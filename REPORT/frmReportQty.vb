Imports System.Data.SqlClient
Imports Excel = Microsoft.Office.Interop.Excel

Public Class frmReportQty
    Dim dt As New DataTable
    Dim dt_brand As New DataTable

    Private Sub LoadGrid()
        Dim str_where As List(Of String) = New List(Of String)
        Dim str_where_con As String = ""
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim connection As New System.Data.SqlClient.SqlConnection(ConnectServer())
            Dim sql As String
            sql = _
"SELECT [part_id]" & _
", [part_number]" & _
", [description]" & _
", [model_no]" & _
", [brand_name]" & _
", [cat_desc]" & _
", [sub_cat_desc]" & _
", [total_qty]" & _
", [defective_qty]" & _
", [rental_qty]" & _
", [repair_qty]" & _
", [available_qty]" & _
" FROM [v_part_qty]"
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If

            If txtPartID.Text <> "" Then
                str_where.Add("[part_id] = '" & txtPartID.Text & "'")
            End If

            If cbo_part.Text <> "" Then
                str_where.Add("[description] like '%" & cbo_part.Text & "%'")
            End If

            If cbo_brand.Text <> "" Then
                str_where.Add("[brand_name] like '%" & cbo_brand.Text & "'")
            End If

            If txt_model.Text <> "" Then
                str_where.Add("[model_no] = '" & txt_model.Text & "'")
            End If

            If cbo_category.Text <> "" Then
                str_where.Add("[cat_desc] = '" & cbo_category.Text & "'")
            End If

            If cbo_sub_category.Text <> "" Then
                str_where.Add("[sub_cat_desc] = '" & cbo_sub_category.Text & "'")
            End If

            For Each val As String In str_where
                If str_where_con = "" Then
                    str_where_con = val
                Else
                    str_where_con = str_where_con & " and " & val
                End If
            Next

            If str_where_con <> "" Then
                sql = sql & " WHERE " & str_where_con
            End If

            sql = sql & _
            " order by [part_id]"

            Dim command As New System.Data.SqlClient.SqlCommand(sql, connection)
            Dim adpt As New Data.SqlClient.SqlDataAdapter(command)
            dt.Clear()
            adpt.Fill(dt)
            dgv_parts.DataSource = dt

            dgv_parts.Columns(0).ReadOnly = True
            dgv_parts.Columns(1).ReadOnly = True
            dgv_parts.Columns(2).ReadOnly = True
            dgv_parts.Columns(3).ReadOnly = True
            dgv_parts.Columns(4).ReadOnly = True
            dgv_parts.Columns(5).ReadOnly = True
            dgv_parts.Columns(6).ReadOnly = True
            dgv_parts.Columns(7).ReadOnly = True
            dgv_parts.Columns(8).ReadOnly = True
            dgv_parts.Columns(9).ReadOnly = True
            dgv_parts.Columns(10).ReadOnly = True
            dgv_parts.Columns(11).ReadOnly = True

            dgv_parts.Columns(0).HeaderText = "PART ID"
            dgv_parts.Columns(1).HeaderText = "PART NUMBER"
            dgv_parts.Columns(2).HeaderText = "DESCRIPTION"
            dgv_parts.Columns(3).HeaderText = "MODEL"
            dgv_parts.Columns(4).HeaderText = "BRAND"
            dgv_parts.Columns(5).HeaderText = "CATEGORY"
            dgv_parts.Columns(6).HeaderText = "SUB CATEGORY"
            dgv_parts.Columns(7).HeaderText = "TOTAL QTY"
            dgv_parts.Columns(8).HeaderText = "DEFECTIVE QTY"
            dgv_parts.Columns(9).HeaderText = "RENTAL QTY"
            dgv_parts.Columns(10).HeaderText = "REPAIR QTY"
            dgv_parts.Columns(11).HeaderText = "AVAILABLE QTY"

            dgv_parts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            dgv_parts.AutoResizeColumns()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub load_cbo_brand()
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim connection As New System.Data.SqlClient.SqlConnection(ConnectServer())
            Dim sql As String
            sql = _
            "SELECT [brand_id]" & _
            ", [brand_name]" & _
            " FROM [tbl_brand]" & _
            " order by [brand_name]"
            Dim command As New System.Data.SqlClient.SqlCommand(sql, connection)
            Dim dt_brand As New DataTable
            Dim adpt As New Data.SqlClient.SqlDataAdapter(command)
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If
            adpt.Fill(dt_brand)
            cbo_brand.DataSource = dt_brand
            cbo_brand.DisplayMember = "brand_name"
            cbo_brand.ValueMember = "brand_id"
            cbo_brand.SelectedIndex = -1
        Catch ex As SqlException
            MessageBox.Show("An error occurred while loading data !" & vbCrLf & ex.ToString())
        Finally
            Cursor.Current = Cursors.Default
        End Try

    End Sub

    Private Sub load_cbo_category()
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim connection As New System.Data.SqlClient.SqlConnection(ConnectServer())
            Dim sql As String
            sql = _
            "SELECT [cat_id]" & _
            ", [cat_desc]" & _
            " FROM [tbl_category]"
            Dim command As New System.Data.SqlClient.SqlCommand(sql, connection)

            Dim adpt As New Data.SqlClient.SqlDataAdapter(command)
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If
            dt_brand.Clear()
            adpt.Fill(dt_brand)
            cbo_category.DataSource = dt_brand
            cbo_category.DisplayMember = "cat_desc"
            cbo_category.ValueMember = "cat_id"
            cbo_category.SelectedIndex = -1
        Catch ex As SqlException
            MessageBox.Show("An error occurred while loading data !" & vbCrLf & ex.ToString())
        Finally
            Cursor.Current = Cursors.Default
        End Try

    End Sub

    Private Sub load_cbo_part()
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim connection As New System.Data.SqlClient.SqlConnection(ConnectServer())
            Dim sql As String
            sql = _
            "select b.part_id, b.description from tbl_part b"
            Dim command As New System.Data.SqlClient.SqlCommand(sql, connection)
            Dim dt_part As New DataTable
            Dim adpt As New Data.SqlClient.SqlDataAdapter(command)
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If
            adpt.Fill(dt_part)
            cbo_part.DataSource = dt_part
            cbo_part.DisplayMember = "description"
            cbo_part.ValueMember = "part_id"
            cbo_part.SelectedIndex = -1
        Catch ex As SqlException
            MessageBox.Show("An error occurred while loading data !" & vbCrLf & ex.ToString())
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub cbo_category_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_category.SelectedIndexChanged
        If Not cbo_category.SelectedIndex = -1 Then
            load_cbo_sub_category(dt_brand(cbo_category.SelectedIndex).Item(0).ToString)
        End If
    End Sub

    Private Sub frm_item_list_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        load_cbo_part()
        load_cbo_brand()
        load_cbo_category()
    End Sub

    Private Sub btn_search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_search.Click
        LoadGrid()
    End Sub

    Private Sub btn_clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_clear.Click
        txt_model.Text = ""
        cbo_part.Text = ""
        cbo_part.SelectedIndex = -1
        cbo_brand.SelectedIndex = -1
        cbo_category.SelectedIndex = -1
        cbo_sub_category.SelectedIndex = -1
    End Sub

    Private Sub load_cbo_sub_category(ByVal cat_code As String)
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim connection As New System.Data.SqlClient.SqlConnection(ConnectServer())
            Dim sql As String
            sql = _
            "SELECT [sub_cat_code]" & _
            ", [sub_cat_desc]" & _
            " FROM [tbl_sub_category]" & _
            " WHERE [cat_id] = '" & cat_code & "'"
            Dim command As New System.Data.SqlClient.SqlCommand(sql, connection)
            Dim dt_brand As New DataTable
            Dim adpt As New Data.SqlClient.SqlDataAdapter(command)
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If
            adpt.Fill(dt_brand)
            cbo_sub_category.DataSource = dt_brand
            cbo_sub_category.DisplayMember = "sub_cat_desc"
            cbo_sub_category.ValueMember = "sub_cat_code"
            cbo_sub_category.Text = ""
            'cbo_category.SelectedIndex = -1
        Catch ex As SqlException
            MessageBox.Show("An error occurred while loading data !" & vbCrLf & ex.ToString())
        Finally
            Cursor.Current = Cursors.Default
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
        ExportExcel(dgv_parts)
    End Sub

    Private Sub txtPartID_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtPartID.TextChanged

    End Sub
End Class