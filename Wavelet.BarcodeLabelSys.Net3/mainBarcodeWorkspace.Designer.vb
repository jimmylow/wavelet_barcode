<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class mainBarcodeWorkspace
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(mainBarcodeWorkspace))
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.printConfigButton = New System.Windows.Forms.Button()
        Me.GenerateLabelsButton = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.printPreviewButton = New System.Windows.Forms.Button()
        Me.PreviewPrint = New System.Windows.Forms.PrintPreviewDialog()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.colUnitPrice = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvItemInfo = New System.Windows.Forms.ListView()
        Me.colQuantity = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colItemCode = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colEANCode = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colItemName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colCategory1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colCategory2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colCategory3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colCategory4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colCategory5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtGRNCode = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnSelectAllRow = New System.Windows.Forms.Button()
        Me.cbxSeachBy = New System.Windows.Forms.ComboBox()
        Me.lbStatus = New System.Windows.Forms.Label()
        Me.btAddItem = New System.Windows.Forms.Button()
        Me.btnClearItems = New System.Windows.Forms.Button()
        Me.btnTSCPrinterFF = New System.Windows.Forms.Button()
        Me.lbVersion = New System.Windows.Forms.Label()
        Me.btEditItem = New System.Windows.Forms.Button()
        Me.btnDownloadLogo = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'printConfigButton
        '
        Me.printConfigButton.Location = New System.Drawing.Point(653, 17)
        Me.printConfigButton.Name = "printConfigButton"
        Me.printConfigButton.Size = New System.Drawing.Size(133, 23)
        Me.printConfigButton.TabIndex = 14
        Me.printConfigButton.Text = "Printer Setup"
        Me.printConfigButton.UseVisualStyleBackColor = True
        '
        'GenerateLabelsButton
        '
        Me.GenerateLabelsButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GenerateLabelsButton.Location = New System.Drawing.Point(653, 90)
        Me.GenerateLabelsButton.Name = "GenerateLabelsButton"
        Me.GenerateLabelsButton.Size = New System.Drawing.Size(133, 42)
        Me.GenerateLabelsButton.TabIndex = 15
        Me.GenerateLabelsButton.Text = "Generate Label"
        Me.GenerateLabelsButton.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(20, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 16)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Select Filter:"
        '
        'printPreviewButton
        '
        Me.printPreviewButton.Location = New System.Drawing.Point(800, 17)
        Me.printPreviewButton.Name = "printPreviewButton"
        Me.printPreviewButton.Size = New System.Drawing.Size(133, 23)
        Me.printPreviewButton.TabIndex = 13
        Me.printPreviewButton.Text = "Print Preview"
        Me.printPreviewButton.UseVisualStyleBackColor = True
        '
        'PreviewPrint
        '
        Me.PreviewPrint.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PreviewPrint.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PreviewPrint.ClientSize = New System.Drawing.Size(400, 300)
        Me.PreviewPrint.Enabled = True
        Me.PreviewPrint.Icon = CType(resources.GetObject("PreviewPrint.Icon"), System.Drawing.Icon)
        Me.PreviewPrint.Name = "PreviewPrint"
        Me.PreviewPrint.Visible = False
        '
        'btnSearch
        '
        Me.btnSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.Location = New System.Drawing.Point(455, 37)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(120, 30)
        Me.btnSearch.TabIndex = 10
        Me.btnSearch.Text = "Search..."
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Location = New System.Drawing.Point(640, 178)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(360, 360)
        Me.PictureBox1.TabIndex = 11
        Me.PictureBox1.TabStop = False
        '
        'colUnitPrice
        '
        Me.colUnitPrice.Text = "Price"
        Me.colUnitPrice.Width = 76
        '
        'lvItemInfo
        '
        Me.lvItemInfo.CheckBoxes = True
        Me.lvItemInfo.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colQuantity, Me.colItemCode, Me.colEANCode, Me.colItemName, Me.colUnitPrice, Me.colCategory1, Me.colCategory2, Me.colCategory3, Me.colCategory4, Me.colCategory5})
        Me.lvItemInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvItemInfo.FullRowSelect = True
        Me.lvItemInfo.GridLines = True
        Me.lvItemInfo.LabelEdit = True
        Me.lvItemInfo.Location = New System.Drawing.Point(23, 119)
        Me.lvItemInfo.MultiSelect = False
        Me.lvItemInfo.Name = "lvItemInfo"
        Me.lvItemInfo.Size = New System.Drawing.Size(611, 447)
        Me.lvItemInfo.TabIndex = 12
        Me.lvItemInfo.UseCompatibleStateImageBehavior = False
        Me.lvItemInfo.UseWaitCursor = True
        Me.lvItemInfo.View = System.Windows.Forms.View.Details
        '
        'colQuantity
        '
        Me.colQuantity.Text = "Quantity"
        Me.colQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.colQuantity.Width = 65
        '
        'colItemCode
        '
        Me.colItemCode.Text = "Item Code"
        Me.colItemCode.Width = 120
        '
        'colEANCode
        '
        Me.colEANCode.Text = "EAN Code"
        Me.colEANCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.colEANCode.Width = 110
        '
        'colItemName
        '
        Me.colItemName.Text = "Item Name"
        Me.colItemName.Width = 230
        '
        'colCategory1
        '
        Me.colCategory1.Text = "Category1"
        Me.colCategory1.Width = 120
        '
        'colCategory2
        '
        Me.colCategory2.Text = "Category2"
        Me.colCategory2.Width = 120
        '
        'colCategory3
        '
        Me.colCategory3.Text = "Category3"
        Me.colCategory3.Width = 120
        '
        'colCategory4
        '
        Me.colCategory4.Text = "Category4"
        Me.colCategory4.Width = 120
        '
        'colCategory5
        '
        Me.colCategory5.Text = "Category5"
        Me.colCategory5.Width = 120
        '
        'txtGRNCode
        '
        Me.txtGRNCode.AcceptsReturn = True
        Me.txtGRNCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGRNCode.Location = New System.Drawing.Point(132, 37)
        Me.txtGRNCode.Name = "txtGRNCode"
        Me.txtGRNCode.Size = New System.Drawing.Size(306, 35)
        Me.txtGRNCode.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(644, 147)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(169, 16)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Barcode Label Preview"
        '
        'btnSelectAllRow
        '
        Me.btnSelectAllRow.Location = New System.Drawing.Point(23, 572)
        Me.btnSelectAllRow.Name = "btnSelectAllRow"
        Me.btnSelectAllRow.Size = New System.Drawing.Size(133, 23)
        Me.btnSelectAllRow.TabIndex = 17
        Me.btnSelectAllRow.Text = "Check All Items"
        Me.btnSelectAllRow.UseVisualStyleBackColor = True
        '
        'cbxSeachBy
        '
        Me.cbxSeachBy.AllowDrop = True
        Me.cbxSeachBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxSeachBy.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxSeachBy.FormattingEnabled = True
        Me.cbxSeachBy.Items.AddRange(New Object() {"GRN", "ItemCode", "EANCode", "Fuzzy"})
        Me.cbxSeachBy.Location = New System.Drawing.Point(23, 41)
        Me.cbxSeachBy.Name = "cbxSeachBy"
        Me.cbxSeachBy.Size = New System.Drawing.Size(95, 28)
        Me.cbxSeachBy.TabIndex = 18
        '
        'lbStatus
        '
        Me.lbStatus.AutoSize = True
        Me.lbStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbStatus.ForeColor = System.Drawing.Color.Navy
        Me.lbStatus.Location = New System.Drawing.Point(37, 90)
        Me.lbStatus.Name = "lbStatus"
        Me.lbStatus.Size = New System.Drawing.Size(64, 20)
        Me.lbStatus.TabIndex = 19
        Me.lbStatus.Text = "Status :"
        '
        'btAddItem
        '
        Me.btAddItem.Location = New System.Drawing.Point(348, 572)
        Me.btAddItem.Name = "btAddItem"
        Me.btAddItem.Size = New System.Drawing.Size(133, 23)
        Me.btAddItem.TabIndex = 20
        Me.btAddItem.Text = "Add Item"
        Me.btAddItem.UseVisualStyleBackColor = True
        '
        'btnClearItems
        '
        Me.btnClearItems.Location = New System.Drawing.Point(491, 572)
        Me.btnClearItems.Name = "btnClearItems"
        Me.btnClearItems.Size = New System.Drawing.Size(133, 23)
        Me.btnClearItems.TabIndex = 21
        Me.btnClearItems.Text = "Clear All Items"
        Me.btnClearItems.UseVisualStyleBackColor = True
        '
        'btnTSCPrinterFF
        '
        Me.btnTSCPrinterFF.Location = New System.Drawing.Point(653, 49)
        Me.btnTSCPrinterFF.Name = "btnTSCPrinterFF"
        Me.btnTSCPrinterFF.Size = New System.Drawing.Size(133, 23)
        Me.btnTSCPrinterFF.TabIndex = 22
        Me.btnTSCPrinterFF.Text = "Printer FormFeed"
        Me.btnTSCPrinterFF.UseVisualStyleBackColor = True
        '
        'lbVersion
        '
        Me.lbVersion.AutoSize = True
        Me.lbVersion.Location = New System.Drawing.Point(24, 603)
        Me.lbVersion.Name = "lbVersion"
        Me.lbVersion.Size = New System.Drawing.Size(42, 13)
        Me.lbVersion.TabIndex = 23
        Me.lbVersion.Text = "Version"
        '
        'btEditItem
        '
        Me.btEditItem.Location = New System.Drawing.Point(207, 572)
        Me.btEditItem.Name = "btEditItem"
        Me.btEditItem.Size = New System.Drawing.Size(133, 23)
        Me.btEditItem.TabIndex = 24
        Me.btEditItem.Text = "Edit Item"
        Me.btEditItem.UseVisualStyleBackColor = True
        '
        'btnDownloadLogo
        '
        Me.btnDownloadLogo.Location = New System.Drawing.Point(800, 49)
        Me.btnDownloadLogo.Name = "btnDownloadLogo"
        Me.btnDownloadLogo.Size = New System.Drawing.Size(133, 23)
        Me.btnDownloadLogo.TabIndex = 25
        Me.btnDownloadLogo.Text = "Download Logo"
        Me.btnDownloadLogo.UseVisualStyleBackColor = True
        '
        'mainBarcodeWorkspace
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 615)
        Me.Controls.Add(Me.btnDownloadLogo)
        Me.Controls.Add(Me.btEditItem)
        Me.Controls.Add(Me.lbVersion)
        Me.Controls.Add(Me.btnTSCPrinterFF)
        Me.Controls.Add(Me.btnClearItems)
        Me.Controls.Add(Me.btAddItem)
        Me.Controls.Add(Me.lbStatus)
        Me.Controls.Add(Me.cbxSeachBy)
        Me.Controls.Add(Me.btnSelectAllRow)
        Me.Controls.Add(Me.printConfigButton)
        Me.Controls.Add(Me.GenerateLabelsButton)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.printPreviewButton)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lvItemInfo)
        Me.Controls.Add(Me.txtGRNCode)
        Me.Controls.Add(Me.Label2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "mainBarcodeWorkspace"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Wavelet Barcode System.Net"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents printConfigButton As System.Windows.Forms.Button
    Friend WithEvents GenerateLabelsButton As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents printPreviewButton As System.Windows.Forms.Button
    Friend WithEvents PreviewPrint As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents colUnitPrice As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvItemInfo As System.Windows.Forms.ListView
    Friend WithEvents colItemCode As System.Windows.Forms.ColumnHeader
    Friend WithEvents colEANCode As System.Windows.Forms.ColumnHeader
    Friend WithEvents colItemName As System.Windows.Forms.ColumnHeader
    Friend WithEvents colQuantity As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtGRNCode As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnSelectAllRow As System.Windows.Forms.Button
    Friend WithEvents cbxSeachBy As System.Windows.Forms.ComboBox
    Friend WithEvents lbStatus As System.Windows.Forms.Label
    Friend WithEvents btAddItem As System.Windows.Forms.Button
    Friend WithEvents btnClearItems As System.Windows.Forms.Button
    Friend WithEvents btnTSCPrinterFF As System.Windows.Forms.Button
    Friend WithEvents lbVersion As System.Windows.Forms.Label
    Friend WithEvents btEditItem As System.Windows.Forms.Button
    Friend WithEvents btnDownloadLogo As System.Windows.Forms.Button
    Friend WithEvents colCategory1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents colCategory2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents colCategory3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents colCategory4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents colCategory5 As System.Windows.Forms.ColumnHeader

End Class
