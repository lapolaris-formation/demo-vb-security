Imports PdfSharp.Fonts
Imports System.IO

''' <summary>
''' Fournit à PdfSharp les fichiers TTF installés dans C:\Windows\Fonts
''' (PdfSharp 6 ne lit plus les polices système tout seul)
''' </summary>
Public Class WindowsFontResolver
    Implements IFontResolver

    Private Shared ReadOnly _fichiers As New Dictionary(Of String, String) From {
        {"Arial#R", "arial.ttf"},
        {"Arial#B", "arialbd.ttf"},
        {"Arial#I", "ariali.ttf"},
        {"Arial#BI", "arialbi.ttf"}
    }

    ''' <summary>
    ''' Toutes les familles sont ramenées à Arial
    ''' </summary>
    Public Function ResolveTypeface(familyName As String, isBold As Boolean, isItalic As Boolean) As FontResolverInfo Implements IFontResolver.ResolveTypeface
        Dim suffixe As String = ""
        If isBold Then suffixe += "B"
        If isItalic Then suffixe += "I"
        If suffixe = "" Then suffixe = "R"

        Return New FontResolverInfo("Arial#" + suffixe)
    End Function

    ''' <summary>
    ''' Contenu binaire du fichier de police
    ''' </summary>
    Public Function GetFont(faceName As String) As Byte() Implements IFontResolver.GetFont
        Dim dossier As String = Environment.GetFolderPath(Environment.SpecialFolder.Fonts)
        Dim fichier As String = "arial.ttf"

        If _fichiers.ContainsKey(faceName) Then
            fichier = _fichiers(faceName)
        End If

        Try
            Return File.ReadAllBytes(Path.Combine(dossier, fichier))
        Catch
            Return Nothing
        End Try
    End Function

End Class
