'Title:         Removed Projects
'Date:          11-9-15
'Author:        Terry Holmes

'Description:   This form is used to save any removed or deleted projects

Option Strict On

Public Class RemovedProjects

    'setting global variables
    Private TheRemovedProjectDataSet As RemovedProjectDataSet
    Private TheRemovedProjectDataTier As InternalProjectsDataTier
    Private WithEvents TheRemovedProjectBindingSource As BindingSource

    Private addingBoolean As Boolean
    Private editingBoolean As Boolean


    Private Sub setComboBoxBinding()

        'Sets the Combobox Bindings
        With Me.cboInternalProjectID
            If (addingBoolean Or editingBoolean) Then
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.OnValidation
                .DropDownStyle = ComboBoxStyle.Simple
            Else
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.Never
                .DropDownStyle = ComboBoxStyle.DropDownList
            End If
        End With
    End Sub

    Private Sub RemovedProjects_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'This will load and save the transaction
        'Try Catch for exceptions

        'setting local variables
        Dim datTodaysDate As Date = Date.Now
        Dim strTodaysDate As String

        Try

            TheRemovedProjectDataTier = New InternalProjectsDataTier
            TheRemovedProjectDataSet = TheRemovedProjectDataTier.GetRemovedProjectsInformation
            TheRemovedProjectBindingSource = New BindingSource

            'Setting up the bindingsource
            With TheRemovedProjectBindingSource
                .DataSource = TheRemovedProjectDataSet
                .DataMember = "removedprojects"
                .MoveFirst()
                .MoveLast()
            End With

            'setting up the combo box
            With cboInternalProjectID
                .DataSource = TheRemovedProjectBindingSource
                .DisplayMember = "InternalProjectID"
                .DataBindings.Add("Text", TheRemovedProjectBindingSource, "InternalProjectID", False, DataSourceUpdateMode.Never)
            End With

            'setting up the rest of the controls
            txtMSRNumber.DataBindings.Add("text", TheRemovedProjectBindingSource, "MSRNumber")
            txtProjectName.DataBindings.Add("text", TheRemovedProjectBindingSource, "ProjectName")
            txtSupplyingWarehouse.DataBindings.Add("Text", TheRemovedProjectBindingSource, "Warehouse")
            txtTWCControlNumber.DataBindings.Add("text", TheRemovedProjectBindingSource, "TWCProjectID")
            txtDate.DataBindings.Add("Text", TheRemovedProjectBindingSource, "Date")
            txtEmployeeID.DataBindings.Add("text", TheRemovedProjectBindingSource, "EmployeeID")

            'adding the record
            With TheRemovedProjectBindingSource
                .EndEdit()
                .AddNew()
            End With

            addingBoolean = True
            setComboBoxBinding()
            cboInternalProjectID.Text = CStr(Logon.mintCreatedTransactionID)
            txtMSRNumber.Text = Logon.mstrMSR
            txtProjectName.Text = Logon.mstrProjectName
            txtTWCControlNumber.Text = Logon.mstrTWCProjectID
            txtSupplyingWarehouse.Text = Logon.mstrWarehouse
            strTodaysDate = CStr(datTodaysDate)
            txtDate.Text = strTodaysDate
            txtEmployeeID.Text = CStr(Logon.mintWarehouseEmployeeID)

            'saving record
            TheRemovedProjectBindingSource.EndEdit()
            TheRemovedProjectDataTier.UpdateRemovedProjectDB(TheRemovedProjectDataSet)
            addingBoolean = False
            editingBoolean = False
            setComboBoxBinding()

            Me.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class