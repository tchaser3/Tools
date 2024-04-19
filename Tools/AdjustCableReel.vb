'Title:         Adjust Cable Reel Footage
'Date:          6/19/14
'Author:        Terry Holmes

'Description:   This form is used to correct the footage on the reel and have the warehouse employee 
'               Explain why

'Updated On:    12-2-15
'Update:        Changed the form for more a key word search and putting the listed transactions in a grid view

Option Strict On

Public Class AdjustCableReel

    'Setting Modular Variables

    'Setting Variables for the Cable Type Boxes
    Private TheAdjustCableReelDataSet As AdjustCableReelDataSet
    Private TheAdjustCableReelDataTier As CableDataTier
    Private WithEvents TheAdjustCableReelBindingSource As BindingSource

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

    Private TheSpecialityCableDataSet As SpecialityCableDataSet
    Private TheSpecialityCableDataTier As CableDataTier
    Private WithEvents TheSpecialityCableBindingSource As BindingSource

    Dim TheInputDataValidation As New InputDataValidation
    Dim TheKeyWordSearchClass As New KeyWordSearchClass
    Dim TheCheckTimeWarnerPartNumber As New CheckTimeWarnerPartNumber

    Private addingBoolean As Boolean = False
    Private editingBoolean As Boolean = False
    Private previousSelectedIndex As Integer
    Dim mintNumuberOfRecords As Integer

    Dim LogDateTime As Date = DateAndTime.Now
    Dim strLogDateTime As String

    Structure Cable
        Dim mintTransactionID As Integer
        Dim mstrReelID As String
        Dim mstrPartNumber As String
        Dim mintFootage As Integer
        Dim mstrCableType As String
    End Structure

    Dim structCoax() As Cable
    Dim mintCoaxCounter As Integer
    Dim mintCoaxUpperLimit As Integer

    Dim structDrop() As Cable
    Dim mintDropCounter As Integer
    Dim mintDropUpperLimit As Integer

    Dim structFiber() As Cable
    Dim mintFiberCounter As Integer
    Dim mintFiberUpperLimit As Integer

    Dim structSpeciality() As Cable
    Dim mintSpecialityCounter As Integer
    Dim mintSpecialityUpperLimit As Integer

    Dim structTwistedPair() As Cable
    Dim mintTwistedCounter As Integer
    Dim mintTwistedUpperLimit As Integer

    Structure SearchResults
        Dim mintTransactionID As Integer
        Dim mstrPartNumber As String
        Dim mstrDescription As String
        Dim mintWarehouseID As Integer
        Dim mstrReelID As String
        Dim mstrNotes As String
        Dim mstrCableType As String
        Dim mintOldFootage As Integer
        Dim mintNewFootage As Integer
        Dim mintEmployeeID As Integer
    End Structure

    Dim structSearchResults() As SearchResults
    Dim mintResultCounter As Integer
    Dim mintResultUpperLimit As Integer

    Dim mstrErrorMessage As String
    Dim mintWarehouseIDForSearch As Integer

    Structure Parts
        Dim mintPartID As Integer
        Dim mstrPartNumber As String
        Dim mstrDescription As String
    End Structure

    Dim structParts() As Parts
    Dim mintPartCounter As Integer
    Dim mintPartUpperLimit As Integer

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        CloseTheProgram.ShowDialog()
    End Sub

    Private Sub btnMainMenu_Click(sender As Object, e As EventArgs) Handles btnMainMenu.Click

        LastTransaction.Show()
        MainMenu.Show()
        Me.Close()

    End Sub

    Private Sub btnAdministrativeMenu_Click(sender As Object, e As EventArgs) Handles btnAdministrativeMenu.Click

        LastTransaction.Show()
        AdministrativeMenu.Show()
        Me.Close()

    End Sub

    Private Sub btnCableAdminMenu_Click(sender As Object, e As EventArgs) Handles btnCableAdminMenu.Click

        LastTransaction.Show()
        CableAdministrationMenu.Show()
        Me.Close()

    End Sub

    Private Sub AdjustCableReel_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'setting local variables
        Dim blnFatalError As Boolean = False

        Logon.mstrLastTransactionSummary = "Loaded Adjust Cable Reel Form"
        mintWarehouseIDForSearch = Logon.mintPartsWarehouseID

        PleaseWait.Show()

        ClearDataBindings()
        blnFatalError = SetCoaxDataBindings()
        If blnFatalError = False Then
            LoadCoaxStructure()
        End If
        If blnFatalError = False Then
            ClearDataBindings()
            blnFatalError = SetPartNumberDataBindings()
        End If
        If blnFatalError = False Then
            ClearDataBindings()
            blnFatalError = SetDropCableDataBindings()
        End If
        If blnFatalError = False Then
            LoadDropCableStructure()
        End If
        If blnFatalError = False Then
            ClearDataBindings()
            blnFatalError = SetFiberDataBindings()
        End If
        If blnFatalError = False Then
            LoadFiberCableStructure()
        End If
        If blnFatalError = False Then
            ClearDataBindings()
            blnFatalError = SetTwistedPairDataBindings()
        End If
        If blnFatalError = False Then
            LoadTwistedPairCableStructure()
        End If
        If blnFatalError = False Then
            ClearDataBindings()
            blnFatalError = SetSpecialityDataBindings()
        End If
        If blnFatalError = False Then
            LoadSpecialityCableStructure()
        End If

        'creating grid
        dgvSearchResults.ColumnCount = 11
        dgvSearchResults.Columns(0).Name = "Transaction ID"
        dgvSearchResults.Columns(0).Width = 75
        dgvSearchResults.Columns(1).Name = "Warehouse ID"
        dgvSearchResults.Columns(1).Width = 75
        dgvSearchResults.Columns(2).Name = "Cable Type"
        dgvSearchResults.Columns(2).Width = 75
        dgvSearchResults.Columns(3).Name = "Part Number"
        dgvSearchResults.Columns(3).Width = 75
        dgvSearchResults.Columns(4).Name = "Description"
        dgvSearchResults.Columns(4).Width = 150
        dgvSearchResults.Columns(5).Name = "Reel ID"
        dgvSearchResults.Columns(5).Width = 75
        dgvSearchResults.Columns(6).Name = "Old Footage"
        dgvSearchResults.Columns(6).Width = 100
        dgvSearchResults.Columns(7).Name = "New Footage"
        dgvSearchResults.Columns(7).Width = 100
        dgvSearchResults.Columns(8).Name = "Employee ID"
        dgvSearchResults.Columns(8).Width = 75
        dgvSearchResults.Columns(9).Name = "Notes"
        dgvSearchResults.Columns(9).Width = 200
        dgvSearchResults.Columns(10).Name = "Change Reel"
        dgvSearchResults.Columns(10).Width = 75

        PleaseWait.Close()

        If blnFatalError = True Then
            btnFindReel.Enabled = False
            MessageBox.Show(mstrErrorMessage, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Function SetPartNumberDataBindings() As Boolean

        'setting local variables
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim blnFatalError As Boolean = False
        Dim blnNotTimeWarnerPart As Boolean

        'try catch for exceptions
        Try

            ThePartNumberDataTier = New PartDataTier
            ThePartNumberDataSet = ThePartNumberDataTier.GetPartNumberInformation
            ThePartNumberBindingSource = New BindingSource

            'setting up the binding source
            With ThePartNumberBindingSource
                .DataSource = ThePartNumberDataSet
                .DataMember = "partnumbers"
                .MoveFirst()
                .MoveLast()
            End With

            'setting up the combo box
            With cboTransactionID
                .DataSource = ThePartNumberBindingSource
                .DisplayMember = "PartID"
                .DataBindings.Add("text", ThePartNumberBindingSource, "PartID", False, DataSourceUpdateMode.Never)
            End With

            'setting up the rest of the controls
            txtPartNumber.DataBindings.Add("text", ThePartNumberBindingSource, "PartNumber")
            txtNotes.DataBindings.Add("text", ThePartNumberBindingSource, "Description")

            'preparing for loop
            intNumberOfRecords = cboTransactionID.Items.Count - 1
            ReDim structParts(intNumberOfRecords)
            mintPartCounter = 0

            'for loop to fill structure
            For intCounter = 0 To intNumberOfRecords

                'incrementing the combo box
                cboTransactionID.SelectedIndex = intCounter

                'loading structure
                structParts(mintPartCounter).mintPartID = CInt(cboTransactionID.Text)
                structParts(mintPartCounter).mstrDescription = txtNotes.Text
                structParts(mintPartCounter).mstrPartNumber = txtPartNumber.Text
                mintPartCounter += 1
            Next

            mintPartUpperLimit = mintPartCounter - 1
            mintPartCounter = 0

            Return blnFatalError

        Catch ex As Exception

            mstrErrorMessage = ex.Message
            blnFatalError = True

            Return blnFatalError

        End Try


    End Function
    Private Function SetSpecialityDataBindings() As Boolean

        'setting local variables
        Dim blnFatalError As Boolean = False

        'try catch for exceptions
        Try
            'setting the data variables
            TheSpecialityCableDataTier = New CableDataTier
            TheSpecialityCableDataSet = TheSpecialityCableDataTier.GetSpecialityCableInformation
            TheSpecialityCableBindingSource = New BindingSource

            With TheSpecialityCableBindingSource
                .DataSource = TheSpecialityCableDataSet
                .DataMember = "specialitycable"
                .MoveFirst()
                .MoveLast()
            End With

            'setting up the combo box
            With cboTransactionID
                .DataSource = TheSpecialityCableBindingSource
                .DisplayMember = "ReelTransactionID"
                .DataBindings.Add("text", TheSpecialityCableBindingSource, "ReelTransactionID", False, DataSourceUpdateMode.Never)
            End With

            'setting up the rest of the consetting up the text box
            txtReelID.DataBindings.Add("text", TheSpecialityCableBindingSource, "ReelID")
            txtPartNumber.DataBindings.Add("Text", TheSpecialityCableBindingSource, "PartNumber")
            txtOldFootage.DataBindings.Add("text", TheSpecialityCableBindingSource, "CurrentFootage")
            txtWarehouseID.DataBindings.Add("text", TheSpecialityCableBindingSource, "WarehouseID")

            Return blnFatalError

        Catch ex As Exception

            mstrErrorMessage = ex.Message
            blnFatalError = True

            Return blnFatalError

        End Try

    End Function
    Private Function SetTwistedPairDataBindings() As Boolean

        'setting local variable
        Dim blnFatalError As Boolean = False

        'try catch for exceptions
        Try

            'setting the data variables
            TheTwistedPairDataTier = New CableDataTier
            TheTwistedPairDataSet = TheTwistedPairDataTier.GetTwistedPairInformation
            TheTwistedPairBindingSource = New BindingSource

            With TheTwistedPairBindingSource
                .DataSource = TheTwistedPairDataSet
                .DataMember = "twistedpair"
                .MoveFirst()
                .MoveLast()
            End With

            'setting up the combo box
            With cboTransactionID
                .DataSource = TheTwistedPairBindingSource
                .DisplayMember = "ReelTransactionID"
                .DataBindings.Add("text", TheTwistedPairBindingSource, "ReelTransactionID", False, DataSourceUpdateMode.Never)
            End With

            'setting up the rest of the consetting up the text box
            txtReelID.DataBindings.Add("text", TheTwistedPairBindingSource, "ReelID")
            txtPartNumber.DataBindings.Add("Text", TheTwistedPairBindingSource, "PartNumber")
            txtOldFootage.DataBindings.Add("text", TheTwistedPairBindingSource, "CurrentFootage")
            txtWarehouseID.DataBindings.Add("text", TheTwistedPairBindingSource, "WarehouseID")

            Return blnFatalError

        Catch ex As Exception

            mstrErrorMessage = ex.Message
            blnFatalError = True

            Return blnFatalError

        End Try

    End Function
    Private Function SetFiberDataBindings() As Boolean

        'setting local variable
        Dim blnFatalError As Boolean = False

        'try catch for exceptions
        Try

            'setting the data variables
            TheFiberDataTier = New CableDataTier
            TheFiberDataSet = TheFiberDataTier.GetFiberInformation
            TheFiberBindingSource = New BindingSource

            'setting up the binding source
            With TheFiberBindingSource
                .DataSource = TheFiberDataSet
                .DataMember = "fiber"
                .MoveFirst()
                .MoveLast()
            End With

            'setting up the combo box
            With cboTransactionID
                .DataSource = TheFiberBindingSource
                .DisplayMember = "ReelTransactionID"
                .DataBindings.Add("text", TheFiberBindingSource, "ReelTransactionID", False, DataSourceUpdateMode.Never)
            End With

            'setting up the rest of the consetting up the text box
            txtReelID.DataBindings.Add("text", TheFiberBindingSource, "ReelID")
            txtPartNumber.DataBindings.Add("Text", TheFiberBindingSource, "PartNumber")
            txtOldFootage.DataBindings.Add("text", TheFiberBindingSource, "CurrentFootage")
            txtWarehouseID.DataBindings.Add("text", TheFiberBindingSource, "WarehouseID")

            Return blnFatalError

        Catch ex As Exception

            mstrErrorMessage = ex.Message
            blnFatalError = True

            Return blnFatalError

        End Try

    End Function
    Private Sub LoadSpecialityCableStructure()

        'setting local variables
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim intWarehouseIDFromTable As Integer
        Dim blnItemsNotFound As Boolean = True

        'setting up for the loop
        intNumberOfRecords = cboTransactionID.Items.Count - 1
        ReDim structSpeciality(intNumberOfRecords)
        mintSpecialityCounter = 0

        'beginning loop
        For intCounter = 0 To intNumberOfRecords

            'incrementing the combo box
            cboTransactionID.SelectedIndex = intCounter

            intWarehouseIDFromTable = CInt(txtWarehouseID.Text)

            If intWarehouseIDFromTable = mintWarehouseIDForSearch Then

                'loading the structure
                structSpeciality(mintSpecialityCounter).mintTransactionID = CInt(cboTransactionID.Text)
                structSpeciality(mintSpecialityCounter).mintFootage = CInt(txtOldFootage.Text)
                structSpeciality(mintSpecialityCounter).mstrPartNumber = txtPartNumber.Text
                structSpeciality(mintSpecialityCounter).mstrReelID = txtReelID.Text
                structSpeciality(mintSpecialityCounter).mstrCableType = "SPECIALITY"
                mintSpecialityCounter += 1
                blnItemsNotFound = False

            End If
        Next

        If blnItemsNotFound = False Then
            mintSpecialityUpperLimit = mintSpecialityCounter - 1
            mintSpecialityCounter = 0
        ElseIf blnItemsNotFound = True Then
            mintSpecialityUpperLimit = 0
        End If

    End Sub

    Private Sub LoadTwistedPairCableStructure()

        'setting local variables
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim intWarehouseIDFromTable As Integer
        Dim blnItemsNotFound As Boolean = True

        'setting up for the loop
        intNumberOfRecords = cboTransactionID.Items.Count - 1
        ReDim structTwistedPair(intNumberOfRecords)
        mintTwistedCounter = 0

        'beginning loop
        For intCounter = 0 To intNumberOfRecords

            'incrementing the combo box
            cboTransactionID.SelectedIndex = intCounter

            intWarehouseIDFromTable = CInt(txtWarehouseID.Text)

            If intWarehouseIDFromTable = mintWarehouseIDForSearch Then

                'loading the structure
                structTwistedPair(mintTwistedCounter).mintTransactionID = CInt(cboTransactionID.Text)
                structTwistedPair(mintTwistedCounter).mintFootage = CInt(txtOldFootage.Text)
                structTwistedPair(mintTwistedCounter).mstrPartNumber = txtPartNumber.Text
                structTwistedPair(mintTwistedCounter).mstrReelID = txtReelID.Text
                structTwistedPair(mintTwistedCounter).mstrCableType = "TWISTED"
                mintTwistedCounter += 1
                blnItemsNotFound = False

            End If
        Next

        If blnItemsNotFound = False Then
            mintTwistedUpperLimit = mintTwistedCounter - 1
            mintTwistedCounter = 0
        ElseIf blnItemsNotFound = True Then
            mintTwistedUpperLimit = 0
        End If

    End Sub
    Private Sub LoadFiberCableStructure()

        'setting local variables
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim intWarehouseIDFromTable As Integer
        Dim blnItemsNotFound As Boolean = True

        'setting up for the loop
        intNumberOfRecords = cboTransactionID.Items.Count - 1
        ReDim structFiber(intNumberOfRecords)
        mintFiberCounter = 0

        'beginning loop
        For intCounter = 0 To intNumberOfRecords

            'incrementing the combo box
            cboTransactionID.SelectedIndex = intCounter

            intWarehouseIDFromTable = CInt(txtWarehouseID.Text)

            If intWarehouseIDFromTable = mintWarehouseIDForSearch Then

                'loading the structure
                structFiber(mintFiberCounter).mintTransactionID = CInt(cboTransactionID.Text)
                structFiber(mintFiberCounter).mintFootage = CInt(txtOldFootage.Text)
                structFiber(mintFiberCounter).mstrPartNumber = txtPartNumber.Text
                structFiber(mintFiberCounter).mstrReelID = txtReelID.Text
                structFiber(mintFiberCounter).mstrCableType = "FIBER"
                mintFiberCounter += 1
                blnItemsNotFound = False

            End If
        Next

        If blnItemsNotFound = False Then
            mintFiberUpperLimit = mintFiberCounter - 1
            mintFiberCounter = 0
        ElseIf blnItemsNotFound = True Then
            mintFiberUpperLimit = 0
        End If

    End Sub
    Private Sub LoadDropCableStructure()

        'setting local variables
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim intWarehouseIDFromTable As Integer
        Dim blnItemsNotFound As Boolean = True

        'setting up for the loop
        intNumberOfRecords = cboTransactionID.Items.Count - 1
        ReDim structDrop(intNumberOfRecords)
        mintDropCounter = 0

        'beginning loop
        For intCounter = 0 To intNumberOfRecords

            'incrementing the combo box
            cboTransactionID.SelectedIndex = intCounter

            intWarehouseIDFromTable = CInt(txtWarehouseID.Text)

            If intWarehouseIDFromTable = mintWarehouseIDForSearch Then

                'loading the structure
                structDrop(mintDropCounter).mintTransactionID = CInt(cboTransactionID.Text)
                structDrop(mintDropCounter).mintFootage = CInt(txtOldFootage.Text)
                structDrop(mintDropCounter).mstrPartNumber = txtPartNumber.Text
                structDrop(mintDropCounter).mstrReelID = txtReelID.Text
                structDrop(mintDropCounter).mstrCableType = "DROP"
                mintDropCounter += 1
                blnItemsNotFound = False

            End If
        Next

        If blnItemsNotFound = False Then
            mintDropUpperLimit = mintDropCounter - 1
            mintDropCounter = 0
        ElseIf blnItemsNotFound = True Then
            mintDropUpperLimit = 0
        End If

    End Sub
    Private Function SetDropCableDataBindings() As Boolean

        'setting local variables
        Dim blnFatalError As Boolean

        Try

            'setting the data variables
            TheDropCableDataTier = New CableDataTier
            TheDropCableDataSet = TheDropCableDataTier.GetDropCableInformation
            TheDropCableBindingSource = New BindingSource

            'setting up the binding source
            With TheDropCableBindingSource
                .DataSource = TheDropCableDataSet
                .DataMember = "dropcable"
                .MoveFirst()
                .MoveLast()
            End With

            'setting up the combo box
            With cboTransactionID
                .DataSource = TheDropCableBindingSource
                .DisplayMember = "ReelTransactionID"
                .DataBindings.Add("text", TheDropCableBindingSource, "ReelTransactionID", False, DataSourceUpdateMode.Never)
            End With

            'setting up the rest of the consetting up the text box
            txtReelID.DataBindings.Add("text", TheDropCableBindingSource, "ReelID")
            txtPartNumber.DataBindings.Add("Text", TheDropCableBindingSource, "PartNumber")
            txtOldFootage.DataBindings.Add("text", TheDropCableBindingSource, "CurrentFootage")
            txtWarehouseID.DataBindings.Add("text", TheDropCableBindingSource, "WarehouseID")

            'returning value to calling sub routine
            Return blnFatalError

        Catch ex As Exception

            mstrErrorMessage = ex.Message
            blnFatalError = True

            'returning value to calling sub routine
            Return blnFatalError

        End Try
    End Function
    Private Sub LoadCoaxStructure()

        'setting local variables
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim intWarehouseIDFromTable As Integer
        Dim blnItemsNotFound As Boolean = True

        'setting up for the loop
        intNumberOfRecords = cboTransactionID.Items.Count - 1
        ReDim structCoax(intNumberOfRecords)
        ReDim structSearchResults(intNumberOfRecords * 5)
        mintCoaxCounter = 0

        'beginning loop
        For intCounter = 0 To intNumberOfRecords

            'incrementing the combo box
            cboTransactionID.SelectedIndex = intCounter

            intWarehouseIDFromTable = CInt(txtWarehouseID.Text)

            If intWarehouseIDFromTable = mintWarehouseIDForSearch Then

                'loading the structure
                structCoax(mintCoaxCounter).mintTransactionID = CInt(cboTransactionID.Text)
                structCoax(mintCoaxCounter).mintFootage = CInt(txtOldFootage.Text)
                structCoax(mintCoaxCounter).mstrPartNumber = txtPartNumber.Text
                structCoax(mintCoaxCounter).mstrReelID = txtReelID.Text
                structCoax(mintCoaxCounter).mstrCableType = "COAX"
                mintCoaxCounter += 1
                blnItemsNotFound = False

            End If
        Next

        If blnItemsNotFound = False Then
            mintCoaxUpperLimit = mintCoaxCounter - 1
            mintCoaxCounter = 0
        ElseIf blnItemsNotFound = True Then
            mintCoaxUpperLimit = 0
        End If

    End Sub
    Private Function SetCoaxDataBindings() As Boolean

        Dim blnFatalError As Boolean = False

        'try catch for exceptions
        Try

            'setting the data variables
            TheCoaxDataTier = New CableDataTier
            TheCoaxDataSet = TheCoaxDataTier.GetCoaxInformation
            TheCoaxBindingSource = New BindingSource

            'setting up the binding source
            With TheCoaxBindingSource
                .DataSource = TheCoaxDataSet
                .DataMember = "coax"
                .MoveFirst()
                .MoveLast()
            End With

            'setting up the binding source
            With cboTransactionID
                .DataSource = TheCoaxBindingSource
                .DisplayMember = "ReelTransactionID"
                .DataBindings.Add("text", TheCoaxBindingSource, "ReelTransactionID", False, DataSourceUpdateMode.Never)
            End With

            'setting up the text box
            txtReelID.DataBindings.Add("text", TheCoaxBindingSource, "ReelID")
            txtPartNumber.DataBindings.Add("Text", TheCoaxBindingSource, "PartNumber")
            txtOldFootage.DataBindings.Add("text", TheCoaxBindingSource, "CurrentFootage")
            txtWarehouseID.DataBindings.Add("text", TheCoaxBindingSource, "WarehouseID")

            'value returned to calling sub-routine
            Return blnFatalError

        Catch ex As Exception

            'message to user
            mstrErrorMessage = ex.Message
            blnFatalError = True

            'value returned to calling sub-routine
            Return blnFatalError

        End Try

    End Function
    Private Sub ClearDataBindings()

        cboTransactionID.DataBindings.Clear()
        txtCableType.DataBindings.Clear()
        txtEmployeeID.DataBindings.Clear()
        txtNewFootage.DataBindings.Clear()
        txtOldFootage.DataBindings.Clear()
        txtPartNumber.DataBindings.Clear()
        txtReelID.DataBindings.Clear()
        txtWarehouseID.DataBindings.Clear()

    End Sub

    Private Sub btnFindReel_Click(sender As Object, e As EventArgs) Handles btnFindReel.Click

        'this proceedure will find any reel that matches the criteria
        Dim intPartCounter As Integer
        Dim intCableCounter As Integer
        Dim blnFatalError As Boolean = False
        Dim blnThereIsAProblem As Boolean = False
        Dim strReelIDForSearch As String
        Dim strCableDescriptionForSearch As String
        Dim strReelIDFromTable As String
        Dim strCableDescriptionFromTable As String
        Dim blnPartKeyWordNotFound As Boolean
        Dim blnReelKeyWordNotFound As Boolean
        Dim strErrorMessage As String = ""
        Dim blnNoItemsFound As Boolean = True
        Dim strPartNumberForSearch As String
        Dim strPartNumberFromTable As String
        Dim intCurrentFootage As Integer
        Dim strCableType As String

        'setting up data validation
        strReelIDForSearch = txtEnterReelID.Text
        blnFatalError = TheInputDataValidation.VerifyTextData(strReelIDForSearch)
        If blnFatalError = True Then
            blnThereIsAProblem = True
            strErrorMessage = strErrorMessage + "The Reel ID Was Not Found" + vbNewLine
        End If
        strCableDescriptionForSearch = txtEnterCable.Text
        blnFatalError = TheInputDataValidation.VerifyTextData(strCableDescriptionForSearch)
        If blnFatalError = True Then
            blnThereIsAProblem = True
            strErrorMessage = strErrorMessage + "The Cable was not Entered" + vbNewLine
        End If
        If blnThereIsAProblem = True Then
            MessageBox.Show(strErrorMessage, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        'Getting ready for the loop
        mintResultCounter = 0
        strCableType = "COAX"

        'beginning loop
        For intPartCounter = 0 To mintPartUpperLimit

            strCableDescriptionFromTable = structParts(intPartCounter).mstrDescription

            blnPartKeyWordNotFound = TheKeyWordSearchClass.FindKeyWord(strCableDescriptionForSearch, strCableDescriptionFromTable)

            If blnPartKeyWordNotFound = False Then

                'loading up the part number
                strPartNumberForSearch = structParts(intPartCounter).mstrPartNumber

                'searching cable
                For intCableCounter = 0 To mintCoaxUpperLimit

                    strPartNumberFromTable = structCoax(intCableCounter).mstrPartNumber

                    If strPartNumberForSearch = strPartNumberFromTable Then

                        'getting reel id
                        strReelIDFromTable = structCoax(intCableCounter).mstrReelID

                        'checking keyword
                        blnReelKeyWordNotFound = TheKeyWordSearchClass.FindKeyWord(strReelIDForSearch, strReelIDFromTable)

                        If blnReelKeyWordNotFound = False Then

                            'calling structure
                            intCurrentFootage = structCoax(intCableCounter).mintFootage
                            LoadSearchResultsStructure(strReelIDFromTable, strPartNumberForSearch, strCableDescriptionFromTable, strCableType, intCurrentFootage)
                            blnNoItemsFound = False

                        End If

                    End If

                Next

            End If

        Next

        mintResultUpperLimit = mintResultCounter - 1
        mintResultCounter = 0


    End Sub
    Private Sub LoadSearchResultsStructure(ByVal strReelID As String, ByVal strPartNumber As String, ByVal strCableDescription As String, ByVal strCableType As String, ByVal intOldFootage As Integer)

        'this will load the structure
        CableTransactionID.Show()
        structSearchResults(mintResultCounter).mintTransactionID = Logon.mintReelTransactionID
        structSearchResults(mintResultCounter).mintWarehouseID = Logon.mintPartsWarehouseID
        structSearchResults(mintResultCounter).mintOldFootage = intOldFootage
        structSearchResults(mintResultCounter).mstrPartNumber = strPartNumber
        structSearchResults(mintResultCounter).mstrReelID = strReelID
        structSearchResults(mintResultCounter).mintEmployeeID = Logon.mintEmployeeID
        structSearchResults(mintResultCounter).mstrCableType = strCableType
        structSearchResults(mintResultCounter).mstrDescription = strCableDescription
        mintResultCounter += 1

    End Sub
    Private Sub LoadDataGridView()


    End Sub
End Class