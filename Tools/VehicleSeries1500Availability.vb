'Title:         Heavy Duty Truck Availability
'Date:          8/8/13
'Author:        Terry Holmes

Option Strict On

Public Class VehicleSeries1500Availability

    Private TheVehiclesDataSet As VehiclesDataSet
    Private TheVehiclesDataTier As VehiclesDataTier
    Private WithEvents TheVehiclesBindingSource As BindingSource

    Dim TheInputDataValidation As New InputDataValidation

    Private addingBoolean As Boolean = False
    Private editingBoolean As Boolean = False
    Private previousSelectedIndex As Integer
    Dim mintNumuberOfRecords As Integer

    Dim LogDateTime As Date = DateAndTime.Now
    Dim strLogDateTime As String
    Friend mintBJCNumber As Integer

    Private Sub btnVehicleMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVehicleMenu.Click

        ClearDataBindings()
        VehicleMenu.Show()
        Me.Close()

    End Sub

    Private Sub btnMainMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMainMenu.Click

        ClearDataBindings()
        MainMenu.Show()
        Me.Close()

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        'Closes the Program
        CloseTheProgram.ShowDialog()

    End Sub

    Private Sub btnAvailabilityMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAvailabilityMenu.Click

        ClearDataBindings()
        VehicleAssignmentChoice.Show()
        Me.Close()

    End Sub
    Private Sub SetControlsVisible(ByVal valueBoolean As Boolean)

        'This will make the controls visible
        cboVehicleID.Visible = valueBoolean
        txtActive.Visible = valueBoolean
        txtAvailable.Visible = valueBoolean
        txtVehicleDownForMaintenance.Visible = valueBoolean
        txtBJCNumber.Visible = valueBoolean

    End Sub
    Private Sub SetDataBindings()

        Try

            'This will bind the controls to the data source
            TheVehiclesDataTier = New VehiclesDataTier
            TheVehiclesDataSet = TheVehiclesDataTier.GetVehiclesInformation
            TheVehiclesBindingSource = New BindingSource

            With TheVehiclesBindingSource
                .DataSource = TheVehiclesDataSet
                .DataMember = "vehicles"
                .MoveFirst()
                .MoveLast()
            End With

            'This sets the databindings
            'Binding controls to for the binding source
            With cboVehicleID
                .DataSource = TheVehiclesBindingSource
                .DisplayMember = "VehicleID"
                .DataBindings.Add("text", TheVehiclesBindingSource, "VehicleID", False, DataSourceUpdateMode.Never)
            End With

            txtAvailable.DataBindings.Add("text", TheVehiclesBindingSource, "Available")
            txtActive.DataBindings.Add("text", TheVehiclesBindingSource, "Active")
            txtVehicleDownForMaintenance.DataBindings.Add("Text", TheVehiclesBindingSource, "DownForRepairs")
            txtBJCNumber.DataBindings.Add("text", TheVehiclesBindingSource, "BJCNumber")

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

        

    End Sub
    Private Sub ClearDataBindings()

        cboVehicleID.DataBindings.Clear()
        txtAvailable.DataBindings.Clear()
        txtActive.DataBindings.Clear()
        txtBJCNumber.DataBindings.Clear()
        txtVehicleDownForMaintenance.DataBindings.Clear()

    End Sub


    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click

        'This sub-routine will refresh the information on the fly
        ClearDataBindings()

        SetDataBindings()

        SetUpButtons()



    End Sub

    Private Sub btnLegend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLegend.Click

        Legend.Show()

    End Sub


    Private Sub VehicleSeries1500Availability_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'This routine runs during form load
        Try
            

            SetDataBindings()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        SetUpButtons()

    End Sub
    Private Sub SetUpButtons()

        Dim intCounter As Integer
        Dim intUpperLimit As Integer
        Dim intBJCNumber As Integer
        Dim strActive As String
        Dim strAvailable As String
        Dim strDownForRepairs As String

        intUpperLimit = cboVehicleID.Items.Count
        SetControlsVisible(True)

        For intCounter = 0 To intUpperLimit - 1

            cboVehicleID.SelectedIndex = intCounter

            intBJCNumber = CInt(txtBJCNumber.Text)
            strActive = txtActive.Text
            strAvailable = txtAvailable.Text
            strDownForRepairs = txtVehicleDownForMaintenance.Text
            If intBJCNumber = 1501 Then
                With BTN1501
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    BTN1501.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    BTN1501.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    BTN1501.BackColor = Color.Black
                End If
                If strDownForRepairs = "YES" Then
                    BTN1501.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1502 Then
                With btn1502
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1502.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1502.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1502.BackColor = Color.Black
                End If
                If strDownForRepairs = "YES" And strActive = "YES" Then
                    btn1502.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1503 Then
                With btn1503
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1503.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1503.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1503.BackColor = Color.Black
                End If
                If strDownForRepairs = "YES" And strActive = "YES" Then
                    btn1503.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1504 Then
                With btn1504
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1504.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1504.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1504.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1504.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1505 Then
                With btn1505
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1505.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1505.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1505.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1505.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1506 Then
                With btn1506
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1506.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1506.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1506.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1506.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1507 Then
                With btn1507
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1507.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1507.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1507.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1507.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1508 Then
                With btn1508
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1508.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1508.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1508.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1508.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1509 Then
                With btn1509
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1509.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1509.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1509.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1509.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1510 Then
                With btn1510
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1510.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1510.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1510.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1510.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1511 Then
                With btn1511
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1511.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1511.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1511.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1511.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1512 Then
                With btn1512
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1512.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1512.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1512.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1512.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1513 Then
                With btn1513
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1513.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1513.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1513.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1513.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1514 Then
                With btn1514
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1514.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1514.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1514.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1514.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1515 Then
                With btn1515
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1515.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1515.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1515.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1515.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1516 Then
                With btn1516
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1516.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1516.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1516.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1516.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1517 Then
                With btn1517
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1517.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1517.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1517.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1517.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1518 Then
                With btn1518
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1518.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1518.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1518.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1518.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1519 Then
                With btn1519
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1519.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1519.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1519.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1519.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1520 Then
                With btn1520
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1520.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1520.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1520.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1520.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1521 Then
                With btn1521
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1521.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1521.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1521.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1521.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1522 Then
                With btn1522
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1522.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1522.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1522.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1522.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1523 Then
                With btn1523
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1523.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1523.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1523.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1523.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1524 Then
                With btn1524
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1524.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1524.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1524.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1524.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1525 Then
                With btn1525
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1525.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1525.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1525.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1525.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1526 Then
                With btn1526
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1526.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1526.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1526.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1526.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1527 Then
                With btn1527
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1527.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1527.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1527.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1527.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1528 Then
                With btn1528
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1528.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1528.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1528.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1528.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1529 Then
                With btn1529
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1529.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1529.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1529.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1529.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1530 Then
                With btn1530
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1530.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1530.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1530.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1530.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1531 Then
                With btn1531
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1531.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1531.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1531.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1531.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1532 Then
                With btn1532
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1532.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1532.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1532.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1532.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1533 Then
                With btn1533
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1533.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1533.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1533.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1533.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1534 Then
                With btn1534
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1534.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1534.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1534.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1534.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1535 Then
                With btn1535
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1535.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1535.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1535.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1535.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1536 Then
                With btn1536
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1536.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1536.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1536.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1536.BackColor = Color.Red
                End If
            End If

        Next

        SetControlsVisible(False)

    End Sub
    Private Sub btn1501_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN1501.Click

        Logon.mintBJCNumber = 1501
        VehicleInformationFromAvailablity.Show()

    End Sub

    Private Sub btn1502_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1502.Click

        Logon.mintBJCNumber = 1502
        VehicleInformationFromAvailablity.Show()

    End Sub

    Private Sub btn1503_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1503.Click

        Logon.mintBJCNumber = 1503
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1504_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1504.Click

        Logon.mintBJCNumber = 1504
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1505_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1505.Click

        Logon.mintBJCNumber = 1505
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1506_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1506.Click

        Logon.mintBJCNumber = 1506
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1507_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1507.Click

        Logon.mintBJCNumber = 1507
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1508_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1508.Click

        Logon.mintBJCNumber = 1508
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1509_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1509.Click

        Logon.mintBJCNumber = 1509
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1510_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1510.Click

        Logon.mintBJCNumber = 1510
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1511_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1511.Click

        Logon.mintBJCNumber = 1511
        VehicleInformationFromAvailablity.Show()

    End Sub

    Private Sub btn1512_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1512.Click

        Logon.mintBJCNumber = 1512
        VehicleInformationFromAvailablity.Show()

    End Sub

    Private Sub btn1513_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1513.Click

        Logon.mintBJCNumber = 1513
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1514_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1514.Click

        Logon.mintBJCNumber = 1514
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1515_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1515.Click

        Logon.mintBJCNumber = 1515
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1516_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1516.Click

        Logon.mintBJCNumber = 1516
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1517_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1517.Click

        Logon.mintBJCNumber = 1517
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1518_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1518.Click

        Logon.mintBJCNumber = 1518
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1519_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1519.Click

        Logon.mintBJCNumber = 1519
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1520_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1520.Click

        Logon.mintBJCNumber = 1520
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1521_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1521.Click

        Logon.mintBJCNumber = 1521
        VehicleInformationFromAvailablity.Show()

    End Sub

    Private Sub btn1522_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1522.Click

        Logon.mintBJCNumber = 1522
        VehicleInformationFromAvailablity.Show()

    End Sub

    Private Sub btn1523_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1523.Click

        Logon.mintBJCNumber = 1523
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1124_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1524.Click

        Logon.mintBJCNumber = 1524
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1525_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1525.Click

        Logon.mintBJCNumber = 1525
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1526_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1526.Click

        Logon.mintBJCNumber = 1526
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1527_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1527.Click

        Logon.mintBJCNumber = 1527
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1528_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1528.Click

        Logon.mintBJCNumber = 1528
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1529_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1529.Click

        Logon.mintBJCNumber = 1529
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1530_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1530.Click

        Logon.mintBJCNumber = 1530
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1531_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1531.Click

        Logon.mintBJCNumber = 1531
        VehicleInformationFromAvailablity.Show()

    End Sub

    Private Sub btn1532_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1532.Click

        Logon.mintBJCNumber = 1532
        VehicleInformationFromAvailablity.Show()

    End Sub

    Private Sub btn1533_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1533.Click

        Logon.mintBJCNumber = 1533
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1534_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1534.Click

        Logon.mintBJCNumber = 1534
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1535_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1535.Click

        Logon.mintBJCNumber = 1535
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1536_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1536.Click

        Logon.mintBJCNumber = 1536
        VehicleInformationFromAvailablity.Show()

    End Sub

End Class
