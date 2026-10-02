<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_mail_adresses
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
        Me.CLB_Adresses = New System.Windows.Forms.CheckedListBox()
        Me.TB_Nouvelle_Adresse = New System.Windows.Forms.TextBox()
        Me.BP_Ajouter = New System.Windows.Forms.Button()
        Me.BP_Supprimer = New System.Windows.Forms.Button()
        Me.BP_A = New System.Windows.Forms.Button()
        Me.BP_Cc = New System.Windows.Forms.Button()
        Me.BP_Fermer = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'CLB_Adresses
        '
        Me.CLB_Adresses.CheckOnClick = True
        Me.CLB_Adresses.FormattingEnabled = True
        Me.CLB_Adresses.Location = New System.Drawing.Point(12, 12)
        Me.CLB_Adresses.Name = "CLB_Adresses"
        Me.CLB_Adresses.Size = New System.Drawing.Size(360, 244)
        Me.CLB_Adresses.TabIndex = 0
        '
        'TB_Nouvelle_Adresse
        '
        Me.TB_Nouvelle_Adresse.Location = New System.Drawing.Point(12, 268)
        Me.TB_Nouvelle_Adresse.Name = "TB_Nouvelle_Adresse"
        Me.TB_Nouvelle_Adresse.Size = New System.Drawing.Size(360, 20)
        Me.TB_Nouvelle_Adresse.TabIndex = 1
        '
        'BP_Ajouter
        '
        Me.BP_Ajouter.Location = New System.Drawing.Point(385, 264)
        Me.BP_Ajouter.Name = "BP_Ajouter"
        Me.BP_Ajouter.Size = New System.Drawing.Size(110, 27)
        Me.BP_Ajouter.TabIndex = 2
        Me.BP_Ajouter.Text = "Ajouter"
        Me.BP_Ajouter.UseVisualStyleBackColor = True
        '
        'BP_Supprimer
        '
        Me.BP_Supprimer.Location = New System.Drawing.Point(385, 12)
        Me.BP_Supprimer.Name = "BP_Supprimer"
        Me.BP_Supprimer.Size = New System.Drawing.Size(110, 40)
        Me.BP_Supprimer.TabIndex = 3
        Me.BP_Supprimer.Text = "Supprimer"
        Me.BP_Supprimer.UseVisualStyleBackColor = True
        '
        'BP_A
        '
        Me.BP_A.Location = New System.Drawing.Point(385, 70)
        Me.BP_A.Name = "BP_A"
        Me.BP_A.Size = New System.Drawing.Size(110, 40)
        Me.BP_A.TabIndex = 4
        Me.BP_A.Text = "A ->"
        Me.BP_A.UseVisualStyleBackColor = True
        '
        'BP_Cc
        '
        Me.BP_Cc.Location = New System.Drawing.Point(385, 118)
        Me.BP_Cc.Name = "BP_Cc"
        Me.BP_Cc.Size = New System.Drawing.Size(110, 40)
        Me.BP_Cc.TabIndex = 5
        Me.BP_Cc.Text = "Cc ->"
        Me.BP_Cc.UseVisualStyleBackColor = True
        '
        'BP_Fermer
        '
        Me.BP_Fermer.Location = New System.Drawing.Point(385, 216)
        Me.BP_Fermer.Name = "BP_Fermer"
        Me.BP_Fermer.Size = New System.Drawing.Size(110, 40)
        Me.BP_Fermer.TabIndex = 6
        Me.BP_Fermer.Text = "Fermer"
        Me.BP_Fermer.UseVisualStyleBackColor = True
        '
        'Frm_mail_adresses
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(507, 302)
        Me.Controls.Add(Me.BP_Fermer)
        Me.Controls.Add(Me.BP_Cc)
        Me.Controls.Add(Me.BP_A)
        Me.Controls.Add(Me.BP_Supprimer)
        Me.Controls.Add(Me.BP_Ajouter)
        Me.Controls.Add(Me.TB_Nouvelle_Adresse)
        Me.Controls.Add(Me.CLB_Adresses)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "Frm_mail_adresses"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Carnet d'adresses"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CLB_Adresses As System.Windows.Forms.CheckedListBox
    Friend WithEvents TB_Nouvelle_Adresse As System.Windows.Forms.TextBox
    Friend WithEvents BP_Ajouter As System.Windows.Forms.Button
    Friend WithEvents BP_Supprimer As System.Windows.Forms.Button
    Friend WithEvents BP_A As System.Windows.Forms.Button
    Friend WithEvents BP_Cc As System.Windows.Forms.Button
    Friend WithEvents BP_Fermer As System.Windows.Forms.Button
End Class
