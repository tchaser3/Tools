'Title:         Cable Data Tier
'Date:          12/26/13
'Author:        Terry Holmes

'Description:   This is the cable data tier

Option Strict On

Public Class CableDataTier

    'Setting Up Cable Type Modular Variables
    Private aCoaxTableAdapter As CoaxDataSetTableAdapters.coaxTableAdapter
    Private aCoaxDataSet As CoaxDataSet

    Private aFiberTableAdapter As FiberDataSetTableAdapters.fiberTableAdapter
    Private aFiberDataSet As FiberDataSet

    Private aDropCableTableAdapter As DropCableDataSetTableAdapters.dropcableTableAdapter
    Private aDropCableDataSet As DropCableDataSet

    Private aTwistedPairTableAdapter As TwistedPairDataSetTableAdapters.twistedpairTableAdapter
    Private aTwistedPairDataSet As TwistedPairDataSet

    Private aSpecialityCableTableAdapter As SpecialityCableDataSetTableAdapters.specialitycableTableAdapter
    Private aSpecialityCableDataSet As SpecialityCableDataSet

    Private aReceiveCableTableAdapter As ReceiveCableDataSetTableAdapters.receivecableTableAdapter
    Private aReceiveCableDataSet As ReceiveCableDataSet

    Private aTransferCableTableAdapter As TransferCableDataSetTableAdapters.transfercablewarehouseTableAdapter
    Private aTransferCableDataSet As TransferCableDataSet

    Private aIssueCableTableAdapter As IssueCableDataSetTableAdapters.issuecableTableAdapter
    Private aIssueCableDataSet As IssueCableDataSet

    Private aManagerQueueDataSetTableAdapter As ManagerQueueDataSetTableAdapters.managerqueueTableAdapter
    Private aManagerQueueDataSet As ManagerQueueDataSet

    Private aReturnCableReelDataSetTableAdapter As ReturnCableReelDataSetTableAdapters.ReturnCableReelTableAdapter
    Private aReturnCableReelDataSet As ReturnCableReelDataSet

    Private aCableUsageDataSetTableAdapter As CableUsageDataSetTableAdapters.cableusageTableAdapter
    Private aCableUsageDataSet As CableUsageDataSet

    Private aAdjustCableReelDataSetTableAdapter As AdjustCableReelDataSetTableAdapters.adjustcablereelTableAdapter
    Private aAdjustCableReelDataSet As AdjustCableReelDataSet

    Private aVoidCableIssueDataSetTableAdapter As VoidCableIssueDataSetTableAdapters.voidcableissueTableAdapter
    Private aVoidCableIssueDataSet As VoidCableIssueDataSet

    Private aHandCoilTransactionIDDataSetTableAdapter As HandCoilTransactionIDDataSetTableAdapters.handcoiltransactionidTableAdapter
    Private aHandCoilTransactionIDDataSet As HandCoilTransactionIDDataSet

    Private aReceiveHandCoilDataSetTableAdapter As ReceiveHandCoilDataSetTableAdapters.receivehandcoilTableAdapter
    Private aReceiveHandCoilDataSet As ReceiveHandCoilDataSet

    Private aCreateHandCoilIDDataSetTableAdapter As CreateHandCoilIDDataSetTableAdapters.createhandcoilidTableAdapter
    Private aCreateHandCoilIDDataSet As CreateHandCoilIDDataSet

    Public Function GetCreateHandCoilIDInformation() As CreateHandCoilIDDataSet

        'Setting up this Function of the Data Tier
        Try

            aCreateHandCoilIDDataSet = New CreateHandCoilIDDataSet
            aCreateHandCoilIDDataSetTableAdapter = New CreateHandCoilIDDataSetTableAdapters.createhandcoilidTableAdapter
            aCreateHandCoilIDDataSetTableAdapter.Fill(aCreateHandCoilIDDataSet.createhandcoilid)
            Return aCreateHandCoilIDDataSet

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Please Check", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return aCreateHandCoilIDDataSet

        End Try

    End Function
    Public Sub UpdateCreateHandCoilIDDB(ByVal aCreateHandCoilIDDataSet As CreateHandCoilIDDataSet)

        Try

            aCreateHandCoilIDDataSetTableAdapter.Update(aCreateHandCoilIDDataSet.createhandcoilid)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Fix", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    Public Function GetReceiveHandCoilInformation() As ReceiveHandCoilDataSet

        'Setting up this Function of the Data Tier
        Try

            aReceiveHandCoilDataSet = New ReceiveHandCoilDataSet
            aReceiveHandCoilDataSetTableAdapter = New ReceiveHandCoilDataSetTableAdapters.receivehandcoilTableAdapter
            aReceiveHandCoilDataSetTableAdapter.Fill(aReceiveHandCoilDataSet.receivehandcoil)
            Return aReceiveHandCoilDataSet

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Please Check", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return aReceiveHandCoilDataSet

        End Try

    End Function
    Public Sub UpdateReceiveHandCoilDB(ByVal aReceiveHandCoilDataSet As ReceiveHandCoilDataSet)

        Try

            aReceiveHandCoilDataSetTableAdapter.Update(aReceiveHandCoilDataSet.receivehandcoil)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Fix", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Function GetHandCoilTransactionIDInformation() As HandCoilTransactionIDDataSet

        'Setting up this Function of the Data Tier
        Try

            aHandCoilTransactionIDDataSet = New HandCoilTransactionIDDataSet
            aHandCoilTransactionIDDataSetTableAdapter = New HandCoilTransactionIDDataSetTableAdapters.handcoiltransactionidTableAdapter
            aHandCoilTransactionIDDataSetTableAdapter.Fill(aHandCoilTransactionIDDataSet.handcoiltransactionid)
            Return aHandCoilTransactionIDDataSet

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Please Check", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return aHandCoilTransactionIDDataSet

        End Try
    End Function

    Public Sub UpdateHandCoilTransactionIDDB(ByVal aHandCoilTransactionIDDataSet As HandCoilTransactionIDDataSet)

        Try

            aHandCoilTransactionIDDataSetTableAdapter.Update(aHandCoilTransactionIDDataSet.handcoiltransactionid)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Fix", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Function GetVoidCableIssueInformation() As VoidCableIssueDataSet

        'Setting up this Function of the Data Tier
        Try

            aVoidCableIssueDataSet = New VoidCableIssueDataSet
            aVoidCableIssueDataSetTableAdapter = New VoidCableIssueDataSetTableAdapters.voidcableissueTableAdapter
            aVoidCableIssueDataSetTableAdapter.Fill(aVoidCableIssueDataSet.voidcableissue)
            Return aVoidCableIssueDataSet

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Please Check", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return aVoidCableIssueDataSet

        End Try
    End Function

    Public Sub UpdateVoidCableIssueDB(ByVal aVoidCableIssueDataSet As VoidCableIssueDataSet)

        Try

            aVoidCableIssueDataSetTableAdapter.Update(aVoidCableIssueDataSet.voidcableissue)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Fix", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Function GetAdjustCableReelInformation() As AdjustCableReelDataSet

        'Setting up this Function of the Data Tier
        Try

            aAdjustCableReelDataSet = New AdjustCableReelDataSet
            aAdjustCableReelDataSetTableAdapter = New AdjustCableReelDataSetTableAdapters.adjustcablereelTableAdapter
            aAdjustCableReelDataSetTableAdapter.Fill(aAdjustCableReelDataSet.adjustcablereel)
            Return aAdjustCableReelDataSet

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Please Check", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return aAdjustCableReelDataSet

        End Try
    End Function

    Public Sub UpdateAdjustCableReelDB(ByVal aAdjustCableReelDataSet As AdjustCableReelDataSet)

        Try

            aAdjustCableReelDataSetTableAdapter.Update(aAdjustCableReelDataSet.adjustcablereel)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Fix", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Function GetCableUsageInformation() As CableUsageDataSet

        'Setting up this Function of the Data Tier
        Try

            aCableUsageDataSet = New CableUsageDataSet
            aCableUsageDataSetTableAdapter = New CableUsageDataSetTableAdapters.cableusageTableAdapter
            aCableUsageDataSetTableAdapter.Fill(aCableUsageDataSet.cableusage)
            Return aCableUsageDataSet

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Please Check", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return aCableUsageDataSet

        End Try
    End Function

    Public Sub UpdateCableUsageDB(ByVal aCableUsageDataSet As CableUsageDataSet)

        Try

            aCableUsageDataSetTableAdapter.Update(aCableUsageDataSet.cableusage)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Fix", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Function GetReturnCableReelInformation() As ReturnCableReelDataSet

        'Setting up this Function of the Data Tier
        Try

            aReturnCableReelDataSet = New ReturnCableReelDataSet
            aReturnCableReelDataSetTableAdapter = New ReturnCableReelDataSetTableAdapters.ReturnCableReelTableAdapter
            aReturnCableReelDataSetTableAdapter.Fill(aReturnCableReelDataSet.ReturnCableReel)
            Return aReturnCableReelDataSet

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Please Check", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return aReturnCableReelDataSet

        End Try
    End Function

    Public Sub UpdateReturnCableReelDB(ByVal aReturnCableReelDataSet As ReturnCableReelDataSet)

        Try

            aReturnCableReelDataSetTableAdapter.Update(aReturnCableReelDataSet.ReturnCableReel)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Fix", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Function GetManagerQueueInformation() As ManagerQueueDataSet

        'Setting up this Function of the Data Tier
        Try

            aManagerQueueDataSet = New ManagerQueueDataSet
            aManagerQueueDataSetTableAdapter = New ManagerQueueDataSetTableAdapters.managerqueueTableAdapter
            aManagerQueueDataSetTableAdapter.Fill(aManagerQueueDataSet.managerqueue)
            Return aManagerQueueDataSet

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Please Check", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return aManagerQueueDataSet

        End Try
    End Function

    Public Sub UpdateManagerQueueDB(ByVal aManagerQueueDataSet As ManagerQueueDataSet)

        Try

            aManagerQueueDataSetTableAdapter.Update(aManagerQueueDataSet.managerqueue)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Fix", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Function GetIssueCableInformation() As IssueCableDataSet

        'Setting up this Function of the Data Tier
        Try

            aIssueCableDataSet = New IssueCableDataSet
            aIssueCableTableAdapter = New IssueCableDataSetTableAdapters.issuecableTableAdapter
            aIssueCableTableAdapter.Fill(aIssueCableDataSet.issuecable)
            Return aIssueCableDataSet

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Please Check", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return aIssueCableDataSet

        End Try
    End Function

    Public Sub UpdateIssueCableDB(ByVal aIssueCableDataSet As IssueCableDataSet)

        Try

            aIssueCableTableAdapter.Update(aIssueCableDataSet.issuecable)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Fix", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Function GetTransferCableInformation() As TransferCableDataSet

        'Setting up this Function of the Data Tier
        Try

            aTransferCableDataSet = New TransferCableDataSet
            aTransferCableTableAdapter = New TransferCableDataSetTableAdapters.transfercablewarehouseTableAdapter
            aTransferCableTableAdapter.Fill(aTransferCableDataSet.transfercablewarehouse)
            Return aTransferCableDataSet

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Please Check", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return aTransferCableDataSet

        End Try
    End Function

    Public Sub UpdateTransferCableDB(ByVal aTransferCableDataSet As TransferCableDataSet)

        Try

            aTransferCableTableAdapter.Update(aTransferCableDataSet.transfercablewarehouse)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Fix", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Function GetReceiveCableInformation() As ReceiveCableDataSet

        'Setting up this Function of the Data Tier
        Try

            aReceiveCableDataSet = New ReceiveCableDataSet
            aReceiveCableTableAdapter = New ReceiveCableDataSetTableAdapters.receivecableTableAdapter
            aReceiveCableTableAdapter.Fill(aReceiveCableDataSet.receivecable)
            Return aReceiveCableDataSet

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Please Check", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return aReceiveCableDataSet

        End Try
    End Function

    Public Sub UpdateReceiveCableDB(ByVal aReceiveCableDataSet As ReceiveCableDataSet)

        Try

            aReceiveCableTableAdapter.Update(aReceiveCableDataSet.receivecable)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Fix", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Function GetSpecialityCableInformation() As SpecialityCableDataSet

        'Setting up this Function of the Data Tier
        Try

            aSpecialityCableDataSet = New SpecialityCableDataSet
            aSpecialityCableTableAdapter = New SpecialityCableDataSetTableAdapters.specialitycableTableAdapter
            aSpecialityCableTableAdapter.Fill(aSpecialityCableDataSet.specialitycable)
            Return aSpecialityCableDataSet

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Please Check", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return aSpecialityCableDataSet

        End Try
    End Function

    Public Sub UpdateSpecialityCableDB(ByVal aSpecialityCableDataSet As SpecialityCableDataSet)

        Try

            aSpecialityCableTableAdapter.Update(aSpecialityCableDataSet.specialitycable)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Fix", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Function GetTwistedPairInformation() As TwistedPairDataSet

        'Setting up this Function of the Data Tier
        Try

            aTwistedPairDataSet = New TwistedPairDataSet
            aTwistedPairTableAdapter = New TwistedPairDataSetTableAdapters.twistedpairTableAdapter
            aTwistedPairTableAdapter.Fill(aTwistedPairDataSet.twistedpair)
            Return aTwistedPairDataSet

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Please Check", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return aTwistedPairDataSet

        End Try
    End Function

    Public Sub UpdateTwistedPairDB(ByVal aTwistedPairDataSet As TwistedPairDataSet)

        Try

            aTwistedPairTableAdapter.Update(aTwistedPairDataSet.twistedpair)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Fix", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Function GetDropCableInformation() As DropCableDataSet

        'Setting up this Function of the Data Tier
        Try

            aDropCableDataSet = New DropCableDataSet
            aDropCableTableAdapter = New DropCableDataSetTableAdapters.dropcableTableAdapter
            aDropCableTableAdapter.Fill(aDropCableDataSet.dropcable)
            Return aDropCableDataSet

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Please Check", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return aDropCableDataSet

        End Try
    End Function

    Public Sub UpdateDropCableDB(ByVal aDropCableDataSet As DropCableDataSet)

        Try

            aDropCableTableAdapter.Update(aDropCableDataSet.dropcable)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Fix", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Function GetFiberInformation() As FiberDataSet

        'Setting up this Function of the Data Tier
        Try

            aFiberDataSet = New FiberDataSet
            aFiberTableAdapter = New FiberDataSetTableAdapters.fiberTableAdapter
            aFiberTableAdapter.Fill(aFiberDataSet.fiber)
            Return aFiberDataSet

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Please Check", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return aFiberDataSet

        End Try
    End Function

    Public Sub UpdateFiberDB(ByVal aFiberDataSet As FiberDataSet)

        Try

            aFiberTableAdapter.Update(aFiberDataSet.fiber)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Fix", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Function GetCoaxInformation() As CoaxDataSet

        'Setting up this Function of the Data Tier
        Try

            aCoaxDataSet = New CoaxDataSet
            aCoaxTableAdapter = New CoaxDataSetTableAdapters.coaxTableAdapter
            aCoaxTableAdapter.Fill(aCoaxDataSet.coax)
            Return aCoaxDataSet

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Please Check", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return aCoaxDataSet

        End Try
    End Function

    Public Sub UpdateCoaxDB(ByVal aCoaxDataSet As CoaxDataSet)

        Try

            aCoaxTableAdapter.Update(aCoaxDataSet.coax)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Fix", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
End Class
