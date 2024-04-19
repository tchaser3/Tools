<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VehicleInspectionReports
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
        Me.btnInspectionsMenu = New System.Windows.Forms.Button()
        Me.btnVehicleAuditReport = New System.Windows.Forms.Button()
        Me.btnMainMenu = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnWeeklyVehicleInspectionsReport = New System.Windows.Forms.Button()
        Me.btnAvailableVehiclesReport = New System.Windows.Forms.Button()
        Me.btnVehicleInspectionHistory = New System.Windows.Forms.Button()
        Me.btnDailyVehicleInspectionReport = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(23, 11)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(485, 94)
        Me.Label1.TabIndex = 40
        Me.Label1.Text = "Vehicle Inspection Reports"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnInspectionsMenu
        '
        Me.btnInspectionsMenu.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnInspectionsMenu.Location = New System.Drawing.Point(275, 249)
        Me.btnInspectionsMenu.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnInspectionsMenu.Name = "btnInspectionsMenu"
        Me.btnInspectionsMenu.Size = New System.Drawing.Size(233, 63)
        Me.btnInspectionsMenu.TabIndex = 5
        Me.btnInspectionsMenu.Text = "Inspections Menu"
        Me.btnInspectionsMenu.UseVisualStyleBackColor = True
        '
        'btnVehicleAuditReport
        '
        Me.btnVehicleAuditReport.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVehicleAuditReport.Location = New System.Drawing.Point(275, 114)
        Me.btnVehicleAuditReport.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnVehicleAuditReport.Name = "btnVehicleAuditReport"
        Me.btnVehicleAuditReport.Size = New System.Drawing.Size(233, 63)
        Me.btnVehicleAuditReport.TabIndex = 1
        Me.btnVehicleAuditReport.Text = "Vehicle Audit Report"
        Me.btnVehicleAuditReport.UseVisualStyleBackColor = True
        '
        'btnMainMenu
        '
        Me.btnMainMenu.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMainMenu.Location = New System.Drawing.Point(23, 318)
        Me.btnMainMenu.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnMainMenu.Name = "btnMainMenu"
        Me.btnMainMenu.Size = New System.Drawing.Size(233, 63)
        Me.btnMainMenu.TabIndex = 6
        Me.btnMainMenu.Text = "Main Menu"
        Me.btnMainMenu.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Location = New System.Drawing.Point(275, 318)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(233, 63)
        Me.btnClose.TabIndex = 7
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnWeeklyVehicleInspectionsReport
        '
        Me.btnWeeklyVehicleInspectionsReport.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnWeeklyVehicleInspectionsReport.Location = New System.Drawing.Point(23, 182)
        Me.btnWeeklyVehicleInspectionsReport.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnWeeklyVehicleInspectionsReport.Name = "btnWeeklyVehicleInspectionsReport"
        Me.btnWeeklyVehicleInspectionsReport.Size = New System.Drawing.Size(233, 63)
        Me.btnWeeklyVehicleInspectionsReport.TabIndex = 2
        Me.btnWeeklyVehicleInspectionsReport.Text = "Weekly Vehicle Inspections Report"
        Me.btnWeeklyVehicleInspectionsReport.UseVisualStyleBackColor = True
        '
        'btnAvailableVehiclesReport
        '
        Me.btnAvailableVehiclesReport.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAvailableVehiclesReport.Location = New System.Drawing.Point(23, 115)
        Me.btnAvailableVehiclesReport.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnAvailableVehiclesReport.Name = "btnAvailableVehiclesReport"
        Me.btnAvailableVehiclesReport.Size = New System.Drawing.Size(233, 63)
        Me.btnAvailableVehiclesReport.TabIndex = 0
        Me.btnAvailableVehiclesReport.Text = "Available Vehicles Report"
        Me.btnAvailableVehiclesReport.UseVisualStyleBackColor = True
        '
        'btnVehicleInspectionHistory
        '
        Me.btnVehicleInspectionHistory.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVehicleInspectionHistory.Location = New System.Drawing.Point(23, 249)
        Me.btnVehicleInspectionHistory.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnVehicleInspectionHistory.Name = "btnVehicleInspectionHistory"
        Me.btnVehicleInspectionHistory.Size = New System.Drawing.Size(233, 63)
        Me.btnVehicleInspectionHistory.TabIndex = 4
        Me.btnVehicleInspectionHistory.Text = "Vehicle Inspection History"
        Me.btnVehicleInspectionHistory.UseVisualStyleBackColor = True
        '
        'btnDailyVehicleInspectionReport
        '
        Me.btnDailyVehicleInspectionReport.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDailyVehicleInspectionReport.Location = New System.Drawing.Point(275, 182)
        Me.btnDailyVehicleInspectionReport.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnDailyVehicleInspectionReport.Name = "btnDailyVehicleInspectionReport"
        Me.btnDailyVehicleInspectionReport.Size = New System.Drawing.Size(233, 63)
        Me.btnDailyVehicleInspectionReport.TabIndex = 3
        Me.btnDailyVehicleInspectionReport.Text = "Daily Vehicle Inspection Report"
        Me.btnDailyVehicleInspectionReport.UseVisualStyleBackColor = True
        '
        'VehicleInspectionReports
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(537, 401)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnVehicleInspectionHistory)
        Me.Controls.Add(Me.btnDailyVehicleInspectionReport)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnInspectionsMenu)
        Me.Controls.Add(Me.btnVehicleAuditReport)
        Me.Controls.Add(Me.btnMainMenu)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnWeeklyVehicleInspectionsReport)
        Me.Controls.Add(Me.btnAvailableVehiclesReport)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "VehicleInspectionReports"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "VehicleInspectionReports"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnInspectionsMenu As System.Windows.Forms.Button
    Friend WithEvents btnVehicleAuditReport As System.Windows.Forms.Button
    Friend WithEvents btnMainMenu As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnWeeklyVehicleInspectionsReport As System.Windows.Forms.Button
    Friend WithEvents btnAvailableVehiclesReport As System.Windows.Forms.Button
    Friend WithEvents btnVehicleInspectionHistory As System.Windows.Forms.Button
    Friend WithEvents btnDailyVehicleInspectionReport As System.Windows.Forms.Button
End Class
