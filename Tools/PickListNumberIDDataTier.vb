'Title:     Pick List Number ID Data Tier
'Date:      7/11/13
'Author:    Terry Holmes

Option Strict On

Public Class PickListNumberIDDataTier

    'Setting up modular variables
    Private aPickListNumberIDTableAdapter As PickListNumberIDDataSetTableAdapters.PickListNumberIDTableAdapter

    Private aPickListNumberIDDataSet As PickListNumberIDDataSet

    Public Function GetPickListNumberIDInformation() As PickListNumberIDDataSet

        'Setting up the Datatier
        Try
            aPickListNumberIDDataSet = New PickListNumberIDDataSet
            aPickListNumberIDTableAdapter = New PickListNumberIDDataSetTableAdapters.PickListNumberIDTableAdapter
            aPickListNumberIDTableAdapter.Fill(aPickListNumberIDDataSet.PickListNumberID)
            Return aPickListNumberIDDataSet

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Check", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return aPickListNumberIDDataSet
        End Try
    End Function

    Public Sub UpdateDB(ByVal aPickListPickListNumberIDDataSet As PickListNumberIDDataSet)

        'This will update the database
        Try
            aPickListNumberIDTableAdapter.Update(aPickListNumberIDDataSet.PickListNumberID)
        Catch ex As Exception

        End Try
    End Sub

End Class
