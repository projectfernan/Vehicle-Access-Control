Imports ADODB
Public Class frmDbSettings

    Private Sub cmdTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTest.Click
        If conServer() = True Then
            MsgBox("Successfully connected!    ", MsgBoxStyle.Information, "Server Connection")
            frmMain.txtdbStat.Text = "Connected"
            frmMain.txtdbStat.ForeColor = Color.Blue
        Else
            MsgBox("Failed to connect!    ", MsgBoxStyle.Exclamation, "Server Connection")
            frmMain.txtdbStat.Text = "Disconnected"
            frmMain.txtdbStat.ForeColor = Color.Red
        End If
    End Sub

    Sub save()
        If Connect_Loc() = False Then Exit Sub
        Try
            Dim rs As New Recordset
            rs = New Recordset
            rs.Open("select * from tblDbSettings", ConnLoc, 1, 2)
            If rs.EOF = False Then
                rs("ServerIP").Value = txtIp.Text
                rs("User").Value = txtUid.Text
                rs("Pass").Value = txtPwd.Text
                rs("Port").Value = txtPort.Value
                rs.Update()
            Else
                rs.AddNew()
                rs("ServerIP").Value = txtIp.Text
                rs("User").Value = txtUid.Text
                rs("Pass").Value = txtPwd.Text
                rs("Port").Value = txtPort.Value
                rs.Update()
            End If
            MsgBox("Database settings saved! ", vbInformation, "Save")
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Save")
        End Try
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        save()
        With frmSystemMain
            saveAudiUpdate(.UserAcc.Text, .SystemTag.Text, "Database settings successfully saved")
        End With
    End Sub

End Class