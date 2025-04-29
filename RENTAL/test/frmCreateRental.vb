'Imports System.Data
Imports System.Data.SqlClient
'Imports System.Xml
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine

Public Class frmCreateRental
    Dim strRentalID As String
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
"SELECT [rental_id]" & _
" ,[rental_no]" & _
" ,[delivered_to]" & _
" ,[event]" & _
" ,[pick_del_date]" & _
" ,[location]" & _
" ,[event_from]" & _
" ,[event_to]" & _
" ,[prepared_by]" & _
"  FROM [dbo].[tbl_rental_hdr] where rental_no = '" & txtRentalNO.Text & "'"

            cmd = New SqlCommand(sql, con)
            Dim dtRentalHdr As New DataTable

            Dim adpt As New Data.SqlClient.SqlDataAdapter(cmd)
            adpt.Fill(dtRentalHdr)
            If dtRentalHdr.Rows.Count = 0 Then
                MsgBox("Cannot find rental No!")
                Return False
            Else
                strRentalID = dtRentalHdr.Rows(0).Item("rental_id").ToString
                txtRentalNO.Text = dtRentalHdr.Rows(0).Item("rental_no").ToString
                txtDeliverTo.Text = dtRentalHdr.Rows(0).Item("delivered_to").ToString
                txtEvent.Text = dtRentalHdr.Rows(0).Item("event").ToString
                dtPickDelDate.Value = dtRentalHdr.Rows(0).Item("pick_del_date")
                dtEventFrom.Value = dtRentalHdr.Rows(0).Item("event_from")
                dtEventTo.Value = dtRentalHdr.Rows(0).Item("event_to")
                txtPreparedBy.Text = dtRentalHdr.Rows(0).Item("prepared_by").ToString
                txtLocation.Text = dtRentalHdr.Rows(0).Item("location").ToString
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
"select count(*) from tbl_rental_line where rental_id = @rental_id and part_id = @part_id"
            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@rental_id", strRentalID)
            cmd.Parameters.AddWithValue("@part_id", txt_part_id.Text)
            If cmd.ExecuteScalar = 0 Then
                sql = _
"INSERT INTO [tbl_rental_line]" & _
" ([rental_id]" & _
" ,[part_id]" & _
" ,[qty])" & _
" VALUES (" & _
" @rental_id" & _
" ,@part_id" & _
" ,@qty)"
                cmd = New SqlCommand(sql, con)
                cmd.Parameters.AddWithValue("@rental_id", strRentalID)
                cmd.Parameters.AddWithValue("@part_id", txt_part_id.Text)
                cmd.Parameters.AddWithValue("@qty", NumericUpDown1.Value)
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
"DELETE FROM [tbl_rental_line] WHERE rental_id = @rental_id AND part_id = @part_id"
            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@rental_id", strRentalID)
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
"select a.part_id, b.part_number, b.description, a.qty from tbl_rental_line a" & _
" left join tbl_part b on a.part_id = b.part_id" & _
" where a.rental_id = '" & strRentalID & "'"
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
        Dim a As New frm_part
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
        If RentalLineCheckExistInsert() Then
            loadRentalLine()
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

    Private Function loadAll() As Boolean
        Dim myReport As New ReportDocument
        Dim connection As New SqlConnection
        Dim cmd As New SqlCommand
        Dim myData As New DataSet
        Dim sql As String
        connection.ConnectionString = ConnectServer()
        Try

            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If
            sql = _
"select a.part_id, b.part_number, b.description," & _
" f.brand_name, b.model_no," & _
" e.[cat_desc], d.sub_cat_desc," & _
" a.qty," & _
" c.[rental_id], c.[rental_no], c.[delivered_to], c.[event]," & _
" c.[pick_del_date], c.[location], c.[event_from], c.[event_to], c.[prepared_by]" & _
" from tbl_rental_line a" & _
" left join tbl_part b on a.part_id = b.part_id" & _
" left join tbl_brand f on b.brand_id = f.brand_id" & _
" left join tbl_sub_category d on b.sub_cat_id = d.sub_cat_id" & _
" left join tbl_category e on d.cat_id = e.cat_id" & _
" left join tbl_rental_hdr c on a.rental_id = c.rental_id" & _
" where a.rental_id = '" & strRentalID & "'"

            cmd.CommandText = sql
            '"select * from vw_dispatch"
            cmd.Connection = connection

            'Dim adpt As New Data.SqlClient.SqlDataAdapter(cmd)

            ''adpt.SelectCommand = cmd
            'adpt.Fill(myData)
            'If Not Directory.Exists(Path + "\rpt\") Then
            '    Directory.CreateDirectory(Path + "\rpt\")
            'End If
            ''myData.WriteXml(Path + "\rpt\rental_hdr.xml", XmlWriteMode.WriteSchema)
            ''dgv_parts.DataSource = myData.Tables(0)
            ''dgv_parts.AutoResizeColumns()

            'Dim A As New frm_rpt
            'myReport.Load(Path + "\rpt\report2.rpt")
            'myReport.SetDataSource(myData)
            'A.myViewer.ReportSource = myReport
            'A.Text = "RENTAL"
            'A.ShowDialog()




            Dim command As New SqlCommand '(sql, connection)

            Dim adpt As New Data.SqlClient.SqlDataAdapter '(command)
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
            myData.WriteXml(Path + "\rpt\rental_hdr.xml", XmlWriteMode.WriteSchema)
            'dgv_parts.DataSource = myData.Tables(0)
            'dgv_parts.AutoResizeColumns()

            Dim A As New frm_rpt
            myReport.Load(Path + "\rpt\report2.rpt")
            myReport.SetDataSource(myData)
            A.myViewer.ReportSource = myReport
            A.Text = "RECEIVE REPORT"
            A.ShowDialog()






            connection.Dispose()
            cmd.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

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
"SELECT b.rental_no, b.delivered_to, b.event, b.location," & _
" b.pick_del_date, b.event_from, b.event_to," & _
" A.qty, f.brand_name, c.model_no, c.description" & _
" FROM [hxpro_db].[dbo].[tbl_rental_line] a" & _
" left join [hxpro_db].[dbo].tbl_rental_hdr b on a.rental_id = b.rental_id" & _
" left join [hxpro_db].[dbo].tbl_part c on a.part_id = c.part_id" & _
" left join [hxpro_db].[dbo].tbl_brand f on c.brand_id = f.brand_id" & _
" where a.rental_id = '" & strRentalID & "'"
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
            'If Not Directory.Exists(Path + "\rpt\") Then
            ' Directory.CreateDirectory(Path + "\rpt\")
            'End If
            'myData.WriteXml(Path + "\rpt\Rental2.xml", XmlWriteMode.WriteSchema)
            'dgv_parts.DataSource = myData.Tables(0)
            'dgv_parts.AutoResizeColumns()

            Dim A As New frm_rpt
            myReport.Load(Path + "\rpt\RentalSlip2.rpt")
            myReport.SetDataSource(myData)
            A.myViewer.ReportSource = myReport
            A.Text = "RENTAL SLIP"
            A.ShowDialog()



        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtDeliverTo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDeliverTo.TextChanged

    End Sub

    Private Sub Button4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        loadReport()
    End Sub
End Class