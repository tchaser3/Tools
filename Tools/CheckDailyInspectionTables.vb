'Title:         Check Daily Inspection Tables
'Date:          9-30-15
'Author:        Terry Holmes

'Description:   This form will check the daily inspection forms for any items that are missing

Option Strict On

Public Class CheckDailyInspectionTables

    'setting up data variables
    Private TheVehicleInventorySheetDataTier As VehicleInventorySheetDataTier
    Private TheVehicleInventorySheetDataSet As VehicleInventorySheetDataSet
    Private WithEvents TheVehicleInventorySheetBindingSource As BindingSource

    Private TheVehicleSignedOutDataTier As VehicleSignedOutDataTier
    Private TheVehicleSignedOutDataSet As VehicleSignedOutDataSet
    Private WithEvents TheVehicleSignedOutBindingSource As BindingSource

    Private TheDailyVehicleInspectionDataTier As DailyVehicleInspectionDataTier
    Private TheDailyVehicleInspectionDataSet As DailyVehicleInspectionDataSet
    Private WithEvents TheDailyVehicleInspectionBindingSource As BindingSource

    'setting inventory sheet structure
    Structure InventorySheet
        Dim mstrTransactionID As String
        Dim mstrBJCNumber As String
        Dim mstrDate As String
        Dim mstrInventorySheetTurnedIn As String
        Dim mstrNotes As String
        Dim mstrProblemReported As String
        Dim mstrProblemCritical As String
        Dim mstrWorkOrderCreated As String
    End Structure

    'Structure supporting variables
    Dim structInventorySheet() As InventorySheet
    Dim mintInventoryCounter As Integer
    Dim mintInventoryUpperLimit As Integer

    'sign out sheet structure
    Structure SignedOut
        Dim mstrTransactionID As String
        Dim mstrBJCNumber As String
        Dim mstrDate As String
        Dim mstrSignOutSheetTurnedIn As String
    End Structure

    'structure supporting variables
    Dim structSignedOut() As SignedOut
    Dim mintSignedOutCounter As Integer
    Dim mintSignedoutUpperLimit As Integer

    'daily inspection structure
    Structure DailyInspection
        Dim mstrInspectionID As String
        Dim mstrBJCNumber As String
        Dim mstrEmployeeID As String
        Dim mstrOdometer As String
        Dim mstrHoursDrive As String
        Dim mstrDate As String
        Dim mstrDOTFormTurnedIn As String
        Dim mstrNotes As String
    End Structure

    'structure supporting variables
    Dim structDailyInspection() As DailyInspection
    Dim mintDailyInspectionCounter As Integer
    Dim mintDailyInspectionUpperLimit As Integer

    'Message to user
    Dim mstrErrorMessage As String
    Dim mstrErrorMessageHeader As String

    Structure SearchResults
        Dim mstrTransactionID As String
        Dim mstrBJCNumber As String
        Dim mstrEmployeeIDProblemReported As String
        Dim mstrOdometerProblemCritical As String
        Dim mstrHoursDrivenWorkOrderCreated As String
        Dim mstrDate As String
        Dim mstrSheetTurnedIn As String
        Dim mstrNotes As String
        Dim mstrTableType As String
        Dim mstrProblem As String
    End Structure

    Dim structSearchResults() As SearchResults
    Dim mintSearchCounter As Integer
    Dim mintSearchUpperLimit As Integer

    Dim TheInputDataValidation As New InputDataValidation
    Dim mblnNoItemsWereFound As Boolean
    Dim mintNewPrintCounter As Integer

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
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        CloseTheProgram.ShowDialog()
    End Sub

    Private Sub btnMainMenu_Click(sender As Object, e As EventArgs) Handles btnMainMenu.Click

        LastTransaction.Show()
        MainMenu.Show()
        Me.Close()

    End Sub
    Private Sub ClearDataBindings()

        cboTransactionID.DataBindings.Clear()
        txtBJCNumber.DataBindings.Clear()
        txtDate.DataBindings.Clear()
        txtEmployeeWorkOrderCreated.DataBindings.Clear()
        txtHoursDrivenProblemCritical.DataBindings.Clear()
        txtNotes.DataBindings.Clear()
        txtOdometerProblemReported.DataBindings.Clear()
        txtSheetPresent.DataBindings.Clear()

    End Sub
    Private Sub SetControlsVisible(ByVal valueBoolean As Boolean)

        cboTransactionID.Visible = valueBoolean
        txtBJCNumber.Visible = valueBoolean
        txtDate.Visible = valueBoolean
        txtEmployeeWorkOrderCreated.Visible = valueBoolean
        txtHoursDrivenProblemCritical.Visible = valueBoolean
        txtNotes.Visible = valueBoolean
        txtOdometerProblemReported.Visible = valueBoolean
        txtSheetPresent.Visible = valueBoolean

    End Sub

    Private Sub CheckDailyInspectionTables_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Setting local variables
        Dim blnFatalError As Boolean = False

        'For loading the variables
        PleaseWait.Show()

        'setting bingings and loading structures
        ClearDataBindings()
        blnFatalError = SetDailyInspectionDataVariables()
        If blnFatalError = False Then
            ClearDataBindings()
            blnFatalError = SetInventorySheetsDataBindings()
        End If
        If blnFatalError = False Then
            ClearDataBindings()
            blnFatalError = SetSignoutSheetDataBindings()
        End If

        PleaseWait.Close()

        'Outputting to user
        If blnFatalError = True Then
            MessageBox.Show(mstrErrorMessage, mstrErrorMessageHeader, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        SetControlsVisible(False)

    End Sub
    Private Function SetSignoutSheetDataBindings() As Boolean

        'Setting local variables
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim blnFatalError As Boolean = False

        'try catch for exceptions
        Try

            'this will set the bindings
            TheVehicleSignedOutDataTier = New VehicleSignedOutDataTier
            TheVehicleSignedOutDataSet = TheVehicleSignedOutDataTier.GetVehicleSignedOutInformation
            TheVehicleSignedOutBindingSource = New BindingSource

            'setting up the binding source
            With TheVehicleSignedOutBindingSource
                .DataSource = TheVehicleSignedOutDataSet
                .DataMember = "vehiclesignedout"
                .MoveFirst()
                .MoveLast()
            End With

            'setting up the combo box
            With cboTransactionID
                .DataSource = TheVehicleSignedOutBindingSource
                .DisplayMember = "TransactionID"
                .DataBindings.Add("text", TheVehicleSignedOutBindingSource, "TransactionID", False, DataSourceUpdateMode.Never)
            End With

            'setting the rest of the controls
            txtBJCNumber.DataBindings.Add("Text", TheVehicleSignedOutBindingSource, "BJCNumber")
            txtDate.DataBindings.Add("Text", TheVehicleSignedOutBindingSource, "Date")
            txtSheetPresent.DataBindings.Add("Text", TheVehicleSignedOutBindingSource, "VehicleSignedOut")

            'setting up for the loading the structure
            intNumberOfRecords = cboTransactionID.Items.Count - 1
            ReDim structSignedOut(intNumberOfRecords)
            mintSignedoutUpperLimit = intNumberOfRecords

            'Running Loop
            For intCounter = 0 To intNumberOfRecords

                'incrementing the combo box
                cboTransactionID.SelectedIndex = intCounter

                'loading the structure
                structSignedOut(intCounter).mstrTransactionID = cboTransactionID.Text
                structSignedOut(intCounter).mstrBJCNumber = txtBJCNumber.Text
                structSignedOut(intCounter).mstrDate = txtDate.Text
                structSignedOut(intCounter).mstrSignOutSheetTurnedIn = txtSheetPresent.Text

            Next

            'returning back to calling sub-routine
            Return blnFatalError

        Catch ex As Exception

            'message to user
            mstrErrorMessage = ex.Message
            mstrErrorMessageHeader = "Please Correct The Sign Out Sheet Bindings"
            blnFatalError = True

            'returning to call sub routine
            Return blnFatalError

        End Try

    End Function
    Private Function SetInventorySheetsDataBindings() As Boolean

        'Setting local variables
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim blnFatalError As Boolean = False

        'Try catch for exceptions
        Try

            'setting data variables
            TheVehicleInventorySheetDataTier = New VehicleInventorySheetDataTier
            TheVehicleInventorySheetDataSet = TheVehicleInventorySheetDataTier.GetVehicleInventorySheetInformation
            TheVehicleInventorySheetBindingSource = New BindingSource

            'Setting up the binding source
            With TheVehicleInventorySheetBindingSource
                .DataSource = TheVehicleInventorySheetDataSet
                .DataMember = "vehicleinventorysheet"
                .MoveFirst()
                .MoveLast()
            End With

            'Setting up the combo box
            With cboTransactionID
                .DataSource = TheVehicleInventorySheetBindingSource
                .DisplayMember = "TransactionID"
                .DataBindings.Add("text", TheVehicleInventorySheetBindingSource, "TransactionID", False, DataSourceUpdateMode.Never)
            End With

            'Setting up the rest of the controls
            txtBJCNumber.DataBindings.Add("text", TheVehicleInventorySheetBindingSource, "BJCNumber")
            txtDate.DataBindings.Add("Text", TheVehicleInventorySheetBindingSource, "Date")
            txtSheetPresent.DataBindings.Add("text", TheVehicleInventorySheetBindingSource, "InventorySheet")
            txtNotes.DataBindings.Add("text", TheVehicleInventorySheetBindingSource, "Notes")
            txtOdometerProblemReported.DataBindings.Add("text", TheVehicleInventorySheetBindingSource, "ProblemReported")
            txtHoursDrivenProblemCritical.DataBindings.Add("text", TheVehicleInventorySheetBindingSource, "ProblemCritical")
            txtEmployeeWorkOrderCreated.DataBindings.Add("text", TheVehicleInventorySheetBindingSource, "WorkOrderCreated")

            'setting up for the loop
            intNumberOfRecords = cboTransactionID.Items.Count - 1
            ReDim structInventorySheet(intNumberOfRecords)
            mintInventoryUpperLimit = intNumberOfRecords

            'Beginning loop
            For intCounter = 0 To intNumberOfRecords

                'incrementing the combo box
                cboTransactionID.SelectedIndex = intCounter

                'Filling the structure
                structInventorySheet(intCounter).mstrBJCNumber = txtBJCNumber.Text
                structInventorySheet(intCounter).mstrDate = txtDate.Text
                structInventorySheet(intCounter).mstrInventorySheetTurnedIn = txtSheetPresent.Text
                structInventorySheet(intCounter).mstrProblemCritical = txtHoursDrivenProblemCritical.Text
                structInventorySheet(intCounter).mstrWorkOrderCreated = txtEmployeeWorkOrderCreated.Text
                structInventorySheet(intCounter).mstrTransactionID = cboTransactionID.Text
                structInventorySheet(intCounter).mstrNotes = txtNotes.Text
                structInventorySheet(intCounter).mstrProblemReported = txtOdometerProblemReported.Text

            Next

            'returning back to main
            Return blnFatalError

        Catch ex As Exception

            'message to user
            mstrErrorMessage = ex.Message
            mstrErrorMessageHeader = "Please Correct The Daily Vehicle Inspection Bindings"
            blnFatalError = True

            'returning to call sub routine
            Return blnFatalError

        End Try

    End Function
    Private Function SetDailyInspectionDataVariables() As Boolean

        'setting local variables
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim blnFatalError As Boolean = False

        'Try catch for exceptions
        Try

            'setting data variables
            TheDailyVehicleInspectionDataTier = New DailyVehicleInspectionDataTier
            TheDailyVehicleInspectionDataSet = TheDailyVehicleInspectionDataTier.GetDailyVehicleInpectionInformation
            TheDailyVehicleInspectionBindingSource = New BindingSource

            'Setting up the bindingsource
            With TheDailyVehicleInspectionBindingSource
                .DataSource = TheDailyVehicleInspectionDataSet
                .DataMember = "VehicleDailyInspection"
                .MoveFirst()
                .MoveLast()
            End With

            'Setting up the combo box
            With cboTransactionID
                .DataSource = TheDailyVehicleInspectionBindingSource
                .DisplayMember = "InspectionID"
                .DataBindings.Add("text", TheDailyVehicleInspectionBindingSource, "InspectionID", False, DataSourceUpdateMode.Never)
            End With

            'setting up the rest of the variables
            txtBJCNumber.DataBindings.Add("text", TheDailyVehicleInspectionBindingSource, "BJCNumber")
            txtDate.DataBindings.Add("text", TheDailyVehicleInspectionBindingSource, "Date")
            txtEmployeeWorkOrderCreated.DataBindings.Add("text", TheDailyVehicleInspectionBindingSource, "EmployeeID")
            txtOdometerProblemReported.DataBindings.Add("Text", TheDailyVehicleInspectionBindingSource, "Odometer")
            txtHoursDrivenProblemCritical.DataBindings.Add("text", TheDailyVehicleInspectionBindingSource, "NumberOfHoursDriven")
            txtNotes.DataBindings.Add("text", TheDailyVehicleInspectionBindingSource, "Notes")
            txtSheetPresent.DataBindings.Add("text", TheDailyVehicleInspectionBindingSource, "DOTFormTurnedIn")

            'setting up for the structure
            intNumberOfRecords = cboTransactionID.Items.Count - 1
            ReDim structDailyInspection(intNumberOfRecords)
            mintDailyInspectionUpperLimit = intNumberOfRecords
            ReDim structSearchResults(intNumberOfRecords * 4)

            'beginning Loop
            For intCounter = 0 To intNumberOfRecords

                'incrementing teh combo boxj
                cboTransactionID.SelectedIndex = intCounter

                'Loading structure
                structDailyInspection(intCounter).mstrBJCNumber = txtBJCNumber.Text
                structDailyInspection(intCounter).mstrDate = txtDate.Text
                structDailyInspection(intCounter).mstrDOTFormTurnedIn = txtSheetPresent.Text
                structDailyInspection(intCounter).mstrEmployeeID = txtEmployeeWorkOrderCreated.Text
                structDailyInspection(intCounter).mstrHoursDrive = txtHoursDrivenProblemCritical.Text
                structDailyInspection(intCounter).mstrInspectionID = cboTransactionID.Text
                structDailyInspection(intCounter).mstrNotes = txtNotes.Text
                structDailyInspection(intCounter).mstrOdometer = txtOdometerProblemReported.Text

            Next

            'returning back to main
            Return blnFatalError

        Catch ex As Exception

            'message to user
            mstrErrorMessage = ex.Message
            mstrErrorMessageHeader = "Please Correct The Daily Vehicle Inspection Bindings"
            blnFatalError = True

            'returning to call sub routine
            Return blnFatalError

        End Try
    End Function

    Private Sub btnCheckTables_Click(sender As Object, e As EventArgs) Handles btnCheckTables.Click

        'this sub-routine will check the tables to ensure that the correct
        'information is in the table

        'setting local variables
        Dim intInspectionCounter As Integer
        Dim intInventoryCounter As Integer
        Dim intSignOutCounter As Integer
        Dim blnFatalError As Boolean
        Dim strTableType As String
        Dim strProblem As String
        Dim strValueForValidation As String

        PleaseWait.Show()

        'getting ready for loop
        mintSearchCounter = 0
        strTableType = "Daily Inspection"
        mblnNoItemsWereFound = True

        'Beginning first loop
        For intInspectionCounter = 0 To mintDailyInspectionUpperLimit

            blnFatalError = False

            'Beginning Check
            strProblem = ""
            strValueForValidation = structDailyInspection(intInspectionCounter).mstrBJCNumber
            blnFatalError = TheInputDataValidation.VerifyIntegerData(strValueForValidation)
            If blnFatalError = True Then
                strProblem = "BJC Number is not an Integer"
            End If
            strValueForValidation = structDailyInspection(intInspectionCounter).mstrDate
            blnFatalError = TheInputDataValidation.VerifyStartingEndingDatesAsDates(strValueForValidation)
            If blnFatalError = True Then
                strProblem = strProblem + " Date is not a Date"
            End If
            strValueForValidation = structDailyInspection(intInspectionCounter).mstrDOTFormTurnedIn
            blnFatalError = TheInputDataValidation.VerifyYesNoData(strValueForValidation)
            If blnFatalError = True Then
                strProblem = strProblem + "Sheet Not Turned is not a Yes"
            End If
            strValueForValidation = structDailyInspection(intInspectionCounter).mstrEmployeeID
            blnFatalError = TheInputDataValidation.VerifyIntegerData(strValueForValidation)
            If blnFatalError = True Then
                strProblem = strProblem + "Employee ID is not an Integer"
            End If
            strValueForValidation = structDailyInspection(intInspectionCounter).mstrHoursDrive
            blnFatalError = TheInputDataValidation.VerifyIntegerData(strValueForValidation)
            If blnFatalError = True Then
                strProblem = strProblem + "The Hours Driven is not an Integer"
            End If
            strValueForValidation = structDailyInspection(intInspectionCounter).mstrOdometer
            blnFatalError = TheInputDataValidation.VerifyIntegerData(strValueForValidation)
            If blnFatalError = True Then
                strProblem = strProblem + "The Odometer is not an Integer"
            End If

            If blnFatalError = True Then

                'this will load the structure
                structSearchResults(mintSearchCounter).mstrBJCNumber = structDailyInspection(intInspectionCounter).mstrBJCNumber
                structSearchResults(mintSearchCounter).mstrDate = structDailyInspection(intInspectionCounter).mstrDate
                structSearchResults(mintSearchCounter).mstrEmployeeIDProblemReported = structDailyInspection(intInspectionCounter).mstrEmployeeID
                structSearchResults(mintSearchCounter).mstrHoursDrivenWorkOrderCreated = structDailyInspection(intInspectionCounter).mstrHoursDrive
                structSearchResults(mintSearchCounter).mstrOdometerProblemCritical = structDailyInspection(intInspectionCounter).mstrOdometer
                structSearchResults(mintSearchCounter).mstrProblem = strProblem
                structSearchResults(mintSearchCounter).mstrSheetTurnedIn = structDailyInspection(intInspectionCounter).mstrDOTFormTurnedIn
                structSearchResults(mintSearchCounter).mstrTableType = strTableType
                structSearchResults(mintSearchCounter).mstrTransactionID = structDailyInspection(intInspectionCounter).mstrInspectionID
                mintSearchCounter += 1
                mblnNoItemsWereFound = False

            End If

        Next

        strTableType = "Inventory Sheets"

        'Beginning Loop
        For intInventoryCounter = 0 To mintInventoryUpperLimit

            'clearing the variables for the loop
            blnFatalError = False
            strProblem = ""

            strValueForValidation = structInventorySheet(intInventoryCounter).mstrBJCNumber
            blnFatalError = TheInputDataValidation.VerifyIntegerData(strValueForValidation)
            If blnFatalError = True Then
                strProblem = strProblem + "BJC Number is not an Integer"
            End If
            strValueForValidation = structInventorySheet(intInventoryCounter).mstrDate
            blnFatalError = TheInputDataValidation.VerifyStartingEndingDatesAsDates(strValueForValidation)
            If blnFatalError = True Then
                strProblem = strProblem + "The Date is not the Correct Format"
            End If
            strValueForValidation = structInventorySheet(intInventoryCounter).mstrTransactionID
            blnFatalError = TheInputDataValidation.VerifyIntegerData(strValueForValidation)
            If blnFatalError = True Then
                strProblem = strProblem + "The Transaction ID is not an Integer"
            End If
            strValueForValidation = structInventorySheet(intInventoryCounter).mstrInventorySheetTurnedIn
            blnFatalError = TheInputDataValidation.VerifyYesNoData(strValueForValidation)
            If blnFatalError = True Then
                strProblem = strProblem + "Sheet Turned is not the Correct Format"
            End If

            If blnFatalError = True Then

                'Loading up the array
                structSearchResults(mintSearchCounter).mstrBJCNumber = structInventorySheet(intInventoryCounter).mstrBJCNumber
                structSearchResults(mintSearchCounter).mstrDate = structInventorySheet(intInventoryCounter).mstrDate
                structSearchResults(mintSearchCounter).mstrEmployeeIDProblemReported = structInventorySheet(intInventoryCounter).mstrProblemReported
                structSearchResults(mintSearchCounter).mstrHoursDrivenWorkOrderCreated = structInventorySheet(intInventoryCounter).mstrWorkOrderCreated
                structSearchResults(mintSearchCounter).mstrOdometerProblemCritical = structInventorySheet(intInventoryCounter).mstrProblemCritical
                structSearchResults(mintSearchCounter).mstrProblem = strProblem
                structSearchResults(mintSearchCounter).mstrSheetTurnedIn = structInventorySheet(intInventoryCounter).mstrInventorySheetTurnedIn
                structSearchResults(mintSearchCounter).mstrTableType = strTableType
                structSearchResults(mintSearchCounter).mstrTransactionID = structInventorySheet(intInventoryCounter).mstrTransactionID
                mintSearchCounter += 1
                mblnNoItemsWereFound = False

            End If

        Next

        strTableType = "Signout Sheet"

        'beginning loop
        For intSignOutCounter = 0 To mintSignedoutUpperLimit

            'setting variables
            blnFatalError = False
            strProblem = ""

            strValueForValidation = structSignedOut(intSignOutCounter).mstrBJCNumber
            blnFatalError = TheInputDataValidation.VerifyIntegerData(strValueForValidation)
            If blnFatalError = True Then
                strProblem = strProblem + "The BJC Number is not an Integer"
            End If
            strValueForValidation = structSignedOut(intSignOutCounter).mstrDate
            blnFatalError = TheInputDataValidation.VerifyStartingEndingDatesAsDates(strValueForValidation)
            If blnFatalError = True Then
                strProblem = strProblem + "The Date is not the Correct Format:"
            End If
            strValueForValidation = structSignedOut(intSignOutCounter).mstrSignOutSheetTurnedIn
            blnFatalError = TheInputDataValidation.VerifyYesNoData(strValueForValidation)
            If blnFatalError = True Then
                strProblem = strProblem + "The Sign Out Sheet Answer is not the Correct Format"
            End If
            strValueForValidation = structSignedOut(intSignOutCounter).mstrTransactionID
            blnFatalError = TheInputDataValidation.VerifyIntegerData(strValueForValidation)
            If blnFatalError = True Then
                strProblem = strProblem + "The Transaction ID is not an Integer"
            End If

            If blnFatalError = True Then

                'loading up the structure
                structSearchResults(mintSearchCounter).mstrBJCNumber = structSignedOut(intSignOutCounter).mstrBJCNumber
                structSearchResults(mintSearchCounter).mstrDate = structSignedOut(intSignOutCounter).mstrDate
                structSearchResults(mintSearchCounter).mstrSheetTurnedIn = structSignedOut(intSignOutCounter).mstrTransactionID
                structSearchResults(mintSearchCounter).mstrTransactionID = structSignedOut(intSignOutCounter).mstrTransactionID
                structSearchResults(mintSearchCounter).mstrProblem = strProblem
                structSearchResults(mintSearchCounter).mstrTableType = strTableType
                mintSearchCounter += 1
                mblnNoItemsWereFound = False

            End If

        Next

        PleaseWait.Close()

        'setting the limit of the structure
        mintSearchUpperLimit = mintSearchCounter - 1
        mintSearchCounter = 0

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
        e.Graphics.DrawString("Blue Jays Database Problem Transaction Report", PrintHeaderFont, Brushes.Black, PrintX, PrintY)
        PrintY = PrintY + HeadingLineHeight

        PrintX = 100
        e.Graphics.DrawString("Table Type", PrintItemsFont, Brushes.Black, PrintX, PrintY)
        PrintX = 275
        e.Graphics.DrawString("Transaction ID", PrintItemsFont, Brushes.Black, PrintX, PrintY)
        PrintX = 450
        e.Graphics.DrawString("Date", PrintItemsFont, Brushes.Black, PrintX, PrintY)
        PrintX = 625
        e.Graphics.DrawString("BJC Numbers", PrintItemsFont, Brushes.Black, PrintX, PrintY)
        PrintY = PrintY + HeadingLineHeight

        'beginnin the loop
        For intCounter = intStartingPageCounter To mintSearchUpperLimit

            PrintX = 100
            e.Graphics.DrawString(structSearchResults(intCounter).mstrTableType, PrintItemsFont, Brushes.Black, PrintX, PrintY)
            PrintX = 275
            e.Graphics.DrawString(structSearchResults(intCounter).mstrTransactionID, PrintItemsFont, Brushes.Black, PrintX, PrintY)
            PrintX = 450
            e.Graphics.DrawString(structSearchResults(intCounter).mstrDate, PrintItemsFont, Brushes.Black, PrintX, PrintY)
            PrintX = 625
            e.Graphics.DrawString(structSearchResults(intCounter).mstrBJCNumber, PrintItemsFont, Brushes.Black, PrintX, PrintY)
            PrintY = PrintY + ItemLineHeight
            PrintX = 100
            e.Graphics.DrawString("Missing Element:   " + structSearchResults(intCounter).mstrProblem, PrintSubHeaderFont, Brushes.Black, PrintX, PrintY)
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
                intCounter = mintSearchUpperLimit
            End If

        Next

    End Sub
End Class