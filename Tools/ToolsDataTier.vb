'Title:     Tools Data Tier
'Date:      3/28/13
'Author:    Terry Holmes

Option Strict On

Public Class ToolsDataTier
    'Setting up modular variables
    Private aToolsTableAdapter As toolsDataSetTableAdapters.toolsTableAdapter
    Private aToolsDataSet As toolsDataSet

    Private aToolCategoryTableAdapter As ToolCategoryDataSetTableAdapters.toolcategoryTableAdapter
    Private aToolCategoryDataSet As ToolCategoryDataSet

    Public Function GetToolCategoryInformation() As ToolCategoryDataSet

        'Setting up the Datatier
        Try
            aToolCategoryDataSet = New ToolCategoryDataSet
            aToolCategoryTableAdapter = New ToolCategoryDataSetTableAdapters.toolcategoryTableAdapter
            aToolCategoryTableAdapter.Fill(aToolCategoryDataSet.toolcategory)
            Return aToolCategoryDataSet

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Check", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return aToolCategoryDataSet
        End Try
    End Function
    Public Sub UpdateToolCategoryDB(ByVal aToolCategoryDataSet As ToolCategoryDataSet)

        'This will update the database
        Try
            aToolCategoryTableAdapter.Update(aToolCategoryDataSet.toolcategory)
        Catch ex As Exception

        End Try
    End Sub

    Public Function GetToolInformation() As toolsDataSet

        'Setting up the Datatier
        Try
            aToolsDataSet = New toolsDataSet
            aToolsTableAdapter = New toolsDataSetTableAdapters.toolsTableAdapter
            aToolsTableAdapter.Fill(aToolsDataSet.tools)
            Return aToolsDataSet

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Check", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return aToolsDataSet
        End Try
    End Function

    Public Sub UpdateToolDB(ByVal aToolsDataSet As toolsDataSet)

        'This will update the database
        Try
            aToolsTableAdapter.Update(aToolsDataSet.tools)
        Catch ex As Exception

        End Try
    End Sub
End Class
