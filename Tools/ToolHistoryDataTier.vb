'Title:     Tool History Data Tier
'Date:      3/28/13
'Author:    Terry Holmes

Option Strict On

Public Class ToolHistoryDataTier
    'Setting up modular variables
    Private aToolsHistoryTableAdapter As ToolsHistoryDataSetTableAdapters.toolhistoryTableAdapter

    Private aToolsHistoryDataSet As ToolsHistoryDataSet

    Public Function GetHistoryInformation() As ToolsHistoryDataSet

        'Setting up the Datatier
        Try
            aToolsHistoryDataSet = New ToolsHistoryDataSet
            aToolsHistoryTableAdapter = New ToolsHistoryDataSetTableAdapters.toolhistoryTableAdapter
            aToolsHistoryTableAdapter.Fill(aToolsHistoryDataSet.toolhistory)
            Return aToolsHistoryDataSet

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Check", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return aToolsHistoryDataSet
        End Try
    End Function

    Public Sub UpdateDB(ByVal aToolsHistoryDataSet As ToolsHistoryDataSet)

        'This will update the database
        Try
            aToolsHistoryTableAdapter.Update(aToolsHistoryDataSet.toolhistory)
        Catch ex As Exception

        End Try
    End Sub
End Class
