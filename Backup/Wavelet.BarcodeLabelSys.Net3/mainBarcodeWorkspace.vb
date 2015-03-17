Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Drawing.Bitmap
Imports System.Drawing.Graphics
Imports System.IO
Imports System.Xml
Imports System.Text
Imports GenCode128.GetCode128
Imports GenCode128.BarcodeLib
Imports Wavelet.BarcodeLabelSys.Net3.EMPWebService
Imports System.Runtime.InteropServices
Imports System.Drawing.Printing
Imports Wavelet.BarcodeLabelSys.Net3.RAWPrinting
Imports System.Net
Imports System.CodeDom
Imports System.CodeDom.Compiler
Imports System.Security
Imports System.Web.Services.Description
Imports System.Reflection
Imports System.Xml.Schema





Public Class mainBarcodeWorkspace
    'Declaration of Private Subroutine for TSC Printer
    Private Declare Sub openport Lib "tsclib.dll" (ByVal PrinterName As String)
    Private Declare Sub closeport Lib "tsclib.dll" ()
    Private Declare Sub sendcommand Lib "tsclib.dll" (ByVal command_Renamed As String)
    Private Declare Sub setup Lib "tsclib.dll" (ByVal LabelWidth As String, ByVal LabelHeight As String, ByVal Speed As String, ByVal Density As String, ByVal Sensor As String, ByVal Vertical As String, ByVal Offset As String)
    Private Declare Sub downloadpcx Lib "tsclib.dll" (ByVal Filename As String, ByVal ImageName As String)
    Private Declare Sub barcode Lib "tsclib.dll" (ByVal X As String, ByVal Y As String, ByVal CodeType As String, ByVal Height_Renamed As String, ByVal Readable As String, ByVal rotation As String, ByVal Narrow As String, ByVal Wide As String, ByVal Code As String)
    Private Declare Sub printerfont Lib "tsclib.dll" (ByVal X As String, ByVal Y As String, ByVal FontName As String, ByVal rotation As String, ByVal Xmul As String, ByVal Ymul As String, ByVal Content As String)
    Private Declare Sub clearbuffer Lib "tsclib.dll" ()
    Private Declare Sub printlabel Lib "tsclib.dll" (ByVal NumberOfSet As String, ByVal NumberOfCopy As String)
    Private Declare Sub formfeed Lib "tsclib.dll" ()
    Private Declare Sub nobackfeed Lib "tsclib.dll" ()
    Private Declare Sub windowsfont Lib "tsclib.dll" (ByVal X As Short, ByVal Y As Short, ByVal fontheight_Renamed As Short, ByVal rotation As Short, ByVal fontstyle As Short, ByVal fontunderline As Short, ByVal FaceName As String, ByVal TextContent As String)

    'Declaration of Private Subroutine for Argos Printer - Printer Programming Language B
    Private Declare Function B_CreatePrn Lib "WINPPLB.DLL" (ByVal selection As Integer, ByVal filename As String) As Integer
    Private Declare Sub B_ClosePrn Lib "WINPPLB.DLL" ()
    Private Declare Function B_Print_Out Lib "WINPPLB.DLL" (ByVal labset As Integer) As Integer
    Private Declare Function B_Print_MCopy Lib "WINPPLB.DLL" (ByVal labset As Integer, ByVal copies As Integer) As Integer
    Private Declare Function B_Bar2d_Maxi Lib "WINPPLB.DLL" (ByVal x As Integer, ByVal y As Integer, ByVal cl As Integer, ByVal cc As Integer, ByVal pc As Integer, ByVal data As String) As Integer
    Private Declare Function B_Bar2d_PDF417 Lib "WINPPLB.DLL" (ByVal x As Integer, ByVal y As Integer, ByVal w As Integer, ByVal v As Integer, ByVal s As Integer, ByVal c As Integer, ByVal px As Integer, ByVal py As Integer, ByVal r As Integer, ByVal l As Integer, ByVal t As Integer, ByVal o As Integer, ByVal data As String) As Integer
    Private Declare Function B_Bar2d_PDF417_N Lib "WINPPLB.DLL" (ByVal x As Integer, ByVal y As Integer, ByVal w As Integer, ByVal h As Integer, ByVal Para As String, ByVal data As String) As Integer
    'UPGRADE_NOTE: height was upgraded to height_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
    'UPGRADE_NOTE: width was upgraded to width_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
    Private Declare Function B_Prn_Barcode Lib "WINPPLB.DLL" (ByVal x As Integer, ByVal y As Integer, ByVal ori As Integer, ByVal TType As String, ByVal narrow As Integer, ByVal width_Renamed As Integer, ByVal height_Renamed As Integer, ByVal human As Byte, ByVal data As String) As Integer
    'UPGRADE_NOTE: font was upgraded to font_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
    Private Declare Function B_Prn_Text Lib "WINPPLB.DLL" (ByVal x As Integer, ByVal y As Integer, ByVal ori As Integer, ByVal font_Renamed As Integer, ByVal hor_factor As Integer, ByVal ver_factor As Integer, ByVal mode As Byte, ByVal data As String) As Integer
    Private Declare Function B_Open_ChineseFont Lib "WINPPLB.DLL" (ByVal path As String) As Integer
    Private Declare Function B_Prn_Text_Chinese Lib "WINPPLB.DLL" (ByVal x As Integer, ByVal y As Integer, ByVal fonttype As Integer, ByVal id_name As String, ByVal data As String) As Integer
    Private Declare Function B_Prn_Text_TrueType Lib "WINPPLB.DLL" (ByVal x As Integer, ByVal y As Integer, ByVal FSize As Integer, ByVal FType As String, ByVal Fspin As Integer, ByVal FWeight As Integer, ByVal FItalic As Integer, ByVal FUnline As Integer, ByVal FStrikeOut As Integer, ByVal id_name As String, ByVal data As String) As Integer
    Private Declare Function B_Prn_Text_TrueType_W Lib "WINPPLB.DLL" (ByVal x As Integer, ByVal y As Integer, ByVal FHeight As Integer, ByVal FWidth As Integer, ByVal FType As String, ByVal Fspin As Integer, ByVal FWeight As Integer, ByVal FItalic As Integer, ByVal FUnline As Integer, ByVal FStrikeOut As Integer, ByVal id_name As String, ByVal data As String) As Integer
    Private Declare Function B_Draw_Box Lib "WINPPLB.DLL" (ByVal x As Integer, ByVal y As Integer, ByVal thickness As Integer, ByVal hor_dots As Integer, ByVal ver_dots As Integer) As Integer
    Private Declare Function B_Draw_Line Lib "WINPPLB.DLL" (ByVal mode As Byte, ByVal x As Integer, ByVal y As Integer, ByVal hor_dots As Integer, ByVal ver_dots As Integer) As Integer
    Private Declare Function B_Get_Pcx Lib "WINPPLB.DLL" (ByVal x As Integer, ByVal y As Integer, ByVal filename As String) As Integer
    Private Declare Function B_Get_Graphic_ColorBMP Lib "WINPPLB.DLL" (ByVal x As Integer, ByVal y As Integer, ByVal filename As String) As Integer
    Private Declare Function B_Load_Pcx Lib "WINPPLB.DLL" (ByVal x As Integer, ByVal y As Integer, ByVal pcxname As String) As Integer
    Private Declare Function B_Del_Pcx Lib "WINPPLB.DLL" (ByVal pcxname As String) As Integer
    Private Declare Function B_Set_Backfeed Lib "WINPPLB.DLL" (ByVal options As Byte) As Integer
    Private Declare Function B_Set_BMPSave Lib "WINPPLB.DLL" (ByVal nSave As Integer, ByVal pstrBMPFName As String) As Integer
    Private Declare Function B_Set_Darkness Lib "WINPPLB.DLL" (ByVal darkness As Integer) As Integer
    Private Declare Function B_Error_Reporting Lib "WINPPLB.DLL" (ByVal options As Byte) As Integer
    Private Declare Function B_Set_DebugDialog Lib "WINPPLB.DLL" (ByVal nEnable As Integer) As Integer
    Private Declare Function B_Set_Form Lib "WINPPLB.DLL" (ByVal formfile As String) As Integer
    Private Declare Function B_Print_Form Lib "WINPPLB.DLL" (ByVal labset As Integer, ByVal copies As Integer, ByVal form_out As String, ByVal var As String) As Integer
    Private Declare Function B_Del_Form Lib "WINPPLB.DLL" (ByVal formname As String) As Integer
    Private Declare Function B_Set_Prncomport Lib "WINPPLB.DLL" (ByVal baud As Integer, ByVal parity As Byte, ByVal data As Integer, ByVal stopp As Integer) As Integer
    Private Declare Function B_Set_Prncomport_PC Lib "WINPPLB.DLL" (ByVal nBaudRate As Integer, ByVal nByteSize As Integer, ByVal nParity As Integer, ByVal nStopBits As Integer, ByVal nDsr As Integer, ByVal nCts As Integer, ByVal nXonXoff As Integer) As Integer
    Private Declare Function B_Set_Speed Lib "WINPPLB.DLL" (ByVal speed As Integer) As Integer
    'UPGRADE_NOTE: object was upgraded to object_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
    Private Declare Function B_Select_Option Lib "WINPPLB.DLL" (ByVal object_Renamed As Integer) As Integer
    'UPGRADE_NOTE: object was upgraded to object_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
    Private Declare Function B_Select_Option2 Lib "WINPPLB.DLL" (ByVal object_Renamed As Integer, ByVal p As Integer) As Integer
    Private Declare Function B_Select_Symbol Lib "WINPPLB.DLL" (ByVal num_bit As Integer, ByVal symbol As Integer, ByVal country As Integer) As Integer
    Private Declare Function B_Select_Symbol2 Lib "WINPPLB.DLL" (ByVal num_bit As Integer, ByVal symbol As String, ByVal country As Integer) As Integer
    Private Declare Function B_Set_Labgap Lib "WINPPLB.DLL" (ByVal lablength As Integer, ByVal gaplength As Integer) As Integer
    Private Declare Function B_Set_Labwidth Lib "WINPPLB.DLL" (ByVal labwidth As Integer) As Integer
    Private Declare Function B_Set_Originpoint Lib "WINPPLB.DLL" (ByVal hor As Integer, ByVal ver As Integer) As Integer
    Private Declare Function B_Set_ProcessDlg Lib "WINPPLB.DLL" (ByVal speed As Integer) As Integer
    Private Declare Function B_Set_Direction Lib "WINPPLB.DLL" (ByVal direction As Byte) As Integer
    Private Declare Function B_Get_DLL_Version Lib "WINPPLB.DLL" (ByVal nShowMessage As Integer) As String
    Private Declare Function B_Get_DLL_VersionA Lib "WINPPLB.DLL" (ByVal nShowMessage As Integer) As Integer
    Private Declare Function B_Initial_Setting Lib "WINPPLB.DLL" (ByVal TType As Integer, ByVal Source As String) As Integer
    Private Declare Sub B_Prn_Configuration Lib "WINPPLB.DLL" ()
    Private Declare Function B_GetUSBBufferLen Lib "WINPPLB.DLL" () As Integer
    Private Declare Function B_EnumUSB Lib "WINPPLB.DLL" (ByVal buf As String) As Integer
    Private Declare Function B_CreateUSBPort Lib "WINPPLB.DLL" (ByVal nPort As Integer) As Integer
    Private Declare Function B_Set_ErrorReport Lib "WINPPLB.DLL" (ByVal nEnable As Integer) As Integer
    Private Declare Function B_ResetPrinter Lib "WINPPLB.DLL" () As Integer
    Private Declare Function B_GetPrinterResponse Lib "WINPPLB.DLL" (ByVal buf As String, ByVal nMax As Integer) As Integer
    Private Declare Function B_TFeedMode Lib "WINPPLB.DLL" (ByVal nMode As Integer) As Integer
    Private Declare Function B_TFeedTest Lib "WINPPLB.DLL" () As Integer
    Private Declare Function B_CreatePort Lib "WINPPLB.DLL" (ByVal nPortType As Integer, ByVal nPort As Integer, ByVal filename As String) As Integer
    Private Declare Function B_Execute_Form Lib "WINPPLB.DLL" (ByVal form_out As String, ByVal var As String) As Integer




    Private _encoding As Hashtable = New Hashtable
    Private Const _wideBarWidth As Short = 2
    Private Const _narrowBarWidth As Short = 1
    Private Const _barHeight As Short = 92 '31
    Private Const _barWidth As Short = 132
    Private Const _LabelHeight As Short = 360 '180 ' with 2" barcode label
    Private Const _LabelWidth As Short = 360 '225 'with 2.5 barcode label width
    Private Const _BarcodeXScale As Single = 0.8 ' scale from 0.8 to 2.0
    Public _BarcodeYScale As Single = 0.2 '0.25 ,,,0.3 = Banzen 
    Private Const _BarcodePageWidth As Short = 360 'with 4" square label based on 90dpi
    Private Const _BarcodePageHeight As Short = 360
    Dim Customer As Short = 0
    Dim btnSelectedClicked As Boolean = False
    Dim PrintMode As Short = 0
    'Label Setup
    Dim LSWidth As String = "35"
    Dim LSHeight As String = "25"
    Dim LSVerticalgap As String = "3.048"
    Dim LSPrintSpeed As String = "1.5"
    Dim LSPrintDensity As String = "1"
    'Barcode Setup
    Dim BarcodeXScale As Single
    Dim BarcodeYScale As Single

    Dim BSBarcodeType As String = "EAN128"
    Dim BSBarHeight As Single = "36.54"
    Dim BSNarrowBarRatio As String = "2"
    Dim BSWideBarRatio As String = "2"
    Dim BSEnableDoubleFormat As String = "TRUE"
    Dim UseItemCode2PrintBarcode As String = "FALSE"

    'Template setup
    Dim CompanyNameLine1 As String = "JAYACOM INFORMATION" '"ALL IT HYPERMARKET" 
    Dim CompanyNameLine2 As String = "SDN. BHD."
    Dim CompanyNameFontType As String = "2"
    Dim CompanyNameFontSize As String = "14"
    Dim CompanyLogoFilename As String = "LOGO.PCX"
    Dim ItemCodeFontSize As Integer = 7
    Dim ItemCodeFontType As String = "Arial"

    Dim ItemNameTextAlign As String = "CENTER"
    Dim ItemNameFontType As String = "1"
    Dim ItemNameFontSize As Integer = 7

    Dim ItemNameMaxLengthperLine As Integer = 26
    Dim BarcodeTextFontType As String = "2"
    Dim XPosOffsetBarcodeItemName As Integer = 0
    Dim XPosOffsetBarcodeDoubleFormat As Integer = 0

    Dim ItemPriceFontType As String = "3"
    Dim ItemPriceFontSize As Integer = 7

    'Printer Setting
    Dim PrinterName As String = "TSC TTP-243(E) - (V)"
    Dim PrinterProgrammingLanguage As String = "TSC"

    'URL Setting
    Dim URLFontType As String = "Arial"
    Dim URLFontSize As Integer = 6
    Dim URLText As String = "www.thundermatch.com.my"

    'Lable  Pos
    Dim LabelYStartPos As Integer = 4
    Dim YPosOffsetItemPrice As Integer = 32
    Dim ItemNameMaxRowLine As Integer = 4
    Dim XPosOffsetBarcodeText As Integer = 0
    Dim XPosOffsetItemPrice As Integer = 0

    Dim YPosGap As Integer = 25

    Dim CoreClient As EMPCoreClient = New EMPCoreClient


    'Define page counters
    Public totalPages As Integer = 1
    Public curPage As Integer = 0

    'Define the main barcode canvas used
    Dim barcodeCanvas As Bitmap

    'Declare the printing object (used later for sending the barcode canvas to printer
    Private WithEvents m_PrintDocument As Printing.PrintDocument
    'Create a new box scan form

    'Define web service
    Dim WebServicesAddress As String
    Dim service As Type
    Dim methodInfos As MethodInfo()
    Dim param As ParameterInfo()
    Dim myProperty As properties
    Dim MethodName As String = ""



