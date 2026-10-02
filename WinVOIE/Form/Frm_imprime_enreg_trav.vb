Imports System.IO

Public Class Frm_imprime_enreg_trav

    Dim chemin_pdf As String = ""

    Private Sub Frm_imprime_enreg_trav_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "IMPRESSION DES ENREGISTREMENTS TRAVAIL"
        If Fichier_Reference_Selectionne <> "" Then
            TB_Fichier.Text = Fichier_Reference_Selectionne
        End If
    End Sub

    Private Sub BP_Parcourir_Click(sender As Object, e As EventArgs) Handles BP_Parcourir.Click

        OpenFileDialog1.Filter = "Enregistrement travail (*.ent)|*.ent|Tous les fichiers (*.*)|*.*"
        OpenFileDialog1.InitialDirectory = path_Rep_EnregTrav
        OpenFileDialog1.FileName = ""

        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            TB_Fichier.Text = OpenFileDialog1.FileName
        End If

    End Sub

    '-- Génération du PDF dans le dossier temporaire puis ouverture
    Private Sub BP_Export_PDF_Click(sender As Object, e As EventArgs) Handles BP_Export_PDF.Click
        Dim export As New ExportEnregistrementPDF
        Dim modifie As Boolean

        If TB_Fichier.Text = "" Then
            MsgBox("Choisir un fichier", )
            Exit Sub
        End If

        '-- contrôle signature du fichier
        modifie = Fichier_Enreg_Modifie(TB_Fichier.Text)
        If modifie Then
            MsgBox("ATTENTION : le fichier a été modifié en dehors de WinVOIE", MsgBoxStyle.Exclamation)
        End If

        Try
            Me.Cursor = Cursors.WaitCursor

            export.ChargerFichier(TB_Fichier.Text)
            chemin_pdf = Path.GetTempPath() + Path.GetFileNameWithoutExtension(TB_Fichier.Text) + ".pdf"
            export.ExporterPDF(chemin_pdf)

            Me.Cursor = Cursors.Default

            ' Ouvrir le PDF avec l'application par défaut
            If CB_Ouvrir_Apres.Checked Then
                Process.Start(chemin_pdf)
            End If

        Catch ex As Exception
            Me.Cursor = Cursors.Default
            ExceptionHandler.Signaler(ex, "Export PDF enregistrement")
        End Try

    End Sub

    Private Sub BP_Envoi_Mail_Click(sender As Object, e As EventArgs) Handles BP_Envoi_Mail.Click
        If Option_WVOIE.Envoi_Mail = 1 Then
            Dim frm As New Frm_mail_enregistrement
            frm.ShowDialog()
        End If
    End Sub

    Private Sub BP_Retour_Click(sender As Object, e As EventArgs) Handles BP_Retour.Click
        Me.Close()
    End Sub

End Class
