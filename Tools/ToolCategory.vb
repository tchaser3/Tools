'Title:         Tool Category
'Date:          4/18/14
'Author:        Terry Holmes

'Description:   This is used to create new tool categories for validation

Option Strict On

Public Class ToolCategory

    Dim TheInputDataValidation As New InputDataValidation

    Private addingBoolean As Boolean = False
    Private editingBoolean As Boolean = False
    Private previousSelectedIndex As Integer
    Dim mintNumuberOfRecords As Integer

    Dim LogDateTime As Date = DateAndTime.Now
    Dim strLogDateTime As String

    'Setting global variable
    Structure ToolCategory
        Dim mintCategoryID As Integer
        Dim mstrToolCategory As String
    End Structure

    Dim structToolCategory() As ToolCategory
    Dim mintToolCounter As Integer
    Dim mintToolUpperLimit As Integer
    Dim mintToolSelectedIndex As Integer

    'Setting up Employee Information
    Private TheToolCategoryDataSet As ToolCategoryDataSet
    Private TheToolCategoryDataTier As ToolsDataTier
    Private WithEvents TheToolCategoryBindingSource As BindingSource

    Friend mblnToolCategoryExists As Boolean = False
    Friend mstrValueForValidation As String

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        'Closes the Program
        CloseTheProgram.ShowDialog()

    End Sub

    Private Sub btnMainMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMainMenu.Click

        'Shows Main Menu
        MainMenu.Show()
        Me.Close()

    End Sub

    Private Sub btnAdministrativeMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdministrativeMenu.Click

        'Shows the Admininstrative Menu
        AdministrativeMenu.Show()
        Me.Close()

    End Sub

    Private Sub setComboBoxBinding()

        With Me.cboCategoryID
            If (addingBoolean Or editingBoolean) Then
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.OnValidation
                .DropDownStyle = ComboBoxStyle.Simple
            Else
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.Never
                .DropDownStyle = ComboBoxStyle.DropDownList
            End If
        End With
    End Sub

    Private Sub ToolCategory_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'This is used to load up the form
        Try

            'This will bind the controls
            TheToolCategoryDataTier = New ToolsDataTier
            TheToolCategoryDataSet = TheToolCategoryDataTier.GetToolCategoryInformation
            TheToolCategoryBindingSource = New BindingSource

            'Setting up the binding source
            With TheToolCategoryBindingSource
                .DataSource = TheToolCategoryDataSet
                .DataMember = "toolcategory"
                .MoveFirst()
                .MoveLast()
            End With

            'Binding the controls
            With cboCategoryID
                .DataSource = TheToolCategoryBindingSource
                .DisplayMember = "CategoryID"
                .DataBindings.Add("text", TheToolCategoryBindingSource, "CategoryID", False, DataSourceUpdateMode.Never)
            End With

            txtToolCategory.DataBindings.Add("text", TheToolCategoryBindingSource, "ToolCategory")

            LoadToolCategory()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub setButtonsForEdit()
        btnAdd.Text = "Save"
        btnEdit.Enabled = False
    End Sub
    Private Sub ResetButtonsAfterEditing()
        btnAdd.Text = "Add"
        btnEdit.Enabled = True
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        setButtonsForEdit()
        previousSelectedIndex = cboCategoryID.SelectedIndex
        setComboBoxBinding()
    End Sub

    Private Sub txtCategoryForSearching_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCategoryForSearching.KeyDown

        'This will run when the enter key is pressed
        If e.KeyCode = Keys.Enter Then
            btnCategorySearch.PerformClick()
        End If

    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        Dim blnFatalError As Boolean
        Dim blnItemNotFound As Boolean

        'This is used to add records to the system
        If btnAdd.Text = "Add" Then

            With TheToolCategoryBindingSource
                .EndEdit()
                .AddNew()
            End With

            'Calling Transaction
            CreateProjectID.Show()

            'Setting up the form for creating record
            addingBoolean = True
            setComboBoxBinding()
            cboCategoryID.Focus()
            setButtonsForEdit()
            If cboCategoryID.SelectedIndex <> -1 Then
                previousSelectedIndex = cboCategoryID.Items.Count - 1
            Else
                previousSelectedIndex = 0
            End If

            cboCategoryID.Text = CStr(Logon.mintCreatedTransactionID)

        Else

            'Performing Data Validation
            mstrValueForValidation = txtToolCategory.Text
            blnFatalError = TheInputDataValidation.VerifyTextData(mstrValueForValidation)

            If blnFatalError = True Then
                txtToolCategory.Text = ""
                MessageBox.Show("Tool Category Not Entered", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            'checking to see if the category exists
            blnItemNotFound = SearchForCategory(txtToolCategory.Text)

            If blnItemNotFound = False Then
                txtToolCategory.Text = ""
                MessageBox.Show("The Tool Category Currently Exists", "Please Try Again", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            'Updating the Data Base
            Try
                TheToolCategoryBindingSource.EndEdit()
                TheToolCategoryDataTier.UpdateToolCategoryDB(TheToolCategoryDataSet)
                addingBoolean = False
                editingBoolean = False
                ResetButtonsAfterEditing()
                setComboBoxBinding()
                cboCategoryID.SelectedIndex = previousSelectedIndex
                LoadToolCategory()

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If

    End Sub
    Private Sub LoadToolCategory()

        'setting local variables
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer

        'Setting up for loop
        intNumberOfRecords = cboCategoryID.Items.Count - 1
        ReDim structToolCategory(intNumberOfRecords)
        mintToolUpperLimit = intNumberOfRecords

        'Performing loop
        For intCounter = 0 To intNumberOfRecords

            'Incrementing the combo box
            cboCategoryID.SelectedIndex = intCounter

            'Loading the structure
            structToolCategory(intCounter).mintCategoryID = CInt(cboCategoryID.Text)
            structToolCategory(intCounter).mstrToolCategory = txtToolCategory.Text

        Next

    End Sub
    Private Function SearchForCategory(ByVal strCategoryForSearch As String) As Boolean

        Dim intCounter As Integer
        Dim strCategoryFromTable As String
        Dim blnItemNotFound As Boolean = True

        'Running Loop
        For intCounter = 0 To mintToolUpperLimit

            'getting tool category
            strCategoryFromTable = structToolCategory(intCounter).mstrToolCategory

            If strCategoryForSearch = strCategoryFromTable Then
                blnItemNotFound = False
                mintToolSelectedIndex = intCounter
            End If

        Next

        Return blnItemNotFound

    End Function

    Private Sub btnCategorySearch_Click(sender As Object, e As EventArgs) Handles btnCategorySearch.Click

        'Setting for searching category
        'setting local variables
        Dim blnFatalError As Boolean
        Dim blnItemNotFound As Boolean
        Dim strCategoryForSearch As String

        'performing data validation
        strCategoryForSearch = txtCategoryForSearching.Text
        blnFatalError = TheInputDataValidation.VerifyTextData(strCategoryForSearch)
        If blnFatalError = True Then
            MessageBox.Show("The Category Was Not Entered", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        'Calling function
        blnItemNotFound = SearchForCategory(strCategoryForSearch)

        'Checking to see if the category was found
        If blnItemNotFound = True Then
            MessageBox.Show("Category Entered Was Not Found", "Try Again", MessageBoxButtons.OK)
            txtCategoryForSearching.Text = ""
        ElseIf blnItemNotFound = False Then
            cboCategoryID.SelectedIndex = mintToolSelectedIndex
            txtCategoryForSearching.Text = ""
        End If

    End Sub
End Class