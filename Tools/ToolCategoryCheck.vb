'Title:         Tool Category Check
'Date:          4/21/14
'Author:        Terry Holmes

'Description:   This form will confirm that the Tool Category does not exist

Option Strict On

Public Class ToolCategoryCheck

    Private addingBoolean As Boolean = False
    Private editingBoolean As Boolean = False
    Private previousSelectedIndex As Integer
    Dim mintNumuberOfRecords As Integer

    Dim LogDateTime As Date = DateAndTime.Now
    Dim strLogDateTime As String

    'Setting up Tool Category Information
    Private TheToolCategoryDataSet As ToolCategoryDataSet
    Private TheToolCategoryDataTier As ToolsDataTier
    Private WithEvents TheToolCategoryBindingSource As BindingSource

    Private Sub setComboBoxBinding()

        With Me.cboCategoryID
            If (addingBoolean Or editingBoolean) Then
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.OnValidation
                .DropDownStyle = ComboBoxStyle.Simple
            Else
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.Never
                .DropDownStyle = ComboBoxStyle.DropDownList
            End If
        End With
    End Sub

    Private Sub ToolCategoryCheck_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Setting Local Variables
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim blnValueNotFound As Boolean = True
        Dim strValueForSearch As String
        Dim strValueFromTable As String

        'This is used to load up the form
        Try

            'This will bind the controls
            TheToolCategoryDataTier = New ToolsDataTier
            TheToolCategoryDataSet = TheToolCategoryDataTier.GetToolCategoryInformation
            TheToolCategoryBindingSource = New BindingSource

            'Setting up the binding source
            With TheToolCategoryBindingSource
                .DataSource = TheToolCategoryDataSet
                .DataMember = "toolcategory"
                .MoveFirst()
                .MoveLast()
            End With

            'Binding the controls
            With cboCategoryID
                .DataSource = TheToolCategoryBindingSource
                .DisplayMember = "CategoryID"
                .DataBindings.Add("text", TheToolCategoryBindingSource, "CategoryID", False, DataSourceUpdateMode.Never)
            End With

            txtToolCategory.DataBindings.Add("text", TheToolCategoryBindingSource, "ToolCategory")

            'Setting up for value search
            intNumberOfRecords = cboCategoryID.Items.Count - 1
            strValueForSearch = Logon.mstrToolCategory

            'Loop for Search
            For intCounter = 0 To intNumberOfRecords

                'Getting Data
                cboCategoryID.SelectedIndex = intCounter
                strValueFromTable = txtToolCategory.Text
                If strValueForSearch = strValueFromTable Then
                    blnValueNotFound = False
                End If

            Next

            'Setting Global Variable
            Logon.mblnToolCategoryExists = blnValueNotFound

            Me.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
End Class