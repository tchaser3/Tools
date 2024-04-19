'Title:         Add Information Technology Devices
'Date:          9/17/14
'Author:        Terry Holmes

'Description:   This form is used to add Information Technology Devices

Option Strict On

Public Class AddInformationTechnologyDevice

    'Setting up global data sources
    Private TheInformationTechnologyDevicesDataSet As InformationTechnologyDevicesDataSet
    Private TheInformationTechnologyDevicesDataTier As InformationTechnologyDataTier
    Private WithEvents TheInformationTechnologyDevicesBindingSource As New BindingSource

    Dim LogDateTime As Date = DateAndTime.Now
    Dim strLogDateTime As String

    'Setting global variables
    Dim TheInputDataValidation As New InputDataValidation
    Dim TheKeyWordSearchClass As New KeyWordSearchClass
    Private addingBoolean As Boolean = False
    Private editingBoolean As Boolean = False
    Private previousSelectedIndex As Integer
    Dim mstrDeviceType As String

    'Setting up a global array
    Dim mintDeviceCounter As Integer
    Dim mintDeviceSelectedIndex() As Integer
    Dim mintDeviceUpperLimit As Integer

    Friend mstrDeviceInformation As String

    Private Sub SetDeviceControlsReadOnly(ByVal valueBoolean As Boolean)

        'This will set these controls to read only
        txtComputerName.ReadOnly = valueBoolean
        txtManufacturer.ReadOnly = valueBoolean
        txtModel.ReadOnly = valueBoolean
        txtNotes.ReadOnly = valueBoolean
        txtPhoneNumber.ReadOnly = valueBoolean
        txtSerialNumber.ReadOnly = valueBoolean

    End Sub

    Private Sub SetComboBoxBinding()

        'This will set the combo box bindings.
        With cboDeviceID
            If (addingBoolean Or editingBoolean) Then
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.OnValidation
                .DropDownStyle = ComboBoxStyle.Simple
            Else
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.Never
                .DropDownStyle = ComboBoxStyle.DropDownList
            End If

        End With

    End Sub

    Private Sub btnMainMenu_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMainMenu.Click

        'This will run when the Main Menu button is pressed
        ClearDeviceBindings()
        MainMenu.Show()
        Me.Close()

    End Sub

    Private Sub btnClose_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        'Closes the Program
        CloseTheProgram.ShowDialog()

    End Sub

    Private Sub btnInformationTechnologyMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInformationTechnologyMenu.Click

        'Displays the Information Technology Menu
        ClearDeviceBindings()
        InformationTechnologyMenu.Show()
        Me.Close()

    End Sub

    Private Sub AddInformationTechnologyDevice_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'This will load up the controls
        Logon.mstrLastTransactionSummary = "LOADED ADD INFORMATION DEVICES"
        SetDeviceBindings()
        SetDeviceControlsReadOnly(True)

    End Sub
    Private Sub SetDeviceBindings()

        'Setting local variables
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

            'Setting array dimensions
            intNumberOfRecords = cboDeviceID.Items.Count - 1
            ReDim mintDeviceSelectedIndex(intNumberOfRecords)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct Device Bindings", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub ClearDeviceBindings()

        'This will clear the data bindings
        cboDeviceID.DataBindings.Clear()
        txtType.DataBindings.Clear()
        txtManufacturer.DataBindings.Clear()
        txtModel.DataBindings.Clear()
        txtPhoneNumber.DataBindings.Clear()
        txtComputerName.DataBindings.Clear()
        txtSerialNumber.DataBindings.Clear()
        txtEmployeeID.DataBindings.Clear()
        txtAvailable.DataBindings.Clear()
        txtActive.DataBindings.Clear()
        txtDate.DataBindings.Clear()
        txtNotes.DataBindings.Clear()

    End Sub


    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        'This form will add a new record

        'Setting Up Local Variables
        Dim strValueForValidation As String
        Dim blnFatalError As Boolean = False
        Dim blnThereIsAProblem As Boolean = False
        Dim strErrorMessage As String = ""
        Dim strDeviceType As String

        'If statements to determine which part of the routine to run
        If btnAdd.Text = "Add" Then

            'Setting Binding Source up to create a new record
            With TheInformationTechnologyDevicesBindingSource
                .EndEdit()
                .AddNew()
            End With
            CreateNewRecord()
            btnAdd.Text = "Save"

        Else

            'This will set up validation
            strValueForValidation = txtManufacturer.Text
            blnFatalError = TheInputDataValidation.VerifyTextData(strValueForValidation)
            If blnFatalError = True Then
                blnThereIsAProblem = True
                strErrorMessage = strErrorMessage + "The Manufacturer Information Was Not Entered" + vbNewLine
            End If

            strValueForValidation = txtModel.Text
            blnFatalError = TheInputDataValidation.VerifyTextData(strValueForValidation)
            If blnFatalError = True Then
                blnThereIsAProblem = True
                strErrorMessage = strErrorMessage + "The Model Was Not Entered" + vbNewLine
            End If
            strValueForValidation = txtType.Text
            blnFatalError = TheInputDataValidation.VerifyTextData(strValueForValidation)
            If blnFatalError = True Then
                blnThereIsAProblem = True
                strErrorMessage = strErrorMessage + "Device Type Was Not Selected" + vbNewLine
            Else
                strDeviceType = txtType.Text
                If strDeviceType = "LAPTOP" Or strDeviceType = "DESKTOP" Then
                    strValueForValidation = txtComputerName.Text
                    blnFatalError = TheInputDataValidation.VerifyTextData(strValueForValidation)
                    If blnFatalError = True Then
                        blnThereIsAProblem = True
                        strErrorMessage = strErrorMessage + "The Computer Name Was Not Entered" + vbNewLine
                    End If
                Else
                    strValueForValidation = txtPhoneNumber.Text
                    blnFatalError = TheInputDataValidation.VerifyPhoneNumberFormat(strValueForValidation)
                    If blnFatalError = True Then
                        blnThereIsAProblem = True
                        strErrorMessage = strErrorMessage + "The Phone Number Was Not Entered" + vbNewLine
                    End If
                End If
            End If
        

            If blnThereIsAProblem = True Then
                MessageBox.Show(strErrorMessage, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            'Verifying that the device entered does not exist and active
            mstrDeviceInformation = strValueForValidation
            VerifyInformationTechnologyDevice.Show()

            If Logon.mbolFatalError = True Then
                MessageBox.Show("The Device Name Exists and is Available, Please Retire Current Device Before Adding This Device", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            'Updating the Data Set
            Try

                TheInformationTechnologyDevicesBindingSource.EndEdit()
                TheInformationTechnologyDevicesDataTier.UpdateInformationTechnologyDevicesDB(TheInformationTechnologyDevicesDataSet)
                btnAdd.Text = "Add"
                SetDeviceControlsReadOnly(True)
                addingBoolean = False
                editingBoolean = False
                SetComboBoxBinding()
                cboDeviceID.SelectedIndex = previousSelectedIndex
                MessageBox.Show("The Record Has Been Saved", "Thank You", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Catch ex As Exception
                'Message to user if there is a probelm
                MessageBox.Show(ex.Message, "There is a problem", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If

    End Sub
    Private Sub CreateNewRecord()

        'This proceedure will run and create a record

        'Calling sub-routine and variables\
        addingBoolean = True
        SetComboBoxBinding()
        cboDeviceID.Focus()
        SetDeviceControlsReadOnly(False)
        btnAdd.Text = "Save"
        cboDeviceID.Visible = True
        InformationTechnologyID.Show()

        cboDeviceID.Text = CStr(Logon.mintCreatedTransactionID)
        txtType.Text = mstrDeviceType
        txtEmployeeID.Text = CStr(Logon.mintHomeOfficeID)
        txtActive.Text = "YES"
        txtAvailable.Text = "YES"
        strLogDateTime = CStr(LogDateTime)
        txtDate.Text = strLogDateTime

    End Sub

    Private Sub cboSelectDeviceType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSelectDeviceType.SelectedIndexChanged

        txtType.Text = cboSelectDeviceType.Text

    End Sub
End Class