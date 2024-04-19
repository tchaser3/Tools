'Title:         Verify Job Type
'Date:          9/3/14
'Author:        Terry Holmes

'Description:   This form is used to verify the Job Type Entered

Option Strict On

Public Class VerifyJobType

    'Setting up Employee Information
    Private TheJobTypeDataSet As JobTypeDataSet
    Private TheJobTypeDataTier As InternalProjectsDataTier
    Private WithEvents TheJobTypeBindingSource As BindingSource

    Private Sub VerifyJobType_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Setting Local Variables
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim strJobTypeForSearch As String
        Dim strJobTypeFromTable As String
        Dim blnFatalError As Boolean = True

        'This is used to load up the form
        Try

            'This will bind the controls
            TheJobTypeDataTier = New InternalProjectsDataTier
            TheJobTypeDataSet = TheJobTypeDataTier.GetJobTypeInformation
            TheJobTypeBindingSource = New BindingSource

            'Setting up the binding source
            With TheJobTypeBindingSource
                .DataSource = TheJobTypeDataSet
                .DataMember = "jobtype"
                .MoveFirst()
                .MoveLast()
            End With

            'Binding the controls
            With cboJobTypeID
                .DataSource = TheJobTypeBindingSource
                .DisplayMember = "JobTypeID"
                .DataBindings.Add("text", TheJobTypeBindingSource, "JobTypeID", False, DataSourceUpdateMode.Never)
            End With

            txtJobType.DataBindings.Add("text", TheJobTypeBindingSource, "JobType")

            'Preparing for the loop
            intNumberOfRecords = cboJobTypeID.Items.Count - 1
            strJobTypeForSearch = Logon.mstrCableSelectionType

            'Performing the loop
            For intCounter = 0 To intNumberOfRecords

                'Setting variables for the IF statements
                cboJobTypeID.SelectedIndex = intCounter
                strJobTypeFromTable = txtJobType.Text

                'If statement to see if the job type is the same
                If strJobTypeForSearch = strJobTypeFromTable Then
                    blnFatalError = False
                End If

            Next

            'Setting up global variable
            Logon.mbolFatalError = blnFatalError

            'Closing the form
            Me.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
End Class