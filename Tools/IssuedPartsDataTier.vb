'Title:         Issued Parts Data Tier
'Date:          3-10-15
'Author:        Terry Holmes

'Description:   This is the data tier for the issued parts

Option Strict On

Public Class IssuedPartsDataTier

    Private aIssuedPartsDataSetTableAdapter As IssuedPartsDataSetTableAdapters.IssuedPartsTableAdapter
    Private aIssuedPartsDataSet As IssuedPartsDataSet

    Public Function GetIssuedPartsInformation() As IssuedPartsDataSet

        'Setting up the Datatier
        Try
            aIssuedPartsDataSet = New IssuedPartsDataSet
            aIssuedPartsDataSetTableAdapter = New IssuedPartsDataSetTableAdapters.IssuedPartsTableAdapter
            aIssuedPartsDataSetTableAdapter.Fill(aIssuedPartsDataSet.IssuedParts)
            Return aIssuedPartsDataSet

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Check", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return aIssuedPartsDataSet
        End Try
    End Function

    Public Sub UpdateIssuedPartsDB(ByVal aIssuedPartsDataSet As IssuedPartsDataSet)

        'This will update the database
        Try
            aIssuedPartsDataSetTableAdapter.Update(aIssuedPartsDataSet.IssuedParts)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class
