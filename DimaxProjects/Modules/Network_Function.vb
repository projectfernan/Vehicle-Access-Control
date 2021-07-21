Module Network_Function
    Public Function PingMe(ByVal IPaddress As String) As Boolean
        If My.Computer.Network.Ping(IPaddress, 5) = False Then
            Return False
        Else
            Return True
        End If
    End Function
End Module
