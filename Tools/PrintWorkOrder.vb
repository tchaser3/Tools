'Title:         Print Work Order
'Date:          11-12-14
'Author:        Terry Holmes

'This will allow the user to print a work order

Option Strict On

Public Class PrintWorkOrder

    'Setting up global variables
    Private TheVehicleRepairsDataSet As VehicleRepairsDataSet
    Private TheVehicleRepairsDataTier As VehicleRepairsDataTier
    Private WithEvents TheVehicleRepairsBindingSource As BindingSource

    Private TheVendorsDataSet As VendorsDataSet
    Private TheVendorsDataTier As VendorDataTier
    Private WithEvents TheVendorsBindingSource As BindingSource

    Private TheVehiclesDataSet As VehiclesDataSet
    Private TheVehiclesDataTier As VehiclesDataTier
    Private WithEvents TheVehiclesBindingSource As BindingSource

    Private addingBoolean As Boolean = False
    Private editingBoolean As Boolean = False
    Private previousSelectedIndex As Integer

    Dim TheInputDataValidation As New InputDataValidation

    Dim mintCounter As Integer
    Dim mintUpperLimit As Integer
    Dim mintSelectedIndex(1000) As Integer

    Private Sub PrintWorkOrder_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'This will load up when the form is launced

        'Try catch to load up the controls
        Try

            'Setting up the vehicle controls
            TheVehiclesDataTier = New VehiclesDataTier
            TheVehiclesDataSet = TheVehiclesDataTier.GetVehiclesInformation
            TheVehiclesBindingSource = New BindingSource

            'Setting up the binding source
            With TheVehiclesBindingSource
                .DataSource = TheVehiclesDataSet
                .DataMember = "vehicles"
                .MoveFirst()
                .MoveLast()
            End With

            'Setting up the combo box
            With cboVehicleID
                .DataSource = TheVehiclesBindingSource
                .DisplayMember = "VehicleID"
                .DataBindings.Add("text", TheVehiclesBindingSource, "VehicleID", False, DataSourceUpdateMode.Never)
            End With

            'Setting up the rest of the controls
            txtVehicleActive.DataBindings.Add("text", TheVehiclesBindingSource, "Active")
            txtVehicleBJCNumber.DataBindings.Add("text", TheVehiclesBindingSource, "BJCNumber")
            txtVehicleDownForRepairs.DataBindings.Add("text", TheVehiclesBindingSource, "DownForRepairs")
            txtVehicleNotes.DataBindings.Add("text", TheVehiclesBindingSource, "Notes")

            'Binding the Vendor Information
            TheVendorsDataTier = New VendorDataTier
            TheVendorsDataSet = TheVendorsDataTier.GetVendorsinformation
            TheVendorsBindingSource = New BindingSource

            'Setting up the binding source
            With TheVendorsBindingSource
                .DataSource = TheVendorsDataSet
                .DataMember = "vendors"
                .MoveFirst()
                .MoveLast()
            End With

            'Setting up the combo box
            With cboVendorName
                .DataSource = TheVendorsBindingSource
                .DisplayMember = "VendorName"
                .DataBindings.Add("text", TheVendorsBindingSource, "VendorName", False, DataSourceUpdateMode.Never)
            End With

            'binding the remaining vendor control
            txtVendorTableID.DataBindings.Add("text", TheVendorsBindingSource, "VendorID")

            'Setting up the work order controls and binding
            TheVehicleRepairsDataTier = New VehicleRepairsDataTier
            TheVehicleRepairsDataSet = TheVehicleRepairsDataTier.GetVehicleRepairsInformation
            TheVehicleRepairsBindingSource = New BindingSource

            'Setting up the binding source
            With TheVehicleRepairsBindingSource
                .DataSource = TheVehicleRepairsDataSet
                .DataMember = "vehiclerepairs"
                .MoveFirst()
                .MoveLast()
            End With

            'Setting up the combo box
            With cboTransactionID
                .DataSource = TheVehicleRepairsBindingSource
                .DisplayMember = "TransactionID"
                .DataBindings.Add("text", TheVehicleRepairsBindingSource, "TransactionID", False, DataSourceUpdateMode.Never)
            End With

            'Binding the Rest of the Controls
            txtWorkOrderDateReported.DataBindings.Add("text", TheVehicleRepairsBindingSource, "DateReported")
            txtWorkOrderNotes.DataBindings.Add("text", TheVehicleRepairsBindingSource, "Notes")
            txtWorkOrderOdometer.DataBindings.Add("text", TheVehicleRepairsBindingSource, "Odometer")
            txtWorkOrderProblemDescription.DataBindings.Add("text", TheVehicleRepairsBindingSource, "ProblemDescription")
            txtWorkOrderStatus.DataBindings.Add("text", TheVehicleRepairsBindingSource, "Status")
            txtWorkOrderVehicleID.DataBindings.Add("text", TheVehicleRepairsBindingSource, "VehicleID")
            txtWorkOrderVendorID.DataBindings.Add("text", TheVehicleRepairsBindingSource, "VendorID")
            txtWorkOrderDateInvoicedReceived.DataBindings.Add("text", TheVehicleRepairsBindingSource, "DateInvoiced")
            txtWorkOrderInvoiceNumber.DataBindings.Add("text", TheVehicleRepairsBindingSource, "InvoiceNumber")
            txtWorkOrderDateInvoiceTurnedIn.DataBindings.Add("text", TheVehicleRepairsBindingSource, "DateTurnedIN")
            txtWorkOrderDateRepairBegan.DataBindings.Add("text", TheVehicleRepairsBindingSource, "DateRepairBegan")
            txtWorkOrderDateRepairCompleted.DataBindings.Add("text", TheVehicleRepairsBindingSource, "DateRepairComplete")
            txtWorkOrderDateReturned.DataBindings.Add("text", TheVehicleRepairsBindingSource, "DateVehicleReturnedService")

            'Beginning Search for the Work Order
            FindRecords()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub FindRecords()

        'Setting local variables
        Dim intWorkOrderCounter As Integer
        Dim intWorkOrderNumberOfRecords As Integer
        Dim intWorkorderNumberForSearch As Integer
        Dim intWorkOrderNumberFromTable As Integer
        Dim intWorkOrderSelectedIndex As Integer
        Dim intVehicleCounter As Integer
        Dim intVehicleNumberOfRecords As Integer
        Dim intVehicleIDForSearch As Integer
        Dim intVehicleIDFromTable As Integer
        Dim intVehicleSelectedIndex As Integer
        Dim intVendorCounter As Integer
        Dim intVendorNumberOfRecords As Integer
        Dim intVendorIDForSearch As Integer
        Dim intVendorIDFromTable As Integer
        Dim intVendorSelectedIndex As Integer

        'Getting Combo Count Boxes
        intWorkOrderNumberOfRecords = cboTransactionID.Items.Count - 1
        intVehicleNumberOfRecords = cboVehicleID.Items.Count - 1
        intVendorNumberOfRecords = cboVendorName.Items.Count - 1
        intWorkorderNumberForSearch = CInt(Logon.mintWorkOrderNumber)

        'Beginning loop for the work orders
        For intWorkOrderCounter = 0 To intWorkOrderNumberOfRecords

            'incrementing the combo counter
            cboTransactionID.SelectedIndex = intWorkOrderCounter
            intWorkOrderNumberFromTable = CInt(cboTransactionID.Text)

            'If statement to see if it matches
            If intWorkOrderNumberFromTable = intWorkorderNumberForSearch Then
                intWorkOrderSelectedIndex = intWorkOrderCounter
            End If

        Next

        'Setting the location of the combo box
        cboTransactionID.SelectedIndex = intWorkOrderSelectedIndex

        'Getting information to find the Vehicle ID
        intVehicleIDForSearch = CInt(txtWorkOrderVehicleID.Text)

        'Getting information to find the Vendor ID
        intVendorIDForSearch = CInt(txtWorkOrderVendorID.Text)

        'Beginning search for the vehicle
        For intVehicleCounter = 0 To intVehicleNumberOfRecords

            'Incrementing the vehicle combo box
            cboVehicleID.SelectedIndex = intVehicleCounter
            intVehicleIDFromTable = CInt(cboVehicleID.Text)

            'Checking to see if it works
            If intVehicleIDForSearch = intVehicleIDFromTable Then
                intVehicleSelectedIndex = intVehicleCounter
            End If

        Next

        'Setting the combo box selected index
        cboVehicleID.SelectedIndex = intVehicleSelectedIndex

        'Searching for the vendor id
        For intVendorCounter = 0 To intVendorNumberOfRecords

            'Incrementing the combo box
            cboVendorName.SelectedIndex = intVendorCounter
            intVendorIDFromTable = CInt(txtVendorTableID.Text)

            If intVendorIDForSearch = intVendorIDFromTable Then
                intVendorSelectedIndex = intVendorCounter
            End If
        Next

        cboVendorName.SelectedIndex = intVendorSelectedIndex
        PrintDocument()
    End Sub
    Private Sub PrintDocument()

        'Setting up the print diaglog box
        PrintDialog1.PrinterSettings = PrintDocument1.PrinterSettings

        If PrintDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            PrintDocument1.PrinterSettings = PrintDialog1.PrinterSettings
        End If

        PrintDocument1.Print()

        Me.Close()

    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage

        'Setting up variables for printing
        Dim PrintHeaderFont As New Font("Arial", 18, FontStyle.Bold)
        Dim PrintSubHeaderFont As New Font("Arial", 14, FontStyle.Bold)
        Dim PrintItems As New Font("Arial", 10, FontStyle.Regular)
        Dim PrintX As Single = e.MarginBounds.Left
        Dim PrintY As Single = e.MarginBounds.Top
        Dim HeadingLineHeight As Single = PrintHeaderFont.GetHeight + 10
        Dim ItemLineHeight As Single = PrintItems.GetHeight + 5

        Dim intCharArrayCounter As Integer
        Dim chaCharacterArray() As Char
        Dim strKeyStringToBuild As String = ""
        Dim intTotalNumberOfCharacters As Integer
        Dim intStartingCount As Integer = 0
        Dim intSecondCounter As Integer
        Dim intCounter As Integer
        Dim intNumberOfLoops As Integer
        Dim intStringSizeLimit As Integer = 70

        'Setting the Y coordinate
        PrintY = 100

        PrintX = 125
        e.Graphics.DrawString("Blue Jay Communications Vehicle Work Order", PrintHeaderFont, Brushes.Black, PrintX, PrintY)
        PrintY = PrintY + HeadingLineHeight
        PrintX = 225
        e.Graphics.DrawString("Work Order Number: " + cboTransactionID.Text, PrintHeaderFont, Brushes.Black, PrintX, PrintY)
        PrintY = PrintY + HeadingLineHeight
        PrintY = PrintY + HeadingLineHeight

        'Start in the Vehicle report
        PrintX = 100
        e.Graphics.DrawString("BJC Number:", PrintItems, Brushes.Black, PrintX, PrintY)
        PrintX = 250
        e.Graphics.DrawString(txtVehicleBJCNumber.Text, PrintItems, Brushes.Black, PrintX, PrintY)
        PrintX = 450
        e.Graphics.DrawString("Date Repoted:", PrintItems, Brushes.Black, PrintX, PrintY)
        PrintX = 600
        e.Graphics.DrawString(txtWorkOrderDateReported.Text, PrintItems, Brushes.Black, PrintX, PrintY)
        PrintY = PrintY + ItemLineHeight

        PrintX = 100
        e.Graphics.DrawString("Date Repair Began:", PrintItems, Brushes.Black, PrintX, PrintY)
        PrintX = 250
        e.Graphics.DrawString(txtWorkOrderDateRepairBegan.Text, PrintItems, Brushes.Black, PrintX, PrintY)
        PrintX = 450
        e.Graphics.DrawString("Date Repair Complete:", PrintItems, Brushes.Black, PrintX, PrintY)
        PrintX = 600
        e.Graphics.DrawString(txtWorkOrderDateRepairCompleted.Text, PrintItems, Brushes.Black, PrintX, PrintY)
        PrintY = PrintY + ItemLineHeight

        PrintX = 100
        e.Graphics.DrawString("Date Invoice Received:", PrintItems, Brushes.Black, PrintX, PrintY)
        PrintX = 250
        e.Graphics.DrawString(txtWorkOrderDateInvoicedReceived.Text, PrintItems, Brushes.Black, PrintX, PrintY)
        PrintX = 450
        e.Graphics.DrawString("Date Invoice Turned In:", PrintItems, Brushes.Black, PrintX, PrintY)
        PrintX = 600
        e.Graphics.DrawString(txtWorkOrderDateInvoiceTurnedIn.Text, PrintItems, Brushes.Black, PrintX, PrintY)
        PrintY = PrintY + ItemLineHeight

        PrintX = 100
        e.Graphics.DrawString("Invoice Number:", PrintItems, Brushes.Black, PrintX, PrintY)
        PrintX = 250
        e.Graphics.DrawString(txtWorkOrderInvoiceNumber.Text, PrintItems, Brushes.Black, PrintX, PrintY)
        PrintX = 450
        e.Graphics.DrawString("Vehicle ID:", PrintItems, Brushes.Black, PrintX, PrintY)
        PrintX = 600
        e.Graphics.DrawString(cboVehicleID.Text, PrintItems, Brushes.Black, PrintX, PrintY)
        PrintY = PrintY + ItemLineHeight

        PrintX = 100
        e.Graphics.DrawString("Odometer:", PrintItems, Brushes.Black, PrintX, PrintY)
        PrintX = 250
        e.Graphics.DrawString(txtWorkOrderOdometer.Text, PrintItems, Brushes.Black, PrintX, PrintY)
        PrintX = 450
        e.Graphics.DrawString("Status:", PrintItems, Brushes.Black, PrintX, PrintY)
        PrintX = 600
        e.Graphics.DrawString(txtWorkOrderStatus.Text, PrintItems, Brushes.Black, PrintX, PrintY)
        PrintY = PrintY + ItemLineHeight

        PrintX = 100
        e.Graphics.DrawString("Vendor ID:", PrintItems, Brushes.Black, PrintX, PrintY)
        PrintX = 250
        e.Graphics.DrawString(txtVendorTableID.Text, PrintItems, Brushes.Black, PrintX, PrintY)
        PrintX = 450
        e.Graphics.DrawString("Vendor Name:", PrintItems, Brushes.Black, PrintX, PrintY)
        PrintX = 600
        e.Graphics.DrawString(cboVendorName.Text, PrintItems, Brushes.Black, PrintX, PrintY)
        PrintY = PrintY + ItemLineHeight

        PrintY = PrintY + HeadingLineHeight

        PrintX = 100
        e.Graphics.DrawString("Problem Description", PrintHeaderFont, Brushes.Black, PrintX, PrintY)
        PrintY = PrintY + HeadingLineHeight

        PrintX = 100

        'loading up the character array
        chaCharacterArray = txtWorkOrderProblemDescription.Text.ToCharArray

        'Getting the total number of loops
        intTotalNumberOfCharacters = txtWorkOrderProblemDescription.Text.Length - 1
        intNumberOfLoops = CInt(intTotalNumberOfCharacters / 70)

        'First Counter for the number of loops
        For intCounter = 0 To intNumberOfLoops

            'Second Counter for loading up the string
            For intSecondCounter = intStartingCount To intTotalNumberOfCharacters

                'Creating the string
                strKeyStringToBuild = strKeyStringToBuild + chaCharacterArray(intSecondCounter)

                intCharArrayCounter += 1

                'If statement to determine how to print
                If intCharArrayCounter = intStringSizeLimit Then
                    If chaCharacterArray(intSecondCounter) <> " " Then
                        intStringSizeLimit += 1
                    Else
                        intCharArrayCounter = 0
                        e.Graphics.DrawString(strKeyStringToBuild, PrintItems, Brushes.Black, PrintX, PrintY)
                        PrintY = PrintY + ItemLineHeight
                        intStringSizeLimit = 70
                        intStartingCount = intSecondCounter + 1
                        intSecondCounter = intTotalNumberOfCharacters
                        strKeyStringToBuild = ""
                    End If
                ElseIf intSecondCounter = intTotalNumberOfCharacters Then
                    'Printing the string
                    intCharArrayCounter = 0
                    e.Graphics.DrawString(strKeyStringToBuild, PrintItems, Brushes.Black, PrintX, PrintY)
                    PrintY = PrintY + ItemLineHeight
                    intStringSizeLimit = 70
                    intStartingCount = intSecondCounter + 1
                    intSecondCounter = intTotalNumberOfCharacters
                    strKeyStringToBuild = ""

                End If
            Next
        Next

        PrintY = PrintY + HeadingLineHeight

        intStringSizeLimit = 70
        intStartingCount = 0

        PrintX = 100
        e.Graphics.DrawString("Notes", PrintHeaderFont, Brushes.Black, PrintX, PrintY)
        PrintY = PrintY + HeadingLineHeight

        'loading up the character array
        chaCharacterArray = txtWorkOrderNotes.Text.ToCharArray

        'Getting the total number of loops
        intTotalNumberOfCharacters = txtWorkOrderNotes.Text.Length - 1
        intNumberOfLoops = CInt(intTotalNumberOfCharacters / 70)

        'First Counter for the number of loops
        For intCounter = 0 To intNumberOfLoops

            'Second Counter for loading up the string
            For intSecondCounter = intStartingCount To intTotalNumberOfCharacters

                'Creating the string
                strKeyStringToBuild = strKeyStringToBuild + chaCharacterArray(intSecondCounter)

                intCharArrayCounter += 1

                'If statement to determine how to print
                If intCharArrayCounter = intStringSizeLimit Then
                    If chaCharacterArray(intSecondCounter) <> " " Then
                        intStringSizeLimit += 1
                    Else
                        intCharArrayCounter = 0
                        e.Graphics.DrawString(strKeyStringToBuild, PrintItems, Brushes.Black, PrintX, PrintY)
                        PrintY = PrintY + ItemLineHeight
                        intStringSizeLimit = 70
                        intStartingCount = intSecondCounter + 1
                        intSecondCounter = intTotalNumberOfCharacters
                        strKeyStringToBuild = ""
                    End If
                ElseIf intSecondCounter = intTotalNumberOfCharacters Then
                    'Printing the string
                    intCharArrayCounter = 0
                    e.Graphics.DrawString(strKeyStringToBuild, PrintItems, Brushes.Black, PrintX, PrintY)
                    PrintY = PrintY + ItemLineHeight
                    intStringSizeLimit = 70
                    intStartingCount = intSecondCounter + 1
                    intSecondCounter = intTotalNumberOfCharacters
                    strKeyStringToBuild = ""

                End If
            Next
        Next

    End Sub
End Class