#Region "Barcode Code39 Generation System"
    'This adds keys to the encoding hashtable, which tells exactly what we need to draw later in GDI
    'But more or less, these are the encoding bits for each of the Code allowable characters
    'Code 39 - barcode format supports only capital letters, numbers and seven other special chars (43 chars total).
    'Each letter is encoded with nine alternating black and white bars, always starting and ending with black.
    'Three of the nine bars will be wide, and the rest narrow (so, the name sometimes called 3 of 9).
    'Between each letter is a narrow white bar, and there is a start and stop code so that you know that you are looking at a Code 39
    'Calcuate the size in pixels before encoding, since each letter is the same size (3 wide and 6 narrow)
    Sub Wavelet_BarcodeC39()
        _encoding.Add("*", "bWbwBwBwb")
        _encoding.Add("-", "bWbwbwBwB")
        _encoding.Add("$", "bWbWbWbwb")
        _encoding.Add("%", "bwbWbWbWb")
        _encoding.Add(" ", "bWBwbwBwb")
        _encoding.Add(".", "BWbwbwBwb")
        _encoding.Add("/", "bWbWbwbWb")
        _encoding.Add("+", "bWbwbWbWb")
        _encoding.Add("0", "bwbWBwBwb")
        _encoding.Add("1", "BwbWbwbwB")
        _encoding.Add("2", "bwBWbwbwB")
        _encoding.Add("3", "BwBWbwbwb")
        _encoding.Add("4", "bwbWBwbwB")
        _encoding.Add("5", "BwbWBwbwb")
        _encoding.Add("6", "bwBWBwbwb")
        _encoding.Add("7", "bwbWbwBwB")
        _encoding.Add("8", "BwbWbwBwb")
        _encoding.Add("9", "bwBWbwBwb")
        _encoding.Add("A", "BwbwbWbwB")
        _encoding.Add("B", "bwBwbWbwB")
        _encoding.Add("C", "BwBwbWbwb")
        _encoding.Add("D", "bwbwBWbwB")
        _encoding.Add("E", "BwbwBWbwb")
        _encoding.Add("F", "bwBwBWbwb")
        _encoding.Add("G", "bwbwbWBwB")
        _encoding.Add("H", "BwbwbWBwb")
        _encoding.Add("I", "bwBwbWBwb")
        _encoding.Add("J", "bwbwBWBwb")
        _encoding.Add("K", "BwbwbwbWB")
        _encoding.Add("L", "bwBwbwbWB")
        _encoding.Add("M", "BwBwbwbWb")
        _encoding.Add("N", "bwbwBwbWB")
        _encoding.Add("O", "BwbwBwbWb")
        _encoding.Add("P", "bwBwBwbWb")
        _encoding.Add("Q", "bwbwbwBWB")
        _encoding.Add("R", "BwbwbwBWb")
        _encoding.Add("S", "bwBwbwBWb")
        _encoding.Add("T", "bwbwBwBWb")
        _encoding.Add("U", "BWbwbwbwB")
        _encoding.Add("V", "bWBwbwbwB")
        _encoding.Add("W", "BWBwbwbwb")
        _encoding.Add("X", "bWbwBwbwB")
        _encoding.Add("Y", "BWbwBwbwb")
        _encoding.Add("Z", "bWBwBwbwb")
    End Sub

    'This returns a color associated with the current line drawing in GDI, since it's a barcode we primarily want a contrasting 
    'color and a light background color, so depending on what the character is (whether it's a char or white space) we add color
    Protected Function getBCSymbolColor(ByVal symbol As String) As System.Drawing.Brush
        getBCSymbolColor = Brushes.Black
        If symbol = "W" Or symbol = "w" Then

            getBCSymbolColor = Brushes.White
        End If
    End Function

    'Now we determine whether or not we are going to be drawing a small or large BC bar on this character code
    Protected Function getBCSymbolWidth(ByVal symbol As String) As Short
        getBCSymbolWidth = _narrowBarWidth
        If symbol = "B" Or symbol = "W" Then
            getBCSymbolWidth = _wideBarWidth
        End If
    End Function

    'This function is called to generate the actual barcode
    Protected Overridable Function GenerateBarcodeImage(ByVal imageWidth As Short, ByVal imageHeight As Short, ByVal Code As String, ByVal ItemName As String, ByVal ItemPrice As String, ByVal ItemCode As String) As IO.MemoryStream
        'Declare a new bitmap canvas to store our new barcode
        Dim b As New Bitmap(imageWidth, imageHeight, Imaging.PixelFormat.Format32bppArgb)

        'Create our graphic object from our barcode canvas 
        Dim canvas As New Rectangle(0, 0, imageWidth, imageHeight)

        'Create our graphics object from our barcode canvas
        Dim g As Graphics = Graphics.FromImage(b)

        g.PageUnit = GraphicsUnit.Pixel
        g.PageScale = 1
        'Fill the drawing with white barkground
        g.FillRectangle(Brushes.White, 0, 0, imageWidth, imageHeight)

        Dim BarcodeWidth As Integer = _barWidth * _BarcodeXScale
        Dim BarcodeHeight As Integer = _barHeight * _BarcodeYScale

        'Define a starting X and Y position for the barcode
        Dim XPosition As Short = 1 + 5
        Dim YPosition As Short = 0

        'We are using SingleBitPerPixel because when printed it appears sharper as opposed to anti-aliased
        g.TextRenderingHint = Drawing.Text.TextRenderingHint.SystemDefault ' .SingleBitPerPixel
        g.SmoothingMode = Drawing2D.SmoothingMode.Default ' .HighQuality
        g.InterpolationMode = Drawing2D.InterpolationMode.Default ' .HighQualityBicubic
        g.CompositingQuality = Drawing2D.CompositingQuality.Default ' HighQuality

        'Write out the original barcode ID '  Arial
        Dim FontSize As Single = 12 * _BarcodeYScale
        If FontSize < 12 Then
            FontSize = 12
        End If

        Dim CompanyNameLine1 As String = "BZ TOP AUTOMOBILE "
        Dim CompanyNameLine2 As String = "SERVICES"

        Dim fontname As String
        fontname = "Arial" '"Tahoma" '"Crystal"  '"Butter" '"Targa MS" '"Arial"
        g.DrawString(CompanyNameLine1, New Font(fontname, FontSize, FontStyle.Bold), New SolidBrush(Color.Black), XPosition, YPosition)
        YPosition = YPosition + FontSize + 3
        g.DrawString(CompanyNameLine2, New Font(fontname, FontSize, FontStyle.Bold), New SolidBrush(Color.Black), XPosition + 50, YPosition)

        YPosition = YPosition + FontSize + 5
        'Code has to be surrounded by asterisk to make it a valid C39 barcode, so add "*" to the front and end of the barcode
        Dim UseCode As String = String.Format("{0}{1}{0}", "*", ItemCode)

        'Now that we are going to draw the barcode lines -- which needs to be very straight, and not blended
        'Else it may blur and cause complications with barcode reading device 
        '1st set
        g.TextRenderingHint = Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit ' SystemDefault
        g.SmoothingMode = Drawing2D.SmoothingMode.None
        g.InterpolationMode = Drawing2D.InterpolationMode.High  'NearestNeighbor
        g.CompositingQuality = Drawing2D.CompositingQuality.Default

        'Initialize our IC marker, and giva a default of false
        'Incorrectly assigned characters for the barcode (ones that won't match C39 standards)
        Dim invalidCharacter As Boolean = False

        'Declare our current character string holding variable 
        Dim CurrentSymbol As String = String.Empty

        'This part is *ONLY* for calculating the width of the barcode to center it!
        'Begin at the starting area of our FINAL rendered barcode value
        'For j As Short = 0 To CShort(UseCode.Length - 1)
        'Set our current character to the character space of the barcode
        'CurrentSymbol = UseCode.Substring(j, 1)

        'Check to ensure that it's a vlid character per our encoding hashtable we defined earlier
        'If Not IsNothing(_encoding(CurrentSymbol)) Then
        'Create a new rendered version of the character per our hashtable with valid values (don't read it, ti will be encoded -- look above at the HT)
        'Dim EncodedSymbol As String = _encoding(CurrentSymbol).ToString

        'Progress throughout the entire encoding value of this character
        'For i As Short = 0 To CShort(EncodedSymbol.Length - 1)
        'Extract the current encoded character value from the complete rendering of this character
        'Dim CurrentCode As String = EncodedSymbol.Substring(i, 1)

        'Change our coordinates for drawing to match the next position (current position plus the char. bar width)
        'XPosition = XPosition + getBCSymbolWidth(CurrentCode)
        'Next

        'Now we need to "create" a whitespace as needed, and get the width
        'XPosition = XPosition + getBCSymbolWidth("w")
        'End If
        'Next

        'Now the nice trick of the division helps with centering the barcode on the canvas
        'XPosition = (imageWidth / 2) - (XPosition / 2)

        'Dim dlineWidthScaleFactor As Short = imageWidth / ((UseCode.Length + 2) * 12)
        Dim lineWidthScaleFactor As Integer = 1 'BarcodeWidth / ((UseCode.Length + 2) * 12)
        If lineWidthScaleFactor = 0 Then
            lineWidthScaleFactor = 1
        End If
        'This is where we actually draw the barcode bars
        'Begin at the starting area of our FINAL rendered barcode value
        For j As Short = 0 To CShort(UseCode.Length - 1)
            'Set our current character to the character space of the barcode
            CurrentSymbol = UseCode.Substring(j, 1)

            'Check to ensure that it's a valid character per our encoding hasttable we defined earlier
            If Not IsNothing(_encoding(CurrentSymbol)) Then
                'Create a new rendered version of the character per our hasttable with valid values
                Dim EncodedSymbol As String = _encoding(CurrentSymbol).ToString

                'Progress throughout the entire encoding value of this character 
                For i As Short = 0 To CShort(EncodedSymbol.Length - 1)
                    Dim CurrentCode As String = EncodedSymbol.Substring(i, 1)

                    'Use our drawing graphics object on the canvas to create a bar with our position and values based o the current character encoding value
                    g.FillRectangle(getBCSymbolColor(CurrentCode), XPosition, YPosition, getBCSymbolWidth(CurrentCode) * lineWidthScaleFactor, BarcodeHeight)
                    'Lets disect this a little to see how it actually works, want to?
                    '   getBCSymbolColor(CurrentCode)
                    '       We already know, but this gets the color of the bar, either white or colorized (in this case, black)
                    '   XPosition, YPosition
                    '       Again, we already know -- but this is the coordinates to draw the bar based on previous locations
                    '   getBCSymbolWidth(CurrentCode)
                    '       This is the important part, we get the correct width (either narrow or wide) for this character (post encoding)
                    '   _barHeight
                    '       This is static as defined earlier, it doesn't much matter but it also depends on your Barcode reader

                    'Change our coordinates for drawing to match the next position (current position plus the char. bar width)
                    XPosition = XPosition + (getBCSymbolWidth(CurrentCode) * lineWidthScaleFactor)
                Next

                'Now we need to "ACTUALLY" create a whitespace as needed, and get the width
                g.FillRectangle(getBCSymbolColor("w"), XPosition, YPosition, getBCSymbolWidth("w") * lineWidthScaleFactor, BarcodeHeight)

                'Change our coordinates for drawing to match the next position (current position plus char. bar width)
                XPosition = XPosition + (getBCSymbolWidth("w") * lineWidthScaleFactor)
            Else
                'This is our fallback, if it is not a valid character per our HT in C39
                invalidCharacter = True
            End If
        Next


        'Test another set of barcode label rendering parameters '2nd set
        'XPosition = 1 + 5
        'YPosition = BarcodeHeight + BarcodeHeight + BarcodeHeight

        'g.TextRenderingHint = Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit ' SystemDefault
        'g.SmoothingMode = Drawing2D.SmoothingMode.None
        'g.InterpolationMode = Drawing2D.InterpolationMode.High  'NearestNeighbor
        'g.CompositingQuality = Drawing2D.CompositingQuality.Default
        'CurrentSymbol = String.Empty

        'lineWidthScaleFactor = 1
        'For j As Short = 0 To CShort(UseCode.Length - 1)
        'CurrentSymbol = UseCode.Substring(j, 1)

        'If Not IsNothing(_encoding(CurrentSymbol)) Then
        'Dim EncodedSymbol As String = _encoding(CurrentSymbol).ToString

        'For i As Short = 0 To CShort(EncodedSymbol.Length - 1)
        'Dim CurrentCode As String = EncodedSymbol.Substring(i, 1)

        'g.FillRectangle(getBCSymbolColor(CurrentCode), XPosition, YPosition, getBCSymbolWidth(CurrentCode) * lineWidthScaleFactor, BarcodeHeight)
        'XPosition = XPosition + (getBCSymbolWidth(CurrentCode) * lineWidthScaleFactor)
        'Next

        'g.FillRectangle(getBCSymbolColor("w"), XPosition, YPosition, getBCSymbolWidth("w") * lineWidthScaleFactor, BarcodeHeight)

        'XPosition = XPosition + (getBCSymbolWidth("w") * lineWidthScaleFactor)
        'Else
        'invalidCharacter = True
        'End If
        'Next


        g.TextRenderingHint = Drawing.Text.TextRenderingHint.SystemDefault ' .SingleBitPerPixel
        g.SmoothingMode = Drawing2D.SmoothingMode.Default ' .HighQuality
        g.InterpolationMode = Drawing2D.InterpolationMode.Default ' .HighQualityBicubic
        g.CompositingQuality = Drawing2D.CompositingQuality.Default ' HighQuality
        XPosition = 1
        YPosition = YPosition + BarcodeHeight + 1
        g.DrawString(ItemCode, New Font(fontname, FontSize, FontStyle.Bold), New SolidBrush(Color.Black), XPosition + 35, YPosition)

        YPosition = YPosition + FontSize + 3

        Dim StrLength As Integer
        Dim StrNameLine1 As String
        Dim StrNameLine2 As String
        Dim StrNameLine3 As String
        Dim xPosExt As Integer = 0

        xPosExt = (BarcodeWidth / 2) - ((ItemPrice.Length() * FontSize) / 2) + 50
        StrLength = ItemName.Length()
        'If StrLength > 18 And StrLength < 35 Then
        'StrNameLine1 = ItemName.Substring(0, 22) '0, 18)
        'StrNameLine2 = ItemName.Substring(22, StrLength - 22) '18, StrLength - 18)
        'g.DrawString(StrNameLine1, New Font(fontname, FontSize, FontStyle.Regular), New SolidBrush(Color.Black), XPosition, YPosition)
        'YPosition = YPosition + FontSize + 3
        'g.DrawString(StrNameLine2, New Font(fontname, FontSize, FontStyle.Regular), New SolidBrush(Color.Black), XPosition, YPosition)

        'YPosition = YPosition + FontSize + 3

        'g.DrawString(ItemPrice, New Font(fontname, FontSize + 1, FontStyle.Bold), New SolidBrush(Color.Black), XPosition + xPosExt, YPosition)

        'ElseIf StrLength > 34 Then
        'StrNameLine1 = ItemName.Substring(0, 22) '0, 18)
        'If (StrLength - 22) < 22 Then
        'StrNameLine2 = ItemName.Substring(22, StrLength - 22) '18, 18)
        'Else
        'StrNameLine2 = ItemName.Substring(22, 22)
        'End If
        'g.DrawString(StrNameLine1, New Font(fontname, FontSize, FontStyle.Regular), New SolidBrush(Color.Black), XPosition, YPosition)
        'YPosition = YPosition + FontSize + 3
        'g.DrawString(StrNameLine2, New Font(fontname, FontSize, FontStyle.Regular), New SolidBrush(Color.Black), XPosition, YPosition)

        'YPosition = YPosition + FontSize + 2
        'g.DrawString(ItemPrice, New Font(fontname, FontSize, FontStyle.Bold), New SolidBrush(Color.Black), XPosition + xPosExt, YPosition)

        'Else

        g.DrawString(ItemName, New Font(fontname, FontSize, FontStyle.Regular), New SolidBrush(Color.Black), XPosition, YPosition)
        YPosition = YPosition + FontSize + 3
        g.DrawString(ItemPrice, New Font(fontname, FontSize, FontStyle.Bold), New SolidBrush(Color.Black), XPosition + xPosExt, YPosition)
        'End If



        'As we set it above (if needed) for an invalid character (not allowed by the C39 guide), then we handle it here
        If invalidCharacter Then
            'Just fill the whole canvas white
            g.FillRectangle(Brushes.White, 0, 0, imageWidth, imageHeight)

            'tell them !
            g.DrawString("Invalid Characters Detected", New Font("Tahoma", 8), New SolidBrush(Color.Red), 0, 0)
            g.DrawString("- Barcode Not Generated -", New Font("Tahoma", 8), New SolidBrush(Color.Black), 0, 10)
            g.DrawString(Code, New Font("Tahoma", 8, FontStyle.Italic), New SolidBrush(Color.Black), 0, 30)
        End If

        'Create a new memorystream to use with our function return
        Dim ms As New IO.MemoryStream

        'Setup the encoding quality of the final barcode rendered image
        Dim encodingParams As New EncoderParameters
        encodingParams.Param(0) = New EncoderParameter(Imaging.Encoder.Quality, 100)

        'During the encoding details of "how" for the image
        'We will use PNG because it's got the best image quality for it's footprint
        Dim encodingInfo As ImageCodecInfo = FindCodecInfo("PNG")

        'Save the drawing directly into the stream
        b.Save(ms, encodingInfo, encodingParams)

        g.Dispose()
        b.Dispose()

        'Finally, return the image via the memorystream
        Return ms
    End Function

    'Find the encoding method in the codec list on the computer based on the known-name (PNG, JPEG, etc)
    Protected Overridable Function FindCodecInfo(ByVal codec As String) As ImageCodecInfo
        Dim encoders As ImageCodecInfo() = ImageCodecInfo.GetImageEncoders
        For Each e As ImageCodecInfo In encoders
            If e.FormatDescription.Equals(codec) Then Return e
        Next
        Return Nothing
    End Function

#End Region


