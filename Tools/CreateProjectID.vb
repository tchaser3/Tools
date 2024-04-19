'Title:         Create Project ID
'Date:          1-23-15
'Author:        Terry Holmes

'Description:   This form is used to create the Project ID

Option Strict On

Public Class CreateProjectID

    Private TheInternalProjectsIDCreationDataSet As InternalProjectsIDCreationDataSet
    Private TheInternalProjectsIDCreationDataTier As InternalProjectsDataTier
    Private WithEvents TheInternalProjectsIDBindingSource As BindingSource

    Private Sub CreateProjectID_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load

        'Setting local variables
        Dim intCreatedID As Integer

        'This will load and edit thec controls
        Try

            'Loading the control
            TheInternalProjectsIDCreationDataTier = New InternalProjectsDataTier
            TheInternalProjectsIDCreationDataSet = TheInternalProjectsIDCreationDataTier.GetInternalProjectsIDCreationInformation
            TheInternalProjectsIDBindingSource = New BindingSource

            'Setting up the binding source
            With TheInternalProjectsIDBindingSource
                .DataSource = TheInternalProjectsIDCreationDataSet
                .DataMember = "internalprojectsidcreation"
                .MoveFirst()
                .MoveLast()
            End With

            'Setting up the combo box
            With cboTransactionID
                .DataSource = TheInternalProjectsIDBindingSource
                .DisplayMember = "TransactionID"
                .DataBindings.Add("text", TheInternalProjectsIDBindingSource, "TransactionID", False, DataSourceUpdateMode.Never)
            End With

            'Setting up the rest of the controls
            txtInternalProjectID.DataBindings.Add("text", TheInternalProjectsIDBindingSource, "InternalProjectID")

            'this will create the new id
            intCreatedID = CInt(txtInternalProjectID.Text)
            intCreatedID = intCreatedID + 1
            txtInternalProjectID.Text = CStr(intCreatedID)
            Logon.mintCreatedTransactionID = CInt(intCreatedID)

            'Saving the record
            TheInternalProjectsIDBindingSource.EndEdit()
            TheInternalProjectsIDCreationDataTier.UpdateInternalProjectsIDCreationDB(TheInternalProjectsIDCreationDataSet)

            'this will close the form
            Me.Close()

        Catch ex As Exception

            'this will display if there is a problem with the load
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub
End Class