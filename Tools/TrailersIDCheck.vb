'Title:     Create a Trailer ID
'Date:      7/12/13
'Author:    Terry Holmes

'Description:   This form is used to create a Trailer ID

'Update:        8-24-15 - Reviewed Code for Optimial Performance

Option Strict On

Public Class TrailersIDCheck

    'Creating Modular Variables
    Private TheTrailersIDCheckDataSet As TrailersIDCheckDataSet
    Private TheTrailersIDCheckDataTier As TrailersIDCheckDataTier
    Private WithEvents TheTrailersIDCheckBindingSource As BindingSource

    Dim LogDateTime As Date = DateAndTime.Now
    Dim strLogDateTime As String
    Friend mintCreatedToolID As Integer

    Private Sub TrailersIDCheck_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'This subroutine runs when the form is loaded
        Dim intTrailerID As Integer

        Try

            'This will bind the controls to the data source
            TheTrailersIDCheckDataTier = New TrailersIDCheckDataTier
            TheTrailersIDCheckDataSet = TheTrailersIDCheckDataTier.GetTrailersIDInformation
            TheTrailersIDCheckBindingSource = New BindingSource

            With TheTrailersIDCheckBindingSource
                .DataSource = TheTrailersIDCheckDataSet
                .DataMember = "trailersidcheck"
                .MoveFirst()
                .MoveLast()
            End With

            With cboTransactionID
                .DataSource = TheTrailersIDCheckBindingSource
                .DisplayMember = "TransactionID"
                .DataBindings.Add("text", TheTrailersIDCheckBindingSource, "TransactionID", False, DataSourceUpdateMode.Never)
            End With

            txtTrailerID.DataBindings.Add("text", TheTrailersIDCheckBindingSource, "TrailerID")
        Catch
            MessageBox.Show("There is a problem with the form loading", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        intTrailerID = CInt(txtTrailerID.Text)
        intTrailerID += 1
        txtTrailerID.Text = CStr(intTrailerID)
        Logon.mintCreatedTransactionID = intTrailerID

        Try
            TheTrailersIDCheckBindingSource.EndEdit()
            TheTrailersIDCheckDataTier.UpdateDB(TheTrailersIDCheckDataSet)

            Me.Close()

        Catch ex As Exception

        End Try
    End Sub

End Class