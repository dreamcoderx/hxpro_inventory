<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRepairView
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
        Me.dgvRentalHDR = New System.Windows.Forms.DataGridView()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lblRentalID = New System.Windows.Forms.Label()
        Me.lblRentalNo = New System.Windows.Forms.Label()
        CType(Me.dgvRentalHDR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvRentalHDR
        '
        Me.dgvRentalHDR.AllowUserToAddRows = False
        Me.dgvRentalHDR.AllowUserToDeleteRows = False
        Me.dgvRentalHDR.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvRentalHDR.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRentalHDR.Location = New System.Drawing.Point(12, 12)
        Me.dgvRentalHDR.Name = "dgvRentalHDR"
        Me.dgvRentalHDR.ReadOnly = True
        Me.dgvRentalHDR.Size = New System.Drawing.Size(1030, 277)
        Me.dgvRentalHDR.TabIndex = 52
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button2.Location = New System.Drawing.Point(12, 301)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(72, 24)
        Me.Button2.TabIndex = 56
        Me.Button2.Text = "EDIT"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(90, 301)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(72, 24)
        Me.Button1.TabIndex = 57
        Me.Button1.Text = "DELETE"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'lblRentalID
        '
        Me.lblRentalID.AutoSize = True
        Me.lblRentalID.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRentalID.Location = New System.Drawing.Point(196, 299)
        Me.lblRentalID.Name = "lblRentalID"
        Me.lblRentalID.Size = New System.Drawing.Size(43, 24)
        Me.lblRentalID.TabIndex = 58
        Me.lblRentalID.Text = "xxx"
        Me.lblRentalID.Visible = False
        '
        'lblRentalNo
        '
        Me.lblRentalNo.AutoSize = True
        Me.lblRentalNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRentalNo.Location = New System.Drawing.Point(243, 299)
        Me.lblRentalNo.Name = "lblRentalNo"
        Me.lblRentalNo.Size = New System.Drawing.Size(43, 24)
        Me.lblRentalNo.TabIndex = 59
        Me.lblRentalNo.Text = "xxx"
        Me.lblRentalNo.Visible = False
        '
        'frmRentalCheckOutVw
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1054, 333)
        Me.Controls.Add(Me.lblRentalNo)
        Me.Controls.Add(Me.lblRentalID)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.dgvRentalHDR)
        Me.Name = "frmRentalCheckOutVw"
        Me.Text = "REPAIR"
        CType(Me.dgvRentalHDR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvRentalHDR As System.Windows.Forms.DataGridView
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents lblRentalID As System.Windows.Forms.Label
    Friend WithEvents lblRentalNo As System.Windows.Forms.Label
End Class
