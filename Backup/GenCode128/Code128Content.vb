Imports System
Imports System.Text

Namespace GetCode128

    Public Enum CodeSet
        CodeA
        CodeB
    End Enum

    'Reperent the set of code values to be output into barcode form
    Public Class Code128Content
        Private mCodeList As Integer()

        'Create content based on a string of ASCII data
        Public Sub New(ByVal AsciiData As String)
            mCodeList = StringToCode128(AsciiData)
        End Sub

        'Provide the Code128 code values representing the object's string
        Public ReadOnly Property Codes() As Integer()
            Get
                Return mCodeList
            End Get
        End Property

        'Transform the string into integers representing the Code128 codes
        ' necessary to represent it
        Private Function StringToCode128(ByVal AsciiData As String) As Integer()
            'turn the string into ascii byte data
            Dim asciiBytes As Byte()
            asciiBytes = Encoding.ASCII.GetBytes(AsciiData)

            'decide which codeset to start with
            Dim csa1 As Code128Code.CodeSetAllowed
            Dim csa0 As Code128Code.CodeSetAllowed
            csa0 = Code128Code.CodesetAllowedForChar(asciiBytes(0))
            csa1 = IIf(asciiBytes.Length > 0, csa0, Code128Code.CodeSetAllowed.CodeAorB)

            Dim csa2 As Code128Code.CodeSetAllowed
            Dim csa3 As Code128Code.CodeSetAllowed
            csa3 = Code128Code.CodesetAllowedForChar(asciiBytes(1))
            csa2 = IIf(asciiBytes.Length > 0, csa3, Code128Code.CodeSetAllowed.CodeAorB)
            Dim currcs As CodeSet
            currcs = GetBestStartSet(csa1, csa2)

            'set up the beginning of the barcode
            Dim codes As System.Collections.ArrayList

            codes = New System.Collections.ArrayList(asciiBytes.Length + 3) 'assume no codeset changes, account for start, checksum, and stop
            codes.Add(Code128Code.StartCodeForCodeSet(currcs))

            'add the codes for each character in the string
            For i As Short = 0 To CShort(asciiBytes.Length - 1)
                Dim thischar As Integer = asciiBytes(i)
                Dim nextchar As Integer
                If asciiBytes.Length > (i + 1) Then
                    nextchar = asciiBytes(i + 1)
                Else
                    nextchar = -1
                End If
                'Dim nextchar As Integer = IIf(asciiBytes.Length > (i), asciiBytes(i + 1), 0) '-1)
                codes.AddRange(Code128Code.CodesForChar(thischar, nextchar, currcs))

            Next

            'calculate the check digit
            Dim checksum As Integer = codes(0)
            For i As Integer = 1 To (codes.Count - 1)
                checksum += i * codes(i)
            Next
            codes.Add(checksum Mod 103)
            codes.Add(Code128Code.StopCode())

            Dim result As Integer() = CType(codes.ToArray(GetType(Integer)), Integer())
            Return result

        End Function

        'Determines the best starting code set based on the the first two 
        ' characters of the string to be encoded
        Private Function GetBestStartSet(ByVal csa1 As Code128Code.CodeSetAllowed, ByVal csa2 As Code128Code.CodeSetAllowed) As CodeSet
            Dim vote As Integer = 0
            vote += (IIf(csa1 = Code128Code.CodeSetAllowed.CodeA, 1, 0))
            vote += (IIf(csa1 = Code128Code.CodeSetAllowed.CodeA, 1, 0))
            vote += (IIf(csa2 = Code128Code.CodeSetAllowed.CodeA, 1, 0))
            vote += (IIf(csa2 = Code128Code.CodeSetAllowed.CodeA, 1, 0))

            If vote > 0 Then
                Return CodeSet.CodeA
            Else
                Return CodeSet.CodeB
            End If
            'Return IIf((vote > 0), CodeSet.CodeA, CodeSet.CodeB)
        End Function





    End Class

    Public Class Code128Code
        'Get the Code128 code value(s) to represent an ASCII character, with 
        'optional look-ahead for length optimization

