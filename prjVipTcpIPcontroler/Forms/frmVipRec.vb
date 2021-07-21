Imports ADODB
Public Class frmVipRec

    Private Sub frmVipRec_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lstList.Clear()
        PHeader()
        'fill()

        lstCards.Clear()
        cHeader()

        If frmMain.SystemTag.Text = "Operator :" Then
            cmdDel.Enabled = False
        Else
            cmdDel.Enabled = True
        End If
    End Sub

    Sub PHeader()
        Dim w As Integer = lstList.Width / 7
        lstList.Columns.Add("OwnerID", 100, HorizontalAlignment.Left)
        lstList.Columns.Add("Name", 200, HorizontalAlignment.Left)
        lstList.Columns.Add("PlateNo", 200, HorizontalAlignment.Left)
        lstList.Columns.Add("Position", 150, HorizontalAlignment.Left)
        lstList.Columns.Add("Gender", 100, HorizontalAlignment.Left)
        lstList.Columns.Add("BirthDate", 150, HorizontalAlignment.Left)
        lstList.Columns.Add("ContactNo", 150, HorizontalAlignment.Left)
        lstList.Columns.Add("Address", 150, HorizontalAlignment.Left)
    End Sub

    Sub fill()
        If conServer() = False Then
            MsgBox("Please connect to server!   ", vbExclamation, "Server")
            Exit Sub
        End If

        On Error Resume Next
        Dim rs As New Recordset
        Dim lup As Short
        rs = New Recordset
        rs = Conn.Execute("select * from vwefullinfo")
        If rs.EOF = False Then
            txtCount.Text = rs.RecordCount
            For lup = 1 To rs.RecordCount
                lstList.Refresh()
                Dim viewlst As New ListViewItem
                viewlst = lstList.Items.Add(rs("OwnerID").Value, lup)
                viewlst.SubItems.Add(rs("Name").Value)
                viewlst.SubItems.Add(rs("PlateNo").Value)
                viewlst.SubItems.Add(rs("Position").Value)
                viewlst.SubItems.Add(rs("Gender").Value)
                viewlst.SubItems.Add(rs("BirthDate").Value)
                viewlst.SubItems.Add(rs("ContactNo").Value)
                viewlst.SubItems.Add(rs("Address").Value)
                rs.MoveNext()
            Next
        Else
            txtCount.Text = 0
        End If
    End Sub

    Sub Findfill()
        If conServer() = False Then
            MsgBox("Please connect to server!    ", vbExclamation, "Server")
            Exit Sub
        End If

        On Error Resume Next
        Dim rs As New Recordset
        Dim lup As Short
        rs = New Recordset
        rs = Conn.Execute("select * from vwefullinfo where " & cboCateg.Text & " like '%" & txtInput.Text & "%'")
        If rs.EOF = False Then
            txtCount.Text = rs.RecordCount
            For lup = 1 To rs.RecordCount
                lstList.Refresh()
                Dim viewlst As New ListViewItem
                viewlst = lstList.Items.Add(rs("OwnerID").Value, lup)
                viewlst.SubItems.Add(rs("Name").Value)
                viewlst.SubItems.Add(rs("PlateNo").Value)
                viewlst.SubItems.Add(rs("Position").Value)
                viewlst.SubItems.Add(rs("Gender").Value)
                viewlst.SubItems.Add(rs("BirthDate").Value)
                viewlst.SubItems.Add(rs("ContactNo").Value)
                viewlst.SubItems.Add(rs("Address").Value)
                rs.MoveNext()
            Next
        Else
            txtCount.Text = 0
        End If
    End Sub

    Sub cHeader()
        Dim w As Integer = lstCards.Width / 4
        lstCards.Columns.Add("CardCode", w, HorizontalAlignment.Left)
        lstCards.Columns.Add("Plate No", w, HorizontalAlignment.Left)
        lstCards.Columns.Add("Date Enrolled", w, HorizontalAlignment.Left)
        lstCards.Columns.Add("Expiration Date", w, HorizontalAlignment.Left)
    End Sub

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        'Dim a As New frmAddVip
        With frmAddVip
            .Text = "New VIP"
            .txtParkerID.Text = parkerID()
            .txtName.Text = vbNullString
            .txtPosition.Text = vbNullString
            .cboGender.Text = vbNullString
            .dtBdate.Value = Now
            .txtContactNo.Text = vbNullString
            .txtAddress.Text = vbNullString
            .ShowDialog()
        End With
    End Sub

    Private Sub lstList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstList.SelectedIndexChanged
        Dim viewlst As New ListViewItem
        For Each viewlst In lstList.Items
            If viewlst.Selected = True Then
                lstCards.Clear()
                cHeader()
                fillcards(lstCards, viewlst.SubItems(0).Text)
            End If
        Next
    End Sub

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click
        lstList.Clear()
        PHeader()
        fill()

        lstCards.Clear()
        cHeader()
    End Sub

    Private Sub cmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFind.Click
        lstList.Clear()
        PHeader()
        Findfill()

        lstCards.Clear()
        cHeader()
    End Sub

    Private Sub cboCateg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboCateg.KeyPress
        If Asc(e.KeyChar) > 0 Then
            e.KeyChar = vbNullString
        End If
    End Sub

    Private Sub txtInput_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtInput.Click

    End Sub

    Private Sub txtInput_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtInput.KeyDown
        If e.KeyCode = Keys.Enter Then
            lstList.Clear()
            PHeader()
            Findfill()

            lstCards.Clear()
            cHeader()
        End If
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

    Sub editView()
        With frmAddVip
            Dim viewlst As New ListViewItem
            For Each viewlst In lstList.Items
                If viewlst.Selected = True Then
                    .txtParkerID.Text = viewlst.SubItems(0).Text
                    .txtName.Text = viewlst.SubItems(1).Text
                    .txtPosition.Text = viewlst.SubItems(3).Text
                    .cboGender.Text = viewlst.SubItems(4).Text
                    .dtBdate.Value = viewlst.SubItems(5).Text
                    .txtContactNo.Text = viewlst.SubItems(6).Text
                    .txtAddress.Text = viewlst.SubItems(7).Text
                End If
            Next
        End With
    End Sub

    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click

        Dim viewlst As New ListViewItem
        For Each viewlst In lstList.Items
            If viewlst.Selected = True Then
                frmAddVip.Text = "Update Parker"
                editView()
                frmAddVip.ShowDialog()
            End If
        Next
    End Sub


    Sub del(ByVal id As String)
        If conServer() = False Then Exit Sub

        Dim rs As New Recordset
        rs = New Recordset

        rs = Conn.Execute("delete from tblowner where OwnerID = '" & id & "'")

        MsgBox("Record successfully deleted! ", vbInformation, "Delete")
    End Sub

    Sub delcard(ByVal id As String)
        If conServer() = False Then Exit Sub

        Dim rs As New Recordset
        rs = New Recordset

        rs = Conn.Execute("delete from tblcards where OwnerID = '" & id & "'")

    End Sub

    Private Sub cmdDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDel.Click
        Dim viewlst As New ListViewItem
        For Each viewlst In lstList.Items
            If viewlst.Selected = True Then
                If MsgBox("Are you sure do you want to delete this record? ", vbQuestion + vbYesNo + vbDefaultButton2, "Delete") = vbYes Then
                    del(viewlst.SubItems(0).Text)
                    delcard(viewlst.SubItems(0).Text)
                    lstList.Clear()
                    PHeader()
                    fill()

                    lstCards.Clear()
                    cHeader()
                End If
            End If
        Next
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        frmEasyEnroll.ShowDialog()
    End Sub
End Class