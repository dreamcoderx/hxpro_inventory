Imports System.Data
Imports System.Data.SqlClient
Imports System.Xml
Public Class frmRenCheckIn
    Dim dtPartRequest As New DataTable
    Dim dtAssetScanned As New DataTable
    Dim strItemCode As String
    
    Private Sub txtAssetNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAssetNumber.KeyPress
        Dim Keyascii As Integer = AscW(e.KeyChar)
        If Keyascii = 13 And txtAssetNumber.Text <> "" Then
            loadItemDesc()
            If Not (strItemCode = String.Empty) Then
                UpdateCheckIN(strItemCode)
                loadItemCheckIn()
            End If
            txtAssetNumber.Text = ""
            txtAssetNumber.Focus()
        End If
    End Sub

    Private Function loadItemCheckIn() As Boolean
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim sql As String
        con.ConnectionString = ConnectServer()
        Try

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            sql = _
"select a.idx, a.item_code, c.asset_number, d.description" & _
", b.rental_no, a.dt_out, b.event_to, a.dt_in  from tbl_rental_asset a" & _
" left join tbl_rental_hdr b on a.rental_id = b.rental_id" & _
" left join tbl_item c  on a.item_code = c.item_code" & _
" left join tbl_part d on c.part_id = d.part_id where a.dt_in is null"

            cmd = New SqlCommand(sql, con)
            dtAssetScanned.Rows.Clear()
            Dim adpt As New Data.SqlClient.SqlDataAdapter(cmd)
            dtAssetScanned.Rows.Clear()
            adpt.Fill(dtAssetScanned)
            dgvAssetList.DataSource = dtAssetScanned

            dgvAssetList.Columns(0).ReadOnly = True
            dgvAssetList.Columns(1).ReadOnly = True
            dgvAssetList.Columns(2).ReadOnly = True
            dgvAssetList.Columns(3).ReadOnly = True
            dgvAssetList.Columns(4).ReadOnly = True
            dgvAssetList.Columns(5).ReadOnly = True
            dgvAssetList.Columns(6).ReadOnly = True
            dgvAssetList.Columns(7).ReadOnly = True

            dgvAssetList.Columns(0).HeaderText = "ID"
            dgvAssetList.Columns(1).HeaderText = "ITEM CODE"
            dgvAssetList.Columns(2).HeaderText = "ASSET NUMBER"
            dgvAssetList.Columns(3).HeaderText = "DESCRIPTION"
            dgvAssetList.Columns(4).HeaderText = "RENTAL NUMBER"
            dgvAssetList.Columns(5).HeaderText = "DATE OUT"
            dgvAssetList.Columns(6).HeaderText = "EVENT"
            dgvAssetList.Columns(7).HeaderText = "DATE IN"
       
            dgvAssetList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            dgvAssetList.AutoResizeColumns()

            con.Dispose()
            cmd.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Function loadItemDesc() As Boolean
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim sql As String
        con.ConnectionString = ConnectServer()
        Try

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            sql = _
"SELECT a.part_id, b.description, a.item_code FROM tbl_item a" & _
" left join tbl_part b on a.part_id = b.part_id where a.asset_number = '" & txtAssetNumber.Text & "'"

            cmd = New SqlCommand(sql, con)
            Dim dtItemDesc As New DataTable

            Dim adpt As New Data.SqlClient.SqlDataAdapter(cmd)
            adpt.Fill(dtItemDesc)
            If dtItemDesc.Rows.Count = 0 Then
                ' MsgBox("Asset Number not found!")
                lblStatus.ForeColor = Color.Red
                lblStatus.Text = "Asset Number not found!"
                strItemCode = ""
                txtPartID.Text = ""
                txtDescription.Text = ""
                Return False
            Else
                txtPartID.Text = dtItemDesc.Rows(0).Item("part_id").ToString
                txtDescription.Text = dtItemDesc.Rows(0).Item("description").ToString
                strItemCode = dtItemDesc.Rows(0).Item("item_code").ToString
                Return True
            End If
            con.Dispose()
            cmd.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Function UpdateCheckIN(ByVal strItemCode As String) As Boolean
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim sql As String = ""
        Try
            con.ConnectionString = ConnectServer()
            con.Open()

            sql = _
"SELECT count(*) FROM [tbl_rental_asset]" & _
" WHERE  [item_code] = @item_code and [dt_in] is null"

            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@item_code", strItemCode)
            Dim intScalar As Integer
            intScalar = cmd.ExecuteScalar

            If intScalar > 0 Then
                sql = _
"UPDATE [tbl_rental_asset]" & _
" SET" & _
" [dt_in] = @dt_in" & _
" ,[user_id_in] = @user_id_in" & _
" WHERE  [item_code] = @item_code and [dt_in] is null"

                cmd = New SqlCommand(sql, con)
                cmd.Parameters.AddWithValue("@item_code", strItemCode)
                cmd.Parameters.AddWithValue("@dt_in", Date.Now)
                cmd.Parameters.AddWithValue("@user_id_in", user_id)
                If cmd.ExecuteNonQuery() > 0 Then
                    lblStatus.ForeColor = Color.Green
                    lblStatus.Text = "Check in Successfull!"
                    Return True
                Else
                    lblStatus.ForeColor = Color.Red
                    lblStatus.Text = "Check in  Failed!"
                    Return False
                End If
            Else
                lblStatus.ForeColor = Color.Red
                lblStatus.Text = "Item is not scanned for check out! Invalid Check In!"
                Return False
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try

    End Function

    Private Sub frmRenCheckIn_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadItemCheckIn()
    End Sub

    Private Sub txtAssetNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAssetNumber.TextChanged

    End Sub
End Class