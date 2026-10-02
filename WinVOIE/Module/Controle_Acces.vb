Imports System.IO
Imports System.Security.Cryptography

''' <summary>
''' Contrôle des accès maintenance (paramètres machine, réglages, configuration mail).
''' Les mots de passe ne sont plus écrits dans le code : le poste ne conserve qu'une empreinte
''' PBKDF2 salée par profil, dans C:\WVOIE\PARAMETRES\acces.par, créée à l'installation
''' par le SAV avec outils\creer-acces.ps1.
''' Format d'une ligne : profil [TAB] sel en base64 [TAB] empreinte en base64
''' </summary>
Module Controle_Acces

    Public Const path_fichier_acces As String = "C:\WVOIE\PARAMETRES\acces.par"

    Public Const PROFIL_SUPERVISEUR As String = "SUPERVISEUR"
    Public Const PROFIL_SAV As String = "SAV"

    '-- Paramètres PBKDF2 : à garder identiques dans outils\creer-acces.ps1
    Private Const ITERATIONS As Integer = 210000
    Private Const TAILLE_SEL As Integer = 16
    Private Const TAILLE_EMPREINTE As Integer = 32

    ''' <summary>
    ''' Vrai si la saisie correspond au mot de passe de l'un des profils autorisés
    ''' </summary>
    Public Function Mot_De_Passe_Valide(saisie As String, profils_autorises As String(), Optional fichier As String = path_fichier_acces) As Boolean
        If String.IsNullOrEmpty(saisie) OrElse Not File.Exists(fichier) Then
            Return False
        End If

        For Each ligne As String In File.ReadAllLines(fichier)
            Dim champs() As String = ligne.Split(ControlChars.Tab)
            If champs.Length <> 3 OrElse Array.IndexOf(profils_autorises, champs(0)) < 0 Then
                Continue For
            End If

            Try
                Dim sel() As Byte = Convert.FromBase64String(champs(1))
                Dim attendue() As Byte = Convert.FromBase64String(champs(2))
                If Egalite_Temps_Constant(Calcul_Empreinte(saisie, sel), attendue) Then
                    Return True
                End If
            Catch ex As FormatException
                '-- ligne corrompue : ignorée, l'accès reste refusé
            End Try
        Next

        Return False
    End Function

    ''' <summary>
    ''' Ligne prête à écrire dans acces.par (même calcul que outils\creer-acces.ps1)
    ''' </summary>
    Public Function Ligne_Acces(profil As String, mot_de_passe As String) As String
        Dim sel(TAILLE_SEL - 1) As Byte
        Using generateur As RandomNumberGenerator = RandomNumberGenerator.Create()
            generateur.GetBytes(sel)
        End Using
        Return profil & ControlChars.Tab & Convert.ToBase64String(sel) & ControlChars.Tab & Convert.ToBase64String(Calcul_Empreinte(mot_de_passe, sel))
    End Function

    Private Function Calcul_Empreinte(mot_de_passe As String, sel() As Byte) As Byte()
        Using pbkdf2 As New Rfc2898DeriveBytes(mot_de_passe, sel, ITERATIONS, HashAlgorithmName.SHA256)
            Return pbkdf2.GetBytes(TAILLE_EMPREINTE)
        End Using
    End Function

    '-- Comparaison qui ne s'arrête pas au premier octet différent
    Private Function Egalite_Temps_Constant(a() As Byte, b() As Byte) As Boolean
        If a.Length <> b.Length Then Return False
        Dim difference As Integer = 0
        For i As Integer = 0 To a.Length - 1
            difference = difference Or (a(i) Xor b(i))
        Next
        Return difference = 0
    End Function

End Module
