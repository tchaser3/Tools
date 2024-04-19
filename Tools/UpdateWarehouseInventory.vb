'Title:         Update Warehouse Inventory
'Date:          9-16-15
'Author:        Terry Holmes

'Description:   This form is used to update the warehouse inventory table

Public Class UpdateWarehouseInventory

    Private TheWarehouseInventoryDataTier As WarehouseInventoryDataTier
    Private TheWarehouseInventoryDataSet As WarehouseInventoryDataSet
    Private WithEvents TheWarehouseInventoryBindingSource As BindingSource

    Private addingBoolean As Boolean = False
    Private editingBoolean As Boolean = False
    Private previouseSelectedIndex As Integer

    Private Sub UpdateWarehouseInventory_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Setting up the local variables
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim intSelectedIndex As Integer
        Dim strPartNumberForSearch As String
        Dim strPartNumberFromTable As String
        Dim intWarehouseIDForSearch As Integer
        Dim intWarehouseIDFromTable As Integer
        Dim intQuantityOnHand As Integer
        Dim blnItemNotFound As Boolean = True

        'Try Catch to Load Form
        Try

            'Setting up the data variables
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
            With cboPartNumber
                .DataSource = TheWarehouseInventoryBindingSource
                .DisplayMember = "PartNumber"
                .DataBindings.Add("text", TheWarehouseInventoryBindingSource, "PartNumber", False, DataSourceUpdateMode.Never)
            End With

            'Setting up the rest of the controls
            txtPartID.DataBindings.Add("text", TheWarehouseInventoryBindingSource, "PartID")
            txtPartDescription.DataBindings.Add("text", TheWarehouseInventoryBindingSource, "PartDescription")
            txtQTYResponible.DataBindings.Add("text", TheWarehouseInventoryBindingSource, "QTYOnHand")
            txtWarehouseID.DataBindings.Add("text", TheWarehouseInventoryBindingSource, "WarehouseID")

            'Getting ready for the search
            intNumberOfRecords = cboPartNumber.Items.Count - 1
            strPartNumberForSearch = Logon.mstrPartNumber
            intWarehouseIDForSearch = Logon.mintPartsWarehouseID

            'Beginning the loop
            For intCounter = 0 To intNumberOfRecords

                'Setting up the combo box
                cboPartNumber.SelectedIndex = intCounter

                'Getting the part number
                strPartNumberFromTable = cboPartNumber.Text
                intWarehouseIDFromTable = CInt(txtWarehouseID.Text)

                'If statements to to see if the part numbers match
                If strPartNumberForSearch = strPartNumberFromTable And intWarehouseIDForSearch = intWarehouseIDFromTable Then
                    intSelectedIndex = intCounter
                    blnItemNotFound = False
                End If
            Next

            If blnItemNotFound = True Then

                Logon.mstrPartNumber = strPartNumberForSearch
                AddPartNumberToWarehouseInventory.Show()

            Else

                'Getting ready to edit the record
                cboPartNumber.SelectedIndex = intSelectedIndex
                intQuantityOnHand = CInt(txtQTYResponible.Text)

                intQuantityOnHand = intQuantityOnHand + CInt(Logon.mintQuantity)
                txtQTYResponible.Text = CStr(intQuantityOnHand)

                'Saving the record
                TheWarehouseInventoryBindingSource.EndEdit()
                TheWarehouseInventoryDataTier.UpdateWarehouseInventoryDB(TheWarehouseInventoryDataSet)

            End If

            cboPartNumber.DataBindings.Clear()
            txtPartDescription.DataBindings.Clear()
            txtPartID.DataBindings.Clear()
            txtQTYResponible.DataBindings.Clear()

            Me.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

End Class