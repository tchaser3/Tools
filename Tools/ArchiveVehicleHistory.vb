'Title:         Archive Vehicle History
'Date:          12-14-15
'Author:        Terry Holmes

'Description:   This form is used to archive the vehicle history

Option Strict On

Public Class ArchiveVehicleHistory

    Private TheVehicleHistoryDataSet As VehicleHistoryDataSet
    Private TheVehicleHistoryDataTier As VehicleHistoryDataTier
    Private WithEvents TheVehicleHistoryBindingSource As BindingSource

    Private TheArchiveVehicleHistoryDataSet As ArchiveVehicleHistoryDataSet
    Private TheArchiveVehicleHistoryDataTier As ArchiveDataTier
    Private WithEvents TheArchiveVehicleHistoryBindingSource As BindingSource

    Private addingBoolean As Boolean
    Private editingBoolean As Boolean

    Structure ArchivedVehicleHistory
        Dim mintTransactionID As Integer
        Dim mintVehicleID As Integer
        Dim mintBJCNumber As Integer
        Dim mintEmployeeID As Integer
        Dim mintWarehouseEmployeeID As Integer
        Dim mdatTransactionDate As Date
        Dim mstrNotes As String
        Dim mstrRemoteVehicle As String
    End Structure

    Dim structArchivedHistory() As ArchivedVehicleHistory
    Dim mintHistoryCounter As Integer
    Dim mintHistoryUpperLimit As Integer
    Dim mstrErrorMessage As String

    'setting up class variables
    Dim TheDateSearch As New DateSearchClass
    Dim TheInputDataValidation As New InputDataValidation

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

    Private Sub ArchiveVehicleHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'setting local variables
        Dim blnFatalError As Boolean = False

        PleaseWait.Show()

        blnFatalError = SetVehicleHistoryDataBindings()
        If blnFatalError = False Then
            blnFatalError = SetArchivedHistoryDataBindings()
        End If

        PleaseWait.Close()

        If blnFatalError = True Then
            btnArchive.Enabled = False
            MessageBox.Show(mstrErrorMessage, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub
    Private Function SetArchivedHistoryDataBindings() As Boolean

        'setting local variable
        Dim blnFatalError As Boolean = False
        Dim intNumberOfRecords As Integer
        Dim intCounter As Integer

        Try

            'setting data variables
            TheArchiveVehicleHistoryDataTier = New ArchiveDataTier
            TheArchiveVehicleHistoryDataSet = TheArchiveVehicleHistoryDataTier.GetArchiveVehicleHistoryInformation
            TheArchiveVehicleHistoryBindingSource = New BindingSource

            'setting up the binding source
            With TheArchiveVehicleHistoryBindingSource
                .DataSource = TheArchiveVehicleHistoryDataSet
                .DataMember = "archivevehiclehistory"
                .MoveFirst()
                .MoveLast()
            End With

            'setting up the combo box
            With cboArchiveTransactionID
                .DataSource = TheArchiveVehicleHistoryBindingSource
                .DisplayMember = "TransactionID"
                .DataBindings.Add("text", TheArchiveVehicleHistoryBindingSource, "TransactionID", False, DataSourceUpdateMode.Never)
            End With

            txtArchiveVehicleID.DataBindings.Add("text", TheArchiveVehicleHistoryBindingSource, "VehicleID")
            txtArchiveBJCNumber.DataBindings.Add("Text", TheArchiveVehicleHistoryBindingSource, "BJCNumber")
            txtArchiveEmployeeID.DataBindings.Add("text", TheArchiveVehicleHistoryBindingSource, "EmployeeID")
            txtArchiveWHEmployeeID.DataBindings.Add("Text", TheArchiveVehicleHistoryBindingSource, "WarehouseEmployeeID")
            txtArchiveDate.DataBindings.Add("text", TheArchiveVehicleHistoryBindingSource, "Date")
            txtArchiveNotes.DataBindings.Add("Text", TheArchiveVehicleHistoryBindingSource, "Notes")
            txtArchiveRemoteVehicle.DataBindings.Add("Text", TheArchiveVehicleHistoryBindingSource, "RemoteVehicle")

            intNumberOfRecords = cboArchiveTransactionID.Items.Count - 1
            ReDim structArchivedHistory(intNumberOfRecords)
            mintHistoryUpperLimit = intNumberOfRecords

            For intCounter = 0 To intNumberOfRecords

                'incrementing the combo box
                cboArchiveTransactionID.SelectedIndex = intCounter

                structArchivedHistory(intCounter).mintBJCNumber = CInt(txtArchiveBJCNumber.Text)
                structArchivedHistory(intCounter).mintEmployeeID = CInt(txtArchiveEmployeeID.Text)
                structArchivedHistory(intCounter).mintTransactionID = CInt(cboArchiveTransactionID.Text)
                structArchivedHistory(intCounter).mintVehicleID = CInt(txtArchiveVehicleID.Text)
                structArchivedHistory(intCounter).mintWarehouseEmployeeID = CInt(txtArchiveWHEmployeeID.Text)
                structArchivedHistory(intCounter).mdatTransactionDate = CDate(txtArchiveDate.Text)
                structArchivedHistory(intCounter).mstrNotes = txtArchiveNotes.Text
                structArchivedHistory(intCounter).mstrRemoteVehicle = txtArchiveRemoteVehicle.Text

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
    Private Function SetVehicleHistoryDataBindings() As Boolean

        'setting local variable
        Dim blnFatalError As Boolean = False

        Try

            'setting data variables
            TheVehicleHistoryDataTier = New VehicleHistoryDataTier
            TheVehicleHistoryDataSet = TheVehicleHistoryDataTier.GetVehicleHistoryInformation
            TheVehicleHistoryBindingSource = New BindingSource

            'setting up the binding source
            With TheVehicleHistoryBindingSource
                .DataSource = TheVehicleHistoryDataSet
                .DataMember = "vehiclehistory"
                .MoveFirst()
                .MoveLast()
            End With

            'setting up the combo box
            With cboTransactionID
                .DataSource = TheVehicleHistoryBindingSource
                .DisplayMember = "TransactionID"
                .DataBindings.Add("text", TheVehicleHistoryBindingSource, "TransactionID", False, DataSourceUpdateMode.Never)
            End With

            txtVehicleID.DataBindings.Add("text", TheVehicleHistoryBindingSource, "VehicleID")
            txtBJCNumber.DataBindings.Add("Text", TheVehicleHistoryBindingSource, "BJCNumber")
            txtEmployeeID.DataBindings.Add("text", TheVehicleHistoryBindingSource, "EmployeeID")
            txtWHEmployeeID.DataBindings.Add("Text", TheVehicleHistoryBindingSource, "WarehouseEmployeeID")
            txtDate.DataBindings.Add("text", TheVehicleHistoryBindingSource, "Date")
            txtNotes.DataBindings.Add("Text", TheVehicleHistoryBindingSource, "Notes")
            txtRemoteVehicle.DataBindings.Add("Text", TheVehicleHistoryBindingSource, "RemoteVehicle")

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

                    With TheArchiveVehicleHistoryBindingSource
                        .EndEdit()
                        .AddNew()
                    End With

                    'setting up to add the record
                    addingBoolean = True
                    setComboBoxBinding()
                    cboArchiveTransactionID.Text = cboTransactionID.Text
                    txtArchiveDate.Text = txtDate.Text
                    txtArchiveBJCNumber.Text = txtBJCNumber.Text
                    txtArchiveEmployeeID.Text = txtEmployeeID.Text
                    txtArchiveNotes.Text = txtNotes.Text
                    txtArchiveRemoteVehicle.Text = txtRemoteVehicle.Text
                    txtArchiveVehicleID.Text = txtVehicleID.Text
                    txtArchiveWHEmployeeID.Text = txtWHEmployeeID.Text
                    intNumberOfRecords -= 1
                    blnRecordDeleted = True

                    Try

                        'adding the record
                        TheArchiveVehicleHistoryBindingSource.EndEdit()
                        TheArchiveVehicleHistoryDataTier.UpdateArchiveVehicleHistoryDB(TheArchiveVehicleHistoryDataSet)
                        addingBoolean = False
                        setComboBoxBinding()

                        'removing the record
                        TheVehicleHistoryBindingSource.RemoveCurrent()
                        TheVehicleHistoryDataTier.UpdateDB(TheVehicleHistoryDataSet)

                    Catch ex As Exception
                        MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try

                    If intCounter = intNumberOfRecords Or intCounter > intNumberOfRecords Then
                        Exit For
                    End If

                Else

                    intNumberOfRecords -= 1
                    blnRecordDeleted = True
                    TheVehicleHistoryBindingSource.RemoveCurrent()
                    TheVehicleHistoryDataTier.UpdateDB(TheVehicleHistoryDataSet)

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

            If structArchivedHistory(intStructureCounter).mintTransactionID = CInt(cboTransactionID.Text) Then

                blnDoNotArchive = True

            End If

        Next

        Return blnDoNotArchive

    End Function
End Class