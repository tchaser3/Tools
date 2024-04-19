'Title:         Transfer Cable Between Warehouses
'Date:          1/14/14
'Author:        Terry Holmes

'Description:   This form is used to transfer cable betwee warehouses

Option Strict On

Public Class TransferCable

    'Setting Modular Variables

    'Setting Variables for the Cable Type Boxes

    'Setting Modular Variables
    Private TheEmployeeDataSet As EmployeeDataSet
    Private TheEmployeeDataTier As EmployeeDataTier
    Private WithEvents TheEmployeeBindingSource As BindingSource

    Private ThePartNumberDataSet As PartNumberDataSet
    Private ThePartNumberDataTier As PartDataTier
    Private ThePartNumberBindingSource As BindingSource

    Private TheTransferCableDataSet As TransferCableDataSet
    Private TheTransferCableDataTier As CableDataTier
    Private WithEvents TheTransferCableBindingSource As BindingSource

    Dim TheInputDataValidation As New InputDataValidation

    Private addingBoolean As Boolean = False
    Private editingBoolean As Boolean = False
    Private previousSelectedIndex As Integer
    Dim mintNumuberOfRecords As Integer

    Dim LogDateTime As Date = DateAndTime.Now
    Dim strLogDateTime As String

    'Setting global variable
    Dim mintSelectedIndex(100) As Integer
    Dim mintSelectedIndexCounter As Integer = 0
    Dim mintSelectedIndexUpperLimit As Integer

    Dim mintCableTypeComboBoxUpperLimit As Integer = 0
    Dim mintReelTransactionID As Integer
    Dim mstrCableCategory As String

    Dim mintWarehouseSelectedIndex(10) As Integer
    Dim mintWarehouseSelectedIndexCounter As Integer
    Dim mintWarehouseSelectedIndexUpperLimit As Integer

    Private Sub btnInventoryMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInventoryMenu.Click

        'This Button will call the Administrative Menu
        InventoryMenu.Show()
        Me.Close()

    End Sub
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        'Closes the form and all hidden forms and the program
        MainMenu.Close()
        Logon.Close()
        Me.Close()

    End Sub

    Private Sub btnMainMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMainMenu.Click

        'Calls the Main Menu
        MainMenu.Show()
        Me.Close()

    End Sub

    Private Sub setComboBoxBinding()

        'Setting Transaction ID Combo Binding
        With Me.cboTransactionID
            If (addingBoolean Or editingBoolean) Then
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.OnValidation
                .DropDownStyle = ComboBoxStyle.Simple
            Else
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.Never
                .DropDownStyle = ComboBoxStyle.DropDownList
            End If
        End With

        'Setting Employee ID Combo Binding
        With Me.cboEmployeeID
            If (addingBoolean Or editingBoolean) Then
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.OnValidation
                .DropDownStyle = ComboBoxStyle.Simple
            Else
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.Never
                .DropDownStyle = ComboBoxStyle.DropDownList
            End If
        End With

        'Setting Type ID Combo Binding
        With Me.cboPartID
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
            txtReelID.ReadOnly = valueBoolean
            txtPartNumber.ReadOnly = valueBoolean
            txtOldWarehouse.ReadOnly = valueBoolean
            txtOldWarehouseID.ReadOnly = valueBoolean
            txtNewWarehouse.ReadOnly = valueBoolean
            txtNewWarehouseID.ReadOnly = valueBoolean
        End With

    End Sub
    Private Sub setButtonsForEdit()

        'Setting the buttons for editing
        btnTransferCable.Text = "Save"
        btnEdit.Enabled = False
        btnMainMenu.Enabled = False

    End Sub
    Private Sub ResetButtonAfterEditing()

        'Setting the buttons for adding a record
        btnTransferCable.Text = "Transfer Cable"
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

    Private Sub btnCableMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCableMenu.Click

        'launches the Cable Menu
        CableMenu.Show()
        Me.Close()

    End Sub

    Private Sub btnSelectPartNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectPartNumber.Click

        'This will launch the Select Cable Part Number Form
        Dim strValueForValidation As String = ""
        Dim blnFatalError As Boolean = False

        strValueForValidation = mstrCableCategory
        blnFatalError = TheInputDataValidation.VerifyCableCategory(strValueForValidation)

        If blnFatalError = True Then
            MessageBox.Show("Cable Category Not Found", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        txtPartNumber.Text = txtCablePartNumber.Text
        btnFromWarehouse.Enabled = True

    End Sub

    Private Sub TransferCable_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim strWarehouse As String
        Dim intCounter As Integer
        Dim intUpperLimit As Integer
        Dim strLastName As String

        'Try - Catch for Transfer Cable
        Try

            'This will bind the controls to the data source
            TheTransferCableDataTier = New CableDataTier
            TheTransferCableDataSet = TheTransferCableDataTier.GetTransferCableInformation
            TheTransferCableBindingSource = New BindingSource

            'Setting up Binding Source for the Combo Box
            With TheTransferCableBindingSource
                .DataSource = TheTransferCableDataSet
                .DataMember = "transfercablewarehouse"
                .MoveFirst()
                .MoveLast()
            End With

            'Setting the data relationship for the Combo Box
            With cboTransactionID
                .DataSource = TheTransferCableBindingSource
                .DisplayMember = "TransactionID"
                .DataBindings.Add("text", TheTransferCableBindingSource, "TransactionID", False, DataSourceUpdateMode.Never)
            End With

            'Setting the data binding for the text boxes
            txtPartNumber.DataBindings.Add("text", TheTransferCableBindingSource, "PartNumber")
            txtReelID.DataBindings.Add("text", TheTransferCableBindingSource, "ReelID")
            txtOldWarehouseID.DataBindings.Add("text", TheTransferCableBindingSource, "OldWarehouseID")
            txtOldWarehouse.DataBindings.Add("text", TheTransferCableBindingSource, "OldWarehouse")
            txtNewWarehouseID.DataBindings.Add("text", TheTransferCableBindingSource, "NewWarehouseID")
            txtNewWarehouse.DataBindings.Add("text", TheTransferCableBindingSource, "NewWarehouse")

        Catch ex As Exception

            'If an exception is thrown, it is rounted here
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


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

            'Setting the data relationship for the Combo Box
            With cboEmployeeID
                .DataSource = TheEmployeeBindingSource
                .DisplayMember = "EmployeeID"
                .DataBindings.Add("text", TheEmployeeBindingSource, "EmployeeID", False, DataSourceUpdateMode.Never)
            End With

            'Setting the data binding for the text boxes
            txtFirstName.DataBindings.Add("text", TheEmployeeBindingSource, "FirstName")
            txtLastName.DataBindings.Add("text", TheEmployeeBindingSource, "LastName")

        Catch ex As Exception

            'If an exception is thrown, it is rounted here
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        'Filling Array with only Warehouses to Be Selected
        strWarehouse = "PARTS"
        mintWarehouseSelectedIndexCounter = 0
        mintWarehouseSelectedIndexUpperLimit = 0
        intUpperLimit = cboEmployeeID.Items.Count - 1

        'Running For Loop to find the different warehouses
        For intCounter = 0 To intUpperLimit

            cboEmployeeID.SelectedIndex = intCounter
            strLastName = txtLastName.Text
            If strLastName = strWarehouse Then
                mintWarehouseSelectedIndex(mintWarehouseSelectedIndexCounter) = intCounter
                mintWarehouseSelectedIndexCounter = mintWarehouseSelectedIndexCounter + 1
            End If

        Next

        mintWarehouseSelectedIndexUpperLimit = mintWarehouseSelectedIndexCounter - 1
        mintWarehouseSelectedIndexCounter = 0
        cboEmployeeID.SelectedIndex = mintWarehouseSelectedIndex(0)

        If mintWarehouseSelectedIndexUpperLimit > 0 Then
            btnEmployeeNext.Enabled = True
        End If

        cboEmployeeID.Visible = False

        'Try - Catch for Cable Type
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

            'Setting the combo box
            With cboPartID
                .DataSource = ThePartNumberBindingSource
                .DisplayMember = "PartID"
                .DataBindings.Add("text", ThePartNumberBindingSource, "PartID", False, DataSourceUpdateMode.Never)
            End With

            'Setting up the part number controls
            txtCablePartNumber.DataBindings.Add("text", ThePartNumberBindingSource, "PartNumber")
            txtCableDescription.DataBindings.Add("text", ThePartNumberBindingSource, "Description")
            txtCableJobType.DataBindings.Add("text", ThePartNumberBindingSource, "Type")
            txtCablePartType.DataBindings.Add("text", ThePartNumberBindingSource, "PartType")

        Catch ex As Exception

            'If an exception is thrown, it is rounted here
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        'ActivateRadioButtons(False)
        btnSelectPartNumber.Enabled = False
        setControlsReadOnly(True)
        btnFromWarehouse.Enabled = False
        btnToWarehouse.Enabled = False
        btnTransferCable.PerformClick()
        btnTransferCable.Visible = False

    End Sub

    Private Sub btnEmployeeNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEmployeeNext.Click

        mintWarehouseSelectedIndexCounter = mintWarehouseSelectedIndexCounter + 1
        cboEmployeeID.SelectedIndex = mintWarehouseSelectedIndex(mintWarehouseSelectedIndexCounter)

        btnEmployeeBack.Enabled = True

        If mintWarehouseSelectedIndexCounter = mintWarehouseSelectedIndexUpperLimit Then
            btnEmployeeNext.Enabled = False
        End If


    End Sub

    Private Sub btnEmployeeBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEmployeeBack.Click

        mintWarehouseSelectedIndexCounter = mintWarehouseSelectedIndexCounter - 1
        cboEmployeeID.SelectedIndex = mintWarehouseSelectedIndex(mintWarehouseSelectedIndexCounter)

        btnEmployeeNext.Enabled = True

        If mintWarehouseSelectedIndexCounter = 0 Then
            btnEmployeeBack.Enabled = False
        End If


    End Sub
    Private Sub SetCategoryBox()

        btnSelectPartNumber.Enabled = True


    End Sub
    Private Sub rdoCoax_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdoCoax.CheckedChanged

        'This will Set the variable value
        mstrCableCategory = "COAX"
        SetCategoryBox()
        SetCableCategory()

    End Sub

    Private Sub rdoFiber_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdoFiber.CheckedChanged

        'This will Set the variable value
        mstrCableCategory = "FIBER"
        SetCategoryBox()
        SetCableCategory()

    End Sub


    Private Sub rdoDropCable_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdoDropCable.CheckedChanged

        'This will Set the variable value
        mstrCableCategory = "DROP CABLE"
        SetCategoryBox()
        SetCableCategory()

    End Sub

    Private Sub rdoTwistedPair_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdoTwistedPair.CheckedChanged

        'This will Set the variable value
        mstrCableCategory = "TWISTED PAIR"
        SetCategoryBox()
        SetCableCategory()

    End Sub

    Private Sub rdoSpecialtyCable_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdoSpecialtyCable.CheckedChanged

        'This will Set the variable value
        mstrCableCategory = "SPECIALTY CABLE"
        SetCategoryBox()
        SetCableCategory()

    End Sub
    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click


        mintSelectedIndexCounter = mintSelectedIndexCounter + 1
        cboPartID.SelectedIndex = mintSelectedIndex(mintSelectedIndexCounter)

        btnBack.Enabled = True

        If mintSelectedIndexCounter = mintSelectedIndexUpperLimit Then
            btnNext.Enabled = False
        End If

    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click

        mintSelectedIndexCounter = mintSelectedIndexCounter - 1
        cboPartID.SelectedIndex = mintSelectedIndex(mintSelectedIndexCounter)

        btnNext.Enabled = True

        If mintSelectedIndexCounter = 0 Then
            btnBack.Enabled = False
        End If

    End Sub

    Private Sub SetCableCategory()

        Dim strCategory As String
        Dim strPartType As String

        cboPartID.SelectedIndex = 0
        btnBack.Enabled = False
        btnNext.Enabled = False

        mintCableTypeComboBoxUpperLimit = cboPartID.Items.Count - 1
        mintSelectedIndexCounter = 0
        mintSelectedIndexUpperLimit = 0

        'For intCounter = 0 To mintCableTypeComboBoxUpperLimit
        'mintSelectedIndex(intCounter) = -1
        'Next

        For intCounter = 0 To mintCableTypeComboBoxUpperLimit

            cboPartID.SelectedIndex = intCounter
            strCategory = txtCableJobType.Text
            strPartType = txtCablePartType.Text

            If strCategory = mstrCableCategory Then
                If strPartType = "CABLE" Then
                    mintSelectedIndex(mintSelectedIndexCounter) = intCounter
                    mintSelectedIndexCounter = mintSelectedIndexCounter + 1
                End If
            End If
        Next
        mintSelectedIndexUpperLimit = mintSelectedIndexCounter - 1
        mintSelectedIndexCounter = 0
        cboPartID.SelectedIndex = mintSelectedIndex(0)
        If mintSelectedIndexUpperLimit > 0 Then
            btnNext.Enabled = True
        End If

        If mintSelectedIndexUpperLimit = 0 Then
            btnNext.Enabled = False
            btnBack.Enabled = False
        End If

        'btnCreateReelID.Enabled = True

    End Sub

    Private Sub ActivateRadioButtons(ByVal valueBoolean As Boolean)

        'Setting the Buttons
        rdoCoax.Enabled = valueBoolean
        rdoFiber.Enabled = valueBoolean
        rdoDropCable.Enabled = valueBoolean
        rdoTwistedPair.Enabled = valueBoolean
        rdoSpecialtyCable.Enabled = valueBoolean

    End Sub

    Private Sub btnFromWarehouse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFromWarehouse.Click

        txtOldWarehouseID.Text = cboEmployeeID.Text
        txtOldWarehouse.Text = txtFirstName.Text

        btnToWarehouse.Enabled = True
        btnFromWarehouse.Enabled = False

    End Sub

    Private Sub btnToWarehouse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToWarehouse.Click

        txtNewWarehouseID.Text = cboEmployeeID.Text
        txtNewWarehouse.Text = txtFirstName.Text

        btnToWarehouse.Enabled = False
        btnTransferCable.Visible = True

    End Sub

    Private Sub btnTransferCable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTransferCable.Click


        'Setting local variables
        Dim blnFatalError As Boolean
        Dim intNumberOfRecords As Integer
        Dim strValueForValidation As String
        Dim strErrorMessage As String

        'Setting up if statements
        If btnTransferCable.Text = "Transfer Cable" Then  'This routine will run if the user is adding an employee
            With TheTransferCableBindingSource
                .EndEdit()
                .AddNew()
            End With

            'Calling sub-routines and setting call values
            addingBoolean = True
            setComboBoxBinding()
            cboTransactionID.Focus()
            setControlsReadOnly(False)
            ActivateRadioButtons(True)
            setButtonsForEdit()
            If cboTransactionID.SelectedIndex <> -1 Then
                previousSelectedIndex = cboTransactionID.Items.Count - 1
            Else
                previousSelectedIndex = 0
            End If

            'Setting up fields with auto-data to avoid having the user do it.
            mintNumuberOfRecords = cboTransactionID.Items.Count
            intNumberOfRecords = mintNumuberOfRecords + 1000

            mintReelTransactionID = intNumberOfRecords
            Logon.mintReelTransactionID = CInt(mintReelTransactionID)

            CableTransactionID.Show()

            mintReelTransactionID = CInt(Logon.mintReelTransactionID)

            cboTransactionID.Text = CStr(mintReelTransactionID)

        Else  'This else statement runs when the record is saved

            'Setting up Data Validation
            blnFatalError = False
            strValueForValidation = txtPartNumber.Text
            strErrorMessage = "Part Number Not Entered"
            blnFatalError = TheInputDataValidation.VerifyTextData(strValueForValidation)
            If blnFatalError = False Then
                strValueForValidation = txtReelID.Text
                strErrorMessage = "Reel ID Not Entered"
                blnFatalError = TheInputDataValidation.VerifyTextData(strValueForValidation)
                If blnFatalError = False Then
                    strValueForValidation = txtOldWarehouseID.Text
                    strErrorMessage = "Old Warehouse ID is not an Integer"
                    blnFatalError = TheInputDataValidation.VerifyIntegerData(strValueForValidation)
                    If blnFatalError = False Then
                        strValueForValidation = txtOldWarehouse.Text
                        strErrorMessage = "Old Warehouse Information was not Entered"
                        blnFatalError = TheInputDataValidation.VerifyTextData(strValueForValidation)
                        If blnFatalError = False Then
                            strValueForValidation = txtNewWarehouseID.Text
                            strErrorMessage = "New Warehouse ID is not an Integer"
                            blnFatalError = TheInputDataValidation.VerifyIntegerData(strValueForValidation)
                            If blnFatalError = False Then
                                strValueForValidation = txtNewWarehouse.Text
                                strErrorMessage = "New Warehouse Information was not Entered"
                                blnFatalError = TheInputDataValidation.VerifyTextData(strValueForValidation)
                            End If
                        End If
                    End If
                End If
            End If

            If blnFatalError = True Then
                MessageBox.Show(strErrorMessage, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            'Loading up Global Variables
            Logon.mintReelTransactionID = CInt(cboTransactionID.Text)
            Logon.mstrCablePartNumber = txtPartNumber.Text
            Logon.mstrReelID = txtReelID.Text
            Logon.mintWarehouseID = CInt(txtNewWarehouseID.Text)

            'Calling the correct transfer form
            If mstrCableCategory = "COAX" Then
                TransferCoax.Show()
            ElseIf mstrCableCategory = "FIBER" Then
                TransferFiber.Show()
            ElseIf mstrCableCategory = "DROP CABLE" Then
                TransferDropCable.Show()
            ElseIf mstrCableCategory = "TWISTED PAIR" Then
                TransferTwistedPair.Show()
            ElseIf mstrCableCategory = "SPECIALTY CABLE" Then
                TransferSpecialtyCable.Show()
            End If

            'Getting Error Condition
            blnFatalError = Logon.mbolFatalError

            'Setting up Error Validation
            If blnFatalError = True Then
                MessageBox.Show("Cable Reel and Part Number Do Not Match", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            'Updating Database
            Try
                TheTransferCableBindingSource.EndEdit()
                TheTransferCableDataTier.UpdateTransferCableDB(TheTransferCableDataSet)
                addingBoolean = False
                editingBoolean = False
                setControlsReadOnly(True)
                ActivateRadioButtons(False)
                ResetButtonAfterEditing()
                setComboBoxBinding()
                cboTransactionID.SelectedIndex = previousSelectedIndex

            Catch ex As Exception
                MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If

    End Sub

End Class