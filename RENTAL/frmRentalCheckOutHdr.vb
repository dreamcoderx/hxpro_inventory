Imports System.Data
Imports System.Data.SqlClient
Imports System.Xml
Public Class frmRentalCheckOutHdr
    'Dim dt_part As New DataTable
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
            dgvRentalHDR.Columns(1).HeaderText = "RENTAL NUMBER"
            dgvRentalHDR.Columns(2).HeaderText = "DELIVERED TO"
            dgvRentalHDR.Columns(3).HeaderText = "EVENT"
            dgvRentalHDR.Columns(4).HeaderText = "PICK-DEL DATE"
            dgvRentalHDR.Columns(5).HeaderText = "LOCATION"
            dgvRentalHDR.Columns(6).HeaderText = "EVENT FROM"
            dgvRentalHDR.Columns(7).HeaderText = "EVENT TO"
            dgvRentalHDR.Columns(8).HeaderText = "PREPARED BY"

            dgvRentalHDR.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            dgvRentalHDR.AutoResizeColumns()


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
                lblRentalNumber.Text = (dgvRentalHDR.Item("rental_no", dgvRentalHDR.CurrentRow.Index).Value())
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If dgvRentalHDR.CurrentRow.Index > -1 Then
            lblRentalID.Text = (dgvRentalHDR.Item("rental_id", dgvRentalHDR.CurrentRow.Index).Value())
            Me.DialogResult = System.Windows.Forms.DialogResult.Yes
            '(dgvRentalLine.Item("part_id", dgvRentalLine.CurrentRow.Index).Value())
        End If
    End Sub
End Class