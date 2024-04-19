'Title:         Add Information Technology Device History
'Date:          9/25/14
'Author:        Terry Holmes

'Description:   This form is used to add information technology history

Option Strict On

Public Class AddInformationTechnologyHistory

    'Setting up global data sources
    Private TheInformationTechnologyHistoryDataSet As InformationTechnologyHistoryDataSet
    Private TheInformationTechnologyHistoryDataTier As InformationTechnologyDataTier
    Private WithEvents TheInformationTechnologyHistoryBindingSource As New BindingSource

    Private addingBoolean As Boolean = False
    Private editingBoolean As Boolean = False
    Private previousSelectedIndex As Integer

    Private Sub SetComboBoxBinding()

        'This will set the combo box bindings.
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
   
    Private Sub AddInformationTechnologyHistory_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'This form will load when the form is loaded

        'Setting up the controls
        Try
            TheInformationTechnologyHistoryDataTier = New InformationTechnologyDataTier
            TheInformationTechnologyHistoryDataSet = TheInformationTechnologyHistoryDataTier.GetInformationTechnologyHistoryInformation
            TheInformationTechnologyHistoryBindingSource = New BindingSource

            'Setting up the binding source
            With TheInformationTechnologyHistoryBindingSource
                .DataSource = TheInformationTechnologyHistoryDataSet
                .DataMember = "informationtechnologyhistory"
                .MoveFirst()
                .MoveLast()
            End With

            'Setting up the combo box
            With cboTransactionID
                .DataSource = TheInformationTechnologyHistoryBindingSource
                .DisplayMember = "TransactionID"
                .DataBindings.Add("text", TheInformationTechnologyHistoryBindingSource, "TransactionID", False, DataSourceUpdateMode.Never)
            End With

            'Binding the rest of the controls
            txtDeviceID.DataBindings.Add("text", TheInformationTechnologyHistoryBindingSource, "DeviceID")
            txtDate.DataBindings.Add("text", TheInformationTechnologyHistoryBindingSource, "Date")
            txtEmployeeID.DataBindings.Add("text", TheInformationTechnologyHistoryBindingSource, "EmployeeID")
            txtIssuingEmployeeID.DataBindings.Add("text", TheInformationTechnologyHistoryBindingSource, "IssuingEmployeeID")
            txtNotes.DataBindings.Add("text", TheInformationTechnologyHistoryBindingSource, "Notes")

            'Beginning to add the record
            With TheInformationTechnologyHistoryBindingSource
                .EndEdit()
                .AddNew()
            End With

            addingBoolean = True
            cboTransactionID.Focus()
            SetComboBoxBinding()
            If cboTransactionID.SelectedIndex <> -1 Then
                previousSelectedIndex = cboTransactionID.Items.Count - 1
            Else
                previousSelectedIndex = 0
            End If

            InformationTechnologyID.Show()
            cboTransactionID.Text = CStr(Logon.mintCreatedTransactionID)
            txtDeviceID.Text = CStr(Logon.mintDeviceID)
            txtDate.Text = CStr(Logon.mdatDate)
            txtEmployeeID.Text = CStr(Logon.mintEmployeeID)
            txtIssuingEmployeeID.Text = CStr(Logon.mintWarehouseEmployeeID)
            txtNotes.Text = Logon.mstrNotes

            TheInformationTechnologyHistoryBindingSource.EndEdit()
            TheInformationTechnologyHistoryDataTier.UpdateInformationTechnologyHistoryDB(TheInformationTechnologyHistoryDataSet)
            addingBoolean = False
            editingBoolean = False
            SetComboBoxBinding()

            Me.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
End Class