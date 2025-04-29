Public Class frm_upload

    Private Sub frm_upload_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub LoadGrid(ByVal sql As String)
        'Dim mySql As String
        Dim dt As New DataTable
        Dim str_where As List(Of String) = New List(Of String)
        Dim str_where_con As String = ""
        'mySql = "SELECT item_code, item_desc, uom, barcode FROM tbl_items"
        Try
            Dim connection As New System.Data.SqlClient.SqlConnection(ConnectServer())
            'Dim sql As String

            '"SELECT a.part_number, a.description, a.brand_id, b.brand_name, a.model_no  FROM tbl_part a" & _
            '" left join tbl_brand b on a.brand_id = b.brand_id"

            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If


            Dim command As New System.Data.SqlClient.SqlCommand(sql, connection)

            Dim adpt As New Data.SqlClient.SqlDataAdapter(command)
            dt.Clear()
            adpt.Fill(dt)
            dgv_upload.DataSource = Nothing
            dgv_upload.DataSource = dt

            'b.part_number, b.description, e.brand_name, b.model_no, d.cat_desc, c.sub_cat_desc from tbl_part b" & _
            'dgv_parts.Columns(0).HeaderText = "ID"
            'dgv_parts.Columns(1).HeaderText = "PART NUMBER"
            'dgv_parts.Columns(2).HeaderText = "DESCRIPTION"
            'dgv_parts.Columns(3).HeaderText = "BRAND ID"
            'dgv_parts.Columns(4).HeaderText = "BRAND NAME"
            'dgv_parts.Columns(5).HeaderText = "MODEL NUMBER"
            'dgv_parts.Columns(6).HeaderText = "CATEGORY"
            'dgv_parts.Columns(7).HeaderText = "SUB CATEGORY"
            dgv_upload.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            dgv_upload.AutoResizeColumns()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim sql As String
        sql = _
"SELECT f.item_code" & _
", a.[asset_number]" & _
", a.[serial_number]" & _
", b.[part_id]" & _
", a.[description]" & _
", a.[model]" & _
", c.[brand_id] " & _
", a.[brand]" & _
", d.cat_id " & _
", a.[category]" & _
", e.sub_cat_id " & _
", a.[sub_category]" & _
" FROM [hxpro_db].[dbo].[tbl_upload] a" & _
" left join [hxpro_db].[dbo].[tbl_item] f on a.asset_number = f.asset_number" & _
" left join [hxpro_db].[dbo].[tbl_brand] c on a.brand = c.brand_name" & _
" left join [hxpro_db].[dbo].[tbl_part] b on a.description = b.description and b.brand_id = c.brand_id" & _
" and a.model = b.model_no" & _
" left join [hxpro_db].[dbo].[tbl_category] d on a.category = d.cat_desc" & _
" left join [hxpro_db].[dbo].[tbl_sub_category] e on a.sub_category = e.sub_cat_desc" & _
" order by a.[asset_number]"

        LoadGrid(Sql)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim sql As String
        sql = _
"SELECT DISTINCT" & _
" b.[part_id]" & _
", a.[description]" & _
", a.[model]" & _
", c.[brand_id] " & _
", a.[brand]" & _
", e.sub_cat_id" & _
", e.sub_cat_desc" & _
" FROM [hxpro_db].[dbo].[tbl_upload] a" & _
" left join [hxpro_db].[dbo].[tbl_brand] c on a.brand = c.brand_name " & _
" left join [hxpro_db].[dbo].[tbl_part] b on a.description = b.description and c.brand_id = b.brand_id" & _
" left join [hxpro_db].[dbo].[tbl_category] d on a.category = d.cat_desc " & _
" left join [hxpro_db].[dbo].[tbl_sub_category] e on a.sub_category = e.sub_cat_desc" & _
" where b.part_id is null"

        '" and a.model = b.model_no" & _
        LoadGrid(sql)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim sql As String = _
"SELECT DISTINCT" & _
" e.sub_cat_id " & _
", a.sub_category" & _
", d.cat_id" & _
", d.cat_desc" & _
" FROM [hxpro_db].[dbo].[tbl_upload] a" & _
" left join [hxpro_db].[dbo].[tbl_brand] c on a.brand = c.brand_name " & _
" left join [hxpro_db].[dbo].[tbl_part] b on a.description = b.description and b.brand_id = c.brand_id" & _
" and b.model_no = a.model" & _
" left join [hxpro_db].[dbo].[tbl_category] d on a.category = d.cat_desc " & _
" left join [hxpro_db].[dbo].[tbl_sub_category] e on a.sub_category = e.sub_cat_desc" & _
" where e.sub_cat_id is null"
        LoadGrid(sql)
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim sql As String = _
"SELECT DISTINCT" & _
" d.cat_id " & _
" ,a.category" & _
" FROM [hxpro_db].[dbo].[tbl_upload] a" & _
" left join [hxpro_db].[dbo].[tbl_brand] c on a.brand = c.brand_name " & _
" left join [hxpro_db].[dbo].[tbl_part] b on a.description = b.description and b.brand_id = c.brand_id" & _
" and b.model_no = a.model" & _
" left join [hxpro_db].[dbo].[tbl_category] d on a.category = d.cat_desc " & _
" left join [hxpro_db].[dbo].[tbl_sub_category] e on a.sub_category = e.sub_cat_desc" & _
" WHERE d.cat_id is null"
        LoadGrid(sql)
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim sql As String = _
"SELECT DISTINCT" & _
" c.brand_id" & _
", a.brand" & _
" FROM [hxpro_db].[dbo].[tbl_upload] a" & _
" left join [hxpro_db].[dbo].[tbl_brand] c on a.brand = c.brand_name " & _
" left join [hxpro_db].[dbo].[tbl_part] b on a.description = b.description and b.brand_id = c.brand_id" & _
" and b.model_no = a.model" & _
" left join [hxpro_db].[dbo].[tbl_category] d on a.category = d.cat_desc " & _
" left join [hxpro_db].[dbo].[tbl_sub_category] e on a.sub_category = e.sub_cat_desc" & _
" WHERE c.brand_id is null"
        LoadGrid(sql)
    End Sub
End Class