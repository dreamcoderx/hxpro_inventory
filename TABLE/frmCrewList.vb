Imports System.Data
Imports System.Data.SqlClient
Public Class frmCrewList
    Dim dt As New DataTable
    Private Sub frm_brand_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        load_dgv()
        load_cbo_acct()
    End Sub
    Private Sub load_cbo_acct()
        Try
            Dim connection As New SqlConnection(ConnectServer())
            Dim sql As String
            sql = _
            "SELECT [acct_id]" & _
            " ,[acct_desc]" & _
            " FROM [tbl_acct]"
            Dim command As New SqlCommand(sql, connection)

            Dim adpt As New Data.SqlClient.SqlDataAdapter(command)
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If
            Dim dt_cat As New DataTable
            'dt_cat.Clear()
            adpt.Fill(dt_cat)
            'cbo_acct_id.DataSource = dt_cat
            'cbo_acct_id.DisplayMember = "acct_desc"
            'cbo_acct_id.ValueMember = "acct_id"
            'cbo_acct_id.SelectedIndex = -1
        Catch ex As SqlException
            MessageBox.Show("An error occurred while loading data !" & vbCrLf & ex.ToString())
        Finally

        End Try

    End Sub

    Private Sub load_dgv()
        Try
            Using connection As New SqlConnection(ConnectServer())
                Dim sql As String
                sql ="SELECT [crew_id] , [crew_name], [active] FROM [tbl_crew]"
                '"SELECT [crew_id]" & " , [crew_name]" & " FROM [tbl_crew]"
                Dim command As New SqlCommand(sql, connection)
                Dim adpt As New Data.SqlClient.SqlDataAdapter(command)
                If connection.State = ConnectionState.Closed Then
                    connection.Open()
                End If
                dt.Clear()
                adpt.Fill(dt)
            End Using
            dgv_brand.DataSource = dt
            dgv_brand.AutoResizeColumns()
        Catch ex As SqlException
            MessageBox.Show("An error occurred while loading data !" & vbCrLf & ex.ToString())
        Finally

        End Try

    End Sub

    Private Sub btn_new_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_new.Click
        Try
            If btn_new.Text = "&New" Then
                txtCrewID.Enabled = False
                txtCrewID.Text = ""
                txtCrewName.Enabled = True
                txtCrewName.Text = ""
                btn_new.Text = "&Save"
                btn_edit.Text = "&Cancel"
            ElseIf btn_new.Text = "&Save" Then
                If insert_cmd() Then
                    MsgBox("Insert Successfull!")
                    load_dgv()
                    btn_new.Text = "&New"
                    btn_edit.Text = "&Edit"
                Else
                    MsgBox("Insert Failed!")
                End If
            ElseIf btn_new.Text = "&Update" Then
                If txtCrewName.Text <> "" And txtCrewID.Text <> "" Then
                    If update_cmd() Then
                        load_dgv()
                        btn_new.Text = "&New"
                        btn_edit.Text = "&Edit"
                    Else
                        MsgBox("Update Failed!")
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
                txtCrewID.Text = dgv_brand.Item(0, dgv_brand.CurrentRow.Index).Value
                txtCrewID.ReadOnly = True
                txtCrewName.Text = dgv_brand.Item(1, dgv_brand.CurrentRow.Index).Value
                txtCrewName.ReadOnly = False
                txtCrewName.Enabled = True
                CheckBox1.Checked = dgv_brand.Item(2, dgv_brand.CurrentRow.Index).Value
                btn_new.Text = "&Update"
                btn_edit.Text = "&Cancel"
            Else
                txtCrewID.Text = ""
                txtCrewName.Text = ""
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
"INSERT INTO [tbl_crew]" & _
" ([crew_name], [active])" & _
" VALUES" & _
" (@crew_name, @active)"
            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@crew_name", txtCrewName.Text)
            cmd.Parameters.AddWithValue("@active", CheckBox1.Checked)
            If cmd.ExecuteNonQuery > 0 Then
                Return True
            End If
            Return False
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Dispose()
            cmd.Dispose()
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
"UPDATE [tbl_crew]" & _
" SET [crew_name] = @crew_name, [active] = @active" & _
" WHERE crew_id = @crew_id"

            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@crew_id", txtCrewID.Text)
            cmd.Parameters.AddWithValue("@crew_name", txtCrewName.Text)
            cmd.Parameters.AddWithValue("@active", CheckBox1.Checked)

                If cmd.ExecuteNonQuery() > 0 Then
                    Return True
                Else
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

    Private Sub dgv_brand_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_brand.CellContentClick

    End Sub
End Class