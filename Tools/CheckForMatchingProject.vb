'Title:         Check For a Matching Project
'Date:          6/30/14
'Author:        Terry Holmes

'Description:   This form is used to check to see if the project exists

'Update:        8-28-15 - Added Gridview and made search faster using a structure
'               Project Name is done with a Keyword Search

Option Strict On

Public Class CheckForMatchingProject

    Private TheInternalProjectsDataSet As InternalProjectsDataSet
    Private TheInternalProjectsDataTier As InternalProjectsDataTier
    Private WithEvents TheInternalProjectsBindingSource As BindingSource

    Dim TheInputDataValidation As New InputDataValidation
    Dim TheKeyWordSearchClass As New KeyWordSearchClass

    Private addingBoolean As Boolean = False
    Private editingBoolean As Boolean = False
    Private previousSelectedIndex As Integer
    Dim mintNumuberOfRecords As Integer

    Dim LogDateTime As Date = DateAndTime.Now
    Dim strLogDateTime As String

    'setting up array
    Structure SearchResults
        Dim mintSelectedIndex As Integer
        Dim mintInternalProjectID As Integer
        Dim mstrTWCProjectID As String
        Dim mstrProjectName As String
        Dim mstrMSRNumber As String
    End Structure

    Dim structSearchResults() As SearchResults
    Dim mintResultCounter As Integer
    Dim mintResultUpperLimit As Integer

   
    Private Sub btnNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNo.Click

        'Closes this form only
        Me.Close()

    End Sub

    Private Sub btnYes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnYes.Click

        InternalProjects.UpdateProjectDataTables()
        Me.Close()

    End Sub

    Private Sub CheckForMatchingProject_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Setting local variables
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim blnRecordFound As Boolean = False
        Dim strTWCProjectIDForSearch As String
        Dim strTWCProjectIDFromTable As String
        Dim strProjectNameForSearch As String
        Dim strMSRNumberForSearch As String
        Dim strMSRNumberFromTable As String
        Dim strProjectNameFromTable As String
        Dim blnKeywordSearchResults As Boolean
        Dim blnProjectSearchResults As Boolean
        Dim row() As String
        Dim blnNotanInteger As Boolean = False
        Dim blnItemNotFound As Boolean
        Dim blnMSRNumberMatches As Boolean

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
            txtMSRNumber.DataBindings.Add("text", TheInternalProjectsBindingSource, "MSRNumber")

            'Setting up for the loop
            intNumberOfRecords = cboInternalProjectID.Items.Count - 1
            strTWCProjectIDForSearch = Logon.mstrTWCProjectID
            strProjectNameForSearch = Logon.mstrProjectName
            strMSRNumberForSearch = Logon.mstrMSR
            ReDim structSearchResults(intNumberOfRecords)
            mintResultCounter = 0
            blnNotanInteger = TheInputDataValidation.VerifyIntegerData(strTWCProjectIDForSearch)

            'beginning Loop
            For intCounter = 0 To intNumberOfRecords

                blnItemNotFound = True
                blnMSRNumberMatches = False

                'Incrementing the combo box
                cboInternalProjectID.SelectedIndex = intCounter

                'Getting variables for if statements
                strProjectNameFromTable = txtProjectName.Text
                strTWCProjectIDFromTable = txtTWCControlNumber.Text
                strMSRNumberFromTable = txtMSRNumber.Text

                If strMSRNumberFromTable <> "" Then
                    If strMSRNumberForSearch = strMSRNumberFromTable Then
                        blnMSRNumberMatches = True
                    End If
                End If

                'keyword compare
                blnProjectSearchResults = TheKeyWordSearchClass.FindKeyWord(strProjectNameForSearch, strProjectNameFromTable)
                blnKeywordSearchResults = TheKeyWordSearchClass.FindKeyWord(strTWCProjectIDForSearch, strProjectNameFromTable)

                If blnKeywordSearchResults = False Or strTWCProjectIDForSearch = strTWCProjectIDFromTable Or blnProjectSearchResults = False Or blnMSRNumberMatches = True Then

                    'loading up the structure
                    structSearchResults(mintResultCounter).mintSelectedIndex = intCounter
                    structSearchResults(mintResultCounter).mintInternalProjectID = CInt(cboInternalProjectID.Text)
                    structSearchResults(mintResultCounter).mstrProjectName = txtProjectName.Text
                    structSearchResults(mintResultCounter).mstrTWCProjectID = txtTWCControlNumber.Text
                    structSearchResults(mintResultCounter).mstrMSRNumber = txtMSRNumber.Text
                    mintResultCounter += 1
                    blnRecordFound = True
                    blnItemNotFound = False

                End If
                If blnNotanInteger = False And blnItemNotFound = True Then
                    If CInt(strTWCProjectIDForSearch) = CInt(cboInternalProjectID.Text) Then

                        structSearchResults(mintResultCounter).mintSelectedIndex = intCounter
                        structSearchResults(mintResultCounter).mintInternalProjectID = CInt(cboInternalProjectID.Text)
                        structSearchResults(mintResultCounter).mstrProjectName = txtProjectName.Text
                        structSearchResults(mintResultCounter).mstrTWCProjectID = txtTWCControlNumber.Text
                        mintResultCounter += 1
                        blnRecordFound = True

                    End If
                End If

            Next

            If blnRecordFound = False Then
                InternalProjects.UpdateProjectDataTables()
                Me.Close()
            Else
                'Getting ready for the grid
                mintResultUpperLimit = mintResultCounter - 1
                dgvSearchResults.ColumnCount = 5
                dgvSearchResults.Columns(0).Name = "Selected Index"
                dgvSearchResults.Columns(0).Width = 100
                dgvSearchResults.Columns(1).Name = "Internal Project ID"
                dgvSearchResults.Columns(1).Width = 100
                dgvSearchResults.Columns(2).Name = "TWC Project ID"
                dgvSearchResults.Columns(2).Width = 100
                dgvSearchResults.Columns(3).Name = "Project Name"
                dgvSearchResults.Columns(3).Width = 100
                dgvSearchResults.Columns(4).Name = "MSR Number"
                dgvSearchResults.Columns(4).Width = 100

                'Loading up the grid
                For intCounter = 0 To mintResultUpperLimit

                    row = New String() {CStr(structSearchResults(intCounter).mintSelectedIndex), CStr(structSearchResults(intCounter).mintInternalProjectID), structSearchResults(intCounter).mstrTWCProjectID, structSearchResults(intCounter).mstrProjectName, structSearchResults(intCounter).mstrMSRNumber}
                    dgvSearchResults.Rows.Add(row)

                Next

            End If

        Catch ex As Exception

            'If an exception is thrown, it is rounted here
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

End Class