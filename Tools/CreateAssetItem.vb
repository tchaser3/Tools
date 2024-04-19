'Title:         Create Asset Item
'Date:          7/16/14
'Author:        Terry Holmes

'Description:   This form is used to create asset items that are used for validation

Option Strict On

Public Class CreateAssetItem

    'Setting up data set
    Private TheAssetItemDataSet As AssetItemDataSet
    Private TheAssetItemDataTier As AssetDataTier
    Private WithEvents TheAssetItemBindingSource As BindingSource

    Dim TheInputDataValidation As New InputDataValidation

    Private addingBoolean As Boolean = False
    Private editingBoolean As Boolean = False
    Private previousSelectedIndex As Integer

    Dim mdatLogDate As Date = Date.Now
    Dim mstrLogDate As String
    Dim mintCreatedTransaction As Integer

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        'Closes the Program
        CloseTheProgram.ShowDialog()

    End Sub
    Private Sub SetAddSaveButtonCondition(ByVal valueBoolean As Boolean)

        If valueBoolean = True Then
            btnAdd.Text = "Save"
        Else
            btnAdd.Text = "Add"
        End If

    End Sub

    Private Sub btnMainMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMainMenu.Click

        'Calls the Main Menu
        MainMenu.Show()
        Me.Close()

    End Sub

    Private Sub btnAssetControlMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAssetControlMenu.Click

        'Calls the Asset Control Menu
        AssetControlMenu.Show()
        Me.Close()

    End Sub
    Private Sub setComboBoxBinding()

        'Setting the changing for the Combobos
        With Me.cboItemID
            If (addingBoolean Or editingBoolean) Then
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.OnValidation
                .DropDownStyle = ComboBoxStyle.Simple
            Else
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.Never
                .DropDownStyle = ComboBoxStyle.DropDownList
            End If
        End With

    End Sub

    Private Sub CreateAssetItem_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'This routine will run when the form is loaded
        Try
            'This will bind the controls to the data source
            TheAssetItemDataTier = New AssetDataTier
            TheAssetItemDataSet = TheAssetItemDataTier.GetAssetItemInformation
            TheAssetItemBindingSource = New BindingSource

            'Setting Combobox binding to the dataset
            With TheAssetItemBindingSource
                .DataSource = TheAssetItemDataSet
                .DataMember = "assetitem"
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
            txtAssetCategory.DataBindings.Add("text", TheAssetItemBindingSource, "ItemCategory")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim intSelectedIndex As Integer
        Dim strItemCategoryForSearch As String
        Dim strItemCategoryFromTable As String
        Dim blnFatalError As Boolean = False
        Dim blnCategoryNotFound As Boolean = True

        'Setting up validation
        strItemCategoryForSearch = txtItemCategoryEntered.Text
        blnFatalError = TheInputDataValidation.VerifyTextData(strItemCategoryForSearch)

        'Checking to verify there as information
        If blnFatalError = True Then
            txtItemCategoryEntered.Text = ""
            MessageBox.Show("Item Category Was Not Entered", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        'Setting up for loop
        intNumberOfRecords = cboItemID.Items.Count - 1

        'Running Loop
        For intCounter = 0 To intNumberOfRecords

            cboItemID.SelectedIndex = intCounter
            strItemCategoryFromTable = txtAssetCategory.Text

            If strItemCategoryForSearch = strItemCategoryFromTable Then
                intSelectedIndex = intCounter
                blnCategoryNotFound = False
            End If

        Next

        If blnCategoryNotFound = True Then
            txtItemCategoryEntered.Text = ""
            MessageBox.Show("Item Entered Does Not Exist", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        cboItemID.SelectedIndex = intSelectedIndex

    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        'Setting Local Variable
        Dim strAssetCategory As String
        Dim blnFatalError As Boolean
        Dim blnAssetCateogoryExists As Boolean = True

        'Beginning the process
        If btnAdd.Text = "Add" Then

            'Setting the Binding Source up
            With TheAssetItemBindingSource
                .EndEdit()
                .AddNew()
            End With

            'Setting variables
            addingBoolean = True
            setComboBoxBinding()

            'Setting Combo Box
            If cboItemID.SelectedIndex <> -1 Then
                previousSelectedIndex = cboItemID.Items.Count - 1
            Else
                previousSelectedIndex = 0
            End If

            'Calling Sub Routine to get ID
            CreateAssetModuleID.Show()

            cboItemID.Text = CStr(Logon.mintCreatedTransactionID)
            SetAddSaveButtonCondition(True)
            mintCreatedTransaction = CInt(Logon.mintCreatedTransactionID)

        Else

            'Beginning Data Validation
            strAssetCategory = txtAssetCategory.Text
            blnFatalError = TheInputDataValidation.VerifyTextData(strAssetCategory)

            'Checking for Data Validation
            If blnFatalError = True Then
                MessageBox.Show("The Asset Category Was Not Entered", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            'Checking to see if the item exists
            Logon.mstrAssetCategory = CStr(strAssetCategory)

            'Calling form and subroutine
            VerifyAssetItem.Show()

            'Setting boolean variables
            blnAssetCateogoryExists = CBool(Logon.mblnAssetCategoryExists)

            'Letting User Know
            If blnAssetCateogoryExists = True Then
                MessageBox.Show("The Asset Category Entered currently exists", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            cboItemID.Text = CStr(mintCreatedTransaction)

            'Updating The Database
            Try
                TheAssetItemBindingSource.EndEdit()
                TheAssetItemDataTier.UpdateAssetItem(TheAssetItemDataSet)
                addingBoolean = False
                editingBoolean = False
                setComboBoxBinding()
                SetAddSaveButtonCondition(False)
                cboItemID.SelectedIndex = previousSelectedIndex
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If

    End Sub
End Class