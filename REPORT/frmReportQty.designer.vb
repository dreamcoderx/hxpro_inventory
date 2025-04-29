<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReportQty
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
        Me.btn_clear = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtPartID = New System.Windows.Forms.TextBox()
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
        Me.dgv_parts.Location = New System.Drawing.Point(3, 167)
        Me.dgv_parts.Name = "dgv_parts"
        Me.dgv_parts.Size = New System.Drawing.Size(764, 448)
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
        Me.Label3.Location = New System.Drawing.Point(65, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "BRAND:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(65, 90)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "MODEL:"
        '
        'txt_model
        '
        Me.txt_model.Location = New System.Drawing.Point(117, 87)
        Me.txt_model.Name = "txt_model"
        Me.txt_model.Size = New System.Drawing.Size(475, 20)
        Me.txt_model.TabIndex = 8
        '
        'cbo_brand
        '
        Me.cbo_brand.FormattingEnabled = True
        Me.cbo_brand.Location = New System.Drawing.Point(117, 61)
        Me.cbo_brand.Name = "cbo_brand"
        Me.cbo_brand.Size = New System.Drawing.Size(540, 21)
        Me.cbo_brand.TabIndex = 12
        '
        'cbo_category
        '
        Me.cbo_category.FormattingEnabled = True
        Me.cbo_category.Location = New System.Drawing.Point(117, 113)
        Me.cbo_category.Name = "cbo_category"
        Me.cbo_category.Size = New System.Drawing.Size(475, 21)
        Me.cbo_category.TabIndex = 15
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(45, 116)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 13)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "CATEGORY:"
        '
        'cbo_sub_category
        '
        Me.cbo_sub_category.FormattingEnabled = True
        Me.cbo_sub_category.Location = New System.Drawing.Point(117, 140)
        Me.cbo_sub_category.Name = "cbo_sub_category"
        Me.cbo_sub_category.Size = New System.Drawing.Size(475, 21)
        Me.cbo_sub_category.TabIndex = 17
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(21, 143)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(94, 13)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "SUB CATEGORY:"
        '
        'cbo_part
        '
        Me.cbo_part.FormattingEnabled = True
        Me.cbo_part.Location = New System.Drawing.Point(116, 34)
        Me.cbo_part.Name = "cbo_part"
        Me.cbo_part.Size = New System.Drawing.Size(541, 21)
        Me.cbo_part.TabIndex = 21
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(115, 13)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "PART DESCRIPTION:"
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
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(61, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 38
        Me.Label2.Text = "PART ID:"
        '
        'txtPartID
        '
        Me.txtPartID.Location = New System.Drawing.Point(116, 11)
        Me.txtPartID.Name = "txtPartID"
        Me.txtPartID.Size = New System.Drawing.Size(475, 20)
        Me.txtPartID.TabIndex = 37
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(663, 87)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(111, 29)
        Me.Button1.TabIndex = 77
        Me.Button1.Text = "Export to Excel"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'frmReportQty
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(774, 627)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtPartID)
        Me.Controls.Add(Me.btn_clear)
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
        Me.Name = "frmReportQty"
        Me.Text = "REPORT - AVAILABLE QTY"
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
    Friend WithEvents btn_clear As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtPartID As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
