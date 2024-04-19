'Title:         Checking Employee Name
'Date:          6/30/14
'Name:          Terry Holmes

'Description:   This will check to see if the employee exists

Option Strict On

Public Class CheckingEmployeeName

    'Setting Modular Variables
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

    'Setting up Array
    Dim mintCounter As Integer
    Dim mintSelectedIndex(1000) As Integer
    Dim mintUpperLimit As Integer

    Private Sub CheckingEmployeeName_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim blnNameExists As Boolean = False
        Dim strLastNameForSearch As String
        Dim strLastNameFromTable As String
        Dim strFirstNameForSearch As String
        Dim strFirstNameFromTable As String

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
            With cboEmployeeID
                .DataSource = TheEmployeeBindingSource
                .DisplayMember = "EmployeeID"
                .DataBindings.Add("text", TheEmployeeBindingSource, "EmployeeID", False, DataSourceUpdateMode.Never)
            End With

            'Setting the data binding for the text boxes
            txtFirstName.DataBindings.Add("text", TheEmployeeBindingSource, "FirstName")
            txtLastName.DataBindings.Add("text", TheEmployeeBindingSource, "LastName")
            txtActive.DataBindings.Add("text", TheEmployeeBindingSource, "Active")
            txtPhoneNumber.DataBindings.Add("text", TheEmployeeBindingSource, "PhoneNumber")
            txtGroup.DataBindings.Add("text", TheEmployeeBindingSource, "Group")
            txtHomeOffice.DataBindings.Add("text", TheEmployeeBindingSource, "HomeOffice")
            txtTypeOfEmployee.DataBindings.Add("text", TheEmployeeBindingSource, "Type")


            'setting up loop variables
            intNumberOfRecords = cboEmployeeID.Items.Count - 1
            strFirstNameForSearch = CreateEmployee.mstrFirstName
            strLastNameForSearch = CreateEmployee.mstrLastName
            mintCounter = 0
            btnNext.Visible = False
            btnBack.Visible = False

            'running loop
            For intCounter = 0 To intNumberOfRecords

                'Setting up loop variables
                cboEmployeeID.SelectedIndex = intCounter
                strFirstNameFromTable = txtFirstName.Text
                strLastNameFromTable = txtLastName.Text

                'If conditional statements to see if the statements match
                If strLastNameForSearch = strLastNameFromTable Then
                    If strFirstNameForSearch = strFirstNameFromTable Then

                        'Setting up variables for a match
                        blnNameExists = True
                        mintSelectedIndex(mintCounter) = intCounter
                        mintCounter = mintCounter + 1

                    End If
                End If

            Next

            'Checking to see if there are multiple people with the same name
            If blnNameExists = False Then

                'Saves the Employee Record
                CreateEmployee.SaveRemployeeRecord()
                Me.Close()

            Else
                'Setting up array
                mintUpperLimit = mintCounter - 1
                mintCounter = 0
                cboEmployeeID.SelectedIndex = mintSelectedIndex(0)

                'Setting up buttons
                If mintUpperLimit > 0 Then
                    btnNext.Visible = True
                    btnBack.Visible = True
                    btnNext.Enabled = True
                End If
                'setting up the label
                lblEmployeeMessage.Text = "Entered Employee Has The Same Name as Another Employee.  Do You Want to Continue, Press Yes To Continue, No to Return"

            End If

        Catch ex As Exception

            'If an exception is thrown, it is rounted here
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnYes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnYes.Click

        'Saves the Employee Record
        CreateEmployee.SaveRemployeeRecord()
        Me.Close()

    End Sub

    Private Sub btnNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNo.Click
        'Closes the form
        Me.Close()
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click

        'Increments the Counter
        mintCounter = mintCounter + 1
        cboEmployeeID.SelectedIndex = mintSelectedIndex(mintCounter)

        btnBack.Enabled = True

        If mintCounter = mintUpperLimit Then
            btnNext.Enabled = False
        End If

    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click

        'decrements the Counter
        mintCounter = mintCounter - 1
        cboEmployeeID.SelectedIndex = mintSelectedIndex(mintCounter)

        btnNext.Enabled = True

        If mintCounter = 0 Then
            btnBack.Enabled = False
        End If

    End Sub
End Class