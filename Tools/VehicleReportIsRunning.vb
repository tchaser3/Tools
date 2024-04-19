'Title:         Vehicle Report Is Running
'Date:          10/17/14
'Author:        Terry Holmes

'Description:   This form is used to complete the report functions.

Public Class VehicleReportIsRunning

    'Setting up the global variables
    Private TheVehicleDataSet As VehiclesDataSet
    Private TheVehicleDataTier As VehiclesDataTier
    Private WithEvents TheVehicleBindingSource As BindingSource

    Private TheHistoryDataSet As VehicleHistoryDataSet
    Private TheHistoryDataTier As VehicleHistoryDataTier
    Private WithEvents TheHistoryBindingSource As BindingSource

    Private TheEmployeeDataSet As EmployeeDataSet
    Private TheEmployeeDataTier As EmployeeDataTier
    Private WithEvents TheEmployeeBindingSource As BindingSource

    Private TheInspectionDataSet As DailyVehicleInspectionDataSet
    Private TheInspectionDataTier As DailyVehicleInspectionDataTier
    Private WithEvents TheInspectionBindingSource As BindingSource

    Private TheInventoryDataSet As VehicleInventorySheetDataSet
    Private TheInventoryDataTier As VehicleInventorySheetDataTier
    Private WithEvents TheInventoryBindingSource As BindingSource

    Private TheSignOutDataSet As VehicleSignedOutDataSet
    Private TheSignOutDataTier As VehicleSignedOutDataTier
    Private WithEvents TheSignOutBindingSource As BindingSource

    Private TheInYardDataSet As VehicleInYardDataSet
    Private TheInYardDataTier As VehicleInYardDataTier
    Private WithEvents theInYardBindingSource As BindingSource

    'Vehicle Structure
    Structure SearchResults
        Dim mintBJCNumber As Integer
        Dim mintVehicleID As Integer
        Dim mstrFirstName As String
        Dim mstrLastName As String
        Dim mdatDate As Date
        Dim mstrInspection As String
        Dim mstrInventory As String
        Dim mstrSignedOut As String
        Dim mstrRemote As String
        Dim mstrDOT As String
        Dim mstrInYard As String
    End Structure

    Dim structSearchResults() As SearchResults
    Dim mintResultCounter As Integer
    Dim mintResultUpperLimit As Integer

    Dim structTemp() As SearchResults
    Dim mintTempCounter As Integer
    Dim mintTempUpperLimit As Integer

    Structure Vehicles
        Dim mintVehicleID As Integer
        Dim mintBJCNumber As Integer
        Dim mstrRemoteVehicle As String
        Dim mstrDOTFormRequired As String
        Dim mstrHomeOffice As String
    End Structure

    Dim structVehicles() As Vehicles
    Dim mintVehicleCounter As Integer
    Dim mintVehicleUpperLimit As Integer

    Structure Employees
        Dim mintEmployeeID As Integer
        Dim mstrFirstName As String
        Dim mstrLastName As String
    End Structure

    Dim structEmployees() As Employees
    Dim mintEmployeeCounter As Integer
    Dim mintEmployeeUpperLimit As Integer

    Structure History
        Dim mintTransactionID As Integer
        Dim mintVehicleID As Integer
        Dim mintEmployeeID As Integer
        Dim mdatTransactionDate As Date
        Dim mstrNotes As String
    End Structure

    Dim structHistory() As History
    Dim mintHistoryCounter As Integer
    Dim mintHistoryUpperLimit As Integer

    Structure InYard
        Dim mintTransactionID As Integer
        Dim mintBJCNumber As Integer
        Dim mdatTransactionDate As Date
        Dim mstrInYard As String
    End Structure

    Dim structInYard() As InYard
    Dim mintInYardCounter As Integer
    Dim mintInYardUpperLimit As Integer

    Structure Inspection
        Dim mintInspectionID As Integer
        Dim mdatTransactionDate As Date
        Dim mintBJCNumber As Integer
        Dim mstrDOTFormTurnedIn As String
    End Structure

    Dim structInspection() As Inspection
    Dim mintInspectionCounter As Integer
    Dim mintInspectionUpperLimit As Integer

    Structure Inventory
        Dim mintTransactionID As Integer
        Dim mdatTransactionDate As Date
        Dim mstrInventoryCompleted As String
        Dim mintBJCNumber As Integer
    End Structure

    Dim structInventory() As Inventory
    Dim mintInventoryCounter As Integer
    Dim mintInventoryUpperLimit As Integer

    Structure SignedOut
        Dim mintTransactionID As Integer
        Dim mintBJCNumber As Integer
        Dim mdatTransactionDate As Date
        Dim mstrVehicleSignedOut As String
    End Structure

    Dim structSignedOut() As SignedOut
    Dim mintSignedOutCounter As Integer
    Dim mintSignedOutUpperLimit As Integer

    Dim mstrReportDate As String
    Dim mintVehicleStructureCounter As Integer = 0
    Dim mstrErrorMessage As String
    Dim TheKeyWordSearchClass As New KeyWordSearchClass
    Dim TheDateSearchClass As New DateSearchClass
    Dim mdatStartingDate As Date
    Dim mdatEndingDate As Date
    Dim mintNumberOfDays As Integer
    Dim mstrFirstName As String
    Dim mstrLastName As String
    Dim mintNewPrintCounter As Integer

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        'This will decide to close the program
        CloseTheProgram.ShowDialog()

    End Sub

    Private Sub btnMainForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMainForm.Click

        LastTransaction.Show()
        MainMenu.Show()
        Me.Close()

    End Sub

    Private Sub btnVehicleInspectionReports_Click(sender As Object, e As EventArgs) Handles btnVehicleInspectionReports.Click
        LastTransaction.Show()
        VehicleInspectionReports.Show()
        Me.Close()
    End Sub

    Private Sub btnInspectionMenu_Click(sender As Object, e As EventArgs) Handles btnInspectionMenu.Click
        LastTransaction.Show()
        InspectionsMenu.Show()
        Me.Close()
    End Sub

    Private Sub VehicleReportIsRunning_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'this will used to load up the controls
        Dim blnFatalError As Boolean = False

        PleaseWait.Show()

        'removing the days
        mdatStartingDate = TheDateSearchClass.RemoveTime(Logon.mdatStartingDate)
        mdatEndingDate = TheDateSearchClass.RemoveTime(Logon.mdatEndingDate)

        'getting the number of days
        mintNumberOfDays = TheDateSearchClass.DaysDifference(mdatStartingDate, mdatEndingDate)

        'calling the binding controls
        ClearDataBindings()
        blnFatalError = SetVehicleBindings()
        If blnFatalError = False Then
            ClearDataBindings()
            blnFatalError = SetEmployeeBindings()
        End If
        If blnFatalError = False Then
            ClearDataBindings()
            blnFatalError = SetHistoryDataBindings()
        End If
        If blnFatalError = False Then
            ClearDataBindings()
            blnFatalError = SetInYardDataBindings()
        End If
        If blnFatalError = False Then
            ClearDataBindings()
            blnFatalError = SetInspectionDataBindings()
        End If
        If blnFatalError = False Then
            ClearDataBindings()
            blnFatalError = SetInventoryDataBindings()
        End If
        If blnFatalError = False Then
            ClearDataBindings()
            blnFatalError = SetSignOutDataBindings()
        End If

        'creating the grid view
        dgvSearchResults.ColumnCount = 7
        dgvSearchResults.Columns(0).Name = "Date"
        dgvSearchResults.Columns(0).Width = 75
        dgvSearchResults.Columns(1).Name = "BJC Number"
        dgvSearchResults.Columns(1).Width = 75
        dgvSearchResults.Columns(2).Name = "First Name"
        dgvSearchResults.Columns(2).Width = 100
        dgvSearchResults.Columns(3).Name = "Last Name"
        dgvSearchResults.Columns(3).Width = 100
        dgvSearchResults.Columns(4).Name = "DOT Form"
        dgvSearchResults.Columns(4).Width = 75
        dgvSearchResults.Columns(5).Name = "Inspection"
        dgvSearchResults.Columns(5).Width = 75
        dgvSearchResults.Columns(6).Name = "Signed Out"
        dgvSearchResults.Columns(6).Width = 75

        If blnFatalError = False Then
            ClearDataBindings()
            blnFatalError = FindTransactions()
        End If

        PleaseWait.Close()

        If blnFatalError = True Then
            btnRunReport.Enabled = False
            MessageBox.Show(mstrErrorMessage, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub
    Private Function FindTransactions() As Boolean

        'this subroutine will find the transactions
        Dim blnFatalError As Boolean = False

        'calling to load the temp structure
        blnFatalError = LoadVehiclesToTempStructure()

        'beginning Data Search
        If blnFatalError = False Then
            FindVehiclesInYard()
            FindHistory()
            FindInventory()
            FindSignedOut()
            FindInspections()
        End If

        If blnFatalError = False Then
            blnFatalError = FillSeachResults()
        End If
        If blnFatalError = False Then
            FillGridView()
        End If

        Return blnFatalError

    End Function
    Private Sub FindInspections()

        'setting local variables
        Dim intTempCounter As Integer
        Dim intInspectionCounter As Integer
        Dim intBJCNumberForSearch As Integer
        Dim intBJCNumberFromTable As Integer
        Dim datTransactionDateForSearch As Date
        Dim datTransactionDateFromTable As Date

        'beginning for loop
        For intTempCounter = 0 To mintTempUpperLimit

            intBJCNumberForSearch = structTemp(intTempCounter).mintBJCNumber
            datTransactionDateForSearch = structTemp(intTempCounter).mdatDate

            'beginning second loop
            For intInspectionCounter = 0 To mintInspectionUpperLimit

                intBJCNumberFromTable = structInspection(intInspectionCounter).mintBJCNumber
                datTransactionDateFromTable = structInspection(intInspectionCounter).mdatTransactionDate

                If intBJCNumberForSearch = intBJCNumberFromTable Then
                    If datTransactionDateForSearch = datTransactionDateFromTable Then

                        structTemp(intTempCounter).mstrInspection = "YES"

                    End If
                End If

            Next
        Next

    End Sub
    Private Sub FindSignedOut()

        'setting local variables
        Dim intTempCounter As Integer
        Dim intSignedOutCounter As Integer
        Dim intBJCNumberForSearch As Integer
        Dim intBJCNumberFromTable As Integer
        Dim datTransactionDateForSearch As Date
        Dim datTransactionDateFromTable As Date

        'beginning for loop
        For intTempCounter = 0 To mintTempUpperLimit

            intBJCNumberForSearch = structTemp(intTempCounter).mintBJCNumber
            datTransactionDateForSearch = structTemp(intTempCounter).mdatDate

            'beginning second loop
            For intSignedOutCounter = 0 To mintSignedOutUpperLimit

                intBJCNumberFromTable = structSignedOut(intSignedOutCounter).mintBJCNumber
                datTransactionDateFromTable = structSignedOut(intSignedOutCounter).mdatTransactionDate

                If intBJCNumberForSearch = intBJCNumberFromTable Then
                    If datTransactionDateForSearch = datTransactionDateFromTable Then

                        structTemp(intTempCounter).mstrSignedOut = "YES"

                    End If
                End If

            Next
        Next

    End Sub
    Private Sub FillGridView()

        'Setting local variables
        Dim intCounter As Integer
        Dim rows() As String

        'loading the grid view
        For intCounter = 0 To mintResultUpperLimit

            rows = New String() {CStr(structSearchResults(intCounter).mdatDate), CStr(structSearchResults(intCounter).mintBJCNumber), structSearchResults(intCounter).mstrFirstName, structSearchResults(intCounter).mstrLastName, structSearchResults(intCounter).mstrInspection, structSearchResults(intCounter).mstrInventory, structSearchResults(intCounter).mstrSignedOut}
            dgvSearchResults.Rows.Add(rows)

        Next

    End Sub
    Private Sub FindInventory()

        'local variables
        Dim intTempCounter As Integer
        Dim intInventoryCounter As Integer
        Dim intBJCNumberForSearch As Integer
        Dim intBJCNumberFromTable As Integer
        Dim datTransactionDateForSearch As Date
        Dim datTransactionDateFromTable As Date

        'beginning for loop
        For intTempCounter = 0 To mintTempUpperLimit

            intBJCNumberForSearch = structTemp(intTempCounter).mintBJCNumber
            datTransactionDateForSearch = structTemp(intTempCounter).mdatDate

            'beginning second loop
            For intInventoryCounter = 0 To mintInventoryUpperLimit

                intBJCNumberFromTable = structInventory(intInventoryCounter).mintBJCNumber
                datTransactionDateFromTable = structInventory(intInventoryCounter).mdatTransactionDate

                If intBJCNumberForSearch = intBJCNumberFromTable Then
                    If datTransactionDateForSearch = datTransactionDateFromTable Then

                        structTemp(intTempCounter).mstrInventory = "YES"

                    End If
                End If
            Next

        Next

    End Sub

    Private Function FillSeachResults() As Boolean

        Dim intTempCounter As Integer
        Dim blnNoItemsFound As Boolean

        mintResultCounter = 0

        'beginning loop
        For intTempCounter = 0 To mintTempUpperLimit

            'determining if the transaction should be in the structure
            If structTemp(intTempCounter).mstrInYard = "NO" And structTemp(intTempCounter).mdatDate <= mdatEndingDate Then
                If structTemp(intTempCounter).mstrInspection = "NO" Or structTemp(intTempCounter).mstrInventory = "NO" Or structTemp(intTempCounter).mstrSignedOut = "NO" Then

                    structSearchResults(mintResultCounter).mdatDate = structTemp(intTempCounter).mdatDate
                    structSearchResults(mintResultCounter).mintBJCNumber = structTemp(intTempCounter).mintBJCNumber
                    structSearchResults(mintResultCounter).mintVehicleID = structTemp(intTempCounter).mintVehicleID
                    structSearchResults(mintResultCounter).mstrDOT = structTemp(intTempCounter).mstrDOT
                    structSearchResults(mintResultCounter).mstrFirstName = structTemp(intTempCounter).mstrFirstName
                    structSearchResults(mintResultCounter).mstrLastName = structTemp(intTempCounter).mstrLastName
                    structSearchResults(mintResultCounter).mstrInspection = structTemp(intTempCounter).mstrInspection
                    structSearchResults(mintResultCounter).mstrInventory = structTemp(intTempCounter).mstrInventory
                    structSearchResults(mintResultCounter).mstrInYard = structTemp(intTempCounter).mstrInYard
                    structSearchResults(mintResultCounter).mstrRemote = structTemp(intTempCounter).mstrRemote
                    structSearchResults(mintResultCounter).mstrSignedOut = structTemp(intTempCounter).mstrSignedOut
                    mintResultCounter += 1
                    blnNoItemsFound = False

                End If

            End If

        Next

        'setting the variables
        If blnNoItemsFound = True Then
            mstrErrorMessage = "No Items Were Found"
        ElseIf blnNoItemsFound = False Then
            mintResultUpperLimit = mintResultCounter - 1
            mintResultCounter = 0
        End If

        'returning value to calling sub routine
        Return blnNoItemsFound

    End Function
    Private Sub FindHistory()

        'setting local variables
        Dim intHistoryCounter As Integer
        Dim intTempCounter As Integer
        Dim intVehicleIDForSearch As Integer
        Dim intVehicleIDFromTable As Integer
        Dim datTransactionDateForSearch As Date
        Dim datTransactionDateFromTable As Date
        Dim intEmployeeIDForSearch As Integer
        Dim strNotes As String

        'beginning first loop
        For intTempCounter = 0 To mintTempUpperLimit

            'preparing for the loop
            intVehicleIDForSearch = structTemp(intTempCounter).mintVehicleID
            datTransactionDateForSearch = structTemp(intTempCounter).mdatDate

            'beginning second loop
            For intHistoryCounter = 0 To mintHistoryUpperLimit

                intVehicleIDFromTable = structHistory(intHistoryCounter).mintVehicleID
                datTransactionDateFromTable = structHistory(intHistoryCounter).mdatTransactionDate
                intEmployeeIDForSearch = structHistory(intHistoryCounter).mintEmployeeID
                strNotes = structHistory(intHistoryCounter).mstrNotes

                'if statements
                If intVehicleIDForSearch = intVehicleIDFromTable Then
                    If datTransactionDateForSearch = datTransactionDateFromTable Then
                        If strNotes = "VEHICLE SIGNED OUT" Then

                            FindEmployee(intEmployeeIDForSearch)

                            structTemp(intTempCounter).mstrLastName = mstrLastName
                            structTemp(intTempCounter).mstrFirstName = mstrFirstName

                        End If
                    End If
                End If
            Next

        Next

    End Sub
    Private Sub FindVehiclesInYard()

        Dim intTempCounter As Integer
        Dim intInYardCounter As Integer
        Dim datTransactionDateForSearch As Date
        Dim datTransactionDateFromTable As Date
        Dim intBJCNumberForSearch As Integer
        Dim intBJCNumberFromTable As Integer

        'performing the first loop
        For intTempCounter = 0 To mintTempUpperLimit

            'getting search criteria
            intBJCNumberForSearch = structTemp(intTempCounter).mintBJCNumber
            datTransactionDateForSearch = structTemp(intTempCounter).mdatDate

            'beginning second loop
            For intInYardCounter = 0 To mintInYardUpperLimit

                'getting information from structure
                intBJCNumberFromTable = structInYard(intInYardCounter).mintBJCNumber
                datTransactionDateFromTable = structInYard(intInYardCounter).mdatTransactionDate

                'if statements
                If intBJCNumberForSearch = intBJCNumberFromTable Then
                    If datTransactionDateForSearch = datTransactionDateFromTable Then
                        structTemp(intTempCounter).mstrInYard = "YES"
                    End If
                End If

            Next

        Next


    End Sub
    Private Function LoadVehiclesToTempStructure() As Boolean

        'This sub routine will set the temp structure
        'Setting local variables
        Dim intVehicleCounter As Integer
        Dim intTempCounter As Integer
        Dim datStartingDate As Date
        Dim datEndingDate As Date
        Dim blnFatalError As Boolean = False

        datStartingDate = mdatStartingDate
        datEndingDate = mdatEndingDate
        intVehicleCounter = 0

        For intTempCounter = 0 To mintTempUpperLimit

            If mdatStartingDate > mdatEndingDate Then
                blnFatalError = True
                mstrErrorMessage = "The Starting Date Is Greater Than The Ending Date"
            End If

            'filling the temp structure
            structTemp(intTempCounter).mintBJCNumber = structVehicles(intVehicleCounter).mintBJCNumber
            structTemp(intTempCounter).mintVehicleID = structVehicles(intVehicleCounter).mintVehicleID
            structTemp(intTempCounter).mstrRemote = structVehicles(intVehicleCounter).mstrRemoteVehicle
            structTemp(intTempCounter).mstrDOT = structVehicles(intVehicleCounter).mstrDOTFormRequired
            If structTemp(intTempCounter).mstrDOT = "NO" Then
                structTemp(intTempCounter).mstrInspection = "N/A"
            ElseIf structTemp(intTempCounter).mstrDOT = "YES" Then
                structTemp(intTempCounter).mstrInspection = "NO"
            End If
            structTemp(intTempCounter).mdatDate = datStartingDate
            structTemp(intTempCounter).mstrSignedOut = "NO"
            structTemp(intTempCounter).mstrInventory = "NO"
            structTemp(intTempCounter).mstrLastName = "WAREHOUSE"
            structTemp(intTempCounter).mstrFirstName = structVehicles(intVehicleCounter).mstrHomeOffice
            structTemp(intTempCounter).mstrInYard = "NO"

            'checking to see if the date needs to be changed
            If intVehicleCounter = mintVehicleUpperLimit Then
                intVehicleCounter = 0
                datStartingDate = TheDateSearchClass.AddingDay(datStartingDate, 1)
            ElseIf intVehicleCounter < mintVehicleUpperLimit Then
                intVehicleCounter += 1
            End If

        Next

        Return blnFatalError

    End Function
   
    Private Sub FindEmployee(ByVal intEmployeeIDForSearch As Integer)

        'finding the employee
        Dim intCounter As Integer
        Dim intEmployeeIDFromTable As Integer

        For intCounter = 0 To mintEmployeeUpperLimit

            intEmployeeIDFromTable = structEmployees(intCounter).mintEmployeeID

            If intEmployeeIDForSearch = intEmployeeIDFromTable Then

                mstrFirstName = structEmployees(intCounter).mstrFirstName
                mstrLastName = structEmployees(intCounter).mstrLastName

                Exit For
            End If
        Next

    End Sub
    Private Function SetSignOutDataBindings() As Boolean

        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim blnFatalError As Boolean = False
        Dim datTransactionDate As Date

        'try catch for exceptions
        Try

            TheSignOutDataTier = New VehicleSignedOutDataTier
            TheSignOutDataSet = TheSignOutDataTier.GetVehicleSignedOutInformation
            TheSignOutBindingSource = New BindingSource

            With TheSignOutBindingSource
                .DataSource = TheSignOutDataSet
                .DataMember = "vehiclesignedout"
                .MoveFirst()
                .MoveLast()
            End With

            With cboTransactionID
                .DataSource = TheSignOutBindingSource
                .DisplayMember = "TransactionID"
                .DataBindings.Add("text", TheSignOutBindingSource, "TransactionID", False, DataSourceUpdateMode.Never)
            End With

            txtBJCNumber.DataBindings.Add("text", TheSignOutBindingSource, "BJCNumber")
            txtDate.DataBindings.Add("text", TheSignOutBindingSource, "Date")
            txtSheetPresent.DataBindings.Add("Text", TheSignOutBindingSource, "VehicleSignedOut")

            'getting ready for the loop
            intNumberOfRecords = cboTransactionID.Items.Count - 1
            ReDim structSignedOut(intNumberOfRecords)
            mintSignedOutCounter = 0

            'performing loop
            For intCounter = 0 To intNumberOfRecords

                cboTransactionID.SelectedIndex = intCounter

                datTransactionDate = CDate(txtDate.Text)
                datTransactionDate = TheDateSearchClass.RemoveTime(datTransactionDate)

                If datTransactionDate >= mdatStartingDate And datTransactionDate <= mdatEndingDate Then

                    structSignedOut(mintSignedOutCounter).mdatTransactionDate = datTransactionDate
                    structSignedOut(mintSignedOutCounter).mstrVehicleSignedOut = txtSheetPresent.Text
                    structSignedOut(mintSignedOutCounter).mintBJCNumber = CInt(txtBJCNumber.Text)
                    structSignedOut(mintSignedOutCounter).mintTransactionID = CInt(cboTransactionID.Text)
                    mintSignedOutCounter += 1
                End If
            Next

            If mintSignedOutCounter > 0 Then
                mintSignedOutUpperLimit = mintSignedOutCounter - 1
                mintSignedOutCounter = 0
            Else
                mintSignedOutUpperLimit = 0
            End If

            Return blnFatalError

        Catch ex As Exception

            mstrErrorMessage = ex.Message
            blnFatalError = True

            Return blnFatalError

        End Try

    End Function
    Private Function SetInventoryDataBindings() As Boolean

        'setting local variables
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim blnFatalError As Boolean = False
        Dim datTransactionDate As Date

        'try catch for exceptions
        Try

            'setting the data variables
            TheInventoryDataTier = New VehicleInventorySheetDataTier
            TheInventoryDataSet = TheInventoryDataTier.GetVehicleInventorySheetInformation
            TheInventoryBindingSource = New BindingSource

            'setting up the binding source
            With TheInventoryBindingSource
                .DataSource = TheInventoryDataSet
                .DataMember = "vehicleinventorysheet"
                .MoveFirst()
                .MoveLast()
            End With

            'setting the combo box
            With cboTransactionID
                .DataSource = TheInventoryBindingSource
                .DisplayMember = "TransactionID"
                .DataBindings.Add("Text", TheInventoryBindingSource, "TransactionID", False, DataSourceUpdateMode.Never)
            End With

            'setting up the rest of the controls
            txtBJCNumber.DataBindings.Add("Text", TheInventoryBindingSource, "BJCNumber")
            txtDate.DataBindings.Add("text", TheInventoryBindingSource, "Date")
            txtSheetPresent.DataBindings.Add("Text", TheInventoryBindingSource, "InventorySheet")

            'setting up for the loop
            intNumberOfRecords = cboTransactionID.Items.Count - 1
            ReDim structInventory(intNumberOfRecords)
            mintInventoryCounter = 0

            'running loop
            For intCounter = 0 To intNumberOfRecords

                'incrementing the combo box
                cboTransactionID.SelectedIndex = intCounter

                'getting the data
                datTransactionDate = CDate(txtDate.Text)
                datTransactionDate = TheDateSearchClass.RemoveTime(datTransactionDate)

                'loading up the structure
                If datTransactionDate >= mdatStartingDate And datTransactionDate <= mdatEndingDate Then

                    structInventory(mintInventoryCounter).mdatTransactionDate = datTransactionDate
                    structInventory(mintInventoryCounter).mstrInventoryCompleted = txtSheetPresent.Text
                    structInventory(mintInventoryCounter).mintBJCNumber = CInt(txtBJCNumber.Text)
                    structInventory(mintInventoryCounter).mintTransactionID = CInt(cboTransactionID.Text)
                    mintInventoryCounter += 1

                End If
            Next

            If mintInventoryCounter > 0 Then
                mintInventoryUpperLimit = mintInventoryCounter - 1
                mintInventoryCounter = 0
            Else
                mintInventoryUpperLimit = 0
            End If

            Return blnFatalError

        Catch ex As Exception

            'message to user
            mstrErrorMessage = ex.Message
            blnFatalError = True

            Return blnFatalError

        End Try

    End Function
    Private Function SetInspectionDataBindings() As Boolean

        'setting local variabled
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim blnFatalError As Boolean = False
        Dim datTransactionDate As Date

        'try catch for exceptions
        Try

            'setting up the data variabled
            TheInspectionDataTier = New DailyVehicleInspectionDataTier
            TheInspectionDataSet = TheInspectionDataTier.GetDailyVehicleInpectionInformation
            TheInspectionBindingSource = New BindingSource

            'setting up the binding source
            With TheInspectionBindingSource
                .DataSource = TheInspectionDataSet
                .DataMember = "VehicleDailyInspection"
                .MoveFirst()
                .MoveLast()
            End With

            'setting up the combo box
            With cboTransactionID
                .DataSource = TheInspectionBindingSource
                .DisplayMember = "InspectionID"
                .DataBindings.Add("Text", TheInspectionBindingSource, "InspectionID", False, DataSourceUpdateMode.Never)
            End With

            'setting up the rest of the controls
            txtBJCNumber.DataBindings.Add("Text", TheInspectionBindingSource, "BJCNumber")
            txtDate.DataBindings.Add("Text", TheInspectionBindingSource, "Date")
            txtSheetPresent.DataBindings.Add("text", TheInspectionBindingSource, "DOTFormTurnedIn")

            'setting up for the loop
            intNumberOfRecords = cboTransactionID.Items.Count - 1
            ReDim structInspection(intNumberOfRecords)
            mintInspectionCounter = 0

            'beginning loop
            For intCounter = 0 To intNumberOfRecords

                'incrementing the combo box
                cboTransactionID.SelectedIndex = intCounter

                'getting the date
                datTransactionDate = CDate(txtDate.Text)
                datTransactionDate = TheDateSearchClass.RemoveTime(datTransactionDate)

                'loading structure
                If datTransactionDate >= mdatStartingDate And datTransactionDate <= mdatEndingDate Then

                    structInspection(mintInspectionCounter).mdatTransactionDate = datTransactionDate
                    structInspection(mintInspectionCounter).mstrDOTFormTurnedIn = txtSheetPresent.Text
                    structInspection(mintInspectionCounter).mintBJCNumber = CInt(txtBJCNumber.Text)
                    structInspection(mintInspectionCounter).mintInspectionID = CInt(cboTransactionID.Text)
                    mintInspectionCounter += 1

                End If
            Next

            'loading global variables
            If mintInspectionCounter > 0 Then
                mintInspectionUpperLimit = mintInspectionCounter - 1
                mintInspectionCounter = 0
            Else
                mintInspectionUpperLimit = 0
            End If

            'returning value to main
            Return blnFatalError

        Catch ex As Exception

            'message to user
            mstrErrorMessage = ex.Message
            blnFatalError = True

            'returning value to main
            Return blnFatalError

        End Try

    End Function
    Private Function SetInYardDataBindings() As Boolean

        'setting local variables
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim blnFatalError As Boolean = False
        Dim datTransactionDate As Date

        'try catch for exceptions
        Try

            'setting the data variables
            TheInYardDataTier = New VehicleInYardDataTier
            TheInYardDataSet = TheInYardDataTier.GetVehicleInYardInformation
            theInYardBindingSource = New BindingSource

            'setting up the binding source
            With theInYardBindingSource
                .DataSource = TheInYardDataSet
                .DataMember = "vehicleinyard"
                .MoveFirst()
                .MoveLast()
            End With

            'setting up the combo box
            With cboTransactionID
                .DataSource = theInYardBindingSource
                .DisplayMember = "TransactionID"
                .DataBindings.Add("text", theInYardBindingSource, "TransactionID", False, DataSourceUpdateMode.Never)
            End With

            'setting up the rest of the controls
            txtBJCNumber.DataBindings.Add("text", theInYardBindingSource, "BJCNumber")
            txtDate.DataBindings.Add("text", theInYardBindingSource, "Date")
            txtSheetPresent.DataBindings.Add("text", theInYardBindingSource, "InYard")

            'getting ready for the loop
            intNumberOfRecords = cboTransactionID.Items.Count - 1
            ReDim structInYard(intNumberOfRecords)
            mintInYardCounter = 0

            'beginning Loop
            For intCounter = 0 To intNumberOfRecords

                'incrementing the combo box
                cboTransactionID.SelectedIndex = intCounter

                'getting the date
                datTransactionDate = CDate(txtDate.Text)
                datTransactionDate = TheDateSearchClass.RemoveTime(datTransactionDate)

                'if statements
                If datTransactionDate >= mdatStartingDate And datTransactionDate <= mdatEndingDate Then

                    structInYard(mintInYardCounter).mstrInYard = txtSheetPresent.Text
                    structInYard(mintInYardCounter).mdatTransactionDate = datTransactionDate
                    structInYard(mintInYardCounter).mintBJCNumber = CInt(txtBJCNumber.Text)
                    structInYard(mintInYardCounter).mintTransactionID = CInt(cboTransactionID.Text)
                    mintInYardCounter += 1

                End If
            Next

            'finishing the search
            If mintInYardCounter > 0 Then
                mintInYardUpperLimit = mintInYardCounter - 1
                mintInYardCounter = 0
            Else
                mintInYardUpperLimit = 0
            End If

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
    Private Function SetHistoryDataBindings() As Boolean

        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim blnFatalError As Boolean = False
        Dim blnNoItemsFound As Boolean = True
        Dim datTransactionDate As Date

        'try catch for exceptions
        Try

            'setting the data variables
            TheHistoryDataTier = New VehicleHistoryDataTier
            TheHistoryDataSet = TheHistoryDataTier.GetVehicleHistoryInformation
            TheHistoryBindingSource = New BindingSource

            'setting up the binding source
            With TheHistoryBindingSource
                .DataSource = TheHistoryDataSet
                .DataMember = "vehiclehistory"
                .MoveFirst()
                .MoveLast()
            End With

            'setting up the combo box
            With cboTransactionID
                .DataSource = TheHistoryBindingSource
                .DisplayMember = "TransactionID"
                .DataBindings.Add("text", TheHistoryBindingSource, "TransactionID", False, DataSourceUpdateMode.Never)
            End With

            'setting up the rest of the controls
            txtBJCNumber.DataBindings.Add("text", TheHistoryBindingSource, "VehicleID")
            txtDate.DataBindings.Add("text", TheHistoryBindingSource, "Date")
            txtSheetPresent.DataBindings.Add("text", TheHistoryBindingSource, "EmployeeID")
            txtDOTForm.DataBindings.Add("text", TheHistoryBindingSource, "Notes")

            'setting up for the loop
            intNumberOfRecords = cboTransactionID.Items.Count - 1
            ReDim structHistory(intNumberOfRecords)
            mintHistoryCounter = 0

            'beginning loop
            For intCounter = 0 To intNumberOfRecords

                'incrementing the combo box
                cboTransactionID.SelectedIndex = intCounter

                'setting the date of the transaction
                datTransactionDate = CDate(txtDate.Text)
                datTransactionDate = TheDateSearchClass.RemoveTime(datTransactionDate)

                If datTransactionDate >= mdatStartingDate And datTransactionDate <= mdatEndingDate Then

                    structHistory(mintHistoryCounter).mintEmployeeID = CInt(txtSheetPresent.Text)
                    structHistory(mintHistoryCounter).mintVehicleID = CInt(txtBJCNumber.Text)
                    structHistory(mintHistoryCounter).mdatTransactionDate = datTransactionDate
                    structHistory(mintHistoryCounter).mintTransactionID = CInt(cboTransactionID.Text)
                    structHistory(mintHistoryCounter).mstrNotes = txtDOTForm.Text
                    mintHistoryCounter += 1
                    blnNoItemsFound = False

                End If
            Next

            If blnNoItemsFound = True Then
                blnFatalError = True
                mstrErrorMessage = "No Items Found for this Date Range"
            ElseIf blnNoItemsFound = False Then
                mintHistoryUpperLimit = mintHistoryCounter - 1
                mintHistoryCounter = 0
            End If

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
    Private Function SetEmployeeBindings() As Boolean

        'setting local variables
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim blnFatalError As Boolean
        Dim blnNoItemsFound As Boolean = True

        'try catch for exceptions
        Try

            'setting up the data controls
            TheEmployeeDataTier = New EmployeeDataTier
            TheEmployeeDataSet = TheEmployeeDataTier.GetEmployeeInformation
            TheEmployeeBindingSource = New BindingSource

            'settting up the binding source
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
            txtDate.DataBindings.Add("Text", TheEmployeeBindingSource, "LastName")

            'setting for the loop
            intNumberOfRecords = cboTransactionID.Items.Count - 1
            ReDim structEmployees(intNumberOfRecords)
            mintEmployeeCounter = 0

            'loading the structure
            For intCounter = 0 To intNumberOfRecords

                'incrementing the combo box
                cboTransactionID.SelectedIndex = intCounter

                'loading structure
                structEmployees(mintEmployeeCounter).mintEmployeeID = CInt(cboTransactionID.Text)
                structEmployees(mintEmployeeCounter).mstrFirstName = txtBJCNumber.Text
                structEmployees(mintEmployeeCounter).mstrLastName = txtDate.Text
                mintEmployeeCounter += 1
                blnNoItemsFound = False
            Next

            mintEmployeeUpperLimit = mintEmployeeCounter - 1
            mintEmployeeCounter = 0

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
    Private Function SetVehicleBindings() As Boolean

        'setting local variables
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim strActive As String
        Dim blnFatalError As Boolean = False
        Dim blnNoItemsFound As Boolean = True

        'try catch for exceptions
        Try

            'setting up the data variables
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

            'setting up the combo box
            With cboTransactionID
                .DataSource = TheVehicleBindingSource
                .DisplayMember = "VehicleID"
                .DataBindings.Add("text", TheVehicleBindingSource, "VehicleID", False, DataSourceUpdateMode.Never)
            End With

            'setting up the rest of the controls
            txtBJCNumber.DataBindings.Add("text", TheVehicleBindingSource, "BJCNumber")
            txtSheetPresent.DataBindings.Add("text", TheVehicleBindingSource, "Active")
            txtDate.DataBindings.Add("text", TheVehicleBindingSource, "OutOfTown")
            txtDOTForm.DataBindings.Add("text", TheVehicleBindingSource, "DOTFormRequired")
            txtHomeOffice.DataBindings.Add("text", TheVehicleBindingSource, "HomeOffice")

            'getting ready for the loop
            intNumberOfRecords = cboTransactionID.Items.Count - 1
            ReDim structVehicles(intNumberOfRecords)
            ReDim structSearchResults(intNumberOfRecords * (mintNumberOfDays + 1))
            mintTempUpperLimit = intNumberOfRecords * (mintNumberOfDays + 1)
            ReDim structTemp(mintTempUpperLimit)
            mintVehicleCounter = 0

            'beginning loop
            For intCounter = 0 To intNumberOfRecords

                'incrementing the combo box
                cboTransactionID.SelectedIndex = intCounter

                'getting if vehicle is active
                strActive = txtSheetPresent.Text

                If strActive = "YES" Then

                    structVehicles(mintVehicleCounter).mintVehicleID = CInt(cboTransactionID.Text)
                    structVehicles(mintVehicleCounter).mintBJCNumber = CInt(txtBJCNumber.Text)
                    structVehicles(mintVehicleCounter).mstrRemoteVehicle = txtDate.Text
                    structVehicles(mintVehicleCounter).mstrDOTFormRequired = txtDOTForm.Text
                    structVehicles(mintVehicleCounter).mstrHomeOffice = txtHomeOffice.Text
                    mintVehicleCounter += 1
                    blnNoItemsFound = False

                End If
            Next

            If blnNoItemsFound = True Then
                mstrErrorMessage = "No Active Vehicles were Found"
                blnFatalError = True
            ElseIf blnNoItemsFound = False Then
                mintVehicleUpperLimit = mintVehicleCounter - 1
                mintVehicleCounter = 0
            End If

            'returning value to calling sub-routine
            Return blnFatalError

        Catch ex As Exception

            mstrErrorMessage = ex.Message
            blnFatalError = True

            'returning value to calling sub-routine
            Return blnFatalError

        End Try
    End Function
    Private Sub ClearDataBindings()

        'clearing the data bindings
        cboTransactionID.DataBindings.Clear()
        txtBJCNumber.DataBindings.Clear()
        txtDate.DataBindings.Clear()
        txtSheetPresent.DataBindings.Clear()
        txtDOTForm.DataBindings.Clear()

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

        'Setting up for default position
        PrintY = 100

        'Setting up for the print header
        PrintX = 200
        e.Graphics.DrawString("Blue Jay Communications Daily Audit Report", PrintHeaderFont, Brushes.Black, PrintX, PrintY)
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
        e.Graphics.DrawString("DOT Form", PrintItemsFont, Brushes.Black, PrintX, PrintY)
        PrintX = 700
        e.Graphics.DrawString("Inspection", PrintItemsFont, Brushes.Black, PrintX, PrintY)
        PrintX = 800
        e.Graphics.DrawString("Signed Out", PrintItemsFont, Brushes.Black, PrintX, PrintY)
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
            PrintX = 600
            e.Graphics.DrawString(structSearchResults(intCounter).mstrInspection, PrintItemsFont, Brushes.Black, PrintX, PrintY)
            PrintX = 700
            e.Graphics.DrawString(structSearchResults(intCounter).mstrInventory, PrintItemsFont, Brushes.Black, PrintX, PrintY)
            PrintX = 800
            e.Graphics.DrawString(structSearchResults(intCounter).mstrSignedOut, PrintItemsFont, Brushes.Black, PrintX, PrintY)
            PrintY = PrintY + ItemLineHeight


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
                intCounter = mintResultUpperLimit
            End If


        Next

    End Sub
End Class