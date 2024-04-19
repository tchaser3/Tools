'Title:         Search for a Project
'Date:          2/9/14
'Author:        Terry Holmes

'Description:   This form will allow the user to search for a Project

Option Strict On

Public Class SearchForProject

    'Setting Modular Variables

    Private TheInternalProjectsDataSet As InternalProjectsDataSet
    Private TheInternalProjectsDataTier As InternalProjectsDataTier
    Private WithEvents TheInternalProjectsBindingSource As BindingSource

    Dim TheInputDataValidation As New InputDataValidation

    Dim mintProjectCounter As Integer
    Dim mintProjectSelectedIndex(1000) As Integer
    Dim mintProjectUpperLimit As Integer
    Dim mintKeyWordLengthForSearch As Integer

    Private addingBoolean As Boolean = False
    Private editingBoolean As Boolean = False
    Private previousSelectedIndex As Integer
    Dim mintNumuberOfRecords As Integer

    Dim LogDateTime As Date = DateAndTime.Now
    Dim strLogDateTime As String

    'Setting global variable
    Dim mintSelectedIndex(2000) As Integer
    Dim mintSelectedIndexCounter As Integer = 0
    Dim mintSelectedIndexUpperLimit As Integer

    Dim mintInternalProjectID As Integer

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click

        'Closes the Program
        CloseTheProgram.ShowDialog()

    End Sub
    Private Sub ClearArray()

        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer

        intNumberOfRecords = cboInternalProjectID.Items.Count - 1

        For intCounter = 0 To intNumberOfRecords

            mintProjectSelectedIndex(intCounter) = -1

        Next

    End Sub

    Private Sub btnMainMenu_Click(sender As System.Object, e As System.EventArgs) Handles btnMainMenu.Click

        'This displays the main menu
        MainMenu.Show()
        Me.Close()

    End Sub

    Private Sub btnInventoryMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInventoryMenu.Click

        'This displays the cable menu
        InventoryMenu.Show()
        Me.Close()

    End Sub

    Private Sub btnSelectProject_Click(sender As System.Object, e As System.EventArgs) Handles btnSelectProject.Click

        Logon.mintInternalProjectID = CInt(cboInternalProjectID.Text)
        If Logon.mstrSourceMenu = "CABLE" Then
            IssueCable.Show()
        ElseIf Logon.mstrSourceMenu = "ORDERS" Then

        ElseIf Logon.mstrSourceMenu = "RECEIVE ORDERS" Then

        ElseIf Logon.mstrSourceMenu = "CABLE USAGE" Then
            CableUsage.Show()
        End If


        Me.Close()

    End Sub

    Private Sub SearchForProject_Load(sender As Object, e As System.EventArgs) Handles Me.Load


        'This routine runs when the form is loaded up

        'This Try - Catch is used to protect the make sure that the program loads correctly
        'And if there is a problem, the exception is routed to a Message Box, instead of 
        'the whole program crashing
        Try

            'This will bind the controls to the data source
            TheInternalProjectsDataTier = New InternalProjectsDataTier
            TheInternalProjectsDataSet = TheInternalProjectsDataTier.GetInternalProjectsInformation
            TheInternalProjectsBindingSource = New BindingSource

            'Setting up Binding Source for the Combo Box
            With TheInternalProjectsBindingSource
                .DataSource = TheInternalProjectsDataSet
                .DataMember = "internalprojects"
                .MoveFirst()
                .MoveLast()
            End With

            'Setting the data relationship for the Combo Box
            With cboInternalProjectID
                .DataSource = TheInternalProjectsBindingSource
                .DisplayMember = "internalProjectID"
                .DataBindings.Add("text", TheInternalProjectsBindingSource, "internalProjectID", False, DataSourceUpdateMode.Never)
            End With

            'Setting the data binding for the text boxes
            txtProjectName.DataBindings.Add("text", TheInternalProjectsBindingSource, "ProjectName")
            txtTWCControlNumber.DataBindings.Add("text", TheInternalProjectsBindingSource, "TWCControlNumber")
            txtTWCCoordinator.DataBindings.Add("text", TheInternalProjectsBindingSource, "TWCCoordinator")
            txtDate.DataBindings.Add("text", TheInternalProjectsBindingSource, "Date")
            txtAddress.DataBindings.Add("text", TheInternalProjectsBindingSource, "Address")
            txtCity.DataBindings.Add("text", TheInternalProjectsBindingSource, "City")
            txtState.DataBindings.Add("text", TheInternalProjectsBindingSource, "State")
            txtSupplyingWarehouse.DataBindings.Add("text", TheInternalProjectsBindingSource, "SupplyingWarehouse")
            txtManagerID.DataBindings.Add("text", TheInternalProjectsBindingSource, "ManagerID")

        Catch ex As Exception

            'If an exception is thrown, it is rounted here
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub btnInternalProjectIDSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInternalProjectIDSearch.Click

        Dim intNumberOfRecords As Integer
        Dim intInternalProjectIDForSearching As Integer
        Dim intInternalProjectIDFromTable As Integer
        Dim intCounter As Integer
        Dim intSelectedIndex As Integer
        Dim strValueForValidation As String
        Dim blnFatalError As Boolean = False
        Dim blnPartNumberFound As Boolean = False

        mintSelectedIndexCounter = 0
        mintSelectedIndexUpperLimit = 0

        strValueForValidation = txtSearchInternalProjectID.Text
        blnFatalError = TheInputDataValidation.VerifyIntegerData(strValueForValidation)

        If blnFatalError = True Then
            MessageBox.Show("The Internal Project ID Was Not Entered", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        intNumberOfRecords = cboInternalProjectID.Items.Count - 1
        intInternalProjectIDForSearching = CInt(txtSearchInternalProjectID.Text)

        For intCounter = 0 To intNumberOfRecords

            cboInternalProjectID.SelectedIndex = intCounter
            intInternalProjectIDFromTable = CInt(cboInternalProjectID.Text)

            If intInternalProjectIDForSearching = intInternalProjectIDFromTable Then
                blnPartNumberFound = True
                intSelectedIndex = intCounter
            End If

        Next

        If blnPartNumberFound = True Then
            cboInternalProjectID.SelectedIndex = intSelectedIndex
        Else
            MessageBox.Show("The Part Number Entered Was Not Found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub btnProjectNameSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProjectNameSearch.Click

        Dim intKeyWordLengthFromTable As Integer = 0
        Dim intNumberOfRecords As Integer = 0
        Dim strKeyWordForSearch As String = ""
        Dim strKeywordFromTable As String = ""
        Dim chaKeywordInputArray() As Char
        Dim blnFatalError As Boolean
        Dim intProjectIDCounter As Integer = 0
        Dim intKeyWordCounter As Integer = 0
        Dim intCharacterCounter As Integer = 0
        Dim strTempString As String

        'Setting buttons up
        btnNavigationBack.Enabled = False
        btnNavigationNext.Enabled = False

        'validating key word 
        strKeyWordForSearch = txtSearchProjectName.Text
        strTempString = strKeyWordForSearch
        blnFatalError = TheInputDataValidation.VerifyTextData(strKeyWordForSearch)

        'Outputting to user if there is a problem
        If blnFatalError = True Then
            MessageBox.Show("The Project Name Was Not Entered", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        mintKeyWordLengthForSearch = strKeyWordForSearch.Length - 1
        blnFatalError = True

        'Resetting the array
        ClearArray()

        'Setting up loop variables
        intNumberOfRecords = cboInternalProjectID.Items.Count - 1
        mintKeyWordLengthForSearch = txtSearchProjectName.TextLength - 1
        mintProjectCounter = 0
        mintProjectUpperLimit = 0

        'Performing the Part ID Loop
        For intPartIDCounter = 0 To intNumberOfRecords

            'Setting up other loop variables
            cboInternalProjectID.SelectedIndex = intPartIDCounter
            intKeyWordLengthFromTable = txtProjectName.TextLength - 1
            chaKeywordInputArray = txtProjectName.Text.ToCharArray
            intCharacterCounter = mintKeyWordLengthForSearch

            'Beginning second loop
            If mintKeyWordLengthForSearch <= intKeyWordLengthFromTable Then

                'Beginning second loop for counting the characters within a string
                For intPartDescriptionCounter = 0 To intKeyWordLengthFromTable

                    For intKeyWordCounter = intPartDescriptionCounter To intCharacterCounter

                        'Setting the character array
                        strKeywordFromTable = strKeywordFromTable + chaKeywordInputArray(intKeyWordCounter)

                    Next

                    'Setting up for the next loop
                    If intCharacterCounter < intKeyWordLengthFromTable Then
                        intCharacterCounter = intCharacterCounter + 1
                    End If

                    'Comparing the string
                    If strKeyWordForSearch = strKeywordFromTable Then
                        mintProjectSelectedIndex(mintProjectCounter) = intPartIDCounter
                        mintProjectCounter += 1
                        blnFatalError = False
                    End If

                    'Clearing the table string for the next loop
                    strKeywordFromTable = ""

                Next

                'Resetting the character counter
                intCharacterCounter = mintKeyWordLengthForSearch

            End If
        Next

        If blnFatalError = True Then
            MessageBox.Show("The Key Word Entered Is Not Found", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtSearchProjectName.Text = ""
            Exit Sub
        End If

        'Setting up controls
        mintProjectUpperLimit = mintProjectCounter - 1
        mintProjectCounter = 0
        cboInternalProjectID.SelectedIndex = mintProjectSelectedIndex(0)

        If mintProjectUpperLimit > 0 Then
            btnNavigationNext.Enabled = True
        End If

        txtSearchProjectName.Text = ""


    End Sub

    Private Sub btnTWProjectNoSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTWProjectNoSearch.Click

        Dim intNumberOfRecords As Integer
        Dim strTWCControlNumberForSearching As String
        Dim strTWCControlNumberFromTable As String
        Dim intCounter As Integer
        Dim intSelectedIndex As Integer
        Dim strValueForValidation As String
        Dim blnFatalError As Boolean = False
        Dim blnPartNumberFound As Boolean = False

        mintSelectedIndexCounter = 0
        mintSelectedIndexUpperLimit = 0

        strValueForValidation = txtTWCControlNumberForSearching.Text
        blnFatalError = TheInputDataValidation.VerifyTextData(strValueForValidation)

        If blnFatalError = True Then
            MessageBox.Show("The TWC Project ID was not Entered", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        intNumberOfRecords = cboInternalProjectID.Items.Count - 1
        strTWCControlNumberForSearching = txtTWCControlNumberForSearching.Text

        For intCounter = 0 To intNumberOfRecords

            cboInternalProjectID.SelectedIndex = intCounter
            strTWCControlNumberFromTable = txtTWCControlNumber.Text

            If strTWCControlNumberForSearching = strTWCControlNumberFromTable Then
                blnPartNumberFound = True
                intSelectedIndex = intCounter
            End If

        Next

        If blnPartNumberFound = True Then
            cboInternalProjectID.SelectedIndex = intSelectedIndex
        Else
            MessageBox.Show("The TW Project ID Entered Was Not Found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub
    Private Sub btnNavigationNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNavigationNext.Click

        mintProjectCounter += 1
        cboInternalProjectID.SelectedIndex = mintProjectSelectedIndex(mintProjectCounter)

        btnNavigationBack.Enabled = True

        If mintProjectCounter = mintProjectUpperLimit Then
            btnNavigationNext.Enabled = False
        End If

    End Sub

    Private Sub btnNavigationBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNavigationBack.Click

        mintProjectCounter -= 1
        cboInternalProjectID.SelectedIndex = mintProjectSelectedIndex(mintProjectCounter)

        btnNavigationNext.Enabled = True

        If mintProjectCounter = 0 Then
            btnNavigationBack.Enabled = False
        End If

    End Sub
End Class