<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VehicleSheetTurnInIDCreation
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboTableTransactionID = New System.Windows.Forms.ComboBox()
        Me.txtTransactionID = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtTableTransactionID = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(17, 33)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(141, 19)
        Me.Label2.TabIndex = 65
        Me.Label2.Text = "Table Transaction ID"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboTableTransactionID
        '
        Me.cboTableTransactionID.FormattingEnabled = True
        Me.cboTableTransactionID.Location = New System.Drawing.Point(173, 33)
        Me.cboTableTransactionID.Margin = New System.Windows.Forms.Padding(2)
        Me.cboTableTransactionID.Name = "cboTableTransactionID"
        Me.cboTableTransactionID.Size = New System.Drawing.Size(145, 21)
        Me.cboTableTransactionID.TabIndex = 63
        '
        'txtTransactionID
        '
        Me.txtTransactionID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTransactionID.Location = New System.Drawing.Point(173, 62)
        Me.txtTransactionID.Margin = New System.Windows.Forms.Padding(2)
        Me.txtTransactionID.Name = "txtTransactionID"
        Me.txtTransactionID.Size = New System.Drawing.Size(145, 20)
        Me.txtTransactionID.TabIndex = 64
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(49, 63)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(109, 19)
        Me.Label1.TabIndex = 66
        Me.Label1.Text = "Transaction ID"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(11, 87)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(147, 19)
        Me.Label3.TabIndex = 68
        Me.Label3.Text = "Table Transaction ID"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtTableTransactionID
        '
        Me.txtTableTransactionID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTableTransactionID.Location = New System.Drawing.Point(173, 86)
        Me.txtTableTransactionID.Margin = New System.Windows.Forms.Padding(2)
        Me.txtTableTransactionID.Name = "txtTableTransactionID"
        Me.txtTableTransactionID.Size = New System.Drawing.Size(145, 20)
        Me.txtTableTransactionID.TabIndex = 67
        '
        'VehicleSheetTurnInIDCreation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(332, 132)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtTableTransactionID)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboTableTransactionID)
        Me.Controls.Add(Me.txtTransactionID)
        Me.Name = "VehicleSheetTurnInIDCreation"
        Me.Text = "VehicleSheetTurnInIDCreation"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboTableTransactionID As System.Windows.Forms.ComboBox
    Friend WithEvents txtTransactionID As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtTableTransactionID As System.Windows.Forms.TextBox
End Class
