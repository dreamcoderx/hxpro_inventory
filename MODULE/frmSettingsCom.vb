Imports System
Imports System.ComponentModel
Imports System.Threading
Imports System.IO.Ports

Public Class frmSettingsCom
    Dim myPort As Array  'COM Ports detected on the system will be stored here
    Delegate Sub SetTextCallback(ByVal [text] As String) 'Added to prevent threading errors during receiveing of data

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try

            myPort = IO.Ports.SerialPort.GetPortNames()
            cboBaud.Items.Add(9600)
            cboBaud.Items.Add(19200)
            cboBaud.Items.Add(38400)
            cboBaud.Items.Add(57600)
            cboBaud.Items.Add(115200)

            cboParity.Items.Add("none")
            cboParity.Items.Add("odd")
            cboParity.Items.Add("even")
            cboParity.Items.Add("mark")
            cboParity.Items.Add("space")

            cboStopBits.Items.Add("none")
            cboStopBits.Items.Add("one")
            cboStopBits.Items.Add("two")
            cboStopBits.Items.Add("OnePointFive")

            For i = 0 To UBound(myPort)
                cboPort.Items.Add(myPort(i))
            Next
            cboPort.Text = Settings.Get("com_name")
            'My.Settings.com_name
            cboBaud.Text = Settings.Get("com_baud")
            'My.Settings.com_baud
            cboParity.Text = Settings.Get("parity")
            'My.Settings.com_parity
            cboStopBits.Text = Settings.Get("com_stopbits")
            'My.Settings.com_stopbits
            Dim comDataBits = Settings.Get("com_databits")
            numDataBits.Value = Convert.ToInt32(comDataBits)
            '(My.Settings.com_databits)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        Try
            'My.Settings.com_name = cboPort.Text
            Settings.Set("com_name", cboPort.Text)
            'My.Settings.com_baud = cboBaud.Text
            Settings.Set("com_baud", cboBaud.Text)
            'My.Settings.com_stopbits = cboStopBits.Text
            Settings.Set("com_stopbits", cboStopBits.Text)
            'My.Settings.com_databits = numDataBits.Value.ToString
            Settings.Set("com_databits", numDataBits.Value.ToString)
            Settings.Update()
            MessageBox.Show("SETTINGS SAVED!")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class