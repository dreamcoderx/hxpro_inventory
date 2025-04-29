Imports System.Data
Imports System.Data.SqlClient
Public Class frmUser
    Dim dt As New DataTable
    Private Sub load_cbo_acct()
        Try
            Dim connection As New System.Data.SqlClient.SqlConnection(ConnectServer())
            Dim sql As String
            sql = _
            "SELECT [acct_id]" & _
            " ,[acct_desc]" & _
            " FROM [tbl_acct]"
            Dim command As New System.Data.SqlClient.SqlCommand(sql, connection)

            Dim adpt As New Data.SqlClient.SqlDataAdapter(command)
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If
            Dim dt_cat As New DataTable
            'dt_cat.Clear()
            adpt.Fill(dt_cat)
            cbo_acct_id.DataSource = dt_cat
            cbo_acct_id.DisplayMember = "acct_desc"
            cbo_acct_id.ValueMember = "acct_id"
            cbo_acct_id.SelectedIndex = -1
        Catch ex As SqlException
            MessageBox.Show("An error occurred while loading data !" & vbCrLf & ex.ToString())
        Finally

        End Try

    End Sub
    Private Sub load_dgv()
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim connection As New System.Data.SqlClient.SqlConnection(ConnectServer())
            Dim sql As String
            sql = _
            "SELECT a.user_id, a.user_name, b.acct_desc, a.active, a.updated_by, a.last_update  FROM tbl_user a" & _
