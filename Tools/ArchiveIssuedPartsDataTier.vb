'Title:         Archive Issued Parts Data Tier
'Date:          6-22-15
'Author:        Terry Holmes

'Description:   This is the data tier for the archived issued parts

Option Strict On

Public Class ArchiveIssuedPartsDataTier

    Private aArchiveIssuedDataSetTableAdapter As ArchiveIssuedDataSetTableAdapters.archivedissuedTableAdapter
    Private aArchiveIssuedDataSet As ArchiveIssuedDataSet

    Public Function GetArchiveIssuedInformation() As ArchiveIssuedDataSet

        'Setting up the Datatier
        Try
            aArchiveIssuedDataSet = New ArchiveIssuedDataSet
            aArchiveIssuedDataSetTableAdapter = New ArchiveIssuedDataSetTableAdapters.archivedissuedTableAdapter
            aArchiveIssuedDataSetTableAdapter.Fill(aArchiveIssuedDataSet.archivedissued)
            Return aArchiveIssuedDataSet

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Check", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return aArchiveIssuedDataSet
        End Try
    End Function

    Public Sub UpdateArchiveIssuedDB(ByVal aArchiveIssuedDataSet As ArchiveIssuedDataSet)

        'This will update the database
        Try
            aArchiveIssuedDataSetTableAdapter.Update(aArchiveIssuedDataSet.archivedissued)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class
