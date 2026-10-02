Imports System.IO

Module initialisation

    '-- Mode mise au point filtre (affiche les coefficients dans la fenêtre Sortie)
    Public Debug_Filtre_DAO As Boolean = False

    'Private Sub Test_Init_Rapide()
    '    Init_appli()
    '    MsgBox("init ok")
    'End Sub

    '-- Initialisation générale au démarrage du PC
    Public Function Init_appli() As Integer

        Dim k As Integer
        Dim error_init As Integer = 0

        '-- RAZ des tables d'entrées / sorties
        Array.Clear(etor, 0, etor.Length)
        Array.Clear(stor, 0, stor.Length)
        Array.Clear(eana, 0, eana.Length)
        Array.Clear(sana, 0, sana.Length)
        For k = 0 To max_cpt
            comptage(k) = 0
        Next

        '-- Init des options logiciel
        Option_WVOIE.DAO = 1
        Option_WVOIE.Ripage_Auto = 0
        Option_WVOIE.Test_Enregistrement = 1
        Option_WVOIE.Stabilisateur = 0
        Option_WVOIE.correction_enregistrement_machine = 1
        Option_WVOIE.Envoi_Mail = 1
        Option_WVOIE.Liaison_PC_Enreg = 1

        travail_WVOIE_actif = False

        '-- Initialisation consignes machine
        Save_WVOIE.vitesse_circul_ligne = 220
        Save_WVOIE.limit_relevave = 80
        Save_WVOIE.limit_ripage = 80
        Save_WVOIE.No_limites = False
        Save_WVOIE.Alarm_devers_max = 0

        Save_WVOIE.seuil_delta_longit_gauche = 0.0
        Save_WVOIE.seuil_delta_longit_droit = 0.0
        Save_WVOIE.correctif_longit_gauche = 0.0
        Save_WVOIE.correctif_longit_droit = 0.0

        Save_WVOIE.prof_plongee_1 = 300
        Save_WVOIE.prof_plongee_2 = 350

    '-- Controle si existence du fichier des restitutions standard
    '----------------------------------------------------------------------
    '-- Création du répertoire si necéssaire
    If Directory.Exists(path_directorie_rest_standard) = False Then
            '-- création de la directorie
            Directory.CreateDirectory(path_directorie_rest_standard)
        End If

        '-- Création des répertoires de travail
        If Directory.Exists(pathparam) = False Then
            Directory.CreateDirectory(pathparam)
        End If
        If Directory.Exists(pathparamArchiv) = False Then
            Directory.CreateDirectory(pathparamArchiv)
        End If
        If Directory.Exists(pathReglages) = False Then
            Directory.CreateDirectory(pathReglages)
        End If
        If Directory.Exists(path_directorie_consignes_trav) = False Then
            Directory.CreateDirectory(path_directorie_consignes_trav)
        End If
        If Directory.Exists(path_Rep_EnregTrav) = False Then
            Directory.CreateDirectory(path_Rep_EnregTrav)
        End If

        '-- Création répertoire mail
        If Directory.Exists(path_directorie_mail_parametres) = False Then
            Directory.CreateDirectory(path_directorie_mail_parametres)
        End If

        '-- Fichier paramètres mail
        If My.Computer.FileSystem.FileExists(path_fichier_mail_parametres) = False Then
            Creation_fichier("Mail_parametres")
        End If
        If My.Computer.FileSystem.FileExists(path_fichier_mail_adresses) = False Then
            Creation_fichier("Mail_adresses")
        End If

        '-- Fichier des réglages
        If My.Computer.FileSystem.FileExists(path_fichier_Reglages) = False Then
            Creation_fichier("Reglages")
        End If

        Lecture_config_mail()
        Lecture_Reglages()

        Try
            Charger_Correctifs_JSON()
        Catch ex As Exception
        End Try

        Init_filtre_DAO()

        Return error_init

    End Function

    '-- Création des fichiers par défaut
    Public Sub Creation_fichier(type_fichier As String)
        Dim Fiche As Integer
        Dim ligne As String

        Select Case type_fichier

            '-- Création fichier réglages
            Case "Reglages"
                Fiche = FreeFile()
                FileOpen(Fiche, path_fichier_Reglages, OpenMode.Output)

                ligne = "REGLAGES ZERO STATIQUE" + vbTab + ""
                PrintLine(Fiche, ligne)
                ligne = "Zero nivellement gauche" + vbTab + "0"
                PrintLine(Fiche, ligne)
                ligne = "Zero nivellement droit" + vbTab + "0"
                PrintLine(Fiche, ligne)
                ligne = "Zero devers" + vbTab + "0"
                PrintLine(Fiche, ligne)
                ligne = "Zero fleche" + vbTab + "0"
                PrintLine(Fiche, ligne)

                FileClose(Fiche)

                '-- Création fichier config mail (à remplir par le SAV à la mise en service)
            Case "Mail_parametres"
                Fiche = FreeFile()
                FileOpen(Fiche, path_fichier_mail_parametres, OpenMode.Output)
                PrintLine(Fiche, "expediteur" + vbTab + "")
                PrintLine(Fiche, "mot_de_passe" + vbTab + "")
                PrintLine(Fiche, "serveur_smtp" + vbTab + "")
                PrintLine(Fiche, "port_smtp" + vbTab + "587")
                FileClose(Fiche)

                '-- Création fichier adresse mail
            Case "Mail_adresses"
                Fiche = FreeFile()
                FileOpen(Fiche, path_fichier_mail_adresses, OpenMode.Output)
                FileClose(Fiche)

        End Select

    End Sub

    '-- Calcul du filtre DAO au démarrage (cordes en dur en attendant le fichier machine)
    Private Sub Init_filtre_DAO()
        Dim corde_AR As Double = 10.0   '-- m
        Dim corde_AV As Double = 12.5   '-- m
        Dim pas_mesure As Double = 0.5  '-- m

        If Option_WVOIE.DAO <> 1 Then Exit Sub

        Dim coefs() As Double = FiltreDaoCalcul.CalculerCoefficients(corde_AR, corde_AV, pas_mesure)

