<#
.SYNOPSIS
    問題を paiza と同じツールチェーン (Mono の mcs + mono) でコンパイル・実行し、
    出力を expected*.txt と比較します。

.DESCRIPTION
    paiza は Program.cs 単体をコンパイルして標準入力を流し込むので、ここでも同じことをします。
    Mono が見つからない場合は .NET でのビルド・実行にフォールバックします
    (その場合 Mono に存在しない API は検出できません)。

.EXAMPLE
    .\tools\Run-Problem.ps1 001
    .\tools\Run-Problem.ps1 002_two_ints
    .\tools\Run-Problem.ps1 003 -Interactive   # 自分でキーボード入力する
    .\tools\Run-Problem.ps1 003 -UseDotnet     # .NET 側で実行する
#>
[CmdletBinding()]
param(
    # 問題フォルダ名 (部分一致でよい) またはフルパス
    [Parameter(Position = 0)]
    [string]$Problem,

    # input.txt を使わず、キーボードから入力する
    [switch]$Interactive,

    # expected*.txt との比較をしない
    [switch]$NoCompare,

    # 判定も装飾もせず、プログラムの出力だけをそのまま出す (Console.WriteLine のデバッグ用)
    [switch]$OutputOnly,

    # Mono ではなく .NET で実行する
    [switch]$UseDotnet
)

$ErrorActionPreference = 'Stop'

# ---- 文字化け対策 ----------------------------------------------------------
# 日本語 Windows のコンソールは既定が CP932 だが、VS Code のターミナルは常に
# UTF-8 として解釈し、mono/mcs も UTF-8 で出力する。合わせておかないと
# 日本語が化ける。子プロセスの stdout/stdin の解釈もこの設定で決まる。
try { [Console]::OutputEncoding = [System.Text.UTF8Encoding]::new($false) } catch { }
try { [Console]::InputEncoding  = [System.Text.UTF8Encoding]::new($false) } catch { }
$OutputEncoding = [System.Text.UTF8Encoding]::new($false)

# 出力だけ見たいときは判定もしない
if ($OutputOnly) { $NoCompare = $true }
$root        = Split-Path -Parent $PSScriptRoot
$problemsDir = Join-Path $root 'problems'

# ---- 問題フォルダの特定 ----------------------------------------------------
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

function Normalize([string]$text) {
    if ($null -eq $text) { return @() }
    # mono は出力の先頭に UTF-8 BOM を書くので除去する
    $text = $text -replace "`u{feff}", ''
    $lines = $text -replace "`r`n", "`n" -replace "`r", "`n" -split "`n"
    # 末尾の空行は無視して比較する
    $end = $lines.Count - 1
    while ($end -ge 0 -and $lines[$end].Trim() -eq '') { $end-- }
    if ($end -lt 0) { return @() }
    return $lines[0..$end] | ForEach-Object { $_.TrimEnd() }
}

$dir = Resolve-ProblemDir $Problem
if (-not $dir) {
    Write-Host "問題フォルダを指定してください。" -ForegroundColor Yellow
    Write-Host "使える問題:" -ForegroundColor Cyan
    Get-ChildItem -LiteralPath $problemsDir -Directory | ForEach-Object { Write-Host "  $($_.Name)" }
    exit 1
}

$source = Join-Path $dir 'Program.cs'
if (-not (Test-Path -LiteralPath $source)) { throw "Program.cs が見つかりません: $dir" }

if (-not $OutputOnly) { Write-Host "=== $(Split-Path -Leaf $dir) ===" -ForegroundColor Cyan }

# ---- コンパイル ------------------------------------------------------------
# $cmd + $cmdArgs で実行する形に揃える
$mcs  = if ($UseDotnet) { $null } else { Find-MonoTool 'mcs' }
$mono = if ($UseDotnet) { $null } else { Find-MonoTool 'mono' }

$usedEnv = @{}

