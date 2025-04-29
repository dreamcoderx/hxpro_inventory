'Imports System.Data
Imports System.Data.SqlClient
'Imports System.Xml
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine

Public Class frmReturnSlipLine
    Dim strReturnSlipID As String
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
"SELECT [rs_id]" & _
" ,[rs_no]" & _
" ,[returned_to]" & _
" ,[date]" & _
" ,b.[user_name]" & _
" FROM [tbl_return_slip_hdr] a" & _
" left join tbl_user b on a.prepared_by = b.user_id" & _
" where [rs_no] = '" & txtReturnSlipNo.Text & "'"

            cmd = New SqlCommand(sql, con)
            Dim dtRentalHdr As New DataTable

            Dim adpt As New Data.SqlClient.SqlDataAdapter(cmd)
            adpt.Fill(dtRentalHdr)
            If dtRentalHdr.Rows.Count = 0 Then
                MsgBox("Cannot find Return Slip No!")
                Return False
            Else
                strReturnSlipID = dtRentalHdr.Rows(0).Item("RS_ID").ToString
                txtReturnSlipNo.Text = dtRentalHdr.Rows(0).Item("RS_NO").ToString
                txtReturnedTo.Text = dtRentalHdr.Rows(0).Item("RETURNED_TO").ToString
                txtPreparedBy.Text = dtRentalHdr.Rows(0).Item("USER_NAME").ToString
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
"select count(*) from tbl_return_slip_line where rs_id = @rs_id and part_id = @part_id"
            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@rs_id", strReturnSlipID)
            cmd.Parameters.AddWithValue("@part_id", txt_part_id.Text)
            If cmd.ExecuteScalar = 0 Then
                sql = _
"INSERT INTO [tbl_return_slip_line]" & _
"([rs_id]" & _
", [part_id]" & _
", [qty], [remarks])" & _
"VALUES" & _
"(@rs_id" & _
", @part_id" & _
", @qty, @remarks)"
                cmd = New SqlCommand(sql, con)
                cmd.Parameters.AddWithValue("@rs_id", strReturnSlipID)
                cmd.Parameters.AddWithValue("@part_id", txt_part_id.Text)
                cmd.Parameters.AddWithValue("@qty", NumericUpDown1.Value)
                cmd.Parameters.AddWithValue("@remarks", txtRemarks.Text)
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
"DELETE FROM [tbl_return_slip_line] WHERE [rs_id] = @rs_id AND part_id = @part_id"
            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@rs_id", strReturnSlipID)
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
"SELECT a.[qty]" & _
" , a.part_id, c.brand_name" & _
" , b.model_no" & _
" , b.description" & _
" , a.[remarks]" & _
" FROM [tbl_return_slip_line] a" & _
" left join [tbl_part] b on a.part_id = b.part_id" & _
" left join [tbl_brand] c on b.brand_id = c.brand_id" & _
" where a.[rs_id] = '" & strReturnSlipID & "'"
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
        If txt_part_id.Text <> "" Then
            If RentalLineCheckExistInsert() Then
                loadRentalLine()
            End If
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
"SELECT a.[qty]" & _
" , c.brand_name" & _
" , b.model_no" & _
" , b.description" & _
" , a.[remarks]" & _
" , d.[rs_no]" & _
" , d.[returned_to]" & _
" , d.date" & _
", e.user_name" & _
" FROM [tbl_return_slip_line] a" & _
" left join [tbl_part] b on a.part_id = b.part_id" & _
" left join [tbl_brand] c on b.brand_id = c.brand_id" & _
" left join [tbl_return_slip_hdr] d on a.rs_id = d.rs_id" & _
" left join tbl_user e on d.prepared_by = e.user_id" & _
" where a.[rs_id] = '" & strReturnSlipID & "'"
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
            'myData.WriteXml(Path + "\rpt\ReturnSlip1.xml", XmlWriteMode.WriteSchema)
            'dgv_parts.DataSource = myData.Tables(0)
            'dgv_parts.AutoResizeColumns()

            Dim A As New frm_rpt
            myReport.Load(Path + "\rpt\rptReturnSlip.rpt")
            myReport.SetDataSource(myData)
            A.myViewer.ReportSource = myReport
            A.Text = "RETURN SLIP"
            A.ShowDialog()



        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtDeliverTo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtReturnedTo.TextChanged

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

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRemarks.TextChanged

    End Sub
End Class