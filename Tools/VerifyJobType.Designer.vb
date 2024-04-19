<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VerifyJobType
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
        Me.txtJobType = New System.Windows.Forms.TextBox()
        Me.cboJobTypeID = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'txtJobType
        '
        Me.txtJobType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtJobType.Location = New System.Drawing.Point(81, 54)
        Me.txtJobType.Margin = New System.Windows.Forms.Padding(2)
        Me.txtJobType.Name = "txtJobType"
        Me.txtJobType.Size = New System.Drawing.Size(145, 20)
        Me.txtJobType.TabIndex = 576
        '
        'cboJobTypeID
        '
        Me.cboJobTypeID.FormattingEnabled = True
        Me.cboJobTypeID.Location = New System.Drawing.Point(81, 25)
        Me.cboJobTypeID.Margin = New System.Windows.Forms.Padding(2)
        Me.cboJobTypeID.Name = "cboJobTypeID"
        Me.cboJobTypeID.Size = New System.Drawing.Size(145, 21)
        Me.cboJobTypeID.TabIndex = 575
        '
        'VerifyJobType
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 115)
        Me.Controls.Add(Me.txtJobType)
        Me.Controls.Add(Me.cboJobTypeID)
        Me.Name = "VerifyJobType"
        Me.Text = "VerifyJobType"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtJobType As System.Windows.Forms.TextBox
    Friend WithEvents cboJobTypeID As System.Windows.Forms.ComboBox
End Class
