Public Class Menu_principal

    Dim frm_reseau As Frm_ethernet
    Dim err_automate As Integer

    Private Sub Menu_principal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ExceptionHandler.Activer()

        Init_appli()

        '-- connexion automate
        err_automate = Connect_PLC()
        If err_automate = 0 Then
            Lecture_Version_Automate()
            Timer1.Enabled = True
        End If

        '-- liaison PC enregistrement
        If Option_WVOIE.Liaison_PC_Enreg = 1 Then
            frm_reseau = New Frm_ethernet
            frm_reseau.Show()
            frm_reseau.Hide()

            Liaison_PC_Enreg = New LiaisonTcpPcEnreg
            Try
                Liaison_PC_Enreg.Demarrer(Port_Serveur_Commandes)
            Catch ex As Exception
                EcrireLog("Menu_principal", "TCP", "Demarrage serveur impossible : " + ex.Message)
            End Try
        End If

        Lab_Version.Text = "Version " + Version_Logiciel_PC
        EcrireLog("Menu_principal", "DEMARRAGE", Version_Logiciel_PC + " sur " + Nom_OS_Poste)

    End Sub

    '-- Lecture de la version du programme automate
    Private Sub Lecture_Version_Automate()
        Try
            Dim nb As Integer = tcClient.Read(hdl_Version_Automate, flux_Version)
            flux_Version.Position = 0
            Version_Automate = System.Text.Encoding.ASCII.GetString(lecteur_Version.ReadBytes(nb)).TrimEnd(Chr(0))
        Catch
            Version_Automate = "Non lue"
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Lecture_entrees_PLC()

        If EtatDeLautomate Then
            Lab_Etat_Automate.Text = "Automate : DEFAUT"
            Lab_Etat_Automate.ForeColor = Color.Red
        Else
            Lab_Etat_Automate.Text = "Automate : OK  (" + CStr(Distance_Parcourue) + " mm)"
            Lab_Etat_Automate.ForeColor = Color.Green
        End If
    End Sub

    Private Sub BP_Travail_Click(sender As Object, e As EventArgs) Handles BP_Travail.Click
        If Changement_Mode_Automate("MODE_TRAVAIL_WVOIE") = 0 Then
            travail_WVOIE_actif = True
            If frm_reseau IsNot Nothing Then
                frm_reseau.Envoi_Contexte_PC_Enreg(2)
            End If
        End If
    End Sub

    Private Sub BP_Impression_Click(sender As Object, e As EventArgs) Handles BP_Impression.Click
        Dim frm As New Frm_imprime_enreg_trav
        frm.ShowDialog()
    End Sub

    Private Sub BP_Utilitaires_Click(sender As Object, e As EventArgs) Handles BP_Utilitaires.Click
        Dim frm As New Frm_util_Menu
        frm.ShowDialog()
    End Sub

    Private Sub BP_Quitter_Click(sender As Object, e As EventArgs) Handles BP_Quitter.Click
        Me.Close()
    End Sub

    Private Sub Menu_principal_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Timer1.Enabled = False
        Deconnexion_PLC()
        If Liaison_PC_Enreg IsNot Nothing Then
            Liaison_PC_Enreg.Arreter()
        End If
        EcrireLog("Menu_principal", "ARRET", "")
    End Sub

End Class
