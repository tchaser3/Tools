<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddInformationTechnologyAccessories
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkUSBCable = New System.Windows.Forms.CheckBox()
        Me.chkPowerUSBCharger = New System.Windows.Forms.CheckBox()
        Me.chkHeadPhones = New System.Windows.Forms.CheckBox()
        Me.chkLaptopCase = New System.Windows.Forms.CheckBox()
        Me.chkPowerCord = New System.Windows.Forms.CheckBox()
        Me.chkKeyboard = New System.Windows.Forms.CheckBox()
        Me.chkPhoneCase = New System.Windows.Forms.CheckBox()
        Me.chkMouse = New System.Windows.Forms.CheckBox()
        Me.chkMonitor = New System.Windows.Forms.CheckBox()
        Me.chkPrinter = New System.Windows.Forms.CheckBox()
        Me.btnIssueAccessories = New System.Windows.Forms.Button()
        Me.cboAccessoryID = New System.Windows.Forms.ComboBox()
        Me.txtDeviceID = New System.Windows.Forms.TextBox()
        Me.txtAccessoryType = New System.Windows.Forms.TextBox()
        Me.txtDate = New System.Windows.Forms.TextBox()
        Me.txtEmployeeID = New System.Windows.Forms.TextBox()
        Me.txtAvailable = New System.Windows.Forms.TextBox()
        Me.txtActive = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(539, 52)
        Me.Label1.TabIndex = 554
        Me.Label1.Text = "Add Accessories"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chkUSBCable
        '
        Me.chkUSBCable.AutoSize = True
        Me.chkUSBCable.Location = New System.Drawing.Point(37, 84)
        Me.chkUSBCable.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.chkUSBCable.Name = "chkUSBCable"
        Me.chkUSBCable.Size = New System.Drawing.Size(107, 24)
        Me.chkUSBCable.TabIndex = 0
        Me.chkUSBCable.Text = "USB Cable"
        Me.chkUSBCable.UseVisualStyleBackColor = True
        '
        'chkPowerUSBCharger
        '
        Me.chkPowerUSBCharger.AutoSize = True
        Me.chkPowerUSBCharger.Location = New System.Drawing.Point(37, 118)
        Me.chkPowerUSBCharger.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.chkPowerUSBCharger.Name = "chkPowerUSBCharger"
        Me.chkPowerUSBCharger.Size = New System.Drawing.Size(171, 24)
        Me.chkPowerUSBCharger.TabIndex = 1
        Me.chkPowerUSBCharger.Text = "Power USB Charger"
        Me.chkPowerUSBCharger.UseVisualStyleBackColor = True
        '
        'chkHeadPhones
        '
        Me.chkHeadPhones.AutoSize = True
        Me.chkHeadPhones.Location = New System.Drawing.Point(37, 152)
        Me.chkHeadPhones.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.chkHeadPhones.Name = "chkHeadPhones"
        Me.chkHeadPhones.Size = New System.Drawing.Size(125, 24)
        Me.chkHeadPhones.TabIndex = 2
        Me.chkHeadPhones.Text = "Head Phones"
        Me.chkHeadPhones.UseVisualStyleBackColor = True
        '
        'chkLaptopCase
        '
        Me.chkLaptopCase.AutoSize = True
        Me.chkLaptopCase.Location = New System.Drawing.Point(220, 84)
        Me.chkLaptopCase.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.chkLaptopCase.Name = "chkLaptopCase"
        Me.chkLaptopCase.Size = New System.Drawing.Size(119, 24)
        Me.chkLaptopCase.TabIndex = 4
        Me.chkLaptopCase.Text = "Laptop Case"
        Me.chkLaptopCase.UseVisualStyleBackColor = True
        '
        'chkPowerCord
        '
        Me.chkPowerCord.AutoSize = True
        Me.chkPowerCord.Location = New System.Drawing.Point(220, 118)
        Me.chkPowerCord.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.chkPowerCord.Name = "chkPowerCord"
        Me.chkPowerCord.Size = New System.Drawing.Size(110, 24)
        Me.chkPowerCord.TabIndex = 5
        Me.chkPowerCord.Text = "Power Cord"
        Me.chkPowerCord.UseVisualStyleBackColor = True
        '
        'chkKeyboard
        '
        Me.chkKeyboard.AutoSize = True
        Me.chkKeyboard.Location = New System.Drawing.Point(220, 152)
        Me.chkKeyboard.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.chkKeyboard.Name = "chkKeyboard"
        Me.chkKeyboard.Size = New System.Drawing.Size(95, 24)
        Me.chkKeyboard.TabIndex = 6
        Me.chkKeyboard.Text = "Keyboard"
        Me.chkKeyboard.UseVisualStyleBackColor = True
        '
        'chkPhoneCase
        '
        Me.chkPhoneCase.AutoSize = True
        Me.chkPhoneCase.Location = New System.Drawing.Point(37, 186)
        Me.chkPhoneCase.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.chkPhoneCase.Name = "chkPhoneCase"
        Me.chkPhoneCase.Size = New System.Drawing.Size(115, 24)
        Me.chkPhoneCase.TabIndex = 3
        Me.chkPhoneCase.Text = "Phone Case"
        Me.chkPhoneCase.UseVisualStyleBackColor = True
        '
        'chkMouse
        '
        Me.chkMouse.AutoSize = True
        Me.chkMouse.Location = New System.Drawing.Point(220, 186)
        Me.chkMouse.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.chkMouse.Name = "chkMouse"
        Me.chkMouse.Size = New System.Drawing.Size(76, 24)
        Me.chkMouse.TabIndex = 7
        Me.chkMouse.Text = "Mouse"
        Me.chkMouse.UseVisualStyleBackColor = True
        '
        'chkMonitor
        '
        Me.chkMonitor.AutoSize = True
        Me.chkMonitor.Location = New System.Drawing.Point(366, 84)
        Me.chkMonitor.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.chkMonitor.Name = "chkMonitor"
        Me.chkMonitor.Size = New System.Drawing.Size(81, 24)
        Me.chkMonitor.TabIndex = 8
        Me.chkMonitor.Text = "Monitor"
        Me.chkMonitor.UseVisualStyleBackColor = True
        '
        'chkPrinter
        '
        Me.chkPrinter.AutoSize = True
        Me.chkPrinter.Location = New System.Drawing.Point(366, 118)
        Me.chkPrinter.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.chkPrinter.Name = "chkPrinter"
        Me.chkPrinter.Size = New System.Drawing.Size(74, 24)
        Me.chkPrinter.TabIndex = 9
        Me.chkPrinter.Text = "Printer"
        Me.chkPrinter.UseVisualStyleBackColor = True
        '
        'btnIssueAccessories
        '
        Me.btnIssueAccessories.Enabled = False
        Me.btnIssueAccessories.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIssueAccessories.Location = New System.Drawing.Point(349, 152)
        Me.btnIssueAccessories.Margin = New System.Windows.Forms.Padding(2)
        Me.btnIssueAccessories.Name = "btnIssueAccessories"
        Me.btnIssueAccessories.Size = New System.Drawing.Size(167, 58)
        Me.btnIssueAccessories.TabIndex = 10
        Me.btnIssueAccessories.Text = "Issue Accessories"
        Me.btnIssueAccessories.UseVisualStyleBackColor = True
        '
        'cboAccessoryID
        '
        Me.cboAccessoryID.FormattingEnabled = True
        Me.cboAccessoryID.Location = New System.Drawing.Point(37, 255)
        Me.cboAccessoryID.Name = "cboAccessoryID"
        Me.cboAccessoryID.Size = New System.Drawing.Size(121, 28)
        Me.cboAccessoryID.TabIndex = 566
        '
        'txtDeviceID
        '
        Me.txtDeviceID.Location = New System.Drawing.Point(37, 290)
        Me.txtDeviceID.Name = "txtDeviceID"
        Me.txtDeviceID.Size = New System.Drawing.Size(121, 26)
        Me.txtDeviceID.TabIndex = 567
        '
        'txtAccessoryType
        '
        Me.txtAccessoryType.Location = New System.Drawing.Point(194, 255)
        Me.txtAccessoryType.Name = "txtAccessoryType"
        Me.txtAccessoryType.Size = New System.Drawing.Size(121, 26)
        Me.txtAccessoryType.TabIndex = 568
        '
        'txtDate
        '
        Me.txtDate.Location = New System.Drawing.Point(194, 290)
        Me.txtDate.Name = "txtDate"
        Me.txtDate.Size = New System.Drawing.Size(121, 26)
        Me.txtDate.TabIndex = 569
        '
        'txtEmployeeID
        '
        Me.txtEmployeeID.Location = New System.Drawing.Point(349, 257)
        Me.txtEmployeeID.Name = "txtEmployeeID"
        Me.txtEmployeeID.Size = New System.Drawing.Size(121, 26)
        Me.txtEmployeeID.TabIndex = 570
        '
        'txtAvailable
        '
        Me.txtAvailable.Location = New System.Drawing.Point(349, 292)
        Me.txtAvailable.Name = "txtAvailable"
        Me.txtAvailable.Size = New System.Drawing.Size(121, 26)
        Me.txtAvailable.TabIndex = 571
        '
        'txtActive
        '
        Me.txtActive.Location = New System.Drawing.Point(194, 223)
        Me.txtActive.Name = "txtActive"
        Me.txtActive.Size = New System.Drawing.Size(121, 26)
        Me.txtActive.TabIndex = 592
        '
        'AddInformationTechnologyAccessories
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(567, 330)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtActive)
        Me.Controls.Add(Me.txtAvailable)
        Me.Controls.Add(Me.txtEmployeeID)
        Me.Controls.Add(Me.txtDate)
        Me.Controls.Add(Me.txtAccessoryType)
        Me.Controls.Add(Me.txtDeviceID)
        Me.Controls.Add(Me.cboAccessoryID)
        Me.Controls.Add(Me.btnIssueAccessories)
        Me.Controls.Add(Me.chkPrinter)
        Me.Controls.Add(Me.chkMonitor)
        Me.Controls.Add(Me.chkMouse)
        Me.Controls.Add(Me.chkPhoneCase)
        Me.Controls.Add(Me.chkKeyboard)
        Me.Controls.Add(Me.chkPowerCord)
        Me.Controls.Add(Me.chkLaptopCase)
        Me.Controls.Add(Me.chkHeadPhones)
        Me.Controls.Add(Me.chkPowerUSBCharger)
        Me.Controls.Add(Me.chkUSBCable)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "AddInformationTechnologyAccessories"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AddInformationTechnologyAccessories"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkUSBCable As System.Windows.Forms.CheckBox
    Friend WithEvents chkPowerUSBCharger As System.Windows.Forms.CheckBox
    Friend WithEvents chkHeadPhones As System.Windows.Forms.CheckBox
    Friend WithEvents chkLaptopCase As System.Windows.Forms.CheckBox
    Friend WithEvents chkPowerCord As System.Windows.Forms.CheckBox
    Friend WithEvents chkKeyboard As System.Windows.Forms.CheckBox
    Friend WithEvents chkPhoneCase As System.Windows.Forms.CheckBox
    Friend WithEvents chkMouse As System.Windows.Forms.CheckBox
    Friend WithEvents chkMonitor As System.Windows.Forms.CheckBox
    Friend WithEvents chkPrinter As System.Windows.Forms.CheckBox
    Friend WithEvents btnIssueAccessories As System.Windows.Forms.Button
    Friend WithEvents cboAccessoryID As System.Windows.Forms.ComboBox
    Friend WithEvents txtDeviceID As System.Windows.Forms.TextBox
    Friend WithEvents txtAccessoryType As System.Windows.Forms.TextBox
    Friend WithEvents txtDate As System.Windows.Forms.TextBox
    Friend WithEvents txtEmployeeID As System.Windows.Forms.TextBox
    Friend WithEvents txtAvailable As System.Windows.Forms.TextBox
    Friend WithEvents txtActive As System.Windows.Forms.TextBox
End Class
