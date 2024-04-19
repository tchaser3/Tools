<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddInformationTechnologyHistory
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
        Me.cboTransactionID = New System.Windows.Forms.ComboBox()
        Me.txtIssuingEmployeeID = New System.Windows.Forms.TextBox()
        Me.txtDeviceID = New System.Windows.Forms.TextBox()
        Me.txtEmployeeID = New System.Windows.Forms.TextBox()
        Me.txtNotes = New System.Windows.Forms.TextBox()
        Me.txtDate = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'cboTransactionID
        '
        Me.cboTransactionID.FormattingEnabled = True
        Me.cboTransactionID.Location = New System.Drawing.Point(40, 31)
        Me.cboTransactionID.Name = "cboTransactionID"
        Me.cboTransactionID.Size = New System.Drawing.Size(145, 21)
        Me.cboTransactionID.TabIndex = 533
        '
        'txtIssuingEmployeeID
        '
        Me.txtIssuingEmployeeID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIssuingEmployeeID.Location = New System.Drawing.Point(40, 132)
        Me.txtIssuingEmployeeID.Margin = New System.Windows.Forms.Padding(2)
        Me.txtIssuingEmployeeID.Name = "txtIssuingEmployeeID"
        Me.txtIssuingEmployeeID.ReadOnly = True
        Me.txtIssuingEmployeeID.Size = New System.Drawing.Size(145, 20)
        Me.txtIssuingEmployeeID.TabIndex = 530
        '
        'txtDeviceID
        '
        Me.txtDeviceID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDeviceID.Location = New System.Drawing.Point(40, 60)
        Me.txtDeviceID.Margin = New System.Windows.Forms.Padding(2)
        Me.txtDeviceID.Name = "txtDeviceID"
        Me.txtDeviceID.ReadOnly = True
        Me.txtDeviceID.Size = New System.Drawing.Size(145, 20)
        Me.txtDeviceID.TabIndex = 527
        '
        'txtEmployeeID
        '
        Me.txtEmployeeID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEmployeeID.Location = New System.Drawing.Point(40, 108)
        Me.txtEmployeeID.Margin = New System.Windows.Forms.Padding(2)
        Me.txtEmployeeID.Name = "txtEmployeeID"
        Me.txtEmployeeID.ReadOnly = True
        Me.txtEmployeeID.Size = New System.Drawing.Size(145, 20)
        Me.txtEmployeeID.TabIndex = 529
        '
        'txtNotes
        '
        Me.txtNotes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNotes.Location = New System.Drawing.Point(40, 156)
        Me.txtNotes.Margin = New System.Windows.Forms.Padding(2)
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.ReadOnly = True
        Me.txtNotes.Size = New System.Drawing.Size(145, 20)
        Me.txtNotes.TabIndex = 531
        '
        'txtDate
        '
        Me.txtDate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDate.Location = New System.Drawing.Point(40, 84)
        Me.txtDate.Margin = New System.Windows.Forms.Padding(2)
        Me.txtDate.Name = "txtDate"
        Me.txtDate.ReadOnly = True
        Me.txtDate.Size = New System.Drawing.Size(145, 20)
        Me.txtDate.TabIndex = 528
        '
        'AddInformationTechnologyHistory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(213, 218)
        Me.Controls.Add(Me.cboTransactionID)
        Me.Controls.Add(Me.txtIssuingEmployeeID)
        Me.Controls.Add(Me.txtDeviceID)
        Me.Controls.Add(Me.txtEmployeeID)
        Me.Controls.Add(Me.txtNotes)
        Me.Controls.Add(Me.txtDate)
        Me.Name = "AddInformationTechnologyHistory"
        Me.Text = "AddInformationTechnologyHistory"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboTransactionID As System.Windows.Forms.ComboBox
    Friend WithEvents txtIssuingEmployeeID As System.Windows.Forms.TextBox
    Friend WithEvents txtDeviceID As System.Windows.Forms.TextBox
    Friend WithEvents txtEmployeeID As System.Windows.Forms.TextBox
    Friend WithEvents txtNotes As System.Windows.Forms.TextBox
    Friend WithEvents txtDate As System.Windows.Forms.TextBox
End Class
