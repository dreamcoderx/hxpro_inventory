<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_create
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.cbo_part = New System.Windows.Forms.ComboBox
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown
        Me.Label2 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.dgv_created = New System.Windows.Forms.DataGridView
        Me.btn_save = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.btn_browse = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txt_model = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.txt_description = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txt_part_number = New System.Windows.Forms.TextBox
        Me.txt_brand = New System.Windows.Forms.TextBox
        Me.txt_category = New System.Windows.Forms.TextBox
        Me.txt_sub_category = New System.Windows.Forms.TextBox
        Me.cbo_print = New System.Windows.Forms.ComboBox
        Me.Button3 = New System.Windows.Forms.Button
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_created, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(115, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "PART DESCRIPTION:"
        '
        'cbo_part
        '
        Me.cbo_part.FormattingEnabled = True
        Me.cbo_part.Location = New System.Drawing.Point(123, 24)
        Me.cbo_part.Name = "cbo_part"
        Me.cbo_part.Size = New System.Drawing.Size(243, 21)
        Me.cbo_part.TabIndex = 1
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Location = New System.Drawing.Point(242, 209)
        Me.NumericUpDown1.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(120, 20)
        Me.NumericUpDown1.TabIndex = 2
        Me.NumericUpDown1.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(193, 211)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "QTY:"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(369, 209)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(72, 24)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Create"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'dgv_created
        '
        Me.dgv_created.AllowUserToAddRows = False
        Me.dgv_created.AllowUserToDeleteRows = False
        Me.dgv_created.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_created.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_created.Location = New System.Drawing.Point(12, 237)
        Me.dgv_created.Name = "dgv_created"
        Me.dgv_created.Size = New System.Drawing.Size(695, 378)
        Me.dgv_created.TabIndex = 5
        '
        'btn_save
        '
        Me.btn_save.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_save.Location = New System.Drawing.Point(434, 651)
        Me.btn_save.Name = "btn_save"
        Me.btn_save.Size = New System.Drawing.Size(119, 23)
        Me.btn_save.TabIndex = 6
        Me.btn_save.Text = "PRINT"
        Me.btn_save.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.Location = New System.Drawing.Point(560, 651)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(119, 23)
        Me.Button2.TabIndex = 7
        Me.Button2.Text = "DELETE"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'btn_browse
        '
        Me.btn_browse.Location = New System.Drawing.Point(386, 22)
        Me.btn_browse.Name = "btn_browse"
        Me.btn_browse.Size = New System.Drawing.Size(72, 24)
        Me.btn_browse.TabIndex = 8
        Me.btn_browse.Text = "Browse"
        Me.btn_browse.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(27, 185)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(94, 13)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "SUB CATEGORY:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(51, 158)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 13)
        Me.Label5.TabIndex = 26
        Me.Label5.Text = "CATEGORY:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(72, 132)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 13)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "MODEL:"
        '
        'txt_model
        '
        Me.txt_model.Location = New System.Drawing.Point(123, 129)
        Me.txt_model.Name = "txt_model"
        Me.txt_model.ReadOnly = True
        Me.txt_model.Size = New System.Drawing.Size(239, 20)
        Me.txt_model.TabIndex = 23
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(72, 106)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 13)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "BRAND:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(37, 80)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(83, 13)
        Me.Label7.TabIndex = 21
        Me.Label7.Text = "DESCRIPTION:"
        '
        'txt_description
        '
        Me.txt_description.Location = New System.Drawing.Point(123, 77)
        Me.txt_description.Name = "txt_description"
        Me.txt_description.ReadOnly = True
        Me.txt_description.Size = New System.Drawing.Size(239, 20)
        Me.txt_description.TabIndex = 20
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(33, 54)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(89, 13)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "PART NUMBER:"
        '
        'txt_part_number
        '
        Me.txt_part_number.Location = New System.Drawing.Point(123, 51)
        Me.txt_part_number.Name = "txt_part_number"
        Me.txt_part_number.ReadOnly = True
        Me.txt_part_number.Size = New System.Drawing.Size(239, 20)
        Me.txt_part_number.TabIndex = 18
        '
        'txt_brand
        '
        Me.txt_brand.Location = New System.Drawing.Point(123, 103)
        Me.txt_brand.Name = "txt_brand"
        Me.txt_brand.ReadOnly = True
        Me.txt_brand.Size = New System.Drawing.Size(239, 20)
        Me.txt_brand.TabIndex = 29
        '
        'txt_category
        '
        Me.txt_category.Location = New System.Drawing.Point(123, 155)
        Me.txt_category.Name = "txt_category"
        Me.txt_category.ReadOnly = True
        Me.txt_category.Size = New System.Drawing.Size(239, 20)
        Me.txt_category.TabIndex = 30
        '
        'txt_sub_category
        '
        Me.txt_sub_category.Location = New System.Drawing.Point(123, 179)
        Me.txt_sub_category.Name = "txt_sub_category"
        Me.txt_sub_category.ReadOnly = True
        Me.txt_sub_category.Size = New System.Drawing.Size(239, 20)
        Me.txt_sub_category.TabIndex = 31
        '
        'cbo_print
        '
        Me.cbo_print.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbo_print.FormattingEnabled = True
        Me.cbo_print.Location = New System.Drawing.Point(434, 621)
        Me.cbo_print.Name = "cbo_print"
        Me.cbo_print.Size = New System.Drawing.Size(120, 21)
        Me.cbo_print.TabIndex = 32
        '
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button3.Location = New System.Drawing.Point(305, 651)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(119, 23)
        Me.Button3.TabIndex = 33
        Me.Button3.Text = "UPDATE"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'frm_create
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(710, 681)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.cbo_print)
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
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.btn_save)
        Me.Controls.Add(Me.dgv_created)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.NumericUpDown1)
        Me.Controls.Add(Me.cbo_part)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frm_create"
        Me.Text = "HxPRO - CREATE"
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_created, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbo_part As System.Windows.Forms.ComboBox
    Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents dgv_created As System.Windows.Forms.DataGridView
    Friend WithEvents btn_save As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
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
    Friend WithEvents cbo_print As System.Windows.Forms.ComboBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
End Class
