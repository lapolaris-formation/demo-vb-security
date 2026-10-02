Option Strict On
Option Infer On

' =============================================================================
' FiltreDaoCalcul.vb
' Calcul des coefficients du filtre inverse DAO (portage du code MATLAB)
' =============================================================================

Imports System.Numerics
Imports MathNet.Numerics
Imports MathNet.Numerics.IntegralTransforms

''' <summary>
''' Calcul du filtre de correction de la flèche mesurée sur corde asymétrique
''' </summary>
Public Module FiltreDaoCalcul

    ''' <summary>
    ''' Nombre de points de la FFT (puissance de 2)
    ''' </summary>
    Private Const NB_POINTS_FFT As Integer = 1024

    ''' <summary>
    ''' Calcule les coefficients du filtre inverse pour une corde a (AR) / b (AV)
    ''' </summary>
    ''' <param name="a">Corde arrière en mètres</param>
    ''' <param name="b">Corde avant en mètres</param>
    ''' <param name="Fe">Pas d'échantillonnage en mètres</param>
    Public Function CalculerCoefficients(a As Double, b As Double, Fe As Double) As Double()
        Dim n As Integer = NB_POINTS_FFT
        Dim spectre(n - 1) As Complex

        ' Fonction de transfert de la corde asymétrique
        ' H(k) = 1 - (b/(a+b)) * exp(-j*k*a) - (a/(a+b)) * exp(j*k*b)
        For i As Integer = 0 To n - 1
            Dim frequence As Double = If(i <= n \ 2, i, i - n) / (n * Fe)
            Dim k As Double = 2.0 * Math.PI * frequence
            Dim h As Complex = Complex.One _
                - (b / (a + b)) * Complex.Exp(New Complex(0, -k * a)) _
                - (a / (a + b)) * Complex.Exp(New Complex(0, k * b))

            ' Inversion avec seuil pour éviter la division par zéro
            If h.Magnitude < 0.05 Then
                spectre(i) = Complex.Zero
            Else
                spectre(i) = Complex.One / h
            End If
        Next

        ' MATLAB ifft divise par N. MathNet Inverse avec Default divise par sqrt(N).
        Fourier.Inverse(spectre, FourierOptions.Matlab)

        Dim coefs(n - 1) As Double
        For i As Integer = 0 To n - 1
            coefs(i) = spectre(i).Real
        Next

        ' Lissage léger des coefficients
        Dim moyenne As Double = Statistics.ArrayStatistics.Mean(coefs)
        Debug.WriteLine($"[FiltreDaoCalcul] moyenne coefficients = {moyenne}")

        Return coefs
    End Function

End Module
