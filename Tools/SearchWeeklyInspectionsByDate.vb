'Title:         View Weekly Inspection Log
'Date:          8/21/13
'Author:        Terry Holmes

'Description:  This Form is used to view the Weekly Inspection Log by date search

Option Strict On

Public Class SearchWeeklyInspectionsByDate

    'Setting Modular Variables
    Private TheEmployeeDataSet As EmployeeDataSet
    Private TheEmployeeDataTier As EmployeeDataTier
    Private WithEvents TheEmployeeBindingSource As BindingSource

    Private TheVehiclesDataSet As VehiclesDataSet
    Private TheVehiclesDataTier As VehiclesDataTier
    Private WithEvents TheVehiclesBindingSource As BindingSource

    Private TheWeeklyVehicleInspectionsDataSet As WeeklyVehicleInspectionsDataSet
    Private TheWeeklyVehicleInspectionDataTier As WeeklyVehicleInpectionDataTier
    Private WithEvents TheWeeklyVehicleInspectionBindingSource As BindingSource

    Private addingBoolean As Boolean = False
    Private editingBoolean As Boolean = False
    Private previousSelectedIndex As Integer
    Dim mintNumuberOfRecords As Integer

    Dim TheInputDataValidation As New InputDataValidation

    Dim LogDateTime As Date = DateAndTime.Now
    Dim strLogDateTime As String
    Dim mblnEmployeeIDFound As Boolean
    Dim mintEmployeeIDSelectedIndex(10000) As Integer
    Dim mintVehicleIDSelectedIndex(10000) As Integer
    Dim mintInspectionIDSelectedIndex(10000) As Integer
    Dim mintVehicleIDCounter As Integer
    Dim mintInspectionIDCounter As Integer
    Dim mintEmployeeIDCounter As Integer
    Dim mblnLastNameFound As Boolean
    Dim mintInspectionIDUpperLimit As Integer
    Dim mintVehicleIDUpperLimit As Integer
    Dim mintEmployeeIdUpperLimit As Integer
    Dim mdatStartingDateForSearching As Date
    Dim mdatEndingDateForSearching As Date
    Dim mdatDateFromTable As Date

    'Variables for History
    Friend mintVehicleID As Integer
    Friend mintEmployeeID As Integer
    Friend mstrLogDateTime As String
    Friend mstrNotes As String
    Friend mintBJCNumber As Integer

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        'Closes the Program
        CloseTheProgram.ShowDialog()

    End Sub

    Private Sub btnInspectionMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInspectionMenu.Click

        'Opens the Tool Menu
        ClearDataBindings()
        InspectionSearchMenu.Show()
        Me.Close()

    End Sub

    Private Sub btnMainMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMainMenu.Click

        'This opens the Main menu
        ClearDataBindings()
        MainMenu.Show()
        Me.Close()

    End Sub

    Private Sub setComboBoxBinding()

        'Sets the Combobox Bindings
        With Me.cboEmployeeID
            If (addingBoolean Or editingBoolean) Then
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.OnValidation
                .DropDownStyle = ComboBoxStyle.Simple
            Else
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.Never
                .DropDownStyle = ComboBoxStyle.DropDownList
            End If
        End With

        With Me.cboVehicleID
            If (addingBoolean Or editingBoolean) Then
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.OnValidation
                .DropDownStyle = ComboBoxStyle.Simple
            Else
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.Never
                .DropDownStyle = ComboBoxStyle.DropDownList
            End If
        End With

        With Me.cboInspectionID
            If (addingBoolean Or editingBoolean) Then
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.OnValidation
                .DropDownStyle = ComboBoxStyle.Simple
            Else
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.Never
                .DropDownStyle = ComboBoxStyle.DropDownList
            End If
        End With

    End Sub
    Private Sub ClearDataBindings()

        'This sub routine clears all Data Bindings

        'Removing Data Bindings for Employees
        cboEmployeeID.DataBindings.Clear()
        txtLastName.DataBindings.Clear()
        txtFirstName.DataBindings.Clear()
        txtPhoneNumber.DataBindings.Clear()

        'Removing Data Bindings for Vehicles
        cboVehicleID.DataBindings.Clear()
        txtVehicleBJCNumber.DataBindings.Clear()
        txtVehicleEmployeeID.DataBindings.Clear()
        txtVehicleLastOilChangeOdometer.DataBindings.Clear()
        txtVehicleMake.DataBindings.Clear()
        txtVehicleModel.DataBindings.Clear()

        'Removing Data Bindings for Inspection
        cboInspectionID.DataBindings.Clear()
        txtInspectionVehicleID.DataBindings.Clear()
        txtInspectionBJCNumber.DataBindings.Clear()
        txtInspectionEmployeeID.DataBindings.Clear()
        txtInspectionCurrentOdometer.DataBindings.Clear()
        txtInspectionDate.DataBindings.Clear()
        txtInspectionNextOilChangeOdometer.DataBindings.Clear()
        txtInspectionToolsInspected.DataBindings.Clear()
        txtInspectionVehicleCleanliness.DataBindings.Clear()
        txtInspectionPPEInspected.DataBindings.Clear()
        txtInspectionNotes.DataBindings.Clear()
        txtInspectionVehicleServiceable.DataBindings.Clear()


    End Sub
    Private Sub btnFindVehicle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindVehicle.Click

        Dim strBJCNumber As String
        Dim blnFatalError As Boolean
        Dim intEmployeeIDFromVehicles As Integer
        Dim intBJCNumberEntered As Integer

        SetTextBoxesVisible(True)

        mintInspectionIDUpperLimit = 0

        'Setting Validation Variable initial condition
        strBJCNumber = CStr(txtBJCNumberEntered.Text)

        blnFatalError = TheInputDataValidation.VerifyIntegerData(strBJCNumber)

        intBJCNumberEntered = CInt(txtBJCNumberEntered.Text)
        intEmployeeIDFromVehicles = CInt(txtVehicleEmployeeID.Text)

        FindInspectionsByVehicle(intBJCNumberEntered)
        FindVehicle(intBJCNumberEntered)
        FindEmployeeID(intemployeeIDFromVehicles)


        cboVehicleID.Visible = False

        If mintInspectionIDUpperLimit > 1 Then
            btnNext.Enabled = True
        End If


        cboInspectionID.SelectedIndex = mintInspectionIDSelectedIndex(mintInspectionIDCounter)
        txtBJCNumberEntered.Text = ""

    End Sub
    Private Sub txtBJCNumberEntered_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBJCNumberEntered.KeyDown

        If e.KeyCode = Keys.Enter Then
            btnFindVehicle.PerformClick()
            txtEmployeeIDSearch.Focus()
        End If

    End Sub

    Private Sub txtEmployeeIDSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEmployeeIDSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSearchByEmployeeID.PerformClick()
        End If
    End Sub

    Private Sub txtLastNameSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLastNameSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSearchByEmployeeName.PerformClick()
            If btnNext.Enabled = True Then
                btnNext.Focus()
            End If
        End If
    End Sub
    Private Sub FindEmployeeID(ByVal intEmployeeID As Integer)

        'Setting Local Variables
        Dim intEmployeeIDFromTable As Integer
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim intSelectedIndexFound As Integer

        'Setting the value of the variables
        mblnEmployeeIDFound = False
        intNumberOfRecords = cboEmployeeID.Items.Count

        'Performing Compare
        For intCounter = 0 To intNumberOfRecords - 1

            cboEmployeeID.SelectedIndex = intCounter
            intEmployeeIDFromTable = CInt(cboEmployeeID.Text)

            If intEmployeeIDFromTable = intEmployeeID Then
                mblnEmployeeIDFound = True
                intSelectedIndexFound = intCounter
            End If

        Next

        'Setting Combobox Selected Index
        If mblnEmployeeIDFound = True Then
            cboEmployeeID.SelectedIndex = intSelectedIndexFound
        End If

    End Sub
    Private Sub FindInspectionsByVehicle(ByVal intBJCNumberEntered As Integer)


        Dim blnBJCNumberNotFound As Boolean
        Dim intNumberOfRecords As Integer
        Dim intBJCNumberFromTable As Integer

        btnBack.Enabled = False
        btnNext.Enabled = False

        For intCounter = 0 To 9999
            mintInspectionIDSelectedIndex(intCounter) = -1
        Next

        'Setting Up Inspections
        intNumberOfRecords = cboInspectionID.Items.Count
        mintInspectionIDCounter = 0
        blnBJCNumberNotFound = True

        'Performing Search
        For intCounter = 0 To intNumberOfRecords - 1
            cboInspectionID.SelectedIndex = intCounter
            intBJCNumberFromTable = CInt(txtInspectionBJCNumber.Text)
            mdatDateFromTable = CDate(txtInspectionDate.Text)
            If intBJCNumberEntered = intBJCNumberFromTable And mdatDateFromTable >= mdatStartingDateForSearching And mdatDateFromTable <= mdatEndingDateForSearching Then
                blnBJCNumberNotFound = False
                mintInspectionIDSelectedIndex(mintInspectionIDCounter) = intCounter
                mintInspectionIDCounter = mintInspectionIDCounter + 1
            End If

        Next

        If blnBJCNumberNotFound = True Then
            SetTextBoxesVisible(False)
            MessageBox.Show("BJC Number Not Found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        Else
            mintInspectionIDUpperLimit = mintInspectionIDCounter
            mintInspectionIDCounter = 0
        End If


    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click

        'This Routine will run the Next Buttons
        mintInspectionIDCounter = mintInspectionIDCounter + 1
        cboInspectionID.SelectedIndex = mintInspectionIDSelectedIndex(mintInspectionIDCounter)

        btnBack.Enabled = True


        If mintInspectionIDCounter = mintInspectionIDUpperLimit - 1 Then
            btnNext.Enabled = False

        End If

        CallVehicleAndEmployeeInformation()

    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click

        'This will run the Back Button
        mintInspectionIDCounter = mintInspectionIDCounter - 1
        cboInspectionID.SelectedIndex = mintInspectionIDSelectedIndex(mintInspectionIDCounter)


        If mintInspectionIDCounter = 0 Then
            btnBack.Enabled = False
        End If

        If mintInspectionIDCounter < mintInspectionIDUpperLimit Then
            btnNext.Enabled = True
        End If

        CallVehicleAndEmployeeInformation()

    End Sub

    Private Sub FindInspectionByEmployeeID(ByVal intEmployeeIDEntered As Integer)

        Dim blnEmployeeIDNotFound As Boolean
        Dim intEmployeeIDFromTable As Integer

        SetTextBoxesVisible(True)

        btnNext.Enabled = False
        btnBack.Enabled = False

        'Setting Up Inspections
        mintInspectionIDUpperLimit = cboInspectionID.Items.Count
        mintInspectionIDCounter = 0
        blnEmployeeIDNotFound = True

        'Performing Search
        For intCounter = 0 To mintInspectionIDUpperLimit - 1
            cboInspectionID.SelectedIndex = intCounter
            intEmployeeIDFromTable = CInt(txtInspectionEmployeeID.Text)
            mdatDateFromTable = CDate(txtInspectionDate.Text)
            If intEmployeeIDEntered = intEmployeeIDFromTable And mdatDateFromTable >= mdatStartingDateForSearching And mdatDateFromTable <= mdatEndingDateForSearching Then
                blnEmployeeIDNotFound = False
                mintInspectionIDSelectedIndex(mintInspectionIDCounter) = intCounter
                mintInspectionIDCounter = mintInspectionIDCounter + 1
            End If

        Next

        If blnEmployeeIDNotFound = True Then
            SetTextBoxesVisible(False)
            MessageBox.Show("Employee Not Found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        Else
            mintInspectionIDUpperLimit = mintInspectionIDCounter
            mintInspectionIDCounter = 0
            cboInspectionID.SelectedIndex = mintInspectionIDSelectedIndex(mintInspectionIDCounter)
            FindVehicle(CInt(txtInspectionBJCNumber.Text))
        End If
    End Sub

    Private Sub btnSearchByEmployeeID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchByEmployeeID.Click

        Dim intEmployeeIDEntered As Integer
        Dim strEmployeeIDEntered As String
        Dim blnFatalError As Boolean = False

        strEmployeeIDEntered = txtEmployeeIDSearch.Text
        blnFatalError = TheInputDataValidation.VerifyIntegerData(strEmployeeIDEntered)

        If blnFatalError = True Then
            MessageBox.Show("The Employee ID Entered is not an Integer", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        intEmployeeIDEntered = CInt(txtEmployeeIDSearch.Text)

        FindEmployeeID(intEmployeeIDEntered)
        FindInspectionByEmployeeID(intEmployeeIDEntered)


        cboInspectionID.SelectedIndex = mintInspectionIDSelectedIndex(mintInspectionIDCounter)

        If mintInspectionIDUpperLimit > 1 Then
            btnNext.Enabled = True
        End If

        txtEmployeeIDSearch.Text = ""

    End Sub
    Private Sub FindVehicle(ByVal intBJCNumberEntered As Integer)

        'This sub-routine runs when the Find Tool button is pressed
        Dim intBJCNumberFromTable As Integer
        Dim intNumberOfRecords As Integer
        Dim intCounter As Integer
        Dim blnBJCNumberNotFound As Boolean = True

        'btnNext.Enabled = False
        'btnBack.Enabled = False

        'Setting Variables for Tool ID Search
        intNumberOfRecords = cboVehicleID.Items.Count

        For intCounter = 0 To 9999
            mintVehicleIDSelectedIndex(intCounter) = -1
        Next

        mintVehicleIDCounter = 0
        mintVehicleIDUpperLimit = cboVehicleID.Items.Count
        'Performing Search
        For intCounter = 0 To intNumberOfRecords - 1
            cboVehicleID.SelectedIndex = intCounter
            intBJCNumberFromTable = CInt(txtVehicleBJCNumber.Text)
            mdatDateFromTable = CDate(txtInspectionDate.Text)
            If intBJCNumberEntered = intBJCNumberFromTable And mdatDateFromTable >= mdatStartingDateForSearching And mdatDateFromTable <= mdatEndingDateForSearching Then
                blnBJCNumberNotFound = False
                mintVehicleIDSelectedIndex(mintVehicleIDCounter) = intCounter
            End If

        Next

        'Putting out Error Message or moving the Combo Box
        If blnBJCNumberNotFound = True Then
            cboVehicleID.Visible = False
            SetTextBoxesVisible(False)
            MessageBox.Show("BJC Number Not Found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        Else
            mintVehicleIDUpperLimit = mintVehicleIDCounter
            mintVehicleIDCounter = 0
            cboVehicleID.SelectedIndex = mintVehicleIDSelectedIndex(mintVehicleIDCounter)
        End If
    End Sub
    Private Sub CallVehicleAndEmployeeInformation()

        Dim intBJCNumberEntered As Integer
        Dim intEmployeeID As Integer

        intBJCNumberEntered = CInt(txtInspectionBJCNumber.Text)
        intEmployeeID = CInt(txtInspectionEmployeeID.Text)

        FindEmployeeID(intEmployeeID)
        FindVehicle(intBJCNumberEntered)

    End Sub

    Private Sub btnSearchByEmployeeName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchByEmployeeName.Click

        'This subroutine runs when the Search by Employee Name is pressed
        Dim strLastNameEntered As String
        Dim strLastNameFromTable As String
        Dim strFirstNameEntered As String
        Dim strFirstNameFromTable As String
        Dim intCounter As Integer
        Dim blnFatalError As Boolean
        Dim blnEmployeeFound As Boolean = False
        Dim intEmployeeIDFound As Integer


        strLastNameEntered = txtLastNameSearch.Text
        blnFatalError = TheInputDataValidation.VerifyTextData(strLastNameEntered)

        If blnFatalError = True Then
            MessageBox.Show("The Employee Last Name was not Entered", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        strFirstNameEntered = txtFirstNameSearch.Text
        blnFatalError = TheInputDataValidation.VerifyTextData(strFirstNameEntered)

        If blnFatalError = True Then
            MessageBox.Show("The Employee First Name was not Entered", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        mintEmployeeIdUpperLimit = cboEmployeeID.Items.Count
        mintEmployeeIDCounter = 0


        For intCounter = 0 To mintEmployeeIdUpperLimit - 1
            cboEmployeeID.SelectedIndex = intCounter
            strLastNameFromTable = txtLastName.Text
            If strLastNameEntered = strLastNameFromTable Then
                strFirstNameFromTable = txtFirstName.Text
                If strFirstNameEntered = strFirstNameFromTable Then
                    mintEmployeeIDSelectedIndex(mintEmployeeIDCounter) = intCounter
                    mintEmployeeIDCounter = mintEmployeeIDCounter + 1
                    blnEmployeeFound = True
                End If
            End If
        Next

        If blnEmployeeFound = False Then
            MessageBox.Show("Employee Not Found", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        Else
            cboEmployeeID.SelectedIndex = mintEmployeeIDSelectedIndex(0)
            intEmployeeIDFound = CInt(cboEmployeeID.Text)
            txtEmployeeIDSearch.Text = CStr(intEmployeeIDFound)
            btnSearchByEmployeeID.PerformClick()
        End If

        txtLastNameSearch.Text = ""
        txtFirstNameSearch.Text = ""

    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click

        SetTextBoxesVisible(True)

        SearchByDateSetup()

        CallVehicleAndEmployeeInformation()

    End Sub

    Private Sub SearchWeeklyInspectionsByDate_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim intEmployeeIDEntered As Integer
        Dim intBJCNumberEntered As Integer

        'Employee Try - Catch
        Try
            'This will bind the controls to the data source
            TheEmployeeDataTier = New EmployeeDataTier
            TheEmployeeDataSet = TheEmployeeDataTier.GetEmployeeInformation
            TheEmployeeBindingSource = New BindingSource

            'Setting up Binding Source for the Combo Box
            With TheEmployeeBindingSource
                .DataSource = TheEmployeeDataSet
                .DataMember = "employees"
                .MoveFirst()
                .MoveLast()
            End With

            'Setting the data relationship for the Combo Box
            With cboEmployeeID
                .DataSource = TheEmployeeBindingSource
                .DisplayMember = "EmployeeID"
                .DataBindings.Add("text", TheEmployeeBindingSource, "EmployeeID", False, DataSourceUpdateMode.Never)
            End With

            'Setting the data binding for the text boxes
            txtFirstName.DataBindings.Add("text", TheEmployeeBindingSource, "FirstName")
            txtLastName.DataBindings.Add("text", TheEmployeeBindingSource, "LastName")
            txtPhoneNumber.DataBindings.Add("text", TheEmployeeBindingSource, "PhoneNumber")


        Catch ex As Exception
            'If an exception is thrown, it is rounted here
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        'Vehicle Try - Catch
        Try

            'This will bind the controls to the data source
            TheVehiclesDataTier = New VehiclesDataTier
            TheVehiclesDataSet = TheVehiclesDataTier.GetVehiclesInformation
            TheVehiclesBindingSource = New BindingSource

            'Setting the binding for the combo box
            With TheVehiclesBindingSource
                .DataSource = TheVehiclesDataSet
                .DataMember = "vehicles"
                .MoveFirst()
                .MoveLast()
            End With

            'Binding controls to for the binding for the combo box
            With cboVehicleID
                .DataSource = TheVehiclesBindingSource
                .DisplayMember = "VehicleID"
                .DataBindings.Add("text", TheVehiclesBindingSource, "VehicleID", False, DataSourceUpdateMode.Never)
            End With

            'Setting the binding for all other textbox controls
            txtVehicleBJCNumber.DataBindings.Add("text", TheVehiclesBindingSource, "BJCNumber")
            txtVehicleEmployeeID.DataBindings.Add("text", TheVehiclesBindingSource, "EmployeeID")
            txtVehicleLastOilChangeOdometer.DataBindings.Add("text", TheVehiclesBindingSource, "LastOilChangeOdometer")
            txtVehicleMake.DataBindings.Add("text", TheVehiclesBindingSource, "Make")
            txtVehicleModel.DataBindings.Add("text", TheVehiclesBindingSource, "Model")

        Catch ex As Exception

            'If an exception is thrown, it is rounted here
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        'Inspection Informtion Try - Catch
        Try

            TheWeeklyVehicleInspectionDataTier = New WeeklyVehicleInpectionDataTier
            TheWeeklyVehicleInspectionsDataSet = TheWeeklyVehicleInspectionDataTier.GetWeeklyVehicleInpectionInformation
            TheWeeklyVehicleInspectionBindingSource = New BindingSource

            'Setting the binding for the combo box
            With TheWeeklyVehicleInspectionBindingSource
                .DataSource = TheWeeklyVehicleInspectionsDataSet
                .DataMember = "WeeklyVehicleInspections"
                .MoveFirst()
                .MoveLast()
            End With

            'Binding controls to for the binding for the combo box
            With cboInspectionID
                .DataSource = TheWeeklyVehicleInspectionBindingSource
                .DisplayMember = "InspectionID"
                .DataBindings.Add("text", TheWeeklyVehicleInspectionBindingSource, "InspectionID", False, DataSourceUpdateMode.Never)
            End With

            txtInspectionVehicleID.DataBindings.Add("text", TheWeeklyVehicleInspectionBindingSource, "VehicleID")
            txtInspectionBJCNumber.DataBindings.Add("text", TheWeeklyVehicleInspectionBindingSource, "BJCNumber")
            txtInspectionEmployeeID.DataBindings.Add("text", TheWeeklyVehicleInspectionBindingSource, "EmployeeID")
            txtInspectionCurrentOdometer.DataBindings.Add("text", TheWeeklyVehicleInspectionBindingSource, "CurrentOdometer")
            txtInspectionDate.DataBindings.Add("text", TheWeeklyVehicleInspectionBindingSource, "InspectionDate")
            txtInspectionNextOilChangeOdometer.DataBindings.Add("text", TheWeeklyVehicleInspectionBindingSource, "NextOilChangeOdometer")
            txtInspectionToolsInspected.DataBindings.Add("text", TheWeeklyVehicleInspectionBindingSource, "ToolsInspected")
            txtInspectionVehicleCleanliness.DataBindings.Add("text", TheWeeklyVehicleInspectionBindingSource, "VehicleCleanliness")
            txtInspectionPPEInspected.DataBindings.Add("text", TheWeeklyVehicleInspectionBindingSource, "PPEInspected")
            txtInspectionNotes.DataBindings.Add("text", TheWeeklyVehicleInspectionBindingSource, "InspectionNotes")
            txtInspectionVehicleServiceable.DataBindings.Add("text", TheWeeklyVehicleInspectionBindingSource, "VehicleServiceability")

            SearchByDateSetup()

            intBJCNumberEntered = CInt(txtInspectionBJCNumber.Text)
            intEmployeeIDEntered = CInt(txtInspectionEmployeeID.Text)

            FindVehicle(intBJCNumberEntered)
            FindEmployeeID(intEmployeeIDEntered)

        Catch ex As Exception
            'If an exception is thrown, it is rounted here
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub SearchByDateSetup()

        'Setting up local variables
        Dim intBJCNumberEntered As Integer
        Dim intEmployeeIDEntered As Integer
        Dim datDateFromTable As Date
        Dim blnDateRangeFound As Boolean = False

        'Setting up Combobox
        cboInspectionID.SelectedIndex = 0

        'Loading up global variables
        mdatStartingDateForSearching = Logon.mdatStartingDate
        mdatEndingDateForSearching = Logon.mdatEndingDate

        'Setting up search conditions
        mintInspectionIDCounter = 0
        mintInspectionIDUpperLimit = cboInspectionID.Items.Count

        'beginning the For Loop
        For intCounter = 0 To mintInspectionIDUpperLimit - 1

            'Incrementing the information
            cboInspectionID.SelectedIndex = intCounter
            datDateFromTable = CDate(txtInspectionDate.Text)

            'Checking each record to see if it meets the criteria
            If datDateFromTable >= mdatStartingDateForSearching And datDateFromTable <= mdatEndingDateForSearching Then

                mintInspectionIDSelectedIndex(mintInspectionIDCounter) = intCounter
                mintInspectionIDCounter = mintInspectionIDCounter + 1
                blnDateRangeFound = True

            End If
        Next

        'If there are no records, the user is notified
        If blnDateRangeFound = False Then
            SetTextBoxesVisible(False)
            MessageBox.Show("No Records found for that Date Range", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        'Setting the conditions for the search
        mintInspectionIDUpperLimit = mintInspectionIDCounter
        mintInspectionIDCounter = 0
        cboInspectionID.SelectedIndex = mintInspectionIDSelectedIndex(0)
        intBJCNumberEntered = CInt(txtInspectionBJCNumber.Text)
        intEmployeeIDEntered = CInt(txtInspectionEmployeeID.Text)

        'Finding Vehicle
        FindVehicle(intBJCNumberEntered)
        FindEmployeeID(intEmployeeIDEntered)

        'Setting up buttons
        If mintInspectionIDUpperLimit - 1 > 0 Then
            btnNext.Enabled = True
        End If

    End Sub
    Private Sub SetTextBoxesVisible(ByVal valueBoolean As Boolean)

        'This sub routine clears all Data Bindings

        'Setting Visible Textboxes for Employees

        txtLastName.Visible = valueBoolean
        txtFirstName.Visible = valueBoolean
        txtPhoneNumber.Visible = valueBoolean

        'Setting Visible Textboxes for Vehicles

        txtVehicleBJCNumber.Visible = valueBoolean
        txtVehicleEmployeeID.Visible = valueBoolean
        txtVehicleLastOilChangeOdometer.Visible = valueBoolean
        txtVehicleMake.Visible = valueBoolean
        txtVehicleModel.Visible = valueBoolean

        'Setting Visible Textboxes for Inspection

        txtInspectionVehicleID.Visible = valueBoolean
        txtInspectionBJCNumber.Visible = valueBoolean
        txtInspectionEmployeeID.Visible = valueBoolean
        txtInspectionCurrentOdometer.Visible = valueBoolean
        txtInspectionDate.Visible = valueBoolean
        txtInspectionNextOilChangeOdometer.Visible = valueBoolean
        txtInspectionToolsInspected.Visible = valueBoolean
        txtInspectionVehicleCleanliness.Visible = valueBoolean
        txtInspectionPPEInspected.Visible = valueBoolean
        txtInspectionNotes.Visible = valueBoolean
        txtInspectionVehicleServiceable.Visible = valueBoolean

    End Sub

End Class