'Title:         Void Cable Issue Transaction
'Date:          7/8/14
'Author:        Terry Holmes

'Description:   This form will void a cable transaction

Option Strict On

Public Class VoidCableIssueTransaction

    Dim TheInputDataValidation As New InputDataValidation

    Private addingBoolean As Boolean = False
    Private editingBoolean As Boolean = False
    Private previousSelectedIndex As Integer
    Dim mintNumuberOfRecords As Integer

    Dim LogDateTime As Date = DateAndTime.Now
    Dim strLogDateTime As String

    'Setting Variables for the Cable Type Boxes
    Private ThePartNumberDataSet As PartNumberDataSet
    Private ThePartNumberDataTier As PartDataTier
    Private WithEvents ThePartNumberBindingSource As BindingSource

    Private TheCoaxDataSet As CoaxDataSet
    Private TheCoaxDataTier As CableDataTier
    Private WithEvents TheCoaxBindingSource As BindingSource

    Private TheFiberDataSet As FiberDataSet
    Private TheFiberDataTier As CableDataTier
    Private WithEvents TheFiberBindingSource As BindingSource

    Private TheDropCableDataSet As DropCableDataSet
    Private TheDropCableDataTier As CableDataTier
    Private WithEvents TheDropCableBindingSource As BindingSource

    Private TheTwistedPairDataSet As TwistedPairDataSet
    Private TheTwistedPairDataTier As CableDataTier
    Private WithEvents TheTwistedPairBindingSource As BindingSource

    Private TheSpecialtyCableDataSet As SpecialityCableDataSet
    Private TheSpecialtyCableDataTier As CableDataTier
    Private WithEvents TheSpecialtyCableBindingSource As BindingSource

    'Setting Variables for Issuing Cable
    Private TheIssueCableDataSet As IssueCableDataSet
    Private TheIssueCableDataTier As CableDataTier
    Private WithEvents TheIssueCableBindingSource As BindingSource

    Private TheWarehouseDataSet As EmployeeDataSet
    Private TheWarehouseDataTier As EmployeeDataTier
    Private WithEvents TheWarehouseBindingSource As BindingSource

    Private TheVoidCableIssueDataSet As VoidCableIssueDataSet
    Private TheVoidCableIssueDataTier As CableDataTier
    Private WithEvents TheVoidCableIssueBindingSource As BindingSource

    Private TheManagerQueueDataSet As ManagerQueueDataSet
    Private TheManagerQueueDataTier As CableDataTier
    Private WithEvents TheManagerQueueBindingSource As BindingSource

    'Setting up Search Variables
    Dim mstrCableJobType As String
    Dim mstrCablePartNumber As String
    Dim mintWarehouseID As Integer
    Dim mintManagerID As Integer
    Dim mintTechnicanID As Integer
    Dim mintCurrentFootage As Integer
    Dim mintInternalProjectID As Integer
    Dim mstrReelID As String
    Dim mintFootagePulled As Integer
    Dim mintIssueCableTransactionID As Integer
    Dim mstrVoidNotes As String

    'Setting up array cable type
    Dim mintCableSelectedCounter As Integer
    Dim mintCableSelectedIndex(1000) As Integer
    Dim mintCableSelectedUpperLimit As Integer

    'Setting up array for warehouse
    Dim mintWarehouseCounter As Integer
    Dim mintWarehouseSelectedIndex(1000) As Integer
    Dim mintWarehouseUpperLimit As Integer

    'Setting up array for issue projects
    Dim mintIssueCableCounter As Integer
    Dim mintIssueCableSelectedIndex(9999) As Integer
    Dim mintIssueCableUpperLimit As Integer


    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        'Closes the Program
        CloseTheProgram.ShowDialog()

    End Sub

    Private Sub btnMainMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMainMenu.Click

        'Calls the Main Menu
        MainMenu.Show()
        Me.Close()

    End Sub

    Private Sub btnCableAdministrationMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCableAdministrationMenu.Click

        'Calls the Cable Administration Menu
        LastTransaction.Show()
        CableAdministrationMenu.Show()
        Me.Close()

    End Sub

    Private Sub btnAdministrationMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdministrationMenu.Click

        'Calls the Administrative Menu
        LastTransaction.Show()
        AdministrativeMenu.Show()
        Me.Close()

    End Sub
    Private Sub SetCableJobTypeDataBindings()

        'Try - Catch for Cable Job Type
        Try

            'This will bind the controls to the data source
            ThePartNumberDataTier = New PartDataTier
            ThePartNumberDataSet = ThePartNumberDataTier.GetPartNumberInformation
            ThePartNumberBindingSource = New BindingSource

            'Setting up the binding source
            With ThePartNumberBindingSource
                .DataSource = ThePartNumberDataSet
                .DataMember = "partnumbers"
                .MoveFirst()
                .MoveLast()
            End With

            'Setting up the combo box
            With cboPartID
                .DataSource = ThePartNumberBindingSource
                .DisplayMember = "PartID"
                .DataBindings.Add("text", ThePartNumberBindingSource, "PartID", False, DataSourceUpdateMode.Never)
            End With

            'Binding Controls
            txtCablePartNumber.DataBindings.Add("text", ThePartNumberBindingSource, "PartNumber")
            txtCableDescription.DataBindings.Add("text", ThePartNumberBindingSource, "Description")
            txtCableJobType.DataBindings.Add("text", ThePartNumberBindingSource, "Type")
            txtCablePartType.DataBindings.Add("text", ThePartNumberBindingSource, "PartType")

        Catch ex As Exception

            'If an exception is thrown, it is rounted here
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub
    Private Sub RemoveCableTypeDataBindings()

        'Clears Cable Type Data Bindings
        txtCableDescription.DataBindings.Clear()
        txtCablePartNumber.DataBindings.Clear()
        txtCableJobType.DataBindings.Clear()
    End Sub

    Private Sub VoidCableIssueTransaction_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'This routine will load when the form is activated
        LastTransaction.Show()
        SetCableJobTypeDataBindings()
        SetSelectCableVisible(False)
        SetWarehouseControlsVisible(False)
        SetIssueCableControlsVisible(False)
        SetVoidCableControlsVisible(False)

    End Sub
    Private Sub rdoCoax_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoCoax.CheckedChanged

        SetSelectCableVisible(True)
        mstrCableJobType = "COAX"
        FindCablePartNumbers()

    End Sub
    Private Sub FindCablePartNumbers()

        'Procedure to find the cable part numbers
        'Setting local variables
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim strCableJobTypeForSearch As String
        Dim strCableJobTypeFromTable As String
        Dim strCablePartTypeFromTable As String

        'Setting up buttons for use
        btnNext.Enabled = False
        btnBack.Enabled = False

        'Setting up the variables for loop
        intNumberOfRecords = cboPartID.Items.Count - 1
        strCableJobTypeForSearch = mstrCableJobType
        mintCableSelectedCounter = 0

        'Running Loop
        For intCounter = 0 To intNumberOfRecords

            'Setting up If statement conditions
            cboPartID.SelectedIndex = intCounter
            strCableJobTypeFromTable = txtCableJobType.Text
            strCablePartTypeFromTable = txtCablePartType.Text

            'Nested Loop
            If strCablePartTypeFromTable = "CABLE" Then
                If strCableJobTypeForSearch = strCableJobTypeFromTable Then

                    'Setting conditions to locate the items
                    mintCableSelectedIndex(mintCableSelectedCounter) = intCounter
                    mintCableSelectedCounter += 1

                End If
            End If

        Next

        'Setting conditions
        mintCableSelectedUpperLimit = mintCableSelectedCounter - 1
        mintCableSelectedCounter = 0

        'Setting Buttons
        If mintCableSelectedUpperLimit > 0 Then
            btnNext.Enabled = True
        End If

        cboPartID.SelectedIndex = mintCableSelectedIndex(0)
        btnSelectPartNumber.Enabled = True
        
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click

        'This is used for the cabley type next box
        mintCableSelectedCounter = mintCableSelectedCounter + 1
        cboPartID.SelectedIndex = mintCableSelectedIndex(mintCableSelectedCounter)

        btnBack.Enabled = True

        If mintCableSelectedCounter = mintCableSelectedUpperLimit Then
            btnNext.Enabled = False
        End If

    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click

        'This is used for the cabley type next box
        mintCableSelectedCounter = mintCableSelectedCounter - 1
        cboPartID.SelectedIndex = mintCableSelectedIndex(mintCableSelectedCounter)

        btnNext.Enabled = True

        If mintCableSelectedCounter = 0 Then
            btnBack.Enabled = False
        End If

    End Sub

    Private Sub rdoFiber_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoFiber.CheckedChanged

        SetSelectCableVisible(True)
        mstrCableJobType = "FIBER"
        FindCablePartNumbers()

    End Sub

    Private Sub rdoDropCable_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoDropCable.CheckedChanged

        SetSelectCableVisible(True)
        mstrCableJobType = "DROP CABLE"
        FindCablePartNumbers()

    End Sub

    Private Sub rdoTwistedPair_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoTwistedPair.CheckedChanged

        SetSelectCableVisible(True)
        mstrCableJobType = "TWISTED PAIR"
        FindCablePartNumbers()

    End Sub

    Private Sub rdoSpecialtyCable_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoSpecialtyCable.CheckedChanged

        SetSelectCableVisible(True)
        mstrCableJobType = "SPECIALTY CABLE"
        FindCablePartNumbers()

    End Sub
    Private Sub SetSelectCableVisible(ByVal valueBoolean As Boolean)

        txtCablePartNumber.Visible = valueBoolean
        txtCableDescription.Visible = valueBoolean
        txtCableJobType.Visible = valueBoolean
        btnBack.Visible = valueBoolean
        btnNext.Visible = valueBoolean
        txtCablePartType.Visible = valueBoolean
        btnFind.Enabled = valueBoolean
        btnFind.Visible = valueBoolean

    End Sub
    Private Sub SetWarehouseDataBindings()

        'This will Set the Warehouse DataBindings
        Try

            'Setting Up Class variables
            TheWarehouseDataTier = New EmployeeDataTier
            TheWarehouseDataSet = TheWarehouseDataTier.GetEmployeeInformation
            TheWarehouseBindingSource = New BindingSource

            'Setting up the Binding Source
            With TheWarehouseBindingSource
                .DataSource = TheWarehouseDataSet
                .DataMember = "employees"
                .MoveFirst()
                .MoveLast()
            End With

            'Setting the Combo Box Bindings
            With cboWarehouseID
                .DataSource = TheWarehouseBindingSource
                .DisplayMember = "EmployeeID"
                .DataBindings.Add("text", TheWarehouseBindingSource, "EmployeeID", False, DataSourceUpdateMode.Never)
            End With

            txtWarehouseFirstName.DataBindings.Add("text", TheWarehouseBindingSource, "FirstName")
            txtWarehouseLastName.DataBindings.Add("text", TheWarehouseBindingSource, "LastName")

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub ClearWarehouseDataBindings()

        'clears the warehouse databindings
        cboWarehouseID.DataBindings.Clear()
        txtWarehouseFirstName.DataBindings.Clear()
        txtWarehouseLastName.DataBindings.Clear()

    End Sub
    Private Sub FindWarehouseLocations()

        'This routine will find all parts locations

        'Setting Local Variables
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim strWarehouseLastName As String

        'setting up buttons for warehouse
        btnWarehouseBack.Enabled = False
        btnWarehouseNext.Enabled = False

        'Setting Up Search Parameters
        intNumberOfRecords = cboWarehouseID.Items.Count - 1
        mintWarehouseCounter = 0

        'Performing the loop
        For intCounter = 0 To intNumberOfRecords

            'setting up If Statement
            cboWarehouseID.SelectedIndex = intCounter
            strWarehouseLastName = txtWarehouseLastName.Text

            'Running If Statements
            If strWarehouseLastName = "PARTS" Then

                'Setting up variables for each matching condition found
                mintWarehouseSelectedIndex(mintWarehouseCounter) = intCounter
                mintWarehouseCounter = mintWarehouseCounter + 1

            End If

        Next

        mintWarehouseUpperLimit = mintWarehouseCounter - 1
        mintWarehouseCounter = 0

        If mintWarehouseUpperLimit > 0 Then
            btnWarehouseNext.Enabled = True
        End If

        btnWarehouseSelect.Enabled = True
        cboWarehouseID.SelectedIndex = mintWarehouseSelectedIndex(0)

    End Sub

    Private Sub btnWarehouseNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWarehouseNext.Click

        'This will increment the combo box
        mintWarehouseCounter = mintWarehouseCounter + 1
        cboWarehouseID.SelectedIndex = mintWarehouseSelectedIndex(mintWarehouseCounter)

        btnWarehouseBack.Enabled = True

        If mintWarehouseCounter = mintWarehouseUpperLimit Then
            btnWarehouseNext.Enabled = False
        End If

    End Sub

    Private Sub btnWarehouseBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWarehouseBack.Click

        'This will decrement the combo box
        mintWarehouseCounter = mintWarehouseCounter - 1
        cboWarehouseID.SelectedIndex = mintWarehouseSelectedIndex(mintWarehouseCounter)

        btnWarehouseNext.Enabled = True

        If mintWarehouseCounter = 0 Then
            btnWarehouseBack.Enabled = False
        End If

    End Sub
    Private Sub SetWarehouseControlsVisible(ByVal valueBoolean As Boolean)

        txtWarehouseFirstName.Visible = valueBoolean
        txtWarehouseLastName.Visible = valueBoolean
        btnWarehouseBack.Visible = valueBoolean
        btnWarehouseNext.Visible = valueBoolean
        btnWarehouseSelect.Visible = valueBoolean

    End Sub

    Private Sub btnSelectPartNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectPartNumber.Click

        'This will run when the set button is selected
        mstrCablePartNumber = txtCablePartNumber.Text
        SetWarehouseControlsVisible(True)
        SetWarehouseDataBindings()
        FindWarehouseLocations()
        SetSelectCableVisible(False)
        gboSelectType.Visible = False

    End Sub
    Private Sub SetIssueCableDataBinding()

        Try

            txtIssueCableReelID.Visible = True

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
            With cboIssueCableTransactionID
                .DataSource = TheIssueCableBindingSource
                .DisplayMember = "TransactionID"
                .DataBindings.Add("text", TheIssueCableBindingSource, "TransactionID", False, DataSourceUpdateMode.Never)
            End With

            'Setting Control bindings
            txtIssueCableInternalProjectID.DataBindings.Add("text", TheIssueCableBindingSource, "InternalProjectID")
            txtIssueCableTechnicianID.DataBindings.Add("text", TheIssueCableBindingSource, "TechnicianID")
            txtIssueCableFootagePulled.DataBindings.Add("text", TheIssueCableBindingSource, "FootagePulled")
            txtIssueCableManagerID.DataBindings.Add("text", TheIssueCableBindingSource, "ManagersID")
            txtIssueCableReelID.DataBindings.Add("Text", TheIssueCableBindingSource, "ReelID")
            txtIssueCableWarehouse.DataBindings.Add("text", TheIssueCableBindingSource, "WarehouseID")
            txtIssueCablePartNumber.DataBindings.Add("text", TheIssueCableBindingSource, "PartNumber")
            txtIssueCableDate.DataBindings.Add("text", TheIssueCableBindingSource, "Date")

        Catch ex As Exception

            'If an exception is thrown, it is rounted here
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub ClearIssueCableDataBindings()

        'Clearing data bindings for Projects
        cboIssueCableTransactionID.DataBindings.Clear()
        txtIssueCableInternalProjectID.DataBindings.Clear()
        txtIssueCableTechnicianID.DataBindings.Clear()
        txtIssueCableFootagePulled.DataBindings.Clear()
        txtIssueCableManagerID.DataBindings.Clear()
        txtIssueCableReelID.DataBindings.Clear()
        txtIssueCableWarehouse.DataBindings.Clear()
        txtIssueCablePartNumber.DataBindings.Clear()
        txtIssueCableDate.DataBindings.Clear()

    End Sub
    Private Sub SetIssueCableControlsVisible(ByVal valueBoolean As Boolean)

        'Making Controls Visible
        txtIssueCableInternalProjectID.Visible = valueBoolean
        txtIssueCableTechnicianID.Visible = valueBoolean
        txtIssueCableFootagePulled.Visible = valueBoolean
        txtIssueCableManagerID.Visible = valueBoolean
        txtIssueCableReelID.Visible = valueBoolean
        txtIssueCableWarehouse.Visible = valueBoolean
        txtIssueCablePartNumber.Visible = valueBoolean
        txtIssueCableDate.Visible = valueBoolean
        btnIssueBack.Visible = valueBoolean
        btnIssueNext.Visible = valueBoolean
        btnVoidCurrentTransaction.Visible = valueBoolean

    End Sub
    Private Function FindIssueCableTransactions() As Boolean

        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim intWarehouseIDFromTable As Integer
        Dim strPartNumberFromTable As String
        Dim intFootagePulled As Integer
        Dim blnTransactionNotFound As Boolean = True

        btnIssueBack.Enabled = False
        btnIssueNext.Enabled = False

        'Setting up variables
        intNumberOfRecords = cboIssueCableTransactionID.Items.Count - 1
        mintIssueCableCounter = 0

        'Beginning Loop
        For intCounter = 0 To intNumberOfRecords

            'Setting up parameters
            cboIssueCableTransactionID.SelectedIndex = intCounter
            intWarehouseIDFromTable = CInt(txtIssueCableWarehouse.Text)
            strPartNumberFromTable = txtIssueCablePartNumber.Text
            intFootagePulled = CInt(txtIssueCableFootagePulled.Text)

            'Setting up If Statements
            If intWarehouseIDFromTable = mintWarehouseID Then
                If strPartNumberFromTable = mstrCablePartNumber Then
                    If intFootagePulled > 0 Then

                        'Setting Variables
                        mintIssueCableSelectedIndex(mintIssueCableCounter) = intCounter
                        mintIssueCableCounter = mintIssueCableCounter + 1
                        blnTransactionNotFound = False

                    End If
                End If
            End If

        Next

        'Setting Navagation buttons
        mintIssueCableUpperLimit = mintIssueCableCounter - 1
        mintIssueCableCounter = 0

        If mintIssueCableUpperLimit > 0 Then
            btnIssueNext.Enabled = True
        End If

        btnVoidCurrentTransaction.Enabled = True
        cboIssueCableTransactionID.SelectedIndex = mintIssueCableSelectedIndex(0)

        Return blnTransactionNotFound

    End Function

    Private Sub btnWarehouseSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWarehouseSelect.Click

        'This will run find all the transactions
        Dim blnTransactionNotFound As Boolean

        'Setting Conditions
        cboWarehouseID.Visible = True
        mintWarehouseID = CInt(cboWarehouseID.Text)
        cboWarehouseID.Visible = False
        SetIssueCableControlsVisible(True)
        SetIssueCableDataBinding()

        'Finding the cable transactions
        blnTransactionNotFound = FindIssueCableTransactions()

        'Checking to see if the transaction has been found
        If blnTransactionNotFound = True Then
            ClearIssueCableDataBindings()
            SetIssueCableControlsVisible(False)
            SetWarehouseControlsVisible(False)
            gboSelectType.Visible = True
            SetSelectCableVisible(True)
            ClearWarehouseDataBindings()
            MessageBox.Show("There Is no Transaction Listed for the Cable Selected", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        'Making controls invisible
        SetWarehouseControlsVisible(False)
        txtVoidNotes.Visible = True

    End Sub

    Private Sub SetVoidCableIssueDataBindings()

        'This will load the Data Bindings for the void table
        Try

            'Setting up initial settings
            TheVoidCableIssueDataTier = New CableDataTier
            TheVoidCableIssueDataSet = TheVoidCableIssueDataTier.GetVoidCableIssueInformation
            TheVoidCableIssueBindingSource = New BindingSource

            'Setting up the Binding Source
            With TheVoidCableIssueBindingSource
                .DataSource = TheVoidCableIssueDataSet
                .DataMember = "voidcableissue"
                .MoveFirst()
                .MoveLast()
            End With

            'Binding Combo Box
            With cboVoidTransactionID
                .DataSource = TheVoidCableIssueBindingSource
                .DisplayMember = "TransactionID"
                .DataBindings.Add("text", TheVoidCableIssueBindingSource, "TransactionID", False, DataSourceUpdateMode.Never)
            End With

            'Binding Other Controls
            txtVoidIssueTransactionID.DataBindings.Add("text", TheVoidCableIssueBindingSource, "IssueCableTransactionID")
            txtVoidWarehouseID.DataBindings.Add("text", TheVoidCableIssueBindingSource, "WarehouseID")
            txtVoidWarehouseEmployeeID.DataBindings.Add("text", TheVoidCableIssueBindingSource, "WarehouseEmployeeID")
            txtVoidNotes.DataBindings.Add("text", TheVoidCableIssueBindingSource, "Notes")

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnVoidCurrentTransaction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVoidCurrentTransaction.Click

        Dim strValueForValidation As String
        Dim blnFatalError As Boolean
        Dim strValueForLastTransaction As String

        'Validation for Notes
        strValueForValidation = txtVoidNotes.Text
        blnFatalError = TheInputDataValidation.VerifyTextData(strValueForValidation)

        If blnFatalError = True Then
            MessageBox.Show("The Notes Were Not Entered", "Please Correct the Void Notes", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        SetVoidCableControlsVisible(True)

        mstrVoidNotes = txtVoidNotes.Text

        SetVoidCableIssueDataBindings()
        SetCableTransactionDataBindings()
        FindCableTransaction()
        EditCableTransaction()
        SearchIssueCableTransactionControls()
        EditIssueCableTransaction()
        ClearIssueCableDataBindings()
        RemoveTextFromIssueCableControls()
        SetManagerQueueDataBindings()
        FindManagerQueueCableTransaction()
        SaveVoidTransaction()
        MessageBox.Show("The Transaction Has Been Voided", "Thank You", MessageBoxButtons.OK, MessageBoxIcon.Information)
        CableAdministrationMenu.Show()
        Me.Close()

    End Sub
    Private Sub SaveVoidTransaction()

        'Setting Local Variables
        Dim intNumberOfRecords As Integer

        'Setting Binding Source
        With TheVoidCableIssueBindingSource
            .EndEdit()
            .AddNew()
        End With

        'Setting Controls
        addingBoolean = True
        SetComboBoxBinding()
        cboVoidTransactionID.Focus()
        If cboVoidTransactionID.SelectedIndex <> -1 Then
            previousSelectedIndex = cboVoidTransactionID.Items.Count - 1
        Else
            previousSelectedIndex = 0
        End If

        CableTransactionID.Show()
        intNumberOfRecords = CInt(Logon.mintReelTransactionID)
        cboVoidTransactionID.Text = CStr(intNumberOfRecords)
        txtVoidIssueTransactionID.Text = CStr(mintInternalProjectID)
        txtVoidWarehouseID.Text = CStr(mintWarehouseID)
        txtVoidWarehouseEmployeeID.Text = CStr(Logon.mintWarehouseEmployeeID)
        txtVoidNotes.Text = mstrVoidNotes

        'Saving the record
        Try
            TheVoidCableIssueBindingSource.EndEdit()
            TheVoidCableIssueDataTier.UpdateVoidCableIssueDB(TheVoidCableIssueDataSet)
            addingBoolean = False
            editingBoolean = False
            cboVoidTransactionID.SelectedIndex = previousSelectedIndex
        Catch ex As Exception
            MessageBox.Show(ex.Message, "There is a Problem", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub SetComboBoxBinding()

        With Me.cboVoidTransactionID
            If (addingBoolean Or editingBoolean) Then
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.OnValidation
                .DropDownStyle = ComboBoxStyle.Simple
            Else
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.Never
                .DropDownStyle = ComboBoxStyle.DropDownList
            End If
        End With

    End Sub
    Private Sub FindManagerQueueCableTransaction()

        'Setting Local Variables
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim intSelectedIndex As Integer
        Dim intManagerIDForSearch As Integer
        Dim intManagerIDFromTable As Integer
        Dim intInternalProjectIDForSearch As Integer
        Dim intInternalProjectIDFromTable As Integer
        Dim intTechincianIDForSearch As Integer
        Dim intTechincianIDFromTable As Integer
        Dim intWarehouseIDForSearch As Integer
        Dim intWarehouseIDFromTable As Integer
        Dim strPartNumberForSearch As String
        Dim strPartNumberFromTable As String
        Dim strReelIDForSearch As String
        Dim strReelIDFromTable As String
        Dim intFootagePulledForSearch As Integer
        Dim intFootagePulledFromTable As Integer

        'setting conditions for loop
        intNumberOfRecords = cboIssueCableTransactionID.Items.Count - 1
        intManagerIDForSearch = mintManagerID
        intInternalProjectIDForSearch = mintInternalProjectID
        intTechincianIDForSearch = mintTechnicanID
        intWarehouseIDForSearch = mintWarehouseID
        strPartNumberForSearch = mstrCablePartNumber
        strReelIDForSearch = mstrReelID
        intFootagePulledForSearch = mintFootagePulled

        'Beginning Loop
        For intCounter = 0 To intNumberOfRecords

            'Setting conditions for the it statement
            cboIssueCableTransactionID.SelectedIndex = intCounter
            intManagerIDFromTable = CInt(txtIssueCableManagerID.Text)
            intInternalProjectIDFromTable = CInt(txtIssueCableInternalProjectID.Text)
            intTechincianIDFromTable = CInt(txtIssueCableTechnicianID.Text)
            intWarehouseIDFromTable = CInt(txtIssueCableWarehouse.Text)
            strPartNumberFromTable = txtIssueCablePartNumber.Text
            strReelIDFromTable = txtIssueCableReelID.Text
            intFootagePulledFromTable = CInt(txtIssueCableFootagePulled.Text)

            'Preforming loop
            If intInternalProjectIDForSearch = intInternalProjectIDFromTable Then
                If intWarehouseIDForSearch = intWarehouseIDFromTable Then
                    If strPartNumberForSearch = strPartNumberFromTable Then
                        If strReelIDForSearch = strReelIDFromTable Then
                            If intManagerIDForSearch = intManagerIDFromTable Then
                                If intTechincianIDForSearch = intTechincianIDFromTable Then
                                    If intFootagePulledForSearch = intFootagePulledFromTable Then
                                        intSelectedIndex = intCounter
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        Next

        'Setting Combobox Selected Index
        cboIssueCableTransactionID.SelectedIndex = intSelectedIndex

        'Editing the record
        editingBoolean = True
        txtIssueCableFootagePulled.Text = "0"

        'Saving Record
        Try
            TheManagerQueueBindingSource.EndEdit()
            TheManagerQueueDataTier.UpdateManagerQueueDB(TheManagerQueueDataSet)
            editingBoolean = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub SetManagerQueueDataBindings()

        'This will set the Manager Queue Data Bindings
        Try

            'Initial Set Up
            TheManagerQueueDataTier = New CableDataTier
            TheManagerQueueDataSet = TheManagerQueueDataTier.GetManagerQueueInformation
            TheManagerQueueBindingSource = New BindingSource

            'Setting up the binding source
            With TheManagerQueueBindingSource
                .DataSource = TheManagerQueueDataSet
                .DataMember = "managerqueue"
                .MoveFirst()
                .MoveLast()
            End With

            'setting the combo box
            With cboIssueCableTransactionID
                .DataSource = TheManagerQueueBindingSource
                .DisplayMember = "TransactionID"
                .DataBindings.Add("text", TheManagerQueueBindingSource, "TransactionID", False, DataSourceUpdateMode.Never)
            End With

            txtIssueCableInternalProjectID.DataBindings.Add("text", TheManagerQueueBindingSource, "InternalProjectID")
            txtIssueCableTechnicianID.DataBindings.Add("text", TheManagerQueueBindingSource, "TechnicianID")
            txtIssueCableFootagePulled.DataBindings.Add("text", TheManagerQueueBindingSource, "Footage")
            txtIssueCableManagerID.DataBindings.Add("text", TheManagerQueueBindingSource, "ManagersID")
            txtIssueCableReelID.DataBindings.Add("text", TheManagerQueueBindingSource, "ReelID")
            txtIssueCableWarehouse.DataBindings.Add("text", TheManagerQueueBindingSource, "WarehouseID")
            txtIssueCablePartNumber.DataBindings.Add("text", TheManagerQueueBindingSource, "PartNumber")

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub RemoveTextFromIssueCableControls()

        txtIssueCableDate.Text = ""
        txtIssueCableFootagePulled.Text = ""
        txtIssueCableInternalProjectID.Text = ""
        txtIssueCableManagerID.Text = ""
        txtIssueCablePartNumber.Text = ""
        txtIssueCableReelID.Text = ""
        txtIssueCableTechnicianID.Text = ""
        txtIssueCableWarehouse.Text = ""

    End Sub
    Private Sub SearchIssueCableTransactionControls()

        'This sub routine will be called to find the information in the Issue Cable Controls

        'Setting up local variables
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim intSelectedIndex As Integer
        Dim intInternalProjectForSearch As Integer
        Dim intInternalProjectFromTable As Integer
        Dim intWarehouseIDForSearch As Integer
        Dim intWarehouseIDFromTable As Integer
        Dim strPartNumberForSearch As String
        Dim strPartNumberfromTable As String
        Dim strReelIDforSearch As String
        Dim strReelIDFromTable As String

        'Setting up for loop
        intNumberOfRecords = cboIssueCableTransactionID.Items.Count - 1
        intInternalProjectForSearch = mintInternalProjectID
        intWarehouseIDForSearch = mintWarehouseID
        strPartNumberForSearch = mstrCablePartNumber
        strReelIDforSearch = mstrReelID

        'performing loop
        For intCounter = 0 To intNumberOfRecords

            'setting controls for If statements
            cboIssueCableTransactionID.SelectedIndex = intCounter
            intInternalProjectFromTable = CInt(txtIssueCableInternalProjectID.Text)
            intWarehouseIDFromTable = CInt(txtIssueCableWarehouse.Text)
            strPartNumberfromTable = txtIssueCablePartNumber.Text
            strReelIDFromTable = txtIssueCableReelID.Text

            If intInternalProjectForSearch = intInternalProjectFromTable Then
                If intWarehouseIDForSearch = intWarehouseIDFromTable Then
                    If strPartNumberForSearch = strPartNumberfromTable Then
                        If strReelIDforSearch = strReelIDFromTable Then
                            intSelectedIndex = intCounter
                        End If
                    End If
                End If
            End If

        Next

        'setting up the combo box
        cboIssueCableTransactionID.SelectedIndex = intSelectedIndex

        editingBoolean = True

        txtIssueCableFootagePulled.Text = "0"

    End Sub
    Private Sub EditIssueCableTransaction()

        'This routine will edit the Issue Cable Transaction

        'Updating the Issue Cable Dataset 
        Try
            TheIssueCableBindingSource.EndEdit()
            TheIssueCableDataTier.UpdateIssueCableDB(TheIssueCableDataSet)
            editingBoolean = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub EditCableTransaction()

        Dim intFootageOnReel As Integer
        Dim intTotalFootage As Integer

        editingBoolean = True

        'Doing Math
        intFootageOnReel = CInt(txtCableTransactionCurrentFootage.Text)
        intTotalFootage = intFootageOnReel + mintFootagePulled
        txtCableTransactionCurrentFootage.Text = CStr(intTotalFootage)

        'Saving Information
        Try
            If mstrCableJobType = "COAX" Then
                TheCoaxBindingSource.EndEdit()
                TheCoaxDataTier.UpdateCoaxDB(TheCoaxDataSet)
            ElseIf mstrCableJobType = "DROP CABLE" Then
                TheDropCableBindingSource.EndEdit()
                TheDropCableDataTier.UpdateDropCableDB(TheDropCableDataSet)
            ElseIf mstrCableJobType = "FIBER" Then
                TheFiberBindingSource.EndEdit()
                TheFiberDataTier.UpdateFiberDB(TheFiberDataSet)
            ElseIf mstrCableJobType = "TWISTED PAIR" Then
                TheTwistedPairBindingSource.EndEdit()
                TheTwistedPairDataTier.UpdateTwistedPairDB(TheTwistedPairDataSet)
            ElseIf mstrCableJobType = "SPECIALTY CABLE" Then
                TheSpecialtyCableBindingSource.EndEdit()
                TheSpecialtyCableDataTier.UpdateSpecialityCableDB(TheSpecialtyCableDataSet)
            End If

            editingBoolean = False
            addingBoolean = False

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub FindCableTransaction()

        'Setting local variables
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim intSelectedIndex As Integer
        Dim intWarehouseIDForSearch As Integer
        Dim intWarehouseIDFromTable As Integer
        Dim strPartNumberForSearch As String
        Dim strPartNumberFromTable As String
        Dim strReelIDForSearch As String
        Dim strReelIDFromTable As String


        'Setting up global variables
        mstrReelID = txtIssueCableReelID.Text()
        mintWarehouseID = CInt(txtIssueCableWarehouse.Text)
        mintInternalProjectID = CInt(txtIssueCableInternalProjectID.Text)
        mstrCablePartNumber = txtIssueCablePartNumber.Text
        mintManagerID = CInt(txtIssueCableManagerID.Text)
        mintTechnicanID = CInt(txtIssueCableTechnicianID.Text)
        mintFootagePulled = CInt(txtIssueCableFootagePulled.Text)
        cboIssueCableTransactionID.Visible = True
        mintIssueCableTransactionID = CInt(cboIssueCableTransactionID.Text)
        cboIssueCableTransactionID.Visible = False

        'Setting variables for loop
        intNumberOfRecords = cboReelTransactionID.Items.Count - 1
        intWarehouseIDForSearch = mintWarehouseID
        strPartNumberForSearch = mstrCablePartNumber

        strReelIDForSearch = mstrReelID

        'Performing Loop
        For intCounter = 0 To intNumberOfRecords

            'Setting for If Statements
            cboReelTransactionID.SelectedIndex = intCounter
            intWarehouseIDFromTable = CInt(txtCableTransactionWarehouseID.Text)
            strPartNumberFromTable = txtCableTransactionPartNumber.Text
            strReelIDFromTable = txtCableTransactionReelID.Text

            'Performing If statements5
            If intWarehouseIDForSearch = intWarehouseIDFromTable Then
                If strPartNumberForSearch = strPartNumberFromTable Then
                    If strReelIDForSearch = strReelIDFromTable Then
                        intSelectedIndex = intCounter
                    End If
                End If
            End If

        Next

        'Setting the combobox selected index
        cboReelTransactionID.SelectedIndex = intSelectedIndex

    End Sub
    Private Sub SetCableTransactionDataBindings()

        If mstrCableJobType = "COAX" Then

            TheCoaxDataTier = New CableDataTier
            TheCoaxDataSet = TheCoaxDataTier.GetCoaxInformation
            TheCoaxBindingSource = New BindingSource

            With TheCoaxBindingSource
                .DataSource = TheCoaxDataSet
                .DataMember = "coax"
                .MoveFirst()
                .MoveLast()
            End With

            With cboReelTransactionID
                .DataSource = TheCoaxBindingSource
                .DisplayMember = "ReelTransactionID"
                .DataBindings.Add("text", TheCoaxBindingSource, "ReelTransactionID", False, DataSourceUpdateMode.Never)
            End With

            txtCableTransactionReelID.DataBindings.Add("text", TheCoaxBindingSource, "ReelID")
            txtCableTransactionPartNumber.DataBindings.Add("text", TheCoaxBindingSource, "PartNumber")
            txtCableTransactionCurrentFootage.DataBindings.Add("text", TheCoaxBindingSource, "CurrentFootage")
            txtCableTransactionWarehouseID.DataBindings.Add("text", TheCoaxBindingSource, "WarehouseID")

        ElseIf mstrCableJobType = "DROP CABLE" Then

            TheDropCableDataTier = New CableDataTier
            TheDropCableDataSet = TheDropCableDataTier.GetDropCableInformation
            TheDropCableBindingSource = New BindingSource

            With TheDropCableBindingSource
                .DataSource = TheDropCableDataSet
                .DataMember = "dropcable"
                .MoveFirst()
                .MoveLast()
            End With

            With cboReelTransactionID
                .DataSource = TheDropCableBindingSource
                .DisplayMember = "ReelTransactionID"
                .DataBindings.Add("text", TheDropCableBindingSource, "ReelTransactionID", False, DataSourceUpdateMode.Never)
            End With

            txtCableTransactionReelID.DataBindings.Add("text", TheDropCableBindingSource, "ReelID")
            txtCableTransactionPartNumber.DataBindings.Add("text", TheDropCableBindingSource, "PartNumber")
            txtCableTransactionCurrentFootage.DataBindings.Add("text", TheDropCableBindingSource, "CurrentFootage")
            txtCableTransactionWarehouseID.DataBindings.Add("text", TheDropCableBindingSource, "WarehouseID")

        ElseIf mstrCableJobType = "FIBER" Then

            TheFiberDataTier = New CableDataTier
            TheFiberDataSet = TheFiberDataTier.GetFiberInformation
            TheFiberBindingSource = New BindingSource

            With TheFiberBindingSource
                .DataSource = TheFiberDataSet
                .DataMember = "fiber"
                .MoveFirst()
                .MoveLast()
            End With

            With cboReelTransactionID
                .DataSource = TheFiberBindingSource
                .DisplayMember = "ReelTransactionID"
                .DataBindings.Add("text", TheFiberBindingSource, "ReelTransactionID", False, DataSourceUpdateMode.Never)
            End With

            txtCableTransactionReelID.DataBindings.Add("text", TheFiberBindingSource, "ReelID")
            txtCableTransactionPartNumber.DataBindings.Add("text", TheFiberBindingSource, "PartNumber")
            txtCableTransactionCurrentFootage.DataBindings.Add("text", TheFiberBindingSource, "CurrentFootage")
            txtCableTransactionWarehouseID.DataBindings.Add("text", TheFiberBindingSource, "WarehouseID")

        ElseIf mstrCableJobType = "TWISTED PAIR" Then

            TheTwistedPairDataTier = New CableDataTier
            TheTwistedPairDataSet = TheTwistedPairDataTier.GetTwistedPairInformation
            TheTwistedPairBindingSource = New BindingSource

            With TheTwistedPairBindingSource
                .DataSource = TheTwistedPairDataSet
                .DataMember = "twistedpair"
                .MoveFirst()
                .MoveLast()
            End With

            With cboReelTransactionID
                .DataSource = TheTwistedPairBindingSource
                .DisplayMember = "ReelTransactionID"
                .DataBindings.Add("text", TheTwistedPairBindingSource, "ReelTransactionID", False, DataSourceUpdateMode.Never)
            End With

            txtCableTransactionReelID.DataBindings.Add("text", TheTwistedPairBindingSource, "ReelID")
            txtCableTransactionPartNumber.DataBindings.Add("text", TheTwistedPairBindingSource, "PartNumber")
            txtCableTransactionCurrentFootage.DataBindings.Add("text", TheTwistedPairBindingSource, "CurrentFootage")
            txtCableTransactionWarehouseID.DataBindings.Add("text", TheTwistedPairBindingSource, "WarehouseID")

        ElseIf mstrCableJobType = "SPECIALTY CABLE" Then

            TheSpecialtyCableDataTier = New CableDataTier
            TheSpecialtyCableDataSet = TheSpecialtyCableDataTier.GetSpecialityCableInformation
            TheSpecialtyCableBindingSource = New BindingSource

            With TheSpecialtyCableBindingSource
                .DataSource = TheSpecialtyCableDataSet
                .DataMember = "specialitycable"
                .MoveFirst()
                .MoveLast()
            End With

            With cboReelTransactionID
                .DataSource = TheSpecialtyCableBindingSource
                .DisplayMember = "ReelTransactionID"
                .DataBindings.Add("text", TheSpecialtyCableBindingSource, "ReelTransactionID", False, DataSourceUpdateMode.Never)
            End With

            txtCableTransactionReelID.DataBindings.Add("text", TheSpecialtyCableBindingSource, "ReelID")
            txtCableTransactionPartNumber.DataBindings.Add("text", TheSpecialtyCableBindingSource, "PartNumber")
            txtCableTransactionCurrentFootage.DataBindings.Add("text", TheSpecialtyCableBindingSource, "CurrentFootage")
            txtCableTransactionWarehouseID.DataBindings.Add("text", TheSpecialtyCableBindingSource, "WarehouseID")

        End If

    End Sub
    
    Private Sub ClearCableTransactionDataBindings()

        'clears the data bindings
        cboReelTransactionID.DataBindings.Clear()
        txtCableTransactionCurrentFootage.DataBindings.Clear()
        txtCableTransactionPartNumber.DataBindings.Clear()
        txtCableTransactionReelID.DataBindings.Clear()
        txtCableTransactionWarehouseID.DataBindings.Clear()

    End Sub

    Private Sub btnIssueNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIssueNext.Click

        'setting the counter
        mintIssueCableCounter += 1
        cboIssueCableTransactionID.SelectedIndex = mintIssueCableSelectedIndex(mintIssueCableCounter)

        'enabling the button
        btnIssueBack.Enabled = True

        'If condition is correct, the button is disabled
        If mintIssueCableCounter = mintIssueCableUpperLimit Then
            btnIssueNext.Enabled = False
        End If

    End Sub

    Private Sub btnIssueBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIssueBack.Click

        'decrementing the counter
        mintIssueCableCounter -= 1
        cboIssueCableTransactionID.SelectedIndex = mintIssueCableSelectedIndex(mintIssueCableCounter)

        'enabling the next button
        btnIssueNext.Enabled = True

        'If the condition is correct, then the back button is disabled
        If mintIssueCableCounter = 0 Then
            btnIssueBack.Enabled = False
        End If

    End Sub
    Private Sub SetVoidCableControlsVisible(ByVal valueBoolean As Boolean)

        'setting the void controls
        txtVoidIssueTransactionID.Visible = valueBoolean
        txtVoidNotes.Visible = valueBoolean
        txtVoidWarehouseEmployeeID.Visible = valueBoolean
        txtVoidWarehouseID.Visible = valueBoolean
        cboVoidTransactionID.Visible = valueBoolean

        'setting the cable controls
        txtCableTransactionCurrentFootage.Visible = valueBoolean
        txtCableTransactionPartNumber.Visible = valueBoolean
        txtCableTransactionReelID.Visible = valueBoolean
        txtCableTransactionWarehouseID.Visible = valueBoolean

    End Sub

    Private Sub btnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFind.Click

        'This will find the cable via entering the number

        'Setting local variables
        Dim intKeywordLengthFromTable As Integer = 0
        Dim intKeywordLengthForSearch As Integer = 0
        Dim intNumberOfRecords As Integer = 0
        Dim strKeywordForSearch As String = ""
        Dim strKeywordFromTable As String = ""
        Dim chaKeywordArray() As Char
        Dim blnFatalError As Boolean = False
        Dim blnItemNotFound As Boolean = True
        Dim intPartIDCounter As Integer = 0
        Dim intPartDescriptionCounter As Integer
        Dim intKeywordCounter As Integer = 0
        Dim intCharacterCounter As Integer = 0

        'Setting up temporary array
        Dim intTempCounter As Integer
        Dim strTempSelectedIndex(1000) As Integer
        Dim intTempUpperLimit As Integer

        'Setting navigation buttons
        btnBack.Enabled = False
        btnNext.Enabled = False

        'Setting up data validation
        strKeywordForSearch = txtEnterCableDigits.Text
        blnFatalError = TheInputDataValidation.VerifyIntegerData(strKeywordForSearch)

        'Output to user if validation fails
        If blnFatalError = True Then
            txtEnterCableDigits.Text = ""
            MessageBox.Show("The Cable Digits Were Not Entered", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        'clearing the global array
        For intTempCounter = 0 To intTempUpperLimit
            mintCableSelectedIndex(intTempCounter) = -1
        Next

        'Setting up the global array
        intTempUpperLimit = mintCableSelectedUpperLimit
        intKeywordLengthForSearch = strKeywordForSearch.Length - 1
        mintCableSelectedCounter = 0
        mintCableSelectedUpperLimit = 0

        'Copying the global array
        For intPartIDCounter = 0 To intTempUpperLimit

            'Incrementing the combo box
            cboPartID.SelectedIndex = mintCableSelectedIndex(intPartIDCounter)

            'Setting up for the keyword search
            intKeywordLengthFromTable = txtCableDescription.Text.Length - 1
            chaKeywordArray = txtCableDescription.Text.ToCharArray
            intCharacterCounter = intKeywordLengthForSearch

            'Beginning Second Loop
            If intKeywordLengthForSearch <= intKeywordLengthFromTable Then

                'Beginning loop for characters within the string
                For intPartDescriptionCounter = 0 To intKeywordLengthFromTable

                    For intKeywordCounter = intPartDescriptionCounter To intCharacterCounter

                        'Setting the character array
                        strKeywordFromTable = strKeywordFromTable + chaKeywordArray(intKeywordCounter)

                    Next

                    'Setting up for the next loop
                    If intCharacterCounter < intKeywordLengthFromTable Then
                        intCharacterCounter = intCharacterCounter + 1
                    End If

                    'Comparing the string
                    If strKeywordForSearch = strKeywordFromTable Then
                        mintCableSelectedIndex(mintCableSelectedCounter) = intPartIDCounter
                        mintCableSelectedCounter += 1
                        blnItemNotFound = False
                    End If

                    strKeywordFromTable = ""
                Next

            End If
        Next

        If blnItemNotFound = True Then
            MessageBox.Show("Information Entered Was Not Found", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtEnterCableDigits.Text = ""
            Exit Sub
        End If

        'Setting up the limiting factors
        mintCableSelectedUpperLimit = mintCableSelectedCounter - 1
        mintCableSelectedCounter = 0
        cboPartID.SelectedIndex = mintCableSelectedIndex(0)

        'Setting the navigation buttons
        If mintCableSelectedUpperLimit > 0 Then
            btnNext.Enabled = True
        End If

        'Clears the text box
        txtEnterCableDigits.Text = ""

    End Sub
End Class