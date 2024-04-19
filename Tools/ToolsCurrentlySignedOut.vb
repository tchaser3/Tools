'Title:         Tools Currently Signed Out
'Date:          7-19-13
'Author:        Terry Holmes

'Description:   This form will show all the tools that are active and signed out.

Option Strict On

Public Class ToolsCurrentlySignedOut

    'Setting Modular Variables
    Private TheEmployeeDataSet As EmployeeDataSet
    Private TheEmployeeDataTier As EmployeeDataTier
    Private WithEvents TheEmployeeBindingSource As BindingSource

    Private TheToolsDataSet As toolsDataSet
    Private TheToolsDataTier As ToolsDataTier
    Private WithEvents TheToolsBindingSource As BindingSource

    Private addingBoolean As Boolean = False
    Private editingBoolean As Boolean = False
    Private previousSelectedIndex As Integer
    Dim mintNumuberOfRecords As Integer

    Dim LogDateTime As Date = DateAndTime.Now
    Dim strLogDateTime As String
    Dim mblnEmployeeIDFound As Boolean
    Dim mintSelectedIndex(10000) As Integer
    Dim mintCounter As Integer
    Dim mblnLastNameFound As Boolean
    Dim mintUpperLimit As Integer
    Dim mintSearchedUpperLimit As Integer


    'Variables for History
    Friend mintToolID As Integer
    Friend mintEmployeeID As Integer
    Friend mstrLogDateTime As String
    Friend mstrAvailability As String
    Friend mstrNotes As String

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        'Closes the Program
        CloseTheProgram.ShowDialog()

    End Sub

    Private Sub btnToolMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToolMenu.Click

        'Opens the Tool Menu
        ClearDataBindings()
        ToolsMenu.Show()
        Me.Close()

    End Sub

    Private Sub btnMainMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMainMenu.Click

        'This opens the Main menu
        ClearDataBindings()
        MainMenu.Show()
        Me.Close()

    End Sub
    Private Sub setComboBoxBinding()

        'Sets the Combobox Bindings
        With Me.cboEmployeeID
            If (addingBoolean Or editingBoolean) Then
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.OnValidation
                .DropDownStyle = ComboBoxStyle.Simple
            Else
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.Never
                .DropDownStyle = ComboBoxStyle.DropDownList
            End If
        End With

        With Me.cboToolID
            If (addingBoolean Or editingBoolean) Then
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.OnValidation
                .DropDownStyle = ComboBoxStyle.Simple
            Else
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.Never
                .DropDownStyle = ComboBoxStyle.DropDownList
            End If
        End With

    End Sub
    Private Sub setControlsReadOnly(ByVal valueBoolean As Boolean)

        'This will set controls either to read only or not
        With Me
            txtEmployeeActive.ReadOnly = valueBoolean
            txtFirstName.ReadOnly = valueBoolean
            txtLastName.ReadOnly = valueBoolean
            txtPhoneNumber.ReadOnly = valueBoolean
            txtActive.ReadOnly = valueBoolean
            txtEmployeeID.ReadOnly = valueBoolean
            txtDate.ReadOnly = valueBoolean
            txtPartNumber.ReadOnly = valueBoolean
            txtType.ReadOnly = valueBoolean
            txtDescription.ReadOnly = valueBoolean
            txtValue.ReadOnly = valueBoolean
            txtAvailable.ReadOnly = valueBoolean
            txtNotes.ReadOnly = valueBoolean
            txtToolID.ReadOnly = valueBoolean
        End With

    End Sub
    Private Sub setButtonsForEdit()



    End Sub
    Private Sub ResetButtonAfterEditing()



    End Sub

    Private Sub ToolsCurrentlySignedOut_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        'Try - Catch is used to protect the make sure that the program loads correctly
        'And if there is a problem, the exception is routed to a Message Box, instead of 
        'the whole program crashing

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
            txtEmployeeActive.DataBindings.Add("text", TheEmployeeBindingSource, "Active")
            txtPhoneNumber.DataBindings.Add("text", TheEmployeeBindingSource, "PhoneNumber")


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
            With cboToolID
                .DataSource = TheToolsBindingSource
                .DisplayMember = "ToolID"
                .DataBindings.Add("text", TheToolsBindingSource, "ToolID", False, DataSourceUpdateMode.Never)
            End With

            'Setting the binding for all other textbox controls
            txtEmployeeID.DataBindings.Add("text", TheToolsBindingSource, "EmployeeID")
            txtDate.DataBindings.Add("text", TheToolsBindingSource, "Date")
            txtPartNumber.DataBindings.Add("text", TheToolsBindingSource, "PartNumber")
            txtType.DataBindings.Add("text", TheToolsBindingSource, "Type")
            txtDescription.DataBindings.Add("text", TheToolsBindingSource, "Description")
            txtValue.DataBindings.Add("text", TheToolsBindingSource, "Value")
            txtAvailable.DataBindings.Add("text", TheToolsBindingSource, "Available")
            txtActive.DataBindings.Add("text", TheToolsBindingSource, "Active")
            txtNotes.DataBindings.Add("text", TheToolsBindingSource, "Notes")
            txtToolID.DataBindings.Add("text", TheToolsBindingSource, "ToolID")

            setControlsReadOnly(True)

            cboEmployeeID.Visible = False

            SetTheToolForm()

        Catch ex As Exception

            'If an exception is thrown, it is rounted here
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    Private Sub SetTheToolForm()

        Dim intCounter As Integer
        Dim strAvailable As String
        Dim strActive As String

        btnStandardBack.Enabled = False
        btnStandardNext.Enabled = False


        'This subroutine will run to set the initial Condition
        For intCounter = 0 To 9999
            mintSelectedIndex(intCounter) = -1
        Next

        mintUpperLimit = cboToolID.Items.Count - 1
        mintCounter = 0

        For intCounter = 0 To mintUpperLimit

            cboToolID.SelectedIndex = intCounter
            strActive = txtActive.Text
            strAvailable = txtAvailable.Text

            If (strActive = "YES" And strAvailable = "NO") Then

                mintSelectedIndex(mintCounter) = intCounter
                mintCounter = mintCounter + 1

            End If

        Next

        If mintCounter = 0 Then
            MessageBox.Show("There are Currently No Tools Signed Out", "The form will close", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        mintSearchedUpperLimit = mintCounter - 1

        If mintCounter > 0 Then
            btnStandardNext.Enabled = True
        End If

        mintCounter = 0
        cboToolID.SelectedIndex = mintSelectedIndex(mintCounter)
        mintEmployeeID = CInt(txtEmployeeID.Text)

        FindEmployeeID(mintEmployeeID)

    End Sub

    Private Sub FindEmployeeID(ByVal intEmployeeID As Integer)

        'Setting Local Variables
        Dim intEmployeeIDFromTable As Integer
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim intSelectedIndexFound As Integer

        'Setting the value of the variables
        mblnEmployeeIDFound = False
        intNumberOfRecords = cboEmployeeID.Items.Count

        'Performing Compare
        For intCounter = 0 To intNumberOfRecords - 1

            cboEmployeeID.SelectedIndex = intCounter
            intEmployeeIDFromTable = CInt(cboEmployeeID.Text)

            If intEmployeeIDFromTable = intEmployeeID Then
                mblnEmployeeIDFound = True
                intSelectedIndexFound = intCounter
            End If

        Next

        'Setting Combobox Selected Index
        If mblnEmployeeIDFound = True Then
            cboEmployeeID.SelectedIndex = intSelectedIndexFound
        End If

    End Sub

    Private Sub btnStandardNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStandardNext.Click

        'This Routine will run the Next Buttons
        mintCounter = mintCounter + 1
        cboToolID.SelectedIndex = mintSelectedIndex(mintCounter)

        btnStandardBack.Enabled = True


        If mintCounter = mintSearchedUpperLimit Then
            btnStandardNext.Enabled = False

        End If

        mintEmployeeID = CInt(txtEmployeeID.Text)

        FindEmployeeID(mintEmployeeID)

    End Sub

    Private Sub btnStandardBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStandardBack.Click

        'This will run the Back Button
        mintCounter = mintCounter - 1
        cboToolID.SelectedIndex = mintSelectedIndex(mintCounter)


        If mintCounter = 0 Then
            btnStandardBack.Enabled = False
        End If

        If mintCounter < mintUpperLimit Then
            btnStandardNext.Enabled = True
        End If

        mintEmployeeID = CInt(txtEmployeeID.Text)

        FindEmployeeID(mintEmployeeID)

    End Sub

    Private Sub FindToolsOutByType()

        Dim intCounter As Integer
        Dim strAvailable As String
        Dim strActive As String
        Dim strType As String
        Dim strTypeFromTable As String
        Dim blnToolTypeFound As Boolean = False

        If txtTypeOfTool.Text = "" Then
            MessageBox.Show("The Type was Not entered", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        btnStandardBack.Enabled = False
        btnStandardNext.Enabled = False


        'This subroutine will run to set the initial Condition
        For intCounter = 0 To 9999
            mintSelectedIndex(intCounter) = -1
        Next

        mintUpperLimit = cboToolID.Items.Count - 1
        mintCounter = 0

        strType = CStr(txtTypeOfTool.Text)

        For intCounter = 0 To mintUpperLimit

            cboToolID.SelectedIndex = intCounter
            strActive = txtActive.Text
            strAvailable = txtAvailable.Text

            If (strActive = "YES" And strAvailable = "NO") Then

                strTypeFromTable = CStr(txtType.Text)

                If strType = strTypeFromTable Then
                    blnToolTypeFound = True
                    mintSelectedIndex(mintCounter) = intCounter
                    mintCounter = mintCounter + 1

                End If

            End If

        Next

        If blnToolTypeFound = False Then
            MessageBox.Show("The Tool Type Entered Was Not Found", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        mintSearchedUpperLimit = mintCounter - 1

        If mintSearchedUpperLimit > 0 Then
            btnStandardNext.Enabled = True
        End If

        mintCounter = 0
        cboToolID.SelectedIndex = mintSelectedIndex(mintCounter)
        mintEmployeeID = CInt(txtEmployeeID.Text)

        FindEmployeeID(mintEmployeeID)

        txtTypeOfTool.Text = ""

    End Sub

    Private Sub btnFindTool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindTool.Click


      

        FindToolsOutByType()



    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        
        SetTheToolForm()

    End Sub

    Private Sub txtTypeOfTool_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTypeOfTool.KeyDown

        If e.KeyCode = Keys.Enter Then
            btnFindTool.PerformClick()
        End If

    End Sub
    Private Sub ClearDataBindings()

        cboEmployeeID.DataBindings.Clear()
        txtFirstName.DataBindings.Clear()
        txtLastName.DataBindings.Clear()
        txtPhoneNumber.DataBindings.Clear()

        cboToolID.DataBindings.Clear()
        txtEmployeeID.DataBindings.Clear()
        txtDate.DataBindings.Clear()
        txtPartNumber.DataBindings.Clear()
        txtType.DataBindings.Clear()
        txtDescription.DataBindings.Clear()
        txtValue.DataBindings.Clear()
        txtNotes.DataBindings.Clear()
        txtAvailable.DataBindings.Clear()
        txtActive.DataBindings.Clear()

    End Sub
End Class