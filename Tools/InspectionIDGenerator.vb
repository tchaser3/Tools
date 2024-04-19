'Title:     Inspection ID Generator
'Date:      7/25/13
'Author:    Terry Holmes

Option Strict On

Public Class InspectionIDGenerator

    'Creating Modular Variables
    Private TheInspectionIDGeneratorDataSet As InspectionIDGeneratorDataSet
    Private TheInspectionIDGeneratorDataTier As InspectionIDGeneratorDataTier
    Private WithEvents TheInspectionIDGeneratorBindingSource As BindingSource

    Private addingBoolean As Boolean = False
    Private editingBoolean As Boolean = False
    Private previousSelectedIndex As Integer
    Dim mintNumuberOfRecords As Integer

    Dim LogDateTime As Date = DateAndTime.Now
    Dim strLogDateTime As String

    'Creating a Global Variable
    Friend mintCreatedInspectionID As Integer

    Private Sub InspectionIDGenerator_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Setting Local Variables
        Dim intNumberOfRecords As Integer
        Dim intComboBoxCount As Integer
        Dim intInspectionIDFromTable As Integer

        'Using a Try Catch to catch illegal exceptions
        Try

            'This will bind the controls to the data source
            TheInspectionIDGeneratorDataTier = New InspectionIDGeneratorDataTier
            TheInspectionIDGeneratorDataSet = TheInspectionIDGeneratorDataTier.GetInspectionIDGeneratorInformation
            TheInspectionIDGeneratorBindingSource = New BindingSource

            'Setting Combobox binding to the dataset
            With TheInspectionIDGeneratorBindingSource
                .DataSource = TheInspectionIDGeneratorDataSet
                .DataMember = "InspectionIDGenerator"
                .MoveFirst()
                .MoveLast()
            End With

            'Setting the combobox to the table
            With cboTransactionID
                .DataSource = TheInspectionIDGeneratorBindingSource
                .DisplayMember = "TransactionID"
                .DataBindings.Add("text", TheInspectionIDGeneratorBindingSource, "TransactionID", False, DataSourceUpdateMode.Never)
            End With

            'Binding the textbox
            txtInspectionID.DataBindings.Add("text", TheInspectionIDGeneratorBindingSource, "InspectionID")

            'Getting the ID read from the table
            intInspectionIDFromTable = CInt(txtInspectionID.Text)

            'Setting the binding source to add a record
            With TheInspectionIDGeneratorBindingSource
                .EndEdit()
                .AddNew()
            End With

            'Calling routines and setting values
            addingBoolean = True
            setComboBoxBinding()
            If cboTransactionID.SelectedIndex <> -1 Then
                previousSelectedIndex = cboTransactionID.Items.Count - 1
            Else
                previousSelectedIndex = 0
            End If

            'Getting a count of the total number of items in the table
            intComboBoxCount = cboTransactionID.Items.Count + 1000

            If intInspectionIDFromTable < intComboBoxCount Then
                intInspectionIDFromTable = intComboBoxCount
            End If

            'Getting the ID that is on the CreateEmployee Form
            intNumberOfRecords = Logon.mintCreatedInspectionID

            'Doing comparison to what was created on the form and what is in the ID Table
            If intInspectionIDFromTable = intNumberOfRecords Then
                intNumberOfRecords = intNumberOfRecords + 1
                Logon.mintCreatedInspectionID = intNumberOfRecords
            ElseIf intNumberOfRecords < intInspectionIDFromTable Then
                intNumberOfRecords = intInspectionIDFromTable + 1
                Logon.mintCreatedInspectionID = intNumberOfRecords
            Else
                CreateEmployee.mintCreatedCustomerID = intNumberOfRecords
            End If

            'Place the ID in the txtEmployee ID
            txtInspectionID.Text = CStr(intNumberOfRecords)
            cboTransactionID.Text = CStr(intComboBoxCount)

            'Updating the Dataset
            TheInspectionIDGeneratorBindingSource.EndEdit()
            TheInspectionIDGeneratorDataTier.UpdateDB(TheInspectionIDGeneratorDataSet)

            'Closing the form
            Me.Close()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub setComboBoxBinding()

        'Setting the changing for the Combobos
        With Me.cboTransactionID
            If (addingBoolean Or editingBoolean) Then
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.OnValidation
                .DropDownStyle = ComboBoxStyle.Simple
            Else
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.Never
                .DropDownStyle = ComboBoxStyle.DropDownList
            End If
        End With

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        Me.Close()

    End Sub
End Class