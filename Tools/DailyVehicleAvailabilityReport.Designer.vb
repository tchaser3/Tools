<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DailyVehicleAvailabilityReport
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
        Me.btnInspectionMenu = New System.Windows.Forms.Button()
        Me.btnVehicleInspectionReportMenu = New System.Windows.Forms.Button()
        Me.btnMainMenu = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnRunReport = New System.Windows.Forms.Button()
        Me.cboVehicleID = New System.Windows.Forms.ComboBox()
        Me.txtVehicleBJCNumber = New System.Windows.Forms.TextBox()
        Me.txtVehicleModel = New System.Windows.Forms.TextBox()
        Me.txtVehicleActive = New System.Windows.Forms.TextBox()
        Me.txtVehicleAvaiable = New System.Windows.Forms.TextBox()
        Me.txtVehicleEmployeeID = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtTransactionBJCNumber = New System.Windows.Forms.TextBox()
        Me.txtTransactionDate = New System.Windows.Forms.TextBox()
        Me.cboTransactionID = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtLastName = New System.Windows.Forms.TextBox()
        Me.txtFirstName = New System.Windows.Forms.TextBox()
        Me.cboEmployeeID = New System.Windows.Forms.ComboBox()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.SuspendLayout()
        '
        'btnInspectionMenu
        '
        Me.btnInspectionMenu.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnInspectionMenu.Location = New System.Drawing.Point(540, 230)
        Me.btnInspectionMenu.Margin = New System.Windows.Forms.Padding(2)
        Me.btnInspectionMenu.Name = "btnInspectionMenu"
        Me.btnInspectionMenu.Size = New System.Drawing.Size(167, 58)
        Me.btnInspectionMenu.TabIndex = 2
        Me.btnInspectionMenu.Text = "Inspection Menu"
        Me.btnInspectionMenu.UseVisualStyleBackColor = True
        '
        'btnVehicleInspectionReportMenu
        '
        Me.btnVehicleInspectionReportMenu.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVehicleInspectionReportMenu.Location = New System.Drawing.Point(539, 163)
        Me.btnVehicleInspectionReportMenu.Margin = New System.Windows.Forms.Padding(2)
        Me.btnVehicleInspectionReportMenu.Name = "btnVehicleInspectionReportMenu"
        Me.btnVehicleInspectionReportMenu.Size = New System.Drawing.Size(167, 58)
        Me.btnVehicleInspectionReportMenu.TabIndex = 1
        Me.btnVehicleInspectionReportMenu.Text = "Vehicle Inspection Report Menu"
        Me.btnVehicleInspectionReportMenu.UseVisualStyleBackColor = True
        '
        'btnMainMenu
        '
        Me.btnMainMenu.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMainMenu.Location = New System.Drawing.Point(540, 298)
        Me.btnMainMenu.Margin = New System.Windows.Forms.Padding(2)
        Me.btnMainMenu.Name = "btnMainMenu"
        Me.btnMainMenu.Size = New System.Drawing.Size(167, 58)
        Me.btnMainMenu.TabIndex = 3
        Me.btnMainMenu.Text = "Main Menu"
        Me.btnMainMenu.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Location = New System.Drawing.Point(540, 367)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(2)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(167, 58)
        Me.btnClose.TabIndex = 4
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(695, 58)
        Me.Label1.TabIndex = 300
        Me.Label1.Text = "Daily Vehicle Availability Report"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnRunReport
        '
        Me.btnRunReport.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRunReport.Location = New System.Drawing.Point(539, 90)
        Me.btnRunReport.Margin = New System.Windows.Forms.Padding(2)
        Me.btnRunReport.Name = "btnRunReport"
        Me.btnRunReport.Size = New System.Drawing.Size(167, 58)
        Me.btnRunReport.TabIndex = 0
        Me.btnRunReport.Text = "Run Report"
        Me.btnRunReport.UseVisualStyleBackColor = True
        '
        'cboVehicleID
        '
        Me.cboVehicleID.FormattingEnabled = True
        Me.cboVehicleID.Location = New System.Drawing.Point(116, 100)
        Me.cboVehicleID.Name = "cboVehicleID"
        Me.cboVehicleID.Size = New System.Drawing.Size(121, 21)
        Me.cboVehicleID.TabIndex = 302
        Me.cboVehicleID.Visible = False
        '
        'txtVehicleBJCNumber
        '
        Me.txtVehicleBJCNumber.Location = New System.Drawing.Point(116, 128)
        Me.txtVehicleBJCNumber.Name = "txtVehicleBJCNumber"
        Me.txtVehicleBJCNumber.ReadOnly = True
        Me.txtVehicleBJCNumber.Size = New System.Drawing.Size(121, 20)
        Me.txtVehicleBJCNumber.TabIndex = 303
        '
        'txtVehicleModel
        '
        Me.txtVehicleModel.Location = New System.Drawing.Point(116, 154)
        Me.txtVehicleModel.Name = "txtVehicleModel"
        Me.txtVehicleModel.ReadOnly = True
        Me.txtVehicleModel.Size = New System.Drawing.Size(121, 20)
        Me.txtVehicleModel.TabIndex = 304
        '
        'txtVehicleActive
        '
        Me.txtVehicleActive.Location = New System.Drawing.Point(116, 180)
        Me.txtVehicleActive.Name = "txtVehicleActive"
        Me.txtVehicleActive.ReadOnly = True
        Me.txtVehicleActive.Size = New System.Drawing.Size(121, 20)
        Me.txtVehicleActive.TabIndex = 305
        '
        'txtVehicleAvaiable
        '
        Me.txtVehicleAvaiable.Location = New System.Drawing.Point(116, 211)
        Me.txtVehicleAvaiable.Name = "txtVehicleAvaiable"
        Me.txtVehicleAvaiable.ReadOnly = True
        Me.txtVehicleAvaiable.Size = New System.Drawing.Size(121, 20)
        Me.txtVehicleAvaiable.TabIndex = 306
        '
        'txtVehicleEmployeeID
        '
        Me.txtVehicleEmployeeID.Location = New System.Drawing.Point(116, 240)
        Me.txtVehicleEmployeeID.Name = "txtVehicleEmployeeID"
        Me.txtVehicleEmployeeID.ReadOnly = True
        Me.txtVehicleEmployeeID.Size = New System.Drawing.Size(121, 20)
        Me.txtVehicleEmployeeID.TabIndex = 307
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(10, 128)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 23)
        Me.Label2.TabIndex = 308
        Me.Label2.Text = "BJC Number"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(10, 98)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 23)
        Me.Label3.TabIndex = 309
        Me.Label3.Text = "Vehicle ID"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(10, 152)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 23)
        Me.Label4.TabIndex = 310
        Me.Label4.Text = "Model"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(12, 178)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 23)
        Me.Label5.TabIndex = 311
        Me.Label5.Text = "Active"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(10, 209)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 23)
        Me.Label6.TabIndex = 312
        Me.Label6.Text = "Available"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(10, 238)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 23)
        Me.Label7.TabIndex = 313
        Me.Label7.Text = "Employee ID"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(10, 371)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 23)
        Me.Label8.TabIndex = 319
        Me.Label8.Text = "BJC Number"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(10, 317)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(100, 23)
        Me.Label9.TabIndex = 318
        Me.Label9.Text = "Transaction ID"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(10, 347)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(100, 23)
        Me.Label10.TabIndex = 317
        Me.Label10.Text = "Transaction Date"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtTransactionBJCNumber
        '
        Me.txtTransactionBJCNumber.Location = New System.Drawing.Point(116, 373)
        Me.txtTransactionBJCNumber.Name = "txtTransactionBJCNumber"
        Me.txtTransactionBJCNumber.ReadOnly = True
        Me.txtTransactionBJCNumber.Size = New System.Drawing.Size(121, 20)
        Me.txtTransactionBJCNumber.TabIndex = 316
        '
        'txtTransactionDate
        '
        Me.txtTransactionDate.Location = New System.Drawing.Point(116, 347)
        Me.txtTransactionDate.Name = "txtTransactionDate"
        Me.txtTransactionDate.ReadOnly = True
        Me.txtTransactionDate.Size = New System.Drawing.Size(121, 20)
        Me.txtTransactionDate.TabIndex = 315
        '
        'cboTransactionID
        '
        Me.cboTransactionID.FormattingEnabled = True
        Me.cboTransactionID.Location = New System.Drawing.Point(116, 319)
        Me.cboTransactionID.Name = "cboTransactionID"
        Me.cboTransactionID.Size = New System.Drawing.Size(121, 21)
        Me.cboTransactionID.TabIndex = 314
        Me.cboTransactionID.Visible = False
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(279, 163)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(100, 23)
        Me.Label11.TabIndex = 325
        Me.Label11.Text = "Last Name"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(279, 109)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(100, 23)
        Me.Label12.TabIndex = 324
        Me.Label12.Text = "Employee ID"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(279, 139)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(100, 23)
        Me.Label13.TabIndex = 323
        Me.Label13.Text = "First Name"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtLastName
        '
        Me.txtLastName.Location = New System.Drawing.Point(385, 165)
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.ReadOnly = True
        Me.txtLastName.Size = New System.Drawing.Size(121, 20)
        Me.txtLastName.TabIndex = 322
        '
        'txtFirstName
        '
        Me.txtFirstName.Location = New System.Drawing.Point(385, 139)
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.ReadOnly = True
        Me.txtFirstName.Size = New System.Drawing.Size(121, 20)
        Me.txtFirstName.TabIndex = 321
        '
        'cboEmployeeID
        '
        Me.cboEmployeeID.FormattingEnabled = True
        Me.cboEmployeeID.Location = New System.Drawing.Point(385, 111)
        Me.cboEmployeeID.Name = "cboEmployeeID"
        Me.cboEmployeeID.Size = New System.Drawing.Size(121, 21)
        Me.cboEmployeeID.TabIndex = 320
        Me.cboEmployeeID.Visible = False
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'DailyVehicleAvailabilityReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(730, 457)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtLastName)
        Me.Controls.Add(Me.txtFirstName)
        Me.Controls.Add(Me.cboEmployeeID)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtTransactionBJCNumber)
        Me.Controls.Add(Me.txtTransactionDate)
        Me.Controls.Add(Me.cboTransactionID)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtVehicleEmployeeID)
        Me.Controls.Add(Me.txtVehicleAvaiable)
        Me.Controls.Add(Me.txtVehicleActive)
        Me.Controls.Add(Me.txtVehicleModel)
        Me.Controls.Add(Me.txtVehicleBJCNumber)
        Me.Controls.Add(Me.cboVehicleID)
        Me.Controls.Add(Me.btnRunReport)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnInspectionMenu)
        Me.Controls.Add(Me.btnVehicleInspectionReportMenu)
        Me.Controls.Add(Me.btnMainMenu)
        Me.Controls.Add(Me.btnClose)
        Me.Name = "DailyVehicleAvailabilityReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DailyVehicleAvailabilityReport"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnInspectionMenu As System.Windows.Forms.Button
    Friend WithEvents btnVehicleInspectionReportMenu As System.Windows.Forms.Button
    Friend WithEvents btnMainMenu As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnRunReport As System.Windows.Forms.Button
    Friend WithEvents cboVehicleID As System.Windows.Forms.ComboBox
    Friend WithEvents txtVehicleBJCNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtVehicleModel As System.Windows.Forms.TextBox
    Friend WithEvents txtVehicleActive As System.Windows.Forms.TextBox
    Friend WithEvents txtVehicleAvaiable As System.Windows.Forms.TextBox
    Friend WithEvents txtVehicleEmployeeID As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtTransactionBJCNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtTransactionDate As System.Windows.Forms.TextBox
    Friend WithEvents cboTransactionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtLastName As System.Windows.Forms.TextBox
    Friend WithEvents txtFirstName As System.Windows.Forms.TextBox
    Friend WithEvents cboEmployeeID As System.Windows.Forms.ComboBox
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
End Class
