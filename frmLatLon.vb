Public Class frmLatLon

    Private Sub CmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click

        On Error GoTo erro

        Dim X As Double
        If IsLat = 1 Then
            X = Str2Lat(txtValue.Text)
            If X > 85.0511287798066 Then GoTo erro
            If X < SLat Then GoTo erro
            NLat = X
        ElseIf IsLat = 2 Then
            X = Str2Lat(txtValue.Text)
            If X < -85.0511287798066 Then GoTo erro
            If X > NLat Then GoTo erro
            SLat = X
        ElseIf IsLat = 3 Then
            X = Str2Lon(txtValue.Text)
            If X < -180 Then GoTo erro
            If X > ELon Then GoTo erro
            WLon = X
        ElseIf IsLat = 4 Then
            X = Str2Lon(txtValue.Text)
            If X > 180 Then GoTo erro
            If X < WLon Then GoTo erro
            ELon = X
        End If

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
        Exit Sub

erro:
        MsgBox("Please check your entry!", MsgBoxStyle.Critical)

    End Sub

    Private Sub CmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub FrmLatLon_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsLat = 1 Then
            Me.Text = "Enter North Latitude"
            txtValue.Text = Lat2Str(NLat)
        ElseIf IsLat = 2 Then
            Me.Text = "Enter South Latitude"
            txtValue.Text = Lat2Str(SLat)
        ElseIf IsLat = 3 Then
            Me.Text = "Enter West Longitude"
            txtValue.Text = Lon2Str(WLon)
        ElseIf IsLat = 4 Then
            Me.Text = "Enter East Longitude"
            txtValue.Text = Lon2Str(ELon)
        End If

    End Sub
End Class