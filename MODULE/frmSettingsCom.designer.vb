<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSettingsCom
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboPort = New System.Windows.Forms.ComboBox()
        Me.cboBaud = New System.Windows.Forms.ComboBox()
        Me.cboParity = New System.Windows.Forms.ComboBox()
        Me.cboStopBits = New System.Windows.Forms.ComboBox()
        Me.numDataBits = New System.Windows.Forms.NumericUpDown()
        CType(Me.numDataBits, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(9, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(234, 20)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "BAUD RATE:"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(9, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(234, 20)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "PORT:"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(9, 163)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(234, 20)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "STOP BITS:"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(9, 113)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(234, 20)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "PARITY:"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(168, 293)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 20
        Me.btnSave.Text = "SAVE"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(9, 221)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(234, 20)
        Me.Label5.TabIndex = 22
        Me.Label5.Text = "DATA BITS:"
        '
        'cboPort
        '
        Me.cboPort.FormattingEnabled = True
        Me.cboPort.Location = New System.Drawing.Point(24, 29)
        Me.cboPort.Name = "cboPort"
        Me.cboPort.Size = New System.Drawing.Size(219, 21)
        Me.cboPort.TabIndex = 23
        '
        'cboBaud
        '
        Me.cboBaud.FormattingEnabled = True
        Me.cboBaud.Location = New System.Drawing.Point(24, 81)
        Me.cboBaud.Name = "cboBaud"
        Me.cboBaud.Size = New System.Drawing.Size(219, 21)
        Me.cboBaud.TabIndex = 24
        '
        'cboParity
        '
        Me.cboParity.FormattingEnabled = True
        Me.cboParity.Location = New System.Drawing.Point(24, 136)
        Me.cboParity.Name = "cboParity"
        Me.cboParity.Size = New System.Drawing.Size(219, 21)
        Me.cboParity.TabIndex = 25
        '
        'cboStopBits
        '
        Me.cboStopBits.FormattingEnabled = True
        Me.cboStopBits.Location = New System.Drawing.Point(24, 186)
        Me.cboStopBits.Name = "cboStopBits"
        Me.cboStopBits.Size = New System.Drawing.Size(219, 21)
        Me.cboStopBits.TabIndex = 26
        '
        'numDataBits
        '
        Me.numDataBits.Location = New System.Drawing.Point(24, 244)
        Me.numDataBits.Name = "numDataBits"
        Me.numDataBits.Size = New System.Drawing.Size(219, 20)
        Me.numDataBits.TabIndex = 27
        '
        'frmSettingsCom
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(273, 332)
        Me.Controls.Add(Me.numDataBits)
        Me.Controls.Add(Me.cboStopBits)
        Me.Controls.Add(Me.cboParity)
        Me.Controls.Add(Me.cboBaud)
        Me.Controls.Add(Me.cboPort)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSettingsCom"
        Me.Text = "COM PORT SETTINGS"
        CType(Me.numDataBits, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboPort As System.Windows.Forms.ComboBox
    Friend WithEvents cboBaud As System.Windows.Forms.ComboBox
    Friend WithEvents cboParity As System.Windows.Forms.ComboBox
    Friend WithEvents cboStopBits As System.Windows.Forms.ComboBox
    Friend WithEvents numDataBits As System.Windows.Forms.NumericUpDown
End Class
