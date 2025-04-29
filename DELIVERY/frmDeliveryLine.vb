Imports System.Data.SqlClient
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine

Public Class frmDeliveryLine
    Dim strDeliveryID As String
    Private Sub frm_create_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadRentalHDR()
        loadRentalLine()
        'cbo_print.Items.Add("1D")
        'cbo_print.Items.Add("2D")
        'load_cbo_part()
    End Sub
    '    Private Sub load_cbo_part()
    '        Try
    '            Dim connection As New System.Data.SqlClient.SqlConnection(ConnectServer())
    '            Dim sql As String
    '            sql = _
    '"select b.part_id, b.part_number, b.description, e.brand_name, b.model_no, d.cat_desc, c.sub_cat_desc from tbl_part b" & _
    '" left join tbl_sub_category c on b.sub_cat_id = c.sub_cat_id" & _
    '" left join tbl_category d on c.cat_id = d.cat_id" & _
    '" left join tbl_brand e on b.brand_id = e.brand_id"
    '            '"SELECT [part_number]" & _
    '            '" ,[description]" & _
    '            '" FROM [tbl_part]"
    '            Dim command As New System.Data.SqlClient.SqlCommand(sql, connection)

    '            Dim adpt As New Data.SqlClient.SqlDataAdapter(command)
    '            If connection.State = ConnectionState.Closed Then
    '                connection.Open()
    '            End If
    '            adpt.Fill(dt_part)
    '            cbo_part.DataSource = Nothing
    '            cbo_part.DataSource = dt_part
    '            cbo_part.DisplayMember = "description"
    '            cbo_part.ValueMember = "part_id"
    '            'cbo_part.SelectedIndex = -1
    '        Catch ex As SqlException
    '            MessageBox.Show("An error occurred while loading data !" & vbCrLf & ex.ToString())
    '        Finally

    '        End Try

    '    End Sub

    Private Sub create()
        Dim str_where As List(Of String) = New List(Of String)
        'str_where.Add("description like '%" & txt_description.Text & "%'")
    End Sub
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
"SELECT [dr_id]" & _
" ,[dr_no]" & _
" ,[delivery_to]" & _
" ,[address]" & _
" ,[date]" & _
" ,[prepared_by]" & _
" FROM tbl_delivery_hdr" & _
" where [dr_no] = '" & txtDR_No.Text & "'"

            cmd = New SqlCommand(sql, con)
            Dim dtRentalHdr As New DataTable

            Dim adpt As New Data.SqlClient.SqlDataAdapter(cmd)
            adpt.Fill(dtRentalHdr)
            If dtRentalHdr.Rows.Count = 0 Then
                MsgBox("Cannot find Delivery No!")
                Return False
            Else
                strDeliveryID = dtRentalHdr.Rows(0).Item("DR_ID").ToString
                txtDR_No.Text = dtRentalHdr.Rows(0).Item("DR_NO").ToString
                txtDeliveryto.Text = dtRentalHdr.Rows(0).Item("DELIVERY_TO").ToString
                txtPreparedBy.Text = dtRentalHdr.Rows(0).Item("PREPARED_BY").ToString
                txtAddress.Text = dtRentalHdr.Rows(0).Item("ADDRESS").ToString
                txtDate.Text = dtRentalHdr.Rows(0).Item("DATE").ToString
            End If
            con.Dispose()
            cmd.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function


    Private Function RentalLineCheckExistInsert() As Boolean
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim sql As String = ""
        con.ConnectionString = ConnectServer()
        Try

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            sql = _
"select count(*) from tbl_delivery_line where dr_id = @dr_id and part_id = @part_id"
            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@dr_id", strDeliveryID)
            cmd.Parameters.AddWithValue("@part_id", txt_part_id.Text)
            If cmd.ExecuteScalar = 0 Then
                sql = _
