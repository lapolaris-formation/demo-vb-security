<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Choix_File_Ref
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
        Me.LB_Enregistrements = New System.Windows.Forms.ListBox()
        Me.LB_References = New System.Windows.Forms.ListBox()
        Me.Lab_Enreg = New System.Windows.Forms.Label()
        Me.Lab_Ref = New System.Windows.Forms.Label()
        Me.TB_Nom_Reference = New System.Windows.Forms.TextBox()
        Me.BP_Copier = New System.Windows.Forms.Button()
        Me.BP_Supprimer = New System.Windows.Forms.Button()
        Me.BP_Selection = New System.Windows.Forms.Button()
        Me.BP_Retour = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'LB_Enregistrements
        '
        Me.LB_Enregistrements.FormattingEnabled = True
        Me.LB_Enregistrements.Location = New System.Drawing.Point(12, 30)
        Me.LB_Enregistrements.Name = "LB_Enregistrements"
        Me.LB_Enregistrements.Size = New System.Drawing.Size(260, 251)
        Me.LB_Enregistrements.TabIndex = 0
        '
        'LB_References
        '
        Me.LB_References.FormattingEnabled = True
        Me.LB_References.Location = New System.Drawing.Point(420, 30)
        Me.LB_References.Name = "LB_References"
        Me.LB_References.Size = New System.Drawing.Size(260, 251)
        Me.LB_References.TabIndex = 1
        '
        'Lab_Enreg
        '
        Me.Lab_Enreg.AutoSize = True
        Me.Lab_Enreg.Location = New System.Drawing.Point(12, 9)
        Me.Lab_Enreg.Name = "Lab_Enreg"
        Me.Lab_Enreg.Size = New System.Drawing.Size(130, 13)
        Me.Lab_Enreg.TabIndex = 2
        Me.Lab_Enreg.Text = "Enregistrements travail"
        '
        'Lab_Ref
        '
        Me.Lab_Ref.AutoSize = True
        Me.Lab_Ref.Location = New System.Drawing.Point(420, 9)
        Me.Lab_Ref.Name = "Lab_Ref"
        Me.Lab_Ref.Size = New System.Drawing.Size(110, 13)
        Me.Lab_Ref.TabIndex = 3
        Me.Lab_Ref.Text = "Fichiers de référence"
        '
        'TB_Nom_Reference
        '
        Me.TB_Nom_Reference.Location = New System.Drawing.Point(285, 60)
        Me.TB_Nom_Reference.Name = "TB_Nom_Reference"
        Me.TB_Nom_Reference.Size = New System.Drawing.Size(122, 20)
        Me.TB_Nom_Reference.TabIndex = 4
        '
        'BP_Copier
        '
        Me.BP_Copier.Location = New System.Drawing.Point(285, 90)
        Me.BP_Copier.Name = "BP_Copier"
        Me.BP_Copier.Size = New System.Drawing.Size(122, 40)
        Me.BP_Copier.TabIndex = 5
        Me.BP_Copier.Text = "Copier en référence ->"
        Me.BP_Copier.UseVisualStyleBackColor = True
        '
        'BP_Supprimer
        '
        Me.BP_Supprimer.Location = New System.Drawing.Point(285, 145)
        Me.BP_Supprimer.Name = "BP_Supprimer"
        Me.BP_Supprimer.Size = New System.Drawing.Size(122, 40)
        Me.BP_Supprimer.TabIndex = 6
        Me.BP_Supprimer.Text = "Supprimer référence"
        Me.BP_Supprimer.UseVisualStyleBackColor = True
        '
        'BP_Selection
        '
        Me.BP_Selection.Location = New System.Drawing.Point(285, 200)
        Me.BP_Selection.Name = "BP_Selection"
        Me.BP_Selection.Size = New System.Drawing.Size(122, 40)
        Me.BP_Selection.TabIndex = 7
        Me.BP_Selection.Text = "Utiliser comme référence"
        Me.BP_Selection.UseVisualStyleBackColor = True
        '
        'BP_Retour
        '
        Me.BP_Retour.Location = New System.Drawing.Point(560, 295)
        Me.BP_Retour.Name = "BP_Retour"
        Me.BP_Retour.Size = New System.Drawing.Size(120, 40)
        Me.BP_Retour.TabIndex = 8
        Me.BP_Retour.Text = "Retour"
        Me.BP_Retour.UseVisualStyleBackColor = True
        '
        'Frm_Choix_File_Ref
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(692, 347)
        Me.ControlBox = False
        Me.Controls.Add(Me.BP_Retour)
        Me.Controls.Add(Me.BP_Selection)
        Me.Controls.Add(Me.BP_Supprimer)
        Me.Controls.Add(Me.BP_Copier)
        Me.Controls.Add(Me.TB_Nom_Reference)
        Me.Controls.Add(Me.Lab_Ref)
        Me.Controls.Add(Me.Lab_Enreg)
        Me.Controls.Add(Me.LB_References)
        Me.Controls.Add(Me.LB_Enregistrements)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "Frm_Choix_File_Ref"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Fichiers de référence"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LB_Enregistrements As System.Windows.Forms.ListBox
    Friend WithEvents LB_References As System.Windows.Forms.ListBox
    Friend WithEvents Lab_Enreg As System.Windows.Forms.Label
    Friend WithEvents Lab_Ref As System.Windows.Forms.Label
    Friend WithEvents TB_Nom_Reference As System.Windows.Forms.TextBox
    Friend WithEvents BP_Copier As System.Windows.Forms.Button
    Friend WithEvents BP_Supprimer As System.Windows.Forms.Button
    Friend WithEvents BP_Selection As System.Windows.Forms.Button
    Friend WithEvents BP_Retour As System.Windows.Forms.Button
End Class
