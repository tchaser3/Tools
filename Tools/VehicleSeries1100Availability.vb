'Title:         Vehicle Availability for the 1100 Series
'Date:          8/7/13
'Author:        Terry Holmes

Option Strict On

Public Class VehicleSeries1100Availability

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


    Private Sub VehicleSeries1100Availability_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'This routine runs during form load
        SetDataBindings()
        SetUpButtons()
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
        Try
            ClearDataBindings()
            SetDataBindings()
            SetUpButtons()

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try


    End Sub

    Private Sub btnLegend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLegend.Click

        Legend.Show()

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
            If intBJCNumber = 1101 Then
                With btn1101
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1101.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1101.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1101.BackColor = Color.Black
                End If
                If strDownForRepairs = "YES" Then
                    btn1101.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1102 Then
                With btn1102
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1102.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1102.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1102.BackColor = Color.Black
                End If
                If strDownForRepairs = "YES" And strActive = "YES" Then
                    btn1102.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1103 Then
                With btn1103
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1103.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1103.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1103.BackColor = Color.Black
                End If
                If strDownForRepairs = "YES" And strActive = "YES" Then
                    btn1103.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1104 Then
                With btn1104
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1104.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1104.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1104.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1104.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1105 Then
                With btn1105
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1105.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1105.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1105.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1105.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1106 Then
                With btn1106
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1106.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1106.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1106.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1106.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1107 Then
                With btn1107
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1107.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1107.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1107.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1107.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1108 Then
                With btn1108
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1108.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1108.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1108.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1108.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1109 Then
                With btn1109
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1109.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1109.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1109.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1109.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1110 Then
                With btn1110
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1110.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1110.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1110.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1110.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1111 Then
                With btn1111
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1111.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1111.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1111.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1111.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1112 Then
                With btn1112
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1112.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1112.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1112.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1112.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1113 Then
                With btn1113
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1113.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1113.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1113.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1113.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1114 Then
                With btn1114
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1114.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1114.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1114.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1114.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1115 Then
                With btn1115
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1115.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1115.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1115.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1115.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1116 Then
                With btn1116
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1116.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1116.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1116.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1116.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1117 Then
                With btn1117
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1117.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1117.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1117.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1117.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1118 Then
                With btn1118
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1118.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1118.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1118.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1118.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1119 Then
                With btn1119
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1119.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1119.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1119.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1119.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1120 Then
                With btn1120
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1120.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1120.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1120.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1120.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1121 Then
                With btn1121
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1121.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1121.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1121.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1121.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1122 Then
                With btn1122
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1122.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1122.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1122.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1122.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1123 Then
                With btn1123
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1123.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1123.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1123.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1123.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1124 Then
                With btn1124
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1124.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1124.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1124.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1124.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1125 Then
                With btn1125
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1125.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1125.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1125.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1125.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1126 Then
                With btn1126
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1126.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1126.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1126.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1126.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1127 Then
                With btn1127
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1127.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1127.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1127.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1127.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1128 Then
                With btn1128
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1128.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1128.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1128.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1128.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1129 Then
                With btn1129
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1129.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1129.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1129.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1129.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1130 Then
                With btn1130
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1130.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1130.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1130.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1130.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1131 Then
                With btn1131
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1131.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1131.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1131.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1131.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1132 Then
                With btn1132
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1132.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1132.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1132.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1132.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1133 Then
                With btn1133
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1133.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1133.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1133.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1133.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1134 Then
                With btn1134
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1134.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1134.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1134.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1134.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1135 Then
                With btn1135
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1135.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1135.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1135.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1135.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1136 Then
                With btn1136
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1136.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1136.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1136.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1136.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1137 Then
                With btn1137
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1137.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1137.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1137.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1137.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1138 Then
                With btn1138
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1138.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1138.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1138.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1138.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1139 Then
                With btn1139
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1139.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1139.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1139.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1139.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1140 Then
                With btn1140
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1140.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1140.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1140.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1140.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1141 Then
                With btn1141
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1141.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1141.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1141.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1141.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1142 Then
                With btn1142
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1142.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1142.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1142.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1142.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1143 Then
                With btn1143
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1143.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1143.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1143.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1143.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1144 Then
                With btn1144
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1144.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1144.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1144.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1144.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1145 Then
                With btn1145
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1145.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1145.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1145.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1145.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1146 Then
                With btn1146
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1146.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1146.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1146.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1146.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1147 Then
                With btn1147
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1147.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1147.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1147.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1147.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1148 Then
                With btn1148
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1148.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1148.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1148.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1148.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1149 Then
                With btn1149
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1149.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1149.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1149.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1149.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1150 Then
                With btn1150
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1150.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1150.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1150.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1150.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1151 Then
                With btn1151
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1151.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1151.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1151.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1151.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1152 Then
                With btn1152
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1152.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1152.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1152.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1152.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1153 Then
                With btn1153
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1153.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1153.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1153.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1153.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1154 Then
                With btn1154
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1154.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1154.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1154.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1154.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1155 Then
                With btn1155
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1155.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1155.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1155.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1155.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1156 Then
                With btn1156
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1156.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1156.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1156.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1156.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1157 Then
                With btn1157
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1157.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1157.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1157.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1157.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1158 Then
                With btn1158
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1158.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1158.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1158.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1158.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1159 Then
                With btn1159
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1159.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1159.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1159.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1159.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1160 Then
                With btn1160
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1160.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1160.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1160.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1160.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1161 Then
                With btn1161
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1161.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1161.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1161.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1161.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1162 Then
                With btn1162
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1162.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1162.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1162.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1162.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1163 Then
                With btn1163
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1163.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1163.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1163.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1163.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1164 Then
                With btn1164
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1164.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1164.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1164.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1164.BackColor = Color.Red
                End If
            End If

        Next

        SetControlsVisible(False)

    End Sub
    Private Sub btn1101_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1101.Click

        Logon.mintBJCNumber = 1101
        VehicleInformationFromAvailablity.Show()

    End Sub

    Private Sub btn1102_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1102.Click

        Logon.mintBJCNumber = 1102
        VehicleInformationFromAvailablity.Show()

    End Sub

    Private Sub btn1103_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1103.Click

        Logon.mintBJCNumber = 1103
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1104_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1104.Click

        Logon.mintBJCNumber = 1104
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1105_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1105.Click

        Logon.mintBJCNumber = 1105
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1106_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1106.Click

        Logon.mintBJCNumber = 1106
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1107_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1107.Click

        Logon.mintBJCNumber = 1107
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1108_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1108.Click

        Logon.mintBJCNumber = 1108
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1109_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1109.Click

        Logon.mintBJCNumber = 1109
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1110_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1110.Click

        Logon.mintBJCNumber = 1110
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1111_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1111.Click

        Logon.mintBJCNumber = 1111
        VehicleInformationFromAvailablity.Show()

    End Sub

    Private Sub btn1112_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1112.Click

        Logon.mintBJCNumber = 1112
        VehicleInformationFromAvailablity.Show()

    End Sub

    Private Sub btn1113_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1113.Click

        Logon.mintBJCNumber = 1113
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1114_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1114.Click

        Logon.mintBJCNumber = 1114
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1115_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1115.Click

        Logon.mintBJCNumber = 1115
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1116_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1116.Click

        Logon.mintBJCNumber = 1116
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1117_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1117.Click

        Logon.mintBJCNumber = 1117
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1118_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1118.Click

        Logon.mintBJCNumber = 1118
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1119_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1119.Click

        Logon.mintBJCNumber = 1119
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1120_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1120.Click

        Logon.mintBJCNumber = 1120
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1121_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1121.Click

        Logon.mintBJCNumber = 1121
        VehicleInformationFromAvailablity.Show()

    End Sub

    Private Sub btn1122_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1122.Click

        Logon.mintBJCNumber = 1122
        VehicleInformationFromAvailablity.Show()

    End Sub

    Private Sub btn1123_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1123.Click

        Logon.mintBJCNumber = 1123
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1124_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1124.Click

        Logon.mintBJCNumber = 1124
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1125_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1125.Click

        Logon.mintBJCNumber = 1125
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1126_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1126.Click

        Logon.mintBJCNumber = 1126
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1127_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1127.Click

        Logon.mintBJCNumber = 1127
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1128_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1128.Click

        Logon.mintBJCNumber = 1128
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1129_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1129.Click

        Logon.mintBJCNumber = 1129
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1130_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1130.Click

        Logon.mintBJCNumber = 1130
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1131_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1131.Click

        Logon.mintBJCNumber = 1131
        VehicleInformationFromAvailablity.Show()

    End Sub

    Private Sub btn1132_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1132.Click

        Logon.mintBJCNumber = 1132
        VehicleInformationFromAvailablity.Show()

    End Sub

    Private Sub btn1133_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1133.Click

        Logon.mintBJCNumber = 1133
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1134_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1134.Click

        Logon.mintBJCNumber = 1134
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1135_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1135.Click

        Logon.mintBJCNumber = 1135
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1136_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1136.Click

        Logon.mintBJCNumber = 1136
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1137_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1137.Click

        Logon.mintBJCNumber = 1137
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1138_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1138.Click

        Logon.mintBJCNumber = 1138
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1139_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1139.Click

        Logon.mintBJCNumber = 1139
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1140_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1140.Click

        Logon.mintBJCNumber = 1140
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1141_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1141.Click

        Logon.mintBJCNumber = 1141
        VehicleInformationFromAvailablity.Show()

    End Sub

    Private Sub btn1142_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1142.Click

        Logon.mintBJCNumber = 1142
        VehicleInformationFromAvailablity.Show()

    End Sub

    Private Sub btn1143_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1143.Click

        Logon.mintBJCNumber = 1143
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1144_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1144.Click

        Logon.mintBJCNumber = 1144
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1145_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1145.Click

        Logon.mintBJCNumber = 1145
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1146_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1146.Click

        Logon.mintBJCNumber = 1146
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1147_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1147.Click

        Logon.mintBJCNumber = 1147
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1148_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1148.Click

        Logon.mintBJCNumber = 1148
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1149_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1149.Click

        Logon.mintBJCNumber = 1149
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1150_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1150.Click

        Logon.mintBJCNumber = 1150
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1151_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1151.Click

        Logon.mintBJCNumber = 1151
        VehicleInformationFromAvailablity.Show()

    End Sub

    Private Sub btn1152_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1152.Click

        Logon.mintBJCNumber = 1152
        VehicleInformationFromAvailablity.Show()

    End Sub

    Private Sub btn1153_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1153.Click

        Logon.mintBJCNumber = 1153
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1154_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1154.Click

        Logon.mintBJCNumber = 1154
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1155_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1155.Click

        Logon.mintBJCNumber = 1155
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1156_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1156.Click

        Logon.mintBJCNumber = 1156
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1157_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1157.Click

        Logon.mintBJCNumber = 1157
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1158_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1158.Click

        Logon.mintBJCNumber = 1158
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1159_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1159.Click

        Logon.mintBJCNumber = 1159
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1160_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1160.Click

        Logon.mintBJCNumber = 1160
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1161_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1161.Click

        Logon.mintBJCNumber = 1161
        VehicleInformationFromAvailablity.Show()

    End Sub

    Private Sub btn1162_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1162.Click

        Logon.mintBJCNumber = 1162
        VehicleInformationFromAvailablity.Show()

    End Sub

    Private Sub btn1163_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1163.Click

        Logon.mintBJCNumber = 1163
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1164_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1164.Click

        Logon.mintBJCNumber = 1164
        VehicleInformationFromAvailablity.Show()

    End Sub
End Class