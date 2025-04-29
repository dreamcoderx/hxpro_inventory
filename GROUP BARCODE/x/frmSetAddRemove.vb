Imports System.Data
Imports System.Data.SqlClient
Imports System.Xml
Public Class frmSetAddRemove
    Dim PickDelDT As DateTime
    Dim strItemCode As String

    Private Function loadSetDetails() As Boolean
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim sql As String
        con.ConnectionString = ConnectServer()
        Try

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            sql = _
String.Format("SELECT [item_code], [set_barcode] ,[serial_number] ,[part_id] ,[part_number] ,[description] ," & _
              "[model_no] ,[brand_name] ,[cat_desc] ,[sub_cat_desc]  FROM [v_set_barcode] where [set_barcode] = '{0}'", _
              txtSetBarcode.Text)

            cmd = New SqlCommand(sql, con)
            Dim dtSetDetails As New DataTable

            Dim adpt As New Data.SqlClient.SqlDataAdapter(cmd)
            adpt.Fill(dtSetDetails)
            If dtSetDetails.Rows.Count = 0 Then
                MsgBox("Set Barcode Not Found!")
                Return False
            Else
                txtSerialNumber.Text = dtSetDetails.Rows(0).Item("serial_number").ToString
                txt_part_id.Text = dtSetDetails.Rows(0).Item("part_id").ToString
                txt_part_number.Text = dtSetDetails.Rows(0).Item("part_number").ToString
                txt_description.Text = dtSetDetails.Rows(0).Item("description").ToString
                txt_brand.Text = dtSetDetails.Rows(0).Item("brand_name").ToString
                txt_model.Text = dtSetDetails.Rows(0).Item("model_no").ToString
                txt_category.Text = dtSetDetails.Rows(0).Item("cat_desc").ToString
                txt_sub_category.Text = dtSetDetails.Rows(0).Item("sub_cat_desc").ToString
                strItemCode = dtSetDetails.Rows(0).Item("item_code").ToString
                Return True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Dispose()
            cmd.Dispose()
        End Try
    End Function

    Private Sub loadSetDetailsChild()
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim sql As String
        con.ConnectionString = ConnectServer()
        Try

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            sql = _
String.Format("Select asset_number, serial_number, part_id, description, model_no, sub_cat_desc, cat_desc from v_set_barcode_details where set_item_code = '{0}'", _
             strItemCode)
            cmd = New SqlCommand(sql, con)
            Dim dtSetDetails As New DataTable
            Dim adpt As New Data.SqlClient.SqlDataAdapter(cmd)
            adpt.Fill(dtSetDetails)
            dgvAssetList.DataSource = dtSetDetails
            lblTot.Text = dtSetDetails.Rows.Count.ToString
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Dispose()
            cmd.Dispose()
        End Try
    End Sub


   

    Private Sub btn_browse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim a As New frm_part1
        If a.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txt_part_id.Text = (a.dgv_parts.Item("part_id", a.dgv_parts.CurrentRow.Index).Value())
            txt_part_number.Text = (a.dgv_parts.Item("part_number", a.dgv_parts.CurrentRow.Index).Value())
            txt_description.Text = (a.dgv_parts.Item("description", a.dgv_parts.CurrentRow.Index).Value())
            txt_brand.Text = (a.dgv_parts.Item("brand_name", a.dgv_parts.CurrentRow.Index).Value().ToString)
            txt_model.Text = (a.dgv_parts.Item("model_no", a.dgv_parts.CurrentRow.Index).Value().ToString)
            txt_category.Text = (a.dgv_parts.Item("cat_desc", a.dgv_parts.CurrentRow.Index).Value().ToString)
            txt_sub_category.Text = (a.dgv_parts.Item("sub_cat_desc", a.dgv_parts.CurrentRow.Index).Value().ToString)
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

    Private Sub GroupBox2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub frmSetAddRemove_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadSetDetails()
        loadSetDetailsChild()
    End Sub

    Private Sub txtAssetNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAssetNumber.KeyPress
        Dim Keyascii As Integer = AscW(e.KeyChar)
        If Keyascii = 13 And txtAssetNumber.Text <> "" Then
            If loadItemDesc() Then
                lblStatus.ForeColor = Color.Green
                lblStatus.Text = String.Format("ASSET NUMBER SUCCESFULLY ADDED TO THE SET!{0}ASSET NUMBER:{1}", vbCrLf, txtAssetNumber.Text)
                loadSetDetailsChild()
            End If
            txtAssetNumber.Text = ""
            txtAssetNumber.Focus()
        End If
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
                txtPartID.Text = ""
                txtDescription.Text = ""
                Return False
            Else
                txtPartID.Text = dtItemDesc.Rows(0).Item("part_id").ToString
                txtDescription.Text = dtItemDesc.Rows(0).Item("description").ToString
                sql = "UPDATE [tbl_item]" & _
   " SET [set_item_code] = @set_item_code where [asset_number] = @asset_number"
                cmd = New SqlCommand(sql, con)
                cmd.Parameters.AddWithValue("@set_item_code", strItemCode)
                cmd.Parameters.AddWithValue("@asset_number", txtAssetNumber.Text)

                If cmd.ExecuteNonQuery() > 0 Then
                    Return True
                Else
                    Return False
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            con.Dispose()
            cmd.Dispose()
        End Try
    End Function

    Private Function removeItem(ByVal strAssetNumber) As Boolean
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim sql As String
        con.ConnectionString = ConnectServer()
        Try

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            sql = "UPDATE [tbl_item]" & _
" SET [set_item_code] = @set_item_code where [asset_number] = @asset_number"
            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@set_item_code", DBNull.Value)
            cmd.Parameters.AddWithValue("@asset_number", strAssetNumber)

            If cmd.ExecuteNonQuery() > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            con.Dispose()
            cmd.Dispose()
        End Try
    End Function


    Private Sub txtAssetNumber_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAssetNumber.Resize

    End Sub

    Private Sub txtAssetNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAssetNumber.TextChanged

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If dgvAssetList.RowCount > 0 Then
            Dim a As System.Windows.Forms.DialogResult
        Dim strAssetNumber As String = (dgvAssetList.Item("asset_number", dgvAssetList.CurrentRow.Index).Value())
        a = MessageBox.Show(String.Format("Are you sure you want to remove asset number:{0}?", strAssetNumber), _
                                     "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        If a = Windows.Forms.DialogResult.Yes Then
            If removeItem(strAssetNumber) Then
                MsgBox("Asset Number successfully remove!", MsgBoxStyle.Information, "HXPRO")
                loadSetDetailsChild()
            Else
                MsgBox("Asset Number failed to remove!", MsgBoxStyle.Exclamation, "HXPRO")
            End If
        End If
        End If

    End Sub
End Class