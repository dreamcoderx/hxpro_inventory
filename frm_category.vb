Imports System.Data
Imports System.Data.SqlClient
Public Class frm_category
    Dim dt As New DataTable
    Private Sub frm_brand_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        load_dgv()
    End Sub
    Private Sub load_dgv()
        Try
            Dim connection As New System.Data.SqlClient.SqlConnection(ConnectServer())
            Dim sql As String
            sql = "SELECT [cat_id], [cat_code], [cat_desc] from tbl_category"
            Dim command As New System.Data.SqlClient.SqlCommand(sql, connection)

            Dim adpt As New Data.SqlClient.SqlDataAdapter(command)

            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If
            dt.Clear()
            adpt.Fill(dt)
            dgv_brand.DataSource = dt
            dgv_brand.Columns(0).HeaderText = "ID"
            dgv_brand.Columns(1).HeaderText = "CODE"
            dgv_brand.Columns(2).HeaderText = "DESCRIPTION"
            dgv_brand.AutoResizeColumns()
        Catch ex As SqlException
            MessageBox.Show("An error occurred while loading data !" & vbCrLf & ex.ToString())
        Finally

        End Try

    End Sub

    Private Sub btn_new_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_new.Click
        Try
            If btn_new.Text = "&New" Then
                txt_category_code.Text = ""
                txt_category_description.Text = ""
                btn_new.Text = "&Save"
                btn_edit.Text = "&Cancel"
            ElseIf btn_new.Text = "&Save" Then
                If txt_category_code.Text <> "" And txt_category_description.Text <> "" Then
                    If insert_cmd() Then
                        load_dgv()
                        btn_new.Text = "&New"
                        btn_edit.Text = "&Edit"
                    End If
                Else
                    MsgBox("Please Complete Data!")
                End If

            ElseIf btn_new.Text = "&Update" Then
                If txt_category_code.Text <> "" And txt_category_description.Text <> "" Then
                    If update_cmd() Then
                        load_dgv()
                        txt_category_code.ReadOnly = False
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
                txt_category_code.Text = dgv_brand.Item("cat_code", dgv_brand.CurrentRow.Index).Value
                'txt_category_code.ReadOnly = True
                txt_category_description.Text = dgv_brand.Item("cat_desc", dgv_brand.CurrentRow.Index).Value
                btn_new.Text = "&Update"
                btn_edit.Text = "&Cancel"
            Else
                txt_category_code.Text = ""
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
            "INSERT INTO [tbl_category] ([cat_code],[cat_desc]) VALUES (@cat_code,@cat_desc)"
            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@cat_code", txt_category_code.Text)
            cmd.Parameters.AddWithValue("@cat_desc", txt_category_description.Text)

            If cmd.ExecuteNonQuery() > 0 Then
                MsgBox("Category Code: " & txt_category_code.Text & " successfully inserted!")
                Return True
            Else
                MsgBox("Category Code: " & txt_category_code.Text & " failed insert!")
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
            "UPDATE [tbl_category]" & _
            " SET [cat_code] = @cat_code, [cat_desc] = @cat_desc" & _
            " WHERE [cat_id] = @cat_id"

            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@cat_desc", txt_category_description.Text)
            cmd.Parameters.AddWithValue("@cat_code", txt_category_code.Text)
            cmd.Parameters.AddWithValue("@cat_id", dgv_brand.Item("cat_id", dgv_brand.CurrentRow.Index).Value)

            If cmd.ExecuteNonQuery() > 0 Then
                MsgBox("Category Code: " & dgv_brand.Item("cat_code", dgv_brand.CurrentRow.Index).Value & " successfully updated!")
                Return True
            Else
                MsgBox("Category Code: " & dgv_brand.Item("cat_code", dgv_brand.CurrentRow.Index).Value & " failed update!")
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
          "DELETE FROM [tbl_category]" & _
      " WHERE cat_code = @cat_code"
            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@cat_code", dgv_brand.Item("cat_code", dgv_brand.CurrentRow.Index).Value)

            If cmd.ExecuteNonQuery() > 0 Then
                MsgBox("Category Code: " & dgv_brand.Item("cat_code", dgv_brand.CurrentRow.Index).Value & " successfully deleted!")
                Return True
            Else
                MsgBox("Category Code: " & dgv_brand.Item("cat_code", dgv_brand.CurrentRow.Index).Value & " failed delete!")
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
End Class