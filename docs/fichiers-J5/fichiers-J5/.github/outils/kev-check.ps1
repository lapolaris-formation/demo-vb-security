# 1. Restaurer les packages NuGet. La restauration affiche les avertissements NU1901 a NU1904.
$log = msbuild WinBAO.sln -t:restore -p:RestorePackagesConfig=true 2>&1 | Out-String

# Si msbuild a echoue, afficher son message et arreter.
if ($LASTEXITCODE -ne 0) { Write-Host $log; exit 1 }

# 2. Extraire les identifiants d'avis GitHub (GHSA), sans doublons.
$ghsas = [regex]::Matches($log, 'GHSA(-[0-9a-z]{4}){3}') | ForEach-Object Value | Sort-Object -Unique

# 3. Telecharger les listes de reference.
$kev = (Invoke-RestMethod https://www.cisa.gov/sites/default/files/feeds/known_exploited_vulnerabilities.json).vulnerabilities.cveID
$certfr = foreach ($alerte in (Invoke-RestMethod https://www.cert.ssi.gouv.fr/alerte/feed/)) {
  (Invoke-RestMethod ($alerte.link + 'json/')).cves.name
}

$exploitees = @()

# 4. Pour chaque avis GHSA trouve
foreach ($ghsa in $ghsas) {

  $cve = (gh api "/advisories/$ghsa" | ConvertFrom-Json).cve_id
  if (-not $cve) { Write-Host "$ghsa : pas de CVE associee"; continue }

  $item = (Invoke-RestMethod "https://euvdservices.enisa.europa.eu/api/search?text=$cve" -UserAgent 'veille-cra').items | Where-Object { $_.aliases -match $cve }
  $euvd = [bool]$item.exploitedSince

  $epss = (Invoke-RestMethod "https://api.first.org/data/v1/epss?cve=$cve").data.epss

  $enKev = $kev -contains $cve
  $enCertfr = $certfr -contains $cve

  $ligne = "$ghsa -> $cve | KEV: $enKev | EUVD exploitee: $euvd | Alerte CERT-FR: $enCertfr | EPSS: $epss"
  Write-Host $ligne
  if ($env:GITHUB_STEP_SUMMARY) { Add-Content $env:GITHUB_STEP_SUMMARY "- $ligne" }

  # 5. Si une source dit "exploitee"
  if ($enKev -or $euvd -or $enCertfr) {
    $exploitees += $cve

    if ($env:GITHUB_ACTIONS) {
      $deja = gh issue list --state open --search "$cve in:title" --json number | ConvertFrom-Json
      if (-not $deja) {
        $corps = "Avis : https://github.com/advisories/$ghsa`n`n$ligne`n`nVerifier l'exposition du produit. Si l'exploitation est confirmee, notification article 14 du CRA sous 24 h."
        gh issue create --title "Vulnerabilite exploitee : $cve" --body $corps
      }
    }
  }
}

# 6. Echec du run si au moins une CVE exploitee
if ($exploitees.Count -gt 0) {
  Write-Host "Vulnerabilites exploitees detectees : $($exploitees -join ', ')"
  exit 1
}

exit 0
