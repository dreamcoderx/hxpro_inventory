Imports System.Data
Imports System.Data.SqlClient
Imports System.Xml
Public Class frmSetItems
    Dim dtPartRequest As New DataTable
    Dim strItemCode As String
    Private Sub frm_create_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadRentalHDR()
        loadPartRequest()

    End Sub
    Private Function loadPartRequest() As Boolean
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim sql As String
        con.ConnectionString = ConnectServer()
        Try

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            sql = _
"select a.part_id, c.description, a.qty as qty_request, b.qty as qty_scanned from tbl_rental_line a" & _
" left join v_rental_part_qty b on a.rental_id = b.rental_id and a.part_id = b.part_id" & _
" left join tbl_part c on a.part_id = c.part_id" & _
" where a.rental_id = '" & lblRentalID.Text & "'"

            cmd = New SqlCommand(sql, con)
            'Dim dtRentalHdr As New DataTable

            Dim adpt As New Data.SqlClient.SqlDataAdapter(cmd)
            dtPartRequest.Rows.Clear()
            adpt.Fill(dtPartRequest)
            dgvRentalHDR.DataSource = dtPartRequest
            con.Dispose()
            cmd.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Function loadItemScanned() As Boolean
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim sql As String
        con.ConnectionString = ConnectServer()
        Try

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            sql = _
"select b.asset_number, c.description, a.rental_id from tbl_rental_asset a" & _
" left join tbl_item b on a.item_code = b.item_code" & _
" left join tbl_part c on b.part_id = c.part_id" & _
" where a.rental_id = '" & lblRentalID.Text & "'"

            cmd = New SqlCommand(sql, con)
            Dim dtAssetList As New DataTable
            Dim adpt As New Data.SqlClient.SqlDataAdapter(cmd)
            dtAssetList.Rows.Clear()
            adpt.Fill(dtAssetList)
            dgvAssetList.DataSource = dtAssetList
            con.Dispose()
            cmd.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Function loadRentalHDR() As Boolean
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim sql As String
        con.ConnectionString = ConnectServer()
        Try

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            sql = _
"select rental_no from tbl_rental_hdr where rental_id = '" & lblRentalID.Text & "'"

            cmd = New SqlCommand(sql, con)
            Dim dtRentalHdr As New DataTable

            Dim adpt As New Data.SqlClient.SqlDataAdapter(cmd)
            adpt.Fill(dtRentalHdr)
            If dtRentalHdr.Rows.Count = 0 Then
                MsgBox("Rental ID not found!")
                Return False
            Else
                txtRentalNo.Text = dtRentalHdr.Rows(0).Item("rental_no").ToString
                Return True
            End If
            con.Dispose()
            cmd.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub txtAssetNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAssetNumber.KeyPress
        Dim Keyascii As Integer = AscW(e.KeyChar)
        If Keyascii = 13 And txtAssetNumber.Text <> "" Then
            If loadItemDesc() Then
                If checkPart(txtPartID.Text) Then
                    lblStatus.ForeColor = Color.Green
                    lblStatus.Text = "CHECK OUT SUCCESFULL!" & vbCrLf & "ASSET NUMBER:" & txtAssetNumber.Text
                    loadPartRequest()
                    txtAssetNumber.Text = ""
                    txtAssetNumber.Focus()
                End If
            End If
        End If
    End Sub

    Private Function checkPart(ByVal strPartID As String) As Boolean
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim sql As String = ""
        Try

            con.ConnectionString = ConnectServer()
            con.Open()
            For ctr As Integer = 0 To dtPartRequest.Rows.Count - 1
                If dtPartRequest.Rows(ctr).Item("part_id") = strPartID Then
                    Dim intQtyBal, intScannedQty As Integer
                    If dtPartRequest.Rows(ctr).Item("qty_scanned") Is DBNull.Value Then
                        intScannedQty = 0
                    Else
                        intScannedQty = dtPartRequest.Rows(ctr).Item("qty_scanned")

                    End If

                    intQtyBal = dtPartRequest.Rows(ctr).Item("qty_request") - intScannedQty

                    If intQtyBal > 0 Then
                        sql = _
    "INSERT INTO [tbl_rental_asset]" & _
    " ([item_code]" & _
    " ,[rental_id]" & _
    " ,[dt_out])" & _
    " VALUES" & _
    " (@item_code" & _
    " ,@rental_id" & _
    " ,@dt_out)"
                        cmd = New SqlCommand(sql, con)
                        cmd.Parameters.AddWithValue("@item_code", strItemCode)
                        cmd.Parameters.AddWithValue("@rental_id", lblRentalID.Text)
                        cmd.Parameters.AddWithValue("@dt_out", Date.Now)

                        If cmd.ExecuteNonQuery() > 0 Then
                            Return True
                        End If
                    Else
                        lblStatus.ForeColor = Color.Red
                        lblStatus.Text = "Bal Qty already Zero!"
                        Return False
                    End If
                End If
            Next
            lblStatus.ForeColor = Color.Red
            lblStatus.Text = "Part ID not found for this Rental!"
            Return False
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try

    End Function
    Private Sub txtAssetNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAssetNumber.TextChanged

    End Sub

    Private Function loadItemDesc() As Boolean
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim sql As String
        con.ConnectionString = ConnectServer()
        Try

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            sql = _
"SELECT a.part_id, b.description, a.item_code FROM tbl_item a" & _
" left join tbl_part b on a.part_id = b.part_id where a.asset_number = '" & txtAssetNumber.Text & "'"

            cmd = New SqlCommand(sql, con)
            Dim dtItemDesc As New DataTable

            Dim adpt As New Data.SqlClient.SqlDataAdapter(cmd)
            adpt.Fill(dtItemDesc)
            If dtItemDesc.Rows.Count = 0 Then
                ' MsgBox("Asset Number not found!")
                lblStatus.ForeColor = Color.Red
                lblStatus.Text = "Asset Number not found!"
                strItemCode = ""
                txtPartID.Text = ""
                txtDescription.Text = ""
                Return False
            Else
                txtPartID.Text = dtItemDesc.Rows(0).Item("part_id").ToString
                txtDescription.Text = dtItemDesc.Rows(0).Item("description").ToString
                strItemCode = dtItemDesc.Rows(0).Item("item_code").ToString
                Return True
            End If
            con.Dispose()
            cmd.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub dgvAssetList_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAssetList.CellContentClick

    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedIndex = 1 Then
            loadItemScanned()
        End If
    End Sub
End Class