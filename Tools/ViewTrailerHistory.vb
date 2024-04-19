'Title:         View Trailer History
'Date:          3/13/14
'Author:        Terry Holmes

'Description:   This form is used to view the Trailer History

Option Strict On

Public Class ViewTrailerHistory

    'Setting Modular Variables
    Private TheEmployeeDataSet As EmployeeDataSet
    Private TheEmployeeDataTier As EmployeeDataTier
    Private WithEvents TheEmployeeBindingSource As BindingSource

    Private TheWarehouseEmployeeDataSet As EmployeeDataSet
    Private TheWarehouseEmployeeDataTier As EmployeeDataTier
    Private WithEvents TheWarehouseEmployeeBindingSource As BindingSource

    Private TheTrailersDataSet As TrailersDataSet
    Private TheTrailersDataTier As TrailersDataTier
    Private WithEvents TheTrailersBindingSource As BindingSource

    Private TheTrailerHistoryDataSet As TrailerHistoryDataSet
    Private TheTrailerHistoryDataTier As TrailerHistoryDataTier
    Private WithEvents TheTrailerHistoryBindingSource As BindingSource

    Private addingBoolean As Boolean = False
    Private editingBoolean As Boolean = False
    Private previousSelectedIndex As Integer
    Dim mintNumuberOfRecords As Integer

    Dim LogDateTime As Date = DateAndTime.Now
    Dim strLogDateTime As String
    Dim mblnEmployeeIDFound As Boolean
    Dim mintSelectedIndex(10000) As Integer
    Dim mintCounter As Integer
    Dim mblnLastNameFound As Boolean
    Dim mintUpperLimit As Integer
    Dim mintEmployeeID As Integer
    Dim mintWarehouseID As Integer
    Dim mintBJCNumber As Integer
    Dim mintSearchUpperLimit As Integer

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        'Closes the Program
        CloseTheProgram.ShowDialog()

    End Sub

    Private Sub btnMainMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMainMenu.Click

        'This opens the Main menu
        'RemoveDataBindings()
        MainMenu.Show()
        VehicleMenu.Close()
        Me.Close()

    End Sub
    Private Sub setComboBoxBinding()

        'Sets the Combobox Bindings
        With Me.cboEmployeeID
            If (addingBoolean Or editingBoolean) Then
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.OnValidation
                .DropDownStyle = ComboBoxStyle.Simple
            Else
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.Never
                .DropDownStyle = ComboBoxStyle.DropDownList
            End If
        End With

        With Me.cboTrailerID
            If (addingBoolean Or editingBoolean) Then
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.OnValidation
                .DropDownStyle = ComboBoxStyle.Simple
                'Else
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.Never
                .DropDownStyle = ComboBoxStyle.DropDownList
            End If

        End With

        With Me.cboTransactionID
            If (addingBoolean Or editingBoolean) Then
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.OnValidation
                .DropDownStyle = ComboBoxStyle.Simple
            Else
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.Never
                .DropDownStyle = ComboBoxStyle.DropDownList
            End If
        End With

        With Me.cboWareHouseEmployeeID
            If (addingBoolean Or editingBoolean) Then
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.OnValidation
                .DropDownStyle = ComboBoxStyle.Simple
            Else
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.Never
                .DropDownStyle = ComboBoxStyle.DropDownList
            End If
        End With

    End Sub

    Private Sub btnTrailerMenu_Click(sender As System.Object, e As System.EventArgs) Handles btnTrailerMenu.Click

        'Shows the Trailer Menu
        TrailerMenu.Show()
        Me.Close()

    End Sub

    Private Sub ViewTrailerHistory_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Try Catch for Employees
        Try
            TheEmployeeDataTier = New EmployeeDataTier
            TheEmployeeDataSet = TheEmployeeDataTier.GetEmployeeInformation
            TheEmployeeBindingSource = New BindingSource

            TheWarehouseEmployeeDataTier = New EmployeeDataTier
            TheWarehouseEmployeeDataSet = TheWarehouseEmployeeDataTier.GetEmployeeInformation
            TheWarehouseEmployeeBindingSource = New BindingSource

            TheTrailerHistoryDataTier = New TrailerHistoryDataTier
            TheTrailerHistoryDataSet = TheTrailerHistoryDataTier.GetTrailerHistoryInformation
            TheTrailerHistoryBindingSource = New BindingSource

            TheTrailersDataTier = New TrailersDataTier
            TheTrailersDataSet = TheTrailersDataTier.GetTrailersInformation
            TheTrailersBindingSource = New BindingSource

            With TheEmployeeBindingSource
                .DataSource = TheEmployeeDataSet
                .DataMember = "employees"
                .MoveFirst()
                .MoveLast()
            End With

            With TheWarehouseEmployeeBindingSource
                .DataSource = TheWarehouseEmployeeDataSet
                .DataMember = "employees"
                .MoveFirst()
                .MoveLast()
            End With

            With TheTrailerHistoryBindingSource
                .DataSource = TheTrailerHistoryDataSet
                .DataMember = "trailerhistory"
                .MoveFirst()
                .MoveLast()
            End With

            With TheTrailersBindingSource
                .DataSource = TheTrailersDataSet
                .DataMember = "trailers"
                .MoveFirst()
                .MoveLast()
            End With

            With cboEmployeeID
                .DataSource = TheEmployeeBindingSource
                .DisplayMember = "EmployeeID"
                .DataBindings.Add("text", TheEmployeeBindingSource, "EmployeeID", False, DataSourceUpdateMode.Never)
            End With

            With cboWareHouseEmployeeID
                .DataSource = TheWarehouseEmployeeBindingSource
                .DisplayMember = "EmployeeID"
                .DataBindings.Add("text", TheWarehouseEmployeeBindingSource, "EmployeeID", False, DataSourceUpdateMode.Never)
            End With

            With cboTransactionID
                .DataSource = TheTrailerHistoryBindingSource
                .DisplayMember = "TransactionID"
                .DataBindings.Add("text", TheTrailerHistoryBindingSource, "TransactionID", False, DataSourceUpdateMode.Never)
            End With

            With cboTrailerID
                .DataSource = TheTrailersBindingSource
                .DisplayMember = "TrailerID"
                .DataBindings.Add("text", TheTrailersBindingSource, "TrailerID", False, DataSourceUpdateMode.Never)
            End With

            'Setting up Employee Text Boxes
            txtLastName.DataBindings.Add("text", TheEmployeeBindingSource, "LastName")
            txtFirstName.DataBindings.Add("text", TheEmployeeBindingSource, "FirstName")
            txtPhoneNumber.DataBindings.Add("text", TheEmployeeBindingSource, "PhoneNumber")

            'Setting Up Warehouse Employee Text Boxes
            txtWarehouselastName.DataBindings.Add("text", TheWarehouseEmployeeBindingSource, "LastName")
            txtWarehouseFirstName.DataBindings.Add("text", TheWarehouseEmployeeBindingSource, "FirstName")
            txtWarehousePhoneNumber.DataBindings.Add("text", TheWarehouseEmployeeBindingSource, "PhoneNumber")

            'Setting Up Trailer History Textboxes
            txtHistoryDate.DataBindings.Add("text", TheTrailerHistoryBindingSource, "date")
            txtHistoryEmployeeID.DataBindings.Add("text", TheTrailerHistoryBindingSource, "EmployeeID")
            txtHistoryTrailerId.DataBindings.Add("text", TheTrailerHistoryBindingSource, "TrailerID")
            txtHistoryNotes.DataBindings.Add("text", TheTrailerHistoryBindingSource, "Notes")
            txtHistoryBJCNumber.DataBindings.Add("text", TheTrailerHistoryBindingSource, "BJCNumber")
            txtHistoryWarehouseEmployeeID.DataBindings.Add("text", TheTrailerHistoryBindingSource, "WarehouseEmployeeID")

            'Setting Up Trailer Textboxes
            txtTrailerActive.DataBindings.Add("text", TheTrailersBindingSource, "Active")
            txtTrailerAvailable.DataBindings.Add("text", TheTrailersBindingSource, "Available")
            txtTrailerBJCNumber.DataBindings.Add("text", TheTrailersBindingSource, "BJCNumber")
            txtTrailerDate.DataBindings.Add("text", TheTrailersBindingSource, "Date")
            txtTrailerDescription.DataBindings.Add("text", TheTrailersBindingSource, "Description")
            txtTrailerLicencePlate.DataBindings.Add("text", TheTrailersBindingSource, "LicensePlate")
            txtTrailerEmployeeID.DataBindings.Add("text", TheTrailersBindingSource, "EmployeeID")
            txtTrailerNotes.DataBindings.Add("text", TheTrailerHistoryBindingSource, "Notes")

            mintNumuberOfRecords = cboTransactionID.Items.Count - 1
            mintCounter = 0

            If mintNumuberOfRecords > 0 Then
                btnHistoryNext.Enabled = True
            End If

            FindEmployee()


        Catch ex As Exception

            MessageBox.Show(ex.Message, "There is a Problem", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub
    Private Sub FindEmployee()

        'Setting variables for employee
        Dim intNumberOfRecords As Integer
        Dim intCounter As Integer
        Dim intSelectedIndex As Integer
        Dim intEmployeeIDFromHistory As Integer
        Dim intEmployeeIDFromTable As Integer

        'Setting variables Warehouse Employee
        Dim intWarehouseEmployeeNumberOfRecords As Integer
        Dim intWarehouseEmployeeCounter As Integer
        Dim intWarehouseEmployeeSelectedIndex As Integer
        Dim intWarehouseEmployeeIDFromHistory As Integer
        Dim intWarehouseEmployeeIDFromTable As Integer

        'Setting the employee boxes
        intNumberOfRecords = cboEmployeeID.Items.Count - 1
        intEmployeeIDFromHistory = CInt(txtHistoryEmployeeID.Text)

        For intCounter = 0 To intNumberOfRecords
            cboEmployeeID.SelectedIndex = intCounter
            intEmployeeIDFromTable = CInt(cboEmployeeID.Text)
            If intEmployeeIDFromHistory = intEmployeeIDFromTable Then
                intSelectedIndex = intCounter
            End If
        Next

        cboEmployeeID.SelectedIndex = intSelectedIndex

        'Setting up Warehoue Employee Controls
        intWarehouseEmployeeNumberOfRecords = cboWareHouseEmployeeID.Items.Count - 1
        intWarehouseEmployeeIDFromHistory = CInt(txtHistoryWarehouseEmployeeID.Text)

        For intWarehouseEmployeeCounter = 0 To intWarehouseEmployeeNumberOfRecords
            cboWareHouseEmployeeID.SelectedIndex = intWarehouseEmployeeCounter
            intWarehouseEmployeeIDFromTable = CInt(cboWareHouseEmployeeID.Text)
            If intWarehouseEmployeeIDFromHistory = intWarehouseEmployeeIDFromTable Then
                intWarehouseEmployeeSelectedIndex = intWarehouseEmployeeCounter
            End If
        Next

        cboWareHouseEmployeeID.SelectedIndex = intWarehouseEmployeeSelectedIndex

    End Sub

    Private Sub btnHistoryNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHistoryNext.Click

        'This subroutine uses the next button
        mintCounter = mintCounter + 1
        cboTransactionID.SelectedIndex = mintCounter

        btnHistoryBack.Enabled = True

        If mintCounter = mintNumuberOfRecords Then
            btnHistoryNext.Enabled = False
        End If

        FindEmployee()

    End Sub

    Private Sub btnHistoryBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHistoryBack.Click

        'This subroutine uses the next button
        mintCounter = mintCounter - 1
        cboTransactionID.SelectedIndex = mintCounter

        btnHistoryNext.Enabled = True

        If mintCounter = 0 Then
            btnHistoryBack.Enabled = False
        End If

        FindEmployee()


    End Sub
End Class