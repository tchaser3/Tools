'Title:         Transfer Fiber
'Date:          1/16/14
'Author:        Terry Holmes

'Description:   This form is used to transfer cable

Option Strict On

Public Class TransferFiber

    Private TheFiberDataSet As FiberDataSet
    Private TheFiberDataTier As CableDataTier
    Private WithEvents TheFiberBindingSource As BindingSource

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


    Private Sub TransferFiber_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim intReelTransactionID As Integer
        Dim strReelID As String
        Dim strPartNumber As String
        Dim strWarehouse As String
        Dim intNumberOfRecords As Integer
        Dim strPartNumberFromTable As String
        Dim strReelIDFromTable As String
        Dim intSelectedIndex As Integer
        Dim blnFatalError As Boolean

        'Try - Catch for Coax
        Try

            'This will bind the controls to the data source
            TheFiberDataTier = New CableDataTier
            TheFiberDataSet = TheFiberDataTier.GetFiberInformation
            TheFiberBindingSource = New BindingSource

            'Setting up Binding Source for the Combo Box
            With TheFiberBindingSource
                .DataSource = TheFiberDataSet
                .DataMember = "fiber"
                .MoveFirst()
                .MoveLast()
            End With

            'Setting the data relationship for the Combo Box
            With cboReelTransactionID
                .DataSource = TheFiberBindingSource
                .DisplayMember = "ReelTransactionID"
                .DataBindings.Add("text", TheFiberBindingSource, "ReelTransactionID", False, DataSourceUpdateMode.Never)
            End With

            'Setting the data binding for the text boxes
            txtReelID.DataBindings.Add("text", TheFiberBindingSource, "ReelID")
            txtTWReelID.DataBindings.Add("text", TheFiberBindingSource, "TWReelID")
            txtPartNumber.DataBindings.Add("text", TheFiberBindingSource, "PartNumber")
            txtCurrentFootage.DataBindings.Add("text", TheFiberBindingSource, "CurrentFootage")
            txtDate.DataBindings.Add("text", TheFiberBindingSource, "Date")
            txtWarehouse.DataBindings.Add("text", TheFiberBindingSource, "Warehouse")
            txtNotes.DataBindings.Add("text", TheFiberBindingSource, "Notes")

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
                TheFiberBindingSource.EndEdit()
                TheFiberDataTier.UpdateFiberDB(TheFiberDataSet)
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