'Title:         Select Cable Part Number\
'Date:          1/6/14
'Author:        Terry Holmes

'Description:   This will allow the user to select a Cable Part Number

Option Strict On

Public Class SelectCablePartNumber

    'Setting Variables for the Cable Type Boxes
    

    Dim TheInputDataValidation As New InputDataValidation

    Private addingBoolean As Boolean = False
    Private editingBoolean As Boolean = False
    Private previousSelectedIndex As Integer
    Dim mintNumuberOfRecords As Integer

    Dim LogDateTime As Date = DateAndTime.Now
    Dim strLogDateTime As String

    'Setting global variable
    Dim mintSelectedIndex(100) As Integer
    Dim mintSelectedIndexCounter As Integer = 0
    Dim mintSelectedIndexUpperLimit As Integer

    Dim mintCableTypeComboBoxUpperLimit As Integer = 0

    Dim mintReelTransactionID As Integer

    Dim mstrCategory As String

    Private Sub SelectCablePartNumber_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim strCategory As String

        'Try - Catch for Cable Type
        Try

            'txtCategory.Visible = True

            'This will bind the controls to the data source
            

            cboTypeID.SelectedIndex = 0

            mintCableTypeComboBoxUpperLimit = cboTypeID.Items.Count - 1
            mintSelectedIndexCounter = 0
            mintSelectedIndexUpperLimit = 0

            mstrCategory = Logon.mstrCategory

            For intCounter = 0 To mintCableTypeComboBoxUpperLimit

                cboTypeID.SelectedIndex = intCounter
                strCategory = txtCategory.Text
                'MessageBox.Show(CStr(txtCategory.Text) + " " + CStr(txtCableType.Text) + " " + CStr(cboTypeID.Text), "There it is", MessageBoxButtons.OK, MessageBoxIcon.Information)
                If strCategory = mstrCategory Then
                    mintSelectedIndex(mintSelectedIndexCounter) = intCounter
                    mintSelectedIndexCounter = mintSelectedIndexCounter + 1
                End If

            Next
            mintSelectedIndexUpperLimit = mintSelectedIndexCounter - 1
            mintSelectedIndexCounter = 5
            cboTypeID.SelectedIndex = mintSelectedIndex(0)
            If mintSelectedIndexUpperLimit > 0 Then
                btnNext.Enabled = True
            End If

            'txtCategory.Visible = False

        Catch ex As Exception

            'If an exception is thrown, it is rounted here
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub setComboBoxBinding()

        'Sets the Combobox Bindings
        With Me.cboTypeID
            If (addingBoolean Or editingBoolean) Then
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.OnValidation
                .DropDownStyle = ComboBoxStyle.Simple
            Else
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.Never
                .DropDownStyle = ComboBoxStyle.DropDownList
            End If
        End With

    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click


        mintSelectedIndexCounter = mintSelectedIndexCounter + 1
        cboTypeID.SelectedIndex = mintSelectedIndex(mintSelectedIndexCounter)

        btnBack.Enabled = True

        If mintSelectedIndexCounter = mintSelectedIndexUpperLimit Then
            btnNext.Enabled = False
        End If

    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click

        mintSelectedIndexCounter = mintSelectedIndexCounter - 1
        cboTypeID.SelectedIndex = mintSelectedIndex(mintSelectedIndexCounter)

        btnNext.Enabled = True

        If mintSelectedIndexCounter = 0 Then
            btnBack.Enabled = False
        End If

    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

        'This Will send the part number to the form
        Logon.mstrCablePartNumber = txtCableTypePartNumber.Text

        cboTypeID.DataBindings.Clear()
        txtCableType.DataBindings.Clear()
        txtCableTypePartNumber.DataBindings.Clear()
        txtCategory.DataBindings.Clear()

        Me.Close()

    End Sub
End Class