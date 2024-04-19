'Title:         Create A Tool
'Date:          3/31/13
'Author:        Terry Holmes

'Update:        8-20-15 - Corrected the Tool Type button, added structure

Option Strict On

Public Class CreateTools

    'Setting Modular Variable
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

    'Setting Global Variable
    Friend mintCreatedToolID As Integer
    Dim mintSelectedIndex(50) As Integer
    Dim mintUpperLimit As Integer
    Dim mintSelectedIndexCounter As Integer = 0

    Dim TheInputDataValidate As New InputDataValidation

    Dim mintToolTypeSelectedIndex(10000) As Integer
    Dim mintToolTypeUpperLimit As Integer
    Dim mintToolTypeCounter As Integer

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click

        'Closes the Program
        CloseTheProgram.ShowDialog()

    End Sub

    Private Sub btnAdministrativeMenu_Click(sender As System.Object, e As System.EventArgs) Handles btnAdministrativeMenu.Click

        'Opens up the Administrative Menu
        LastTransaction.Show()
        AdministrativeMenu.Show()
        Me.Close()

    End Sub

    Private Sub btnMainMenu_Click(sender As System.Object, e As System.EventArgs) Handles btnMainMenu.Click

        'Opens the Main Menu
        LastTransaction.Show()
        MainMenu.Show()
        Me.Close()

    End Sub
    Private Sub setComboBoxBinding()

        'This sub-routine sets and changes the combo box binding 
        With Me.cboTransactionID
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

        'Sets controls for editing
        btnAdd.Text = "Save"
        btnEdit.Enabled = False
        btnMainMenu.Enabled = False

    End Sub
    Private Sub ResetButtonAfterEditing()

        'Sets the controls for adding a record
        btnAdd.Text = "Add"
        btnEdit.Enabled = True
        btnMainMenu.Enabled = True

    End Sub
    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click

        'This sub-routine runs when the edit button is pressed
        setControlsReadOnly(False)
        setButtonsForEdit()
        previousSelectedIndex = cboTransactionID.SelectedIndex
        setComboBoxBinding()
        txtEmployeeID.ReadOnly = True

    End Sub

    Private Sub CreateTools_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'This sub-routine runs when the form is loaded
        Try
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
            With cboTransactionID
                .DataSource = TheToolsBindingSource
                .DisplayMember = "ToolKey"
                .DataBindings.Add("text", TheToolsBindingSource, "ToolKey", False, DataSourceUpdateMode.Never)
            End With

            'Setting the binding for all other textbox controls
            txtToolID.DataBindings.Add("text", TheToolsBindingSource, "ToolID")
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

        Catch ex As Exception
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        'This will add or save a record to the data set

        'Setting local variables
        Dim blnFatalError As Boolean
        Dim strHomeOffice As String
        Dim strValueForValidation As String
        Dim strErrorMessage As String = ""
        Dim blnThereIsAProblem As Boolean = False

        'Setting up if statements
        If btnAdd.Text = "Add" Then  'This routine will run if the user is adding a vehicle

            'Changing the binding sourse
            With TheToolsBindingSource
                .EndEdit()
                .AddNew()
            End With

            'Calls and setting values to sub-routines
            addingBoolean = True
            setComboBoxBinding()

            'Setting the combo box focus
            cboTransactionID.Focus()

            'Setting the values and calls for more sub-routines
            setControlsReadOnly(False)
            setButtonsForEdit()

            If cboTransactionID.SelectedIndex <> -1 Then
                previousSelectedIndex = cboTransactionID.Items.Count - 1
            Else
                previousSelectedIndex = 0
            End If

            'Setting up fields with auto-data to avoid having the user do it.

            CreateToolID.Show()

            mintCreatedToolID = CInt(Logon.mintCreatedToolID)

            strHomeOffice = Logon.mstrHomeOffice

            txtEmployeeID.Text = CStr(Logon.mintWarehouseID)

            cboTransactionID.Text = CStr(mintCreatedToolID)
            txtActive.Text = "YES"
            txtAvailable.Text = "YES"
            strLogDateTime = CStr(LogDateTime)
            txtDate.Text = strLogDateTime
            txtValue.Text = "0.00"
            txtEmployeeID.ReadOnly = True

            'Adding a record to the table
        Else

            'Clearing variables for data validation
            blnFatalError = False

            'Beginning Data Validation
            strValueForValidation = txtEmployeeID.Text
            blnFatalError = TheInputDataValidate.VerifyIntegerData(strValueForValidation)
            If blnFatalError = True Then
                blnThereIsAProblem = True
                strErrorMessage = strErrorMessage + "Employee ID Is Not An Integer" + vbNewLine
            End If

            strValueForValidation = txtDate.Text
            blnFatalError = TheInputDataValidate.VerifyStartingEndingDatesAsDates(strValueForValidation)
            If blnFatalError = True Then
                blnThereIsAProblem = True
                strErrorMessage = strErrorMessage + "The Date Is Not The Correct Format" + vbNewLine
            End If

            strValueForValidation = txtPartNumber.Text
            blnFatalError = TheInputDataValidate.VerifyTextData(strValueForValidation)
            If blnFatalError = True Then
                blnThereIsAProblem = True
                strErrorMessage = strErrorMessage + "The Part Number was not Entered" + vbNewLine
            End If

            strValueForValidation = txtType.Text
            blnFatalError = TheInputDataValidate.VerifyTextData(strValueForValidation)
            If blnFatalError = True Then
                blnThereIsAProblem = True
                strErrorMessage = strErrorMessage + "The Type Was not Entered" + vbNewLine
            End If

            strValueForValidation = txtValue.Text
            blnFatalError = TheInputDataValidate.VerifyMoney(strValueForValidation)
            If blnFatalError = True Then
                blnThereIsAProblem = True
                strErrorMessage = strErrorMessage + "The Value Entered is not the Correct Format" + vbNewLine
            End If

            strValueForValidation = txtDescription.Text
            blnFatalError = TheInputDataValidate.VerifyTextData(strValueForValidation)
            If blnFatalError = True Then
                blnThereIsAProblem = True
                strErrorMessage = strErrorMessage + "The Description was not Entered" + vbNewLine
            End If

            strValueForValidation = txtAvailable.Text
            blnFatalError = TheInputDataValidate.VerifyYesNoData(strValueForValidation)
            If blnFatalError = True Then
                blnThereIsAProblem = True
                strErrorMessage = strErrorMessage + "Available is to be Either Yes or No" + vbNewLine
            End If

            strValueForValidation = txtActive.Text
            blnFatalError = TheInputDataValidate.VerifyYesNoData(strValueForValidation)
            If blnFatalError = True Then
                blnThereIsAProblem = True
                strErrorMessage = strErrorMessage + "Active is to be Either Yes or No" + vbNewLine
            End If

            strValueForValidation = txtToolID.Text
            blnFatalError = TheInputDataValidate.VerifyTextData(strValueForValidation)
            If blnFatalError = True Then
                blnThereIsAProblem = True
                strErrorMessage = strErrorMessage + "The Tool ID was not Entered" + vbNewLine
            End If

            'Checking if there were any data validation errors and either continuing the sub-routine or ending it.
            If blnThereIsAProblem = True Then
                MessageBox.Show(strErrorMessage, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            strValueForValidation = txtType.Text
            Logon.mstrToolCategory = strValueForValidation
            ToolCategoryCheck.Show()
            blnFatalError = Logon.mblnToolCategoryExists
            Logon.mstrLastTransactionSummary = "CREATED TOOL ID " + txtToolID.Text
            LastTransaction.Show()

            If blnFatalError = True Then
                MessageBox.Show("Tool Type Does Not Exist", "Please Add Through Correct Form", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            'Updating Database
            Try
                TheToolsBindingSource.EndEdit()
                TheToolsDataTier.UpdateToolDB(TheToolsDataSet)
                addingBoolean = False
                editingBoolean = False
                setControlsReadOnly(True)
                ResetButtonAfterEditing()
                setComboBoxBinding()
                cboTransactionID.SelectedIndex = previousSelectedIndex

            Catch ex As Exception
                MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If
    End Sub

    Private Sub btnSearchForNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchForNumber.Click

        'This sub routine will search for a specific BJC Number
        Dim blnFatalError As Boolean
        Dim strValueForValidation As String
        Dim blnToolIDNotFound As Boolean = True
        Dim intNumberOfRecords As Integer
        Dim strToolIDFromTable As String
        Dim strToolIDForSearch As String

        btnBack.Enabled = False
        btnNext.Enabled = False

        strValueForValidation = txtToolIDForSearching.Text

        blnFatalError = TheInputDataValidation.VerifyTextData(strValueForValidation)

        If blnFatalError = True Then
            MessageBox.Show("The Tool ID Was Not Entered", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        strToolIDForSearch = strValueForValidation
        intNumberOfRecords = cboTransactionID.Items.Count - 1

        For intCounter = 0 To intNumberOfRecords
            cboTransactionID.SelectedIndex = intCounter
            strToolIDFromTable = txtToolID.Text
            If strToolIDFromTable = strToolIDForSearch Then

                mintSelectedIndex(mintSelectedIndexCounter) = intCounter
                mintSelectedIndexCounter = mintSelectedIndexCounter + 1
                blnToolIDNotFound = False

            End If
        Next

        If blnToolIDNotFound = True Then

            MessageBox.Show("The Tool ID entered was not found", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtToolIDForSearching.Text = ""
            Exit Sub

        End If

        mintUpperLimit = mintSelectedIndexCounter - 1
        mintSelectedIndexCounter = 0
        cboTransactionID.SelectedIndex = mintSelectedIndex(mintSelectedIndexCounter)

        If mintUpperLimit > 0 Then

            btnNext.Enabled = True

        End If

        txtToolIDForSearching.Text = ""

    End Sub
    Private Sub txtBJCNumberForSearching_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtToolIDForSearching.KeyDown

        If e.KeyCode = Keys.Enter Then

            btnSearchForNumber.PerformClick()

        End If

    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click

        mintSelectedIndexCounter = mintSelectedIndexCounter + 1

        cboTransactionID.SelectedIndex = mintSelectedIndex(mintSelectedIndexCounter)

        btnBack.Enabled = True

        If mintSelectedIndexCounter = mintUpperLimit Then
            btnNext.Enabled = False
        End If

    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click

        mintSelectedIndexCounter = mintSelectedIndexCounter - 1

        cboTransactionID.SelectedIndex = mintSelectedIndex(mintSelectedIndexCounter)

        btnNext.Enabled = True

        If mintSelectedIndexCounter = 0 Then
            btnBack.Enabled = False
        End If

    End Sub

    Private Sub btnSeachByToolType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSeachByToolType.Click

        Dim blnFatalError As Boolean
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim strValueForValidation As String
        Dim strToolTypeForSearching As String
        Dim strTooltypeFromTable As String
        Dim blnToolTypeFound As Boolean = False

        'Setting Button initial condition
        btnToolTypeNext.Enabled = False
        btnToolTypeBack.Enabled = False

        'Performing Data Validation
        strValueForValidation = txtToolTypeForSearching.Text
        Logon.mstrToolCategory = strValueForValidation
        ToolCategoryCheck.Show()
        blnFatalError = Logon.mblnToolCategoryExists

        If blnFatalError = True Then
            MessageBox.Show("The Tool Category Entered Does Not Exist", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtToolTypeForSearching.Text = ""
            Exit Sub
        End If

        'Beginning Search Criteria
        strToolTypeForSearching = strValueForValidation
        intNumberOfRecords = cboTransactionID.Items.Count - 1
        mintToolTypeCounter = 0
        mintToolTypeUpperLimit = 0

        'Peforming For Loop
        For intCounter = 0 To intNumberOfRecords

            cboTransactionID.SelectedIndex = intCounter
            strTooltypeFromTable = txtType.Text

            If strToolTypeForSearching = strTooltypeFromTable Then

                mintToolTypeSelectedIndex(mintToolTypeCounter) = intCounter
                mintToolTypeCounter = mintToolTypeCounter + 1
                blnToolTypeFound = True

            End If
        Next

        'Doing quick check to see if any tools were found
        If blnToolTypeFound = False Then

            MessageBox.Show("No Tools Found", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtToolTypeForSearching.Text = ""
            Exit Sub

        End If

        'Enabling Tool Type Next Button
        If mintToolTypeCounter > 1 Then
            btnToolTypeNext.Enabled = True
        End If

        'Setting up Global Array
        cboTransactionID.SelectedIndex = mintToolTypeSelectedIndex(0)
        mintToolTypeUpperLimit = mintToolTypeCounter - 1
        mintToolTypeCounter = 0

    End Sub

    Private Sub btnToolTypeNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToolTypeNext.Click

        'This routine will move the next button
        mintToolTypeCounter = mintToolTypeCounter + 1
        cboTransactionID.SelectedIndex = mintToolTypeSelectedIndex(mintToolTypeCounter)

        'Enabling the Back Button
        btnToolTypeBack.Enabled = True

        If mintToolTypeCounter = mintToolTypeUpperLimit Then
            btnToolTypeNext.Enabled = False
        End If

    End Sub

    Private Sub btnToolTypeBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToolTypeBack.Click

        'This routine will move the back button
        mintToolTypeCounter = mintToolTypeCounter - 1
        cboTransactionID.SelectedIndex = mintToolTypeSelectedIndex(mintToolTypeCounter)

        'Enabling the Back Button
        btnToolTypeNext.Enabled = True

        If mintToolTypeCounter = 0 Then
            btnToolTypeBack.Enabled = False
        End If

    End Sub

    Private Sub btnToolAssetReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToolAssetReport.Click

        'This will load the tool asset report form
        LastTransaction.Show()
        ToolAssetReport.Show()
        Me.Close()

    End Sub
End Class