'Title:         Archive Used Material
'Date:          6-24-15
'Author:        Terry Holmes

'Description:   This form is used to archive used material

Option Strict On

Public Class ArchiveUsedMaterial

    Private TheBOMPartsDataSet As BOMPartsDataSet
    Private TheBOMPartsDataTier As BOMPartsDataTier
    Private WithEvents TheBOMPartsBindingSource As BindingSource

    Private TheArchiveUsedDataSet As ArchiveUsedDataSet
    Private TheArchiveUsedDataTier As ArchiveUsedDataTier
    Private WithEvents TheArchiveUsedBindingSource As BindingSource

    Private addingBoolean As Boolean = False
    Private editingBoolean As Boolean = False
    Private PreviousSelectedIndex As Integer

    Dim TheDateSearch As New DateSearchClass

    Structure ArchivedTransactions
        Dim mstrTransactionID As String
        Dim mstrDate As String
        Dim mstrProjectID As String
        Dim mstrPartNumber As String
        Dim mstrMSRNumber As String
        Dim mstrQuantity As String
    End Structure

    Dim structArchivedTransaction() As ArchivedTransactions
    Dim mintStructureUpperLimit As Integer

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        CloseTheProgram.Show()
    End Sub

    Private Sub btnMainMenu_Click(sender As Object, e As EventArgs) Handles btnMainMenu.Click

        LastTransaction.Show()
        MainMenu.Show()
        Me.Close()

    End Sub
    Private Sub SetComboBoxBinding()

        'This will set the combo box bindings
        With cboArchiveTransactionID
            If (addingBoolean Or editingBoolean) Then
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.OnValidation
                .DropDownStyle = ComboBoxStyle.Simple
            Else
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.Never
                .DropDownStyle = ComboBoxStyle.DropDownList
            End If
        End With
    End Sub
    Private Sub SetTransactionDataBindings()

        Try

            'Setting the bindings
            TheBOMPartsDataTier = New BOMPartsDataTier
            TheBOMPartsDataSet = TheBOMPartsDataTier.GetBOMPartsInformation
            TheBOMPartsBindingSource = New BindingSource

            'setting up the binding source
            With TheBOMPartsBindingSource
                .DataSource = TheBOMPartsDataSet
                .DataMember = "BOMParts"
                .MoveFirst()
                .MoveLast()
            End With

            'Setting up the combo box
            With cboTransactionID
                .DataSource = TheBOMPartsBindingSource
                .DisplayMember = "TransactionID"
                .DataBindings.Add("text", TheBOMPartsBindingSource, "TransactionID", False, DataSourceUpdateMode.Never)
            End With

            txtDate.DataBindings.Add("text", TheBOMPartsBindingSource, "Date")
            txtProjectID.DataBindings.Add("text", TheBOMPartsBindingSource, "ProjectID")
            txtPartNumber.DataBindings.Add("text", TheBOMPartsBindingSource, "PartNumber")
            txtQuantity.DataBindings.Add("text", TheBOMPartsBindingSource, "QTY")
            txtWarehouseID.DataBindings.Add("Text", TheBOMPartsBindingSource, "WarehouseID")

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub SetArchiveTransactionDataBindings()

        Try
            'This will set up the bindings
            TheArchiveUsedDataTier = New ArchiveUsedDataTier
            TheArchiveUsedDataSet = TheArchiveUsedDataTier.GetArchiveUsedInformation
            TheArchiveUsedBindingSource = New BindingSource

            'Setting up the bindingsource
            With TheArchiveUsedBindingSource
                .DataSource = TheArchiveUsedDataSet
                .DataMember = "archivedused"
                .MoveFirst()
                .MoveLast()
            End With

            'Setting up the combo box
            With cboArchiveTransactionID
                .DataSource = TheArchiveUsedBindingSource
                .DisplayMember = "TransactionID"
                .DataBindings.Add("text", TheArchiveUsedBindingSource, "TransactionID", False, DataSourceUpdateMode.Never)
            End With

            'Setting the rest of the controls
            txtArchiveDate.DataBindings.Add("text", TheArchiveUsedBindingSource, "Date")
            txtArchivePartNumber.DataBindings.Add("text", TheArchiveUsedBindingSource, "PartNumber")
            txtArchiveProjectID.DataBindings.Add("text", TheArchiveUsedBindingSource, "ProjectID")
            txtArchiveQTY.DataBindings.Add("text", TheArchiveUsedBindingSource, "QTY")
            txtArchiveWarehouseID.DataBindings.Add("text", TheArchiveUsedBindingSource, "WarehouseID")

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub LoadArchiveStructure()

        'Setting local variables
        Dim intNumberOfRecords As Integer
        Dim intCounter As Integer

        PleaseWait.Show()

        'Setting up for the loop
        intNumberOfRecords = cboArchiveTransactionID.Items.Count - 1
        ReDim structArchivedTransaction(intNumberOfRecords)
        mintStructureUpperLimit = intNumberOfRecords

        'if the table is blank
        If intNumberOfRecords < 0 Then
            Exit Sub
        End If

        For intCounter = 0 To intNumberOfRecords

            cboArchiveTransactionID.SelectedIndex = intCounter

            'Loading the array
            structArchivedTransaction(intCounter).mstrTransactionID = cboArchiveTransactionID.Text
            structArchivedTransaction(intCounter).mstrDate = txtArchiveDate.Text
            structArchivedTransaction(intCounter).mstrPartNumber = txtArchivePartNumber.Text
            structArchivedTransaction(intCounter).mstrQuantity = txtArchiveQTY.Text

        Next

        PleaseWait.Close()

    End Sub

    Private Sub ArchiveUsedMaterial_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        SetTransactionDataBindings()
        SetArchiveTransactionDataBindings()
        LoadArchiveStructure()
        PleaseWait.Close()

    End Sub

    Private Sub btnArchive_Click(sender As Object, e As EventArgs) Handles btnArchive.Click

        'Setting local variables
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim intNumberOfDays As Integer = 180
        Dim DateForSearch As Date
        Dim DateFromTable As Date
        Dim DateForStart As Date = Date.Now
        Dim blnDoNotArchive As Boolean
        Dim blnRecordDeleted As Boolean = False

        'Setting up for loop
        intNumberOfRecords = cboTransactionID.Items.Count - 1
        DateForSearch = TheDateSearch.SubtractDays(DateForStart, intNumberOfDays)

        For intCounter = 0 To intNumberOfRecords

            If intCounter = intNumberOfRecords Or intCounter > intNumberOfRecords Then
                Exit For
            End If

            blnDoNotArchive = False
            PleaseWait.Show()
            If blnRecordDeleted = True Then
                intCounter -= 1
            End If
            blnRecordDeleted = False

            cboTransactionID.SelectedIndex = intCounter

            DateFromTable = TheDateSearch.RemoveTime(CDate(txtDate.Text))

            If DateForSearch > DateFromTable Then

                blnDoNotArchive = DuplicateRecords()

                If blnDoNotArchive = False Then

                    With TheArchiveUsedBindingSource
                        .EndEdit()
                        .AddNew()
                    End With

                    'setting up to add the record
                    addingBoolean = True
                    SetComboBoxBinding()
                    cboArchiveTransactionID.Text = cboTransactionID.Text
                    txtArchiveDate.Text = txtDate.Text
                    txtArchivePartNumber.Text = txtPartNumber.Text
                    txtArchiveProjectID.Text = txtProjectID.Text
                    txtArchiveQTY.Text = txtQuantity.Text
                    txtArchiveWarehouseID.Text = txtWarehouseID.Text
                    intNumberOfRecords -= 1
                    blnRecordDeleted = True

                    Try

                        'adding the record
                        TheArchiveUsedBindingSource.EndEdit()
                        TheArchiveUsedDataTier.UpdateArchiveUsedDB(TheArchiveUsedDataSet)
                        addingBoolean = False
                        SetComboBoxBinding()

                        'removing the record
                        TheBOMPartsBindingSource.RemoveCurrent()
                        TheBOMPartsDataTier.UpdateBOMPartsDB(TheBOMPartsDataSet)

                    Catch ex As Exception
                        PleaseWait.Close()
                        MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try

                    If intCounter = intNumberOfRecords Or intCounter > intNumberOfRecords Then
                        Exit For
                    End If

                Else

                    intNumberOfRecords -= 1
                    blnRecordDeleted = True
                    TheBOMPartsBindingSource.RemoveCurrent()
                    TheBOMPartsDataTier.UpdateBOMPartsDB(TheBOMPartsDataSet)

                    If intCounter = intNumberOfRecords Or intCounter > intNumberOfRecords Then
                        Exit For
                    End If

                End If

            End If
        Next
        PleaseWait.Close()
        MessageBox.Show("All Records Have Been Archived", "Thank You", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub
    Private Function DuplicateRecords() As Boolean

        Dim blnDoNotArchive As Boolean
        Dim intStructureCounter As Integer

        'This will determine if the record is within the structure
        For intStructureCounter = 0 To mintStructureUpperLimit

            If structArchivedTransaction(intStructureCounter).mstrTransactionID = cboTransactionID.Text Then

                blnDoNotArchive = True

            End If
        Next

        Return blnDoNotArchive

    End Function

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