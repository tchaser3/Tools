'Title:         Information Technology ID From
'Date:          9/17/14
'Author:        Terry Holmes

'Description:   This form creates all IDs for the Information Technology Module

Option Strict On

Public Class InformationTechnologyID

    Private TheInformationTechnologyIDDataSet As InformationTechnologyIDDataSet
    Private TheInformationTechnologyIDDataTier As InformationTechnologyDataTier
    Private WithEvents TheInformationTechnologyIDBindingSource As BindingSource

    Private Sub InformationTechnologyID_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'This subroutine will run when the form is loaded

        'Setting local variables
        Dim intCreatedID As Integer

        Try

            'Loading up the data set
            TheInformationTechnologyIDDataTier = New InformationTechnologyDataTier
            TheInformationTechnologyIDDataSet = TheInformationTechnologyIDDataTier.GetInformationTechnologyIDInformation
            TheInformationTechnologyIDBindingSource = New BindingSource

            'Setting up the binding source
            With TheInformationTechnologyIDBindingSource
                .DataSource = TheInformationTechnologyIDDataSet
                .DataMember = "informationtechnologyid"
                .MoveFirst()
                .MoveLast()
            End With

            'Setting up the combo box
            With cboTransactionID
                .DataSource = TheInformationTechnologyIDBindingSource
                .DisplayMember = "TransactionID"
                .DataBindings.Add("text", TheInformationTechnologyIDBindingSource, "TransactionID", False, DataSourceUpdateMode.Never)
            End With

            'Setting up the last control
            txtCreatedID.DataBindings.Add("text", TheInformationTechnologyIDBindingSource, "CreatedID")

            'Getting ready for adding the record
            intCreatedID = CInt(txtCreatedID.Text)
            intCreatedID += 1
            txtCreatedID.Text = CStr(intCreatedID)
            'Calling routines and loading boxes

            'Loading Global variable
            Logon.mintCreatedTransactionID = CInt(intCreatedID)

            'Saving Record
            TheInformationTechnologyIDBindingSource.EndEdit()
            TheInformationTechnologyIDDataTier.UpdateInformationTechnologyIDDB(TheInformationTechnologyIDDataSet)
            Logon.mbolFatalError = False
            Me.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Logon.mbolFatalError = True
        End Try

    End Sub
End Class