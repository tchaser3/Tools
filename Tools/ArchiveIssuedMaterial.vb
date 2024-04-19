'Title:         Archive Issued Material
'Date:          6-22-15
'Author:        Terry Holmes

'Description:   This form is used to archive issued material

Public Class ArchiveIssuedMaterial

    Private TheIssuedPartsDataSet As IssuedPartsDataSet
    Private TheIssuedPartsDataTier As IssuedPartsDataTier
    Private WithEvents TheIssuedPartsBindingSource As BindingSource

    Private TheArchiveIssuedDataSet As ArchiveIssuedDataSet
    Private TheArchiveIssuedDataTier As ArchiveIssuedPartsDataTier
    Private WithEvents TheArchiveIssuedBindingSource As BindingSource

    Private addingBoolean As Boolean = False
    Private editingBoolean As Boolean = False
    Private PreviousSelectedIndex As Integer

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

    Dim TheDateSearch As New DateSearchClass

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
            TheIssuedPartsDataTier = New IssuedPartsDataTier
            TheIssuedPartsDataSet = TheIssuedPartsDataTier.GetIssuedPartsInformation
            TheIssuedPartsBindingSource = New BindingSource

            'setting up the binding source
            With TheIssuedPartsBindingSource
                .DataSource = TheIssuedPartsDataSet
                .DataMember = "IssuedParts"
                .MoveFirst()
                .MoveLast()
            End With

            'Setting up the combo box
            With cboTransactionID
                .DataSource = TheIssuedPartsBindingSource
                .DisplayMember = "TransactionID"
                .DataBindings.Add("text", TheIssuedPartsBindingSource, "TransactionID", False, DataSourceUpdateMode.Never)
            End With

            txtDate.DataBindings.Add("text", TheIssuedPartsBindingSource, "Date")
            txtProjectID.DataBindings.Add("text", TheIssuedPartsBindingSource, "ProjectID")
            txtPartNumber.DataBindings.Add("text", TheIssuedPartsBindingSource, "PartNumber")
            txtQuantity.DataBindings.Add("text", TheIssuedPartsBindingSource, "QTY")
            txtWarehouseID.DataBindings.Add("text", TheIssuedPartsBindingSource, "WarehouseID")

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub SetArchiveTransactionDataBindings()

        Try
            'This will set up the bindings
            TheArchiveIssuedDataTier = New ArchiveIssuedPartsDataTier
            TheArchiveIssuedDataSet = TheArchiveIssuedDataTier.GetArchiveIssuedInformation
            TheArchiveIssuedBindingSource = New BindingSource

            'Setting up the bindingsource
            With TheArchiveIssuedBindingSource
                .DataSource = TheArchiveIssuedDataSet
                .DataMember = "archivedissued"
                .MoveFirst()
                .MoveLast()
            End With

            'Setting up the combo box
            With cboArchiveTransactionID
                .DataSource = TheArchiveIssuedBindingSource
                .DisplayMember = "TransactionID"
                .DataBindings.Add("text", TheArchiveIssuedBindingSource, "TransactionID", False, DataSourceUpdateMode.Never)
            End With

            'Setting the rest of the controls
            txtArchiveDate.DataBindings.Add("text", TheArchiveIssuedBindingSource, "Date")
            txtArchivePartNumber.DataBindings.Add("text", TheArchiveIssuedBindingSource, "PartNumber")
            txtArchiveProjectID.DataBindings.Add("text", TheArchiveIssuedBindingSource, "ProjectID")
            txtArchiveQTY.DataBindings.Add("text", TheArchiveIssuedBindingSource, "QTY")
            txtArchiveWarehouseID.DataBindings.Add("Text", TheArchiveIssuedBindingSource, "WarehouseID")

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

        Next

        PleaseWait.Close()

    End Sub

    Private Sub ArchiveIssuedMaterial_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'This is the form load event
        SetTransactionDataBindings()
        SetArchiveTransactionDataBindings()
        LoadArchiveStructure()
        PleaseWait.Close()

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

    Private Sub btnArchive_Click(sender As Object, e As EventArgs) Handles btnArchive.Click

        'Setting local variables
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim intNumberOfDays As Integer = 180
        Dim DateForSearch As Date
        Dim DateFromTable As Date
        Dim DateForStart As Date = Date.Now
        Dim blnRecordDeleted As Boolean = False
        Dim blnDoNotArchive As Boolean

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

                    With TheArchiveIssuedBindingSource
                        .EndEdit()
                        .AddNew()
                    End With

                    'setting up to add the record
                    addingBoolean = True
                    SetComboBoxBinding()
                    cboArchiveTransactionID.Text = cboTransactionID.Text
                    txtArchiveDate.Text = txtDate.Text
                    txtArchiveMSRNumber.Text = txtMSRNumber.Text
                    txtArchivePartNumber.Text = txtPartNumber.Text
                    txtArchiveProjectID.Text = txtProjectID.Text
                    txtArchiveQTY.Text = txtQuantity.Text
                    txtArchiveWarehouseID.Text = txtWarehouseID.Text
                    intNumberOfRecords -= 1
                    blnRecordDeleted = True

                    Try

                        'adding the record
                        TheArchiveIssuedBindingSource.EndEdit()
                        TheArchiveIssuedDataTier.UpdateArchiveIssuedDB(TheArchiveIssuedDataSet)
                        addingBoolean = False
                        SetComboBoxBinding()

                        'removing the record
                        TheIssuedPartsBindingSource.RemoveCurrent()
                        TheIssuedPartsDataTier.UpdateIssuedPartsDB(TheIssuedPartsDataSet)

                    Catch ex As Exception
                        MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try

                    If intCounter = intNumberOfRecords Or intCounter > intNumberOfRecords Then
                        Exit For
                    End If

                Else

                    intNumberOfRecords -= 1
                    blnRecordDeleted = True
                    TheIssuedPartsBindingSource.RemoveCurrent()
                    TheIssuedPartsDataTier.UpdateIssuedPartsDB(TheIssuedPartsDataSet)

                    If intCounter = intNumberOfRecords Or intCounter > intNumberOfRecords Then
                        Exit For
                    End If

                End If
            

            End If

        Next

        PleaseWait.Close()
        MessageBox.Show("All Records Have Been Archived", "Thank You", MessageBoxButtons.OK, MessageBoxIcon.Information)

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