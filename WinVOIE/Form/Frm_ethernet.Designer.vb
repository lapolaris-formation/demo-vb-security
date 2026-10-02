<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_ethernet
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
        Me.components = New System.ComponentModel.Container()
        Me.Adaptateur_Reseau = New Fde.Vmp60.Network.NetworkAdaptator
        Me.Mise_A_Jour_iBox = New Fde.Vmp60.Network.iBoxUpdater(Me.components)
        Me.Lab_Etat = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Lab_Etat
        '
        Me.Lab_Etat.AutoSize = True
        Me.Lab_Etat.Location = New System.Drawing.Point(12, 9)
        Me.Lab_Etat.Name = "Lab_Etat"
        Me.Lab_Etat.Size = New System.Drawing.Size(120, 13)
        Me.Lab_Etat.TabIndex = 0
        Me.Lab_Etat.Text = "Liaison PC enregistrement"
        '
        'Frm_ethernet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 41)
        Me.Controls.Add(Me.Lab_Etat)
        Me.Name = "Frm_ethernet"
        Me.ShowInTaskbar = False
        Me.Text = "Frm_ethernet"
        Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Adaptateur_Reseau As Fde.Vmp60.Network.NetworkAdaptator
    Friend WithEvents Mise_A_Jour_iBox As Fde.Vmp60.Network.iBoxUpdater
    Friend WithEvents Lab_Etat As System.Windows.Forms.Label
End Class
