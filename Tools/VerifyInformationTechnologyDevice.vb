'Title:         Verify Information Technology Device
'Date:          9/30/14
'Author:        Terry Holmes

'Description:   This form is used to verify the name

Option Strict On

Public Class VerifyInformationTechnologyDevice

    'Setting up global data sources
    Private TheInformationTechnologyDevicesDataSet As InformationTechnologyDevicesDataSet
    Private TheInformationTechnologyDevicesDataTier As InformationTechnologyDataTier
    Private WithEvents TheInformationTechnologyDevicesBindingSource As New BindingSource

    Private Sub VerifyInformationTechnologyDevice_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Setting Local Variables
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim strDeviceInformationForSearch As String
        Dim strDeviceInformationFromTable As String
        Dim strActiveFromTable As String
        Dim strAvailableFromTable As String
        Dim blnDeviceFound As Boolean = False

        'This will set the control bindings
        SetDeviceBindings()

        'Setting up for search
        intNumberOfRecords = cboDeviceID.Items.Count - 1
        strDeviceInformationForSearch = AddInformationTechnologyDevice.mstrDeviceInformation

        'Beginning Search for phone number
        For intCounter = 0 To intNumberOfRecords

            cboDeviceID.SelectedIndex = intCounter
            strDeviceInformationFromTable = txtPhoneNumber.Text
            strActiveFromTable = txtActive.Text
            strAvailableFromTable = txtAvailable.Text

            'Beginning if statements
            If strActiveFromTable = "YES" Then
                If strAvailableFromTable = "YES" Then
                    If strDeviceInformationForSearch = strDeviceInformationFromTable Then
                        blnDeviceFound = True
                    End If
                End If
            End If

        Next

        'Beginning Search for Computer Name
        For intCounter = 0 To intNumberOfRecords

            cboDeviceID.SelectedIndex = intCounter
            strDeviceInformationFromTable = txtComputerName.Text
            strActiveFromTable = txtActive.Text
            strAvailableFromTable = txtAvailable.Text

            'Beginning if statements
            If strActiveFromTable = "YES" Then
                If strAvailableFromTable = "YES" Then
                    If strDeviceInformationForSearch = strDeviceInformationFromTable Then
                        blnDeviceFound = True
                    End If
                End If
            End If

        Next

        Logon.mbolFatalError = blnDeviceFound
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
End Class