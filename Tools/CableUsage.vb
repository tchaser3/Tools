'Title:         Cable Usage
'Date:          5/27/14
'Author:        Terry Holmes

'Description:   This form is for reporting the cable usage

Option Strict On

Public Class CableUsage

    Dim TheInputDataValidation As New InputDataValidation

    Private addingBoolean As Boolean = False
    Private editingBoolean As Boolean = False
    Private previousSelectedIndex As Integer
    Dim mintNumuberOfRecords As Integer

    Dim LogDateTime As Date = DateAndTime.Now
    Dim strLogDateTime As String

    'Setting up Employee Information
    Private TheEmployeeDataSet As EmployeeDataSet
    Private TheEmployeeDataTier As EmployeeDataTier
    Private WithEvents TheEmployeeBindingSource As BindingSource

    Private TheManagerDataSet As EmployeeDataSet
    Private TheManagerDataTier As EmployeeDataTier
    Private WithEvents TheManagerBindingSource As BindingSource

    'Setting Variables for the Cable Type Boxes
    Private ThePartNumberDataSet As PartNumberDataSet
    Private ThePartNumberDataTier As PartDataTier
    Private WithEvents ThePartNumberBindingSource As BindingSource

    'Setting Variables for Issuing Cable
    Private TheIssueCableDataSet As IssueCableDataSet
    Private TheIssueCableDataTier As CableDataTier
    Private WithEvents TheIssueCableBindingSource As BindingSource

    'Setting Variables for Issuing Cable
    Private TheCableUsageDataSet As CableUsageDataSet
    Private TheCableUsageDataTier As CableDataTier
    Private WithEvents TheCableUsageBindingSource As BindingSource

    Private TheManagerQueueDataSet As ManagerQueueDataSet
    Private TheManagerQueueDataTier As CableDataTier
    Private WithEvents TheManagerQueueBindingSource As BindingSource

    'Setting up array for Issue Cable Transactions and Project ID
    Dim mintIssueCableCounter As Integer
    Dim mintIssueCableSelectedIndex(1000) As Integer
    Dim mintIssueCableUpperLimit As Integer

    Friend mstrCabledPulled As String
    Friend mblnUseFootagePulled As Boolean

    Private Sub btnInventoryMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInventoryMenu.Click

        'This Button will call the Administrative Menu
        ClearAllDataBindings()
        InventoryMenu.Show()
        Me.Close()

    End Sub
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        'Closes the Program
        CloseTheProgram.ShowDialog()

    End Sub

    Private Sub btnMainMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMainMenu.Click

        'Calls the Main Menu
        ClearAllDataBindings()
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

        With Me.cboEmployeeID
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

    Private Sub btnCableMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCableMenu.Click

        'launches the Cable Menu
        ClearAllDataBindings()
        CableMenu.Show()
        Me.Close()

    End Sub

    Private Sub CableUsage_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Setting Local Variables
        Dim intNumberOfRecords As Integer
        Dim intCounter As Integer
        Dim intProjectIDFromTable As Integer
        Dim intProjectIDForSearch As Integer
        Dim blnNoTransactionsFound As Boolean = True
        Dim intCurrentFootage As Integer

        SetDataBindingsForCableIssue()

        'Loop to Find Project 
        intNumberOfRecords = cboTransactionID.Items.Count - 1
        mintIssueCableCounter = 0
        intProjectIDForSearch = CInt(Logon.mintInternalProjectID)

        For intCounter = 0 To intNumberOfRecords

            cboTransactionID.SelectedIndex = intCounter
            intProjectIDFromTable = CInt(txtInternalProjectID.Text)
            intCurrentFootage = CInt(txtFootagePulled.Text)

            If intProjectIDForSearch = intProjectIDFromTable Then
                If intCurrentFootage > 0 Then

                    mintIssueCableSelectedIndex(mintIssueCableCounter) = intCounter
                    mintIssueCableCounter = mintIssueCableCounter + 1
                    blnNoTransactionsFound = False
                End If
            End If

        Next

        If blnNoTransactionsFound = True Then
            MakeControlsInvisble()
            MessageBox.Show("No Cable Transactions are found for this project", "Thank You", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            btnIssueSelect.Enabled = False
        Else
            mintIssueCableUpperLimit = mintIssueCableCounter - 1
            mintIssueCableCounter = 0
            cboTransactionID.SelectedIndex = mintIssueCableSelectedIndex(0)

            If mintIssueCableUpperLimit > 0 Then
                btnIssueCableNext.Enabled = True
            End If
        End If

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

        Catch ex As Exception
            'If an exception is thrown, it is rounted here
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        FindManager()

        'Try Catch for the Part Number
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

            'Setting up the rest of the controls
            txtCablePartNumber.DataBindings.Add("text", ThePartNumberBindingSource, "PartNumber")
            txtCableDescription.DataBindings.Add("text", ThePartNumberBindingSource, "Description")
            txtCableJobType.DataBindings.Add("text", ThePartNumberBindingSource, "Type")
            txtCablePartType.DataBindings.Add("text", ThePartNumberBindingSource, "PartType")

        Catch ex As Exception
            'If an exception is thrown, it is rounted here
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


        FindCablePartNumber()

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

        FindEmployee()

    End Sub

    Private Sub btnIssueCableNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIssueCableNext.Click

        mintIssueCableCounter = mintIssueCableCounter + 1
        cboTransactionID.SelectedIndex = mintIssueCableSelectedIndex(mintIssueCableCounter)

        btnIssueCableBack.Enabled = True

        If mintIssueCableCounter = mintIssueCableUpperLimit Then
            btnIssueCableNext.Enabled = False
        End If

        FindManager()
        FindCablePartNumber()
        FindEmployee()

    End Sub

    Private Sub btnIssueCableBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIssueCableBack.Click

        mintIssueCableCounter = mintIssueCableCounter - 1
        cboTransactionID.SelectedIndex = mintIssueCableSelectedIndex(mintIssueCableCounter)

        btnIssueCableNext.Enabled = True

        If mintIssueCableCounter = 0 Then
            btnIssueCableBack.Enabled = False
        End If

        FindManager()
        FindCablePartNumber()
        FindEmployee()

    End Sub
    Private Sub FindManager()

        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim intManagerIDForSearch As Integer
        Dim intManagerIDFromTable As Integer
        Dim intSelectedIndex As Integer

        intNumberOfRecords = cboManagerID.Items.Count - 1
        intManagerIDForSearch = CInt(txtManagerID.Text)

        For intCounter = 0 To intNumberOfRecords

            cboManagerID.SelectedIndex = intCounter
            intManagerIDFromTable = CInt(cboManagerID.Text)

            If intManagerIDForSearch = intManagerIDFromTable Then
                intSelectedIndex = intCounter
            End If

        Next

        cboManagerID.SelectedIndex = intSelectedIndex

    End Sub
    Private Sub FindCablePartNumber()

        'Setting local variables
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim intSelectedIndex As Integer
        Dim strPartNumberForSearch As String
        Dim strPartNumberFromTable As String

        'Setting Up Search
        intNumberOfRecords = cboPartID.Items.Count - 1
        strPartNumberForSearch = txtPartNumber.Text

        'Peforming Loop
        For intCounter = 0 To intNumberOfRecords

            cboPartID.SelectedIndex = intCounter
            strPartNumberFromTable = txtCablePartNumber.Text

            If strPartNumberForSearch = strPartNumberFromTable Then
                intSelectedIndex = intCounter
            End If
        Next

        'Setting selected Index of the Combo Box
        cboPartID.SelectedIndex = intSelectedIndex

    End Sub
    Private Sub FindEmployee()

        'Setting Local Variables
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim intSelectedIndex As Integer
        Dim intEmployeeIDForSearch As Integer
        Dim intEmployeeIDFromTable As Integer

        'Setting up variables for the loop
        intNumberOfRecords = cboEmployeeID.Items.Count - 1
        intEmployeeIDForSearch = CInt(txtTechnicianID.Text)

        'Performing Loop
        For intCounter = 0 To intNumberOfRecords

            'Getting information from the table
            cboEmployeeID.SelectedIndex = intCounter
            intEmployeeIDFromTable = CInt(cboEmployeeID.Text)

            'Doing compare
            If intEmployeeIDForSearch = intEmployeeIDFromTable Then
                intSelectedIndex = intCounter
            End If
        Next

        'Setting Selected Index
        cboEmployeeID.SelectedIndex = intSelectedIndex

    End Sub

    Private Sub ClearCableIssueDataBindings()

        'This will clear the Issue and Cable Usage Areas
        cboTransactionID.DataBindings.Clear()
        txtInternalProjectID.DataBindings.Clear()
        txtTechnicianID.DataBindings.Clear()
        txtFootagePulled.DataBindings.Clear()
        txtManagerID.DataBindings.Clear()
        txtReelID.DataBindings.Clear()
        txtPartNumber.DataBindings.Clear()
        txtDate.DataBindings.Clear()
        txtWarehouseID.DataBindings.Clear()

    End Sub
    Private Sub SetDataBindingsForCableIssue()

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
            txtWarehouseID.DataBindings.Add("text", TheIssueCableBindingSource, "WarehouseID")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "There is a Problem", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub SetDataBindingsForCableUsage()

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
            txtTechnicianID.DataBindings.Add("text", TheCableUsageBindingSource, "TechnicianID")
            txtFootagePulled.DataBindings.Add("text", TheCableUsageBindingSource, "FootageUsed")
            txtManagerID.DataBindings.Add("text", TheCableUsageBindingSource, "ManagerID")
            txtReelID.DataBindings.Add("Text", TheCableUsageBindingSource, "ReelID")
            txtPartNumber.DataBindings.Add("text", TheCableUsageBindingSource, "PartNumber")
            txtDate.DataBindings.Add("text", TheCableUsageBindingSource, "DateReported")
            txtWarehouseID.DataBindings.Add("text", TheCableUsageBindingSource, "WarehouseID")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "There is a Problem", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub ClearAllDataBindings()

        'Clears All Data Bindings
        ClearCableIssueDataBindings()
        cboEmployeeID.DataBindings.Clear()
        cboManagerID.DataBindings.Clear()
        cboPartID.DataBindings.Clear()
        txtCablePartNumber.DataBindings.Clear()
        txtCableDescription.DataBindings.Clear()
        txtEmployeeFirstName.DataBindings.Clear()
        txtEmployeeLastName.DataBindings.Clear()
        txtManagerFirstName.DataBindings.Clear()
        txtManagerLastName.DataBindings.Clear()

    End Sub
    Private Sub MakeControlsInvisble()

        'This will make all controls invisible
        btnAssignUsage.Visible = False
        btnIssueSelect.Visible = False
        btnIssueCableBack.Visible = False
        btnIssueCableNext.Visible = False
        gboFootagePulled.Visible = False
        txtCablePartNumber.Visible = False
        txtCableDescription.Visible = False
        txtDate.Visible = False
        txtEmployeeFirstName.Visible = False
        txtEmployeeLastName.Visible = False
        txtManagerFirstName.Visible = False
        txtManagerID.Visible = False
        txtManagerLastName.Visible = False
        txtFootagePulled.Visible = False
        txtInternalProjectID.Visible = False
        txtPartNumber.Visible = False
        txtReelID.Visible = False
        txtTechnicianID.Visible = False

    End Sub

    Private Sub btnAssignUsage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAssignUsage.Click

        'This sub routine will first subtract the reportage usage from the issue cable control
        'Then remove the data binding and bind the controls to the Cable Usage Binding Sourse
        'Then copy the correct information over to the Cable Usage Data Set

        'Setting Local Variables
        Dim intInternalProjectIDForSearch As Integer
        Dim intInternalProjectIDFromTable As Integer
        Dim intManagerIDForSearch As Integer
        Dim intManagerIDFromTable As Integer
        Dim intFootagePulled As Integer
        Dim intFootageUsed As Integer
        Dim intFootageLeft As Integer
        Dim intFootageFromTable As Integer
        Dim intTechnicianIDForSearch As Integer
        Dim intTechnicianIDFromTable As Integer
        Dim strReelIDForSearch As String
        Dim strReelIDFromTable As String
        Dim strPartNumberForSearch As String
        Dim strPartNumberFromTable As String
        Dim strValueForValidation As String
        Dim blnFatalError As Boolean = False
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim intSelectedIndex As Integer
        Dim intWarehouseID As Integer

        strValueForValidation = txtFootageUsed.Text
        blnFatalError = TheInputDataValidation.VerifyIntegerData(strValueForValidation)

        If blnFatalError = True Then
            MessageBox.Show("Footage Entered Is Not An Integer", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        'Doing the Math for Footage Used
        intFootagePulled = CInt(txtFootagePulled.Text)
        intFootageUsed = CInt(txtFootageUsed.Text)
        intFootageLeft = intFootagePulled - intFootageUsed

        'Loading Up Variables to be saved in the Cable Usage Table
        intInternalProjectIDForSearch = CInt(txtInternalProjectID.Text)
        intManagerIDForSearch = CInt(txtManagerID.Text)
        intTechnicianIDForSearch = CInt(txtTechnicianID.Text)
        strReelIDForSearch = txtReelID.Text
        strPartNumberForSearch = txtPartNumber.Text
        intWarehouseID = CInt(txtWarehouseID.Text)

        'Try Catch to update the Issue Table
        Try
            editingBoolean = True
            txtFootagePulled.Text = CStr(intFootageLeft)
            TheIssueCableBindingSource.EndEdit()
            TheIssueCableDataTier.UpdateIssueCableDB(TheIssueCableDataSet)
            editingBoolean = False
            setComboBoxBinding()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        'Beginning to update the manager queue

        ClearCableIssueDataBindings()
        SetDataBindingsForManagerQueue()

        'Setting Conditions for Updating the Manager Queue
        intNumberOfRecords = cboTransactionID.Items.Count - 1

        'Beginning Loop
        For intCounter = 0 To intNumberOfRecords

            cboTransactionID.SelectedIndex = intCounter
            intManagerIDFromTable = CInt(txtManagerID.Text)
            intFootageFromTable = CInt(txtFootagePulled.Text)
            intTechnicianIDFromTable = CInt(txtTechnicianID.Text)
            strReelIDFromTable = txtReelID.Text
            strPartNumberFromTable = txtPartNumber.Text
            intInternalProjectIDFromTable = CInt(txtInternalProjectID.Text)

            'Beginning Compare to set the selected index
            If intManagerIDForSearch = intManagerIDFromTable Then
                If intInternalProjectIDForSearch = intInternalProjectIDFromTable Then
                    If intTechnicianIDForSearch = intTechnicianIDFromTable Then
                        If strReelIDForSearch = strReelIDFromTable Then
                            If strPartNumberForSearch = strPartNumberFromTable Then
                                If intFootageFromTable = intFootagePulled Then
                                    intSelectedIndex = intCounter
                                End If
                            End If
                        End If
                    End If
                End If
            End If

        Next

        cboTransactionID.SelectedIndex = intSelectedIndex

        'Try Catch to update the Manager Queue
        Try
            editingBoolean = True
            txtFootagePulled.Text = CStr(intFootageLeft)
            TheManagerQueueBindingSource.EndEdit()
            TheManagerQueueDataTier.UpdateManagerQueueDB(TheManagerQueueDataSet)
            editingBoolean = False
            setComboBoxBinding()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        cboTransactionID.Visible = True

        'Setting up for Cable Usage
        ClearCableIssueDataBindings()
        SetDataBindingsForCableUsage()

        'Adds the Record to the Cable Usage Form
        With TheCableUsageBindingSource
            .EndEdit()
            .AddNew()
        End With

        addingBoolean = True
        setComboBoxBinding()
        cboTransactionID.Focus()
        If cboTransactionID.SelectedIndex <> -1 Then
            previousSelectedIndex = cboTransactionID.Items.Count - 1
        Else
            previousSelectedIndex = 0
        End If

        Logon.mintReelTransactionID = cboTransactionID.Items.Count + 1000

        strLogDateTime = CStr(LogDateTime)
        txtDate.Text = strLogDateTime

        CableTransactionID.Show()

        cboTransactionID.Text = CStr(Logon.mintReelTransactionID)

        txtInternalProjectID.Text = CStr(intInternalProjectIDForSearch)
        txtTechnicianID.Text = CStr(intTechnicianIDForSearch)
        txtManagerID.Text = CStr(intManagerIDForSearch)
        txtFootagePulled.Text = CStr(intFootageUsed)
        txtPartNumber.Text = strPartNumberForSearch
        txtReelID.Text = strReelIDForSearch
        txtWarehouseID.Text = CStr(intWarehouseID)

        Try
            TheCableUsageBindingSource.EndEdit()
            TheCableUsageDataTier.UpdateCableUsageDB(TheCableUsageDataSet)
            editingBoolean = False
            addingBoolean = False
            setComboBoxBinding()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    Private Sub btnIssueSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIssueSelect.Click

        'Setting variables
        btnAssignUsage.Enabled = True
        btnIssueCableBack.Enabled = False
        btnIssueCableNext.Enabled = False
        btnIssueSelect.Enabled = False
        mstrCabledPulled = txtFootagePulled.Text
        UseCablePulled.ShowDialog()

        'Determining if control should be enabled
        If mblnUseFootagePulled = False Then
            txtFootageUsed.ReadOnly = False
        Else
            txtFootageUsed.Text = txtFootagePulled.Text
        End If

    End Sub
    Private Sub SetDataBindingsForManagerQueue()

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
            With cboTransactionID
                .DataSource = TheManagerQueueBindingSource
                .DisplayMember = "TransactionID"
                .DataBindings.Add("text", TheManagerQueueBindingSource, "TransactionID", False, DataSourceUpdateMode.Never)
            End With

            'Setting Control bindings
            txtInternalProjectID.DataBindings.Add("text", TheManagerQueueBindingSource, "InternalProjectID")
            txtTechnicianID.DataBindings.Add("text", TheManagerQueueBindingSource, "TechnicianID")
            txtFootagePulled.DataBindings.Add("text", TheManagerQueueBindingSource, "Footage")
            txtManagerID.DataBindings.Add("text", TheManagerQueueBindingSource, "ManagersID")
            txtReelID.DataBindings.Add("Text", TheManagerQueueBindingSource, "ReelID")
            txtPartNumber.DataBindings.Add("text", TheManagerQueueBindingSource, "PartNumber")
            txtDate.DataBindings.Add("text", TheManagerQueueBindingSource, "Date")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "There is a Problem", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
End Class