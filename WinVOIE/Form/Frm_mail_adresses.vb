Public Class Frm_mail_adresses

    ' Chargement du carnet (une adresse par ligne)
    Private Sub Frm_mail_adresses_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Fiche As Integer
        Dim ligne As String

        CLB_Adresses.Items.Clear()

        If My.Computer.FileSystem.FileExists(path_fichier_mail_adresses) Then
            Fiche = FreeFile()
            FileOpen(Fiche, path_fichier_mail_adresses, OpenMode.Input)
            Do While Not EOF(Fiche)
                ligne = LineInput(Fiche)
                If ligne <> "" Then
                    CLB_Adresses.Items.Add(ligne)
                End If
            Loop
            FileClose(Fiche)
        End If

    End Sub

    ' Sauvegarde du carnet
    Private Sub Sauve_Carnet()
        Dim Fiche As Integer
        Dim i As Integer

        Fiche = FreeFile()
        FileOpen(Fiche, path_fichier_mail_adresses, OpenMode.Output)
        For i = 0 To CLB_Adresses.Items.Count - 1
            PrintLine(Fiche, CLB_Adresses.Items(i))
        Next
        FileClose(Fiche)
    End Sub

    Private Sub BP_Ajouter_Click(sender As Object, e As EventArgs) Handles BP_Ajouter.Click
        If TB_Nouvelle_Adresse.Text <> "" Then
            CLB_Adresses.Items.Add(TB_Nouvelle_Adresse.Text)
            TB_Nouvelle_Adresse.Text = ""
            Sauve_Carnet()
        End If
    End Sub

    Private Sub BP_Supprimer_Click(sender As Object, e As EventArgs) Handles BP_Supprimer.Click
        Dim i As Integer
        For i = CLB_Adresses.Items.Count - 1 To 0 Step -1
            If CLB_Adresses.GetItemChecked(i) Then
                CLB_Adresses.Items.RemoveAt(i)
            End If
        Next
        Sauve_Carnet()
    End Sub

    ' Adresses cochées -> destinataires
    Private Sub BP_A_Click(sender As Object, e As EventArgs) Handles BP_A.Click
        Dim i As Integer
        For i = 0 To CLB_Adresses.CheckedItems.Count - 1
            Destinataires_Mail = Destinataires_Mail + CLB_Adresses.CheckedItems(i) + ";"
        Next
        Me.Close()
    End Sub

    ' Adresses cochées -> copie
    Private Sub BP_Cc_Click(sender As Object, e As EventArgs) Handles BP_Cc.Click
        Dim i As Integer
        For i = 0 To CLB_Adresses.CheckedItems.Count - 1
            Destinataires_Copie_Mail = Destinataires_Copie_Mail + CLB_Adresses.CheckedItems(i) + ";"
        Next
        Me.Close()
    End Sub

    Private Sub BP_Fermer_Click(sender As Object, e As EventArgs) Handles BP_Fermer.Click
        Me.Close()
    End Sub

End Class
