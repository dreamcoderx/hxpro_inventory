Imports System.Data.SqlClient
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine

Public Class frmCreateRentalfin
    Dim strRentalID As String
    Dim dtPickDel As DateTime
    Dim dtEventFrom As DateTime
    Dim dtEventTo As DateTime
    Dim strRentalLineID As String
    Dim intLineNum As Integer

    Private Sub frm_create_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadRentalHDR()
        loadRentalLine()
        loadCrew()
        loadCrewListBox()
        line_num_index(strRentalID)
    End Sub

    Private Function UpdateCmd() As Boolean
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim sql As String
        con.ConnectionString = ConnectServer()
        Try

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            sql = _
"UPDATE [tbl_rental_hdr]" & _
" SET [rental_no] = @rental_no" & _
", [delivered_to] = @delivered_to" & _
", [event] = @event" & _
", [pick_del_date] = @pick_del_date" & _
", [location] = @location" & _
", [event_from] = @event_from" & _
", [event_to] = @event_to" & _
", [prepared_by] = @prepared_by" & _
" WHERE [rental_id] = @rental_id"

            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@rental_id", strRentalID)
            cmd.Parameters.AddWithValue("@rental_no", txtRentalNO.Text)
            cmd.Parameters.AddWithValue("@delivered_to", txtDeliverTo.Text)
            cmd.Parameters.AddWithValue("@event", txtEvent.Text)
            cmd.Parameters.AddWithValue("@pick_del_date", dtpickdeldate1.Value)
            cmd.Parameters.AddWithValue("@location", txtLocation.Text)
            cmd.Parameters.AddWithValue("@event_from", dtpEventFrom1.Value)
            cmd.Parameters.AddWithValue("@event_to", dtpEventTo1.Value)
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
"  FROM [dbo].[tbl_rental_hdr] where rental_no = '" & txtRentalNO.Text & "'"

            cmd = New SqlCommand(sql, con)
            Dim dtRentalHdr As New DataTable

            Dim adpt As New Data.SqlClient.SqlDataAdapter(cmd)
            adpt.Fill(dtRentalHdr)
            If dtRentalHdr.Rows.Count = 0 Then
                MsgBox("Cannot find rental No!")
                Return False
            Else
                strRentalID = dtRentalHdr.Rows(0).Item("rental_id").ToString
                txtRentalNO.Text = dtRentalHdr.Rows(0).Item("rental_no").ToString
                txtDeliverTo.Text = dtRentalHdr.Rows(0).Item("delivered_to").ToString
                txtEvent.Text = dtRentalHdr.Rows(0).Item("event").ToString

                dtPickDel = dtRentalHdr.Rows(0).Item("pick_del_date")
                dtpickdeldate1.Value = dtPickDel
                dtPickDelDate2.Value = dtPickDel

                dtEventFrom = dtRentalHdr.Rows(0).Item("event_from")
                dtpEventFrom1.Value = dtEventFrom
                dtpEventFrom2.Value = dtEventFrom

                dtEventTo = dtRentalHdr.Rows(0).Item("event_to")
                dtpEventTo1.Value = dtEventTo
                dtpEventTo2.Value = dtEventTo

                txtPreparedBy.Text = dtRentalHdr.Rows(0).Item("prepared_by").ToString
                txtLocation.Text = dtRentalHdr.Rows(0).Item("location").ToString
            End If
            con.Dispose()
            cmd.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function

    Private Function ItmAddInsert(ByVal addType As Integer) As Boolean
        Dim insLineNum As Integer
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim sql As String = ""
        con.ConnectionString = ConnectServer()
        Try
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            cmd = New SqlCommand
            cmd.Parameters.Add("@rental_id", SqlDbType.Int)
            cmd.Parameters.Add("@part_id", SqlDbType.Int)
            cmd.Parameters.Add("@model", SqlDbType.NVarChar)
            cmd.Parameters.Add("@brand", SqlDbType.NVarChar)
            cmd.Parameters.Add("@description", SqlDbType.NVarChar)
            cmd.Parameters.Add("@qty", SqlDbType.Int)
            cmd.Parameters.Add("@uom", SqlDbType.NVarChar)
            cmd.Parameters.Add("@rental_line_num", SqlDbType.Int)

            cmd.Parameters("@rental_id").Value = strRentalID
            cmd.Parameters("@part_id").Value = txtpartid.Text
            cmd.Parameters("@model").Value = txtModel.Text
            cmd.Parameters("@brand").Value = txtBrand.Text
            cmd.Parameters("@description").Value = txtDescription.Text
            cmd.Parameters("@qty").Value = NumericUpDown1.Value
            cmd.Parameters("@uom").Value = txtUOM.Text
            cmd.Parameters("@rental_line_num").Value = intLineNum

            cmd.Connection = con
            cmd.CommandType = CommandType.Text

            Select Case addType
                Case 0
                    sql = "SELECT COUNT(*) FROM [tbl_rental_line] WHERE [rental_id] = @rental_id"
                    cmd.CommandText = sql
                    insLineNum = cmd.ExecuteScalar()

                    sql = _
    "INSERT INTO [tbl_rental_line]" & _
    " ([rental_id]" & _
    " ,[rental_line_num]" & _
    " ,[part_id]" & _
    " ,[qty]" & _
    " ,[model]" & _
    " ,[brand]" & _
    " ,[description]" & _
    " ,[uom])" & _
    " VALUES" & _
    " (@rental_id" & _
    " ,@rental_line_num" & _
    " ,@part_id" & _
    " ,@qty" & _
    " ,@model" & _
    " ,@brand" & _
    " ,@description" & _
    " ,@uom)"

                    cmd.CommandText = sql
                    cmd.Parameters("@rental_line_num").Value = insLineNum + 1
                    If cmd.ExecuteNonQuery = 0 Then
                        Return False
                    Else
                        Return True
                    End If
                Case 1
                    sql = "UPDATE[tbl_rental_line]" & _
    " SET [rental_line_num] = [rental_line_num] + 1 " & _
    " WHERE [rental_id] = @rental_id" & _
    " and [rental_line_num] >= @rental_line_num"
                    cmd.CommandText = sql
                    cmd.ExecuteNonQuery()
                    sql = _
    "INSERT INTO [tbl_rental_line]" & _
    " ([rental_id]" & _
    " ,[rental_line_num]" & _
    " ,[part_id]" & _
    " ,[qty]" & _
    " ,[model]" & _
    " ,[brand]" & _
    " ,[description]" & _
    " ,[uom])" & _
    " VALUES" & _
    " (@rental_id" & _
    " ,@rental_line_num" & _
    " ,@part_id" & _
    " ,@qty" & _
    " ,@model" & _
    " ,@brand" & _
    " ,@description" & _
    " ,@uom)"

                    cmd.CommandText = sql
                    If cmd.ExecuteNonQuery = 0 Then
                        Return False
                    Else
                        Return True
                    End If

            End Select
            con.Dispose()
            cmd.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Function

    Private Function InsCrew() As Boolean
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim sql As String = ""
        con.ConnectionString = ConnectServer()
        Try

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            sql = _
"INSERT INTO [tbl_rental_crew]" & _
" ([rental_id]" & _
" ,[crew_id])" & _
" VALUES" & _
" (@rental_id" & _
" , @crew_id)"
            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@rental_id", strRentalID)
            cmd.Parameters.AddWithValue("@crew_id", cboCrewList.SelectedValue)
            If cmd.ExecuteNonQuery() > 0 Then
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

    Private Function deleteLine() As Boolean
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim sql As String = ""
        con.ConnectionString = ConnectServer()
        Try

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            sql = _
"DELETE FROM [tbl_rental_line] WHERE rental_line_id = @rental_line_id"
            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@rental_line_id", (dgvRentalLine.Item("rental_line_id", dgvRentalLine.CurrentRow.Index).Value()))
            If cmd.ExecuteNonQuery = 0 Then
                Return False
            Else
                sql = "UPDATE[tbl_rental_line]" & _
