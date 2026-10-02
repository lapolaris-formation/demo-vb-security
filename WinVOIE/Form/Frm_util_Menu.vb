Public Class Frm_util_Menu

    Private Sub Frm_util_Menu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Lab_Version.Text = Version_Logiciel_PC + "   -   " + Nom_OS_Poste + "   -   automate " + Version_Automate
    End Sub

    '-- Contrôle du mot de passe SAV / Superviseur
    Private Function Acces_Autorise() As Boolean

        Dim frm_psw As New Frm_MotDePasse

        If frm_psw.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If PSW_saisie = "FERROSUP" Or PSW_saisie = "ferrosup" Or PSW_saisie = "FERROSAV" Or PSW_saisie = "ferrosav" Or PSW_saisie = "FERRODEMO" Or PSW_saisie = "ferrodemo" Then

                Return True
            Else
                MsgBox("Mot de passe incorrect", )
            End If
        End If

        Return False

    End Function

    '-- Edition directe du fichier paramètres machine
    Private Sub BP_Parametres_Click(sender As Object, e As EventArgs) Handles BP_Parametres.Click

        If Acces_Autorise() = False Then
            Exit Sub
        End If

        EcrireLog("Frm_util_Menu", "ACCES", "Edition parametres machine")
        Process.Start("notepad.exe", path_fichier_parametres)

    End Sub

    Private Sub BP_Reglages_Click(sender As Object, e As EventArgs) Handles BP_Reglages.Click
        Dim frm As New Frm_Reglage_Zero_Statique
        frm.ShowDialog()
    End Sub

    Private Sub BP_Fichier_Ref_Click(sender As Object, e As EventArgs) Handles BP_Fichier_Ref.Click
        Dim frm As New Frm_Choix_File_Ref
        frm.ShowDialog()
    End Sub

    '-- Export du contexte complet pour le SAV (zip sur le bureau)
    Private Sub BP_Export_Contexte_Click(sender As Object, e As EventArgs) Handles BP_Export_Contexte.Click
        Dim chemin As String

        Me.Cursor = Cursors.WaitCursor
        chemin = ContextZip.ExporterContexteVersBureau(ContextZip.CapturerEcranPublic())
        Me.Cursor = Cursors.Default

        If chemin <> "" Then
            MsgBox("Archive créée sur le bureau :" + vbCrLf + chemin + vbCrLf + vbCrLf + "Envoyez ce fichier à hotline@ferrodemo.example", )
        End If
    End Sub

    '-- Modification du compte mail du poste
    Private Sub BP_Config_Mail_Click(sender As Object, e As EventArgs) Handles BP_Config_Mail.Click

        If Acces_Autorise() = False Then
            Exit Sub
        End If

        Process.Start("notepad.exe", path_fichier_mail_parametres)

    End Sub

    Private Sub BP_Retour_Click(sender As Object, e As EventArgs) Handles BP_Retour.Click
        Me.Close()
    End Sub

End Class
