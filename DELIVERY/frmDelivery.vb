Imports System.Data
Imports System.Data.SqlClient
Imports System.Xml
Public Class frmDelivery
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
            sql = "select count(dr_no) from tbl_delivery_hdr where dr_no = @dr_no"

            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@dr_no", txtDeliveryNo.Text)
            If (cmd.ExecuteScalar) <> 0 Then
                MsgBox("Delivery No. already exist!")
                Return False
            End If

            sql = _
"INSERT INTO [tbl_delivery_hdr]" & _
"([dr_no]" & _
",[delivery_to]" & _
",[address]" & _
",[date]" & _
",[prepared_by])" & _
"VALUES" & _
"(@dr_no" & _
",@delivery_to" & _
",@address" & _
",@date" & _
",@prepared_by)"

            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@dr_no", txtDeliveryNo.Text)
            cmd.Parameters.AddWithValue("@delivery_to", txtDeliveryTo.Text)
            cmd.Parameters.AddWithValue("@address", txtAddress.Text)
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
        If txtDeliveryNo.Text = String.Empty Or txtDeliveryTo.Text = String.Empty Then
            MsgBox("Please Complete all needed data!")
            Exit Sub
        End If


        If CreateCmd() Then
            'Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Dim a As New frmDeliveryLine
            a.txtDR_No.Text = txtDeliveryNo.Text
            a.Show()
            Me.Dispose()
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub


End Class