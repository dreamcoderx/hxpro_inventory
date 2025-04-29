Imports System.Data
Imports System.Data.SqlClient
Imports System.Xml
Public Class frmCreateAssetScan
    Private Function insert_cmd() As Boolean
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim sql As String
        con.ConnectionString = ConnectServer()
        Try
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            sql = _
"SELECT count(*)" & _
" FROM [tbl_item]" & _
" WHERE asset_number = '" & txtAssetNumber.Text & "'"
            cmd = New SqlCommand(sql, con)
            If cmd.ExecuteScalar > 0 Then
                MsgBox("Asset Number already exist!")
                con.Dispose()
                cmd.Dispose()
                Return False
            End If

            sql = _
"INSERT INTO [tbl_item]" & _
"([part_id]" & _
", [serial_number]" & _
", [asset_number])" & _
" VALUES" & _
"(@part_id" & _
",@serial_number" & _
",@asset_number)"
            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@part_id", txt_part_id.Text)
            cmd.Parameters.AddWithValue("@serial_number", txtSerialNumber.Text)
            cmd.Parameters.AddWithValue("@asset_number", txtAssetNumber.Text)
            If cmd.ExecuteNonQuery() > 0 Then
                con.Dispose()
                cmd.Dispose()
                Return True
            End If

            con.Dispose()
            cmd.Dispose()
            Return False
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If txt_part_id.Text <> "" And txtAssetNumber.Text <> "" Then
            If insert_cmd() Then
                loadAssetNumber()
                lblStatus.Text = String.Format("Asset Number:{0} successfully added!", txtAssetNumber.Text)
                txtAssetNumber.Focus()
            Else
                lblStatus.Text = String.Format("Asset Number:{0} failed to add!", txtAssetNumber.Text)
                txtAssetNumber.Focus()
            End If

        Else
        MsgBox("Please Complete Data!")
        End If

    End Sub
    Private Function loadAssetNumber() As Boolean
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim sql As String
        con.ConnectionString = ConnectServer()
        Try

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            sql = _
"SELECT [serial_number]" & _
" , [asset_number]" & _
" FROM [tbl_item]" & _
" where part_id = '" & txt_part_id.Text & "'"
            cmd = New SqlCommand(sql, con)
            Dim dtRentalHdr As New DataTable

            Dim adpt As New Data.SqlClient.SqlDataAdapter(cmd)
            adpt.Fill(dtRentalHdr)
            dgvAssetList.DataSource = dtRentalHdr
            con.Dispose()
            cmd.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function

    Private Sub btn_browse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_browse.Click
        Dim a As New frm_part1
        If a.ShowDialog() = DialogResult.OK Then
            txt_part_id.Text = (a.dgv_parts.Item("part_id", a.dgv_parts.CurrentRow.Index).Value())
            txt_part_number.Text = (a.dgv_parts.Item("part_number", a.dgv_parts.CurrentRow.Index).Value())
            txt_description.Text = (a.dgv_parts.Item("description", a.dgv_parts.CurrentRow.Index).Value())
            txt_brand.Text = (a.dgv_parts.Item("brand_name", a.dgv_parts.CurrentRow.Index).Value().ToString)
            txt_model.Text = (a.dgv_parts.Item("model_no", a.dgv_parts.CurrentRow.Index).Value().ToString)
            txt_category.Text = (a.dgv_parts.Item("cat_desc", a.dgv_parts.CurrentRow.Index).Value().ToString)
            txt_sub_category.Text = (a.dgv_parts.Item("sub_cat_desc", a.dgv_parts.CurrentRow.Index).Value().ToString)
            loadAssetNumber()
        Else
            txt_part_id.Text = ""
            txt_part_number.Text = ""
            txt_description.Text = ""
            txt_brand.Text = ""
            txt_model.Text = ""
            txt_category.Text = ""
            txt_sub_category.Text = ""
        End If
    End Sub

    Private Sub txtAssetNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAssetNumber.KeyPress
        Dim Keyascii As Integer = AscW(e.KeyChar)
        If Keyascii = 13 And txtAssetNumber.Text <> "" Then
            txtSerialNumber.Focus()
        End If
    End Sub


    Private Sub txtSerialNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSerialNumber.KeyPress
        Dim Keyascii As Integer = AscW(e.KeyChar)
        If Keyascii = 13 And txtAssetNumber.Text <> "" Then
            Button1_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub txtSerialNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSerialNumber.TextChanged

    End Sub
End Class