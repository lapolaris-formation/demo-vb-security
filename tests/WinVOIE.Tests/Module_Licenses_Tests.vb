Imports System.Xml
Imports Xunit

''' <summary>
''' Lire_Licences_Fichier corrige CA3075 : Licenses.xml était chargé par XmlDocument.Load(chemin),
''' qui accepte une DTD (expansion d'entités, références externes).
''' </summary>
Public Class Module_Licenses_Tests
    Implements IDisposable

    Private ReadOnly _fichier As String = Path.Combine(Path.GetTempPath(), "WinVOIE_licences_" & Guid.NewGuid().ToString("N") & ".xml")

    <Fact>
    Public Sub Fichier_de_licences_normal_est_lu()
        File.WriteAllText(_fichier,
            "<?xml version=""1.0"" encoding=""utf-8""?>" &
            "<licences>" &
            "<librairie nom=""Newtonsoft.Json"" version=""13.0.4"" licence=""MIT""><url>https://www.newtonsoft.com/json</url></librairie>" &
            "<librairie nom=""TwinCAT.Ads"" version=""4.3.30"" licence=""Beckhoff"" />" &
            "</licences>")

        Dim licences = Lire_Licences_Fichier(_fichier)

        Assert.Equal(2, licences.Count)
        Assert.Equal("MIT", licences(0).Licence)
        Assert.Equal("https://www.newtonsoft.com/json", licences(0).Url)
        Assert.Equal("TwinCAT.Ads", licences(1).Nom)
    End Sub

    <Fact>
    Public Sub Fichier_contenant_une_DTD_est_refuse()
        ' Entité interne : avec l'ancien XmlDocument.Load(chemin), elle était développée sans contrôle
        File.WriteAllText(_fichier,
            "<?xml version=""1.0""?>" &
            "<!DOCTYPE licences [<!ENTITY x ""DEVELOPPEE"">]>" &
            "<licences><librairie nom=""&x;"" version=""1"" licence=""MIT"" /></licences>")

        Assert.Throws(Of XmlException)(Sub() Lire_Licences_Fichier(_fichier))
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        If File.Exists(_fichier) Then File.Delete(_fichier)
    End Sub

End Class
