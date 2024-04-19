'Title:         Daily Vehicle Inspection Report
'Date:          10-26-15
'Author:        Terry Holmes

'Description:   This is used to run a report on Daily Vehicle Inspections

Option Strict On

Public Class DailyVehicleInspectionReport

    Private TheVehicleInventorySheetDataSet As VehicleInventorySheetDataSet
    Private TheVehicleInventorySheetDataTier As VehicleInventorySheetDataTier
    Private WithEvents TheVehicleInventorySheetBindingSource As BindingSource

    Private TheVehiclesDataTier As VehiclesDataTier
    Private TheVehiclesDataSet As VehiclesDataSet
    Private WithEvents TheVehiclesBindingSource As BindingSource

    Private TheEmployeeDataTier As EmployeeDataTier
    Private TheEmployeeDataSet As EmployeeDataSet
    Private WithEvents TheEmployeeBindingSource As BindingSource

    Private TheVehicleHistoryDataTier As VehicleHistoryDataTier
    Private TheVehicleHistoryDataSet As VehicleHistoryDataSet
    Private WithEvents TheVehicleHistoryBindingSource As BindingSource

    'setting designed classes
    Dim TheDateSearchClass As New DateSearchClass
    Dim TheInputDataValidation As New InputDataValidation
    Dim TheKeyWordSearchClass As New KeyWordSearchClass

    Structure Employees
        Dim mintEmployeeID As Integer
        Dim mstrLastName As String
        Dim mstrFirstName As String
    End Structure

    Dim structEmployees() As Employees
    Dim mintEmployeeUpperLimit As Integer
    Dim mintEmployeeCounter As Integer

    'setting up the vehicle structure
    Structure Vehicles
        Dim mintVehicleID As Integer
        Dim mintEmployeeID As Integer
        Dim mintBJCNumber As Integer
        Dim mstrActive As String
    End Structure

    Dim structVehicles() As Vehicles
    Dim mintVehicleUpperLimit As Integer
    Dim mintVehicleCounter As Integer

    Structure SearchResults
        Dim mintBJCNumber As Integer
        Dim mstrFirstName As String
        Dim mstrLastName As String
        Dim mdatDate As Date
        Dim mintOdometerReading As Integer
        Dim mstrNotes As String
    End Structure

    Dim structSearchResults() As SearchResults
    Dim structTempResults() As SearchResults
    Dim mintResultCounter As Integer
    Dim mintResultUpperLimit As Integer

    Dim mstrErrorMessage As String
    Dim mintNewPrintCounter As Integer

    Structure VehicleHistory
        Dim mintVehicleID As Integer
        Dim mintEmployeeID As Integer
        Dim mintBJCNumber As Integer
        Dim mdatDate As Date
    End Structure

    Dim structVehicleHistory() As VehicleHistory
    Dim structTempHistory() As VehicleHistory
    Dim mintHistoryCounter As Integer
    Dim mintHistoryUpperLimit As Integer

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        CloseTheProgram.ShowDialog()
    End Sub

    Private Sub btnMainMenu_Click(sender As Object, e As EventArgs) Handles btnMainMenu.Click

        'this will open the main menu
        LastTransaction.Show()
        MainMenu.Show()
        Me.Close()

    End Sub

    Private Sub btnInspectionMenu_Click(sender As Object, e As EventArgs) Handles btnInspectionMenu.Click

        'this will open up the inspection menu
        LastTransaction.Show()
        InspectionsMenu.Show()
        Me.Close()

    End Sub

    Private Sub btnInspectionReportMenu_Click(sender As Object, e As EventArgs) Handles btnInspectionReportMenu.Click

        'this will open the inspection report menu
        LastTransaction.Show()
        VehicleInspectionReports.Show()
        Me.Close()

    End Sub

    Private Sub DailyVehicleInspectionReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'this will load the structures and controls
        Dim blnFatalError As Boolean = False

        PleaseWait.Show()

        ClearDataBindings()
        blnFatalError = SetEmployeeDataBindings()
        If blnFatalError = False Then
            ClearDataBindings()
            blnFatalError = SetVehicleDataBindings()
        End If
        If blnFatalError = False Then
            ClearDataBindings()
            blnFatalError = SetVehicleHistoryDataBindings()
        End If
        If blnFatalError = False Then
            ClearDataBindings()
            blnFatalError = SetVehicleInventoryDataBindings()
        End If

        PleaseWait.Close()

        If blnFatalError = True Then
            btnRunReport.Enabled = False
            MessageBox.Show(mstrErrorMessage, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub
    Private Function SetVehicleInventoryDataBindings() As Boolean

        'setting local variables
        Dim intTableCounter As Integer
        Dim intTableNumberOfRecords As Integer
        Dim intResultsCounter As Integer
        Dim intEmployeeCounter As Integer
        Dim intVehicleCounter As Integer
        Dim intHistoryCounter As Integer
        Dim datStartingDate As Date
        Dim datEndingDate As Date
        Dim datTableDate As Date
        Dim intDaysDifferance As Integer
        Dim blnNoItemsFound As Boolean = True
        Dim blnFatalError As Boolean = False
        Dim strProblemReported As String
        Dim intBJCNumberForSearch As Integer
        Dim intBJCNumberFromTable As Integer
        Dim intVehicleIDForSearch As Integer
        Dim intVehicleIDFromTable As Integer
        Dim intEmployeeIDForSearch As Integer
        Dim intEmployeeIDFromTable As Integer
        Dim blnNoVehicleHistory As Boolean
        Dim intDayCounter As Integer
        Dim rows() As String

        'try catch for exceptions
        Try

            'setting up global variables
            TheVehicleInventorySheetDataTier = New VehicleInventorySheetDataTier
            TheVehicleInventorySheetDataSet = TheVehicleInventorySheetDataTier.GetVehicleInventorySheetInformation
            TheVehicleInventorySheetBindingSource = New BindingSource

            'setting up the binding source
            With TheVehicleInventorySheetBindingSource
                .DataSource = TheVehicleInventorySheetDataSet
                .DataMember = "vehicleinventorysheet"
                .MoveFirst()
                .MoveLast()
            End With

            'setting up the combo source
            With cboTransactionID
                .DataSource = TheVehicleInventorySheetBindingSource
                .DisplayMember = "TransactionID"
                .DataBindings.Add("text", TheVehicleInventorySheetBindingSource, "TransactionID", False, DataSourceUpdateMode.Never)
            End With

            'setting up the rest of the controls
            txtBJCNumber.DataBindings.Add("text", TheVehicleInventorySheetBindingSource, "BJCNumber")
            txtDate.DataBindings.Add("Text", TheVehicleInventorySheetBindingSource, "Date")
            txtNotes.DataBindings.Add("Text", TheVehicleInventorySheetBindingSource, "Notes")
            txtOdometerReading.DataBindings.Add("text", TheVehicleInventorySheetBindingSource, "OdometerReading")
            txtProblemReported.DataBindings.Add("Text", TheVehicleInventorySheetBindingSource, "ProblemReported")

            'getting ready for the loop
            intTableNumberOfRecords = cboTransactionID.Items.Count - 1
            ReDim structTempResults(intTableNumberOfRecords)
            ReDim structSearchResults(intTableNumberOfRecords)
            mintResultCounter = 0
            datStartingDate = TheDateSearchClass.RemoveTime(Logon.mdatStartingDate)
            datEndingDate = TheDateSearchClass.RemoveTime(Logon.mdatEndingDate)

            'running loop
            For intTableCounter = 0 To intTableNumberOfRecords

                'incrementing the combo box
                cboTransactionID.SelectedIndex = intTableCounter

                'getting the date
                datTableDate = CDate(txtDate.Text)
                datTableDate = TheDateSearchClass.RemoveTime(datTableDate)
                strProblemReported = txtProblemReported.Text

                'if statements to determine if entry should be entered
                If datTableDate >= datStartingDate Then
                    If datTableDate <= datEndingDate Then
                        If strProblemReported = "YES" Then

                            blnNoItemsFound = False

                            structTempResults(mintResultCounter).mdatDate = datTableDate
                            structTempResults(mintResultCounter).mintBJCNumber = CInt(txtBJCNumber.Text)
                            structTempResults(mintResultCounter).mintOdometerReading = CInt(txtOdometerReading.Text)
                            structTempResults(mintResultCounter).mstrNotes = txtNotes.Text

                            'getting ready for the searching for the BJC Number
                            intBJCNumberForSearch = CInt(txtBJCNumber.Text)

                            'beginning to search vehicles
                            For intVehicleCounter = 0 To mintVehicleUpperLimit

                                'getting vehicle ID
                                intBJCNumberFromTable = structVehicles(intVehicleCounter).mintBJCNumber

                                If intBJCNumberFromTable = intBJCNumberForSearch Then

                                    blnNoVehicleHistory = True
                                    intVehicleIDForSearch = structVehicles(intVehicleCounter).mintVehicleID

                                    'Loop through the history
                                    For intHistoryCounter = 0 To mintHistoryUpperLimit

                                        'getting vehicle id
                                        intVehicleIDFromTable = structVehicleHistory(intHistoryCounter).mintVehicleID

                                        If intVehicleIDForSearch = intVehicleIDFromTable Then
                                            blnNoVehicleHistory = False

                                            'getting ready to find the Employee ID
                                            intEmployeeIDForSearch = structVehicleHistory(intHistoryCounter).mintEmployeeID

                                            'preforming loop
                                            For intEmployeeCounter = 0 To mintEmployeeUpperLimit

                                                intEmployeeIDFromTable = structEmployees(intEmployeeCounter).mintEmployeeID

                                                If intEmployeeIDForSearch = intEmployeeIDFromTable Then

                                                    structTempResults(mintResultCounter).mstrLastName = structEmployees(intEmployeeCounter).mstrLastName
                                                    structTempResults(mintResultCounter).mstrFirstName = structEmployees(intEmployeeCounter).mstrFirstName

                                                End If
                                            Next
                                        End If
                                    Next
                                End If

                                If blnNoVehicleHistory = True Then

                                    intEmployeeIDForSearch = structVehicles(intVehicleCounter).mintEmployeeID

                                    For intEmployeeCounter = 0 To mintEmployeeUpperLimit

                                        intEmployeeIDFromTable = structEmployees(intEmployeeCounter).mintEmployeeID

                                        If intEmployeeIDForSearch = intEmployeeIDFromTable Then

                                            structTempResults(mintResultCounter).mstrLastName = structEmployees(intEmployeeCounter).mstrLastName
                                            structTempResults(mintResultCounter).mstrFirstName = structEmployees(intEmployeeCounter).mstrFirstName
                                            blnNoVehicleHistory = False

                                        End If
                                    Next

                                End If

                            Next
                            mintResultCounter += 1
                        End If
                    End If
                End If
            Next

            'setting up to put them in order
            mintResultUpperLimit = mintResultCounter - 1
            mintResultCounter = 0
            datTableDate = datStartingDate
            intDaysDifferance = TheDateSearchClass.DaysDifference(datStartingDate, datEndingDate)

            'beginning first loop
            For intDayCounter = 0 To intDaysDifferance

                'beginning results loop
                For intResultsCounter = 0 To mintResultUpperLimit

                    If structTempResults(intResultsCounter).mdatDate = datTableDate Then
                        structSearchResults(mintResultCounter).mdatDate = structTempResults(intResultsCounter).mdatDate
                        structSearchResults(mintResultCounter).mintBJCNumber = structTempResults(intResultsCounter).mintBJCNumber
                        structSearchResults(mintResultCounter).mintOdometerReading = structTempResults(intResultsCounter).mintOdometerReading
                        structSearchResults(mintResultCounter).mstrFirstName = structTempResults(intResultsCounter).mstrFirstName
                        structSearchResults(mintResultCounter).mstrLastName = structTempResults(intResultsCounter).mstrLastName
                        structSearchResults(mintResultCounter).mstrNotes = structTempResults(intResultsCounter).mstrNotes
                        mintResultCounter += 1
                    End If

                Next

                'adding a day
                datTableDate = TheDateSearchClass.AddingDay(datTableDate, 1)

            Next

            'setting up the gridview
            dgvSearchResults.ColumnCount = 6
            dgvSearchResults.Columns(0).Name = "Date"
            dgvSearchResults.Columns(0).Width = 75
            dgvSearchResults.Columns(1).Name = "BJC Number"
            dgvSearchResults.Columns(1).Width = 75
            dgvSearchResults.Columns(2).Name = "First Name"
            dgvSearchResults.Columns(2).Width = 100
            dgvSearchResults.Columns(3).Name = "Last Name"
            dgvSearchResults.Columns(3).Width = 100
            dgvSearchResults.Columns(4).Name = "Odometer"
            dgvSearchResults.Columns(4).Width = 75
            dgvSearchResults.Columns(5).Name = "Notes"
            dgvSearchResults.Columns(5).Width = 200

            'filling the grid view
            For intResultsCounter = 0 To mintResultUpperLimit

                rows = New String() {CStr(structSearchResults(intResultsCounter).mdatDate), CStr(structSearchResults(intResultsCounter).mintBJCNumber), structSearchResults(intResultsCounter).mstrFirstName, structSearchResults(intResultsCounter).mstrLastName, CStr(structSearchResults(intResultsCounter).mintOdometerReading), structSearchResults(intResultsCounter).mstrNotes}
                dgvSearchResults.Rows.Add(rows)

            Next

            'returning value to calling sub routine
            Return blnFatalError

        Catch ex As Exception

            'message to user
            mstrErrorMessage = ex.Message
            blnFatalError = True

            'returning value to calling sub routine
            Return blnFatalError

        End Try

    End Function
    Private Function SetVehicleHistoryDataBindings() As Boolean

        'This will load the history with only the items that match the date
        'setting local variables
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim datStartDate As Date
        Dim datEndingDate As Date
        Dim blnFatalError As Boolean = False
        Dim datDateFromTable As Date
        Dim intDateCounter As Integer
        Dim intDateDifferance As Integer

        'try catch for exceptions
        Try

            'setting up the data variables
            TheVehicleHistoryDataTier = New VehicleHistoryDataTier
            TheVehicleHistoryDataSet = TheVehicleHistoryDataTier.GetVehicleHistoryInformation
            TheVehicleHistoryBindingSource = New BindingSource

            'setting up the binding source
            With TheVehicleHistoryBindingSource
                .DataSource = TheVehicleHistoryDataSet
                .DataMember = "vehiclehistory"
                .MoveFirst()
                .MoveLast()
            End With

            'setting up the combo box
            With cboTransactionID
                .DataSource = TheVehicleHistoryBindingSource
                .DisplayMember = "TransactionID"
                .DataBindings.Add("text", TheVehicleHistoryBindingSource, "TransactionID", False, DataSourceUpdateMode.Never)
            End With

            'setting up the rest of the controls
            txtBJCNumber.DataBindings.Add("Text", TheVehicleHistoryBindingSource, "BJCNumber")
            txtDate.DataBindings.Add("Text", TheVehicleHistoryBindingSource, "Date")
            txtOdometerReading.DataBindings.Add("Text", TheVehicleHistoryBindingSource, "VehicleID")
            txtNotes.DataBindings.Add("Text", TheVehicleHistoryBindingSource, "EmployeeID")

            'getting ready for the loop
            intNumberOfRecords = cboTransactionID.Items.Count - 1
            ReDim structTempHistory(intNumberOfRecords)
            ReDim structVehicleHistory(intNumberOfRecords)
            mintHistoryCounter = 0
            datStartDate = TheDateSearchClass.RemoveTime(Logon.mdatStartingDate)
            datEndingDate = TheDateSearchClass.RemoveTime(Logon.mdatEndingDate)

            'loading the temp structure
            For intCounter = 0 To intNumberOfRecords

                'incrementing the combo box
                cboTransactionID.SelectedIndex = intCounter

                'Getting date
                datDateFromTable = CDate(txtDate.Text)
                datDateFromTable = TheDateSearchClass.RemoveTime(datDateFromTable)

                'Checking the date
                If datDateFromTable >= datStartDate Then
                    If datDateFromTable <= datEndingDate Then

                        'loading the temp structure
                        structTempHistory(mintHistoryCounter).mintBJCNumber = CInt(txtBJCNumber.Text)
                        structTempHistory(mintHistoryCounter).mintVehicleID = CInt(txtOdometerReading.Text)
                        structTempHistory(mintHistoryCounter).mdatDate = datDateFromTable
                        structTempHistory(mintHistoryCounter).mintEmployeeID = CInt(txtNotes.Text)
                        mintHistoryCounter += 1
                    End If
                End If

            Next

            mintHistoryUpperLimit = mintHistoryCounter - 1
            mintHistoryCounter = 0

            datDateFromTable = datStartDate
            intDateDifferance = TheDateSearchClass.DaysDifference(datStartDate, datEndingDate)

            'getting ready to put the transactions in Order
            For intDateCounter = 0 To intDateDifferance

                'beginning loop
                For intCounter = 0 To mintHistoryUpperLimit

                    If structTempHistory(intCounter).mdatDate = datDateFromTable Then

                        'loading vehicle history structure
                        structVehicleHistory(mintHistoryCounter).mdatDate = structTempHistory(intCounter).mdatDate
                        structVehicleHistory(mintHistoryCounter).mintBJCNumber = structTempHistory(intCounter).mintBJCNumber
                        structVehicleHistory(mintHistoryCounter).mintVehicleID = structTempHistory(intCounter).mintVehicleID
                        structVehicleHistory(mintHistoryCounter).mintEmployeeID = structTempHistory(intCounter).mintEmployeeID
                        mintHistoryCounter += 1

                    End If

                Next

                'adding a day
                datDateFromTable = TheDateSearchClass.AddingDay(datDateFromTable, 1)

            Next

            'returning the value to the calling sub routine
            Return blnFatalError

        Catch ex As Exception

            'message to the user
            mstrErrorMessage = ex.Message
            blnFatalError = True

            'returning the value to the calling sub routine
            Return blnFatalError

        End Try

    End Function
    Private Function SetVehicleDataBindings() As Boolean

        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim blnFatalError As Boolean = False
        Dim strActiveFromTable As String

        'try catch for exceptions
        Try

            'setting up the main data variables
            TheVehiclesDataTier = New VehiclesDataTier
            TheVehiclesDataSet = TheVehiclesDataTier.GetVehiclesInformation
            TheVehiclesBindingSource = New BindingSource

            'setting up the binding source
            With TheVehiclesBindingSource
                .DataSource = TheVehiclesDataSet
                .DataMember = "vehicles"
                .MoveFirst()
                .MoveLast()
            End With

            'setting up the combo box
            With cboTransactionID
                .DataSource = TheVehiclesBindingSource
                .DisplayMember = "VehicleID"
                .DataBindings.Add("Text", TheVehiclesBindingSource, "VehicleID", False, DataSourceUpdateMode.Never)
            End With

            'setting up the rest of the controls
            txtBJCNumber.DataBindings.Add("text", TheVehiclesBindingSource, "BJCNumber")
            txtDate.DataBindings.Add("text", TheVehiclesBindingSource, "Active")
            txtOdometerReading.DataBindings.Add("Text", TheVehiclesBindingSource, "EmployeeID")

            'getting ready for the loop
            intNumberOfRecords = cboTransactionID.Items.Count - 1
            ReDim structVehicles(intNumberOfRecords)
            mintVehicleCounter = 0

            'Beginning Loop
            For intCounter = 0 To intNumberOfRecords

                'incrementing the combo box
                cboTransactionID.SelectedIndex = intCounter

                'setting entry is active
                strActiveFromTable = txtDate.Text

                If strActiveFromTable = "YES" Then

                    'loading up the structure
                    structVehicles(mintVehicleCounter).mintVehicleID = CInt(cboTransactionID.Text)
                    structVehicles(mintVehicleCounter).mintBJCNumber = CInt(txtBJCNumber.Text)
                    structVehicles(mintVehicleCounter).mstrActive = txtDate.Text
                    structVehicles(mintVehicleCounter).mintEmployeeID = CInt(txtOdometerReading.Text)
                    mintVehicleCounter += 1

                End If
            Next

            'setting the controls
            mintVehicleUpperLimit = mintVehicleCounter - 1
            mintVehicleCounter = 0

            'returning the value to the main
            Return blnFatalError

        Catch ex As Exception

            'to create message for the user
            mstrErrorMessage = ex.Message
            blnFatalError = True

            'returning the value to the main
            Return blnFatalError

        End Try
    End Function
    Private Function SetEmployeeDataBindings() As Boolean

        'setting local variables
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim blnFatalError As Boolean = False

        'try catch for exceptions
        Try

            'setting up for the data variables
            TheEmployeeDataTier = New EmployeeDataTier
            TheEmployeeDataSet = TheEmployeeDataTier.GetEmployeeInformation
            TheEmployeeBindingSource = New BindingSource

            'setting up the binding source
            With TheEmployeeBindingSource
                .DataSource = TheEmployeeDataSet
                .DataMember = "employees"
                .MoveFirst()
                .MoveLast()
            End With

            'setting up the combo box
            With cboTransactionID
                .DataSource = TheEmployeeBindingSource
                .DisplayMember = "EmployeeID"
                .DataBindings.Add("text", TheEmployeeBindingSource, "EmployeeID", False, DataSourceUpdateMode.Never)
            End With

            'setting up the rest of the controls
            txtBJCNumber.DataBindings.Add("text", TheEmployeeBindingSource, "FirstName")
            txtDate.DataBindings.Add("text", TheEmployeeBindingSource, "LastName")

            'getting ready to fill the structure
            intNumberOfRecords = cboTransactionID.Items.Count - 1
            ReDim structEmployees(intNumberOfRecords)
            mintEmployeeCounter = 0

            'beginning loop
            For intCounter = 0 To intNumberOfRecords

                'incrementing the comob box
                cboTransactionID.SelectedIndex = intCounter

                structEmployees(mintEmployeeCounter).mstrLastName = txtDate.Text
                structEmployees(mintEmployeeCounter).mstrFirstName = txtBJCNumber.Text
                structEmployees(mintEmployeeCounter).mintEmployeeID = CInt(cboTransactionID.Text)
                mintEmployeeCounter += 1

            Next

            'setting the controls
            mintEmployeeUpperLimit = mintEmployeeCounter - 1
            mintEmployeeCounter = 0

            'returning to calling sub-routine
            Return blnFatalError

        Catch ex As Exception

            'output to user if there is a failure
            mstrErrorMessage = ex.Message
            blnFatalError = True

            'returning to calling sub-routine
            Return blnFatalError

        End Try
    End Function
    Private Sub ClearDataBindings()

        'this clears the data bindings of all controls
        cboTransactionID.DataBindings.Clear()
        txtBJCNumber.DataBindings.Clear()
        txtDate.DataBindings.Clear()
        txtNotes.DataBindings.Clear()
        txtOdometerReading.DataBindings.Clear()
        txtProblemReported.DataBindings.Clear()

    End Sub

    Private Sub btnRunReport_Click(sender As Object, e As EventArgs) Handles btnRunReport.Click

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
        e.Graphics.DrawString("Blue Jay Communications Daily Inspection Report", PrintHeaderFont, Brushes.Black, PrintX, PrintY)
        PrintY = PrintY + HeadingLineHeight

        'Setting up the columns
        PrintX = 50
        e.Graphics.DrawString("Date", PrintItemsFont, Brushes.Black, PrintX, PrintY)
        PrintX = 150
        e.Graphics.DrawString("BJC Number", PrintItemsFont, Brushes.Black, PrintX, PrintY)
        PrintX = 300
        e.Graphics.DrawString("First Name", PrintItemsFont, Brushes.Black, PrintX, PrintY)
        PrintX = 450
        e.Graphics.DrawString("Last Name", PrintItemsFont, Brushes.Black, PrintX, PrintY)
        PrintX = 600
        e.Graphics.DrawString("Notes", PrintItemsFont, Brushes.Black, PrintX, PrintY)
        PrintY = PrintY + ItemLineHeight

        'Setting up for multiple pages
        intStartingPageCounter = mintNewPrintCounter
        intNumberOfRecords = mintResultUpperLimit

        For intCounter = intStartingPageCounter To mintResultUpperLimit

            PrintX = 50
            e.Graphics.DrawString(CStr(structSearchResults(intCounter).mdatDate), PrintItemsFont, Brushes.Black, PrintX, PrintY)
            PrintX = 150
            e.Graphics.DrawString(CStr(structSearchResults(intCounter).mintBJCNumber), PrintItemsFont, Brushes.Black, PrintX, PrintY)
            PrintX = 300
            e.Graphics.DrawString(structSearchResults(intCounter).mstrFirstName, PrintItemsFont, Brushes.Black, PrintX, PrintY)
            PrintX = 450
            e.Graphics.DrawString(structSearchResults(intCounter).mstrLastName, PrintItemsFont, Brushes.Black, PrintX, PrintY)

            'setting up for spreading the notes out
            charNotesAray = structSearchResults(intCounter).mstrNotes.ToCharArray
            intArrayLength = structSearchResults(intCounter).mstrNotes.Length - 1

            'setting the upper limit
            intNotesUpperLimit = CInt(intArrayLength / 35) - 1

            If intNotesUpperLimit <= 0 Then

                PrintX = 600
                e.Graphics.DrawString(structSearchResults(intCounter).mstrNotes, PrintItemsFont, Brushes.Black, PrintX, PrintY)
                PrintY = PrintY + ItemLineHeight

            ElseIf intNotesUpperLimit > 0 Then

                intStartCharCount = 0
                intCharUpperLimit = 35
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
                        PrintX = 600
                        e.Graphics.DrawString(strNewString, PrintItemsFont, Brushes.Black, PrintX, PrintY)
                        PrintY = PrintY + ItemLineHeight
                        strNewString = ""
                        intStringCounter = 0
                    End If
                    If intCharCounter = intArrayLength Then
                        PrintX = 600
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
End Class