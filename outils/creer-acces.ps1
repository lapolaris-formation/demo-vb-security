# Crée ou complète C:\WVOIE\PARAMETRES\acces.par sur le poste de la machine (installation SAV).
# Le mot de passe est saisi masqué et n'est jamais écrit : seule son empreinte PBKDF2 salée l'est.
# Paramètres identiques à WinVOIE\Module\Controle_Acces.vb : SHA-256, 210 000 itérations, sel 16 octets, empreinte 32 octets.
#
# Usage, en administrateur sur le poste :
#   powershell -File outils\creer-acces.ps1 -Profil SUPERVISEUR
#   powershell -File outils\creer-acces.ps1 -Profil SAV

param(
    [Parameter(Mandatory = $true)]
    [ValidateSet("SUPERVISEUR", "SAV")]
    [string] $Profil,

    [string] $Fichier = "C:\WVOIE\PARAMETRES\acces.par"
)

$ErrorActionPreference = "Stop"

$saisie1 = Read-Host "Nouveau mot de passe $Profil" -AsSecureString
$saisie2 = Read-Host "Confirmation" -AsSecureString
$mdp1 = [Runtime.InteropServices.Marshal]::PtrToStringBSTR([Runtime.InteropServices.Marshal]::SecureStringToBSTR($saisie1))
$mdp2 = [Runtime.InteropServices.Marshal]::PtrToStringBSTR([Runtime.InteropServices.Marshal]::SecureStringToBSTR($saisie2))

if ($mdp1 -ne $mdp2) { throw "Les deux saisies sont différentes." }
if ($mdp1.Length -lt 12) { throw "12 caractères minimum." }

$sel = New-Object byte[] 16
[Security.Cryptography.RandomNumberGenerator]::Create().GetBytes($sel)
$pbkdf2 = New-Object Security.Cryptography.Rfc2898DeriveBytes($mdp1, $sel, 210000, [Security.Cryptography.HashAlgorithmName]::SHA256)
$empreinte = $pbkdf2.GetBytes(32)
$pbkdf2.Dispose()

$ligne = "$Profil`t$([Convert]::ToBase64String($sel))`t$([Convert]::ToBase64String($empreinte))"

# Une seule ligne par profil : l'ancienne est remplacée
$lignes = @()
if (Test-Path $Fichier) { $lignes = @(Get-Content $Fichier | Where-Object { $_ -notlike "$Profil`t*" }) }
New-Item -ItemType Directory -Force (Split-Path $Fichier) | Out-Null
Set-Content -Path $Fichier -Value ($lignes + $ligne) -Encoding ASCII

Write-Host "Profil $Profil enregistré dans $Fichier"