if ($mcs -and $mono) {
    # paiza と同じ: Program.cs 単体を mcs でコンパイルし、mono で実行する
    $exe = Join-Path $dir 'bin\mono\Program.exe'
    New-Item -ItemType Directory -Force -Path (Split-Path $exe) | Out-Null

    $log = & $mcs -target:exe -nologo "-out:$exe" $source 2>&1
    if ($LASTEXITCODE -ne 0) {
        $log | ForEach-Object { Write-Host ($_ -replace "`u{feff}", '') -ForegroundColor Red }
        Write-Host ""
        Write-Host "mcs (paiza と同じコンパイラ) でコンパイルできませんでした。" -ForegroundColor Red
        Write-Host "このコードは paiza でも通りません。" -ForegroundColor Red
        exit 1
    }
    $log | Where-Object { $_ -match 'warning' } | ForEach-Object { Write-Host ($_ -replace "`u{feff}", '') -ForegroundColor Yellow }

    $cmd     = $mono
    $cmdArgs = @($exe)
    if (-not $OutputOnly) { Write-Host "コンパイル: mcs / 実行: mono (paiza と同じ)" -ForegroundColor DarkGray }
} else {
    # フォールバック: .NET でビルドして実行する
    if (-not $UseDotnet) {
        Write-Host "Mono が見つからないため .NET で実行します (Mono に無い API は検出できません)。" -ForegroundColor Yellow
        Write-Host "  winget install Mono.Mono" -ForegroundColor Yellow
    }

    $csproj = Get-ChildItem -LiteralPath $dir -Filter '*.csproj' | Select-Object -First 1
    if (-not $csproj) { throw ".csproj が見つかりません: $dir" }

    $buildLog = dotnet build $csproj.FullName --nologo -v quiet 2>&1
    if ($LASTEXITCODE -ne 0) {
        $buildLog | ForEach-Object { Write-Host $_ }
        Write-Host ""
        Write-Host "ビルド失敗（上のエラーを直してください）" -ForegroundColor Red
        exit 1
    }

    # 出力名は Directory.Build.props で problem に固定してある
    $cmd     = Join-Path $dir 'bin\Debug\net10.0\problem.exe'
    $cmdArgs = @()
    if (-not (Test-Path -LiteralPath $cmd)) { throw "実行ファイルが見つかりません: $cmd" }

    # LocalRunner による input.txt の読み込みを止め、標準入力はこちらから渡す
    $usedEnv['PAIZA_STDIN'] = 'pipe'
    if (-not $OutputOnly) { Write-Host "コンパイル: Roslyn / 実行: .NET" -ForegroundColor DarkGray }
}

# ---- 対話モード ------------------------------------------------------------
if ($Interactive) {
    $saved = $env:PAIZA_STDIN
    try {
        $env:PAIZA_STDIN = 'console'
        & $cmd @cmdArgs
    } finally {
        $env:PAIZA_STDIN = $saved
    }
    exit $LASTEXITCODE
}

# ---- テストケース (input.txt / input2.txt ... と expected*.txt の対) --------
$inputs = @(Get-ChildItem -LiteralPath $dir -Filter 'input*.txt' | Sort-Object Name)
if ($inputs.Count -eq 0) {
    if (-not $OutputOnly) { Write-Host "input*.txt がないので、入力なしで実行します。" -ForegroundColor DarkGray }
    $inputs = @($null)
}

$outFile  = Join-Path $dir 'bin\_last_output.txt'
$errFile  = Join-Path $dir 'bin\_last_stderr.txt'
New-Item -ItemType Directory -Force -Path (Split-Path $outFile) | Out-Null
$allOk    = $true
$anyCheck = $false

$savedEnv = @{}
foreach ($k in $usedEnv.Keys) { $savedEnv[$k] = [Environment]::GetEnvironmentVariable($k) }

