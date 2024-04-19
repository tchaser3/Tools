'Title:     Trailers Data Tier
'Date:      3/31/13
'Author:    Terry Holmes

Option Strict On

Public Class TrailersDataTier
    'Setting up modular variables
    Private aTrailersTableAdapter As TrailersDataSetTableAdapters.trailersTableAdapter

    Private aTrailersDataSet As TrailersDataSet

    Public Function GetTrailersInformation() As TrailersDataSet

        'Setting up the Datatier
        Try
            aTrailersDataSet = New TrailersDataSet
            aTrailersTableAdapter = New TrailersDataSetTableAdapters.trailersTableAdapter
            aTrailersTableAdapter.Fill(aTrailersDataSet.trailers)
            Return aTrailersDataSet

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Check", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return aTrailersDataSet
        End Try
    End Function

    Public Sub UpdateDB(ByVal aTrailersDataSet As TrailersDataSet)

        'This will update the database
        Try
            aTrailersTableAdapter.Update(aTrailersDataSet.trailers)
        Catch ex As Exception

        End Try
    End Sub
End Class
