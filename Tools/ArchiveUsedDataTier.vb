'Title:         Archive Used Data Tier
'Date:          6-22-15
'Author:        Terry Holmes

'Description:   This is the Data Tier for archiving the BOM Data

Option Strict On

Public Class ArchiveUsedDataTier

    'Setting global variables
    Private aArchiveUsedDataSetTableAdapter As ArchiveUsedDataSetTableAdapters.archivedusedTableAdapter
    Private aArchiveUsedDataSet As ArchiveUsedDataSet

    Public Function GetArchiveUsedInformation() As ArchiveUsedDataSet

        'Setting up the Datatier
        Try
            aArchiveUsedDataSet = New ArchiveUsedDataSet
            aArchiveUsedDataSetTableAdapter = New ArchiveUsedDataSetTableAdapters.archivedusedTableAdapter
            aArchiveUsedDataSetTableAdapter.Fill(aArchiveUsedDataSet.archivedused)
            Return aArchiveUsedDataSet

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Check", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return aArchiveUsedDataSet
        End Try
    End Function

    Public Sub UpdateArchiveUsedDB(ByVal aArchiveUsedDataSet As ArchiveUsedDataSet)

        'This will update the database
        Try
            aArchiveUsedDataSetTableAdapter.Update(aArchiveUsedDataSet.archivedused)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class