"INSERT INTO [tbl_delivery_line]" & _
"([dr_id]" & _
",[part_id]" & _
",[qty]" & _
",[unit_price], [unit])" & _
" VALUES" & _
"(@dr_id" & _
",@part_id" & _
",@qty" & _
",@unit_price, @unit)"
                cmd = New SqlCommand(sql, con)
                cmd.Parameters.AddWithValue("@dr_id", strDeliveryID)
                cmd.Parameters.AddWithValue("@part_id", txt_part_id.Text)
                cmd.Parameters.AddWithValue("@qty", NumericUpDown1.Value)
                cmd.Parameters.AddWithValue("@unit_price", Convert.ToDecimal(txtRemarks.Text))
                cmd.Parameters.AddWithValue("@unit", txtUnit.Text)
                If cmd.ExecuteNonQuery() > 0 Then
                    MsgBox("item succesfully added!")
                    Return True
                Else
                    MsgBox("item failed to add!")
                    Return False
                End If
            Else
                MsgBox("Item already exist in the list!")
                Return False
            End If
            con.Dispose()
            cmd.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function

    Private Function deleteLine() As Boolean
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim sql As String = ""
        con.ConnectionString = ConnectServer()
        Try

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            sql = _
"DELETE FROM [tbl_delivery_line] WHERE [dr_id] = @dr_id AND part_id = @part_id"
            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@dr_id", strDeliveryID)
            cmd.Parameters.AddWithValue("@part_id", (dgvRentalLine.Item("part_id", dgvRentalLine.CurrentRow.Index).Value()))
            If cmd.ExecuteNonQuery = 0 Then
                Return False
            Else
                Return True
            End If

            con.Dispose()
            cmd.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function

    Private Sub loadRentalLine()
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim sql As String
        con.ConnectionString = ConnectServer()
        Try

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            sql = _
"SELECT [qty], [unit]" & _
", b.description" & _
",[unit_price]" & _
", a.[qty] * [unit_price] as amount" & _
" FROM [tbl_delivery_line] a" & _
" left join tbl_part b on a.part_id = b.part_id" & _
" where a.dr_id = '" & strDeliveryID & "'"
            cmd = New SqlCommand(sql, con)
            Dim dtRentalLine As New DataTable

            Dim adpt As New Data.SqlClient.SqlDataAdapter(cmd)
            adpt.Fill(dtRentalLine)
            dgvRentalLine.DataSource = dtRentalLine

            con.Dispose()
            cmd.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub


    'Private Sub btn_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    update_cmd()
    '    If cbo_print.SelectedIndex >= 0 Then

    '        Dim p As New Process
    '        p.StartInfo.UseShellExecute = True
    '        p.StartInfo.WorkingDirectory = Path
    '        p.StartInfo.Arguments = Path & "\bt\" & cbo_print.Text & ".btw" + " /P/X"
    '        p.StartInfo.FileName = Path + "\bt\BarTend.exe"
    '        p.Start()
    '    Else
    '        MsgBox("Select format!")
    '    End If


    '    Button1.Enabled = True
    'End Sub
    'Private Sub txt_create()
    '    Dim TW As System.IO.TextWriter


    '    'Write data to text file
    '    'With 2 field separated with (/)forward slash; field1 is top label field, field2 is bottom label field

    '    'text file sample
    '    'L60-11A-3205 / -05172011-26
    '    'L60-11A-3205 / -05172011-27
    '    'L60-11A-3205 / -05172011-28
    '    'L60-11A-3205 / -05172011-29
    '    'L60-11A-3205 / -05172011-30

    '    TW = System.IO.File.CreateText(PDir + "print.txt")

    '    For d = beginctr To endctr(4)
    '        TW.WriteLine(endctr(0) + "-" + endctr(1) + "-" + endctr(2) + "/" + "-" + endctr(3) + "-" + d.ToString)
    '    Next d
    '    TW.Flush()
    '    TW.Close()


    '    'Call Bartend.exe and print

    '    'label sample
    '    'HOCHENG PHILIPPINES INC.
    '    'L60-11A-3205(field1)     2D BARCODE HERE(Field1 + Field2)
    '    '-05172011-30(field2)

    '    'Call bartend and print
    '    Dim p As New Process
    '    p.StartInfo.UseShellExecute = True
    '    p.StartInfo.WorkingDirectory = PDir
    '    p.StartInfo.Arguments = "hcg.btw" + " /P/X"
    '    p.StartInfo.FileName = PDir + "BarTend.exe"
    '    p.Start()
    '    End If
    'End Sub

    'Private Sub delete_cmd()
    '    Dim str_item_code As List(Of String) = New List(Of String)
    '    Dim str_item_code_where As String = ""
    '    Dim con As New SqlConnection
    '    Dim cmd As New SqlCommand
    '    Dim sql As String = "DELETE FROM [tbl_item]"
    '    con.ConnectionString = ConnectServer()
    '    Try
    '        If con.State = ConnectionState.Closed Then
    '            con.Open()
    '        End If

    '        For ctr As Integer = 0 To dgv_created.Rows.Count - 1
    '            str_item_code.Add(dgv_created.Item("item_code", ctr).Value)
    '        Next

    '        For Each val As String In str_item_code
    '            If str_item_code_where = "" Then
    '                str_item_code_where = "item_code = " & val
    '            Else
    '                str_item_code_where = str_item_code_where & " or item_code = " & val
    '            End If
    '        Next

    '        If str_item_code_where <> "" Then
    '            sql = sql & " where " & str_item_code_where
    '        Else

    '        End If
    '        MsgBox(sql)
    '        cmd = New SqlCommand(sql, con)
    '        Dim cmd_int As Integer
    '        cmd_int = cmd.ExecuteNonQuery
    '        MsgBox("DELETED:" & cmd_int.ToString)
    '        dgv_created.DataSource = Nothing

    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub

    'Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If dgv_created.Rows.Count > 0 Then
    '        delete_cmd()
    '        Button1.Enabled = True
    '    Else
    '        MsgBox("No item to delete!")
    '    End If
    'End Sub

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

    'Private Sub cbo_part_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    '       "select b.part_number, b.description, e.brand_name, b.model_no, d.cat_desc, c.sub_cat_desc from tbl_part b" & _
    '    If cbo_part.SelectedIndex >= 0 Then
    '        'txt_part_number.Text = dt_part(cbo_part.SelectedIndex).Item("part_number").ToString
    '        'txt_description.Text = dt_part(cbo_part.SelectedIndex).Item("description").ToString
    '        'txt_brand.Text = dt_part(cbo_part.SelectedIndex).Item("brand_name").ToString
    '        'txt_model.Text = dt_part(cbo_part.SelectedIndex).Item("model_no").ToString
    '        'txt_category.Text = dt_part(cbo_part.SelectedIndex).Item("cat_desc").ToString
    '        'txt_sub_category.Text = dt_part(cbo_part.SelectedIndex).Item("sub_cat_desc").ToString
    '    Else
    '        txt_part_number.Text = ""
    '        txt_description.Text = ""
    '        txt_brand.Text = ""
    '        txt_model.Text = ""
    '        txt_category.Text = ""
    '        txt_sub_category.Text = ""
    '    End If
    'End Sub

    'Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    update_cmd()
    '    'Dim p As New Process
    '    'p.StartInfo.UseShellExecute = True
    '    'p.StartInfo.WorkingDirectory = Path
    '    'p.StartInfo.Arguments = Path & "\bt\print.btw" + " /P/X"
    '    'p.StartInfo.FileName = Path + "\bt\BarTend.exe"
    '    'p.Start()
    '    Button1.Enabled = True
    'End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If txt_part_id.Text <> "" And txtRemarks.Text <> "" And txtUnit.Text <> "" Then
            If RentalLineCheckExistInsert() Then
                loadRentalLine()
            End If
        Else
            MsgBox("Please Complete all the needed data!")
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If dgvRentalLine.CurrentRow.Index > -1 Then
            If deleteLine() Then
                loadRentalLine()
            End If
            '(dgvRentalLine.Item("part_id", dgvRentalLine.CurrentRow.Index).Value())
        End If
    End Sub


    'Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
    '    loadAll()
    'End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        loadReport()
    End Sub
    Private Sub loadReport()
        'Dim mySql As String
        Dim myReport As New ReportDocument
        Dim myData As New DataSet

        'mySql = "SELECT item_code, item_desc, uom, barcode FROM tbl_items"
        Try
            Dim connection As New System.Data.SqlClient.SqlConnection(ConnectServer())
            Dim sql As String
            sql = _
