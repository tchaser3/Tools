'Title:     Employee ID Check Data Tier
'Date:      April 15 2013
'Author:    Terry Holmes

Option Strict On

Public Class EmployeeIDCheckDataTier
    'Setting up modular variables
    Private aEmployeeIDCheckTableAdapter As EmployeeIDCheckDataSetTableAdapters.employeeidcheckTableAdapter

    Private aEmployeeIDCheckDataSet As EmployeeIDCheckDataSet

    Public Function GetEmployeeIDInformation() As EmployeeIDCheckDataSet

        'Setting up the Datatier
        Try
            aEmployeeIDCheckDataSet = New EmployeeIDCheckDataSet
            aEmployeeIDCheckTableAdapter = New EmployeeIDCheckDataSetTableAdapters.employeeidcheckTableAdapter
            aEmployeeIDCheckTableAdapter.Fill(aEmployeeIDCheckDataSet.employeeidcheck)
            Return aEmployeeIDCheckDataSet

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Check", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return aEmployeeIDCheckDataSet
        End Try
    End Function

    Public Sub UpdateDB(ByVal aEmployeeIDCheckDataSet As EmployeeIDCheckDataSet)

        'This will update the database
        Try
            aEmployeeIDCheckTableAdapter.Update(aEmployeeIDCheckDataSet.employeeidcheck)
        Catch ex As Exception

        End Try
    End Sub
End Class