#Region "Printing Methods (Physical Printing and On-Screen Printing)"
    'Physical Printing
    'This is basically sends the current barcode renderings to the printer under the printer options
    Public Sub doPrintActive()
        m_PrintDocument = New Printing.PrintDocument
        m_PrintDocument.PrinterSettings = PrintDialog1.PrinterSettings
        m_PrintDocument.DefaultPageSettings.Color = False
        m_PrintDocument.DefaultPageSettings.Margins = New System.Drawing.Printing.Margins(2.5, 2.5, 2.5, 2.5)
        m_PrintDocument.Print()
    End Sub

    Private Sub m_PrintDocument_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles m_PrintDocument.PrintPage
        Dim x As Integer = e.MarginBounds.X
        Dim y As Integer = e.MarginBounds.Y
        e.Graphics.DrawImage(barcodeCanvas, x, y)
        e.HasMorePages = False
    End Sub

    'Logical/On-Screen Printing
    'This is extended method that generate the strbarcode and display them, or print them
    Public Sub doPrintNow(ByVal strbarcode As String, ByVal ItemName As String, ByVal ItemPrice As String, ByVal ItemCode As String)
        'Set our current page counter and determine the total pages to be printed 
        curPage = 0

        totalPages = 1

        'Declare the current strbarcode holding variable and the current strbarcode render object
        Dim thisBarCode As Bitmap

        'Define a new strbarcode canvas drawing object with a 8.5" x 11" A4 paper
        'barcodeCanvas = New Bitmap(1275, 1650)
        'barcodeCanvas = New Bitmap(766, 960)
        barcodeCanvas = New Bitmap(_BarcodePageWidth, _BarcodePageHeight) ' with 4" square label

        'Create our trusty graphics object for this canvas
        Dim dc As Graphics = Graphics.FromImage(barcodeCanvas)

        'Make it white - the background of the canvas
        dc.Clear(Color.White)

        'Declare our placeholders for coordinates used on drawing the strbarcode object
        Dim pgX As Integer = 0
        Dim pgXc As Integer = 0

        Dim pgY As Integer = 0

        'Declare our counter so we can apply various actions at different levels
        Dim newColCounter As Integer = 1

        Dim bBoxLabel As Boolean = True

        If bBoxLabel = True Then
            'It is a document label
            dc.Clear(Color.White)
            'dc.DrawString("Generation Cancelled!    Generation Cancelled!    Generation Cancelled!    Generation Cancelled!    Generation Cancelled!    Generation Cancelled!", New Font("Tahoma", 20, FontStyle.Bold), New SolidBrush(Color.LightPink), 5, 10)

            PictureBox1.Image = barcodeCanvas
            'Exit Sub
            'Application.DoEvents()


            'Define a variable to hold our box number, and our page number
            Dim bid As String = "0"
            Dim pid As String = "0"


            'Set the strbarcode "code" with what we created
            'strbarcode = bid & "-" & pid

            'Request that the strbarcode be rendered and exported via memorystream into our new strbarcode holder
            'thisBarCode = New Bitmap(GenerateBarcodeImage(169, 48, strbarcode))

            Select Case Customer
                Case 0 'Banzen
                    thisBarCode = New Bitmap(GenerateBarcodeImage(_LabelWidth, _LabelHeight, strbarcode, ItemName, ItemPrice, ItemCode))
                Case 1 ' Jayacom
                    'thisBarCode = New Bitmap(GenerateBarcodeImageForC128(_LabelWidth, _LabelHeight, strbarcode))
                    thisBarCode = New Bitmap(GenerateBarcodeImageForC128_v2(_LabelWidth, _LabelHeight, strbarcode, ItemName, ItemPrice))
                Case Else
                    thisBarCode = New Bitmap(GenerateBarcodeImage(_LabelWidth, _LabelHeight, strbarcode, ItemName, ItemPrice, ItemCode))
                    Exit Select
            End Select

            'Draw the strbarcode onto the strbarcode printing page canvas
            dc.DrawImage(thisBarCode, New PointF(pgX, pgY))

 
        End If

    End Sub


    Public Sub doTSCPrintDirect(ByVal strbarcode As String, ByVal ItemName As String, ByVal ItemPrice As String, ByVal ItemQuality As String, ByVal ItemCode As String, _
                                ByVal PriceCheckedBy As String, ByVal Barcode1 As String, ByVal Barcode2 As String, _
                                ByVal Barcode3 As String, ByVal Barcode4 As String, ByVal Barcode5 As String)


        '203dpi => 1mm = 8dots
        'Call openport(PrintDialog1.PrinterSettings.PrinterName) '"TSC TTP-243(E) - (V)")
        Call openport(PrinterName)
        '35mm = 1.4" 25mm = 0.9", print speed = 2.0"/sec, print density = 15,
        'sensor type = 0 = vertical gap sensor, vertical gap height = 0.12" = 3.048, shift dist = 0mm
        Call setup(LSWidth, LSHeight, LSPrintSpeed, LSPrintDensity, "0", LSVerticalgap, "0")
        'Call setup("0", "100", "3", "10", "0", "0", "0")
        Call clearbuffer()
        Call sendcommand("DIRECTION 0")
        'Call sendcommand("SET CUTTER OFF") ' Or the number of printout per cut'
        'Call sendcommand("FORMFEED") '"HOME") 'This will jump over one empty label

        'Print a barcode'
        Dim CodeType As String = BSBarcodeType
        Dim TSCBarHeight As Single = BSBarHeight ' 36.54pt = 0.18"
        Dim TSCHumanRead As String = "0"
        Dim TSCRotation As String = "0"
        Dim TSCNarrowBar As String = "2"
        Dim TSCBuildinFont1 As String = "1"  '8 x 12 dots
        Dim TSCBuildinFont2 As String = "2"  '12 x 20 dots
        Dim TSCBuildinFont3 As String = "3"  '16 x 24 dots
        Dim TSCBuildinFont4 As String = "4"  '24 x 32 dots
        Dim TSCBuildinFont5 As String = "5" '32 x 48 dots
        Dim TSCFontMag As String = "1"

        Dim ptLabelWidth As Integer = 26 * 8 '35 * 8 - suppose 35mm * 8dot = 280, but font1 support 26 char, 26 * 8dot =208
        Dim ptLabelHeight As Integer = 25 * 8

        Dim Font1Width As Integer = 8
        Dim Font1Height As Integer = 12
        Dim Font2Width As Integer = 12
        Dim Font2Height As Integer = 20
        Dim Font3Width As Integer = 16
        Dim Font3Height As Integer = 24
        Dim Font4Width As Integer = 24
        Dim Font4Height As Integer = 32
        Dim Font5Width As Integer = 32
        Dim Font5Height As Integer = 48
        Dim CompanyNameFontHeight As Integer
        Dim CompanyNameSpaceAdjust As Integer = 2

        Dim XPosExt As Integer
        Dim StrLengthinPt As Integer
        Dim StrLength As Integer

        'Define a starting X and Y position for the barcode
        Dim XStartPos As Integer = 2
        Dim YStartPos As Integer = LabelYStartPos
        Dim XPos As Integer
        Dim YPos As Integer
        Dim YPosExt As Integer = 0
        Dim YPos2 As Integer = 20

        XPos = 0
        YPos = YStartPos + YPosExt
        '==========================================================================
        Call barcode(CStr(XPos), CStr(YPos), CodeType, CStr(TSCBarHeight), TSCHumanRead, TSCRotation, BSNarrowBarRatio, BSWideBarRatio, ItemCode)
        'Call printerfont("200", "100", "4", "0", "1", "1", "PDR007029")
        'Call printerfont("200", "150", "4", "0", "1", "1", "3MM")
        'Call printerfont("200", "200", "4", "0", "1", "1", "No.12")
        'Call printerfont("200", "250", "4", "0", "1", "1", "RD 1/0.02")
        'Call printerfont("200", "300", "4", "0", "1", "1", "750W/2.84")

        YPos = YPos + TSCBarHeight
        Call windowsfont(CStr(XPos + 860), CStr(YPos - YPosGap), CStr(BarcodeTextFontType), "180", "0", "0", "Arial", Barcode5)
        Call windowsfont(CStr(XPos), CStr(YPos), CStr(BarcodeTextFontType), "0", "0", "0", "Arial", ItemCode)
        Call windowsfont(CStr(XPos + 860), CStr(YPos), CStr(BarcodeTextFontType), "180", "0", "0", "Arial", Barcode4)

        YPos = YPos + YPosGap
        Call windowsfont(CStr(XPos), CStr(YPos), CStr(BarcodeTextFontType), "0", "0", "0", "Arial", Barcode2)
        Call windowsfont(CStr(XPos + 860), CStr(YPos), CStr(BarcodeTextFontType), "180", "0", "0", "Arial", Barcode3)

        YPos = YPos + YPosGap
        Call windowsfont(CStr(XPos), CStr(YPos), CStr(BarcodeTextFontType), "0", "0", "0", "Arial", Barcode3)
        Call windowsfont(CStr(XPos + 860), CStr(YPos), CStr(BarcodeTextFontType), "180", "0", "0", "Arial", Barcode2)

        YPos = YPos + YPosGap
        Call windowsfont(CStr(XPos), CStr(YPos), CStr(BarcodeTextFontType), "0", "0", "0", "Arial", Barcode4)
        Call windowsfont(CStr(XPos + 860), CStr(YPos), CStr(BarcodeTextFontType), "180", "0", "0", "Arial", Barcode1)

        YPos = YPos + YPosGap
        Call windowsfont(CStr(XPos), CStr(YPos), CStr(BarcodeTextFontType), "0", "0", "0", "Arial", Barcode5)

        YPos = YPos - YPosGap + 10
        Call barcode(CStr(XPos + 620), CStr(YPos), CodeType, CStr(TSCBarHeight), TSCHumanRead, TSCRotation, BSNarrowBarRatio, BSWideBarRatio, ItemCode)
        YPos = YPos + TSCBarHeight
        Call windowsfont(CStr(XPos + 620), CStr(YPos), CStr(BarcodeTextFontType), "0", "0", "0", "Arial", ItemCode)
        YPos = YPos + YPosGap

        If ItemPrice.Length > 0 Then
            Call windowsfont(CStr(XPos + 620), CStr(YPos), CStr(ItemPriceFontType), "0", "0", "0", "Arial", ItemPrice)
        End If


        '===========================================================================

        'If CompanyLogoFilename <> "" Then
        '    CompanyNameFontHeight = Font2Height
        '    'Print Company logo
        '    Dim putpcxcmd As String
        '    Dim putpcxpath As String
        '    'putpcxpath = "D:\BMP-PCX\LOGO.PCX" ' + CompanyLogoFilename
        '    'Call downloadpcx(putpcxpath, "LOGO.PCX")
        '    'Call sendcommand("MOVE")
        '    'putpcxcmd = "PUTPCX 1,1,'LOGO.PCX'" '+ CompanyLogoFilename
        '    Call sendcommand("PUTPCX 2,12,""LOGO.PCX""")
        '    'sendcommand(putbmpcmd)
        '    'Call downloadpcx(putpcxpath, "LOGO")
        '    'Call sendcommand(putpcxcmd)

        '    XPos = XStartPos + 90
        '    'Print company name
        '    Call windowsfont(CStr(XPos), CStr(YStartPos), CInt(CompanyNameFontSize), 0, 0, 0, CompanyNameFontType, CompanyNameLine1)
        '    'Call printerfont(CStr(XStartPos) + 100, CStr(YStartPos), CompanyNameFontType, TSCRotation, TSCFontMag, TSCFontMag, CompanyNameLine1)
        '    YPosExt = CompanyNameFontSize
        '    YPos = YStartPos + YPosExt

        '    Call windowsfont(CStr(XPos), CStr(YPos), CInt(CompanyNameFontSize), 0, 0, 0, CompanyNameFontType, CompanyNameLine2)
        '    'Call printerfont(CStr(XPos), CStr(YPos), CompanyNameFontType, TSCRotation, TSCFontMag, TSCFontMag, CompanyNameLine2)

        'Else
        '    'Print company name
        '    'Dim CompanyNameLine1 As String = "JAYACOM INFORMATION" '"ALL IT HYPERMARKET" 
        '    'Dim CompanyNameLine2 As String = "SDN. BHD."

        '    CompanyNameFontHeight = Font2Height
        '    Call printerfont(CStr(XStartPos), CStr(YStartPos), CompanyNameFontType, TSCRotation, TSCFontMag, TSCFontMag, CompanyNameLine1)
        '    YPosExt = CompanyNameFontHeight
        '    YPos = YStartPos + YPosExt
        '    XPos = XStartPos + 70
        '    Call printerfont(CStr(XPos), CStr(YPos), CompanyNameFontType, TSCRotation, TSCFontMag, TSCFontMag, CompanyNameLine2)

        'End If

        'Dim AdjustedCompanyNameFontType As String = "2"
        ''human readable disable, rotation = 0deg, narrow bar = 2pt
        'If CompanyLogoFilename <> "" Then
        '    AdjustedCompanyNameFontType = "2" 'Font2Height
        'Else
        '    AdjustedCompanyNameFontType = CompanyNameFontType
        'End If

        'If CompanyNameLine2 = "" Then
        '    CompanyNameSpaceAdjust = 1
        'Else
        '    CompanyNameSpaceAdjust = 2
        'End If
        ''YPosExt = CompanyNameFontHeight + CompanyNameFontHeight + 2
        'YPosExt = (GetTSCFontHeight(AdjustedCompanyNameFontType) * CompanyNameSpaceAdjust) + 2

        'YPos = YStartPos + YPosExt

        'If UseItemCode2PrintBarcode = "TRUE" Then
        '    strbarcode = ""
        '    strbarcode = ItemCode
        'End If

        'XPos = XStartPos + XPosOffsetBarcodeItemName
        'If BSEnableDoubleFormat = "TRUE" Then
        '    If Not IsNumeric(strbarcode) And strbarcode.Length > 6 Then
        '        TSCNarrowBar = 1
        '        XPos = XPos + XPosOffsetBarcodeDoubleFormat
        '        Call barcode(CStr(XPos), CStr(YPos), CodeType, CStr(TSCBarHeight), TSCHumanRead, TSCRotation, TSCNarrowBar, TSCNarrowBar, strbarcode)
        '    Else 'normal numeric only barcode and alpahabet barcode less than 6 chars 
        '        If strbarcode.Length > 6 Then
        '            Call barcode(CStr(XPos), CStr(YPos), CodeType, CStr(TSCBarHeight), TSCHumanRead, TSCRotation, BSNarrowBarRatio, BSWideBarRatio, strbarcode)
        '        Else
        '            XPos = XPos + XPosOffsetBarcodeDoubleFormat
        '            Call barcode(CStr(XPos), CStr(YPos), CodeType, CStr(TSCBarHeight), TSCHumanRead, TSCRotation, BSNarrowBarRatio, BSWideBarRatio, strbarcode)
        '        End If

        '    End If
        'Else
        '    Call barcode(CStr(XPos), CStr(YPos), CodeType, CStr(TSCBarHeight), TSCHumanRead, TSCRotation, BSNarrowBarRatio, BSWideBarRatio, strbarcode)

        'End If

        ''Print human readable barcode text and center-align
        'YPosExt = (GetTSCFontHeight(AdjustedCompanyNameFontType) * CompanyNameSpaceAdjust) + 4 + TSCBarHeight
        'YPos = YStartPos + YPosExt

        'Dim LabelWidth_dot As Integer = LSWidth * 8
        'Dim LabelWitdh_Pix As Integer = 208

        'StrLength = strbarcode.Length()
        'StrLengthinPt = StrLength * ((GetTSCFontWidth(BarcodeTextFontType) * LabelWitdh_Pix) / LabelWidth_dot)

        'XPosExt = (LabelWitdh_Pix / 2) - (StrLengthinPt / 2)
        'XPos = XPosOffsetBarcodeText + XStartPos + XPosExt
        ''XPos = XStartPos + 20 '50
        'Call printerfont(CStr(XPos), CStr(YPos), BarcodeTextFontType, TSCRotation, TSCFontMag, TSCFontMag, strbarcode)


        ''Print Item Name
        'Dim StrNameLine1 As String
        'Dim StrNameLine2 As String
        'Dim StrNameLine3 As String
        'Dim StrNameLine4 As String
        'Dim StrArrItemName(50) As String
        'Dim oldDQ As String = Chr(34)
        'Dim newDQ As String = "\[" & Chr(34) & "]" 'Chr(34) = "
        'Dim ItemNameFontHeight As Integer = 0

        'If IsNumeric(ItemNameFontType) Then
        '    ItemNameFontHeight = GetTSCFontHeight(BarcodeTextFontType)
        'Else
        '    ItemNameFontHeight = ItemNameFontSize
        'End If

        'StrArrItemName = BreakItemName(ItemName, ItemNameMaxLengthperLine)
        'StrNameLine1 = StrArrItemName(0)
        'StrNameLine2 = StrArrItemName(1)
        'StrNameLine3 = StrArrItemName(2)
        'StrNameLine4 = StrArrItemName(3)

        'If ItemNameMaxRowLine = 1 Then
        '    StrNameLine2 = ""
        '    StrNameLine3 = ""
        '    StrNameLine4 = ""
        'ElseIf ItemNameMaxRowLine = 2 Then
        '    StrNameLine3 = ""
        '    StrNameLine4 = ""
        'ElseIf ItemNameMaxRowLine = 3 Then
        '    StrNameLine4 = ""
        'End If

        'StrLength = ItemName.Length()
        ''If StrLength <= ItemNameMaxLengthperLine Then
        'If StrNameLine1 <> "" And StrNameLine2 = "" Then
        '    'StrNameLine1 = ItemName.Substring(0, StrLength)
        '    If StrNameLine1.IndexOf(oldDQ) <> -1 Then
        '        StrNameLine1 = StrNameLine1.Replace(oldDQ, newDQ)
        '    End If

        '    StrLengthinPt = StrLength * Font1Width
        '    XPosExt = (ptLabelWidth / 2) - (StrLengthinPt / 2)
        '    If ItemNameTextAlign = "CENTER" Then
        '        XPos = XStartPos + XPosExt
        '    Else
        '        XPos = XStartPos + XPosOffsetBarcodeItemName
        '    End If



        '    YPosExt = (GetTSCFontHeight(AdjustedCompanyNameFontType) * CompanyNameSpaceAdjust) + 4 + TSCBarHeight + GetTSCFontHeight(BarcodeTextFontType)
        '    YPos = YStartPos + YPosExt
        '    If IsNumeric(ItemNameFontType) Then
        '        Call printerfont(CStr(XPos), CStr(YPos), ItemNameFontType, TSCRotation, TSCFontMag, TSCFontMag, StrNameLine1)
        '    Else
        '        Call windowsfont(CStr(XPos), CStr(YPos), CInt(ItemNameFontSize), 0, 2, 0, ItemNameFontType, StrNameLine1)
        '    End If
        '    'ElseIf StrLength > ItemNameMaxLengthperLine And StrLength <= (ItemNameMaxLengthperLine * 2) Then
        'ElseIf StrNameLine2 <> "" And StrNameLine3 = "" Then
        '    'StrNameLine1 = ItemName.Substring(0, 26)
        '    'StrNameLine2 = ItemName.Substring(ItemNameMaxLengthperLine, StrLength - ItemNameMaxLengthperLine)

        '    If StrNameLine1.IndexOf(oldDQ) <> -1 Then
        '        StrNameLine1 = StrNameLine1.Replace(oldDQ, newDQ)
        '    End If
        '    If StrNameLine2.IndexOf(oldDQ) <> -1 Then
        '        StrNameLine2 = StrNameLine2.Replace(oldDQ, newDQ)
        '    End If

        '    StrLengthinPt = ItemNameMaxLengthperLine * Font1Width
        '    XPosExt = (ptLabelWidth / 2) - (StrLengthinPt / 2)
        '    If ItemNameTextAlign = "CENTER" Then
        '        XPos = XStartPos + XPosExt
        '    Else
        '        XPos = XStartPos + XPosOffsetBarcodeItemName
        '    End If


        '    YPosExt = (GetTSCFontHeight(AdjustedCompanyNameFontType) * CompanyNameSpaceAdjust) + 4 + TSCBarHeight + GetTSCFontHeight(BarcodeTextFontType)
        '    YPos = YStartPos + YPosExt
        '    If IsNumeric(ItemNameFontType) Then
        '        Call printerfont(CStr(XPos), CStr(YPos), ItemNameFontType, TSCRotation, TSCFontMag, TSCFontMag, StrNameLine1)
        '    Else
        '        Call windowsfont(CStr(XPos), CStr(YPos), CInt(ItemNameFontSize), 0, 2, 0, ItemNameFontType, StrNameLine1)
        '    End If



        '    StrLengthinPt = (StrLength - ItemNameMaxLengthperLine) * Font1Width
        '    XPosExt = (ptLabelWidth / 2) - ((StrLengthinPt) / 2)
        '    If ItemNameTextAlign = "CENTER" Then
        '        XPos = XStartPos + XPosExt
        '    Else
        '        XPos = XStartPos + XPosOffsetBarcodeItemName
        '    End If


        '    YPosExt = (GetTSCFontHeight(AdjustedCompanyNameFontType) * CompanyNameSpaceAdjust) + 4 + TSCBarHeight + GetTSCFontHeight(BarcodeTextFontType) + ItemNameFontHeight
        '    YPos = YStartPos + YPosExt
        '    If IsNumeric(ItemNameFontType) Then
        '        Call printerfont(CStr(XPos), CStr(YPos), ItemNameFontType, TSCRotation, TSCFontMag, TSCFontMag, StrNameLine2)
        '    Else
        '        Call windowsfont(CStr(XPos), CStr(YPos), CInt(ItemNameFontSize), 0, 2, 0, ItemNameFontType, StrNameLine2)
        '    End If
        '    'ElseIf StrLength > (ItemNameMaxLengthperLine * 2) And StrLength <= (ItemNameMaxLengthperLine * 3) Then
        'ElseIf StrNameLine3 <> "" And StrNameLine4 = "" Then
        '    'StrNameLine1 = ItemName.Substring(0, 26)
        '    'StrNameLine2 = ItemName.Substring(ItemNameMaxLengthperLine, ItemNameMaxLengthperLine)
        '    'StrNameLine3 = ItemName.Substring(ItemNameMaxLengthperLine * 2, StrLength - ItemNameMaxLengthperLine * 2)

        '    If StrNameLine1.IndexOf(oldDQ) <> -1 Then
        '        StrNameLine1 = StrNameLine1.Replace(oldDQ, newDQ)
        '    End If

        '    If StrNameLine2.IndexOf(oldDQ) <> -1 Then
        '        StrNameLine2 = StrNameLine2.Replace(oldDQ, newDQ)
        '    End If

        '    If StrNameLine3.IndexOf(oldDQ) <> -1 Then
        '        StrNameLine3 = StrNameLine3.Replace(oldDQ, newDQ)
        '    End If


        '    StrLengthinPt = (ItemNameMaxLengthperLine) * Font1Width
        '    XPosExt = (ptLabelWidth / 2) - ((StrLengthinPt) / 2)
        '    If ItemNameTextAlign = "CENTER" Then
        '        XPos = XStartPos + XPosExt
        '    Else
        '        XPos = XStartPos + XPosOffsetBarcodeItemName
        '    End If


        '    YPosExt = (GetTSCFontHeight(AdjustedCompanyNameFontType) * CompanyNameSpaceAdjust) + 4 + TSCBarHeight + GetTSCFontHeight(BarcodeTextFontType)
        '    YPos = YStartPos + YPosExt
        '    If IsNumeric(ItemNameFontType) Then
        '        Call printerfont(CStr(XPos), CStr(YPos), ItemNameFontType, TSCRotation, TSCFontMag, TSCFontMag, StrNameLine1)
        '    Else
        '        Call windowsfont(CStr(XPos), CStr(YPos), CInt(ItemNameFontSize), 0, 2, 0, ItemNameFontType, StrNameLine1)
        '    End If


        '    StrLengthinPt = (ItemNameMaxLengthperLine) * Font1Width
        '    XPosExt = (ptLabelWidth / 2) - ((StrLengthinPt) / 2)
        '    If ItemNameTextAlign = "CENTER" Then
        '        XPos = XStartPos + XPosExt
        '    Else
        '        XPos = XStartPos + XPosOffsetBarcodeItemName
        '    End If


        '    YPosExt = (GetTSCFontHeight(AdjustedCompanyNameFontType) * CompanyNameSpaceAdjust) + 4 + TSCBarHeight + GetTSCFontHeight(BarcodeTextFontType) + ItemNameFontHeight
        '    YPos = YStartPos + YPosExt
        '    If IsNumeric(ItemNameFontType) Then
        '        Call printerfont(CStr(XPos), CStr(YPos), ItemNameFontType, TSCRotation, TSCFontMag, TSCFontMag, StrNameLine2)
        '    Else
        '        Call windowsfont(CStr(XPos), CStr(YPos), CInt(ItemNameFontSize), 0, 2, 0, ItemNameFontType, StrNameLine2)
        '    End If

        '    StrLengthinPt = (StrLength - (ItemNameMaxLengthperLine * 2)) * Font1Width
        '    XPosExt = (ptLabelWidth / 2) - ((StrLengthinPt) / 2)
        '    If ItemNameTextAlign = "CENTER" Then
        '        XPos = XStartPos + XPosExt
        '    Else
        '        XPos = XStartPos + XPosOffsetBarcodeItemName
        '    End If


        '    YPosExt = (GetTSCFontHeight(AdjustedCompanyNameFontType) * CompanyNameSpaceAdjust) + 4 + TSCBarHeight + GetTSCFontHeight(BarcodeTextFontType) + ItemNameFontHeight + ItemNameFontHeight
        '    YPos = YStartPos + YPosExt
        '    If IsNumeric(ItemNameFontType) Then
        '        Call printerfont(CStr(XPos), CStr(YPos), ItemNameFontType, TSCRotation, TSCFontMag, TSCFontMag, StrNameLine3)
        '    Else
        '        Call windowsfont(CStr(XPos), CStr(YPos), CInt(ItemNameFontSize), 0, 2, 0, ItemNameFontType, StrNameLine3)
        '    End If


        'Else   ' strLength > 78
        '    'StrNameLine1 = ItemName.Substring(0, ItemNameMaxLengthperLine)
        '    'StrNameLine2 = ItemName.Substring(ItemNameMaxLengthperLine, ItemNameMaxLengthperLine)
        '    'StrNameLine3 = ItemName.Substring((ItemNameMaxLengthperLine * 2), ItemNameMaxLengthperLine)
        '    'StrNameLine4 = ItemName.Substring((ItemNameMaxLengthperLine * 3), StrLength - (ItemNameMaxLengthperLine * 3))

        '    If StrNameLine1.IndexOf(oldDQ) <> -1 Then
        '        StrNameLine1 = StrNameLine1.Replace(oldDQ, newDQ)
        '    End If

        '    If StrNameLine2.IndexOf(oldDQ) <> -1 Then
        '        StrNameLine2 = StrNameLine2.Replace(oldDQ, newDQ)
        '    End If

        '    If StrNameLine3.IndexOf(oldDQ) <> -1 Then
        '        StrNameLine3 = StrNameLine3.Replace(oldDQ, newDQ)
        '    End If

        '    If StrNameLine4.IndexOf(oldDQ) <> -1 Then
        '        StrNameLine4 = StrNameLine4.Replace(oldDQ, newDQ)
        '    End If


        '    StrLengthinPt = (ItemNameMaxLengthperLine) * Font1Width
        '    XPosExt = (ptLabelWidth / 2) - ((StrLengthinPt) / 2)
        '    If ItemNameTextAlign = "CENTER" Then
        '        XPos = XStartPos + XPosExt
        '    Else
        '        XPos = XStartPos + XPosOffsetBarcodeItemName
        '    End If


        '    YPosExt = (GetTSCFontHeight(AdjustedCompanyNameFontType) * CompanyNameSpaceAdjust) + 4 + TSCBarHeight + GetTSCFontHeight(BarcodeTextFontType)
        '    YPos = YStartPos + YPosExt
        '    If IsNumeric(ItemNameFontType) Then
        '        Call printerfont(CStr(XPos), CStr(YPos), ItemNameFontType, TSCRotation, TSCFontMag, TSCFontMag, StrNameLine1)
        '    Else
        '        Call windowsfont(CStr(XPos), CStr(YPos), CInt(ItemNameFontSize), 0, 2, 0, ItemNameFontType, StrNameLine1)
        '    End If


        '    StrLengthinPt = (ItemNameMaxLengthperLine) * Font1Width
        '    XPosExt = (ptLabelWidth / 2) - ((StrLengthinPt) / 2)
        '    If ItemNameTextAlign = "CENTER" Then
        '        XPos = XStartPos + XPosExt
        '    Else
        '        XPos = XStartPos + XPosOffsetBarcodeItemName
        '    End If


        '    YPosExt = (GetTSCFontHeight(AdjustedCompanyNameFontType) * CompanyNameSpaceAdjust) + 4 + TSCBarHeight + GetTSCFontHeight(BarcodeTextFontType) + ItemNameFontHeight
        '    YPos = YStartPos + YPosExt
        '    If IsNumeric(ItemNameFontType) Then
        '        Call printerfont(CStr(XPos), CStr(YPos), ItemNameFontType, TSCRotation, TSCFontMag, TSCFontMag, StrNameLine2)
        '    Else
        '        Call windowsfont(CStr(XPos), CStr(YPos), CInt(ItemNameFontSize), 0, 2, 0, ItemNameFontType, StrNameLine2)
        '    End If


        '    StrLengthinPt = (ItemNameMaxLengthperLine) * Font1Width
        '    XPosExt = (ptLabelWidth / 2) - ((StrLengthinPt) / 2)
        '    If ItemNameTextAlign = "CENTER" Then
        '        XPos = XStartPos + XPosExt
        '    Else
        '        XPos = XStartPos + XPosOffsetBarcodeItemName
        '    End If


        '    YPosExt = (GetTSCFontHeight(AdjustedCompanyNameFontType) * CompanyNameSpaceAdjust) + 4 + TSCBarHeight + GetTSCFontHeight(BarcodeTextFontType) + ItemNameFontHeight + ItemNameFontHeight
        '    YPos = YStartPos + YPosExt
        '    If IsNumeric(ItemNameFontType) Then
        '        Call printerfont(CStr(XPos), CStr(YPos), ItemNameFontType, TSCRotation, TSCFontMag, TSCFontMag, StrNameLine3)
        '    Else
        '        Call windowsfont(CStr(XPos), CStr(YPos), CInt(ItemNameFontSize), 0, 2, 0, ItemNameFontType, StrNameLine3)
        '    End If

        '    StrLengthinPt = (StrLength - (ItemNameMaxLengthperLine * 3)) * Font1Width
        '    XPosExt = (ptLabelWidth / 2) - ((StrLengthinPt) / 2)
        '    If ItemNameTextAlign = "CENTER" Then
        '        XPos = XStartPos + XPosExt
        '    Else
        '        XPos = XStartPos + XPosOffsetBarcodeItemName
        '    End If


        '    YPosExt = (GetTSCFontHeight(AdjustedCompanyNameFontType) * CompanyNameSpaceAdjust) + 4 + TSCBarHeight + GetTSCFontHeight(BarcodeTextFontType) + ItemNameFontHeight + ItemNameFontHeight + ItemNameFontHeight
        '    YPos = YStartPos + YPosExt
        '    If IsNumeric(ItemNameFontType) Then
        '        Call printerfont(CStr(XPos), CStr(YPos), ItemNameFontType, TSCRotation, TSCFontMag, TSCFontMag, StrNameLine4)
        '    Else
        '        Call windowsfont(CStr(XPos), CStr(YPos), CInt(ItemNameFontSize), 0, 2, 0, ItemNameFontType, StrNameLine4)
        '    End If

        'End If


        ''Print Item Price
        'StrLength = ItemPrice.Length
        'StrLengthinPt = StrLength * Font4Width
        ''XPosExt = (ptLabelWidth / 2) - (StrLengthinPt / 2)
        'XPosExt = ((Font4Width * 12) / 2) - (StrLengthinPt / 2) 'using font width to calculate label width FW*20char
        '' 20+20+2+40+80+5=167 < (200-20-8)=172
        'YPosExt = YPosOffsetItemPrice + (GetTSCFontHeight(AdjustedCompanyNameFontType) * CompanyNameSpaceAdjust) + 4 + TSCBarHeight + +GetTSCFontHeight(BarcodeTextFontType)
        'YPos = YStartPos + YPosExt
        'XPos = XPosOffsetItemPrice + XStartPos + XPosExt

        ''Don't print if print is RM 0.00
        'If ItemPrice <> "RM 0.00" Then
        '    If IsNumeric(ItemPriceFontType) Then
        '        Call printerfont(CStr(XPos), CStr(YPos), ItemPriceFontType, TSCRotation, TSCFontMag, TSCFontMag, ItemPrice)
        '    Else
        '        Call windowsfont(CStr(XPos), CStr(YPos), CInt(ItemPriceFontSize), 0, 2, 0, ItemPriceFontType, ItemPrice)
        '    End If

        'End If



        'The number of printout sets&copies'

        Call printlabel("1", ItemQuality)

        'Disconnect with the printer'

        Call closeport()
    End Sub

    Public Sub doTSCPrintDirect1(ByVal strbarcode As String, ByVal ItemName As String, ByVal ItemPrice As String, ByVal ItemQuality As String, ByVal ItemCode As String)


        '203dpi => 1mm = 8dots
        'Call openport(PrintDialog1.PrinterSettings.PrinterName) '"TSC TTP-243(E) - (V)")
        Call openport(PrinterName)
        '35mm = 1.4" 25mm = 0.9", print speed = 2.0"/sec, print density = 15,
        'sensor type = 0 = vertical gap sensor, vertical gap height = 0.12" = 3.048, shift dist = 0mm
        Call setup(LSWidth, LSHeight, LSPrintSpeed, LSPrintDensity, "0", LSVerticalgap, "0")
        'Call setup("0", "100", "3", "10", "0", "0", "0")
        Call clearbuffer()
        'Call sendcommand("DIRECTION 1")
        'Call sendcommand("SET CUTTER OFF") ' Or the number of printout per cut'
        'Call sendcommand("FORMFEED") '"HOME") 'This will jump over one empty label


        'Print a barcode'
        Dim CodeType As String = BSBarcodeType
        Dim TSCBarHeight As Single = BSBarHeight ' 36.54pt = 0.18"
        Dim TSCHumanRead As String = "0"
        Dim TSCRotation As String = "0"
        Dim TSCNarrowBar As String = "2"
        Dim TSCBuildinFont1 As String = "1"  '8 x 12 dots
        Dim TSCBuildinFont2 As String = "2"  '12 x 20 dots
        Dim TSCBuildinFont3 As String = "3"  '16 x 24 dots
        Dim TSCBuildinFont4 As String = "4"  '24 x 32 dots
        Dim TSCBuildinFont5 As String = "5" '32 x 48 dots
        Dim TSCFontMag As String = "1"

        Dim ptLabelWidth As Integer = 26 * 8 '35 * 8 - suppose 35mm * 8dot = 280, but font1 support 26 char, 26 * 8dot =208
        Dim ptLabelHeight As Integer = 25 * 8

        Dim Font1Width As Integer = 8
        Dim Font1Height As Integer = 12
        Dim Font2Width As Integer = 12
        Dim Font2Height As Integer = 20
        Dim Font3Width As Integer = 16
        Dim Font3Height As Integer = 24
        Dim Font4Width As Integer = 24
        Dim Font4Height As Integer = 32
        Dim Font5Width As Integer = 32
        Dim Font5Height As Integer = 48
        Dim CompanyNameFontHeight As Integer
        Dim CompanyNameSpaceAdjust As Integer = 2

        Dim XPosExt As Integer
        Dim StrLengthinPt As Integer
        Dim StrLength As Integer

        'Define a starting X and Y position for the barcode
        Dim XStartPos As Integer = 2
        Dim YStartPos As Integer = LabelYStartPos
        Dim XPos As Integer
        Dim YPos As Integer
        Dim YPosExt As Integer = 0


        If CompanyLogoFilename <> "" Then
            CompanyNameFontHeight = Font2Height
            'Print Company logo
            Dim putpcxcmd As String
            Dim putpcxpath As String
            'putpcxpath = "D:\BMP-PCX\LOGO.PCX" ' + CompanyLogoFilename
            'Call downloadpcx(putpcxpath, "LOGO.PCX")
            'Call sendcommand("MOVE")
            'putpcxcmd = "PUTPCX 1,1,'LOGO.PCX'" '+ CompanyLogoFilename
            Call sendcommand("PUTPCX 2,12,""LOGO.PCX""")
            'sendcommand(putbmpcmd)
            'Call downloadpcx(putpcxpath, "LOGO")
            'Call sendcommand(putpcxcmd)

            XPos = XStartPos + 90
            'Print company name
            Call windowsfont(CStr(XPos), CStr(YStartPos), CInt(CompanyNameFontSize), 0, 0, 0, CompanyNameFontType, CompanyNameLine1)
            'Call printerfont(CStr(XStartPos) + 100, CStr(YStartPos), CompanyNameFontType, TSCRotation, TSCFontMag, TSCFontMag, CompanyNameLine1)
            YPosExt = CompanyNameFontSize
            YPos = YStartPos + YPosExt

            Call windowsfont(CStr(XPos), CStr(YPos), CInt(CompanyNameFontSize), 0, 0, 0, CompanyNameFontType, CompanyNameLine2)
            'Call printerfont(CStr(XPos), CStr(YPos), CompanyNameFontType, TSCRotation, TSCFontMag, TSCFontMag, CompanyNameLine2)

        Else
            'Print company name
            'Dim CompanyNameLine1 As String = "JAYACOM INFORMATION" '"ALL IT HYPERMARKET" 
            'Dim CompanyNameLine2 As String = "SDN. BHD."

            CompanyNameFontHeight = Font2Height
            Call printerfont(CStr(XStartPos), CStr(YStartPos), CompanyNameFontType, TSCRotation, TSCFontMag, TSCFontMag, CompanyNameLine1)
            YPosExt = CompanyNameFontHeight
            YPos = YStartPos + YPosExt
            XPos = XStartPos + 70
            Call printerfont(CStr(XPos), CStr(YPos), CompanyNameFontType, TSCRotation, TSCFontMag, TSCFontMag, CompanyNameLine2)

        End If

        Dim AdjustedCompanyNameFontType As String = "2"
        'human readable disable, rotation = 0deg, narrow bar = 2pt
        If CompanyLogoFilename <> "" Then
            AdjustedCompanyNameFontType = "2" 'Font2Height
        Else
            AdjustedCompanyNameFontType = CompanyNameFontType
        End If

        If CompanyNameLine2 = "" Then
            CompanyNameSpaceAdjust = 1
        Else
            CompanyNameSpaceAdjust = 2
        End If
        'YPosExt = CompanyNameFontHeight + CompanyNameFontHeight + 2
        YPosExt = (GetTSCFontHeight(AdjustedCompanyNameFontType) * CompanyNameSpaceAdjust) + 2

        YPos = YStartPos + YPosExt

        If UseItemCode2PrintBarcode = "TRUE" Then
            strbarcode = ""
            strbarcode = ItemCode
        End If

        XPos = XStartPos + XPosOffsetBarcodeItemName
        If BSEnableDoubleFormat = "TRUE" Then
            If Not IsNumeric(strbarcode) And strbarcode.Length > 6 Then
                TSCNarrowBar = 1
                XPos = XPos + XPosOffsetBarcodeDoubleFormat
                Call barcode(CStr(XPos), CStr(YPos), CodeType, CStr(TSCBarHeight), TSCHumanRead, TSCRotation, TSCNarrowBar, TSCNarrowBar, strbarcode)
            Else 'normal numeric only barcode and alpahabet barcode less than 6 chars 
                If strbarcode.Length > 6 Then
                    Call barcode(CStr(XPos), CStr(YPos), CodeType, CStr(TSCBarHeight), TSCHumanRead, TSCRotation, BSNarrowBarRatio, BSWideBarRatio, strbarcode)
                Else
                    XPos = XPos + XPosOffsetBarcodeDoubleFormat
                    Call barcode(CStr(XPos), CStr(YPos), CodeType, CStr(TSCBarHeight), TSCHumanRead, TSCRotation, BSNarrowBarRatio, BSWideBarRatio, strbarcode)
                End If

            End If
        Else
            Call barcode(CStr(XPos), CStr(YPos), CodeType, CStr(TSCBarHeight), TSCHumanRead, TSCRotation, BSNarrowBarRatio, BSWideBarRatio, strbarcode)

        End If

        'Print human readable barcode text and center-align
        YPosExt = (GetTSCFontHeight(AdjustedCompanyNameFontType) * CompanyNameSpaceAdjust) + 4 + TSCBarHeight
        YPos = YStartPos + YPosExt

        Dim LabelWidth_dot As Integer = LSWidth * 8
        Dim LabelWitdh_Pix As Integer = 208

        StrLength = strbarcode.Length()
        StrLengthinPt = StrLength * ((GetTSCFontWidth(BarcodeTextFontType) * LabelWitdh_Pix) / LabelWidth_dot)

        XPosExt = (LabelWitdh_Pix / 2) - (StrLengthinPt / 2)
        XPos = XPosOffsetBarcodeText + XStartPos + XPosExt
        'XPos = XStartPos + 20 '50
        Call printerfont(CStr(XPos), CStr(YPos), BarcodeTextFontType, TSCRotation, TSCFontMag, TSCFontMag, strbarcode)


        'Print Item Name
        Dim StrNameLine1 As String
        Dim StrNameLine2 As String
        Dim StrNameLine3 As String
        Dim StrNameLine4 As String
        Dim StrArrItemName(50) As String
        Dim oldDQ As String = Chr(34)
        Dim newDQ As String = "\[" & Chr(34) & "]" 'Chr(34) = "
        Dim ItemNameFontHeight As Integer = 0

        If IsNumeric(ItemNameFontType) Then
            ItemNameFontHeight = GetTSCFontHeight(BarcodeTextFontType)
        Else
            ItemNameFontHeight = ItemNameFontSize
        End If

        StrArrItemName = BreakItemName(ItemName, ItemNameMaxLengthperLine)
        StrNameLine1 = StrArrItemName(0)
        StrNameLine2 = StrArrItemName(1)
        StrNameLine3 = StrArrItemName(2)
        StrNameLine4 = StrArrItemName(3)

        If ItemNameMaxRowLine = 1 Then
            StrNameLine2 = ""
            StrNameLine3 = ""
            StrNameLine4 = ""
        ElseIf ItemNameMaxRowLine = 2 Then
            StrNameLine3 = ""
            StrNameLine4 = ""
        ElseIf ItemNameMaxRowLine = 3 Then
            StrNameLine4 = ""
        End If

        StrLength = ItemName.Length()
        'If StrLength <= ItemNameMaxLengthperLine Then
        If StrNameLine1 <> "" And StrNameLine2 = "" Then
            'StrNameLine1 = ItemName.Substring(0, StrLength)
            If StrNameLine1.IndexOf(oldDQ) <> -1 Then
                StrNameLine1 = StrNameLine1.Replace(oldDQ, newDQ)
            End If

            StrLengthinPt = StrLength * Font1Width
            XPosExt = (ptLabelWidth / 2) - (StrLengthinPt / 2)
            If ItemNameTextAlign = "CENTER" Then
                XPos = XStartPos + XPosExt
            Else
                XPos = XStartPos + XPosOffsetBarcodeItemName
            End If



            YPosExt = (GetTSCFontHeight(AdjustedCompanyNameFontType) * CompanyNameSpaceAdjust) + 4 + TSCBarHeight + GetTSCFontHeight(BarcodeTextFontType)
            YPos = YStartPos + YPosExt
            If IsNumeric(ItemNameFontType) Then
                Call printerfont(CStr(XPos), CStr(YPos), ItemNameFontType, TSCRotation, TSCFontMag, TSCFontMag, StrNameLine1)
            Else
                Call windowsfont(CStr(XPos), CStr(YPos), CInt(ItemNameFontSize), 0, 2, 0, ItemNameFontType, StrNameLine1)
            End If
            'ElseIf StrLength > ItemNameMaxLengthperLine And StrLength <= (ItemNameMaxLengthperLine * 2) Then
        ElseIf StrNameLine2 <> "" And StrNameLine3 = "" Then
            'StrNameLine1 = ItemName.Substring(0, 26)
            'StrNameLine2 = ItemName.Substring(ItemNameMaxLengthperLine, StrLength - ItemNameMaxLengthperLine)

            If StrNameLine1.IndexOf(oldDQ) <> -1 Then
                StrNameLine1 = StrNameLine1.Replace(oldDQ, newDQ)
            End If
            If StrNameLine2.IndexOf(oldDQ) <> -1 Then
                StrNameLine2 = StrNameLine2.Replace(oldDQ, newDQ)
            End If

            StrLengthinPt = ItemNameMaxLengthperLine * Font1Width
            XPosExt = (ptLabelWidth / 2) - (StrLengthinPt / 2)
            If ItemNameTextAlign = "CENTER" Then
                XPos = XStartPos + XPosExt
            Else
                XPos = XStartPos + XPosOffsetBarcodeItemName
            End If


            YPosExt = (GetTSCFontHeight(AdjustedCompanyNameFontType) * CompanyNameSpaceAdjust) + 4 + TSCBarHeight + GetTSCFontHeight(BarcodeTextFontType)
            YPos = YStartPos + YPosExt
            If IsNumeric(ItemNameFontType) Then
                Call printerfont(CStr(XPos), CStr(YPos), ItemNameFontType, TSCRotation, TSCFontMag, TSCFontMag, StrNameLine1)
            Else
                Call windowsfont(CStr(XPos), CStr(YPos), CInt(ItemNameFontSize), 0, 2, 0, ItemNameFontType, StrNameLine1)
            End If



            StrLengthinPt = (StrLength - ItemNameMaxLengthperLine) * Font1Width
            XPosExt = (ptLabelWidth / 2) - ((StrLengthinPt) / 2)
            If ItemNameTextAlign = "CENTER" Then
                XPos = XStartPos + XPosExt
            Else
                XPos = XStartPos + XPosOffsetBarcodeItemName
            End If


            YPosExt = (GetTSCFontHeight(AdjustedCompanyNameFontType) * CompanyNameSpaceAdjust) + 4 + TSCBarHeight + GetTSCFontHeight(BarcodeTextFontType) + ItemNameFontHeight
            YPos = YStartPos + YPosExt
            If IsNumeric(ItemNameFontType) Then
                Call printerfont(CStr(XPos), CStr(YPos), ItemNameFontType, TSCRotation, TSCFontMag, TSCFontMag, StrNameLine2)
            Else
                Call windowsfont(CStr(XPos), CStr(YPos), CInt(ItemNameFontSize), 0, 2, 0, ItemNameFontType, StrNameLine2)
            End If
            'ElseIf StrLength > (ItemNameMaxLengthperLine * 2) And StrLength <= (ItemNameMaxLengthperLine * 3) Then
        ElseIf StrNameLine3 <> "" And StrNameLine4 = "" Then
            'StrNameLine1 = ItemName.Substring(0, 26)
            'StrNameLine2 = ItemName.Substring(ItemNameMaxLengthperLine, ItemNameMaxLengthperLine)
            'StrNameLine3 = ItemName.Substring(ItemNameMaxLengthperLine * 2, StrLength - ItemNameMaxLengthperLine * 2)

            If StrNameLine1.IndexOf(oldDQ) <> -1 Then
                StrNameLine1 = StrNameLine1.Replace(oldDQ, newDQ)
            End If

            If StrNameLine2.IndexOf(oldDQ) <> -1 Then
                StrNameLine2 = StrNameLine2.Replace(oldDQ, newDQ)
            End If

            If StrNameLine3.IndexOf(oldDQ) <> -1 Then
                StrNameLine3 = StrNameLine3.Replace(oldDQ, newDQ)
            End If


            StrLengthinPt = (ItemNameMaxLengthperLine) * Font1Width
            XPosExt = (ptLabelWidth / 2) - ((StrLengthinPt) / 2)
            If ItemNameTextAlign = "CENTER" Then
                XPos = XStartPos + XPosExt
            Else
                XPos = XStartPos + XPosOffsetBarcodeItemName
            End If


            YPosExt = (GetTSCFontHeight(AdjustedCompanyNameFontType) * CompanyNameSpaceAdjust) + 4 + TSCBarHeight + GetTSCFontHeight(BarcodeTextFontType)
            YPos = YStartPos + YPosExt
            If IsNumeric(ItemNameFontType) Then
                Call printerfont(CStr(XPos), CStr(YPos), ItemNameFontType, TSCRotation, TSCFontMag, TSCFontMag, StrNameLine1)
            Else
                Call windowsfont(CStr(XPos), CStr(YPos), CInt(ItemNameFontSize), 0, 2, 0, ItemNameFontType, StrNameLine1)
            End If


            StrLengthinPt = (ItemNameMaxLengthperLine) * Font1Width
            XPosExt = (ptLabelWidth / 2) - ((StrLengthinPt) / 2)
            If ItemNameTextAlign = "CENTER" Then
                XPos = XStartPos + XPosExt
            Else
                XPos = XStartPos + XPosOffsetBarcodeItemName
            End If


            YPosExt = (GetTSCFontHeight(AdjustedCompanyNameFontType) * CompanyNameSpaceAdjust) + 4 + TSCBarHeight + GetTSCFontHeight(BarcodeTextFontType) + ItemNameFontHeight
            YPos = YStartPos + YPosExt
            If IsNumeric(ItemNameFontType) Then
                Call printerfont(CStr(XPos), CStr(YPos), ItemNameFontType, TSCRotation, TSCFontMag, TSCFontMag, StrNameLine2)
            Else
                Call windowsfont(CStr(XPos), CStr(YPos), CInt(ItemNameFontSize), 0, 2, 0, ItemNameFontType, StrNameLine2)
            End If

            StrLengthinPt = (StrLength - (ItemNameMaxLengthperLine * 2)) * Font1Width
            XPosExt = (ptLabelWidth / 2) - ((StrLengthinPt) / 2)
            If ItemNameTextAlign = "CENTER" Then
                XPos = XStartPos + XPosExt
            Else
                XPos = XStartPos + XPosOffsetBarcodeItemName
            End If


            YPosExt = (GetTSCFontHeight(AdjustedCompanyNameFontType) * CompanyNameSpaceAdjust) + 4 + TSCBarHeight + GetTSCFontHeight(BarcodeTextFontType) + ItemNameFontHeight + ItemNameFontHeight
            YPos = YStartPos + YPosExt
            If IsNumeric(ItemNameFontType) Then
                Call printerfont(CStr(XPos), CStr(YPos), ItemNameFontType, TSCRotation, TSCFontMag, TSCFontMag, StrNameLine3)
            Else
                Call windowsfont(CStr(XPos), CStr(YPos), CInt(ItemNameFontSize), 0, 2, 0, ItemNameFontType, StrNameLine3)
            End If


        Else   ' strLength > 78
            'StrNameLine1 = ItemName.Substring(0, ItemNameMaxLengthperLine)
            'StrNameLine2 = ItemName.Substring(ItemNameMaxLengthperLine, ItemNameMaxLengthperLine)
            'StrNameLine3 = ItemName.Substring((ItemNameMaxLengthperLine * 2), ItemNameMaxLengthperLine)
            'StrNameLine4 = ItemName.Substring((ItemNameMaxLengthperLine * 3), StrLength - (ItemNameMaxLengthperLine * 3))

            If StrNameLine1.IndexOf(oldDQ) <> -1 Then
                StrNameLine1 = StrNameLine1.Replace(oldDQ, newDQ)
            End If

            If StrNameLine2.IndexOf(oldDQ) <> -1 Then
                StrNameLine2 = StrNameLine2.Replace(oldDQ, newDQ)
            End If

            If StrNameLine3.IndexOf(oldDQ) <> -1 Then
                StrNameLine3 = StrNameLine3.Replace(oldDQ, newDQ)
            End If

            If StrNameLine4.IndexOf(oldDQ) <> -1 Then
                StrNameLine4 = StrNameLine4.Replace(oldDQ, newDQ)
            End If


            StrLengthinPt = (ItemNameMaxLengthperLine) * Font1Width
            XPosExt = (ptLabelWidth / 2) - ((StrLengthinPt) / 2)
            If ItemNameTextAlign = "CENTER" Then
                XPos = XStartPos + XPosExt
            Else
                XPos = XStartPos + XPosOffsetBarcodeItemName
            End If


            YPosExt = (GetTSCFontHeight(AdjustedCompanyNameFontType) * CompanyNameSpaceAdjust) + 4 + TSCBarHeight + GetTSCFontHeight(BarcodeTextFontType)
            YPos = YStartPos + YPosExt
            If IsNumeric(ItemNameFontType) Then
                Call printerfont(CStr(XPos), CStr(YPos), ItemNameFontType, TSCRotation, TSCFontMag, TSCFontMag, StrNameLine1)
            Else
                Call windowsfont(CStr(XPos), CStr(YPos), CInt(ItemNameFontSize), 0, 2, 0, ItemNameFontType, StrNameLine1)
            End If


            StrLengthinPt = (ItemNameMaxLengthperLine) * Font1Width
            XPosExt = (ptLabelWidth / 2) - ((StrLengthinPt) / 2)
            If ItemNameTextAlign = "CENTER" Then
                XPos = XStartPos + XPosExt
            Else
                XPos = XStartPos + XPosOffsetBarcodeItemName
            End If


            YPosExt = (GetTSCFontHeight(AdjustedCompanyNameFontType) * CompanyNameSpaceAdjust) + 4 + TSCBarHeight + GetTSCFontHeight(BarcodeTextFontType) + ItemNameFontHeight
            YPos = YStartPos + YPosExt
            If IsNumeric(ItemNameFontType) Then
                Call printerfont(CStr(XPos), CStr(YPos), ItemNameFontType, TSCRotation, TSCFontMag, TSCFontMag, StrNameLine2)
            Else
                Call windowsfont(CStr(XPos), CStr(YPos), CInt(ItemNameFontSize), 0, 2, 0, ItemNameFontType, StrNameLine2)
            End If


            StrLengthinPt = (ItemNameMaxLengthperLine) * Font1Width
            XPosExt = (ptLabelWidth / 2) - ((StrLengthinPt) / 2)
            If ItemNameTextAlign = "CENTER" Then
                XPos = XStartPos + XPosExt
            Else
                XPos = XStartPos + XPosOffsetBarcodeItemName
            End If


            YPosExt = (GetTSCFontHeight(AdjustedCompanyNameFontType) * CompanyNameSpaceAdjust) + 4 + TSCBarHeight + GetTSCFontHeight(BarcodeTextFontType) + ItemNameFontHeight + ItemNameFontHeight
            YPos = YStartPos + YPosExt
            If IsNumeric(ItemNameFontType) Then
                Call printerfont(CStr(XPos), CStr(YPos), ItemNameFontType, TSCRotation, TSCFontMag, TSCFontMag, StrNameLine3)
            Else
                Call windowsfont(CStr(XPos), CStr(YPos), CInt(ItemNameFontSize), 0, 2, 0, ItemNameFontType, StrNameLine3)
            End If

            StrLengthinPt = (StrLength - (ItemNameMaxLengthperLine * 3)) * Font1Width
            XPosExt = (ptLabelWidth / 2) - ((StrLengthinPt) / 2)
            If ItemNameTextAlign = "CENTER" Then
                XPos = XStartPos + XPosExt
            Else
                XPos = XStartPos + XPosOffsetBarcodeItemName
            End If


            YPosExt = (GetTSCFontHeight(AdjustedCompanyNameFontType) * CompanyNameSpaceAdjust) + 4 + TSCBarHeight + GetTSCFontHeight(BarcodeTextFontType) + ItemNameFontHeight + ItemNameFontHeight + ItemNameFontHeight
            YPos = YStartPos + YPosExt
            If IsNumeric(ItemNameFontType) Then
                Call printerfont(CStr(XPos), CStr(YPos), ItemNameFontType, TSCRotation, TSCFontMag, TSCFontMag, StrNameLine4)
            Else
                Call windowsfont(CStr(XPos), CStr(YPos), CInt(ItemNameFontSize), 0, 2, 0, ItemNameFontType, StrNameLine4)
            End If

        End If


        'Print Item Price
        StrLength = ItemPrice.Length
        StrLengthinPt = StrLength * Font4Width
        'XPosExt = (ptLabelWidth / 2) - (StrLengthinPt / 2)
        XPosExt = ((Font4Width * 12) / 2) - (StrLengthinPt / 2) 'using font width to calculate label width FW*20char
        ' 20+20+2+40+80+5=167 < (200-20-8)=172
        YPosExt = YPosOffsetItemPrice + (GetTSCFontHeight(AdjustedCompanyNameFontType) * CompanyNameSpaceAdjust) + 4 + TSCBarHeight + +GetTSCFontHeight(BarcodeTextFontType)
        YPos = YStartPos + YPosExt
        XPos = XPosOffsetItemPrice + XStartPos + XPosExt

        'Don't print if print is RM 0.00
        If ItemPrice <> "RM 0.00" Then
            If IsNumeric(ItemPriceFontType) Then
                Call printerfont(CStr(XPos), CStr(YPos), ItemPriceFontType, TSCRotation, TSCFontMag, TSCFontMag, ItemPrice)
            Else
                Call windowsfont(CStr(XPos), CStr(YPos), CInt(ItemPriceFontSize), 0, 2, 0, ItemPriceFontType, ItemPrice)
            End If

        End If



        'The number of printout sets&copies'

        Call printlabel("1", ItemQuality)

        'Disconnect with the printer'

        Call closeport()
    End Sub

    ' Printing using Argox Printing Programming Language B (PPLB)
    Public Sub doPPLBPrintDirect(ByVal strbarcode As String, ByVal ItemName As String, ByVal ItemPrice As String, ByVal ItemQuality As String, ByVal ItemCode As String)



        'Define a starting X and Y position for the barcode
        Dim XStartPos As Integer = 2
        Dim YStartPos As Integer = 4
        Dim XPos As Integer
        Dim YPos As Integer
        Dim YPosExt As Integer = 0
        Dim XPosExt As Integer = 0

        'font info
        Dim dpi As Integer = 300
        Dim dpi_constant As Integer = 72



        '203dpi => 1mm = 8dots
        '300dpi => 1mm = 12dots
        '1 Point = 1/72 inch
        'Call openport(PrintDialog1.PrinterSettings.PrinterName) '"TSC TTP-243(E) - (V)")
        Call B_CreatePrn(1, 0)
        'Call B_Select_Symbol2(8, "5", 1)
        Call B_Set_Speed(CInt(LSPrintSpeed)) '0/1-7ips
        Call B_Set_Darkness(CInt(LSPrintDensity)) '0-15, default=8
        Call B_Select_Option(1) '1 -> thermal transfer, disable Cutter and Peel.

        '1 millimeter = 0.0393700787 inch
        Call B_Set_Labwidth(354) 'Label width in dots. 30mm=30*0.0393700787=1.1811', 1.1811*300=354.33
        Call B_Set_Labgap(319, 35) 'lablength, gaplength; length = 27mm=1.063', 1.063*300=318.9, gap = 3mm=0.11811'*300=35.43

        'B_Prn_Text_TrueType(x, y, FSize, FType, Fspin, FWeight, FItalic, FUnline, FStrikeOut, id_name, data)
        'Size, Height, Width in dots, FSize = (dpi * point) / 72. 
        'Fspin - 1->0, 2->90,..rotate
        'FWeight 0/NULL/400->standard, 100->Special thin, 200->very thin, 300->thin, 500->middle, 600->half thin, 700->thick, 800->special thick, 900->black body
        'B_Prn_Text_TrueType_W(x, y, FHeight, FWidth, FType, Fspin, FWeight, FItalic, FUnline, FStrikeOut, id_name, data)


        'Print company name
        Dim CompanyNameFontSize_dot = (dpi * CompanyNameFontSize) / dpi_constant
        Call B_Prn_Text_TrueType(XStartPos, YStartPos, CompanyNameFontSize_dot, CompanyNameFontType, 1, 400, 0, 0, 0, "CN1", CompanyNameLine1)

        'Print Item code
        Dim ItemCodeFontSize_dot = (dpi * ItemCodeFontSize) / dpi_constant

        XPos = XStartPos
        YPosExt = 2 + CompanyNameFontSize_dot
        YPos = YStartPos + YPosExt
        Call B_Prn_Text_TrueType(XPos, YPos, ItemCodeFontSize_dot, ItemCodeFontType, 1, 400, 0, 0, 0, "IC", ItemCode)

        'Print barcode
        XPos = XStartPos
        YPosExt = 2 + CompanyNameFontSize_dot + ItemCodeFontSize_dot
        YPos = YStartPos + YPosExt
        ' B_Prn_Barcode(x, y, ori, type, narrow, width, height, human, data) - human 'N'=78/'B'=66
        Call B_Prn_Barcode(XPos, YPos, 0, BSBarcodeType, CInt(BSNarrowBarRatio), CInt(BSWideBarRatio), BSBarHeight, 66, strbarcode) '1E=UCC/EAN, E30=EAN-13

        'Call B_Prn_Text(20, 150, 0, 4, 1, 1, 78, "ABCDEFGH")

        'Print human readable text 
        '-- with barcode

        'Print Item Name
        Dim StrLength As Integer
        Dim StrNameLine1 As String
        Dim StrNameLine2 As String
        Dim StrNameLine3 As String
        Dim StrArrItemName(50) As String
        Dim StrLengthinDot As Integer

        StrArrItemName = BreakItemName(ItemName, ItemNameMaxLengthperLine)
        StrNameLine1 = StrArrItemName(0)
        StrNameLine2 = StrArrItemName(1)
        StrNameLine3 = StrArrItemName(2)

        Dim ItemNameFontSize_dot As Integer
        ItemNameFontSize_dot = (dpi * ItemNameFontSize) / dpi_constant

        StrLength = ItemName.Length()
        If StrNameLine1 <> "" And StrNameLine2 = "" Then

            StrNameLine1 = ReplaceDQ_PPLB(StrNameLine1)
            StrNameLine1 = ReplaceBS_PPLB(StrNameLine1)

            StrLengthinDot = StrLength * ItemNameFontSize_dot
            XPosExt = ((ItemNameMaxLengthperLine * ItemNameFontSize_dot) / 2) - (StrLengthinDot / 2)
            If ItemNameTextAlign = "CENTER" Then
                XPos = XStartPos + XPosExt
            Else
                XPos = XStartPos + XPosOffsetBarcodeItemName
            End If

            YPosExt = 2 + CompanyNameFontSize_dot + ItemCodeFontSize_dot + BSBarHeight
            YPos = YStartPos + YPosExt
            ItemNameFontSize_dot = (dpi * 6) / dpi_constant
            Call B_Prn_Text_TrueType(XPos, YPos, ItemNameFontSize_dot, ItemNameFontType, 1, 400, 0, 0, 0, "N1", StrNameLine1)

        ElseIf StrNameLine2 <> "" And StrNameLine3 = "" Then

            StrNameLine1 = ReplaceDQ_PPLB(StrNameLine1)
            StrNameLine1 = ReplaceBS_PPLB(StrNameLine1)
            StrNameLine2 = ReplaceDQ_PPLB(StrNameLine2)
            StrNameLine2 = ReplaceBS_PPLB(StrNameLine2)

            StrLengthinDot = StrLength * ItemNameFontSize_dot
            XPosExt = ((ItemNameMaxLengthperLine * ItemNameFontSize_dot) / 2) - (StrLengthinDot / 2)
            If ItemNameTextAlign = "CENTER" Then
                XPos = XStartPos + XPosExt
            Else
                XPos = XStartPos + XPosOffsetBarcodeItemName
            End If

            YPosExt = 2 + CompanyNameFontSize_dot + ItemCodeFontSize_dot + BSBarHeight
            YPos = YStartPos + YPosExt
            ItemNameFontSize_dot = (dpi * 6) / dpi_constant
            Call B_Prn_Text_TrueType(XPos, YPos, ItemNameFontSize_dot, ItemNameFontType, 1, 400, 0, 0, 0, "N1", StrNameLine1)




        ElseIf StrNameLine3 <> "" Then
            StrNameLine1 = ReplaceDQ_PPLB(StrNameLine1)
            StrNameLine1 = ReplaceBS_PPLB(StrNameLine1)
            StrNameLine2 = ReplaceDQ_PPLB(StrNameLine2)
            StrNameLine2 = ReplaceBS_PPLB(StrNameLine2)
            StrNameLine3 = ReplaceDQ_PPLB(StrNameLine3)
            StrNameLine3 = ReplaceBS_PPLB(StrNameLine3)

            StrLengthinDot = StrLength * ItemNameFontSize_dot
            XPosExt = ((ItemNameMaxLengthperLine * ItemNameFontSize_dot) / 2) - (StrLengthinDot / 2)
            If ItemNameTextAlign = "CENTER" Then
                XPos = XStartPos + XPosExt
            Else
                XPos = XStartPos + XPosOffsetBarcodeItemName
            End If

            YPosExt = 2 + CompanyNameFontSize_dot + ItemCodeFontSize_dot + BSBarHeight
            YPos = YStartPos + YPosExt
            ItemNameFontSize_dot = (dpi * 6) / dpi_constant
            Call B_Prn_Text_TrueType(XPos, YPos, ItemNameFontSize_dot, ItemNameFontType, 1, 400, 0, 0, 0, "N1", StrNameLine1)


        End If

        'Print Price
        Dim ItemPriceFontSize_dot As Integer
        ItemPriceFontSize_dot = (dpi * ItemPriceFontSize) / dpi_constant

        XPos = XStartPos
        YPosExt = 2 + CompanyNameFontSize_dot + ItemCodeFontSize_dot + BSBarHeight + ItemNameFontSize_dot
        YPos = YStartPos + YPosExt
        If ItemPrice <> "RM 0.00" Then
            Call B_Prn_Text_TrueType(XPos, YPos, 40, ItemPriceFontType, 1, 400, 0, 0, 0, "IP", ItemPrice)
        End If

        'Print URL
        Dim URLFontSize_dot = (dpi * URLFontSize) / dpi_constant

        XPos = XStartPos
        If ItemPrice <> "RM 0.00" Then
            YPosExt = 2 + CompanyNameFontSize_dot + ItemCodeFontSize_dot + BSBarHeight + ItemNameFontSize_dot + 40
        Else
            YPosExt = 2 + CompanyNameFontSize_dot + ItemCodeFontSize_dot + BSBarHeight + ItemNameFontSize_dot
        End If


        YPos = YStartPos

        Call B_Prn_Text_TrueType(XPos, YPos, URLFontSize_dot, URLFontType, 1, 400, 0, 0, 0, "URL", URLText)



        'Call B_Print_Out(1)
        Call B_Print_MCopy(1, 3) 'labset,copies;
        Call B_ClosePrn()

        '35mm = 1.4" 25mm = 0.9", print speed = 2.0"/sec, print density = 15,
    End Sub

    'Printing using Intermec Direct Protocol (IDP)
    Public Sub doIDPPrintDirect(ByVal strbarcode As String, ByVal ItemName As String, ByVal ItemPrice As String, ByVal ItemQuality As String, ByVal ItemCode As String)



        'Define a starting X and Y position for the barcode
        Dim XStartPos As Integer = 2
        Dim YStartPos As Integer = 4
        Dim XPos As Integer
        Dim YPos As Integer
        Dim YPosExt As Integer = 0
        Dim XPosExt As Integer = 0

        'font info
        Dim dpi As Integer = 300
        Dim dpi_constant As Integer = 72

        Dim lhPrinter As New System.IntPtr()
        Dim di As New DirectPrinter.DOCINFOW()
        Dim pcWritten As Integer = 0
        Dim st1 As String
        ' text to print with a form feed character
        st1 = "This is an example of printing directly to a printer" + ControlChars.FormFeed
        di.pDocName = "my test document"
        di.pOutputFile = ""
        di.pDataType = "RAW"
        ' the \x1b means an ascii escape character
        st1 = ChrW(27) + "*c600a6b0P" + ControlChars.FormFeed
        'lhPrinter contains the handle for the printer opened
        'If lhPrinter is 0 then an error has occured
        DirectPrinter.OpenPrinter(PrinterName, lhPrinter, 0)
        DirectPrinter.StartDocPrinter(lhPrinter, 1, di)
        DirectPrinter.StartPagePrinter(lhPrinter)

        'DirectPrinter.WritePrinter(lhPrinter, st1, st1.Length, pcWritten)
        st1 = "INPUT ON" + ControlChars.Cr 'Enable Intermec Direct Protocol Mode
        DirectPrinter.WritePrinter(lhPrinter, st1, st1.Length, pcWritten)

        st1 = "SETSTDIO 6,6" + ControlChars.Cr 'Set Standard Input/Output, 6=usb1
        DirectPrinter.WritePrinter(lhPrinter, st1, st1.Length, pcWritten)

        st1 = "SYSVAR(37) =12" + ControlChars.Cr 'Minimum Gap Length 12 dots
        DirectPrinter.WritePrinter(lhPrinter, st1, st1.Length, pcWritten)

        st1 = "BF ON" + ControlChars.Cr
        DirectPrinter.WritePrinter(lhPrinter, st1, st1.Length, pcWritten)

        st1 = "BF""Swiss 721 BT"",6" + ControlChars.Cr
        DirectPrinter.WritePrinter(lhPrinter, st1, st1.Length, pcWritten)

        st1 = "PP 75,170" + ControlChars.Cr
        DirectPrinter.WritePrinter(lhPrinter, st1, st1.Length, pcWritten)

        st1 = "BT ""CODE39""" + ControlChars.Cr
        DirectPrinter.WritePrinter(lhPrinter, st1, st1.Length, pcWritten)

        st1 = "PB ""ABC""" + ControlChars.Cr
        DirectPrinter.WritePrinter(lhPrinter, st1, st1.Length, pcWritten)

        st1 = "PP 75,120" + ControlChars.Cr
        DirectPrinter.WritePrinter(lhPrinter, st1, st1.Length, pcWritten)

        st1 = "FT ""Swiss 721 BT"",6" + ControlChars.Cr
        DirectPrinter.WritePrinter(lhPrinter, st1, st1.Length, pcWritten)

        st1 = "PT ""My FIRST Label""" + ControlChars.Cr
        DirectPrinter.WritePrinter(lhPrinter, st1, st1.Length, pcWritten)

        st1 = "PF" + ControlChars.Cr 'Print one label
        DirectPrinter.WritePrinter(lhPrinter, st1, st1.Length, pcWritten)


        '203dpi => 1mm = 8dots
        '300dpi => 1mm = 12dots
        '1 Point = 1/72 inch
        'Call openport(PrintDialog1.PrinterSettings.PrinterName) '"TSC TTP-243(E) - (V)")
        'Call B_CreatePrn(1, 0)

        'Call B_Select_Symbol2(8, "5", 1)
        'Call B_Set_Speed(CInt(LSPrintSpeed)) '0/1-7ips
        'Call B_Set_Darkness(CInt(LSPrintDensity)) '0-15, default=8
        'Call B_Select_Option(1) '1 -> thermal transfer, disable Cutter and Peel.

        '1 millimeter = 0.0393700787 inch
        'Call B_Set_Labwidth(354) 'Label width in dots. 30mm=30*0.0393700787=1.1811', 1.1811*300=354.33
        'Call B_Set_Labgap(319, 35) 'lablength, gaplength; length = 27mm=1.063', 1.063*300=318.9, gap = 3mm=0.11811'*300=35.43



        DirectPrinter.EndPagePrinter(lhPrinter)
        DirectPrinter.EndDocPrinter(lhPrinter)
        DirectPrinter.ClosePrinter(lhPrinter)
    End Sub



    Public Function ReplaceDQ_PPLB(ByVal strNameLine As String) As String
        Dim oldDQ As String = Chr(34) 'Double Quote Chr(34) = "
        Dim newDQ As String = "\" & Chr(34)

        If strNameLine.IndexOf(oldDQ) Then
            Return strNameLine.Replace(oldDQ, newDQ)
        End If
        Return strNameLine
    End Function

    Public Function ReplaceBS_PPLB(ByVal strNameLine As String) As String
        Dim oldBS As String = Chr(92) 'Back slash Chr(92) = \
        Dim newBS As String = "\\"

        If strNameLine.IndexOf(oldBS) Then
            Return strNameLine.Replace(oldBS, newBS)
        End If
        Return strNameLine
    End Function

    Public Function GetTSCFontHeight(ByVal FontType As String) As Integer
        Dim Font1Height As Integer = 12
        Dim Font2Height As Integer = 20
        Dim Font3Height As Integer = 24
        Dim Font4Height As Integer = 32
        Dim Font5Height As Integer = 48
        Dim ReturnHeight As Integer = 12

        Select Case FontType
            Case "1"
                ReturnHeight = Font1Height
            Case "2"
                ReturnHeight = Font2Height
            Case "3"
                ReturnHeight = Font3Height
            Case "4"
                ReturnHeight = Font4Height
            Case "5"
                ReturnHeight = Font5Height

            Case Else
                ReturnHeight = Font1Height
                Exit Select
        End Select

        Return ReturnHeight
    End Function

    Public Function GetTSCFontWidth(ByVal FontType As String) As Integer
        Dim Font1Width As Integer = 8
        Dim Font2Width As Integer = 12
        Dim Font3Width As Integer = 16
        Dim Font4Width As Integer = 24
        Dim Font5Width As Integer = 32

        Dim ReturnWidth As Integer = 12

        Select Case FontType
            Case "1"
                ReturnWidth = Font1Width
            Case "2"
                ReturnWidth = Font2Width
            Case "3"
                ReturnWidth = Font3Width
            Case "4"
                ReturnWidth = Font4Width
            Case "5"
                ReturnWidth = Font5Width

            Case Else
                ReturnWidth = Font1Width
                Exit Select
        End Select

        Return ReturnWidth

    End Function

    ' Break the Item Name to specific length.
    Public Function BreakItemName(ByVal item_name As String, ByVal max_len As Integer) As String()
        Dim indent As String
        Dim good_space As Long
        Dim result As String
        Dim j As Long
        Dim min_length As Integer
        Dim arr_result(50) As String
        Dim arr_pointer As Integer = 0

        ' See how much the line is indented.
        indent = Space$(Len(item_name) - Len(Trim$(item_name)))

        ' Don't break within this many characters of
        ' the start of the string.
        min_length = Len(indent)

        ' Trim the line until it fits.
        Do While Len(item_name) > max_len
            ' Find the space closest to the maximum character.
            good_space = InStrRev(item_name, " ", max_len)

            ' Do not break too soon.
            If good_space <= min_length Then good_space = 0

            ' If there are no spaces before MAX_LEN, look after.
            If good_space = 0 Then
                good_space = InStr(max_len, item_name, " ")
            End If

            If good_space = 0 Then
                ' No good spaces. Display the rest at once.
                Exit Do
            Else
                ' Break the code.
                result = result & vbCrLf & Strings.Left$(item_name, good_space - 1) & " _"

                arr_result(arr_pointer) = Strings.Left(item_name, good_space - 1)
                arr_pointer = arr_pointer + 1
                item_name = indent & Trim$(Mid$(item_name, good_space))

            End If 'If good_space = 0 Then
        Loop

        ' Add the last piece of code.
        result = result & vbCrLf & item_name
        arr_result(arr_pointer) = item_name
        Return arr_result

        If Len(result) > 0 Then
            'BreakItemName = Mid$(result, Len(vbCrLf) + 1)
            result = Mid$(result, Len(vbCrLf) + 1)
        Else
            'BreakItemName = result
            result = result
        End If
    End Function

