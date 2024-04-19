'Title:         Tool Asset Report
'Date:          12-17-14
'Author:        Terry Holmes

'Description:   This will list all active tools

'Update:        8-21-15 - Adding Gridview and a Search results structure

Option Strict On

Public Class ToolAssetReport

    'Setting Modular Variable
    Private TheToolsDataSet As toolsDataSet
    Private TheToolsDataTier As ToolsDataTier
    Private WithEvents TheToolsBindingSource As BindingSource

    Dim mintStartCount As Integer = 0
    Dim datLogDate As Date = Date.Now
    Dim mstrLogDate As String

    Structure ToolInformation
        Dim mstrToolID As String
        Dim mstrDescription As String
        Dim mstrNotes As String
        Dim mstrActive As String
        Dim mstrAsset As String
    End Structure

    Dim structToolInformation() As ToolInformation

    Dim mintToolCounter As Integer
    Dim mintToolUpperLimit As Integer

    Structure SearchResults
        Dim mstrToolID As String
        Dim mstrDescription As String
        Dim mstrNotes As String
        Dim mstrActive As String
        Dim mstrAsset As String
    End Structure

    Dim structSearchResults() As SearchResults
    Dim mintResultCounter As Integer
    Dim mintResultUpperLimit As Integer

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        'This will call the Close the Program form
        CloseTheProgram.ShowDialog()

    End Sub

    Private Sub ToolAssetReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Setting local variables
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer

        PleaseWait.Show()
        Logon.mstrLastTransactionSummary = "Loaded the Tool Asset Report Module"

        'This sub-routine runs when the form is loaded
        Try
            'This will bind the controls to the data source
            TheToolsDataTier = New ToolsDataTier
            TheToolsDataSet = TheToolsDataTier.GetToolInformation
            TheToolsBindingSource = New BindingSource

            'Setting the binding for the combo box
            With TheToolsBindingSource
                .DataSource = TheToolsDataSet
                .DataMember = "tools"
                .MoveFirst()
                .MoveLast()
            End With

            'Binding controls to for the binding for the combo box
            With cboTransactionID
                .DataSource = TheToolsBindingSource
                .DisplayMember = "ToolKey"
                .DataBindings.Add("text", TheToolsBindingSource, "ToolKey", False, DataSourceUpdateMode.Never)
            End With

            'Setting the binding for all other textbox controls
            txtToolID.DataBindings.Add("text", TheToolsBindingSource, "ToolID")
            txtEmployeeID.DataBindings.Add("text", TheToolsBindingSource, "EmployeeID")
            txtDescription.DataBindings.Add("text", TheToolsBindingSource, "Description")
            txtActive.DataBindings.Add("text", TheToolsBindingSource, "Active")
            txtNotes.DataBindings.Add("text", TheToolsBindingSource, "Notes")
            txtType.DataBindings.Add("text", TheToolsBindingSource, "Type")
            txtAsset.DataBindings.Add("text", TheToolsBindingSource, "Asset")

            'Loading Tool Structure
            intNumberOfRecords = cboTransactionID.Items.Count - 1
            ReDim structToolInformation(intNumberOfRecords)
            ReDim structSearchResults(intNumberOfRecords)
            mintToolCounter = 0
            mintToolUpperLimit = intNumberOfRecords

            For intCounter = 0 To intNumberOfRecords

                'incrementing the combo box
                cboTransactionID.SelectedIndex = intCounter

                'Loading up the array
                structToolInformation(intCounter).mstrActive = txtActive.Text
                structToolInformation(intCounter).mstrAsset = txtAsset.Text
                structToolInformation(intCounter).mstrDescription = txtDescription.Text
                structToolInformation(intCounter).mstrNotes = txtNotes.Text
                structToolInformation(intCounter).mstrToolID = txtToolID.Text

            Next

            'loading the search results structure
            BubbleSortSelectedIndex()

            SetControlsVisible(False)

            PleaseWait.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnToolMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToolMenu.Click

        'This will open the tool menu
        LastTransaction.Show()
        ToolsMenu.Show()
        Me.Close()

    End Sub

    Private Sub btnMainMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMainMenu.Click

        'This will open the main menu
        LastTransaction.Show()
        MainMenu.Show()
        Me.Close()

    End Sub
    Private Sub SetControlsVisible(ByVal valueBoolean As Boolean)

        'This will make the controls visible
        cboTransactionID.Visible = valueBoolean
        txtActive.Visible = valueBoolean
        txtDescription.Visible = valueBoolean
        txtEmployeeID.Visible = valueBoolean
        txtToolID.Visible = valueBoolean
        txtNotes.Visible = valueBoolean
        txtType.Visible = valueBoolean
        txtAsset.Visible = valueBoolean

    End Sub

    Private Sub PrintDocument1_QueryPageSettings(ByVal sender As Object, ByVal e As System.Drawing.Printing.QueryPageSettingsEventArgs) Handles PrintDocument1.QueryPageSettings

        'Setting the page to landscape
        e.PageSettings.Landscape = True

    End Sub
    Private Sub BubbleSortSelectedIndex()

        'This will load up the search results structure
        Dim intCounter As Integer
        Dim blnNoItemsFound As Boolean = True

        'Setting up for the loop
        mintResultCounter = 0
        mintResultUpperLimit = 0

        'beginning loop
        For intCounter = 0 To mintToolUpperLimit

            'If statements to load up structure
            If structToolInformation(intCounter).mstrActive = "YES" Then
                If structToolInformation(intCounter).mstrAsset = "YES" Then

                    'Loading up the structure
                    structSearchResults(mintResultCounter).mstrActive = structToolInformation(intCounter).mstrActive
                    structSearchResults(mintResultCounter).mstrAsset = structToolInformation(intCounter).mstrAsset
                    structSearchResults(mintResultCounter).mstrDescription = structToolInformation(intCounter).mstrDescription
                    structSearchResults(mintResultCounter).mstrNotes = structToolInformation(intCounter).mstrNotes
                    structSearchResults(mintResultCounter).mstrToolID = structToolInformation(intCounter).mstrToolID
                    mintResultCounter += 1
                    blnNoItemsFound = False

                End If
            End If

        Next

        'Message to user if there is a problem
        If blnNoItemsFound = True Then
            MessageBox.Show("There are no Items that are Marked as Assets", "There is a Problem", MessageBoxButtons.OK, MessageBoxIcon.Error)
            btnRunReport.Enabled = False
            dgvSearchResults.Visible = False
            SetControlsVisible(False)
        ElseIf blnNoItemsFound = False Then
            mintResultUpperLimit = mintResultCounter - 1
            mintResultCounter = 0
            CreateAndLoadGridView()
        End If
        

    End Sub
    Private Sub CreateAndLoadGridView()

        'Setting local variables
        Dim intCounter As Integer
        Dim row() As String

        'Creating Grid Columns
        dgvSearchResults.ColumnCount = 3
        dgvSearchResults.Columns(0).Width = 100
        dgvSearchResults.Columns(0).Name = "Tool ID"
        dgvSearchResults.Columns(1).Width = 150
        dgvSearchResults.Columns(1).Name = "Description"
        dgvSearchResults.Columns(2).Width = 150
        dgvSearchResults.Columns(2).Name = "Notes"

        For intCounter = 0 To mintResultUpperLimit

            row = New String() {structSearchResults(intCounter).mstrToolID, structSearchResults(intCounter).mstrDescription, structSearchResults(intCounter).mstrNotes}
            dgvSearchResults.Rows.Add(row)

        Next



    End Sub

    Private Sub btnRunReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRunReport.Click

        BubbleSortSelectedIndex()

        'This will call for the print dialog box
        PrintDialog1.PrinterSettings = PrintDocument1.PrinterSettings

        'If statemtn for the dialog box
        If PrintDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            PrintDocument1.PrinterSettings = PrintDialog1.PrinterSettings
        End If

        'Setting initial count
        mintStartCount = 0

        'Calling Print Routine
        PrintDocument1.Print()

    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage

        'This sub routine will print the page

        'Setting up local variables
        Dim intToolCounter As Integer
        Dim intToolNumberOfRecords As Integer
        Dim intToolStartCount As Integer
        Dim blnNewPage As Boolean = False
        Dim strNotes As String = ""
        Dim strDescription As String = ""
        Dim chaDescriptionArray() As Char
        Dim chaNotesArray() As Char
        Dim intDescriptionLimit As Integer
        Dim intNotesLimit As Integer
        Dim intDescriptionCounter As Integer
        Dim intNotesCounter As Integer

        Dim fntPrtHeader As New Font("Arial", 18, FontStyle.Bold)
        Dim fntPrtSubHeader As New Font("Arial", 14, FontStyle.Bold)
        Dim fntPrtItems As New Font("Arial", 10, FontStyle.Regular)
        Dim fntPrtNotes As New Font("Arial", 8, FontStyle.Regular)
        Dim sngPrintX As Single = e.MarginBounds.Left
        Dim sngPrintY As Single = e.MarginBounds.Top
        Dim sngHeadingLineHeight As Single = fntPrtHeader.GetHeight + 10
        Dim sngItemLineHeight As Single = fntPrtItems.GetHeight + 5

        'Getting the starting location
        intToolStartCount = mintStartCount
        mstrLogDate = CStr(datLogDate)

        'Setting up for the header of the document
        sngPrintY = 100
        sngPrintX = 250
        e.Graphics.DrawString("Blue Jay Communications Tool Asset Report", fntPrtHeader, Brushes.Black, sngPrintX, sngPrintY)
        sngPrintY = sngPrintY + sngHeadingLineHeight
        sngPrintX = 350
        e.Graphics.DrawString("For Today, " + mstrLogDate, fntPrtSubHeader, Brushes.Black, sngPrintX, sngPrintY)
        sngPrintY = sngPrintY + sngHeadingLineHeight
        sngPrintY = sngPrintY + sngHeadingLineHeight

        'Setting for loops
        SetControlsVisible(True)
        intToolNumberOfRecords = mintResultUpperLimit

        'Setting up columns
        sngPrintX = 100
        e.Graphics.DrawString("Tool ID", fntPrtItems, Brushes.Black, sngPrintX, sngPrintY)
        sngPrintX = 350
        e.Graphics.DrawString("Description", fntPrtItems, Brushes.Black, sngPrintX, sngPrintY)
        sngPrintX = 750
        e.Graphics.DrawString("Notes", fntPrtItems, Brushes.Black, sngPrintX, sngPrintY)
        sngPrintY = sngPrintY + sngItemLineHeight

        'Beginning Loops
        For intToolCounter = intToolStartCount To intToolNumberOfRecords

            'Setting up to limit the size of the strings
            chaDescriptionArray = structSearchResults(intToolCounter).mstrDescription.ToCharArray
            chaNotesArray = structSearchResults(intToolCounter).mstrNotes.ToCharArray
            intDescriptionLimit = structSearchResults(intToolCounter).mstrDescription.Length - 1
            intNotesLimit = structSearchResults(intToolCounter).mstrNotes.Length - 1

            If intDescriptionLimit > 40 Then
                intDescriptionLimit = 40
            ElseIf intDescriptionLimit < 0 Then
                intDescriptionLimit = 0
            End If

            If intNotesLimit > 30 Then
                intNotesLimit = 30
            ElseIf intNotesLimit < 0 Then
                intNotesLimit = 0
            End If

            For intDescriptionCounter = 0 To intDescriptionLimit
                strDescription = strDescription + CStr(chaDescriptionArray(intDescriptionCounter))
            Next

            If intNotesLimit <> 0 Then
                For intNotesCounter = 0 To intNotesLimit
                    strNotes = strNotes + CStr(chaNotesArray(intNotesCounter))
                Next
            End If

            sngPrintX = 100
            e.Graphics.DrawString(structSearchResults(intToolCounter).mstrToolID, fntPrtItems, Brushes.Black, sngPrintX, sngPrintY)
            sngPrintX = 350
            e.Graphics.DrawString(strDescription, fntPrtItems, Brushes.Black, sngPrintX, sngPrintY)
            sngPrintX = 750
            e.Graphics.DrawString(strNotes, fntPrtItems, Brushes.Black, sngPrintX, sngPrintY)
            sngPrintY = sngPrintY + sngItemLineHeight

            If sngPrintY > 750 Then
                If intToolCounter = intToolNumberOfRecords Then
                    e.HasMorePages = False
                Else
                    e.HasMorePages = True
                    blnNewPage = True
                End If
            End If

            'setting up for multiple pages
            If blnNewPage = True Then
                mintStartCount = intToolCounter + 1
                intToolCounter = intToolNumberOfRecords
            End If

            strDescription = ""
            strNotes = ""

        Next


    End Sub

    Private Sub btnCreateTool_Click(sender As Object, e As EventArgs) Handles btnCreateTool.Click

        'This will load the create a tool
        LastTransaction.Show()
        CreateTools.Show()
        Me.Close()

    End Sub
End Class