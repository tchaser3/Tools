'Title:         Add Part Number To Inventory
'Date:          5-5-15
'Author:        Terry Holmes

'Description:   This will add a part to the inventory table

Option Strict On

Public Class AddPartNumberToInventory

    'setting global variables
    Private TheInventoryDataSet As InventoryDataSet
    Private TheInventoryDataTier As InventoryDataTier
    Private WithEvents TheInventoryBindingSource As BindingSource

    Private addingBoolean As Boolean = False
    Private editingBoolean As Boolean = False
    Private previousSelectedIndex As Integer

    Private Sub SetComboBoxBinding()
        With cboPartID
            If (addingBoolean Or editingBoolean) Then
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.OnValidation
                .DropDownStyle = ComboBoxStyle.Simple
            Else
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.Never
                .DropDownStyle = ComboBoxStyle.DropDownList
            End If
        End With
    End Sub

    Private Sub AddPartNumberToInventory_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'This will load up the controls
        Try

            'loading data variables
            TheInventoryDataTier = New InventoryDataTier
            TheInventoryDataSet = TheInventoryDataTier.GetInventoryInformation
            TheInventoryBindingSource = New BindingSource

            'Setting up the binding source
            With TheInventoryBindingSource
                .DataSource = TheInventoryDataSet
                .DataMember = "Inventory"
                .MoveFirst()
                .MoveLast()
            End With

            'Setting up the combo box
            With cboPartID
                .DataSource = TheInventoryBindingSource
                .DisplayMember = "PartID"
                .DataBindings.Add("text", TheInventoryBindingSource, "PartID", False, DataSourceUpdateMode.Never)
            End With

            'Setting up the rest of the controls
            txtPartDescription.DataBindings.Add("text", TheInventoryBindingSource, "PartDescription")
            txtPartNumber.DataBindings.Add("Text", TheInventoryBindingSource, "PartNumber")
            txtQTYResponible.DataBindings.Add("text", TheInventoryBindingSource, "QTYResponible")
            txtWarehouseID.DataBindings.Add("text", TheInventoryBindingSource, "WarehouseID")

            CreateInventoryID.Show()

            'Adding new record
            With TheInventoryBindingSource
                .EndEdit()
                .AddNew()
            End With

            addingBoolean = True
            SetComboBoxBinding()

            cboPartID.Text = CStr(Logon.mintCreatedTransactionID)
            txtWarehouseID.Text = CStr(Logon.mintPartsWarehouseID)
            txtPartNumber.Text = Logon.mstrPartNumber
            txtQTYResponible.Text = CStr(Logon.mintQuantity)

            'Saving the record
            TheInventoryBindingSource.EndEdit()
            TheInventoryDataTier.UpdateInventoryDB(TheInventoryDataSet)
            addingBoolean = False
            editingBoolean = False
            SetComboBoxBinding()

            Me.Close()

        Catch ex As Exception

            'output to user
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub
End Class