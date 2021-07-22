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

Public Class frmMain
    Public watching As New wgWatchingService
    Public Event EventHandler(ByVal message As String)
    Public receivedPktCount As New Integer
    Public QueRecText As New Queue

    Private Delegate Sub txtInfoHaveNewInfo()
    Shared dealingTxt As Integer = 0
    Shared infoRowsCount As Integer = 0
    Dim seventhandler As OnEventHandler

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewConn()
        conServer()

        viewCam()

        lstControler.Clear()
        CtrlHeader()
        fill()

        lstList.Clear()
        LogsHeader()
    End Sub

    Sub CtrlHeader()
        Dim w As Integer = lstControler.Width / 4
        lstControler.Columns.Add("ID", 50, HorizontalAlignment.Left)
        lstControler.Columns.Add("Node Name", w, HorizontalAlignment.Left)
        lstControler.Columns.Add("SN", w, HorizontalAlignment.Left)
        lstControler.Columns.Add("IP", w, HorizontalAlignment.Left)
        lstControler.Columns.Add("", 0, HorizontalAlignment.Left)
        lstControler.Columns.Add("Status", 60, HorizontalAlignment.Left)
    End Sub

    Sub LogsHeader()
        Dim w As Integer = lstList.Width / 4
        lstList.Columns.Add("CardCode", w, HorizontalAlignment.Left)
        lstList.Columns.Add("Plate", w, HorizontalAlignment.Left)
        lstList.Columns.Add("Time", w, HorizontalAlignment.Left)
        lstList.Columns.Add("Status", w, HorizontalAlignment.Left)
    End Sub

    Private Sub CotrollerSettingsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CotrollerSettingsToolStripMenuItem.Click
        Dim a As New frmController
        a.ShowDialog()
    End Sub

    Private Sub TerminateSystemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TerminateSystemToolStripMenuItem.Click
        If MsgBox("Are you sure you want to terminate system? ", vbQuestion + vbYesNo + vbDefaultButton2, "Terminate System") = vbYes Then
            Application.Exit()
        End If
    End Sub

    Private Sub ServerConnectionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ServerConnectionToolStripMenuItem.Click
        frmDbSettings.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        frmCamSettings.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        frmVipRec.ShowDialog()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        txttime.Text = Format(Now, "")
    End Sub

    Private Sub ToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem4.Click
        frmAntiPassback.ShowDialog()
    End Sub

    Sub fill()
        'On Error Resume Next
        Dim rs As New Recordset
        Dim lup As Short
        rs = New Recordset
        rs = Conn.Execute("select * from tblcontroler")
        If rs.EOF = False Then
            For lup = 1 To rs.RecordCount
                If rs("Stat").Value = 1 Then
                    lstControler.Refresh()
                    Dim viewlst As New ListViewItem
                    viewlst = lstControler.Items.Add(rs("Id").Value, lup)
                    viewlst.SubItems.Add(rs("NodeName").Value)
                    viewlst.SubItems.Add(rs("SN").Value)
                    viewlst.SubItems.Add(rs("IP").Value)
                    viewlst.SubItems.Add(rs("Port").Value)
                    viewlst.SubItems.Add("")
                    controler.ControllerSN = CInt(rs("SN").Value)
                    controler.IP = rs("IP").Value
                    controler.PORT = CInt(rs("Port").Value)
                End If
                rs.MoveNext()
            Next
        End If
    End Sub

    Private Sub tmeRead_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmeRead.Tick
        tmeRead.Enabled = False
        If watching IsNot Nothing Then
            updateControllerStatus()
            If QueRecText.Count > 0 Then
                Me.Invoke(New txtInfoHaveNewInfo(AddressOf txtInfoHaveNewInfoEntry))
            End If
            Application.DoEvents()
            tmeRead.Enabled = True
        End If
    End Sub

    Private Sub evtNewInfoCallBack(ByVal text As String)
        System.Diagnostics.Debug.WriteLine("Got text through callback! {0}", text)
        receivedPktCount += 1
        SyncLock QueRecText.SyncRoot
            QueRecText.Enqueue(text)
        End SyncLock
    End Sub

    Sub StartSwipe()
        If conServer() = False Then Exit Sub

        If watching IsNot Nothing Then
            watching = New wgWatchingService
            AddHandler watching.EventHandler, New OnEventHandler(AddressOf evtNewInfoCallBack)
        End If


        Dim rs As New Recordset
        'Dim lup As Short
        rs = New Recordset
        rs = Conn.Execute("select * from tblcontroler")
        Do While rs.EOF = False
            If rs("Stat").Value = 1 Then
                Dim SNno As Integer = rs("SN").Value
                Dim IPAdd As String = rs("IP").Value
                Dim Port As String = rs("Port").Value

                Dim selectedControllers As New Dictionary(Of Integer, wgMjController)()

                'Dim config As New wgMjController
                Dim wgMjControllerWatching As New wgMjController
                'Create New 
                wgMjControllerWatching.ControllerSN = SNno
                wgMjControllerWatching.IP = IPAdd
                wgMjControllerWatching.PORT = Port

                selectedControllers.Add(wgMjControllerWatching.ControllerSN, wgMjControllerWatching)

                If selectedControllers.Count > 0 Then

                    System.Diagnostics.Debug.WriteLine("selectedControllers.Count=" + selectedControllers.Count.ToString())
                    watching.WatchingController = selectedControllers
                    tmeRead.Interval = 300
                    tmeRead.Enabled = True
                Else
                    System.Diagnostics.Debug.WriteLine("selectedControllers.Count=" + selectedControllers.Count.ToString())
                    watching.WatchingController = Nothing
                    tmeRead.Enabled = False
                End If
            End If
            rs.MoveNext()
        Loop


    End Sub

    Private Sub txtInfoHaveNewInfoEntry()
        If dealingTxt > 0 Then
            Exit Sub
        End If
        If watching.WatchingController Is Nothing Then
            '2010-8-1 08:27:15 没有选中监控的就退出
            Exit Sub
        End If
        System.Threading.Interlocked.Exchange(dealingTxt, 1)
        Dim dealt As Integer = 0
        Dim obj As Object
        Dim startTicks As Long = DateTime.Now.Ticks
        ' Date.Now.Ticks  'us
        Dim updateSpan As Long = 2000 * 1000 * 10
        Dim endTicks As Long = startTicks + updateSpan
        ' '100毫微秒的倍数  '一个Ticks＝10亿分之一秒，一毫秒＝10000Ticks
        While QueRecText.Count > 0
            SyncLock QueRecText.SyncRoot
                '取出
                obj = QueRecText.Dequeue()
            End SyncLock
            txtInfoUpdateEntry(obj)
            infoRowsCount += 1
            dealt += 1
            If DateTime.Now.Ticks > endTicks Then
                endTicks = DateTime.Now.Ticks + updateSpan
                If watching.WatchingController Is Nothing Then
                    Exit While
                End If
            End If
        End While
        Application.DoEvents()
        '显示
        System.Threading.Interlocked.Exchange(dealingTxt, 0)
    End Sub

    Private Sub txtInfoUpdateEntry(ByVal info As Object)
        Dim mjrec As New wgMjControllerSwipeRecord(TryCast(info, String))
        If mjrec.ControllerSN > 0 Then
            Try
                If Not watching.WatchingController.ContainsKey(CInt(mjrec.ControllerSN)) Then
                    Return
                End If
            Catch generatedExceptionName As Exception
                Return
            End Try

            Delete_Image()
            txtHandler.Text = vbNullString
            txtCardCode.Text = vbNullString
            txtDoor.Text = vbNullString
            txtMsg.Text = "---"

            txtHandler.AppendText(mjrec.ToDisplaySimpleInfo(True))

            'TextBox1.Text = Replace(TextBox1.Text, " ", vbNullString)
            Dim reRep As String = Mid(txtHandler.Text, 10, 10)
            
            txtCardCode.Text = Regex.Replace(reRep, "[^0-9]", "")
            Dim CcodeL As Long = Len(txtCardCode.Text)
            Dim LtobeAdd As Long = 8 - CcodeL

            Dim DoorS As Long = 33 - LtobeAdd

            txtDoor.Text = Mid(txtHandler.Text, DoorS, 5)
            txtDoor.Text = Mid(txtDoor.Text, 2)

            txtDoor.Text = Replace(txtDoor.Text, "[", vbNullString)
            txtDoor.Text = Replace(txtDoor.Text, "]", vbNullString)
            'Timer1.Interval = 5000
            tmeRead.Enabled = False

            Dim strDoor As String = Trim(txtDoor.Text)
            Dim strIn As String = "In"
            Dim strOut As String = "Out"

            Select Case strDoor

                Case strIn
                    Camera_Capture1()
                    If ViewIn(txtCardCode.Text) = False Then
                        Exit Sub
                    End If

                    If DateExp(txtCardCode.Text) = True Then
                        txtMsg.Text = "CARD ALREADY EXPIRED"
                        Exit Sub
                    End If

                    If PassbackStat() = True Then
                        If chkTimeLogs(txtCardCode.Text) = True Then
                            txtMsg.Text = "CARD ALREADY LOGIN"
                            Exit Sub
                        End If
                    End If

                    saveIn()

                    Dim doorNo As Integer = 1
                    If controler.RemoteOpenDoorIP(doorNo) > 0 Then
                        txtMsg.Text = "ACCESSED"
                        tmeRead.Enabled = True
                    End If
                Case strOut
                    Camera_Capture2()
                    If ViewOut(txtCardCode.Text) = False Then
                        Exit Sub
                    End If

                    If DateExp(txtCardCode.Text) = True Then
                        txtMsg.Text = "CARD ALREADY EXPIRED"
                        Exit Sub
                    End If

                    If PassbackStat() = True Then
                        If chkTimeLogs(txtCardCode.Text) = False Then
                            txtMsg.Text = "LOGIN FIRST"
                            Exit Sub
                        Else
                            saveInOut(txtCardCode.Text)
                            delTimein(txtCardCode.Text)
                        End If
                    Else
                        If chkTimeLogs(txtCardCode.Text) = False Then
                            saveOut()
                        Else
                            saveInOut(txtCardCode.Text)
                            delTimein(txtCardCode.Text)
                        End If
                    End If

                    Dim doorNo As Integer = 2
                    If controler.RemoteOpenDoorIP(doorNo) > 0 Then
                        txtMsg.Text = "ACCESSED"
                        tmeRead.Enabled = True
                    End If
            End Select
            ' If strDoor = strIn Then

            ' ElseIf strDoor = strOut Then

            '   End If

            Delete_Image()
            txtHandler.Text = vbNullString
            txtCardCode.Text = vbNullString
            txtDoor.Text = vbNullString
        End If
    End Sub

    Public Sub updateControllerStatus()

        If watching Is Nothing Then

        Else
            lstControler.Clear()
            CtrlHeader()

            Dim rs As New Recordset
            Dim lup As Short
            rs = New Recordset
            rs = Conn.Execute("select * from tblcontroler")
            Do While rs.EOF = False
                If rs("Stat").Value = 1 Then

                    lstControler.Refresh()
                    Dim viewlst As New ListViewItem
                    viewlst = lstControler.Items.Add(rs("Id").Value, lup)
                    viewlst.SubItems.Add(rs("NodeName").Value)
                    viewlst.SubItems.Add(rs("SN").Value)
                    viewlst.SubItems.Add(rs("IP").Value)
                    viewlst.SubItems.Add(rs("Port").Value)
                    viewlst.SubItems.Add("")

                    Dim conRunInfo As wgMjControllerRunInformation = Nothing
                    Dim commStatus As Integer
                    commStatus = watching.CheckControllerCommStatus(CInt(rs("SN").Value), conRunInfo)

                    If commStatus = -1 Then
                        lstControler.Clear()
                        CtrlHeader()
                        viewlst = lstControler.Items.Add(rs("Id").Value, lup)
                        viewlst.SubItems.Add(rs("NodeName").Value)
                        viewlst.SubItems.Add(rs("SN").Value)
                        viewlst.SubItems.Add(rs("IP").Value)
                        viewlst.SubItems.Add(rs("Port").Value)
                        viewlst.SubItems.Add("Failed")
                    ElseIf commStatus = 1 Then
                        lstControler.Clear()
                        CtrlHeader()
                        viewlst = lstControler.Items.Add(rs("Id").Value, lup)
                        viewlst.SubItems.Add(rs("NodeName").Value)
                        viewlst.SubItems.Add(rs("SN").Value)
                        viewlst.SubItems.Add(rs("IP").Value)
                        viewlst.SubItems.Add(rs("Port").Value)
                        viewlst.SubItems.Add("OK")
                    End If
                End If
                rs.MoveNext()
            Loop
            End If

    End Sub

    Private Sub cmdStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStart.Click
        StartSwipe()
        cmdStart.Enabled = False
    End Sub

    Private Sub cmdStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStop.Click
        cmdStart.Enabled = True

        If watching IsNot Nothing Then
            watching.WatchingController = Nothing
            tmeRead.Enabled = False
        End If
        System.Threading.Interlocked.Exchange(dealingTxt, 0)
    End Sub

    Function ViewIn(ByVal Ccode As String) As Boolean
        If conServer() = False Then Return False

        Try
            Dim rs As New Recordset
            rs = New Recordset
            rs = Conn.Execute("select * from vweinfo where CardCode = '" & Ccode & "'")
            If rs.EOF = False Then
                txtCode1.Text = rs("CardCode").Value
                txtPlate1.Text = rs("PlateNo").Value
                txtName1.Text = rs("Name").Value
                txtEntryTime.Text = Format(Now, "yyyy-MM-dd HH:mm:ss")
                Return True
            Else
                txtCode1.Text = "Unknown Card"
                txtPlate1.Text = "Unknown Card"
                txtName1.Text = "Unknown Card"
                txtEntryTime.Text = Format(Now, "yyyy-MM-dd HH:mm:ss")
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Function ViewOut(ByVal Ccode As String) As Boolean
        If conServer() = False Then Return False

        Try
            Dim rs As New Recordset
            rs = New Recordset
            rs = Conn.Execute("select * from vweinfo where CardCode = '" & Ccode & "'")
            If rs.EOF = False Then
                txtCode2.Text = rs("CardCode").Value
                txtPlate2.Text = rs("PlateNo").Value
                txtName2.Text = rs("Name").Value
                txtExitTime.Text = Format(Now, "yyyy-MM-dd HH:mm:ss")
                Return True
            Else
                txtCode2.Text = "Unknown Card"
                txtPlate2.Text = "Unknown Card"
                txtName2.Text = "Unknown Card"
                txtExitTime.Text = Format(Now, "yyyy-MM-dd HH:mm:ss")
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Function DateExp(ByVal Ccode As String) As Boolean
        If conServer() = False Then Return False

        Try
            Dim rs As New Recordset
            rs = New Recordset
            rs = Conn.Execute("select * from tblcards where CardCode = '" & Ccode & "'")
            If rs.EOF = False Then
                Dim dtNow As Date = Now
                Dim dtExp As Date = rs("DateExpired").Value
                If dtNow >= dtExp Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Function chkTimeLogs(ByVal Ccode As String) As Boolean
        If conServer() = False Then Return False

        Try
            Dim rs As New Recordset
            rs = New Recordset

            rs = Conn.Execute("select * from tbltimein where CardCode = '" & Ccode & "'")
            If rs.EOF = False Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Sub fillLogs(ByVal Ccode As String, ByVal PlateNum As String, ByVal tme As String, ByVal Stat As String)
        lstList.Refresh()
        Dim viewlst As New ListViewItem
        viewlst = lstList.Items.Add(Ccode)
        viewlst.SubItems.Add(PlateNum)
        viewlst.SubItems.Add(tme)
        viewlst.SubItems.Add(Stat)
    End Sub

    Sub saveIn()
        If conServer() = False Then
            txtMsg.Text = "Server disconnected"
            Exit Sub
        End If

        Try
            Dim rs As New Recordset
            rs.Open("select * from tbltimein", Conn, 1, 2)
            rs.AddNew()
            rs("CardCode").Value = txtCardCode.Text
            rs("Plate").Value = txtPlate1.Text
            rs("TimeIn").Value = Now
            If Get_ImageName() <> Nothing Then
                Dim strem As New Stream
                strem.Type = StreamTypeEnum.adTypeBinary
                strem.Open()
                strem.LoadFromFile(Get_ImageName)
                rs("PicIn").Value = strem.Read
            End If
            rs.Update()

            fillLogs(txtCardCode.Text, txtPlate1.Text, Now, "In")
        Catch ex As Exception
            txtMsg.Text = ex.Message
        End Try
    End Sub

    Sub saveOut()
        If conServer() = False Then
            txtMsg.Text = "Server disconnected"
            Exit Sub
        End If

        Try
            Dim rs As New Recordset
            rs.Open("select * from tbltimeOut", Conn, 1, 2)
            rs.AddNew()
            rs("CardCode").Value = txtCardCode.Text
            rs("Plate").Value = txtPlate2.Text
            rs("TimeOut").Value = Now
            If Get_ImageName() <> Nothing Then
                Dim strem As New Stream
                strem.Type = StreamTypeEnum.adTypeBinary
                strem.Open()
                strem.LoadFromFile(Get_ImageName)
                rs("PicOut").Value = strem.Read
            End If
            rs.Update()

            fillLogs(txtCardCode.Text, txtPlate2.Text, Now, "Out")
        Catch ex As Exception
            txtMsg.Text = ex.Message
        End Try
    End Sub

    Sub saveInOut(ByVal Ccode As String)
        If conServer() = False Then
            txtMsg.Text = "Server disconnected"
            Exit Sub
        End If

        Try
            Dim rs1 As New Recordset
            rs1 = New Recordset
            rs1 = Conn.Execute("select * from tbltimein where CardCode = '" & Ccode & "'")
            If rs1.EOF = False Then
                Dim rs As New Recordset
                rs.Open("select * from tblinout", Conn, 1, 2)
                rs.AddNew()
                rs("CardCode").Value = txtCardCode.Text
                rs("Plate").Value = txtPlate2.Text
                rs("TimeIn").Value = rs1("TimeIn").Value
                rs("PicIn").Value = rs1("PicIn").Value
                rs("TimeOut").Value = Now
                If Get_ImageName() <> Nothing Then
                    Dim strem As New Stream
                    strem.Type = StreamTypeEnum.adTypeBinary
                    strem.Open()
                    strem.LoadFromFile(Get_ImageName)
                    rs("PicOut").Value = strem.Read
                End If
                rs.Update()

                fillLogs(txtCardCode.Text, txtPlate2.Text, Now, "Out")
            End If
        Catch ex As Exception
            txtMsg.Text = ex.Message
        End Try
    End Sub

    Sub delTimein(ByVal Ccode As String)
        If conServer() = False Then Exit Sub

        Try
            Dim rs As New Recordset
            rs = New Recordset
            rs = Conn.Execute("delete from tbltimein where CardCode = '" & Ccode & "'")
        Catch ex As Exception
            txtMsg.Text = ex.Message
        End Try
    End Sub

    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
        frmlogs.ShowDialog()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        If controler.RemoteOpenDoorIP(1) > 0 Then
            MsgBox("Successfully triggered!", vbInformation)
        Else
            MsgBox("Fail to triggered!", vbExclamation)
        End If

    End Sub
End Class
