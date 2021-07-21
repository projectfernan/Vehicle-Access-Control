Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports WG3000_COMM.Core
Imports ADODB

Public Class frmAddController

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Dim snNo As Integer = txtSN.Text
        If wgMjController.GetControllerType(snNo) = 0 Then

        Else
            controler = New wgMjController
            controler.NetIPConfigure(txtSN.Text, txtMack.Text, txtIP.Text, txtSubnet.Text, txtGateway.Text, txtPort.Text, PCip)
            If Me.Text = "Add Controller" Then
                If ChkNodeExist(txtNodeName.Text) = False Then
                    Save()
                    With frmSystemMain
                        saveAudiUpdate(.UserAcc.Text, .SystemTag.Text, "Controller : " & txtSN.Text & " successfully saved")
                    End With
                Else
                    MsgBox("Node name already exist! ", vbExclamation, "Save")
                End If
            Else
                Edit()
                With frmSystemMain
                    saveAudiUpdate(.UserAcc.Text, .SystemTag.Text, "Controller : " & txtSN.Text & " successfully updated")
                End With
            End If

reconfig:
            controler.ControllerSN = CInt(txtSN.Text)
            controler.IP = txtIP.Text
            controler.PORT = txtPort.Text

            Dim controlConfigure As New wgMjControllerConfigure

            controlConfigure.DoorControlSet(1, 0)
            controlConfigure.DoorControlSet(2, 0)

            controlConfigure.DoorDelaySet(1, txtTriggerDelay.Value)
            controlConfigure.DoorDelaySet(2, txtTriggerDelay.Value)
            My.Settings.TriggerDelay = txtTriggerDelay.Value
            My.Settings.Save()

            MsgBox("Controller successfully saved and configured! ", vbInformation, "Save")

            Me.Close()
        End If
    End Sub

    Sub Save()
        If conServer() = False Then
            MsgBox("Please connect to server! ", vbInformation, "Save")
            frmDbSettings.ShowDialog()
            Exit Sub
        End If

        If MsgBox("Are you sure your entries are correct? ", vbQuestion + vbYesNo + vbDefaultButton2, "Saves") = vbYes Then
            Try
                Dim rs As New Recordset
                rs = New Recordset

                rs.Open("select * from tblcontroler", Conn, 1, 2)
                rs.AddNew()
                rs("NodeName").Value = txtNodeName.Text
                rs("SN").Value = txtSN.Text
                rs("Ip").Value = txtIP.Text
                rs("Port").Value = txtPort.Text
                rs("MacAdd").Value = txtMack.Text
                rs("Subnet").Value = txtSubnet.Text
                rs("Gateway").Value = txtGateway.Text
                rs("PCip").Value = PCip
                If chkAuto.Checked = False Then
                    rs("Stat").Value = 0
                Else
                    rs("Stat").Value = 1
                End If
                rs("Cam_Ip").Value = txtCamIP.Text
                rs("Cam_User").Value = txtUser.Text
                rs("Cam_Pass").Value = txtPass.Text
                rs("Cam_Port").Value = txtPortCam.Value
                rs("Cam1").Value = txtCam1.Value
                rs("Cam_Cap1").Value = Cap1.Value
                rs("Cam2").Value = txtCam2.Value
                rs("Cam_Cap2").Value = Cap2.Value
                rs.Update()
                'MsgBox("Controller successfully saved and configured! ", vbInformation, "Save")
                'Me.Close()
            Catch ex As Exception
                MsgBox(ex.Message, vbCritical, "Save")
            End Try
        End If
    End Sub

    Sub Edit()
        If conServer() = False Then
            MsgBox("Please connect to server! ", vbInformation, "Save")
            frmDbSettings.ShowDialog()
            Exit Sub
        End If

        If MsgBox("Are you sure do you want to save changes? ", vbQuestion + vbYesNo + vbDefaultButton2, "Saves") = vbYes Then
            Try
                Dim rs As New Recordset
                rs = New Recordset

                rs.Open("select * from tblcontroler where SN = '" & txtSN.Text & "'", Conn, 1, 2)
                rs("NodeName").Value = txtNodeName.Text
                rs("SN").Value = txtSN.Text
                rs("Ip").Value = txtIP.Text
                rs("Port").Value = txtPort.Text
                rs("MacAdd").Value = txtMack.Text
                rs("Subnet").Value = txtSubnet.Text
                rs("Gateway").Value = txtGateway.Text
                rs("PCip").Value = PCip
                If chkAuto.Checked = False Then
                    rs("Stat").Value = 0
                Else
                    rs("Stat").Value = 1
                End If
                rs("Cam_Ip").Value = txtCamIP.Text
                rs("Cam_User").Value = txtUser.Text
                rs("Cam_Pass").Value = txtPass.Text
                rs("Cam_Port").Value = txtPortCam.Value
                rs("Cam1").Value = txtCam1.Value
                rs("Cam_Cap1").Value = Cap1.Value
                rs("Cam2").Value = txtCam2.Value
                rs("Cam_Cap2").Value = Cap2.Value
                rs.Update()

                'Me.Close()
            Catch ex As Exception
                MsgBox(ex.Message, vbCritical, "Save")
            End Try
        End If
    End Sub

    Function ChkNodeExist(ByVal Node As String) As Boolean
        If conServer() = False Then Return False
        Try
            Dim rs As New Recordset
            rs = New Recordset
            rs = Conn.Execute("select * from tblcontroler where NodeName = '" & Node & "'")
            If rs.EOF = False Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub cmdTest1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTest1.Click
        If Camera_Connect(txtIP.Text, txtPortCam.Value, txtUser.Text, txtPass.Text, txtCam1.Value) = True Then
            MsgBox("Camera " & txtCam1.Value.ToString & "successfully connected!", vbInformation, "Test Connect")
        Else
            MsgBox("Failed to connect in Camera " & txtCam1.Value.ToString & " !", vbInformation, "Test Connect")
        End If
    End Sub

    Private Sub cmdTest2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTest2.Click
        If Camera_Connect(txtIP.Text, txtPortCam.Value, txtUser.Text, txtPass.Text, txtCam2.Value) = True Then
            MsgBox("Camera " & txtCam2.Value.ToString & "successfully connected!", vbInformation, "Test Connect")
        Else
            MsgBox("Failed to connect in Camera " & txtCam2.Value.ToString & " !", vbInformation, "Test Connect")
        End If
    End Sub

    Private Sub frmAddController_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        txtTriggerDelay.Value = My.Settings.TriggerDelay
    End Sub
End Class