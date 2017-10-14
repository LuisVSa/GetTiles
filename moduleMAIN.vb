Module moduleMAIN

    Friend NLat As Double = 39
    Friend SLat As Double = 38
    Friend WLon As Double = -9
    Friend ELon As Double = -8
    Friend Zoom = 8

    Friend DecimalDegrees As Boolean = False

    Friend IsLat As Integer

    Friend Function Str2Lat(ByVal lat As String) As Double

        Dim a As String
        Dim N, M As Integer
        Dim Neg As Boolean

        On Error GoTo error1

        If DecimalDegrees Then

            Str2Lat = CDbl(lat)

        Else
            lat = Replace(lat, "s", "S")
            lat = Replace(lat, "n", "N")

            Neg = False
            N = InStr(lat, "S")
            If N > 0 Then
                Neg = True
                lat = Replace(lat, "S", "")
            End If

            N = InStr(lat, "-")
            If N > 0 Then
                Neg = True
                lat = Replace(lat, "-", "")
            End If

            N = InStr(lat, "N")
            If N > 0 Then lat = Replace(lat, "N", "")

            lat = Replace(lat, ":", " ")
            lat = Replace(lat, Chr(176), " ")
            lat = Replace(lat, "'", " ")
            'lat = Replace(lat, "''", " ")
            lat = Replace(lat, "''", "")
            lat = Replace(lat, "   ", " ")
            lat = Replace(lat, "  ", " ")
            lat = Trim(lat)

            N = InStr(lat, " ")
            If N = 0 Then
                Str2Lat = CDbl(lat)
                If Neg Then Str2Lat = -1 * Str2Lat
                Exit Function
            End If
            a = Mid(lat, 1, N - 1)
            Str2Lat = CDbl(a)

            M = InStr(N + 1, lat, " ")
            If M = 0 Then
                a = Mid(lat, N + 1)
                Str2Lat = Str2Lat + CDbl(a) / 60
                If Neg Then Str2Lat = -1 * Str2Lat
                Exit Function
            End If
            a = Mid(lat, N + 1, M - N - 1)
            Str2Lat = Str2Lat + CDbl(a) / 60

            a = Mid(lat, M + 1)
            Str2Lat = Str2Lat + CDbl(a) / 3600

            If Neg Then Str2Lat = -1 * Str2Lat

        End If

        Exit Function


error1:
        Str2Lat = 100

    End Function

    Friend Function Str2Lon(ByVal lon As String) As Double

        Dim a As String
        Dim N, M As Integer
        Dim Neg As Boolean

        On Error GoTo error1

        If DecimalDegrees Then
            Str2Lon = CDbl(lon)
        Else

            lon = Replace(lon, "e", "E")
            lon = Replace(lon, "w", "W")

            Neg = False
            N = InStr(lon, "W")
            If N > 0 Then
                Neg = True
                lon = Replace(lon, "W", "")
            End If

            N = InStr(lon, "-")
            If N > 0 Then
                Neg = True
                lon = Replace(lon, "-", "")
            End If


            N = InStr(lon, "E")
            If N > 0 Then lon = Replace(lon, "E", "")

            lon = Replace(lon, ":", " ")
            lon = Replace(lon, Chr(176), " ")
            lon = Replace(lon, "'", " ")
            'lon = Replace(lon, "''", " ")
            lon = Replace(lon, "''", "'")
            lon = Replace(lon, "   ", " ")
            lon = Replace(lon, "  ", " ")
            lon = Trim(lon)

            N = InStr(lon, " ")

            If N = 0 Then
                Str2Lon = CDbl(lon)
                If Neg Then Str2Lon = -1 * Str2Lon
                Exit Function
            End If

            a = Mid(lon, 1, N - 1)
            Str2Lon = CDbl(a)

            M = InStr(N + 1, lon, " ")

            If M = 0 Then
                a = Mid(lon, N + 1)
                Str2Lon = Str2Lon + CDbl(a) / 60
                If Neg Then Str2Lon = -1 * Str2Lon
                Exit Function
            End If

            a = Mid(lon, N + 1, M - N - 1)
            Str2Lon = Str2Lon + CDbl(a) / 60

            a = Mid(lon, M + 1)
            Str2Lon = Str2Lon + CDbl(a) / 3600

            If Neg Then Str2Lon = -1 * Str2Lon

        End If

        Exit Function

error1:
        Str2Lon = 200

    End Function

    Friend Function Lon2Str(ByVal lon As Double) As String

        Dim a As String
        Dim X As Double
        Dim N As Integer

        If DecimalDegrees Then
            Lon2Str = Format(lon, "00.0000000")
        Else
            If lon < 0 Then
                a = "W"
                lon = -1 * lon
            Else
                a = "E"
            End If
            N = CInt(Int(lon))
            Lon2Str = CStr(N)
            X = (lon - CDbl(N)) * 60
            N = CInt(Int(X))
            Lon2Str = Lon2Str & Chr(176) & " " & Format(N, "00")
            X = (X - CDbl(N)) * 60
            X = System.Math.Round(X, 4)
            Lon2Str = Lon2Str & "' " & Format(X, "00.0000") & "'' " & a
        End If

    End Function

    Friend Function Lat2Str(ByVal lat As Double) As String

        Dim b As String
        Dim X As Double
        Dim N As Integer


        If DecimalDegrees Then
            Lat2Str = Format(lat, "00.0000000")
        Else
            If lat < 0 Then
                b = "S"
                lat = -1 * lat
            Else
                b = "N"
            End If
            N = CInt(Int(lat))
            Lat2Str = CStr(N)
            X = (lat - CDbl(N)) * 60
            N = CInt(Int(X))
            Lat2Str = Lat2Str & Chr(176) & " " & Format(N, "00")
            X = (X - CDbl(N)) * 60
            X = System.Math.Round(X, 4)
            Lat2Str = Lat2Str & "' " & Format(X, "00.0000") & "'' " & b
        End If

    End Function

End Module
