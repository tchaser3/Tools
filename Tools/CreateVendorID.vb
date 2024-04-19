'Title:         Create VendorID
'Date:          11-10-14
'Author:        Terry Holmes

'Description:   This Form is used to create a new vendor id

Option Strict On

Public Class CreateVendorID

    'Setting up the Global Data Set variables
    Private TheVendorIDDataSet As VendorIDDataSet
    Private TheVendorIDDataTier As VendorDataTier
    Private WithEvents TheVendorIDBindingSource As BindingSource

    Private Sub CreateVendorID_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'setting local variables
        Dim intNewID As Integer

        'Try Catch to load the form
        Try

            'Setting up the data sets
            TheVendorIDDataTier = New VendorDataTier
            TheVendorIDDataSet = TheVendorIDDataTier.GetVendorIDinformation
            TheVendorIDBindingSource = New BindingSource

            'Setting up the binding source 
            With TheVendorIDBindingSource
                .DataSource = TheVendorIDDataSet
                .DataMember = "vendorid"
                .MoveLast()
                .MoveLast()
            End With

            'Setting up the combo box
            With cboTransactionID
                .DataSource = TheVendorIDBindingSource
                .DisplayMember = "TransactionID"
                .DataBindings.Add("text", TheVendorIDBindingSource, "TransactionID", False, DataSourceUpdateMode.Never)
            End With

            'Binding the rest of the controls
            txtVehicleID.DataBindings.Add("text", TheVendorIDBindingSource, "VendorID")

            'creating the new id
            intNewID = CInt(txtVehicleID.Text)
            intNewID += 1
            Logon.mintCreatedTransactionID = intNewID
            txtVehicleID.Text = CStr(intNewID)

            TheVendorIDBindingSource.EndEdit()
            TheVendorIDDataTier.UpdateVendorIDDB(TheVendorIDDataSet)

            Me.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
End Class