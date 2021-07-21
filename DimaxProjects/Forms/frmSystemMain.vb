Imports ADODB

Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports WG3000_COMM.Core
Imports System.Collections

Imports System.Text.RegularExpressions

Public Class frmSystemMain

    Private Sub cmdStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStart.Click
        Dim dev As New controlDev
        PanelDev.Controls.Add(dev)
    End Sub

    Sub LogsHeader()
        Dim w As Integer = lstList.Width / 4
        lstList.Columns.Add("Time", w, HorizontalAlignment.Left)
        lstList.Columns.Add("Name", w, HorizontalAlignment.Left)
        lstList.Columns.Add("Plate", w, HorizontalAlignment.Left)
        lstList.Columns.Add("Status", w, HorizontalAlignment.Left)
    End Sub

    Sub loadContollers()
        If conServer() = False Then Exit Sub

        Try
            Dim rs As New Recordset

            rs = New Recordset
            rs = Conn.Execute("select * from tblcontroler")
            Do While rs.EOF = False
                If rs("Stat").Value = 1 Then
                    ctrl_Node = rs("NodeName").Value
                    ctrl_SN = rs("SN").Value
                    ctrl_IP = rs("Ip").Value
                    ctrl_Port = rs("Port").Value
                    ctrl_MAC = rs("MacAdd").Value
                    ctrl_SubNet = rs("Subnet").Value
                    ctrl_Gateway = rs("Gateway").Value
                    ctrl_PCip = rs("PCip").Value

                    ctrl_CamIP = rs("Cam_Ip").Value
                    ctrl_CamUID = rs("Cam_User").Value
                    ctrl_CamPWD = rs("Cam_Pass").Value
                    ctrl_CamPort = rs("Cam_Port").Value
                    ctrl_Cam1 = rs("Cam1").Value
                    ctrl_Cap1 = rs("Cam_Cap1").Value
                    ctrl_Cam2 = rs("Cam2").Value
                    ctrl_Cap2 = rs("Cam_Cap2").Value

                    Sleep(1000)
                    Dim dev1 As New controlDev
                    PanelDev.Controls.Add(dev1)
                End If
                rs.MoveNext()
            Loop

        Catch ex As Exception

        End Try

    End Sub

    Sub fillLogs(ByVal Pname As String, ByVal PlateNum As String, ByVal tme As String, ByVal Stat As String)
        lstList.Refresh()
        Dim viewlst As New ListViewItem
        viewlst = lstList.Items.Add(Format(CDate(tme), "yyyy-MM-dd HH:mm:ss"))
        viewlst.SubItems.Add(Pname) 'PlateNum)
        viewlst.SubItems.Add(PlateNum)
        viewlst.SubItems.Add(Stat)
    End Sub

    Private Sub frmSystemMain_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Control = True And e.KeyCode = Keys.F Then
            frmLogin.ShowDialog()
        End If

        If e.Control = True And e.KeyCode = Keys.Enter Then
            frmLogin.ShowDialog()
        End If
    End Sub

    Private Sub frmSystemMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SysLock()
    End Sub

    Private Sub frmSystemMain_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        viewConn()
        conServer()

        lstList.Clear()
        LogsHeader()

        lstList.Clear()
        LogsHeader()

        loadContollers()
    End Sub

    Private Sub TerminateSystemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTerminate.Click
        If MsgBox("Are you sure you want to terminate system? ", vbQuestion + vbYesNo + vbDefaultButton2, "Terminate System") = vbYes Then
            saveAudiUpdate(UserAcc.Text, SystemTag.Text, "System Terminated")

            Application.ExitThread()
            Application.Exit()
        End If
    End Sub

    Private Sub ServerConnectionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSeverCon.Click
        frmDbSettings.ShowDialog()
    End Sub

    Private Sub CotrollerSettingsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuController.Click
        Dim a As New frmController
        a.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAntiPsb.Click
        frmAntiPassback.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuParkerRec.Click
        frmVipRec.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuLogs.Click
        frmlogs.ShowDialog()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        txttime.Text = Format(Now, "")
    End Sub

    Public Function IsProcessRunning(ByVal name As String) As Boolean
        For Each clsProcess As Process In Process.GetProcesses()
            If clsProcess.ProcessName.StartsWith(name) Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click
        If IsProcessRunning(Application.StartupPath & "\prjStarter.exe") = False Then
            Process.Start(Application.StartupPath & "\prjStarter.exe")
            Application.ExitThread()
        End If
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        If controler.RemoteOpenDoorIP(1) > 0 Then
            MsgBox("Successfully triggered!", vbInformation)
        Else
            MsgBox("Fail to triggered!", vbExclamation)
        End If
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSysAcc.Click
        frmSysAccount.ShowDialog()
    End Sub

    Private Sub mnuLogout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuLogout.Click
        If MsgBox("Are you sure do you want to logout? ", vbQuestion + vbYesNo + vbDefaultButton2, "Logout") = vbYes Then

            SysLock()
            saveAudiUpdate(UserAcc.Text, SystemTag.Text, "Account Logout")

            SystemTag.Text = "System :"
            UserAcc.Text = "Locked"

        End If
    End Sub

    Private Sub mnuAuditLogs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAuditLogs.Click
        frmAudit.ShowDialog()
    End Sub
End Class