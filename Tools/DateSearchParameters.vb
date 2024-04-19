'Title:         Search By Date
'Date:          8/12/13
'Author:        Terry Holmes

'Description:   This form will provide the Starting and Ending Dates for searches

Option Strict On

Public Class DateSearchParameters

    Dim TheInputDataValidation As New InputDataValidation
    Dim mstrTypeOfDateSearch As String = Logon.mstrTypeOfDateSearch
    Friend mdatStartingDate As Date
    Friend mdatEndingDate As Date

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        'Closing the form
        If mstrTypeOfDateSearch = "DAILYVEHICLEINSPECTION" Or mstrTypeOfDateSearch = "WEEKLYVEHICLEINSPECTION" Then
            InspectionsMenu.Show()
        ElseIf mstrTypeOfDateSearch = "VEHICLESHEETAUDIT" Then
            InspectionsMenu.Show()
        Else
            MainMenu.Show()
        End If

        Me.Close()

    End Sub

    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click

        'Setting Local Variables
        Dim strStartingDate As String
        Dim strEndingDate As String
        Dim blnFatalError As Boolean

        'Loading Variables for Validation
        strStartingDate = txtStartingDate.Text
        strEndingDate = txtEndingDate.Text

        'Beginning Validation

        'Checking Starting Date for if it is a Date
        blnFatalError = TheInputDataValidation.VerifyStartingEndingDatesAsDates(strStartingDate)
        If blnFatalError = True Then
            MessageBox.Show("The Starting Date Entered is not a Date", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        'Checking Ending Date for if it is a Date
        blnFatalError = TheInputDataValidation.VerifyStartingEndingDatesAsDates(strEndingDate)
        If blnFatalError = True Then
            MessageBox.Show("The Ending Date Entered is not a Date", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        'Checking Validate for Low Range

        'Checking Starting Date for Range
        mdatStartingDate = CDate(strStartingDate)
        blnFatalError = TheInputDataValidation.VerifyStartingEndingDates(mdatStartingDate)
        If blnFatalError = True Then
            MessageBox.Show("The Starting Date Entered is not within Range", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        'Checking Ending Date for Range
        mdatEndingDate = CDate(strEndingDate)
        blnFatalError = TheInputDataValidation.VerifyStartingEndingDates(mdatEndingDate)
        If blnFatalError = True Then
            MessageBox.Show("The Starting Date Entered is not within Range", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Logon.mdatStartingDate = mdatStartingDate
        Logon.mdatEndingDate = mdatEndingDate
        Logon.mstrTypeOfDateSearch = mstrTypeOfDateSearch

        If mstrTypeOfDateSearch = "DAILYVEHICLEINSPECTION" Then
            SearchDailyInspectionsByDate.Show()
        ElseIf mstrTypeOfDateSearch = "WEEKLYVEHICLEINSPECTION" Then
            SearchWeeklyInspectionsByDate.Show()
        ElseIf mstrTypeOfDateSearch = "VEHICLESHEETAUDIT" Then
            VehicleSheetAuditForm.Show()
        ElseIf mstrTypeOfDateSearch = "CABLEREPORT" Then
            CableReport.Show()
        ElseIf mstrTypeOfDateSearch = "WEEKLYINSPECTIONREPORT" Then
            WeeklyVehicleInspectionsReport.Show()
        ElseIf mstrTypeOfDateSearch = "DAILYVEHICLEINSPECTIONREPORT" Then
            DailyVehicleInspectionReport.Show()
        ElseIf mstrTypeOfDateSearch = "DAILYVEHICLEAUDIT" Then
            VehicleReportIsRunning.Show()
        End If

        Me.Close()

    End Sub

    Private Sub txtStartingDate_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtStartingDate.KeyDown

        If e.KeyCode = Keys.Enter Then
            txtEndingDate.Focus()
        End If

    End Sub

    Private Sub txtEndingDate_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEndingDate.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSubmit.PerformClick()
        End If
    End Sub
End Class