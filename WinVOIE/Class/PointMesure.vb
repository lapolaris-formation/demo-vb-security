''' <summary>
''' Point de mesure d'un enregistrement travail (une ligne du fichier .ent)
''' Valeurs en dixièmes de mm
''' </summary>
Public Class PointMesure
    Public PK As Integer
    Public Nivellement_Gauche As Integer
    Public Nivellement_Droit As Integer
    Public Devers As Integer
    Public Fleche As Integer
    Public Ecartement As Integer
    Public HorsSeuil As Boolean

    Public Sub New()
    End Sub

    Public Sub New(ligne As String)
        Dim LigneArray() As String = Split(ligne, vbTab)
        If LigneArray.Length >= 6 Then
            PK = LigneArray(0)
            Nivellement_Gauche = LigneArray(1)
            Nivellement_Droit = LigneArray(2)
            Devers = LigneArray(3)
            Fleche = LigneArray(4)
            Ecartement = LigneArray(5)
        End If
    End Sub
End Class
