Imports System.Data.SqlClient

Public Class View
    Public conn As New SqlConnection
    Public cmd As New SqlCommand
    Public str As String
    Public da As New SqlDataAdapter
    Public dr As SqlDataReader
    Public ds As New DataSet
    Public u As String

    Private lastcol As Integer
    Private lastsort As String

    Private Sub sortlistview(ByRef lv As ListView, index As Integer)
        Dim temptable As New DataTable()
        Dim sorttype As String = String.Empty
        For Each icol As ColumnHeader In lv.Columns
            temptable.Columns.Add(icol.Text)
        Next
        For Each item As ListViewItem In lv.Items
            Dim irow As DataRow = temptable.NewRow()
            Dim i As Integer = 0
            While i < lv.Columns.Count
                If i = 0 Then
                    irow(i) = item.Text
                Else
                    irow(i) = item.SubItems(i).Text
                End If
                System.Math.Max(System.Threading.Interlocked.Increment(i), i - 1)
            End While
            temptable.Rows.Add(irow)
        Next
        If lastcol = index Then
            If lastsort = "ASC" OrElse lastsort = String.Empty OrElse lastsort = Nothing Then
                sorttype = "DESC"
                lastsort = "DESC"
            Else
                sorttype = "ASC"
                lastsort = "ASC"
            End If
        Else
            sorttype = "DESC"
            lastsort = "DESC"
        End If
        lastcol = index
        lv.Items.Clear()
        temptable.DefaultView.Sort = lv.Columns(index).Text + " " + sorttype
        temptable = temptable.DefaultView.ToTable

        For Each irow As DataTable In temptable.Rows
            Dim item As New ListViewItem()
            Dim subitems As New List(Of String)()
            Dim i As Integer = 0
            While i < temptable.Columns.Count
                If i = 0 Then
                    item.Text = irow(i).ToString
                Else
                    subitems.Add(irow(i).ToString())
                End If
                System.Math.Max(System.Threading.Interlocked.Increment(1), i - 1)
            End While
            item.SubItems.AddRange(subitems.ToArray())
            lv.Items.Add(item)
        Next
    End Sub

    Private Sub View_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click



    End Sub



    Private Sub ListView1_Click(sender As Object, e As EventArgs)
        ListView1.Sorting = True
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        SaveFileDialog1.ShowDialog()
        Dim path As String = SaveFileDialog1.FileName
        Dim allitem As String = ""
        Try

            For itm = 0 To ListView1.Items.Count - 1
                allitem = allitem & ListView1.Items.Item(itm).Text & vbNewLine
            Next
            allitem = allitem.Trim
        Catch ex As Exception

        End Try
        Try
            If My.Computer.FileSystem.FileExists(path) Then
                My.Computer.FileSystem.DeleteFile(path)
            End If
            My.Computer.FileSystem.WriteAllText(path, allitem, False)
        Catch ex As Exception
            MsgBox("Error" & vbNewLine & ex.Message, MsgBoxStyle.Exclamation, "error")
        End Try
    End Sub

    Private Sub ListView1_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles ListView1.ColumnClick
        sortlistview(ListView1, 0)
    End Sub
End Class