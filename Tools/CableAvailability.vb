'Title:         Cable Availability
'Date:          1/22/14
'Author:        Terry Holmes

'Description:   This form shows the cable availability for a certain cable

Option Strict On

Public Class CableAvailability

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
    End Sub

    Private Sub btnCableAvailability_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCableAvailability.Click

        Logon.mstrCableSelectionType = "AVAILABILITY"
        CableSelection.Show()
        Me.Close()

    End Sub

    Private Sub btnCableMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCableMenu.Click

        CableMenu.Show()
        Me.Close()

    End Sub

    Private Sub CableAvailability_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Setting Local Variables
        Dim intFootage As Integer
        Dim intCounter As Integer
        Dim strPartNumberFromTable As String
        Dim strPartNumberFromForm As String
        Dim intWarehouseFromTable As Integer
        Dim intWarehouseFromForm As Integer
        Dim intNumberOfRecords As Integer
        Dim blnPartNumberNotFound As Boolean = True


        If Logon.mstrCategory = "COAX" Then

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
                With cboTransactionID
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

            Catch ex As Exception

                'If an exception is thrown, it is rounted here
                MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try

        ElseIf Logon.mstrCategory = "FIBER" Then

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
                With cboTransactionID
                    .DataSource = TheFiberBindingSource
                    .DisplayMember = "ReelTransactionID"
                    .DataBindings.Add("text", TheFiberBindingSource, "ReelTransactionID", False, DataSourceUpdateMode.Never)
                End With

                'Setting the data binding for the text boxes
                txtReelID.DataBindings.Add("text", TheFiberBindingSource, "ReelID")
                txtTWReelID.DataBindings.Add("text", TheFiberBindingSource, "TWReelID")
                txtPartNumber.DataBindings.Add("text", TheFiberBindingSource, "PartNumber")
                txtCurrentFootage.DataBindings.Add("text", TheFiberBindingSource, "CurrentFootage")
                txtDate.DataBindings.Add("text", TheFiberBindingSource, "Date")
                txtWarehouse.DataBindings.Add("text", TheFiberBindingSource, "WarehouseID")
                txtNotes.DataBindings.Add("text", TheFiberBindingSource, "Notes")

            Catch ex As Exception

                'If an exception is thrown, it is rounted here
                MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try

        ElseIf Logon.mstrCategory = "DROP CABLE" Then

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
                With cboTransactionID
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

            Catch ex As Exception

                'If an exception is thrown, it is rounted here
                MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try

        ElseIf Logon.mstrCategory = "TWISTED PAIR" Then

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
                With cboTransactionID
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

            Catch ex As Exception

                'If an exception is thrown, it is rounted here
                MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try

        ElseIf Logon.mstrCategory = "SPECIALTY CABLE" Then

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
                With cboTransactionID
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

            Catch ex As Exception

                'If an exception is thrown, it is rounted here
                MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try

        End If

        'Finding Part Number and Warehouse
        intNumberOfRecords = cboTransactionID.Items.Count - 1
        intWarehouseFromForm = CInt(Logon.mintWarehouseID)
        strPartNumberFromForm = Logon.mstrPartNumber
        mintSelectedIndexCounter = 0

        For intCounter = 0 To intNumberOfRecords

            'Setting Up Combo Box
            cboTransactionID.SelectedIndex = intCounter
            strPartNumberFromTable = txtPartNumber.Text
            intWarehouseFromTable = CInt(txtWarehouse.Text)
            intFootage = CInt(txtCurrentFootage.Text)

            'Seeing if the part number there
            If strPartNumberFromForm = strPartNumberFromTable And intWarehouseFromForm = intWarehouseFromTable And intFootage > 10 Then

                'Filling Array
                mintSelectedIndex(mintSelectedIndexCounter) = intCounter
                mintSelectedIndexCounter = mintSelectedIndexCounter + 1
                blnPartNumberNotFound = False

            End If

        Next

        If blnPartNumberNotFound = True Then
            MessageBox.Show("Cable Not Found in This Warehouse", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ClearTextBoxes()
            Exit Sub
        End If

        cboTransactionID.SelectedIndex = mintSelectedIndex(0)
        mintSelectedIndexUpperLimit = mintSelectedIndexCounter - 1
        mintSelectedIndexCounter = 0

        If mintSelectedIndexUpperLimit > 0 Then
            btnNext.Enabled = True
        End If

    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click

        'Setting the combo box
        mintSelectedIndexCounter = mintSelectedIndexCounter + 1
        cboTransactionID.SelectedIndex = mintSelectedIndex(mintSelectedIndexCounter)

        'Enabling the Back Button
        btnBack.Enabled = True

        If mintSelectedIndexCounter = mintSelectedIndexUpperLimit Then
            btnNext.Enabled = False
        End If
    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click

        mintSelectedIndexCounter = mintSelectedIndexCounter - 1
        cboTransactionID.SelectedIndex = mintSelectedIndex(mintSelectedIndexCounter)

        'Enabling the Back Button
        btnNext.Enabled = True

        If mintSelectedIndexCounter = 0 Then
            btnBack.Enabled = False
        End If

    End Sub
    Private Sub ClearDataBindings()

        cboTransactionID.DataBindings.Clear()
        txtCurrentFootage.DataBindings.Clear()
        txtDate.DataBindings.Clear()
        txtNotes.DataBindings.Clear()
        txtPartNumber.DataBindings.Clear()
        txtReelID.DataBindings.Clear()
        txtTWReelID.DataBindings.Clear()
        txtWarehouse.DataBindings.Clear()

    End Sub

    Private Sub ClearTextBoxes()

        txtCurrentFootage.Text = ""
        txtDate.Text = ""
        txtNotes.Text = ""
        txtPartNumber.Text = ""
        txtReelID.Text = ""
        txtTWReelID.Text = ""
        txtWarehouse.Text = ""

    End Sub
End Class