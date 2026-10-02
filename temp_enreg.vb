    ' test lecture enregistrement - a supprimer
    Private Sub Test_Lecture()
        Dim lignes() As String = System.IO.File.ReadAllLines("C:\ENREGISTREMENTS\TRAVAIL\test.ent")
        For Each l As String In lignes
            Debug.WriteLine(l)
        Next
    End Sub
