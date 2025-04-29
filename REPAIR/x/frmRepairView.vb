Imports System.Data.SqlClient

Public Class frmRepairView

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
"SELECT [repair_number]" & _
", [company]" & _
", [address]" & _
", [date]" & _
", [created_by]" & _
" FROM [tbl_repair_hdr]"

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

            dgvRentalHDR.Columns(0).HeaderText = "REPAIR NUMBER"
            dgvRentalHDR.Columns(1).HeaderText = "COMPANY"
            dgvRentalHDR.Columns(2).HeaderText = "ADDRESS"
            dgvRentalHDR.Columns(3).HeaderText = "DATE"
            dgvRentalHDR.Columns(4).HeaderText = "CREATED BY"

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
                Dim a As New frmRepairLine
                a.txtRepairNumber.Text = (dgvRentalHDR.Item("repair_number", dgvRentalHDR.CurrentRow.Index).Value())
                a.Show()
                Me.Dispose()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If dgvRentalHDR.CurrentRow.Index > -1 Then
                Dim a As System.Windows.Forms.DialogResult
                Dim strRentalID As String = (dgvRentalHDR.Item("repair_number", dgvRentalHDR.CurrentRow.Index).Value())
                a = MessageBox.Show(String.Format("Are you sure you want to repair number: {0}?", dgvRentalHDR.Item("repair_number", dgvRentalHDR.CurrentRow.Index).Value()), _
                                             "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                If a = Windows.Forms.DialogResult.Yes Then
                    If deleteRental(strRentalID) Then
                        MsgBox("Repair Number successfully remove!")
                        loadRentalHDR()
                    Else
                        MsgBox("Repair Number failed to remove!")
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
"DELETE FROM [tbl_repair_hdr]" & _
" WHERE [repair_number] = @repair_number"
            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@repair_number", strRentalID)
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