<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AdjustCableReel
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
        Me.btnAdjustReel = New System.Windows.Forms.Button()
        Me.btnCableAdminMenu = New System.Windows.Forms.Button()
        Me.btnAdministrativeMenu = New System.Windows.Forms.Button()
        Me.btnMainMenu = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtWarehouseID = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtReelID = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtOldFootage = New System.Windows.Forms.TextBox()
        Me.txtPartNumber = New System.Windows.Forms.TextBox()
        Me.cboTransactionID = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtEmployeeID = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCableType = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtNewFootage = New System.Windows.Forms.TextBox()
        Me.dgvSearchResults = New System.Windows.Forms.DataGridView()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtNotes = New System.Windows.Forms.TextBox()
        Me.btnFindReel = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtEnterReelID = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtEnterCable = New System.Windows.Forms.TextBox()
        CType(Me.dgvSearchResults, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnAdjustReel
        '
        Me.btnAdjustReel.Enabled = False
        Me.btnAdjustReel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdjustReel.Location = New System.Drawing.Point(959, 167)
        Me.btnAdjustReel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnAdjustReel.Name = "btnAdjustReel"
        Me.btnAdjustReel.Size = New System.Drawing.Size(223, 71)
        Me.btnAdjustReel.TabIndex = 3
        Me.btnAdjustReel.Text = "Adjust Reel"
        Me.btnAdjustReel.UseVisualStyleBackColor = True
        '
        'btnCableAdminMenu
        '
        Me.btnCableAdminMenu.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCableAdminMenu.Location = New System.Drawing.Point(959, 241)
        Me.btnCableAdminMenu.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnCableAdminMenu.Name = "btnCableAdminMenu"
        Me.btnCableAdminMenu.Size = New System.Drawing.Size(223, 63)
        Me.btnCableAdminMenu.TabIndex = 6
        Me.btnCableAdminMenu.Text = "Cable Admin Menu"
        Me.btnCableAdminMenu.UseVisualStyleBackColor = True
        '
        'btnAdministrativeMenu
        '
        Me.btnAdministrativeMenu.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdministrativeMenu.Location = New System.Drawing.Point(959, 310)
        Me.btnAdministrativeMenu.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnAdministrativeMenu.Name = "btnAdministrativeMenu"
        Me.btnAdministrativeMenu.Size = New System.Drawing.Size(223, 63)
        Me.btnAdministrativeMenu.TabIndex = 5
        Me.btnAdministrativeMenu.Text = "Administrative Menu"
        Me.btnAdministrativeMenu.UseVisualStyleBackColor = True
        '
        'btnMainMenu
        '
        Me.btnMainMenu.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMainMenu.Location = New System.Drawing.Point(959, 377)
        Me.btnMainMenu.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnMainMenu.Name = "btnMainMenu"
        Me.btnMainMenu.Size = New System.Drawing.Size(223, 63)
        Me.btnMainMenu.TabIndex = 7
        Me.btnMainMenu.Text = "Main Menu"
        Me.btnMainMenu.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Location = New System.Drawing.Point(959, 445)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(223, 63)
        Me.btnClose.TabIndex = 8
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(15, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1167, 57)
        Me.Label1.TabIndex = 500
        Me.Label1.Text = "Adjust Cable Reel"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(299, 295)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(145, 23)
        Me.Label8.TabIndex = 513
        Me.Label8.Text = "Warehouse ID"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtWarehouseID
        '
        Me.txtWarehouseID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtWarehouseID.Location = New System.Drawing.Point(463, 295)
        Me.txtWarehouseID.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtWarehouseID.Name = "txtWarehouseID"
        Me.txtWarehouseID.ReadOnly = True
        Me.txtWarehouseID.Size = New System.Drawing.Size(192, 22)
        Me.txtWarehouseID.TabIndex = 507
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(299, 233)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(145, 23)
        Me.Label5.TabIndex = 511
        Me.Label5.Text = "Reel ID"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtReelID
        '
        Me.txtReelID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtReelID.Location = New System.Drawing.Point(463, 233)
        Me.txtReelID.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtReelID.Name = "txtReelID"
        Me.txtReelID.ReadOnly = True
        Me.txtReelID.Size = New System.Drawing.Size(192, 22)
        Me.txtReelID.TabIndex = 503
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(248, 264)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(196, 23)
        Me.Label7.TabIndex = 510
        Me.Label7.Text = "Old Footage"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(299, 204)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(145, 23)
        Me.Label3.TabIndex = 509
        Me.Label3.Text = "Part Number"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(244, 171)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(200, 23)
        Me.Label2.TabIndex = 508
        Me.Label2.Text = "Transaction ID"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtOldFootage
        '
        Me.txtOldFootage.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOldFootage.Location = New System.Drawing.Point(463, 264)
        Me.txtOldFootage.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtOldFootage.Name = "txtOldFootage"
        Me.txtOldFootage.ReadOnly = True
        Me.txtOldFootage.Size = New System.Drawing.Size(192, 22)
        Me.txtOldFootage.TabIndex = 505
        '
        'txtPartNumber
        '
        Me.txtPartNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPartNumber.Location = New System.Drawing.Point(463, 205)
        Me.txtPartNumber.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtPartNumber.Name = "txtPartNumber"
        Me.txtPartNumber.ReadOnly = True
        Me.txtPartNumber.Size = New System.Drawing.Size(192, 22)
        Me.txtPartNumber.TabIndex = 502
        '
        'cboTransactionID
        '
        Me.cboTransactionID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTransactionID.FormattingEnabled = True
        Me.cboTransactionID.Location = New System.Drawing.Point(463, 168)
        Me.cboTransactionID.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cboTransactionID.Name = "cboTransactionID"
        Me.cboTransactionID.Size = New System.Drawing.Size(192, 24)
        Me.cboTransactionID.TabIndex = 517
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(208, 327)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(236, 23)
        Me.Label11.TabIndex = 522
        Me.Label11.Text = "Employee ID"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtEmployeeID
        '
        Me.txtEmployeeID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEmployeeID.Location = New System.Drawing.Point(463, 327)
        Me.txtEmployeeID.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtEmployeeID.Name = "txtEmployeeID"
        Me.txtEmployeeID.ReadOnly = True
        Me.txtEmployeeID.Size = New System.Drawing.Size(192, 22)
        Me.txtEmployeeID.TabIndex = 521
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(208, 363)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(236, 23)
        Me.Label4.TabIndex = 524
        Me.Label4.Text = "Cable Type"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCableType
        '
        Me.txtCableType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCableType.Location = New System.Drawing.Point(463, 363)
        Me.txtCableType.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtCableType.Name = "txtCableType"
        Me.txtCableType.ReadOnly = True
        Me.txtCableType.Size = New System.Drawing.Size(192, 22)
        Me.txtCableType.TabIndex = 523
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(208, 408)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(236, 23)
        Me.Label6.TabIndex = 526
        Me.Label6.Text = "New Footage"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtNewFootage
        '
        Me.txtNewFootage.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNewFootage.Location = New System.Drawing.Point(463, 408)
        Me.txtNewFootage.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtNewFootage.Name = "txtNewFootage"
        Me.txtNewFootage.ReadOnly = True
        Me.txtNewFootage.Size = New System.Drawing.Size(192, 22)
        Me.txtNewFootage.TabIndex = 525
        '
        'dgvSearchResults
        '
        Me.dgvSearchResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSearchResults.Location = New System.Drawing.Point(21, 168)
        Me.dgvSearchResults.Name = "dgvSearchResults"
        Me.dgvSearchResults.RowTemplate.Height = 24
        Me.dgvSearchResults.Size = New System.Drawing.Size(922, 432)
        Me.dgvSearchResults.TabIndex = 527
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(208, 449)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(236, 23)
        Me.Label9.TabIndex = 529
        Me.Label9.Text = "Notes"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtNotes
        '
        Me.txtNotes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNotes.Location = New System.Drawing.Point(463, 449)
        Me.txtNotes.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.ReadOnly = True
        Me.txtNotes.Size = New System.Drawing.Size(192, 22)
        Me.txtNotes.TabIndex = 528
        '
        'btnFindReel
        '
        Me.btnFindReel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFindReel.Location = New System.Drawing.Point(959, 92)
        Me.btnFindReel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnFindReel.Name = "btnFindReel"
        Me.btnFindReel.Size = New System.Drawing.Size(223, 71)
        Me.btnFindReel.TabIndex = 530
        Me.btnFindReel.Text = "Find Reel"
        Me.btnFindReel.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(114, 118)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(157, 23)
        Me.Label10.TabIndex = 532
        Me.Label10.Text = "Enter Reel ID"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtEnterReelID
        '
        Me.txtEnterReelID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEnterReelID.Location = New System.Drawing.Point(290, 119)
        Me.txtEnterReelID.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtEnterReelID.Name = "txtEnterReelID"
        Me.txtEnterReelID.Size = New System.Drawing.Size(192, 22)
        Me.txtEnterReelID.TabIndex = 531
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(505, 118)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(136, 23)
        Me.Label12.TabIndex = 534
        Me.Label12.Text = "Enter Cable"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtEnterCable
        '
        Me.txtEnterCable.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEnterCable.Location = New System.Drawing.Point(660, 119)
        Me.txtEnterCable.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtEnterCable.Name = "txtEnterCable"
        Me.txtEnterCable.Size = New System.Drawing.Size(192, 22)
        Me.txtEnterCable.TabIndex = 533
        '
        'AdjustCableReel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1194, 615)
        Me.ControlBox = False
        Me.Controls.Add(Me.dgvSearchResults)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtEnterCable)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtEnterReelID)
        Me.Controls.Add(Me.btnFindReel)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtNotes)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtNewFootage)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtCableType)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtEmployeeID)
        Me.Controls.Add(Me.cboTransactionID)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtWarehouseID)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtReelID)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtOldFootage)
        Me.Controls.Add(Me.txtPartNumber)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnAdjustReel)
        Me.Controls.Add(Me.btnCableAdminMenu)
        Me.Controls.Add(Me.btnAdministrativeMenu)
        Me.Controls.Add(Me.btnMainMenu)
        Me.Controls.Add(Me.btnClose)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "AdjustCableReel"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AdjustCableReel"
        CType(Me.dgvSearchResults, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnAdjustReel As System.Windows.Forms.Button
    Friend WithEvents btnCableAdminMenu As System.Windows.Forms.Button
    Friend WithEvents btnAdministrativeMenu As System.Windows.Forms.Button
    Friend WithEvents btnMainMenu As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtWarehouseID As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtReelID As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtOldFootage As System.Windows.Forms.TextBox
    Friend WithEvents txtPartNumber As System.Windows.Forms.TextBox
    Friend WithEvents cboTransactionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtEmployeeID As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCableType As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtNewFootage As System.Windows.Forms.TextBox
    Friend WithEvents dgvSearchResults As System.Windows.Forms.DataGridView
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtNotes As System.Windows.Forms.TextBox
    Friend WithEvents btnFindReel As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtEnterReelID As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtEnterCable As System.Windows.Forms.TextBox
End Class
