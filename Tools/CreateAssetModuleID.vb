'Title:         Create Asset Module ID
'Date:          7-15-14
'Author:        Terry Holmes

Option Strict On

Public Class CreateAssetModuleID

    'Creating Modular Variables
    Private TheAssetModuleIDDataSet As AssetModuleIDDataSet
    Private TheAssetModuleIDDataTier As AssetDataTier
    Private WithEvents TheAssetModuleIDBindingSource As BindingSource

    Private addingBoolean As Boolean = False
    Private editingBoolean As Boolean = False
    Private previousSelectedIndex As Integer
    Dim mintNumuberOfRecords As Integer

    Dim LogDateTime As Date = DateAndTime.Now
    Dim strLogDateTime As String

    Private Sub setComboBoxBinding()

        'Setting the changing for the Combobos
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

    Private Sub CreateAssetModuleID_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Setting Local Variables
        Dim intNumberOfRecords As Integer
        Dim intCreatedTransactionFromLogon As Integer
        Dim intTransactionID As Integer

        'Using a Try Catch to catch illegal exceptions
        Try

            'This will bind the controls to the data source
            TheAssetModuleIDDataTier = New AssetDataTier
            TheAssetModuleIDDataSet = TheAssetModuleIDDataTier.GetAssetModuleIDInformation
            TheAssetModuleIDBindingSource = New BindingSource

            'Setting Combobox binding to the dataset
            With TheAssetModuleIDBindingSource
                .DataSource = TheAssetModuleIDDataSet
                .DataMember = "assetmoduleid"
                .MoveFirst()
                .MoveLast()
            End With

            'Setting the combobox to the table
            With cboTransactionID
                .DataSource = TheAssetModuleIDBindingSource
                .DisplayMember = "TransactionID"
                .DataBindings.Add("text", TheAssetModuleIDBindingSource, "TransactionID", False, DataSourceUpdateMode.Never)
            End With

            'Binding the textbox
            txtCreatedTransactionID.DataBindings.Add("text", TheAssetModuleIDBindingSource, "CreatedTransactionID")

            'Getting the created ID
            intCreatedTransactionFromLogon = CInt(Logon.mintCreatedTransactionID)
            intNumberOfRecords = 1000 + cboTransactionID.Items.Count
            intTransactionID = intNumberOfRecords

            'Setting the binding source to add a record
            With TheAssetModuleIDBindingSource
                .EndEdit()
                .AddNew()
            End With

            'Calling routines and setting values
            addingBoolean = True
            setComboBoxBinding()
            If cboTransactionID.SelectedIndex <> -1 Then
                previousSelectedIndex = cboTransactionID.Items.Count
            Else
                previousSelectedIndex = 0

            End If

            cboTransactionID.Text = CStr(intNumberOfRecords)
            txtCreatedTransactionID.Text = CStr(intNumberOfRecords)
            Logon.mintCreatedTransactionID = intNumberOfRecords

            'Updating the Dataset
            TheAssetModuleIDBindingSource.EndEdit()
            TheAssetModuleIDDataTier.UpdateAssetModuleID(TheAssetModuleIDDataSet)

            'Closing the form
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
End Class