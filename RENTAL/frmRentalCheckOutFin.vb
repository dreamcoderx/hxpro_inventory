Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.IO.Ports
Imports System.Text.RegularExpressions

Public Class frmRentalCheckOutFin
    Dim dtPartRequest As New DataTable
    Dim strItemCode As String
    Dim dtSubAssetList As New DataTable
    ' Dim myPort As Array

    Delegate Sub SetTextCallback(ByVal [text] As String)

    Private Sub frm_create_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadRentalHDR()
        loadPartRequest()
        loadSubAsset()
        loadPort()
    End Sub

    Private Sub loadPort()
        For Each sp As String In My.Computer.Ports.SerialPortNames
            cboPort.Items.Add(Regex.Replace(sp, "[^A-Za-z0-9\-/]", ""))
        Next
        'myPort = IO.Ports.SerialPort.GetPortNames()
        'For i = 0 To UBound(myPort)
        '    cboPort.Items.Add(myPort(i))
        'Next
    End Sub

    Private Function loadPartRequest() As Boolean
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim sql As String
        Try

            If con.State = ConnectionState.Closed Then
                con.ConnectionString = ConnectServer()
                con.Open()
            End If
            sql = _
"select" & _
"  vrl.part_id" & _
" , vrl.sum_qty as qty_request" & _
" , b.qty as qty_scanned " & _
" , vpa.description" & _
" , vpa.model_no" & _
" , vpa.brand_name" & _
" , vpa.cat_desc" & _
" , vpa.sub_cat_desc" & _
"  from v_rental_line_part_sum vrl" & _
"  left join v_rental_part_qty b on vrl.rental_id = b.rental_id and vrl.part_id = b.part_id" & _
"  left join v_part_all vpa on vpa.part_id = vrl.part_id" & _
" where vrl.rental_id = '" & lblRentalID.Text & "'"
            cmd = New SqlCommand(sql, con)

            Dim adpt As New Data.SqlClient.SqlDataAdapter(cmd)
            dtPartRequest.Rows.Clear()
            adpt.Fill(dtPartRequest)
            dgvRentalHDR.DataSource = dtPartRequest

            dgvRentalHDR.Columns(0).HeaderText = "PART ID"
            dgvRentalHDR.Columns(1).HeaderText = "QTY REQUEST"
            dgvRentalHDR.Columns(2).HeaderText = "QTY SCANNED"
            dgvRentalHDR.Columns(3).HeaderText = "DESCRIPTION"
            dgvRentalHDR.Columns(4).HeaderText = "MODEL NO"
            dgvRentalHDR.Columns(5).HeaderText = "BRAND NAME"
            dgvRentalHDR.Columns(6).HeaderText = "CATEGORY"
            dgvRentalHDR.Columns(7).HeaderText = "SUB CATEGORY"

            dgvRentalHDR.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            dgvRentalHDR.AutoResizeColumns()

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
"select b.item_code" & _
" , b.asset_number" & _
" , vpa.description" & _
" , vpa.model_no" & _
" , vpa.brand_name" & _
" , vpa.cat_desc" & _
" , vpa.sub_cat_desc" & _
" , a.dt_out" & _
" , a.dt_in" & _
"  from tbl_rental_asset a " & _
"  left join tbl_item b on a.item_code = b.item_code " & _
"  left join v_part_all vpa on vpa.part_id = b.part_id " & _
" where a.rental_id = '" & lblRentalID.Text & "' order by a.dt_out desc"

            cmd = New SqlCommand(sql, con)
            Dim dtAssetList As New DataTable
            Dim adpt As New Data.SqlClient.SqlDataAdapter(cmd)
            dtAssetList.Rows.Clear()
            adpt.Fill(dtAssetList)
            dgvAssetList.DataSource = dtAssetList

            dgvAssetList.Columns(0).HeaderText = "ITEM CODE"
            dgvAssetList.Columns(1).HeaderText = "ASSET NUMBER"
            dgvAssetList.Columns(2).HeaderText = "DESCRIPTION"
            dgvAssetList.Columns(3).HeaderText = "MODEL NO"
            dgvAssetList.Columns(4).HeaderText = "BRAND"
            dgvAssetList.Columns(5).HeaderText = "CATEGORY"
            dgvAssetList.Columns(6).HeaderText = "SUB CATEGORY"
            dgvAssetList.Columns(7).HeaderText = "DATE OUT"
            dgvAssetList.Columns(8).HeaderText = "DATE IN"

            dgvAssetList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            dgvAssetList.AutoResizeColumns()

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
" where a.rental_id = '" & lblRentalID.Text & "' and b.set_item_code is not null"

            cmd = New SqlCommand(sql, con)

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
        Try
            Dim Keyascii As Integer = AscW(e.KeyChar)
            If Keyascii = 13 And txtAssetNumber.Text <> "" Then
                If check_out_asset(txtAssetNumber.Text, Integer.Parse(lblRentalID.Text), user_id) Then
                    lblStatus.ForeColor = Color.Green
                    timerAlarm.Enabled = False
                Else
                    lblStatus.ForeColor = Color.Red
                    timerAlarm.Enabled = True
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
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

    Private Function check_out_asset(vAssetNumber As String, vRentalID As Integer, vUserID As String) As Boolean
        Dim rv As Boolean
        Dim cmd As New SqlCommand
        Try
            Cursor.Current = Cursors.WaitCursor
            If Not conecDB_OK() Then Return rv
            With cmd
                .CommandText = "dbo.usp_validate_check_out"
                .CommandType = CommandType.StoredProcedure
                .Connection = connDB
                .CommandTimeout = 0
                .Parameters.Add("@asset_number", SqlDbType.NVarChar, 30).Value = vAssetNumber
                .Parameters.Add("@rental_id", SqlDbType.Int).Value = vRentalID
                .Parameters.Add("@user", SqlDbType.NVarChar, 20).Value = vUserID
                .Parameters.Add("@part_id", SqlDbType.Int).Direction = ParameterDirection.Output
                .Parameters.Add("@part_desc", SqlDbType.NVarChar, 150).Direction = ParameterDirection.Output
                .Parameters.Add("@model", SqlDbType.NVarChar, 30).Direction = ParameterDirection.Output
                .Parameters.Add("@brand", SqlDbType.NVarChar, 50).Direction = ParameterDirection.Output
                .Parameters.Add("@category", SqlDbType.NVarChar, 50).Direction = ParameterDirection.Output
                .Parameters.Add("@subcategory", SqlDbType.NVarChar, 50).Direction = ParameterDirection.Output
                .Parameters.Add("@item_code", SqlDbType.NVarChar, 50).Direction = ParameterDirection.Output
                .Parameters.Add("@msg", SqlDbType.NVarChar, 350).Direction = ParameterDirection.Output
                .Parameters.Add("@rv", SqlDbType.Int).Direction = ParameterDirection.ReturnValue
                .CommandTimeout = 0
                .ExecuteNonQuery()

                If cmd.Parameters("@rv").Value = 0 Then
                    rv = True
                Else
                End If
                lblStatus.Text = cmd.Parameters("@msg").Value.ToString

                txtPartID.Text = cmd.Parameters("@part_id").Value.ToString
                txtDescription.Text = cmd.Parameters("@part_desc").Value.ToString
                txtModel.Text = cmd.Parameters("@model").Value.ToString
                txtBrand.Text = cmd.Parameters("@brand").Value.ToString
                txtCategory.Text = cmd.Parameters("@category").Value.ToString
                txtSubCategory.Text = cmd.Parameters("@subcategory").Value.ToString
                strItemCode = cmd.Parameters("@item_code").Value.ToString
            End With

            txtAssetNumber.Focus()
            txtAssetNumber.SelectAll()
        Catch sqlex As SqlException
            lblStatus.Text = sqlex.Message
        Catch ex As Exception
            lblStatus.Text = ex.Message
        Finally
            Cursor.Current = Cursors.Default
        End Try
        Return rv
    End Function

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
"SELECT a.part_id" & _
", a.item_code " & _
", vpa.description" & _
", vpa.model_no" & _
", vpa.brand_name" & _
", vpa.cat_desc" & _
", vpa.sub_cat_desc" & _
" FROM [dbo].[tbl_item] a" & _
" LEFT JOIN [dbo].[v_part_all] vpa on vpa.part_id = a.part_id" & _
" where a.asset_number = '" & AssetNumber & "'" & _
" and (a.is_deleted is null or a.is_deleted = 0)"

            cmd = New SqlCommand(sql, con)
            Dim dtItemDesc As New DataTable

            Dim adpt As New Data.SqlClient.SqlDataAdapter(cmd)
            adpt.Fill(dtItemDesc)
            If dtItemDesc.Rows.Count = 0 Then
                lblStatus.ForeColor = Color.Red
                lblStatus.Text = "Asset Number not found!"
                strItemCode = ""
                txtPartID.Text = ""
                txtDescription.Text = ""
                txtModel.Text = ""
                txtBrand.Text = ""
                txtCategory.Text = ""
                txtSubCategory.Text = ""
                Return False
            Else
                txtPartID.Text = dtItemDesc.Rows(0).Item("part_id").ToString
                txtDescription.Text = dtItemDesc.Rows(0).Item("description").ToString
                txtModel.Text = dtItemDesc.Rows(0).Item("model_no").ToString
                txtBrand.Text = dtItemDesc.Rows(0).Item("brand_name").ToString
                txtCategory.Text = dtItemDesc.Rows(0).Item("cat_desc").ToString
                txtSubCategory.Text = dtItemDesc.Rows(0).Item("sub_cat_desc").ToString
                strItemCode = dtItemDesc.Rows(0).Item("item_code").ToString
                Return True
            End If
            con.Dispose()
            cmd.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Function loadGroup(ByVal GroupBarcode As String) As Boolean
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim sql As String
        Dim dt As New DataTable
        con.ConnectionString = ConnectServer()
        Try

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            sql = _
"select tgl.item_code" & _
", itm.asset_number" & _
", vpa.part_id" & _
", vpa.description" & _
", vpa.model_no" & _
", vpa.brand_name" & _
", vpa.cat_desc" & _
", vpa.sub_cat_desc" & _
" from tbl_group_hdr tgh" & _
" left join tbl_group_line tgl on tgh.group_id = tgl.group_id" & _
" left join tbl_item itm on tgl.item_code = itm.item_code" & _
" left join v_part_all vpa on vpa.part_id = itm.part_id" & _
" where group_barcode = '" & GroupBarcode & "'"
            cmd = New SqlCommand(sql, con)
            Dim adpt As New Data.SqlClient.SqlDataAdapter(cmd)
            adpt.Fill(dt)
            If dt.Rows.Count = 0 Then
                Return False
            End If

            For ctr As Integer = 0 To dt.Rows.Count - 1
                Dim retval As Integer = -1
                retval = checkOut(dt.Rows(ctr).Item("item_code").ToString)
                txtPartID.Text = dt.Rows(ctr).Item("part_id").ToString
                txtDescription.Text = dt.Rows(ctr).Item("description").ToString
                txtModel.Text = dt.Rows(ctr).Item("model_no").ToString
                txtBrand.Text = dt.Rows(ctr).Item("brand_name").ToString
                txtCategory.Text = dt.Rows(ctr).Item("cat_desc").ToString
                txtSubCategory.Text = dt.Rows(ctr).Item("sub_cat_desc").ToString
                strItemCode = dt.Rows(ctr).Item("item_code").ToString
                Select Case retval
                    Case 0
                        lblStatus.ForeColor = Color.Red
                        lblStatus.Text = "ASSET ALREADY SCANNED!" & vbCrLf & "ASSET NUMBER:" & txtAssetNumber.Text
                        timerAlarm.Enabled = True
                    Case 1
                        lblStatus.ForeColor = Color.Green
                        lblStatus.Text = "CHECK OUT SUCCESFULL!" & vbCrLf & "ASSET NUMBER:" & txtAssetNumber.Text
                        timerAlarm.Enabled = False
                    Case Else
                        lblStatus.ForeColor = Color.Red
                        lblStatus.Text = "CHECK OUT FAILED!" & vbCrLf & "ASSET NUMBER:" & txtAssetNumber.Text
                        timerAlarm.Enabled = True
                End Select
            Next
            Return True
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

    Private Function checkOut(ByVal ItemCode As String) As Integer
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim sql As String = ""
        Try

            con.ConnectionString = ConnectServer()
            con.Open()

            cmd = New SqlCommand
            sql = _
