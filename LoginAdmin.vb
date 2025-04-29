Imports System.Data.SqlClient

Public Class LoginAdmin

    Private Sub log_in()
        If Not conecDB_OK() Then Return
        Dim sql As String = _
        String.Format("select user_name, acct_id, password from tbl_user where active = 1 and user_id = '{0}'", txt_user_id.Text)
        Using command As New SqlCommand(sql, connDB)
            Using dt As New DataTable()
                Dim adpt As New Data.SqlClient.SqlDataAdapter(command)
                Try
                    adpt.Fill(dt)
                    If dt.Rows.Count > 0 Then
                        If Decrypt(dt(0).Item("password")) = txt_password.Text Then
                            If dt(0).Item(1) = "1" Then
                                frm_main.Text = "HXPRO - BARCODE INVENTORY - " & dt(0).Item("user_name")
                                user_id = txt_user_id.Text
                                DialogResult = System.Windows.Forms.DialogResult.OK
                                Close()
                            Else
                                frm_main.Text = "HXPRO - BARCODE INVENTORY - " & dt(0).Item("user_name")
                                user_id = txt_user_id.Text
                                frm_main.TABLESToolStripMenuItem.Enabled = False
                                frm_main.ITEMToolStripMenuItem.Enabled = False
                                frm_main.REPAIRToolStripMenuItem.Enabled = False
                                frm_main.RETURNToolStripMenuItem.Enabled = False
                                frm_main.DELIVERYToolStripMenuItem.Enabled = False
                                frm_main.INVENTORYToolStripMenuItem.Enabled = False
                                frm_main.CREATEToolStripMenuItem.Enabled = False
                                frm_main.VIEWToolStripMenuItem.Enabled = False
                                DialogResult = System.Windows.Forms.DialogResult.OK
                                Close()
                            End If
                        Else
                            MsgBox("INVALID PASSWORD!")
                        End If
                    Else
                        MsgBox("INVALID USERID!")
                    End If
                Catch ex As SqlException
                    MessageBox.Show("An error occurred while loading data !" & vbCrLf & ex.ToString())
                End Try
            End Using
        End Using
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        log_in()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim f As New frmSettingsCon
        f.Show()
    End Sub
End Class
