'Title:         Issue Cable Table Update Form
'Date:          7-7-14
'Author:        Terry Holmes

'Description:   This form is replacing the Individual Issue Cable Type forms for speed and flow

Option Strict On

Public Class IssueCableTableUpdate

    'Setting up global variables for data sets
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

    'Setting up Employee Information
    Private TheEmployeeDataSet As EmployeeDataSet
    Private TheEmployeeDataTier As EmployeeDataTier
    Private WithEvents TheEmployeeBindingSource As BindingSource

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

    Dim mintWarehouseSelectedIndex(100) As Integer
    Dim mintWarehouseSelectedIndexCounter As Integer
    Dim mintWarehouseSelectedIndexUpperLimit As Integer

    Dim mintWarehouseSelected As Integer
    Dim mstrWarehouseName As String
    Dim mintEmployeeComboBoxUpperLimit As Integer = 0

    Dim mintReelTransactionID As Integer
    Dim mstrCableCategory As String

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

        'Setting Employee ID Combo Binding
        With Me.cboWarehouseID
            If (addingBoolean Or editingBoolean) Then
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.OnValidation
                .DropDownStyle = ComboBoxStyle.Simple
            Else
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.Never
                .DropDownStyle = ComboBoxStyle.DropDownList
            End If
        End With

    End Sub
    Private Sub UpdateReelInformation()

        Dim strPartNumberFromTable As String
        Dim strPartNumberForSeach As String
        Dim strReelIDFromTable As String
        Dim strReelIDForSearch As String
        Dim intFootageOnReel As Integer
        Dim intFootagePulled As Integer
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim blnReelIDNotFound As Boolean = True
        Dim intWarehouseFromTable As Integer
        Dim blnReelIssued As Boolean

        'Getting information from Issue Cable Form
        strPartNumberForSeach = IssueCable.mstrPartNumber
        strReelIDForSearch = IssueCable.mstrReelID
        intFootagePulled = IssueCable.mintFootagePulled

        blnReelIssued = IssueCable.mblnIssuedCompleteReel

        'Search for the Reel
        mintSelectedIndexCounter = 0
        mintSelectedIndexUpperLimit = 0
        intNumberOfRecords = cboReelTransactionID.Items.Count - 1

        mintWarehouseSelected = CInt(Logon.mintWarehouseID)

        'Loop to find the reel
        For intCounter = 0 To intNumberOfRecords
            cboReelTransactionID.SelectedIndex = intCounter
            strReelIDFromTable = txtReelID.Text
            strPartNumberFromTable = CStr(txtPartNumber.Text)
            intWarehouseFromTable = CInt(txtWarehouse.Text)

            If strPartNumberForSeach = strPartNumberFromTable Then
                If strReelIDForSearch = strReelIDFromTable Then
                    If intWarehouseFromTable = mintWarehouseSelected Then
                        mintSelectedIndex(mintSelectedIndexCounter) = intCounter
                        mintSelectedIndexCounter = mintSelectedIndexCounter + 1
                        blnReelIDNotFound = False
                    End If
                End If
            End If

        Next

        If blnReelIDNotFound = True Then
            FindWarehouseName()
            IssueCable.mblnReelIDNotFound = True
            Me.Close()
            Exit Sub
        End If

        cboReelTransactionID.SelectedIndex = mintSelectedIndex(0)
        IssueCable.mblnReelIDNotFound = False
        If blnReelIssued = True Then
            IssueCable.mintFootagePulled = CInt(txtCurrentFootage.Text)
        End If

        intFootagePulled = CInt(IssueCable.mintFootagePulled)
        intFootageOnReel = CInt(txtCurrentFootage.Text)

        If intFootagePulled > intFootageOnReel And blnReelIssued = False Then
            IssueCable.mblnFootageGreaterThanReelAmout = True
            Me.Close()
            Exit Sub
        End If

        intFootageOnReel = intFootageOnReel - intFootagePulled

        If intFootageOnReel = 0 Then
            IssueCable.mblnFootageEqualToZero = True
            txtIssuedReel.Text = "YES"
        End If
        txtCurrentFootage.Text = CStr(intFootageOnReel)

        'Updating Database
        Try
            'Making sure the correct table is updated
            If mstrCableCategory = "COAX" Then
                TheCoaxBindingSource.EndEdit()
                TheCoaxDataTier.UpdateCoaxDB(TheCoaxDataSet)
            ElseIf mstrCableCategory = "DROP CABLE" Then
                TheDropCableBindingSource.EndEdit()
                TheDropCableDataTier.UpdateDropCableDB(TheDropCableDataSet)
            ElseIf mstrCableCategory = "FIBER" Then
                TheFiberBindingSource.EndEdit()
                TheFiberDataTier.UpdateFiberDB(TheFiberDataSet)
            ElseIf mstrCableCategory = "TWISTED PAIR" Then
                TheTwistedPairBindingSource.EndEdit()
                TheTwistedPairDataTier.UpdateTwistedPairDB(TheTwistedPairDataSet)
            ElseIf mstrCableCategory = "SPECIALTY CABLE" Then
                TheSpecialtyCableBindingSource.EndEdit()
                TheSpecialtyCableDataTier.UpdateSpecialityCableDB(TheSpecialtyCableDataSet)
            End If

            addingBoolean = False
            editingBoolean = False
            setComboBoxBinding()
            cboReelTransactionID.SelectedIndex = previousSelectedIndex

        Catch ex As Exception
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Me.Close()
    End Sub
    Private Sub FindWarehouseName()

        'This subroutine will find name of the warehouse if there is a failure
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim intSelectedIndex As Integer
        Dim intwarehouseIDFromTable As Integer

        'Setting Objects for Loop
        intNumberOfRecords = cboWarehouseID.Items.Count - 1

        'Beginning Loop
        For intCounter = 0 To intNumberOfRecords

            cboWarehouseID.SelectedIndex = intCounter
            intwarehouseIDFromTable = CInt(cboWarehouseID.Text)

            If intwarehouseIDFromTable = mintWarehouseSelected Then
                intSelectedIndex = intCounter
            End If

        Next

        cboWarehouseID.SelectedIndex = intSelectedIndex
        mstrWarehouseName = txtWarehouseFirstName.Text

    End Sub

    Private Sub IssueCableTableUpdate_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'This loads up the form
        mstrCableCategory = IssueCable.mstrCableCategory

        If mstrCableCategory = "COAX" Then

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
                txtPartNumber.DataBindings.Add("text", TheCoaxBindingSource, "PartNumber")
                txtCurrentFootage.DataBindings.Add("text", TheCoaxBindingSource, "CurrentFootage")
                txtDate.DataBindings.Add("text", TheCoaxBindingSource, "Date")
                txtWarehouse.DataBindings.Add("text", TheCoaxBindingSource, "WarehouseID")
                txtNotes.DataBindings.Add("text", TheCoaxBindingSource, "Notes")
                txtIssuedReel.DataBindings.Add("text", TheCoaxBindingSource, "IssuedReel")
                txtReelEmpty.DataBindings.Add("text", TheCoaxBindingSource, "ReelEmpty")

            Catch ex As Exception

                'If an exception is thrown, it is rounted here
                MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try

        ElseIf mstrCableCategory = "DROP CABLE" Then

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
                txtWarehouse.DataBindings.Add("text", TheDropCableBindingSource, "WarehouseID")
                txtNotes.DataBindings.Add("text", TheDropCableBindingSource, "Notes")
                txtIssuedReel.DataBindings.Add("text", TheDropCableBindingSource, "IssuedReel")
                txtReelEmpty.DataBindings.Add("text", TheDropCableBindingSource, "ReelEmpty")

            Catch ex As Exception

                'If an exception is thrown, it is rounted here
                MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try

        ElseIf mstrCableCategory = "FIBER" Then

            'Try - Catch for Fiber
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
                txtPartNumber.DataBindings.Add("text", TheFiberBindingSource, "PartNumber")
                txtCurrentFootage.DataBindings.Add("text", TheFiberBindingSource, "CurrentFootage")
                txtDate.DataBindings.Add("text", TheFiberBindingSource, "Date")
                txtWarehouse.DataBindings.Add("text", TheFiberBindingSource, "WarehouseID")
                txtNotes.DataBindings.Add("text", TheFiberBindingSource, "Notes")
                txtIssuedReel.DataBindings.Add("text", TheFiberBindingSource, "IssuedReel")
                txtReelEmpty.DataBindings.Add("text", TheFiberBindingSource, "ReelEmpty")

            Catch ex As Exception

                'If an exception is thrown, it is rounted here
                MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try

        ElseIf mstrCableCategory = "TWISTED PAIR" Then

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
                txtDate.DataBindings.Add("text", TheTwistedPairBindingSource, "Date")
                txtWarehouse.DataBindings.Add("text", TheTwistedPairBindingSource, "WarehouseID")
                txtNotes.DataBindings.Add("text", TheTwistedPairBindingSource, "Notes")
                txtIssuedReel.DataBindings.Add("text", TheTwistedPairBindingSource, "IssuedReel")

            Catch ex As Exception

                'If an exception is thrown, it is rounted here
                MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try

        ElseIf mstrCableCategory = "SPECIALTY CABLE" Then

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
                txtDate.DataBindings.Add("text", TheSpecialtyCableBindingSource, "Date")
                txtWarehouse.DataBindings.Add("text", TheSpecialtyCableBindingSource, "WarehouseID")
                txtNotes.DataBindings.Add("text", TheSpecialtyCableBindingSource, "Notes")
                txtIssuedReel.DataBindings.Add("text", TheSpecialtyCableBindingSource, "IssuedReel")
                txtReelEmpty.DataBindings.Add("text", TheSpecialtyCableBindingSource, "ReelEmpty")

            Catch ex As Exception

                'If an exception is thrown, it is rounted here
                MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try

        Else
            MessageBox.Show("The Cable Category Did Not Match", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End If

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

        UpdateReelInformation()

    End Sub
End Class