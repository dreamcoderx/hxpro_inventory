Imports System.Xml
Public Class frmSettings
    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        txtDataSource.Text = My.Settings.data_source
        txtInitialCatalog.Text = My.Settings.initial_catalog
        txtUserName.Text = My.Settings.user_id
        txtPassword.Text = My.Settings.password
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        Try
            My.Settings.data_source = txtDataSource.Text
            My.Settings.initial_catalog = txtInitialCatalog.Text
            My.Settings.user_id = txtUserName.Text
            My.Settings.password = txtPassword.Text
            MessageBox.Show("SETTINGS SAVED!")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class