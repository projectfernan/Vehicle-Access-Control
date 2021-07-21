Imports ADODB
Imports System.IO
Module Cam_Function
    Public Cam_ID As Integer

    Sub viewCam()
        If Connect_Loc() = False Then
            MsgBox("Local database error!", vbExclamation)
            Exit Sub
        End If

        Try
            Dim rs As New Recordset
            rs = New Recordset
            rs = ConnLoc.Execute("select * from tblSetCam")
            If rs.EOF = False Then
                With frmCamSettings
                    .txtIp.Text = rs("Cam_Ip").Value
                    .txtUser.Text = rs("Cam_User").Value
                    .txtPass.Text = rs("Cam_Pass").Value
                    .txtPort.Value = rs("Cam_Port").Value

                    .Cap1.Value = rs("Cam_cap1").Value
                    .Cap2.Value = rs("Cam_Cap2").Value
                End With
            End If

        Catch ex As Exception

        End Try
    End Sub

    Public Function Camera_Connect(ByVal strIP As String, ByVal IntPort As Integer, ByVal strUID As String, ByVal strPWD As String, ByVal CamID As Integer) As Boolean
        With frmAddController.NetVidtest
            .Logout()
            .ClearOCX()
            If PingMe(strIP) = False Then Return False
            Cam_ID = .Login(strIP, IntPort, strUID, strPWD)
            If Cam_ID < 0 Then
                Return False
            Else
                .StartRealPlay(CamID, 0, 0)
                Return True
            End If
        End With
    End Function

    Public Function Get_ImageName() As String
        Dim Name As String = Dir$(Application.StartupPath & "\Capture\JPEGCapture\*.jpeg")
        If Name = "" Then
            Return Nothing
        Else
            Return Application.StartupPath & "\Capture\JPEGCapture\" & Name
        End If
    End Function

    Public Sub Delete_Image()
        If Directory.Exists(Application.StartupPath & "\Capture") = True Then
            Directory.Delete(Application.StartupPath & "\Capture", True)
        End If
    End Sub

    Public Function Camera_Capture1() As Boolean
        Delete_Image()
        With frmMain.NetVideo1
            Dim Cap As Integer = frmCamSettings.Cap1.Value
            If .JPEGCapturePicture(Cap, 0, 0, Application.StartupPath & "\Capture") = True Then
                With frmMain.PicBox1
                    .ImageLocation = Get_ImageName()
                    .Load()
                End With
                Return True
            Else
                With frmMain.PicBox1
                    .Image = Image.FromFile(Application.StartupPath & "\noCar.jpg")
                End With
                Return False
            End If
        End With
    End Function

    Public Function Camera_Capture2() As Boolean
        Delete_Image()
        With frmMain.NetVideo2
            Dim Cap As Integer = frmCamSettings.Cap2.Value
            If .JPEGCapturePicture(Cap, 0, 0, Application.StartupPath & "\Capture") = True Then
                With frmMain.PicBox1
                    .ImageLocation = Get_ImageName()
                    .Load()
                End With
                Return True
            Else
                With frmMain.PicBox2
                    .Image = Image.FromFile(Application.StartupPath & "\noCar.jpg")
                End With
                Return False
            End If
        End With
    End Function

    Public Sub Camera_Exit()
        With frmMain.NetVideo2
            .Logout()
            .ClearOCX()
        End With
    End Sub
End Module
