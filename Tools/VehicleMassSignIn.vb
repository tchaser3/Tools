'Title:         Vehicle Mass Sign In
'Date:          10-30-14
'Author:        Terry Holmes

'Description:   This form is used for Mass Vehicle Sign in

Option Strict On

Public Class VehicleMassSignIn

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

    'Setting up the Vehicle Selected Index Array
    Dim mintVehicleCounter As Integer
    Dim mintVehicleUpperLimit As Integer
    Dim mintVehicleSelectedIndex(1000) As Integer

    'Setting up the Warehouse Selected Index
    Dim mintWarehouseCounter As Integer
    Dim mintWarehouseUpperLimit As Integer
    Dim mintWarehouseSelectedIndex(100) As Integer

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

    Private Sub VehicleMassSignIn_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

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
            txtHomeOffice.DataBindings.Add("text", TheEmployeeBindingSource, "HomeOffice")

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
            txtEmployeeID.DataBindings.Add("text", TheVehiclesBindingSource, "EmployeeID")
            txtDate.DataBindings.Add("text", TheVehiclesBindingSource, "Date")
            txtAvailable.DataBindings.Add("text", TheVehiclesBindingSource, "Available")
            txtActive.DataBindings.Add("text", TheVehiclesBindingSource, "Active")
            txtOutOfTown.DataBindings.Add("text", TheVehiclesBindingSource, "OutOfTown")

            LoadVehicleArray()
            LoadWarehouseArray()
            SetControlsVisible(False)

        Catch ex As Exception

            'If an exception is thrown, it is rounted here
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub SetControlsVisible(ByVal valueBoolean As Boolean)

        'This will make the controls visible
        txtActive.Visible = valueBoolean
        txtAvailable.Visible = valueBoolean
        txtBJCNumber.Visible = valueBoolean
        txtDate.Visible = valueBoolean
        txtEmployeeID.Visible = valueBoolean
        txtFirstName.Visible = valueBoolean
        txtHomeOffice.Visible = valueBoolean
        txtLastName.Visible = valueBoolean
        txtOutOfTown.Visible = valueBoolean

    End Sub
    Private Sub ClearDataBindings()

        'Clear Combo Boxes
        cboEmployeeID.DataBindings.Clear()
        cboVehicleID.DataBindings.Clear()

        'Clear Text Boxes
        txtActive.DataBindings.Clear()
        txtAvailable.DataBindings.Clear()
        txtBJCNumber.DataBindings.Clear()
        txtDate.DataBindings.Clear()
        txtEmployeeID.DataBindings.Clear()
        txtFirstName.DataBindings.Clear()
        txtHomeOffice.DataBindings.Clear()
        txtLastName.DataBindings.Clear()
        txtOutOfTown.DataBindings.Clear()

    End Sub
    Private Sub LoadVehicleArray()

        'Setting Local variables
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim strActiveFromTable As String

        'Setting up for loop
        intNumberOfRecords = cboVehicleID.Items.Count - 1
        mintVehicleCounter = 0
        mintVehicleUpperLimit = 0

        'Preforming Loop
        For intCounter = 0 To intNumberOfRecords

            'Incrementing the Combo Box
            cboVehicleID.SelectedIndex = intCounter

            'Loading up the Search Variable
            strActiveFromTable = txtActive.Text

            'Preforming If Statement to load up Vehicle Selected Index Array
            If strActiveFromTable = "YES" Then

                'Setting the value of the Vehicle Array
                mintVehicleSelectedIndex(mintVehicleCounter) = intCounter
                mintVehicleCounter += 1

            End If
        Next

        'Setting up the Vehicle Array
        mintVehicleUpperLimit = mintVehicleCounter - 1
        mintVehicleCounter = 0
        cboVehicleID.SelectedIndex = mintVehicleSelectedIndex(0)

    End Sub
    Private Sub LoadWarehouseArray()

        'Setting Local Warehouse
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim strLastNameFromTable As String

        'Setting up for loop
        intNumberOfRecords = cboEmployeeID.Items.Count - 1
        mintWarehouseCounter = 0
        mintWarehouseUpperLimit = 0

        'Running Loop
        For intCounter = 0 To intNumberOfRecords

            'Incrementing the Combo box
            cboEmployeeID.SelectedIndex = intCounter

            'Loading string variable
            strLastNameFromTable = txtLastName.Text

            'Performing If Statements
            If strLastNameFromTable = "WAREHOUSE" Then

                'Setting Array Variable
                mintWarehouseSelectedIndex(mintWarehouseCounter) = intCounter
                mintWarehouseCounter += 1

            End If
        Next

        'Setting up the upper limit of array
        mintWarehouseUpperLimit = mintWarehouseCounter - 1
        mintWarehouseCounter = 0

    End Sub

    Private Sub btnRunSignInProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRunSignInProcess.Click

        'This Sub Routine will sign in all vehicles that are not out of town
        'This sub routine will also assign the vehicle to the home office that the
        'Employee is from

        'Setting up local variables
        Dim intVehicleCounter As Integer
        Dim intEmployeeCounter As Integer
        Dim intEmployeeNumberOfRecords As Integer
        Dim intWarehouseCounter As Integer
        Dim intEmployeeIDForSearch As Integer
        Dim intEmployeeIDFromTable As Integer
        Dim intEmployeeSectedIndex As Integer
        Dim strAvailableFromTable As String
        Dim strHomeOfficeFromTable As String
        Dim strHomeOfficeForSearch As String
        Dim strRemoteVehicleFromTable As String
        Dim intWarehouseSelectedIndex As Integer

        'Setting Controls Visible
        SetControlsVisible(True)

        'Setting up for Loop
        intEmployeeNumberOfRecords = cboEmployeeID.Items.Count - 1

        'Beginning Vehicle Loop
        For intVehicleCounter = 0 To mintVehicleUpperLimit

            'Incrementing the combo box
            cboVehicleID.SelectedIndex = mintVehicleSelectedIndex(intVehicleCounter)

            'Loadiing local variables for If Statements
            strAvailableFromTable = txtAvailable.Text
            strRemoteVehicleFromTable = txtOutOfTown.Text

            'If Statements for determining if the record should be edited
            If strAvailableFromTable = "NO" Then
                If strRemoteVehicleFromTable = "NO" Then

                    'Looking for Employee ID
                    intEmployeeIDForSearch = CInt(txtEmployeeID.Text)

                    'Beginning Loop to find Employee ID
                    For intEmployeeCounter = 0 To intEmployeeNumberOfRecords

                        'Incrementing the Combo Box
                        cboEmployeeID.SelectedIndex = intEmployeeCounter

                        'Getting Employee ID From Table
                        intEmployeeIDFromTable = CInt(cboEmployeeID.Text)

                        'If Statements to see if they match
                        If intEmployeeIDForSearch = intEmployeeIDFromTable Then

                            'Setting Value for the Selected Index
                            intEmployeeSectedIndex = intEmployeeCounter

                        End If
                    Next

                    'Getting Employee Home Office
                    cboEmployeeID.SelectedIndex = intEmployeeSectedIndex
                    strHomeOfficeForSearch = txtHomeOffice.Text

                    'Searching for Home Office through loop
                    For intWarehouseCounter = 0 To mintWarehouseUpperLimit

                        'Incrementing the combo box
                        cboEmployeeID.SelectedIndex = mintWarehouseSelectedIndex(intWarehouseCounter)
                        strHomeOfficeFromTable = txtFirstName.Text

                        'Checking to see if the two home offices match
                        If strHomeOfficeForSearch = strHomeOfficeFromTable Then

                            'If the match, the index is set
                            intWarehouseSelectedIndex = intWarehouseCounter

                        End If
                    Next

                    'Setting up the combo box
                    cboEmployeeID.SelectedIndex = mintWarehouseSelectedIndex(intWarehouseSelectedIndex)

                    'setting up conditions for editing the record
                    txtAvailable.Text = "YES"
                    txtEmployeeID.Text = cboEmployeeID.Text
                    strLogDateTime = CStr(LogDateTime)
                    txtDate.Text = strLogDateTime

                    'Setting Variables to call History Form
                    Logon.mintBJCNumber = CInt(txtBJCNumber.Text)
                    Logon.mintVehicleID = CInt(cboVehicleID.Text)
                    Logon.mintHistoryEmployeeID = CInt(cboEmployeeID.Text)
                    Logon.mstrNotes = "VEHICLE SIGNED BACK IN"
                    Logon.mstrLogDateTime = strLogDateTime
                    Logon.mstrRemoteVehicle = "NO"

                    AddingVehicleHistory.Show()

                    'Try Catch to edit the form
                    Try
                        TheVehiclesBindingSource.EndEdit()
                        TheVehiclesDataTier.UpdateDB(TheVehiclesDataSet)
                        editingBoolean = False
                    Catch ex As Exception
                        MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try

                End If
            End If

        Next

        SetControlsVisible(False)
        MessageBox.Show("All Applicable Vehicles Are Now Signed In", "Thank You", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub
End Class