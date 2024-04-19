'Title:         Trailers In Use
'Date:          3/24/14
'Author:        Terry Holmes

'Description:   This is used to see what trailers are in use

Option Strict On

Public Class TrailersInUse

    'Setting Modular Variables
    Private TheEmployeeDataSet As EmployeeDataSet
    Private TheEmployeeDataTier As EmployeeDataTier
    Private WithEvents TheEmployeeBindingSource As BindingSource

    Private TheTrailersDataSet As TrailersDataSet
    Private TheTrailersDataTier As TrailersDataTier
    Private WithEvents TheTrailersBindingSource As BindingSource

    Private addingBoolean As Boolean = False
    Private editingBoolean As Boolean = False
    Private previousSelectedIndex As Integer
    Dim mintNumuberOfRecords As Integer

    Dim TheInputDataValidation As New InputDataValidation

    Dim LogDateTime As Date = DateAndTime.Now
    Dim strLogDateTime As String
    Dim mintSelectedIndex(10000) As Integer
    Dim mintCounter As Integer
    Dim mintUpperLimit As Integer

    'Variables for History
    Dim mintTrailerID As Integer
    Dim mintEmployeeID As Integer
    Dim mstrLogDateTime As String
    Dim mstrNotes As String
    Dim mintBJCNumber As Integer

    Private Sub btnMainMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMainMenu.Click

        'Displays the Main Menu
        MainMenu.Show()
        Me.Close()

    End Sub

    Private Sub btnTrailerMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTrailerMenu.Click

        'Displays the Trailer Menu
        TrailerMenu.Show()
        Me.Close()

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        'Closes the Program
        CloseTheProgram.ShowDialog()

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

        With Me.cboTrailerID
            If (addingBoolean Or editingBoolean) Then
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.OnValidation
                .DropDownStyle = ComboBoxStyle.Simple
            Else
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.Never
                .DropDownStyle = ComboBoxStyle.DropDownList
            End If
        End With

    End Sub

   
    Private Sub TrailersInUse_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Setting Local Variables
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim strAvailableFromTable As String
        Dim blnNoTrailersSignedOut As Boolean = True

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
            txtPhoneNumber.DataBindings.Add("text", TheEmployeeBindingSource, "PhoneNumber")


            'This will bind the controls to the data source
            TheTrailersDataTier = New TrailersDataTier
            TheTrailersDataSet = TheTrailersDataTier.GetTrailersInformation
            TheTrailersBindingSource = New BindingSource

            'Setting the binding for the combo box
            With TheTrailersBindingSource
                .DataSource = TheTrailersDataSet
                .DataMember = "trailers"
                .MoveFirst()
                .MoveLast()
            End With

            'Binding controls to for the binding for the combo box
            With cboTrailerID
                .DataSource = TheTrailersBindingSource
                .DisplayMember = "TrailerID"
                .DataBindings.Add("text", TheTrailersBindingSource, "VehicleID", False, DataSourceUpdateMode.Never)
            End With

            'Setting the binding for all other textbox controls

            txtBJCNumber.DataBindings.Add("text", TheTrailersBindingSource, "BJCNumber")
            txtLicencePlate.DataBindings.Add("text", TheTrailersBindingSource, "LicensePlate")
            txtEmployeeID.DataBindings.Add("text", TheTrailersBindingSource, "EmployeeID")
            txtDate.DataBindings.Add("text", TheTrailersBindingSource, "Date")
            txtAvailable.DataBindings.Add("text", TheTrailersBindingSource, "Available")
            txtActive.DataBindings.Add("text", TheTrailersBindingSource, "Active")
            txtNotes.DataBindings.Add("text", TheTrailersBindingSource, "Notes")

            'Procedure to find all trailers in use
            intNumberOfRecords = cboTrailerID.Items.Count - 1
            mintCounter = 0
            mintUpperLimit = 0

            'Loop to find all the trailers in use
            For intCounter = 0 To intNumberOfRecords

                cboTrailerID.SelectedIndex = intCounter
                strAvailableFromTable = txtAvailable.Text
                If strAvailableFromTable = "NO" Then
                    mintSelectedIndex(mintCounter) = intCounter
                    mintCounter = mintCounter + 1
                    blnNoTrailersSignedOut = False
                End If

            Next

            If blnNoTrailersSignedOut = True Then
                MessageBox.Show("All Trailers are Available", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Error)
                setTrailerTextBoxesVisible(False)
                SetEmployeeTextBoxesVisible(False)
            End If

        Catch ex As Exception

            'If an exception is thrown, it is rounted here
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub setTrailerTextBoxesVisible(ByVal valueBoolean As Boolean)

        'Makes the controls either visible or not
        txtActive.Visible = valueBoolean
        txtAvailable.Visible = valueBoolean
        txtBJCNumber.Visible = valueBoolean
        txtDate.Visible = valueBoolean
        txtEmployeeID.Visible = valueBoolean
        txtLicencePlate.Visible = valueBoolean
        txtNotes.Visible = valueBoolean

    End Sub
    Private Sub SetEmployeeTextBoxesVisible(ByVal valueBoolean As Boolean)

        'Makes Control Visible or not
        txtPhoneNumber.Visible = valueBoolean
        txtFirstName.Visible = valueBoolean
        txtLastName.Visible = valueBoolean

    End Sub
    Private Sub FindEmployees()

        'This Sub Procedure will find the employees

    End Sub
End Class