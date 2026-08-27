<#
.SYNOPSIS
    問題フォルダを削除し、ソリューションからも登録を外します。

.DESCRIPTION
    フォルダを手で消すだけでは Paiza.sln に登録が残り、
    ソリューションのビルドが error MSB3202 で失敗します。
    このスクリプトは sln の登録を外してからフォルダを削除します。

.EXAMPLE
    .\tools\Remove-Problem.ps1 005
    .\tools\Remove-Problem.ps1 005_ミス問題 -Force
#>
[CmdletBinding()]
param(
    # 問題フォルダ名 (部分一致でよい) またはフルパス
    [Parameter(Position = 0)]
    [string]$Problem,

    # 確認せずに削除する
    [switch]$Force
)

$ErrorActionPreference = 'Stop'
$root        = Split-Path -Parent $PSScriptRoot
$problemsDir = Join-Path $root 'problems'

. (Join-Path $PSScriptRoot '_Solution.ps1')

function Resolve-ProblemDir([string]$name) {
    if ([string]::IsNullOrWhiteSpace($name)) { return $null }

    if (Test-Path -LiteralPath $name -PathType Container) {
        return (Resolve-Path -LiteralPath $name).Path
    }

    # New-Problem と同じ正規化 (paiza の問題名をそのまま貼っても見つかるように)
    $name = $name -replace ':\s*', '：' -replace '\s+', '_'

    $all = Get-ChildItem -LiteralPath $problemsDir -Directory
    $hit = @($all | Where-Object { $_.Name -eq $name })
    if ($hit.Count -eq 0) { $hit = @($all | Where-Object { $_.Name -like "*$name*" }) }

    if ($hit.Count -eq 1) { return $hit[0].FullName }
    if ($hit.Count -gt 1) {
        Write-Host "候補が複数あります:" -ForegroundColor Yellow
        $hit | ForEach-Object { Write-Host "  $($_.Name)" }
        return $null
    }
    return $null
}

$dir = Resolve-ProblemDir $Problem
if (-not $dir) {
    Write-Host "削除する問題フォルダを指定してください。" -ForegroundColor Yellow
    Write-Host "今ある問題:" -ForegroundColor Cyan
    Get-ChildItem -LiteralPath $problemsDir -Directory | ForEach-Object { Write-Host "  $($_.Name)" }
    exit 1
}

$name = Split-Path -Leaf $dir

# 何を消すのか見せる
Write-Host "削除対象: problems\$name" -ForegroundColor Yellow
$source = Join-Path $dir 'Program.cs'
if (Test-Path -LiteralPath $source) {
    $lines = @(Get-Content -LiteralPath $source).Count
    Write-Host "  Program.cs ... $lines 行" -ForegroundColor DarkGray
}
foreach ($f in @('input.txt', 'expected.txt', 'input2.txt', 'expected2.txt', 'memo.md')) {
    $p = Join-Path $dir $f
    if (Test-Path -LiteralPath $p) {
        $len = (Get-Item -LiteralPath $p).Length
        Write-Host "  $f ... $len バイト" -ForegroundColor DarkGray
    }
}

if (-not $Force) {
    Write-Host ""
    # y / yes だけを承諾とみなす（大文字小文字は問わない）。それ以外は安全側に倒して中止。
    $answer = (Read-Host "本当に削除しますか? 取り消せません (y/n)").Trim()
    if ($answer -notmatch '^(y|yes)$') {
        Write-Host "中止しました。" -ForegroundColor Cyan
        exit 0
    }
}

$sln = Get-SolutionFile $root
if ($sln) {
    # 手削除された問題の参照が残っていれば掃除する
    $fixed = Repair-Solution $sln $root
    if ($fixed -gt 0) {
        Write-Host "ソリューションから実体のない参照 $fixed 件を取り除きました。" -ForegroundColor DarkGray
    }
}

# 削除対象フォルダの列挙は @() で受け切る。
# `... | Select-Object -First 1` はパイプラインを途中で打ち切るので、
# 削除しようとしているフォルダの列挙ハンドルを掴んだままになりかねない。
$csprojFiles = @(Get-ChildItem -LiteralPath $dir -Filter '*.csproj' -File)
$csprojPath  = if ($csprojFiles.Count -gt 0) { $csprojFiles[0].FullName } else { $null }

# sln の登録を先に外す。理由は 2 つ。
#  1. 逆順だと、フォルダ削除が途中で失敗したとき (子ファイルは消えるが
#     フォルダだけ残ることがある) csproj だけ消えて sln に登録が残り、
#     error MSB3202 でソリューションのビルドが壊れる。
#  2. 登録を外すと言語サーバーがプロジェクトを閉じる。
if ($sln -and $csprojPath) {
    dotnet sln $sln remove $csprojPath | Out-Null
    Write-Host "ソリューションから登録を外しました。" -ForegroundColor DarkGray
}

# VS Code の C# Dev Kit は、追加された直後のプロジェクトを自動で復元・ビルドし、
# その間フォルダのハンドルを保持する (bin\ obj\ が勝手に生えるのがその痕跡)。
# ソリューションから外した後は数秒で解放されるので、それを待つ。
# Remove-Item -Recurse ではなく Directory.Delete を使う (挙動が素直)。
$waits   = @(500, 1000, 1500, 2000, 3000, 4000, 5000)
$deleted = $false
$lastErr = $null

for ($i = 0; $i -le $waits.Count; $i++) {
    try {
        [System.IO.Directory]::Delete($dir, $true)
        $deleted = $true
        break
    } catch {
        $lastErr = $_
        if ($i -eq $waits.Count) { break }
        if ($i -eq 0) {
            # MSBuild のビルドサーバーが掴んでいる場合はこれで外れる
            dotnet build-server shutdown 2>&1 | Out-Null
        }
        if ($i -eq 1) { Write-Host "使用中のため解放を待っています..." -ForegroundColor DarkGray }
        Start-Sleep -Milliseconds $waits[$i]
    }
}

if (-not $deleted) {
    $left = @(Get-ChildItem -LiteralPath $dir -Recurse -Force -ErrorAction SilentlyContinue).Count
    Write-Host ""
    Write-Host "フォルダを削除できませんでした（他のプロセスが使用中）。" -ForegroundColor Red
    Write-Host $lastErr.Exception.Message -ForegroundColor DarkGray
    Write-Host ""
    Write-Host "ソリューションの登録は外れているので、ビルドは壊れていません。" -ForegroundColor Cyan
    if ($left -eq 0) {
        Write-Host "残っているのは空フォルダだけです。" -ForegroundColor Cyan
    }
    Write-Host "少し待ってもう一度実行するか、エクスプローラーで手動削除してください。" -ForegroundColor Cyan
    exit 1
}

Write-Host "削除しました: problems\$name" -ForegroundColor Green
