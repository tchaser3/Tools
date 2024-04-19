'Title:         Add Information Technology Accessory History
'Date:          10/13/14
'Author:        Terry Holmes

'Description:   This form will allow the user to add Information Technology Accessory History

Option Strict On

Public Class AddInformationTechnologyAccessoryHistory

    'Setting up the global variables
    Private addingBoolean As Boolean = False
    Private editingBoolean As Boolean = False
    Private previousSelectedIndex As Integer

    'Setting up the global data set
    Private TheInformationTechnologyAccessoryHistoryDataSet As InformationTechnologyAccessoryHistoryDataSet
    Private TheInformationTechnologyAccessoryHistoryDataTier As InformationTechnologyDataTier
    Private WithEvents TheInformationTechnologyAccessoryHistoryBindingSource As BindingSource

    Private Sub SetComboBoxBinding()

        'Setting the combo box binding source
        With cboTransactionID
            If (addingBoolean Or editingBoolean) Then
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.OnValidation
                .DropDownStyle = ComboBoxStyle.Simple
            Else
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.Never
                .DropDownStyle = ComboBoxStyle.DropDownList
            End If
        End With

    End Sub

    Private Sub AddInformationTechnologyAccessoryHistory_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'This will load the form

        'Try Catch for the load
        Try

            'Binding Controls
            TheInformationTechnologyAccessoryHistoryDataTier = New InformationTechnologyDataTier
            TheInformationTechnologyAccessoryHistoryDataSet = TheInformationTechnologyAccessoryHistoryDataTier.GetInformationTechnologyAccessoryHistoryInformation
            TheInformationTechnologyAccessoryHistoryBindingSource = New BindingSource

            'Setting up the binding source
            With TheInformationTechnologyAccessoryHistoryBindingSource
                .DataSource = TheInformationTechnologyAccessoryHistoryDataSet
                .DataMember = "informationtechnologyaccessoryhistory"
                .MoveFirst()
                .MoveLast()
            End With

            'Setting up the combo box
            With cboTransactionID
                .DataSource = TheInformationTechnologyAccessoryHistoryBindingSource
                .DisplayMember = "TransactionID"
                .DataBindings.Add("text", TheInformationTechnologyAccessoryHistoryBindingSource, "TransactionID", False, DataSourceUpdateMode.Never)
            End With

            'Binding the rest of the controls
            txtAccessoryID.DataBindings.Add("text", TheInformationTechnologyAccessoryHistoryBindingSource, "AccessoryID")
            txtDeviceID.DataBindings.Add("text", TheInformationTechnologyAccessoryHistoryBindingSource, "DeviceID")
            txtDate.DataBindings.Add("text", TheInformationTechnologyAccessoryHistoryBindingSource, "Date")
            txtEmployeeID.DataBindings.Add("text", TheInformationTechnologyAccessoryHistoryBindingSource, "EmployeeID")
            txtIssuingEmployeeID.DataBindings.Add("text", TheInformationTechnologyAccessoryHistoryBindingSource, "IssuingEmployeeID")
            txtNotes.DataBindings.Add("text", TheInformationTechnologyAccessoryHistoryBindingSource, "Notes")

            'Beginning to add the record
            With TheInformationTechnologyAccessoryHistoryBindingSource
                .EndEdit()
                .AddNew()
            End With

            'Setting up to add a record
            addingBoolean = True
            SetComboBoxBinding()
            cboTransactionID.Focus()
            If cboTransactionID.SelectedIndex <> -1 Then
                previousSelectedIndex = cboTransactionID.Items.Count - 1
            Else
                previousSelectedIndex = 0
            End If

            'Setting data in the controls
            InformationTechnologyID.Show()
            cboTransactionID.Text = CStr(Logon.mintCreatedTransactionID)
            txtAccessoryID.Text = CStr(Logon.mintAccessoryID)
            txtDeviceID.Text = CStr(Logon.mintDeviceID)
            txtDate.Text = CStr(Logon.mdatDate)
            txtEmployeeID.Text = CStr(Logon.mintEmployeeID)
            txtIssuingEmployeeID.Text = CStr(Logon.mintWarehouseEmployeeID)
            txtNotes.Text = Logon.mstrNotes

            'Upating the data set
            TheInformationTechnologyAccessoryHistoryBindingSource.EndEdit()
            TheInformationTechnologyAccessoryHistoryDataTier.UpdateInformationTechnologyAccessoryHistoryDB(TheInformationTechnologyAccessoryHistoryDataSet)
            addingBoolean = False
            editingBoolean = False
            SetComboBoxBinding()
            cboTransactionID.SelectedIndex = previousSelectedIndex

            Me.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
End Class