Public Class Frm_Reglage_Zero_Statique

    Dim zero_calcule As Boolean = False
    Dim nb_echantillons As Integer
    Dim somme_NivG As Double
    Dim somme_NivD As Double
    Dim somme_Devers As Double
    Dim somme_Fleche As Double

    Private Sub Frm_Reglage_Zero_Statique_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        TB_Zero_NivG.Text = Save_WVOIE.zero_statique_nivel_gauche
        TB_Zero_NivD.Text = Save_WVOIE.zero_statique_nivel_droit
        TB_Zero_Devers.Text = Save_WVOIE.zero_statique_devers
        TB_Zero_Fleche.Text = Save_WVOIE.zero_statique_fleche

        Changement_Mode_Automate("MODE_REGLAGE")
        Timer1.Enabled = True

    End Sub

    '-- Rafraichissement des mesures capteurs
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        Lecture_entrees_PLC()

        TB_Mesure_NivG.Text = eana(1)
        TB_Mesure_NivD.Text = eana(2)
        TB_Mesure_Devers.Text = eana(3)
        TB_Mesure_Fleche.Text = eana(4)

        '-- accumulation pour moyenne
        If zero_calcule = False And nb_echantillons > 0 Then
            somme_NivG = somme_NivG + eana(1)
            somme_NivD = somme_NivD + eana(2)
            somme_Devers = somme_Devers + eana(3)
            somme_Fleche = somme_Fleche + eana(4)
            nb_echantillons = nb_echantillons + 1

            If nb_echantillons > 50 Then
                TB_Zero_NivG.Text = Math.Round(somme_NivG / 50, 1)
                TB_Zero_NivD.Text = Math.Round(somme_NivD / 50, 1)
                TB_Zero_Devers.Text = Math.Round(somme_Devers / 50, 1)
                TB_Zero_Fleche.Text = Math.Round(somme_Fleche / 50, 1)
                zero_calcule = True
                BP_Calcul_Zero.Enabled = True
            End If
        End If

    End Sub

    Private Sub BP_Calcul_Zero_Click(sender As Object, e As EventArgs) Handles BP_Calcul_Zero.Click
        somme_NivG = 0
        somme_NivD = 0
        somme_Devers = 0
        somme_Fleche = 0
        nb_echantillons = 1
        zero_calcule = False
        BP_Calcul_Zero.Enabled = False
    End Sub

    '-- Validation des zéros : mot de passe obligatoire
    Private Sub BP_Valider_Click(sender As Object, e As EventArgs) Handles BP_Valider.Click
        Dim reponse As MsgBoxResult

        Dim frm_psw As New Frm_MotDePasse
        If frm_psw.ShowDialog() = Windows.Forms.DialogResult.OK Then '1
            If Mot_De_Passe_Valide(PSW_saisie, {PROFIL_SUPERVISEUR}) Then '2

                reponse = MsgBox("Enregistrer les nouveaux zéros ?", MsgBoxStyle.YesNo)
                If reponse = MsgBoxResult.Yes Then '3

                    Save_WVOIE.zero_statique_nivel_gauche = TB_Zero_NivG.Text
                    Save_WVOIE.zero_statique_nivel_droit = TB_Zero_NivD.Text
                    Save_WVOIE.zero_statique_devers = TB_Zero_Devers.Text
                    Save_WVOIE.zero_statique_fleche = TB_Zero_Fleche.Text

                    Save_Reglages()
                    Changement_Mode_Automate("MODE_REGLAGE")

                    EcrireLog("Frm_Reglage_Zero_Statique", Libelle_Sauvegarde("ZS"), "NivG=" + TB_Zero_NivG.Text + " NivD=" + TB_Zero_NivD.Text)

                End If '3
            Else
                MsgBox("Mot de passe incorrect", )
            End If '2
        End If '1

    End Sub

    Private Sub BP_Retour_Click(sender As Object, e As EventArgs) Handles BP_Retour.Click
        Timer1.Enabled = False
        Me.Close()
    End Sub

End Class
