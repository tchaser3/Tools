'Title:         Cable Report Module
'Data:          6/23/14
'Author:        Terry Holmes

'Description:   This module will prepare all the information for the cable the report.

Option Strict On

Public Class CableReport

    'Setting up Global Variables
    Dim mstrCableType As String
    Dim mdatStartDate As Date
    Dim mdatEndDate As Date
    Dim mstrStartingDate As String
    Dim mstrEndingDate As String

    Private TheCoaxDataSet As CoaxDataSet
    Private TheCoaxDataTier As CableDataTier
    Private WithEvents TheCoaxBindingSource As BindingSource

    'Setting Variables for Issuing Cable
    Private TheIssueCableDataSet As IssueCableDataSet
    Private TheIssueCableDataTier As CableDataTier
    Private WithEvents TheIssueCableBindingSource As BindingSource

    Private TheFiberDataSet As FiberDataSet
    Private TheFiberDataTier As CableDataTier
    Private WithEvents TheFiberBindingSource As BindingSource

    Private TheDropCableDataSet As DropCableDataSet
    Private TheDropCableDataTier As CableDataTier
    Private WithEvents TheDropCableBindingSource As BindingSource

    Private TheTwistedPairDataSet As TwistedPairDataSet
    Private TheTwistedPairDataTier As CableDataTier
    Private WithEvents TheTwistedPairBindingSource As BindingSource

    Private TheSpecialityCableDataSet As SpecialityCableDataSet
    Private TheSpecialityCableDataTier As CableDataTier
    Private WithEvents TheSpecialityCableBindingSource As BindingSource

    'Setting Variables for Issuing Cable
    Private TheCableUsageDataSet As CableUsageDataSet
    Private TheCableUsageDataTier As CableDataTier
    Private WithEvents TheCableUsageBindingSource As BindingSource

    Private ThePartNumberDataSet As PartNumberDataSet
    Private ThePartNumberDataTier As PartDataTier
    Private WithEvents ThePartNumberBindingSource As BindingSource

    Dim mstrReportHeader As String

    Dim TheInputDataValidation As New InputDataValidation

    Private addingBoolean As Boolean = False
    Private editingBoolean As Boolean = False
    Private previousSelectedIndex As Integer
    Dim mintNumuberOfRecords As Integer

    Dim LogDateTime As Date = DateAndTime.Now
    Dim strLogDateTime As String

    'Setting Boolean variable to verify that Data Bindings worked
    Dim mblnFatalError As Boolean = True
    Dim mblnOnHandReport As Boolean = True

    Dim mintPartCounter As Integer
    Dim mintPartSelectedIndex(1000) As Integer
    Dim mintPartUpperLimit As Integer

    Dim mintPartNumberCountStart As Integer = 0

    Private Sub btnInventoryMenu_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInventoryMenu.Click

        InventoryMenu.Show()
        Me.Close()

    End Sub
    Private Sub MakeControlsVisible(ByVal valueBoolean As Boolean)

        'Conntrols whether controls are visible
        txtCableDescription.Visible = valueBoolean
        txtCableJobType.Visible = valueBoolean
        txtCablePartNumber.Visible = valueBoolean
        txtCablePartType.Visible = valueBoolean
        txtDate.Visible = valueBoolean
        txtFootagePulled.Visible = valueBoolean
        txtInternalProjectID.Visible = valueBoolean
        txtPartNumber.Visible = valueBoolean
        txtReelID.Visible = valueBoolean
        txtWarehouse.Visible = valueBoolean

    End Sub

    Private Sub btnCableMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCableMenu.Click

        CableMenu.Show()
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

    Private Sub CableReport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Loading up variables for form load
        mdatEndDate = CDate(Logon.mdatEndingDate)
        mdatStartDate = CDate(Logon.mdatStartingDate)
        mstrEndingDate = CStr(mdatEndDate)
        mstrStartingDate = CStr(mdatStartDate)
        SetPartNumberDataBindings()
        MakeControlsVisible(False)

        rdoCoax.PerformClick()

        
    End Sub

    Private Sub rdoCoax_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoCoax.CheckedChanged

        mstrCableType = "COAX"

    End Sub

    Private Sub rdoFiber_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoFiber.CheckedChanged

        mstrCableType = "FIBER"
       
    End Sub

    Private Sub rdoDropCable_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoDropCable.CheckedChanged

        mstrCableType = "DROP CABLE"
        
    End Sub

    Private Sub rdoTwistedPair_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoTwistedPair.CheckedChanged

        mstrCableType = "TWISTED PAIR"
        
    End Sub

    Private Sub rdoSpecialtyCable_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoSpecialtyCable.CheckedChanged

        mstrCableType = "SPECIALTY CABLE"
        
    End Sub
    Private Sub ClearDataBindings()

        'Clearss all data bindings
        cboTransactionID.DataBindings.Clear()
        txtDate.DataBindings.Clear()
        txtFootagePulled.DataBindings.Clear()
        txtInternalProjectID.DataBindings.Clear()
        txtPartNumber.DataBindings.Clear()
        txtReelID.DataBindings.Clear()
        txtWarehouse.DataBindings.Clear()

    End Sub
    Private Sub SetPartNumberDataBindings()

        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim strCablePartType As String

        'Try - Catch for Coax
        Try

            'This will bind the controls to the data source
            ThePartNumberDataTier = New PartDataTier
            ThePartNumberDataSet = ThePartNumberDataTier.GetPartNumberInformation
            ThePartNumberBindingSource = New BindingSource

            'Setting up Binding Source for the Combo Box
            With ThePartNumberBindingSource
                .DataSource = ThePartNumberDataSet
                .DataMember = "partnumbers"
                .MoveFirst()
                .MoveLast()
            End With

            'Setting the data relationship for the Combo Box
            With cboPartID
                .DataSource = ThePartNumberBindingSource
                .DisplayMember = "PartID"
                .DataBindings.Add("text", ThePartNumberBindingSource, "PartID", False, DataSourceUpdateMode.Never)
            End With

            txtCablePartNumber.DataBindings.Add("text", ThePartNumberBindingSource, "PartNumber")
            txtCableDescription.DataBindings.Add("text", ThePartNumberBindingSource, "Description")
            txtCableJobType.DataBindings.Add("text", ThePartNumberBindingSource, "Type")
            txtCablePartType.DataBindings.Add("text", ThePartNumberBindingSource, "PartType")

            'Setting up for the loop
            intNumberOfRecords = cboPartID.Items.Count - 1
            mintPartCounter = 0

            'Performing loop
            For intCounter = 0 To intNumberOfRecords

                'Setting up of if statements
                cboPartID.SelectedIndex = intCounter
                strCablePartType = txtCablePartType.Text

                'Performing if statement to see if the part number is cable
                If strCablePartType = "CABLE" Then

                    'Loading global array
                    mintPartSelectedIndex(mintPartCounter) = intCounter
                    mintPartCounter += 1

                End If

            Next

            'Setting up global limiting variables
            mintPartUpperLimit = mintPartCounter - 1
            mintPartCounter = 0

        Catch ex As Exception

            'If an exception is thrown, it is rounted here
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub SetCoaxDataBindings()

        'Try - Catch for Coax
        Try

            'This will bind the controls to the data source
            TheCoaxDataTier = New CableDataTier
            TheCoaxDataSet = TheCoaxDataTier.GetCoaxInformation
            TheCoaxBindingSource = New BindingSource

            'Setting up Binding Source for the Combo Box
            With TheCoaxBindingSource
                .DataSource = TheCoaxDataSet
                .DataMember = "coax"
                .MoveFirst()
                .MoveLast()
            End With

            'Setting the data relationship for the Combo Box
            With cboTransactionID
                .DataSource = TheCoaxBindingSource
                .DisplayMember = "ReelTransactionID"
                .DataBindings.Add("text", TheCoaxBindingSource, "ReelTransactionID", False, DataSourceUpdateMode.Never)
            End With

            'Setting the data binding for the text boxes
            txtReelID.DataBindings.Add("text", TheCoaxBindingSource, "ReelID")
            txtPartNumber.DataBindings.Add("text", TheCoaxBindingSource, "PartNumber")
            txtFootagePulled.DataBindings.Add("text", TheCoaxBindingSource, "CurrentFootage")
            txtDate.DataBindings.Add("text", TheCoaxBindingSource, "Date")
            txtWarehouse.DataBindings.Add("text", TheCoaxBindingSource, "WarehouseID")

            mblnFatalError = False

        Catch ex As Exception

            'If an exception is thrown, it is rounted here
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub
    Private Sub SetFiberDataBindings()

        'Try - Catch for Fiber
        Try

            'This will bind the controls to the data source
            TheFiberDataTier = New CableDataTier
            TheFiberDataSet = TheFiberDataTier.GetFiberInformation
            TheFiberBindingSource = New BindingSource

            'Setting up Binding Source for the Combo Box
            With TheFiberBindingSource
                .DataSource = TheFiberDataSet
                .DataMember = "fiber"
                .MoveFirst()
                .MoveLast()
            End With

            'Setting the data relationship for the Combo Box
            With cboTransactionID
                .DataSource = TheFiberBindingSource
                .DisplayMember = "ReelTransactionID"
                .DataBindings.Add("text", TheFiberBindingSource, "ReelTransactionID", False, DataSourceUpdateMode.Never)
            End With

            'Setting the data binding for the text boxes
            txtReelID.DataBindings.Add("text", TheFiberBindingSource, "ReelID")
            txtPartNumber.DataBindings.Add("text", TheFiberBindingSource, "PartNumber")
            txtFootagePulled.DataBindings.Add("text", TheFiberBindingSource, "CurrentFootage")
            txtDate.DataBindings.Add("text", TheFiberBindingSource, "Date")
            txtWarehouse.DataBindings.Add("text", TheFiberBindingSource, "WarehouseID")

            mblnFatalError = False

        Catch ex As Exception

            'If an exception is thrown, it is rounted here
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub
    Private Sub SetDropCableDataBindings()

        'Try - Catch for Drop Cable
        Try

            'This will bind the controls to the data source
            TheDropCableDataTier = New CableDataTier
            TheDropCableDataSet = TheDropCableDataTier.GetDropCableInformation
            TheDropCableBindingSource = New BindingSource

            'Setting up Binding Source for the Combo Box
            With TheDropCableBindingSource
                .DataSource = TheDropCableDataSet
                .DataMember = "dropcable"
                .MoveFirst()
                .MoveLast()
            End With

            'Setting the data relationship for the Combo Box
            With cboTransactionID
                .DataSource = TheDropCableBindingSource
                .DisplayMember = "ReelTransactionID"
                .DataBindings.Add("text", TheDropCableBindingSource, "ReelTransactionID", False, DataSourceUpdateMode.Never)
            End With

            'Setting the data binding for the text boxes
            txtReelID.DataBindings.Add("text", TheDropCableBindingSource, "ReelID")
            txtPartNumber.DataBindings.Add("text", TheDropCableBindingSource, "PartNumber")
            txtFootagePulled.DataBindings.Add("text", TheDropCableBindingSource, "CurrentFootage")
            txtDate.DataBindings.Add("text", TheDropCableBindingSource, "Date")
            txtWarehouse.DataBindings.Add("text", TheDropCableBindingSource, "WarehouseID")

            mblnFatalError = False

        Catch ex As Exception

            'If an exception is thrown, it is rounted here
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub
    Private Sub SetTwistedPairDataBindings()

        'Try - Catch for Fiber
        Try

            'This will bind the controls to the data source
            TheTwistedPairDataTier = New CableDataTier
            TheTwistedPairDataSet = TheTwistedPairDataTier.GetTwistedPairInformation
            TheTwistedPairBindingSource = New BindingSource

            'Setting up Binding Source for the Combo Box
            With TheTwistedPairBindingSource
                .DataSource = TheTwistedPairDataSet
                .DataMember = "twistedpair"
                .MoveFirst()
                .MoveLast()
            End With

            'Setting the data relationship for the Combo Box
            With cboTransactionID
                .DataSource = TheTwistedPairBindingSource
                .DisplayMember = "ReelTransactionID"
                .DataBindings.Add("text", TheTwistedPairBindingSource, "ReelTransactionID", False, DataSourceUpdateMode.Never)
            End With

            'Setting the data binding for the text boxes
            txtReelID.DataBindings.Add("text", TheTwistedPairBindingSource, "ReelID")
            txtPartNumber.DataBindings.Add("text", TheTwistedPairBindingSource, "PartNumber")
            txtFootagePulled.DataBindings.Add("text", TheTwistedPairBindingSource, "CurrentFootage")
            txtDate.DataBindings.Add("text", TheTwistedPairBindingSource, "Date")
            txtWarehouse.DataBindings.Add("text", TheTwistedPairBindingSource, "WarehouseID")

            mblnFatalError = False

        Catch ex As Exception

            'If an exception is thrown, it is rounted here
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub
    Private Sub SetSpecialityCableDataBindings()

        'Try - Catch for Fiber
        Try

            'This will bind the controls to the data source
            TheSpecialityCableDataTier = New CableDataTier
            TheSpecialityCableDataSet = TheSpecialityCableDataTier.GetSpecialityCableInformation
            TheSpecialityCableBindingSource = New BindingSource

            'Setting up Binding Source for the Combo Box
            With TheSpecialityCableBindingSource
                .DataSource = TheSpecialityCableDataSet
                .DataMember = "specialitycable"
                .MoveFirst()
                .MoveLast()
            End With

            'Setting the data relationship for the Combo Box
            With cboTransactionID
                .DataSource = TheSpecialityCableBindingSource
                .DisplayMember = "ReelTransactionID"
                .DataBindings.Add("text", TheSpecialityCableBindingSource, "ReelTransactionID", False, DataSourceUpdateMode.Never)
            End With

            'Setting the data binding for the text boxes
            txtReelID.DataBindings.Add("text", TheSpecialityCableBindingSource, "ReelID")
            txtPartNumber.DataBindings.Add("text", TheSpecialityCableBindingSource, "PartNumber")
            txtFootagePulled.DataBindings.Add("text", TheSpecialityCableBindingSource, "CurrentFootage")
            txtDate.DataBindings.Add("text", TheSpecialityCableBindingSource, "Date")
            txtWarehouse.DataBindings.Add("text", TheSpecialityCableBindingSource, "WarehouseID")

            mblnFatalError = False

        Catch ex As Exception

            'If an exception is thrown, it is rounted here
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub
    Private Sub SetCableIssueDataBindings()

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
            txtFootagePulled.DataBindings.Add("text", TheIssueCableBindingSource, "FootagePulled")
            txtReelID.DataBindings.Add("Text", TheIssueCableBindingSource, "ReelID")
            txtWarehouse.DataBindings.Add("text", TheIssueCableBindingSource, "WarehouseID")
            txtPartNumber.DataBindings.Add("text", TheIssueCableBindingSource, "PartNumber")
            txtDate.DataBindings.Add("text", TheIssueCableBindingSource, "Date")
            mblnFatalError = False

        Catch ex As Exception

            'If an exception is thrown, it is rounted here
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try



    End Sub
    Private Sub SetCableUsageDataBindings()

        Try

            'This will bind the controls to the data source
            TheCableUsageDataTier = New CableDataTier
            TheCableUsageDataSet = TheCableUsageDataTier.GetCableUsageInformation
            TheCableUsageBindingSource = New BindingSource

            'Setting up Binding Source for the Combo Box
            With TheCableUsageBindingSource
                .DataSource = TheCableUsageDataSet
                .DataMember = "cableusage"
                .MoveFirst()
                .MoveLast()
            End With

            'Setting the data relationship for the Combo Box
            With cboTransactionID
                .DataSource = TheCableUsageBindingSource
                .DisplayMember = "TransactionID"
                .DataBindings.Add("text", TheCableUsageBindingSource, "TransactionID", False, DataSourceUpdateMode.Never)
            End With

            'Setting Control bindings
            txtInternalProjectID.DataBindings.Add("text", TheCableUsageBindingSource, "InternalProjectID")
            txtFootagePulled.DataBindings.Add("text", TheCableUsageBindingSource, "FootageUsed")
            txtReelID.DataBindings.Add("Text", TheCableUsageBindingSource, "ReelID")
            txtWarehouse.DataBindings.Add("text", TheCableUsageBindingSource, "WarehouseID")
            txtPartNumber.DataBindings.Add("text", TheCableUsageBindingSource, "PartNumber")
            txtDate.DataBindings.Add("text", TheCableUsageBindingSource, "DateReported")

            mblnFatalError = False

        Catch ex As Exception

            'If an exception is thrown, it is rounted here
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnRunReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRunReport.Click

        'Setting Local Variables

        mblnFatalError = True

        PrintDialog1.PrinterSettings = PrintCableReportDocument.PrinterSettings
        If PrintDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            PrintCableReportDocument.PrinterSettings = PrintDialog1.PrinterSettings
        End If

        MakeControlsVisible(True)

        'Setting the controls according that what is selected
        If mstrCableType = "COAX" Then
            ClearDataBindings()
            ClearTextControls()
            SetCoaxDataBindings()
        ElseIf mstrCableType = "FIBER" Then
            ClearDataBindings()
            ClearTextControls()
            SetFiberDataBindings()
        ElseIf mstrCableType = "DROP CABLE" Then
            ClearDataBindings()
            ClearTextControls()
            SetDropCableDataBindings()
        ElseIf mstrCableType = "TWISTED PAIR" Then
            ClearDataBindings()
            ClearTextControls()
            SetTwistedPairDataBindings()
        ElseIf mstrCableType = "SPECIALTY CABLE" Then
            ClearDataBindings()
            ClearTextControls()
            SetSpecialityCableDataBindings()
        End If

        If mblnFatalError = True Then
            MessageBox.Show("The Data bindings for " + mstrCableType + " have failed", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ClearDataBindings()
            ClearDataBindings()
            MakeControlsVisible(False)
            Exit Sub
        End If

        'Printing On Hand Report
        strLogDateTime = CStr(LogDateTime)
        mblnOnHandReport = True
        mintPartNumberCountStart = 0
        mstrReportHeader = "Current " + mstrCableType + " Available today, " + strLogDateTime
        PrintReports()

        'Printing Cable Issued
        mblnFatalError = True
        ClearDataBindings()
        mintPartNumberCountStart = 0
        mblnOnHandReport = False
        mstrReportHeader = mstrCableType + " Issued Between " + mstrStartingDate + " And " + mstrEndingDate
        SetCableIssueDataBindings()
        If mblnFatalError = True Then
            MessageBox.Show("The Data Bindings for Issue Cable Have Failed", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            MakeControlsVisible(False)
            Exit Sub
        End If
        PrintReports()

        'Printing Cable Used
        mblnFatalError = True
        mintPartNumberCountStart = 0
        ClearDataBindings()
        mblnOnHandReport = False
        mstrReportHeader = mstrCableType + " Reported Used " + mstrStartingDate + " And " + mstrEndingDate
        SetCableUsageDataBindings()
        If mblnFatalError = True Then
            MessageBox.Show("The Data Bindings for Cable Usage Have Failed", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            MakeControlsVisible(False)
            Exit Sub
        End If
        PrintReports()

        'Resetting the form
        ClearDataBindings()
        ClearTextControls()
        MakeControlsVisible(False)

    End Sub
    Private Sub ClearTextControls()

        txtDate.Text = ""
        txtFootagePulled.Text = ""
        txtInternalProjectID.Text = ""
        txtPartNumber.Text = ""
        txtReelID.Text = ""
        txtWarehouse.Text = ""
        cboTransactionID.Text = ""

    End Sub

    Private Sub PrintCableReportDocument_QueryPageSettings(ByVal sender As Object, ByVal e As System.Drawing.Printing.QueryPageSettingsEventArgs) Handles PrintCableReportDocument.QueryPageSettings

        e.PageSettings.Landscape = True

    End Sub

    Private Sub PrintCableReportDocument_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintCableReportDocument.PrintPage

        Dim intPartNumberCounter As Integer
        Dim intPartNumberNumberOfRecords As Integer
        Dim intPartNumberCountStart As Integer
        Dim intTransactionCounter As Integer
        Dim intTransactionNumberOfRecords As Integer
        Dim strCableTypeForSearch As String
        Dim strCableTypeFromTable As String
        Dim strPartNumberForSearch As String
        Dim strPartNumberFromTable As String
        Dim intWarehouseIDForSearch As Integer
        Dim intWarehouseIDFromTable As Integer
        Dim intFootagePulled As Integer
        Dim strDescription As String
        Dim datIssuedDate As Date
        Dim blnInformationForPartNumber As Boolean
        Dim blnNewPage As Boolean = False
        Dim intTotalFootage As Integer

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

        sngPrintX = 300
        e.Graphics.DrawString("Blue Jay Communications Cable Report", fntPrtHeader, Brushes.Black, sngPrintX, sngPrintY)
        sngPrintY = sngPrintY + sngHeadingLineHeight

        If mblnOnHandReport = True Then
            sngPrintX = 300
        ElseIf mblnOnHandReport = False Then
            sngPrintX = 325
        End If

        e.Graphics.DrawString(mstrReportHeader, fntPrtSubHeader, Brushes.Black, sngPrintX, sngPrintY)
        sngPrintY = sngPrintY + sngHeadingLineHeight
        sngPrintY = sngPrintY + sngHeadingLineHeight

        'Setting column headers
        sngPrintX = 100
        e.Graphics.DrawString("Part Number", fntPrtItems, Brushes.Black, sngPrintX, sngPrintY)
        sngPrintX = 250
        e.Graphics.DrawString("Description", fntPrtItems, Brushes.Black, sngPrintX, sngPrintY)
        sngPrintX = 525
        e.Graphics.DrawString("Reel ID", fntPrtItems, Brushes.Black, sngPrintX, sngPrintY)
        sngPrintX = 625
        e.Graphics.DrawString("Footage", fntPrtItems, Brushes.Black, sngPrintX, sngPrintY)
        sngPrintX = 850
        e.Graphics.DrawString("Project ID", fntPrtItems, Brushes.Black, sngPrintX, sngPrintY)
        sngPrintY = sngPrintY + sngItemLineHeight

        'Beginning the first Loop
        intPartNumberNumberOfRecords = mintPartUpperLimit
        intTransactionNumberOfRecords = cboTransactionID.Items.Count - 1
        intWarehouseIDForSearch = CInt(Logon.mintWarehouseID)
        strCableTypeForSearch = mstrCableType

        'Running the first loop
        For intPartNumberCounter = intPartNumberCountStart To intPartNumberNumberOfRecords

            cboPartID.SelectedIndex = mintPartSelectedIndex(intPartNumberCounter)
            strCableTypeFromTable = txtCableJobType.Text
            blnInformationForPartNumber = False
            intTotalFootage = 0

            'Compare for the first loop
            If strCableTypeForSearch = strCableTypeFromTable Then

                'Setting up the parameters for the second loop
                strPartNumberForSearch = txtCablePartNumber.Text

                'Running the second loop
                For intTransactionCounter = 0 To intTransactionNumberOfRecords

                    cboTransactionID.SelectedIndex = intTransactionCounter
                    intWarehouseIDFromTable = CInt(txtWarehouse.Text)
                    strPartNumberFromTable = txtPartNumber.Text
                    intFootagePulled = CInt(txtFootagePulled.Text)
                    strDescription = txtCableDescription.Text


                    If intWarehouseIDForSearch = intWarehouseIDFromTable Then
                        If strPartNumberForSearch = strPartNumberFromTable Then
                            If intFootagePulled > 0 Then
                                If mblnOnHandReport = True Then

                                    'Prints Body
                                    sngPrintX = 100
                                    e.Graphics.DrawString(strPartNumberForSearch, fntPrtItems, Brushes.Black, sngPrintX, sngPrintY)
                                    sngPrintX = 250
                                    e.Graphics.DrawString(txtCableDescription.Text, fntPrtItems, Brushes.Black, sngPrintX, sngPrintY)
                                    sngPrintX = 525
                                    e.Graphics.DrawString(txtReelID.Text, fntPrtItems, Brushes.Black, sngPrintX, sngPrintY)
                                    sngPrintX = 625
                                    e.Graphics.DrawString(txtFootagePulled.Text, fntPrtItems, Brushes.Black, sngPrintX, sngPrintY)
                                    sngPrintX = 850
                                    e.Graphics.DrawString(txtInternalProjectID.Text, fntPrtItems, Brushes.Black, sngPrintX, sngPrintY)
                                    sngPrintY = sngPrintY + sngItemLineHeight

                                Else

                                    'This will run after the initial load
                                    datIssuedDate = CDate(txtDate.Text)

                                    If datIssuedDate >= mdatStartDate And datIssuedDate <= mdatEndDate Then

                                        'Prints Body
                                        sngPrintX = 100
                                        e.Graphics.DrawString(strPartNumberForSearch, fntPrtItems, Brushes.Black, sngPrintX, sngPrintY)
                                        sngPrintX = 250
                                        e.Graphics.DrawString(txtCableDescription.Text, fntPrtItems, Brushes.Black, sngPrintX, sngPrintY)
                                        sngPrintX = 525
                                        e.Graphics.DrawString(txtReelID.Text, fntPrtItems, Brushes.Black, sngPrintX, sngPrintY)
                                        sngPrintX = 625
                                        e.Graphics.DrawString(txtFootagePulled.Text, fntPrtItems, Brushes.Black, sngPrintX, sngPrintY)
                                        sngPrintX = 850
                                        e.Graphics.DrawString(txtInternalProjectID.Text, fntPrtItems, Brushes.Black, sngPrintX, sngPrintY)
                                        sngPrintY = sngPrintY + sngItemLineHeight

                                        

                                    End If

                                End If

                                blnInformationForPartNumber = True
                                intTotalFootage = intTotalFootage + intFootagePulled

                                If sngPrintY > 650 Then
                                    If intPartNumberCounter = mintPartUpperLimit Then
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

                Next

                If blnInformationForPartNumber = True Then
                    sngPrintX = 100
                    e.Graphics.DrawString("Total Footage for Part Number " + strPartNumberForSearch + " Is: " + CStr(intTotalFootage), fntPrtSubHeader, Brushes.Black, sngPrintX, sngPrintY)
                    sngPrintY = sngPrintY + sngHeadingLineHeight
                End If

                If blnNewPage = True Then
                    mintPartNumberCountStart = intPartNumberCounter + 1
                    intPartNumberCounter = intPartNumberNumberOfRecords
                End If

            End If
        Next


    End Sub
    Private Sub PrintReports()

        'Setting to see the Printer Dialog box
        PrintCableReportDocument.Print()
    End Sub

    Private Sub btnNewSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewSearch.Click

        Logon.mstrCableSelectionType = "CABLEREPORT"
        SelectWarehouse.Show()
        Me.Close()

    End Sub
End Class