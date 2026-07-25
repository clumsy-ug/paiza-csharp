<#
.SYNOPSIS
    新しい問題フォルダを作って、ソリューションに追加します。

.EXAMPLE
    .\tools\New-Problem.ps1 sum_of_array      # → problems\004_sum_of_array
    .\tools\New-Problem.ps1 010_my_problem    # 番号を自分で付けてもOK
#>
[CmdletBinding()]
param(
    [Parameter(Mandatory, Position = 0)]
    [string]$Name,

    # 作成後に VS Code で Program.cs を開く
    [switch]$Open
)

$ErrorActionPreference = 'Stop'
$root        = Split-Path -Parent $PSScriptRoot
$problemsDir = Join-Path $root 'problems'
$templateDir = Join-Path $root 'templates\problem'

. (Join-Path $PSScriptRoot '_Solution.ps1')

# 日本語の問題名をそのまま使える。Windows のパスとして使えない文字だけ弾く。
$Name = $Name.Trim()
if ([string]::IsNullOrWhiteSpace($Name)) {
    throw "問題名を指定してください。"
}
# 空白は _ に置き換える（コマンドラインで扱いづらいため）
$Name = $Name -replace '\s+', '_'

$invalid = [char[]]'\/:*?"<>|'
foreach ($c in $invalid) {
    if ($Name.Contains($c)) {
        throw "問題名に使えない文字が含まれています ($c): $Name"
    }
}
if ($Name -match '[\x00-\x1f]' -or $Name.EndsWith('.')) {
    throw "問題名に使えない文字が含まれています: $Name"
}
# Windows の予約名
if ($Name -match '^(CON|PRN|AUX|NUL|COM[1-9]|LPT[1-9])(\..*)?$') {
    throw "Windows の予約名は使えません: $Name"
}

# 先頭が NNN_ でなければ、次の連番を自動で付ける
# ('3つのデータの入力' のように数字で始まる日本語名を「番号付き」と誤判定しないため NNN_ で判定する)
if ($Name -notmatch '^\d{3}_') {
    $used = Get-ChildItem -LiteralPath $problemsDir -Directory |
            ForEach-Object { if ($_.Name -match '^(\d{3})_') { [int]$Matches[1] } }
    # Measure-Object は Maximum を double で返すことがあるので、必ず int にする（D3 書式が失敗する）
    $next = if ($used) { [int](($used | Measure-Object -Maximum).Maximum) + 1 } else { 1 }
    $Name = ('{0:D3}_{1}' -f [int]$next, $Name)
}

$dir = Join-Path $problemsDir $Name
if (Test-Path -LiteralPath $dir) { throw "もう存在します: $dir" }

# 問題名に [ ] などワイルドカード扱いされる文字が入っても壊れないよう、
# ディレクトリ作成もコピーもリテラル指定で行う
[System.IO.Directory]::CreateDirectory($dir) | Out-Null

foreach ($f in @('Program.cs', 'input.txt', 'expected.txt', 'memo.md')) {
    Copy-Item -LiteralPath (Join-Path $templateDir $f) -Destination $dir
}

@"
<Project Sdk="Microsoft.NET.Sdk">
  <!-- 共通設定は ..\..\Directory.Build.props にある -->
</Project>
"@ | Set-Content -LiteralPath (Join-Path $dir "$Name.csproj") -Encoding utf8NoBOM

# ソリューションに追加（VS Code / Visual Studio のソリューションエクスプローラーに出るように）
$sln = Get-SolutionFile $root
if ($sln) {
    # 手削除された問題の参照が残っていれば先に掃除する
    $fixed = Repair-Solution $sln $root
    if ($fixed -gt 0) {
        Write-Host "ソリューションから実体のない参照 $fixed 件を取り除きました。" -ForegroundColor DarkGray
    }
    dotnet sln $sln add (Join-Path $dir "$Name.csproj") | Out-Null
}

Write-Host "作成しました: problems\$Name" -ForegroundColor Green
Write-Host ""
Write-Host "次にやること:" -ForegroundColor Cyan
Write-Host "  1. problems\$Name\input.txt    に問題の入力例を貼る"
Write-Host "  2. problems\$Name\expected.txt に期待する出力例を貼る"
Write-Host "  3. problems\$Name\Program.cs   を書く"
Write-Host "  4. Program.cs を開いた状態で Ctrl+Shift+B で採点"

if ($Open) { code (Join-Path $dir 'Program.cs') }
