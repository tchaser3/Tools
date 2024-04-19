<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CreatePartNumbers
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnSearchForPartNumber = New System.Windows.Forms.Button()
        Me.txtPartNumberSeach = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtPartNumber = New System.Windows.Forms.TextBox()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.btnAdministrativeMenu = New System.Windows.Forms.Button()
        Me.lblTitleLabel = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboPartID = New System.Windows.Forms.ComboBox()
        Me.txtTimeWarnerPart = New System.Windows.Forms.TextBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnMainMenu = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnNavigationNext = New System.Windows.Forms.Button()
        Me.btnNavigationBack = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtPrice = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnKeyWordSearch = New System.Windows.Forms.Button()
        Me.txtKeyWordEntered = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtActive = New System.Windows.Forms.TextBox()
        Me.txtPartID = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnSearchForPartNumber)
        Me.GroupBox1.Controls.Add(Me.txtPartNumberSeach)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(374, 241)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(200, 131)
        Me.GroupBox1.TabIndex = 177
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Seach For Part Number"
        '
        'btnSearchForPartNumber
        '
        Me.btnSearchForPartNumber.Location = New System.Drawing.Point(28, 81)
        Me.btnSearchForPartNumber.Name = "btnSearchForPartNumber"
        Me.btnSearchForPartNumber.Size = New System.Drawing.Size(145, 34)
        Me.btnSearchForPartNumber.TabIndex = 1
        Me.btnSearchForPartNumber.Text = "Search For Number"
        Me.btnSearchForPartNumber.UseVisualStyleBackColor = True
        '
        'txtPartNumberSeach
        '
        Me.txtPartNumberSeach.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPartNumberSeach.Location = New System.Drawing.Point(28, 49)
        Me.txtPartNumberSeach.Margin = New System.Windows.Forms.Padding(2)
        Me.txtPartNumberSeach.Name = "txtPartNumberSeach"
        Me.txtPartNumberSeach.Size = New System.Drawing.Size(145, 22)
        Me.txtPartNumberSeach.TabIndex = 0
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(25, 23)
        Me.Label17.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(148, 19)
        Me.Label17.TabIndex = 150
        Me.Label17.Text = "Enter Part Number"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(45, 125)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(109, 19)
        Me.Label6.TabIndex = 175
        Me.Label6.Text = "Part Number"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(45, 190)
        Me.Label10.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(109, 19)
        Me.Label10.TabIndex = 172
        Me.Label10.Text = "Description"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtPartNumber
        '
        Me.txtPartNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPartNumber.Location = New System.Drawing.Point(168, 125)
        Me.txtPartNumber.Margin = New System.Windows.Forms.Padding(2)
        Me.txtPartNumber.Name = "txtPartNumber"
        Me.txtPartNumber.Size = New System.Drawing.Size(145, 20)
        Me.txtPartNumber.TabIndex = 1
        '
        'txtDescription
        '
        Me.txtDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescription.Location = New System.Drawing.Point(168, 176)
        Me.txtDescription.Margin = New System.Windows.Forms.Padding(2)
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(145, 44)
        Me.txtDescription.TabIndex = 5
        '
        'btnAdministrativeMenu
        '
        Me.btnAdministrativeMenu.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdministrativeMenu.Location = New System.Drawing.Point(613, 264)
        Me.btnAdministrativeMenu.Margin = New System.Windows.Forms.Padding(2)
        Me.btnAdministrativeMenu.Name = "btnAdministrativeMenu"
        Me.btnAdministrativeMenu.Size = New System.Drawing.Size(167, 58)
        Me.btnAdministrativeMenu.TabIndex = 9
        Me.btnAdministrativeMenu.Text = "Administrative Menu"
        Me.btnAdministrativeMenu.UseVisualStyleBackColor = True
        '
        'lblTitleLabel
        '
        Me.lblTitleLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitleLabel.Location = New System.Drawing.Point(11, 9)
        Me.lblTitleLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblTitleLabel.Name = "lblTitleLabel"
        Me.lblTitleLabel.Size = New System.Drawing.Size(769, 41)
        Me.lblTitleLabel.TabIndex = 171
        Me.lblTitleLabel.Text = "Create Part Numbers"
        Me.lblTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(6, 152)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(148, 19)
        Me.Label7.TabIndex = 170
        Me.Label7.Text = "Time Warner Part"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(45, 100)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(109, 19)
        Me.Label2.TabIndex = 167
        Me.Label2.Text = "Part ID"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboPartID
        '
        Me.cboPartID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPartID.FormattingEnabled = True
        Me.cboPartID.Location = New System.Drawing.Point(168, 67)
        Me.cboPartID.Margin = New System.Windows.Forms.Padding(2)
        Me.cboPartID.Name = "cboPartID"
        Me.cboPartID.Size = New System.Drawing.Size(145, 21)
        Me.cboPartID.TabIndex = 0
        Me.cboPartID.Visible = False
        '
        'txtTimeWarnerPart
        '
        Me.txtTimeWarnerPart.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTimeWarnerPart.Location = New System.Drawing.Point(168, 152)
        Me.txtTimeWarnerPart.Margin = New System.Windows.Forms.Padding(2)
        Me.txtTimeWarnerPart.Name = "txtTimeWarnerPart"
        Me.txtTimeWarnerPart.Size = New System.Drawing.Size(145, 20)
        Me.txtTimeWarnerPart.TabIndex = 4
        '
        'btnAdd
        '
        Me.btnAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Location = New System.Drawing.Point(613, 61)
        Me.btnAdd.Margin = New System.Windows.Forms.Padding(2)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(167, 58)
        Me.btnAdd.TabIndex = 6
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.Location = New System.Drawing.Point(613, 126)
        Me.btnEdit.Margin = New System.Windows.Forms.Padding(2)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(167, 58)
        Me.btnEdit.TabIndex = 7
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnMainMenu
        '
        Me.btnMainMenu.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMainMenu.Location = New System.Drawing.Point(613, 193)
        Me.btnMainMenu.Margin = New System.Windows.Forms.Padding(2)
        Me.btnMainMenu.Name = "btnMainMenu"
        Me.btnMainMenu.Size = New System.Drawing.Size(167, 58)
        Me.btnMainMenu.TabIndex = 8
        Me.btnMainMenu.Text = "Main Menu"
        Me.btnMainMenu.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Location = New System.Drawing.Point(613, 334)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(2)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(167, 58)
        Me.btnClose.TabIndex = 10
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnNavigationNext)
        Me.GroupBox2.Controls.Add(Me.btnNavigationBack)
        Me.GroupBox2.Location = New System.Drawing.Point(80, 290)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(233, 65)
        Me.GroupBox2.TabIndex = 186
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Record Navigation"
        '
        'btnNavigationNext
        '
        Me.btnNavigationNext.Enabled = False
        Me.btnNavigationNext.Location = New System.Drawing.Point(118, 25)
        Me.btnNavigationNext.Name = "btnNavigationNext"
        Me.btnNavigationNext.Size = New System.Drawing.Size(75, 23)
        Me.btnNavigationNext.TabIndex = 9
        Me.btnNavigationNext.Text = "Next"
        Me.btnNavigationNext.UseVisualStyleBackColor = True
        '
        'btnNavigationBack
        '
        Me.btnNavigationBack.Enabled = False
        Me.btnNavigationBack.Location = New System.Drawing.Point(40, 25)
        Me.btnNavigationBack.Name = "btnNavigationBack"
        Me.btnNavigationBack.Size = New System.Drawing.Size(75, 23)
        Me.btnNavigationBack.TabIndex = 8
        Me.btnNavigationBack.Text = "Back"
        Me.btnNavigationBack.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(6, 224)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(148, 19)
        Me.Label8.TabIndex = 189
        Me.Label8.Text = "Price"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtPrice
        '
        Me.txtPrice.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPrice.Location = New System.Drawing.Point(168, 224)
        Me.txtPrice.Margin = New System.Windows.Forms.Padding(2)
        Me.txtPrice.Name = "txtPrice"
        Me.txtPrice.Size = New System.Drawing.Size(145, 20)
        Me.txtPrice.TabIndex = 188
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.btnKeyWordSearch)
        Me.GroupBox3.Controls.Add(Me.txtKeyWordEntered)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(355, 67)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(233, 140)
        Me.GroupBox3.TabIndex = 190
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Key Word Search"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(221, 23)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Enter Key Word"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnKeyWordSearch
        '
        Me.btnKeyWordSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnKeyWordSearch.Location = New System.Drawing.Point(62, 93)
        Me.btnKeyWordSearch.Name = "btnKeyWordSearch"
        Me.btnKeyWordSearch.Size = New System.Drawing.Size(108, 37)
        Me.btnKeyWordSearch.TabIndex = 10
        Me.btnKeyWordSearch.Text = "Search"
        Me.btnKeyWordSearch.UseVisualStyleBackColor = True
        '
        'txtKeyWordEntered
        '
        Me.txtKeyWordEntered.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtKeyWordEntered.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtKeyWordEntered.Location = New System.Drawing.Point(41, 51)
        Me.txtKeyWordEntered.Name = "txtKeyWordEntered"
        Me.txtKeyWordEntered.Size = New System.Drawing.Size(150, 29)
        Me.txtKeyWordEntered.TabIndex = 7
        Me.txtKeyWordEntered.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(6, 251)
        Me.Label9.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(148, 19)
        Me.Label9.TabIndex = 192
        Me.Label9.Text = "Active Part"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtActive
        '
        Me.txtActive.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtActive.Location = New System.Drawing.Point(168, 251)
        Me.txtActive.Margin = New System.Windows.Forms.Padding(2)
        Me.txtActive.Name = "txtActive"
        Me.txtActive.ReadOnly = True
        Me.txtActive.Size = New System.Drawing.Size(145, 20)
        Me.txtActive.TabIndex = 191
        '
        'txtPartID
        '
        Me.txtPartID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPartID.Location = New System.Drawing.Point(168, 100)
        Me.txtPartID.Margin = New System.Windows.Forms.Padding(2)
        Me.txtPartID.Name = "txtPartID"
        Me.txtPartID.ReadOnly = True
        Me.txtPartID.Size = New System.Drawing.Size(145, 20)
        Me.txtPartID.TabIndex = 193
        '
        'CreatePartNumbers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(821, 419)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtPartID)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtActive)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtPrice)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtPartNumber)
        Me.Controls.Add(Me.txtDescription)
        Me.Controls.Add(Me.btnAdministrativeMenu)
        Me.Controls.Add(Me.lblTitleLabel)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboPartID)
        Me.Controls.Add(Me.txtTimeWarnerPart)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnMainMenu)
        Me.Controls.Add(Me.btnClose)
        Me.Name = "CreatePartNumbers"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CreatePartNumbers"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnSearchForPartNumber As System.Windows.Forms.Button
    Friend WithEvents txtPartNumberSeach As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtPartNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents btnAdministrativeMenu As System.Windows.Forms.Button
    Friend WithEvents lblTitleLabel As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboPartID As System.Windows.Forms.ComboBox
    Friend WithEvents txtTimeWarnerPart As System.Windows.Forms.TextBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnMainMenu As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnNavigationNext As System.Windows.Forms.Button
    Friend WithEvents btnNavigationBack As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtPrice As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnKeyWordSearch As System.Windows.Forms.Button
    Friend WithEvents txtKeyWordEntered As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtActive As System.Windows.Forms.TextBox
    Friend WithEvents txtPartID As System.Windows.Forms.TextBox
End Class
