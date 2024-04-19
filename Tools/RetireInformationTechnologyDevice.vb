'Title:         Retire Information Technology Device
'Date:          9/30/14
'Author:        Terry Holmes

'Description:   This form is used to retire devices

Option Strict On

Public Class RetireInformationTechnologyDevice

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

    Private Sub btnMainMenu_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMainMenu.Click

        'This will run when the Main Menu button is pressed
        MainMenu.Show()
        Me.Close()

    End Sub

    Private Sub btnClose_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        'Closes the Program
        CloseTheProgram.ShowDialog()

    End Sub

    Private Sub btnInformationTechnologyMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInformationTechnologyMenu.Click

        'Displays the Information Technology Menu
        InformationTechnologyMenu.Show()
        Me.Close()

    End Sub
    Private Sub SetDeviceBindings()

        'set local variables
        Dim intNumberOfRecords As Integer

        Try

            'Setting up the data controls for information technology device
            TheInformationTechnologyDevicesDataTier = New InformationTechnologyDataTier
            TheInformationTechnologyDevicesDataSet = TheInformationTechnologyDevicesDataTier.GetInformationTechnologyDevicesInformation
            TheInformationTechnologyDevicesBindingSource = New BindingSource

            'Setting up the Binding Source for information technology
            With TheInformationTechnologyDevicesBindingSource
                .DataSource = TheInformationTechnologyDevicesDataSet
                .DataMember = "informationtechnologydevices"
                .MoveFirst()
                .MoveLast()
            End With

            'Setting up the Combo Box for Information Technology
            With cboDeviceID
                .DataSource = TheInformationTechnologyDevicesBindingSource
                .DisplayMember = "DeviceID"
                .DataBindings.Add("text", TheInformationTechnologyDevicesBindingSource, "DeviceID", False, DataSourceUpdateMode.Never)
            End With

            'Binding the Rest of the controls for information technology
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

            'redimensioning the array
            intNumberOfRecords = cboDeviceID.Items.Count - 1
            ReDim mintDeviceSelectedIndex(intNumberOfRecords)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct Device Bindings", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub RetireInformationTechnologyDevice_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Calling sub-routine to set up the controls
        SetDeviceBindings()
        DeviceControlVisible(False)

    End Sub
    Private Sub FindDevices()

        'This routine will run to find a type of device

        'Setting Local Variables
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim strDeviceTypeForSearch As String
        Dim strDeviceTypeFromTable As String
        Dim strActiveFromTable As String
        Dim strAvailableFromTable As String
        Dim blnDeviceNotFound As Boolean = True

        'Setting initial conditions
        DeviceControlVisible(True)
        btnNext.Enabled = False
        btnBack.Enabled = False

        'Setting up conditions
        intNumberOfRecords = cboDeviceID.Items.Count - 1
        strDeviceTypeForSearch = mstrDeviceType
        mintDeviceCounter = 0
        mintDeviceUpperLimit = 0

        'Beginning Loop
        For intCounter = 0 To intNumberOfRecords

            'This will load up the variables
            cboDeviceID.SelectedIndex = intCounter
            strDeviceTypeFromTable = txtType.Text
            strActiveFromTable = txtActive.Text
            strAvailableFromTable = txtAvailable.Text

            'Performing a series of if statements
            If strDeviceTypeForSearch = strDeviceTypeFromTable Then
                If strActiveFromTable = "YES" Then
                    If strAvailableFromTable = "YES" Then
                        mintDeviceSelectedIndex(mintDeviceCounter) = intCounter
                        mintDeviceCounter += 1
                        blnDeviceNotFound = False
                    End If
                End If
            End If

        Next

        'displaying message to user if there is a problem
        If blnDeviceNotFound = True Then
            DeviceControlVisible(False)
            MessageBox.Show("No Devices Found, Device Could Be Retired, Still Issued, or Not Exist", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        'setting upper limits
        mintDeviceUpperLimit = mintDeviceCounter - 1
        mintDeviceCounter = 0

        'Enabling the next button
        If mintDeviceUpperLimit > 0 Then
            btnNext.Enabled = True
        End If

        'placing the combo box to the proper index
        cboDeviceID.SelectedIndex = mintDeviceSelectedIndex(0)
        btnSelect.Enabled = True

    End Sub

    Private Sub rdoMobilePhone_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdoMobilePhone.Click

        'Sets the controls to visible and readonly
        mstrDeviceType = "MOBILE"

        FindDevices()

    End Sub

    Private Sub rdoAirCard_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdoAirCard.Click

        'Sets the controls to visible and readonly
        mstrDeviceType = "AIRCARD"

        FindDevices()

    End Sub

    Private Sub rdoLaptopComputer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdoLaptopComputer.Click

        'Sets the controls to visible and readonly
        mstrDeviceType = "LAPTOP"

        FindDevices()

    End Sub

    Private Sub rdoDesktopComputer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdoDesktopComputer.Click

        'Sets the controls to visible and readonly
        mstrDeviceType = "DESKTOP"

        'This will determine which subroutine to run
        FindDevices()
        

    End Sub
    Private Sub rdoTablet_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdoTablet.Click

        'Sets the controls to visible and readonly
        mstrDeviceType = "TABLET"

        FindDevices()


    End Sub
    Private Sub DeviceControlVisible(ByVal valueBoolean As Boolean)

        'This will make the controls visible
        txtActive.Visible = valueBoolean
        txtAvailable.Visible = valueBoolean
        txtComputerName.Visible = valueBoolean
        txtDate.Visible = valueBoolean
        txtEmployeeID.Visible = valueBoolean
        txtManufacturer.Visible = valueBoolean
        txtModel.Visible = valueBoolean
        txtNotes.Visible = valueBoolean
        txtPhoneNumber.Visible = valueBoolean
        txtSerialNumber.Visible = valueBoolean
        txtType.Visible = valueBoolean
        btnBack.Visible = valueBoolean
        btnNext.Visible = valueBoolean
        btnSelect.Visible = valueBoolean

    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click

        'This will increment the global counter
        mintDeviceCounter += 1

        'Setting the combo box
        cboDeviceID.SelectedIndex = mintDeviceSelectedIndex(mintDeviceCounter)

        'Setting the button condition
        btnBack.Enabled = True

        If mintDeviceCounter = mintDeviceUpperLimit Then
            btnNext.Enabled = False
        End If

    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click

        'This will decrement the counter
        mintDeviceCounter -= 1

        'Setting the Combo Box Selected Index
        cboDeviceID.SelectedIndex = mintDeviceSelectedIndex(mintDeviceCounter)

        'This will enable the Next Button
        btnNext.Enabled = True

        'This will disable the Next Button
        If mintDeviceCounter = 0 Then
            btnBack.Enabled = False
        End If

    End Sub

    Private Sub btnDeviceFindDevice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeviceFindDevice.Click

        'This sub-routine will find a device name by either the phone number or device name

        'Setting local variables
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim strDeviceInformationForSearch As String
        Dim strDeviceInformationFromTable As String = ""
        Dim strActiveFromTable As String
        Dim strAvailableFromTable As String
        Dim blnDeviceNotFound As Boolean = True
        Dim blnNotPhoneNUmber As Boolean = False
        Dim blnFatalError As Boolean

        btnNext.Enabled = False
        btnBack.Enabled = False

        'Performing Data Validation
        strDeviceInformationForSearch = txtDeviceFindInformation.Text
        blnFatalError = TheInputDataValidation.VerifyTextData(strDeviceInformationForSearch)

        'Outputting to user if Validation Fails
        If blnFatalError = True Then
            MessageBox.Show("Device Information Was not Entered", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        'Checking to see if information entered is a phone number
        blnNotPhoneNUmber = TheInputDataValidation.VerifyPhoneNumberFormat(strDeviceInformationForSearch)

        DeviceControlVisible(True)

        'Getting information for loop
        intNumberOfRecords = cboDeviceID.Items.Count - 1
        mintDeviceCounter = 0
        mintDeviceUpperLimit = 0

        'Perparing Loop
        For intCounter = 0 To intNumberOfRecords

            'Setting up for if statements
            cboDeviceID.SelectedIndex = intCounter
            strActiveFromTable = txtActive.Text
            strAvailableFromTable = txtAvailable.Text

            'deciding if it is a phone number
            If blnNotPhoneNUmber = True Then
                strDeviceInformationFromTable = txtComputerName.Text
            ElseIf blnNotPhoneNUmber = False Then
                strDeviceInformationFromTable = txtPhoneNumber.Text
            End If

            'Preforming If Statements
            If strDeviceInformationForSearch = strDeviceInformationFromTable Then
                If strActiveFromTable = "YES" Then
                    If strAvailableFromTable = "YES" Then
                        mintDeviceSelectedIndex(mintDeviceCounter) = intCounter
                        mintDeviceCounter += 1
                        blnDeviceNotFound = False
                    End If
                End If
            End If

        Next

        'Results of the Search

        'Outputted to user if no records are found
        If blnDeviceNotFound = True Then
            DeviceControlVisible(False)
            txtDeviceFindInformation.Text = ""
            MessageBox.Show("The Device Entered Was Not Found Or is Retired or Issued Out", "Please Try Again", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        'Setting up conditions
        mintDeviceUpperLimit = mintDeviceCounter - 1
        mintDeviceCounter = 0

        'Enabling buttons and message to User
        If mintDeviceUpperLimit > 0 Then
            MessageBox.Show("Multiple Devices Have Been Found, Please Ensure That You Select The Correct Device", "Thank You", MessageBoxButtons.OK, MessageBoxIcon.Error)
            btnNext.Enabled = True
        End If

        'Setting the combo box starting point
        cboDeviceID.SelectedIndex = mintDeviceSelectedIndex(0)

        btnSelect.Enabled = True

    End Sub

    Private Sub btnResetForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetForm.Click

        'This will set the form into default conditions
        ClearDeviceDataBindings()
        txtDeviceFindInformation.Text = ""
        SetDeviceBindings()
        DeviceControlVisible(False)


    End Sub
    Private Sub ClearDeviceDataBindings()

        'Clears all the Data Bindings
        cboDeviceID.DataBindings.Clear()
        txtActive.DataBindings.Clear()
        txtAvailable.DataBindings.Clear()
        txtDate.DataBindings.Clear()
        txtDeviceFindInformation.DataBindings.Clear()
        txtEmployeeID.DataBindings.Clear()
        txtManufacturer.DataBindings.Clear()
        txtModel.DataBindings.Clear()
        txtNotes.DataBindings.Clear()
        txtPhoneNumber.DataBindings.Clear()
        txtSerialNumber.DataBindings.Clear()
        txtType.DataBindings.Clear()
        txtComputerName.DataBindings.Clear()

    End Sub

    Private Sub btnRetireDevice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRetireDevice.Click

        'This sub routine will change the settings of the device

        'Verifying the user's choice
        DeviceRetirementConfirmation.ShowDialog()

        'If statement if the to see if the record is canceled
        If Logon.mblnDeviceConfirmation = False Then
            MessageBox.Show("The Process Has Been Canceled", "Thank You", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        'Setting conditions for editing the record
        txtActive.Text = "NO"
        txtAvailable.Text = "NO"

        'Saving the record
        Try
            'Saving the record
            TheInformationTechnologyDevicesBindingSource.EndEdit()
            TheInformationTechnologyDevicesDataTier.UpdateInformationTechnologyDevicesDB(TheInformationTechnologyDevicesDataSet)

            MessageBox.Show("Device ID " + cboDeviceID.Text + " Has Been Retired", "Thank You", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnResetForm.PerformClick()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click

        btnNext.Enabled = False
        btnBack.Enabled = False
        btnRetireDevice.Enabled = True
        btnSelect.Enabled = False

    End Sub
End Class