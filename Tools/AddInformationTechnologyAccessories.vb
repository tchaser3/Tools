'Title:         Add Information Technology Accessories
'Date:          10-6-14
'Author:        Terry Holmes

'Description:   This form is used to Issue Information Technology Accessories

Option Strict On

Public Class AddInformationTechnologyAccessories

    Private TheInformationTechnologyDeviceAccessoriesDataSet As InformationTechnologyDeviceAccessoriesDataSet
    Private TheInformationTechnologyDeviceAccessoriesDataTier As InformationTechnologyDataTier
    Private WithEvents TheInformationTechnologyDeviceAccessoriesBindingSource As BindingSource

    'Setting up structure
    Structure InformationTechnologyAccessoryStructure
        Dim mblnARecord As Boolean
        Dim mintDeviceID As Integer
        Dim mstrAccessoryType As String
        Dim mdatDate As Date
        Dim mintEmployeeID As Integer
        Dim mstrAvailable As String
        Dim mstrActive As String
    End Structure

    'Creating Structure Object
    Dim structAccesories(10) As InformationTechnologyAccessoryStructure

    'Creating date and time objects
    Dim LogDateTime As Date = DateAndTime.Now
    Dim strLogDateTime As String

    Private addingBoolean As Boolean = False
    Private editingBoolean As Boolean = False
    Private previousSelectedIndex As Integer

    Private Sub btnIssueAccessories_Click(sender As System.Object, e As System.EventArgs) Handles btnIssueAccessories.Click

        'This proceedure will save the items that were issued

        Dim intCounter As Integer
        Dim blnNoItemsSelected As Boolean = True

        SetControlsVisible(True)

        For intCounter = 0 To 10

            If structAccesories(intCounter).mblnARecord = True Then

                'Since records were found
                blnNoItemsSelected = False

                'Setting up the binding source
                With TheInformationTechnologyDeviceAccessoriesBindingSource
                    .EndEdit()
                    .AddNew()
                End With

                'Setting up other variables
                cboAccessoryID.Focus()
                addingBoolean = True
                SetComboBoxBinding()

                'Setting the combo box
                If cboAccessoryID.SelectedIndex <> -1 Then
                    previousSelectedIndex = cboAccessoryID.Items.Count - 1
                Else
                    previousSelectedIndex = 0
                End If

                'Loading up the the controls
                InformationTechnologyID.Show()
                cboAccessoryID.Text = CStr(Logon.mintCreatedTransactionID)
                txtDeviceID.Text = CStr(structAccesories(intCounter).mintDeviceID)
                txtAccessoryType.Text = structAccesories(intCounter).mstrAccessoryType
                txtDate.Text = strLogDateTime
                txtEmployeeID.Text = CStr(structAccesories(intCounter).mintEmployeeID)
                txtAvailable.Text = structAccesories(intCounter).mstrAvailable
                txtActive.Text = structAccesories(intCounter).mstrActive

                'saving the record
                Try
                    TheInformationTechnologyDeviceAccessoriesBindingSource.EndEdit()
                    TheInformationTechnologyDeviceAccessoriesDataTier.UpdateInformationTechnologyDeviceAccessoriesDB(TheInformationTechnologyDeviceAccessoriesDataSet)
                    addingBoolean = False
                    editingBoolean = False
                    SetComboBoxBinding()

                    'Setting up to add new history entry
                    Logon.mintEmployeeID = CInt(txtEmployeeID.Text)
                    Logon.mintAccessoryID = CInt(cboAccessoryID.Text)
                    Logon.mintDeviceID = CInt(txtDeviceID.Text)
                    Logon.mdatDate = CDate(txtDate.Text)
                    Logon.mstrNotes = "UNIT SIGNED OUT"

                    AddInformationTechnologyAccessoryHistory.Show()

                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

            End If

        Next

        If blnNoItemsSelected = True Then
            MessageBox.Show("No Accessories Were Issued with Device", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        Else
            Me.Close()
        End If

    End Sub

    Private Sub chkUSBCable_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkUSBCable.CheckedChanged

        'Setting up the elements of the structure
        If chkUSBCable.Checked = True Then

            structAccesories(0).mblnARecord = True
            structAccesories(0).mintDeviceID = CInt(Logon.mintDeviceID)
            structAccesories(0).mintEmployeeID = CInt(Logon.mintEmployeeID)
            structAccesories(0).mdatDate = CDate(LogDateTime)
            structAccesories(0).mstrAccessoryType = "USB CABLE"
            structAccesories(0).mstrAvailable = "NO"
            structAccesories(0).mstrActive = "YES"
            btnIssueAccessories.Enabled = True

        Else
            structAccesories(0).mblnARecord = False
        End If

    End Sub

    Private Sub chkPowerUSBCharger_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPowerUSBCharger.CheckedChanged

        'Setting up the elements of the structure
        If chkPowerUSBCharger.Checked = True Then

            structAccesories(1).mblnARecord = True
            structAccesories(1).mintDeviceID = CInt(Logon.mintDeviceID)
            structAccesories(1).mintEmployeeID = CInt(Logon.mintEmployeeID)
            structAccesories(1).mdatDate = CDate(LogDateTime)
            structAccesories(1).mstrAccessoryType = "POWER USB CHARGER"
            structAccesories(1).mstrAvailable = "NO"
            structAccesories(1).mstrActive = "YES"
            btnIssueAccessories.Enabled = True

        Else
            structAccesories(1).mblnARecord = False
        End If

    End Sub

    Private Sub chkHeadPhones_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkHeadPhones.CheckedChanged

        'Setting up the elements of the structure
        If chkHeadPhones.Checked = True Then

            structAccesories(2).mblnARecord = True
            structAccesories(2).mintDeviceID = CInt(Logon.mintDeviceID)
            structAccesories(2).mintEmployeeID = CInt(Logon.mintEmployeeID)
            structAccesories(2).mdatDate = CDate(LogDateTime)
            structAccesories(2).mstrAccessoryType = "HEAD PHONES"
            structAccesories(2).mstrAvailable = "NO"
            structAccesories(2).mstrActive = "YES"
            btnIssueAccessories.Enabled = True

        Else
            structAccesories(2).mblnARecord = False
        End If

    End Sub

    Private Sub chkPhoneCase_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPhoneCase.CheckedChanged

        'Setting up the elements of the structure
        If chkPhoneCase.Checked = True Then

            structAccesories(3).mblnARecord = True
            structAccesories(3).mintDeviceID = CInt(Logon.mintDeviceID)
            structAccesories(3).mintEmployeeID = CInt(Logon.mintEmployeeID)
            structAccesories(3).mdatDate = CDate(LogDateTime)
            structAccesories(3).mstrAccessoryType = "PHONE CASE"
            structAccesories(3).mstrAvailable = "NO"
            structAccesories(3).mstrActive = "YES"
            btnIssueAccessories.Enabled = True

        Else
            structAccesories(3).mblnARecord = False
        End If

    End Sub

    Private Sub chkLaptopCase_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkLaptopCase.CheckedChanged

        'Setting up the elements of the structure
        If chkLaptopCase.Checked = True Then

            structAccesories(4).mblnARecord = True
            structAccesories(4).mintDeviceID = CInt(Logon.mintDeviceID)
            structAccesories(4).mintEmployeeID = CInt(Logon.mintEmployeeID)
            structAccesories(4).mdatDate = CDate(LogDateTime)
            structAccesories(4).mstrAccessoryType = "LAPTOP CASE"
            structAccesories(4).mstrAvailable = "NO"
            structAccesories(4).mstrActive = "YES"
            btnIssueAccessories.Enabled = True

        Else
            structAccesories(4).mblnARecord = False
        End If

    End Sub

    Private Sub chkPowerCord_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPowerCord.CheckedChanged

        'Setting up the elements of the structure
        If chkPowerCord.Checked = True Then

            structAccesories(5).mblnARecord = True
            structAccesories(5).mintDeviceID = CInt(Logon.mintDeviceID)
            structAccesories(5).mintEmployeeID = CInt(Logon.mintEmployeeID)
            structAccesories(5).mdatDate = CDate(LogDateTime)
            structAccesories(5).mstrAccessoryType = "POWER CORD"
            structAccesories(5).mstrAvailable = "NO"
            structAccesories(5).mstrActive = "YES"
            btnIssueAccessories.Enabled = True

        Else
            structAccesories(5).mblnARecord = False
        End If

    End Sub

    Private Sub chkKeyboard_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkKeyboard.CheckedChanged

        'Setting up the elements of the structure
        If chkKeyboard.Checked = True Then

            structAccesories(6).mblnARecord = True
            structAccesories(6).mintDeviceID = CInt(Logon.mintDeviceID)
            structAccesories(6).mintEmployeeID = CInt(Logon.mintEmployeeID)
            structAccesories(6).mdatDate = CDate(LogDateTime)
            structAccesories(6).mstrAccessoryType = "KEYBOARD"
            structAccesories(6).mstrAvailable = "NO"
            structAccesories(6).mstrActive = "YES"
            btnIssueAccessories.Enabled = True

        Else
            structAccesories(6).mblnARecord = False
        End If

    End Sub

    Private Sub chkMouse_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMouse.CheckedChanged

        'Setting up the elements of the structure
        If chkMouse.Checked = True Then

            structAccesories(7).mblnARecord = True
            structAccesories(7).mintDeviceID = CInt(Logon.mintDeviceID)
            structAccesories(7).mintEmployeeID = CInt(Logon.mintEmployeeID)
            structAccesories(7).mdatDate = CDate(LogDateTime)
            structAccesories(7).mstrAccessoryType = "MOUSE"
            structAccesories(7).mstrAvailable = "NO"
            structAccesories(7).mstrActive = "YES"
            btnIssueAccessories.Enabled = True

        Else
            structAccesories(7).mblnARecord = False
        End If

    End Sub

    Private Sub chkMonitor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMonitor.CheckedChanged

        'Setting up the elements of the structure
        If chkMonitor.Checked = True Then

            structAccesories(8).mblnARecord = True
            structAccesories(8).mintDeviceID = CInt(Logon.mintDeviceID)
            structAccesories(8).mintEmployeeID = CInt(Logon.mintEmployeeID)
            structAccesories(8).mdatDate = CDate(LogDateTime)
            structAccesories(8).mstrAccessoryType = "MONITOR"
            structAccesories(8).mstrAvailable = "NO"
            structAccesories(8).mstrActive = "YES"
            btnIssueAccessories.Enabled = True

        Else
            structAccesories(8).mblnARecord = False
        End If

    End Sub

    Private Sub chkPrinter_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPrinter.CheckedChanged

        'Setting up the elements of the structure
        If chkPrinter.Checked = True Then

            structAccesories(9).mblnARecord = True
            structAccesories(9).mintDeviceID = CInt(Logon.mintDeviceID)
            structAccesories(9).mintEmployeeID = CInt(Logon.mintEmployeeID)
            structAccesories(9).mdatDate = CDate(LogDateTime)
            structAccesories(9).mstrAccessoryType = "PRINTER"
            structAccesories(9).mstrAvailable = "NO"
            structAccesories(9).mstrActive = "YES"
            btnIssueAccessories.Enabled = True

        Else
            structAccesories(9).mblnARecord = False
        End If

    End Sub

    Private Sub AddInformationTechnologyAccessories_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Local Variables
        Dim intCounter As Integer

        'Setting the time
        strLogDateTime = CStr(LogDateTime)

        'Binding the controls
        Try

            'Setting up the structure
            For intCounter = 0 To 10
                structAccesories(intCounter).mblnARecord = False
            Next

            'Setting up the data set
            TheInformationTechnologyDeviceAccessoriesDataTier = New InformationTechnologyDataTier
            TheInformationTechnologyDeviceAccessoriesDataSet = TheInformationTechnologyDeviceAccessoriesDataTier.GetInformationTechnologyDeviceAccessoriesInformation
            TheInformationTechnologyDeviceAccessoriesBindingSource = New BindingSource

            'Setting up the binding source
            With TheInformationTechnologyDeviceAccessoriesBindingSource
                .DataSource = TheInformationTechnologyDeviceAccessoriesDataSet
                .DataMember = "informationtechnologydeviceaccessories"
                .MoveFirst()
                .MoveLast()
            End With

            'Setting up the Combo Box
            With cboAccessoryID
                .DataSource = TheInformationTechnologyDeviceAccessoriesBindingSource
                .DisplayMember = "AccessoryID"
                .DataBindings.Add("text", TheInformationTechnologyDeviceAccessoriesBindingSource, "AccessoryID", False, DataSourceUpdateMode.Never)
            End With

            'Binding the rest of the controls
            txtDeviceID.DataBindings.Add("text", TheInformationTechnologyDeviceAccessoriesBindingSource, "DeviceID")
            txtAccessoryType.DataBindings.Add("text", TheInformationTechnologyDeviceAccessoriesBindingSource, "AccessoryType")
            txtDate.DataBindings.Add("text", TheInformationTechnologyDeviceAccessoriesBindingSource, "Date")
            txtEmployeeID.DataBindings.Add("text", TheInformationTechnologyDeviceAccessoriesBindingSource, "EmployeeID")
            txtAvailable.DataBindings.Add("text", TheInformationTechnologyDeviceAccessoriesBindingSource, "Available")
            txtActive.DataBindings.Add("text", TheInformationTechnologyDeviceAccessoriesBindingSource, "Active")

            SetControlsVisible(False)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub SetControlsVisible(ByVal valueBoolean As Boolean)

        'These Controls are set visible
        cboAccessoryID.Visible = valueBoolean
        txtAccessoryType.Visible = valueBoolean
        txtAvailable.Visible = valueBoolean
        txtDate.Visible = valueBoolean
        txtDeviceID.Visible = valueBoolean
        txtEmployeeID.Visible = valueBoolean
        txtActive.Visible = valueBoolean

    End Sub
    Private Sub SetComboBoxBinding()

        'This will set the combo box bindings.
        With cboAccessoryID
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