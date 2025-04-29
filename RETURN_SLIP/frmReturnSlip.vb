Imports System.Data
Imports System.Data.SqlClient
Imports System.Xml
Public Class frmReturnSlip
    Dim PickDelDT As DateTime
    Dim eventFrom As DateTime
    Dim evenTo As DateTime


    Private Function CreateCmd() As Boolean
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim sql As String
        con.ConnectionString = ConnectServer()
        Try

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            sql = "select count(rs_no) from tbl_return_slip_hdr where rs_no = @rs_no"

            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@rs_no", txtRentalSlip.Text)
            If (cmd.ExecuteScalar) <> 0 Then
                MsgBox("Return Slip No. already exist!")
                Return False
            End If

            sql = _
"INSERT INTO [tbl_return_slip_hdr]" & _
" ([rs_no]" & _
" ,[returned_to]" & _
" ,[date]" & _
" ,[prepared_by])" & _
" VALUES" & _
" (@rs_no" & _
" , @returned_to" & _
" , @date" & _
" , @prepared_by)"

            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@rs_no", txtRentalSlip.Text)
            cmd.Parameters.AddWithValue("@returned_to", txtReturnedTo.Text)
            cmd.Parameters.AddWithValue("@date", dtDate.Value)
            cmd.Parameters.AddWithValue("@prepared_by", user_id)
            If cmd.ExecuteNonQuery > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Dispose()
            cmd.Dispose()
        End Try

    End Function



    Private Sub btnCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreate.Click
        If txtRentalSlip.Text = String.Empty Or txtReturnedTo.Text = String.Empty Then
            MsgBox("Please Complete all needed data!")
            Exit Sub
        End If


        If CreateCmd() Then
            'Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Dim a As New frmReturnSlipLine
            a.txtReturnSlipNo.Text = txtRentalSlip.Text
            a.Show()
            Me.Dispose()
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub


End Class