#Region "Constants"
        Private Const cSHIFT As Integer = 98
        Private Const cCODEA As Integer = 101
        Private Const cCODEB As Integer = 100

        Private Const cSTARTA As Integer = 103
        Private Const cSTARTB As Integer = 104
        Private Const cSTOP As Integer = 106
#End Region

        Public Shared Function CodesForChar(ByVal CharAscii As Integer, ByVal LookAheadAscii As Integer, ByRef CurrCodeSet As CodeSet) As Integer()
            Dim result As Integer()
            Dim shifter As Integer = -1

            If (Not CharCompatibleWithCodeset(CharAscii, CurrCodeSet)) Then
                If (LookAheadAscii <> 1) And Not CharCompatibleWithCodeset(LookAheadAscii, CurrCodeSet) Then
                    Select Case CurrCodeSet
                        Case CodeSet.CodeA
                            shifter = cCODEB
                            CurrCodeSet = CodeSet.CodeB
                            Exit Select
                        Case CodeSet.CodeB
                            shifter = cCODEA
                            CurrCodeSet = CodeSet.CodeA
                            Exit Select
                    End Select
                Else
                    shifter = cSHIFT
                End If
            End If

            If shifter <> -1 Then

                'Dim validDates() As Date = New Date() {}

                Dim result1(1) As Integer
                result1(0) = shifter
                result1(1) = CodeValueForChar(CharAscii)
                Return result1
            Else
                Dim result2(0) As Integer
                result2(0) = CodeValueForChar(CharAscii)
                Return result2
            End If

        End Function

        Public Shared Function CodesetAllowedForChar(ByVal CharAscii As Byte) As CodeSetAllowed
            If CharAscii >= 32 And CharAscii <= 95 Then
                Return CodeSetAllowed.CodeAorB
            ElseIf CharAscii < 32 Then
                Return CodeSetAllowed.CodeA
            Else
                Return CodeSetAllowed.CodeB
                'Return IIf((CharAscii < 32), CodeSetAllowed.CodeA, CodeSetAllowed.CodeB)
            End If
        End Function

        'Determine if a character can be represented in a given codeset
        Public Shared Function CharCompatibleWithCodeset(ByVal CharAscii As Integer, ByVal currcs As CodeSet) As Boolean
            Dim csa As CodeSetAllowed
            csa = CodesetAllowedForChar(CharAscii)

            If csa = CodeSetAllowed.CodeAorB Then
                Return CodeSetAllowed.CodeAorB
            ElseIf csa = CodeSetAllowed.CodeA And currcs = CodeSet.CodeA Then
                Return CodeSetAllowed.CodeA And CodeSet.CodeA
            ElseIf csa = CodeSetAllowed.CodeB And currcs = CodeSet.CodeB Then
                Return CodeSetAllowed.CodeB And CodeSet.CodeB
            End If


            'Return csa = CodeSetAllowed.CodeAorB _
            '    Or (csa = CodeSetAllowed.CodeA And currcs = CodeSet.CodeA) _
            '    Or (csa = CodeSetAllowed.CodeB And currcs = CodeSet.CodeB)



        End Function

        'Gets the integer code128 code value for a character (assuming the appropriate code set)
        Public Shared Function CodeValueForChar(ByVal CharAscii As Integer) As Integer
            If CharAscii > 32 Then
                Return CharAscii - 32
            Else
                Return CharAscii + 64
            End If
            'Return IIf(CharAscii > 32, CharAscii - 32, CharAscii + 64)
        End Function

        'Return the appropriate START code depending on the codeset we want to be in
        Public Shared Function StartCodeForCodeSet(ByVal cs As CodeSet) As Integer
            If cs = CodeSet.CodeA Then
                Return cSTARTA
            Else
                Return cSTARTB
            End If
            'Return cs = IIf(cs EQUAL CodeSet.CodeA, cSTARTA, cSTARTB)
        End Function

        'Return the Code128 stop code
        Public Shared Function StopCode() As Integer
            Return cSTOP
        End Function


        Public Enum CodeSetAllowed
            CodeA
            CodeB
            CodeAorB
        End Enum


    End Class
End Namespace
