<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddItemBoxFrm
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
        Me.txItemCode = New System.Windows.Forms.TextBox
        Me.txItemName1 = New System.Windows.Forms.TextBox
        Me.txItemPrice = New System.Windows.Forms.TextBox
        Me.txItemQuantity = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.btnAddItem = New System.Windows.Forms.Button
        Me.txEANCode = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txItemName = New System.Windows.Forms.RichTextBox
        Me.btnCancel = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtCategory2 = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtCategory3 = New System.Windows.Forms.TextBox
        Me.cboPriceCheked = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtCategory4 = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.Label14 = New System.Windows.Forms.Label
        Me.chkPrintPage2 = New System.Windows.Forms.CheckBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtCategory8 = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtCategory7 = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtCategory5 = New System.Windows.Forms.TextBox
        Me.txtCategory6 = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtCategory9 = New System.Windows.Forms.TextBox
        Me.txtCategory10 = New System.Windows.Forms.TextBox
        Me.GroupBox1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'txItemCode
        '
        Me.txItemCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txItemCode.Location = New System.Drawing.Point(143, 19)
        Me.txItemCode.Name = "txItemCode"
        Me.txItemCode.Size = New System.Drawing.Size(264, 26)
        Me.txItemCode.TabIndex = 0
        '
        'txItemName1
        '
        Me.txItemName1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txItemName1.Location = New System.Drawing.Point(180, 175)
        Me.txItemName1.Multiline = True
        Me.txItemName1.Name = "txItemName1"
        Me.txItemName1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txItemName1.Size = New System.Drawing.Size(84, 24)
        Me.txItemName1.TabIndex = 11
        Me.txItemName1.Visible = False
        '
        'txItemPrice
        '
        Me.txItemPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txItemPrice.Location = New System.Drawing.Point(143, 139)
        Me.txItemPrice.Name = "txItemPrice"
        Me.txItemPrice.Size = New System.Drawing.Size(121, 26)
        Me.txItemPrice.TabIndex = 4
        Me.txItemPrice.Text = "0.00"
        Me.txItemPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txItemQuantity
        '
        Me.txItemQuantity.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txItemQuantity.Location = New System.Drawing.Point(143, 175)
        Me.txItemQuantity.Name = "txItemQuantity"
        Me.txItemQuantity.Size = New System.Drawing.Size(31, 26)
        Me.txItemQuantity.TabIndex = 5
        Me.txItemQuantity.Text = "1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(18, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 20)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Item Code"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(18, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 20)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Item Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(18, 142)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 20)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Item Price"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(19, 178)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 20)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Quantity"
        '
        'btnAddItem
        '
        Me.btnAddItem.Location = New System.Drawing.Point(236, 452)
        Me.btnAddItem.Name = "btnAddItem"
        Me.btnAddItem.Size = New System.Drawing.Size(97, 28)
        Me.btnAddItem.TabIndex = 9
        Me.btnAddItem.Text = "Add/Edit Item"
        Me.btnAddItem.UseVisualStyleBackColor = True
        '
        'txEANCode
        '
        Me.txEANCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txEANCode.Location = New System.Drawing.Point(143, 105)
        Me.txEANCode.Name = "txEANCode"
        Me.txEANCode.Size = New System.Drawing.Size(264, 26)
        Me.txEANCode.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(19, 108)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 20)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "EAN Code "
        '
        'txItemName
        '
        Me.txItemName.DetectUrls = False
        Me.txItemName.Location = New System.Drawing.Point(142, 53)
        Me.txItemName.Name = "txItemName"
        Me.txItemName.Size = New System.Drawing.Size(265, 44)
        Me.txItemName.TabIndex = 1
        Me.txItemName.Text = ""
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(351, 452)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(97, 28)
        Me.btnCancel.TabIndex = 10
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(3, 12)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(86, 20)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Category 2"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(3, 45)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(86, 20)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Category 3"
        '
        'txtCategory2
        '
        Me.txtCategory2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCategory2.Location = New System.Drawing.Point(101, 12)
        Me.txtCategory2.Name = "txtCategory2"
        Me.txtCategory2.Size = New System.Drawing.Size(264, 26)
        Me.txtCategory2.TabIndex = 2
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(3, 78)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(86, 20)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "Category 4"
        '
        'txtCategory3
        '
        Me.txtCategory3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCategory3.Location = New System.Drawing.Point(101, 45)
        Me.txtCategory3.Name = "txtCategory3"
        Me.txtCategory3.Size = New System.Drawing.Size(264, 26)
        Me.txtCategory3.TabIndex = 3
        '
        'cboPriceCheked
        '
        Me.cboPriceCheked.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPriceCheked.FormattingEnabled = True
        Me.cboPriceCheked.Items.AddRange(New Object() {"", "Nt", "Ws"})
        Me.cboPriceCheked.Location = New System.Drawing.Point(270, 175)
        Me.cboPriceCheked.Name = "cboPriceCheked"
        Me.cboPriceCheked.Size = New System.Drawing.Size(121, 28)
        Me.cboPriceCheked.TabIndex = 3
        Me.cboPriceCheked.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(3, 111)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(86, 20)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "Category 5"
        '
        'txtCategory4
        '
        Me.txtCategory4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCategory4.Location = New System.Drawing.Point(101, 78)
        Me.txtCategory4.Name = "txtCategory4"
        Me.txtCategory4.Size = New System.Drawing.Size(264, 26)
        Me.txtCategory4.TabIndex = 4
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TabControl1)
        Me.GroupBox1.Controls.Add(Me.txItemCode)
        Me.GroupBox1.Controls.Add(Me.txItemName1)
        Me.GroupBox1.Controls.Add(Me.txItemPrice)
        Me.GroupBox1.Controls.Add(Me.cboPriceCheked)
        Me.GroupBox1.Controls.Add(Me.txItemQuantity)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txEANCode)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txItemName)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(434, 433)
        Me.GroupBox1.TabIndex = 22
        Me.GroupBox1.TabStop = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TabControl1.Location = New System.Drawing.Point(22, 220)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(405, 207)
        Me.TabControl1.TabIndex = 6
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.txtCategory5)
        Me.TabPage1.Controls.Add(Me.txtCategory6)
        Me.TabPage1.Controls.Add(Me.Label15)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.txtCategory2)
        Me.TabPage1.Controls.Add(Me.txtCategory4)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.txtCategory3)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Location = New System.Drawing.Point(4, 29)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(397, 174)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Page1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.txtCategory10)
        Me.TabPage2.Controls.Add(Me.txtCategory9)
        Me.TabPage2.Controls.Add(Me.Label10)
        Me.TabPage2.Controls.Add(Me.Label14)
        Me.TabPage2.Controls.Add(Me.chkPrintPage2)
        Me.TabPage2.Controls.Add(Me.Label11)
        Me.TabPage2.Controls.Add(Me.txtCategory8)
        Me.TabPage2.Controls.Add(Me.Label12)
        Me.TabPage2.Controls.Add(Me.txtCategory7)
        Me.TabPage2.Controls.Add(Me.Label13)
        Me.TabPage2.Location = New System.Drawing.Point(4, 29)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(397, 174)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Page2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(4, 137)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(41, 20)
        Me.Label14.TabIndex = 31
        Me.Label14.Text = "Print"
        '
        'chkPrintPage2
        '
        Me.chkPrintPage2.AutoSize = True
        Me.chkPrintPage2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.chkPrintPage2.Location = New System.Drawing.Point(101, 141)
        Me.chkPrintPage2.Name = "chkPrintPage2"
        Me.chkPrintPage2.Size = New System.Drawing.Size(15, 14)
        Me.chkPrintPage2.TabIndex = 30
        Me.chkPrintPage2.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(3, 78)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(86, 20)
        Me.Label11.TabIndex = 29
        Me.Label11.Text = "Category 9"
        '
        'txtCategory8
        '
        Me.txtCategory8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCategory8.Location = New System.Drawing.Point(101, 45)
        Me.txtCategory8.Name = "txtCategory8"
        Me.txtCategory8.Size = New System.Drawing.Size(264, 26)
        Me.txtCategory8.TabIndex = 4
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(3, 12)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(86, 20)
        Me.Label12.TabIndex = 27
        Me.Label12.Text = "Category 7"
        '
        'txtCategory7
        '
        Me.txtCategory7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCategory7.Location = New System.Drawing.Point(101, 12)
        Me.txtCategory7.Name = "txtCategory7"
        Me.txtCategory7.Size = New System.Drawing.Size(264, 26)
        Me.txtCategory7.TabIndex = 3
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(3, 45)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(86, 20)
        Me.Label13.TabIndex = 28
        Me.Label13.Text = "Category 8"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(3, 143)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(86, 20)
        Me.Label15.TabIndex = 23
        Me.Label15.Text = "Category 6"
        '
        'txtCategory5
        '
        Me.txtCategory5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCategory5.Location = New System.Drawing.Point(101, 111)
        Me.txtCategory5.Name = "txtCategory5"
        Me.txtCategory5.Size = New System.Drawing.Size(264, 26)
        Me.txtCategory5.TabIndex = 24
        '
        'txtCategory6
        '
        Me.txtCategory6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCategory6.Location = New System.Drawing.Point(101, 142)
        Me.txtCategory6.Name = "txtCategory6"
        Me.txtCategory6.Size = New System.Drawing.Size(264, 26)
        Me.txtCategory6.TabIndex = 25
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(3, 111)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(95, 20)
        Me.Label10.TabIndex = 32
        Me.Label10.Text = "Category 10"
        '
        'txtCategory9
        '
        Me.txtCategory9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCategory9.Location = New System.Drawing.Point(101, 78)
        Me.txtCategory9.Name = "txtCategory9"
        Me.txtCategory9.Size = New System.Drawing.Size(264, 26)
        Me.txtCategory9.TabIndex = 33
        '
        'txtCategory10
        '
        Me.txtCategory10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCategory10.Location = New System.Drawing.Point(101, 111)
        Me.txtCategory10.Name = "txtCategory10"
        Me.txtCategory10.Size = New System.Drawing.Size(264, 26)
        Me.txtCategory10.TabIndex = 34
        '
        'AddItemBoxFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(459, 490)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnAddItem)
        Me.Name = "AddItemBoxFrm"
        Me.Text = " "
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txItemCode As System.Windows.Forms.TextBox
    Friend WithEvents txItemName1 As System.Windows.Forms.TextBox
    Friend WithEvents txItemPrice As System.Windows.Forms.TextBox
    Friend WithEvents txItemQuantity As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnAddItem As System.Windows.Forms.Button
    Friend WithEvents txEANCode As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txItemName As System.Windows.Forms.RichTextBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtCategory2 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtCategory3 As System.Windows.Forms.TextBox
    Friend WithEvents cboPriceCheked As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtCategory4 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents chkPrintPage2 As System.Windows.Forms.CheckBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtCategory8 As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtCategory7 As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtCategory5 As System.Windows.Forms.TextBox
    Friend WithEvents txtCategory6 As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtCategory10 As System.Windows.Forms.TextBox
    Friend WithEvents txtCategory9 As System.Windows.Forms.TextBox
End Class
