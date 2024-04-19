'Title:         View Last Transactions
'Date:          2-10-15
'Author:        Terry Holmes

'Description:   This will allow the user to view thier last transactions

Option Strict On

Public Class ViewLastTransactions

    'Setting up the global data sources
    Private TheLastTransactionDataSet As LastTransactionDataSet
    Private TheLastTransactionDataTier As LastTransactionDataTier
    Private WithEvents TheLastTransactionBindingSource As BindingSource

    'Setting up array
    Dim mintCounter As Integer
    Dim mintSelectedIndex() As Integer
    Dim mintUpperLimit As Integer
    Dim TheInputDataValidation As New InputDataValidation

    Structure LastTransactions
        Dim mintTransactionID As Integer
        Dim mintEmployeeID As Integer
        Dim mdatDate As Date
        Dim mstrLastTransaction As String
    End Structure

    Dim structLastTransactions() As LastTransactions
    Dim mintTransactionCounter As Integer
    Dim mintTransactionUpperLimit As Integer

    Private Sub ViewLastTransaction_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load

        'This will load when the form is launched
        'Try Catch for exceptions
        'Setting local variables
        Dim intNumberOfRecords As Integer
        Dim intCounter As Integer
        Dim strValueForValidation As String

        PleaseWait.Show()

        Try

            'Setting up the data set
            TheLastTransactionDataTier = New LastTransactionDataTier
            TheLastTransactionDataSet = TheLastTransactionDataTier.GetLastTransactionInformation
            TheLastTransactionBindingSource = New BindingSource

            'Setting up the binding source
            With TheLastTransactionBindingSource
                .DataSource = TheLastTransactionDataSet
                .DataMember = "lasttransaction"
                .MoveFirst()
                .MoveLast()
            End With

            'Setting up the combo box
            With cboTransactionID
                .DataSource = TheLastTransactionBindingSource
                .DisplayMember = "TransactionID"
                .DataBindings.Add("text", TheLastTransactionBindingSource, "TransactionID", False, DataSourceUpdateMode.Never)
            End With

            'Setting up the rest of the controls
            txtEmployeeID.DataBindings.Add("text", TheLastTransactionBindingSource, "EmployeeID")
            txtDate.DataBindings.Add("text", TheLastTransactionBindingSource, "Date")
            txtLastTransactionSummary.DataBindings.Add("text", TheLastTransactionBindingSource, "LastTransactionSummary")

            intNumberOfRecords = cboTransactionID.Items.Count - 1
            ReDim mintSelectedIndex(intNumberOfRecords)
            ReDim structLastTransactions(intNumberOfRecords)
            mintTransactionUpperLimit = intNumberOfRecords

            For intCounter = 0 To intNumberOfRecords

                'Incrementing the combo box
                cboTransactionID.SelectedIndex = intCounter

                structLastTransactions(intCounter).mintTransactionID = CInt(cboTransactionID.Text)
                structLastTransactions(intCounter).mintEmployeeID = CInt(txtEmployeeID.Text)

                'Setting up for the date
                strValueForValidation = txtDate.Text

                If strValueForValidation = "" Then
                    strValueForValidation = "1/1/15"
                End If

                structLastTransactions(intCounter).mdatDate = CDate(strValueForValidation)
                structLastTransactions(intCounter).mstrLastTransaction = txtLastTransactionSummary.Text

            Next

            'Setting defaault value
            txtNumberOfLastTransactions.Text = "10"

            'Calling sub routine
            FindLastTransactionsForEmployee()

            PleaseWait.Close()

        Catch ex As Exception
            PleaseWait.Close()
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub FindLastTransactionsForEmployee()

        'This will find the number of last transactions

        'Setting local variables
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim strValueForValidation As String
        Dim blnFatalError As Boolean = False
        Dim intEmployeeIDForSearch As Integer
        Dim intEmployeeIDFromTable As Integer
        Dim intNumberOfTransactionRequested As Integer

        'Setting navigation buttons
        btnNext.Enabled = False
        btnBack.Enabled = False

        'Performing data validation
        strValueForValidation = txtNumberOfLastTransactions.Text
        blnFatalError = TheInputDataValidation.VerifyIntegerData(strValueForValidation)

        'Output to user
        If blnFatalError = True Then
            txtNumberOfLastTransactions.Text = ""
            MessageBox.Show("Number Of Last Transactions is not an Integer", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        'Setting up for loop
        intNumberOfRecords = mintTransactionUpperLimit
        intEmployeeIDForSearch = Logon.mintEmployeeID
        mintCounter = 0
        intNumberOfTransactionRequested = CInt(txtNumberOfLastTransactions.Text)

        For intCounter = intNumberOfRecords To 0 Step -1

            'getting employee id
            intEmployeeIDFromTable = structLastTransactions(intCounter).mintEmployeeID

            'If statement to see if the IDs match
            If intEmployeeIDForSearch = intEmployeeIDFromTable Then

                'Setting up the array
                mintSelectedIndex(mintCounter) = intCounter
                mintCounter += 1

                'If statement to see if the loop is done
                If mintCounter = intNumberOfRecords Then
                    intCounter = 0
                End If

            End If

        Next

        mintUpperLimit = mintCounter - 1

        If mintUpperLimit >= intNumberOfTransactionRequested - 1 Then
            mintUpperLimit = intNumberOfTransactionRequested - 1
        End If

        'Setting up the navigation buttons
        If mintUpperLimit > 0 Then
            btnNext.Enabled = True
        End If

        mintCounter = 0
        cboTransactionID.SelectedIndex = mintSelectedIndex(0)

    End Sub

    Private Sub btnAdministrativeMenu_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAdministrativeMenu.Click

        'This will launch the Administrative Menu
        LastTransaction.Show()
        AdministrativeMenu.Show()
        Me.Close()

    End Sub

    Private Sub btnMainMenu_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnMainMenu.Click

        'This will open up the main menu
        LastTransaction.Show()
        MainMenu.Show()
        Me.Close()

    End Sub

    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClose.Click

        'This will close the application
        CloseTheProgram.ShowDialog()

    End Sub

    Private Sub btnFindTransaction_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnFindTransaction.Click

        'Calling sub routine
        FindLastTransactionsForEmployee()

    End Sub

    Private Sub btnNext_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnNext.Click

        'Setting up the counter variable
        mintCounter += 1

        'This will increment the combo box
        cboTransactionID.SelectedIndex = mintSelectedIndex(mintCounter)

        'setting the navigation button
        btnBack.Enabled = True

        'Checking to see if to the other button is disabled
        If mintCounter = mintUpperLimit Then
            btnNext.Enabled = False
        End If

    End Sub

    Private Sub btnBack_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBack.Click

        'Setting up the counter variable
        mintCounter -= 1

        'This will increment the combo box
        cboTransactionID.SelectedIndex = mintSelectedIndex(mintCounter)

        'setting the navigation button
        btnNext.Enabled = True

        'Checking to see if to the other button is disabled
        If mintCounter = 0 Then
            btnBack.Enabled = False
        End If

    End Sub

End Class