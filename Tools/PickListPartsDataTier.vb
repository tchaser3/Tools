'Title:     Pick List Parts Data Tier
'Date:      7/11/13
'Author:    Terry Holmes

Option Strict On

Public Class PickListPartsDataTier

    'Setting up modular variables
    Private aPickListPartsTableAdapter As PickListPartsDataSetTableAdapters.PickListPartsTableAdapter

    Private aPickListPartsDataSet As PickListPartsDataSet

    Public Function GetPickListPartsInformation() As PickListPartsDataSet

        'Setting up the Datatier
        Try
            aPickListPartsDataSet = New PickListPartsDataSet
            aPickListPartsTableAdapter = New PickListPartsDataSetTableAdapters.PickListPartsTableAdapter
            aPickListPartsTableAdapter.Fill(aPickListPartsDataSet.PickListParts)
            Return aPickListPartsDataSet

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Check", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return aPickListPartsDataSet
        End Try
    End Function

    Public Sub UpdateDB(ByVal aPickListPartsDataSet As PickListPartsDataSet)

        'This will update the database
        Try
            aPickListPartsTableAdapter.Update(aPickListPartsDataSet.PickListParts)
        Catch ex As Exception

        End Try
    End Sub

End Class
