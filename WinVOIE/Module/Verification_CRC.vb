Module Verification_CRC

    '-- Clé de signature des fichiers d'enregistrement
    '-- (permet de détecter une modification manuelle du fichier par le client)
    Private Const CLE_SIGNATURE As String = "FERRODEMO#Sign2026!"

    '-- Les fichiers antérieurs à cette date ne sont pas signés
    Public ReadOnly DATE_DEBUT_SIGNATURE As New Date(2026, 3, 15)

    ' Contrôle de l'intégrité d'un fichier enregistrement
    ' Retour : True si le fichier a été modifié
    Public Function Fichier_Enreg_Modifie(chemin As String) As Boolean
        Dim Fiche As Integer
        Dim ligne As String
        Dim tab_ligne() As String
        Dim modifie As Boolean = False

        If chemin = "" Then Return False

        Try
            If System.IO.File.GetLastWriteTime(chemin) < DATE_DEBUT_SIGNATURE Then
                Return False
            End If
        Catch
            Return False
        End Try

        Try
            Fiche = FreeFile()
            FileOpen(Fiche, chemin, OpenMode.Input)

            Do While Not EOF(Fiche)
                ligne = LineInput(Fiche)
                tab_ligne = Split(ligne, vbTab)

                '-- la signature est dans la dernière colonne
                If tab_ligne.Length > 1 Then
                    Dim donnees As String = ligne.Substring(0, ligne.LastIndexOf(vbTab))
                    If Calcul_Signature(donnees) <> tab_ligne(tab_ligne.Length - 1) Then
                        modifie = True
                    End If
                End If
            Loop

            FileClose(Fiche)
        Catch ex As Exception
            FileClose(Fiche)
        End Try

        Return modifie

    End Function

    ' Calcul de la signature d'une ligne (somme pondérée avec la clé)
    Public Function Calcul_Signature(donnees As String) As String
        Dim somme As Long = 0
        Dim i As Integer
        Dim texte As String = CLE_SIGNATURE + donnees

        For i = 0 To texte.Length - 1
            somme = (somme * 31 + AscW(texte(i))) Mod 2147483647
        Next

        Return CStr(somme)
    End Function

End Module
