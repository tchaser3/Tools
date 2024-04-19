<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CableAvailabilityReport
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
        Me.btnCableMenu = New System.Windows.Forms.Button()
        Me.btnInventoryMenu = New System.Windows.Forms.Button()
        Me.btnMainMenu = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnRunReport = New System.Windows.Forms.Button()
        Me.txtInternalProjectID = New System.Windows.Forms.TextBox()
        Me.txtWarehouse = New System.Windows.Forms.TextBox()
        Me.txtDate = New System.Windows.Forms.TextBox()
        Me.txtReelID = New System.Windows.Forms.TextBox()
        Me.cboTransactionID = New System.Windows.Forms.ComboBox()
        Me.txtFootagePulled = New System.Windows.Forms.TextBox()
        Me.txtPartNumber = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtCablePartType = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtCableJobType = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cboPartID = New System.Windows.Forms.ComboBox()
        Me.txtCableDescription = New System.Windows.Forms.TextBox()
        Me.txtCablePartNumber = New System.Windows.Forms.TextBox()
        Me.gboSelectCableType = New System.Windows.Forms.GroupBox()
        Me.rdoSpecialtyCable = New System.Windows.Forms.RadioButton()
        Me.rdoTwistedPair = New System.Windows.Forms.RadioButton()
        Me.rdoDropCable = New System.Windows.Forms.RadioButton()
        Me.rdoFiber = New System.Windows.Forms.RadioButton()
        Me.rdoCoax = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.PrintCableReportDocument = New System.Drawing.Printing.PrintDocument()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.gboSelectCableType.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCableMenu
        '
        Me.btnCableMenu.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCableMenu.Location = New System.Drawing.Point(615, 204)
        Me.btnCableMenu.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCableMenu.Name = "btnCableMenu"
        Me.btnCableMenu.Size = New System.Drawing.Size(167, 51)
        Me.btnCableMenu.TabIndex = 7
        Me.btnCableMenu.Text = "Cable Menu"
        Me.btnCableMenu.UseVisualStyleBackColor = True
        '
        'btnInventoryMenu
        '
        Me.btnInventoryMenu.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnInventoryMenu.Location = New System.Drawing.Point(615, 149)
        Me.btnInventoryMenu.Margin = New System.Windows.Forms.Padding(2)
        Me.btnInventoryMenu.Name = "btnInventoryMenu"
        Me.btnInventoryMenu.Size = New System.Drawing.Size(167, 51)
        Me.btnInventoryMenu.TabIndex = 6
        Me.btnInventoryMenu.Text = "Inventory Menu"
        Me.btnInventoryMenu.UseVisualStyleBackColor = True
        '
        'btnMainMenu
        '
        Me.btnMainMenu.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMainMenu.Location = New System.Drawing.Point(615, 259)
        Me.btnMainMenu.Margin = New System.Windows.Forms.Padding(2)
        Me.btnMainMenu.Name = "btnMainMenu"
        Me.btnMainMenu.Size = New System.Drawing.Size(167, 51)
        Me.btnMainMenu.TabIndex = 8
        Me.btnMainMenu.Text = "Main Menu"
        Me.btnMainMenu.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Location = New System.Drawing.Point(615, 314)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(2)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(167, 51)
        Me.btnClose.TabIndex = 9
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnRunReport
        '
        Me.btnRunReport.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRunReport.Location = New System.Drawing.Point(615, 87)
        Me.btnRunReport.Margin = New System.Windows.Forms.Padding(2)
        Me.btnRunReport.Name = "btnRunReport"
        Me.btnRunReport.Size = New System.Drawing.Size(167, 58)
        Me.btnRunReport.TabIndex = 10
        Me.btnRunReport.Text = "Run Report"
        Me.btnRunReport.UseVisualStyleBackColor = True
        '
        'txtInternalProjectID
        '
        Me.txtInternalProjectID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtInternalProjectID.Location = New System.Drawing.Point(454, 153)
        Me.txtInternalProjectID.Margin = New System.Windows.Forms.Padding(2)
        Me.txtInternalProjectID.Name = "txtInternalProjectID"
        Me.txtInternalProjectID.ReadOnly = True
        Me.txtInternalProjectID.Size = New System.Drawing.Size(145, 20)
        Me.txtInternalProjectID.TabIndex = 496
        '
        'txtWarehouse
        '
        Me.txtWarehouse.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtWarehouse.Location = New System.Drawing.Point(454, 277)
        Me.txtWarehouse.Margin = New System.Windows.Forms.Padding(2)
        Me.txtWarehouse.Name = "txtWarehouse"
        Me.txtWarehouse.ReadOnly = True
        Me.txtWarehouse.Size = New System.Drawing.Size(145, 20)
        Me.txtWarehouse.TabIndex = 501
        '
        'txtDate
        '
        Me.txtDate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDate.Location = New System.Drawing.Point(454, 253)
        Me.txtDate.Margin = New System.Windows.Forms.Padding(2)
        Me.txtDate.Name = "txtDate"
        Me.txtDate.ReadOnly = True
        Me.txtDate.Size = New System.Drawing.Size(145, 20)
        Me.txtDate.TabIndex = 500
        '
        'txtReelID
        '
        Me.txtReelID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtReelID.Location = New System.Drawing.Point(454, 227)
        Me.txtReelID.Margin = New System.Windows.Forms.Padding(2)
        Me.txtReelID.Name = "txtReelID"
        Me.txtReelID.ReadOnly = True
        Me.txtReelID.Size = New System.Drawing.Size(145, 20)
        Me.txtReelID.TabIndex = 499
        '
        'cboTransactionID
        '
        Me.cboTransactionID.FormattingEnabled = True
        Me.cboTransactionID.Location = New System.Drawing.Point(454, 124)
        Me.cboTransactionID.Margin = New System.Windows.Forms.Padding(2)
        Me.cboTransactionID.Name = "cboTransactionID"
        Me.cboTransactionID.Size = New System.Drawing.Size(145, 21)
        Me.cboTransactionID.TabIndex = 502
        Me.cboTransactionID.Visible = False
        '
        'txtFootagePulled
        '
        Me.txtFootagePulled.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFootagePulled.Location = New System.Drawing.Point(454, 180)
        Me.txtFootagePulled.Margin = New System.Windows.Forms.Padding(2)
        Me.txtFootagePulled.Name = "txtFootagePulled"
        Me.txtFootagePulled.ReadOnly = True
        Me.txtFootagePulled.Size = New System.Drawing.Size(145, 20)
        Me.txtFootagePulled.TabIndex = 497
        '
        'txtPartNumber
        '
        Me.txtPartNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPartNumber.Location = New System.Drawing.Point(454, 203)
        Me.txtPartNumber.Margin = New System.Windows.Forms.Padding(2)
        Me.txtPartNumber.Name = "txtPartNumber"
        Me.txtPartNumber.ReadOnly = True
        Me.txtPartNumber.Size = New System.Drawing.Size(145, 20)
        Me.txtPartNumber.TabIndex = 498
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(14, 371)
        Me.Label10.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(109, 29)
        Me.Label10.TabIndex = 517
        Me.Label10.Text = "Part Type"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCablePartType
        '
        Me.txtCablePartType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCablePartType.Location = New System.Drawing.Point(137, 381)
        Me.txtCablePartType.Margin = New System.Windows.Forms.Padding(2)
        Me.txtCablePartType.Name = "txtCablePartType"
        Me.txtCablePartType.ReadOnly = True
        Me.txtCablePartType.Size = New System.Drawing.Size(145, 20)
        Me.txtCablePartType.TabIndex = 516
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(14, 347)
        Me.Label15.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(109, 29)
        Me.Label15.TabIndex = 515
        Me.Label15.Text = "Job Type"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCableJobType
        '
        Me.txtCableJobType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCableJobType.Location = New System.Drawing.Point(137, 357)
        Me.txtCableJobType.Margin = New System.Windows.Forms.Padding(2)
        Me.txtCableJobType.Name = "txtCableJobType"
        Me.txtCableJobType.ReadOnly = True
        Me.txtCableJobType.Size = New System.Drawing.Size(145, 20)
        Me.txtCableJobType.TabIndex = 514
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(14, 323)
        Me.Label16.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(109, 29)
        Me.Label16.TabIndex = 513
        Me.Label16.Text = "Description"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(14, 300)
        Me.Label17.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(109, 29)
        Me.Label17.TabIndex = 512
        Me.Label17.Text = "Part Number"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboPartID
        '
        Me.cboPartID.FormattingEnabled = True
        Me.cboPartID.Location = New System.Drawing.Point(137, 281)
        Me.cboPartID.Margin = New System.Windows.Forms.Padding(2)
        Me.cboPartID.Name = "cboPartID"
        Me.cboPartID.Size = New System.Drawing.Size(145, 21)
        Me.cboPartID.TabIndex = 509
        Me.cboPartID.Visible = False
        '
        'txtCableDescription
        '
        Me.txtCableDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCableDescription.Location = New System.Drawing.Point(137, 333)
        Me.txtCableDescription.Margin = New System.Windows.Forms.Padding(2)
        Me.txtCableDescription.Name = "txtCableDescription"
        Me.txtCableDescription.ReadOnly = True
        Me.txtCableDescription.Size = New System.Drawing.Size(145, 20)
        Me.txtCableDescription.TabIndex = 511
        '
        'txtCablePartNumber
        '
        Me.txtCablePartNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCablePartNumber.Location = New System.Drawing.Point(137, 310)
        Me.txtCablePartNumber.Margin = New System.Windows.Forms.Padding(2)
        Me.txtCablePartNumber.Name = "txtCablePartNumber"
        Me.txtCablePartNumber.ReadOnly = True
        Me.txtCablePartNumber.Size = New System.Drawing.Size(145, 20)
        Me.txtCablePartNumber.TabIndex = 510
        '
        'gboSelectCableType
        '
        Me.gboSelectCableType.Controls.Add(Me.rdoSpecialtyCable)
        Me.gboSelectCableType.Controls.Add(Me.rdoTwistedPair)
        Me.gboSelectCableType.Controls.Add(Me.rdoDropCable)
        Me.gboSelectCableType.Controls.Add(Me.rdoFiber)
        Me.gboSelectCableType.Controls.Add(Me.rdoCoax)
        Me.gboSelectCableType.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gboSelectCableType.Location = New System.Drawing.Point(17, 93)
        Me.gboSelectCableType.Name = "gboSelectCableType"
        Me.gboSelectCableType.Size = New System.Drawing.Size(265, 179)
        Me.gboSelectCableType.TabIndex = 518
        Me.gboSelectCableType.TabStop = False
        Me.gboSelectCableType.Text = "Select Cable Type"
        '
        'rdoSpecialtyCable
        '
        Me.rdoSpecialtyCable.AutoSize = True
        Me.rdoSpecialtyCable.Location = New System.Drawing.Point(62, 131)
        Me.rdoSpecialtyCable.Name = "rdoSpecialtyCable"
        Me.rdoSpecialtyCable.Size = New System.Drawing.Size(136, 24)
        Me.rdoSpecialtyCable.TabIndex = 446
        Me.rdoSpecialtyCable.TabStop = True
        Me.rdoSpecialtyCable.Text = "Specialty Cable"
        Me.rdoSpecialtyCable.UseVisualStyleBackColor = True
        '
        'rdoTwistedPair
        '
        Me.rdoTwistedPair.AutoSize = True
        Me.rdoTwistedPair.Location = New System.Drawing.Point(62, 108)
        Me.rdoTwistedPair.Name = "rdoTwistedPair"
        Me.rdoTwistedPair.Size = New System.Drawing.Size(112, 24)
        Me.rdoTwistedPair.TabIndex = 445
        Me.rdoTwistedPair.TabStop = True
        Me.rdoTwistedPair.Text = "Twisted Pair"
        Me.rdoTwistedPair.UseVisualStyleBackColor = True
        '
        'rdoDropCable
        '
        Me.rdoDropCable.AutoSize = True
        Me.rdoDropCable.Location = New System.Drawing.Point(62, 85)
        Me.rdoDropCable.Name = "rdoDropCable"
        Me.rdoDropCable.Size = New System.Drawing.Size(107, 24)
        Me.rdoDropCable.TabIndex = 444
        Me.rdoDropCable.TabStop = True
        Me.rdoDropCable.Text = "Drop Cable"
        Me.rdoDropCable.UseVisualStyleBackColor = True
        '
        'rdoFiber
        '
        Me.rdoFiber.AutoSize = True
        Me.rdoFiber.Location = New System.Drawing.Point(62, 62)
        Me.rdoFiber.Name = "rdoFiber"
        Me.rdoFiber.Size = New System.Drawing.Size(63, 24)
        Me.rdoFiber.TabIndex = 443
        Me.rdoFiber.TabStop = True
        Me.rdoFiber.Text = "Fiber"
        Me.rdoFiber.UseVisualStyleBackColor = True
        '
        'rdoCoax
        '
        Me.rdoCoax.AutoSize = True
        Me.rdoCoax.Location = New System.Drawing.Point(62, 39)
        Me.rdoCoax.Name = "rdoCoax"
        Me.rdoCoax.Size = New System.Drawing.Size(63, 24)
        Me.rdoCoax.TabIndex = 442
        Me.rdoCoax.TabStop = True
        Me.rdoCoax.Text = "Coax"
        Me.rdoCoax.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 9)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(779, 46)
        Me.Label1.TabIndex = 519
        Me.Label1.Text = "Run Cable Availability Report"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(331, 203)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(109, 19)
        Me.Label3.TabIndex = 503
        Me.Label3.Text = "Part Number"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(293, 180)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(147, 19)
        Me.Label7.TabIndex = 504
        Me.Label7.Text = "Footage Pulled"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(331, 227)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(109, 19)
        Me.Label5.TabIndex = 505
        Me.Label5.Text = "Reel ID"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(331, 253)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(109, 19)
        Me.Label4.TabIndex = 506
        Me.Label4.Text = "Date"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(331, 277)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(109, 19)
        Me.Label8.TabIndex = 507
        Me.Label8.Text = "Warehouse"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(296, 154)
        Me.Label9.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(140, 19)
        Me.Label9.TabIndex = 508
        Me.Label9.Text = "Internal Project ID"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'CableAvailabilityReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(794, 424)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.gboSelectCableType)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtCablePartType)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtCableJobType)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.cboPartID)
        Me.Controls.Add(Me.txtCableDescription)
        Me.Controls.Add(Me.txtCablePartNumber)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtInternalProjectID)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtWarehouse)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtDate)
        Me.Controls.Add(Me.txtReelID)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboTransactionID)
        Me.Controls.Add(Me.txtFootagePulled)
        Me.Controls.Add(Me.txtPartNumber)
        Me.Controls.Add(Me.btnRunReport)
        Me.Controls.Add(Me.btnCableMenu)
        Me.Controls.Add(Me.btnInventoryMenu)
        Me.Controls.Add(Me.btnMainMenu)
        Me.Controls.Add(Me.btnClose)
        Me.Name = "CableAvailabilityReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CableAvailabilityReport"
        Me.gboSelectCableType.ResumeLayout(False)
        Me.gboSelectCableType.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCableMenu As System.Windows.Forms.Button
    Friend WithEvents btnInventoryMenu As System.Windows.Forms.Button
    Friend WithEvents btnMainMenu As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnRunReport As System.Windows.Forms.Button
    Friend WithEvents txtInternalProjectID As System.Windows.Forms.TextBox
    Friend WithEvents txtWarehouse As System.Windows.Forms.TextBox
    Friend WithEvents txtDate As System.Windows.Forms.TextBox
    Friend WithEvents txtReelID As System.Windows.Forms.TextBox
    Friend WithEvents cboTransactionID As System.Windows.Forms.ComboBox
    Friend WithEvents txtFootagePulled As System.Windows.Forms.TextBox
    Friend WithEvents txtPartNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtCablePartType As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtCableJobType As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cboPartID As System.Windows.Forms.ComboBox
    Friend WithEvents txtCableDescription As System.Windows.Forms.TextBox
    Friend WithEvents txtCablePartNumber As System.Windows.Forms.TextBox
    Friend WithEvents gboSelectCableType As System.Windows.Forms.GroupBox
    Friend WithEvents rdoSpecialtyCable As System.Windows.Forms.RadioButton
    Friend WithEvents rdoTwistedPair As System.Windows.Forms.RadioButton
    Friend WithEvents rdoDropCable As System.Windows.Forms.RadioButton
    Friend WithEvents rdoFiber As System.Windows.Forms.RadioButton
    Friend WithEvents rdoCoax As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents PrintCableReportDocument As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
End Class
