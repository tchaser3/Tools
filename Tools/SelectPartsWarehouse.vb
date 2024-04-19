'Title:         Select Parts Warehouse
'Date:          6-25-15
'Author:        Terry Holmes

'Description:   This form is used to select the warehouse

Option Strict On

Public Class SelectPartsWarehouse

    Private TheEmployeesDataSet As EmployeeDataSet
    Private TheEmployeesDataTier As EmployeeDataTier
    Private WithEvents TheEmployeesBindingSource As BindingSource

    'Setting up for array
    Dim mintSelectedIndex() As Integer
    Dim mintCounter As Integer
    Dim mintUpperLimit As Integer

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click

        CloseTheProgram.ShowDialog()

    End Sub

    Private Sub SelectPartsWarehouse_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Setting local variables
        Dim intNumberOfRecords As Integer
        Dim intCounter As Integer
        Dim strLastNameForSearch As String
        Dim strLastNameFromTable As String

        btnNext.Enabled = False
        btnBack.Enabled = False

        'Try catch to catch exceptions
        Try

            TheEmployeesDataTier = New EmployeeDataTier
            TheEmployeesDataSet = TheEmployeesDataTier.GetEmployeeInformation
            TheEmployeesBindingSource = New BindingSource

            'Setting up the binding source
            With TheEmployeesBindingSource
                .DataSource = TheEmployeesDataSet
                .DataMember = "employees"
                .MoveFirst()
                .MoveLast()
            End With

            'Setting up the combo box
            With cboEmployeeID
                .DataSource = TheEmployeesBindingSource
                .DisplayMember = "EmployeeID"
                .DataBindings.Add("text", TheEmployeesBindingSource, "EmployeeID", False, DataSourceUpdateMode.Never)
            End With

            'Setting up the rest of the controls
            txtFirstName.DataBindings.Add("Text", TheEmployeesBindingSource, "FirstName")
            txtLastName.DataBindings.Add("text", TheEmployeesBindingSource, "LastName")

            'getting ready for the loop
            intNumberOfRecords = cboEmployeeID.Items.Count - 1
            ReDim mintSelectedIndex(intNumberOfRecords)
            mintCounter = 0
            strLastNameForSearch = "PARTS"

            'Running loop
            For intCounter = 0 To intNumberOfRecords

                'Incrementing the combo box
                cboEmployeeID.SelectedIndex = intCounter

                'getting the last name
                strLastNameFromTable = txtLastName.Text

                If strLastNameForSearch = strLastNameFromTable Then
                    mintSelectedIndex(mintCounter) = intCounter
                    mintCounter += 1
                End If
            Next

            'Finishing loop
            mintUpperLimit = mintCounter - 1
            mintCounter = 0
            If mintUpperLimit > 0 Then
                btnNext.Enabled = True
            End If
            cboEmployeeID.SelectedIndex = mintSelectedIndex(0)

        Catch ex As Exception

            'Setting up if there is a failure
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            If Logon.mstrSelectionOrigination = "ADMIN" Then
                MessageBox.Show("The Admin Menu Will Be Now Displayed", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Error)
                AdministrativeMenu.Show()
                Me.Close()
            End If

        End Try
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click

        'this will increment the counter
        mintCounter += 1
        cboEmployeeID.SelectedIndex = mintSelectedIndex(mintCounter)

        'Setting navigation buttons
        btnBack.Enabled = True

        If mintCounter = mintUpperLimit Then
            btnNext.Enabled = False
        End If
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click


        'this will increment the counter
        mintCounter -= 1
        cboEmployeeID.SelectedIndex = mintSelectedIndex(mintCounter)

        'Setting navigation buttons
        btnNext.Enabled = True

        If mintCounter = 0 Then
            btnBack.Enabled = False
        End If

    End Sub

    Private Sub btnLogon_Click(sender As Object, e As EventArgs) Handles btnLogon.Click

        'This will Select the Form to load
        LastTransaction.Show()
        Logon.mintPartsWarehouseID = CInt(cboEmployeeID.Text)

        If Logon.mstrSelectionOrigination = "VOID INVENTORY TRANSACTION" Then
            VoidInventoryTransaction.Show()
        ElseIf Logon.mstrSelectionOrigination = "LOGON" Then
            MainMenu.Show()
        End If

        Me.Close()
    End Sub
End Class