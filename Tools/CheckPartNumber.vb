'Title:         Part Number Check
'Date:          4/2/14
'Author:        Terry Holmes

'Description:   This form checks to see if the part number entered already exists.

Option Strict On

Public Class CheckPartNumber

    'Setting Modular Variables
    Private ThePartNumberDataSet As PartNumberDataSet
    Private ThePartNumberDataTier As PartDataTier
    Private WithEvents ThePartNumberBindingSource As BindingSource

    Private addingBoolean As Boolean = False
    Private editingBoolean As Boolean = False
    Private previousSelectedIndex As Integer
    Dim mintNumuberOfRecords As Integer

    Private Sub CheckPartNumber_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'This routine runs when the form is loaded
        Dim strPartNumberFromTable As String
        Dim intCounter As Integer

        'This Try Catch will catch any exceptions that are through during the routine
        Try

            'This will bind the controls to the data source
            ThePartNumberDataTier = New PartDataTier
            ThePartNumberDataSet = ThePartNumberDataTier.GetPartNumberInformation
            ThePartNumberBindingSource = New BindingSource

            'Setting up the binding for the Combobox
            With ThePartNumberBindingSource
                .DataSource = ThePartNumberDataSet
                .DataMember = "partnumbers"
                .MoveFirst()
                .MoveLast()
            End With

            'Setting up the Table Relationships and binding for the table.
            With cboPartID
                .DataSource = ThePartNumberBindingSource
                .DisplayMember = "PartID"
                .DataBindings.Add("text", ThePartNumberBindingSource, "PartID", False, DataSourceUpdateMode.Never)
            End With

            'Setting up the data bindings for the textboxes
            txtPartNumber.DataBindings.Add("text", ThePartNumberBindingSource, "PartNumber")
            txtDescription.DataBindings.Add("text", ThePartNumberBindingSource, "Description")

            mintNumuberOfRecords = cboPartID.Items.Count - 1
            CreatePartNumbers.mbolPartNumberExists = False

            For intCounter = 0 To mintNumuberOfRecords
                cboPartID.SelectedIndex = intCounter
                strPartNumberFromTable = txtPartNumber.Text
                If CreatePartNumbers.mstrPartNumberForValidation = strPartNumberFromTable Then
                    CreatePartNumbers.mbolPartNumberExists = True
                End If

            Next

            Me.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
End Class