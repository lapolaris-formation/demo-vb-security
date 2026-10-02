Imports System.IO

Module LogMod

    '-- Répertoire et nom des journaux
    Private Const REP_JOURNAL As String = "C:\WVOIE\JOURNAL\"
    Private Const TAILLE_MAX_JOURNAL As Long = 500000

    '-- Numéro du fichier journal en cours
    Private num_journal As Integer = -1

    ' Ecriture d'une ligne dans le journal (alarmes, erreurs, actions opérateur)
    Public Sub EcrireLog(origine As String, categorie As String, message As String)
        Dim Fiche As Integer
        Dim nom_fichier As String

        Try
            If Directory.Exists(REP_JOURNAL) = False Then
                Directory.CreateDirectory(REP_JOURNAL)
            End If

            '-- recherche du dernier numéro de journal
            If num_journal < 0 Then
                num_journal = Directory.GetFiles(REP_JOURNAL, "journal_*.txt").Length
                If num_journal > 0 Then num_journal = num_journal - 1
            End If

            nom_fichier = REP_JOURNAL + "journal_" + CStr(num_journal) + ".txt"

            '-- fichier trop gros : on passe au suivant
            If File.Exists(nom_fichier) Then
                If New FileInfo(nom_fichier).Length > TAILLE_MAX_JOURNAL Then
                    num_journal = num_journal + 1
                    nom_fichier = REP_JOURNAL + "journal_" + CStr(num_journal) + ".txt"
                End If
            End If

            Fiche = FreeFile()
            FileOpen(Fiche, nom_fichier, OpenMode.Append)
            PrintLine(Fiche, Format(Now, "dd/MM/yyyy HH:mm:ss") + vbTab + Environment.UserName + vbTab + origine + vbTab + categorie + vbTab + message)
            FileClose(Fiche)

        Catch ex As Exception
            MsgBox("Ecriture journal impossible : " + ex.Message, )
        End Try

    End Sub

End Module
