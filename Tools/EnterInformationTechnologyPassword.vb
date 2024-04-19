'Title:         Enter Information Technology Password
'Date:          9/16/14
'Author:        Terry Holmes

'Description:   A password is entered to access the Information Technology Menu

Option Strict On

Public Class EnterInformationTechnologyPassword

    'Setting global data variables
    Private TheInformationTechnologyPasswordDataSet As InformationTechnologyPasswordDataSet
    Private TheInformationTechnologyPasswordDataTier As InformationTechnologyDataTier
    Private WithEvents TheInformationTechnologyBindingSource As BindingSource

    'Setting global variables.
    Dim mintCounter As Integer
    Dim mblnPassordIsNotCorrect As Boolean
    Private TheInputDataValidation As New InputDataValidation
    Dim mstrPasswords() As String
    Dim mintUpperLimit As Integer

    Private Sub EnterInformationTechnologyPassword_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Setting local variables
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer

        'Binding the controls
        Try

            'Setting up the data controls
            TheInformationTechnologyPasswordDataTier = New InformationTechnologyDataTier
            TheInformationTechnologyPasswordDataSet = TheInformationTechnologyPasswordDataTier.GetInformationTechnologyPasswordInformation
            TheInformationTechnologyBindingSource = New BindingSource

            'Setting up the Binding Source
            With TheInformationTechnologyBindingSource
                .DataSource = TheInformationTechnologyPasswordDataSet
                .DataMember = "informationtechnologypassword"
                .MoveFirst()
                .MoveLast()
            End With

            With cboTransactionID
                .DataSource = TheInformationTechnologyBindingSource
                .DisplayMember = "TransactionID"
                .DataBindings.Add("text", TheInformationTechnologyBindingSource, "TransactionID", False, DataSourceUpdateMode.Never)
            End With

            txtEnterPassword.DataBindings.Add("text", TheInformationTechnologyBindingSource, "Password")

            'Setting up array
            intNumberOfRecords = cboTransactionID.Items.Count - 1
            ReDim mstrPasswords(intNumberOfRecords)
            mintUpperLimit = intNumberOfRecords

            'Loading array
            For intCounter = 0 To intNumberOfRecords

                'incrementing the combo box
                cboTransactionID.SelectedIndex = intCounter

                'Setting array
                mstrPasswords(intCounter) = txtEnterPassword.Text

            Next

            txtEnterPassword.DataBindings.Clear()
            txtEnterPassword.Text = ""
            mintCounter = 0
            txtEnterPassword.Focus()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

        'This will run when the button is pressed

        'Setting local variables
        Dim blnFatalError As Boolean
        Dim strPasswordEntered As String
        Dim intCounter As Integer

        'Perparing for data valiation
        strPasswordEntered = txtEnterPassword.Text
        blnFatalError = TheInputDataValidation.VerifyTextData(strPasswordEntered)
        mblnPassordIsNotCorrect = True

        'Preforming data validation
        If blnFatalError = True Then
            MessageBox.Show("The Password Was Not Entered", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        'Checking to see if the passwords match
        For intCounter = 0 To mintUpperLimit

            If mstrPasswords(intCounter) = strPasswordEntered Then
                mblnPassordIsNotCorrect = False
            End If
        Next

        'Checking boolean variable to see if the passwords match
        If mblnPassordIsNotCorrect = False Then
            InformationTechnologyMenu.Show()
            Me.Close()
        Else

            'Message Box to user to let them know that the passwords did not match
            txtEnterPassword.Text = ""
            MessageBox.Show("Password Entered is Incorrect", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Error)
            mintCounter += 1

            'Checking the number of failures
            If mintCounter >= 3 Then
                MessageBox.Show("There have been three attemps, the application will return to the Main Menu", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error)
                MainMenu.Show()
                Me.Close()
            End If

        End If

    End Sub

    Private Sub txtEnterPassword_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEnterPassword.KeyDown

        If e.KeyCode = Keys.Enter Then
            btnOK.PerformClick()
        End If

    End Sub
End Class