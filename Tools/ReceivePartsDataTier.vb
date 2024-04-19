'Title:         Receive Parts Data Tier
'Date:          2-16-15
'Author:        Terry Holmes

'Description:   This is the data tier for the Receive Parts

Option Strict On

Public Class ReceivePartsDataTier

    Private aReceivedPartsDataSetTableAdapter As ReceivedPartsDataSetTableAdapters.ReceivedPartsTableAdapter
    Private aReceivedPartsDataSet As ReceivedPartsDataSet

    Public Function GetReceivedPartsInformation() As ReceivedPartsDataSet

        'Setting up the Datatier
        Try
            aReceivedPartsDataSet = New ReceivedPartsDataSet
            aReceivedPartsDataSetTableAdapter = New ReceivedPartsDataSetTableAdapters.ReceivedPartsTableAdapter
            aReceivedPartsDataSetTableAdapter.Fill(aReceivedPartsDataSet.ReceivedParts)
            Return aReceivedPartsDataSet

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Check", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return aReceivedPartsDataSet
        End Try
    End Function

    Public Sub UpdateReceivedPartsDB(ByVal aReceivePartsDataSet As ReceivedPartsDataSet)

        'This will update the database
        Try
            aReceivedPartsDataSetTableAdapter.Update(aReceivePartsDataSet.ReceivedParts)
        Catch ex As Exception

        End Try
    End Sub


End Class
