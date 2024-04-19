'Title:         Update Duplicate Inventory Part Numbers
'Date:          9-28-15
'Author:        Terry Holmes

'Description:   This form is used to remove the duplicate part numbers from the inventory table

Option Strict On

Public Class UpdateDuplicateInventoryPartNumbers

    Private TheInventoryDataTier As InventoryDataTier
    Private TheInventoryDataSet As InventoryDataSet
    Private WithEvents TheInventoryBindingSource As BindingSource

    Private TheWarehouseInventoryDataTier As WarehouseInventoryDataTier
    Private TheWarehouseInventoryDataSet As WarehouseInventoryDataSet
    Private WithEvents TheWarehouseInventoryBindingSource As BindingSource

    Structure Inventory
        Dim mintPartID As Integer
        Dim mstrPartNumber As String
        Dim mintQuantity As Integer
    End Structure

    Dim structInventory() As Inventory
    Dim mintInventoryCounter As Integer
    Dim mintInventoryUpperLimit As Integer
    Dim mintNumberOfRecords As Integer

    Private Sub ClearDataBindings()

        'this will remove the data bindings
        txtPartNumber.DataBindings.Clear()
        txtQuantity.DataBindings.Clear()
        cboPartID.DataBindings.Clear()
        txtWarehouseID.DataBindings.Clear()

    End Sub
    Private Sub SetInventoryDataBindings()

        'Setting local variables
        Dim intNumberOfRecords As Integer

        'Try Catch for exceptions
        Try

            'setting the controls
            TheInventoryDataTier = New InventoryDataTier
            TheInventoryDataSet = TheInventoryDataTier.GetInventoryInformation
            TheInventoryBindingSource = New BindingSource

            'setting the bindingsource
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
            txtPartNumber.DataBindings.Add("Text", TheInventoryBindingSource, "PartNumber")
            txtQuantity.DataBindings.Add("Text", TheInventoryBindingSource, "QTYResponible")
            txtWarehouseID.DataBindings.Add("Text", TheInventoryBindingSource, "WarehouseID")

            intNumberOfRecords = cboPartID.Items.Count - 1
            ReDim structInventory(intNumberOfRecords)
            mintNumberOfRecords = intNumberOfRecords

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub SetWarehouseInventoryDataBindings()
        'Try Catch for exceptions
        Try

            'setting the controls
            TheWarehouseInventoryDataTier = New WarehouseInventoryDataTier
            TheWarehouseInventoryDataSet = TheWarehouseInventoryDataTier.GetWarehouseInventoryInformation
            TheWarehouseInventoryBindingSource = New BindingSource

            'setting the bindingsource
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
            txtPartNumber.DataBindings.Add("Text", TheWarehouseInventoryBindingSource, "PartNumber")
            txtQuantity.DataBindings.Add("Text", TheWarehouseInventoryBindingSource, "QTYOnHand")
            txtWarehouseID.DataBindings.Add("Text", TheWarehouseInventoryBindingSource, "WarehouseID")

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub ClearStructure()

        'setting local variables
        Dim intCounter As Integer

        'clearing structure
        For intCounter = 0 To mintNumberOfRecords

            structInventory(intCounter).mintPartID = 0
            structInventory(intCounter).mintQuantity = 0
            structInventory(intCounter).mstrPartNumber = ""

        Next
    End Sub
    Private Sub RemoveDuplicateTransactions(ByVal strTableType As String)

        'Setting local variables
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim strPartNumberForSearch As String
        Dim strPartNumberFromTable As String
        Dim intQuantityFromStructure As Integer
        Dim intQuantityFromTable As Integer
        Dim blnTransactionInStructure As Boolean = False
        Dim intStructureCounter As Integer
        Dim intStructureIndex As Integer
        Dim blnRecordsRemoved As Boolean = False
        Dim intPartIDForSearch As Integer
        Dim intPartIDFromTable As Integer
        Dim intWarehouseIDForSearch As Integer
        Dim intWarehouseIDFromTable As Integer
        Dim blnTransactionRemoved As Boolean = False

        'getting the number of records
        intNumberOfRecords = cboPartID.Items.Count - 1
        strPartNumberForSearch = Logon.mstrPartNumber
        mintInventoryCounter = 0
        intWarehouseIDForSearch = CInt(Logon.mintPartsWarehouseID)

        'Preforming the loop
        While (intCounter <= intNumberOfRecords)

            If blnTransactionRemoved = True Then
                intCounter -= 1
                intNumberOfRecords -= 1
            End If

            blnTransactionRemoved = False

            'incrementing the combo box
            cboPartID.SelectedIndex = intCounter

            'Getting part number
            strPartNumberFromTable = txtPartNumber.Text

            'getting warehouse id
            intWarehouseIDFromTable = CInt(txtWarehouseID.Text)

            'If Statements to see if the part number matched
            If strPartNumberForSearch = strPartNumberFromTable Then
                If intWarehouseIDForSearch = intWarehouseIDFromTable Then
                    If blnTransactionInStructure = False Then

                        structInventory(intCounter).mintPartID = CInt(cboPartID.Text)
                        structInventory(intCounter).mintQuantity = CInt(txtQuantity.Text)
                        structInventory(intCounter).mstrPartNumber = txtPartNumber.Text
                        blnTransactionInStructure = True
                        mintInventoryUpperLimit = mintInventoryCounter
                        mintInventoryCounter += 1

                    ElseIf blnTransactionInStructure = True Then

                        MessageBox.Show("there is a fucking one " + strPartNumberForSearch, "Mother Fucker", MessageBoxButtons.OK, MessageBoxIcon.Error)

                        'Finding the part number
                        For intStructureCounter = 0 To mintInventoryUpperLimit

                            If strPartNumberFromTable = structInventory(intStructureCounter).mstrPartNumber Then
                                intStructureIndex = intStructureCounter
                            End If
                        Next

                        'Getting the quantity change
                        intQuantityFromStructure = structInventory(intStructureIndex).mintQuantity
                        intQuantityFromTable = CInt(txtQuantity.Text)
                        intQuantityFromStructure = intQuantityFromStructure + intQuantityFromTable
                        structInventory(intStructureIndex).mintQuantity = intQuantityFromStructure

                        'Updating the record
                        Try
                            If strTableType = "INVENTORY" Then
                                TheInventoryBindingSource.RemoveCurrent()
                                TheInventoryDataTier.UpdateInventoryDB(TheInventoryDataSet)
                            ElseIf strTableType = "WAREHOUSE" Then
                                TheWarehouseInventoryBindingSource.RemoveCurrent()
                                TheWarehouseInventoryDataTier.UpdateWarehouseInventoryDB(TheWarehouseInventoryDataSet)
                            End If

                            'decrementing the counters
                            blnRecordsRemoved = True
                            blnTransactionRemoved = True

                        Catch ex As Exception
                            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                    End If
                End If
            End If
            intCounter += 1
        End While


        'Updating Inventory
        If blnRecordsRemoved = True Then

            'Performoing Loop through structure
            For intStructureCounter = 0 To mintInventoryUpperLimit

                'Getting ready for second loop
                intPartIDForSearch = structInventory(intStructureCounter).mintPartID

                'Beginning Second loop
                For intCounter = 0 To intNumberOfRecords

                    'incrementing the combo box
                    cboPartID.SelectedIndex = intCounter

                    intPartIDFromTable = CInt(cboPartID.Text)

                    If intPartIDForSearch = intPartIDFromTable Then

                        txtQuantity.Text = CStr(structInventory(intStructureCounter).mintQuantity)

                        'try catch for exceptions
                        Try

                            'Updating tables
                            If strTableType = "INVENTORY" Then
                                TheInventoryBindingSource.EndEdit()
                                TheInventoryDataTier.UpdateInventoryDB(TheInventoryDataSet)
                            ElseIf strTableType = "WAREHOUSE" Then
                                TheWarehouseInventoryBindingSource.EndEdit()
                                TheWarehouseInventoryDataTier.UpdateWarehouseInventoryDB(TheWarehouseInventoryDataSet)
                            End If

                        Catch ex As Exception
                            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                    End If
                Next
            Next
        End If
    End Sub

    Private Sub UpdateDuplicateInventoryPartNumbers_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'setting local inventory
        Dim strTableType As String

        'Runs during boot up
        ClearDataBindings()
        SetInventoryDataBindings()
        ClearStructure()
        strTableType = "INVENTORY"
        RemoveDuplicateTransactions(strTableType)
        ClearDataBindings()
        SetWarehouseInventoryDataBindings()
        ClearStructure()
        strTableType = "WAREHOUSE"
        RemoveDuplicateTransactions(strTableType)
        ClearDataBindings()
        Me.Close()

    End Sub
End Class