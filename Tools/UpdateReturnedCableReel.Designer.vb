<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UpdateReturnedCableReel
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
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtCurrentFootage = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtWarehouse = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtReelID = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboReelTransactionID = New System.Windows.Forms.ComboBox()
        Me.txtPartNumber = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtIssuedReel = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(14, 181)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(147, 19)
        Me.Label7.TabIndex = 498
        Me.Label7.Text = "Current Footage"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCurrentFootage
        '
        Me.txtCurrentFootage.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCurrentFootage.Location = New System.Drawing.Point(175, 181)
        Me.txtCurrentFootage.Margin = New System.Windows.Forms.Padding(2)
        Me.txtCurrentFootage.Name = "txtCurrentFootage"
        Me.txtCurrentFootage.Size = New System.Drawing.Size(145, 20)
        Me.txtCurrentFootage.TabIndex = 491
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(52, 157)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(109, 19)
        Me.Label8.TabIndex = 496
        Me.Label8.Text = "Warehouse"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtWarehouse
        '
        Me.txtWarehouse.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtWarehouse.Location = New System.Drawing.Point(175, 157)
        Me.txtWarehouse.Margin = New System.Windows.Forms.Padding(2)
        Me.txtWarehouse.Name = "txtWarehouse"
        Me.txtWarehouse.ReadOnly = True
        Me.txtWarehouse.Size = New System.Drawing.Size(145, 20)
        Me.txtWarehouse.TabIndex = 490
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(52, 133)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(109, 19)
        Me.Label5.TabIndex = 494
        Me.Label5.Text = "Reel ID"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtReelID
        '
        Me.txtReelID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtReelID.Location = New System.Drawing.Point(175, 133)
        Me.txtReelID.Margin = New System.Windows.Forms.Padding(2)
        Me.txtReelID.Name = "txtReelID"
        Me.txtReelID.Size = New System.Drawing.Size(145, 20)
        Me.txtReelID.TabIndex = 488
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(52, 109)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(109, 19)
        Me.Label3.TabIndex = 493
        Me.Label3.Text = "Part Number"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(11, 77)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(150, 19)
        Me.Label2.TabIndex = 492
        Me.Label2.Text = "Transaction ID"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboReelTransactionID
        '
        Me.cboReelTransactionID.FormattingEnabled = True
        Me.cboReelTransactionID.Location = New System.Drawing.Point(175, 77)
        Me.cboReelTransactionID.Margin = New System.Windows.Forms.Padding(2)
        Me.cboReelTransactionID.Name = "cboReelTransactionID"
        Me.cboReelTransactionID.Size = New System.Drawing.Size(145, 21)
        Me.cboReelTransactionID.TabIndex = 485
        '
        'txtPartNumber
        '
        Me.txtPartNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPartNumber.Location = New System.Drawing.Point(175, 109)
        Me.txtPartNumber.Margin = New System.Windows.Forms.Padding(2)
        Me.txtPartNumber.Name = "txtPartNumber"
        Me.txtPartNumber.ReadOnly = True
        Me.txtPartNumber.Size = New System.Drawing.Size(145, 20)
        Me.txtPartNumber.TabIndex = 487
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 9)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(311, 46)
        Me.Label1.TabIndex = 499
        Me.Label1.Text = "Return Cable Reel"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(14, 205)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(147, 19)
        Me.Label4.TabIndex = 501
        Me.Label4.Text = "Issued Reel"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtIssuedReel
        '
        Me.txtIssuedReel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIssuedReel.Location = New System.Drawing.Point(175, 205)
        Me.txtIssuedReel.Margin = New System.Windows.Forms.Padding(2)
        Me.txtIssuedReel.Name = "txtIssuedReel"
        Me.txtIssuedReel.Size = New System.Drawing.Size(145, 20)
        Me.txtIssuedReel.TabIndex = 500
        '
        'UpdateReturnedCableReel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(342, 264)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtIssuedReel)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtCurrentFootage)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtWarehouse)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtReelID)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboReelTransactionID)
        Me.Controls.Add(Me.txtPartNumber)
        Me.Name = "UpdateReturnedCableReel"
        Me.Text = "UpdateReturnedCableReel"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtCurrentFootage As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtWarehouse As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtReelID As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboReelTransactionID As System.Windows.Forms.ComboBox
    Friend WithEvents txtPartNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtIssuedReel As System.Windows.Forms.TextBox
End Class
