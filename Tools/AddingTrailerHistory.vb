'Title:         Adding Trailer History
'Date:          3/24/14
'Author:        Terry Holmes

'Description:   This form is used to Add trailer History

Option Strict On

Public Class AddingTrailerHistory

    Private TheTrailerHistoryDataSet As TrailerHistoryDataSet
    Private TheTrailerHistoryDataTier As TrailerHistoryDataTier
    Private WithEvents TheTrailerHistoryBindingSource As BindingSource

    Private addingBoolean As Boolean = False
    Private editingBoolean As Boolean = False
    Private previousSelectedIndex As Integer
    Dim mintNumberOfRecords As Integer

    Dim LogDateTime As Date = DateAndTime.Now
    Dim strLogDateTime As String

    Private Sub setComboBoxBinding()

        'This sub-routine sets and changes the combo box binding
        With Me.cboTransactionID
            If (addingBoolean Or editingBoolean) Then
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.OnValidation
                .DropDownStyle = ComboBoxStyle.Simple
            Else
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.Never
                .DropDownStyle = ComboBoxStyle.DropDownList
            End If
        End With

    End Sub

    Private Sub AddingTrailerHistory_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim intNumberOfRecords As Integer
        Dim intTrailerID As Integer
        Dim intEmployeeID As Integer
        Dim intWarehouseEmployeeID As Integer
        Dim strDate As String
        Dim strNotes As String
        Dim intCreatedTransactionID As Integer
        Dim intBJCNumber As Integer

        'This sub-routine runs when the form is loaded
        Try
            'This will bind the controls to the data source
            TheTrailerHistoryDataTier = New TrailerHistoryDataTier
            TheTrailerHistoryDataSet = TheTrailerHistoryDataTier.GetTrailerHistoryInformation
            TheTrailerHistoryBindingSource = New BindingSource

            'Setting the binding for the combo box
            With TheTrailerHistoryBindingSource
                .DataSource = TheTrailerHistoryDataSet
                .DataMember = "trailerhistory"
                .MoveFirst()
                .MoveLast()
            End With

            'Binding controls to for the binding for the combo box
            With cboTransactionID
                .DataSource = TheTrailerHistoryBindingSource
                .DisplayMember = "TransactionID"
                .DataBindings.Add("text", TheTrailerHistoryBindingSource, "TransactionID", False, DataSourceUpdateMode.Never)
            End With

            'Setting the binding for all other textbox controls
            txtEmployeeID.DataBindings.Add("text", TheTrailerHistoryBindingSource, "EmployeeID")
            txtDate.DataBindings.Add("text", TheTrailerHistoryBindingSource, "Date")
            txtNotes.DataBindings.Add("text", TheTrailerHistoryBindingSource, "Notes")
            txtWareHouseEmployeeID.DataBindings.Add("Text", TheTrailerHistoryBindingSource, "WarehouseEmployeeID")
            txtTrailerID.DataBindings.Add("Text", TheTrailerHistoryBindingSource, "TrailerID")
            txtBJCNumber.DataBindings.Add("Text", TheTrailerHistoryBindingSource, "BJCNumber")

        Catch ex As Exception
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        'Getting ready to add the information to the DB

        'Changing the binding sourse
        With TheTrailerHistoryBindingSource
            .EndEdit()
            .AddNew()
        End With

        'Calls and setting values to sub-routines
        addingBoolean = True
        setComboBoxBinding()

        'Setting the combo box focus
        cboTransactionID.Focus()

        If cboTransactionID.SelectedIndex <> -1 Then
            previousSelectedIndex = cboTransactionID.Items.Count - 1
        Else
            previousSelectedIndex = 0
        End If

        'Setting up fields with auto-data to avoid having the user do it.
        mintNumberOfRecords = cboTransactionID.Items.Count
        intNumberOfRecords = mintNumberOfRecords + 1002
        intCreatedTransactionID = intNumberOfRecords

        cboTransactionID.Text = CStr(intCreatedTransactionID)

        intTrailerID = CInt(Logon.mintTrailerID)
        intEmployeeID = CInt(Logon.mintHistoryEmployeeID)
        intWarehouseEmployeeID = CInt(Logon.mintEmployeeID)
        strDate = CStr(Logon.mstrLogDateTime)
        strNotes = CStr(Logon.mstrNotes)
        intBJCNumber = CInt(Logon.mintBJCNumber)
        strLogDateTime = CStr(LogDateTime)

        txtTrailerID.Text = CStr(intTrailerID)
        txtBJCNumber.Text = CStr(intBJCNumber)
        txtEmployeeID.Text = CStr(intEmployeeID)
        txtWareHouseEmployeeID.Text = CStr(intWarehouseEmployeeID)
        txtDate.Text = strDate
        txtNotes.Text = strNotes
        txtDate.Text = strLogDateTime

        'Adding a record to the table
        'Updating Database
        Try
            TheTrailerHistoryBindingSource.EndEdit()
            TheTrailerHistoryDataTier.UpdateDB(TheTrailerHistoryDataSet)
            addingBoolean = False
            editingBoolean = False
            setComboBoxBinding()
            cboTransactionID.SelectedIndex = previousSelectedIndex

        Catch ex As Exception
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Me.Close()

    End Sub
End Class