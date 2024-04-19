<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FindDuplicateProjects
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
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtMSRNumber = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtSupplyingWarehouse = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboInternalProjectID = New System.Windows.Forms.ComboBox()
        Me.txtTWCControlNumber = New System.Windows.Forms.TextBox()
        Me.txtProjectName = New System.Windows.Forms.TextBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnRemoveProjects = New System.Windows.Forms.Button()
        Me.dgvSearchResults = New System.Windows.Forms.DataGridView()
        CType(Me.dgvSearchResults, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(108, 225)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(145, 23)
        Me.Label12.TabIndex = 408
        Me.Label12.Text = "MSR Number"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtMSRNumber
        '
        Me.txtMSRNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMSRNumber.Location = New System.Drawing.Point(258, 225)
        Me.txtMSRNumber.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtMSRNumber.Name = "txtMSRNumber"
        Me.txtMSRNumber.Size = New System.Drawing.Size(192, 22)
        Me.txtMSRNumber.TabIndex = 393
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(18, 188)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(235, 23)
        Me.Label8.TabIndex = 404
        Me.Label8.Text = "Supplying Warehouse"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtSupplyingWarehouse
        '
        Me.txtSupplyingWarehouse.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSupplyingWarehouse.Location = New System.Drawing.Point(258, 188)
        Me.txtSupplyingWarehouse.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtSupplyingWarehouse.Name = "txtSupplyingWarehouse"
        Me.txtSupplyingWarehouse.Size = New System.Drawing.Size(192, 22)
        Me.txtSupplyingWarehouse.TabIndex = 389
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(12, 18)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(1094, 57)
        Me.Label11.TabIndex = 398
        Me.Label11.Text = "Find and Remove Duplicate Projects"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(32, 155)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(221, 23)
        Me.Label7.TabIndex = 397
        Me.Label7.Text = "TWC Control Number"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(108, 126)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(145, 23)
        Me.Label3.TabIndex = 396
        Me.Label3.Text = "Project Name"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(40, 91)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(213, 23)
        Me.Label2.TabIndex = 395
        Me.Label2.Text = "Internal Project ID"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboInternalProjectID
        '
        Me.cboInternalProjectID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboInternalProjectID.FormattingEnabled = True
        Me.cboInternalProjectID.Location = New System.Drawing.Point(258, 92)
        Me.cboInternalProjectID.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cboInternalProjectID.Name = "cboInternalProjectID"
        Me.cboInternalProjectID.Size = New System.Drawing.Size(192, 24)
        Me.cboInternalProjectID.TabIndex = 394
        '
        'txtTWCControlNumber
        '
        Me.txtTWCControlNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTWCControlNumber.Location = New System.Drawing.Point(258, 156)
        Me.txtTWCControlNumber.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtTWCControlNumber.Name = "txtTWCControlNumber"
        Me.txtTWCControlNumber.Size = New System.Drawing.Size(192, 22)
        Me.txtTWCControlNumber.TabIndex = 383
        '
        'txtProjectName
        '
        Me.txtProjectName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProjectName.Location = New System.Drawing.Point(258, 128)
        Me.txtProjectName.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtProjectName.Name = "txtProjectName"
        Me.txtProjectName.Size = New System.Drawing.Size(192, 22)
        Me.txtProjectName.TabIndex = 382
        '
        'btnClose
        '
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Location = New System.Drawing.Point(930, 280)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(176, 63)
        Me.btnClose.TabIndex = 409
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnRemoveProjects
        '
        Me.btnRemoveProjects.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemoveProjects.Location = New System.Drawing.Point(930, 213)
        Me.btnRemoveProjects.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnRemoveProjects.Name = "btnRemoveProjects"
        Me.btnRemoveProjects.Size = New System.Drawing.Size(176, 63)
        Me.btnRemoveProjects.TabIndex = 410
        Me.btnRemoveProjects.Text = "Remove Projects"
        Me.btnRemoveProjects.UseVisualStyleBackColor = True
        '
        'dgvSearchResults
        '
        Me.dgvSearchResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSearchResults.Location = New System.Drawing.Point(12, 91)
        Me.dgvSearchResults.Name = "dgvSearchResults"
        Me.dgvSearchResults.RowTemplate.Height = 24
        Me.dgvSearchResults.Size = New System.Drawing.Size(912, 402)
        Me.dgvSearchResults.TabIndex = 411
        '
        'FindDuplicateProjects
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1118, 505)
        Me.ControlBox = False
        Me.Controls.Add(Me.dgvSearchResults)
        Me.Controls.Add(Me.btnRemoveProjects)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtMSRNumber)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtSupplyingWarehouse)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboInternalProjectID)
        Me.Controls.Add(Me.txtTWCControlNumber)
        Me.Controls.Add(Me.txtProjectName)
        Me.Name = "FindDuplicateProjects"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FindDuplicateProjects"
        CType(Me.dgvSearchResults, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtMSRNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtSupplyingWarehouse As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboInternalProjectID As System.Windows.Forms.ComboBox
    Friend WithEvents txtTWCControlNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtProjectName As System.Windows.Forms.TextBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnRemoveProjects As System.Windows.Forms.Button
    Friend WithEvents dgvSearchResults As System.Windows.Forms.DataGridView
End Class
