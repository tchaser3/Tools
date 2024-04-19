'Title:     Create an Employee
'Date:      3/28/13
'Author:    Terry Holmes

Public Class CreateEmployee

    'Setting Modular Variables
    Private TheEmployeeDataSet As EmployeeDataSet
    Private TheEmployeeDataTier As EmployeeDataTier
    Private WithEvents TheEmployeeBindingSource As BindingSource

    Dim TheInputDataValidation As New InputDataValidation

    Private addingBoolean As Boolean = False
    Private editingBoolean As Boolean = False
    Private previousSelectedIndex As Integer
    Dim mintNumuberOfRecords As Integer

    Dim LogDateTime As Date = DateAndTime.Now
    Dim strLogDateTime As String

    'Setting global variable
    Friend mintCreatedCustomerID As Integer

    Dim mintSelectedIndex(20) As Integer
    Dim mintSelectedIndexCounter As Integer = 0
    Dim mintSelectedIndexUpperLimit As Integer

    Friend mstrFirstName As String
    Friend mstrLastName As String
    Friend mblnNameExisits As Boolean = False

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click

        'Closes the Program
        CloseTheProgram.ShowDialog()

    End Sub

    Private Sub btnMainMenu_Click(sender As System.Object, e As System.EventArgs) Handles btnMainMenu.Click

        'Opens up the Main Menu
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

    End Sub
    Private Sub setControlsReadOnly(ByVal valueBoolean As Boolean)

        'This will set controls either to read only or not
        With Me
            txtActive.ReadOnly = valueBoolean
            txtFirstName.ReadOnly = valueBoolean
            txtLastName.ReadOnly = valueBoolean
            txtPhoneNumber.ReadOnly = valueBoolean
            txtGroup.ReadOnly = valueBoolean
            txtHomeOffice.ReadOnly = valueBoolean
            txtTypeOfEmployee.ReadOnly = valueBoolean
        End With

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
        previousSelectedIndex = cboEmployeeID.SelectedIndex
        setComboBoxBinding()

    End Sub

    Private Sub CreateEmployee_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'This routine runs when the form is loaded up

        'This Try - Catch is used to protect the make sure that the program loads correctly
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
            txtActive.DataBindings.Add("text", TheEmployeeBindingSource, "Active")
            txtPhoneNumber.DataBindings.Add("text", TheEmployeeBindingSource, "PhoneNumber")
            txtGroup.DataBindings.Add("text", TheEmployeeBindingSource, "Group")
            txtHomeOffice.DataBindings.Add("text", TheEmployeeBindingSource, "HomeOffice")
            txtTypeOfEmployee.DataBindings.Add("text", TheEmployeeBindingSource, "Type")

            setControlsReadOnly(True)

        Catch ex As Exception

            'If an exception is thrown, it is rounted here
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        'This will add or save a record to the data set

        'Setting local variables
        Dim strValueForValidation As String
        Dim blnFatalError As Boolean = False
        Dim intNumberOfRecords As Integer
        Dim strHeaderMessage As String

        'Setting up if statements
        If btnAdd.Text = "Add" Then  'This routine will run if the user is adding an employee
            With TheEmployeeBindingSource
                .EndEdit()
                .AddNew()
            End With

            'Calling sub-routines and setting call values
            addingBoolean = True
            setComboBoxBinding()
            cboEmployeeID.Focus()
            setControlsReadOnly(False)
            setButtonsForEdit()
            If cboEmployeeID.SelectedIndex <> -1 Then
                previousSelectedIndex = cboEmployeeID.Items.Count - 1
            Else
                previousSelectedIndex = 0
            End If

            'Setting up fields with auto-data to avoid having the user do it.
            mintNumuberOfRecords = cboEmployeeID.Items.Count
            intNumberOfRecords = mintNumuberOfRecords + 1000

            mintCreatedCustomerID = intNumberOfRecords
            txtActive.Text = "YES"

            'Calling the Employee ID
            CreateEmployeeID.Show()
            cboEmployeeID.Text = CStr(mintCreatedCustomerID)

        Else  'This else statement runs when the record is saved

            'Validating the input data
            strValueForValidation = txtFirstName.Text
            strHeaderMessage = "Please Correct The First Name"
            blnFatalError = TheInputDataValidation.VerifyTextData(strValueForValidation)
            If blnFatalError = False Then
                strValueForValidation = txtLastName.Text
                strHeaderMessage = "Please Correct The Last Name"
                blnFatalError = TheInputDataValidation.VerifyTextData(strValueForValidation)
                If blnFatalError = False Then
                    strValueForValidation = txtPhoneNumber.Text
                    strHeaderMessage = "Please Correct The Phone Number"
                    blnFatalError = TheInputDataValidation.VerifyTextData(strValueForValidation)
                    If blnFatalError = False Then
                        strValueForValidation = txtActive.Text
                        strHeaderMessage = "Please Correct The Active"
                        blnFatalError = TheInputDataValidation.VerifyTextData(strValueForValidation)
                        If blnFatalError = False Then
                            strValueForValidation = txtGroup.Text
                            strHeaderMessage = "Please Correct The Group"
                            blnFatalError = TheInputDataValidation.VerifyTextData(strValueForValidation)
                            If blnFatalError = False Then
                                strValueForValidation = txtHomeOffice.Text
                                strHeaderMessage = "Please Correct The Home Office"
                                blnFatalError = TheInputDataValidation.VerifyTextData(strValueForValidation)
                                If blnFatalError = False Then
                                    strValueForValidation = txtTypeOfEmployee.Text
                                    strHeaderMessage = "Please Correct The Type Of Employee"
                                    blnFatalError = TheInputDataValidation.VerifyTextData(strValueForValidation)
                                End If
                            End If
                        End If
                    End If
                End If
            End If

            If blnFatalError = True Then
                MessageBox.Show(strHeaderMessage, strHeaderMessage, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            'Checking to see if the employee name exists
            mstrFirstName = txtFirstName.Text
            mstrLastName = txtLastName.Text
            CheckingEmployeeName.Show()

        End If

    End Sub
    Public Sub SaveRemployeeRecord()

        'Updating Database
        Try
            TheEmployeeBindingSource.EndEdit()
            TheEmployeeDataTier.UpdateDB(TheEmployeeDataSet)
            addingBoolean = False
            editingBoolean = False
            setControlsReadOnly(True)
            setComboBoxBinding()
            cboEmployeeID.SelectedIndex = previousSelectedIndex
            ResetButtonAfterEditing()
            cboEmployeeID.DisplayMember = "EmployeeID"
        Catch ex As Exception
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub btnAdministrativeMenu_Click(sender As System.Object, e As System.EventArgs) Handles btnAdministrativeMenu.Click

        'Loads the Administrative Menu
        AdministrativeMenu.Show()
        Me.Close()

    End Sub

    Private Sub ComboUpdate()

        'Sets the Combobox Binding
        With cboEmployeeID
            .DataSource = TheEmployeeBindingSource
            .DisplayMember = "EmployeeID"
            .DataBindings.Add("text", TheEmployeeBindingSource, "EmployeeID", False, DataSourceUpdateMode.Never)
        End With
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        'This sub-routine allows the user to search for a user
        Dim intNumberOfRecords As Integer
        Dim intCounter As Integer
        Dim strLastNameForSearch As String
        Dim strFirstNameForSearch As String
        Dim strLastNameFromTable As String
        Dim strFirstNameFromTable As String
        Dim strValueForValidation As String
        Dim blnFatalError As Boolean = False
        Dim blnFoundNames As Boolean = False
        Dim strErrorMessage As String

        btnNext.Enabled = False
        btnBack.Enabled = False

        mintSelectedIndexCounter = 0
        mintSelectedIndexUpperLimit = 0

        'Validate User Input
        strValueForValidation = txtSearchLastName.Text
        strErrorMessage = "The Last Name For The Search Was Not Entered"
        blnFatalError = TheInputDataValidation.VerifyTextData(strValueForValidation)
        If blnFatalError = False Then
            strValueForValidation = txtSearchFirstName.Text
            strErrorMessage = "The First Name For The Search Was Not Entered"
            blnFatalError = TheInputDataValidation.VerifyTextData(strValueForValidation)
        End If

        If blnFatalError = True Then
            MessageBox.Show(strErrorMessage, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        intNumberOfRecords = cboEmployeeID.Items.Count - 1

        strLastNameForSearch = txtSearchLastName.Text
        strFirstNameForSearch = txtSearchFirstName.Text

        For intCounter = 0 To intNumberOfRecords

            cboEmployeeID.SelectedIndex = intCounter
            strLastNameFromTable = txtLastName.Text
            strFirstNameFromTable = txtFirstName.Text

            If strFirstNameForSearch = strFirstNameFromTable And strLastNameForSearch = strLastNameFromTable Then

                blnFoundNames = True
                mintSelectedIndex(mintSelectedIndexCounter) = intCounter
                mintSelectedIndexCounter = mintSelectedIndexCounter + 1

            End If
        Next

        If blnFoundNames = False Then
            MessageBox.Show("The Name is Not Found", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Else
            mintSelectedIndexUpperLimit = mintSelectedIndexCounter - 1
            mintSelectedIndexCounter = 0
            cboEmployeeID.SelectedIndex = mintSelectedIndex(mintSelectedIndexCounter)

        End If

        If mintSelectedIndexUpperLimit > 0 Then
            btnNext.Enabled = True
        End If


    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click

        mintSelectedIndexCounter = mintSelectedIndexCounter + 1
        cboEmployeeID.SelectedIndex = mintSelectedIndex(mintSelectedIndexCounter)

        btnBack.Enabled = True

        If mintSelectedIndexCounter = mintSelectedIndexUpperLimit Then

            btnNext.Enabled = False

        End If

    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click

        mintSelectedIndexCounter = mintSelectedIndexCounter - 1
        cboEmployeeID.SelectedIndex = mintSelectedIndex(mintSelectedIndexCounter)

        btnNext.Enabled = True

        If mintSelectedIndexCounter = 0 Then

            btnBack.Enabled = False

        End If

    End Sub
End Class