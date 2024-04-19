'Title:     Employee Data Tier
'Date:      3/28/13
'Author:    Terry Holmes

Option Strict On

Public Class EmployeeDataTier
    'Setting up modular variables
    Private aEmployeeTableAdapter As EmployeeDataSetTableAdapters.employeesTableAdapter

    Private aEmployeeDataSet As EmployeeDataSet

    Public Function GetEmployeeInformation() As EmployeeDataSet

        'Setting up the Datatier
        Try
            aEmployeeDataSet = New EmployeeDataSet
            aEmployeeTableAdapter = New EmployeeDataSetTableAdapters.employeesTableAdapter
            aEmployeeTableAdapter.Fill(aEmployeeDataSet.employees)
            Return aEmployeeDataSet

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Check", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return aEmployeeDataSet
        End Try
    End Function

    Public Sub UpdateDB(ByVal aEmployeeDataSet As EmployeeDataSet)

        'This will update the database
        Try
            aEmployeeTableAdapter.Update(aEmployeeDataSet.employees)
        Catch ex As Exception

        End Try
    End Sub
End Class
