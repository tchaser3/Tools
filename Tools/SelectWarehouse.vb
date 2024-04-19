'Title:         Select Warehouse
'Date:          5/22/14
'Author:        Terry Holmes

'Description:   This is used to Select the Warehouse

Option Strict On

Public Class SelectWarehouse

    Dim TheInputDataValidation As New InputDataValidation

    Private addingBoolean As Boolean = False
    Private editingBoolean As Boolean = False
    Private previousSelectedIndex As Integer

    Dim LogDateTime As Date = DateAndTime.Now
    Dim strLogDateTime As String

    'Warehouse Array
    Dim mintWarehouseSelectedIndex(1000) As Integer
    Dim mintWarehouseCounter As Integer
    Dim mintWarehouseUpperLimit As Integer

    'Setting up Employee Information
    Private TheSelectWarehouseDataSet As EmployeeDataSet
    Private TheSelectWarehouseDataTier As EmployeeDataTier
    Private WithEvents TheSelectWarehouseBindingSource As BindingSource

    'Setting up Employee Information
    Private TheManagerDataSet As EmployeeDataSet
    Private TheManagerDataTier As EmployeeDataTier
    Private WithEvents TheManagerBindingSource As BindingSource

    Private Sub setComboBoxBinding()

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

    Private Sub SelectWarehouse_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Declaring Local Variables
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim strWarehouseLastName As String
        Dim blnWarehouseNotFound As Boolean = True

        SetManagerBindings()
        ClearDataBindings()

        'Used to Populate the Form
        'Try - Catch for Managers, Warehouse and Technicians
        Try


            'This will bind the controls to the data source
            TheSelectWarehouseDataTier = New EmployeeDataTier
            TheSelectWarehouseDataSet = TheSelectWarehouseDataTier.GetEmployeeInformation
            TheSelectWarehouseBindingSource = New BindingSource

            'Setting up Binding Source for the Combo Box
            With TheSelectWarehouseBindingSource
                .DataSource = TheSelectWarehouseDataSet
                .DataMember = "employees"
                .MoveFirst()
                .MoveLast()
            End With

            'Setting the Warehouse Relationship for the controls
            With cboWarehouseID
                .DataSource = TheSelectWarehouseBindingSource
                .DisplayMember = "EmployeeID"
                .DataBindings.Add("text", TheSelectWarehouseBindingSource, "EmployeeID", False, DataSourceUpdateMode.Never)
            End With

            'Setting the data binding for the text boxes
            txtWarehouseFirstName.DataBindings.Add("text", TheSelectWarehouseBindingSource, "FirstName")
            txtWarehouseLastName.DataBindings.Add("text", TheSelectWarehouseBindingSource, "LastName")

            'Beginning loop to find parts warehouse
            intNumberOfRecords = cboWarehouseID.Items.Count - 1
            mintWarehouseCounter = 0

            If Logon.mstrCableSelectionType = "EDITREELVERIFY" Then
                VerifyIDAsParts()
            Else
                'For Loop to find all files
                For intCounter = 0 To intNumberOfRecords

                    cboWarehouseID.SelectedIndex = intCounter
                    strWarehouseLastName = txtWarehouseLastName.Text

                    'If Statements for Compares
                    If strWarehouseLastName = "PARTS" Then

                        mintWarehouseSelectedIndex(mintWarehouseCounter) = intCounter
                        mintWarehouseCounter = mintWarehouseCounter + 1
                        blnWarehouseNotFound = False

                    End If
                Next
            End If


            'Setting up array
            mintWarehouseUpperLimit = mintWarehouseCounter - 1
            mintWarehouseCounter = 0
            cboWarehouseID.SelectedIndex = mintWarehouseSelectedIndex(0)

            'Enabling the button
            If mintWarehouseUpperLimit > 0 Then
                btnWarehouseNext.Enabled = True
            End If


        Catch ex As Exception

            'If an exception is thrown, it is rounted here
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try



    End Sub
    Private Sub VerifyIDAsParts()

        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim blnIsNotWarehouse As Boolean = True
        Dim strLastName As String
        Dim intWarehouseIDForSearch As Integer
        Dim intWarehouseIDFromTable As Integer

        'Setting up for the loop
        intNumberOfRecords = cboWarehouseID.Items.Count - 1
        intWarehouseIDForSearch = CInt(Logon.mintWarehouseID)

        For intCounter = 0 To intNumberOfRecords

            cboWarehouseID.SelectedIndex = intCounter
            strLastName = txtWarehouseLastName.Text
            intWarehouseIDFromTable = CInt(cboWarehouseID.Text)

            If intWarehouseIDForSearch = intWarehouseIDFromTable Then
                If strLastName = "PARTS" Then
                    blnIsNotWarehouse = False
                End If
            End If

        Next

        Logon.mbolFatalError = blnIsNotWarehouse

        Me.Close()

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        'Cancels the operation and send the user back to the inventory menu
        InventoryMenu.Show()
        Me.Close()

    End Sub

    Private Sub btnWarehouseNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWarehouseNext.Click

        'This will increment the counter
        mintWarehouseCounter = mintWarehouseCounter + 1
        cboWarehouseID.SelectedIndex = mintWarehouseSelectedIndex(mintWarehouseCounter)

        btnWarehouseBack.Enabled = True

        If mintWarehouseCounter = mintWarehouseUpperLimit Then
            btnWarehouseNext.Enabled = False
        End If

    End Sub

    Private Sub btnWarehouseBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWarehouseBack.Click

        'This will decrement the counter
        mintWarehouseCounter = mintWarehouseCounter - 1
        cboWarehouseID.SelectedIndex = mintWarehouseSelectedIndex(mintWarehouseCounter)

        btnWarehouseNext.Enabled = True

        If mintWarehouseCounter = 0 Then
            btnWarehouseBack.Enabled = False
        End If

    End Sub

    Private Sub btnWarehouseSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWarehouseSelect.Click

        'This routine will run after the warehouse is selected
        Logon.mintWarehouseID = CInt(cboWarehouseID.Text)

        If Logon.mstrCableSelectionType = "RECEIVECABLE" Then
            ReceiveCable.Show()
        ElseIf Logon.mstrCableSelectionType = "EDITREEL" Then
            EditCableReel.Show()
        ElseIf Logon.mstrCableSelectionType = "RETURNCABLEREEL" Then
            ReturnCableReel.Show()
        ElseIf Logon.mstrCableSelectionType = "ADDCABLE" Then
            AddCable.Show()
        ElseIf Logon.mstrCableSelectionType = "ADJUSTCABLEREEL" Then
            AdjustCableReel.Show()
        ElseIf Logon.mstrCableSelectionType = "CABLEREPORT" Then
            Logon.mstrTypeOfDateSearch = Logon.mstrCableSelectionType
            DateSearchParameters.Show()
        ElseIf Logon.mstrCableSelectionType = "CABLEAVAILABILITY" Then
            CableAvailabilityReport.Show()
        ElseIf Logon.mstrCableSelectionType = "MANAGERQUEUE" Then

            Logon.mstrWarehouse = txtWarehouseFirstName.Text
            ManagerCableQueue.PrintDocument()
            Me.Close()
        ElseIf Logon.mstrCableSelectionType = "TECHNICIANQUEUE" Then

            Logon.mstrWarehouse = txtWarehouseFirstName.Text
            ViewTechnicianQueues.PrintDocument()
            Me.Close()
        End If

        Me.Close()

    End Sub
    Private Sub ClearDataBindings()

        cboWarehouseID.DataBindings.Clear()
        txtWarehouseFirstName.DataBindings.Clear()
        txtWarehouseLastName.DataBindings.Clear()

    End Sub
    Private Sub SetManagerBindings()
        Try
            'This will bind the controls to the data source
            TheManagerDataTier = New EmployeeDataTier
            TheManagerDataSet = TheManagerDataTier.GetEmployeeInformation
            TheManagerBindingSource = New BindingSource

            'Setting up Binding Source for the Combo Box
            With TheManagerBindingSource
                .DataSource = TheManagerDataSet
                .DataMember = "employees"
                .MoveFirst()
                .MoveLast()
            End With

            'Setting the Warehouse Relationship for the controls
            With cboWarehouseID
                .DataSource = TheManagerBindingSource
                .DisplayMember = "EmployeeID"
                .DataBindings.Add("text", TheManagerBindingSource, "EmployeeID", False, DataSourceUpdateMode.Never)
            End With

            'Setting the data binding for the text boxes
            txtWarehouseFirstName.DataBindings.Add("text", TheManagerBindingSource, "FirstName")
            txtWarehouseLastName.DataBindings.Add("text", TheManagerBindingSource, "LastName")
        Catch ex As Exception

        End Try
    End Sub
End Class