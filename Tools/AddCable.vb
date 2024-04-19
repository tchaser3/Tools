'Title:         Add Cable Not Recieved
'Date:          1/10/14
'Author:        Terry Holmes

'Description:   This form is used to Add Cable

Option Strict On

Public Class AddCable

    'Setting Modular Variables

    'Setting Variables for the Cable Type Boxes
    Dim TheInputDataValidation As New InputDataValidation
    Dim TheKeyWordClass As New KeyWordSearchClass

    Private ThePartNumberDataSet As PartNumberDataSet
    Private ThePartNumberDataTier As PartDataTier
    Private WithEvents ThePartNumberBindingSource As BindingSource

    Dim LogDateTime As Date = DateAndTime.Now
    Dim strLogDateTime As String

    'Setting global variable
    Dim mintSelectedIndex() As Integer
    Dim mintCounter As Integer
    Dim mintUpperLimit As Integer

    Dim mintReelTransactionID As Integer
    Dim mstrCableJobTypeForSearch As String

    Private Sub btnAdministrativeMenu_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdministrativeMenu.Click

        LastTransaction.Show()
        AdministrativeMenu.Show()
        Me.Close()

    End Sub


    Private Sub btnCableAdminMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCableAdminMenu.Click

        LastTransaction.Show()
        CableAdministrationMenu.Show()
        Me.Close()

    End Sub

    Private Sub btnMainMenu_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMainMenu.Click

        LastTransaction.Show()
        MainMenu.Show()
        Me.Close()

    End Sub

    Private Sub btnClose_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        CloseTheProgram.ShowDialog()

    End Sub
    Private Sub btnSelectPartNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectPartNumber.Click

        'This will load the information in the correct control
        SetTransactionControlsVisible(True)
        strLogDateTime = CStr(LogDateTime)
        txtWarehouse.Text = CStr(Logon.mintWarehouseID)
        txtDate.Text = strLogDateTime
        txtWarehouseEmployeeID.Text = CStr(Logon.mintEmployeeID)
        txtPartNumber.Text = txtCablePartNumber.Text
        txtJobType.Text = txtCableJobType.Text

        CableTransactionID.Show()

        mintReelTransactionID = CInt(Logon.mintReelTransactionID)

        txtTransactionID.Text = CStr(mintReelTransactionID)
        btnCreateReelID.Enabled = True

    End Sub
    Private Sub btnCreateReelID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateReelID.Click

        Dim strValueForValidation As String
        Dim blnFatalError As Boolean = False

        'This will Open the Create Reel ID Form
        strValueForValidation = txtPartNumber.Text
        blnFatalError = TheInputDataValidation.VerifyTextData(strValueForValidation)

        If blnFatalError = True Then
            MessageBox.Show("Part Number Not Entered", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Logon.mstrCablePartNumber = txtPartNumber.Text

        CreateReelID.Show()
        txtReelID.Text = Logon.mstrReelID

    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click


        mintCounter = mintCounter + 1
        cboPartID.SelectedIndex = mintSelectedIndex(mintCounter)

        btnBack.Enabled = True

        If mintCounter = mintUpperLimit Then
            btnNext.Enabled = False
        End If

    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click

        mintCounter = mintCounter - 1
        cboPartID.SelectedIndex = mintSelectedIndex(mintCounter)

        btnNext.Enabled = True

        If mintCounter = 0 Then
            btnBack.Enabled = False
        End If

    End Sub


    Private Sub AddCable_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Setting local variables
        Dim intNumberOfRecords As Integer

        'Try - Catch for Cable Type
        Try

            txtJobType.Visible = True

            'This will bind the controls to the data source
            ThePartNumberDataTier = New PartDataTier
            ThePartNumberDataSet = ThePartNumberDataTier.GetPartNumberInformation
            ThePartNumberBindingSource = New BindingSource

            With ThePartNumberBindingSource
                .DataSource = ThePartNumberDataSet
                .DataMember = "partnumbers"
                .MoveFirst()
                .MoveLast()
            End With

            With cboPartID
                .DataSource = ThePartNumberBindingSource
                .DisplayMember = "PartID"
                .DataBindings.Add("text", ThePartNumberBindingSource, "PartID", False, DataSourceUpdateMode.Never)
            End With

            txtCablePartNumber.DataBindings.Add("text", ThePartNumberBindingSource, "PartNumber")
            txtCableDescription.DataBindings.Add("text", ThePartNumberBindingSource, "Description")
            txtCableJobType.DataBindings.Add("text", ThePartNumberBindingSource, "Type")
            txtCablePartType.DataBindings.Add("text", ThePartNumberBindingSource, "PartType")

            intNumberOfRecords = cboPartID.Items.Count - 1
            ReDim mintSelectedIndex(intNumberOfRecords)

            Logon.mstrLastTransactionSummary = "LOADED ADD CABLE FORM"

            SetCableControlsVisible(False)
            SetTransactionControlsVisible(False)

        Catch ex As Exception

            'If an exception is thrown, it is rounted here
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub
    Private Sub SetCableControlsVisible(ByVal valueBoolean As Boolean)

        txtCableDescription.Visible = valueBoolean
        txtCableJobType.Visible = valueBoolean
        txtCablePartNumber.Visible = valueBoolean
        txtCablePartType.Visible = valueBoolean

    End Sub
    Private Sub SetTransactionControlsVisible(ByVal valueBoolean As Boolean)

        txtJobType.Visible = valueBoolean
        txtDate.Visible = valueBoolean
        txtNotes.Visible = valueBoolean
        txtPartNumber.Visible = valueBoolean
        txtReelID.Visible = valueBoolean
        txtTWReelID.Visible = valueBoolean
        txtTransactionID.Visible = valueBoolean
        txtCurrentFootage.Visible = valueBoolean
        txtWarehouse.Visible = valueBoolean
        txtWarehouseEmployeeID.Visible = valueBoolean

    End Sub

    Private Sub ClearTextBoxes()

        txtJobType.Text = ""
        txtDate.Text = ""
        txtNotes.Text = ""
        txtPartNumber.Text = ""
        txtReelID.Text = ""
        txtTWReelID.Text = ""
        txtTransactionID.Text = ""
        txtCurrentFootage.Text = ""
        txtWarehouse.Text = ""
        txtWarehouseEmployeeID.Text = ""

    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        'Setting local variables
        Dim blnFatalError As Boolean = False
        Dim blnThereIsAProblem As Boolean = False
        Dim strValueForValidation As String
        Dim strErrorMessage As String = ""

        'Setting up if statements
        'Performing Data Validation
            blnFatalError = False
            strValueForValidation = txtPartNumber.Text
            blnFatalError = TheInputDataValidation.VerifyTextData(strValueForValidation)
            If blnFatalError = True Then
                blnThereIsAProblem = True
                strErrorMessage = strErrorMessage + "Part Number Not Entered" + vbNewLine
            End If

            strValueForValidation = txtCurrentFootage.Text
            blnFatalError = TheInputDataValidation.VerifyIntegerData(strValueForValidation)
            If blnFatalError = True Then
                blnThereIsAProblem = True
                strErrorMessage = strErrorMessage + "Value Not Entered Was Not An Integer" + vbNewLine
            Else
                blnFatalError = TheInputDataValidation.VerifyIntegerRange(strValueForValidation)
                If blnFatalError = True Then
                    blnThereIsAProblem = True
                    strErrorMessage = strErrorMessage + "The Value Entered is out of Range" + vbNewLine
                End If
            End If

            strValueForValidation = txtReelID.Text
            blnFatalError = TheInputDataValidation.VerifyTextData(strValueForValidation)
            If blnFatalError = True Then
                blnThereIsAProblem = True
                strErrorMessage = strErrorMessage + "Reel ID Was Not Entered" + vbNewLine
            End If

            strValueForValidation = txtDate.Text
            blnFatalError = TheInputDataValidation.VerifyStartingEndingDatesAsDates(strValueForValidation)
            If blnFatalError = True Then
                blnThereIsAProblem = True
                strErrorMessage = strErrorMessage + "Date Informtion is not a Date" + vbNewLine
            End If


            strValueForValidation = txtWarehouse.Text
            blnFatalError = TheInputDataValidation.VerifyTextData(strValueForValidation)
            If blnFatalError = True Then
                blnThereIsAProblem = True
                strErrorMessage = strErrorMessage + "Warehouse Information was not Entered" + vbNewLine
            End If

            If blnThereIsAProblem = True Then
                MessageBox.Show(strErrorMessage, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

        'Loading up Global Variables
        Logon.mstrCategory = txtJobType.Text
        Logon.mstrCablePartNumber = txtPartNumber.Text
        Logon.mstrReelID = txtReelID.Text
        Logon.mstrTWReelID = txtTWReelID.Text
        Logon.mintCurrentFootage = CInt(txtCurrentFootage.Text)
        Logon.mdatDate = CDate(txtDate.Text)
        Logon.mstrWarehouse = txtWarehouse.Text
        Logon.mintWarehouseEmployeeID = CInt(txtWarehouseEmployeeID.Text)
        Logon.mstrNotes = txtNotes.Text

        Logon.mstrLastTransactionSummary = "The Last Transction for Adding Cable with a Transaction ID " + txtTransactionID.Text + " For " + txtPartNumber.Text + " With Reel ID " + txtReelID.Text + " With Footage of " + txtCurrentFootage.Text


        'Validation for Category
        Logon.mstrReelCategory = txtJobType.Text

        blnFatalError = Logon.mbolFatalError

        If blnFatalError = True Then
            MessageBox.Show("The Cable Type is not Correct", "Please Try Again", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtJobType.Text = ""
            Exit Sub
        End If

        AddCableUpdateTables.Show()

        If Logon.mbolFatalError = True Then
            MessageBox.Show("Reel ID Entered is Already Used", "Please Try Again", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        LastTransaction.Show()

        btnCreateReelID.Enabled = False
        ClearTextBoxes()
        SetTransactionControlsVisible(False)

    End Sub

    Private Sub btnFindCable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindCable.Click

        'This will use the keyword class to find all the cable types
        'setting local variables
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim strCableDescriptionForSearch As String
        Dim strCableDescriptionFromTable As String
        Dim blnItemNotFound As Boolean = True
        Dim blnKeyWordNotFound As Boolean
        Dim blnFatalError As Boolean = True
        Dim strPartType As String

        'Setting controls initial conditions
        btnBack.Enabled = False
        btnNext.Enabled = False
        btnSelectPartNumber.Enabled = False

        'Performing data validation
        strCableDescriptionForSearch = txtEnterCableDescription.Text
        blnFatalError = TheInputDataValidation.VerifyTextData(strCableDescriptionForSearch)
        If blnFatalError = True Then
            MessageBox.Show("Cable Type Was Not Entered", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        'getting ready for the loop
        intNumberOfRecords = cboPartID.Items.Count - 1
        mintCounter = 0
        SetCableControlsVisible(True)

        'Beginning the loop
        For intCounter = 0 To intNumberOfRecords

            'Incrementing the combo box
            cboPartID.SelectedIndex = intCounter

            'getting part description
            strCableDescriptionFromTable = txtCableDescription.Text
            strPartType = txtCablePartType.Text

            'Checking for the key word
            blnKeyWordNotFound = TheKeyWordClass.FindKeyWord(strCableDescriptionForSearch, strCableDescriptionFromTable)

            'Checking to see if the keyword
            If strPartType = "CABLE" Then
                If blnKeyWordNotFound = False Then
                    mintSelectedIndex(mintCounter) = intCounter
                    mintCounter += 1
                    blnItemNotFound = False
                End If
            End If

        Next

        'Checking to see if the keyword is found
        If blnItemNotFound = True Then
            txtEnterCableDescription.Text = ""
            MessageBox.Show("Cable Description Was Not Found", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        'Setting up the controls
        mintUpperLimit = mintCounter - 1
        mintCounter = 0
        If mintUpperLimit > 0 Then
            btnNext.Enabled = True
        End If
        cboPartID.SelectedIndex = mintSelectedIndex(0)
        btnSelectPartNumber.Enabled = True

    End Sub
End Class