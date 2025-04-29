Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO
Public Class frm_item_list
    Dim dt As New DataTable
    Dim dt_brand As New DataTable
    Private Sub LoadGrid()
        'Dim mySql As String
        Dim str_where As List(Of String) = New List(Of String)
        Dim str_where_con As String = ""
        'mySql = "SELECT item_code, item_desc, uom, barcode FROM tbl_items"
        Try
            Dim connection As New System.Data.SqlClient.SqlConnection(ConnectServer())
            Dim sql As String
            sql = _
"select a.item_code, a.asset_number, a.serial_number, b.part_id, b.description, b.model_no, c.brand_name, e.cat_desc, d.sub_cat_desc  from tbl_item a" & _
" left join tbl_part b on a.part_id  = b.part_id " & _
" left join tbl_brand c on b.brand_id = c.brand_id" & _
" left join tbl_sub_category d on b.sub_cat_id = d.sub_cat_id" & _
" left join tbl_category e on d.cat_id = e.cat_id"
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If

            If txt_num_from.Text <> String.Empty And txt_num_to.Text <> String.Empty Then
                str_where.Add("a.item_code between '" & txt_num_from.Text & "' AND '" & txt_num_to.Text & "'")
            End If

            If txt_asset_number.Text <> "" Then
                str_where.Add("a.asset_number like '%" & txt_asset_number.Text & "%'")
            End If

            If txt_serial_number.Text <> "" Then
                str_where.Add("a.serial_number like '%" & txt_serial_number.Text & "%'")
            End If


            If cbo_part.Text <> "" Then
                str_where.Add("b.description like '%" & cbo_part.Text & "%'")
            End If

            If cbo_brand.SelectedIndex >= 0 Then
                str_where.Add("c.brand_id = '" & cbo_brand.SelectedValue & "'")
            End If

            If cbo_category.Text <> "" Then
                str_where.Add("e.cat_desc like '%" & cbo_category.Text & "%'")
            End If

            If cbo_sub_category.Text <> "" Then
                str_where.Add("d.sub_cat_desc like '%" & cbo_sub_category.Text & "%'")
            End If


            For Each val As String In str_where
                If str_where_con = "" Then
                    str_where_con = val
                Else
                    str_where_con = str_where_con & " and " & val
                End If
            Next

            If str_where_con <> "" Then
                sql = sql & " WHERE " & str_where_con
            End If

            sql = sql & _
            " order by a.asset_number"


            'MsgBox(sql)
            Dim command As New System.Data.SqlClient.SqlCommand(sql, connection)

            Dim adpt As New Data.SqlClient.SqlDataAdapter(command)
            dt.Clear()
            adpt.Fill(dt)
            dgv_parts.DataSource = Nothing

            Dim checkCol As DataGridViewCheckBoxColumn = New DataGridViewCheckBoxColumn()
            checkCol.HeaderText = "select"
            dgv_parts.Columns.Clear()
            dgv_parts.DataSource = Nothing
            dgv_parts.Columns.Add(checkCol)
            dgv_parts.Columns(0).Width = 50
            'dgv_parts.DataSource = dt








            dgv_parts.DataSource = dt
            'GridControl1.DataSource = dt


            dgv_parts.Columns(0).ReadOnly = False
            dgv_parts.Columns(1).ReadOnly = True
            dgv_parts.Columns(2).ReadOnly = True
            dgv_parts.Columns(3).ReadOnly = True
            dgv_parts.Columns(4).ReadOnly = True
            dgv_parts.Columns(5).ReadOnly = True
            dgv_parts.Columns(6).ReadOnly = True
            dgv_parts.Columns(7).ReadOnly = True
            dgv_parts.Columns(8).ReadOnly = True
            dgv_parts.Columns(9).ReadOnly = True

            dgv_parts.Columns(0).HeaderText = "SELECT"
            dgv_parts.Columns(1).HeaderText = "ITEM NUMBER"
            dgv_parts.Columns(2).HeaderText = "ASSET NUMBER"
            dgv_parts.Columns(3).HeaderText = "SERIAL NUMBER"
            dgv_parts.Columns(4).HeaderText = "PART ID"
            dgv_parts.Columns(5).HeaderText = "DESCRIPTION"
            dgv_parts.Columns(6).HeaderText = "MODEL"
            dgv_parts.Columns(7).HeaderText = "BRAND NAME"
            dgv_parts.Columns(8).HeaderText = "CATEGORY"
            dgv_parts.Columns(9).HeaderText = "SUB CATEGORY"
            dgv_parts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            dgv_parts.AutoResizeColumns()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub LoadGrid2()
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
"select a.item_code, a.asset_number, a.serial_number, b.part_id, b.description, b.model_no, c.brand_name, e.cat_desc, d.sub_cat_desc  from tbl_item a" & _
" left join tbl_part b on a.part_id  = b.part_id " & _
" left join tbl_brand c on b.brand_id = c.brand_id" & _
" left join tbl_sub_category d on b.sub_cat_id = d.sub_cat_id" & _
" left join tbl_category e on d.cat_id = e.cat_id"
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If

            If txt_num_from.Text <> String.Empty And txt_num_to.Text <> String.Empty Then
                str_where.Add("a.item_code between '" & txt_num_from.Text & "' AND '" & txt_num_to.Text & "'")
            End If

            If txt_asset_number.Text <> "" Then
                str_where.Add("a.asset_number like '%" & txt_asset_number.Text & "%'")
            End If

            If txt_serial_number.Text <> "" Then
                str_where.Add("a.serial_number like '%" & txt_serial_number.Text & "%'")
            End If


            If cbo_part.Text <> "" Then
                str_where.Add("b.description like '%" & cbo_part.Text & "%'")
            End If

            If cbo_brand.SelectedIndex >= 0 Then
                str_where.Add("c.brand_id = '" & cbo_brand.SelectedValue & "'")
            End If

            If cbo_category.Text <> "" Then
                str_where.Add("e.cat_desc like '%" & cbo_category.Text & "%'")
            End If

            If cbo_sub_category.Text <> "" Then
                str_where.Add("d.sub_cat_desc like '%" & cbo_sub_category.Text & "%'")
            End If


            For Each val As String In str_where
                If str_where_con = "" Then
                    str_where_con = val
                Else
                    str_where_con = str_where_con & " and " & val
                End If
            Next

            If str_where_con <> "" Then
                sql = sql & " WHERE " & str_where_con
            End If

            sql = sql & _
            " order by a.asset_number"


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
            'myData.WriteXml(Path + "\rpt\receive.xml", XmlWriteMode.WriteSchema)
            'dgv_parts.DataSource = myData.Tables(0)
            'dgv_parts.AutoResizeColumns()

            Dim A As New frm_rpt
            myReport.Load(Path + "\rpt\rpt1.rpt")
            myReport.SetDataSource(myData)
            A.myViewer.ReportSource = myReport
            A.Text = "RECEIVE REPORT"
            A.ShowDialog()


            Dim checkCol As DataGridViewCheckBoxColumn = New DataGridViewCheckBoxColumn()
            checkCol.HeaderText = "select"
            dgv_parts.Columns.Clear()
            dgv_parts.DataSource = Nothing
            dgv_parts.Columns.Add(checkCol)
            dgv_parts.Columns(0).Width = 50
            'dgv_parts.DataSource = dt


            dgv_parts.DataSource = myData.Tables(0)
            'GridControl1.DataSource = dt


            dgv_parts.Columns(0).ReadOnly = False
            dgv_parts.Columns(1).ReadOnly = True
            dgv_parts.Columns(2).ReadOnly = True
            dgv_parts.Columns(3).ReadOnly = True
            dgv_parts.Columns(4).ReadOnly = True
            dgv_parts.Columns(5).ReadOnly = True
            dgv_parts.Columns(6).ReadOnly = True
            dgv_parts.Columns(7).ReadOnly = True
            dgv_parts.Columns(8).ReadOnly = True
            dgv_parts.Columns(9).ReadOnly = True

            dgv_parts.Columns(0).HeaderText = "SELECT"
            dgv_parts.Columns(1).HeaderText = "ITEM NUMBER"
            dgv_parts.Columns(2).HeaderText = "ASSET NUMBER"
            dgv_parts.Columns(3).HeaderText = "SERIAL NUMBER"
            dgv_parts.Columns(4).HeaderText = "PART ID"
            dgv_parts.Columns(5).HeaderText = "DESCRIPTION"
            dgv_parts.Columns(6).HeaderText = "MODEL"
            dgv_parts.Columns(7).HeaderText = "BRAND NAME"
            dgv_parts.Columns(8).HeaderText = "CATEGORY"
            dgv_parts.Columns(9).HeaderText = "SUB CATEGORY"
            dgv_parts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            dgv_parts.AutoResizeColumns()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub load_cbo_brand()
        Try
            Dim connection As New System.Data.SqlClient.SqlConnection(ConnectServer())
            Dim sql As String
            sql = _
            "SELECT [brand_id]" & _
            ", [brand_name]" & _
            " FROM [tbl_brand]" & _
            " order by [brand_name]"
            Dim command As New System.Data.SqlClient.SqlCommand(sql, connection)
            Dim dt_brand As New DataTable
            Dim adpt As New Data.SqlClient.SqlDataAdapter(command)
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If
            adpt.Fill(dt_brand)
            cbo_brand.DataSource = dt_brand
            cbo_brand.DisplayMember = "brand_name"
            cbo_brand.ValueMember = "brand_id"
            cbo_brand.SelectedIndex = -1
        Catch ex As SqlException
            MessageBox.Show("An error occurred while loading data !" & vbCrLf & ex.ToString())
        Finally

        End Try

    End Sub

    Private Sub load_cbo_category()
        Try
            Dim connection As New System.Data.SqlClient.SqlConnection(ConnectServer())
            Dim sql As String
            sql = _
            "SELECT [cat_id]" & _
            ", [cat_desc]" & _
            " FROM [tbl_category]"
            Dim command As New System.Data.SqlClient.SqlCommand(sql, connection)

            Dim adpt As New Data.SqlClient.SqlDataAdapter(command)
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If
            dt_brand.clear()
            adpt.Fill(dt_brand)
            cbo_category.DataSource = dt_brand
            cbo_category.DisplayMember = "cat_desc"
            cbo_category.ValueMember = "cat_id"
            cbo_category.SelectedIndex = -1
        Catch ex As SqlException
            MessageBox.Show("An error occurred while loading data !" & vbCrLf & ex.ToString())
        Finally

        End Try

    End Sub

    Private Sub load_cbo_sub_category(ByVal cat_code As String)
        Try
            Dim connection As New System.Data.SqlClient.SqlConnection(ConnectServer())
            Dim sql As String
            sql = _
            "SELECT [sub_cat_code]" & _
            ", [sub_cat_desc]" & _
            " FROM [tbl_sub_category]" & _
            " WHERE [cat_id] = '" & cat_code & "'"
            Dim command As New System.Data.SqlClient.SqlCommand(sql, connection)
            Dim dt_brand As New DataTable
            Dim adpt As New Data.SqlClient.SqlDataAdapter(command)
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If
            adpt.Fill(dt_brand)
            cbo_sub_category.DataSource = dt_brand
            cbo_sub_category.DisplayMember = "sub_cat_desc"
            cbo_sub_category.ValueMember = "sub_cat_code"
            cbo_sub_category.Text = ""
            'cbo_category.SelectedIndex = -1
        Catch ex As SqlException
            MessageBox.Show("An error occurred while loading data !" & vbCrLf & ex.ToString())
        Finally

        End Try

    End Sub

    
    Private Sub load_cbo_part()
        Try
            Dim connection As New System.Data.SqlClient.SqlConnection(ConnectServer())
            Dim sql As String
            sql = _
