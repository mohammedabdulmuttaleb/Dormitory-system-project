Imports System.Data.SqlClient

Public Class Form1
    Public conn As New SqlConnection
    Public cmd As New SqlCommand
    Public str As String
    Public da As New SqlDataAdapter
    Public dr As SqlDataReader
    Public ds As New DataSet
    Public u As String

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form2.Visible = True
        Me.Hide()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Search.Visible = True
        Me.Hide()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Delete.Visible = True
        Me.Hide()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        View.Visible = True
        Me.Hide()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn.ConnectionString = "server=.\MSSQLSERVER02;database=mohammed;trusted_connection=yes"
        Try
            conn.Open()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
        Login.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Emergency.Visible = True
        Me.Hide()
    End Sub
End Class
