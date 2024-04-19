'Title:         Hand Coil Transaction ID
'Date:          9/8/14
'Author:        Terry Holmes

'Description:   This form is used to create the ID for all Hand Coil Functions

Option Strict On

Public Class HandCoilTransactionID

    'Setting Global Variables
    Private TheHandCoilTransactionIDDataSet As HandCoilTransactionIDDataSet
    Private TheHandCoilTransactionIDDataTier As CableDataTier
    Private WithEvents TheHandCoilTransactionIDBindingSource As BindingSource

    Private addingBoolean As Boolean = False
    Private editingBoolean As Boolean = False
    Private previouseSelectedIndex As Integer

    Private Sub SetComboBoxBinding()

        'Setting the Combo Box bindings.
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

    Private Sub HandCoilTransactionID_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'This sub routine is used to load up the form

        'Setting Local Variables
        Dim intNumberOfRecords As Integer
        Dim intTransactionID As Integer

        Try
            'Setting up for the Data
            TheHandCoilTransactionIDDataTier = New CableDataTier
            TheHandCoilTransactionIDDataSet = TheHandCoilTransactionIDDataTier.GetHandCoilTransactionIDInformation
            TheHandCoilTransactionIDBindingSource = New BindingSource

            'Setting up the binding souce
            With TheHandCoilTransactionIDBindingSource
                .DataSource = TheHandCoilTransactionIDDataSet
                .DataMember = "handcoiltransactionid"
                .MoveFirst()
                .MoveLast()
            End With

            'Setting the combo box
            With cboTransactionID
                .DataSource = TheHandCoilTransactionIDBindingSource
                .DisplayMember = "TransactionID"
                .DataBindings.Add("text", TheHandCoilTransactionIDBindingSource, "TransactionID", False, DataSourceUpdateMode.Never)
            End With

            'Binding the text box
            txtCreatedID.DataBindings.Add("text", TheHandCoilTransactionIDBindingSource, "CreatedID")

            'Beginning the proceedure to create a transaction ID
            intNumberOfRecords = cboTransactionID.Items.Count
            intTransactionID = intNumberOfRecords + 1000

            'Creating the new record
            With TheHandCoilTransactionIDBindingSource
                .EndEdit()
                .AddNew()
            End With

            addingBoolean = True
            SetComboBoxBinding()
            cboTransactionID.Focus()
            If cboTransactionID.SelectedIndex <> -1 Then
                previouseSelectedIndex = cboTransactionID.Items.Count - 1
            Else
                previouseSelectedIndex = 0
            End If

            'Placing items within the controls
            cboTransactionID.Text = CStr(intTransactionID)
            txtCreatedID.Text = CStr(intTransactionID)
            Logon.mintCreatedTransactionID = CInt(intTransactionID)

            TheHandCoilTransactionIDBindingSource.EndEdit()
            TheHandCoilTransactionIDDataTier.UpdateHandCoilTransactionIDDB(TheHandCoilTransactionIDDataSet)
            addingBoolean = False
            editingBoolean = False
            SetComboBoxBinding()
            Me.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End Try

    End Sub
End Class