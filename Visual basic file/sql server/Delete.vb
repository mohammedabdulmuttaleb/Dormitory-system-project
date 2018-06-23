
Imports System.Data.SqlClient

Public Class Delete
    Public conn As New SqlConnection
    Public cmd As New SqlCommand
    Public str As String
    Public da As New SqlDataAdapter
    Public dr As SqlDataReader
    Public ds As New DataSet
    Public u As String
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Then
            MsgBox("Please Enter the ID to Delete")
        Else


            If MsgBox("are you sure to delete a Account?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                ds = New DataSet
                da = New SqlDataAdapter("Delete from dorminfo where Student_ID='" & TextBox1.Text & "'", conn)
                da.Fill(ds, "dorminfo")
                conn.Close()
                MsgBox("Delete Record success")
            End If
        End If
        TextBox1.Text = ""
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
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form1.Visible = True
        Me.Close()

    End Sub

    Private Sub Delete_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Button1.Enabled = True
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub
End Class