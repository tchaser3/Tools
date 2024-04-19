<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OpenVehicleWorkOrderReport
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
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnMaintenanceMenu = New System.Windows.Forms.Button()
        Me.btnMainMenu = New System.Windows.Forms.Button()
        Me.btnMaintenanceReportMenu = New System.Windows.Forms.Button()
        Me.btnPrintReport = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.txtDateReported = New System.Windows.Forms.TextBox()
        Me.txtVendorID = New System.Windows.Forms.TextBox()
        Me.txtProblemDescription = New System.Windows.Forms.TextBox()
        Me.txtOdometer = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtVehicleID = New System.Windows.Forms.TextBox()
        Me.cboTransactionID = New System.Windows.Forms.ComboBox()
        Me.dgvSearchResults = New System.Windows.Forms.DataGridView()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        CType(Me.dgvSearchResults, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 21)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(877, 52)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "Open Vehicle Work Order Report"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnClose
        '
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Location = New System.Drawing.Point(655, 380)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(235, 63)
        Me.btnClose.TabIndex = 4
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnMaintenanceMenu
        '
        Me.btnMaintenanceMenu.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMaintenanceMenu.Location = New System.Drawing.Point(655, 246)
        Me.btnMaintenanceMenu.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnMaintenanceMenu.Name = "btnMaintenanceMenu"
        Me.btnMaintenanceMenu.Size = New System.Drawing.Size(235, 63)
        Me.btnMaintenanceMenu.TabIndex = 2
        Me.btnMaintenanceMenu.Text = "Maintenance Menu"
        Me.btnMaintenanceMenu.UseVisualStyleBackColor = True
        '
        'btnMainMenu
        '
        Me.btnMainMenu.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMainMenu.Location = New System.Drawing.Point(655, 313)
        Me.btnMainMenu.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnMainMenu.Name = "btnMainMenu"
        Me.btnMainMenu.Size = New System.Drawing.Size(235, 63)
        Me.btnMainMenu.TabIndex = 3
        Me.btnMainMenu.Text = "Main Menu"
        Me.btnMainMenu.UseVisualStyleBackColor = True
        '
        'btnMaintenanceReportMenu
        '
        Me.btnMaintenanceReportMenu.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMaintenanceReportMenu.Location = New System.Drawing.Point(655, 179)
        Me.btnMaintenanceReportMenu.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnMaintenanceReportMenu.Name = "btnMaintenanceReportMenu"
        Me.btnMaintenanceReportMenu.Size = New System.Drawing.Size(235, 63)
        Me.btnMaintenanceReportMenu.TabIndex = 1
        Me.btnMaintenanceReportMenu.Text = "Maintenance Report Menu"
        Me.btnMaintenanceReportMenu.UseVisualStyleBackColor = True
        '
        'btnPrintReport
        '
        Me.btnPrintReport.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrintReport.Location = New System.Drawing.Point(655, 112)
        Me.btnPrintReport.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnPrintReport.Name = "btnPrintReport"
        Me.btnPrintReport.Size = New System.Drawing.Size(235, 63)
        Me.btnPrintReport.TabIndex = 0
        Me.btnPrintReport.Text = "Print Report"
        Me.btnPrintReport.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(161, 394)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(180, 28)
        Me.Label9.TabIndex = 427
        Me.Label9.Text = "Status"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(161, 357)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(180, 28)
        Me.Label6.TabIndex = 426
        Me.Label6.Text = "Date Reported"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(161, 321)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(180, 28)
        Me.Label5.TabIndex = 425
        Me.Label5.Text = "Vendor ID"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(161, 247)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(180, 28)
        Me.Label4.TabIndex = 424
        Me.Label4.Text = "Problem Description"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(161, 177)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(180, 28)
        Me.Label3.TabIndex = 423
        Me.Label3.Text = "Odometer"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(161, 142)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(180, 28)
        Me.Label2.TabIndex = 422
        Me.Label2.Text = "Vehicle ID"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtStatus
        '
        Me.txtStatus.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtStatus.Location = New System.Drawing.Point(349, 396)
        Me.txtStatus.Margin = New System.Windows.Forms.Padding(4)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.ReadOnly = True
        Me.txtStatus.Size = New System.Drawing.Size(160, 22)
        Me.txtStatus.TabIndex = 420
        '
        'txtDateReported
        '
        Me.txtDateReported.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDateReported.Location = New System.Drawing.Point(349, 359)
        Me.txtDateReported.Margin = New System.Windows.Forms.Padding(4)
        Me.txtDateReported.Name = "txtDateReported"
        Me.txtDateReported.ReadOnly = True
        Me.txtDateReported.Size = New System.Drawing.Size(160, 22)
        Me.txtDateReported.TabIndex = 419
        '
        'txtVendorID
        '
        Me.txtVendorID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtVendorID.Location = New System.Drawing.Point(349, 324)
        Me.txtVendorID.Margin = New System.Windows.Forms.Padding(4)
        Me.txtVendorID.Name = "txtVendorID"
        Me.txtVendorID.ReadOnly = True
        Me.txtVendorID.Size = New System.Drawing.Size(160, 22)
        Me.txtVendorID.TabIndex = 418
        '
        'txtProblemDescription
        '
        Me.txtProblemDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProblemDescription.Location = New System.Drawing.Point(349, 215)
        Me.txtProblemDescription.Margin = New System.Windows.Forms.Padding(4)
        Me.txtProblemDescription.Multiline = True
        Me.txtProblemDescription.Name = "txtProblemDescription"
        Me.txtProblemDescription.ReadOnly = True
        Me.txtProblemDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtProblemDescription.Size = New System.Drawing.Size(160, 94)
        Me.txtProblemDescription.TabIndex = 417
        '
        'txtOdometer
        '
        Me.txtOdometer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOdometer.Location = New System.Drawing.Point(349, 180)
        Me.txtOdometer.Margin = New System.Windows.Forms.Padding(4)
        Me.txtOdometer.Name = "txtOdometer"
        Me.txtOdometer.ReadOnly = True
        Me.txtOdometer.Size = New System.Drawing.Size(160, 22)
        Me.txtOdometer.TabIndex = 416
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(161, 103)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(180, 28)
        Me.Label7.TabIndex = 421
        Me.Label7.Text = "Work Order Number"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtVehicleID
        '
        Me.txtVehicleID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtVehicleID.Location = New System.Drawing.Point(349, 144)
        Me.txtVehicleID.Margin = New System.Windows.Forms.Padding(4)
        Me.txtVehicleID.Name = "txtVehicleID"
        Me.txtVehicleID.ReadOnly = True
        Me.txtVehicleID.Size = New System.Drawing.Size(160, 22)
        Me.txtVehicleID.TabIndex = 415
        '
        'cboTransactionID
        '
        Me.cboTransactionID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTransactionID.FormattingEnabled = True
        Me.cboTransactionID.Location = New System.Drawing.Point(349, 106)
        Me.cboTransactionID.Margin = New System.Windows.Forms.Padding(4)
        Me.cboTransactionID.Name = "cboTransactionID"
        Me.cboTransactionID.Size = New System.Drawing.Size(160, 24)
        Me.cboTransactionID.TabIndex = 414
        '
        'dgvSearchResults
        '
        Me.dgvSearchResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSearchResults.Location = New System.Drawing.Point(19, 94)
        Me.dgvSearchResults.Name = "dgvSearchResults"
        Me.dgvSearchResults.RowTemplate.Height = 24
        Me.dgvSearchResults.Size = New System.Drawing.Size(630, 392)
        Me.dgvSearchResults.TabIndex = 428
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'PrintDocument1
        '
        '
        'OpenVehicleWorkOrderReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(903, 498)
        Me.ControlBox = False
        Me.Controls.Add(Me.dgvSearchResults)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtStatus)
        Me.Controls.Add(Me.txtDateReported)
        Me.Controls.Add(Me.txtVendorID)
        Me.Controls.Add(Me.txtProblemDescription)
        Me.Controls.Add(Me.txtOdometer)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtVehicleID)
        Me.Controls.Add(Me.cboTransactionID)
        Me.Controls.Add(Me.btnPrintReport)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnMaintenanceMenu)
        Me.Controls.Add(Me.btnMainMenu)
        Me.Controls.Add(Me.btnMaintenanceReportMenu)
        Me.Controls.Add(Me.Label1)
        Me.Name = "OpenVehicleWorkOrderReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "OpenVehicleWorkOrderReport"
        CType(Me.dgvSearchResults, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnMaintenanceMenu As System.Windows.Forms.Button
    Friend WithEvents btnMainMenu As System.Windows.Forms.Button
    Friend WithEvents btnMaintenanceReportMenu As System.Windows.Forms.Button
    Friend WithEvents btnPrintReport As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtStatus As System.Windows.Forms.TextBox
    Friend WithEvents txtDateReported As System.Windows.Forms.TextBox
    Friend WithEvents txtVendorID As System.Windows.Forms.TextBox
    Friend WithEvents txtProblemDescription As System.Windows.Forms.TextBox
    Friend WithEvents txtOdometer As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtVehicleID As System.Windows.Forms.TextBox
    Friend WithEvents cboTransactionID As System.Windows.Forms.ComboBox
    Friend WithEvents dgvSearchResults As System.Windows.Forms.DataGridView
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
End Class
