Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.Threading

' Liaison TCP avec le PC enregistrement (remplace l'ancienne liaison RS232)
Public Class LiaisonTcpPcEnreg
  Public Enum CodeTrame As Integer
    OUVERTURE = 1
    PRET = 2
    FERMETURE = 3
    FERME = 4

    MESURE = 10
    ACQUIT = 11
  End Enum

  Private ecoute As TcpListener
  Private connexion As TcpClient
  Private threadEcoute As Thread
  Private actif As Boolean = False

  ' Trames en attente d'envoi
  Private fileTrames As New Queue(Of String)
  Private pcPret As Boolean = False
  Private attenteAcquit As Boolean = False

  Public Event TrameRecue(code As Integer, contenu As String)

  '---------------- mode serveur ----------------
  Public Sub Demarrer(port As Integer)
    ecoute = New TcpListener(IPAddress.Any, port)
    ecoute.Start()
    actif = True

    threadEcoute = New Thread(AddressOf BoucleAttente)
    threadEcoute.IsBackground = True
    threadEcoute.Start()
  End Sub

  Private Sub BoucleAttente()
    Do While actif
      Try
        connexion = ecoute.AcceptTcpClient()
        Dim th As New Thread(AddressOf BoucleLecture)
        th.IsBackground = True
        th.Start()
      Catch
      End Try
    Loop
  End Sub

  '---------------- mode client ----------------
  Public Sub Connecter(adresse As String, port As Integer)
    connexion = New TcpClient()
    connexion.Connect(adresse, port)
    actif = True
    Dim th As New Thread(AddressOf BoucleLecture)
    th.IsBackground = True
    th.Start()
  End Sub

  '---------------- lecture ----------------
  Private Sub BoucleLecture()
    Try
      Using flux = connexion.GetStream()
        Do While actif And connexion.Connected
          Dim code = LireEntier(flux)
          Dim contenu = LireTexte(flux)
          Traiter(code, contenu)
        Loop
      End Using
    Catch
      Arreter()
    End Try
  End Sub

  Private Sub Traiter(code As Integer, contenu As String)
    If code = CodeTrame.PRET Then
      pcPret = True
      EnvoyerSuivante()
    ElseIf code = CodeTrame.ACQUIT Then
      attenteAcquit = False
      EnvoyerSuivante()
    Else
      RaiseEvent TrameRecue(code, contenu)
    End If
  End Sub

  '---------------- envoi ----------------
  Public Sub Envoyer(code As Integer, contenu As String)
    If connexion Is Nothing Then Exit Sub
    If connexion.Connected = False Then Exit Sub

    SyncLock Me
      Using flux = connexion.GetStream()
        EcrireEntier(flux, code)
        EcrireTexte(flux, contenu)
      End Using
    End SyncLock
  End Sub

  Public Sub AjouterTrame(contenu As String)
    SyncLock fileTrames
      fileTrames.Enqueue(contenu)
    End SyncLock

    If pcPret And Not attenteAcquit Then EnvoyerSuivante()
  End Sub

  Private Sub EnvoyerSuivante()
    SyncLock fileTrames
      If fileTrames.Count > 0 Then
        attenteAcquit = True
        Envoyer(CodeTrame.MESURE, fileTrames.Dequeue())
      Else
        attenteAcquit = False
      End If
    End SyncLock
  End Sub

  Public Sub Arreter()
    actif = False
    Try
      If connexion IsNot Nothing Then connexion.Close()
      If ecoute IsNot Nothing Then ecoute.Stop()
    Catch
    End Try
  End Sub

  '---------------- format trame : [longueur][octets] ----------------
  Private Function LireEntier(flux As NetworkStream) As Integer
    Dim tampon(3) As Byte
    LireOctets(flux, tampon, 4)
    Return BitConverter.ToInt32(tampon, 0)
  End Function

  Private Function LireTexte(flux As NetworkStream) As String
    Dim longueur = LireEntier(flux)
    If longueur <= 0 Then Return ""
    Dim tampon(longueur - 1) As Byte
    LireOctets(flux, tampon, longueur)
    Return Encoding.UTF8.GetString(tampon)
  End Function

  Private Sub EcrireEntier(flux As NetworkStream, valeur As Integer)
    flux.Write(BitConverter.GetBytes(valeur), 0, 4)
  End Sub

  Private Sub EcrireTexte(flux As NetworkStream, texte As String)
    Dim octets = Encoding.UTF8.GetBytes(texte)
    EcrireEntier(flux, octets.Length)
    flux.Write(octets, 0, octets.Length)
  End Sub

  Private Sub LireOctets(flux As NetworkStream, tampon() As Byte, nb As Integer)
    Dim lus = 0
    Do While lus < nb
      Dim n = flux.Read(tampon, lus, nb - lus)
      If n = 0 Then Throw New Exception("Connexion perdue")
      lus = lus + n
    Loop
  End Sub

End Class
