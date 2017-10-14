<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmStart
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmStart))
        Me.lbTilesRemaining = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.BarA = New System.Windows.Forms.HScrollBar
        Me.lbZoom = New System.Windows.Forms.Label
        Me.lbTiles = New System.Windows.Forms.Label
        Me.cmdGetMap = New System.Windows.Forms.Button
        Me.ListMapServers = New System.Windows.Forms.ListBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.ckDG = New System.Windows.Forms.CheckBox
        Me.lbNLat = New System.Windows.Forms.Label
        Me.lbWLon = New System.Windows.Forms.Label
        Me.lbELon = New System.Windows.Forms.Label
        Me.lbSLat = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbTilesRemaining
        '
        Me.lbTilesRemaining.AutoSize = True
        Me.lbTilesRemaining.Location = New System.Drawing.Point(-1, 0)
        Me.lbTilesRemaining.Name = "lbTilesRemaining"
        Me.lbTilesRemaining.Size = New System.Drawing.Size(0, 13)
        Me.lbTilesRemaining.TabIndex = 0
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(141, 71)
        Me.Label11.Name = "Label11"
        Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label11.Size = New System.Drawing.Size(78, 13)
        Me.Label11.TabIndex = 59
        Me.Label11.Text = "East Longitude"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(140, 114)
        Me.Label10.Name = "Label10"
        Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label10.Size = New System.Drawing.Size(76, 13)
        Me.Label10.TabIndex = 60
        Me.Label10.Text = "South Latitude"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(6, 71)
        Me.Label9.Name = "Label9"
        Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label9.Size = New System.Drawing.Size(82, 13)
        Me.Label9.TabIndex = 61
        Me.Label9.Text = "West Longitude"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(6, 26)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(74, 13)
        Me.Label8.TabIndex = 62
        Me.Label8.Text = "North Latitude"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BarA
        '
        Me.BarA.LargeChange = 2
        Me.BarA.Location = New System.Drawing.Point(167, 18)
        Me.BarA.Maximum = 18
        Me.BarA.Name = "BarA"
        Me.BarA.Size = New System.Drawing.Size(70, 20)
        Me.BarA.TabIndex = 2
        '
        'lbZoom
        '
        Me.lbZoom.AutoSize = True
        Me.lbZoom.Location = New System.Drawing.Point(91, 22)
        Me.lbZoom.Name = "lbZoom"
        Me.lbZoom.Size = New System.Drawing.Size(52, 13)
        Me.lbZoom.TabIndex = 67
        Me.lbZoom.Text = "Zoom = 0"
        '
        'lbTiles
        '
        Me.lbTiles.BackColor = System.Drawing.Color.Transparent
        Me.lbTiles.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbTiles.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbTiles.Location = New System.Drawing.Point(6, 19)
        Me.lbTiles.Name = "lbTiles"
        Me.lbTiles.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbTiles.Size = New System.Drawing.Size(79, 19)
        Me.lbTiles.TabIndex = 68
        Me.lbTiles.Text = "Tiles  ="
        Me.lbTiles.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdGetMap
        '
        Me.cmdGetMap.Location = New System.Drawing.Point(296, 173)
        Me.cmdGetMap.Name = "cmdGetMap"
        Me.cmdGetMap.Size = New System.Drawing.Size(77, 25)
        Me.cmdGetMap.TabIndex = 70
        Me.cmdGetMap.Text = "Get Tiles"
        Me.cmdGetMap.UseVisualStyleBackColor = True
        '
        'ListMapServers
        '
        Me.ListMapServers.FormattingEnabled = True
        Me.ListMapServers.Location = New System.Drawing.Point(273, 26)
        Me.ListMapServers.Name = "ListMapServers"
        Me.ListMapServers.Size = New System.Drawing.Size(115, 121)
        Me.ListMapServers.TabIndex = 71
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.BarA)
        Me.GroupBox1.Controls.Add(Me.lbTiles)
        Me.GroupBox1.Controls.Add(Me.lbZoom)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 160)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(248, 48)
        Me.GroupBox1.TabIndex = 72
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Download Size"
        '
        'ckDG
        '
        Me.ckDG.Location = New System.Drawing.Point(9, 115)
        Me.ckDG.Name = "ckDG"
        Me.ckDG.Size = New System.Drawing.Size(88, 32)
        Me.ckDG.TabIndex = 73
        Me.ckDG.Text = "Use Decimal Degrees"
        Me.ckDG.UseVisualStyleBackColor = True
        '
        'lbNLat
        '
        Me.lbNLat.BackColor = System.Drawing.Color.White
        Me.lbNLat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbNLat.Location = New System.Drawing.Point(9, 39)
        Me.lbNLat.Name = "lbNLat"
        Me.lbNLat.Size = New System.Drawing.Size(117, 20)
        Me.lbNLat.TabIndex = 74
        Me.lbNLat.Text = "Label1"
        Me.lbNLat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbWLon
        '
        Me.lbWLon.BackColor = System.Drawing.Color.White
        Me.lbWLon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbWLon.Location = New System.Drawing.Point(9, 84)
        Me.lbWLon.Name = "lbWLon"
        Me.lbWLon.Size = New System.Drawing.Size(117, 20)
        Me.lbWLon.TabIndex = 75
        Me.lbWLon.Text = "Label1"
        Me.lbWLon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbELon
        '
        Me.lbELon.BackColor = System.Drawing.Color.White
        Me.lbELon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbELon.Location = New System.Drawing.Point(143, 84)
        Me.lbELon.Name = "lbELon"
        Me.lbELon.Size = New System.Drawing.Size(117, 20)
        Me.lbELon.TabIndex = 76
        Me.lbELon.Text = "Label1"
        Me.lbELon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbSLat
        '
        Me.lbSLat.BackColor = System.Drawing.Color.White
        Me.lbSLat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbSLat.Location = New System.Drawing.Point(143, 127)
        Me.lbSLat.Name = "lbSLat"
        Me.lbSLat.Size = New System.Drawing.Size(117, 20)
        Me.lbSLat.TabIndex = 77
        Me.lbSLat.Text = "Label1"
        Me.lbSLat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(140, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(109, 32)
        Me.Label1.TabIndex = 78
        Me.Label1.Text = "Click on the boxes to change their values"
        '
        'frmStart
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(405, 223)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lbSLat)
        Me.Controls.Add(Me.lbELon)
        Me.Controls.Add(Me.lbWLon)
        Me.Controls.Add(Me.lbNLat)
        Me.Controls.Add(Me.ckDG)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ListMapServers)
        Me.Controls.Add(Me.cmdGetMap)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.lbTilesRemaining)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmStart"
        Me.Text = "Get Background Tiles"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbTilesRemaining As System.Windows.Forms.Label
    Public WithEvents Label11 As System.Windows.Forms.Label
    Public WithEvents Label10 As System.Windows.Forms.Label
    Public WithEvents Label9 As System.Windows.Forms.Label
    Public WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents BarA As System.Windows.Forms.HScrollBar
    Friend WithEvents lbZoom As System.Windows.Forms.Label
    Public WithEvents lbTiles As System.Windows.Forms.Label
    Friend WithEvents cmdGetMap As System.Windows.Forms.Button
    Friend WithEvents ListMapServers As System.Windows.Forms.ListBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ckDG As System.Windows.Forms.CheckBox
    Friend WithEvents lbNLat As System.Windows.Forms.Label
    Friend WithEvents lbWLon As System.Windows.Forms.Label
    Friend WithEvents lbELon As System.Windows.Forms.Label
    Friend WithEvents lbSLat As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
