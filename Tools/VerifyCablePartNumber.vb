'Title:         Verify Cable Part Number
'Date:          June 10, 2014
'Name:          Terry Holmes

'Description:   This form will verify that a part number does not currently exist and therefore
'               can be saved

Option Strict On

Public Class VerifyCablePartNumber

    'Setting Modular Variables

   

    Dim TheInputDataValidation As New InputDataValidation

    Private addingBoolean As Boolean = False
    Private editingBoolean As Boolean = False
    Private previousSelectedIndex As Integer
    Dim mintNumuberOfRecords As Integer

    Dim LogDateTime As Date = DateAndTime.Now
    Dim strLogDateTime As String

    'Setting global variable
    Dim mintSelectedIndex(20) As Integer
    Dim mintSelectedIndexCounter As Integer = 0
    Dim mintSelectedIndexUpperLimit As Integer

    Dim mintTypeID As Integer

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
    Private Sub VerifyCablePartNumber_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'This routine runs when the form is loaded up

        'Setting local variables
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim strPartNumberForSearch As String
        Dim strPartNumberFromTable As String
        Dim strCategoryForSearch As String
        Dim strCategoryFromTable As String
        Dim blnFatalError As Boolean = False

        'This Try - Catch is used to protect the make sure that the program loads correctly
        'And if there is a problem, the exception is routed to a Message Box, instead of 
        'the whole program crashing
        Try

            'This will bind the controls to the data source
           

            'Setting Conditions for Loop
            intNumberOfRecords = cboTypeID.Items.Count - 1
            strCategoryForSearch = Logon.mstrReelCategory
            strPartNumberForSearch = Logon.mstrPartNumber

            'Peforming Loop
            For intCounter = 0 To intNumberOfRecords

                cboTypeID.SelectedIndex = intCounter
                strCategoryFromTable = txtCategory.Text
                strPartNumberFromTable = txtPartNumber.Text

                'Conditions to see if the part number exists
                If strCategoryForSearch = strCategoryFromTable Then
                    If strPartNumberForSearch = strPartNumberFromTable Then
                        blnFatalError = True
                    End If
                End If

            Next

            Logon.mbolFatalError = blnFatalError
            Me.Close()

        Catch ex As Exception

            'If an exception is thrown, it is rounted here
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub
End Class