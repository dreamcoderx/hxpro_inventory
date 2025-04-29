Imports System.Data
Imports System.Data.SqlClient
Imports System.Xml
Public Class frmRentalCheckIn
    Dim dtPartRequest As New DataTable
    Dim dtAssetScanned As New DataTable
    Dim strItemCode As String
    Private Sub frm_create_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadRentalHDR()
        loadPartRequest()
        loadSubAsset()
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
"select b.item_code, b.asset_number, c.description, a.dt_out, a.dt_in from tbl_rental_asset a" & _
" left join tbl_item b on a.item_code = b.item_code" & _
" left join tbl_part c on b.part_id = c.part_id" & _
" where a.rental_id = '" & lblRentalID.Text & "'"

            cmd = New SqlCommand(sql, con)
            'Dim dtAssetList As New DataTable
            dtAssetScanned.Rows.Clear()
            Dim adpt As New Data.SqlClient.SqlDataAdapter(cmd)
            dtAssetScanned.Rows.Clear()
            adpt.Fill(dtAssetScanned)
            dgvAssetList.DataSource = dtAssetScanned
            con.Dispose()
            cmd.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
    Private Function CheckIn(ByVal strAssetNumber) As String
        For ctr As Integer = 0 To dtAssetScanned.Rows.Count - 1
            If dtAssetScanned.Rows(ctr).Item("asset_number") = strAssetNumber Then
                Return dtAssetScanned.Rows(ctr).Item("item_code")
            End If
        Next
        Return ""
    End Function
    Private Function loadSubAsset() As Boolean
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim sql As String
        con.ConnectionString = ConnectServer()
        Try
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            sql = _
"select c.asset_number as set_barcode, b.asset_number, b.serial_number," & _
" b.part_id, b.description, b.model_no, b.cat_desc, b.sub_cat_desc" & _
" from tbl_rental_asset a" & _
" left join v_set_barcode_details b on a.item_code = b.set_item_code" & _
" left join tbl_item c on a.item_code = c.item_code" & _
" where a.rental_id = '" & lblRentalID.Text & "' and b.set_item_code is not null"

            cmd = New SqlCommand(sql, con)
            Dim dtSubAssetList As New DataTable
            Dim adpt As New Data.SqlClient.SqlDataAdapter(cmd)
            dtSubAssetList.Rows.Clear()
            adpt.Fill(dtSubAssetList)
            dgvSubAsset.DataSource = dtSubAssetList
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
            strItemCode = CheckIn(txtAssetNumber.Text)
            If strItemCode = String.Empty Then
                lblStatus.ForeColor = Color.Red
                lblStatus.Text = "Asset Number not found on this Rental!"
            Else
                If UpdateCheckIN(strItemCode) Then
                    loadItemScanned()
                End If

            End If
            txtAssetNumber.Text = ""
            txtAssetNumber.Focus()

        End If

    End Sub

    Private Function deleteItem(ByVal strItemCode As String) As Boolean
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim sql As String = ""
        Try
            con.ConnectionString = ConnectServer()
            con.Open()
            sql = _
"DELETE FROM [tbl_rental_asset]" & _
" WHERE [item_code] = @item_code and [rental_id] = @rental_id"
            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@item_code", strItemCode)
            cmd.Parameters.AddWithValue("@rental_id", lblRentalID.Text)
            If cmd.ExecuteNonQuery() > 0 Then
                Return True
            End If
            Return False
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try

    End Function

    Private Sub txtAssetNumber_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAssetNumber.MouseEnter

    End Sub
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

    Private Function UpdateCheckIN(ByVal strItemCode As String) As Boolean
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim sql As String = ""
        Try
            con.ConnectionString = ConnectServer()
            con.Open()

            sql = "UPDATE [tbl_rental_asset] SET [dt_in] = @dt_in, [user_in] = @user_in  where [item_code] = @item_code and [rental_id] = @rental_id"

            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@item_code", strItemCode)
            cmd.Parameters.AddWithValue("@rental_id", lblRentalID.Text)
            cmd.Parameters.AddWithValue("@dt_in", Date.Now)
            cmd.Parameters.AddWithValue("@user_in", user_id)


            If cmd.ExecuteNonQuery() > 0 Then
                lblStatus.ForeColor = Color.Green
                lblStatus.Text = "Check Out Successfull!"
                Return True
            Else
                lblStatus.ForeColor = Color.Red
                lblStatus.Text = "Check Out Failed!"
                Return False
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try

    End Function

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If dgvAssetList.CurrentRow.Index > -1 Then
            Dim a As System.Windows.Forms.DialogResult
            Dim strItemCode As String = (dgvAssetList.Item("item_code", dgvAssetList.CurrentRow.Index).Value())
            a = MessageBox.Show(String.Format("Are you sure you want to remove asset number: {0}?", dgvAssetList.Item("asset_number", dgvAssetList.CurrentRow.Index).Value()), _
                                         "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            If a = DialogResult.Yes Then
                If deleteItem(strItemCode) Then
                    MsgBox("Item successfully remove!")
                    loadItemScanned()
                Else
                    MsgBox("Item failed to remove!")
                End If
            End If
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        loadPartRequest()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        loadSubAsset()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        loadItemScanned()
    End Sub
End Class