"SELECT COUNT(*)" & _
" FROM [tbl_rental_asset]" & _
" where rental_id = @rental_id and item_code = @item_code"

            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@item_code", ItemCode)
            cmd.Parameters.AddWithValue("@rental_id", lblRentalID.Text)
            If cmd.ExecuteScalar > 0 Then
                Return 0
            End If

            cmd = New SqlCommand
            sql = _
"UPDATE [tbl_rental_asset]" & _
" SET" & _
" [dt_in] = @dt_in" & _
" ,[user_id_in] = @user_id_in" & _
" WHERE  [item_code] = @item_code and [dt_in] is null and not([rental_id] = @rental_id)"

            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@item_code", ItemCode)
            cmd.Parameters.AddWithValue("@dt_in", Date.Now)
            cmd.Parameters.AddWithValue("@user_id_in", user_id)
            cmd.Parameters.AddWithValue("@rental_id", lblRentalID.Text)
            cmd.ExecuteNonQuery()

            cmd = New SqlCommand
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
            cmd.Parameters.AddWithValue("@item_code", ItemCode)
            cmd.Parameters.AddWithValue("@rental_id", lblRentalID.Text)
            cmd.Parameters.AddWithValue("@dt_out", Date.Now)
            cmd.Parameters.AddWithValue("@user_id_out", user_id)
            If cmd.ExecuteNonQuery() > 0 Then
                Return 1
            End If
            Return -1
        Catch ex As Exception
            MsgBox(ex.Message)
            Return -1
        End Try

    End Function

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Try

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
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

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



    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        loadSubAsset()
        If dtSubAssetList.Rows.Count > 0 Then
            loadReport2()
        Else
            loadReport()
        End If
        '
    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBrand.TextChanged

    End Sub

    Private Sub TabPage2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage2.Click

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'loadReport()
    End Sub
    Private Sub loadReport()
        Dim myReport As New ReportDocument
        Dim myData As New DataSet
        Try
            Dim connection As New System.Data.SqlClient.SqlConnection(ConnectServer())
            Dim sql As String
            sql = _