#End Region

#Region "Workspace Button Handlers"
    Private Sub GenerateLabelsButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GenerateLabelsButton.Click

        'doPrintNow(txtGRNCode.Text)


        Dim index As Integer
        Dim BcodeFrItemCode As String
        Dim QtyFrItemCode As String
        Dim NameFrItemCode As String
        Dim PriceFrItemCode As String
        Dim ItmCodeFrItemCode As String

        Dim PriceCheckedBy As String
        Dim Barcode1 As String
        Dim Barcode2 As String
        Dim Barcode3 As String
        Dim Barcode4 As String

        If lvItemInfo.Items.Count() > 0 Then
            For index = 0 To lvItemInfo.Items.Count() - 1

                If lvItemInfo.Items(index).Checked = True Then
                    Dim bItem As BarcodeItem = DirectCast(lvItemInfo.Items(index).Tag, BarcodeItem)
                    QtyFrItemCode = lvItemInfo.Items(index).SubItems(0).Text
                    ItmCodeFrItemCode = lvItemInfo.Items(index).SubItems(1).Text
                    BcodeFrItemCode = lvItemInfo.Items(index).SubItems(2).Text
                    NameFrItemCode = lvItemInfo.Items(index).SubItems(3).Text
                    'PriceCheckedBy = lvItemInfo.Items(index).SubItems(4).Text
                    PriceFrItemCode = lvItemInfo.Items(index).SubItems(5).Text
                    Barcode1 = lvItemInfo.Items(index).SubItems(6).Text
                    Barcode2 = lvItemInfo.Items(index).SubItems(7).Text
                    Barcode3 = lvItemInfo.Items(index).SubItems(8).Text
                    Barcode4 = lvItemInfo.Items(index).SubItems(9).Text

                    If CInt(QtyFrItemCode) > 0 Then
                        Select Case Customer
                            Case 0 '
                                If ItmCodeFrItemCode <> "" Then
                                    doPrintNow(BcodeFrItemCode, NameFrItemCode, PriceFrItemCode, ItmCodeFrItemCode)
                                    'doPrintActive()
                                Else
                                    MsgBox("No Item Code")
                                End If
                            Case 1 ' Jayacom
                                If BcodeFrItemCode <> "" Or ItmCodeFrItemCode <> "" Then
                                    'For PrintCnt As Integer = 0 To CInt(QtyFrItemCode) - 1
                                    If PrinterProgrammingLanguage = "TSC" Then
                                        ' PYT-4
                                        doTSCPrintDirect(bItem.EANCode, bItem.ItemName, bItem.getDisplayPrice, bItem.Qty.ToString, bItem.ItemCode, _
                                                         bItem.PriceChecked, bItem.Category2, bItem.Category3, bItem.Category4, bItem.Category5, bItem.Category6)
                                        If bItem.PrintPage2 Then
                                            doTSCPrintDirect(bItem.EANCode, bItem.ItemName, "", bItem.Qty.ToString, bItem.ItemCode, _
                                                         bItem.PriceChecked, bItem.Category7, bItem.Category8, bItem.Category9, bItem.Category10, "")

                                        End If


                                    ElseIf PrinterProgrammingLanguage = "PPLB" Then
                                        doPPLBPrintDirect(BcodeFrItemCode, NameFrItemCode, PriceFrItemCode, QtyFrItemCode, ItmCodeFrItemCode)
                                    ElseIf PrinterProgrammingLanguage = "IDP" Then
                                        doIDPPrintDirect(BcodeFrItemCode, NameFrItemCode, PriceFrItemCode, QtyFrItemCode, ItmCodeFrItemCode)
                                    End If
                                    'Next
                                Else
                                    MsgBox("No Barcode/Item Code")
                                End If
                            Case Else
                                Exit Select
                        End Select

                    Else
                        MsgBox("Quantity is not correct")
                    End If
                End If
            Next

        End If


    End Sub

    Private Sub printConfigButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles printConfigButton.Click
        PrintDialog1.ShowDialog(Me)
        Label2.Text = "Printer : " & PrintDialog1.PrinterSettings.PrinterName
        PrinterName = PrintDialog1.PrinterSettings.PrinterName
        'Write_Setting()
    End Sub

    Private Sub printPreviewButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles printPreviewButton.Click
        m_PrintDocument = New Printing.PrintDocument
        m_PrintDocument.PrinterSettings = PrintDialog1.PrinterSettings
        m_PrintDocument.DefaultPageSettings.Color = False
        m_PrintDocument.DefaultPageSettings.Margins = New System.Drawing.Printing.Margins(2.5, 2.5, 2.5, 2.5)
        PreviewPrint.Document = m_PrintDocument
        PreviewPrint.ShowDialog()
    End Sub


    Private Sub btnSelectAllRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectAllRow.Click

        Dim index As Integer
        If btnSelectedClicked = False Then
            If lvItemInfo.Items.Count() > 0 Then
                For index = 0 To lvItemInfo.Items.Count() - 1

                    lvItemInfo.Items(index).Selected = True
                    lvItemInfo.Items(index).Checked = True
                Next
                btnSelectedClicked = True
                btnSelectAllRow.Text = "UnCheck All Items"
            End If
        Else
            If lvItemInfo.Items.Count() > 0 Then
                For index = 0 To lvItemInfo.Items.Count() - 1

                    lvItemInfo.Items(index).Selected = False
                    lvItemInfo.Items(index).Checked = False
                Next
                btnSelectedClicked = False
                btnSelectAllRow.Text = "Check All Items"
            End If

        End If


        'Application.DoEvents()
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        Dim cbSelectedIndex As Integer = 0

        'lvItemInfo.Items.Clear()
        If lvItemInfo.Items.Count() > 0 Then
            'For index = 0 To lvItemInfo.Items.Count() - 1
            For index As Integer = lvItemInfo.Items.Count - 1 To 0 Step -1
                If lvItemInfo.Items(index).Checked = False Then
                    lvItemInfo.Items(index).Remove()
                End If
            Next
        End If


        lvItemInfo.LabelEdit = True

        If btnSelectedClicked = True Then
            btnSelectedClicked = False
            btnSelectAllRow.Text = "Check All Items"
        End If
        cbSelectedIndex = cbxSeachBy.SelectedIndex
        lbStatus.Text = ""
        Select Case cbSelectedIndex
            Case 0  'GRN
                lbStatus.Text = "Status :Searching ...GRN " & txtGRNCode.Text
                lbStatus.Update()
                DynamicSearchbyGRN()
            Case 1  'ItemCode
                lbStatus.Text = "Status :Searching ...Item Code " & txtGRNCode.Text
                lbStatus.Update()
                DynamicSearchbyItemCode()
            Case 2  'EANCode
                lbStatus.Text = "Status :Searching ...EAN Code " & txtGRNCode.Text
                lbStatus.Update()
                DynamicSearchbyEANCode()
            Case 3   'Fuzzy
                lbStatus.Text = "Status :Searching ...Fuzzy "
                lbStatus.Update()
                DynamicSearchbyFuzzy()
            Case Else 'GRN
                lbStatus.Text = "Status :Searching ...GRN " & txtGRNCode.Text
                lbStatus.Update()
                DynamicSearchbyGRN()
        End Select


        'Dim itemcode As Integer = 1001
        'For i As Integer = 0 To 2
        'lvItemInfo.Items.Add(itemcode)
        'lvItemInfo.Items(i).SubItems.Add("2002819131844")
        'lvItemInfo.Items(i).SubItems.Add("SAMSUNG DVDRW 22X_BLACK")
        'lvItemInfo.Items(i).SubItems.Add("samples description")
        'lvItemInfo.Items(i).SubItems.Add("1")
        'lvItemInfo.Items(i).SubItems.Add("RM110.00")
        'itemcode = itemcode + 1
        'Next


    End Sub

    Private Sub txtGRNCode_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtGRNCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSearch_Click(sender, e)
        End If
    End Sub

    Sub SearchbyGRN()
        Try
            Dim note As goodsReceivedNoteObject
            Dim itmObj As itemObject

            If txtGRNCode.Text <> "" Then
                lvItemInfo.UseWaitCursor = True
                note = CoreClient.getGoodsReceivedNote(txtGRNCode.Text)
                Dim count As Integer = 0
                Dim list As Array

                'If Not DBNull.Value.Equals(note.vecGRNItems) Then
                If note.vecGRNItems.Length > 0 Then
                    list = note.vecGRNItems
                    For Each item As goodsReceivedNoteItemObject In list


                        itmObj = CoreClient.getItemByCode(item.mStkCode)

                        lvItemInfo.Items.Add(CInt(item.mTotalQty))           'Quatity
                        lvItemInfo.Items(count).SubItems.Add(itmObj.code)    'Item Code
                        lvItemInfo.Items(count).SubItems.Add(itmObj.EANCode) ' Barcode
                        lvItemInfo.Items(count).SubItems.Add(itmObj.name)       'Item Name
                        lvItemInfo.Items(count).SubItems.Add(Format(itmObj.priceList, "RM 0.00"))   'Price

                        count = count + 1
                    Next
                    lbStatus.Text = "Status :GRN code Found [" & txtGRNCode.Text & "]"
                Else
                    lbStatus.Text = "Status :Cannot Find GRN code from server."
                End If
            End If

        Catch ex As Exception
            lbStatus.Text = "Status :Failed to connect to server."
        End Try
        lvItemInfo.UseWaitCursor = False
    End Sub


    Sub DynamicSearchbyGRN()
        Try
            Dim note As [Object] = Nothing
            Dim itmObj As [Object] = Nothing

            If txtGRNCode.Text <> "" Then
                lvItemInfo.UseWaitCursor = True
                note = wsGetMethod("getGoodsReceivedNote", txtGRNCode.Text)

                Dim count As Integer = 0
                Dim list As Array

                'If Not DBNull.Value.Equals(note.vecGRNItems) Then
                If note.vecGRNItems.Length > 0 Then
                    list = note.vecGRNItems
                    Dim item As [Object] = wsGetMethod("goodsReceivedNoteItemObject", "")
                    For Each item In list

                        itmObj = wsGetMethod("getItemByCode", item.mStkCode)

                        'lvItemInfo.Items.Add(CInt(item.mTotalQty))           'Quatity
                        'lvItemInfo.Items(count).SubItems.Add(itmObj.code)    'Item Code
                        'lvItemInfo.Items(count).SubItems.Add(itmObj.EANCode) ' Barcode
                        'lvItemInfo.Items(count).SubItems.Add(itmObj.name)       'Item Name
                        'lvItemInfo.Items(count).SubItems.Add("")
                        'lvItemInfo.Items(count).SubItems.Add(Format(itmObj.priceList, "RM 0.00"))   'Price
                        'lvItemInfo.Items(count).SubItems.Add(itmObj.category1)
                        'lvItemInfo.Items(count).SubItems.Add(itmObj.category2)
                        'lvItemInfo.Items(count).SubItems.Add(itmObj.category3)
                        'Dim str As String = itmObj.category4
                        'If str.Length <> 0 Then
                        '    str = str & "/" & itmObj.category5
                        'End If
                        'lvItemInfo.Items(count).SubItems.Add(str)
                        'count = count + 1

                        Dim bItem As BarcodeItem = getBarcodeItem(itmObj)
                        AddItemToList(bItem)
                    Next
                    lbStatus.Text = "Status :GRN code Found [" & txtGRNCode.Text & "]"
                Else
                    lbStatus.Text = "Status :Cannot Find GRN code from server."
                End If
            End If

        Catch ex As Exception
            lbStatus.Text = "Status : Cannot Find GRN Code"
        End Try
        lvItemInfo.UseWaitCursor = False
    End Sub

    Sub SearchbyItemCode()
        Try
            Dim itmObj As itemObject
            If txtGRNCode.Text <> "" Then
                lvItemInfo.UseWaitCursor = True
                itmObj = CoreClient.getItemByCode(txtGRNCode.Text)
                Dim count As Integer = 0

                lvItemInfo.Items.Add(CInt(itmObj.outQty))             'Quatity
                lvItemInfo.Items(count).SubItems.Add(itmObj.code)    'Item Code
                lvItemInfo.Items(count).SubItems.Add(itmObj.EANCode) ' Barcode
                lvItemInfo.Items(count).SubItems.Add(itmObj.name)       'Item Name
                lvItemInfo.Items(count).SubItems.Add(Format(itmObj.priceList, "RM 0.00"))   'Price

                If itmObj.name <> "" Then
                    lbStatus.Text = "Status :Item code Found [" & txtGRNCode.Text & "]"
                Else
                    lbStatus.Text = "Status :Cannot Find Item code from server."
                End If
            End If

        Catch ex As Exception
            lbStatus.Text = "Status :Failed to connect to server."
        End Try
        lvItemInfo.UseWaitCursor = False
    End Sub

    Sub DynamicSearchbyItemCode()
        Try
            Dim itmObj As [Object] = Nothing
            If txtGRNCode.Text <> "" Then
                lvItemInfo.UseWaitCursor = True
                itmObj = wsGetMethod("getItemByCode", txtGRNCode.Text)

                'Dim count As Integer = 0

                'lvItemInfo.Items.Add(CInt(itmObj.outQty))             'Quatity
                'lvItemInfo.Items(count).SubItems.Add(itmObj.code)    'Item Code
                'lvItemInfo.Items(count).SubItems.Add(itmObj.EANCode) ' Barcode
                'lvItemInfo.Items(count).SubItems.Add(itmObj.name)       'Item Name
                'lvItemInfo.Items(count).SubItems.Add("")                ' By
                'lvItemInfo.Items(count).SubItems.Add(Format(itmObj.priceList, "RM 0.00"))   'Price
                'lvItemInfo.Items(count).SubItems.Add(itmObj.category1)
                'lvItemInfo.Items(count).SubItems.Add(itmObj.category2)
                'lvItemInfo.Items(count).SubItems.Add(itmObj.category3)
                'Dim str As String = itmObj.category4
                'If str.Length <> 0 Then
                '    str = str & "/" & itmObj.category5
                'End If
                'lvItemInfo.Items(count).SubItems.Add(str)

                Dim bItem As BarcodeItem = getBarcodeItem(itmObj)
                AddItemToList(bItem)

                If itmObj.name <> "" Then
                    lbStatus.Text = "Status :Item code Found [" & txtGRNCode.Text & "]"
                Else
                    lbStatus.Text = "Status :Cannot Find Item code from server."
                End If
            End If

        Catch ex As Exception
            lbStatus.Text = "Status :Cannot Find Item code."
        End Try
        lvItemInfo.UseWaitCursor = False
    End Sub

    Sub SearchbyEANCode()
        Try
            Dim itmObj As itemObject
            If txtGRNCode.Text <> "" Then
                lvItemInfo.UseWaitCursor = True
                itmObj = CoreClient.getItemByEANCode(txtGRNCode.Text)
                Dim count As Integer = 0

                lvItemInfo.Items.Add(CInt(itmObj.outQty))             'Quatity
                lvItemInfo.Items(count).SubItems.Add(itmObj.code)    'Item Code
                lvItemInfo.Items(count).SubItems.Add(itmObj.EANCode) ' Barcode
                lvItemInfo.Items(count).SubItems.Add(itmObj.name)       'Item Name
                lvItemInfo.Items(count).SubItems.Add(Format(itmObj.priceList, "RM 0.00"))   'Price

                If itmObj.name <> "" Then
                    lbStatus.Text = "Status :EAN code Found [" & txtGRNCode.Text & "]"
                Else
                    lbStatus.Text = "Status :Cannot Find EAN code from server."
                End If

            End If

        Catch ex As Exception
            lbStatus.Text = "Status :Failed to connect to server."
        End Try
        lvItemInfo.UseWaitCursor = False
    End Sub

    Sub DynamicSearchbyEANCode()
        Try
            Dim itmObj As [Object] = Nothing
            If txtGRNCode.Text <> "" Then
                lvItemInfo.UseWaitCursor = True
                itmObj = wsGetMethod("getItemByEANCode", txtGRNCode.Text)

                'Dim count As Integer = 0

                'lvItemInfo.Items.Add(CInt(itmObj.outQty))             'Quatity
                'lvItemInfo.Items(count).SubItems.Add(itmObj.code)    'Item Code
                'lvItemInfo.Items(count).SubItems.Add(itmObj.EANCode) ' Barcode
                'lvItemInfo.Items(count).SubItems.Add(itmObj.name)       'Item Name
                'lvItemInfo.Items(count).SubItems.Add("")
                'lvItemInfo.Items(count).SubItems.Add(Format(itmObj.priceList, "RM 0.00"))   'Price
                'lvItemInfo.Items(count).SubItems.Add(itmObj.category1)
                'lvItemInfo.Items(count).SubItems.Add(itmObj.category2)
                'lvItemInfo.Items(count).SubItems.Add(itmObj.category3)
                'Dim str As String = itmObj.category4
                'If str.Length <> 0 Then
                '    str = str & "/" & itmObj.category5
                'End If
                'lvItemInfo.Items(count).SubItems.Add(str)

                Dim bItem As BarcodeItem = getBarcodeItem(itmObj)
                AddItemToList(bItem)

                If itmObj.name <> "" Then
                    lbStatus.Text = "Status :EAN code Found [" & txtGRNCode.Text & "]"
                Else
                    lbStatus.Text = "Status :Cannot Find EAN code from server."
                End If

            End If

        Catch ex As Exception
            lbStatus.Text = "Status :Cannot Find EAN code."
        End Try
        lvItemInfo.UseWaitCursor = False
    End Sub


    Sub SearchbyFuzzy()
        Try
            Dim itmObjArray As itemObject()
            If txtGRNCode.Text <> "" Then
                lvItemInfo.UseWaitCursor = True
                itmObjArray = CoreClient.getItemFuzzySearch(txtGRNCode.Text)
                Dim cntlist As Integer
                Dim count As Integer = 0

                If itmObjArray.Length > 0 Then
                    For cntlist = 0 To itmObjArray.Length - 1
                        lvItemInfo.Items.Add(CInt(itmObjArray(cntlist).outQty)) 'Quatity
                        lvItemInfo.Items(count).SubItems.Add(itmObjArray(cntlist).code)    'Item Code
                        lvItemInfo.Items(count).SubItems.Add(itmObjArray(cntlist).EANCode) ' Barcode
                        lvItemInfo.Items(count).SubItems.Add(itmObjArray(cntlist).name)       'Item Name
                        lvItemInfo.Items(count).SubItems.Add(Format(itmObjArray(cntlist).priceList, "RM 0.00"))   'Price
                        count = count + 1
                    Next
                End If

                If itmObjArray(0).name <> "" Then
                    lbStatus.Text = "Status :Item code Found [" & txtGRNCode.Text & "]"
                Else
                    lbStatus.Text = "Status :Cannot Find Item code from server."
                End If
            End If

        Catch ex As Exception
            lbStatus.Text = "Status :Failed to connect to server."
        End Try
        lvItemInfo.UseWaitCursor = False
    End Sub

    Sub DynamicSearchbyFuzzy()
        Try
            Dim itmObjArray As [Object]() = Nothing

            If txtGRNCode.Text <> "" Then
                lvItemInfo.UseWaitCursor = True

                itmObjArray = wsGetMethod("getItemFuzzySearch", txtGRNCode.Text)

                Dim cntlist As Integer
                Dim count As Integer = 0

                If itmObjArray.Length > 0 Then
                    For cntlist = 0 To itmObjArray.Length - 1
                        'lvItemInfo.Items.Add(CInt(itmObjArray(cntlist).outQty)) 'Quatity
                        'lvItemInfo.Items(count).SubItems.Add(itmObjArray(cntlist).code)    'Item Code
                        'lvItemInfo.Items(count).SubItems.Add(itmObjArray(cntlist).EANCode) ' Barcode
                        'lvItemInfo.Items(count).SubItems.Add(itmObjArray(cntlist).name)       'Item Name
                        'lvItemInfo.Items(count).SubItems.Add("")
                        'lvItemInfo.Items(count).SubItems.Add(Format(itmObjArray(cntlist).priceList, "RM 0.00"))   'Price
                        'lvItemInfo.Items(count).SubItems.Add(itmObjArray(cntlist).category1)
                        'lvItemInfo.Items(count).SubItems.Add(itmObjArray(cntlist).category2)
                        'lvItemInfo.Items(count).SubItems.Add(itmObjArray(cntlist).category3)
                        'Dim str As String = itmObjArray(cntlist).category4
                        'If str.Length <> 0 Then
                        '    str = str & "/" & itmObjArray(cntlist).category5
                        'End If
                        'lvItemInfo.Items(count).SubItems.Add(str)
                        'count = count + 1

                        Dim bItem As BarcodeItem = getBarcodeItem(itmObjArray(cntlist))
                        AddItemToList(bItem)
                    Next
                End If

                If itmObjArray(0).name <> "" Then
                    lbStatus.Text = "Status :Item code Found [" & txtGRNCode.Text & "]"
                Else
                    lbStatus.Text = "Status :Cannot Find Item code from server."
                End If
            End If

        Catch ex As Exception
            lbStatus.Text = "Status :Cannot Find Item code."
        End Try
        lvItemInfo.UseWaitCursor = False
    End Sub

    Private Sub btEditItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btEditItem.Click
        Dim index As Integer
        Dim item As BarcodeItem = Nothing
        Dim lvItem As ListViewItem = Nothing

        If lvItemInfo.Items.Count > 0 Then
            For index = 0 To lvItemInfo.Items.Count() - 1
                If lvItemInfo.Items(index).Selected = True Then
                    lvItem = lvItemInfo.Items(index)
                    item = DirectCast(lvItem.Tag, BarcodeItem)
                End If
            Next
        End If

        If lvItem Is Nothing Then Exit Sub

        Dim boxEditItem As New AddItemBoxFrm

        With item
            boxEditItem.txItemQuantity.Text = lvItem.SubItems(0).Text
            boxEditItem.txItemCode.Text = .ItemCode
            boxEditItem.txEANCode.Text = .EANCode
            boxEditItem.txItemName.Text = .ItemName
            boxEditItem.cboPriceCheked.Text = .PriceChecked
            boxEditItem.txItemPrice.Text = .Price
            If .Category1 <> "" Then
                boxEditItem.txItemPrice.Text = .Category1
            End If

            'boxEditItem.txtCategory1.Text = .Category1
            boxEditItem.txtCategory2.Text = .Category2
            boxEditItem.txtCategory3.Text = .Category3
            boxEditItem.txtCategory4.Text = .Category4
            boxEditItem.txtCategory5.Text = .Category5
            boxEditItem.txtCategory6.Text = .Category6
            boxEditItem.txtCategory7.Text = .Category7
            boxEditItem.txtCategory8.Text = .Category8
            boxEditItem.txtCategory9.Text = .Category9
            boxEditItem.txtCategory10.Text = .Category10
            boxEditItem.chkPrintPage2.Checked = .PrintPage2
        End With

        If (boxEditItem.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            If boxEditItem.txItemCode.Text <> "" And lvItemInfo.Items.Count > 0 Then

                With item
                    .ItemCode = boxEditItem.txItemCode.Text.Trim
                    .EANCode = boxEditItem.txEANCode.Text.Trim
                    .ItemName = boxEditItem.txItemName.Text.Trim
                    .PriceChecked = boxEditItem.cboPriceCheked.Text
                    .Price = boxEditItem.txItemPrice.Text.Trim
                    '.Category1 = boxEditItem.txtCategory1.Text.Trim
                    .Category2 = boxEditItem.txtCategory2.Text.Trim
                    .Category3 = boxEditItem.txtCategory3.Text.Trim
                    .Category4 = boxEditItem.txtCategory4.Text.Trim
                    .Category5 = boxEditItem.txtCategory5.Text.Trim
                    .Category6 = boxEditItem.txtCategory6.Text.Trim
                    .Category7 = boxEditItem.txtCategory7.Text.Trim
                    .Category8 = boxEditItem.txtCategory8.Text.Trim
                    .Category9 = boxEditItem.txtCategory9.Text.Trim
                    .Category10 = boxEditItem.txtCategory10.Text.Trim
                    .PrintPage2 = boxEditItem.chkPrintPage2.Checked
                End With

                lvItem.Tag = item
                lvItem.SubItems(0).Text = (CInt(boxEditItem.txItemQuantity.Text))
                lvItem.SubItems(1).Text = boxEditItem.txItemCode.Text
                lvItem.SubItems(2).Text = boxEditItem.txEANCode.Text
                lvItem.SubItems(3).Text = boxEditItem.txItemName.Text
                'lvItem.SubItems(4).Text = boxEditItem.cboPriceCheked.Text
                lvItem.SubItems(4).Text = boxEditItem.txItemPrice.Text
                lvItem.SubItems(5).Text = boxEditItem.txtCategory2.Text
                lvItem.SubItems(6).Text = boxEditItem.txtCategory3.Text
                lvItem.SubItems(7).Text = boxEditItem.txtCategory4.Text
                lvItem.SubItems(8).Text = boxEditItem.txtCategory5.Text
                lvItem.SubItems(9).Text = boxEditItem.txtCategory6.Text
            End If
        End If


    End Sub

    Private Sub btAddItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAddItem.Click

        'If lvItemInfo.Items.Count > 0 Then
        '    If AddItemCount = 0 Then
        '        AddItemCount = lvItemInfo.Items.Count
        '    End If
        'End If

        Dim boxAddItem As New AddItemBoxFrm
        If (boxAddItem.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            If boxAddItem.txItemCode.Text <> "" Then

                Dim item As New BarcodeItem
                With item
                    .ItemCode = boxAddItem.txItemCode.Text.Trim
                    .EANCode = boxAddItem.txEANCode.Text.Trim
                    .ItemName = boxAddItem.txItemName.Text.Trim
                    .PriceChecked = boxAddItem.cboPriceCheked.Text
                    .Price = boxAddItem.txItemPrice.Text.Trim
                    '.Category1 = boxAddItem.txtCategory1.Text.Trim
                    .Category2 = boxAddItem.txtCategory2.Text.Trim
                    .Category3 = boxAddItem.txtCategory3.Text.Trim
                    .Category4 = boxAddItem.txtCategory4.Text.Trim
                    .Category5 = boxAddItem.txtCategory5.Text.Trim
                    .Category6 = boxAddItem.txtCategory6.Text.Trim
                    .Category7 = boxAddItem.txtCategory7.Text.Trim
                    .Category8 = boxAddItem.txtCategory8.Text.Trim
                    .Category9 = boxAddItem.txtCategory9.Text.Trim
                    .Category10 = boxAddItem.txtCategory10.Text.Trim
                    .PrintPage2 = boxAddItem.chkPrintPage2.Checked
                End With

                AddItemToList(item)

            End If
        End If


    End Sub
    Private Sub btnClearItems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearItems.Click
        lvItemInfo.Items.Clear()
    End Sub


    Private Sub btnTSCPrinterFF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTSCPrinterFF.Click
        'FormFeed for Printer
        '203dpi => 1mm = 8dots
        'Call openport(PrintDialog1.PrinterSettings.PrinterName) '"TSC TTP-243(E) - (V)")
        Call openport(PrinterName)
        '35mm = 1.4" 25mm = 0.9", print speed = 2.0"/sec, print density = 15,
        'sensor type = 0 = vertical gap sensor, vertical gap height = 0.12" = 3.048, shift dist = 0mm
        Call setup(LSWidth, LSHeight, LSPrintSpeed, LSPrintDensity, "0", LSVerticalgap, "0")
        Call clearbuffer()
        Call sendcommand("DIRECTION 1")
        Call sendcommand("SET CUTTER OFF") ' Or the number of printout per cut'
        Call sendcommand("SET PEEL OFF")
        Call sendcommand("HOME") '"FORMFEED") '"HOME") 'This will jump over one empty label

        'Disconnect with the printer'
        Call closeport()

    End Sub

    Private Sub btnDownloadLogo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDownloadLogo.Click
        '203dpi => 1mm = 8dots
        Call openport(PrintDialog1.PrinterSettings.PrinterName) '"TSC TTP-243(E) - (V)")
        '35mm = 1.4" 25mm = 0.9", print speed = 2.0"/sec, print density = 15,
        'sensor type = 0 = vertical gap sensor, vertical gap height = 0.12" = 3.048, shift dist = 0mm
        Call setup(LSWidth, LSHeight, LSPrintSpeed, LSPrintDensity, "0", LSVerticalgap, "0")
        Call clearbuffer()
        Call sendcommand("DIRECTION 1")
        Call sendcommand("SET CUTTER OFF") ' Or the number of printout per cut'

        Dim putpcxpath As String
        putpcxpath = CompanyLogoFilename '"D:\BMP-PCX\LOGO.PCX" ' + 
        Call downloadpcx(putpcxpath, "LOGO.PCX")
        Call sendcommand("MOVE")

        'Disconnect with the printer'
        Call closeport()

    End Sub
