<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_util_Menu
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
        Me.BP_Parametres = New System.Windows.Forms.Button()
        Me.BP_Reglages = New System.Windows.Forms.Button()
        Me.BP_Fichier_Ref = New System.Windows.Forms.Button()
        Me.BP_Export_Contexte = New System.Windows.Forms.Button()
        Me.BP_Config_Mail = New System.Windows.Forms.Button()
        Me.BP_Retour = New System.Windows.Forms.Button()
        Me.Lab_Version = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.BP_Parametres)
        Me.GroupBox1.Controls.Add(Me.BP_Reglages)
        Me.GroupBox1.Controls.Add(Me.BP_Fichier_Ref)
        Me.GroupBox1.Controls.Add(Me.BP_Export_Contexte)
        Me.GroupBox1.Controls.Add(Me.BP_Config_Mail)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(560, 220)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Utilitaires"
        '
        'BP_Parametres
        '
        Me.BP_Parametres.Location = New System.Drawing.Point(20, 30)
        Me.BP_Parametres.Name = "BP_Parametres"
        Me.BP_Parametres.Size = New System.Drawing.Size(160, 70)
        Me.BP_Parametres.TabIndex = 0
        Me.BP_Parametres.Text = "Paramètres machine"
        Me.BP_Parametres.UseVisualStyleBackColor = True
        '
        'BP_Reglages
        '
        Me.BP_Reglages.Location = New System.Drawing.Point(200, 30)
        Me.BP_Reglages.Name = "BP_Reglages"
        Me.BP_Reglages.Size = New System.Drawing.Size(160, 70)
        Me.BP_Reglages.TabIndex = 1
        Me.BP_Reglages.Text = "Réglage zéro statique"
        Me.BP_Reglages.UseVisualStyleBackColor = True
        '
        'BP_Fichier_Ref
        '
        Me.BP_Fichier_Ref.Location = New System.Drawing.Point(380, 30)
        Me.BP_Fichier_Ref.Name = "BP_Fichier_Ref"
        Me.BP_Fichier_Ref.Size = New System.Drawing.Size(160, 70)
        Me.BP_Fichier_Ref.TabIndex = 2
        Me.BP_Fichier_Ref.Text = "Fichiers de référence"
        Me.BP_Fichier_Ref.UseVisualStyleBackColor = True
        '
        'BP_Export_Contexte
        '
        Me.BP_Export_Contexte.Location = New System.Drawing.Point(20, 125)
        Me.BP_Export_Contexte.Name = "BP_Export_Contexte"
        Me.BP_Export_Contexte.Size = New System.Drawing.Size(160, 70)
        Me.BP_Export_Contexte.TabIndex = 3
        Me.BP_Export_Contexte.Text = "Export contexte SAV"
        Me.BP_Export_Contexte.UseVisualStyleBackColor = True
        '
        'BP_Config_Mail
        '
        Me.BP_Config_Mail.Location = New System.Drawing.Point(200, 125)
        Me.BP_Config_Mail.Name = "BP_Config_Mail"
        Me.BP_Config_Mail.Size = New System.Drawing.Size(160, 70)
        Me.BP_Config_Mail.TabIndex = 4
        Me.BP_Config_Mail.Text = "Configuration mail"
        Me.BP_Config_Mail.UseVisualStyleBackColor = True
        '
        'BP_Retour
        '
        Me.BP_Retour.Location = New System.Drawing.Point(452, 245)
        Me.BP_Retour.Name = "BP_Retour"
        Me.BP_Retour.Size = New System.Drawing.Size(120, 45)
        Me.BP_Retour.TabIndex = 5
        Me.BP_Retour.Text = "Retour"
        Me.BP_Retour.UseVisualStyleBackColor = True
        '
        'Lab_Version
        '
        Me.Lab_Version.AutoSize = True
        Me.Lab_Version.Location = New System.Drawing.Point(12, 262)
        Me.Lab_Version.Name = "Lab_Version"
        Me.Lab_Version.Size = New System.Drawing.Size(45, 13)
        Me.Lab_Version.TabIndex = 6
        Me.Lab_Version.Text = "Version"
        '
        'Frm_util_Menu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(584, 302)
        Me.ControlBox = False
        Me.Controls.Add(Me.Lab_Version)
        Me.Controls.Add(Me.BP_Retour)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "Frm_util_Menu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Utilitaires"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents BP_Parametres As System.Windows.Forms.Button
    Friend WithEvents BP_Reglages As System.Windows.Forms.Button
    Friend WithEvents BP_Fichier_Ref As System.Windows.Forms.Button
    Friend WithEvents BP_Export_Contexte As System.Windows.Forms.Button
    Friend WithEvents BP_Config_Mail As System.Windows.Forms.Button
    Friend WithEvents BP_Retour As System.Windows.Forms.Button
    Friend WithEvents Lab_Version As System.Windows.Forms.Label
End Class
