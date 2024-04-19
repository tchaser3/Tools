<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MaintenanceReports
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
        Me.btnInvoicedWorkOrderReports = New System.Windows.Forms.Button()
        Me.btnOpenWorkOrderReport = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnMaintenanceMenu = New System.Windows.Forms.Button()
        Me.btnMainMenu = New System.Windows.Forms.Button()
        Me.btnVehicleWorkOrderHistoryReport = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 9)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(500, 52)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Maintenance Reports Menu"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnInvoicedWorkOrderReports
        '
        Me.btnInvoicedWorkOrderReports.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnInvoicedWorkOrderReports.Location = New System.Drawing.Point(15, 187)
        Me.btnInvoicedWorkOrderReports.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnInvoicedWorkOrderReports.Name = "btnInvoicedWorkOrderReports"
        Me.btnInvoicedWorkOrderReports.Size = New System.Drawing.Size(235, 63)
        Me.btnInvoicedWorkOrderReports.TabIndex = 2
        Me.btnInvoicedWorkOrderReports.Text = "Invoiced Work Orders Report"
        Me.btnInvoicedWorkOrderReports.UseVisualStyleBackColor = True
        '
        'btnOpenWorkOrderReport
        '
        Me.btnOpenWorkOrderReport.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOpenWorkOrderReport.Location = New System.Drawing.Point(15, 106)
        Me.btnOpenWorkOrderReport.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnOpenWorkOrderReport.Name = "btnOpenWorkOrderReport"
        Me.btnOpenWorkOrderReport.Size = New System.Drawing.Size(235, 63)
        Me.btnOpenWorkOrderReport.TabIndex = 0
        Me.btnOpenWorkOrderReport.Text = "Open Work Order Report"
        Me.btnOpenWorkOrderReport.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Location = New System.Drawing.Point(277, 268)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(235, 63)
        Me.btnClose.TabIndex = 5
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnMaintenanceMenu
        '
        Me.btnMaintenanceMenu.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMaintenanceMenu.Location = New System.Drawing.Point(275, 187)
        Me.btnMaintenanceMenu.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnMaintenanceMenu.Name = "btnMaintenanceMenu"
        Me.btnMaintenanceMenu.Size = New System.Drawing.Size(235, 63)
        Me.btnMaintenanceMenu.TabIndex = 3
        Me.btnMaintenanceMenu.Text = "Maintenance Menu"
        Me.btnMaintenanceMenu.UseVisualStyleBackColor = True
        '
        'btnMainMenu
        '
        Me.btnMainMenu.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMainMenu.Location = New System.Drawing.Point(15, 268)
        Me.btnMainMenu.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnMainMenu.Name = "btnMainMenu"
        Me.btnMainMenu.Size = New System.Drawing.Size(235, 63)
        Me.btnMainMenu.TabIndex = 4
        Me.btnMainMenu.Text = "Main Menu"
        Me.btnMainMenu.UseVisualStyleBackColor = True
        '
        'btnVehicleWorkOrderHistoryReport
        '
        Me.btnVehicleWorkOrderHistoryReport.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVehicleWorkOrderHistoryReport.Location = New System.Drawing.Point(277, 106)
        Me.btnVehicleWorkOrderHistoryReport.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnVehicleWorkOrderHistoryReport.Name = "btnVehicleWorkOrderHistoryReport"
        Me.btnVehicleWorkOrderHistoryReport.Size = New System.Drawing.Size(233, 63)
        Me.btnVehicleWorkOrderHistoryReport.TabIndex = 1
        Me.btnVehicleWorkOrderHistoryReport.Text = "Vehicle Work Order History Report"
        Me.btnVehicleWorkOrderHistoryReport.UseVisualStyleBackColor = True
        '
        'MaintenanceReports
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(526, 364)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnInvoicedWorkOrderReports)
        Me.Controls.Add(Me.btnOpenWorkOrderReport)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnMaintenanceMenu)
        Me.Controls.Add(Me.btnMainMenu)
        Me.Controls.Add(Me.btnVehicleWorkOrderHistoryReport)
        Me.Controls.Add(Me.Label1)
        Me.Name = "MaintenanceReports"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MaintenanceReports"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnInvoicedWorkOrderReports As System.Windows.Forms.Button
    Friend WithEvents btnOpenWorkOrderReport As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnMaintenanceMenu As System.Windows.Forms.Button
    Friend WithEvents btnMainMenu As System.Windows.Forms.Button
    Friend WithEvents btnVehicleWorkOrderHistoryReport As System.Windows.Forms.Button
End Class
