'Title:         Auto Sign In Date Data Tier
'Date:          10-9-15
'Author:        Terry Holmes

'Description:   This is the data tier for the auto sign in

Option Strict On

Public Class AutoSignInDateDataTier

    Private aAutoSignInDateDataSetTableAdpaters As AutoSignInDateDataSetTableAdapters.autosignindateTableAdapter
    Private aAutoSignInDataDataSet As AutoSignInDateDataSet

    Public Function GetAutoSignInInformation() As AutoSignInDateDataSet

        Try

            aAutoSignInDataDataSet = New AutoSignInDateDataSet
            aAutoSignInDateDataSetTableAdpaters = New AutoSignInDateDataSetTableAdapters.autosignindateTableAdapter
            aAutoSignInDateDataSetTableAdpaters.Fill(aAutoSignInDataDataSet.autosignindate)

            Return aAutoSignInDataDataSet

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return aAutoSignInDataDataSet
        End Try
    End Function

    Public Sub UpdateAutoSignInDB(ByVal aAutoSignInDateDataSet As AutoSignInDateDataSet)

        'This will update the database
        Try
            aAutoSignInDateDataSetTableAdpaters.Update(aAutoSignInDateDataSet.autosignindate)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class
