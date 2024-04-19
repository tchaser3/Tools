<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectCableCategory
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
        Me.rdoCoax = New System.Windows.Forms.RadioButton()
        Me.rdoFiber = New System.Windows.Forms.RadioButton()
        Me.rdoDropCable = New System.Windows.Forms.RadioButton()
        Me.rdoTwistedPair = New System.Windows.Forms.RadioButton()
        Me.rdoSpecialtyCable = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'rdoCoax
        '
        Me.rdoCoax.AutoSize = True
        Me.rdoCoax.Location = New System.Drawing.Point(59, 53)
        Me.rdoCoax.Name = "rdoCoax"
        Me.rdoCoax.Size = New System.Drawing.Size(49, 17)
        Me.rdoCoax.TabIndex = 0
        Me.rdoCoax.TabStop = True
        Me.rdoCoax.Text = "Coax"
        Me.rdoCoax.UseVisualStyleBackColor = True
        '
        'rdoFiber
        '
        Me.rdoFiber.AutoSize = True
        Me.rdoFiber.Location = New System.Drawing.Point(59, 76)
        Me.rdoFiber.Name = "rdoFiber"
        Me.rdoFiber.Size = New System.Drawing.Size(48, 17)
        Me.rdoFiber.TabIndex = 1
        Me.rdoFiber.TabStop = True
        Me.rdoFiber.Text = "Fiber"
        Me.rdoFiber.UseVisualStyleBackColor = True
        '
        'rdoDropCable
        '
        Me.rdoDropCable.AutoSize = True
        Me.rdoDropCable.Location = New System.Drawing.Point(59, 99)
        Me.rdoDropCable.Name = "rdoDropCable"
        Me.rdoDropCable.Size = New System.Drawing.Size(78, 17)
        Me.rdoDropCable.TabIndex = 2
        Me.rdoDropCable.TabStop = True
        Me.rdoDropCable.Text = "Drop Cable"
        Me.rdoDropCable.UseVisualStyleBackColor = True
        '
        'rdoTwistedPair
        '
        Me.rdoTwistedPair.AutoSize = True
        Me.rdoTwistedPair.Location = New System.Drawing.Point(59, 122)
        Me.rdoTwistedPair.Name = "rdoTwistedPair"
        Me.rdoTwistedPair.Size = New System.Drawing.Size(83, 17)
        Me.rdoTwistedPair.TabIndex = 3
        Me.rdoTwistedPair.TabStop = True
        Me.rdoTwistedPair.Text = "Twisted Pair"
        Me.rdoTwistedPair.UseVisualStyleBackColor = True
        '
        'rdoSpecialtyCable
        '
        Me.rdoSpecialtyCable.AutoSize = True
        Me.rdoSpecialtyCable.Location = New System.Drawing.Point(59, 145)
        Me.rdoSpecialtyCable.Name = "rdoSpecialtyCable"
        Me.rdoSpecialtyCable.Size = New System.Drawing.Size(98, 17)
        Me.rdoSpecialtyCable.TabIndex = 4
        Me.rdoSpecialtyCable.TabStop = True
        Me.rdoSpecialtyCable.Text = "Specialty Cable"
        Me.rdoSpecialtyCable.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(11, 4)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(202, 46)
        Me.Label1.TabIndex = 401
        Me.Label1.Text = "Select Type"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(59, 168)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(98, 38)
        Me.btnOK.TabIndex = 402
        Me.btnOK.Text = "Ok"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'SelectCableCategory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(214, 218)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.rdoSpecialtyCable)
        Me.Controls.Add(Me.rdoTwistedPair)
        Me.Controls.Add(Me.rdoDropCable)
        Me.Controls.Add(Me.rdoFiber)
        Me.Controls.Add(Me.rdoCoax)
        Me.Name = "SelectCableCategory"
        Me.Text = "SelectCableCategory"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents rdoCoax As System.Windows.Forms.RadioButton
    Friend WithEvents rdoFiber As System.Windows.Forms.RadioButton
    Friend WithEvents rdoDropCable As System.Windows.Forms.RadioButton
    Friend WithEvents rdoTwistedPair As System.Windows.Forms.RadioButton
    Friend WithEvents rdoSpecialtyCable As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnOK As System.Windows.Forms.Button
End Class
