'Title:         Sign In A Tool
'Date:          7/18/13
'Author:        Terry Holmes

'Description:   This Form is used to Sign in a Tool

Option Strict On

Public Class SignInATool

    'Setting Modular Variables
    Private TheEmployeeDataSet As EmployeeDataSet
    Private TheEmployeeDataTier As EmployeeDataTier
    Private WithEvents TheEmployeeBindingSource As BindingSource

    Private TheToolsDataSet As toolsDataSet
    Private TheToolsDataTier As ToolsDataTier
    Private WithEvents TheToolsBindingSource As BindingSource

    Dim TheInputDataValidation As New InputDataValidation

    Private addingBoolean As Boolean = False
    Private editingBoolean As Boolean = False
    Private previousSelectedIndex As Integer
    Dim mintNumuberOfRecords As Integer

    Dim LogDateTime As Date = DateAndTime.Now
    Dim strLogDateTime As String
    Dim mblnEmployeeIDFound As Boolean
    Dim mintSelectedIndex(10) As Integer
    Dim mintCounter As Integer
    Dim mblnLastNameFound As Boolean
    Dim mintUpperLimit As Integer

    'Variables for History
    Friend mintToolID As Integer
    Friend mintEmployeeID As Integer
    Friend mstrLogDateTime As String
    Friend mstrAvailability As String
    Friend mstrNotes As String

    Private Sub SignInATool_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

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

            VisibleEmployeeTextBoxes(False)
            VisibleToolTextBoxes(False)

        Catch ex As Exception

            'If an exception is thrown, it is rounted here
            cboToolID.Visible = False
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        'Closes the Program
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
            txtGroup.ReadOnly = valueBoolean
            txtActive.ReadOnly = valueBoolean
            txtEmployeeID.ReadOnly = valueBoolean
            txtDate.ReadOnly = valueBoolean
            txtPartNumber.ReadOnly = valueBoolean
            txtType.ReadOnly = valueBoolean
            txtDescription.ReadOnly = valueBoolean
            txtValue.ReadOnly = valueBoolean
            txtAvailable.ReadOnly = valueBoolean
            txtNotes.ReadOnly = valueBoolean
        End With

    End Sub
  
    Private Sub btnFindTool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindTool.Click

        'This sub-routine runs when the Find Tool button is pressed
        Dim blnFatalError As Boolean
        Dim strToolIDEntered As String
        Dim strToolIDFromTable As String
        Dim intToolCBOSelectedIndex As Integer
        Dim intNumberOfRecords As Integer
        Dim intCounter As Integer
        Dim blnToolIDNotFound As Boolean = True
        Dim intEmployeeIDFromTools As Integer
        Dim strValueForValidation As String
        Dim strAvailable As String
        Dim strActive As String
        Dim blnToolAlreadySignedIn As Boolean = True

        'Setting Validation Variable initial condition
        blnFatalError = False

        strValueForValidation = txtToolID.Text
        blnFatalError = TheInputDataValidation.VerifyTextData(strValueForValidation)


        'Sending Error Message to User
        If blnFatalError = True Then
            MessageBox.Show("The Tool ID was not Entered", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        btnSignIn.Enabled = True
        VisibleEmployeeTextBoxes(True)
        VisibleToolTextBoxes(True)

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
                If strActive = "YES" And strAvailable = "NO" Then
                    blnToolAlreadySignedIn = False
                    intToolCBOSelectedIndex = intCounter
                End If
            End If

        Next

        'Putting out Error Message or moving the Combo Box
        If blnToolIDNotFound = True Then
            VisibleEmployeeTextBoxes(False)
            VisibleToolTextBoxes(False)
            MessageBox.Show("Tool ID Not Found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        ElseIf blnToolAlreadySignedIn = True Then
            VisibleEmployeeTextBoxes(False)
            VisibleToolTextBoxes(False)
            MessageBox.Show("Tool Already Signed In", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        Else
            cboToolID.SelectedIndex = intToolCBOSelectedIndex
        End If

        'Setting the buttons up for signing out the tool
        setComboBoxBinding()
        strLogDateTime = CStr(LogDateTime)
        txtDate.Text = strLogDateTime

        intEmployeeIDFromTools = CInt(txtEmployeeID.Text)

        FindEmployeeID(intEmployeeIDFromTools)

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

    Private Sub btnSignIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSignIn.Click

        'This routine will sign out a tool
        Dim intEmployeeID As Integer
        Dim strFirstName As String
        Dim strLastName As String
        Dim strToolID As String
        Dim strSignOutMessage As String
        Dim strHomeOffice As String


        'Performing Data Validation
        If txtActive.Text = "NO" Then
            MessageBox.Show("This Tool has Been Retired, it can not be Signed In", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If txtAvailable.Text = "YES" Then
            MessageBox.Show("The Tool is already Signed In", "Thank You", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        strHomeOffice = Logon.mstrHomeOffice

        If strHomeOffice = "CLEVELAND" Then
            intEmployeeID = 100000
        ElseIf strHomeOffice = "ELMIRA" Then
            intEmployeeID = 100001
        End If

        'Loading up Variables and Textboxes
        txtAvailable.Text = "YES"
        txtEmployeeID.Text = CStr(intEmployeeID)
        strFirstName = "WAREHOUSE"
        strLastName = "WAREHOUSE"
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

        SignOutATool.Show()
        SignOutATool.Hide()

        Logon.mstrToolID = strToolID
        Logon.mintEmployeeID = CInt(cboEmployeeID.Text)
        Logon.mstrLogDateTime = strLogDateTime
        Logon.mstrAvailability = "SIGNED IN"
        Logon.mstrNotes = txtNotes.Text

        AddingToolHistory.Show()

        'SignOutATool.Close()

        'Setting up the form for the next Tool
        txtToolID.Text = ""
        btnSignIn.Enabled = False
        VisibleEmployeeTextBoxes(False)
        VisibleToolTextBoxes(False)

        'Outputting a Message to the User
        strSignOutMessage = "Tool ID of " + strToolID + " is Signed In" + vbNewLine

        MessageBox.Show(strSignOutMessage, "Thank You", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub ClearDataBindings()

        cboEmployeeID.DataBindings.Clear()
        txtFirstName.DataBindings.Clear()
        txtLastName.DataBindings.Clear()
        txtGroup.DataBindings.Clear()
        txtPhoneNumber.DataBindings.Clear()

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
            btnFindTool.PerformClick()
        End If
    End Sub

    Private Sub VisibleToolTextBoxes(ByVal valueBoolean As Boolean)

        'cboToolID.Visible = valueBoolean
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