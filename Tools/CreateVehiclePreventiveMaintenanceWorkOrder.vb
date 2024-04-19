'Title:         Create Preventive Maintenance Work Order
'Date:          11-7-14
'Author:        Terry Holmes

'Description:   This form will allow the user to create a preventive maintenance work order

Option Strict On

Public Class CreateVehiclePreventiveMaintenanceWorkOrder

    'Setting up global variables
    Private TheVehicleRepairsDataSet As VehicleRepairsDataSet
    Private TheVehicleRepairsDateTier As VehicleRepairsDataTier
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
    Dim mintSelectedIndex(1000) As Integer

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

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        'Setting local variables
        Dim strValueForValidation As String
        Dim blnFatalError As Boolean

        'Performing Data Validation
        strValueForValidation = txtVendorID.Text
        blnFatalError = TheInputDataValidation.VerifyTextData(strValueForValidation)

        If blnFatalError = True Then
            MessageBox.Show("The Vendor Information Was Not Complete", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Logon.mintWorkOrderNumber = CInt(cboTransactionID.Text)

        'Saving the record
        Try
            TheVehicleRepairsBindingSource.EndEdit()
            TheVehicleRepairsDateTier.UpdateDB(TheVehicleRepairsDataSet)
            editingBoolean = False
            addingBoolean = False
            SetComboBoxBinding()
            cboTransactionID.SelectedIndex = previousSelectedIndex
            VehiclePreventiveMaintenanceUpdate.Show()
            PrintWorkOrderOption.Show()
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    Private Sub CreateVehiclePreventiveMaintenanceWorkOrder_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Setting local variables
        Dim strDateForDataEntry As String

        'This will load up the controls and also create a work order
        Try

            'Loading up the global variables
            TheVehicleRepairsDateTier = New VehicleRepairsDataTier
            TheVehicleRepairsDataSet = TheVehicleRepairsDateTier.GetVehicleRepairsInformation
            TheVehicleRepairsBindingSource = New BindingSource

            TheVendorsDataTier = New VendorDataTier
            TheVendorsDataSet = TheVendorsDataTier.GetVendorsinformation
            TheVendorsBindingSource = New BindingSource

            'Setting up the binding source
            With TheVehicleRepairsBindingSource
                .DataSource = TheVehicleRepairsDataSet
                .DataMember = "vehiclerepairs"
                .MoveFirst()
                .MoveLast()
            End With

            'Setting up the vendors binding source
            With TheVendorsBindingSource
                .DataSource = TheVendorsDataSet
                .DataMember = "vendors"
                .MoveFirst()
                .MoveLast()
            End With

            'Setting
            With cboTransactionID
                .DataSource = TheVehicleRepairsBindingSource
                .DisplayMember = "TransactionID"
                .DataBindings.Add("text", TheVehicleRepairsBindingSource, "TransactionID", False, DataSourceUpdateMode.Never)
            End With

            'Setting up the Vendor Combo Box
            With cboVendorName
                .DataSource = TheVendorsBindingSource
                .DisplayMember = "VendorName"
                .DataBindings.Add("text", TheVendorsBindingSource, "VendorName", False, DataSourceUpdateMode.Never)
            End With

            'Binding the rest of the controls
            txtDateRepairBegan.DataBindings.Add("Text", TheVehicleRepairsBindingSource, "DateRepairBegan")
            txtDateReturned.DataBindings.Add("text", TheVehicleRepairsBindingSource, "DateVehicleReturnedService")
            txtDateRepairComplete.DataBindings.Add("text", TheVehicleRepairsBindingSource, "DateRepairComplete")
            txtProblemDescription.DataBindings.Add("text", TheVehicleRepairsBindingSource, "ProblemDescription")
            txtDateReported.DataBindings.Add("text", TheVehicleRepairsBindingSource, "DateReported")
            txtNotes.DataBindings.Add("text", TheVehicleRepairsBindingSource, "Notes")
            txtOdometer.DataBindings.Add("text", TheVehicleRepairsBindingSource, "Odometer")
            txtStatus.DataBindings.Add("text", TheVehicleRepairsBindingSource, "Status")
            txtVehicleID.DataBindings.Add("text", TheVehicleRepairsBindingSource, "VehicleID")
            txtVendorID.DataBindings.Add("text", TheVehicleRepairsBindingSource, "VendorID")

            txtVendorTableID.DataBindings.Add("text", TheVendorsBindingSource, "VendorID")

            'Creating a New Record
            With TheVehicleRepairsBindingSource
                .EndEdit()
                .AddNew()
            End With

            'Setting up variables
            addingBoolean = True
            SetComboBoxBinding()
            cboTransactionID.Focus()
            If cboTransactionID.SelectedIndex <> -1 Then
                previousSelectedIndex = cboTransactionID.Items.Count - 1
            Else
                previousSelectedIndex = 0
            End If

            'Creating the work order number
            VehicleRepairID.Show()
            cboTransactionID.Text = CStr(Logon.mintCreatedTransactionID)
            txtVehicleID.Text = CStr(Logon.mintVehicleID)
            txtOdometer.Text = CStr(Logon.mintOdometerTransferred)
            txtProblemDescription.Text = "PREVENTIVE MAINTENANCE PERFORMED"
            strDateForDataEntry = CStr(Logon.mdatStartingDate)
            txtDateRepairBegan.Text = strDateForDataEntry
            txtDateRepairComplete.Text = strDateForDataEntry
            txtDateReported.Text = strDateForDataEntry
            txtDateReturned.Text = strDateForDataEntry
            txtStatus.Text = "AWAITING INVOICE"



        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click

        'This will increment the counter
        mintCounter += 1
        cboVendorName.SelectedIndex = mintSelectedIndex(mintCounter)

        btnBack.Enabled = True

        If mintCounter = mintUpperLimit Then
            btnNext.Enabled = False
        End If

    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click

        'This will decrement the counter
        mintCounter -= 1
        cboVendorName.SelectedIndex = mintSelectedIndex(mintCounter)

        btnNext.Enabled = True

        If mintCounter = 0 Then
            btnBack.Enabled = False
        End If

    End Sub

    Private Sub btnSelectVendor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectVendor.Click

        'This will put the Vendor ID in the text box
        txtVendorID.Text = txtVendorTableID.Text

    End Sub

    Private Sub btnSearchForVendor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchForVendor.Click

        'This will search for a specific vendor by name
        Dim intNumberOfRecords As Integer
        Dim intCounter As Integer
        Dim intFirstCounter As Integer
        Dim intSecondCounter As Integer
        Dim strNameForSearch As String
        Dim strNameFromTable As String
        Dim intCharacterCountForSearch As Integer
        Dim intCharacterCountFromTable As Integer
        Dim blnFatalError As Boolean = False
        Dim blnItemNotFound As Boolean = True
        Dim strKeyWordFromTable As String = ""
        Dim chaKeyWordFromTable() As Char

        'Setting up for search
        intNumberOfRecords = cboVendorName.Items.Count - 1
        strNameForSearch = txtEnterVendorName.Text
        mintCounter = 0
        btnNext.Enabled = False
        btnBack.Enabled = False

        'Beginning Loop
        For intCounter = 0 To intNumberOfRecords

            'Setting the value from the com
            cboVendorName.SelectedIndex = intCounter
            strNameFromTable = cboVendorName.Text
            intCharacterCountFromTable = strNameFromTable.Length - 1
            intCharacterCountForSearch = strNameForSearch.Length - 1

            'If statement for the search string to be less than or equal to the table
            If intCharacterCountForSearch <= intCharacterCountFromTable Then

                'Checking to see if the strings match
                If intCharacterCountForSearch = intCharacterCountFromTable Then
                    If strNameForSearch = strNameFromTable Then
                        mintSelectedIndex(mintCounter) = intCounter
                        mintCounter += 1
                        blnItemNotFound = False
                    End If
                Else

                    'Beginning Key Word Search
                    chaKeyWordFromTable = strNameFromTable.ToCharArray

                    'Beginning first loop
                    For intFirstCounter = 0 To intCharacterCountFromTable

                        'Beginning second loop
                        For intSecondCounter = intFirstCounter To intCharacterCountForSearch

                            'Setting up the string for search
                            strKeyWordFromTable = strKeyWordFromTable + chaKeyWordFromTable(intSecondCounter)

                        Next

                        'Checking to see if there needs to be another loop
                        If intCharacterCountForSearch < intCharacterCountFromTable Then
                            intCharacterCountForSearch += 1
                        End If

                        'Checking to see if the key word is found
                        If strKeyWordFromTable = strNameForSearch Then
                            mintSelectedIndex(mintCounter) = intCounter
                            mintCounter += 1
                            blnItemNotFound = False
                        End If

                        strKeyWordFromTable = ""

                    Next
                End If
            End If
        Next

        If blnItemNotFound = True Then
            MessageBox.Show("Item Entered Not Found", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        'Setting up the combo box and navigation controls
        mintUpperLimit = mintCounter - 1
        mintCounter = 0
        cboVendorName.SelectedIndex = mintSelectedIndex(0)

        If mintUpperLimit > 0 Then
            btnNext.Enabled = True
        End If

    End Sub
End Class