"SELECT [qty], [unit]" & _
", b.description" & _
",[unit_price]" & _
", a.[qty] * [unit_price] as amount" & _
", c.dr_no" & _
", c.delivery_to" & _
", c.address" & _
", c.date" & _
", d.user_name" & _
" FROM [hxpro_db].[dbo].[tbl_delivery_line] a" & _
" left join tbl_part b on a.part_id = b.part_id" & _
" left join tbl_delivery_hdr c on a.dr_id = c.dr_id" & _
" left join tbl_user d on c.prepared_by = d.user_id" & _
" where a.dr_id = '" & strDeliveryID & "'"
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
            ' myData.WriteXml(Path + "\rpt\Delivery.xml", XmlWriteMode.WriteSchema)
            'dgv_parts.DataSource = myData.Tables(0)
            'dgv_parts.AutoResizeColumns()

            Dim A As New frm_rpt
            myReport.Load(Path + "\rpt\rptDelivery.rpt")
            myReport.SetDataSource(myData)
            A.myViewer.ReportSource = myReport
            A.Text = "DELIVERY SLIP"
            A.ShowDialog()



        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtDeliverTo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDeliveryto.TextChanged

    End Sub

    Private Sub Button4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        loadReport()
    End Sub

    Private Sub dgvRentalLine_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRentalLine.CellContentClick

    End Sub

    Private Sub txt_part_id_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_part_id.TextChanged

    End Sub

    Private Sub Label9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label9.Click

    End Sub

    Private Sub txt_sub_category_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_sub_category.TextChanged

    End Sub

    Private Sub txt_category_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_category.TextChanged

    End Sub

    Private Sub txt_brand_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_brand.TextChanged

    End Sub

    Private Sub txt_part_number_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_part_number.TextChanged

    End Sub

    Private Sub Label8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label8.Click

    End Sub

    Private Sub NumericUpDown1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericUpDown1.ValueChanged

    End Sub

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click

    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click

    End Sub

    Private Sub txt_model_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_model.TextChanged

    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click

    End Sub

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click

    End Sub

    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click

    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click

    End Sub

    Private Sub txt_description_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_description.TextChanged

    End Sub

    Private Sub Label11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label11.Click

    End Sub

    Private Sub txtRemarks_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRemarks.KeyPress
        Dim decexist As Boolean = False
        If (CType(sender, TextBox).Text.IndexOf(".") > 0) And e.KeyChar.Equals("."c) Then
            decexist = True
        End If
        If (e.KeyChar = "-") Then
            If (CType(sender, TextBox).Text.StartsWith("-") = True) Then
                e.Handled = True
                Exit Sub
            Else
                e.Handled = True
                CType(sender, TextBox).Text = "-" & CType(sender, TextBox).Text
                CType(sender, TextBox).SelectionStart = CType(sender, TextBox).Text.Length
                Exit Sub
            End If
        End If
        If (Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) And Not (e.KeyChar.Equals("."c))) Or decexist Then
            e.Handled = True
        End If

    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRemarks.TextChanged

    End Sub

    Private Sub Label15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label15.Click

    End Sub
End Class