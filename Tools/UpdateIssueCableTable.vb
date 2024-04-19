'Title:         Updating The Issue Tables
'Date:          6/16/14
'Author:        Terry Holmes

'Description:   This will update all the different usage tables

Option Strict On

Public Class UpdateIssueCableTable

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

        With Me.cboReelTransactionID
            If (addingBoolean Or editingBoolean) Then
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.OnValidation
                .DropDownStyle = ComboBoxStyle.Simple
            Else
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.Never
                .DropDownStyle = ComboBoxStyle.DropDownList
            End If
        End With
    End Sub

    Private Sub UpdateIssueCableTable_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim intIssueCounter As Integer
        Dim intIssueNumberOfRecords As Integer
        Dim strCategory As String = ""
        Dim strPartNumberForSearch As String
        Dim strPartNumberFromTable As String
        Dim strReelIDForSearch As String
        Dim strReelIDfromTable As String
        Dim strReelIssued As String
        Dim intWarehouseIDForSearch As Integer
        Dim intWarehouseIDFromTable As Integer
        Dim intReturnFootage As Integer
        Dim intCurrentFootage As Integer
        Dim intFootageDifference As Integer
        Dim intSelectedIndex As Integer

        'Try Catch for Issue Cable
        Try

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
            With cboTransactionID
                .DataSource = TheIssueCableBindingSource
                .DisplayMember = "TransactionID"
                .DataBindings.Add("text", TheIssueCableBindingSource, "TransactionID", False, DataSourceUpdateMode.Never)
            End With

            'Setting Control bindings
            txtInternalProjectID.DataBindings.Add("text", TheIssueCableBindingSource, "InternalProjectID")
            txtTechnicianID.DataBindings.Add("text", TheIssueCableBindingSource, "TechnicianID")
            txtFootagePulled.DataBindings.Add("text", TheIssueCableBindingSource, "FootagePulled")
            txtManagerID.DataBindings.Add("text", TheIssueCableBindingSource, "ManagersID")
            txtReelID.DataBindings.Add("Text", TheIssueCableBindingSource, "ReelID")
            txtWarehouse.DataBindings.Add("text", TheIssueCableBindingSource, "WarehouseID")
            txtWarehouseEmployeeID.DataBindings.Add("Text", TheIssueCableBindingSource, "WarehouseEmployeeID")
            txtPartNumber.DataBindings.Add("text", TheIssueCableBindingSource, "PartNumber")
            txtDate.DataBindings.Add("text", TheIssueCableBindingSource, "Date")
            txtIssuedReel.DataBindings.Add("text", TheIssueCableBindingSource, "IssuedReel")
            txtNotes.DataBindings.Add("text", TheIssueCableBindingSource, "Notes")

            'Setting up the search for the transaction
            intIssueNumberOfRecords = cboTransactionID.Items.Count - 1
            strPartNumberForSearch = Logon.mstrPartNumber
            strReelIDForSearch = Logon.mstrReelID
            intWarehouseIDForSearch = CInt(Logon.mstrWarehouse)
            intReturnFootage = CInt(Logon.mintCurrentFootage)
            strCategory = Logon.mstrCategory

            For intIssueCounter = 0 To intIssueNumberOfRecords

                cboTransactionID.SelectedIndex = intIssueCounter
                strPartNumberFromTable = txtPartNumber.Text
                strReelIDfromTable = txtReelID.Text
                intWarehouseIDFromTable = CInt(txtWarehouse.Text)
                strReelIssued = txtIssuedReel.Text

                If intWarehouseIDForSearch = intWarehouseIDFromTable Then
                    If strPartNumberForSearch = strPartNumberFromTable Then
                        If strReelIDForSearch = strReelIDfromTable Then
                            If strReelIssued = "YES" Then
                                intSelectedIndex = intIssueCounter
                            End If
                        End If
                    End If
                End If
            Next

            cboTransactionID.SelectedIndex = intSelectedIndex

            txtIssuedReel.Text = "NO"
            intCurrentFootage = CInt(txtFootagePulled.Text)
            intFootageDifference = intCurrentFootage - intReturnFootage
            editingBoolean = True
            txtFootagePulled.Text = CStr(intFootageDifference)

            'Try Catch to update the database
            Try
                TheIssueCableBindingSource.EndEdit()
                TheIssueCableDataTier.UpdateIssueCableDB(TheIssueCableDataSet)
                editingBoolean = False
                cboTransactionID.SelectedIndex = previousSelectedIndex
            Catch ex As Exception
                MessageBox.Show(ex.Message, "There is a Problem", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            Me.Close()

        Catch ex As Exception

            'If an exception is thrown, it is rounted here
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Me.Close()

    End Sub
End Class