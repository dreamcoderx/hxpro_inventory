Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO
Imports System.Xml
Public Class frmRepairLine
    Dim dtPartRequest As New DataTable
    Dim strItemCode As String
    Private Sub frm_create_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadRentalHDR()
        loadRental_item()
        'loadPartRequest()
        'loadSubAsset()
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
"select a.part_id, c.description, c.model_no, d.brand_name, a.qty as qty_request, b.qty as qty_scanned from tbl_rental_line a" & _
" left join v_rental_part_qty b on a.rental_id = b.rental_id and a.part_id = b.part_id" & _
" left join tbl_part c on a.part_id = c.part_id" & _
" left join tbl_brand d on c.brand_id = d.brand_id" & _
" where a.rental_id = '" & lblRepairID.Text & "'"
            cmd = New SqlCommand(sql, con)

            Dim adpt As New Data.SqlClient.SqlDataAdapter(cmd)
            dtPartRequest.Rows.Clear()
            adpt.Fill(dtPartRequest)
            'dgvRentalHDR.DataSource = dtPartRequest
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
" where a.rental_id = '" & lblRepairID.Text & "'"

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
" where a.rental_id = '" & lblRepairID.Text & "' and b.set_item_code is not null"

            cmd = New SqlCommand(sql, con)
            Dim dtSubAssetList As New DataTable
            Dim adpt As New Data.SqlClient.SqlDataAdapter(cmd)
            dtSubAssetList.Rows.Clear()
            adpt.Fill(dtSubAssetList)
            'dgvSubAsset.DataSource = dtSubAssetList
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
String.Format("SELECT [repair_id] FROM [tbl_repair_hdr] where [repair_number] = '{0}'", txtRepairNumber.Text)

            cmd = New SqlCommand(sql, con)
            Dim dtRentalHdr As New DataTable

            Dim adpt As New Data.SqlClient.SqlDataAdapter(cmd)
            adpt.Fill(dtRentalHdr)
            If dtRentalHdr.Rows.Count = 0 Then
                MsgBox("Repair ID not found!")
                Return False
            Else
                lblRepairID.Text = dtRentalHdr.Rows(0).Item("repair_id").ToString
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
            sql = _
"DELETE FROM [tbl_rental_asset]" & _
" WHERE [item_code] = @item_code and [rental_id] = @rental_id and [dt_in] is null"
            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@item_code", strItemCode)
            cmd.Parameters.AddWithValue("@rental_id", lblRepairID.Text)
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

    Private Function ItemRepairedNotReturned(ByVal strItemCode As String) As Boolean
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim sql As String = ""
        Try

            con.ConnectionString = ConnectServer()
            con.Open()

            sql = _
"select COUNT(*) from tbl_repair_line" & _
" where item_code = @item_code and status_id is null"
            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@item_code", strItemCode)
            If cmd.ExecuteScalar > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try

    End Function



    Private Function InsertRepairLine(ByVal strItemCode As String) As Boolean
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim sql As String = ""
        Try

            con.ConnectionString = ConnectServer()
            con.Open()

            sql = _
"INSERT INTO [tbl_repair_line]" & _
" ([repair_id]" & _
" ,[item_code]" & _
" ,[repair_description])" & _
" VALUES" & _
" (@repair_id" & _
" ,@item_code" & _
" ,@repair_description)"
            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@repair_id", lblRepairID.Text)
            cmd.Parameters.AddWithValue("@item_code", strItemCode)
            cmd.Parameters.AddWithValue("@repair_description", txtRepairDescription.Text)

            If cmd.ExecuteNonQuery() > 0 Then
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
" ,@remarks)"
                cmd = New SqlCommand(sql, con)
                cmd.Parameters.AddWithValue("@status", False)
                cmd.Parameters.AddWithValue("@item_code", strItemCode)
                cmd.Parameters.AddWithValue("@remarks", txtRepairDescription.Text)
                cmd.Parameters.AddWithValue("@date", Date.Now)
                cmd.Parameters.AddWithValue("@scanned_by", user_id)
                'Return True
                If cmd.ExecuteNonQuery > 0 Then
                    Return True
                End If
            End If

            Return False
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try

    End Function

    Private Function checkOut() As Boolean
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim sql As String = ""
        Try

            con.ConnectionString = ConnectServer()
            con.Open()
            sql = _
    "INSERT INTO [tbl_rental_asset]" & _
    " ([item_code]" & _
    " ,[rental_id]" & _
    " ,[dt_out], [user_id_out])" & _
    " VALUES" & _
    " (@item_code" & _
    " ,@rental_id" & _
    " ,@dt_out, @user_id_out)"
            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@item_code", strItemCode)
            cmd.Parameters.AddWithValue("@rental_id", lblRepairID.Text)
            cmd.Parameters.AddWithValue("@dt_out", Date.Now)
            cmd.Parameters.AddWithValue("@user_id_out", user_id)
            If cmd.ExecuteNonQuery() > 0 Then
                Return True
            End If
            Return False
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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        loadPartRequest()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        loadSubAsset()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        loadItemScanned()
    End Sub


    Private Function loadAll() As Boolean
        '        Dim con As New SqlConnection
        '        Dim cmd As New SqlCommand
        '        Dim myData As New DataSet
        '        Dim sql As String
        '        con.ConnectionString = ConnectServer()
        '        Try

        '            If con.State = ConnectionState.Closed Then
        '                con.Open()
        '            End If
        '            sql = _
        '" select * from tbl_rental_asset a" & _
        '" left join v_set_barcode_details b on a.item_code = b.set_item_code" & _
        '" where a.rental_id = '" & lblRepairID.Text & "'"

        '            cmd.CommandText = sql
        '            '"select * from vw_dispatch"
        '            cmd.Connection = con

        '            Dim adpt As New Data.SqlClient.SqlDataAdapter(cmd)

        '            'adpt.SelectCommand = cmd
        '            adpt.Fill(myData)
        '            dgvAssetList.



        '            con.Dispose()
        '            cmd.Dispose()
        '        Catch ex As Exception
        '            MsgBox(ex.Message)
        '        End Try
    End Function

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        'loadAll()
        loadReport()
    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBrand.TextChanged

    End Sub

    Private Sub TabPage2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'loadReport()
    End Sub
    Private Sub loadReport()
        'Dim mySql As String
        Dim myReport As New ReportDocument
        Dim myData As New DataSet
        Dim str_where As List(Of String) = New List(Of String)
        Dim str_where_con As String = ""
        'mySql = "SELECT item_code, item_desc, uom, barcode FROM tbl_items"
        Try
            Dim connection As New System.Data.SqlClient.SqlConnection(ConnectServer())
            Dim sql As String
            sql = _