" SET [rental_line_num] = [rental_line_num] -1 " & _
" WHERE [rental_id] = @rental_id" & _
" and [rental_line_num] >= @rental_line_num"
                cmd = New SqlCommand(sql, con)
                cmd.Parameters.AddWithValue("@rental_id", strRentalID)
                cmd.Parameters.AddWithValue("@rental_line_num", (dgvRentalLine.Item("rental_line_num", dgvRentalLine.CurrentRow.Index).Value()))
                cmd.ExecuteNonQuery()
                Return True
            End If

            con.Dispose()
            cmd.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function

    Private Sub loadRentalLine()
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim sql As String
        con.ConnectionString = ConnectServer()
        Try

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            sql = _
"SELECT [rental_line_id],ROW_NUMBER() over(order by rental_line_num) as rental_line_num ,[qty],[uom], [brand]" & _
", [model]" & _
", [description]" & _
" FROM [tbl_rental_line]" & _
" WHERE [rental_id] = '" & strRentalID & "'" & _
" ORDER BY [rental_line_num], [rental_line_id]"


            cmd = New SqlCommand(sql, con)
            Dim dtRentalLine As New DataTable

            Dim adpt As New Data.SqlClient.SqlDataAdapter(cmd)
            adpt.Fill(dtRentalLine)
            dgvRentalLine.DataSource = dtRentalLine
            lblTotal.Text = dtRentalLine.Rows.Count.ToString

            dgvRentalLine.Columns(0).Width = 0
            dgvRentalLine.Columns(1).Width = 50
            dgvRentalLine.Columns(2).Width = 50
            dgvRentalLine.Columns(3).Width = 150
            dgvRentalLine.Columns(4).Width = 250
            dgvRentalLine.Columns(5).Width = 250
            dgvRentalLine.Columns(6).Width = 350
            dgvRentalLine.Columns(0).HeaderText = "LINE ID"
            dgvRentalLine.Columns(1).HeaderText = "#"
            dgvRentalLine.Columns(2).HeaderText = "QTY"
            dgvRentalLine.Columns(3).HeaderText = "UOM"
            dgvRentalLine.Columns(4).HeaderText = "BRAND"
            dgvRentalLine.Columns(5).HeaderText = "MODEL"
            dgvRentalLine.Columns(6).HeaderText = "DESCRIPTION"
            
            con.Dispose()
            cmd.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub loadCrew()
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim sql As String
        con.ConnectionString = ConnectServer()
        Try
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            sql = _
"SELECT [crew_id]" & _
" ,[crew_name]" & _
" FROM [tbl_crew] where [active] = 1"
            cmd = New SqlCommand(sql, con)
            Dim dtCrew As New DataTable

            Dim adpt As New Data.SqlClient.SqlDataAdapter(cmd)
            adpt.Fill(dtCrew)
            cboCrewList.ValueMember = "CREW_ID"
            cboCrewList.DisplayMember = "CREW_NAME"
            cboCrewList.DataSource = dtCrew
            con.Dispose()
            cmd.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub loadCrewListBox()
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim sql As String
        con.ConnectionString = ConnectServer()
        Try

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            sql = _
"SELECT a.[crew_id], b.[crew_name]" & _
" FROM [tbl_rental_crew] a" & _
" left join [tbl_crew] b on a.[crew_id] = b.[crew_id]" & _
" where a.rental_id = '" & strRentalID & "'"

            cmd = New SqlCommand(sql, con)
            Dim dtCrewList As New DataTable

            Dim adpt As New Data.SqlClient.SqlDataAdapter(cmd)
            adpt.Fill(dtCrewList)

            listCrew.ValueMember = "CREW_ID"
            listCrew.DisplayMember = "CREW_NAME"
            listCrew.DataSource = dtCrewList
            con.Dispose()
            cmd.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub btn_browse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_browse.Click
        Try
            Dim a As New frm_part1
            If a.ShowDialog() = DialogResult.OK Then
                txtpartid.Text = (a.dgv_parts.Item("part_id", a.dgv_parts.CurrentRow.Index).Value())
                txtPartNumber.Text = (a.dgv_parts.Item("part_number", a.dgv_parts.CurrentRow.Index).Value())
                txtDescription.Text = (a.dgv_parts.Item("description", a.dgv_parts.CurrentRow.Index).Value())
                txtBrand.Text = (a.dgv_parts.Item("brand_name", a.dgv_parts.CurrentRow.Index).Value().ToString)
                txtModel.Text = (a.dgv_parts.Item("model_no", a.dgv_parts.CurrentRow.Index).Value().ToString)
                txt_category.Text = (a.dgv_parts.Item("cat_desc", a.dgv_parts.CurrentRow.Index).Value().ToString)
                txt_sub_category.Text = (a.dgv_parts.Item("sub_cat_desc", a.dgv_parts.CurrentRow.Index).Value().ToString)
            Else
                txtpartid.Text = ""
                txtPartNumber.Text = ""
                txtDescription.Text = ""
                txtBrand.Text = ""
                txtModel.Text = ""
                txt_category.Text = ""
                txt_sub_category.Text = ""
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If txtpartid.Text <> "" And txtModel.Text = "" And txtBrand.Text <> "" And txtDescription.Text = "" Then
                MsgBox("Please Complete all Data Needed!")
                Exit Sub
            End If

        Dim insval As Integer = 0
        Select Case txtMode.Text
            Case "ADD"
                insval = 0
            Case "EDIT"
                insval = 2
            Case "INSERT"
                insval = 1
        End Select

        If insval = 2 Then
            If UpdateRenLine(strRentalLineID) Then
                MsgBox("UPDATE SUCESSFULL!")
                loadRentalLine()
                btnSave.Text = "ADD"
                btnCancel.Text = "EDIT"
                txtMode.Text = "ADD"
            End If
        Else
            If ItmAddInsert(insval) Then
                loadRentalLine()
                MessageBox.Show("SAVE SUCCESS!")
                txtMode.Text = "ADD"
            Else
                MessageBox.Show("SAVE FAILED!")
            End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Function UpdateRenLine(ByVal vRentalLineID As String) As Boolean
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim sql As String = ""
        con.ConnectionString = ConnectServer()
        Try
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            sql = _
"UPDATE [tbl_rental_line]" & _
" SET " & _
" [qty] = @qty" & _
" ,[model] = @model" & _
" ,[brand] = @brand" & _
" ,[description] = @description" & _
" ,[uom] = @uom" & _
" WHERE [rental_line_id] = @rental_line_id"
            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@rental_line_id", vRentalLineID)
            cmd.Parameters.AddWithValue("@model", txtModel.Text)
            cmd.Parameters.AddWithValue("@brand", txtBrand.Text)
            cmd.Parameters.AddWithValue("@description", txtDescription.Text)
            cmd.Parameters.AddWithValue("@qty", NumericUpDown1.Value)
            cmd.Parameters.AddWithValue("@uom", txtUOM.Text)
            If cmd.ExecuteNonQuery() > 0 Then
                Return True
            End If
            Return False
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Dispose()
            cmd.Dispose()
        End Try
    End Function

    Private Sub loadReport()
        Dim myReport As New ReportDocument
        Dim myData As New DataSet

        Try
            Dim connection As New System.Data.SqlClient.SqlConnection(ConnectServer())
            Dim sql As String
            sql = _
