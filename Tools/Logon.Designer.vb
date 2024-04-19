<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Logon
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtEmployeeID = New System.Windows.Forms.TextBox()
        Me.btnLogon = New System.Windows.Forms.Button()
        Me.txtLastName = New System.Windows.Forms.TextBox()
        Me.txtFirstName = New System.Windows.Forms.TextBox()
        Me.txtGroup = New System.Windows.Forms.TextBox()
        Me.cboEmployeeID = New System.Windows.Forms.ComboBox()
        Me.lblTestValue = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtLogonLastName = New System.Windows.Forms.TextBox()
        Me.txtActive = New System.Windows.Forms.TextBox()
        Me.txtHomeOffice = New System.Windows.Forms.TextBox()
        Me.txtType = New System.Windows.Forms.TextBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 7)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(429, 41)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Please Type Your Employee ID and Last Name"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtEmployeeID
        '
        Me.txtEmployeeID.AcceptsReturn = True
        Me.txtEmployeeID.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmployeeID.Location = New System.Drawing.Point(165, 64)
        Me.txtEmployeeID.Margin = New System.Windows.Forms.Padding(2)
        Me.txtEmployeeID.Name = "txtEmployeeID"
        Me.txtEmployeeID.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtEmployeeID.Size = New System.Drawing.Size(106, 26)
        Me.txtEmployeeID.TabIndex = 0
        '
        'btnLogon
        '
        Me.btnLogon.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogon.Location = New System.Drawing.Point(295, 55)
        Me.btnLogon.Margin = New System.Windows.Forms.Padding(2)
        Me.btnLogon.Name = "btnLogon"
        Me.btnLogon.Size = New System.Drawing.Size(143, 42)
        Me.btnLogon.TabIndex = 2
        Me.btnLogon.Text = "Logon"
        Me.btnLogon.UseVisualStyleBackColor = True
        '
        'txtLastName
        '
        Me.txtLastName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLastName.Location = New System.Drawing.Point(165, 185)
        Me.txtLastName.Margin = New System.Windows.Forms.Padding(2)
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Size = New System.Drawing.Size(134, 26)
        Me.txtLastName.TabIndex = 3
        Me.txtLastName.Visible = False
        '
        'txtFirstName
        '
        Me.txtFirstName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFirstName.Location = New System.Drawing.Point(165, 214)
        Me.txtFirstName.Margin = New System.Windows.Forms.Padding(2)
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(134, 26)
        Me.txtFirstName.TabIndex = 4
        Me.txtFirstName.Visible = False
        '
        'txtGroup
        '
        Me.txtGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGroup.Location = New System.Drawing.Point(13, 214)
        Me.txtGroup.Margin = New System.Windows.Forms.Padding(2)
        Me.txtGroup.Name = "txtGroup"
        Me.txtGroup.Size = New System.Drawing.Size(125, 26)
        Me.txtGroup.TabIndex = 5
        Me.txtGroup.Visible = False
        '
        'cboEmployeeID
        '
        Me.cboEmployeeID.FormattingEnabled = True
        Me.cboEmployeeID.Location = New System.Drawing.Point(13, 185)
        Me.cboEmployeeID.Margin = New System.Windows.Forms.Padding(2)
        Me.cboEmployeeID.Name = "cboEmployeeID"
        Me.cboEmployeeID.Size = New System.Drawing.Size(125, 21)
        Me.cboEmployeeID.TabIndex = 6
        Me.cboEmployeeID.Visible = False
        '
        'lblTestValue
        '
        Me.lblTestValue.Location = New System.Drawing.Point(363, 185)
        Me.lblTestValue.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblTestValue.Name = "lblTestValue"
        Me.lblTestValue.Size = New System.Drawing.Size(75, 19)
        Me.lblTestValue.TabIndex = 7
        Me.lblTestValue.Text = "Label2"
        Me.lblTestValue.Visible = False
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(11, 63)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(137, 26)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Employee ID"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(11, 112)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(137, 26)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Last Name"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtLogonLastName
        '
        Me.txtLogonLastName.AcceptsReturn = True
        Me.txtLogonLastName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLogonLastName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLogonLastName.Location = New System.Drawing.Point(165, 113)
        Me.txtLogonLastName.Margin = New System.Windows.Forms.Padding(2)
        Me.txtLogonLastName.Name = "txtLogonLastName"
        Me.txtLogonLastName.Size = New System.Drawing.Size(106, 26)
        Me.txtLogonLastName.TabIndex = 1
        '
        'txtActive
        '
        Me.txtActive.AcceptsReturn = True
        Me.txtActive.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtActive.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtActive.Location = New System.Drawing.Point(11, 244)
        Me.txtActive.Margin = New System.Windows.Forms.Padding(2)
        Me.txtActive.Name = "txtActive"
        Me.txtActive.Size = New System.Drawing.Size(106, 26)
        Me.txtActive.TabIndex = 11
        Me.txtActive.Visible = False
        '
        'txtHomeOffice
        '
        Me.txtHomeOffice.AcceptsReturn = True
        Me.txtHomeOffice.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtHomeOffice.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHomeOffice.Location = New System.Drawing.Point(165, 242)
        Me.txtHomeOffice.Margin = New System.Windows.Forms.Padding(2)
        Me.txtHomeOffice.Name = "txtHomeOffice"
        Me.txtHomeOffice.Size = New System.Drawing.Size(106, 26)
        Me.txtHomeOffice.TabIndex = 12
        Me.txtHomeOffice.Visible = False
        '
        'txtType
        '
        Me.txtType.AcceptsReturn = True
        Me.txtType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtType.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtType.Location = New System.Drawing.Point(332, 242)
        Me.txtType.Margin = New System.Windows.Forms.Padding(2)
        Me.txtType.Name = "txtType"
        Me.txtType.Size = New System.Drawing.Size(106, 26)
        Me.txtType.TabIndex = 13
        Me.txtType.Visible = False
        '
        'btnClose
        '
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Location = New System.Drawing.Point(295, 104)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(2)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(143, 42)
        Me.btnClose.TabIndex = 14
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'Logon
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(461, 279)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.txtType)
        Me.Controls.Add(Me.txtHomeOffice)
        Me.Controls.Add(Me.txtActive)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtLogonLastName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblTestValue)
        Me.Controls.Add(Me.cboEmployeeID)
        Me.Controls.Add(Me.txtGroup)
        Me.Controls.Add(Me.txtFirstName)
        Me.Controls.Add(Me.txtLastName)
        Me.Controls.Add(Me.btnLogon)
        Me.Controls.Add(Me.txtEmployeeID)
        Me.Controls.Add(Me.Label1)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "Logon"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Logon"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtEmployeeID As System.Windows.Forms.TextBox
    Friend WithEvents btnLogon As System.Windows.Forms.Button
    Friend WithEvents txtLastName As System.Windows.Forms.TextBox
    Friend WithEvents txtFirstName As System.Windows.Forms.TextBox
    Friend WithEvents txtGroup As System.Windows.Forms.TextBox
    Friend WithEvents cboEmployeeID As System.Windows.Forms.ComboBox
    Friend WithEvents lblTestValue As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtLogonLastName As System.Windows.Forms.TextBox
    Friend WithEvents txtActive As System.Windows.Forms.TextBox
    Friend WithEvents txtHomeOffice As System.Windows.Forms.TextBox
    Friend WithEvents txtType As System.Windows.Forms.TextBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
End Class
