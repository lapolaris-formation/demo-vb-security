Imports System.Net.Mail

Public Class Frm_mail_enregistrement
    Dim liste_pieces_jointes As String = ""
    Dim nb_pieces_jointes As Integer = 0
    Dim taille_totale As Long
    Dim envoi_ok As Boolean

    ' Ouverture fenêtre
    Private Sub Frm_mail_enregistrement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Destinataires_Mail = ""
        Destinataires_Copie_Mail = ""
        LB_Pieces_Jointes.Items.Clear()
        TB_Objet.Text = "Enregistrement travail " + Format(Now, "dd/MM/yyyy")
    End Sub

    ' Envoi du message
    Private Sub BP_Envoyer_Click(sender As Object, e As EventArgs) Handles BP_Envoyer.Click
        Dim smtp As New SmtpClient
        Dim message As New MailMessage
        Dim adresses() As String
        Dim k As Integer

        If TB_Destinataires.Text = "" Then
            MsgBox("Aucun destinataire", )
            Exit Sub
        End If

        message.From = New MailAddress(mail_expediteur)

        '-- destinataires (séparateur ; ou ,)
        adresses = TB_Destinataires.Text.Split(New Char() {";"c, ","c})
        For k = 0 To adresses.Length - 1
            If adresses(k) <> "" Then
                Try
                    message.To.Add(adresses(k))
                Catch ex As Exception
                    MsgBox("Adresse incorrecte : " + adresses(k), )
                End Try
            End If
        Next

        '-- copies
        adresses = Split(TB_Copie.Text, ";")
        For k = 0 To adresses.Length - 1
            If adresses(k) <> "" Then
                Try
                    message.CC.Add(adresses(k))
                Catch ex As Exception
                    MsgBox("Adresse incorrecte : " + adresses(k), )
                End Try
            End If
        Next

        message.Subject = TB_Objet.Text
        message.Body = TB_Message.Text

        '-- pièces jointes
        adresses = Split(liste_pieces_jointes, ";")
        For k = 0 To adresses.Length - 1
            If adresses(k) <> "" Then
                message.Attachments.Add(New Attachment(adresses(k)))
            End If
        Next

        '-- paramètres serveur (fichier C:\WVOIE\MAIL\mail_parametres.con)
        smtp.Host = mail_serveur
        smtp.Port = mail_port
        smtp.EnableSsl = True
        smtp.UseDefaultCredentials = False
        smtp.Credentials = New System.Net.NetworkCredential(mail_expediteur, mail_mdp)

        Try
            smtp.Send(message)
            envoi_ok = True
        Catch ex As Exception
            envoi_ok = False
            MsgBox("Le mail n'a pas pu être envoyé" + vbCrLf + ex.Message, )
        End Try

        EcrireLog("Frm_mail_enregistrement", "MAIL", "Envoi a " + TB_Destinataires.Text + " ok=" + CStr(envoi_ok))

        Me.Close()

    End Sub

    ' Ajout d'une pièce jointe
    Private Sub BP_Joindre_Click(sender As Object, e As EventArgs) Handles BP_Joindre.Click
        Dim info As System.IO.FileInfo

        OpenFileDialog1.Filter = "Enregistrement PDF (*.pdf)|*.pdf|Tous les fichiers (*.*)|*.*"
        OpenFileDialog1.InitialDirectory = path_Rep_EnregTrav
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Title = "Choix du fichier à envoyer"

        If OpenFileDialog1.ShowDialog() <> Windows.Forms.DialogResult.OK Then
            Return
        End If

        info = New System.IO.FileInfo(OpenFileDialog1.FileName)
        taille_totale = taille_totale + info.Length

        '-- limite boite mail 20 Mo
        If taille_totale > 20000000 Then
            MsgBox("Taille maximum des pièces jointes atteinte", )
            taille_totale = taille_totale - info.Length
            Return
        End If

        liste_pieces_jointes = liste_pieces_jointes + OpenFileDialog1.FileName + ";"
        nb_pieces_jointes = nb_pieces_jointes + 1

        If info.Length > 1000000 Then
            LB_Pieces_Jointes.Items.Add(info.Name + "  (" + CStr(info.Length \ 1000000) + " Mo)")
        ElseIf info.Length > 1000 Then
            LB_Pieces_Jointes.Items.Add(info.Name + "  (" + CStr(info.Length \ 1000) + " Ko)")
        Else
            LB_Pieces_Jointes.Items.Add(info.Name + "  (" + CStr(info.Length) + " o)")
        End If

    End Sub

    ' Ouverture du carnet d'adresses
    Private Sub BP_Carnet_Click(sender As Object, e As EventArgs) Handles BP_Carnet.Click

        Destinataires_Mail = TB_Destinataires.Text
        Destinataires_Copie_Mail = TB_Copie.Text

        Dim frm As New Frm_mail_adresses
        frm.ShowDialog()

        If Destinataires_Mail <> "" Then TB_Destinataires.Text = Destinataires_Mail
        If Destinataires_Copie_Mail <> "" Then TB_Copie.Text = Destinataires_Copie_Mail

    End Sub

End Class
