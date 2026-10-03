Imports System.Xml

'-- Liste des librairies tierces et de leurs licences (affichage dans A propos)
Module Module_Licenses

    Public Structure Licence_Librairie
        Dim Nom As String
        Dim Version As String
        Dim Licence As String
        Dim Url As String
    End Structure

    '-- Lecture du fichier Licenses.xml livré avec le logiciel
    Public Function Lire_Licences() As List(Of Licence_Librairie)
        Dim liste As New List(Of Licence_Librairie)
        Dim chemins() As String = {Application.StartupPath + "\Resources\Licenses.xml",
                                   Application.StartupPath + "\Licenses.xml",
                                   "C:\WVOIE\Licenses.xml"}
        Dim fichier As String = ""

        For Each c As String In chemins
            If System.IO.File.Exists(c) Then
                fichier = c
                Exit For
            End If
        Next

        If fichier = "" Then Return liste

        Return Lire_Licences_Fichier(fichier)
    End Function

    '-- Lecture sécurisée : DTD interdite, aucune ressource externe résolue (CA3075).
    '-- Un fichier contenant une DTD lève une XmlException au lieu d'être interprété.
    Public Function Lire_Licences_Fichier(fichier As String) As List(Of Licence_Librairie)
        Dim liste As New List(Of Licence_Librairie)
        Dim parametres As New XmlReaderSettings()
        parametres.DtdProcessing = DtdProcessing.Prohibit
        parametres.XmlResolver = Nothing

        Dim doc As New XmlDocument()
        doc.XmlResolver = Nothing
        Using lecteur As XmlReader = XmlReader.Create(fichier, parametres)
            doc.Load(lecteur)
        End Using

        For Each noeud As XmlNode In doc.SelectNodes("//librairie")
            Dim lib_info As New Licence_Librairie
            lib_info.Nom = noeud.Attributes("nom").Value
            lib_info.Version = noeud.Attributes("version").Value
            lib_info.Licence = noeud.Attributes("licence").Value
            If noeud.SelectSingleNode("url") IsNot Nothing Then
                lib_info.Url = noeud.SelectSingleNode("url").InnerText
            End If
            liste.Add(lib_info)
        Next

        Return liste
    End Function

    '-- Recherche d'une librairie par son nom (insensible à la casse)
    Public Function Trouver_Licence(nom As String) As String
        For Each l As Licence_Librairie In Lire_Licences()
            If l.Nom.ToLower() = nom.ToLower() Then
                Return l.Licence
            End If
        Next
        Return ""
    End Function

End Module
