'Title:         Open Vehicle Work Order Report
'Date:          11-2-15
'Author:        Terry Holmes

'Description:   This form is used to create the Open Vehicle Work Order Report

Option Strict On

Public Class OpenVehicleWorkOrderReport

    'setting up the global variables
    Private TheVehicleDataSet As VehiclesDataSet
    Private TheVehicleDataTier As VehiclesDataTier
    Private WithEvents TheVehicleBindingSource As BindingSource

    Structure Vehicles
        Dim mintBJCNumber As Integer
        Dim mintVehicleID As Integer
    End Structure

    Dim structVehicles() As Vehicles
    Dim mintVehicleCounter As Integer
    Dim mintVehicleUpperLimit As Integer

    Private TheVehicleRepairsDataSet As VehicleRepairsDataSet
    Private TheVehicleRepairsDataTier As VehicleRepairsDataTier
    Private WithEvents TheVehicleRepairsBindingSource As BindingSource

    Structure OpenWorkOrders
        Dim mintTransactionID As Integer
        Dim mintVehicleID As Integer
        Dim mintVendorID As Integer
        Dim mintOdometer As Integer
        Dim mstrProblemDescription As String
        Dim mdatDateReported As Date
    End Structure

    Dim structOpenWorkOrders() As OpenWorkOrders
    Dim mintOpenOrderCounter As Integer
    Dim mintOpenOrderUpperLimit As Integer

    Dim mstrErrorMessage As String

    Structure SearchResults
        Dim mintTransactionID As Integer
        Dim mintBJCNumber As Integer
        Dim mintOdometer As Integer
        Dim mstrProblemDescription As String
        Dim mdatDateReported As Date
        Dim mstrAssignedVendor As String
    End Structure

    Dim structSearchResults() As SearchResults
    Dim mintResultCounter As Integer
    Dim mintResultUpperLimit As Integer

    Private TheVendorDataSet As VendorsDataSet
    Private TheVendorDataTier As VendorDataTier
    Private WithEvents TheVendorBindingSource As BindingSource

    Structure Vendors
        Dim mintVendorID As Integer
        Dim mstrVendorName As String
    End Structure

    Dim structVendors() As Vendors
    Dim mintVendorCounter As Integer
    Dim mintVendorUpperLimit As Integer

    Dim mintNewPrintCounter As Integer
    Dim TheDateSearchClass As New DateSearchClass

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        CloseTheProgram.ShowDialog()
    End Sub

    Private Sub btnMainMenu_Click(sender As Object, e As EventArgs) Handles btnMainMenu.Click
        LastTransaction.Show()
        MainMenu.Show()
        Me.Close()
    End Sub

    Private Sub btnMaintenanceMenu_Click(sender As Object, e As EventArgs) Handles btnMaintenanceMenu.Click
        LastTransaction.Show()
        MaintenanceMenu.Show()
        Me.Close()
    End Sub

    Private Sub btnMaintenanceReportMenu_Click(sender As Object, e As EventArgs) Handles btnMaintenanceReportMenu.Click
        LastTransaction.Show()
        MaintenanceReports.Show()
        Me.Close()
    End Sub

    Private Sub OpenVehicleWorkOrderReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'setting local variables
        Dim blnFatalError As Boolean = False

        PleaseWait.Show()

        Logon.mstrLastTransactionSummary = "Loaded the Open Work Order Report"
        ClearDataBindings()

        blnFatalError = LoadVendorStructure()
        If blnFatalError = False Then
            ClearDataBindings()
            blnFatalError = LoadVehicleStructure()
        End If
        If blnFatalError = False Then
            ClearDataBindings()
            blnFatalError = LoadOpenWorkOrderStructure()
        End If
        If blnFatalError = False Then
            LoadGridView()
        End If

        PleaseWait.Close()

        If blnFatalError = True Then
            MessageBox.Show(mstrErrorMessage, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            btnPrintReport.Enabled = False
            SetControlsInvisible()
        End If

    End Sub
    Private Sub LoadGridView()

        Dim intOpenOrderCounter As Integer
        Dim intVehicleCounter As Integer
        Dim intVendorCounter As Integer
        Dim intResultCounter As Integer
        Dim intVehicleIDForSearch As Integer
        Dim intVehicleIDFromTable As Integer
        Dim intVendorIDForSearch As Integer
        Dim intVendorIDFromTable As Integer
        Dim rows() As String

        'creating the grid
        dgvSearchResults.ColumnCount = 6
        dgvSearchResults.Columns(0).Name = "Transaction ID"
        dgvSearchResults.Columns(0).Width = 75
        dgvSearchResults.Columns(1).Name = "BJC Number"
        dgvSearchResults.Columns(1).Width = 75
        dgvSearchResults.Columns(2).Name = "Odometer"
        dgvSearchResults.Columns(2).Width = 75
        dgvSearchResults.Columns(3).Name = "Date Reported"
        dgvSearchResults.Columns(3).Width = 75
        dgvSearchResults.Columns(4).Name = "Problem Description"
        dgvSearchResults.Columns(4).Width = 200
        dgvSearchResults.Columns(5).Name = "Assigned Vendor"
        dgvSearchResults.Columns(5).Width = 150

        mintResultCounter = 0

        'beginning loop
        For intOpenOrderCounter = 0 To mintOpenOrderUpperLimit

            structSearchResults(mintResultCounter).mdatDateReported = structOpenWorkOrders(intOpenOrderCounter).mdatDateReported
            structSearchResults(mintResultCounter).mstrProblemDescription = structOpenWorkOrders(intOpenOrderCounter).mstrProblemDescription
            structSearchResults(mintResultCounter).mintTransactionID = structOpenWorkOrders(intOpenOrderCounter).mintTransactionID
            structSearchResults(mintResultCounter).mintOdometer = structOpenWorkOrders(intOpenOrderCounter).mintOdometer

            'getting ready to the assigned vendor
            intVendorIDForSearch = structOpenWorkOrders(intOpenOrderCounter).mintVendorID

            'peforming loop
            For intVendorCounter = 0 To mintVendorUpperLimit

                'getting the vendor id from structure
                intVendorIDFromTable = structVendors(intVendorCounter).mintVendorID

                If intVendorIDFromTable = intVendorIDForSearch Then
                    structSearchResults(mintResultCounter).mstrAssignedVendor = structVendors(intVendorCounter).mstrVendorName

                End If
            Next

            'getting the vehicle id
            intVehicleIDForSearch = structOpenWorkOrders(intOpenOrderCounter).mintVehicleID

            'beforming loop
            For intVehicleCounter = 0 To mintVehicleUpperLimit

                intVehicleIDFromTable = structVehicles(intVehicleCounter).mintVehicleID

                If intVehicleIDFromTable = intVehicleIDForSearch Then
                    structSearchResults(mintResultCounter).mintBJCNumber = structVehicles(intVehicleCounter).mintBJCNumber
                End If

            Next

            mintResultCounter += 1

        Next

        mintResultUpperLimit = mintResultCounter - 1

        'filling the grid view
        For intResultCounter = 0 To mintResultUpperLimit

            'this will load the structure
            rows = New String() {CStr(structSearchResults(intResultCounter).mintTransactionID), CStr(structSearchResults(intResultCounter).mintBJCNumber), CStr(structSearchResults(intResultCounter).mintOdometer), CStr(structSearchResults(intResultCounter).mdatDateReported), structSearchResults(intResultCounter).mstrProblemDescription, structSearchResults(intResultCounter).mstrAssignedVendor}
            dgvSearchResults.Rows.Add(rows)

        Next

    End Sub
    Private Function LoadOpenWorkOrderStructure() As Boolean

        'setting local variables
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim blnFatalError As Boolean = False
        Dim strStatus As String
        Dim blnNoOpenOrders = True

        'try catch for exceptions
        Try

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
            txtDateReported.DataBindings.Add("text", TheVehicleRepairsBindingSource, "DateReported")
            txtOdometer.DataBindings.Add("text", TheVehicleRepairsBindingSource, "Odometer")
            txtProblemDescription.DataBindings.Add("text", TheVehicleRepairsBindingSource, "ProblemDescription")
            txtStatus.DataBindings.Add("text", TheVehicleRepairsBindingSource, "Status")
            txtVehicleID.DataBindings.Add("text", TheVehicleRepairsBindingSource, "VehicleID")
            txtVendorID.DataBindings.Add("text", TheVehicleRepairsBindingSource, "VendorID")

            'setting up the structures
            intNumberOfRecords = cboTransactionID.Items.Count - 1
            ReDim structOpenWorkOrders(intNumberOfRecords)
            ReDim structSearchResults(intNumberOfRecords)
            mintOpenOrderCounter = 0

            'beginning loop
            For intCounter = 0 To intNumberOfRecords

                'incrementing the combo box
                cboTransactionID.SelectedIndex = intCounter

                'getting the work order status
                strStatus = txtStatus.Text

                If strStatus = "OPEN" Then

                    'loading the structure
                    structOpenWorkOrders(mintOpenOrderCounter).mintOdometer = CInt(txtOdometer.Text)
                    structOpenWorkOrders(mintOpenOrderCounter).mintTransactionID = CInt(cboTransactionID.Text)
                    structOpenWorkOrders(mintOpenOrderCounter).mintVehicleID = CInt(txtVehicleID.Text)
                    structOpenWorkOrders(mintOpenOrderCounter).mintVendorID = CInt(txtVendorID.Text)
                    structOpenWorkOrders(mintOpenOrderCounter).mdatDateReported = CDate(txtDateReported.Text)
                    structOpenWorkOrders(mintOpenOrderCounter).mstrProblemDescription = txtProblemDescription.Text
                    mintOpenOrderCounter += 1
                    blnNoOpenOrders = False

                End If

            Next

            If blnNoOpenOrders = True Then
                mstrErrorMessage = "No Open Work Orders Were Found"
                blnFatalError = True
            ElseIf blnNoOpenOrders = False Then
                mintOpenOrderUpperLimit = mintOpenOrderCounter - 1
                mintOpenOrderCounter = 0
            End If

            'returning information to calling sub routine
            Return blnFatalError

        Catch ex As Exception

            'returning bad information to call sub routine
            mstrErrorMessage = ex.Message
            blnFatalError = True
            Return blnFatalError

        End Try

    End Function
    Private Function LoadVehicleStructure() As Boolean

        'setting local variables
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim blnFatalError As Boolean = False
        Dim strActive As String

        'try catch for exceptions
        Try

            'setting data variables
            TheVehicleDataTier = New VehiclesDataTier
            TheVehicleDataSet = TheVehicleDataTier.GetVehiclesInformation
            TheVehicleBindingSource = New BindingSource

            'setting up the binding source
            With TheVehicleBindingSource
                .DataSource = TheVehicleDataSet
                .DataMember = "vehicles"
                .MoveFirst()
                .MoveLast()
            End With

            'setting up the transaction id
            With cboTransactionID
                .DataSource = TheVehicleBindingSource
                .DisplayMember = "VehicleID"
                .DataBindings.Add("text", TheVehicleBindingSource, "VehicleID", False, DataSourceUpdateMode.Never)
            End With

            txtVehicleID.DataBindings.Add("text", TheVehicleBindingSource, "BJCNumber")
            txtStatus.DataBindings.Add("text", TheVehicleBindingSource, "Active")

            'loading up the structure
            intNumberOfRecords = cboTransactionID.Items.Count - 1
            ReDim structVehicles(intNumberOfRecords)
            mintVehicleCounter = 0

            'Running loop
            For intCounter = 0 To intNumberOfRecords

                'incrementing the combo box
                cboTransactionID.SelectedIndex = intCounter

                strActive = txtStatus.Text

                If strActive = "YES" Then
                    structVehicles(mintVehicleCounter).mintVehicleID = CInt(cboTransactionID.Text)
                    structVehicles(mintVehicleCounter).mintBJCNumber = CInt(txtVehicleID.Text)
                    mintVehicleCounter += 1
                End If

            Next

            'setting up the variables
            mintVehicleUpperLimit = mintVehicleCounter - 1
            mintVehicleCounter = 0

            'returning value to calling sub routine
            Return blnFatalError

        Catch ex As Exception

            'Return information if there is a failure
            mstrErrorMessage = ex.Message
            blnFatalError = True
            Return blnFatalError

        End Try

    End Function
    Private Function LoadVendorStructure() As Boolean

        'Setting Local Variables
        Dim blnFatalError As Boolean = False
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer

        'try catch for exceptions
        Try

            'setting up the data controls
            TheVendorDataTier = New VendorDataTier
            TheVendorDataSet = TheVendorDataTier.GetVendorsinformation
            TheVendorBindingSource = New BindingSource

            'setting up the binding source
            With TheVendorBindingSource
                .DataSource = TheVendorDataSet
                .DataMember = "vendors"
                .MoveFirst()
                .MoveLast()
            End With

            'setting up the combo box
            With cboTransactionID
                .DataSource = TheVendorBindingSource
                .DisplayMember = "VendorID"
                .DataBindings.Add("text", TheVendorBindingSource, "VendorID", False, DataSourceUpdateMode.Never)
            End With

            txtProblemDescription.DataBindings.Add("text", TheVendorBindingSource, "VendorName")

            'getting ready to fill the vendor structure
            intNumberOfRecords = cboTransactionID.Items.Count - 1
            ReDim structVendors(intNumberOfRecords)
            mintVendorCounter = 0
            mintVendorUpperLimit = intNumberOfRecords

            'loop to load structure
            For intCounter = 0 To intNumberOfRecords

                'incrementing the combo box
                cboTransactionID.SelectedIndex = intCounter

                'loading the structure
                structVendors(intCounter).mintVendorID = CInt(cboTransactionID.Text)
                structVendors(intCounter).mstrVendorName = txtProblemDescription.Text
                mintVendorCounter += 1

            Next

            'returning value to calling sub routine
            Return blnFatalError

        Catch ex As Exception

            'message to the user
            mstrErrorMessage = ex.Message
            blnFatalError = True
            Return blnFatalError

        End Try
    End Function
    Private Sub ClearDataBindings()

        'clearing the data bindings
        cboTransactionID.DataBindings.Clear()
        txtDateReported.DataBindings.Clear()
        txtOdometer.DataBindings.Clear()
        txtProblemDescription.DataBindings.Clear()
        txtStatus.DataBindings.Clear()
        txtVehicleID.DataBindings.Clear()
        txtVendorID.DataBindings.Clear()

    End Sub
    Private Sub SetControlsInvisible()

        cboTransactionID.Visible = False
        txtDateReported.Visible = False
        txtOdometer.Visible = False
        txtProblemDescription.Visible = False
        txtStatus.Visible = False
        txtVehicleID.Visible = False
        txtVendorID.Visible = False

    End Sub
    Private Sub PrintDocument1_QueryPageSettings(sender As Object, e As Printing.QueryPageSettingsEventArgs) Handles PrintDocument1.QueryPageSettings

        'setting page to landscape
        e.PageSettings.Landscape = True

    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage

        'Setting up the local variables
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
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
        Dim datAdjustedDate As Date

        'Variables for looping the description
        Dim strNewString As String = ""
        Dim charNotesAray() As Char
        Dim intArrayLength As Integer
        Dim intNotesUpperLimit As Integer
        Dim intStartCharCount As Integer
        Dim intCharUpperLimit As Integer
        Dim intStringCounter As Integer
        Dim intCharCounter As Integer

        'Setting up for default position
        PrintY = 100

        'Setting up for the print header
        PrintX = 200
        e.Graphics.DrawString("Blue Jay Communications Open Vehicle Work Orders", PrintHeaderFont, Brushes.Black, PrintX, PrintY)
        PrintY = PrintY + HeadingLineHeight

        'Setting up the columns
        PrintX = 50
        e.Graphics.DrawString("Transaction ID", PrintItemsFont, Brushes.Black, PrintX, PrintY)
        PrintX = 150
        e.Graphics.DrawString("BJC Number", PrintItemsFont, Brushes.Black, PrintX, PrintY)
        PrintX = 250
        e.Graphics.DrawString("Odometer", PrintItemsFont, Brushes.Black, PrintX, PrintY)
        PrintX = 350
        e.Graphics.DrawString("Date", PrintItemsFont, Brushes.Black, PrintX, PrintY)
        PrintX = 450
        e.Graphics.DrawString("Problem Reported", PrintItemsFont, Brushes.Black, PrintX, PrintY)
        PrintX = 800
        e.Graphics.DrawString("Assigned Vendor", PrintItemsFont, Brushes.Black, PrintX, PrintY)
        PrintY = PrintY + ItemLineHeight

        'Setting up for multiple pages
        intStartingPageCounter = mintNewPrintCounter
        intNumberOfRecords = mintResultUpperLimit

        For intCounter = intStartingPageCounter To mintResultUpperLimit

            PrintX = 50
            e.Graphics.DrawString(CStr(structSearchResults(intCounter).mintTransactionID), PrintItemsFont, Brushes.Black, PrintX, PrintY)
            PrintX = 150
            e.Graphics.DrawString(CStr(structSearchResults(intCounter).mintBJCNumber), PrintItemsFont, Brushes.Black, PrintX, PrintY)
            PrintX = 250
            e.Graphics.DrawString(CStr(structSearchResults(intCounter).mintOdometer), PrintItemsFont, Brushes.Black, PrintX, PrintY)
            PrintX = 350
            datAdjustedDate = TheDateSearchClass.RemoveTime(structSearchResults(intCounter).mdatDateReported)
            e.Graphics.DrawString(CStr(datAdjustedDate), PrintItemsFont, Brushes.Black, PrintX, PrintY)
            PrintX = 800
            e.Graphics.DrawString(structSearchResults(intCounter).mstrAssignedVendor, PrintItemsFont, Brushes.Black, PrintX, PrintY)

            'setting up for spreading the notes out
            charNotesAray = structSearchResults(intCounter).mstrProblemDescription.ToCharArray
            intArrayLength = structSearchResults(intCounter).mstrProblemDescription.Length - 1

            'setting the upper limit
            intNotesUpperLimit = CInt(intArrayLength / 25) - 1

            If intNotesUpperLimit <= 0 Then

                PrintX = 450
                e.Graphics.DrawString(structSearchResults(intCounter).mstrProblemDescription, PrintItemsFont, Brushes.Black, PrintX, PrintY)
                PrintY = PrintY + ItemLineHeight

            ElseIf intNotesUpperLimit > 0 Then

                intStartCharCount = 0
                intCharUpperLimit = 25
                intStringCounter = 0
                strNewString = ""

                For intCharCounter = intStartCharCount To intArrayLength

                    strNewString = strNewString + CStr(charNotesAray(intCharCounter))
                    intStringCounter += 1
                    If intStringCounter = intCharUpperLimit Then
                        If charNotesAray(intCharCounter) <> " " Then
                            intCharUpperLimit += 1
                        End If
                    End If
                    If intStringCounter = intCharUpperLimit Then
                        PrintX = 450
                        e.Graphics.DrawString(strNewString, PrintItemsFont, Brushes.Black, PrintX, PrintY)
                        PrintY = PrintY + ItemLineHeight
                        strNewString = ""
                        intStringCounter = 0
                    End If
                    If intCharCounter = intArrayLength Then
                        PrintX = 450
                        e.Graphics.DrawString(strNewString, PrintItemsFont, Brushes.Black, PrintX, PrintY)
                        PrintY = PrintY + ItemLineHeight
                        strNewString = ""
                        intStringCounter = 0
                    End If
                Next
                'PrintY = PrintY + ItemLineHeight
            End If


            If PrintY > 750 Then
                If intStartingPageCounter = mintResultUpperLimit Then
                    e.HasMorePages = False
                Else
                    e.HasMorePages = True
                    blnNewPage = True
                End If
            End If

            If blnNewPage = True Then
                mintNewPrintCounter = intCounter + 1
                intCounter = mintResultCounter
            End If


        Next

    End Sub

    Private Sub btnPrintReport_Click(sender As Object, e As EventArgs) Handles btnPrintReport.Click


        'Setting up the print dialog
        If PrintDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            PrintDocument1.PrinterSettings = PrintDialog1.PrinterSettings
        End If

        'Making an entry showing that the report has been run
        Logon.mstrLastTransactionSummary = "RAN PARTS RECEIVED FOR A PROJECT REPORT"

        'Setting up for multiple pages
        mintNewPrintCounter = 0

        'Calling the print document
        PrintDocument1.Print()
    End Sub
End Class