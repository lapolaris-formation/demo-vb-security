Imports Xunit

''' <summary>
''' Mot_De_Passe_Valide remplace les mots de passe de maintenance écrits en dur dans les formulaires.
''' Aucun mot de passe réel ici : seulement des valeurs de test.
''' </summary>
Public Class Controle_Acces_Tests
    Implements IDisposable

    Private ReadOnly _fichier As String = Path.Combine(Path.GetTempPath(), "WinVOIE_acces_" & Guid.NewGuid().ToString("N") & ".par")

    <Fact>
    Public Sub Bon_mot_de_passe_du_profil_autorise_est_accepte()
        File.WriteAllLines(_fichier, {Ligne_Acces(PROFIL_SUPERVISEUR, "Essai-Superviseur-2026")})

        Assert.True(Mot_De_Passe_Valide("Essai-Superviseur-2026", {PROFIL_SUPERVISEUR}, _fichier))
    End Sub

    <Fact>
    Public Sub Mauvais_mot_de_passe_est_refuse()
        File.WriteAllLines(_fichier, {Ligne_Acces(PROFIL_SUPERVISEUR, "Essai-Superviseur-2026")})

        Assert.False(Mot_De_Passe_Valide("essai-superviseur-2026", {PROFIL_SUPERVISEUR}, _fichier))
        Assert.False(Mot_De_Passe_Valide("", {PROFIL_SUPERVISEUR}, _fichier))
    End Sub

    <Fact>
    Public Sub Mot_de_passe_SAV_refuse_pour_un_reglage_reserve_au_superviseur()
        File.WriteAllLines(_fichier, {Ligne_Acces(PROFIL_SAV, "Essai-Sav-2026")})

        Assert.False(Mot_De_Passe_Valide("Essai-Sav-2026", {PROFIL_SUPERVISEUR}, _fichier))
    End Sub

    <Fact>
    Public Sub Sans_fichier_d_acces_tout_est_refuse()
        Assert.False(Mot_De_Passe_Valide("Essai-Superviseur-2026", {PROFIL_SUPERVISEUR, PROFIL_SAV}, _fichier))
    End Sub

    ' Ligne produite par outils\creer-acces.ps1 (PowerShell 5.1) pour le mot de passe de test « Essai-Formation-2026 » :
    ' le script du SAV et l'application doivent calculer la même empreinte
    <Fact>
    Public Sub Ligne_creee_par_le_script_SAV_est_acceptee()
        File.WriteAllLines(_fichier, {"SUPERVISEUR" & vbTab & "yxBiLSPLcaX2xSMXdTWzVA==" & vbTab & "7oeVzIUyDRrZEpNb9VTs04wkoX9WzTnbXeR9l4+62Go="})

        Assert.True(Mot_De_Passe_Valide("Essai-Formation-2026", {PROFIL_SUPERVISEUR}, _fichier))
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        If File.Exists(_fichier) Then File.Delete(_fichier)
    End Sub

End Class
