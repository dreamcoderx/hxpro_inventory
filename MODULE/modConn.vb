Imports System.Data

Module modConn
    Public connDB As New SqlClient.SqlConnection
    Public comDB As New SqlClient.SqlCommand
    Public rdDB As SqlClient.SqlDataReader
    Public Item As ListViewItem
    Public SQL As String

    Private Function ConStr() As String
        ''Return String.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3}", _
        '                        My.Settings.host, _
        '                        My.Settings.initial_catalog, _
        '                        My.Settings.user_id,
        '                        My.Settings.password)
        Dim FILE_NAME As String = Path & "\ConStr.txt"
        Dim TextLine As String = ""

        If System.IO.File.Exists(FILE_NAME) = True Then
            Dim objReader As New System.IO.StreamReader(FILE_NAME)
            Do While objReader.Peek() <> -1
                TextLine = TextLine & objReader.ReadLine() '& vbNewLine
            Loop
            Return TextLine
        Else
            MsgBox("File Does Not Exist")
            Return TextLine
        End If
    End Function

    Public Sub conecDB()
            If connDB.State <> ConnectionState.Open Then
            connDB.ConnectionString = ConStr()
            connDB.Open()
        End If
    End Sub

    Public Function conecDB_OK() As Boolean
        Try
            Cursor.Current = Cursors.WaitCursor
            If connDB.State <> ConnectionState.Open Then
                connDB.ConnectionString = ConStr()
                connDB.Open()
            End If
            If connDB.State = ConnectionState.Open Then
                Return True
            End If
            MessageBox.Show("CONNECTION FAILED!")
            Return False
        Catch sql_ex As SqlClient.SqlException
            MessageBox.Show(sql_ex.Message)
            Return False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Function

    'Close the connection from database
    Public Sub closeDB()
        If connDB.State <> ConnectionState.Closed Then connDB.Close()
    End Sub

    'Initialize the sql command object
    Public Sub initCMD()
        With comDB
            .Connection = connDB
            .CommandType = CommandType.Text
            .CommandTimeout = 0
        End With
    End Sub

    Public Sub colorLV(ByVal Plv As ListView, ByVal PintIx As Integer, ByVal Pcolo As System.Drawing.Color, Optional ByVal PintFlgRefresh As Integer = 0)
        Plv.Items(PintIx).ForeColor = Pcolo
        'Refresh if flag is 1
        If PintFlgRefresh = 1 Then
            Plv.Refresh()
        End If
    End Sub

    'Public Sub dispStatLB(ByVal PstatLbl As System.Windows.Forms.ToolStripStatusLabel, ByVal PstrMsg As String)
    '    PstatLbl.Text = PstrMsg
    'End Sub

    Public Sub execComDB(ByVal PstrSQL As String)
        Try
            With comDB
                .CommandText = PstrSQL
                .ExecuteNonQuery()
            End With
        Catch sql_ex As SqlClient.SqlException
            MessageBox.Show(sql_ex.Message)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

End Module
