'Title:         Cable ID Data Tier
'Date:          12/26/13
'Author:        Terry Holmes

'Description:   This Data Tier is for all of the ID Generation of the cables

Option Strict On

Public Class CableIDDataTier

    'Setting Up Cable Type Modular Variables

    Private aCableTransactionIDTableAdapter As CableTransactionIDDataSetTableAdapters.cabletransactionidTableAdapter
    Private aCableTransactionIDDataSet As CableTransactionIDDataSet

    Private aReelIDTableAdapter As ReelIDDataSetTableAdapters.reelidTableAdapter
    Private aReelIDDataSet As ReelIDDataSet

    Public Function GetReelIDInformation() As ReelIDDataSet

        'Setting up this Function of the Data Tier
        Try

            aReelIDDataSet = New ReelIDDataSet
            aReelIDTableAdapter = New ReelIDDataSetTableAdapters.reelidTableAdapter
            aReelIDTableAdapter.Fill(aReelIDDataSet.reelid)
            Return aReelIDDataSet

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Please Check", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return aReelIDDataSet

        End Try
    End Function

    Public Sub UpdateReelIDDB(ByVal aReelIDDataSet As ReelIDDataSet)

        Try

            aReelIDTableAdapter.Update(aReelIDDataSet.reelid)

        Catch ex As Exception

        End Try

    End Sub

    Public Function GetCableTransactionIDInformation() As CableTransactionIDDataSet

        'Setting up this Function of the Data Tier
        Try

            aCableTransactionIDDataSet = New CableTransactionIDDataSet
            aCableTransactionIDTableAdapter = New CableTransactionIDDataSetTableAdapters.cabletransactionidTableAdapter
            aCableTransactionIDTableAdapter.Fill(aCableTransactionIDDataSet.cabletransactionid)
            Return aCableTransactionIDDataSet

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Please Check", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return aCableTransactionIDDataSet

        End Try
    End Function

    Public Sub UpdateCableTransactionIDDB(ByVal aCableTransactionIDDataSet As CableTransactionIDDataSet)

        Try

            aCableTransactionIDTableAdapter.Update(aCableTransactionIDDataSet.cabletransactionid)

        Catch ex As Exception

        End Try

    End Sub

End Class
