Module Mes_variables

    '-- POur mots de passe
    Public flg_Passe_Word_Input As Boolean = False

    Public PSW_saisie As String

    '-- Version Logiciel

    Public Const Version_Logiciel_PC As String = "L_WVOIE_UNI_6_73h"

    '-- Infos poste (affichées dans A propos et sauvées dans parametres.par)
    Public Nom_OS_Poste As String = Lire_Nom_OS()
    Public Version_Automate As String = "?"

    '-- Lecture du nom de l'OS dans la base de registre
    Private Function Lire_Nom_OS() As String
        Dim nom As String = ""
        Try
            nom = Microsoft.Win32.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "ProductName", "")
        Catch
        End Try
        If nom = "" Then
            nom = "Windows " + Environment.OSVersion.Version.ToString()
        End If
        Return nom
    End Function


    Public IP_Adress_PC_Enreg As String = "192.168.10.2"
    'Public IP_Adress_PC_Enreg As String = "127.0.0.1"
    Public IP_Adress_PC_Cabine As String = "192.168.10.3"
    Public Port_Serveur_Commandes As Integer = 5001

    '-- Définition des répertoires et fichiers
    '-----------------------------------------

    Public Const pathparam As String = "C:\WVOIE\PARAMETRES\TRAVAIL\"
    Public Const pathparamArchiv As String = "C:\WVOIE\PARAMETRES\ARCHIVES"
    Public Const path_fichier_parametres As String = "C:\WVOIE\PARAMETRES\TRAVAIL\parametres.par"
    Public Const path_fichier_parametres_archives As String = "C:\WVOIE\PARAMETRES\ARCHIVES\parametres.par"
    Public Const path_fichier_vitesse_simulation As String = "C:\WVOIE\PARAMETRES\TRAVAIL\vitesse_simu.par"

    Public Const path_parametres_temporaire As String = "C:\WVOIE\PARAMETRES\TEMPORAIRE\"
    Public Const path_parametres_temporaire_fichier As String = "C:\WVOIE\PARAMETRES\TEMPORAIRE\tempo.par"

    Public Const path_geom_save As String = "C:\GEOMETRIE"
    Public Const path_geom_trav As String = "C:\GEOMETRIE\TRAVAIL\"
    Public Const path_geometrie_temporaire As String = "C:\GEOMETRIE\TEMPORAIRE\"

    Public Const path_logo_impression As String = "C:\WVOIE\IMAGES\ferrodemo_200p.jpg"
    Public Const pathReglages As String = "C:\WVOIE\REGLAGES"
    Public Const path_fichier_Reglages As String = "C:\WVOIE\REGLAGES\reglages.rgl"
    Public Const path_fichier_Alarmes As String = "C:\WVOIE\ALARMES\W_alarme.ala"

    Public Const path_Rep_EnregTrav As String = "C:\ENREGISTREMENTS\TRAVAIL\"
    Public Const path_Rep_Fichiers_Reference As String = "C:\ENREGISTREMENTS\REFERENCE\"

    Public path_directorie_consignes_trav As String = "C:\WVOIE\CONSIGNES"

    '------les standard de restitution
    Public Const path_directorie_rest_standard As String = "C:\WVOIE\STANDARD\FERRODEMO"

    Public Const path_fichier_rest_standard As String = "C:\WVOIE\STANDARD\FERRODEMO\standard.stdf"

    '-- Options logiciel
    Public Structure Type_Option_WVOIE
        Dim DAO As Integer
        Dim Ripage_Auto As Integer
        Dim Test_Enregistrement As Integer
        Dim Stabilisateur As Integer
        Dim correction_enregistrement_machine As Integer
        Dim Envoi_Mail As Integer
        Dim Liaison_PC_Enreg As Integer
    End Structure

    Public Option_WVOIE As Type_Option_WVOIE

    '-- Consignes machine
    Public Structure Type_Save_WVOIE
        Dim vitesse_circul_ligne As Integer
        Dim limit_relevave As Integer
        Dim limit_ripage As Integer
        Dim No_limites As Boolean
        Dim Alarm_devers_max As Integer
        Dim seuil_delta_longit_gauche As Double
        Dim seuil_delta_longit_droit As Double
        Dim correctif_longit_gauche As Double
        Dim correctif_longit_droit As Double
        Dim prof_plongee_1 As Integer
        Dim prof_plongee_2 As Integer
        Dim zero_statique_nivel_gauche As Double
        Dim zero_statique_nivel_droit As Double
        Dim zero_statique_devers As Double
        Dim zero_statique_fleche As Double
    End Structure

    Public Save_WVOIE As Type_Save_WVOIE

    Public travail_WVOIE_actif As Boolean = False

    '-- Correctifs machine (sauvegarde JSON)
    Public Class Correctifs_Machine
        Public Property Correctif_Nivellement_Gauche As Double
        Public Property Correctif_Nivellement_Droit As Double
        Public Property Correctif_Devers As Double
        Public Property Date_Modification As String
        Public Property Operateur As String
    End Class

    Public Correctifs_Mach As New Correctifs_Machine

    '-- Liaison TCP/IP PC enregistrement
    Public buff_TCPIP_send As String = ""
    Public buff_TPCIP_Display As String = ""
    Public Liaison_PC_Enreg As LiaisonTcpPcEnreg

    '-- Index pour fichier des parametres
    Public Indexe_Selection_Filtre_TCA As Integer = 2
    Public Indexe_Selection_Calage_Zero As Integer = 3
    Public Indexe_Selection_Filtrage_Regelage_Zero As Integer = 7 'Mediane ou moyenne

    Public path_directorie_mail_parametres As String = "C:\WVOIE\MAIL\"
    Public path_fichier_mail_parametres As String = "C:\WVOIE\MAIL\mail_parametres.con"
    Public path_fichier_mail_adresses As String = "C:\WVOIE\MAIL\mail_adresses.adr"

    Public Destinataires_Mail As String
    Public Destinataires_Copie_Mail As String
    Public mail_expediteur As String
    Public mail_mdp As String
    Public mail_serveur As String
    Public mail_port As Integer

    Public memo_vitesse_simulation_travail As Integer
    Public memo_vitesse_simulation_enregistrement As Integer

    'Sélection format enregistrement client
    Public Enreg_format_client As Boolean

    '-- Fichier de référence sélectionné pour comparaison
    Public Fichier_Reference_Selectionne As String = ""

End Module
