'Title:         Find and Remove Duplicate Projects
'Date:          11-9-15 
'Author:        Terry Holmes

'Description:   This form will find and allow the user to remove duplicate projects

Option Strict On

Public Class FindDuplicateProjects

    Private TheInternalProjectsDataSet As InternalProjectsDataSet
    Private TheInternalProjectsDataTier As InternalProjectsDataTier
    Private WithEvents TheInternalProjectsBindingSource As BindingSource

    Dim TheInputDataValidation As New InputDataValidation
    Dim TheKeyWordDataSearch As New KeyWordSearchClass

    Private addingBoolean As Boolean = False
    Private editingBoolean As Boolean = False
    Private previousSelectedIndex As Integer
    Dim mintNumuberOfRecords As Integer

    Dim LogDateTime As Date = DateAndTime.Now
    Dim strLogDateTime As String

    'setting up project structure
    Structure Projects
        Dim mintSelectedIndex As Integer
        Dim mintInternalProjectID As Integer
        Dim mstrProjectName As String
        Dim mstrTWCProjectID As String
        Dim mstrSupplyingWarehouse As String
        Dim mstrMSRNumber As String
    End Structure

    Dim structProjects() As Projects
    Dim mintProjectUpperLimit As Integer

    Dim structSearchResults() As Projects
    Dim mintResultCounter As Integer
    Dim mintResultUpperLimit As Integer

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click

        'this will open the Internal Projects Form
        LastTransaction.Show()
        InternalProjects.Show()
        Me.Close()

    End Sub

    Private Sub FindDuplicateProjects_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Setting local variables
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer

        Logon.mstrLastTransactionSummary = "Loaded The Find Duplicate Project Form"

        PleaseWait.Show()

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
            txtSupplyingWarehouse.DataBindings.Add("text", TheInternalProjectsBindingSource, "SupplyingWarehouse")
            txtMSRNumber.DataBindings.Add("text", TheInternalProjectsBindingSource, "MSRNumber")

            FindDuplicateProjects()
            PleaseWait.Close()

        Catch ex As Exception

            'If an exception is thrown, it is rounted here
            PleaseWait.Close()
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub FindDuplicateProjects()

        'setting local variables
        Dim intTableCounter As Integer
        Dim intTableNumberOfRecords As Integer
        Dim intStructureCounter As Integer
        Dim intInternalProjectIDFromTable As Integer
        Dim intinternalProjectIDForSearch As Integer
        Dim strTWCProjectIDForSearch As String
        Dim strTWCProjectIDFromTable As String
        Dim strMSRNumberFromTable As String
        Dim strMSRNumberForSearch As String
        Dim strProjectNameForSearch As String
        Dim strProjectNameFromTable As String
        Dim blnNoProjectsFound As Boolean = True
        Dim blnProjectNotFound As Boolean
        Dim blnAddSourceProject As Boolean
        Dim intResultCounter As Integer
        Dim intResultProjectIDForSearch As Integer
        Dim intResultProjectIDFromTable As Integer
        Dim rows() As String

        intTableNumberOfRecords = cboInternalProjectID.Items.Count - 1
        ReDim structProjects(intTableNumberOfRecords)
        mintProjectUpperLimit = intTableNumberOfRecords
        ReDim structSearchResults(intTableNumberOfRecords * 3)

        'Loading Structure
        For intTableCounter = 0 To intTableNumberOfRecords

            'incrementing the combo box
            cboInternalProjectID.SelectedIndex = intTableCounter

            structProjects(intTableCounter).mintSelectedIndex = intTableCounter
            structProjects(intTableCounter).mintInternalProjectID = CInt(cboInternalProjectID.Text)
            structProjects(intTableCounter).mstrMSRNumber = txtMSRNumber.Text
            structProjects(intTableCounter).mstrProjectName = txtProjectName.Text
            structProjects(intTableCounter).mstrTWCProjectID = txtTWCControlNumber.Text
            structProjects(intTableCounter).mstrSupplyingWarehouse = txtSupplyingWarehouse.Text

        Next

        'Setting up for the loop
        mintResultCounter = 0

        'beginning First Loop
        For intTableCounter = 0 To intTableNumberOfRecords

            'incrementing the combo box
            cboInternalProjectID.SelectedIndex = intTableCounter

            'loading the search variables
            intinternalProjectIDForSearch = CInt(cboInternalProjectID.Text)
            strTWCProjectIDForSearch = txtTWCControlNumber.Text
            strMSRNumberForSearch = txtMSRNumber.Text
            strProjectNameForSearch = txtProjectName.Text
            blnAddSourceProject = False

            'beginning loop within the project
            For intStructureCounter = 0 To mintProjectUpperLimit

                'loading variables
                intInternalProjectIDFromTable = structProjects(intStructureCounter).mintInternalProjectID
                strProjectNameFromTable = structProjects(intStructureCounter).mstrProjectName
                strTWCProjectIDFromTable = structProjects(intStructureCounter).mstrTWCProjectID
                strMSRNumberFromTable = structProjects(intStructureCounter).mstrMSRNumber
                blnProjectNotFound = True

                'Begining if statemens
                If intinternalProjectIDForSearch <> intInternalProjectIDFromTable Then
                    If strProjectNameForSearch = strProjectNameFromTable And strProjectNameFromTable <> "" Then
                        blnProjectNotFound = False
                        blnNoProjectsFound = False
                    ElseIf strMSRNumberForSearch = strMSRNumberFromTable And strMSRNumberFromTable <> "" Then
                        blnProjectNotFound = False
                        blnNoProjectsFound = False
                    ElseIf strTWCProjectIDForSearch = strTWCProjectIDFromTable And strTWCProjectIDFromTable <> "" Then
                        blnProjectNotFound = False
                        blnNoProjectsFound = False
                    End If

                    'Checking Result Structure
                    If blnProjectNotFound = False Then

                        'getting project id from structure
                        intResultProjectIDForSearch = intInternalProjectIDFromTable

                        'looping structure
                        For intResultCounter = 0 To mintResultCounter

                            intResultProjectIDFromTable = structSearchResults(intResultCounter).mintInternalProjectID

                            If intResultProjectIDForSearch = intResultProjectIDFromTable Then
                                blnProjectNotFound = True
                            End If
                        Next
                    End If

                    If blnProjectNotFound = False Then
                        structSearchResults(mintResultCounter).mintInternalProjectID = structProjects(intStructureCounter).mintInternalProjectID
                        structSearchResults(mintResultCounter).mintSelectedIndex = structProjects(intStructureCounter).mintSelectedIndex
                        structSearchResults(mintResultCounter).mstrMSRNumber = structProjects(intStructureCounter).mstrMSRNumber
                        structSearchResults(mintResultCounter).mstrProjectName = structProjects(intStructureCounter).mstrProjectName
                        structSearchResults(mintResultCounter).mstrSupplyingWarehouse = structProjects(intStructureCounter).mstrSupplyingWarehouse
                        structSearchResults(mintResultCounter).mstrTWCProjectID = structProjects(intStructureCounter).mstrTWCProjectID
                        mintResultCounter += 1
                        blnAddSourceProject = True
                    End If
                End If
            Next

            If blnAddSourceProject = True Then
                structSearchResults(mintResultCounter).mintInternalProjectID = CInt(cboInternalProjectID.Text)
                structSearchResults(mintResultCounter).mintSelectedIndex = intTableCounter
                structSearchResults(mintResultCounter).mstrMSRNumber = strMSRNumberForSearch
                structSearchResults(mintResultCounter).mstrProjectName = strProjectNameForSearch
                structSearchResults(mintResultCounter).mstrSupplyingWarehouse = txtSupplyingWarehouse.Text
                structSearchResults(mintResultCounter).mstrTWCProjectID = strTWCProjectIDForSearch
                mintResultCounter += 1
            End If
        Next

        dgvSearchResults.ColumnCount = 6
        dgvSearchResults.Columns(0).Name = "Internal Project ID"
        dgvSearchResults.Columns(0).Width = 75
        dgvSearchResults.Columns(1).Name = "TWC Project ID"
        dgvSearchResults.Columns(1).Width = 100
        dgvSearchResults.Columns(2).Name = "Project Name"
        dgvSearchResults.Columns(2).Width = 150
        dgvSearchResults.Columns(3).Name = "MSR Number"
        dgvSearchResults.Columns(3).Width = 100
        dgvSearchResults.Columns(4).Name = "Warehouse"
        dgvSearchResults.Columns(4).Width = 150
        dgvSearchResults.Columns(5).Name = "Remove"

        If blnNoProjectsFound = True Then
            btnRemoveProjects.Enabled = False
            MessageBox.Show("No Duplicate Projects Found", "Thank You", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf blnNoProjectsFound = False Then
            mintResultUpperLimit = mintResultCounter - 1
            mintResultCounter = 0
            For intStructureCounter = 0 To mintResultUpperLimit
                rows = New String() {CStr(structSearchResults(intStructureCounter).mintInternalProjectID), structSearchResults(intStructureCounter).mstrTWCProjectID, structSearchResults(intStructureCounter).mstrProjectName, structSearchResults(intStructureCounter).mstrMSRNumber, structSearchResults(intStructureCounter).mstrSupplyingWarehouse, "NO"}
                dgvSearchResults.Rows.Add(rows)
            Next
        End If
    End Sub

    Private Sub btnRemoveProjects_Click(sender As Object, e As EventArgs) Handles btnRemoveProjects.Click

        'setting local variables
        Dim intGridCounter As Integer
        Dim intGridNumberOfRecords As Integer
        Dim intTableCounter As Integer
        Dim intTableNumberOfRecords As Integer
        Dim intProjectIDForSearch As Integer
        Dim intProjectIDFromTable As Integer
        Dim strDeleteRecord As String
        Dim intTableSelectedIndex As Integer

        CommandConfirmation.ShowDialog()

        If Logon.mblnAreYouSure = True Then

            PleaseWait.Show()

            'getting ready for the loop
            intGridNumberOfRecords = dgvSearchResults.Rows.Count - 2
            intTableNumberOfRecords = cboInternalProjectID.Items.Count - 1

            For intGridCounter = 0 To intGridNumberOfRecords

                'Determining to delete record
                strDeleteRecord = dgvSearchResults.Rows(intGridCounter).Cells(5).Value.ToString.ToUpper

                If strDeleteRecord = "YES" Then

                    'getting project id
                    intProjectIDForSearch = CInt(dgvSearchResults.Rows(intGridCounter).Cells(0).Value.ToString)

                    Try

                        'beginning loop
                        For intTableCounter = 0 To intTableNumberOfRecords

                            'getting the id
                            cboInternalProjectID.SelectedIndex = intTableCounter
                            intProjectIDFromTable = CInt(cboInternalProjectID.Text)

                            If intProjectIDForSearch = intProjectIDFromTable Then
                                intTableSelectedIndex = intTableCounter
                            End If

                        Next

                        cboInternalProjectID.SelectedIndex = intTableSelectedIndex

                        'setting up to save record
                        Logon.mintCreatedTransactionID = CInt(cboInternalProjectID.Text)
                        Logon.mstrMSR = txtMSRNumber.Text
                        Logon.mstrTWCProjectID = txtTWCControlNumber.Text
                        Logon.mstrProjectName = txtProjectName.Text
                        Logon.mstrWarehouse = txtSupplyingWarehouse.Text

                        RemovedProjects.Show()

                        TheInternalProjectsBindingSource.RemoveCurrent()
                        TheInternalProjectsDataTier.UpdateInternalProjectsDB(TheInternalProjectsDataSet)
                        intTableNumberOfRecords -= 1

                    Catch ex As Exception
                        PleaseWait.Close()
                        MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try

                End If
            Next

            dgvSearchResults.Rows.Clear()

            FindDuplicateProjects()

            PleaseWait.Close()

            MessageBox.Show("The Selected Records Have Been Removed", "Thank You", MessageBoxButtons.OK, MessageBoxIcon.Error)

        ElseIf Logon.mblnAreYouSure = False Then

            MessageBox.Show("No Projects Were Removed", "Thank You", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If
    End Sub
End Class