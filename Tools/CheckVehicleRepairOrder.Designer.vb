<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CheckVehicleRepairOrder
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
        Me.btnNo = New System.Windows.Forms.Button()
        Me.btnYes = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblNoOpenRepairOrders = New System.Windows.Forms.Label()
        Me.txtWorkOrderStatus = New System.Windows.Forms.TextBox()
        Me.txtWorkOrderVehicleID = New System.Windows.Forms.TextBox()
        Me.cboTransactionID = New System.Windows.Forms.ComboBox()
        Me.txtVehicleActive = New System.Windows.Forms.TextBox()
        Me.txtVehicleBJCNumber = New System.Windows.Forms.TextBox()
        Me.cboVehicleID = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'btnNo
        '
        Me.btnNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNo.Location = New System.Drawing.Point(295, 254)
        Me.btnNo.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnNo.Name = "btnNo"
        Me.btnNo.Size = New System.Drawing.Size(223, 71)
        Me.btnNo.TabIndex = 14
        Me.btnNo.Text = "No"
        Me.btnNo.UseVisualStyleBackColor = True
        '
        'btnYes
        '
        Me.btnYes.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnYes.Location = New System.Drawing.Point(32, 254)
        Me.btnYes.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnYes.Name = "btnYes"
        Me.btnYes.Size = New System.Drawing.Size(223, 71)
        Me.btnYes.TabIndex = 15
        Me.btnYes.Text = "Yes"
        Me.btnYes.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 9)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(496, 52)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "Check For Open Vehicle Repair Orders"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblNoOpenRepairOrders
        '
        Me.lblNoOpenRepairOrders.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoOpenRepairOrders.Location = New System.Drawing.Point(26, 70)
        Me.lblNoOpenRepairOrders.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblNoOpenRepairOrders.Name = "lblNoOpenRepairOrders"
        Me.lblNoOpenRepairOrders.Size = New System.Drawing.Size(483, 156)
        Me.lblNoOpenRepairOrders.TabIndex = 28
        Me.lblNoOpenRepairOrders.Text = "There Are No Open Repair Orders For This Vehicle, Do You Want To Create One"
        Me.lblNoOpenRepairOrders.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtWorkOrderStatus
        '
        Me.txtWorkOrderStatus.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtWorkOrderStatus.Location = New System.Drawing.Point(81, 166)
        Me.txtWorkOrderStatus.Margin = New System.Windows.Forms.Padding(4)
        Me.txtWorkOrderStatus.Name = "txtWorkOrderStatus"
        Me.txtWorkOrderStatus.ReadOnly = True
        Me.txtWorkOrderStatus.Size = New System.Drawing.Size(160, 22)
        Me.txtWorkOrderStatus.TabIndex = 35
        '
        'txtWorkOrderVehicleID
        '
        Me.txtWorkOrderVehicleID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtWorkOrderVehicleID.Location = New System.Drawing.Point(81, 133)
        Me.txtWorkOrderVehicleID.Margin = New System.Windows.Forms.Padding(4)
        Me.txtWorkOrderVehicleID.Name = "txtWorkOrderVehicleID"
        Me.txtWorkOrderVehicleID.ReadOnly = True
        Me.txtWorkOrderVehicleID.Size = New System.Drawing.Size(160, 22)
        Me.txtWorkOrderVehicleID.TabIndex = 30
        '
        'cboTransactionID
        '
        Me.cboTransactionID.FormattingEnabled = True
        Me.cboTransactionID.Location = New System.Drawing.Point(81, 101)
        Me.cboTransactionID.Margin = New System.Windows.Forms.Padding(4)
        Me.cboTransactionID.Name = "cboTransactionID"
        Me.cboTransactionID.Size = New System.Drawing.Size(160, 24)
        Me.cboTransactionID.TabIndex = 29
        '
        'txtVehicleActive
        '
        Me.txtVehicleActive.Location = New System.Drawing.Point(318, 166)
        Me.txtVehicleActive.Margin = New System.Windows.Forms.Padding(4)
        Me.txtVehicleActive.Name = "txtVehicleActive"
        Me.txtVehicleActive.ReadOnly = True
        Me.txtVehicleActive.Size = New System.Drawing.Size(160, 22)
        Me.txtVehicleActive.TabIndex = 442
        '
        'txtVehicleBJCNumber
        '
        Me.txtVehicleBJCNumber.Location = New System.Drawing.Point(318, 133)
        Me.txtVehicleBJCNumber.Margin = New System.Windows.Forms.Padding(4)
        Me.txtVehicleBJCNumber.Name = "txtVehicleBJCNumber"
        Me.txtVehicleBJCNumber.ReadOnly = True
        Me.txtVehicleBJCNumber.Size = New System.Drawing.Size(160, 22)
        Me.txtVehicleBJCNumber.TabIndex = 441
        '
        'cboVehicleID
        '
        Me.cboVehicleID.FormattingEnabled = True
        Me.cboVehicleID.Location = New System.Drawing.Point(318, 95)
        Me.cboVehicleID.Margin = New System.Windows.Forms.Padding(4)
        Me.cboVehicleID.Name = "cboVehicleID"
        Me.cboVehicleID.Size = New System.Drawing.Size(160, 24)
        Me.cboVehicleID.TabIndex = 440
        Me.cboVehicleID.Visible = False
        '
        'CheckVehicleRepairOrder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(548, 356)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblNoOpenRepairOrders)
        Me.Controls.Add(Me.txtVehicleActive)
        Me.Controls.Add(Me.txtVehicleBJCNumber)
        Me.Controls.Add(Me.cboVehicleID)
        Me.Controls.Add(Me.txtWorkOrderStatus)
        Me.Controls.Add(Me.txtWorkOrderVehicleID)
        Me.Controls.Add(Me.cboTransactionID)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnYes)
        Me.Controls.Add(Me.btnNo)
        Me.Name = "CheckVehicleRepairOrder"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CheckVehicleRepairOrder"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnNo As System.Windows.Forms.Button
    Friend WithEvents btnYes As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblNoOpenRepairOrders As System.Windows.Forms.Label
    Friend WithEvents txtWorkOrderStatus As System.Windows.Forms.TextBox
    Friend WithEvents txtWorkOrderVehicleID As System.Windows.Forms.TextBox
    Friend WithEvents cboTransactionID As System.Windows.Forms.ComboBox
    Friend WithEvents txtVehicleActive As System.Windows.Forms.TextBox
    Friend WithEvents txtVehicleBJCNumber As System.Windows.Forms.TextBox
    Friend WithEvents cboVehicleID As System.Windows.Forms.ComboBox
End Class
