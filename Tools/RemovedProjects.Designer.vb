<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RemovedProjects
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
        Me.txtMSRNumber = New System.Windows.Forms.TextBox()
        Me.txtSupplyingWarehouse = New System.Windows.Forms.TextBox()
        Me.cboInternalProjectID = New System.Windows.Forms.ComboBox()
        Me.txtTWCControlNumber = New System.Windows.Forms.TextBox()
        Me.txtProjectName = New System.Windows.Forms.TextBox()
        Me.txtEmployeeID = New System.Windows.Forms.TextBox()
        Me.txtDate = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'txtMSRNumber
        '
        Me.txtMSRNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMSRNumber.Location = New System.Drawing.Point(45, 182)
        Me.txtMSRNumber.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtMSRNumber.Name = "txtMSRNumber"
        Me.txtMSRNumber.Size = New System.Drawing.Size(192, 22)
        Me.txtMSRNumber.TabIndex = 398
        '
        'txtSupplyingWarehouse
        '
        Me.txtSupplyingWarehouse.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSupplyingWarehouse.Location = New System.Drawing.Point(45, 145)
        Me.txtSupplyingWarehouse.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtSupplyingWarehouse.Name = "txtSupplyingWarehouse"
        Me.txtSupplyingWarehouse.Size = New System.Drawing.Size(192, 22)
        Me.txtSupplyingWarehouse.TabIndex = 397
        '
        'cboInternalProjectID
        '
        Me.cboInternalProjectID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboInternalProjectID.FormattingEnabled = True
        Me.cboInternalProjectID.Location = New System.Drawing.Point(45, 49)
        Me.cboInternalProjectID.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cboInternalProjectID.Name = "cboInternalProjectID"
        Me.cboInternalProjectID.Size = New System.Drawing.Size(192, 24)
        Me.cboInternalProjectID.TabIndex = 399
        '
        'txtTWCControlNumber
        '
        Me.txtTWCControlNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTWCControlNumber.Location = New System.Drawing.Point(45, 113)
        Me.txtTWCControlNumber.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtTWCControlNumber.Name = "txtTWCControlNumber"
        Me.txtTWCControlNumber.Size = New System.Drawing.Size(192, 22)
        Me.txtTWCControlNumber.TabIndex = 396
        '
        'txtProjectName
        '
        Me.txtProjectName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProjectName.Location = New System.Drawing.Point(45, 85)
        Me.txtProjectName.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtProjectName.Name = "txtProjectName"
        Me.txtProjectName.Size = New System.Drawing.Size(192, 22)
        Me.txtProjectName.TabIndex = 395
        '
        'txtEmployeeID
        '
        Me.txtEmployeeID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEmployeeID.Location = New System.Drawing.Point(45, 258)
        Me.txtEmployeeID.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtEmployeeID.Name = "txtEmployeeID"
        Me.txtEmployeeID.Size = New System.Drawing.Size(192, 22)
        Me.txtEmployeeID.TabIndex = 401
        '
        'txtDate
        '
        Me.txtDate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDate.Location = New System.Drawing.Point(45, 221)
        Me.txtDate.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtDate.Name = "txtDate"
        Me.txtDate.Size = New System.Drawing.Size(192, 22)
        Me.txtDate.TabIndex = 400
        '
        'RemovedProjects
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(282, 292)
        Me.Controls.Add(Me.txtEmployeeID)
        Me.Controls.Add(Me.txtDate)
        Me.Controls.Add(Me.txtMSRNumber)
        Me.Controls.Add(Me.txtSupplyingWarehouse)
        Me.Controls.Add(Me.cboInternalProjectID)
        Me.Controls.Add(Me.txtTWCControlNumber)
        Me.Controls.Add(Me.txtProjectName)
        Me.Name = "RemovedProjects"
        Me.Text = "RemovedProjects"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtMSRNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtSupplyingWarehouse As System.Windows.Forms.TextBox
    Friend WithEvents cboInternalProjectID As System.Windows.Forms.ComboBox
    Friend WithEvents txtTWCControlNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtProjectName As System.Windows.Forms.TextBox
    Friend WithEvents txtEmployeeID As System.Windows.Forms.TextBox
    Friend WithEvents txtDate As System.Windows.Forms.TextBox
End Class
