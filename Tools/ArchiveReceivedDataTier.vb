'Title:         Archive Received Data Tier
'Date:          6-22-15
'Author:        Terry Holmes

'Description:   This is the data tier for the archived received parts

Option Strict On

Public Class ArchiveReceivedDataTier


    Private aArchiveReceivedDataSetTableAdapter As ArchiveReceivedDataSetTableAdapters.archivedreceivedTableAdapter
    Private aArchiveReceivedDataSet As ArchiveReceivedDataSet

    Public Function GetArchiveReceivedInformation() As ArchiveReceivedDataSet

        'Setting up the Datatier
        Try
            aArchiveReceivedDataSet = New ArchiveReceivedDataSet
            aArchiveReceivedDataSetTableAdapter = New ArchiveReceivedDataSetTableAdapters.archivedreceivedTableAdapter
            aArchiveReceivedDataSetTableAdapter.Fill(aArchiveReceivedDataSet.archivedreceived)
            Return aArchiveReceivedDataSet

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Check", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return aArchiveReceivedDataSet
        End Try
    End Function

    Public Sub UpdateArchiveReceivedDB(ByVal aArchiveReceivedDataSet As ArchiveReceivedDataSet)

        'This will update the database
        Try
            aArchiveReceivedDataSetTableAdapter.Update(aArchiveReceivedDataSet.archivedreceived)
        Catch ex As Exception

        End Try
    End Sub
End Class