" left join tbl_acct b on a.acct_id = b.acct_id"
            Dim command As New System.Data.SqlClient.SqlCommand(sql, connection)
            Dim adpt As New Data.SqlClient.SqlDataAdapter(command)
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If
            dt.Clear()
            adpt.Fill(dt)
            dgvUser.DataSource = dt

            dgvUser.Columns(0).HeaderText = "USER ID"
            dgvUser.Columns(1).HeaderText = "USER NAME"
            dgvUser.Columns(2).HeaderText = "ACCOUNT"
            dgvUser.Columns(3).HeaderText = "ACTIVE"
            dgvUser.Columns(4).HeaderText = "LAST TOUCHED"
            dgvUser.Columns(5).HeaderText = "DATE UPDATE"

            dgvUser.AutoResizeColumns()
            dgvUser.Refresh()
        Catch ex As SqlException
            MessageBox.Show("An error occurred while loading data !" & vbCrLf & ex.ToString())
        Finally
            Cursor.Current = Cursors.Default
        End Try

    End Sub

    Private Sub btn_new_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_new.Click
        Try
            If btn_new.Text = "&New" Then
                txt_user_id.Enabled = True
                txt_user_name.Enabled = True
                txt_password.Enabled = True
                txt_confirm_password.Enabled = True
                cbo_acct_id.Enabled = True
                btn_new.Text = "&Save"
                btn_edit.Text = "&Cancel"
            ElseIf btn_new.Text = "&Save" Then
                If (txt_password.Text = txt_confirm_password.Text) Then
                    If txt_user_name.Text <> "" And txt_user_id.Text <> "" And txt_password.Text <> "" And cbo_acct_id.SelectedIndex >= 0 Then
                        If insert_cmd() Then
                            load_dgv()
                            btn_new.Text = "&New"
                            btn_edit.Text = "&Edit"
                        End If
                    Else
                        MsgBox("Please Complete Data needed!")
                    End If
                Else
                    MsgBox("Password is not Equal!")
                End If

            ElseIf btn_new.Text = "&Update" Then
                If txt_user_name.Text <> "" And txt_user_id.Text <> "" Then
                    If update_cmd() Then
                        load_dgv()
                        btn_new.Text = "&New"
                        btn_edit.Text = "&Edit"
                    End If
                Else
                    MsgBox("Please Complete Needed Data!")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub btn_edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_edit.Click
        Try
            If btn_edit.Text = "&Edit" Then
                txt_user_id.Text = dgvUser.Item(0, dgvUser.CurrentRow.Index).Value
                txt_user_id.ReadOnly = True
                txt_user_name.ReadOnly = False
                txt_old_password.Enabled = True
                txt_password.Enabled = True
                txt_confirm_password.Enabled = True
                cbo_acct_id.Enabled = True
                txt_user_name.Text = dgvUser.Item(1, dgvUser.CurrentRow.Index).Value
                txt_user_name.Enabled = True
                btn_new.Text = "&Update"
                btn_edit.Text = "&Cancel"
            Else
                txt_user_id.Text = ""
                txt_user_name.Text = ""
                txt_old_password.Text = ""
                txt_password.Text = ""
                txt_confirm_password.Text = ""
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
            "INSERT INTO [tbl_user]" & _
           "([user_id]" & _
           ",[user_name]" & _
           ",[password]" & _
           ",[acct_id] ,[active])" & _
            "VALUES" & _
           "(@user_id" & _
           ",@user_name" & _
           ",@password" & _
           ", @acct_id, @active)"
            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@user_id", txt_user_id.Text)
            cmd.Parameters.AddWithValue("@user_name", txt_user_name.Text)
            cmd.Parameters.AddWithValue("@password", Encrypt(txt_password.Text))
            cmd.Parameters.AddWithValue("@acct_id", cbo_acct_id.SelectedValue)
            cmd.Parameters.AddWithValue("@active", CheckBox1.Checked)

            If cmd.ExecuteNonQuery() > 0 Then
                MsgBox("User Name: " & txt_user_name.Text & " successfully inserted!")
                Return True
            Else
                MsgBox("User Name: " & txt_user_name.Text & " failed insert!")
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
         "select password from tbl_user where user_id = @user_id"
            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@user_id", txt_user_id.Text)

            If Decrypt(cmd.ExecuteScalar) = txt_old_password.Text Then
                sql = _
           "UPDATE [tbl_user]" & _
           " SET [user_name] = @user_name" & _
           " ,[password] = @password" & _
           " ,[acct_id] = @acct_id, [active] = @active" & _
           " WHERE [user_id] = @user_id"

                cmd = New SqlCommand(sql, con)
                cmd.Parameters.AddWithValue("@user_id", txt_user_id.Text)
                cmd.Parameters.AddWithValue("@user_name", txt_user_name.Text)
                cmd.Parameters.AddWithValue("@acct_id", cbo_acct_id.SelectedValue)
                cmd.Parameters.AddWithValue("@password", Encrypt(txt_password.Text))
                cmd.Parameters.AddWithValue("@active", CheckBox1.Checked)

                If cmd.ExecuteNonQuery() > 0 Then
                    MsgBox("USER ID: " & txt_user_id.Text & " successfully updated!")
                    Return True
                Else
                    MsgBox("USER ID: " & txt_user_id.Text & " failed update!")
                    Return False
                End If
            Else
                MsgBox("Old Password is incorrect!")
            End If

            con.Dispose()
            cmd.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function

    Private Function update_user_active(ByVal active As Boolean, ByVal vuser_id As String) As Boolean
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim sql As String
        con.ConnectionString = ConnectServer()
        Try
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            sql = _
       "UPDATE [tbl_user]" & _
       " SET [active] = @active" & _
       " , [updated_by] = @updated_by" & _
       " WHERE [user_id] = @user_id"

            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@user_id", vuser_id)
            cmd.Parameters.AddWithValue("@updated_by", user_id)
            cmd.Parameters.AddWithValue("@active", active)

            If cmd.ExecuteNonQuery() > 0 Then
                Return True
            Else
                Return False
            End If
            con.Dispose()
            cmd.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
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
          "DELETE FROM [tbl_brand]" & _
      " WHERE brand_id = @brand_id"
            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@brand_id", dgvUser.Item("brand_id", dgvUser.CurrentRow.Index).Value)

            If cmd.ExecuteNonQuery() > 0 Then
                MsgBox("Brand ID: " & dgvUser.Item("brand_id", dgvUser.CurrentRow.Index).Value & " successfully deleted!")
                Return True
            Else
                MsgBox("Brand ID: " & dgvUser.Item("brand_id", dgvUser.CurrentRow.Index).Value & " failed delete!")
                Return False
            End If
            con.Dispose()
            cmd.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function

    Private Sub DELETE()
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

    Private Sub dgv_brand_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvUser.CellContentClick

    End Sub

    Private Sub frmUser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        load_dgv()
        load_cbo_acct()
    End Sub

    Private Sub dgvUser_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvUser.CellMouseClick
        Try

            If e.Button = MouseButtons.Right And dgvUser.CurrentRow.Index > -1 Then
                cmdAddEditDel.Show(MousePosition.X, MousePosition.Y)
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub INSERTToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles INSERTToolStripMenuItem.Click
        If dgvUser.CurrentRow.Index > -1 Then
            If MessageBox.Show("SET ACTIVE USER?", "ACTIVE USER", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = DialogResult.Cancel Then
                Exit Sub
            End If
            If update_user_active(True, dgvUser.Item("user_id", dgvUser.CurrentRow.Index).Value()) Then
                MessageBox.Show("UPDATE SUCCESS!")
                load_dgv()
            Else
                MessageBox.Show("UPDATE FAILED")
            End If
        End If
    End Sub

    Private Sub DELETEToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DELETEToolStripMenuItem.Click
        If dgvUser.CurrentRow.Index > -1 Then
            If MessageBox.Show("SET IN-ACTIVE USER?", "ACTIVE USER", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = DialogResult.Cancel Then
                Exit Sub
            End If
            If update_user_active(False, dgvUser.Item("user_id", dgvUser.CurrentRow.Index).Value()) Then
                MessageBox.Show("UPDATE SUCCESS!")
                load_dgv()
            Else
                MessageBox.Show("UPDATE FAILED")
            End If
        End If
    End Sub
End Class