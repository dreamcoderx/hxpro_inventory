<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_item_list
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
        Me.dgv_parts = New System.Windows.Forms.DataGridView()
        Me.btn_search = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_model = New System.Windows.Forms.TextBox()
        Me.cbo_brand = New System.Windows.Forms.ComboBox()
        Me.cbo_category = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cbo_sub_category = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbo_part = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_asset_number = New System.Windows.Forms.TextBox()
        Me.cbo_print = New System.Windows.Forms.ComboBox()
        Me.btn_save = New System.Windows.Forms.Button()
        Me.btn_clear = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txt_serial_number = New System.Windows.Forms.TextBox()
        Me.btn_uncheck_all = New System.Windows.Forms.Button()
        Me.btn_chk_all = New System.Windows.Forms.Button()
        Me.btn_edit = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txt_num_from = New System.Windows.Forms.TextBox()
        Me.txt_num_to = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.dgv_parts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgv_parts
        '
        Me.dgv_parts.AllowUserToAddRows = False
        Me.dgv_parts.AllowUserToDeleteRows = False
        Me.dgv_parts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_parts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_parts.Location = New System.Drawing.Point(3, 215)
        Me.dgv_parts.Name = "dgv_parts"
        Me.dgv_parts.Size = New System.Drawing.Size(764, 382)
        Me.dgv_parts.TabIndex = 0
        '
        'btn_search
        '
        Me.btn_search.Location = New System.Drawing.Point(663, 33)
        Me.btn_search.Name = "btn_search"
        Me.btn_search.Size = New System.Drawing.Size(111, 23)
        Me.btn_search.TabIndex = 3
        Me.btn_search.Text = "&Search"
        Me.btn_search.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(65, 112)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "BRAND:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(65, 138)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "MODEL:"
        '
        'txt_model
        '
        Me.txt_model.Location = New System.Drawing.Point(117, 135)
        Me.txt_model.Name = "txt_model"
        Me.txt_model.Size = New System.Drawing.Size(475, 20)
        Me.txt_model.TabIndex = 8
        '
        'cbo_brand
        '
        Me.cbo_brand.FormattingEnabled = True
        Me.cbo_brand.Location = New System.Drawing.Point(117, 109)
        Me.cbo_brand.Name = "cbo_brand"
        Me.cbo_brand.Size = New System.Drawing.Size(540, 21)
        Me.cbo_brand.TabIndex = 12
        '
        'cbo_category
        '
        Me.cbo_category.FormattingEnabled = True
        Me.cbo_category.Location = New System.Drawing.Point(117, 161)
        Me.cbo_category.Name = "cbo_category"
        Me.cbo_category.Size = New System.Drawing.Size(475, 21)
        Me.cbo_category.TabIndex = 15
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(45, 164)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 13)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "CATEGORY:"
        '
        'cbo_sub_category
        '
        Me.cbo_sub_category.FormattingEnabled = True
        Me.cbo_sub_category.Location = New System.Drawing.Point(117, 188)
        Me.cbo_sub_category.Name = "cbo_sub_category"
        Me.cbo_sub_category.Size = New System.Drawing.Size(475, 21)
        Me.cbo_sub_category.TabIndex = 17
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(21, 191)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(94, 13)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "SUB CATEGORY:"
        '
        'cbo_part
        '
        Me.cbo_part.FormattingEnabled = True
        Me.cbo_part.Location = New System.Drawing.Point(116, 82)
        Me.cbo_part.Name = "cbo_part"
        Me.cbo_part.Size = New System.Drawing.Size(541, 21)
        Me.cbo_part.TabIndex = 21
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 86)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(115, 13)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "PART DESCRIPTION:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(23, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 13)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "ASSET NUMBER:"
        '
        'txt_asset_number
        '
        Me.txt_asset_number.Location = New System.Drawing.Point(118, 35)
        Me.txt_asset_number.Name = "txt_asset_number"
        Me.txt_asset_number.Size = New System.Drawing.Size(539, 20)
        Me.txt_asset_number.TabIndex = 22
        '
        'cbo_print
        '
        Me.cbo_print.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cbo_print.FormattingEnabled = True
        Me.cbo_print.Location = New System.Drawing.Point(587, 606)
        Me.cbo_print.Name = "cbo_print"
        Me.cbo_print.Size = New System.Drawing.Size(180, 21)
        Me.cbo_print.TabIndex = 34
        '
        'btn_save
        '
        Me.btn_save.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_save.Location = New System.Drawing.Point(460, 604)
        Me.btn_save.Name = "btn_save"
        Me.btn_save.Size = New System.Drawing.Size(119, 23)
        Me.btn_save.TabIndex = 33
        Me.btn_save.Text = "PRINT TAG"
        Me.btn_save.UseVisualStyleBackColor = True
        '
        'btn_clear
        '
        Me.btn_clear.Location = New System.Drawing.Point(663, 59)
        Me.btn_clear.Name = "btn_clear"
        Me.btn_clear.Size = New System.Drawing.Size(111, 23)
        Me.btn_clear.TabIndex = 36
        Me.btn_clear.Text = "&Clear"
        Me.btn_clear.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(663, 119)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(111, 23)
        Me.Button2.TabIndex = 37
        Me.Button2.Text = "&Delete"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(21, 63)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(98, 13)
        Me.Label7.TabIndex = 39
        Me.Label7.Text = "SERIAL NUMBER:"
        '
        'txt_serial_number
        '
        Me.txt_serial_number.Location = New System.Drawing.Point(119, 60)
        Me.txt_serial_number.Name = "txt_serial_number"
        Me.txt_serial_number.Size = New System.Drawing.Size(539, 20)
        Me.txt_serial_number.TabIndex = 38
        '
        'btn_uncheck_all
        '
        Me.btn_uncheck_all.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_uncheck_all.Location = New System.Drawing.Point(207, 603)
        Me.btn_uncheck_all.Name = "btn_uncheck_all"
        Me.btn_uncheck_all.Size = New System.Drawing.Size(107, 23)
        Me.btn_uncheck_all.TabIndex = 41
        Me.btn_uncheck_all.Text = "UN-CHECK ALL"
        Me.btn_uncheck_all.UseVisualStyleBackColor = True
        '
        'btn_chk_all
        '
        Me.btn_chk_all.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_chk_all.Location = New System.Drawing.Point(128, 603)
        Me.btn_chk_all.Name = "btn_chk_all"
        Me.btn_chk_all.Size = New System.Drawing.Size(75, 23)
        Me.btn_chk_all.TabIndex = 40
        Me.btn_chk_all.Text = "CHECK ALL"
        Me.btn_chk_all.UseVisualStyleBackColor = True
        '
        'btn_edit
        '
        Me.btn_edit.Location = New System.Drawing.Point(663, 88)
        Me.btn_edit.Name = "btn_edit"
        Me.btn_edit.Size = New System.Drawing.Size(111, 23)
        Me.btn_edit.TabIndex = 42
        Me.btn_edit.Text = "&Edit"
        Me.btn_edit.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(32, 13)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(86, 13)
        Me.Label8.TabIndex = 43
        Me.Label8.Text = "ITEM NUMBER:"
        '
        'txt_num_from
        '
        Me.txt_num_from.Location = New System.Drawing.Point(119, 10)
        Me.txt_num_from.Name = "txt_num_from"
        Me.txt_num_from.Size = New System.Drawing.Size(108, 20)
        Me.txt_num_from.TabIndex = 44
        '
        'txt_num_to
        '
        Me.txt_num_to.Location = New System.Drawing.Point(267, 10)
        Me.txt_num_to.Name = "txt_num_to"
        Me.txt_num_to.Size = New System.Drawing.Size(108, 20)
        Me.txt_num_to.TabIndex = 45
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(237, 12)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(22, 13)
        Me.Label9.TabIndex = 46
        Me.Label9.Text = "TO"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(663, 148)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(111, 23)
        Me.Button1.TabIndex = 47
        Me.Button1.Text = "&Search/Report"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'frm_item_list
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(774, 627)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txt_num_to)
        Me.Controls.Add(Me.txt_num_from)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.btn_edit)
        Me.Controls.Add(Me.btn_uncheck_all)
        Me.Controls.Add(Me.btn_chk_all)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txt_serial_number)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.btn_clear)
        Me.Controls.Add(Me.cbo_print)
        Me.Controls.Add(Me.btn_save)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txt_asset_number)
        Me.Controls.Add(Me.cbo_part)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbo_sub_category)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cbo_category)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cbo_brand)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txt_model)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btn_search)
        Me.Controls.Add(Me.dgv_parts)
        Me.Name = "frm_item_list"
        Me.Text = "ASSET LIST"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgv_parts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgv_parts As System.Windows.Forms.DataGridView
    Friend WithEvents btn_search As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_model As System.Windows.Forms.TextBox
    Friend WithEvents cbo_brand As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_category As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cbo_sub_category As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cbo_part As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_asset_number As System.Windows.Forms.TextBox
    Friend WithEvents cbo_print As System.Windows.Forms.ComboBox
    Friend WithEvents btn_save As System.Windows.Forms.Button
    Friend WithEvents btn_clear As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txt_serial_number As System.Windows.Forms.TextBox
    Friend WithEvents btn_uncheck_all As System.Windows.Forms.Button
    Friend WithEvents btn_chk_all As System.Windows.Forms.Button
    Friend WithEvents btn_edit As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txt_num_from As System.Windows.Forms.TextBox
    Friend WithEvents txt_num_to As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