#End Region

    Private Sub mainBarcodeWorkspace_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Read_Setting()
        'Write_Setting()

        Label2.Text = "Printer : " & PrinterName


        'Generate the hashtable of encoding values
        Select Case Customer
            Case 0 'Banzen
                StartWebServices()
                Wavelet_BarcodeC39()
                PictureBox1.Visible = True
                printPreviewButton.Visible = True
                _BarcodeYScale = 0.36 '0.3
            Case 1 'Jayacom
                StartWebServices()
                'Wavelet_BarcodeC128()
                'Disable for Jayacom 
                PictureBox1.Visible = False
                printPreviewButton.Visible = False
                _BarcodeYScale = 0.2
            Case Else
                CoreClient.Endpoint.Address = New System.ServiceModel.EndpointAddress("http://test.wavelet.biz:8888/ws/EMPCoreService?wsdl")
                PictureBox1.Visible = False
                printPreviewButton.Visible = False
                Exit Select
        End Select

        If CompanyLogoFilename = "" Then
            btnDownloadLogo.Visible = False
        End If

        lvItemInfo.UseWaitCursor = False
        cbxSeachBy.SelectedIndex = 0
        txtGRNCode.Focus()

        lbVersion.Text = "Version 0.17"

    End Sub

#Region "File Handling"
    Sub Read_Setting()
        'Read the setting from WBarcodeSetting.xml

        Dim WBarcodeSettingDoc As XmlDocument = New XmlDocument
        Dim WBarcodeSettingNodelist As XmlNodeList
        Dim WBarcodeSettingNode As XmlNode
        Dim strFilename As String = Path.Combine(Application.StartupPath, "WBarcodeSetting.xml")

        If (File.Exists(strFilename)) Then
            'Fastest way to load xml file
            WBarcodeSettingDoc.Load(strFilename)

            WBarcodeSettingNodelist = WBarcodeSettingDoc.SelectNodes("/Setting/WebServices")
            For Each WBarcodeSettingNode In WBarcodeSettingNodelist
                WebServicesAddress = WBarcodeSettingNode.ChildNodes.Item(0).InnerText 'Adress
                Customer = WBarcodeSettingNode.ChildNodes.Item(1).InnerText 'Customer
            Next

            WBarcodeSettingNodelist = WBarcodeSettingDoc.SelectNodes("/Setting/PrinterSetting")
            For Each WBarcodeSettingNode In WBarcodeSettingNodelist
                PrinterName = WBarcodeSettingNode.ChildNodes.Item(0).InnerText 'PrinterName
                PrinterProgrammingLanguage = WBarcodeSettingNode.ChildNodes.Item(1).InnerText 'PrinterProgrammingLanguage
            Next



            WBarcodeSettingNodelist = WBarcodeSettingDoc.SelectNodes("/Setting/Template")
            For Each WBarcodeSettingNode In WBarcodeSettingNodelist
                CompanyNameLine1 = WBarcodeSettingNode.ChildNodes.Item(0).InnerText 'Company name line 1
                CompanyNameLine2 = WBarcodeSettingNode.ChildNodes.Item(1).InnerText 'Company name line 2
                CompanyNameFontType = WBarcodeSettingNode.ChildNodes.Item(2).InnerText 'Company name Font type
                CompanyNameFontSize = WBarcodeSettingNode.ChildNodes.Item(3).InnerText 'Company name Font size
                CompanyLogoFilename = WBarcodeSettingNode.ChildNodes.Item(4).InnerText 'Company Logo file path
                ItemCodeFontType = WBarcodeSettingNode.ChildNodes.Item(5).InnerText 'Item Code Font Type
                ItemCodeFontSize = WBarcodeSettingNode.ChildNodes.Item(6).InnerText 'Item Code Font Size
                ItemNameTextAlign = WBarcodeSettingNode.ChildNodes.Item(7).InnerText 'Text align for item name when print out ' CENTER | LEFT
                ItemNameFontType = WBarcodeSettingNode.ChildNodes.Item(8).InnerText 'Item Name Font type
                ItemNameFontSize = WBarcodeSettingNode.ChildNodes.Item(9).InnerText 'Item Name Font size
                ItemNameMaxLengthperLine = WBarcodeSettingNode.ChildNodes.Item(10).InnerText 'Item Name Max length per line
                ItemPriceFontType = WBarcodeSettingNode.ChildNodes.Item(11).InnerText 'Item price Font type
                ItemPriceFontSize = WBarcodeSettingNode.ChildNodes.Item(12).InnerText 'Item price Font size
                BarcodeTextFontType = WBarcodeSettingNode.ChildNodes.Item(13).InnerText 'human readable barcode textBar
                XPosOffsetBarcodeItemName = WBarcodeSettingNode.ChildNodes.Item(14).InnerText 'Offset X-pos for barcode and item name
                URLFontType = WBarcodeSettingNode.ChildNodes.Item(15).InnerText 'URL font type
                URLFontSize = WBarcodeSettingNode.ChildNodes.Item(16).InnerText 'URL font size
                URLText = WBarcodeSettingNode.ChildNodes.Item(17).InnerText 'URL
                LabelYStartPos = WBarcodeSettingNode.ChildNodes.Item(18).InnerText 'Label Y Start Pos
                XPosOffsetBarcodeDoubleFormat = WBarcodeSettingNode.ChildNodes.Item(19).InnerText 'Barcode X-offset used for Double Format
                XPosOffsetBarcodeText = WBarcodeSettingNode.ChildNodes.Item(20).InnerText 'Barcode Text X-offset
                YPosOffsetItemPrice = WBarcodeSettingNode.ChildNodes.Item(21).InnerText 'ItemPrice Y-offset after Barcode Text
                XPosOffsetItemPrice = WBarcodeSettingNode.ChildNodes.Item(22).InnerText 'ItemPrice X-offset after Barcode Text
                ItemNameMaxRowLine = WBarcodeSettingNode.ChildNodes.Item(23).InnerText 'Max number of row or line for item name
                YPosGap = WBarcodeSettingNode.ChildNodes.Item(24).InnerText
            Next


            WBarcodeSettingNodelist = WBarcodeSettingDoc.SelectNodes("/Setting/Barcode")
            For Each WBarcodeSettingNode In WBarcodeSettingNodelist
                BarcodeXScale = WBarcodeSettingNode.ChildNodes.Item(0).InnerText 'BarcodeXScale
                BarcodeYScale = WBarcodeSettingNode.ChildNodes.Item(1).InnerText 'BarcodeYScale
                BSBarcodeType = WBarcodeSettingNode.ChildNodes.Item(2).InnerText 'BarcodeType
                BSBarHeight = WBarcodeSettingNode.ChildNodes.Item(3).InnerText 'BarHeight
                BSNarrowBarRatio = WBarcodeSettingNode.ChildNodes.Item(4).InnerText 'Barcode Narrow Bar Ratio
                BSWideBarRatio = WBarcodeSettingNode.ChildNodes.Item(5).InnerText 'Barcode Wide Bar Ratio
                BSEnableDoubleFormat = WBarcodeSettingNode.ChildNodes.Item(6).InnerText 'Enable double format for AllIt
                UseItemCode2PrintBarcode = WBarcodeSettingNode.ChildNodes.Item(7).InnerText 'Enable using itemcode to print barcode

            Next

            WBarcodeSettingNodelist = WBarcodeSettingDoc.SelectNodes("/Setting/LabelSetup")
            For Each WBarcodeSettingNode In WBarcodeSettingNodelist
                'Call setup(LSWidth, LSHeight, LSPrintSpeed, LSPrintDensity, "0", LSVerticalgap, "0")

                LSWidth = WBarcodeSettingNode.ChildNodes.Item(0).InnerText 'LabelWidth
                LSHeight = WBarcodeSettingNode.ChildNodes.Item(1).InnerText 'LabelHeight
                LSPrintSpeed = WBarcodeSettingNode.ChildNodes.Item(2).InnerText 'PrintSpeed
                LSPrintDensity = WBarcodeSettingNode.ChildNodes.Item(3).InnerText 'PrintDensity
                LSVerticalgap = WBarcodeSettingNode.ChildNodes.Item(4).InnerText 'VerticalGap

            Next

            'Dim rdrWBarcodeSetting As XmlTextReader = New XmlTextReader(strFilename)
            'Do
            'If (XmlNodeType.Element <> 0) And (rdrWBarcodeSetting.Name = "Barcode") Then _
            'BarcodeXScale = rdrWBarcodeSetting.ReadElementString("BarcodeXScale")
            'rdrWBarcodeSetting.ReadElementContentAsDouble(BarcodeXScale, "BarcodeXScale")
            'End If
            'Loop While rdrWBarcodeSetting.Read()
            'rdrWBarcodeSetting.Close()
        Else
            MsgBox("The file " & strFilename & " was not found.")
        End If

    End Sub
    Sub Write_Setting()
        Dim Writer As XmlTextWriter = New XmlTextWriter("WBarcodeSetting.xml", Encoding.UTF8)
        Writer.Formatting = Formatting.Indented

        Writer.WriteStartDocument()

        'Setting
        Writer.WriteStartElement("Setting")

        'WebServices setting
        Writer.WriteStartElement("WebServices")
        Writer.WriteElementString("Address", WebServicesAddress)
        Writer.WriteElementString("Customer", Customer)
        Writer.WriteEndElement()

        'Printer setting
        Writer.WriteStartElement("PrinterSetting")
        Writer.WriteElementString("PrinterName", PrinterName)
        Writer.WriteElementString("PrinterProgrammingLanguage", PrinterProgrammingLanguage)
        Writer.WriteEndElement()




        'Template setup
        Writer.WriteStartElement("Template")
        Writer.WriteElementString("CompanyNameLine1", CompanyNameLine1)
        Writer.WriteElementString("CompanyNameLine2", CompanyNameLine2)
        Writer.WriteElementString("CompanyNameFontType", CompanyNameFontType)
        Writer.WriteElementString("CompanyNameFontSize", CompanyNameFontSize)
        Writer.WriteElementString("CompanyLogoFilename", CompanyLogoFilename)

        Writer.WriteElementString("ItemCodeFontType", ItemCodeFontType)
        Writer.WriteElementString("ItemCodeFontSize", ItemCodeFontSize)

        Writer.WriteElementString("ItemNameTextAlign", ItemNameTextAlign)
        Writer.WriteElementString("ItemNameFontType", ItemNameFontType)
        Writer.WriteElementString("ItemNameFontSize", ItemNameFontSize)
        Writer.WriteElementString("ItemNameMaxLengthperLine", ItemNameMaxLengthperLine)

        Writer.WriteElementString("ItemPriceFontType", ItemPriceFontType)
        Writer.WriteElementString("ItemPriceFontSize", ItemPriceFontSize)

        Writer.WriteElementString("BarcodeTextFontType", BarcodeTextFontType)
        Writer.WriteElementString("XPosOffsetBarcodeItemName", XPosOffsetBarcodeItemName)

        Writer.WriteElementString("URLFontType", URLFontType)
        Writer.WriteElementString("URLFontSize", URLFontSize)
        Writer.WriteElementString("URLText", URLText)
        Writer.WriteElementString("LabelYStartPos", LabelYStartPos)
        Writer.WriteElementString("XPosOffsetBarcodeDoubleFormat", XPosOffsetBarcodeDoubleFormat)
        Writer.WriteElementString("XPosOffsetBarcodeText", XPosOffsetBarcodeText)
        Writer.WriteElementString("YPosOffsetItemPrice", YPosOffsetItemPrice)
        Writer.WriteElementString("XPosOffsetItemPrice", XPosOffsetItemPrice)
        Writer.WriteElementString("ItemNameMaxRowLine", ItemNameMaxRowLine)

        Writer.WriteEndElement()

        'Barcode
        Writer.WriteStartElement("Barcode")
        Writer.WriteElementString("BarcodeXScale", BarcodeXScale)
        Writer.WriteElementString("BarcodeYScale", BarcodeYScale)
        Writer.WriteElementString("BarcodeType", BSBarcodeType)
        Writer.WriteElementString("BarHeight", CStr(BSBarHeight))
        Writer.WriteElementString("NarrowBarRatio", BSNarrowBarRatio)
        Writer.WriteElementString("WideBarRatio", BSWideBarRatio)
        Writer.WriteElementString("EnableDoubleFormat", BSEnableDoubleFormat)
        Writer.WriteElementString("UseItemCode2PrintBarcode", UseItemCode2PrintBarcode)


        Writer.WriteEndElement()



        'TSCPrinter setting
        Writer.WriteStartElement("LabelSetup")
        'Writer.WriteStartElement("PrintDensity")
        'Writer.WriteString("5")
        Writer.WriteElementString("LabelWidth", LSWidth)
        Writer.WriteElementString("LabelHeight", LSHeight)
        Writer.WriteElementString("PrintSpeed", LSPrintSpeed)
        Writer.WriteElementString("PrintDensity", LSPrintDensity)
        Writer.WriteElementString("VerticalGap", LSVerticalgap)
        Writer.WriteEndElement()

        Writer.WriteEndDocument()

        Writer.Flush()
        Writer.Close()


    End Sub

