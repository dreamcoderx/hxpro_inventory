Imports System.Data
Imports System.Data.SqlClient
Imports System.Xml
Public Class frmSetBarcodeView1
    'Dim dt_part As New DataTable
    Private Sub frm_create_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadSetBarcode()
        'cbo_print.Items.Add("1D")
        'cbo_print.Items.Add("2D")
        'load_cbo_part()
    End Sub
    Private Function loadSetBarcode() As Boolean
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim sql As String
        con.ConnectionString = ConnectServer()
        Try

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            sql = "select * from v_set_barcode"

            cmd = New SqlCommand(sql, con)
            Dim dtRentalHdr As New DataTable

            Dim adpt As New Data.SqlClient.SqlDataAdapter(cmd)
            adpt.Fill(dtRentalHdr)
            dgvSetList.DataSource = dtRentalHdr
            dgvSetList.AutoResizeColumns()
            con.Dispose()
            cmd.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function

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
    Private Function insert_cmd() As Boolean
        '        Dim str_item_code As List(Of String) = New List(Of String)
        '        Dim str_item_code_where As String = ""
        '        Dim con As New SqlConnection
        '        Dim cmd As New SqlCommand
        '        Dim sql As String
        '        con.ConnectionString = ConnectServer()
        '        Try

        '            If con.State = ConnectionState.Closed Then
        '                con.Open()
        '            End If
        '            For ctr As Integer = 1 To NumericUpDown1.Value
        '                sql = _
        '               "INSERT INTO [tbl_item]" & _
        '               " ([part_id])" & _
        '               " VALUES(@part_id);" & _
        '               " SELECT SCOPE_IDENTITY()"
        '                cmd = New SqlCommand(sql, con)
        '                cmd.Parameters.AddWithValue("@part_id", txt_part_id.Text)

        '                'cbo_part.SelectedValue)
        '                str_item_code.Add(cmd.ExecuteScalar)
        '            Next
        '            For Each val As String In str_item_code
        '                If str_item_code_where = "" Then
        '                    str_item_code_where = "item_code = " & val
        '                Else
        '                    str_item_code_where = str_item_code_where & " or item_code = " & val
        '                End If
        '            Next
        '            sql = _
        '            "select a.item_code, 'HX' + RIGHT('00000000' + LTRIM(STR(a.item_code)), 6) as asset_number, b.part_number, b.part_id, b.description, b.model_no, c.brand_name, a.serial_number, '                                     ' as status from tbl_item a" & _
        '" left join tbl_part b on a.part_id = b.part_id" & _
        '" left join tbl_brand c on b.brand_id = c.brand_id"


        '            '"select * from tbl_item"

        '            ' MsgBox(str_item_code_where)
        '            If str_item_code_where <> "" Then
        '                sql = sql & " where " & str_item_code_where
        '            End If

        '            'MsgBox(sql)
        '            cmd = New SqlCommand(sql, con)
        '            Dim dt_created As New DataTable
        '            Dim adpt As New Data.SqlClient.SqlDataAdapter(cmd)
        '            'dt_created.Clear()
        '            adpt.Fill(dt_created)
        '            'dgv_created.DataSource = Nothing
        '            Dim b As New frm_create_print




        '            Dim checkCol As DataGridViewCheckBoxColumn = New DataGridViewCheckBoxColumn()
        '            checkCol.HeaderText = "select"
        '            b.dgv_created.Columns.Clear()
        '            b.dgv_created.DataSource = Nothing
        '            b.dgv_created.Columns.Add(checkCol)
        '            b.dgv_created.Columns(0).Width = 50


        '            b.dgv_created.DataSource = dt_created


        '            'b.dgv_created.Columns(0).ReadOnly = True
        '            b.dgv_created.Columns(1).ReadOnly = True
        '            b.dgv_created.Columns(2).ReadOnly = True
        '            b.dgv_created.Columns(3).ReadOnly = True
        '            b.dgv_created.Columns(4).ReadOnly = True
        '            b.dgv_created.Columns(5).ReadOnly = True
        '            b.dgv_created.Columns(6).ReadOnly = True
        '            b.dgv_created.Columns(7).ReadOnly = True
        '            b.dgv_created.Columns(9).ReadOnly = True
        '            b.dgv_created.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

        '            If b.ShowDialog() Then
        '                ' cbo_part.SelectedIndex = -1
        '                txt_part_id.Text = ""
        '                txt_part_number.Text = ""
        '                txt_description.Text = ""
        '                txt_brand.Text = ""
        '                txt_model.Text = ""
        '                txt_category.Text = ""
        '                txt_sub_category.Text = ""
        '            End If

        '            con.Dispose()
        '            cmd.Dispose()
        '        Catch ex As Exception
        '            MsgBox(ex.Message)
        '        End Try

    End Function

    'Private Function update_cmd() As Boolean
    '    Dim str_item_code As List(Of String) = New List(Of String)
    '    Dim str_item_code_where As String = ""
    '    Dim con As New SqlConnection
    '    Dim cmd As New SqlCommand
    '    Dim sql As String = ""
    '    Dim TW As System.IO.TextWriter

    '    con.ConnectionString = ConnectServer()
    '    Try

    '        If con.State = ConnectionState.Closed Then
    '            con.Open()
    '        End If
    '        TW = System.IO.File.CreateText(Path + "\bt\print.txt")

    '        For ctr As Integer = 0 To dgv_created.Rows.Count - 1
    '            Dim bol_duplicate_serial As Boolean = False
    '            'MsgBox(dgv_created.Item("asset_number", ctr).Value)
    '            If dgv_created.Item("serial_number", ctr).Value.ToString <> String.Empty Then
    '                sql = _
    '         "select count(*) from tbl_item" & _
    '         " where part_id = @part_id and" & _
    '         " serial_number = @serial_number and not(" & _
    '         " item_code = @item_code)"
    '                cmd = New SqlCommand(sql, con)
    '                cmd.Parameters.AddWithValue("@part_id", dgv_created.Item("part_id", ctr).Value)
    '                cmd.Parameters.AddWithValue("@serial_number", dgv_created.Item("serial_number", ctr).Value.ToString)
    '                cmd.Parameters.AddWithValue("@item_code", dgv_created.Item("item_code", ctr).Value)

    '                If cmd.ExecuteScalar > 0 Then
    '                    bol_duplicate_serial = True
    '                End If
    '            End If
    '            If bol_duplicate_serial Then
    '                dgv_created.Item("status", ctr).Value = "Serial Number is duplicate!"
    '            Else
    '                sql = _
    '              "UPDATE [tbl_item]" & _
    '              " SET [serial_number] = @serial_number, [asset_number]= @asset_number" & _
    '              " WHERE [item_code] = @item_code"
    '                cmd = New SqlCommand(sql, con)

    '                cmd.Parameters.AddWithValue("@item_code", dgv_created.Item("item_code", ctr).Value)
    '                cmd.Parameters.AddWithValue("@asset_number", dgv_created.Item("asset_number", ctr).Value)
    '                cmd.Parameters.AddWithValue("@serial_number", dgv_created.Item("serial_number", ctr).Value.ToString)
    '                If cmd.ExecuteNonQuery() > 0 Then
    '                    dgv_created.Item("status", ctr).Value = "Updated!"
    '                Else
    '                    dgv_created.Item("status", ctr).Value = "Update failed!"
    '                End If
    '            End If
    '            'End If
    '            TW.WriteLine(dgv_created.Item("asset_number", ctr).Value & "|" & dgv_created.Item("serial_number", ctr).Value.ToString & "|" & dgv_created.Item("description", ctr).Value)
    '            'description
    '        Next
    '        TW.Flush()
    '        TW.Close()
    '        con.Dispose()
    '        cmd.Dispose()
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try

    'End Function



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

    'Private Sub btn_browse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_browse.Click
    '    'Dim a As New frm_part
    '    'If a.ShowDialog() = Windows.Forms.DialogResult.OK Then
    '    '    'load_cbo_part()
    '    '    'cbo_part.SelectedValue = (a.dgv_parts.Item("part_id", a.dgv_parts.CurrentRow.Index).Value())
    '    '    txt_part_id.Text = (a.dgv_parts.Item("part_id", a.dgv_parts.CurrentRow.Index).Value())
    '    '    txt_part_number.Text = (a.dgv_parts.Item("part_number", a.dgv_parts.CurrentRow.Index).Value())
    '    '    txt_description.Text = (a.dgv_parts.Item("description", a.dgv_parts.CurrentRow.Index).Value())
    '    '    txt_brand.Text = (a.dgv_parts.Item("brand_name", a.dgv_parts.CurrentRow.Index).Value().ToString)
    '    '    txt_model.Text = (a.dgv_parts.Item("model_no", a.dgv_parts.CurrentRow.Index).Value().ToString)
    '    '    txt_category.Text = (a.dgv_parts.Item("cat_desc", a.dgv_parts.CurrentRow.Index).Value().ToString)
    '    '    txt_sub_category.Text = (a.dgv_parts.Item("sub_cat_desc", a.dgv_parts.CurrentRow.Index).Value().ToString)
    '    'Else
    '    '    txt_part_id.Text = ""
    '    '    txt_part_number.Text = ""
    '    '    txt_description.Text = ""
    '    '    txt_brand.Text = ""
    '    '    txt_model.Text = ""
    '    '    txt_category.Text = ""
    '    '    txt_sub_category.Text = ""
    '    'End If
    'End Sub

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

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If dgvSetList.CurrentRow.Index > -1 Then
            lblSetBarcode.Text = (dgvSetList.Item("set_barcode", dgvSetList.CurrentRow.Index).Value())
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
        End If

    End Sub

    Private Function deleteSet(ByVal strItemCode) As Boolean
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim sql As String
        con.ConnectionString = ConnectServer()
        Try

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            sql = "DELETE FROM [tbl_item]" & _
      " WHERE [item_code] = @item_code"
            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@item_code", strItemCode)

            If cmd.ExecuteNonQuery() > 0 Then
                sql = "UPDATE [tbl_item]" & _
" SET [set_item_code] = @d1 where [set_item_code] = @d2"
                cmd = New SqlCommand(sql, con)
                cmd.Parameters.AddWithValue("@d1", DBNull.Value)
                cmd.Parameters.AddWithValue("@d2", strItemCode)
                cmd.ExecuteNonQuery()
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

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If dgvSetList.CurrentRow.Index > -1 Then
            Dim a As System.Windows.Forms.DialogResult
            Dim strItemCode As String = (dgvSetList.Item("item_code", dgvSetList.CurrentRow.Index).Value())
            a = MessageBox.Show(String.Format("Are you sure you want to delete this set:{0}?", dgvSetList.Item("set_barcode", dgvSetList.CurrentRow.Index).Value()), _
                                         "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            If a = DialogResult.Yes Then
                If deleteSet(strItemCode) Then
                    MsgBox("Set Code successfully deleted!")
                    loadSetBarcode()
                Else
                    MsgBox("Set Code failed to delete!")
                End If
            End If
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim a As New frmRentalSetParent
        a.ShowDialog()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        loadSetBarcode()
    End Sub
End Class