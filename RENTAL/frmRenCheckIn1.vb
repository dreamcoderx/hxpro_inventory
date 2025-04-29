Imports System.Data.SqlClient
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.IO.Ports
Imports System.Text.RegularExpressions

Public Class frmRenCheckIn1
    'Dim myPort As Array
    Delegate Sub SetTextCallback(ByVal [text] As String)
    Dim dtAssetScanned As New DataTable

    Private Sub txtAssetNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAssetNumber.KeyPress
        Dim Keyascii As Integer = AscW(e.KeyChar)
        If Keyascii = 13 And txtAssetNumber.Text <> "" Then
            If checkin(txtAssetNumber.Text, user_id) Then
                loadItemCheckIn()
                lblStatus.ForeColor = Color.Green
                timerAlarm.Enabled = False
            Else
                lblStatus.ForeColor = Color.Red
                timerAlarm.Enabled = True
            End If
            txtAssetNumber.Focus()
            txtAssetNumber.SelectAll()
        End If
    End Sub

    Private Sub frmRenCheckIn_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadItemCheckIn()
        loadPort()
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
"select a.idx" & _
" , a.item_code" & _
" , c.asset_number" & _
" , vpa.description" & _
" , vpa.model_no" & _
" , vpa.brand_name" & _
" , vpa.cat_desc" & _
" , vpa.sub_cat_desc" & _
" , b.rental_no" & _
" , b.event" & _
" , a.dt_out" & _
" from tbl_rental_asset a" & _
" left join tbl_rental_hdr b on a.rental_id = b.rental_id" & _
" left join tbl_item c  on a.item_code = c.item_code" & _
" left join v_part_all vpa on vpa.part_id = c.part_id where a.dt_in is null"

            cmd = New SqlCommand(sql, con)
            dtAssetScanned.Rows.Clear()
            Dim adpt As New Data.SqlClient.SqlDataAdapter(cmd)
            dtAssetScanned.Rows.Clear()
            adpt.Fill(dtAssetScanned)
            dgvAssetList.DataSource = dtAssetScanned
            lblTotal.Text = dtAssetScanned.Rows.Count.ToString

            dgvAssetList.Columns(0).HeaderText = "ID"
            dgvAssetList.Columns(1).HeaderText = "ITEM CODE"
            dgvAssetList.Columns(2).HeaderText = "ASSET NUMBER"
            dgvAssetList.Columns(3).HeaderText = "DESCRIPTION"
            dgvAssetList.Columns(4).HeaderText = "MODEL"
            dgvAssetList.Columns(5).HeaderText = "BRAND"
            dgvAssetList.Columns(6).HeaderText = "CATEGORY"
            dgvAssetList.Columns(7).HeaderText = "SUB CATEGORY"
            dgvAssetList.Columns(8).HeaderText = "RENTAL NO"
            dgvAssetList.Columns(9).HeaderText = "EVENT"
            dgvAssetList.Columns(10).HeaderText = "DATE OUT"


            dgvAssetList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            dgvAssetList.AutoResizeColumns()

            con.Dispose()
            cmd.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub loadPort()
        For Each sp As String In My.Computer.Ports.SerialPortNames
            cboPort.Items.Add(Regex.Replace(sp, "[^A-Za-z0-9\-/]", ""))
        Next
        'myPort = IO.Ports.SerialPort.GetPortNames()
        'For i = 0 To UBound(myPort)
        '    cboPort.Items.Add(myPort(i))
        'Next
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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ExportExcel(dgvAssetList)
    End Sub

    Private Sub btnConnect_Click(sender As System.Object, e As System.EventArgs) Handles btnConnect.Click
        Try

        
        If btnConnect.Text = "CONNECT" Then
                'My.Settings.com_name = cboPort.Text
                Settings.Set("com_name", cboPort.Text)
                Settings.Update()
                SerialPort1.PortName = Settings.Get("com_name")
                'My.Settings.com_name
                SerialPort1.BaudRate = Settings.Get("com_baud")
                'My.Settings.com_baud
                SerialPort1.Parity = IO.Ports.Parity.None
                SerialPort1.StopBits = IO.Ports.StopBits.One
                SerialPort1.DataBits = Convert.ToInt32(Settings.Get("com_databits"))
                If SerialPort1.IsOpen Then
                    SerialPort1.Close()
                End If
                SerialPort1.Open()
            btnConnect.Text = "DISCONNECT"

        Else
                If SerialPort1.IsOpen Then
                    SerialPort1.Close()
                End If
            btnConnect.Text = "CONNECT"

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub SerialPort1_DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived
        ReceivedText(SerialPort1.ReadExisting())
    End Sub

    Private Sub ReceivedText(ByVal [text] As String)
        Try
            If txtAssetNumber.InvokeRequired Then
                Dim x As New SetTextCallback(AddressOf ReceivedText)
                Invoke(x, New Object() {(text)})
            Else
                txtAssetNumber.Text = Trim(text.Replace(vbCr, "").Replace(vbLf, "").Replace(vbCrLf, ""))
                'checkin(txtAssetNumber.Text, user_id)
                If checkin(txtAssetNumber.Text, user_id) Then
                    loadItemCheckIn()
                    lblStatus.ForeColor = Color.Green
                    timerAlarm.Enabled = False
                Else
                    lblStatus.ForeColor = Color.Red
                    timerAlarm.Enabled = True
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Function checkin(assetnumber As String, user As String) As Boolean
        Dim rv As Boolean
        Dim cmd As New SqlCommand
        Try
            Cursor.Current = Cursors.WaitCursor
            If Not conecDB_OK() Then Return False
            With cmd
                .CommandText = "dbo.usp_checkin"
                .CommandType = CommandType.StoredProcedure
                .Connection = connDB
                .CommandTimeout = 0
                .Parameters.Add("@assetnumber", SqlDbType.NVarChar, 30).Value = assetnumber
                .Parameters.Add("@user", SqlDbType.NVarChar, 20).Value = user
                .Parameters.Add("@partid", SqlDbType.Int).Direction = ParameterDirection.Output
                .Parameters.Add("@description", SqlDbType.NVarChar, 150).Direction = ParameterDirection.Output
                .Parameters.Add("@model", SqlDbType.NVarChar, 30).Direction = ParameterDirection.Output
                .Parameters.Add("@brand", SqlDbType.NVarChar, 50).Direction = ParameterDirection.Output
                .Parameters.Add("@category", SqlDbType.NVarChar, 50).Direction = ParameterDirection.Output
                .Parameters.Add("@subcategory", SqlDbType.NVarChar, 50).Direction = ParameterDirection.Output
                .Parameters.Add("@msg", SqlDbType.NVarChar, 250).Direction = ParameterDirection.Output
                .Parameters.Add("@rv", SqlDbType.Int).Direction = ParameterDirection.ReturnValue
                .CommandTimeout = 0
                .ExecuteNonQuery()
                txtPartID.Text = .Parameters("@partid").Value.ToString
                txtDescription.Text = .Parameters("@description").Value.ToString
                txtModel.Text = .Parameters("@model").Value.ToString
                txtBrand.Text = .Parameters("@brand").Value.ToString
                txtCategory.Text = .Parameters("@category").Value.ToString
                txtSubCategory.Text = .Parameters("@subcategory").Value.ToString
                lblStatus.Text = .Parameters("@msg").Value.ToString
                If .Parameters("@rv").Value = 0 Then
                    rv = True
                End If
            End With
        Catch sqlex As SqlException
            lblStatus.Text = sqlex.Message
        Catch ex As Exception
            lblStatus.Text = ex.Message
        Finally
            Cursor.Current = Cursors.Default
        End Try
        Return rv
    End Function


    Private Sub txtAssetNumber_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtAssetNumber.TextChanged

    End Sub
End Class