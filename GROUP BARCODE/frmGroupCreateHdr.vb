Imports System.Data.SqlClient

Public Class frmGroupCreateHdr

    Private Function CreateCmd() As Boolean
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim sql As String
        con.ConnectionString = ConnectServer()
        Try

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            sql = "select count(*) from [tbl_group_hdr] where group_barcode = '" & txtGroupBarcode.Text & "'"
            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@asset_number", txtGroupBarcode.Text)
            If (cmd.ExecuteScalar) <> 0 Then
                MsgBox("Group Barcode already exist!")
                Return False
            End If
            sql = _
"INSERT INTO [tbl_group_hdr]" & _
 " ([group_barcode]" & _
 " ,[description])" & _
 " VALUES" & _
 " (@group_barcode" & _
 " ,@description)"

            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@group_barcode", txtGroupBarcode.Text)
            cmd.Parameters.AddWithValue("@description", txtGroupDescription.Text)

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
        If txtGroupBarcode.Text = String.Empty Then
            MsgBox("Please Enter the Group Barcode!")
            Exit Sub
        End If

        If txtGroupDescription.Text = String.Empty Then
            MsgBox("Please Enter the Group Description!")
            Exit Sub
        End If


        If CreateCmd() Then
            MsgBox("Set barcode is created!", MsgBoxStyle.Information, "HX PRO")

        Else
            MsgBox("Set barcode failed to create!", MsgBoxStyle.Information, "HX PRO")
        End If

    End Sub


End Class