# Crée une branche qui rétrograde Newtonsoft.Json en 12.0.3 (GHSA-5crp-9r3c-p9vr, sévérité High)
# puis la pousse : ouvrir ensuite une PR vers main pour voir "Revue des dépendances" bloquer.
# Usage (à la racine du dépôt) :  powershell -File .github\demo\creer-branche-newtonsoft-vulnerable.ps1

$ErrorActionPreference = "Stop"
$branche = "demo/newtonsoft-vulnerable"

git switch -c $branche

$pc = "WinVOIE\packages.config"
(Get-Content $pc -Raw) -replace 'id="Newtonsoft.Json" version="13.0.4"', 'id="Newtonsoft.Json" version="12.0.3"' |
    Set-Content $pc -NoNewline -Encoding UTF8

$proj = "WinVOIE\WinVOIE.vbproj"
(Get-Content $proj -Raw) `
    -replace 'Newtonsoft.Json, Version=13.0.0.0', 'Newtonsoft.Json, Version=12.0.0.0' `
    -replace 'Newtonsoft.Json.13.0.4\\lib', 'Newtonsoft.Json.12.0.3\lib' |
    Set-Content $proj -NoNewline -Encoding UTF8

git add $pc $proj
git commit -m "Retour Newtonsoft.Json 12.0.3 (compatibilite ancien PC enregistrement)"
git push -u origin $branche

Write-Host "Branche $branche poussée. Ouvrir une PR vers main."