#End Region


#Region "EMP CoreService"
    Sub StartWebServices()


        Try
            Dim client As New WebClient()

            'Connect to the Web Service
            Dim streamAddress As String = WebServicesAddress.Trim + "?wsdl"

            Dim uri As New Uri(streamAddress)

            'Dim wsdlContents As String = client.DownloadString(WebServicesAddress.Trim + "?wsdl")
            'Dim wsdlDoc As New XmlDocument()
            'wsdlDoc.InnerXml = wsdlContents
            'wsdlDoc.Load(WebServicesAddress.Trim + "?wsdl")

            Dim webreq As WebRequest = WebRequest.Create(uri)
            Dim RequestStream As System.IO.Stream = webreq.GetResponse().GetResponseStream()

            'Dim xnr As New XmlNodeReader(wsdlDoc)
            'Dim description As ServiceDescription = ServiceDescription.Read(xnr)
            'Dim description As ServiceDescription = ServiceDescription.Read(stream)
            Dim description As ServiceDescription = ServiceDescription.Read(RequestStream)

            'Read the WSDL file describing a service
            'Dim description As ServiceDescription = ServiceDescription.Read(stream)

            'LOAD the DOM
            'Initialize a service description importer
            Dim importer As New ServiceDescriptionImporter()
            importer.AddServiceDescription(description, [String].Empty, [String].Empty)

            importer.ProtocolName = "Soap" ' Use SOAP 1.2.

            'Generate a proxy client 
            'importer.Style = ServiceDescriptionImportStyle.Client
            'Generate properties to represent primitive values
            'importer.CodeGenerationOptions = System.Xml.Serialization.CodeGenerationOptions.GenerateProperties
            importer.CodeGenerationOptions = System.Xml.Serialization.CodeGenerationOptions.None
            importer.AddServiceDescription(description, Nothing, Nothing)

            'Download and inject any imported schemas
            For Each wsdlSchema As XmlSchema In description.Types.Schemas
                'Loop through all detected imports in the main schema
                For Each externalSchema As XmlSchemaObject In wsdlSchema.Includes
                    'Read each external schema into a schema object and add to importer 
                    If TypeOf externalSchema Is XmlSchemaImport Then
                        Dim baseUri As New Uri(streamAddress)
                        Dim schemaUri As New Uri(baseUri, DirectCast(externalSchema, XmlSchemaExternal).SchemaLocation)

                        Dim schemaStream As Stream = client.OpenRead(schemaUri)
                        Dim schema As System.Xml.Schema.XmlSchema = XmlSchema.Read(schemaStream, Nothing)
                        importer.Schemas.Add(schema)

                    End If
                Next
            Next


            'Initialize a Code-DOM tree into which we will import the service
            Dim [nmspace] As New CodeNamespace()
            Dim codeCompileUnit As New CodeCompileUnit()
            codeCompileUnit.Namespaces.Add([nmspace])

            'Import the service into the Code-DOM tree. 
            'This creates proxy code that uses the service
            Dim warning As ServiceDescriptionImportWarnings = importer.Import([nmspace], codeCompileUnit)
            If warning = 0 Then
                'Generate the proxy code
                Dim stringWriter As New StringWriter(System.Globalization.CultureInfo.CurrentCulture)

                Dim provider As New Microsoft.CSharp.CSharpCodeProvider()
                provider.GenerateCodeFromNamespace([nmspace], stringWriter, New CodeGeneratorOptions())

                'Compile the assembly proxy with the //appropriate references
                Dim assemblyReferences() As String
                assemblyReferences = New String() {"System.dll", "System.Web.Services.dll", "System.Web.dll", "System.Xml.dll", "System.Data.dll"}
                Dim parms As New CompilerParameters(assemblyReferences)
                parms.GenerateExecutable = False
                parms.GenerateInMemory = True
                parms.TreatWarningsAsErrors = False
                parms.WarningLevel = 4
                Dim results As New CompilerResults(New TempFileCollection())
                results = provider.CompileAssemblyFromDom(parms, codeCompileUnit)

                'Check For Errors
                If results.Errors.Count > 0 Then
                    Dim oops As CompilerError
                    For Each opps In results.Errors
                        System.Diagnostics.Debug.WriteLine("=====Compiler error========")
                        System.Diagnostics.Debug.WriteLine(opps.ToString)
                    Next
                    Throw New System.Exception("Compile Error Occurred calling webservice.")
                End If

                'Finally, Invoke the web service method
                Dim serviceName As String = description.Services(0).Name
                'Dim TypeName As String = "goodsReceivedNoteObject" '"EMPCoreClient"

                Dim assembly As Assembly = results.CompiledAssembly
                service = assembly.[GetType](serviceName)

                Dim cntMethod As Integer = 0

                methodInfos = service.GetMethods()


            Else



            End If
        Catch ex As Exception
            'Throw ex
        End Try


       




        CoreClient.Endpoint.Address = New System.ServiceModel.EndpointAddress(WebServicesAddress)


    End Sub



    Protected Function wsGetMethod(ByVal methodname As String, ByVal argValue As String) As Object
        Dim cntMethod As Integer = 0
        Dim response As [Object] = Nothing

        For Each t As MethodInfo In methodInfos
            If t.Name = methodname Then
                methodname = t.Name
                param = methodInfos(cntMethod).GetParameters()
                myProperty = New properties(param.Length)

                'Get the Parameters Type
                Dim paramTypes As Type()
                paramTypes = New Type(param.Length - 1) {}

                Dim ii As Integer = 0
                For ii = 0 To paramTypes.Length - 1
                    paramTypes(ii) = param(ii).ParameterType

                Next

                For ii = 0 To param.Length - 1
                    myProperty.Index = ii
                    myProperty.Type = param(ii).ParameterType

                Next

                Dim param1 As Object() = New Object(param.Length - 1) {}

                myProperty.Value = argValue
                For j As Integer = 0 To j < param.Length - 1
                    param1(j) = Convert.ChangeType(myProperty.MyValue(j), myProperty.TypeParameter(j))
                Next

                'Invoke Method
                Dim obj As [Object] = Activator.CreateInstance(service)
                response = t.Invoke(obj, param1)
                Return response

            End If
            cntMethod = cntMethod + 1
        Next
        Return response
    End Function


