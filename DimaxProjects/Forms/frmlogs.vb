Imports ADODB
Public Class frmlogs
    Public rsPRS As New Recordset
    Public id As String
    Public rsIO As Recordset
    Public rsLogs As Recordset

    Public categ As String

    Sub EntHead()
        Dim w As Integer = LstEmpRec.Width / 4
        LstEmpRec.Columns.Clear()
        LstEmpRec.Columns.Add("ID Log", w, HorizontalAlignment.Left)
        LstEmpRec.Columns.Add("PlateNo", w, HorizontalAlignment.Left)
        LstEmpRec.Columns.Add("Name", 350, HorizontalAlignment.Left)
        LstEmpRec.Columns.Add("TimeIn", w, HorizontalAlignment.Left)
        'LstEmpRec.Columns.Add("Date", 100, HorizontalAlignment.Left)
        'LstEmpRec.Columns.Add("Remarks", 120, HorizontalAlignment.Left)
    End Sub
    Sub ExtHead()
        LstEmpRec.Columns.Clear()
        Dim w As Integer = LstEmpRec.Width / 4
        LstEmpRec.Columns.Add("ID Log", w, HorizontalAlignment.Left)
        LstEmpRec.Columns.Add("PlateNo", w, HorizontalAlignment.Left)
        LstEmpRec.Columns.Add("Name", 350, HorizontalAlignment.Left)
        LstEmpRec.Columns.Add("TimeOut", w, HorizontalAlignment.Left)
        'LstEmpRec.Columns.Add("Date", 100, HorizontalAlignment.Left)
        'LstEmpRec.Columns.Add("Remarks", 120, HorizontalAlignment.Left)
    End Sub
    Sub AttHead()
        Dim w As Integer = LstEmpRec.Width / 5
        LstEmpRec.Columns.Clear()
        LstEmpRec.Columns.Add("ID Log", w, HorizontalAlignment.Left)
        LstEmpRec.Columns.Add("PlateNo", w, HorizontalAlignment.Left)
        LstEmpRec.Columns.Add("Name", 200, HorizontalAlignment.Left)
        LstEmpRec.Columns.Add("TimeIn", w, HorizontalAlignment.Left)
        LstEmpRec.Columns.Add("TimeOut", w, HorizontalAlignment.Left)
        'LstEmpRec.Columns.Add("Remarks", 120, HorizontalAlignment.Left)
    End Sub

    Sub LogsHead()
        Dim w As Integer = LstEmpRec.Width / 5
        LstEmpRec.Columns.Clear()
        LstEmpRec.Columns.Add("ID Log", w, HorizontalAlignment.Left)
        LstEmpRec.Columns.Add("PlateNo", w, HorizontalAlignment.Left)
        LstEmpRec.Columns.Add("Name", 200, HorizontalAlignment.Left)
        LstEmpRec.Columns.Add("TimeIn", w, HorizontalAlignment.Left)
        LstEmpRec.Columns.Add("TimeOut", w, HorizontalAlignment.Left)
        'LstEmpRec.Columns.Add("Remarks", 120, HorizontalAlignment.Left)
    End Sub

    Sub InOutAll()
        If conServer() = False Then
            MsgBox("Please connect to server!    ", vbExclamation, "Server")
            frmDbSettings.ShowDialog()
            Exit Sub
        End If
        'LstEmpRec.Clear()
        'Dim rs As New Recordset
        Dim lup As Short
        rsLogs = New Recordset
        rsLogs = Conn.Execute("select * from vweinout")
        If rsLogs.EOF = False Then
            For lup = 1 To rsLogs.RecordCount
                LstEmpRec.Refresh()
                Dim viewlst As New ListViewItem
                viewlst = LstEmpRec.Items.Add(rsLogs("Id").Value, lup)
                viewlst.SubItems.Add(rsLogs("Plate").Value)
                viewlst.SubItems.Add(rsLogs("Name").Value)
                viewlst.SubItems.Add(rsLogs("TimeIn").Value)
                viewlst.SubItems.Add(rsLogs("TimeOut").Value)
                'viewlst.SubItems.Add(rs("Remarks").Value)
                rsLogs.MoveNext()
            Next
        End If
    End Sub
    Sub Entall()
        If conServer() = False Then
            MsgBox("Please connect to server!    ", vbExclamation, "Server")
            frmDbSettings.ShowDialog()
            Exit Sub
        End If
        'LstEmpRec.Clear()
        ' Dim rs As New Recordset
        Dim lup As Short
        rsPRS = New Recordset
        rsPRS = Conn.Execute("select * from vwetimein")
        If rsPRS.EOF = False Then
            For lup = 1 To rsPRS.RecordCount
                LstEmpRec.Refresh()
                Dim viewlst As New ListViewItem
                viewlst = LstEmpRec.Items.Add(rsPRS("ID").Value, lup)
                viewlst.SubItems.Add(rsPRS("Plate").Value)
                viewlst.SubItems.Add(rsPRS("Name").Value)
                viewlst.SubItems.Add(rsPRS("TimeIn").Value)
                'viewlst.SubItems.Add(rs("Date").Value)
                'viewlst.SubItems.Add(rs("Remarks").Value)
                rsPRS.MoveNext()
            Next
        End If
    End Sub
    Sub Extall()
        If conServer() = False Then
            MsgBox("Please connect to server!    ", vbExclamation, "Server")
            frmDbSettings.ShowDialog()
            Exit Sub
        End If
        'LstEmpRec.Clear()
        ' Dim rs As New Recordset
        Dim lup As Short
        rsIO = New Recordset
        rsIO = Conn.Execute("select * from vwetimeOut")
        If rsIO.EOF = False Then
            For lup = 1 To rsIO.RecordCount
                LstEmpRec.Refresh()
                Dim viewlst As New ListViewItem
                viewlst = LstEmpRec.Items.Add(rsIO("ID").Value, lup)
                viewlst.SubItems.Add(rsIO("Plate").Value)
                viewlst.SubItems.Add(rsIO("Name").Value)
                viewlst.SubItems.Add(rsIO("TimeOut").Value)
                'viewlst.SubItems.Add(rsIO("Status").Value)
                'viewlst.SubItems.Add(rs("Date").Value)
                'viewlst.SubItems.Add(rs("Remarks").Value)
                rsIO.MoveNext()
            Next
        End If
    End Sub
    
    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        Select Case cboCateg.Text
            Case "Time In"
                LstEmpRec.Clear()
                EntHead()
                Entall()
                cmdDel.Enabled = True
                cmdPrint.Enabled = True
            Case "Time Out"
                LstEmpRec.Clear()
                ExtHead()
                Extall()
                cmdDel.Enabled = True
                cmdPrint.Enabled = True
            Case "Logs Report"
                LstEmpRec.Clear()
                LogsHead()
                InOutAll()
                cmdDel.Enabled = True
                cmdPrint.Enabled = True
        End Select
        categ = "All"

        With frmSystemMain
            saveAudiUpdate(.UserAcc.Text, .SystemTag.Text, "View all report generation")
        End With

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Select Case cboCateg.Text
            Case "Time In"
                LstEmpRec.Clear()
                EntHead()
                If SirchCateg.Text = "By Date" Then
                    EntSrch()
                    cmdDel.Enabled = True
                    cmdPrint.Enabled = True
                    categ = "Searchdt"
                Else
                    EntSrch2()
                    cmdDel.Enabled = True
                    cmdPrint.Enabled = True
                    categ = "Search"
                End If
            Case "Time Out"
                LstEmpRec.Clear()
                ExtHead()
                If SirchCateg.Text = "By Date" Then
                    ExtSrch()
                    cmdDel.Enabled = True
                    cmdPrint.Enabled = True
                    categ = "Searchdt"
                Else
                    ExtSrch2()
                    cmdDel.Enabled = True
                    cmdPrint.Enabled = True
                    categ = "Search"
                End If
            Case "Logs Report"
                LstEmpRec.Clear()
                LogsHead()
                If SirchCateg.Text = "By Date" Then
                    LogsSrch()
                    cmdDel.Enabled = True
                    cmdPrint.Enabled = True
                    categ = "Searchdt"
                Else
                    LogsSrch2()
                    cmdDel.Enabled = True
                    cmdPrint.Enabled = True
                    categ = "Search"
                End If
        End Select

        With frmSystemMain
            saveAudiUpdate(.UserAcc.Text, .SystemTag.Text, "Search report generation")
        End With
    End Sub

    Sub EntSrch()
        If conServer() = False Then
            MsgBox("Please connect to server!    ", vbExclamation, "Server")
            frmDbSettings.ShowDialog()
            Exit Sub
        End If

        Dim lup As Short
        Dim TmeInTo As String
        Dim TmeInFrm As String

        TmeInFrm = Format(CDate(dtDateFrm.Value), "yyyy-MM-dd") + " " + Format(CDate(dtTmeFrm.Value), "HH:mm:ss tt")
        TmeInTo = Format(CDate(dtDateTo.Value), "yyyy-MM-dd") + " " + Format(CDate(dtTmeTo.Value), "HH:mm:ss tt")

        rsPRS = New Recordset
        rsPRS = Conn.Execute("select * from vwetimein where TimeIn >= '" & TmeInFrm & "' and TimeIn <='" & TmeInTo & "'")
        If rsPRS.EOF = False Then
            For lup = 1 To rsPRS.RecordCount
                LstEmpRec.Refresh()
                Dim viewlst As New ListViewItem
                viewlst = LstEmpRec.Items.Add(rsPRS("ID").Value, lup)
                viewlst.SubItems.Add(rsPRS("Plate").Value)
                viewlst.SubItems.Add(rsPRS("Name").Value)
                viewlst.SubItems.Add(rsPRS("TimeIn").Value)
                ' viewlst.SubItems.Add(rsPRS("Status").Value)
                rsPRS.MoveNext()
            Next
        End If
    End Sub

    Sub DelEntSrch()
        If conServer() = False Then
            MsgBox("Please connect to server!    ", vbExclamation, "Server")
            frmDbSettings.ShowDialog()
            Exit Sub
        End If

        Dim lup As Short
        Dim TmeInTo As String
        Dim TmeInFrm As String

        TmeInFrm = Format(CDate(dtDateFrm.Value), "yyyy-MM-dd") + " " + Format(CDate(dtTmeFrm.Value), "HH:mm:ss tt")
        TmeInTo = Format(CDate(dtDateTo.Value), "yyyy-MM-dd") + " " + Format(CDate(dtTmeTo.Value), "HH:mm:ss tt")

        rsPRS = New Recordset
        rsPRS = Conn.Execute("delete from tbltimein where TimeIn >= '" & TmeInFrm & "' and TimeIn <='" & TmeInTo & "'")
       
    End Sub

    Sub DelEntSrchAll()
        If conServer() = False Then
            MsgBox("Please connect to server!    ", vbExclamation, "Server")
            frmDbSettings.ShowDialog()
            Exit Sub
        End If

        Dim lup As Short
        Dim TmeInTo As String
        Dim TmeInFrm As String

        TmeInFrm = Format(CDate(dtDateFrm.Value), "yyyy-MM-dd") + " " + Format(CDate(dtTmeFrm.Value), "HH:mm:ss tt")
        TmeInTo = Format(CDate(dtDateTo.Value), "yyyy-MM-dd") + " " + Format(CDate(dtTmeTo.Value), "HH:mm:ss tt")

        rsPRS = New Recordset
        rsPRS = Conn.Execute("delete from tbltimein")

    End Sub

    Sub EntSrch2()
        If conServer() = False Then
            MsgBox("Please connect to server!    ", vbExclamation, "Server")
            frmDbSettings.ShowDialog()
            Exit Sub
        End If

        rsPRS = New Recordset
        rsPRS = Conn.Execute("select * from vwetimein where " & SirchCateg.Text & " like '" & txtInput.Text & "%'")
        If rsPRS.EOF = False Then
            For lup = 1 To rsPRS.RecordCount
                LstEmpRec.Refresh()
                Dim viewlst As New ListViewItem
                viewlst = LstEmpRec.Items.Add(rsPRS("ID").Value, lup)
                viewlst.SubItems.Add(rsPRS("Plate").Value)
                viewlst.SubItems.Add(rsPRS("Name").Value)
                viewlst.SubItems.Add(rsPRS("TimeIn").Value)
                ' viewlst.SubItems.Add(rsPRS("Status").Value)
                'viewlst.SubItems.Add(rs("Date").Value)
                'viewlst.SubItems.Add(rs("Remarks").Value)
                rsPRS.MoveNext()
            Next
        End If
    End Sub

    Sub DelEntSrch2()
        If conServer() = False Then
            MsgBox("Please connect to server!    ", vbExclamation, "Server")
            frmDbSettings.ShowDialog()
            Exit Sub
        End If

        rsPRS = New Recordset
        rsPRS = Conn.Execute("delete from tbltimein where " & SirchCateg.Text & " like '" & txtInput.Text & "%'")
        
    End Sub

    Sub ExtSrch()
        'On Error Resume Next
        If conServer() = False Then
            MsgBox("Please connect to server!    ", vbExclamation, "Server")
            frmDbSettings.ShowDialog()
            Exit Sub
        End If
        'LstEmpRec.Clear()

        Dim lup As Short
        Dim TmeInTo As String
        Dim TmeInFrm As String
        'Dim DateInFrm As String
        'Dim DateInTo As String

        TmeInFrm = Format(CDate(dtDateFrm.Value), "yyyy-MM-dd") + " " + Format(CDate(dtTmeFrm.Value), "HH:mm:ss tt")
        TmeInTo = Format(CDate(dtDateTo.Value), "yyyy-MM-dd") + " " + Format(CDate(dtTmeTo.Value), "HH:mm:ss tt")
        'Dim rs As New Recordset
        rsIO = New Recordset
        rsIO = Conn.Execute("select * from vwetimeOut where TimeOut >= '" & TmeInFrm & "' and TimeOut <='" & TmeInTo & "'")
        If rsIO.EOF = False Then
            For lup = 1 To rsIO.RecordCount
                LstEmpRec.Refresh()
                Dim viewlst As New ListViewItem
                viewlst = LstEmpRec.Items.Add(rsIO("ID").Value, lup)
                viewlst.SubItems.Add(rsIO("Plate").Value)
                viewlst.SubItems.Add(rsIO("Name").Value)
                viewlst.SubItems.Add(rsIO("TimeOut").Value)
                '  viewlst.SubItems.Add(rsIO("Status").Value)
                rsIO.MoveNext()
            Next
        End If
    End Sub

    Sub DelExtSrch()
        'On Error Resume Next
        If conServer() = False Then
            MsgBox("Please connect to server!    ", vbExclamation, "Server")
            frmDbSettings.ShowDialog()
            Exit Sub
        End If
        'LstEmpRec.Clear()

        Dim lup As Short
        Dim TmeInTo As String
        Dim TmeInFrm As String
        'Dim DateInFrm As String
        'Dim DateInTo As String

        TmeInFrm = Format(CDate(dtDateFrm.Value), "yyyy-MM-dd") + " " + Format(CDate(dtTmeFrm.Value), "HH:mm:ss tt")
        TmeInTo = Format(CDate(dtDateTo.Value), "yyyy-MM-dd") + " " + Format(CDate(dtTmeTo.Value), "HH:mm:ss tt")
        'Dim rs As New Recordset
        rsIO = New Recordset
        rsIO = Conn.Execute("Delete from tbltimeOut where TimeOut >= '" & TmeInFrm & "' and TimeOut <='" & TmeInTo & "'")
      
    End Sub

    Sub DelExtSrchAll()
        'On Error Resume Next
        If conServer() = False Then
            MsgBox("Please connect to server!    ", vbExclamation, "Server")
            frmDbSettings.ShowDialog()
            Exit Sub
        End If
        'LstEmpRec.Clear()

        Dim lup As Short
        Dim TmeInTo As String
        Dim TmeInFrm As String
        'Dim DateInFrm As String
        'Dim DateInTo As String

        TmeInFrm = Format(CDate(dtDateFrm.Value), "yyyy-MM-dd") + " " + Format(CDate(dtTmeFrm.Value), "HH:mm:ss tt")
        TmeInTo = Format(CDate(dtDateTo.Value), "yyyy-MM-dd") + " " + Format(CDate(dtTmeTo.Value), "HH:mm:ss tt")
        'Dim rs As New Recordset
        rsIO = New Recordset
        rsIO = Conn.Execute("Delete from tbltimeOut")

    End Sub

    Sub ExtSrch2()
        'On Error Resume Next
        If conServer() = False Then
            MsgBox("Please connect to server!    ", vbExclamation, "Server")
            frmDbSettings.ShowDialog()
            Exit Sub
        End If
        rsIO = New Recordset
        rsIO = Conn.Execute("select * from vwetimeout where " & SirchCateg.Text & " like '" & txtInput.Text & "%'")
        If rsIO.EOF = False Then
            For lup = 1 To rsIO.RecordCount
                LstEmpRec.Refresh()
                Dim viewlst As New ListViewItem
                viewlst = LstEmpRec.Items.Add(rsIO("ID").Value, lup)
                viewlst.SubItems.Add(rsIO("Plate").Value)
                viewlst.SubItems.Add(rsIO("Name").Value)
                viewlst.SubItems.Add(rsIO("TimeOut").Value)
                'viewlst.SubItems.Add(rsIO("Status").Value)
                rsIO.MoveNext()
            Next
        End If
    End Sub

    Sub DelExtSrch2()
        'On Error Resume Next
        If conServer() = False Then
            MsgBox("Please connect to server!    ", vbExclamation, "Server")
            frmDbSettings.ShowDialog()
            Exit Sub
        End If
        rsIO = New Recordset
        rsIO = Conn.Execute("delete from tbltimeout where " & SirchCateg.Text & " like '" & txtInput.Text & "%'")
       
    End Sub

    Sub LogsSrch()
        'On Error Resume Next
        If conServer() = False Then
            MsgBox("Please connect to server!    ", vbExclamation, "Server")
            frmDbSettings.ShowDialog()
            Exit Sub
        End If
        'LstEmpRec.Clear()

        Dim lup As Short
        Dim TmeInTo As String
        Dim TmeInFrm As String
        'Dim DateInFrm As String
        'Dim DateInTo As String

        TmeInFrm = Format(CDate(dtDateFrm.Value), "yyyy-MM-dd") + " " + Format(CDate(dtTmeFrm.Value), "HH:mm:ss tt")
        TmeInTo = Format(CDate(dtDateTo.Value), "yyyy-MM-dd") + " " + Format(CDate(dtTmeTo.Value), "HH:mm:ss tt")
        'Dim rs As New Recordset
        rsLogs = New Recordset
        rsLogs = Conn.Execute("select * from vweinout where TimeOut >= '" & TmeInFrm & "' and TimeOut <='" & TmeInTo & "'")
        If rsLogs.EOF = False Then
            For lup = 1 To rsLogs.RecordCount
                LstEmpRec.Refresh()
                Dim viewlst As New ListViewItem
                viewlst = LstEmpRec.Items.Add(rsLogs("ID").Value, lup)
                viewlst.SubItems.Add(rsLogs("Plate").Value)
                viewlst.SubItems.Add(rsLogs("Name").Value)
                viewlst.SubItems.Add(rsLogs("TimeIn").Value)
                viewlst.SubItems.Add(rsLogs("TimeOut").Value)
                'viewlst.SubItems.Add(rsLogs("Status").Value)
                'viewlst.SubItems.Add(rs("Remarks").Value)
                rsLogs.MoveNext()
            Next
        End If
    End Sub

    Sub DelLogsSrch()
        'On Error Resume Next
        If conServer() = False Then
            MsgBox("Please connect to server!    ", vbExclamation, "Server")
            frmDbSettings.ShowDialog()
            Exit Sub
        End If
        'LstEmpRec.Clear()

        Dim lup As Short
        Dim TmeInTo As String
        Dim TmeInFrm As String
        'Dim DateInFrm As String
        'Dim DateInTo As String

        TmeInFrm = Format(CDate(dtDateFrm.Value), "yyyy-MM-dd") + " " + Format(CDate(dtTmeFrm.Value), "HH:mm:ss tt")
        TmeInTo = Format(CDate(dtDateTo.Value), "yyyy-MM-dd") + " " + Format(CDate(dtTmeTo.Value), "HH:mm:ss tt")
        'Dim rs As New Recordset
        rsLogs = New Recordset
        rsLogs = Conn.Execute("delete from tblinout where TimeOut >= '" & TmeInFrm & "' and TimeOut <='" & TmeInTo & "'")
      
    End Sub

    Sub DelLogsSrchAll()
        'On Error Resume Next
        If conServer() = False Then
            MsgBox("Please connect to server!    ", vbExclamation, "Server")
            frmDbSettings.ShowDialog()
            Exit Sub
        End If
        'LstEmpRec.Clear()

        Dim lup As Short
        Dim TmeInTo As String
        Dim TmeInFrm As String
        'Dim DateInFrm As String
        'Dim DateInTo As String

        TmeInFrm = Format(CDate(dtDateFrm.Value), "yyyy-MM-dd") + " " + Format(CDate(dtTmeFrm.Value), "HH:mm:ss tt")
        TmeInTo = Format(CDate(dtDateTo.Value), "yyyy-MM-dd") + " " + Format(CDate(dtTmeTo.Value), "HH:mm:ss tt")
        'Dim rs As New Recordset
        rsLogs = New Recordset
        rsLogs = Conn.Execute("delete from tblinout")

    End Sub

    Sub LogsSrch2()
        'On Error Resume Next
        If conServer() = False Then
            MsgBox("Please connect to server!    ", vbExclamation, "Server")
            frmDbSettings.ShowDialog()
            Exit Sub
        End If
        rsLogs = New Recordset
        rsLogs = Conn.Execute("select * from vweinout where " & SirchCateg.Text & " like '" & txtInput.Text & "%'")
        If rsLogs.EOF = False Then
            For lup = 1 To rsLogs.RecordCount
                LstEmpRec.Refresh()
                Dim viewlst As New ListViewItem
                viewlst = LstEmpRec.Items.Add(rsLogs("ID").Value, lup)
                viewlst.SubItems.Add(rsLogs("Plate").Value)
                viewlst.SubItems.Add(rsLogs("Name").Value)
                viewlst.SubItems.Add(rsLogs("TimeIn").Value)
                viewlst.SubItems.Add(rsLogs("TimeOut").Value)
                'viewlst.SubItems.Add(rsLogs("Status").Value)
                'viewlst.SubItems.Add(rs("Remarks").Value)
                rsLogs.MoveNext()
            Next
        End If
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        Select Case cboCateg.Text
            Case "Time In"
                Prstprint()
            Case "Time Out"
                AttRecPrint()
            Case "Logs Report"
                LogsRep()
        End Select

        With frmSystemMain
            saveAudiUpdate(.UserAcc.Text, .SystemTag.Text, "Print preview report generation")
        End With
    End Sub

    Sub Prstprint()
        Dim ReportPath As String = Application.StartupPath & "\Reports\crTimein.rpt"
        If Not IO.File.Exists(ReportPath) Then
            MsgBox("Cannot load Report file", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        Dim Report As CrystalDecisions.CrystalReports.Engine.ReportDocument = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load(ReportPath)
        Report.SetDataSource(rsPRS)
        frmReportLogs.CRViewer.ReportSource = Report
        frmReportLogs.ShowDialog()
    End Sub

    Sub AttRecPrint()
        Dim ReportPath As String = Application.StartupPath & "\Reports\crTimeOut.rpt"
        If Not IO.File.Exists(ReportPath) Then
            MsgBox("Cannot load Report file!    ", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        Dim Report As CrystalDecisions.CrystalReports.Engine.ReportDocument = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load(ReportPath)
        Report.SetDataSource(rsIO)
        frmReportLogs.CRViewer.ReportSource = Report
        frmReportLogs.ShowDialog()
        'Else
        ' MsgBox("No Record Found", MsgBoxStyle.Exclamation)
        'End If
    End Sub

    Sub LogsRep()
        Dim ReportPath As String = Application.StartupPath & "\Reports\crTimeinOut.rpt"
        If Not IO.File.Exists(ReportPath) Then
            MsgBox("Cannot load Report file!    ", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        Dim Report As CrystalDecisions.CrystalReports.Engine.ReportDocument = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load(ReportPath)
        Report.SetDataSource(rsLogs)
        frmReportLogs.CRviewer.ReportSource = Report
        frmReportLogs.ShowDialog()
        'Else
        ' MsgBox("No Record Found", MsgBoxStyle.Exclamation)
        'End If
    End Sub

    Private Sub frmlogs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        EntHead()
        unable()
    End Sub

    Sub unable()
        cmdEdit.Enabled = False
        cmdDel.Enabled = False
        cmdPrint.Enabled = False
        Button1.Enabled = False

        dtDateFrm.Enabled = False
        dtDateTo.Enabled = False
        dtTmeFrm.Enabled = False
        dtTmeTo.Enabled = False
        txtInput.Enabled = False

        SirchCateg.Enabled = False
    End Sub

    Sub able()
        cmdEdit.Enabled = True
        cmdDel.Enabled = True
        cmdPrint.Enabled = True
        Button1.Enabled = True

    End Sub

    Sub abledt()
        dtDateFrm.Enabled = True
        dtDateTo.Enabled = True
        dtTmeFrm.Enabled = True
        dtTmeTo.Enabled = True
        Button1.Enabled = True
    End Sub

    Sub disdt()
        dtDateFrm.Enabled = False
        dtDateTo.Enabled = False
        dtTmeFrm.Enabled = False
        dtTmeTo.Enabled = False
    End Sub

    Private Sub cboCateg_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCateg.SelectedIndexChanged
        Select Case cboCateg.Text
            Case "Time In"
                LstEmpRec.Clear()
                EntHead()
                able()
                cmdDel.Enabled = False
                cmdPrint.Enabled = False
                Button1.Enabled = False
                SirchCateg.Enabled = True
                EntPic.Image = Nothing
                ExtPic.Image = Nothing
            Case "Time Out"
                LstEmpRec.Clear()
                ExtHead()
                able()
                cmdDel.Enabled = False
                cmdPrint.Enabled = False
                Button1.Enabled = False
                SirchCateg.Enabled = True
                EntPic.Image = Nothing
                ExtPic.Image = Nothing
            Case "Logs Report"
                LstEmpRec.Clear()
                AttHead()
                able()
                cmdDel.Enabled = False
                cmdPrint.Enabled = False
                Button1.Enabled = False
                SirchCateg.Enabled = True
                EntPic.Image = Nothing
                ExtPic.Image = Nothing
        End Select
    End Sub

    Private Sub SirchCateg_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SirchCateg.SelectedIndexChanged
        If SirchCateg.Text = "By Date" Then
            txtInput.Enabled = False
            abledt()
        Else
            txtInput.Enabled = True
            Button1.Enabled = True
            txtInput.Focus()
            disdt()
        End If
    End Sub

    Public Function Get_ImageIn(ByRef Acnumber As String) As Bitmap
        Try
            Dim rs As New Recordset
            rs = Conn.Execute("select PicIn from tblTimein where id = '" & Acnumber & "'")
            If rs.EOF = False Then
                Dim imgByteArray() As Byte
                Try
                    imgByteArray = CType(rs("PicIn").Value, Byte())
                    Dim stream As New System.IO.MemoryStream(imgByteArray)
                    Dim bmp As New Bitmap(stream)
                    stream.Close()
                    Return bmp
                Catch ex As Exception
                    'MessageBox.Show(ex.Message)
                    'frmLogs.EntPic.Image = Image.FromFile(Application.StartupPath & "\noimage.jpeg")
                    Return Nothing
                End Try
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function Get_PicEnt(ByRef Acnumber As String) As Bitmap
        Try
            Dim rs As New Recordset
            rs = Conn.Execute("select PicIn from tblinout where Id = '" & Acnumber & "'")
            If rs.EOF = False Then
                Dim imgByteArray() As Byte
                Try
                    imgByteArray = CType(rs("PicIn").Value, Byte())
                    Dim stream As New System.IO.MemoryStream(imgByteArray)
                    Dim bmp As New Bitmap(stream)
                    stream.Close()
                    Return bmp
                Catch ex As Exception
                    'MessageBox.Show(ex.Message)
                    'frmLogs.EntPic.Image = Image.FromFile(Application.StartupPath & "\noimage.jpeg")
                    Return Nothing
                End Try
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function Get_PicExt(ByRef Acnumber As String) As Bitmap
        Try
            Dim rs As New Recordset
            rs = Conn.Execute("select PicOut from tblinout where id = '" & Acnumber & "'")
            If rs.EOF = False Then
                Dim imgByteArray() As Byte
                Try
                    imgByteArray = CType(rs("PicOut").Value, Byte())
                    Dim stream As New System.IO.MemoryStream(imgByteArray)
                    Dim bmp As New Bitmap(stream)
                    stream.Close()
                    Return bmp
                Catch ex As Exception
                    'MessageBox.Show(ex.Message)
                    'frmLogs.ExtPic.Image = Image.FromFile(Application.StartupPath & "\noimage.jpeg")
                    Return Nothing
                End Try
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function Get_ImageOut(ByRef Acnumber As String) As Bitmap
        Try
            Dim rs As New Recordset
            rs = Conn.Execute("select PicOut from tblTimeOut where id = '" & Acnumber & "'")
            If rs.EOF = False Then
                Dim imgByteArray() As Byte
                Try
                    imgByteArray = CType(rs("PicOut").Value, Byte())
                    Dim stream As New System.IO.MemoryStream(imgByteArray)
                    Dim bmp As New Bitmap(stream)
                    stream.Close()
                    Return bmp
                Catch ex As Exception
                    ' MessageBox.Show(ex.Message)
                    'frmLogs.EntPic.Image = Image.FromFile(Application.StartupPath & "\noimage.jpeg")
                    Return Nothing
                End Try
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Sub picInOutView()
        If conServer() = False Then
            MsgBox("Please connect to server!    ", vbExclamation, "Server")
            'frmMySQLConn.ShowDialog()
            Exit Sub
        End If
        Try
            Dim rs As New Recordset
            rs = New Recordset
            rs = Conn.Execute("select PicIn,PicOut from tblinout where Id = '" & id & "'")
            If rs.EOF = False Then
                EntPic.Image = Get_PicEnt(id)
                ExtPic.Image = Get_PicExt(id)
            End If
        Catch
            EntPic.Image = Image.FromFile(Application.StartupPath & "\noimage.jpeg")
            ExtPic.Image = Image.FromFile(Application.StartupPath & "\noimage.jpeg")
        End Try
    End Sub
    Sub picEntView()
        If conServer() = False Then
            MsgBox("Please connect to server!    ", vbExclamation, "Server")
            ' frmMySQLConn.ShowDialog()
            Exit Sub
        End If
        Try
            EntPic.Image = Get_ImageIn(id)
        Catch
            EntPic.Image = Image.FromFile(Application.StartupPath & "\noimage.jpeg")
        End Try
    End Sub
    Sub picExtView()
        If conServer() = False Then
            MsgBox("Please connect to server!    ", vbExclamation, "Server")
            'frmMySQLConn.ShowDialog()
            Exit Sub
        End If
        Try
            ExtPic.Image = Get_ImageOut(id)
        Catch
            ExtPic.Image = Image.FromFile(Application.StartupPath & "\noimage.jpeg")
        End Try
    End Sub
    Sub slct()
        Dim viewlst As New ListViewItem
        For Each viewlst In LstEmpRec.Items
            If viewlst.Selected = True Then
                id = viewlst.SubItems(0).Text
            End If
        Next
    End Sub

    Private Sub LstEmpRec_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LstEmpRec.SelectedIndexChanged
        Select Case cboCateg.Text
            Case "Time In"
                slct()
                picEntView()
            Case "Time Out"
                slct()
                picExtView()
            Case "Logs Report"
                slct()
                picInOutView()
        End Select
    End Sub

    Private Sub cmdDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDel.Click
        If MsgBox("Are you sure do you want to delete this logs?", vbYesNo + vbQuestion + vbDefaultButton2, "Delete") = vbNo Then
            Exit Sub
        End If

        Select Case cboCateg.Text
            Case "Time In"
               
                If categ = "Searchdt" Then
                    DelEntSrch()
                    With frmSystemMain
                        saveAudiUpdate(.UserAcc.Text, .SystemTag.Text, "Delete Time In Logs report")
                    End With
                    LstEmpRec.Clear()
                    EntHead()
                ElseIf categ = "All" Then
                    DelEntSrchAll()
                    With frmSystemMain
                        saveAudiUpdate(.UserAcc.Text, .SystemTag.Text, "Delete Time In Logs report")
                    End With
                    LstEmpRec.Clear()
                    EntHead()
                Else
                    MsgBox("You can delete logs with (By date) category only", vbExclamation, "Delete")
                End If

            Case "Time Out"
               
                Select Case categ
                    Case "Searchdt"

                        DelExtSrch()
                        With frmSystemMain
                            saveAudiUpdate(.UserAcc.Text, .SystemTag.Text, "Delete Time Out Logs report")
                        End With
                        LstEmpRec.Clear()
                        ExtHead()
                    Case "All"
                        DelExtSrchAll()
                        With frmSystemMain
                            saveAudiUpdate(.UserAcc.Text, .SystemTag.Text, "Delete Time Out Logs report")
                        End With
                        LstEmpRec.Clear()
                        ExtHead()
                    Case Else
                        MsgBox("You can delete logs with (By date) category only", vbExclamation, "Delete")
                End Select
            Case "Logs Report"
              
                If categ = "Searchdt" Then
                    DelLogsSrch()
                    With frmSystemMain
                        saveAudiUpdate(.UserAcc.Text, .SystemTag.Text, "Delete Logs report")
                    End With
                    LstEmpRec.Clear()
                    LogsHead()
                ElseIf categ = "All" Then
                    DelLogsSrchAll()
                    With frmSystemMain
                        saveAudiUpdate(.UserAcc.Text, .SystemTag.Text, "Delete Logs report")
                    End With
                    LstEmpRec.Clear()
                    LogsHead()
                Else
                    MsgBox("You can delete logs with (By date) category only", vbExclamation, "Delete")
                End If
        End Select
    End Sub
End Class