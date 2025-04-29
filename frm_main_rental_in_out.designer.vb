<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_main_rental_in_out
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_main_rental_in_out))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.CREATERENTALToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CREATEToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VIEWToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RENTALCHECKOUTToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CHECKINToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CREATERENTALToolStripMenuItem, Me.RENTALCHECKOUTToolStripMenuItem, Me.CHECKINToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1059, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'CREATERENTALToolStripMenuItem
        '
        Me.CREATERENTALToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CREATEToolStripMenuItem, Me.VIEWToolStripMenuItem})
        Me.CREATERENTALToolStripMenuItem.Name = "CREATERENTALToolStripMenuItem"
        Me.CREATERENTALToolStripMenuItem.Size = New System.Drawing.Size(62, 20)
        Me.CREATERENTALToolStripMenuItem.Text = "RENTAL"
        '
        'CREATEToolStripMenuItem
        '
        Me.CREATEToolStripMenuItem.Name = "CREATEToolStripMenuItem"
        Me.CREATEToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.CREATEToolStripMenuItem.Text = "CREATE"
        '
        'VIEWToolStripMenuItem
        '
        Me.VIEWToolStripMenuItem.Name = "VIEWToolStripMenuItem"
        Me.VIEWToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.VIEWToolStripMenuItem.Text = "VIEW"
        '
        'RENTALCHECKOUTToolStripMenuItem
        '
        Me.RENTALCHECKOUTToolStripMenuItem.Name = "RENTALCHECKOUTToolStripMenuItem"
        Me.RENTALCHECKOUTToolStripMenuItem.Size = New System.Drawing.Size(130, 20)
        Me.RENTALCHECKOUTToolStripMenuItem.Text = "RENTAL CHECK OUT"
        '
        'CHECKINToolStripMenuItem
        '
        Me.CHECKINToolStripMenuItem.Name = "CHECKINToolStripMenuItem"
        Me.CHECKINToolStripMenuItem.Size = New System.Drawing.Size(118, 20)
        Me.CHECKINToolStripMenuItem.Text = "RENTAL CHECK IN"
        '
        'frm_main_rental_in_out
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1059, 580)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frm_main_rental_in_out"
        Me.Text = "HxPRO - BARCODE INVENTORY SYSTEM"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents CREATERENTALToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RENTALCHECKOUTToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CREATEToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VIEWToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CHECKINToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
