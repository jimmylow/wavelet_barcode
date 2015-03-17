Imports System
Imports System.Collections.Generic
Imports System.Text

Namespace BarcodeLib
    Interface IBarcode
        Property Encoded_Value() As String
        Property RawData() As String
        Property FormmattedData() As String

    End Interface
End Namespace

