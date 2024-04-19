'Title:         Create Reel ID
'Date:          1/2/14
'Author;        Terry Holmes

'Description:   This form will create Reel IDs for all cable reels.

Option Strict On

Public Class CreateReelID

    Private TheReelIDDataSet As ReelIDDataSet
    Private TheReelIDDataTier As CableIDDataTier
    Private WithEvents TheReelIDBindingSource As BindingSource

    Private TheEmployeeDataSet As EmployeeDataSet
    Private TheEmployeeDataTier As EmployeeDataTier
    Private WithEvents TheEmployeeBindingSource As BindingSource

    Private addingBoolean As Boolean = False
    Private editingBoolean As Boolean = False
    Private previousSelectedIndex As Integer
    Dim mintNumuberOfRecords As Integer

    Dim LogDateTime As Date = DateAndTime.Now
    Dim strLogDateTime As String

    'Setting up for structure
    Structure Employees
        Dim mintEmployeeID As Integer
        Dim mstrFirstName As String
        Dim mstrLastName As String
    End Structure

    Dim structEmployees() As Employees
    Dim mintEmployeeCounter As Integer
    Dim mintEmployeeUpperLimit As Integer
    Dim mstrReelLabel As String

    Private Sub CreateReelID_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Using a Try Catch to catch illegal exceptions
        ClearDataBindings()
        SetEmployeeBindings()
        ClearDataBindings()

        Try

            'This will bind the controls to the data source
            TheReelIDDataTier = New CableIDDataTier
            TheReelIDDataSet = TheReelIDDataTier.GetReelIDInformation
            TheReelIDBindingSource = New BindingSource

            'Setting Combobox binding to the dataset
            With TheReelIDBindingSource
                .DataSource = TheReelIDDataSet
                .DataMember = "reelid"
                .MoveFirst()
                .MoveLast()
            End With

            'Setting the combobox to the table
            With cboTransactionID
                .DataSource = TheReelIDBindingSource
                .DisplayMember = "TransactionID"
                .DataBindings.Add("text", TheReelIDBindingSource, "TransactionID", False, DataSourceUpdateMode.Never)
            End With

            'Binding the textbox
            txtPartNumber.DataBindings.Add("text", TheReelIDBindingSource, "PartNumber")
            txtWarehouse.DataBindings.Add("text", TheReelIDBindingSource, "WarehouseID")
            txtReelID.DataBindings.Add("text", TheReelIDBindingSource, "ReelID")

            FindPartNumberReelID()

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub
    Private Sub SetEmployeeBindings()

        'setting local variables
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim strLastNameForSearch As String
        Dim strLastNameFromTable As String
        Dim intWarehouseIDForSearch As Integer
        Dim intWarehouseIDFromTable As Integer
        Dim chaWarehouseHouseName() As Char

        'try catch for exceptions
        Try

            'setting up the binding source
            TheEmployeeDataTier = New EmployeeDataTier
            TheEmployeeDataSet = TheEmployeeDataTier.GetEmployeeInformation
            TheEmployeeBindingSource = New BindingSource

            'setting up the binding source
            With TheEmployeeBindingSource
                .DataSource = TheEmployeeDataSet
                .DataMember = "employees"
                .MoveFirst()
                .MoveLast()
            End With

            'setting up the combo box
            With cboTransactionID
                .DataSource = TheEmployeeBindingSource
                .DisplayMember = "EmployeeID"
                .DataBindings.Add("text", TheEmployeeBindingSource, "EmployeeID", False, DataSourceUpdateMode.Never)
            End With

            'setting up the text boxes
            txtPartNumber.DataBindings.Add("text", TheEmployeeBindingSource, "FirstName")
            txtReelID.DataBindings.Add("text", TheEmployeeBindingSource, "LastName")

            'setting up for the loop
            intNumberOfRecords = cboTransactionID.Items.Count - 1
            ReDim structEmployees(intNumberOfRecords)
            mintEmployeeCounter = 0
            strLastNameForSearch = "PARTS"

            For intCounter = 0 To intNumberOfRecords

                cboTransactionID.SelectedIndex = intCounter
                strLastNameFromTable = txtReelID.Text

                If strLastNameForSearch = strLastNameFromTable Then
                    structEmployees(mintEmployeeCounter).mintEmployeeID = CInt(cboTransactionID.Text)
                    structEmployees(mintEmployeeCounter).mstrFirstName = txtPartNumber.Text
                    structEmployees(mintEmployeeCounter).mstrLastName = txtReelID.Text
                    mintEmployeeCounter += 1
                End If
            Next

            'getting ready for the second loop
            mintEmployeeUpperLimit = mintEmployeeCounter - 1
            intWarehouseIDForSearch = CInt(Logon.mintPartsWarehouseID)

            'second loop
            For intCounter = 0 To mintEmployeeUpperLimit

                'getting warehouse id
                intWarehouseIDFromTable = structEmployees(intCounter).mintEmployeeID

                If intWarehouseIDForSearch = intWarehouseIDFromTable Then

                    chaWarehouseHouseName = structEmployees(intCounter).mstrFirstName.ToCharArray
                    mstrReelLabel = chaWarehouseHouseName(0) + chaWarehouseHouseName(1)

                End If
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub ClearDataBindings()

        cboTransactionID.DataBindings.Clear()
        txtPartNumber.DataBindings.Clear()
        txtReelID.DataBindings.Clear()
        txtWarehouse.DataBindings.Clear()

    End Sub
    Private Sub setComboBoxBinding()

        'Sets the Combobox Bindings
        With cboTransactionID
            If addingBoolean Or editingBoolean Then
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.OnValidation
                .DropDownStyle = ComboBoxStyle.Simple
            Else
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.Never
                .DropDownStyle = ComboBoxStyle.DropDownList
            End If
        End With
    End Sub
    Private Sub FindPartNumberReelID()

        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim strPartNumberForSearch As String
        Dim strPartNumberFromTable As String
        Dim intWarehouseIDForSearch As Integer
        Dim intWarehouseIDFromTable As Integer
        Dim intSelectedIndex As Integer
        Dim blnItemNotFound As Boolean = True
        Dim intNewID As Integer

        'getting information for loop
        intNumberOfRecords = cboTransactionID.Items.Count - 1
        intWarehouseIDForSearch = Logon.mintPartsWarehouseID
        strPartNumberForSearch = Logon.mstrCablePartNumber

        'Beginning Loop
        For intCounter = 0 To intNumberOfRecords

            'incrementing the combo box
            cboTransactionID.SelectedIndex = intCounter

            'setting search variables
            intWarehouseIDFromTable = CInt(txtWarehouse.Text)
            strPartNumberFromTable = txtPartNumber.Text

            If intWarehouseIDForSearch = intWarehouseIDFromTable Then
                If strPartNumberForSearch = strPartNumberFromTable Then
                    intSelectedIndex = intCounter
                    blnItemNotFound = False
                End If
            End If
        Next

        If blnItemNotFound = True Then
            CreateReelID()
        ElseIf blnItemNotFound = False Then

            'setting up to create the new id
            cboTransactionID.SelectedIndex = intSelectedIndex
            intNewID = CInt(txtReelID.Text)
            intNewID += 1
            txtReelID.Text = CStr(intNewID)
            mstrReelLabel = mstrReelLabel + txtReelID.Text
            Logon.mstrReelID = mstrReelLabel
            UpdateDataBase()

        End If


    End Sub
    Private Sub CreateReelID()

        With TheReelIDBindingSource
            .EndEdit()
            .AddNew()
        End With

        'Calling sub-routines and setting call values
        addingBoolean = True
        setComboBoxBinding()
        cboTransactionID.Focus()
        CableTransactionID.Show()
        cboTransactionID.Text = CStr(Logon.mintReelTransactionID)
        txtPartNumber.Text = Logon.mstrCablePartNumber
        txtWarehouse.Text = CStr(Logon.mintPartsWarehouseID)
        txtReelID.Text = "200"
        mstrReelLabel = mstrReelLabel + txtReelID.Text
        Logon.mstrReelID = mstrReelLabel
        UpdateDataBase()

    End Sub
    
    Private Sub UpdateDataBase()


        'Adding the record into the table
        TheReelIDBindingSource.EndEdit()
        TheReelIDDataTier.UpdateReelIDDB(TheReelIDDataSet)

        Me.Close()

    End Sub
End Class