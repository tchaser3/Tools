'Title:         Return Cable Reel Form
'Date:          2/20/14
'Author:        Terry Holmes

'Description:   This form is used to return cable reels

Option Strict On

Public Class ReturnCableReel

    'Setting Modular Variables

        'Setting Variables for the Cable Type Boxes
       

        Private TheReturnCableReelDataSet As ReturnCableReelDataSet
        Private TheReturnCableReelDataTier As CableDataTier
    Private WithEvents TheReturnCableReelBindingSource As BindingSource

    'Setting Variables for the Cable Boxes
    Private ThePartNumberDataSet As PartNumberDataSet
    Private ThePartNumberDataTier As PartDataTier
    Private WithEvents ThePartNumberBindingSource As BindingSource

        Dim TheInputDataValidation As New InputDataValidation

        Private addingBoolean As Boolean = False
        Private editingBoolean As Boolean = False
        Private previousSelectedIndex As Integer
    Dim mintNumuberOfRecords As Integer
    Dim mblnFatalError As Boolean

        Dim LogDateTime As Date = DateAndTime.Now
        Dim strLogDateTime As String

        'Setting global variable
    Dim mintSelectedIndex(5000) As Integer
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

            txtCurrentFootage.ReadOnly = valueBoolean
            txtReelID.ReadOnly = valueBoolean

        End With

    End Sub
    Private Sub setButtonsForEdit()

        'Setting the buttons for editing
        btnAdd.Text = "Save"
        btnMainMenu.Enabled = False

    End Sub
    Private Sub ResetButtonAfterEditing()

        'Setting the buttons for adding a record
        btnAdd.Text = "Return Reel"
        btnMainMenu.Enabled = True

    End Sub

    Private Sub btnCableMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCableMenu.Click

        'launches the Cable Menu
        CableMenu.Show()
        Me.Close()

    End Sub

    Private Sub VerifyReelType()

        Logon.mstrCableSelectionType = txtCategory.Text
        VerifyJobType.Show()

    End Sub
    Private Sub btnSelectPartNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectPartNumber.Click

        'This will launch the Select Cable Part Number Form
        Dim strValueForValidation As String = ""
        Dim blnFatalError As Boolean = False

        strValueForValidation = txtCategory.Text
        blnFatalError = TheInputDataValidation.VerifyTextData(strValueForValidation)

        If blnFatalError = True Then
            MessageBox.Show("Cable Category Was Not Entered", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        VerifyReelType()
        blnFatalError = Logon.mbolFatalError

        If blnFatalError = True Then
            MessageBox.Show("The Cable Reel Category is Incorrect", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtCategory.Text = ""
            Exit Sub
        End If


        txtPartNumber.Text = txtCablePartNumber.Text
        SetVisibleRadioButtons(False)
        SetSelectCableTextboxesVisible(False)
        btnAdd.Enabled = True

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
        SetSelectCableTextboxesVisible(True)

    End Sub

    Private Sub rdoFiber_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdoFiber.CheckedChanged

        'This will Set the variable value
        mstrCableCategory = "FIBER"
        SetCategoryBox()
        SetCableCategory()
        SetSelectCableTextboxesVisible(True)

    End Sub


    Private Sub rdoDropCable_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdoDropCable.CheckedChanged

        'This will Set the variable value
        mstrCableCategory = "DROP CABLE"
        SetCategoryBox()
        SetCableCategory()
        SetSelectCableTextboxesVisible(True)

    End Sub

    Private Sub rdoTwistedPair_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdoTwistedPair.CheckedChanged

        'This will Set the variable value
        mstrCableCategory = "TWISTED PAIR"
        SetCategoryBox()
        SetCableCategory()
        SetSelectCableTextboxesVisible(True)

    End Sub

    Private Sub rdoSpecialtyCable_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdoSpecialtyCable.CheckedChanged

        'This will Set the variable value
        mstrCableCategory = "SPECIALTY CABLE"
        SetCategoryBox()
        SetCableCategory()
        SetSelectCableTextboxesVisible(True)

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
        Dim strCablePartType As String

        cboPartID.SelectedIndex = 0
        btnBack.Enabled = False
        btnNext.Enabled = False

        mintCableTypeComboBoxUpperLimit = cboPartID.Items.Count - 1
        mintSelectedIndexCounter = 0
        mintSelectedIndexUpperLimit = 0

        For intCounter = 0 To mintCableTypeComboBoxUpperLimit

            cboPartID.SelectedIndex = intCounter
            strCategory = txtCableJobType.Text
            strCablePartType = txtCablePartType.Text
            If strCategory = mstrCableCategory Then
                If strCablePartType = "CABLE" Then
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

    Private Sub ReturnCableReel_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Try - Catch for Receive Cable
        Try

            'This will bind the controls to the data source
            TheReturnCableReelDataTier = New CableDataTier
            TheReturnCableReelDataSet = TheReturnCableReelDataTier.GetReturnCableReelInformation
            TheReturnCableReelBindingSource = New BindingSource

            'Setting up Binding Source for the Combo Box
            With TheReturnCableReelBindingSource
                .DataSource = TheReturnCableReelDataSet
                .DataMember = "ReturnCableReel"
                .MoveFirst()
                .MoveLast()
            End With

            'Setting the data relationship for the Combo Box
            With cboTransactionID
                .DataSource = TheReturnCableReelBindingSource
                .DisplayMember = "TransactionID"
                .DataBindings.Add("text", TheReturnCableReelBindingSource, "TransactionID", False, DataSourceUpdateMode.Never)
            End With

            'Setting the data binding for the text boxes
            txtCategory.DataBindings.Add("text", TheReturnCableReelBindingSource, "Category")
            txtPartNumber.DataBindings.Add("text", TheReturnCableReelBindingSource, "PartNumber")
            txtReelID.DataBindings.Add("text", TheReturnCableReelBindingSource, "ReelID")
            txtCurrentFootage.DataBindings.Add("text", TheReturnCableReelBindingSource, "CurrentFootage")
            txtDate.DataBindings.Add("text", TheReturnCableReelBindingSource, "Date")
            txtWarehouse.DataBindings.Add("text", TheReturnCableReelBindingSource, "WarehouseID")

            setControlsReadOnly(True)

        Catch ex As Exception

            'If an exception is thrown, it is rounted here
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        'Try - Catch for Cable Type
        Try

            txtCategory.Visible = True

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


            SetVisibleRadioButtons(False)
            SetSelectCableTextboxesVisible(False)
            SetReturnCableControlsVisible(False)

            btnAdd.PerformClick()

        Catch ex As Exception

            'If an exception is thrown, it is rounted here
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try



    End Sub

    Private Sub SetVisibleRadioButtons(ByVal valueBoolean As Boolean)

        rdoCoax.Visible = valueBoolean
        rdoDropCable.Visible = valueBoolean
        rdoFiber.Visible = valueBoolean
        rdoTwistedPair.Visible = valueBoolean
        rdoSpecialtyCable.Visible = valueBoolean

    End Sub

    Private Sub SetSelectCableTextboxesVisible(ByVal valueBoolean As Boolean)

        txtCablePartNumber.Visible = valueBoolean
        txtCableDescription.Visible = valueBoolean
        txtCableJobType.Visible = valueBoolean
        btnBack.Visible = valueBoolean
        btnNext.Visible = valueBoolean
        btnSelectPartNumber.Visible = valueBoolean

    End Sub

    Private Sub SetReturnCableControlsVisible(ByVal valueBoolean As Boolean)

        cboTransactionID.Visible = valueBoolean
        txtCategory.Visible = valueBoolean
        txtPartNumber.Visible = valueBoolean
        txtReelID.Visible = valueBoolean
        txtDate.Visible = valueBoolean
        txtWarehouse.Visible = valueBoolean
        txtCurrentFootage.Visible = valueBoolean

    End Sub

    Private Sub btnAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click

        'Setting local variables
        Dim blnFatalError As Boolean
        Dim intNumberOfRecords As Integer
        Dim strValueForValidation As String
        Dim strErrorMessage As String

        'Setting up if statements
        If btnAdd.Text = "Return Reel" Then  'This routine will run if the user is adding an employee
            With TheReturnCableReelBindingSource
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

            SetReturnCableControlsVisible(True)
            SetVisibleRadioButtons(True)

            'Setting up fields with auto-data to avoid having the user do it.
            mintNumuberOfRecords = cboTransactionID.Items.Count
            intNumberOfRecords = mintNumuberOfRecords + 1000

            strLogDateTime = CStr(LogDateTime)
            txtWarehouse.Text = CStr(Logon.mintWarehouseID)
            txtDate.Text = strLogDateTime

            mintReelTransactionID = intNumberOfRecords
            Logon.mintReelTransactionID = CInt(mintReelTransactionID)

            CableTransactionID.Show()

            mintReelTransactionID = CInt(Logon.mintReelTransactionID)

            cboTransactionID.Text = CStr(mintReelTransactionID)

            btnAdd.Enabled = False

        Else  'This else statement runs when the record is saved

            'Beginning Data Validation
            strValueForValidation = txtReelID.Text
            blnFatalError = TheInputDataValidation.VerifyTextData(strValueForValidation)
            strErrorMessage = "The Reel ID was not Entered"
            If blnFatalError = False Then
                strValueForValidation = txtCurrentFootage.Text
                strErrorMessage = "The Current Footage Entered is not an Integer"
                blnFatalError = TheInputDataValidation.VerifyIntegerData(strValueForValidation)
            End If

            If blnFatalError = True Then
                MessageBox.Show(strErrorMessage, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            'Setting Global Variables for Updating Tables
            Logon.mstrCategory = txtCategory.Text
            Logon.mstrPartNumber = txtPartNumber.Text
            Logon.mstrReelID = txtReelID.Text
            Logon.mstrWarehouse = txtWarehouse.Text
            Logon.mintCurrentFootage = CInt(txtCurrentFootage.Text)
            Logon.mstrReelCategory = mstrCableCategory

            VerifyReelType()
            blnFatalError = Logon.mbolFatalError

            If blnFatalError = True Then
                MessageBox.Show("The Cable Reel Category is Incorrect", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtCategory.Text = ""
                Exit Sub
            End If

            UpdateReturnedCableReel.Show()

            If Logon.mbolFatalError = True Then
                MessageBox.Show("Reel Information Not Found", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            If Logon.mbolFootageIsNotZero = True Then
                MessageBox.Show("Footage Is Not Zero", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            UpdateManagerQueue.Show()
            UpdateIssueCableTable.Show()

            If Logon.mbolFatalError = True Then
                MessageBox.Show("No Fucking Clue", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            'Try Catch to update the Data Base
            Try
                TheReturnCableReelBindingSource.EndEdit()
                TheReturnCableReelDataTier.UpdateReturnCableReelDB(TheReturnCableReelDataSet)
                addingBoolean = False
                editingBoolean = False
                ResetButtonAfterEditing()
                setComboBoxBinding()
                setControlsReadOnly(True)
                cboTransactionID.SelectedIndex = previousSelectedIndex
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If

    End Sub
End Class