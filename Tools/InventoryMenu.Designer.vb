<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InventoryMenu
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
        Me.btnMainMenu = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnCableMenu = New System.Windows.Forms.Button()
        Me.btnFindPartNumber = New System.Windows.Forms.Button()
        Me.btnInventoryLookup = New System.Windows.Forms.Button()
        Me.btnNewOrders = New System.Windows.Forms.Button()
        Me.btnGeneratePickList = New System.Windows.Forms.Button()
        Me.btnFillPickList = New System.Windows.Forms.Button()
        Me.btnReceiveOrder = New System.Windows.Forms.Button()
        Me.btnEmployeeInventory = New System.Windows.Forms.Button()
        Me.btnTruckInventory = New System.Windows.Forms.Button()
        Me.btnReportPartsUsage = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(487, 42)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Inventory Menu"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnMainMenu
        '
        Me.btnMainMenu.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMainMenu.Location = New System.Drawing.Point(175, 240)
        Me.btnMainMenu.Margin = New System.Windows.Forms.Padding(2)
        Me.btnMainMenu.Name = "btnMainMenu"
        Me.btnMainMenu.Size = New System.Drawing.Size(160, 51)
        Me.btnMainMenu.TabIndex = 10
        Me.btnMainMenu.Text = "Main Menu"
        Me.btnMainMenu.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Location = New System.Drawing.Point(339, 240)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(2)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(160, 51)
        Me.btnClose.TabIndex = 11
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnCableMenu
        '
        Me.btnCableMenu.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCableMenu.Location = New System.Drawing.Point(11, 73)
        Me.btnCableMenu.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCableMenu.Name = "btnCableMenu"
        Me.btnCableMenu.Size = New System.Drawing.Size(160, 51)
        Me.btnCableMenu.TabIndex = 0
        Me.btnCableMenu.Text = "Cable Menu"
        Me.btnCableMenu.UseVisualStyleBackColor = True
        '
        'btnFindPartNumber
        '
        Me.btnFindPartNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFindPartNumber.Location = New System.Drawing.Point(175, 73)
        Me.btnFindPartNumber.Margin = New System.Windows.Forms.Padding(2)
        Me.btnFindPartNumber.Name = "btnFindPartNumber"
        Me.btnFindPartNumber.Size = New System.Drawing.Size(160, 51)
        Me.btnFindPartNumber.TabIndex = 1
        Me.btnFindPartNumber.Text = "Find Part Number"
        Me.btnFindPartNumber.UseVisualStyleBackColor = True
        '
        'btnInventoryLookup
        '
        Me.btnInventoryLookup.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnInventoryLookup.Location = New System.Drawing.Point(339, 73)
        Me.btnInventoryLookup.Margin = New System.Windows.Forms.Padding(2)
        Me.btnInventoryLookup.Name = "btnInventoryLookup"
        Me.btnInventoryLookup.Size = New System.Drawing.Size(160, 51)
        Me.btnInventoryLookup.TabIndex = 2
        Me.btnInventoryLookup.Text = "Inventory Look Up"
        Me.btnInventoryLookup.UseVisualStyleBackColor = True
        '
        'btnNewOrders
        '
        Me.btnNewOrders.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNewOrders.Location = New System.Drawing.Point(11, 130)
        Me.btnNewOrders.Margin = New System.Windows.Forms.Padding(2)
        Me.btnNewOrders.Name = "btnNewOrders"
        Me.btnNewOrders.Size = New System.Drawing.Size(160, 51)
        Me.btnNewOrders.TabIndex = 3
        Me.btnNewOrders.Text = "New Orders"
        Me.btnNewOrders.UseVisualStyleBackColor = True
        '
        'btnGeneratePickList
        '
        Me.btnGeneratePickList.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGeneratePickList.Location = New System.Drawing.Point(175, 130)
        Me.btnGeneratePickList.Margin = New System.Windows.Forms.Padding(2)
        Me.btnGeneratePickList.Name = "btnGeneratePickList"
        Me.btnGeneratePickList.Size = New System.Drawing.Size(160, 51)
        Me.btnGeneratePickList.TabIndex = 4
        Me.btnGeneratePickList.Text = "Generate Pick List"
        Me.btnGeneratePickList.UseVisualStyleBackColor = True
        '
        'btnFillPickList
        '
        Me.btnFillPickList.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFillPickList.Location = New System.Drawing.Point(339, 130)
        Me.btnFillPickList.Margin = New System.Windows.Forms.Padding(2)
        Me.btnFillPickList.Name = "btnFillPickList"
        Me.btnFillPickList.Size = New System.Drawing.Size(160, 51)
        Me.btnFillPickList.TabIndex = 5
        Me.btnFillPickList.Text = "Fill Pick List"
        Me.btnFillPickList.UseVisualStyleBackColor = True
        '
        'btnReceiveOrder
        '
        Me.btnReceiveOrder.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReceiveOrder.Location = New System.Drawing.Point(11, 185)
        Me.btnReceiveOrder.Margin = New System.Windows.Forms.Padding(2)
        Me.btnReceiveOrder.Name = "btnReceiveOrder"
        Me.btnReceiveOrder.Size = New System.Drawing.Size(160, 51)
        Me.btnReceiveOrder.TabIndex = 6
        Me.btnReceiveOrder.Text = "Receive Order"
        Me.btnReceiveOrder.UseVisualStyleBackColor = True
        '
        'btnEmployeeInventory
        '
        Me.btnEmployeeInventory.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEmployeeInventory.Location = New System.Drawing.Point(175, 185)
        Me.btnEmployeeInventory.Margin = New System.Windows.Forms.Padding(2)
        Me.btnEmployeeInventory.Name = "btnEmployeeInventory"
        Me.btnEmployeeInventory.Size = New System.Drawing.Size(160, 51)
        Me.btnEmployeeInventory.TabIndex = 7
        Me.btnEmployeeInventory.Text = "Employee Inventory"
        Me.btnEmployeeInventory.UseVisualStyleBackColor = True
        '
        'btnTruckInventory
        '
        Me.btnTruckInventory.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTruckInventory.Location = New System.Drawing.Point(339, 185)
        Me.btnTruckInventory.Margin = New System.Windows.Forms.Padding(2)
        Me.btnTruckInventory.Name = "btnTruckInventory"
        Me.btnTruckInventory.Size = New System.Drawing.Size(160, 51)
        Me.btnTruckInventory.TabIndex = 8
        Me.btnTruckInventory.Text = "Truck Inventory"
        Me.btnTruckInventory.UseVisualStyleBackColor = True
        '
        'btnReportPartsUsage
        '
        Me.btnReportPartsUsage.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReportPartsUsage.Location = New System.Drawing.Point(11, 240)
        Me.btnReportPartsUsage.Margin = New System.Windows.Forms.Padding(2)
        Me.btnReportPartsUsage.Name = "btnReportPartsUsage"
        Me.btnReportPartsUsage.Size = New System.Drawing.Size(160, 51)
        Me.btnReportPartsUsage.TabIndex = 9
        Me.btnReportPartsUsage.Text = "Report Parts Usage"
        Me.btnReportPartsUsage.UseVisualStyleBackColor = True
        '
        'InventoryMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(519, 323)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnReportPartsUsage)
        Me.Controls.Add(Me.btnTruckInventory)
        Me.Controls.Add(Me.btnEmployeeInventory)
        Me.Controls.Add(Me.btnReceiveOrder)
        Me.Controls.Add(Me.btnFillPickList)
        Me.Controls.Add(Me.btnGeneratePickList)
        Me.Controls.Add(Me.btnNewOrders)
        Me.Controls.Add(Me.btnInventoryLookup)
        Me.Controls.Add(Me.btnFindPartNumber)
        Me.Controls.Add(Me.btnCableMenu)
        Me.Controls.Add(Me.btnMainMenu)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.Label1)
        Me.Name = "InventoryMenu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Inventory Menu"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnMainMenu As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnCableMenu As System.Windows.Forms.Button
    Friend WithEvents btnFindPartNumber As System.Windows.Forms.Button
    Friend WithEvents btnInventoryLookup As System.Windows.Forms.Button
    Friend WithEvents btnNewOrders As System.Windows.Forms.Button
    Friend WithEvents btnGeneratePickList As System.Windows.Forms.Button
    Friend WithEvents btnFillPickList As System.Windows.Forms.Button
    Friend WithEvents btnReceiveOrder As System.Windows.Forms.Button
    Friend WithEvents btnEmployeeInventory As System.Windows.Forms.Button
    Friend WithEvents btnTruckInventory As System.Windows.Forms.Button
    Friend WithEvents btnReportPartsUsage As System.Windows.Forms.Button
End Class
