'Title:         Find the Home Office ID
'Date:          10/11/13
'Author:        Terry Holmes

'Description:   This form is used to find the home office ID and load the global variable.

Option Strict On

Public Class FindHomeOfficeID

    'Calling Modular Variables
    Private TheEmployeeDataSet As EmployeeDataSet
    Private TheEmployeeDataTier As EmployeeDataTier
    Private WithEvents TheEmployeeBindingSource As BindingSource

    Private Sub FindHomeOfficeID_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'This will load up the form.
        Dim strHomeOffice As String
        Dim intWarehouseID As Integer = 0
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim strLastName As String
        Dim strFirstName As String

        Try

            TheEmployeeDataTier = New EmployeeDataTier
            TheEmployeeDataSet = TheEmployeeDataTier.GetEmployeeInformation
            TheEmployeeBindingSource = New BindingSource

            With TheEmployeeBindingSource
                .DataSource = TheEmployeeDataSet
                .DataMember = "employees"
                .MoveFirst()
                .MoveLast()
            End With

            With cboEmployeeID
                .DataSource = TheEmployeeBindingSource
                .DisplayMember = "EmployeeID"
                .DataBindings.Add("text", TheEmployeeBindingSource, "EmployeeID", False, DataSourceUpdateMode.Never)
            End With

            txtFirstName.DataBindings.Add("text", TheEmployeeBindingSource, "FirstName")
            txtLastName.DataBindings.Add("text", TheEmployeeBindingSource, "LastName")
            txtGroup.DataBindings.Add("text", TheEmployeeBindingSource, "Group")

            strHomeOffice = Logon.mstrHomeOffice

            intNumberOfRecords = cboEmployeeID.Items.Count - 1

            For intCounter = 0 To intNumberOfRecords

                cboEmployeeID.SelectedIndex = intCounter
                strLastName = txtLastName.Text
                strFirstName = txtFirstName.Text
                If strLastName = "WAREHOUSE" And strFirstName = strHomeOffice Then
                    intWarehouseID = CInt(cboEmployeeID.Text)
                End If

            Next

            Logon.mintWarehouseID = intWarehouseID
            Logon.mintHomeOfficeID = intWarehouseID

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Me.Close()

    End Sub
End Class