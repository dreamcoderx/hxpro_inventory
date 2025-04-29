Imports System.Data
Imports System.Data.SqlClient
Public Class frm_part_qty
    Dim dt As New DataTable
    Private Sub frm_brand_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        load_dgv()
    End Sub
    Private Sub load_dgv()
        Try
            Dim connection As New System.Data.SqlClient.SqlConnection(ConnectServer())
            Dim sql As String
            sql = "select * from v_part_qty"
            Dim command As New System.Data.SqlClient.SqlCommand(sql, connection)

            Dim adpt As New Data.SqlClient.SqlDataAdapter(command)

            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If
            dt.Clear()
            adpt.Fill(dt)
            dgv_brand.DataSource = dt
            dgv_brand.Columns(0).HeaderText = "ID"
            dgv_brand.Columns(1).HeaderText = "BRAND CODE"
            dgv_brand.Columns(2).HeaderText = "NAME"

            dgv_brand.AutoResizeColumns()


        Catch ex As SqlException
            MessageBox.Show("An error occurred while loading data !" & vbCrLf & ex.ToString())
        Finally

        End Try

    End Sub



End Class