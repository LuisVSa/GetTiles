Imports System.Reflection
Imports System.IO


Public Class FrmStart

    Private Init As Boolean = True

    Private X1 As Integer
    Private X2 As Integer
    Private Y1 As Integer
    Private Y2 As Integer

    'Private NOfC As Integer
    'Private NOfR As Integer

    Friend AppPath As String = My.Application.Info.DirectoryPath

    Friend TilesToCome As Integer = 0

    Private myServer As TileServer.IServer
    Private myServers As New ArrayList

    Private myTypes As Type()
    Private myType As Type

    Friend NoOfServerTypes As Integer
    Friend MaximumZoom As Integer

    Friend TileFolder As String

    Friend Structure TileHandlerState
        Dim handler As Object
        Dim tile As String
        Dim dir As String
    End Structure

    Private Const PI As Double = 3.14159265358979
    Private Const pi_360 As Double = PI / 360.0
    Private Const pi_180 = PI / 180.0
    Private Const pi_4 As Double = PI / 4.0
    Private Const pi_2 As Double = PI / 2.0

    Private Delegate Sub UpdateUIHandler(ByVal remain As Integer)
    Private Delegate Function DownloadTileHandler(ByVal X As Integer, ByVal Y As Integer, ByVal S As Integer, ByVal file As String) As Boolean
    Private myDownloadTileCallback As AsyncCallback = AddressOf DownloadTileCallback


    Public Sub MakeBackground()

        TilesToCome = 0

        If Zoom > MaximumZoom Then
            MsgBox("Maximum Zoom Level for this server is " & MaximumZoom)
            HideForm(True)
            Me.Cursor = System.Windows.Forms.Cursors.Default
            Exit Sub
        End If

        Dim X, Y As Integer

        Dim TileExtension As String = myServer.ImageType
        If Not My.Computer.FileSystem.DirectoryExists(TileFolder) Then
            Directory.CreateDirectory(TileFolder)
        End If

        Dim TilePrefix As String = "\L" & Trim(Zoom) & "X"
        Dim TileName, TileFull, TileTemp As String

        Dim myDownloadTileHandler As DownloadTileHandler = AddressOf myServer.DownloadTile
        Dim myTileHandlerState As TileHandlerState

        Dim AR As System.IAsyncResult
        Dim TileDir As String

        For Y = Y1 To Y2
            For X = X1 To X2

                TileDir = TileDirFromXYZ(X, Y, Zoom)
                TileName = TilePrefix & Trim(X) & "Y" & Trim(Y) & TileExtension
                TileFull = TileFolder & TileDir & TileName
                TileTemp = AppPath & "\Tiles" & TileName

                If Not My.Computer.FileSystem.FileExists(TileFull) Then

                    Try
                        TilesToCome = TilesToCome + 1
                        TileHasArrived(TilesToCome)
                        myTileHandlerState.handler = myDownloadTileHandler
                        myTileHandlerState.tile = TileName
                        myTileHandlerState.dir = TileDir
                        AR = myDownloadTileHandler.BeginInvoke(X, Y, Zoom, TileTemp, myDownloadTileCallback, myTileHandlerState)
                    Catch ex As Exception

                    End Try
                End If
            Next
        Next

        If TilesToCome = 0 Then
            lbTilesRemaining.Visible = False
            Me.Cursor = System.Windows.Forms.Cursors.Default
            HideForm(True)
        End If

    End Sub

    Private Sub DownloadTileCallback(ByVal ar As IAsyncResult)

        '*** this code fires at completion of each asynchronous method call
        Dim myTileHandlerState As TileHandlerState
        myTileHandlerState = CType(ar.AsyncState, TileHandlerState)

        Dim caller As DownloadTileHandler = myTileHandlerState.handler
        Dim Tilename As String = myTileHandlerState.tile
        Dim TileDir As String = myTileHandlerState.dir


        Dim TileFull As String = TileFolder & TileDir & Tilename
        Dim TileTemp As String = AppPath & "\Tiles" & Tilename

        Dim retval As Boolean
        retval = False
        Try
            retval = caller.EndInvoke(ar)
        Catch ex As Exception

        End Try

        If retval Then
            If My.Computer.FileSystem.FileExists(TileTemp) Then
                My.Computer.FileSystem.CopyFile(TileTemp, TileFull)
                My.Computer.FileSystem.DeleteFile(TileTemp)
            End If
        Else
            If My.Computer.FileSystem.FileExists(TileTemp) Then
                My.Computer.FileSystem.DeleteFile(TileTemp)
            End If
        End If

        TilesToCome = TilesToCome - 1
        If TilesToCome < 0 Then TilesToCome = 0

        UpdateUI(TilesToCome)

    End Sub
    Private Sub UpdateUI(ByVal remain As Integer)

        '*** check to see if thread switch is required
        If Me.InvokeRequired Then
            Dim handler As New UpdateUIHandler(AddressOf TileHasArrived)
            Me.BeginInvoke(handler, remain)
        Else
            TileHasArrived(remain)
        End If

    End Sub

    Private Sub TileHasArrived(ByVal N As Integer)

        If N > 0 Then
            lbTilesRemaining.Text = "(" & N & " tiles remainning) downloading from " & myServer.ServerName
            lbTilesRemaining.Visible = True
        Else
            lbTilesRemaining.Visible = False
            Me.Cursor = System.Windows.Forms.Cursors.Default
            HideForm(True)
        End If

    End Sub
    Friend Function TilenameFromXYZ(ByVal X As Integer, ByVal Y As Integer, ByVal Z As Integer) As String

        TilenameFromXYZ = "\L" & Trim(Z) & "X" & Trim(X) & "Y" & Trim(Y) & myServer.ImageType

        If Z < 4 Then Exit Function

        Dim N As Integer
        Dim Limit As Integer
        Dim TilePath As String = ""

        For N = Z To 4 Step -1
            Limit = 2 ^ N
            If X < Limit Then
                If Y < Limit Then
                    TilePath = TilePath & "\0"
                Else
                    TilePath = TilePath & "\2"
                    Y = Y - Limit
                End If
            Else
                If Y < Limit Then
                    TilePath = TilePath & "\1"
                Else
                    TilePath = TilePath & "\3"
                    Y = Y - Limit
                End If
                X = X - Limit
            End If
        Next

        TilenameFromXYZ = TilePath & TilenameFromXYZ


    End Function

    Friend Function TileDirFromXYZ(ByVal X As Integer, ByVal Y As Integer, ByVal Z As Integer) As String

        TileDirFromXYZ = ""
        If Z < 4 Then Exit Function

        Dim N As Integer
        Dim Limit As Integer

        For N = Z To 4 Step -1
            Limit = 2 ^ N
            If X < Limit Then
                If Y < Limit Then
                    TileDirFromXYZ = TileDirFromXYZ & "\0"
                Else
                    TileDirFromXYZ = TileDirFromXYZ & "\2"
                    Y = Y - Limit
                End If
            Else
                If Y < Limit Then
                    TileDirFromXYZ = TileDirFromXYZ & "\1"
                Else
                    TileDirFromXYZ = TileDirFromXYZ & "\3"
                    Y = Y - Limit
                End If
                X = X - Limit
            End If
        Next

    End Function

    Friend Function XTilesFromLon(ByVal lon As Double, ByVal Z As Integer) As Integer

        Dim dXY As Double
        dXY = PI / (2 ^ Z)
        lon = PI + lon * pi_180
        XTilesFromLon = Int(lon / dXY)

    End Function

    Friend Function YTilesFromLat(ByVal lat As Double, ByVal Z As Integer) As Integer

        Dim dXY As Double
        dXY = PI / (2 ^ Z)
        lat = lat * pi_360  ' lat=lat/2  <<< equivalent
        lat = lat + pi_4
        lat = Math.Tan(lat)
        lat = Math.Log(lat)
        lat = PI - lat
        YTilesFromLat = Int(lat / dXY)

    End Function


    Private Sub FrmStart_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim myAssembly As Assembly

        Dim myFiles As String()
        Dim Dll, DllBase As String

        Dim myFolder As String = My.Application.Info.DirectoryPath

        ' get all DLL files that are inside the subfolder Tiles
        myFiles = Directory.GetFiles(myFolder & "\Tiles", "*.dll")

        ' load all these DLLs and get their type (eg their classes). If they
        ' implement the interface "SBTileServer.IServer" add these classes
        ' to myServers array 

        ' AppDomain.CurrentDomain.AppendPrivatePath("Tiles")
        ' could not resolve this warning but it works
        ' we can comment it by setting the App.config

        For Each Dll In myFiles
            DllBase = Path.GetFileNameWithoutExtension(Dll)
            myAssembly = Assembly.Load(DllBase)
            myTypes = myAssembly.GetTypes
            For Each myType In myTypes
                If myType.GetInterface("TileServer.IServer") IsNot Nothing Then
                    If Not myType.IsAbstract Then
                        myServers.Add(myType)
                    End If
                End If
            Next
        Next

        Dim NoOfServers As Integer = myServers.Count

        ' place the name of the servers in a list box
        Dim N As Integer
        For N = 1 To NoOfServers
            ListMapServers.Items.Add(myServers(N - 1).Name)
        Next

        ' by default select the first server (eg class) and create an instance of it
        ListMapServers.SelectedIndex = 0
        myServer = Activator.CreateInstance(myServers(ListMapServers.SelectedIndex))


        LatLon2Labels()
        BarA.Value = Zoom


        'Init = False

        CountTiles()

    End Sub


    Private Sub CmdGetMap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGetMap.Click

        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        HideForm(False)

        Dim K As Integer

        myServer = Nothing

        For Each foundFile As String In My.Computer.FileSystem.GetFiles(AppPath & "\Tiles", FileIO.SearchOption.SearchTopLevelOnly, "L*")
            My.Computer.FileSystem.DeleteFile(foundFile)
        Next

        K = ListMapServers.SelectedIndex
        myServer = Activator.CreateInstance(myServers(K))
        MaximumZoom = myServer.MaximumZoom
        TileFolder = AppPath & "\Tiles\" & myServer.ServerName

        MakeBackground()

    End Sub

    Private Sub CountTiles()

        'If Init Then Exit Sub
        Dim X As Double

        X1 = XTilesFromLon(WLon, Zoom)
        Y1 = YTilesFromLat(NLat, Zoom)
        X2 = XTilesFromLon(ELon, Zoom)
        Y2 = YTilesFromLat(SLat, Zoom)

        X = CDbl((Y2 - Y1 + 1)) * CDbl((X2 - X1 + 1))

        If X > 20000 Then
            Zoom = Zoom - 1
            BarA.Value = Zoom
            lbZoom.Text = "Zoom = " & Zoom
            CountTiles()
        Else
            lbTiles.Text = "Tiles = " & CStr(X)
        End If

    End Sub
    Private Sub LatLon2Labels()

        lbNLat.Text = Lat2Str(NLat)
        lbSLat.Text = Lat2Str(SLat)
        lbWLon.Text = Lon2Str(WLon)
        lbELon.Text = Lon2Str(ELon)

    End Sub


    Private Sub CkDG_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckDG.CheckedChanged
        DecimalDegrees = False
        If ckDG.Checked Then DecimalDegrees = True
        LatLon2Labels()
    End Sub

    Private Sub BarA_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles BarA.ValueChanged

        Zoom = BarA.Value
        lbZoom.Text = "Zoom = " & Zoom
        CountTiles()

    End Sub

    Private Sub LbNLat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbNLat.Click
        IsLat = 1
        frmLatLon.ShowDialog()
        lbNLat.Text = Lat2Str(NLat)
        CountTiles()
    End Sub

    Private Sub LbWLon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbWLon.Click
        IsLat = 3
        frmLatLon.ShowDialog()
        lbWLon.Text = Lon2Str(WLon)
        CountTiles()
    End Sub

    Private Sub LbELon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbELon.Click
        IsLat = 4
        frmLatLon.ShowDialog()
        lbELon.Text = Lon2Str(ELon)
        CountTiles()
    End Sub

    Private Sub LbSLat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbSLat.Click
        IsLat = 2
        frmLatLon.ShowDialog()
        lbSLat.Text = Lat2Str(SLat)
        CountTiles()
    End Sub

    Private Sub HideForm(ByVal Flag As Boolean)

        Me.lbELon.Enabled = Flag
        Me.lbWLon.Enabled = Flag
        Me.lbNLat.Enabled = Flag
        Me.lbSLat.Enabled = Flag
        Me.ListMapServers.Enabled = Flag
        Me.BarA.Enabled = Flag
        Me.cmdGetMap.Enabled = Flag
        Me.ckDG.Enabled = Flag

    End Sub

End Class
