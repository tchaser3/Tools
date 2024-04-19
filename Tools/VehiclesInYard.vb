'Title:         Vehicles In Yard
'Date:          10-27-14
'Author:        Terry Holmes

'Description:   This form is used for letting the user know about the vehicles currently in the yard

Option Strict On

Public Class VehiclesInYard

    'Setting Modular Variables
    Private TheVehicleInYardDataSet As VehicleInYardDataSet
    Private TheVehicleInYardDataTier As VehicleInYardDataTier
    Private WithEvents TheVehicleInYardBindingSource As BindingSource

    Dim TheInputDataValidation As New InputDataValidation

    Private addingBoolean As Boolean = False
    Private editingBoolean As Boolean = False
    Private previousSelectedIndex As Integer
    Dim mintNumuberOfRecords As Integer

    Dim LogDateTime As Date = DateAndTime.Now
    Dim strLogDateTime As String

    Dim mintCreatedTransactionID As Integer
    Friend mstrDoneDataEntry As String

    'Setting local variables
    Dim strValueForValidation As String
    Dim blnFatalError As Boolean
    Dim intNumberOfRecords As Integer
    Dim mblnFatalError As Boolean

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        'Closes the Program
        CloseTheProgram.ShowDialog()

    End Sub

    Private Sub btnMainMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMainMenu.Click
        MainMenu.Show()
        Me.Close()
    End Sub

    Private Sub btnInspectionMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInspectionMenu.Click
        InspectionsMenu.Show()
        Me.Close()
    End Sub
    Private Sub SetForPreLoad()

        'Placing the Binding Source to Add a record
        With TheVehicleInYardBindingSource
            .EndEdit()
            .AddNew()
        End With

        'Calling routines and setting the values
        addingBoolean = True
        setComboBoxBinding()
        cboTransactionID.Focus()
        setControlsReadOnly(False)
        setButtonsForEdit()
        If cboTransactionID.SelectedIndex <> -1 Then
            previousSelectedIndex = cboTransactionID.Items.Count - 1
        Else
            previousSelectedIndex = 0
        End If

        txtAreYouDoneWithDataEntry.Text = "NO"


        'Setting up fields with auto-data to avoid having the user do it.
        mintNumuberOfRecords = cboTransactionID.Items.Count
        intNumberOfRecords = mintNumuberOfRecords + 1000
        mintCreatedTransactionID = intNumberOfRecords

        Logon.mintCreatedTransactionID = mintCreatedTransactionID

        VehicleSheetTurnInIDCreation.Show()

        mintCreatedTransactionID = CInt(Logon.mintCreatedTransactionID)

        cboTransactionID.Text = CStr(mintCreatedTransactionID)
        txtVehicleInYard.Text = "YES"
        strLogDateTime = CStr(Logon.mdatDateForDataEntry)
        txtDate.Text = strLogDateTime

    End Sub
    Private Sub SaveData()

        Dim strErrorMessage As String = ""

        'Clearing and setting initial Data Validation Values
        mblnFatalError = False

        strValueForValidation = txtBJCNumber.Text
        mblnFatalError = TheInputDataValidation.VerifyIntegerData(strValueForValidation)
        If mblnFatalError = False Then
            mblnFatalError = TheInputDataValidation.VerifyVehicleNumber(strValueForValidation)
        End If

        If mblnFatalError = False Then
            strValueForValidation = txtDate.Text
            strErrorMessage = "Date Information is not a Date"
            mblnFatalError = TheInputDataValidation.VerifyStartingEndingDatesAsDates(strValueForValidation)
            If blnFatalError = False Then
                strValueForValidation = txtVehicleInYard.Text
                strErrorMessage = "Vehicle In the Yard is not a Yes or No"
                mblnFatalError = TheInputDataValidation.VerifyYesNoData(strValueForValidation)
                If blnFatalError = False Then
                    strValueForValidation = txtAreYouDoneWithDataEntry.Text
                    strErrorMessage = "Are You Done with Data Entry is not a Yes or No"
                    mblnFatalError = TheInputDataValidation.VerifyYesNoData(strValueForValidation)
                End If
            End If
        End If

        'Putting out error message if data validation fails
        If (mblnFatalError = True) Then
            MessageBox.Show(strErrorMessage, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        'Updating Database
        Try
            TheVehicleInYardBindingSource.EndEdit()
            TheVehicleInYardDataTier.UpdateVehicleInYardDB(TheVehicleInYardDataSet)


        Catch ex As Exception
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        'This will add or save a record to the data set
        'Setting up if statements
        If btnAdd.Text = "Add" Then  'This routine will run if the user is adding a trailer

            SetForPreLoad()

        Else

            SaveData()
            If mblnFatalError = True Then
                Exit Sub
            End If
            mstrDoneDataEntry = txtAreYouDoneWithDataEntry.Text
            txtBJCNumber.Focus()
            If mstrDoneDataEntry = "YES" Then

                addingBoolean = False
                editingBoolean = False
                setControlsReadOnly(True)
                ResetButtonAfterEditing()
                setComboBoxBinding()
                cboTransactionID.SelectedIndex = previousSelectedIndex

            Else

                SetForPreLoad()
                txtBJCNumber.Text = ""

            End If

            txtBJCNumber.Focus()

        End If
    End Sub

    Private Sub setButtonsForEdit()

        'Sets the buttons up for editing and saving a record
        btnAdd.Text = "Save"
        btnMainMenu.Enabled = False

    End Sub
    Private Sub ResetButtonAfterEditing()

        'Setting the buttons up for adding records
        btnAdd.Text = "Add"
        btnMainMenu.Enabled = True

    End Sub
    Private Sub setControlsReadOnly(ByVal valueBoolean As Boolean)

        'This will set controls either to read only or not
        With Me

            txtDate.ReadOnly = valueBoolean
            txtBJCNumber.ReadOnly = valueBoolean
            txtVehicleInYard.ReadOnly = valueBoolean
            txtAreYouDoneWithDataEntry.ReadOnly = valueBoolean
        End With

    End Sub

    Private Sub txtBJCNumber_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBJCNumber.KeyDown

        If e.KeyCode = Keys.Enter Then

            btnAdd.PerformClick()

        End If
    End Sub

    Private Sub txtDate_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDate.KeyDown

        If e.KeyCode = Keys.Enter Then

            btnAdd.PerformClick()

        End If

    End Sub
    Private Sub btnChangeDate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangeDate.Click

        Logon.mstrFormForDataEntry = "VEHICLESINYARD"
        DataEntryDate.Show()
        Me.Close()

    End Sub

    Private Sub VehiclesInYard_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'This routine runs when the form is loaded

        'This Try Catch will catch any exceptions that are through during the routine
        Try

            'This will bind the controls to the data source
            TheVehicleInYardDataTier = New VehicleInYardDataTier
            TheVehicleInYardDataSet = TheVehicleInYardDataTier.GetVehicleInYardInformation
            TheVehicleInYardBindingSource = New BindingSource

            'Setting up the binding for the Combobox
            With TheVehicleInYardBindingSource
                .DataSource = TheVehicleInYardDataSet
                .DataMember = "vehicleinyard"
                .MoveFirst()
                .MoveLast()
            End With

            'Setting up the Table Relationships and binding for the table.
            With cboTransactionID
                .DataSource = TheVehicleInYardBindingSource
                .DisplayMember = "TransactionID"
                .DataBindings.Add("text", TheVehicleInYardBindingSource, "TransactionID", False, DataSourceUpdateMode.Never)
            End With

            'Setting up the data bindings for the textboxes
            txtBJCNumber.DataBindings.Add("text", TheVehicleInYardBindingSource, "BJCNumber")
            txtDate.DataBindings.Add("text", TheVehicleInYardBindingSource, "Date")
            txtVehicleInYard.DataBindings.Add("text", TheVehicleInYardBindingSource, "InYard")

            btnAdd.PerformClick()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub setComboBoxBinding()

        'Sets the Combobox Binding
        With Me.cboTransactionID
            If (addingBoolean Or editingBoolean) Then
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.OnValidation
                .DropDownStyle = ComboBoxStyle.Simple
            Else
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.Never
                .DropDownStyle = ComboBoxStyle.DropDownList
            End If
        End With

    End Sub
End Class