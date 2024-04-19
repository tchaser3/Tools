'Title:     Create Customer ID and ID Check
'Date:      April 15, 2013
'Author:    Terry Holmes

Option Strict On

Public Class CreateEmployeeID

    'Creating Modular Variables
    Private TheEmployeeIDCheckDataSet As EmployeeIDCheckDataSet
    Private TheEmployeeIDCheckDataTier As EmployeeIDCheckDataTier
    Private WithEvents TheEmployeeIDCheckBindingSource As BindingSource

    Private addingBoolean As Boolean = False
    Private editingBoolean As Boolean = False
    Private previousSelectedIndex As Integer
    Dim mintNumuberOfRecords As Integer

    Dim LogDateTime As Date = DateAndTime.Now
    Dim strLogDateTime As String

    'Creating a Global Variable
    Friend mintCreatedEmployeeID As Integer

    Private Sub CreateEmployeeID_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        'Setting Local Variables
        Dim intNumberOfRecords As Integer
        Dim intComboBoxCount As Integer
        Dim intEmployeeIDFromTable As Integer

        'Using a Try Catch to catch illegal exceptions
        Try

            'This will bind the controls to the data source
            TheEmployeeIDCheckDataTier = New EmployeeIDCheckDataTier
            TheEmployeeIDCheckDataSet = TheEmployeeIDCheckDataTier.GetEmployeeIDInformation
            TheEmployeeIDCheckBindingSource = New BindingSource

            'Setting Combobox binding to the dataset
            With TheEmployeeIDCheckBindingSource
                .DataSource = TheEmployeeIDCheckDataSet
                .DataMember = "employeeidcheck"
                .MoveFirst()
                .MoveLast()
            End With

            'Setting the combobox to the table
            With cboTransactionID
                .DataSource = TheEmployeeIDCheckBindingSource
                .DisplayMember = "TransactionID"
                .DataBindings.Add("text", TheEmployeeIDCheckBindingSource, "TransactionID", False, DataSourceUpdateMode.Never)
            End With

            'Binding the textbox
            txtEmployeeID.DataBindings.Add("text", TheEmployeeIDCheckBindingSource, "EmployeeID")

            'Getting the ID read from the table
            intEmployeeIDFromTable = CInt(txtEmployeeID.Text)

            'Setting the binding source to add a record
            With TheEmployeeIDCheckBindingSource
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
            intComboBoxCount = cboTransactionID.Items.Count

            'Getting the ID that is on the CreateEmployee Form
            intNumberOfRecords = CreateEmployee.mintCreatedCustomerID

            'Doing comparison to what was created on the form and what is in the ID Table
            If intEmployeeIDFromTable = intNumberOfRecords Then
                intNumberOfRecords = intNumberOfRecords + 1
                CreateEmployee.mintCreatedCustomerID = intNumberOfRecords
            ElseIf intNumberOfRecords < intEmployeeIDFromTable Then
                intNumberOfRecords = intEmployeeIDFromTable + 1
                CreateEmployee.mintCreatedCustomerID = intNumberOfRecords
            Else
                CreateEmployee.mintCreatedCustomerID = intNumberOfRecords
            End If

            'Place the ID in the txtEmployee ID
            txtEmployeeID.Text = CStr(intNumberOfRecords)
            cboTransactionID.Text = CStr(intComboBoxCount + 1000)

            'Updating the Dataset
            TheEmployeeIDCheckBindingSource.EndEdit()
            TheEmployeeIDCheckDataTier.UpdateDB(TheEmployeeIDCheckDataSet)

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
End Class