Imports System.Data
Imports System.Data.SqlClient
Imports System.Xml
Public Class frmRentalAlarm


    Private Function loadItemCheckIn() As Integer
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim sql As String
        Dim dtAssetScanned As New DataTable
        Dim dtcount As Integer = 0
        con.ConnectionString = ConnectServer()
        Try

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            sql = _
String.Format("select a.idx" & _
", a.item_code" & _
", c.asset_number" & _
", d.description" & _
", b.rental_no" & _
", b.event" & _
", a.dt_out" & _
", b.event_to" & _
" from tbl_rental_asset a" & _
" left join tbl_rental_hdr b on a.rental_id = b.rental_id" & _
" left join tbl_item c  on a.item_code = c.item_code" & _
" left join tbl_part d on c.part_id = d.part_id " & _
" where a.dt_in is null" & _
" and dateadd(HH, {0} ,b.event_to) <= GETDATE()" & _
" order by b.event_to", txtHours.Text)

            cmd = New SqlCommand(sql, con)
            Dim adpt As New Data.SqlClient.SqlDataAdapter(cmd)
            dtAssetScanned.Rows.Clear()
            adpt.Fill(dtAssetScanned)
            dtcount = dtAssetScanned.Rows.Count

            dgvAssetList.DataSource = dtAssetScanned

            dgvAssetList.Columns(0).HeaderText = "ID"
            dgvAssetList.Columns(1).HeaderText = "ITEM CODE"
            dgvAssetList.Columns(2).HeaderText = "ASSET NUMBER"
            dgvAssetList.Columns(3).HeaderText = "DESCRIPTION"
            dgvAssetList.Columns(4).HeaderText = "RENTAL NUMBER"
            dgvAssetList.Columns(5).HeaderText = "EVENT"
            dgvAssetList.Columns(6).HeaderText = "DATE OUT"
            dgvAssetList.Columns(7).HeaderText = "EVENT TO"
            
            dgvAssetList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            dgvAssetList.AutoResizeColumns()

            con.Dispose()
            cmd.Dispose()
            dtAssetScanned.Dispose()

            Return dtcount
        Catch ex As Exception
            MsgBox(ex.Message)
            Return dtcount
        End Try
    End Function

   
    Private Sub frmRenCheckIn_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtHours.Text = Settings.Get("HourOver")
        If loadItemCheckIn() > 0 Then
            timerAlarm.Enabled = True
        End If
    End Sub

    Private Sub txtHours_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHours.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If (Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) Then
                e.Handled = False
            End If
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Settings.Set("HourOver", txtHours.Text)
        Settings.Update()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        timerAlarm.Enabled = False
        txtHours.Text = Settings.Get("HourOver")
        If loadItemCheckIn() > 0 Then
            timerAlarm.Enabled = True
        End If
    End Sub

    Private Sub timerAlarm_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timerAlarm.Tick
        Dim Sound As New System.Media.SoundPlayer()
        Sound.SoundLocation = Path & "\tututut.wav"
        Sound.Load()
        Sound.Play()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        timerAlarm.Enabled = False
    End Sub
End Class