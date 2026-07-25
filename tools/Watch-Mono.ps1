<#
.SYNOPSIS
    problems\ 配下の Program.cs を監視し、保存されるたびに mcs (paiza と同じコンパイラ) に通します。

.DESCRIPTION
    Roslyn (VS Code の赤波線) は通しても mcs が通さないコードがあります。
      - ローカル関数           -> CS1525
      - switch 文の型パターン  -> CS0589
      - Mono に無い API        -> CS1061
    これらをビルドを待たずに検出するため、保存の 1 秒後に mcs のエラーを
    「問題」パネルへ流し込みます。

    VS Code ではフォルダを開いたときに自動起動します
    (初回だけ「このフォルダーで自動タスクを許可しますか?」に許可が必要)。

.EXAMPLE
    .\tools\Watch-Mono.ps1
#>
[CmdletBinding()]
param(
    # 監視の間隔 (ミリ秒)
    [int]$IntervalMs = 700
)

$ErrorActionPreference = 'Continue'
$root        = Split-Path -Parent $PSScriptRoot
$problemsDir = Join-Path $root 'problems'

function Find-MonoTool([string]$tool) {
    $cmd = Get-Command $tool -ErrorAction SilentlyContinue
    if ($cmd) { return $cmd.Source }
    foreach ($base in @("$env:ProgramFiles\Mono\bin", "${env:ProgramFiles(x86)}\Mono\bin")) {
        foreach ($ext in @('.bat', '.exe')) {
            $p = Join-Path $base "$tool$ext"
            if (Test-Path -LiteralPath $p) { return $p }
        }
    }
    return $null
}

$mcs = Find-MonoTool 'mcs'
if (-not $mcs) {
    Write-Host "mcs が見つからないため監視を開始しません。" -ForegroundColor Yellow
    Write-Host "  winget install Mono.Mono" -ForegroundColor Yellow
    exit 1
}

# 多重起動を防ぐ。
# VS Code のウィンドウ再読み込みでは folderOpen タスクが再度起動する一方、
# 前のプロセスが残ることがあり、放っておくと監視が 2 重になって
# 同じエラーを二度出したり CPU を無駄に食ったりする。
# リポジトリのパスから名前を作るので、別フォルダの監視とは競合しない。
$md5      = [System.Security.Cryptography.MD5]::Create()
$hash     = [BitConverter]::ToString($md5.ComputeHash([Text.Encoding]::UTF8.GetBytes($root.ToLowerInvariant()))).Replace('-', '')
$mutex    = New-Object System.Threading.Mutex($false, "Local\paiza-mcs-watch-$hash")
$acquired = $false
try { $acquired = $mutex.WaitOne(0) } catch [System.Threading.AbandonedMutexException] { $acquired = $true }

if (-not $acquired) {
    Write-Host "このフォルダの mcs 監視は既に動いているので、このプロセスは終了します。" -ForegroundColor DarkGray
    exit 0
}

Write-Host "mcs 監視を開始しました ($mcs)"
Write-Host "problems\**\Program.cs を保存すると paiza と同じコンパイラでチェックします。"

# コンパイル結果の置き場はリポジトリ直下に 1 つだけ作る。
# 問題フォルダの中に書き込むと、このプロセスがフォルダのハンドルを掴んでしまい、
# Remove-Problem.ps1 での削除が「別のプロセスが使用中」で失敗する。
$cacheDir = Join-Path $root '.mcs-cache'
if (-not (Test-Path -LiteralPath $cacheDir)) {
    New-Item -ItemType Directory -Force -Path $cacheDir | Out-Null
}
$outExe = Join-Path $cacheDir 'mcs-watch.exe'

# 1 ファイル分の mcs チェック。エラー行をそのまま標準出力に流す (VS Code が拾う)
function Invoke-McsCheck([System.IO.FileInfo]$file) {
    $out = & $mcs -target:exe -nologo "-out:$outExe" $file.FullName 2>&1
    $failed = ($LASTEXITCODE -ne 0)

    foreach ($line in $out) {
        # mono/mcs は出力の先頭に BOM を書くので除去する
        $text = ($line -replace "`u{feff}", '').TrimEnd()
        if ($text) { Write-Host $text }
    }
    return $failed
}

$stamps  = @{}   # path -> LastWriteTimeUtc.Ticks
$failing = @{}   # path -> $true (前回エラーだったファイル)

while ($true) {
    $files = @(Get-ChildItem -LiteralPath $problemsDir -Recurse -Filter 'Program.cs' -File -ErrorAction SilentlyContinue)

    $changed = @()
    foreach ($f in $files) {
        $stamp = $f.LastWriteTimeUtc.Ticks
        if ($stamps[$f.FullName] -ne $stamp) {
            $stamps[$f.FullName] = $stamp
            $changed += $f
        }
    }

    if ($changed.Count -gt 0) {
        # 前回エラーだったファイルも一緒に再チェックする。
        # VS Code は checking で既存の診断を消すため、これをしないと
        # 他ファイルのエラー表示が消えたままになる。
        $targets = @{}
        foreach ($f in $changed) { $targets[$f.FullName] = $f }
        foreach ($path in @($failing.Keys)) {
            if (-not $targets.ContainsKey($path) -and (Test-Path -LiteralPath $path)) {
                $targets[$path] = Get-Item -LiteralPath $path
            }
        }

        Write-Host "[mcs] checking"
        foreach ($f in $targets.Values) {
            if (Invoke-McsCheck $f) { $failing[$f.FullName] = $true }
            else { $failing.Remove($f.FullName) }
        }
        Write-Host "[mcs] done"
    }

    Start-Sleep -Milliseconds $IntervalMs
}
