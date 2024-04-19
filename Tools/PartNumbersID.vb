'Title:         Part Number ID Creation
'Date:          3/31/14
'Author:        Terry Holmes

'Description:   This form is used to create Part Number IDs

Option Strict On

Public Class PartNumbersID

    'Creating Modular Variables
    Private ThePartNumberIDDataSet As PartNumberIDDataSet
    Private ThePartNumberIDDataTier As PartDataTier
    Private WithEvents ThePartNumberIDBindingSource As BindingSource

    Private addingBoolean As Boolean = False
    Private editingBoolean As Boolean = False
    Private previousSelectedIndex As Integer
    Dim mintNumuberOfRecords As Integer

    Dim LogDateTime As Date = DateAndTime.Now
    Dim strLogDateTime As String
    Friend mintCreatedToolID As Integer

    Private Sub PartNumbersID_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'This subroutine runs when the form is loaded
        Dim intNewPartID As Integer

        Try

            'This will bind the controls to the data source
            ThePartNumberIDDataTier = New PartDataTier
            ThePartNumberIDDataSet = ThePartNumberIDDataTier.GetPartNumberIDInformation
            ThePartNumberIDBindingSource = New BindingSource

            With ThePartNumberIDBindingSource
                .DataSource = ThePartNumberIDDataSet
                .DataMember = "PartNumberID"
                .MoveFirst()
                .MoveLast()
            End With

            With cboTransactionID
                .DataSource = ThePartNumberIDBindingSource
                .DisplayMember = "TransactionID"
                .DataBindings.Add("text", ThePartNumberIDBindingSource, "TransactionID", False, DataSourceUpdateMode.Never)
            End With

            txtPartID.DataBindings.Add("text", ThePartNumberIDBindingSource, "PartID")

            'Creating and saving the new id
            intNewPartID = CInt(txtPartID.Text)
            intNewPartID = intNewPartID + 1
            Logon.mintPartID = CInt(intNewPartID)
            txtPartID.Text = CStr(intNewPartID)

            ThePartNumberIDBindingSource.EndEdit()
            ThePartNumberIDDataTier.UpdatePartNumberIDDB(ThePartNumberIDDataSet)
            Me.Close()

        Catch
            MessageBox.Show("There is a problem with the form loading", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
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
End Class