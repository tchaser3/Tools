'Title:         Return Information Technology Device Accessories
'Date:          10/9/14
'Author:        Terry Holmes

'Description:   This form is used to find and return accessories

Option Strict On

Public Class ReturnInformationTechnologyDeviceAccessories

    Private TheInformationTechnologyDeviceAccessoriesDataSet As InformationTechnologyDeviceAccessoriesDataSet
    Private TheInformationTechnologyDeviceAccessoriesDataTier As InformationTechnologyDataTier
    Private WithEvents TheInformationTechnologyDeviceAccessoriesBindingSource As BindingSource

    'Creating Structure Object
    Dim mstrAccessoriesTypeReturnedForSearch(10) As String
    Dim mintAccessoryCounter As Integer
    Dim mintAccessoryUpperLimit As Integer
    Dim mblnAccessoryReturned As Boolean

    'Creating date and time objects
    Dim LogDateTime As Date = DateAndTime.Now
    Dim strLogDateTime As String
    Dim mintEmployeeID As Integer


    Private Sub ReturnInformationTechnologyDeviceAccessories_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Setting Local Variables
        Dim intCounter As Integer

        'Running loop to place arrays in initial condition
        For intCounter = 0 To 10

            mstrAccessoriesTypeReturnedForSearch(intCounter) = ""

        Next

        mintAccessoryCounter = 0

        'Setting up the controls
        Try

            'Setting up the data set 
            TheInformationTechnologyDeviceAccessoriesDataTier = New InformationTechnologyDataTier
            TheInformationTechnologyDeviceAccessoriesDataSet = TheInformationTechnologyDeviceAccessoriesDataTier.GetInformationTechnologyDeviceAccessoriesInformation
            TheInformationTechnologyDeviceAccessoriesBindingSource = New BindingSource

            'Setting up the binding source
            With TheInformationTechnologyDeviceAccessoriesBindingSource
                .DataSource = TheInformationTechnologyDeviceAccessoriesDataSet
                .DataMember = "informationtechnologydeviceaccessories"
                .MoveFirst()
                .MoveLast()
            End With

            'Setting up the combo box
            With cboAccessoryID
                .DataSource = TheInformationTechnologyDeviceAccessoriesBindingSource
                .DisplayMember = "AccessoryID"
                .DataBindings.Add("text", TheInformationTechnologyDeviceAccessoriesBindingSource, "AccessoryID", False, DataSourceUpdateMode.Never)
            End With

            txtDeviceID.DataBindings.Add("text", TheInformationTechnologyDeviceAccessoriesBindingSource, "DeviceID")
            txtAccessoryType.DataBindings.Add("text", TheInformationTechnologyDeviceAccessoriesBindingSource, "AccessoryType")
            txtDate.DataBindings.Add("text", TheInformationTechnologyDeviceAccessoriesBindingSource, "Date")
            txtEmployeeID.DataBindings.Add("text", TheInformationTechnologyDeviceAccessoriesBindingSource, "EmployeeID")
            txtAvailable.DataBindings.Add("text", TheInformationTechnologyDeviceAccessoriesBindingSource, "Available")
            txtActive.DataBindings.Add("text", TheInformationTechnologyDeviceAccessoriesBindingSource, "Active")

            ControlsVisible(False)
            ClearCheckBoxes()
            mintAccessoryCounter = 0

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub ControlsVisible(ByVal valueBoolean As Boolean)

        'Sets controls visible
        cboAccessoryID.Visible = valueBoolean
        txtAccessoryType.Visible = valueBoolean
        txtAvailable.Visible = valueBoolean
        txtDate.Visible = valueBoolean
        txtDeviceID.Visible = valueBoolean
        txtEmployeeID.Visible = valueBoolean
        txtActive.Visible = valueBoolean

    End Sub
    Private Sub ClearDataBindings()

        'This will clear the data bindings of all the controls
        cboAccessoryID.DataBindings.Clear()
        txtAccessoryType.DataBindings.Clear()
        txtAvailable.DataBindings.Clear()
        txtDate.DataBindings.Clear()
        txtDeviceID.DataBindings.Clear()
        txtEmployeeID.DataBindings.Clear()
        txtActive.DataBindings.Clear()

    End Sub
    Private Sub ClearCheckBoxes()

        'This will clear the check boxes
        chkHeadPhones.Checked = False
        chkKeyboard.Checked = False
        chkLaptopCase.Checked = False
        chkMonitor.Checked = False
        chkMouse.Checked = False
        chkNoAccessoriesReturned.Checked = False
        chkPhoneCase.Checked = False
        chkPowerCord.Checked = False
        chkPowerUSBCharger.Checked = False
        chkPrinter.Checked = False
        chkUSBCable.Checked = False

    End Sub

    Private Sub btnReturnAccessories_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReturnAccessories.Click

        'This will find the accessories

        'Setting Local Variables
        Dim intTableCounter As Integer
        Dim intArrayCounter As Integer
        Dim intTableNumberOfRecords As Integer
        Dim intEmployeeIDForSearch As Integer
        Dim intEmployeeIDFromTable As Integer
        Dim blnFatalError As Boolean = True
        Dim strAccessoryTypeFromTable As String
        Dim strAccessoryTypeForSearch As String
        Dim strAvailableFromTable As String
        Dim strActiveFromTable As String
        Dim blnNoAccessoriesFound As Boolean = True
        Dim blnItemNotFound As Boolean = True

        mintAccessoryCounter = 0

        'If statements to determin if there were accesssories issued
        If chkNoAccessoriesReturned.Checked = True Then

            MessageBox.Show("No Accessories Were Returned", "Thank You", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ClearDataBindings()
            Me.Close()

        Else

            'Checking the status of the each check box
            If chkHeadPhones.Checked <> False Then
                blnFatalError = False
                mstrAccessoriesTypeReturnedForSearch(mintAccessoryCounter) = "HEAD PHONES"
                mintAccessoryCounter += 1
            End If
            If chkKeyboard.Checked <> False Then
                blnFatalError = False
                mstrAccessoriesTypeReturnedForSearch(mintAccessoryCounter) = "KEYBOARD"
                mintAccessoryCounter += 1
            End If
            If chkLaptopCase.Checked <> False Then
                blnFatalError = False
                mstrAccessoriesTypeReturnedForSearch(mintAccessoryCounter) = "LAPTOP CASE"
                mintAccessoryCounter += 1
            End If
            If chkMonitor.Checked <> False Then
                blnFatalError = False
                mstrAccessoriesTypeReturnedForSearch(mintAccessoryCounter) = "MONITOR"
                mintAccessoryCounter += 1
            End If
            If chkMouse.Checked <> False Then
                blnFatalError = False
                mstrAccessoriesTypeReturnedForSearch(mintAccessoryCounter) = "MOUSE"
                mintAccessoryCounter += 1
            End If
            If chkPhoneCase.Checked <> False Then
                blnFatalError = False
                mstrAccessoriesTypeReturnedForSearch(mintAccessoryCounter) = "PHONE CASE"
                mintAccessoryCounter += 1
            End If
            If chkPowerCord.Checked <> False Then
                blnFatalError = False
                mstrAccessoriesTypeReturnedForSearch(mintAccessoryCounter) = "POWER CORD"
                mintAccessoryCounter += 1
            End If
            If chkPowerUSBCharger.Checked <> False Then
                blnFatalError = False
                mstrAccessoriesTypeReturnedForSearch(mintAccessoryCounter) = "POWER USB CHARGER"
                mintAccessoryCounter += 1
            End If
            If chkPrinter.Checked <> False Then
                blnFatalError = False
                mstrAccessoriesTypeReturnedForSearch(mintAccessoryCounter) = "PRINTER"
                mintAccessoryCounter += 1
            End If
            If chkUSBCable.Checked <> False Then
                blnFatalError = False
                mstrAccessoriesTypeReturnedForSearch(mintAccessoryCounter) = "USB CABLE"
                mintAccessoryCounter += 1
            End If

            'Output to User
            If blnFatalError = True Then
                MessageBox.Show("None of the Check Boxes Where Checked", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            'Making Controls Visible
            ControlsVisible(True)

            'Setting up the upper limit for the Array Counter
            mintAccessoryUpperLimit = mintAccessoryCounter - 1

            'Setting up the Number Of records for the table
            intTableNumberOfRecords = cboAccessoryID.Items.Count - 1

            'Getting the employee ID
            intEmployeeIDForSearch = CInt(Logon.mintEmployeeID)

            'For Loop for the Array Counter
            For intArrayCounter = 0 To mintAccessoryUpperLimit

                'Loop for the device
                strAccessoryTypeForSearch = mstrAccessoriesTypeReturnedForSearch(intArrayCounter)

                'Beginning the second loop
                For intTableCounter = 0 To intTableNumberOfRecords

                    'Loading up variables
                    cboAccessoryID.SelectedIndex = intTableCounter
                    strAccessoryTypeFromTable = txtAccessoryType.Text
                    strActiveFromTable = txtActive.Text
                    strAvailableFromTable = txtAvailable.Text
                    intEmployeeIDFromTable = CInt(txtEmployeeID.Text)

                    'Beginning if statements
                    If intEmployeeIDForSearch = intEmployeeIDFromTable Then
                        If strAccessoryTypeForSearch = strAccessoryTypeFromTable Then
                            If strActiveFromTable = "YES" Then
                                If strAvailableFromTable = "NO" Then

                                    'Peforming Logic for editing the record
                                    txtEmployeeID.Text = CStr(Logon.mintHomeOfficeID)
                                    txtActive.Text = "NO"
                                    blnItemNotFound = False

                                    'Updating the database
                                    Try
                                        TheInformationTechnologyDeviceAccessoriesBindingSource.EndEdit()
                                        TheInformationTechnologyDeviceAccessoriesDataTier.UpdateInformationTechnologyDeviceAccessoriesDB(TheInformationTechnologyDeviceAccessoriesDataSet)
                                        blnNoAccessoriesFound = False

                                        'Setting up for the history file
                                        Logon.mintEmployeeID = intEmployeeIDForSearch
                                        Logon.mintAccessoryID = CInt(cboAccessoryID.Text)
                                        Logon.mintDeviceID = CInt(txtDeviceID.Text)
                                        Logon.mdatDate = CDate(txtDate.Text)
                                        Logon.mstrNotes = "UNIT SIGNED IN"

                                        AddInformationTechnologyAccessoryHistory.Show()

                                    Catch ex As Exception
                                        MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    End Try
                                End If
                            End If
                        End If
                    End If

                    'Letting the user know if there is a problem
                    If blnItemNotFound = True Then
                        Logon.mbolFatalError = True
                    End If
                Next
            Next

            If blnNoAccessoriesFound = True Then
                MessageBox.Show("No Accessories Were Found Signed Out To This Employee" + vbNewLine + "No Items Were Credited", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            ClearDataBindings()
            Me.Close()

        End If


    End Sub
    
    
End Class