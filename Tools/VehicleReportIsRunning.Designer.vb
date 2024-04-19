<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VehicleReportIsRunning
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
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtSheetPresent = New System.Windows.Forms.TextBox()
        Me.txtDate = New System.Windows.Forms.TextBox()
        Me.cboTransactionID = New System.Windows.Forms.ComboBox()
        Me.txtBJCNumber = New System.Windows.Forms.TextBox()
        Me.btnMainForm = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnVehicleInspectionReports = New System.Windows.Forms.Button()
        Me.btnInspectionMenu = New System.Windows.Forms.Button()
        Me.btnRunReport = New System.Windows.Forms.Button()
        Me.txtDOTForm = New System.Windows.Forms.TextBox()
        Me.dgvSearchResults = New System.Windows.Forms.DataGridView()
        Me.txtHomeOffice = New System.Windows.Forms.TextBox()
        CType(Me.dgvSearchResults, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(13, 25)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(1040, 78)
        Me.Label14.TabIndex = 54
        Me.Label14.Text = "Daily Vehicle Audit Information"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtSheetPresent
        '
        Me.txtSheetPresent.Location = New System.Drawing.Point(250, 273)
        Me.txtSheetPresent.Margin = New System.Windows.Forms.Padding(4)
        Me.txtSheetPresent.Name = "txtSheetPresent"
        Me.txtSheetPresent.Size = New System.Drawing.Size(160, 22)
        Me.txtSheetPresent.TabIndex = 48
        '
        'txtDate
        '
        Me.txtDate.Location = New System.Drawing.Point(250, 241)
        Me.txtDate.Margin = New System.Windows.Forms.Padding(4)
        Me.txtDate.Name = "txtDate"
        Me.txtDate.Size = New System.Drawing.Size(160, 22)
        Me.txtDate.TabIndex = 47
        '
        'cboTransactionID
        '
        Me.cboTransactionID.FormattingEnabled = True
        Me.cboTransactionID.Location = New System.Drawing.Point(250, 176)
        Me.cboTransactionID.Margin = New System.Windows.Forms.Padding(4)
        Me.cboTransactionID.Name = "cboTransactionID"
        Me.cboTransactionID.Size = New System.Drawing.Size(160, 24)
        Me.cboTransactionID.TabIndex = 46
        '
        'txtBJCNumber
        '
        Me.txtBJCNumber.Location = New System.Drawing.Point(250, 209)
        Me.txtBJCNumber.Margin = New System.Windows.Forms.Padding(4)
        Me.txtBJCNumber.Name = "txtBJCNumber"
        Me.txtBJCNumber.Size = New System.Drawing.Size(160, 22)
        Me.txtBJCNumber.TabIndex = 45
        '
        'btnMainForm
        '
        Me.btnMainForm.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMainForm.Location = New System.Drawing.Point(832, 371)
        Me.btnMainForm.Margin = New System.Windows.Forms.Padding(4)
        Me.btnMainForm.Name = "btnMainForm"
        Me.btnMainForm.Size = New System.Drawing.Size(221, 73)
        Me.btnMainForm.TabIndex = 40
        Me.btnMainForm.Text = "Main Menu"
        Me.btnMainForm.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Location = New System.Drawing.Point(832, 452)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(4)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(221, 73)
        Me.btnClose.TabIndex = 39
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnVehicleInspectionReports
        '
        Me.btnVehicleInspectionReports.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVehicleInspectionReports.Location = New System.Drawing.Point(832, 209)
        Me.btnVehicleInspectionReports.Margin = New System.Windows.Forms.Padding(4)
        Me.btnVehicleInspectionReports.Name = "btnVehicleInspectionReports"
        Me.btnVehicleInspectionReports.Size = New System.Drawing.Size(221, 73)
        Me.btnVehicleInspectionReports.TabIndex = 65
        Me.btnVehicleInspectionReports.Text = "Vehicle Inspection Reports Menu"
        Me.btnVehicleInspectionReports.UseVisualStyleBackColor = True
        '
        'btnInspectionMenu
        '
        Me.btnInspectionMenu.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnInspectionMenu.Location = New System.Drawing.Point(832, 290)
        Me.btnInspectionMenu.Margin = New System.Windows.Forms.Padding(4)
        Me.btnInspectionMenu.Name = "btnInspectionMenu"
        Me.btnInspectionMenu.Size = New System.Drawing.Size(221, 73)
        Me.btnInspectionMenu.TabIndex = 64
        Me.btnInspectionMenu.Text = "Inspection Menu"
        Me.btnInspectionMenu.UseVisualStyleBackColor = True
        '
        'btnRunReport
        '
        Me.btnRunReport.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRunReport.Location = New System.Drawing.Point(832, 126)
        Me.btnRunReport.Margin = New System.Windows.Forms.Padding(4)
        Me.btnRunReport.Name = "btnRunReport"
        Me.btnRunReport.Size = New System.Drawing.Size(221, 73)
        Me.btnRunReport.TabIndex = 63
        Me.btnRunReport.Text = "Run Report"
        Me.btnRunReport.UseVisualStyleBackColor = True
        '
        'txtDOTForm
        '
        Me.txtDOTForm.Location = New System.Drawing.Point(250, 319)
        Me.txtDOTForm.Margin = New System.Windows.Forms.Padding(4)
        Me.txtDOTForm.Name = "txtDOTForm"
        Me.txtDOTForm.Size = New System.Drawing.Size(160, 22)
        Me.txtDOTForm.TabIndex = 66
        '
        'dgvSearchResults
        '
        Me.dgvSearchResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSearchResults.Location = New System.Drawing.Point(19, 126)
        Me.dgvSearchResults.Name = "dgvSearchResults"
        Me.dgvSearchResults.RowTemplate.Height = 24
        Me.dgvSearchResults.Size = New System.Drawing.Size(793, 399)
        Me.dgvSearchResults.TabIndex = 67
        '
        'txtHomeOffice
        '
        Me.txtHomeOffice.Location = New System.Drawing.Point(250, 371)
        Me.txtHomeOffice.Margin = New System.Windows.Forms.Padding(4)
        Me.txtHomeOffice.Name = "txtHomeOffice"
        Me.txtHomeOffice.Size = New System.Drawing.Size(160, 22)
        Me.txtHomeOffice.TabIndex = 68
        '
        'VehicleReportIsRunning
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1066, 558)
        Me.ControlBox = False
        Me.Controls.Add(Me.dgvSearchResults)
        Me.Controls.Add(Me.txtHomeOffice)
        Me.Controls.Add(Me.txtDOTForm)
        Me.Controls.Add(Me.btnVehicleInspectionReports)
        Me.Controls.Add(Me.btnInspectionMenu)
        Me.Controls.Add(Me.btnRunReport)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtSheetPresent)
        Me.Controls.Add(Me.txtDate)
        Me.Controls.Add(Me.cboTransactionID)
        Me.Controls.Add(Me.txtBJCNumber)
        Me.Controls.Add(Me.btnMainForm)
        Me.Controls.Add(Me.btnClose)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "VehicleReportIsRunning"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "VehicleReportIsRunning"
        CType(Me.dgvSearchResults, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtSheetPresent As System.Windows.Forms.TextBox
    Friend WithEvents txtDate As System.Windows.Forms.TextBox
    Friend WithEvents cboTransactionID As System.Windows.Forms.ComboBox
    Friend WithEvents txtBJCNumber As System.Windows.Forms.TextBox
    Friend WithEvents btnMainForm As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnVehicleInspectionReports As System.Windows.Forms.Button
    Friend WithEvents btnInspectionMenu As System.Windows.Forms.Button
    Friend WithEvents btnRunReport As System.Windows.Forms.Button
    Friend WithEvents txtDOTForm As System.Windows.Forms.TextBox
    Friend WithEvents dgvSearchResults As System.Windows.Forms.DataGridView
    Friend WithEvents txtHomeOffice As System.Windows.Forms.TextBox
End Class
