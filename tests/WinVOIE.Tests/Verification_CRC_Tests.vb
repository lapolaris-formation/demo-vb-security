Imports Xunit

''' <summary>
''' Fichier_Enreg_Modifie protège l'intégrité des enregistrements de mesure :
''' une valeur modifiée à la main en dehors de WinVOIE doit être détectée.
''' Deux cas sont nécessaires : avec le seul cas « modifié », une fonction
''' qui répondrait toujours True passerait le test.
''' </summary>
Public Class Verification_CRC_Tests
    Implements IDisposable

    Private ReadOnly _fichier As String = Path.Combine(Path.GetTempPath(), "WinVOIE_test_" & Guid.NewGuid().ToString("N") & ".ent")

    ' Ligne d'enregistrement telle que WinVOIE l'écrit : PK, nivellement G, nivellement D, puis la signature
    Private Shared Function LigneSignee(pk As String, nivG As String, nivD As String) As String
        Dim donnees As String = pk & vbTab & nivG & vbTab & nivD
        Return donnees & vbTab & Calcul_Signature(donnees)
    End Function

    <Fact>
    Public Sub Fichier_intact_n_est_pas_signale_comme_modifie()
        File.WriteAllLines(_fichier, {LigneSignee("1250", "12", "-3"),
                                      LigneSignee("1270", "14", "-2")})

        Assert.False(Fichier_Enreg_Modifie(_fichier))
    End Sub

    <Fact>
    Public Sub Valeur_modifiee_a_la_main_est_detectee()
        Dim lignes As String() = {LigneSignee("1250", "12", "-3"),
                                  LigneSignee("1270", "14", "-2")}
        ' Nivellement gauche de la 2e ligne passé de 14 à 4, signature inchangée
        lignes(1) = lignes(1).Replace(vbTab & "14" & vbTab, vbTab & "4" & vbTab)
        File.WriteAllLines(_fichier, lignes)

        Assert.True(Fichier_Enreg_Modifie(_fichier))
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        If File.Exists(_fichier) Then File.Delete(_fichier)
    End Sub

End Class
