Public Class BarcodeItem

    Public ItemCode As String = ""
    Public ItemName As String = ""
    Public EANCode As String = ""
    Public PriceChecked As String = "Nt"
    Public Price As String = ""
    Public Qty As Integer = 1
    Public PrintPage2 As Boolean = False
    Public Category1 As String = ""
    Public Category2 As String = ""
    Public Category3 As String = ""
    Public Category4 As String = ""
    Public Category5 As String = ""
    Public Category6 As String = ""
    Public Category7 As String = ""
    Public Category8 As String = ""
    Public Category9 As String = ""
    Public Category10 As String = ""


    Public Function getDisplayPrice() As String

        Dim s1 As Decimal

        s1 = Price * 100 / 100

        If s1.ToString.IndexOf(".") = 1 Then
            Return "RM" & Format(s1, "0.00")
        Else
            Return "RM" & Format(s1, "0")
        End If

    End Function

End Class
