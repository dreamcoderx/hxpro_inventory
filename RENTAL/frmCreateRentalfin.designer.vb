<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCreateRentalfin
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
        Me.components = New System.ComponentModel.Container()
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btn_browse = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtModel = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtPartNumber = New System.Windows.Forms.TextBox()
        Me.txtBrand = New System.Windows.Forms.TextBox()
        Me.txt_category = New System.Windows.Forms.TextBox()
        Me.txt_sub_category = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtpartid = New System.Windows.Forms.TextBox()
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
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtPreparedBy = New System.Windows.Forms.TextBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.listCrew = New System.Windows.Forms.ListBox()
        Me.cboCrewList = New System.Windows.Forms.ComboBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.txtAssetNumber = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.dtpEventTo2 = New System.Windows.Forms.DateTimePicker()
        Me.dtpEventFrom2 = New System.Windows.Forms.DateTimePicker()
        Me.dtPickDelDate2 = New System.Windows.Forms.DateTimePicker()
        Me.dtpEventTo1 = New System.Windows.Forms.DateTimePicker()
        Me.dtpEventFrom1 = New System.Windows.Forms.DateTimePicker()
        Me.dtpickdeldate1 = New System.Windows.Forms.DateTimePicker()
        Me.txtUOM = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.txtMode = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.cmdAddEditDel = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.INSERTToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DELETEToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DELETEToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvRentalLine, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmdAddEditDel.SuspendLayout()
        Me.SuspendLayout()
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Location = New System.Drawing.Point(111, 314)
        Me.NumericUpDown1.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(65, 20)
        Me.NumericUpDown1.TabIndex = 7
        Me.NumericUpDown1.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(62, 316)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "QTY:"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(364, 313)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(72, 24)
        Me.btnSave.TabIndex = 9
        Me.btnSave.Text = "SAVE"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btn_browse
        '
        Me.btn_browse.Location = New System.Drawing.Point(361, 208)
        Me.btn_browse.Name = "btn_browse"
        Me.btn_browse.Size = New System.Drawing.Size(72, 24)
        Me.btn_browse.TabIndex = 8
        Me.btn_browse.Text = "SEARCH"
        Me.btn_browse.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(575, 288)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(94, 13)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "SUB CATEGORY:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(599, 261)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 13)
        Me.Label5.TabIndex = 26
        Me.Label5.Text = "CATEGORY:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(620, 235)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 13)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "MODEL:"
        '
        'txtModel
        '
        Me.txtModel.Location = New System.Drawing.Point(671, 232)
        Me.txtModel.Name = "txtModel"
        Me.txtModel.Size = New System.Drawing.Size(296, 20)
        Me.txtModel.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(60, 288)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 13)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "BRAND:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(25, 262)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(83, 13)
        Me.Label7.TabIndex = 21
        Me.Label7.Text = "DESCRIPTION:"
        '
        'txtDescription
        '
        Me.txtDescription.Location = New System.Drawing.Point(111, 259)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(451, 20)
        Me.txtDescription.TabIndex = 2
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(21, 239)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(89, 13)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "PART NUMBER:"
        '
        'txtPartNumber
        '
        Me.txtPartNumber.Location = New System.Drawing.Point(111, 236)
        Me.txtPartNumber.Name = "txtPartNumber"
        Me.txtPartNumber.Size = New System.Drawing.Size(451, 20)
        Me.txtPartNumber.TabIndex = 1
        '
        'txtBrand
        '
        Me.txtBrand.Location = New System.Drawing.Point(111, 285)
        Me.txtBrand.Name = "txtBrand"
        Me.txtBrand.Size = New System.Drawing.Size(451, 20)
        Me.txtBrand.TabIndex = 3
        '
        'txt_category
        '
        Me.txt_category.Location = New System.Drawing.Point(671, 258)
        Me.txt_category.Name = "txt_category"
        Me.txt_category.ReadOnly = True
        Me.txt_category.Size = New System.Drawing.Size(296, 20)
        Me.txt_category.TabIndex = 5
        '
        'txt_sub_category
        '
        Me.txt_sub_category.Location = New System.Drawing.Point(671, 282)
        Me.txt_sub_category.Name = "txt_sub_category"
        Me.txt_sub_category.ReadOnly = True
        Me.txt_sub_category.Size = New System.Drawing.Size(296, 20)
        Me.txt_sub_category.TabIndex = 6
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(56, 213)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(53, 13)
        Me.Label9.TabIndex = 33
        Me.Label9.Text = "PART ID:"
        '
        'txtpartid
        '
        Me.txtpartid.Location = New System.Drawing.Point(113, 210)
        Me.txtpartid.Name = "txtpartid"
        Me.txtpartid.ReadOnly = True
        Me.txtpartid.Size = New System.Drawing.Size(230, 20)
        Me.txtpartid.TabIndex = 0
        Me.txtpartid.Text = " "
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
        Me.txtRentalNO.Size = New System.Drawing.Size(230, 20)
        Me.txtRentalNO.TabIndex = 37
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(686, 57)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(64, 13)
        Me.Label10.TabIndex = 46
        Me.Label10.Text = "EVENT TO:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(673, 32)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(80, 13)
        Me.Label11.TabIndex = 45
        Me.Label11.Text = "EVENT FROM:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(59, 85)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(64, 13)
        Me.Label12.TabIndex = 44
        Me.Label12.Text = "LOCATION:"
        '
        'txtLocation
        '
        Me.txtLocation.Location = New System.Drawing.Point(128, 82)
        Me.txtLocation.Name = "txtLocation"
        Me.txtLocation.Size = New System.Drawing.Size(451, 20)
        Me.txtLocation.TabIndex = 40
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(640, 10)
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
        Me.txtDeliverTo.Size = New System.Drawing.Size(451, 20)
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
        Me.dgvRentalLine.Location = New System.Drawing.Point(13, 343)
        Me.dgvRentalLine.Name = "dgvRentalLine"
        Me.dgvRentalLine.ReadOnly = True
        Me.dgvRentalLine.Size = New System.Drawing.Size(1129, 347)
        Me.dgvRentalLine.TabIndex = 51
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(668, 84)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(86, 13)
        Me.Label16.TabIndex = 52
        Me.Label16.Text = "PREPARED BY:"
        '
        'txtPreparedBy
        '
        Me.txtPreparedBy.Location = New System.Drawing.Point(760, 81)
        Me.txtPreparedBy.Name = "txtPreparedBy"
        Me.txtPreparedBy.ReadOnly = True
        Me.txtPreparedBy.Size = New System.Drawing.Size(230, 20)
        Me.txtPreparedBy.TabIndex = 54
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(482, 5)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(108, 24)
        Me.Button4.TabIndex = 58
        Me.Button4.Text = "PRINT RENTAL"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(49, 113)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(69, 13)
        Me.Label17.TabIndex = 59
        Me.Label17.Text = "CREW LIST:"
        '
        'listCrew
        '
        Me.listCrew.FormattingEnabled = True
        Me.listCrew.Location = New System.Drawing.Point(443, 108)
        Me.listCrew.Name = "listCrew"
        Me.listCrew.Size = New System.Drawing.Size(230, 69)
        Me.listCrew.TabIndex = 60
        '
        'cboCrewList
        '
        Me.cboCrewList.FormattingEnabled = True
        Me.cboCrewList.Location = New System.Drawing.Point(126, 106)
        Me.cboCrewList.Name = "cboCrewList"
        Me.cboCrewList.Size = New System.Drawing.Size(230, 21)
        Me.cboCrewList.TabIndex = 61
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(365, 108)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(72, 24)
        Me.Button3.TabIndex = 62
        Me.Button3.Text = "ADD"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(365, 138)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(72, 24)
        Me.Button5.TabIndex = 63
        Me.Button5.Text = "REMOVE"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'txtAssetNumber
        '
        Me.txtAssetNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAssetNumber.Location = New System.Drawing.Point(114, 183)
        Me.txtAssetNumber.Name = "txtAssetNumber"
        Me.txtAssetNumber.Size = New System.Drawing.Size(227, 20)
        Me.txtAssetNumber.TabIndex = 65
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(12, 184)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(95, 13)
        Me.Label18.TabIndex = 64
        Me.Label18.Text = "ASSET NUMBER:"
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(365, 5)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(108, 24)
        Me.Button6.TabIndex = 66
        Me.Button6.Text = "UPDATE HEADER"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'dtpEventTo2
        '
        Me.dtpEventTo2.CustomFormat = "HH:mm"
        Me.dtpEventTo2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEventTo2.Location = New System.Drawing.Point(995, 54)
        Me.dtpEventTo2.Name = "dtpEventTo2"
        Me.dtpEventTo2.ShowUpDown = True
        Me.dtpEventTo2.Size = New System.Drawing.Size(95, 20)
        Me.dtpEventTo2.TabIndex = 72
        '
        'dtpEventFrom2
        '
        Me.dtpEventFrom2.CustomFormat = "HH:mm"
        Me.dtpEventFrom2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEventFrom2.Location = New System.Drawing.Point(995, 30)
        Me.dtpEventFrom2.Name = "dtpEventFrom2"
        Me.dtpEventFrom2.ShowUpDown = True
        Me.dtpEventFrom2.Size = New System.Drawing.Size(95, 20)
        Me.dtpEventFrom2.TabIndex = 71
        '
        'dtPickDelDate2
        '
        Me.dtPickDelDate2.CustomFormat = "HH:mm"
        Me.dtPickDelDate2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtPickDelDate2.Location = New System.Drawing.Point(995, 8)
        Me.dtPickDelDate2.Name = "dtPickDelDate2"
        Me.dtPickDelDate2.ShowUpDown = True
        Me.dtPickDelDate2.Size = New System.Drawing.Size(95, 20)
        Me.dtPickDelDate2.TabIndex = 70
        '
        'dtpEventTo1
        '
        Me.dtpEventTo1.Location = New System.Drawing.Point(759, 57)
        Me.dtpEventTo1.Name = "dtpEventTo1"
        Me.dtpEventTo1.Size = New System.Drawing.Size(230, 20)
        Me.dtpEventTo1.TabIndex = 69
        '
        'dtpEventFrom1
        '
        Me.dtpEventFrom1.Location = New System.Drawing.Point(759, 30)
        Me.dtpEventFrom1.Name = "dtpEventFrom1"
        Me.dtpEventFrom1.Size = New System.Drawing.Size(230, 20)
        Me.dtpEventFrom1.TabIndex = 68
        '
        'dtpickdeldate1
        '
        Me.dtpickdeldate1.Location = New System.Drawing.Point(759, 7)
        Me.dtpickdeldate1.Name = "dtpickdeldate1"
        Me.dtpickdeldate1.Size = New System.Drawing.Size(230, 20)
        Me.dtpickdeldate1.TabIndex = 67
        '
        'txtUOM
        '
        Me.txtUOM.Location = New System.Drawing.Point(229, 315)
        Me.txtUOM.Name = "txtUOM"
        Me.txtUOM.Size = New System.Drawing.Size(112, 20)
        Me.txtUOM.TabIndex = 73
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(191, 317)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(35, 13)
        Me.Label19.TabIndex = 74
        Me.Label19.Text = "UOM:"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(446, 313)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(72, 24)
        Me.btnCancel.TabIndex = 75
        Me.btnCancel.Text = "CANCEL"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'txtMode
        '
        Me.txtMode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMode.Location = New System.Drawing.Point(671, 308)
        Me.txtMode.Name = "txtMode"
        Me.txtMode.ReadOnly = True
        Me.txtMode.Size = New System.Drawing.Size(296, 20)
        Me.txtMode.TabIndex = 77
        Me.txtMode.Text = "ADD"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(626, 312)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(42, 13)
        Me.Label20.TabIndex = 76
        Me.Label20.Text = "MODE:"
        '
        'lblTotal
        '
        Me.lblTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Location = New System.Drawing.Point(1021, 700)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(28, 13)
        Me.lblTotal.TabIndex = 78
        Me.lblTotal.Text = "###"
        '
        'cmdAddEditDel
        '
        Me.cmdAddEditDel.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.INSERTToolStripMenuItem, Me.DELETEToolStripMenuItem, Me.DELETEToolStripMenuItem1})
        Me.cmdAddEditDel.Name = "cmCheckBox"
        Me.cmdAddEditDel.Size = New System.Drawing.Size(153, 92)
        '
        'INSERTToolStripMenuItem
        '
        Me.INSERTToolStripMenuItem.Name = "INSERTToolStripMenuItem"
        Me.INSERTToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.INSERTToolStripMenuItem.Text = "INSERT"
        '
        'DELETEToolStripMenuItem
        '
        Me.DELETEToolStripMenuItem.Name = "DELETEToolStripMenuItem"
        Me.DELETEToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.DELETEToolStripMenuItem.Text = "EDIT"
        '
        'DELETEToolStripMenuItem1
        '
        Me.DELETEToolStripMenuItem1.Name = "DELETEToolStripMenuItem1"
        Me.DELETEToolStripMenuItem1.Size = New System.Drawing.Size(165, 22)
        Me.DELETEToolStripMenuItem1.Text = "DELETE"
        '
        'frmCreateRentalfin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1154, 722)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.dgvRentalLine)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.txtMode)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.txtUOM)
        Me.Controls.Add(Me.dtpEventFrom2)
        Me.Controls.Add(Me.dtPickDelDate2)
        Me.Controls.Add(Me.dtpEventTo2)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.dtpEventTo1)
        Me.Controls.Add(Me.dtpEventFrom1)
        Me.Controls.Add(Me.dtpickdeldate1)
        Me.Controls.Add(Me.txtAssetNumber)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.cboCrewList)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.listCrew)
        Me.Controls.Add(Me.txtPreparedBy)
        Me.Controls.Add(Me.txtRentalNO)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtLocation)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtEvent)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtDeliverTo)
        Me.Controls.Add(Me.txtModel)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtpartid)
        Me.Controls.Add(Me.txt_sub_category)
        Me.Controls.Add(Me.txt_category)
        Me.Controls.Add(Me.txtBrand)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.NumericUpDown1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtDescription)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtPartNumber)
        Me.Controls.Add(Me.btn_browse)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.Label2)
        Me.Name = "frmCreateRentalfin"
        Me.Text = "RENTAL CREATE"
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvRentalLine, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmdAddEditDel.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btn_browse As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtModel As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtPartNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtBrand As System.Windows.Forms.TextBox
    Friend WithEvents txt_category As System.Windows.Forms.TextBox
    Friend WithEvents txt_sub_category As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtpartid As System.Windows.Forms.TextBox
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
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents listCrew As System.Windows.Forms.ListBox
    Friend WithEvents cboCrewList As System.Windows.Forms.ComboBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents txtAssetNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents dtpEventTo2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpEventFrom2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtPickDelDate2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpEventTo1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpEventFrom1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpickdeldate1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtUOM As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents txtMode As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents cmdAddEditDel As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents INSERTToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DELETEToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DELETEToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
End Class
