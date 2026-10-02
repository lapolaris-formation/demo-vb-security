' ANCIEN CODE - NE PLUS UTILISER - garder pour reference (avant passage PDF)
'
'Imports System.Net.Mail.SmtpClient
'
'Public Class frm_old_code_enregistrement
'
'    Private Sub BP_Imprime_Click(sender As Object, e As EventArgs) Handles BP_Imprime.Click
'        Dim i As Integer
'        Dim Fiche As Integer
'        Dim ligne As String
'
'        Fiche = FreeFile()
'        FileOpen(Fiche, path_Rep_EnregTrav + TB_Fichier.Text, OpenMode.Input)
'        Do While Not EOF(Fiche)
'            ligne = LineInput(Fiche)
'            i = i + 1
'        Loop
'        FileClose(Fiche)
'
'        PrintDocument1.Print()
'    End Sub
'
'End Class
