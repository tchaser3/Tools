﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CheckDuplicateTools
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
        Me.btnFindToolKey = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtEnterToolKey = New System.Windows.Forms.TextBox()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnResetForm = New System.Windows.Forms.Button()
        Me.dgvSearchResults = New System.Windows.Forms.DataGridView()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtToolType = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtToolID = New System.Windows.Forms.TextBox()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboToolKey = New System.Windows.Forms.ComboBox()
        Me.txtPartNumber = New System.Windows.Forms.TextBox()
        Me.btnCheckForDuplicates = New System.Windows.Forms.Button()
        Me.btnRemoveDuplicates = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnUtilitiesMenu = New System.Windows.Forms.Button()
        Me.btnAdminMenu = New System.Windows.Forms.Button()
        Me.btnMainMenu = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        CType(Me.dgvSearchResults, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnFindToolKey
        '
        Me.btnFindToolKey.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFindToolKey.Location = New System.Drawing.Point(157, 200)
        Me.btnFindToolKey.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnFindToolKey.Name = "btnFindToolKey"
        Me.btnFindToolKey.Size = New System.Drawing.Size(122, 32)
        Me.btnFindToolKey.TabIndex = 234
        Me.btnFindToolKey.Text = "Find Tool Key"
        Me.btnFindToolKey.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(126, 129)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(192, 23)
        Me.Label3.TabIndex = 233
        Me.Label3.Text = "Enter Tool Key"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtEnterToolKey
        '
        Me.txtEnterToolKey.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEnterToolKey.Location = New System.Drawing.Point(126, 164)
        Me.txtEnterToolKey.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtEnterToolKey.Name = "txtEnterToolKey"
        Me.txtEnterToolKey.Size = New System.Drawing.Size(192, 22)
        Me.txtEnterToolKey.TabIndex = 232
        '
        'btnEdit
        '
        Me.btnEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.Location = New System.Drawing.Point(420, 212)
        Me.btnEdit.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(191, 52)
        Me.btnEdit.TabIndex = 212
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnResetForm
        '
        Me.btnResetForm.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnResetForm.Location = New System.Drawing.Point(420, 268)
        Me.btnResetForm.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnResetForm.Name = "btnResetForm"
        Me.btnResetForm.Size = New System.Drawing.Size(191, 52)
        Me.btnResetForm.TabIndex = 213
        Me.btnResetForm.Text = "Reset Form"
        Me.btnResetForm.UseVisualStyleBackColor = True
        '
        'dgvSearchResults
        '
        Me.dgvSearchResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSearchResults.Location = New System.Drawing.Point(645, 94)
        Me.dgvSearchResults.Name = "dgvSearchResults"
        Me.dgvSearchResults.RowTemplate.Height = 24
        Me.dgvSearchResults.Size = New System.Drawing.Size(554, 450)
        Me.dgvSearchResults.TabIndex = 231
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(40, 438)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(141, 23)
        Me.Label8.TabIndex = 228
        Me.Label8.Text = "Tool Type"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtToolType
        '
        Me.txtToolType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtToolType.Location = New System.Drawing.Point(200, 439)
        Me.txtToolType.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtToolType.Name = "txtToolType"
        Me.txtToolType.ReadOnly = True
        Me.txtToolType.Size = New System.Drawing.Size(192, 22)
        Me.txtToolType.TabIndex = 227
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(36, 316)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(145, 23)
        Me.Label6.TabIndex = 226
        Me.Label6.Text = "Tool ID"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(36, 396)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(145, 23)
        Me.Label10.TabIndex = 225
        Me.Label10.Text = "Description"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtToolID
        '
        Me.txtToolID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtToolID.Location = New System.Drawing.Point(200, 316)
        Me.txtToolID.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtToolID.Name = "txtToolID"
        Me.txtToolID.ReadOnly = True
        Me.txtToolID.Size = New System.Drawing.Size(192, 22)
        Me.txtToolID.TabIndex = 220
        '
        'txtDescription
        '
        Me.txtDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescription.Location = New System.Drawing.Point(200, 379)
        Me.txtDescription.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.ReadOnly = True
        Me.txtDescription.Size = New System.Drawing.Size(192, 53)
        Me.txtDescription.TabIndex = 222
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(14, 349)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(167, 23)
        Me.Label7.TabIndex = 224
        Me.Label7.Text = "Part Number"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(36, 285)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(145, 23)
        Me.Label2.TabIndex = 223
        Me.Label2.Text = "Tool Key"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboToolKey
        '
        Me.cboToolKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboToolKey.FormattingEnabled = True
        Me.cboToolKey.Location = New System.Drawing.Point(200, 284)
        Me.cboToolKey.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cboToolKey.Name = "cboToolKey"
        Me.cboToolKey.Size = New System.Drawing.Size(192, 24)
        Me.cboToolKey.TabIndex = 219
        '
        'txtPartNumber
        '
        Me.txtPartNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPartNumber.Location = New System.Drawing.Point(200, 349)
        Me.txtPartNumber.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtPartNumber.Name = "txtPartNumber"
        Me.txtPartNumber.ReadOnly = True
        Me.txtPartNumber.Size = New System.Drawing.Size(192, 22)
        Me.txtPartNumber.TabIndex = 221
        '
        'btnCheckForDuplicates
        '
        Me.btnCheckForDuplicates.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCheckForDuplicates.Location = New System.Drawing.Point(420, 100)
        Me.btnCheckForDuplicates.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnCheckForDuplicates.Name = "btnCheckForDuplicates"
        Me.btnCheckForDuplicates.Size = New System.Drawing.Size(191, 52)
        Me.btnCheckForDuplicates.TabIndex = 210
        Me.btnCheckForDuplicates.Text = "Check For Duplicates"
        Me.btnCheckForDuplicates.UseVisualStyleBackColor = True
        '
        'btnRemoveDuplicates
        '
        Me.btnRemoveDuplicates.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemoveDuplicates.Location = New System.Drawing.Point(420, 156)
        Me.btnRemoveDuplicates.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnRemoveDuplicates.Name = "btnRemoveDuplicates"
        Me.btnRemoveDuplicates.Size = New System.Drawing.Size(191, 52)
        Me.btnRemoveDuplicates.TabIndex = 211
        Me.btnRemoveDuplicates.Text = "Remove Duplicates"
        Me.btnRemoveDuplicates.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1187, 57)
        Me.Label1.TabIndex = 218
        Me.Label1.Text = "Check Duplicate Tool IDs"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnUtilitiesMenu
        '
        Me.btnUtilitiesMenu.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUtilitiesMenu.Location = New System.Drawing.Point(420, 324)
        Me.btnUtilitiesMenu.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnUtilitiesMenu.Name = "btnUtilitiesMenu"
        Me.btnUtilitiesMenu.Size = New System.Drawing.Size(191, 52)
        Me.btnUtilitiesMenu.TabIndex = 214
        Me.btnUtilitiesMenu.Text = "Utilities Menu"
        Me.btnUtilitiesMenu.UseVisualStyleBackColor = True
        '
        'btnAdminMenu
        '
        Me.btnAdminMenu.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdminMenu.Location = New System.Drawing.Point(420, 380)
        Me.btnAdminMenu.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnAdminMenu.Name = "btnAdminMenu"
        Me.btnAdminMenu.Size = New System.Drawing.Size(191, 52)
        Me.btnAdminMenu.TabIndex = 215
        Me.btnAdminMenu.Text = "Administrative Menu"
        Me.btnAdminMenu.UseVisualStyleBackColor = True
        '
        'btnMainMenu
        '
        Me.btnMainMenu.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMainMenu.Location = New System.Drawing.Point(420, 436)
        Me.btnMainMenu.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnMainMenu.Name = "btnMainMenu"
        Me.btnMainMenu.Size = New System.Drawing.Size(191, 52)
        Me.btnMainMenu.TabIndex = 216
        Me.btnMainMenu.Text = "Main Menu"
        Me.btnMainMenu.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Location = New System.Drawing.Point(420, 492)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(191, 52)
        Me.btnClose.TabIndex = 217
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'CheckDuplicateTools
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1229, 568)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnFindToolKey)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtEnterToolKey)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnResetForm)
        Me.Controls.Add(Me.dgvSearchResults)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtToolType)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtToolID)
        Me.Controls.Add(Me.txtDescription)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboToolKey)
        Me.Controls.Add(Me.txtPartNumber)
        Me.Controls.Add(Me.btnCheckForDuplicates)
        Me.Controls.Add(Me.btnRemoveDuplicates)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnUtilitiesMenu)
        Me.Controls.Add(Me.btnAdminMenu)
        Me.Controls.Add(Me.btnMainMenu)
        Me.Controls.Add(Me.btnClose)
        Me.Name = "CheckDuplicateTools"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CheckDuplicateTools"
        CType(Me.dgvSearchResults, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnFindToolKey As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtEnterToolKey As System.Windows.Forms.TextBox
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnResetForm As System.Windows.Forms.Button
    Friend WithEvents dgvSearchResults As System.Windows.Forms.DataGridView
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtToolType As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtToolID As System.Windows.Forms.TextBox
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboToolKey As System.Windows.Forms.ComboBox
    Friend WithEvents txtPartNumber As System.Windows.Forms.TextBox
    Friend WithEvents btnCheckForDuplicates As System.Windows.Forms.Button
    Friend WithEvents btnRemoveDuplicates As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnUtilitiesMenu As System.Windows.Forms.Button
    Friend WithEvents btnAdminMenu As System.Windows.Forms.Button
    Friend WithEvents btnMainMenu As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
End Class
