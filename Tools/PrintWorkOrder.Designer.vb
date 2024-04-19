<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PrintWorkOrder
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
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtVehicleNotes = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtVehicleDownForRepairs = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtVehicleActive = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtVehicleBJCNumber = New System.Windows.Forms.TextBox()
        Me.cboVehicleID = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtVendorTableID = New System.Windows.Forms.TextBox()
        Me.cboVendorName = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtWorkOrderNotes = New System.Windows.Forms.TextBox()
        Me.txtWorkOrderStatus = New System.Windows.Forms.TextBox()
        Me.txtWorkOrderDateReported = New System.Windows.Forms.TextBox()
        Me.txtWorkOrderVendorID = New System.Windows.Forms.TextBox()
        Me.txtWorkOrderProblemDescription = New System.Windows.Forms.TextBox()
        Me.txtWorkOrderOdometer = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtWorkOrderVehicleID = New System.Windows.Forms.TextBox()
        Me.cboTransactionID = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtWorkOrderDateRepairBegan = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtWorkOrderDateRepairCompleted = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtWorkOrderDateReturned = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtWorkOrderDateInvoicedReceived = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtWorkOrderDateInvoiceTurnedIn = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtWorkOrderInvoiceNumber = New System.Windows.Forms.TextBox()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.SuspendLayout()
        '
        'Label19
        '
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(47, 396)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(118, 23)
        Me.Label19.TabIndex = 490
        Me.Label19.Text = "Notes"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtVehicleNotes
        '
        Me.txtVehicleNotes.Location = New System.Drawing.Point(171, 398)
        Me.txtVehicleNotes.Name = "txtVehicleNotes"
        Me.txtVehicleNotes.ReadOnly = True
        Me.txtVehicleNotes.Size = New System.Drawing.Size(121, 20)
        Me.txtVehicleNotes.TabIndex = 489
        '
        'Label22
        '
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(403, 59)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(227, 47)
        Me.Label22.TabIndex = 488
        Me.Label22.Text = "Work Order Information"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label21
        '
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(47, 370)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(118, 23)
        Me.Label21.TabIndex = 487
        Me.Label21.Text = "Down For Repairs"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtVehicleDownForRepairs
        '
        Me.txtVehicleDownForRepairs.Location = New System.Drawing.Point(171, 372)
        Me.txtVehicleDownForRepairs.Name = "txtVehicleDownForRepairs"
        Me.txtVehicleDownForRepairs.ReadOnly = True
        Me.txtVehicleDownForRepairs.Size = New System.Drawing.Size(121, 20)
        Me.txtVehicleDownForRepairs.TabIndex = 486
        '
        'Label20
        '
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(60, 342)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(105, 23)
        Me.Label20.TabIndex = 485
        Me.Label20.Text = "Active"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtVehicleActive
        '
        Me.txtVehicleActive.Location = New System.Drawing.Point(171, 344)
        Me.txtVehicleActive.Name = "txtVehicleActive"
        Me.txtVehicleActive.ReadOnly = True
        Me.txtVehicleActive.Size = New System.Drawing.Size(121, 20)
        Me.txtVehicleActive.TabIndex = 484
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(65, 225)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(227, 47)
        Me.Label12.TabIndex = 481
        Me.Label12.Text = "Vendor Information"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(60, 315)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(105, 23)
        Me.Label18.TabIndex = 480
        Me.Label18.Text = "BJC Number"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtVehicleBJCNumber
        '
        Me.txtVehicleBJCNumber.Location = New System.Drawing.Point(171, 317)
        Me.txtVehicleBJCNumber.Name = "txtVehicleBJCNumber"
        Me.txtVehicleBJCNumber.ReadOnly = True
        Me.txtVehicleBJCNumber.Size = New System.Drawing.Size(121, 20)
        Me.txtVehicleBJCNumber.TabIndex = 479
        '
        'cboVehicleID
        '
        Me.cboVehicleID.FormattingEnabled = True
        Me.cboVehicleID.Location = New System.Drawing.Point(171, 286)
        Me.cboVehicleID.Name = "cboVehicleID"
        Me.cboVehicleID.Size = New System.Drawing.Size(121, 21)
        Me.cboVehicleID.TabIndex = 478
        Me.cboVehicleID.Visible = False
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(83, 48)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(227, 47)
        Me.Label15.TabIndex = 475
        Me.Label15.Text = "Vendor Information"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(78, 138)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(105, 23)
        Me.Label13.TabIndex = 474
        Me.Label13.Text = "Vendor ID"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(75, 107)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(108, 23)
        Me.Label14.TabIndex = 473
        Me.Label14.Text = "Vendor Name"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtVendorTableID
        '
        Me.txtVendorTableID.Location = New System.Drawing.Point(189, 140)
        Me.txtVendorTableID.Name = "txtVendorTableID"
        Me.txtVendorTableID.ReadOnly = True
        Me.txtVendorTableID.Size = New System.Drawing.Size(121, 20)
        Me.txtVendorTableID.TabIndex = 472
        '
        'cboVendorName
        '
        Me.cboVendorName.FormattingEnabled = True
        Me.cboVendorName.Location = New System.Drawing.Point(189, 109)
        Me.cboVendorName.Name = "cboVendorName"
        Me.cboVendorName.Size = New System.Drawing.Size(121, 21)
        Me.cboVendorName.TabIndex = 471
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(380, 406)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(135, 23)
        Me.Label10.TabIndex = 470
        Me.Label10.Text = "Notes"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(380, 355)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(135, 23)
        Me.Label9.TabIndex = 469
        Me.Label9.Text = "Status"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(380, 325)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(135, 23)
        Me.Label6.TabIndex = 468
        Me.Label6.Text = "Date Reported"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(380, 296)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(135, 23)
        Me.Label5.TabIndex = 467
        Me.Label5.Text = "Vendor ID"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(380, 236)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(135, 23)
        Me.Label4.TabIndex = 466
        Me.Label4.Text = "Problem Description"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(380, 179)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(135, 23)
        Me.Label3.TabIndex = 465
        Me.Label3.Text = "Odometer"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(380, 150)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(135, 23)
        Me.Label2.TabIndex = 464
        Me.Label2.Text = "Vehicle ID"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtWorkOrderNotes
        '
        Me.txtWorkOrderNotes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtWorkOrderNotes.Location = New System.Drawing.Point(521, 387)
        Me.txtWorkOrderNotes.Multiline = True
        Me.txtWorkOrderNotes.Name = "txtWorkOrderNotes"
        Me.txtWorkOrderNotes.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtWorkOrderNotes.Size = New System.Drawing.Size(121, 84)
        Me.txtWorkOrderNotes.TabIndex = 462
        '
        'txtWorkOrderStatus
        '
        Me.txtWorkOrderStatus.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtWorkOrderStatus.Location = New System.Drawing.Point(521, 357)
        Me.txtWorkOrderStatus.Name = "txtWorkOrderStatus"
        Me.txtWorkOrderStatus.ReadOnly = True
        Me.txtWorkOrderStatus.Size = New System.Drawing.Size(121, 20)
        Me.txtWorkOrderStatus.TabIndex = 461
        '
        'txtWorkOrderDateReported
        '
        Me.txtWorkOrderDateReported.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtWorkOrderDateReported.Location = New System.Drawing.Point(521, 327)
        Me.txtWorkOrderDateReported.Name = "txtWorkOrderDateReported"
        Me.txtWorkOrderDateReported.Size = New System.Drawing.Size(121, 20)
        Me.txtWorkOrderDateReported.TabIndex = 460
        '
        'txtWorkOrderVendorID
        '
        Me.txtWorkOrderVendorID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtWorkOrderVendorID.Location = New System.Drawing.Point(521, 298)
        Me.txtWorkOrderVendorID.Name = "txtWorkOrderVendorID"
        Me.txtWorkOrderVendorID.ReadOnly = True
        Me.txtWorkOrderVendorID.Size = New System.Drawing.Size(121, 20)
        Me.txtWorkOrderVendorID.TabIndex = 459
        '
        'txtWorkOrderProblemDescription
        '
        Me.txtWorkOrderProblemDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtWorkOrderProblemDescription.Location = New System.Drawing.Point(521, 210)
        Me.txtWorkOrderProblemDescription.Multiline = True
        Me.txtWorkOrderProblemDescription.Name = "txtWorkOrderProblemDescription"
        Me.txtWorkOrderProblemDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtWorkOrderProblemDescription.Size = New System.Drawing.Size(121, 77)
        Me.txtWorkOrderProblemDescription.TabIndex = 458
        '
        'txtWorkOrderOdometer
        '
        Me.txtWorkOrderOdometer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtWorkOrderOdometer.Location = New System.Drawing.Point(521, 181)
        Me.txtWorkOrderOdometer.Name = "txtWorkOrderOdometer"
        Me.txtWorkOrderOdometer.Size = New System.Drawing.Size(121, 20)
        Me.txtWorkOrderOdometer.TabIndex = 457
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(380, 119)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(135, 23)
        Me.Label1.TabIndex = 463
        Me.Label1.Text = "Work Order Number"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtWorkOrderVehicleID
        '
        Me.txtWorkOrderVehicleID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtWorkOrderVehicleID.Location = New System.Drawing.Point(521, 152)
        Me.txtWorkOrderVehicleID.Name = "txtWorkOrderVehicleID"
        Me.txtWorkOrderVehicleID.ReadOnly = True
        Me.txtWorkOrderVehicleID.Size = New System.Drawing.Size(121, 20)
        Me.txtWorkOrderVehicleID.TabIndex = 456
        '
        'cboTransactionID
        '
        Me.cboTransactionID.FormattingEnabled = True
        Me.cboTransactionID.Location = New System.Drawing.Point(521, 121)
        Me.cboTransactionID.Name = "cboTransactionID"
        Me.cboTransactionID.Size = New System.Drawing.Size(121, 21)
        Me.cboTransactionID.TabIndex = 455
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(676, 120)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(135, 23)
        Me.Label7.TabIndex = 492
        Me.Label7.Text = "Date Repair Began"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtWorkOrderDateRepairBegan
        '
        Me.txtWorkOrderDateRepairBegan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtWorkOrderDateRepairBegan.Location = New System.Drawing.Point(817, 122)
        Me.txtWorkOrderDateRepairBegan.Name = "txtWorkOrderDateRepairBegan"
        Me.txtWorkOrderDateRepairBegan.Size = New System.Drawing.Size(121, 20)
        Me.txtWorkOrderDateRepairBegan.TabIndex = 491
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(676, 151)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(135, 23)
        Me.Label8.TabIndex = 494
        Me.Label8.Text = "Date Completed"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtWorkOrderDateRepairCompleted
        '
        Me.txtWorkOrderDateRepairCompleted.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtWorkOrderDateRepairCompleted.Location = New System.Drawing.Point(817, 153)
        Me.txtWorkOrderDateRepairCompleted.Name = "txtWorkOrderDateRepairCompleted"
        Me.txtWorkOrderDateRepairCompleted.Size = New System.Drawing.Size(121, 20)
        Me.txtWorkOrderDateRepairCompleted.TabIndex = 493
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(676, 180)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(135, 23)
        Me.Label11.TabIndex = 496
        Me.Label11.Text = "Date Returned"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtWorkOrderDateReturned
        '
        Me.txtWorkOrderDateReturned.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtWorkOrderDateReturned.Location = New System.Drawing.Point(817, 182)
        Me.txtWorkOrderDateReturned.Name = "txtWorkOrderDateReturned"
        Me.txtWorkOrderDateReturned.Size = New System.Drawing.Size(121, 20)
        Me.txtWorkOrderDateReturned.TabIndex = 495
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(648, 208)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(163, 23)
        Me.Label16.TabIndex = 498
        Me.Label16.Text = "Date Invoice Received"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtWorkOrderDateInvoicedReceived
        '
        Me.txtWorkOrderDateInvoicedReceived.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtWorkOrderDateInvoicedReceived.Location = New System.Drawing.Point(817, 210)
        Me.txtWorkOrderDateInvoicedReceived.Name = "txtWorkOrderDateInvoicedReceived"
        Me.txtWorkOrderDateInvoicedReceived.Size = New System.Drawing.Size(121, 20)
        Me.txtWorkOrderDateInvoicedReceived.TabIndex = 497
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(665, 237)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(146, 23)
        Me.Label17.TabIndex = 500
        Me.Label17.Text = "Date Invoice Turned In"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtWorkOrderDateInvoiceTurnedIn
        '
        Me.txtWorkOrderDateInvoiceTurnedIn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtWorkOrderDateInvoiceTurnedIn.Location = New System.Drawing.Point(817, 239)
        Me.txtWorkOrderDateInvoiceTurnedIn.Name = "txtWorkOrderDateInvoiceTurnedIn"
        Me.txtWorkOrderDateInvoiceTurnedIn.Size = New System.Drawing.Size(121, 20)
        Me.txtWorkOrderDateInvoiceTurnedIn.TabIndex = 499
        '
        'Label23
        '
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(676, 265)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(135, 23)
        Me.Label23.TabIndex = 502
        Me.Label23.Text = "Invoice Number"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtWorkOrderInvoiceNumber
        '
        Me.txtWorkOrderInvoiceNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtWorkOrderInvoiceNumber.Location = New System.Drawing.Point(817, 267)
        Me.txtWorkOrderInvoiceNumber.Name = "txtWorkOrderInvoiceNumber"
        Me.txtWorkOrderInvoiceNumber.Size = New System.Drawing.Size(121, 20)
        Me.txtWorkOrderInvoiceNumber.TabIndex = 501
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'PrintDocument1
        '
        '
        'PrintWorkOrder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1001, 495)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.txtWorkOrderInvoiceNumber)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.txtWorkOrderDateInvoiceTurnedIn)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.txtWorkOrderDateInvoicedReceived)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtWorkOrderDateReturned)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtWorkOrderDateRepairCompleted)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtWorkOrderDateRepairBegan)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.txtVehicleNotes)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.txtVehicleDownForRepairs)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.txtVehicleActive)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.txtVehicleBJCNumber)
        Me.Controls.Add(Me.cboVehicleID)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtVendorTableID)
        Me.Controls.Add(Me.cboVendorName)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtWorkOrderNotes)
        Me.Controls.Add(Me.txtWorkOrderStatus)
        Me.Controls.Add(Me.txtWorkOrderDateReported)
        Me.Controls.Add(Me.txtWorkOrderVendorID)
        Me.Controls.Add(Me.txtWorkOrderProblemDescription)
        Me.Controls.Add(Me.txtWorkOrderOdometer)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtWorkOrderVehicleID)
        Me.Controls.Add(Me.cboTransactionID)
        Me.Name = "PrintWorkOrder"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PrintWorkOrder"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtVehicleNotes As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtVehicleDownForRepairs As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtVehicleActive As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtVehicleBJCNumber As System.Windows.Forms.TextBox
    Friend WithEvents cboVehicleID As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtVendorTableID As System.Windows.Forms.TextBox
    Friend WithEvents cboVendorName As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtWorkOrderNotes As System.Windows.Forms.TextBox
    Friend WithEvents txtWorkOrderStatus As System.Windows.Forms.TextBox
    Friend WithEvents txtWorkOrderDateReported As System.Windows.Forms.TextBox
    Friend WithEvents txtWorkOrderVendorID As System.Windows.Forms.TextBox
    Friend WithEvents txtWorkOrderProblemDescription As System.Windows.Forms.TextBox
    Friend WithEvents txtWorkOrderOdometer As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtWorkOrderVehicleID As System.Windows.Forms.TextBox
    Friend WithEvents cboTransactionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtWorkOrderDateRepairBegan As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtWorkOrderDateRepairCompleted As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtWorkOrderDateReturned As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtWorkOrderDateInvoicedReceived As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtWorkOrderDateInvoiceTurnedIn As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtWorkOrderInvoiceNumber As System.Windows.Forms.TextBox
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
End Class
