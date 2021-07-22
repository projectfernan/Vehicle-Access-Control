Imports ADODB
Public Class frmAudit
    Sub PrintSearch()
        If conServer() = False Then
            MsgBox("Please connect to local connection!    ", vbExclamation, "Server")
            frmDbSettings.ShowDialog()
            Exit Sub
        End If

        Dim TmeInTo As String
        Dim TmeInFrm As String

        TmeInFrm = Format(CDate(dtDateFrm.Value), "yyyy-MM-dd HH:mm:ss")
        TmeInTo = Format(CDate(dtDateTo.Value), "yyyy-MM-dd HH:mm:ss")

        Dim rs As Recordset
        rs = New Recordset
        rs = Conn.Execute("select * from tblauditlogs where " & cboSCateg.Text & " like '" & txtKeyword.Text & "%' and DateModified >= '" & TmeInFrm & "' and DateModified <='" & TmeInTo & "'")

        If rs.EOF = False Then
            Dim ReportPath As String = Application.StartupPath & "\Reports\crAudit.rpt"
            If Not IO.File.Exists(ReportPath) Then
                MsgBox("Cannot load Report file", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            Dim Report As CrystalDecisions.CrystalReports.Engine.ReportDocument = New CrystalDecisions.CrystalReports.Engine.ReportDocument
            Report.Load(ReportPath)
            Report.SetDataSource(rs)
            frmReportLogs.CRviewer.ReportSource = Report
            frmReportLogs.ShowDialog()
        Else
            MsgBox("No record found! ", vbExclamation, "Print")
        End If

    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        PrintSearch()
    End Sub

    Private Sub cboSCateg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboSCateg.KeyPress
        If Asc(e.KeyChar) > 1 Then
            e.KeyChar = vbNullString
        End If
    End Sub

End Class