try {
    foreach ($k in $usedEnv.Keys) { Set-Item -Path "env:$k" -Value $usedEnv[$k] }

    foreach ($inp in $inputs) {
        # New-Problem は予備の input2.txt / expected2.txt を空で用意する。
        # 両方とも空のままの対は「使っていないテストケース」なので実行しない。
        if ($inp) {
            $suffix       = $inp.BaseName -replace '^input', ''
            $expectedPath = Join-Path $dir "expected$suffix.txt"
            $inpEmpty = [string]::IsNullOrWhiteSpace((Get-Content -LiteralPath $inp.FullName -Raw))
            $expEmpty = -not (Test-Path -LiteralPath $expectedPath) -or
                        [string]::IsNullOrWhiteSpace((Get-Content -LiteralPath $expectedPath -Raw))
            if ($inpEmpty -and $expEmpty) {
                Write-Host ""
                Write-Host "-- 入力: $($inp.Name) は空なのでスキップ" -ForegroundColor DarkGray
                continue
            }
        }

        $label = if ($inp) { $inp.Name } else { '(入力なし)' }
        # 出力だけ見たいときは、入力が複数あるときだけ区切りを出す
        if (-not $OutputOnly) {
            Write-Host ""
            Write-Host "-- 入力: $label" -ForegroundColor DarkCyan
        } elseif ($inputs.Count -gt 1) {
            Write-Host ""
            Write-Host "-- $label" -ForegroundColor DarkCyan
        }

        if ($inp) {
            Get-Content -LiteralPath $inp.FullName | & $cmd @cmdArgs > $outFile 2> $errFile
        } else {
            '' | & $cmd @cmdArgs > $outFile 2> $errFile
        }
        $code = $LASTEXITCODE

        # mono は BOM だけの行を stderr に出すので、中身があるときだけ表示する
        $errRaw = if (Test-Path -LiteralPath $errFile) { (Get-Content -LiteralPath $errFile -Raw) -replace "`u{feff}", '' } else { '' }
        if (-not [string]::IsNullOrWhiteSpace($errRaw)) {
            if (-not $OutputOnly) { Write-Host "-- 標準エラー:" -ForegroundColor DarkYellow }
            $errRaw.TrimEnd() -split "`n" | ForEach-Object {
                $prefix = if ($OutputOnly) { '' } else { '  ' }
                Write-Host "$prefix$($_.TrimEnd())" -ForegroundColor Yellow
            }
        }

        $actualRaw = if (Test-Path -LiteralPath $outFile) { Get-Content -LiteralPath $outFile -Raw } else { '' }
        if ($OutputOnly) {
            # デバッグ用。インデントも整形もせず、書いたとおりに出す
            if (-not [string]::IsNullOrEmpty($actualRaw)) {
                ($actualRaw -replace "`u{feff}", '').TrimEnd("`r", "`n") -split "`r?`n" | ForEach-Object { Write-Host $_ }
            }
        } else {
            Write-Host "-- 出力:" -ForegroundColor DarkCyan
            if ([string]::IsNullOrEmpty($actualRaw)) {
                Write-Host "  (なし)" -ForegroundColor DarkGray
            } else {
                (Normalize $actualRaw) | ForEach-Object { Write-Host "  $_" }
            }
        }

        if ($code -ne 0) {
            $prefix = if ($OutputOnly) { '' } else { '  ' }
            Write-Host "$prefix終了コード $code (実行時エラー)" -ForegroundColor Red
            $allOk = $false
            continue
        }

        if ($NoCompare) { continue }

        # input.txt -> expected.txt / input2.txt -> expected2.txt
        $suffix       = if ($inp) { $inp.BaseName -replace '^input', '' } else { '' }
        $expectedPath = Join-Path $dir "expected$suffix.txt"
        $expectedRaw  = if (Test-Path -LiteralPath $expectedPath) { Get-Content -LiteralPath $expectedPath -Raw } else { $null }
        if ([string]::IsNullOrWhiteSpace($expectedRaw)) {
            # ファイルが無い場合も、テンプレートのまま空の場合も判定しない
            Write-Host "  (expected$suffix.txt が空か存在しないので判定なし)" -ForegroundColor DarkGray
            continue
        }

        $anyCheck = $true
        # @() は必須: 1 行だけのとき、配列でなく文字列になって文字単位比較になるのを防ぐ
        $expected = @(Normalize $expectedRaw)
        $actual   = @(Normalize $actualRaw)

        $same = $expected.Count -eq $actual.Count
        if ($same) {
            for ($i = 0; $i -lt $expected.Count; $i++) {
                if ($expected[$i] -cne $actual[$i]) { $same = $false; break }
            }
        }

        if ($same) {
            Write-Host "  [OK] expected$suffix.txt と一致" -ForegroundColor Green
        } else {
            $allOk = $false
            Write-Host "  [NG] expected$suffix.txt と不一致" -ForegroundColor Red
            $max = [Math]::Max($expected.Count, $actual.Count)
            for ($i = 0; $i -lt $max; $i++) {
                $e = if ($i -lt $expected.Count) { $expected[$i] } else { '(なし)' }
                $a = if ($i -lt $actual.Count)   { $actual[$i] }   else { '(なし)' }
                if ($e -cne $a) {
                    Write-Host "    $($i + 1) 行目: 期待 [$e] / 実際 [$a]" -ForegroundColor Red
                }
            }
        }
    }
} finally {
    foreach ($k in $savedEnv.Keys) { Set-Item -Path "env:$k" -Value $savedEnv[$k] }
}

if ($OutputOnly) { if ($allOk) { exit 0 } else { exit 1 } }

Write-Host ""
# 実行時エラーは expected の有無に関係なく失敗として扱う
if (-not $allOk) {
    Write-Host "NG あり" -ForegroundColor Red
    exit 1
}
if (-not $anyCheck) {
    Write-Host "実行完了（判定なし）" -ForegroundColor DarkGray
    exit 0
}
Write-Host "すべて OK" -ForegroundColor Green
exit 0
