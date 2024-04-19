<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VehicleRepairID
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
        Me.cboVehicleRepairID = New System.Windows.Forms.ComboBox()
        Me.txtTransactionID = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'cboVehicleRepairID
        '
        Me.cboVehicleRepairID.FormattingEnabled = True
        Me.cboVehicleRepairID.Location = New System.Drawing.Point(30, 31)
        Me.cboVehicleRepairID.Name = "cboVehicleRepairID"
        Me.cboVehicleRepairID.Size = New System.Drawing.Size(121, 21)
        Me.cboVehicleRepairID.TabIndex = 0
        '
        'txtTransactionID
        '
        Me.txtTransactionID.Location = New System.Drawing.Point(30, 59)
        Me.txtTransactionID.Name = "txtTransactionID"
        Me.txtTransactionID.Size = New System.Drawing.Size(121, 20)
        Me.txtTransactionID.TabIndex = 1
        '
        'VehicleRepairID
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(195, 109)
        Me.Controls.Add(Me.txtTransactionID)
        Me.Controls.Add(Me.cboVehicleRepairID)
        Me.Name = "VehicleRepairID"
        Me.Text = "VehicleRepairID"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboVehicleRepairID As System.Windows.Forms.ComboBox
    Friend WithEvents txtTransactionID As System.Windows.Forms.TextBox
End Class
