'Title:         Vehicles Currently Signed Out
'Date:          7/25/13
'Author:        Terry Holmes

'Description:   This form will show all the open vehicles

Option Strict On

Public Class VehiclesCurrentlySignedOut

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
    Dim mblnEmployeeIDFound As Boolean
    Dim mintSelectedIndex(10000) As Integer
    Dim mintCounter As Integer
    Dim mblnLastNameFound As Boolean
    Dim mintUpperLimit As Integer
    Dim mintSearchedUpperLimit As Integer


    'Variables for History
    Friend mintToolID As Integer
    Friend mintEmployeeID As Integer
    Friend mstrLogDateTime As String
    Friend mstrAvailability As String
    Friend mstrNotes As String

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
    Private Sub SetTheVehicleForm()

        Dim intCounter As Integer
        Dim strAvailable As String
        Dim strActive As String

        btnStandardBack.Enabled = False
        btnStandardNext.Enabled = False


        'This subroutine will run to set the initial Condition
        For intCounter = 0 To 9999
            mintSelectedIndex(intCounter) = -1
        Next

        mintUpperLimit = cboVehicleID.Items.Count - 1
        mintCounter = 0

        For intCounter = 0 To mintUpperLimit

            cboVehicleID.SelectedIndex = intCounter
            strActive = txtActive.Text
            strAvailable = txtAvailable.Text

            If (strActive = "YES" And strAvailable = "NO") Then

                mintSelectedIndex(mintCounter) = intCounter
                mintCounter = mintCounter + 1

            End If

        Next

        If mintCounter = 0 Then
            MessageBox.Show("All Vehicles are Signed In", "The form will close", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        mintSearchedUpperLimit = mintCounter - 1

        If mintCounter > 1 Then
            btnStandardNext.Enabled = True
        End If

        mintCounter = 0
        cboVehicleID.SelectedIndex = mintSelectedIndex(mintCounter)
        mintEmployeeID = CInt(txtEmployeeID.Text)

        FindEmployeeID(mintEmployeeID)

    End Sub

    Private Sub FindEmployeeID(ByVal intEmployeeID As Integer)

        'Setting Local Variables
        Dim intEmployeeIDFromTable As Integer
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim intSelectedIndexFound As Integer

        'Setting the value of the variables
        mblnEmployeeIDFound = False
        intNumberOfRecords = cboEmployeeID.Items.Count

        'Performing Compare
        For intCounter = 0 To intNumberOfRecords - 1

            cboEmployeeID.SelectedIndex = intCounter
            intEmployeeIDFromTable = CInt(cboEmployeeID.Text)

            If intEmployeeIDFromTable = intEmployeeID Then
                mblnEmployeeIDFound = True
                intSelectedIndexFound = intCounter
            End If

        Next

        'Setting Combobox Selected Index
        If mblnEmployeeIDFound = True Then
            cboEmployeeID.SelectedIndex = intSelectedIndexFound
        End If

    End Sub

    Private Sub btnStandardNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStandardNext.Click

        'This Routine will run the Next Buttons
        mintCounter = mintCounter + 1
        cboVehicleID.SelectedIndex = mintSelectedIndex(mintCounter)

        btnStandardBack.Enabled = True


        If mintCounter = mintSearchedUpperLimit Then
            btnStandardNext.Enabled = False

        End If

        mintEmployeeID = CInt(txtEmployeeID.Text)

        FindEmployeeID(mintEmployeeID)

    End Sub

    Private Sub btnStandardBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStandardBack.Click

        'This will run the Back Button
        mintCounter = mintCounter - 1
        cboVehicleID.SelectedIndex = mintSelectedIndex(mintCounter)


        If mintCounter = 0 Then
            btnStandardBack.Enabled = False
        End If

        If mintCounter < mintUpperLimit Then
            btnStandardNext.Enabled = True
        End If

        mintEmployeeID = CInt(txtEmployeeID.Text)

        FindEmployeeID(mintEmployeeID)

    End Sub

    Private Sub VehiclesCurrentlySignedOut_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

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
            txtPhoneNumber.DataBindings.Add("text", TheEmployeeBindingSource, "PhoneNumber")


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

            txtActive.DataBindings.Add("text", TheVehiclesBindingSource, "Active")
            txtAvailable.DataBindings.Add("text", TheVehiclesBindingSource, "Available")
            txtBJCNumber.DataBindings.Add("text", TheVehiclesBindingSource, "BJCNumber")
            txtEmployeeID.DataBindings.Add("text", TheVehiclesBindingSource, "EmployeeID")
            txtLicencePlate.DataBindings.Add("text", TheVehiclesBindingSource, "LicencePlate")
            txtMake.DataBindings.Add("text", TheVehiclesBindingSource, "Make")
            txtModel.DataBindings.Add("text", TheVehiclesBindingSource, "Model")
            txtNotes.DataBindings.Add("text", TheVehiclesBindingSource, "Notes")
            txtYear.DataBindings.Add("text", TheVehiclesBindingSource, "Year")

            'Setting the binding for all other textbox controls

            setControlsReadOnly(True)

            cboEmployeeID.Visible = False

            SetTheVehicleForm()

        Catch ex As Exception

            'If an exception is thrown, it is rounted here
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub
    Private Sub setControlsReadOnly(ByVal valueBoolean As Boolean)

        'This will set controls either to read only or not
        With Me
            'Employee Text Boxes
            txtFirstName.ReadOnly = valueBoolean
            txtLastName.ReadOnly = valueBoolean
            txtPhoneNumber.ReadOnly = valueBoolean

            'Vehicle Textboxes
            txtActive.ReadOnly = valueBoolean
            txtAvailable.ReadOnly = valueBoolean
            txtBJCNumber.ReadOnly = valueBoolean
            txtEmployeeID.ReadOnly = valueBoolean
            txtLicencePlate.ReadOnly = valueBoolean
            txtMake.ReadOnly = valueBoolean
            txtModel.ReadOnly = valueBoolean
            txtNotes.ReadOnly = valueBoolean
            txtYear.ReadOnly = valueBoolean
           
        End With

    End Sub

    Private Sub btnFindBJCNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindBJCNumber.Click

        FindBJCNumber()

    End Sub

    Private Sub FindBJCNumber()

        Dim intCounter As Integer
        Dim strAvailable As String
        Dim strActive As String
        Dim strBJCNumber As String
        Dim strBJCNumberFromTable As String
        Dim blnBJCNumberFound As Boolean = False

        If txtBJCNumberEntered.Text = "" Then
            MessageBox.Show("The Type was Not entered", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        btnStandardBack.Enabled = False
        btnStandardNext.Enabled = False


        'This subroutine will run to set the initial Condition
        For intCounter = 0 To 9999
            mintSelectedIndex(intCounter) = -1
        Next

        mintUpperLimit = cboVehicleID.Items.Count - 1
        mintCounter = 0

        strBJCNumber = CStr(txtBJCNumberEntered.Text)

        For intCounter = 0 To mintUpperLimit

            cboVehicleID.SelectedIndex = intCounter
            strActive = txtActive.Text
            strAvailable = txtAvailable.Text

            If (strActive = "YES" And strAvailable = "NO") Then

                strBJCNumberFromTable = CStr(txtBJCNumber.Text)

                If strBJCNumber = strBJCNumberFromTable Then
                    blnBJCNumberFound = True
                    mintSelectedIndex(mintCounter) = intCounter
                    mintCounter = mintCounter + 1

                End If

            End If

        Next

        If blnBJCNumberFound = False Then
            MessageBox.Show("The Was not Found or Not Signed Out", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        mintSearchedUpperLimit = mintCounter - 1

        If mintSearchedUpperLimit > 0 Then
            btnStandardNext.Enabled = True
        End If

        mintCounter = 0
        cboVehicleID.SelectedIndex = mintSelectedIndex(mintCounter)
        mintEmployeeID = CInt(txtEmployeeID.Text)

        FindEmployeeID(mintEmployeeID)

        txtBJCNumberEntered.Text = ""

    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click

        'Resets the form to initial condition
        SetTheVehicleForm()

    End Sub

    Private Sub txtBJCNumberEntered_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBJCNumberEntered.KeyDown

        If e.KeyCode = Keys.Enter Then
            btnFindBJCNumber.PerformClick()
            btnReset.Focus()
        End If

    End Sub

    Private Sub ClearDataBindings()

        'Clearing the Employee Bindings
        cboEmployeeID.DataBindings.Clear()
        txtFirstName.DataBindings.Clear()
        txtLastName.DataBindings.Clear()
        txtPhoneNumber.DataBindings.Clear()

        'Clearing the Vehicle bindings
        cboVehicleID.DataBindings.Clear()
        txtAvailable.DataBindings.Clear()
        txtActive.DataBindings.Clear()
        txtEmployeeID.DataBindings.Clear()
        txtMake.DataBindings.Clear()
        txtLicencePlate.DataBindings.Clear()
        txtModel.DataBindings.Clear()
        txtNotes.DataBindings.Clear()
        txtYear.DataBindings.Clear()

    End Sub
End Class