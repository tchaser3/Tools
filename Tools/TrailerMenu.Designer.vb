<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TrailerMenu
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnMainMenu = New System.Windows.Forms.Button()
        Me.btnAbout = New System.Windows.Forms.Button()
        Me.btnSignOutTrailer = New System.Windows.Forms.Button()
        Me.SignInTrailer = New System.Windows.Forms.Button()
        Me.btnAvailableTrailers = New System.Windows.Forms.Button()
        Me.btnTrailersInUse = New System.Windows.Forms.Button()
        Me.btnViewTrailerHistory = New System.Windows.Forms.Button()
        Me.btnUpdateTrailerWorkOrder = New System.Windows.Forms.Button()
        Me.btnCreateTrailerWorkOrder = New System.Windows.Forms.Button()
        Me.btnViewTrailerInspections = New System.Windows.Forms.Button()
        Me.btnCloseTrailerWorkOrder = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(11, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(359, 42)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Trailer Menu"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnClose
        '
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Location = New System.Drawing.Point(195, 391)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(2)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(176, 51)
        Me.btnClose.TabIndex = 11
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnMainMenu
        '
        Me.btnMainMenu.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMainMenu.Location = New System.Drawing.Point(10, 391)
        Me.btnMainMenu.Margin = New System.Windows.Forms.Padding(2)
        Me.btnMainMenu.Name = "btnMainMenu"
        Me.btnMainMenu.Size = New System.Drawing.Size(176, 51)
        Me.btnMainMenu.TabIndex = 10
        Me.btnMainMenu.Text = "Main Menu"
        Me.btnMainMenu.UseVisualStyleBackColor = True
        '
        'btnAbout
        '
        Me.btnAbout.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAbout.Location = New System.Drawing.Point(195, 326)
        Me.btnAbout.Margin = New System.Windows.Forms.Padding(2)
        Me.btnAbout.Name = "btnAbout"
        Me.btnAbout.Size = New System.Drawing.Size(175, 51)
        Me.btnAbout.TabIndex = 9
        Me.btnAbout.Text = "About"
        Me.btnAbout.UseVisualStyleBackColor = True
        '
        'btnSignOutTrailer
        '
        Me.btnSignOutTrailer.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSignOutTrailer.Location = New System.Drawing.Point(11, 79)
        Me.btnSignOutTrailer.Margin = New System.Windows.Forms.Padding(2)
        Me.btnSignOutTrailer.Name = "btnSignOutTrailer"
        Me.btnSignOutTrailer.Size = New System.Drawing.Size(175, 51)
        Me.btnSignOutTrailer.TabIndex = 0
        Me.btnSignOutTrailer.Text = "Sign Out Trailer"
        Me.btnSignOutTrailer.UseVisualStyleBackColor = True
        '
        'SignInTrailer
        '
        Me.SignInTrailer.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SignInTrailer.Location = New System.Drawing.Point(195, 79)
        Me.SignInTrailer.Margin = New System.Windows.Forms.Padding(2)
        Me.SignInTrailer.Name = "SignInTrailer"
        Me.SignInTrailer.Size = New System.Drawing.Size(175, 51)
        Me.SignInTrailer.TabIndex = 1
        Me.SignInTrailer.Text = "Sign In Trailer"
        Me.SignInTrailer.UseVisualStyleBackColor = True
        '
        'btnAvailableTrailers
        '
        Me.btnAvailableTrailers.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAvailableTrailers.Location = New System.Drawing.Point(195, 140)
        Me.btnAvailableTrailers.Margin = New System.Windows.Forms.Padding(2)
        Me.btnAvailableTrailers.Name = "btnAvailableTrailers"
        Me.btnAvailableTrailers.Size = New System.Drawing.Size(175, 51)
        Me.btnAvailableTrailers.TabIndex = 3
        Me.btnAvailableTrailers.Text = "Available Trailers"
        Me.btnAvailableTrailers.UseVisualStyleBackColor = True
        '
        'btnTrailersInUse
        '
        Me.btnTrailersInUse.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTrailersInUse.Location = New System.Drawing.Point(11, 140)
        Me.btnTrailersInUse.Margin = New System.Windows.Forms.Padding(2)
        Me.btnTrailersInUse.Name = "btnTrailersInUse"
        Me.btnTrailersInUse.Size = New System.Drawing.Size(175, 51)
        Me.btnTrailersInUse.TabIndex = 2
        Me.btnTrailersInUse.Text = "Trailers In Use"
        Me.btnTrailersInUse.UseVisualStyleBackColor = True
        '
        'btnViewTrailerHistory
        '
        Me.btnViewTrailerHistory.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnViewTrailerHistory.Location = New System.Drawing.Point(11, 200)
        Me.btnViewTrailerHistory.Margin = New System.Windows.Forms.Padding(2)
        Me.btnViewTrailerHistory.Name = "btnViewTrailerHistory"
        Me.btnViewTrailerHistory.Size = New System.Drawing.Size(175, 51)
        Me.btnViewTrailerHistory.TabIndex = 4
        Me.btnViewTrailerHistory.Text = "View Trailer History"
        Me.btnViewTrailerHistory.UseVisualStyleBackColor = True
        '
        'btnUpdateTrailerWorkOrder
        '
        Me.btnUpdateTrailerWorkOrder.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdateTrailerWorkOrder.Location = New System.Drawing.Point(195, 261)
        Me.btnUpdateTrailerWorkOrder.Margin = New System.Windows.Forms.Padding(2)
        Me.btnUpdateTrailerWorkOrder.Name = "btnUpdateTrailerWorkOrder"
        Me.btnUpdateTrailerWorkOrder.Size = New System.Drawing.Size(175, 51)
        Me.btnUpdateTrailerWorkOrder.TabIndex = 7
        Me.btnUpdateTrailerWorkOrder.Text = "Update Trailer Work Order"
        Me.btnUpdateTrailerWorkOrder.UseVisualStyleBackColor = True
        '
        'btnCreateTrailerWorkOrder
        '
        Me.btnCreateTrailerWorkOrder.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCreateTrailerWorkOrder.Location = New System.Drawing.Point(11, 261)
        Me.btnCreateTrailerWorkOrder.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCreateTrailerWorkOrder.Name = "btnCreateTrailerWorkOrder"
        Me.btnCreateTrailerWorkOrder.Size = New System.Drawing.Size(175, 51)
        Me.btnCreateTrailerWorkOrder.TabIndex = 6
        Me.btnCreateTrailerWorkOrder.Text = "Create Trailer Work Order"
        Me.btnCreateTrailerWorkOrder.UseVisualStyleBackColor = True
        '
        'btnViewTrailerInspections
        '
        Me.btnViewTrailerInspections.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnViewTrailerInspections.Location = New System.Drawing.Point(195, 200)
        Me.btnViewTrailerInspections.Margin = New System.Windows.Forms.Padding(2)
        Me.btnViewTrailerInspections.Name = "btnViewTrailerInspections"
        Me.btnViewTrailerInspections.Size = New System.Drawing.Size(175, 51)
        Me.btnViewTrailerInspections.TabIndex = 5
        Me.btnViewTrailerInspections.Text = "View Trailer Inspections"
        Me.btnViewTrailerInspections.UseVisualStyleBackColor = True
        '
        'btnCloseTrailerWorkOrder
        '
        Me.btnCloseTrailerWorkOrder.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCloseTrailerWorkOrder.Location = New System.Drawing.Point(11, 326)
        Me.btnCloseTrailerWorkOrder.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCloseTrailerWorkOrder.Name = "btnCloseTrailerWorkOrder"
        Me.btnCloseTrailerWorkOrder.Size = New System.Drawing.Size(175, 51)
        Me.btnCloseTrailerWorkOrder.TabIndex = 8
        Me.btnCloseTrailerWorkOrder.Text = "Close Trailer Work Order"
        Me.btnCloseTrailerWorkOrder.UseVisualStyleBackColor = True
        '
        'TrailerMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(386, 476)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnCloseTrailerWorkOrder)
        Me.Controls.Add(Me.btnViewTrailerInspections)
        Me.Controls.Add(Me.btnCreateTrailerWorkOrder)
        Me.Controls.Add(Me.btnUpdateTrailerWorkOrder)
        Me.Controls.Add(Me.btnViewTrailerHistory)
        Me.Controls.Add(Me.btnTrailersInUse)
        Me.Controls.Add(Me.btnAvailableTrailers)
        Me.Controls.Add(Me.SignInTrailer)
        Me.Controls.Add(Me.btnSignOutTrailer)
        Me.Controls.Add(Me.btnAbout)
        Me.Controls.Add(Me.btnMainMenu)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.Label1)
        Me.Name = "TrailerMenu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Trailer Menu"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnMainMenu As System.Windows.Forms.Button
    Friend WithEvents btnAbout As System.Windows.Forms.Button
    Friend WithEvents btnSignOutTrailer As System.Windows.Forms.Button
    Friend WithEvents SignInTrailer As System.Windows.Forms.Button
    Friend WithEvents btnAvailableTrailers As System.Windows.Forms.Button
    Friend WithEvents btnTrailersInUse As System.Windows.Forms.Button
    Friend WithEvents btnViewTrailerHistory As System.Windows.Forms.Button
    Friend WithEvents btnUpdateTrailerWorkOrder As System.Windows.Forms.Button
    Friend WithEvents btnCreateTrailerWorkOrder As System.Windows.Forms.Button
    Friend WithEvents btnViewTrailerInspections As System.Windows.Forms.Button
    Friend WithEvents btnCloseTrailerWorkOrder As System.Windows.Forms.Button
End Class
