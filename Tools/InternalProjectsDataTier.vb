'Title:         Internal Projects Data Tier
'Data:          12/30/13
'Author:        Terry Holmes

'Description:   This is the Data Tier for the Internal Projects Form

Option Strict On

Public Class InternalProjectsDataTier

    'Setting Up Internal Projects Modular Variables
    Private aInternalProjectsTableAdapter As InternalProjectsDataSetTableAdapters.internalprojectsTableAdapter
    Private aInternalProjectsDataSet As InternalProjectsDataSet

    Private aJobTypeTableAdapter As JobTypeDataSetTableAdapters.jobtypeTableAdapter
    Private aJobTypeDataSet As JobTypeDataSet

    Private aInternalProjectsIDCreationTableAdapter As InternalProjectsIDCreationDataSetTableAdapters.internalprojectsidcreationTableAdapter
    Private aInternalProjectsIDCreationDataSet As InternalProjectsIDCreationDataSet

    Private aRemovedProjectTableAdapter As RemovedProjectDataSetTableAdapters.removedprojectsTableAdapter
    Private aRemovedProjectDataSet As RemovedProjectDataSet

    Public Function GetRemovedProjectsInformation() As RemovedProjectDataSet

        'Setting up this Function of the Data Tier
        Try

            aRemovedProjectDataSet = New RemovedProjectDataSet
            aRemovedProjectTableAdapter = New RemovedProjectDataSetTableAdapters.removedprojectsTableAdapter
            aRemovedProjectTableAdapter.Fill(aRemovedProjectDataSet.removedprojects)
            Return aRemovedProjectDataSet

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Please Check", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return aRemovedProjectDataSet

        End Try
    End Function

    Public Sub UpdateRemovedProjectDB(ByVal aRemovedProjectDataSet As RemovedProjectDataSet)

        Try

            aRemovedProjectTableAdapter.Update(aRemovedProjectDataSet.removedprojects)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Function GetInternalProjectsIDCreationInformation() As InternalProjectsIDCreationDataSet

        'Setting up this Function of the Data Tier
        Try

            aInternalProjectsIDCreationDataSet = New InternalProjectsIDCreationDataSet
            aInternalProjectsIDCreationTableAdapter = New InternalProjectsIDCreationDataSetTableAdapters.internalprojectsidcreationTableAdapter
            aInternalProjectsIDCreationTableAdapter.Fill(aInternalProjectsIDCreationDataSet.internalprojectsidcreation)
            Return aInternalProjectsIDCreationDataSet

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Please Check", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return aInternalProjectsIDCreationDataSet

        End Try
    End Function

    Public Sub UpdateInternalProjectsIDCreationDB(ByVal aInternalProjectsIDCreationDataSet As InternalProjectsIDCreationDataSet)

        Try

            aInternalProjectsIDCreationTableAdapter.Update(aInternalProjectsIDCreationDataSet.internalprojectsidcreation)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Function GetJobTypeInformation() As JobTypeDataSet

        'Setting up this Function of the Data Tier
        Try

            aJobTypeDataSet = New JobTypeDataSet
            aJobTypeTableAdapter = New JobTypeDataSetTableAdapters.jobtypeTableAdapter
            aJobTypeTableAdapter.Fill(aJobTypeDataSet.jobtype)
            Return aJobTypeDataSet

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Please Check", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return aJobTypeDataSet

        End Try
    End Function

    Public Sub UpdateJobTypeDB(ByVal aJobTypeDataSet As JobTypeDataSet)

        Try

            aJobTypeTableAdapter.Update(aJobTypeDataSet.jobtype)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    Public Function GetInternalProjectsInformation() As InternalProjectsDataSet

        'Setting up this Function of the Data Tier
        Try

            aInternalProjectsDataSet = New InternalProjectsDataSet
            aInternalProjectsTableAdapter = New InternalProjectsDataSetTableAdapters.internalprojectsTableAdapter
            aInternalProjectsTableAdapter.Fill(aInternalProjectsDataSet.internalprojects)
            Return aInternalProjectsDataSet

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Please Check", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return aInternalProjectsDataSet

        End Try
    End Function

    Public Sub UpdateInternalProjectsDB(ByVal aInternalProjectsDataSet As InternalProjectsDataSet)

        Try

            aInternalProjectsTableAdapter.Update(aInternalProjectsDataSet.internalprojects)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

End Class
