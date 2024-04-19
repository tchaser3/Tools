'Title:         Sign In A Vehicle
'Date:          7/23/13
'Author:        Terry Holmes

'Description:   This form is used to Sign in a Vehicle

Option Strict On

Public Class SignInAVehicle

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

    Dim TheInputDataValidation As New InputDataValidation

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
    Private Sub setControlsReadOnly(ByVal valueBoolean As Boolean)

        'This will set controls either to read only or not
        With Me

            txtFirstName.ReadOnly = valueBoolean
            txtLastName.ReadOnly = valueBoolean
            txtPhoneNumber.ReadOnly = valueBoolean

            txtBJCNumber.ReadOnly = valueBoolean
            txtYear.ReadOnly = valueBoolean
            txtMake.ReadOnly = valueBoolean
            txtModel.ReadOnly = valueBoolean
            txtLicencePlate.ReadOnly = valueBoolean
            txtEmployeeID.ReadOnly = valueBoolean
            txtDate.ReadOnly = valueBoolean
            txtNotes.ReadOnly = valueBoolean
            txtAvailable.ReadOnly = valueBoolean
            txtActive.ReadOnly = valueBoolean
            txtOutOfTown.ReadOnly = valueBoolean
            txtVehicleHomeOffice.ReadOnly = valueBoolean

        End With

    End Sub
    
    Private Sub setTextBoxesVisible(ByVal valueBoolean As Boolean)

        'This will set controls either to visible or not
        txtFirstName.Visible = valueBoolean
        txtLastName.Visible = valueBoolean
        txtPhoneNumber.Visible = valueBoolean

        txtBJCNumber.Visible = valueBoolean
        txtYear.Visible = valueBoolean
        txtMake.Visible = valueBoolean
        txtModel.Visible = valueBoolean
        txtLicencePlate.Visible = valueBoolean
        txtEmployeeID.Visible = valueBoolean
        txtDate.Visible = valueBoolean
        txtNotes.Visible = valueBoolean
        txtAvailable.Visible = valueBoolean
        txtActive.Visible = valueBoolean
        txtOutOfTown.Visible = valueBoolean
        txtVehicleHomeOffice.Visible = valueBoolean

    End Sub
   
    Private Sub SignInAVehicle_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Try - Catch is used to protect the make sure that the program loads correctly
        'And if there is a problem, the exception is routed to a Message Box, instead of 
        'the whole program crashing

        PleaseWait.Show()

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

            'Setting the binding for all other textbox controls

            txtBJCNumber.DataBindings.Add("text", TheVehiclesBindingSource, "BJCNumber")
            txtYear.DataBindings.Add("text", TheVehiclesBindingSource, "Year")
            txtMake.DataBindings.Add("text", TheVehiclesBindingSource, "Make")
            txtModel.DataBindings.Add("text", TheVehiclesBindingSource, "Model")
            txtLicencePlate.DataBindings.Add("text", TheVehiclesBindingSource, "LicencePlate")
            txtEmployeeID.DataBindings.Add("text", TheVehiclesBindingSource, "EmployeeID")
            txtDate.DataBindings.Add("text", TheVehiclesBindingSource, "Date")
            txtAvailable.DataBindings.Add("text", TheVehiclesBindingSource, "Available")
            txtActive.DataBindings.Add("text", TheVehiclesBindingSource, "Active")
            txtNotes.DataBindings.Add("text", TheVehiclesBindingSource, "Notes")
            txtOutOfTown.DataBindings.Add("text", TheVehiclesBindingSource, "OutOfTown")
            txtVehicleHomeOffice.DataBindings.Add("text", TheVehiclesBindingSource, "HomeOffice")

            setControlsReadOnly(True)

            setTextBoxesVisible(False)

            PleaseWait.Close()

        Catch ex As Exception

            'If an exception is thrown, it is rounted here
            PleaseWait.Close()
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

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

    Private Sub btnFindVehicle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindVehicle.Click

        'This sub-routine runs when the Find Tool button is pressed
        Dim blnFatalError As Boolean
        Dim intBJCNumberEntered As Integer
        Dim intBJCNumberFromTable As Integer
        Dim intVehicleIDCBOSelectedIndex As Integer
        Dim intNumberOfRecords As Integer
        Dim intCounter As Integer
        Dim blnBJCNumberNotFound As Boolean = True
        Dim intEmployeeIDFromTools As Integer

        'Setting Validation Variable initial condition
        blnFatalError = False

        blnFatalError = TheInputDataValidation.VerifyIntegerData(txtBJCNumberEntered.Text)

        'Sending Error Message to User
        If blnFatalError = True Then
            MessageBox.Show("The Value Entered for BJC Number is not an Integer", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        setTextBoxesVisible(True)

        'Setting Variables for Tool ID Search
        intBJCNumberEntered = CInt(txtBJCNumberEntered.Text)
        intNumberOfRecords = cboVehicleID.Items.Count

        'Performing Search
        For intCounter = 0 To intNumberOfRecords - 1
            cboVehicleID.SelectedIndex = intCounter
            intBJCNumberFromTable = CInt(txtBJCNumber.Text)

            If intBJCNumberEntered = intBJCNumberFromTable Then
                blnBJCNumberNotFound = False
                intVehicleIDCBOSelectedIndex = intCounter
            End If

        Next

        'Putting out Error Message or moving the Combo Box
        If blnBJCNumberNotFound = True Then
            MessageBox.Show("The BJC Number Entered Was Not Found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        Else
            cboVehicleID.SelectedIndex = intVehicleIDCBOSelectedIndex
        End If

        'Setting the buttons up for signing out the tool
        setComboBoxBinding()
        strLogDateTime = CStr(LogDateTime)
        txtDate.Text = strLogDateTime

        btnSignIn.Enabled = True

        intEmployeeIDFromTools = CInt(txtEmployeeID.Text)

        FindEmployeeID(intEmployeeIDFromTools)

    End Sub

    Private Sub btnSignIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSignIn.Click

        'This routine will sign out a tool
        Dim intEmployeeID As Integer
        Dim strFirstName As String
        Dim strLastName As String
        Dim intVehicleID As Integer
        Dim strSignOutMessage As String
        Dim intBJCNumber As Integer
        Dim strHomeOffice As String
        Dim intNumberOfRecords As Integer
        Dim intSelectedIndex As Integer
        Dim strFirstNameFromTable As String
        Dim strLastNameFromTable As String

        'Performing Data Validation
        If txtActive.Text = "NO" Then
            MessageBox.Show("This Vehicle has Been Retired, it can not be Signed In", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If txtAvailable.Text = "YES" Then
            MessageBox.Show("This Vehicle is already Signed In", "Thank You", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        'Loading up Variables and Textboxes

        strHomeOffice = txtVehicleHomeOffice.Text
        intNumberOfRecords = cboEmployeeID.Items.Count - 1

        For intCounter = 0 To intNumberOfRecords

            cboEmployeeID.SelectedIndex = intCounter
            strFirstNameFromTable = txtFirstName.Text
            strLastNameFromTable = txtLastName.Text
            If strLastNameFromTable = "WAREHOUSE" And strFirstNameFromTable = strHomeOffice Then
                intSelectedIndex = intCounter
            End If

        Next

        cboEmployeeID.SelectedIndex = intSelectedIndex
        intEmployeeID = CInt(cboEmployeeID.Text)

        txtAvailable.Text = "YES"
        txtOutOfTown.Text = "NO"
        Logon.mstrRemoteVehicle = txtOutOfTown.Text
        txtEmployeeID.Text = CStr(intEmployeeID)
        strFirstName = txtFirstName.Text
        strLastName = txtLastName.Text
        intBJCNumber = CInt(txtBJCNumber.Text)
        intVehicleID = CInt(cboVehicleID.Text)

        'Updating the Database
        Try
            TheVehiclesBindingSource.EndEdit()
            TheVehiclesDataTier.UpdateDB(TheVehiclesDataSet)
            addingBoolean = False
            editingBoolean = False
            setControlsReadOnly(True)
            setComboBoxBinding()
            cboVehicleID.SelectedIndex = previousSelectedIndex

        Catch ex As Exception
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


        Logon.mintBJCNumber = intBJCNumber
        Logon.mintVehicleID = intVehicleID
        Logon.mintHistoryEmployeeID = intEmployeeID
        Logon.mstrNotes = "VEHICLE SIGNED BACK IN"
        Logon.mstrLogDateTime = strLogDateTime

        AddingVehicleHistory.Show()

        'Outputting a Message to the User
        strSignOutMessage = "BJC" + CStr(intBJCNumber) + " is Signed In" + vbNewLine

        MessageBox.Show(strSignOutMessage, "Thank You", MessageBoxButtons.OK, MessageBoxIcon.Information)

        'Setting up the form for the next Tool
        txtBJCNumberEntered.Text = ""
        btnSignIn.Enabled = False
        txtLastName.Visible = False
        txtFirstName.Visible = False
        txtPhoneNumber.Visible = False

    End Sub


    Private Sub txtBJCNumberEntered_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBJCNumberEntered.KeyDown

        If e.KeyCode = Keys.Enter Then
            btnFindVehicle.PerformClick()
            btnSignIn.Focus()
        End If

    End Sub

    Private Sub ClearDataBindings()

        cboEmployeeID.DataBindings.Clear()
        txtFirstName.DataBindings.Clear()
        txtLastName.DataBindings.Clear()
        txtPhoneNumber.DataBindings.Clear()

        cboVehicleID.DataBindings.Clear()
        txtBJCNumber.DataBindings.Clear()
        txtYear.DataBindings.Clear()
        txtMake.DataBindings.Clear()
        txtModel.DataBindings.Clear()
        txtLicencePlate.DataBindings.Clear()
        txtEmployeeID.DataBindings.Clear()
        txtDate.DataBindings.Clear()
        txtNotes.DataBindings.Clear()
        txtAvailable.DataBindings.Clear()
        txtActive.DataBindings.Clear()

    End Sub
End Class