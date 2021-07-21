Imports ADODB
Module Sys_Security
    Public desig As String
    Public admin As String

    Sub SysLock()
        With frmSystemMain
            .SysToolBar.Enabled = False
            .PanelDev.Enabled = False
        End With
    End Sub

    Sub SysUnLock()
        With frmSystemMain
            .SysToolBar.Enabled = True
            .PanelDev.Enabled = True
        End With
    End Sub

    Sub AdminMnu()
        With frmSystemMain
            .mnuSeverCon.Enabled = True
            .mnuSysAcc.Enabled = True
            .mnuController.Enabled = True
            .mnuAntiPsb.Enabled = True
            .mnuParkerRec.Enabled = True
            .mnuLogs.Enabled = True
            .mnuTerminate.Enabled = True
            .mnuAuditLogs.Enabled = True
        End With
    End Sub

    Sub UserMnu()
        With frmSystemMain
            .mnuSeverCon.Enabled = False
            .mnuSysAcc.Enabled = False
            .mnuController.Enabled = False
            .mnuAntiPsb.Enabled = True
            .mnuParkerRec.Enabled = True
            .mnuLogs.Enabled = True
            .mnuTerminate.Enabled = False
            .mnuAuditLogs.Enabled = False
        End With
    End Sub

    Public Sub saveAudiUpdate(ByVal sysUser As String, ByVal SysPosi As String, ByVal modi As String)

        Dim dtngaun As String = Format(Now, "yyyy-MM-dd HH:mm:ss")

        Try
            Dim rs As New Recordset
            rs = New Recordset
            rs = Conn.Execute("insert into tblauditlogs(Username,Designation,DateModified,Actions)values('" & sysUser & "','" & SysPosi & "','" & dtngaun & "','" & modi & "')")
        Catch ex As Exception
            'frmMain.txtSystemErr.Text = ex.Message
        End Try
    End Sub
End Module
