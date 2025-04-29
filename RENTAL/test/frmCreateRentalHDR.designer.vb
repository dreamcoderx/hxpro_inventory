<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCreateRentalHDR
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
        Me.btnCreate = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtLocation = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtEvent = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtDeliverTo = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtRentalNO = New System.Windows.Forms.TextBox()
        Me.dtPickDelDate = New System.Windows.Forms.DateTimePicker()
        Me.dtEventFrom = New System.Windows.Forms.DateTimePicker()
        Me.dtEventTo = New System.Windows.Forms.DateTimePicker()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.dtTime1 = New System.Windows.Forms.DateTimePicker()
        Me.dtpEventFrom = New System.Windows.Forms.DateTimePicker()
        Me.dtpEventTo = New System.Windows.Forms.DateTimePicker()
        Me.SuspendLayout()
        '
        'btnCreate
        '
        Me.btnCreate.Location = New System.Drawing.Point(272, 188)
        Me.btnCreate.Name = "btnCreate"
        Me.btnCreate.Size = New System.Drawing.Size(72, 24)
        Me.btnCreate.TabIndex = 9
        Me.btnCreate.Text = "Create"
        Me.btnCreate.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(42, 165)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 13)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "EVENT TO:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(29, 140)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 13)
        Me.Label5.TabIndex = 26
        Me.Label5.Text = "EVENT FROM:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(45, 115)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 13)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "LOCATION:"
        '
        'txtLocation
        '
        Me.txtLocation.Location = New System.Drawing.Point(114, 112)
        Me.txtLocation.Name = "txtLocation"
        Me.txtLocation.Size = New System.Drawing.Size(451, 20)
        Me.txtLocation.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(-4, 90)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(113, 13)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "PICK-UP/DEL. DATE:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(63, 65)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(46, 13)
        Me.Label7.TabIndex = 21
        Me.Label7.Text = "EVENT:"
        '
        'txtEvent
        '
        Me.txtEvent.Location = New System.Drawing.Point(114, 62)
        Me.txtEvent.Name = "txtEvent"
        Me.txtEvent.Size = New System.Drawing.Size(451, 20)
        Me.txtEvent.TabIndex = 2
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(20, 40)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(89, 13)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "DELIVERED TO:"
        '
        'txtDeliverTo
        '
        Me.txtDeliverTo.Location = New System.Drawing.Point(114, 37)
        Me.txtDeliverTo.Name = "txtDeliverTo"
        Me.txtDeliverTo.Size = New System.Drawing.Size(622, 20)
        Me.txtDeliverTo.TabIndex = 1
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(37, 15)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(72, 13)
        Me.Label9.TabIndex = 33
        Me.Label9.Text = "RENTAL NO:"
        '
        'txtRentalNO
        '
        Me.txtRentalNO.Location = New System.Drawing.Point(114, 12)
        Me.txtRentalNO.Name = "txtRentalNO"
        Me.txtRentalNO.Size = New System.Drawing.Size(230, 20)
        Me.txtRentalNO.TabIndex = 0
        '
        'dtPickDelDate
        '
        Me.dtPickDelDate.Location = New System.Drawing.Point(114, 87)
        Me.dtPickDelDate.Name = "dtPickDelDate"
        Me.dtPickDelDate.Size = New System.Drawing.Size(230, 20)
        Me.dtPickDelDate.TabIndex = 34
        '
        'dtEventFrom
        '
        Me.dtEventFrom.Location = New System.Drawing.Point(114, 137)
        Me.dtEventFrom.Name = "dtEventFrom"
        Me.dtEventFrom.Size = New System.Drawing.Size(230, 20)
        Me.dtEventFrom.TabIndex = 35
        '
        'dtEventTo
        '
        Me.dtEventTo.Location = New System.Drawing.Point(114, 162)
        Me.dtEventTo.Name = "dtEventTo"
        Me.dtEventTo.Size = New System.Drawing.Size(230, 20)
        Me.dtEventTo.TabIndex = 36
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(350, 188)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(72, 24)
        Me.btnCancel.TabIndex = 37
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'dtTime1
        '
        Me.dtTime1.CustomFormat = "HH:mm"
        Me.dtTime1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtTime1.Location = New System.Drawing.Point(350, 88)
        Me.dtTime1.Name = "dtTime1"
        Me.dtTime1.ShowUpDown = True
        Me.dtTime1.Size = New System.Drawing.Size(95, 20)
        Me.dtTime1.TabIndex = 38
        '
        'dtpEventFrom
        '
        Me.dtpEventFrom.CustomFormat = "HH:mm"
        Me.dtpEventFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEventFrom.Location = New System.Drawing.Point(350, 137)
        Me.dtpEventFrom.Name = "dtpEventFrom"
        Me.dtpEventFrom.ShowUpDown = True
        Me.dtpEventFrom.Size = New System.Drawing.Size(95, 20)
        Me.dtpEventFrom.TabIndex = 41
        '
        'dtpEventTo
        '
        Me.dtpEventTo.CustomFormat = "HH:mm"
        Me.dtpEventTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEventTo.Location = New System.Drawing.Point(350, 159)
        Me.dtpEventTo.Name = "dtpEventTo"
        Me.dtpEventTo.ShowUpDown = True
        Me.dtpEventTo.Size = New System.Drawing.Size(95, 20)
        Me.dtpEventTo.TabIndex = 42
        '
        'frmCreateRentalHDR1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(766, 225)
        Me.Controls.Add(Me.dtpEventTo)
        Me.Controls.Add(Me.dtpEventFrom)
        Me.Controls.Add(Me.dtTime1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.dtEventTo)
        Me.Controls.Add(Me.dtEventFrom)
        Me.Controls.Add(Me.dtPickDelDate)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtRentalNO)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtLocation)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtEvent)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtDeliverTo)
        Me.Controls.Add(Me.btnCreate)
        Me.Name = "frmCreateRentalHDR1"
        Me.Text = "ASSET CREATE"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCreate As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtLocation As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtEvent As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtDeliverTo As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtRentalNO As System.Windows.Forms.TextBox
    Friend WithEvents dtPickDelDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtEventFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtEventTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents dtTime1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpEventFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpEventTo As System.Windows.Forms.DateTimePicker
End Class
