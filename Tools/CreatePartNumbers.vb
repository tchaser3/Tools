'Title:         Create Part Numbers
'Date:          3/31/14
'Author:        Terry Holmes

'Description:   This form is used to create Part Numbers

Option Strict On

Public Class CreatePartNumbers

    'Setting Modular Variables
    Private ThePartNumberDataSet As PartNumberDataSet
    Private ThePartNumberDataTier As PartDataTier
    Private WithEvents ThePartNumberBindingSource As BindingSource

    Private addingBoolean As Boolean = False
    Private editingBoolean As Boolean = False
    Private previousSelectedIndex As Integer
    Dim mintNumuberOfRecords As Integer

    Dim TheInputDataValidation As New InputDataValidation
    Dim TheKeywordSearch As New KeyWordSearchClass

    Dim LogDateTime As Date = DateAndTime.Now
    Dim strLogDateTime As String

    'Setting Global Variables
    Dim mintSelectedIndex() As Integer
    Dim mintCounter As Integer
    Dim mintUpperLimit As Integer

    Dim mblnEditingRecord As Boolean

    'Variable for Radio Buttons
    Dim mbolAll As Boolean = False
    Dim mbolCoax As Boolean = False
    Dim mbolFiber As Boolean = False
    Friend mbolPartNumberExists As Boolean = False
    Friend mstrPartNumberForValidation As String
    Dim mstrDescriptionForValidation As String
    Dim mintKeyWordLengthForSearch As Integer

    Dim blnSetInputMast As Boolean = True

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        'Closes the Program
        LastTransaction.Show()
        CloseTheProgram.ShowDialog()

    End Sub

    Private Sub btnAdministrativeMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdministrativeMenu.Click

        'Loading up last transaction
        LastTransaction.Show()

        'clearing the bindings
        ClearDataBinding()

        If btnAdministrativeMenu.Text = "Inventory Menu" Then

            'Shows the Inventory menu
            InventoryMenu.Show()
            Me.Close()
        Else
            'Opens the Administrative Menu
            AdministrativeMenu.Show()
            Me.Close()

        End If

    End Sub

    Private Sub btnMainMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMainMenu.Click

        'This will open the main menu
        LastTransaction.Show()
        ClearDataBinding()
        MainMenu.Show()
        Me.Close()

    End Sub
    Private Sub setComboBoxBinding()

        'Sets the Combobox Binding
        With Me.cboPartID
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
        txtPartNumber.ReadOnly = valueBoolean
        txtDescription.ReadOnly = valueBoolean
        txtTimeWarnerPart.ReadOnly = valueBoolean
        txtPrice.ReadOnly = valueBoolean

    End Sub
    Private Sub setButtonsForEdit()

        'Sets the buttons up for editing and saving a record
        btnAdd.Text = "Save"
        btnEdit.Enabled = False
        btnMainMenu.Enabled = False

    End Sub
    Private Sub ResetButtonAfterEditing()

        'Setting the buttons up for adding records
        btnAdd.Text = "Add"
        btnEdit.Enabled = True
        btnMainMenu.Enabled = True

    End Sub
    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click

        'Getting the form ready to edit a record
        mblnEditingRecord = True
        mstrPartNumberForValidation = txtPartNumber.Text
        mstrDescriptionForValidation = txtDescription.Text
        setControlsReadOnly(False)
        blnSetInputMast = False
        setButtonsForEdit()
        previousSelectedIndex = cboPartID.SelectedIndex
        setComboBoxBinding()

    End Sub

    Private Sub CreatePartNumbers_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'This routine runs when the form is loaded

        'Local Variables
        Dim strDecimalValue As String
        Dim intCounter As Integer

        'This Try Catch will catch any exceptions that are through during the routine
        Try

            'This will bind the controls to the data source
            ThePartNumberDataTier = New PartDataTier
            ThePartNumberDataSet = ThePartNumberDataTier.GetPartNumberInformation
            ThePartNumberBindingSource = New BindingSource

            'Setting up the binding for the Combobox
            With ThePartNumberBindingSource
                .DataSource = ThePartNumberDataSet
                .DataMember = "partnumbers"
                .MoveFirst()
                .MoveLast()
            End With

            'Setting up the Table Relationships and binding for the table.
            With cboPartID
                .DataSource = ThePartNumberBindingSource
                .DisplayMember = "PartID"
                .DataBindings.Add("text", ThePartNumberBindingSource, "PartID", False, DataSourceUpdateMode.Never)
            End With

            'Setting up the data bindings for the textboxes
            txtPartNumber.DataBindings.Add("text", ThePartNumberBindingSource, "PartNumber")
            txtDescription.DataBindings.Add("text", ThePartNumberBindingSource, "Description")
            txtTimeWarnerPart.DataBindings.Add("text", ThePartNumberBindingSource, "TimeWarnerPart")
            txtPrice.DataBindings.Add("text", ThePartNumberBindingSource, "Price")
            txtActive.DataBindings.Add("text", ThePartNumberBindingSource, "Active")

            setControlsReadOnly(True)

            cboPartID.SelectedIndex = 0
            strDecimalValue = txtPrice.Text
            txtPrice.Text = FormatNumber(strDecimalValue, 2)

            'Setting up for navigation
            mintUpperLimit = cboPartID.Items.Count - 1
            ReDim mintSelectedIndex(mintUpperLimit)
            mintCounter = 0
            For intCounter = 0 To mintUpperLimit
                mintSelectedIndex(intCounter) = intCounter
            Next
            If mintUpperLimit > 0 Then
                btnNavigationNext.Enabled = True
            End If

            If Logon.mstrSourceMenu = "Inventory Menu" Then
                btnAdd.Visible = False
                btnEdit.Visible = False
                lblTitleLabel.Text = "Part Number Search"
                btnAdministrativeMenu.Text = "Inventory Menu"
            End If

            txtPartID.Text = cboPartID.Text
            Logon.mstrLastTransactionSummary = "LOADED CREATE PART FORM"

        Catch ex As Exception
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        'Setting local variables
        Dim blnFatalError As Boolean
        Dim intNumberOfRecords As Integer
        Dim strHomeOffice As String
        Dim strValueForValidation As String
        Dim strPartNumberEntered As String
        Dim strDescriptionEntered As String
        Dim strErrorMessage As String


        'Setting up if statements
        If btnAdd.Text = "Add" Then  'This routine will run if the user is adding a trailer

            cboPartID.Visible = True
            txtPartID.Visible = False

            mblnEditingRecord = False
            blnSetInputMast = False

            'Placing the Binding Source to Add a record
            With ThePartNumberBindingSource
                .EndEdit()
                .AddNew()
            End With

            'Calling routines and setting the values
            addingBoolean = True
            setComboBoxBinding()
            cboPartID.Visible = True
            cboPartID.Focus()
            setControlsReadOnly(False)
            setButtonsForEdit()
            If cboPartID.SelectedIndex <> -1 Then
                previousSelectedIndex = cboPartID.Items.Count - 1
            Else
                previousSelectedIndex = 0
            End If

            'Setting up fields with auto-data to avoid having the user do it.
            mintNumuberOfRecords = cboPartID.Items.Count
            intNumberOfRecords = mintNumuberOfRecords + 1000
            Logon.mintPartID = intNumberOfRecords
            txtActive.Text = "YES"

            'Calling the Part Number ID From
            PartNumbersID.Show()

            strHomeOffice = CStr(Logon.mstrHomeOffice)
            cboPartID.Text = CStr(Logon.mintPartID)
            strLogDateTime = CStr(LogDateTime)

        Else

            If mblnEditingRecord = True Then
                If txtPartNumber.Text = " " Then
                    strDescriptionEntered = txtDescription.Text
                    If strDescriptionEntered <> mstrDescriptionForValidation Then
                        MessageBox.Show("You Have Edited the Description, A Part Number Is Now Required", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        mblnEditingRecord = False
                    End If
                End If
            End If

            'Beginning Data Validation
            strValueForValidation = txtDescription.Text
            strErrorMessage = "The Description Was Not Entered"
            blnFatalError = TheInputDataValidation.VerifyTextData(strValueForValidation)
            If blnFatalError = False Then
                If mblnEditingRecord = False Then
                    strValueForValidation = txtPartNumber.Text
                    strErrorMessage = "The Part Number Was Not Entered"
                    blnFatalError = TheInputDataValidation.VerifyTextData(strValueForValidation)
                End If
                If blnFatalError = False Then
                    strValueForValidation = txtTimeWarnerPart.Text
                    strErrorMessage = "The Time Warner Part Information Was Not Entered"
                    blnFatalError = TheInputDataValidation.VerifyYesNoData(strValueForValidation)
                End If
            End If

            'Error if Data Validation Fails
            If blnFatalError = True Then
                MessageBox.Show(strErrorMessage, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            'Checking to see if the part number has been changed
            If mblnEditingRecord = True Then
                strPartNumberEntered = txtPartNumber.Text
                strDescriptionEntered = txtDescription.Text
                If strPartNumberEntered <> mstrPartNumberForValidation Then
                    mblnEditingRecord = False
                End If
            End If

            'Checking to see if part number exists
            If mblnEditingRecord = False Then
                mstrPartNumberForValidation = txtPartNumber.Text
                CheckPartNumber.Show()
                If mbolPartNumberExists = True Then
                    MessageBox.Show("Part Number Already Exists", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            End If

            Logon.mstrLastTransactionSummary = txtPartNumber.Text + " " + txtDescription.Text + " Created"

            blnSetInputMast = True
            SetInputMask()
            cboPartID.Visible = False
            txtPartID.Visible = True
            'Updating Database
            Try
                ThePartNumberBindingSource.EndEdit()
                ThePartNumberDataTier.UpdatePartNumberDB(ThePartNumberDataSet)
                addingBoolean = False
                editingBoolean = False
                setControlsReadOnly(True)
                ResetButtonAfterEditing()
                setComboBoxBinding()
                cboPartID.SelectedIndex = previousSelectedIndex
                cboPartID.Visible = False

            Catch ex As Exception
                MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            txtPartID.Text = cboPartID.Text

            End If

    End Sub

    Private Sub btnSearchForPartNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchForPartNumber.Click

        'This is used to find a selected Part Number
        Dim intNumberOfRecords As Integer
        Dim strValueForValidation As String
        Dim blnFatalError As Boolean
        Dim blnPartNumberNotFound As Boolean = True
        Dim strPartNumberForSearch As String
        Dim strPartNumberFromTable As String = ""
        Dim intPartIDCounter As Integer
        Dim intPartNumberCounter As Integer
        Dim intCharacterCounter As Integer
        Dim intKeyWordCounter As Integer
        Dim intKeyWordLengthForSearch As Integer
        Dim intKeyWordLengthFromTable As Integer
        Dim charPartNumberArray() As Char
        Dim intCounter As Integer

        'Setting up navagation buttons
        btnNavigationBack.Enabled = False
        btnNavigationNext.Enabled = False

        'Checking data input and validating input
        strValueForValidation = txtPartNumberSeach.Text
        blnFatalError = TheInputDataValidation.VerifyTextData(strValueForValidation)

        If blnFatalError = True Then
            MessageBox.Show("The Part Number Was Not Entered", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        'Searching for Part Number
        intNumberOfRecords = cboPartID.Items.Count - 1
        mintUpperLimit = 0
        mintCounter = 0
        strPartNumberForSearch = strValueForValidation
        intKeyWordLengthForSearch = txtPartNumberSeach.TextLength - 1
        intCounter = 0

        'First Loop to increment the Counter
        For intPartIDCounter = 0 To intNumberOfRecords

            'Setting Up Control Variables
            cboPartID.SelectedIndex = intPartIDCounter
            intKeyWordLengthFromTable = txtPartNumber.TextLength - 1
            charPartNumberArray = txtPartNumber.Text.ToCharArray
            intCharacterCounter = intKeyWordLengthForSearch

            If intKeyWordLengthForSearch <= intKeyWordLengthFromTable Then

                'Setting the second counter
                For intPartNumberCounter = 0 To intKeyWordLengthFromTable

                    'Setting third counter
                    For intKeyWordCounter = intPartNumberCounter To intCharacterCounter

                        'setting the character array
                        strPartNumberFromTable = strPartNumberFromTable + charPartNumberArray(intKeyWordCounter)

                    Next

                    'incrementing the characters within the array
                    If intCharacterCounter < intKeyWordLengthFromTable Then
                        intCharacterCounter += 1
                    End If

                    'doing string comparison
                    If strPartNumberForSearch = strPartNumberFromTable Then
                        mintSelectedIndex(mintCounter) = intPartIDCounter
                        mintCounter += 1
                        blnPartNumberNotFound = False
                    End If

                    'clearing the variable
                    strPartNumberFromTable = ""

                Next

                'Resetting the character count
                intCharacterCounter = intKeyWordLengthForSearch

            End If
        Next

        'Setting up message for user
        If blnPartNumberNotFound = True Then
            MessageBox.Show("Part Number Entered Not Found", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtPartNumberSeach.Text = ""
            Exit Sub
        End If

        'Setting up the controls
        mintUpperLimit = mintCounter - 1
        mintCounter = 0
        cboPartID.SelectedIndex = mintSelectedIndex(0)
        txtPartID.Text = cboPartID.Text

        If mintUpperLimit > 0 Then
            btnNavigationNext.Enabled = True
        End If

        'Clearing input text box
        txtPartNumberSeach.Text = ""

    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'This is used to reset to the initial condition
        cboPartID.Visible = True
        cboPartID.SelectedIndex = 0
        txtPartNumberSeach.Text = ""

    End Sub

    Private Sub ClearDataBinding()

        txtDescription.DataBindings.Clear()
        txtPartNumber.DataBindings.Clear()
        txtPartNumberSeach.DataBindings.Clear()
        txtTimeWarnerPart.DataBindings.Clear()
        cboPartID.DataBindings.Clear()

    End Sub
    Private Sub btnNavigationNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNavigationNext.Click

        'This will increment the Counter
        mintCounter = mintCounter + 1
        cboPartID.SelectedIndex = mintSelectedIndex(mintCounter)
        txtPartID.Text = cboPartID.Text

        'Setting Control
        btnNavigationBack.Enabled = True

        If mintCounter = mintUpperLimit Then
            btnNavigationNext.Enabled = False
        End If

    End Sub

    Private Sub btnNavigationBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNavigationBack.Click

        'This will decrement the Counter
        mintCounter = mintCounter - 1
        cboPartID.SelectedIndex = mintSelectedIndex(mintCounter)
        txtPartID.Text = cboPartID.Text

        'Setting Control
        btnNavigationNext.Enabled = True

        If mintCounter = 0 Then
            btnNavigationBack.Enabled = False
        End If


    End Sub

    Private Sub txtPrice_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPrice.TextChanged

        SetInputMask()

    End Sub
    Private Sub SetInputMask()

        Dim strDecimalValue As String

        If blnSetInputMast = True Then
            strDecimalValue = txtPrice.Text
            txtPrice.Text = FormatNumber(strDecimalValue, 2)
        End If

    End Sub

    Private Sub btnKeyWordSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKeyWordSearch.Click

        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim blnFatalError As Boolean = False
        Dim strKeywordForSearch As String
        Dim strPartDescriptionFromTable As String
        Dim blnItemNotFound As Boolean
        Dim blnItemFound As Boolean = False

        'Setting up the navigation buttons
        btnNavigationBack.Enabled = False
        btnNavigationNext.Enabled = False

        'Performing Data Validation
        strKeywordForSearch = txtKeyWordEntered.Text
        blnFatalError = TheInputDataValidation.VerifyTextData(strKeywordForSearch)

        'Output to user if validation fails
        If blnFatalError = True Then
            MessageBox.Show("The Key Word Was Not Entered", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        'Setting up for loop
        intNumberOfRecords = cboPartID.Items.Count - 1
        mintCounter = 0

        'Redimensioning the array
        ReDim mintSelectedIndex(intNumberOfRecords)
        ClearArray()

        'Performing Loop
        For intCounter = 0 To intNumberOfRecords

            'Setting up the boolean modifier
            blnItemNotFound = False

            'incrementing the combo box
            cboPartID.SelectedIndex = intCounter

            'Getting the part description
            strPartDescriptionFromTable = txtDescription.Text

            'Calling the keyword class
            blnItemNotFound = TheKeywordSearch.FindKeyWord(strKeywordForSearch, strPartDescriptionFromTable)

            'If statement to see if word was found
            If blnItemNotFound = False Then

                'Setting variables
                mintSelectedIndex(mintCounter) = intCounter
                mintCounter += 1
                blnItemFound = True

            End If

        Next

        If blnItemFound = False Then
            txtKeyWordEntered.Text = ""
            MessageBox.Show("No Parts Were Found", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        'setting up the navigation buttons
        mintUpperLimit = mintCounter - 1
        mintCounter = 0
        cboPartID.SelectedIndex = mintSelectedIndex(0)

        If mintUpperLimit > 0 Then
            btnNavigationNext.Enabled = True
        End If
        
    End Sub
    Private Sub ClearArray()

        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer

        intNumberOfRecords = cboPartID.Items.Count - 1

        For intCounter = 0 To intNumberOfRecords

            mintSelectedIndex(intCounter) = -1

        Next

    End Sub

    Private Sub txtKeyWordEntered_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtKeyWordEntered.KeyDown

        If e.KeyCode = Keys.Enter Then
            btnKeyWordSearch.PerformClick()
        End If

    End Sub
End Class