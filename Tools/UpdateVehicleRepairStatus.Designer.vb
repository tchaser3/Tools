<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UpdateVehicleRepairStatus
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
        Me.txtDownForRepairs = New System.Windows.Forms.TextBox()
        Me.cboVehicleID = New System.Windows.Forms.ComboBox()
        Me.txtNotes = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'txtDownForRepairs
        '
        Me.txtDownForRepairs.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDownForRepairs.Location = New System.Drawing.Point(35, 77)
        Me.txtDownForRepairs.Margin = New System.Windows.Forms.Padding(4)
        Me.txtDownForRepairs.Name = "txtDownForRepairs"
        Me.txtDownForRepairs.Size = New System.Drawing.Size(213, 26)
        Me.txtDownForRepairs.TabIndex = 28
        '
        'cboVehicleID
        '
        Me.cboVehicleID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboVehicleID.FormattingEnabled = True
        Me.cboVehicleID.Location = New System.Drawing.Point(35, 28)
        Me.cboVehicleID.Margin = New System.Windows.Forms.Padding(4)
        Me.cboVehicleID.Name = "cboVehicleID"
        Me.cboVehicleID.Size = New System.Drawing.Size(213, 28)
        Me.cboVehicleID.TabIndex = 29
        '
        'txtNotes
        '
        Me.txtNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNotes.Location = New System.Drawing.Point(35, 125)
        Me.txtNotes.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.Size = New System.Drawing.Size(213, 26)
        Me.txtNotes.TabIndex = 30
        '
        'UpdateVehicleRepairStatus
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(282, 183)
        Me.Controls.Add(Me.txtNotes)
        Me.Controls.Add(Me.txtDownForRepairs)
        Me.Controls.Add(Me.cboVehicleID)
        Me.Name = "UpdateVehicleRepairStatus"
        Me.Text = "UpdateVehicleRepairStatus"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtDownForRepairs As System.Windows.Forms.TextBox
    Friend WithEvents cboVehicleID As System.Windows.Forms.ComboBox
    Friend WithEvents txtNotes As System.Windows.Forms.TextBox
End Class
