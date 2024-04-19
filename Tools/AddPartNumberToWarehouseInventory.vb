'Title:         Add Part Number To Warehouse Inventory
'Date:          9-15-155
'Author:        Terry Holmes

'Description:   This form is used to update the warehouse inventory

Option Strict On

Public Class AddPartNumberToWarehouseInventory

    'Setting up global dat variables
    Private TheWarehouseInventoryDataTier As WarehouseInventoryDataTier
    Private TheWarehouseInventoryDataSet As WarehouseInventoryDataSet
    Private WithEvents TheWarehouseInventoryBindingSource As BindingSource

    Private addingBoolean As Boolean = False
    Private editingBoolean As Boolean = False
    Private previousSelectedIndex As Integer

    Private Sub SetComboBoxBinding()

        'This will set the combo box bindings
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


    Private Sub AddPartNumberToWarehouseInventory_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'This will load up the controls
        Try

            'loading data variables
            TheWarehouseInventoryDataTier = New WarehouseInventoryDataTier
            TheWarehouseInventoryDataSet = TheWarehouseInventoryDataTier.GetWarehouseInventoryInformation
            TheWarehouseInventoryBindingSource = New BindingSource

            'Setting up the binding source
            With TheWarehouseInventoryBindingSource
                .DataSource = TheWarehouseInventoryDataSet
                .DataMember = "WarehouseInventory"
                .MoveFirst()
                .MoveLast()
            End With

            'Setting up the combo box
            With cboPartID
                .DataSource = TheWarehouseInventoryBindingSource
                .DisplayMember = "PartID"
                .DataBindings.Add("text", TheWarehouseInventoryBindingSource, "PartID", False, DataSourceUpdateMode.Never)
            End With

            'Setting up the rest of the controls
            txtPartDescription.DataBindings.Add("text", TheWarehouseInventoryBindingSource, "PartDescription")
            txtPartNumber.DataBindings.Add("Text", TheWarehouseInventoryBindingSource, "PartNumber")
            txtQTYOnHand.DataBindings.Add("text", TheWarehouseInventoryBindingSource, "QTYOnHand")
            txtWarehouseID.DataBindings.Add("text", TheWarehouseInventoryBindingSource, "WarehouseID")

            CreateInventoryID.Show()

            'Adding new record
            With TheWarehouseInventoryBindingSource
                .EndEdit()
                .AddNew()
            End With

            addingBoolean = True
            SetComboBoxBinding()

            cboPartID.Text = CStr(Logon.mintCreatedTransactionID)
            txtWarehouseID.Text = CStr(Logon.mintPartsWarehouseID)
            txtPartNumber.Text = Logon.mstrPartNumber
            txtQTYOnHand.Text = CStr(Logon.mintQuantity)

            'Saving the record
            TheWarehouseInventoryBindingSource.EndEdit()
            TheWarehouseInventoryDataTier.UpdateWarehouseInventoryDB(TheWarehouseInventoryDataSet)
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