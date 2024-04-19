'Title:         Tool History Form
'Date:          7/18/13
'Author:        Terry Holmes

'Description:   This form displays the Tool History

Option Strict On

Public Class ToolHistory

    'Setting Modular Variables
    Private TheEmployeeDataSet As EmployeeDataSet
    Private TheEmployeeDataTier As EmployeeDataTier
    Private WithEvents TheEmployeeBindingSource As BindingSource
    Private WithEvents TheWarehouseEmployeeBindingSource As BindingSource

    Dim TheInputDataValidation As New InputDataValidation

    Private TheToolsDataSet As toolsDataSet
    Private TheToolsDataTier As ToolsDataTier
    Private WithEvents TheToolsBindingSource As BindingSource

    Private TheToolsHistoryDataSet As ToolsHistoryDataSet
    Private TheToolHistoryDataTier As ToolHistoryDataTier
    Private WithEvents TheToolsHistoryBindingSource As BindingSource

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
    Dim mintEmployeeID As Integer
    Dim mintWarehouseID As Integer
    Dim mstrToolID As String
    Dim mintSearchUpperLimit As Integer


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
                'Else
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.Never
                .DropDownStyle = ComboBoxStyle.DropDownList
            End If

        End With

        With Me.cboTransactionID
            If (addingBoolean Or editingBoolean) Then
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.OnValidation
                .DropDownStyle = ComboBoxStyle.Simple
            Else
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.Never
                .DropDownStyle = ComboBoxStyle.DropDownList
            End If
        End With

        With Me.cboWareHouseEmployeeID
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
           
        End With

    End Sub
    Private Sub setButtonsForEdit()



    End Sub
    Private Sub ResetButtonAfterEditing()



    End Sub

    Private Sub ToolHistory_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'This sub-routine runs when the form is loaded

        'Locks the controls to readonly
        setControlsReadOnly()

        Try
            'This will bind the controls to the data source
            TheToolHistoryDataTier = New ToolHistoryDataTier
            TheToolsHistoryDataSet = TheToolHistoryDataTier.GetHistoryInformation
            TheToolsHistoryBindingSource = New BindingSource

            'Setting the binding for the combo box
            With TheToolsHistoryBindingSource
                .DataSource = TheToolsHistoryDataSet
                .DataMember = "toolhistory"
                .MoveFirst()
                .MoveLast()
            End With

            'Binding controls to for the binding for the combo box
            With cboTransactionID
                .DataSource = TheToolsHistoryBindingSource
                .DisplayMember = "TransactionID"
                .DataBindings.Add("text", TheToolsHistoryBindingSource, "TransactionID", False, DataSourceUpdateMode.Never)
            End With

            'Setting the binding for all other textbox controls
            txtHistoryEmployeeID.DataBindings.Add("text", TheToolsHistoryBindingSource, "EmployeeID")
            txtHistoryDate.DataBindings.Add("text", TheToolsHistoryBindingSource, "Date")
            txtHistoryAvailable.DataBindings.Add("text", TheToolsHistoryBindingSource, "Availablity")
            txtHistoryNotes.DataBindings.Add("text", TheToolsHistoryBindingSource, "Notes")
            txtHistoryToolID.DataBindings.Add("text", TheToolsHistoryBindingSource, "ToolID")
            txtHistoryWareHouseEmployeeID.DataBindings.Add("Text", TheToolsHistoryBindingSource, "WarehouseEmployeeID")

        Catch ex As Exception
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Try

            'This will bind the controls to the data source
            TheEmployeeDataTier = New EmployeeDataTier
            TheEmployeeDataSet = TheEmployeeDataTier.GetEmployeeInformation
            TheEmployeeBindingSource = New BindingSource
            TheWareHouseEmployeeBindingSource = New BindingSource

            'Setting up Binding Source for the Combo Box
            With TheEmployeeBindingSource
                .DataSource = TheEmployeeDataSet
                .DataMember = "employees"
                .MoveFirst()
                .MoveLast()
            End With

            'Setting up Binding Source for the Combo Box
            With TheWarehouseEmployeeBindingSource
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

            With cboWareHouseEmployeeID
                .DataSource = TheWarehouseEmployeeBindingSource
                .DisplayMember = "EmployeeID"
                .DataBindings.Add("text", TheEmployeeBindingSource, "EmployeeID", False, DataSourceUpdateMode.Never)
            End With


            'Setting the data binding for the text boxes
            txtFirstName.DataBindings.Add("text", TheEmployeeBindingSource, "FirstName")
            txtLastName.DataBindings.Add("text", TheEmployeeBindingSource, "LastName")
            txtPhoneNumber.DataBindings.Add("text", TheEmployeeBindingSource, "PhoneNumber")

            'Setting the data binding for the text boxes
            txtWarehouseFirstName.DataBindings.Add("text", TheWarehouseEmployeeBindingSource, "FirstName")
            txtWarehouselastName.DataBindings.Add("text", TheWarehouseEmployeeBindingSource, "LastName")
            txtWarehousePhoneNumber.DataBindings.Add("text", TheWarehouseEmployeeBindingSource, "PhoneNumber")


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
            txtToolEmployeeID.DataBindings.Add("text", TheToolsBindingSource, "EmployeeID")
            txtToolDate.DataBindings.Add("text", TheToolsBindingSource, "Date")
            txtToolPartNumber.DataBindings.Add("text", TheToolsBindingSource, "PartNumber")
            txtToolType.DataBindings.Add("text", TheToolsBindingSource, "Type")
            txtToolDescription.DataBindings.Add("text", TheToolsBindingSource, "Description")
            txtToolValue.DataBindings.Add("text", TheToolsBindingSource, "Value")
            txtToolAvailable.DataBindings.Add("text", TheToolsBindingSource, "Available")
            txtToolActive.DataBindings.Add("text", TheToolsBindingSource, "Active")
            txtToolNotes.DataBindings.Add("text", TheToolsBindingSource, "Notes")

            'cboEmployeeID.Visible = False
            'txtFirstName.Visible = False
            'txtLastName.Visible = False
            'txtPhoneNumber.Visible = False

        Catch ex As Exception

            'If an exception is thrown, it is rounted here
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        mintUpperLimit = cboTransactionID.Items.Count - 1
        mintCounter = 0
        cboTransactionID.SelectedIndex = 0

        If mintUpperLimit > 1 Then
            btnHistoryNext.Enabled = True
        End If

        mintEmployeeID = CInt(txtHistoryEmployeeID.Text)
        mintWarehouseID = CInt(txtHistoryWareHouseEmployeeID.Text)
        mstrToolID = txtHistoryToolID.Text

        'FindEmployeeID(mintEmployeeID)
        'FindWarehouseEmployeeID(mintWarehouseID)
        'FindToolID(mintToolID)

    End Sub

    Private Sub SetControlsReadOnly()

        'This sets the TextBoxes to ReadOnly

        'This sets Readonly for the employee area
        txtFirstName.ReadOnly = True
        txtLastName.ReadOnly = True
        txtPhoneNumber.ReadOnly = True

        'This sets Readonly for the Warehouse Employee
        txtWarehouseFirstName.ReadOnly = True
        txtWarehouselastName.ReadOnly = True
        txtWarehousePhoneNumber.ReadOnly = True

        'This sets the History Transaction Textboxes to Readonly
        txtHistoryAvailable.ReadOnly = True
        txtHistoryDate.ReadOnly = True
        txtHistoryEmployeeID.ReadOnly = True
        txtHistoryNotes.ReadOnly = True
        txtHistoryToolID.ReadOnly = True
        txtHistoryWareHouseEmployeeID.ReadOnly = True

        'This sets the Tool Textboxes to Readonly
        txtToolActive.ReadOnly = True
        txtToolAvailable.ReadOnly = True
        txtToolDate.ReadOnly = True
        txtToolDescription.ReadOnly = True
        txtToolEmployeeID.ReadOnly = True
        txtToolNotes.ReadOnly = True
        txtToolPartNumber.ReadOnly = True
        txtToolType.ReadOnly = True
        txtToolValue.ReadOnly = True

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

    Private Sub FindWarehouseEmployeeID(ByVal intEmployeeID As Integer)

        'Setting Local Variables
        Dim intEmployeeIDFromTable As Integer
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim intSelectedIndexFound As Integer

        'Setting the value of the variables
        mblnEmployeeIDFound = False
        intNumberOfRecords = cboWareHouseEmployeeID.Items.Count

        'Performing Compare
        For intCounter = 0 To intNumberOfRecords - 1

            cboWareHouseEmployeeID.SelectedIndex = intCounter
            intEmployeeIDFromTable = CInt(cboWareHouseEmployeeID.Text)

            If intEmployeeIDFromTable = intEmployeeID Then
                mblnEmployeeIDFound = True
                intSelectedIndexFound = intCounter
            End If

        Next

        'Setting Combobox Selected Index
        If mblnEmployeeIDFound = True Then
            cboWareHouseEmployeeID.SelectedIndex = intSelectedIndexFound
        End If

    End Sub

    Private Sub btnHistoryNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHistoryNext.Click

        'This increments the Next Buttons for History Transaction Searches
        Dim intSelectedIndex As Integer

        intSelectedIndex = cboTransactionID.SelectedIndex
        intSelectedIndex = intSelectedIndex + 1
        cboTransactionID.SelectedIndex = intSelectedIndex

        If intSelectedIndex < mintUpperLimit And intSelectedIndex <> 0 Then
            btnHistoryBack.Enabled = True
        End If

        mintEmployeeID = CInt(txtHistoryEmployeeID.Text)
        mintWarehouseID = CInt(txtHistoryWareHouseEmployeeID.Text)
        mstrToolID = txtHistoryToolID.Text

        FindEmployeeID(mintEmployeeID)
        FindWarehouseEmployeeID(mintWarehouseID)
        FindToolID(mstrToolID)

        If intSelectedIndex = mintUpperLimit Then
            btnHistoryNext.Enabled = False
        End If

    End Sub

    Private Sub btnHistoryBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHistoryBack.Click

        'This increments the Next Buttons for History Transaction Searches
        Dim intSelectedIndex As Integer

        intSelectedIndex = cboTransactionID.SelectedIndex
        intSelectedIndex = intSelectedIndex - 1
        cboTransactionID.SelectedIndex = intSelectedIndex

        If intSelectedIndex < mintUpperLimit And intSelectedIndex <> mintUpperLimit Then
            btnHistoryNext.Enabled = True
        End If

        mintEmployeeID = CInt(txtHistoryEmployeeID.Text)
        mintWarehouseID = CInt(txtHistoryWareHouseEmployeeID.Text)
        mstrToolID = txtHistoryToolID.Text

        FindEmployeeID(mintEmployeeID)
        FindWarehouseEmployeeID(mintWarehouseID)
        FindToolID(mstrToolID)

        If intSelectedIndex = 0 Then
            btnHistoryBack.Enabled = False
        End If
    End Sub
    Private Sub FindToolID(ByVal strToolID As String)

        'Setting Local Variables
        Dim strToolIDFromTable As String
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim intSelectedIndexFound As Integer

        'Setting the value of the variables
        mblnEmployeeIDFound = False
        intNumberOfRecords = cboToolID.Items.Count

        'Performing Compare
        For intCounter = 0 To intNumberOfRecords - 1

            cboToolID.SelectedIndex = intCounter
            strToolIDFromTable = cboToolID.Text

            If strToolIDFromTable = strToolID Then
                mblnEmployeeIDFound = True
                intSelectedIndexFound = intCounter
            End If

        Next

        'Setting Combobox Selected Index
        If mblnEmployeeIDFound = True Then
            cboToolID.SelectedIndex = intSelectedIndexFound
        End If

    End Sub

    Private Sub btnFindTool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindTool.Click

        'This Routine Runs to find all transactions for a Tool ID

        'Setting Local Variables
        Dim intCounter As Integer
        Dim strToolIDEntered As String
        Dim strToolIDFromTable As String
        Dim blnFatalError As Boolean
        Dim strErrorMessage As String
        Dim blnToolIDNotFound As Boolean
        Dim strValueForValidation As String

        'Setting initial conditions
        btnIDBack.Enabled = False
        btnIDNext.Enabled = False

        'Setting Local Variables for validation
        blnToolIDNotFound = True
        blnFatalError = False
        strErrorMessage = ""

        strValueForValidation = txtToolIDForSearching.Text
        TheInputDataValidation.VerifyTextData(strValueForValidation)

        If blnFatalError = True Then
            MessageBox.Show("Tool ID Not Entered", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtToolIDForSearching.Text = ""
            Exit Sub
        End If

        strToolIDEntered = txtToolIDForSearching.Text
        mintCounter = 0

        For intCounter = 0 To mintUpperLimit

            cboTransactionID.SelectedIndex = intCounter
            strToolIDFromTable = txtHistoryToolID.Text

            If strToolIDEntered = strToolIDFromTable Then

                mintSelectedIndex(mintCounter) = intCounter
                mintCounter = mintCounter + 1
                blnToolIDNotFound = False

            End If

        Next

        If blnToolIDNotFound = False Then
            btnHistoryBack.Enabled = False
            btnHistoryNext.Enabled = False
        Else
            MessageBox.Show("Tool ID Entered Has No History", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        mintSearchUpperLimit = mintCounter - 1
        mintCounter = 0

        cboTransactionID.SelectedIndex = mintSelectedIndex(mintCounter)
        mstrToolID = txtHistoryToolID.Text
        mintEmployeeID = CInt(txtHistoryEmployeeID.Text)
        mintWarehouseID = CInt(txtHistoryWareHouseEmployeeID.Text)

        FindEmployeeID(mintEmployeeID)
        FindWarehouseEmployeeID(mintWarehouseID)
        'FindToolID(mintToolID)

        If mintSearchUpperLimit > 1 Then
            btnIDNext.Enabled = True
        End If

        txtToolIDForSearching.Text = ""
    End Sub

    Private Sub btnSearchByEmployeeID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchByEmployeeID.Click

        'Setting Local Variables
        Dim intCounter As Integer
        Dim intEmployeeIDEntered As Integer
        Dim intEmployeeIDFromTable As Integer
        Dim blnFatalError As Boolean
        Dim strErrorMessage As String
        Dim blnEmployeeIDNotFound As Boolean
        Dim strValueForValidation As String

        'Setting initial conditions
        btnIDNext.Enabled = False
        btnIDBack.Enabled = False

        'Setting Local Variables for validation
        blnEmployeeIDNotFound = True
        blnFatalError = False
        strErrorMessage = ""


        strValueForValidation = txtSearchEmployeeID.Text
        blnFatalError = TheInputDataValidation.VerifyIntegerData(strValueForValidation)


        If blnFatalError = True Then
            MessageBox.Show("Employee ID is not an Integer", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtSearchEmployeeID.Text = ""
            Exit Sub
        End If

        intEmployeeIDEntered = CInt(txtSearchEmployeeID.Text)
        mintCounter = 0

        For intCounter = 0 To mintUpperLimit

            cboTransactionID.SelectedIndex = intCounter
            intEmployeeIDFromTable = CInt(txtHistoryEmployeeID.Text)

            If intEmployeeIDEntered = intEmployeeIDFromTable Then

                mintSelectedIndex(mintCounter) = intCounter
                mintCounter = mintCounter + 1
                blnEmployeeIDNotFound = False

            End If

        Next

        If blnEmployeeIDNotFound = False Then
            btnHistoryBack.Enabled = False
            btnHistoryNext.Enabled = False
        Else
            MessageBox.Show("Employee ID Entered Has No History", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        mintSearchUpperLimit = mintCounter - 1
        mintCounter = 0

        cboTransactionID.SelectedIndex = mintSelectedIndex(mintCounter)
        mstrToolID = txtHistoryToolID.Text
        mintEmployeeID = CInt(txtHistoryEmployeeID.Text)
        mintWarehouseID = CInt(txtHistoryWareHouseEmployeeID.Text)

        FindEmployeeID(mintEmployeeID)
        FindWarehouseEmployeeID(mintWarehouseID)
        'FindToolID(mintToolID)

        If mintSearchUpperLimit > 1 Then
            btnIDNext.Enabled = True
        End If

        txtSearchEmployeeID.Text = ""

    End Sub

    Private Sub btnIDNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIDNext.Click


        'This Routine will run the Next Buttons
        mintCounter = mintCounter + 1
        cboTransactionID.SelectedIndex = mintSelectedIndex(mintCounter)
        btnIDBack.Enabled = True


        If mintCounter = mintSearchUpperLimit Then
            btnIDNext.Enabled = False

        End If


        mstrToolID = txtHistoryToolID.Text
        mintEmployeeID = CInt(txtHistoryEmployeeID.Text)
        mintWarehouseID = CInt(txtHistoryWareHouseEmployeeID.Text)

        FindEmployeeID(mintEmployeeID)
        FindWarehouseEmployeeID(mintWarehouseID)
        FindToolID(mstrToolID)



    End Sub

    Private Sub btnIDBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIDBack.Click

        'This Routine will run the Next Buttons
        mintCounter = mintCounter - 1
        cboTransactionID.SelectedIndex = mintSelectedIndex(mintCounter)



        If mintCounter < mintSearchUpperLimit Then
            btnIDNext.Enabled = True

        End If
        If mintCounter = 0 Then
            btnIDBack.Enabled = False
        End If


        mstrToolID = txtHistoryToolID.Text
        mintEmployeeID = CInt(txtHistoryEmployeeID.Text)
        mintWarehouseID = CInt(txtHistoryWareHouseEmployeeID.Text)

        FindEmployeeID(mintEmployeeID)
        FindWarehouseEmployeeID(mintWarehouseID)
        FindToolID(mstrToolID)

    End Sub

    Private Sub btnSearchByEmployeeName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchByEmployeeName.Click

        'This will search for the Employee by name

        Dim strFirstNameEntered As String
        Dim strLastNameEntered As String
        Dim strFirstNameFromTable As String
        Dim strLastNameFromTable As String
        Dim blnFatalErrors As Boolean
        Dim strErrorMessage As String
        Dim intEmployeeIDFromSearch As Integer
        Dim intCounter As Integer
        Dim intEmployeeIDUpperLevel As Integer
        Dim blnEmployeeFound As Boolean

        'Setting Data Validation Variables
        blnFatalErrors = False
        strErrorMessage = ""
        blnEmployeeFound = False



        If txtSearchLastName.Text = "" Then
            blnFatalErrors = True
            strErrorMessage = strErrorMessage + "The Last Name For Searching was not entered" + vbNewLine
        End If
        If txtSearchFirstName.Text = "" Then
            blnFatalErrors = True
            strErrorMessage = strErrorMessage + "The First Name for Searching was not Entered" + vbNewLine
        End If

        If blnFatalErrors = True Then
            MessageBox.Show(strErrorMessage, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        strFirstNameEntered = txtSearchFirstName.Text
        strLastNameEntered = txtSearchLastName.Text

        intEmployeeIDUpperLevel = cboEmployeeID.Items.Count - 1

        For intCounter = 0 To intEmployeeIDUpperLevel

            cboEmployeeID.SelectedIndex = intCounter
            strLastNameFromTable = txtLastName.Text
            strFirstNameFromTable = txtFirstName.Text

            If strLastNameEntered = strLastNameFromTable Then
                If strFirstNameEntered = strFirstNameFromTable Then

                    intEmployeeIDFromSearch = CInt(cboEmployeeID.Text)
                    blnEmployeeFound = True

                End If
            End If

        Next

        If blnEmployeeFound = False Then
            MessageBox.Show("The Employee Name Entered does not Exist", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        txtSearchEmployeeID.Text = CStr(intEmployeeIDFromSearch)
        btnSearchByEmployeeID.PerformClick()
        txtSearchEmployeeID.Text = ""
        txtSearchFirstName.Text = ""
        txtSearchLastName.Text = ""

    End Sub

    Private Sub btnResetNavagation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetNavagation.Click

        'This sub-routine resets the navagation

        btnIDBack.Enabled = False
        btnIDNext.Enabled = False

        cboTransactionID.SelectedIndex = 0

        mstrToolID = txtHistoryToolID.Text
        mintEmployeeID = CInt(txtHistoryEmployeeID.Text)
        mintWarehouseID = CInt(txtHistoryWareHouseEmployeeID.Text)

        FindEmployeeID(mintEmployeeID)
        FindWarehouseEmployeeID(mintWarehouseID)
        FindToolID(mstrToolID)


        If mintUpperLimit > 1 Then
            btnHistoryNext.Enabled = True
        End If


    End Sub

    Private Sub txtToolIDForSearching_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtToolIDForSearching.KeyDown

        'This is run if the Enter Key is pressed
        If e.KeyCode = Keys.Enter Then
            btnFindTool.PerformClick()
        End If

    End Sub

    Private Sub txtSearchEmployeeID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearchEmployeeID.KeyDown

        'This is run if the Enter Key is pressed
        If e.KeyCode = Keys.Enter Then
            btnSearchByEmployeeID.PerformClick()
        End If

    End Sub

    Private Sub ClearDataBindings()

        'Resetting Employee bindings
        cboEmployeeID.DataBindings.Clear()
        txtFirstName.DataBindings.Clear()
        txtLastName.DataBindings.Clear()
        txtPhoneNumber.DataBindings.Clear()

        'Reseting Warehouse Employee Bindings
        cboWareHouseEmployeeID.DataBindings.Clear()
        txtWarehouseFirstName.DataBindings.Clear()
        txtWarehouselastName.DataBindings.Clear()
        txtWarehousePhoneNumber.DataBindings.Clear()

        'Resetting tool bindings
        cboToolID.DataBindings.Clear()
        txtToolEmployeeID.DataBindings.Clear()
        txtToolDate.DataBindings.Clear()
        txtToolPartNumber.DataBindings.Clear()
        txtToolType.DataBindings.Clear()
        txtToolDescription.DataBindings.Clear()
        txtToolValue.DataBindings.Clear()
        txtToolAvailable.DataBindings.Clear()
        txtToolActive.DataBindings.Clear()
        txtToolNotes.DataBindings.Clear()

        'Clearing History
        cboTransactionID.DataBindings.Clear()
        txtHistoryToolID.DataBindings.Clear()
        txtHistoryEmployeeID.DataBindings.Clear()
        txtHistoryWareHouseEmployeeID.DataBindings.Clear()
        txtHistoryDate.DataBindings.Clear()
        txtHistoryAvailable.DataBindings.Clear()
        txtHistoryNotes.DataBindings.Clear()
        

    End Sub

    Private Sub txtSearchFirstName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearchFirstName.KeyDown

        If e.KeyCode = Keys.Enter Then
            btnSearchByEmployeeName.PerformClick()
        End If

    End Sub

    Private Sub txtSearchLastName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearchLastName.KeyDown

        If e.KeyCode = Keys.Enter Then
            txtSearchFirstName.Focus()
        End If

    End Sub
End Class