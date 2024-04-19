'Title:         Verify Asset Item
'Date:          7/16/14
'Author:        Terry Holmes

'Description:   This is used to verify the Item Category for existance

Public Class VerifyAssetItem

    'Setting up data set
    Private TheAssetItemDataSet As AssetItemDataSet
    Private TheAssetItemDataTier As AssetDataTier
    Private WithEvents TheAssetItemBindingSource As BindingSource

    Dim TheInputDataValidation As New InputDataValidation

    Private addingBoolean As Boolean = False
    Private editingBoolean As Boolean = False
    Private previousSelectedIndex As Integer


    Private Sub VerifyAssetItem_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim strAssetCategoryForSearch As String
        Dim strAssetCategoryFromTable As String
        Dim blnAssetCategoryExists As Boolean = False

        'This routine will run when the form is loaded
        Try
            'This will bind the controls to the data source
            TheAssetItemDataTier = New AssetDataTier
            TheAssetItemDataSet = TheAssetItemDataTier.GetAssetItemInformation
            TheAssetItemBindingSource = New BindingSource

            'Setting Combobox binding to the dataset
            With TheAssetItemBindingSource
                .DataSource = TheAssetItemDataSet
                .DataMember = "assetitems"
                .MoveFirst()
                .MoveLast()
            End With

            'Setting the combobox to the table
            With cboItemID
                .DataSource = TheAssetItemBindingSource
                .DisplayMember = "ItemID"
                .DataBindings.Add("text", TheAssetItemBindingSource, "ItemID", False, DataSourceUpdateMode.Never)
            End With

            'Binding the textbox
            txtItemCategory.DataBindings.Add("text", TheAssetItemBindingSource, "ItemCategory")

            'Beginning the Search
            intNumberOfRecords = cboItemID.Items.Count - 1
            strAssetCategoryForSearch = Logon.mstrAssetCategory

            'Beginning Loop
            For intCounter = 0 To intNumberOfRecords

                cboItemID.SelectedIndex = intCounter
                strAssetCategoryFromTable = txtItemCategory.Text

                If strAssetCategoryForSearch = strAssetCategoryFromTable Then
                    blnAssetCategoryExists = True
                End If


            Next

            Logon.mblnAssetCategoryExists = blnAssetCategoryExists

            Me.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
End Class