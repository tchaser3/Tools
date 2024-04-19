'Title:     Pick List Data Tier
'Date:      7/11/13
'Author:    Terry Holmes

Option Strict On

Public Class PickListDataTier

    'Setting up modular variables
    Private aPickListTableAdapter As PickListDataSetTableAdapters.PickListTableAdapter

    Private aPickListDataSet As PickListDataSet

    Public Function GetPickListInformation() As PickListDataSet

        'Setting up the Datatier
        Try
            aPickListDataSet = New PickListDataSet
            aPickListTableAdapter = New PickListDataSetTableAdapters.PickListTableAdapter
            aPickListTableAdapter.Fill(aPickListDataSet.PickList)
            Return aPickListDataSet

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Check", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return aPickListDataSet
        End Try
    End Function

    Public Sub UpdateDB(ByVal aPickListDataSet As PickListDataSet)

        'This will update the database
        Try
            aPickListTableAdapter.Update(aPickListDataSet.PickList)
        Catch ex As Exception

        End Try
    End Sub

End Class
