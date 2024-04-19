'Name:          Terry Holmes
'Date:          9/25/14
'Author:        Terry Holmes

'Description:   This form is used to Issue Out an Information Technology Device

Option Strict On

Public Class IssueInformationTechnologyDevice

    'Setting up global data sources
    Private TheInformationTechnologyDevicesDataSet As InformationTechnologyDevicesDataSet
    Private TheInformationTechnologyDevicesDataTier As InformationTechnologyDataTier
    Private WithEvents TheInformationTechnologyDevicesBindingSource As New BindingSource

    Private TheEmployeeDataSet As EmployeeDataSet
    Private TheEmployeeDataTier As EmployeeDataTier
    Private WithEvents TheEmployeeBindingSource As BindingSource

    Dim LogDateTime As Date = DateAndTime.Now
    Dim strLogDateTime As String

    'Setting global variables
    Dim TheInputDataValidation As New InputDataValidation
    Dim mstrDeviceType As String

    'Setting up a global array
    Dim mintDeviceCounter As Integer
    Dim mintDeviceSelectedIndex() As Integer
    Dim mintDeviceUpperLimit As Integer

    Dim mintEmployeeCounter As Integer
    Dim mintEmployeeSelectedIndex() As Integer
    Dim mintEmployeeUpperLimit As Integer

    Dim mintEmployeeIDSelected As Integer
    Dim mstrEmployeeLastName As String
    Dim mstrEmployeeFirstName As String
    Dim mstrDeviceInformation As String

    Private Sub SetDeviceControlsReadOnly(ByVal valueBoolean As Boolean)

        'This will set these controls to read only
        txtComputerName.ReadOnly = valueBoolean
        txtManufacturer.ReadOnly = valueBoolean
        txtModel.ReadOnly = valueBoolean
        txtNotes.ReadOnly = valueBoolean
        txtPhoneNumber.ReadOnly = valueBoolean
        txtSerialNumber.ReadOnly = valueBoolean

    End Sub
    Private Sub btnMainMenu_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMainMenu.Click

        'This will run when the Main Menu button is pressed
        LastTransaction.Show()
        MainMenu.Show()
        Me.Close()

    End Sub

    Private Sub btnClose_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        'Closes the Program
        CloseTheProgram.ShowDialog()

    End Sub

    Private Sub btnInformationTechnologyMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInformationTechnologyMenu.Click

        'Displays the Information Technology Menu
        LastTransaction.Show()
        InformationTechnologyMenu.Show()
        Me.Close()

    End Sub


    Private Sub IssueInformationTechnologyDevice_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Setting local variable
        Dim intNumberOfRecords As Integer
        Logon.mstrLastTransactionSummary = "LOADED ISSUE INFORMATION TECHNOLOGY DEVICES"

        'This will load up the employee controls
        Try

            'Setting up the global data containers
            TheEmployeeDataTier = New EmployeeDataTier
            TheEmployeeDataSet = TheEmployeeDataTier.GetEmployeeInformation
            TheEmployeeBindingSource = New BindingSource

            'Setting up the binding source
            With TheEmployeeBindingSource
                .DataSource = TheEmployeeDataSet
                .DataMember = "employees"
                .MoveFirst()
                .MoveLast()
            End With

            'Setting up the combo box
            With cboEmployeeID
                .DataSource = TheEmployeeBindingSource
                .DisplayMember = "EmployeeID"
                .DataBindings.Add("text", TheEmployeeBindingSource, "EmployeeID", False, DataSourceUpdateMode.Never)
            End With

            'Binding remaining controls
            txtEmployeeActive.DataBindings.Add("text", TheEmployeeBindingSource, "Active")
            txtEmployeeFirstName.DataBindings.Add("text", TheEmployeeBindingSource, "FirstName")
            txtEmployeeLastName.DataBindings.Add("text", TheEmployeeBindingSource, "LastName")

            'Setting the array
            intNumberOfRecords = cboEmployeeID.Items.Count - 1
            ReDim mintEmployeeSelectedIndex(intNumberOfRecords)

            EmployeeControlsVisible(False)

            'Performing load for information technology

            'Setting up the datasets
            TheInformationTechnologyDevicesDataTier = New InformationTechnologyDataTier
            TheInformationTechnologyDevicesDataSet = TheInformationTechnologyDevicesDataTier.GetInformationTechnologyDevicesInformation
            TheInformationTechnologyDevicesBindingSource = New BindingSource

            'Setting up the binding source
            With TheInformationTechnologyDevicesBindingSource
                .DataSource = TheInformationTechnologyDevicesDataSet
                .DataMember = "informationtechnologydevices"
                .MoveFirst()
                .MoveLast()
            End With

            'Setting up the combo box
            With cboDeviceID
                .DataSource = TheInformationTechnologyDevicesBindingSource
                .DisplayMember = "DeviceID"
                .DataBindings.Add("text", TheInformationTechnologyDevicesBindingSource, "DeviceID", False, DataSourceUpdateMode.Never)
            End With

            'Setting up the control bindings
            txtType.DataBindings.Add("text", TheInformationTechnologyDevicesBindingSource, "Type")
            txtManufacturer.DataBindings.Add("text", TheInformationTechnologyDevicesBindingSource, "Manufacturer")
            txtModel.DataBindings.Add("text", TheInformationTechnologyDevicesBindingSource, "Model")
            txtPhoneNumber.DataBindings.Add("text", TheInformationTechnologyDevicesBindingSource, "PhoneNumber")
            txtComputerName.DataBindings.Add("text", TheInformationTechnologyDevicesBindingSource, "ComputerName")
            txtSerialNumber.DataBindings.Add("text", TheInformationTechnologyDevicesBindingSource, "SerialNumber")
            txtEmployeeID.DataBindings.Add("text", TheInformationTechnologyDevicesBindingSource, "EmployeeID")
            txtAvailable.DataBindings.Add("text", TheInformationTechnologyDevicesBindingSource, "Available")
            txtActive.DataBindings.Add("text", TheInformationTechnologyDevicesBindingSource, "Active")
            txtDate.DataBindings.Add("text", TheInformationTechnologyDevicesBindingSource, "Date")
            txtNotes.DataBindings.Add("text", TheInformationTechnologyDevicesBindingSource, "Notes")

            'Setting the array
            intNumberOfRecords = cboDeviceID.Items.Count - 1
            ReDim mintDeviceSelectedIndex(intNumberOfRecords)

            SearchForDeviceControlsVisible(False)
            DeviceControlsVisible(False)
            txtEmployeeLastNameEntered.Focus()
            btnIssueDevice.Enabled = False

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub EmployeeControlsVisible(ByVal valueBoolean As Boolean)

        'This will make the controls visible
        txtEmployeeActive.Visible = valueBoolean
        txtEmployeeLastName.Visible = valueBoolean
        txtEmployeeFirstName.Visible = valueBoolean
        btnNext.Visible = valueBoolean
        btnBack.Visible = valueBoolean
        btnSelect.Visible = valueBoolean

    End Sub
    Private Sub SearchForDeviceControlsVisible(ByVal valueBoolean As Boolean)

        'This will make the controls for the finding the device visible
        txtFindDevice.Visible = valueBoolean
        btnFindDevice.Visible = valueBoolean

    End Sub
    Private Sub DeviceControlsVisible(ByVal valueBoolean As Boolean)

        'This will make the device controls visible
        txtType.Visible = valueBoolean
        txtManufacturer.Visible = valueBoolean
        txtModel.Visible = valueBoolean
        txtPhoneNumber.Visible = valueBoolean
        txtComputerName.Visible = valueBoolean
        txtSerialNumber.Visible = valueBoolean
        txtEmployeeID.Visible = valueBoolean
        txtAvailable.Visible = valueBoolean
        txtActive.Visible = valueBoolean
        txtDate.Visible = valueBoolean
        txtNotes.Visible = valueBoolean

    End Sub

    Private Sub btnFindEmployee_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindEmployee.Click

        'This sub-routine will find the employee
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim strLastNameForSearch As String
        Dim strLastNameFromTable As String
        Dim blnFatalError As Boolean = False
        Dim blnLastNameNotFound As Boolean = True
        Dim strActiveFromTable As String

        'Deactivating the buttons
        btnNext.Enabled = False
        btnBack.Enabled = False
        btnSelect.Enabled = False

        'Performing Data Validation
        strLastNameForSearch = txtEmployeeLastNameEntered.Text
        blnFatalError = TheInputDataValidation.VerifyTextData(strLastNameForSearch)

        'Outputting to the user if there is a problem
        If blnFatalError = True Then
            txtEmployeeLastNameEntered.Text = ""
            MessageBox.Show("The Employee's Last Was Not Entered", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        'Making Controls Visible
        EmployeeControlsVisible(True)

        'Preparing to begin loop
        intNumberOfRecords = cboEmployeeID.Items.Count - 1
        mintEmployeeCounter = 0

        'Beginning Loop
        For intCounter = 0 To intNumberOfRecords

            'Getting information for if statements
            cboEmployeeID.SelectedIndex = intCounter
            strLastNameFromTable = txtEmployeeLastName.Text
            strActiveFromTable = txtEmployeeActive.Text

            'Preparing If Statements
            If strLastNameForSearch = strLastNameFromTable Then
                If strActiveFromTable = "YES" Then

                    'Setting up the array
                    mintEmployeeSelectedIndex(mintEmployeeCounter) = intCounter
                    mintEmployeeCounter += 1
                    blnLastNameNotFound = False

                End If
            End If
        Next

        'Message to user if Last Name Found
        If blnLastNameNotFound = True Then
            txtEmployeeLastNameEntered.Text = ""
            MessageBox.Show("Last Name Entered Not Found", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        'Setting up the navigation buttons
        mintEmployeeUpperLimit = mintEmployeeCounter - 1
        mintEmployeeCounter = 0

        'Enabling the buttons
        If mintEmployeeUpperLimit > 0 Then
            btnNext.Enabled = True
        End If

        'Setting up the combo box
        cboEmployeeID.SelectedIndex = mintEmployeeSelectedIndex(0)

        'Enabling the select button
        btnSelect.Enabled = True

        SearchForEmployeeControls(False)

    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click

        'This will increment the counter
        mintEmployeeCounter += 1

        'Setting up the combo box
        cboEmployeeID.SelectedIndex = mintEmployeeSelectedIndex(mintEmployeeCounter)

        'Enabling the button
        btnBack.Enabled = True

        'Checking to see if the button should be disabled
        If mintEmployeeCounter = mintEmployeeUpperLimit Then
            btnNext.Enabled = False
        End If

    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click

        'This will decrement the counter
        mintEmployeeCounter -= 1

        'Setting up the combo box
        cboEmployeeID.SelectedIndex = mintEmployeeSelectedIndex(mintEmployeeCounter)

        'Enabling the button
        btnNext.Enabled = True

        'Checking to see if the button should be disabled
        If mintEmployeeCounter = 0 Then
            btnBack.Enabled = False
        End If

    End Sub

    Private Sub txtEmployeeLastNameEntered_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEmployeeLastNameEntered.KeyDown

        'This will activate when the key is pressed
        If e.KeyData = Keys.Enter Then
            btnFindEmployee.PerformClick()
        End If

    End Sub
    Private Sub SearchForEmployeeControls(ByVal valueBoolean As Boolean)

        btnFindEmployee.Visible = valueBoolean
        txtEmployeeLastNameEntered.Visible = valueBoolean

    End Sub

    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click

        'This will run when the user Clicks on the Select Button
        mintEmployeeIDSelected = CInt(cboEmployeeID.Text)
        mstrEmployeeFirstName = txtEmployeeFirstName.Text
        mstrEmployeeLastName = txtEmployeeLastName.Text
        SearchForDeviceControlsVisible(True)
        EmployeeControlsVisible(False)

    End Sub

    Private Sub btnResetForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetForm.Click

        'This will reset the form to initial conditions
        SearchForEmployeeControls(True)
        SearchForDeviceControlsVisible(False)
        DeviceControlsVisible(False)
        EmployeeControlsVisible(False)
        btnIssueDevice.Enabled = False
        txtEmployeeLastNameEntered.Text = ""

    End Sub

    Private Sub btnFindDevice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindDevice.Click

        'Setting local variables
        Dim intNumberOfRecords As Integer
        Dim intCounter As Integer
        Dim strDeviceForSearch As String
        Dim strDeviceFromTable As String
        Dim blnFatalError As Boolean = False
        Dim blnDeviceNotFound As Boolean = True
        Dim strActiveFromTable As String
        Dim strAvailableFromTable As String

        'Setting up data validation
        strDeviceForSearch = txtFindDevice.Text
        blnFatalError = TheInputDataValidation.VerifyTextData(strDeviceForSearch)

        'Outputting if there is a problem with data validation
        If blnFatalError = True Then
            txtFindDevice.Text = ""
            MessageBox.Show("Device Information Was Not Entered", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        'Setting Device Controls Visible
        DeviceControlsVisible(True)

        'Beginning search, first with phone number
        intNumberOfRecords = cboDeviceID.Items.Count - 1
        mintDeviceCounter = 0

        'Beginning first loop searching for phone number
        For intCounter = 0 To intNumberOfRecords

            'Loading variables for if statements
            cboDeviceID.SelectedIndex = intCounter
            strDeviceFromTable = txtPhoneNumber.Text
            strAvailableFromTable = txtAvailable.Text
            strActiveFromTable = txtActive.Text

            If strActiveFromTable = "YES" Then
                If strAvailableFromTable = "YES" Then
                    If strDeviceForSearch = strDeviceFromTable Then

                        'Setting Global Array
                        mintDeviceSelectedIndex(mintDeviceCounter) = intCounter
                        mintDeviceCounter += 1
                        blnDeviceNotFound = False

                    End If
                End If
            End If

        Next

        'Second Loop if this is not a phone
        If blnDeviceNotFound = True Then

            'Beginning first loop searching for Computer Name
            For intCounter = 0 To intNumberOfRecords

                'Loading variables for if statements
                cboDeviceID.SelectedIndex = intCounter
                strDeviceFromTable = txtComputerName.Text
                strAvailableFromTable = txtAvailable.Text
                strActiveFromTable = txtActive.Text

                If strActiveFromTable = "YES" Then
                    If strAvailableFromTable = "YES" Then
                        If strDeviceForSearch = strDeviceFromTable Then

                            'Setting Global Array
                            mintDeviceSelectedIndex(mintDeviceCounter) = intCounter
                            mintDeviceCounter += 1
                            blnDeviceNotFound = False

                        End If
                    End If
                End If
            Next
        End If

        'Message Box to user if device is not found or available
        If blnDeviceNotFound = True Then

            txtFindDevice.Text = ""
            DeviceControlsVisible(False)
            MessageBox.Show("Device Entered Does Not Exist or is Signed Out", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub

        End If

        'Setting up for the final steps
        mintDeviceUpperLimit = mintDeviceCounter - 1
        mintDeviceCounter = 0

        If mintDeviceUpperLimit > 0 Then
            txtFindDevice.Text = ""
            DeviceControlsVisible(False)
            MessageBox.Show("There are Multiple Devices With The Same Information, Please Edit the Devices", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        mstrDeviceInformation = strDeviceForSearch

        'Sets combo box for the device
        cboDeviceID.SelectedIndex = mintDeviceSelectedIndex(0)
        btnIssueDevice.Enabled = True
        SearchForDeviceControlsVisible(False)

    End Sub

    Private Sub btnIssueDevice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIssueDevice.Click

        'This routine makes changes to the Information Technology Devices table

        'Setting up controls
        txtEmployeeID.Text = CStr(mintEmployeeIDSelected)
        strLogDateTime = CStr(LogDateTime)
        txtDate.Text = strLogDateTime
        txtAvailable.Text = "NO"

        mstrDeviceType = txtType.Text

        'Setting up the Global variables
        Logon.mstrNotes = "SIGNED OUT"
        Logon.mintEmployeeID = CInt(txtEmployeeID.Text)
        Logon.mintDeviceID = CInt(cboDeviceID.Text)

        'Calling the History Form
        AddInformationTechnologyHistory.Show()
        AddInformationTechnologyAccessories.ShowDialog()

        'Updating the Data Set
        Try

            TheInformationTechnologyDevicesBindingSource.EndEdit()
            TheInformationTechnologyDevicesDataTier.UpdateInformationTechnologyDevicesDB(TheInformationTechnologyDevicesDataSet)
            MessageBox.Show(mstrDeviceType + " " + mstrDeviceInformation + " Was Signed Out to " + mstrEmployeeFirstName + " " + mstrEmployeeLastName, "Thank You", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnResetForm.PerformClick()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
End Class