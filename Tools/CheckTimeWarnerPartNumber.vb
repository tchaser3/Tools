'Title:         Check Time Warner Part Number
'Date:          2-17-15
'Author:        Terry Holmes

'Description:   This class will check for a part number to see if it is a Time Warner Part Number

Option Strict On

Public Class CheckTimeWarnerPartNumber

    'Setting up to call a class
    Dim TheInputDataValidation As New InputDataValidation

    Public Function CheckPartNumber(ByVal strValueForValidation As String) As Boolean

        'Creating Local Variables
        Dim blnNotaTWCPartNumber As Boolean = False
        Dim intPartNumberForValidation As Integer

        Dim intCharacterCount As Integer

        intCharacterCount = strValueForValidation.Length

        If intCharacterCount > 7 Then
            blnNotaTWCPartNumber = True
        Else
            'Calling validation class
            blnNotaTWCPartNumber = TheInputDataValidation.VerifyIntegerData(strValueForValidation)
        End If

        If blnNotaTWCPartNumber = False Then

            'Changing the type of variable
            intPartNumberForValidation = CInt(strValueForValidation)

            'If Statements to see if the part number meets the requirements
            If intPartNumberForValidation < 1000000 Or intPartNumberForValidation > 9999999 Then
                blnNotaTWCPartNumber = True
            End If

        End If

        'return to calling sub-routine
        Return blnNotaTWCPartNumber

    End Function

End Class
