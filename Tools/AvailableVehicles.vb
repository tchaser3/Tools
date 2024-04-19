'Title:         Available Vehicles
'Date:          7/28/13
'Author:        Terry Holmes

'Description:   This Vehicle shows alls of the available vehicles

Option Strict On

Public Class AvailableVehicles

    'Setting Modular Variables
    Private TheEmployeeDataSet As EmployeeDataSet
    Private TheEmployeeDataTier As EmployeeDataTier
    Private WithEvents TheEmployeeBindingSource As BindingSource

    Private TheVehiclesDataSet As VehiclesDataSet
    Private TheVehiclesDataTier As VehiclesDataTier
    Private WithEvents TheVehiclesBindingSource As BindingSource

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        'Closes the Program
        CloseTheProgram.ShowDialog()

    End Sub

    Private Sub btnVehicleMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVehicleMenu.Click

        'Opens the Tool Menu
        ClearDataBindings()
        LastTransaction.Show()
        VehicleMenu.Show()
        Me.Close()

    End Sub

    Private Sub btnMainMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMainMenu.Click

        'This opens the Main menu
        ClearDataBindings()
        LastTransaction.Show()
        MainMenu.Show()
        Me.Close()

    End Sub
    Private Sub ClearDataBindings()

        'Clearing the Employee Bindings
        cboEmployeeID.DataBindings.Clear()
        txtFirstName.DataBindings.Clear()
        txtLastName.DataBindings.Clear()

        'Clearing the Vehicle bindings
        cboVehicleID.DataBindings.Clear()
        txtAvailable.DataBindings.Clear()
        txtActive.DataBindings.Clear()
        txtEmployeeID.DataBindings.Clear()
        txtNotes.DataBindings.Clear()

    End Sub
    Private Sub SetVehicleDataBindings()

        'Try Catch for exceptions
        Try

            TheVehiclesDataTier = New VehiclesDataTier
            TheVehiclesDataSet = TheVehiclesDataTier.GetVehiclesInformation
            TheVehiclesBindingSource = New BindingSource

            'Setting up the binding source
            With TheVehiclesBindingSource
                .DataSource = TheVehiclesDataSet
                .DataMember = "vehicles"
                .MoveFirst()
                .MoveLast()
            End With

            'Setting up the comb box
            With cboVehicleID
                .DataSource = TheVehiclesBindingSource
                .DisplayMember = "VehicleID"
                .DataBindings.Add("text", TheVehiclesBindingSource, "VehicleID", False, DataSourceUpdateMode.Never)
            End With

            'Setting the rest of the controls
            txtActive.DataBindings.Add("text", TheVehiclesBindingSource, "Active")
            txtAvailable.DataBindings.Add("text", TheVehiclesBindingSource, "Available")
            txtBJCNumber.DataBindings.Add("Text", TheVehiclesBindingSource, "BJCNumber")
            txtNotes.DataBindings.Add("text", TheVehiclesBindingSource, "NoteS")
            txtEmployeeID.DataBindings.Add("text", TheVehiclesBindingSource, "EmployeeID")

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub SetEmployeeDataBindings()

        'try catch for exceptions
        Try
            TheEmployeeDataTier = New EmployeeDataTier
            TheEmployeeDataSet = TheEmployeeDataTier.GetEmployeeInformation
            TheEmployeeBindingSource = New BindingSource

            With TheEmployeeBindingSource
                .DataSource = TheEmployeeDataSet
                .DataMember = "employees"
                .MoveFirst()
                .MoveLast()
            End With

            With cboEmployeeID
                .DataSource = TheEmployeeBindingSource
                .DisplayMember = "EmployeeID"
                .DataBindings.Add("text", TheEmployeeBindingSource, "EmployeeID", False, DataSourceUpdateMode.Never)
            End With

            'Setting up the rest of the controls
            txtLastName.DataBindings.Add("text", TheEmployeeBindingSource, "LastName")
            txtFirstName.DataBindings.Add("text", TheEmployeeBindingSource, "FirstName")

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub AvailableVehicles_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Loading controls
        PleaseWait.Show()
        Logon.mstrLastTransactionSummary = "LOADED AVAILABLE VEHICLES"
        SetVehicleDataBindings()
        SetEmployeeDataBindings()
        FindAvailableVehicles()
        PleaseWait.Close()

    End Sub

    Private Sub FindAvailableVehicles()

        'Setting local variables
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim strAvailableFromTable As String
        Dim strActiveFromTable As String
        Dim blnNoVehiclesFound As Boolean = True
        Dim row() As String

        'getting ready for loop
        intNumberOfRecords = cboVehicleID.Items.Count - 1

        dgvVehicles.ColumnCount = 2
        dgvVehicles.Columns(0).Name = "BJC Number"
        dgvVehicles.Columns(1).Name = "Location"

        'performing loop
        For intCounter = 0 To intNumberOfRecords

            'setting the combo box
            cboVehicleID.SelectedIndex = intCounter

            'loading the variables
            strActiveFromTable = txtActive.Text
            strAvailableFromTable = txtAvailable.Text

            'if statements
            If strActiveFromTable = "YES" Then
                If strAvailableFromTable = "YES" Then
                    FindEmployee()
                    row = New String() {txtBJCNumber.Text, txtFirstName.Text}
                    dgvVehicles.Rows.Add(row)
                    blnNoVehiclesFound = False
                End If
            End If

        Next

        If blnNoVehiclesFound = True Then
            SetControlsVisible(False)
            dgvVehicles.Visible = False
            MessageBox.Show("All Vehicles are Signed Out", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information)
            VehicleMenu.Show()
            Me.Close()
        End If

    End Sub
    Private Sub SetControlsVisible(ByVal valueBoolean As Boolean)

        'This will make the controls visible
        txtActive.Visible = valueBoolean
        txtAvailable.Visible = valueBoolean
        txtBJCNumber.Visible = valueBoolean
        txtEmployeeID.Visible = valueBoolean
        txtFirstName.Visible = valueBoolean
        txtLastName.Visible = valueBoolean
        txtNotes.Visible = valueBoolean

    End Sub
    Private Sub FindEmployee()

        'This sub routine will find the employee id
        'setting local variables
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim intEmployeeIDForSearch As Integer
        Dim intEmployeeIDFromTable As Integer
        Dim intSelectedIndex As Integer

        'Setting up for the loop
        intNumberOfRecords = cboEmployeeID.Items.Count - 1
        intEmployeeIDForSearch = CInt(txtEmployeeID.Text)

        'Performing Loop
        For intCounter = 0 To intNumberOfRecords

            'Setting the value for the combo box
            cboEmployeeID.SelectedIndex = intCounter

            'Getting the employee id
            intEmployeeIDFromTable = CInt(cboEmployeeID.Text)

            If intEmployeeIDForSearch = intEmployeeIDFromTable Then
                intSelectedIndex = intCounter
            End If
        Next

        cboEmployeeID.SelectedIndex = intSelectedIndex

    End Sub
End Class