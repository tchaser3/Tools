'Title:         Change Information Technology Password
'Date:          9-16-14
'Author:        Terry Holmes

Option Strict On

Public Class ChangeInformationTechnologyPassword

    'Setting global data variables
    Private TheInformationTechnologyPasswordDataSet As InformationTechnologyPasswordDataSet
    Private TheInformationTechnologyPasswordDataTier As InformationTechnologyDataTier
    Private WithEvents TheInformationTechnologyPasswordBindingSource As BindingSource

    Dim mstrPasswordFromTable As String
    Private TheInputDataValidation As New InputDataValidation

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        'Closes the Program
        CloseTheProgram.ShowDialog()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInformationTechnologyMenu.Click
        InformationTechnologyMenu.Show()
        Me.Close()
    End Sub

    Private Sub btnMainMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMainMenu.Click
        MainMenu.Show()
        Me.Close()
    End Sub

    Private Sub ChangeInformationTechnologyPassword_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Setting Bindings to get old password value
        SetPasswordBindings()

        'Beginning to get information
        mstrPasswordFromTable = txtOldPassword.Text

        'Clears Password Bindings
        ClearPasswordBindings()
        txtOldPassword.Text = ""

    End Sub
    Private Sub SetPasswordBindings()

        Try
            'Setting up the data controls
            TheInformationTechnologyPasswordDataTier = New InformationTechnologyDataTier
            TheInformationTechnologyPasswordDataSet = TheInformationTechnologyPasswordDataTier.GetInformationTechnologyPasswordInformation
            TheInformationTechnologyPasswordBindingSource = New BindingSource

            'Setting up the Binding Source
            With TheInformationTechnologyPasswordBindingSource
                .DataSource = TheInformationTechnologyPasswordDataSet
                .DataMember = "informationtechnologypassword"
                .MoveFirst()
                .MoveLast()
            End With

            With cboTransactionID
                .DataSource = TheInformationTechnologyPasswordBindingSource
                .DisplayMember = "TransactionID"
                .DataBindings.Add("text", TheInformationTechnologyPasswordBindingSource, "TransactionID", False, DataSourceUpdateMode.Never)
            End With

            txtOldPassword.DataBindings.Add("text", TheInformationTechnologyPasswordBindingSource, "Password")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "There is a problem", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub ClearPasswordBindings()

        'Clears the Bindings
        cboTransactionID.DataBindings.Clear()
        txtOldPassword.DataBindings.Clear()

    End Sub

    Private Sub btnChangePassword_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangePassword.Click

        'This will run and change the password

        'Setting local variables
        Dim strOldPasswordEntered As String
        Dim strEnterNewPassword As String
        Dim strConformNewPassword As String
        Dim blnFatalError As Boolean = False
        Dim strErrorMessage As String

        'Preforming Data Validation
        strOldPasswordEntered = txtOldPassword.Text
        strEnterNewPassword = txtEnterNewPassword.Text
        strConformNewPassword = txtConfirmNewPassword.Text

        'If Statements for data validation
        blnFatalError = TheInputDataValidation.VerifyTextData(strOldPasswordEntered)
        strErrorMessage = "Old Password WAs Not Entered"
        If blnFatalError = False Then
            blnFatalError = TheInputDataValidation.VerifyTextData(strEnterNewPassword)
            strErrorMessage = "New Password Was Not Entered"
            If blnFatalError = False Then
                blnFatalError = TheInputDataValidation.VerifyTextData(strConformNewPassword)
                strErrorMessage = "Confirming New Password Was Not Entered"
            End If
        End If

        If blnFatalError = True Then
            MessageBox.Show(strErrorMessage, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If strOldPasswordEntered <> mstrPasswordFromTable Then
            MessageBox.Show("Old Password Does Not Match", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtOldPassword.Text = ""
            Exit Sub
        End If

        If strConformNewPassword <> strEnterNewPassword Then
            MessageBox.Show("New Passwords Do Not Match", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtConfirmNewPassword.Text = ""
            txtEnterNewPassword.Text = ""
            Exit Sub
        End If

        'Updating Data Set
        SetPasswordBindings()
        txtOldPassword.Text = strEnterNewPassword

        Try
            'Updating the data set
            TheInformationTechnologyPasswordBindingSource.EndEdit()
            TheInformationTechnologyPasswordDataTier.UpdateInformationTechnologyPasswordDB(TheInformationTechnologyPasswordDataSet)
            MessageBox.Show("The Password Has Been Changed", "Thank You", MessageBoxButtons.OK, MessageBoxIcon.Information)

            'Clearing the controls
            ClearPasswordBindings()
            txtConfirmNewPassword.Text = ""
            txtEnterNewPassword.Text = ""
            txtOldPassword.Text = ""

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
End Class