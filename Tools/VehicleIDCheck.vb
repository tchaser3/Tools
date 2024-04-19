'Title:     Vehicle ID Check
'Date:      7-12-13
'Author:    Terry Holmes

Option Strict On

Public Class VehicleIDCheck

    'Creating Modular Variables
    Private TheVehicleIDCheckDataSet As VehicleIDCheckDataSet
    Private TheVehicleIDCheckDataTier As VehicleIDCheckDataTier
    Private WithEvents TheVehicleIDCheckBindingSource As BindingSource

    Private addingBoolean As Boolean = False
    Private editingBoolean As Boolean = False
    Private previousSelectedIndex As Integer
    Dim mintNumuberOfRecords As Integer

    Dim LogDateTime As Date = DateAndTime.Now
    Dim strLogDateTime As String

    'Setting a global variable
    Friend mintCreatedVehicleID As Integer

    Private Sub VehicleIDCheck_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'This subroutine runs when the form is loaded

        'Setting Local Variables
        Dim intNumberOfRecords As Integer

        'Running a Try Catch to catch exceptions
        Try

            'This will bind the controls to the data source
            TheVehicleIDCheckDataTier = New VehicleIDCheckDataTier
            TheVehicleIDCheckDataSet = TheVehicleIDCheckDataTier.GetVehicleIDInformation
            TheVehicleIDCheckBindingSource = New BindingSource

            'Setting the combobox data binding
            With TheVehicleIDCheckBindingSource
                .DataSource = TheVehicleIDCheckDataSet
                .DataMember = "vehiclesidcheck"
                .MoveFirst()
                .MoveLast()
            End With

            'Setting up the combobox-table relationship
            With cboTransactionID
                .DataSource = TheVehicleIDCheckBindingSource
                .DisplayMember = "TransactionID"
                .DataBindings.Add("text", TheVehicleIDCheckBindingSource, "TransactionID", False, DataSourceUpdateMode.Never)
            End With

            'Binding the textbox with the table
            txtVehicleID.DataBindings.Add("text", TheVehicleIDCheckBindingSource, "VehicleID")
        Catch
            MessageBox.Show("There is a problem with the form loading", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        'Beginning the part of the routine to add the record to the ID Table


        Try

            intNumberOfRecords = CInt(txtVehicleID.Text)
            intNumberOfRecords += 1
            txtVehicleID.Text = CStr(intNumberOfRecords)
            Logon.mintVehicleID = CInt(intNumberOfRecords)

            'Adding the record into the table
            TheVehicleIDCheckBindingSource.EndEdit()
            TheVehicleIDCheckDataTier.UpdateDB(TheVehicleIDCheckDataSet)

            'Closing the form
            Me.Close()

        Catch ex As Exception

        End Try
    End Sub
    Private Sub setComboBoxBinding()

        'Setting the combobox binding
        With Me.cboTransactionID
            If (addingBoolean Or editingBoolean) Then
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.OnValidation
                .DropDownStyle = ComboBoxStyle.Simple
            Else
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.Never
                .DropDownStyle = ComboBoxStyle.DropDownList
            End If
        End With

    End Sub
End Class