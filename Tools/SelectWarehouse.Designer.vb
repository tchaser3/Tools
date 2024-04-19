<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectWarehouse
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtWarehouseLastName = New System.Windows.Forms.TextBox()
        Me.txtWarehouseFirstName = New System.Windows.Forms.TextBox()
        Me.cboWarehouseID = New System.Windows.Forms.ComboBox()
        Me.btnWarehouseSelect = New System.Windows.Forms.Button()
        Me.btnWarehouseNext = New System.Windows.Forms.Button()
        Me.btnWarehouseBack = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(337, 39)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Select Parts Location"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 78)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 23)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Warehouse"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 111)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(120, 23)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Location"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtWarehouseLastName
        '
        Me.txtWarehouseLastName.Location = New System.Drawing.Point(151, 78)
        Me.txtWarehouseLastName.Name = "txtWarehouseLastName"
        Me.txtWarehouseLastName.Size = New System.Drawing.Size(142, 20)
        Me.txtWarehouseLastName.TabIndex = 3
        '
        'txtWarehouseFirstName
        '
        Me.txtWarehouseFirstName.Location = New System.Drawing.Point(151, 111)
        Me.txtWarehouseFirstName.Name = "txtWarehouseFirstName"
        Me.txtWarehouseFirstName.Size = New System.Drawing.Size(142, 20)
        Me.txtWarehouseFirstName.TabIndex = 4
        '
        'cboWarehouseID
        '
        Me.cboWarehouseID.FormattingEnabled = True
        Me.cboWarehouseID.Location = New System.Drawing.Point(151, 51)
        Me.cboWarehouseID.Name = "cboWarehouseID"
        Me.cboWarehouseID.Size = New System.Drawing.Size(142, 21)
        Me.cboWarehouseID.TabIndex = 5
        Me.cboWarehouseID.Visible = False
        '
        'btnWarehouseSelect
        '
        Me.btnWarehouseSelect.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnWarehouseSelect.Location = New System.Drawing.Point(86, 166)
        Me.btnWarehouseSelect.Margin = New System.Windows.Forms.Padding(2)
        Me.btnWarehouseSelect.Name = "btnWarehouseSelect"
        Me.btnWarehouseSelect.Size = New System.Drawing.Size(75, 31)
        Me.btnWarehouseSelect.TabIndex = 529
        Me.btnWarehouseSelect.Text = "Select"
        Me.btnWarehouseSelect.UseVisualStyleBackColor = True
        '
        'btnWarehouseNext
        '
        Me.btnWarehouseNext.Enabled = False
        Me.btnWarehouseNext.Location = New System.Drawing.Point(197, 138)
        Me.btnWarehouseNext.Name = "btnWarehouseNext"
        Me.btnWarehouseNext.Size = New System.Drawing.Size(75, 23)
        Me.btnWarehouseNext.TabIndex = 528
        Me.btnWarehouseNext.Text = "Next"
        Me.btnWarehouseNext.UseVisualStyleBackColor = True
        '
        'btnWarehouseBack
        '
        Me.btnWarehouseBack.Enabled = False
        Me.btnWarehouseBack.Location = New System.Drawing.Point(86, 138)
        Me.btnWarehouseBack.Name = "btnWarehouseBack"
        Me.btnWarehouseBack.Size = New System.Drawing.Size(75, 23)
        Me.btnWarehouseBack.TabIndex = 527
        Me.btnWarehouseBack.Text = "Back"
        Me.btnWarehouseBack.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(197, 166)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 31)
        Me.btnCancel.TabIndex = 530
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'SelectWarehouse
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(352, 218)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnWarehouseSelect)
        Me.Controls.Add(Me.btnWarehouseNext)
        Me.Controls.Add(Me.btnWarehouseBack)
        Me.Controls.Add(Me.cboWarehouseID)
        Me.Controls.Add(Me.txtWarehouseFirstName)
        Me.Controls.Add(Me.txtWarehouseLastName)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "SelectWarehouse"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SelectWarehouse"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtWarehouseLastName As System.Windows.Forms.TextBox
    Friend WithEvents txtWarehouseFirstName As System.Windows.Forms.TextBox
    Friend WithEvents cboWarehouseID As System.Windows.Forms.ComboBox
    Friend WithEvents btnWarehouseSelect As System.Windows.Forms.Button
    Friend WithEvents btnWarehouseNext As System.Windows.Forms.Button
    Friend WithEvents btnWarehouseBack As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
End Class
