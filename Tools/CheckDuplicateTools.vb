'Title:         Check Duplicate Tools
'Date:          9-11-15
'Author:        Terry Holmes

'Description:   This form will identify duplicate tools and remove them

Option Strict On

Public Class CheckDuplicateTools

    Private TheToolsDataTier As ToolsDataTier
    Private TheToolsDataSet As toolsDataSet
    Private WithEvents TheToolsBindingBindingSource As BindingSource

    Structure ToolList
        Dim mintToolKey As Integer
        Dim mstrToolID As String
        Dim mstrPartNumber As String
        Dim mstrType As String
        Dim mstrDescription As String
        Dim mblnItemAccountedFor As Boolean
    End Structure

    Dim structToolList() As ToolList
    Dim mintToolCounter As Integer
    Dim mintToolUpperLimit As Integer

    Dim structSearchResults() As ToolList
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

    Private Sub CheckDuplicateTools_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        PleaseWait.Show()

        'this will load the controls
        Try

            'setting up the data variables
            TheToolsDataTier = New ToolsDataTier
            TheToolsDataSet = TheToolsDataTier.GetToolInformation
            TheToolsBindingBindingSource = New BindingSource

            'Setting up the binding source
            With TheToolsBindingBindingSource
                .DataSource = TheToolsDataSet
                .DataMember = "tools"
                .MoveFirst()
                .MoveLast()
            End With

            'Setting up the combo box
            With cboToolKey
                .DataSource = TheToolsBindingBindingSource
                .DisplayMember = "ToolKey"
                .DataBindings.Add("text", TheToolsBindingBindingSource, "ToolKey", False, DataSourceUpdateMode.Never)
            End With

            'Setting up the rest of the controls
            txtDescription.DataBindings.Add("text", TheToolsBindingBindingSource, "Description")
            txtPartNumber.DataBindings.Add("text", TheToolsBindingBindingSource, "PartNumber")
            txtToolID.DataBindings.Add("Text", TheToolsBindingBindingSource, "ToolID")
            txtToolType.DataBindings.Add("text", TheToolsBindingBindingSource, "Type")

            PleaseWait.Close()

            dgvSearchResults.ColumnCount = 5
            dgvSearchResults.Columns(0).Name = "Tool Key"
            dgvSearchResults.Columns(0).Width = 75
            dgvSearchResults.Columns(1).Name = "Tool ID"
            dgvSearchResults.Columns(1).Width = 100
            dgvSearchResults.Columns(2).Name = "Part Number"
            dgvSearchResults.Columns(2).Width = 100
            dgvSearchResults.Columns(3).Name = "Description"
            dgvSearchResults.Columns(3).Width = 150
            dgvSearchResults.Columns(4).Name = "Remove"

            ResetandLoadToolStructure()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub ResetandLoadToolStructure()

        'Setting local variables
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer

        PleaseWait.Show()
        btnRemoveDuplicates.Enabled = False
        btnEdit.Enabled = False
        SetFindToolsControlsVisible(False)
        dgvSearchResults.Visible = False

        'Getting ready for the loop
        intNumberOfRecords = cboToolKey.Items.Count - 1
        ReDim structToolList(intNumberOfRecords)
        mintToolUpperLimit = intNumberOfRecords
        ReDim structSearchResults(intNumberOfRecords)

        'preforming loop
        For intCounter = 0 To intNumberOfRecords

            'incrementing the combo box
            cboToolKey.SelectedIndex = intCounter

            'loading the structure
            structToolList(intCounter).mintToolKey = CInt(cboToolKey.Text)
            structToolList(intCounter).mstrDescription = txtDescription.Text
            structToolList(intCounter).mstrPartNumber = txtPartNumber.Text
            structToolList(intCounter).mstrToolID = txtToolID.Text
            structToolList(intCounter).mstrType = txtToolType.Text
            structToolList(intCounter).mblnItemAccountedFor = False

        Next

        'finishing the sub-routine
        btnCheckForDuplicates.Enabled = True
        SetControlsVisible(False)
        PleaseWait.Close()

    End Sub
    Private Sub SetFindToolsControlsVisible(ByVal valueBoolean As Boolean)

        btnFindToolKey.Visible = valueBoolean
        txtEnterToolKey.Visible = valueBoolean
    End Sub

    Private Sub btnResetForm_Click(sender As Object, e As EventArgs) Handles btnResetForm.Click
        ResetandLoadToolStructure()
    End Sub

    Private Sub btnCheckForDuplicates_Click(sender As Object, e As EventArgs) Handles btnCheckForDuplicates.Click

        'setting local variables
        Dim intTableCounter As Integer
        Dim intTableNumberOfRecords As Integer
        Dim intStructureCounter As Integer
        Dim strToolIDForSearch As String
        Dim strToolIDFromTable As String
        Dim intToolKeyForSearch As Integer
        Dim intToolKeyFromTable As Integer
        Dim blnDuplicateRecordFound As Boolean
        Dim row() As String
        Dim blnItemNotFound As Boolean = True
        Dim intStringLength As Integer
        Dim blnItemAccountedFor As Boolean

        PleaseWait.Show()
        intTableNumberOfRecords = cboToolKey.Items.Count - 1
        mintSearchCounter = 0
        dgvSearchResults.Visible = True
        dgvSearchResults.Rows.Clear()

        For intTableCounter = 0 To intTableNumberOfRecords

            blnDuplicateRecordFound = False

            'incrementing the combo box
            cboToolKey.SelectedIndex = intTableCounter

            'getting the tool id
            strToolIDForSearch = txtToolID.Text
            intToolKeyForSearch = CInt(cboToolKey.Text)

            'preforming loop on structure
            For intStructureCounter = 0 To mintToolUpperLimit

                strToolIDFromTable = structToolList(intStructureCounter).mstrToolID
                intToolKeyFromTable = structToolList(intStructureCounter).mintToolKey
                blnItemAccountedFor = structToolList(intStructureCounter).mblnItemAccountedFor

                'If statements comparing tool id
                If strToolIDForSearch = strToolIDFromTable Then
                    If blnItemAccountedFor = False Then
                        If intToolKeyForSearch <> intToolKeyFromTable Then

                            'loading search results structure
                            structSearchResults(mintSearchCounter).mintToolKey = structToolList(intStructureCounter).mintToolKey
                            structSearchResults(mintSearchCounter).mstrDescription = structToolList(intStructureCounter).mstrDescription
                            structSearchResults(mintSearchCounter).mstrPartNumber = structToolList(intStructureCounter).mstrPartNumber
                            structSearchResults(mintSearchCounter).mstrToolID = structToolList(intStructureCounter).mstrToolID
                            structSearchResults(mintSearchCounter).mstrType = structToolList(intStructureCounter).mstrType
                            structToolList(intStructureCounter).mblnItemAccountedFor = True
                            row = New String() {CStr(structSearchResults(mintSearchCounter).mintToolKey), structSearchResults(mintSearchCounter).mstrToolID, structSearchResults(mintSearchCounter).mstrPartNumber, structSearchResults(mintSearchCounter).mstrDescription, "NO"}
                            dgvSearchResults.Rows.Add(row)
                            blnDuplicateRecordFound = True
                            mintSearchCounter += 1
                            blnItemNotFound = False

                        End If
                    End If
                End If

            Next

            'loading search structure
            If blnDuplicateRecordFound = True Then
                structSearchResults(mintSearchCounter).mintToolKey = CInt(cboToolKey.Text)
                structSearchResults(mintSearchCounter).mstrDescription = txtDescription.Text
                structSearchResults(mintSearchCounter).mstrPartNumber = txtPartNumber.Text
                structSearchResults(mintSearchCounter).mstrToolID = txtToolID.Text
                structSearchResults(mintSearchCounter).mstrType = txtToolType.Text
                row = New String() {CStr(structSearchResults(mintSearchCounter).mintToolKey), structSearchResults(mintSearchCounter).mstrToolID, structSearchResults(mintSearchCounter).mstrPartNumber, structSearchResults(mintSearchCounter).mstrDescription, "NO"}
                dgvSearchResults.Rows.Add(row)
                For intStructureCounter = 0 To mintToolUpperLimit
                    If structSearchResults(mintSearchCounter).mintToolKey = structToolList(intStructureCounter).mintToolKey Then
                        structToolList(intStructureCounter).mblnItemAccountedFor = True
                    End If
                Next
                mintSearchCounter += 1
            End If

        Next
        
        PleaseWait.Close()

        If blnItemNotFound = True Then
            MessageBox.Show("No Duplicates were found", "Thank You", MessageBoxButtons.OK, MessageBoxIcon.Information)
            dgvSearchResults.Visible = False
        Else
            SetFindToolsControlsVisible(True)
            btnCheckForDuplicates.Enabled = False
            btnRemoveDuplicates.Enabled = True
            mintSearchUpperLimit = mintSearchCounter - 1
            mintSearchCounter = 0
        End If

    End Sub

    Private Sub btnRemoveDuplicates_Click(sender As Object, e As EventArgs) Handles btnRemoveDuplicates.Click

        'This will remove the duplicate records for the user
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim strDoesItGetRemoved As String
        Dim intSelectedIndex As Integer
        Dim intToolKeyForSearch As Integer
        Dim intToolKeyFromTable As Integer
        Dim intToolCounter As Integer
        Dim intToolNumberOfRecords As Integer

        PleaseWait.Show()

        'getting ready for the loop
        intNumberOfRecords = dgvSearchResults.RowCount - 2

        'Preforming Loop
        For intCounter = 0 To intNumberOfRecords

            'determining if the record gets removed
            strDoesItGetRemoved = dgvSearchResults.Rows(intCounter).Cells(4).Value.ToString.ToUpper

            If strDoesItGetRemoved = "YES" Then

                'Try catch for if there is an exception
                Try

                    'getting the record number
                    intToolKeyForSearch = CInt(dgvSearchResults.Rows(intCounter).Cells(0).Value.ToString)

                    'getting the number of records
                    intToolNumberOfRecords = cboToolKey.Items.Count - 1

                    'Performing second loop
                    For intToolCounter = 0 To intToolNumberOfRecords

                        'Incrementing the combo box
                        cboToolKey.SelectedIndex = intToolCounter

                        'getting the tool key from each record
                        intToolKeyFromTable = CInt(cboToolKey.Text)

                        'if statements to determine if to set the selected index
                        If intToolKeyForSearch = intToolKeyFromTable Then
                            intSelectedIndex = intToolCounter
                        End If

                    Next

                    'setting the combo box to correct record
                    cboToolKey.SelectedIndex = intSelectedIndex
                    TheToolsBindingBindingSource.RemoveCurrent()
                    TheToolsDataTier.UpdateToolDB(TheToolsDataSet)

                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If

        Next

        btnResetForm.PerformClick()
        PleaseWait.Close()
        MessageBox.Show("Process Complete, All Selected Records Have Been Removed", "Thank You", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub btnFindToolKey_Click(sender As Object, e As EventArgs) Handles btnFindToolKey.Click

        'This will find the tool key entered
        Dim intNumberOfRecords As Integer
        Dim intCounter As Integer
        Dim intToolKeyForSearch As Integer
        Dim intToolKeyFromTable As Integer
        Dim strValueForValidation As String
        Dim blnFatalError As Boolean = False
        Dim blnItemInGrid As Boolean = False
        Dim intSelectedIndex As Integer

        'performing data validation
        strValueForValidation = txtEnterToolKey.Text
        blnFatalError = TheInputDataValidation.VerifyIntegerData(strValueForValidation)
        If blnFatalError = True Then
            MessageBox.Show("The Value Entered is not an Integer", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        'Checking to see if the key is in the structure
        intToolKeyForSearch = CInt(txtEnterToolKey.Text)
        intNumberOfRecords = mintSearchUpperLimit

        'begging loop
        For intCounter = 0 To intNumberOfRecords

            'getting tool key from structure
            intToolKeyFromTable = structSearchResults(intCounter).mintToolKey

            'If statements to see if the tool key is in the structure
            If intToolKeyForSearch = intToolKeyFromTable Then
                blnItemInGrid = True
            End If

        Next

        If blnItemInGrid = False Then
            MessageBox.Show("The Tool Key Entered was not in the Grid", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        SetControlsVisible(True)

        'beginning loop
        For intCounter = 0 To mintToolUpperLimit

            'incrementing the combo box
            cboToolKey.SelectedIndex = intCounter

            'getting the id
            intToolKeyFromTable = CInt(cboToolKey.Text)

            'compare
            If intToolKeyForSearch = intToolKeyFromTable Then
                intSelectedIndex = intCounter
                Exit For
            End If
        Next

        'setting up to edit record
        cboToolKey.SelectedIndex = intSelectedIndex
        btnEdit.Enabled = True
        btnEdit.PerformClick()

    End Sub
    Private Sub SetControlsReadOnly(ByVal valueBoolean As Boolean)

        txtDescription.ReadOnly = valueBoolean
        txtPartNumber.ReadOnly = valueBoolean
        txtToolID.ReadOnly = valueBoolean
        txtToolType.ReadOnly = valueBoolean

    End Sub
    Private Sub SetControlsVisible(ByVal valueBoolean As Boolean)

        cboToolKey.Visible = valueBoolean
        txtDescription.Visible = valueBoolean
        txtPartNumber.Visible = valueBoolean
        txtToolID.Visible = valueBoolean
        txtToolType.Visible = valueBoolean

    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click

        'This will run when the record is edited
        'Setting local variables
        Dim strValueForValidation As String
        Dim blnFatalError As Boolean = False
        Dim blnThereIsAProblem As Boolean = False
        Dim strErrorMessage As String = ""

        If btnEdit.Text = "Edit" Then
            SetControlsReadOnly(False)
            btnEdit.Text = "Save"
        Else

            'beginning Data Validation
            strValueForValidation = txtDescription.Text
            blnFatalError = TheInputDataValidation.VerifyTextData(strValueForValidation)
            If blnFatalError = True Then
                blnThereIsAProblem = True
                strErrorMessage = strErrorMessage + "The Description Was Not Entered" + vbNewLine
            End If
            strValueForValidation = txtPartNumber.Text
            blnFatalError = TheInputDataValidation.VerifyTextData(strValueForValidation)
            If blnFatalError = True Then
                blnThereIsAProblem = True
                strErrorMessage = strErrorMessage + "The Part Number Was Not Entered" + vbNewLine
            End If
            strValueForValidation = txtToolID.Text
            blnFatalError = TheInputDataValidation.VerifyTextData(strValueForValidation)
            If blnFatalError = True Then
                blnThereIsAProblem = True
                strErrorMessage = strErrorMessage + "The Tool ID was not Entered" + vbNewLine
            End If
            strValueForValidation = txtToolType.Text
            blnFatalError = TheInputDataValidation.VerifyTextData(strValueForValidation)
            If blnFatalError = True Then
                blnThereIsAProblem = True
                strErrorMessage = strErrorMessage + "The Tool Type Was Not Entered" + vbNewLine
            Else
                Logon.mstrToolCategory = strValueForValidation
                ToolCategoryCheck.Show()
                blnFatalError = Logon.mblnToolCategoryExists
                If blnFatalError = True Then
                    blnThereIsAProblem = True
                    strErrorMessage = strErrorMessage + "The Tool Type Entered Was Not Found" + vbNewLine
                End If
            End If

            If blnThereIsAProblem = True Then
                MessageBox.Show(strErrorMessage, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            'Saving the information
            Try
                TheToolsBindingBindingSource.EndEdit()
                TheToolsDataTier.UpdateToolDB(TheToolsDataSet)
                SetControlsReadOnly(True)
                SetControlsVisible(False)
                btnEdit.Text = "Edit"
                btnEdit.Enabled = False
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If

    End Sub
End Class