<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AvailableVehicles
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
        Me.txtBJCNumber = New System.Windows.Forms.TextBox()
        Me.cboEmployeeID = New System.Windows.Forms.ComboBox()
        Me.txtFirstName = New System.Windows.Forms.TextBox()
        Me.txtLastName = New System.Windows.Forms.TextBox()
        Me.txtNotes = New System.Windows.Forms.TextBox()
        Me.txtActive = New System.Windows.Forms.TextBox()
        Me.txtAvailable = New System.Windows.Forms.TextBox()
        Me.txtEmployeeID = New System.Windows.Forms.TextBox()
        Me.btnVehicleMenu = New System.Windows.Forms.Button()
        Me.cboVehicleID = New System.Windows.Forms.ComboBox()
        Me.btnMainMenu = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvVehicles = New System.Windows.Forms.DataGridView()
        CType(Me.dgvVehicles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtBJCNumber
        '
        Me.txtBJCNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBJCNumber.Location = New System.Drawing.Point(42, 103)
        Me.txtBJCNumber.Margin = New System.Windows.Forms.Padding(2)
        Me.txtBJCNumber.Name = "txtBJCNumber"
        Me.txtBJCNumber.ReadOnly = True
        Me.txtBJCNumber.Size = New System.Drawing.Size(145, 20)
        Me.txtBJCNumber.TabIndex = 308
        '
        'cboEmployeeID
        '
        Me.cboEmployeeID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEmployeeID.FormattingEnabled = True
        Me.cboEmployeeID.Location = New System.Drawing.Point(42, 287)
        Me.cboEmployeeID.Margin = New System.Windows.Forms.Padding(2)
        Me.cboEmployeeID.Name = "cboEmployeeID"
        Me.cboEmployeeID.Size = New System.Drawing.Size(145, 21)
        Me.cboEmployeeID.TabIndex = 283
        Me.cboEmployeeID.Visible = False
        '
        'txtFirstName
        '
        Me.txtFirstName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFirstName.Location = New System.Drawing.Point(42, 339)
        Me.txtFirstName.Margin = New System.Windows.Forms.Padding(2)
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.ReadOnly = True
        Me.txtFirstName.Size = New System.Drawing.Size(145, 20)
        Me.txtFirstName.TabIndex = 285
        '
        'txtLastName
        '
        Me.txtLastName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLastName.Location = New System.Drawing.Point(42, 316)
        Me.txtLastName.Margin = New System.Windows.Forms.Padding(2)
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.ReadOnly = True
        Me.txtLastName.Size = New System.Drawing.Size(145, 20)
        Me.txtLastName.TabIndex = 284
        '
        'txtNotes
        '
        Me.txtNotes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNotes.Location = New System.Drawing.Point(42, 192)
        Me.txtNotes.Margin = New System.Windows.Forms.Padding(2)
        Me.txtNotes.Multiline = True
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.ReadOnly = True
        Me.txtNotes.Size = New System.Drawing.Size(145, 84)
        Me.txtNotes.TabIndex = 282
        '
        'txtActive
        '
        Me.txtActive.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtActive.Location = New System.Drawing.Point(42, 169)
        Me.txtActive.Margin = New System.Windows.Forms.Padding(2)
        Me.txtActive.Name = "txtActive"
        Me.txtActive.ReadOnly = True
        Me.txtActive.Size = New System.Drawing.Size(145, 20)
        Me.txtActive.TabIndex = 281
        '
        'txtAvailable
        '
        Me.txtAvailable.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAvailable.Location = New System.Drawing.Point(42, 149)
        Me.txtAvailable.Margin = New System.Windows.Forms.Padding(2)
        Me.txtAvailable.Name = "txtAvailable"
        Me.txtAvailable.ReadOnly = True
        Me.txtAvailable.Size = New System.Drawing.Size(145, 20)
        Me.txtAvailable.TabIndex = 280
        '
        'txtEmployeeID
        '
        Me.txtEmployeeID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEmployeeID.Location = New System.Drawing.Point(42, 124)
        Me.txtEmployeeID.Margin = New System.Windows.Forms.Padding(2)
        Me.txtEmployeeID.Name = "txtEmployeeID"
        Me.txtEmployeeID.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtEmployeeID.ReadOnly = True
        Me.txtEmployeeID.Size = New System.Drawing.Size(145, 20)
        Me.txtEmployeeID.TabIndex = 279
        '
        'btnVehicleMenu
        '
        Me.btnVehicleMenu.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVehicleMenu.Location = New System.Drawing.Point(356, 199)
        Me.btnVehicleMenu.Margin = New System.Windows.Forms.Padding(2)
        Me.btnVehicleMenu.Name = "btnVehicleMenu"
        Me.btnVehicleMenu.Size = New System.Drawing.Size(167, 58)
        Me.btnVehicleMenu.TabIndex = 289
        Me.btnVehicleMenu.Text = "Vehicle Menu"
        Me.btnVehicleMenu.UseVisualStyleBackColor = True
        '
        'cboVehicleID
        '
        Me.cboVehicleID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVehicleID.FormattingEnabled = True
        Me.cboVehicleID.Location = New System.Drawing.Point(42, 75)
        Me.cboVehicleID.Margin = New System.Windows.Forms.Padding(2)
        Me.cboVehicleID.Name = "cboVehicleID"
        Me.cboVehicleID.Size = New System.Drawing.Size(145, 21)
        Me.cboVehicleID.TabIndex = 274
        Me.cboVehicleID.Visible = False
        '
        'btnMainMenu
        '
        Me.btnMainMenu.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMainMenu.Location = New System.Drawing.Point(356, 128)
        Me.btnMainMenu.Margin = New System.Windows.Forms.Padding(2)
        Me.btnMainMenu.Name = "btnMainMenu"
        Me.btnMainMenu.Size = New System.Drawing.Size(167, 58)
        Me.btnMainMenu.TabIndex = 288
        Me.btnMainMenu.Text = "Main Menu"
        Me.btnMainMenu.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Location = New System.Drawing.Point(356, 269)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(2)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(167, 58)
        Me.btnClose.TabIndex = 290
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(42, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(481, 42)
        Me.Label1.TabIndex = 291
        Me.Label1.Text = "Available Vehicles"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dgvVehicles
        '
        Me.dgvVehicles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvVehicles.Location = New System.Drawing.Point(42, 63)
        Me.dgvVehicles.Name = "dgvVehicles"
        Me.dgvVehicles.Size = New System.Drawing.Size(274, 310)
        Me.dgvVehicles.TabIndex = 309
        '
        'AvailableVehicles
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(569, 431)
        Me.ControlBox = False
        Me.Controls.Add(Me.dgvVehicles)
        Me.Controls.Add(Me.txtBJCNumber)
        Me.Controls.Add(Me.cboEmployeeID)
        Me.Controls.Add(Me.txtFirstName)
        Me.Controls.Add(Me.txtLastName)
        Me.Controls.Add(Me.txtNotes)
        Me.Controls.Add(Me.txtActive)
        Me.Controls.Add(Me.txtAvailable)
        Me.Controls.Add(Me.txtEmployeeID)
        Me.Controls.Add(Me.btnVehicleMenu)
        Me.Controls.Add(Me.cboVehicleID)
        Me.Controls.Add(Me.btnMainMenu)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.Label1)
        Me.Name = "AvailableVehicles"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AvailableVehicles"
        CType(Me.dgvVehicles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtBJCNumber As System.Windows.Forms.TextBox
    Friend WithEvents cboEmployeeID As System.Windows.Forms.ComboBox
    Friend WithEvents txtFirstName As System.Windows.Forms.TextBox
    Friend WithEvents txtLastName As System.Windows.Forms.TextBox
    Friend WithEvents txtNotes As System.Windows.Forms.TextBox
    Friend WithEvents txtActive As System.Windows.Forms.TextBox
    Friend WithEvents txtAvailable As System.Windows.Forms.TextBox
    Friend WithEvents txtEmployeeID As System.Windows.Forms.TextBox
    Friend WithEvents btnVehicleMenu As System.Windows.Forms.Button
    Friend WithEvents cboVehicleID As System.Windows.Forms.ComboBox
    Friend WithEvents btnMainMenu As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvVehicles As System.Windows.Forms.DataGridView
End Class
