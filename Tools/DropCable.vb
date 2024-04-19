﻿'Title:         Add/Edit Drop Cable
'Date:          1/4/14
'Author:        Terry Holmes

'Description:   This Module is used to set the Initial Drop Cable

Option Strict On

Public Class DropCable

    'Setting Modular Variables

    'Setting Variables for the Cable Type Boxes

    Private TheDropCableDataSet As DropCableDataSet
    Private TheDropCableDataTier As CableDataTier
    Private WithEvents TheDropCableBindingSource As BindingSource

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

    Dim mintEmployeeComboBoxUpperLimit As Integer = 0

    Dim mintReelTransactionID As Integer

    Private Sub btnAdministrativeMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdministrativeMenu.Click

        'This Button will call the Administrative Menu
        AdministrativeMenu.Show()
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

    Private Sub btnCableAdministration_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCableAdministration.Click

        'Calls the Cable Administration Menu
        CableAdministrationMenu.Show()
        Me.Close()

    End Sub

    Private Sub setComboBoxBinding()

        'Sets the Combobox Bindings
        With Me.cboTypeID
            If (addingBoolean Or editingBoolean) Then
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.OnValidation
                .DropDownStyle = ComboBoxStyle.Simple
            Else
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.Never
                .DropDownStyle = ComboBoxStyle.DropDownList
            End If
        End With

        With Me.cboReelTransactionID
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
            txtPartNumber.ReadOnly = valueBoolean
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
        previousSelectedIndex = cboReelTransactionID.SelectedIndex
        setComboBoxBinding()

    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click


        mintSelectedIndexCounter = mintSelectedIndexCounter + 1
        cboTypeID.SelectedIndex = mintSelectedIndex(mintSelectedIndexCounter)

        btnBack.Enabled = True

        If mintSelectedIndexCounter = mintSelectedIndexUpperLimit Then
            btnNext.Enabled = False
        End If

    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click

        mintSelectedIndexCounter = mintSelectedIndexCounter - 1
        cboTypeID.SelectedIndex = mintSelectedIndex(mintSelectedIndexCounter)

        btnNext.Enabled = True

        If mintSelectedIndexCounter = 0 Then
            btnBack.Enabled = False
        End If

    End Sub

    Private Sub btnSelectPartNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectPartNumber.Click

        If btnAdd.Text = "Save" Then
            txtPartNumber.Text = txtCableTypePartNumber.Text
        Else
            MessageBox.Show("You Can Only Select the Cable Type When Either Editing or Saving a Record", "Please Try Again", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub DropCable_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim strCategory As String

        'Try - Catch for Cable Type
        Try

            txtCategory.Visible = True

            

            setControlsReadOnly(True)

            cboTypeID.SelectedIndex = 0

            mintEmployeeComboBoxUpperLimit = cboTypeID.Items.Count - 1
            mintSelectedIndexCounter = 0
            mintSelectedIndexUpperLimit = 0

            For intCounter = 0 To mintEmployeeComboBoxUpperLimit

                cboTypeID.SelectedIndex = intCounter
                strCategory = txtCategory.Text
                If strCategory = "DROP CABLE" Then
                    mintSelectedIndex(mintSelectedIndexCounter) = intCounter
                    mintSelectedIndexCounter = mintSelectedIndexCounter + 1
                End If

            Next
            mintSelectedIndexUpperLimit = mintSelectedIndexCounter - 1
            mintSelectedIndexCounter = 0
            cboTypeID.SelectedIndex = mintSelectedIndex(0)
            btnNext.Enabled = True
            txtCategory.Visible = False

        Catch ex As Exception

            'If an exception is thrown, it is rounted here
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        'Try - Catch for Coax
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
            With cboReelTransactionID
                .DataSource = TheDropCableBindingSource
                .DisplayMember = "ReelTransactionID"
                .DataBindings.Add("text", TheDropCableBindingSource, "ReelTransactionID", False, DataSourceUpdateMode.Never)
            End With

            'Setting the data binding for the text boxes
            txtReelID.DataBindings.Add("text", TheDropCableBindingSource, "ReelID")
            txtPartNumber.DataBindings.Add("text", TheDropCableBindingSource, "PartNumber")
            txtCurrentFootage.DataBindings.Add("text", TheDropCableBindingSource, "CurrentFootage")
            txtDate.DataBindings.Add("text", TheDropCableBindingSource, "Date")
            txtWarehouse.DataBindings.Add("text", TheDropCableBindingSource, "Warehouse")
            txtNotes.DataBindings.Add("text", TheDropCableBindingSource, "Notes")

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
            With TheDropCableBindingSource
                .EndEdit()
                .AddNew()
            End With

            'Calling sub-routines and setting call values
            addingBoolean = True
            setComboBoxBinding()
            cboReelTransactionID.Focus()
            setControlsReadOnly(False)
            setButtonsForEdit()
            If cboReelTransactionID.SelectedIndex <> -1 Then
                previousSelectedIndex = cboReelTransactionID.Items.Count - 1
            Else
                previousSelectedIndex = 0
            End If

            'Setting up fields with auto-data to avoid having the user do it.
            mintNumuberOfRecords = cboReelTransactionID.Items.Count
            intNumberOfRecords = mintNumuberOfRecords + 1000

            strLogDateTime = CStr(LogDateTime)
            txtWarehouse.Text = Logon.mstrHomeOffice
            txtDate.Text = strLogDateTime

            mintReelTransactionID = intNumberOfRecords
            Logon.mintReelTransactionID = CInt(mintReelTransactionID)

            CableTransactionID.Show()

            mintReelTransactionID = CInt(Logon.mintReelTransactionID)

            cboReelTransactionID.Text = CStr(mintReelTransactionID)

        Else  'This else statement runs when the record is saved

            blnFatalError = False
            strValueForValidation = txtPartNumber.Text
            strErrorMessage = "The Part Number Was Not Entered"
            blnFatalError = TheInputDataValidation.VerifyTextData(strValueForValidation)
            If blnFatalError = False Then
                strValueForValidation = txtCurrentFootage.Text
                strErrorMessage = "Current Footage Entered is not an Integer"
                blnFatalError = TheInputDataValidation.VerifyIntegerData(strValueForValidation)
                If blnFatalError = False Then
                    strValueForValidation = txtReelID.Text
                    strErrorMessage = "The Reel ID was not Entered"
                    blnFatalError = TheInputDataValidation.VerifyTextData(strValueForValidation)
                    If blnFatalError = False Then
                        strValueForValidation = txtDate.Text
                        strErrorMessage = "The Date Entered is not a Date"
                        blnFatalError = TheInputDataValidation.VerifyStartingEndingDatesAsDates(strValueForValidation)
                        If blnFatalError = False Then
                            strValueForValidation = txtWarehouse.Text
                            strErrorMessage = "The Warehouse was not Entered"
                            blnFatalError = TheInputDataValidation.VerifyTextData(strValueForValidation)
                        End If
                    End If
                End If
            End If


            If blnFatalError = True Then
                MessageBox.Show(strErrorMessage, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            'Updating Database
            Try
                TheDropCableBindingSource.EndEdit()
                TheDropCableDataTier.UpdateDropCableDB(TheDropCableDataSet)
                addingBoolean = False
                editingBoolean = False
                setControlsReadOnly(True)
                ResetButtonAfterEditing()
                setComboBoxBinding()
                cboReelTransactionID.SelectedIndex = previousSelectedIndex

            Catch ex As Exception
                MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If

    End Sub

    Private Sub btnCreateReelID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateReelID.Click

        Dim strValueForValidation As String
        Dim blnFatalError As Boolean = False

        'This will Open the Create Reel ID Form
        If btnAdd.Text = "Save" Then

            strValueForValidation = txtPartNumber.Text
            blnFatalError = TheInputDataValidation.VerifyTextData(strValueForValidation)

            If blnFatalError = True Then
                MessageBox.Show("The Part Number Was Not Entered", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Logon.mstrCablePartNumber = txtPartNumber.Text

            CreateReelID.Show()
            txtReelID.Text = Logon.mstrReelID
        Else
            MessageBox.Show("You Can Only Select the Cable Type When Either Editing or Saving a Record", "Please Try Again", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

End Class