Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Public Class LoginForm1

    Private Sub log_in()
        Dim connection As New System.Data.SqlClient.SqlConnection(ConnectServer())
        Dim sql As String = _
        "select user_name, acct_id, password from tbl_user where user_id = '" & txt_user_id.Text & "'"
        Dim command As New System.Data.SqlClient.SqlCommand(sql, connection)
        Dim dt As New DataTable
        Dim adpt As New Data.SqlClient.SqlDataAdapter(command)
        Try
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If
            adpt.Fill(dt)
            If dt.Rows.Count > 0 Then
                If Decrypt(dt(0).Item("password")) = txt_password.Text Then
                    frm_main.Text = "HXPro - Barcode Inventory - " & dt(0).Item("user_name")
                    user_id = txt_user_id.Text
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    Me.Close()
                Else
                    MsgBox("Invalid Password!")
                End If

                
                'If dt(0).Item(0) = "1" Then
                'Dim Main As New frmMain
                'Main.Show()
                'Me.Hide()
                ' Else
                '    MsgBox("Account should be Admin!")
                '   Exit Try
                'End If
            Else
                MsgBox("Invalid UserID!")
            End If
            connection.Close()
        Catch ex As SqlException
            MessageBox.Show("An error occurred while loading data !" & vbCrLf & ex.ToString())
        Finally
            connection.Dispose()
        End Try

    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

  
    Private Sub txt_user_id_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_user_id.TextChanged

    End Sub

    Private Sub txt_password_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_password.TextChanged

    End Sub

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        log_in()
        'MsgBox(Encrypt(txt_password.Text))
    End Sub
End Class
