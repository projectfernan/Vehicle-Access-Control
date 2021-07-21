Imports ADODB
Public Class frmAddVip

    Private Sub frmAddVip_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lstCards.Clear()
        cHeader()
        fillcards(lstCards, txtParkerID.Text)

        If frmMain.SystemTag.Text = "Operator :" Then
            cmdDelete.Enabled = False
        Else
            cmdDelete.Enabled = True
        End If
    End Sub

    Sub save()
        If conServer() = False Then
            MsgBox("Please connect to server!    ", vbExclamation, "Database connection")
            frmDbSettings.ShowDialog()
            Exit Sub
        End If

        Try
            Dim rs As New Recordset
            rs = New Recordset
            rs.Open("select * from tblowner", Conn, 1, 2)
            rs.AddNew()
            rs("OwnerID").Value = txtParkerID.Text
            rs("Name").Value = txtName.Text
            rs("Position").Value = txtPosition.Text
            rs("Gender").Value = cboGender.Text
            rs("BirthDate").Value = dtBdate.Value
            rs("ContactNo").Value = txtContactNo.Text
            rs("Address").Value = txtAddress.Text
            rs.Update()

            MsgBox("New parker successfully saved! ", vbInformation, "Save")
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Save")
        End Try
    End Sub

    Sub Edit(ByVal id As String)
        If conServer() = False Then
            MsgBox("Please connect to server!    ", vbExclamation, "Database connection")
            frmDbSettings.ShowDialog()
            Exit Sub
        End If

        Try
            Dim rs As New Recordset
            rs = New Recordset
            rs.Open("select * from tblowner where OwnerID = '" & id & "'", Conn, 1, 2)
            rs("Name").Value = txtName.Text
            rs("Position").Value = txtPosition.Text
            rs("Gender").Value = cboGender.Text
            rs("BirthDate").Value = dtBdate.Value
            rs("ContactNo").Value = txtContactNo.Text
            rs("Address").Value = txtAddress.Text
            rs.Update()

            MsgBox("Parker successfully updated! ", vbInformation, "Save")
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Save")
        End Try
    End Sub

    Sub clearcard()
        With frmAddCard
            .txtCode.Text = vbNullString
            .txtPlate.Text = vbNullString
            .dtEnrolled.Value = Now
            .dtExpired.Value = Now
        End With
    End Sub

    Sub viewEdit(ByVal code As String)
        With frmAddCard
            Dim rs As New Recordset
            rs = New Recordset
            rs = Conn.Execute("select * from tblcards where CardCode = '" & code & "'")
            If rs.EOF = False Then
                .txtCode.Text = rs("CardCode").Value
                .txtPlate.Text = rs("Plateno").Value
                .dtEnrolled.Value = rs("DateEnrolled").Value
                .dtExpired.Value = rs("DateExpired").Value
            End If
        End With
    End Sub


    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        Dim a As New frmAddCard
        With a
            .Text = "New Card"
            .txtCode.Enabled = True
            .ShowDialog()
        End With
    End Sub

    Sub cHeader()
        Dim w As Integer = lstCards.Width / 4
        lstCards.Columns.Add("CardCode", w, HorizontalAlignment.Left)
        lstCards.Columns.Add("Plate No", w, HorizontalAlignment.Left)
        lstCards.Columns.Add("Date Enrolled", w, HorizontalAlignment.Left)
        lstCards.Columns.Add("Expiration Date", w, HorizontalAlignment.Left)
    End Sub

    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        Dim viewlst As New ListViewItem
        For Each viewlst In lstCards.Items
            If viewlst.Selected = True Then
                viewEdit(viewlst.SubItems(0).Text)
                With frmAddCard
                    .Text = "Update Card"
                    .txtCode.Enabled = False
                    .ShowDialog()
                End With
            End If
        Next
    End Sub

    Sub delCard(ByVal cod As String)
        If conServer() = False Then Exit Sub

        Try
            Dim rs As New Recordset
            rs = New Recordset
            rs = Conn.Execute("delete from tblcards where CardCode = '" & cod & "'")
        Catch ex As Exception

        End Try

    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        If MsgBox("Are you sure do you want to delete this card?", vbYesNo + vbQuestion + vbDefaultButton2, "Delete") = vbYes Then
            Dim viewlst As New ListViewItem
            For Each viewlst In lstCards.Items
                If viewlst.Selected = True Then
                    delCard(viewlst.SubItems(0).Text)
                    lstCards.Clear()
                    cHeader()
                    fillcards(lstCards, txtParkerID.Text)
                End If
            Next
        End If
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If Me.Text = "New VIP" Then
            If MsgBox("Are you sure your entries are correct?    ", vbQuestion + vbYesNo, "Save") = vbYes Then
                save()
            End If
        Else
            If MsgBox("Are you sure do you want save changes?    ", vbQuestion + vbYesNo, "Save") = vbYes Then
                Edit(txtParkerID.Text)
            End If
        End If
    End Sub

    Private Sub cboGender_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboGender.KeyPress
        If Asc(e.KeyChar) > 0 Then
            e.KeyChar = vbNullString
        End If
    End Sub

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub cboGender_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboGender.SelectedIndexChanged

    End Sub
End Class