"SELECT [rental_id]" & _
" ,[part_id]" & _
" ,[qty]" & _
" ,[description]" & _
" ,[model_no]" & _
" ,[brand_name]" & _
" ,[cat_desc]" & _
" ,[sub_cat_desc]" & _
" ,[rental_no]" & _
" ,[delivered_to]" & _
" ,[event]" & _
" ,[pick_del_date]" & _
" ,[location]" & _
" ,[event_from]" & _
" ,[event_to]" & _
" ,[prepared_by]" & _
" FROM [v_rental_all]" & _
" where [rental_id] = '" & lblRentalID.Text & "'" & _
" order by cat_desc, sub_cat_desc, description"

            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If
            Dim command As New SqlCommand(sql, connection)

            Dim adpt As New Data.SqlClient.SqlDataAdapter(command)
            command.CommandText = sql
            command.Connection = connection

            adpt.SelectCommand = command
            adpt.Fill(myData)

            If Not Directory.Exists(Path + "\rpt\") Then
                Directory.CreateDirectory(Path + "\rpt\")
            End If

            Dim A As New frm_rpt
            myReport.Load(Path + "\rpt\CheckListV3.rpt")
            myReport.SetDataSource(myData)
            A.myViewer.ReportSource = myReport
            A.Text = "CHECKLIST REPORT"
            A.ShowDialog()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub loadReport2()
        Dim myReport As New ReportDocument
        Dim myData As New DataSet
        Try
            Dim connection As New System.Data.SqlClient.SqlConnection(ConnectServer())
            Dim sql As String
            sql = _
"select b.item_code, b.asset_number, c.description, a.dt_out" & _
" , c.model_no, d.brand_name, f.cat_desc, e.sub_cat_desc" & _
" , g.rental_no, g.delivered_to, g.event, g.pick_del_date" & _
" , g.location, g.event_from, g.event_to, i.user_name" & _
" , h.asset_number as sub_asset_number" & _
" , h.serial_number as sub_serial_number" & _
" , h.description as sub_description" & _
" , h.model_no as sub_model_no" & _
" , h.brand_name as sub_brand_name" & _
" from tbl_rental_asset a" & _
" left join tbl_item b on a.item_code = b.item_code" & _
" left join tbl_part c on b.part_id = c.part_id" & _
" left join tbl_brand d on c.brand_id = d.brand_id " & _
" left join tbl_sub_category e on c.sub_cat_id = e.sub_cat_id" & _
" left join tbl_category f on e.cat_id = f.cat_id" & _
" left join tbl_rental_hdr g on a.rental_id = g.rental_id" & _
" left join v_set_barcode_details h on a.item_code = h.set_item_code" & _
" left join tbl_user i on g.prepared_by = i.user_id" & _
" where a.rental_id = '" & lblRentalID.Text & "'"
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If



            'MsgBox(sql)
            Dim command As New SqlCommand(sql, connection)

            Dim adpt As New Data.SqlClient.SqlDataAdapter(command)
            command.CommandText = sql
            command.Connection = connection

            adpt.SelectCommand = command
            adpt.Fill(myData)
            If Not Directory.Exists(Path + "\rpt\") Then
                Directory.CreateDirectory(Path + "\rpt\")
            End If

            'myData.WriteXml(Path + "\rpt\checklist_set.xml", XmlWriteMode.WriteSchema)
            'dgv_parts.DataSource = myData.Tables(0)
            'dgv_parts.AutoResizeColumns()

            Dim A As New frm_rpt
            myReport.Load(Path + "\rpt\report3_2.rpt")
            myReport.SetDataSource(myData)
            A.myViewer.ReportSource = myReport
            A.Text = "CHECKLIST REPORT"
            A.ShowDialog()



        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub



    Private Sub timerAlarm_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timerAlarm.Tick
        Try
            Dim Sound As New System.Media.SoundPlayer()
            Sound.SoundLocation = Path & "\tututut.wav"
            Sound.Load()
            Sound.Play()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Function ExportExcel(ByVal dgv As DataGridView) As Boolean
        If dgv.RowCount = Nothing Then
            MessageBox.Show("Sorry nothing to export into excel sheet.." & vbCrLf & "Please retrieve data in datagridview", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If
        Dim rowsTotal, colsTotal As Short
        Dim I, j, iC As Short
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Dim xlApp As New Excel.Application

        Try
            Dim excelBook As Excel.Workbook = xlApp.Workbooks.Add
            Dim excelWorksheet As Excel.Worksheet = CType(excelBook.Worksheets(1), Excel.Worksheet)
            xlApp.Visible = True

            rowsTotal = dgv.RowCount - 1
            colsTotal = dgv.Columns.Count - 1
            With excelWorksheet
                .Cells.Select()
                .Cells.Delete()
                For iC = 0 To colsTotal
                    .Cells(1, iC + 1).Value = dgv.Columns(iC).HeaderText
                Next
                For I = 0 To rowsTotal
                    For j = 0 To colsTotal
                        .Cells(I + 2, j + 1).value = dgv.Rows(I).Cells(j).Value
                    Next j
                Next I
                .Rows("1:1").Font.FontStyle = "Bold"
                .Rows("1:1").Font.Size = 12

                .Cells.Columns.AutoFit()
                .Cells.Select()
                .Cells.EntireColumn.AutoFit()
                .Cells(1, 1).Select()
            End With
            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            'RELEASE ALLOACTED RESOURCES
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            xlApp = Nothing
        End Try
    End Function

    Private Sub Button5_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        ExportExcel(dgvAssetList)
    End Sub


    Private Sub btnConnect_Click(sender As System.Object, e As System.EventArgs) Handles btnConnect.Click
        Try


            If btnConnect.Text = "CONNECT" Then

                Settings.Set("com_name", cboPort.Text)
                Settings.Update()
                SerialPort1.PortName = Settings.Get("com_name")
                SerialPort1.BaudRate = Settings.Get("com_baud")
                SerialPort1.Parity = IO.Ports.Parity.None
                SerialPort1.StopBits = IO.Ports.StopBits.One
                SerialPort1.DataBits = Convert.ToInt32(Settings.Get("com_databits"))
                If SerialPort1.IsOpen Then
                    SerialPort1.Close()
                End If
                SerialPort1.Open()
                btnConnect.Text = "DISCONNECT"

            Else
                If SerialPort1.IsOpen Then
                    SerialPort1.Close()
                End If
                btnConnect.Text = "CONNECT"

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub SerialPort1_DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived
        ReceivedText(SerialPort1.ReadExisting())
    End Sub

    Private Sub ReceivedText(ByVal [text] As String)
        Try
            If txtAssetNumber.InvokeRequired Then
                Dim x As New SetTextCallback(AddressOf ReceivedText)
                Invoke(x, New Object() {(text)})
            Else
                txtAssetNumber.Text = Trim(text.Replace(vbCr, "").Replace(vbLf, "").Replace(vbCrLf, ""))
                'check_out_asset(txtAssetNumber.Text, Integer.Parse(lblRentalID.Text), user_id)
                If check_out_asset(txtAssetNumber.Text, Integer.Parse(lblRentalID.Text), user_id) Then
                    lblStatus.ForeColor = Color.Green
                    timerAlarm.Enabled = False
                Else
                    lblStatus.ForeColor = Color.Red
                    timerAlarm.Enabled = True
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub txtAssetNumber_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtAssetNumber.TextChanged

    End Sub
End Class