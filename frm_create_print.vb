Imports System.Data
Imports System.Data.SqlClient
Public Class frm_create_print
    Dim dt_part As New DataTable
    'Dim mnuItemNew As New MenuItem()
    'Dim mnuItemOpen As New MenuItem()
    '' Visual Basic
    'Public Sub AddContextMenuAndItems()
    '    Dim mnuContextMenu As New ContextMenu()
    '    Me.ContextMenu = mnuContextMenu
    'End Sub

    ' Dim bol_first As Boolean = False
    Private Sub frm_create_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        list_btw()
        'cbo_print.Items.Add("1D")
        'cbo_print.Items.Add("2D")
        update_cmd(True)
        ' load_cbo_part()
    End Sub

    Private Sub list_btw()
        Dim myCoolFolder As String = Path & "/bt/"
        For Each myCoolFile As String In My.Computer.FileSystem.GetFiles _
        (myCoolFolder, FileIO.SearchOption.SearchTopLevelOnly, "*.btw")
            cbo_print.Items.Add(IO.Path.GetFileName(myCoolFile))
        Next
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        update_cmd(False)
    End Sub
    Private Function update_cmd(ByVal bol_first As Boolean) As Boolean
        Dim str_item_code As List(Of String) = New List(Of String)
        Dim str_item_code_where As String = ""
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim sql As String = ""
        Dim TW As System.IO.TextWriter

        con.ConnectionString = ConnectServer()
        Try

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            TW = System.IO.File.CreateText(Path + "\bt\print.txt")

            For ctr As Integer = 0 To dgv_created.Rows.Count - 1
                Dim bol_duplicate_serial As Boolean = False
                'MsgBox(dgv_created.Item("asset_number", ctr).Value)
                If dgv_created.Item("serial_number", ctr).Value.ToString <> String.Empty Then
                    sql = _
             "select count(*) from tbl_item" & _
             " where part_id = @part_id and" & _
             " serial_number = @serial_number and not(" & _
             " item_code = @item_code)"
                    cmd = New SqlCommand(sql, con)
                    cmd.Parameters.AddWithValue("@part_id", dgv_created.Item("part_id", ctr).Value)
                    cmd.Parameters.AddWithValue("@serial_number", dgv_created.Item("serial_number", ctr).Value.ToString)
                    cmd.Parameters.AddWithValue("@item_code", dgv_created.Item("item_code", ctr).Value)

                    If cmd.ExecuteScalar > 0 Then
                        bol_duplicate_serial = True
                    End If
                End If
                If bol_duplicate_serial Then
                    dgv_created.Item("status", ctr).Value = "Serial Number is duplicate!"
                Else
                    sql = _
                  "UPDATE [tbl_item]" & _
                  " SET [serial_number] = @serial_number, [asset_number]= @asset_number" & _
                  " WHERE [item_code] = @item_code"
                    cmd = New SqlCommand(sql, con)

                    cmd.Parameters.AddWithValue("@item_code", dgv_created.Item("item_code", ctr).Value)
                    cmd.Parameters.AddWithValue("@asset_number", dgv_created.Item("asset_number", ctr).Value)
                    cmd.Parameters.AddWithValue("@serial_number", dgv_created.Item("serial_number", ctr).Value.ToString)
                    If cmd.ExecuteNonQuery() > 0 Then
                        If bol_first Then
                            dgv_created.Item("status", ctr).Value = "Created!"
                        Else
                            dgv_created.Item("status", ctr).Value = "Updated!"

                        End If
                    Else
                        dgv_created.Item("status", ctr).Value = "Update failed!"
                    End If
                End If
                'End If
                TW.WriteLine(dgv_created.Item("asset_number", ctr).Value & "|" & dgv_created.Item("serial_number", ctr).Value.ToString & "|" & dgv_created.Item("description", ctr).Value & "|" & dgv_created.Item("model_no", ctr).Value & "|" & dgv_created.Item("brand_name", ctr).Value)

                'TW.WriteLine(dgv_created.Item("asset_number", ctr).Value & "|" & dgv_created.Item("description", ctr).Value & "|" & dgv_created.Item("model_no", ctr).Value & "|" & dgv_created.Item("brand_name", ctr).Value)
                'description
            Next
            TW.Flush()
            TW.Close()
            con.Dispose()
            cmd.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function

    Private Sub btn_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_save.Click
        Try
            update_cmd(False)
            Dim TW As System.IO.TextWriter
            TW = System.IO.File.CreateText(Path + "\bt\print.txt")

            For ctr As Integer = 0 To dgv_created.RowCount - 1
                Dim bolchk As New Boolean
                bolchk = dgv_created.Item(0, ctr).Value
                If bolchk Then
                    TW.WriteLine(dgv_created.Item("asset_number", ctr).Value & "|" & dgv_created.Item("serial_number", ctr).Value.ToString & "|" & dgv_created.Item("description", ctr).Value & "|" & dgv_created.Item("model_no", ctr).Value & "|" & dgv_created.Item("brand_name", ctr).Value)
                End If
            Next

        
            If cbo_print.SelectedIndex >= 0 Then
                Dim p As New Process
                p.StartInfo.UseShellExecute = True
                p.StartInfo.WorkingDirectory = Path
                p.StartInfo.Arguments = Path & "\bt\" & cbo_print.Text & " /P/X"
                p.StartInfo.FileName = Path + "\bt\BarTend.exe"
                p.Start()
                p.Dispose()
            Else
                MsgBox("Please select a format!")
            End If

            TW.Dispose()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        'update_cmd(False)
        'If cbo_print.SelectedIndex >= 0 Then
        '    Dim p As New Process
        '    p.StartInfo.UseShellExecute = True
        '    p.StartInfo.WorkingDirectory = Path
        '    p.StartInfo.Arguments = Path & "\bt\" & cbo_print.Text & " /P/X"
        '    p.StartInfo.FileName = Path + "\bt\BarTend.exe"
        '    p.Start()
        '    p.Dispose()
        'Else
        '    MsgBox("Select format!")
        'End If


        ' Button1.Enabled = True
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim a As System.Windows.Forms.DialogResult

        If dgv_created.Rows.Count > 0 Then
            a = MessageBox.Show("Are you sure you want to Cancel the Creation?", _
                                   "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            If a = DialogResult.Yes Then
                delete_cmd()
            Else
                MsgBox("No item to delete!")
            End If
        End If
    End Sub
    Private Sub delete_cmd()
        Dim str_item_code As List(Of String) = New List(Of String)
        Dim str_item_code_where As String = ""
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim sql As String = "DELETE FROM [tbl_item]"
        con.ConnectionString = ConnectServer()
        Try
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            For ctr As Integer = 0 To dgv_created.Rows.Count - 1
                str_item_code.Add(dgv_created.Item("item_code", ctr).Value)
            Next

            For Each val As String In str_item_code
                If str_item_code_where = "" Then
                    str_item_code_where = "item_code = " & val
                Else
                    str_item_code_where = str_item_code_where & " or item_code = " & val
                End If
            Next

            If str_item_code_where <> "" Then
                sql = sql & " where " & str_item_code_where
            Else

            End If
            'MsgBox(sql)
            cmd = New SqlCommand(sql, con)
            Dim cmd_int As Integer
            cmd_int = cmd.ExecuteNonQuery
            MsgBox("DELETED:" & cmd_int.ToString)
            dgv_created.DataSource = Nothing

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub dgv_created_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgv_created.MouseClick
        If e.Button = MouseButtons.Right And dgv_created.CurrentCell.ColumnIndex = 8 Then
            ContextMenuStrip1.Show(Control.MousePosition.X, Control.MousePosition.Y)
        End If
    End Sub


    Private Sub ContextMenuStrip1_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening

    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PasteToolStripMenuItem.Click
        paste()
    End Sub
    'Paste copied cells from clipboard (Excel) to DataGridView with a fixed number of columns
    Private Sub paste()
        Dim s As String = Clipboard.GetText()                   'Get clipboard data as a string
        Dim rows() As String = s.Split(ControlChars.NewLine)    'Split into rows
        Dim i, j As Integer                                     'Counters
        Try
            For i = dgv_created.CurrentRow.Index To dgv_created.Rows.Count - 1
                If i > rows.Length.ToString - 1 Then
                    Exit For
                End If
                Dim bufferCell() As String = rows(i).Split(ControlChars.Tab)
                If bufferCell(j).ToString.Contains(ControlChars.Lf) Then
                    bufferCell(j) = bufferCell(j).ToString.Replace(ControlChars.Lf, "")
                End If
                dgv_created.Item(8, i).Value = bufferCell(0)
            Next
        Catch
            MessageBox.Show("INPUT ERROR" & ControlChars.NewLine & _
            "Number of columns shall be max " & dgv_created.ColumnCount)
        End Try
    End Sub

    Private Sub dgv_created_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_created.CellContentClick

    End Sub

    Private Sub btn_chk_all_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_chk_all.Click
        For r As Integer = 0 To dgv_created.RowCount - 1
            Dim bolchk As New Boolean
            bolchk = dgv_created.Item(0, r).Value
            If bolchk = False Then
                dgv_created.Item(0, r).Value = True
            End If
        Next
    End Sub

    Private Sub btn_uncheck_all_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_uncheck_all.Click
        For r As Integer = 0 To dgv_created.RowCount - 1
            Dim bolchk As New Boolean
            bolchk = dgv_created.Item(0, r).Value
            If bolchk Then
                dgv_created.Item(0, r).Value = False
            End If
        Next
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim a As System.Windows.Forms.DialogResult
        a = MessageBox.Show("Are you sure you want to Exit?", _
                                   "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        If a = DialogResult.Yes Then
            Me.Dispose()
        End If
    End Sub
End Class