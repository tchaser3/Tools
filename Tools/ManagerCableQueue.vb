'Title:         View Manager Cable Queue
'Date:          June 11, 2014
'Author:        Terry Holmes

'Description:   This form is used to view the Cable within a Manager Queue.

Option Strict On

Public Class ManagerCableQueue

    'Setting Modular Variables

    'Setting the internal projects data set
    Private TheInternalProjectsDataSet As InternalProjectsDataSet
    Private TheInternalProjectsDataTier As InternalProjectsDataTier
    Private WithEvents TheInternalProjectsBindingSource As BindingSource

    'Setting the employee data set
    Private TheEmployeeDataSet As EmployeeDataSet
    Private TheEmployeeDataTier As EmployeeDataTier
    Private WithEvents TheEmployeeBindingSource As BindingSource

    'Setting the warehouse data set
    Private TheWarehouseDataSet As EmployeeDataSet
    Private TheWarehouseDataTier As EmployeeDataTier
    Private WithEvents TheWarehouseBindingSource As BindingSource

    'Setting the warehouse employee data set
    Private TheWarehouseEmployeeDataSet As EmployeeDataSet
    Private TheWarehouseEmployeeDataTier As EmployeeDataTier
    Private WithEvents TheWarehouseEmployeeBindingSource As BindingSource

    'Setting the manager data set
    Private TheManagerDataSet As EmployeeDataSet
    Private TheManagerDataTier As EmployeeDataTier
    Private WithEvents TheManagerBindingSource As BindingSource

    'setting the manager queue data set
    Private TheManagerQueueDataSet As ManagerQueueDataSet
    Private TheManagerQueueDataTier As CableDataTier
    Private WithEvents TheManagerQueueBindingSource As BindingSource

    'Setting Variables for the Cable Type Boxes
    Private ThePartNumberDataSet As PartNumberDataSet
    Private ThePartNumberDataTier As PartDataTier
    Private WithEvents ThePartNumberBindingSource As BindingSource

    'Global Variable for find managers
    Dim mintManagerSelectedIndex(3000) As Integer
    Dim mintManagerCounter As Integer
    Dim mintManagerUpperLimit As Integer

    'Setting variable for the Data Validation Class
    Dim TheInputDataValidation As New InputDataValidation

    'Setting global variables
    Private addingBoolean As Boolean = False
    Private editingBoolean As Boolean = False
    Private previousSelectedIndex As Integer
    Dim mintNumuberOfRecords As Integer
    Dim LogDateTime As Date = DateAndTime.Now
    Dim strLogDateTime As String

    'Setting up global arrays
    Dim mintQueueSelectedIndex(3000) As Integer
    Dim mintQueueCounter As Integer
    Dim mintQueueUpperLimit As Integer

    Dim mintProjectSelectedIndex(3000) As Integer
    Dim mintProjectCounter As Integer
    Dim mintProjectUpperLimit As Integer

    Dim mintTechnicianSelectedIndex(3000) As Integer
    Dim mintTechnicianCounter As Integer
    Dim mintTechnicianUpperLimit As Integer

    Dim mintPartNumberCounter As Integer
    Dim mintPartNumberSelectedIndex(2000) As Integer
    Dim mintPartNumberUpperLimit As Integer

    Dim mintPartNumberCountStart As Integer = 0

    Private Sub LimitSearches()

        Dim intTechIDForSearch As Integer
        Dim intTechIDFromTable As Integer
        Dim intProjectIDForSearch As Integer
        Dim intProjectIDFromTable As Integer
        Dim intQueueCounter As Integer
        Dim intQueueNumberOfRecords As Integer
        Dim intTechCounter As Integer
        Dim intTechNumberOfRecords As Integer
        Dim intProjectCounter As Integer
        Dim intProjectNumberOfRecords As Integer

        'Setting Up for loop
        intQueueNumberOfRecords = mintQueueUpperLimit
        intTechNumberOfRecords = cboEmployeeID.Items.Count - 1
        intProjectNumberOfRecords = cboInternalProjectID.Items.Count - 1
        mintProjectCounter = 0
        mintTechnicianCounter = 0

        'Loop for the Queue
        For intQueueCounter = 0 To intQueueNumberOfRecords

            'Setting conditions for the project loop
            cboInternalTransactionID.SelectedIndex = mintQueueSelectedIndex(intQueueCounter)
            intTechIDForSearch = CInt(txtInternalTechnicianID.Text)
            intProjectIDForSearch = CInt(txtInternalProjectID.Text)

            'Loop for Project ID
            For intProjectCounter = 0 To intProjectNumberOfRecords

                'Setting combo box counter
                cboInternalProjectID.SelectedIndex = intProjectCounter
                intProjectIDFromTable = CInt(cboInternalProjectID.Text)

                'Verifying if statement and loading up global array
                If intProjectIDForSearch = intProjectIDFromTable Then
                    mintProjectSelectedIndex(mintProjectCounter) = intProjectCounter
                    mintProjectCounter += 1
                End If

            Next

            'Loop for techs
            For intTechCounter = 0 To intTechNumberOfRecords

                'incrementing the combo box counter
                cboEmployeeID.SelectedIndex = intTechCounter
                intTechIDFromTable = CInt(cboEmployeeID.Text)

                If intTechIDForSearch = intTechIDFromTable Then
                    mintTechnicianSelectedIndex(mintTechnicianCounter) = intTechCounter
                    mintTechnicianCounter += 1
                End If

            Next

        Next

        'Setting up the upper limits
        mintProjectUpperLimit = mintProjectCounter - 1
        mintTechnicianUpperLimit = mintTechnicianCounter - 1

    End Sub

    Private Sub btnCableAdminMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCableAdminMenu.Click

        'Calls the Cable Admin Menu
        ClearDataBindings()
        CableAdministrationMenu.Show()
        Me.Close()

    End Sub

    Private Sub btnClose_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        'Closes the Program
        CloseTheProgram.ShowDialog()

    End Sub

    Private Sub btnAdministrativeMenu_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdministrativeMenu.Click

        'Shows the Administrative Menu
        ClearDataBindings()
        AdministrativeMenu.Show()
        Me.Close()

    End Sub

    Private Sub btnMainMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMainMenu.Click

        'Shows the main menue
        ClearDataBindings()
        MainMenu.Show()
        Me.Close()

    End Sub

    Private Sub ManagerCableQueue_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Setting Local Variables
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim strCablePartType As String
        Dim strGroupFromTable As String

        'Manager Loading Manager Try Catch
        Try

            'This will bind the controls to the data source
            TheManagerDataTier = New EmployeeDataTier
            TheManagerDataSet = TheManagerDataTier.GetEmployeeInformation
            TheManagerBindingSource = New BindingSource

            'Setting up Binding Source for the Combo Box
            With TheManagerBindingSource
                .DataSource = TheManagerDataSet
                .DataMember = "employees"
                .MoveFirst()
                .MoveLast()
            End With

            'Setting the data relationship for the Combo Box
            With cboManagerID
                .DataSource = TheManagerBindingSource
                .DisplayMember = "EmployeeID"
                .DataBindings.Add("text", TheManagerBindingSource, "EmployeeID", False, DataSourceUpdateMode.Never)
            End With

            txtManagerFirstName.DataBindings.Add("text", TheManagerBindingSource, "FirstName")
            txtManagerLastName.DataBindings.Add("text", TheManagerBindingSource, "LastName")
            txtManagerGroup.DataBindings.Add("text", TheManagerBindingSource, "Group")

            'Beginning Loop to find Managers
            intNumberOfRecords = cboManagerID.Items.Count - 1
            mintManagerCounter = 0

            For intCounter = 0 To intNumberOfRecords

                cboManagerID.SelectedIndex = intCounter
                strGroupFromTable = txtManagerGroup.Text

                If strGroupFromTable = "ADMIN" Or strGroupFromTable = "MANAGERS" Then

                    mintManagerSelectedIndex(mintManagerCounter) = intCounter
                    mintManagerCounter = mintManagerCounter + 1

                End If

            Next

            mintManagerUpperLimit = mintManagerCounter - 1
            mintManagerCounter = 0
            cboManagerID.SelectedIndex = mintManagerSelectedIndex(0)

            btnManagerSelect.Enabled = True


            If mintManagerUpperLimit > 0 Then
                btnManagerNext.Enabled = True
            End If
            
        Catch ex As Exception
            'If an exception is thrown, it is rounted here
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        'Try Catch for Technicians
        Try

            'Setting The employee variables
            TheEmployeeDataTier = New EmployeeDataTier
            TheEmployeeDataSet = TheEmployeeDataTier.GetEmployeeInformation
            TheEmployeeBindingSource = New BindingSource

            With TheEmployeeBindingSource
                .DataSource = TheEmployeeDataSet
                .DataMember = "employees"
                .MoveFirst()
                .MoveLast()
            End With

            With cboEmployeeID
                .DataSource = TheEmployeeBindingSource
                .DisplayMember = "EmployeeID"
                .DataBindings.Add("text", TheEmployeeBindingSource, "EmployeeID", False, DataSourceUpdateMode.Never)
            End With

            txtEmployeeFirstName.DataBindings.Add("text", TheEmployeeBindingSource, "FirstName")
            txtEmployeeLastName.DataBindings.Add("text", TheEmployeeBindingSource, "LastName")

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

        Catch ex As Exception
            'If an exception is thrown, it is rounted here
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Try

            'Setting The employee variables
            TheWarehouseEmployeeDataTier = New EmployeeDataTier
            TheWarehouseEmployeeDataSet = TheEmployeeDataTier.GetEmployeeInformation
            TheWarehouseEmployeeBindingSource = New BindingSource

            With TheWarehouseEmployeeBindingSource
                .DataSource = TheWarehouseEmployeeDataSet
                .DataMember = "employees"
                .MoveFirst()
                .MoveLast()
            End With

            With cboWarehouseEmployeeID
                .DataSource = TheWarehouseEmployeeBindingSource
                .DisplayMember = "EmployeeID"
                .DataBindings.Add("text", TheWarehouseEmployeeBindingSource, "EmployeeID", False, DataSourceUpdateMode.Never)
            End With

            txtWarehouseEmployeeFirstName.DataBindings.Add("text", TheWarehouseEmployeeBindingSource, "FirstName")
            txtWarehouseEmployeeLastName.DataBindings.Add("text", TheWarehouseEmployeeBindingSource, "LastName")

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

        Try

            'This will bind the controls to the data source
            TheManagerQueueDataTier = New CableDataTier
            TheManagerQueueDataSet = TheManagerQueueDataTier.GetManagerQueueInformation
            TheManagerQueueBindingSource = New BindingSource

            'Setting up Binding Source for the Combo Box
            With TheManagerQueueBindingSource
                .DataSource = TheManagerQueueDataSet
                .DataMember = "managerqueue"
                .MoveFirst()
                .MoveLast()
            End With

            'Setting the data relationship for the Combo Box
            With cboInternalTransactionID
                .DataSource = TheManagerQueueBindingSource
                .DisplayMember = "TransactionID"
                .DataBindings.Add("text", TheManagerQueueBindingSource, "TransactionID", False, DataSourceUpdateMode.Never)
            End With

            'Setting Control bindings
            txtInternalProjectID.DataBindings.Add("text", TheManagerQueueBindingSource, "InternalProjectID")
            txtInternalTechnicianID.DataBindings.Add("text", TheManagerQueueBindingSource, "TechnicianID")
            txtInternalFootagePulled.DataBindings.Add("text", TheManagerQueueBindingSource, "Footage")
            txtInternalManagerID.DataBindings.Add("text", TheManagerQueueBindingSource, "ManagersID")
            txtInternalReelID.DataBindings.Add("Text", TheManagerQueueBindingSource, "ReelID")
            txtInternalWarehouse.DataBindings.Add("text", TheManagerQueueBindingSource, "WarehouseID")
            txtInternalWarehouseEmployeeID.DataBindings.Add("Text", TheManagerQueueBindingSource, "WarehouseEmployeeID")
            txtInternalPartNumber.DataBindings.Add("text", TheManagerQueueBindingSource, "PartNumber")
            txtInternalDate.DataBindings.Add("text", TheManagerQueueBindingSource, "Date")
            txtInternalNotes.DataBindings.Add("text", TheManagerQueueBindingSource, "Note")

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
            txtCablePartNumber.DataBindings.Add("text", ThePartNumberBindingSource, "PartNumber")
            txtCableDescription.DataBindings.Add("text", ThePartNumberBindingSource, "Description")
            txtCablePartType.DataBindings.Add("text", ThePartNumberBindingSource, "PartType")

            'Filling up the Cable Part Number
            intNumberOfRecords = cboPartID.Items.Count - 1
            mintPartNumberCounter = 0

            'Performing Loop
            For intCounter = 0 To intNumberOfRecords

                'Setting up the controls for the loop
                cboPartID.SelectedIndex = intCounter
                strCablePartType = txtCablePartType.Text

                If strCablePartType = "CABLE" Then
                    mintPartNumberSelectedIndex(mintPartNumberCounter) = intCounter
                    mintPartNumberCounter += 1
                End If

            Next

            mintPartNumberUpperLimit = mintPartNumberCounter - 1
            mintPartNumberCounter = 0

            If Logon.mstrGroup = "ADMIN" Or Logon.mstrGroup = "WAREHOUSE" Then
                btnCableAdminMenu.Enabled = True
                btnAdministrativeMenu.Enabled = True
            End If

            'Routine will run if Exception is thrown
        Catch ex As Exception

            'If an exception is thrown, it is rounted here
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        SetControlsVisable(False)

    End Sub

    Private Sub btnManagerNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnManagerNext.Click


        'This routine will increment the manager next button
        mintManagerCounter = mintManagerCounter + 1
        cboManagerID.SelectedIndex = mintManagerSelectedIndex(mintManagerCounter)

        btnManagerBack.Enabled = True

        If mintManagerCounter = mintManagerUpperLimit Then
            btnManagerNext.Enabled = False
        End If

    End Sub

    Private Sub btnManagerBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnManagerBack.Click

        'This routine will decrement the manager back button
        mintManagerCounter = mintManagerCounter - 1
        cboManagerID.SelectedIndex = mintManagerSelectedIndex(mintManagerCounter)

        btnManagerNext.Enabled = True

        If mintManagerCounter = 0 Then
            btnManagerBack.Enabled = False
        End If

    End Sub
    Private Sub SetControlsVisable(ByVal valueBoolean As Boolean)

        'Technician Controls
        txtEmployeeFirstName.Visible = valueBoolean
        txtEmployeeLastName.Visible = valueBoolean

        'Manager Queue Controls
        txtInternalDate.Visible = valueBoolean
        txtInternalFootagePulled.Visible = valueBoolean
        txtInternalManagerID.Visible = valueBoolean
        txtInternalNotes.Visible = valueBoolean
        txtInternalPartNumber.Visible = valueBoolean
        txtInternalProjectID.Visible = valueBoolean
        txtInternalReelID.Visible = valueBoolean
        txtInternalTechnicianID.Visible = valueBoolean
        txtInternalWarehouse.Visible = valueBoolean
        txtInternalWarehouseEmployeeID.Visible = valueBoolean

        'Project Controls
        txtProjectInternalID.Visible = valueBoolean
        txtProjectName.Visible = valueBoolean
        txtTWCControlNumber.Visible = valueBoolean

        'Warehouse Controls
        txtWarehouseEmployeeFirstName.Visible = valueBoolean
        txtWarehouseEmployeeLastName.Visible = valueBoolean
        txtWarehouseFirstName.Visible = valueBoolean
        txtWarehouseLastName.Visible = valueBoolean

        'Cable Type Controls
        txtCablePartNumber.Visible = valueBoolean
        txtCableDescription.Visible = valueBoolean
        txtCablePartType.Visible = valueBoolean

    End Sub

    Private Sub btnManagerSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnManagerSelect.Click

        'Setting up the local variables
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim intManagerIDForSearch As Integer
        Dim intManagerIDFromTable As Integer
        Dim intFootagePulledFromTable As Integer
        Dim blnNoRecordsFound As Boolean = True

        SetControlsVisable(True)
        btnNext.Enabled = False
        btnBack.Enabled = False
        btnManagerQueueCableReport.Enabled = True

        'Setting Up Loop
        intNumberOfRecords = cboInternalTransactionID.Items.Count - 1
        intManagerIDForSearch = CInt(cboManagerID.Text)
        mintQueueCounter = 0

        'Loop for find open cable transactions
        For intCounter = 0 To intNumberOfRecords

            cboInternalTransactionID.SelectedIndex = intCounter
            intManagerIDFromTable = CInt(txtInternalManagerID.Text)
            intFootagePulledFromTable = CInt(txtInternalFootagePulled.Text)

            If intManagerIDForSearch = intManagerIDFromTable Then
                If intFootagePulledFromTable > 0 Then

                    mintQueueSelectedIndex(mintQueueCounter) = intCounter
                    mintQueueCounter = mintQueueCounter + 1
                    blnNoRecordsFound = False

                End If
            End If

        Next

        If blnNoRecordsFound = True Then
            SetControlsVisable(False)
            btnManagerQueueCableReport.Enabled = False
            MessageBox.Show("There Are No Open Records for This Manager", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        'Setting Conditions
        mintQueueUpperLimit = mintQueueCounter - 1
        mintQueueCounter = 0
        cboInternalTransactionID.SelectedIndex = mintQueueSelectedIndex(0)

        If mintQueueUpperLimit > 0 Then
            btnNext.Enabled = True
        End If

        LimitSearches()
        FindProjectInformation()
        FindTechnicianAssigned()
        FindWarehouse()
        FindWarehouseEmployee()
        FindCablePartNumber()

    End Sub


    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click

        mintQueueCounter = mintQueueCounter + 1
        cboInternalTransactionID.SelectedIndex = mintQueueSelectedIndex(mintQueueCounter)

        btnBack.Enabled = True

        If mintQueueCounter = mintQueueUpperLimit Then
            btnNext.Enabled = False
        End If

        FindProjectInformation()
        FindTechnicianAssigned()
        FindWarehouse()
        FindWarehouseEmployee()
        FindCablePartNumber()

    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click

        mintQueueCounter = mintQueueCounter - 1
        cboInternalTransactionID.SelectedIndex = mintQueueSelectedIndex(mintQueueCounter)

        btnNext.Enabled = True

        If mintQueueCounter = 0 Then
            btnBack.Enabled = False
        End If

        FindProjectInformation()
        FindTechnicianAssigned()
        FindWarehouse()
        FindWarehouseEmployee()
        FindCablePartNumber()

    End Sub
    Private Sub FindProjectInformation()

        'This sub routine will find the Project Information
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim intSelectedIndex As Integer
        Dim intInternalProjectIDForSearch As Integer
        Dim intInternalProjectIDFromTable As Integer

        intNumberOfRecords = mintProjectUpperLimit
        intInternalProjectIDForSearch = CInt(txtInternalProjectID.Text)

        For intCounter = 0 To intNumberOfRecords

            cboInternalProjectID.SelectedIndex = mintProjectSelectedIndex(intCounter)
            intInternalProjectIDFromTable = CInt(cboInternalProjectID.Text)

            If intInternalProjectIDForSearch = intInternalProjectIDFromTable Then
                intSelectedIndex = intCounter
            End If

        Next

        cboInternalProjectID.SelectedIndex = mintProjectSelectedIndex(intSelectedIndex)

    End Sub
    Private Sub FindTechnicianAssigned()

        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim intSelectedIndex As Integer
        Dim intEmployeeIDForSearch As Integer
        Dim intEmployeeIDFromTable As Integer

        intNumberOfRecords = mintTechnicianUpperLimit
        intEmployeeIDForSearch = CInt(txtInternalTechnicianID.Text)

        For intCounter = 0 To intNumberOfRecords

            cboEmployeeID.SelectedIndex = mintTechnicianSelectedIndex(intCounter)
            intEmployeeIDFromTable = CInt(cboEmployeeID.Text)

            If intEmployeeIDForSearch = intEmployeeIDFromTable Then
                intSelectedIndex = intCounter
            End If

        Next

        cboEmployeeID.SelectedIndex = mintTechnicianSelectedIndex(intSelectedIndex)

    End Sub
    Private Sub FindWarehouse()

        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim intSelectedIndex As Integer
        Dim intWarehouseIDForSearch As Integer
        Dim intWarehouseIDFromTable As Integer

        intNumberOfRecords = cboWarehouseID.Items.Count - 1
        intWarehouseIDForSearch = CInt(txtInternalWarehouse.Text)

        For intCounter = 0 To intNumberOfRecords

            cboWarehouseID.SelectedIndex = intCounter
            intWarehouseIDFromTable = CInt(cboWarehouseID.Text)

            If intWarehouseIDForSearch = intWarehouseIDFromTable Then
                intSelectedIndex = intCounter
            End If

        Next

        cboWarehouseID.SelectedIndex = intSelectedIndex


    End Sub
    Private Sub FindWarehouseEmployee()

        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim intSelectedIndex As Integer
        Dim intWarehouseEmployeeIDForSearch As Integer
        Dim intWarehouseEmployeeIDFromTable As Integer

        intNumberOfRecords = cboWarehouseEmployeeID.Items.Count - 1
        intWarehouseEmployeeIDForSearch = CInt(txtInternalWarehouseEmployeeID.Text)

        For intCounter = 0 To intNumberOfRecords

            cboWarehouseEmployeeID.SelectedIndex = intCounter
            intWarehouseEmployeeIDFromTable = CInt(cboWarehouseEmployeeID.Text)

            If intWarehouseEmployeeIDForSearch = intWarehouseEmployeeIDFromTable Then
                intSelectedIndex = intCounter
            End If

        Next

        cboWarehouseEmployeeID.SelectedIndex = intSelectedIndex
    End Sub
    Private Sub FindCablePartNumber()

        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim intSelectedIndex As Integer
        Dim strPartNumberForSearch As String
        Dim strPartNumberFromTable As String

        'Setting Up Loop
        intNumberOfRecords = mintPartNumberUpperLimit
        strPartNumberForSearch = txtInternalPartNumber.Text

        For intCounter = 0 To intNumberOfRecords

            cboPartID.SelectedIndex = mintPartNumberSelectedIndex(intCounter)
            strPartNumberFromTable = txtCablePartNumber.Text

            If strPartNumberForSearch = strPartNumberFromTable Then
                intSelectedIndex = intCounter
            End If

        Next

        cboPartID.SelectedIndex = mintPartNumberSelectedIndex(intSelectedIndex)

    End Sub

    Private Sub btnManagerQueueCableReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnManagerQueueCableReport.Click

        'getting ready for the loop
        Logon.mstrCableSelectionType = "MANAGERQUEUE"
        mintPartNumberCountStart = 0
        SelectWarehouse.Show()


    End Sub
    Public Sub PrintDocument()

        'This is used to set up the print dialog box
        PrintDialog1.PrinterSettings = PrintDocument1.PrinterSettings
        If PrintDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            PrintDocument1.PrinterSettings = PrintDialog1.PrinterSettings
        End If

        PrintDocument1.Print()
    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage

        'This subroutine will run a report

        'Setting Local Variables
        Dim intManagerIDForSearch As Integer
        Dim intManagerIDFromTable As Integer
        Dim intManagerQueueCounter As Integer
        Dim intManagerQueueNumberOfRecords As Integer
        Dim intPartNumberNumberOfRecords As Integer
        Dim intPartNumberCounter As Integer
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
        Dim strCableDescriptionEntered As String
        Dim strCableDescriptionPrinted As String

        Dim fntPrtHeader As New Font("Arial", 18, FontStyle.Bold)
        Dim fntPrtSubHeader As New Font("Arial", 14, FontStyle.Bold)
        Dim fntPrtItems As New Font("Arial", 10, FontStyle.Regular)
        Dim fntPrtNotes As New Font("Arial", 8, FontStyle.Regular)
        Dim sngPrintX As Single = e.MarginBounds.Left
        Dim sngPrintY As Single = e.MarginBounds.Top
        Dim sngHeadingLineHeight As Single = fntPrtHeader.GetHeight + 10
        Dim sngItemLineHeight As Single = fntPrtItems.GetHeight + 5

        intPartNumberCountStart = mintPartNumberCountStart

        'Setting up the header for the report
        sngPrintY = 100

        sngPrintX = 250
        e.Graphics.DrawString("Blue Jay Communications Manager Queue Cable Report", fntPrtHeader, Brushes.Black, sngPrintX, sngPrintY)
        sngPrintY = sngPrintY + sngHeadingLineHeight

        sngPrintX = 300
        e.Graphics.DrawString("Report For " + txtManagerFirstName.Text + " " + txtManagerLastName.Text + " For Warehouse " + Logon.mstrWarehouse, fntPrtSubHeader, Brushes.Black, sngPrintX, sngPrintY)
        sngPrintY = sngPrintY + sngHeadingLineHeight
        sngPrintY = sngPrintY + sngHeadingLineHeight

        'Setting Search Criteria Up
        intWarehouseIDForSearch = Logon.mintWarehouseID
        intPartNumberNumberOfRecords = mintPartNumberUpperLimit
        intManagerQueueNumberOfRecords = mintManagerUpperLimit
        intManagerIDForSearch = CInt(cboManagerID.Text)

        'Setting column headers
        sngPrintX = 100
        e.Graphics.DrawString("Part Number", fntPrtItems, Brushes.Black, sngPrintX, sngPrintY)
        sngPrintX = 250
        e.Graphics.DrawString("Description", fntPrtItems, Brushes.Black, sngPrintX, sngPrintY)
        sngPrintX = 425
        e.Graphics.DrawString("Reel ID", fntPrtItems, Brushes.Black, sngPrintX, sngPrintY)
        sngPrintX = 500
        e.Graphics.DrawString("Footage", fntPrtItems, Brushes.Black, sngPrintX, sngPrintY)
        sngPrintX = 575
        e.Graphics.DrawString("Project Name", fntPrtItems, Brushes.Black, sngPrintX, sngPrintY)
        sngPrintX = 850
        e.Graphics.DrawString("Technician", fntPrtItems, Brushes.Black, sngPrintX, sngPrintY)
        sngPrintY = sngPrintY + sngItemLineHeight

        'This is where the new code will begin

        'Beginning first loop
        For intPartNumberCounter = intPartNumberCountStart To intPartNumberNumberOfRecords

            'Setting variables for Second Loop
            cboPartID.SelectedIndex = mintPartNumberSelectedIndex(intPartNumberCounter)
            strPartNumberForSearch = txtCablePartNumber.Text
            blnInformationForPartNumber = False
            intTotalFootage = 0

            'Running Second Loop
            For intManagerQueueCounter = 0 To intManagerQueueNumberOfRecords

                'Setting variables for if statements
                cboInternalTransactionID.SelectedIndex = mintQueueSelectedIndex(intManagerQueueCounter)
                intWarehouseIDFromTable = CInt(txtInternalWarehouse.Text)
                intManagerIDFromTable = CInt(txtInternalManagerID.Text)
                strPartNumberFromTable = txtInternalPartNumber.Text
                intFootagePulled = CInt(txtInternalFootagePulled.Text)

                'Running Nested IF statements
                If strPartNumberForSearch = strPartNumberFromTable Then
                    If intManagerIDForSearch = intManagerIDFromTable Then
                        If intWarehouseIDForSearch = intWarehouseIDFromTable Then
                            If intFootagePulled > 0 Then

                                'Calling routines and setting variables
                                FindTechnicianAssigned()
                                FindProjectInformation()
                                strProjectNamePrinted = ""
                                strCableDescriptionPrinted = ""

                                strProjectNameEntered = txtProjectName.Text
                                intCharacterCount = strProjectNameEntered.Length - 1

                                If intCharacterCount < 30 Then
                                    strProjectNamePrinted = strProjectNameEntered
                                Else
                                    charProjectNameCharacterArray = strProjectNameEntered.ToCharArray

                                    For intCharacterCounter = 0 To 30
                                        strProjectNamePrinted = strProjectNamePrinted + charProjectNameCharacterArray(intCharacterCounter)
                                    Next

                                End If

                                strCableDescriptionEntered = txtCableDescription.Text
                                intCharacterCount = strCableDescriptionEntered.Length - 1

                                If intCharacterCount < 20 Then
                                    strCableDescriptionPrinted = strCableDescriptionEntered
                                Else
                                    charProjectNameCharacterArray = strCableDescriptionEntered.ToCharArray

                                    For intCharacterCounter = 0 To 20
                                        strCableDescriptionPrinted = strCableDescriptionPrinted + charProjectNameCharacterArray(intCharacterCounter)
                                    Next

                                End If

                                blnInformationForPartNumber = True
                                intTotalFootage = intTotalFootage + intFootagePulled

                                'Printing output to the user
                                sngPrintX = 100
                                e.Graphics.DrawString(strPartNumberForSearch, fntPrtItems, Brushes.Black, sngPrintX, sngPrintY)
                                sngPrintX = 250
                                e.Graphics.DrawString(strCableDescriptionPrinted, fntPrtItems, Brushes.Black, sngPrintX, sngPrintY)
                                sngPrintX = 425
                                e.Graphics.DrawString(txtInternalReelID.Text, fntPrtItems, Brushes.Black, sngPrintX, sngPrintY)
                                sngPrintX = 500
                                e.Graphics.DrawString(CStr(intFootagePulled), fntPrtItems, Brushes.Black, sngPrintX, sngPrintY)
                                sngPrintX = 575
                                e.Graphics.DrawString(strProjectNamePrinted, fntPrtItems, Brushes.Black, sngPrintX, sngPrintY)
                                sngPrintX = 850
                                e.Graphics.DrawString(txtEmployeeFirstName.Text + " " + txtEmployeeLastName.Text, fntPrtItems, Brushes.Black, sngPrintX, sngPrintY)
                                sngPrintY = sngPrintY + sngItemLineHeight

                                If sngPrintY > 650 Then
                                    If intPartNumberCounter = mintPartNumberUpperLimit Then
                                        e.HasMorePages = False
                                    Else
                                        e.HasMorePages = True
                                        blnNewPage = True
                                    End If
                                ElseIf intPartNumberCounter = intPartNumberNumberOfRecords Then
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
                mintPartNumberCountStart = intPartNumberCounter + 1
                intPartNumberCounter = intPartNumberNumberOfRecords
            End If
            

        Next

    End Sub

    Private Sub PrintDocument1_QueryPageSettings(ByVal sender As Object, ByVal e As System.Drawing.Printing.QueryPageSettingsEventArgs) Handles PrintDocument1.QueryPageSettings

        e.PageSettings.Landscape = True

    End Sub
    Private Sub ClearDataBindings()

        'This sub routine clears all data bindings to prevent possible problems later


        'Clearing Combo Boxes
        cboEmployeeID.DataBindings.Clear()
        cboInternalProjectID.DataBindings.Clear()
        cboInternalTransactionID.DataBindings.Clear()
        cboManagerID.DataBindings.Clear()
        cboWarehouseEmployeeID.DataBindings.Clear()
        cboWarehouseID.DataBindings.Clear()

        'Clearing Text Boxes
        txtCableDescription.DataBindings.Clear()
        txtEmployeeFirstName.DataBindings.Clear()
        txtEmployeeLastName.DataBindings.Clear()
        txtInternalDate.DataBindings.Clear()
        txtInternalFootagePulled.DataBindings.Clear()
        txtInternalManagerID.DataBindings.Clear()
        txtInternalNotes.DataBindings.Clear()
        txtInternalPartNumber.DataBindings.Clear()
        txtInternalProjectID.DataBindings.Clear()
        txtInternalReelID.DataBindings.Clear()
        txtInternalTechnicianID.DataBindings.Clear()
        txtInternalWarehouse.DataBindings.Clear()
        txtInternalWarehouseEmployeeID.DataBindings.Clear()
        txtManagerFirstName.DataBindings.Clear()
        txtManagerGroup.DataBindings.Clear()
        txtManagerLastName.DataBindings.Clear()
        txtCablePartNumber.DataBindings.Clear()
        txtProjectName.DataBindings.Clear()
        txtTWCControlNumber.DataBindings.Clear()
        txtWarehouseEmployeeFirstName.DataBindings.Clear()
        txtWarehouseEmployeeLastName.DataBindings.Clear()
        txtWarehouseFirstName.DataBindings.Clear()
        txtWarehouseLastName.DataBindings.Clear()

    End Sub

    Private Sub btnCableMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCableMenu.Click

        ClearDataBindings()
        CableMenu.Show()
        Me.Close()

    End Sub

End Class