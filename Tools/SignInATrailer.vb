'Title:         Sign In A Trailer
'Date:          3/24/14
'Author:        Terry Holmes

'Description:   This form is used to sign in a trailer

Option Strict On

Public Class SignInATrailer

    'Setting Modular Variables
    Private TheEmployeeDataSet As EmployeeDataSet
    Private TheEmployeeDataTier As EmployeeDataTier
    Private WithEvents TheEmployeeBindingSource As BindingSource

    Private TheTrailersDataSet As TrailersDataSet
    Private TheTrailersDataTier As TrailersDataTier
    Private WithEvents TheTrailersBindingSource As BindingSource

    Private addingBoolean As Boolean = False
    Private editingBoolean As Boolean = False
    Private previousSelectedIndex As Integer
    Dim mintNumuberOfRecords As Integer

    Dim TheInputDataValidation As New InputDataValidation

    Dim LogDateTime As Date = DateAndTime.Now
    Dim strLogDateTime As String
    Dim mintSelectedIndex(10000) As Integer
    Dim mintCounter As Integer
    Dim mintUpperLimit As Integer

    'Variables for History
    Dim mintTrailerID As Integer
    Dim mintEmployeeID As Integer
    Dim mstrLogDateTime As String
    Dim mstrNotes As String
    Dim mintBJCNumber As Integer

    Private Sub btnTrailerMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'Shows the trailer menu
        ClearDataBinding()
        TrailerMenu.Show()
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

        With Me.cboTrailerID
            If (addingBoolean Or editingBoolean) Then
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.OnValidation
                .DropDownStyle = ComboBoxStyle.Simple
            Else
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.Never
                .DropDownStyle = ComboBoxStyle.DropDownList
            End If
        End With

    End Sub

    Private Sub setTrailerTextBoxesVisible(ByVal valueBoolean As Boolean)

        'Makes the controls either visible or not
        txtActive.Visible = valueBoolean
        txtAvailable.Visible = valueBoolean
        txtBJCNumber.Visible = valueBoolean
        txtDate.Visible = valueBoolean
        txtEmployeeID.Visible = valueBoolean
        txtLicencePlate.Visible = valueBoolean
        txtNotes.Visible = valueBoolean

    End Sub
    Private Sub SetEmployeeTextBoxesVisible(ByVal valueBoolean As Boolean)

        'Makes Control Visible or not
        txtPhoneNumber.Visible = valueBoolean
        txtFirstName.Visible = valueBoolean
        txtLastName.Visible = valueBoolean

    End Sub

    Private Sub txtBJCNumberEntered_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)

        'Runs when the Enter Key is entered
        If e.KeyCode = Keys.Enter Then
            btnFindTrailer.PerformClick()
        End If

    End Sub

    Private Sub btnFindTrailer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindTrailer.Click

        'This routine runs when the button is pressed or a button press call is made
        Dim intNumberOfRecords As Integer = 0
        Dim intCounter As Integer = 0
        Dim intSelectedIndex As Integer = 0
        Dim blnFatalError As Boolean
        Dim strValueForValidation As String
        Dim intBJCNumberEntered As Integer
        Dim intBJCNumberFromTable As Integer
        Dim blnBJCNumberNotFound As Boolean = True
        Dim strActive As String = ""
        Dim intEmployeeIDEntered As Integer
        Dim intEmployeeIDFromTable As Integer

        'Performing DataValidation
        strValueForValidation = CStr(txtBJCNumberEntered.Text)
        blnFatalError = TheInputDataValidation.VerifyIntegerData(strValueForValidation)

        If blnFatalError = True Then
            txtBJCNumberEntered.Text = ""
            MessageBox.Show("The BJC Number Entered is not an Integer", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        setTrailerTextBoxesVisible(True)
        SetEmployeeTextBoxesVisible(True)

        'Finding Trailer
        'Setting Up main variables
        intBJCNumberEntered = CInt(strValueForValidation)
        intNumberOfRecords = cboTrailerID.Items.Count - 1

        'Performing Loop
        For intCounter = 0 To intNumberOfRecords

            'Loading up loop variables
            cboTrailerID.SelectedIndex = intCounter
            intBJCNumberFromTable = CInt(txtBJCNumber.Text)
            strActive = CStr(txtActive.Text)

            'Doing Comparison Check
            If intBJCNumberEntered = intBJCNumberFromTable Then
                If strActive = "YES" Then
                    blnBJCNumberNotFound = False
                    intSelectedIndex = intCounter
                End If
            End If
        Next

        'Validation for exiting Trailer Number
        If blnBJCNumberNotFound = True Then
            txtBJCNumberEntered.Text = ""
            setTrailerTextBoxesVisible(False)
            SetEmployeeTextBoxesVisible(False)
            MessageBox.Show("The BJC Number does not Exist", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        cboTrailerID.SelectedIndex = intSelectedIndex
        txtBJCNumberEntered.Text = ""

        intEmployeeIDEntered = CInt(txtEmployeeID.Text)
        intNumberOfRecords = cboEmployeeID.Items.Count - 1

        For intCounter = 0 To intNumberOfRecords
            cboEmployeeID.SelectedIndex = intCounter
            intEmployeeIDFromTable = CInt(cboEmployeeID.Text)
            If intEmployeeIDEntered = intEmployeeIDFromTable Then
                intSelectedIndex = intCounter
            End If
        Next

        cboEmployeeID.SelectedIndex = intSelectedIndex

        btnSignIn.Enabled = True
        btnSignIn.Focus()

    End Sub
    Private Sub ClearDataBinding()

        'Clears Databindings for the module
        txtActive.DataBindings.Clear()
        txtAvailable.DataBindings.Clear()
        txtBJCNumber.DataBindings.Clear()
        txtDate.DataBindings.Clear()
        txtEmployeeID.DataBindings.Clear()
        txtFirstName.DataBindings.Clear()
        txtLastName.DataBindings.Clear()
        txtNotes.DataBindings.Clear()
        txtPhoneNumber.DataBindings.Clear()

    End Sub

    Private Sub btnVehicleMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTrailerMenu.Click

        'Shows the trailer menu
        ClearDataBinding()
        TrailerMenu.Show()
        Me.Close()

    End Sub

    Private Sub SignInATrailer_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

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
            TheTrailersDataTier = New TrailersDataTier
            TheTrailersDataSet = TheTrailersDataTier.GetTrailersInformation
            TheTrailersBindingSource = New BindingSource

            'Setting the binding for the combo box
            With TheTrailersBindingSource
                .DataSource = TheTrailersDataSet
                .DataMember = "trailers"
                .MoveFirst()
                .MoveLast()
            End With

            'Binding controls to for the binding for the combo box
            With cboTrailerID
                .DataSource = TheTrailersBindingSource
                .DisplayMember = "TrailerID"
                .DataBindings.Add("text", TheTrailersBindingSource, "VehicleID", False, DataSourceUpdateMode.Never)
            End With

            'Setting the binding for all other textbox controls

            txtBJCNumber.DataBindings.Add("text", TheTrailersBindingSource, "BJCNumber")
            txtLicencePlate.DataBindings.Add("text", TheTrailersBindingSource, "LicensePlate")
            txtEmployeeID.DataBindings.Add("text", TheTrailersBindingSource, "EmployeeID")
            txtDate.DataBindings.Add("text", TheTrailersBindingSource, "Date")
            txtAvailable.DataBindings.Add("text", TheTrailersBindingSource, "Available")
            txtActive.DataBindings.Add("text", TheTrailersBindingSource, "Active")
            txtNotes.DataBindings.Add("text", TheTrailersBindingSource, "Notes")

            setTrailerTextBoxesVisible(False)
            SetEmployeeTextBoxesVisible(False)

        Catch ex As Exception

            'If an exception is thrown, it is rounted here
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnMainMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMainMenu.Click

        'Shows Main Menu
        ClearDataBinding()
        MainMenu.Show()
        Me.Close()

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        'Closes the Program
        CloseTheProgram.ShowDialog()

    End Sub

    Private Sub txtBJCNumberEntered_KeyDown1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBJCNumberEntered.KeyDown

        'Will activate the button
        If e.KeyCode = Keys.Enter Then
            btnFindTrailer.PerformClick()
        End If

    End Sub

    Private Sub btnSignIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSignIn.Click

        'This routine will sign out a tool
        Dim intEmployeeID As Integer
        Dim strFirstName As String
        Dim strLastName As String
        Dim intTrailerID As Integer
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

        strHomeOffice = Logon.mstrHomeOffice
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
        txtEmployeeID.Text = CStr(intEmployeeID)
        strFirstName = txtFirstName.Text
        strLastName = txtLastName.Text
        intBJCNumber = CInt(txtBJCNumber.Text)
        intTrailerID = CInt(cboTrailerID.Text)

        'Updating the Database
        Try
            TheTrailersBindingSource.EndEdit()
            TheTrailersDataTier.UpdateDB(TheTrailersDataSet)
            addingBoolean = False
            editingBoolean = False
            setComboBoxBinding()
            cboTrailerID.SelectedIndex = previousSelectedIndex

        Catch ex As Exception
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


        Logon.mintBJCNumber = intBJCNumber
        Logon.mintTrailerID = intTrailerID
        Logon.mintHistoryEmployeeID = intEmployeeID
        Logon.mstrNotes = "TRAILER SIGNED BACK IN"
        Logon.mstrLogDateTime = strLogDateTime

        AddingTrailerHistory.Show()

        'Outputting a Message to the User
        strSignOutMessage = "BJC" + CStr(intBJCNumber) + " is Signed In" + vbNewLine

        'Setting up the form for the next Tool
        txtBJCNumberEntered.Text = ""
        btnSignIn.Enabled = False
        txtLastName.Visible = False
        txtFirstName.Visible = False
        txtPhoneNumber.Visible = False

        SetEmployeeTextBoxesVisible(False)
        setTrailerTextBoxesVisible(False)

        MessageBox.Show(strSignOutMessage, "Thank You", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub
End Class