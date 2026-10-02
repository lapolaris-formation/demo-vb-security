Imports System.IO
Imports TwinCAT.Ads

Module Mes_variables_BECKHOFF

    '-- Liaison ADS automate
    Public tcClient As TcAdsClient
    Public AMS_Net_ID As String = "5.80.201.14.1.1"
    Public Port_Twincat As Integer = 851

    Public EtatDeLautomate As Boolean = False

    '-- Dimensions des tables E/S
    Public Const max_etor As Integer = 64
    Public Const max_stor As Integer = 32
    Public Const max_eana As Integer = 16
    Public Const max_sana As Integer = 8
    Public Const max_cpt As Integer = 4

    Public etor(max_etor) As Boolean
    Public stor(max_stor) As Integer
    Public eana(max_eana) As Integer
    Public sana(max_sana) As Integer
    Public comptage(max_cpt) As Integer

    '-- Handles variables automate
    Public hdl_Index_Avance As Integer
    Public hdl_Distance_mm As Integer
    Public hdl_Mesures_Valides As Integer
    Public hdl_flg_init_RDM As Integer
    Public hdl_Simulation As Integer
    Public hdl_Defaut_Module As Integer
    Public hdl_Tab_ETOR As Integer
    Public hdl_Tab_STOR As Integer
    Public hdl_Tab_EANA As Integer
    Public hdl_Tab_SANA As Integer
    Public hdl_Version_Automate As Integer
    Public hdl_zero_nivel_gauche As Integer
    Public hdl_zero_nivel_droit As Integer
    Public hdl_zero_devers As Integer
    Public hdl_zero_fleche As Integer
    Public hdl_corr_rdm_pc As Integer
    Public hdl_Vitesse_Simu As Integer
    Public PLC_distance_test_enregistrement As Integer

    '-- Flux de lecture
    Public dataStream As New AdsStream(4)
    Public binReader As New BinaryReader(dataStream)
    Public flux_ETOR As AdsStream
    Public lecteur_ETOR As BinaryReader
    Public flux_EANA As AdsStream
    Public lecteur_EANA As BinaryReader
    Public flux_Version As New AdsStream(30)
    Public lecteur_Version As New BinaryReader(flux_Version)

    Public Distance_Parcourue As Integer
    Public Index_Avance As Integer

End Module
