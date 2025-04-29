<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_category
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
        Me.txt_category_code = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_new = New System.Windows.Forms.Button()
        Me.btn_edit = New System.Windows.Forms.Button()
        Me.btn_delete = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_category_description = New System.Windows.Forms.TextBox()
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
        Me.dgv_brand.Location = New System.Drawing.Point(2, 94)
        Me.dgv_brand.Name = "dgv_brand"
        Me.dgv_brand.ReadOnly = True
        Me.dgv_brand.Size = New System.Drawing.Size(624, 446)
        Me.dgv_brand.TabIndex = 0
        '
        'txt_category_code
        '
        Me.txt_category_code.Location = New System.Drawing.Point(118, 30)
        Me.txt_category_code.MaxLength = 10
        Me.txt_category_code.Name = "txt_category_code"
        Me.txt_category_code.Size = New System.Drawing.Size(184, 20)
        Me.txt_category_code.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(102, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "CATEGORY CODE:"
        '
        'btn_new
        '
        Me.btn_new.Location = New System.Drawing.Point(525, 8)
        Me.btn_new.Name = "btn_new"
        Me.btn_new.Size = New System.Drawing.Size(75, 23)
        Me.btn_new.TabIndex = 2
        Me.btn_new.Text = "&New"
        Me.btn_new.UseVisualStyleBackColor = True
        '
        'btn_edit
        '
        Me.btn_edit.Location = New System.Drawing.Point(525, 37)
        Me.btn_edit.Name = "btn_edit"
        Me.btn_edit.Size = New System.Drawing.Size(75, 23)
        Me.btn_edit.TabIndex = 3
        Me.btn_edit.Text = "&Edit"
        Me.btn_edit.UseVisualStyleBackColor = True
        '
        'btn_delete
        '
        Me.btn_delete.Location = New System.Drawing.Point(525, 65)
        Me.btn_delete.Name = "btn_delete"
        Me.btn_delete.Size = New System.Drawing.Size(75, 23)
        Me.btn_delete.TabIndex = 4
        Me.btn_delete.Text = "&Delete"
        Me.btn_delete.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(30, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "DESCRIPTION:"
        '
        'txt_category_description
        '
        Me.txt_category_description.Location = New System.Drawing.Point(118, 60)
        Me.txt_category_description.MaxLength = 50
        Me.txt_category_description.Name = "txt_category_description"
        Me.txt_category_description.Size = New System.Drawing.Size(401, 20)
        Me.txt_category_description.TabIndex = 1
        '
        'frm_category
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(637, 556)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txt_category_description)
        Me.Controls.Add(Me.btn_delete)
        Me.Controls.Add(Me.btn_edit)
        Me.Controls.Add(Me.btn_new)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txt_category_code)
        Me.Controls.Add(Me.dgv_brand)
        Me.Name = "frm_category"
        Me.Text = "CATEGORY"
        CType(Me.dgv_brand, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgv_brand As System.Windows.Forms.DataGridView
    Friend WithEvents txt_category_code As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn_new As System.Windows.Forms.Button
    Friend WithEvents btn_edit As System.Windows.Forms.Button
    Friend WithEvents btn_delete As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_category_description As System.Windows.Forms.TextBox
End Class
