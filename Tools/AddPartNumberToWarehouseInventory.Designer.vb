<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddPartNumberToWarehouseInventory
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
        Me.txtWarehouseID = New System.Windows.Forms.TextBox()
        Me.txtQTYOnHand = New System.Windows.Forms.TextBox()
        Me.txtPartDescription = New System.Windows.Forms.TextBox()
        Me.txtPartNumber = New System.Windows.Forms.TextBox()
        Me.cboPartID = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'txtWarehouseID
        '
        Me.txtWarehouseID.Location = New System.Drawing.Point(13, 230)
        Me.txtWarehouseID.Margin = New System.Windows.Forms.Padding(4)
        Me.txtWarehouseID.Name = "txtWarehouseID"
        Me.txtWarehouseID.ReadOnly = True
        Me.txtWarehouseID.Size = New System.Drawing.Size(160, 22)
        Me.txtWarehouseID.TabIndex = 30
        '
        'txtQTYOnHand
        '
        Me.txtQTYOnHand.Location = New System.Drawing.Point(13, 187)
        Me.txtQTYOnHand.Margin = New System.Windows.Forms.Padding(4)
        Me.txtQTYOnHand.Name = "txtQTYOnHand"
        Me.txtQTYOnHand.ReadOnly = True
        Me.txtQTYOnHand.Size = New System.Drawing.Size(160, 22)
        Me.txtQTYOnHand.TabIndex = 29
        '
        'txtPartDescription
        '
        Me.txtPartDescription.Location = New System.Drawing.Point(13, 79)
        Me.txtPartDescription.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPartDescription.Multiline = True
        Me.txtPartDescription.Name = "txtPartDescription"
        Me.txtPartDescription.ReadOnly = True
        Me.txtPartDescription.Size = New System.Drawing.Size(160, 100)
        Me.txtPartDescription.TabIndex = 28
        '
        'txtPartNumber
        '
        Me.txtPartNumber.Location = New System.Drawing.Point(13, 47)
        Me.txtPartNumber.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPartNumber.Name = "txtPartNumber"
        Me.txtPartNumber.ReadOnly = True
        Me.txtPartNumber.Size = New System.Drawing.Size(160, 22)
        Me.txtPartNumber.TabIndex = 27
        '
        'cboPartID
        '
        Me.cboPartID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPartID.FormattingEnabled = True
        Me.cboPartID.Location = New System.Drawing.Point(13, 12)
        Me.cboPartID.Margin = New System.Windows.Forms.Padding(4)
        Me.cboPartID.Name = "cboPartID"
        Me.cboPartID.Size = New System.Drawing.Size(160, 24)
        Me.cboPartID.TabIndex = 26
        '
        'AddPartNumberToWarehouseInventory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(194, 280)
        Me.Controls.Add(Me.txtWarehouseID)
        Me.Controls.Add(Me.txtQTYOnHand)
        Me.Controls.Add(Me.txtPartDescription)
        Me.Controls.Add(Me.txtPartNumber)
        Me.Controls.Add(Me.cboPartID)
        Me.Name = "AddPartNumberToWarehouseInventory"
        Me.Text = "AddPartNumberToWarehouseInventory"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtWarehouseID As System.Windows.Forms.TextBox
    Friend WithEvents txtQTYOnHand As System.Windows.Forms.TextBox
    Friend WithEvents txtPartDescription As System.Windows.Forms.TextBox
    Friend WithEvents txtPartNumber As System.Windows.Forms.TextBox
    Friend WithEvents cboPartID As System.Windows.Forms.ComboBox
End Class
