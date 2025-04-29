<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_sub_category
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
        Me.dgv_brand = New System.Windows.Forms.DataGridView()
        Me.txt_sub_cat_code = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_new = New System.Windows.Forms.Button()
        Me.btn_edit = New System.Windows.Forms.Button()
        Me.btn_delete = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_sub_cat_desc = New System.Windows.Forms.TextBox()
        Me.cbo_category = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.dgv_brand, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgv_brand
        '
        Me.dgv_brand.AllowUserToAddRows = False
        Me.dgv_brand.AllowUserToDeleteRows = False
        Me.dgv_brand.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_brand.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_brand.Location = New System.Drawing.Point(2, 126)
        Me.dgv_brand.Name = "dgv_brand"
        Me.dgv_brand.ReadOnly = True
        Me.dgv_brand.Size = New System.Drawing.Size(534, 414)
        Me.dgv_brand.TabIndex = 7
        '
        'txt_sub_cat_code
        '
        Me.txt_sub_cat_code.Location = New System.Drawing.Point(136, 36)
        Me.txt_sub_cat_code.MaxLength = 10
        Me.txt_sub_cat_code.Name = "txt_sub_cat_code"
        Me.txt_sub_cat_code.Size = New System.Drawing.Size(213, 20)
        Me.txt_sub_cat_code.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(127, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "SUB-CATEGORY CODE:"
        '
        'btn_new
        '
        Me.btn_new.Location = New System.Drawing.Point(460, 36)
        Me.btn_new.Name = "btn_new"
        Me.btn_new.Size = New System.Drawing.Size(75, 23)
        Me.btn_new.TabIndex = 4
        Me.btn_new.Text = "&New"
        Me.btn_new.UseVisualStyleBackColor = True
        '
        'btn_edit
        '
        Me.btn_edit.Location = New System.Drawing.Point(460, 65)
        Me.btn_edit.Name = "btn_edit"
        Me.btn_edit.Size = New System.Drawing.Size(75, 23)
        Me.btn_edit.TabIndex = 5
        Me.btn_edit.Text = "&Edit"
        Me.btn_edit.UseVisualStyleBackColor = True
        '
        'btn_delete
        '
        Me.btn_delete.Location = New System.Drawing.Point(460, 93)
        Me.btn_delete.Name = "btn_delete"
        Me.btn_delete.Size = New System.Drawing.Size(75, 23)
        Me.btn_delete.TabIndex = 6
        Me.btn_delete.Text = "&Delete"
        Me.btn_delete.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(25, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "DESCRIPTION:"
        '
        'txt_sub_cat_desc
        '
        Me.txt_sub_cat_desc.Location = New System.Drawing.Point(136, 66)
        Me.txt_sub_cat_desc.MaxLength = 50
        Me.txt_sub_cat_desc.Name = "txt_sub_cat_desc"
        Me.txt_sub_cat_desc.Size = New System.Drawing.Size(318, 20)
        Me.txt_sub_cat_desc.TabIndex = 2
        '
        'cbo_category
        '
        Me.cbo_category.FormattingEnabled = True
        Me.cbo_category.Location = New System.Drawing.Point(133, 8)
        Me.cbo_category.Name = "cbo_category"
        Me.cbo_category.Size = New System.Drawing.Size(216, 21)
        Me.cbo_category.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(62, 11)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 13)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "CATEGORY:"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(459, 7)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "&Search"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'frm_sub_category
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(547, 556)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.cbo_category)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txt_sub_cat_desc)
        Me.Controls.Add(Me.btn_delete)
        Me.Controls.Add(Me.btn_edit)
        Me.Controls.Add(Me.btn_new)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txt_sub_cat_code)
        Me.Controls.Add(Me.dgv_brand)
        Me.Name = "frm_sub_category"
        Me.Text = "SUB CATEGORY"
        CType(Me.dgv_brand, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgv_brand As System.Windows.Forms.DataGridView
    Friend WithEvents txt_sub_cat_code As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn_new As System.Windows.Forms.Button
    Friend WithEvents btn_edit As System.Windows.Forms.Button
    Friend WithEvents btn_delete As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_sub_cat_desc As System.Windows.Forms.TextBox
    Friend WithEvents cbo_category As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
