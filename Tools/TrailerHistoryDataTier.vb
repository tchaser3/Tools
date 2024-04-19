'Title:     Trailer History Data Tier
'Date:      3/31/13
'Author:    Terry Holmes

Option Strict On

Public Class TrailerHistoryDataTier
    'Setting up modular variables
    Private aTrailerHistoryTableAdapter As TrailerHistoryDataSetTableAdapters.trailerhistoryTableAdapter

    Private aTrailerHistoryDataSet As TrailerHistoryDataSet

    Public Function GetTrailerHistoryInformation() As TrailerHistoryDataSet

        'Setting up the Datatier
        Try
            aTrailerHistoryDataSet = New TrailerHistoryDataSet
            aTrailerHistoryTableAdapter = New TrailerHistoryDataSetTableAdapters.trailerhistoryTableAdapter
            aTrailerHistoryTableAdapter.Fill(aTrailerHistoryDataSet.trailerhistory)
            Return aTrailerHistoryDataSet

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Check", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return aTrailerHistoryDataSet
        End Try
    End Function

    Public Sub UpdateDB(ByVal aTrailerHistoryDataSet As TrailerHistoryDataSet)

        'This will update the database
        Try
            aTrailerHistoryTableAdapter.Update(aTrailerHistoryDataSet.trailerhistory)
        Catch ex As Exception

        End Try
    End Sub
End Class
