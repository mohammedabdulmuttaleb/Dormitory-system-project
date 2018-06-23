Imports System.Data.SqlClient

Public Class Form2
    Public conn As New SqlConnection
    Public cmd As New SqlCommand
    Public str As String
    Public da As New SqlDataAdapter
    Public dr As SqlDataReader
    Public ds As New DataSet
    Public u As String

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form1.Visible = True
        Me.Close()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        If Len(TextBox1.Text) <> 4 Then
            TextBox1.ForeColor = Color.Red
            TextBox1.Text = "Please must be four digit"
        Else
            TextBox1.Text = TextBox1.Text
        End If
        If TextBox8.Text = "A" Or TextBox8.Text = "B" Or TextBox8.Text = "C" Then
            TextBox8.Text = TextBox8.Text

        Else
            TextBox8.ForeColor = Color.Red
            TextBox8.Text = "Please enter A or B or C"

        End If
        If TextBox2.Text = "" Then
            TextBox2.Text = "Enter the Firstname"
            TextBox2.ForeColor = Color.Red
        End If
        If TextBox3.Text = "" Then
            TextBox3.Text = "Enter the middlename"
            TextBox3.ForeColor = Color.Red
        End If
        If TextBox4.Text = "" Then
            TextBox4.Text = "Enter the lastname"
            TextBox4.ForeColor = Color.Red
        End If
        If ComboBox1.Text = "" Then
            ComboBox1.Text = "Select the city"
            ComboBox1.ForeColor = Color.Red
        End If
        If towntxt.Text = "" Then
            towntxt.Text = "Enter the Town"
            towntxt.ForeColor = Color.Red
        End If
        If TextBox6.Text = "" Then
            TextBox6.Text = "Enter the Phone"
            TextBox6.ForeColor = Color.Red
        End If
        If TextBox7.Text = "" Then
            TextBox7.Text = "Enter the Email"
            TextBox7.ForeColor = Color.Red
        End If
        If TextBox9.Text = "" Then
            TextBox9.Text = "Room number must be between 1-270"
            TextBox9.ForeColor = Color.Red
        Else

            str = "Insert into dorminfo(Student_ID,First_Name,Middle_Name,Last_Name,City,Town,Phone,Email,Block,Room_Number) values(@field1,@field2,@field3,@field4,@field5,@field6,@field7,@field8,@field9,@field10)"
            cmd = New SqlClient.SqlCommand(str, conn)
            With cmd
                .Parameters.AddWithValue("@field1", TextBox1.Text)
                .Parameters.AddWithValue("@field2", TextBox2.Text)
                .Parameters.AddWithValue("@field3", TextBox3.Text)
                .Parameters.AddWithValue("@field4", TextBox4.Text)
                .Parameters.AddWithValue("@field5", ComboBox1.Text)
                .Parameters.AddWithValue("@field6", towntxt.Text)
                .Parameters.AddWithValue("@field7", TextBox6.Text)
                .Parameters.AddWithValue("@field8", TextBox7.Text)
                .Parameters.AddWithValue("@field9", TextBox8.Text)
                .Parameters.AddWithValue("@field10", TextBox9.Text)
            End With
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            conn.Close()
            MsgBox("Adition Success",, "congratuation")

            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
            TextBox4.Text = ""
            ComboBox1.Text = ""
            towntxt.Text = ""
            TextBox6.Text = ""
            TextBox7.Text = ""
            TextBox8.Text = ""
            TextBox9.Text = ""
            ListView1.Items.Clear()

            conn.ConnectionString = "server=.\MSSQLSERVER02;database=dorm;trusted_connection=yes"
            Try
                conn.Open()

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            Try
                str = "select* from dorminfo"
                cmd = New SqlClient.SqlCommand(str, conn)
                dr = cmd.ExecuteReader
                While (dr.Read())
                    With ListView1.Items.Add(dr("Student_ID"))
                        .SubItems.Add(dr("First_Name"))
                        .SubItems.Add(dr("Middle_Name"))
                        .SubItems.Add(dr("Last_Name"))
                        .SubItems.Add(dr("City"))
                        .SubItems.Add(dr("Town"))
                        .SubItems.Add(dr("Phone"))
                        .SubItems.Add(dr("Email"))
                        .SubItems.Add(dr("Block"))
                        .SubItems.Add(dr("Room_Number"))
                    End With
                End While
                cmd.Dispose()
                dr.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If

        ListView1.Sort()
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        ComboBox1.Text = ""
        towntxt.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
        TextBox9.Text = ""
    End Sub

    Private Sub Form2_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        conn.ConnectionString = "server=.\MSSQLSERVER02;database=dorm;trusted_connection=yes"
        Try
            conn.Open()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Try
            str = "select* from dorminfo"
            cmd = New SqlClient.SqlCommand(str, conn)
            dr = cmd.ExecuteReader
            While (dr.Read())
                With ListView1.Items.Add(dr("Student_ID"))
                    .SubItems.Add(dr("First_Name"))
                    .SubItems.Add(dr("Middle_Name"))
                    .SubItems.Add(dr("Last_Name"))
                    .SubItems.Add(dr("City"))
                    .SubItems.Add(dr("Town"))
                    .SubItems.Add(dr("Phone"))
                    .SubItems.Add(dr("Email"))
                    .SubItems.Add(dr("Block"))
                    .SubItems.Add(dr("Room_Number"))
                End With
            End While
            cmd.Dispose()
            dr.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub TextBox1_Click(sender As Object, e As EventArgs) Handles TextBox1.Click
        TextBox1.Text = ""
        TextBox1.ForeColor = Color.Black
    End Sub


    Private Sub TextBox2_Click(sender As Object, e As EventArgs) Handles TextBox2.Click
        TextBox2.Text = ""
        TextBox2.ForeColor = Color.Black
    End Sub
    Private Sub TextBox3_Click(sender As Object, e As EventArgs) Handles TextBox3.Click
        TextBox3.Text = ""
        TextBox3.ForeColor = Color.Black
    End Sub
    Private Sub TextBox4_Click(sender As Object, e As EventArgs) Handles TextBox4.Click
        TextBox4.Text = ""
        TextBox4.ForeColor = Color.Black
    End Sub
    Private Sub TextBox6_Click(sender As Object, e As EventArgs) Handles TextBox6.Click
        TextBox6.Text = ""
        TextBox6.ForeColor = Color.Black
    End Sub
    Private Sub TextBox7_Click(sender As Object, e As EventArgs) Handles TextBox7.Click
        TextBox7.Text = ""
        TextBox7.ForeColor = Color.Black
    End Sub



    Private Sub TextBox8_Click(sender As Object, e As EventArgs) Handles TextBox8.Click
        TextBox8.Text = ""
        TextBox8.ForeColor = Color.Black


    End Sub
    Private Sub TextBox9_Click(sender As Object, e As EventArgs) Handles TextBox9.Click
        TextBox9.Text = ""
        TextBox9.ForeColor = Color.Black
    End Sub
    Private Sub ComboBox1_Click(sender As Object, e As EventArgs) Handles ComboBox1.Click
        ComboBox1.Text = ""
        ComboBox1.ForeColor = Color.Black
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub towntxt_Click(sender As Object, e As EventArgs) Handles towntxt.Click
        towntxt.Text = ""
        towntxt.ForeColor = Color.Black
    End Sub


End Class
