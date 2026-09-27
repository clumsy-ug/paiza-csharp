# Run-Problem.ps1 / Watch-Mono.ps1 から dot-source して使う、Mono (mcs / mono) を探す共通処理。
# 単体で実行するものではない。Windows と macOS の両方で動く。

# mcs / mono の実行ファイルのパスを返す。見つからなければ $null
function Find-MonoTool([string]$tool) {
    $cmd = Get-Command $tool -ErrorAction SilentlyContinue
    if ($cmd) { return $cmd.Source }

    # PATH に無いときは、既定のインストール先を探す
    $candidates = if ($env:OS -eq 'Windows_NT') {
        foreach ($base in @("$env:ProgramFiles\Mono\bin", "${env:ProgramFiles(x86)}\Mono\bin")) {
            foreach ($ext in @('.bat', '.exe')) { Join-Path $base "$tool$ext" }
        }
    } else {
        # Homebrew (Apple Silicon / Intel) と Mono 公式の .pkg
        foreach ($base in @('/opt/homebrew/bin', '/usr/local/bin', '/Library/Frameworks/Mono.framework/Versions/Current/Commands')) {
            Join-Path $base $tool
        }
    }
    foreach ($p in $candidates) {
        if (Test-Path -LiteralPath $p) { return $p }
    }
    return $null
}

# Mono が見つからないときに案内するインストール方法
function Get-MonoInstallHint {
    if ($env:OS -eq 'Windows_NT') { 'winget install Mono.Mono' } else { 'brew install mono' }
}
