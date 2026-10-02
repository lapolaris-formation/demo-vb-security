Imports System.IO
Imports System.IO.Compression
Imports System.Drawing.Imaging

''' <summary>
''' Création d'une archive de contexte (paramètres, enregistrements, captures écran)
''' à envoyer au SAV FERRODEMO en cas de problème
''' </summary>
Module ContextZip

    ''' <summary>
    ''' Liste des dossiers racine à archiver
    ''' </summary>
    Private ReadOnly DossiersAArchiver As String() = {
        "C:\WVOIE",
        "C:\GEOMETRIE",
        "C:\ENREGISTREMENTS",
        "C:\RELRIP_THEO"
    }

    ''' <summary>
    ''' Nombre de jours d'historique pour les enregistrements (hors dossier WVOIE)
    ''' </summary>
    Private Const NB_JOURS_HISTORIQUE As Integer = 30

    ''' <summary>
    ''' Indique si le dossier est le dossier WVOIE (archivé en totalité)
    ''' </summary>
    Private Function EstDossierWVOIE(cheminDossierRacine As String) As Boolean
        Return cheminDossierRacine.ToUpper().EndsWith("WVOIE")
    End Function

    ''' <summary>
    ''' Le dossier WVOIE est archivé en entier (paramètres, réglages, mail...),
    ''' les autres dossiers seulement sur les 30 derniers jours
    ''' </summary>
    Private Function FichierDoitEtreInclus(cheminFichier As String, estWVOIE As Boolean, dateLimite As DateTime) As Boolean
        If estWVOIE Then
            Return True
        End If
        Return File.GetLastWriteTime(cheminFichier) >= dateLimite
    End Function

    ''' <summary>
    ''' Crée l'archive de contexte complète
    ''' </summary>
    ''' <param name="cheminArchive">Chemin complet du fichier ZIP à créer (ex: "C:\Archives\WVOIE_Context_20240115.zip")</param>
    Public Function CreerArchiveContexte(cheminArchive As String) As Boolean
        Dim dateLimite As DateTime = DateTime.Now.AddDays(-NB_JOURS_HISTORIQUE)

        Try
            If File.Exists(cheminArchive) Then
                File.Delete(cheminArchive)
            End If

            Using archive As ZipArchive = ZipFile.Open(cheminArchive, ZipArchiveMode.Create)
                For Each dossier As String In DossiersAArchiver
                    If Directory.Exists(dossier) Then
                        Dim estWVOIE As Boolean = EstDossierWVOIE(dossier)
                        AjouterDossierDansArchive(archive, dossier, Path.GetFileName(dossier), estWVOIE, dateLimite)
                    End If
                Next
            End Using

            Return True
        Catch ex As Exception
            MsgBox("Erreur création archive contexte : " + ex.Message)
            Return False
        End Try
    End Function

    Private Sub AjouterDossierDansArchive(archive As ZipArchive, cheminSource As String, cheminRelatif As String, estWVOIE As Boolean, dateLimite As DateTime)
        For Each fichier As String In Directory.GetFiles(cheminSource)
            If FichierDoitEtreInclus(fichier, estWVOIE, dateLimite) Then
                AjouterFichierDansArchive(archive, fichier, cheminRelatif + "\" + Path.GetFileName(fichier))
            End If
        Next

        For Each sousDossier As String In Directory.GetDirectories(cheminSource)
            AjouterDossierDansArchive(archive, sousDossier, cheminRelatif + "\" + Path.GetFileName(sousDossier), estWVOIE, dateLimite)
        Next
    End Sub

    Private Sub AjouterFichierDansArchive(archive As ZipArchive, cheminFichier As String, cheminDansArchive As String)
        Try
            Dim entree As ZipArchiveEntry = archive.CreateEntry(cheminDansArchive, CompressionLevel.Optimal)
            Using fluxEntree As Stream = entree.Open()
                Using fluxFichier As New FileStream(cheminFichier, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
                    fluxFichier.CopyTo(fluxEntree)
                End Using
            End Using
        Catch
            ' Fichier verrouillé : on ignore
        End Try
    End Sub

    ''' <summary>
    ''' Crée l'archive sur le bureau avec un nom horodaté et retourne son chemin
    ''' </summary>
    Public Function ExporterContexteVersBureau(Optional screenshotEcran As Bitmap = Nothing) As String
        Dim bureau As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        Dim nomArchive As String = "WVOIE_Context_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".zip"
        Dim cheminArchive As String = Path.Combine(bureau, nomArchive)

        If CreerArchiveContexte(cheminArchive) Then
            If screenshotEcran IsNot Nothing Then
                Using archive As ZipArchive = ZipFile.Open(cheminArchive, ZipArchiveMode.Update)
                    Dim entree As ZipArchiveEntry = archive.CreateEntry("capture_ecran.png")
                    Using flux As Stream = entree.Open()
                        screenshotEcran.Save(flux, ImageFormat.Png)
                    End Using
                End Using
            End If
            Return cheminArchive
        End If

        Return ""
    End Function

    ''' <summary>
    ''' Capture de l'écran principal complet
    ''' </summary>
    Public Function CapturerEcranPublic() As Bitmap
        Try
            Dim bounds As Rectangle = Screen.PrimaryScreen.Bounds
            Dim bmp As New Bitmap(bounds.Width, bounds.Height)
            Using g As Graphics = Graphics.FromImage(bmp)
                g.CopyFromScreen(bounds.Location, Point.Empty, bounds.Size)
            End Using
            Return bmp
        Catch
            Return Nothing
        End Try
    End Function

End Module
