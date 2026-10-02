Option Strict On
Option Infer On

Imports System.Text

''' <summary>
''' Fenêtre d'erreur : affiche le détail technique complet (copiable) pour le SAV
''' </summary>
Public Class Frm_Exception
    Inherits Form

    Private txtDetail As TextBox
    Private btnCopier As Button
    Private btnExport As Button
    Private btnFermer As Button
    Private lblEntete As Label

    Private ReadOnly _erreur As Exception
    Private ReadOnly _origine As String
    Private ReadOnly _capture As Bitmap

    Public Sub New(ex As Exception, Optional origine As String = "")
        ' Capture avant affichage de la fenêtre
        _capture = ContextZip.CapturerEcranPublic()
        _erreur = ex
        _origine = origine
        Construire()
    End Sub

    Private Sub Construire()
        Me.Text = "Erreur WinVOIE - SAV : hotline@ferrodemo.example"
        Me.Size = New Size(820, 600)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.TopMost = True

        lblEntete = New Label()
        lblEntete.Dock = DockStyle.Top
        lblEntete.Height = 60
        lblEntete.BackColor = Color.Firebrick
        lblEntete.ForeColor = Color.White
        lblEntete.Font = New Font("Arial", 14, FontStyle.Bold)
        lblEntete.TextAlign = ContentAlignment.MiddleCenter
        lblEntete.Text = "ERREUR INATTENDUE"

        txtDetail = New TextBox()
        txtDetail.Multiline = True
        txtDetail.ReadOnly = True
        txtDetail.ScrollBars = ScrollBars.Both
        txtDetail.Font = New Font("Consolas", 9)
        txtDetail.Dock = DockStyle.Fill

        Dim pnlBas As New FlowLayoutPanel()
        pnlBas.Dock = DockStyle.Bottom
        pnlBas.Height = 50
        pnlBas.FlowDirection = FlowDirection.RightToLeft

        btnFermer = New Button() With {.Text = "Fermer", .Width = 120, .Height = 36}
        btnExport = New Button() With {.Text = "Export contexte SAV", .Width = 160, .Height = 36}
        btnCopier = New Button() With {.Text = "Copier", .Width = 120, .Height = 36}
        AddHandler btnFermer.Click, Sub() Me.Close()
        AddHandler btnCopier.Click, Sub() Clipboard.SetText(txtDetail.Text)
        AddHandler btnExport.Click, AddressOf Export_Click
        pnlBas.Controls.AddRange(New Control() {btnFermer, btnExport, btnCopier})

        Me.Controls.Add(txtDetail)
        Me.Controls.Add(pnlBas)
        Me.Controls.Add(lblEntete)

        Dim sb As New StringBuilder()
        sb.AppendLine("Version     : " & Version_Logiciel_PC)
        sb.AppendLine("Poste       : " & Environment.MachineName & " / " & Environment.UserName)
        sb.AppendLine("Origine     : " & _origine)
        sb.AppendLine("Date        : " & DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"))
        sb.AppendLine()
        sb.AppendLine(_erreur.ToString())
        txtDetail.Text = sb.ToString()
    End Sub

    Private Sub Export_Click(sender As Object, e As EventArgs)
        Dim chemin = ContextZip.ExporterContexteVersBureau(_capture)
        If chemin <> "" Then
            MsgBox("Archive créée : " & chemin, MsgBoxStyle.Information)
        End If
    End Sub

End Class
