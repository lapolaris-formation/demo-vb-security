Imports System.IO

Public Class Frm_Choix_File_Ref

    Private Sub Frm_Choix_File_Ref_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Directory.Exists(path_Rep_Fichiers_Reference) = False Then
            Directory.CreateDirectory(path_Rep_Fichiers_Reference)
        End If
        Rafraichir_Listes()
    End Sub

    Private Sub Rafraichir_Listes()
        LB_Enregistrements.Items.Clear()
        LB_References.Items.Clear()

        For Each f As String In Directory.GetFiles(path_Rep_EnregTrav, "*.ent")
            LB_Enregistrements.Items.Add(Path.GetFileName(f))
        Next
        For Each f As String In Directory.GetFiles(path_Rep_Fichiers_Reference, "*.ent")
            LB_References.Items.Add(Path.GetFileName(f))
        Next
    End Sub

    '-- Copie d'un enregistrement dans les références sous le nom saisi
    Private Sub BP_Copier_Click(sender As Object, e As EventArgs) Handles BP_Copier.Click
        Dim source As String
        Dim destination As String

        If LB_Enregistrements.SelectedIndex < 0 Then
            MsgBox("Sélectionner un enregistrement", )
            Exit Sub
        End If

        If TB_Nom_Reference.Text = "" Then
            TB_Nom_Reference.Text = Path.GetFileNameWithoutExtension(LB_Enregistrements.SelectedItem)
        End If

        source = path_Rep_EnregTrav + LB_Enregistrements.SelectedItem
        destination = path_Rep_Fichiers_Reference + TB_Nom_Reference.Text + ".ent"

        Try
            File.Copy(source, destination, True)
        Catch ex As Exception
            MsgBox("Copie impossible : " + ex.Message, )
        End Try

        Rafraichir_Listes()
    End Sub

    Private Sub BP_Supprimer_Click(sender As Object, e As EventArgs) Handles BP_Supprimer.Click
        If LB_References.SelectedIndex < 0 Then Exit Sub

        If MsgBox("Supprimer " + LB_References.SelectedItem + " ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            File.Delete(path_Rep_Fichiers_Reference + LB_References.SelectedItem)
            Rafraichir_Listes()
        End If
    End Sub

    Private Sub BP_Selection_Click(sender As Object, e As EventArgs) Handles BP_Selection.Click
        If LB_References.SelectedIndex >= 0 Then
            Fichier_Reference_Selectionne = path_Rep_Fichiers_Reference + LB_References.SelectedItem
            Me.Close()
        End If
    End Sub

    Private Sub BP_Retour_Click(sender As Object, e As EventArgs) Handles BP_Retour.Click
        Me.Close()
    End Sub

End Class