"SELECT b.rental_no, b.delivered_to, b.event, b.location," & _
" b.pick_del_date, b.event_from, b.event_to," & _
" A.qty, a.uom, a.brand as brand_name, a.model as model_no, a.description, g.user_name" & _
" FROM [tbl_rental_line] a" & _
" left join tbl_rental_hdr b on a.rental_id = b.rental_id" & _
" left join tbl_user g on b.prepared_by = g.user_id " & _
" where a.rental_id = '" & strRentalID & "'" & _
" ORDER BY [rental_line_num], [rental_line_id]"

            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If
            Dim command As New SqlCommand(sql, connection)

            Dim adpt As New Data.SqlClient.SqlDataAdapter(command)
            command.CommandText = sql
            command.Connection = connection

            adpt.SelectCommand = command
            adpt.Fill(myData)

            sql = _
"SELECT a.[crew_id], b.[crew_name]" & _
" FROM [tbl_rental_crew] a" & _
" left join [tbl_crew] b on a.[crew_id] = b.[crew_id]" & _
" where a.rental_id = '" & strRentalID & "'"

            Dim myData2 As New DataSet
            command.CommandText = sql
            command.Connection = connection

            adpt.SelectCommand = command
            adpt.Fill(myData2)

            Dim A As New frm_rpt
            myReport.Load(Path + "\rpt\RentalSlipFinal.rpt")
            myReport.Subreports("n").SetDataSource(myData2)
            myReport.SetDataSource(myData)
            A.myViewer.ReportSource = myReport
            A.Text = "RENTAL SLIP"
            A.ShowDialog()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        loadReport()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If InsCrew() Then
            MsgBox("Insert Successfull!")
            loadCrewListBox()
        Else
            MsgBox("Insert Failed!")
        End If
    End Sub

    Private Function deleteCrew() As Boolean
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim sql As String = ""
        con.ConnectionString = ConnectServer()
        Try

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            sql = _
"DELETE FROM [tbl_rental_crew]" & _
" WHERE(rental_id = @rental_id And crew_id = @crew_id)"

            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@rental_id", strRentalID)
            cmd.Parameters.AddWithValue("@crew_id", listCrew.SelectedValue)
            If cmd.ExecuteNonQuery = 0 Then
                Return False
            Else
                Return True
            End If

            con.Dispose()
            cmd.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If deleteCrew() Then
            MsgBox("Crew removed!")
            loadCrewListBox()
        Else
            MsgBox("Crew failed to remove!")
        End If
    End Sub

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
                MsgBox("Asset Number not found!")
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
                Return True
            End If
            con.Dispose()
            cmd.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub txtAssetNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAssetNumber.KeyPress
        Dim Keyascii As Integer = AscW(e.KeyChar)
        If Keyascii = 13 And txtAssetNumber.Text <> "" Then
            If loadItemDesc() Then
            End If
        End If
    End Sub

    Private Sub dtPickDelDate2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtPickDelDate2.ValueChanged
        dtPickDel = dtPickDelDate2.Value
        dtpickdeldate1.Value = dtPickDel
    End Sub

    Private Sub dtpickdeldate1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpickdeldate1.ValueChanged
        dtPickDel = dtpickdeldate1.Value
        dtPickDelDate2.Value = dtPickDel
    End Sub

    Private Sub dtpEventFrom2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpEventFrom2.ValueChanged
        dtEventFrom = dtpEventFrom2.Value
        dtpEventFrom1.Value = dtEventFrom
    End Sub

    Private Sub dtpEventFrom1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpEventFrom1.ValueChanged
        dtEventFrom = dtpEventFrom1.Value
        dtpEventFrom2.Value = dtEventFrom
    End Sub

    Private Sub dtpEventTo2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpEventTo2.ValueChanged
        dtEventTo = dtpEventTo2.Value
        dtpEventTo1.Value = dtEventTo
    End Sub

    Private Sub dtpEventTo1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpEventTo1.ValueChanged
        dtEventTo = dtpEventTo1.Value
        dtpEventTo2.Value = dtEventTo
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        If txtRentalNO.Text = String.Empty Or txtDeliverTo.Text = String.Empty Then
            MsgBox("Please Complete all needed data!")
            Exit Sub
        End If

        If UpdateCmd() Then
            MsgBox("Update Successfull!")
        Else
            MsgBox("Update Failed!")
        End If
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        txtMode.Text = "ADD"
    End Sub

    Private Sub dgvRentalLine_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvRentalLine.CellMouseClick
        Try

            If e.Button = MouseButtons.Right And dgvRentalLine.CurrentRow.Index > -1 Then
                cmdAddEditDel.Show(MousePosition.X, MousePosition.Y)
            End If
        Catch ex As Exception

        End Try

    End Sub


    Private Sub INSERTToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles INSERTToolStripMenuItem.Click
        Try
            If dgvRentalLine.CurrentRow.Index > -1 Then
                txtMode.Text = "INSERT"
                intLineNum = (dgvRentalLine.Item("rental_line_num", dgvRentalLine.CurrentRow.Index).Value())
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub DELETEToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DELETEToolStripMenuItem1.Click
        Try
            If dgvRentalLine.CurrentRow.Index > -1 Then
                If MessageBox.Show("Delete Item?", "ITEM DELETE", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) _
                    = DialogResult.Cancel Then
                    Exit Sub
                End If

                If deleteLine() Then
                    loadRentalLine()
                    MessageBox.Show("DELETE SUCCESS!")
                Else
                    MessageBox.Show("SADELETEVE FAILED!")
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub DELETEToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DELETEToolStripMenuItem.Click
        Try

            If dgvRentalLine.CurrentRow.Index > -1 Then
                If MessageBox.Show("Edit Selected Item?", "EDIT", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) _
                                        = DialogResult.Cancel Then
                    Exit Sub
                End If
                strRentalLineID = (dgvRentalLine.Item("rental_line_id", dgvRentalLine.CurrentRow.Index).Value()).ToString
                NumericUpDown1.Value = (dgvRentalLine.Item("qty", dgvRentalLine.CurrentRow.Index).Value())
                txtDescription.Text = (dgvRentalLine.Item("description", dgvRentalLine.CurrentRow.Index).Value()).ToString
                txtModel.Text = (dgvRentalLine.Item("model", dgvRentalLine.CurrentRow.Index).Value()).ToString
                txtBrand.Text = (dgvRentalLine.Item("brand", dgvRentalLine.CurrentRow.Index).Value()).ToString
                btnSave.Text = "SAVE"
                btnCancel.Text = "CANCEL"
                txtMode.Text = "EDIT"
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub line_num_index(ByVal rental_id As String)
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim sql As String = ""
        con.ConnectionString = ConnectServer()
        Try
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            sql = "update trl" & _
" set rental_line_num = a.row" & _
" from [tbl_rental_line] trl" & _
" join" & _
" (SELECT ROW_NUMBER() over(order by rental_line_num) as row" & _
" , [rental_line_id]" & _
" FROM [hxpro_db].[dbo].[tbl_rental_line]" & _
" where rental_id = @rental_id) a" & _
" on a.rental_line_id = trl.rental_line_id" & _
" where trl.rental_id = @rental_id"
            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@rental_id", rental_id)
            If cmd.ExecuteNonQuery() > 0 Then
                '   MessageBox.Show("line number index success!")
            End If
            '  MessageBox.Show("line number index failed!")
        Catch ex As Exception
            'MsgBox(ex.Message)
        Finally
            con.Dispose()
            cmd.Dispose()
        End Try
    End Sub



End Class