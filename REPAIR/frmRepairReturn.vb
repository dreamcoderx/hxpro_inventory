Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO
Imports System.Xml
Public Class frmRepairReturn
    Dim dtPartRequest As New DataTable
    Dim strItemCode As String
    Private Sub frm_create_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'loadRentalHDR()
        '   loadRepairDR()
        'loadPartRequest()
        'loadSubAsset()
    End Sub
    '    Private Function loadPartRequest() As Boolean
    '        Dim con As New SqlConnection
    '        Dim cmd As New SqlCommand
    '        Dim sql As String
    '        con.ConnectionString = ConnectServer()
    '        Try

    '            If con.State = ConnectionState.Closed Then
    '                con.Open()
    '            End If
    '            sql = _
    '"select a.part_id, c.description, c.model_no, d.brand_name, a.qty as qty_request, b.qty as qty_scanned from tbl_rental_line a" & _
    '" left join v_rental_part_qty b on a.rental_id = b.rental_id and a.part_id = b.part_id" & _
    '" left join tbl_part c on a.part_id = c.part_id" & _
    '" left join tbl_brand d on c.brand_id = d.brand_id" & _
    '" where a.rental_id = '" & lblRepairID.Text & "'"
    '            cmd = New SqlCommand(sql, con)

    '            Dim adpt As New Data.SqlClient.SqlDataAdapter(cmd)
    '            dtPartRequest.Rows.Clear()
    '            adpt.Fill(dtPartRequest)
    '            'dgvRentalHDR.DataSource = dtPartRequest
    '            con.Dispose()
    '            cmd.Dispose()
    '        Catch ex As Exception
    '            MsgBox(ex.Message)
    '        End Try
    '    End Function


    Private Sub txtAssetNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAssetNumber.KeyPress
        Dim Keyascii As Integer = AscW(e.KeyChar)
        If Keyascii = 13 And txtAssetNumber.Text <> "" Then
            If loadItemDesc() Then
                txtRepairDescription.Focus()
            End If
        End If
    End Sub



    Private Function deleteItem(ByVal strItemCode As String) As Boolean
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim sql As String = ""
        Try
            con.ConnectionString = ConnectServer()
            con.Open()
            '            sql = _
            ''"DELETE FROM [tbl_rental_asset]" & _
            '" WHERE [item_code] = @item_code and [rental_id] = @rental_id and [dt_in] is null"
            '            cmd = New SqlCommand(sql, con)
            '            cmd.Parameters.AddWithValue("@item_code", strItemCode)
            '            cmd.Parameters.AddWithValue("@rental_id", lblRepairID.Text)
            If cmd.ExecuteNonQuery() > 0 Then
                Return True
            End If
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
"SELECT a.part_id, b.description, b.model_no, c.brand_name, a.item_code FROM tbl_item a" & _
" left join tbl_part b on a.part_id = b.part_id" & _
" left join tbl_brand c on b.brand_id = c.brand_id" & _
" where a.asset_number = '" & txtAssetNumber.Text & "'"

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
                txtModel.Text = ""
                txtBrand.Text = ""
                Return False
            Else
                txtPartID.Text = dtItemDesc.Rows(0).Item("part_id").ToString
                txtDescription.Text = dtItemDesc.Rows(0).Item("description").ToString
                txtModel.Text = dtItemDesc.Rows(0).Item("model_no").ToString
                txtBrand.Text = dtItemDesc.Rows(0).Item("brand_name").ToString
                strItemCode = dtItemDesc.Rows(0).Item("item_code").ToString
                Return True
            End If
            con.Dispose()
            cmd.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Function InsertReturn(ByVal strItemCode As String) As Boolean
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim sql As String = ""
        Try
            con.ConnectionString = ConnectServer()
            con.Open()
            sql = _
"INSERT INTO [tbl_status]" & _
" ([item_code]" & _
" ,[status]" & _
" ,[date]" & _
" ,[scanned_by]" & _
" ,[remarks])" & _
" VALUES" & _
" (@item_code " & _
" ,@status" & _
" ,@date" & _
" ,@scanned_by" & _
" ,@remarks);SELECT SCOPE_IDENTITY()"
            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@status", cbStatus.Checked)
            cmd.Parameters.AddWithValue("@item_code", strItemCode)
            cmd.Parameters.AddWithValue("@remarks", "Repair Return:" & txtRepairDescription.Text)
            cmd.Parameters.AddWithValue("@date", Date.Now)
            cmd.Parameters.AddWithValue("@scanned_by", user_id)

            Dim insertID As Integer = -1
            insertID = cmd.ExecuteScalar()
            If insertID > 0 Then
                sql = _
"UPDATE [tbl_repair_line]" & _
" SET [status_id] = @status_id" & _
" WHERE [item_code] = @item_code and [status_id] is null"
                cmd = New SqlCommand(sql, con)
                cmd.Parameters.AddWithValue("@status_id", insertID)
                cmd.Parameters.AddWithValue("@item_code", strItemCode)
                cmd.ExecuteNonQuery()
                Return True
            End If
            Return False
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try

    End Function

   
   
    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If strItemCode <> "" Or txtDescription.Text <> "" Then
            If InsertReturn(strItemCode) Then
                MsgBox("Successfull Return!")
                txtAssetNumber.Focus()
            Else
                MsgBox("Return Failed!")
            End If
        Else
            MsgBox("Complete Data!")

        End If
    End Sub
 
End Class