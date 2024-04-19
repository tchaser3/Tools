'Title:     Part Pick List ID Data Tier
'Date:      7/11/13
'Author:    Terry Holmes

Option Strict On

Public Class PartPickListIDDataTier

    'Setting up modular variables
    Private aPartPickListIDTableAdapter As PartPickListIDDataSetTableAdapters.PartPickListIDTableAdapter

    Private aPartPickListIDDataSet As PartPickListIDDataSet

    Public Function GetPartPickListIDInformation() As PartPickListIDDataSet

        'Setting up the Datatier
        Try
            aPartPickListIDDataSet = New PartPickListIDDataSet
            aPartPickListIDTableAdapter = New PartPickListIDDataSetTableAdapters.PartPickListIDTableAdapter
            aPartPickListIDTableAdapter.Fill(aPartPickListIDDataSet.PartPickListID)
            Return aPartPickListIDDataSet

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Check", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return aPartPickListIDDataSet
        End Try
    End Function

    Public Sub UpdateDB(ByVal aPartPickListIDDataSet As PartPickListIDDataSet)

        'This will update the database
        Try
            aPartPickListIDTableAdapter.Update(aPartPickListIDDataSet.PartPickListID)
        Catch ex As Exception

        End Try
    End Sub

End Class
