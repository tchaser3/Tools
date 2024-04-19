'Title:         Vendor Data Tier
'Date:          11-10-14
'Author:        Terry Holmes

'Description:   This class is used for accessing the vendor information

Option Strict On

Public Class VendorDataTier

    Private aVendorsDataSetTableAdapter As VendorsDataSetTableAdapters.vendorsTableAdapter
    Private aVendorsDataSet As VendorsDataSet

    Private aVendorIDDataSetTableAdapter As VendorIDDataSetTableAdapters.vendoridTableAdapter
    Private aVendorIDDataSet As VendorIDDataSet

    Public Function GetVendorIDinformation() As VendorIDDataSet

        'Try and Catch
        Try
            'Setting up the variables
            aVendorIDDataSet = New VendorIDDataSet
            aVendorIDDataSetTableAdapter = New VendorIDDataSetTableAdapters.vendoridTableAdapter
            aVendorIDDataSetTableAdapter.Fill(aVendorIDDataSet.vendorid)
            Return aVendorIDDataSet

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return aVendorIDDataSet

        End Try

    End Function
    Public Sub UpdateVendorIDDB(ByVal aVendorIDDataSet As VendorIDDataSet)

        'Try Catch to catch exceptions
        Try
            aVendorIDDataSetTableAdapter.Update(aVendorIDDataSet.vendorid)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Function GetVendorsinformation() As VendorsDataSet

        'Try and Catch
        Try
            'Setting up the variables
            aVendorsDataSet = New VendorsDataSet
            aVendorsDataSetTableAdapter = New VendorsDataSetTableAdapters.vendorsTableAdapter
            aVendorsDataSetTableAdapter.Fill(aVendorsDataSet.vendors)
            Return aVendorsDataSet

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return aVendorsDataSet

        End Try

    End Function
    Public Sub UpdateVendorsDB(ByVal aVendorsDataSet As VendorsDataSet)

        'Try Catch to catch exceptions
        Try
            aVendorsDataSetTableAdapter.Update(aVendorsDataSet.vendors)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class
