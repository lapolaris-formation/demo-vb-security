<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Menu_principal
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Menu_principal))
        Me.BP_Travail = New System.Windows.Forms.Button()
        Me.BP_Impression = New System.Windows.Forms.Button()
        Me.BP_Utilitaires = New System.Windows.Forms.Button()
        Me.BP_Quitter = New System.Windows.Forms.Button()
        Me.Lab_Titre = New System.Windows.Forms.Label()
        Me.Lab_Version = New System.Windows.Forms.Label()
        Me.Lab_Etat_Automate = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'BP_Travail
        '
        Me.BP_Travail.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BP_Travail.Location = New System.Drawing.Point(40, 90)
        Me.BP_Travail.Name = "BP_Travail"
        Me.BP_Travail.Size = New System.Drawing.Size(200, 90)
        Me.BP_Travail.TabIndex = 0
        Me.BP_Travail.Text = "TRAVAIL"
        Me.BP_Travail.UseVisualStyleBackColor = True
        '
        'BP_Impression
        '
        Me.BP_Impression.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BP_Impression.Location = New System.Drawing.Point(260, 90)
        Me.BP_Impression.Name = "BP_Impression"
        Me.BP_Impression.Size = New System.Drawing.Size(200, 90)
        Me.BP_Impression.TabIndex = 1
        Me.BP_Impression.Text = "IMPRESSION"
        Me.BP_Impression.UseVisualStyleBackColor = True
        '
        'BP_Utilitaires
        '
        Me.BP_Utilitaires.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BP_Utilitaires.Location = New System.Drawing.Point(480, 90)
        Me.BP_Utilitaires.Name = "BP_Utilitaires"
        Me.BP_Utilitaires.Size = New System.Drawing.Size(200, 90)
        Me.BP_Utilitaires.TabIndex = 2
        Me.BP_Utilitaires.Text = "UTILITAIRES"
        Me.BP_Utilitaires.UseVisualStyleBackColor = True
        '
        'BP_Quitter
        '
        Me.BP_Quitter.Location = New System.Drawing.Point(560, 220)
        Me.BP_Quitter.Name = "BP_Quitter"
        Me.BP_Quitter.Size = New System.Drawing.Size(120, 45)
        Me.BP_Quitter.TabIndex = 3
        Me.BP_Quitter.Text = "Quitter"
        Me.BP_Quitter.UseVisualStyleBackColor = True
        '
        'Lab_Titre
        '
        Me.Lab_Titre.AutoSize = True
        Me.Lab_Titre.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lab_Titre.Location = New System.Drawing.Point(34, 25)
        Me.Lab_Titre.Name = "Lab_Titre"
        Me.Lab_Titre.Size = New System.Drawing.Size(133, 31)
        Me.Lab_Titre.TabIndex = 4
        Me.Lab_Titre.Text = "WinVOIE"
        '
        'Lab_Version
        '
        Me.Lab_Version.AutoSize = True
        Me.Lab_Version.Location = New System.Drawing.Point(37, 236)
        Me.Lab_Version.Name = "Lab_Version"
        Me.Lab_Version.Size = New System.Drawing.Size(42, 13)
        Me.Lab_Version.TabIndex = 5
        Me.Lab_Version.Text = "Version"
        '
        'Lab_Etat_Automate
        '
        Me.Lab_Etat_Automate.AutoSize = True
        Me.Lab_Etat_Automate.Location = New System.Drawing.Point(37, 252)
        Me.Lab_Etat_Automate.Name = "Lab_Etat_Automate"
        Me.Lab_Etat_Automate.Size = New System.Drawing.Size(80, 13)
        Me.Lab_Etat_Automate.TabIndex = 6
        Me.Lab_Etat_Automate.Text = "Automate : ---"
        '
        'Timer1
        '
        Me.Timer1.Interval = 100
        '
        'Menu_principal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(720, 285)
        Me.Controls.Add(Me.Lab_Etat_Automate)
        Me.Controls.Add(Me.Lab_Version)
        Me.Controls.Add(Me.Lab_Titre)
        Me.Controls.Add(Me.BP_Quitter)
        Me.Controls.Add(Me.BP_Utilitaires)
        Me.Controls.Add(Me.BP_Impression)
        Me.Controls.Add(Me.BP_Travail)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Menu_principal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "WinVOIE - Menu principal"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BP_Travail As System.Windows.Forms.Button
    Friend WithEvents BP_Impression As System.Windows.Forms.Button
    Friend WithEvents BP_Utilitaires As System.Windows.Forms.Button
    Friend WithEvents BP_Quitter As System.Windows.Forms.Button
    Friend WithEvents Lab_Titre As System.Windows.Forms.Label
    Friend WithEvents Lab_Version As System.Windows.Forms.Label
    Friend WithEvents Lab_Etat_Automate As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer

End Class
