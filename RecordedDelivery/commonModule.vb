Option Explicit On
Option Strict On

Imports System.Text
Imports System.IO
Imports System.Runtime.InteropServices

Module commonModule

    Public intPrintImageIndex As Integer   ' 印字ページインデックス
    Public intImageDataCount As Integer    ' 印字する画像データの個数

    '設定取得
    Public Function myGetPrivateProfileString( _
            ByRef lpApplicationName As String, _
            ByRef lpKeyName As String, _
            ByRef lpDefault As String, _
            ByVal lpFileName As String) As String
        Dim buf As StringBuilder = New StringBuilder(256)
        GetPrivateProfileString(lpApplicationName, lpKeyName, lpDefault, buf, 256, lpFileName)
        Return buf.ToString
    End Function


    ' ANSI版 GetPrivateProfileString
    Public Declare Function GetPrivateProfileString Lib "kernel32" _
        Alias "GetPrivateProfileStringA" ( _
        <MarshalAs(UnmanagedType.LPStr)> ByVal lpApplicationName As String, _
        <MarshalAs(UnmanagedType.LPStr)> ByVal lpKeyName As String, _
        <MarshalAs(UnmanagedType.LPStr)> ByVal lpDefault As String, _
        <MarshalAs(UnmanagedType.LPStr)> ByVal lpReturnedString As StringBuilder, _
        ByVal nSize As UInt32, _
        <MarshalAs(UnmanagedType.LPStr)> ByVal lpFileName As String) As UInt32

    ' ANSI版 GetPrivateProfileInt
    Public Declare Function GetPrivateProfileInt Lib "kernel32" _
        Alias "GetPrivateProfileIntA" ( _
        <MarshalAs(UnmanagedType.LPStr)> ByVal lpApplicationName As String, _
        <MarshalAs(UnmanagedType.LPStr)> ByVal lpKeyName As String, _
        ByVal nDefault As Int32, _
        <MarshalAs(UnmanagedType.LPStr)> ByVal lpFileName As String) As UInt32

    ' ANSI版 WritePrivateProfileString
    Public Declare Function WritePrivateProfileString Lib "kernel32" _
        Alias "WritePrivateProfileStringA" ( _
        <MarshalAs(UnmanagedType.LPStr)> ByVal lpApplicationName As String, _
        <MarshalAs(UnmanagedType.LPStr)> ByVal lpKeyName As String, _
        <MarshalAs(UnmanagedType.LPStr)> ByVal lpString As String, _
        <MarshalAs(UnmanagedType.LPStr)> ByVal lpFileName As String) As UInt32


    ''' <summary>
    ''' フォルダの末尾の「\」を保証する
    ''' </summary>
    ''' <param name="strCheckFolder">チェック対象のフォルダ名称</param>
    ''' <returns>チェック後のフォルダ名称</returns>
    ''' <remarks></remarks>
    Public Function IncludeTrailingPathDelimiter(ByVal strCheckFolder As String) As String

        If strCheckFolder.Substring(strCheckFolder.Length - 1, 1) = "\"c Then
            IncludeTrailingPathDelimiter = strCheckFolder
        Else
            IncludeTrailingPathDelimiter = strCheckFolder & "\"
        End If

    End Function

    ''' <summary>
    ''' オペレータ情報の取得
    ''' </summary>
    ''' <returns>オペレータ情報（オペレータコード：オペレータ名称）</returns>
    ''' <remarks>ログインしているオペレータ情報を取得する</remarks>
    Public Function GetOperatorInfomation() As String

        Dim strRetVal As String = ""

        If PubConstClass.pblOperatorCode <> "" Then
            ' オペレータ情報（オペレータコード：オペレータ名称）の表示
            strRetVal = PubConstClass.pblOperatorCode & "：" & PubConstClass.pblOperatorName
        Else
            strRetVal = "オペレータ ログアウト"
        End If

        Return strRetVal

    End Function

    ''' <summary>
    ''' 現在の年月日を取得する
    ''' </summary>
    ''' <returns>現在の年月日</returns>
    ''' <remarks>現在の年月日を（yyyy 年 MM 月 dd 日）の形式で取得する</remarks>
    Public Function GetCurrentDate() As String

        Dim strRetVal As String = ""

        strRetVal = Date.Now.ToString("yyyy 年 MM 月 dd 日")

        Return strRetVal

    End Function

    'Public Sub OutPutSerialLogFile(ByVal strOutSerialData As String)

    '    Dim strOutPutFolder As String
    '    Dim strOutPutFileName As String
    '    Dim strYYYYMMDDvalue As String
    '    Dim strHHMMSSvalue As String
    '    Dim strPutMessage As String

    '    Try
    '        Dim dtNow As DateTime = DateTime.Now

    '        ' 指定した書式で日付を文字列に変換する
    '        Dim strNowFormat As String = dtNow.ToString("yyyy/MM/dd HH:mm:ss")

    '        With Now
    '            strYYYYMMDDvalue = String.Format("{0:D4}{1:D2}{2:D2}", .Year, .Month, .Day)
    '            strHHMMSSvalue = String.Format("{0:D2}{1:D2}{2:D2}", .Hour, .Minute, .Second)
    '        End With

    '        ' 格納フォルダ名の設定
    '        strOutPutFolder = IncludeTrailingPathDelimiter(Application.StartupPath) & "OPHISTORYLOG\"
    '        ' 格納ファイル名の設定
    '        strOutPutFileName = "通信ログ_" & strYYYYMMDDvalue & ".LOG"

    '        If System.IO.Directory.Exists(strOutPutFolder) = False Then
    '            ' フォルダの作成
    '            System.IO.Directory.CreateDirectory(strOutPutFolder)
    '            strPutMessage = strNowFormat & "【" & strOutPutFolder & "】フォルダを作成しました。"
    '            ' 追記モードで書き込む
    '            Using sw As New System.IO.StreamWriter(strOutPutFolder & strOutPutFileName, True, System.Text.Encoding.Default)
    '                sw.WriteLine(strPutMessage)
    '            End Using
    '        End If

    '        ' 操作履歴ログに操作ログ内容を書き込む
    '        strPutMessage = strNowFormat & "：" & strOutSerialData
    '        ' 追記モードで書き込む
    '        Using sw As New System.IO.StreamWriter(strOutPutFolder & strOutPutFileName, True, System.Text.Encoding.Default)
    '            sw.WriteLine(strPutMessage)
    '        End Using

    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try

    'End Sub

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
                MsgBox(ex.Message)
            End Try

        End SyncLock

    End Sub


    ''' <summary>
    ''' 検査ログ書込処理
    ''' </summary>
    ''' <param name="strYYYYMMDDvalue">処理開始年月日</param>
    ''' <param name="strHHMMSSvalue">処理開始時分秒</param>
    ''' <param name="strOutPutMessage">検査ログメッセージ</param>
    ''' <remarks></remarks>
    Public Sub OutPutKensaLogFile(ByVal strYYYYMMDDvalue As String, _
                                  ByVal strHHMMSSvalue As String, _
                                  ByVal strOutPutMessage As String)

        Dim strOutPutFolder As String
        Dim strOutPutFileName As String

        Try
            Dim dtNow As DateTime = DateTime.Now

            ' 格納フォルダ名の設定
            strOutPutFolder = IncludeTrailingPathDelimiter(PubConstClass.imgPath) & strYYYYMMDDvalue & "\"
            ' 格納ファイル名の設定
            strOutPutFileName = "稼動ログ_" & strYYYYMMDDvalue & "_" & strHHMMSSvalue & ".LOG"
            ' 追記モードで書き込む
            Using sw As New System.IO.StreamWriter(strOutPutFolder & strOutPutFileName, True, System.Text.Encoding.Default)
                sw.WriteLine(strOutPutMessage)
            End Using

        Catch ex As Exception
            MsgBox(ex.Message)
            ' 操作ログに書き込む
            Call OutPutLogFile(ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 運用記録ログの書込処理
    ''' </summary>
    ''' <param name="strOutPutMessage">運用記録ログメッセージ</param>
    ''' <remarks></remarks>
    Public Sub OutPutUseLogFile(ByVal strOutPutMessage As String)

        Dim strYYYYMMDDvalue As String
        Dim strHHMMSSvalue As String
        Dim strOutPutFolder As String
        Dim strOutPutFileName As String
        Dim strDate As String
        Dim strTime As String

        Try
            Dim dtNow As DateTime = DateTime.Now

            ' 指定した書式で日付を文字列に変換する
            Dim strNowFormat As String = dtNow.ToString("yyyy/MM/dd HH:mm:ss")

            With Now
                strYYYYMMDDvalue = String.Format("{0:D4}{1:D2}{2:D2}", .Year, .Month, .Day)
                strHHMMSSvalue = String.Format("{0:D2}{1:D2}{2:D2}", .Hour, .Minute, .Second)
            End With

            ' 格納フォルダ名の設定
            strOutPutFolder = IncludeTrailingPathDelimiter(PubConstClass.tranPath)
            ' 格納ファイル名の設定
            strOutPutFileName = "運用記録ログ_" & strYYYYMMDDvalue & ".LOG"
            strDate = strYYYYMMDDvalue.Substring(0, 4) & "/" & strYYYYMMDDvalue.Substring(4, 2) & "/" & strYYYYMMDDvalue.Substring(6, 2)
            strTime = strHHMMSSvalue.Substring(0, 2) & ":" & strHHMMSSvalue.Substring(2, 2) & ":" & strHHMMSSvalue.Substring(4, 2)
            ' 追記モードで書き込む
            Using sw As New System.IO.StreamWriter(strOutPutFolder & strOutPutFileName, True, System.Text.Encoding.Default)
                sw.WriteLine("  " & strDate & "        " & strTime & "        " & strOutPutMessage)
            End Using

        Catch ex As Exception
            MsgBox(ex.Message)
            ' 操作ログに書き込む
            Call OutPutLogFile(ex.Message)
        End Try

    End Sub


    ''' <summary>
    ''' エラーメッセージを配列に読み込む
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub getErrorInformation()

        Dim strReadDataPath As String

        Try
            strReadDataPath = IncludeTrailingPathDelimiter(Application.StartupPath) & "ErrorMessageList.txt"

            PubConstClass.intErrCnt = 0

            Using sr As New System.IO.StreamReader(strReadDataPath, System.Text.Encoding.Default)
                Do While Not sr.EndOfStream
                    PubConstClass.strErrArray(PubConstClass.intErrCnt) = sr.ReadLine.ToString
                    'OutPutLogFile("■エラーメッセージ：" & PubConstClass.strErrArray(PubConstClass.intErrCnt))
                    PubConstClass.intErrCnt += 1
                Loop
            End Using

            ' 操作ログの書き込み
            OutPutLogFile("■読込エラーメッセージ数：" & PubConstClass.intErrCnt.ToString)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' INIファイルから設定値を取得する
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub getSystemIniFile()

        Dim strIniFilePath As String

        Try
            strIniFilePath = IncludeTrailingPathDelimiter(Application.StartupPath) & PubConstClass.DEF_INI_FILENAME
            ' ユーザー番号
            PubConstClass.userNumber = myGetPrivateProfileString("System", "UserNo", "1", strIniFilePath)
            ' パスワード有効期間
            PubConstClass.passUsePeriod = myGetPrivateProfileString("System", "PasswordPeriod", "1", strIniFilePath)
            ' 区分通数
            PubConstClass.pblKuwakeCnt = myGetPrivateProfileString("System", "KuwakeCnt", "10", strIniFilePath)
            ' トリガータイム
            PubConstClass.trigerTime = myGetPrivateProfileString("System", "TrigerTime", "1", strIniFilePath)
            ' ヘッダー１頁
            PubConstClass.pblHeder1Page = myGetPrivateProfileString("System", "Header1Page", "1", strIniFilePath)
            ' ヘッダー２頁
            PubConstClass.pblHeder2Page = myGetPrivateProfileString("System", "Header2Page", "1", strIniFilePath)
            ' フッター１
            PubConstClass.pblFooter1 = myGetPrivateProfileString("System", "Footer1", "1", strIniFilePath)
            ' フッター２
            PubConstClass.pblFooter2 = myGetPrivateProfileString("System", "Footer2", "1", strIniFilePath)
            ' 号機名
            PubConstClass.pblMachineName = myGetPrivateProfileString("System", "MachineName", "1", strIniFilePath)
            ' 差出人住所１
            PubConstClass.pblSenderAddress1 = myGetPrivateProfileString("System", "SenderAddress1", "1", strIniFilePath)
            ' 差出人住所２
            PubConstClass.pblSenderAddress2 = myGetPrivateProfileString("System", "SenderAddress2", "1", strIniFilePath)
            ' 差出人氏名
            PubConstClass.pblSenderName = myGetPrivateProfileString("System", "SenderName", "1", strIniFilePath)

            ' 稼動ログファイル
            PubConstClass.tranPath = myGetPrivateProfileString("Folder", "TranSaveFolder", "1", strIniFilePath)
            ' 画像ログファイル
            PubConstClass.imgPath = myGetPrivateProfileString("Folder", "ImageSaveFolder", "1", strIniFilePath)

            ' デバイスインデックス（カメラ用）
            PubConstClass.intDeviceIdnex = CInt(myGetPrivateProfileString("Camera", "DeviceIndex", "0", strIniFilePath))
            ' フォーマットインデックス（カメラ用）
            PubConstClass.intFormatIndex = CInt(myGetPrivateProfileString("Camera", "FormatIndex", "0", strIniFilePath))

            '' 作業日
            'PubConstClass.strWorkDay = myGetPrivateProfileString("Counter", "WorkDay", "0", strIniFilePath)
            '' 当日累計
            'PubConstClass.intTodayALLCount = CInt(myGetPrivateProfileString("Counter", "TodayAllCount", "0", strIniFilePath))
            '' 簡易書留累計
            'PubConstClass.intKaniALLCount = CInt(myGetPrivateProfileString("Counter", "KaniAllCount", "0", strIniFilePath))
            '' 特定郵便累計
            'PubConstClass.intTokuALLCount = CInt(myGetPrivateProfileString("Counter", "TokuAllCount", "0", strIniFilePath))
            '' ゆうメール累計
            'PubConstClass.intMailALLCount = CInt(myGetPrivateProfileString("Counter", "MailAllCount", "0", strIniFilePath))

        Catch ex As Exception
            MsgBox("【getSystemIniFile】" & ex.Message)
        End Try

    End Sub


    ''' <summary>
    ''' 業務（ユーザー）データ取得処理
    ''' </summary>
    ''' <param name="intUserNo">ユーザー番号</param>
    ''' <remarks></remarks>
    Public Sub getUserInfomation(ByVal intUserNo As Integer)

        Dim strReadDataPath As String
        Dim strArray() As String

        Try
            strReadDataPath = IncludeTrailingPathDelimiter(Application.StartupPath) & "USER\user_" & intUserNo.ToString.PadLeft(2, "0"c) & ".txt"

            Dim sr As New System.IO.StreamReader(strReadDataPath, System.Text.Encoding.Default)

            PubConstClass.strPubPositiveDirection = "0"

            'ファイルの最後までループ
            Do Until sr.Peek = -1
                '１行づつ読込む（文字列の連結が高速に処理される）
                strArray = sr.ReadLine.Split(","c)
                Select Case strArray(0)
                    Case PubConstClass.USR_JOB_NAME
                        ' (01)業務名称
                        PubConstClass.strPubJobName = strArray(1)

                    Case PubConstClass.USR_COMMENT
                        ' (02)コメント
                        PubConstClass.strPubComment = strArray(1)

                    Case PubConstClass.USR_KIND
                        ' (03)種別
                        PubConstClass.strPubKind = strArray(1) & "," & strArray(2)

                    Case PubConstClass.USR_TEIKEI
                        ' (04)定形／定形外
                        PubConstClass.strPubTeikei = strArray(1)

                    Case PubConstClass.USR_ADRESS1
                        ' (05)差出人住所１
                        PubConstClass.strPubAddress1 = strArray(1)

                    Case PubConstClass.USR_ADRESS2
                        ' (06)差出人住所２
                        PubConstClass.strPubAddress2 = strArray(1)

                    Case PubConstClass.USR_NAME
                        ' (07)差出人氏名
                        PubConstClass.strPubName = strArray(1)

                    Case PubConstClass.USR_POSTNAME
                        ' (08)承認局名
                        PubConstClass.strPubPostName = strArray(1)

                    Case PubConstClass.USR_TEKIYOU
                        ' (09)摘要
                        PubConstClass.strPubTekiyou = strArray(1)

                    Case PubConstClass.USR_YOUSYOUGAKU
                        ' (10)要償額
                        PubConstClass.strPubYousyougaku = strArray(1)

                    Case PubConstClass.USR_FEEDER_POS_V
                        ' (11)フィーダー位置（垂直方向）
                        PubConstClass.strPubFeederPosV = strArray(1)

                    Case PubConstClass.USR_LABEL_POS_V
                        ' (12)ラベル貼付位置（垂直方向）
                        PubConstClass.strPubLabelPosV = strArray(1)

                    Case PubConstClass.USR_LABEL_POS_H
                        ' (13)ラベル貼付位置（水平方向）
                        PubConstClass.strPubLabelPosH = strArray(1)

                    Case PubConstClass.USR_ADDRESS_POS_V
                        ' (14)宛名撮像位置（垂直方向）
                        PubConstClass.strPubAddressPosV = strArray(1)

                    Case PubConstClass.USR_ADDRESS_POS_H
                        ' (15)宛名撮像位置（水平方向）
                        PubConstClass.strPubAddressPosH = strArray(1)

                    Case PubConstClass.USR_POSITIVE_DIRECTION
                        ' (16)正方向流し
                        PubConstClass.strPubPositiveDirection = strArray(1)

                    Case Else

                End Select

            Loop
            sr.Close()

        Catch ex As Exception
            MsgBox("【getUserInfomation】" & ex.Message)
        End Try

    End Sub


    ''' <summary>
    ''' 全てのオペレータ情報の取得
    ''' </summary>
    ''' <remarks>暗号化されたオペレータ情報ファイルを復号化して全てのオペレータ情報を取得する</remarks>
    Public Sub GetOperatorIniFile()

        Try
            Dim strReadDataENCPath As String = IncludeTrailingPathDelimiter(Application.StartupPath) & PubConstClass.DEF_OPERATOR_FILE_NAME_ENC
            Dim strReadDataINIPath As String = IncludeTrailingPathDelimiter(Application.StartupPath) & PubConstClass.DEF_OPERATOR_FILE_NAME_INI
            ' 暗号化されたオペレータ情報ファイルを復号化する
            DecryptFile(strReadDataENCPath, strReadDataINIPath, PubConstClass.DEF_OPEN_KEY)

            PubConstClass.pblOperatorArrayIndex = 0

            Using sr As New System.IO.StreamReader(strReadDataINIPath, System.Text.Encoding.Default)
                Do While Not sr.EndOfStream
                    PubConstClass.pblOperatorArray(PubConstClass.pblOperatorArrayIndex) = sr.ReadLine.ToString
                    'OutPutLogFile("■オペレーター情報：" & PubConstClass.pblOperatorArray(PubConstClass.pblOperatorArrayIndex))
                    PubConstClass.pblOperatorArrayIndex += 1
                Loop
            End Using
            ' 復号化したオペレータファイルの削除
            System.IO.File.Delete(strReadDataINIPath)

            ' 操作ログの書き込み
            OutPutLogFile("■オペレータ情報読込数：" & PubConstClass.pblOperatorArrayIndex.ToString)

        Catch ex As Exception
            MsgBox("【GetOperatorIniFile】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 支店マスター読込処理
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub GetBranchMasterFile()

        Try
            Dim strReadDataPath As String = IncludeTrailingPathDelimiter(Application.StartupPath) & PubConstClass.DEF_BRANCH_MASTER

            PubConstClass.pblBranchIndex = 0

            Using sr As New System.IO.StreamReader(strReadDataPath, System.Text.Encoding.Default)
                Do While Not sr.EndOfStream
                    PubConstClass.pblBranchArray(PubConstClass.pblBranchIndex) = sr.ReadLine.ToString
                    'OutPutLogFile("■支店マスター情報：" & PubConstClass.pblBranchArray(PubConstClass.pblBranchIndex))
                    PubConstClass.pblBranchIndex += 1
                Loop
            End Using

            ' 操作ログの書き込み
            OutPutLogFile("■支店マスター読込数：" & PubConstClass.pblBranchIndex.ToString)

        Catch ex As Exception
            MsgBox("【GetBranchMasterFile】" & ex.Message)
        End Try

    End Sub


    ''' <summary>
    ''' 種別データの取得
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub GetClassDataFile()

        Try            
            ' 種別ファイルの読込み
            Dim strReadDataPath As String = IncludeTrailingPathDelimiter(Application.StartupPath) & PubConstClass.DEF_CLASS_FILE_NAME

            PubConstClass.pblClassDataIndex = 0

            Using sr As New System.IO.StreamReader(strReadDataPath, System.Text.Encoding.Default)

                Do While Not sr.EndOfStream
                    PubConstClass.pblClassData(PubConstClass.pblClassDataIndex) = sr.ReadLine.ToString
                    PubConstClass.pblClassDataIndex += 1
                Loop

            End Using

            ' 操作ログの書き込み
            OutPutLogFile("■種別データ読込数：" & PubConstClass.pblClassDataIndex.ToString)

        Catch ex As Exception
            MsgBox("【GetClassDataFile】" & ex.Message)
        End Try

    End Sub


    ''' <summary>
    ''' 業務データコンボボックス登録処理
    ''' </summary>
    ''' <param name="cmbJob">データを追加するコンボボックス</param>
    ''' <remarks>指定したコンボボックスに業務データを登録する</remarks>
    Public Sub EntryJobComboBox(ByVal cmbJob As ComboBox)

        Dim strFolder As String
        Dim N As Integer
        Dim strArray() As String
        Dim strReadDataPath As String

        Try

            strFolder = IncludeTrailingPathDelimiter(Application.StartupPath) & "USER"
            Dim files As String() = System.IO.Directory.GetFiles( _
                                    strFolder, "user_*.txt", System.IO.SearchOption.AllDirectories)
            cmbJob.Items.Clear()
            For N = 0 To files.GetLength(0) - 1
                strArray = files(N).Split("\"c)

                strReadDataPath = IncludeTrailingPathDelimiter(Application.StartupPath) & "USER\" & strArray(strArray.GetLength(0) - 1)

                Using sr As New System.IO.StreamReader(strReadDataPath, System.Text.Encoding.Default)
                    Do While Not sr.EndOfStream
                        strArray = sr.ReadLine.Split(","c)
                        If strArray(0) = PubConstClass.USR_JOB_NAME Then
                            ' コメント
                            cmbJob.Items.Add((N + 1).ToString.PadLeft(3, "0"c) & "：" & strArray(1))
                            Exit Do
                        End If
                    Loop
                End Using
            Next
            cmbJob.SelectedIndex = CInt(PubConstClass.userNumber) - 1

        Catch ex As Exception
            MsgBox("【EntryJobComboBox】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 業務データコンボボックス登録処理（種別と一致したデータのみ）
    ''' </summary>
    ''' <param name="cmbJob">データを追加するコンボボックス</param>
    ''' <param name="strClass">表示したい種別</param>
    ''' <remarks>指定したコンボボックスに指定した種別と一致した業務データを登録する</remarks>
    Public Sub EntryJobClassComboBox(ByVal cmbJob As ComboBox, ByRef strClass As String)

        Dim strFolder As String
        Dim N As Integer
        Dim strArray() As String
        Dim strReadDataPath As String

        Dim strJobName As String = ""

        Try

            strFolder = IncludeTrailingPathDelimiter(Application.StartupPath) & "USER"
            Dim files As String() = System.IO.Directory.GetFiles( _
                                    strFolder, "user_*.txt", System.IO.SearchOption.AllDirectories)
            cmbJob.Items.Clear()
            For N = 0 To files.GetLength(0) - 1
                strArray = files(N).Split("\"c)

                strReadDataPath = IncludeTrailingPathDelimiter(Application.StartupPath) & "USER\" & strArray(strArray.GetLength(0) - 1)

                Using sr As New System.IO.StreamReader(strReadDataPath, System.Text.Encoding.Default)

                    Do While Not sr.EndOfStream
                        strArray = sr.ReadLine.Split(","c)
                        If strArray(0) = PubConstClass.USR_JOB_NAME Then
                            ' 業務名
                            strJobName = (N + 1).ToString.PadLeft(3, "0"c) & "：" & strArray(1)
                        End If
                        If strArray(0) = PubConstClass.USR_KIND Then
                            ' 種別
                            If strArray.Length > 2 Then
                                Dim strWork() As String = strJobName.Split("："c)
                                If strArray(2) = strClass And strWork(1) <> "（空き）" Then
                                    cmbJob.Items.Add(strJobName)
                                    Exit Do
                                End If
                            End If
                        End If
                    Loop

                End Using
            Next
            ' コンボボックスの初期表示はインデックス＝０とする
            'cmbJob.SelectedIndex = CInt(PubConstClass.userNumber) - 1
            cmbJob.SelectedIndex = 0

        Catch exArgOutOfRange As ArgumentOutOfRangeException
            MsgBox("種別【" & strClass & "】の業務データが見つかりません")
        Catch ex As Exception
            MsgBox("【EntryJobComboBox】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 引受番号データ取得処理
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub GetUnderWritingNumber()

        Try
            Dim intArrayIndex As Integer = 0
            Dim strReadDataFileName As String = IncludeTrailingPathDelimiter(Application.StartupPath) & PubConstClass.DEF_UNDER_WRITING_NUMBER

            ' 引受番号帯コードと種別（表示用）【030,簡易書留】
            PubConstClass.strNumberInfo(0) = myGetPrivateProfileString("Class30", "ClassName", "999,ＸＸＸ", strReadDataFileName)
            ' 開始番号
            PubConstClass.strStartNumber(0) = myGetPrivateProfileString("Class30", "StartNum", "開始番号,999-99-99999-9", strReadDataFileName)
            ' 終了番号
            PubConstClass.strEndNumber(0) = myGetPrivateProfileString("Class30", "EndNum", "終了番号,999-99-99999-9", strReadDataFileName)
            ' 番号帯の中でのスタート番号
            PubConstClass.strCurrentNumber(0) = myGetPrivateProfileString("Class30", "CurrentNum", "スタート番号,999-99-99999-9", strReadDataFileName)

            ' 引受番号帯コードと種別（表示用）【050,特定記録】
            PubConstClass.strNumberInfo(1) = myGetPrivateProfileString("Class50", "ClassName", "999,ＸＸＸ", strReadDataFileName)
            ' 開始番号
            PubConstClass.strStartNumber(1) = myGetPrivateProfileString("Class50", "StartNum", "開始番号,999-99-99999-9", strReadDataFileName)
            ' 終了番号
            PubConstClass.strEndNumber(1) = myGetPrivateProfileString("Class50", "EndNum", "終了番号,999-99-99999-9", strReadDataFileName)
            ' 番号帯の中でのスタート番号
            PubConstClass.strCurrentNumber(1) = myGetPrivateProfileString("Class50", "CurrentNum", "スタート番号,999-99-99999-9", strReadDataFileName)

            ' 引受番号帯コードと種別（表示用）【150,ゆうメール】
            PubConstClass.strNumberInfo(2) = myGetPrivateProfileString("Class150", "ClassName", "999,ＸＸＸ", strReadDataFileName)
            ' 開始番号
            PubConstClass.strStartNumber(2) = myGetPrivateProfileString("Class150", "StartNum", "開始番号,999-99-99999-9", strReadDataFileName)
            ' 終了番号
            PubConstClass.strEndNumber(2) = myGetPrivateProfileString("Class150", "EndNum", "終了番号,999-99-99999-9", strReadDataFileName)
            ' 番号帯の中でのスタート番号
            PubConstClass.strCurrentNumber(2) = myGetPrivateProfileString("Class150", "CurrentNum", "スタート番号,999-99-99999-9", strReadDataFileName)

            ' 引受番号帯コードと種別（表示用）【070,書留】
            PubConstClass.strNumberInfo(3) = myGetPrivateProfileString("Class70", "ClassName", "999,ＸＸＸ", strReadDataFileName)
            ' 開始番号
            PubConstClass.strStartNumber(3) = myGetPrivateProfileString("Class70", "StartNum", "開始番号,999-99-99999-9", strReadDataFileName)
            ' 終了番号
            PubConstClass.strEndNumber(3) = myGetPrivateProfileString("Class70", "EndNum", "終了番号,999-99-99999-9", strReadDataFileName)
            ' 番号帯の中でのスタート番号
            PubConstClass.strCurrentNumber(3) = myGetPrivateProfileString("Class70", "CurrentNum", "スタート番号,999-99-99999-9", strReadDataFileName)

            'Using sr As New System.IO.StreamReader(strReadDataFileName, System.Text.Encoding.Default)
            '    Do While Not sr.EndOfStream
            '        ' 引受番号帯コードと種別（表示用）
            '        PubConstClass.strNumberInfo(intArrayIndex) = sr.ReadLine.ToString
            '        ' 開始番号
            '        PubConstClass.strStartNumber(intArrayIndex) = sr.ReadLine.ToString
            '        ' 終了番号
            '        PubConstClass.strEndNumber(intArrayIndex) = sr.ReadLine.ToString
            '        ' 番号帯の中でのスタート番号
            '        PubConstClass.strCurrentNumber(intArrayIndex) = sr.ReadLine.ToString
            '        intArrayIndex += 1
            '        If intArrayIndex > 2 Then
            '            ' データは３個固定
            '            Exit Do
            '        End If
            '    Loop
            'End Using

        Catch ex As Exception
            MsgBox("【GetUnderWritingNumber】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 種別単位の重量及び料金データを読込む
    ''' </summary>
    ''' <param name="strClassCodeFile"></param>
    ''' <remarks></remarks>
    Public Sub GetClassMasterData(ByVal strClassCodeFile As String)

        Dim strReadData As String
        Dim strArray() As String

        Try
            Dim strReadDataPath As String = IncludeTrailingPathDelimiter(Application.StartupPath) & strClassCodeFile & ".txt"

            Using sr As New System.IO.StreamReader(strReadDataPath, System.Text.Encoding.Default)

                ' １行読み飛ばし（0,030：簡易書留）
                strReadData = sr.ReadLine.ToString
                ' １行読み飛ばし（[定形：重量,料金]）
                strReadData = sr.ReadLine.ToString
                For N = 0 To 8
                    ' 定形の重量及び料金の読込
                    strArray = sr.ReadLine.ToString.Split(","c)
                    If strArray(0) = "" Then
                        PubConstClass.strWeightArray(N) = "0"
                        PubConstClass.strPriceArray(N) = "0"
                    Else
                        PubConstClass.strWeightArray(N) = strArray(0)
                        PubConstClass.strPriceArray(N) = strArray(1)
                    End If
                    OutPutLogFile("定形：" & PubConstClass.strWeightArray(N) & "／" & PubConstClass.strPriceArray(N))
                Next
                OutPutLogFile("----------------------------------------------------------------------")

                ' １行読み飛ばし（[定形外（規格内）：重量,料金]）
                strReadData = sr.ReadLine.ToString
                For N = 0 To 7
                    ' 定形外の重量及び料金の読込
                    strArray = sr.ReadLine.ToString.Split(","c)
                    If strArray(0) = "" Then
                        PubConstClass.strWeightGaiArray(N) = "0"
                        PubConstClass.strPriceGaiArray(N) = "0"
                    Else
                        PubConstClass.strWeightGaiArray(N) = strArray(0)
                        PubConstClass.strPriceGaiArray(N) = strArray(1)
                    End If
                    OutPutLogFile("定形外（規格内）：" & PubConstClass.strWeightGaiArray(N) & "／" & PubConstClass.strPriceGaiArray(N))
                Next

                OutPutLogFile("----------------------------------------------------------------------")
                ' １行読み飛ばし（[定形外（規格外）：重量,料金]）
                strReadData = sr.ReadLine.ToString
                For N = 0 To 7
                    ' 定形外の重量及び料金の読込
                    strArray = sr.ReadLine.ToString.Split(","c)
                    If strArray(0) = "" Then
                        PubConstClass.strWeightNonSArray(N) = "0"
                        PubConstClass.strPriceNonSArray(N) = "0"
                    Else
                        PubConstClass.strWeightNonSArray(N) = strArray(0)
                        PubConstClass.strPriceNonSArray(N) = strArray(1)
                    End If
                    OutPutLogFile("定形外（規格外）：" & PubConstClass.strWeightNonSArray(N) & "／" & PubConstClass.strPriceNonSArray(N))
                Next
                OutPutLogFile("----------------------------------------------------------------------")

            End Using

        Catch ex As Exception
            MsgBox("【GetClassMasterData】" & ex.Message)
        End Try

    End Sub



    ''' <summary>
    ''' 文字列を暗号化する
    ''' </summary>
    ''' <param name="sourceString">暗号化する文字列</param>
    ''' <param name="password">暗号化に使用するパスワード</param>
    ''' <returns>暗号化された文字列</returns>
    Public Function EncryptString(ByVal sourceString As String, _
                                         ByVal password As String) As String
        'RijndaelManagedオブジェクトを作成
        Dim rijndael As New System.Security.Cryptography.RijndaelManaged()

        'パスワードから共有キーと初期化ベクタを作成
        Dim key As Byte() = Nothing
        Dim iv As Byte() = Nothing
        GenerateKeyFromPassword(password, rijndael.KeySize, key, rijndael.BlockSize, iv)
        rijndael.Key = key
        rijndael.IV = iv

        '文字列をバイト型配列に変換する
        Dim strBytes As Byte() = System.Text.Encoding.UTF8.GetBytes(sourceString)

        '対称暗号化オブジェクトの作成
        Dim encryptor As System.Security.Cryptography.ICryptoTransform = _
            rijndael.CreateEncryptor()
        'バイト型配列を暗号化する
        Dim encBytes As Byte() = encryptor.TransformFinalBlock(strBytes, 0, strBytes.Length)
        '閉じる
        encryptor.Dispose()

        'バイト型配列を文字列に変換して返す
        Return System.Convert.ToBase64String(encBytes)

    End Function

    ''' <summary>
    ''' 暗号化された文字列を復号化する
    ''' </summary>
    ''' <param name="sourceString">暗号化された文字列</param>
    ''' <param name="password">暗号化に使用したパスワード</param>
    ''' <returns>復号化された文字列</returns>
    Public Function DecryptString(ByVal sourceString As String, _
                                         ByVal password As String) As String
        'RijndaelManagedオブジェクトを作成
        Dim rijndael As New System.Security.Cryptography.RijndaelManaged()

        'パスワードから共有キーと初期化ベクタを作成
        Dim key As Byte() = Nothing
        Dim iv As Byte() = Nothing
        GenerateKeyFromPassword(password, rijndael.KeySize, key, rijndael.BlockSize, iv)
        rijndael.Key = key
        rijndael.IV = iv

        '文字列をバイト型配列に戻す
        Dim strBytes As Byte() = System.Convert.FromBase64String(sourceString)

        '対称暗号化オブジェクトの作成
        Dim decryptor As System.Security.Cryptography.ICryptoTransform = _
            rijndael.CreateDecryptor()
        'バイト型配列を復号化する
        '復号化に失敗すると例外CryptographicExceptionが発生
        Dim decBytes As Byte() = decryptor.TransformFinalBlock(strBytes, 0, strBytes.Length)
        '閉じる
        decryptor.Dispose()

        'バイト型配列を文字列に戻して返す
        Return System.Text.Encoding.UTF8.GetString(decBytes)

    End Function


    ''' <summary>
    ''' パスワードから共有キーと初期化ベクタを生成する
    ''' </summary>
    ''' <param name="password">基になるパスワード</param>
    ''' <param name="keySize">共有キーのサイズ（ビット）</param>
    ''' <param name="key">作成された共有キー</param>
    ''' <param name="blockSize">初期化ベクタのサイズ（ビット）</param>
    ''' <param name="iv">作成された初期化ベクタ</param>
    Private Sub GenerateKeyFromPassword(ByVal password As String, _
                                               ByVal keySize As Integer, _
                                               ByRef key As Byte(), _
                                               ByVal blockSize As Integer, _
                                               ByRef iv As Byte())
        'パスワードから共有キーと初期化ベクタを作成する
        'saltを決める
        Dim salt As Byte() = System.Text.Encoding.UTF8.GetBytes("saltは必ず8バイト以上")
        'Rfc2898DeriveBytesオブジェクトを作成する
        Dim deriveBytes As New System.Security.Cryptography.Rfc2898DeriveBytes( _
            password, salt)
        '.NET Framework 1.1以下の時は、PasswordDeriveBytesを使用する
        'Dim deriveBytes As New System.Security.Cryptography.PasswordDeriveBytes( _
        '    password, salt)
        '反復処理回数を指定する デフォルトで1000回
        deriveBytes.IterationCount = 1000

        '共有キーと初期化ベクタを生成する
        key = deriveBytes.GetBytes(keySize \ 8)
        iv = deriveBytes.GetBytes(blockSize \ 8)
    End Sub

    ''' <summary>
    ''' ファイルを暗号化する
    ''' </summary>
    ''' <param name="sourceFile">暗号化するファイルパス</param>
    ''' <param name="destFile">暗号化されたデータを保存するファイルパス</param>
    ''' <param name="password">暗号化に使用するパスワード</param>
    Public Sub EncryptFile(ByVal sourceFile As String, _
                                  ByVal destFile As String, _
                                  ByVal password As String)
        Dim rijndael As New System.Security.Cryptography.RijndaelManaged()

        'パスワードから共有キーと初期化ベクタを作成
        Dim key As Byte(), iv As Byte()
        key = Nothing
        iv = Nothing

        GenerateKeyFromPassword(password, rijndael.KeySize, key, rijndael.BlockSize, iv)
        rijndael.Key = key
        rijndael.IV = iv

        '以下、前のコードと同じ
        Dim outFs As New System.IO.FileStream( _
            destFile, System.IO.FileMode.Create, System.IO.FileAccess.Write)
        Dim encryptor As System.Security.Cryptography.ICryptoTransform = _
            rijndael.CreateEncryptor()
        Dim cryptStrm As New System.Security.Cryptography.CryptoStream( _
            outFs, encryptor, System.Security.Cryptography.CryptoStreamMode.Write)

        Dim inFs As New System.IO.FileStream( _
            sourceFile, System.IO.FileMode.Open, System.IO.FileAccess.Read)
        Dim bs As Byte() = New Byte(1023) {}
        Dim readLen As Integer
        While True
            readLen = inFs.Read(bs, 0, bs.Length)
            If readLen = 0 Then
                Exit While
            End If
            cryptStrm.Write(bs, 0, readLen)
        End While

        inFs.Close()
        cryptStrm.Close()
        encryptor.Dispose()
        outFs.Close()
    End Sub

    ''' <summary>
    ''' ファイルを復号化する
    ''' </summary>
    ''' <param name="sourceFile">復号化するファイルパス</param>
    ''' <param name="destFile">復号化されたデータを保存するファイルパス</param>
    ''' <param name="password">暗号化に使用したパスワード</param>
    Public Sub DecryptFile(ByVal sourceFile As String, _
                                  ByVal destFile As String, _
                                  ByVal password As String)
        Dim rijndael As New System.Security.Cryptography.RijndaelManaged()

        'パスワードから共有キーと初期化ベクタを作成
        Dim key As Byte(), iv As Byte()
        key = Nothing
        iv = Nothing

        GenerateKeyFromPassword(password, rijndael.KeySize, key, rijndael.BlockSize, iv)
        rijndael.Key = key
        rijndael.IV = iv

        '以下、前のコードと同じ
        Dim inFs As New System.IO.FileStream( _
            sourceFile, System.IO.FileMode.Open, System.IO.FileAccess.Read)
        Dim decryptor As System.Security.Cryptography.ICryptoTransform = _
            rijndael.CreateDecryptor()
        Dim cryptStrm As New System.Security.Cryptography.CryptoStream( _
            inFs, decryptor, System.Security.Cryptography.CryptoStreamMode.Read)

        Dim outFs As New System.IO.FileStream( _
            destFile, System.IO.FileMode.Create, System.IO.FileAccess.Write)
        Dim bs As Byte() = New Byte(1023) {}
        Dim readLen As Integer
        While True
            readLen = cryptStrm.Read(bs, 0, bs.Length)
            If readLen = 0 Then
                Exit While
            End If
            outFs.Write(bs, 0, readLen)
        End While

        outFs.Close()
        cryptStrm.Close()
        decryptor.Dispose()
        inFs.Close()
    End Sub

    ''' <summary>
    ''' 引受番号の取得
    ''' </summary>
    ''' <param name="index"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetArAcceptNumber(ByVal index As Integer) As String

        Try
            Dim strArray() As String = PubConstClass.arListForPrint(index).ToString.Split(","c)
            GetArAcceptNumber = strArray(3)

        Catch ex As Exception
            GetArAcceptNumber = "XXX-XX-XXXXX-X"
            MsgBox("【GetArAcceptNumber】" & ex.Message)
        End Try

    End Function

    ''' <summary>
    ''' 重量の取得
    ''' </summary>
    ''' <param name="index"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetArWeightVal(ByVal index As Integer) As String

        Try
            Dim strArray() As String = PubConstClass.arListForPrint(index).ToString.Split(","c)
            GetArWeightVal = strArray(4)

        Catch ex As Exception
            GetArWeightVal = "XXXX"
            MsgBox("【GetArWeightVal】" & ex.Message)
        End Try

    End Function

    ''' <summary>
    ''' 料金の取得
    ''' </summary>
    ''' <param name="index"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetArPriceVal(ByVal index As Integer) As String

        Try
            Dim strArray() As String = PubConstClass.arListForPrint(index).ToString.Split(","c)
            GetArPriceVal = strArray(5)

        Catch ex As Exception
            GetArPriceVal = "XXXX"
            MsgBox("【GetArPriceValSub】" & ex.Message)
        End Try

    End Function

    ''' <summary>
    ''' 撮像画像ファイル名の取得
    ''' </summary>
    ''' <param name="index"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetArPrintFileName(ByVal index As Integer) As String

        Try
            Dim strArray() As String = PubConstClass.arListForPrint(index).ToString.Split(","c)
            GetArPrintFileName = strArray(6)

        Catch ex As Exception
            GetArPrintFileName = ""
            MsgBox("【GetArPrintFileName】" & ex.Message)
        End Try

    End Function

    ''' <summary>
    ''' 抜取・削除データの取得
    ''' </summary>
    ''' <param name="index"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetArNukitoriVal(ByVal index As Integer) As String

        Try
            Dim strArray() As String = PubConstClass.arListForPrint(index).ToString.Split(","c)
            GetArNukitoriVal = strArray(12)

        Catch ex As Exception
            GetArNukitoriVal = ""
            MsgBox("【GetArNukitoriVal】" & ex.Message)
        End Try

    End Function


    ''' <summary>
    ''' 「１５面／ページ」印刷処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Sub Print15FacePerPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)

        ' 「１５面／ページ」印刷処理
        Dim strArray() As String        ' データ分離用配列
        Dim img(15) As Image            ' 印刷画像格納配列

        Dim intLoopCnt As Integer       ' 汎用ループカウンタ
        Dim N As Integer                ' 汎用ループカウンタ
        Dim intXPos(3) As Integer       ' ３列横ポジション
        Dim intYPos(6) As Integer       ' （５段＋フッター）縦ポジション

        Dim intGetIndex As Integer

        Dim intIMGYoko As Integer       ' 画像の横サイズ
        Dim intIMGTate As Integer       ' 画像の縦サイズ

        Dim intYoko As Integer          ' 横枠（画像用）
        Dim intTate As Integer          ' 縦枠（画像用）

        Dim intTateChr1 As Integer      ' 縦枠（１行目文字用）
        Dim intTateChr2 As Integer      ' 縦枠（２行目文字用）

        Dim intChrPos1 As Integer       '「重量」印字位置
        Dim intChrPos2 As Integer       '「要償額」印字位置
        Dim intChrPos3 As Integer       '「摘要」印字位置

        Dim intMargin As Integer        ' 余白

        Dim intSTPosYoko As Integer     ' 印刷開始ポジション（横）
        Dim intSTPosTate As Integer     ' 印刷開始ポジション（縦）

        Dim intLineWidth As Integer     ' 罫線幅
        Dim intOffSet As Integer        ' 印字オフセット

        Try
            ' 印刷画像の大きさ設定
            intIMGYoko = 248    ' ≒1980÷8（1/8サイズ）（約60mm／1mm≒4.11）
            intIMGTate = 140    ' ≒1080÷8（1/8サイズ）（約34mm／1mm≒4.11）
            ' 余白の設定
            intMargin = 10
            ' 印刷枠の大きさ設定
            intYoko = intMargin + intIMGYoko
            intTate = intMargin + intIMGTate
            ' 印刷文字列の高さ設定
            intTateChr1 = 20
            intTateChr2 = 20

            intChrPos1 = intYoko - 40 - 50 - 40
            intChrPos2 = intYoko - 50 - 40
            intChrPos3 = intYoko - 40

            ' 印刷開始ポジションの設定
            intSTPosYoko = intMargin * 2
            intSTPosTate = intMargin * 6

            ' 罫線幅の設定
            intLineWidth = 800

            intOffSet = 5
            ' ヘッダーの印刷
            Dim dtNow As DateTime = DateTime.Now
            Dim h As New Font("メイリオ", 14, FontStyle.Regular)
            Dim f As New Font("メイリオ", 10, FontStyle.Regular)
            ' ヘッダー１行目
            e.Graphics.DrawString(PubConstClass.strPubPostName & " 承認", f, Brushes.Black, 700, intMargin * 1)

            strArray = Split(PubConstClass.pblClassForSiten, "："c)
            If PubConstClass.intReceiptKind = 0 Then
                ' 「ヘッダー１頁」情報の印刷                
                e.Graphics.DrawString(strArray(1) & PubConstClass.pblHeder1Page, h, Brushes.Black, 10, intMargin * 2)
                Call OutPutLogFile(strArray(1) & PubConstClass.pblHeder1Page)
            Else
                ' 「ヘッダー２頁」情報の印刷
                e.Graphics.DrawString(strArray(1) & PubConstClass.pblHeder2Page, h, Brushes.Black, 10, intMargin * 2)
                Call OutPutLogFile(strArray(1) & PubConstClass.pblHeder2Page)
            End If

            ' ヘッダー２行目
            ' 号機名
            e.Graphics.DrawString("【" & PubConstClass.pblMachineName & "】", f, Brushes.Black, 600, intMargin * 1)

            e.Graphics.DrawString("店番：" & PubConstClass.pblSitenCode, f, Brushes.Black, 350, intMargin * 1)
            e.Graphics.DrawString("店名：" & PubConstClass.pblSitenName, f, Brushes.Black, 350, intMargin * 3)

            e.Graphics.DrawString(dtNow.ToString("yyyy年 MM月 dd日"), f, Brushes.Black, 600, intMargin * 3)
            e.Graphics.DrawString("Page " & (intPrintImageIndex + 1).ToString, f, Brushes.Black, 750, intMargin * 3)
            ' 罫線の印刷
            e.Graphics.DrawLine(New Pen(Color.Black), intSTPosYoko, intMargin * 5, intLineWidth, intMargin * 5)            

            For N = 1 To 5

                '// １段目の画像の枠作成
                e.Graphics.DrawRectangle(New Pen(Color.Black), New Rectangle(intSTPosYoko + intYoko * 0 + intMargin * 0, intSTPosTate + intTate * (N - 1), intYoko, intTate))
                e.Graphics.DrawRectangle(New Pen(Color.Black), New Rectangle(intSTPosYoko + intYoko * 1 + intMargin * 1, intSTPosTate + intTate * (N - 1), intYoko, intTate))
                e.Graphics.DrawRectangle(New Pen(Color.Black), New Rectangle(intSTPosYoko + intYoko * 2 + intMargin * 2, intSTPosTate + intTate * (N - 1), intYoko, intTate))
                '// １段目の１行目文字列の作成
                e.Graphics.DrawRectangle(New Pen(Color.Black), New Rectangle(intSTPosYoko + intYoko * 0 + intMargin * 0, intSTPosTate + intTate * N, intYoko, intTateChr1))
                e.Graphics.DrawRectangle(New Pen(Color.Black), New Rectangle(intSTPosYoko + intYoko * 1 + intMargin * 1, intSTPosTate + intTate * N, intYoko, intTateChr1))
                e.Graphics.DrawRectangle(New Pen(Color.Black), New Rectangle(intSTPosYoko + intYoko * 2 + intMargin * 2, intSTPosTate + intTate * N, intYoko, intTateChr1))

                e.Graphics.DrawRectangle(New Pen(Color.Black), New Rectangle(intSTPosYoko + intYoko * 0 + intMargin * 0, intSTPosTate + intTate * N, 103, intTateChr1))
                e.Graphics.DrawRectangle(New Pen(Color.Black), New Rectangle(intSTPosYoko + intYoko * 1 + intMargin * 1, intSTPosTate + intTate * N, 103, intTateChr1))
                e.Graphics.DrawRectangle(New Pen(Color.Black), New Rectangle(intSTPosYoko + intYoko * 2 + intMargin * 2, intSTPosTate + intTate * N, 103, intTateChr1))

                '// １段目の２行目文字列の枠作成
                e.Graphics.DrawRectangle(New Pen(Color.Black), New Rectangle(intSTPosYoko + intYoko * 0 + intMargin * 0, intSTPosTate + intTate * N + intTateChr1 * 1, intYoko, intTateChr2))
                e.Graphics.DrawRectangle(New Pen(Color.Black), New Rectangle(intSTPosYoko + intYoko * 1 + intMargin * 1, intSTPosTate + intTate * N + intTateChr1 * 1, intYoko, intTateChr2))
                e.Graphics.DrawRectangle(New Pen(Color.Black), New Rectangle(intSTPosYoko + intYoko * 2 + intMargin * 2, intSTPosTate + intTate * N + intTateChr1 * 1, intYoko, intTateChr2))

                '// 「引受番号」の枠作成
                e.Graphics.DrawRectangle(New Pen(Color.Black), New Rectangle(intSTPosYoko + intYoko * 0 + intMargin * 0, intSTPosTate + intTate * N, intChrPos1, intTateChr1 + intTateChr2))
                e.Graphics.DrawRectangle(New Pen(Color.Black), New Rectangle(intSTPosYoko + intYoko * 1 + intMargin * 1, intSTPosTate + intTate * N, intChrPos1, intTateChr1 + intTateChr2))
                e.Graphics.DrawRectangle(New Pen(Color.Black), New Rectangle(intSTPosYoko + intYoko * 2 + intMargin * 2, intSTPosTate + intTate * N, intChrPos1, intTateChr1 + intTateChr2))
                e.Graphics.DrawString("引受番号", f, Brushes.Black, intSTPosYoko + intYoko * 0 + intMargin * 2, intSTPosTate + intTate * N)
                e.Graphics.DrawString("引受番号", f, Brushes.Black, intSTPosYoko + intYoko * 1 + intMargin * 3, intSTPosTate + intTate * N)
                e.Graphics.DrawString("引受番号", f, Brushes.Black, intSTPosYoko + intYoko * 2 + intMargin * 4, intSTPosTate + intTate * N)

                '// 「重量」の枠作成
                e.Graphics.DrawRectangle(New Pen(Color.Black), New Rectangle(intSTPosYoko + intYoko * 0 + intMargin * 0, intSTPosTate + intTate * N, intChrPos2, intTateChr1 + intTateChr2))
                e.Graphics.DrawRectangle(New Pen(Color.Black), New Rectangle(intSTPosYoko + intYoko * 1 + intMargin * 1, intSTPosTate + intTate * N, intChrPos2, intTateChr1 + intTateChr2))
                e.Graphics.DrawRectangle(New Pen(Color.Black), New Rectangle(intSTPosYoko + intYoko * 2 + intMargin * 2, intSTPosTate + intTate * N, intChrPos2, intTateChr1 + intTateChr2))
                e.Graphics.DrawString("重量", f, Brushes.Black, intSTPosYoko + intYoko * 0 + intChrPos1 + intMargin * 1 - intOffSet, intSTPosTate + intTate * N)
                e.Graphics.DrawString("重量", f, Brushes.Black, intSTPosYoko + intYoko * 1 + intChrPos1 + intMargin * 2 - intOffSet, intSTPosTate + intTate * N)
                e.Graphics.DrawString("重量", f, Brushes.Black, intSTPosYoko + intYoko * 2 + intChrPos1 + intMargin * 3 - intOffSet, intSTPosTate + intTate * N)
                '// 「料金」の枠作成（残りが「要償額」の枠となる）
                e.Graphics.DrawRectangle(New Pen(Color.Black), New Rectangle(intSTPosYoko + intYoko * 0 + intMargin * 0, intSTPosTate + intTate * N, intChrPos3 - 10, intTateChr1 + intTateChr2))
                e.Graphics.DrawRectangle(New Pen(Color.Black), New Rectangle(intSTPosYoko + intYoko * 1 + intMargin * 1, intSTPosTate + intTate * N, intChrPos3 - 10, intTateChr1 + intTateChr2))
                e.Graphics.DrawRectangle(New Pen(Color.Black), New Rectangle(intSTPosYoko + intYoko * 2 + intMargin * 2, intSTPosTate + intTate * N, intChrPos3 - 10, intTateChr1 + intTateChr2))

                e.Graphics.DrawString("料金", f, Brushes.Black, intSTPosYoko + intYoko * 0 + intChrPos2 + intMargin * 0, intSTPosTate + intTate * N)
                e.Graphics.DrawString("料金", f, Brushes.Black, intSTPosYoko + intYoko * 1 + intChrPos2 + intMargin * 1, intSTPosTate + intTate * N)
                e.Graphics.DrawString("料金", f, Brushes.Black, intSTPosYoko + intYoko * 2 + intChrPos2 + intMargin * 2, intSTPosTate + intTate * N)

                e.Graphics.DrawString("要償額", f, Brushes.Black, intSTPosYoko + intYoko * 0 + intChrPos3 + intMargin * 1 - intOffSet - 15, intSTPosTate + intTate * N)
                e.Graphics.DrawString("要償額", f, Brushes.Black, intSTPosYoko + intYoko * 1 + intChrPos3 + intMargin * 2 - intOffSet - 15, intSTPosTate + intTate * N)
                e.Graphics.DrawString("要償額", f, Brushes.Black, intSTPosYoko + intYoko * 2 + intChrPos3 + intMargin * 3 - intOffSet - 15, intSTPosTate + intTate * N)

                ' 縦方向画像印字位置設定
                intYPos(N - 1) = intSTPosTate + intTate * (N - 1) + CInt(intMargin / 2)

                ' 印刷開始ポジションを１段下に下げる
                intSTPosTate = intSTPosTate + intTateChr1 + intTateChr2 + intMargin

            Next N

            ' 印刷開始ポジションを１段下に下げる
            intYPos(5) = intSTPosTate + intTate * 5
            ' フッターの印刷
            Dim ft As New Font("メイリオ", 9, FontStyle.Regular)
            e.Graphics.DrawRectangle(New Pen(Color.Black), New Rectangle(intSTPosYoko, intYPos(5), intLineWidth - 10 - 82 - 33, intMargin * 3))
            e.Graphics.DrawRectangle(New Pen(Color.Black), New Rectangle(intSTPosYoko, intYPos(5), intLineWidth - 10, intMargin * 10))
            e.Graphics.DrawRectangle(New Pen(Color.Black), New Rectangle(intSTPosYoko, intYPos(5), intLineWidth - 10 - 82, intMargin * 10))
            e.Graphics.DrawRectangle(New Pen(Color.Black), New Rectangle(intSTPosYoko, intYPos(5), intLineWidth - 10 - 82 - 33, intMargin * 10))

            e.Graphics.DrawString("(差出人の住所及び氏名)　" & PubConstClass.strPubAddress1 & PubConstClass.strPubAddress2, ft, Brushes.Black, intSTPosYoko, intYPos(5))
            e.Graphics.DrawString(PubConstClass.strPubName, ft, Brushes.Black, intSTPosYoko + 200, intYPos(5) + intMargin + 2)
            e.Graphics.DrawString("引", ft, Brushes.Black, intLineWidth - 10 - 60 - 25, intYPos(5) + intMargin * 1)
            e.Graphics.DrawString("受", ft, Brushes.Black, intLineWidth - 10 - 60 - 25, intYPos(5) + intMargin * 2 + 5)
            e.Graphics.DrawString("日", ft, Brushes.Black, intLineWidth - 10 - 60 - 25, intYPos(5) + intMargin * 3 + 10)
            e.Graphics.DrawString("付", ft, Brushes.Black, intLineWidth - 10 - 60 - 25, intYPos(5) + intMargin * 4 + 15)
            e.Graphics.DrawString("印", ft, Brushes.Black, intLineWidth - 10 - 60 - 25, intYPos(5) + intMargin * 5 + 20)

            ' 印刷開始ポジションを１段下に下げる
            intYPos(5) = intSTPosTate + intTate * 5 + 35
            e.Graphics.DrawString("(ご注意)　" & PubConstClass.pblFooter1, ft, Brushes.Black, intSTPosYoko, intYPos(5))

            ' 印刷開始ポジションを１段下に下げる
            intYPos(5) = intSTPosTate + intTate * 5 + 50
            e.Graphics.DrawString("　　　　　" & PubConstClass.pblFooter2, ft, Brushes.Black, intSTPosYoko, intYPos(5))

            ' 横方向印字位置設定
            intXPos(0) = intSTPosYoko + CInt(intMargin / 2)
            intXPos(1) = intSTPosYoko + CInt(intMargin / 2) + intYoko + intMargin
            intXPos(2) = intSTPosYoko + CInt(intMargin / 2) + intYoko + intMargin + intYoko + intMargin

            Dim index_X As Integer
            Dim index_Y As Integer
            Dim strPrintFileName(15) As String
            Dim strAcceptNumber As String
            Dim strNukitori As String
            Dim strWeightVal As String
            Dim strPriceVal As String

            strAcceptNumber = ""
            ' １ページ１５画像印字
            For intLoopCnt = 0 To 15 - 1

                intGetIndex = intLoopCnt + intPrintImageIndex * 15
                ' 画像ファイル名
                strPrintFileName(intLoopCnt) = GetArPrintFileName(intGetIndex)
                ' 引受番号の取得
                strAcceptNumber = GetArAcceptNumber(intGetIndex)
                ' 抜取／削除
                strNukitori = GetArNukitoriVal(intGetIndex)
                ' 重量の取得
                strWeightVal = GetArWeightVal(intGetIndex)
                ' 料金の取得
                strPriceVal = GetArPriceVal(intGetIndex)

                Dim intModVal As Integer
                Dim intDivVal As Integer

                intModVal = intLoopCnt Mod 3
                intDivVal = CInt(Math.Truncate(intLoopCnt / 3))

                Select Case intModVal
                    Case 0
                        ' 引受番号印字
                        e.Graphics.DrawString(strAcceptNumber, f, Brushes.Black, intSTPosYoko + intYoko * 0 + intMargin * 0, intYPos(intDivVal) + intTate + intTateChr1 - CInt(intMargin / 2))
                        ' 抜取／削除
                        e.Graphics.DrawString(strNukitori, f, Brushes.Black, intSTPosYoko + intYoko * 0 + intMargin * 0 + 108, intYPos(intDivVal) + intTate - CInt(intMargin / 2))
                        ' 重量印字
                        e.Graphics.DrawString(strWeightVal, f, Brushes.Black, intSTPosYoko + intYoko * 0 - 5 + intChrPos1 + intMargin * 1 - intOffSet, intYPos(intDivVal) + intTate + intTateChr1 - CInt(intMargin / 2))
                        ' 料金印字
                        e.Graphics.DrawString(strPriceVal, f, Brushes.Black, intSTPosYoko + intYoko * 0 + 35 + intChrPos1 + intMargin * 1 - intOffSet, intYPos(intDivVal) + intTate + intTateChr1 - CInt(intMargin / 2))
                    Case 1
                        ' 引受番号印字
                        e.Graphics.DrawString(strAcceptNumber, f, Brushes.Black, intSTPosYoko + intYoko * 1 + intMargin * 1, intYPos(intDivVal) + intTate + intTateChr1 - CInt(intMargin / 2))
                        ' 抜取／削除
                        e.Graphics.DrawString(strNukitori, f, Brushes.Black, intSTPosYoko + intYoko * 1 + intMargin * 1 + 108, intYPos(intDivVal) + intTate - CInt(intMargin / 2))
                        ' 重量印字
                        e.Graphics.DrawString(strWeightVal, f, Brushes.Black, intSTPosYoko + intYoko * 1 - 5 + intChrPos1 + intMargin * 2 - intOffSet, intYPos(intDivVal) + intTate + intTateChr1 - CInt(intMargin / 2))
                        ' 料金印字
                        e.Graphics.DrawString(strPriceVal, f, Brushes.Black, intSTPosYoko + intYoko * 1 + 35 + intChrPos1 + intMargin * 2 - intOffSet, intYPos(intDivVal) + intTate + intTateChr1 - CInt(intMargin / 2))
                    Case 2
                        ' 引受番号印字
                        e.Graphics.DrawString(strAcceptNumber, f, Brushes.Black, intSTPosYoko + intYoko * 2 + intMargin * 2, intYPos(intDivVal) + intTate + intTateChr1 - CInt(intMargin / 2))
                        ' 抜取／削除
                        e.Graphics.DrawString(strNukitori, f, Brushes.Black, intSTPosYoko + intYoko * 2 + intMargin * 2 + 108, intYPos(intDivVal) + intTate - CInt(intMargin / 2))
                        ' 重量印字
                        e.Graphics.DrawString(strWeightVal, f, Brushes.Black, intSTPosYoko + intYoko * 2 - 5 + intChrPos1 + intMargin * 3 - intOffSet, intYPos(intDivVal) + intTate + intTateChr1 - CInt(intMargin / 2))
                        ' 料金印字
                        e.Graphics.DrawString(strPriceVal, f, Brushes.Black, intSTPosYoko + intYoko * 2 + 35 + intChrPos1 + intMargin * 3 - intOffSet, intYPos(intDivVal) + intTate + intTateChr1 - CInt(intMargin / 2))
                End Select

                ' 画像ファイルの存在チェック
                If System.IO.File.Exists(strPrintFileName(intLoopCnt)) = True Then
                    '// 2016.02.05 Ver.B06 hayakawa 修正↓ここから
                    ' 画像ファイルが存在する
                    'img(intLoopCnt) = Image.FromFile(strPrintFileName(intLoopCnt))
                    Dim imgSmall As Image
                    imgSmall = Image.FromFile(strPrintFileName(intLoopCnt))
                    If imgSmall.Width > 1920 Or imgSmall.Height > 1080 Then
                        ' Full HD 以上ならサムネイル処理を行う
                        img(intLoopCnt) = imgSmall.GetThumbnailImage(intIMGYoko * 2, intIMGTate * 2, Nothing, IntPtr.Zero)
                        '//TODO:コメントアウトする事
                        'img(intLoopCnt).Save(strPrintFileName(intLoopCnt).Replace(".jpg", "_small.jpg"))
                        '// 2016.01.25 Ver.B06 hayakawa 修正↑ここまで
                    Else
                        'img(intLoopCnt) = imgSmall
                        img(intLoopCnt) = Image.FromFile(strPrintFileName(intLoopCnt))
                    End If
                    imgSmall.Dispose()
                    '// 2016.02.05 Ver.B06 hayakawa 修正↑ここまで
                Else
                    ' 画像ファイルが存在しない場合
                    img(intLoopCnt) = Image.FromFile(IncludeTrailingPathDelimiter(Application.StartupPath) & "noimage.jpg")
                End If

                index_X = intLoopCnt Mod 3
                index_Y = CInt(Math.Truncate(intLoopCnt / 3))
                e.Graphics.DrawImage(img(intLoopCnt), New Rectangle(intXPos(index_X), intYPos(index_Y), intIMGYoko, intIMGTate))
                ' 画像ファイルの解放
                img(intLoopCnt).Dispose()

                If (intLoopCnt + 1) Mod 3 = 0 Then
                    'e.Graphics.DrawString(strAcceptNumber, font, Brushes.Black, e.MarginBounds, StringFormat.GenericTypographic)
                    strAcceptNumber = ""
                End If
                intImageDataCount = intImageDataCount - 1
                If intImageDataCount < 1 Then
                    Exit For
                End If

            Next intLoopCnt

            If intImageDataCount > 0 Then
                e.HasMorePages = True
                intPrintImageIndex = intPrintImageIndex + 1
            Else
                e.HasMorePages = False
            End If

        Catch ex As Exception
            MsgBox("【Print15FacePerPage】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 「８面／ページ」印刷処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Sub Print8FacePerPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)

        Dim strArray() As String        ' データ分離用配列
        Dim img(8) As Image             ' 印刷画像格納配列

        Dim intLoopCnt As Integer       ' 汎用ループカウンタ
        Dim N As Integer                ' 汎用ループカウンタ
        Dim intXPos(2) As Integer       ' 横ポジション（２列）
        Dim intYPos(5) As Integer       ' 縦ポジション（４段＋フッター）

        Dim intGetIndex As Integer

        Dim intIMGYoko As Integer       ' 画像の横サイズ
        Dim intIMGTate As Integer       ' 画像の縦サイズ

        Dim intYoko As Integer          ' 横枠（画像用）
        Dim intTate As Integer          ' 縦枠（画像用）

        Dim intTateChr1 As Integer      ' 縦枠（１行目文字用）
        Dim intTateChr2 As Integer      ' 縦枠（２行目文字用）

        Dim intChrPos1 As Integer       '「重量」印字位置
        Dim intChrPos2 As Integer       '「料金」印字位置
        Dim intChrPos3 As Integer       '「要償額」印字位置

        Dim intMargin As Integer        ' 余白

        Dim intSTPosYoko As Integer     ' 印刷開始ポジション（横）
        Dim intSTPosTate As Integer     ' 印刷開始ポジション（縦）

        Dim intLineWidth As Integer     ' 罫線幅
        Dim intOffSet As Integer        ' 印字オフセット

        Try

            ' 印刷画像の大きさ設定
            intIMGYoko = 382    ' ≒93mm（1mm≒4.11）
            intIMGTate = 190    ' ≒46mm（1mm≒4.11）
            ' 余白の設定
            intMargin = 10
            ' 印刷枠の大きさ設定
            intYoko = intMargin + intIMGYoko
            intTate = intMargin + intIMGTate
            ' 印刷文字列の高さ設定
            intTateChr1 = 20
            intTateChr2 = 20

            intChrPos1 = intYoko - 40 - 50 - 40
            intChrPos2 = intYoko - 50 - 40
            intChrPos3 = intYoko - 40

            ' 印刷開始ポジションの設定
            intSTPosYoko = intMargin * 2
            intSTPosTate = intMargin * 6

            ' 罫線幅の設定
            intLineWidth = 800

            intOffSet = 5
            ' ヘッダーの印刷
            Dim dtNow As DateTime = DateTime.Now
            Dim h As New Font("メイリオ", 14, FontStyle.Regular)
            Dim f As New Font("メイリオ", 10, FontStyle.Regular)
            ' ヘッダー１行目
            e.Graphics.DrawString(PubConstClass.strPubPostName & " 承認", f, Brushes.Black, 700, intMargin * 1)

            strArray = Split(PubConstClass.pblClassForSiten, "："c)
            If PubConstClass.intReceiptKind = 0 Then
                ' 「ヘッダー１頁」情報の印刷                
                e.Graphics.DrawString(strArray(1) & PubConstClass.pblHeder1Page, h, Brushes.Black, 10, intMargin * 2)
                Call OutPutLogFile(strArray(1) & PubConstClass.pblHeder1Page)
            Else
                ' 「ヘッダー２頁」情報の印刷
                e.Graphics.DrawString(strArray(1) & PubConstClass.pblHeder2Page, h, Brushes.Black, 10, intMargin * 2)
                Call OutPutLogFile(strArray(1) & PubConstClass.pblHeder2Page)
            End If

            ' ヘッダー２行目
            ' 号機名
            e.Graphics.DrawString("【" & PubConstClass.pblMachineName & "】", f, Brushes.Black, 600, intMargin * 1)
            e.Graphics.DrawString("店番：" & PubConstClass.pblSitenCode, f, Brushes.Black, 350, intMargin * 1)
            e.Graphics.DrawString("店名：" & PubConstClass.pblSitenName, f, Brushes.Black, 350, intMargin * 3)

            e.Graphics.DrawString(dtNow.ToString("yyyy年 MM月 dd日"), f, Brushes.Black, 600, intMargin * 3)
            e.Graphics.DrawString("Page " & (intPrintImageIndex + 1).ToString, f, Brushes.Black, 750, intMargin * 3)
            ' 罫線の印刷
            e.Graphics.DrawLine(New Pen(Color.Black), intSTPosYoko, intMargin * 5, intLineWidth, intMargin * 5)

            For N = 1 To 4

                '// １段目の画像の枠作成
                e.Graphics.DrawRectangle(New Pen(Color.Black), New Rectangle(intSTPosYoko + intYoko * 0 + intMargin * 0, intSTPosTate + intTate * (N - 1), intYoko, intTate))
                e.Graphics.DrawRectangle(New Pen(Color.Black), New Rectangle(intSTPosYoko + intYoko * 1 + intMargin * 1, intSTPosTate + intTate * (N - 1), intYoko, intTate))

                '// １段目の１行目文字列の作成
                e.Graphics.DrawRectangle(New Pen(Color.Black), New Rectangle(intSTPosYoko + intYoko * 0 + intMargin * 0, intSTPosTate + intTate * N, intYoko, intTateChr1))
                e.Graphics.DrawRectangle(New Pen(Color.Black), New Rectangle(intSTPosYoko + intYoko * 1 + intMargin * 1, intSTPosTate + intTate * N, intYoko, intTateChr1))

                e.Graphics.DrawRectangle(New Pen(Color.Black), New Rectangle(intSTPosYoko + intYoko * 0 + intMargin * 0, intSTPosTate + intTate * N, 230, intTateChr1))
                e.Graphics.DrawRectangle(New Pen(Color.Black), New Rectangle(intSTPosYoko + intYoko * 1 + intMargin * 1, intSTPosTate + intTate * N, 230, intTateChr1))

                '// １段目の２行目文字列の枠作成
                e.Graphics.DrawRectangle(New Pen(Color.Black), New Rectangle(intSTPosYoko + intYoko * 0 + intMargin * 0, intSTPosTate + intTate * N + intTateChr1 * 1, intYoko, intTateChr2))
                e.Graphics.DrawRectangle(New Pen(Color.Black), New Rectangle(intSTPosYoko + intYoko * 1 + intMargin * 1, intSTPosTate + intTate * N + intTateChr1 * 1, intYoko, intTateChr2))

                '// 「引受番号」の枠作成
                e.Graphics.DrawRectangle(New Pen(Color.Black), New Rectangle(intSTPosYoko + intYoko * 0 + intMargin * 0, intSTPosTate + intTate * N, intChrPos1, intTateChr1 + intTateChr2))
                e.Graphics.DrawRectangle(New Pen(Color.Black), New Rectangle(intSTPosYoko + intYoko * 1 + intMargin * 1, intSTPosTate + intTate * N, intChrPos1, intTateChr1 + intTateChr2))
                e.Graphics.DrawString("引受番号", f, Brushes.Black, intSTPosYoko + intYoko * 0 + intMargin * 2, intSTPosTate + intTate * N)
                e.Graphics.DrawString("引受番号", f, Brushes.Black, intSTPosYoko + intYoko * 1 + intMargin * 3, intSTPosTate + intTate * N)

                '// 「重量」の枠作成
                e.Graphics.DrawRectangle(New Pen(Color.Black), New Rectangle(intSTPosYoko + intYoko * 0 + intMargin * 0, intSTPosTate + intTate * N, intChrPos2, intTateChr1 + intTateChr2))
                e.Graphics.DrawRectangle(New Pen(Color.Black), New Rectangle(intSTPosYoko + intYoko * 1 + intMargin * 1, intSTPosTate + intTate * N, intChrPos2, intTateChr1 + intTateChr2))
                e.Graphics.DrawString("重量", f, Brushes.Black, intSTPosYoko + intYoko * 0 + intChrPos1 + intMargin * 1 - intOffSet, intSTPosTate + intTate * N)
                e.Graphics.DrawString("重量", f, Brushes.Black, intSTPosYoko + intYoko * 1 + intChrPos1 + intMargin * 2 - intOffSet, intSTPosTate + intTate * N)

                '// 「料金」の枠作成（残りが「要償額」の枠となる）
                e.Graphics.DrawRectangle(New Pen(Color.Black), New Rectangle(intSTPosYoko + intYoko * 0 + intMargin * 0, intSTPosTate + intTate * N, intChrPos3 - 10, intTateChr1 + intTateChr2))
                e.Graphics.DrawRectangle(New Pen(Color.Black), New Rectangle(intSTPosYoko + intYoko * 1 + intMargin * 1, intSTPosTate + intTate * N, intChrPos3 - 10, intTateChr1 + intTateChr2))
                e.Graphics.DrawString("料金", f, Brushes.Black, intSTPosYoko + intYoko * 0 + intChrPos2 + intMargin * 0, intSTPosTate + intTate * N)
                e.Graphics.DrawString("料金", f, Brushes.Black, intSTPosYoko + intYoko * 1 + intChrPos2 + intMargin * 1, intSTPosTate + intTate * N)

                e.Graphics.DrawString("要償額", f, Brushes.Black, intSTPosYoko + intYoko * 0 + intChrPos3 + intMargin * 1 - intOffSet - 15, intSTPosTate + intTate * N)
                e.Graphics.DrawString("要償額", f, Brushes.Black, intSTPosYoko + intYoko * 1 + intChrPos3 + intMargin * 2 - intOffSet - 15, intSTPosTate + intTate * N)

                ' 縦方向画像印字位置設定
                intYPos(N - 1) = intSTPosTate + intTate * (N - 1) + CInt(intMargin / 2)

                ' 印刷開始ポジションを１段下に下げる
                intSTPosTate = intSTPosTate + intTateChr1 + intTateChr2 + intMargin

            Next N

            ' 印刷開始ポジションを１段下に下げる
            intYPos(5) = intSTPosTate + intTate * 4
            ' フッターの印刷
            Dim ft As New Font("メイリオ", 9, FontStyle.Regular)
            e.Graphics.DrawRectangle(New Pen(Color.Black), New Rectangle(intSTPosYoko, intYPos(5), intLineWidth - 10 - 82 - 33, intMargin * 3))
            e.Graphics.DrawRectangle(New Pen(Color.Black), New Rectangle(intSTPosYoko, intYPos(5), intLineWidth - 10, intMargin * 10))
            e.Graphics.DrawRectangle(New Pen(Color.Black), New Rectangle(intSTPosYoko, intYPos(5), intLineWidth - 10 - 82, intMargin * 10))
            e.Graphics.DrawRectangle(New Pen(Color.Black), New Rectangle(intSTPosYoko, intYPos(5), intLineWidth - 10 - 82 - 33, intMargin * 10))

            e.Graphics.DrawString("(差出人の住所及び氏名)　" & PubConstClass.strPubAddress1 & PubConstClass.strPubAddress2, ft, Brushes.Black, intSTPosYoko, intYPos(5))
            e.Graphics.DrawString(PubConstClass.strPubName, ft, Brushes.Black, intSTPosYoko + 200, intYPos(5) + intMargin + 2)
            e.Graphics.DrawString("引", ft, Brushes.Black, intLineWidth - 10 - 60 - 25, intYPos(5) + intMargin * 1)
            e.Graphics.DrawString("受", ft, Brushes.Black, intLineWidth - 10 - 60 - 25, intYPos(5) + intMargin * 2 + 5)
            e.Graphics.DrawString("日", ft, Brushes.Black, intLineWidth - 10 - 60 - 25, intYPos(5) + intMargin * 3 + 10)
            e.Graphics.DrawString("付", ft, Brushes.Black, intLineWidth - 10 - 60 - 25, intYPos(5) + intMargin * 4 + 15)
            e.Graphics.DrawString("印", ft, Brushes.Black, intLineWidth - 10 - 60 - 25, intYPos(5) + intMargin * 5 + 20)

            ' 印刷開始ポジションを１段下に下げる
            intYPos(5) = intSTPosTate + intTate * 4 + 35
            e.Graphics.DrawString("(ご注意)　" & PubConstClass.pblFooter1, ft, Brushes.Black, intSTPosYoko, intYPos(5))

            ' 印刷開始ポジションを１段下に下げる
            intYPos(5) = intSTPosTate + intTate * 4 + 50
            e.Graphics.DrawString("　　　　　" & PubConstClass.pblFooter2, ft, Brushes.Black, intSTPosYoko, intYPos(5))

            ' 横方向印字位置設定
            intXPos(0) = intSTPosYoko + CInt(intMargin / 2)
            intXPos(1) = intSTPosYoko + CInt(intMargin / 2) + intYoko + intMargin
            intXPos(2) = intSTPosYoko + CInt(intMargin / 2) + intYoko + intMargin + intYoko + intMargin

            Dim index_X As Integer
            Dim index_Y As Integer
            Dim strPrintFileName(15) As String
            Dim strAcceptNumber As String
            Dim strNukitori As String
            Dim strWeightVal As String
            Dim strPriceVal As String

            strAcceptNumber = ""
            ' １ページ８画像印字
            For intLoopCnt = 0 To 8 - 1

                intGetIndex = intLoopCnt + intPrintImageIndex * 8
                ' 画像ファイル名
                strPrintFileName(intLoopCnt) = GetArPrintFileName(intGetIndex)
                ' 引受番号の取得
                strAcceptNumber = GetArAcceptNumber(intGetIndex)
                ' 抜取／削除
                strNukitori = GetArNukitoriVal(intGetIndex)                
                ' 重量の取得
                strWeightVal = GetArWeightVal(intGetIndex)
                ' 料金の取得
                strPriceVal = GetArPriceVal(intGetIndex)

                Dim intModVal As Integer
                Dim intDivVal As Integer

                intModVal = intLoopCnt Mod 2
                intDivVal = CInt(Math.Truncate(intLoopCnt / 2))
                Select Case intModVal
                    Case 0
                        ' 引受番号印字
                        e.Graphics.DrawString(strAcceptNumber, f, Brushes.Black, intSTPosYoko + intYoko * 0 + intMargin * 0, intYPos(intDivVal) + intTate + intTateChr1 - CInt(intMargin / 2))
                        ' 抜取／削除
                        e.Graphics.DrawString(strNukitori, f, Brushes.Black, intSTPosYoko + intYoko * 0 + intMargin * 0 + 238, intYPos(intDivVal) + intTate - CInt(intMargin / 2))
                        ' 重量印字
                        e.Graphics.DrawString(strWeightVal, f, Brushes.Black, intSTPosYoko + intYoko * 0 - 5 + intChrPos1 + intMargin * 1 - intOffSet, intYPos(intDivVal) + intTate + intTateChr1 - CInt(intMargin / 2))
                        ' 料金印字
                        e.Graphics.DrawString(strPriceVal, f, Brushes.Black, intSTPosYoko + intYoko * 0 + 35 + intChrPos1 + intMargin * 1 - intOffSet, intYPos(intDivVal) + intTate + intTateChr1 - CInt(intMargin / 2))
                    Case 1
                        ' 引受番号印字
                        e.Graphics.DrawString(strAcceptNumber, f, Brushes.Black, intSTPosYoko + intYoko * 1 + intMargin * 1, intYPos(intDivVal) + intTate + intTateChr1 - CInt(intMargin / 2))
                        ' 抜取／削除
                        e.Graphics.DrawString(strNukitori, f, Brushes.Black, intSTPosYoko + intYoko * 1 + intMargin * 1 + 238, intYPos(intDivVal) + intTate - CInt(intMargin / 2))
                        ' 重量印字
                        e.Graphics.DrawString(strWeightVal, f, Brushes.Black, intSTPosYoko + intYoko * 1 - 5 + intChrPos1 + intMargin * 2 - intOffSet, intYPos(intDivVal) + intTate + intTateChr1 - CInt(intMargin / 2))
                        ' 料金印字
                        e.Graphics.DrawString(strPriceVal, f, Brushes.Black, intSTPosYoko + intYoko * 1 + 35 + intChrPos1 + intMargin * 2 - intOffSet, intYPos(intDivVal) + intTate + intTateChr1 - CInt(intMargin / 2))
                End Select

                ' 画像ファイルの存在チェック
                If System.IO.File.Exists(strPrintFileName(intLoopCnt)) = True Then
                    '// 2016.02.05 Ver.B06 hayakawa 修正↓ここから
                    ' 画像ファイルが存在する
                    'img(intLoopCnt) = Image.FromFile(strPrintFileName(intLoopCnt))
                    Dim imgSmall As Image
                    imgSmall = Image.FromFile(strPrintFileName(intLoopCnt))
                    If imgSmall.Width > 1920 Or imgSmall.Height > 1080 Then
                        ' Full HD 以上ならサムネイル処理を行う
                        img(intLoopCnt) = imgSmall.GetThumbnailImage(intIMGYoko * 2, intIMGTate * 2, Nothing, IntPtr.Zero)
                        '//TODO:コメントアウトする事
                        'img(intLoopCnt).Save(strPrintFileName(intLoopCnt).Replace(".jpg", "_small.jpg"))
                        '// 2016.01.25 Ver.B06 hayakawa 修正↑ここまで
                    Else
                        'img(intLoopCnt) = imgSmall
                        img(intLoopCnt) = Image.FromFile(strPrintFileName(intLoopCnt))
                    End If
                    imgSmall.Dispose()
                    '// 2016.02.05 Ver.B06 hayakawa 修正↑ここまで
                Else
                    ' 画像ファイルが存在しない場合
                    img(intLoopCnt) = Image.FromFile(IncludeTrailingPathDelimiter(Application.StartupPath) & "noimage.jpg")
                End If

                index_X = intLoopCnt Mod 2
                index_Y = CInt(Math.Truncate(intLoopCnt / 2))
                e.Graphics.DrawImage(img(intLoopCnt), New Rectangle(intXPos(index_X), intYPos(index_Y), intIMGYoko, intIMGTate))
                ' 画像ファイルの解放
                img(intLoopCnt).Dispose()

                If (intLoopCnt + 1) Mod 2 = 0 Then
                    strAcceptNumber = ""
                End If
                intImageDataCount = intImageDataCount - 1
                If intImageDataCount < 1 Then
                    Exit For
                End If
            Next intLoopCnt

            If intImageDataCount > 0 Then
                e.HasMorePages = True
                intPrintImageIndex = intPrintImageIndex + 1
            Else
                e.HasMorePages = False
            End If

        Catch ex As Exception
            MsgBox("【Print8FacePerPage】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 入力されたキーのチェック
    ''' 1：数字のみ入力可能
    ''' 2：数字と大文字英字と小文字英字のみ入力可能
    ''' 3：数字と大文字英字と小文字英字と「-」「_」のみ入力可能
    ''' </summary>
    ''' <param name="strFunc"></param>
    ''' <param name="e"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CheckKeyPress(ByVal strFunc As String, e As System.Windows.Forms.KeyPressEventArgs) As Boolean

        ' 「BS」の場合はキャンセルしない
        If e.KeyChar = Constants.vbBack Then
            Return False
        End If

        Select Case strFunc
            Case "1"
                If e.KeyChar >= "0"c And e.KeyChar <= "9"c Then
                    ' 押されたキーが「0～9」の場合は入力をキャンセルしない
                    Return False
                Else
                    ' 上記以外のキー入力はキャンセルする
                    Return True
                End If
            Case "2"
                If e.KeyChar >= "0"c And e.KeyChar <= "9"c Then
                    ' 押されたキーが「0～9」の場合は入力をキャンセルしない
                    Return False
                ElseIf e.KeyChar >= "A"c And e.KeyChar <= "Z"c Then
                    ' 押されたキーが「A～Z」の場合は入力をキャンセルしない
                    Return False
                ElseIf e.KeyChar >= "a"c And e.KeyChar <= "z"c Then
                    ' 押されたキーが「a～z」の場合は入力をキャンセルしない
                    Return False
                Else
                    ' 上記以外のキー入力はキャンセルする
                    Return True
                End If
            Case "3"
                If e.KeyChar >= "0"c And e.KeyChar <= "9"c Then
                    ' 押されたキーが「0～9」の場合は入力をキャンセルしない
                    Return False
                ElseIf e.KeyChar >= "A"c And e.KeyChar <= "Z"c Then
                    ' 押されたキーが「A～Z」の場合は入力をキャンセルしない
                    Return False
                ElseIf e.KeyChar >= "a"c And e.KeyChar <= "z"c Then
                    ' 押されたキーが「a～z」の場合は入力をキャンセルしない
                    Return False
                ElseIf e.KeyChar = "-"c Or e.KeyChar = "_"c Then
                    ' 押されたキーが「-」「_」の場合は入力をキャンセルしない
                    Return False
                Else
                    ' 上記以外のキー入力はキャンセルする
                    Return True
                End If
            Case Else
                Return False
        End Select

        Return False

    End Function


    ''' <summary>
    ''' ①10桁の引受番号からバーコードデータESCコマンドを作成する
    ''' ②CODABAR(NW-7)でC/Dは7DR
    ''' ③スタート・ストップコードは「c」
    ''' </summary>
    ''' <param name="txtHikiuke">10桁の引受番号</param>
    ''' <returns>バーコードデータ印字コマンド文字列</returns>
    ''' <remarks></remarks>
    Public Function GetBarCodeSendData(ByVal txtHikiuke As String) As String

        Dim strSendData As String
        Dim strCd As String

        Try
            strCd = (CDbl(txtHikiuke) Mod 7).ToString("0")

            strSendData = Chr(27) & "%0"
            strSendData &= Chr(27) & "V024"
            strSendData &= Chr(27) & "H600"
            strSendData &= Chr(27) & "B003100c" & txtHikiuke & strCd & "c"

            Return strSendData

        Catch ex As Exception
            MsgBox("【GetEscSendData】" & ex.Message)
        End Try

        Return "ERROR"

    End Function

    ''' <summary>
    ''' バーコードの解説文字データESCコマンドを作成する
    ''' C/Dは7DRで作成しスタート・ストップコードは付加しない
    ''' </summary>
    ''' <param name="txtHikiuke">引受番号</param>
    ''' <returns>バーコードの解説文字印字コマンド文字列</returns>
    ''' <remarks></remarks>
    Public Function GetCharSendData(ByVal txtHikiuke As String) As String

        Dim strSendData As String
        Dim strCd As String

        Try
            strCd = (CDbl(txtHikiuke) Mod 7).ToString("0")

            strSendData = Chr(27) & "%0"
            strSendData &= Chr(27) & "V132"
            strSendData &= Chr(27) & "H720"
            strSendData &= Chr(27) & "P04L0101WB0" & CDbl(txtHikiuke).ToString("000-00-00000") & "-" & strCd

            Return strSendData

        Catch ex As Exception
            MsgBox("【GetEscSendData】" & ex.Message)
        End Try

        Return "ERROR"

    End Function


    ''' <summary>
    ''' テストラベルの作成
    ''' </summary>
    ''' <param name="txtTestData"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetTestLabelSendData(ByVal txtTestData As String) As String

        Dim strSendData As String

        Try
            strSendData = Chr(27) & "%0"
            strSendData &= Chr(27) & "V132"
            strSendData &= Chr(27) & "H720"
            strSendData &= Chr(27) & "P04L0101WB0" & txtTestData

            Return strSendData

        Catch ex As Exception
            MsgBox("【GetTestLabelSendData】" & ex.Message)
        End Try

        Return "ERROR"

    End Function


    ''' <summary>
    ''' ①10桁の引受番号からバーコードデータESCコマンドを作成する
    ''' ②CODABAR(NW-7)でC/Dは7DR
    ''' ③スタート・ストップコードは「c」
    ''' </summary>
    ''' <param name="txtHikiuke">10桁の引受番号</param>
    ''' <returns>バーコードデータ印字コマンド文字列</returns>
    ''' <remarks></remarks>
    Public Function GetBarCode180SendData(ByVal txtHikiuke As String) As String

        Dim strSendData As String
        Dim strCd As String

        Try
            strCd = (CDbl(txtHikiuke) Mod 7).ToString("0")

            strSendData = Chr(27) & "%2"
            'strSendData &= Chr(27) & "V024"        ' 縦方向：2 mm＝24  ÷12
            'strSendData &= Chr(27) & "H600"        ' 横方向：50mm＝600 ÷12
            strSendData &= Chr(27) & "V144"         ' 縦方向：mm＝144 ÷12
            strSendData &= Chr(27) & "H1140"        ' 横方向：90mm＝1080÷12
            strSendData &= Chr(27) & "B003100c" & txtHikiuke & strCd & "c"

            Return strSendData

        Catch ex As Exception
            MsgBox("【GetEscSendData】" & ex.Message)
        End Try

        Return "ERROR"

    End Function

    ''' <summary>
    ''' バーコードの解説文字データESCコマンドを作成する
    ''' C/Dは7DRで作成しスタート・ストップコードは付加しない
    ''' </summary>
    ''' <param name="txtHikiuke">引受番号</param>
    ''' <returns>バーコードの解説文字印字コマンド文字列</returns>
    ''' <remarks></remarks>
    Public Function GetChar180SendData(ByVal txtHikiuke As String) As String

        Dim strSendData As String
        Dim strCd As String

        Try
            strCd = (CDbl(txtHikiuke) Mod 7).ToString("0")

            'strSendData = Chr(27) & "%0"
            'strSendData &= Chr(27) & "V132"
            'strSendData &= Chr(27) & "H720"
            strSendData = Chr(27) & "%2"
            strSendData &= Chr(27) & "V036"     ' 縦方向：3 mm＝36 ÷12
            strSendData &= Chr(27) & "H1080"    ' 横方向：90mm＝1080÷12
            strSendData &= Chr(27) & "P04L0101WB0" & CDbl(txtHikiuke).ToString("000-00-00000") & "-" & strCd

            Return strSendData

        Catch ex As Exception
            MsgBox("【GetEscSendData】" & ex.Message)
        End Try

        Return "ERROR"

    End Function


    ''' <summary>
    ''' テストラベルの作成
    ''' </summary>
    ''' <param name="txtTestData">テスト印字文字列</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetTestLabel180SendData(ByVal txtTestData As String) As String

        Dim strSendData As String

        Try
            'strSendData = Chr(27) & "%2"
            'strSendData &= Chr(27) & "V132"
            'strSendData &= Chr(27) & "H720"
            strSendData = Chr(27) & "%2"
            strSendData &= Chr(27) & "V132"     ' 縦方向：11 mm＝132 ÷12
            strSendData &= Chr(27) & "H1080"    ' 横方向：90 mm＝1080÷12
            strSendData &= Chr(27) & "P04L0101WB0" & txtTestData

            Return strSendData

        Catch ex As Exception
            MsgBox("【GetTestLabelSendData】" & ex.Message)
        End Try

        Return "ERROR"

    End Function

    ''' <summary>
    ''' 過去に使用された引受番号を取得する
    ''' 2015.12.14 Ver.B04 hayakawa 追加
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub GetUsedUnderWritingNumber()

        Dim strUsedWrittingNumber As String

        Try
            Dim arrayUnderWrittingList() As String
            Dim strReadData As String
            Dim arUsed30WrittingList As ArrayList = New ArrayList()
            Dim arUsed50WrittingList As ArrayList = New ArrayList()
            Dim arUsed150WrittingList As ArrayList = New ArrayList()
            Dim arUsed70WrittingList As ArrayList = New ArrayList()        '【今回追加】

            Dim arUsed30WrittingList2 As ArrayList = New ArrayList()
            Dim arUsed50WrittingList2 As ArrayList = New ArrayList()
            Dim arUsed150WrittingList2 As ArrayList = New ArrayList()
            Dim arUsed70WrittingList2 As ArrayList = New ArrayList()       '【今回追加】

            arUsed30WrittingList.Clear()
            arUsed50WrittingList.Clear()
            arUsed150WrittingList.Clear()
            arUsed70WrittingList.Clear()                    '【今回追加】

            arUsed30WrittingList2.Clear()
            arUsed50WrittingList2.Clear()
            arUsed150WrittingList2.Clear()
            arUsed70WrittingList2.Clear()                   '【今回追加】

            PubConstClass.blnIsOneRound30Flg = False
            PubConstClass.blnIsOneRound50Flg = False
            PubConstClass.blnIsOneRound150Flg = False
            PubConstClass.blnIsOneRound70Flg = False        '【今回追加】
            Dim strArrayClass() As String

            Dim strMaxHikiukeKan() As String = PubConstClass.strEndNumber(0).Split(","c)        ' 簡易書留
            Dim strMaxHikiukeTok() As String = PubConstClass.strEndNumber(1).Split(","c)        ' 特定記録
            Dim strMaxHikiukeYou() As String = PubConstClass.strEndNumber(2).Split(","c)        ' ゆうメール簡易
            Dim strMaxHikiukeKakitome() As String = PubConstClass.strEndNumber(3).Split(","c)   '【今回追加】書留

            Dim subFolderArray(200) As String
            Dim subFolderIndex As Integer = 0
            Dim intOffset As Integer = 0

            ' 稼働ログファイル保存フォルダの存在チェック
            If System.IO.Directory.Exists(IncludeTrailingPathDelimiter(PubConstClass.imgPath)) = False Then
                OutPutLogFile("「" & IncludeTrailingPathDelimiter(PubConstClass.imgPath) & "」フォルダが存在しません。")
            Else

                For Each subFolders As String In System.IO.Directory.GetDirectories( _
                                PubConstClass.imgPath, "*", System.IO.SearchOption.TopDirectoryOnly)
                    subFolderArray(subFolderIndex) = subFolders
                    subFolderIndex += 1
                Next
                If subFolderIndex > 9 Then
                    intOffset = subFolderIndex - 10
                Else
                    intOffset = 0
                End If

                For N = intOffset To subFolderIndex - 1
                    OutPutLogFile("〓サブフォルダ一覧取得：" & subFolderArray(N))
                    For Each targetFile As String In System.IO.Directory.GetFiles(subFolderArray(N), "*.log")
                        Using sr As New System.IO.StreamReader(targetFile, System.Text.Encoding.Default)
                            Do While Not sr.EndOfStream
                                '    0,                           1,                 2,             3, 4,  5,                                                            6,           7,   8,           9,  0,   1,2
                                '00001,009：I 諸届センター 青（逆）,2015/11/26 9:22:54,358-91-98465-6,39,402,C:\RECDEL\IMG\20151126\092139\image_20151126_092252_00001.jpg,30：簡易書留,9756,東京諸届ｾﾝﾀｰ,284,定形,
                                strReadData = sr.ReadLine.ToString

                                'OutPutLogFile("strReadData:" & strReadData)

                                arrayUnderWrittingList = strReadData.Split(","c)
                                If arrayUnderWrittingList.Length > 7 Then
                                    strUsedWrittingNumber = arrayUnderWrittingList(3).Replace("-", "").Substring(0, 10)
                                    strArrayClass = arrayUnderWrittingList(7).Split("："c)
                                    If IsNumeric(strUsedWrittingNumber) = True And IsNumeric(strArrayClass(0)) = True Then
                                        ' 数値に変換できる値のみ追加する
                                        Select Case strArrayClass(0)
                                            '【簡易書留】
                                            Case "30", "40"
                                                If CDbl(strMaxHikiukeKan(1).Replace("-", "").Substring(0, 10)) <= CDbl(strUsedWrittingNumber) Then
                                                    PubConstClass.blnIsOneRound30Flg = True
                                                    arUsed30WrittingList.Add(strUsedWrittingNumber)
                                                Else
                                                    ' 引受番号が一周したかを判断し格納するアレイリストを判断する
                                                    If PubConstClass.blnIsOneRound30Flg = False Then
                                                        arUsed30WrittingList.Add(strUsedWrittingNumber)
                                                    Else
                                                        arUsed30WrittingList2.Add(strUsedWrittingNumber)
                                                    End If
                                                End If

                                            '【特定記録】
                                            Case "50", "60"
                                                If CDbl(strMaxHikiukeTok(1).Replace("-", "").Substring(0, 10)) <= CDbl(strUsedWrittingNumber) Then
                                                    PubConstClass.blnIsOneRound50Flg = True
                                                    arUsed50WrittingList.Add(strUsedWrittingNumber)
                                                Else
                                                    ' 引受番号が一周したかを判断し格納するアレイリストを判断する
                                                    If PubConstClass.blnIsOneRound50Flg = False Then
                                                        arUsed50WrittingList.Add(strUsedWrittingNumber)
                                                    Else
                                                        arUsed50WrittingList2.Add(strUsedWrittingNumber)
                                                    End If
                                                End If

                                            '【ゆうメール簡易】
                                            Case "150", "160"
                                                If CDbl(strMaxHikiukeYou(1).Replace("-", "").Substring(0, 10)) <= CDbl(strUsedWrittingNumber) Then
                                                    PubConstClass.blnIsOneRound150Flg = True
                                                    arUsed150WrittingList.Add(strUsedWrittingNumber)
                                                Else
                                                    ' 引受番号が一周したかを判断し格納するアレイリストを判断する
                                                    If PubConstClass.blnIsOneRound150Flg = False Then
                                                        arUsed150WrittingList.Add(strUsedWrittingNumber)
                                                    Else
                                                        arUsed150WrittingList2.Add(strUsedWrittingNumber)
                                                    End If
                                                End If

                                            '【書留】
                                            Case "70", "80", "90", "100"
                                            Case "75", "85", "95", "105"
                                                If CDbl(strMaxHikiukeKakitome(1).Replace("-", "").Substring(0, 10)) <= CDbl(strUsedWrittingNumber) Then
                                                    PubConstClass.blnIsOneRound70Flg = True
                                                    arUsed70WrittingList.Add(strUsedWrittingNumber)
                                                Else
                                                    ' 引受番号が一周したかを判断し格納するアレイリストを判断する
                                                    If PubConstClass.blnIsOneRound70Flg = False Then
                                                        arUsed70WrittingList.Add(strUsedWrittingNumber)
                                                    Else
                                                        arUsed70WrittingList2.Add(strUsedWrittingNumber)
                                                    End If
                                                End If

                                            Case Else
                                        End Select

                                    End If
                                End If
                            Loop
                        End Using
                    Next
                    'OutPutLogFile("〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓")
                Next

            End If

            arUsed30WrittingList.Sort()
            arUsed50WrittingList.Sort()
            arUsed150WrittingList.Sort()
            arUsed70WrittingList.Sort()         '【今回追加】

            arUsed30WrittingList2.Sort()
            arUsed50WrittingList2.Sort()
            arUsed150WrittingList2.Sort()
            arUsed70WrittingList2.Sort()        '【今回追加】

            If arUsed30WrittingList.Count > 0 Then
                For N = 0 To arUsed30WrittingList.Count - 1
                    'OutPutLogFile("簡易書留１【" & (N + 1).ToString("0000") & "】" & CLng(arUsed30WrittingList.Item(N)).ToString("000-00-00000") & "-" & (CLng(arUsed30WrittingList.Item(N)) Mod 7).ToString("0"))
                Next
                PubConstClass.pblUsed30FromUnderWrittingNumber = CLng(arUsed30WrittingList(0))
                PubConstClass.pblUsed30ToUnderWrittingNumber = CLng(arUsed30WrittingList(arUsed30WrittingList.Count - 1))
            End If

            If arUsed30WrittingList2.Count > 0 Then
                For N = 0 To arUsed30WrittingList2.Count - 1
                    'OutPutLogFile("簡易書留２【" & (N + 1).ToString("0000") & "】" & CLng(arUsed30WrittingList2.Item(N)).ToString("000-00-00000") & "-" & (CLng(arUsed30WrittingList2.Item(N)) Mod 7).ToString("0"))
                Next
                PubConstClass.pblUsed30FromUnderWrittingNumber2 = CLng(arUsed30WrittingList2(0))
                PubConstClass.pblUsed30ToUnderWrittingNumber2 = CLng(arUsed30WrittingList2(arUsed30WrittingList2.Count - 1))
            End If

            If arUsed50WrittingList.Count > 0 Then
                For N = 0 To arUsed50WrittingList.Count - 1
                    'OutPutLogFile("特定記録１【" & (N + 1).ToString("0000") & "】" & CLng(arUsed50WrittingList.Item(N)).ToString("000-00-00000") & "-" & (CLng(arUsed50WrittingList.Item(N)) Mod 7).ToString("0"))
                Next
                PubConstClass.pblUsed50FromUnderWrittingNumber = CLng(arUsed50WrittingList(0))
                PubConstClass.pblUsed50ToUnderWrittingNumber = CLng(arUsed50WrittingList(arUsed50WrittingList.Count - 1))
            End If

            If arUsed50WrittingList2.Count > 0 Then
                For N = 0 To arUsed50WrittingList2.Count - 1
                    'OutPutLogFile("特定記録２【" & (N + 1).ToString("0000") & "】" & CLng(arUsed50WrittingList2.Item(N)).ToString("000-00-00000") & "-" & (CLng(arUsed50WrittingList2.Item(N)) Mod 7).ToString("0"))
                Next
                PubConstClass.pblUsed50FromUnderWrittingNumber2 = CLng(arUsed50WrittingList2(0))
                PubConstClass.pblUsed50ToUnderWrittingNumber2 = CLng(arUsed50WrittingList2(arUsed50WrittingList2.Count - 1))
            End If


            If arUsed150WrittingList.Count > 0 Then
                For N = 0 To arUsed150WrittingList.Count - 1
                    'OutPutLogFile("ゆうメール１【" & (N + 1).ToString("0000") & "】" & CLng(arUsed150WrittingList.Item(N)).ToString("000-00-00000") & "-" & (CLng(arUsed150WrittingList.Item(N)) Mod 7).ToString("0"))
                Next
                PubConstClass.pblUsed150FromUnderWrittingNumber = CLng(arUsed150WrittingList(0))
                PubConstClass.pblUsed150ToUnderWrittingNumber = CLng(arUsed150WrittingList(arUsed150WrittingList.Count - 1))
            End If

            If arUsed150WrittingList2.Count > 0 Then
                For N = 0 To arUsed150WrittingList2.Count - 1
                    'OutPutLogFile("ゆうメール２【" & (N + 1).ToString("0000") & "】" & CLng(arUsed150WrittingList2.Item(N)).ToString("000-00-00000") & "-" & (CLng(arUsed150WrittingList2.Item(N)) Mod 7).ToString("0"))
                Next
                PubConstClass.pblUsed150FromUnderWrittingNumber2 = CLng(arUsed150WrittingList2(0))
                PubConstClass.pblUsed150ToUnderWrittingNumber2 = CLng(arUsed150WrittingList2(arUsed150WrittingList2.Count - 1))
            End If

            If arUsed70WrittingList.Count > 0 Then
                For N = 0 To arUsed70WrittingList.Count - 1
                    OutPutLogFile("書留１【" & (N + 1).ToString("0000") & "】" & CLng(arUsed70WrittingList.Item(N)).ToString("000-00-00000") & "-" & (CLng(arUsed70WrittingList.Item(N)) Mod 7).ToString("0"))
                Next
                PubConstClass.pblUsed70FromUnderWrittingNumber = CLng(arUsed70WrittingList(0))
                PubConstClass.pblUsed70ToUnderWrittingNumber = CLng(arUsed70WrittingList(arUsed70WrittingList.Count - 1))
            End If

            If arUsed70WrittingList2.Count > 0 Then
                For N = 0 To arUsed70WrittingList2.Count - 1
                    OutPutLogFile("書留２【" & (N + 1).ToString("0000") & "】" & CLng(arUsed70WrittingList2.Item(N)).ToString("000-00-00000") & "-" & (CLng(arUsed70WrittingList2.Item(N)) Mod 7).ToString("0"))
                Next
                PubConstClass.pblUsed70FromUnderWrittingNumber2 = CLng(arUsed70WrittingList2(0))
                PubConstClass.pblUsed70ToUnderWrittingNumber2 = CLng(arUsed70WrittingList2(arUsed70WrittingList2.Count - 1))
            End If

            Dim strMessage As String

            strMessage = "簡易書留１：" & Format(PubConstClass.pblUsed30FromUnderWrittingNumber, "000-00-00000") & "-" & _
                                          Format((PubConstClass.pblUsed30FromUnderWrittingNumber Mod 7).ToString("0"))
            strMessage = strMessage & " ～ " & Format(PubConstClass.pblUsed30ToUnderWrittingNumber, "000-00-00000") & "-" & _
                                               Format((PubConstClass.pblUsed30ToUnderWrittingNumber Mod 7).ToString("0"))
            OutPutLogFile(strMessage)

            strMessage = "簡易書留２：" & Format(PubConstClass.pblUsed30FromUnderWrittingNumber2, "000-00-00000") & "-" & _
                                          Format((PubConstClass.pblUsed30FromUnderWrittingNumber2 Mod 7).ToString("0"))
            strMessage = strMessage & " ～ " & Format(PubConstClass.pblUsed30ToUnderWrittingNumber2, "000-00-00000") & "-" & _
                                               Format((PubConstClass.pblUsed30ToUnderWrittingNumber2 Mod 7).ToString("0"))
            OutPutLogFile(strMessage)

            strMessage = "特定記録１：" & Format(PubConstClass.pblUsed50FromUnderWrittingNumber, "000-00-00000") & "-" & _
                                          Format((PubConstClass.pblUsed50FromUnderWrittingNumber Mod 7).ToString("0"))
            strMessage = strMessage & " ～ " & Format(PubConstClass.pblUsed50ToUnderWrittingNumber, "000-00-00000") & "-" & _
                                               Format((PubConstClass.pblUsed50ToUnderWrittingNumber Mod 7).ToString("0"))
            OutPutLogFile(strMessage)

            strMessage = "特定記録２：" & Format(PubConstClass.pblUsed50FromUnderWrittingNumber2, "000-00-00000") & "-" & _
                                          Format((PubConstClass.pblUsed50FromUnderWrittingNumber2 Mod 7).ToString("0"))
            strMessage = strMessage & " ～ " & Format(PubConstClass.pblUsed50ToUnderWrittingNumber2, "000-00-00000") & "-" & _
                                               Format((PubConstClass.pblUsed50ToUnderWrittingNumber2 Mod 7).ToString("0"))
            OutPutLogFile(strMessage)

            strMessage = "ゆうメール１：" & Format(PubConstClass.pblUsed150FromUnderWrittingNumber, "000-00-00000") & "-" & _
                                            Format((PubConstClass.pblUsed150FromUnderWrittingNumber Mod 7).ToString("0"))
            strMessage = strMessage & " ～ " & Format(PubConstClass.pblUsed150ToUnderWrittingNumber, "000-00-00000") & "-" & _
                                               Format((PubConstClass.pblUsed150ToUnderWrittingNumber Mod 7).ToString("0"))
            OutPutLogFile(strMessage)

            strMessage = "ゆうメール２：" & Format(PubConstClass.pblUsed150FromUnderWrittingNumber2, "000-00-00000") & "-" & _
                                            Format((PubConstClass.pblUsed150FromUnderWrittingNumber2 Mod 7).ToString("0"))
            strMessage = strMessage & " ～ " & Format(PubConstClass.pblUsed150ToUnderWrittingNumber2, "000-00-00000") & "-" & _
                                               Format((PubConstClass.pblUsed150ToUnderWrittingNumber2 Mod 7).ToString("0"))

            strMessage = "書留１：" & Format(PubConstClass.pblUsed70FromUnderWrittingNumber, "000-00-00000") & "-" &
                                            Format((PubConstClass.pblUsed70FromUnderWrittingNumber Mod 7).ToString("0"))
            strMessage = strMessage & " ～ " & Format(PubConstClass.pblUsed70ToUnderWrittingNumber, "000-00-00000") & "-" &
                                               Format((PubConstClass.pblUsed70ToUnderWrittingNumber Mod 7).ToString("0"))
            OutPutLogFile(strMessage)

            strMessage = "書留２：" & Format(PubConstClass.pblUsed70FromUnderWrittingNumber2, "000-00-00000") & "-" &
                                            Format((PubConstClass.pblUsed70FromUnderWrittingNumber2 Mod 7).ToString("0"))
            strMessage = strMessage & " ～ " & Format(PubConstClass.pblUsed70ToUnderWrittingNumber2, "000-00-00000") & "-" &
                                               Format((PubConstClass.pblUsed70ToUnderWrittingNumber2 Mod 7).ToString("0"))

            OutPutLogFile(strMessage)

            arUsed30WrittingList.Clear()
            arUsed50WrittingList.Clear()
            arUsed150WrittingList.Clear()
            arUsed70WrittingList.Clear()    '【今回追加】

            arUsed30WrittingList2.Clear()
            arUsed50WrittingList2.Clear()
            arUsed150WrittingList2.Clear()
            arUsed70WrittingList2.Clear()   '【今回追加】

        Catch ex As Exception
            MsgBox("【GetUsedUnderWritingNumber】" & ex.Message + Environment.NewLine + ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' 保存する月数より古いフォルダ及びファイルを削除する
    ''' （１）画像ファイル保存フォルダ
    ''' （２）稼働ファイル
    ''' （３）操作履歴ログファイル
    ''' </summary>
    ''' <param name="intMinusMonth">保存する月数</param>
    ''' <remarks></remarks>
    Public Sub DeleteLogFiles(ByVal intMinusMonth As Integer)

        Dim strArray() As String
        Dim strCompDate As String

        Try
            ' 現在の日付（年月日）を求める
            Dim dtCurrent As DateTime = DateTime.Now

            ' 現在日付から指定月を減算
            Dim dtPassDate As DateTime = dtCurrent.AddMonths(-(intMinusMonth))

            'Dim retVal As MsgBoxResult = MsgBox("現在の日付から" & (intMinusMonth).ToString & "ヶ月前は、" & dtPassDate, _
            '       CType(MsgBoxStyle.Information + MsgBoxStyle.OkCancel, MsgBoxStyle), _
            '       "【確認】")
            'If retVal = MsgBoxResult.Cancel Then
            '    Exit Sub
            'End If

            '（１）画像ファイル保存フォルダの削除
            If System.IO.Directory.Exists(IncludeTrailingPathDelimiter(PubConstClass.imgPath)) = False Then
                OutPutLogFile("「" & IncludeTrailingPathDelimiter(PubConstClass.imgPath) & "」フォルダが存在しません。")
            Else
                ' 削除対象フォルダ（指定したフォルダのトップフォルダのみ）の取得
                For Each subFolders As String In System.IO.Directory.GetDirectories( _
                                                PubConstClass.imgPath, "*", System.IO.SearchOption.TopDirectoryOnly)

                    'OutPutLogFile("サブフォルダ一覧取得：" & subFolders)
                    strArray = subFolders.Split("\"c)

                    If strArray.Length > 1 Then
                        ' 「YYYYMMDD」部分を切り出す
                        strCompDate = strArray(strArray.Length - 1)
                        If strCompDate < dtPassDate.ToString("yyyyMMdd") Then
                            ' フォルダを削除する（サブフォルダも無条件に）
                            System.IO.Directory.Delete(subFolders, True)
                            OutPutLogFile("【稼動ログ】削除対象フォルダ（" & subFolders & "）を削除しました。")
                        End If
                    End If
                Next
            End If

            '（２）運用記録ログファイル（運用記録ログ_20150901.LOG）
            If System.IO.Directory.Exists(IncludeTrailingPathDelimiter(PubConstClass.tranPath)) = False Then
                OutPutLogFile("「" & IncludeTrailingPathDelimiter(PubConstClass.tranPath) & "」フォルダが存在しません。")
            Else
                For Each strDeleteFile As String In System.IO.Directory.GetFiles( _
                                        IncludeTrailingPathDelimiter(PubConstClass.tranPath), _
                                        "*.LOG", System.IO.SearchOption.AllDirectories)

                    'OutPutLogFile("運用記録ログファイル一覧取得：" & strDeleteFile)
                    strArray = strDeleteFile.Split("\"c)

                    If strArray(strArray.Length - 1).Length > 12 Then
                        ' 「YYYYMMDD」部分を切り出す
                        strCompDate = strArray(strArray.Length - 1).Substring(strArray(strArray.Length - 1).Length - 12, 8)
                        If strCompDate < dtPassDate.ToString("yyyyMMdd") Then
                            ' ファイルを削除する
                            System.IO.File.Delete(strDeleteFile)
                            OutPutLogFile("【運用記録ログ／通信ログ】削除対象ファイル（" & strDeleteFile & "）を削除しました。")
                        End If
                    End If
                Next
            End If

            '（３）操作履歴ログファイル（操作履歴ログ_20150901.LOG）
            ' 削除対象ファイル（操作履歴ログ）の取得
            For Each strDeleteFile As String In System.IO.Directory.GetFiles( _
                                    IncludeTrailingPathDelimiter(Application.StartupPath) & "OPHISTORYLOG\", _
                                    "*.LOG", System.IO.SearchOption.AllDirectories)

                'OutPutLogFile("操作履歴ログファイル一覧取得：" & strDeleteFile)
                strArray = strDeleteFile.Split("\"c)

                If strArray(strArray.Length - 1).Length > 12 Then
                    ' 「YYYYMMDD」部分を切り出す
                    strCompDate = strArray(strArray.Length - 1).Substring(strArray(strArray.Length - 1).Length - 12, 8)
                    If strCompDate < dtPassDate.ToString("yyyyMMdd") Then
                        ' ファイルを削除する
                        System.IO.File.Delete(strDeleteFile)
                        OutPutLogFile("【操作履歴ログ】削除対象ファイル（" & strDeleteFile & "）を削除しました。")
                    End If
                End If

            Next

            OutPutLogFile("削除処理が完了しました。")

        Catch ex As Exception
            MsgBox("【DeleteLogFiles】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 引受番号のスタート番号を取得する
    ''' </summary>
    ''' <param name="strClass"></param>
    ''' <remarks></remarks>
    Public Sub GetStartUnderWritingNumber(ByVal strClass As String)

        Dim strArray() As String
        Dim strCmp1Array() As String
        Dim strCmp2Array() As String

        '30：簡易書留
        '40：簡易書留速達
        '50：特定記録
        '60：特定記録速達
        '150：ゆうメール(簡易書留)
        '160：ゆうメール（簡易書留）速達
        '70：書留
        '80：書留速達
        '90：配達証明
        '100：配達証明速達
        '75：書留（本人限定）
        '85：書留速達（本人限定）
        '95：配達証明（本人限定）
        '105：配達証明速達（本人限定）

        Try
            strCmp1Array = strClass.Split("："c)
            If strCmp1Array(0) = "40" Then
                ' 「40」は「30」と同じ扱いとする
                strCmp1Array(0) = "30"
            ElseIf strCmp1Array(0) = "60" Then
                ' 「60」は「50」と同じ扱いとする
                strCmp1Array(0) = "50"
            ElseIf strCmp1Array(0) = "160" Then
                ' 「160」は「150」と同じ扱いとする
                strCmp1Array(0) = "150"
            ElseIf strCmp1Array(0) = "80" Or strCmp1Array(0) = "90" Or strCmp1Array(0) = "100" Then
                ' 「80」「90」「100」は「70」と同じ扱いとする
                strCmp1Array(0) = "70"
            ElseIf strCmp1Array(0) = "75" Or strCmp1Array(0) = "85" Or strCmp1Array(0) = "95" Or strCmp1Array(0) = "105" Then
                ' 「75」「85」「95」「105」は「70」と同じ扱いとする
                strCmp1Array(0) = "70"
            End If

            For N = 0 To 3
                strCmp2Array = PubConstClass.strNumberInfo(N).Split(","c)

                If CInt(strCmp1Array(0)) = CInt(strCmp2Array(0)) Then

                    ' 運転時の引受番号（10桁でC/D含まず）
                    strArray = PubConstClass.strCurrentNumber(N).Split(","c)
                    PubConstClass.dblStartUnderWritingNumber = CDbl(strArray(1).Replace("-", "").Substring(0, 10))
                    'Debug_Print("運転時の引受番号：" & PubConstClass.dblStartUnderWritingNumber.ToString("000-00-00000") & "-" & (PubConstClass.dblStartUnderWritingNumber Mod 7).ToString("0"))

                    ' 開始番号（10桁でC/D含まず）
                    strArray = PubConstClass.strStartNumber(N).Split(","c)
                    PubConstClass.dblFirstUnderWritingNumber = CDbl(strArray(1).Replace("-", "").Substring(0, 10))
                    'Debug_Print("設定開始番号：" & PubConstClass.dblFirstUnderWritingNumber.ToString("000-00-00000") & "-" & (PubConstClass.dblFirstUnderWritingNumber Mod 7).ToString("0"))

                    ' 終了番号（10桁でC/D含まず）
                    strArray = PubConstClass.strEndNumber(N).Split(","c)
                    PubConstClass.dblEndUnderWritingNumber = CDbl(strArray(1).Replace("-", "").Substring(0, 10))
                    'Debug_Print("設定終了番号：" & PubConstClass.dblEndUnderWritingNumber.ToString("000-00-00000") & "-" & (PubConstClass.dblEndUnderWritingNumber Mod 7).ToString("0"))

                End If
            Next

        Catch ex As Exception
            MsgBox("【GetStartUnderWritingNumber】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 「通数」と「合計金額」と「通数の合計」と「合計金額の合計」を求める
    ''' </summary>
    ''' <param name="arReadData">対象ファイルの内容を格納したアレイリスト</param>
    ''' <remarks>指定されたアレイリストから「通数」と「合計金額」と「通数の合計」と「合計金額の合計」を求める</remarks>
    Public Sub GetTranCntAndAmount(ByVal arReadData As ArrayList)

        Dim strChkData As String
        Dim strTeikei As String         ' 「0：定形／1:定形外」変数
        Dim strArray() As String
        Dim strPutData As String        ' 出力用データ格納変数

        Try
            ' (0) = "No"
            ' (1) = "業務名称"
            ' (2) = "取得時間"
            ' (3) = "引受番号"
            ' (4) = "重量"
            ' (5) = "料金"
            ' (6) = "ファイル名称"
            ' (7) = "種別"
            ' (8) = "支店コード"
            ' (9) = "支店名"
            '(10) = "処理予定通数"
            '(11) = "定形／定形外"

            PubConstClass.intTranALLCnt = 0
            PubConstClass.intAmountALL = 0
            For N = 0 To PubConstClass.strTranCnt.Length - 1
                PubConstClass.strTranCnt(N) = "0"     ' 通数格納配列クリア（定形）
                PubConstClass.strAmount(N) = "0"      ' 合計金額格納配列クリア（定形）
            Next
            For N = 0 To PubConstClass.strTranCntGai.Length - 1
                PubConstClass.strTranCntGai(N) = "0"  ' 通数格納配列クリア（定形外／規格内）
                PubConstClass.strAmountGai(N) = "0"   ' 合計金額格納配列クリア（定形外／規格内）
            Next
            For N = 0 To PubConstClass.strTranCntNonS.Length - 1
                PubConstClass.strTranCntNonS(N) = "0" ' 通数格納配列クリア（定形外／規格外）
                PubConstClass.strAmountNonS(N) = "0"  ' 合計金額格納配列クリア（定形外／規格外）
            Next

            strArray = arReadData(0).ToString.Split(","c)
            Dim strSyubetu As String = strArray(7)
            Dim strSitenCode As String = strArray(8)
            Dim strSitenName As String = strArray(9)

            '    0,                                  1,                  2,             3,  4,  5,                                                            6,           7,      8,       9  10,  11,
            '00001,001：簡易書留郵便（定型ラベル右上）,2015/07/28 19:44:18,358-19-00001-1,894,910,C:\RECDEL\IMG\20150728\194347\image_20150728_194418_00001.jpg,30：簡易書留,0234-00,蟹江支店,234,定形,
            For Each ar In arReadData
                strArray = ar.ToString.Split(","c)

                ' 抜取データは対象としない
                If strArray(12) <> "■" Then
                    ' 重量を取得する
                    strChkData = strArray(4)
                    ' 「定形／定形外」を取得する
                    If strArray(11) = "定形" Then
                        strTeikei = "0"     ' 定形
                    ElseIf strArray(11) = "定形外(規格内)" Then
                        strTeikei = "1"     ' 定形外(規格内)
                    ElseIf strArray(11) = "定形外(規格外)" Then
                        strTeikei = "2"     ' 定形外(規格外)
                    Else
                        strTeikei = "1"     ' 定形外(規格内)
                    End If
                    ' 重量から通数をカウントアップし合計金額を求める
                    GetTranCntFromWeight(strChkData, strTeikei)
                End If

            Next

            '// for DEBUG↓ここから
            For N = 0 To PubConstClass.strTranCnt.Length - 1
                OutPutLogFile("■strTranCnt(" & N & ")=" & PubConstClass.strTranCnt(N) & "／strAmount(" & N & ")=" & PubConstClass.strAmount(N))
            Next
            For N = 0 To PubConstClass.strTranCntGai.Length - 1
                OutPutLogFile("〓strTranCntGai(" & N & ")=" & PubConstClass.strTranCntGai(N) & "／strAmountGai(" & N & ")=" & PubConstClass.strAmountGai(N))
            Next
            For N = 0 To PubConstClass.strTranCntNonS.Length - 1
                OutPutLogFile("★strTranCntNonS(" & N & ")=" & PubConstClass.strTranCntNonS(N) & "／strAmountNonS(" & N & ")=" & PubConstClass.strAmountNonS(N))
            Next
            '// for DEBUG↑ここまで

            For N = 0 To PubConstClass.strTranCnt.Length - 1
                ' 通数の合計を求める（定形）
                PubConstClass.intTranALLCnt += CInt(PubConstClass.strTranCnt(N))
                ' 合計金額の合計を求める（定形）
                PubConstClass.intAmountALL += CInt(PubConstClass.strAmount(N))
            Next
            For N = 0 To PubConstClass.strTranCntGai.Length - 1
                ' 通数の合計を求める（定形外／規格内）
                PubConstClass.intTranALLCnt += CInt(PubConstClass.strTranCntGai(N))
                ' 合計金額の合計を求める（定形外／規格内）
                PubConstClass.intAmountALL += CInt(PubConstClass.strAmountGai(N))
            Next
            For N = 0 To PubConstClass.strTranCntNonS.Length - 1
                ' 通数の合計を求める（定形外／規格外）
                PubConstClass.intTranALLCnt += CInt(PubConstClass.strTranCntNonS(N))
                ' 合計金額の合計を求める（定形外／規格外）
                PubConstClass.intAmountALL += CInt(PubConstClass.strAmountNonS(N))
            Next

            '// 定形
            For N = 0 To PubConstClass.strTranCnt.Length - 1
                If PubConstClass.strTranCnt(N) = "0" Or PubConstClass.strTranCnt(N) = "" Then
                    '// 出力しない
                Else
                    strPutData = strSyubetu & "," & _
                                  strSitenCode & "," & _
                                  strSitenName & "," & _
                                  PubConstClass.strWeightArray(N) & "," & _
                                  PubConstClass.strPriceArray(N) & "," & _
                                  PubConstClass.strTranCnt(N) & "," & _
                                  PubConstClass.strAmount(N) & ",定"
                    ' 操作履歴ログに格納
                    OutPutLogFile("■定形：" & strPutData)
                    ' 印字用アレイリストに追加
                    PubConstClass.arPrePrintData.Add(strPutData)
                End If
            Next
            '// 定形外(規格内)
            For N = 0 To PubConstClass.strTranCntGai.Length - 1
                If PubConstClass.strTranCntGai(N) = "0" Or PubConstClass.strTranCntGai(N) = "" Then
                    '// 出力しない
                Else
                    strPutData = strSyubetu & "," & _
                                  strSitenCode & "," & _
                                  strSitenName & "," & _
                                  PubConstClass.strWeightGaiArray(N) & "," & _
                                  PubConstClass.strPriceGaiArray(N) & "," & _
                                  PubConstClass.strTranCntGai(N) & "," & _
                                  PubConstClass.strAmountGai(N) & ",○"
                    ' 操作履歴ログに格納
                    OutPutLogFile("〓定形外（規格内）：" & strPutData)
                    ' 印字用アレイリストに追加
                    PubConstClass.arPrePrintData.Add(strPutData)
                End If
            Next
            '// 定形外(規格外)
            For N = 0 To PubConstClass.strTranCntNonS.Length - 1
                If PubConstClass.strTranCntNonS(N) = "0" Or PubConstClass.strTranCntNonS(N) = "" Then
                    '// 出力しない
                Else
                    strPutData = strSyubetu & "," & _
                                  strSitenCode & "," & _
                                  strSitenName & "," & _
                                  PubConstClass.strWeightNonSArray(N) & "," & _
                                  PubConstClass.strPriceNonSArray(N) & "," & _
                                  PubConstClass.strTranCntNonS(N) & "," & _
                                  PubConstClass.strAmountNonS(N) & ",●"
                    ' 操作履歴ログに格納
                    OutPutLogFile("★定形外（規格外）：" & strPutData)
                    ' 印字用アレイリストに追加
                    PubConstClass.arPrePrintData.Add(strPutData)
                End If
            Next

            strPutData = strSyubetu & ",,,,小計," & PubConstClass.intTranALLCnt & "," & PubConstClass.intAmountALL
            ' 操作履歴ログに格納
            OutPutLogFile(strPutData)

            If PubConstClass.intTranALLCnt = 0 And PubConstClass.intAmountALL = 0 Then
                ' 操作履歴ログに格納
                OutPutLogFile("小計が「0」の場合は、印字用アレイリスト（arPrePrintData）には追加しない。")
            Else
                ' 印字用アレイリストに追加
                PubConstClass.arPrePrintData.Add(strPutData)
            End If

        Catch ex As Exception
            MsgBox("【GetTranCntAndAmount】" & ex.Message)
        End Try

    End Sub


    ''' <summary>
    ''' 重量から通数をカウントアップする
    ''' </summary>
    ''' <param name="strWeight">重量</param>
    ''' <param name="strTeikei">0：定形／1：定形外(規格内)／2：定形外(規格外)</param>
    ''' <remarks></remarks>
    Private Sub GetTranCntFromWeight(ByVal strWeight As String, ByVal strTeikei As String)


        Dim strRetVal As String = "Error"
        Dim intWeight As Integer = CInt(strWeight)

        Try

            If strTeikei = "0" Then
                ' 定形
                If intWeight <= CInt(PubConstClass.strWeightArray(0)) Then
                    PubConstClass.strTranCnt(0) = (CInt(PubConstClass.strTranCnt(0)) + 1).ToString("0")
                    PubConstClass.strAmount(0) = (CInt(PubConstClass.strTranCnt(0)) * CInt(PubConstClass.strPriceArray(0))).ToString("0")

                ElseIf intWeight <= CInt(PubConstClass.strWeightArray(1)) Then
                    PubConstClass.strTranCnt(1) = (CInt(PubConstClass.strTranCnt(1)) + 1).ToString("0")
                    PubConstClass.strAmount(1) = (CInt(PubConstClass.strTranCnt(1)) * CInt(PubConstClass.strPriceArray(1))).ToString("0")

                ElseIf intWeight <= CInt(PubConstClass.strWeightArray(2)) Then
                    PubConstClass.strTranCnt(2) = (CInt(PubConstClass.strTranCnt(2)) + 1).ToString("0")
                    PubConstClass.strAmount(2) = (CInt(PubConstClass.strTranCnt(2)) * CInt(PubConstClass.strPriceArray(2))).ToString("0")

                ElseIf intWeight <= CInt(PubConstClass.strWeightArray(3)) Then
                    PubConstClass.strTranCnt(3) = (CInt(PubConstClass.strTranCnt(3)) + 1).ToString("0")
                    PubConstClass.strAmount(3) = (CInt(PubConstClass.strTranCnt(3)) * CInt(PubConstClass.strPriceArray(3))).ToString("0")

                ElseIf intWeight <= CInt(PubConstClass.strWeightArray(4)) Then
                    PubConstClass.strTranCnt(4) = (CInt(PubConstClass.strTranCnt(4)) + 1).ToString("0")
                    PubConstClass.strAmount(4) = (CInt(PubConstClass.strTranCnt(4)) * CInt(PubConstClass.strPriceArray(4))).ToString("0")

                ElseIf intWeight <= CInt(PubConstClass.strWeightArray(5)) Then
                    PubConstClass.strTranCnt(5) = (CInt(PubConstClass.strTranCnt(5)) + 1).ToString("0")
                    PubConstClass.strAmount(5) = (CInt(PubConstClass.strTranCnt(5)) * CInt(PubConstClass.strPriceArray(5))).ToString("0")

                ElseIf intWeight <= CInt(PubConstClass.strWeightArray(6)) Then
                    PubConstClass.strTranCnt(6) = (CInt(PubConstClass.strTranCnt(6)) + 1).ToString("0")
                    PubConstClass.strAmount(6) = (CInt(PubConstClass.strTranCnt(6)) * CInt(PubConstClass.strPriceArray(6))).ToString("0")

                ElseIf intWeight <= CInt(PubConstClass.strWeightArray(7)) Then
                    PubConstClass.strTranCnt(7) = (CInt(PubConstClass.strTranCnt(7)) + 1).ToString("0")
                    PubConstClass.strAmount(7) = (CInt(PubConstClass.strTranCnt(7)) * CInt(PubConstClass.strPriceArray(7))).ToString("0")

                ElseIf intWeight <= CInt(PubConstClass.strWeightArray(8)) Then
                    PubConstClass.strTranCnt(8) = (CInt(PubConstClass.strTranCnt(8)) + 1).ToString("0")
                    PubConstClass.strAmount(8) = (CInt(PubConstClass.strTranCnt(8)) * CInt(PubConstClass.strPriceArray(8))).ToString("0")
                Else
                    strRetVal = "定形？"
                End If

            ElseIf strTeikei = "1" Then
                '// 定形外(規格内)
                If intWeight <= CInt(PubConstClass.strWeightGaiArray(0)) Then
                    PubConstClass.strTranCntGai(0) = (CInt(PubConstClass.strTranCntGai(0)) + 1).ToString("0")
                    PubConstClass.strAmountGai(0) = (CInt(PubConstClass.strTranCntGai(0)) * CInt(PubConstClass.strPriceGaiArray(0))).ToString("0")

                ElseIf intWeight <= CInt(PubConstClass.strWeightGaiArray(1)) Then
                    PubConstClass.strTranCntGai(1) = (CInt(PubConstClass.strTranCntGai(1)) + 1).ToString("0")
                    PubConstClass.strAmountGai(1) = (CInt(PubConstClass.strTranCntGai(1)) * CInt(PubConstClass.strPriceGaiArray(1))).ToString("0")

                ElseIf intWeight <= CInt(PubConstClass.strWeightGaiArray(2)) Then
                    PubConstClass.strTranCntGai(2) = (CInt(PubConstClass.strTranCntGai(2)) + 1).ToString("0")
                    PubConstClass.strAmountGai(2) = (CInt(PubConstClass.strTranCntGai(2)) * CInt(PubConstClass.strPriceGaiArray(2))).ToString("0")

                ElseIf intWeight <= CInt(PubConstClass.strWeightGaiArray(3)) Then
                    PubConstClass.strTranCntGai(3) = (CInt(PubConstClass.strTranCntGai(3)) + 1).ToString("0")
                    PubConstClass.strAmountGai(3) = (CInt(PubConstClass.strTranCntGai(3)) * CInt(PubConstClass.strPriceGaiArray(3))).ToString("0")

                ElseIf intWeight <= CInt(PubConstClass.strWeightGaiArray(4)) Then
                    PubConstClass.strTranCntGai(4) = (CInt(PubConstClass.strTranCntGai(4)) + 1).ToString("0")
                    PubConstClass.strAmountGai(4) = (CInt(PubConstClass.strTranCntGai(4)) * CInt(PubConstClass.strPriceGaiArray(4))).ToString("0")

                ElseIf intWeight <= CInt(PubConstClass.strWeightGaiArray(5)) Then
                    PubConstClass.strTranCntGai(5) = (CInt(PubConstClass.strTranCntGai(5)) + 1).ToString("0")
                    PubConstClass.strAmountGai(5) = (CInt(PubConstClass.strTranCntGai(5)) * CInt(PubConstClass.strPriceGaiArray(5))).ToString("0")

                ElseIf intWeight <= CInt(PubConstClass.strWeightGaiArray(6)) Then
                    PubConstClass.strTranCntGai(6) = (CInt(PubConstClass.strTranCntGai(6)) + 1).ToString("0")
                    PubConstClass.strAmountGai(6) = (CInt(PubConstClass.strTranCntGai(6)) * CInt(PubConstClass.strPriceGaiArray(6))).ToString("0")

                ElseIf intWeight <= CInt(PubConstClass.strWeightGaiArray(7)) Then
                    PubConstClass.strTranCntGai(7) = (CInt(PubConstClass.strTranCntGai(7)) + 1).ToString("0")
                    PubConstClass.strAmountGai(7) = (CInt(PubConstClass.strTranCntGai(7)) * CInt(PubConstClass.strPriceGaiArray(7))).ToString("0")
                Else
                    strRetVal = "定形外(規格内)？"
                End If

            Else
                '// 定形外(規格外)
                If intWeight <= CInt(PubConstClass.strWeightNonSArray(0)) Then
                    PubConstClass.strTranCntNonS(0) = (CInt(PubConstClass.strTranCntNonS(0)) + 1).ToString("0")
                    PubConstClass.strAmountNonS(0) = (CInt(PubConstClass.strTranCntNonS(0)) * CInt(PubConstClass.strPriceNonSArray(0))).ToString("0")

                ElseIf intWeight <= CInt(PubConstClass.strWeightNonSArray(1)) Then
                    PubConstClass.strTranCntNonS(1) = (CInt(PubConstClass.strTranCntNonS(1)) + 1).ToString("0")
                    PubConstClass.strAmountNonS(1) = (CInt(PubConstClass.strTranCntNonS(1)) * CInt(PubConstClass.strPriceNonSArray(1))).ToString("0")

                ElseIf intWeight <= CInt(PubConstClass.strWeightNonSArray(2)) Then
                    PubConstClass.strTranCntNonS(2) = (CInt(PubConstClass.strTranCntNonS(2)) + 1).ToString("0")
                    PubConstClass.strAmountNonS(2) = (CInt(PubConstClass.strTranCntNonS(2)) * CInt(PubConstClass.strPriceNonSArray(2))).ToString("0")

                ElseIf intWeight <= CInt(PubConstClass.strWeightNonSArray(3)) Then
                    PubConstClass.strTranCntNonS(3) = (CInt(PubConstClass.strTranCntNonS(3)) + 1).ToString("0")
                    PubConstClass.strAmountNonS(3) = (CInt(PubConstClass.strTranCntNonS(3)) * CInt(PubConstClass.strPriceNonSArray(3))).ToString("0")

                ElseIf intWeight <= CInt(PubConstClass.strWeightNonSArray(4)) Then
                    PubConstClass.strTranCntNonS(4) = (CInt(PubConstClass.strTranCntNonS(4)) + 1).ToString("0")
                    PubConstClass.strAmountNonS(4) = (CInt(PubConstClass.strTranCntNonS(4)) * CInt(PubConstClass.strPriceNonSArray(4))).ToString("0")

                ElseIf intWeight <= CInt(PubConstClass.strWeightNonSArray(5)) Then
                    PubConstClass.strTranCntNonS(5) = (CInt(PubConstClass.strTranCntNonS(5)) + 1).ToString("0")
                    PubConstClass.strAmountNonS(5) = (CInt(PubConstClass.strTranCntNonS(5)) * CInt(PubConstClass.strPriceNonSArray(5))).ToString("0")

                ElseIf intWeight <= CInt(PubConstClass.strWeightNonSArray(6)) Then
                    PubConstClass.strTranCntNonS(6) = (CInt(PubConstClass.strTranCntNonS(6)) + 1).ToString("0")
                    PubConstClass.strAmountNonS(6) = (CInt(PubConstClass.strTranCntNonS(6)) * CInt(PubConstClass.strPriceNonSArray(6))).ToString("0")

                ElseIf intWeight <= CInt(PubConstClass.strWeightNonSArray(7)) Then
                    PubConstClass.strTranCntNonS(7) = (CInt(PubConstClass.strTranCntNonS(7)) + 1).ToString("0")
                    PubConstClass.strAmountNonS(7) = (CInt(PubConstClass.strTranCntNonS(7)) * CInt(PubConstClass.strPriceNonSArray(7))).ToString("0")
                Else
                    strRetVal = "定形外(規格外)？"
                End If

            End If

        Catch ex As Exception
            MsgBox("【GetTranCntFromWeight】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 種別グループファイルの読込み
    ''' </summary>
    Public Sub GetClassGroupFile()

        Dim sReadDataPath As String
        'Dim sClassGroupList As New List(Of String)()
        Dim sArray() As String
        Dim sPreviousValue As String
        Dim sData As String

        Try
            PubConstClass.sClassGroupList.Clear()
            sPreviousValue = ""
            sData = ""

            sReadDataPath = IncludeTrailingPathDelimiter(Application.StartupPath) & "ClassGroupFile.ini"
            Using sr As New StreamReader(sReadDataPath, Encoding.Default)
                Do While Not sr.EndOfStream
                    sArray = sr.ReadLine.ToString.Split(","c)
                    If sPreviousValue = "" Then
                        ' 最初のデータの処理
                        sPreviousValue = sArray(0).Trim()
                        sData = $"{sArray(0).Trim()},{sArray(1).Trim()}"
                    Else
                        If sPreviousValue = sArray(0).Trim() Then
                            ' 同じ種別コードの場合、データを連結する
                            sData &= $",{sArray(1).Trim()}"
                        Else
                            ' 異なる種別コードの場合、リストに追加し、新しいデータを開始する
                            PubConstClass.sClassGroupList.Add(sData)
                            sPreviousValue = sArray(0).Trim()
                            sData = $"{sArray(0).Trim()},{sArray(1).Trim()}"
                            OutPutLogFile($"■PubConstClass.sClassGroupList({PubConstClass.sClassGroupList.Count - 1})={PubConstClass.sClassGroupList(PubConstClass.sClassGroupList.Count - 1)}")
                        End If
                    End If
                Loop
                ' 最後のデータを格納する
                PubConstClass.sClassGroupList.Add(sData)
                OutPutLogFile($"■sClassGroupList({PubConstClass.sClassGroupList.Count - 1})={PubConstClass.sClassGroupList(PubConstClass.sClassGroupList.Count - 1)}")
            End Using

            ' 操作ログの書き込み
            OutPutLogFile("■読込エラーメッセージ数：" & PubConstClass.intErrCnt.ToString)

        Catch ex As Exception
            MsgBox("【GetClassGroupFile】" & ex.Message)
        End Try

    End Sub

    Public Sub SetComboBoxForClassFile(cmbClassFilter As ComboBox)
        Try
            ' 種別ファイルフィルターの設定
            Dim sAray() As String
            cmbClassFilter.Items.Clear()
            For Each sData In PubConstClass.sClassGroupList
                sAray = sData.Split(","c)
                cmbClassFilter.Items.Add(sAray(0))
            Next
            'cmbClassFilter.SelectedIndex = 0

        Catch ex As Exception
            MsgBox("【SetComboBoxForClassFile】" & ex.Message)
        End Try
    End Sub

End Module
