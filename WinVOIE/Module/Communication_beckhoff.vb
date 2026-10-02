Imports System.IO
Imports TwinCAT.Ads

Module Communication_beckhoff

    '-- Passage de l'automate dans le mode demandé (travail, réglage...)
    Public Function Changement_Mode_Automate(mode As String) As Integer
        Dim code_retour As Integer = 0
        Dim n As Integer

        '-- (re)connexion si besoin
        Try
            If tcClient Is Nothing Then
                tcClient = New TcAdsClient()
                tcClient.Connect(AMS_Net_ID, Port_Twincat)
            ElseIf tcClient.IsConnected = False Then
                tcClient.Connect(AMS_Net_ID, Port_Twincat)
            End If

            If tcClient.ReadState().AdsState <> AdsState.Run And EtatDeLautomate = False Then
                MsgBox("L'automate n'est pas en RUN", )
                EtatDeLautomate = True
            End If
        Catch ex As Exception
            If EtatDeLautomate = False Then MsgBox("Pas de communication avec l'automate", )
            EtatDeLautomate = True
            Return 1
        End Try

        EtatDeLautomate = False

        Select Case mode

#Region "Case MODE_TRAVAIL_WVOIE"

            Case "MODE_TRAVAIL_WVOIE"
                Try
                    '-- RAZ roue de mesure
                    tcClient.WriteAny(hdl_flg_init_RDM, 1)

                    '-- ancienne distance test (garder pour compatibilité automate V5)
                    tcClient.WriteAny(PLC_distance_test_enregistrement, 25000)

                    If Option_WVOIE.Test_Enregistrement = 1 Then
                        tcClient.WriteAny(hdl_corr_rdm_pc, 0)
                    End If

                    For n = 0 To max_stor
                        stor(n) = 0
                    Next
                Catch ex As Exception
                    code_retour = 1
                End Try
#End Region

#Region "Case MODE_REGLAGE"

			Case "MODE_REGLAGE"
				Try
					tcClient.WriteAny(hdl_Simulation, 0)
					tcClient.WriteAny(hdl_zero_nivel_gauche, Save_WVOIE.zero_statique_nivel_gauche)
					tcClient.WriteAny(hdl_zero_nivel_droit, Save_WVOIE.zero_statique_nivel_droit)
					tcClient.WriteAny(hdl_zero_devers, Save_WVOIE.zero_statique_devers)
					tcClient.WriteAny(hdl_zero_fleche, Save_WVOIE.zero_statique_fleche)
				Catch ex As Exception
					code_retour = 1
				End Try
#End Region

            Case Else

        End Select

        Return code_retour

    End Function

    '-- Ouverture liaison ADS + récupération des handles
    Public Function Connect_PLC() As Integer
        Dim retour As Integer = 0

			Try
				flux_ETOR = New AdsStream(max_etor + 1)
				lecteur_ETOR = New BinaryReader(flux_ETOR)
				flux_EANA = New AdsStream((max_eana + 1) * 2)
				lecteur_EANA = New BinaryReader(flux_EANA)

				tcClient = New TcAdsClient()
				tcClient.Connect(AMS_Net_ID, Port_Twincat)
			Catch ex As Exception
				MsgBox("Connexion automate impossible", )
				retour = 1
			End Try

			'-- handles
			Try
				hdl_Index_Avance = tcClient.CreateVariableHandle("GVL_PC.nIndexAvance")
				hdl_Distance_mm = tcClient.CreateVariableHandle("GVL_PC.nDistanceMm")
				hdl_Mesures_Valides = tcClient.CreateVariableHandle("GVL_PC.bMesuresValides")
				hdl_flg_init_RDM = tcClient.CreateVariableHandle("GVL_PC.bInitRoue")
				hdl_Simulation = tcClient.CreateVariableHandle("GVL_PC.bSimulation")
				hdl_Defaut_Module = tcClient.CreateVariableHandle("GVL_PC.bDefautModule")
				hdl_Tab_ETOR = tcClient.CreateVariableHandle("GVL_IO.aETOR")
				hdl_Tab_STOR = tcClient.CreateVariableHandle("GVL_IO.aSTOR")
				hdl_Tab_EANA = tcClient.CreateVariableHandle("GVL_IO.aEANA")
				hdl_Tab_SANA = tcClient.CreateVariableHandle("GVL_IO.aSANA")
				hdl_Version_Automate = tcClient.CreateVariableHandle("GVL_PC.sVersion")
				hdl_zero_nivel_gauche = tcClient.CreateVariableHandle("GVL_REG.rZeroNivG")
				hdl_zero_nivel_droit = tcClient.CreateVariableHandle("GVL_REG.rZeroNivD")
				hdl_zero_devers = tcClient.CreateVariableHandle("GVL_REG.rZeroDevers")
				hdl_zero_fleche = tcClient.CreateVariableHandle("GVL_REG.rZeroFleche")
				hdl_corr_rdm_pc = tcClient.CreateVariableHandle("GVL_REG.rCorrRoue")
				hdl_Vitesse_Simu = tcClient.CreateVariableHandle("GVL_PC.nVitesseSimu")
				'-- ancien test enregistrement
				PLC_distance_test_enregistrement = tcClient.CreateVariableHandle("GVL_PC.nDistTestEnreg")
			Catch ex As Exception
				retour = 2
			End Try

        Return retour

    End Function

    '-- Lecture cyclique (timer 100 ms)
    Public Sub Lecture_entrees_PLC()
        Dim n As Integer

        Try
                    tcClient.Read(hdl_Distance_mm, dataStream)
                    dataStream.Position = 0
                    Distance_Parcourue = binReader.ReadInt32()

                    tcClient.Read(hdl_Index_Avance, dataStream)
                    dataStream.Position = 0
                    Index_Avance = binReader.ReadInt32()

                    tcClient.Read(hdl_Tab_ETOR, flux_ETOR)
                    flux_ETOR.Position = 0
                    For n = 0 To max_etor
                        etor(n) = lecteur_ETOR.ReadBoolean()
                    Next

                    tcClient.Read(hdl_Tab_EANA, flux_EANA)
                    flux_EANA.Position = 0
                    For n = 0 To max_eana
                        eana(n) = lecteur_EANA.ReadInt16()
                    Next
        Catch ex As Exception
        End Try

    End Sub

    '-- Fermeture liaison
    Public Sub Deconnexion_PLC()
        Try
            tcClient.DeleteVariableHandle(hdl_Index_Avance)
            tcClient.DeleteVariableHandle(hdl_Distance_mm)
            tcClient.DeleteVariableHandle(hdl_Mesures_Valides)
            tcClient.DeleteVariableHandle(hdl_flg_init_RDM)
            tcClient.DeleteVariableHandle(hdl_Simulation)
            tcClient.DeleteVariableHandle(hdl_Defaut_Module)
            tcClient.DeleteVariableHandle(hdl_Tab_ETOR)
            tcClient.DeleteVariableHandle(hdl_Tab_STOR)
            tcClient.DeleteVariableHandle(hdl_Tab_EANA)
            tcClient.DeleteVariableHandle(hdl_Tab_SANA)
            tcClient.Dispose()
        Catch
        End Try
    End Sub

End Module
