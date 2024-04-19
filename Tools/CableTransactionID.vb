'Title:         Cable Transaction ID
'Date:          1/2/14
'Author:        Terry Holmes

'Description:   This form creates the transaction ID for all cable transactions

Option Strict On

Public Class CableTransactionID

    Private TheCableTransactionIDDataSet As CableTransactionIDDataSet
    Private TheCableTransactionIDDataTier As CableIDDataTier
    Private WithEvents TheCableTransactionIDBindingSource As BindingSource

    Private Sub CableTransactionID_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Setting Local Variables
        Dim intNewID As Integer

        'Using a Try Catch to catch illegal exceptions
        Try

            'This will bind the controls to the data source
            TheCableTransactionIDDataTier = New CableIDDataTier
            TheCableTransactionIDDataSet = TheCableTransactionIDDataTier.GetCableTransactionIDInformation
            TheCableTransactionIDBindingSource = New BindingSource

            'Setting Combobox binding to the dataset
            With TheCableTransactionIDBindingSource
                .DataSource = TheCableTransactionIDDataSet
                .DataMember = "cabletransactionid"
                .MoveFirst()
                .MoveLast()
            End With

            'Setting the combobox to the table
            With cboTransactionID
                .DataSource = TheCableTransactionIDBindingSource
                .DisplayMember = "TransactionID"
                .DataBindings.Add("text", TheCableTransactionIDBindingSource, "TransactionID", False, DataSourceUpdateMode.Never)
            End With

            'Binding the textbox
            txtReelTransactionID.DataBindings.Add("text", TheCableTransactionIDBindingSource, "ReelTransactionID")

            'creating the new ID
            intNewID = CInt(txtReelTransactionID.Text)
            intNewID += 1
            Logon.mintReelTransactionID = intNewID
            txtReelTransactionID.Text = CStr(intNewID)

            'Updating the Dataset
            TheCableTransactionIDBindingSource.EndEdit()
            TheCableTransactionIDDataTier.UpdateCableTransactionIDDB(TheCableTransactionIDDataSet)

            'Closing the form
            Me.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class