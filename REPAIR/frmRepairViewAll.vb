Imports System.Data.SqlClient
Imports System.Xml

Public Class frmRepairViewAll

    Private Function Query() As Boolean
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim sql As String
        Dim str_where As List(Of String) = New List(Of String)
        Dim str_where_con As String = ""

        con.ConnectionString = ConnectServer()
        Try

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            sql = _
"SELECT" & _
" b.repair_number" & _
", b.company" & _
", b.address" & _
", b.date" & _
", a.[item_code]" & _
", d.description" & _
", d.model_no" & _
", e.brand_name" & _
", a.[repair_description]" & _
", f.[date] as date_in" & _
" FROM [hxpro_db].[dbo].[tbl_repair_line] a" & _
" left join [hxpro_db].[dbo].[tbl_repair_hdr] b on a.repair_id = b.repair_id" & _
" left join [hxpro_db].[dbo].[tbl_item] c on a.item_code = c.item_code" & _
" left join [hxpro_db].[dbo].[tbl_part] d on c.part_id = d.part_id" & _
" left join [hxpro_db].[dbo].[tbl_brand] e on d.brand_id =  e.brand_id" & _
" left join [hxpro_db].[dbo].[tbl_status] f on a.status_id = f.status_id"

            If txtCompany.Text <> "" Then
                str_where.Add("d.description like '%" & txtDescription.Text & "%'")
            End If

            If txtDescription.Text <> "" Then
                str_where.Add("b.company like '%" & txtCompany.Text & "%'")
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

            
            cmd = New SqlCommand(sql, con)
            Dim dtRentalHdr As New DataTable

            Dim adpt As New Data.SqlClient.SqlDataAdapter(cmd)
            adpt.Fill(dtRentalHdr)
            dgvRentalHDR.DataSource = dtRentalHdr

            dgvRentalHDR.Columns(0).HeaderText = "REPAIR NUMBER"
            dgvRentalHDR.Columns(1).HeaderText = "COMPANY"
            dgvRentalHDR.Columns(2).HeaderText = "ADDRESS"
            dgvRentalHDR.Columns(3).HeaderText = "DATE OUT"
            dgvRentalHDR.Columns(4).HeaderText = "ITEM CODE"
            dgvRentalHDR.Columns(5).HeaderText = "DESCRIPTION"
            dgvRentalHDR.Columns(6).HeaderText = "MODEL NO"
            dgvRentalHDR.Columns(7).HeaderText = "BRAND"
            dgvRentalHDR.Columns(8).HeaderText = "REPAIR DESCRIPTION"
            dgvRentalHDR.Columns(9).HeaderText = "DATE IN"

            dgvRentalHDR.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            dgvRentalHDR.AutoResizeColumns()

            con.Dispose()
            cmd.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function

    Private Sub btn_clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_clear.Click
        txtDescription.Text = ""
        txtCompany.Text = ""
    End Sub

    Private Sub btn_search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_search.Click
        Query()
    End Sub
End Class