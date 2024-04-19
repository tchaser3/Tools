'Title:     Trailer ID Check Data Tier
'Date:      4/15/13
'Author:    Terry Holmes

Option Strict On

Public Class TrailersIDCheckDataTier
    'Setting up modular variables
    Private aTrailersIDCheckTableAdapter As TrailersIDCheckDataSetTableAdapters.trailersidcheckTableAdapter

    Private aTrailersIDCheckDataSet As TrailersIDCheckDataSet

    Public Function GetTrailersIDInformation() As TrailersIDCheckDataSet

        'Setting up the Datatier
        Try
            aTrailersIDCheckDataSet = New TrailersIDCheckDataSet
            aTrailersIDCheckTableAdapter = New TrailersIDCheckDataSetTableAdapters.trailersidcheckTableAdapter
            aTrailersIDCheckTableAdapter.Fill(aTrailersIDCheckDataSet.trailersidcheck)
            Return aTrailersIDCheckDataSet

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Check", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return aTrailersIDCheckDataSet
        End Try
    End Function

    Public Sub UpdateDB(ByVal aTrailersIDCheckDataSet As TrailersIDCheckDataSet)

        'This will update the database
        Try
            aTrailersIDCheckTableAdapter.Update(aTrailersIDCheckDataSet.trailersidcheck)
        Catch ex As Exception

        End Try
    End Sub
End Class
