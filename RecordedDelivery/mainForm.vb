Option Explicit On
Option Strict On

Public Class MainForm

    Inherits System.Windows.Forms.Form

    Public blnEndFlag As Boolean
    Private intIconNumber As Integer
    Private iCallScreenType As Integer

    ''' <summary>
    ''' 「終了」ボタン処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnEnd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnd.Click

        blnEndFlag = False
        OutPutLogFile("〓「終了画面」呼び出し〓")
        ' 運用記録ログ格納
        Call OutPutUseLogFile(LblOperatorName.Text & ":「終了画面」呼び出し")

        EndForm.ShowDialog()
        If blnEndFlag = True Then
            Me.Dispose()
            End
        End If

    End Sub

    ''' <summary>
    ''' 「×」ボタンのキャンセル
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub mainForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        ' 「×」ボタンのキャンセル
        e.Cancel = True

    End Sub

    ' ファンクションキーの処理
    Private Sub mainForm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        Select Case e.KeyCode
            Case Keys.F1
                ' ジョブ選択画面の表示
                'btnJobSelect.PerformClick()

            Case Keys.F2

            Case Keys.F3
                ' '' ログ管理画面の表示
                ''btnLogManage.PerformClick()

            Case Keys.F12
                ' 終了画面の表示
                'btnEnd.PerformClick()

            Case Else
        End Select

    End Sub

    ''' <summary>
    ''' フォームロード処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub mainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            'PubConstClass.objSyncHist = New Object  ' 操作履歴書込み用
            'PubConstClass.objSyncRec = New Object   ' メンテナンス画面用

            ' 操作ログの書き込み
            'OutPutLogFile("〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓")
            OutPutLogFile($"【メインメニュー表示】（{PubConstClass.pblOperatorCode}：{PubConstClass.pblOperatorName}）")

            '二重起動のチェック
            If Diagnostics.Process.GetProcessesByName(
                Diagnostics.Process.GetCurrentProcess.ProcessName).Length > 1 Then
                'すでに起動していると判断する
                OutPutLogFile("二重起動はできません。")
                MsgBox("二重起動はできません。", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")
                Me.Dispose()
            End If

            lblVersion.Text = PubConstClass.DEF_VERSION

            timIconTimer.Interval = 300
            timIconTimer.Enabled = True
            intIconNumber = 1

            'Dim strReadDataENCPath As String = IncludeTrailingPathDelimiter(Application.StartupPath) & PubConstClass.DEF_OPERATOR_FILE_NAME_ENC
            'Dim strReadDataINIPath As String = IncludeTrailingPathDelimiter(Application.StartupPath) & PubConstClass.DEF_OPERATOR_FILE_NAME_INI
            '' オペレータ情報ファイル（INI）を暗号化する
            'EncryptFile(strReadDataINIPath, strReadDataENCPath, PubConstClass.DEF_OPEN_KEY)

            'Dim strReadDataENCPath As String = IncludeTrailingPathDelimiter(Application.StartupPath) & PubConstClass.DEF_OPERATOR_FILE_NAME_ENC
            'Dim strReadDataINIPath As String = IncludeTrailingPathDelimiter(Application.StartupPath) & PubConstClass.DEF_OPERATOR_FILE_NAME_INI
            '' オペレータ情報ファイル（INI）を復号化する
            'DecryptFile(strReadDataENCPath, strReadDataINIPath, PubConstClass.DEF_OPEN_KEY)

            'PubConstClass.intTodayALLCount = 0           ' 当日累計
            'PubConstClass.intKaniALLCount = 0            ' 簡易書留累計
            'PubConstClass.intTokuALLCount = 0            ' 特定郵便累計
            'PubConstClass.intMailALLCount = 0            ' ゆうメール累計


#Region "ログイン画面で呼び出すように変更"
            '' エラー情報の取得
            'Call getErrorInformation()
            '' 支店マスター情報の取得
            'Call GetBranchMasterFile()
            '' 種別データ情報の取得
            'Call GetClassDataFile()
            '' 引受番号データ取得処理
            'Call GetUnderWritingNumber()
            '' INIファイルから設定値を取得する
            'Call getSystemIniFile()
#End Region

            Dim strIniFilePath As String = IncludeTrailingPathDelimiter(Application.StartupPath) & PubConstClass.DEF_INI_FILENAME
            ' 作業日
            PubConstClass.strWorkDay = myGetPrivateProfileString("Counter", "WorkDay", "0", strIniFilePath)
            ' 当日累計
            PubConstClass.intTodayALLCount = CInt(myGetPrivateProfileString("Counter", "TodayAllCount", "0", strIniFilePath))
            ' 簡易書留累計
            PubConstClass.intKaniALLCount = CInt(myGetPrivateProfileString("Counter", "KaniAllCount", "0", strIniFilePath))
            ' 特定郵便累計
            PubConstClass.intTokuALLCount = CInt(myGetPrivateProfileString("Counter", "TokuAllCount", "0", strIniFilePath))
            ' ゆうメール累計
            PubConstClass.intMailALLCount = CInt(myGetPrivateProfileString("Counter", "MailAllCount", "0", strIniFilePath))

            ' 作業日と今日の日付が異なっていたら各カウンタを「0」から始める
            ' 運転画面終了時に各カウンタの値をINIファイルに書き込む
            If PubConstClass.strWorkDay <> Date.Now.ToString("yyyyMMdd") Then
                ' 当日累計
                PubConstClass.intTodayALLCount = 0
                ' 簡易書留累計
                PubConstClass.intKaniALLCount = 0
                ' 特定郵便累計
                PubConstClass.intTokuALLCount = 0
                ' ゆうメール累計
                PubConstClass.intMailALLCount = 0
            End If

            ' 運用記録ログ格納
            Call OutPutUseLogFile("アプリ起動")

            ' 過去のログファイルの削除
            Call DeleteLogFiles(6)      ' 6ヶ月固定

            '// 2015.12.14 Ver.B04 hayakawa 追加↓ここから
            ' 過去に使用された引受番号の取得
            Call GetUsedUnderWritingNumber()
            '// 2015.12.14 Ver.B04 hayakawa 追加↑ここまで

            ' シリアルポートのオープン
            SerialPort.PortName = "COM1"
            ' シリアルポートの通信速度指定
            SerialPort.BaudRate = 38400
            ' シリアルポートのパリティ指定
            SerialPort.Parity = IO.Ports.Parity.Even
            ' シリアルポートのビット数指定
            SerialPort.DataBits = 8
            ' シリアルポートのストップビット指定
            SerialPort.StopBits = IO.Ports.StopBits.One

            ' シリアルポートのオープン
            SerialPort.Open()

            ' シリアルポートにデータ送信（起動コマンド）
            Dim dat As Byte() = System.Text.Encoding.GetEncoding("SHIFT-JIS").GetBytes(PubConstClass.CMD_ACK & vbCr)

            SerialPort.Write(dat, 0, dat.GetLength(0))
            SerialPort.Write(dat, 0, dat.GetLength(0))
            SerialPort.Write(dat, 0, dat.GetLength(0))

            ' シリアルポートのクローズ
            SerialPort.Close()

            ' DEFファイルの読み込み
            'Call getSystemDefinition()

        Catch ex As Exception
            MsgBox("【mainForm_Load】" & ex.Message)
            OutPutLogFile("【mainForm_Load】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' アイコンの動画処理タイマー
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub timIconTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timIconTimer.Tick

        Try
            Dim ico_file_path As String = Application.StartupPath + "\icon\" + "Rotate1.ico"

            Select Case intIconNumber
                Case 1
                    ico_file_path = Application.StartupPath + "\icon\" + "Rotate1.ico"

                    ' オペレータ情報の表示
                    LblOperatorName.Text = GetOperatorInfomation()

                Case 2
                    ico_file_path = Application.StartupPath + "\icon\" + "Rotate2.ico"
                Case 3
                    ico_file_path = Application.StartupPath + "\icon\" + "Rotate3.ico"
                Case 4
                    ico_file_path = Application.StartupPath + "\icon\" + "Rotate4.ico"
                Case 5
                    ico_file_path = Application.StartupPath + "\icon\" + "Rotate5.ico"
                Case 6
                    ico_file_path = Application.StartupPath + "\icon\" + "Rotate6.ico"
                Case 7
                    ico_file_path = Application.StartupPath + "\icon\" + "Rotate7.ico"
                Case 8
                    ico_file_path = Application.StartupPath + "\icon\" + "Rotate8.ico"
                Case Else

            End Select

            intIconNumber += 1
            If intIconNumber > 8 Then
                intIconNumber = 1
            End If
            '呼び出すアイコンの相対パス

            Dim ico As New System.Drawing.Icon(ico_file_path)

            Me.Icon = ico

        Catch ex As Exception
            'MsgBox("【timIconTimer_Tick】" & ex.Message)
        End Try

    End Sub

    Private Sub btnLogManage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        ' '' ログ管理画面の表示
        ''logManageForm.Show()
        ''Me.Hide()

    End Sub

    ''' <summary>
    ''' 印刷処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Sub PrintDocument1_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage

        Try

            Select Case PubConstClass.intPrintFuncNo
                Case 1
                    ' 受領証印刷
                    If PubConstClass.pblPrintCountPerPage = "0" Then
                        ' 「15面／頁」印刷処理
                        Print15FacePerPage(sender, e)
                        Exit Sub
                    Else
                        ' 「8面／頁」印刷処理
                        Print8FacePerPage(sender, e)
                        Exit Sub
                    End If
                Case 2
                    ' 作業日報
                    Call Print_Work_Daily_List(sender, e)
                    'Call Print_Work_Daily_List_Kan(sender, e)
                Case 3
                    ' 運用記録リスト
                    Call Print_Receipt(sender, e)
                Case 4
                    ' 処理データ表（配送内容集計リスト）印刷
                    DrivingForm.PrintTranData(sender, e)
                Case 5
                    ' 手入力リスト（簡易書留）印刷
                    DrivingForm.PrintHandInputList(sender, e)
                Case 8
                    ' 発行リスト
                    Call Print_Publish(sender, e)
                Case 9
                    ' データ状況リスト
                    Call Print_Data_Status_List(sender, e)
                Case Else
            End Select

        Catch ex As Exception
            MsgBox("【MainForm.PrintDocument1_PrintPage】" & ex.Message)
        End Try

    End Sub



    Private Sub Print_Work_Daily_List_Kan(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)

        Dim intHdrXPos As Integer       ' ヘッダーのＸ座標
        Dim intHdrYPos As Integer       ' ヘッダーのＹ座標
        Dim intCount As Integer         ' 計算結果を格納数する件数
        Dim intTatePos As Integer       ' 縦方向（Ｙ軸）の印字位置
        Dim intPageCnt As Integer
        Dim intPageCntValue As Integer = 30     ' 最大印字行数

        Try
            PrintDocument1.DocumentName = "作業日報の印刷"

            intHdrXPos = 50
            intHdrYPos = 13

            ' ヘッダーの印刷
            Dim dtNow As DateTime = DateTime.Now
            Dim h As New Font("ＭＳ ゴシック", 18, FontStyle.Regular)
            Dim f As New Font("ＭＳ ゴシック", 10, FontStyle.Regular)
            ' ヘッダー１行目
            intTatePos = intHdrYPos * 3     '（３）
            e.Graphics.DrawString(dtNow.ToString("yyyy年 MM月 dd日 hh：mm：ss"), f, Brushes.Black, 450, intTatePos)
            e.Graphics.DrawString("Page " & (PubConstClass.lngPrintIndexKan +
                                             PubConstClass.lngPrintIndexTok +
                                             PubConstClass.lngPrintIndexYou +
                                             PubConstClass.lngPrintIndexKanNuk +
                                             PubConstClass.lngPrintIndexTokNuk +
                                             PubConstClass.lngPrintIndexYouNuk + 1).ToString, f, Brushes.Black, 700, intTatePos)
            ' ヘッダー２行目
            intTatePos = intTatePos + intHdrYPos    '（４）
            e.Graphics.DrawString("処　理　日　：" & dtNow.ToString("yyyy年 MM月 dd日") & "　" & "【" & PubConstClass.pblMachineName & "】", f, Brushes.Black, intHdrXPos, intTatePos)
            intTatePos = intTatePos + intHdrYPos + intHdrYPos   '（６）

            '/////// 【簡易書留】　印刷処理 ///////
            If PubConstClass.blnIsDispKan = False Then
                e.Graphics.DrawString("作業日報　簡易書留", h, Brushes.Black, intHdrXPos, intTatePos)
                ' 罫線の印刷
                intTatePos = intTatePos + intHdrYPos + intHdrYPos   '（８）
                e.Graphics.DrawLine(New Pen(Color.Black), intHdrXPos, intHdrYPos * 8, 750, intTatePos)
                ' 引受番号（簡易書留）の最小値が設定されている時に印字
                If PubConstClass.strMinUdrWrtKan <> "" Then
                    ' 引受番号（最小）
                    intTatePos = intTatePos + intHdrYPos + intHdrYPos + intHdrYPos  '（１１）
                    e.Graphics.DrawString("引受番号　　：　最小　" & PubConstClass.strMinUdrWrtKan, f, Brushes.Black, intHdrXPos, intTatePos)
                    ' 引受番号（最大）
                    intTatePos = intTatePos + intHdrYPos + intHdrYPos   '（１３）
                    e.Graphics.DrawString("　　　　　　：　最大　" & PubConstClass.strMaxUdrWrtKan, f, Brushes.Black, intHdrXPos, intTatePos)
                    ' 処理通数の表示
                    intCount = PubConstClass.intTranCountKan
                    intTatePos = intTatePos + intHdrYPos + intHdrYPos   '（１５）
                    e.Graphics.DrawString("処理通数　　：　" & intCount.ToString & " 件", f, Brushes.Black, intHdrXPos, intTatePos)
                    ' 受領書件数の計算
                    intTatePos = intTatePos + intHdrYPos + intHdrYPos   '（１７）
                    intCount = intCount - PubConstClass.intUdrWrtDupIndexKan - PubConstClass.intUdrWrtNukiIndexKan
                    e.Graphics.DrawString("受領書件数　：　" & intCount.ToString & " 件", f, Brushes.Black, intHdrXPos, intTatePos)
                    intTatePos = intTatePos + intHdrYPos + intHdrYPos + intHdrYPos   '（２０）
                    e.Graphics.DrawString("重複件数　　：　" & PubConstClass.intUdrWrtDupIndexKan.ToString & " 件", f, Brushes.Black, intHdrXPos, intTatePos)
                    intTatePos = intTatePos + intHdrYPos    '（２１）
                    e.Graphics.DrawString("＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊", f, Brushes.Black, intHdrXPos, intTatePos)
                    ' 重複引受番号の印刷（簡易書留）
                    If PubConstClass.intUdrWrtDupIndexKan > 0 Then
                        intPageCnt = intPageCntValue
                        intTatePos = intTatePos + intHdrYPos    '（２２）
                        For N = 0 To PubConstClass.intUdrWrtDupIndexKan - 1
                            intTatePos = intTatePos + intHdrYPos
                            e.Graphics.DrawString(PubConstClass.strDupUdrWrtNumKan(CInt(N + PubConstClass.lngPrintIndexKan * intPageCntValue)), f, Brushes.Black, intHdrXPos + 40 + 115, intTatePos)
                            intPageCnt = intPageCnt - 1
                            PubConstClass.lngLoopCntKan -= 1
                            If intPageCnt = 0 Then
                                Exit For
                            End If
                            If PubConstClass.lngLoopCntKan = 0 Then
                                PubConstClass.blnIsDispKan = True
                                PubConstClass.blnIsDispKanNuk = False
                                e.HasMorePages = True
                                PubConstClass.lngPrintIndexKan = PubConstClass.lngPrintIndexKan + 1
                                Exit Sub
                                Exit For
                            End If
                        Next N
                    Else
                        PubConstClass.blnIsDispKan = True
                        PubConstClass.blnIsDispKanNuk = False
                    End If
                Else
                    ' 簡易書留の印字データがない場合は、特定記録の印字処理を有効にする
                    PubConstClass.blnIsDispKan = True
                    PubConstClass.blnIsDispTok = False
                End If
            End If
            '/////// 【簡易書留】抜取件数　印字 ///////
            If PubConstClass.blnIsDispKanNuk = False Then
                ' 重複件数が無くなったら抜取件数を印字する
                intTatePos = intTatePos + intHdrYPos + intHdrYPos
                e.Graphics.DrawString("抜取件数　　：　" & PubConstClass.intUdrWrtNukiIndexKan.ToString & " 件", f, Brushes.Black, intHdrXPos, intTatePos)
                intTatePos = intTatePos + intHdrYPos
                e.Graphics.DrawString("＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊", f, Brushes.Black, intHdrXPos, intTatePos)
                ' 抜取番号の印刷（簡易書留）
                If PubConstClass.intUdrWrtNukiIndexKan > 0 Then
                    intPageCnt = intPageCntValue
                    intTatePos = intTatePos + intHdrYPos
                    For N = 0 To PubConstClass.intUdrWrtNukiIndexKan - 1
                        intTatePos = intTatePos + intHdrYPos
                        e.Graphics.DrawString(PubConstClass.strNukUdrWrtNumKan(CInt(N + PubConstClass.lngPrintIndexKanNuk * intPageCntValue)), f, Brushes.Black, intHdrXPos + 40 + 115, intTatePos)
                        intPageCnt = intPageCnt - 1
                        PubConstClass.lngLoopCntKanNuk -= 1
                        If intPageCnt = 0 Then
                            Exit For
                        End If
                        If PubConstClass.lngLoopCntKanNuk = 0 Then
                            PubConstClass.blnIsDispKanNuk = True
                            PubConstClass.blnIsDispTok = False
                            Exit For
                        End If
                    Next N
                Else
                    PubConstClass.blnIsDispKanNuk = True
                    PubConstClass.blnIsDispTok = False
                End If
            End If


            If PubConstClass.blnIsDispYouNuk = False Then
                intTatePos = intTatePos + intHdrYPos + intHdrYPos
                e.Graphics.DrawString("抜取件数　　：　" & PubConstClass.intUdrWrtNukiIndexYou.ToString & " 件", f, Brushes.Black, intHdrXPos, intTatePos)
                intTatePos = intTatePos + intHdrYPos + intHdrYPos
                e.Graphics.DrawString("＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊", f, Brushes.Black, intHdrXPos, intTatePos)
                ' 抜取番号の印刷（ゆうメール）
                If PubConstClass.intUdrWrtNukiIndexYou > 0 Then
                    intPageCnt = intPageCntValue
                    intTatePos = intTatePos + intHdrYPos
                    For N = 0 To PubConstClass.intUdrWrtNukiIndexYou - 1
                        intTatePos = intTatePos + intHdrYPos
                        e.Graphics.DrawString(PubConstClass.strNukUdrWrtNumYou(CInt(N + PubConstClass.lngPrintIndexYouNuk * intPageCntValue)), f, Brushes.Black, intHdrXPos + 40 + 115, intTatePos)
                        intPageCnt = intPageCnt - 1
                        PubConstClass.lngLoopCntYouNuk -= 1
                        If intPageCnt = 0 Then
                            Exit For
                        End If
                        If PubConstClass.lngLoopCntYouNuk = 0 Then
                            PubConstClass.blnIsDispYouNuk = True
                            Exit For
                        End If

                    Next N
                End If

            End If

            If PubConstClass.lngLoopCntKan > 0 And PubConstClass.blnIsDispKan = False Then
                e.HasMorePages = True
                PubConstClass.lngPrintIndexKan = PubConstClass.lngPrintIndexKan + 1
            ElseIf PubConstClass.lngLoopCntKanNuk > 0 And PubConstClass.blnIsDispKanNuk = False Then
                e.HasMorePages = True
                PubConstClass.lngPrintIndexKanNuk = PubConstClass.lngPrintIndexKanNuk + 1
            Else
                e.HasMorePages = False
                intTatePos = intTatePos + intHdrYPos
                e.Graphics.DrawString("以上", f, Brushes.Black, 700, intTatePos)
                intTatePos = intTatePos + intHdrYPos + intHdrYPos
            End If

        Catch ex As Exception
            MsgBox("【Print_Work_Daily_List】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 作業日報印刷処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Print_Work_Daily_List(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)

        Dim intHdrXPos As Integer       ' ヘッダーのＸ座標
        Dim intHdrYPos As Integer       ' ヘッダーのＹ座標
        Dim intCount As Integer         ' 計算結果を格納数する件数
        Dim intTatePos As Integer       ' 縦方向（Ｙ軸）の印字位置
        Dim intPageCnt As Integer
        Dim intPageCntValue As Integer = 30     ' 最大印字行数

        Try
            PrintDocument1.DocumentName = "作業日報の印刷"

            intHdrXPos = 50
            intHdrYPos = 13

            ' ヘッダーの印刷
            Dim dtNow As DateTime = DateTime.Now
            Dim h As New Font("ＭＳ ゴシック", 18, FontStyle.Regular)
            Dim f As New Font("ＭＳ ゴシック", 10, FontStyle.Regular)
            ' ヘッダー１行目
            intTatePos = intHdrYPos * 3     '（３）
            e.Graphics.DrawString(dtNow.ToString("yyyy年MM月dd日 HH時mm分ss秒"), f, Brushes.Black, 450, intTatePos)
            e.Graphics.DrawString("Page " & (PubConstClass.lngPrintIndexKan +
                                             PubConstClass.lngPrintIndexTok +
                                             PubConstClass.lngPrintIndexYou +
                                             PubConstClass.lngPrintIndexKanNuk +
                                             PubConstClass.lngPrintIndexTokNuk +
                                             PubConstClass.lngPrintIndexYouNuk + 1).ToString, f, Brushes.Black, 700, intTatePos)
            ' ヘッダー２行目
            intTatePos = intTatePos + intHdrYPos    '（４）
            e.Graphics.DrawString("処　理　日　：" & dtNow.ToString("yyyy年 MM月 dd日") & "　" & "【" & PubConstClass.pblMachineName & "】", f, Brushes.Black, intHdrXPos, intTatePos)
            intTatePos = intTatePos + intHdrYPos + intHdrYPos   '（６）

            '/////// 【簡易書留】　印刷処理 ///////
            If PubConstClass.blnIsDispKan = False Then
                e.Graphics.DrawString("作業日報　簡易書留", h, Brushes.Black, intHdrXPos, intTatePos)
                ' 罫線の印刷
                intTatePos = intTatePos + intHdrYPos + intHdrYPos   '（８）
                e.Graphics.DrawLine(New Pen(Color.Black), intHdrXPos, intHdrYPos * 8, 750, intTatePos)
                ' 引受番号（簡易書留）の最小値が設定されている時に印字
                If PubConstClass.strMinUdrWrtKan <> "" Then
                    ' 引受番号（最小）
                    intTatePos = intTatePos + intHdrYPos + intHdrYPos + intHdrYPos  '（１１）
                    e.Graphics.DrawString("引受番号　　：　最小　" & PubConstClass.strMinUdrWrtKan, f, Brushes.Black, intHdrXPos, intTatePos)
                    ' 引受番号（最大）
                    intTatePos = intTatePos + intHdrYPos + intHdrYPos   '（１３）
                    e.Graphics.DrawString("　　　　　　：　最大　" & PubConstClass.strMaxUdrWrtKan, f, Brushes.Black, intHdrXPos, intTatePos)
                    ' 処理通数の表示
                    intCount = PubConstClass.intTranCountKan
                    intTatePos = intTatePos + intHdrYPos + intHdrYPos   '（１５）
                    e.Graphics.DrawString("処理通数　　：　" & intCount.ToString & " 件", f, Brushes.Black, intHdrXPos, intTatePos)
                    ' 受領書件数の計算
                    intTatePos = intTatePos + intHdrYPos + intHdrYPos   '（１７）
                    intCount = intCount - PubConstClass.intUdrWrtDupIndexKan - PubConstClass.intUdrWrtNukiIndexKan
                    e.Graphics.DrawString("受領書件数　：　" & intCount.ToString & " 件", f, Brushes.Black, intHdrXPos, intTatePos)
                    intTatePos = intTatePos + intHdrYPos + intHdrYPos + intHdrYPos   '（２０）
                    e.Graphics.DrawString("重複件数　　：　" & PubConstClass.intUdrWrtDupIndexKan.ToString & " 件", f, Brushes.Black, intHdrXPos, intTatePos)
                    intTatePos = intTatePos + intHdrYPos    '（２１）
                    e.Graphics.DrawString("＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊", f, Brushes.Black, intHdrXPos, intTatePos)
                    ' 重複引受番号の印刷（簡易書留）
                    If PubConstClass.intUdrWrtDupIndexKan > 0 Then
                        intPageCnt = intPageCntValue
                        intTatePos = intTatePos + intHdrYPos    '（２２）
                        For N = 0 To PubConstClass.intUdrWrtDupIndexKan - 1
                            intTatePos = intTatePos + intHdrYPos
                            e.Graphics.DrawString(PubConstClass.strDupUdrWrtNumKan(CInt(N + PubConstClass.lngPrintIndexKan * intPageCntValue)), f, Brushes.Black, intHdrXPos + 40 + 115, intTatePos)
                            intPageCnt = intPageCnt - 1
                            PubConstClass.lngLoopCntKan -= 1
                            If intPageCnt = 0 Then
                                Exit For
                            End If
                            If PubConstClass.lngLoopCntKan = 0 Then
                                PubConstClass.blnIsDispKan = True
                                PubConstClass.blnIsDispKanNuk = False
                                'e.HasMorePages = True
                                'PubConstClass.lngPrintIndexKan = PubConstClass.lngPrintIndexKan + 1
                                'Exit Sub
                                Exit For
                            End If
                        Next N
                    Else
                        PubConstClass.blnIsDispKan = True
                        PubConstClass.blnIsDispKanNuk = False
                    End If
                Else
                    ' 簡易書留の印字データがない場合は、特定記録の印字処理を有効にする
                    PubConstClass.blnIsDispKan = True
                    PubConstClass.blnIsDispTok = False
                    intTatePos = intTatePos + intHdrYPos + intHdrYPos + intHdrYPos  '（１１）
                    e.Graphics.DrawString("処理件数：なし", h, Brushes.Black, intHdrXPos, intTatePos)
                    PubConstClass.lngPrintIndexKan = PubConstClass.lngPrintIndexKan + 1
                    e.HasMorePages = True
                    Exit Sub
                End If
            End If
            '/////// 【簡易書留】抜取件数　印字 ///////
            If PubConstClass.blnIsDispKanNuk = False Then
                ' 重複件数が無くなったら抜取件数を印字する
                intTatePos = intTatePos + intHdrYPos + intHdrYPos
                e.Graphics.DrawString("抜取件数　　：　" & PubConstClass.intUdrWrtNukiIndexKan.ToString & " 件", f, Brushes.Black, intHdrXPos, intTatePos)
                intTatePos = intTatePos + intHdrYPos
                e.Graphics.DrawString("＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊", f, Brushes.Black, intHdrXPos, intTatePos)
                ' 抜取番号の印刷（簡易書留）
                If PubConstClass.intUdrWrtNukiIndexKan > 0 Then
                    intPageCnt = intPageCntValue
                    intTatePos = intTatePos + intHdrYPos
                    For N = 0 To PubConstClass.intUdrWrtNukiIndexKan - 1
                        intTatePos = intTatePos + intHdrYPos
                        e.Graphics.DrawString(PubConstClass.strNukUdrWrtNumKan(CInt(N + PubConstClass.lngPrintIndexKanNuk * intPageCntValue)), f, Brushes.Black, intHdrXPos + 40 + 115, intTatePos)
                        intPageCnt = intPageCnt - 1
                        PubConstClass.lngLoopCntKanNuk -= 1
                        If intPageCnt = 0 Then
                            '// 2016.07.13 Ver.B07 hayakawa 追加↓ここから
                            If PubConstClass.lngLoopCntKanNuk = 0 Then
                                PubConstClass.blnIsDispKanNuk = True
                                PubConstClass.blnIsDispTok = False
                                e.HasMorePages = True
                                PubConstClass.lngPrintIndexKan = PubConstClass.lngPrintIndexKan + 1
                                Exit Sub
                            Else
                                Exit For
                            End If
                            'Exit For
                            '// 2016.07.13 Ver.B07 hayakawa 追加↑ここまで
                        End If
                        If PubConstClass.lngLoopCntKanNuk = 0 Then
                            PubConstClass.blnIsDispKanNuk = True
                            PubConstClass.blnIsDispTok = False
                            e.HasMorePages = True
                            PubConstClass.lngPrintIndexKan = PubConstClass.lngPrintIndexKan + 1
                            Exit Sub
                            'Exit For
                        End If
                    Next N
                Else
                    PubConstClass.blnIsDispKanNuk = True
                    PubConstClass.blnIsDispTok = False
                    e.HasMorePages = True
                    PubConstClass.lngPrintIndexKan = PubConstClass.lngPrintIndexKan + 1
                    Exit Sub
                End If
            End If

            '/////// 【特定記録】　印字処理 ///////
            If PubConstClass.blnIsDispTok = False Then
                'intTatePos = intTatePos + intHdrYPos + intHdrYPos
                e.Graphics.DrawString("作業日報　特定記録", h, Brushes.Black, intHdrXPos, intTatePos)
                ' 罫線の印刷
                intTatePos = intTatePos + intHdrYPos + intHdrYPos
                e.Graphics.DrawLine(New Pen(Color.Black), intHdrXPos, intTatePos, 750, intTatePos)
                ' 引受番号（特定記録）の最小値が設定されている時に印字
                If PubConstClass.strMinUdrWrtTok <> "" Then
                    ' 引受番号（最小）
                    intTatePos = intTatePos + intHdrYPos + intHdrYPos + intHdrYPos
                    e.Graphics.DrawString("引受番号　　：　最小　" & PubConstClass.strMinUdrWrtTok, f, Brushes.Black, intHdrXPos, intTatePos)
                    ' 引受番号（最大）
                    intTatePos = intTatePos + intHdrYPos + intHdrYPos
                    e.Graphics.DrawString("　　　　　　：　最大　" & PubConstClass.strMaxUdrWrtTok, f, Brushes.Black, intHdrXPos, intTatePos)
                    ' 処理通数の計算
                    intTatePos = intTatePos + intHdrYPos + intHdrYPos
                    intCount = PubConstClass.intTranCountTok
                    e.Graphics.DrawString("処理通数　　：　" & intCount.ToString & " 件", f, Brushes.Black, intHdrXPos, intTatePos)
                    ' 受領書件数の計算
                    intTatePos = intTatePos + intHdrYPos + intHdrYPos
                    intCount = intCount - PubConstClass.intUdrWrtDupIndexTok - PubConstClass.intUdrWrtNukiIndexTok
                    e.Graphics.DrawString("受領書件数　：　" & intCount.ToString & " 件", f, Brushes.Black, intHdrXPos, intTatePos)
                    intTatePos = intTatePos + intHdrYPos + intHdrYPos + intHdrYPos
                    e.Graphics.DrawString("重複件数　　：　" & PubConstClass.intUdrWrtDupIndexTok.ToString & " 件", f, Brushes.Black, intHdrXPos, intTatePos)
                    intTatePos = intTatePos + intHdrYPos
                    e.Graphics.DrawString("＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊", f, Brushes.Black, intHdrXPos, intTatePos)
                    ' 重複引受番号の印刷（特定記録）
                    If PubConstClass.intUdrWrtDupIndexTok > 0 Then
                        intPageCnt = intPageCntValue
                        intTatePos = intTatePos + intHdrYPos    '（２２）
                        For N = 0 To PubConstClass.intUdrWrtDupIndexTok - 1
                            intTatePos = intTatePos + intHdrYPos
                            e.Graphics.DrawString(PubConstClass.strDupUdrWrtNumTok(CInt(N + PubConstClass.lngPrintIndexTok * intPageCntValue)), f, Brushes.Black, intHdrXPos + 40 + 115, intTatePos)
                            intPageCnt = intPageCnt - 1
                            PubConstClass.lngLoopCntTok -= 1
                            If intPageCnt = 0 Then
                                Exit For
                            End If
                            If PubConstClass.lngLoopCntTok = 0 Then
                                PubConstClass.blnIsDispTok = True
                                PubConstClass.blnIsDispTokNuk = False
                                'e.HasMorePages = True
                                'PubConstClass.lngPrintIndexTok = PubConstClass.lngPrintIndexTok + 1
                                'Exit Sub
                            End If
                        Next N
                    Else
                        PubConstClass.blnIsDispTok = True
                        PubConstClass.blnIsDispTokNuk = False
                    End If

                Else
                    ' 特定記録の印字データがない場合は、ゆうメールの印字処理を有効にする
                    PubConstClass.blnIsDispTok = True
                    PubConstClass.blnIsDispYou = False
                    intTatePos = intTatePos + intHdrYPos + intHdrYPos + intHdrYPos  '（１１）
                    e.Graphics.DrawString("処理件数：なし", h, Brushes.Black, intHdrXPos, intTatePos)
                    PubConstClass.lngPrintIndexTok = PubConstClass.lngPrintIndexTok + 1
                    e.HasMorePages = True
                    Exit Sub
                End If
            End If
            '/////// 【特定記録】抜取件数　印字処理 ///////
            If PubConstClass.blnIsDispTokNuk = False Then
                ' 重複件数が無くなったら抜取件数を印字する
                intTatePos = intTatePos + intHdrYPos + intHdrYPos
                e.Graphics.DrawString("抜取件数　　：　" & PubConstClass.intUdrWrtNukiIndexTok.ToString & " 件", f, Brushes.Black, intHdrXPos, intTatePos)
                intTatePos = intTatePos + intHdrYPos
                e.Graphics.DrawString("＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊", f, Brushes.Black, intHdrXPos, intTatePos)
                ' 抜取番号の印刷（特定記録）
                If PubConstClass.intUdrWrtNukiIndexTok > 0 Then
                    intPageCnt = intPageCntValue
                    intTatePos = intTatePos + intHdrYPos
                    For N = 0 To PubConstClass.intUdrWrtNukiIndexTok - 1
                        intTatePos = intTatePos + intHdrYPos
                        e.Graphics.DrawString(PubConstClass.strNukUdrWrtNumTok(CInt(N + PubConstClass.lngPrintIndexTokNuk * intPageCntValue)), f, Brushes.Black, intHdrXPos + 40 + 115, intTatePos)
                        intPageCnt = intPageCnt - 1
                        PubConstClass.lngLoopCntTokNuk -= 1
                        If intPageCnt = 0 Then
                            '// 2016.07.13 Ver.B07 hayakawa 追加↓ここから
                            If PubConstClass.lngLoopCntTokNuk = 0 Then
                                PubConstClass.blnIsDispTok = True
                                PubConstClass.blnIsDispTokNuk = True
                                PubConstClass.blnIsDispYou = False
                                e.HasMorePages = True
                                PubConstClass.lngPrintIndexTok = PubConstClass.lngPrintIndexTok + 1
                                Exit Sub
                            Else
                                Exit For
                            End If
                            'Exit For
                            '// 2016.07.13 Ver.B07 hayakawa 追加↑ここまで
                        End If
                        If PubConstClass.lngLoopCntTokNuk = 0 Then
                            PubConstClass.blnIsDispTok = True
                            PubConstClass.blnIsDispTokNuk = True
                            PubConstClass.blnIsDispYou = False
                            e.HasMorePages = True
                            PubConstClass.lngPrintIndexTok = PubConstClass.lngPrintIndexTok + 1
                            Exit Sub
                            'Exit For
                        End If
                    Next N
                Else
                    PubConstClass.blnIsDispTok = True
                    PubConstClass.blnIsDispTokNuk = True
                    PubConstClass.blnIsDispYou = False
                    e.HasMorePages = True
                    PubConstClass.lngPrintIndexTok = PubConstClass.lngPrintIndexTok + 1
                    Exit Sub
                End If

            End If

            '/////// 【ゆうメール】　印字処理 ///////
            If PubConstClass.blnIsDispYou = False Then
                'intTatePos = intTatePos + intHdrYPos + intHdrYPos
                e.Graphics.DrawString("作業日報　ゆうメール（簡易書留）", h, Brushes.Black, intHdrXPos, intTatePos)
                ' 罫線の印刷
                intTatePos = intTatePos + intHdrYPos + intHdrYPos
                e.Graphics.DrawLine(New Pen(Color.Black), intHdrXPos, intTatePos, 750, intTatePos)
                ' 引受番号（ゆうメール）の最小値が設定されている時に印字
                If PubConstClass.strMinUdrWrtYou <> "" Then
                    ' 引受番号（最小）
                    intTatePos = intTatePos + intHdrYPos + intHdrYPos + intHdrYPos
                    e.Graphics.DrawString("引受番号　　：　最小　" & PubConstClass.strMinUdrWrtYou, f, Brushes.Black, intHdrXPos, intTatePos)
                    ' 引受番号（最大）
                    intTatePos = intTatePos + intHdrYPos + intHdrYPos
                    e.Graphics.DrawString("　　　　　　：　最大　" & PubConstClass.strMaxUdrWrtYou, f, Brushes.Black, intHdrXPos, intTatePos)
                    ' 処理通数の計算
                    intTatePos = intTatePos + intHdrYPos + intHdrYPos
                    intCount = PubConstClass.intTranCountYou
                    e.Graphics.DrawString("処理通数　　：　" & intCount.ToString & " 件", f, Brushes.Black, intHdrXPos, intTatePos)
                    ' 受領書件数の計算
                    intTatePos = intTatePos + intHdrYPos + intHdrYPos
                    intCount = intCount - PubConstClass.intUdrWrtDupIndexYou - PubConstClass.intUdrWrtNukiIndexYou
                    e.Graphics.DrawString("受領書件数　：　" & intCount.ToString & " 件", f, Brushes.Black, intHdrXPos, intTatePos)
                    intTatePos = intTatePos + intHdrYPos + intHdrYPos + intHdrYPos
                    e.Graphics.DrawString("重複件数　　：　" & PubConstClass.intUdrWrtDupIndexYou.ToString & " 件", f, Brushes.Black, intHdrXPos, intTatePos)
                    intTatePos = intTatePos + intHdrYPos
                    e.Graphics.DrawString("＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊", f, Brushes.Black, intHdrXPos, intTatePos)
                    ' 重複引受番号の印刷（ゆうメール）
                    If PubConstClass.intUdrWrtDupIndexYou > 0 Then
                        intPageCnt = intPageCntValue
                        intTatePos = intTatePos + intHdrYPos    '（２２）
                        For N = 0 To PubConstClass.intUdrWrtDupIndexYou - 1
                            intTatePos = intTatePos + intHdrYPos
                            e.Graphics.DrawString(PubConstClass.strDupUdrWrtNumYou(CInt(N + PubConstClass.lngPrintIndexYou * intPageCntValue)), f, Brushes.Black, intHdrXPos + 40 + 115, intTatePos)
                            intPageCnt = intPageCnt - 1
                            PubConstClass.lngLoopCntYou -= 1
                            If intPageCnt = 0 Then
                                PubConstClass.blnIsDispYou = True
                                PubConstClass.blnIsDispYouNuk = False
                                Exit For
                            End If
                            If PubConstClass.lngLoopCntYou = 0 Then
                                PubConstClass.blnIsDispYou = True
                                PubConstClass.blnIsDispYouNuk = False
                                'e.HasMorePages = True
                                'PubConstClass.lngPrintIndexYou = PubConstClass.lngPrintIndexYou + 1
                                'Exit Sub
                                Exit For
                            End If
                        Next N
                    Else
                        PubConstClass.blnIsDispYou = True
                        PubConstClass.blnIsDispYouNuk = False
                    End If
                Else
                    intTatePos = intTatePos + intHdrYPos + intHdrYPos + intHdrYPos  '（１１）
                    e.Graphics.DrawString("処理件数：なし", h, Brushes.Black, intHdrXPos, intTatePos)
                End If
            End If

            If PubConstClass.blnIsDispYouNuk = False Then
                intTatePos = intTatePos + intHdrYPos + intHdrYPos
                e.Graphics.DrawString("抜取件数　　：　" & PubConstClass.intUdrWrtNukiIndexYou.ToString & " 件", f, Brushes.Black, intHdrXPos, intTatePos)
                intTatePos = intTatePos + intHdrYPos
                e.Graphics.DrawString("＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊", f, Brushes.Black, intHdrXPos, intTatePos)
                ' 抜取番号の印刷（ゆうメール）
                If PubConstClass.intUdrWrtNukiIndexYou > 0 Then
                    intPageCnt = intPageCntValue
                    intTatePos = intTatePos + intHdrYPos
                    For N = 0 To PubConstClass.intUdrWrtNukiIndexYou - 1
                        intTatePos = intTatePos + intHdrYPos
                        e.Graphics.DrawString(PubConstClass.strNukUdrWrtNumYou(CInt(N + PubConstClass.lngPrintIndexYouNuk * intPageCntValue)), f, Brushes.Black, intHdrXPos + 40 + 115, intTatePos)
                        intPageCnt = intPageCnt - 1
                        PubConstClass.lngLoopCntYouNuk -= 1
                        If intPageCnt = 0 Then
                            Exit For
                        End If
                        If PubConstClass.lngLoopCntYouNuk = 0 Then
                            PubConstClass.blnIsDispYouNuk = True
                            Exit For
                        End If

                    Next N
                End If

            End If

            If PubConstClass.lngLoopCntKan > 0 And PubConstClass.blnIsDispKan = False Then
                e.HasMorePages = True
                PubConstClass.lngPrintIndexKan = PubConstClass.lngPrintIndexKan + 1

            ElseIf PubConstClass.lngLoopCntTok > 0 And PubConstClass.blnIsDispTok = False Then
                e.HasMorePages = True
                PubConstClass.lngPrintIndexTok = PubConstClass.lngPrintIndexTok + 1

            ElseIf PubConstClass.lngLoopCntYou > 0 And PubConstClass.blnIsDispYou = False Then
                e.HasMorePages = True
                PubConstClass.lngPrintIndexYou = PubConstClass.lngPrintIndexYou + 1

            ElseIf PubConstClass.lngLoopCntKanNuk > 0 And PubConstClass.blnIsDispKanNuk = False Then
                e.HasMorePages = True
                PubConstClass.lngPrintIndexKanNuk = PubConstClass.lngPrintIndexKanNuk + 1

            ElseIf PubConstClass.lngLoopCntTokNuk > 0 And PubConstClass.blnIsDispTokNuk = False Then
                e.HasMorePages = True
                PubConstClass.lngPrintIndexTokNuk = PubConstClass.lngPrintIndexTokNuk + 1

            ElseIf PubConstClass.lngLoopCntYouNuk > 0 And PubConstClass.blnIsDispYouNuk = False Then
                e.HasMorePages = True
                PubConstClass.lngPrintIndexYouNuk = PubConstClass.lngPrintIndexYouNuk + 1

            Else
                e.HasMorePages = False
                intTatePos = intTatePos + intHdrYPos
                e.Graphics.DrawString("以上", f, Brushes.Black, 700, intTatePos)
                intTatePos = intTatePos + intHdrYPos + intHdrYPos
                'e.Graphics.DrawString("※受領証の発行枚数は作業日報に表示することができません", f, Brushes.Black, intHdrXPos, intTatePos)
            End If

        Catch ex As Exception
            MsgBox("【Print_Work_Daily_List】" & ex.Message)
        End Try

    End Sub


    ''' <summary>
    ''' データ状況リスト印刷処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Print_Data_Status_List(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)

        Dim intHdrXPos As Integer       ' ヘッダーのＸ座標
        Dim intHdrYPos As Integer       ' ヘッダーのＹ座標

        Try
            PrintDocument1.DocumentName = "データ状況リストの印刷"

            intHdrXPos = 50
            intHdrYPos = 13

            ' ヘッダーの印刷
            Dim dtNow As DateTime = DateTime.Now
            Dim h As New Font("ＭＳ ゴシック", 18, FontStyle.Regular)
            Dim f As New Font("ＭＳ ゴシック", 10, FontStyle.Regular)
            ' ヘッダー１行目
            e.Graphics.DrawString(dtNow.ToString("yyyy年 MM月 dd日 hh時 mm分 ss秒"), f, Brushes.Black, 450, intHdrYPos * 3)
            e.Graphics.DrawString("Page " & (PubConstClass.lngPrintIndex + 1).ToString, f, Brushes.Black, 700, intHdrYPos * 3)
            ' ヘッダー２行目
            e.Graphics.DrawString("データ状況リスト", h, Brushes.Black, intHdrXPos, intHdrYPos * 3)
            ' 罫線の印刷
            e.Graphics.DrawLine(New Pen(Color.Black), intHdrXPos, intHdrYPos * 5 + 10, 750, intHdrYPos * 5 + 10)

            'e.Graphics.DrawString("設定処理日　：　" & dtNow.ToString("yyyy年 MM月 dd日"), f, Brushes.Black, intHdrXPos, intHdrYPos * 8)
            e.Graphics.DrawString("設定処理日　：　" & PubConstClass.strSetDateValue, f, Brushes.Black, intHdrXPos, intHdrYPos * 8)

            e.Graphics.DrawString("引受番号　　：　最小　" & PubConstClass.strMinReceiptNum, f, Brushes.Black, intHdrXPos, intHdrYPos * 10)

            e.Graphics.DrawString("　　　　　　：　最大　" & PubConstClass.strMaxReceiptNum, f, Brushes.Black, intHdrXPos, intHdrYPos * 12)

            e.Graphics.DrawString("処理通数　　：　" & (PubConstClass.lngReceiptIndex - PubConstClass.intReceiptDispDupIndex).ToString & " 件", f, Brushes.Black, intHdrXPos, intHdrYPos * 14)
            'e.Graphics.DrawString("受領書件数　：　" & (PubConstClass.lngReceiptIndex + PubConstClass.lngReceiptNGIndex).ToString & " 件" _
            '                                          , f, Brushes.Black, intHdrXPos, intHdrYPos * 16)
            e.Graphics.DrawString("受領書件数　：　" & PubConstClass.lngReceiptIndex.ToString & " 件", f, Brushes.Black, intHdrXPos, intHdrYPos * 16)
            e.Graphics.DrawString("重複件数　　：　" & PubConstClass.intReceiptDispDupIndex.ToString & " 件", f, Brushes.Black, intHdrXPos, intHdrYPos * 18)

            e.Graphics.DrawString("重複引受番号", f, Brushes.Black, intHdrXPos, intHdrYPos * 20)
            e.Graphics.DrawString("〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓",
                                  f, Brushes.Black, intHdrXPos, intHdrYPos * 21)

            ' 重複引受番号の印刷
            Dim N As Integer
            Dim strArray() As String
            Dim intPageData As Integer
            Dim intDataNum As Integer
            Dim strDupData As String
            Dim intPageCnt As Integer

            If PubConstClass.intReceiptDupIndex > 0 Then
                intPageCnt = 50
                For N = 0 To intPageCnt - 1
                    strArray = PubConstClass.strDupReceiptNum(CInt(N + PubConstClass.lngPrintIndex * intPageCnt)).Split(","c)
                    intPageData = CInt(Math.Truncate(CInt(strArray(1)) / 15) + 1)
                    intDataNum = CInt(CInt(strArray(1)) Mod 15)
                    strDupData = strArray(0) & "   " & intPageData.ToString & "頁　" & (intDataNum + 1).ToString & "番"
                    e.Graphics.DrawString(strDupData, f, Brushes.Black, intHdrXPos + 40, intHdrYPos * 22 + intHdrYPos * N)

                    PubConstClass.intReceiptDupIndex = PubConstClass.intReceiptDupIndex - 1
                    If PubConstClass.intReceiptDupIndex = 0 Then
                        Exit For
                    End If
                Next N

            End If

            If PubConstClass.intReceiptDupIndex > 0 Then
                e.HasMorePages = True
                PubConstClass.lngPrintIndex = PubConstClass.lngPrintIndex + 1
            Else
                e.HasMorePages = False
                e.Graphics.DrawString("―以上―", f, Brushes.Black, intHdrXPos, intHdrYPos * 22 + intHdrYPos * (N + 1))
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 発行リスト印刷処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Print_Publish(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)

        Dim intHdrXPos As Integer       ' ヘッダーのＸ座標
        Dim intHdrYPos As Integer       ' ヘッダーのＹ座標

        Try

            PrintDocument1.DocumentName = "発行リスト印刷"

            intHdrXPos = 50
            intHdrYPos = 13

            ' ヘッダーの印刷
            Dim dtNow As DateTime = DateTime.Now
            Dim h As New Font("ＭＳ ゴシック", 18, FontStyle.Regular)
            Dim f As New Font("ＭＳ ゴシック", 10, FontStyle.Regular)
            ' ヘッダー１行目
            e.Graphics.DrawString(dtNow.ToString("yyyy年 MM月 dd日 hh時 mm分 ss秒"), f, Brushes.Black, 450, intHdrYPos * 3)
            e.Graphics.DrawString("Page " & (PubConstClass.lngPrintIndex + 1).ToString, f, Brushes.Black, 700, intHdrYPos * 3)
            ' ヘッダー２行目
            e.Graphics.DrawString("発行リスト", h, Brushes.Black, intHdrXPos, intHdrYPos * 3)
            ' 罫線の印刷
            e.Graphics.DrawLine(New Pen(Color.Black), intHdrXPos, intHdrYPos * 5 + 10, 750, intHdrYPos * 5 + 10)

            ' ヘッダー３行目
            'e.Graphics.DrawString("発行リスト", f, Brushes.Black, intHdrXPos, intHdrYPos * 7)

            Dim strPrintData As String

            For lngLoopCnt = 1 To 60
                strPrintData = ""
                For N = 1 To 5
                    strPrintData = strPrintData & PubConstClass.strReceiptNum(CInt(PubConstClass.lngLoopCnt)) & "    "
                    PubConstClass.lngLoopCnt += 1
                    If PubConstClass.lngLoopCnt > PubConstClass.lngReceiptIndex Then
                        Exit For
                    End If
                    e.Graphics.DrawString(strPrintData, f, Brushes.Black, intHdrXPos + 20, intHdrYPos * (6 + lngLoopCnt))
                Next

                If PubConstClass.lngLoopCnt > PubConstClass.lngReceiptIndex Then
                    Exit For
                End If

            Next

            If PubConstClass.lngLoopCnt < PubConstClass.lngReceiptIndex Then
                e.HasMorePages = True
                ' 頁番号を＋１する
                PubConstClass.lngPrintIndex = PubConstClass.lngPrintIndex + 1
            Else
                e.HasMorePages = False
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 運用記録リスト印刷処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Print_Receipt(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)

        Dim intHdrXPos As Integer       ' ヘッダーのＸ座標
        Dim intHdrYPos As Integer       ' ヘッダーのＹ座標
        Dim intXPos As Integer          ' 本文のＸ座標
        Dim intYPos As Integer          ' 本文のＹ座標
        Dim strTitle1 As String         ' 本文のタイトル（１行目）
        Dim strTitle2 As String         ' 本文のタイトル（２行目）

        Dim N As Long

        Try

            PrintDocument1.DocumentName = "運用記録リストの印刷"

            intHdrXPos = 50
            intHdrYPos = 13

            ' ヘッダーの印刷
            Dim dtNow As DateTime = DateTime.Now
            Dim h As New Font("ＭＳ ゴシック", 18, FontStyle.Regular)
            Dim f As New Font("ＭＳ ゴシック", 10, FontStyle.Regular)
            ' ヘッダー１行目
            e.Graphics.DrawString(dtNow.ToString("yyyy年MM月dd日 HH時mm分ss秒"), f, Brushes.Black, 450, intHdrYPos * 3)
            e.Graphics.DrawString("Page " & (PubConstClass.lngPrintIndex + 1).ToString, f, Brushes.Black, 700, intHdrYPos * 3)
            ' ヘッダー２行目
            e.Graphics.DrawString("運用記録リスト", h, Brushes.Black, intHdrXPos, intHdrYPos * 3)
            ' 号機名
            e.Graphics.DrawString("【" & PubConstClass.pblMachineName & "】", f, Brushes.Black, 300, intHdrYPos * 3)
            ' 罫線の印刷
            e.Graphics.DrawLine(New Pen(Color.Black), intHdrXPos, intHdrYPos * 5 + 10, 750, intHdrYPos * 5 + 10)
            strTitle1 = "　　日　付　　　　　　時　間　　　　　ステータス"
            strTitle2 = "〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓"
            ' ヘッダー３行目
            e.Graphics.DrawString(strTitle1, f, Brushes.Black, intHdrXPos, intHdrYPos * 6)
            ' ヘッダー４行目
            e.Graphics.DrawString(strTitle2, f, Brushes.Black, intHdrXPos, intHdrYPos * 7)

            intXPos = 60
            intYPos = 13

            For N = 0 To 59

                e.Graphics.DrawString(PubConstClass.strUseLogArray(CInt(N + PubConstClass.lngPrintIndex * 60)), f, Brushes.Black, intXPos, intYPos * (N + 1) + intHdrYPos * 7)
                PubConstClass.lngLoopCnt = PubConstClass.lngLoopCnt - 1
                If PubConstClass.lngLoopCnt < 1 Then
                    Exit For
                End If
            Next N

            If PubConstClass.lngLoopCnt > 0 Then
                e.HasMorePages = True
                PubConstClass.lngPrintIndex = PubConstClass.lngPrintIndex + 1
            Else
                e.HasMorePages = False
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 全ての稼動ログから引受番号をソート処理無しで取得する
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub getRecieptNoSortALLInfo()

        Dim strGetFile As String
        Dim strArray() As String

        Try

            Call getSystemIniFile()

            PubConstClass.lngReceiptIndex = 0

            ' 画像格納フォルダ内の全てのフォルダを取得する
            strGetFile = ""
            For Each tempFile As String In
                System.IO.Directory.GetFiles(IncludeTrailingPathDelimiter(PubConstClass.imgPath) &
                                             DateTime.Now.ToString("yyyyMMdd"))
                Call OutPutLogFile("取得したフォルダ：" & tempFile)
                strGetFile = strGetFile & tempFile & Constants.vbCr

                Using sr As New System.IO.StreamReader(tempFile, System.Text.Encoding.Default)
                    'Debug.Print("〓〓〓〓〓〓〓〓〓〓")
                    Do While Not sr.EndOfStream
                        strArray = sr.ReadLine.Split(","c)
                        Call OutPutLogFile("OK:" & strArray(3))
                        PubConstClass.strReceiptNum(CInt(PubConstClass.lngReceiptIndex)) = strArray(3)
                        PubConstClass.lngReceiptIndex += 1
                    Loop
                End Using

            Next
            Call OutPutLogFile("■受付番号の数：" & PubConstClass.lngReceiptIndex.ToString)

            'Dim strWork As String

            '' 引受番号を昇順にソートし最小値と最大値を求める
            'For N = 0 To PubConstClass.lngReceiptIndex - 1
            '    For K = N + 1 To PubConstClass.lngReceiptIndex - 1

            '        If PubConstClass.strReceiptNum(CInt(N)).Replace("-", "") > PubConstClass.strReceiptNum(CInt(K)).Replace("-", "") Then
            '            strWork = PubConstClass.strReceiptNum(CInt(N))
            '            PubConstClass.strReceiptNum(CInt(N)) = PubConstClass.strReceiptNum(CInt(K))
            '            PubConstClass.strReceiptNum(CInt(K)) = strWork
            '        End If

            '    Next
            'Next N
            '' 最小値を取得する
            'PubConstClass.strMinReceiptNum = PubConstClass.strReceiptNum(0)
            '' 最大値を取得する
            'PubConstClass.strMaxReceiptNum = PubConstClass.strReceiptNum(CInt(PubConstClass.lngReceiptIndex - 1))

            'If strGetFile <> "" Then
            '    'MsgBox("以下の稼働ファイルを取得しました。" & Constants.vbCrLf & strGetFile, CType(MsgBoxStyle.Information + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認メッセージ")
            '    strGetFile = strGetFile.Substring(0, strGetFile.LastIndexOf(Constants.vbCr))
            '    Call OutPutLogFile("以下の稼働ファイルを取得しました。" & Constants.vbCr & strGetFile)
            '    Call OutPutLogFile("引受番号の最小値：" & PubConstClass.strMinReceiptNum)
            '    Call OutPutLogFile("引受番号の最大値：" & PubConstClass.strMaxReceiptNum)
            'End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

    ''' <summary>
    ''' 全ての稼動ログから引受番号を取得する（最小値・最大値・OK数・NG数）
    ''' </summary>
    ''' <remarks></remarks>
    '''
    Public Sub getRecieptALLInfo()

        Dim strGetFile As String
        Dim strArray() As String

        Try

            Call getSystemIniFile()

            PubConstClass.lngReceiptIndex = 0

            ' 画像格納フォルダ内の全てのフォルダを取得する
            strGetFile = ""
            For Each tempFile As String In
                System.IO.Directory.GetFiles(IncludeTrailingPathDelimiter(PubConstClass.imgPath) &
                                             DateTime.Now.ToString("yyyyMMdd"))
                'Call OutPutLogFile("取得したフォルダ：" & tempFile)
                strGetFile = strGetFile & tempFile & Constants.vbCr

                Using sr As New System.IO.StreamReader(tempFile, System.Text.Encoding.Default)
                    'Debug.Print("〓〓〓〓〓〓〓〓〓〓")
                    Do While Not sr.EndOfStream
                        strArray = sr.ReadLine.Split(","c)
                        PubConstClass.strReceiptNum(CInt(PubConstClass.lngReceiptIndex)) = strArray(3)
                        PubConstClass.lngReceiptIndex += 1
                    Loop
                End Using

            Next
            'Call OutPutLogFile("■受付番号の数：" & PubConstClass.lngReceiptIndex.ToString)

            Dim strWork As String

            ' 引受番号を昇順にソートし最小値と最大値を求める
            For N = 0 To PubConstClass.lngReceiptIndex - 1
                For K = N + 1 To PubConstClass.lngReceiptIndex - 1

                    If PubConstClass.strReceiptNum(CInt(N)).Replace("-", "") > PubConstClass.strReceiptNum(CInt(K)).Replace("-", "") Then
                        strWork = PubConstClass.strReceiptNum(CInt(N))
                        PubConstClass.strReceiptNum(CInt(N)) = PubConstClass.strReceiptNum(CInt(K))
                        PubConstClass.strReceiptNum(CInt(K)) = strWork
                    End If

                Next
            Next N
            ' 最小値を取得する
            PubConstClass.strMinReceiptNum = PubConstClass.strReceiptNum(0)
            ' 最大値を取得する
            PubConstClass.strMaxReceiptNum = PubConstClass.strReceiptNum(CInt(PubConstClass.lngReceiptIndex - 1))

            If strGetFile <> "" Then
                'MsgBox("以下の稼働ファイルを取得しました。" & Constants.vbCrLf & strGetFile, CType(MsgBoxStyle.Information + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認メッセージ")
                strGetFile = strGetFile.Substring(0, strGetFile.LastIndexOf(Constants.vbCr))
                Call OutPutLogFile("以下の稼働ファイルを取得しました。" & Constants.vbCr & strGetFile)
                Call OutPutLogFile("引受番号の最小値：" & PubConstClass.strMinReceiptNum)
                Call OutPutLogFile("引受番号の最大値：" & PubConstClass.strMaxReceiptNum)
            End If

        Catch ex As Exception
            MsgBox("【getRecieptALLInfo】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 引受番号の重複チェック
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub checkDuplication()

        Dim strArray() As String
        Dim strCmpArray() As String
        Dim arKanList As ArrayList = New ArrayList
        Dim arTokList As ArrayList = New ArrayList
        Dim arYouList As ArrayList = New ArrayList

        Dim arKanNukiList As ArrayList = New ArrayList
        Dim arTokNukiList As ArrayList = New ArrayList
        Dim arYouNukiList As ArrayList = New ArrayList

        Dim arKanDupList As ArrayList = New ArrayList
        Dim arTokDupList As ArrayList = New ArrayList
        Dim arYouDupList As ArrayList = New ArrayList

        Try
            Call getSystemIniFile()

            arKanList.Clear()
            arTokList.Clear()
            arYouList.Clear()

            arKanNukiList.Clear()
            arTokNukiList.Clear()
            arYouNukiList.Clear()

            arKanDupList.Clear()
            arTokDupList.Clear()
            arYouDupList.Clear()

            For Each strGetFile As String In
                System.IO.Directory.GetFiles(IncludeTrailingPathDelimiter(PubConstClass.imgPath) &
                                             DateTime.Now.ToString("yyyyMMdd"))
                Call OutPutLogFile("【checkDuplication】取得したファイル：" & strGetFile)

                Using sr As New System.IO.StreamReader(strGetFile, System.Text.Encoding.Default)
                    '    0                 1                  2              3    4    5                                                             6            7       8        9  0    1  2
                    '00001,001：簡易書留郵便,2015/08/18 9:18:36,358-19-00243-5,2356,1490,C:\RECDEL\IMG\20150818\091559\image_20150818_091836_00001.jpg,30：簡易書留,0047-00,広尾支店,47,定形,■
                    Do While Not sr.EndOfStream
                        strArray = sr.ReadLine.Split(","c)
                        ' 種別コードを取得する
                        strCmpArray = strArray(7).Split("："c)
                        Select Case strCmpArray(0)
                            Case "30", "40"
                                ' 簡易書留
                                arKanList.Add(strArray(3))
                                ' 抜取データのチェック
                                If strArray(12) = "■" Then
                                    arKanNukiList.Add(strArray(3))
                                End If
                            Case "50", "60"
                                ' 特定記録
                                arTokList.Add(strArray(3))
                                ' 抜取データのチェック
                                If strArray(12) = "■" Then
                                    arTokNukiList.Add(strArray(3))
                                End If

                            Case "150", "160"
                                ' ゆうメール
                                arYouList.Add(strArray(3))
                                ' 抜取データのチェック
                                If strArray(12) = "■" Then
                                    arYouNukiList.Add(strArray(3))
                                End If

                            Case Else

                        End Select
                    Loop
                End Using
            Next

            ' ソートする前に必ず実行する事
            PubConstClass.arHikiukeKanList = New ArrayList
            PubConstClass.arHikiukeKanList.Clear()
            For N = 0 To arKanList.Count - 1
                PubConstClass.arHikiukeKanList.Add(arKanList.Item(N).ToString)
            Next
            PubConstClass.arHikiukeTokList = New ArrayList
            PubConstClass.arHikiukeTokList.Clear()
            For N = 0 To arTokList.Count - 1
                PubConstClass.arHikiukeTokList.Add(arTokList.Item(N).ToString)
            Next
            PubConstClass.arHikiukeYouList = New ArrayList
            PubConstClass.arHikiukeYouList.Clear()
            For N = 0 To arYouList.Count - 1
                PubConstClass.arHikiukeYouList.Add(arYouList.Item(N).ToString)
            Next

            ' 処理数の格納
            PubConstClass.intTranCountKan = arKanList.Count
            PubConstClass.intTranCountTok = arTokList.Count
            PubConstClass.intTranCountYou = arYouList.Count
            ' 昇順にソートする
            arKanList.Sort()
            arTokList.Sort()
            arYouList.Sort()

            ' 簡易書留の最小引受番号と最大引受番号を取得する
            If arKanList.Count > 0 Then
                PubConstClass.strMinUdrWrtKan = arKanList(0).ToString
                PubConstClass.strMaxUdrWrtKan = arKanList(arKanList.Count - 1).ToString
            Else
                PubConstClass.strMinUdrWrtKan = ""
                PubConstClass.strMaxUdrWrtKan = ""
            End If
            ' 特別記録の最小引受番号と最大引受番号を取得する
            If arTokList.Count > 0 Then
                PubConstClass.strMinUdrWrtTok = arTokList(0).ToString
                PubConstClass.strMaxUdrWrtTok = arTokList(arTokList.Count - 1).ToString
            Else
                PubConstClass.strMinUdrWrtTok = ""
                PubConstClass.strMaxUdrWrtTok = ""
            End If
            ' ゆうメールの最小引受番号と最大引受番号を取得する
            If arYouList.Count > 0 Then
                PubConstClass.strMinUdrWrtYou = arYouList(0).ToString
                PubConstClass.strMaxUdrWrtYou = arYouList(arYouList.Count - 1).ToString
            Else
                PubConstClass.strMinUdrWrtYou = ""
                PubConstClass.strMaxUdrWrtYou = ""
            End If

            ' 重複チェック
            Dim lngStart As Long
            Dim lngEnd As Long
            Dim lngMod As Long

            '/////// 簡易書留の重複及び抜取チェック
            PubConstClass.intUdrWrtDupIndexKan = 0
            PubConstClass.intUdrWrtNukiIndexKan = 0
            If arKanList.Count > 0 Then
                lngStart = CLng(PubConstClass.strMinUdrWrtKan.Replace("-", "").Substring(0, 10))
                lngEnd = CLng(PubConstClass.strMaxUdrWrtKan.Replace("-", "").Substring(0, 10))
                For N = 0 To lngEnd - lngStart
                    lngMod = (lngStart + N) Mod 7
                    arKanDupList.Add((lngStart + N).ToString("000-00-00000") & "-" & lngMod.ToString("0"))
                Next
                For N = 0 To lngEnd - lngStart
                    arKanList.Remove(arKanDupList(CInt(N)).ToString)
                Next
                ' 重複データ設定（簡易書留）
                If arKanList.Count > 0 Then
                    For N = 0 To arKanList.Count - 1
                        PubConstClass.strDupUdrWrtNumKan(N) = arKanList(N).ToString
                        PubConstClass.intUdrWrtDupIndexKan += 1
                    Next
                End If
                ' 抜取データ設定（簡易書留）
                If arKanNukiList.Count > 0 Then
                    For N = 0 To arKanNukiList.Count - 1
                        PubConstClass.strNukUdrWrtNumKan(N) = arKanNukiList(N).ToString
                        PubConstClass.intUdrWrtNukiIndexKan += 1
                    Next
                End If
            End If

            '/////// 特定記録の重複及び抜取チェック
            PubConstClass.intUdrWrtDupIndexTok = 0
            PubConstClass.intUdrWrtNukiIndexTok = 0
            If arTokList.Count > 0 Then
                lngStart = CLng(PubConstClass.strMinUdrWrtTok.Replace("-", "").Substring(0, 10))
                lngEnd = CLng(PubConstClass.strMaxUdrWrtTok.Replace("-", "").Substring(0, 10))
                For N = 0 To lngEnd - lngStart
                    lngMod = (lngStart + N) Mod 7
                    arTokDupList.Add((lngStart + N).ToString("000-00-00000") & "-" & lngMod.ToString("0"))
                Next
                For N = 0 To lngEnd - lngStart
                    arTokList.Remove(arTokDupList(CInt(N)).ToString)
                Next
                ' 重複データ設定（特定記録）
                If arTokList.Count > 0 Then
                    For N = 0 To arTokList.Count - 1
                        PubConstClass.strDupUdrWrtNumTok(N) = arTokList(N).ToString
                        PubConstClass.intUdrWrtDupIndexTok += 1
                    Next
                End If
                ' 抜取データ設定（特定記録）
                If arTokNukiList.Count > 0 Then
                    For N = 0 To arTokNukiList.Count - 1
                        PubConstClass.strNukUdrWrtNumTok(N) = arTokNukiList(N).ToString
                        PubConstClass.intUdrWrtNukiIndexTok += 1
                    Next
                End If
            End If


            '/////// ゆうメールの重複及び抜取チェック
            PubConstClass.intUdrWrtDupIndexYou = 0
            PubConstClass.intUdrWrtNukiIndexYou = 0
            If arYouList.Count > 0 Then
                lngStart = CLng(PubConstClass.strMinUdrWrtYou.Replace("-", "").Substring(0, 10))
                lngEnd = CLng(PubConstClass.strMaxUdrWrtYou.Replace("-", "").Substring(0, 10))
                For N = 0 To lngEnd - lngStart
                    lngMod = (lngStart + N) Mod 7
                    arYouDupList.Add((lngStart + N).ToString("000-00-00000") & "-" & lngMod.ToString("0"))
                Next
                For N = 0 To lngEnd - lngStart
                    arYouList.Remove(arYouDupList(CInt(N)).ToString)
                Next
                ' 重複データ設定（ゆうメール）
                If arYouList.Count > 0 Then
                    For N = 0 To arYouList.Count - 1
                        PubConstClass.strDupUdrWrtNumYou(N) = arYouList(N).ToString
                        PubConstClass.intUdrWrtDupIndexYou += 1
                    Next
                End If
                ' 抜取データ設定（ゆうメール）
                If arYouNukiList.Count > 0 Then
                    For N = 0 To arYouNukiList.Count - 1
                        PubConstClass.strNukUdrWrtNumYou(N) = arYouNukiList(N).ToString
                        PubConstClass.intUdrWrtNukiIndexYou += 1
                    Next
                End If
            End If

        Catch ex As Exception
            MsgBox("【checkDuplication】" & ex.Message)
        Finally
            arKanList = Nothing
            arTokList = Nothing
            arYouList = Nothing

            arKanNukiList = Nothing
            arTokNukiList = Nothing
            arYouNukiList = Nothing

            arKanDupList = Nothing
            arTokDupList = Nothing
            arYouDupList = Nothing
        End Try

    End Sub


    ''' <summary>
    ''' 「保守メニュー」ボタン処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnMaintenance_Click(sender As System.Object, e As System.EventArgs) Handles BtnMaintenance.Click

        Try
            OperatorInputForm.bIsCloseFlag = False
            ' オペレータ入力画面表示
            OperatorInputForm.ShowDialog()

            If PubConstClass.pblIsOkayFlag = True Then

                If PubConstClass.pblOperatorAuthorityh <> "保守員" Then
                    OutPutLogFile("■「保守員」以外の権限では保守メニューは操作できません")
                    MsgBox("「保守員」以外の権限では保守メニューは操作できません", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")
                    Exit Sub
                End If

                If SerialPort.IsOpen = False Then
                    ' シリアルポートのオープン
                    SerialPort.Open()
                End If

                ' シリアルポートにデータ送信（起動コマンド）
                Dim dat As Byte() = System.Text.Encoding.GetEncoding("SHIFT-JIS").GetBytes(PubConstClass.CMD_ACK & vbCr)

                SerialPort.Write(dat, 0, dat.GetLength(0))
                SerialPort.Write(dat, 0, dat.GetLength(0))
                SerialPort.Write(dat, 0, dat.GetLength(0))

                ' シリアルポートのクローズ
                SerialPort.Close()

                OutPutLogFile("〓「保守メニュー」呼び出し〓")
                ' 運用記録ログ格納
                Call OutPutUseLogFile(LblOperatorName.Text & ":「保守メニュー」呼び出し")

                MaintenanceForm.Show()
                'Me.Hide()
            Else
                'Me.Activate()
            End If


        Catch ex As Exception
            MsgBox("【BtnMaintenance_Click】" & ex.Message)
        End Try


    End Sub


    ''' <summary>
    ''' 「受領証発行処理」ボタン処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnReceipPublish_Click(sender As System.Object, e As System.EventArgs) Handles BtnReceipPublish.Click

        Try

            ' シリアルポートのオープン
            SerialPort.Open()

            ' シリアルポートにデータ送信（起動コマンド）
            Dim dat As Byte() = System.Text.Encoding.GetEncoding("SHIFT-JIS").GetBytes(PubConstClass.CMD_ACK & vbCr)

            SerialPort.Write(dat, 0, dat.GetLength(0))
            SerialPort.Write(dat, 0, dat.GetLength(0))
            SerialPort.Write(dat, 0, dat.GetLength(0))

            ' シリアルポートのクローズ
            SerialPort.Close()
            OutPutLogFile("〓「支店選択画面」呼び出し〓")
            ' 運用記録ログ格納
            Call OutPutUseLogFile(LblOperatorName.Text & ":「支店選択画面」呼び出し")

            SelectClassForm.ShowDialog()

            'If PubConstClass.pblIsOkayFlag = True Then
            '    'OutPutLogFile("〓「運転画面」呼び出し〓")
            '    'DrivingForm.Show()
            '    'Me.Hide()
            'End If


            '' オペレータ入力画面表示
            'OperatorInputForm.ShowDialog()

            'If PubConstClass.pblIsOkayFlag = True Then

            '    ' シリアルポートのオープン
            '    SerialPort.Open()

            '    ' シリアルポートにデータ送信（起動コマンド）
            '    Dim dat As Byte() = System.Text.Encoding.GetEncoding("SHIFT-JIS").GetBytes(PubConstClass.CMD_ACK & vbCr)

            '    SerialPort.Write(dat, 0, dat.GetLength(0))
            '    SerialPort.Write(dat, 0, dat.GetLength(0))
            '    SerialPort.Write(dat, 0, dat.GetLength(0))

            '    ' シリアルポートのクローズ
            '    SerialPort.Close()
            '    OutPutLogFile("〓「支店選択画面」呼び出し〓")
            '    ' 運用記録ログ格納
            '    Call OutPutUseLogFile(LblOperatorName.Text & ":「支店選択画面」呼び出し")

            '    SelectClassForm.ShowDialog()

            '    If PubConstClass.pblIsOkayFlag = True Then
            '        'OutPutLogFile("〓「運転画面」呼び出し〓")
            '        'DrivingForm.Show()
            '        'Me.Hide()
            '    End If

            'End If

        Catch ex As Exception
            MsgBox("【BtnReceipPublish_Click】" & ex.Message)
        End Try

    End Sub


    ''' <summary>
    ''' 「リスト・レポート印刷」ボタン処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnListReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnListReport.Click

        Try
            OutPutLogFile("〓「リスト・レポート印刷画面」呼び出し〓")
            ' 運用記録ログ格納
            Call OutPutUseLogFile(LblOperatorName.Text & ":「リスト・レポート印刷画面」呼び出し")

            ListMenuForm.Show()
            Me.Hide()

            '' オペレータ入力画面表示
            'OperatorInputForm.ShowDialog()

            'If PubConstClass.pblIsOkayFlag = True Then
            '    OutPutLogFile("〓「リスト・レポート印刷画面」呼び出し〓")
            '    ' 運用記録ログ格納
            '    Call OutPutUseLogFile(LblOperatorName.Text & ":「リスト・レポート印刷画面」呼び出し")

            '    ListMenuForm.Show()
            '    Me.Hide()

            'End If

        Catch ex As Exception
            MsgBox("【BtnListReport_Click】" & ex.Message)
        End Try

    End Sub


    ''' <summary>
    ''' 「マスターメンテナンス」ボタン処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnMasterMent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMasterMent.Click

        Try
            If PubConstClass.pblOperatorAuthorityh = "一般" Then
                OutPutLogFile("■「一般」の権限ではマスターメンテナンスは操作できません")
                MsgBox("「一般」の権限ではマスターメンテナンスは操作できません", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")
                Exit Sub
            Else
                ' 管理者または保守員が操作可能
                OutPutLogFile("〓「マスターメンテナンス画面」呼び出し〓")
                ' 運用記録ログ格納
                Call OutPutUseLogFile(LblOperatorName.Text & ":「マスターメンテナンス画面」呼び出し")

                MasterMaintForm.Show()
                Me.Hide()
            End If

            '' オペレータ入力画面表示
            'OperatorInputForm.ShowDialog()

            'If PubConstClass.pblIsOkayFlag = True Then

            '    If PubConstClass.pblOperatorAuthorityh = "一般" Then
            '        OutPutLogFile("■「一般」の権限ではマスターメンテナンスは操作できません")
            '        MsgBox("「一般」の権限ではマスターメンテナンスは操作できません", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")
            '        Exit Sub
            '    Else
            '        ' 管理者または保守員が操作可能
            '        OutPutLogFile("〓「マスターメンテナンス画面」呼び出し〓")
            '        ' 運用記録ログ格納
            '        Call OutPutUseLogFile(LblOperatorName.Text & ":「マスターメンテナンス画面」呼び出し")

            '        MasterMaintForm.Show()
            '        Me.Hide()
            '    End If

            'End If

        Catch ex As Exception
            MsgBox("【BtnMasterMent_Click】" & ex.Message)
        End Try

    End Sub


    ''' <summary>
    ''' 「データ確認・抜取り」ボタン処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnDataCheck_Click(sender As System.Object, e As System.EventArgs) Handles BtnDataCheck.Click

        Try
            OutPutLogFile("〓「データ確認・抜取り画面」呼び出し〓")
            ' 運用記録ログ格納
            Call OutPutUseLogFile(LblOperatorName.Text & ":「データ確認・抜取り画面」呼び出し")

            DataCheckForm.ShowDialog()

            '' オペレータ入力画面表示
            'OperatorInputForm.ShowDialog()

            'If PubConstClass.pblIsOkayFlag = True Then
            '    OutPutLogFile("〓「データ確認・抜取り画面」呼び出し〓")
            '    ' 運用記録ログ格納
            '    Call OutPutUseLogFile(LblOperatorName.Text & ":「データ確認・抜取り画面」呼び出し")

            '    DataCheckForm.ShowDialog()
            'End If

        Catch ex As Exception
            MsgBox("【BtnDataCheck_Click】" & ex.Message)
        End Try

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Try

            'Dim bc1 As DotNetBarcode = New DotNetBarcode

            'bc1.Type = DotNetBarcode.Types.Code39
            'bc1.PrintCheckDigitChar = False
            'bc1.WriteBar(TextBox1.Text, 0, 0, PictureBox1.Size.Width, PictureBox1.Size.Height, PictureBox1.CreateGraphics)


            Dim cbar = New ClsBarCode

            cbar.Top = 0
            cbar.Left = 0
            cbar.Block = 1
            cbar.Height = 50
            cbar.Check = True
            cbar.StartChr = "A"
            cbar.StopChr = "A"
            cbar.Code = TextBox1.Text

            cbar.Target = PictureBox1
            cbar.PrintBar()

        Catch ex As Exception
            MsgBox("【Button1_Click】" & ex.Message)
        End Try

    End Sub

    Private Sub lblVersion_Click(sender As System.Object, e As System.EventArgs) Handles lblVersion.Click
        '// lblVersion_DoubleClick 参照
    End Sub

    Private Sub lblVersion_DoubleClick(sender As Object, e As System.EventArgs) Handles lblVersion.DoubleClick

        If Button1.Visible = True Then
            Button1.Visible = False
            PictureBox1.Visible = False
            TextBox1.Visible = False
        Else
            Button1.Visible = True
            PictureBox1.Visible = True
            TextBox1.Visible = True
        End If

    End Sub

    Private Sub BtnLogOut_Click(sender As Object, e As EventArgs) Handles BtnLogOut.Click
        Try
            'Me.Hide()
            Me.Dispose()
            OperatorInputForm.bIsCloseFlag = True
            OperatorInputForm.Show()

        Catch ex As Exception
            MsgBox("【BtnLogOut_Click】" & ex.Message)
        End Try
    End Sub
End Class
