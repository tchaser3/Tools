'Title:     Tool ID Check Data Tier
'Date:      4/15/13
'Author:    Terry Holmes

Option Strict On

Public Class ToolIDCheckDataTier
    'Setting up modular variables
    Private aToolIDCheckTableAdapter As ToolIDCheckDataSetTableAdapters.toolidcheckTableAdapter

    Private aToolIDCheckDataSet As ToolIDCheckDataSet

    Public Function GetToolIDInformation() As ToolIDCheckDataSet

        'Setting up the Datatier
        Try
            aToolIDCheckDataSet = New ToolIDCheckDataSet
            aToolIDCheckTableAdapter = New ToolIDCheckDataSetTableAdapters.toolidcheckTableAdapter
            aToolIDCheckTableAdapter.Fill(aToolIDCheckDataSet.toolidcheck)
            Return aToolIDCheckDataSet

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Check", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return aToolIDCheckDataSet
        End Try
    End Function

    Public Sub UpdateDB(ByVal aToolIDCheckDataSet As ToolIDCheckDataSet)

        'This will update the database
        Try
            aToolIDCheckTableAdapter.Update(aToolIDCheckDataSet.toolidcheck)
        Catch ex As Exception

        End Try
    End Sub
End Class
