'Title:         The Create A Trailer Form
'Date:          7/11/13
'Author:        Terry Holmes

'Description:   This form is used to create a trailer

'Update:        8-24-15 - Reviewing code for optimial performance

Option Strict On

Public Class CreateATrailer

    'Setting Modular Variables
    Private TheTrailersDataSet As TrailersDataSet
    Private TheTrailersDataTier As TrailersDataTier
    Private WithEvents TheTrailersBindingSource As BindingSource

    Private addingBoolean As Boolean = False
    Private editingBoolean As Boolean = False
    Private previousSelectedIndex As Integer
    Dim mintNumuberOfRecords As Integer

    Dim TheInputDataValidation As New InputDataValidation
    Dim TheKeyWordSearchClass As New KeyWordSearchClass

    Dim LogDateTime As Date = DateAndTime.Now
    Dim strLogDateTime As String

    'Setting Global Variable
    Dim mintSelectedIndex(20) As Integer
    Dim mintIndexCounter As Integer
    Dim mintIndexUpperLimit As Integer

    Structure Trailers
        Dim mintTrailerIndex As Integer
        Dim mintBJCNumber As Integer
    End Structure

    Dim structTrailers() As Trailers
    Dim mintTrailerCounter As Integer
    Dim mintTrailerUpperLimit As Integer

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        'Closes the Program
        CloseTheProgram.ShowDialog()

    End Sub

    Private Sub btnAdministrativeMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdministrativeMenu.Click

        'Opens the Administrative Menu
        LastTransaction.Show()
        AdministrativeMenu.Show()
        Me.Close()

    End Sub

    Private Sub btnMainMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMainMenu.Click

        'This will open the main menu
        LastTransaction.Show()
        MainMenu.Show()
        Me.Close()

    End Sub
    Private Sub setComboBoxBinding()

        'Sets the Combobox Binding
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
    Private Sub setControlsReadOnly(ByVal valueBoolean As Boolean)

        'This will set controls either to read only or not
        With Me
            txtActive.ReadOnly = valueBoolean
            txtEmployeeID.ReadOnly = valueBoolean
            txtDate.ReadOnly = valueBoolean
            txtLicensePlate.ReadOnly = valueBoolean
            txtDescription.ReadOnly = valueBoolean
            txtBJCNumber.ReadOnly = valueBoolean
            txtAvailable.ReadOnly = valueBoolean
            txtNotes.ReadOnly = valueBoolean
        End With

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

    Private Sub CreateATrailer_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'This routine runs when the form is loaded
        PleaseWait.Show()
        Logon.mstrLastTransactionSummary = "Loaded Create a Trailer Form"

        'This Try Catch will catch any exceptions that are through during the routine
        Try

            'This will bind the controls to the data source
            TheTrailersDataTier = New TrailersDataTier
            TheTrailersDataSet = TheTrailersDataTier.GetTrailersInformation
            TheTrailersBindingSource = New BindingSource

            'Setting up the binding for the Combobox
            With TheTrailersBindingSource
                .DataSource = TheTrailersDataSet
                .DataMember = "trailers"
                .MoveFirst()
                .MoveLast()
            End With

            'Setting up the Table Relationships and binding for the table.
            With cboTrailerID
                .DataSource = TheTrailersBindingSource
                .DisplayMember = "TrailerID"
                .DataBindings.Add("text", TheTrailersBindingSource, "TrailerID", False, DataSourceUpdateMode.Never)
            End With

            'Setting up the data bindings for the textboxes
            txtEmployeeID.DataBindings.Add("text", TheTrailersBindingSource, "EmployeeID")
            txtDate.DataBindings.Add("text", TheTrailersBindingSource, "Date")
            txtLicensePlate.DataBindings.Add("text", TheTrailersBindingSource, "LicensePlate")
            txtBJCNumber.DataBindings.Add("text", TheTrailersBindingSource, "BJCNumber")
            txtDescription.DataBindings.Add("text", TheTrailersBindingSource, "Description")
            txtAvailable.DataBindings.Add("text", TheTrailersBindingSource, "Available")
            txtActive.DataBindings.Add("text", TheTrailersBindingSource, "Active")
            txtNotes.DataBindings.Add("text", TheTrailersBindingSource, "Notes")

            LoadTrailerStructure()

            setControlsReadOnly(True)

            PleaseWait.Close()

        Catch ex As Exception
            PleaseWait.Close()
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub LoadTrailerStructure()

        'Setting local variables
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer

        'Setting up for loop
        intNumberOfRecords = cboTrailerID.Items.Count - 1
        ReDim structTrailers(intNumberOfRecords)
        ReDim mintSelectedIndex(intNumberOfRecords)
        mintTrailerUpperLimit = intNumberOfRecords

        'Perfoming loop
        For intCounter = 0 To intNumberOfRecords

            'incrementing the combo box
            cboTrailerID.SelectedIndex = intCounter

            'Loading up the structure
            structTrailers(intCounter).mintTrailerIndex = intCounter
            structTrailers(intCounter).mintBJCNumber = CInt(txtBJCNumber.Text)

        Next

    End Sub
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        'This will add or save a record to the data set

        'Setting local variables
        Dim blnFatalError As Boolean = False
        Dim blnItemNotFound As Boolean
        Dim blnThereIsAProblem As Boolean = False
        Dim strHomeOffice As String
        Dim strValueForValidation As String
        Dim strErrorMessage As String = ""

        'Setting up if statements
        If btnAdd.Text = "Add" Then  'This routine will run if the user is adding a trailer

            btnSearchForNumber.Enabled = False

            'Placing the Binding Source to Add a record
            With TheTrailersBindingSource
                .EndEdit()
                .AddNew()
            End With

            'Calling routines and setting the values
            addingBoolean = True
            setComboBoxBinding()
            cboTrailerID.Focus()
            setControlsReadOnly(False)
            setButtonsForEdit()
            If cboTrailerID.SelectedIndex <> -1 Then
                previousSelectedIndex = cboTrailerID.Items.Count - 1
            Else
                previousSelectedIndex = 0
            End If

            'Calling the Trailer ID From
            TrailersIDCheck.Show()

            strHomeOffice = CStr(Logon.mstrHomeOffice)

            txtEmployeeID.Text = CStr(Logon.mintWarehouseID)

            cboTrailerID.Text = CStr(Logon.mintCreatedTransactionID)
            txtActive.Text = "YES"
            txtAvailable.Text = "YES"
            strLogDateTime = CStr(LogDateTime)
            txtDate.Text = strLogDateTime
            txtEmployeeID.ReadOnly = True
        Else

            'Clearing and setting initial Data Validation Values
            strValueForValidation = txtEmployeeID.Text
            blnFatalError = TheInputDataValidation.VerifyIntegerData(strValueForValidation)
            If blnFatalError = True Then
                blnThereIsAProblem = True
                strErrorMessage = strErrorMessage + "The Employee ID was not Entered" + vbNewLine
            End If

            strValueForValidation = txtDate.Text
            blnFatalError = TheInputDataValidation.VerifyStartingEndingDatesAsDates(strValueForValidation)
            If blnFatalError = True Then
                blnThereIsAProblem = True
                strErrorMessage = strErrorMessage + "The Date is not in the Correct Format" + vbNewLine
            End If

            strValueForValidation = txtLicensePlate.Text
            blnFatalError = TheInputDataValidation.VerifyTextData(strValueForValidation)
            If blnFatalError = True Then
                blnThereIsAProblem = True
                strErrorMessage = strErrorMessage + "The License Plate was not Entered" + vbNewLine
            End If

            strValueForValidation = txtBJCNumber.Text
            blnFatalError = TheInputDataValidation.VerifyIntegerData(strValueForValidation)
            If blnFatalError = True Then
                blnThereIsAProblem = True
                strErrorMessage = strErrorMessage + "The BJC Number Entered is not an Integer" + vbNewLine
            Else
                blnItemNotFound = BJCNumberSearch(CInt(strValueForValidation))
                If blnItemNotFound = False Then
                    blnThereIsAProblem = True
                    strErrorMessage = strErrorMessage + "BJC Value Entered Already Exists" + vbNewLine
                End If
            End If

            strValueForValidation = txtDescription.Text
            blnFatalError = TheInputDataValidation.VerifyTextData(strValueForValidation)
            If blnFatalError = True Then
                blnThereIsAProblem = True
                strErrorMessage = strErrorMessage + "The Description was not Entered" + vbNewLine
            End If

            strValueForValidation = txtAvailable.Text
            blnFatalError = TheInputDataValidation.VerifyYesNoData(strValueForValidation)
            If blnFatalError = True Then
                blnThereIsAProblem = True
                strErrorMessage = strErrorMessage + "The Value Required is Either a Yes or No" + vbNewLine
            End If

            strValueForValidation = txtActive.Text
            blnFatalError = TheInputDataValidation.VerifyYesNoData(strValueForValidation)
            If blnFatalError = True Then
                blnThereIsAProblem = True
                strErrorMessage = strErrorMessage + "The Value Required is Either a Yes or No" + vbNewLine
            End If

            'Putting out error message if data validation fails
            If blnThereIsAProblem = True Then
                MessageBox.Show(strErrorMessage, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            'Updating Database
            Try
                TheTrailersBindingSource.EndEdit()
                TheTrailersDataTier.UpdateDB(TheTrailersDataSet)
                addingBoolean = False
                editingBoolean = False
                setControlsReadOnly(True)
                ResetButtonAfterEditing()
                setComboBoxBinding()
                cboTrailerID.SelectedIndex = previousSelectedIndex
                LoadTrailerStructure()
                btnSearchForNumber.Enabled = True

            Catch ex As Exception
                MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If
    End Sub
    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click

        'Getting the form ready to edit a record
        setControlsReadOnly(False)
        setButtonsForEdit()
        previousSelectedIndex = cboTrailerID.SelectedIndex
        setComboBoxBinding()
        txtEmployeeID.ReadOnly = True

    End Sub
    

    Private Sub txtBJCNumberForSearching_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBJCNumberForSearching.KeyDown

        If e.KeyCode = Keys.Enter Then

            btnSearchForNumber.PerformClick()

        End If

    End Sub
    Private Function BJCNumberSearch(ByVal intBJCNumberForSearch As Integer) As Boolean

        Dim intCounter As Integer
        Dim blnItemNotFound As Boolean = True
        Dim intBJCNumberFromTable As Integer

        'Getting ready for the loop
        mintIndexCounter = 0

        'Peforming the loop
        For intCounter = 0 To mintTrailerUpperLimit

            'getting bjc number from structure
            intBJCNumberFromTable = structTrailers(intCounter).mintBJCNumber

            'If statements comparing the bjc numbers
            If intBJCNumberForSearch = intBJCNumberFromTable Then

                mintSelectedIndex(mintIndexCounter) = structTrailers(intCounter).mintTrailerIndex
                mintIndexCounter += 1
                blnItemNotFound = False

            End If
        Next

        If blnItemNotFound = False Then
            mintIndexUpperLimit = mintIndexCounter - 1
            mintIndexCounter = 0
        End If

        Return blnItemNotFound

    End Function
    Private Sub btnSearchForNumber_Click(sender As Object, e As EventArgs) Handles btnSearchForNumber.Click

        'Setting local variables
        Dim strValueForValidation As String
        Dim blnFatalError As Boolean = False
        Dim blnItemNotFound As Boolean
        Dim intBJCNumberForSearch As Integer

        'Performing data validation
        strValueForValidation = txtBJCNumberForSearching.Text
        blnFatalError = TheInputDataValidation.VerifyIntegerData(strValueForValidation)
        If blnFatalError = True Then
            MessageBox.Show("The Value Entered is not an Integer", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        'calling function
        intBJCNumberForSearch = CInt(strValueForValidation)
        blnItemNotFound = BJCNumberSearch(intBJCNumberForSearch)

        'Determining if the item was found
        If blnItemNotFound = True Then
            txtBJCNumberForSearching.Text = ""
            MessageBox.Show("The BJC Number Entered was not Found", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf blnItemNotFound = False Then
            If mintIndexUpperLimit > 0 Then
                btnNext.Enabled = True
            End If
        End If

    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click

        'this will increment the combo box
        mintIndexCounter += 1
        cboTrailerID.SelectedIndex = mintSelectedIndex(mintIndexCounter)

        btnBack.Enabled = True

        If mintIndexCounter = mintIndexUpperLimit Then
            btnNext.Enabled = False
        End If

    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click

        'this will increment the combo box
        mintIndexCounter -= 1
        cboTrailerID.SelectedIndex = mintSelectedIndex(mintIndexCounter)

        btnNext.Enabled = True

        If mintIndexCounter = 0 Then
            btnBack.Enabled = False
        End If

    End Sub
End Class