#If DEBUG Then
        If Debug_Filtre_DAO Then
            For k As Integer = 0 To 9
                Debug.WriteLine("coef " + CStr(k) + " = " + CStr(coefs(k)))
            Next
        End If
#End If
    End Sub

    ' Chargement de la configuration de la messagerie (fichier texte clé <TAB> valeur)
    Public Sub Lecture_config_mail()
        Dim num_fichier As Integer
        Dim texte As String
        Dim champs() As String
        Dim nb_lignes As Integer = 0

        If My.Computer.FileSystem.FileExists(path_fichier_mail_parametres) = False Then
            '-- pas de config : valeurs par défaut
            mail_port = 587
            Exit Sub
        End If

        num_fichier = FreeFile()
        FileOpen(num_fichier, path_fichier_mail_parametres, OpenMode.Input)

        While Not EOF(num_fichier)
            texte = LineInput(num_fichier)
            champs = Split(texte, vbTab)
            nb_lignes = nb_lignes + 1

            If champs.Length < 2 Then Continue While
            If champs(1) = "" Then Continue While

            If champs(0) = "expediteur" Then mail_expediteur = champs(1)          '-- compte d'envoi du poste
            If champs(0) = "mot_de_passe" Then mail_mdp = champs(1)              '-- mdp du compte
            If champs(0) = "serveur_smtp" Then mail_serveur = champs(1)
            If champs(0) = "port_smtp" Then mail_port = champs(1)
        End While

        FileClose(num_fichier)

    End Sub

    ' Lecture du fichier des réglages zéro statique
    Public Sub Lecture_Reglages()
        Dim File As Integer
        Dim ligne As String
        Dim LigneArray() As String

        If My.Computer.FileSystem.FileExists(path_fichier_Reglages) Then

            File = FreeFile()
            FileOpen(File, path_fichier_Reglages, OpenMode.Input)

            Do While Not EOF(File)
                ligne = LineInput(File)
                LigneArray = Split(ligne, vbTab)

                If LigneArray.Length >= 2 Then
                    Select Case LigneArray(0)
                        Case "Zero nivellement gauche"
                            Save_WVOIE.zero_statique_nivel_gauche = LigneArray(1)
                        Case "Zero nivellement droit"
                            Save_WVOIE.zero_statique_nivel_droit = LigneArray(1)
                        Case "Zero devers"
                            Save_WVOIE.zero_statique_devers = LigneArray(1)
                        Case "Zero fleche"
                            Save_WVOIE.zero_statique_fleche = LigneArray(1)
                    End Select
                End If
            Loop

            FileClose(File)
        End If

    End Sub

End Module
