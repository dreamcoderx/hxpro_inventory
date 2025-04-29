Imports System.Data
Imports System.Data.SqlClient
Public Class frm_sub_category


    Private Sub frm_brand_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        load_cbo_category()
        load_dgv()
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
            Dim dt_cat As New DataTable
            'dt_cat.Clear()
            adpt.Fill(dt_cat)
            cbo_category.DataSource = dt_cat
            cbo_category.DisplayMember = "cat_desc"
            cbo_category.ValueMember = "cat_id"
            'cbo_category.SelectedIndex = -1
        Catch ex As SqlException
            MessageBox.Show("An error occurred while loading data !" & vbCrLf & ex.ToString())
        Finally

        End Try

    End Sub
    Private Sub load_dgv()
        Try
            Dim connection As New System.Data.SqlClient.SqlConnection(ConnectServer())
            Dim sql As String
            sql = _
"SELECT b.[cat_code]" & _
", b.cat_desc" & _
", a.[sub_cat_id]" & _
", a.[sub_cat_code]" & _
", [sub_cat_desc]" & _
" FROM [hxpro_db].[dbo].[tbl_sub_category] a" & _
" left join [hxpro_db].[dbo].[tbl_category] b on a.cat_id = b.cat_id"
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If
            If cbo_category.SelectedIndex >= 0 Then
                sql = sql + " where a.cat_id = '" & cbo_category.SelectedValue.ToString & "'"
            End If
            'dt.Clear()
            Dim command As New System.Data.SqlClient.SqlCommand(sql, connection)
            Dim adpt As New Data.SqlClient.SqlDataAdapter(command)
            Dim dt As New DataTable
            adpt.Fill(dt)
            dgv_brand.DataSource = dt
            dgv_brand.AutoResizeColumns()
            dgv_brand.Columns(0).HeaderText = "CATEGORY"
            dgv_brand.Columns(1).HeaderText = "CATEGORY DESCRIPTION"
            dgv_brand.Columns(2).HeaderText = "SUB CATEGORY ID"
            dgv_brand.Columns(3).HeaderText = "SUB CATEGORY CODE"
            dgv_brand.Columns(4).HeaderText = "SUB CATEGORY DESCRIPTION"

        Catch ex As SqlException
            MessageBox.Show("An error occurred while loading data !" & vbCrLf & ex.ToString())
        Finally

        End Try

    End Sub
    'Private Sub load_dgv_cbo()
    '    Try
    '        Dim connection As New System.Data.SqlClient.SqlConnection(ConnectServer())
    '        Dim sql As String
    '        sql = "SELECT * from tbl_sub_category"
    '        Dim command As New System.Data.SqlClient.SqlCommand(sql, connection)

    '        Dim adpt As New Data.SqlClient.SqlDataAdapter(command)

    '        If connection.State = ConnectionState.Closed Then
    '            connection.Open()
    '        End If
    '        dt.Clear()
    '        adpt.Fill(dt)
    '        dgv_brand.DataSource = dt
    '        dgv_brand.AutoResizeColumns()
    '    Catch ex As SqlException
    '        MessageBox.Show("An error occurred while loading data !" & vbCrLf & ex.ToString())
    '    Finally

    '    End Try

    'End Sub

    Private Sub btn_new_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_new.Click
        Try
            If btn_new.Text = "&New" Then
                txt_sub_cat_code.Text = ""
                txt_sub_cat_desc.Text = ""
                btn_new.Text = "&Save"
                btn_edit.Text = "&Cancel"
            ElseIf btn_new.Text = "&Save" Then
                If txt_sub_cat_code.Text <> "" And txt_sub_cat_desc.Text <> "" And cbo_category.SelectedIndex >= 0 Then
                    If insert_cmd() Then
                        load_dgv()
                        btn_new.Text = "&New"
                        btn_edit.Text = "&Edit"
                    End If
                Else
                    MsgBox("Please Complete Data!")
                End If

            ElseIf btn_new.Text = "&Update" Then
                If txt_sub_cat_code.Text <> "" And txt_sub_cat_desc.Text <> "" And cbo_category.SelectedIndex >= 0 Then
                    If update_cmd() Then
                        load_dgv()
                        txt_sub_cat_code.ReadOnly = False
                        btn_new.Text = "&New"
                        btn_edit.Text = "&Edit"
                    End If
                Else
                    MsgBox("Please Complete Data!")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub btn_edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_edit.Click
        Try
            If btn_edit.Text = "&Edit" Then
                txt_sub_cat_code.Text = dgv_brand.Item("sub_cat_code", dgv_brand.CurrentRow.Index).Value
                txt_sub_cat_desc.Text = dgv_brand.Item("sub_cat_desc", dgv_brand.CurrentRow.Index).Value
                ' txt_sub_cat_code.ReadOnly = True
                'txt_sub_cat_desc.Text = ""
                btn_new.Text = "&Update"
                btn_edit.Text = "&Cancel"
            Else
                txt_sub_cat_code.Text = ""
                btn_new.Text = "&New"
                btn_edit.Text = "&Edit"
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

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
           "INSERT INTO [tbl_sub_category]" & _
           " ([sub_cat_code]" & _
           " ,[sub_cat_desc]" & _
           " ,[cat_id])" & _
           " VALUES" & _
           " (@sub_cat_code" & _
           " ,@sub_cat_desc" & _
           " ,@cat_id)"

            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@sub_cat_code", txt_sub_cat_code.Text)
            cmd.Parameters.AddWithValue("@sub_cat_desc", txt_sub_cat_desc.Text)
            cmd.Parameters.AddWithValue("@cat_id", cbo_category.SelectedValue.ToString)

            If cmd.ExecuteNonQuery() > 0 Then
                MsgBox("Sub-Category Code: " & txt_sub_cat_code.Text & " successfully inserted!")
                Return True
            Else
                MsgBox("Sub-Category Code: " & txt_sub_cat_code.Text & " failed insert!")
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
            "UPDATE [tbl_sub_category]" & _
            " SET [sub_cat_code] = @sub_cat_code" & _
            " ,[sub_cat_desc] = @sub_cat_desc" & _
            " ,[cat_id] = @cat_id" & _
            " WHERE sub_cat_id = @sub_cat_id"
            '"UPDATE [tbl_category]" & _
            '" SET [cat_desc] = @cat_desc" & _
            '" WHERE [cat_code] = @cat_code"

            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@sub_cat_id", dgv_brand.Item("sub_cat_id", dgv_brand.CurrentRow.Index).Value)
            cmd.Parameters.AddWithValue("@sub_cat_code", txt_sub_cat_code.Text)
            cmd.Parameters.AddWithValue("@sub_cat_desc", txt_sub_cat_desc.Text)
            cmd.Parameters.AddWithValue("@cat_id", cbo_category.SelectedValue.ToString)

            If cmd.ExecuteNonQuery() > 0 Then
                MsgBox("Sub Category id: " & dgv_brand.Item("sub_cat_id", dgv_brand.CurrentRow.Index).Value & " successfully updated!")
                Return True
            Else
                MsgBox("Sub Category id: " & dgv_brand.Item("sub_cat_id", dgv_brand.CurrentRow.Index).Value & " failed update!")
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
          "DELETE FROM [tbl_sub_category]" & _
      " WHERE sub_cat_id = @sub_cat_id"
            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@sub_cat_id", dgv_brand.Item("sub_cat_id", dgv_brand.CurrentRow.Index).Value)

            If cmd.ExecuteNonQuery() > 0 Then
                MsgBox("Sub Category Code: " & dgv_brand.Item("sub_cat_code", dgv_brand.CurrentRow.Index).Value & " successfully deleted!")
                Return True
            Else
                MsgBox("Sub Category Code: " & dgv_brand.Item("sub_cat_code", dgv_brand.CurrentRow.Index).Value & " failed delete!")
                Return False
            End If
            con.Dispose()
            cmd.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function

    Private Sub btn_delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_delete.Click
        Try
            Dim a As System.Windows.Forms.DialogResult
            a = MessageBox.Show("Are you sure you want to delete the selected brand?", _
                            "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

            If a = DialogResult.No Then
                Exit Try
            Else
                If delete_cmd() Then
                    load_dgv()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cbo_category_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_category.SelectedIndexChanged
        'If Not cbo_category.SelectedIndex = -1 Then
        ' load_dgv()
        'MsgBox(dt_brand(cbo_category.SelectedIndex).Item(0).ToString)
        'load_cbo_sub_category(dt_brand(cbo_category.SelectedIndex).Item(0).ToString)

        ' End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        load_dgv()
    End Sub
End Class