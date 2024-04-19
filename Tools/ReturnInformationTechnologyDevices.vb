'Title:         Return Information Technology Devices
'Date:          10/7/14
'Author:        Terry Holmes

'Description:   This form will return information technology devices

Option Strict On

Public Class ReturnInformationTechnologyDevices

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
    Private Sub SetDeviceControlsReadOnly(ByVal valueBoolean As Boolean)

        'This will set these controls to read only
        txtComputerName.ReadOnly = valueBoolean
        txtManufacturer.ReadOnly = valueBoolean
        txtModel.ReadOnly = valueBoolean
        txtNotes.ReadOnly = valueBoolean
        txtPhoneNumber.ReadOnly = valueBoolean
        txtSerialNumber.ReadOnly = valueBoolean

    End Sub

    Private Sub ReturnInformationTechnologyDevices_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Setting local variables
        Dim intNumberOfRecords As Integer
        Logon.mstrLastTransactionSummary = "LOADED RETURN INFORMATION TECHNOLOGY DEVICES"

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

            'Setting up the array
            intNumberOfRecords = cboDeviceID.Items.Count - 1
            ReDim mintDeviceSelectedIndex(intNumberOfRecords)

            DeviceControlsVisible(False)
            txtEmployeeLastNameEntered.Focus()
            btnReturnDevice.Enabled = False

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
            MessageBox.Show("Employee's Last Name Was Not Entered", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
    Private Sub SearchForEmployeeControls(ByVal valueBoolean As Boolean)

        btnFindEmployee.Visible = valueBoolean
        txtEmployeeLastNameEntered.Visible = valueBoolean

    End Sub
    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click

        'This routine will find all the devices that are active and are assigned to an employee

        'Setting Local Variables
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim intEmployeeIDForSearch As Integer
        Dim intEmployeeIDFromTable As Integer
        Dim strActiveFromTable As String
        Dim strAvailableFromTable As String
        Dim blnNoDevicesFound As Boolean = True

        'This will set the controls visible
        DeviceControlsVisible(True)

        btnDeviceBack.Enabled = False
        btnDeviceNext.Enabled = False

        'This will set up for the search
        intNumberOfRecords = cboDeviceID.Items.Count - 1
        intEmployeeIDForSearch = CInt(cboEmployeeID.Text)
        mintDeviceCounter = 0
        mintDeviceUpperLimit = 0

        'Preforming loop
        For intCounter = 0 To intNumberOfRecords

            'Setting up variables for compare
            cboDeviceID.SelectedIndex = intCounter
            intEmployeeIDFromTable = CInt(txtEmployeeID.Text)
            strActiveFromTable = txtActive.Text
            strAvailableFromTable = txtAvailable.Text

            'Preforming If Statements
            If intEmployeeIDForSearch = intEmployeeIDFromTable Then
                If strActiveFromTable = "YES" Then
                    If strAvailableFromTable = "NO" Then

                        'Setting the array up
                        mintDeviceSelectedIndex(mintDeviceCounter) = intCounter
                        mintDeviceCounter += 1
                        blnNoDevicesFound = False

                    End If
                End If
            End If
        Next

        If blnNoDevicesFound = True Then
            DeviceControlsVisible(False)
            MessageBox.Show("No Devices Issued To This Employee", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        'Providing the finishing touches
        mintDeviceUpperLimit = mintDeviceCounter - 1
        mintDeviceCounter = 0

        If mintDeviceUpperLimit > 0 Then
            btnDeviceNext.Enabled = True
        End If

        cboDeviceID.SelectedIndex = mintDeviceSelectedIndex(0)
        btnReturnDevice.Enabled = True

    End Sub

    Private Sub btnDeviceNext_Click(sender As System.Object, e As System.EventArgs) Handles btnDeviceNext.Click

        'Increment the counter
        mintDeviceCounter += 1
        cboDeviceID.SelectedIndex = mintDeviceSelectedIndex(mintDeviceCounter)

        'Finds the employee
        FindEmployees()

        'Setting up the other navigation button
        btnDeviceBack.Enabled = True

        'Disabling this button
        If mintDeviceCounter = mintDeviceUpperLimit Then
            btnDeviceNext.Enabled = False
        End If

    End Sub

    Private Sub btnDeviceBack_Click(sender As System.Object, e As System.EventArgs) Handles btnDeviceBack.Click


        'Decrement the counter
        mintDeviceCounter -= 1
        cboDeviceID.SelectedIndex = mintDeviceSelectedIndex(mintDeviceCounter)

        'Find the employee
        FindEmployees()

        'Setting up the other navigation button
        btnDeviceNext.Enabled = True

        'Disabling this button
        If mintDeviceCounter = 0 Then
            btnDeviceBack.Enabled = False
        End If
    End Sub

    Private Sub btnFindDevice_Click(sender As System.Object, e As System.EventArgs) Handles btnFindDevice.Click

        'This will a specific device

        'Setting up local variables
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim strDeviceNameForSearch As String
        Dim strDeviceNameFromTable As String
        Dim strActiveFromTable As String
        Dim strAvailableFromTable As String
        Dim blnFatalError As Boolean
        Dim blnDeviceNotFound As Boolean = True
        Dim blnNotAPhoneNumber As Boolean

        'Performming data validation
        strDeviceNameForSearch = txtFindDevice.Text
        blnFatalError = TheInputDataValidation.VerifyTextData(strDeviceNameForSearch)

        If blnFatalError = True Then
            txtFindDevice.Text = ""
            MessageBox.Show("Device Information Was Not Entered", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        DeviceControlsVisible(True)

        'Setting up the for the loop
        intNumberOfRecords = cboDeviceID.Items.Count - 1
        mintDeviceCounter = 0
        mintDeviceUpperLimit = 0

        'Performing Loop
        For intCounter = 0 To intNumberOfRecords

            'Setting up the variables for the If statements
            cboDeviceID.SelectedIndex = intCounter
            strActiveFromTable = txtActive.Text
            strAvailableFromTable = txtAvailable.Text
            blnNotAPhoneNumber = True

            'Checking to see if this a phone number
            strDeviceNameFromTable = txtPhoneNumber.Text

            If strDeviceNameForSearch = strDeviceNameFromTable Then
                If strActiveFromTable = "YES" Then
                    If strAvailableFromTable = "NO" Then

                        'Setting up the array
                        mintDeviceSelectedIndex(mintDeviceCounter) = intCounter
                        mintDeviceCounter += 1
                        blnDeviceNotFound = False
                        blnNotAPhoneNumber = False

                    End If
                End If
            End If

            'Checking to see if this a computer
            If blnNotAPhoneNumber = True Then

                'Getting computer Name
                strDeviceNameFromTable = txtComputerName.Text

                If strDeviceNameForSearch = strDeviceNameFromTable Then
                    If strActiveFromTable = "YES" Then
                        If strAvailableFromTable = "NO" Then

                            'Setting up the array
                            mintDeviceSelectedIndex(mintDeviceCounter) = intCounter
                            mintDeviceCounter += 1
                            blnDeviceNotFound = False
                            blnNotAPhoneNumber = False

                        End If
                    End If
                End If
            End If
        Next

        If blnDeviceNotFound = True Then
            DeviceControlsVisible(False)
            txtFindDevice.Text = ""
            MessageBox.Show("The Device Entered Was Not Issued or Does Not Exist", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        'Putting on the final touches
        mintDeviceUpperLimit = mintDeviceCounter - 1
        mintDeviceCounter = 0

        If mintDeviceUpperLimit > 0 Then
            btnDeviceNext.Enabled = True
        End If

        cboDeviceID.SelectedIndex = mintDeviceSelectedIndex(0)
        btnReturnDevice.Enabled = True
        EmployeeControlsVisible(True)
        FindEmployees()
        btnReturnDevice.Enabled = True

    End Sub

    Private Sub btnResetForm_Click(sender As System.Object, e As System.EventArgs) Handles btnResetForm.Click

        'This routine will reset the form
        txtFindDevice.Text = ""
        txtEmployeeLastNameEntered.Text = ""
        EmployeeControlsVisible(False)
        DeviceControlsVisible(False)
        btnReturnDevice.Enabled = False
        SearchForEmployeeControls(True)

    End Sub
    Private Sub FindEmployees()

        'This sub routine will find employees

        'Setting up local variables
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim intSelectedIndex As Integer
        Dim intEmployeeIDForSearch As Integer
        Dim intEmployeeIDFromTable As Integer

        'Setting up for the search
        intNumberOfRecords = cboEmployeeID.Items.Count - 1
        intEmployeeIDForSearch = CInt(txtEmployeeID.Text)

        'For Loop
        For intCounter = 0 To intNumberOfRecords

            'Setting to find Employee ID
            cboEmployeeID.SelectedIndex = intCounter
            intEmployeeIDFromTable = CInt(cboEmployeeID.Text)

            If intEmployeeIDForSearch = intEmployeeIDFromTable Then
                intSelectedIndex = intCounter
            End If

        Next

        'Setting up combo box
        cboEmployeeID.SelectedIndex = intSelectedIndex

    End Sub

    Private Sub btnReturnDevice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReturnDevice.Click


        'This sub-routine is used to return items to 
        Logon.mintEmployeeID = CInt(txtEmployeeID.Text)
        Logon.mdatDate = LogDateTime
        ReturnInformationTechnologyDeviceAccessories.ShowDialog()

        If Logon.mbolFatalError = True Then
            MessageBox.Show("No Accessories Were Returned", "Sorry", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
        End If

        'Setting Text for returning item
        txtEmployeeID.Text = CStr(Logon.mintHomeOfficeID)
        txtAvailable.Text = "YES"
        txtDate.Text = CStr(LogDateTime)


        'Setting up the Global variables
        Logon.mstrNotes = "SIGNED IN"
        Logon.mintEmployeeID = CInt(txtEmployeeID.Text)
        Logon.mintDeviceID = CInt(cboDeviceID.Text)

        'Calling the History Form
        AddInformationTechnologyHistory.Show()

        'Updating the dataset and setting the form for more entry
        Try
            TheInformationTechnologyDevicesBindingSource.EndEdit()
            TheInformationTechnologyDevicesDataTier.UpdateInformationTechnologyDevicesDB(TheInformationTechnologyDevicesDataSet)
            txtFindDevice.Text = ""
            txtEmployeeLastNameEntered.Text = ""
            DeviceControlsVisible(False)
            EmployeeControlsVisible(False)
            SearchForEmployeeControls(True)
            MessageBox.Show("The Device Has Been Returned", "Thank You", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
End Class