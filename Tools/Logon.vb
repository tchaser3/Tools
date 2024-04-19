'Title:     Logon Form
'Date:      4/2/13
'Author:    Terry Holmes

Option Strict On
Imports System.IO

Public Class Logon

    'Setting Global Variables
    Friend mblnAreYouSure As Boolean
    Friend mstrDownForRepair As String
    Friend mblnWorkOrderCreated As Boolean
    Friend mintQuantity As Integer
    Friend mintPartsWarehouseID As Integer
    Friend mstrSelectionOrigination As String
    Friend mstrTWCProjectID As String
    Friend mstrProjectName As String
    Friend mintWorkOrderNumber As Integer
    Friend mintOdometerTransferred As Integer
    Friend mintNumberOfDays As Integer
    Friend mstrPartNumber As String
    Friend mstrToolCategory As String
    Friend mstrAssetCategory As String
    Friend mblnAssetCategoryExists As Boolean
    Friend mblnToolCategoryExists As Boolean
    Friend mstrGroup As String
    Friend mstrFirstName As String
    Friend mstrLastName As String
    Friend mintEmployeeID As Integer
    Friend mintAccessoryID As Integer
    Friend mintDeviceID As Integer
    Friend mintWarehouseEmployeeID As Integer
    Friend mintWarehouseID As Integer
    Friend mintCreatedInspectionID As Integer = 0
    Friend mintBJCNumber As Integer
    Friend mdatStartingDate As Date
    Friend mdatEndingDate As Date
    Friend mdatDateForDataEntry As Date
    Friend mstrFormForDataEntry As String
    Friend mstrTypeOfDateSearch As String
    Friend mstrHomeOffice As String
    Friend mintHomeOfficeID As Integer
    Friend mstrEmployeeType As String
    Dim mintNumberOfMisses As Integer
    Friend mintCreatedTransactionID As Integer
    Friend mintCreatedToolTransactionID As Integer
    Friend mstrToolID As String
    Friend mstrAvailability As String
    Friend mstrLogDateTime As String
    Friend mintVehicleID As Integer
    Friend mstrActive As String
    Friend mstrNotes As String
    Friend mintHistoryEmployeeID As Integer
    Friend mintReelTransactionID As Integer
    Friend mstrReelID As String
    Friend mstrCablePartNumber As String
    Friend mstrCategory As String
    Friend mstrTWReelID As String
    Friend mintCurrentFootage As Integer
    Friend mstrMSR As String
    Friend mdatDate As Date
    Friend mstrWarehouse As String
    Friend mbolFatalError As Boolean
    Friend mintCreatedToolID As Integer
    Friend mstrCableSelectionType As String
    Friend mintInternalProjectID As Integer
    Friend mbolFootageIsNotZero As Boolean
    Friend mblnDeviceConfirmation As Boolean
    Friend mstrReelType As String
    Friend mstrReelCategory As String
    Friend mblnReturnReel As Boolean
    Friend mstrRemoteVehicle As String
    Friend mblnOilChangeDate As Boolean
    Friend mstrLastTransactionSummary As String
    Friend mstrLastTransactionAction As String = "OPEN"

    'Global Variables for Inventory Module
    Friend mintPartID As Integer
    Friend mstrSourceMenu As String

    'Global Variables for Trailers
    Friend mintTrailerID As Integer
    Friend mintTrailerEmployeeID As Integer

    Dim TheInputDataValidation As New InputDataValidation

    'Calling Modular Variables
    Private TheEmployeeDataSet As EmployeeDataSet
    Private TheEmployeeDataTier As EmployeeDataTier
    Private WithEvents TheEmployeeBindingSource As BindingSource

    'Global Variables for Returing Cables
    Friend mblnProblemWithReturn As Boolean = True

    Private Sub btnLogon_Click(sender As System.Object, e As System.EventArgs) Handles btnLogon.Click
        'Log the User In

        'Setting Local Variables
        Dim intEmployeeID As Integer
        Dim intEmployeeIDFromTable As Integer
        Dim blnEmployeeID As Boolean = False
        Dim intNumberOfRecords As Integer = 0
        Dim strLogDateTime As String
        Dim blnFatalError As Boolean = False
        Dim LogDateTime As Date = DateAndTime.Now
        Dim strErrorMessage = ""
        Dim strValueForValidation As String
        Dim blnEmployeeIDCorrect = False
        Dim strLoginMessage As String
        Dim strLastNameEntered As String
        Dim strLastNameFromTable As String
        Dim strActive As String

        Try

            strValueForValidation = txtEmployeeID.Text

            blnFatalError = TheInputDataValidation.VerifyIntegerData(strValueForValidation)

            If blnFatalError = False Then
                strValueForValidation = txtLogonLastName.Text
                blnFatalError = TheInputDataValidation.VerifyTextData(strValueForValidation)
            End If

            'Checking to see if there are any errors.
            If (blnFatalError = True) Then
                MessageBox.Show("Employee ID Was Not Entered", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtEmployeeID.Text = ""
                Exit Sub
            End If

            strLogDateTime = CStr(LogDateTime)

            'Making controls visible
            cboEmployeeID.Visible = True
            txtFirstName.Visible = True
            txtLastName.Visible = True
            txtGroup.Visible = True
            txtHomeOffice.Visible = True
            txtType.Visible = True
            lblTestValue.Visible = True
            txtActive.Visible = True

            'Getting the number of items in the table
            intNumberOfRecords = cboEmployeeID.Items.Count
            strLastNameEntered = txtLogonLastName.Text

            'Preforming Compare to find if the ID exists
            For intCounter = 0 To intNumberOfRecords - 1
                cboEmployeeID.SelectedIndex = intCounter
                intEmployeeID = CInt(txtEmployeeID.Text)
                intEmployeeIDFromTable = CInt(lblTestValue.Text)
                strLastNameFromTable = txtLastName.Text
                strActive = txtActive.Text

                'Finding group for the user
                If intEmployeeID = intEmployeeIDFromTable And strLastNameEntered = strLastNameFromTable Then

                    If strActive = "NO" Then
                        txtEmployeeID.Text = ""
                        txtLogonLastName.Text = ""
                        ClearTextBoxes()
                        MessageBox.Show("This Employee Is No Longer with The Company", "Do Not Attempt Again", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                    intCounter = intNumberOfRecords
                    blnEmployeeIDCorrect = True
                    mstrGroup = CStr(txtGroup.Text)
                    If (mstrGroup <> "ADMIN") Then
                    ElseIf (mstrGroup <> "WAREHOUSE") Then
                    ElseIf (mstrGroup <> "MANAGERS") Then
                    ElseIf (mstrGroup <> "OFFICE") Then
                    ElseIf (mstrGroup <> "USERS") Then
                    Else
                        MessageBox.Show("You are not Authorized to use this application", "Do Not Continue", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                        strLoginMessage = strLogDateTime + " A Person has Tried to Access the System that is not Authorized"
                        WriteToLog(strLoginMessage)
                        InvisibleControls()
                        Exit Sub
                    End If

                    If mstrGroup = "WAREHOUSE" Or mstrGroup = "ADMIN" Then
                        mintWarehouseEmployeeID = CInt(txtEmployeeID.Text)
                    End If

                    mstrLastName = txtLastName.Text
                    mstrFirstName = txtFirstName.Text
                    mintEmployeeID = intEmployeeID
                    mstrHomeOffice = txtHomeOffice.Text
                    FindHomeOfficeID.Show()
                    mstrEmployeeType = txtType.Text
                End If
            Next

            InvisibleControls()

            If blnEmployeeIDCorrect = False Then
                mintNumberOfMisses = mintNumberOfMisses + 1
                If mintNumberOfMisses = 3 Then
                    MessageBox.Show("You have failed three times to log in, the program will close", "Thank You", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    strLoginMessage = strLogDateTime + " There has been an atempt to Access the System and has failed three times"
                    WriteToLog(strLoginMessage)
                    Me.Close()
                End If
                txtEmployeeID.Text = ""
                txtLogonLastName.Text = ""
                MessageBox.Show("Your ID or Last Name is not Correct", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            MessageBox.Show(mstrFirstName + " " + mstrLastName + " is logged in", "Thank You", MessageBoxButtons.OK, MessageBoxIcon.Information)

            strLoginMessage = strLogDateTime + " " + mstrFirstName + " " + mstrLastName + " Logged In as User Type " + mstrGroup
            WriteToLog(strLoginMessage)
            mstrLastTransactionSummary = mstrFirstName + " " + mstrLastName + " LOGGING ON APPLICATION"
            LastTransaction.Show()
            mstrSelectionOrigination = "LOGON"
            AutoSignIn.Show()
            Me.Hide()

        Catch

            ClearTextBoxes()
            MessageBox.Show("The Program has encountered an Error, The Program Will Close", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()

        End Try

    End Sub
    Private Sub ClearTextBoxes()
        cboEmployeeID.Visible = False
        txtLastName.Visible = False
        txtFirstName.Visible = False
        txtGroup.Visible = False
        txtActive.Visible = False
        txtHomeOffice.Visible = False
        txtType.Visible = False
        lblTestValue.Text = ""
    End Sub

    Private Sub Logon_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Try
            mintNumberOfMisses = 0
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
            txtActive.DataBindings.Add("text", TheEmployeeBindingSource, "Active")
            lblTestValue.DataBindings.Add("text", TheEmployeeBindingSource, "EmployeeID")
            txtHomeOffice.DataBindings.Add("text", TheEmployeeBindingSource, "HomeOffice")
            txtType.DataBindings.Add("text", TheEmployeeBindingSource, "Type")

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub InvisibleControls()
        txtFirstName.Visible = False
        txtLastName.Visible = False
        txtGroup.Visible = False
        lblTestValue.Visible = False
        cboEmployeeID.Visible = False
        txtActive.Visible = False
        txtHomeOffice.Visible = False
        txtType.Visible = False
    End Sub

    Private Sub WriteToLog(ByVal strLoginMessage As String)

        Dim LogWriter As New StreamWriter("login.crp", True)
        LogWriter.WriteLine(strLoginMessage)
        LogWriter.Close()

    End Sub

    Private Sub txtEmployeeID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEmployeeID.KeyDown

        'This will run if the Enter Key is press
        If e.KeyCode = Keys.Enter Then
            txtLogonLastName.Focus()
        End If

    End Sub

    Private Sub txtLogonLastName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLogonLastName.KeyDown

        If e.KeyCode = Keys.Enter Then
            btnLogon.PerformClick()
        End If

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        CloseTheProgram.ShowDialog()
    End Sub
End Class