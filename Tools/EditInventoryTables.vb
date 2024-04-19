'Title:         Edit Inventory Tables
'Date           6-29-15 
'Author:        Terry Holmes

'Description:   This form will edit the inventory tables

Option Strict On

Public Class EditInventoryTables

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

    Dim TheInputDataValidation As New InputDataValidation
    Dim mstrTableType As String

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        CloseTheProgram.ShowDialog()
    End Sub

    Private Sub btnMainMenu_Click(sender As Object, e As EventArgs) Handles btnMainMenu.Click

        LastTransaction.Show()
        MainMenu.Show()
        Me.Close()

    End Sub

    Private Sub ClearDataBindings()

        'this will clear the data bindings
        cboTransactionID.DataBindings.Clear()
        txtMSRNumber.DataBindings.Clear()
        txtDate.DataBindings.Clear()
        txtPartNumber.DataBindings.Clear()
        txtProjectID.DataBindings.Clear()
        txtQuantity.DataBindings.Clear()
        txtWarehouseID.DataBindings.Clear()

    End Sub
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
            txtMSRNumber.DataBindings.Add("text", TheReceivePartsBindingSource, "MSRNumber")
            txtPartNumber.DataBindings.Add("text", TheReceivePartsBindingSource, "PartNumber")
            txtProjectID.DataBindings.Add("Text", TheReceivePartsBindingSource, "ProjectID")
            txtQuantity.DataBindings.Add("Text", TheReceivePartsBindingSource, "QTY")
            txtWarehouseID.DataBindings.Add("text", TheReceivePartsBindingSource, "WarehouseID")

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
            txtWarehouseID.DataBindings.Add("text", TheIssuedPartsBindingSource, "WarehouseID")

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
            txtWarehouseID.DataBindings.Add("Text", TheBOMPartsBindingSource, "WarehouseID")

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub SetControlsVisible(ByVal valueBoolean As Boolean)

        txtMSRNumber.Visible = valueBoolean
        txtDate.Visible = valueBoolean
        txtPartNumber.Visible = valueBoolean
        txtProjectID.Visible = valueBoolean
        txtQuantity.Visible = valueBoolean
        txtWarehouseID.Visible = valueBoolean

    End Sub
    Private Sub SetControlsReadOnly(ByVal valueBoolean As Boolean)

        txtMSRNumber.ReadOnly = valueBoolean
        txtDate.ReadOnly = valueBoolean
        txtPartNumber.ReadOnly = valueBoolean
        txtProjectID.ReadOnly = valueBoolean
        txtQuantity.ReadOnly = valueBoolean
        txtWarehouseID.ReadOnly = valueBoolean

    End Sub

    Private Sub EditInventoryTables_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Logon.mstrLastTransactionSummary = "LOADED EDIT INVENTORY TABLES"
        ClearDataBindings()
        SetControlsVisible(False)
        SetControlsReadOnly(True)
        btnEditRecord.Enabled = False

    End Sub

    Private Sub btnFindRecord_Click(sender As Object, e As EventArgs) Handles btnFindRecord.Click

        'This will find the record
        'Setting local variables
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim intSelectedIndex As Integer
        Dim intTransactionIDForSearch As Integer
        Dim intTransactionIDFromTable As Integer
        Dim strValueForValidation As String
        Dim blnFatalError As Boolean
        Dim blnItemNotFound As Boolean = True
        Dim blnThereIsAProblem As Boolean = False
        Dim strErrorMessage As String = ""

        ClearDataBindings()

        'Setting validation
        If cboSelectTable.Text = "" Then
            blnThereIsAProblem = True
            strErrorMessage = strErrorMessage + "Table Type Was Not Selected" + vbNewLine
        End If

        strValueForValidation = txtEnterTransactionID.Text
        blnFatalError = TheInputDataValidation.VerifyIntegerData(strValueForValidation)
        If blnFatalError = True Then
            blnThereIsAProblem = True
            strErrorMessage = strErrorMessage + "Value Entered Is Not An Integer" + vbNewLine
        Else
            blnFatalError = TheInputDataValidation.VerifyIntegerRange(strValueForValidation)
            If blnFatalError = True Then
                blnThereIsAProblem = True
                strErrorMessage = strErrorMessage + "Integer Entered Is Out Of Range" + vbNewLine
            End If
        End If

        If blnThereIsAProblem = True Then
            MessageBox.Show(strErrorMessage, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        PleaseWait.Show()

        SetControlsVisible(True)

        If cboSelectTable.Text = "RECEIVE" Then
            SetReceivedDataBindings()
        ElseIf cboSelectTable.Text = "ISSUED" Then
            SetIssuedDataBindings()
        ElseIf cboSelectTable.Text = "BOM" Then
            SetBOMDataBindings()
        End If

        'Setting the rtext
        mstrTableType = cboSelectTable.Text

        'getting ready for the loop
        intNumberOfRecords = cboTransactionID.Items.Count - 1
        intTransactionIDForSearch = CInt(strValueForValidation)

        'Performing loop
        For intCounter = 0 To intNumberOfRecords

            cboTransactionID.SelectedIndex = intCounter

            'Getting the transaction id
            intTransactionIDFromTable = CInt(cboTransactionID.Text)

            If intTransactionIDForSearch = intTransactionIDFromTable Then

                intSelectedIndex = intCounter
                blnItemNotFound = False
            End If
        Next

        If blnItemNotFound = True Then
            SetControlsVisible(False)
            PleaseWait.Close()
            MessageBox.Show("The Transaction ID Entered Was Not Found", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        cboTransactionID.SelectedIndex = intSelectedIndex
        btnEditRecord.Enabled = True
        btnFindRecord.Enabled = False
        PleaseWait.Close()

    End Sub

    Private Sub btnEditRecord_Click(sender As Object, e As EventArgs) Handles btnEditRecord.Click

        'Setting local variables
        Dim strValueForValidation As String
        Dim blnFatalError As Boolean = False
        Dim blnThereIsAProblem As Boolean = False
        Dim strErrorMessage As String = ""

        If btnEditRecord.Text = "Edit Record" Then

            SetControlsReadOnly(False)
            btnEditRecord.Text = "Save"

        Else

            If mstrTableType = "RECEIVE" Then
                strValueForValidation = txtMSRNumber.Text
                blnFatalError = TheInputDataValidation.VerifyTextData(strValueForValidation)
                If blnFatalError = True Then
                    blnThereIsAProblem = True
                    strErrorMessage = strErrorMessage + "There is no Value for the MSR Number" + vbNewLine
                End If
            End If

            strValueForValidation = txtDate.Text
            blnFatalError = TheInputDataValidation.VerifyStartingEndingDatesAsDates(strValueForValidation)
            If blnFatalError = True Then
                blnThereIsAProblem = True
                strErrorMessage = strErrorMessage + "The Date Format is not Correct" + vbNewLine
            End If
            strValueForValidation = txtPartNumber.Text
            blnFatalError = TheInputDataValidation.VerifyTextData(strValueForValidation)
            If blnFatalError = True Then
                blnThereIsAProblem = True
                strErrorMessage = strErrorMessage + "There is no Value For the Part Number" + vbNewLine
            End If
            strValueForValidation = txtProjectID.Text
            blnFatalError = TheInputDataValidation.VerifyTextData(strValueForValidation)
            If blnFatalError = True Then
                blnThereIsAProblem = True
                strErrorMessage = strErrorMessage + "There is no Value for the Project ID" + vbNewLine
            End If
            strValueForValidation = txtQuantity.Text
            blnFatalError = TheInputDataValidation.VerifyIntegerData(strValueForValidation)
            If blnFatalError = True Then
                blnThereIsAProblem = True
                strErrorMessage = strErrorMessage + "The Quantity Entered is not an Integer" + vbNewLine
            Else
                blnFatalError = TheInputDataValidation.VerifyIntegerRange(strValueForValidation)
                If blnFatalError = True Then
                    blnThereIsAProblem = True
                    strErrorMessage = strErrorMessage + "The Quantity Entered is Out of Range" + vbNewLine
                End If
            End If
            strValueForValidation = txtWarehouseID.Text
            blnFatalError = TheInputDataValidation.VerifyIntegerData(strValueForValidation)
            If blnFatalError = True Then
                blnThereIsAProblem = True
                strErrorMessage = strErrorMessage + "The Warehouse ID Entered is not an Integer" + vbNewLine
            Else
                blnFatalError = TheInputDataValidation.VerifyIntegerRange(strValueForValidation)
                If blnFatalError = True Then
                    blnThereIsAProblem = True
                    strErrorMessage = strErrorMessage + "The Warehouse ID Entered is Out of Range" + vbNewLine
                End If
            End If


            'Message to user if validation failed
            If blnThereIsAProblem = True Then
                MessageBox.Show(strErrorMessage, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Try

                'Saving edited file
                If mstrTableType = "RECEIVE" Then
                    TheReceivePartsBindingSource.EndEdit()
                    TheReceivePartsDataTier.UpdateReceivedPartsDB(TheReceivePartsDataSet)
                ElseIf mstrTableType = "ISSUED" Then
                    TheIssuedPartsBindingSource.EndEdit()
                    TheIssuedPartsDataTier.UpdateIssuedPartsDB(TheIssuedPartsDataSet)
                ElseIf mstrTableType = "BOM" Then
                    TheBOMPartsBindingSource.EndEdit()
                    TheBOMPartsDataTier.UpdateBOMPartsDB(TheBOMPartsDataSet)
                End If

                ClearDataBindings()
                SetControlsReadOnly(True)
                SetControlsVisible(False)
                btnEditRecord.Text = "Edit Record"
                btnEditRecord.Enabled = False
                btnFindRecord.Enabled = True

                MessageBox.Show("The Edited Record Has Been Saved", "Thank You", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If
    End Sub

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
End Class