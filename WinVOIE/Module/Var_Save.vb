Imports System.IO
Imports Newtonsoft.Json

Module Var_Save

  ' Sauvegarde des réglages zéro statique
  Public Sub Save_Reglages()
    Dim Fiche As Integer
    Dim ligne As String

    Fiche = FreeFile()
    FileOpen(Fiche, path_fichier_Reglages, OpenMode.Output)

    ligne = "REGLAGES ZERO STATIQUE" + vbTab + ""
    PrintLine(Fiche, ligne)
    ligne = "Zero nivellement gauche" + vbTab + CStr(Save_WVOIE.zero_statique_nivel_gauche)
    PrintLine(Fiche, ligne)
    ligne = "Zero nivellement droit" + vbTab + CStr(Save_WVOIE.zero_statique_nivel_droit)
    PrintLine(Fiche, ligne)
    ligne = "Zero devers" + vbTab + CStr(Save_WVOIE.zero_statique_devers)
    PrintLine(Fiche, ligne)
    ligne = "Zero fleche" + vbTab + CStr(Save_WVOIE.zero_statique_fleche)
    PrintLine(Fiche, ligne)

    FileClose(Fiche)


  End Sub

  ' Sauvegarde des consignes machine
  Public Sub Save_Consignes()
    Dim Fiche As Integer
    Dim ligne As String

    Fiche = FreeFile()
    FileOpen(Fiche, path_directorie_consignes_trav + "\" + "consignes.csg", OpenMode.Output)

    ligne = "Vitesse circulation ligne" + vbTab + CStr(Save_WVOIE.vitesse_circul_ligne)
    PrintLine(Fiche, ligne)
    ligne = "Limite relevage" + vbTab + CStr(Save_WVOIE.limit_relevave)
    PrintLine(Fiche, ligne)
    ligne = "Limite ripage" + vbTab + CStr(Save_WVOIE.limit_ripage)
    PrintLine(Fiche, ligne)

    If Option_WVOIE.Stabilisateur = 1 Then
      ligne = "Profondeur plongee 1" + vbTab + CStr(Save_WVOIE.prof_plongee_1)
      PrintLine(Fiche, ligne)

      ligne = "Profondeur plongee 2" + vbTab + CStr(Save_WVOIE.prof_plongee_2)
      PrintLine(Fiche, ligne)
    End If

    FileClose(Fiche)

  End Sub

  '-- Lecture des correctifs machine (fichier JSON)
  Public Sub Charger_Correctifs_JSON()
    Dim chemin As String = path_directorie_consignes_trav + "\correctifs.json"

    If Option_WVOIE.correction_enregistrement_machine <> 1 Then Exit Sub

    Dim contenu As String = File.ReadAllText(chemin)
    Correctifs_Mach = JsonConvert.DeserializeObject(Of Correctifs_Machine)(contenu)
  End Sub

  '-- Ecriture des correctifs machine (fichier JSON)
  Public Sub Sauver_Correctifs_JSON()
    Dim chemin As String = path_directorie_consignes_trav + "\correctifs.json"

    If Option_WVOIE.correction_enregistrement_machine <> 1 Then Exit Sub

    Correctifs_Mach.Date_Modification = Now.ToString("dd/MM/yyyy HH:mm")
    File.WriteAllText(chemin, JsonConvert.SerializeObject(Correctifs_Mach, Formatting.Indented))
  End Sub


    ''' <summary>
    ''' Libellé affiché dans l'historique des sauvegardes
    ''' </summary>
    Public Function Libelle_Sauvegarde(code As String) As String
        If code = "ZS" Then Return "Zéro statique"
        If code = "ZD" Then Return "Zéro dynamique"
        If code = "GN" Then Return "Gains capteurs"
        Return "?"
    End Function

End Module
