<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSettingsCon
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
        Me.txtInitialCatalog = New System.Windows.Forms.TextBox()
        Me.txtDataSource = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtUserName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtInitialCatalog
        '
        Me.txtInitialCatalog.Location = New System.Drawing.Point(24, 81)
        Me.txtInitialCatalog.Name = "txtInitialCatalog"
        Me.txtInitialCatalog.Size = New System.Drawing.Size(219, 20)
        Me.txtInitialCatalog.TabIndex = 13
        '
        'txtDataSource
        '
        Me.txtDataSource.Location = New System.Drawing.Point(24, 31)
        Me.txtDataSource.Name = "txtDataSource"
        Me.txtDataSource.Size = New System.Drawing.Size(219, 20)
        Me.txtDataSource.TabIndex = 12
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(9, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(234, 20)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "INITIAL CATALOG:"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(9, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(234, 20)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "DATA SOURCE:"
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(24, 186)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(219, 20)
        Me.txtPassword.TabIndex = 17
        '
        'txtUserName
        '
        Me.txtUserName.Location = New System.Drawing.Point(24, 136)
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Size = New System.Drawing.Size(219, 20)
        Me.txtUserName.TabIndex = 16
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(9, 163)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(234, 20)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "PASSWORD:"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(9, 113)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(234, 20)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "USER NAME:"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(168, 227)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 20
        Me.btnSave.Text = "SAVE"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(273, 262)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.txtUserName)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtInitialCatalog)
        Me.Controls.Add(Me.txtDataSource)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.Text = "CONNECTION SETTINGS"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtInitialCatalog As System.Windows.Forms.TextBox
    Friend WithEvents txtDataSource As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtUserName As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
End Class
