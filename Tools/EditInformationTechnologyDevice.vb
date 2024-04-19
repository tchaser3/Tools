'Title:         Edit Information Technology Device
'Date:          6-15-15
'Author:        Terry Holmes

'Description:   This form is used to edit information technology equipment

Option Strict On

Public Class EditInformationTechnologyDevice

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

    Friend mstrDeviceInformation As String

    Private Sub SetDeviceControlsReadOnly(ByVal valueBoolean As Boolean)

        'This will set these controls to read only
        txtManufacturer.ReadOnly = valueBoolean
        txtModel.ReadOnly = valueBoolean
        txtNotes.ReadOnly = valueBoolean
        txtSerialNumber.ReadOnly = valueBoolean

    End Sub
    Private Sub btnMainMenu_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMainMenu.Click

        'This will run when the Main Menu button is pressed
        LastTransaction.Show()
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
        LastTransaction.Show()
        ClearDeviceBindings()
        InformationTechnologyMenu.Show()
        Me.Close()

    End Sub
    Private Sub SetDeviceBindings()

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

    Private Sub EditInformationTechnologyDevice_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'this will load when the form loads
        Logon.mstrLastTransactionSummary = "LOADED EDIT INFORMATION TECHNOLOGY DEVICE"
        SetDeviceBindings()
        SetDeviceControlsReadOnly(True)
        cboDeviceID.Visible = False

    End Sub

    Private Sub btnFindDevice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindDevice.Click

        'this sub-routine will find the device
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim intDeviceIDForSearch As Integer
        Dim intDeviceIDFromTable As Integer
        Dim intSelectedIndex As Integer
        Dim strStringInformationForSearch As String
        Dim strComputerNameFromTable As String
        Dim strPhoneNumberFromTable As String
        Dim blnFatalError As Boolean = False
        Dim blnItemNotFound As Boolean = True
        Dim blnIsNotInteger As Boolean = True

        cboDeviceID.Visible = True

        'Beginning Data validation
        strStringInformationForSearch = txtEnterDeviceInformation.Text
        blnFatalError = TheInputDataValidation.VerifyTextData(strStringInformationForSearch)
        If blnFatalError = True Then
            cboDeviceID.Visible = False
            MessageBox.Show("No Information Was Entered", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        'Checking to see if the value entered is an integer
        Try
            blnIsNotInteger = TheInputDataValidation.VerifyIntegerData(strStringInformationForSearch)
            If blnIsNotInteger = False Then
                blnFatalError = TheInputDataValidation.VerifyIntegerRange(strStringInformationForSearch)
                If blnFatalError = True Then
                    txtEnterDeviceInformation.Text = ""
                    cboDeviceID.Visible = False
                    MessageBox.Show("Integer Information Entered Is Not Within Range", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            blnFatalError = True
        End Try

        'Closing routine
        If blnFatalError = True Then
            cboDeviceID.Visible = False
            Exit Sub
        End If

        'Getting ready for the loop
        intNumberOfRecords = cboDeviceID.Items.Count - 1

        If blnIsNotInteger = False Then

            'Setting up for loop
            intDeviceIDForSearch = CInt(strStringInformationForSearch)

            'beginning loop
            For intCounter = 0 To intNumberOfRecords

                'Incrementing the combo box
                cboDeviceID.SelectedIndex = intCounter

                'getting the device id
                intDeviceIDFromTable = CInt(cboDeviceID.Text)

                If intDeviceIDForSearch = intDeviceIDFromTable Then
                    intSelectedIndex = intCounter
                    blnItemNotFound = False
                End If
            Next
        End If

        If blnItemNotFound = True Then

            'Setting up for the loop
            For intCounter = 0 To intNumberOfRecords

                'Incrementing the combo box
                cboDeviceID.SelectedIndex = intCounter

                'loading the variables
                strComputerNameFromTable = txtComputerName.Text
                strPhoneNumberFromTable = txtPhoneNumber.Text

                If strComputerNameFromTable = strStringInformationForSearch Then
                    intSelectedIndex = intCounter
                    blnItemNotFound = False
                ElseIf strPhoneNumberFromTable = strStringInformationForSearch Then
                    intSelectedIndex = intCounter
                    blnItemNotFound = False
                End If
            Next

        End If

        If blnItemNotFound = True Then
            cboDeviceID.Visible = False
            MessageBox.Show("The Information Entered Was Not Found", "Try Again", MessageBoxButtons.OK)
            Exit Sub
        End If

        'Setting up for finding the record
        cboDeviceID.SelectedIndex = intSelectedIndex
        cboDeviceID.Visible = False
        btnEdit.Enabled = True

    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click

        Dim strValueForValidation As String
        Dim blnFatalError As Boolean = False
        Dim blnThereIsAProblem As Boolean = False
        Dim strErrorMessage As String = ""

        'this sub-routine will edit the record
        If btnEdit.Text = "Edit" Then

            SetDeviceControlsReadOnly(False)
            btnEdit.Text = "Save"

        Else

            'Performing Data Validation
            strValueForValidation = txtManufacturer.Text
            blnFatalError = TheInputDataValidation.VerifyTextData(strValueForValidation)
            If blnFatalError = True Then
                blnThereIsAProblem = True
                strErrorMessage = strErrorMessage + "The Manufacture Was Not Entered" + vbNewLine
            End If
            strValueForValidation = txtModel.Text
            blnFatalError = TheInputDataValidation.VerifyTextData(strValueForValidation)
            If blnFatalError = True Then
                blnThereIsAProblem = True
                strErrorMessage = strErrorMessage + "The Model Was Not Entered" + vbNewLine
            End If
            strValueForValidation = txtSerialNumber.Text
            blnFatalError = TheInputDataValidation.VerifyTextData(strValueForValidation)
            If blnFatalError = True Then
                blnThereIsAProblem = True
                strErrorMessage = strErrorMessage + "The Serial Number Was Not Entered" + vbNewLine
            End If
            strValueForValidation = txtNotes.Text
            blnFatalError = TheInputDataValidation.VerifyTextData(strValueForValidation)
            If blnFatalError = True Then
                blnThereIsAProblem = True
                strErrorMessage = strErrorMessage + "The Notes Were Not Entered" + vbNewLine
            End If

            If blnThereIsAProblem = True Then
                MessageBox.Show(strErrorMessage, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Try
                TheInformationTechnologyDevicesBindingSource.EndEdit()
                TheInformationTechnologyDevicesDataTier.UpdateInformationTechnologyDevicesDB(TheInformationTechnologyDevicesDataSet)
                SetDeviceControlsReadOnly(True)
                MessageBox.Show("The Record Has Been Saved", "Thank You", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If

    End Sub
End Class