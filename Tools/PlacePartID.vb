'Title:         Place Part ID and Reel in Cable Tables
'Date:          9-10-14
'Author:        Terry Holmes

'Description:   This form will load the Part ID and Reel into existing cable tables

Option Strict On

Public Class PlacePartID

    'Setting Modular Variables

    'Setting Variables for the Cable Type Boxes
    Dim TheInputDataValidation As New InputDataValidation

    'Setting up the cable global controls
    Private ThePartNumberDataSet As PartNumberDataSet
    Private ThePartNumberDataTier As PartDataTier
    Private WithEvents ThePartNumberBindingSource As BindingSource

    Private TheCoaxDataSet As CoaxDataSet
    Private TheCoaxDataTier As CableDataTier
    Private WithEvents TheCoaxBindingSource As BindingSource

    Private TheDropCableDataSet As DropCableDataSet
    Private TheDropCableDataTier As CableDataTier
    Private WithEvents TheDropCableBindingSource As BindingSource

    Private TheFiberDataSet As FiberDataSet
    Private TheFiberDataTier As CableDataTier
    Private WithEvents TheFiberBindingSource As BindingSource

    Private TheSpecialtyCableDataSet As SpecialityCableDataSet
    Private TheSpecialtyCableDataTier As CableDataTier
    Private WithEvents TheSpecialtyCableBindingSource As BindingSource

    Private TheTwistedPairDataSet As TwistedPairDataSet
    Private TheTwistedPairDataTier As CableDataTier
    Private WithEvents TheTwistedPairBindingSource As BindingSource

    Private addingBoolean As Boolean = False
    Private editingBoolean As Boolean = False
    Private previousSelectedIndex As Integer
    Dim mintNumuberOfRecords As Integer

    Dim LogDateTime As Date = DateAndTime.Now
    Dim strLogDateTime As String

    Private Sub btnAdministrativeMenu_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdministrativeMenu.Click

        AdministrativeMenu.Show()
        Me.Close()

    End Sub

    Private Sub btnCableAdminMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCableAdminMenu.Click

        CableAdministrationMenu.Show()
        Me.Close()

    End Sub

    Private Sub btnMainMenu_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMainMenu.Click

        MainMenu.Show()
        Me.Close()

    End Sub

    Private Sub btnClose_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        'Closes the Program
        CloseTheProgram.ShowDialog()
        ClearCableDataBindings()
        ClearPartDataBindings()

    End Sub
    Private Sub ClearPartDataBindings()

        'Clears the Part Data bindings
        cboPartID.DataBindings.Clear()
        txtPartNumber.DataBindings.Clear()
    End Sub
    Private Sub ClearCableDataBindings()

        'Clears the Data Bindings for the Cable Controls
        cboReelTransactionID.DataBindings.Clear()
        txtCablePartID.DataBindings.Clear()
        txtCablePartNumber.DataBindings.Clear()
        txtCableReelOrHandCoil.DataBindings.Clear()

    End Sub

    Private Sub PlacePartID_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'This will load up the Part Number information
        Try

            'Setting up the Part Number Global Variabes
            ThePartNumberDataTier = New PartDataTier
            ThePartNumberDataSet = ThePartNumberDataTier.GetPartNumberInformation
            ThePartNumberBindingSource = New BindingSource

            'Setting up the binding Source
            With ThePartNumberBindingSource
                .DataSource = ThePartNumberDataSet
                .DataMember = "partnumbers"
                .MoveFirst()
                .MoveLast()
            End With

            'Set the combo box
            With cboPartID
                .DataSource = ThePartNumberBindingSource
                .DisplayMember = "PartID"
                .DataBindings.Add("text", ThePartNumberBindingSource, "PartID", False, DataSourceUpdateMode.Never)
            End With

            'Setting the rest of the part number controls
            txtPartNumber.DataBindings.Add("text", ThePartNumberBindingSource, "PartNumber")

        Catch ex As Exception
            MessageBox.Show(ex.Message, "There is a problem", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub SetDropCableDataBindings()

        'This will set the Coax Data Bindings
        Try

            TheDropCableDataTier = New CableDataTier
            TheDropCableDataSet = TheDropCableDataTier.GetDropCableInformation
            TheDropCableBindingSource = New BindingSource

            'Setting up the binding source
            With TheDropCableBindingSource
                .DataSource = TheDropCableDataSet
                .DataMember = "dropcable"
                .MoveFirst()
                .MoveLast()
            End With

            With cboReelTransactionID
                .DataSource = TheDropCableBindingSource
                .DisplayMember = "ReelTransactionID"
                .DataBindings.Add("text", TheDropCableBindingSource, "ReelTransactionID", False, DataSourceUpdateMode.Never)
            End With

            'Setting the rest of the controls
            txtCablePartID.DataBindings.Add("text", TheDropCableBindingSource, "PartID")
            txtCablePartNumber.DataBindings.Add("text", TheDropCableBindingSource, "PartNumber")
            txtCableReelOrHandCoil.DataBindings.Add("text", TheDropCableBindingSource, "ReelorHC")

        Catch ex As Exception
            'This message box will be displayed if there is an error
            MessageBox.Show(ex.Message, "There is a Problem", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub SetCoaxDataBindings()

        'This will set the Coax Data Bindings
        Try

            TheCoaxDataTier = New CableDataTier
            TheCoaxDataSet = TheCoaxDataTier.GetCoaxInformation
            TheCoaxBindingSource = New BindingSource

            'Setting up the binding source
            With TheCoaxBindingSource
                .DataSource = TheCoaxDataSet
                .DataMember = "coax"
                .MoveFirst()
                .MoveLast()
            End With

            With cboReelTransactionID
                .DataSource = TheCoaxBindingSource
                .DisplayMember = "ReelTransactionID"
                .DataBindings.Add("text", TheCoaxBindingSource, "ReelTransactionID", False, DataSourceUpdateMode.Never)
            End With

            'Setting the rest of the controls
            txtCablePartID.DataBindings.Add("text", TheCoaxBindingSource, "PartID")
            txtCablePartNumber.DataBindings.Add("text", TheCoaxBindingSource, "PartNumber")
            txtCableReelOrHandCoil.DataBindings.Add("text", TheCoaxBindingSource, "ReelorHC")

        Catch ex As Exception
            'This message box will be displayed if there is an error
            MessageBox.Show(ex.Message, "There is a Problem", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub SetFiberDataBindings()

        'This will set the Coax Data Bindings
        Try

            TheFiberDataTier = New CableDataTier
            TheFiberDataSet = TheFiberDataTier.GetFiberInformation
            TheFiberBindingSource = New BindingSource

            'Setting up the binding source
            With TheFiberBindingSource
                .DataSource = TheFiberDataSet
                .DataMember = "fiber"
                .MoveFirst()
                .MoveLast()
            End With

            With cboReelTransactionID
                .DataSource = TheFiberBindingSource
                .DisplayMember = "ReelTransactionID"
                .DataBindings.Add("text", TheFiberBindingSource, "ReelTransactionID", False, DataSourceUpdateMode.Never)
            End With

            'Setting the rest of the controls
            txtCablePartID.DataBindings.Add("text", TheFiberBindingSource, "PartID")
            txtCablePartNumber.DataBindings.Add("text", TheFiberBindingSource, "PartNumber")
            txtCableReelOrHandCoil.DataBindings.Add("text", TheFiberBindingSource, "ReelorHC")

        Catch ex As Exception
            'This message box will be displayed if there is an error
            MessageBox.Show(ex.Message, "There is a Problem", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnRunUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRunUpdate.Click
        SetFiberDataBindings()

    End Sub
End Class