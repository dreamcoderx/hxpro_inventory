Imports System.Data.SqlClient

Public Class frmRentalCheckOutVw1

    Private Sub frm_create_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadRentalHDR()
    End Sub
    Private Function loadRentalHDR() As Boolean
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim sql As String
        con.ConnectionString = ConnectServer()
        Try

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            sql = _
"SELECT [rental_id]" & _
" ,[rental_no]" & _
" ,[delivered_to]" & _
" ,[event]" & _
" ,[pick_del_date]" & _
" ,[location]" & _
" ,[event_from]" & _
" ,[event_to]" & _
" ,[prepared_by]" & _
"  FROM [dbo].[tbl_rental_hdr]"

            cmd = New SqlCommand(sql, con)
            Dim dtRentalHdr As New DataTable

            Dim adpt As New Data.SqlClient.SqlDataAdapter(cmd)
            adpt.Fill(dtRentalHdr)
            dgvRentalHDR.DataSource = dtRentalHdr

            dgvRentalHDR.Columns(0).ReadOnly = True
            dgvRentalHDR.Columns(1).ReadOnly = True
            dgvRentalHDR.Columns(2).ReadOnly = True
            dgvRentalHDR.Columns(3).ReadOnly = True
            dgvRentalHDR.Columns(4).ReadOnly = True
            dgvRentalHDR.Columns(5).ReadOnly = True
            dgvRentalHDR.Columns(6).ReadOnly = True
            dgvRentalHDR.Columns(7).ReadOnly = True
            dgvRentalHDR.Columns(8).ReadOnly = True

            dgvRentalHDR.Columns(0).HeaderText = "RENTAL ID"
            dgvRentalHDR.Columns(1).HeaderText = "RENTAL NO"
            dgvRentalHDR.Columns(2).HeaderText = "DELIVERED TO"
            dgvRentalHDR.Columns(3).HeaderText = "EVENT"
            dgvRentalHDR.Columns(4).HeaderText = "PICK-DEL DATE"
            dgvRentalHDR.Columns(5).HeaderText = "LOCATION"
            dgvRentalHDR.Columns(6).HeaderText = "EVENT FROM"
            dgvRentalHDR.Columns(7).HeaderText = "EVENT TO"
            dgvRentalHDR.Columns(8).HeaderText = "PREPARED BY"

            dgvRentalHDR.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            dgvRentalHDR.AutoResizeColumns()

            dgvRentalHDR.DataSource = dtRentalHdr
            con.Dispose()
            cmd.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            If dgvRentalHDR.CurrentRow.Index > -1 Then
                lblRentalID.Text = (dgvRentalHDR.Item("rental_id", dgvRentalHDR.CurrentRow.Index).Value())
                lblRentalNo.Text = (dgvRentalHDR.Item("rental_no", dgvRentalHDR.CurrentRow.Index).Value())
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If dgvRentalHDR.CurrentRow.Index > -1 Then
                Dim a As System.Windows.Forms.DialogResult
                Dim strRentalID As String = (dgvRentalHDR.Item("rental_id", dgvRentalHDR.CurrentRow.Index).Value())
                a = MessageBox.Show(String.Format("Are you sure you want to delete rental: {0}?", dgvRentalHDR.Item("rental_id", dgvRentalHDR.CurrentRow.Index).Value()), _
                                             "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                If a = DialogResult.Yes Then
                    If deleteRental(strRentalID) Then
                        MsgBox("Rental successfully remove!")
                        loadRentalHDR()
                    Else
                        MsgBox("Rental failed to remove!")
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function deleteRental(ByVal strRentalID As String) As Boolean
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim sql As String = ""
        Try
            con.ConnectionString = ConnectServer()
            con.Open()
            sql = _
"DELETE FROM [tbl_rental_hdr]" & _
" WHERE [rental_id] = @rental_id"
            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@rental_id", strRentalID)
            If cmd.ExecuteNonQuery() > 0 Then
                Return True
            End If
            Return False
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try

    End Function
End Class