'Title:         Archive Tool History
'Date:          122-17-15
'Author:        Terry Holmes

'Description:   This form is to archive tool history transactions

Option Strict On

Public Class ArchiveToolHistory

    'setting up the data tables
    Private TheToolHistoryDataSet As ToolsHistoryDataSet
    Private TheToolHistoryDataTier As ToolHistoryDataTier
    Private WithEvents TheToolHistoryBindingSource As BindingSource

    Private TheArchiveToolHistoryDataSet As ArchiveToolHistoryDataSet
    Private TheArchiveToolHistoryDataTier As ArchiveDataTier
    Private WithEvents TheArchiveToolHistoryBindingSource As BindingSource

    Private addingBoolean As Boolean
    Private editingBoolean As Boolean

    'setting up class variables
    Dim TheDateSearch As New DateSearchClass
    Dim TheInputDataValidation As New InputDataValidation
    Dim mstrErrorMessage As String

    Structure ArchiveToolHistory
        Dim mintTransactionID As Integer
        Dim mstrToolID As String
        Dim mintEmployeeID As Integer
        Dim mintWarehouseEmployeeID As Integer
        Dim mdatTransactionDate As Date
        Dim mstrAvailability As String
        Dim mstrNotes As String
    End Structure

    Dim structArchiveToolHistory() As ArchiveToolHistory
    Dim mintHistoryCounter As Integer
    Dim mintHistoryUpperLimit As Integer

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        CloseTheProgram.ShowDialog()
    End Sub

    Private Sub btnMainMenu_Click(sender As Object, e As EventArgs) Handles btnMainMenu.Click
        LastTransaction.Show()
        MainMenu.Show()
        Me.Close()
    End Sub

    Private Sub btnAdminMenu_Click(sender As Object, e As EventArgs) Handles btnAdminMenu.Click
        LastTransaction.Show()
        AdministrativeMenu.Show()
        Me.Close()
    End Sub

    Private Sub btnUtilitiesMenu_Click(sender As Object, e As EventArgs) Handles btnUtilitiesMenu.Click
        LastTransaction.Show()
        UtilitiesMenu.Show()
        Me.Close()
    End Sub

    Private Sub ArchiveToolHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'this will run loading the form
        'setting local variables
        Dim blnFatalError As Boolean

        PleaseWait.Show()

        blnFatalError = SetToolHistoryDataBindings()

        If blnFatalError = False Then
            blnFatalError = SetArchiveToolHistoryDataBindings()
        End If

        PleaseWait.Close()

        If blnFatalError = True Then
            MessageBox.Show(mstrErrorMessage, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Function SetArchiveToolHistoryDataBindings() As Boolean

        'setting local variables
        Dim blnFatalError As Boolean = False
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer

        Try

            'setting the variables
            TheArchiveToolHistoryDataTier = New ArchiveDataTier
            TheArchiveToolHistoryDataSet = TheArchiveToolHistoryDataTier.GetArchiveToolHistoryInformation
            TheArchiveToolHistoryBindingSource = New BindingSource

            'setting up the binding source
            With TheArchiveToolHistoryBindingSource
                .DataSource = TheArchiveToolHistoryDataSet
                .DataMember = "archivetoolhistory"
                .MoveFirst()
                .MoveLast()
            End With

            'setting up the combo box
            With cboArchiveTransactionID
                .DataSource = TheArchiveToolHistoryBindingSource
                .DisplayMember = "TransactionID"
                .DataBindings.Add("text", TheArchiveToolHistoryBindingSource, "TransactionID", False, DataSourceUpdateMode.Never)
            End With

            'setting up the rest of the controls
            txtArchiveDate.DataBindings.Add("text", TheArchiveToolHistoryBindingSource, "Date")
            txtArchiveToolID.DataBindings.Add("text", TheArchiveToolHistoryBindingSource, "ToolID")
            txtArchiveEmployeeID.DataBindings.Add("text", TheArchiveToolHistoryBindingSource, "EmployeeID")
            txtArchiveWHEmployeeID.DataBindings.Add("text", TheArchiveToolHistoryBindingSource, "WarehouseEmployeeID")
            txtArchiveAvailability.DataBindings.Add("text", TheArchiveToolHistoryBindingSource, "Availablity")
            txtArchiveNotes.DataBindings.Add("text", TheArchiveToolHistoryBindingSource, "Notes")

            'getting ready to do the loop
            intNumberOfRecords = cboArchiveTransactionID.Items.Count - 1

            'setting up the structure
            ReDim structArchiveToolHistory(intNumberOfRecords)
            mintHistoryUpperLimit = intNumberOfRecords

            'loading the structure
            For intCounter = 0 To intNumberOfRecords

                cboArchiveTransactionID.SelectedIndex = intCounter

                structArchiveToolHistory(intCounter).mintTransactionID = CInt(cboArchiveTransactionID.Text)
                structArchiveToolHistory(intCounter).mintEmployeeID = CInt(txtArchiveEmployeeID.Text)
                structArchiveToolHistory(intCounter).mintWarehouseEmployeeID = CInt(txtArchiveWHEmployeeID.Text)
                structArchiveToolHistory(intCounter).mdatTransactionDate = CDate(txtArchiveDate.Text)
                structArchiveToolHistory(intCounter).mstrAvailability = txtArchiveAvailability.Text
                structArchiveToolHistory(intCounter).mstrNotes = txtArchiveNotes.Text
                structArchiveToolHistory(intCounter).mstrToolID = txtArchiveToolID.Text

            Next

            'returning value to calling sub routine
            Return blnFatalError

        Catch ex As Exception

            mstrErrorMessage = ex.Message
            blnFatalError = True

            'returning value to calling sub routine
            Return blnFatalError

        End Try

    End Function
    Private Function SetToolHistoryDataBindings() As Boolean

        'setting local variables
        Dim blnFatalError As Boolean = False

        Try

            'setting the variables
            TheToolHistoryDataTier = New ToolHistoryDataTier
            TheToolHistoryDataSet = TheToolHistoryDataTier.GetHistoryInformation
            TheToolHistoryBindingSource = New BindingSource

            'setting up the binding source
            With TheToolHistoryBindingSource
                .DataSource = TheToolHistoryDataSet
                .DataMember = "toolhistory"
                .MoveFirst()
                .MoveLast()
            End With

            'setting up the combo box
            With cboTransactionID
                .DataSource = TheToolHistoryBindingSource
                .DisplayMember = "TransactionID"
                .DataBindings.Add("text", TheToolHistoryBindingSource, "TransactionID", False, DataSourceUpdateMode.Never)
            End With

            'setting up the rest of the controls
            txtDate.DataBindings.Add("text", TheToolHistoryBindingSource, "Date")
            txtToolID.DataBindings.Add("text", TheToolHistoryBindingSource, "ToolID")
            txtEmployeeID.DataBindings.Add("text", TheToolHistoryBindingSource, "EmployeeID")
            txtWHEmployeeID.DataBindings.Add("text", TheToolHistoryBindingSource, "WarehouseEmployeeID")
            txtAvailability.DataBindings.Add("text", TheToolHistoryBindingSource, "Availablity")
            txtNotes.DataBindings.Add("text", TheToolHistoryBindingSource, "Notes")

            'returning value to calling sub routine
            Return blnFatalError

        Catch ex As Exception

            mstrErrorMessage = ex.Message
            blnFatalError = True

            'returning value to calling sub routine
            Return blnFatalError

        End Try
    End Function

    Private Sub setComboBoxBinding()

        'This sub-routine sets and changes the combo box binding 
        With Me.cboArchiveTransactionID
            If (addingBoolean Or editingBoolean) Then
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.OnValidation
                .DropDownStyle = ComboBoxStyle.Simple
            Else
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.Never
                .DropDownStyle = ComboBoxStyle.DropDownList
            End If
        End With

    End Sub

    Private Sub btnArchive_Click(sender As Object, e As EventArgs) Handles btnArchive.Click

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

                    With TheArchiveToolHistoryBindingSource
                        .EndEdit()
                        .AddNew()
                    End With

                    'setting up to add the record
                    addingBoolean = True
                    setComboBoxBinding()
                    cboArchiveTransactionID.Text = cboTransactionID.Text
                    txtArchiveDate.Text = txtDate.Text
                    txtArchiveEmployeeID.Text = txtEmployeeID.Text
                    txtArchiveNotes.Text = txtNotes.Text
                    txtArchiveAvailability.Text = txtAvailability.Text
                    txtArchiveToolID.Text = txtToolID.Text
                    txtArchiveWHEmployeeID.Text = txtWHEmployeeID.Text
                    intNumberOfRecords -= 1
                    blnRecordDeleted = True

                    Try

                        'adding the record
                        TheArchiveToolHistoryBindingSource.EndEdit()
                        TheArchiveToolHistoryDataTier.UpdateArchiveToolHistoryDB(TheArchiveToolHistoryDataSet)
                        addingBoolean = False
                        setComboBoxBinding()

                        'removing the record
                        TheToolHistoryBindingSource.RemoveCurrent()
                        TheToolHistoryDataTier.UpdateDB(TheToolHistoryDataSet)

                    Catch ex As Exception
                        MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try

                    If intCounter = intNumberOfRecords Or intCounter > intNumberOfRecords Then
                        Exit For
                    End If

                Else

                    intNumberOfRecords -= 1
                    blnRecordDeleted = True
                    TheToolHistoryBindingSource.RemoveCurrent()
                    TheToolHistoryDataTier.UpdateDB(TheToolHistoryDataSet)

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
        For intStructureCounter = 0 To mintHistoryUpperLimit

            If structArchiveToolHistory(intStructureCounter).mintTransactionID = CInt(cboTransactionID.Text) Then

                blnDoNotArchive = True

            End If

        Next

        Return blnDoNotArchive

    End Function

End Class