'Title:         Adding Vehicle History
'Date:          7/23/13
'Author:        Terry Holmes
'Description:   This program will update the Vehicle History

Option Strict On

Public Class AddingVehicleHistory

    'Setting Modular Variable
    Private TheVehicleHistoryDataSet As VehicleHistoryDataSet
    Private TheVehicleHistoryDataTier As VehicleHistoryDataTier
    Private WithEvents TheVehicleHistoryBindingSource As BindingSource

    Private addingBoolean As Boolean = False
    Private editingBoolean As Boolean = False
    Private previousSelectedIndex As Integer
    Dim mintNumuberOfRecords As Integer

    Dim LogDateTime As Date = DateAndTime.Now
    Dim strLogDateTime As String

    Private Sub AddingVehicleHistory_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim intNumberOfRecords As Integer
        Dim intVehicleID As Integer
        Dim intEmployeeID As Integer
        Dim intWarehouseEmployeeID As Integer
        Dim strDate As String
        Dim strNotes As String
        Dim intCreatedTransactionID As Integer
        Dim intBJCNumber As Integer

        'This sub-routine runs when the form is loaded
        Try
            'This will bind the controls to the data source
            TheVehicleHistoryDataTier = New VehicleHistoryDataTier
            TheVehicleHistoryDataSet = TheVehicleHistoryDataTier.GetVehicleHistoryInformation
            TheVehicleHistoryBindingSource = New BindingSource

            'Setting the binding for the combo box
            With TheVehicleHistoryBindingSource
                .DataSource = TheVehicleHistoryDataSet
                .DataMember = "vehiclehistory"
                .MoveFirst()
                .MoveLast()
            End With

            'Binding controls to for the binding for the combo box
            With cboTransactionID
                .DataSource = TheVehicleHistoryBindingSource
                .DisplayMember = "TransactionID"
                .DataBindings.Add("text", TheVehicleHistoryBindingSource, "TransactionID", False, DataSourceUpdateMode.Never)
            End With

            'Setting the binding for all other textbox controls
            txtEmployeeID.DataBindings.Add("text", TheVehicleHistoryBindingSource, "EmployeeID")
            txtDate.DataBindings.Add("text", TheVehicleHistoryBindingSource, "Date")
            txtNotes.DataBindings.Add("text", TheVehicleHistoryBindingSource, "Notes")
            txtWareHouseEmployeeID.DataBindings.Add("Text", TheVehicleHistoryBindingSource, "WarehouseEmployeeID")
            txtVehicleID.DataBindings.Add("Text", TheVehicleHistoryBindingSource, "VehicleID")
            txtBJCNumber.DataBindings.Add("Text", TheVehicleHistoryBindingSource, "BJCNumber")
            txtRemoteVehicle.DataBindings.Add("text", TheVehicleHistoryBindingSource, "RemoteVehicle")

        Catch ex As Exception
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        'Getting ready to add the information to the DB

        'Changing the binding sourse
        With TheVehicleHistoryBindingSource
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
        intNumberOfRecords = mintNumuberOfRecords + 1002
        intCreatedTransactionID = intNumberOfRecords

        cboTransactionID.Text = CStr(intCreatedTransactionID)

        intVehicleID = CInt(Logon.mintVehicleID)
        intEmployeeID = CInt(Logon.mintHistoryEmployeeID)
        intWarehouseEmployeeID = CInt(Logon.mintEmployeeID)
        strDate = CStr(Logon.mstrLogDateTime)
        strNotes = CStr(Logon.mstrNotes)
        intBJCNumber = CInt(Logon.mintBJCNumber)

        txtVehicleID.Text = CStr(intVehicleID)
        txtBJCNumber.Text = CStr(intBJCNumber)
        txtEmployeeID.Text = CStr(intEmployeeID)
        txtWareHouseEmployeeID.Text = CStr(intWarehouseEmployeeID)
        txtDate.Text = strDate
        txtNotes.Text = strNotes
        txtRemoteVehicle.Text = Logon.mstrRemoteVehicle


        'Adding a record to the table
        'Updating Database
        Try
            TheVehicleHistoryBindingSource.EndEdit()
            TheVehicleHistoryDataTier.UpdateDB(TheVehicleHistoryDataSet)
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