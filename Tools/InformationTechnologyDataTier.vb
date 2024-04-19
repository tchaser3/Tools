'Title:         Information Technology Data Tier
'Date:          9/11/14
'Author:        Terry Holmes

'Description:   This class is the Information Technology Data Tier

Public Class InformationTechnologyDataTier

    'Setting Global Variables
    Private aInformationTechnologyDevicesDataSetTableAdapter As InformationTechnologyDevicesDataSetTableAdapters.informationtechnologydevicesTableAdapter
    Private aInformationTechnologyDevicesDataSet As InformationTechnologyDevicesDataSet

    Private aInformationTechnologyIDDataSetTableAdapter As InformationTechnologyIDDataSetTableAdapters.informationtechnologyidTableAdapter
    Private aInformationTechnologyIDDataSet As InformationTechnologyIDDataSet

    Private aInformationTechnologyHistoryDataSetTableAdapter As InformationTechnologyHistoryDataSetTableAdapters.informationtechnologyhistoryTableAdapter
    Private aInformationTechnologyHistoryDataSet As InformationTechnologyHistoryDataSet

    Private aInformationTechnologyInspectionDataSetTableAdapter As InformationTechnologyInspectionDataSetTableAdapters.informationtechnologyinspectionTableAdapter
    Private aInformationTechnologyInspectionDataSet As InformationTechnologyInspectionDataSet

    Private aInformationTechnologyProblemDataSetTableAdapter As InformationTechnologyProblemDataSetTableAdapters.informationtechnologyproblemTableAdapter
    Private aInformationTechnologyProblemDataSet As InformationTechnologyProblemDataSet

    Private aInformationTechnologyDeviceAccessoriesDataSetTableAdapter As InformationTechnologyDeviceAccessoriesDataSetTableAdapters.informationtechnologydeviceaccessoriesTableAdapter
    Private aInformationTechnologyDeviceAccessoriesDataSet As InformationTechnologyDeviceAccessoriesDataSet

    Private aInformationTechnologyPasswordDataSetTableAdapter As InformationTechnologyPasswordDataSetTableAdapters.informationtechnologypasswordTableAdapter
    Private aInformationTechnologyPasswordDataSet As InformationTechnologyPasswordDataSet

    Private aInformationTechnologyAccessoryHistoryDataSetTableAdapter As InformationTechnologyAccessoryHistoryDataSetTableAdapters.informationtechnologyaccessoryhistoryTableAdapter
    Private aInformationTechnologyAccessoryHistoryDataSet As InformationTechnologyAccessoryHistoryDataSet

    Public Function GetInformationTechnologyAccessoryHistoryInformation() As InformationTechnologyAccessoryHistoryDataSet

        Try

            'Getting Device Information
            aInformationTechnologyAccessoryHistoryDataSet = New InformationTechnologyAccessoryHistoryDataSet
            aInformationTechnologyAccessoryHistoryDataSetTableAdapter = New InformationTechnologyAccessoryHistoryDataSetTableAdapters.informationtechnologyaccessoryhistoryTableAdapter
            aInformationTechnologyAccessoryHistoryDataSetTableAdapter.Fill(aInformationTechnologyAccessoryHistoryDataSet.informationtechnologyaccessoryhistory)
            Return aInformationTechnologyAccessoryHistoryDataSet

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return aInformationTechnologyAccessoryHistoryDataSet
        End Try

    End Function
    Public Sub UpdateInformationTechnologyAccessoryHistoryDB(ByVal aInformationTechnologAccessoryHistoryDataSet As InformationTechnologyAccessoryHistoryDataSet)

        Try
            'Setting up the Devices
            aInformationTechnologyAccessoryHistoryDataSetTableAdapter.Update(aInformationTechnologyAccessoryHistoryDataSet.informationtechnologyaccessoryhistory)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Function GetInformationTechnologyPasswordInformation() As InformationTechnologyPasswordDataSet

        Try

            'Getting Device Information
            aInformationTechnologyPasswordDataSet = New InformationTechnologyPasswordDataSet
            aInformationTechnologyPasswordDataSetTableAdapter = New InformationTechnologyPasswordDataSetTableAdapters.informationtechnologypasswordTableAdapter
            aInformationTechnologyPasswordDataSetTableAdapter.Fill(aInformationTechnologyPasswordDataSet.informationtechnologypassword)
            Return aInformationTechnologyPasswordDataSet

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return aInformationTechnologyPasswordDataSet
        End Try

    End Function
    Public Sub UpdateInformationTechnologyPasswordDB(ByVal aInformationTechnologyPasswordDataSet As InformationTechnologyPasswordDataSet)

        Try
            'Setting up the Devices
            aInformationTechnologyPasswordDataSetTableAdapter.Update(aInformationTechnologyPasswordDataSet.informationtechnologypassword)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Function GetInformationTechnologyDeviceAccessoriesInformation() As InformationTechnologyDeviceAccessoriesDataSet

        Try

            'Getting Device Information
            aInformationTechnologyDeviceAccessoriesDataSet = New InformationTechnologyDeviceAccessoriesDataSet
            aInformationTechnologyDeviceAccessoriesDataSetTableAdapter = New InformationTechnologyDeviceAccessoriesDataSetTableAdapters.informationtechnologydeviceaccessoriesTableAdapter
            aInformationTechnologyDeviceAccessoriesDataSetTableAdapter.Fill(aInformationTechnologyDeviceAccessoriesDataSet.informationtechnologydeviceaccessories)
            Return aInformationTechnologyDeviceAccessoriesDataSet

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return aInformationTechnologyDeviceAccessoriesDataSet
        End Try

    End Function
    Public Sub UpdateInformationTechnologyDeviceAccessoriesDB(ByVal aInformationTechnologyDeviceAccessoriesDataSet As InformationTechnologyDeviceAccessoriesDataSet)

        Try
            'Setting up the Devices
            aInformationTechnologyDeviceAccessoriesDataSetTableAdapter.Update(aInformationTechnologyDeviceAccessoriesDataSet.informationtechnologydeviceaccessories)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Function GetInformationTechnologyProblemInformation() As InformationTechnologyProblemDataSet

        Try
            'Setting to Get Problem Information
            aInformationTechnologyProblemDataSet = New InformationTechnologyProblemDataSet
            aInformationTechnologyProblemDataSetTableAdapter = New InformationTechnologyProblemDataSetTableAdapters.informationtechnologyproblemTableAdapter
            aInformationTechnologyProblemDataSetTableAdapter.Fill(aInformationTechnologyProblemDataSet.informationtechnologyproblem)
            Return aInformationTechnologyProblemDataSet

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return aInformationTechnologyProblemDataSet
        End Try

    End Function
    Public Sub UpdateInformationProblemHistoryDB(ByVal aInformationTechnologyProblemDataSet As InformationTechnologyProblemDataSet)

        Try
            'Setting to update the problem data set
            aInformationTechnologyProblemDataSetTableAdapter.Update(aInformationTechnologyProblemDataSet.informationtechnologyproblem)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Function GetInformationTechnologyInspectionInformation() As InformationTechnologyInspectionDataSet

        Try

            'Setting up Inspection Data Set
            aInformationTechnologyInspectionDataSet = New InformationTechnologyInspectionDataSet
            aInformationTechnologyInspectionDataSetTableAdapter = New InformationTechnologyInspectionDataSetTableAdapters.informationtechnologyinspectionTableAdapter
            aInformationTechnologyInspectionDataSetTableAdapter.Fill(aInformationTechnologyInspectionDataSet.informationtechnologyinspection)
            Return aInformationTechnologyInspectionDataSet

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return aInformationTechnologyInspectionDataSet
        End Try

    End Function
    Public Sub UpdateInformationInspectionHistoryDB(ByVal aInformationTechnologyInspectionDataSet As InformationTechnologyInspectionDataSet)

        Try
            'Updating the Inspection Data Set
            aInformationTechnologyInspectionDataSetTableAdapter.Update(aInformationTechnologyInspectionDataSet.informationtechnologyinspection)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Function GetInformationTechnologyHistoryInformation() As InformationTechnologyHistoryDataSet

        Try

            'Getting history information
            aInformationTechnologyHistoryDataSet = New InformationTechnologyHistoryDataSet
            aInformationTechnologyHistoryDataSetTableAdapter = New InformationTechnologyHistoryDataSetTableAdapters.informationtechnologyhistoryTableAdapter
            aInformationTechnologyHistoryDataSetTableAdapter.Fill(aInformationTechnologyHistoryDataSet.informationtechnologyhistory)
            Return aInformationTechnologyHistoryDataSet

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return aInformationTechnologyHistoryDataSet
        End Try

    End Function
    Public Sub UpdateInformationTechnologyHistoryDB(ByVal aInformationTechnologyHistoryDataSet As InformationTechnologyHistoryDataSet)

        Try
            'Updating the History Data Set
            aInformationTechnologyHistoryDataSetTableAdapter.Update(aInformationTechnologyHistoryDataSet.informationtechnologyhistory)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Function GetInformationTechnologyIDInformation() As InformationTechnologyIDDataSet

        Try

            'Getting the ID Information
            aInformationTechnologyIDDataSet = New InformationTechnologyIDDataSet
            aInformationTechnologyIDDataSetTableAdapter = New InformationTechnologyIDDataSetTableAdapters.informationtechnologyidTableAdapter
            aInformationTechnologyIDDataSetTableAdapter.Fill(aInformationTechnologyIDDataSet.informationtechnologyid)
            Return aInformationTechnologyIDDataSet

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return aInformationTechnologyIDDataSet
        End Try

    End Function
    Public Sub UpdateInformationTechnologyIDDB(ByVal aInformationTechnologyIDDataSet As InformationTechnologyIDDataSet)

        Try
            'Updating the ID data set
            aInformationTechnologyIDDataSetTableAdapter.Update(aInformationTechnologyIDDataSet.informationtechnologyid)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Function GetInformationTechnologyDevicesInformation() As InformationTechnologyDevicesDataSet

        Try

            'Getting Device Information
            aInformationTechnologyDevicesDataSet = New InformationTechnologyDevicesDataSet
            aInformationTechnologyDevicesDataSetTableAdapter = New InformationTechnologyDevicesDataSetTableAdapters.informationtechnologydevicesTableAdapter
            aInformationTechnologyDevicesDataSetTableAdapter.Fill(aInformationTechnologyDevicesDataSet.informationtechnologydevices)
            Return aInformationTechnologyDevicesDataSet

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return aInformationTechnologyDevicesDataSet
        End Try

    End Function
    Public Sub UpdateInformationTechnologyDevicesDB(ByVal aInformationTechnologyDevicesDataSet As InformationTechnologyDevicesDataSet)

        Try
            'Setting up the Devices
            aInformationTechnologyDevicesDataSetTableAdapter.Update(aInformationTechnologyDevicesDataSet.informationtechnologydevices)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

End Class
