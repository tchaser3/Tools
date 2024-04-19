'Title:         Receive Cable
'Date:          1/6/14
'Author:        Terry Holmes

'Description:   This form is used to receive cable

Option Strict On

Public Class ReceiveCable

    'Setting Modular Variables

    'Setting Variables for the Cable Type Boxes
    

    Dim mblnFatalError As Boolean

    Private TheReceiveCableDataSet As ReceiveCableDataSet
    Private TheReceiveCableDataTier As CableDataTier
    Private WithEvents TheReceiveCableBindingSource As BindingSource

    'Setting up global variables for The Part Number Controls
    Private ThePartNumberDataSet As PartNumberDataSet
    Private ThePartNumberDataTier As PartDataTier
    Private WithEvents ThePartNumberBindingSource As BindingSource

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

    End Sub
    Private Sub setControlsReadOnly(ByVal valueBoolean As Boolean)

        'This will set controls either to read only or not
        With Me
            txtCategory.ReadOnly = valueBoolean
            txtCurrentFootage.ReadOnly = valueBoolean
            txtReelID.ReadOnly = valueBoolean
            txtTWReelID.ReadOnly = valueBoolean
            txtPartNumber.ReadOnly = valueBoolean
            txtMSR.ReadOnly = valueBoolean
            txtWarehouseEmployeeID.ReadOnly = valueBoolean
            txtDate.ReadOnly = valueBoolean
            txtWarehouse.ReadOnly = valueBoolean
            txtNotes.ReadOnly = valueBoolean
        End With

    End Sub
    Private Sub setButtonsForEdit()

        'Setting the buttons for editing
        btnAdd.Text = "Save"
        btnEdit.Enabled = False
        btnMainMenu.Enabled = False

    End Sub
    Private Sub ResetButtonAfterEditing()

        'Setting the buttons for adding a record
        btnAdd.Text = "Add"
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

        strValueForValidation = txtCategory.Text
        blnFatalError = TheInputDataValidation.VerifyTextData(strValueForValidation)

        If blnFatalError = True Then
            MessageBox.Show("Part Category Was Not Entered", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        txtPartNumber.Text = txtCablePartNumber.Text
        btnCreateReelID.Enabled = True

    End Sub
    Private Sub btnCreateReelID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateReelID.Click

        Dim strValueForValidation As String
        Dim blnFatalError As Boolean = False

        'This will Open the Create Reel ID Form
        strValueForValidation = txtPartNumber.Text
        blnFatalError = TheInputDataValidation.VerifyTextData(strValueForValidation)

        If blnFatalError = True Then
            MessageBox.Show("The Part Number Was Not Entered", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Logon.mstrCablePartNumber = txtPartNumber.Text

        CreateReelID.Show()
        txtReelID.Text = Logon.mstrReelID


    End Sub

    Private Sub ReceiveCable_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Try - Catch for Receive Cable
        Try

            'This will bind the controls to the data source
            TheReceiveCableDataTier = New CableDataTier
            TheReceiveCableDataSet = TheReceiveCableDataTier.GetReceiveCableInformation
            TheReceiveCableBindingSource = New BindingSource

            'Setting up Binding Source for the Combo Box
            With TheReceiveCableBindingSource
                .DataSource = TheReceiveCableDataSet
                .DataMember = "receivecable"
                .MoveFirst()
                .MoveLast()
            End With

            'Setting the data relationship for the Combo Box
            With cboTransactionID
                .DataSource = TheReceiveCableBindingSource
                .DisplayMember = "TransactionID"
                .DataBindings.Add("text", TheReceiveCableBindingSource, "TransactionID", False, DataSourceUpdateMode.Never)
            End With

            'Setting the data binding for the text boxes
            txtCategory.DataBindings.Add("text", TheReceiveCableBindingSource, "Category")
            txtPartNumber.DataBindings.Add("text", TheReceiveCableBindingSource, "PartNumber")
            txtReelID.DataBindings.Add("text", TheReceiveCableBindingSource, "ReelID")
            txtTWReelID.DataBindings.Add("text", TheReceiveCableBindingSource, "TWReelID")
            txtCurrentFootage.DataBindings.Add("text", TheReceiveCableBindingSource, "Footage")
            txtMSR.DataBindings.Add("text", TheReceiveCableBindingSource, "MSR")
            txtDate.DataBindings.Add("text", TheReceiveCableBindingSource, "Date")
            txtWarehouse.DataBindings.Add("text", TheReceiveCableBindingSource, "WarehouseID")
            txtWarehouseEmployeeID.DataBindings.Add("text", TheReceiveCableBindingSource, "WarehouseEmployeeID")
            txtNotes.DataBindings.Add("text", TheReceiveCableBindingSource, "Notes")

            setControlsReadOnly(True)

        Catch ex As Exception

            'If an exception is thrown, it is rounted here
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        'Try - Catch for Cable Type
        Try

            txtCategory.Visible = True

            'Setting up controls
            ThePartNumberDataTier = New PartDataTier
            ThePartNumberDataSet = ThePartNumberDataTier.GetPartNumberInformation
            ThePartNumberBindingSource = New BindingSource

            'Setting the Binding Source
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

            'Binding Part Number Controls
            txtCablePartNumber.DataBindings.Add("text", ThePartNumberBindingSource, "PartNumber")
            txtCableDescription.DataBindings.Add("text", ThePartNumberBindingSource, "Description")
            txtCableJobType.DataBindings.Add("text", ThePartNumberBindingSource, "Type")
            txtCablePartType.DataBindings.Add("text", ThePartNumberBindingSource, "PartType")

            btnAdd.PerformClick()

        Catch ex As Exception

            'If an exception is thrown, it is rounted here
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        'Setting local variables
        Dim blnFatalError As Boolean
        Dim intNumberOfRecords As Integer
        Dim strValueForValidation As String
        Dim strErrorMessage As String

        'Setting up if statements
        If btnAdd.Text = "Add" Then  'This routine will run if the user is adding an employee
            With TheReceiveCableBindingSource
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

            strLogDateTime = CStr(LogDateTime)
            txtDate.Text = strLogDateTime
            txtWarehouse.Text = CStr(Logon.mintWarehouseID)
            txtWarehouseEmployeeID.Text = CStr(Logon.mintEmployeeID)

            mintReelTransactionID = intNumberOfRecords
            Logon.mintReelTransactionID = CInt(mintReelTransactionID)

            CableTransactionID.Show()

            mintReelTransactionID = CInt(Logon.mintReelTransactionID)

            cboTransactionID.Text = CStr(mintReelTransactionID)

        Else  'This else statement runs when the record is saved

            blnFatalError = False
            strValueForValidation = txtPartNumber.Text
            strErrorMessage = "The Part Number Information was not Entered"
            blnFatalError = TheInputDataValidation.VerifyTextData(strValueForValidation)
            If blnFatalError = False Then
                strValueForValidation = txtCurrentFootage.Text
                strErrorMessage = "The Current Footage Entered is not an Integer"
                blnFatalError = TheInputDataValidation.VerifyIntegerData(strValueForValidation)
                If blnFatalError = False Then
                    strValueForValidation = txtReelID.Text
                    strErrorMessage = "The Reel ID was not Entered"
                    blnFatalError = TheInputDataValidation.VerifyTextData(strValueForValidation)
                    If blnFatalError = False Then
                        strValueForValidation = txtDate.Text
                        strErrorMessage = "The Date Information Entered is not a Date"
                        blnFatalError = TheInputDataValidation.VerifyStartingEndingDatesAsDates(strValueForValidation)
                        If blnFatalError = False Then
                            strValueForValidation = txtWarehouse.Text
                            strErrorMessage = "The Warehouse Information was not Entered"
                            blnFatalError = TheInputDataValidation.VerifyIntegerData(strValueForValidation)
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
            Logon.mstrCategory = txtCategory.Text
            Logon.mstrCablePartNumber = txtPartNumber.Text
            Logon.mstrReelID = txtReelID.Text
            Logon.mstrTWReelID = txtTWReelID.Text
            Logon.mintCurrentFootage = CInt(txtCurrentFootage.Text)
            Logon.mstrMSR = txtMSR.Text
            Logon.mdatDate = CDate(txtDate.Text)
            Logon.mintWarehouseID = CInt(txtWarehouse.Text)
            Logon.mintWarehouseEmployeeID = CInt(txtWarehouseEmployeeID.Text)
            Logon.mstrNotes = txtNotes.Text

            'Cable Type Verification
            AddCableUpdateTables.Show()
            If Logon.mbolFatalError = True Then
                MessageBox.Show("Reel ID Entered Is Aready Used", "Please Try Again", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            btnSelectPartNumber.Enabled = False
            btnCreateReelID.Enabled = False
            btnNext.Enabled = False
            btnBack.Enabled = False

            'Updating Database
            Try
                TheReceiveCableBindingSource.EndEdit()
                TheReceiveCableDataTier.UpdateReceiveCableDB(TheReceiveCableDataSet)
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
    Private Sub SetCategoryBox()

        txtCategory.Text = mstrCableCategory
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
End Class