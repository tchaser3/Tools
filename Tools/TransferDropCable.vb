'Title:         Transfer Drop Cable
'Date:          1/20/14
'Author:        Terry Holmes

'Description:   This form is used to transfer Drop Cable

Option Strict On

Public Class TransferDropCable

    Private TheDropCableDataSet As DropCableDataSet
    Private TheDropCableDataTier As CableDataTier
    Private WithEvents TheDropCableBindingSource As BindingSource

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

    Private Sub TransferDropCable_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim intReelTransactionID As Integer
        Dim strReelID As String
        Dim strPartNumber As String
        Dim strWarehouse As String
        Dim strPartNumberFromTable As String
        Dim strReelIDFromTable As String
        Dim intSelectedIndex As Integer
        Dim intNumberOfRecords As Integer
        Dim blnFatalError As Boolean = True

        'Try - Catch for Coax
        Try

            'This will bind the controls to the data source
            TheDropCableDataTier = New CableDataTier
            TheDropCableDataSet = TheDropCableDataTier.GetDropCableInformation
            TheDropCableBindingSource = New BindingSource

            'Setting up Binding Source for the Combo   
            With TheDropCableBindingSource
                .DataSource = TheDropCableDataSet
                .DataMember = "dropcable"
                .MoveFirst()
                .MoveLast()
            End With

            'Setting the data relationship for the Combo Box
            With cboReelTransactionID
                .DataSource = TheDropCableBindingSource
                .DisplayMember = "ReelTransactionID"
                .DataBindings.Add("text", TheDropCableBindingSource, "ReelTransactionID", False, DataSourceUpdateMode.Never)
            End With

            'Setting the data binding for the text boxes
            txtReelID.DataBindings.Add("text", TheDropCableBindingSource, "ReelID")
            txtPartNumber.DataBindings.Add("text", TheDropCableBindingSource, "PartNumber")
            txtCurrentFootage.DataBindings.Add("text", TheDropCableBindingSource, "CurrentFootage")
            txtDate.DataBindings.Add("text", TheDropCableBindingSource, "Date")
            txtWarehouse.DataBindings.Add("text", TheDropCableBindingSource, "Warehouse")
            txtNotes.DataBindings.Add("text", TheDropCableBindingSource, "Notes")

        Catch ex As Exception

            'If an exception is thrown, it is rounted here
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        'Beginning Search for part number
        strPartNumber = CStr(Logon.mstrCablePartNumber)
        strReelID = CStr(Logon.mstrReelID)
        strWarehouse = CStr(Logon.mstrWarehouse)
        intReelTransactionID = CInt(mintReelTransactionID)

        intNumberOfRecords = cboReelTransactionID.Items.Count - 1

        'For Loop to find Part Number and Reel ID
        For intCounter = 0 To intNumberOfRecords

            cboReelTransactionID.SelectedIndex = intCounter
            strPartNumberFromTable = txtPartNumber.Text
            strReelIDFromTable = CStr(txtReelID.Text)

            If strPartNumber = strPartNumberFromTable And strReelID = strReelIDFromTable Then
                intSelectedIndex = intCounter
                blnFatalError = False
            End If
        Next

        If blnFatalError = True Then
            Logon.mbolFatalError = True

        End If

        If blnFatalError = False Then

            cboReelTransactionID.SelectedIndex = intSelectedIndex

            txtWarehouse.Text = strWarehouse

            Try
                TheDropCableBindingSource.EndEdit()
                TheDropCableDataTier.UpdateDropCableDB(TheDropCableDataSet)
                addingBoolean = False
                editingBoolean = False
                setComboBoxBinding()
                cboReelTransactionID.SelectedIndex = previousSelectedIndex

            Catch ex As Exception
                MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If

        Me.Close()

    End Sub
End Class