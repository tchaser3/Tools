'Title:         View Technician Queue
'Date:          6/23/14
'Author:        Terry Holmes

'Description:   This form is used for view and reporting technician queues

Option Strict On

Public Class ViewTechnicianQueues

    Dim TheInputDataValidation As New InputDataValidation

    Private addingBoolean As Boolean = False
    Private editingBoolean As Boolean = False
    Private previousSelectedIndex As Integer
    Dim mintNumuberOfRecords As Integer

    Dim LogDateTime As Date = DateAndTime.Now
    Dim strLogDateTime As String

    'Setting Up Data Controls
    Private TheInternalProjectsDataSet As InternalProjectsDataSet
    Private TheInternalProjectsDataTier As InternalProjectsDataTier
    Private WithEvents TheInternalProjectsBindingSource As BindingSource

    'Setting up Employee Information
    Private TheEmployeeDataSet As EmployeeDataSet
    Private TheEmployeeDataTier As EmployeeDataTier
    Private WithEvents TheEmployeeBindingSource As BindingSource

    Private TheWarehouseDataSet As EmployeeDataSet
    Private TheWarehouseDataTier As EmployeeDataTier
    Private WithEvents TheWarehouseBindingSource As BindingSource

    'Setting Variables for the Cable Type Boxes
    Private ThePartNumberDataSet As PartNumberDataSet
    Private ThePartNumberDataTier As PartDataTier
    Private WithEvents ThePartNumberBindingSource As BindingSource

    'Setting Variables for Issuing Cable
    Private TheIssueCableDataSet As IssueCableDataSet
    Private TheIssueCableDataTier As CableDataTier
    Private WithEvents TheIssueCableBindingSource As BindingSource

    'setting employee array
    Dim mintEmployeeCounter As Integer
    Dim mintEmployeeSelectedIndex(5000) As Integer
    Dim mintEmployeeUpperLimit As Integer

    Dim mintTransactionCounter As Integer
    Dim mintTransactionSelectedIndex(1000) As Integer
    Dim mintTransactionUpperLimit As Integer

    Dim mintPartCounter As Integer
    Dim mintPartCountStart As Integer
    Dim mintPartSelectedIndex(2000) As Integer
    Dim mintPartUpperLimit As Integer

    Dim mintProjectCounter As Integer
    Dim mintProjectSelectedIndex(2000) As Integer
    Dim mintProjectUpperLimit As Integer

    Dim mintWarehouseCounter As Integer
    Dim mintWarehouseSelectedIndex(1000) As Integer
    Dim mintWarehouseUpperLimit As Integer

    Private Sub LimitPartsLocations()

        'Setting Local Variables
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim strPartLastName As String

        'Setting qualifiers for the loop
        intNumberOfRecords = cboWarehouseID.Items.Count - 1
        mintWarehouseCounter = 0

        'Preforming Loop
        For intCounter = 0 To intNumberOfRecords

            'Incrementing the combo box
            cboWarehouseID.SelectedIndex = intCounter
            strPartLastName = txtWarehouseLastName.Text

            'Running if statement and loading global array
            If strPartLastName = "PARTS" Then
                mintWarehouseSelectedIndex(mintWarehouseCounter) = intCounter
                mintWarehouseCounter += 1
            End If

        Next

        mintWarehouseUpperLimit = mintWarehouseCounter - 1

    End Sub

    Private Sub LimitProjects()

        Dim intProjectIDForSearch As Integer
        Dim intProjectIDFromTable As Integer
        Dim intTransactionCounter As Integer
        Dim intTransactionNumberOfRecords As Integer
        Dim intProjectCounter As Integer
        Dim intProjectNumberOfRecords As Integer
       

        'Setting Variables
        intTransactionNumberOfRecords = mintTransactionUpperLimit
        intProjectNumberOfRecords = cboInternalProjectID.Items.Count - 1
        mintProjectCounter = 0

        'Loop for finding all the projects 
        For intTransactionCounter = 0 To intTransactionNumberOfRecords

            'This will increment the transaction combo box
            cboTransactionID.SelectedIndex = mintTransactionSelectedIndex(intTransactionCounter)
            intProjectIDForSearch = CInt(txtInternalProjectID.Text)

            'Performing second loop
            For intProjectCounter = 0 To intProjectNumberOfRecords

                'Incrementing the project combo box
                cboInternalProjectID.SelectedIndex = intProjectCounter
                intProjectIDFromTable = CInt(cboInternalProjectID.Text)

                'Checking to see if the projects match
                If intProjectIDForSearch = intProjectIDFromTable Then
                    mintProjectSelectedIndex(mintProjectCounter) = intProjectCounter
                    mintProjectCounter += 1
                End If
            Next

        Next

        mintProjectUpperLimit = mintProjectCounter - 1

    End Sub

    Private Sub LimitPartNumbers()

        'Setting Local Variables
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim strCablePartType As String

        'Setting up for the loop
        intNumberOfRecords = cboPartID.Items.Count - 1
        mintPartCounter = 0

        'Loop for loading up the array
        For intCounter = 0 To intNumberOfRecords

            'Incrementing the combo box
            cboPartID.SelectedIndex = intCounter
            strCablePartType = txtCablePartType.Text

            'If statement to find part numbers that are cable
            If strCablePartType = "CABLE" Then

                'Loading the global array
                mintPartSelectedIndex(mintPartCounter) = intCounter
                mintPartCounter += 1

            End If

        Next

        'Setting the global limiting function
        mintPartUpperLimit = mintPartCounter - 1

    End Sub

    Private Sub btnAdministrativeMenu_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdministrativeMenu.Click

        AdministrativeMenu.Show()
        Me.Close()

    End Sub

    Private Sub btnCableAdminMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCableAdminMenu.Click

        CableAdministrationMenu.Show()
        Me.Close()

    End Sub

    Private Sub btnMainMenu_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMainMenu.Click

        MainMenu.Show()
        Me.Close()

    End Sub

    Private Sub btnClose_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        'Closes the Program
        CloseTheProgram.ShowDialog()

    End Sub

    Private Sub ViewTechnicianQueues_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Try - Catch for Managers, Warehouse and Technicians
        Try

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

            'Setting the Technician relationship for the Combo Box
            With cboTechnicianID
                .DataSource = TheEmployeeBindingSource
                .DisplayMember = "EmployeeID"
                .DataBindings.Add("text", TheEmployeeBindingSource, "EmployeeID", False, DataSourceUpdateMode.Never)
            End With

            'Setting the data binding for the text boxes
            txtTechnicianFirstName.DataBindings.Add("text", TheEmployeeBindingSource, "FirstName")
            txtTechnicianLastName.DataBindings.Add("text", TheEmployeeBindingSource, "LastName")

            MakeEmployeeControlsVisible(False)

        Catch ex As Exception

            'If an exception is thrown, it is rounted here
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Try

            'Setting The employee variables
            TheWarehouseDataTier = New EmployeeDataTier
            TheWarehouseDataSet = TheEmployeeDataTier.GetEmployeeInformation
            TheWarehouseBindingSource = New BindingSource

            With TheWarehouseBindingSource
                .DataSource = TheWarehouseDataSet
                .DataMember = "employees"
                .MoveFirst()
                .MoveLast()
            End With

            With cboWarehouseID
                .DataSource = TheWarehouseBindingSource
                .DisplayMember = "EmployeeID"
                .DataBindings.Add("text", TheWarehouseBindingSource, "EmployeeID", False, DataSourceUpdateMode.Never)
            End With

            txtWarehouseFirstName.DataBindings.Add("text", TheWarehouseBindingSource, "FirstName")
            txtWarehouseLastName.DataBindings.Add("text", TheWarehouseBindingSource, "LastName")

            LimitPartsLocations()

        Catch ex As Exception
            'If an exception is thrown, it is rounted here
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Try

            'This will bind the controls to the data source
            ThePartNumberDataTier = New PartDataTier
            ThePartNumberDataSet = ThePartNumberDataTier.GetPartNumberInformation
            ThePartNumberBindingSource = New BindingSource

            'Setting the binding source
            With ThePartNumberBindingSource
                .DataSource = ThePartNumberDataSet
                .DataMember = "partnumbers"
                .MoveFirst()
                .MoveLast()
            End With

            'Setting the combobox
            With cboPartID
                .DataSource = ThePartNumberBindingSource
                .DisplayMember = "PartID"
                .DataBindings.Add("text", ThePartNumberBindingSource, "PartID", False, DataSourceUpdateMode.Never)
            End With

            'binding the controls
            txtCableTypePartNumber.DataBindings.Add("text", ThePartNumberBindingSource, "PartNumber")
            txtCableDescription.DataBindings.Add("text", ThePartNumberBindingSource, "Description")
            txtCableJobType.DataBindings.Add("text", ThePartNumberBindingSource, "Type")
            txtCablePartType.DataBindings.Add("text", ThePartNumberBindingSource, "PartType")

            LimitPartNumbers()

        Catch ex As Exception

            'If an exception is thrown, it is rounted here
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        'Try Catch for Internal Projects
        Try

            TheInternalProjectsDataTier = New InternalProjectsDataTier
            TheInternalProjectsDataSet = TheInternalProjectsDataTier.GetInternalProjectsInformation
            TheInternalProjectsBindingSource = New BindingSource

            With TheInternalProjectsBindingSource
                .DataSource = TheInternalProjectsDataSet
                .DataMember = "internalprojects"
                .MoveFirst()
                .MoveLast()
            End With

            With cboInternalProjectID
                .DataSource = TheInternalProjectsBindingSource
                .DisplayMember = "InternalProjectID"
                .DataBindings.Add("text", TheInternalProjectsBindingSource, "InternalProjectID", False, DataSourceUpdateMode.Never)
            End With

            txtProjectInternalID.DataBindings.Add("text", TheInternalProjectsBindingSource, "InternalProjectID")
            txtProjectName.DataBindings.Add("text", TheInternalProjectsBindingSource, "ProjectName")
            txtTWCControlNumber.DataBindings.Add("text", TheInternalProjectsBindingSource, "TWCControlNumber")

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


        'Try - Catch for Cable Type
        Try

            'This will bind the controls to the data source
            TheIssueCableDataTier = New CableDataTier
            TheIssueCableDataSet = TheIssueCableDataTier.GetIssueCableInformation
            TheIssueCableBindingSource = New BindingSource

            'Setting up Binding Source for the Combo Box
            With TheIssueCableBindingSource
                .DataSource = TheIssueCableDataSet
                .DataMember = "issuecable"
                .MoveFirst()
                .MoveLast()
            End With

            'Setting the data relationship for the Combo Box
            With cboTransactionID
                .DataSource = TheIssueCableBindingSource
                .DisplayMember = "TransactionID"
                .DataBindings.Add("text", TheIssueCableBindingSource, "TransactionID", False, DataSourceUpdateMode.Never)
            End With

            'Setting Control bindings
            txtInternalProjectID.DataBindings.Add("text", TheIssueCableBindingSource, "InternalProjectID")
            txtTechnicianID.DataBindings.Add("text", TheIssueCableBindingSource, "TechnicianID")
            txtFootagePulled.DataBindings.Add("text", TheIssueCableBindingSource, "FootagePulled")
            txtManagerID.DataBindings.Add("text", TheIssueCableBindingSource, "ManagersID")
            txtReelID.DataBindings.Add("Text", TheIssueCableBindingSource, "ReelID")
            txtPartNumber.DataBindings.Add("text", TheIssueCableBindingSource, "PartNumber")
            txtDate.DataBindings.Add("text", TheIssueCableBindingSource, "Date")
            txtWarehouse.DataBindings.Add("text", TheIssueCableBindingSource, "WarehouseID")

            MakeTransactionControlsVisble(False)

        Catch ex As Exception

            'If an exception is thrown, it is rounted here
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnTechnicianNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTechnicianNext.Click

        'This will increment the counter
        mintEmployeeCounter = mintEmployeeCounter + 1
        cboTechnicianID.SelectedIndex = mintEmployeeSelectedIndex(mintEmployeeCounter)

        btnTechncianBack.Enabled = True

        If mintEmployeeCounter = mintEmployeeUpperLimit Then
            btnTechnicianNext.Enabled = False
        End If

    End Sub

    Private Sub btnTechncianBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTechncianBack.Click

        'This will increment the counter
        mintEmployeeCounter = mintEmployeeCounter - 1
        cboTechnicianID.SelectedIndex = mintEmployeeSelectedIndex(mintEmployeeCounter)

        btnTechnicianNext.Enabled = True

        If mintEmployeeCounter = 0 Then
            btnTechncianBack.Enabled = False
        End If

    End Sub

    Private Sub btnSearchForLastName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchForLastName.Click

        'This Sub routine will search for an employee's Last Name

        'Setting Local Variables
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim strLastNameForSearch As String
        Dim strLastNameFromTable As String
        Dim blnLastNameNotFound As Boolean = True

        'Making Controls Visible
        MakeEmployeeControlsVisible(True)

        btnTechncianBack.Enabled = False
        btnTechnicianNext.Enabled = False

        'Setting Up For Loop
        intNumberOfRecords = cboTechnicianID.Items.Count - 1
        strLastNameForSearch = txtEnteredLastName.Text
        mintEmployeeCounter = 0

        'Beginning Loop
        For intCounter = 0 To intNumberOfRecords

            cboTechnicianID.SelectedIndex = intCounter
            strLastNameFromTable = txtTechnicianLastName.Text

            If strLastNameForSearch = strLastNameFromTable Then

                mintEmployeeSelectedIndex(mintEmployeeCounter) = intCounter
                mintEmployeeCounter = mintEmployeeCounter + 1
                blnLastNameNotFound = False

            End If

        Next

        If blnLastNameNotFound = True Then
            txtEnteredLastName.Text = ""
            MakeEmployeeControlsVisible(False)
            MessageBox.Show("Last Entered Not Found", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        mintEmployeeUpperLimit = mintEmployeeCounter - 1
        mintEmployeeCounter = 0

        If mintEmployeeUpperLimit > 0 Then
            btnTechnicianNext.Enabled = True
        End If

        cboTechnicianID.SelectedIndex = mintEmployeeSelectedIndex(0)
        btnTechnicianSelect.Enabled = True
        txtEnteredLastName.Text = ""

    End Sub

    Private Sub txtEnteredLastName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEnteredLastName.KeyDown

        If e.KeyCode = Keys.Enter Then
            btnSearchForLastName.PerformClick()
        End If

    End Sub

    Private Sub MakeEmployeeControlsVisible(ByVal valueBoolean As Boolean)

        'Makes Control Visible
        txtTechnicianFirstName.Visible = valueBoolean
        txtTechnicianLastName.Visible = valueBoolean
        btnTechncianBack.Visible = valueBoolean
        btnTechnicianNext.Visible = valueBoolean
        btnTechnicianSelect.Visible = valueBoolean

    End Sub
    Private Sub MakeTransactionControlsVisble(ByVal valueboolean As Boolean)

        txtDate.Visible = valueboolean
        txtFootagePulled.Visible = valueboolean
        txtInternalProjectID.Visible = valueboolean
        txtManagerID.Visible = valueboolean
        txtPartNumber.Visible = valueboolean
        txtReelID.Visible = valueboolean
        txtTechnicianID.Visible = valueboolean
        txtWarehouse.Visible = valueboolean
        btnTransactionBack.Visible = valueboolean
        btnTransactionNext.Visible = valueboolean
        txtCableDescription.Visible = valueboolean
        txtCableTypePartNumber.Visible = valueboolean
        txtWarehouseFirstName.Visible = valueboolean
        txtWarehouseLastName.Visible = valueboolean
        txtProjectName.Visible = valueboolean
        txtTWCControlNumber.Visible = valueboolean
        txtCableJobType.Visible = valueboolean
        txtCablePartType.Visible = valueboolean

    End Sub

    Private Sub btnResetSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetSearch.Click

        'This will set the form to original settings

        'Setting local variables
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer

        'Setting up loop
        intNumberOfRecords = cboTechnicianID.Items.Count - 1
        mintEmployeeCounter = 0

        'Setting array to 0
        For intCounter = 0 To intNumberOfRecords
            mintEmployeeSelectedIndex(intCounter) = 0
        Next

        'Setting button conditions
        btnTechncianBack.Enabled = False
        btnTechnicianNext.Enabled = False
        btnTechnicianSelect.Enabled = False

        'Making Controls visible
        MakeEmployeeControlsVisible(False)
        MakeTransactionControlsVisble(False)
        txtEnteredLastName.Text = ""

    End Sub

    Private Sub btnTechnicianSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTechnicianSelect.Click

        'Setting local variables
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim intTechnicianIDForSearch As Integer
        Dim intTechnicianIDFromTable As Integer
        Dim intFootagePulled As Integer
        Dim blnNoTransactionsForTechnician As Boolean = True

        MakeTransactionControlsVisble(True)

        btnTransactionBack.Enabled = False
        btnTransactionNext.Enabled = False

        'Setting up for loop
        intNumberOfRecords = cboTransactionID.Items.Count - 1
        mintTransactionCounter = 0
        intTechnicianIDForSearch = CInt(cboTechnicianID.Text)

        For intCounter = 0 To intNumberOfRecords

            cboTransactionID.SelectedIndex = intCounter
            intTechnicianIDFromTable = CInt(txtTechnicianID.Text)
            intFootagePulled = CInt(txtFootagePulled.Text)

            If intTechnicianIDForSearch = intTechnicianIDFromTable Then
                If intFootagePulled > 0 Then

                    mintTransactionSelectedIndex(mintTransactionCounter) = intCounter
                    mintTransactionCounter = mintTransactionCounter + 1
                    blnNoTransactionsForTechnician = False



                End If
            End If

        Next

        If blnNoTransactionsForTechnician = True Then
            MakeTransactionControlsVisble(False)
            MessageBox.Show("The Selected Technician Has No Open Transaction", "Select Another Technician", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        'Running limiting sub-routine
        mintTransactionUpperLimit = mintTransactionCounter - 1
        mintTransactionCounter = 0

        If mintTransactionUpperLimit > 0 Then
            btnTransactionNext.Enabled = True
        End If

        LimitProjects()
        cboTransactionID.SelectedIndex = mintTransactionSelectedIndex(0)
        FindCablePartNumber()
        FindInternalProjects()
        FindWarehouseInformation()

    End Sub

    Private Sub btnTransactionNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTransactionNext.Click

        'This will increment the counter
        mintTransactionCounter = mintTransactionCounter + 1
        cboTransactionID.SelectedIndex = mintTransactionSelectedIndex(mintTransactionCounter)

        btnTransactionBack.Enabled = True

        If mintTransactionCounter = mintTransactionUpperLimit Then
            btnTransactionNext.Enabled = False
        End If

        FindCablePartNumber()
        FindInternalProjects()
        FindWarehouseInformation()

    End Sub

    Private Sub btnTransactionBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTransactionBack.Click

        'This will decrement the counter
        mintTransactionCounter = mintTransactionCounter - 1
        cboTransactionID.SelectedIndex = mintTransactionSelectedIndex(mintTransactionCounter)

        btnTransactionNext.Enabled = True

        If mintTransactionCounter = 0 Then
            btnTransactionBack.Enabled = False
        End If

        FindCablePartNumber()
        FindInternalProjects()
        FindWarehouseInformation()

    End Sub
    Private Sub FindWarehouseInformation()

        'Setting local variables
        Dim intNumberOfRecords As Integer
        Dim intCounter As Integer
        Dim intSelectedIndex As Integer
        Dim intWarehouseIDForSearch As Integer
        Dim intWarehouseIDFromTable As Integer

        'Setting up the search
        intNumberOfRecords = mintWarehouseUpperLimit
        intWarehouseIDForSearch = CInt(txtWarehouse.Text)

        'Performing Loop
        For intCounter = 0 To intNumberOfRecords

            'Getting information for the compare
            cboWarehouseID.SelectedIndex = mintWarehouseSelectedIndex(intCounter)
            intWarehouseIDFromTable = CInt(cboWarehouseID.Text)

            'Doing Compare
            If intWarehouseIDForSearch = intWarehouseIDFromTable Then

                'Setting Conditions
                intSelectedIndex = intCounter

            End If

        Next

        'Setting combo box
        cboWarehouseID.SelectedIndex = mintWarehouseSelectedIndex(intSelectedIndex)

    End Sub
    Private Sub FindCablePartNumber()

        'Setting Local Variables
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim intSelectIndex As Integer
        Dim strPartNumberForSearch As String
        Dim strPartNumberFromTable As String

        'Setting up for Loop
        intNumberOfRecords = mintPartUpperLimit
        strPartNumberForSearch = txtPartNumber.Text

        'Performing the Loop
        For intCounter = 0 To intNumberOfRecords

            'Setting up variables for the compare
            cboPartID.SelectedIndex = mintPartSelectedIndex(intCounter)
            strPartNumberFromTable = txtCableTypePartNumber.Text

            'Performing the compare
            If strPartNumberForSearch = strPartNumberFromTable Then
                intSelectIndex = intCounter
            End If
        Next

        'Setting up the Combo box
        cboPartID.SelectedIndex = mintPartSelectedIndex(intSelectIndex)

    End Sub
    Private Sub FindInternalProjects()

        'Setting up local variables
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim intSelectedIndex As Integer
        Dim intInternalProjectIDForSearch As Integer
        Dim intInternalProjectIDFromTable As Integer

        'Setting up variables for Loop
        intNumberOfRecords = mintProjectUpperLimit
        intInternalProjectIDForSearch = CInt(txtInternalProjectID.Text)

        'Performing the loop
        For intCounter = 0 To intNumberOfRecords

            'Setting Variables for the if statements
            cboInternalProjectID.SelectedIndex = mintProjectSelectedIndex(intCounter)
            intInternalProjectIDFromTable = CInt(cboInternalProjectID.Text)

            'Performing If Statements
            If intInternalProjectIDForSearch = intInternalProjectIDFromTable Then
                intSelectedIndex = intCounter
            End If
        Next

        'setting combo box
        cboInternalProjectID.SelectedIndex = mintProjectSelectedIndex(intSelectedIndex)

    End Sub

    Private Sub btnTechnicianQueueReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTechnicianQueueReport.Click

        'Setting up to print the document
        Logon.mstrCableSelectionType = "TECHNICIANQUEUE"
        mintPartCountStart = 0
        SelectWarehouse.Show()

    End Sub
    Public Sub PrintDocument()

        'Setting up to show the printer dialog box
        PrintDialog1.PrinterSettings = PrintDocument1.PrinterSettings

        If PrintDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            PrintDocument1.PrinterSettings = PrintDialog1.PrinterSettings
        End If

        PrintDocument1.Print()

    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage

        'Setting Local Variables
        Dim intPartNumberOfRecords As Integer
        Dim intPartCounter As Integer
        Dim intWarehouseIDForSearch As Integer
        Dim intWarehouseIDFromTable As Integer
        Dim strPartNumberForSearch As String
        Dim strPartNumberFromTable As String
        Dim intFootagePulled As Integer
        Dim blnInformationForPartNumber As Boolean
        Dim intTotalFootage As Integer
        Dim strProjectNameEntered As String
        Dim charProjectNameCharacterArray() As Char
        Dim strProjectNamePrinted As String = ""
        Dim intCharacterCount As Integer
        Dim intCharacterCounter As Integer
        Dim intPartNumberCountStart As Integer
        Dim blnNewPage As Boolean = False
        Dim intTransactionNumberOfRecords As Integer
        Dim intTransactionCounter As Integer
        Dim intTechnicianIDForSearch As Integer
        Dim intTechnicianIDFromTable As Integer

        Dim fntPrtHeader As New Font("Arial", 18, FontStyle.Bold)
        Dim fntPrtSubHeader As New Font("Arial", 14, FontStyle.Bold)
        Dim fntPrtItems As New Font("Arial", 10, FontStyle.Regular)
        Dim fntPrtNotes As New Font("Arial", 8, FontStyle.Regular)
        Dim sngPrintX As Single = e.MarginBounds.Left
        Dim sngPrintY As Single = e.MarginBounds.Top
        Dim sngHeadingLineHeight As Single = fntPrtHeader.GetHeight + 10
        Dim sngItemLineHeight As Single = fntPrtItems.GetHeight + 5

        intPartNumberCountStart = mintPartCountStart

        'Setting up the header for the report
        sngPrintY = 100

        sngPrintX = 200
        e.Graphics.DrawString("Blue Jay Communications Technician Queue Cable Report", fntPrtHeader, Brushes.Black, sngPrintX, sngPrintY)
        sngPrintY = sngPrintY + sngHeadingLineHeight

        sngPrintX = 250
        e.Graphics.DrawString("Report For " + txtTechnicianFirstName.Text + " " + txtTechnicianLastName.Text + " For Warehouse " + Logon.mstrWarehouse, fntPrtSubHeader, Brushes.Black, sngPrintX, sngPrintY)
        sngPrintY = sngPrintY + sngHeadingLineHeight
        sngPrintY = sngPrintY + sngHeadingLineHeight

        'Setting Search Criteria Up
        intWarehouseIDForSearch = Logon.mintWarehouseID
        intPartNumberOfRecords = mintPartUpperLimit
        intTransactionNumberOfRecords = mintTransactionUpperLimit
        intTechnicianIDForSearch = CInt(cboTechnicianID.Text)

        'Setting column headers
        sngPrintX = 100
        e.Graphics.DrawString("Part Number", fntPrtItems, Brushes.Black, sngPrintX, sngPrintY)
        sngPrintX = 275
        e.Graphics.DrawString("Description", fntPrtItems, Brushes.Black, sngPrintX, sngPrintY)
        sngPrintX = 500
        e.Graphics.DrawString("Reel ID", fntPrtItems, Brushes.Black, sngPrintX, sngPrintY)
        sngPrintX = 650
        e.Graphics.DrawString("Footage", fntPrtItems, Brushes.Black, sngPrintX, sngPrintY)
        sngPrintX = 775
        e.Graphics.DrawString("Project Name", fntPrtItems, Brushes.Black, sngPrintX, sngPrintY)
        sngPrintY = sngPrintY + sngItemLineHeight

        'Beginning first loop
        For intPartCounter = intPartNumberCountStart To intPartNumberOfRecords

            'Setting variables for the second loop
            cboPartID.SelectedIndex = mintPartSelectedIndex(intPartCounter)
            strPartNumberForSearch = txtCableTypePartNumber.Text
            blnInformationForPartNumber = False
            intTotalFootage = 0

            'Second Loop to find the transactions
            For intTransactionCounter = 0 To intTransactionNumberOfRecords

                'Setting variables for if statements
                cboTransactionID.SelectedIndex = mintTransactionSelectedIndex(intTransactionCounter)
                intWarehouseIDForSearch = CInt(txtWarehouse.Text)
                strPartNumberFromTable = txtPartNumber.Text
                intFootagePulled = CInt(txtFootagePulled.Text)
                intTechnicianIDFromTable = CInt(txtTechnicianID.Text)
                intWarehouseIDFromTable = CInt(txtWarehouse.Text)

                'Running nested if statements
                If strPartNumberForSearch = strPartNumberFromTable Then
                    If intFootagePulled > 0 Then
                        If intTechnicianIDForSearch = intTechnicianIDFromTable Then
                            If intWarehouseIDForSearch = intWarehouseIDFromTable Then

                                'Setting up report
                                FindInternalProjects()
                                strProjectNamePrinted = ""

                                'Limiting the size of the project name
                                strProjectNameEntered = txtProjectName.Text
                                intCharacterCount = strProjectNameEntered.Length - 1

                                'If statement to limit the project name
                                If intCharacterCount < 30 Then
                                    strProjectNamePrinted = strProjectNameEntered
                                Else
                                    charProjectNameCharacterArray = strProjectNameEntered.ToCharArray

                                    For intCharacterCounter = 0 To 30
                                        strProjectNamePrinted = strProjectNamePrinted + charProjectNameCharacterArray(intCharacterCounter)
                                    Next

                                End If

                                'Getting cable total
                                blnInformationForPartNumber = True
                                intTotalFootage = intTotalFootage + intFootagePulled

                                'Printing output to the user
                                sngPrintX = 100
                                e.Graphics.DrawString(strPartNumberForSearch, fntPrtItems, Brushes.Black, sngPrintX, sngPrintY)
                                sngPrintX = 275
                                e.Graphics.DrawString(txtCableDescription.Text, fntPrtItems, Brushes.Black, sngPrintX, sngPrintY)
                                sngPrintX = 500
                                e.Graphics.DrawString(txtReelID.Text, fntPrtItems, Brushes.Black, sngPrintX, sngPrintY)
                                sngPrintX = 650
                                e.Graphics.DrawString(CStr(intFootagePulled), fntPrtItems, Brushes.Black, sngPrintX, sngPrintY)
                                sngPrintX = 775
                                e.Graphics.DrawString(strProjectNamePrinted, fntPrtItems, Brushes.Black, sngPrintX, sngPrintY)
                                sngPrintY = sngPrintY + sngItemLineHeight

                                'Setting up for multiple pages
                                If sngPrintY > 650 Then
                                    If intPartCounter = mintPartUpperLimit Then
                                        e.HasMorePages = False
                                    Else
                                        e.HasMorePages = True
                                        blnNewPage = True
                                    End If
                                ElseIf intPartCounter = intPartNumberOfRecords Then
                                    e.HasMorePages = False
                                End If

                            End If
                        End If
                    End If
                End If
            Next

            'Setting totals for each part number
            If blnInformationForPartNumber = True Then
                sngPrintX = 100
                e.Graphics.DrawString("Total Footage for Part Number " + strPartNumberForSearch + " In Queue:    " + CStr(intTotalFootage), fntPrtSubHeader, Brushes.Black, sngPrintX, sngPrintY)
                sngPrintY = sngPrintY + sngHeadingLineHeight
            End If

            If blnNewPage = True Then
                mintPartCountStart = intPartCounter + 1
                intPartCounter = intPartNumberOfRecords
            End If

        Next

    End Sub
    Private Sub ClearDataBindings()

        'This sub routine clears all data bindings to prevent possible problems later


    End Sub
    Private Sub PrintDocument1_QueryPageSettings(ByVal sender As Object, ByVal e As System.Drawing.Printing.QueryPageSettingsEventArgs) Handles PrintDocument1.QueryPageSettings

        e.PageSettings.Landscape = True

    End Sub
End Class