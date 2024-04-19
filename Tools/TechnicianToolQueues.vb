'Title:         Tools Per Technician
'Date:          7/22/13
'Author:        Terry Holmes

'Description:   This will allow the display of tools per Technician

Option Strict On

Public Class TechnicianToolQueues

    'Setting Modular Variables
    Private TheEmployeeDataSet As EmployeeDataSet
    Private TheEmployeeDataTier As EmployeeDataTier
    Private WithEvents TheEmployeeBindingSource As BindingSource

    Dim TheInputDataValidation As New InputDataValidation

    Private TheToolsDataSet As toolsDataSet
    Private TheToolsDataTier As ToolsDataTier
    Private WithEvents TheToolsBindingSource As BindingSource

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

    'Variables for History
    Friend mintToolID As Integer
    Friend mintEmployeeID As Integer
    Friend mstrLogDateTime As String
    Friend mstrAvailability As String
    Friend mstrNotes As String

    Dim mintSearchedUpperLimit As Integer

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
            txtActive.ReadOnly = valueBoolean
            txtEmployeeID.ReadOnly = valueBoolean
            txtDate.ReadOnly = valueBoolean
            txtPartNumber.ReadOnly = valueBoolean
            txtType.ReadOnly = valueBoolean
            txtDescription.ReadOnly = valueBoolean
            txtValue.ReadOnly = valueBoolean
            txtAvailable.ReadOnly = valueBoolean
            txtNotes.ReadOnly = valueBoolean
            txtToolID.ReadOnly = valueBoolean
        End With

    End Sub
    Private Sub setButtonsForEdit()



    End Sub
    Private Sub ResetButtonAfterEditing()



    End Sub

    Private Sub TechnicianToolQueues_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
            txtToolID.DataBindings.Add("text", TheToolsBindingSource, "ToolID")

            setControlsReadOnly(True)

            VisibleTextBoxes(False)
           

        Catch ex As Exception

            'If an exception is thrown, it is rounted here
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub VisibleTextBoxes(ByVal valueBoolean As Boolean)

        txtFirstName.Visible = valueBoolean
        txtLastName.Visible = valueBoolean
        txtPhoneNumber.Visible = valueBoolean
        txtEmployeeID.Visible = valueBoolean
        txtDate.Visible = valueBoolean
        txtPartNumber.Visible = valueBoolean
        txtType.Visible = valueBoolean
        txtDescription.Visible = valueBoolean
        txtValue.Visible = valueBoolean
        txtAvailable.Visible = valueBoolean
        txtActive.Visible = valueBoolean
        txtNotes.Visible = valueBoolean
        txtToolID.Visible = valueBoolean
        txtLastName.Visible = valueBoolean
        txtFirstName.Visible = valueBoolean
        txtPhoneNumber.Visible = valueBoolean

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
        Dim strErrorMessage As String = ""

        'Setting initial Data Validation variables
        blnFatalError = False
        strValueForValidation = txtEmployeeIDSearch.Text
        blnFatalError = TheInputDataValidation.VerifyIntegerData(strValueForValidation)

        If blnFatalError = True Then
            txtEmployeeIDSearch.Text = ""
            MessageBox.Show("The Employee ID Entered is not an Integer", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        'Sets vaue of the local variable
        intEmployeeIDEntered = CInt(txtEmployeeIDSearch.Text)

        If Logon.mstrGroup = "USER" Then
            If intEmployeeIDEntered <> Logon.mintEmployeeID Then
                blnFatalError = True
                strErrorMessage = strErrorMessage + "You are not Authorized to Look at That Technician" + vbNewLine
            End If

        End If

        If blnFatalError = True Then
            VisibleTextBoxes(False)
            txtEmployeeIDSearch.Text = ""
            MessageBox.Show(strErrorMessage, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        btnFindTools.Enabled = True
        VisibleTextBoxes(True)

        'Call sub-routine
        FindEmployeeID(intEmployeeIDEntered)

        'Message to the user
        If mblnEmployeeIDFound = False Then
            MessageBox.Show("Employee ID Entered Does Not Exist", "Please Try Again", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        btnFindTools.PerformClick()

    End Sub

    Private Sub btnSearchByEmployeeLastName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchByEmployeeLastName.Click

        'This routine is used to search for by Last Name

        Dim strLastNameEntered As String
        Dim strLastNameFromTable As String
        Dim strFirstNameEntered As String
        Dim strFirstNameFromTable As String
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim blnFatalError As Boolean
        Dim strErrorMessage As String
        Dim strValueForValidation As String

        'Setting validation variables
        blnFatalError = False
        strErrorMessage = ""
        mblnLastNameFound = False

        strValueForValidation = txtSearchFirstName.Text
        blnFatalError = TheInputDataValidation.VerifyTextData(strValueForValidation)

        If blnFatalError = True Then
            MessageBox.Show("The First Name was not Entered", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        strValueForValidation = txtSearchLastName.Text
        blnFatalError = TheInputDataValidation.VerifyTextData(strValueForValidation)

        If blnFatalError = True Then
            MessageBox.Show("The Last Name was not Entered", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If


        strLastNameEntered = CStr(txtSearchLastName.Text)
        strFirstNameEntered = CStr(txtSearchFirstName.Text)

        If Logon.mstrGroup = "USER" Then
            If strLastNameEntered <> Logon.mstrLastName And strFirstNameEntered <> Logon.mstrFirstName Then
                blnFatalError = True
                strErrorMessage = strErrorMessage + "You Are Not Authorized to Look at That Technician" + vbNewLine
            End If
        End If

        'Letting User Know if there was a problem
        If blnFatalError = True Then
            MessageBox.Show(strErrorMessage, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        'Making Textboxes Visible
       
        btnFindTools.Enabled = True
        VisibleTextBoxes(True)

        'Setting initial variables
        intNumberOfRecords = cboEmployeeID.Items.Count
        mintCounter = 0

        'Looking for Employee's Last Name
        For intCounter = 0 To intNumberOfRecords - 1
            cboEmployeeID.SelectedIndex = intCounter
            strLastNameFromTable = CStr(txtLastName.Text)
            strFirstNameFromTable = CStr(txtFirstName.Text)

            If strLastNameEntered = strLastNameFromTable And strFirstNameEntered = strFirstNameFromTable Then
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

        'Setting the Upper Limit Variable
        mintUpperLimit = mintCounter - 1
        mintCounter = 0

        'Placing the the Combobox in the first location
        cboEmployeeID.SelectedIndex = mintSelectedIndex(mintCounter)

        btnFindTools.PerformClick()

    End Sub


    Private Sub txtEmployeeIDSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEmployeeIDSearch.KeyDown

        If e.KeyCode = Keys.Enter Then
            btnSearchByEmployeeID.PerformClick()
        End If

    End Sub

    Private Sub txtLastNameSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)

        If e.KeyCode = Keys.Enter Then
            btnSearchByEmployeeLastName.PerformClick()
        End If

    End Sub

    Private Sub btnFindTools_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindTools.Click

        'This routine will sign out a tool
        Dim intEmployeeID As Integer
        Dim strFirstName As String
        Dim strLastName As String
        
       
        'Setting Local Variables
        intEmployeeID = CInt(cboEmployeeID.Text)
        strFirstName = CStr(txtFirstName.Text)
        strLastName = CStr(txtLastName.Text)


        If Logon.mstrGroup = "USER" Then

            If intEmployeeID <> Logon.mintEmployeeID Then
                MessageBox.Show("Your are Not Authorized to View That Technician's Queue", "Please Exit", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

        End If

        'cboToolID.Visible = True

        'Loading up Variables and Textboxes
        intEmployeeID = CInt(cboEmployeeID.Text)

        FindToolsPerTechnician()


    End Sub

    Private Sub FindToolsPerTechnician()

        Dim intCounter As Integer
        Dim strEmployeeID As String
        Dim strEmployeeIDFromTable As String
        Dim blnToolFound As Boolean = False

        btnStandardBack.Enabled = False
        btnStandardNext.Enabled = False


        'This subroutine will run to set the initial Condition
        For intCounter = 0 To 9999
            mintSelectedIndex(intCounter) = -1
        Next

        mintUpperLimit = cboToolID.Items.Count - 1
        mintCounter = 0

        strEmployeeID = CStr(cboEmployeeID.Text)

        For intCounter = 0 To mintUpperLimit

            cboToolID.SelectedIndex = intCounter

            strEmployeeIDFromTable = CStr(txtEmployeeID.Text)

            If strEmployeeID = strEmployeeIDFromTable Then
                blnToolFound = True
                mintSelectedIndex(mintCounter) = intCounter
                mintCounter = mintCounter + 1

            End If

        Next

        If blnToolFound = False Then
            VisibleTextBoxes(False)
            btnFindTools.Enabled = False
            MessageBox.Show("This Technician has No Tools Signed Out", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        mintSearchedUpperLimit = mintCounter - 1

        If mintSearchedUpperLimit > 0 Then
            btnStandardNext.Enabled = True
        End If

        mintCounter = 0
        cboToolID.SelectedIndex = mintSelectedIndex(mintCounter)
        mintEmployeeID = CInt(txtEmployeeID.Text)

        FindEmployeeID(mintEmployeeID)



    End Sub
    Private Sub btnStandardNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStandardNext.Click

        'This Routine will run the Next Buttons
        mintCounter = mintCounter + 1
        cboToolID.SelectedIndex = mintSelectedIndex(mintCounter)

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
        cboToolID.SelectedIndex = mintSelectedIndex(mintCounter)


        If mintCounter = 0 Then
            btnStandardBack.Enabled = False
        End If

        If mintCounter < mintUpperLimit Then
            btnStandardNext.Enabled = True
        End If

        mintEmployeeID = CInt(txtEmployeeID.Text)

        FindEmployeeID(mintEmployeeID)

    End Sub
    Private Sub ClearDataBindings()

        cboEmployeeID.DataBindings.Clear()
        txtFirstName.DataBindings.Clear()
        txtLastName.DataBindings.Clear()
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
    
    Private Sub txtSearchFirstName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearchFirstName.KeyDown

        If e.KeyCode = Keys.Enter Then
            btnSearchByEmployeeLastName.PerformClick()
        End If

    End Sub

    Private Sub txtSearchLastName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearchLastName.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtSearchFirstName.Focus()
        End If
    End Sub
End Class
