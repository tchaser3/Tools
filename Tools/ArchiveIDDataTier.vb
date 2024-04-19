'Title:         Archive ID Data Tier
'Date:          6-22-15
'Author:        Terry Holmes

'Description:   This is the data tier to create an archive id

Option Strict On

Public Class ArchiveIDDataTier

    Private aArchiveIDDataSetTableAdapter As ArchiveIDDataSetTableAdapters.archiveidTableAdapter
    Private aArchiveIDDataSet As ArchiveIDDataSet

    Public Function GetArchiveIDInformation() As ArchiveIDDataSet

        'Setting up the Datatier
        Try
            aArchiveIDDataSet = New ArchiveIDDataSet
            aArchiveIDDataSetTableAdapter = New ArchiveIDDataSetTableAdapters.archiveidTableAdapter
            aArchiveIDDataSetTableAdapter.Fill(aArchiveIDDataSet.archiveid)
            Return aArchiveIDDataSet

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Check", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return aArchiveIDDataSet
        End Try
    End Function

    Public Sub UpdateArchiveIDDB(ByVal aLastTransactionIDDataSet As ArchiveIDDataSet)

        'This will update the database
        Try
            aArchiveIDDataSetTableAdapter.Update(aArchiveIDDataSet.archiveid)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class
