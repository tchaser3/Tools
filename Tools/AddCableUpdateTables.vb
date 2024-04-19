'Title:         Add Cable Update Table Form
'Date:          7/7/14
'Author:        Terry Holmes

'Description:   This form is used to update all the tables when cable is either added or received

Option Strict On

Public Class AddCableUpdateTables

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

    End Sub
    Private Function VerifyReelIDEntered() As Boolean

        'Setting up the local variables
        Dim blnFatalError As Boolean = False
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim strReelIDForSearch As String
        Dim strReelIDFromTable As String
        Dim intWarehouseIDForSearch As Integer
        Dim intWarehouseIDFromTable As Integer
        Dim strCablePartNumberForSearch As String
        Dim strCablePartNumberFromTable As String

        'Setting up for loop
        intNumberOfRecords = cboReelTransactionID.Items.Count - 1
        strReelIDForSearch = Logon.mstrReelID
        intWarehouseIDForSearch = CInt(Logon.mintWarehouseID)
        strCablePartNumberForSearch = Logon.mstrCablePartNumber

        'Beginning Loop
        For intCounter = 0 To intNumberOfRecords

            'Loading up variables
            cboReelTransactionID.SelectedIndex = intCounter
            strReelIDFromTable = txtReelID.Text
            intWarehouseIDFromTable = CInt(txtWarehouse.Text)
            strCablePartNumberFromTable = txtPartNumber.Text

            'Doing Compare
            If intWarehouseIDForSearch = intWarehouseIDFromTable Then
                If strCablePartNumberForSearch = strCablePartNumberFromTable Then
                    If strReelIDForSearch = strReelIDFromTable Then
                        blnFatalError = True
                    End If
                End If
            End If

        Next

        'Returning value from function
        Return blnFatalError

    End Function

    Private Sub UpdateReelInformation()

        'Setting Local Variables
        Dim strReelID As String
        Dim strPartNumber As String
        Dim strTWReelID As String
        Dim strCurrentFootage As String
        Dim strDate As String
        Dim strWarehouseID As String
        Dim strNotes As String
        Dim blnFatalError As Boolean

        blnFatalError = VerifyReelIDEntered()

        If blnFatalError = True Then
            Logon.mbolFatalError = blnFatalError
        End If

        If blnFatalError = False Then
            'Setting up the Binding Sources
            If mstrCableCategory = "COAX" Then
                With TheCoaxBindingSource
                    .EndEdit()
                    .AddNew()
                End With
            ElseIf mstrCableCategory = "DROP CABLE" Then
                With TheDropCableBindingSource
                    .EndEdit()
                    .AddNew()
                End With
            ElseIf mstrCableCategory = "FIBER" Then
                With TheFiberBindingSource
                    .EndEdit()
                    .AddNew()
                End With
            ElseIf mstrCableCategory = "TWISTED PAIR" Then
                With TheTwistedPairBindingSource
                    .EndEdit()
                    .AddNew()
                End With
            ElseIf mstrCableCategory = "SPECIALTY CABLE" Then
                With TheSpecialtyCableBindingSource
                    .EndEdit()
                    .AddNew()
                End With
            End If

            addingBoolean = True
            setComboBoxBinding()

            If cboReelTransactionID.SelectedIndex <> -1 Then
                previousSelectedIndex = cboReelTransactionID.Items.Count - 1
            Else
                previousSelectedIndex = 0
            End If

            'Setting Global Variable for Creating Reel Transaction ID
            Logon.mintReelTransactionID = cboReelTransactionID.Items.Count + 1000

            'Creating Reel Transaction ID
            cboReelTransactionID.Focus()
            CableTransactionID.Show()

            cboReelTransactionID.Text = CStr(Logon.mintReelTransactionID)

            'Setting Variables
            strReelID = Logon.mstrReelID
            strPartNumber = Logon.mstrCablePartNumber
            strCurrentFootage = CStr(Logon.mintCurrentFootage)
            strTWReelID = Logon.mstrTWReelID
            strDate = CStr(Logon.mdatDate)
            strNotes = Logon.mstrNotes
            strWarehouseID = CStr(Logon.mintWarehouseID)

            txtIssuedReel.Text = "NO"
            txtReelEmpty.Text = "NO"
            txtReelID.Text = strReelID
            txtTWReelID.Text = strTWReelID
            txtPartNumber.Text = strPartNumber
            txtCurrentFootage.Text = strCurrentFootage
            txtDate.Text = strDate
            txtNotes.Text = strNotes
            txtWarehouse.Text = strWarehouseID

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
        End If
        Me.Close()

    End Sub

    Private Sub AddCableUpdateTables_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'This loads up the form
        mstrCableCategory = Logon.mstrCategory

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
                txtTWReelID.DataBindings.Add("Text", TheCoaxBindingSource, "TWReelID")

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
                txtTWReelID.DataBindings.Add("text", TheFiberBindingSource, "TWReelID")

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
                txtIssuedReel.DataBindings.Add("text", TheSpecialtyCableBindingSource, "IssueReel")
                txtReelEmpty.DataBindings.Add("text", TheSpecialtyCableBindingSource, "ReelEmpty")

            Catch ex As Exception

                'If an exception is thrown, it is rounted here
                MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try

        Else
            MessageBox.Show("The Cable Category Did Not Match", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End If

        UpdateReelInformation()

    End Sub
End Class