"select b.part_id, b.description from tbl_part b"
            '" left join tbl_sub_category c on b.sub_cat_code = c.sub_cat_code" & _
            '" left join tbl_category d on c.cat_code = d.cat_code" & _
            '" left join tbl_brand e on b.brand_id = e.brand_id"
            '"SELECT [part_number]" & _
            '" ,[description]" & _
            '" FROM [tbl_part]"
            Dim command As New System.Data.SqlClient.SqlCommand(sql, connection)
            Dim dt_part As New DataTable
            Dim adpt As New Data.SqlClient.SqlDataAdapter(command)
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If
            adpt.Fill(dt_part)
            cbo_part.DataSource = dt_part
            cbo_part.DisplayMember = "description"
            cbo_part.ValueMember = "part_id"
            cbo_part.SelectedIndex = -1
        Catch ex As SqlException
            MessageBox.Show("An error occurred while loading data !" & vbCrLf & ex.ToString())
        Finally

        End Try

    End Sub
   

    Private Sub cbo_category_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_category.SelectedIndexChanged
        If Not cbo_category.SelectedIndex = -1 Then
            'MsgBox(dt_brand(cbo_category.SelectedIndex).Item(0).ToString)
            load_cbo_sub_category(dt_brand(cbo_category.SelectedIndex).Item(0).ToString)
        End If
    End Sub

    Private Sub frm_item_list_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim a As New LoginForm1
        'If a.ShowDialog = Windows.Forms.DialogResult.OK Then
        '    LoadGrid()
        load_cbo_part()
        load_cbo_brand()
        load_cbo_category()
        list_btw()
        'Else
        '    Me.Dispose()
        'End If
        
    End Sub

    Private Sub BRANDMAKEToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim a As New frm_brand1
        a.Show()
    End Sub

    Private Sub CATEGORYToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim a As New frm_category
        a.Show()
    End Sub

    Private Sub SUBCATEGORYToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim a As New frm_sub_category
        a.Show()
    End Sub

    Private Sub PARTNUMBERToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim a As New frm_part1
        a.Show()
    End Sub

    Private Sub USERToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim a As New frm_user1
        a.Show()
    End Sub

    Private Sub CREToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim a As New frm_create_x
        a.Show()
    End Sub

    Private Sub btn_search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_search.Click
        If btn_search.Text = "&Search" Then
            LoadGrid()
        End If
    End Sub

    Private Sub list_btw()
        Dim myCoolFolder As String = Path & "/bt/"
        For Each myCoolFile As String In My.Computer.FileSystem.GetFiles _
        (myCoolFolder, FileIO.SearchOption.SearchTopLevelOnly, "*.btw")
            cbo_print.Items.Add(IO.Path.GetFileName(myCoolFile))
        Next
    End Sub

    Private Sub btn_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_save.Click
        Try
            Dim TW As System.IO.TextWriter
            TW = System.IO.File.CreateText(Path + "\bt\print.txt")

            For ctr As Integer = 0 To dgv_parts.RowCount - 1
                Dim bolchk As New Boolean
                bolchk = dgv_parts.Item(0, ctr).Value
                If bolchk Then
                    TW.WriteLine(dgv_parts.Item("asset_number", ctr).Value & "|" & dgv_parts.Item("serial_number", ctr).Value.ToString & "|" & dgv_parts.Item("description", ctr).Value & "|" & dgv_parts.Item("model_no", ctr).Value & "|" & dgv_parts.Item("brand_name", ctr).Value)
                    'src_copy.ImportRow(src.Rows(r))
                End If
            Next

            ' For ctr As Integer = 0 To dgv_parts.Rows.Count - 1
            'TW.WriteLine(dgv_parts.Item("asset_number", ctr).Value & "|" & dgv_parts.Item("serial_number", ctr).Value.ToString & "|" & dgv_parts.Item("description", ctr).Value & "|" & dgv_parts.Item("model_no", ctr).Value & "|" & dgv_parts.Item("brand_name", ctr).Value)
            'TW.WriteLine(dgv_parts.Item("asset_number", ctr).Value & "|" & "|" & dgv_parts.Item("description", ctr).Value & "|" & dgv_parts.Item("model_no", ctr).Value & "|" & dgv_parts.Item("brand_name", ctr).Value)
            ' Next

            If cbo_print.SelectedIndex >= 0 Then
                Dim p As New Process
                p.StartInfo.UseShellExecute = True
                p.StartInfo.WorkingDirectory = Path
                p.StartInfo.Arguments = Path & "\bt\" & cbo_print.Text & " /P/X"
                p.StartInfo.FileName = Path + "\bt\BarTend.exe"
                p.Start()
                p.Dispose()
            Else
                MsgBox("Please select a format!")
            End If

            TW.Dispose()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

   

    Private Sub btn_chk_all_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_chk_all.Click
        For r As Integer = 0 To dgv_parts.RowCount - 1
            Dim bolchk As New Boolean
            bolchk = dgv_parts.Item(0, r).Value
            If bolchk = False Then
                dgv_parts.Item(0, r).Value = True
            End If
        Next
    End Sub

    Private Sub btn_uncheck_all_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_uncheck_all.Click
        For r As Integer = 0 To dgv_parts.RowCount - 1
            Dim bolchk As New Boolean
            bolchk = dgv_parts.Item(0, r).Value
            If bolchk Then
                dgv_parts.Item(0, r).Value = False
            End If
        Next
    End Sub

  
    Private Sub btn_edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_edit.Click
        Try
            If btn_edit.Text = "&Edit" Then
                btn_search.Enabled = False
                btn_clear.Text = "&Save"
                btn_edit.Text = "&Cancel"
                'reset_txtbox()
                'btn_new.Text = "&New"
                'btn_edit.Text = "&Edit"
                'btn_search.Text = "&Search"

                txt_asset_number.Text = dgv_parts.Item("asset_number", dgv_parts.CurrentRow.Index).Value.ToString
                txt_asset_number.ReadOnly = True
                txt_serial_number.Text = dgv_parts.Item("serial_number", dgv_parts.CurrentRow.Index).Value.ToString
                cbo_part.SelectedValue = dgv_parts.Item("part_id", dgv_parts.CurrentRow.Index).Value
                'txt_model.Text = dgv_parts.Item("model_no", dgv_parts.CurrentRow.Index).Value.ToString
                'If dgv_parts.Item("brand_id", dgv_parts.CurrentRow.Index).Value.ToString <> String.Empty Then
                'cbo_brand.SelectedValue = dgv_parts.Item("brand_id", dgv_parts.CurrentRow.Index).Value
                'Else
                '   cbo_brand.SelectedIndex = -1
                'End If

                'cbo_part.SelectedText = dgv_parts.Item
                'txt_part_number.Text = dgv_parts.Item("part_number", dgv_parts.CurrentRow.Index).Value.ToString
                'txt_description.Text = dgv_parts.Item("description", dgv_parts.CurrentRow.Index).Value.ToString
                'cbo_brand.SelectedValue = dgv_parts.Item("brand_id", dgv_parts.CurrentRow.Index).Value
                'txt_model.Text = dgv_parts.Item("model_no", dgv_parts.CurrentRow.Index).Value.ToString
                'btn_new.Text = "&Update"
                'btn_edit.Text = "&Cancel"
                'btn_search.Text = "C&heck Part#"
            Else
                btn_search.Enabled = True
                btn_clear.Text = "&Clear"
                btn_edit.Text = "&Edit"
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Function update_cmd() As Boolean
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim sql As String
        con.ConnectionString = ConnectServer()
        Try

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            sql = _
"UPDATE [tbl_item]" & _
" SET [part_id] = @part_id" & _
" ,[serial_number] = @serial_number" & _
" WHERE [asset_number] = @asset_number"


            '"UPDATE [tbl_part]" & _
            '"SET [part_number] = @part_number" & _
            '",[description] = @description" & _
            '",[brand_id] = @brand_id" & _
            '",[model_no] = @model_no" & _
            '",[sub_cat_id] = @sub_cat_id" & _
            '" WHERE [part_id] = @part_id"

            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@part_id", dgv_parts.Item("part_id", dgv_parts.CurrentRow.Index).Value)
            cmd.Parameters.AddWithValue("@serial_number", txt_serial_number.Text)
            cmd.Parameters.AddWithValue("@asset_number", txt_asset_number.Text)
         

            If cmd.ExecuteNonQuery() > 0 Then
                MsgBox("Asset Number: " & txt_asset_number.Text & " successfully updated!")
                Return True
            Else
                MsgBox("Asset Number: " & txt_asset_number.Text & " failed update!")
                Return False
            End If
            con.Dispose()
            cmd.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function

    Private Function delete_cmd() As Boolean
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim sql As String
        con.ConnectionString = ConnectServer()
        Try

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            sql = _
            "DELETE [tbl_item]" & _
            " WHERE [asset_number] = @asset_number"

            '"UPDATE [tbl_item]" & _
            '" SET [part_id] = @part_id" & _
            '" ,[serial_number] = @serial_number" & _
            '" WHERE [asset_number] = @asset_number"


            '"UPDATE [tbl_part]" & _
            '"SET [part_number] = @part_number" & _
            '",[description] = @description" & _
            '",[brand_id] = @brand_id" & _
            '",[model_no] = @model_no" & _
            '",[sub_cat_id] = @sub_cat_id" & _
            '" WHERE [part_id] = @part_id"

            cmd = New SqlCommand(sql, con)
            ' cmd.Parameters.AddWithValue("@part_id", dgv_parts.Item("part_id", dgv_parts.CurrentRow.Index).Value)
            'cmd.Parameters.AddWithValue("@serial_number", txt_serial_number.Text)
            cmd.Parameters.AddWithValue("@asset_number", dgv_parts.Item("asset_number", dgv_parts.CurrentRow.Index).Value.ToString)

            'txt_asset_number.Text)


            If cmd.ExecuteNonQuery() > 0 Then
                MsgBox("Asset Number: " & dgv_parts.Item("asset_number", dgv_parts.CurrentRow.Index).Value.ToString & " successfully deleted!")
                Return True
            Else
                MsgBox("Asset Number: " & dgv_parts.Item("asset_number", dgv_parts.CurrentRow.Index).Value.ToString & " failed delete!")
                Return False
            End If
            con.Dispose()
            cmd.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function

    Private Function insert_delete_cmd() As Boolean
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim sql As String
        con.ConnectionString = ConnectServer()
        Try

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            sql = _
            "INSERT INTO [tbl_delete]" & _
            " ([user_id]" & _
            " ,[asset_number])" & _
            " VALUES" & _
            " (@user_id" & _
            " ,@asset_number)"


            '"INSERT INTO [tbl_brand] ([brand_name],[brand_code]) VALUES (@brand_name, @brand_code)"
            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@user_id", user_id)
            cmd.Parameters.AddWithValue("@asset_number", dgv_parts.Item("asset_number", dgv_parts.CurrentRow.Index).Value.ToString)

            If cmd.ExecuteNonQuery() > 0 Then
                'MsgBox("Brand: " & txt_brand.Text & " successfully inserted!")
                Return True
            Else
                'MsgBox("Brand: " & txt_brand.Text & " failed insert!")
                Return False
            End If
            con.Dispose()
            cmd.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function

    Private Sub btn_clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_clear.Click
        If btn_clear.Text = "&Clear" Then
            txt_num_from.Text = ""
            txt_num_to.Text = ""
            txt_asset_number.Text = ""
            txt_serial_number.Text = ""
            txt_model.Text = ""
            cbo_part.Text = ""
            cbo_part.SelectedIndex = -1
            cbo_brand.SelectedIndex = -1
            cbo_category.SelectedIndex = -1
            cbo_sub_category.SelectedIndex = -1
        Else
            If update_cmd() Then
                txt_asset_number.ReadOnly = False
                btn_edit.Text = "&Edit"
                btn_clear.Text = "&Clear"
                btn_search.Enabled = True
            End If
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim a As System.Windows.Forms.DialogResult
        a = MessageBox.Show("Are you sure you want to delete asset number:" & dgv_parts.Item("asset_number", dgv_parts.CurrentRow.Index).Value.ToString & "?", _
                                   "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        If a = Windows.Forms.DialogResult.Yes Then
            If delete_cmd() Then
                insert_delete_cmd()
            End If
            'Me.Dispose()
        End If
    End Sub

    Private Sub txt_num_from_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_num_from.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txt_num_to_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_num_to.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub rpt_1()
        Dim myReport As New ReportDocument
        Dim myData As New DataSet
        Dim conn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim myAdapter As New SqlDataAdapter
        conn.ConnectionString = ConnectServer()

        Dim mySql As String
        Dim str_where As List(Of String) = New List(Of String)
        Dim str_where_con As String = ""
        mySql = "SELECT * FROM vw_receive"

        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If

            'If cb_t_date.Checked Then
            '    str_where.Add("(t_date BETWEEN '" & dtFrom.Value.ToString("yyyy-MM-dd") & "' AND '" & dtTo.Value.AddDays(1).ToString("yyyy-MM-dd") & "')")
            'End If

            'If cbo_transaction_code.SelectedIndex >= 0 Then
            '    str_where.Add("transaction_code = '" & cbo_transaction_code.SelectedValue & "'")
            'End If

            'Dim builder As StringBuilder = New StringBuilder()
            'For Each val As String In str_where
            '    builder.Append(val).Append(" and ")
            'Next
            'Dim res = builder.ToString()
            'If res.Count > 0 Then
            '    str_where_con = res.Remove(res.Length - 5, 5)
            '    mySql = mySql + " WHERE " + str_where_con
            'End If


            'conn.Open()
            cmd.CommandText = mySql
            '"select * from vw_dispatch"
            cmd.Connection = conn

            myAdapter.SelectCommand = cmd
            myAdapter.Fill(myData)
            If Not Directory.Exists(Path + "\rpt\") Then
                Directory.CreateDirectory(Path + "\rpt\")
            End If
            'myData.WriteXml(Path + "\rpt\receive.xml", XmlWriteMode.WriteSchema)
            dgv_parts.DataSource = myData.Tables(0)
            dgv_parts.AutoResizeColumns()

            Dim A As New frm_rpt
            myReport.Load(Path + "\rpt\rpt1.rpt")
            myReport.SetDataSource(myData)
            A.myViewer.ReportSource = myReport
            A.Text = "RECEIVE REPORT"
            A.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "HEXAGON")
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'rpt_1()
        LoadGrid2()
    End Sub
End Class