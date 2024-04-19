'Title:         Cable Selection Form
'Date:          1/22/14
'Author;        Terry Holmes

'Description:   This form is used to type of cable and the part number
'               for both availability and usage

Option Strict On

Public Class CableSelection

    'Setting up the Employee DataSet
    Private TheEmployeeDataSet As EmployeeDataSet
    Private TheEmployeeDataTier As EmployeeDataTier
    Private WithEvents TheEmployeeBindingSource As BindingSource

    Private ThePartNumberDataSet As PartNumberDataSet
    Private ThePartNumberDataTier As PartDataTier
    Private WithEvents ThePartNumberBindingSource As BindingSource

    Dim TheInputDataValidation As New InputDataValidation

    Private addingBoolean As Boolean = False
    Private editingBoolean As Boolean = False
    Private previousSelectedIndex As Integer
    Dim mintNumuberOfRecords As Integer

    Dim LogDateTime As Date = DateAndTime.Now
    Dim strLogDateTime As String
    Dim mstrCableCategory As String

    'Setting global variable
    Dim mintSelectedIndex(100) As Integer
    Dim mintSelectedIndexCounter As Integer = 0
    Dim mintSelectedIndexUpperLimit As Integer
    Dim mintCableTypeComboBoxUpperLimit As Integer

    Dim mintWarehouseSelectedIndex(10) As Integer
    Dim mintWarehouseSelectedIndexCounter As Integer
    Dim mintWarehouseSelectedIndexUpperLimit As Integer

    Private Sub CableSelection_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Setting Local Variables
        Dim strWarehouse As String
        Dim intCounter As Integer
        Dim intUpperLimit As Integer
        Dim strLastName As String

        Try

            'This will bind the controls to the data source
            TheEmployeeDataTier = New EmployeeDataTier
            TheEmployeeDataSet = TheEmployeeDataTier.GetEmployeeInformation
            TheEmployeeBindingSource = New BindingSource

            'Setting variables to bind controls
            ThePartNumberDataTier = New PartDataTier
            ThePartNumberDataSet = ThePartNumberDataTier.GetPartNumberInformation
            ThePartNumberBindingSource = New BindingSource

            'Setting up Binding Source for the Combo Box
            With TheEmployeeBindingSource
                .DataSource = TheEmployeeDataSet
                .DataMember = "employees"
                .MoveFirst()
                .MoveLast()
            End With

            'Setting up the part number binding source
            With ThePartNumberBindingSource
                .DataSource = ThePartNumberDataSet
                .DataMember = "partnumbers"
                .MoveFirst()
                .MoveLast()
            End With

            'Setting the data relationship for the Combo Box
            With cboEmployeeID
                .DataSource = TheEmployeeBindingSource
                .DisplayMember = "EmployeeID"
                .DataBindings.Add("text", TheEmployeeBindingSource, "EmployeeID", False, DataSourceUpdateMode.Never)
            End With

            'Binding the part number combo box
            With cboPartID
                .DataSource = ThePartNumberBindingSource
                .DisplayMember = "PartID"
                .DataBindings.Add("text", ThePartNumberBindingSource, "PartID", False, DataSourceUpdateMode.Never)
            End With

            'Setting the data binding for the text boxes
            txtFirstName.DataBindings.Add("text", TheEmployeeBindingSource, "FirstName")
            txtLastName.DataBindings.Add("text", TheEmployeeBindingSource, "LastName")

            'setting the databinding for the part number controls
            txtCablePartNumber.DataBindings.Add("text", ThePartNumberBindingSource, "PartNumber")
            txtCableDescription.DataBindings.Add("text", ThePartNumberBindingSource, "Description")
            txtCableJobType.DataBindings.Add("text", ThePartNumberBindingSource, "Type")
            txtCablePartType.DataBindings.Add("text", ThePartNumberBindingSource, "PartType")

        Catch ex As Exception

            'If an exception is thrown, it is rounted here
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        'Filling Array with only Warehouses to Be Selected
        strWarehouse = "PARTS"
        mintWarehouseSelectedIndexCounter = 0
        mintWarehouseSelectedIndexUpperLimit = 0
        intUpperLimit = cboEmployeeID.Items.Count - 1

        'Running For Loop to find the different warehouses
        For intCounter = 0 To intUpperLimit

            cboEmployeeID.SelectedIndex = intCounter
            strLastName = txtLastName.Text
            If strLastName = strWarehouse Then
                mintWarehouseSelectedIndex(mintWarehouseSelectedIndexCounter) = intCounter
                mintWarehouseSelectedIndexCounter = mintWarehouseSelectedIndexCounter + 1
            End If

        Next

        mintWarehouseSelectedIndexUpperLimit = mintWarehouseSelectedIndexCounter - 1
        mintWarehouseSelectedIndexCounter = 0
        cboEmployeeID.SelectedIndex = mintWarehouseSelectedIndex(0)

        If mintWarehouseSelectedIndexUpperLimit > 0 Then
            btnEmployeeNext.Enabled = True
        End If

    End Sub
    Private Sub setComboBoxBinding()

        'Setting Type ID Combo Binding
        With Me.cboPartID
            If (addingBoolean Or editingBoolean) Then
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.OnValidation
                .DropDownStyle = ComboBoxStyle.Simple
            Else
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.Never
                .DropDownStyle = ComboBoxStyle.DropDownList
            End If
        End With

    End Sub
    Private Sub btnSelectPartNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectPartNumber.Click

        'This will launch the Select Cable Part Number Form
        Dim strValueForValidation As String = ""
        Dim blnFatalError As Boolean = False

        strValueForValidation = mstrCableCategory
        blnFatalError = TheInputDataValidation.VerifyCableCategory(strValueForValidation)

        If blnFatalError = True Then
            MessageBox.Show("Cable Category Entered Is Not Correct", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Logon.mstrPartNumber = txtCablePartNumber.Text

        btnSelectWarehouse.Enabled = True
        btnNext.Enabled = False
        btnBack.Enabled = False
        btnSelectPartNumber.Enabled = False
        rdoCoax.Enabled = False
        rdoDropCable.Enabled = False
        rdoFiber.Enabled = False
        rdoTwistedPair.Enabled = False
        rdoSpecialtyCable.Enabled = False

    End Sub
    Private Sub SetCategoryBox()

        btnSelectPartNumber.Enabled = True


    End Sub
    Private Sub rdoCoax_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdoCoax.CheckedChanged

        'This will Set the variable value
        mstrCableCategory = "COAX"
        SetCategoryBox()
        SetCableCategory()

    End Sub

    Private Sub rdoFiber_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdoFiber.CheckedChanged

        'This will Set the variable value
        mstrCableCategory = "FIBER"
        SetCategoryBox()
        SetCableCategory()

    End Sub


    Private Sub rdoDropCable_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdoDropCable.CheckedChanged

        'This will Set the variable value
        mstrCableCategory = "DROP CABLE"
        SetCategoryBox()
        SetCableCategory()

    End Sub

    Private Sub rdoTwistedPair_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdoTwistedPair.CheckedChanged

        'This will Set the variable value
        mstrCableCategory = "TWISTED PAIR"
        SetCategoryBox()
        SetCableCategory()

    End Sub

    Private Sub rdoSpecialtyCable_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdoSpecialtyCable.CheckedChanged

        'This will Set the variable value
        mstrCableCategory = "SPECIALTY CABLE"
        SetCategoryBox()
        SetCableCategory()

    End Sub
    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click


        mintSelectedIndexCounter = mintSelectedIndexCounter + 1
        cboPartID.SelectedIndex = mintSelectedIndex(mintSelectedIndexCounter)

        btnBack.Enabled = True

        If mintSelectedIndexCounter = mintSelectedIndexUpperLimit Then
            btnNext.Enabled = False
        End If

    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click

        mintSelectedIndexCounter = mintSelectedIndexCounter - 1
        cboPartID.SelectedIndex = mintSelectedIndex(mintSelectedIndexCounter)

        btnNext.Enabled = True

        If mintSelectedIndexCounter = 0 Then
            btnBack.Enabled = False
        End If

    End Sub

    Private Sub SetCableCategory()

        Dim strCategory As String
        Dim strPartType As String
        Dim intCounter As Integer

        cboPartID.SelectedIndex = 0
        btnBack.Enabled = False
        btnNext.Enabled = False

        mintCableTypeComboBoxUpperLimit = cboPartID.Items.Count - 1
        mintSelectedIndexCounter = 0
        mintSelectedIndexUpperLimit = 0

        'For intCounter = 0 To mintCableTypeComboBoxUpperLimit
        'mintSelectedIndex(intCounter) = -1
        'Next

        For intCounter = 0 To mintCableTypeComboBoxUpperLimit

            cboPartID.SelectedIndex = intCounter
            strCategory = txtCableJobType.Text
            strPartType = txtCablePartType.Text
            If strCategory = mstrCableCategory Then
                If strPartType = "CABLE" Then
                    mintSelectedIndex(mintSelectedIndexCounter) = intCounter
                    mintSelectedIndexCounter = mintSelectedIndexCounter + 1
                End If
            End If
        Next
        mintSelectedIndexUpperLimit = mintSelectedIndexCounter - 1
        mintSelectedIndexCounter = 0
        cboPartID.SelectedIndex = mintSelectedIndex(0)
        If mintSelectedIndexUpperLimit > 0 Then
            btnNext.Enabled = True
        End If

        If mintSelectedIndexUpperLimit = 0 Then
            btnNext.Enabled = False
            btnBack.Enabled = False
        End If

        'btnCreateReelID.Enabled = True

    End Sub
    Private Sub btnEmployeeNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEmployeeNext.Click

        mintWarehouseSelectedIndexCounter = mintWarehouseSelectedIndexCounter + 1
        cboEmployeeID.SelectedIndex = mintWarehouseSelectedIndex(mintWarehouseSelectedIndexCounter)

        btnEmployeeBack.Enabled = True

        If mintWarehouseSelectedIndexCounter = mintWarehouseSelectedIndexUpperLimit Then
            btnEmployeeNext.Enabled = False
        End If


    End Sub

    Private Sub btnEmployeeBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEmployeeBack.Click

        mintWarehouseSelectedIndexCounter = mintWarehouseSelectedIndexCounter - 1
        cboEmployeeID.SelectedIndex = mintWarehouseSelectedIndex(mintWarehouseSelectedIndexCounter)

        btnEmployeeNext.Enabled = True

        If mintWarehouseSelectedIndexCounter = 0 Then
            btnEmployeeBack.Enabled = False
        End If


    End Sub

    Private Sub btnSelectWarehouse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectWarehouse.Click

        '
        Logon.mintWarehouseID = CInt(cboEmployeeID.Text)
        Logon.mstrCategory = mstrCableCategory

        If Logon.mstrCableSelectionType = "AVAILABILITY" Then
            CableAvailability.Show()
            ClearDataBindings()
            Me.Close()
        ElseIf Logon.mstrCableSelectionType = "ISSUECABLE" Then
            IssueCable.Show()
            ClearDataBindings()
            Me.Close()
        End If


    End Sub
    Private Sub ClearDataBindings()

        cboEmployeeID.DataBindings.Clear()
        cboPartID.DataBindings.Clear()
        txtCableJobType.DataBindings.Clear()
        txtCablePartNumber.DataBindings.Clear()
        txtFirstName.DataBindings.Clear()
        txtLastName.DataBindings.Clear()
        txtCablePartType.DataBindings.Clear()

    End Sub
End Class