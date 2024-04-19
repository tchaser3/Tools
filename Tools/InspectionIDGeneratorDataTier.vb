'Title:     Inspection ID Generator Data Tier
'Date:      7/25/13
'Author:    Terry Holmes

Option Strict On

Public Class InspectionIDGeneratorDataTier

    'Setting up modular variables
    Private aInspectionIDGeneratorTableAdapter As InspectionIDGeneratorDataSetTableAdapters.InspectionIDGeneratorTableAdapter

    Private aInspectionIDGeneratorDataSet As InspectionIDGeneratorDataSet

    Public Function GetInspectionIDGeneratorInformation() As InspectionIDGeneratorDataSet

        'Setting up the Datatier
        Try
            aInspectionIDGeneratorDataSet = New InspectionIDGeneratorDataSet
            aInspectionIDGeneratorTableAdapter = New InspectionIDGeneratorDataSetTableAdapters.InspectionIDGeneratorTableAdapter
            aInspectionIDGeneratorTableAdapter.Fill(aInspectionIDGeneratorDataSet.InspectionIDGenerator)
            Return aInspectionIDGeneratorDataSet

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Check", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return aInspectionIDGeneratorDataSet
        End Try
    End Function

    Public Sub UpdateDB(ByVal aInspectionIDGeneratorDataSet As InspectionIDGeneratorDataSet)

        'This will update the database
        Try
            aInspectionIDGeneratorTableAdapter.Update(aInspectionIDGeneratorDataSet.InspectionIDGenerator)
        Catch ex As Exception

        End Try
    End Sub

End Class
