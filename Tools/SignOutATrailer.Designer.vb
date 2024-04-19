<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SignOutATrailer
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
        Me.txtEmployeeID = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.btnSearchByEmployeeLastName = New System.Windows.Forms.Button()
        Me.txtLastNameSearch = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.btnSearchByEmployeeID = New System.Windows.Forms.Button()
        Me.txtEmployeeIDSearch = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.cboEmployeeID = New System.Windows.Forms.ComboBox()
        Me.txtPhoneNumber = New System.Windows.Forms.TextBox()
        Me.txtFirstName = New System.Windows.Forms.TextBox()
        Me.txtLastName = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.btnFindTrailer = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtBJCNumberEntered = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtNotes = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtActive = New System.Windows.Forms.TextBox()
        Me.txtAvailable = New System.Windows.Forms.TextBox()
        Me.txtDate = New System.Windows.Forms.TextBox()
        Me.txtLicencePlate = New System.Windows.Forms.TextBox()
        Me.btnTrailerMenu = New System.Windows.Forms.Button()
        Me.cboTrailerID = New System.Windows.Forms.ComboBox()
        Me.txtBJCNumber = New System.Windows.Forms.TextBox()
        Me.btnSignOut = New System.Windows.Forms.Button()
        Me.btnMainMenu = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(20, 261)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(109, 19)
        Me.Label2.TabIndex = 229
        Me.Label2.Text = "Employee ID"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtEmployeeID
        '
        Me.txtEmployeeID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEmployeeID.Location = New System.Drawing.Point(143, 262)
        Me.txtEmployeeID.Margin = New System.Windows.Forms.Padding(2)
        Me.txtEmployeeID.Name = "txtEmployeeID"
        Me.txtEmployeeID.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtEmployeeID.ReadOnly = True
        Me.txtEmployeeID.Size = New System.Drawing.Size(145, 20)
        Me.txtEmployeeID.TabIndex = 228
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(20, 213)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(109, 19)
        Me.Label3.TabIndex = 227
        Me.Label3.Text = "BJC Number"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnNext
        '
        Me.btnNext.Enabled = False
        Me.btnNext.Location = New System.Drawing.Point(707, 506)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(75, 23)
        Me.btnNext.TabIndex = 226
        Me.btnNext.Text = "Next"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnBack
        '
        Me.btnBack.Enabled = False
        Me.btnBack.Location = New System.Drawing.Point(596, 506)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(75, 23)
        Me.btnBack.TabIndex = 225
        Me.btnBack.Text = "Back"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(517, 249)
        Me.Label20.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(313, 19)
        Me.Label20.TabIndex = 224
        Me.Label20.Text = "Search by Employee Last Name"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnSearchByEmployeeLastName
        '
        Me.btnSearchByEmployeeLastName.Enabled = False
        Me.btnSearchByEmployeeLastName.Location = New System.Drawing.Point(605, 308)
        Me.btnSearchByEmployeeLastName.Name = "btnSearchByEmployeeLastName"
        Me.btnSearchByEmployeeLastName.Size = New System.Drawing.Size(123, 49)
        Me.btnSearchByEmployeeLastName.TabIndex = 5
        Me.btnSearchByEmployeeLastName.Text = "Search By Employee Last Name"
        Me.btnSearchByEmployeeLastName.UseVisualStyleBackColor = True
        '
        'txtLastNameSearch
        '
        Me.txtLastNameSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLastNameSearch.Location = New System.Drawing.Point(596, 278)
        Me.txtLastNameSearch.Margin = New System.Windows.Forms.Padding(2)
        Me.txtLastNameSearch.Name = "txtLastNameSearch"
        Me.txtLastNameSearch.Size = New System.Drawing.Size(145, 20)
        Me.txtLastNameSearch.TabIndex = 4
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(574, 126)
        Me.Label16.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(173, 19)
        Me.Label16.TabIndex = 223
        Me.Label16.Text = "Search by Employee ID"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnSearchByEmployeeID
        '
        Me.btnSearchByEmployeeID.Enabled = False
        Me.btnSearchByEmployeeID.Location = New System.Drawing.Point(605, 185)
        Me.btnSearchByEmployeeID.Name = "btnSearchByEmployeeID"
        Me.btnSearchByEmployeeID.Size = New System.Drawing.Size(123, 49)
        Me.btnSearchByEmployeeID.TabIndex = 3
        Me.btnSearchByEmployeeID.Text = "Search By Employee ID"
        Me.btnSearchByEmployeeID.UseVisualStyleBackColor = True
        '
        'txtEmployeeIDSearch
        '
        Me.txtEmployeeIDSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEmployeeIDSearch.Location = New System.Drawing.Point(596, 155)
        Me.txtEmployeeIDSearch.Margin = New System.Windows.Forms.Padding(2)
        Me.txtEmployeeIDSearch.Name = "txtEmployeeIDSearch"
        Me.txtEmployeeIDSearch.Size = New System.Drawing.Size(145, 20)
        Me.txtEmployeeIDSearch.TabIndex = 2
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(512, 68)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(318, 42)
        Me.Label14.TabIndex = 222
        Me.Label14.Text = "Employee Information"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(514, 432)
        Me.Label15.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(109, 19)
        Me.Label15.TabIndex = 221
        Me.Label15.Text = "First Name"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(514, 454)
        Me.Label17.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(109, 19)
        Me.Label17.TabIndex = 220
        Me.Label17.Text = "Phone Number"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(514, 409)
        Me.Label18.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(109, 19)
        Me.Label18.TabIndex = 219
        Me.Label18.Text = "Last Name"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label19
        '
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(514, 380)
        Me.Label19.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(109, 19)
        Me.Label19.TabIndex = 218
        Me.Label19.Text = "Employee ID"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboEmployeeID
        '
        Me.cboEmployeeID.FormattingEnabled = True
        Me.cboEmployeeID.Location = New System.Drawing.Point(637, 380)
        Me.cboEmployeeID.Margin = New System.Windows.Forms.Padding(2)
        Me.cboEmployeeID.Name = "cboEmployeeID"
        Me.cboEmployeeID.Size = New System.Drawing.Size(145, 21)
        Me.cboEmployeeID.TabIndex = 214
        Me.cboEmployeeID.Visible = False
        '
        'txtPhoneNumber
        '
        Me.txtPhoneNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPhoneNumber.Location = New System.Drawing.Point(637, 454)
        Me.txtPhoneNumber.Margin = New System.Windows.Forms.Padding(2)
        Me.txtPhoneNumber.Name = "txtPhoneNumber"
        Me.txtPhoneNumber.ReadOnly = True
        Me.txtPhoneNumber.Size = New System.Drawing.Size(145, 20)
        Me.txtPhoneNumber.TabIndex = 217
        '
        'txtFirstName
        '
        Me.txtFirstName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFirstName.Location = New System.Drawing.Point(637, 432)
        Me.txtFirstName.Margin = New System.Windows.Forms.Padding(2)
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.ReadOnly = True
        Me.txtFirstName.Size = New System.Drawing.Size(145, 20)
        Me.txtFirstName.TabIndex = 216
        '
        'txtLastName
        '
        Me.txtLastName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLastName.Location = New System.Drawing.Point(637, 409)
        Me.txtLastName.Margin = New System.Windows.Forms.Padding(2)
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.ReadOnly = True
        Me.txtLastName.Size = New System.Drawing.Size(145, 20)
        Me.txtLastName.TabIndex = 215
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(23, 68)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(454, 42)
        Me.Label13.TabIndex = 213
        Me.Label13.Text = "Trailer Information"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnFindTrailer
        '
        Me.btnFindTrailer.Location = New System.Drawing.Point(354, 127)
        Me.btnFindTrailer.Name = "btnFindTrailer"
        Me.btnFindTrailer.Size = New System.Drawing.Size(123, 32)
        Me.btnFindTrailer.TabIndex = 1
        Me.btnFindTrailer.Text = "Find Trailer"
        Me.btnFindTrailer.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(17, 134)
        Me.Label12.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(173, 19)
        Me.Label12.TabIndex = 212
        Me.Label12.Text = "Type In BJC Number"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtBJCNumberEntered
        '
        Me.txtBJCNumberEntered.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBJCNumberEntered.Location = New System.Drawing.Point(194, 134)
        Me.txtBJCNumberEntered.Margin = New System.Windows.Forms.Padding(2)
        Me.txtBJCNumberEntered.Name = "txtBJCNumberEntered"
        Me.txtBJCNumberEntered.Size = New System.Drawing.Size(145, 20)
        Me.txtBJCNumberEntered.TabIndex = 0
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(20, 379)
        Me.Label11.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(109, 19)
        Me.Label11.TabIndex = 211
        Me.Label11.Text = "Notes"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtNotes
        '
        Me.txtNotes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNotes.Location = New System.Drawing.Point(143, 355)
        Me.txtNotes.Margin = New System.Windows.Forms.Padding(2)
        Me.txtNotes.Multiline = True
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.ReadOnly = True
        Me.txtNotes.Size = New System.Drawing.Size(145, 84)
        Me.txtNotes.TabIndex = 203
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(20, 287)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(109, 19)
        Me.Label6.TabIndex = 210
        Me.Label6.Text = "Date"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(20, 332)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(109, 19)
        Me.Label8.TabIndex = 209
        Me.Label8.Text = "Active"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(20, 310)
        Me.Label9.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(109, 19)
        Me.Label9.TabIndex = 208
        Me.Label9.Text = "Available"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(20, 240)
        Me.Label10.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(109, 19)
        Me.Label10.TabIndex = 207
        Me.Label10.Text = "License Plate"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtActive
        '
        Me.txtActive.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtActive.Location = New System.Drawing.Point(143, 332)
        Me.txtActive.Margin = New System.Windows.Forms.Padding(2)
        Me.txtActive.Name = "txtActive"
        Me.txtActive.ReadOnly = True
        Me.txtActive.Size = New System.Drawing.Size(145, 20)
        Me.txtActive.TabIndex = 202
        '
        'txtAvailable
        '
        Me.txtAvailable.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAvailable.Location = New System.Drawing.Point(143, 312)
        Me.txtAvailable.Margin = New System.Windows.Forms.Padding(2)
        Me.txtAvailable.Name = "txtAvailable"
        Me.txtAvailable.ReadOnly = True
        Me.txtAvailable.Size = New System.Drawing.Size(145, 20)
        Me.txtAvailable.TabIndex = 201
        '
        'txtDate
        '
        Me.txtDate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDate.Location = New System.Drawing.Point(143, 287)
        Me.txtDate.Margin = New System.Windows.Forms.Padding(2)
        Me.txtDate.Name = "txtDate"
        Me.txtDate.ReadOnly = True
        Me.txtDate.Size = New System.Drawing.Size(145, 20)
        Me.txtDate.TabIndex = 200
        '
        'txtLicencePlate
        '
        Me.txtLicencePlate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLicencePlate.Location = New System.Drawing.Point(143, 239)
        Me.txtLicencePlate.Margin = New System.Windows.Forms.Padding(2)
        Me.txtLicencePlate.Multiline = True
        Me.txtLicencePlate.Name = "txtLicencePlate"
        Me.txtLicencePlate.ReadOnly = True
        Me.txtLicencePlate.Size = New System.Drawing.Size(145, 20)
        Me.txtLicencePlate.TabIndex = 199
        '
        'btnTrailerMenu
        '
        Me.btnTrailerMenu.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTrailerMenu.Location = New System.Drawing.Point(310, 378)
        Me.btnTrailerMenu.Margin = New System.Windows.Forms.Padding(2)
        Me.btnTrailerMenu.Name = "btnTrailerMenu"
        Me.btnTrailerMenu.Size = New System.Drawing.Size(167, 58)
        Me.btnTrailerMenu.TabIndex = 191
        Me.btnTrailerMenu.Text = "Trailer Menu"
        Me.btnTrailerMenu.UseVisualStyleBackColor = True
        '
        'cboTrailerID
        '
        Me.cboTrailerID.FormattingEnabled = True
        Me.cboTrailerID.Location = New System.Drawing.Point(143, 185)
        Me.cboTrailerID.Margin = New System.Windows.Forms.Padding(2)
        Me.cboTrailerID.Name = "cboTrailerID"
        Me.cboTrailerID.Size = New System.Drawing.Size(145, 21)
        Me.cboTrailerID.TabIndex = 194
        Me.cboTrailerID.Visible = False
        '
        'txtBJCNumber
        '
        Me.txtBJCNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBJCNumber.Location = New System.Drawing.Point(143, 214)
        Me.txtBJCNumber.Margin = New System.Windows.Forms.Padding(2)
        Me.txtBJCNumber.Name = "txtBJCNumber"
        Me.txtBJCNumber.ReadOnly = True
        Me.txtBJCNumber.Size = New System.Drawing.Size(145, 20)
        Me.txtBJCNumber.TabIndex = 195
        '
        'btnSignOut
        '
        Me.btnSignOut.Enabled = False
        Me.btnSignOut.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSignOut.Location = New System.Drawing.Point(310, 240)
        Me.btnSignOut.Margin = New System.Windows.Forms.Padding(2)
        Me.btnSignOut.Name = "btnSignOut"
        Me.btnSignOut.Size = New System.Drawing.Size(167, 58)
        Me.btnSignOut.TabIndex = 6
        Me.btnSignOut.Text = "SignOut"
        Me.btnSignOut.UseVisualStyleBackColor = True
        '
        'btnMainMenu
        '
        Me.btnMainMenu.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMainMenu.Location = New System.Drawing.Point(310, 307)
        Me.btnMainMenu.Margin = New System.Windows.Forms.Padding(2)
        Me.btnMainMenu.Name = "btnMainMenu"
        Me.btnMainMenu.Size = New System.Drawing.Size(167, 58)
        Me.btnMainMenu.TabIndex = 190
        Me.btnMainMenu.Text = "Main Menu"
        Me.btnMainMenu.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Location = New System.Drawing.Point(310, 448)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(2)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(167, 58)
        Me.btnClose.TabIndex = 192
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(818, 42)
        Me.Label1.TabIndex = 193
        Me.Label1.Text = "Sign Out A Trailer"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'SignOutATrailer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(842, 559)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtEmployeeID)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.btnSearchByEmployeeLastName)
        Me.Controls.Add(Me.txtLastNameSearch)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.btnSearchByEmployeeID)
        Me.Controls.Add(Me.txtEmployeeIDSearch)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.cboEmployeeID)
        Me.Controls.Add(Me.txtPhoneNumber)
        Me.Controls.Add(Me.txtFirstName)
        Me.Controls.Add(Me.txtLastName)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.btnFindTrailer)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtBJCNumberEntered)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtNotes)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtActive)
        Me.Controls.Add(Me.txtAvailable)
        Me.Controls.Add(Me.txtDate)
        Me.Controls.Add(Me.txtLicencePlate)
        Me.Controls.Add(Me.btnTrailerMenu)
        Me.Controls.Add(Me.cboTrailerID)
        Me.Controls.Add(Me.txtBJCNumber)
        Me.Controls.Add(Me.btnSignOut)
        Me.Controls.Add(Me.btnMainMenu)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.Label1)
        Me.Name = "SignOutATrailer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sign Out A Trailer"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtEmployeeID As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents btnBack As System.Windows.Forms.Button
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents btnSearchByEmployeeLastName As System.Windows.Forms.Button
    Friend WithEvents txtLastNameSearch As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents btnSearchByEmployeeID As System.Windows.Forms.Button
    Friend WithEvents txtEmployeeIDSearch As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents cboEmployeeID As System.Windows.Forms.ComboBox
    Friend WithEvents txtPhoneNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtFirstName As System.Windows.Forms.TextBox
    Friend WithEvents txtLastName As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents btnFindTrailer As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtBJCNumberEntered As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtNotes As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtActive As System.Windows.Forms.TextBox
    Friend WithEvents txtAvailable As System.Windows.Forms.TextBox
    Friend WithEvents txtDate As System.Windows.Forms.TextBox
    Friend WithEvents txtLicencePlate As System.Windows.Forms.TextBox
    Friend WithEvents btnTrailerMenu As System.Windows.Forms.Button
    Friend WithEvents cboTrailerID As System.Windows.Forms.ComboBox
    Friend WithEvents txtBJCNumber As System.Windows.Forms.TextBox
    Friend WithEvents btnSignOut As System.Windows.Forms.Button
    Friend WithEvents btnMainMenu As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
