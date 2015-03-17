Public Class AddItemBoxFrm
    'Public itemPriceRM As String
    Private Sub btnAddItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddItem.Click
        'Dim price As Decimal
        'If txItemPrice.Text <> "" Then
        '    price = CDec(txItemPrice.Text)
        'End If

        ''itemPriceRM = "RM" & price ' Format(price, "RM 0")

        'itemPriceRM = price

        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    'Private Sub AddItemBoxFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    'End Sub

    'Private Sub txItemPrice_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txItemPrice.TextChanged

    'End Sub

    Private Sub TabPage1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage1.Click

    End Sub
End Class