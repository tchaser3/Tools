'Title:         Create Asset
'Date:          7/16/14
'Author:        Terry Holmes

'Description:   This form is used to create an asset

Option Strict On

Public Class CreateAsset

    'Setting up data set
    Private TheAssetDataSet As AssetDataSet
    Private TheAssetDataTier As AssetDataTier
    Private WithEvents TheAssetBindingSource As BindingSource

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
        With Me.cboAssetID
            If (addingBoolean Or editingBoolean) Then
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.OnValidation
                .DropDownStyle = ComboBoxStyle.Simple
            Else
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.Never
                .DropDownStyle = ComboBoxStyle.DropDownList
            End If
        End With

    End Sub

    Private Sub CreateAsset_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'This will load the form
        Try

            'Setting up the data information
            TheAssetDataTier = New AssetDataTier
            TheAssetDataSet = TheAssetDataTier.GetAssetInformation
            TheAssetBindingSource = New BindingSource

            'Setting the Binding Source
            With TheAssetBindingSource
                .DataSource = TheAssetDataSet
                .DataMember = "asset"
                .MoveFirst()
                .MoveLast()
            End With

            'Setting the bombo box
            With cboAssetID
                .DataSource = TheAssetBindingSource
                .DisplayMember = "AssetID"
                .DataBindings.Add("text", TheAssetBindingSource, "AssetID", False, DataSourceUpdateMode.Never)
            End With

            'Binding the Controls
            txtAssetCategory.DataBindings.Add("text", TheAssetBindingSource, "ItemCategory")
            txtDescription.DataBindings.Add("text", TheAssetBindingSource, "Description")
            txtManufacturer.DataBindings.Add("text", TheAssetBindingSource, "Manufacturer")
            txtSerialNumber.DataBindings.Add("text", TheAssetBindingSource, "SerialNo")
            txtComputerName.DataBindings.Add("text", TheAssetBindingSource, "ComputerName")
            txtEmployeeID.DataBindings.Add("text", TheAssetBindingSource, "EmployeeID")
            txtOfficeID.DataBindings.Add("text", TheAssetBindingSource, "OfficeID")
            txtLocation.DataBindings.Add("text", TheAssetBindingSource, "Location")
            txtAvailable.DataBindings.Add("text", TheAssetBindingSource, "Available")
            txtActive.DataBindings.Add("text", TheAssetBindingSource, "Active")

            SetTextBoxesReadOnly(True)
            cboAssetID.SelectedIndex = 0

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        'Setting up local variables
        Dim strValueForValidation As String
        Dim blnFatalError As Boolean = False
        Dim blnAssetCategoryExists As Boolean = False
        Dim strAssetCategory As String
        Dim strControlName As String
        Dim strEmptyControlWarning As String = ""
        Dim strErrorMessage As String

        'This procedure will run when the button is pressed
        If btnAdd.Text = "Add" Then

            'Setting up the binding source
            With TheAssetBindingSource
                .EndEdit()
                .AddNew()
            End With

            SetTextBoxesReadOnly(False)

            'Setting up other variables
            addingBoolean = True
            setComboBoxBinding()
            cboAssetID.Focus()
            If cboAssetID.SelectedIndex <> -1 Then
                previousSelectedIndex = cboAssetID.Items.Count - 1
            Else
                previousSelectedIndex = 0
            End If

            'Setting value of controls
            CreateAssetModuleID.Show()
            FindHomeOfficeID.Show()
            cboAssetID.Text = CStr(Logon.mintCreatedTransactionID)
            txtEmployeeID.Text = CStr(Logon.mintWarehouseID)
            txtOfficeID.Text = CStr(Logon.mintWarehouseID)
            txtActive.Text = "YES"
            txtAvailable.Text = "YES"
            SetAddSaveButtonCondition(True)

        Else

            'Beginning Data Validation
            strAssetCategory = txtAssetCategory.Text
            strControlName = "ASSET CATEGORY"
            strErrorMessage = "Asset Category Was Not Entered"
            blnFatalError = TheInputDataValidation.VerifyTextData(strAssetCategory)
            If blnFatalError = False Then
                strValueForValidation = txtDescription.Text
                strErrorMessage = "The Description Was Not Entered"
                strControlName = "DESCRIPTION"
                blnFatalError = TheInputDataValidation.VerifyTextData(strValueForValidation)
                If blnFatalError = False Then
                    strValueForValidation = txtLocation.Text
                    strErrorMessage = "The Location Was Not Entered"
                    strControlName = "LOCATION"
                    blnFatalError = TheInputDataValidation.VerifyTextData(strValueForValidation)
                End If
            End If

            If blnFatalError = True Then
                MessageBox.Show(strErrorMessage, "Please Correct the " + strControlName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            'Checking for text in other controls
            strValueForValidation = txtManufacturer.Text
            If strValueForValidation = "" Then
                strEmptyControlWarning = strEmptyControlWarning + "There is No Text For Manufacturer" + vbNewLine
                blnFatalError = True
            End If
            strValueForValidation = txtSerialNumber.Text
            If strValueForValidation = "" Then
                strEmptyControlWarning = strEmptyControlWarning + "There is No Text For Serial Number" + vbNewLine
                blnFatalError = True
            End If
            strValueForValidation = txtComputerName.Text
            If strValueForValidation = "" Then
                strEmptyControlWarning = strEmptyControlWarning + "There is No Text For Computer Name" + vbNewLine
                blnFatalError = True
            End If

            If blnFatalError = True Then
                MessageBox.Show(strEmptyControlWarning, "For Your Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            'Verifying the Asset Category
            Logon.mstrAssetCategory = strAssetCategory
            VerifyAssetItem.Show()
            blnAssetCategoryExists = Logon.mblnAssetCategoryExists

            If blnAssetCategoryExists = False Then
                MessageBox.Show("Asset Category Entered Does Not Exist", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            'Saving Database Changes
            Try
                TheAssetBindingSource.EndEdit()
                TheAssetDataTier.UpdateAssetDB(TheAssetDataSet)
                addingBoolean = False
                editingBoolean = False
                setComboBoxBinding()
                SetTextBoxesReadOnly(True)
                cboAssetID.SelectedIndex = previousSelectedIndex
                SetAddSaveButtonCondition(False)

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If

    End Sub
    Private Sub SetTextBoxesReadOnly(ByVal valueBoolean As Boolean)

        txtAssetCategory.ReadOnly = valueBoolean
        txtDescription.ReadOnly = valueBoolean
        txtManufacturer.ReadOnly = valueBoolean
        txtSerialNumber.ReadOnly = valueBoolean
        txtComputerName.ReadOnly = valueBoolean
        txtLocation.ReadOnly = valueBoolean

    End Sub
End Class