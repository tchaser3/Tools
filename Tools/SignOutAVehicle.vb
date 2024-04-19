'Title:         Sign Out a Vehicle
'Date:          7/22/13
'Name:          Terry Holmes

'Description:   This form is used to sign out a Vehicle

Option Strict On

Public Class SignOutAVehicle

    'Setting Modular Variables
    Private TheEmployeeDataSet As EmployeeDataSet
    Private TheEmployeeDataTier As EmployeeDataTier
    Private WithEvents TheEmployeeBindingSource As BindingSource

    Private TheVehiclesDataSet As VehiclesDataSet
    Private TheVehiclesDataTier As VehiclesDataTier
    Private WithEvents TheVehiclesBindingSource As BindingSource

    Private addingBoolean As Boolean = False
    Private editingBoolean As Boolean = False
    Private previousSelectedIndex As Integer
    Dim mintNumuberOfRecords As Integer

    Dim LogDateTime As Date = DateAndTime.Now
    Dim strLogDateTime As String
    Dim mblnEmployeeIDFound As Boolean
    Dim mintSelectedIndex(10000) As Integer
    Dim mintCounter As Integer
    Dim mblnLastNameFound As Boolean
    Dim mintUpperLimit As Integer

    'Variables for History
    Friend mintVehicleID As Integer
    Friend mintEmployeeID As Integer
    Friend mstrLogDateTime As String
    Friend mstrNotes As String
    Friend mintBJCNumber As Integer
    Dim mstrOutOfTownSetting As String = "FALSE"

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        'Closes the Program
        CloseTheProgram.ShowDialog()

    End Sub

    Private Sub btnVehicleMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVehicleMenu.Click

        'Opens the Tool Menu
        ClearDataBindings()
        VehicleMenu.Show()
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

    End Sub
    Private Sub setControlsReadOnly(ByVal valueBoolean As Boolean)

        'This will set controls either to read only or not
        With Me

            txtFirstName.ReadOnly = valueBoolean
            txtLastName.ReadOnly = valueBoolean
            txtPhoneNumber.ReadOnly = valueBoolean

            txtBJCNumber.ReadOnly = valueBoolean
            txtYear.ReadOnly = valueBoolean
            txtMake.ReadOnly = valueBoolean
            txtModel.ReadOnly = valueBoolean
            txtLicencePlate.ReadOnly = valueBoolean
            txtEmployeeID.ReadOnly = valueBoolean
            txtDate.ReadOnly = valueBoolean
            txtNotes.ReadOnly = valueBoolean
            txtAvailable.ReadOnly = valueBoolean
            txtActive.ReadOnly = valueBoolean
            txtOutOfTown.ReadOnly = valueBoolean

        End With

    End Sub
    Private Sub setButtonsForEdit()



    End Sub
    Private Sub ResetButtonAfterEditing()



    End Sub
    Private Sub setTextBoxesVisible(ByVal valueBoolean As Boolean)

        'This will set controls either to visible or not
        With Me

            txtFirstName.Visible = valueBoolean
            txtLastName.Visible = valueBoolean
            txtPhoneNumber.Visible = valueBoolean

            txtBJCNumber.Visible = valueBoolean
            txtYear.Visible = valueBoolean
            txtMake.Visible = valueBoolean
            txtModel.Visible = valueBoolean
            txtLicencePlate.Visible = valueBoolean
            txtEmployeeID.Visible = valueBoolean
            txtDate.Visible = valueBoolean
            txtNotes.Visible = valueBoolean
            txtAvailable.Visible = valueBoolean
            txtActive.Visible = valueBoolean
            txtOutOfTown.Visible = valueBoolean

        End With

    End Sub

    Private Sub SignOutAVehicle_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Try - Catch is used to protect the make sure that the program loads correctly
        'And if there is a problem, the exception is routed to a Message Box, instead of 
        'the whole program crashing
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
            
            txtBJCNumber.DataBindings.Add("text", TheVehiclesBindingSource, "BJCNumber")
            txtYear.DataBindings.Add("text", TheVehiclesBindingSource, "Year")
            txtMake.DataBindings.Add("text", TheVehiclesBindingSource, "Make")
            txtModel.DataBindings.Add("text", TheVehiclesBindingSource, "Model")
            txtLicencePlate.DataBindings.Add("text", TheVehiclesBindingSource, "LicencePlate")
            txtEmployeeID.DataBindings.Add("text", TheVehiclesBindingSource, "EmployeeID")
            txtDate.DataBindings.Add("text", TheVehiclesBindingSource, "Date")
            txtAvailable.DataBindings.Add("text", TheVehiclesBindingSource, "Available")
            txtActive.DataBindings.Add("text", TheVehiclesBindingSource, "Active")
            txtNotes.DataBindings.Add("text", TheVehiclesBindingSource, "Notes")
            txtOutOfTown.DataBindings.Add("text", TheVehiclesBindingSource, "OutOfTown")

            setControlsReadOnly(True)

            setTextBoxesVisible(False)

        Catch ex As Exception

            'If an exception is thrown, it is rounted here
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnFindVehicle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindVehicle.Click

        'This sub-routine runs when the Find Tool button is pressed
        Dim decBJCNumber As Decimal
        Dim decBJCNumberTruncated As Decimal
        Dim blnFatalError As Boolean
        Dim strErrorMessage As String
        Dim intBJCNumberEntered As Integer
        Dim intBJCNumberFromTable As Integer
        Dim intVehicleIDCBOSelectedIndex As Integer
        Dim intNumberOfRecords As Integer
        Dim intCounter As Integer
        Dim blnBJCNumberNotFound As Boolean = True
        Dim intEmployeeIDFromTools As Integer

        btnNext.Enabled = False
        btnBack.Enabled = False

        'Setting Validation Variable initial condition
        blnFatalError = False
        strErrorMessage = ""

        'Checking that information was added into the Tool ID
        If Not IsNumeric(txtBJCNumberEntered.Text) Then
            blnFatalError = True
            strErrorMessage = strErrorMessage + "The BJC Number entered is not Numeric" + vbNewLine

        Else
            decBJCNumber = Convert.ToDecimal(txtBJCNumberEntered.Text)
            decBJCNumberTruncated = Decimal.Truncate(decBJCNumber)
            If decBJCNumberTruncated <> decBJCNumber Then
                blnFatalError = True
                strErrorMessage = strErrorMessage + "The BJC Number value entered is not an integer" + vbNewLine
            Else
                If decBJCNumber < 1000 Then
                    blnFatalError = True
                    strErrorMessage = strErrorMessage + "Number is out of range, must be Greater than 1000" + vbNewLine
                End If
            End If

        End If

        If decBJCNumber > 99999999 Then
            blnFatalError = True
            strErrorMessage = strErrorMessage + "BJC Number Entered is Tool Large" + vbNewLine
        End If

        'Sending Error Message to User
        If blnFatalError = True Then
            MessageBox.Show(strErrorMessage, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        setTextBoxesVisible(True)

        btnSearchByEmployeeID.Enabled = True
        btnSearchByEmployeeLastName.Enabled = True


        'Setting Variables for Tool ID Search
        intBJCNumberEntered = CInt(txtBJCNumberEntered.Text)
        intNumberOfRecords = cboVehicleID.Items.Count

        'Performing Search
        For intCounter = 0 To intNumberOfRecords - 1
            cboVehicleID.SelectedIndex = intCounter
            intBJCNumberFromTable = CInt(txtBJCNumber.Text)

            If intBJCNumberEntered = intBJCNumberFromTable Then
                blnBJCNumberNotFound = False
                intVehicleIDCBOSelectedIndex = intCounter
            End If

        Next

        'Putting out Error Message or moving the Combo Box
        If blnBJCNumberNotFound = True Then
            cboVehicleID.Visible = False
            MessageBox.Show("BJC Number Not Found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        Else
            cboVehicleID.SelectedIndex = intVehicleIDCBOSelectedIndex
        End If

        'Setting the buttons up for signing out the tool
        setButtonsForEdit()
        setComboBoxBinding()
        strLogDateTime = CStr(LogDateTime)
        txtDate.Text = strLogDateTime
        txtEmployeeIDSearch.Text = ""
        txtLastNameSearch.Text = ""

        'cboEmployeeID.Visible = True
        txtFirstName.Visible = True
        txtLastName.Visible = True
        txtPhoneNumber.Visible = True


        intEmployeeIDFromTools = CInt(txtEmployeeID.Text)

        FindEmployeeID(intEmployeeIDFromTools)

        cboVehicleID.Visible = False


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
    Private Sub btnSearchByEmployeeID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchByEmployeeID.Click

        'This subroutine will run if the user is looking for the Employee ID
        Dim intEmployeeIDEntered As Integer
        Dim blnFatalError As Boolean
        Dim strErrorMessage As String
        Dim decEmployeeID As Decimal
        Dim decEmployeeIDTruncated As Decimal

        btnBack.Enabled = False
        btnNext.Enabled = False

        'Setting initial Data Validation variables
        blnFatalError = False
        strErrorMessage = ""

        'Performating Data Validation
        If Not IsNumeric(txtEmployeeIDSearch.Text) Then
            blnFatalError = True
            strErrorMessage = "The Employee ID entered is not Numeric" + vbNewLine
        Else

            decEmployeeID = Convert.ToDecimal(txtEmployeeIDSearch.Text)
            decEmployeeIDTruncated = Decimal.Truncate(decEmployeeID)

            If decEmployeeID <> decEmployeeIDTruncated Then
                blnFatalError = True
                strErrorMessage = "The Employee ID entered is not an Integer" + vbNewLine
            Else
                If decEmployeeID < 1 Then
                    blnFatalError = True
                    strErrorMessage = "The Employee ID entered can not be Less Than 1" + vbNewLine
                End If
            End If

        End If

        If decEmployeeID > 99999999 Then
            blnFatalError = True
            strErrorMessage = strErrorMessage + "The Employee ID is Tool Large"
        End If

        If blnFatalError = True Then
            MessageBox.Show(strErrorMessage, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        'Making Textboxes visible
        txtLastName.Visible = True
        txtFirstName.Visible = True
        txtPhoneNumber.Visible = True
        btnSignOut.Enabled = True

        'Sets vaue of the local variable
        intEmployeeIDEntered = CInt(txtEmployeeIDSearch.Text)

        'Call sub-routine
        FindEmployeeID(intEmployeeIDEntered)

        'Message to the user
        If mblnEmployeeIDFound = False Then
            MessageBox.Show("Employee ID Entered Does Not Exist", "Please Try Again", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnSearchByEmployeeLastName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchByEmployeeLastName.Click

        'This routine is used to search for by Last Name

        btnBack.Enabled = False
        btnNext.Enabled = False
        Dim strLastNameEntered As String
        Dim strLastNameFromTable As String
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim blnFatalError As Boolean
        Dim strErrorMessage As String

        btnNext.Enabled = False
        btnBack.Enabled = False

        'Setting validation variables
        blnFatalError = False
        strErrorMessage = ""
        mblnLastNameFound = False

        'Performing Validation
        If txtLastNameSearch.Text = "" Then
            blnFatalError = True
            strErrorMessage = strErrorMessage + "No Last Name was entered to be searched" + vbNewLine
        End If

        'Letting User Know if there was a problem
        If blnFatalError = True Then
            MessageBox.Show(strErrorMessage, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        'Making Textboxes Visible
        txtLastName.Visible = True
        txtFirstName.Visible = True
        txtPhoneNumber.Visible = True
        btnSignOut.Enabled = True
        btnNext.Enabled = False
        btnBack.Enabled = False

        'Setting initial variables
        strLastNameEntered = CStr(txtLastNameSearch.Text)
        intNumberOfRecords = cboEmployeeID.Items.Count
        mintCounter = 0

        'Looking for Employee's Last Name
        For intCounter = 0 To intNumberOfRecords - 1
            cboEmployeeID.SelectedIndex = intCounter
            strLastNameFromTable = CStr(txtLastName.Text)

            If strLastNameEntered = strLastNameFromTable Then
                mintSelectedIndex(mintCounter) = intCounter
                mintCounter = mintCounter + 1
                mblnLastNameFound = True
            End If
        Next

        'Performing Output to User
        If mblnLastNameFound = False Then
            MessageBox.Show("The Employee Last Name was not Found", "Please Verify and Try again", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        'Enabling the Next Button
        If mintCounter > 1 Then
            btnNext.Enabled = True
        End If

        'Setting the Upper Limit Variable
        mintUpperLimit = mintCounter - 1
        mintCounter = 0

        'Placing the the Combobox in the first location
        cboEmployeeID.SelectedIndex = mintSelectedIndex(mintCounter)


    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click

        'This Routine will run the Next Buttons
        mintCounter = mintCounter + 1
        cboEmployeeID.SelectedIndex = mintSelectedIndex(mintCounter)
        btnBack.Enabled = True


        If mintCounter = mintUpperLimit Then
            btnNext.Enabled = False

        End If

    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click

        'This will run the Back Button
        mintCounter = mintCounter - 1
        cboEmployeeID.SelectedIndex = mintSelectedIndex(mintCounter)


        If mintCounter = 0 Then
            btnBack.Enabled = False
        End If

        If mintCounter < mintUpperLimit Then
            btnNext.Enabled = True
        End If

    End Sub

    Private Sub txtEmployeeIDSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEmployeeIDSearch.KeyDown

        If e.KeyCode = Keys.Enter Then
            btnSearchByEmployeeID.PerformClick()
            btnSignOut.Focus()
        End If

    End Sub

    Private Sub txtLastNameSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLastNameSearch.KeyDown

        If e.KeyCode = Keys.Enter Then
            btnSearchByEmployeeLastName.PerformClick()
        End If

    End Sub

    Private Sub txtBJCNumberEntered_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBJCNumberEntered.KeyDown

        If e.KeyCode = Keys.Enter Then
            btnFindVehicle.PerformClick()
            txtEmployeeIDSearch.Focus()
        End If

    End Sub

    Private Sub btnSignOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'This routine will sign out a tool
        Dim intEmployeeID As Integer
        Dim strFirstName As String
        Dim strLastName As String
        Dim strBJCNumber As String
        Dim strSignOutMessage As String
        Dim intVehicleID As Integer

        'Performing Data Validation
        If txtActive.Text = "NO" Then
            MessageBox.Show("The Vehicle is not an Active Vehicle, it can not be signed out", "Please Change", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If txtAvailable.Text = "NO" Then
            MessageBox.Show("The Vehicle is not Available, please Sign Vehicle in First", "Please Change", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        cboVehicleID.Visible = True

        'Loading up Variables and Textboxes
        intEmployeeID = CInt(cboEmployeeID.Text)
        txtAvailable.Text = "NO"
        txtEmployeeID.Text = CStr(intEmployeeID)
        strFirstName = CStr(txtFirstName.Text)
        strLastName = CStr(txtLastName.Text)
        strBJCNumber = CStr(txtBJCNumber.Text)
        intVehicleID = CInt(cboVehicleID.Text)

        mintVehicleID = CInt(intVehicleID)
        mintEmployeeID = CInt(cboEmployeeID.Text)
        mstrLogDateTime = strLogDateTime
        mintBJCNumber = CInt(txtBJCNumber.Text)
        mstrNotes = "VEHICLE SIGNED OUT"

        'Updating the Database
        Try
            TheVehiclesBindingSource.EndEdit()
            TheVehiclesDataTier.UpdateDB(TheVehiclesDataSet)
            addingBoolean = False
            editingBoolean = False
            setControlsReadOnly(True)
            ResetButtonAfterEditing()
            setComboBoxBinding()
            cboVehicleID.SelectedIndex = previousSelectedIndex

        Catch ex As Exception
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        AddingVehicleHistory.Show()

        cboVehicleID.Visible = False

        'Outputting a Message to the User
        strSignOutMessage = "Vehicle " + strBJCNumber + " Was Signed Out" + vbNewLine
        strSignOutMessage = strSignOutMessage + "By " + strFirstName + " " + strLastName + vbNewLine

        MessageBox.Show(strSignOutMessage, "Thank You", MessageBoxButtons.OK, MessageBoxIcon.Information)

        'Setting up the form for the next Tool
        txtBJCNumberEntered.Text = ""
        txtEmployeeIDSearch.Text = ""
        txtLastNameSearch.Text = ""
        btnSignOut.Enabled = False
        btnSearchByEmployeeID.Enabled = False
        btnSearchByEmployeeLastName.Enabled = False
        btnNext.Enabled = False
        btnBack.Enabled = False
        txtLastName.Visible = False
        txtFirstName.Visible = False
        txtPhoneNumber.Visible = False


    End Sub

    Private Sub btnSignOut_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSignOut.Click
        'This routine will sign out a tool
        Dim intEmployeeID As Integer
        Dim strFirstName As String
        Dim strLastName As String
        Dim strBJCNumber As String
        Dim strSignOutMessage As String
        Dim intVehicleID As Integer

        'Performing Data Validation
        If txtActive.Text = "NO" Then
            MessageBox.Show("The Vehicle is not an Active Vehicle, it can not be signed out", "Please Change", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If txtAvailable.Text = "NO" Then
            MessageBox.Show("The Vehicle is not Available, please Sign Vehicle in First", "Please Change", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If mstrOutOfTownSetting = "FALSE" Then
            MessageBox.Show("The Vehicle Location Setting Was Not Selected", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        PleaseWait.Show()

        cboVehicleID.Visible = True

        'Loading up Variables and Textboxes
        intEmployeeID = CInt(cboEmployeeID.Text)
        txtAvailable.Text = "NO"
        txtEmployeeID.Text = CStr(intEmployeeID)
        strFirstName = CStr(txtFirstName.Text)
        strLastName = CStr(txtLastName.Text)
        strBJCNumber = CStr(txtBJCNumber.Text)
        intVehicleID = CInt(cboVehicleID.Text)

        Logon.mintVehicleID = CInt(intVehicleID)
        Logon.mintHistoryEmployeeID = CInt(cboEmployeeID.Text)
        Logon.mstrLogDateTime = strLogDateTime
        Logon.mintBJCNumber = CInt(txtBJCNumber.Text)
        Logon.mstrNotes = "VEHICLE SIGNED OUT"
        Logon.mstrRemoteVehicle = txtOutOfTown.Text
        mstrOutOfTownSetting = "FALSE"
        rdoLocalVehicle.Checked = False
        rdoRemoteVehicle.Checked = False

        'Updating the Database
        Try
            TheVehiclesBindingSource.EndEdit()
            TheVehiclesDataTier.UpdateDB(TheVehiclesDataSet)
            addingBoolean = False
            editingBoolean = False
            setControlsReadOnly(True)
            ResetButtonAfterEditing()
            setComboBoxBinding()
            cboVehicleID.SelectedIndex = previousSelectedIndex

        Catch ex As Exception
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        AddingVehicleHistory.Show()
        AutoVehicleSignedOutSheet.Show()

        cboVehicleID.Visible = False

        PleaseWait.Close()

        'Outputting a Message to the User
        strSignOutMessage = "Vehicle " + strBJCNumber + " Was Signed Out" + vbNewLine
        strSignOutMessage = strSignOutMessage + "By " + strFirstName + " " + strLastName + vbNewLine

        MessageBox.Show(strSignOutMessage, "Thank You", MessageBoxButtons.OK, MessageBoxIcon.Information)

        'Setting up the form for the next Tool
        txtBJCNumberEntered.Text = ""
        txtEmployeeIDSearch.Text = ""
        txtLastNameSearch.Text = ""
        btnSignOut.Enabled = False
        btnSearchByEmployeeID.Enabled = False
        btnSearchByEmployeeLastName.Enabled = False
        btnNext.Enabled = False
        btnBack.Enabled = False
        txtLastName.Visible = False
        txtFirstName.Visible = False
        txtPhoneNumber.Visible = False

    End Sub

    Private Sub ClearDataBindings()

        cboEmployeeID.DataBindings.Clear()
        txtFirstName.DataBindings.Clear()
        txtLastName.DataBindings.Clear()
        txtPhoneNumber.DataBindings.Clear()

        cboVehicleID.DataBindings.Clear()
        txtBJCNumber.DataBindings.Clear()
        txtYear.DataBindings.Clear()
        txtMake.DataBindings.Clear()
        txtModel.DataBindings.Clear()
        txtLicencePlate.DataBindings.Clear()
        txtEmployeeID.DataBindings.Clear()
        txtDate.DataBindings.Clear()
        txtNotes.DataBindings.Clear()
        txtAvailable.DataBindings.Clear()
        txtActive.DataBindings.Clear()

    End Sub

    
    Private Sub rdoLocalVehicle_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdoLocalVehicle.Click

        'This will set the Out of town text box
        mstrOutOfTownSetting = "NO"
        txtOutOfTown.Text = mstrOutOfTownSetting

    End Sub

    Private Sub rdoRemoteVehicle_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdoRemoteVehicle.Click

        'This will set the Out of town text box
        mstrOutOfTownSetting = "YES"
        txtOutOfTown.Text = mstrOutOfTownSetting

    End Sub
End Class