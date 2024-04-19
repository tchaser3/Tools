<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CreateVehiclePreventiveMaintenanceWorkOrder
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
        Me.btnClose = New System.Windows.Forms.Button()
        Me.cboTransactionID = New System.Windows.Forms.ComboBox()
        Me.txtVehicleID = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtOdometer = New System.Windows.Forms.TextBox()
        Me.txtProblemDescription = New System.Windows.Forms.TextBox()
        Me.txtVendorID = New System.Windows.Forms.TextBox()
        Me.txtDateReported = New System.Windows.Forms.TextBox()
        Me.txtDateRepairBegan = New System.Windows.Forms.TextBox()
        Me.txtDateRepairComplete = New System.Windows.Forms.TextBox()
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.txtNotes = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtDateReturned = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtVendorTableID = New System.Windows.Forms.TextBox()
        Me.cboVendorName = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtEnterVendorName = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.btnSearchForVendor = New System.Windows.Forms.Button()
        Me.btnSelectVendor = New System.Windows.Forms.Button()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Location = New System.Drawing.Point(348, 475)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(2)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(182, 73)
        Me.btnClose.TabIndex = 358
        Me.btnClose.Text = "Close and Save"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'cboTransactionID
        '
        Me.cboTransactionID.FormattingEnabled = True
        Me.cboTransactionID.Location = New System.Drawing.Point(155, 89)
        Me.cboTransactionID.Name = "cboTransactionID"
        Me.cboTransactionID.Size = New System.Drawing.Size(121, 21)
        Me.cboTransactionID.TabIndex = 359
        '
        'txtVehicleID
        '
        Me.txtVehicleID.Location = New System.Drawing.Point(155, 120)
        Me.txtVehicleID.Name = "txtVehicleID"
        Me.txtVehicleID.ReadOnly = True
        Me.txtVehicleID.Size = New System.Drawing.Size(121, 20)
        Me.txtVehicleID.TabIndex = 360
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(14, 87)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(135, 23)
        Me.Label1.TabIndex = 361
        Me.Label1.Text = "Work Order Number"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtOdometer
        '
        Me.txtOdometer.Location = New System.Drawing.Point(155, 149)
        Me.txtOdometer.Name = "txtOdometer"
        Me.txtOdometer.ReadOnly = True
        Me.txtOdometer.Size = New System.Drawing.Size(121, 20)
        Me.txtOdometer.TabIndex = 362
        '
        'txtProblemDescription
        '
        Me.txtProblemDescription.Location = New System.Drawing.Point(155, 178)
        Me.txtProblemDescription.Multiline = True
        Me.txtProblemDescription.Name = "txtProblemDescription"
        Me.txtProblemDescription.ReadOnly = True
        Me.txtProblemDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtProblemDescription.Size = New System.Drawing.Size(121, 77)
        Me.txtProblemDescription.TabIndex = 363
        '
        'txtVendorID
        '
        Me.txtVendorID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtVendorID.Location = New System.Drawing.Point(155, 266)
        Me.txtVendorID.Name = "txtVendorID"
        Me.txtVendorID.ReadOnly = True
        Me.txtVendorID.Size = New System.Drawing.Size(121, 20)
        Me.txtVendorID.TabIndex = 364
        '
        'txtDateReported
        '
        Me.txtDateReported.Location = New System.Drawing.Point(155, 295)
        Me.txtDateReported.Name = "txtDateReported"
        Me.txtDateReported.ReadOnly = True
        Me.txtDateReported.Size = New System.Drawing.Size(121, 20)
        Me.txtDateReported.TabIndex = 365
        '
        'txtDateRepairBegan
        '
        Me.txtDateRepairBegan.Location = New System.Drawing.Point(155, 324)
        Me.txtDateRepairBegan.Name = "txtDateRepairBegan"
        Me.txtDateRepairBegan.ReadOnly = True
        Me.txtDateRepairBegan.Size = New System.Drawing.Size(121, 20)
        Me.txtDateRepairBegan.TabIndex = 366
        '
        'txtDateRepairComplete
        '
        Me.txtDateRepairComplete.Location = New System.Drawing.Point(155, 353)
        Me.txtDateRepairComplete.Name = "txtDateRepairComplete"
        Me.txtDateRepairComplete.ReadOnly = True
        Me.txtDateRepairComplete.Size = New System.Drawing.Size(121, 20)
        Me.txtDateRepairComplete.TabIndex = 367
        '
        'txtStatus
        '
        Me.txtStatus.Location = New System.Drawing.Point(155, 407)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.ReadOnly = True
        Me.txtStatus.Size = New System.Drawing.Size(121, 20)
        Me.txtStatus.TabIndex = 368
        '
        'txtNotes
        '
        Me.txtNotes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNotes.Location = New System.Drawing.Point(155, 437)
        Me.txtNotes.Multiline = True
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtNotes.Size = New System.Drawing.Size(121, 84)
        Me.txtNotes.TabIndex = 369
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(14, 118)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(135, 23)
        Me.Label2.TabIndex = 370
        Me.Label2.Text = "Vehicle ID"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(14, 147)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(135, 23)
        Me.Label3.TabIndex = 371
        Me.Label3.Text = "Odometer"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(14, 204)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(135, 23)
        Me.Label4.TabIndex = 372
        Me.Label4.Text = "Problem Description"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(14, 264)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(135, 23)
        Me.Label5.TabIndex = 373
        Me.Label5.Text = "Vendor ID"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(14, 293)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(135, 23)
        Me.Label6.TabIndex = 374
        Me.Label6.Text = "Date Reported"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(14, 322)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(135, 23)
        Me.Label7.TabIndex = 375
        Me.Label7.Text = "Date Repair Began"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(4, 351)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(145, 23)
        Me.Label8.TabIndex = 376
        Me.Label8.Text = "Date Repair Complete"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(14, 405)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(135, 23)
        Me.Label9.TabIndex = 377
        Me.Label9.Text = "Status"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(14, 456)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(135, 23)
        Me.Label10.TabIndex = 378
        Me.Label10.Text = "Notes"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(12, 9)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(567, 60)
        Me.Label11.TabIndex = 379
        Me.Label11.Text = "Create Preventive Maintenance Work Order  Use This Form Only For Preventive Maint" & _
            "enance"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(4, 377)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(145, 23)
        Me.Label12.TabIndex = 381
        Me.Label12.Text = "Date Returned"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtDateReturned
        '
        Me.txtDateReturned.Location = New System.Drawing.Point(155, 379)
        Me.txtDateReturned.Name = "txtDateReturned"
        Me.txtDateReturned.ReadOnly = True
        Me.txtDateReturned.Size = New System.Drawing.Size(121, 20)
        Me.txtDateReturned.TabIndex = 380
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(317, 169)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(105, 23)
        Me.Label13.TabIndex = 385
        Me.Label13.Text = "Vendor ID"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(314, 138)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(108, 23)
        Me.Label14.TabIndex = 384
        Me.Label14.Text = "Vendor Name"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtVendorTableID
        '
        Me.txtVendorTableID.Location = New System.Drawing.Point(428, 171)
        Me.txtVendorTableID.Name = "txtVendorTableID"
        Me.txtVendorTableID.ReadOnly = True
        Me.txtVendorTableID.Size = New System.Drawing.Size(121, 20)
        Me.txtVendorTableID.TabIndex = 383
        '
        'cboVendorName
        '
        Me.cboVendorName.FormattingEnabled = True
        Me.cboVendorName.Location = New System.Drawing.Point(428, 140)
        Me.cboVendorName.Name = "cboVendorName"
        Me.cboVendorName.Size = New System.Drawing.Size(121, 21)
        Me.cboVendorName.TabIndex = 382
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(322, 79)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(227, 47)
        Me.Label15.TabIndex = 386
        Me.Label15.Text = "Vendor Information"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(322, 204)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(227, 36)
        Me.Label16.TabIndex = 387
        Me.Label16.Text = "Search For Vendor"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtEnterVendorName
        '
        Me.txtEnterVendorName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEnterVendorName.Location = New System.Drawing.Point(377, 245)
        Me.txtEnterVendorName.Name = "txtEnterVendorName"
        Me.txtEnterVendorName.Size = New System.Drawing.Size(121, 20)
        Me.txtEnterVendorName.TabIndex = 388
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(327, 277)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(222, 23)
        Me.Label17.TabIndex = 389
        Me.Label17.Text = "Enter Vendor Name"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnSearchForVendor
        '
        Me.btnSearchForVendor.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearchForVendor.Location = New System.Drawing.Point(384, 311)
        Me.btnSearchForVendor.Margin = New System.Windows.Forms.Padding(2)
        Me.btnSearchForVendor.Name = "btnSearchForVendor"
        Me.btnSearchForVendor.Size = New System.Drawing.Size(107, 42)
        Me.btnSearchForVendor.TabIndex = 390
        Me.btnSearchForVendor.Text = "Search"
        Me.btnSearchForVendor.UseVisualStyleBackColor = True
        '
        'btnSelectVendor
        '
        Me.btnSelectVendor.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSelectVendor.Location = New System.Drawing.Point(370, 409)
        Me.btnSelectVendor.Margin = New System.Windows.Forms.Padding(2)
        Me.btnSelectVendor.Name = "btnSelectVendor"
        Me.btnSelectVendor.Size = New System.Drawing.Size(130, 42)
        Me.btnSelectVendor.TabIndex = 391
        Me.btnSelectVendor.Text = "Select Vendor"
        Me.btnSelectVendor.UseVisualStyleBackColor = True
        '
        'btnNext
        '
        Me.btnNext.Enabled = False
        Me.btnNext.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNext.Location = New System.Drawing.Point(446, 362)
        Me.btnNext.Margin = New System.Windows.Forms.Padding(2)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(66, 31)
        Me.btnNext.TabIndex = 392
        Me.btnNext.Text = "Next"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnBack
        '
        Me.btnBack.Enabled = False
        Me.btnBack.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBack.Location = New System.Drawing.Point(356, 362)
        Me.btnBack.Margin = New System.Windows.Forms.Padding(2)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(66, 31)
        Me.btnBack.TabIndex = 393
        Me.btnBack.Text = "Back"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'CreateVehiclePreventiveMaintenanceWorkOrder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(591, 571)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.btnSelectVendor)
        Me.Controls.Add(Me.btnSearchForVendor)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.txtEnterVendorName)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtVendorTableID)
        Me.Controls.Add(Me.cboVendorName)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtDateReturned)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtNotes)
        Me.Controls.Add(Me.txtStatus)
        Me.Controls.Add(Me.txtDateRepairComplete)
        Me.Controls.Add(Me.txtDateRepairBegan)
        Me.Controls.Add(Me.txtDateReported)
        Me.Controls.Add(Me.txtVendorID)
        Me.Controls.Add(Me.txtProblemDescription)
        Me.Controls.Add(Me.txtOdometer)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtVehicleID)
        Me.Controls.Add(Me.cboTransactionID)
        Me.Controls.Add(Me.btnClose)
        Me.Name = "CreateVehiclePreventiveMaintenanceWorkOrder"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CreateVehiclePreventiveMaintenanceWorkOrder"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents cboTransactionID As System.Windows.Forms.ComboBox
    Friend WithEvents txtVehicleID As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtOdometer As System.Windows.Forms.TextBox
    Friend WithEvents txtProblemDescription As System.Windows.Forms.TextBox
    Friend WithEvents txtVendorID As System.Windows.Forms.TextBox
    Friend WithEvents txtDateReported As System.Windows.Forms.TextBox
    Friend WithEvents txtDateRepairBegan As System.Windows.Forms.TextBox
    Friend WithEvents txtDateRepairComplete As System.Windows.Forms.TextBox
    Friend WithEvents txtStatus As System.Windows.Forms.TextBox
    Friend WithEvents txtNotes As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtDateReturned As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtVendorTableID As System.Windows.Forms.TextBox
    Friend WithEvents cboVendorName As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtEnterVendorName As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents btnSearchForVendor As System.Windows.Forms.Button
    Friend WithEvents btnSelectVendor As System.Windows.Forms.Button
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents btnBack As System.Windows.Forms.Button
End Class
