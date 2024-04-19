'Title:         Tool Sign Out Form
'Date:          7/16/13
'Author:        Terry Holmes

'Description:   This form is used to signout a Tool

Option Strict On

Public Class SignOutATool

    'Setting Modular Variables
    Private TheEmployeeDataSet As EmployeeDataSet
    Private TheEmployeeDataTier As EmployeeDataTier
    Private WithEvents TheEmployeeBindingSource As BindingSource

    Private TheToolsDataSet As toolsDataSet
    Private TheToolsDataTier As ToolsDataTier
    Private WithEvents TheToolsBindingSource As BindingSource

    Private addingBoolean As Boolean = False
    Private editingBoolean As Boolean = False
    Private previousSelectedIndex As Integer
    Dim mintNumuberOfRecords As Integer

    Dim TheInputDataValidation As New InputDataValidation

    Dim LogDateTime As Date = DateAndTime.Now
    Dim strLogDateTime As String
    Dim mblnEmployeeIDFound As Boolean
    Dim mintSelectedIndex(10) As Integer
    Dim mintCounter As Integer
    Dim mblnLastNameFound As Boolean
    Dim mintUpperLimit As Integer


    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        ''Closes the Program
        CloseTheProgram.ShowDialog()

    End Sub

    Private Sub btnToolMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToolMenu.Click

        'Opens the Tool Menu
        ClearDataBindings()
        ToolsMenu.Show()
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

        With Me.cboToolID
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
            txtEmployeeActive.ReadOnly = valueBoolean
            txtFirstName.ReadOnly = valueBoolean
            txtLastName.ReadOnly = valueBoolean
            txtPhoneNumber.ReadOnly = valueBoolean
            txtActive.ReadOnly = valueBoolean
            txtEmployeeID.ReadOnly = valueBoolean
            txtDate.ReadOnly = valueBoolean
            txtPartNumber.ReadOnly = valueBoolean
            txtType.ReadOnly = valueBoolean
            txtDescription.ReadOnly = valueBoolean
            txtValue.ReadOnly = valueBoolean
            txtAvailable.ReadOnly = valueBoolean
            txtNotes.ReadOnly = valueBoolean
            txtGroup.ReadOnly = valueBoolean
        End With

    End Sub

    Private Sub SignOutATool_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

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
            txtEmployeeActive.DataBindings.Add("text", TheEmployeeBindingSource, "Active")
            txtPhoneNumber.DataBindings.Add("text", TheEmployeeBindingSource, "PhoneNumber")
            txtGroup.DataBindings.Add("text", TheEmployeeBindingSource, "Group")

            'This will bind the controls to the data source
            TheToolsDataTier = New ToolsDataTier
            TheToolsDataSet = TheToolsDataTier.GetToolInformation
            TheToolsBindingSource = New BindingSource

            'Setting the binding for the combo box
            With TheToolsBindingSource
                .DataSource = TheToolsDataSet
                .DataMember = "tools"
                .MoveFirst()
                .MoveLast()
            End With

            'Binding controls to for the binding for the combo box
            With cboToolID
                .DataSource = TheToolsBindingSource
                .DisplayMember = "ToolID"
                .DataBindings.Add("text", TheToolsBindingSource, "ToolID", False, DataSourceUpdateMode.Never)
            End With

            'Setting the binding for all other textbox controls
            txtEmployeeID.DataBindings.Add("text", TheToolsBindingSource, "EmployeeID")
            txtDate.DataBindings.Add("text", TheToolsBindingSource, "Date")
            txtPartNumber.DataBindings.Add("text", TheToolsBindingSource, "PartNumber")
            txtType.DataBindings.Add("text", TheToolsBindingSource, "Type")
            txtDescription.DataBindings.Add("text", TheToolsBindingSource, "Description")
            txtValue.DataBindings.Add("text", TheToolsBindingSource, "Value")
            txtAvailable.DataBindings.Add("text", TheToolsBindingSource, "Available")
            txtActive.DataBindings.Add("text", TheToolsBindingSource, "Active")
            txtNotes.DataBindings.Add("text", TheToolsBindingSource, "Notes")

            setControlsReadOnly(True)

            cboEmployeeID.Visible = False
            VisibleEmployeeTextBoxes(False)
            VisibleToolTextBoxes(False)

        Catch ex As Exception

            'If an exception is thrown, it is rounted here
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    Private Sub btnFindTool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindTool.Click

        'This sub-routine runs when the Find Tool button is pressed
        Dim blnFatalError As Boolean
        Dim strErrorMessage As String
        Dim strToolIDEntered As String
        Dim strToolIDFromTable As String
        Dim intToolCBOSelectedIndex As Integer
        Dim intNumberOfRecords As Integer
        Dim intCounter As Integer
        Dim blnToolIDNotFound As Boolean = True
        Dim intEmployeeIDFromTools As Integer
        Dim strValueForValidation As String
        Dim strActive As String
        Dim strAvailable As String
        Dim blnToolAlreadySignedOut As Boolean = True
        Dim intEmployeeCounter As Integer
        Dim intEmployeeNumberOfRecords As Integer
        Dim intEmployeeIDForSearcch As Integer
        Dim intEmployeeIDFromTable As Integer
        Dim strFirstName As String = ""
        Dim strLastName As String = ""
        Dim strMessageBoxMessage As String

        btnNext.Enabled = False
        btnBack.Enabled = False

        'Setting Validation Variable initial condition
        blnFatalError = False
        strErrorMessage = ""

        'Checking that information was added into the Tool ID
        strValueForValidation = txtToolID.Text
        blnFatalError = TheInputDataValidation.VerifyTextData(strValueForValidation)

        'Sending Error Message to User
        If blnFatalError = True Then
            MessageBox.Show("The Tool ID was not Entered", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        VisibleToolTextBoxes(True)

        btnSearchByEmployeeID.Enabled = True
        btnSearchByEmployeeLastName.Enabled = True


        'Setting Variables for Tool ID Search
        strToolIDEntered = txtToolID.Text
        intNumberOfRecords = cboToolID.Items.Count

        'Performing Search
        For intCounter = 0 To intNumberOfRecords - 1
            cboToolID.SelectedIndex = intCounter
            strToolIDFromTable = cboToolID.Text
            strActive = txtActive.Text
            strAvailable = txtAvailable.Text

            If strToolIDEntered = strToolIDFromTable Then
                blnToolIDNotFound = False
                If strActive = "YES" And strAvailable = "YES" Then
                    blnToolAlreadySignedOut = False
                    intToolCBOSelectedIndex = intCounter
                ElseIf strActive = "YES" And strAvailable = "NO" Then

                    'Setting up employee Controls visible
                    VisibleEmployeeTextBoxes(True)

                    'Setting up for employee search
                    intEmployeeNumberOfRecords = cboEmployeeID.Items.Count - 1
                    intEmployeeIDForSearcch = CInt(txtEmployeeID.Text)

                    'Beginning Loop
                    For intEmployeeCounter = 0 To intEmployeeNumberOfRecords

                        'incrementing the combo box
                        cboEmployeeID.SelectedIndex = intEmployeeCounter

                        'Getting employee id from table
                        intEmployeeIDFromTable = CInt(cboEmployeeID.Text)

                        'Checking to see if they match
                        If intEmployeeIDFromTable = intEmployeeIDForSearcch Then

                            'Setting up string
                            strLastName = txtLastName.Text
                            strFirstName = txtFirstName.Text

                        End If
                    Next

                End If

            End If

        Next

        strMessageBoxMessage = "Tool ID " + strToolIDEntered + " Is Signed Out To " + strFirstName + " " + strLastName

        'Putting out Error Message or moving the Combo Box
        If blnToolIDNotFound = True Then
            cboToolID.Visible = False
            VisibleToolTextBoxes(False)
            txtToolID.Text = ""
            MessageBox.Show("Tool ID Not Found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        ElseIf blnToolAlreadySignedOut = True Then
            cboToolID.Visible = False
            VisibleToolTextBoxes(False)
            VisibleEmployeeTextBoxes(False)
            txtToolID.Text = ""
            MessageBox.Show(strMessageBoxMessage, "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        Else
            cboToolID.SelectedIndex = intToolCBOSelectedIndex
        End If

        'Setting the buttons up for signing out the tool
        setComboBoxBinding()
        strLogDateTime = CStr(LogDateTime)
        txtDate.Text = strLogDateTime
        txtEmployeeIDSearch.Text = ""
        txtLastNameSearch.Text = ""

        intEmployeeIDFromTools = CInt(txtEmployeeID.Text)

        FindEmployeeID(intEmployeeIDFromTools)

        cboToolID.Visible = False

    End Sub

    Private Sub btnSignOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSignOut.Click

        'This routine will sign out a tool
        Dim intEmployeeID As Integer
        Dim strFirstName As String
        Dim strLastName As String
        Dim strToolID As String
        Dim strSignOutMessage As String

        'Performing Data Validation
        If txtActive.Text = "NO" Then
            MessageBox.Show("Tool is not an Active Tool, it can not be signed out", "Please Change", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If txtAvailable.Text = "NO" Then
            MessageBox.Show("Tool is not Available, please Sign Tool in First", "Please Change", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        cboToolID.Visible = True

        'Loading up Variables and Textboxes
        intEmployeeID = CInt(cboEmployeeID.Text)
        txtAvailable.Text = "NO"
        txtEmployeeID.Text = CStr(intEmployeeID)
        strFirstName = CStr(txtFirstName.Text)
        strLastName = CStr(txtLastName.Text)
        strToolID = CStr(cboToolID.Text)

        'Updating the Database
        Try
            TheToolsBindingSource.EndEdit()
            TheToolsDataTier.UpdateToolDB(TheToolsDataSet)
            addingBoolean = False
            editingBoolean = False
            setControlsReadOnly(True)
            setComboBoxBinding()
            cboToolID.SelectedIndex = previousSelectedIndex

        Catch ex As Exception
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Logon.mstrToolID = strToolID
        Logon.mintEmployeeID = CInt(cboEmployeeID.Text)
        Logon.mstrLogDateTime = strLogDateTime
        Logon.mstrAvailability = "SIGNED OUT"
        Logon.mstrNotes = txtNotes.Text

        AddingToolHistory.Show()

        cboToolID.Visible = False

        'Outputting a Message to the User
        strSignOutMessage = "Tool ID of " + strToolID + " Was Signed Out" + vbNewLine
        strSignOutMessage = strSignOutMessage + "By " + strFirstName + " " + strLastName + vbNewLine

        VisibleToolTextBoxes(False)
        VisibleEmployeeTextBoxes(False)

        MessageBox.Show(strSignOutMessage, "Thank You", MessageBoxButtons.OK, MessageBoxIcon.Information)


        'Setting up the form for the next Tool
        txtToolID.Text = ""
        txtEmployeeIDSearch.Text = ""
        txtLastNameSearch.Text = ""
        btnSignOut.Enabled = False
        btnSearchByEmployeeID.Enabled = False
        btnSearchByEmployeeLastName.Enabled = False
        btnNext.Enabled = False
        btnBack.Enabled = False
        

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

    Private Sub btnSearchByEmployeeID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchByEmployeeID.Click

        'This subroutine will run if the user is looking for the Employee ID
        Dim intEmployeeIDEntered As Integer
        Dim blnFatalError As Boolean
        Dim strValueForValidation As String

        btnBack.Enabled = False
        btnNext.Enabled = False

        'Setting initial Data Validation variables
        blnFatalError = False

        strValueForValidation = txtEmployeeIDSearch.Text
        blnFatalError = TheInputDataValidation.VerifyIntegerData(strValueForValidation)
        

        If blnFatalError = True Then
            MessageBox.Show("The Employee ID Entered is not an Integer", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        VisibleEmployeeTextBoxes(True)
        btnSignOut.Enabled = True

        'Sets vaue of the local variable
        intEmployeeIDEntered = CInt(txtEmployeeIDSearch.Text)

        'Call sub-routine
        FindEmployeeID(intEmployeeIDEntered)

        'Message to the user
        If mblnEmployeeIDFound = False Then
            VisibleEmployeeTextBoxes(False)
            txtEmployeeIDSearch.Text = ""
            MessageBox.Show("Employee ID Entered Does Not Exist", "Please Try Again", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
    End Sub

    Private Sub btnSearchByEmployeeLastName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchByEmployeeLastName.Click

        'This routine is used to search for by Last Name

        btnBack.Enabled = False
        btnNext.Enabled = False
        Dim strLastNameEntered As String
        Dim strLastNameFromTable As String
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim blnFatalError As Boolean
        Dim strErrorMessage As String

        btnNext.Enabled = False
        btnBack.Enabled = False

        'Setting validation variables
        blnFatalError = False
        strErrorMessage = ""
        mblnLastNameFound = False

        'Performing Validation
        If txtLastNameSearch.Text = "" Then
            blnFatalError = True
            strErrorMessage = strErrorMessage + "No Last Name was entered to be searched" + vbNewLine
        End If

        'Letting User Know if there was a problem
        If blnFatalError = True Then
            MessageBox.Show(strErrorMessage, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        'Making Textboxes Visible
        VisibleEmployeeTextBoxes(True)
        btnSignOut.Enabled = True
        btnNext.Enabled = False
        btnBack.Enabled = False

        'Setting initial variables
        strLastNameEntered = CStr(txtLastNameSearch.Text)
        intNumberOfRecords = cboEmployeeID.Items.Count
        mintCounter = 0

        'Looking for Employee's Last Name
        For intCounter = 0 To intNumberOfRecords - 1
            cboEmployeeID.SelectedIndex = intCounter
            strLastNameFromTable = CStr(txtLastName.Text)

            If strLastNameEntered = strLastNameFromTable Then
                mintSelectedIndex(mintCounter) = intCounter
                mintCounter = mintCounter + 1
                mblnLastNameFound = True
            End If
        Next

        'Performing Output to User
        If mblnLastNameFound = False Then
            MessageBox.Show("The Employee Last Name was not Found", "Please Verify and Try again", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        'Enabling the Next Button
        If mintCounter > 1 Then
            btnNext.Enabled = True
        End If

        'Setting the Upper Limit Variable
        mintUpperLimit = mintCounter - 1
        mintCounter = 0

        'Placing the the Combobox in the first location
        cboEmployeeID.SelectedIndex = mintSelectedIndex(mintCounter)


    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click

        'This Routine will run the Next Buttons
        mintCounter = mintCounter + 1
        cboEmployeeID.SelectedIndex = mintSelectedIndex(mintCounter)
        btnBack.Enabled = True


        If mintCounter = mintUpperLimit Then
            btnNext.Enabled = False

        End If

    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click

        'This will run the Back Button
        mintCounter = mintCounter - 1
        cboEmployeeID.SelectedIndex = mintSelectedIndex(mintCounter)


        If mintCounter = 0 Then
            btnBack.Enabled = False
        End If

        If mintCounter < mintUpperLimit Then
            btnNext.Enabled = True
        End If

    End Sub

    

    Private Sub txtEmployeeIDSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEmployeeIDSearch.KeyDown

        If e.KeyCode = Keys.Enter Then
            btnSearchByEmployeeID.PerformClick()
        End If

    End Sub

    Private Sub txtLastNameSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLastNameSearch.KeyDown

        If e.KeyCode = Keys.Enter Then
            btnSearchByEmployeeLastName.PerformClick()
        End If

    End Sub
    Private Sub ClearDataBindings()

        cboEmployeeID.DataBindings.Clear()
        txtFirstName.DataBindings.Clear()
        txtLastName.DataBindings.Clear()
        txtPhoneNumber.DataBindings.Clear()
        txtGroup.DataBindings.Clear()

        cboToolID.DataBindings.Clear()
        txtEmployeeID.DataBindings.Clear()
        txtDate.DataBindings.Clear()
        txtPartNumber.DataBindings.Clear()
        txtType.DataBindings.Clear()
        txtDescription.DataBindings.Clear()
        txtValue.DataBindings.Clear()
        txtNotes.DataBindings.Clear()
        txtAvailable.DataBindings.Clear()
        txtActive.DataBindings.Clear()

    End Sub

    Private Sub txtToolID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtToolID.KeyDown

        If e.KeyCode = Keys.Enter Then
            txtEmployeeIDSearch.Focus()
            btnFindTool.PerformClick()
        End If
    End Sub

    Private Sub VisibleToolTextBoxes(ByVal valueBoolean As Boolean)

        cboToolID.Visible = valueBoolean
        txtEmployeeID.Visible = valueBoolean
        txtDate.Visible = valueBoolean
        txtPartNumber.Visible = valueBoolean
        txtType.Visible = valueBoolean
        txtDescription.Visible = valueBoolean
        txtDate.Visible = valueBoolean
        txtAvailable.Visible = valueBoolean
        txtActive.Visible = valueBoolean
        txtNotes.Visible = valueBoolean
        txtValue.Visible = valueBoolean

    End Sub
    Private Sub VisibleEmployeeTextBoxes(ByVal valueBoolean As Boolean)

        txtLastName.Visible = valueBoolean
        txtFirstName.Visible = valueBoolean
        txtPhoneNumber.Visible = valueBoolean
        txtGroup.Visible = valueBoolean
    End Sub
End Class