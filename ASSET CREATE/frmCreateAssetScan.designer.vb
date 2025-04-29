<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCreateAssetScan
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
        Me.txtAssetNumber = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvAssetList = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtSerialNumber = New System.Windows.Forms.TextBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        CType(Me.dgvAssetList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(415, 220)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(72, 24)
        Me.Button1.TabIndex = 9
        Me.Button1.Text = "Create"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btn_browse
        '
        Me.btn_browse.Location = New System.Drawing.Point(362, 9)
        Me.btn_browse.Name = "btn_browse"
        Me.btn_browse.Size = New System.Drawing.Size(72, 24)
        Me.btn_browse.TabIndex = 8
        Me.btn_browse.Text = "Search"
        Me.btn_browse.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(18, 169)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(94, 13)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "SUB CATEGORY:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(42, 142)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 13)
        Me.Label5.TabIndex = 26
        Me.Label5.Text = "CATEGORY:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(63, 116)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 13)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "MODEL:"
        '
        'txt_model
        '
        Me.txt_model.Location = New System.Drawing.Point(114, 113)
        Me.txt_model.Name = "txt_model"
        Me.txt_model.ReadOnly = True
        Me.txt_model.Size = New System.Drawing.Size(451, 20)
        Me.txt_model.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(63, 90)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 13)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "BRAND:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(28, 64)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(83, 13)
        Me.Label7.TabIndex = 21
        Me.Label7.Text = "DESCRIPTION:"
        '
        'txt_description
        '
        Me.txt_description.Location = New System.Drawing.Point(114, 61)
        Me.txt_description.Name = "txt_description"
        Me.txt_description.ReadOnly = True
        Me.txt_description.Size = New System.Drawing.Size(451, 20)
        Me.txt_description.TabIndex = 2
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(24, 41)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(89, 13)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "PART NUMBER:"
        '
        'txt_part_number
        '
        Me.txt_part_number.Location = New System.Drawing.Point(114, 38)
        Me.txt_part_number.Name = "txt_part_number"
        Me.txt_part_number.ReadOnly = True
        Me.txt_part_number.Size = New System.Drawing.Size(622, 20)
        Me.txt_part_number.TabIndex = 1
        '
        'txt_brand
        '
        Me.txt_brand.Location = New System.Drawing.Point(114, 87)
        Me.txt_brand.Name = "txt_brand"
        Me.txt_brand.ReadOnly = True
        Me.txt_brand.Size = New System.Drawing.Size(451, 20)
        Me.txt_brand.TabIndex = 3
        '
        'txt_category
        '
        Me.txt_category.Location = New System.Drawing.Point(114, 139)
        Me.txt_category.Name = "txt_category"
        Me.txt_category.ReadOnly = True
        Me.txt_category.Size = New System.Drawing.Size(451, 20)
        Me.txt_category.TabIndex = 5
        '
        'txt_sub_category
        '
        Me.txt_sub_category.Location = New System.Drawing.Point(114, 163)
        Me.txt_sub_category.Name = "txt_sub_category"
        Me.txt_sub_category.ReadOnly = True
        Me.txt_sub_category.Size = New System.Drawing.Size(451, 20)
        Me.txt_sub_category.TabIndex = 6
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(57, 15)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(53, 13)
        Me.Label9.TabIndex = 33
        Me.Label9.Text = "PART ID:"
        '
        'txt_part_id
        '
        Me.txt_part_id.Location = New System.Drawing.Point(114, 12)
        Me.txt_part_id.Name = "txt_part_id"
        Me.txt_part_id.ReadOnly = True
        Me.txt_part_id.Size = New System.Drawing.Size(230, 20)
        Me.txt_part_id.TabIndex = 0
        '
        'txtAssetNumber
        '
        Me.txtAssetNumber.Location = New System.Drawing.Point(114, 199)
        Me.txtAssetNumber.Name = "txtAssetNumber"
        Me.txtAssetNumber.Size = New System.Drawing.Size(274, 20)
        Me.txtAssetNumber.TabIndex = 34
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 202)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 13)
        Me.Label1.TabIndex = 35
        Me.Label1.Text = "ASSET NUMBER:"
        '
        'dgvAssetList
        '
        Me.dgvAssetList.AllowUserToAddRows = False
        Me.dgvAssetList.AllowUserToDeleteRows = False
        Me.dgvAssetList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvAssetList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAssetList.Location = New System.Drawing.Point(27, 282)
        Me.dgvAssetList.Name = "dgvAssetList"
        Me.dgvAssetList.ReadOnly = True
        Me.dgvAssetList.Size = New System.Drawing.Size(538, 149)
        Me.dgvAssetList.TabIndex = 65
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 226)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 13)
        Me.Label2.TabIndex = 67
        Me.Label2.Text = "SERIAL NUMBER:"
        '
        'txtSerialNumber
        '
        Me.txtSerialNumber.Location = New System.Drawing.Point(114, 223)
        Me.txtSerialNumber.Name = "txtSerialNumber"
        Me.txtSerialNumber.Size = New System.Drawing.Size(274, 20)
        Me.txtSerialNumber.TabIndex = 66
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(142, 252)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(10, 13)
        Me.lblStatus.TabIndex = 68
        Me.lblStatus.Text = "-"
        '
        'frmCreateAssetScan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(768, 467)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtSerialNumber)
        Me.Controls.Add(Me.dgvAssetList)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtAssetNumber)
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
        Me.Name = "frmCreateAssetScan"
        Me.Text = "ASSET CREATE"
        CType(Me.dgvAssetList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
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
    Friend WithEvents txtAssetNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvAssetList As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtSerialNumber As System.Windows.Forms.TextBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
End Class
