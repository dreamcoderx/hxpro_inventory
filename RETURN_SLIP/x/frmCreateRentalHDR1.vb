Imports System.Data
Imports System.Data.SqlClient
Imports System.Xml
Public Class frmCreateRentalHDR1
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
            sql = "select count(rental_no) from tbl_rental_hdr where rental_no = @rental_no"

            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@rental_no", txtRentalNO.Text)
            If (cmd.ExecuteScalar) <> 0 Then
                MsgBox("Rental No. already exist!")
                Return False
            End If

            sql = _
"INSERT INTO [tbl_rental_hdr]" & _
" ([rental_no]" & _
" ,[delivered_to]" & _
" ,[event]" & _
" ,[pick_del_date]" & _
" ,[location]" & _
" ,[event_from]" & _
" ,[event_to]" & _
" ,[prepared_by])" & _
" VALUES" & _
" (@rental_no" & _
" ,@delivered_to" & _
" ,@event" & _
" ,@pick_del_date" & _
" ,@location" & _
" ,@event_from" & _
" ,@event_to" & _
" ,@prepared_by)"

            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@rental_no", txtRentalNO.Text)
            cmd.Parameters.AddWithValue("@delivered_to", txtDeliverTo.Text)
            cmd.Parameters.AddWithValue("@event", txtEvent.Text)
            cmd.Parameters.AddWithValue("@pick_del_date", dtPickDelDate.Value)
            cmd.Parameters.AddWithValue("@location", txtLocation.Text)
            cmd.Parameters.AddWithValue("@event_from", dtEventFrom.Value)
            cmd.Parameters.AddWithValue("@event_to", dtEventTo.Value)
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
        If txtRentalNO.Text = String.Empty Or txtDeliverTo.Text = String.Empty Then
            MsgBox("Please Complete all needed data!")
            Exit Sub
        End If

        If Date.Compare(dtPickDelDate.Value, dtEventFrom.Value) > 0 Then
            MsgBox("Pick Date must not be greater than Event From!")
            Exit Sub
        End If

        If Date.Compare(dtEventFrom.Value, dtEventTo.Value) > 0 Then
            MsgBox("Event Date from  must not be greater than Event Date To!")
            Exit Sub
        End If

        If CreateCmd() Then
            Me.DialogResult = System.Windows.Forms.DialogResult.OK

        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub dtPickDelDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtPickDelDate.ValueChanged
        PickDelDT = dtPickDelDate.Value
        dtTime1.Value = PickDelDT
    End Sub

    Private Sub dtTime1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtTime1.ValueChanged
        PickDelDT = dtTime1.Value
        dtPickDelDate.Value = PickDelDT
    End Sub


    Private Sub dtpEventFrom_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpEventFrom.ValueChanged
        eventFrom = dtpEventFrom.Value
        dtEventFrom.Value = eventFrom
    End Sub

    Private Sub dtEventFrom_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtEventFrom.ValueChanged
        eventFrom = dtEventFrom.Value
        dtpEventFrom.Value = eventFrom
    End Sub

    Private Sub dtpEventTo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpEventTo.ValueChanged
        evenTo = dtpEventTo.Value
        dtEventTo.Value = evenTo
    End Sub

    Private Sub dtEventTo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtEventTo.ValueChanged
        evenTo = dtEventTo.Value
        dtpEventTo.Value = evenTo
    End Sub
End Class