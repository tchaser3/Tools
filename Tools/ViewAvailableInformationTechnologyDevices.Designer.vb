<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewAvailableInformationTechnologyDevices
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
        Me.btnInformationTechnologyMenu = New System.Windows.Forms.Button()
        Me.btnMainMenu = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.txtActive = New System.Windows.Forms.TextBox()
        Me.txtEmployeeID = New System.Windows.Forms.TextBox()
        Me.cboDeviceID = New System.Windows.Forms.ComboBox()
        Me.txtPhoneNumber = New System.Windows.Forms.TextBox()
        Me.txtType = New System.Windows.Forms.TextBox()
        Me.txtAvailable = New System.Windows.Forms.TextBox()
        Me.txtSerialNumber = New System.Windows.Forms.TextBox()
        Me.txtModel = New System.Windows.Forms.TextBox()
        Me.txtComputerName = New System.Windows.Forms.TextBox()
        Me.txtManufacturer = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboEmployeeID = New System.Windows.Forms.ComboBox()
        Me.txtFirstName = New System.Windows.Forms.TextBox()
        Me.txtLastName = New System.Windows.Forms.TextBox()
        Me.dgvAvailableDevices = New System.Windows.Forms.DataGridView()
        Me.cboDeviceList = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnFind = New System.Windows.Forms.Button()
        CType(Me.dgvAvailableDevices, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnInformationTechnologyMenu
        '
        Me.btnInformationTechnologyMenu.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnInformationTechnologyMenu.Location = New System.Drawing.Point(625, 88)
        Me.btnInformationTechnologyMenu.Margin = New System.Windows.Forms.Padding(2)
        Me.btnInformationTechnologyMenu.Name = "btnInformationTechnologyMenu"
        Me.btnInformationTechnologyMenu.Size = New System.Drawing.Size(167, 51)
        Me.btnInformationTechnologyMenu.TabIndex = 562
        Me.btnInformationTechnologyMenu.Text = "Information Technology Menu"
        Me.btnInformationTechnologyMenu.UseVisualStyleBackColor = True
        '
        'btnMainMenu
        '
        Me.btnMainMenu.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMainMenu.Location = New System.Drawing.Point(625, 143)
        Me.btnMainMenu.Margin = New System.Windows.Forms.Padding(2)
        Me.btnMainMenu.Name = "btnMainMenu"
        Me.btnMainMenu.Size = New System.Drawing.Size(167, 51)
        Me.btnMainMenu.TabIndex = 563
        Me.btnMainMenu.Text = "Main Menu"
        Me.btnMainMenu.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Location = New System.Drawing.Point(625, 198)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(2)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(167, 51)
        Me.btnClose.TabIndex = 564
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'txtActive
        '
        Me.txtActive.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtActive.Location = New System.Drawing.Point(62, 429)
        Me.txtActive.Margin = New System.Windows.Forms.Padding(2)
        Me.txtActive.Name = "txtActive"
        Me.txtActive.ReadOnly = True
        Me.txtActive.Size = New System.Drawing.Size(145, 20)
        Me.txtActive.TabIndex = 584
        '
        'txtEmployeeID
        '
        Me.txtEmployeeID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEmployeeID.Location = New System.Drawing.Point(62, 374)
        Me.txtEmployeeID.Margin = New System.Windows.Forms.Padding(2)
        Me.txtEmployeeID.Name = "txtEmployeeID"
        Me.txtEmployeeID.ReadOnly = True
        Me.txtEmployeeID.Size = New System.Drawing.Size(145, 20)
        Me.txtEmployeeID.TabIndex = 582
        '
        'cboDeviceID
        '
        Me.cboDeviceID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDeviceID.FormattingEnabled = True
        Me.cboDeviceID.Location = New System.Drawing.Point(62, 198)
        Me.cboDeviceID.Name = "cboDeviceID"
        Me.cboDeviceID.Size = New System.Drawing.Size(145, 21)
        Me.cboDeviceID.TabIndex = 575
        '
        'txtPhoneNumber
        '
        Me.txtPhoneNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPhoneNumber.Location = New System.Drawing.Point(62, 299)
        Me.txtPhoneNumber.Margin = New System.Windows.Forms.Padding(2)
        Me.txtPhoneNumber.Name = "txtPhoneNumber"
        Me.txtPhoneNumber.ReadOnly = True
        Me.txtPhoneNumber.Size = New System.Drawing.Size(145, 20)
        Me.txtPhoneNumber.TabIndex = 579
        '
        'txtType
        '
        Me.txtType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtType.Location = New System.Drawing.Point(62, 227)
        Me.txtType.Margin = New System.Windows.Forms.Padding(2)
        Me.txtType.Name = "txtType"
        Me.txtType.ReadOnly = True
        Me.txtType.Size = New System.Drawing.Size(145, 20)
        Me.txtType.TabIndex = 576
        '
        'txtAvailable
        '
        Me.txtAvailable.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAvailable.Location = New System.Drawing.Point(62, 402)
        Me.txtAvailable.Margin = New System.Windows.Forms.Padding(2)
        Me.txtAvailable.Name = "txtAvailable"
        Me.txtAvailable.ReadOnly = True
        Me.txtAvailable.Size = New System.Drawing.Size(145, 20)
        Me.txtAvailable.TabIndex = 583
        '
        'txtSerialNumber
        '
        Me.txtSerialNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSerialNumber.Location = New System.Drawing.Point(62, 346)
        Me.txtSerialNumber.Margin = New System.Windows.Forms.Padding(2)
        Me.txtSerialNumber.Name = "txtSerialNumber"
        Me.txtSerialNumber.Size = New System.Drawing.Size(145, 20)
        Me.txtSerialNumber.TabIndex = 581
        '
        'txtModel
        '
        Me.txtModel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtModel.Location = New System.Drawing.Point(62, 275)
        Me.txtModel.Margin = New System.Windows.Forms.Padding(2)
        Me.txtModel.Name = "txtModel"
        Me.txtModel.Size = New System.Drawing.Size(145, 20)
        Me.txtModel.TabIndex = 578
        '
        'txtComputerName
        '
        Me.txtComputerName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComputerName.Location = New System.Drawing.Point(62, 323)
        Me.txtComputerName.Margin = New System.Windows.Forms.Padding(2)
        Me.txtComputerName.Name = "txtComputerName"
        Me.txtComputerName.ReadOnly = True
        Me.txtComputerName.Size = New System.Drawing.Size(145, 20)
        Me.txtComputerName.TabIndex = 580
        '
        'txtManufacturer
        '
        Me.txtManufacturer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtManufacturer.Location = New System.Drawing.Point(62, 251)
        Me.txtManufacturer.Margin = New System.Windows.Forms.Padding(2)
        Me.txtManufacturer.Name = "txtManufacturer"
        Me.txtManufacturer.Size = New System.Drawing.Size(145, 20)
        Me.txtManufacturer.TabIndex = 577
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(11, 9)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(781, 46)
        Me.Label1.TabIndex = 599
        Me.Label1.Text = "View Available Information Technology Devices"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cboEmployeeID
        '
        Me.cboEmployeeID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEmployeeID.FormattingEnabled = True
        Me.cboEmployeeID.Location = New System.Drawing.Point(236, 246)
        Me.cboEmployeeID.Name = "cboEmployeeID"
        Me.cboEmployeeID.Size = New System.Drawing.Size(145, 21)
        Me.cboEmployeeID.TabIndex = 600
        '
        'txtFirstName
        '
        Me.txtFirstName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFirstName.Location = New System.Drawing.Point(236, 275)
        Me.txtFirstName.Margin = New System.Windows.Forms.Padding(2)
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.ReadOnly = True
        Me.txtFirstName.Size = New System.Drawing.Size(145, 20)
        Me.txtFirstName.TabIndex = 601
        '
        'txtLastName
        '
        Me.txtLastName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLastName.Location = New System.Drawing.Point(236, 299)
        Me.txtLastName.Margin = New System.Windows.Forms.Padding(2)
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Size = New System.Drawing.Size(145, 20)
        Me.txtLastName.TabIndex = 602
        '
        'dgvAvailableDevices
        '
        Me.dgvAvailableDevices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAvailableDevices.Location = New System.Drawing.Point(13, 152)
        Me.dgvAvailableDevices.Name = "dgvAvailableDevices"
        Me.dgvAvailableDevices.Size = New System.Drawing.Size(591, 335)
        Me.dgvAvailableDevices.TabIndex = 603
        '
        'cboDeviceList
        '
        Me.cboDeviceList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDeviceList.FormattingEnabled = True
        Me.cboDeviceList.Items.AddRange(New Object() {"ALL", "MOBILE", "AIR CARD", "TABLET", "DESKTOP", "LAPTOP"})
        Me.cboDeviceList.Location = New System.Drawing.Point(236, 88)
        Me.cboDeviceList.Name = "cboDeviceList"
        Me.cboDeviceList.Size = New System.Drawing.Size(145, 21)
        Me.cboDeviceList.TabIndex = 604
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(16, 87)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(191, 19)
        Me.Label3.TabIndex = 605
        Me.Label3.Text = "Select Device Type"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnFind
        '
        Me.btnFind.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFind.Location = New System.Drawing.Point(415, 80)
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Size = New System.Drawing.Size(94, 35)
        Me.btnFind.TabIndex = 606
        Me.btnFind.Text = "Find"
        Me.btnFind.UseVisualStyleBackColor = True
        '
        'ViewAvailableInformationTechnologyDevices
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(803, 506)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnFind)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboDeviceList)
        Me.Controls.Add(Me.dgvAvailableDevices)
        Me.Controls.Add(Me.cboEmployeeID)
        Me.Controls.Add(Me.txtFirstName)
        Me.Controls.Add(Me.txtLastName)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtActive)
        Me.Controls.Add(Me.txtEmployeeID)
        Me.Controls.Add(Me.cboDeviceID)
        Me.Controls.Add(Me.txtPhoneNumber)
        Me.Controls.Add(Me.txtType)
        Me.Controls.Add(Me.txtAvailable)
        Me.Controls.Add(Me.txtSerialNumber)
        Me.Controls.Add(Me.txtModel)
        Me.Controls.Add(Me.txtComputerName)
        Me.Controls.Add(Me.txtManufacturer)
        Me.Controls.Add(Me.btnInformationTechnologyMenu)
        Me.Controls.Add(Me.btnMainMenu)
        Me.Controls.Add(Me.btnClose)
        Me.Name = "ViewAvailableInformationTechnologyDevices"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ViewAvailableInformationTechnologyDevices"
        CType(Me.dgvAvailableDevices, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnInformationTechnologyMenu As System.Windows.Forms.Button
    Friend WithEvents btnMainMenu As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents txtActive As System.Windows.Forms.TextBox
    Friend WithEvents txtEmployeeID As System.Windows.Forms.TextBox
    Friend WithEvents cboDeviceID As System.Windows.Forms.ComboBox
    Friend WithEvents txtPhoneNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtType As System.Windows.Forms.TextBox
    Friend WithEvents txtAvailable As System.Windows.Forms.TextBox
    Friend WithEvents txtSerialNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtModel As System.Windows.Forms.TextBox
    Friend WithEvents txtComputerName As System.Windows.Forms.TextBox
    Friend WithEvents txtManufacturer As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboEmployeeID As System.Windows.Forms.ComboBox
    Friend WithEvents txtFirstName As System.Windows.Forms.TextBox
    Friend WithEvents txtLastName As System.Windows.Forms.TextBox
    Friend WithEvents dgvAvailableDevices As System.Windows.Forms.DataGridView
    Friend WithEvents cboDeviceList As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnFind As System.Windows.Forms.Button
End Class
