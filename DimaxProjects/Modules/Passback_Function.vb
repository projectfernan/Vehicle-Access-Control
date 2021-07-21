Imports ADODB
Module Passback_Function
    Public Sub ViewPassback()
        If Connect_Loc() = False Then
            frmAntiPassback.OptDisable.Checked = True
            frmAntiPassback.OptEnable.Checked = False
            Exit Sub
        End If

        Try
            Dim rs As New Recordset
            rs = ConnLoc.Execute("select * from tblpassback")
            If rs.EOF = False Then
                If rs("Passback").Value = 0 Then
                    frmAntiPassback.OptDisable.Checked = True
                    frmAntiPassback.OptEnable.Checked = False
                Else
                    frmAntiPassback.OptDisable.Checked = False
                    frmAntiPassback.OptEnable.Checked = True
                End If
            Else
                frmAntiPassback.OptDisable.Checked = True
                frmAntiPassback.OptEnable.Checked = False
            End If
        Catch ex As Exception
            frmAntiPassback.OptDisable.Checked = True
            frmAntiPassback.OptEnable.Checked = False
        End Try
    End Sub

    Public Function PassbackStat() As Boolean
        If Connect_Loc() = False Then Return False

        Try
            Dim rs As New Recordset
            rs = New Recordset
            rs = ConnLoc.Execute("select * from tblpassback")
            If rs.EOF = False Then
                If rs("Passback").Value = 0 Then
                    Return False
                Else
                    Return True
                End If
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
End Module
