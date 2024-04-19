'Title:         Weekly Vehicle Inspection Report
'Date:          11-3-14
'Author:        Terry Holmes

'Description:   This form is used to run the Weekly Vehicle Inspection Report

Option Strict On

Public Class WeeklyVehicleInspectionsReport

    'Setting Modular Variables
    Private TheEmployeeDataSet As EmployeeDataSet
    Private TheEmployeeDataTier As EmployeeDataTier
    Private WithEvents TheEmployeeBindingSource As BindingSource

    Private TheVehiclesDataSet As VehiclesDataSet
    Private TheVehiclesDataTier As VehiclesDataTier
    Private WithEvents TheVehiclesBindingSource As BindingSource

    Private TheWeeklyVehicleInspectionsDataSet As WeeklyVehicleInspectionsDataSet
    Private TheWeeklyVehicleInspectionDataTier As WeeklyVehicleInpectionDataTier
    Private WithEvents TheWeeklyVehicleInspectionBindingSource As BindingSource

    Private addingBoolean As Boolean = False
    Private editingBoolean As Boolean = False
    Private previousSelectedIndex As Integer
    Dim mintNumuberOfRecords As Integer

    Dim TheInputDataValidation As New InputDataValidation

    Dim mintDateCounter As Integer
    Dim mintDateSelectedIndex(3000) As Integer
    Dim mintDateUpperLimit As Integer

    Dim mintBJCNumber(3000) As Integer

    Dim mintPrintLoopStartNumber As Integer = 0

    'Setting up for the date
    Dim datLogDate As Date = Date.Now
    Dim mstrLogDate As String

    Private Sub btnVehicleInspectionReports_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVehicleInspectionReports.Click

        'This will launch the Vehicle Inspection Reports Menu
        ClearDataBindings()
        LastTransaction.Show()
        VehicleInspectionReports.Show()
        Me.Close()

    End Sub
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        'Closes the Program
        CloseTheProgram.ShowDialog()

    End Sub

    Private Sub btnInspectionMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInspectionMenu.Click

        'Opens the Tool Menu
        ClearDataBindings()
        LastTransaction.Show()
        InspectionsMenu.Show()
        Me.Close()

    End Sub

    Private Sub btnMainMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMainMenu.Click

        'This opens the Main menu
        ClearDataBindings()
        LastTransaction.Show()
        MainMenu.Show()
        Me.Close()

    End Sub
    Private Sub ClearDataBindings()

        'this will clear the combo boxes
        cboEmployeeID.DataBindings.Clear()
        cboInspectionID.DataBindings.Clear()
        cboVehicleID.DataBindings.Clear()

        'This will clear the text boxes
        txtFirstName.DataBindings.Clear()
        txtInspectionBJCNumber.DataBindings.Clear()
        txtInspectionCurrentOdometer.DataBindings.Clear()
        txtInspectionDate.DataBindings.Clear()
        txtInspectionEmployeeID.DataBindings.Clear()
        txtInspectionNextOilChangeOdometer.DataBindings.Clear()
        txtInspectionNotes.DataBindings.Clear()
        txtInspectionVehicleID.DataBindings.Clear()
        txtLastName.DataBindings.Clear()
        txtPhoneNumber.DataBindings.Clear()
        txtVehicleBJCNumber.DataBindings.Clear()
        txtVehicleEmployeeID.DataBindings.Clear()
        txtVehicleLastOilChangeDate.DataBindings.Clear()
        txtVehicleLastOilChangeOdometer.DataBindings.Clear()
        txtVehicleMake.DataBindings.Clear()
        txtVehicleModel.DataBindings.Clear()

    End Sub

    Private Sub WeeklyVehicleInspectionsReport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Setting Local Variables
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim datStartDateForSearch As Date
        Dim datEndingDateForSearch As Date
        Dim datDateFromTable As Date
        Dim intDay As Integer
        Dim intMonth As Integer
        Dim intYear As Integer
        Dim strCreatedDate As String
        Dim blnNoInspectionsDone As Boolean = True

        Try

            'This will bind the controls to the data source
            TheVehiclesDataTier = New VehiclesDataTier
            TheVehiclesDataSet = TheVehiclesDataTier.GetVehiclesInformation
            TheVehiclesBindingSource = New BindingSource

            'Setting the binding for the combo box
            With TheVehiclesBindingSource
                .DataSource = TheVehiclesDataSet
                .DataMember = "vehicles"
                .MoveFirst()
                .MoveLast()
            End With

            'Binding controls to for the binding for the combo box
            With cboVehicleID
                .DataSource = TheVehiclesBindingSource
                .DisplayMember = "VehicleID"
                .DataBindings.Add("text", TheVehiclesBindingSource, "VehicleID", False, DataSourceUpdateMode.Never)
            End With

            'Setting the binding for all other textbox controls
            txtVehicleBJCNumber.DataBindings.Add("text", TheVehiclesBindingSource, "BJCNumber")
            txtVehicleEmployeeID.DataBindings.Add("text", TheVehiclesBindingSource, "EmployeeID")
            txtVehicleLastOilChangeOdometer.DataBindings.Add("text", TheVehiclesBindingSource, "LastOilChangeOdometer")
            txtVehicleLastOilChangeDate.DataBindings.Add("text", TheVehiclesBindingSource, "LastOilChangeDate")
            txtVehicleMake.DataBindings.Add("text", TheVehiclesBindingSource, "Make")
            txtVehicleModel.DataBindings.Add("text", TheVehiclesBindingSource, "Model")

            'This will bind the controls to the data source
            TheEmployeeDataTier = New EmployeeDataTier
            TheEmployeeDataSet = TheEmployeeDataTier.GetEmployeeInformation
            TheEmployeeBindingSource = New BindingSource

            'Setting up Binding Source for the Combo Box
            With TheEmployeeBindingSource
                .DataSource = TheEmployeeDataSet
                .DataMember = "employees"
                .MoveFirst()
                .MoveLast()
            End With

            'Setting the data relationship for the Combo Box
            With cboEmployeeID
                .DataSource = TheEmployeeBindingSource
                .DisplayMember = "EmployeeID"
                .DataBindings.Add("text", TheEmployeeBindingSource, "EmployeeID", False, DataSourceUpdateMode.Never)
            End With

            'Setting the data binding for the text boxes
            txtFirstName.DataBindings.Add("text", TheEmployeeBindingSource, "FirstName")
            txtLastName.DataBindings.Add("text", TheEmployeeBindingSource, "LastName")
            txtPhoneNumber.DataBindings.Add("text", TheEmployeeBindingSource, "PhoneNumber")

            TheWeeklyVehicleInspectionDataTier = New WeeklyVehicleInpectionDataTier
            TheWeeklyVehicleInspectionsDataSet = TheWeeklyVehicleInspectionDataTier.GetWeeklyVehicleInpectionInformation
            TheWeeklyVehicleInspectionBindingSource = New BindingSource

            'Setting the binding for the combo box
            With TheWeeklyVehicleInspectionBindingSource
                .DataSource = TheWeeklyVehicleInspectionsDataSet
                .DataMember = "WeeklyVehicleInspections"
                .MoveFirst()
                .MoveLast()
            End With

            'Binding controls to for the binding for the combo box
            With cboInspectionID
                .DataSource = TheWeeklyVehicleInspectionBindingSource
                .DisplayMember = "InspectionID"
                .DataBindings.Add("text", TheWeeklyVehicleInspectionBindingSource, "InspectionID", False, DataSourceUpdateMode.Never)
            End With

            txtInspectionVehicleID.DataBindings.Add("text", TheWeeklyVehicleInspectionBindingSource, "VehicleID")
            txtInspectionBJCNumber.DataBindings.Add("text", TheWeeklyVehicleInspectionBindingSource, "BJCNumber")
            txtInspectionEmployeeID.DataBindings.Add("text", TheWeeklyVehicleInspectionBindingSource, "EmployeeID")
            txtInspectionCurrentOdometer.DataBindings.Add("text", TheWeeklyVehicleInspectionBindingSource, "CurrentOdometer")
            txtInspectionDate.DataBindings.Add("text", TheWeeklyVehicleInspectionBindingSource, "InspectionDate")
            txtInspectionNextOilChangeOdometer.DataBindings.Add("text", TheWeeklyVehicleInspectionBindingSource, "NextOilChangeOdometer")
            txtInspectionNotes.DataBindings.Add("text", TheWeeklyVehicleInspectionBindingSource, "InspectionNotes")

            'Setting up to make the entry for the last transaction update
            LastTransaction.Show()

            'Creating the starting day
            intDay = Logon.mdatStartingDate.Day
            intMonth = Logon.mdatStartingDate.Month
            intYear = Logon.mdatStartingDate.Year

            'Creating Date for Starting Date
            strCreatedDate = CStr(intMonth) + "/" + CStr(intDay) + "/" + CStr(intYear)

            'Placing the date in the correct variable
            datStartDateForSearch = CDate(strCreatedDate)

            'Creating the ending day
            intDay = Logon.mdatEndingDate.Day
            intMonth = Logon.mdatEndingDate.Month
            intYear = Logon.mdatEndingDate.Year

            'Creating Date for Starting Date
            strCreatedDate = CStr(intMonth) + "/" + CStr(intDay) + "/" + CStr(intYear)

            'Saving the date to a variable
            datEndingDateForSearch = CDate(strCreatedDate)

            'Setting up for the loop
            intNumberOfRecords = cboInspectionID.Items.Count - 1
            mintDateCounter = 0

            'Beginning the loop
            For intCounter = 0 To intNumberOfRecords

                'Incrementing the combo box
                cboInspectionID.SelectedIndex = intCounter

                'Creating the date
                datDateFromTable = CDate(txtInspectionDate.Text)

                'Making the date searchable
                intDay = datDateFromTable.Day
                intMonth = datDateFromTable.Month
                intYear = datDateFromTable.Year

                'Creating Date for Starting Date
                strCreatedDate = CStr(intMonth) + "/" + CStr(intDay) + "/" + CStr(intYear)

                'Saving the date to a variable
                datDateFromTable = CDate(strCreatedDate)

                'If Statement to see if the date is within the range
                If datDateFromTable >= datStartDateForSearch And datDateFromTable <= datEndingDateForSearch Then

                    'Saving the items to the array
                    mintDateSelectedIndex(mintDateCounter) = intCounter
                    mintDateCounter += 1
                    blnNoInspectionsDone = False

                End If

            Next

            If blnNoInspectionsDone = True Then
                MessageBox.Show("No Inspections Done Within the Date Range", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Information)
                VehicleInspectionReports.Show()
                Me.Close()
            End If

            'Setting up for mutiple items
            mintDateUpperLimit = mintDateCounter - 1
            mintDateCounter = 0
            SortSelectedIndexByDate()
            cboInspectionID.SelectedIndex = mintDateSelectedIndex(0)
            FindEmployeeVehicle()

            If mintDateUpperLimit > 0 Then
                btnNext.Enabled = True
            End If

        Catch ex As Exception

            'If an exception is thrown, it is rounted here
            MessageBox.Show(ex.Message, "There is an Error With Vehicle Bindings", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub
    Private Sub FillGlobalLastTransactionString(ByVal strValueInputted As String)

        'Filling Entry
        mstrLogDate = CStr(datLogDate)
        Logon.mstrLastTransactionSummary = mstrLogDate + " " + strValueInputted

    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click

        'This will increment the combo box
        mintDateCounter += 1
        cboInspectionID.SelectedIndex = mintDateSelectedIndex(mintDateCounter)

        FindEmployeeVehicle()

        btnBack.Enabled = True

        'Disabling the button if condition is met
        If mintDateCounter = mintDateUpperLimit Then
            btnNext.Enabled = False
        End If

    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click

        'This will increment the combo box
        mintDateCounter -= 1
        cboInspectionID.SelectedIndex = mintDateSelectedIndex(mintDateCounter)

        FindEmployeeVehicle()

        btnNext.Enabled = True

        'Disabling the button if condition is met
        If mintDateCounter = 0 Then
            btnBack.Enabled = False
        End If

    End Sub
    Private Sub FindEmployeeVehicle()

        'Setting local variables
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim intSelectedIndex As Integer
        Dim intEmployeeIDForSearch As Integer
        Dim intEmployeeIDFromTable As Integer
        Dim intVehicleIDForSearch As Integer
        Dim intVehicleIDFromTable As Integer

        'Setting up for Search
        intNumberOfRecords = cboEmployeeID.Items.Count - 1
        intEmployeeIDForSearch = CInt(txtInspectionEmployeeID.Text)

        'Beginning the loop
        For intCounter = 0 To intNumberOfRecords

            'Incrementing the combo box
            cboEmployeeID.SelectedIndex = intCounter

            'Setting the variable
            intEmployeeIDFromTable = CInt(cboEmployeeID.Text)

            'Performing If Statements
            If intEmployeeIDForSearch = intEmployeeIDFromTable Then

                'Setting variable if condition is met
                intSelectedIndex = intCounter

            End If
        Next

        'Setting the combo box for employee
        cboEmployeeID.SelectedIndex = intSelectedIndex

        'Getting ready for search for vehicles
        intNumberOfRecords = cboVehicleID.Items.Count - 1
        intVehicleIDForSearch = CInt(txtInspectionVehicleID.Text)

        'Beginning Loop
        For intCounter = 0 To intNumberOfRecords

            'Incrementing the counter
            cboVehicleID.SelectedIndex = intCounter

            'Loading up the variables
            intVehicleIDFromTable = CInt(cboVehicleID.Text)

            'Performing If statements for condition
            If intVehicleIDForSearch = intVehicleIDFromTable Then

                'Setting variable
                intSelectedIndex = intCounter
            End If

        Next

        'Setting the combo box
        cboVehicleID.SelectedIndex = intSelectedIndex

    End Sub


    Private Sub btnRunReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRunReport.Click

        'Setting up for the printer dialog box
        PrintDialog1.PrinterSettings = PrintDocument1.PrinterSettings

        'Calling the printer dialog box
        If PrintDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            PrintDocument1.PrinterSettings = PrintDialog1.PrinterSettings
        End If

        LastTransaction.Show()

        mintPrintLoopStartNumber = 0
        PrintDocument1.Print()

    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage

        'This sub-routine will print out the report
        Dim intCounter As Integer
        Dim blnnewPage As Boolean = False

        'Setting up for making the notes multiple lines
        Dim intCharCounter As Integer
        Dim intArrayLength As Integer
        Dim intStartCharCounter As Integer
        Dim intCharUpplerLimit As Integer
        Dim intNotesUpperLimit As Integer
        Dim charNotesArray() As Char
        Dim strNewString As String = ""
        Dim intStringCounter As Integer
        Dim strStartDate As String
        Dim strEndingDate As String

        'Local Variables for the report
        Dim PrintHeaderFont As New Font("Arial", 18, FontStyle.Bold)
        Dim PrintSubHeaderFont As New Font("Arial", 14, FontStyle.Bold)
        Dim PrintItemsFont As New Font("Arial", 10, FontStyle.Regular)
        Dim sngPrintX As Single = e.MarginBounds.Left
        Dim sngPrintY As Single = e.MarginBounds.Top
        Dim HeadingLineHeight As Single = PrintHeaderFont.GetHeight + 18
        Dim ItemLineHeight As Single = PrintItemsFont.GetHeight + 10

        'To change the dates to just the date
        Dim datDateToChange As Date
        Dim intDay As Integer
        Dim intMonth As Integer
        Dim intYear As Integer
        Dim strDateForReport As String
        Dim intStartCounter As Integer

        Dim intNextOilChangeOdometer As Integer

        intStartCounter = mintPrintLoopStartNumber
        mstrLogDate = CStr(datLogDate)

        'Setting up for default position
        sngPrintY = 100

        'Setting up the print header
        sngPrintX = 200
        e.Graphics.DrawString("Blue Jay Communications Weekly Inspection Report", PrintHeaderFont, Brushes.Black, sngPrintX, sngPrintY)
        sngPrintY = sngPrintY + HeadingLineHeight
        sngPrintX = 350
        strStartDate = CStr(Logon.mdatStartingDate)
        strEndingDate = CStr(Logon.mdatEndingDate)
        e.Graphics.DrawString("From: " + strStartDate + " To " + strEndingDate, PrintSubHeaderFont, Brushes.Black, sngPrintX, sngPrintY)
        sngPrintY = sngPrintY + HeadingLineHeight
        sngPrintY = sngPrintY + HeadingLineHeight

        'Setting up column headers
        sngPrintX = 75
        e.Graphics.DrawString("BJC Number", PrintItemsFont, Brushes.Black, sngPrintX, sngPrintY)
        sngPrintX = 175
        e.Graphics.DrawString("Insp. Date", PrintItemsFont, Brushes.Black, sngPrintX, sngPrintY)
        sngPrintX = 275
        e.Graphics.DrawString("Last LOF Date", PrintItemsFont, Brushes.Black, sngPrintX, sngPrintY)
        sngPrintX = 400
        e.Graphics.DrawString("Last LOF Odometer", PrintItemsFont, Brushes.Black, sngPrintX, sngPrintY)
        sngPrintX = 550
        e.Graphics.DrawString("Next LOF Odometer", PrintItemsFont, Brushes.Black, sngPrintX, sngPrintY)
        sngPrintX = 700
        e.Graphics.DrawString("Inspection Notes", PrintItemsFont, Brushes.Black, sngPrintX, sngPrintY)
        sngPrintY = sngPrintY + HeadingLineHeight

        For intCounter = intStartCounter To mintDateUpperLimit

            'incrementing the combo box
            cboInspectionID.SelectedIndex = mintDateSelectedIndex(intCounter)

            'Settting up the other information
            FindEmployeeVehicle()

            sngPrintX = 75
            e.Graphics.DrawString(txtInspectionBJCNumber.Text, PrintItemsFont, Brushes.Black, sngPrintX, sngPrintY)
            sngPrintX = 175

            'Changing the date
            datDateToChange = CDate(txtInspectionDate.Text)

            intDay = datDateToChange.Day
            intMonth = datDateToChange.Month
            intYear = datDateToChange.Year

            strDateForReport = CStr(intMonth) + "/" + CStr(intDay) + "/" + CStr(intYear)

            e.Graphics.DrawString(strDateForReport, PrintItemsFont, Brushes.Black, sngPrintX, sngPrintY)
            sngPrintX = 275

            'Changing the date
            datDateToChange = CDate(txtVehicleLastOilChangeDate.Text)

            intDay = datDateToChange.Day
            intMonth = datDateToChange.Month
            intYear = datDateToChange.Year

            strDateForReport = CStr(intMonth) + "/" + CStr(intDay) + "/" + CStr(intYear)

            e.Graphics.DrawString(strDateForReport, PrintItemsFont, Brushes.Black, sngPrintX, sngPrintY)
            sngPrintX = 400
            e.Graphics.DrawString(txtVehicleLastOilChangeOdometer.Text, PrintItemsFont, Brushes.Black, sngPrintX, sngPrintY)
            sngPrintX = 550

            'Getting the next odometer reading
            intNextOilChangeOdometer = CInt(txtVehicleLastOilChangeOdometer.Text)
            intNextOilChangeOdometer = intNextOilChangeOdometer + 3000

            e.Graphics.DrawString(CStr(intNextOilChangeOdometer), PrintItemsFont, Brushes.Black, sngPrintX, sngPrintY)

            If txtInspectionNotes.Text = "" Then

                strNewString = txtInspectionNotes.Text
                sngPrintX = 700
                e.Graphics.DrawString(strNewString, PrintItemsFont, Brushes.Black, sngPrintX, sngPrintY)
                sngPrintY = sngPrintY + HeadingLineHeight

            Else

                'Loading up Character Array
                charNotesArray = txtInspectionNotes.Text.ToCharArray

                'Setting the length
                intArrayLength = txtInspectionNotes.Text.Length - 1

                intNotesUpperLimit = CInt(intArrayLength / 25) - 1

                If intNotesUpperLimit = 0 Then
                    strNewString = txtInspectionNotes.Text
                    sngPrintX = 700
                    e.Graphics.DrawString(strNewString, PrintItemsFont, Brushes.Black, sngPrintX, sngPrintY)
                    'sngPrintY = sngPrintY + HeadingLineHeight

                End If
                If intNotesUpperLimit > 0 Then

                    intStartCharCounter = 0
                    intCharUpplerLimit = 25
                    intStringCounter = 0

                    strNewString = ""

                    For intCharCounter = intStartCharCounter To intArrayLength

                        strNewString = strNewString + CStr(charNotesArray(intCharCounter))
                        intStringCounter += 1
                        If intStringCounter = intCharUpplerLimit Then
                            If charNotesArray(intCharCounter) <> " " Then
                                intCharUpplerLimit += 1
                            End If
                        End If

                        If intStringCounter = intCharUpplerLimit Then
                            If intStringCounter = intCharUpplerLimit Then
                                sngPrintX = 700
                                e.Graphics.DrawString(strNewString, PrintItemsFont, Brushes.Black, sngPrintX, sngPrintY)
                                sngPrintY = sngPrintY + ItemLineHeight
                                strNewString = ""
                                intStringCounter = 0
                            End If

                        End If
                        If intCharCounter = intArrayLength Then
                            sngPrintX = 700
                            e.Graphics.DrawString(strNewString, PrintItemsFont, Brushes.Black, sngPrintX, sngPrintY)
                            'sngPrintY = sngPrintY + HeadingLineHeight
                            strNewString = ""
                            intStringCounter = 0
                        End If

                    Next

                End If
                sngPrintY = sngPrintY + HeadingLineHeight
            End If


            If sngPrintY > 700 Then

                If intCounter = mintDateUpperLimit Then
                    e.HasMorePages = False
                Else
                    e.HasMorePages = True
                    blnnewPage = True
                End If

            End If

            If blnnewPage = True Then
                mintPrintLoopStartNumber = intCounter + 1
                intCounter = mintDateUpperLimit
            End If
        Next

    End Sub

    Private Sub PrintDocument1_QueryPageSettings(ByVal sender As Object, ByVal e As System.Drawing.Printing.QueryPageSettingsEventArgs) Handles PrintDocument1.QueryPageSettings

        'This will set the page to landscape
        e.PageSettings.Landscape = True

    End Sub

    Private Sub SortSelectedIndexByDate()

        Dim intDay As Integer
        Dim intMonth As Integer
        Dim intYear As Integer
        Dim strDateForSearch As String
        Dim datDateForSearch As Date
        Dim datDateFromTable As Date
        Dim datStartDate As Date
        Dim datEndDate As Date
        Dim intFirstCounter As Integer
        Dim intSecondCounter As Integer
        Dim intSelectedIndexCounter As Integer
        Dim intSelectedIndexForNewArray(5000) As Integer
        Dim intStartDayOfTheYear As Integer
        Dim intEndingDayOfTheYear As Integer
        Dim intLeapYearRemainder As Integer
        Dim intNumberOfLoops As Integer

        'Loading up the Start and End Dates
        datStartDate = Logon.mdatStartingDate
        datEndDate = Logon.mdatEndingDate

        intStartDayOfTheYear = datStartDate.DayOfYear
        intEndingDayOfTheYear = datEndDate.DayOfYear

        'Computing the number of days for the loop
        If intStartDayOfTheYear > intEndingDayOfTheYear Then

            'Breaking out the date
            intDay = datEndDate.Day
            intMonth = datEndDate.Month
            intYear = datEndDate.Year

            intLeapYearRemainder = intYear Mod 4

            'Logic to Compinsate for leap year and end of the year
            If intLeapYearRemainder = 0 Then

                If intMonth = 2 And intDay = 29 Then
                    intEndingDayOfTheYear = intEndingDayOfTheYear + 366
                ElseIf intMonth > 2 Then
                    intEndingDayOfTheYear = intEndingDayOfTheYear + 366
                Else
                    intEndingDayOfTheYear = intEndingDayOfTheYear + 365
                End If

            Else
                intEndingDayOfTheYear = intEndingDayOfTheYear + 365
            End If

        End If

        'Setting the initial counts
        datDateForSearch = datStartDate
        intSelectedIndexCounter = 0

        'Getting the number of loop for each day
        intNumberOfLoops = intEndingDayOfTheYear - intStartDayOfTheYear

        'This will increment for the number days for the loop
        For intFirstCounter = 0 To intNumberOfLoops

            'Second loop for each of the selected index 
            For intSecondCounter = 0 To mintDateUpperLimit

                'Locating the correct
                cboInspectionID.SelectedIndex = mintDateSelectedIndex(intSecondCounter)
                datDateFromTable = CDate(txtInspectionDate.Text)

                'Breaking the date out
                intDay = datDateFromTable.Day
                intMonth = datDateFromTable.Month
                intYear = datDateFromTable.Year

                'Putting the date back together
                strDateForSearch = CStr(intMonth) + "/" + CStr(intDay) + "/" + CStr(intYear)

                datDateFromTable = CDate(strDateForSearch)

                If datDateForSearch = datDateFromTable Then

                    intSelectedIndexForNewArray(intSelectedIndexCounter) = mintDateSelectedIndex(intSecondCounter)
                    intSelectedIndexCounter += 1

                End If
            Next

            'Putting the next date together
            intDay = datDateForSearch.Day
            intMonth = datDateForSearch.Month
            intYear = datDateForSearch.Year

            'Incrementing the day
            intDay += 1

            'If Statements to see if the month is changed
            If intMonth = 12 And intDay = 32 Then

                intMonth = 1
                intDay = 1
                intYear += 1

            ElseIf intMonth = 1 And intDay = 32 Then

                intDay = 1
                intMonth = 2

            ElseIf intMonth = 2 Then

                intLeapYearRemainder = intYear Mod 4

                If intLeapYearRemainder = 0 Then
                    If intDay = 30 Then

                        intMonth = 3
                        intDay = 1

                    End If
                Else

                    If intDay = 29 Then

                        intMonth = 3
                        intDay = 1

                    End If
                End If

            ElseIf intMonth = 3 And intDay = 32 Then

                intDay = 1
                intMonth = 4

            ElseIf intMonth = 5 And intDay = 32 Then

                intDay = 1
                intMonth = 6

            ElseIf intMonth = 7 And intDay = 32 Then

                intDay = 1
                intMonth = 8

            ElseIf intMonth = 8 And intDay = 32 Then

                intDay = 1
                intMonth = 9

            ElseIf intMonth = 10 And intDay = 32 Then

                intDay = 1
                intMonth = 11

            ElseIf intMonth = 4 And intDay = 30 Then

                intDay = 1
                intMonth = 5

            ElseIf intMonth = 6 And intDay = 30 Then

                intDay = 1
                intMonth = 7

            ElseIf intMonth = 9 And intDay = 30 Then

                intDay = 1
                intMonth = 10

            ElseIf intMonth = 11 And intDay = 30 Then

                intDay = 1
                intMonth = 12

            End If

            strDateForSearch = CStr(intMonth) + "/" + CStr(intDay) + "/" + CStr(intYear)

            Try
                datDateForSearch = CDate(strDateForSearch)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        Next

        'Loading up the array
        For intFirstCounter = 0 To mintDateUpperLimit

            mintDateSelectedIndex(intFirstCounter) = intSelectedIndexForNewArray(intFirstCounter)

        Next

    End Sub
End Class