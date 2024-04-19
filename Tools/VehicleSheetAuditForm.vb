'Title:         Vehicle Audit Report Form
'Date:          9/29/30
'Author:        Terry Holmes

'Description:   This form is used to perform the audit on the Vehicles.

Option Strict On

Public Class VehicleSheetAuditForm

    'Structure Variables
    Structure VehicleSheetAudit
        Dim strBJCNumber As String
        Dim strInspectionDate As String
        Dim strLastName As String
        Dim strFirstName As String
        Dim strDOTFormDone As String
        Dim strPPESheetDone As String
        Dim strVehicleSignOutSheet As String
    End Structure

    Dim mpmfVehicleAuditArray(10000) As VehicleSheetAudit
    Dim mintStructureCounter As Integer
    Dim mintBJCNumber As Integer

    'Setting up the Data Sets
    Private TheDailyVehicleInspectionDataSet As DailyVehicleInspectionDataSet
    Private TheDailyVehicleInspectionDataTier As DailyVehicleInspectionDataTier
    Private WithEvents TheDailyVehicleInspectionBindingSource As BindingSource

    Private TheVehicleInventorySheetDataSet As VehicleInventorySheetDataSet
    Private TheVehicleInventorySheetDataTier As VehicleInventorySheetDataTier
    Private WithEvents TheVehicleInventorySheetBindingSource As BindingSource

    Private TheVehicleSignedOutDataSet As VehicleSignedOutDataSet
    Private TheVehicleSignedOutDataTier As VehicleSignedOutDataTier
    Private WithEvents TheVehicleSignedOutBindingSource As BindingSource

    Private TheVehiclesDataSet As VehiclesDataSet
    Private TheVehiclesDataTier As VehiclesDataTier
    Private WithEvents TheVehiclesBindingSource As BindingSource

    Private TheEmployeeDataSet As EmployeeDataSet
    Private TheEmployeeDataTier As EmployeeDataTier
    Private WithEvents TheEmployeeBindingSource As BindingSource

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        'Closes the Program
        CloseTheProgram.ShowDialog()

    End Sub

    Private Sub btnInspectionMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInspectionMenu.Click

        'Opens the Tool Menu
        'ClearDataBindings()
        InspectionSearchMenu.Show()
        Me.Close()

    End Sub

    Private Sub btnMainMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMainMenu.Click

        'This opens the Main menu
        'ClearDataBindings()
        MainMenu.Show()
        Me.Close()

    End Sub

    Private Sub LoadTextBoxes()

        txtBJCNumber.Text = mpmfVehicleAuditArray(mintStructureCounter).strBJCNumber
        txtLastName.Text = mpmfVehicleAuditArray(mintStructureCounter ).strLastName
        txtFirstName.Text = mpmfVehicleAuditArray(mintStructureCounter).strFirstName
        txtDOTFormComplete.Text = mpmfVehicleAuditArray(mintStructureCounter).strDOTFormDone
        txtPPESheetComplete.Text = mpmfVehicleAuditArray(mintStructureCounter).strPPESheetDone
        txtVehicleSignedOut.Text = mpmfVehicleAuditArray(mintStructureCounter).strVehicleSignOutSheet

    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click

        mintStructureCounter = mintStructureCounter + 1

        btnBack.Enabled = True

        LoadTextBoxes()

        If mintStructureCounter = 100 Then
            btnNext.Enabled = False
            btnBack.Focus()
        End If

    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click

        mintStructureCounter = mintStructureCounter - 1

        btnNext.Enabled = True

        LoadTextBoxes()

        If mintStructureCounter = 0 Then
            btnBack.Enabled = False
            btnNext.Focus()
        End If

    End Sub

    Private Sub VehicleSheetAuditForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'This form is used to find the information regarding vehicle audits

        'Make controls visible
        setControlsVisible(True)

        'Vehicle Try - Catch
        Try

            'This will bind the controls to the data source
            TheVehiclesDataTier = New VehiclesDataTier
            TheVehiclesDataSet = TheVehiclesDataTier.GetVehiclesInformation
            TheVehiclesBindingSource = New BindingSource

            'Setting the binding for the combo box
            With TheVehiclesBindingSource
                .DataSource = TheVehiclesDataSet
                .DataMember = "vehicles"
                .MoveFirst()
                .MoveLast()
            End With

            'Binding controls to for the binding for the combo box
            With cboVehicleID
                .DataSource = TheVehiclesBindingSource
                .DisplayMember = "VehicleID"
                .DataBindings.Add("text", TheVehiclesBindingSource, "VehicleID", False, DataSourceUpdateMode.Never)
            End With

            'Setting the binding for all other textbox controls
            txtVehiclesBJCNumber.DataBindings.Add("text", TheVehiclesBindingSource, "BJCNumber")
            txtVehiclesActive.DataBindings.Add("text", TheVehiclesBindingSource, "Active")


        Catch ex As Exception

            'If an exception is thrown, it is rounted here
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        'Employee Try - Catch
        Try
            'This will bind the controls to the data source
            TheEmployeeDataTier = New EmployeeDataTier
            TheEmployeeDataSet = TheEmployeeDataTier.GetEmployeeInformation
            TheEmployeeBindingSource = New BindingSource

            'Setting up Binding Source for the Combo Box
            With TheEmployeeBindingSource
                .DataSource = TheEmployeeDataSet
                .DataMember = "employees"
                .MoveFirst()
                .MoveLast()
            End With

            'Setting the data relationship for the Combo Box
            With cboEmployeeID
                .DataSource = TheEmployeeBindingSource
                .DisplayMember = "EmployeeID"
                .DataBindings.Add("text", TheEmployeeBindingSource, "EmployeeID", False, DataSourceUpdateMode.Never)
            End With

            'Setting the data binding for the text boxes
            txtEmployeeFirstName.DataBindings.Add("text", TheEmployeeBindingSource, "FirstName")
            txtEmployeeLastName.DataBindings.Add("text", TheEmployeeBindingSource, "LastName")

        Catch ex As Exception
            'If an exception is thrown, it is rounted here
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        'The Vehicle Inventory Try - Catch
        Try
            'This will bind the controls to the data source
            TheVehicleInventorySheetDataTier = New VehicleInventorySheetDataTier
            TheVehicleInventorySheetDataSet = TheVehicleInventorySheetDataTier.GetVehicleInventorySheetInformation
            TheVehicleInventorySheetBindingSource = New BindingSource

            'Setting up Binding Source for the Combo Box
            With TheVehicleInventorySheetBindingSource
                .DataSource = TheVehicleInventorySheetDataSet
                .DataMember = "vehicleinventorysheet"
                .MoveFirst()
                .MoveLast()
            End With

            'Setting the data relationship for the Combo Box
            With cboVehicleInventoryTransactionID
                .DataSource = TheVehicleInventorySheetBindingSource
                .DisplayMember = "TransactionID"
                .DataBindings.Add("text", TheVehicleInventorySheetBindingSource, "TransactionID", False, DataSourceUpdateMode.Never)
            End With

            'Setting the data binding for the text boxes
            txtVehicleInventoryBJCNumber.DataBindings.Add("text", TheVehicleInventorySheetBindingSource, "BJCNumber")
            txtVehicleInventoryDate.DataBindings.Add("text", TheVehicleInventorySheetBindingSource, "Date")
            txtVehicleInventorySheetPresent.DataBindings.Add("text", TheVehicleInventorySheetBindingSource, "InventorySheet")

        Catch ex As Exception
            'If an exception is thrown, it is rounted here
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        'Try - Catch for Daily Inspections
        Try
            'This will bind the controls to the data source
            TheDailyVehicleInspectionDataTier = New DailyVehicleInspectionDataTier
            TheDailyVehicleInspectionDataSet = TheDailyVehicleInspectionDataTier.GetDailyVehicleInpectionInformation
            TheDailyVehicleInspectionBindingSource = New BindingSource

            'Setting up Binding Source for the Combo Box
            With TheDailyVehicleInspectionBindingSource
                .DataSource = TheDailyVehicleInspectionDataSet
                .DataMember = "VehicleDailyInspection"
                .MoveFirst()
                .MoveLast()
            End With

            'Setting the data relationship for the Combo Box
            With cboVehicleDailyInspectionID
                .DataSource = TheVehicleInventorySheetBindingSource
                .DisplayMember = "InspectionID"
                .DataBindings.Add("text", TheDailyVehicleInspectionBindingSource, "InspectionID", False, DataSourceUpdateMode.Never)
            End With

            'Setting the data binding for the text boxes
            txtVehicleDailyBJCNumber.DataBindings.Add("text", TheDailyVehicleInspectionBindingSource, "BJCNumber")
            txtVehicleDailyDate.DataBindings.Add("text", TheDailyVehicleInspectionBindingSource, "Date")
            txtVehicleDailyEmployeeID.DataBindings.Add("text", TheDailyVehicleInspectionBindingSource, "EmployeeID")
            txtVehicleDailyFormTurnedIn.DataBindings.Add("text", TheDailyVehicleInspectionBindingSource, "DOTFormTurnedIn")

        Catch ex As Exception
            'If an exception is thrown, it is rounted here
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        'The Vehicle Inventory Try - Catch
        Try
            'This will bind the controls to the data source
            TheVehicleSignedOutDataTier = New VehicleSignedOutDataTier
            TheVehicleSignedOutDataSet = TheVehicleSignedOutDataTier.GetVehicleSignedOutInformation
            TheVehicleSignedOutBindingSource = New BindingSource

            'Setting up Binding Source for the Combo Box
            With TheVehicleSignedOutBindingSource
                .DataSource = TheVehicleSignedOutDataSet
                .DataMember = "vehiclesignedout"
                .MoveFirst()
                .MoveLast()
            End With

            'Setting the data relationship for the Combo Box
            With cboVehicleSignedOutTransactionID
                .DataSource = TheVehicleSignedOutBindingSource
                .DisplayMember = "TransactionID"
                .DataBindings.Add("text", TheVehicleSignedOutBindingSource, "TransactionID", False, DataSourceUpdateMode.Never)
            End With

            'Setting the data binding for the text boxes
            txtVehicleSignedOutBJCNumber.DataBindings.Add("text", TheVehicleSignedOutBindingSource, "BJCNumber")
            txtVehicleSignedOutDate.DataBindings.Add("text", TheVehicleSignedOutBindingSource, "Date")
            txtVehicleSignedOutFormIn.DataBindings.Add("text", TheVehicleSignedOutBindingSource, "VehicleSignedOut")

        Catch ex As Exception
            'If an exception is thrown, it is rounted here
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub setControlsVisible(ByVal valueboolean As Boolean)

        'Vehicles
        cboVehicleID.Visible = valueboolean
        txtBJCNumber.Visible = valueboolean
        txtVehiclesActive.Visible = valueboolean

        'Employees
        cboEmployeeID.Visible = valueboolean
        txtFirstName.Visible = valueboolean
        txtLastName.Visible = valueboolean

        'Daily Vehicle Inspections
        cboVehicleDailyInspectionID.Visible = valueboolean
        txtVehicleDailyBJCNumber.Visible = valueboolean
        txtVehicleDailyDate.Visible = valueboolean
        txtVehicleDailyEmployeeID.Visible = valueboolean
        txtVehicleDailyFormTurnedIn.Visible = valueboolean

        'Vehicle Inventory Sheet
        cboVehicleInventoryTransactionID.Visible = valueboolean
        txtVehicleInventoryBJCNumber.Visible = valueboolean
        txtVehicleInventoryDate.Visible = valueboolean
        txtVehicleInventorySheetPresent.Visible = valueboolean

        'Vehicle Singed Out Sheet
        cboVehicleSignedOutTransactionID.Visible = valueboolean
        txtVehicleSignedOutBJCNumber.Visible = valueboolean
        txtVehicleSignedOutDate.Visible = valueboolean
        txtVehicleSignedOutFormIn.Visible = valueboolean

    End Sub

End Class