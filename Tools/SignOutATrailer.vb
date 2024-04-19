'Title:         Sign Out A Trailer
'Date:          3/20/14
'Author:        Terry Holmes

'Description:   This form is used to sign out a trailer

Option Strict On

Public Class SignOutATrailer

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

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        'Closes the Program
        CloseTheProgram.ShowDialog()

    End Sub

    Private Sub btnMainMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMainMenu.Click

        'Shows Main Menu
        ClearDataBinding()
        MainMenu.Show()
        Me.Close()

    End Sub

    Private Sub btnTrailerMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTrailerMenu.Click

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

    Private Sub SignOutATrailer_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

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

    Private Sub txtBJCNumberEntered_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBJCNumberEntered.KeyDown

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

        'Performing DataValidation
        strValueForValidation = CStr(txtBJCNumberEntered.Text)
        blnFatalError = TheInputDataValidation.VerifyIntegerData(strValueForValidation)

        If blnFatalError = True Then
            txtBJCNumberEntered.Text = ""
            MessageBox.Show("The BJC Number Entered is not an Integer", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        setTrailerTextBoxesVisible(True)

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
            MessageBox.Show("The BJC Number does not Exist", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        cboTrailerID.SelectedIndex = intSelectedIndex
        btnSearchByEmployeeID.Enabled = True
        btnSearchByEmployeeLastName.Enabled = True
        txtBJCNumberEntered.Text = ""

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

    Private Sub btnSearchByEmployeeID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchByEmployeeID.Click

        'Variables for Validation
        Dim blnFatalError As Boolean
        Dim strValueForValidation As String
        Dim blnEmployeeIDNotFound As Boolean = True

        'Variables to Find Employee ID
        Dim intNumberOfRecords As Integer
        Dim intCounter As Integer
        Dim intEmployeeIDEntered As Integer
        Dim intEmployeeIDFromTable As Integer
        Dim intSelectedIndex As Integer

        strValueForValidation = CStr(txtEmployeeIDSearch.Text)
        blnFatalError = TheInputDataValidation.VerifyIntegerData(strValueForValidation)

        If blnFatalError = True Then
            txtEmployeeIDSearch.Text = ""
            MessageBox.Show("The Employee ID Entered is not an Integer", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        SetEmployeeTextBoxesVisible(True)

        'Setting up condition for Employee ID
        intNumberOfRecords = cboEmployeeID.Items.Count - 1
        intEmployeeIDEntered = CInt(txtEmployeeIDSearch.Text)

        'Beginning Loop to find Employee ID
        For intCounter = 0 To intNumberOfRecords

            'Loading Loop Variables\
            cboEmployeeID.SelectedIndex = intCounter
            intEmployeeIDFromTable = CInt(cboEmployeeID.Text)

            'Doing compare
            If intEmployeeIDEntered = intEmployeeIDFromTable Then
                blnEmployeeIDNotFound = False
                intSelectedIndex = intCounter
            End If

        Next

        'Checking to see if the ID Was Found
        If blnEmployeeIDNotFound = True Then
            txtEmployeeIDSearch.Text = ""
            MessageBox.Show("Employee ID Not Found", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        'Setting Condition
        cboEmployeeID.SelectedIndex = intSelectedIndex
        txtEmployeeIDSearch.Text = ""
        btnSignOut.Enabled = True

    End Sub

    Private Sub txtEmployeeIDSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEmployeeIDSearch.KeyDown

        If e.KeyCode = Keys.Enter Then
            btnSearchByEmployeeID.PerformClick()
        End If

    End Sub

    Private Sub btnSearchByEmployeeLastName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchByEmployeeLastName.Click

        'Setting Data Validation Variables
        Dim blnFatalError As Boolean
        Dim blnLastNameNotFound As Boolean = True
        Dim strValueForValidation As String

        'Setting local variables for finding Employee Name
        Dim intNumberOfRecords As Integer
        Dim intCounter As Integer
        Dim strLastNameEntered As String
        Dim strLastNameFromTable As String

        'Performing Data Validation on Input
        strValueForValidation = CStr(txtLastNameSearch.Text)
        blnFatalError = TheInputDataValidation.VerifyTextData(strValueForValidation)

        If blnFatalError = True Then
            txtLastNameSearch.Text = ""
            MessageBox.Show("The Employee Last Name was not Entered", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        SetEmployeeTextBoxesVisible(True)

        'Setting up information for the Last Name Search
        intNumberOfRecords = cboEmployeeID.Items.Count - 1
        strLastNameEntered = strValueForValidation
        mintCounter = 0

        'Performing Loop
        For intCounter = 0 To intNumberOfRecords

            'Loading up loop variables
            cboEmployeeID.SelectedIndex = intCounter
            strLastNameFromTable = txtLastName.Text

            'Performing Compare
            If strLastNameEntered = strLastNameFromTable Then

                'Setting Variables for Recall
                mintSelectedIndex(mintCounter) = intCounter
                mintCounter = mintCounter + 1
                blnLastNameNotFound = False

            End If

        Next

        If blnLastNameNotFound = True Then
            txtLastNameSearch.Text = ""
            MessageBox.Show("The Last Name Entered Does Not Exist", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        mintUpperLimit = mintCounter - 1
        mintCounter = 0
        cboEmployeeID.SelectedIndex = mintSelectedIndex(0)

        If mintUpperLimit > 0 Then
            btnNext.Enabled = True
        End If

        txtLastNameSearch.Text = ""
        btnSignOut.Enabled = True

    End Sub

    Private Sub txtLastNameSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLastNameSearch.KeyDown

        'This is used to find the name if the enter button is pressed
        If e.KeyCode = Keys.Enter Then
            btnSearchByEmployeeLastName.PerformClick()
        End If

    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click

        'This is used to go through the employees
        mintCounter = mintCounter + 1
        cboEmployeeID.SelectedIndex = mintSelectedIndex(mintCounter)

        btnBack.Enabled = True

        If mintCounter = mintUpperLimit Then
            btnNext.Enabled = False
        End If

    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click

        'This is used to go through the employees
        mintCounter = mintCounter - 1
        cboEmployeeID.SelectedIndex = mintSelectedIndex(mintCounter)

        btnNext.Enabled = True

        If mintCounter = 0 Then
            btnBack.Enabled = False
        End If

    End Sub

    Private Sub btnSignOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSignOut.Click

        Dim intTrailerEmployeeID As Integer
        Dim strfirstName As String
        Dim strLastName As String
        Dim intBJCNumber As Integer
        Dim intTrailerID As Integer
        Dim strSignOutMessage As String

        'Preforming Data Validation
        If txtActive.Text = "NO" Then
            MessageBox.Show("The Trailer is not Active and Cannot be Signed Out", "Please Change", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If txtAvailable.Text = "NO" Then
            MessageBox.Show("Trailer is Already Signed Out", "Please Change", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        'Loading up Variables and Textboxes for Signing Out
        intTrailerEmployeeID = CInt(cboEmployeeID.Text)
        txtAvailable.Text = "NO"
        txtEmployeeID.Text = CStr(intTrailerEmployeeID)
        strfirstName = CStr(txtFirstName.Text)
        strLastName = CStr(txtLastName.Text)
        intBJCNumber = CInt(txtBJCNumber.Text)
        intTrailerID = CInt(cboTrailerID.Text)

        'Loading Up Global Variables
        Logon.mintTrailerID = intTrailerID
        Logon.mintHistoryEmployeeID = intTrailerEmployeeID
        Logon.mstrLogDateTime = strLogDateTime
        Logon.mintBJCNumber = intBJCNumber
        Logon.mstrNotes = "TRAILER SIGNED OUT"

        Try
            TheTrailersBindingSource.EndEdit()
            TheTrailersDataTier.UpdateDB(TheTrailersDataSet)
            addingBoolean = False
            editingBoolean = False
            setComboBoxBinding()
            cboTrailerID.SelectedIndex = previousSelectedIndex

            AddingTrailerHistory.Show()

            strSignOutMessage = "Trailer " + CStr(intBJCNumber) + " Was Signed Out" + vbNewLine
            strSignOutMessage = strSignOutMessage + "By " + strfirstName + " " + strLastName + vbNewLine

            txtBJCNumberEntered.Text = ""
            txtEmployeeIDSearch.Text = ""
            txtLastNameSearch.Text = ""
            btnSignOut.Enabled = False
            SetEmployeeTextBoxesVisible(False)
            setTrailerTextBoxesVisible(False)
            btnNext.Enabled = False
            btnBack.Enabled = False
            btnSearchByEmployeeID.Enabled = False
            btnSearchByEmployeeLastName.Enabled = False

            MessageBox.Show(strSignOutMessage, "Thank You", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
End Class