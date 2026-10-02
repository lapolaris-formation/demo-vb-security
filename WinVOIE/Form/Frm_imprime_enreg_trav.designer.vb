<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_imprime_enreg_trav
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
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
        Me.TB_Fichier = New System.Windows.Forms.TextBox()
        Me.BP_Parcourir = New System.Windows.Forms.Button()
        Me.BP_Export_PDF = New System.Windows.Forms.Button()
        Me.BP_Envoi_Mail = New System.Windows.Forms.Button()
        Me.BP_Retour = New System.Windows.Forms.Button()
        Me.CB_Ouvrir_Apres = New System.Windows.Forms.CheckBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TB_Fichier)
        Me.GroupBox1.Controls.Add(Me.BP_Parcourir)
        Me.GroupBox1.Controls.Add(Me.CB_Ouvrir_Apres)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(560, 90)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Fichier enregistrement travail"
        '
        'TB_Fichier
        '
        Me.TB_Fichier.Location = New System.Drawing.Point(15, 25)
        Me.TB_Fichier.Name = "TB_Fichier"
        Me.TB_Fichier.Size = New System.Drawing.Size(420, 20)
        Me.TB_Fichier.TabIndex = 0
        '
        'BP_Parcourir
        '
        Me.BP_Parcourir.Location = New System.Drawing.Point(445, 22)
        Me.BP_Parcourir.Name = "BP_Parcourir"
        Me.BP_Parcourir.Size = New System.Drawing.Size(100, 25)
        Me.BP_Parcourir.TabIndex = 1
        Me.BP_Parcourir.Text = "Parcourir..."
        Me.BP_Parcourir.UseVisualStyleBackColor = True
        '
        'CB_Ouvrir_Apres
        '
        Me.CB_Ouvrir_Apres.AutoSize = True
        Me.CB_Ouvrir_Apres.Checked = True
        Me.CB_Ouvrir_Apres.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CB_Ouvrir_Apres.Location = New System.Drawing.Point(15, 58)
        Me.CB_Ouvrir_Apres.Name = "CB_Ouvrir_Apres"
        Me.CB_Ouvrir_Apres.Size = New System.Drawing.Size(180, 17)
        Me.CB_Ouvrir_Apres.TabIndex = 2
        Me.CB_Ouvrir_Apres.Text = "Ouvrir le PDF après génération"
        Me.CB_Ouvrir_Apres.UseVisualStyleBackColor = True
        '
        'BP_Export_PDF
        '
        Me.BP_Export_PDF.Location = New System.Drawing.Point(12, 115)
        Me.BP_Export_PDF.Name = "BP_Export_PDF"
        Me.BP_Export_PDF.Size = New System.Drawing.Size(140, 50)
        Me.BP_Export_PDF.TabIndex = 1
        Me.BP_Export_PDF.Text = "Export PDF"
        Me.BP_Export_PDF.UseVisualStyleBackColor = True
        '
        'BP_Envoi_Mail
        '
        Me.BP_Envoi_Mail.Location = New System.Drawing.Point(162, 115)
        Me.BP_Envoi_Mail.Name = "BP_Envoi_Mail"
        Me.BP_Envoi_Mail.Size = New System.Drawing.Size(140, 50)
        Me.BP_Envoi_Mail.TabIndex = 2
        Me.BP_Envoi_Mail.Text = "Envoi par mail"
        Me.BP_Envoi_Mail.UseVisualStyleBackColor = True
        '
        'BP_Retour
        '
        Me.BP_Retour.Location = New System.Drawing.Point(432, 115)
        Me.BP_Retour.Name = "BP_Retour"
        Me.BP_Retour.Size = New System.Drawing.Size(140, 50)
        Me.BP_Retour.TabIndex = 3
        Me.BP_Retour.Text = "Retour"
        Me.BP_Retour.UseVisualStyleBackColor = True
        '
        'Frm_imprime_enreg_trav
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(584, 177)
        Me.ControlBox = False
        Me.Controls.Add(Me.BP_Retour)
        Me.Controls.Add(Me.BP_Envoi_Mail)
        Me.Controls.Add(Me.BP_Export_PDF)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "Frm_imprime_enreg_trav"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Impression enregistrement travail"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TB_Fichier As System.Windows.Forms.TextBox
    Friend WithEvents BP_Parcourir As System.Windows.Forms.Button
    Friend WithEvents CB_Ouvrir_Apres As System.Windows.Forms.CheckBox
    Friend WithEvents BP_Export_PDF As System.Windows.Forms.Button
    Friend WithEvents BP_Envoi_Mail As System.Windows.Forms.Button
    Friend WithEvents BP_Retour As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
End Class
