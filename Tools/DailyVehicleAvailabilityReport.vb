'Title:         Daily Vehicle Availability Report
'Date:          10/28/14
'Author:        Terry Holmes

'Description:   This form is used to run a report of vehicles that are in the yard

Option Strict On

Public Class DailyVehicleAvailabilityReport

    'Setting up the Vehicles Global Information
    Private TheVehiclesDataSet As VehiclesDataSet
    Private TheVehiclesDataTier As VehiclesDataTier
    Private WithEvents TheVehiclesBindingSource As BindingSource

    'Setting up the Employees Global Information
    Private TheEmployeeDataSet As EmployeeDataSet
    Private TheEmployeeDataTier As EmployeeDataTier
    Private WithEvents TheEmployeeBindingSource As BindingSource

    'Setting up the Vehicles In Yard Global Information
    Private TheVehicleInYardDataSet As VehicleInYardDataSet
    Private TheVehicleInYardDataTier As VehicleInYardDataTier
    Private WithEvents TheVehicleInYardBindingSource As BindingSource

    'Setting up the vehicle array
    Dim mintVehicleCounter As Integer
    Dim mintVehicleUpperLimit As Integer
    Dim mintVehicleSelectedIndex(1000) As Integer

    Dim mintTransactionCounter As Integer
    Dim mintTransactionUpperLimit As Integer
    Dim mintTransactionSelectedIndex(1000) As Integer

    'Setting up for the date
    Dim datLogDate As Date = Date.Now
    Dim mstrLogDate As String

    Dim mintNewPrintCounter As Integer

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        'Closes the Program
        CloseTheProgram.ShowDialog()

    End Sub

    Private Sub btnInspectionMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInspectionMenu.Click

        ClearDataBindings()
        InspectionsMenu.Show()
        Me.Close()

    End Sub

    Private Sub btnMainMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMainMenu.Click

        'This opens the Main menu
        ClearDataBindings()
        MainMenu.Show()
        Me.Close()

    End Sub

    Private Sub btnVehicleInspectionReportMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVehicleInspectionReportMenu.Click

        'This will open up the Vehicle Reports Menu
        ClearDataBindings()
        VehicleInspectionReports.Show()
        Me.Close()

    End Sub
    Private Sub ClearDataBindings()

        'This will clear the combo boxes
        cboEmployeeID.DataBindings.Clear()
        cboTransactionID.DataBindings.Clear()
        cboVehicleID.DataBindings.Clear()

        'This will clear the text boxes
        txtLastName.DataBindings.Clear()
        txtFirstName.DataBindings.Clear()
        txtTransactionBJCNumber.DataBindings.Clear()
        txtTransactionDate.DataBindings.Clear()
        txtVehicleActive.DataBindings.Clear()
        txtVehicleAvaiable.DataBindings.Clear()
        txtVehicleBJCNumber.DataBindings.Clear()
        txtVehicleEmployeeID.DataBindings.Clear()
        txtVehicleModel.DataBindings.Clear()

    End Sub


    Private Sub DailyVehicleAvailabilityReport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Preforming a Try Catch
        Try

            'Setting up the employee controls
            TheEmployeeDataTier = New EmployeeDataTier
            TheEmployeeDataSet = TheEmployeeDataTier.GetEmployeeInformation
            TheEmployeeBindingSource = New BindingSource

            'Setting up the employee binding source
            With TheEmployeeBindingSource
                .DataSource = TheEmployeeDataSet
                .DataMember = "employees"
                .MoveFirst()
                .MoveLast()
            End With

            'Setting up the employee combo box
            With cboEmployeeID
                .DataSource = TheEmployeeBindingSource
                .DisplayMember = "EmployeeID"
                .DataBindings.Add("text", TheEmployeeBindingSource, "EmployeeID", False, DataSourceUpdateMode.Never)
            End With

            'Setting up the rest of the controls
            txtLastName.DataBindings.Add("text", TheEmployeeBindingSource, "LastName")
            txtFirstName.DataBindings.Add("text", TheEmployeeBindingSource, "FirstName")

            'Setting up the vehicles
            TheVehiclesDataTier = New VehiclesDataTier
            TheVehiclesDataSet = TheVehiclesDataTier.GetVehiclesInformation
            TheVehiclesBindingSource = New BindingSource

            'Setting up the vehicles binding source
            With TheVehiclesBindingSource
                .DataSource = TheVehiclesDataSet
                .DataMember = "vehicles"
                .MoveFirst()
                .MoveLast()
            End With

            'Setting up the Vehicle Combo Box
            With cboVehicleID
                .DataSource = TheVehiclesBindingSource
                .DisplayMember = "VehicleID"
                .DataBindings.Add("text", TheVehiclesBindingSource, "VehicleID", False, DataSourceUpdateMode.Never)
            End With

            'Setting up the rest of the vehicle controls
            txtVehicleActive.DataBindings.Add("text", TheVehiclesBindingSource, "Active")
            txtVehicleAvaiable.DataBindings.Add("text", TheVehiclesBindingSource, "Available")
            txtVehicleBJCNumber.DataBindings.Add("text", TheVehiclesBindingSource, "BJCNumber")
            txtVehicleEmployeeID.DataBindings.Add("text", TheVehiclesBindingSource, "EmployeeID")
            txtVehicleModel.DataBindings.Add("text", TheVehiclesBindingSource, "Model")

            'Setting up for Vehicles in the Yard
            TheVehicleInYardDataTier = New VehicleInYardDataTier
            TheVehicleInYardDataSet = TheVehicleInYardDataTier.GetVehicleInYardInformation
            TheVehicleInYardBindingSource = New BindingSource

            'Setting up the Vehicles in yard binding source
            With TheVehicleInYardBindingSource
                .DataSource = TheVehicleInYardDataSet
                .DataMember = "vehicleinyard"
                .MoveFirst()
                .MoveLast()
            End With

            'Setting up the Vehicles in yard combo box
            With cboTransactionID
                .DataSource = TheVehicleInYardBindingSource
                .DisplayMember = "TransactionID"
                .DataBindings.Add("text", TheVehicleInYardBindingSource, "TransactionID", False, DataSourceUpdateMode.Never)
            End With

            'Setting up the rest of the vehicle in yard controls
            txtTransactionBJCNumber.DataBindings.Add("text", TheVehicleInYardBindingSource, "BJCNumber")
            txtTransactionDate.DataBindings.Add("text", TheVehicleInYardBindingSource, "Date")

            SetVehicleArray()
            SetControlsVisible(False)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub SetControlsVisible(ByVal valueBoolean As Boolean)

        'Setting the text boxes visible
        txtFirstName.Visible = valueBoolean
        txtLastName.Visible = valueBoolean
        txtTransactionBJCNumber.Visible = valueBoolean
        txtTransactionDate.Visible = valueBoolean
        txtVehicleActive.Visible = valueBoolean
        txtVehicleAvaiable.Visible = valueBoolean
        txtVehicleBJCNumber.Visible = valueBoolean
        txtVehicleEmployeeID.Visible = valueBoolean
        txtVehicleModel.Visible = valueBoolean

    End Sub
    Private Sub FindEmployee(ByVal intEmployeeIDForSearch As Integer)

        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim intSelectedIndex As Integer
        Dim intEmployeeIDFromTable As Integer

        'Getting information for search
        intNumberOfRecords = cboEmployeeID.Items.Count - 1

        'Beginning Loop
        For intCounter = 0 To intNumberOfRecords

            'Setting up the combo box
            cboEmployeeID.SelectedIndex = intCounter
            intEmployeeIDFromTable = CInt(cboEmployeeID.Text)

            If intEmployeeIDForSearch = intEmployeeIDFromTable Then

                'setting up the selected index
                intSelectedIndex = intCounter

            End If

        Next

        'Setting the combo box to the correct index
        cboEmployeeID.SelectedIndex = intSelectedIndex

    End Sub
    Private Sub FindVehicle(ByVal intBJCNumberForSearch As Integer)

        Dim intCounter As Integer
        Dim intBJCNumberFromTable As Integer
        Dim intSelectedIndex As Integer

        'Preforming Loop
        For intCounter = 0 To mintVehicleUpperLimit

            cboVehicleID.SelectedIndex = mintVehicleSelectedIndex(intCounter)
            intBJCNumberFromTable = CInt(txtVehicleBJCNumber.Text)

            If intBJCNumberForSearch = intBJCNumberFromTable Then
                intSelectedIndex = intCounter
            End If

        Next

        cboVehicleID.SelectedIndex = mintVehicleSelectedIndex(intSelectedIndex)

    End Sub
    Private Sub SetVehicleArray()

        'This sub routine will load an array with the selected index of only active vehicles

        'Setting local variables
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim strActiveFromTable As String

        'Setting up for search
        intNumberOfRecords = cboVehicleID.Items.Count - 1
        mintVehicleCounter = 0

        'Preforming loop
        For intCounter = 0 To intNumberOfRecords

            'Incrementing the combo box
            cboVehicleID.SelectedIndex = intCounter

            'Setting the value of the variable
            strActiveFromTable = txtVehicleActive.Text

            'Performing if statements
            If strActiveFromTable = "YES" Then

                'Setting value of the array
                mintVehicleSelectedIndex(mintVehicleCounter) = intCounter
                mintVehicleCounter += 1

            End If

        Next

        'Setting up the limiting variables
        mintVehicleUpperLimit = mintVehicleCounter - 1
        cboVehicleID.SelectedIndex = mintVehicleSelectedIndex(0)
        mintVehicleCounter = 0

    End Sub

    Private Sub btnRunReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRunReport.Click

        'This routine will run and print the report

        'Setting up the local variables
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim datSearchDate As Date
        Dim datTableDate As Date
        Dim intDateDays As Integer
        Dim intDateMonths As Integer
        Dim intDateYears As Integer
        Dim strDateForSearch As String
        Dim blnNoVehiclesFound As Boolean = True

        'Setting up for the search
        intDateDays = datLogDate.Day
        intDateMonths = datLogDate.Month
        intDateYears = datLogDate.Year

        'Setting date to a string
        strDateForSearch = CStr(intDateMonths) + "/" + CStr(intDateDays) + "/" + CStr(intDateYears)

        'try catch to convert the string to a date
        Try
            datSearchDate = CDate(strDateForSearch)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        mstrLogDate = CStr(datSearchDate)

        'Making controls visble
        SetControlsVisible(True)

        'Getting ready for loop
        intNumberOfRecords = cboTransactionID.Items.Count - 1
        mintTransactionCounter = 0

        'Beginning loop
        For intCounter = 0 To intNumberOfRecords

            'Incrementing the counter
            cboTransactionID.SelectedIndex = intCounter
            datTableDate = CDate(txtTransactionDate.Text)

            'If statements to see if the values fit the requirements
            If datTableDate = datSearchDate Then

                'Setting up the variables
                mintTransactionSelectedIndex(mintTransactionCounter) = intCounter
                mintTransactionCounter += 1
                blnNoVehiclesFound = False
            End If

        Next

        If blnNoVehiclesFound = True Then
            SetControlsVisible(False)
            MessageBox.Show("No Vehicles Were Found", "Thank You", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        'Setting up the selected index array
        mintTransactionUpperLimit = mintTransactionCounter - 1
        cboTransactionID.SelectedIndex = mintTransactionSelectedIndex(0)
        mintTransactionCounter = 0

        'Setting up for the printer dialog box
        PrintDialog1.PrinterSettings = PrintDocument1.PrinterSettings

        'Calling the printer dialog box
        If PrintDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            PrintDocument1.PrinterSettings = PrintDialog1.PrinterSettings
        End If

        mintNewPrintCounter = 0
        PrintDocument1.Print()

    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage

        'This sub-routine will print out the report
        Dim intArrayCounter As Integer
        Dim intBJCNumberForSearch As Integer
        Dim intEmployeeIDForSearch As Integer
        Dim intStartingArrayCounter As Integer
        Dim blnnewPage As Boolean = False

        'Local Variables for the report
        Dim PrintHeaderFont As New Font("Arial", 18, FontStyle.Bold)
        Dim PrintSubHeaderFont As New Font("Arial", 14, FontStyle.Bold)
        Dim PrintItemsFont As New Font("Arial", 10, FontStyle.Regular)
        Dim sngPrintX As Single = e.MarginBounds.Left
        Dim sngPrintY As Single = e.MarginBounds.Top
        Dim HeadingLineHeight As Single = PrintHeaderFont.GetHeight + 18
        Dim ItemLineHeight As Single = PrintItemsFont.GetHeight + 10

        intStartingArrayCounter = mintNewPrintCounter

        'Setting up for default position
        sngPrintY = 100

        'Setting up the print header
        sngPrintX = 150
        e.Graphics.DrawString("Blue Jay Communications Vehicle Report", PrintHeaderFont, Brushes.Black, sngPrintX, sngPrintY)
        sngPrintY = sngPrintY + HeadingLineHeight
        sngPrintX = 200
        e.Graphics.DrawString("Vehicles Currently In Warehouses", PrintHeaderFont, Brushes.Black, sngPrintX, sngPrintY)
        sngPrintY = sngPrintY + HeadingLineHeight
        sngPrintX = 300
        e.Graphics.DrawString("Date Of: " + mstrLogDate, PrintSubHeaderFont, Brushes.Black, sngPrintX, sngPrintY)
        sngPrintY = sngPrintY + HeadingLineHeight
        sngPrintY = sngPrintY + HeadingLineHeight

        'Setting up column headers
        sngPrintX = 75
        e.Graphics.DrawString("BJC Number", PrintItemsFont, Brushes.Black, sngPrintX, sngPrintY)
        sngPrintX = 200
        e.Graphics.DrawString("Type Of Vehicle", PrintItemsFont, Brushes.Black, sngPrintX, sngPrintY)
        sngPrintX = 400
        e.Graphics.DrawString("First Name", PrintItemsFont, Brushes.Black, sngPrintX, sngPrintY)
        sngPrintX = 600
        e.Graphics.DrawString("Last Name", PrintItemsFont, Brushes.Black, sngPrintX, sngPrintY)
        sngPrintY = sngPrintY + HeadingLineHeight

        'Beginning loop
        For intArrayCounter = intStartingArrayCounter To mintTransactionUpperLimit

            'incrementing the combo box
            cboTransactionID.SelectedIndex = mintTransactionSelectedIndex(intArrayCounter)
            intBJCNumberForSearch = CInt(txtTransactionBJCNumber.Text)

            'Finding the vehicle
            FindVehicle(intBJCNumberForSearch)

            'Finding the employee
            intEmployeeIDForSearch = CInt(txtVehicleEmployeeID.Text)
            FindEmployee(intEmployeeIDForSearch)

            'Printing the information
            sngPrintX = 75
            e.Graphics.DrawString(txtTransactionBJCNumber.Text, PrintItemsFont, Brushes.Black, sngPrintX, sngPrintY)
            sngPrintX = 200
            e.Graphics.DrawString(txtVehicleModel.Text, PrintItemsFont, Brushes.Black, sngPrintX, sngPrintY)
            sngPrintX = 400
            e.Graphics.DrawString(txtFirstName.Text, PrintItemsFont, Brushes.Black, sngPrintX, sngPrintY)
            sngPrintX = 600
            e.Graphics.DrawString(txtLastName.Text, PrintItemsFont, Brushes.Black, sngPrintX, sngPrintY)
            sngPrintY = sngPrintY + ItemLineHeight

            'Setting up code to see if there is more than one page
            If sngPrintY > 1000 Then
                If intStartingArrayCounter = mintTransactionUpperLimit Then
                    e.HasMorePages = False
                Else
                    e.HasMorePages = True
                    blnnewPage = True
                End If
            End If

            'Checking to see if there is more than one page
            If blnnewPage = True Then
                mintNewPrintCounter = intArrayCounter + 1
                intArrayCounter = mintTransactionUpperLimit
            End If

        Next

    End Sub
    Private Sub PrintDocument1_QueryPageSettings(ByVal sender As Object, ByVal e As System.Drawing.Printing.QueryPageSettingsEventArgs) Handles PrintDocument1.QueryPageSettings

        

    End Sub

End Class