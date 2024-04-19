'Title:         Check Inventory Table
'Date:          6-26-15
'Author:        Terry Holmes

'Description:   This form is used to check the table and generate a report

Option Strict On

Public Class CheckInventoryTables

    'Setting up the data componentes
    Private TheBOMPartsDataSet As BOMPartsDataSet
    Private TheBOMPartsDataTier As BOMPartsDataTier
    Private WithEvents TheBOMPartsBindingSource As BindingSource

    Private TheReceivePartsDataSet As ReceivedPartsDataSet
    Private TheReceivePartsDataTier As ReceivePartsDataTier
    Private WithEvents TheReceivePartsBindingSource As BindingSource

    Private TheIssuedPartsDataSet As IssuedPartsDataSet
    Private TheIssuedPartsDataTier As IssuedPartsDataTier
    Private WithEvents TheIssuedPartsBindingSource As BindingSource

    Dim TheInputDataValidation As New InputDataValidation
    Dim mblnNoItemsWereFound As Boolean
    Dim mintNewPrintCounter As Integer

    Structure TransactionCheck
        Dim mstrTransactionID As String
        Dim mstrTableType As String
        Dim mstrDate As String
        Dim mstrProjectID As String
        Dim mstrPartNumber As String
        Dim mstrQuantity As String
        Dim mstrProblem As String
        Dim mstrWarehouseID As String
    End Structure

    Dim structTransactionCheck() As TransactionCheck
    Dim mintStructureCounter As Integer
    Dim mstrStructureUpperLimit As Integer
    Dim mstrTableType As String

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        CloseTheProgram.ShowDialog()
    End Sub

    Private Sub btnMainMenu_Click(sender As Object, e As EventArgs) Handles btnMainMenu.Click

        LastTransaction.Show()
        MainMenu.Show()
        Me.Close()

    End Sub
    Private Sub ClearDataBindings()

        'this will clear the data bindings
        cboTransactionID.DataBindings.Clear()
        txtDate.DataBindings.Clear()
        txtPartNumber.DataBindings.Clear()
        txtProjectID.DataBindings.Clear()
        txtQuantity.DataBindings.Clear()
        txtWarehouseID.DataBindings.Clear()

    End Sub
    Private Sub SetReceivedDataBindings()

        'This will bind the received bindings
        Try
            TheReceivePartsDataTier = New ReceivePartsDataTier
            TheReceivePartsDataSet = TheReceivePartsDataTier.GetReceivedPartsInformation
            TheReceivePartsBindingSource = New BindingSource

            'Setting up the binding source
            With TheReceivePartsBindingSource
                .DataSource = TheReceivePartsDataSet
                .DataMember = "ReceivedParts"
                .MoveFirst()
                .MoveLast()
            End With

            'setting up the combo box
            With cboTransactionID
                .DataSource = TheReceivePartsBindingSource
                .DisplayMember = "TransactionID"
                .DataBindings.Add("text", TheReceivePartsBindingSource, "TransactionID", False, DataSourceUpdateMode.Never)
            End With

            'setting up the rest of the controls
            txtDate.DataBindings.Add("text", TheReceivePartsBindingSource, "Date")
            txtPartNumber.DataBindings.Add("text", TheReceivePartsBindingSource, "PartNumber")
            txtProjectID.DataBindings.Add("Text", TheReceivePartsBindingSource, "ProjectID")
            txtQuantity.DataBindings.Add("Text", TheReceivePartsBindingSource, "QTY")
            txtWarehouseID.DataBindings.Add("text", TheReceivePartsBindingSource, "WarehouseID")

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub SetIssuedDataBindings()

        Try
            TheIssuedPartsDataTier = New IssuedPartsDataTier
            TheIssuedPartsDataSet = TheIssuedPartsDataTier.GetIssuedPartsInformation
            TheIssuedPartsBindingSource = New BindingSource

            'Setting up the binding source
            With TheIssuedPartsBindingSource
                .DataSource = TheIssuedPartsDataSet
                .DataMember = "IssuedParts"
                .MoveFirst()
                .MoveLast()
            End With

            'setting up the combo box
            With cboTransactionID
                .DataSource = TheIssuedPartsBindingSource
                .DisplayMember = "TransactionID"
                .DataBindings.Add("text", TheIssuedPartsBindingSource, "TransactionID", False, DataSourceUpdateMode.Never)
            End With

            'setting up the rest of the controls
            txtDate.DataBindings.Add("text", TheIssuedPartsBindingSource, "Date")
            txtPartNumber.DataBindings.Add("text", TheIssuedPartsBindingSource, "PartNumber")
            txtProjectID.DataBindings.Add("Text", TheIssuedPartsBindingSource, "ProjectID")
            txtQuantity.DataBindings.Add("Text", TheIssuedPartsBindingSource, "QTY")
            txtWarehouseID.DataBindings.Add("Text", TheIssuedPartsBindingSource, "WarehouseID")

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub SetBOMDataBindings()

        Try
            TheBOMPartsDataTier = New BOMPartsDataTier
            TheBOMPartsDataSet = TheBOMPartsDataTier.GetBOMPartsInformation
            TheBOMPartsBindingSource = New BindingSource

            'Setting up the binding source
            With TheBOMPartsBindingSource
                .DataSource = TheBOMPartsDataSet
                .DataMember = "BOMParts"
                .MoveFirst()
                .MoveLast()
            End With

            'setting up the combo box
            With cboTransactionID
                .DataSource = TheBOMPartsBindingSource
                .DisplayMember = "TransactionID"
                .DataBindings.Add("text", TheBOMPartsBindingSource, "TransactionID", False, DataSourceUpdateMode.Never)
            End With

            'setting up the rest of the controls
            txtDate.DataBindings.Add("text", TheBOMPartsBindingSource, "Date")
            txtPartNumber.DataBindings.Add("text", TheBOMPartsBindingSource, "PartNumber")
            txtProjectID.DataBindings.Add("Text", TheBOMPartsBindingSource, "ProjectID")
            txtQuantity.DataBindings.Add("Text", TheBOMPartsBindingSource, "QTY")
            txtWarehouseID.DataBindings.Add("text", TheBOMPartsBindingSource, "WarehouseID")

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub SetControlsVisible(ByVal valueBoolean As Boolean)

        cboTransactionID.Visible = valueBoolean
        txtDate.Visible = valueBoolean
        txtPartNumber.Visible = valueBoolean
        txtProjectID.Visible = valueBoolean
        txtQuantity.Visible = valueBoolean
        txtWarehouseID.Visible = valueBoolean

    End Sub
    Private Sub CheckInventoryTables_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Setting up the form load event
        Logon.mstrLastTransactionSummary = "Loaded Check Inventory Tables"
        ClearDataBindings()
        SetControlsVisible(False)

    End Sub

    Private Sub btnCheckTables_Click(sender As Object, e As EventArgs) Handles btnCheckTables.Click

        'Setting local variables
        Dim intNumberOfRecords As Integer
        Dim strTableType As String

        ClearDataBindings()

        PleaseWait.Show()

        'Set controls visible
        SetControlsVisible(True)
        mblnNoItemsWereFound = True

        'clearing the databindings
        SetReceivedDataBindings()
        strTableType = "RECEIVE"

        'setting the dimensions of the structure
        intNumberOfRecords = 4 * cboTransactionID.Items.Count - 1
        ReDim structTransactionCheck(intNumberOfRecords)
        mintStructureCounter = 0
        FindRecords(strTableType)
        ClearDataBindings()
        SetIssuedDataBindings()
        strTableType = "ISSUED"
        FindRecords(strTableType)
        ClearDataBindings()
        SetBOMDataBindings()
        strTableType = "BOM"
        FindRecords(strTableType)

        PleaseWait.Close()

        mintStructureCounter -= 1

        If mblnNoItemsWereFound = False Then

            'Dialog Box for printer
            If PrintDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                PrintDocument1.PrinterSettings = PrintDialog1.PrinterSettings
            End If

            mintNewPrintCounter = 0

            PrintDocument1.Print()

        Else
            MessageBox.Show("No Items Were Found", "Thank You", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If


    End Sub
    Private Sub FindRecords(ByVal strTableType As String)

        'Setting local variables
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim blnItemsMissing As Boolean
        Dim strDataMissing As String

        'setting up for the loop
        intNumberOfRecords = cboTransactionID.Items.Count - 1

        'running loop
        For intCounter = 0 To intNumberOfRecords

            blnItemsMissing = False

            cboTransactionID.SelectedIndex = intCounter

            'checking controls
            blnItemsMissing = TheInputDataValidation.VerifyStartingEndingDatesAsDates(txtDate.Text)
            strDataMissing = "DATE"
            If blnItemsMissing = False Then
                blnItemsMissing = TheInputDataValidation.VerifyTextData(txtPartNumber.Text)
                strDataMissing = "PARTNUMBER"
                If blnItemsMissing = False Then
                    blnItemsMissing = TheInputDataValidation.VerifyTextData(txtProjectID.Text)
                    strDataMissing = "PROJECTID"
                    If blnItemsMissing = False Then
                        blnItemsMissing = TheInputDataValidation.VerifyIntegerData(txtQuantity.Text)
                        strDataMissing = "QUANTITY"
                        If blnItemsMissing = False Then
                            blnItemsMissing = TheInputDataValidation.VerifyIntegerRange(txtQuantity.Text)
                            strDataMissing = "QUANTITY"
                            If blnItemsMissing = False Then
                                blnItemsMissing = TheInputDataValidation.VerifyIntegerData(txtWarehouseID.Text)
                                strDataMissing = "WAREHOUSEID"
                                If blnItemsMissing = False Then
                                    blnItemsMissing = TheInputDataValidation.VerifyIntegerRange(txtWarehouseID.Text)
                                    strDataMissing = "WAREHOUSEID"
                                End If
                            End If
                        End If
                    End If
                End If
            End If

            If blnItemsMissing = True Then
                mblnNoItemsWereFound = False
                structTransactionCheck(mintStructureCounter).mstrDate = txtDate.Text
                structTransactionCheck(mintStructureCounter).mstrPartNumber = txtPartNumber.Text
                structTransactionCheck(mintStructureCounter).mstrProjectID = txtProjectID.Text
                structTransactionCheck(mintStructureCounter).mstrQuantity = txtQuantity.Text
                structTransactionCheck(mintStructureCounter).mstrTableType = strTableType
                structTransactionCheck(mintStructureCounter).mstrTransactionID = cboTransactionID.Text
                structTransactionCheck(mintStructureCounter).mstrProblem = strDataMissing
                structTransactionCheck(mintStructureCounter).mstrWarehouseID = txtWarehouseID.Text
                mintStructureCounter += 1
            End If

        Next

    End Sub

    Private Sub PrintDocument1_QueryPageSettings(sender As Object, e As Printing.QueryPageSettingsEventArgs) Handles PrintDocument1.QueryPageSettings

        'this will set the page to landscape
        e.PageSettings.Landscape = True

    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage

        Dim intCounter As Integer
        Dim intStartingPageCounter As Integer
        Dim blnNewPage As Boolean = False

        'Setting up variables for the reports
        Dim PrintHeaderFont As New Font("Arial", 18, FontStyle.Bold)
        Dim PrintSubHeaderFont As New Font("Arial", 14, FontStyle.Bold)
        Dim PrintItemsFont As New Font("Arial", 10, FontStyle.Regular)
        Dim PrintX As Single = e.MarginBounds.Left
        Dim PrintY As Single = e.MarginBounds.Top
        Dim HeadingLineHeight As Single = PrintHeaderFont.GetHeight + 18
        Dim ItemLineHeight As Single = PrintItemsFont.GetHeight + 10

        intStartingPageCounter = mintNewPrintCounter

        'Setting up for default position
        PrintY = 100

        'Setting up for the print header
        PrintX = 150
        e.Graphics.DrawString("Blue Jay Communications Database Problem Transaction Report", PrintHeaderFont, Brushes.Black, PrintX, PrintY)
        PrintY = PrintY + HeadingLineHeight

        PrintX = 100
        e.Graphics.DrawString("Table Type", PrintItemsFont, Brushes.Black, PrintX, PrintY)
        PrintX = 250
        e.Graphics.DrawString("Transaction ID", PrintItemsFont, Brushes.Black, PrintX, PrintY)
        PrintX = 400
        e.Graphics.DrawString("Date", PrintItemsFont, Brushes.Black, PrintX, PrintY)
        PrintX = 550
        e.Graphics.DrawString("Part Number", PrintItemsFont, Brushes.Black, PrintX, PrintY)
        PrintX = 700
        e.Graphics.DrawString("Project ID", PrintItemsFont, Brushes.Black, PrintX, PrintY)
        PrintX = 850
        e.Graphics.DrawString("Quantity", PrintItemsFont, Brushes.Black, PrintX, PrintY)
        PrintY = PrintY + HeadingLineHeight

        'beginnin the loop
        For intCounter = intStartingPageCounter To mintStructureCounter

            PrintX = 100
            e.Graphics.DrawString(structTransactionCheck(intCounter).mstrTableType, PrintItemsFont, Brushes.Black, PrintX, PrintY)
            PrintX = 250
            e.Graphics.DrawString(structTransactionCheck(intCounter).mstrTransactionID, PrintItemsFont, Brushes.Black, PrintX, PrintY)
            PrintX = 400
            e.Graphics.DrawString(structTransactionCheck(intCounter).mstrDate, PrintItemsFont, Brushes.Black, PrintX, PrintY)
            PrintX = 550
            e.Graphics.DrawString(structTransactionCheck(intCounter).mstrPartNumber, PrintItemsFont, Brushes.Black, PrintX, PrintY)
            PrintX = 700
            e.Graphics.DrawString(structTransactionCheck(intCounter).mstrProjectID, PrintItemsFont, Brushes.Black, PrintX, PrintY)
            PrintX = 850
            e.Graphics.DrawString(structTransactionCheck(intCounter).mstrQuantity, PrintItemsFont, Brushes.Black, PrintX, PrintY)
            PrintY = PrintY + ItemLineHeight
            PrintX = 100
            e.Graphics.DrawString("Missing Element " + structTransactionCheck(intCounter).mstrProblem, PrintItemsFont, Brushes.Black, PrintX, PrintY)
            PrintX = 550
            e.Graphics.DrawString("Warehouse ID " + structTransactionCheck(intCounter).mstrWarehouseID, PrintItemsFont, Brushes.Black, PrintX, PrintY)
            PrintY = PrintY + HeadingLineHeight

            'Setting up for multiple pages
            If PrintY > 700 Then
                If intCounter = mintNewPrintCounter Then
                    e.HasMorePages = False
                Else
                    e.HasMorePages = True
                    blnNewPage = True
                End If
            End If
            If blnNewPage = True Then
                mintNewPrintCounter = intCounter + 1
                intCounter = mintStructureCounter
            End If

        Next

    End Sub

    Private Sub btnUtilitiesMenu_Click(sender As Object, e As EventArgs) Handles btnUtilitiesMenu.Click
        LastTransaction.Show()
        UtilitiesMenu.Show()
        Me.Close()
    End Sub

    Private Sub btnAdminMenu_Click(sender As Object, e As EventArgs) Handles btnAdminMenu.Click
        LastTransaction.Show()
        AdministrativeMenu.Show()
        Me.Close()
    End Sub
End Class