#End Region

#Region "Barcode Code128 Generation System"
    'in principle these rows should each have 6 elements
    ' however, the last one -- STOP -- has 7. The cost of the
    ' extra integers is trivial, and this lets the code flow
    ' much more elegantly 
    ' from '0 -> 106

    Protected Overridable Function GenerateBarcodeImageForC128_v2(ByVal imageWidth As Short, ByVal imageHeight As Short, ByVal Code As String, ByVal ItemName As String, ByVal ItemPrice As String) As IO.MemoryStream
        'Declare a new bitmap canvas to store our new barcode
        Dim b As New Bitmap(imageWidth, imageHeight, Imaging.PixelFormat.Format32bppArgb)

        'Create our graphic object from our barcode canvas 
        Dim canvas As New Rectangle(0, 0, imageWidth, imageHeight)

        'Create our graphics object from our barcode canvas
        Dim g As Graphics = Graphics.FromImage(b)

        g.PageUnit = GraphicsUnit.Pixel
        g.PageScale = 1
        'Fill the drawing with white barkground
        g.FillRectangle(Brushes.White, 0, 0, imageWidth, imageHeight)

        Dim BarcodeWidth As Integer = _barWidth * _BarcodeXScale
        Dim BarcodeHeight As Integer = _barHeight * _BarcodeYScale

        'Define a starting X and Y position for the barcode
        Dim XPosition As Short = 3
        Dim YPosition As Short = 1

        'We are using SingleBitPerPixel because when printed it appears sharper as opposed to anti-aliased
        g.TextRenderingHint = Drawing.Text.TextRenderingHint.SystemDefault ' .SingleBitPerPixel
        g.SmoothingMode = Drawing2D.SmoothingMode.Default ' .HighQuality
        g.InterpolationMode = Drawing2D.InterpolationMode.Default ' .HighQualityBicubic
        g.CompositingQuality = Drawing2D.CompositingQuality.Default ' HighQuality

        'Write out the original barcode ID '  Arial
        Dim FontSize As Single = 12 * _BarcodeYScale
        If FontSize < 7 Then
            FontSize = 7
        End If

        Dim CompanyNameLine1 As String = "JAYACOM INFORMATION"
        Dim CompanyNameLine2 As String = "SDN. BHD."

        Dim fontname As String
        fontname = "Targa" 'Tahoma" '"Butter" '"Targa MS" '"Arial"
        g.DrawString(CompanyNameLine1, New Font(fontname, FontSize, FontStyle.Bold), New SolidBrush(Color.Black), XPosition, YPosition)
        YPosition = YPosition + 10
        g.DrawString(CompanyNameLine2, New Font(fontname, FontSize, FontStyle.Bold), New SolidBrush(Color.Black), XPosition + 30, YPosition)


        Dim Encoded_Value As String
        Dim Raw_Data As String
        Dim Formatted_Data As String

        Dim barcodeC128 As Code128 = New Code128(Code)
        Encoded_Value = barcodeC128.Encoded_Value
        Raw_Data = barcodeC128.RawData
        Formatted_Data = barcodeC128.FormattedData


        'Now that we are going to draw the barcode lines -- which needs to be very straight, and not blended
        'Else it may blur and cause complications with barcode reading device 
        '1st set
        g.TextRenderingHint = Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit ' SystemDefault
        g.SmoothingMode = Drawing2D.SmoothingMode.None
        g.InterpolationMode = Drawing2D.InterpolationMode.High  'NearestNeighbor
        g.CompositingQuality = Drawing2D.CompositingQuality.Default

        Dim iBarWidth As Integer = BarcodeWidth / Encoded_Value.Length
        Dim shiftAdjustment As Integer = (BarcodeWidth Mod Encoded_Value.Length) / 2


        If iBarWidth <= 0 Then
            Throw New Exception("Image size specified not large enough to draw image. (Bar size determined to be less than 1 pixel)")
        End If

        Dim pen As Pen = New Pen(Color.Black, iBarWidth)
        pen.Alignment = Drawing2D.PenAlignment.Right
        YPosition = YPosition + 12
        Dim nLineCount As Integer = 0

        While nLineCount < Encoded_Value.Length
            If Encoded_Value(nLineCount) = "1" Then
                Dim posx As Point = New Point(XPosition * iBarWidth, YPosition)
                Dim posy As Point = New Point(XPosition * iBarWidth, YPosition + BarcodeHeight)
                g.DrawLine(pen, posx, posy)
            End If
            XPosition = XPosition + 1
            nLineCount = nLineCount + 1

        End While


        g.TextRenderingHint = Drawing.Text.TextRenderingHint.SystemDefault ' .SingleBitPerPixel
        g.SmoothingMode = Drawing2D.SmoothingMode.Default ' .HighQuality
        g.InterpolationMode = Drawing2D.InterpolationMode.Default ' .HighQualityBicubic
        g.CompositingQuality = Drawing2D.CompositingQuality.Default ' HighQuality
        XPosition = 1
        YPosition = YPosition + BarcodeHeight + 1
        g.DrawString(Code, New Font(fontname, FontSize, FontStyle.Bold), New SolidBrush(Color.Black), XPosition + 20, YPosition)

        YPosition = YPosition + FontSize + 3

        Dim StrLength As Integer
        Dim StrNameLine1 As String
        Dim StrNameLine2 As String
        Dim xPosExt As Integer = 0

        xPosExt = (BarcodeWidth / 2) - ((ItemPrice.Length() * FontSize) / 2) + 8
        StrLength = ItemName.Length()
        If StrLength > 18 And StrLength < 35 Then
            'ItemName.CopyTo(0, charItemName, 1, 18)
            StrNameLine1 = ItemName.Substring(0, 22) '0, 18)
            StrNameLine2 = ItemName.Substring(22, StrLength - 22) '18, StrLength - 18)
            g.DrawString(StrNameLine1, New Font(fontname, FontSize, FontStyle.Regular), New SolidBrush(Color.Black), XPosition, YPosition)
            YPosition = YPosition + FontSize + 3
            g.DrawString(StrNameLine2, New Font(fontname, FontSize, FontStyle.Regular), New SolidBrush(Color.Black), XPosition, YPosition)

            YPosition = YPosition + FontSize + 3

            g.DrawString(ItemPrice, New Font(fontname, FontSize + 1, FontStyle.Bold), New SolidBrush(Color.Black), XPosition + xPosExt, YPosition)

        ElseIf StrLength > 34 Then
            StrNameLine1 = ItemName.Substring(0, 22) '0, 18)
            If (StrLength - 22) < 22 Then
                StrNameLine2 = ItemName.Substring(22, StrLength - 22) '18, 18)
            Else
                StrNameLine2 = ItemName.Substring(22, 22)
            End If
            'If StrLength > 44 Then
            'StrNameLine3 = ItemName.Substring(44, 66 - 44) '36, 53 - 36) 'StrLength - 35)
            'End If
            g.DrawString(StrNameLine1, New Font(fontname, FontSize, FontStyle.Regular), New SolidBrush(Color.Black), XPosition, YPosition)
            YPosition = YPosition + FontSize + 3
            g.DrawString(StrNameLine2, New Font(fontname, FontSize, FontStyle.Regular), New SolidBrush(Color.Black), XPosition, YPosition)
            'YPosition = YPosition + FontSize + 3
            'g.DrawString(StrNameLine3, New Font(fontname, FontSize, FontStyle.Regular), New SolidBrush(Color.Black), XPosition, YPosition)

            YPosition = YPosition + FontSize + 2
            g.DrawString(ItemPrice, New Font(fontname, FontSize, FontStyle.Bold), New SolidBrush(Color.Black), XPosition + xPosExt, YPosition)

        Else

            g.DrawString(ItemName, New Font(fontname, FontSize, FontStyle.Regular), New SolidBrush(Color.Black), XPosition, YPosition)
            YPosition = YPosition + FontSize + 3
            g.DrawString(ItemPrice, New Font(fontname, FontSize, FontStyle.Bold), New SolidBrush(Color.Black), XPosition + xPosExt, YPosition)
        End If





        'Create a new memorystream to use with our function return
        Dim ms As New IO.MemoryStream

        'Setup the encoding quality of the final barcode rendered image
        Dim encodingParams As New EncoderParameters
        encodingParams.Param(0) = New EncoderParameter(Imaging.Encoder.Quality, 100)

        'During the encoding details of "how" for the image
        'We will use PNG because it's got the best image quality for it's footprint
        Dim encodingInfo As ImageCodecInfo = FindCodecInfo("PNG")

        'Save the drawing directly into the stream
        b.Save(ms, encodingInfo, encodingParams)

        g.Dispose()
        b.Dispose()

        'Finally, return the image via the memorystream
        Return ms
    End Function
