Imports System
Imports System.Collections.Generic
Imports System.Text

Namespace BarcodeLib
    'MustInherit Class BarcodeCommon
    Public Class BarcodeCommon
        Protected Raw_Data As String = ""
        Protected Formatted_Data As String = ""

        Property RawData() As String
            Get
                Return Raw_Data
            End Get
            Set(ByVal value As String)

            End Set
        End Property

        Property FormattedData()
            Get
                Return Formatted_Data
            End Get
            Set(ByVal value)
                Formatted_Data = value
            End Set
        End Property

    End Class
End Namespace


