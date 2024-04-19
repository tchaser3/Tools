<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VehiclePreventiveMaintenanceUpdate
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
        Me.btnMaintenanceMenu = New System.Windows.Forms.Button()
        Me.btnUpdateVehicle = New System.Windows.Forms.Button()
        Me.btnMainMenu = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnFindVehicle = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtBJCNumberEntered = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboVehicleID = New System.Windows.Forms.ComboBox()
        Me.txtLastOilChangeDate = New System.Windows.Forms.TextBox()
        Me.txtLastOilChangeOdometer = New System.Windows.Forms.TextBox()
        Me.txtVehicleBJCNumber = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtActive = New System.Windows.Forms.TextBox()
        Me.btnInspectionMenu = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnMaintenanceMenu
        '
        Me.btnMaintenanceMenu.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMaintenanceMenu.Location = New System.Drawing.Point(400, 284)
        Me.btnMaintenanceMenu.Margin = New System.Windows.Forms.Padding(2)
        Me.btnMaintenanceMenu.Name = "btnMaintenanceMenu"
        Me.btnMaintenanceMenu.Size = New System.Drawing.Size(167, 58)
        Me.btnMaintenanceMenu.TabIndex = 309
        Me.btnMaintenanceMenu.Text = "Maintenance Menu"
        Me.btnMaintenanceMenu.UseVisualStyleBackColor = True
        '
        'btnUpdateVehicle
        '
        Me.btnUpdateVehicle.Enabled = False
        Me.btnUpdateVehicle.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdateVehicle.Location = New System.Drawing.Point(400, 146)
        Me.btnUpdateVehicle.Margin = New System.Windows.Forms.Padding(2)
        Me.btnUpdateVehicle.Name = "btnUpdateVehicle"
        Me.btnUpdateVehicle.Size = New System.Drawing.Size(167, 58)
        Me.btnUpdateVehicle.TabIndex = 307
        Me.btnUpdateVehicle.Text = "Update Vehicle"
        Me.btnUpdateVehicle.UseVisualStyleBackColor = True
        '
        'btnMainMenu
        '
        Me.btnMainMenu.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMainMenu.Location = New System.Drawing.Point(400, 213)
        Me.btnMainMenu.Margin = New System.Windows.Forms.Padding(2)
        Me.btnMainMenu.Name = "btnMainMenu"
        Me.btnMainMenu.Size = New System.Drawing.Size(167, 58)
        Me.btnMainMenu.TabIndex = 308
        Me.btnMainMenu.Text = "Main Menu"
        Me.btnMainMenu.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Location = New System.Drawing.Point(400, 429)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(2)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(167, 58)
        Me.btnClose.TabIndex = 310
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnFindVehicle
        '
        Me.btnFindVehicle.Location = New System.Drawing.Point(371, 74)
        Me.btnFindVehicle.Name = "btnFindVehicle"
        Me.btnFindVehicle.Size = New System.Drawing.Size(123, 32)
        Me.btnFindVehicle.TabIndex = 331
        Me.btnFindVehicle.Text = "Find Vehicle"
        Me.btnFindVehicle.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(34, 81)
        Me.Label12.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(173, 19)
        Me.Label12.TabIndex = 332
        Me.Label12.Text = "Type In BJC Number"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtBJCNumberEntered
        '
        Me.txtBJCNumberEntered.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBJCNumberEntered.Location = New System.Drawing.Point(211, 81)
        Me.txtBJCNumberEntered.Margin = New System.Windows.Forms.Padding(2)
        Me.txtBJCNumberEntered.Name = "txtBJCNumberEntered"
        Me.txtBJCNumberEntered.Size = New System.Drawing.Size(145, 20)
        Me.txtBJCNumberEntered.TabIndex = 330
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(10, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(573, 42)
        Me.Label1.TabIndex = 333
        Me.Label1.Text = "Vehicle Preventive Maintenance"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(79, 183)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(109, 19)
        Me.Label3.TabIndex = 351
        Me.Label3.Text = "BJC Number"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(11, 231)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(177, 19)
        Me.Label5.TabIndex = 350
        Me.Label5.Text = "Last Oil Change Date"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(11, 209)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(177, 19)
        Me.Label4.TabIndex = 349
        Me.Label4.Text = "Last Oil Change Odometer"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboVehicleID
        '
        Me.cboVehicleID.FormattingEnabled = True
        Me.cboVehicleID.Location = New System.Drawing.Point(202, 155)
        Me.cboVehicleID.Margin = New System.Windows.Forms.Padding(2)
        Me.cboVehicleID.Name = "cboVehicleID"
        Me.cboVehicleID.Size = New System.Drawing.Size(145, 21)
        Me.cboVehicleID.TabIndex = 345
        Me.cboVehicleID.UseWaitCursor = True
        Me.cboVehicleID.Visible = False
        '
        'txtLastOilChangeDate
        '
        Me.txtLastOilChangeDate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLastOilChangeDate.Location = New System.Drawing.Point(202, 232)
        Me.txtLastOilChangeDate.Margin = New System.Windows.Forms.Padding(2)
        Me.txtLastOilChangeDate.Name = "txtLastOilChangeDate"
        Me.txtLastOilChangeDate.Size = New System.Drawing.Size(145, 20)
        Me.txtLastOilChangeDate.TabIndex = 348
        '
        'txtLastOilChangeOdometer
        '
        Me.txtLastOilChangeOdometer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLastOilChangeOdometer.Location = New System.Drawing.Point(202, 209)
        Me.txtLastOilChangeOdometer.Margin = New System.Windows.Forms.Padding(2)
        Me.txtLastOilChangeOdometer.Name = "txtLastOilChangeOdometer"
        Me.txtLastOilChangeOdometer.Size = New System.Drawing.Size(145, 20)
        Me.txtLastOilChangeOdometer.TabIndex = 347
        '
        'txtVehicleBJCNumber
        '
        Me.txtVehicleBJCNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtVehicleBJCNumber.Location = New System.Drawing.Point(202, 184)
        Me.txtVehicleBJCNumber.Margin = New System.Windows.Forms.Padding(2)
        Me.txtVehicleBJCNumber.Name = "txtVehicleBJCNumber"
        Me.txtVehicleBJCNumber.ReadOnly = True
        Me.txtVehicleBJCNumber.Size = New System.Drawing.Size(145, 20)
        Me.txtVehicleBJCNumber.TabIndex = 346
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(11, 255)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(177, 19)
        Me.Label2.TabIndex = 353
        Me.Label2.Text = "Active"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtActive
        '
        Me.txtActive.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtActive.Location = New System.Drawing.Point(202, 256)
        Me.txtActive.Margin = New System.Windows.Forms.Padding(2)
        Me.txtActive.Name = "txtActive"
        Me.txtActive.ReadOnly = True
        Me.txtActive.Size = New System.Drawing.Size(145, 20)
        Me.txtActive.TabIndex = 352
        '
        'btnInspectionMenu
        '
        Me.btnInspectionMenu.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnInspectionMenu.Location = New System.Drawing.Point(400, 357)
        Me.btnInspectionMenu.Margin = New System.Windows.Forms.Padding(2)
        Me.btnInspectionMenu.Name = "btnInspectionMenu"
        Me.btnInspectionMenu.Size = New System.Drawing.Size(167, 58)
        Me.btnInspectionMenu.TabIndex = 354
        Me.btnInspectionMenu.Text = "Inspection Menu"
        Me.btnInspectionMenu.UseVisualStyleBackColor = True
        '
        'VehiclePreventiveMaintenanceUpdate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(595, 498)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnInspectionMenu)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtActive)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cboVehicleID)
        Me.Controls.Add(Me.txtLastOilChangeDate)
        Me.Controls.Add(Me.txtLastOilChangeOdometer)
        Me.Controls.Add(Me.txtVehicleBJCNumber)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnFindVehicle)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtBJCNumberEntered)
        Me.Controls.Add(Me.btnMaintenanceMenu)
        Me.Controls.Add(Me.btnUpdateVehicle)
        Me.Controls.Add(Me.btnMainMenu)
        Me.Controls.Add(Me.btnClose)
        Me.Name = "VehiclePreventiveMaintenanceUpdate"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "VehiclePreventiveMaintenanceUpdate"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnMaintenanceMenu As System.Windows.Forms.Button
    Friend WithEvents btnUpdateVehicle As System.Windows.Forms.Button
    Friend WithEvents btnMainMenu As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnFindVehicle As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtBJCNumberEntered As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboVehicleID As System.Windows.Forms.ComboBox
    Friend WithEvents txtLastOilChangeDate As System.Windows.Forms.TextBox
    Friend WithEvents txtLastOilChangeOdometer As System.Windows.Forms.TextBox
    Friend WithEvents txtVehicleBJCNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtActive As System.Windows.Forms.TextBox
    Friend WithEvents btnInspectionMenu As System.Windows.Forms.Button
End Class
