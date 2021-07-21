Imports ADODB
Module CARD_FUNCTION
    Public Sub fillcards(ByVal lst As ListView, ByVal IdNo As String)
        If conServer() = False Then
            MsgBox("Please connect to server!    ", vbExclamation, "Server")
            Exit Sub
        End If
        'LstEmpRec.Clear()
        On Error Resume Next
        Dim rs As New Recordset
        Dim lup As Short
        rs = New Recordset
        rs = Conn.Execute("select * from tblcards where OwnerID = '" & IdNo & "'")
        If rs.EOF = False Then
            For lup = 1 To rs.RecordCount
                lst.Refresh()
                Dim viewlst As New ListViewItem
                viewlst = lst.Items.Add(rs("CardCode").Value, lup)
                viewlst.SubItems.Add(rs("PlateNo").Value)
                viewlst.SubItems.Add(rs("DateEnrolled").Value)
                viewlst.SubItems.Add(rs("DateExpired").Value)
                'viewlst.SubItems.Add(rs("Status").Value)
                rs.MoveNext()
            Next
        End If
    End Sub
End Module
