'Title:         Add/Edit Internal Projects
'Date:          12/30/13
'Author:        Terry Holmes

'Description:   This form is Project Data Entry Form

'Update:        Several changes have been made this form, adding grid for searches, removing several controls
'               Adding a structure for the search results and all current projects with the form.
'               The information entered is searched in several locations at once

Option Strict On

Public Class InternalProjects

    'Setting Modular Variables

    Private TheInternalProjectsDataSet As InternalProjectsDataSet
    Private TheInternalProjectsDataTier As InternalProjectsDataTier
    Private WithEvents TheInternalProjectsBindingSource As BindingSource

    Dim TheInputDataValidation As New InputDataValidation
    Dim TheKeyWordDataSearch As New KeyWordSearchClass

    Private addingBoolean As Boolean = False
    Private editingBoolean As Boolean = False
    Private previousSelectedIndex As Integer
    Dim mintNumuberOfRecords As Integer

    Dim LogDateTime As Date = DateAndTime.Now
    Dim strLogDateTime As String

    'setting up project structure
    Structure Projects
        Dim mintSelectedIndex As Integer
        Dim mintInternalProjectID As Integer
        Dim mstrProjectName As String
        Dim mstrTWCProjectID As String
        Dim mstrTWCCoordinator As String
        Dim mstrSupplyingWarehouse As String
        Dim mstrMSRNumber As String
    End Structure

    Dim structProjects() As Projects
    Dim mintProjectCounter As Integer
    Dim mintProjectUpperLimit As Integer

    Dim mintSelectedIndex() As Integer
    Dim mintSelectedCounter As Integer
    Dim mintSelectedUpperLimit As Integer

    Private Sub btnAdministrativeMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdministrativeMenu.Click

        'This Button will call the Administrative Menu
        AdministrativeMenu.Show()
        Me.Close()

    End Sub
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        'Closes the Program
        CloseTheProgram.ShowDialog()

    End Sub

    Private Sub btnMainMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMainMenu.Click

        'Calls the Main Menu
        MainMenu.Show()
        Me.Close()

    End Sub

    Private Sub setComboBoxBinding()

        'Sets the Combobox Bindings
        With Me.cboInternalProjectID
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
        txtAddress.ReadOnly = valueBoolean
        txtCity.ReadOnly = valueBoolean
        txtDate.ReadOnly = valueBoolean
        txtProjectName.ReadOnly = valueBoolean
        txtState.ReadOnly = valueBoolean
        txtSupplyingWarehouse.ReadOnly = valueBoolean
        txtTWCControlNumber.ReadOnly = valueBoolean
        txtTWCCoordinator.ReadOnly = valueBoolean
        txtZone.ReadOnly = valueBoolean
        txtAerial.ReadOnly = valueBoolean
        txtUnderground.ReadOnly = valueBoolean
        txtMSRNumber.ReadOnly = valueBoolean

    End Sub
    Private Sub setButtonsForEdit()

        'Setting the buttons for editing
        btnAdd.Text = "Save"
        btnEdit.Enabled = False
        btnMainMenu.Enabled = False

    End Sub
    Private Sub ResetButtonAfterEditing()

        'Setting the buttons for adding a record
        btnAdd.Text = "Add"
        btnEdit.Enabled = True
        btnMainMenu.Enabled = True

    End Sub
    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click

        'Sets the buttons up to edit a record
        setControlsReadOnly(False)
        setButtonsForEdit()
        previousSelectedIndex = cboInternalProjectID.SelectedIndex
        setComboBoxBinding()
        btnDelete.Enabled = False

    End Sub

    Private Sub InternalProjects_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'This routine runs when the form is loaded up

        'This Try - Catch is used to protect the make sure that the program loads correctly
        'And if there is a problem, the exception is routed to a Message Box, instead of 
        'the whole program crashing
        'Setting local variable

        PleaseWait.Show()

        Try

            'This will bind the controls to the data source
            TheInternalProjectsDataTier = New InternalProjectsDataTier
            TheInternalProjectsDataSet = TheInternalProjectsDataTier.GetInternalProjectsInformation
            TheInternalProjectsBindingSource = New BindingSource

            'Setting up Binding Source for the Combo Box
            With TheInternalProjectsBindingSource
                .DataSource = TheInternalProjectsDataSet
                .DataMember = "internalprojects"
                .MoveFirst()
                .MoveLast()
            End With

            'Setting the data relationship for the Combo Box
            With cboInternalProjectID
                .DataSource = TheInternalProjectsBindingSource
                .DisplayMember = "internalProjectID"
                .DataBindings.Add("text", TheInternalProjectsBindingSource, "internalProjectID", False, DataSourceUpdateMode.Never)
            End With

            'Setting the data binding for the text boxes
            txtProjectName.DataBindings.Add("text", TheInternalProjectsBindingSource, "ProjectName")
            txtTWCControlNumber.DataBindings.Add("text", TheInternalProjectsBindingSource, "TWCControlNumber")
            txtTWCCoordinator.DataBindings.Add("text", TheInternalProjectsBindingSource, "TWCCoordinator")
            txtDate.DataBindings.Add("text", TheInternalProjectsBindingSource, "Date")
            txtAddress.DataBindings.Add("text", TheInternalProjectsBindingSource, "Address")
            txtCity.DataBindings.Add("text", TheInternalProjectsBindingSource, "City")
            txtState.DataBindings.Add("text", TheInternalProjectsBindingSource, "State")
            txtSupplyingWarehouse.DataBindings.Add("text", TheInternalProjectsBindingSource, "SupplyingWarehouse")
            txtZone.DataBindings.Add("text", TheInternalProjectsBindingSource, "Zone")
            txtAerial.DataBindings.Add("text", TheInternalProjectsBindingSource, "Aerial")
            txtUnderground.DataBindings.Add("text", TheInternalProjectsBindingSource, "Underground")
            txtMSRNumber.DataBindings.Add("text", TheInternalProjectsBindingSource, "MSRNumber")

            'Filling project structure
            ResetAndFillStructure()

            setControlsReadOnly(True)

            btnBack.Visible = False
            btnNext.Visible = False
            btnDelete.Enabled = False

            PleaseWait.Close()

        Catch ex As Exception

            'If an exception is thrown, it is rounted here
            PleaseWait.Close()
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        'This will add or save a record to the data set

        'Setting local variables
        Dim blnFatalError As Boolean
        Dim intNumberOfRecords As Integer
        Dim strValueForValidation As String
        Dim strErrorMessage As String = ""
        Dim blnThereIsAProblem As Boolean = False
        Dim datTodayDate As Date = Date.Now
        Dim strTodayDate As String

        'Setting up if statements
        If btnAdd.Text = "Add" Then  'This routine will run if the user is adding an employee
            With TheInternalProjectsBindingSource
                .EndEdit()
                .AddNew()
            End With

            'Calling sub-routines and setting call values
            cboInternalProjectID.Visible = True
            addingBoolean = True
            setComboBoxBinding()
            cboInternalProjectID.Focus()
            setControlsReadOnly(False)
            setButtonsForEdit()
            If cboInternalProjectID.SelectedIndex <> -1 Then
                previousSelectedIndex = cboInternalProjectID.Items.Count - 1
            Else
                previousSelectedIndex = 0
            End If

            'Setting up fields with auto-data to avoid having the user do it.
            mintNumuberOfRecords = cboInternalProjectID.Items.Count
            intNumberOfRecords = mintNumuberOfRecords + 1000

            'Creating the project ID
            CreateProjectID.Show()

            cboInternalProjectID.Text = CStr(Logon.mintCreatedTransactionID)
            txtSupplyingWarehouse.Text = CStr(Logon.mstrHomeOffice)
            strTodayDate = CStr(datTodayDate)
            txtDate.Text = strTodayDate

        Else  'This else statement runs when the record is saved

            strValueForValidation = txtProjectName.Text
            blnFatalError = TheInputDataValidation.VerifyTextData(strValueForValidation)
            If blnFatalError = True Then
                blnThereIsAProblem = True
                strErrorMessage = strErrorMessage + "Project Name was not Entered" + vbNewLine
            End If

            strValueForValidation = txtTWCCoordinator.Text
            blnFatalError = TheInputDataValidation.VerifyTextData(strValueForValidation)
            If blnFatalError = True Then
                blnThereIsAProblem = True
                strErrorMessage = strErrorMessage + "Time Warner Coordinator was not Entered" + vbNewLine
            End If

            strValueForValidation = txtDate.Text
            blnFatalError = TheInputDataValidation.VerifyStartingEndingDatesAsDates(strValueForValidation)
            If blnFatalError = True Then
                blnThereIsAProblem = True
                strErrorMessage = strErrorMessage + "The Date was not Entered" + vbNewLine
            End If

            strValueForValidation = txtSupplyingWarehouse.Text
            blnFatalError = TheInputDataValidation.VerifyTextData(strValueForValidation)
            If blnFatalError = True Then
                blnThereIsAProblem = True
                strErrorMessage = strErrorMessage + "Supplying Warehouse was not Entered" + vbNewLine
            End If

        If blnThereIsAProblem = True Then
            MessageBox.Show(strErrorMessage, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        'Setting variables to see if project exists
        Logon.mstrProjectName = txtProjectName.Text
        Logon.mstrTWCProjectID = txtTWCControlNumber.Text
            Logon.mintInternalProjectID = CInt(cboInternalProjectID.Text)
            Logon.mstrMSR = txtMSRNumber.Text

        CheckForMatchingProject.Show()

        End If

    End Sub
    Public Sub UpdateProjectDataTables()

        'Updating Database
        PleaseWait.Show()
        Try

            TheInternalProjectsBindingSource.EndEdit()
            TheInternalProjectsDataTier.UpdateInternalProjectsDB(TheInternalProjectsDataSet)
            addingBoolean = False
            editingBoolean = False
            setControlsReadOnly(True)
            setComboBoxBinding()
            cboInternalProjectID.SelectedIndex = previousSelectedIndex
            ResetButtonAfterEditing()
            cboInternalProjectID.DisplayMember = "internalProjectID"
            ResetAndFillStructure()
            PleaseWait.Close()

        Catch ex As Exception

            PleaseWait.Close()
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub
    Private Sub ResetAndFillStructure()

        'this sub routine will fill the structure
        'setting local variables
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer

        'Dimenisioning the variables and structures
        intNumberOfRecords = cboInternalProjectID.Items.Count - 1
        ReDim structProjects(intNumberOfRecords)
        ReDim mintSelectedIndex(intNumberOfRecords)
        mintProjectUpperLimit = intNumberOfRecords
        mintProjectCounter = 0
        btnBack.Visible = False
        btnNext.Visible = False

        'beginning loop
        For intCounter = 0 To intNumberOfRecords

            'incrementing the counter
            cboInternalProjectID.SelectedIndex = intCounter

            'loading the structure
            structProjects(intCounter).mintSelectedIndex = intCounter
            structProjects(intCounter).mintInternalProjectID = CInt(cboInternalProjectID.Text)
            structProjects(intCounter).mstrProjectName = txtProjectName.Text
            structProjects(intCounter).mstrSupplyingWarehouse = txtSupplyingWarehouse.Text
            structProjects(intCounter).mstrTWCCoordinator = txtTWCCoordinator.Text
            structProjects(intCounter).mstrTWCProjectID = txtTWCControlNumber.Text
            structProjects(intCounter).mstrMSRNumber = txtMSRNumber.Text

        Next

    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click

        'local variables
        Dim intCounter As Integer
        Dim strKeyWordForSearch As String
        Dim strKeyWordFromTable As String
        Dim strProjectIDForSearch As String
        Dim strProjectIDFromTable As String
        Dim strMSRNumberForSearch As String
        Dim strMSRNumberFromTable As String
        Dim blnItemNotFound As Boolean = True
        Dim blnTransactionFound As Boolean
        Dim blnFatalError As Boolean
        Dim blnKeyWordNotFound As Boolean

        'performing data validation
        strKeyWordForSearch = txtSearchProjects.Text
        blnFatalError = TheInputDataValidation.VerifyTextData(strKeyWordForSearch)

        btnBack.Enabled = False
        btnNext.Enabled = False
        btnBack.Visible = False
        btnNext.Visible = False
        cboInternalProjectID.Visible = True

        If blnFatalError = True Then
            MessageBox.Show("No Information For Search", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        'Peparing for Loop
        mintSelectedCounter = 0
        strProjectIDForSearch = strKeyWordForSearch
        strMSRNumberForSearch = strKeyWordForSearch

        'Beginning Loop
        For intCounter = 0 To mintProjectUpperLimit

            blnTransactionFound = False

            'First Check Project ID
            strProjectIDFromTable = structProjects(intCounter).mstrTWCProjectID
            strMSRNumberFromTable = structProjects(intCounter).mstrMSRNumber
            strKeyWordFromTable = structProjects(intCounter).mstrProjectName
            blnKeyWordNotFound = TheKeyWordDataSearch.FindKeyWord(strKeyWordForSearch, strKeyWordFromTable)

            If strProjectIDForSearch = strProjectIDFromTable Then
                blnTransactionFound = True
            End If
            If strMSRNumberFromTable <> "" Then
                If strMSRNumberForSearch = strMSRNumberFromTable Then
                    blnTransactionFound = True
                End If
            End If
            If blnKeyWordNotFound = False Then
                blnTransactionFound = True
            End If

            If blnTransactionFound = True Then

                'loading up the array
                mintSelectedIndex(mintSelectedCounter) = structProjects(intCounter).mintSelectedIndex
                mintSelectedCounter += 1
                blnItemNotFound = False

            End If
        Next

        If blnItemNotFound = True Then
            txtSearchProjects.Text = ""
            MessageBox.Show("No Projects Were Found Matching Search Criteria", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        btnDelete.Enabled = True

        mintSelectedUpperLimit = mintSelectedCounter - 1
        mintSelectedCounter = 0
        cboInternalProjectID.Visible = False
        txtSearchProjects.Text = ""

        cboInternalProjectID.SelectedIndex = mintSelectedIndex(0)

        If mintSelectedUpperLimit > 0 Then

            btnNext.Visible = True
            btnBack.Visible = True
            btnNext.Enabled = True
            btnBack.Enabled = False

        End If

    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click

        'this will increment the counter
        mintSelectedCounter += 1

        cboInternalProjectID.SelectedIndex = mintSelectedIndex(mintSelectedCounter)

        btnBack.Enabled = True

        If mintSelectedCounter = mintSelectedUpperLimit Then
            btnNext.Enabled = False
        End If

    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click

        'this will increment the counter
        mintSelectedCounter -= 1

        cboInternalProjectID.SelectedIndex = mintSelectedIndex(mintSelectedCounter)

        btnNext.Enabled = True

        If mintSelectedCounter = 0 Then
            btnBack.Enabled = False
        End If

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

        'This will launch if the user wants to delete a record
        CommandConfirmation.ShowDialog()

        If Logon.mblnAreYouSure = True Then

            Try

                cboInternalProjectID.Visible = True

                'loading up to save the deleted project
                Logon.mintCreatedTransactionID = CInt(cboInternalProjectID.Text)
                Logon.mstrMSR = txtMSRNumber.Text
                Logon.mstrTWCProjectID = txtTWCControlNumber.Text
                Logon.mstrProjectName = txtProjectName.Text
                Logon.mstrWarehouse = txtSupplyingWarehouse.Text

                RemovedProjects.Show()

                TheInternalProjectsBindingSource.RemoveCurrent()
                TheInternalProjectsDataTier.UpdateInternalProjectsDB(TheInternalProjectsDataSet)

                ResetAndFillStructure()

                btnDelete.Enabled = False

                MessageBox.Show("The Current Record Was Removed", "Thank You", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf Logon.mblnAreYouSure = False Then

            'Message to user
            MessageBox.Show("The Record Was Not Deleted", "Thank You", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

    End Sub

    Private Sub btnFindDuplicateProjects_Click(sender As Object, e As EventArgs) Handles btnFindDuplicateProjects.Click

        'this will launch duplicate projects
        LastTransaction.Show()
        FindDuplicateProjects.Show()
        Me.Close()

    End Sub
End Class