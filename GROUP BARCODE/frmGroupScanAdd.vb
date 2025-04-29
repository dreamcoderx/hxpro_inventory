Imports System.Data.SqlClient

Public Class frmGroupScanAdd
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
String.Format( _
  "SELECT [group_id]" & _
" ,[group_barcode]" & _
" ,[description]" & _
" FROM [tbl_group_hdr]" & _
" where [group_id] = '{0}'", _
txtGroupID.Text)

            cmd = New SqlCommand(sql, con)
            Dim dtSetDetails As New DataTable
            Dim adpt As New Data.SqlClient.SqlDataAdapter(cmd)
            adpt.Fill(dtSetDetails)
            If dtSetDetails.Rows.Count = 0 Then
                MsgBox("Group Barcode Not Found!")
                Return False
            Else
                txtGroupBarcode.Text = dtSetDetails.Rows(0).Item("group_barcode").ToString
                txtGroupDescription.Text = dtSetDetails.Rows(0).Item("description").ToString
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
String.Format( _
"SELECT tgl.[item_code]" & _
" ,ast.[asset_number]" & _
" ,ast.[serial_number]" & _
" ,ast.[part_id]" & _
" ,ast.[description]" & _
" ,ast.[model_no]" & _
" ,ast.[brand_name]" & _
" ,ast.[cat_desc]" & _
" ,ast.[sub_cat_desc]" & _
" FROM [tbl_group_line] tgl" & _
" LEFT JOIN [tbl_group_hdr] tgh on tgh.group_id = tgl.group_id" & _
" left join [v_asset_all] ast on ast.item_code = tgl.item_code" & _
" where tgl.group_id = '{0}'" _
    , txtGroupID.Text)
            cmd = New SqlCommand(sql, con)
            Dim dtSetDetails As New DataTable
            Dim adpt As New Data.SqlClient.SqlDataAdapter(cmd)
            adpt.Fill(dtSetDetails)
            dgvAssetList.DataSource = dtSetDetails

            dgvAssetList.Columns(0).HeaderText = "ITEM CODE"
            dgvAssetList.Columns(1).HeaderText = "ASSET NUMBER"
            dgvAssetList.Columns(2).HeaderText = "SERIAL NUMBER"
            dgvAssetList.Columns(3).HeaderText = "PART ID"
            dgvAssetList.Columns(4).HeaderText = "DESCRIPTION"
            dgvAssetList.Columns(5).HeaderText = "MODEL NO"
            dgvAssetList.Columns(6).HeaderText = "BRAND"
            dgvAssetList.Columns(7).HeaderText = "CATEGORY"
            dgvAssetList.Columns(8).HeaderText = "SUB CATEGORY"

            dgvAssetList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            dgvAssetList.AutoResizeColumns()

            lblTot.Text = dtSetDetails.Rows.Count.ToString
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Dispose()
            cmd.Dispose()
        End Try
    End Sub

    Private Sub frmSetAddRemove_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadSetDetails()
        loadSetDetailsChild()
    End Sub

    Private Sub txtAssetNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAssetNumber.KeyPress
        Dim Keyascii As Integer = AscW(e.KeyChar)
        If Keyascii = 13 And txtAssetNumber.Text <> "" Then
            If loadItemDesc(txtAssetNumber.Text) = False Then
                Exit Sub
            End If

            If InsertCmd(txtGroupID.Text, strItemCode) Then
                lblStatus.ForeColor = Color.Green
                lblStatus.Text = String.Format("ASSET NUMBER SUCCESFULLY ADDED TO THE GROUP!{0}ASSET NUMBER:{1}", vbCrLf, txtAssetNumber.Text)
                loadSetDetailsChild()
            Else
                lblStatus.ForeColor = Color.Red
                lblStatus.Text = String.Format("ASSET NUMBER FAILED TO BE ADDED TO THE GROUP!{0}ASSET NUMBER:{1}", vbCrLf, txtAssetNumber.Text)
            End If
            txtAssetNumber.Focus()
            txtAssetNumber.SelectAll()
        End If
        
    End Sub

    Private Function loadItemDesc(ByVal AssetNumber As String) As Boolean
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim sql As String
        con.ConnectionString = ConnectServer()
        Try

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            sql = _
"SELECT [item_code]" & _
" ,[asset_number]" & _
" ,[serial_number]" & _
" ,[part_id]" & _
" ,[description]" & _
" ,[model_no]" & _
" ,[brand_name]" & _
" ,[cat_desc]" & _
" ,[sub_cat_desc]" & _
" FROM [v_asset_all]" & _
" WHERE [asset_number] = '" & AssetNumber & "'"
            cmd = New SqlCommand(sql, con)
            Dim dtItemDesc As New DataTable

            Dim adpt As New Data.SqlClient.SqlDataAdapter(cmd)
            adpt.Fill(dtItemDesc)
            If dtItemDesc.Rows.Count = 0 Then
                lblStatus.ForeColor = Color.Red
                lblStatus.Text = "Asset Number not found!"
                txtPartID.Text = ""
                txtDescription.Text = ""
                txtModel.Text = ""
                txtBrand.Text = ""
                txtSerialNumber.Text = ""
                txtCategory.Text = ""
                txtSubCategory.Text = ""
                Return False
            Else
                strItemCode = dtItemDesc.Rows(0).Item("item_code").ToString
                txtPartID.Text = dtItemDesc.Rows(0).Item("part_id").ToString
                txtDescription.Text = dtItemDesc.Rows(0).Item("description").ToString
                txtModel.Text = dtItemDesc.Rows(0).Item("model_no").ToString
                txtBrand.Text = dtItemDesc.Rows(0).Item("brand_name").ToString
                txtSerialNumber.Text = dtItemDesc.Rows(0).Item("serial_number").ToString
                txtCategory.Text = dtItemDesc.Rows(0).Item("cat_desc").ToString
                txtSubCategory.Text = dtItemDesc.Rows(0).Item("sub_cat_desc").ToString
                Return True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            con.Dispose()
            cmd.Dispose()
        End Try
    End Function

    Private Function InsertCmd(ByVal GroupID As String, ByVal ItemCode As String) As Boolean
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim sql As String
        con.ConnectionString = ConnectServer()
        Try

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            sql = _
"select" & _
" COUNT(*) from [tbl_group_hdr] tgh" & _
" left join [tbl_group_line] tgl on tgl.group_id = tgh.group_id" & _
" where tgh.group_id = '" & GroupID & "' and item_code = '" & ItemCode & "'"
            cmd = New SqlCommand(sql, con)
            If cmd.ExecuteScalar > 0 Then
                lblStatus.Text = "Asset already exist in the Group!"
                Return False
            End If
            sql = "INSERT INTO [tbl_group_line]" & _
                  " ([group_id]" & _
                  " ,[item_code])" & _
                  " VALUES" & _
                  " (@group_id" & _
                  " ,@item_code)"

            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@group_id", txtGroupID.Text)
            cmd.Parameters.AddWithValue("@item_code", strItemCode)
            If cmd.ExecuteNonQuery() > 0 Then
                Return True
            End If
            Return False
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            con.Dispose()
            cmd.Dispose()
        End Try
    End Function



    Private Function removeItem(ByVal strItemCode As String, ByVal strGroupID As String) As Boolean
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim sql As String
        con.ConnectionString = ConnectServer()
        Try

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            sql = "DELETE FROM [tbl_group_line]" & _
"WHERE group_id = @group_id and item_code = @item_code"
            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@item_code", strItemCode)
            cmd.Parameters.AddWithValue("@group_id", strGroupID)

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
            Dim ItemCode As String = (dgvAssetList.Item(0, dgvAssetList.CurrentRow.Index).Value())
            a = MessageBox.Show(String.Format("Are you sure you want to remove asset number:{0}?", ItemCode), _
                                         "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            If a = DialogResult.Yes Then
                If removeItem(ItemCode, txtGroupID.Text) Then
                    MsgBox("Asset Number successfully remove to the group!", MsgBoxStyle.Information, "HXPRO")
                    loadSetDetailsChild()
                Else
                    MsgBox("Asset Number failed to remove to the group!", MsgBoxStyle.Exclamation, "HXPRO")
                End If
            End If
        End If

    End Sub

    Private Sub txt_description_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtGroupDescription.TextChanged
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If txtGroupBarcode.Text = String.Empty Or txtGroupDescription.Text = String.Empty Then
            MsgBox("Please Complete Data!")
            Exit Sub
        End If
        If UpdateCmd() Then
            MsgBox("Update Successfull!")
        Else
            MsgBox("Update Failed!")
        End If
    End Sub
    Private Function UpdateCmd() As Boolean
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim sql As String
        con.ConnectionString = ConnectServer()
        Try

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            sql = _
"UPDATE [tbl_group_hdr]" & _
" SET [group_barcode] = @group_barcode" & _
" ,[description] = @description" & _
" WHERE [group_id] = @group_id"

            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@group_id", txtGroupID.Text)
            cmd.Parameters.AddWithValue("@group_barcode", txtGroupBarcode.Text)
            cmd.Parameters.AddWithValue("@description", txtGroupDescription.Text)

            If cmd.ExecuteNonQuery > 0 Then
                Return True
            End If
            Return False
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Dispose()
            cmd.Dispose()
        End Try

    End Function

    Private Sub lblStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblStatus.Click

    End Sub
End Class