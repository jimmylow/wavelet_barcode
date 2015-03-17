Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Data

Namespace BarcodeLib
    Public Class Code128
        Inherits BarcodeCommon

        Private C128_Code As DataTable = New DataTable("C128")
        Private _FormattedData As List(Of String) = New List(Of String)
        Private _EncodedData As List(Of String) = New List(Of String)
        Private StartCharacter As DataRow

        Public Sub New(ByVal input As String)
            Raw_Data = input
        End Sub

        Private Function Encode_Code128() As String
            init_Code128()
            Return GetEncoding()
        End Function

        Private Function Formatted_Data_Code128() As String
            Return GetEncoding()
        End Function

        Private Sub init_Code128()
            'set the table to case sensitive since there are upper and lower case values
            C128_Code.CaseSensitive = True

            'set up columns
            C128_Code.Columns.Add("Value", System.Type.GetType("System.String"))
            C128_Code.Columns.Add("A", System.Type.GetType("System.String"))
            C128_Code.Columns.Add("B", System.Type.GetType("System.String"))
            C128_Code.Columns.Add("C", System.Type.GetType("System.String"))
            C128_Code.Columns.Add("Encoding", System.Type.GetType("System.String"))

            C128_Code.Rows.Add("0", " ", " ", "00", "11011001100")
            C128_Code.Rows.Add("1", "!", "!", "01", "11001101100")



            C128_Code.Rows.Add("2", "\", "\", "02", "11001100110") '"2", "\"", " \ "", "02", "11001100110"
            C128_Code.Rows.Add("3", "#", "#", "03", "10010011000")
            C128_Code.Rows.Add("4", "$", "$", "04", "10010001100")
            C128_Code.Rows.Add("5", "%", "%", "05", "10001001100")
            C128_Code.Rows.Add("6", "&", "&", "06", "10011001000")
            C128_Code.Rows.Add("7", "'", "'", "07", "10011000100")
            C128_Code.Rows.Add("8", "(", "(", "08", "10001100100")
            C128_Code.Rows.Add("9", ")", ")", "09", "11001001000")
            C128_Code.Rows.Add("10", "*", "*", "10", "11001000100")
            C128_Code.Rows.Add("11", "+", "+", "11", "11000100100")
            C128_Code.Rows.Add("12", ",", ",", "12", "10110011100")
            C128_Code.Rows.Add("13", "-", "-", "13", "10011011100")
            C128_Code.Rows.Add("14", ".", ".", "14", "10011001110")
            C128_Code.Rows.Add("15", "/", "/", "15", "10111001100")
            C128_Code.Rows.Add("16", "0", "0", "16", "10011101100")
            C128_Code.Rows.Add("17", "1", "1", "17", "10011100110")
            C128_Code.Rows.Add("18", "2", "2", "18", "11001110010")
            C128_Code.Rows.Add("19", "3", "3", "19", "11001011100")
            C128_Code.Rows.Add("20", "4", "4", "20", "11001001110")
            C128_Code.Rows.Add("21", "5", "5", "21", "11011100100")
            C128_Code.Rows.Add("22", "6", "6", "22", "11001110100")
            C128_Code.Rows.Add("23", "7", "7", "23", "11101101110")
            C128_Code.Rows.Add("24", "8", "8", "24", "11101001100")
            C128_Code.Rows.Add("25", "9", "9", "25", "11100101100")
            C128_Code.Rows.Add("26", ":", ":", "26", "11100100110")
            C128_Code.Rows.Add("27", ";", ";", "27", "11101100100")
            C128_Code.Rows.Add("28", "<", "<", "28", "11100110100")
            C128_Code.Rows.Add("29", "=", "=", "29", "11100110010")
            C128_Code.Rows.Add("30", ">", ">", "30", "11011011000")
            C128_Code.Rows.Add("31", "?", "?", "31", "11011000110")
            C128_Code.Rows.Add("32", "@", "@", "32", "11000110110")
            C128_Code.Rows.Add("33", "A", "A", "33", "10100011000")
            C128_Code.Rows.Add("34", "B", "B", "34", "10001011000")
            C128_Code.Rows.Add("35", "C", "C", "35", "10001000110")
            C128_Code.Rows.Add("36", "D", "D", "36", "10110001000")
            C128_Code.Rows.Add("37", "E", "E", "37", "10001101000")
            C128_Code.Rows.Add("38", "F", "F", "38", "10001100010")
            C128_Code.Rows.Add("39", "G", "G", "39", "11010001000")
            C128_Code.Rows.Add("40", "H", "H", "40", "11000101000")
            C128_Code.Rows.Add("41", "I", "I", "41", "11000100010")
            C128_Code.Rows.Add("42", "J", "J", "42", "10110111000")
            C128_Code.Rows.Add("43", "K", "K", "43", "10110001110")
            C128_Code.Rows.Add("44", "L", "L", "44", "10001101110")
            C128_Code.Rows.Add("45", "M", "M", "45", "10111011000")
            C128_Code.Rows.Add("46", "N", "N", "46", "10111000110")
            C128_Code.Rows.Add("47", "O", "O", "47", "10001110110")
            C128_Code.Rows.Add("48", "P", "P", "48", "11101110110")
            C128_Code.Rows.Add("49", "Q", "Q", "49", "11010001110")
            C128_Code.Rows.Add("50", "R", "R", "50", "11000101110")
            C128_Code.Rows.Add("51", "S", "S", "51", "11011101000")
            C128_Code.Rows.Add("52", "T", "T", "52", "11011100010")
            C128_Code.Rows.Add("53", "U", "U", "53", "11011101110")
            C128_Code.Rows.Add("54", "V", "V", "54", "11101011000")
            C128_Code.Rows.Add("55", "W", "W", "55", "11101000110")
            C128_Code.Rows.Add("56", "X", "X", "56", "11100010110")
            C128_Code.Rows.Add("57", "Y", "Y", "57", "11101101000")
            C128_Code.Rows.Add("58", "Z", "U", "58", "11101100010")
            C128_Code.Rows.Add("59", "[", "[", "59", "11100011010")
            C128_Code.Rows.Add("60", "\", "\", "60", "11101111010") '"60",@"\",@"\", "60", "11101111010" )
            C128_Code.Rows.Add("61", "]", "]", "61", "11001000010")
            C128_Code.Rows.Add("62", "^", "^", "62", "11110001010")
            C128_Code.Rows.Add("63", "_", "_", "63", "10100110000")
            C128_Code.Rows.Add("64", "\0", "`", "64", "10100001100")
            C128_Code.Rows.Add("65", Convert.ToChar(1).ToString(), "a", "65", "10010110000")

            C128_Code.Rows.Add("66", Convert.ToChar(2).ToString(), "b", "66", "10010000110")
            C128_Code.Rows.Add("67", Convert.ToChar(3).ToString(), "c", "67", "10000101100")
            C128_Code.Rows.Add("68", Convert.ToChar(4).ToString(), "d", "68", "10000100110")
            C128_Code.Rows.Add("69", Convert.ToChar(5).ToString(), "e", "69", "10110010000")
            C128_Code.Rows.Add("70", Convert.ToChar(6).ToString(), "f", "70", "10110000100")
            C128_Code.Rows.Add("71", Convert.ToChar(7).ToString(), "g", "71", "10011010000")
            C128_Code.Rows.Add("72", Convert.ToChar(8).ToString(), "h", "72", "10011000010")
            C128_Code.Rows.Add("73", Convert.ToChar(9).ToString(), "i", "73", "10000110100")
            C128_Code.Rows.Add("74", Convert.ToChar(10).ToString(), "j", "74", "10000110010")
            C128_Code.Rows.Add("75", Convert.ToChar(11).ToString(), "k", "75", "11000010010")
            C128_Code.Rows.Add("76", Convert.ToChar(12).ToString(), "l", "76", "11001010000")
            C128_Code.Rows.Add("77", Convert.ToChar(13).ToString(), "m", "77", "11110111010")
            C128_Code.Rows.Add("78", Convert.ToChar(14).ToString(), "n", "78", "11000010100")
            C128_Code.Rows.Add("79", Convert.ToChar(15).ToString(), "o", "79", "10001111010")
            C128_Code.Rows.Add("80", Convert.ToChar(16).ToString(), "p", "80", "10100111100")
            C128_Code.Rows.Add("81", Convert.ToChar(17).ToString(), "q", "81", "10010111100")
            C128_Code.Rows.Add("82", Convert.ToChar(18).ToString(), "r", "82", "10010011110")
            C128_Code.Rows.Add("83", Convert.ToChar(19).ToString(), "s", "83", "10111100100")
            C128_Code.Rows.Add("84", Convert.ToChar(20).ToString(), "t", "84", "10011110100")
            C128_Code.Rows.Add("85", Convert.ToChar(21).ToString(), "u", "85", "10011110010")
            C128_Code.Rows.Add("86", Convert.ToChar(22).ToString(), "v", "86", "11110100100")
            C128_Code.Rows.Add("87", Convert.ToChar(23).ToString(), "w", "87", "11110010100")
            C128_Code.Rows.Add("88", Convert.ToChar(24).ToString(), "x", "88", "11110010010")
            C128_Code.Rows.Add("89", Convert.ToChar(25).ToString(), "y", "89", "11011011110")
            C128_Code.Rows.Add("90", Convert.ToChar(26).ToString(), "z", "90", "11011110110")
            C128_Code.Rows.Add("91", Convert.ToChar(27).ToString(), "{", "91", "11110110110")
            C128_Code.Rows.Add("92", Convert.ToChar(28).ToString(), "|", "92", "10101111000")
            C128_Code.Rows.Add("93", Convert.ToChar(29).ToString(), "}", "93", "10100011110")
            C128_Code.Rows.Add("94", Convert.ToChar(30).ToString(), "~", "94", "10001011110")

            C128_Code.Rows.Add("95", Convert.ToChar(31).ToString(), Convert.ToChar(127).ToString(), "95", "10111101000")
            C128_Code.Rows.Add("96", Convert.ToChar(202).ToString(), Convert.ToChar(202).ToString(), "96", "10111100010") '/*FNC3*/
            C128_Code.Rows.Add("97", Convert.ToChar(201).ToString(), Convert.ToChar(201).ToString(), "97", "11110101000") '/*FNC2*/
            C128_Code.Rows.Add("98", "SHIFT", "SHIFT", "98", "11110100010")
            C128_Code.Rows.Add("99", "CODE_C", "CODE_C", "99", "10111011110")
            C128_Code.Rows.Add("100", "CODE_B", Convert.ToChar(203).ToString(), "CODE_B", "10111101110") '/*FNC4*/
            C128_Code.Rows.Add("101", Convert.ToChar(203).ToString(), "CODE_A", "CODE_A", "11101011110") '/*FNC4*
            C128_Code.Rows.Add("102", Convert.ToChar(200).ToString(), Convert.ToChar(200).ToString(), Convert.ToChar(200).ToString(), "11110101110") '/*FNC1*/
            C128_Code.Rows.Add("103", "START_A", "START_A", "START_A", "11010000100")
            C128_Code.Rows.Add("104", "START_B", "START_B", "START_B", "11010010000")
            C128_Code.Rows.Add("105", "START_C", "START_C", "START_C", "11010011100")
            C128_Code.Rows.Add("", "STOP", "STOP", "STOP", "11000111010")


        End Sub

        Private Function FindStartorCodeCharacter(ByVal s As String, ByRef col As Integer)
            Dim rows As List(Of DataRow) = New List(Of DataRow)

            'if two chars are numbers then START_C or CODE_C
            If s.Length > 1 And Char.IsNumber(s(0)) Then
                If Char.IsNumber(s(1)) Then
                    If Not DBNull.Value.Equals(StartCharacter) Then
                        StartCharacter = C128_Code.Select("A = 'START_C'")(0)
                        rows.Add(StartCharacter)
                    Else
                        rows.Add(C128_Code.Select("A = 'CODE_C'")(0))
                    End If
                    col = 1
                End If
            Else
                Dim AFound As Boolean = False
                Dim BFound As Boolean = False
                For Each row As DataRow In C128_Code.Rows
                    If Not AFound And s = row("A").ToString() Then
                        AFound = True
                        col = 2
                        'If Not DBNull.Value.Equals(StartCharacter) Then
                        Dim bCheck As Boolean = False
                        bCheck = StartCharacter.IsNull(0)

                        If bCheck Then
                            StartCharacter = C128_Code.Select("A = 'START_A'")(0)
                            rows.Add(StartCharacter)
                        Else
                            rows.Add(C128_Code.Select("B = 'CODE_A'")(0))
                        End If
                    ElseIf Not BFound And s = row("B").ToString() Then
                        BFound = True
                        col = 1
                        If Not DBNull.Value.Equals(StartCharacter) Then
                            StartCharacter = C128_Code.Select("B = 'START_B'")(0)
                            rows.Add(StartCharacter)
                        Else
                            rows.Add(C128_Code.Select("A = 'CODE_B'")(0))
                        End If
                    ElseIf AFound And BFound Then
                        Exit For
                    End If
                Next
            End If

            Return rows

        End Function

        Private Function CalculateCheckDigit() As String
            Dim currentStartChar As String = _FormattedData(0)
            Dim CheckSum As UInteger = 0

            For i As UInteger = 0 To _FormattedData.Count - 1
                'replace apostrophes with double apostrophes for escape chars
                Dim s As String = _FormattedData(CInt(i)).Replace("'", "''")

                'try to find value in the A column
                Dim rows As DataRow() = C128_Code.Select("A = '" & s & "'")

                'try to find value in the B column
                If rows.Length <= 0 Then
                    rows = C128_Code.Select("B = '" & s & "'")
                End If


                'try to find value in the C column
                If rows.Length <= 0 Then
                    rows = C128_Code.Select("C = '" & s & "'")
                End If

                Dim value As UInteger = UInt32.Parse(rows(0)("Value").ToString())
                Dim addition = value * (IIf(i = 0, 1, i))
                CheckSum += addition

            Next


            Dim Remainder As UInteger = CheckSum Mod 103
            Dim RetRows As DataRow() = C128_Code.Select("Value = '" & Remainder.ToString() & "'")
            Return RetRows(0)("Encoding").ToString()
        End Function


        Private Sub BreakUpDataForEncoding()
            Dim temp As String = ""
            Dim tempRawData As String = Raw_Data

            'CODE C: adds a 0 to the front of the Raw_Data if the length is not divisible by 2
            'If Raw_Data Mod 2 > 0 Then
            'tempRawData = "0" + Raw_Data
            'End If

            For Each c As Char In tempRawData
                If Char.IsNumber(c) Then
                    If temp = "" Then
                        temp += c
                    Else
                        temp += c
                        _FormattedData.Add(temp)
                        temp = ""
                    End If
                Else
                    If temp <> "" Then
                        _FormattedData.Add(temp)
                        temp = ""
                    End If
                    _FormattedData.Add(c.ToString())
                End If
            Next

            'if something is still in temp go ahead and push it onto the queue
            If temp <> "" Then
                _FormattedData.Add(temp)
                temp = ""
            End If

        End Sub

        Private Sub InsertStartandCodeCharacters()
            Dim CurrentCodeSet As DataRow
            Dim CurrentCodeString As String = ""

            For i As Integer = 0 To _FormattedData.Count
                Dim col As Integer = 0
                Dim tempStartChars As List(Of DataRow) = FindStartorCodeCharacter(_FormattedData(i), col)

                'check all the start characters and see if we need to stay with the same codeset or if a change of sets is required
                Dim sameCodeSet As Boolean = False
                For Each row As DataRow In tempStartChars
                    If row("A").ToString.EndsWith(CurrentCodeString) Or row("B").ToString().EndsWith(CurrentCodeString) Or row("C").ToString().EndsWith(CurrentCodeString) Then
                        sameCodeSet = True
                        Exit For
                    End If
                Next

                If CurrentCodeString = "" Or Not sameCodeSet Then
                    CurrentCodeSet = tempStartChars(0)

                    Dim error1 As Boolean = True
                    While (error1)
                        Dim splitChar As Char = "_"
                        CurrentCodeString = CurrentCodeSet(col).ToString().Split(splitChar)(1) 'New Char() {" '_' "}
                        error1 = False
                    End While
                    Dim j As Integer = i + 1
                    _FormattedData.Insert(i, CurrentCodeSet(col).ToString())

                End If
            Next

        End Sub

        Private Function GetEncoding() As String
            BreakUpDataForEncoding()
            InsertStartandCodeCharacters()

            Dim CheckDigit As String = CalculateCheckDigit()
            Dim Encoded_Data As String = ""

            For Each s As String In _FormattedData
                Dim s1 As String = s.Replace("'", "''")
                Dim E_Row As DataRow() = C128_Code.Select("A = '" & s1 & "'")

                If E_Row.Length <= 0 Then
                    E_Row = C128_Code.Select("B = '" & s1 + "'")

                    If E_Row.Length <= 0 Then
                        E_Row = C128_Code.Select("C = '" & s1 & "'")

                    End If
                End If

                Encoded_Data += E_Row(0)("Encoding").ToString()
                _EncodedData.Add(E_Row(0)("Encoding").ToString())
            Next

            'add the check digit
            Encoded_Data += CalculateCheckDigit()
            _EncodedData.Add(CalculateCheckDigit())

            'add the stop character
            Encoded_Data += C128_Code.Select("A = 'STOP'")(0)("Encoding").ToString()
            _EncodedData.Add(C128_Code.Select("A = 'STOP'")(0)("Encoding").ToString())

            'add the termination bars
            Encoded_Data += "11"
            _EncodedData.Add("11")

            Return Encoded_Data

        End Function

#Region "IBarcode Members"
        ReadOnly Property Encoded_Value() As String
            Get
                Return Encode_Code128()
            End Get
        End Property

#End Region

    End Class
End Namespace