"SELECT" & _
" b.asset_number, b.serial_number" & _
", c.part_id, c.model_no, d.brand_name, c.description, h.user_name" & _
", a.[repair_description]" & _
", g.repair_number, g.company, g.address, g.date" & _
" FROM [tbl_repair_line] a" & _
" left join tbl_item b on a.item_code = b.item_code" & _
" left join tbl_part c on b.part_id = c.part_id" & _
" left join tbl_brand d on c.brand_id = d.brand_id" & _
" left join tbl_repair_hdr g on a.repair_id = g.repair_id" & _
" left join tbl_user h on g.created_by = h.user_name" & _
" WHERE a.repair_id = '" & lblRepairID.Text & "'"
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If



            'MsgBox(sql)
            Dim command As New SqlCommand(sql, connection)

            Dim adpt As New Data.SqlClient.SqlDataAdapter(command)
            ' dt.Clear()
            'adpt.Fill(dt)
            'dgv_parts.DataSource = Nothing


            command.CommandText = sql
            '"select * from vw_dispatch"
            command.Connection = connection

            adpt.SelectCommand = command
            adpt.Fill(myData)
            If Not Directory.Exists(Path + "\rpt\") Then
                Directory.CreateDirectory(Path + "\rpt\")
            End If
            'myData.WriteXml(Path + "\rpt\repair6.xml", XmlWriteMode.WriteSchema)
            'dgv_parts.DataSource = myData.Tables(0)
            'dgv_parts.AutoResizeColumns()

            Dim A As New frm_rpt
            myReport.Load(Path + "\rpt\repair6.rpt")
            myReport.SetDataSource(myData)
            A.myViewer.ReportSource = myReport
            A.Text = "REPAIR REPORT"
            A.ShowDialog()



        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button5_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If strItemCode <> "" And txtDescription.Text <> "" Then
            If ItemRepairedNotReturned(strItemCode) Then
                MsgBox("Item is on repair status!, Scan at Repair Return first...")
                Exit Sub
            End If

            If InsertRepairLine(strItemCode) Then
                MsgBox("Successfully Added!")
                txtAssetNumber.Focus()
                loadRental_item()
            Else
                MsgBox("Failed to Add")
            End If
        Else
            MsgBox("Complete Data!")

        End If
    End Sub
    Private Function loadRental_item() As Boolean
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim sql As String
        con.ConnectionString = ConnectServer()
        Try

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            sql = _
"SELECT" & _
" b.asset_number" & _
", c.model_no, d.brand_name, f.cat_desc, e.sub_cat_desc" & _
", a.[repair_description]" & _
" FROM [tbl_repair_line] a" & _
" left join tbl_item b on a.item_code = b.item_code" & _
" left join tbl_part c on b.part_id = c.part_id" & _
" left join tbl_brand d on c.brand_id = d.brand_id" & _
" left join tbl_sub_category e on c.sub_cat_id = e.sub_cat_id" & _
" left join tbl_category f on e.cat_id = f.cat_id" & _
" left join tbl_repair_hdr g on a.repair_id = g.repair_id" & _
" WHERE a.repair_id = '" & lblRepairID.Text & "'"
            cmd = New SqlCommand(sql, con)

            Dim adpt As New Data.SqlClient.SqlDataAdapter(cmd)
            dtPartRequest.Rows.Clear()
            adpt.Fill(dtPartRequest)
            dgvAssetList.DataSource = dtPartRequest
            con.Dispose()
            cmd.Dispose()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function
End Class