Imports System.IO

' Lecture des options depuis un fichier texte (remplacé par l'initialisation dans initialisation.vb)
Public Class OptionsFileService

    Private Const FICHIER_OPTIONS As String = "C:\WVOIE\PARAMETRES\options.opt"

    Public Shared Sub Charger()
        If File.Exists(FICHIER_OPTIONS) = False Then Return

        For Each ligne As String In File.ReadAllLines(FICHIER_OPTIONS)
            Dim t() As String = ligne.Split(vbTab)
            If t.Length < 2 Then Continue For
            Select Case t(0)
                Case "DAO" : Option_WVOIE.DAO = t(1)
                Case "RIPAGE_AUTO" : Option_WVOIE.Ripage_Auto = t(1)
            End Select
        Next
    End Sub

End Class
