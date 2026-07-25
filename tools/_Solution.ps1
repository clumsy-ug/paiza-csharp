# New-Problem.ps1 / Remove-Problem.ps1 から dot-source して使う共通処理。
# 単体で実行するものではない。

# ソリューションファイルを返す (.slnx を優先)
function Get-SolutionFile([string]$root) {
    foreach ($ext in @('*.slnx', '*.sln')) {
        $hit = @(Get-ChildItem -LiteralPath $root -Filter $ext -File)
        if ($hit.Count -gt 0) { return $hit[0].FullName }
    }
    return $null
}

# 実体が無いプロジェクト参照を .slnx から取り除く。
# フォルダをエクスプローラーで手削除した後などに残る参照を掃除する。
# 残したままだと dotnet build が error MSB3202 で失敗し、
# VS Code の C# Dev Kit も「Projects: x N」とエラーを出す。
# 戻り値は取り除いた件数。
function Repair-Solution([string]$slnPath, [string]$root) {
    if (-not $slnPath -or -not $slnPath.EndsWith('.slnx')) { return 0 }

    [xml]$xml = Get-Content -LiteralPath $slnPath -Raw
    $removed = 0

    foreach ($node in @($xml.SelectNodes('//Project'))) {
        $rel = $node.GetAttribute('Path')
        if ([string]::IsNullOrWhiteSpace($rel)) { continue }

        $full = Join-Path $root ($rel -replace '/', '\')
        if (-not (Test-Path -LiteralPath $full)) {
            $node.ParentNode.RemoveChild($node) | Out-Null
            $removed++
        }
    }

    if ($removed -gt 0) {
        # dotnet が生成する .slnx に合わせて、XML 宣言なし・BOM なし・2 スペースで書き戻す
        $settings = New-Object System.Xml.XmlWriterSettings
        $settings.Indent             = $true
        $settings.IndentChars        = '  '
        $settings.OmitXmlDeclaration = $true
        $settings.Encoding           = New-Object System.Text.UTF8Encoding($false)

        $writer = [System.Xml.XmlWriter]::Create($slnPath, $settings)
        try { $xml.Save($writer) } finally { $writer.Close() }
    }

    return $removed
}
