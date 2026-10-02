Option Strict On
Option Infer On

Imports System.Threading

''' <summary>
''' Interception des erreurs non prévues pour éviter la fermeture brutale du logiciel
''' en cours de travail sur la voie.
''' </summary>
Public Module ExceptionHandler

    Private _actif As Boolean = False

    ''' <summary>
    ''' Branche les gestionnaires (appelé une fois dans Menu_principal_Load)
    ''' </summary>
    Public Sub Activer()
        If _actif Then Return

        AddHandler Application.ThreadException, AddressOf ErreurThreadUI
        AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf ErreurAutreThread

        _actif = True
    End Sub

    Private Sub ErreurThreadUI(sender As Object, e As ThreadExceptionEventArgs)
        Signaler(e.Exception, "Interface")
    End Sub

    Private Sub ErreurAutreThread(sender As Object, e As UnhandledExceptionEventArgs)
        Dim ex = TryCast(e.ExceptionObject, Exception)
        If ex Is Nothing Then
            MsgBox("Erreur inconnue", MsgBoxStyle.Critical)
        Else
            Signaler(ex, "Tâche de fond")
        End If
    End Sub

    ''' <summary>
    ''' Journalise puis affiche le détail complet de l'erreur à l'opérateur
    ''' </summary>
    Public Sub Signaler(ex As Exception, Optional origine As String = "")
        Try
            LogMod.EcrireLog(origine, "EXCEPTION", ex.ToString().Replace(Environment.NewLine, " / "))
        Catch
        End Try

        Try
            Using frm As New Frm_Exception(ex, origine)
                frm.ShowDialog()
            End Using
        Catch
            MsgBox(ex.ToString(), MsgBoxStyle.Critical, "Erreur")
        End Try
    End Sub

End Module
