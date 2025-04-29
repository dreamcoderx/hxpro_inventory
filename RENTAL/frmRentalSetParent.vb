Imports System.Data
Imports System.Data.SqlClient
Imports System.Xml
Public Class frmRentalSetParent
    Dim PickDelDT As DateTime

    Private Function CreateCmd() As Boolean
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim sql As String
        con.ConnectionString = ConnectServer()
        Try

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            sql = "select count(asset_number) from tbl_item where asset_number = @asset_number"

            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@asset_number", txtSetBarcode.Text)
            If (cmd.ExecuteScalar) <> 0 Then
                MsgBox("Asset No. already exist!")
                Return False
            End If

            sql = _
"INSERT INTO [tbl_item]" & _
" ([part_id]" & _
" ,[serial_number]" & _
" ,[asset_number]" & _
" ,[bol_set])" & _
"     VALUES" & _
" (@part_id" & _
" ,@serial_number" & _
" ,@asset_number" & _
" ,@bol_set)"

            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@part_id", txt_part_id.Text)
            cmd.Parameters.AddWithValue("@serial_number", txtSerialNumber.Text)
            cmd.Parameters.AddWithValue("@asset_number", txtSetBarcode.Text)
            cmd.Parameters.AddWithValue("@bol_set", True)

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




    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If txtSetBarcode.Text = String.Empty Then
            MsgBox("Please Enter the Set Barcode!")
            Exit Sub
        End If

        If txt_part_id.Text = String.Empty Then
            MsgBox("Please Enter the Part Details!")
            Exit Sub
        End If

        If CreateCmd() Then
            MsgBox("Set barcode is created!", MsgBoxStyle.Information, "HX PRO")

        Else
            MsgBox("Set barcode failed to create!", MsgBoxStyle.Information, "HX PRO")
        End If

    End Sub


    Private Sub btn_browse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_browse.Click
        Dim a As New frm_part1
        If a.ShowDialog() = DialogResult.OK Then
            txt_part_id.Text = (a.dgv_parts.Item("part_id", a.dgv_parts.CurrentRow.Index).Value())
            txt_part_number.Text = (a.dgv_parts.Item("part_number", a.dgv_parts.CurrentRow.Index).Value())
            txt_description.Text = (a.dgv_parts.Item("description", a.dgv_parts.CurrentRow.Index).Value())
            txt_brand.Text = (a.dgv_parts.Item("brand_name", a.dgv_parts.CurrentRow.Index).Value().ToString)
            txt_model.Text = (a.dgv_parts.Item("model_no", a.dgv_parts.CurrentRow.Index).Value().ToString)
            txt_category.Text = (a.dgv_parts.Item("cat_desc", a.dgv_parts.CurrentRow.Index).Value().ToString)
            txt_sub_category.Text = (a.dgv_parts.Item("sub_cat_desc", a.dgv_parts.CurrentRow.Index).Value().ToString)
        Else
            txt_part_id.Text = ""
            txt_part_number.Text = ""
            txt_description.Text = ""
            txt_brand.Text = ""
            txt_model.Text = ""
            txt_category.Text = ""
            txt_sub_category.Text = ""
        End If
    End Sub
End Class