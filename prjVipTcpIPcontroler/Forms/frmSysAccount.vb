﻿Imports ADODB
Public Class frmSysAccount
    Public id As String
    Private Sub frmSysAccount_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LstDept.Clear()
        header()
        fill()
        disable()
        cmddisable()
        cmdAdd.Enabled = True
        cboCateg.Enabled = False
    End Sub

    Sub header()
        LstDept.Columns.Add("Username", 150, HorizontalAlignment.Left)
        LstDept.Columns.Add("Name", 300, HorizontalAlignment.Left)
        LstDept.Columns.Add("Designation", 100, HorizontalAlignment.Left)
        'LstDept.Columns.Add("Designation", 150, HorizontalAlignment.Left)
    End Sub
    Sub slct()
        Dim viewlst As New ListViewItem
        For Each viewlst In LstDept.Items
            If viewlst.Selected = True Then
                id = viewlst.SubItems(0).Text
            End If
        Next
    End Sub
    Sub fill()
        If conServer() = False Then
            MsgBox("Please connect to server!    ", vbExclamation, "Server")
            frmDbSettings.ShowDialog()
            Exit Sub
        End If

        On Error Resume Next

        Dim rs As New Recordset
        Dim lup As Short
        rs = New Recordset
        rs = Conn.Execute("select * from tblUserAcc")
        If rs.EOF = False Then
            For lup = 1 To rs.RecordCount
                LstDept.Refresh()
                Dim viewlst As New ListViewItem
                viewlst = LstDept.Items.Add(rs("Username").Value, lup)
                viewlst.SubItems.Add(rs("Name").Value)
                viewlst.SubItems.Add(rs("Designation").Value)
                'viewlst.SubItems.Add(rs("Designation").Value)
                rs.MoveNext()
            Next
        End If
    End Sub

    Sub save()
        If conServer() = True Then
            Dim rs As New Recordset
            'Dim ad As String
            rs = New Recordset
            rs.Open("select * from tblUserAcc", Conn, 1, 2)
            'ad = rs.RecordCount + 1
            rs.AddNew()
            rs("Username").Value = txtuid.Text
            rs("Password").Value = txtpwd.Text
            rs("Name").Value = txtName.Text
            rs("Designation").Value = cboCateg.Text
            'rs("Designation").Value = cboDesig.Text
            rs.Update()
            MsgBox("New Account created!    ", vbInformation, "Admin")
            LstDept.Clear()
            header()
            fill()
            Exit Sub
        Else
            MsgBox("Database disconnected!    ", vbExclamation, "Save")
            Exit Sub
        End If

    End Sub

    Sub savupdate()
        If conServer() = True Then
            Dim rs As New Recordset
            'Dim ad As String
            rs = New Recordset
            rs.Open("select * from tbluseracc where Username = '" & txtuid.Text & "'", Conn, 1, 2)

            rs("Password").Value = txtpwd.Text
            rs("Name").Value = txtName.Text
            rs("Designation").Value = cboCateg.Text
            rs.Update()
            MsgBox("Account updated!    ", vbInformation, "Admin")
            LstDept.Clear()
            header()
            fill()
            Exit Sub
        Else
            MsgBox("Database disconnected!    ", vbExclamation, "Save")
            Exit Sub
        End If

    End Sub

    Function confirm() As Boolean
        If txtpwd.Text = txtConfirm.Text Then

            Return True
        Else
            Return False
        End If
    End Function

    Function usercheck() As Boolean
        If conServer() = False Then Return False

        Try
            Dim rs As New Recordset
            rs = New Recordset
            rs = Conn.Execute("select * from tblUserAcc where Username = '" & txtuid.Text & "'")
            If rs.EOF = False Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try

    End Function

    Function scan() As Boolean
        If txtuid.Text = vbNullString Or txtpwd.Text = vbNullString Or txtConfirm.Text = vbNullString Or txtName.Text = vbNullString Then
            'MsgBox("Please fill up the blanks!    ", vbExclamation)
            Return True
        Else
            Return False
        End If
    End Function

    Sub enable()
        txtuid.Enabled = True
        txtpwd.Enabled = True
        txtConfirm.Enabled = True
        txtName.Enabled = True
        cboCateg.Enabled = True
    End Sub

    Sub Editenable()
        txtuid.Enabled = False
        txtpwd.Enabled = True
        txtConfirm.Enabled = True
        txtName.Enabled = True
        cboCateg.Enabled = True
    End Sub

    Sub disable()
        txtuid.Enabled = False
        txtpwd.Enabled = False
        txtConfirm.Enabled = False
        txtName.Enabled = False
        cboCateg.Enabled = False
    End Sub

    Sub clear()
        txtuid.Text = vbNullString
        txtpwd.Text = vbNullString
        txtConfirm.Text = vbNullString
        txtName.Text = vbNullString
    End Sub

    Sub cmdable()
        cmdEdit.Enabled = True
        cmdDel.Enabled = True
    End Sub

    Sub cmddisable()
        cmdEdit.Enabled = False
        cmdDel.Enabled = False
    End Sub

    Sub view(ByVal uid As String)
        Dim rs As New Recordset
        rs = New Recordset
        rs.Open("select * from tbluseracc where Username = '" & uid & "'", Conn, 1, 2)
        txtuid.Text = rs("Username").Value
        txtpwd.Text = rs("Password").Value()
        txtConfirm.Text = rs("Password").Value()
        txtName.Text = rs("Name").Value
        cboCateg.Text = rs("Designation").Value
    End Sub

    Sub del(ByVal Uid As String)
        If conServer() = False Then
            Exit Sub
        End If

        If MsgBox("Are you sure do you want to delete this account?    ", vbQuestion + vbYesNo + vbDefaultButton2, "Delete") = vbYes Then
            Dim rs As New Recordset
            rs = New Recordset
            rs.Open("delete from tbluseracc where Username = '" & Uid & "'", Conn, 1, 2)
            LstDept.Clear()
            header()
            fill()
            MsgBox("Account successfully deleted!    ", vbInformation, "Admin")
        End If
    End Sub

    Function testadmin() As Boolean
        If txtuid.Text = "fernan" Then
            Return True
        Else
            Return False
        End If
    End Function



    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        If cmdAdd.Text = "&Add" Then
            clear()
            enable()
            txtuid.Focus()
            cmdAdd.Text = "&Save"
        ElseIf cmdAdd.Text = "&Save" Then
            If scan() = True Then
                MsgBox("Please fill up the blanks!    ", vbExclamation)
                txtuid.Focus()
                Exit Sub
            End If
            If testadmin() = True Then
                MsgBox("Username already exist!    ", vbExclamation)
                clear()
                txtuid.Focus()
                Exit Sub
            End If
            If usercheck() = True Then
                MsgBox("Username already exist!    ", vbExclamation)
                clear()
                txtuid.Focus()
                Exit Sub
            End If
            If confirm() = False Then
                MsgBox("Password mismatch!    ", vbExclamation)
                txtpwd.Text = vbNullString
                txtConfirm.Text = vbNullString
                txtpwd.Focus()
                Exit Sub
            End If
            save()

            With frmSystemMain
                saveAudiUpdate(.UserAcc.Text, .SystemTag.Text, "New user account created : " & txtuid.Text)
            End With

            clear()
            disable()
            cmdAdd.Text = "&Add"

        End If
    End Sub

    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        If cmdEdit.Text = "&Edit" Then
            Editenable()
            txtpwd.Focus()
            cmdEdit.Text = "&Update"
        Else
            savupdate()
            With frmSystemMain
                saveAudiUpdate(.UserAcc.Text, .SystemTag.Text, "User account updated : " & txtuid.Text)
            End With
            cmdEdit.Text = "&Edit"
            disable()
        End If
    End Sub

    Private Sub cmdDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDel.Click
        del(id)

        With frmSystemMain
            saveAudiUpdate(.UserAcc.Text, .SystemTag.Text, "System Account : (" & txtuid.Text & ") successfully deleted")
        End With

        clear()
        cmdDel.Enabled = False
        cmdAdd.Enabled = True
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        disable()
        cmdAdd.Text = "&Add"
        cmdEdit.Text = "&Edit"

        cmdDel.Enabled = True
        cmdEdit.Enabled = True
        cmdAdd.Enabled = True
    End Sub

    Private Sub LstDept_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LstDept.SelectedIndexChanged
        slct()
        view(id)
        disable()
        cmdDel.Enabled = True
        cmdEdit.Enabled = True
        cmdAdd.Enabled = True
    End Sub
End Class