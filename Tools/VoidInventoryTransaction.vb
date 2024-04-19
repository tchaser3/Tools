'Title:         Void Inventory Transaction
'Date:          9-14-15
'Author:        Terry Holmes

'Description:   This form will allow you to remove an inventory item

Option Strict On

Public Class VoidInventoryTransaction

    'Setting up the data componentes
    Private TheBOMPartsDataSet As BOMPartsDataSet
    Private TheBOMPartsDataTier As BOMPartsDataTier
    Private WithEvents TheBOMPartsBindingSource As BindingSource

    Private TheReceivePartsDataSet As ReceivedPartsDataSet
    Private TheReceivePartsDataTier As ReceivePartsDataTier
    Private WithEvents TheReceivePartsBindingSource As BindingSource

    Private TheIssuedPartsDataSet As IssuedPartsDataSet
    Private TheIssuedPartsDataTier As IssuedPartsDataTier
    Private WithEvents TheIssuedPartsBindingSource As BindingSource

    Private TheVoidInventoryTransactionDataSet As VoidInventoryTransactionDataSet
    Private TheVoidInventoryTransactionDataTier As InventoryDataTier
    Private WithEvents TheVoidInventoryTransactionBindingSource As BindingSource

    Dim TheInputDataValidation As New InputDataValidation
    Dim TheDateSearchClass As New DateSearchClass
    Dim mblnNoItemsWereFound As Boolean

    Structure Transactions
        Dim mintSelectedIndex As Integer
        Dim mintTransactionID As Integer
        Dim mstrDate As String
        Dim mstrProjectID As String
        Dim mstrPartNumber As String
        Dim mstrQuantity As String
        Dim mstrWarehouseID As String
        Dim mstrMSRNumber As String
    End Structure

    Structure VoidedTransactions
        Dim mintTransactionID As Integer
        Dim mdatDate As Date
        Dim mstrProjectID As String
        Dim mstrPartNumber As String
        Dim mintQuantity As Integer
        Dim mintWarehouseID As Integer
        Dim mstrMSRNumber As String
        Dim mintEmployeeID As Integer
        Dim mstrTableType As String
        Dim mstrNotes As String
    End Structure

    Dim structVoidedTransactions() As VoidedTransactions
    Dim mintVoidCounter As Integer
    Dim mintVoidUpperLimit As Integer

    Dim structTransactions() As Transactions
    Dim mintStructureCounter As Integer
    Dim mintStructureUpperLimit As Integer
    Dim mstrTableType As String

    Dim structSearchResults() As Transactions
    Dim mintResultCounter As Integer
    Dim mintResultUpperLimit As Integer

    Private addingBoolean As Boolean
    Private editingBoolean As Boolean

    Private Sub SetComboBoxBinding()
        With cboTransactionID
            If (addingBoolean Or editingBoolean) Then
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.OnValidation
                .DropDownStyle = ComboBoxStyle.Simple
            Else
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.OnValidation
                .DropDownStyle = ComboBoxStyle.Simple
            End If
        End With
    End Sub

    Private Sub btnAdministrativeMenu_Click(sender As Object, e As EventArgs) Handles btnAdministrativeMenu.Click

        'this will load the admin menu
        LastTransaction.Show()
        AdministrativeMenu.Show()
        Me.Close()

    End Sub

    Private Sub btnMainMenu_Click(sender As Object, e As EventArgs) Handles btnMainMenu.Click

        'this will load the main menu
        LastTransaction.Show()
        MainMenu.Show()
        Me.Close()

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click

        CloseTheProgram.ShowDialog()

    End Sub
    Private Sub ClearDataBindings()

        'this will clear the data bindings
        cboTransactionID.DataBindings.Clear()
        txtDate.DataBindings.Clear()
        txtPartNumber.DataBindings.Clear()
        txtProjectID.DataBindings.Clear()
        txtQuantity.DataBindings.Clear()
        txtWarehouseID.DataBindings.Clear()
        txtMSRNumber.DataBindings.Clear()
        txtTableType.DataBindings.Clear()
        txtNotes.DataBindings.Clear()
        txtEmployeeID.DataBindings.Clear()

    End Sub
    Private Function SetVoidInventoryTransactionDataBindings() As Boolean

        'setting local variable
        Dim blnFatalError As Boolean = False

        'Try Catch for exceptions
        Try

            'setting the data variables
            TheVoidInventoryTransactionDataTier = New InventoryDataTier
            TheVoidInventoryTransactionDataSet = TheVoidInventoryTransactionDataTier.GetVoidInventoryTransactionInformation
            TheVoidInventoryTransactionBindingSource = New BindingSource

            'Setting up the binding source
            With TheVoidInventoryTransactionBindingSource
                .DataSource = TheVoidInventoryTransactionDataSet
                .DataMember = "voidinventorytransaction"
                .MoveFirst()
                .MoveLast()
            End With

            'setting up the combo box
            With cboTransactionID
                .DataSource = TheVoidInventoryTransactionBindingSource
                .DisplayMember = "TransactionID"
                .DataBindings.Add("text", TheVoidInventoryTransactionBindingSource, "TransactionID", False, DataSourceUpdateMode.Never)
            End With

            txtDate.DataBindings.Add("text", TheVoidInventoryTransactionBindingSource, "Date")
            txtEmployeeID.DataBindings.Add("text", TheVoidInventoryTransactionBindingSource, "EmployeeID")
            txtPartNumber.DataBindings.Add("Text", TheVoidInventoryTransactionBindingSource, "PartNumber")
            txtWarehouseID.DataBindings.Add("Text", TheVoidInventoryTransactionBindingSource, "WarehouseID")
            txtNotes.DataBindings.Add("Text", TheVoidInventoryTransactionBindingSource, "Notes")
            txtProjectID.DataBindings.Add("text", TheVoidInventoryTransactionBindingSource, "ProjectID")
            txtMSRNumber.DataBindings.Add("text", TheVoidInventoryTransactionBindingSource, "MSRNumber")
            txtTableType.DataBindings.Add("text", TheVoidInventoryTransactionBindingSource, "TableType")
            txtQuantity.DataBindings.Add("text", TheVoidInventoryTransactionBindingSource, "Quantity")

            'returning information back to the calling sub-routine
            Return blnFatalError

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            blnFatalError = True
            Return blnFatalError

        End Try
    End Function
    Private Sub SetReceivedDataBindings()

        'This will bind the received bindings
        Try
            TheReceivePartsDataTier = New ReceivePartsDataTier
            TheReceivePartsDataSet = TheReceivePartsDataTier.GetReceivedPartsInformation
            TheReceivePartsBindingSource = New BindingSource

            'Setting up the binding source
            With TheReceivePartsBindingSource
                .DataSource = TheReceivePartsDataSet
                .DataMember = "ReceivedParts"
                .MoveFirst()
                .MoveLast()
            End With

            'setting up the combo box
            With cboTransactionID
                .DataSource = TheReceivePartsBindingSource
                .DisplayMember = "TransactionID"
                .DataBindings.Add("text", TheReceivePartsBindingSource, "TransactionID", False, DataSourceUpdateMode.Never)
            End With

            'setting up the rest of the controls
            txtDate.DataBindings.Add("text", TheReceivePartsBindingSource, "Date")
            txtPartNumber.DataBindings.Add("text", TheReceivePartsBindingSource, "PartNumber")
            txtProjectID.DataBindings.Add("Text", TheReceivePartsBindingSource, "ProjectID")
            txtQuantity.DataBindings.Add("Text", TheReceivePartsBindingSource, "QTY")
            txtWarehouseID.DataBindings.Add("text", TheReceivePartsBindingSource, "WarehouseID")
            txtMSRNumber.DataBindings.Add("Text", TheReceivePartsBindingSource, "MSRNumber")

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub SetIssuedDataBindings()

        Try
            TheIssuedPartsDataTier = New IssuedPartsDataTier
            TheIssuedPartsDataSet = TheIssuedPartsDataTier.GetIssuedPartsInformation
            TheIssuedPartsBindingSource = New BindingSource

            'Setting up the binding source
            With TheIssuedPartsBindingSource
                .DataSource = TheIssuedPartsDataSet
                .DataMember = "IssuedParts"
                .MoveFirst()
                .MoveLast()
            End With

            'setting up the combo box
            With cboTransactionID
                .DataSource = TheIssuedPartsBindingSource
                .DisplayMember = "TransactionID"
                .DataBindings.Add("text", TheIssuedPartsBindingSource, "TransactionID", False, DataSourceUpdateMode.Never)
            End With

            'setting up the rest of the controls
            txtDate.DataBindings.Add("text", TheIssuedPartsBindingSource, "Date")
            txtPartNumber.DataBindings.Add("text", TheIssuedPartsBindingSource, "PartNumber")
            txtProjectID.DataBindings.Add("Text", TheIssuedPartsBindingSource, "ProjectID")
            txtQuantity.DataBindings.Add("Text", TheIssuedPartsBindingSource, "QTY")
            txtWarehouseID.DataBindings.Add("Text", TheIssuedPartsBindingSource, "WarehouseID")
            txtMSRNumber.Text = ""

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub SetBOMDataBindings()

        Try
            TheBOMPartsDataTier = New BOMPartsDataTier
            TheBOMPartsDataSet = TheBOMPartsDataTier.GetBOMPartsInformation
            TheBOMPartsBindingSource = New BindingSource

            'Setting up the binding source
            With TheBOMPartsBindingSource
                .DataSource = TheBOMPartsDataSet
                .DataMember = "BOMParts"
                .MoveFirst()
                .MoveLast()
            End With

            'setting up the combo box
            With cboTransactionID
                .DataSource = TheBOMPartsBindingSource
                .DisplayMember = "TransactionID"
                .DataBindings.Add("text", TheBOMPartsBindingSource, "TransactionID", False, DataSourceUpdateMode.Never)
            End With

            'setting up the rest of the controls
            txtDate.DataBindings.Add("text", TheBOMPartsBindingSource, "Date")
            txtPartNumber.DataBindings.Add("text", TheBOMPartsBindingSource, "PartNumber")
            txtProjectID.DataBindings.Add("Text", TheBOMPartsBindingSource, "ProjectID")
            txtQuantity.DataBindings.Add("Text", TheBOMPartsBindingSource, "QTY")
            txtWarehouseID.DataBindings.Add("text", TheBOMPartsBindingSource, "WarehouseID")
            txtMSRNumber.Text = ""

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub SetControlsVisible(ByVal valueBoolean As Boolean)

        cboTransactionID.Visible = valueBoolean
        txtDate.Visible = valueBoolean
        txtPartNumber.Visible = valueBoolean
        txtProjectID.Visible = valueBoolean
        txtQuantity.Visible = valueBoolean
        txtWarehouseID.Visible = valueBoolean
        txtMSRNumber.Visible = valueBoolean

    End Sub

    Private Sub VoidInventoryTransaction_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Setting up the form load event
        Logon.mstrLastTransactionSummary = "Loaded Void Inventory Transaction"
        ClearDataBindings()
        SetControlsVisible(False)
        txtNotes.Visible = False
        CreateDataGrid()
        dgvSearchResults.Visible = False
        btnVoidTransactions.Enabled = False

    End Sub

    Private Sub cboSelectedTable_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSelectedTable.SelectedIndexChanged

        'this will run when the table is selected
        mstrTableType = cboSelectedTable.Text
        ClearDataBindings()

        If cboSelectedTable.Text = "Received Items" Then
            SetReceivedDataBindings()
            LoadStructure()
        ElseIf cboSelectedTable.Text = "Issued Items" Then
            SetIssuedDataBindings()
            LoadStructure()
        ElseIf cboSelectedTable.Text = "Used Items" Then
            SetBOMDataBindings()
            LoadStructure()
        End If

    End Sub
    Private Sub LoadStructure()

        'Setting local variables
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim blnItemsNotFound As Boolean = True
        Dim intPartsWarehouseIDForSearch As Integer
        Dim intPartsWarehouseIDFromTable As Integer

        PleaseWait.Show()
        SetControlsVisible(True)

        'Setting up for loop
        intNumberOfRecords = cboTransactionID.Items.Count - 1
        ReDim structTransactions(intNumberOfRecords)
        ReDim structSearchResults(intNumberOfRecords)
        ReDim structVoidedTransactions(intNumberOfRecords)
        intPartsWarehouseIDForSearch = Logon.mintPartsWarehouseID
        mintStructureCounter = 0

        'Performing Loop
        For intCounter = 0 To intNumberOfRecords

            'incrementing the combo box
            cboTransactionID.SelectedIndex = intCounter

            'Getting the parts warehouse id from table
            intPartsWarehouseIDFromTable = CInt(txtWarehouseID.Text)

            If intPartsWarehouseIDForSearch = intPartsWarehouseIDFromTable Then

                structTransactions(mintStructureCounter).mintSelectedIndex = intCounter
                structTransactions(mintStructureCounter).mstrDate = txtDate.Text
                structTransactions(mintStructureCounter).mstrProjectID = txtProjectID.Text
                structTransactions(mintStructureCounter).mstrPartNumber = txtPartNumber.Text
                structTransactions(mintStructureCounter).mintTransactionID = CInt(cboTransactionID.Text)
                structTransactions(mintStructureCounter).mstrQuantity = txtQuantity.Text
                structTransactions(mintStructureCounter).mstrWarehouseID = txtWarehouseID.Text
                structTransactions(mintStructureCounter).mstrMSRNumber = txtMSRNumber.Text
                blnItemsNotFound = False
                mintStructureCounter += 1

            End If

        Next

        'setting the boudries of the structure
        mintStructureUpperLimit = mintStructureCounter - 1

        PleaseWait.Close()

        If blnItemsNotFound = True Then
            MessageBox.Show("No Items Were Found For this Warehouse for This Table", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Information)
            SetControlsVisible(False)
        Else
            ClearDataBindings()
            btnFindTransactions.Enabled = True
            cboTransactionID.Visible = False
            txtWarehouseID.Visible = False
            txtMSRNumber.Visible = False
            txtDate.Text = ""
            txtPartNumber.Text = ""
            txtProjectID.Text = ""
            txtQuantity.Text = ""
            SetControlsReadOnly(False)
            txtNotes.Visible = True
        End If

    End Sub
    Private Sub SetControlsReadOnly(ByVal valueBoolean As Boolean)

        txtDate.ReadOnly = valueBoolean
        txtPartNumber.ReadOnly = valueBoolean
        txtProjectID.ReadOnly = valueBoolean
        txtQuantity.ReadOnly = valueBoolean

    End Sub

    Private Sub btnFindTransactions_Click(sender As Object, e As EventArgs) Handles btnFindTransactions.Click

        'Setting local variables
        Dim intCounter As Integer
        Dim blnFatalError As Boolean = False
        Dim strValueForValidation As String
        Dim blnThereIsAProblem As Boolean = False
        Dim datDateFromTable As Date
        Dim datDateForSearch As Date
        Dim datDateFromControl As Date
        Dim datDateFromStructure As Date
        Dim strPartNumberForSearch As String
        Dim strPartNumberFromTable As String
        Dim intQuantityForSearch As Integer
        Dim intQuantityFromTable As Integer
        Dim strProjectIDForSearch As String
        Dim strProjectIDFromTable As String
        Dim strErrorMessage As String = ""
        Dim blnItemNotFound As Boolean = True
        Dim row() As String

        'Clearing the grid
        dgvSearchResults.Rows.Clear()

        'Beginning Data Validation
        strValueForValidation = txtDate.Text
        blnFatalError = TheInputDataValidation.VerifyStartingEndingDatesAsDates(strValueForValidation)
        If blnFatalError = True Then
            blnThereIsAProblem = True
            strErrorMessage = strErrorMessage + "The Date Entered Is Not the Correct Format" + vbNewLine
        End If
        strValueForValidation = txtPartNumber.Text
        blnFatalError = TheInputDataValidation.VerifyTextData(strValueForValidation)
        If blnFatalError = True Then
            blnThereIsAProblem = True
            strErrorMessage = strErrorMessage + "The Part Number Was Not Entered" + vbNewLine
        End If
        strValueForValidation = txtProjectID.Text
        blnFatalError = TheInputDataValidation.VerifyTextData(strValueForValidation)
        If blnFatalError = True Then
            blnThereIsAProblem = True
            strErrorMessage = strErrorMessage + "The Project ID was not Entered" + vbNewLine
        End If
        strValueForValidation = txtQuantity.Text
        blnFatalError = TheInputDataValidation.VerifyIntegerData(strValueForValidation)
        If blnFatalError = True Then
            blnThereIsAProblem = True
            strErrorMessage = strErrorMessage + "The Quantity Entered is not an Integer" + vbNewLine
        End If

        'Output to user if there is a failure
        If blnThereIsAProblem = True Then
            MessageBox.Show(strErrorMessage, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        dgvSearchResults.Visible = True

        'Loading the controls and getting ready for the loop
        strPartNumberForSearch = txtPartNumber.Text
        strProjectIDForSearch = txtProjectID.Text
        intQuantityForSearch = CInt(txtQuantity.Text)
        datDateFromControl = CDate(txtDate.Text)
        datDateForSearch = TheDateSearchClass.RemoveTime(datDateFromControl)
        mintResultCounter = 0

        For intCounter = 0 To mintStructureUpperLimit

            'Loading the variables
            strPartNumberFromTable = structTransactions(intCounter).mstrPartNumber
            strProjectIDFromTable = structTransactions(intCounter).mstrProjectID
            datDateFromStructure = CDate(structTransactions(intCounter).mstrDate)
            datDateFromTable = TheDateSearchClass.RemoveTime(datDateFromStructure)
            intQuantityFromTable = CInt(structTransactions(intCounter).mstrQuantity)

            'If statements for the transaction
            If strPartNumberForSearch = strPartNumberFromTable Then
                If strProjectIDForSearch = strProjectIDFromTable Then
                    If intQuantityForSearch = intQuantityFromTable Then
                        If datDateForSearch = datDateFromTable Then

                            'this will load up the structure
                            structSearchResults(mintResultCounter).mintSelectedIndex = structTransactions(intCounter).mintSelectedIndex
                            structSearchResults(mintResultCounter).mintTransactionID = structTransactions(intCounter).mintTransactionID
                            structSearchResults(mintResultCounter).mstrDate = structTransactions(intCounter).mstrDate
                            structSearchResults(mintResultCounter).mstrProjectID = structTransactions(intCounter).mstrProjectID
                            structSearchResults(mintResultCounter).mstrPartNumber = structTransactions(intCounter).mstrPartNumber
                            structSearchResults(mintResultCounter).mstrQuantity = structTransactions(intCounter).mstrQuantity
                            structSearchResults(mintResultCounter).mstrWarehouseID = structTransactions(intCounter).mstrWarehouseID
                            structSearchResults(mintResultCounter).mstrMSRNumber = structTransactions(intCounter).mstrMSRNumber
                            blnItemNotFound = False
                            row = New String() {CStr(structSearchResults(mintResultCounter).mintTransactionID), structSearchResults(mintResultCounter).mstrDate, structSearchResults(mintResultCounter).mstrProjectID, structSearchResults(mintResultCounter).mstrPartNumber, structSearchResults(mintResultCounter).mstrMSRNumber, structSearchResults(mintResultCounter).mstrQuantity, "NO"}
                            dgvSearchResults.Rows.Add(row)
                            mintResultCounter += 1

                        End If
                    End If
                End If
            End If

        Next

        If blnItemNotFound = True Then
            MessageBox.Show("No Items Were Found", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Error)
            dgvSearchResults.Visible = False
            Exit Sub
        End If

        mintResultUpperLimit = mintResultCounter - 1
        mintResultCounter = 0
        btnVoidTransactions.Enabled = True
        SetControlsForVoiding(False)

    End Sub
    Private Sub SetControlsForVoiding(ByVal valueBoolean As Boolean)

        cboSelectedTable.Visible = valueBoolean
        txtDate.Visible = valueBoolean
        txtPartNumber.Visible = valueBoolean
        txtProjectID.Visible = valueBoolean
        txtQuantity.Visible = valueBoolean
        btnFindTransactions.Visible = valueBoolean
        txtDate.Text = ""
        txtPartNumber.Text = ""
        txtProjectID.Text = ""
        txtQuantity.Text = ""

    End Sub
    Private Sub CreateDataGrid()

        dgvSearchResults.ColumnCount = 7
        dgvSearchResults.Columns(0).Name = "Transaction ID"
        dgvSearchResults.Columns(0).Width = 75
        dgvSearchResults.Columns(1).Name = "Date"
        dgvSearchResults.Columns(1).Width = 75
        dgvSearchResults.Columns(2).Name = "Project ID"
        dgvSearchResults.Columns(2).Width = 75
        dgvSearchResults.Columns(3).Name = "Part Number"
        dgvSearchResults.Columns(3).Width = 100
        dgvSearchResults.Columns(4).Name = "MSR Number"
        dgvSearchResults.Columns(4).Width = 100
        dgvSearchResults.Columns(5).Name = "Quantity"
        dgvSearchResults.Columns(5).Width = 75
        dgvSearchResults.Columns(6).Name = "Void Transaction"
        dgvSearchResults.Columns(6).Width = 75

    End Sub
    Private Sub btnResetForm_Click(sender As Object, e As EventArgs) Handles btnResetForm.Click

        'This will reset the form int intial condition
        SetControlsForVoiding(True)
        SetControlsVisible(False)
        txtEmployeeID.Visible = False
        txtTableType.Visible = False
        txtNotes.Visible = False
        cboSelectedTable.SelectedIndex = 0
        ClearDataBindings()
        dgvSearchResults.Rows.Clear()
        dgvSearchResults.Visible = False
        btnVoidTransactions.Enabled = False

    End Sub

    Private Sub btnVoidTransactions_Click(sender As Object, e As EventArgs) Handles btnVoidTransactions.Click

        'This will be the sub-routine that will void that transaction
        Dim intGridCounter As Integer
        Dim intGridNumberOfRecords As Integer
        Dim intTransactionIDForSearch As Integer
        Dim intTransactionIDFromTable As Integer
        Dim strWasTheTransactionVoided As String
        Dim blnWasTheTransactionVoided As Boolean
        Dim strPartNumberToBeVoided As String
        Dim intQuantityToBeVoided As Integer
        Dim blnNoItemsVoided As Boolean = True
        Dim intPartCounter As Integer
        Dim intPartNumberOfRecords As Integer
        Dim intTotalTransactionsVoided As Integer = 0
        Dim blnItemWasDeleted As Boolean
        Dim blnFatalError As Boolean
        Dim strNotes As String

        strNotes = txtNotes.Text
        blnFatalError = TheInputDataValidation.VerifyTextData(strNotes)
        If blnFatalError = True Then
            MessageBox.Show("No Notes Were Added", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        PleaseWait.Show()

        'clearing the databindings
        ClearDataBindings()

        'Setting the bindings
        If mstrTableType = "Received Items" Then
            SetReceivedDataBindings()
        ElseIf mstrTableType = "Issued Items" Then
            SetIssuedDataBindings()
        ElseIf mstrTableType = "Used Items" Then
            SetBOMDataBindings()
        End If

        'Getting ready for the loop
        intGridNumberOfRecords = dgvSearchResults.Rows.Count - 2
        intPartNumberOfRecords = cboTransactionID.Items.Count - 1
        intTotalTransactionsVoided = 0
        mintVoidCounter = 0

        'beginning loop
        For intGridCounter = 0 To intGridNumberOfRecords

            blnWasTheTransactionVoided = False

            'getting value
            strWasTheTransactionVoided = dgvSearchResults.Rows(intGridCounter).Cells(6).Value.ToString.ToUpper

            'Determining if a transaction should be voided
            If strWasTheTransactionVoided = "YES" Then
                blnWasTheTransactionVoided = True
            End If

            If blnWasTheTransactionVoided = True Then

                'Getting information to find the transactions
                intTransactionIDForSearch = CInt(dgvSearchResults.Rows(intGridCounter).Cells(0).Value.ToString)
                strPartNumberToBeVoided = dgvSearchResults.Rows(intGridCounter).Cells(3).Value.ToString.ToUpper
                intQuantityToBeVoided = CInt(dgvSearchResults.Rows(intGridCounter).Cells(5).Value.ToString)
                Logon.mintQuantity = intQuantityToBeVoided * -1
                Logon.mstrPartNumber = strPartNumberToBeVoided

                'This will load up the void structure
                structVoidedTransactions(mintVoidCounter).mintTransactionID = CInt(dgvSearchResults.Rows(intGridCounter).Cells(0).Value.ToString)
                structVoidedTransactions(mintVoidCounter).mdatDate = CDate(dgvSearchResults.Rows(intGridCounter).Cells(1).Value.ToString)
                structVoidedTransactions(mintVoidCounter).mstrProjectID = dgvSearchResults.Rows(intGridCounter).Cells(2).Value.ToString.ToUpper
                structVoidedTransactions(mintVoidCounter).mstrPartNumber = dgvSearchResults.Rows(intGridCounter).Cells(3).Value.ToString.ToUpper
                structVoidedTransactions(mintVoidCounter).mstrMSRNumber = dgvSearchResults.Rows(intGridCounter).Cells(4).Value.ToString.ToUpper
                structVoidedTransactions(mintVoidCounter).mintQuantity = CInt(dgvSearchResults.Rows(intGridCounter).Cells(5).Value.ToString)
                structVoidedTransactions(mintVoidCounter).mintWarehouseID = Logon.mintPartsWarehouseID
                structVoidedTransactions(mintVoidCounter).mintEmployeeID = Logon.mintWarehouseEmployeeID
                structVoidedTransactions(mintVoidCounter).mstrNotes = strNotes
                structVoidedTransactions(mintVoidCounter).mstrTableType = mstrTableType
                mintVoidCounter += 1

                'Setting up the data bindings
                If mstrTableType = "Received Items" Then
                    UpdateInventory.Show()
                    UpdateWarehouseInventory.Show()
                ElseIf mstrTableType = "Issued Items" Then
                    UpdateWarehouseInventory.Show()
                ElseIf mstrTableType = "Used Items" Then
                    UpdateInventory.Show()
                End If

                'starting second loop
                For intPartCounter = 0 To intPartNumberOfRecords

                    'Incrementing the combo box
                    cboTransactionID.SelectedIndex = intPartCounter

                    'getting the transaction id
                    intTransactionIDFromTable = CInt(cboTransactionID.Text)

                    If intTransactionIDForSearch = intTransactionIDFromTable Then


                        Try
                            If mstrTableType = "Received Items" Then
                                TheReceivePartsBindingSource.RemoveCurrent()
                                TheReceivePartsDataTier.UpdateReceivedPartsDB(TheReceivePartsDataSet)
                            ElseIf mstrTableType = "Issued Items" Then
                                TheIssuedPartsBindingSource.RemoveCurrent()
                                TheIssuedPartsDataTier.UpdateIssuedPartsDB(TheIssuedPartsDataSet)
                            ElseIf mstrTableType = "Used Items" Then
                                TheBOMPartsBindingSource.RemoveCurrent()
                                TheBOMPartsDataTier.UpdateBOMPartsDB(TheBOMPartsDataSet)
                            End If
                            intPartNumberOfRecords -= 1
                            blnItemWasDeleted = True
                            intTotalTransactionsVoided += 1
                            blnNoItemsVoided = False
                            Exit For
                        Catch ex As Exception
                            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                    End If
                Next

            End If

        Next

        mintVoidUpperLimit = mintVoidCounter - 1
        mintVoidCounter = 0

        'Closing the sub-routine out.
        PleaseWait.Close()

        'Determining if there were transactions voided
        If blnNoItemsVoided = True Then
            MessageBox.Show("No Items were Voided", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf blnNoItemsVoided = False Then
            ClearDataBindings()
            SetControlsVisible(True)
            txtTableType.Visible = True
            txtEmployeeID.Visible = True
            blnFatalError = SetVoidInventoryTransactionDataBindings()
            If blnFatalError = False Then
                blnFatalError = SaveVoidedTransactions()
            End If
            If blnFatalError = True Then
                MessageBox.Show("The Transaction was Voided, but Not Written to the Voided Transaction Table", "Please Enter Manually", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            MessageBox.Show("There Were " + CStr(intTotalTransactionsVoided) + " Voided", "Sub Routine Complete", MessageBoxButtons.OK, MessageBoxIcon.Error)
            btnResetForm.PerformClick()
        End If

    End Sub
    Private Function SaveVoidedTransactions() As Boolean

        'Setting local variables
        Dim intCounter As Integer
        Dim blnFatalError As Boolean = False

        PleaseWait.Show()

        'Looping to Save Transactions
        For intCounter = 0 To mintVoidUpperLimit

            Try

                'Setting up to add records
                With TheVoidInventoryTransactionBindingSource
                    .EndEdit()
                    .AddNew()
                End With

                'Setting controls and loading
                addingBoolean = True
                SetComboBoxBinding()
                cboTransactionID.Text = CStr(structVoidedTransactions(intCounter).mintTransactionID)
                txtDate.Text = CStr(structVoidedTransactions(intCounter).mdatDate)
                txtEmployeeID.Text = CStr(structVoidedTransactions(intCounter).mintEmployeeID)
                txtPartNumber.Text = structVoidedTransactions(intCounter).mstrPartNumber
                txtWarehouseID.Text = CStr(structVoidedTransactions(intCounter).mintWarehouseID)
                txtNotes.Text = structVoidedTransactions(intCounter).mstrNotes
                txtProjectID.Text = structVoidedTransactions(intCounter).mstrProjectID
                txtMSRNumber.Text = structVoidedTransactions(intCounter).mstrMSRNumber
                txtTableType.Text = structVoidedTransactions(intCounter).mstrTableType
                txtQuantity.Text = CStr(structVoidedTransactions(intCounter).mintQuantity)

                'saving the record
                TheVoidInventoryTransactionBindingSource.EndEdit()
                TheVoidInventoryTransactionDataTier.UpdateVoidInventoryTransactionDB(TheVoidInventoryTransactionDataSet)
                addingBoolean = False
                editingBoolean = False
                SetComboBoxBinding()

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
                blnFatalError = True
                Exit For
            End Try
        Next

        PleaseWait.Close()

        'Returning to calling sub-routine
        Return blnFatalError

    End Function
End Class