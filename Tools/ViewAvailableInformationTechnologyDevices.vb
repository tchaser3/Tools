'Title:         View Available Information Technology Devices
'Date:          6-17-15
'Author:        Terry Holmes

'Description:   This form is used to view available information technology devices

Option Strict On

Public Class ViewAvailableInformationTechnologyDevices

    Private TheInformationTechnologyDevicesDataSet As InformationTechnologyDevicesDataSet
    Private TheInformationTechnologyDevicesDataTier As InformationTechnologyDataTier
    Private WithEvents TheInformationTechnologyDevicesBindingSource As New BindingSource

    Private TheEmployeeDataSet As EmployeeDataSet
    Private TheEmployeeDataTier As EmployeeDataTier
    Private WithEvents TheEmployeeBindingSource As BindingSource

    Dim mblnFatalError As Boolean = False

    Private Sub btnInformationTechnologyMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInformationTechnologyMenu.Click

        LastTransaction.Show()
        InformationTechnologyMenu.Show()
        Me.Close()

    End Sub

    Private Sub btnMainMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMainMenu.Click

        LastTransaction.Show()
        MainMenu.Show()
        Me.Close()

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        CloseTheProgram.ShowDialog()

    End Sub
    Private Sub SetEmployeeDataBindings()

        Try

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

            'Setting the rest of the controls
            txtLastName.DataBindings.Add("text", TheEmployeeBindingSource, "LastName")
            txtFirstName.DataBindings.Add("text", TheEmployeeBindingSource, "FirstName")

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            mblnFatalError = True
        End Try

    End Sub
    Private Sub SetDeviceBindings()

        Try
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

            'setting the combo box
            With cboDeviceID
                .DataSource = TheInformationTechnologyDevicesBindingSource
                .DisplayMember = "DeviceID"
                .DataBindings.Add("text", TheInformationTechnologyDevicesBindingSource, "DeviceID", False, DataSourceUpdateMode.Never)
            End With

            txtActive.DataBindings.Add("text", TheInformationTechnologyDevicesBindingSource, "Active")
            txtAvailable.DataBindings.Add("text", TheInformationTechnologyDevicesBindingSource, "Available")
            txtComputerName.DataBindings.Add("text", TheInformationTechnologyDevicesBindingSource, "ComputerName")
            txtEmployeeID.DataBindings.Add("text", TheInformationTechnologyDevicesBindingSource, "EmployeeID")
            txtManufacturer.DataBindings.Add("text", TheInformationTechnologyDevicesBindingSource, "Manufacturer")
            txtPhoneNumber.DataBindings.Add("text", TheInformationTechnologyDevicesBindingSource, "PhoneNumber")
            txtSerialNumber.DataBindings.Add("text", TheInformationTechnologyDevicesBindingSource, "SerialNumber")
            txtType.DataBindings.Add("text", TheInformationTechnologyDevicesBindingSource, "Type")
            txtModel.DataBindings.Add("text", TheInformationTechnologyDevicesBindingSource, "Model")

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            mblnFatalError = True
        End Try

    End Sub

    Private Sub ViewAvailableInformationTechnologyDevices_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Sub-routine loaded during Form Load
        SetEmployeeDataBindings()
        SetDeviceBindings()
        If mblnFatalError = True Then
            MessageBox.Show("The Data Bindings Failed to Load, The Information Technology Menu Will Be Loaded", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Error)
            InformationTechnologyMenu.Show()
            Me.Close()
        End If
        CreateDataGrid()
        SetControlsVisible(False)
        dgvAvailableDevices.Visible = False

    End Sub

    Private Sub SetControlsVisible(ByVal valueBoolean As Boolean)

        cboDeviceID.Visible = valueBoolean
        cboEmployeeID.Visible = valueBoolean
        txtActive.Visible = valueBoolean
        txtAvailable.Visible = valueBoolean
        txtComputerName.Visible = valueBoolean
        txtEmployeeID.Visible = valueBoolean
        txtFirstName.Visible = valueBoolean
        txtLastName.Visible = valueBoolean
        txtManufacturer.Visible = valueBoolean
        txtModel.Visible = valueBoolean
        txtPhoneNumber.Visible = valueBoolean
        txtSerialNumber.Visible = valueBoolean
        txtType.Visible = valueBoolean

    End Sub
    Private Sub CreateDataGrid()

        dgvAvailableDevices.ColumnCount = 5
        dgvAvailableDevices.Columns(0).Name = "Manufacturer"
        dgvAvailableDevices.Columns(1).Name = "Model"
        dgvAvailableDevices.Columns(2).Name = "Computer Name"
        dgvAvailableDevices.Columns(3).Name = "Phone Number"
        dgvAvailableDevices.Columns(4).Name = "Warehouse Location"

    End Sub

    Private Sub btnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFind.Click
        'Setting Local Variables
        Dim intNumberOfRecords As Integer
        Dim intCounter As Integer
        Dim strTypeForSearch As String
        Dim strTypeFromTable As String
        Dim row() As String
        Dim blnItemNotFound As Boolean = True
        Dim strAvailableFromTable As String = ""


        'Checks to see if a category was selected
        If cboDeviceList.Text = "" Then
            MessageBox.Show("A Device Type Was Not Selected", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        SetControlsVisible(True)
        dgvAvailableDevices.Visible = True

        'Clears the data grid
        ClearDataGridView()

        'Setting up for the loop
        intNumberOfRecords = cboDeviceID.Items.Count - 1
        strTypeForSearch = cboDeviceList.Text

        If strTypeForSearch = "ALL" Then

            'Preforming Loop
            For intCounter = 0 To intNumberOfRecords

                'getting employee
                FindEmployee()

                cboDeviceID.SelectedIndex = intCounter

                strAvailableFromTable = txtAvailable.Text

                If strAvailableFromTable = "YES" Then

                    'Adding the row
                    row = New String() {txtManufacturer.Text, txtModel.Text, txtComputerName.Text, txtPhoneNumber.Text, txtFirstName.Text}
                    dgvAvailableDevices.Rows.Add(row)
                    blnItemNotFound = False

                End If
            Next

        Else

            For intCounter = 0 To intNumberOfRecords

                'incrementing the counter
                cboDeviceID.SelectedIndex = intCounter

                strTypeFromTable = txtType.Text
                strAvailableFromTable = txtAvailable.Text

                If strTypeForSearch = strTypeFromTable Then
                    If strAvailableFromTable = "YES" Then

                        'Adding the row
                        row = New String() {txtManufacturer.Text, txtModel.Text, txtComputerName.Text, txtPhoneNumber.Text, txtFirstName.Text}
                        dgvAvailableDevices.Rows.Add(row)
                        blnItemNotFound = False

                    End If
                End If
            Next
        End If

        If blnItemNotFound = True Then
            SetControlsVisible(False)
            dgvAvailableDevices.Visible = False
            MessageBox.Show("No Available Items For That Type", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

    End Sub
    Private Sub FindEmployee()

        'Setting local variables
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim intEmployeeIDForSearch As Integer
        Dim intEmployeeIDFromTable As Integer
        Dim intSelectedIndex As Integer

        'Getting ready for the loop
        intNumberOfRecords = cboEmployeeID.Items.Count - 1
        intEmployeeIDForSearch = CInt(txtEmployeeID.Text)

        'beginning loop
        For intCounter = 0 To intNumberOfRecords

            'incrementing the combo box
            cboEmployeeID.SelectedIndex = intCounter

            'Getting employee id
            intEmployeeIDFromTable = CInt(cboEmployeeID.Text)

            If intEmployeeIDForSearch = intEmployeeIDFromTable Then
                intSelectedIndex = intCounter
            End If
        Next

        'setting the location
        cboEmployeeID.SelectedIndex = intSelectedIndex

    End Sub
    Private Sub ClearDataGridView()

        'setting local variables
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer

        'Getting Count
        intNumberOfRecords = dgvAvailableDevices.Rows.Count - 2

        If intNumberOfRecords >= 0 Then

            'loop to clear data gridview
            For intCounter = 0 To intNumberOfRecords
                dgvAvailableDevices.Rows.Clear()
            Next

        End If

    End Sub
End Class