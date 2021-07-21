Imports ADODB
Public Class frmAccount

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        lstList.Clear()
        header()

        If conServer() = True Then
            fillL()
        Else
            MsgBox("Please connect to database!    ", vbExclamation, "Database Connection")
            'frmConnDB.ShowDialog()
        End If

        cmdEdit.Enabled = False
        cmdDel.Enabled = False
    End Sub

    Sub header()
        Dim w As Integer = lstList.Width / 3
        lstList.Columns.Add("Username", w, HorizontalAlignment.Left)
        lstList.Columns.Add("Name", w, HorizontalAlignment.Left)
        lstList.Columns.Add("Designation", w, HorizontalAlignment.Left)
    End Sub

    Sub fillL()
        On Error Resume Next
        Dim rs As New Recordset
        Dim lup As Short
        rs = New Recordset
        rs = Conn.Execute("select * from tblUseracc")
        txtcnt.Text = rs.RecordCount
        If rs.EOF = False Then
            For lup = 1 To rs.RecordCount
                lstList.Refresh()
                Dim viewlst As New ListViewItem
                viewlst = lstList.Items.Add(rs("Username").Value, lup)
                viewlst.SubItems.Add(rs("Name").Value)
                viewlst.SubItems.Add(rs("Designation").Value)
                rs.MoveNext()
            Next
        End If
    End Sub

    Sub clr()
        With frmAddAcc
            .txtUser.Text = vbNullString
            .txtPass.Text = vbNullString
            .txtConfirm.Text = vbNullString
            .txtName.Text = vbNullString
            .cboDesig.Text = vbNullString
        End With
    End Sub

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click

    End Sub
End Class