'Title:         Update Returned Cable Reel
'Date:          2/24/14
'Author:        Terry Holmes

'Description:   This form is used to update cable reels that have been returned

Option Strict On

Public Class UpdateReturnedCableReel

    'Set Global Variables from the Return Cable Reel
    Dim mstrCategory As String = Logon.mstrCategory
    Dim mstrPartNumber As String = Logon.mstrPartNumber
    Dim mstrReelID As String = Logon.mstrReelID
    Dim mstrWarehouse As String = Logon.mstrWarehouse
    Dim mintCurrentFootage As Integer = Logon.mintCurrentFootage

    Private TheSpecialtyCableDataSet As SpecialityCableDataSet
    Private TheSpecialtyCableDataTier As CableDataTier
    Private WithEvents TheSpecialtyCableBindingSource As BindingSource

    Private TheTwistedPairDataSet As TwistedPairDataSet
    Private TheTwistedPairDataTier As CableDataTier
    Private WithEvents TheTwistedPairBindingSource As BindingSource

    Private TheDropCableDataSet As DropCableDataSet
    Private TheDropCableDataTier As CableDataTier
    Private WithEvents TheDropCableBindingSource As BindingSource

    Private TheFiberDataSet As FiberDataSet
    Private TheFiberDataTier As CableDataTier
    Private WithEvents TheFiberBindingSource As BindingSource

    Private TheCoaxDataSet As CoaxDataSet
    Private TheCoaxDataTier As CableDataTier
    Private WithEvents TheCoaxBindingSource As BindingSource

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

    Private Sub UpdateReturnedCableReel_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        If mstrCategory = "COAX" Then

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
                txtWarehouse.DataBindings.Add("text", TheCoaxBindingSource, "WarehouseID")
                txtIssuedReel.DataBindings.Add("text", TheCoaxBindingSource, "IssuedReel")

            Catch ex As Exception

                'If an exception is thrown, it is rounted here
                MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try

        ElseIf mstrCategory = "FIBER" Then

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
                txtWarehouse.DataBindings.Add("text", TheFiberBindingSource, "WarehouseID")
                txtIssuedReel.DataBindings.Add("text", TheFiberBindingSource, "IssuedReel")

            Catch ex As Exception

                'If an exception is thrown, it is rounted here
                MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try

        ElseIf mstrCategory = "DROP CABLE" Then

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
                txtWarehouse.DataBindings.Add("text", TheDropCableBindingSource, "WarehouseID")
                txtIssuedReel.DataBindings.Add("text", TheDropCableBindingSource, "IssuedReel")

            Catch ex As Exception

                'If an exception is thrown, it is rounted here
                MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try

        ElseIf mstrCategory = "TWISTED PAIR" Then

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
                txtWarehouse.DataBindings.Add("text", TheTwistedPairBindingSource, "WarehouseID")
                txtIssuedReel.DataBindings.Add("text", TheTwistedPairBindingSource, "IssuedReel")

            Catch ex As Exception

                'If an exception is thrown, it is rounted here
                MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try

        ElseIf mstrCategory = "SPECIALTY CABLE" Then

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
                txtWarehouse.DataBindings.Add("text", TheSpecialtyCableBindingSource, "WarehouseID")
                txtIssuedReel.DataBindings.Add("text", TheSpecialtyCableBindingSource, "IssuedReel")

            Catch ex As Exception

                'If an exception is thrown, it is rounted here
                MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try

        End If

        'Call Find Reel Sub Routine
        ReturnReel()

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
    Private Sub ReturnReel()

        Dim strWarehouseFromTable As String
        Dim strPartNumberFromTable As String
        Dim strReelIDFromTable As String
        Dim intFootageFromReel As Integer
        Dim intCounter As Integer
        Dim intSelectedIndex As Integer
        Dim blnReelNotFound As Boolean = True
        Dim blnFootageNotZero As Boolean = True
        Dim strIssuedReel As String

        'Getting Record Count from Combo Box
        mintNumuberOfRecords = cboReelTransactionID.Items.Count - 1

        For intCounter = 0 To mintNumuberOfRecords

            cboReelTransactionID.SelectedIndex = intCounter
            strWarehouseFromTable = txtWarehouse.Text
            strReelIDFromTable = txtReelID.Text
            strPartNumberFromTable = txtPartNumber.Text

            If strWarehouseFromTable = mstrWarehouse Then
                If strPartNumberFromTable = mstrPartNumber Then
                    If strReelIDFromTable = mstrReelID Then
                        intSelectedIndex = intCounter
                        blnReelNotFound = False
                    End If
                End If
            End If

        Next

        Logon.mbolFatalError = blnReelNotFound

        If blnReelNotFound = True Then
            Logon.mbolFatalError = True
            Me.Close()
        End If

        cboReelTransactionID.SelectedIndex = intSelectedIndex

        intFootageFromReel = CInt(txtCurrentFootage.Text)
        strIssuedReel = txtIssuedReel.Text

        If intFootageFromReel = 0 And strIssuedReel = "YES" Then
            blnFootageNotZero = False
        End If

        Logon.mbolFootageIsNotZero = blnFootageNotZero

        If blnFootageNotZero = True Then
            ClearDataBindings()
            Me.Close()
        End If

        txtCurrentFootage.Text = CStr(mintCurrentFootage)
        txtIssuedReel.Text = "NO"

        'Updating Databases
        Try

            If mstrCategory = "COAX" Then
                TheCoaxBindingSource.EndEdit()
                TheCoaxDataTier.UpdateCoaxDB(TheCoaxDataSet)
            ElseIf mstrCategory = "FIBER" Then
                TheFiberBindingSource.EndEdit()
                TheFiberDataTier.UpdateFiberDB(TheFiberDataSet)
            ElseIf mstrCategory = "DROP CABLE" Then
                TheDropCableBindingSource.EndEdit()
                TheDropCableDataTier.UpdateDropCableDB(TheDropCableDataSet)
            ElseIf mstrCategory = "TWISTED PAIR" Then
                TheTwistedPairBindingSource.EndEdit()
                TheTwistedPairDataTier.UpdateTwistedPairDB(TheTwistedPairDataSet)
            ElseIf mstrCategory = "SPECIALTY CABLE" Then
                TheSpecialtyCableBindingSource.EndEdit()
                TheSpecialtyCableDataTier.UpdateSpecialityCableDB(TheSpecialtyCableDataSet)
            End If

            ClearDataBindings()
            Me.Close()

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

        ClearDataBindings()
        Me.Close()

    End Sub
    Private Sub ClearDataBindings()

        cboReelTransactionID.DataBindings.Clear()
        txtCurrentFootage.DataBindings.Clear()
        txtReelID.DataBindings.Clear()
        txtIssuedReel.DataBindings.Clear()
        txtPartNumber.DataBindings.Clear()
        txtWarehouse.DataBindings.Clear()
    End Sub
End Class