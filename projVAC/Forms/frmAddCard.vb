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

Public Class frmAddCard
    Public watching As New wgWatchingService
    Public Event EventHandler(ByVal message As String)
    Public receivedPktCount As New Integer
    Public QueRecText As New Queue

    Private Delegate Sub txtInfoHaveNewInfo()
    Shared dealingTxt As Integer = 0
    Shared infoRowsCount As Integer = 0
    Dim seventhandler As OnEventHandler

    Private Sub frmAddCard_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Call cmdDiscon_Click(sender, New System.EventArgs)
    End Sub

    Private Sub frmAddCard_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        nodeList(cboNode.ComboBox)
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


    Private Sub evtNewInfoCallBack(ByVal text As String)
        System.Diagnostics.Debug.WriteLine("Got text through callback! {0}", text)
        receivedPktCount += 1
        SyncLock QueRecText.SyncRoot
            QueRecText.Enqueue(text)
        End SyncLock
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

    Private Sub cboNode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboNode.KeyPress
        If Asc(e.KeyChar) > 0 Then
            e.KeyChar = vbNullString
        End If
    End Sub

    Sub save()
        If conServer() = False Then
            MsgBox("Please connect to server!    ", vbExclamation, "Database connection")
            frmDbSettings.ShowDialog()
            Exit Sub
        End If

        Dim OwID As String = frmAddVip.txtParkerID.Text
        Try
            Dim rs As New Recordset
            rs = New Recordset
            rs.Open("select * from tblcards", Conn, 1, 2)
            rs.AddNew()
            rs("CardCode").Value = txtCode.Text
            rs("PlateNo").Value = txtPlate.Text
            rs("DateEnrolled").Value = dtEnrolled.Value
            rs("DateExpired").Value = dtExpired.Value
            rs("OwnerID").Value = OwID
            rs.Update()
            MsgBox("Successfully saved!", vbInformation, "Save")
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Save")
        End Try
    End Sub

    Sub edit(ByVal code As String)
        If conServer() = False Then
            MsgBox("Please connect to server!    ", vbExclamation, "Database connection")
            frmDbSettings.ShowDialog()
            Exit Sub
        End If

        Try
            Dim rs As New Recordset
            rs = New Recordset
            rs.Open("select * from tblcards where CardCode = '" & code & "'", Conn, 1, 2)
            rs("PlateNo").Value = txtPlate.Text
            rs("DateEnrolled").Value = dtEnrolled.Value
            rs("DateExpired").Value = dtExpired.Value
            rs("OwnerID").Value = frmAddVip.txtParkerID.Text
            MsgBox("Updated successfully!", vbInformation, "Save")
            rs.Update()
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Save")
        End Try
    End Sub

    Function ChkField() As Boolean
        If txtCode.Text = vbNullString Or txtPlate.Text = vbNullString Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        With frmAddVip
            If Me.Text = "New Card" Then
                If ChkField() = True Then
                    MsgBox("Please fill up the blanks! ", vbExclamation, "Save")
                    Exit Sub
                End If
                save()
                .lstCards.Clear()
                .cHeader()
                fillcards(.lstCards, .txtParkerID.Text)

                With frmSystemMain
                    saveAudiUpdate(.UserAcc.Text, .SystemTag.Text, "Card Code : " & txtCode.Text & " successfully saved")
                End With

                Me.Close()
            Else
                edit(txtCode.Text)
                .lstCards.Clear()
                .cHeader()
                fillcards(.lstCards, .txtParkerID.Text)

                With frmSystemMain
                    saveAudiUpdate(.UserAcc.Text, .SystemTag.Text, "Card Code : " & txtCode.Text & " successfully updated")
                End With

                Me.Close()
            End If
        End With
    End Sub

    Private Sub txtCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCode.KeyPress
        If Asc(e.KeyChar) >= 58 And Asc(e.KeyChar) <> 8 Then
            e.KeyChar = vbNullString
        End If
        If Asc(e.KeyChar) <= 47 And Asc(e.KeyChar) <> 8 Then
            e.KeyChar = vbNullString
        End If
    End Sub

End Class