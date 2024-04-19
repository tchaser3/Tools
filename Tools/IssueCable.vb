'Title:         Issue Cable Form
'Date:          1/24/14
'Author:        Terry Holmes

'Description:   This form is used to issue cable

Option Strict On

Public Class IssueCable

    Dim TheInputDataValidation As New InputDataValidation

    Private addingBoolean As Boolean = False
    Private editingBoolean As Boolean = False
    Private previousSelectedIndex As Integer
    Dim mintNumuberOfRecords As Integer

    Dim LogDateTime As Date = DateAndTime.Now
    Dim strLogDateTime As String

    'Setting global variable
    Dim mintProjectSelectedIndex(5000) As Integer
    Dim mintProjectSelectedIndexCounter As Integer = 0
    Dim mintProjectSelectedIndexUpperLimit As Integer

    Dim mintCableTypeComboBoxUpperLimit As Integer = 0
    Dim mintReelTransactionID As Integer
    Friend mstrCableCategory As String

    Dim mintManagerSelectedIndex(1000) As Integer
    Dim mintManagerSelectedIndexCounter As Integer
    Dim mintManagerSelectedIndexUpperLimit As Integer

    Dim mintTechnicianSelectedIndex(5000) As Integer
    Dim mintTechnicianSelectedIndexCounter As Integer
    Dim mintTechnicianSelectedIndexUpperLimit As Integer

    Dim mintCableSelectedIndex(5000) As Integer
    Dim mintCableSelectedIndexCounter As Integer
    Dim mintCableSelectedIndexUpperLimit As Integer

    Dim mintWarehouseSelectedIndex(1000) As Integer
    Dim mintWarehouseSelectedIndexCounter As Integer
    Dim mintWarehouseSelectedIndexUpperLimit As Integer

    'Variables for Updating other Tables
    Friend mintInternalProjectID As Integer
    Friend mintTransactionID As Integer
    Friend mstrTWProjectID As String
    Friend mintTechnicianID As Integer
    Friend mintFootagePulled As Integer
    Friend mintManagerID As Integer
    Friend mstrReelID As String
    Friend mintWarehouseID As Integer
    Friend mintWarehouseEmployeeID As Integer
    Friend mstrPartNumber As String
    Friend mdatDate As Date
    Friend mstrNotes As String
    Friend mblnResetPartNumber As Boolean = False
    Friend mblnFootageEqualToZero As Boolean = False

    'Setting Boolean Variables
    Friend mblnReelIDNotFound As Boolean
    Friend mblnFootageGreaterThanReelAmout As Boolean

    'Setting Up Data Controls
    Private TheInternalProjectsDataSet As InternalProjectsDataSet
    Private TheInternalProjectsDataTier As InternalProjectsDataTier
    Private WithEvents TheInternalProjectsBindingSource As BindingSource

    'Setting up Employee Information
    Private TheEmployeeDataSet As EmployeeDataSet
    Private TheEmployeeDataTier As EmployeeDataTier
    Private WithEvents TheEmployeeBindingSource As BindingSource

    'Setting Variables for the Cable Boxes
    Private ThePartNumberDataSet As PartNumberDataSet
    Private ThePartNumberDataTier As PartDataTier
    Private WithEvents ThePartNumberBindingSource As BindingSource

    'Setting Variables for Issuing Cable
    Private TheIssueCableDataSet As IssueCableDataSet
    Private TheIssueCableDataTier As CableDataTier
    Private WithEvents TheIssueCableBindingSource As BindingSource

    Friend mblnIssuedCompleteReel As Boolean

    Private Sub btnInventoryMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInventoryMenu.Click

        'This Button will call the Administrative Menu
        InventoryMenu.Show()
        Me.Close()

    End Sub
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        'Closes the Program
        CloseTheProgram.ShowDialog()

    End Sub

    Private Sub btnMainMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMainMenu.Click

        'Calls the Main Menu
        MainMenu.Show()
        Me.Close()

    End Sub

    Private Sub setComboBoxBinding()

        With Me.cboTransactionID
            If (addingBoolean Or editingBoolean) Then
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.OnValidation
                .DropDownStyle = ComboBoxStyle.Simple
            Else
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.Never
                .DropDownStyle = ComboBoxStyle.DropDownList
            End If
        End With

        With Me.cboPartID
            If (addingBoolean Or editingBoolean) Then
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.OnValidation
                .DropDownStyle = ComboBoxStyle.Simple
            Else
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.Never
                .DropDownStyle = ComboBoxStyle.DropDownList
            End If
        End With

        With Me.cboTechnicianID
            If (addingBoolean Or editingBoolean) Then
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.OnValidation
                .DropDownStyle = ComboBoxStyle.Simple
            Else
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.Never
                .DropDownStyle = ComboBoxStyle.DropDownList
            End If
        End With

        With Me.cboManagerID
            If (addingBoolean Or editingBoolean) Then
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.OnValidation
                .DropDownStyle = ComboBoxStyle.Simple
            Else
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.Never
                .DropDownStyle = ComboBoxStyle.DropDownList
            End If
        End With

    End Sub
    Private Sub setControlsReadOnly(ByVal valueBoolean As Boolean)

        'This will set controls either to read only or not
        With Me

        End With

    End Sub
    Private Sub btnCableMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCableMenu.Click

        'launches the Cable Menu
        CableMenu.Show()
        Me.Close()

    End Sub

    Private Sub IssueCable_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Setting Local Variables
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim strGroupFromTable As String

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

            'Setting the Manager relationship for the Combo Box
            With cboManagerID
                .DataSource = TheEmployeeBindingSource
                .DisplayMember = "EmployeeID"
                .DataBindings.Add("text", TheEmployeeBindingSource, "EmployeeID", False, DataSourceUpdateMode.Never)
            End With

            'Setting the data binding for the text boxes
            txtManagerFirstName.DataBindings.Add("text", TheEmployeeBindingSource, "FirstName")
            txtManagerLastName.DataBindings.Add("text", TheEmployeeBindingSource, "LastName")
            txtManagerGroup.DataBindings.Add("text", TheEmployeeBindingSource, "Group")

            'Setting the Technician relationship for the Combo Box
            With cboTechnicianID
                .DataSource = TheEmployeeBindingSource
                .DisplayMember = "EmployeeID"
                .DataBindings.Add("text", TheEmployeeBindingSource, "EmployeeID", False, DataSourceUpdateMode.Never)
            End With

            'Setting the data binding for the text boxes
            txtTechnicianFirstName.DataBindings.Add("text", TheEmployeeBindingSource, "FirstName")
            txtTechnicianLastName.DataBindings.Add("text", TheEmployeeBindingSource, "LastName")
            txtTechnicianGroup.DataBindings.Add("text", TheEmployeeBindingSource, "Group")

            'Setting the Warehouse Relationship for the controls
            With cboWarehouseID
                .DataSource = TheEmployeeBindingSource
                .DisplayMember = "EmployeeID"
                .DataBindings.Add("text", TheEmployeeBindingSource, "EmployeeID", False, DataSourceUpdateMode.Never)
            End With

            'Setting the data binding for the text boxes
            txtWarehouseFirstName.DataBindings.Add("text", TheEmployeeBindingSource, "FirstName")
            txtWarehouseLastName.DataBindings.Add("text", TheEmployeeBindingSource, "LastName")

        Catch ex As Exception

            'If an exception is thrown, it is rounted here
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        'Setting up Employee and Manager Sections
        Try
            'Setting Global Varible Values
            mintManagerSelectedIndexCounter = 0
            mintManagerSelectedIndexUpperLimit = 0
            mintTechnicianSelectedIndexCounter = 0
            mintTechnicianSelectedIndexUpperLimit = 0

            cboTechnicianID.SelectedIndex = 0
            intNumberOfRecords = cboManagerID.Items.Count - 1
            For intCounter = 0 To intNumberOfRecords

                cboManagerID.SelectedIndex = intCounter
                strGroupFromTable = txtManagerGroup.Text
                If strGroupFromTable = "ADMIN" Or strGroupFromTable = "MANAGERS" Then

                    mintManagerSelectedIndex(mintManagerSelectedIndexCounter) = intCounter
                    mintManagerSelectedIndexCounter = mintManagerSelectedIndexCounter + 1

                End If

            Next

            mintManagerSelectedIndexUpperLimit = mintManagerSelectedIndexCounter - 1
            mintManagerSelectedIndexCounter = 0
            cboManagerID.SelectedIndex = mintManagerSelectedIndex(0)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        'Try - Catch for Cable Information
        Try

            txtReelID.Visible = True

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

            'Setting up the Combo Box
            With cboPartID
                .DataSource = ThePartNumberBindingSource
                .DisplayMember = "PartID"
                .DataBindings.Add("text", ThePartNumberBindingSource, "PartID", False, DataSourceUpdateMode.Never)
            End With

            'Set the rest of the controls
            txtCablePartNumber.DataBindings.Add("text", ThePartNumberBindingSource, "PartNumber")
            txtCableDescription.DataBindings.Add("text", ThePartNumberBindingSource, "Description")
            txtCableJobType.DataBindings.Add("text", ThePartNumberBindingSource, "Type")
            txtCablePartType.DataBindings.Add("text", ThePartNumberBindingSource, "PartType")

        Catch ex As Exception

            'If an exception is thrown, it is rounted here
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        'Try - Catch for Cable Type
        Try

            txtReelID.Visible = True

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
            txtWarehouse.DataBindings.Add("text", TheIssueCableBindingSource, "WarehouseID")
            txtWarehouseEmployeeID.DataBindings.Add("Text", TheIssueCableBindingSource, "WarehouseEmployeeID")
            txtPartNumber.DataBindings.Add("text", TheIssueCableBindingSource, "PartNumber")
            txtDate.DataBindings.Add("text", TheIssueCableBindingSource, "Date")
            txtIssuedReel.DataBindings.Add("text", TheIssueCableBindingSource, "IssuedReel")
            txtNotes.DataBindings.Add("text", TheIssueCableBindingSource, "Notes")

        Catch ex As Exception

            'If an exception is thrown, it is rounted here
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        SetControlsVisible(False)
        btnIssueCable.PerformClick()
        txtInternalProjectID.Text = CStr(Logon.mintInternalProjectID)

    End Sub

    Private Sub btnManagerNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnManagerNext.Click

        'This will allow the Manager Next button to function
        mintManagerSelectedIndexCounter = mintManagerSelectedIndexCounter + 1
        cboManagerID.SelectedIndex = mintManagerSelectedIndex(mintManagerSelectedIndexCounter)

        btnManagerBack.Enabled = True

        If mintManagerSelectedIndexCounter = mintManagerSelectedIndexUpperLimit Then
            btnManagerNext.Enabled = False
        End If

    End Sub

    Private Sub btnManagerBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnManagerBack.Click

        'This will allow the Manager Next button to function
        mintManagerSelectedIndexCounter = mintManagerSelectedIndexCounter - 1
        cboManagerID.SelectedIndex = mintManagerSelectedIndex(mintManagerSelectedIndexCounter)

        btnManagerNext.Enabled = True

        If mintManagerSelectedIndexCounter = 0 Then
            btnManagerBack.Enabled = False
        End If

    End Sub
    Private Sub SetControlsVisible(ByVal valueBoolean As Boolean)

        'Setting Master List
        cboPartID.Visible = valueBoolean
        cboManagerID.Visible = valueBoolean
        cboTechnicianID.Visible = valueBoolean
        cboTransactionID.Visible = valueBoolean

        SetIssueControlsVisible(valueBoolean)
        SetCableTypeButtonsVisible(valueBoolean)
        SetSelectCableVisible(valueBoolean)
        SetSelectTechnicianVisible(valueBoolean)
        SetSelectManagerVisible(valueBoolean)
        SetStartingControlsVisible(valueBoolean)

    End Sub
    Private Sub SetStartingControlsVisible(ByVal valueBoolean As Boolean)

        txtEnterLastName.Visible = valueBoolean

    End Sub
    Private Sub SetIssueControlsVisible(ByVal valueBoolean As Boolean)

        txtInternalProjectID.Visible = valueBoolean
        txtTechnicianID.Visible = valueBoolean
        txtManagerID.Visible = valueBoolean
        txtFootagePulled.Visible = valueBoolean
        txtPartNumber.Visible = valueBoolean
        txtPartNumber.Visible = valueBoolean
        txtReelID.Visible = valueBoolean
        txtDate.Visible = valueBoolean
        txtWarehouse.Visible = valueBoolean
        txtWarehouseEmployeeID.Visible = valueBoolean
        txtNotes.Visible = valueBoolean

    End Sub
    Private Sub SetCableTypeButtonsVisible(ByVal valueBoolean As Boolean)

        rdoCoax.Visible = valueBoolean
        rdoFiber.Visible = valueBoolean
        rdoDropCable.Visible = valueBoolean
        rdoSpecialtyCable.Visible = valueBoolean
        rdoTwistedPair.Visible = valueBoolean

    End Sub
    Private Sub SetSelectCableVisible(ByVal valueBoolean As Boolean)

        txtCablePartNumber.Visible = valueBoolean
        txtCableDescription.Visible = valueBoolean
        txtCableJobType.Visible = valueBoolean
        txtCablePartType.Visible = valueBoolean
        btnBack.Visible = valueBoolean
        btnNext.Visible = valueBoolean
        btnSelectPartNumber.Visible = valueBoolean

    End Sub
    Private Sub SetSelectTechnicianVisible(ByVal valueBoolean As Boolean)

        txtTechnicianFirstName.Visible = valueBoolean
        txtTechnicianLastName.Visible = valueBoolean
        txtTechnicianGroup.Visible = valueBoolean
        btnTechncianBack.Visible = valueBoolean
        btnTechnicianNext.Visible = valueBoolean
        btnTechnicianSearch.Visible = valueBoolean
        btnTechnicianSelect.Visible = valueBoolean

    End Sub
    Private Sub SetSelectManagerVisible(ByVal valueBoolean As Boolean)

        txtManagerFirstName.Visible = valueBoolean
        txtManagerLastName.Visible = valueBoolean
        txtManagerGroup.Visible = valueBoolean
        btnManagerBack.Visible = valueBoolean
        btnManagerNext.Visible = valueBoolean
        btnManagerSelect.Visible = valueBoolean

    End Sub


    Private Sub btnIssueCable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIssueCable.Click

        'Setting local variables
        Dim blnFatalError As Boolean
        Dim intNumberOfRecords As Integer
        Dim strValueForValidation As String
        Dim strErrorMessage As String

        'Setting up if statements
        If btnIssueCable.Text = "Issue Cable" Then  'This routine will run if the user is adding an employee

            'This will Issue the Cable
            SetStartingControlsVisible(True)
            SetIssueControlsVisible(True)

            btnIssueCable.Enabled = False

            With TheIssueCableBindingSource
                .EndEdit()
                .AddNew()
            End With

            'Calling sub-routines and setting call values
            addingBoolean = True
            setComboBoxBinding()
            cboTransactionID.Focus()
            setControlsReadOnly(False)
            setButtonsForEdit()
            If cboTransactionID.SelectedIndex <> -1 Then
                previousSelectedIndex = cboTransactionID.Items.Count - 1
            Else
                previousSelectedIndex = 0
            End If

            'Setting initial Conditions
            'Setting up fields with auto-data to avoid having the user do it.
            cboTransactionID.Visible = True
            mintNumuberOfRecords = cboTransactionID.Items.Count
            intNumberOfRecords = mintNumuberOfRecords + 1000

            txtWarehouseEmployeeID.Text = CStr(Logon.mintEmployeeID)
            txtIssuedReel.Text = "NO"

            mintReelTransactionID = intNumberOfRecords
            Logon.mintReelTransactionID = CInt(mintReelTransactionID)

            strLogDateTime = CStr(LogDateTime)
            txtDate.Text = strLogDateTime

            CableTransactionID.Show()

            mintReelTransactionID = CInt(Logon.mintReelTransactionID)

            cboTransactionID.Text = CStr(mintReelTransactionID)

            SetSelectWarehouseVisible(True)
            FindWarehouse()

            btnIssueCable.Enabled = False
        Else

            'This section will run when the user selects to save the record
            mblnFootageGreaterThanReelAmout = False

            IssuedCompleteReel.ShowDialog()

            If mblnIssuedCompleteReel = True Then
                txtIssuedReel.Text = "YES"
                txtFootagePulled.Text = "100000"
            Else
                txtIssuedReel.Text = "NO"
            End If

            'Performing Data Validation
            strValueForValidation = txtFootagePulled.Text
            strErrorMessage = "The Footage Pulled is not an Integer"
            blnFatalError = TheInputDataValidation.VerifyIntegerData(strValueForValidation)
            If blnFatalError = False Then
                strValueForValidation = txtReelID.Text
                strErrorMessage = "The Reel ID was not Entered"
                blnFatalError = TheInputDataValidation.VerifyTextData(strValueForValidation)
                If blnFatalError = False Then
                    strValueForValidation = txtIssuedReel.Text
                    strErrorMessage = "The Issued Reel is not Yes or No"
                    blnFatalError = TheInputDataValidation.VerifyYesNoData(strValueForValidation)
                End If
            End If

            If blnFatalError = True Then
                MessageBox.Show(strErrorMessage, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            mintTransactionID = CInt(cboTransactionID.Text)
            mintInternalProjectID = CInt(txtInternalProjectID.Text)
            mintTechnicianID = CInt(txtTechnicianID.Text)
            mintFootagePulled = CInt(txtFootagePulled.Text)
            mintManagerID = CInt(txtManagerID.Text)
            mstrReelID = CStr(txtReelID.Text)
            mintWarehouseID = CInt(txtWarehouse.Text)
            mintWarehouseEmployeeID = CInt(txtWarehouseEmployeeID.Text)
            mstrPartNumber = CStr(txtPartNumber.Text)
            mdatDate = CDate(txtDate.Text)
            mstrNotes = CStr(txtNotes.Text)

            IssueCableTableUpdate.Show()

            If mblnIssuedCompleteReel = True Then
                txtFootagePulled.Text = CStr(mintFootagePulled)
            End If

            'If statement to see if the reel was found
            If mblnReelIDNotFound = True Then

                ResetCableandPartNumber.ShowDialog()

                If mblnResetPartNumber = True Then
                    SetCableTypeButtonsVisible(True)
                    Exit Sub
                ElseIf mblnResetPartNumber = False Then
                    Exit Sub
                End If

            End If

            If mblnFootageGreaterThanReelAmout = True Then
                MessageBox.Show("The Footage Entered is greater that the Footage On Record", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            AddManagerQueueTransaction.Show()

            Try
                TheIssueCableBindingSource.EndEdit()
                TheIssueCableDataTier.UpdateIssueCableDB(TheIssueCableDataSet)
                addingBoolean = False
                editingBoolean = False
                setControlsReadOnly(True)
                ResetButtonAfterEditing()
                setComboBoxBinding()
                cboTransactionID.SelectedIndex = previousSelectedIndex
                ContineIssuseCable.Show()
                Me.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "There is a problem", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If

    End Sub
    Private Sub setButtonsForEdit()

        'Setting the buttons for editing
        btnIssueCable.Text = "Save"
        btnEdit.Enabled = False
        btnMainMenu.Enabled = False

    End Sub
    Private Sub ResetButtonAfterEditing()

        'Setting the buttons for adding a record
        btnIssueCable.Text = "Issue Cable"
        btnEdit.Enabled = True
        btnMainMenu.Enabled = True

    End Sub
    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click

        'Sets the buttons up to edit a record
        setControlsReadOnly(False)
        setButtonsForEdit()
        previousSelectedIndex = cboTransactionID.SelectedIndex
        setComboBoxBinding()

    End Sub
    Private Sub FindCableCategoryPartNumbers()

        'Setting up local variables
        cboPartID.SelectedIndex = 0
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim strCableCategoryFromTable As String
        Dim blnCableCategoryNotFound As Boolean = True
        Dim strCablePartType As String = ""

        intNumberOfRecords = cboPartID.Items.Count - 1
        btnNext.Enabled = False
        btnBack.Enabled = False
        mintCableSelectedIndexCounter = 0
        mintCableSelectedIndexUpperLimit = 0

        For intCounter = 0 To intNumberOfRecords

            cboPartID.SelectedIndex = intCounter
            strCableCategoryFromTable = txtCableJobType.Text
            strCablePartType = txtCablePartType.Text

            If mstrCableCategory = strCableCategoryFromTable Then
                If strCablePartType = "CABLE" Then

                    mintCableSelectedIndex(mintCableSelectedIndexCounter) = intCounter
                    mintCableSelectedIndexCounter = mintCableSelectedIndexCounter + 1
                    blnCableCategoryNotFound = False

                End If
            End If
        Next

        If blnCableCategoryNotFound = True Then
            MessageBox.Show("Cable Category Not Found", "Please Choose Again", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        mintCableSelectedIndexUpperLimit = mintCableSelectedIndexCounter - 1
        mintCableSelectedIndexCounter = 0
        cboPartID.SelectedIndex = mintCableSelectedIndex(0)

        If mintCableSelectedIndexUpperLimit = 0 Then
            btnNext.Enabled = False
        ElseIf mintCableSelectedIndexUpperLimit > 0 Then
            btnNext.Enabled = True
        End If
        btnSelectPartNumber.Enabled = True

    End Sub

    Private Sub rdoCoax_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoCoax.CheckedChanged

        SetSelectCableVisible(True)
        mstrCableCategory = "COAX"

        FindCableCategoryPartNumbers()

    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click

        'This is used for the cabley type next box
        mintCableSelectedIndexCounter = mintCableSelectedIndexCounter + 1
        cboPartID.SelectedIndex = mintCableSelectedIndex(mintCableSelectedIndexCounter)

        btnBack.Enabled = True

        If mintCableSelectedIndexCounter = mintCableSelectedIndexUpperLimit Then
            btnNext.Enabled = False
        End If

    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click

        'This is used for the cabley type next box
        mintCableSelectedIndexCounter = mintCableSelectedIndexCounter - 1
        cboPartID.SelectedIndex = mintCableSelectedIndex(mintCableSelectedIndexCounter)

        btnNext.Enabled = True

        If mintCableSelectedIndexCounter = 0 Then
            btnBack.Enabled = False
        End If

    End Sub

    Private Sub rdoFiber_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoFiber.CheckedChanged

        SetSelectCableVisible(True)
        mstrCableCategory = "FIBER"

        FindCableCategoryPartNumbers()

    End Sub

    Private Sub rdoDropCable_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoDropCable.CheckedChanged

        SetSelectCableVisible(True)
        mstrCableCategory = "DROP CABLE"

        FindCableCategoryPartNumbers()

    End Sub

    Private Sub rdoTwistedPair_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoTwistedPair.CheckedChanged

        SetSelectCableVisible(True)
        mstrCableCategory = "TWISTED PAIR"

        FindCableCategoryPartNumbers()

    End Sub

    Private Sub rdoSpecialtyCable_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoSpecialtyCable.CheckedChanged

        SetSelectCableVisible(True)
        mstrCableCategory = "SPECIALTY CABLE"

        FindCableCategoryPartNumbers()

    End Sub

    Private Sub btnSelectPartNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectPartNumber.Click

        txtPartNumber.Text = txtCablePartNumber.Text

        If mblnResetPartNumber = False Then

            SetSelectTechnicianVisible(True)

        End If

        SetSelectCableVisible(False)
        SetCableTypeButtonsVisible(False)
        cboTechnicianID.Visible = False
        txtTechnicianFirstName.Visible = False
        txtTechnicianLastName.Visible = False
        txtTechnicianGroup.Visible = False
        btnTechnicianSearch.Enabled = True
        txtEnterLastName.Focus()
    End Sub

    Private Sub btnTechnicianSearch_Click(sender As System.Object, e As System.EventArgs) Handles btnTechnicianSearch.Click

        Dim blnFatalError As Boolean
        Dim strValueForValidation As String
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim strLastNameForSearch As String
        Dim strLastNameFromTable As String
        Dim blnNameNotFound As Boolean = True

        txtTechnicianFirstName.Visible = True
        txtTechnicianLastName.Visible = True
        txtTechnicianGroup.Visible = True

        strValueForValidation = txtEnterLastName.Text
        blnFatalError = TheInputDataValidation.VerifyTextData(strValueForValidation)

        If blnFatalError = True Then
            MessageBox.Show("The Technician's Last Name was not Entered", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        intNumberOfRecords = cboTechnicianID.Items.Count - 1
        strLastNameForSearch = txtEnterLastName.Text

        mintTechnicianSelectedIndexCounter = 0
        mintTechnicianSelectedIndexUpperLimit = 0

        For intCounter = 0 To intNumberOfRecords

            cboTechnicianID.SelectedIndex = intCounter
            strLastNameFromTable = txtTechnicianLastName.Text

            If strLastNameForSearch = strLastNameFromTable Then

                blnNameNotFound = False
                mintTechnicianSelectedIndex(mintTechnicianSelectedIndexCounter) = intCounter
                mintTechnicianSelectedIndexCounter = mintTechnicianSelectedIndexCounter + 1

            End If

        Next

        If blnNameNotFound = True Then
            MessageBox.Show("Name Entered is not Found", "Please Try Again", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        mintTechnicianSelectedIndexUpperLimit = mintTechnicianSelectedIndexCounter - 1
        mintTechnicianSelectedIndexCounter = 0
        cboTechnicianID.SelectedIndex = mintTechnicianSelectedIndex(0)

        If mintTechnicianSelectedIndexUpperLimit > 0 Then
            btnTechnicianNext.Enabled = True
        End If

        btnTechnicianSelect.Enabled = True

    End Sub

    
    Private Sub txtEnterFirstName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)

        If e.KeyCode = Keys.Enter Then
            txtEnterLastName.Focus()
        End If

    End Sub

    Private Sub txtEnterLastName_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtEnterLastName.KeyDown

        If btnTechnicianSearch.Enabled = True Then
            If e.KeyCode = Keys.Enter Then
                btnTechnicianSearch.PerformClick()
            End If
        End If

    End Sub

    Private Sub btnTechncianBack_Click(sender As System.Object, e As System.EventArgs) Handles btnTechncianBack.Click

        mintTechnicianSelectedIndexCounter = mintTechnicianSelectedIndexCounter - 1
        cboTechnicianID.SelectedIndex = mintTechnicianSelectedIndex(mintTechnicianSelectedIndexCounter)

        btnTechnicianNext.Enabled = True

        If mintTechnicianSelectedIndexCounter = 0 Then
            btnTechncianBack.Enabled = False
        End If

    End Sub

    Private Sub btnTechnicianNext_Click(sender As System.Object, e As System.EventArgs) Handles btnTechnicianNext.Click

        mintTechnicianSelectedIndexCounter = mintTechnicianSelectedIndexCounter + 1
        cboTechnicianID.SelectedIndex = mintTechnicianSelectedIndex(mintTechnicianSelectedIndexCounter)

        btnTechncianBack.Enabled = True

        If mintTechnicianSelectedIndexCounter = mintTechnicianSelectedIndexUpperLimit Then
            btnTechnicianNext.Enabled = False
        End If

    End Sub

    Private Sub btnTechnicianSelect_Click(sender As System.Object, e As System.EventArgs) Handles btnTechnicianSelect.Click

        'This will load up the Technician ID Text Box
        txtTechnicianID.Text = CStr(cboTechnicianID.Text)
        SetSelectManagerVisible(True)


        'Disabling the Technician buttons
        btnTechncianBack.Enabled = False
        btnTechnicianNext.Enabled = False
        btnTechnicianSearch.Enabled = False
        btnTechnicianSelect.Enabled = False
        SetSelectTechnicianVisible(False)

        FindManagers()


    End Sub

    Private Sub FindManagers()

        Dim intNumberOfRecords As Integer
        Dim intCounter As Integer
        Dim strGroupFromTable As String
        Dim blnGroupNotFound As Boolean = True

        'Clearing Name Entry Textboxes
        txtEnterLastName.Text = ""


        intNumberOfRecords = cboManagerID.Items.Count - 1
        mintManagerSelectedIndexCounter = 0
        mintManagerSelectedIndexUpperLimit = 0

        For intCounter = 0 To intNumberOfRecords

            'Find all Managers or Admins for issuing parts
            cboManagerID.SelectedIndex = intCounter
            strGroupFromTable = txtManagerGroup.Text

            If strGroupFromTable = "MANAGERS" Or strGroupFromTable = "ADMIN" Then

                blnGroupNotFound = False
                mintManagerSelectedIndex(mintManagerSelectedIndexCounter) = intCounter
                mintManagerSelectedIndexCounter = mintManagerSelectedIndexCounter + 1

            End If
        Next

        If blnGroupNotFound = True Then
            MessageBox.Show("No Managers or Admins were found", "This is not Possible", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        mintManagerSelectedIndexUpperLimit = mintManagerSelectedIndexCounter - 1
        mintManagerSelectedIndexCounter = 0
        cboManagerID.SelectedIndex = mintManagerSelectedIndex(0)

        btnManagerSelect.Enabled = True

        If mintManagerSelectedIndexUpperLimit > 0 Then
            btnManagerNext.Enabled = True
        End If

    End Sub

    Private Sub btnManagerSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnManagerSelect.Click

        'This will select the Manager that assigned the cable
        txtManagerID.Text = CStr(cboManagerID.Text)
        SetSelectManagerVisible(False)
        btnIssueCable.Enabled = True

    End Sub
    Private Sub FindWarehouse()

        'Defining Local Variables
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim strWarehouseLastNameFromTable As String
        Dim blnWarehouseNotFound As Boolean = True

        'Setting initial values
        intNumberOfRecords = cboWarehouseID.Items.Count - 1
        mintWarehouseSelectedIndexCounter = 0
        mintWarehouseSelectedIndexUpperLimit = 0

        'Performing Loop to find warehouses
        For intCounter = 0 To intNumberOfRecords

            cboWarehouseID.SelectedIndex = intCounter
            strWarehouseLastNameFromTable = txtWarehouseLastName.Text

            'If statement to see if the warehouse is found
            If strWarehouseLastNameFromTable = "PARTS" Then

                blnWarehouseNotFound = False
                mintWarehouseSelectedIndex(mintWarehouseSelectedIndexCounter) = intCounter
                mintWarehouseSelectedIndexCounter = mintWarehouseSelectedIndexCounter + 1

            End If

        Next

        If blnWarehouseNotFound = True Then
            MessageBox.Show("No Warehouses present", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        'Setting the Combo Box and Text Boxes for warehouse
        mintWarehouseSelectedIndexUpperLimit = mintWarehouseSelectedIndexCounter - 1
        mintWarehouseSelectedIndexCounter = 0
        cboWarehouseID.SelectedIndex = mintWarehouseSelectedIndex(0)

        If mintWarehouseSelectedIndexUpperLimit > 0 Then
            btnWarehouseNext.Enabled = True
        End If

        btnWarehouseSelect.Enabled = True

    End Sub

    Private Sub btnWarehouseNext_Click(sender As System.Object, e As System.EventArgs) Handles btnWarehouseNext.Click

        mintWarehouseSelectedIndexCounter = mintWarehouseSelectedIndexCounter + 1
        cboWarehouseID.SelectedIndex = mintWarehouseSelectedIndex(mintWarehouseSelectedIndexCounter)

        btnWarehouseBack.Enabled = True

        If mintWarehouseSelectedIndexCounter = mintWarehouseSelectedIndexUpperLimit Then
            btnWarehouseNext.Enabled = False
        End If

    End Sub

    Private Sub btnWarehouseBack_Click(sender As System.Object, e As System.EventArgs) Handles btnWarehouseBack.Click

        mintWarehouseSelectedIndexCounter = mintWarehouseSelectedIndexCounter - 1
        cboWarehouseID.SelectedIndex = mintWarehouseSelectedIndex(mintWarehouseSelectedIndexCounter)

        btnWarehouseNext.Enabled = True

        If mintWarehouseSelectedIndexCounter = 0 Then
            btnWarehouseBack.Enabled = False
        End If

    End Sub

    Private Sub SetSelectWarehouseVisible(ByVal valueBoolean As Boolean)

        txtWarehouseFirstName.Visible = valueBoolean
        txtWarehouseLastName.Visible = valueBoolean
        btnWarehouseBack.Visible = valueBoolean
        btnWarehouseNext.Visible = valueBoolean
        btnWarehouseSelect.Visible = valueBoolean

    End Sub

    Private Sub btnWarehouseSelect_Click(sender As System.Object, e As System.EventArgs) Handles btnWarehouseSelect.Click

        txtWarehouse.Text = cboWarehouseID.Text
        Logon.mintWarehouseID = CInt(cboWarehouseID.Text)
        SetCableTypeButtonsVisible(True)
        SetSelectWarehouseVisible(False)

    End Sub
End Class