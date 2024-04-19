'Title:         Create A Vendor
'Date:          11-10-14
'Author:        Terry Holmes

'Description:   This form is used for creating a vendor

Option Strict On

Public Class CreateAVendor

    'Setting global variables
    Private addingBoolean As Boolean = False
    Private editingBoolean As Boolean = False
    Private previousSelectedIndex As Integer
    Dim mintNumuberOfRecords As Integer
    Dim LogDateTime As Date = DateAndTime.Now
    Dim strLogDateTime As String

    'Creating the validation object
    Dim TheInputDataValidation As New InputDataValidation

    'Creating the Data Set objects
    Private TheVendorsDataSet As VendorsDataSet
    Private TheVendorsDataTier As VendorDataTier
    Private WithEvents TheVendorsBindingSource As BindingSource

    'Setting up search array
    Dim mintCounter As Integer
    Dim mintSelectedIndex() As Integer
    Dim mintUpperLimit As Integer
    Dim mintNumberOfCharacters As Integer

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        'Closes the Program
        CloseTheProgram.ShowDialog()

    End Sub

    Private Sub btnMainMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMainMenu.Click

        'Opens up the Main Menu
        MainMenu.Show()
        Me.Close()

    End Sub
    Private Sub setComboBoxBinding()

        'Sets the Combobox Bindings
        With cboVendorID
            If (addingBoolean Or editingBoolean) Then
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.OnValidation
                .DropDownStyle = ComboBoxStyle.Simple
            Else
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.Never
                .DropDownStyle = ComboBoxStyle.DropDownList
            End If
        End With

    End Sub

    Private Sub btnAdministrativeMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdministrativeMenu.Click

        'This will display the Administrative Menu
        LastTransaction.Show()
        AdministrativeMenu.Show()
        Me.Close()

    End Sub
    Private Sub SetControlsReadOnly(ByVal valueBoolean As Boolean)

        'This will set the control to Read Only
        txtAddress.ReadOnly = valueBoolean
        txtCity.ReadOnly = valueBoolean
        txtContactName.ReadOnly = valueBoolean
        txtEmail.ReadOnly = valueBoolean
        txtPhone.ReadOnly = valueBoolean
        txtZip.ReadOnly = valueBoolean
        txtVendorName.ReadOnly = valueBoolean
        txtState.ReadOnly = valueBoolean
        txtVendorType.ReadOnly = valueBoolean

    End Sub

    Private Sub CreateAVendor_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Loading up the controls
        Logon.mstrLastTransactionSummary = "Loaded Create A Vendor"
        Dim intNumberOfRecords As Integer

        Try

            'This will load the Vendor Objects
            TheVendorsDataTier = New VendorDataTier
            TheVendorsDataSet = TheVendorsDataTier.GetVendorsinformation
            TheVendorsBindingSource = New BindingSource

            'Setting up the bindingsource
            With TheVendorsBindingSource
                .DataSource = TheVendorsDataSet
                .DataMember = "vendors"
                .MoveFirst()
                .MoveLast()
            End With

            'Setting up the combo box
            With cboVendorID
                .DataSource = TheVendorsBindingSource
                .DisplayMember = "VendorID"
                .DataBindings.Add("text", TheVendorsBindingSource, "VendorID", False, DataSourceUpdateMode.Never)
            End With

            'Binding the Rest of The Controls
            txtVendorName.DataBindings.Add("text", TheVendorsBindingSource, "VendorName")
            txtContactName.DataBindings.Add("text", TheVendorsBindingSource, "ContactName")
            txtVendorType.DataBindings.Add("text", TheVendorsBindingSource, "VendorType")
            txtAddress.DataBindings.Add("text", TheVendorsBindingSource, "Address")
            txtCity.DataBindings.Add("text", TheVendorsBindingSource, "City")
            txtState.DataBindings.Add("text", TheVendorsBindingSource, "State")
            txtZip.DataBindings.Add("text", TheVendorsBindingSource, "Zip")
            txtPhone.DataBindings.Add("text", TheVendorsBindingSource, "Phone")
            txtEmail.DataBindings.Add("text", TheVendorsBindingSource, "Email")

            intNumberOfRecords = cboVendorID.Items.Count - 1
            ReDim mintSelectedIndex(intNumberOfRecords * 2)

            SetControlsReadOnly(True)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        'Setting up the local variables
        Dim strValueForValidation As String = ""
        Dim blnFatalError As Boolean = False
        Dim strErrorMessage As String = ""
        Dim blnThereIsAProblem As Boolean = False

        'This routine will add or save a record
        If btnAdd.Text = "Add" Then

            SetControlsReadOnly(False)
            btnAdd.Text = "Save"

            'Setting the binding source
            With TheVendorsBindingSource
                .EndEdit()
                .AddNew()
            End With

            'Setting up the variables to add a record
            addingBoolean = True
            setComboBoxBinding()
            cboVendorID.Focus()

            'Setting the binding source up
            If cboVendorID.SelectedIndex <> -1 Then
                previousSelectedIndex = cboVendorID.Items.Count - 1
            Else
                previousSelectedIndex = 0
            End If

            'Setting up the text for the combo box
            CreateVendorID.Show()
            cboVendorID.Text = CStr(Logon.mintCreatedTransactionID)

        Else

            blnFatalError = False

            'Beginning Data Validation
            strValueForValidation = txtVendorName.Text
            blnFatalError = TheInputDataValidation.VerifyTextData(strValueForValidation)
            If blnFatalError = True Then
                blnThereIsAProblem = True
                strErrorMessage = strErrorMessage + "Vendor Name is Missing" + vbNewLine
            End If

            strValueForValidation = txtContactName.Text
            blnFatalError = TheInputDataValidation.VerifyTextData(strValueForValidation)
            If blnFatalError = True Then
                blnThereIsAProblem = True
                strErrorMessage = strErrorMessage + "Contact Name is Missing" + vbNewLine
            End If

            strValueForValidation = txtVendorType.Text
            blnFatalError = TheInputDataValidation.VerifyTextData(strValueForValidation)
            If blnFatalError = True Then
                blnThereIsAProblem = True
                strErrorMessage = strErrorMessage + "Vendor Type is Missing" + vbNewLine
            End If

            strValueForValidation = txtAddress.Text
            blnFatalError = TheInputDataValidation.VerifyTextData(strValueForValidation)
            If blnFatalError = True Then
                blnThereIsAProblem = True
                strErrorMessage = strErrorMessage + "Address is Missing" + vbNewLine
            End If

            strValueForValidation = txtCity.Text
            blnFatalError = TheInputDataValidation.VerifyTextData(strValueForValidation)
            If blnFatalError = True Then
                blnThereIsAProblem = True
                strErrorMessage = strErrorMessage + "City is Missing" + vbNewLine
            End If

            strValueForValidation = txtState.Text
            blnFatalError = TheInputDataValidation.VerifyTextData(strValueForValidation)
            If blnFatalError = True Then
                blnThereIsAProblem = True
                strErrorMessage = strErrorMessage + "State is Missing" + vbNewLine
            End If

            strValueForValidation = txtZip.Text
            blnFatalError = TheInputDataValidation.VerifyTextData(strValueForValidation)
            If blnFatalError = True Then
                blnThereIsAProblem = True
                strErrorMessage = strErrorMessage + "Zip Code is Missing" + vbNewLine
            End If

            strValueForValidation = txtPhone.Text
            blnFatalError = TheInputDataValidation.VerifyPhoneNumberFormat(strValueForValidation)
            If blnFatalError = True Then
                blnThereIsAProblem = True
                strErrorMessage = strErrorMessage + "Phone Number is not the Correct Format of (xxx) xxx-xxxx" + vbNewLine
            End If

            strValueForValidation = cboVendorID.Text
            blnFatalError = TheInputDataValidation.VerifyIntegerData(strValueForValidation)
            If blnFatalError = True Then
                blnThereIsAProblem = True
                strErrorMessage = strErrorMessage + "Vendor ID is not an Integer" + vbNewLine
            End If
      

        If blnThereIsAProblem = True Then
            MessageBox.Show(strErrorMessage, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        'Continuing to save the record
        Try

            'Saving the record
            TheVendorsBindingSource.EndEdit()
            TheVendorsDataTier.UpdateVendorsDB(TheVendorsDataSet)
            addingBoolean = False
            editingBoolean = False
            setComboBoxBinding()
            cboVendorID.SelectedIndex = previousSelectedIndex
            btnAdd.Text = "Add"
            SetControlsReadOnly(True)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        End If

    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click

        editingBoolean = True
        setComboBoxBinding()
        btnAdd.Text = "Save"
        SetControlsReadOnly(False)

    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        'This will search the text boxes for search

        'Setting up local variables
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim strInformationForSearch As String
        Dim strInformationFromTable As String
        Dim blnFatalError As Boolean = False
        Dim blnItemNotFound = True

        intNumberOfRecords = cboVendorID.Items.Count - 1
        mintCounter = 0

        'Setting up initial navagation buttons
        btnNext.Enabled = False
        btnBack.Enabled = False

        'Checking to see which search function will be done
        If txtSearchCompanyName.Text <> "" Then

            'this will load the variables
            strInformationForSearch = txtSearchCompanyName.Text

            'beginning loop
            For intCounter = 0 To intNumberOfRecords

                'incrementing the combo box
                cboVendorID.SelectedIndex = intCounter

                strInformationFromTable = txtVendorName.Text

                If strInformationForSearch = strInformationFromTable Then

                    mintSelectedIndex(mintCounter) = intCounter
                    mintCounter += 1
                    blnItemNotFound = False

                End If
            Next

        ElseIf txtSearchContactName.Text <> "" Then

            'this will load the variables
            strInformationForSearch = txtSearchContactName.Text

            'beginning loop
            For intCounter = 0 To intNumberOfRecords

                'incrementing the combo box
                cboVendorID.SelectedIndex = intCounter

                strInformationFromTable = txtContactName.Text

                If strInformationForSearch = strInformationFromTable Then

                    mintSelectedIndex(mintCounter) = intCounter
                    mintCounter += 1
                    blnItemNotFound = False

                End If
            Next

        ElseIf txtSearchPhone.Text <> "" Then

            'this will load the variables
            strInformationForSearch = txtSearchPhone.Text

            'beginning loop
            For intCounter = 0 To intNumberOfRecords

                'incrementing the combo box
                cboVendorID.SelectedIndex = intCounter

                strInformationFromTable = txtPhone.Text

                If strInformationForSearch = strInformationFromTable Then

                    mintSelectedIndex(mintCounter) = intCounter
                    mintCounter += 1
                    blnItemNotFound = False

                End If
            Next

        ElseIf txtSearchVendorType.Text <> "" Then

            'this will load the variables
            strInformationForSearch = txtSearchVendorType.Text

            'beginning loop
            For intCounter = 0 To intNumberOfRecords

                'incrementing the combo box
                cboVendorID.SelectedIndex = intCounter

                strInformationFromTable = txtVendorType.Text

                If strInformationForSearch = strInformationFromTable Then

                    mintSelectedIndex(mintCounter) = intCounter
                    mintCounter += 1
                    blnItemNotFound = False

                End If
            Next

        Else
            MessageBox.Show("No Information Was Placed In Search Boxes", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If blnItemNotFound = True Then
            MessageBox.Show("The Information Requested was not Found", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        mintUpperLimit = mintCounter - 1
        mintCounter = 0
        If mintUpperLimit > 0 Then
            btnNext.Enabled = True
        End If

        cboVendorID.SelectedIndex = mintSelectedIndex(0)
        txtSearchCompanyName.Text = ""
        txtSearchContactName.Text = ""
        txtSearchPhone.Text = ""
        txtSearchVendorType.Text = ""


    End Sub
    

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click

        'Incrementing the combo box
        mintCounter += 1
        cboVendorID.SelectedIndex = mintSelectedIndex(mintCounter)

        'Enabling the control
        btnBack.Enabled = True

        'Checking for end
        If mintCounter = mintUpperLimit Then
            btnNext.Enabled = False
        End If

    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click

        'Decrementing the combo box
        mintCounter -= 1
        cboVendorID.SelectedIndex = mintSelectedIndex(mintCounter)

        'Enabling the control
        btnNext.Enabled = True

        'Checking for end
        If mintCounter = 0 Then
            btnBack.Enabled = False
        End If

    End Sub
End Class