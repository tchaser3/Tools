'Title:         Archive Last Transactions
'Date:          8-24-15
'Author:        Terry Holmes

'Description:   This form will archive all last transactions over 30 days

Option Strict On

Public Class ArchiveLastTransactions

    Private TheLastTransactionDataSet As LastTransactionDataSet
    Private TheLastTransactionDataTier As LastTransactionDataTier
    Private WithEvents TheLastTransactionBindingSource As BindingSource

    Private TheArchiveLastTransactionDataSet As ArchiveLastTransactionDataSet
    Private TheArchiveLastTransactionDataTier As ArchiveDataTier
    Private WithEvents TheArchiveLastTransactionBindingSource As BindingSource

    Private AddingBoolean As Boolean = False
    Private EditingBoolean As Boolean = False

    Dim TheDateSearchClass As New DateSearchClass

    Structure ArchivedTransactions
        Dim mstrTransactionID As String
        Dim mstrDate As String
        Dim mstrEmployeeID As String
        Dim mstrLastTransactionSummary As String
    End Structure

    Dim structArchiveTransactions() As ArchivedTransactions
    Dim mintArchivedCounter As Integer
    Dim mintArchivedUpperLimit As Integer
    Dim mstrErrorMessage As String

    Private Sub ArchiveLastTransactions_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Setting local variables
        Dim blnFatalError As Boolean

        Logon.mstrLastTransactionSummary = "Loaded Archive Last Transaction Form"

        blnFatalError = SetTransactionDataBindings()
        If blnFatalError = False Then
            blnFatalError = SetArchiveTransactionDataBindings()
        End If

        PleaseWait.Close()

        If blnFatalError = True Then
            MessageBox.Show(mstrErrorMessage, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf blnFatalError = False Then
            LoadArchiveStructure()
        End If


    End Sub
    Private Sub SetComboBoxBinding()
        With cboArchiveTransactionID
            If AddingBoolean Or EditingBoolean Then
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.OnValidation
                .DropDownStyle = ComboBoxStyle.Simple
            Else
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.Never
                .DropDownStyle = ComboBoxStyle.DropDownList
            End If
        End With
    End Sub
    Private Function SetTransactionDataBindings() As Boolean

        'Setting local variable
        Dim blnFatalError As Boolean = False

        'Try Catch for exceptions
        Try

            'setting up the binding variables
            TheLastTransactionDataTier = New LastTransactionDataTier
            TheLastTransactionDataSet = TheLastTransactionDataTier.GetLastTransactionInformation
            TheLastTransactionBindingSource = New BindingSource

            'Setting up the binding source
            With TheLastTransactionBindingSource
                .DataSource = TheLastTransactionDataSet
                .DataMember = "lasttransaction"
                .MoveFirst()
                .MoveLast()
            End With

            'Setting the combo box
            With cboTransactionID
                .DataSource = TheLastTransactionBindingSource
                .DisplayMember = "TransactionID"
                .DataBindings.Add("text", TheLastTransactionBindingSource, "TransactionID", False, DataSourceUpdateMode.Never)
            End With

            'setting the rest of the controls
            txtDate.DataBindings.Add("Text", TheLastTransactionBindingSource, "Date")
            txtEmployeeID.DataBindings.Add("Text", TheLastTransactionBindingSource, "EmployeeID")
            txtLastTransactionSummary.DataBindings.Add("text", TheLastTransactionBindingSource, "LastTransactionSummary")

            'returned value to calling subroutine
            Return blnFatalError

        Catch ex As Exception

            'setting up to let the user know
            blnFatalError = True
            mstrErrorMessage = ex.Message

            'returned value to calling subroutine
            Return blnFatalError

        End Try

    End Function
    Private Function SetArchiveTransactionDataBindings() As Boolean

        'Setting local variable
        Dim blnFatalError As Boolean = False

        'Try Catch for exceptions
        Try

            'setting up the binding variables
            TheArchiveLastTransactionDataTier = New ArchiveDataTier
            TheArchiveLastTransactionDataSet = TheArchiveLastTransactionDataTier.GetArchiveLastTransactionInformation
            TheArchiveLastTransactionBindingSource = New BindingSource

            'Setting up the binding source
            With TheArchiveLastTransactionBindingSource
                .DataSource = TheArchiveLastTransactionDataSet
                .DataMember = "archivelasttransaction"
                .MoveFirst()
                .MoveLast()
            End With

            'Setting the combo box
            With cboArchiveTransactionID
                .DataSource = TheArchiveLastTransactionBindingSource
                .DisplayMember = "TransactionID"
                .DataBindings.Add("text", TheArchiveLastTransactionBindingSource, "TransactionID", False, DataSourceUpdateMode.Never)
            End With

            'setting the rest of the controls
            txtArchiveDate.DataBindings.Add("Text", TheArchiveLastTransactionBindingSource, "Date")
            txtArchiveEmployeeID.DataBindings.Add("Text", TheArchiveLastTransactionBindingSource, "EmployeeID")
            txtArchiveLastTransactionSummary.DataBindings.Add("text", TheArchiveLastTransactionBindingSource, "LastTransactionSummary")

            'returned value to calling subroutine
            Return blnFatalError

        Catch ex As Exception

            'setting up to let the user know
            blnFatalError = True
            mstrErrorMessage = ex.Message

            'returned value to calling subroutine
            Return blnFatalError

        End Try

    End Function
    Private Sub LoadArchiveStructure()

        'Setting local variables
        Dim intNumberOfRecords As Integer
        Dim intCounter As Integer

        PleaseWait.Show()

        'Setting up for the loop
        intNumberOfRecords = cboArchiveTransactionID.Items.Count - 1
        ReDim structArchiveTransactions(intNumberOfRecords)
        mintArchivedUpperLimit = intNumberOfRecords

        If intNumberOfRecords < 0 Then
            Exit Sub
        End If

        'Beginning loop
        For intCounter = 0 To intNumberOfRecords

            'Incrementing the combo box
            cboArchiveTransactionID.SelectedIndex = intCounter

            'Loading structure
            structArchiveTransactions(intCounter).mstrTransactionID = cboArchiveTransactionID.Text
            structArchiveTransactions(intCounter).mstrDate = txtArchiveDate.Text
            structArchiveTransactions(intCounter).mstrEmployeeID = txtArchiveEmployeeID.Text
            structArchiveTransactions(intCounter).mstrLastTransactionSummary = txtArchiveLastTransactionSummary.Text

        Next

        PleaseWait.Close()

    End Sub
    Private Function DuplicateRecords() As Boolean

        'setting local records
        Dim blnDoNotArchive As Boolean
        Dim intStructureCounter As Integer

        'This will determine if a records is within the structure
        For intStructureCounter = 0 To mintArchivedUpperLimit

            If structArchiveTransactions(intStructureCounter).mstrTransactionID = cboTransactionID.Text Then

                blnDoNotArchive = True

            End If
        Next

        Return blnDoNotArchive

    End Function
    Private Sub ArchiveLastTransactions()

        'Setting Local Variables
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim intNumberOfDays As Integer = 15
        Dim DateForSearch As Date
        Dim strValueForValidation As String
        Dim blnFatalError As Boolean
        Dim DateFromTable As Date
        Dim DateForStart As Date = Date.Now
        Dim blnDoNotArchive As Boolean
        Dim blnRecordDeleted As Boolean = False

        'Getting ready for the search
        intNumberOfRecords = cboTransactionID.Items.Count - 1
        DateForSearch = TheDateSearchClass.SubtractDays(DateForStart, intNumberOfDays)

        'Beginning Loop
        For intCounter = 0 To intNumberOfRecords

            'determining if the loop has to be run
            If intCounter = intNumberOfRecords Or intCounter > intNumberOfRecords Then
                Exit For
            End If

            'setting up for the loop
            blnDoNotArchive = False
            PleaseWait.Show()

            If blnRecordDeleted = True Then
                intCounter -= 1
            End If
            blnRecordDeleted = False

            'incrementing the combo box
            cboTransactionID.SelectedIndex = intCounter

            'Getting date
            strValueForValidation = txtDate.Text
            If strValueForValidation = "" Then
                strValueForValidation = "1/1/15"
                DateFromTable = TheDateSearchClass.RemoveTime(CDate(strValueForValidation))
            Else
                DateFromTable = TheDateSearchClass.RemoveTime(CDate(txtDate.Text))
            End If

            If DateForSearch > DateFromTable Then

                'try catch for exceptions
                blnDoNotArchive = DuplicateRecords()

                If blnDoNotArchive = False Then
                    Try

                        'setting up the binding source
                        With TheArchiveLastTransactionBindingSource
                            .EndEdit()
                            .AddNew()
                        End With

                        AddingBoolean = True
                        SetComboBoxBinding()
                        cboArchiveTransactionID.Text = cboTransactionID.Text
                        txtArchiveDate.Text = CStr(DateFromTable)
                        txtArchiveEmployeeID.Text = txtEmployeeID.Text
                        txtArchiveLastTransactionSummary.Text = txtLastTransactionSummary.Text
                        intNumberOfRecords -= 1
                        blnRecordDeleted = True

                        'adding the record
                        TheArchiveLastTransactionBindingSource.EndEdit()
                        TheArchiveLastTransactionDataTier.UpdateArchiveLastTransactionDB(TheArchiveLastTransactionDataSet)
                        AddingBoolean = False
                        SetComboBoxBinding()

                        'removing the record
                        TheLastTransactionBindingSource.RemoveCurrent()
                        TheLastTransactionDataTier.UpdateLastTransactionDB(TheLastTransactionDataSet)

                    Catch ex As Exception

                        PleaseWait.Close()
                        MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    End Try

                    If intCounter = intNumberOfRecords Or intCounter > intNumberOfRecords Then
                        Exit For
                    End If
                Else

                    'removing record if record is within structure
                    intNumberOfRecords -= 1
                    TheLastTransactionBindingSource.RemoveCurrent()
                    TheLastTransactionDataTier.UpdateLastTransactionDB(TheLastTransactionDataSet)

                    If intCounter = intNumberOfRecords Or intCounter > intNumberOfRecords Then
                        Exit For
                    End If
                End If

            End If
        Next

        PleaseWait.Close()
        MessageBox.Show("All Records Have Been Archived", "Thank You", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

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

    Private Sub btnArchive_Click(sender As Object, e As EventArgs) Handles btnArchive.Click
        ArchiveLastTransactions()
    End Sub
End Class