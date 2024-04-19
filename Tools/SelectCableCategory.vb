'Title:         Select Cable Type
'Date:          1/6/14
'Author:        Terry Holmes

'Description    This will allow the user to select the cable type

Public Class SelectCableCategory

    Dim mstrCableCategory As String

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

        If mstrCableCategory = "" Then
            MessageBox.Show("No Cable Type Selected", "Please Select", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Logon.mstrCategory = mstrCableCategory
            Me.Close()
        End If

    End Sub

    Private Sub rdoCoax_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdoCoax.CheckedChanged

        'This will Set the variable value
        mstrCableCategory = "COAX"

    End Sub

    Private Sub rdoFiber_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdoFiber.CheckedChanged

        'This will Set the variable value
        mstrCableCategory = "FIBER"

    End Sub


    Private Sub rdoDropCable_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdoDropCable.CheckedChanged

        'This will Set the variable value
        mstrCableCategory = "DROP CABLE"

    End Sub

    Private Sub rdoTwistedPair_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdoTwistedPair.CheckedChanged

        'This will Set the variable value
        mstrCableCategory = "TWISTED PAIR"

    End Sub

    Private Sub rdoSpecialtyCable_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdoSpecialtyCable.CheckedChanged

        'This will Set the variable value
        mstrCableCategory = "SPECIALTY CABLE"

    End Sub
End Class