Imports System.Data
Imports System.Data.SqlClient
Public Class frm_brand1
    Dim dt As New DataTable
    Private Sub frm_brand_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        load_dgv()
    End Sub
    Private Sub load_dgv()
        Try
            Dim connection As New System.Data.SqlClient.SqlConnection(ConnectServer())
            Dim sql As String
            sql = "SELECT [brand_id], [brand_code], [brand_name] from tbl_brand order by [brand_name]"
            Dim command As New System.Data.SqlClient.SqlCommand(sql, connection)

            Dim adpt As New Data.SqlClient.SqlDataAdapter(command)

            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If
            dt.Clear()
            adpt.Fill(dt)
            dgv_brand.DataSource = dt
            dgv_brand.Columns(0).HeaderText = "ID"
            dgv_brand.Columns(1).HeaderText = "BRAND CODE"
            dgv_brand.Columns(2).HeaderText = "NAME"

            dgv_brand.AutoResizeColumns()




        Catch ex As SqlException
            MessageBox.Show("An error occurred while loading data !" & vbCrLf & ex.ToString())
        Finally

        End Try

    End Sub

    Private Sub btn_new_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_new.Click
        Try
            If btn_new.Text = "&New" Then
                txt_brand.Text = ""
                txt_brand_code.Text = ""
                btn_new.Text = "&Save"
                btn_edit.Text = "&Cancel"
            ElseIf btn_new.Text = "&Save" Then
                If txt_brand.Text <> "" And txt_brand_code.Text <> "" Then
                    If insert_cmd() Then
                        load_dgv()
                        btn_new.Text = "&New"
                        btn_edit.Text = "&Edit"
                    End If
                Else
                    MsgBox("Please Complete Data needed!")
                End If

            ElseIf btn_new.Text = "&Update" Then
                If txt_brand.Text <> "" And txt_brand_code.Text <> "" Then
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
                txt_brand_code.Text = dgv_brand.Item("brand_code", dgv_brand.CurrentRow.Index).Value
                txt_brand.Text = dgv_brand.Item("brand_name", dgv_brand.CurrentRow.Index).Value
                btn_new.Text = "&Update"
                btn_edit.Text = "&Cancel"
            Else
                txt_brand.Text = ""
                txt_brand_code.Text = ""
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
            "INSERT INTO [tbl_brand] ([brand_name],[brand_code]) VALUES (@brand_name, @brand_code)"
            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@brand_name", txt_brand.Text)
            cmd.Parameters.AddWithValue("@brand_code", txt_brand_code.Text)

            If cmd.ExecuteNonQuery() > 0 Then
                MsgBox("Brand: " & txt_brand.Text & " successfully inserted!")
                Return True
            Else
                MsgBox("Brand: " & txt_brand.Text & " failed insert!")
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
            "UPDATE [tbl_brand]" & _
            " SET [brand_name] = @brand_name, [brand_code] = @brand_code" & _
            " WHERE [brand_id] = @brand_id"

            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@brand_name", txt_brand.Text)
            cmd.Parameters.AddWithValue("@brand_code", txt_brand_code.Text)
            cmd.Parameters.AddWithValue("@brand_id", dgv_brand.Item("brand_id", dgv_brand.CurrentRow.Index).Value)

            If cmd.ExecuteNonQuery() > 0 Then
                MsgBox("Brand ID: " & dgv_brand.Item("brand_id", dgv_brand.CurrentRow.Index).Value & " successfully updated!")
                Return True
            Else
                MsgBox("Brand ID: " & dgv_brand.Item("brand_id", dgv_brand.CurrentRow.Index).Value & " failed update!")
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
          "DELETE FROM [tbl_brand]" & _
      " WHERE brand_id = @brand_id"
            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@brand_id", dgv_brand.Item("brand_id", dgv_brand.CurrentRow.Index).Value)

            If cmd.ExecuteNonQuery() > 0 Then
                MsgBox("Brand ID: " & dgv_brand.Item("brand_id", dgv_brand.CurrentRow.Index).Value & " successfully deleted!")
                Return True
            Else
                MsgBox("Brand ID: " & dgv_brand.Item("brand_id", dgv_brand.CurrentRow.Index).Value & " failed delete!")
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

    Private Sub dgv_brand_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub txt_brand_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_brand.TextChanged

    End Sub
End Class