<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReturnCableReel
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
        Me.txtCableJobType = New System.Windows.Forms.TextBox()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cboPartID = New System.Windows.Forms.ComboBox()
        Me.txtCableDescription = New System.Windows.Forms.TextBox()
        Me.txtCablePartNumber = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.rdoSpecialtyCable = New System.Windows.Forms.RadioButton()
        Me.rdoTwistedPair = New System.Windows.Forms.RadioButton()
        Me.rdoDropCable = New System.Windows.Forms.RadioButton()
        Me.rdoFiber = New System.Windows.Forms.RadioButton()
        Me.rdoCoax = New System.Windows.Forms.RadioButton()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtCategory = New System.Windows.Forms.TextBox()
        Me.btnSelectPartNumber = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtWarehouse = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtDate = New System.Windows.Forms.TextBox()
        Me.txtReelID = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboTransactionID = New System.Windows.Forms.ComboBox()
        Me.txtPartNumber = New System.Windows.Forms.TextBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnCableMenu = New System.Windows.Forms.Button()
        Me.btnInventoryMenu = New System.Windows.Forms.Button()
        Me.btnMainMenu = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtCurrentFootage = New System.Windows.Forms.TextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.txtCablePartType = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(387, 229)
        Me.Label14.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(270, 31)
        Me.Label14.TabIndex = 482
        Me.Label14.Text = "Select Cable"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(389, 332)
        Me.Label15.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(109, 29)
        Me.Label15.TabIndex = 481
        Me.Label15.Text = "Job Type"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCableJobType
        '
        Me.txtCableJobType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCableJobType.Location = New System.Drawing.Point(512, 342)
        Me.txtCableJobType.Margin = New System.Windows.Forms.Padding(2)
        Me.txtCableJobType.Name = "txtCableJobType"
        Me.txtCableJobType.ReadOnly = True
        Me.txtCableJobType.Size = New System.Drawing.Size(145, 20)
        Me.txtCableJobType.TabIndex = 480
        '
        'btnNext
        '
        Me.btnNext.Enabled = False
        Me.btnNext.Location = New System.Drawing.Point(582, 417)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(75, 23)
        Me.btnNext.TabIndex = 6
        Me.btnNext.Text = "Next"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnBack
        '
        Me.btnBack.Enabled = False
        Me.btnBack.Location = New System.Drawing.Point(471, 417)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(75, 23)
        Me.btnBack.TabIndex = 5
        Me.btnBack.Text = "Back"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(389, 308)
        Me.Label16.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(109, 29)
        Me.Label16.TabIndex = 479
        Me.Label16.Text = "Description"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(389, 285)
        Me.Label17.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(109, 29)
        Me.Label17.TabIndex = 478
        Me.Label17.Text = "Part Number"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboPartID
        '
        Me.cboPartID.FormattingEnabled = True
        Me.cboPartID.Location = New System.Drawing.Point(512, 266)
        Me.cboPartID.Margin = New System.Windows.Forms.Padding(2)
        Me.cboPartID.Name = "cboPartID"
        Me.cboPartID.Size = New System.Drawing.Size(145, 21)
        Me.cboPartID.TabIndex = 475
        Me.cboPartID.Visible = False
        '
        'txtCableDescription
        '
        Me.txtCableDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCableDescription.Location = New System.Drawing.Point(512, 318)
        Me.txtCableDescription.Margin = New System.Windows.Forms.Padding(2)
        Me.txtCableDescription.Name = "txtCableDescription"
        Me.txtCableDescription.ReadOnly = True
        Me.txtCableDescription.Size = New System.Drawing.Size(145, 20)
        Me.txtCableDescription.TabIndex = 477
        '
        'txtCablePartNumber
        '
        Me.txtCablePartNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCablePartNumber.Location = New System.Drawing.Point(512, 295)
        Me.txtCablePartNumber.Margin = New System.Windows.Forms.Padding(2)
        Me.txtCablePartNumber.Name = "txtCablePartNumber"
        Me.txtCablePartNumber.ReadOnly = True
        Me.txtCablePartNumber.Size = New System.Drawing.Size(145, 20)
        Me.txtCablePartNumber.TabIndex = 476
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(455, 55)
        Me.Label13.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(202, 46)
        Me.Label13.TabIndex = 474
        Me.Label13.Text = "Select Type"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'rdoSpecialtyCable
        '
        Me.rdoSpecialtyCable.AutoSize = True
        Me.rdoSpecialtyCable.Location = New System.Drawing.Point(503, 196)
        Me.rdoSpecialtyCable.Name = "rdoSpecialtyCable"
        Me.rdoSpecialtyCable.Size = New System.Drawing.Size(98, 17)
        Me.rdoSpecialtyCable.TabIndex = 4
        Me.rdoSpecialtyCable.TabStop = True
        Me.rdoSpecialtyCable.Text = "Specialty Cable"
        Me.rdoSpecialtyCable.UseVisualStyleBackColor = True
        Me.rdoSpecialtyCable.Visible = False
        '
        'rdoTwistedPair
        '
        Me.rdoTwistedPair.AutoSize = True
        Me.rdoTwistedPair.Location = New System.Drawing.Point(503, 173)
        Me.rdoTwistedPair.Name = "rdoTwistedPair"
        Me.rdoTwistedPair.Size = New System.Drawing.Size(83, 17)
        Me.rdoTwistedPair.TabIndex = 3
        Me.rdoTwistedPair.TabStop = True
        Me.rdoTwistedPair.Text = "Twisted Pair"
        Me.rdoTwistedPair.UseVisualStyleBackColor = True
        Me.rdoTwistedPair.Visible = False
        '
        'rdoDropCable
        '
        Me.rdoDropCable.AutoSize = True
        Me.rdoDropCable.Location = New System.Drawing.Point(503, 150)
        Me.rdoDropCable.Name = "rdoDropCable"
        Me.rdoDropCable.Size = New System.Drawing.Size(78, 17)
        Me.rdoDropCable.TabIndex = 2
        Me.rdoDropCable.TabStop = True
        Me.rdoDropCable.Text = "Drop Cable"
        Me.rdoDropCable.UseVisualStyleBackColor = True
        Me.rdoDropCable.Visible = False
        '
        'rdoFiber
        '
        Me.rdoFiber.AutoSize = True
        Me.rdoFiber.Location = New System.Drawing.Point(503, 127)
        Me.rdoFiber.Name = "rdoFiber"
        Me.rdoFiber.Size = New System.Drawing.Size(48, 17)
        Me.rdoFiber.TabIndex = 1
        Me.rdoFiber.TabStop = True
        Me.rdoFiber.Text = "Fiber"
        Me.rdoFiber.UseVisualStyleBackColor = True
        Me.rdoFiber.Visible = False
        '
        'rdoCoax
        '
        Me.rdoCoax.AutoSize = True
        Me.rdoCoax.Location = New System.Drawing.Point(503, 104)
        Me.rdoCoax.Name = "rdoCoax"
        Me.rdoCoax.Size = New System.Drawing.Size(49, 17)
        Me.rdoCoax.TabIndex = 0
        Me.rdoCoax.TabStop = True
        Me.rdoCoax.Text = "Coax"
        Me.rdoCoax.UseVisualStyleBackColor = True
        Me.rdoCoax.Visible = False
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(53, 112)
        Me.Label9.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(109, 19)
        Me.Label9.TabIndex = 470
        Me.Label9.Text = "Cable Type"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCategory
        '
        Me.txtCategory.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCategory.Location = New System.Drawing.Point(180, 111)
        Me.txtCategory.Margin = New System.Windows.Forms.Padding(2)
        Me.txtCategory.Name = "txtCategory"
        Me.txtCategory.ReadOnly = True
        Me.txtCategory.Size = New System.Drawing.Size(145, 20)
        Me.txtCategory.TabIndex = 9
        '
        'btnSelectPartNumber
        '
        Me.btnSelectPartNumber.Enabled = False
        Me.btnSelectPartNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSelectPartNumber.Location = New System.Drawing.Point(512, 446)
        Me.btnSelectPartNumber.Margin = New System.Windows.Forms.Padding(2)
        Me.btnSelectPartNumber.Name = "btnSelectPartNumber"
        Me.btnSelectPartNumber.Size = New System.Drawing.Size(112, 31)
        Me.btnSelectPartNumber.TabIndex = 7
        Me.btnSelectPartNumber.Text = "Select Cable"
        Me.btnSelectPartNumber.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(57, 207)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(109, 19)
        Me.Label8.TabIndex = 468
        Me.Label8.Text = "Warehouse"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtWarehouse
        '
        Me.txtWarehouse.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtWarehouse.Location = New System.Drawing.Point(180, 207)
        Me.txtWarehouse.Margin = New System.Windows.Forms.Padding(2)
        Me.txtWarehouse.Name = "txtWarehouse"
        Me.txtWarehouse.ReadOnly = True
        Me.txtWarehouse.Size = New System.Drawing.Size(145, 20)
        Me.txtWarehouse.TabIndex = 13
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(57, 183)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(109, 19)
        Me.Label4.TabIndex = 467
        Me.Label4.Text = "Date"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(57, 159)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(109, 19)
        Me.Label5.TabIndex = 466
        Me.Label5.Text = "Reel ID"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtDate
        '
        Me.txtDate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDate.Location = New System.Drawing.Point(180, 183)
        Me.txtDate.Margin = New System.Windows.Forms.Padding(2)
        Me.txtDate.Name = "txtDate"
        Me.txtDate.ReadOnly = True
        Me.txtDate.Size = New System.Drawing.Size(145, 20)
        Me.txtDate.TabIndex = 12
        '
        'txtReelID
        '
        Me.txtReelID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtReelID.Location = New System.Drawing.Point(180, 159)
        Me.txtReelID.Margin = New System.Windows.Forms.Padding(2)
        Me.txtReelID.Name = "txtReelID"
        Me.txtReelID.Size = New System.Drawing.Size(145, 20)
        Me.txtReelID.TabIndex = 11
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(11, 9)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(856, 46)
        Me.Label1.TabIndex = 465
        Me.Label1.Text = "Return Cable Reel"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(57, 135)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(109, 19)
        Me.Label3.TabIndex = 463
        Me.Label3.Text = "Part Number"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 82)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(150, 19)
        Me.Label2.TabIndex = 462
        Me.Label2.Text = "Transaction ID"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboTransactionID
        '
        Me.cboTransactionID.FormattingEnabled = True
        Me.cboTransactionID.Location = New System.Drawing.Point(180, 82)
        Me.cboTransactionID.Margin = New System.Windows.Forms.Padding(2)
        Me.cboTransactionID.Name = "cboTransactionID"
        Me.cboTransactionID.Size = New System.Drawing.Size(145, 21)
        Me.cboTransactionID.TabIndex = 8
        '
        'txtPartNumber
        '
        Me.txtPartNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPartNumber.Location = New System.Drawing.Point(180, 135)
        Me.txtPartNumber.Margin = New System.Windows.Forms.Padding(2)
        Me.txtPartNumber.Name = "txtPartNumber"
        Me.txtPartNumber.ReadOnly = True
        Me.txtPartNumber.Size = New System.Drawing.Size(145, 20)
        Me.txtPartNumber.TabIndex = 10
        '
        'btnAdd
        '
        Me.btnAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Location = New System.Drawing.Point(700, 75)
        Me.btnAdd.Margin = New System.Windows.Forms.Padding(2)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(167, 58)
        Me.btnAdd.TabIndex = 15
        Me.btnAdd.Text = "Return Reel"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnCableMenu
        '
        Me.btnCableMenu.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCableMenu.Location = New System.Drawing.Point(700, 194)
        Me.btnCableMenu.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCableMenu.Name = "btnCableMenu"
        Me.btnCableMenu.Size = New System.Drawing.Size(167, 51)
        Me.btnCableMenu.TabIndex = 18
        Me.btnCableMenu.Text = "Cable Menu"
        Me.btnCableMenu.UseVisualStyleBackColor = True
        '
        'btnInventoryMenu
        '
        Me.btnInventoryMenu.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnInventoryMenu.Location = New System.Drawing.Point(700, 139)
        Me.btnInventoryMenu.Margin = New System.Windows.Forms.Padding(2)
        Me.btnInventoryMenu.Name = "btnInventoryMenu"
        Me.btnInventoryMenu.Size = New System.Drawing.Size(167, 51)
        Me.btnInventoryMenu.TabIndex = 17
        Me.btnInventoryMenu.Text = "Inventory Menu"
        Me.btnInventoryMenu.UseVisualStyleBackColor = True
        '
        'btnMainMenu
        '
        Me.btnMainMenu.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMainMenu.Location = New System.Drawing.Point(700, 249)
        Me.btnMainMenu.Margin = New System.Windows.Forms.Padding(2)
        Me.btnMainMenu.Name = "btnMainMenu"
        Me.btnMainMenu.Size = New System.Drawing.Size(167, 51)
        Me.btnMainMenu.TabIndex = 19
        Me.btnMainMenu.Text = "Main Menu"
        Me.btnMainMenu.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Location = New System.Drawing.Point(700, 304)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(2)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(167, 51)
        Me.btnClose.TabIndex = 20
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(19, 231)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(147, 19)
        Me.Label7.TabIndex = 484
        Me.Label7.Text = "Current Footage"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCurrentFootage
        '
        Me.txtCurrentFootage.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCurrentFootage.Location = New System.Drawing.Point(180, 231)
        Me.txtCurrentFootage.Margin = New System.Windows.Forms.Padding(2)
        Me.txtCurrentFootage.Name = "txtCurrentFootage"
        Me.txtCurrentFootage.Size = New System.Drawing.Size(145, 20)
        Me.txtCurrentFootage.TabIndex = 14
        '
        'Label32
        '
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(389, 359)
        Me.Label32.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(109, 29)
        Me.Label32.TabIndex = 534
        Me.Label32.Text = "Part Type"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCablePartType
        '
        Me.txtCablePartType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCablePartType.Location = New System.Drawing.Point(512, 369)
        Me.txtCablePartType.Margin = New System.Windows.Forms.Padding(2)
        Me.txtCablePartType.Name = "txtCablePartType"
        Me.txtCablePartType.ReadOnly = True
        Me.txtCablePartType.Size = New System.Drawing.Size(145, 20)
        Me.txtCablePartType.TabIndex = 533
        '
        'ReturnCableReel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(897, 502)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label32)
        Me.Controls.Add(Me.txtCablePartType)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtCurrentFootage)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtCableJobType)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.cboPartID)
        Me.Controls.Add(Me.txtCableDescription)
        Me.Controls.Add(Me.txtCablePartNumber)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.rdoSpecialtyCable)
        Me.Controls.Add(Me.rdoTwistedPair)
        Me.Controls.Add(Me.rdoDropCable)
        Me.Controls.Add(Me.rdoFiber)
        Me.Controls.Add(Me.rdoCoax)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtCategory)
        Me.Controls.Add(Me.btnSelectPartNumber)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtWarehouse)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtDate)
        Me.Controls.Add(Me.txtReelID)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboTransactionID)
        Me.Controls.Add(Me.txtPartNumber)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnCableMenu)
        Me.Controls.Add(Me.btnInventoryMenu)
        Me.Controls.Add(Me.btnMainMenu)
        Me.Controls.Add(Me.btnClose)
        Me.Name = "ReturnCableReel"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ReturnCableReel"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtCableJobType As System.Windows.Forms.TextBox
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents btnBack As System.Windows.Forms.Button
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cboPartID As System.Windows.Forms.ComboBox
    Friend WithEvents txtCableDescription As System.Windows.Forms.TextBox
    Friend WithEvents txtCablePartNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents rdoSpecialtyCable As System.Windows.Forms.RadioButton
    Friend WithEvents rdoTwistedPair As System.Windows.Forms.RadioButton
    Friend WithEvents rdoDropCable As System.Windows.Forms.RadioButton
    Friend WithEvents rdoFiber As System.Windows.Forms.RadioButton
    Friend WithEvents rdoCoax As System.Windows.Forms.RadioButton
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtCategory As System.Windows.Forms.TextBox
    Friend WithEvents btnSelectPartNumber As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtWarehouse As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtDate As System.Windows.Forms.TextBox
    Friend WithEvents txtReelID As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboTransactionID As System.Windows.Forms.ComboBox
    Friend WithEvents txtPartNumber As System.Windows.Forms.TextBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnCableMenu As System.Windows.Forms.Button
    Friend WithEvents btnInventoryMenu As System.Windows.Forms.Button
    Friend WithEvents btnMainMenu As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtCurrentFootage As System.Windows.Forms.TextBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents txtCablePartType As System.Windows.Forms.TextBox
End Class
