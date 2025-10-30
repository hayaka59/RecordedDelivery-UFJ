Option Explicit On
Option Strict On

Imports System.IO

Module commonModule

    ''' <summary>
    ''' フォルダの末尾の「\」を保証する
    ''' </summary>
    ''' <param name="strCheckFolder">チェック対象のフォルダ名称</param>
    ''' <returns>チェック後のフォルダ名称</returns>
    ''' <remarks></remarks>
    Public Function IncludeTrailingPathDelimiter(ByVal strCheckFolder As String) As String

        Try

            If strCheckFolder.Substring(strCheckFolder.Length - 1, 1) = "\"c Then
                IncludeTrailingPathDelimiter = strCheckFolder
            Else
                IncludeTrailingPathDelimiter = strCheckFolder & "\"
            End If

        Catch ex As Exception
            MsgBox("【IncludeTrailingPathDelimiter】" & ex.Message)
            Return ""
        End Try

    End Function


    ''' <summary>
    ''' 実績ログデータの書き込み処理
    ''' </summary>
    ''' <param name="strResultsData"></param>
    ''' <remarks></remarks>
    Public Sub OutPutResultsLogData(ByVal strResultsData As String)

        Dim strPutMessage As String

        Try
            Dim dtNow As DateTime = DateTime.Now

            ' 指定した書式で日付を文字列に変換する
            Dim strNowFormat As String = dtNow.ToString("yyyy/MM/dd HH:mm:ss")

            ' 実績ログファイルに操作ログ内容を書き込む
            strPutMessage = strNowFormat & "：" & strResultsData
            ' 追記モードで書き込む
            Using sw As New System.IO.StreamWriter(PubConstClass.pblDriveLogFileName, True, System.Text.Encoding.Default)
                sw.WriteLine(strPutMessage)
            End Using

        Catch ex As Exception
            MsgBox("【OutPutResultsLogData】" & ex.Message)
        End Try

    End Sub


    ''' <summary>
    ''' 通信ログデータの書き込み処理
    ''' </summary>
    ''' <param name="strOutSerialData"></param>
    ''' <remarks></remarks>
    Public Sub OutPutSerialLogFile(ByVal strOutSerialData As String)

        Dim strOutPutFolder As String
        Dim strOutPutFileName As String
        Dim strYYYYMMDDvalue As String
        Dim strHHMMSSvalue As String
        Dim strPutMessage As String

        SyncLock (PubConstClass.objSyncSeri)

            Try
                Dim dtNow As DateTime = DateTime.Now

                ' 指定した書式で日付を文字列に変換する
                Dim strNowFormat As String = dtNow.ToString("yyyy/MM/dd HH:mm:ss")

                With Now
                    strYYYYMMDDvalue = String.Format("{0:D4}{1:D2}{2:D2}", .Year, .Month, .Day)
                    strHHMMSSvalue = String.Format("{0:D2}{1:D2}{2:D2}", .Hour, .Minute, .Second)
                End With

                ' 格納フォルダ名の設定
                strOutPutFolder = IncludeTrailingPathDelimiter(Application.StartupPath) & "OPHISTORYLOG\"
                ' 格納ファイル名の設定
                strOutPutFileName = "通信ログ_" & strYYYYMMDDvalue & ".LOG"

                If System.IO.Directory.Exists(strOutPutFolder) = False Then
                    ' フォルダの作成
                    System.IO.Directory.CreateDirectory(strOutPutFolder)
                    strPutMessage = strNowFormat & "【" & strOutPutFolder & "】フォルダを作成しました。"
                    ' 追記モードで書き込む
                    Using sw As New System.IO.StreamWriter(strOutPutFolder & strOutPutFileName, True, System.Text.Encoding.Default)
                        sw.WriteLine(strPutMessage)
                    End Using
                End If

                ' 通信ログに送受信内容を書き込む
                strPutMessage = strNowFormat & "：" & strOutSerialData
                ' 追記モードで書き込む
                Using sw As New System.IO.StreamWriter(strOutPutFolder & strOutPutFileName, True, System.Text.Encoding.Default)
                    sw.WriteLine(strPutMessage)
                End Using

            Catch ex As Exception
                MsgBox("【OutPutSerialLogFile】" & ex.Message)
            End Try

        End SyncLock

    End Sub

    ''' <summary>
    ''' 操作履歴ログの書込処理
    ''' </summary>
    ''' <param name="strOutPutData">操作履歴メッセージ</param>
    ''' <remarks></remarks>
    Public Sub OutPutLogFile(ByVal strOutPutData As String)

        Dim strOutPutFolder As String
        Dim strOutPutFileName As String
        Dim strYYYYMMDDvalue As String
        Dim strHHMMSSvalue As String
        Dim strPutMessage As String

        SyncLock (PubConstClass.objSyncHist)

            Try
                Dim dtNow As DateTime = DateTime.Now

                ' 指定した書式で日付を文字列に変換する
                Dim strNowFormat As String = dtNow.ToString("yyyy/MM/dd HH:mm:ss")

                With Now
                    strYYYYMMDDvalue = String.Format("{0:D4}{1:D2}{2:D2}", .Year, .Month, .Day)
                    strHHMMSSvalue = String.Format("{0:D2}{1:D2}{2:D2}", .Hour, .Minute, .Second)
                End With

                ' 格納フォルダ名の設定
                strOutPutFolder = IncludeTrailingPathDelimiter(Application.StartupPath) & "OPHISTORYLOG\"
                ' 格納ファイル名の設定
                strOutPutFileName = "操作履歴ログ_" & strYYYYMMDDvalue & ".LOG"

                If System.IO.Directory.Exists(strOutPutFolder) = False Then
                    ' フォルダの作成
                    System.IO.Directory.CreateDirectory(strOutPutFolder)
                    strPutMessage = strNowFormat & "【" & strOutPutFolder & "】フォルダを作成しました。"
                    ' 追記モードで書き込む
                    Using sw As New System.IO.StreamWriter(strOutPutFolder & strOutPutFileName, True, System.Text.Encoding.Default)
                        sw.WriteLine(strPutMessage)
                    End Using
                End If

                ' 操作履歴ログに操作ログ内容を書き込む
                strPutMessage = strNowFormat & "：" & strOutPutData
                ' 追記モードで書き込む
                Using sw As New System.IO.StreamWriter(strOutPutFolder & strOutPutFileName, True, System.Text.Encoding.Default)
                    sw.WriteLine(strPutMessage)
                End Using

            Catch ex As Exception
                MsgBox("【OutPutLogFile】" & ex.Message)
            End Try

        End SyncLock

    End Sub


    ''' <summary>
    ''' 「空き」以外の登録ジョブ数を返す
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetCountJobInfomation() As Integer

        Dim strReadDataPath As String
        Dim strArray() As String
        Dim IntJobCount As Integer

        Try
            IntJobCount = 0
            strReadDataPath = IncludeTrailingPathDelimiter(Application.StartupPath) & "JOB\KindName.ini"
            Using sr As New System.IO.StreamReader(strReadDataPath, System.Text.Encoding.Default)
                Do While Not sr.EndOfStream
                    strArray = sr.ReadLine.Split(","c)
                    If strArray(1) <> "空き" Then
                        IntJobCount += 1
                    End If
                Loop
            End Using
            GetCountJobInfomation = IntJobCount

        Catch ex As Exception
            MsgBox("【GetCountJobInfomation】" & ex.Message)
            GetCountJobInfomation = 0
        End Try

    End Function

    ''' <summary>
    ''' 禁則文字【 \ / : * ? " ＜＞ | 】が含まれているかチェックする。
    ''' </summary>
    ''' <param name="strCheckData"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CheckProhibitedChar(ByVal strCheckData As String) As Boolean

        Dim BlnRetVal As Boolean

        Try
            BlnRetVal = False
            If strCheckData.Length <> strCheckData.Replace("\"c, "").Length Then
                BlnRetVal = True
            End If

            If strCheckData.Length <> strCheckData.Replace("/"c, "").Length Then
                BlnRetVal = True
            End If

            If strCheckData.Length <> strCheckData.Replace(":"c, "").Length Then
                BlnRetVal = True
            End If

            If strCheckData.Length <> strCheckData.Replace("*"c, "").Length Then
                BlnRetVal = True
            End If

            If strCheckData.Length <> strCheckData.Replace("?"c, "").Length Then
                BlnRetVal = True
            End If

            If strCheckData.Length <> strCheckData.Replace(""""c, "").Length Then
                BlnRetVal = True
            End If

            If strCheckData.Length <> strCheckData.Replace("<"c, "").Length Then
                BlnRetVal = True
            End If

            If strCheckData.Length <> strCheckData.Replace(">"c, "").Length Then
                BlnRetVal = True
            End If

            If strCheckData.Length <> strCheckData.Replace("|"c, "").Length Then
                BlnRetVal = True
            End If

            If BlnRetVal = True Then
                MsgBox("禁則文字 \ / : * ? "" < > | が含まれています。", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")
            End If
            CheckProhibitedChar = BlnRetVal

        Catch ex As Exception
            MsgBox("【CheckProhibitedChar】" & ex.Message)
            CheckProhibitedChar = True
        End Try


    End Function


End Module
