Imports System.Data.SqlClient
Imports Excel = Microsoft.Office.Interop.Excel

Public Class frmInventoryScan

    Dim dtPartRequest As New DataTable
    Dim strItemCode As String

    Private Sub frm_create_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadScanned()
    End Sub

    Private Sub txtAssetNumber_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAssetNumber.KeyDown

    End Sub

    Private Sub txtAssetNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAssetNumber.KeyPress
        Dim Keyascii As Integer = AscW(e.KeyChar)
        If Keyascii = 13 And txtAssetNumber.Text <> "" Then
            If loadItemDesc() Then
                timerAlarm.Enabled = True
                If cbAutoSave.Checked Then
                    btnSave_Click(Nothing, Nothing)
                    txtAssetNumber.Focus()
                    txtAssetNumber.SelectAll()
                Else
                    txtRemarks.Focus()
                End If
            Else
                timerAlarm.Enabled = True
                lblStatus.ForeColor = Color.Red
                lblStatus.Text = "Asset Number not found!"
                txtAssetNumber.Focus()
                txtAssetNumber.SelectAll()
            End If
        End If
    End Sub

    Private Function deleteItem(ByVal strItemCode As String) As Boolean
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Try
            con.ConnectionString = ConnectServer()
            con.Open()
            If cmd.ExecuteNonQuery() > 0 Then
                Return True
            End If
            Return False
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
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
"SELECT a.part_id, b.description, b.model_no, c.brand_name, a.item_code FROM tbl_item a" & _
" left join tbl_part b on a.part_id = b.part_id" & _
" left join tbl_brand c on b.brand_id = c.brand_id" & _
" where a.asset_number = '" & txtAssetNumber.Text & "'"

            cmd = New SqlCommand(sql, con)
            Dim dtItemDesc As New DataTable

            Dim adpt As New Data.SqlClient.SqlDataAdapter(cmd)
            adpt.Fill(dtItemDesc)
            If dtItemDesc.Rows.Count = 0 Then
                strItemCode = ""
                txtPartID.Text = ""
                txtDescription.Text = ""
                txtModel.Text = ""
                txtBrand.Text = ""
                Return False
            Else
                txtPartID.Text = dtItemDesc.Rows(0).Item("part_id").ToString
                txtDescription.Text = dtItemDesc.Rows(0).Item("description").ToString
                txtModel.Text = dtItemDesc.Rows(0).Item("model_no").ToString
                txtBrand.Text = dtItemDesc.Rows(0).Item("brand_name").ToString
                strItemCode = dtItemDesc.Rows(0).Item("item_code").ToString
                Return True
            End If
            con.Dispose()
            cmd.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Function InsertStatus(ByVal strItemCode As String) As Boolean
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim sql As String = ""
        Dim bolStatus As Boolean
        Try

            con.ConnectionString = ConnectServer()
            con.Open()


            If rbGood.Checked Then
                bolStatus = True
            Else
                bolStatus = False
            End If
            sql = _
"INSERT INTO [tbl_status]" & _
" ([item_code]" & _
" ,[status]" & _
" ,[date]" & _
" ,[scanned_by]" & _
" ,[remarks])" & _
" VALUES" & _
" (@item_code " & _
" ,@status" & _
" , sysdatetime()" & _
" ,@scanned_by" & _
" ,@remarks)"
            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@status", bolStatus)
            cmd.Parameters.AddWithValue("@item_code", strItemCode)
            cmd.Parameters.AddWithValue("@remarks", txtRemarks.Text)
            ' cmd.Parameters.AddWithValue("@date", Date.Now)
            cmd.Parameters.AddWithValue("@scanned_by", user_id)

            If cmd.ExecuteNonQuery() > 0 Then
                Return True
            End If
            Return False
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Private Function SrcStatusHrs(ByVal vHours As String, ByVal vItemCode As String) As Boolean
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim sql As String = ""
        Try
            con.ConnectionString = ConnectServer()
            con.Open()
            sql = _
