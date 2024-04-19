<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VehicleAssignmentChoice
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
        Me.btn1100Series = New System.Windows.Forms.Button()
        Me.btn1200Series = New System.Windows.Forms.Button()
        Me.btn1500Series = New System.Windows.Forms.Button()
        Me.btnVehicleMenu = New System.Windows.Forms.Button()
        Me.btnMainMenu = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 9)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(510, 41)
        Me.Label1.TabIndex = 130
        Me.Label1.Text = "Pick a Vehicle Series"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn1100Series
        '
        Me.btn1100Series.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn1100Series.Location = New System.Drawing.Point(16, 62)
        Me.btn1100Series.Name = "btn1100Series"
        Me.btn1100Series.Size = New System.Drawing.Size(157, 53)
        Me.btn1100Series.TabIndex = 131
        Me.btn1100Series.Text = "Bucket Trucks"
        Me.btn1100Series.UseVisualStyleBackColor = True
        '
        'btn1200Series
        '
        Me.btn1200Series.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn1200Series.Location = New System.Drawing.Point(195, 62)
        Me.btn1200Series.Name = "btn1200Series"
        Me.btn1200Series.Size = New System.Drawing.Size(157, 53)
        Me.btn1200Series.TabIndex = 132
        Me.btn1200Series.Text = "General Purpose Vehicles"
        Me.btn1200Series.UseVisualStyleBackColor = True
        '
        'btn1500Series
        '
        Me.btn1500Series.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn1500Series.Location = New System.Drawing.Point(369, 62)
        Me.btn1500Series.Name = "btn1500Series"
        Me.btn1500Series.Size = New System.Drawing.Size(157, 53)
        Me.btn1500Series.TabIndex = 133
        Me.btn1500Series.Text = "Heavy Duty Vehicles"
        Me.btn1500Series.UseVisualStyleBackColor = True
        '
        'btnVehicleMenu
        '
        Me.btnVehicleMenu.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVehicleMenu.Location = New System.Drawing.Point(16, 131)
        Me.btnVehicleMenu.Name = "btnVehicleMenu"
        Me.btnVehicleMenu.Size = New System.Drawing.Size(157, 53)
        Me.btnVehicleMenu.TabIndex = 134
        Me.btnVehicleMenu.Text = "Vehicle Menu"
        Me.btnVehicleMenu.UseVisualStyleBackColor = True
        '
        'btnMainMenu
        '
        Me.btnMainMenu.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMainMenu.Location = New System.Drawing.Point(195, 131)
        Me.btnMainMenu.Name = "btnMainMenu"
        Me.btnMainMenu.Size = New System.Drawing.Size(157, 53)
        Me.btnMainMenu.TabIndex = 135
        Me.btnMainMenu.Text = "Main Menu"
        Me.btnMainMenu.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Location = New System.Drawing.Point(369, 131)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(157, 53)
        Me.btnClose.TabIndex = 136
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'VehicleAssignmentChoice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(548, 206)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnMainMenu)
        Me.Controls.Add(Me.btnVehicleMenu)
        Me.Controls.Add(Me.btn1500Series)
        Me.Controls.Add(Me.btn1200Series)
        Me.Controls.Add(Me.btn1100Series)
        Me.Controls.Add(Me.Label1)
        Me.Name = "VehicleAssignmentChoice"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "VehicleAssignmentChoice"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn1100Series As System.Windows.Forms.Button
    Friend WithEvents btn1200Series As System.Windows.Forms.Button
    Friend WithEvents btn1500Series As System.Windows.Forms.Button
    Friend WithEvents btnVehicleMenu As System.Windows.Forms.Button
    Friend WithEvents btnMainMenu As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
End Class
