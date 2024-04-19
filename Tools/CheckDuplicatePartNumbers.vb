'Title:         Check Duplicate Part Numbers
'Date:          9-2-15
'Author:        Terry Holmes

'Description:   This form is used to find Duplicate Part Numbers

Option Strict On

Public Class CheckDuplicatePartNumbers

    'Setting Modular Variables
    Private ThePartNumberDataSet As PartNumberDataSet
    Private ThePartNumberDataTier As PartDataTier
    Private WithEvents ThePartNumberBindingSource As BindingSource

    Structure PartNumbers
        Dim mintSelectedIndex As Integer
        Dim mintPartID As Integer
        Dim mstrPartNumber As String
        Dim mstrDescription As String
        Dim mblnItemAccountedFor As Boolean
    End Structure

    Dim structPartNumbers() As PartNumbers
    Dim mintPartCounter As Integer
    Dim mintPartUpperLimit As Integer

    Dim structSearchResults() As PartNumbers
    Dim mintSearchCounter As Integer
    Dim mintSearchUpperLimit As Integer

    Dim TheInputDataValidation As New InputDataValidation
    Dim TheKeywordSearch As New KeyWordSearchClass
    Dim TheCheckTWCPartNumber As New CheckTimeWarnerPartNumber

    Private Sub btnUtilitiesMenu_Click(sender As Object, e As EventArgs) Handles btnUtilitiesMenu.Click
        LastTransaction.Show()
        UtilitiesMenu.Show()
        Me.Close()
    End Sub

    Private Sub btnAdminMenu_Click(sender As Object, e As EventArgs) Handles btnAdminMenu.Click
        LastTransaction.Show()
        AdministrativeMenu.Show()
        Me.Close()
    End Sub

    Private Sub btnMainMenu_Click(sender As Object, e As EventArgs) Handles btnMainMenu.Click
        LastTransaction.Show()
        MainMenu.Show()
        Me.Close()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        CloseTheProgram.ShowDialog()
    End Sub

    Private Sub CheckDuplicatePartNumbers_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'This will load the controls
        PleaseWait.Show()

        'Try Catch for Exceptions
        Try
            'Setting the data variables
            ThePartNumberDataTier = New PartDataTier
            ThePartNumberDataSet = ThePartNumberDataTier.GetPartNumberInformation
            ThePartNumberBindingSource = New BindingSource

            'setting up the binding source
            With ThePartNumberBindingSource
                .DataSource = ThePartNumberDataSet
                .DataMember = "partnumbers"
                .MoveFirst()
                .MoveLast()
            End With

            'setting up the combo box
            With cboPartID
                .DataSource = ThePartNumberBindingSource
                .DisplayMember = "PartID"
                .DataBindings.Add("text", ThePartNumberBindingSource, "PartID", False, DataSourceUpdateMode.Never)
            End With

            'Setting up the rest of the controls
            txtActive.DataBindings.Add("Text", ThePartNumberBindingSource, "Active")
            txtDescription.DataBindings.Add("Text", ThePartNumberBindingSource, "Description")
            txtPartNumber.DataBindings.Add("text", ThePartNumberBindingSource, "PartNumber")
            txtPrice.DataBindings.Add("Text", ThePartNumberBindingSource, "Price")
            txtTimeWarnerPart.DataBindings.Add("text", ThePartNumberBindingSource, "TimeWarnerPart")

            'Loading the Structure
            ResetPartStructure()
            SetControlsReadOnly(True)

        Catch ex As Exception

            PleaseWait.Close()
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub
    Private Sub ResetPartStructure()

        'setting local variables
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer

        'Setting up the structures
        intNumberOfRecords = cboPartID.Items.Count - 1
        mintPartUpperLimit = intNumberOfRecords
        ReDim structPartNumbers(intNumberOfRecords)
        ReDim structSearchResults(intNumberOfRecords * 50)

        'Loading structure
        For intCounter = 0 To intNumberOfRecords

            'incrementing the combo box
            cboPartID.SelectedIndex = intCounter
            structPartNumbers(intCounter).mintSelectedIndex = intCounter
            structPartNumbers(intCounter).mintPartID = CInt(cboPartID.Text)
            structPartNumbers(intCounter).mstrDescription = txtDescription.Text
            structPartNumbers(intCounter).mstrPartNumber = txtPartNumber.Text
            structPartNumbers(intCounter).mblnItemAccountedFor = False
        Next

        dgvSearchResults.ColumnCount = 5
        dgvSearchResults.Columns(0).Name = "Selected Index"
        dgvSearchResults.Columns(0).Width = 50
        dgvSearchResults.Columns(1).Name = "Part ID"
        dgvSearchResults.Columns(1).Width = 50
        dgvSearchResults.Columns(2).Name = "Part Number"
        dgvSearchResults.Columns(2).Width = 50
        dgvSearchResults.Columns(3).Name = "Description"
        dgvSearchResults.Columns(3).Width = 150
        dgvSearchResults.Columns(4).Name = "Remove"
        dgvSearchResults.Visible = False

        PleaseWait.Close()
        btnRemoveDuplicates.Enabled = False
        btnCheckForDuplicates.Enabled = True
        btnEdit.Enabled = False
        MakeFindPartIDControlsVisible(False)

    End Sub
    Private Sub MakeFindPartIDControlsVisible(ByVal valueBoolean As Boolean)

        txtEnterPartID.Visible = valueBoolean
        btnFindPartID.Visible = valueBoolean

    End Sub

    Private Sub btnCheckForDuplicates_Click(sender As Object, e As EventArgs) Handles btnCheckForDuplicates.Click

        'This will check the item to see for duplicates.
        'Setting local variables
        Dim intTableCounter As Integer
        Dim intTableNumberOfRecords As Integer
        Dim intStructureCounter As Integer
        Dim strPartNumberForSearch As String
        Dim strPartNumberFromStructure As String
        Dim intPartIDForSearch As Integer
        Dim intPartIDFromStructure As Integer
        Dim blnDuplicateRecordFound As Boolean
        Dim row() As String
        Dim blnItemNotFound As Boolean = True
        Dim intStringLenght As Integer
        Dim blnItemAccountedFor As Boolean

        PleaseWait.Show()

        'getting ready for the table loop
        intTableNumberOfRecords = cboPartID.Items.Count - 1
        mintSearchCounter = 0
        dgvSearchResults.Visible = True
        dgvSearchResults.Rows.Clear()

        'beginning first loop
        For intTableCounter = 0 To intTableNumberOfRecords

            blnDuplicateRecordFound = False

            'incrementing the combo box
            cboPartID.SelectedIndex = intTableCounter

            strPartNumberForSearch = txtPartNumber.Text
            intPartIDForSearch = CInt(cboPartID.Text)

            'Performing the second loop
            For intStructureCounter = 0 To mintPartUpperLimit

                strPartNumberFromStructure = structPartNumbers(intStructureCounter).mstrPartNumber
                intPartIDFromStructure = structPartNumbers(intStructureCounter).mintPartID
                blnItemAccountedFor = structPartNumbers(intStructureCounter).mblnItemAccountedFor

                intStringLenght = strPartNumberForSearch.Length

                If strPartNumberForSearch = strPartNumberFromStructure And blnItemAccountedFor = False Then
                    If intPartIDForSearch <> intPartIDFromStructure Then

                        structSearchResults(mintSearchCounter).mintSelectedIndex = structPartNumbers(intStructureCounter).mintSelectedIndex
                        structSearchResults(mintSearchCounter).mintPartID = structPartNumbers(intStructureCounter).mintPartID
                        structSearchResults(mintSearchCounter).mstrPartNumber = structPartNumbers(intStructureCounter).mstrPartNumber
                        structSearchResults(mintSearchCounter).mstrDescription = structPartNumbers(intStructureCounter).mstrDescription
                        structPartNumbers(intStructureCounter).mblnItemAccountedFor = True
                        row = New String() {CStr(structSearchResults(mintSearchCounter).mintSelectedIndex), CStr(structSearchResults(mintSearchCounter).mintPartID), structSearchResults(mintSearchCounter).mstrPartNumber, structSearchResults(mintSearchCounter).mstrDescription, "NO"}
                        dgvSearchResults.Rows.Add(row)
                        blnDuplicateRecordFound = True
                        mintSearchCounter += 1
                        blnItemNotFound = False
                    End If
                End If
            Next

            If blnDuplicateRecordFound = True Then
                structSearchResults(mintSearchCounter).mintSelectedIndex = intTableCounter
                structSearchResults(mintSearchCounter).mintPartID = CInt(cboPartID.Text)
                structSearchResults(mintSearchCounter).mstrPartNumber = txtPartNumber.Text
                structSearchResults(mintSearchCounter).mstrDescription = txtDescription.Text
                row = New String() {CStr(structSearchResults(mintSearchCounter).mintSelectedIndex), CStr(structSearchResults(mintSearchCounter).mintPartID), structSearchResults(mintSearchCounter).mstrPartNumber, structSearchResults(mintSearchCounter).mstrDescription, "NO"}
                dgvSearchResults.Rows.Add(row)
                For intStructureCounter = 0 To mintPartUpperLimit
                    If structSearchResults(mintSearchCounter).mintPartID = structPartNumbers(intStructureCounter).mintPartID Then
                        structPartNumbers(intStructureCounter).mblnItemAccountedFor = True
                    End If
                Next
                mintSearchCounter += 1
            End If
        Next

        btnCheckForDuplicates.Enabled = False
        btnRemoveDuplicates.Enabled = True

        PleaseWait.Close()
        If blnItemNotFound = True Then
            MessageBox.Show("No Duplicates were found", "Thank You", MessageBoxButtons.OK, MessageBoxIcon.Information)
            dgvSearchResults.Visible = False
        Else
            MakeFindPartIDControlsVisible(True)
        End If

    End Sub

    Private Sub btnResetForm_Click(sender As Object, e As EventArgs) Handles btnResetForm.Click
        PleaseWait.Show()
        dgvSearchResults.Rows.Clear()
        ResetPartStructure()
    End Sub

    Private Sub btnRemoveDuplicates_Click(sender As Object, e As EventArgs) Handles btnRemoveDuplicates.Click

        'Setting up to remove duplicate records
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim strDoesItGetRemoved As String
        Dim intSelectedIndex As Integer
        Dim intPartIDForSearch As Integer
        Dim intPartIDFromTable As Integer
        Dim intPartCounter As Integer
        Dim intPartNumberOfRecords As Integer

        PleaseWait.Show()

        'setting the number of records
        intNumberOfRecords = dgvSearchResults.RowCount - 2

        For intCounter = 0 To intNumberOfRecords

            strDoesItGetRemoved = dgvSearchResults.Rows(intCounter).Cells(4).Value.ToString.ToUpper

            'If Statements to determin if record is removed
            If strDoesItGetRemoved = "YES" Then
                Try
                    'Setting up for loop
                    intPartIDForSearch = CInt(dgvSearchResults.Rows(intCounter).Cells(1).Value.ToString)
                    intPartNumberOfRecords = cboPartID.Items.Count - 1
                    'performing Loop
                    For intPartCounter = 0 To intPartNumberOfRecords

                        'incrementing the combo box
                        cboPartID.SelectedIndex = intPartCounter

                        intPartIDFromTable = CInt(cboPartID.Text)

                        If intPartIDForSearch = intPartIDFromTable Then
                            intSelectedIndex = intPartCounter
                        End If

                    Next

                    'Setting the record to be removed
                    cboPartID.SelectedIndex = intSelectedIndex
                    Logon.mstrPartNumber = txtPartNumber.Text
                    UpdateDuplicateInventoryPartNumbers.Show()

                    'removing the record
                    ThePartNumberBindingSource.RemoveCurrent()
                    ThePartNumberDataTier.UpdatePartNumberDB(ThePartNumberDataSet)

                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        Next

        btnResetForm.PerformClick()

        PleaseWait.Close()
        MessageBox.Show("Process is Complete, all Selected Records Have Been Removed", "Thank You", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub btnFindPartID_Click(sender As Object, e As EventArgs) Handles btnFindPartID.Click

        'Setting local variables
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim intPartIDForSearch As Integer
        Dim intPartIDFromTable As Integer
        Dim blnFatalError As Boolean
        Dim blnItemNotFound As Boolean = True
        Dim blnItemInGrid As Boolean = False
        Dim strValueForValidation As String
        Dim intSelectedIndex As Integer

        'Preforming Data Validation
        strValueForValidation = txtEnterPartID.Text
        blnFatalError = TheInputDataValidation.VerifyIntegerData(strValueForValidation)
        If blnFatalError = True Then
            MessageBox.Show("Value Entered is not an Integer", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        'Getting ready to do the loop
        intNumberOfRecords = dgvSearchResults.RowCount - 1
        intPartIDForSearch = CInt(txtEnterPartID.Text)

        'Performing loop
        For intCounter = 0 To intNumberOfRecords

            'getting the part id from the grid
            intPartIDFromTable = structSearchResults(intCounter).mintPartID

            'checking the part id to see if it is in the grid
            If intPartIDForSearch = intPartIDFromTable Then
                blnItemInGrid = True
            End If
        Next

        'if statements if item is in the grid
        If blnItemInGrid = False Then
            MessageBox.Show("Part ID Entered was not in Grid", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        'beginning loop
        For intCounter = 0 To mintPartUpperLimit

            cboPartID.SelectedIndex = intCounter

            intPartIDFromTable = CInt(cboPartID.Text)

            If intPartIDForSearch = intPartIDFromTable Then
                intSelectedIndex = intCounter
                Exit For
            End If
        Next

        cboPartID.SelectedIndex = intCounter

        btnEdit.Enabled = True
        btnEdit.PerformClick()

    End Sub
    Private Sub SetControlsReadOnly(ByVal valueBoolean As Boolean)

        txtActive.ReadOnly = valueBoolean
        txtDescription.ReadOnly = valueBoolean
        txtPartNumber.ReadOnly = valueBoolean
        txtPrice.ReadOnly = valueBoolean
        txtTimeWarnerPart.ReadOnly = valueBoolean

    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click

        'setting local variables
        Dim strValueForValidation As String
        Dim blnFatalError As Boolean = False
        Dim blnThereIsAProblem As Boolean = False
        Dim strErrorMessage As String = ""

        'This will run when the edit button is pressed
        If btnEdit.Text = "Edit" Then
            SetControlsReadOnly(False)
            btnEdit.Text = "Save"
        Else

            'performing data validation
            strValueForValidation = txtActive.Text
            blnFatalError = TheInputDataValidation.VerifyYesNoData(strValueForValidation)
            If blnFatalError = True Then
                blnThereIsAProblem = True
                strErrorMessage = strErrorMessage + "Active Requires a Yes No Format" + vbNewLine
            End If
            strValueForValidation = txtDescription.Text
            blnFatalError = TheInputDataValidation.VerifyTextData(strValueForValidation)
            If blnFatalError = True Then
                blnThereIsAProblem = True
                strErrorMessage = strErrorMessage + "No Description Was Entered" + vbNewLine
            End If
            strValueForValidation = txtPartNumber.Text
            blnFatalError = TheInputDataValidation.VerifyTextData(strValueForValidation)
            If blnFatalError = True Then
                blnThereIsAProblem = True
                strErrorMessage = strErrorMessage + "No Part Number was Entered" + vbNewLine
            End If
            strValueForValidation = txtPrice.Text
            blnFatalError = TheInputDataValidation.VerifyMoney(strValueForValidation)
            If blnFatalError = True Then
                blnThereIsAProblem = True
                strErrorMessage = strErrorMessage + "Price was not Entered or in Incorrect Format" + vbNewLine
            End If
            strValueForValidation = txtTimeWarnerPart.Text
            blnFatalError = TheInputDataValidation.VerifyYesNoData(strValueForValidation)
            If blnFatalError = True Then
                blnThereIsAProblem = True
                strErrorMessage = strErrorMessage + "Time Warner Part needs to be Either Yes or No" + vbNewLine
            End If
            If blnThereIsAProblem = True Then
                MessageBox.Show(strErrorMessage, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            'Saving the information
            Try
                ThePartNumberBindingSource.EndEdit()
                ThePartNumberDataTier.UpdatePartNumberDB(ThePartNumberDataSet)
                SetControlsReadOnly(True)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If
    End Sub
End Class