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
Public Class frmEasyEnroll
    Public watching As New wgWatchingService
    Public Event EventHandler(ByVal message As String)
    Public receivedPktCount As New Integer
    Public QueRecText As New Queue

    Private Delegate Sub txtInfoHaveNewInfo()
    Shared dealingTxt As Integer = 0
    Shared infoRowsCount As Integer = 0
    Dim seventhandler As OnEventHandler

    Dim OwID As String = vbNullString

    Private Sub evtNewInfoCallBack(ByVal text As String)
        System.Diagnostics.Debug.WriteLine("Got text through callback! {0}", text)
        receivedPktCount += 1
        SyncLock QueRecText.SyncRoot
            QueRecText.Enqueue(text)
        End SyncLock
    End Sub

    Sub StartSwipe(ByVal node As String)
        If conServer() = False Then Exit Sub

        If watching IsNot Nothing Then
            watching = New wgWatchingService
            AddHandler watching.EventHandler, New OnEventHandler(AddressOf evtNewInfoCallBack)
        End If


        Dim rs As New Recordset
        rs = New Recordset
        rs = Conn.Execute("select * from tblcontroler where NodeName = '" & node & "'")
        If rs.EOF = False Then
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

                Timer1.Interval = 300
                Timer1.Enabled = True
            Else
                System.Diagnostics.Debug.WriteLine("selectedControllers.Count=" + selectedControllers.Count.ToString())
                watching.WatchingController = Nothing
                Timer1.Enabled = False
            End If

        End If

    End Sub

    Private Sub cmdConn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConn.Click
        StartSwipe(cboNode.Text)
        cmdConn.Enabled = False
    End Sub

    Private Sub cmdDiscon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDiscon.Click
        cmdConn.Enabled = True

        If watching IsNot Nothing Then
            watching.WatchingController = Nothing
            Timer1.Enabled = False
        End If
        System.Threading.Interlocked.Exchange(dealingTxt, 0)
    End Sub

    Public Sub updateControllerStatus(ByVal Node As String)
        If conServer() = False Then Exit Sub

        If watching Is Nothing Then

        Else
            Dim rs As New Recordset
            rs = New Recordset
            rs = Conn.Execute("select * from tblcontroler where NodeName = '" & Node & "'")
            If rs.EOF = False Then
                Dim SNno As Integer = rs("SN").Value

                Dim conRunInfo As wgMjControllerRunInformation = Nothing
                Dim commStatus As Integer
                commStatus = watching.CheckControllerCommStatus(SNno, conRunInfo)

                If commStatus = -1 Then
                    'MsgBox("Falied to connect!", vbExclamation, "Start")
                ElseIf commStatus = 1 Then
                    'MsgBox("Successfully connected!", vbInformation, "Start")
                End If
            End If
        End If
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
            TextBox1.Text = vbNullString
            txtCode.Text = vbNullString

            TextBox1.AppendText(mjrec.ToDisplaySimpleInfo(True))


            Dim reRep As String = Mid(TextBox1.Text, 10, 10)
            txtCode.Text = Regex.Replace(reRep, "[^0-9]", "")
            txtCode.Focus()


        End If
    End Sub

    Private Sub txtInfoHaveNewInfoEntry()
        If dealingTxt > 0 Then
            Exit Sub
        End If
        If watching.WatchingController Is Nothing Then
            Exit Sub
        End If
        System.Threading.Interlocked.Exchange(dealingTxt, 1)
        Dim dealt As Integer = 0
        Dim obj As Object
        Dim startTicks As Long = DateTime.Now.Ticks
        Dim updateSpan As Long = 2000 * 1000 * 10
        Dim endTicks As Long = startTicks + updateSpan
        While QueRecText.Count > 0
            SyncLock QueRecText.SyncRoot
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

        System.Threading.Interlocked.Exchange(dealingTxt, 0)
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        If watching IsNot Nothing Then
            updateControllerStatus(cboNode.Text)
            If QueRecText.Count > 0 Then
                Me.Invoke(New txtInfoHaveNewInfo(AddressOf txtInfoHaveNewInfoEntry))
            End If
            Application.DoEvents()
            Timer1.Enabled = True
        End If
    End Sub

    Public Sub nodeList(ByVal cbo As ComboBox)
        Dim rs As New Recordset
        cbo.Items.Clear()

        rs = New Recordset
        rs = Conn.Execute("SELECT * from tblcontroler")

        While rs.EOF = False
            cbo.Items.Add(rs("NodeName").Value)
            rs.MoveNext()
        End While
    End Sub

    Private Sub frmEasyEnroll_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        nodeList(cboNode.ComboBox)
        lstlist.Clear()
        Header()
        fill()
    End Sub

    Function parkerID() As Integer
        If conServer() = False Then Return 1

        Dim rs As New Recordset
        rs = Conn.Execute("select * from tblowner order by OwnerId desc")
        If rs.EOF = False Then
            Return rs("OwnerID").Value + 1
        Else
            Return 1
        End If
    End Function


    Sub saveVIP()
        If conServer() = False Then
            MsgBox("Please connect to server!    ", vbExclamation, "Database connection")
            frmDbSettings.ShowDialog()
            Exit Sub
        End If

        'Try
        OwID = parkerID()
        save()

        Dim rs As New Recordset
        rs = New Recordset
        rs.Open("select * from tblowner", Conn, 1, 2)
        rs.AddNew()
        rs("OwnerID").Value = OwID
        rs("Name").Value = txtCArdNo.Value.ToString
        rs("Position").Value = "na"
        rs("Gender").Value = "na"
        rs("BirthDate").Value = Now
        rs("ContactNo").Value = "na"
        rs("Address").Value = "na"
        rs.Update()

        txtCArdNo.Value = txtCArdNo.Value + 1

        'Catch ex As Exception
        'MsgBox(ex.Message, vbCritical, "Save")
        'End Try
    End Sub

    Sub save()
        If conServer() = False Then
            MsgBox("Please connect to server!    ", vbExclamation, "Database connection")
            frmDbSettings.ShowDialog()
            Exit Sub
        End If


        Try
            Dim rs As New Recordset
            rs = New Recordset
            rs.Open("select * from tblcards", Conn, 1, 2)
            rs.AddNew()
            rs("CardCode").Value = txtCode.Text
            rs("PlateNo").Value = "na"
            rs("DateEnrolled").Value = Format(Now, "yyyy-MM-dd")

            Dim datenow As Date = Now
            Dim strDateNow As String = Format(datenow.AddYears(1), "yyyy-MM-dd")

            rs("DateExpired").Value = strDateNow
            rs("OwnerID").Value = OwID
            rs.Update()

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Save")
        End Try
    End Sub

    Function chkCardCod(ByVal cc As String) As Boolean
        If conServer() = False Then Return True

        Try
            Dim rs As New Recordset
            rs = New Recordset
            rs = Conn.Execute("select CardCode from tblcards where CardCode = '" & cc & "'")
            If rs.EOF = False Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return True
        End Try
    End Function

    Private Sub txtCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtCode.Text = vbNullString Then Exit Sub

            If MsgBox("Save this sticker?", vbYesNo + vbQuestion, "Save") = vbYes Then
                If chkCardCod(txtCode.Text) = False Then

                    saveVIP()
                    txtCode.Text = vbNullString
                    lstlist.Clear()
                    Header()
                    fill()

                    With frmSystemMain
                        saveAudiUpdate(.UserAcc.Text, .SystemTag.Text, "Card Code : " & txtCode.Text & " successfully saved")
                    End With

                Else
                    MsgBox("Sticker already exist!", vbExclamation, "Save")
                    txtCode.Text = vbNullString
                    txtCode.Focus()
                End If
            End If
        End If
    End Sub

    Sub Header()
        Dim w As Integer = lstlist.Width / 3
        lstList.Columns.Clear()
        lstlist.Columns.Add("ID", w, HorizontalAlignment.Left)
        lstlist.Columns.Add("Name", w, HorizontalAlignment.Left)
        lstlist.Columns.Add("CardCode", w, HorizontalAlignment.Left)
    End Sub

    Sub fill()
        'On Error Resume Next
        Dim rs As New Recordset
        Dim lup As Short
        rs = New Recordset
        rs = Conn.Execute("select id,Name,CardCode from vweinfo order by id desc limit 20;")
        If rs.EOF = False Then
            For lup = 1 To rs.RecordCount
                lstList.Refresh()
                Dim viewlst As New ListViewItem
                viewlst = lstList.Items.Add(rs("Id").Value, lup)
                viewlst.SubItems.Add(rs("Name").Value)
                viewlst.SubItems.Add(rs("CardCode").Value)
                rs.MoveNext()
            Next
        End If
    End Sub


    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If txtCode.Text = vbNullString Then Exit Sub

        If MsgBox("Save this sticker?", vbYesNo + vbQuestion, "Save") = vbYes Then
            If chkCardCod(txtCode.Text) = False Then

                saveVIP()
                txtCode.Text = vbNullString
                lstlist.Clear()
                Header()
                fill()

                With frmSystemMain
                    saveAudiUpdate(.UserAcc.Text, .SystemTag.Text, "Card Code : " & txtCode.Text & " successfully saved")
                End With

            Else
                MsgBox("Sticker already exist!", vbExclamation, "Save")
                txtCode.Text = vbNullString
                txtCode.Focus()
            End If
        End If

    End Sub

    Private Sub txtCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCode.TextChanged

    End Sub
End Class