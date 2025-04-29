<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_create_print
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
        Me.components = New System.ComponentModel.Container
        Me.dgv_created = New System.Windows.Forms.DataGridView
        Me.btn_save = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.cbo_print = New System.Windows.Forms.ComboBox
        Me.Button3 = New System.Windows.Forms.Button
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.PasteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.btn_uncheck_all = New System.Windows.Forms.Button
        Me.btn_chk_all = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        CType(Me.dgv_created, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgv_created
        '
        Me.dgv_created.AllowUserToAddRows = False
        Me.dgv_created.AllowUserToDeleteRows = False
        Me.dgv_created.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_created.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_created.Location = New System.Drawing.Point(3, 3)
        Me.dgv_created.Name = "dgv_created"
        Me.dgv_created.Size = New System.Drawing.Size(704, 299)
        Me.dgv_created.TabIndex = 5
        '
        'btn_save
        '
        Me.btn_save.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_save.Location = New System.Drawing.Point(337, 338)
        Me.btn_save.Name = "btn_save"
        Me.btn_save.Size = New System.Drawing.Size(119, 23)
        Me.btn_save.TabIndex = 6
        Me.btn_save.Text = "UPDATE/PRINT"
        Me.btn_save.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.Location = New System.Drawing.Point(463, 338)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(119, 23)
        Me.Button2.TabIndex = 7
        Me.Button2.Text = "CANCEL"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'cbo_print
        '
        Me.cbo_print.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbo_print.FormattingEnabled = True
        Me.cbo_print.Location = New System.Drawing.Point(340, 308)
        Me.cbo_print.Name = "cbo_print"
        Me.cbo_print.Size = New System.Drawing.Size(120, 21)
        Me.cbo_print.TabIndex = 32
        '
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button3.Location = New System.Drawing.Point(205, 338)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(119, 23)
        Me.Button3.TabIndex = 33
        Me.Button3.Text = "UPDATE"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PasteToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(103, 26)
        Me.ContextMenuStrip1.Text = "paste"
        '
        'PasteToolStripMenuItem
        '
        Me.PasteToolStripMenuItem.Name = "PasteToolStripMenuItem"
        Me.PasteToolStripMenuItem.Size = New System.Drawing.Size(102, 22)
        Me.PasteToolStripMenuItem.Text = "Paste"
        '
        'btn_uncheck_all
        '
        Me.btn_uncheck_all.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_uncheck_all.Location = New System.Drawing.Point(89, 338)
        Me.btn_uncheck_all.Name = "btn_uncheck_all"
        Me.btn_uncheck_all.Size = New System.Drawing.Size(107, 23)
        Me.btn_uncheck_all.TabIndex = 43
        Me.btn_uncheck_all.Text = "UN-CHECK ALL"
        Me.btn_uncheck_all.UseVisualStyleBackColor = True
        '
        'btn_chk_all
        '
        Me.btn_chk_all.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_chk_all.Location = New System.Drawing.Point(10, 338)
        Me.btn_chk_all.Name = "btn_chk_all"
        Me.btn_chk_all.Size = New System.Drawing.Size(75, 23)
        Me.btn_chk_all.TabIndex = 42
        Me.btn_chk_all.Text = "CHECK ALL"
        Me.btn_chk_all.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(588, 338)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(119, 23)
        Me.Button1.TabIndex = 44
        Me.Button1.Text = "EXIT"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'frm_create_print
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(710, 368)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btn_uncheck_all)
        Me.Controls.Add(Me.btn_chk_all)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.cbo_print)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.btn_save)
        Me.Controls.Add(Me.dgv_created)
        Me.Name = "frm_create_print"
        Me.Text = "HxPRO - CREATE"
        CType(Me.dgv_created, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgv_created As System.Windows.Forms.DataGridView
    Friend WithEvents btn_save As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents cbo_print As System.Windows.Forms.ComboBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents PasteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btn_uncheck_all As System.Windows.Forms.Button
    Friend WithEvents btn_chk_all As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
