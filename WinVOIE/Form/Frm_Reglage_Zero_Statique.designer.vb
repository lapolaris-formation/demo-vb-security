<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Reglage_Zero_Statique
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Lab_NivG = New System.Windows.Forms.Label()
        Me.Lab_NivD = New System.Windows.Forms.Label()
        Me.Lab_Devers = New System.Windows.Forms.Label()
        Me.Lab_Fleche = New System.Windows.Forms.Label()
        Me.TB_Zero_NivG = New System.Windows.Forms.TextBox()
        Me.TB_Zero_NivD = New System.Windows.Forms.TextBox()
        Me.TB_Zero_Devers = New System.Windows.Forms.TextBox()
        Me.TB_Zero_Fleche = New System.Windows.Forms.TextBox()
        Me.TB_Mesure_NivG = New System.Windows.Forms.TextBox()
        Me.TB_Mesure_NivD = New System.Windows.Forms.TextBox()
        Me.TB_Mesure_Devers = New System.Windows.Forms.TextBox()
        Me.TB_Mesure_Fleche = New System.Windows.Forms.TextBox()
        Me.BP_Calcul_Zero = New System.Windows.Forms.Button()
        Me.BP_Valider = New System.Windows.Forms.Button()
        Me.BP_Retour = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Lab_NivG)
        Me.GroupBox1.Controls.Add(Me.Lab_NivD)
        Me.GroupBox1.Controls.Add(Me.Lab_Devers)
        Me.GroupBox1.Controls.Add(Me.Lab_Fleche)
        Me.GroupBox1.Controls.Add(Me.TB_Zero_NivG)
        Me.GroupBox1.Controls.Add(Me.TB_Zero_NivD)
        Me.GroupBox1.Controls.Add(Me.TB_Zero_Devers)
        Me.GroupBox1.Controls.Add(Me.TB_Zero_Fleche)
        Me.GroupBox1.Controls.Add(Me.TB_Mesure_NivG)
        Me.GroupBox1.Controls.Add(Me.TB_Mesure_NivD)
        Me.GroupBox1.Controls.Add(Me.TB_Mesure_Devers)
        Me.GroupBox1.Controls.Add(Me.TB_Mesure_Fleche)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(440, 190)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "REGLAGE DES ZEROS STATIQUES (1/10 mm)"
        '
        'Lab_NivG
        '
        Me.Lab_NivG.AutoSize = True
        Me.Lab_NivG.Location = New System.Drawing.Point(15, 35)
        Me.Lab_NivG.Name = "Lab_NivG"
        Me.Lab_NivG.Size = New System.Drawing.Size(130, 16)
        Me.Lab_NivG.TabIndex = 0
        Me.Lab_NivG.Text = "Nivellement gauche"
        '
        'Lab_NivD
        '
        Me.Lab_NivD.AutoSize = True
        Me.Lab_NivD.Location = New System.Drawing.Point(15, 72)
        Me.Lab_NivD.Name = "Lab_NivD"
        Me.Lab_NivD.Size = New System.Drawing.Size(120, 16)
        Me.Lab_NivD.TabIndex = 1
        Me.Lab_NivD.Text = "Nivellement droit"
        '
        'Lab_Devers
        '
        Me.Lab_Devers.AutoSize = True
        Me.Lab_Devers.Location = New System.Drawing.Point(15, 109)
        Me.Lab_Devers.Name = "Lab_Devers"
        Me.Lab_Devers.Size = New System.Drawing.Size(53, 16)
        Me.Lab_Devers.TabIndex = 2
        Me.Lab_Devers.Text = "Dévers"
        '
        'Lab_Fleche
        '
        Me.Lab_Fleche.AutoSize = True
        Me.Lab_Fleche.Location = New System.Drawing.Point(15, 146)
        Me.Lab_Fleche.Name = "Lab_Fleche"
        Me.Lab_Fleche.Size = New System.Drawing.Size(52, 16)
        Me.Lab_Fleche.TabIndex = 3
        Me.Lab_Fleche.Text = "Flèche"
        '
        'TB_Zero_NivG
        '
        Me.TB_Zero_NivG.Location = New System.Drawing.Point(180, 32)
        Me.TB_Zero_NivG.Name = "TB_Zero_NivG"
        Me.TB_Zero_NivG.Size = New System.Drawing.Size(110, 22)
        Me.TB_Zero_NivG.TabIndex = 4
        '
        'TB_Zero_NivD
        '
        Me.TB_Zero_NivD.Location = New System.Drawing.Point(180, 69)
        Me.TB_Zero_NivD.Name = "TB_Zero_NivD"
        Me.TB_Zero_NivD.Size = New System.Drawing.Size(110, 22)
        Me.TB_Zero_NivD.TabIndex = 5
        '
        'TB_Zero_Devers
        '
        Me.TB_Zero_Devers.Location = New System.Drawing.Point(180, 106)
        Me.TB_Zero_Devers.Name = "TB_Zero_Devers"
        Me.TB_Zero_Devers.Size = New System.Drawing.Size(110, 22)
        Me.TB_Zero_Devers.TabIndex = 6
        '
        'TB_Zero_Fleche
        '
        Me.TB_Zero_Fleche.Location = New System.Drawing.Point(180, 143)
        Me.TB_Zero_Fleche.Name = "TB_Zero_Fleche"
        Me.TB_Zero_Fleche.Size = New System.Drawing.Size(110, 22)
        Me.TB_Zero_Fleche.TabIndex = 7
        '
        'TB_Mesure_NivG
        '
        Me.TB_Mesure_NivG.Location = New System.Drawing.Point(310, 32)
        Me.TB_Mesure_NivG.Name = "TB_Mesure_NivG"
        Me.TB_Mesure_NivG.ReadOnly = True
        Me.TB_Mesure_NivG.Size = New System.Drawing.Size(110, 22)
        Me.TB_Mesure_NivG.TabIndex = 8
        '
        'TB_Mesure_NivD
        '
        Me.TB_Mesure_NivD.Location = New System.Drawing.Point(310, 69)
        Me.TB_Mesure_NivD.Name = "TB_Mesure_NivD"
        Me.TB_Mesure_NivD.ReadOnly = True
        Me.TB_Mesure_NivD.Size = New System.Drawing.Size(110, 22)
        Me.TB_Mesure_NivD.TabIndex = 9
        '
        'TB_Mesure_Devers
        '
        Me.TB_Mesure_Devers.Location = New System.Drawing.Point(310, 106)
        Me.TB_Mesure_Devers.Name = "TB_Mesure_Devers"
        Me.TB_Mesure_Devers.ReadOnly = True
        Me.TB_Mesure_Devers.Size = New System.Drawing.Size(110, 22)
        Me.TB_Mesure_Devers.TabIndex = 10
        '
        'TB_Mesure_Fleche
        '
        Me.TB_Mesure_Fleche.Location = New System.Drawing.Point(310, 143)
        Me.TB_Mesure_Fleche.Name = "TB_Mesure_Fleche"
        Me.TB_Mesure_Fleche.ReadOnly = True
        Me.TB_Mesure_Fleche.Size = New System.Drawing.Size(110, 22)
        Me.TB_Mesure_Fleche.TabIndex = 11
        '
        'BP_Calcul_Zero
        '
        Me.BP_Calcul_Zero.Location = New System.Drawing.Point(12, 215)
        Me.BP_Calcul_Zero.Name = "BP_Calcul_Zero"
        Me.BP_Calcul_Zero.Size = New System.Drawing.Size(140, 45)
        Me.BP_Calcul_Zero.TabIndex = 1
        Me.BP_Calcul_Zero.Text = "Calcul zéro"
        Me.BP_Calcul_Zero.UseVisualStyleBackColor = True
        '
        'BP_Valider
        '
        Me.BP_Valider.Location = New System.Drawing.Point(162, 215)
        Me.BP_Valider.Name = "BP_Valider"
        Me.BP_Valider.Size = New System.Drawing.Size(140, 45)
        Me.BP_Valider.TabIndex = 2
        Me.BP_Valider.Text = "Valider"
        Me.BP_Valider.UseVisualStyleBackColor = True
        '
        'BP_Retour
        '
        Me.BP_Retour.Location = New System.Drawing.Point(312, 215)
        Me.BP_Retour.Name = "BP_Retour"
        Me.BP_Retour.Size = New System.Drawing.Size(140, 45)
        Me.BP_Retour.TabIndex = 3
        Me.BP_Retour.Text = "Retour"
        Me.BP_Retour.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Interval = 200
        '
        'Frm_Reglage_Zero_Statique
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(464, 272)
        Me.ControlBox = False
        Me.Controls.Add(Me.BP_Retour)
        Me.Controls.Add(Me.BP_Valider)
        Me.Controls.Add(Me.BP_Calcul_Zero)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "Frm_Reglage_Zero_Statique"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Réglage zéro statique"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Lab_NivG As System.Windows.Forms.Label
    Friend WithEvents Lab_NivD As System.Windows.Forms.Label
    Friend WithEvents Lab_Devers As System.Windows.Forms.Label
    Friend WithEvents Lab_Fleche As System.Windows.Forms.Label
    Friend WithEvents TB_Zero_NivG As System.Windows.Forms.TextBox
    Friend WithEvents TB_Zero_NivD As System.Windows.Forms.TextBox
    Friend WithEvents TB_Zero_Devers As System.Windows.Forms.TextBox
    Friend WithEvents TB_Zero_Fleche As System.Windows.Forms.TextBox
    Friend WithEvents TB_Mesure_NivG As System.Windows.Forms.TextBox
    Friend WithEvents TB_Mesure_NivD As System.Windows.Forms.TextBox
    Friend WithEvents TB_Mesure_Devers As System.Windows.Forms.TextBox
    Friend WithEvents TB_Mesure_Fleche As System.Windows.Forms.TextBox
    Friend WithEvents BP_Calcul_Zero As System.Windows.Forms.Button
    Friend WithEvents BP_Valider As System.Windows.Forms.Button
    Friend WithEvents BP_Retour As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
End Class
