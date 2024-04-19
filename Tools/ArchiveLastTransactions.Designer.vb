<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ArchiveLastTransactions
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
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtLastTransactionSummary = New System.Windows.Forms.TextBox()
        Me.txtDate = New System.Windows.Forms.TextBox()
        Me.txtEmployeeID = New System.Windows.Forms.TextBox()
        Me.cboTransactionID = New System.Windows.Forms.ComboBox()
        Me.txtArchiveLastTransactionSummary = New System.Windows.Forms.TextBox()
        Me.txtArchiveDate = New System.Windows.Forms.TextBox()
        Me.txtArchiveEmployeeID = New System.Windows.Forms.TextBox()
        Me.cboArchiveTransactionID = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnAdminMenu = New System.Windows.Forms.Button()
        Me.btnUtilitiesMenu = New System.Windows.Forms.Button()
        Me.btnArchive = New System.Windows.Forms.Button()
        Me.btnMainMenu = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(10, 235)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(133, 60)
        Me.Label3.TabIndex = 41
        Me.Label3.Text = "Last Transaction Summary"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(10, 161)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(133, 28)
        Me.Label2.TabIndex = 40
        Me.Label2.Text = "Date"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(10, 124)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(133, 28)
        Me.Label1.TabIndex = 39
        Me.Label1.Text = "Employee ID"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtLastTransactionSummary
        '
        Me.txtLastTransactionSummary.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLastTransactionSummary.Location = New System.Drawing.Point(163, 195)
        Me.txtLastTransactionSummary.Margin = New System.Windows.Forms.Padding(4)
        Me.txtLastTransactionSummary.Multiline = True
        Me.txtLastTransactionSummary.Name = "txtLastTransactionSummary"
        Me.txtLastTransactionSummary.ReadOnly = True
        Me.txtLastTransactionSummary.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtLastTransactionSummary.Size = New System.Drawing.Size(205, 153)
        Me.txtLastTransactionSummary.TabIndex = 38
        '
        'txtDate
        '
        Me.txtDate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDate.Location = New System.Drawing.Point(163, 161)
        Me.txtDate.Margin = New System.Windows.Forms.Padding(4)
        Me.txtDate.Name = "txtDate"
        Me.txtDate.ReadOnly = True
        Me.txtDate.Size = New System.Drawing.Size(205, 22)
        Me.txtDate.TabIndex = 37
        '
        'txtEmployeeID
        '
        Me.txtEmployeeID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEmployeeID.Location = New System.Drawing.Point(163, 128)
        Me.txtEmployeeID.Margin = New System.Windows.Forms.Padding(4)
        Me.txtEmployeeID.Name = "txtEmployeeID"
        Me.txtEmployeeID.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtEmployeeID.ReadOnly = True
        Me.txtEmployeeID.Size = New System.Drawing.Size(205, 22)
        Me.txtEmployeeID.TabIndex = 36
        '
        'cboTransactionID
        '
        Me.cboTransactionID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTransactionID.FormattingEnabled = True
        Me.cboTransactionID.Location = New System.Drawing.Point(163, 94)
        Me.cboTransactionID.Margin = New System.Windows.Forms.Padding(4)
        Me.cboTransactionID.Name = "cboTransactionID"
        Me.cboTransactionID.Size = New System.Drawing.Size(205, 24)
        Me.cboTransactionID.TabIndex = 35
        '
        'txtArchiveLastTransactionSummary
        '
        Me.txtArchiveLastTransactionSummary.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtArchiveLastTransactionSummary.Location = New System.Drawing.Point(163, 490)
        Me.txtArchiveLastTransactionSummary.Margin = New System.Windows.Forms.Padding(4)
        Me.txtArchiveLastTransactionSummary.Multiline = True
        Me.txtArchiveLastTransactionSummary.Name = "txtArchiveLastTransactionSummary"
        Me.txtArchiveLastTransactionSummary.ReadOnly = True
        Me.txtArchiveLastTransactionSummary.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtArchiveLastTransactionSummary.Size = New System.Drawing.Size(205, 153)
        Me.txtArchiveLastTransactionSummary.TabIndex = 45
        '
        'txtArchiveDate
        '
        Me.txtArchiveDate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtArchiveDate.Location = New System.Drawing.Point(163, 456)
        Me.txtArchiveDate.Margin = New System.Windows.Forms.Padding(4)
        Me.txtArchiveDate.Name = "txtArchiveDate"
        Me.txtArchiveDate.ReadOnly = True
        Me.txtArchiveDate.Size = New System.Drawing.Size(205, 22)
        Me.txtArchiveDate.TabIndex = 44
        '
        'txtArchiveEmployeeID
        '
        Me.txtArchiveEmployeeID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtArchiveEmployeeID.Location = New System.Drawing.Point(163, 423)
        Me.txtArchiveEmployeeID.Margin = New System.Windows.Forms.Padding(4)
        Me.txtArchiveEmployeeID.Name = "txtArchiveEmployeeID"
        Me.txtArchiveEmployeeID.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtArchiveEmployeeID.ReadOnly = True
        Me.txtArchiveEmployeeID.Size = New System.Drawing.Size(205, 22)
        Me.txtArchiveEmployeeID.TabIndex = 43
        '
        'cboArchiveTransactionID
        '
        Me.cboArchiveTransactionID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboArchiveTransactionID.FormattingEnabled = True
        Me.cboArchiveTransactionID.Location = New System.Drawing.Point(163, 389)
        Me.cboArchiveTransactionID.Margin = New System.Windows.Forms.Padding(4)
        Me.cboArchiveTransactionID.Name = "cboArchiveTransactionID"
        Me.cboArchiveTransactionID.Size = New System.Drawing.Size(205, 24)
        Me.cboArchiveTransactionID.TabIndex = 42
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(10, 497)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(133, 60)
        Me.Label4.TabIndex = 48
        Me.Label4.Text = "Last Transaction Summary"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(10, 423)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(133, 28)
        Me.Label5.TabIndex = 47
        Me.Label5.Text = "Date"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(10, 386)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(133, 28)
        Me.Label6.TabIndex = 46
        Me.Label6.Text = "Employee ID"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(13, 18)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(565, 38)
        Me.Label7.TabIndex = 110
        Me.Label7.Text = "Archive Issued Material"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnAdminMenu
        '
        Me.btnAdminMenu.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdminMenu.Location = New System.Drawing.Point(387, 296)
        Me.btnAdminMenu.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnAdminMenu.Name = "btnAdminMenu"
        Me.btnAdminMenu.Size = New System.Drawing.Size(191, 52)
        Me.btnAdminMenu.TabIndex = 113
        Me.btnAdminMenu.Text = "Administration Menu"
        Me.btnAdminMenu.UseVisualStyleBackColor = True
        '
        'btnUtilitiesMenu
        '
        Me.btnUtilitiesMenu.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUtilitiesMenu.Location = New System.Drawing.Point(386, 240)
        Me.btnUtilitiesMenu.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnUtilitiesMenu.Name = "btnUtilitiesMenu"
        Me.btnUtilitiesMenu.Size = New System.Drawing.Size(191, 52)
        Me.btnUtilitiesMenu.TabIndex = 112
        Me.btnUtilitiesMenu.Text = "Utilities Menu"
        Me.btnUtilitiesMenu.UseVisualStyleBackColor = True
        '
        'btnArchive
        '
        Me.btnArchive.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnArchive.Location = New System.Drawing.Point(387, 184)
        Me.btnArchive.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnArchive.Name = "btnArchive"
        Me.btnArchive.Size = New System.Drawing.Size(191, 52)
        Me.btnArchive.TabIndex = 111
        Me.btnArchive.Text = "Archive"
        Me.btnArchive.UseVisualStyleBackColor = True
        '
        'btnMainMenu
        '
        Me.btnMainMenu.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMainMenu.Location = New System.Drawing.Point(387, 352)
        Me.btnMainMenu.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnMainMenu.Name = "btnMainMenu"
        Me.btnMainMenu.Size = New System.Drawing.Size(191, 52)
        Me.btnMainMenu.TabIndex = 114
        Me.btnMainMenu.Text = "Main Menu"
        Me.btnMainMenu.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Location = New System.Drawing.Point(387, 408)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(191, 52)
        Me.btnClose.TabIndex = 115
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'ArchiveLastTransactions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(610, 668)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnAdminMenu)
        Me.Controls.Add(Me.btnUtilitiesMenu)
        Me.Controls.Add(Me.btnArchive)
        Me.Controls.Add(Me.btnMainMenu)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtArchiveLastTransactionSummary)
        Me.Controls.Add(Me.txtArchiveDate)
        Me.Controls.Add(Me.txtArchiveEmployeeID)
        Me.Controls.Add(Me.cboArchiveTransactionID)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtLastTransactionSummary)
        Me.Controls.Add(Me.txtDate)
        Me.Controls.Add(Me.txtEmployeeID)
        Me.Controls.Add(Me.cboTransactionID)
        Me.Name = "ArchiveLastTransactions"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ArchiveLastTransactions"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtLastTransactionSummary As System.Windows.Forms.TextBox
    Friend WithEvents txtDate As System.Windows.Forms.TextBox
    Friend WithEvents txtEmployeeID As System.Windows.Forms.TextBox
    Friend WithEvents cboTransactionID As System.Windows.Forms.ComboBox
    Friend WithEvents txtArchiveLastTransactionSummary As System.Windows.Forms.TextBox
    Friend WithEvents txtArchiveDate As System.Windows.Forms.TextBox
    Friend WithEvents txtArchiveEmployeeID As System.Windows.Forms.TextBox
    Friend WithEvents cboArchiveTransactionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnAdminMenu As System.Windows.Forms.Button
    Friend WithEvents btnUtilitiesMenu As System.Windows.Forms.Button
    Friend WithEvents btnArchive As System.Windows.Forms.Button
    Friend WithEvents btnMainMenu As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
End Class
