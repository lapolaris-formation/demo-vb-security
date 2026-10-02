' =============================================================================
' ExportEnregistrementPDF.vb
' Export PDF des enregistrements travail (courbes géométriques)
'
' Génère un PDF au format paysage :
' - Zone légende à gauche (paramètre, échelle)
' - Courbes tracées point par point
' - Entête avec informations du fichier (à développer)
' =============================================================================

Imports System.IO
Imports PdfSharp.Pdf
Imports PdfSharp.Drawing

''' <summary>
''' Classe d'export PDF des enregistrements travail
''' </summary>
Public Class ExportEnregistrementPDF

#Region "Constantes de mise en page"

    Private Const MARGE_GAUCHE_MM As Double = 10
    Private Const LARGEUR_LEGENDE_MM As Double = 40
    Private Const HAUTEUR_COURBE_MM As Double = 35
    Private Const MM_TO_POINT As Double = 72.0 / 25.4

#End Region

#Region "Variables membres"

    Private _points As New List(Of PointMesure)
    Private _titre As String = ""

#End Region

    ''' <summary>
    ''' Charge les points de mesure depuis un fichier enregistrement travail
    ''' </summary>
    Public Sub ChargerFichier(cheminFichier As String)
        If cheminFichier = "" Then
            Throw New ArgumentException("cheminFichier")
        End If

        _points.Clear()
        _titre = Path.GetFileNameWithoutExtension(cheminFichier)

        For Each ligne As String In File.ReadAllLines(cheminFichier)
            If ligne <> "" AndAlso Char.IsDigit(ligne(0)) Then
                _points.Add(New PointMesure(ligne))
            End If
        Next
    End Sub

    ''' <summary>
    ''' Génère le fichier PDF des courbes
    ''' </summary>
    ''' <param name="cheminFichier">Chemin du fichier PDF de sortie</param>
    Public Sub ExporterPDF(cheminFichier As String)

        If _points.Count = 0 Then Return

        ' Enregistrer le résolveur de polices Windows pour PdfSharp
        If PdfSharp.Fonts.GlobalFontSettings.FontResolver Is Nothing Then
            PdfSharp.Fonts.GlobalFontSettings.FontResolver = New WindowsFontResolver()
        End If

        Dim document As New PdfDocument()
        document.Info.Title = "Enregistrement travail " + _titre
        document.Info.Author = "WinVOIE " + Version_Logiciel_PC

        Dim page As PdfPage = document.AddPage()
        page.Size = PdfSharp.PageSize.A4
        page.Orientation = PdfSharp.PageOrientation.Landscape

        Using gfx As XGraphics = XGraphics.FromPdfPage(page)
            Dim fontTitre As New XFont("Arial", 14, XFontStyleEx.Bold)
            Dim fontLegende As New XFont("Arial", 8, XFontStyleEx.Regular)

            gfx.DrawString("Enregistrement travail : " + _titre, fontTitre, XBrushes.Black, New XPoint(MARGE_GAUCHE_MM * MM_TO_POINT, 20))

            Dim noms() As String = {"Niv. gauche", "Niv. droit", "Dévers", "Flèche"}
            Dim couleurs() As XPen = {XPens.Blue, XPens.Red, XPens.Green, XPens.DarkOrange}

            Dim xDebut As Double = (MARGE_GAUCHE_MM + LARGEUR_LEGENDE_MM) * MM_TO_POINT
            Dim largeur As Double = page.Width.Point - xDebut - 20
            Dim pas As Double = largeur / Math.Max(1, _points.Count - 1)

            For c As Integer = 0 To 3
                Dim yAxe As Double = (30 + c * HAUTEUR_COURBE_MM + HAUTEUR_COURBE_MM / 2) * MM_TO_POINT
                gfx.DrawString(noms(c), fontLegende, XBrushes.Black, New XPoint(MARGE_GAUCHE_MM * MM_TO_POINT, yAxe))
                gfx.DrawLine(XPens.LightGray, xDebut, yAxe, xDebut + largeur, yAxe)

                For i As Integer = 1 To _points.Count - 1
                    Dim v1 As Integer = ValeurCourbe(_points(i - 1), c)
                    Dim v2 As Integer = ValeurCourbe(_points(i), c)
                    gfx.DrawLine(couleurs(c), xDebut + (i - 1) * pas, yAxe - v1 / 10.0, xDebut + i * pas, yAxe - v2 / 10.0)
                Next
            Next
        End Using

        ' TODO : ajouter la courbe d'écartement (seuils asymétriques)
        ' TODO : entête avec PK début / fin et opérateur
        document.Save(cheminFichier)

    End Sub

    Private Function ValeurCourbe(p As PointMesure, index As Integer) As Integer
        Select Case index
            Case 0 : Return p.Nivellement_Gauche
            Case 1 : Return p.Nivellement_Droit
            Case 2 : Return p.Devers
            Case Else : Return p.Fleche
        End Select
    End Function

End Class
