'Title:     1200 Series Availability
'Date:      8/6/13
'Author:    Terry Holmes

Option Strict On

Public Class VehicleSeries1200Availability

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

    Private Sub VehicleSeries1200Availability_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'This routine runs during form load
        SetDataBindings()
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

            If intBJCNumber = 1201 Then
                With btn1201
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1201.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1201.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1201.BackColor = Color.Black
                End If
                If strDownForRepairs = "YES" Then
                    btn1201.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1202 Then
                With btn1202
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1202.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1202.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1202.BackColor = Color.Black
                End If
                If strDownForRepairs = "YES" And strActive = "YES" Then
                    btn1202.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1203 Then
                With btn1203
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1203.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1203.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1203.BackColor = Color.Black
                End If
                If strDownForRepairs = "YES" And strActive = "YES" Then
                    btn1203.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1204 Then
                With btn1204
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1204.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1204.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1204.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1204.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1205 Then
                With btn1205
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1205.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1205.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1205.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1205.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1206 Then
                With btn1206
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1206.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1206.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1206.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1206.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1207 Then
                With btn1207
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1207.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1207.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1207.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1207.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1208 Then
                With btn1208
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1208.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1208.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1208.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1208.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1209 Then
                With btn1209
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1209.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1209.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1209.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1209.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1210 Then
                With btn1210
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1210.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1210.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1210.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1210.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1211 Then
                With btn1211
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1211.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1211.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1211.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1211.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1212 Then
                With btn1212
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1212.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1212.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1212.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1212.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1213 Then
                With btn1213
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1213.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1213.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1213.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1213.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1214 Then
                With btn1214
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1214.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1214.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1214.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1214.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1215 Then
                With btn1215
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1215.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1215.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1215.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1215.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1216 Then
                With btn1216
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1216.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1216.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1216.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1216.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1217 Then
                With btn1217
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1217.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1217.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1217.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1217.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1218 Then
                With btn1218
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1218.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1218.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1218.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1218.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1219 Then
                With btn1219
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1219.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1219.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1219.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1219.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1220 Then
                With btn1220
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1220.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1220.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1220.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1220.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1221 Then
                With btn1221
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1221.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1221.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1221.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1221.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1222 Then
                With btn1222
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1222.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1222.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1222.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1222.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1223 Then
                With btn1223
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1223.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1223.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1223.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1223.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1224 Then
                With btn1224
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1224.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1224.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1224.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1224.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1225 Then
                With btn1225
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1225.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1225.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1225.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1225.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1226 Then
                With btn1226
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1226.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1226.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1226.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1226.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1227 Then
                With btn1227
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1227.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1227.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1227.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1227.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1228 Then
                With btn1228
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1228.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1228.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1228.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1228.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1229 Then
                With btn1229
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1229.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1229.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1229.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1229.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1230 Then
                With btn1230
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1230.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1230.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1230.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1230.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1231 Then
                With btn1231
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1231.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1231.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1231.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1231.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1232 Then
                With btn1232
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1232.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1232.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1232.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1232.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1233 Then
                With btn1233
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1233.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1233.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1233.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1233.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1234 Then
                With btn1234
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1234.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1234.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1234.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1234.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1235 Then
                With btn1235
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1235.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1235.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1235.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1235.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1236 Then
                With btn1236
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1236.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1236.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1236.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1236.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1237 Then
                With btn1237
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1237.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1237.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1237.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1237.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1238 Then
                With btn1238
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1238.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1238.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1238.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1238.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1239 Then
                With btn1239
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1239.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1239.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1239.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1239.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1240 Then
                With btn1240
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1240.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1240.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1240.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1240.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1241 Then
                With btn1241
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1241.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1241.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1241.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1241.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1242 Then
                With btn1242
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1242.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1242.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1242.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1242.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1243 Then
                With btn1243
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1243.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1243.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1243.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1243.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1244 Then
                With btn1244
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1244.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1244.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1244.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1244.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1245 Then
                With btn1245
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1245.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1245.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1245.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1245.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1246 Then
                With btn1246
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1246.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1246.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1246.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1246.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1247 Then
                With btn1247
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1247.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1247.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1247.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1247.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1248 Then
                With btn1248
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1248.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1248.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1248.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1248.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1249 Then
                With btn1249
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1249.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1249.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1249.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1249.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1250 Then
                With btn1250
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1250.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1250.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1250.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1250.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1251 Then
                With btn1251
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1251.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1251.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1251.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1251.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1252 Then
                With btn1252
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1252.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1252.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1252.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1252.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1253 Then
                With btn1253
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1253.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1253.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1253.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1253.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1254 Then
                With btn1254
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1254.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1254.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1254.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1254.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1255 Then
                With btn1255
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1255.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1255.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1255.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1255.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1256 Then
                With btn1256
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1256.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1256.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1256.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1256.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1257 Then
                With btn1257
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1257.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1257.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1257.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1257.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1258 Then
                With btn1258
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1258.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1258.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1258.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1258.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1259 Then
                With btn1259
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1259.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1259.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1259.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1259.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1260 Then
                With btn1260
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1260.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1260.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1260.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1260.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1261 Then
                With btn1261
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1261.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1261.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1261.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1261.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1262 Then
                With btn1262
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1262.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1262.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1262.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1262.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1263 Then
                With btn1263
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1263.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1263.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1263.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1263.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1264 Then
                With btn1264
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1264.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1264.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1264.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1264.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1265 Then
                With btn1265
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1265.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1265.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1265.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1265.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1266 Then
                With btn1266
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1266.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1266.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1266.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1266.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1267 Then
                With btn1267
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1267.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1267.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1267.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1267.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1268 Then
                With btn1268
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1268.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1268.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1268.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1268.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1269 Then
                With btn1269
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1269.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1269.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1269.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1269.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1270 Then
                With btn1270
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1270.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1270.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1270.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1270.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1271 Then
                With btn1271
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1271.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1271.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1271.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1271.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1272 Then
                With btn1272
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1272.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1272.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1272.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1272.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1273 Then
                With btn1273
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1273.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1273.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1273.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1273.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1274 Then
                With btn1274
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1274.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1274.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1274.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1274.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1275 Then
                With btn1275
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1275.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1275.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1275.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1275.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1276 Then
                With btn1276
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1276.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1276.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1276.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1276.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1277 Then
                With btn1277
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1277.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1277.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1277.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1277.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1278 Then
                With btn1278
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1278.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1278.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1278.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1278.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1279 Then
                With btn1279
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1279.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1279.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1279.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1279.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1280 Then
                With btn1280
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1280.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1280.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1280.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1280.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1281 Then
                With btn1281
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1281.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1281.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1281.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1281.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1282 Then
                With btn1282
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1282.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1282.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1282.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1282.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1283 Then
                With btn1283
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1283.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1283.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1283.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1283.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1284 Then
                With btn1284
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1284.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1284.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1284.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1284.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1285 Then
                With btn1285
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1285.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1285.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1285.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1285.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1286 Then
                With btn1286
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1286.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1286.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1286.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1286.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1287 Then
                With btn1287
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1287.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1287.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1287.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1287.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1288 Then
                With btn1288
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1288.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1288.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1288.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1288.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1289 Then
                With btn1289
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1289.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1289.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1289.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1289.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1290 Then
                With btn1290
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1290.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1290.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1290.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1290.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1291 Then
                With btn1291
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1291.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1291.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1291.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1291.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1292 Then
                With btn1292
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1292.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1292.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1292.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1292.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1293 Then
                With btn1293
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1293.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1293.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1293.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1293.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1294 Then
                With btn1294
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1294.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1294.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1294.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1294.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1295 Then
                With btn1295
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1295.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1295.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1295.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1295.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1296 Then
                With btn1296
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1296.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1296.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1296.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1296.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1297 Then
                With btn1297
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1297.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1297.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1297.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1297.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1298 Then
                With btn1298
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1298.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1298.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1298.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1298.BackColor = Color.Red
                End If
            End If
            If intBJCNumber = 1299 Then
                With btn1299
                    .Enabled = True
                    .Visible = True
                    .ForeColor = Color.White
                End With

                If strActive = "YES" And strAvailable = "YES" And strDownForRepairs = "NO" Then
                    btn1299.BackColor = Color.Green
                End If
                If strActive = "YES" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1299.BackColor = Color.Blue
                End If
                If strActive = "NO" And strAvailable = "NO" And strDownForRepairs = "NO" Then
                    btn1299.BackColor = Color.Black
                End If
                If strActive = "YES" And strDownForRepairs = "YES" Then
                    btn1299.BackColor = Color.Red
                End If
            End If
        Next

        SetControlsVisible(False)

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

    Private Sub btn1201_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1201.Click

        Logon.mintBJCNumber = 1201
        VehicleInformationFromAvailablity.Show()

    End Sub

    Private Sub btn1202_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1202.Click

        Logon.mintBJCNumber = 1202
        VehicleInformationFromAvailablity.Show()

    End Sub

    Private Sub btn1203_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1203.Click

        Logon.mintBJCNumber = 1203
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1204_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1204.Click

        Logon.mintBJCNumber = 1204
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1205_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1205.Click

        Logon.mintBJCNumber = 1205
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1206_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1206.Click

        Logon.mintBJCNumber = 1206
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1207_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1207.Click

        Logon.mintBJCNumber = 1207
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1208_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1208.Click

        Logon.mintBJCNumber = 1208
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1209_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1209.Click

        Logon.mintBJCNumber = 1209
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1210_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1210.Click

        Logon.mintBJCNumber = 1210
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1211_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1211.Click

        Logon.mintBJCNumber = 1211
        VehicleInformationFromAvailablity.Show()

    End Sub

    Private Sub btn1212_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1212.Click

        Logon.mintBJCNumber = 1212
        VehicleInformationFromAvailablity.Show()

    End Sub

    Private Sub btn1213_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1213.Click

        Logon.mintBJCNumber = 1213
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1214_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1214.Click

        Logon.mintBJCNumber = 1214
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1215_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1215.Click

        Logon.mintBJCNumber = 1215
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1216_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1216.Click

        Logon.mintBJCNumber = 1216
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1217_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1217.Click

        Logon.mintBJCNumber = 1217
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1218_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1218.Click

        Logon.mintBJCNumber = 1218
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1219_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1219.Click

        Logon.mintBJCNumber = 1219
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1220_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1220.Click

        Logon.mintBJCNumber = 1220
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1221_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1221.Click

        Logon.mintBJCNumber = 1221
        VehicleInformationFromAvailablity.Show()

    End Sub

    Private Sub btn1222_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1222.Click

        Logon.mintBJCNumber = 1222
        VehicleInformationFromAvailablity.Show()

    End Sub

    Private Sub btn1223_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1223.Click

        Logon.mintBJCNumber = 1223
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1224_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1224.Click

        Logon.mintBJCNumber = 1224
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1225_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1225.Click

        Logon.mintBJCNumber = 1225
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1226_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1226.Click

        Logon.mintBJCNumber = 1226
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1227_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1227.Click

        Logon.mintBJCNumber = 1227
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1228_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1228.Click

        Logon.mintBJCNumber = 1228
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1229_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1229.Click

        Logon.mintBJCNumber = 1229
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1230_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1230.Click

        Logon.mintBJCNumber = 1230
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1231_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1231.Click

        Logon.mintBJCNumber = 1231
        VehicleInformationFromAvailablity.Show()

    End Sub

    Private Sub btn1232_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1232.Click

        Logon.mintBJCNumber = 1232
        VehicleInformationFromAvailablity.Show()

    End Sub

    Private Sub btn1233_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1233.Click

        Logon.mintBJCNumber = 1233
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1234_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1234.Click

        Logon.mintBJCNumber = 1234
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1235_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1235.Click

        Logon.mintBJCNumber = 1235
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1236_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1236.Click

        Logon.mintBJCNumber = 1236
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1237_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1237.Click

        Logon.mintBJCNumber = 1237
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1238_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1238.Click

        Logon.mintBJCNumber = 1238
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1239_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1239.Click

        Logon.mintBJCNumber = 1239
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1240_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1240.Click

        Logon.mintBJCNumber = 1240
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1241_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1241.Click

        Logon.mintBJCNumber = 1241
        VehicleInformationFromAvailablity.Show()

    End Sub

    Private Sub btn1242_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1242.Click

        Logon.mintBJCNumber = 1242
        VehicleInformationFromAvailablity.Show()

    End Sub

    Private Sub btn1243_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1243.Click

        Logon.mintBJCNumber = 1243
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1244_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1244.Click

        Logon.mintBJCNumber = 1244
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1245_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1245.Click

        Logon.mintBJCNumber = 1245
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1246_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1246.Click

        Logon.mintBJCNumber = 1246
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1247_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1247.Click

        Logon.mintBJCNumber = 1247
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1248_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1248.Click

        Logon.mintBJCNumber = 1248
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1249_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1249.Click

        Logon.mintBJCNumber = 1249
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1250_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1250.Click

        Logon.mintBJCNumber = 1250
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1251_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1251.Click

        Logon.mintBJCNumber = 1251
        VehicleInformationFromAvailablity.Show()

    End Sub

    Private Sub btn1252_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1252.Click

        Logon.mintBJCNumber = 1252
        VehicleInformationFromAvailablity.Show()

    End Sub

    Private Sub btn1253_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1253.Click

        Logon.mintBJCNumber = 1253
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1254_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1254.Click

        Logon.mintBJCNumber = 1254
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1255_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1255.Click

        Logon.mintBJCNumber = 1255
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1256_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1256.Click

        Logon.mintBJCNumber = 1256
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1257_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1257.Click

        Logon.mintBJCNumber = 1257
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1258_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1258.Click

        Logon.mintBJCNumber = 1258
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1259_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1259.Click

        Logon.mintBJCNumber = 1259
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1260_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1260.Click

        Logon.mintBJCNumber = 1260
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1261_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1261.Click

        Logon.mintBJCNumber = 1261
        VehicleInformationFromAvailablity.Show()

    End Sub

    Private Sub btn1262_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1262.Click

        Logon.mintBJCNumber = 1262
        VehicleInformationFromAvailablity.Show()

    End Sub

    Private Sub btn1263_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1263.Click

        Logon.mintBJCNumber = 1263
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1264_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1264.Click

        Logon.mintBJCNumber = 1264
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1265_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1265.Click

        Logon.mintBJCNumber = 1265
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1266_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1266.Click

        Logon.mintBJCNumber = 1266
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1267_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1267.Click

        Logon.mintBJCNumber = 1267
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1268_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1268.Click

        Logon.mintBJCNumber = 1268
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1269_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1269.Click

        Logon.mintBJCNumber = 1269
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1270_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1270.Click

        Logon.mintBJCNumber = 1270
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1271_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1271.Click

        Logon.mintBJCNumber = 1271
        VehicleInformationFromAvailablity.Show()

    End Sub

    Private Sub btn1272_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1272.Click

        Logon.mintBJCNumber = 1272
        VehicleInformationFromAvailablity.Show()

    End Sub

    Private Sub btn1273_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1273.Click

        Logon.mintBJCNumber = 1273
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1274_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1274.Click

        Logon.mintBJCNumber = 1274
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1275_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1275.Click

        Logon.mintBJCNumber = 1275
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1276_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1276.Click

        Logon.mintBJCNumber = 1276
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1277_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1277.Click

        Logon.mintBJCNumber = 1277
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1278_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1278.Click

        Logon.mintBJCNumber = 1278
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1279_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1279.Click

        Logon.mintBJCNumber = 1279
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1280_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1280.Click

        Logon.mintBJCNumber = 1280
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1281_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1281.Click

        Logon.mintBJCNumber = 1281
        VehicleInformationFromAvailablity.Show()

    End Sub

    Private Sub btn1282_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1282.Click

        Logon.mintBJCNumber = 1282
        VehicleInformationFromAvailablity.Show()

    End Sub

    Private Sub btn1283_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1283.Click

        Logon.mintBJCNumber = 1283
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1284_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1284.Click

        Logon.mintBJCNumber = 1284
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1285_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1285.Click

        Logon.mintBJCNumber = 1285
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1286_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1286.Click

        Logon.mintBJCNumber = 1286
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1287_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1287.Click

        Logon.mintBJCNumber = 1287
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1288_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1288.Click

        Logon.mintBJCNumber = 1288
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1289_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1289.Click

        Logon.mintBJCNumber = 1289
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1290_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1290.Click

        Logon.mintBJCNumber = 1290
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1291_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1291.Click

        Logon.mintBJCNumber = 1291
        VehicleInformationFromAvailablity.Show()

    End Sub

    Private Sub btn1292_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1292.Click

        Logon.mintBJCNumber = 1292
        VehicleInformationFromAvailablity.Show()

    End Sub

    Private Sub btn1293_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1293.Click

        Logon.mintBJCNumber = 1293
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1294_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1294.Click

        Logon.mintBJCNumber = 1294
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1295_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1295.Click

        Logon.mintBJCNumber = 1295
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1296_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1296.Click

        Logon.mintBJCNumber = 1296
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1297_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1297.Click

        Logon.mintBJCNumber = 1297
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1298_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1298.Click

        Logon.mintBJCNumber = 1298
        VehicleInformationFromAvailablity.Show()

    End Sub
    Private Sub btn1299_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1299.Click

        Logon.mintBJCNumber = 1299
        VehicleInformationFromAvailablity.Show()

    End Sub
End Class