#End Region


    Private Sub AddItemToList(ByVal bItem As BarcodeItem)

        Dim AddItemCount As Integer = lvItemInfo.Items.Count

        Dim lvItem As New ListViewItem
        With lvItem
            .Tag = bItem
            .Text = bItem.Qty
            .SubItems.Add(bItem.ItemCode)
            .SubItems.Add(bItem.EANCode)
            .SubItems.Add(bItem.ItemName)
            '.SubItems.Add(bItem.PriceChecked)
            .SubItems.Add(bItem.Price)
            .SubItems.Add(bItem.Category2)
            .SubItems.Add(bItem.Category3)
            .SubItems.Add(bItem.Category4)
            .SubItems.Add(bItem.Category5)
            .SubItems.Add(bItem.Category6)
            
        End With

        lvItemInfo.Items.Add(lvItem)
    End Sub


    Private Function getBarcodeItem(ByVal itmObj As Object) As BarcodeItem

        Dim item As New BarcodeItem
        With item
            .ItemCode = itmObj.code
            .EANCode = itmObj.EANCode
            .ItemName = itmObj.name
            .PriceChecked = ""
            .Price = "NtRM" & Format(itmObj.priceList, "0.00")
            .Category1 = itmObj.category1
            .Category2 = itmObj.category2
            .Category3 = itmObj.category3
            .Category4 = itmObj.category4
            .Category5 = itmObj.category5
            .Category6 = itmObj.category6
            .Category7 = itmObj.category7
            .Category8 = itmObj.category8
            .Category9 = itmObj.category9
            .Category10 = itmObj.category10
            .PrintPage2 = False

            If .Category1.Length <> 0 Then
                .Price = .Category1
            End If
        End With

        Return item

    End Function

End Class




