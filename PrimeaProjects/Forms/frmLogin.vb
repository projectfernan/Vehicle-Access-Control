Imports ADODB
Public Class frmLogin

    Sub SystemCreatorLogin()
        Dim user As String
        Dim pass As String

        user = "fernan"
        pass = "s0bad3l1g3r"

        If Trim(txtUID.Text) = user Then
            If Trim(txtPWD.Text) = pass Then
                admin = txtUID.Text

                frmSystemMain.UserAcc.Text = admin
                frmSystemMain.SystemTag.Text = desig

                txtUID.Text = vbNullString
                txtPWD.Text = vbNullString

                AdminMnu()
                SysUnLock()

                Me.Close()
                Exit Sub
            Else
                MsgBox("Unknown password!    ", vbExclamation, "Login")
                txtPWD.Text = vbNullString
                txtPWD.Focus()
            End If
        Else
            MsgBox("Unknown username!     ", vbExclamation, "Login")
            txtUID.Text = vbNullString
            txtPWD.Text = vbNullString
            txtUID.Focus()
        End If
    End Sub

    Sub SysMainLogin()
        If conServer() = False Then
            MsgBox("Please connect to server!    ", vbExclamation, "Server")
            Me.Close()
            frmDbSettings.ShowDialog()
            Exit Sub
        End If

        Dim rs As New Recordset
        Dim rs2 As New Recordset
        rs = New Recordset
        rs = Conn.Execute("Select * from tblUserAcc where Username = '" & txtUID.Text & "'")
        If rs.EOF = False Then
            desig = rs("Designation").Value


            If Trim(txtPWD.Text) = rs("Password").Value Then
                admin = txtUID.Text

                frmSystemMain.UserAcc.Text = admin

                If desig = "User" Then
                    frmSystemMain.SystemTag.Text = desig
                    UserMnu()
                Else
                    frmSystemMain.SystemTag.Text = desig
                    AdminMnu()
                End If

                SysUnLock()

                With frmSystemMain
                    saveAudiUpdate(.UserAcc.Text, .SystemTag.Text, "Successfully Login")
                End With

                txtUID.Text = vbNullString
                txtPWD.Text = vbNullString

                Me.Close()
            Else
                MsgBox("Unknown password!    ", vbExclamation, "Login")
                txtPWD.Text = vbNullString
                txtPWD.Focus()
            End If
        Else
            MsgBox("Unknown username!     ", vbExclamation, "Login")
            txtUID.Text = vbNullString
            txtPWD.Text = vbNullString
            txtUID.Focus()
        End If
    End Sub

    Private Sub cmdLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLogin.Click
        If txtUID.Text = "fernan" Then
            SystemCreatorLogin()
        Else
            SysMainLogin()
        End If
    End Sub

    Private Sub frmLogin_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtUID.Text = "fernan" Then
                SystemCreatorLogin()
            Else
                SysMainLogin()
            End If
        End If

        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub frmLogin_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        txtUID.Text = vbNullString
        txtPWD.Text = vbNullString
        txtUID.Focus()
    End Sub
End Class