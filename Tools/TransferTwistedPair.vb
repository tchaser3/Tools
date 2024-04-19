'Title:         Transfer Twisted Pair
'Date:          1/20/14
'Author:        Terry Holmes

'Description:   This form is used to transfer twisted pair 

Option Strict On

Public Class TransferTwistedPair

    Private TheTwistedPairDataSet As TwistedPairDataSet
    Private TheTwistedPairDataTier As CableDataTier
    Private WithEvents TheTwistedPairBindingSource As BindingSource

    Dim TheInputDataValidation As New InputDataValidation

    Private addingBoolean As Boolean = False
    Private editingBoolean As Boolean = False
    Private previousSelectedIndex As Integer
    Dim mintNumuberOfRecords As Integer

    Dim LogDateTime As Date = DateAndTime.Now
    Dim strLogDateTime As String

    'Setting global variable
    Dim mintSelectedIndex(100) As Integer
    Dim mintSelectedIndexCounter As Integer = 0
    Dim mintSelectedIndexUpperLimit As Integer

    Dim mintEmployeeComboBoxUpperLimit As Integer = 0

    Dim mintReelTransactionID As Integer

    Private Sub setComboBoxBinding()

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

    Private Sub TransferTwistedPair_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim intReelTransactionID As Integer
        Dim strReelID As String
        Dim strPartNumber As String
        Dim strWarehouse As String
        Dim strPartNumberFromTable As String
        Dim strReelIDFromTable As String
        Dim intSelectedIndex As Integer
        Dim intNumberOfRecords As Integer
        Dim blnFatalError As Boolean = True

        'Try - Catch for Speciality Cable
        Try

            'This will bind the controls to the data source
            TheTwistedPairDataTier = New CableDataTier
            TheTwistedPairDataSet = TheTwistedPairDataTier.GetTwistedPairInformation
            TheTwistedPairBindingSource = New BindingSource

            'Setting up Binding Source for the Combo   
            With TheTwistedPairBindingSource
                .DataSource = TheTwistedPairDataSet
                .DataMember = "twistedpair"
                .MoveFirst()
                .MoveLast()
            End With

            'Setting the data relationship for the Combo Box
            With cboReelTransactionID
                .DataSource = TheTwistedPairBindingSource
                .DisplayMember = "ReelTransactionID"
                .DataBindings.Add("text", TheTwistedPairBindingSource, "ReelTransactionID", False, DataSourceUpdateMode.Never)
            End With

            'Setting the data binding for the text boxes
            txtReelID.DataBindings.Add("text", TheTwistedPairBindingSource, "ReelID")
            txtPartNumber.DataBindings.Add("text", TheTwistedPairBindingSource, "PartNumber")
            txtCurrentFootage.DataBindings.Add("text", TheTwistedPairBindingSource, "CurrentFootage")
            txtDate.DataBindings.Add("text", TheTwistedPairBindingSource, "Date")
            txtWarehouse.DataBindings.Add("text", TheTwistedPairBindingSource, "Warehouse")
            txtNotes.DataBindings.Add("text", TheTwistedPairBindingSource, "Notes")

        Catch ex As Exception

            'If an exception is thrown, it is rounted here
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        'Beginning search for part number
        strPartNumber = CStr(Logon.mstrCablePartNumber)
        strReelID = CStr(Logon.mstrReelID)
        strWarehouse = CStr(Logon.mstrWarehouse)
        intReelTransactionID = CInt(mintReelTransactionID)

        intNumberOfRecords = cboReelTransactionID.Items.Count - 1

        For intcounter = 0 To intNumberOfRecords

            cboReelTransactionID.SelectedIndex = intcounter
            strPartNumberFromTable = txtPartNumber.Text
            strReelIDFromTable = CStr(txtReelID.Text)

            If strPartNumber = strPartNumberFromTable And strReelID = strReelIDFromTable Then
                intSelectedIndex = intcounter
                blnFatalError = False
            End If

        Next

        If blnFatalError = True Then
            Logon.mbolFatalError = True
            Me.Close()
        End If

        If blnFatalError = False Then

            cboReelTransactionID.SelectedIndex = intSelectedIndex

            txtWarehouse.Text = strWarehouse

            Try

                TheTwistedPairBindingSource.EndEdit()
                TheTwistedPairDataTier.UpdateTwistedPairDB(TheTwistedPairDataSet)
                addingBoolean = False
                editingBoolean = False
                setComboBoxBinding()
                cboReelTransactionID.SelectedIndex = previousSelectedIndex

            Catch ex As Exception

                MessageBox.Show(ex.Message, "There is an error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try
        End If

        Me.Close()

    End Sub
End Class