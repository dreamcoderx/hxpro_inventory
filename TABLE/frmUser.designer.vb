<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUser
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
        Me.components = New System.ComponentModel.Container()
        Me.dgvUser = New System.Windows.Forms.DataGridView()
        Me.txt_user_name = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_new = New System.Windows.Forms.Button()
        Me.btn_edit = New System.Windows.Forms.Button()
        Me.txt_user_id = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbo_acct_id = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_old_password = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt_password = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txt_confirm_password = New System.Windows.Forms.TextBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.cmdAddEditDel = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.INSERTToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DELETEToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.dgvUser, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmdAddEditDel.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvUser
        '
        Me.dgvUser.AllowUserToAddRows = False
        Me.dgvUser.AllowUserToDeleteRows = False
        Me.dgvUser.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvUser.Location = New System.Drawing.Point(1, 194)
        Me.dgvUser.Name = "dgvUser"
        Me.dgvUser.ReadOnly = True
        Me.dgvUser.Size = New System.Drawing.Size(615, 374)
        Me.dgvUser.TabIndex = 0
        '
        'txt_user_name
        '
        Me.txt_user_name.Enabled = False
        Me.txt_user_name.Location = New System.Drawing.Point(151, 34)
        Me.txt_user_name.MaxLength = 50
        Me.txt_user_name.Name = "txt_user_name"
        Me.txt_user_name.Size = New System.Drawing.Size(235, 20)
        Me.txt_user_name.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(92, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "USER ID:"
        '
        'btn_new
        '
        Me.btn_new.Location = New System.Drawing.Point(415, 8)
        Me.btn_new.Name = "btn_new"
        Me.btn_new.Size = New System.Drawing.Size(75, 23)
        Me.btn_new.TabIndex = 3
        Me.btn_new.Text = "&New"
        Me.btn_new.UseVisualStyleBackColor = True
        '
        'btn_edit
        '
        Me.btn_edit.Location = New System.Drawing.Point(415, 37)
        Me.btn_edit.Name = "btn_edit"
        Me.btn_edit.Size = New System.Drawing.Size(75, 23)
        Me.btn_edit.TabIndex = 4
        Me.btn_edit.Text = "&Edit"
        Me.btn_edit.UseVisualStyleBackColor = True
        '
        'txt_user_id
        '
        Me.txt_user_id.Location = New System.Drawing.Point(152, 10)
        Me.txt_user_id.MaxLength = 10
        Me.txt_user_id.Name = "txt_user_id"
        Me.txt_user_id.Size = New System.Drawing.Size(171, 20)
        Me.txt_user_id.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(74, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "USER NAME:"
        '
        'cbo_acct_id
        '
        Me.cbo_acct_id.Enabled = False
        Me.cbo_acct_id.FormattingEnabled = True
        Me.cbo_acct_id.Location = New System.Drawing.Point(152, 139)
        Me.cbo_acct_id.Name = "cbo_acct_id"
        Me.cbo_acct_id.Size = New System.Drawing.Size(122, 21)
        Me.cbo_acct_id.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(91, 141)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "ACCT ID:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(48, 63)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(98, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "OLD PASSWORD:"
        '
        'txt_old_password
        '
        Me.txt_old_password.Enabled = False
        Me.txt_old_password.Location = New System.Drawing.Point(151, 60)
        Me.txt_old_password.MaxLength = 50
        Me.txt_old_password.Name = "txt_old_password"
        Me.txt_old_password.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txt_old_password.Size = New System.Drawing.Size(236, 20)
        Me.txt_old_password.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(72, 89)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 13)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "PASSWORD:"
        '
        'txt_password
        '
        Me.txt_password.Enabled = False
        Me.txt_password.Location = New System.Drawing.Point(151, 86)
        Me.txt_password.MaxLength = 50
        Me.txt_password.Name = "txt_password"
        Me.txt_password.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txt_password.Size = New System.Drawing.Size(236, 20)
        Me.txt_password.TabIndex = 12
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(22, 116)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(125, 13)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "CONFIRM PASSWORD:"
        '
        'txt_confirm_password
        '
        Me.txt_confirm_password.Enabled = False
        Me.txt_confirm_password.Location = New System.Drawing.Point(151, 113)
        Me.txt_confirm_password.MaxLength = 50
        Me.txt_confirm_password.Name = "txt_confirm_password"
        Me.txt_confirm_password.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txt_confirm_password.Size = New System.Drawing.Size(236, 20)
        Me.txt_confirm_password.TabIndex = 14
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Location = New System.Drawing.Point(151, 166)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(56, 17)
        Me.CheckBox1.TabIndex = 16
        Me.CheckBox1.Text = "Active"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'cmdAddEditDel
        '
        Me.cmdAddEditDel.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.INSERTToolStripMenuItem, Me.DELETEToolStripMenuItem})
        Me.cmdAddEditDel.Name = "cmCheckBox"
        Me.cmdAddEditDel.Size = New System.Drawing.Size(153, 70)
        '
        'INSERTToolStripMenuItem
        '
        Me.INSERTToolStripMenuItem.Name = "INSERTToolStripMenuItem"
        Me.INSERTToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.INSERTToolStripMenuItem.Text = "SET ACTIVE"
        '
        'DELETEToolStripMenuItem
        '
        Me.DELETEToolStripMenuItem.Name = "DELETEToolStripMenuItem"
        Me.DELETEToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.DELETEToolStripMenuItem.Text = "SET INACTIVE"
        '
        'frmUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(628, 556)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txt_confirm_password)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txt_password)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txt_old_password)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cbo_acct_id)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txt_user_id)
        Me.Controls.Add(Me.btn_edit)
        Me.Controls.Add(Me.btn_new)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txt_user_name)
        Me.Controls.Add(Me.dgvUser)
        Me.Name = "frmUser"
        Me.Text = "USER"
        CType(Me.dgvUser, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmdAddEditDel.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvUser As System.Windows.Forms.DataGridView
    Friend WithEvents txt_user_name As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn_new As System.Windows.Forms.Button
    Friend WithEvents btn_edit As System.Windows.Forms.Button
    Friend WithEvents txt_user_id As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbo_acct_id As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_old_password As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_password As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_confirm_password As System.Windows.Forms.TextBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents cmdAddEditDel As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents INSERTToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DELETEToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
