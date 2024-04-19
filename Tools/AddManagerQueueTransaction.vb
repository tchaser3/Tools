'Title:         Add Entry to Manager Queue
'Date;          2/14/14
'Author:        Terry Holmes

'Description:   This form is used make entries into the Manager Queue

Option Strict On

Public Class AddManagerQueueTransaction

    Dim TheInputDataValidation As New InputDataValidation

    Private addingBoolean As Boolean = False
    Private editingBoolean As Boolean = False
    Private previousSelectedIndex As Integer
    Dim mintNumuberOfRecords As Integer

    Dim LogDateTime As Date = DateAndTime.Now
    Dim strLogDateTime As String

    
    'Setting Up Data Controls
    Private TheManagerQueueDataSet As ManagerQueueDataSet
    Private TheManagerQueueDataTier As CableDataTier
    Private WithEvents TheManagerQueueBindingSource As BindingSource

    Private Sub setComboBoxBinding()

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

    Private Sub AddManagerQueueTransaction_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        Dim intTransactionID As Integer
        Dim intInternalProjectID As Integer
        Dim intTechnicianID As Integer
        Dim intFootagePulled As Integer
        Dim intManagerID As Integer
        Dim strReelID As String
        Dim intWarehouseID As Integer
        Dim intWarehouseEmployeeID As Integer
        Dim strPartNumber As String
        Dim strNotes As String
        Dim datDate As Date

        'Try - Catch for the Manager Queue
        Try

            txtReelID.Visible = True

            'This will bind the controls to the data source
            TheManagerQueueDataTier = New CableDataTier
            TheManagerQueueDataSet = TheManagerQueueDataTier.GetManagerQueueInformation
            TheManagerQueueBindingSource = New BindingSource

            'Setting up Binding Source for the Combo Box
            With TheManagerQueueBindingSource
                .DataSource = TheManagerQueueDataSet
                .DataMember = "managerqueue"
                .MoveFirst()
                .MoveLast()
            End With

            'Setting the data relationship for the Combo Box
            With cboTransactionID
                .DataSource = TheManagerQueueBindingSource
                .DisplayMember = "TransactionID"
                .DataBindings.Add("text", TheManagerQueueBindingSource, "TransactionID", False, DataSourceUpdateMode.Never)
            End With

            'Setting Control bindings
            txtInternalProjectID.DataBindings.Add("text", TheManagerQueueBindingSource, "InternalProjectID")
            txtTechnicianID.DataBindings.Add("text", TheManagerQueueBindingSource, "TechnicianID")
            txtFootagePulled.DataBindings.Add("text", TheManagerQueueBindingSource, "Footage")
            txtManagerID.DataBindings.Add("text", TheManagerQueueBindingSource, "ManagersID")
            txtReelID.DataBindings.Add("Text", TheManagerQueueBindingSource, "ReelID")
            txtWarehouse.DataBindings.Add("text", TheManagerQueueBindingSource, "WarehouseID")
            txtWarehouseEmployeeID.DataBindings.Add("Text", TheManagerQueueBindingSource, "WarehouseEmployeeID")
            txtPartNumber.DataBindings.Add("text", TheManagerQueueBindingSource, "PartNumber")
            txtDate.DataBindings.Add("text", TheManagerQueueBindingSource, "Date")
            txtNotes.DataBindings.Add("text", TheManagerQueueBindingSource, "Note")

        Catch ex As Exception

            'If an exception is thrown, it is rounted here
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        'Try Catch for Loading up the text boxes
        Try

            With TheManagerQueueBindingSource
                .EndEdit()
                .AddNew()
            End With

            'Calling sub-routines and setting call values
            addingBoolean = True
            setComboBoxBinding()
            cboTransactionID.Focus()
            If cboTransactionID.SelectedIndex <> -1 Then
                previousSelectedIndex = cboTransactionID.Items.Count - 1
            Else
                previousSelectedIndex = 0
            End If

            'Setting initial Conditions
            intTransactionID = CInt(IssueCable.mintTransactionID)
            intInternalProjectID = CInt(IssueCable.mintInternalProjectID)
            intTechnicianID = CInt(IssueCable.mintTechnicianID)
            intFootagePulled = CInt(IssueCable.mintFootagePulled)
            intManagerID = CInt(IssueCable.mintManagerID)
            strReelID = CStr(IssueCable.mstrReelID)
            intWarehouseID = CInt(IssueCable.mintWarehouseID)
            intWarehouseEmployeeID = CInt(IssueCable.mintWarehouseEmployeeID)
            datDate = CDate(IssueCable.mdatDate)
            strPartNumber = CStr(IssueCable.mstrPartNumber)
            strNotes = CStr(IssueCable.mstrNotes)

            cboTransactionID.Text = CStr(intTransactionID)
            txtInternalProjectID.Text = CStr(intInternalProjectID)
            txtTechnicianID.Text = CStr(intTechnicianID)
            txtFootagePulled.Text = CStr(intFootagePulled)
            txtManagerID.Text = CStr(intManagerID)
            txtReelID.Text = strReelID
            txtWarehouse.Text = CStr(intWarehouseID)
            txtWarehouseEmployeeID.Text = CStr(intWarehouseEmployeeID)
            txtPartNumber.Text = strPartNumber
            txtDate.Text = CStr(datDate)
            txtNotes.Text = strNotes

            TheManagerQueueBindingSource.EndEdit()
            TheManagerQueueDataTier.UpdateManagerQueueDB(TheManagerQueueDataSet)
            addingBoolean = False
            editingBoolean = False
            setComboBoxBinding()
            cboTransactionID.SelectedIndex = previousSelectedIndex

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

        Me.Close()

    End Sub
End Class