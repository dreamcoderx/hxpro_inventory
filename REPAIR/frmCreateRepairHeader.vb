Imports System.Data
Imports System.Data.SqlClient
Imports System.Xml
Public Class frmCreateRepairHeader
    Dim PickDelDT As DateTime

    Private Function CreateCmd() As Boolean
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim sql As String
        con.ConnectionString = ConnectServer()
        Try

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            sql = "select count([repair_number]) from [tbl_repair_hdr] where repair_number = @repair_number"

            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@repair_number", txtRepairNo.Text)
            If (cmd.ExecuteScalar) <> 0 Then
                MsgBox("Repair No. already exist!")
                Return False
            End If

            sql = _
" INSERT INTO [tbl_repair_hdr]" & _
" ([repair_number]" & _
" ,[company]" & _
" ,[address]" & _
" ,[date]" & _
" ,[created_by])" & _
" VALUES" & _
" (@repair_number" & _
" ,@company" & _
" ,@address" & _
" ,@date" & _
" ,@created_by)"

            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@repair_number", txtRepairNo.Text)
            cmd.Parameters.AddWithValue("@company", txtCompany.Text)
            cmd.Parameters.AddWithValue("@address", txtAddress.Text)
            cmd.Parameters.AddWithValue("@date", dtDate.Value)
            cmd.Parameters.AddWithValue("@created_by", user_id)

            If cmd.ExecuteNonQuery > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            con.Dispose()
            cmd.Dispose()
        End Try

    End Function



    Private Sub btnCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreate.Click
        If txtRepairNo.Text = String.Empty Or txtCompany.Text = String.Empty Then
            MsgBox("Please Complete all needed data!")
            Exit Sub
        End If

        If CreateCmd() Then
            Dim a As New frmRepairLine
            a.txtRepairNumber.Text = txtRepairNo.Text
            a.Show()
            Me.Dispose()
            ' Me.DialogResult = System.Windows.Forms.DialogResult.OK

        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

End Class