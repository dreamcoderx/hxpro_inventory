<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCreateRental1
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
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btn_browse = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_model = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txt_description = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txt_part_number = New System.Windows.Forms.TextBox()
        Me.txt_brand = New System.Windows.Forms.TextBox()
        Me.txt_category = New System.Windows.Forms.TextBox()
        Me.txt_sub_category = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txt_part_id = New System.Windows.Forms.TextBox()
        Me.dtEventTo = New System.Windows.Forms.DateTimePicker()
        Me.dtEventFrom = New System.Windows.Forms.DateTimePicker()
        Me.dtPickDelDate = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtRentalNO = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtLocation = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtEvent = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtDeliverTo = New System.Windows.Forms.TextBox()
        Me.dgvRentalLine = New System.Windows.Forms.DataGridView()
        Me.part_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtPreparedBy = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.listCrew = New System.Windows.Forms.ListBox()
        Me.cboCrewList = New System.Windows.Forms.ComboBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.txtAssetNumber = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvRentalLine, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Location = New System.Drawing.Point(227, 429)
        Me.NumericUpDown1.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(254, 20)
        Me.NumericUpDown1.TabIndex = 7
        Me.NumericUpDown1.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(178, 431)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "QTY:"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(487, 425)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(72, 24)
        Me.Button1.TabIndex = 9
        Me.Button1.Text = "ADD"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btn_browse
        '
        Me.btn_browse.Location = New System.Drawing.Point(358, 322)
        Me.btn_browse.Name = "btn_browse"
        Me.btn_browse.Size = New System.Drawing.Size(72, 24)
        Me.btn_browse.TabIndex = 8
        Me.btn_browse.Text = "SEARCH"
        Me.btn_browse.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(572, 402)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(94, 13)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "SUB CATEGORY:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(596, 375)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 13)
        Me.Label5.TabIndex = 26
        Me.Label5.Text = "CATEGORY:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(617, 349)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 13)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "MODEL:"
        '
        'txt_model
        '
        Me.txt_model.Location = New System.Drawing.Point(668, 346)
        Me.txt_model.Name = "txt_model"
        Me.txt_model.ReadOnly = True
        Me.txt_model.Size = New System.Drawing.Size(296, 20)
        Me.txt_model.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(57, 402)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 13)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "BRAND:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(22, 376)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(83, 13)
        Me.Label7.TabIndex = 21
        Me.Label7.Text = "DESCRIPTION:"
        '
        'txt_description
        '
        Me.txt_description.Location = New System.Drawing.Point(108, 373)
        Me.txt_description.Name = "txt_description"
        Me.txt_description.ReadOnly = True
        Me.txt_description.Size = New System.Drawing.Size(451, 20)
        Me.txt_description.TabIndex = 2
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(18, 353)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(89, 13)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "PART NUMBER:"
        '
        'txt_part_number
        '
        Me.txt_part_number.Location = New System.Drawing.Point(108, 350)
        Me.txt_part_number.Name = "txt_part_number"
        Me.txt_part_number.ReadOnly = True
        Me.txt_part_number.Size = New System.Drawing.Size(451, 20)
        Me.txt_part_number.TabIndex = 1
        '
        'txt_brand
        '
        Me.txt_brand.Location = New System.Drawing.Point(108, 399)
        Me.txt_brand.Name = "txt_brand"
        Me.txt_brand.ReadOnly = True
        Me.txt_brand.Size = New System.Drawing.Size(451, 20)
        Me.txt_brand.TabIndex = 3
        '
        'txt_category
        '
        Me.txt_category.Location = New System.Drawing.Point(668, 372)
        Me.txt_category.Name = "txt_category"
        Me.txt_category.ReadOnly = True
        Me.txt_category.Size = New System.Drawing.Size(296, 20)
        Me.txt_category.TabIndex = 5
        '
        'txt_sub_category
        '
        Me.txt_sub_category.Location = New System.Drawing.Point(668, 396)
        Me.txt_sub_category.Name = "txt_sub_category"
        Me.txt_sub_category.ReadOnly = True
        Me.txt_sub_category.Size = New System.Drawing.Size(296, 20)
        Me.txt_sub_category.TabIndex = 6
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(53, 327)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(53, 13)
        Me.Label9.TabIndex = 33
        Me.Label9.Text = "PART ID:"
        '
        'txt_part_id
        '
        Me.txt_part_id.Location = New System.Drawing.Point(110, 324)
        Me.txt_part_id.Name = "txt_part_id"
        Me.txt_part_id.ReadOnly = True
        Me.txt_part_id.Size = New System.Drawing.Size(230, 20)
        Me.txt_part_id.TabIndex = 0
        Me.txt_part_id.Text = " "
        '
        'dtEventTo
        '
        Me.dtEventTo.CustomFormat = "MM/dd/yyyy HH:MM"
        Me.dtEventTo.Enabled = False
        Me.dtEventTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtEventTo.Location = New System.Drawing.Point(128, 158)
        Me.dtEventTo.Name = "dtEventTo"
        Me.dtEventTo.Size = New System.Drawing.Size(230, 20)
        Me.dtEventTo.TabIndex = 50
        '
        'dtEventFrom
        '
        Me.dtEventFrom.CustomFormat = "MM/dd/yyyy HH:MM"
        Me.dtEventFrom.Enabled = False
        Me.dtEventFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtEventFrom.Location = New System.Drawing.Point(128, 133)
        Me.dtEventFrom.Name = "dtEventFrom"
        Me.dtEventFrom.Size = New System.Drawing.Size(230, 20)
        Me.dtEventFrom.TabIndex = 49
        '
        'dtPickDelDate
        '
        Me.dtPickDelDate.CustomFormat = "MM/dd/yyyy HH:MM"
        Me.dtPickDelDate.Enabled = False
        Me.dtPickDelDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtPickDelDate.Location = New System.Drawing.Point(128, 83)
        Me.dtPickDelDate.Name = "dtPickDelDate"
        Me.dtPickDelDate.Size = New System.Drawing.Size(230, 20)
        Me.dtPickDelDate.TabIndex = 48
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(51, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 13)
        Me.Label1.TabIndex = 47
        Me.Label1.Text = "RENTAL NO:"
        '
        'txtRentalNO
        '
        Me.txtRentalNO.Location = New System.Drawing.Point(128, 8)
        Me.txtRentalNO.Name = "txtRentalNO"
        Me.txtRentalNO.ReadOnly = True
        Me.txtRentalNO.Size = New System.Drawing.Size(230, 20)
        Me.txtRentalNO.TabIndex = 37
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(56, 161)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(64, 13)
        Me.Label10.TabIndex = 46
        Me.Label10.Text = "EVENT TO:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(43, 136)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(80, 13)
        Me.Label11.TabIndex = 45
        Me.Label11.Text = "EVENT FROM:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(59, 111)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(64, 13)
        Me.Label12.TabIndex = 44
        Me.Label12.Text = "LOCATION:"
        '
        'txtLocation
        '
        Me.txtLocation.Location = New System.Drawing.Point(128, 108)
        Me.txtLocation.Name = "txtLocation"
        Me.txtLocation.ReadOnly = True
        Me.txtLocation.Size = New System.Drawing.Size(451, 20)
        Me.txtLocation.TabIndex = 40
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(10, 86)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(113, 13)
        Me.Label13.TabIndex = 43
        Me.Label13.Text = "PICK-UP/DEL. DATE:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(77, 61)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(46, 13)
        Me.Label14.TabIndex = 42
        Me.Label14.Text = "EVENT:"
        '
        'txtEvent
        '
        Me.txtEvent.Location = New System.Drawing.Point(128, 58)
        Me.txtEvent.Name = "txtEvent"
        Me.txtEvent.ReadOnly = True
        Me.txtEvent.Size = New System.Drawing.Size(451, 20)
        Me.txtEvent.TabIndex = 39
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(34, 36)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(89, 13)
        Me.Label15.TabIndex = 41
        Me.Label15.Text = "DELIVERED TO:"
        '
        'txtDeliverTo
        '
        Me.txtDeliverTo.Location = New System.Drawing.Point(128, 33)
        Me.txtDeliverTo.Name = "txtDeliverTo"
        Me.txtDeliverTo.ReadOnly = True
        Me.txtDeliverTo.Size = New System.Drawing.Size(622, 20)
        Me.txtDeliverTo.TabIndex = 38
        '
        'dgvRentalLine
        '
        Me.dgvRentalLine.AllowUserToAddRows = False
        Me.dgvRentalLine.AllowUserToDeleteRows = False
        Me.dgvRentalLine.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvRentalLine.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRentalLine.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.part_id, Me.Column2, Me.Column3, Me.Column4})
        Me.dgvRentalLine.Location = New System.Drawing.Point(13, 458)
        Me.dgvRentalLine.Name = "dgvRentalLine"
        Me.dgvRentalLine.ReadOnly = True
        Me.dgvRentalLine.Size = New System.Drawing.Size(1129, 232)
        Me.dgvRentalLine.TabIndex = 51
        '
        'part_id
        '
        Me.part_id.DataPropertyName = "part_id"
        Me.part_id.HeaderText = "ID"
        Me.part_id.Name = "part_id"
        Me.part_id.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.DataPropertyName = "part_number"
        Me.Column2.HeaderText = "PART NUMBER"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 200
        '
        'Column3
        '
        Me.Column3.DataPropertyName = "description"
        Me.Column3.HeaderText = "DESCRIPTION"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 500
        '
        'Column4
        '
        Me.Column4.DataPropertyName = "qty"
        Me.Column4.HeaderText = "QTY"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 150
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(506, 164)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(86, 13)
        Me.Label16.TabIndex = 52
        Me.Label16.Text = "PREPARED BY:"
        '
        'txtPreparedBy
        '
        Me.txtPreparedBy.Location = New System.Drawing.Point(598, 161)
        Me.txtPreparedBy.Name = "txtPreparedBy"
        Me.txtPreparedBy.ReadOnly = True
        Me.txtPreparedBy.Size = New System.Drawing.Size(230, 20)
        Me.txtPreparedBy.TabIndex = 54
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button2.Location = New System.Drawing.Point(15, 694)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(72, 24)
        Me.Button2.TabIndex = 55
        Me.Button2.Text = "DELETE"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(364, 5)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(108, 24)
        Me.Button4.TabIndex = 58
        Me.Button4.Text = "PRINT RENTAL"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(51, 191)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(69, 13)
        Me.Label17.TabIndex = 59
        Me.Label17.Text = "CREW LIST:"
        '
        'listCrew
        '
        Me.listCrew.FormattingEnabled = True
        Me.listCrew.Location = New System.Drawing.Point(128, 211)
        Me.listCrew.Name = "listCrew"
        Me.listCrew.Size = New System.Drawing.Size(230, 69)
        Me.listCrew.TabIndex = 60
        '
        'cboCrewList
        '
        Me.cboCrewList.FormattingEnabled = True
        Me.cboCrewList.Location = New System.Drawing.Point(128, 184)
        Me.cboCrewList.Name = "cboCrewList"
        Me.cboCrewList.Size = New System.Drawing.Size(230, 21)
        Me.cboCrewList.TabIndex = 61
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(367, 186)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(72, 24)
        Me.Button3.TabIndex = 62
        Me.Button3.Text = "ADD"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(367, 216)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(72, 24)
        Me.Button5.TabIndex = 63
        Me.Button5.Text = "REMOVE"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'txtAssetNumber
        '
        Me.txtAssetNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAssetNumber.Location = New System.Drawing.Point(111, 297)
        Me.txtAssetNumber.Name = "txtAssetNumber"
        Me.txtAssetNumber.Size = New System.Drawing.Size(227, 20)
        Me.txtAssetNumber.TabIndex = 65
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(9, 298)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(95, 13)
        Me.Label18.TabIndex = 64
        Me.Label18.Text = "ASSET NUMBER:"
        '
        'frmCreateRental1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1154, 722)
        Me.Controls.Add(Me.txtAssetNumber)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.cboCrewList)
        Me.Controls.Add(Me.listCrew)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.txtPreparedBy)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.dgvRentalLine)
        Me.Controls.Add(Me.dtEventTo)
        Me.Controls.Add(Me.dtEventFrom)
        Me.Controls.Add(Me.dtPickDelDate)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtRentalNO)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtLocation)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtEvent)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtDeliverTo)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txt_part_id)
        Me.Controls.Add(Me.txt_sub_category)
        Me.Controls.Add(Me.txt_category)
        Me.Controls.Add(Me.txt_brand)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txt_model)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txt_description)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txt_part_number)
        Me.Controls.Add(Me.btn_browse)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.NumericUpDown1)
        Me.Name = "frmCreateRental1"
        Me.Text = "RENTAL CREATE"
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvRentalLine, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btn_browse As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_model As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txt_description As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txt_part_number As System.Windows.Forms.TextBox
    Friend WithEvents txt_brand As System.Windows.Forms.TextBox
    Friend WithEvents txt_category As System.Windows.Forms.TextBox
    Friend WithEvents txt_sub_category As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txt_part_id As System.Windows.Forms.TextBox
    Friend WithEvents dtEventTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtEventFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtPickDelDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtRentalNO As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtLocation As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtEvent As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtDeliverTo As System.Windows.Forms.TextBox
    Friend WithEvents dgvRentalLine As System.Windows.Forms.DataGridView
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtPreparedBy As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents part_id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents listCrew As System.Windows.Forms.ListBox
    Friend WithEvents cboCrewList As System.Windows.Forms.ComboBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents txtAssetNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
End Class
