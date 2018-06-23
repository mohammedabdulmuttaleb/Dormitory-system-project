Public Class Login
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox1.Text = "admin" Or TextBox1.Text = "mariwan" Or TextBox1.Text = "soran" Or TextBox1.Text = "binyamin" Or TextBox1.Text = "dlovan" And TextBox2.Text = "12345" Then
            Me.Hide()
            Form1.Show()
        Else
            MsgBox("Incorrect Password or Username", 16, "Warning")
        End If

    End Sub

    Private Sub TextBox1_Click(sender As Object, e As EventArgs) Handles TextBox1.Click
        TextBox1.Text = ""
        TextBox1.ForeColor = Color.Black
    End Sub

    Private Sub TextBox2_Click(sender As Object, e As EventArgs) Handles TextBox2.Click
        TextBox2.Text = ""
        TextBox2.ForeColor = Color.Black
        TextBox2.PasswordChar = "*"
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        TextBox1.ForeColor = Color.Black
    End Sub

End Class