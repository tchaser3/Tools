<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CheckForMatchingProject
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
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboInternalProjectID = New System.Windows.Forms.ComboBox()
        Me.txtTWCControlNumber = New System.Windows.Forms.TextBox()
        Me.txtProjectName = New System.Windows.Forms.TextBox()
        Me.btnNo = New System.Windows.Forms.Button()
        Me.btnYes = New System.Windows.Forms.Button()
        Me.lblEmployeeMessage = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.dgvSearchResults = New System.Windows.Forms.DataGridView()
        Me.txtMSRNumber = New System.Windows.Forms.TextBox()
        CType(Me.dgvSearchResults, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(95, 156)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(221, 23)
        Me.Label7.TabIndex = 361
        Me.Label7.Text = "TWC Control Number"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(171, 128)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(145, 23)
        Me.Label3.TabIndex = 360
        Me.Label3.Text = "Project Name"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(103, 92)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(213, 23)
        Me.Label2.TabIndex = 359
        Me.Label2.Text = "Internal Project ID"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboInternalProjectID
        '
        Me.cboInternalProjectID.FormattingEnabled = True
        Me.cboInternalProjectID.Location = New System.Drawing.Point(321, 94)
        Me.cboInternalProjectID.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cboInternalProjectID.Name = "cboInternalProjectID"
        Me.cboInternalProjectID.Size = New System.Drawing.Size(192, 24)
        Me.cboInternalProjectID.TabIndex = 358
        '
        'txtTWCControlNumber
        '
        Me.txtTWCControlNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTWCControlNumber.Location = New System.Drawing.Point(321, 158)
        Me.txtTWCControlNumber.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtTWCControlNumber.Name = "txtTWCControlNumber"
        Me.txtTWCControlNumber.ReadOnly = True
        Me.txtTWCControlNumber.Size = New System.Drawing.Size(192, 22)
        Me.txtTWCControlNumber.TabIndex = 350
        '
        'txtProjectName
        '
        Me.txtProjectName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProjectName.Location = New System.Drawing.Point(321, 129)
        Me.txtProjectName.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtProjectName.Name = "txtProjectName"
        Me.txtProjectName.ReadOnly = True
        Me.txtProjectName.Size = New System.Drawing.Size(192, 22)
        Me.txtProjectName.TabIndex = 349
        '
        'btnNo
        '
        Me.btnNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNo.Location = New System.Drawing.Point(426, 350)
        Me.btnNo.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnNo.Name = "btnNo"
        Me.btnNo.Size = New System.Drawing.Size(223, 71)
        Me.btnNo.TabIndex = 371
        Me.btnNo.Text = "No"
        Me.btnNo.UseVisualStyleBackColor = True
        '
        'btnYes
        '
        Me.btnYes.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnYes.Location = New System.Drawing.Point(12, 350)
        Me.btnYes.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnYes.Name = "btnYes"
        Me.btnYes.Size = New System.Drawing.Size(223, 71)
        Me.btnYes.TabIndex = 370
        Me.btnYes.Text = "Yes"
        Me.btnYes.UseVisualStyleBackColor = True
        '
        'lblEmployeeMessage
        '
        Me.lblEmployeeMessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmployeeMessage.Location = New System.Drawing.Point(16, 244)
        Me.lblEmployeeMessage.Name = "lblEmployeeMessage"
        Me.lblEmployeeMessage.Size = New System.Drawing.Size(633, 95)
        Me.lblEmployeeMessage.TabIndex = 369
        Me.lblEmployeeMessage.Text = "The Project Entered Has Some of the Same Information as Another Project.  Do You " & _
    "Want to Continue, Press Yes To Continue, No to Return"
        Me.lblEmployeeMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(15, 11)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(634, 50)
        Me.Label10.TabIndex = 372
        Me.Label10.Text = "Project Name and Number Check"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dgvSearchResults
        '
        Me.dgvSearchResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSearchResults.Location = New System.Drawing.Point(12, 64)
        Me.dgvSearchResults.Name = "dgvSearchResults"
        Me.dgvSearchResults.RowTemplate.Height = 24
        Me.dgvSearchResults.Size = New System.Drawing.Size(637, 150)
        Me.dgvSearchResults.TabIndex = 373
        '
        'txtMSRNumber
        '
        Me.txtMSRNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMSRNumber.Location = New System.Drawing.Point(321, 184)
        Me.txtMSRNumber.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtMSRNumber.Name = "txtMSRNumber"
        Me.txtMSRNumber.ReadOnly = True
        Me.txtMSRNumber.Size = New System.Drawing.Size(192, 22)
        Me.txtMSRNumber.TabIndex = 374
        '
        'CheckForMatchingProject
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(661, 463)
        Me.ControlBox = False
        Me.Controls.Add(Me.dgvSearchResults)
        Me.Controls.Add(Me.txtMSRNumber)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.btnNo)
        Me.Controls.Add(Me.btnYes)
        Me.Controls.Add(Me.lblEmployeeMessage)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboInternalProjectID)
        Me.Controls.Add(Me.txtTWCControlNumber)
        Me.Controls.Add(Me.txtProjectName)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "CheckForMatchingProject"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Project Name and Number Check"
        CType(Me.dgvSearchResults, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboInternalProjectID As System.Windows.Forms.ComboBox
    Friend WithEvents txtTWCControlNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtProjectName As System.Windows.Forms.TextBox
    Friend WithEvents btnNo As System.Windows.Forms.Button
    Friend WithEvents btnYes As System.Windows.Forms.Button
    Friend WithEvents lblEmployeeMessage As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents dgvSearchResults As System.Windows.Forms.DataGridView
    Friend WithEvents txtMSRNumber As System.Windows.Forms.TextBox
End Class
