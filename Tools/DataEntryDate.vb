'Title:         Data Entry Date
'Date:          10/1/13
'Author:        Terry Holmes

'Description:   This form is used to used for the Data Entry Date

Option Strict On

Public Class DataEntryDate

    Dim TheInputDataValidation As New InputDataValidation

    Private Sub btnContinue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContinue.Click

        Dim strValueForValidation As String
        Dim blnFatalError As Boolean

        strValueForValidation = txtDate.Text

        blnFatalError = TheInputDataValidation.VerifyStartingEndingDatesAsDates(strValueForValidation)

        If blnFatalError = True Then
            MessageBox.Show("The Date Entered is not a Date", "Date Incorrect", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Logon.mdatDateForDataEntry = CDate(txtDate.Text)

        If Logon.mstrFormForDataEntry = "DOTFORM" Then
            DailyVehicleInspection.Show()
        ElseIf Logon.mstrFormForDataEntry = "VEHICLEINVENTORY" Then
            VehicleInventorySheets.Show()
        ElseIf Logon.mstrFormForDataEntry = "VEHICLESIGNOUT" Then
            VehiclesSignedOutSheet.Show()
        ElseIf Logon.mstrFormForDataEntry = "VEHICLESINYARD" Then
            VehiclesInYard.Show()
        End If

        Me.Close()

    End Sub

    Private Sub txtDate_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDate.KeyDown

        If e.KeyCode = Keys.Enter Then

            btnContinue.PerformClick()

        End If

    End Sub
End Class