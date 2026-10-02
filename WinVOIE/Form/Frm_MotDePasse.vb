Public Class Frm_MotDePasse

    Private Sub Frm_MotDePasse_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        TB_psw.Text = ""
        TB_psw.Focus()
    End Sub

    Private Sub OK_Button_Click(sender As Object, e As EventArgs) Handles OK_Button.Click
        PSW_saisie = TB_psw.Text
        flg_Passe_Word_Input = True
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(sender As Object, e As EventArgs) Handles Cancel_Button.Click
        PSW_saisie = ""
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

End Class
