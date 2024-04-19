'Title:         Auto Vehicle Signed Out Sheet
'Date:          10-15-15
'Author:        Terry Holmes

'Description:   This form is used to make an entry in the auto signed out table

Option Strict On

Public Class AutoVehicleSignedOutSheet

    'Setting Modular Variables
    Private TheVehicleSignedOutDataSet As VehicleSignedOutDataSet
    Private TheVehicleSignedOutDataTier As VehicleSignedOutDataTier
    Private WithEvents TheVehicleSignedOutBindingSource As BindingSource

    Dim TheInputDataValidation As New InputDataValidation

    Private addingBoolean As Boolean = False
    Private editingBoolean As Boolean = False
    Private previousSelectedIndex As Integer
    Dim mintNumuberOfRecords As Integer

    Dim LogDateTime As Date = DateAndTime.Now
    Dim strLogDateTime As String

    Dim mintCreatedTransactionID As Integer

    Private Sub setComboBoxBinding()

        'Sets the Combobox Binding
        With cboTransactionID
            If (addingBoolean Or editingBoolean) Then
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.OnValidation
                .DropDownStyle = ComboBoxStyle.Simple
            Else
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.Never
                .DropDownStyle = ComboBoxStyle.DropDownList
            End If
        End With

    End Sub

    Private Sub AutoVehicleSignedOutSheet_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try

            'This will bind the controls to the data source
            TheVehicleSignedOutDataTier = New VehicleSignedOutDataTier
            TheVehicleSignedOutDataSet = TheVehicleSignedOutDataTier.GetVehicleSignedOutInformation
            TheVehicleSignedOutBindingSource = New BindingSource

            'Setting up the binding for the Combobox
            With TheVehicleSignedOutBindingSource
                .DataSource = TheVehicleSignedOutDataSet
                .DataMember = "vehiclesignedout"
                .MoveFirst()
                .MoveLast()
            End With

            'Setting up the Table Relationships and binding for the table.
            With cboTransactionID
                .DataSource = TheVehicleSignedOutBindingSource
                .DisplayMember = "TransactionID"
                .DataBindings.Add("text", TheVehicleSignedOutBindingSource, "TransactionID", False, DataSourceUpdateMode.Never)
            End With

            'Setting up the data bindings for the textboxes
            txtBJCNumber.DataBindings.Add("text", TheVehicleSignedOutBindingSource, "BJCNumber")
            txtDate.DataBindings.Add("text", TheVehicleSignedOutBindingSource, "Date")
            txtVehicleSignOutSheetSigned.DataBindings.Add("text", TheVehicleSignedOutBindingSource, "VehicleSignedOut")

            'Placing the Binding Source to Add a record
            With TheVehicleSignedOutBindingSource
                .EndEdit()
                .AddNew()
            End With

            'Calling routines and setting the values
            addingBoolean = True
            setComboBoxBinding()
            cboTransactionID.Focus()
            If cboTransactionID.SelectedIndex <> -1 Then
                previousSelectedIndex = cboTransactionID.Items.Count - 1
            Else
                previousSelectedIndex = 0
            End If

            VehicleSheetTurnInIDCreation.Show()

            mintCreatedTransactionID = CInt(Logon.mintCreatedTransactionID)

            cboTransactionID.Text = CStr(mintCreatedTransactionID)
            txtVehicleSignOutSheetSigned.Text = "YES"
            strLogDateTime = CStr(Logon.mdatDateForDataEntry)
            txtDate.Text = strLogDateTime
            txtBJCNumber.Text = CStr(Logon.mintBJCNumber)

            'updating the data base
            TheVehicleSignedOutBindingSource.EndEdit()
            TheVehicleSignedOutDataTier.UpdateDB(TheVehicleSignedOutDataSet)
            addingBoolean = False
            editingBoolean = False
            setComboBoxBinding()

            Me.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
End Class