<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SpecialityCable
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
        Me.txtCategory = New System.Windows.Forms.TextBox()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cboTypeID = New System.Windows.Forms.ComboBox()
        Me.txtCableType = New System.Windows.Forms.TextBox()
        Me.txtCableTypePartNumber = New System.Windows.Forms.TextBox()
        Me.btnCreateReelID = New System.Windows.Forms.Button()
        Me.btnSelectPartNumber = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtNotes = New System.Windows.Forms.TextBox()
        Me.txtWarehouse = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtDate = New System.Windows.Forms.TextBox()
        Me.txtReelID = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboReelTransactionID = New System.Windows.Forms.ComboBox()
        Me.txtCurrentFootage = New System.Windows.Forms.TextBox()
        Me.txtPartNumber = New System.Windows.Forms.TextBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnCableAdministration = New System.Windows.Forms.Button()
        Me.btnAdministrativeMenu = New System.Windows.Forms.Button()
        Me.btnMainMenu = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtCategory
        '
        Me.txtCategory.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCategory.Location = New System.Drawing.Point(176, 424)
        Me.txtCategory.Margin = New System.Windows.Forms.Padding(2)
        Me.txtCategory.Name = "txtCategory"
        Me.txtCategory.Size = New System.Drawing.Size(145, 20)
        Me.txtCategory.TabIndex = 379
        Me.txtCategory.Visible = False
        '
        'btnNext
        '
        Me.btnNext.Enabled = False
        Me.btnNext.Location = New System.Drawing.Point(246, 458)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(75, 23)
        Me.btnNext.TabIndex = 356
        Me.btnNext.Text = "Next"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnBack
        '
        Me.btnBack.Enabled = False
        Me.btnBack.Location = New System.Drawing.Point(135, 458)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(75, 23)
        Me.btnBack.TabIndex = 355
        Me.btnBack.Text = "Back"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(53, 390)
        Me.Label10.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(109, 29)
        Me.Label10.TabIndex = 378
        Me.Label10.Text = "Cable Type"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(53, 367)
        Me.Label11.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(109, 29)
        Me.Label11.TabIndex = 377
        Me.Label11.Text = "Part Number"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboTypeID
        '
        Me.cboTypeID.FormattingEnabled = True
        Me.cboTypeID.Location = New System.Drawing.Point(176, 348)
        Me.cboTypeID.Margin = New System.Windows.Forms.Padding(2)
        Me.cboTypeID.Name = "cboTypeID"
        Me.cboTypeID.Size = New System.Drawing.Size(145, 21)
        Me.cboTypeID.TabIndex = 374
        Me.cboTypeID.Visible = False
        '
        'txtCableType
        '
        Me.txtCableType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCableType.Location = New System.Drawing.Point(176, 400)
        Me.txtCableType.Margin = New System.Windows.Forms.Padding(2)
        Me.txtCableType.Name = "txtCableType"
        Me.txtCableType.ReadOnly = True
        Me.txtCableType.Size = New System.Drawing.Size(145, 20)
        Me.txtCableType.TabIndex = 376
        '
        'txtCableTypePartNumber
        '
        Me.txtCableTypePartNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCableTypePartNumber.Location = New System.Drawing.Point(176, 377)
        Me.txtCableTypePartNumber.Margin = New System.Windows.Forms.Padding(2)
        Me.txtCableTypePartNumber.Name = "txtCableTypePartNumber"
        Me.txtCableTypePartNumber.ReadOnly = True
        Me.txtCableTypePartNumber.Size = New System.Drawing.Size(145, 20)
        Me.txtCableTypePartNumber.TabIndex = 375
        '
        'btnCreateReelID
        '
        Me.btnCreateReelID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCreateReelID.Location = New System.Drawing.Point(329, 153)
        Me.btnCreateReelID.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCreateReelID.Name = "btnCreateReelID"
        Me.btnCreateReelID.Size = New System.Drawing.Size(112, 31)
        Me.btnCreateReelID.TabIndex = 357
        Me.btnCreateReelID.Text = "Create Reel ID"
        Me.btnCreateReelID.UseVisualStyleBackColor = True
        '
        'btnSelectPartNumber
        '
        Me.btnSelectPartNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSelectPartNumber.Location = New System.Drawing.Point(329, 372)
        Me.btnSelectPartNumber.Margin = New System.Windows.Forms.Padding(2)
        Me.btnSelectPartNumber.Name = "btnSelectPartNumber"
        Me.btnSelectPartNumber.Size = New System.Drawing.Size(112, 31)
        Me.btnSelectPartNumber.TabIndex = 358
        Me.btnSelectPartNumber.Text = "Select Cable"
        Me.btnSelectPartNumber.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(57, 227)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(109, 19)
        Me.Label6.TabIndex = 373
        Me.Label6.Text = "Notes"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(57, 204)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(109, 19)
        Me.Label8.TabIndex = 372
        Me.Label8.Text = "Warehouse"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtNotes
        '
        Me.txtNotes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNotes.Location = New System.Drawing.Point(180, 227)
        Me.txtNotes.Margin = New System.Windows.Forms.Padding(2)
        Me.txtNotes.Multiline = True
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNotes.Size = New System.Drawing.Size(145, 84)
        Me.txtNotes.TabIndex = 354
        '
        'txtWarehouse
        '
        Me.txtWarehouse.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtWarehouse.Location = New System.Drawing.Point(180, 204)
        Me.txtWarehouse.Margin = New System.Windows.Forms.Padding(2)
        Me.txtWarehouse.Name = "txtWarehouse"
        Me.txtWarehouse.Size = New System.Drawing.Size(145, 20)
        Me.txtWarehouse.TabIndex = 353
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(57, 180)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(109, 19)
        Me.Label4.TabIndex = 371
        Me.Label4.Text = "Date"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(57, 157)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(109, 19)
        Me.Label5.TabIndex = 370
        Me.Label5.Text = "Reel ID"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtDate
        '
        Me.txtDate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDate.Location = New System.Drawing.Point(180, 180)
        Me.txtDate.Margin = New System.Windows.Forms.Padding(2)
        Me.txtDate.Name = "txtDate"
        Me.txtDate.Size = New System.Drawing.Size(145, 20)
        Me.txtDate.TabIndex = 352
        '
        'txtReelID
        '
        Me.txtReelID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtReelID.Location = New System.Drawing.Point(180, 157)
        Me.txtReelID.Margin = New System.Windows.Forms.Padding(2)
        Me.txtReelID.Name = "txtReelID"
        Me.txtReelID.Size = New System.Drawing.Size(145, 20)
        Me.txtReelID.TabIndex = 351
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(11, 9)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(605, 46)
        Me.Label1.TabIndex = 369
        Me.Label1.Text = "Add/Edit Twisted Pair Cable"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(19, 132)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(147, 19)
        Me.Label7.TabIndex = 368
        Me.Label7.Text = "Current Footage"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(57, 109)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(109, 19)
        Me.Label3.TabIndex = 367
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
        Me.Label2.TabIndex = 366
        Me.Label2.Text = "Reel Transaction ID"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboReelTransactionID
        '
        Me.cboReelTransactionID.FormattingEnabled = True
        Me.cboReelTransactionID.Location = New System.Drawing.Point(180, 82)
        Me.cboReelTransactionID.Margin = New System.Windows.Forms.Padding(2)
        Me.cboReelTransactionID.Name = "cboReelTransactionID"
        Me.cboReelTransactionID.Size = New System.Drawing.Size(145, 21)
        Me.cboReelTransactionID.TabIndex = 365
        '
        'txtCurrentFootage
        '
        Me.txtCurrentFootage.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCurrentFootage.Location = New System.Drawing.Point(180, 132)
        Me.txtCurrentFootage.Margin = New System.Windows.Forms.Padding(2)
        Me.txtCurrentFootage.Name = "txtCurrentFootage"
        Me.txtCurrentFootage.Size = New System.Drawing.Size(145, 20)
        Me.txtCurrentFootage.TabIndex = 350
        '
        'txtPartNumber
        '
        Me.txtPartNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPartNumber.Location = New System.Drawing.Point(180, 109)
        Me.txtPartNumber.Margin = New System.Windows.Forms.Padding(2)
        Me.txtPartNumber.Name = "txtPartNumber"
        Me.txtPartNumber.Size = New System.Drawing.Size(145, 20)
        Me.txtPartNumber.TabIndex = 349
        '
        'btnAdd
        '
        Me.btnAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Location = New System.Drawing.Point(449, 83)
        Me.btnAdd.Margin = New System.Windows.Forms.Padding(2)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(167, 58)
        Me.btnAdd.TabIndex = 359
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.Location = New System.Drawing.Point(449, 145)
        Me.btnEdit.Margin = New System.Windows.Forms.Padding(2)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(167, 58)
        Me.btnEdit.TabIndex = 360
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnCableAdministration
        '
        Me.btnCableAdministration.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCableAdministration.Location = New System.Drawing.Point(449, 262)
        Me.btnCableAdministration.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCableAdministration.Name = "btnCableAdministration"
        Me.btnCableAdministration.Size = New System.Drawing.Size(167, 51)
        Me.btnCableAdministration.TabIndex = 362
        Me.btnCableAdministration.Text = "Cable Administration"
        Me.btnCableAdministration.UseVisualStyleBackColor = True
        '
        'btnAdministrativeMenu
        '
        Me.btnAdministrativeMenu.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdministrativeMenu.Location = New System.Drawing.Point(449, 207)
        Me.btnAdministrativeMenu.Margin = New System.Windows.Forms.Padding(2)
        Me.btnAdministrativeMenu.Name = "btnAdministrativeMenu"
        Me.btnAdministrativeMenu.Size = New System.Drawing.Size(167, 51)
        Me.btnAdministrativeMenu.TabIndex = 361
        Me.btnAdministrativeMenu.Text = "Administrative Menu"
        Me.btnAdministrativeMenu.UseVisualStyleBackColor = True
        '
        'btnMainMenu
        '
        Me.btnMainMenu.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMainMenu.Location = New System.Drawing.Point(449, 317)
        Me.btnMainMenu.Margin = New System.Windows.Forms.Padding(2)
        Me.btnMainMenu.Name = "btnMainMenu"
        Me.btnMainMenu.Size = New System.Drawing.Size(167, 51)
        Me.btnMainMenu.TabIndex = 363
        Me.btnMainMenu.Text = "Main Menu"
        Me.btnMainMenu.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Location = New System.Drawing.Point(449, 372)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(2)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(167, 51)
        Me.btnClose.TabIndex = 364
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'SpecialityCable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(641, 508)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtCategory)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.cboTypeID)
        Me.Controls.Add(Me.txtCableType)
        Me.Controls.Add(Me.txtCableTypePartNumber)
        Me.Controls.Add(Me.btnCreateReelID)
        Me.Controls.Add(Me.btnSelectPartNumber)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtNotes)
        Me.Controls.Add(Me.txtWarehouse)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtDate)
        Me.Controls.Add(Me.txtReelID)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboReelTransactionID)
        Me.Controls.Add(Me.txtCurrentFootage)
        Me.Controls.Add(Me.txtPartNumber)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnCableAdministration)
        Me.Controls.Add(Me.btnAdministrativeMenu)
        Me.Controls.Add(Me.btnMainMenu)
        Me.Controls.Add(Me.btnClose)
        Me.Name = "SpecialityCable"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Initial Speciality Cable"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtCategory As System.Windows.Forms.TextBox
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents btnBack As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cboTypeID As System.Windows.Forms.ComboBox
    Friend WithEvents txtCableType As System.Windows.Forms.TextBox
    Friend WithEvents txtCableTypePartNumber As System.Windows.Forms.TextBox
    Friend WithEvents btnCreateReelID As System.Windows.Forms.Button
    Friend WithEvents btnSelectPartNumber As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtNotes As System.Windows.Forms.TextBox
    Friend WithEvents txtWarehouse As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtDate As System.Windows.Forms.TextBox
    Friend WithEvents txtReelID As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboReelTransactionID As System.Windows.Forms.ComboBox
    Friend WithEvents txtCurrentFootage As System.Windows.Forms.TextBox
    Friend WithEvents txtPartNumber As System.Windows.Forms.TextBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnCableAdministration As System.Windows.Forms.Button
    Friend WithEvents btnAdministrativeMenu As System.Windows.Forms.Button
    Friend WithEvents btnMainMenu As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
End Class