"select COUNT(*) from v_item_code_status" & _
" WHERE item_code = @item_code" & _
" and (date <= sysdatetime() " & _
" and date >= dateadd(HH, @hrs, sysdatetime()))"
            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@hrs", Convert.ToInt32(vHours) * (-1))
            cmd.Parameters.AddWithValue("@item_code", vItemCode)

            If cmd.ExecuteScalar = 0 Then
                Return True
            End If
            Return False
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            con.Dispose()
            cmd.Dispose()
        End Try
    End Function

    Private Function checkOut() As Boolean
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim sql As String = ""
        Try

            con.ConnectionString = ConnectServer()
            con.Open()
            sql = _
    "INSERT INTO [tbl_rental_asset]" & _
    " ([item_code]" & _
    " ,[rental_id]" & _
    " ,[dt_out], [user_id_out])" & _
    " VALUES" & _
    " (@item_code" & _
    " ,@rental_id" & _
    " ,@dt_out, @user_id_out)"
            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@item_code", strItemCode)
            cmd.Parameters.AddWithValue("@rental_id", "xxxx")
            cmd.Parameters.AddWithValue("@dt_out", Date.Now)
            cmd.Parameters.AddWithValue("@user_id_out", user_id)
            If cmd.ExecuteNonQuery() > 0 Then
                Return True
            End If
            Return False
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try

    End Function

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If dgvAssetList.CurrentRow.Index > -1 Then
            Dim a As System.Windows.Forms.DialogResult
            Dim strItemCode As String = (dgvAssetList.Item("item_code", dgvAssetList.CurrentRow.Index).Value())
            a = MessageBox.Show(String.Format("Are you sure you want to remove asset number: {0}?", dgvAssetList.Item("asset_number", dgvAssetList.CurrentRow.Index).Value()), _
                                         "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            If a = DialogResult.Yes Then
                If deleteItem(strItemCode) Then
                    MsgBox("Item successfully remove!")
                    'loadItemScanned()
                Else
                    MsgBox("Item failed to remove!")
                End If
            End If
        End If
    End Sub

    Private Function LoadScanned() As Boolean
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim sql As String
        con.ConnectionString = ConnectServer()
        Try

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            sql = _
"SELECT [item_code]" & _
",[asset_number]" & _
",[serial_number]" & _
",[description]" & _
",[model_no]" & _
",[brand_name]" & _
",[status]" & _
",[remarks]" & _
",[date]" & _
" FROM [v_inventory_status]" & _
" where ([date] <= sysdatetime()" & _
" and date >= dateadd(HH, -24, sysdatetime()))"

            '" WHERE [date] between '" & Date.Now.AddDays(-1) & "' AND '" & Date.Now & "' order by [date] desc"

            cmd = New SqlCommand(sql, con)

            Dim adpt As New Data.SqlClient.SqlDataAdapter(cmd)
            dtPartRequest.Rows.Clear()
            adpt.Fill(dtPartRequest)
            dgvAssetList.DataSource = dtPartRequest

            dgvAssetList.Columns(0).ReadOnly = True
            dgvAssetList.Columns(1).ReadOnly = True
            dgvAssetList.Columns(2).ReadOnly = True
            dgvAssetList.Columns(3).ReadOnly = True
            dgvAssetList.Columns(4).ReadOnly = True
            dgvAssetList.Columns(5).ReadOnly = True
            dgvAssetList.Columns(6).ReadOnly = True
            dgvAssetList.Columns(7).ReadOnly = True
            dgvAssetList.Columns(8).ReadOnly = True

            dgvAssetList.Columns(0).HeaderText = "ITEM CODE"
            dgvAssetList.Columns(1).HeaderText = "ASSET NUMBER"
            dgvAssetList.Columns(2).HeaderText = "SERIAL NUMBER"
            dgvAssetList.Columns(3).HeaderText = "DESCRIPTION"
            dgvAssetList.Columns(4).HeaderText = "MODEL"
            dgvAssetList.Columns(5).HeaderText = "BRAND NAME"
            dgvAssetList.Columns(6).HeaderText = "STATUS"
            dgvAssetList.Columns(7).HeaderText = "REMARKS"
            dgvAssetList.Columns(8).HeaderText = "DATE"

            dgvAssetList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            dgvAssetList.AutoResizeColumns()
            con.Dispose()
            cmd.Dispose()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function


    Private Sub rbGood_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbGood.CheckedChanged
        If rbGood.Checked Then
            rbDefective.Checked = False
        Else
            rbDefective.Checked = True
        End If
    End Sub

    Private Sub rbBad_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbDefective.CheckedChanged
        If rbDefective.Checked Then
            rbGood.Checked = False
        Else
            rbGood.Checked = True
        End If
    End Sub


    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If strItemCode <> "" Or txtDescription.Text <> "" Then
            If txtHours.Text <> "" Then
                If SrcStatusHrs(txtHours.Text, strItemCode) = False Then
                    timerAlarm.Enabled = True
                    lblStatus.ForeColor = Color.Red
                    lblStatus.Text = "Already scan! Check your Save Limit(HOURS)! ASSET:" & txtAssetNumber.Text
                    Exit Sub
                End If
            End If

            If InsertStatus(strItemCode) Then
                timerAlarm.Enabled = False
                lblStatus.ForeColor = Color.Green
                lblStatus.Text = "Save: Successfull! AssetNumber:" & txtAssetNumber.Text
                LoadScanned()
                txtAssetNumber.Text = ""
                txtAssetNumber.Focus()
            Else
                timerAlarm.Enabled = True
                lblStatus.ForeColor = Color.Red
                lblStatus.Text = "Save: Failed! AssetNumber:" & txtAssetNumber.Text
            End If
        Else
            timerAlarm.Enabled = True
            lblStatus.ForeColor = Color.Red
            lblStatus.Text = "Please Complete Data before saving!"
        End If
    End Sub

    Private Sub txtAssetNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAssetNumber.TextChanged

    End Sub

    Private Sub timerAlarm_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timerAlarm.Tick
        Try
            Dim Sound As New System.Media.SoundPlayer()
            Sound.SoundLocation = Path & "\tututut.wav"
            Sound.Load()
            Sound.Play()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ExportExcel(dgvAssetList)
    End Sub
    Private Function ExportExcel(ByVal dgv As DataGridView) As Boolean
        If dgv.RowCount = Nothing Then
            MessageBox.Show("Sorry nothing to export into excel sheet.." & vbCrLf & "Please retrieve data in datagridview", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If
        Dim rowsTotal, colsTotal As Short
        Dim I, j, iC As Short
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Dim xlApp As New Excel.Application

        Try
            Dim excelBook As Excel.Workbook = xlApp.Workbooks.Add
            Dim excelWorksheet As Excel.Worksheet = CType(excelBook.Worksheets(1), Excel.Worksheet)
            xlApp.Visible = True

            rowsTotal = dgv.RowCount - 1
            colsTotal = dgv.Columns.Count - 1
            With excelWorksheet
                .Cells.Select()
                .Cells.Delete()
                For iC = 0 To colsTotal
                    .Cells(1, iC + 1).Value = dgv.Columns(iC).HeaderText
                Next
                For I = 0 To rowsTotal
                    For j = 0 To colsTotal
                        .Cells(I + 2, j + 1).value = dgv.Rows(I).Cells(j).Value
                    Next j
                Next I
                .Rows("1:1").Font.FontStyle = "Bold"
                .Rows("1:1").Font.Size = 12

                .Cells.Columns.AutoFit()
                .Cells.Select()
                .Cells.EntireColumn.AutoFit()
                .Cells(1, 1).Select()
            End With
            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            'RELEASE ALLOACTED RESOURCES
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            xlApp = Nothing
        End Try
    End Function

End Class