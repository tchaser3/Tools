'Title:         Create Vehicle Inspection Work Order
'Date:          10-21-15
'Author:        Terry Holmes

'Description:   This is used to create a new work order from a daily inspection

Option Strict On

Public Class CreateVehicleInspectionWorkOrder

    'Setting up global variables
    Private TheVehicleRepairsDataSet As VehicleRepairsDataSet
    Private TheVehicleRepairsDataTier As VehicleRepairsDataTier
    Private WithEvents TheVehicleRepairsBindingSource As BindingSource

    Private TheVendorsDataSet As VendorsDataSet
    Private TheVendorsDataTier As VendorDataTier
    Private WithEvents TheVendorsBindingSource As BindingSource

    Private addingBoolean As Boolean = False
    Private editingBoolean As Boolean = False
    Private previousSelectedIndex As Integer

    Dim TheInputDataValidation As New InputDataValidation

    Dim mintCounter As Integer
    Dim mintUpperLimit As Integer
    Dim mintSelectedIndex() As Integer

    Private Sub CreateVehicleInspectionWorkOrder_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'setting local variables
        Dim intVendorNumberOfRecords As Integer

        'Try catch to load up the controls
        Try

            'Binding the Vendor Information
            TheVendorsDataTier = New VendorDataTier
            TheVendorsDataSet = TheVendorsDataTier.GetVendorsinformation
            TheVendorsBindingSource = New BindingSource

            'Setting up the binding source
            With TheVendorsBindingSource
                .DataSource = TheVendorsDataSet
                .DataMember = "vendors"
                .MoveFirst()
                .MoveLast()
            End With

            'Setting up the combo box
            With cboVendorName
                .DataSource = TheVendorsBindingSource
                .DisplayMember = "VendorName"
                .DataBindings.Add("text", TheVendorsBindingSource, "VendorName", False, DataSourceUpdateMode.Never)
            End With

            'binding the remaining vendor control
            txtVendorTableID.DataBindings.Add("text", TheVendorsBindingSource, "VendorID")

            'setting size of array
            intVendorNumberOfRecords = cboVendorName.Items.Count - 1
            ReDim mintSelectedIndex(intVendorNumberOfRecords)

            'MakeVendorControlsVisable(False)

            'Setting up the work order controls and binding
            TheVehicleRepairsDataTier = New VehicleRepairsDataTier
            TheVehicleRepairsDataSet = TheVehicleRepairsDataTier.GetVehicleRepairsInformation
            TheVehicleRepairsBindingSource = New BindingSource

            'Setting up the binding source
            With TheVehicleRepairsBindingSource
                .DataSource = TheVehicleRepairsDataSet
                .DataMember = "vehiclerepairs"
                .MoveFirst()
                .MoveLast()
            End With

            'Setting up the combo box
            With cboTransactionID
                .DataSource = TheVehicleRepairsBindingSource
                .DisplayMember = "TransactionID"
                .DataBindings.Add("text", TheVehicleRepairsBindingSource, "TransactionID", False, DataSourceUpdateMode.Never)
            End With

            'Binding the Rest of the Controls
            txtWorkOrderDateReported.DataBindings.Add("text", TheVehicleRepairsBindingSource, "DateReported")
            txtWorkOrderNotes.DataBindings.Add("text", TheVehicleRepairsBindingSource, "Notes")
            txtWorkOrderOdometer.DataBindings.Add("text", TheVehicleRepairsBindingSource, "Odometer")
            txtWorkOrderProblemDescription.DataBindings.Add("text", TheVehicleRepairsBindingSource, "ProblemDescription")
            txtWorkOrderStatus.DataBindings.Add("text", TheVehicleRepairsBindingSource, "Status")
            txtWorkOrderVehicleID.DataBindings.Add("text", TheVehicleRepairsBindingSource, "VehicleID")
            txtWorkOrderVendorID.DataBindings.Add("text", TheVehicleRepairsBindingSource, "VendorID")

            'Creating the New Record
            AddNewRecord()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub SetComboBoxBinding()

        'This will set the binding
        With cboTransactionID
            If (addingBoolean Or editingBoolean) Then
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
                .DropDownStyle = ComboBoxStyle.Simple
            Else
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
                .DropDownStyle = ComboBoxStyle.Simple
            End If
        End With

    End Sub
    Private Sub AddNewRecord()

        'setting local variables
        Dim datTodayDate As Date = Date.Now
        Dim strTodayDate As String

        'setting up to add the records
        With TheVehicleRepairsBindingSource
            .EndEdit()
            .AddNew()
        End With

        'setting up the conditions
        addingBoolean = True
        SetComboBoxBinding()

        'Fillup controls
        VehicleRepairID.Show()
        cboTransactionID.Text = CStr(Logon.mintCreatedTransactionID)
        txtWorkOrderVehicleID.Text = CStr(Logon.mintVehicleID)
        txtWorkOrderOdometer.Text = CStr(Logon.mintOdometerTransferred)
        txtWorkOrderProblemDescription.Text = Logon.mstrNotes
        strTodayDate = CStr(datTodayDate)
        txtWorkOrderDateReported.Text = strTodayDate
        txtWorkOrderStatus.Text = "OPEN"

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        'This will save the record
        'setting up local variables
        Dim strValueForValidation As String
        Dim blnFatalError As Boolean = False
        Dim blnThereIsAProblem As Boolean = False
        Dim strErrorMessage As String = ""

        'setting up for data validation
        strValueForValidation = txtWorkOrderProblemDescription.Text
        blnFatalError = TheInputDataValidation.VerifyTextData(strValueForValidation)
        If blnFatalError = True Then
            blnThereIsAProblem = True
            strErrorMessage = strErrorMessage + "The Problem Description was not Entered" + vbNewLine
        End If
        strValueForValidation = txtWorkOrderNotes.Text
        blnFatalError = TheInputDataValidation.VerifyTextData(strValueForValidation)
        If blnFatalError = True Then
            blnThereIsAProblem = True
            strErrorMessage = strErrorMessage + "The Notes Were Not Entered" + vbNewLine
        End If
        strValueForValidation = txtWorkOrderVendorID.Text
        blnFatalError = TheInputDataValidation.VerifyIntegerData(strValueForValidation)
        If blnFatalError = True Then
            blnThereIsAProblem = True
            strErrorMessage = strErrorMessage + "The Vendor ID entered is not an Integer" + vbNewLine
        End If
        If blnThereIsAProblem = True Then
            MessageBox.Show(strErrorMessage, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Logon.mstrDownForRepair = "YES"
        UpdateVehicleRepairStatus.Show()

        Logon.mblnWorkOrderCreated = True

        'saving record
        Try
            TheVehicleRepairsBindingSource.EndEdit()
            TheVehicleRepairsDataTier.UpdateDB(TheVehicleRepairsDataSet)
            addingBoolean = False
            editingBoolean = False
            SetComboBoxBinding()

            'calling sub-routine
            VehicleInventorySheets.FinishInformationSave()

            'closing this form
            Me.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnSelectVendor_Click(sender As Object, e As EventArgs) Handles btnSelectVendor.Click

        'this will add a vendor the form
        txtWorkOrderVendorID.Text = txtVendorTableID.Text

    End Sub
End Class