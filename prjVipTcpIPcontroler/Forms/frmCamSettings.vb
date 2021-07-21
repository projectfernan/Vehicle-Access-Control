Imports ADODB
Public Class frmCamSettings

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        save()
    End Sub

    Sub save()
        If Connect_Loc() = False Then
            MsgBox("Local database error!", vbCritical, "Local Connection")
            Exit Sub
        End If

        Try
            Dim rs As New Recordset
            rs = New Recordset
            rs.Open("Select * from tblSetCam", ConnLoc, 1, 2)
            If rs.EOF = False Then
                rs("Cam_Ip").Value = txtIp.Text
                rs("Cam_User").Value = txtUser.Text
                rs("Cam_Pass").Value = txtPass.Text
                rs("Cam_Port").Value = txtPort.Value
                rs("Cam_Cap1").Value = Cap1.Value
                rs("Cam_Cap2").Value = Cap2.Value
                rs.Update()
            Else
                rs.AddNew()
                rs("Cam_Ip").Value = txtIp.Text
                rs("Cam_User").Value = txtUser.Text
                rs("Cam_Pass").Value = txtPass.Text
                rs("Cam_Port").Value = txtPort.Value
                rs("Cam_Cap1").Value = Cap1.Value
                rs("Cam_Cap2").Value = Cap2.Value
                rs.Update()
            End If
            MsgBox("Camera settings saved!", vbInformation, "Save")
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Save")
        End Try
    End Sub

    Private Sub cmdTest1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTest1.Click
        If Camera_Capture1() = False Then
            MsgBox("Failed to capture!", vbExclamation)
        Else
            MsgBox("Captured successfully!", vbInformation)
        End If
    End Sub

    Private Sub cmdTest2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTest2.Click
        If Camera_Capture2() = False Then
            MsgBox("Failed to capture!", vbExclamation)
        Else
            MsgBox("Captured successfully!", vbInformation)
        End If
    End Sub
End Class