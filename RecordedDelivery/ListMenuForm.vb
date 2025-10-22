Option Explicit On
Option Strict On

Public Class ListMenuForm

    ''' <summary>
    ''' フォームアクティブ処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ListMenuForm_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated

        ' オペレータ情報の表示
        LblOperatorName.Text = GetOperatorInfomation()

    End Sub

    ''' <summary>
    ''' 「×」ボタンのキャンセル
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ListMenuForm_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        ' 「×」ボタンのキャンセル
        e.Cancel = True

    End Sub


    ''' <summary>
    ''' フォームロード処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ListMenuForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try

        Catch ex As Exception
            MsgBox("【ListMenuForm_Load】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 「戻る」ボタン処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBack.Click

        Try
            MsgBoxForm.strMessage = "メインメニューに戻りますか？"
            ' 確認メッセージの表示
            MsgBoxForm.ShowDialog()

            If MsgBoxForm.blnRetValMsgBox = True Then
                OutPutLogFile("〓「メインメニューに戻る」呼び出し〓")
                MainForm.Show()
                Me.Hide()
            End If

        Catch ex As Exception
            MsgBox("【BtnBack_Click】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 「支店集計表」ボタン処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnBranchTotal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBranchTotal.Click

        OutPutLogFile("〓「支店集計表画面」呼び出し〓")
        ' 運用記録ログ格納
        Call OutPutUseLogFile(LblOperatorName.Text & ":「支店集計表画面」呼び出し")
        BranchTotalForm.ShowDialog()

    End Sub

    ''' <summary>
    ''' 「集計ＣＳＶ出力」ボタン処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnCsvOutPut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCsvOutPut.Click

        OutPutLogFile("〓「集計ＣＳＶ出力画面」呼び出し〓")
        ' 運用記録ログ格納
        Call OutPutUseLogFile(LblOperatorName.Text & ":「集計ＣＳＶ出力画面」呼び出し")
        CsvOutPutForm.ShowDialog()

    End Sub

    ''' <summary>
    ''' 「集計ＣＳＶ取込」ボタン処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnCsvInPut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCsvInPut.Click

        OutPutLogFile("〓「集計ＣＳＶ取込画面」呼び出し〓")
        CsvInPutForm.ShowDialog()

    End Sub

    ''' <summary>
    ''' 「欠番確認表」ボタン処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnConfirmKetuban_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnConfirmKetuban.Click

        OutPutLogFile("〓「欠番確認表画面」呼び出し〓")
        ' 運用記録ログ格納
        Call OutPutUseLogFile(LblOperatorName.Text & ":「欠番確認表画面」呼び出し")
        ConfirmKetubanForm.ShowDialog()

    End Sub


    ''' <summary>
    ''' 「作業日報」ボタン処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnJobDayReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnJobDayReport.Click

        Dim lngTempLoopCnt As Long
        Dim lngTempLoopCntNuk As Long

        Try
            ' 運用記録ログ格納
            Call OutPutUseLogFile(LblOperatorName.Text & ":「作業日報」呼び出し")

            ' フォルダ名称を取得する
            Dim strReadFolder As String = DateTime.Now.ToString("yyyyMMdd")

            ' 格納フォルダ名の設定
            strReadFolder = IncludeTrailingPathDelimiter(PubConstClass.imgPath) & strReadFolder & "\"

            ' 格納フォルダ配下の稼働ファイルの存在確認
            If System.IO.Directory.Exists(strReadFolder) = False Then
                MsgBox("印刷するデータがありません。", CType(MsgBoxStyle.Information + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認メッセージ")
                Exit Sub
            End If

            Dim varRet As VariantType
            varRet = CType(MsgBox("作業日報の内容を確認しますか？", CType(MsgBoxStyle.Question + MsgBoxStyle.OkCancel, MsgBoxStyle), "印刷確認"), VariantType)
            If varRet = vbCancel Then
                Exit Sub
            End If

            OutPutLogFile("〓「作業日報」呼び出し〓")
            With MainForm
                ' 重複チェック
                Call .checkDuplication()

                Dim strStartArray() As String
                Dim strEndArray() As String

                ' 簡易書留の番号帯の最終引受番号が存在するかチェック
                If PubConstClass.arHikiukeKanList.Count > 0 Then
                    strStartArray = PubConstClass.strStartNumber(0).Split(","c)
                    strEndArray = PubConstClass.strEndNumber(0).Split(","c)
                    If CDbl(PubConstClass.arHikiukeKanList.Item(0).ToString.Replace("-", "")) > _
                       CDbl(PubConstClass.arHikiukeKanList.Item(PubConstClass.arHikiukeKanList.Count - 1).ToString.Replace("-", "")) Then
                        PubConstClass.strMinUdrWrtKan = PubConstClass.arHikiukeKanList.Item(0).ToString & " ～ " & strEndArray(1)
                        PubConstClass.strMaxUdrWrtKan = strStartArray(1) & " ～ " & _
                            PubConstClass.arHikiukeKanList.Item(PubConstClass.arHikiukeKanList.Count - 1).ToString
                    End If
                End If

                ' 特定記録の番号帯の最終引受番号が存在するかチェック
                If PubConstClass.arHikiukeTokList.Count > 0 Then
                    strStartArray = PubConstClass.strStartNumber(1).Split(","c)
                    strEndArray = PubConstClass.strEndNumber(1).Split(","c)
                    If CDbl(PubConstClass.arHikiukeTokList.Item(0).ToString.Replace("-", "")) > _
                       CDbl(PubConstClass.arHikiukeTokList.Item(PubConstClass.arHikiukeTokList.Count - 1).ToString.Replace("-", "")) Then
                        PubConstClass.strMinUdrWrtTok = PubConstClass.arHikiukeTokList.Item(0).ToString & " ～ " & strEndArray(1)
                        PubConstClass.strMaxUdrWrtTok = strStartArray(1) & " ～ " & _
                            PubConstClass.arHikiukeTokList.Item(PubConstClass.arHikiukeTokList.Count - 1).ToString
                    End If
                End If

                ' ゆうメールの番号帯の最終引受番号が存在するかチェック
                If PubConstClass.arHikiukeYouList.Count > 0 Then
                    strStartArray = PubConstClass.strStartNumber(2).Split(","c)
                    strEndArray = PubConstClass.strEndNumber(2).Split(","c)
                    If CDbl(PubConstClass.arHikiukeYouList.Item(0).ToString.Replace("-", "")) > _
                       CDbl(PubConstClass.arHikiukeYouList.Item(PubConstClass.arHikiukeYouList.Count - 1).ToString.Replace("-", "")) Then
                        PubConstClass.strMinUdrWrtYou = PubConstClass.arHikiukeYouList.Item(0).ToString & " ～ " & strEndArray(1)
                        PubConstClass.strMaxUdrWrtYou = strStartArray(1) & " ～ " & _
                            PubConstClass.arHikiukeYouList.Item(PubConstClass.arHikiukeYouList.Count - 1).ToString
                    End If
                End If

                'PrintDocumentオブジェクトの作成
                Dim pd As New System.Drawing.Printing.PrintDocument
                'PrintPageイベントハンドラの追加
                AddHandler pd.PrintPage, AddressOf .PrintDocument1_PrintPage

                ' PrintPreviewDialogオブジェクトの作成
                Dim ppd As New PrintPreviewDialog
                ppd.Width = 1200
                ppd.Height = 1000
                ' プレビューオブジェクトの「印刷」ボタン削除
                Dim tool As ToolStrip = CType(ppd.Controls(1), ToolStrip)
                tool.Items.RemoveAt(0)

                ' 印字ページインデックスの初期化
                PubConstClass.lngPrintIndexKan = 0
                PubConstClass.lngPrintIndexTok = 0
                PubConstClass.lngPrintIndexYou = 0
                PubConstClass.lngPrintIndexKanNuk = 0
                PubConstClass.lngPrintIndexTokNuk = 0
                PubConstClass.lngPrintIndexYouNuk = 0

                ' 重複件数用の引受番号カウンタ
                lngTempLoopCnt = PubConstClass.intUdrWrtDupIndexKan
                PubConstClass.lngLoopCntKan = lngTempLoopCnt
                ' 抜取件数用の引受番号カウンタ
                lngTempLoopCntNuk = PubConstClass.intUdrWrtNukiIndexKan
                PubConstClass.lngLoopCntKanNuk = lngTempLoopCntNuk

                ' 重複件数用の引受番号カウンタ
                lngTempLoopCnt = PubConstClass.intUdrWrtDupIndexTok
                PubConstClass.lngLoopCntTok = lngTempLoopCnt
                ' 抜取件数用の引受番号カウンタ
                lngTempLoopCntNuk = PubConstClass.intUdrWrtNukiIndexTok
                PubConstClass.lngLoopCntTokNuk = lngTempLoopCntNuk

                ' 重複件数用の引受番号カウンタ
                lngTempLoopCnt = PubConstClass.intUdrWrtDupIndexYou
                PubConstClass.lngLoopCntYou = lngTempLoopCnt
                ' 抜取件数用の引受番号カウンタ
                lngTempLoopCntNuk = PubConstClass.intUdrWrtNukiIndexYou
                PubConstClass.lngLoopCntYouNuk = lngTempLoopCntNuk

                PubConstClass.blnIsDispKan = False
                PubConstClass.blnIsDispKanNuk = True
                PubConstClass.blnIsDispTok = True
                PubConstClass.blnIsDispTokNuk = True
                PubConstClass.blnIsDispYou = True
                PubConstClass.blnIsDispYouNuk = True

                ' 印刷機能番号
                PubConstClass.intPrintFuncNo = 2                

                ' プレビューするPrintDocumentを設定
                ppd.Document = pd
                ' 印刷プレビューダイアログを表示する
                ppd.ShowDialog()
                ' PrintPreviewDialogオブジェクトの解放
                ppd.Dispose()


                varRet = CType(MsgBox("作業日報を印刷しますか？", CType(MsgBoxStyle.Question + MsgBoxStyle.OkCancel, MsgBoxStyle), "印刷確認"), VariantType)
                If varRet = vbCancel Then
                    Exit Sub
                End If

                ' 印字ページインデックスの初期化
                PubConstClass.lngPrintIndexKan = 0
                PubConstClass.lngPrintIndexTok = 0
                PubConstClass.lngPrintIndexYou = 0
                PubConstClass.lngPrintIndexKanNuk = 0
                PubConstClass.lngPrintIndexTokNuk = 0
                PubConstClass.lngPrintIndexYouNuk = 0


                ' 重複件数用の引受番号カウンタ
                lngTempLoopCnt = PubConstClass.intUdrWrtDupIndexKan
                PubConstClass.lngLoopCntKan = lngTempLoopCnt
                ' 抜取件数用の引受番号カウンタ
                lngTempLoopCntNuk = PubConstClass.intUdrWrtNukiIndexKan
                PubConstClass.lngLoopCntKanNuk = lngTempLoopCntNuk

                ' 重複件数用の引受番号カウンタ
                lngTempLoopCnt = PubConstClass.intUdrWrtDupIndexTok
                PubConstClass.lngLoopCntTok = lngTempLoopCnt
                ' 抜取件数用の引受番号カウンタ
                lngTempLoopCntNuk = PubConstClass.intUdrWrtNukiIndexTok
                PubConstClass.lngLoopCntTokNuk = lngTempLoopCntNuk

                ' 重複件数用の引受番号カウンタ
                lngTempLoopCnt = PubConstClass.intUdrWrtDupIndexYou
                PubConstClass.lngLoopCntYou = lngTempLoopCnt
                ' 抜取件数用の引受番号カウンタ
                lngTempLoopCntNuk = PubConstClass.intUdrWrtNukiIndexYou
                PubConstClass.lngLoopCntYouNuk = lngTempLoopCntNuk

                PubConstClass.blnIsDispKan = False
                PubConstClass.blnIsDispKanNuk = True
                PubConstClass.blnIsDispTok = True
                PubConstClass.blnIsDispTokNuk = True
                PubConstClass.blnIsDispYou = True
                PubConstClass.blnIsDispYouNuk = True

                PubConstClass.intPrintFuncNo = 2
                .PrintDocument1.DocumentName = "作業日報の印刷"
                .PrintDocument1.Print()

            End With

        Catch ex As Exception
            MsgBox("【BtnJobDayReport_Click】" & ex.Message)
        End Try

    End Sub


    ''' <summary>
    ''' 「運用記録リスト」ボタン処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnJobRecordList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnJobRecordList.Click

        Dim strReadFolder As String
        Dim strReadFileName As String
        Dim strYYYYMMDDvalue As String

        Try
            ' 運用記録ログ格納
            Call OutPutUseLogFile(LblOperatorName.Text & ":「運用記録リスト」呼び出し")

            Dim dtNow As DateTime = DateTime.Now

            ' 指定した書式で日付を文字列に変換する
            Dim strNowFormat As String = dtNow.ToString("yyyy/MM/dd HH:mm:ss")

            With Now
                strYYYYMMDDvalue = String.Format("{0:D4}{1:D2}{2:D2}", .Year, .Month, .Day)
            End With

            ' 格納フォルダ名の設定
            strReadFolder = IncludeTrailingPathDelimiter(PubConstClass.tranPath)
            ' 格納ファイル名の設定
            strReadFileName = "運用記録ログ_" & strYYYYMMDDvalue & ".LOG"

            ' 運用記録リストの存在確認
            If System.IO.File.Exists(strReadFolder & strReadFileName) = False Then
                MsgBox("運用記録リストはありません。", CType(MsgBoxStyle.Information + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認メッセージ")
                Exit Sub
            End If

            OutPutLogFile("〓「運用記録リスト」呼び出し〓")
            PubConstClass.lngLoopCnt = 0
            Using sr As New System.IO.StreamReader(strReadFolder & strReadFileName, System.Text.Encoding.Default)
                Do While Not sr.EndOfStream
                    PubConstClass.strUseLogArray(CInt(PubConstClass.lngLoopCnt)) = sr.ReadLine.ToString
                    PubConstClass.lngLoopCnt += 1
                Loop
            End Using

            Dim lngPrintCounter As Long = PubConstClass.lngLoopCnt

            If PubConstClass.lngLoopCnt = 0 Then
                MsgBox("印刷する運用記録ログはありません。")
                Exit Sub
            End If

            Dim retVal As MsgBoxResult
            retVal = MsgBox("運用記録リストの内容を確認しますか？", CType(MsgBoxStyle.Question + MsgBoxStyle.OkCancel, MsgBoxStyle), "確認")
            If retVal = MsgBoxResult.Cancel Then
                ' キャンセル
                Exit Sub
            End If

            ' 印字ページインデックスの初期化
            PubConstClass.lngPrintIndex = 0
            PubConstClass.intPrintFuncNo = 3

            'PrintDocumentオブジェクトの作成
            Dim pd As New System.Drawing.Printing.PrintDocument
            'PrintPageイベントハンドラの追加
            AddHandler pd.PrintPage, AddressOf MainForm.PrintDocument1_PrintPage

            ' PrintPreviewDialogオブジェクトの作成
            Dim ppd As New PrintPreviewDialog
            ppd.Width = 1200
            ppd.Height = 1000
            ' プレビューオブジェクトの「印刷」ボタン削除
            Dim tool As ToolStrip = CType(ppd.Controls(1), ToolStrip)
            tool.Items.RemoveAt(0)
            ' プレビューするPrintDocumentを設定
            ppd.Document = pd
            ' 印刷プレビューダイアログを表示する
            ppd.ShowDialog()
            ' PrintPreviewDialogオブジェクトの解放
            ppd.Dispose()

            retVal = MsgBox("運用記録リストを印刷しますか？", CType(MsgBoxStyle.Question + MsgBoxStyle.OkCancel, MsgBoxStyle), "確認")
            If retVal = MsgBoxResult.Cancel Then
                ' キャンセル
                Exit Sub
            End If

            ' 印字ページインデックスの初期化
            PubConstClass.lngPrintIndex = 0
            PubConstClass.intPrintFuncNo = 3
            ' 印字カウンタの再セット
            PubConstClass.lngLoopCnt = lngPrintCounter

            pd.DocumentName = "運用記録リストの印刷"
            ' 印刷処理
            pd.Print()


        Catch ex As Exception
            MsgBox("【BtnJobRecordList_Click】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 「受領証再発行」ボタン処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ReceiptReprint_Click(sender As System.Object, e As System.EventArgs) Handles ReceiptReprint.Click

        OutPutLogFile("〓「受領証再発行画面」呼び出し〓")
        ' 運用記録ログ格納
        Call OutPutUseLogFile(LblOperatorName.Text & ":「受領証再発行画面」呼び出し")

        ReceiptReprintForm.ShowDialog()

    End Sub

End Class