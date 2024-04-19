<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddInformationTechnologyAccessoryHistory
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
        Me.txtDeviceID = New System.Windows.Forms.TextBox()
        Me.txtNotes = New System.Windows.Forms.TextBox()
        Me.txtEmployeeID = New System.Windows.Forms.TextBox()
        Me.txtDate = New System.Windows.Forms.TextBox()
        Me.txtIssuingEmployeeID = New System.Windows.Forms.TextBox()
        Me.txtAccessoryID = New System.Windows.Forms.TextBox()
        Me.cboTransactionID = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'txtDeviceID
        '
        Me.txtDeviceID.Location = New System.Drawing.Point(100, 132)
        Me.txtDeviceID.Name = "txtDeviceID"
        Me.txtDeviceID.Size = New System.Drawing.Size(121, 20)
        Me.txtDeviceID.TabIndex = 599
        '
        'txtNotes
        '
        Me.txtNotes.Location = New System.Drawing.Point(100, 236)
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.Size = New System.Drawing.Size(121, 20)
        Me.txtNotes.TabIndex = 598
        '
        'txtEmployeeID
        '
        Me.txtEmployeeID.Location = New System.Drawing.Point(100, 210)
        Me.txtEmployeeID.Name = "txtEmployeeID"
        Me.txtEmployeeID.Size = New System.Drawing.Size(121, 20)
        Me.txtEmployeeID.TabIndex = 597
        '
        'txtDate
        '
        Me.txtDate.Location = New System.Drawing.Point(100, 184)
        Me.txtDate.Name = "txtDate"
        Me.txtDate.Size = New System.Drawing.Size(121, 20)
        Me.txtDate.TabIndex = 596
        '
        'txtIssuingEmployeeID
        '
        Me.txtIssuingEmployeeID.Location = New System.Drawing.Point(100, 158)
        Me.txtIssuingEmployeeID.Name = "txtIssuingEmployeeID"
        Me.txtIssuingEmployeeID.Size = New System.Drawing.Size(121, 20)
        Me.txtIssuingEmployeeID.TabIndex = 595
        '
        'txtAccessoryID
        '
        Me.txtAccessoryID.Location = New System.Drawing.Point(100, 106)
        Me.txtAccessoryID.Name = "txtAccessoryID"
        Me.txtAccessoryID.Size = New System.Drawing.Size(121, 20)
        Me.txtAccessoryID.TabIndex = 594
        '
        'cboTransactionID
        '
        Me.cboTransactionID.FormattingEnabled = True
        Me.cboTransactionID.Location = New System.Drawing.Point(100, 79)
        Me.cboTransactionID.Name = "cboTransactionID"
        Me.cboTransactionID.Size = New System.Drawing.Size(121, 21)
        Me.cboTransactionID.TabIndex = 593
        '
        'AddInformationTechnologyAccessoryHistory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(309, 320)
        Me.Controls.Add(Me.txtDeviceID)
        Me.Controls.Add(Me.txtNotes)
        Me.Controls.Add(Me.txtEmployeeID)
        Me.Controls.Add(Me.txtDate)
        Me.Controls.Add(Me.txtIssuingEmployeeID)
        Me.Controls.Add(Me.txtAccessoryID)
        Me.Controls.Add(Me.cboTransactionID)
        Me.Name = "AddInformationTechnologyAccessoryHistory"
        Me.Text = "AddInformationTechnologyAccessoryHistory"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtDeviceID As System.Windows.Forms.TextBox
    Friend WithEvents txtNotes As System.Windows.Forms.TextBox
    Friend WithEvents txtEmployeeID As System.Windows.Forms.TextBox
    Friend WithEvents txtDate As System.Windows.Forms.TextBox
    Friend WithEvents txtIssuingEmployeeID As System.Windows.Forms.TextBox
    Friend WithEvents txtAccessoryID As System.Windows.Forms.TextBox
    Friend WithEvents cboTransactionID As System.Windows.Forms.ComboBox
End Class
