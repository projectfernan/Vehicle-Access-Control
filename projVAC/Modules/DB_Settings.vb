Imports ADODB
Module DB_Settings
    Public Conn As New Connection
    Public ConnLoc As New Connection

    Function Connect_Loc() As Boolean
        Try
            ConnLoc = New Connection
            With ConnLoc
                .Open("Provider=Microsoft.jet.OLEDB.4.0;Data Source=" & Application.StartupPath & "\SettingsDb.mdb")
                .CursorLocation = CursorLocationEnum.adUseClient
            End With
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Sub viewConn()
        If Connect_Loc() = False Then Exit Sub
        Dim rs As New Recordset
        rs = New Recordset

        rs = ConnLoc.Execute("select * from tblDbSettings")
        If rs.EOF = False Then
            With frmDbSettings
                .txtIp.Text = rs("ServerIp").Value
                .txtUid.Text = rs("User").Value
                .txtPwd.Text = rs("Pass").Value
                .txtPort.Value = rs("Port").Value
            End With
        End If
    End Sub

    Public Function conServer() As Boolean
        Try
            With frmDbSettings
                If Conn.State = ConnectionState.Open Then Conn.Close()
                Conn = New ADODB.Connection
                Conn.CursorLocation = ADODB.CursorLocationEnum.adUseClient
                Conn.Open("Driver={mySQL ODBC 8.0 Unicode Driver}; " _
                & "Server=" & .txtIp.Text & ";" _
                & "Port=" & .txtPort.Value.ToString & ";" _
                & "Option=3;" _
                & "Database=dimaxdb;" _
                & "UID=" & .txtUid.Text & ";" _
                & "PWD=" & .txtPwd.Text & ";")
                frmSystemMain.txtdbStat.Text = "Connected"
                frmSystemMain.txtdbStat.ForeColor = Color.Blue
                Return True
            End With
        Catch
            frmSystemMain.txtdbStat.Text = "Disconnected"
            frmSystemMain.txtdbStat.ForeColor = Color.Red
            Return False
        End Try
    End Function
End Module
