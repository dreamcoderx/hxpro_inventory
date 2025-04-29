<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_part1
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
        Me.txt_part_number = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_search = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_description = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_model = New System.Windows.Forms.TextBox()
        Me.btn_new = New System.Windows.Forms.Button()
        Me.btn_edit = New System.Windows.Forms.Button()
        Me.cbo_brand = New System.Windows.Forms.ComboBox()
        Me.btn_delete = New System.Windows.Forms.Button()
        Me.cbo_category = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cbo_sub_category = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.btn_clear = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txt_part_id = New System.Windows.Forms.TextBox()
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
        Me.dgv_parts.Location = New System.Drawing.Point(3, 189)
        Me.dgv_parts.Name = "dgv_parts"
        Me.dgv_parts.ReadOnly = True
        Me.dgv_parts.Size = New System.Drawing.Size(755, 282)
        Me.dgv_parts.TabIndex = 0
        '
        'txt_part_number
        '
        Me.txt_part_number.Location = New System.Drawing.Point(102, 31)
        Me.txt_part_number.MaxLength = 30
        Me.txt_part_number.Name = "txt_part_number"
        Me.txt_part_number.Size = New System.Drawing.Size(386, 20)
        Me.txt_part_number.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "PART NUMBER:"
        '
        'btn_search
        '
        Me.btn_search.Location = New System.Drawing.Point(644, 7)
        Me.btn_search.Name = "btn_search"
        Me.btn_search.Size = New System.Drawing.Size(111, 23)
        Me.btn_search.TabIndex = 7
        Me.btn_search.Text = "&Search"
        Me.btn_search.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "DESCRIPTION:"
        '
        'txt_description
        '
        Me.txt_description.Location = New System.Drawing.Point(102, 57)
        Me.txt_description.MaxLength = 150
        Me.txt_description.Name = "txt_description"
        Me.txt_description.Size = New System.Drawing.Size(525, 20)
        Me.txt_description.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(50, 86)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "BRAND:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(50, 112)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "MODEL:"
        '
        'txt_model
        '
        Me.txt_model.Location = New System.Drawing.Point(102, 109)
        Me.txt_model.MaxLength = 30
        Me.txt_model.Name = "txt_model"
        Me.txt_model.Size = New System.Drawing.Size(386, 20)
        Me.txt_model.TabIndex = 4
        '
        'btn_new
        '
        Me.btn_new.Location = New System.Drawing.Point(644, 34)
        Me.btn_new.Name = "btn_new"
        Me.btn_new.Size = New System.Drawing.Size(111, 23)
        Me.btn_new.TabIndex = 8
        Me.btn_new.Text = "&New"
        Me.btn_new.UseVisualStyleBackColor = True
        '
        'btn_edit
        '
        Me.btn_edit.Location = New System.Drawing.Point(644, 63)
        Me.btn_edit.Name = "btn_edit"
        Me.btn_edit.Size = New System.Drawing.Size(111, 23)
        Me.btn_edit.TabIndex = 9
        Me.btn_edit.Text = "&Edit"
        Me.btn_edit.UseVisualStyleBackColor = True
        '
        'cbo_brand
        '
        Me.cbo_brand.FormattingEnabled = True
        Me.cbo_brand.Location = New System.Drawing.Point(102, 83)
        Me.cbo_brand.Name = "cbo_brand"
        Me.cbo_brand.Size = New System.Drawing.Size(386, 21)
        Me.cbo_brand.TabIndex = 3
        '
        'btn_delete
        '
        Me.btn_delete.Location = New System.Drawing.Point(644, 92)
        Me.btn_delete.Name = "btn_delete"
        Me.btn_delete.Size = New System.Drawing.Size(111, 23)
        Me.btn_delete.TabIndex = 10
        Me.btn_delete.Text = "&Delete"
        Me.btn_delete.UseVisualStyleBackColor = True
        '
        'cbo_category
        '
        Me.cbo_category.FormattingEnabled = True
        Me.cbo_category.Location = New System.Drawing.Point(102, 135)
        Me.cbo_category.Name = "cbo_category"
        Me.cbo_category.Size = New System.Drawing.Size(386, 21)
        Me.cbo_category.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(30, 138)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 13)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "CATEGORY:"
        '
        'cbo_sub_category
        '
        Me.cbo_sub_category.FormattingEnabled = True
        Me.cbo_sub_category.Location = New System.Drawing.Point(102, 162)
        Me.cbo_sub_category.Name = "cbo_sub_category"
        Me.cbo_sub_category.Size = New System.Drawing.Size(386, 21)
        Me.cbo_sub_category.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 165)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(94, 13)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "SUB CATEGORY:"
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(530, 477)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(111, 23)
        Me.Button1.TabIndex = 18
        Me.Button1.Text = "&OK"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.Location = New System.Drawing.Point(647, 477)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(111, 23)
        Me.Button2.TabIndex = 19
        Me.Button2.Text = "&Cancel"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'btn_clear
        '
        Me.btn_clear.Location = New System.Drawing.Point(644, 121)
        Me.btn_clear.Name = "btn_clear"
        Me.btn_clear.Size = New System.Drawing.Size(111, 23)
        Me.btn_clear.TabIndex = 11
        Me.btn_clear.Text = "&Clear"
        Me.btn_clear.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(48, 10)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 13)
        Me.Label7.TabIndex = 21
        Me.Label7.Text = "PART ID:"
        '
        'txt_part_id
        '
        Me.txt_part_id.Location = New System.Drawing.Point(102, 7)
        Me.txt_part_id.MaxLength = 30
        Me.txt_part_id.Name = "txt_part_id"
        Me.txt_part_id.Size = New System.Drawing.Size(242, 20)
        Me.txt_part_id.TabIndex = 0
        '
        'frm_part
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(759, 504)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txt_part_id)
        Me.Controls.Add(Me.btn_clear)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.cbo_sub_category)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cbo_category)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btn_delete)
        Me.Controls.Add(Me.cbo_brand)
        Me.Controls.Add(Me.btn_edit)
        Me.Controls.Add(Me.btn_new)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txt_model)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txt_description)
        Me.Controls.Add(Me.btn_search)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txt_part_number)
        Me.Controls.Add(Me.dgv_parts)
        Me.Name = "frm_part"
        Me.Text = "PART"
        CType(Me.dgv_parts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgv_parts As System.Windows.Forms.DataGridView
    Friend WithEvents txt_part_number As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn_search As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_description As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_model As System.Windows.Forms.TextBox
    Friend WithEvents btn_new As System.Windows.Forms.Button
    Friend WithEvents btn_edit As System.Windows.Forms.Button
    Friend WithEvents cbo_brand As System.Windows.Forms.ComboBox
    Friend WithEvents btn_delete As System.Windows.Forms.Button
    Friend WithEvents cbo_category As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cbo_sub_category As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents btn_clear As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txt_part_id As System.Windows.Forms.TextBox
End Class
