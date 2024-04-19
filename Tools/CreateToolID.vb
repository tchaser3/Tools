'Title:     Tool ID Creation and Verification
'Date:      4/16/13
'Author:    Terry Holmes

Option Strict On

Public Class CreateToolID

    'Creating Modular Variables
    Private TheToolIDCheckDataSet As ToolIDCheckDataSet
    Private TheToolIDCheckDataTier As ToolIDCheckDataTier
    Private WithEvents TheToolIDCheckBindingSource As BindingSource

    Private addingBoolean As Boolean = False
    Private editingBoolean As Boolean = False
    Private previousSelectedIndex As Integer
    Dim mintNumuberOfRecords As Integer

    Dim LogDateTime As Date = DateAndTime.Now
    Dim strLogDateTime As String

    'Creating Global Variable
    Friend mintToolID As Integer
    Friend mintToolIDFromForm As Integer = 0


    Private Sub CreateToolID_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        'Setting Local Variables
        Dim intNewID As Integer

        'Try - Catch to catch a thrown exception
        Try

            'This will bind the controls to the data source
            TheToolIDCheckDataTier = New ToolIDCheckDataTier
            TheToolIDCheckDataSet = TheToolIDCheckDataTier.GetToolIDInformation
            TheToolIDCheckBindingSource = New BindingSource

            'Binding the Combobox
            With TheToolIDCheckBindingSource
                .DataSource = TheToolIDCheckDataSet
                .DataMember = "toolidcheck"
                .MoveFirst()
                .MoveLast()
            End With

            'Setting the relationship between the table and the Combobox
            With cboTransactionID
                .DataSource = TheToolIDCheckBindingSource
                .DisplayMember = "TransactionID"
                .DataBindings.Add("text", TheToolIDCheckBindingSource, "TransactionID", False, DataSourceUpdateMode.Never)
            End With

            'Setting the data bindings for the textboxes
            txtToolID.DataBindings.Add("text", TheToolIDCheckBindingSource, "ToolID")

            'Creating the ID
            intNewID = CInt(txtToolID.Text)
            intNewID += 1
            txtToolID.Text = CStr(intNewID)
            Logon.mintCreatedToolID = CInt(intNewID)
            Logon.mstrLastTransactionSummary = "CREATED TOOL ID " + txtToolID.Text
            LastTransaction.Show()

            TheToolIDCheckBindingSource.EndEdit()
            TheToolIDCheckDataTier.UpdateDB(TheToolIDCheckDataSet)
            Me.Close()

            'Catch is used to catch the exception
        Catch
            MessageBox.Show("There is a problem with the form loading", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub setComboBoxBinding()

        'Setting the combobox binding
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