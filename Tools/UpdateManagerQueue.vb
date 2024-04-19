'Title:         Updating Manager Queue
'Date:          5/28/14
'Author:        Terry Holmes

'Description:   Updating Manager Queue

Option Strict On

Public Class UpdateManagerQueue

    Dim TheInputDataValidation As New InputDataValidation

    Private addingBoolean As Boolean = False
    Private editingBoolean As Boolean = False
    Private previousSelectedIndex As Integer
    Dim mintNumuberOfRecords As Integer

    Dim LogDateTime As Date = DateAndTime.Now
    Dim strLogDateTime As String

    'Setting Variables for Issuing Cable
    Private TheIssueCableDataSet As IssueCableDataSet
    Private TheIssueCableDataTier As CableDataTier
    Private WithEvents TheIssueCableBindingSource As BindingSource

    Private TheManagerQueueDataSet As ManagerQueueDataSet
    Private TheManagerQueueDataTier As CableDataTier
    Private WithEvents TheManagerQueueBindingSource As BindingSource

    'Setting local variables
    Dim mintCounter As Integer
    Dim mintNumberOfRecords As Integer
    Dim mstrPartNumberForSearch As String
    Dim mstrPartNumberFromTable As String
    Dim mstrReelIDforSearch As String
    Dim mstrReelIDFromTable As String
    Dim mstrWarehouseForSearch As String
    Dim mstrWarehouseFromTable As String
    Dim mstrIssuedReelFromTable As String
    Dim mblnItemNotFound As Boolean = True
    Dim mintProjectIDForSearch As Integer
    Dim mintProjectIDFromTable As Integer
    Dim mintIssuedCableSelectedIndex As Integer
    Dim mintManagerQueueSelectedIndex As Integer

    Private Sub setComboBoxBinding()

        With Me.cboIssuedTransactionID
            If (addingBoolean Or editingBoolean) Then
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.OnValidation
                .DropDownStyle = ComboBoxStyle.Simple
            Else
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.Never
                .DropDownStyle = ComboBoxStyle.DropDownList
            End If
        End With
    End Sub
    Private Sub UpdateManagerQueue_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Setting local variables
        Dim intFootagePulled As Integer

        Try

            txtIssuedReelID.Visible = True

            'This will bind the controls to the data source
            TheIssueCableDataTier = New CableDataTier
            TheIssueCableDataSet = TheIssueCableDataTier.GetIssueCableInformation
            TheIssueCableBindingSource = New BindingSource

            'Setting up Binding Source for the Combo Box
            With TheIssueCableBindingSource
                .DataSource = TheIssueCableDataSet
                .DataMember = "issuecable"
                .MoveFirst()
                .MoveLast()
            End With

            'Setting the data relationship for the Combo Box
            With cboIssuedTransactionID
                .DataSource = TheIssueCableBindingSource
                .DisplayMember = "TransactionID"
                .DataBindings.Add("text", TheIssueCableBindingSource, "TransactionID", False, DataSourceUpdateMode.Never)
            End With

            'Setting Control bindings
            txtIssuedInternalProjectID.DataBindings.Add("text", TheIssueCableBindingSource, "InternalProjectID")
            txtIssuedManagerID.DataBindings.Add("text", TheIssueCableBindingSource, "ManagersID")
            txtIssuedReelID.DataBindings.Add("Text", TheIssueCableBindingSource, "ReelID")
            txtIssuedWarehouse.DataBindings.Add("text", TheIssueCableBindingSource, "WarehouseID")
            txtIssuedPartNumber.DataBindings.Add("text", TheIssueCableBindingSource, "PartNumber")
            txtIssuedReel.DataBindings.Add("text", TheIssueCableBindingSource, "IssuedReel")

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        'Try Catch for Manager Queue
        Try
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
            With cboQueueTransactionID
                .DataSource = TheManagerQueueBindingSource
                .DisplayMember = "TransactionID"
                .DataBindings.Add("text", TheManagerQueueBindingSource, "TransactionID", False, DataSourceUpdateMode.Never)
            End With

            'Setting Control bindings
            txtQueueProjectID.DataBindings.Add("text", TheManagerQueueBindingSource, "InternalProjectID")
            txtQueueFootagePulled.DataBindings.Add("text", TheManagerQueueBindingSource, "Footage")
            txtQueueManagerID.DataBindings.Add("text", TheManagerQueueBindingSource, "ManagersID")
            txtQueueReelID.DataBindings.Add("Text", TheManagerQueueBindingSource, "ReelID")
            txtQueueWarehouse.DataBindings.Add("text", TheManagerQueueBindingSource, "WarehouseID")
            txtQueuePartNumber.DataBindings.Add("text", TheManagerQueueBindingSource, "PartNumber")

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        'Subroutine to Find Issuing Transaction

        'Setting Variables for Search
        mintNumberOfRecords = cboIssuedTransactionID.Items.Count - 1
        mstrReelIDforSearch = Logon.mstrReelID
        mstrPartNumberForSearch = Logon.mstrPartNumber
        mstrWarehouseForSearch = Logon.mstrWarehouse
        mintCounter = 0

        'Loop to Search for Issuing transaction
        For Me.mintCounter = 0 To mintNumberOfRecords

            cboIssuedTransactionID.SelectedIndex = mintCounter
            mstrPartNumberFromTable = txtIssuedPartNumber.Text
            mstrReelIDFromTable = txtIssuedReelID.Text
            mstrIssuedReelFromTable = txtIssuedReel.Text
            mstrWarehouseFromTable = txtIssuedWarehouse.Text

            If mstrIssuedReelFromTable = "YES" Then
                If mstrPartNumberForSearch = mstrPartNumberFromTable Then
                    If mstrReelIDforSearch = mstrReelIDFromTable Then
                        If mstrWarehouseForSearch = mstrWarehouseFromTable Then

                            mintProjectIDForSearch = CInt(txtIssuedInternalProjectID.Text)
                            mintIssuedCableSelectedIndex = mintCounter

                        End If
                    End If
                End If
            End If

        Next

        cboIssuedTransactionID.SelectedIndex = mintIssuedCableSelectedIndex

        'Setting up loop for the Manager Queue
        mintNumberOfRecords = cboQueueTransactionID.Items.Count - 1

        For Me.mintCounter = 0 To mintNumberOfRecords

            cboQueueTransactionID.SelectedIndex = mintCounter
            mstrPartNumberFromTable = txtQueuePartNumber.Text
            mstrReelIDFromTable = txtQueueReelID.Text
            mintProjectIDFromTable = CInt(txtQueueProjectID.Text)
            mstrWarehouseFromTable = txtQueueWarehouse.Text


            If mstrPartNumberForSearch = mstrPartNumberFromTable Then
                If mstrReelIDforSearch = mstrReelIDFromTable Then
                    If mstrIssuedReelFromTable = "YES" Then
                        If mstrWarehouseForSearch = mstrWarehouseFromTable Then
                            If mintProjectIDForSearch = mintProjectIDFromTable Then

                                mintManagerQueueSelectedIndex = mintCounter

                            End If
                        End If
                    End If

                End If
            End If

        Next

        'Setting the queue variables
        cboQueueTransactionID.SelectedIndex = mintManagerQueueSelectedIndex
        intFootagePulled = CInt(txtQueueFootagePulled.Text)

        If Logon.mintCurrentFootage > intFootagePulled Then
            Logon.mbolFatalError = True
        Else
            intFootagePulled = intFootagePulled - Logon.mintCurrentFootage
            txtQueueFootagePulled.Text = CStr(intFootagePulled)

            'Try Catch to update the Data Base
            Try
                TheManagerQueueBindingSource.EndEdit()
                TheManagerQueueDataTier.UpdateManagerQueueDB(TheManagerQueueDataSet)
                addingBoolean = False
                editingBoolean = False
                setComboBoxBinding()
                cboQueueTransactionID.SelectedIndex = previousSelectedIndex
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If

        Me.Close()

    End Sub
    
End Class