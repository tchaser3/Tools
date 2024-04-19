'Title:         Update Inventory
'Date:          9-16-15
'Author:        Terry Holmes

'Description:   Update the Inventory Table

Option Strict On

Public Class UpdateInventory

    Private TheInventoryDataTier As InventoryDataTier
    Private TheInventoryDataSet As InventoryDataSet
    Private WithEvents TheInventoryBindingSource As BindingSource

    Private addingBoolean As Boolean = False
    Private editingBoolean As Boolean = False
    Private previouseSelectedIndex As Integer

    Private Sub ViewCurrentInventory_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Setting up the local variables
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim intSelectedIndex As Integer
        Dim strPartNumberForSearch As String
        Dim strPartNumberFromTable As String
        Dim intQuantityOnHand As Integer
        Dim blnItemNotFound As Boolean = True
        Dim intWarehouseIDForSearch As Integer
        Dim intWarehouseIDFromTable As Integer

        'Try Catch to Load Form
        Try

            'Setting up the data variables
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
            With cboPartNumber
                .DataSource = TheInventoryBindingSource
                .DisplayMember = "PartNumber"
                .DataBindings.Add("text", TheInventoryBindingSource, "PartNumber", False, DataSourceUpdateMode.Never)
            End With

            'Setting up the rest of the controls
            txtPartID.DataBindings.Add("text", TheInventoryBindingSource, "PartID")
            txtPartDescription.DataBindings.Add("text", TheInventoryBindingSource, "PartDescription")
            txtQTYResponible.DataBindings.Add("text", TheInventoryBindingSource, "QTYResponible")
            txtWarehouseID.DataBindings.Add("text", TheInventoryBindingSource, "WarehouseID")

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

                'This will load the global variable
                Logon.mstrPartNumber = strPartNumberForSearch
                AddPartNumberToInventory.Show()

            Else
                'Getting ready to edit the record
                cboPartNumber.SelectedIndex = intSelectedIndex
                intQuantityOnHand = CInt(txtQTYResponible.Text)

                intQuantityOnHand = intQuantityOnHand + CInt(Logon.mintQuantity)
                txtQTYResponible.Text = CStr(intQuantityOnHand)

                'Saving the record
                TheInventoryBindingSource.EndEdit()
                TheInventoryDataTier.UpdateInventoryDB(TheInventoryDataSet)
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