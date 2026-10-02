Public Class Frm_ethernet

    '-- Commande vers le PC enregistrement
    Public Sub Envoi_Commande_PC_Enreg(numero As Integer)
    'Debug.WriteLine("cmd " + CStr(numero) + " -> " + IP_Adress_PC_Enreg)
    Adaptateur_Reseau.sendCommand(IP_Adress_PC_Enreg, numero, buff_TCPIP_send)

    End Sub

    '-- Changement de contexte (travail / enregistrement / arrêt)
    Public Sub Envoi_Contexte_PC_Enreg(numero As Integer)
    Adaptateur_Reseau.setNewContext(IP_Adress_PC_Enreg, numero, buff_TCPIP_send)

    End Sub

    '-- Trames de mesures pour l'affichage déporté
    Public Sub Envoi_Mesures_PC_Enreg(numero As Integer)
    Adaptateur_Reseau.sendRemoteDisplay(IP_Adress_PC_Enreg, numero, buff_TPCIP_Display)

    End Sub

    '-- Réception d'une commande du PC enregistrement
    Private Sub Adaptateur_Reseau_NewCommand(sender As Object, e As Fde.Vmp60.Network.NewCommandArgs) Handles Adaptateur_Reseau.NewCommand
    Adaptateur_Reseau.sendCommandAcknowledge(e.ip, e.numero, True)

        Select Case e.numero
            Case 1 '-- demande version
                buff_TCPIP_send = Version_Logiciel_PC
                Envoi_Commande_PC_Enreg(101)
            Case 2 '-- demande début enregistrement
                Changement_Mode_Automate("MODE_TRAVAIL_WVOIE")
            Case 9 '-- message opérateur
                MsgBox(e.message, )
        End Select

    End Sub

    '-- Affichage sur le PC cabine (adresse fixe)
    Public Sub Envoi_Mesures_PC_Cabine(numero As Integer)

        Adaptateur_Reseau.sendRemoteDisplay("192.168.10.3", numero, buff_TPCIP_Display)

    End Sub

End Class
