Option Explicit On
Option Strict On

Public Class rePrintForm

    Private intImageDataCount As Integer

    Private objSync As Object
    Private objPrintSync As Object
    Private objPrintSyncReserve As Object


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        MainForm.Show()
        'Me.Hide()
        Me.Dispose()

    End Sub

    Private Sub rePrintForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim intLastPage As Integer
        Dim intDataNum As Integer

        Try

            objSync = New Object
            objPrintSync = New Object
            objPrintSyncReserve = New Object

            intLastPage = CInt(Math.Truncate(PubConstClass.lngReceiptIndex / 15)) + 1
            intDataNum = CInt(PubConstClass.lngReceiptIndex Mod 15)
            If intLastPage > 0 Then
                If CInt(PubConstClass.lngReceiptIndex Mod 15) = 0 Then
                    ' 最終頁が「0」の場合は余りを「0」から「15」にして最終頁を「-1」する。
                    intLastPage = intLastPage - 1
                    intDataNum = 15
                End If
            End If

            ' 最終頁
            lblLastPage.Text = intLastPage.ToString
            ' 最終頁内データ数
            lblDataNum.Text = intDataNum.ToString

            txtStart.Text = ""
            txtEnd.Text = ""
            txtSum.Text = ""

            txtStart.TabIndex = 1
            txtEnd.TabIndex = 2
            rdbOriginal.TabIndex = 3
            rdbReserve.TabIndex = 4
            rdbBoth.TabIndex = 5
            Button1.TabIndex = 6
            Button2.TabIndex = 7

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 「印刷」ボタン処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Try
            ' 空白チェック
            If txtStart.Text = "" Or txtEnd.Text = "" Then
                MsgBox("開始頁または終了頁が空白です。")
                Exit Sub
            End If
            ' 「0」入力チェック
            If CInt(txtStart.Text) = 0 Or CInt(txtEnd.Text) = 0 Then
                MsgBox("「0」が入力されています。")
                Exit Sub
            End If
            ' 大小チェック
            If CInt(txtStart.Text) > CInt(txtEnd.Text) Then
                MsgBox("「開始頁＜終了頁」で入力して下さい。")
                Exit Sub
            End If
            ' 入力範囲外チェック
            If CInt(txtStart.Text) > CInt(lblLastPage.Text) Or CInt(txtEnd.Text) > CInt(lblLastPage.Text) Then
                MsgBox("「1～" & lblLastPage.Text & "」の範囲で入力して下さい。")
                Exit Sub
            End If

            ' 全ての稼動ログから全てのデータを取得する
            Call getTranLogAllInfo()

            If rdbOriginal.Checked = True Then
                PubConstClass.intPrintStatus = 1
                Call rePrinting()

            ElseIf rdbReserve.Checked = True Then
                PubConstClass.intPrintStatus = 2
                Call rePrinting()

            ElseIf rdbBoth.Checked = True Then

                MessageBox.Show("「原符」を印刷します。「OK」をクリックしてください。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)

                PubConstClass.intPrintStatus = 1
                Call rePrinting()

                'While (PubConstClass.lngRePrintIndex < CLng(txtSum.Text))
                '    System.Windows.Forms.Application.DoEvents()
                'End While

                MessageBox.Show("「原符」の印刷終了後に「OK」をクリックしてください。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)

                'If CInt(txtSum.Text) > 900 Then
                '    Timer1.Interval = 1000 * 900
                'Else
                '    Timer1.Interval = 10 * CInt(txtSum.Text)
                'End If
                'Timer1.Enabled = True

                'System.Threading.Thread.Sleep(1000 * 60)

                PubConstClass.intPrintStatus = 2
                Call rePrinting()

            End If

            'Call rePrinting()

            ' 再発行印刷フラグの設定
            'PubConstClass.blnRePrintFlg = True

            Me.Dispose()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 全ての稼動ログから全てのデータを取得し、最後のログデータを採用する
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub getTranLogAllInfo()

        Dim strGetFile As String
        Dim strArray() As String

        Try

            Call getSystemIniFile()

            PubConstClass.lngReceiptIndex = 0

            ' 画像格納フォルダ内の全てのフォルダを取得する
            strGetFile = ""
            For Each tempFile As String In _
                System.IO.Directory.GetFiles(IncludeTrailingPathDelimiter(PubConstClass.imgPath) & _
                                             DateTime.Now.ToString("yyyyMMdd"))
                'Call OutPutLogFile("取得したフォルダ：" & tempFile)
                strGetFile = strGetFile & tempFile & Constants.vbCrLf

                ' 最後の稼動ログを採用するには下記をコメントアウトする
                'PubConstClass.lngReceiptIndex = 0
                'PubConstClass.lngReceiptNGIndex = 0

                Dim strReadData As String

                Using sr As New System.IO.StreamReader(tempFile, System.Text.Encoding.Default)
                    'Debug.Print("〓〓〓〓〓〓〓〓〓〓")
                    Do While Not sr.EndOfStream
                        strReadData = sr.ReadLine
                        strArray = strReadData.Split(","c)
                        'Call OutPutLogFile("（getTranLogAllInfo）OK:" & strReadData)
                        PubConstClass.strReceiptNum(CInt(PubConstClass.lngReceiptIndex)) = strReadData
                        PubConstClass.lngReceiptIndex += 1
                    Loop
                End Using

            Next
            Call OutPutLogFile("■（getTranLogAllInfo）受付番号の数：" & PubConstClass.lngReceiptIndex.ToString)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 受領書再発行処理
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub rePrinting()

        Dim intLoopCnt As Integer

        SyncLock (objPrintSync)

            Try
                PubConstClass.intReceiptKind = 0

                ' 最終頁の存在チェック
                If CInt(txtEnd.Text) = CInt(lblLastPage.Text) Then
                    If CInt(txtSum.Text) = 1 Then
                        ' 総頁数が１頁の場合
                        intImageDataCount = CInt(lblDataNum.Text)
                    Else
                        intImageDataCount = (CInt(txtEnd.Text) - CInt(txtStart.Text)) * 15 + CInt(lblDataNum.Text)
                    End If
                Else
                    ' 最終頁を含まない
                    ' （頁数）×（１頁１５画像）の設定
                    'intImageDataCount = (CInt(txtEnd.Text) - CInt(txtStart.Text) + 1) * 15
                    intImageDataCount = CInt(txtEnd.Text) * 15
                End If

                PubConstClass.lngImageDataCount = intImageDataCount

                Select Case PubConstClass.intPrintStatus

                    Case 1
                        ' 受領書の種類（0：原符／1：控え）
                        PubConstClass.intReceiptKind = 0
                        ' ページ番号の初期化
                        PubConstClass.lngRePrintIndex = CLng(txtStart.Text) - 1

                        ' WaitCallbackデリゲートを作成
                        Dim waitCallbackOrigin As New System.Threading.WaitCallback(AddressOf ThreadMethodPrintOrigin)

                        For intLoopCnt = CInt(txtStart.Text) To CInt(txtEnd.Text)
                            ' スレッドプールに登録
                            System.Threading.ThreadPool.QueueUserWorkItem(waitCallbackOrigin, "A" & intLoopCnt.ToString)
                            'System.Threading.Thread.Sleep(500)
                        Next

                    Case 2
                        ' 受領書の種類（0：原符／1：控え）
                        PubConstClass.intReceiptKind = 1
                        ' ページ番号の初期化
                        PubConstClass.lngPrintIndexReserve = CLng(txtStart.Text) - 1

                        ' WaitCallbackデリゲートを作成
                        Dim waitCallbackReserve As New System.Threading.WaitCallback(AddressOf ThreadMethodPrintReserve)

                        For intLoopCnt = CInt(txtStart.Text) To CInt(txtEnd.Text)
                            ' スレッドプールに登録
                            System.Threading.ThreadPool.QueueUserWorkItem(waitCallbackReserve, "B" & intLoopCnt.ToString)
                            'System.Threading.Thread.Sleep(500)
                        Next

                    Case 3

                        '' 原符の頁番号の初期化
                        'PubConstClass.lngRePrintIndex = 0

                        'For intLoopCnt = CInt(txtStart.Text) To CInt(txtEnd.Text)
                        '    ' 受領書の種類（0：原符／1：控え）
                        '    PubConstClass.intReceiptKind = 0
                        '    ' スレッドプールに登録
                        '    System.Threading.ThreadPool.QueueUserWorkItem(waitCallbackOrigin, "A" & intLoopCnt.ToString)

                        'Next

                        ''System.Threading.Thread.Sleep(2000)

                        '' 控えの頁番号の初期化
                        'PubConstClass.lngPrintIndexReserve = 0
                        'For intLoopCnt = CInt(txtStart.Text) To CInt(txtEnd.Text)

                        '    ' 受領書の種類（0：原符／1：控え）
                        '    PubConstClass.intReceiptKind = 1
                        '    ' スレッドプールに登録
                        '    System.Threading.ThreadPool.QueueUserWorkItem(waitCallbackReserve, "B" & intLoopCnt.ToString)

                        'Next

                End Select

            Catch ex As Exception
                MsgBox("(rePrinting)" & ex.Message)
            End Try

        End SyncLock

    End Sub

    ''' <summary>
    ''' 別スレッドで原符の印刷処理を実行
    ''' </summary>
    ''' <param name="state"></param>
    ''' <remarks></remarks>
    Private Sub ThreadMethodPrintOrigin(ByVal state As Object)

        SyncLock (objPrintSync)

            Try
                PubConstClass.intReceiptKind = 0
                PubConstClass.lngRePrintIndex += 1
                Call OutPutLogFile("■ThreadMethodPrintOrigin：" & PubConstClass.lngRePrintIndex.ToString)
                If PubConstClass.lngRePrintIndex * 15 <= PubConstClass.lngImageDataCount Then
                    intImageDataCount = 15
                Else
                    intImageDataCount = CInt(PubConstClass.lngImageDataCount Mod 15)
                End If
                PrintDocument1.DocumentName = "受領書（原符）の印刷"
                PrintDocument1.Print()
                Console.Write(" {0} ", state)
                'Call OutPutLogFile("■ThreadMethodPrint：" & state.ToString)
            Catch ex As Exception
                MsgBox("(ThreadMethodPrintOrigin)" & ex.Message)
            End Try

        End SyncLock

    End Sub

    ''' <summary>
    ''' 別スレッドで控えの印刷処理を実行
    ''' </summary>
    ''' <param name="state"></param>
    ''' <remarks></remarks>
    Private Sub ThreadMethodPrintReserve(ByVal state As Object)

        SyncLock (objPrintSync)

            Try
                PubConstClass.intReceiptKind = 1
                PubConstClass.lngPrintIndexReserve += 1
                Call OutPutLogFile("■ThreadMethodPrintReserve：" & PubConstClass.lngPrintIndexReserve.ToString)
                If PubConstClass.lngPrintIndexReserve * 15 <= PubConstClass.lngImageDataCount Then
                    intImageDataCount = 15
                Else
                    intImageDataCount = CInt(PubConstClass.lngImageDataCount Mod 15)
                End If

                PrintDocument1.DocumentName = "受領書（控え）の印刷"
                PrintDocument1.Print()
                Console.Write(" {0} ", state)
                'Call OutPutLogFile("■ThreadMethodPrint：" & state.ToString)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End SyncLock


    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage

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

        'SyncLock (objPrintSync)

        Try
            ' 印刷画像の大きさ設定
            intIMGYoko = 248    ' ≒1980÷8（1/8サイズ）
            intIMGTate = 140    ' ≒1080÷8（1/8サイズ）
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
            e.Graphics.DrawString(PubConstClass.strPubPostName & " 承認", f, Brushes.Black, 600, intMargin * 1)
            e.Graphics.DrawRectangle(New Pen(Color.Black), New Rectangle(20, intMargin * 1, 65, 30))
            If PubConstClass.strPubKind = "0" Then
                e.Graphics.DrawString("簡易", h, Brushes.Black, 30, intMargin * 1)
            Else
                e.Graphics.DrawString("配達", h, Brushes.Black, 30, intMargin * 1)
            End If
            If PubConstClass.intReceiptKind = 0 Then
                e.Graphics.DrawString("書留郵便物受領証　原符", h, Brushes.Black, 100, intMargin * 2)
            Else
                e.Graphics.DrawString("書留郵便物受領証", h, Brushes.Black, 100, intMargin * 2)
            End If

            ' ヘッダー２行目
            e.Graphics.DrawString(dtNow.ToString("yyyy年 MM月 dd日"), f, Brushes.Black, 600, intMargin * 3)

            'e.Graphics.DrawString("Page " & PubConstClass.lngRePrintIndex.ToString, f, Brushes.Black, 750, intMargin * 3)


            'hayakawa
            If PubConstClass.intReceiptKind = 0 Then
                e.Graphics.DrawString("Page " & PubConstClass.lngRePrintIndex.ToString, f, Brushes.Black, 750, intMargin * 3)
                '    Call OutPutLogFile("【原符】頁：" & PubConstClass.lngRePrintIndex)
            Else
                e.Graphics.DrawString("Page " & PubConstClass.lngPrintIndexReserve.ToString, f, Brushes.Black, 750, intMargin * 3)
                '    Call OutPutLogFile("【控え】頁：" & PubConstClass.lngPrintIndexReserve)
            End If


            ' 罫線の印刷
            'e.Graphics.DrawLine(New Pen(Color.Black), intSTPosYoko, intMargin * 5, intLineWidth, intMargin * 5)
            PrintDocument1.DocumentName = "受領書　再印刷"

            For N = 1 To 5

                '// １段目の画像の枠作成
                e.Graphics.DrawRectangle(New Pen(Color.Black), New Rectangle(intSTPosYoko + intYoko * 0 + intMargin * 0, intSTPosTate + intTate * (N - 1), intYoko, intTate))
                e.Graphics.DrawRectangle(New Pen(Color.Black), New Rectangle(intSTPosYoko + intYoko * 1 + intMargin * 1, intSTPosTate + intTate * (N - 1), intYoko, intTate))
                e.Graphics.DrawRectangle(New Pen(Color.Black), New Rectangle(intSTPosYoko + intYoko * 2 + intMargin * 2, intSTPosTate + intTate * (N - 1), intYoko, intTate))
                '// １段目の１行目文字列の作成
                e.Graphics.DrawRectangle(New Pen(Color.Black), New Rectangle(intSTPosYoko + intYoko * 0 + intMargin * 0, intSTPosTate + intTate * N, intYoko, intTateChr1))
                e.Graphics.DrawRectangle(New Pen(Color.Black), New Rectangle(intSTPosYoko + intYoko * 1 + intMargin * 1, intSTPosTate + intTate * N, intYoko, intTateChr1))
                e.Graphics.DrawRectangle(New Pen(Color.Black), New Rectangle(intSTPosYoko + intYoko * 2 + intMargin * 2, intSTPosTate + intTate * N, intYoko, intTateChr1))
                '// １段目の２行目文字列の枠作成
                e.Graphics.DrawRectangle(New Pen(Color.Black), New Rectangle(intSTPosYoko + intYoko * 0 + intMargin * 0, intSTPosTate + intTate * N + intTateChr1 * 1, intYoko, intTateChr2))
                e.Graphics.DrawRectangle(New Pen(Color.Black), New Rectangle(intSTPosYoko + intYoko * 1 + intMargin * 1, intSTPosTate + intTate * N + intTateChr1 * 1, intYoko, intTateChr2))
                e.Graphics.DrawRectangle(New Pen(Color.Black), New Rectangle(intSTPosYoko + intYoko * 2 + intMargin * 2, intSTPosTate + intTate * N + intTateChr1 * 1, intYoko, intTateChr2))
                '// 「引受番号」の枠作成
                e.Graphics.DrawRectangle(New Pen(Color.Black), New Rectangle(intSTPosYoko + intYoko * 0 + intMargin * 0, intSTPosTate + intTate * N, intChrPos1, intTateChr1 + intTateChr2))
                e.Graphics.DrawRectangle(New Pen(Color.Black), New Rectangle(intSTPosYoko + intYoko * 0 + intMargin * 0, intSTPosTate + intTate * N, intChrPos2, intTateChr1 + intTateChr2))
                e.Graphics.DrawRectangle(New Pen(Color.Black), New Rectangle(intSTPosYoko + intYoko * 0 + intMargin * 0, intSTPosTate + intTate * N, intChrPos3, intTateChr1 + intTateChr2))
                e.Graphics.DrawString("引受番号", f, Brushes.Black, intSTPosYoko + intYoko * 0 + intMargin * 2, intSTPosTate + intTate * N)
                e.Graphics.DrawString("引受番号", f, Brushes.Black, intSTPosYoko + intYoko * 1 + intMargin * 3, intSTPosTate + intTate * N)
                e.Graphics.DrawString("引受番号", f, Brushes.Black, intSTPosYoko + intYoko * 2 + intMargin * 4, intSTPosTate + intTate * N)
                '// 「重量」の枠作成
                e.Graphics.DrawRectangle(New Pen(Color.Black), New Rectangle(intSTPosYoko + intYoko * 1 + intMargin * 1, intSTPosTate + intTate * N, intChrPos1, intTateChr1 + intTateChr2))
                e.Graphics.DrawRectangle(New Pen(Color.Black), New Rectangle(intSTPosYoko + intYoko * 1 + intMargin * 1, intSTPosTate + intTate * N, intChrPos2, intTateChr1 + intTateChr2))
                e.Graphics.DrawRectangle(New Pen(Color.Black), New Rectangle(intSTPosYoko + intYoko * 1 + intMargin * 1, intSTPosTate + intTate * N, intChrPos3, intTateChr1 + intTateChr2))
                e.Graphics.DrawString("重量", f, Brushes.Black, intSTPosYoko + intYoko * 0 + intChrPos1 + intMargin * 1 - intOffSet, intSTPosTate + intTate * N)
                e.Graphics.DrawString("重量", f, Brushes.Black, intSTPosYoko + intYoko * 1 + intChrPos1 + intMargin * 2 - intOffSet, intSTPosTate + intTate * N)
                e.Graphics.DrawString("重量", f, Brushes.Black, intSTPosYoko + intYoko * 2 + intChrPos1 + intMargin * 3 - intOffSet, intSTPosTate + intTate * N)
                '// 「要償額」の枠作成（残りが「摘要」の枠となる）
                e.Graphics.DrawRectangle(New Pen(Color.Black), New Rectangle(intSTPosYoko + intYoko * 2 + intMargin * 2, intSTPosTate + intTate * N, intChrPos1, intTateChr1 + intTateChr2))
                e.Graphics.DrawRectangle(New Pen(Color.Black), New Rectangle(intSTPosYoko + intYoko * 2 + intMargin * 2, intSTPosTate + intTate * N, intChrPos2, intTateChr1 + intTateChr2))
                e.Graphics.DrawRectangle(New Pen(Color.Black), New Rectangle(intSTPosYoko + intYoko * 2 + intMargin * 2, intSTPosTate + intTate * N, intChrPos3, intTateChr1 + intTateChr2))
                e.Graphics.DrawString("要償額", f, Brushes.Black, intSTPosYoko + intYoko * 0 + intChrPos2 + intMargin * 0, intSTPosTate + intTate * N)
                e.Graphics.DrawString("要償額", f, Brushes.Black, intSTPosYoko + intYoko * 1 + intChrPos2 + intMargin * 1, intSTPosTate + intTate * N)
                e.Graphics.DrawString("要償額", f, Brushes.Black, intSTPosYoko + intYoko * 2 + intChrPos2 + intMargin * 2, intSTPosTate + intTate * N)

                e.Graphics.DrawString("摘要", f, Brushes.Black, intSTPosYoko + intYoko * 0 + intChrPos3 + intMargin * 1 - intOffSet, intSTPosTate + intTate * N)
                e.Graphics.DrawString("摘要", f, Brushes.Black, intSTPosYoko + intYoko * 1 + intChrPos3 + intMargin * 2 - intOffSet, intSTPosTate + intTate * N)
                e.Graphics.DrawString("摘要", f, Brushes.Black, intSTPosYoko + intYoko * 2 + intChrPos3 + intMargin * 3 - intOffSet, intSTPosTate + intTate * N)

                ' 縦方向画像印字位置設定
                intYPos(N - 1) = intSTPosTate + intTate * (N - 1) + CInt(intMargin / 2)

                ' 印刷開始ポジションを１段下に下げる
                intSTPosTate = intSTPosTate + intTateChr1 + intTateChr2 + intMargin

            Next N

            ' 印刷開始ポジションを１段下に下げる
            intYPos(5) = intSTPosTate + intTate * 5
            ' フッターの印刷
            Dim ft As New Font("メイリオ", 9, FontStyle.Regular)
            e.Graphics.DrawRectangle(New Pen(Color.Black), New Rectangle(intSTPosYoko, intYPos(5), intLineWidth - 10, intMargin * 3))
            e.Graphics.DrawRectangle(New Pen(Color.Black), New Rectangle(intSTPosYoko, intYPos(5), intLineWidth - 10, intMargin * 9))
            e.Graphics.DrawRectangle(New Pen(Color.Black), New Rectangle(intSTPosYoko, intYPos(5), intLineWidth - 10 - 100, intMargin * 9))
            e.Graphics.DrawString("(差出人の住所及び氏名)　" & PubConstClass.strPubAddress1 & PubConstClass.strPubAddress2, ft, Brushes.Black, intSTPosYoko, intYPos(5))
            e.Graphics.DrawString(PubConstClass.strPubName, ft, Brushes.Black, intSTPosYoko + 200, intYPos(5) + intMargin + 2)
            e.Graphics.DrawString("引受日付印", ft, Brushes.Black, intLineWidth - 10 - 60, intYPos(5) + intMargin * 1)

            ' 横方向印字位置設定
            intXPos(0) = intSTPosYoko + CInt(intMargin / 2)
            intXPos(1) = intSTPosYoko + CInt(intMargin / 2) + intYoko + intMargin
            intXPos(2) = intSTPosYoko + CInt(intMargin / 2) + intYoko + intMargin + intYoko + intMargin

            Dim index_X As Integer
            Dim index_Y As Integer
            Dim strPrintFileName(15) As String
            Dim strAcceptNumber As String

            strAcceptNumber = ""
            ' １ページ１５画像印字
            For intLoopCnt = 0 To 15 - 1

                'intGetIndex = intLoopCnt + CInt(PubConstClass.lngRePrintIndex - 1) * 15

                ' hayakawa
                If PubConstClass.intReceiptKind = 0 Then
                    intGetIndex = intLoopCnt + CInt(PubConstClass.lngRePrintIndex - 1) * 15
                    'Call OutPutLogFile("【原符】" & PubConstClass.lngRePrintIndex)
                Else
                    intGetIndex = intLoopCnt + CInt(PubConstClass.lngPrintIndexReserve - 1) * 15
                    'Call OutPutLogFile("【控え】" & PubConstClass.lngPrintIndexReserve)
                End If

                Dim strArray() As String
                strArray = PubConstClass.strReceiptNum(intGetIndex).Split(","c)

                ' 画像ファイル名の取得
                strPrintFileName(intLoopCnt) = strArray(4)
                ' 引受番号の取得
                strAcceptNumber = strArray(3)

                Dim intModVal As Integer
                Dim intDivVal As Integer

                intModVal = intLoopCnt Mod 3
                intDivVal = CInt(Math.Truncate(intLoopCnt / 3))
                Select Case intModVal
                    Case 0
                        ' 引受番号印字
                        e.Graphics.DrawString(strAcceptNumber, f, Brushes.Black, intSTPosYoko + intYoko * 0 + intMargin * 0, intYPos(intDivVal) + intTate + intTateChr1 - CInt(intMargin / 2))
                        ' 重量印字
                        e.Graphics.DrawString(strArray(5), f, Brushes.Black, intSTPosYoko + intYoko * 0 + intChrPos1 + intMargin * 1 - intOffSet, intYPos(intDivVal) + intTate + intTateChr1 - CInt(intMargin / 2))
                    Case 1
                        ' 引受番号印字
                        e.Graphics.DrawString(strAcceptNumber, f, Brushes.Black, intSTPosYoko + intYoko * 1 + intMargin * 1, intYPos(intDivVal) + intTate + intTateChr1 - CInt(intMargin / 2))
                        ' 重量印字
                        e.Graphics.DrawString(strArray(5), f, Brushes.Black, intSTPosYoko + intYoko * 1 + intChrPos1 + intMargin * 2 - intOffSet, intYPos(intDivVal) + intTate + intTateChr1 - CInt(intMargin / 2))
                    Case 2
                        ' 引受番号印字
                        e.Graphics.DrawString(strAcceptNumber, f, Brushes.Black, intSTPosYoko + intYoko * 2 + intMargin * 2, intYPos(intDivVal) + intTate + intTateChr1 - CInt(intMargin / 2))
                        ' 重量印字
                        e.Graphics.DrawString(strArray(5), f, Brushes.Black, intSTPosYoko + intYoko * 2 + intChrPos1 + intMargin * 3 - intOffSet, intYPos(intDivVal) + intTate + intTateChr1 - CInt(intMargin / 2))
                End Select

                If System.IO.File.Exists(strPrintFileName(intLoopCnt)) = True Then
                    ' 画像ファイルが存在する
                    img(intLoopCnt) = Image.FromFile(strPrintFileName(intLoopCnt))
                Else
                    ' 画像ファイルが存在しない場合
                    img(intLoopCnt) = Image.FromFile(IncludeTrailingPathDelimiter(Application.StartupPath) & "noimage.jpg")
                End If

                index_X = intLoopCnt Mod 3
                index_Y = CInt(Math.Truncate(intLoopCnt / 3))
                e.Graphics.DrawImage(img(intLoopCnt), New Rectangle(intXPos(index_X), intYPos(index_Y), intIMGYoko, intIMGTate))
                If (intLoopCnt + 1) Mod 3 = 0 Then
                    'e.Graphics.DrawString(strAcceptNumber, font, Brushes.Black, e.MarginBounds, StringFormat.GenericTypographic)
                    strAcceptNumber = ""
                End If

                '// 2014.05.19 hayakawa 修正↓ここから
                ''intImageDataCount = intImageDataCount - 1
                ''If intImageDataCount < 1 Then
                ''    Exit For
                ''End If
                PubConstClass.lngImageDataCount = PubConstClass.lngImageDataCount - 1
                If PubConstClass.lngImageDataCount < 1 Then
                    Exit For
                End If
                '// 2014.05.19 hayakawa 修正↑ここまで


            Next intLoopCnt

            e.HasMorePages = False

            'If intImageDataCount > 0 Then
            '    e.HasMorePages = True
            '    ' 頁数を＋１する
            '    PubConstClass.lngPrintIndex += 1
            '    'intPrintImageIndex = intPrintImageIndex + 1
            'Else
            '    e.HasMorePages = False
            'End If

        Catch ex As Exception
            MsgBox("(PrintDocument1_PrintPage)" & ex.Message)
        End Try

        'End SyncLock

    End Sub

    Private Sub txtStart_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtStart.KeyPress

        ' 「BS」の場合はキャンセルしない
        If e.KeyChar = Constants.vbBack Then
            Exit Sub
        End If

        ' 押されたキーが「0～9」以外の場合は入力をキャンセルする
        If e.KeyChar < "0"c Or e.KeyChar > "9"c Then
            e.Handled = True
        End If



    End Sub

    Private Sub txtEnd_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEnd.KeyPress

        ' 「BS」の場合はキャンセルしない
        If e.KeyChar = Constants.vbBack Then
            Exit Sub
        End If

        ' 押されたキーが「0～9」以外の場合は入力をキャンセルする
        If e.KeyChar < "0"c Or e.KeyChar > "9"c Then
            e.Handled = True
        End If

    End Sub

    Private Sub txtStart_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtStart.KeyUp

        Debug.Print("START：" & txtStart.Text)
        Debug.Print("START：" & txtEnd.Text)

        If txtStart.Text <> "" And txtEnd.Text <> "" Then
            If CInt(txtEnd.Text) >= CInt(txtStart.Text) Then
                txtSum.Text = (CInt(txtEnd.Text) - CInt(txtStart.Text) + 1).ToString
            End If
        End If

    End Sub

    Private Sub txtEnd_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEnd.KeyUp

        Debug.Print("END：" & txtStart.Text)
        Debug.Print("END：" & txtEnd.Text)

        If txtStart.Text <> "" And txtEnd.Text <> "" Then
            If CInt(txtEnd.Text) >= CInt(txtStart.Text) Then
                txtSum.Text = (CInt(txtEnd.Text) - CInt(txtStart.Text) + 1).ToString
            End If
        End If

    End Sub

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        PubConstClass.intPrintStatus = 2
        Call rePrinting()

        Timer1.Enabled = False

    End Sub

End Class