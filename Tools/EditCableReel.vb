'Title:         Edit Cable Reel
'Date:          6/25/14
'Author:        Terry Holmes

'Description:   This form is used to edit a Cable Reel

Option Strict On

Public Class EditCableReel

    'Setting Variables for the Cable Type Boxes
    

    Private TheCoaxDataSet As CoaxDataSet
    Private TheCoaxDataTier As CableDataTier
    Private WithEvents TheCoaxBindingSource As BindingSource

    Private TheDropCableDataSet As DropCableDataSet
    Private TheDropCableDataTier As CableDataTier
    Private WithEvents TheDropCableBindingSource As BindingSource

    Private TheFiberDataSet As FiberDataSet
    Private TheFiberDataTier As CableDataTier
    Private WithEvents TheFiberBindingSource As BindingSource

    Private TheTwistedPairDataSet As TwistedPairDataSet
    Private TheTwistedPairDataTier As CableDataTier
    Private WithEvents TheTwistedPairBindingSource As BindingSource

    Private TheSpecialtyCableDataSet As SpecialityCableDataSet
    Private TheSpecialtyCableDataTier As CableDataTier
    Private WithEvents TheSpecialtyCableBindingSource As BindingSource

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

    Dim mintCableCounter As Integer
    Dim mintCableSelectedIndex(10000) As Integer
    Dim mintCableUpperLimit As Integer

    Dim mstrCableJobType As String
    Dim mstrPartNumberForSearch As String

    Private Sub btnAdministrativeMenu_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdministrativeMenu.Click

        AdministrativeMenu.Show()
        Me.Close()

    End Sub

    Private Sub btnCableAdminMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCableAdminMenu.Click

        CableAdministrationMenu.Show()
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

    Private Sub EditCableReel_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Setting up the cable type try catch
        Try

            'Setting up data sets
            ThePartNumberDataTier = New PartDataTier
            ThePartNumberDataSet = ThePartNumberDataTier.GetPartNumberInformation
            ThePartNumberBindingSource = New BindingSource

            'Setting up Binding Source
            With ThePartNumberBindingSource
                .DataSource = ThePartNumberDataSet
                .DataMember = "partnumbers"
                .MoveFirst()
                .MoveLast()
            End With

            'Setting up combo box
            With cboPartID
                .DataSource = ThePartNumberBindingSource
                .DisplayMember = "PartID"
                .DataBindings.Add("text", ThePartNumberBindingSource, "PartID", False, DataSourceUpdateMode.Never)
            End With

            'Setting up other controls
            txtCablePartNumber.DataBindings.Add("text", ThePartNumberBindingSource, "PartNumber")
            txtCableDescription.DataBindings.Add("text", ThePartNumberBindingSource, "Description")
            txtCablePartType.DataBindings.Add("text", ThePartNumberBindingSource, "PartType")
            txtCableJobType.DataBindings.Add("text", ThePartNumberBindingSource, "Type")

            MakeCableTypeControlsVisible(False)
            MakeEnterReelIDControlsVisible(False)
            MakeCableInformationControlsVisible(False)


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub MakeCableInformationControlsVisible(ByVal valueBoolean As Boolean)

        'This will make the cable controls visible
        txtNotes.Visible = valueBoolean
        txtPartNumber.Visible = valueBoolean
        txtReelID.Visible = valueBoolean
        txtTWReelID.Visible = valueBoolean
        txtWarehouseID.Visible = valueBoolean
        txtCurrentFootage.Visible = valueBoolean
        btnSaveEdit.Visible = valueBoolean

    End Sub
    Private Sub MakeCableTypeControlsVisible(ByVal valueBoolean As Boolean)

        'This will set the visibility for the control
        txtCableDescription.Visible = valueBoolean
        txtCablePartNumber.Visible = valueBoolean
        txtCableJobType.Visible = valueBoolean
        txtCablePartType.Visible = valueBoolean
        btnBack.Visible = valueBoolean
        btnNext.Visible = valueBoolean
        btnSelectPartNumber.Visible = valueBoolean

    End Sub
    Private Sub MakeEnterReelIDControlsVisible(ByVal valueBoolean As Boolean)

        'This will make the Reel ID Controls Visible
        txtEnterReelID.Visible = valueBoolean
        btnFindReel.Visible = valueBoolean

    End Sub
    Private Sub FindCablePartNumbers()

        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim strCableJobTypeFromTable As String
        Dim strCableJobTypeForSearch As String
        Dim strCablePartTypeFromTable As String

        btnBack.Enabled = False
        btnNext.Enabled = False
        btnSelectPartNumber.Enabled = True

        strCableJobTypeForSearch = mstrCableJobType

        'Setting up for Loop
        intNumberOfRecords = cboPartID.Items.Count - 1
        mintCableCounter = 0

        'Peforming Loop
        For intCounter = 0 To intNumberOfRecords

            'Getting information for comparing categories
            cboPartID.SelectedIndex = intCounter
            strCableJobTypeFromTable = txtCableJobType.Text
            strCablePartTypeFromTable = txtCablePartType.Text

            'Compairing Categories
            If strCablePartTypeFromTable = "CABLE" Then
                If strCableJobTypeForSearch = strCableJobTypeFromTable Then

                    'Setting array for navigation
                    mintCableSelectedIndex(mintCableCounter) = intCounter
                    mintCableCounter = mintCableCounter + 1

                End If
            End If
        Next

        'Setting up for navigation
        mintCableUpperLimit = mintCableCounter - 1
        mintCableCounter = 0

        If mintCableUpperLimit > 0 Then
            btnNext.Enabled = True
        End If

        cboPartID.SelectedIndex = mintCableSelectedIndex(0)

    End Sub

    Private Sub rdoCoax_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoCoax.CheckedChanged

        'Setting the radio button and making controls visible
        mstrCableJobType = "COAX"
        MakeCableTypeControlsVisible(True)
        FindCablePartNumbers()
    End Sub

    Private Sub rdoFiber_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoFiber.CheckedChanged
        'Setting the radio button and making controls visible
        mstrCableJobType = "FIBER"
        MakeCableTypeControlsVisible(True)
        FindCablePartNumbers()
    End Sub

    Private Sub rdoDropCable_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoDropCable.CheckedChanged
        'Setting the radio button and making controls visible
        mstrCableJobType = "DROP CABLE"
        MakeCableTypeControlsVisible(True)
        FindCablePartNumbers()
    End Sub

    Private Sub rdoTwistedPair_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoTwistedPair.CheckedChanged
        'Setting the radio button and making controls visible
        mstrCableJobType = "TWISTED PAIR"
        MakeCableTypeControlsVisible(True)
        FindCablePartNumbers()
    End Sub

    Private Sub rdoSpecialtyCable_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoSpecialtyCable.CheckedChanged
        'Setting the radio button and making controls visible
        mstrCableJobType = "SPECIALTY CABLE"
        MakeCableTypeControlsVisible(True)
        FindCablePartNumbers()
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click

        'This will increment the counter
        mintCableCounter = mintCableCounter + 1
        cboPartID.SelectedIndex = mintCableSelectedIndex(mintCableCounter)

        'Enabling the Back button
        btnBack.Enabled = True

        'Disabling the next button
        If mintCableCounter = mintCableUpperLimit Then
            btnNext.Enabled = False
        End If

    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click

        'This will increment the counter
        mintCableCounter = mintCableCounter - 1
        cboPartID.SelectedIndex = mintCableSelectedIndex(mintCableCounter)

        'enabling the next button
        btnNext.Enabled = True

        'Disabling the back button
        If mintCableCounter = 0 Then
            btnBack.Enabled = False
        End If

    End Sub
    Private Sub EnableRadioButtons(ByVal valueBoolean As Boolean)

        'This will enable the radio buttons
        rdoCoax.Enabled = valueBoolean
        rdoDropCable.Enabled = valueBoolean
        rdoFiber.Enabled = valueBoolean
        rdoTwistedPair.Enabled = valueBoolean
        rdoSpecialtyCable.Enabled = valueBoolean

    End Sub

    Private Sub btnSelectPartNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectPartNumber.Click

        'This subroutine will run when the button is pressed
        mstrPartNumberForSearch = txtCablePartNumber.Text
        MakeEnterReelIDControlsVisible(True)
        EnableRadioButtons(False)
        MakeCableTypeControlsVisible(False)

    End Sub
    Private Sub ClearCableTransactionDataBindings()

        'Clears Bindings for the controls
        cboReelTransactionID.DataBindings.Clear()
        txtNotes.DataBindings.Clear()
        txtPartNumber.DataBindings.Clear()
        txtReelID.DataBindings.Clear()
        txtTWReelID.DataBindings.Clear()
        txtWarehouseID.DataBindings.Clear()
        txtCurrentFootage.DataBindings.Clear()

    End Sub
    Private Sub setComboBoxBinding()

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

    Private Sub btnFindReel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindReel.Click

        'Set Local Variables
        Dim strValueForValidation As String
        Dim blnFatalError As Boolean = False
        Dim strReelIDForSearch As String
        Dim strReelIDFromTable As String
        Dim intWarehouseIDForSearch As Integer
        Dim intWarehouseIDFromTable As Integer
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim intSelectedIndex As Integer
        Dim strPartNumberFromTable As String
        Dim blnReelNotFound As Boolean = True

        MakeCableInformationControlsVisible(True)

        strValueForValidation = txtEnterReelID.Text
        blnFatalError = TheInputDataValidation.VerifyTextData(strValueForValidation)

        If blnFatalError = True Then
            MessageBox.Show("The Reel ID was not Entered", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        'Clearing all Data bindings
        ClearCableTransactionDataBindings()

        If mstrCableJobType = "COAX" Then
            SetCoaxDataBindings()
        ElseIf mstrCableJobType = "DROP CABLE" Then
            SetDropCableDataBindings()
        ElseIf mstrCableJobType = "FIBER" Then
            SetFiberDataBindings()
        ElseIf mstrCableJobType = "TWISTED PAIR" Then
            SetTwistedPairDataBindings()
        ElseIf mstrCableJobType = "SPECIALTY CABLE" Then
            SetSpecialtyCableDataBindings()
        End If

        'Getting ready to do the loop
        intNumberOfRecords = cboReelTransactionID.Items.Count - 1
        intWarehouseIDForSearch = CInt(Logon.mintWarehouseID)
        strReelIDForSearch = txtEnterReelID.Text

        'Beginning loop
        For intCounter = 0 To intNumberOfRecords

            'setting variables for Compare
            cboReelTransactionID.SelectedIndex = intCounter
            intWarehouseIDFromTable = CInt(txtWarehouseID.Text)
            strReelIDFromTable = txtReelID.Text
            strPartNumberFromTable = txtPartNumber.Text

            'Comparing information through nested if statements
            If intWarehouseIDForSearch = intWarehouseIDFromTable Then
                If mstrPartNumberForSearch = strPartNumberFromTable Then
                    If strReelIDForSearch = strReelIDFromTable Then

                        'Setting variable to have the Combo Box return there
                        intSelectedIndex = intCounter
                        blnReelNotFound = False

                    End If
                End If
            End If
        Next

        If blnReelNotFound = True Then
            MakeCableInformationControlsVisible(False)
            MessageBox.Show("Reel ID Not Found", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        'setting the conditions for editing the record
        cboReelTransactionID.SelectedIndex = intSelectedIndex
        editingBoolean = True
        setComboBoxBinding()

    End Sub
    Private Sub SetTwistedPairDataBindings()

        'Try - Catch for Coax
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
            With cboReelTransactionID
                .DataSource = TheTwistedPairBindingSource
                .DisplayMember = "ReelTransactionID"
                .DataBindings.Add("text", TheTwistedPairBindingSource, "ReelTransactionID", False, DataSourceUpdateMode.Never)
            End With

            'Setting the data binding for the text boxes
            txtReelID.DataBindings.Add("text", TheTwistedPairBindingSource, "ReelID")
            txtPartNumber.DataBindings.Add("text", TheTwistedPairBindingSource, "PartNumber")
            txtCurrentFootage.DataBindings.Add("text", TheTwistedPairBindingSource, "CurrentFootage")
            txtWarehouseID.DataBindings.Add("text", TheTwistedPairBindingSource, "WarehouseID")
            txtNotes.DataBindings.Add("text", TheTwistedPairBindingSource, "Notes")

        Catch ex As Exception

            'If an exception is thrown, it is rounted here
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

    End Sub
    Private Sub SetSpecialtyCableDataBindings()

        Try

            'This will bind the controls to the data source
            TheSpecialtyCableDataTier = New CableDataTier
            TheSpecialtyCableDataSet = TheSpecialtyCableDataTier.GetSpecialityCableInformation
            TheSpecialtyCableBindingSource = New BindingSource

            'Setting up Binding Source for the Combo Box
            With TheSpecialtyCableBindingSource
                .DataSource = TheSpecialtyCableDataSet
                .DataMember = "specialitycable"
                .MoveFirst()
                .MoveLast()
            End With

            'Setting the data relationship for the Combo Box
            With cboReelTransactionID
                .DataSource = TheSpecialtyCableBindingSource
                .DisplayMember = "ReelTransactionID"
                .DataBindings.Add("text", TheSpecialtyCableBindingSource, "ReelTransactionID", False, DataSourceUpdateMode.Never)
            End With

            'Setting the data binding for the text boxes
            txtReelID.DataBindings.Add("text", TheSpecialtyCableBindingSource, "ReelID")
            txtPartNumber.DataBindings.Add("text", TheSpecialtyCableBindingSource, "PartNumber")
            txtCurrentFootage.DataBindings.Add("text", TheSpecialtyCableBindingSource, "CurrentFootage")
            txtWarehouseID.DataBindings.Add("text", TheSpecialtyCableBindingSource, "WarehouseID")
            txtNotes.DataBindings.Add("text", TheSpecialtyCableBindingSource, "Notes")

        Catch ex As Exception

            'If an exception is thrown, it is rounted here
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

    End Sub
    Private Sub SetFiberDataBindings()

        'Try - Catch for Coax
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
            With cboReelTransactionID
                .DataSource = TheFiberBindingSource
                .DisplayMember = "ReelTransactionID"
                .DataBindings.Add("text", TheFiberBindingSource, "ReelTransactionID", False, DataSourceUpdateMode.Never)
            End With

            'Setting the data binding for the text boxes
            txtReelID.DataBindings.Add("text", TheFiberBindingSource, "ReelID")
            txtTWReelID.DataBindings.Add("text", TheFiberBindingSource, "TWReelID")
            txtPartNumber.DataBindings.Add("text", TheFiberBindingSource, "PartNumber")
            txtCurrentFootage.DataBindings.Add("text", TheFiberBindingSource, "CurrentFootage")
            txtWarehouseID.DataBindings.Add("text", TheFiberBindingSource, "WarehouseID")
            txtNotes.DataBindings.Add("text", TheFiberBindingSource, "Notes")

        Catch ex As Exception

            'If an exception is thrown, it is rounted here
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

    End Sub
    Private Sub SetDropCableDataBindings()

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
            txtWarehouseID.DataBindings.Add("text", TheDropCableBindingSource, "WarehouseID")
            txtNotes.DataBindings.Add("text", TheDropCableBindingSource, "Notes")

        Catch ex As Exception

            'If an exception is thrown, it is rounted here
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
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
            With cboReelTransactionID
                .DataSource = TheCoaxBindingSource
                .DisplayMember = "ReelTransactionID"
                .DataBindings.Add("text", TheCoaxBindingSource, "ReelTransactionID", False, DataSourceUpdateMode.Never)
            End With

            'Setting the data binding for the text boxes
            txtReelID.DataBindings.Add("text", TheCoaxBindingSource, "ReelID")
            txtTWReelID.DataBindings.Add("text", TheCoaxBindingSource, "TWReelID")
            txtPartNumber.DataBindings.Add("text", TheCoaxBindingSource, "PartNumber")
            txtCurrentFootage.DataBindings.Add("text", TheCoaxBindingSource, "CurrentFootage")
            txtWarehouseID.DataBindings.Add("text", TheCoaxBindingSource, "WarehouseID")
            txtNotes.DataBindings.Add("text", TheCoaxBindingSource, "Notes")

        Catch ex As Exception

            'If an exception is thrown, it is rounted here
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub btnResetForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetForm.Click

        'This will set the form back to Original Condition
        ClearCableTransactionDataBindings()
        EnableRadioButtons(True)
        MakeCableInformationControlsVisible(False)
        MakeCableTypeControlsVisible(False)
        MakeEnterReelIDControlsVisible(False)
        rdoCoax.PerformClick()

    End Sub

    Private Sub btnSaveReel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveEdit.Click

        'This subroutine will save the information

        'Setting Local Variables
        Dim strValueForValidation As String
        Dim blnFatalError As Boolean = False
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim strPartNumberForSearch As String
        Dim strPartNumberFromTable As String
        Dim blnPartNumberNotFound As Boolean = True
        Dim intSavedWarehouseID As Integer
        Dim strCategoryFromTable As String
        Dim strErrorMessage As String

        intSavedWarehouseID = CInt(Logon.mintWarehouseID)

        'Beginning Data Validation
        strValueForValidation = txtCurrentFootage.Text
        strErrorMessage = "The Current Footage Entered is not an Integer"
        blnFatalError = TheInputDataValidation.VerifyIntegerData(strValueForValidation)
        If blnFatalError = False Then
            strValueForValidation = txtPartNumber.Text
            strErrorMessage = "The Part Number Was Not Entered"
            blnFatalError = TheInputDataValidation.VerifyTextData(strValueForValidation)
            If blnFatalError = False Then
                strValueForValidation = txtReelID.Text
                strErrorMessage = "The Reel ID was not Entered"
                blnFatalError = TheInputDataValidation.VerifyTextData(strValueForValidation)
                If blnFatalError = False Then
                    strValueForValidation = txtWarehouseID.Text
                    strErrorMessage = "The Warehouse ID is not an Integer"
                    blnFatalError = TheInputDataValidation.VerifyIntegerData(strValueForValidation)
                End If
            End If
        End If

        'Checking to see if there is a validation error
        If blnFatalError = True Then
            MessageBox.Show(strErrorMessage, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        'Checking Part Number to verify that it exists
        intNumberOfRecords = cboPartID.Items.Count - 1
        strPartNumberForSearch = txtPartNumber.Text

        'Performing Loop to verify the part number
        For intCounter = 0 To intNumberOfRecords

            'Loading up variables for comparing
            cboPartID.SelectedIndex = intCounter
            strCategoryFromTable = txtCableJobType.Text
            strPartNumberFromTable = txtCablePartNumber.Text

            'Performing Compare
            If strCategoryFromTable = mstrCableJobType Then
                If strPartNumberForSearch = strPartNumberFromTable Then
                    blnPartNumberNotFound = False
                End If
            End If

        Next

        'Verifying there is a problem or not
        If blnPartNumberNotFound = True Then
            MessageBox.Show("The Part Number Entered is not a Valid Part Number", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        'Checking Warehouse ID for validity
        Logon.mstrCableSelectionType = "EDITREELVERIFY"
        intSavedWarehouseID = CInt(Logon.mintWarehouseID)
        Logon.mintWarehouseID = CInt(txtWarehouseID.Text)
        SelectWarehouse.Show()
        blnFatalError = Logon.mbolFatalError

        If blnFatalError = True Then
            MessageBox.Show("The Warehouse ID Entered is either Not Found or not a Warehouse ID", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Logon.mintWarehouseID = CInt(intSavedWarehouseID)
            Exit Sub
        End If

        Logon.mintWarehouseID = intSavedWarehouseID

        Try
            'Perparing to save edited table
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
            setComboBoxBinding()

            MessageBox.Show(txtEnterReelID.Text + " Has Been Saved", "Thank You", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnResetForm.PerformClick()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "There is a Problem", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class