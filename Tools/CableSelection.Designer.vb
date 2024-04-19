<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CableSelection
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
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtCablePartType = New System.Windows.Forms.TextBox()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cboPartID = New System.Windows.Forms.ComboBox()
        Me.txtCableJobType = New System.Windows.Forms.TextBox()
        Me.txtCablePartNumber = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.rdoSpecialtyCable = New System.Windows.Forms.RadioButton()
        Me.rdoTwistedPair = New System.Windows.Forms.RadioButton()
        Me.rdoDropCable = New System.Windows.Forms.RadioButton()
        Me.rdoFiber = New System.Windows.Forms.RadioButton()
        Me.rdoCoax = New System.Windows.Forms.RadioButton()
        Me.btnSelectPartNumber = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnEmployeeNext = New System.Windows.Forms.Button()
        Me.btnEmployeeBack = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboEmployeeID = New System.Windows.Forms.ComboBox()
        Me.txtFirstName = New System.Windows.Forms.TextBox()
        Me.txtLastName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnSelectWarehouse = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCableDescription = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(234, 86)
        Me.Label14.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(270, 31)
        Me.Label14.TabIndex = 470
        Me.Label14.Text = "Select Cable Part Number"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(236, 213)
        Me.Label15.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(109, 29)
        Me.Label15.TabIndex = 469
        Me.Label15.Text = "Part Type"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCablePartType
        '
        Me.txtCablePartType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCablePartType.Location = New System.Drawing.Point(359, 223)
        Me.txtCablePartType.Margin = New System.Windows.Forms.Padding(2)
        Me.txtCablePartType.Name = "txtCablePartType"
        Me.txtCablePartType.ReadOnly = True
        Me.txtCablePartType.Size = New System.Drawing.Size(145, 20)
        Me.txtCablePartType.TabIndex = 468
        '
        'btnNext
        '
        Me.btnNext.Enabled = False
        Me.btnNext.Location = New System.Drawing.Point(429, 259)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(75, 23)
        Me.btnNext.TabIndex = 460
        Me.btnNext.Text = "Next"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnBack
        '
        Me.btnBack.Enabled = False
        Me.btnBack.Location = New System.Drawing.Point(318, 259)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(75, 23)
        Me.btnBack.TabIndex = 459
        Me.btnBack.Text = "Back"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(236, 189)
        Me.Label16.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(109, 29)
        Me.Label16.TabIndex = 467
        Me.Label16.Text = "Job Type"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(236, 142)
        Me.Label17.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(109, 29)
        Me.Label17.TabIndex = 466
        Me.Label17.Text = "Part Number"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboPartID
        '
        Me.cboPartID.FormattingEnabled = True
        Me.cboPartID.Location = New System.Drawing.Point(359, 123)
        Me.cboPartID.Margin = New System.Windows.Forms.Padding(2)
        Me.cboPartID.Name = "cboPartID"
        Me.cboPartID.Size = New System.Drawing.Size(145, 21)
        Me.cboPartID.TabIndex = 463
        Me.cboPartID.Visible = False
        '
        'txtCableJobType
        '
        Me.txtCableJobType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCableJobType.Location = New System.Drawing.Point(359, 199)
        Me.txtCableJobType.Margin = New System.Windows.Forms.Padding(2)
        Me.txtCableJobType.Name = "txtCableJobType"
        Me.txtCableJobType.ReadOnly = True
        Me.txtCableJobType.Size = New System.Drawing.Size(145, 20)
        Me.txtCableJobType.TabIndex = 465
        '
        'txtCablePartNumber
        '
        Me.txtCablePartNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCablePartNumber.Location = New System.Drawing.Point(359, 152)
        Me.txtCablePartNumber.Margin = New System.Windows.Forms.Padding(2)
        Me.txtCablePartNumber.Name = "txtCablePartNumber"
        Me.txtCablePartNumber.ReadOnly = True
        Me.txtCablePartNumber.Size = New System.Drawing.Size(145, 20)
        Me.txtCablePartNumber.TabIndex = 464
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(11, 78)
        Me.Label13.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(219, 46)
        Me.Label13.TabIndex = 462
        Me.Label13.Text = "Select Cable Type"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'rdoSpecialtyCable
        '
        Me.rdoSpecialtyCable.AutoSize = True
        Me.rdoSpecialtyCable.Location = New System.Drawing.Point(76, 219)
        Me.rdoSpecialtyCable.Name = "rdoSpecialtyCable"
        Me.rdoSpecialtyCable.Size = New System.Drawing.Size(98, 17)
        Me.rdoSpecialtyCable.TabIndex = 458
        Me.rdoSpecialtyCable.TabStop = True
        Me.rdoSpecialtyCable.Text = "Specialty Cable"
        Me.rdoSpecialtyCable.UseVisualStyleBackColor = True
        '
        'rdoTwistedPair
        '
        Me.rdoTwistedPair.AutoSize = True
        Me.rdoTwistedPair.Location = New System.Drawing.Point(76, 196)
        Me.rdoTwistedPair.Name = "rdoTwistedPair"
        Me.rdoTwistedPair.Size = New System.Drawing.Size(83, 17)
        Me.rdoTwistedPair.TabIndex = 457
        Me.rdoTwistedPair.TabStop = True
        Me.rdoTwistedPair.Text = "Twisted Pair"
        Me.rdoTwistedPair.UseVisualStyleBackColor = True
        '
        'rdoDropCable
        '
        Me.rdoDropCable.AutoSize = True
        Me.rdoDropCable.Location = New System.Drawing.Point(76, 173)
        Me.rdoDropCable.Name = "rdoDropCable"
        Me.rdoDropCable.Size = New System.Drawing.Size(78, 17)
        Me.rdoDropCable.TabIndex = 456
        Me.rdoDropCable.TabStop = True
        Me.rdoDropCable.Text = "Drop Cable"
        Me.rdoDropCable.UseVisualStyleBackColor = True
        '
        'rdoFiber
        '
        Me.rdoFiber.AutoSize = True
        Me.rdoFiber.Location = New System.Drawing.Point(76, 150)
        Me.rdoFiber.Name = "rdoFiber"
        Me.rdoFiber.Size = New System.Drawing.Size(48, 17)
        Me.rdoFiber.TabIndex = 455
        Me.rdoFiber.TabStop = True
        Me.rdoFiber.Text = "Fiber"
        Me.rdoFiber.UseVisualStyleBackColor = True
        '
        'rdoCoax
        '
        Me.rdoCoax.AutoSize = True
        Me.rdoCoax.Location = New System.Drawing.Point(76, 127)
        Me.rdoCoax.Name = "rdoCoax"
        Me.rdoCoax.Size = New System.Drawing.Size(49, 17)
        Me.rdoCoax.TabIndex = 454
        Me.rdoCoax.TabStop = True
        Me.rdoCoax.Text = "Coax"
        Me.rdoCoax.UseVisualStyleBackColor = True
        '
        'btnSelectPartNumber
        '
        Me.btnSelectPartNumber.Enabled = False
        Me.btnSelectPartNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSelectPartNumber.Location = New System.Drawing.Point(359, 288)
        Me.btnSelectPartNumber.Margin = New System.Windows.Forms.Padding(2)
        Me.btnSelectPartNumber.Name = "btnSelectPartNumber"
        Me.btnSelectPartNumber.Size = New System.Drawing.Size(112, 31)
        Me.btnSelectPartNumber.TabIndex = 461
        Me.btnSelectPartNumber.Text = "Select Cable"
        Me.btnSelectPartNumber.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(11, 9)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(776, 46)
        Me.Label1.TabIndex = 471
        Me.Label1.Text = "Select Cable and Warehouse"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnEmployeeNext
        '
        Me.btnEmployeeNext.Enabled = False
        Me.btnEmployeeNext.Location = New System.Drawing.Point(704, 204)
        Me.btnEmployeeNext.Name = "btnEmployeeNext"
        Me.btnEmployeeNext.Size = New System.Drawing.Size(75, 23)
        Me.btnEmployeeNext.TabIndex = 482
        Me.btnEmployeeNext.Text = "Next"
        Me.btnEmployeeNext.UseVisualStyleBackColor = True
        '
        'btnEmployeeBack
        '
        Me.btnEmployeeBack.Enabled = False
        Me.btnEmployeeBack.Location = New System.Drawing.Point(593, 204)
        Me.btnEmployeeBack.Name = "btnEmployeeBack"
        Me.btnEmployeeBack.Size = New System.Drawing.Size(75, 23)
        Me.btnEmployeeBack.TabIndex = 481
        Me.btnEmployeeBack.Text = "Back"
        Me.btnEmployeeBack.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(519, 175)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(109, 19)
        Me.Label7.TabIndex = 480
        Me.Label7.Text = "First Name"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(519, 152)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(109, 19)
        Me.Label4.TabIndex = 479
        Me.Label4.Text = "Last Name"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboEmployeeID
        '
        Me.cboEmployeeID.FormattingEnabled = True
        Me.cboEmployeeID.Location = New System.Drawing.Point(642, 123)
        Me.cboEmployeeID.Margin = New System.Windows.Forms.Padding(2)
        Me.cboEmployeeID.Name = "cboEmployeeID"
        Me.cboEmployeeID.Size = New System.Drawing.Size(145, 21)
        Me.cboEmployeeID.TabIndex = 476
        '
        'txtFirstName
        '
        Me.txtFirstName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFirstName.Location = New System.Drawing.Point(642, 175)
        Me.txtFirstName.Margin = New System.Windows.Forms.Padding(2)
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.ReadOnly = True
        Me.txtFirstName.Size = New System.Drawing.Size(145, 20)
        Me.txtFirstName.TabIndex = 478
        '
        'txtLastName
        '
        Me.txtLastName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLastName.Location = New System.Drawing.Point(642, 152)
        Me.txtLastName.Margin = New System.Windows.Forms.Padding(2)
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.ReadOnly = True
        Me.txtLastName.Size = New System.Drawing.Size(145, 20)
        Me.txtLastName.TabIndex = 477
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(517, 86)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(270, 31)
        Me.Label2.TabIndex = 483
        Me.Label2.Text = "Select Warehouse"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnSelectWarehouse
        '
        Me.btnSelectWarehouse.Enabled = False
        Me.btnSelectWarehouse.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSelectWarehouse.Location = New System.Drawing.Point(616, 233)
        Me.btnSelectWarehouse.Margin = New System.Windows.Forms.Padding(2)
        Me.btnSelectWarehouse.Name = "btnSelectWarehouse"
        Me.btnSelectWarehouse.Size = New System.Drawing.Size(135, 31)
        Me.btnSelectWarehouse.TabIndex = 484
        Me.btnSelectWarehouse.Text = "Select Warehouse"
        Me.btnSelectWarehouse.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(236, 166)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(109, 29)
        Me.Label3.TabIndex = 486
        Me.Label3.Text = "Description"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCableDescription
        '
        Me.txtCableDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCableDescription.Location = New System.Drawing.Point(359, 176)
        Me.txtCableDescription.Margin = New System.Windows.Forms.Padding(2)
        Me.txtCableDescription.Name = "txtCableDescription"
        Me.txtCableDescription.ReadOnly = True
        Me.txtCableDescription.Size = New System.Drawing.Size(145, 20)
        Me.txtCableDescription.TabIndex = 485
        '
        'CableSelection
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(815, 354)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtCableDescription)
        Me.Controls.Add(Me.btnSelectWarehouse)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnEmployeeNext)
        Me.Controls.Add(Me.btnEmployeeBack)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cboEmployeeID)
        Me.Controls.Add(Me.txtFirstName)
        Me.Controls.Add(Me.txtLastName)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtCablePartType)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.cboPartID)
        Me.Controls.Add(Me.txtCableJobType)
        Me.Controls.Add(Me.txtCablePartNumber)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.rdoSpecialtyCable)
        Me.Controls.Add(Me.rdoTwistedPair)
        Me.Controls.Add(Me.rdoDropCable)
        Me.Controls.Add(Me.rdoFiber)
        Me.Controls.Add(Me.rdoCoax)
        Me.Controls.Add(Me.btnSelectPartNumber)
        Me.Name = "CableSelection"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cable Selection Form"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtCablePartType As System.Windows.Forms.TextBox
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents btnBack As System.Windows.Forms.Button
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cboPartID As System.Windows.Forms.ComboBox
    Friend WithEvents txtCableJobType As System.Windows.Forms.TextBox
    Friend WithEvents txtCablePartNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents rdoSpecialtyCable As System.Windows.Forms.RadioButton
    Friend WithEvents rdoTwistedPair As System.Windows.Forms.RadioButton
    Friend WithEvents rdoDropCable As System.Windows.Forms.RadioButton
    Friend WithEvents rdoFiber As System.Windows.Forms.RadioButton
    Friend WithEvents rdoCoax As System.Windows.Forms.RadioButton
    Friend WithEvents btnSelectPartNumber As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnEmployeeNext As System.Windows.Forms.Button
    Friend WithEvents btnEmployeeBack As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboEmployeeID As System.Windows.Forms.ComboBox
    Friend WithEvents txtFirstName As System.Windows.Forms.TextBox
    Friend WithEvents txtLastName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnSelectWarehouse As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCableDescription As System.Windows.Forms.TextBox
End Class
