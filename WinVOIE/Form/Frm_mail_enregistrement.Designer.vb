<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_mail_enregistrement
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(  disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Lab_A = New System.Windows.Forms.Label()
        Me.Lab_Cc = New System.Windows.Forms.Label()
        Me.Lab_Objet = New System.Windows.Forms.Label()
        Me.TB_Destinataires = New System.Windows.Forms.TextBox()
        Me.TB_Copie = New System.Windows.Forms.TextBox()
        Me.TB_Objet = New System.Windows.Forms.TextBox()
        Me.BP_Carnet = New System.Windows.Forms.Button()
        Me.BP_Joindre = New System.Windows.Forms.Button()
        Me.BP_Envoyer = New System.Windows.Forms.Button()
        Me.LB_Pieces_Jointes = New System.Windows.Forms.ListBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TB_Message = New System.Windows.Forms.TextBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Lab_A)
        Me.GroupBox1.Controls.Add(Me.Lab_Cc)
        Me.GroupBox1.Controls.Add(Me.Lab_Objet)
        Me.GroupBox1.Controls.Add(Me.TB_Destinataires)
        Me.GroupBox1.Controls.Add(Me.TB_Copie)
        Me.GroupBox1.Controls.Add(Me.TB_Objet)
        Me.GroupBox1.Controls.Add(Me.BP_Carnet)
        Me.GroupBox1.Controls.Add(Me.BP_Joindre)
        Me.GroupBox1.Controls.Add(Me.BP_Envoyer)
        Me.GroupBox1.Controls.Add(Me.LB_Pieces_Jointes)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(700, 200)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'Lab_A
        '
        Me.Lab_A.AutoSize = True
        Me.Lab_A.Location = New System.Drawing.Point(15, 25)
        Me.Lab_A.Name = "Lab_A"
        Me.Lab_A.Size = New System.Drawing.Size(20, 13)
        Me.Lab_A.TabIndex = 0
        Me.Lab_A.Text = "A :"
        '
        'Lab_Cc
        '
        Me.Lab_Cc.AutoSize = True
        Me.Lab_Cc.Location = New System.Drawing.Point(15, 55)
        Me.Lab_Cc.Name = "Lab_Cc"
        Me.Lab_Cc.Size = New System.Drawing.Size(26, 13)
        Me.Lab_Cc.TabIndex = 1
        Me.Lab_Cc.Text = "Cc :"
        '
        'Lab_Objet
        '
        Me.Lab_Objet.AutoSize = True
        Me.Lab_Objet.Location = New System.Drawing.Point(15, 85)
        Me.Lab_Objet.Name = "Lab_Objet"
        Me.Lab_Objet.Size = New System.Drawing.Size(40, 13)
        Me.Lab_Objet.TabIndex = 2
        Me.Lab_Objet.Text = "Objet :"
        '
        'TB_Destinataires
        '
        Me.TB_Destinataires.Location = New System.Drawing.Point(70, 22)
        Me.TB_Destinataires.Name = "TB_Destinataires"
        Me.TB_Destinataires.Size = New System.Drawing.Size(470, 20)
        Me.TB_Destinataires.TabIndex = 3
        '
        'TB_Copie
        '
        Me.TB_Copie.Location = New System.Drawing.Point(70, 52)
        Me.TB_Copie.Name = "TB_Copie"
        Me.TB_Copie.Size = New System.Drawing.Size(470, 20)
        Me.TB_Copie.TabIndex = 4
        '
        'TB_Objet
        '
        Me.TB_Objet.Location = New System.Drawing.Point(70, 82)
        Me.TB_Objet.Name = "TB_Objet"
        Me.TB_Objet.Size = New System.Drawing.Size(470, 20)
        Me.TB_Objet.TabIndex = 5
        '
        'BP_Carnet
        '
        Me.BP_Carnet.Location = New System.Drawing.Point(555, 20)
        Me.BP_Carnet.Name = "BP_Carnet"
        Me.BP_Carnet.Size = New System.Drawing.Size(130, 52)
        Me.BP_Carnet.TabIndex = 6
        Me.BP_Carnet.Text = "Carnet d'adresses"
        Me.BP_Carnet.UseVisualStyleBackColor = True
        '
        'BP_Joindre
        '
        Me.BP_Joindre.Location = New System.Drawing.Point(555, 80)
        Me.BP_Joindre.Name = "BP_Joindre"
        Me.BP_Joindre.Size = New System.Drawing.Size(130, 52)
        Me.BP_Joindre.TabIndex = 7
        Me.BP_Joindre.Text = "Joindre un fichier"
        Me.BP_Joindre.UseVisualStyleBackColor = True
        '
        'BP_Envoyer
        '
        Me.BP_Envoyer.Location = New System.Drawing.Point(555, 140)
        Me.BP_Envoyer.Name = "BP_Envoyer"
        Me.BP_Envoyer.Size = New System.Drawing.Size(130, 52)
        Me.BP_Envoyer.TabIndex = 8
        Me.BP_Envoyer.Text = "Envoyer"
        Me.BP_Envoyer.UseVisualStyleBackColor = True
        '
        'LB_Pieces_Jointes
        '
        Me.LB_Pieces_Jointes.FormattingEnabled = True
        Me.LB_Pieces_Jointes.Location = New System.Drawing.Point(70, 112)
        Me.LB_Pieces_Jointes.Name = "LB_Pieces_Jointes"
        Me.LB_Pieces_Jointes.Size = New System.Drawing.Size(470, 69)
        Me.LB_Pieces_Jointes.TabIndex = 9
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TB_Message)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 211)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(700, 230)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Message"
        '
        'TB_Message
        '
        Me.TB_Message.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TB_Message.Multiline = True
        Me.TB_Message.Name = "TB_Message"
        Me.TB_Message.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TB_Message.TabIndex = 0
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Frm_mail_enregistrement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(724, 453)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Frm_mail_enregistrement"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Envoi enregistrement par mail"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Lab_A As System.Windows.Forms.Label
    Friend WithEvents Lab_Cc As System.Windows.Forms.Label
    Friend WithEvents Lab_Objet As System.Windows.Forms.Label
    Friend WithEvents TB_Destinataires As System.Windows.Forms.TextBox
    Friend WithEvents TB_Copie As System.Windows.Forms.TextBox
    Friend WithEvents TB_Objet As System.Windows.Forms.TextBox
    Friend WithEvents BP_Carnet As System.Windows.Forms.Button
    Friend WithEvents BP_Joindre As System.Windows.Forms.Button
    Friend WithEvents BP_Envoyer As System.Windows.Forms.Button
    Friend WithEvents LB_Pieces_Jointes As System.Windows.Forms.ListBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TB_Message As System.Windows.Forms.TextBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
End Class
