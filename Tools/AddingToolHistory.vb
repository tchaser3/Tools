'Title:         Tool Sign Out History
'Date:          7/17/13
'Author:        Terry Holmes

'Description:   This program will update the History of the Tools

Option Strict On

Public Class AddingToolHistory

    'Setting Modular Variable
    Private TheToolsHistoryDataSet As ToolsHistoryDataSet
    Private TheToolHistoryDataTier As ToolHistoryDataTier
    Private WithEvents TheToolsHistoryBindingSource As BindingSource

    Private addingBoolean As Boolean = False
    Private editingBoolean As Boolean = False
    Private previousSelectedIndex As Integer
    Dim mintNumuberOfRecords As Integer

    Dim LogDateTime As Date = DateAndTime.Now
    Dim strLogDateTime As String

    Private Sub AddingToolHistory_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim intNumberOfRecords As Integer
        Dim strToolID As String
        Dim intEmployeeID As Integer
        Dim intWarehouseEmployeeID As Integer
        Dim strDate As String
        Dim strAvailablity As String
        Dim strNotes As String
        Dim intCreatedTransactionID As Integer

        'This sub-routine runs when the form is loaded
        Try
            'This will bind the controls to the data source
            TheToolHistoryDataTier = New ToolHistoryDataTier
            TheToolsHistoryDataSet = TheToolHistoryDataTier.GetHistoryInformation
            TheToolsHistoryBindingSource = New BindingSource

            'Setting the binding for the combo box
            With TheToolsHistoryBindingSource
                .DataSource = TheToolsHistoryDataSet
                .DataMember = "toolhistory"
                .MoveFirst()
                .MoveLast()
            End With

            'Binding controls to for the binding for the combo box
            With cboTransactionID
                .DataSource = TheToolsHistoryBindingSource
                .DisplayMember = "TransactionID"
                .DataBindings.Add("text", TheToolsHistoryBindingSource, "TransactionID", False, DataSourceUpdateMode.Never)
            End With

            'Setting the binding for all other textbox controls
            txtEmployeeID.DataBindings.Add("text", TheToolsHistoryBindingSource, "EmployeeID")
            txtDate.DataBindings.Add("text", TheToolsHistoryBindingSource, "Date")
            txtAvailable.DataBindings.Add("text", TheToolsHistoryBindingSource, "Availablity")
            txtNotes.DataBindings.Add("text", TheToolsHistoryBindingSource, "Notes")
            txtToolID.DataBindings.Add("text", TheToolsHistoryBindingSource, "ToolID")
            txtWareHouseEmployeeID.DataBindings.Add("Text", TheToolsHistoryBindingSource, "WarehouseEmployeeID")

        Catch ex As Exception
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        'Getting ready to add the information to the DB

        'Changing the binding sourse
        With TheToolsHistoryBindingSource
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
        mintNumuberOfRecords = cboTransactionID.Items.Count
        intNumberOfRecords = mintNumuberOfRecords + 1000
        intCreatedTransactionID = intNumberOfRecords

        cboTransactionID.Text = CStr(intCreatedTransactionID)

        strToolID = Logon.mstrToolID
        intEmployeeID = CInt(Logon.mintEmployeeID)
        intWarehouseEmployeeID = CInt(Logon.mintEmployeeID)
        strDate = CStr(Logon.mstrLogDateTime)
        strAvailablity = CStr(Logon.mstrAvailability)
        strNotes = CStr(Logon.mstrNotes)

        txtToolID.Text = strToolID
        txtEmployeeID.Text = CStr(intEmployeeID)
        txtWareHouseEmployeeID.Text = CStr(intWarehouseEmployeeID)
        txtDate.Text = strDate
        txtAvailable.Text = strAvailablity
        txtNotes.Text = strNotes


        'Adding a record to the table
        'Updating Database
        Try
            TheToolsHistoryBindingSource.EndEdit()
            TheToolHistoryDataTier.UpdateDB(TheToolsHistoryDataSet)
            addingBoolean = False
            editingBoolean = False
            setComboBoxBinding()
            cboTransactionID.SelectedIndex = previousSelectedIndex

        Catch ex As Exception
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Me.Close()

    End Sub
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
End Class