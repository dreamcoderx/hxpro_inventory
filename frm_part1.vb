Imports System.Data
Imports System.Data.SqlClient
Imports System.Xml
Public Class frm_part1
    Dim dt As New DataTable
    Dim dt_brand As New DataTable
    Private Sub btn_search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_search.Click
        If btn_search.Text = "&Search" Then
            LoadGrid()
        Else
            If txt_part_number.Text <> String.Empty Then
                If src_part_number_cmd() Then
                    MsgBox("Part Number already exist!", MsgBoxStyle.Exclamation, "HxPRO")
                Else
                    MsgBox("Part Number does not exist!", MsgBoxStyle.Exclamation, "HxPRO")
                End If
            Else
                MsgBox("Please Type the Part Number to search!")
            End If

        End If
    End Sub
    Private Sub LoadGrid()
        'Dim mySql As String
        Dim str_where As List(Of String) = New List(Of String)
        Dim str_where_con As String = ""
        'mySql = "SELECT item_code, item_desc, uom, barcode FROM tbl_items"
        Try
            Dim connection As New System.Data.SqlClient.SqlConnection(ConnectServer())
            Dim sql As String
            sql = _
"select b.part_id, b.part_number, b.description, e.brand_id, e.brand_name, b.model_no, d.cat_desc, c.sub_cat_desc from tbl_part b" & _
" left join tbl_sub_category c on b.sub_cat_id  = c.sub_cat_id" & _
" left join tbl_category d on c.cat_id = d.cat_id" & _
" left join tbl_brand e on b.brand_id = e.brand_id"


            '"SELECT a.part_number, a.description, a.brand_id, b.brand_name, a.model_no  FROM tbl_part a" & _
            '" left join tbl_brand b on a.brand_id = b.brand_id"

            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If

            If txt_part_id.Text <> String.Empty Then
                str_where.Add("part_id = '" & txt_part_id.Text & "'")
            End If
            If txt_part_number.Text <> String.Empty Then
                str_where.Add("part_number like '%" & txt_part_number.Text & "%'")
            End If

            If txt_description.Text <> String.Empty Then
                str_where.Add("description like '%" & txt_description.Text & "%'")
            End If

            If cbo_brand.Text <> String.Empty Then
                str_where.Add("brand_name like '%" & cbo_brand.Text & "%'")
            End If

            If txt_model.Text <> String.Empty Then
                str_where.Add("model_no like '%" & txt_model.Text & "%'")
            End If

            If cbo_category.Text <> String.Empty Then
                str_where.Add("d.cat_desc like '%" & cbo_category.Text & "%'")
            End If

            If cbo_sub_category.Text <> String.Empty Then
                str_where.Add("c.sub_cat_desc like '%" & cbo_sub_category.Text & "%'")
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
            Dim command As New System.Data.SqlClient.SqlCommand(sql, connection)

            Dim adpt As New Data.SqlClient.SqlDataAdapter(command)
            dt.Clear()
            adpt.Fill(dt)
            dgv_parts.DataSource = Nothing
            dgv_parts.DataSource = dt

            'b.part_number, b.description, e.brand_name, b.model_no, d.cat_desc, c.sub_cat_desc from tbl_part b" & _
            dgv_parts.Columns(0).HeaderText = "ID"
            dgv_parts.Columns(1).HeaderText = "PART NUMBER"
            dgv_parts.Columns(2).HeaderText = "DESCRIPTION"
            dgv_parts.Columns(3).HeaderText = "BRAND ID"
            dgv_parts.Columns(4).HeaderText = "BRAND NAME"
            dgv_parts.Columns(5).HeaderText = "MODEL NUMBER"
            dgv_parts.Columns(6).HeaderText = "CATEGORY"
            dgv_parts.Columns(7).HeaderText = "SUB CATEGORY"
            dgv_parts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            dgv_parts.AutoResizeColumns()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btn_new_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_new.Click
        If btn_new.Text = "&New" Then
            'reset_txtbox()
            btn_new.Text = "&Save"
            btn_edit.Text = "&Cancel"
            btn_search.Text = "C&heck Part#"
            txt_part_id.Text = ""
            txt_part_id.ReadOnly = True
        ElseIf btn_new.Text = "&Save" Then
            If src_part_number_cmd() Then
                MsgBox("Part Number already Exist!")
            Else
                If chk_complete() Then
                    If insert_cmd() Then
                        LoadGrid()
                        txt_part_id.ReadOnly = False
                        btn_new.Text = "&New"
                        btn_edit.Text = "&Edit"
                        btn_search.Text = "&Search"
                    End If
                Else
                    MsgBox("Please Complete needed data!")
                End If
            End If
        ElseIf btn_new.Text = "&Update" Then
            If chk_complete() Then
                If update_cmd() Then
                    txt_part_id.ReadOnly = False
                    txt_part_number.ReadOnly = False
                    LoadGrid()
                    btn_new.Text = "&New"
                    btn_edit.Text = "&Edit"
                    btn_search.Text = "&Search"
                End If
            Else
                MsgBox("Please Complete data!")
            End If

        End If
    End Sub

    Private Function chk_complete() As Boolean
        If txt_part_number.Text <> "" And txt_description.Text <> "" And cbo_sub_category.SelectedIndex >= 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Sub btn_edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_edit.Click
        Try
            If btn_edit.Text = "&Cancel" Then
                reset_txtbox()
                txt_part_id.ReadOnly = False
                btn_new.Text = "&New"
                btn_edit.Text = "&Edit"
                btn_search.Text = "&Search"
            Else
                txt_part_id.Text = dgv_parts.Item("part_id", dgv_parts.CurrentRow.Index).Value.ToString
                txt_part_id.ReadOnly = True
                txt_part_number.Text = dgv_parts.Item("part_number", dgv_parts.CurrentRow.Index).Value.ToString
                txt_description.Text = dgv_parts.Item("description", dgv_parts.CurrentRow.Index).Value.ToString
                cbo_brand.SelectedValue = dgv_parts.Item("brand_id", dgv_parts.CurrentRow.Index).Value
                txt_model.Text = dgv_parts.Item("model_no", dgv_parts.CurrentRow.Index).Value.ToString
                btn_new.Text = "&Update"
                btn_edit.Text = "&Cancel"
                btn_search.Text = "C&heck Part#"
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub reset_txtbox()
        txt_part_id.Text = ""
        txt_part_number.Text = ""
        txt_part_number.ReadOnly = False
        cbo_brand.SelectedIndex = -1
        txt_description.Text = ""
        txt_model.Text = ""
    End Sub
    Private Function src_part_number_cmd() As Boolean
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim sql As String
        con.ConnectionString = ConnectServer()
        Try

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            sql = _
           "SELECT COUNT(*)" & _
           " FROM [tbl_part]" & _
           " where part_number = @part_number"
            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@part_number", txt_part_number.Text)
            If cmd.ExecuteScalar = 0 Then
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

    Private Function insert_cmd() As Boolean
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim sql As String
        con.ConnectionString = ConnectServer()
        Try

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            sql = _
"INSERT INTO [tbl_part](" & _
"[part_number]" & _
",[description]" & _
", [brand_id]" & _
", [model_no]" & _
", [sub_cat_id])" & _
" VALUES (" & _
"@part_number" & _
", @description" & _
", @brand_id" & _
", @model_no" & _
", @sub_cat_id)"
            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@part_number", txt_part_number.Text)
            cmd.Parameters.AddWithValue("@description", txt_description.Text)
            cmd.Parameters.AddWithValue("@brand_id", IIf(cbo_brand.SelectedIndex >= 0, cbo_brand.SelectedValue, DBNull.Value))
            cmd.Parameters.AddWithValue("@model_no", txt_model.Text)
            cmd.Parameters.AddWithValue("@sub_cat_id", cbo_sub_category.SelectedValue)

            If cmd.ExecuteNonQuery() > 0 Then
                MsgBox("Part Number: " & txt_part_number.Text & " successfully inserted!")
                Return True
            Else
                MsgBox("Part Number: " & txt_part_number.Text & " failed insert!")
                Return False
            End If
            con.Dispose()
            cmd.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function

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
"UPDATE [tbl_part]" & _
"SET [part_number] = @part_number" & _
",[description] = @description" & _
",[brand_id] = @brand_id" & _
",[model_no] = @model_no" & _
",[sub_cat_id] = @sub_cat_id" & _
" WHERE [part_id] = @part_id"

            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@part_id", txt_part_id.Text)
            'dgv_parts.Item("part_id", dgv_parts.CurrentRow.Index).Value)
            cmd.Parameters.AddWithValue("@part_number", txt_part_number.Text)
            cmd.Parameters.AddWithValue("@description", txt_description.Text)
            cmd.Parameters.AddWithValue("@brand_id", IIf(cbo_brand.SelectedIndex >= 0, cbo_brand.SelectedValue, DBNull.Value))
            cmd.Parameters.AddWithValue("@model_no", txt_model.Text)
            cmd.Parameters.AddWithValue("@sub_cat_id", cbo_sub_category.SelectedValue)

            If cmd.ExecuteNonQuery() > 0 Then
                MsgBox("Part Number: " & txt_part_number.Text & " successfully updated!")
                Return True
            Else
                MsgBox("Part Number: " & txt_part_number.Text & " failed update!")
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
         "DELETE FROM [tbl_part]" & _
      " WHERE part_id = @part_id"

            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@part_id", dgv_parts.Item("part_id", dgv_parts.CurrentRow.Index).Value)


            If cmd.ExecuteNonQuery() > 0 Then
                MsgBox("Part ID: " & dgv_parts.Item("part_id", dgv_parts.CurrentRow.Index).Value & " sucessfully deleted!")
                Return True
            Else
                MsgBox("Part ID: " & dgv_parts.Item("part_id", dgv_parts.CurrentRow.Index).Value & " failed delete!")
                Return False
            End If
            con.Dispose()
            cmd.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function
    Private Sub load_cbo_brand()
        Try
            Dim connection As New System.Data.SqlClient.SqlConnection(ConnectServer())
            Dim sql As String
            sql = _
            "SELECT [brand_id]" & _
            ", [brand_name]" & _
            " FROM [tbl_brand] order by [brand_name]"
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
            'cbo_category.SelectedIndex = -1
        Catch ex As SqlException
            MessageBox.Show("An error occurred while loading data !" & vbCrLf & ex.ToString())
        Finally

        End Try

    End Sub

    Private Sub load_cbo_sub_category(ByVal cat_id As String)
        Try
            Dim connection As New System.Data.SqlClient.SqlConnection(ConnectServer())
            Dim sql As String
            sql = _
            "SELECT [sub_cat_id]" & _
            ", [sub_cat_desc]" & _
            " FROM [tbl_sub_category]" & _
            " WHERE [cat_id] = '" & cat_id & "'"
            Dim command As New System.Data.SqlClient.SqlCommand(sql, connection)
            Dim dt_brand As New DataTable
            Dim adpt As New Data.SqlClient.SqlDataAdapter(command)
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If
            adpt.Fill(dt_brand)
            cbo_sub_category.DataSource = dt_brand
            cbo_sub_category.DisplayMember = "sub_cat_desc"
            cbo_sub_category.ValueMember = "sub_cat_id"
            cbo_sub_category.Text = ""
            'cbo_category.SelectedIndex = -1
        Catch ex As SqlException
            MessageBox.Show("An error occurred while loading data !" & vbCrLf & ex.ToString())
        Finally

        End Try

    End Sub

    Private Sub frm_part_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        load_cbo_brand()
        load_cbo_category()
        clear()
    End Sub

    Private Sub btn_delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_delete.Click
        Try
            Dim a As System.Windows.Forms.DialogResult
            a = MessageBox.Show("Are you sure you want to delete the selected part?", _
                            "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

            If a = DialogResult.No Then
                Exit Try
            Else
                If delete_cmd() Then

                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "HxPRO")
        End Try
    End Sub

    Private Sub cbo_category_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_category.SelectedIndexChanged
        If Not cbo_category.SelectedIndex = -1 Then
            'MsgBox(dt_brand(cbo_category.SelectedIndex).Item(0).ToString)
            load_cbo_sub_category(dt_brand(cbo_category.SelectedIndex).Item(0).ToString)
        End If
    End Sub

    Private Sub cbo_sub_category_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_sub_category.SelectedIndexChanged

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If dt.Rows.Count > 0 Then
            ' MsgBox(dgv_parts.Item("part_number", dgv_parts.CurrentRow.Index).Value)
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        Else
            MsgBox("Invalid - grid is empty!")
        End If

    End Sub


    Private Sub clear()
        txt_part_number.Text = ""
        txt_description.Text = ""
        txt_model.Text = ""
        cbo_brand.SelectedIndex = -1
        cbo_category.SelectedIndex = -1
        cbo_sub_category.SelectedIndex = -1
    End Sub

    Private Sub btn_clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_clear.Click
        clear()
    End Sub
End Class