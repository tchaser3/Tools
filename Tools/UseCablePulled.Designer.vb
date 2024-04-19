<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UseCablePulled
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
        Me.btnYes = New System.Windows.Forms.Button()
        Me.btnNo = New System.Windows.Forms.Button()
        Me.lblUserMessage = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnYes
        '
        Me.btnYes.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnYes.Location = New System.Drawing.Point(11, 137)
        Me.btnYes.Margin = New System.Windows.Forms.Padding(2)
        Me.btnYes.Name = "btnYes"
        Me.btnYes.Size = New System.Drawing.Size(167, 51)
        Me.btnYes.TabIndex = 22
        Me.btnYes.Text = "Yes"
        Me.btnYes.UseVisualStyleBackColor = True
        '
        'btnNo
        '
        Me.btnNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNo.Location = New System.Drawing.Point(216, 137)
        Me.btnNo.Margin = New System.Windows.Forms.Padding(2)
        Me.btnNo.Name = "btnNo"
        Me.btnNo.Size = New System.Drawing.Size(167, 51)
        Me.btnNo.TabIndex = 23
        Me.btnNo.Text = "No"
        Me.btnNo.UseVisualStyleBackColor = True
        '
        'lblUserMessage
        '
        Me.lblUserMessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUserMessage.Location = New System.Drawing.Point(11, 9)
        Me.lblUserMessage.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblUserMessage.Name = "lblUserMessage"
        Me.lblUserMessage.Size = New System.Drawing.Size(372, 113)
        Me.lblUserMessage.TabIndex = 403
        Me.lblUserMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'UseCablePulled
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(394, 208)
        Me.Controls.Add(Me.lblUserMessage)
        Me.Controls.Add(Me.btnYes)
        Me.Controls.Add(Me.btnNo)
        Me.Name = "UseCablePulled"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "UseCablePulled"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnYes As System.Windows.Forms.Button
    Friend WithEvents btnNo As System.Windows.Forms.Button
    Friend WithEvents lblUserMessage As System.Windows.Forms.Label
End Class
