Imports ADODB
Public Class frmAntiPassback

    Private Sub frmAntiPassback_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ViewPassback()
    End Sub

    Sub savePassback()
        If Connect_Loc() = False Then Exit Sub

        Try
            Dim rs As New recordset
            rs = New Recordset
            rs.Open("select * from tblpassback", ConnLoc, 1, 2)
            If rs.EOF = False Then
                If OptDisable.Checked = True Then
                    rs("Passback").Value = 0
                ElseIf OptEnable.Checked = True Then
                    rs("Passback").Value = 1
                End If
                rs.Update()
            Else
                rs.AddNew()
                If OptDisable.Checked = True Then
                    rs("Passback").Value = 0
                ElseIf OptEnable.Checked = True Then
                    rs("Passback").Value = 1
                End If
                rs.Update()
            End If
            MsgBox("Anti Passback settings successfully saved!", vbInformation, "Save")
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Save")
        End Try
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        savePassback()
    End Sub
End Class