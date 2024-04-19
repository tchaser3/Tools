'Title:         Vehicle Auto Sign in
'Date:          10-9-15
'Author:        Terry Holmes

'Description:   This form will auto sign in the vehicles each day

Option Strict On

Public Class AutoSignIn

    'setting global variables
    Dim mstrErrorMessage As String
    Dim mdatTodaysDate As Date
    Dim mdatTableDate As Date

    Private TheAutoSignInDateDataTier As AutoSignInDateDataTier
    Private TheAutoSignInDateDataSet As AutoSignInDateDataSet
    Private WithEvents TheAutoSignInDateBindingSource As BindingSource

    Private TheEmployeeDataSet As EmployeeDataSet
    Private TheEmployeeDataTier As EmployeeDataTier
    Private WithEvents TheEmployeeBindingSource As BindingSource

    Private TheVehiclesDataSet As VehiclesDataSet
    Private TheVehiclesDataTier As VehiclesDataTier
    Private WithEvents TheVehiclesBindingSource As BindingSource

    Dim TheDateSearchClass As New DateSearchClass
    Dim mblnRunRoutine As Boolean

    'creating data structure for warehouses
    Structure Warehouses
        Dim mintEmployeeID As Integer
        Dim mstrLastName As String
        Dim mstrFirstName As String
    End Structure

    'setting variables for structure
    Dim structWarehouses() As Warehouses
    Dim mintWarehouseCounter As Integer
    Dim mintWarehouseUpperLimit As Integer

    Private Function SetAutoSignInDataBindings() As Boolean

        'setting local variables
        Dim blnFatalError As Boolean = False
        Dim datTodaysDate As Date = Date.Now
        Dim datTableDate As Date

        'try catch for exceptions
        Try

            'setting up the controls
            TheAutoSignInDateDataTier = New AutoSignInDateDataTier
            TheAutoSignInDateDataSet = TheAutoSignInDateDataTier.GetAutoSignInInformation
            TheAutoSignInDateBindingSource = New BindingSource

            'Setting up the binding source
            With TheAutoSignInDateBindingSource
                .DataSource = TheAutoSignInDateDataSet
                .DataMember = "autosignindate"
                .MoveFirst()
                .MoveLast()
            End With

            'setting up the combo box
            With cboAutoTransactionID
                .DataSource = TheAutoSignInDateBindingSource
                .DisplayMember = "TransactionID"
                .DataBindings.Add("text", TheAutoSignInDateBindingSource, "TransactionID", False, DataSourceUpdateMode.Never)
            End With

            txtAutoDate.DataBindings.Add("text", TheAutoSignInDateBindingSource, "AutoSignInDate")

            'Removing the Time
            mdatTodaysDate = TheDateSearchClass.RemoveTime(datTodaysDate)
            datTableDate = CDate(txtAutoDate.Text)

            mdatTableDate = TheDateSearchClass.RemoveTime(datTableDate)

            If mdatTodaysDate > mdatTableDate Then
                mblnRunRoutine = True
            Else
                mblnRunRoutine = False
            End If

            Return blnFatalError

        Catch ex As Exception

            'Message to user if there is a problem
            mstrErrorMessage = ex.Message
            blnFatalError = True
            Return blnFatalError

        End Try

    End Function
    Private Function UpdateAutoSignInTable() As Boolean

        'setting local variables
        Dim datTodaysDate As Date = Date.Now
        Dim blnFatalError As Boolean = False

        Try

            txtAutoDate.Text = CStr(datTodaysDate)
            TheAutoSignInDateBindingSource.EndEdit()
            TheAutoSignInDateDataTier.UpdateAutoSignInDB(TheAutoSignInDateDataSet)

        Catch ex As Exception

            'output to user
            mstrErrorMessage = ex.Message
            blnFatalError = True
            Return blnFatalError

        End Try
    End Function

    Private Sub AutoSignIn_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'setting up the local variables
        Dim blnFatalError As Boolean

        PleaseWait.Show()
        Logon.mstrLastTransactionSummary = "Ran Automatic Sign In"
        LastTransaction.Show()

        'setting the autosignin data bindings
        blnFatalError = SetAutoSignInDataBindings()

        If mblnRunRoutine = True Then
            If blnFatalError = False Then

                'setting the vehicle databindings
                blnFatalError = SetVehicleDataBindings()

            End If
            If blnFatalError = False Then

                'setting the employee data bindings
                blnFatalError = SetEmployeeDataBindings()

            End If
            If blnFatalError = False Then
                blnFatalError = SignInVehicles()
            End If
        End If

        If blnFatalError = True Then
            PleaseWait.Close()
            MessageBox.Show(mstrErrorMessage, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            UpdateAutoSignInTable()
        End If

        PleaseWait.Close()
        SelectPartsWarehouse.Show()
        Me.Close()

    End Sub
    
    Private Function SignInVehicles() As Boolean

        'This will sign in the vehicles
        'setting local variables
        Dim intVehicleCounter As Integer
        Dim intVehicleNumberOfRecords As Integer
        Dim strHomeOfficeForSearch As String
        Dim strHomeOfficeFromTable As String
        Dim intWarehouseCounter As Integer
        Dim blnFatalError As Boolean = False
        Dim strRemoteVehicle As String
        Dim strVehicleUnderRepair As String
        Dim strActive As String
        Dim strAvailable As String
        Dim datTodayDate As Date = Date.Now
        Dim strLogDateTime As String

        'getting the date
        strLogDateTime = CStr(datTodayDate)

        'try catch for exceptions
        Try

            'getting vehicle count
            intVehicleNumberOfRecords = cboVehicleID.Items.Count - 1

            'Beginning loop
            For intVehicleCounter = 0 To intVehicleNumberOfRecords

                'Incrementing the combo box
                cboVehicleID.SelectedIndex = intVehicleCounter

                'getting variables to decide if the record should be updated.
                strVehicleUnderRepair = txtVehicleDownForMaintenance.Text
                strAvailable = txtAvailable.Text
                strActive = txtActive.Text
                strRemoteVehicle = txtOutOfTown.Text
                strHomeOfficeForSearch = txtHomeOffice.Text

                'beginning if statements
                If strRemoteVehicle = "NO" Then
                    If strActive = "YES" Then
                        If strAvailable = "NO" Then

                            'preforming loop
                            For intWarehouseCounter = 0 To mintWarehouseUpperLimit

                                'getting home office from the structure
                                strHomeOfficeFromTable = structWarehouses(intWarehouseCounter).mstrFirstName

                                If strHomeOfficeForSearch = strHomeOfficeFromTable Then

                                    'Saving information
                                    txtAvailable.Text = "YES"
                                    txtEmployeeID.Text = CStr(structWarehouses(intWarehouseCounter).mintEmployeeID)
                                    Logon.mintBJCNumber = CInt(txtBJCNumber.Text)
                                    Logon.mintVehicleID = CInt(cboVehicleID.Text)
                                    Logon.mintHistoryEmployeeID = structWarehouses(intWarehouseCounter).mintEmployeeID
                                    Logon.mstrNotes = "VEHICLE SIGNED BACK IN"
                                    Logon.mstrLogDateTime = strLogDateTime
                                    Logon.mstrRemoteVehicle = "NO"

                                    AddingVehicleHistory.Show()

                                    TheVehiclesBindingSource.EndEdit()
                                    TheVehiclesDataTier.UpdateDB(TheVehiclesDataSet)

                                End If
                            Next
                        End If
                    End If
                End If
            Next

            'returning value to calling sub-routine
            Return blnFatalError

        Catch ex As Exception

            mstrErrorMessage = ex.Message
            blnFatalError = True

            'returning back to calling sub-routine
            Return blnFatalError

        End Try

    End Function
    Private Function SetEmployeeDataBindings() As Boolean

        Dim blnFatalError As Boolean = False
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim strLastNameForSearch As String
        Dim strLastNameFromTable As String

        'try catch for exceptions
        Try

            'setting data variables
            TheEmployeeDataTier = New EmployeeDataTier
            TheEmployeeDataSet = TheEmployeeDataTier.GetEmployeeInformation
            TheEmployeeBindingSource = New BindingSource

            'setting up the binding source
            With TheEmployeeBindingSource
                .DataSource = TheEmployeeDataSet
                .DataMember = "employees"
                .MoveFirst()
                .MoveLast()
            End With

            'setting up the combo box
            With cboEmployeeID
                .DataSource = TheEmployeeBindingSource
                .DisplayMember = "EmployeeID"
                .DataBindings.Add("Text", TheEmployeeBindingSource, "EmployeeID", False, DataSourceUpdateMode.Never)
            End With

            'setting the rest of the controls
            txtFirstName.DataBindings.Add("text", TheEmployeeBindingSource, "FirstName")
            txtLastName.DataBindings.Add("text", TheEmployeeBindingSource, "LastName")

            'getting ready to load up the structure
            intNumberOfRecords = cboEmployeeID.Items.Count - 1
            ReDim structWarehouses(intNumberOfRecords)
            mintWarehouseCounter = 0
            strLastNameForSearch = "WAREHOUSE"

            'beginning loop
            For intCounter = 0 To intNumberOfRecords

                'incrementing the combo box
                cboEmployeeID.SelectedIndex = intCounter

                'getting the last name
                strLastNameFromTable = txtLastName.Text

                'if statements
                If strLastNameForSearch = strLastNameFromTable Then

                    structWarehouses(mintWarehouseCounter).mintEmployeeID = CInt(cboEmployeeID.Text)
                    structWarehouses(mintWarehouseCounter).mstrFirstName = txtFirstName.Text
                    structWarehouses(mintWarehouseCounter).mstrLastName = txtLastName.Text
                    mintWarehouseCounter += 1

                End If

            Next

            'setting variables
            mintWarehouseUpperLimit = mintWarehouseCounter - 1
            mintWarehouseCounter = 0

            'returning value to the main sub routine
            Return blnFatalError

        Catch ex As Exception

            'message to user if there is a failure
            mstrErrorMessage = ex.Message
            blnFatalError = True

            'returning value to main sub-routine
            Return blnFatalError

        End Try
    End Function
    Private Function SetVehicleDataBindings() As Boolean

        Dim blnFatalError As Boolean = False

        Try

            'setting up the vehicle variables
            TheVehiclesDataTier = New VehiclesDataTier
            TheVehiclesDataSet = TheVehiclesDataTier.GetVehiclesInformation
            TheVehiclesBindingSource = New BindingSource

            'setting up the Binding source
            With TheVehiclesBindingSource
                .DataSource = TheVehiclesDataSet
                .DataMember = "vehicles"
                .MoveFirst()
                .MoveLast()
            End With

            'setting up the combo box
            With cboVehicleID
                .DataSource = TheVehiclesBindingSource
                .DisplayMember = "VehicleID"
                .DataBindings.Add("text", TheVehiclesBindingSource, "VehicleID", False, DataSourceUpdateMode.Never)
            End With

            'Setting up the rest of the controls
            txtActive.DataBindings.Add("text", TheVehiclesBindingSource, "Active")
            txtAvailable.DataBindings.Add("text", TheVehiclesBindingSource, "Available")
            txtBJCNumber.DataBindings.Add("text", TheVehiclesBindingSource, "BJCNumber")
            txtEmployeeID.DataBindings.Add("text", TheVehiclesBindingSource, "EmployeeID")
            txtHomeOffice.DataBindings.Add("text", TheVehiclesBindingSource, "HomeOffice")
            txtOutOfTown.DataBindings.Add("text", TheVehiclesBindingSource, "OutOfTown")
            txtVehicleDownForMaintenance.DataBindings.Add("text", TheVehiclesBindingSource, "DownForRepairs")
            txtDate.DataBindings.Add("text", TheVehiclesBindingSource, "Date")

            'Returning value to calling sub routine
            Return blnFatalError

        Catch ex As Exception

            'Message to user
            mstrErrorMessage = ex.Message
            blnFatalError = True

            'returning value to call sub-routine
            Return blnFatalError

        End Try

    End Function
End Class