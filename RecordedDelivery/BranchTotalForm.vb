Option Explicit On
Option Strict On

Public Class BranchTotalForm

    Private intTranALLCnt As Integer = 0    ' 通数の合計
    Private intAmountALL As Integer = 0     ' 合計金額の合計

    Private strTranCnt(9) As String         ' 通数（定形）
    Private strAmount(9) As String          ' 合計金額（定数）
    Private strTranCntGai(8) As String      ' 通数（定形外）
    Private strAmountGai(8) As String       ' 合計金額（定数外）

    Private arPrePrintData As New ArrayList ' 印字データ作成用アレイリスト
    Private arPrintData As New ArrayList    ' 印字データ用アレイリスト

    Private intPageIndex As Integer         ' 頁インデックス
    Private intClassPageIndex As Integer    ' 種別単位の頁インデックス
    Private intNextPrintDtIndex As Integer  ' 次のプリントデータのインデックス 
    Private strAggregateTargetDay As String ' 集計対象日
    Private strListForLast(6) As String     ' 最後の頁に印刷するリストデータ
    Private blnIsLastList As Boolean        ' 最後の頁に印刷するフラグ（TRUE：する）

    ''' <summary>
    ''' フォームアクティブ処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BranchTotalForm_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated

        ' オペレータ情報の表示
        LblOperatorName.Text = GetOperatorInfomation()

    End Sub

    ''' <summary>
    ''' フォームロード処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BranchTotalForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            ' 現在の年月日を取得する
            lblCurrentDate.Text = GetCurrentDate()

            ' リストビューのヘッダー表示
            Call DisplayHeader()

            Call DispTargetData()

        Catch ex As Exception
            MsgBox("【BranchTotalForm_Load】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 「戻る」ボタン処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBack.Click

        Me.Dispose()

    End Sub

    ''' <summary>
    ''' 「印刷」ボタン処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click

        Dim col(5) As String
        Dim strReadDataFileName As String
        Dim strArray() As String = Nothing
        Dim intNumber As Integer = 1
        Dim retVal As MsgBoxResult

        Dim blnIsReadClassMaster As Boolean     ' 種別ファイル読込フラグ
        Dim arReadData As New ArrayList
        Dim strReadData As String
        Dim strBeforeData As String
        Dim strFirstReadData As String

        Try
            If DispTargetData() = False Then
                lstGetDataView.Items.Clear()
                Exit Sub
            End If

            retVal = MsgBox("支店日次集計表の内容を確認しますか？", CType(MsgBoxStyle.Question + MsgBoxStyle.OkCancel, MsgBoxStyle), "確認")
            If retVal = MsgBoxResult.Cancel Then
                ' キャンセル
                Exit Sub
            End If

            ' 印字用アレイデータのクリア
            PubConstClass.arPrePrintData.Clear()
            blnIsReadClassMaster = False
            strBeforeData = ""
            arReadData.Clear()
            For K = 0 To lstGetDataView.Items.Count - 1
                '  0      1          2      3    4              5
                ' No,処理日,支店コード,処理数,種別,対象ファイル名

                strReadDataFileName = lstGetDataView.Items(K).SubItems(5).Text

                Using sr As New System.IO.StreamReader(strReadDataFileName, System.Text.Encoding.Default)
                    '    0,                1,                  2,             3,  4,  5,                                                            6,           7,      8,       9  10,  11,12
                    '00001,001：簡易書留郵便,2015/07/28 19:44:18,358-19-00001-1,894,910,C:\RECDEL\IMG\20150728\194347\image_20150728_194418_00001.jpg,30：簡易書留,0234-00,蟹江支店,234,定形,■

                    ' ファイルから１行読込む
                    strReadData = sr.ReadLine.ToString
                    strFirstReadData = strReadData

                    If strBeforeData <> "" And strBeforeData <> lstGetDataView.Items(K).SubItems(2).Text & lstGetDataView.Items(K).SubItems(4).Text Then
                        strBeforeData = lstGetDataView.Items(K).SubItems(2).Text & lstGetDataView.Items(K).SubItems(4).Text
                        ' 対象データから通数合計、金額合計を取得する
                        GetTranCntAndAmount(arReadData)
                        arReadData.Clear()
                    End If

                    ' カンマ単位にデータを分解
                    strArray = strReadData.Split(","c)
                    If blnIsReadClassMaster = False Then
                        blnIsReadClassMaster = True
                        ' 種別単位の重量及び料金データを読込む
                        Call GetClassMasterData(strArray(7))
                    End If

                    If strBeforeData = "" Then
                        strBeforeData = lstGetDataView.Items(K).SubItems(2).Text & lstGetDataView.Items(K).SubItems(4).Text
                    End If

                    ' 対象ファイルの内容を格納する
                    arReadData.Add(strFirstReadData)
                    Do While Not sr.EndOfStream
                        strReadData = sr.ReadLine.ToString
                        arReadData.Add(strReadData)
                    Loop

                    blnIsReadClassMaster = False

                End Using

            Next
            ' 対象データから通数合計、金額合計を取得する
            GetTranCntAndAmount(arReadData)

            Dim intTusuSum As Integer = 0
            Dim intSum As Integer = 0
            Dim strBeforVal As String = ""

            PubConstClass.arPrintData.Clear()
            For N = 0 To PubConstClass.arPrePrintData.Count - 1
                strReadData = PubConstClass.arPrePrintData(N).ToString
                strArray = strReadData.Split(","c)
                If strArray(4) = "小計" Then
                    intTusuSum = intTusuSum + CInt(strArray(5))
                    intSum = intSum + CInt(strArray(6))
                End If

                If strBeforVal <> strArray(0) And strBeforVal <> "" Then
                    PubConstClass.arPrintData.Add(strBeforVal & ",,,,合計," & intTusuSum.ToString & "," & intSum.ToString)
                    PubConstClass.arPrintData.Add(strReadData)
                    intTusuSum = 0
                    intSum = 0
                    strBeforVal = ""
                ElseIf strBeforVal = "" Then
                    strBeforVal = strArray(0)
                    PubConstClass.arPrintData.Add(strReadData)
                Else
                    PubConstClass.arPrintData.Add(strReadData)
                End If
            Next
            PubConstClass.arPrintData.Add(strBeforVal & ",,,,合計," & intTusuSum.ToString & "," & intSum.ToString)

            '           0 1 2 3    4  5    6
            '30：簡易書留, , , ,合計,21,8380
            strListForLast(0) = " 30：簡易書留　……………………………（通数：0）（合計金額：0）"
            strListForLast(1) = " 40：簡易書留速達　………………………（通数：0）（合計金額：0）"
            strListForLast(2) = " 50：特定記録　……………………………（通数：0）（合計金額：0）"
            strListForLast(3) = " 60：特定記録速達　………………………（通数：0）（合計金額：0）"
            strListForLast(4) = "150：ゆうメール（簡易書留）……………（通数：0）（合計金額：0）"
            strListForLast(5) = "160：ゆうメール（簡易書留）速達　……（通数：0）（合計金額：0）"
            'Dim strArray() As String
            Dim strSubArray() As String
            Dim strEditArray() As String

            For N = 0 To PubConstClass.arPrintData.Count - 1
                OutPutLogFile("■印刷データ（arPrintData）：" & PubConstClass.arPrintData(N).ToString)
                strArray = PubConstClass.arPrintData(N).ToString.Split(","c)
                If strArray(4) = "合計" Then
                    strSubArray = strArray(0).Split("："c)

                    Select Case strSubArray(0)
                        Case "30"
                            strEditArray = PubConstClass.arPrintData(N).ToString.Split(","c)
                            strListForLast(0) = " " & strEditArray(0)
                            strListForLast(0) &= "　……………………………（通数：" & strEditArray(5)
                            strListForLast(0) &= "）（合計金額：" & strEditArray(6) & "）"
                        Case "40"
                            strEditArray = PubConstClass.arPrintData(N).ToString.Split(","c)
                            strListForLast(1) = " " & strEditArray(0)
                            strListForLast(1) &= "　………………………（通数：" & strEditArray(5)
                            strListForLast(1) &= "）（合計金額：" & strEditArray(6) & "）"
                        Case "50"
                            strEditArray = PubConstClass.arPrintData(N).ToString.Split(","c)
                            strListForLast(2) = " " & strEditArray(0)
                            strListForLast(2) &= "　……………………………（通数：" & strEditArray(5)
                            strListForLast(2) &= "）（合計金額：" & strEditArray(6) & "）"
                        Case "60"
                            strEditArray = PubConstClass.arPrintData(N).ToString.Split(","c)
                            strListForLast(3) = " " & strEditArray(0)
                            strListForLast(3) &= "　………………………（通数：" & strEditArray(5)
                            strListForLast(3) &= "）（合計金額：" & strEditArray(6) & "）"
                        Case "150"
                            strEditArray = PubConstClass.arPrintData(N).ToString.Split(","c)
                            strListForLast(4) = strEditArray(0)
                            strListForLast(4) &= "　…………（通数：" & strEditArray(5)
                            strListForLast(4) &= "）（合計金額：" & strEditArray(6) & "）"
                        Case "160"
                            strEditArray = PubConstClass.arPrintData(N).ToString.Split(","c)
                            strListForLast(5) = strEditArray(0)
                            strListForLast(5) &= "　……（通数：" & strEditArray(5)
                            strListForLast(5) &= "）（合計金額：" & strEditArray(6) & "）"
                        Case Else

                    End Select
                End If
            Next
            OutPutLogFile("〓" & strListForLast(0))
            OutPutLogFile("〓" & strListForLast(1))
            OutPutLogFile("〓" & strListForLast(2))
            OutPutLogFile("〓" & strListForLast(3))
            OutPutLogFile("〓" & strListForLast(4))
            OutPutLogFile("〓" & strListForLast(5))
            blnIsLastList = False

            ' 集計対象日の設定
            strAggregateTargetDay = DateTimePicker1.Value.ToString("yyyy/MM/dd")

            'PrintDocumentオブジェクトの作成
            Dim pd As New System.Drawing.Printing.PrintDocument
            'PrintPageイベントハンドラの追加
            AddHandler pd.PrintPage, AddressOf PrintDocument1_PrintPage

            intPageIndex = 1        ' 頁＝１
            intClassPageIndex = 0   ' 種別単位の頁＝０
            intNextPrintDtIndex = 0

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

            retVal = MsgBox("支店日次集計表を印刷しますか？", CType(MsgBoxStyle.Question + MsgBoxStyle.OkCancel, MsgBoxStyle), "確認")
            If retVal = MsgBoxResult.Cancel Then
                ' キャンセル
                Exit Sub
            End If

            intPageIndex = 1        ' 頁＝１
            intClassPageIndex = 0   ' 種別単位の頁＝０
            intNextPrintDtIndex = 0

            ' 印刷処理
            pd.Print()
            ' PrintDocumentオブジェクトの解放
            pd.Dispose()

        Catch ex As Exception
            MsgBox("【BtnPrint_Click】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' リストビューのヘッダー表示
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DisplayHeader()

        Try
            ' ListViewのカラムヘッダー設定
            lstGetDataView.View = View.Details
            Dim col1 As ColumnHeader = New ColumnHeader
            Dim col2 As ColumnHeader = New ColumnHeader
            Dim col3 As ColumnHeader = New ColumnHeader
            Dim col4 As ColumnHeader = New ColumnHeader
            Dim col5 As ColumnHeader = New ColumnHeader
            Dim col6 As ColumnHeader = New ColumnHeader

            col1.Text = "No"
            col2.Text = "処理日"
            col3.Text = "支店コード"
            col4.Text = "処理通数"
            col5.Text = "種別"
            col6.Text = "対象ファイル名称"

            col1.TextAlign = HorizontalAlignment.Center
            col2.TextAlign = HorizontalAlignment.Center
            col3.TextAlign = HorizontalAlignment.Right
            col4.TextAlign = HorizontalAlignment.Right
            col5.TextAlign = HorizontalAlignment.Left
            col6.TextAlign = HorizontalAlignment.Left

            col1.Width = 80     ' No
            col2.Width = 120    ' 処理日
            col3.Width = 100    ' 支店コード
            col4.Width = 100    ' 処理通数
            col5.Width = 185    ' 種別
            col6.Width = 5      ' 対象ファイル名

            Dim colHeader() As ColumnHeader = {col1, col2, col3, col4, col5, col6}
            lstGetDataView.Columns.AddRange(colHeader)

        Catch ex As Exception
            MsgBox("【DisplayHeader】" & ex.Message)
        End Try

    End Sub


    ''' <summary>
    ''' 「支店日次集計表」印刷処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub PrintDocument1_PrintPage(sender As System.Object, e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage

        '// 1mm≒4.11
        Dim intMargin As Integer = 12       ' 余白の設定（3mm）

        Dim intYoko1 As Integer = 62        ' 横１の印刷座標（15mm）（原点からの距離）
        Dim intYoko2 As Integer = 144 + 41  ' 横２の印刷座標（35mm＋10mm）（横１からの距離）
        Dim intYoko3 As Integer = 329 + 41  ' 横３の印刷座標（80mm＋10mm）（横１からの距離）
        Dim intYoko4 As Integer = 411 + 41  ' 横４の印刷座標（100mm＋10mm）（横１からの距離）
        Dim intYoko5 As Integer = 493 + 41  ' 横５の印刷座標（120mm＋10mm）（横１からの距離）
        Dim intYoko6 As Integer = 576 + 41  ' 横６の印刷座標（140mm＋10mm）（横１からの距離）
        Dim intYoko7 As Integer = 658 + 41  ' 横７の印刷座標（160mm＋10mm）（横１からの距離）

        Dim intTate1 As Integer = 41        ' 縦１の印刷座標（10mm）
        Dim intTate2 As Integer = 82        ' 縦２の印刷座標（20mm）
        Dim intTate3 As Integer = 123       ' 縦３の印刷座標（30mm）
        Dim intTate4 As Integer = 164       ' 縦４の印刷座標（40mm）

        Dim intSTPosYoko As Integer         ' 印刷開始ポジション（横）
        Dim intSTPosTate As Integer         ' 印刷開始ポジション（縦）
        Dim intTateHaba As Integer          ' 行の縦幅
        Dim intOffset As Integer            ' 文字印刷縦方向印刷オフセット

        Dim strArray() As String
        Dim strSubArray() As String
        Dim N As Integer
        Dim strClassArray() As String

        intYoko3 = intYoko3 - intYoko2
        intYoko4 = intYoko4 - intYoko3 - intYoko2
        intYoko5 = intYoko5 - intYoko4 - intYoko3 - intYoko2
        intYoko6 = intYoko6 - intYoko5 - intYoko4 - intYoko3 - intYoko2
        intYoko7 = intYoko7 - intYoko6 - intYoko5 - intYoko4 - intYoko3 - intYoko2

        Try
            ' ヘッダーの印刷
            Dim dtNow As DateTime = DateTime.Now
            Dim t As New Font("メイリオ", 18, FontStyle.Regular)
            Dim h As New Font("メイリオ", 14, FontStyle.Regular)
            Dim f As New Font("メイリオ", 10, FontStyle.Regular)

            Dim uh As New Font("メイリオ", 14, FontStyle.Underline)
            Dim mf As New Font("ＭＳ ゴシック", 10, FontStyle.Regular)
            Dim ms As New Font("ＭＳ ゴシック", 14, FontStyle.Regular)
            Dim mm As New Font("ＭＳ ゴシック", 12, FontStyle.Regular)

            ' ヘッダー１行目（印字開始位置：横130mm×縦10mm）
            e.Graphics.DrawString(Date.Now.ToString("yyyy年MM月dd日 HH時mm分ss秒"), f, Brushes.Black, 534, 41)
            ' ヘッダー２行目（印字開始位置：横75mm×縦15mm）
            e.Graphics.DrawString("支店日次集計表（" & strAggregateTargetDay & "）", t, Brushes.Black, 308 - 103, 61)
            ' ヘッダー３行目（印字開始位置：横150mm×縦20mm）
            e.Graphics.DrawString("【" & PubConstClass.pblMachineName & "】", f, Brushes.Black, 616, 82)
            ' ヘッダー３行目（印字開始位置：横170mm×縦20mm）
            e.Graphics.DrawString("Page " & intPageIndex.ToString("0"), f, Brushes.Black, 699, 82)

            PrintDocument1.DocumentName = "支店日次集計表印刷"

            intSTPosYoko = intYoko1
            intSTPosTate = intTate3

            intTateHaba = 25        ' 6mm
            intOffset = 5           ' 1mm

            If blnIsLastList = True Then
                blnIsLastList = False

                intSTPosYoko = intYoko1
                e.Graphics.DrawString(strListForLast(0), mm, Brushes.Black, intSTPosYoko, intSTPosTate + intOffset)
                intSTPosTate = intSTPosTate + intTateHaba
                e.Graphics.DrawString(strListForLast(1), mm, Brushes.Black, intSTPosYoko, intSTPosTate + intOffset)
                intSTPosTate = intSTPosTate + intTateHaba
                e.Graphics.DrawString(strListForLast(2), mm, Brushes.Black, intSTPosYoko, intSTPosTate + intOffset)
                intSTPosTate = intSTPosTate + intTateHaba
                e.Graphics.DrawString(strListForLast(3), mm, Brushes.Black, intSTPosYoko, intSTPosTate + intOffset)
                intSTPosTate = intSTPosTate + intTateHaba
                e.Graphics.DrawString(strListForLast(4), mm, Brushes.Black, intSTPosYoko, intSTPosTate + intOffset)
                intSTPosTate = intSTPosTate + intTateHaba
                e.Graphics.DrawString(strListForLast(5), mm, Brushes.Black, intSTPosYoko, intSTPosTate + intOffset)

                ' 次の頁なし
                e.HasMorePages = False
                Exit Sub
            End If



            e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(intSTPosYoko, intSTPosTate, intYoko2, intTateHaba))
            intSTPosYoko = intSTPosYoko + intYoko2
            e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(intSTPosYoko, intSTPosTate, intYoko3, intTateHaba))
            intSTPosYoko = intSTPosYoko + intYoko3
            e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(intSTPosYoko, intSTPosTate, intYoko4, intTateHaba))
            intSTPosYoko = intSTPosYoko + intYoko4
            e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(intSTPosYoko, intSTPosTate, intYoko5, intTateHaba))
            intSTPosYoko = intSTPosYoko + intYoko5
            e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(intSTPosYoko, intSTPosTate, intYoko6, intTateHaba))
            intSTPosYoko = intSTPosYoko + intYoko6
            e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(intSTPosYoko, intSTPosTate, intYoko7, intTateHaba))

            intSTPosYoko = intYoko1
            Dim sHosoku As String = "定：定形／○：定形外(規格内)／●：定形外(規格外)"
            e.Graphics.DrawString(sHosoku, f, Brushes.Black, intSTPosYoko, intSTPosTate + intOffset - 32)

            e.Graphics.DrawString("　種別", f, Brushes.Black, intSTPosYoko, intSTPosTate + intOffset)
            intSTPosYoko = intSTPosYoko + intYoko2
            e.Graphics.DrawString("　支店", f, Brushes.Black, intSTPosYoko, intSTPosTate + intOffset)
            intSTPosYoko = intSTPosYoko + intYoko3
            e.Graphics.DrawString("　　重量", f, Brushes.Black, intSTPosYoko, intSTPosTate + intOffset)
            intSTPosYoko = intSTPosYoko + intYoko4
            e.Graphics.DrawString("　　単価", f, Brushes.Black, intSTPosYoko, intSTPosTate + intOffset)
            intSTPosYoko = intSTPosYoko + intYoko5
            e.Graphics.DrawString("　　通数", f, Brushes.Black, intSTPosYoko, intSTPosTate + intOffset)
            intSTPosYoko = intSTPosYoko + intYoko6
            e.Graphics.DrawString("　合計金額", f, Brushes.Black, intSTPosYoko, intSTPosTate + intOffset)

            ' １頁の印字行数（37行：ヘッダー部除く）
            'Const intRowPerPage = 40
            Const intRowPerPage = 37
            Dim intDispCnt As Integer = intRowPerPage

            Dim strBeforClass As String = ""    ' 前回の種別データを格納する
            Dim strBeforSiten As String = ""    ' 前回の支店データを格納する

            Dim intDispIndex As Integer = 0

            For N = intNextPrintDtIndex To PubConstClass.arPrintData.Count - 1

                strArray = PubConstClass.arPrintData(N).ToString.Split(","c)

                If strArray(4) = "合計" Or strArray(4) = "小計" Then
                    e.Graphics.FillRectangle(Brushes.LightGray, New Rectangle(intYoko1 + intYoko2 + intYoko3, _
                                                                              intTate3 + intTateHaba * (intDispIndex - ((1 - 1) * intRowPerPage) + 1), _
                                                                              intYoko4 + intYoko5 + intYoko6 + intYoko7, _
                                                                              intTateHaba))
                    e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(intYoko1 + intYoko2, _
                                                                                    intTate3, _
                                                                                    intYoko3, _
                                                                                    intTateHaba * (intDispIndex - ((1 - 1) * intRowPerPage) + 2)))
                    If strArray(4) = "合計" Then
                        e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(intYoko1, _
                                                                                        intTate3, _
                                                                                        intYoko2, _
                                                                                        intTateHaba * (intDispIndex - ((1 - 1) * intRowPerPage) + 2)))
                    End If
                End If

                ' 種別
                intSTPosYoko = intYoko1
                If strBeforClass = "" Then
                    ' 種別の印刷（「合計」「小計」の行に種別は印刷しない）
                    If strArray(4) <> "合計" And strArray(5) <> "小計" Then
                        strSubArray = strArray(0).Split("："c)
                        If strSubArray.Length > 1 Then
                            e.Graphics.DrawString(strSubArray(0), f, Brushes.Black, intSTPosYoko, intSTPosTate + intTateHaba * (intDispIndex - ((1 - 1) * intRowPerPage) + 1) + intOffset)
                            e.Graphics.DrawString(strSubArray(1), f, Brushes.Black, intSTPosYoko, intSTPosTate + intTateHaba * (intDispIndex - ((1 - 1) * intRowPerPage) + 2) + intOffset)

                            strClassArray = strArray(0).Split("："c)
                            strBeforClass = strClassArray(0)
                            'Select Case strClassArray(0)
                            '    Case "40"
                            '        strBeforClass = "30"
                            '    Case "60"
                            '        strBeforClass = "50"
                            '    Case "160"
                            '        strBeforClass = "150"
                            '    Case Else
                            '        strBeforClass = strClassArray(0)
                            'End Select

                        End If
                    End If
                Else
                    strClassArray = strArray(0).Split("："c)
                    'Select Case strClassArray(0)
                    '    Case "40"
                    '        strClassArray(0) = "30"
                    '    Case "60"
                    '        strClassArray(0) = "50"
                    '    Case "160"
                    '        strClassArray(0) = "150"
                    '    Case Else
                    'End Select
                    Debug.Print("■strArray(2)：" & strArray(2))
                    If strBeforClass <> strClassArray(0) And strArray(0) <> "" Then

                        ' 次の頁あり
                        e.HasMorePages = True
                        intPageIndex += 1       ' 頁インデックス＋１
                        intClassPageIndex = 0   ' 種別単位の頁インデックスの初期化
                        Exit Sub

                    End If
                    If strArray(0) = "" Then
                        strBeforClass = ""
                    End If

                End If

                intSTPosYoko = intYoko1
                If strArray(0) = "" Then
                    ' 種別が空白の時
                    intSTPosYoko = intSTPosYoko + intYoko2
                    intSTPosYoko = intSTPosYoko + intYoko3
                    intSTPosYoko = intSTPosYoko + intYoko4
                    intSTPosYoko = intSTPosYoko + intYoko5
                    intSTPosYoko = intSTPosYoko + intYoko6
                    e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(intSTPosYoko, intSTPosTate + intTateHaba * (intDispIndex + 1), intYoko7, intTateHaba))
                Else
                    ' 種別が存在する時
                    intSTPosYoko = intSTPosYoko + intYoko2
                    intSTPosYoko = intSTPosYoko + intYoko3
                    e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(intSTPosYoko, intSTPosTate + intTateHaba * (intDispIndex + 1), intYoko4, intTateHaba))
                    intSTPosYoko = intSTPosYoko + intYoko4
                    e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(intSTPosYoko, intSTPosTate + intTateHaba * (intDispIndex + 1), intYoko5, intTateHaba))
                    intSTPosYoko = intSTPosYoko + intYoko5
                    e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(intSTPosYoko, intSTPosTate + intTateHaba * (intDispIndex + 1), intYoko6, intTateHaba))
                    intSTPosYoko = intSTPosYoko + intYoko6
                    e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(intSTPosYoko, intSTPosTate + intTateHaba * (intDispIndex + 1), intYoko7, intTateHaba))
                End If

                intSTPosYoko = intYoko1
                ' 支店＋支店名
                intSTPosYoko = intSTPosYoko + intYoko2
                If strArray(1) = "" Then
                    Debug.Print("〓strArray(4)：" & strArray(4))
                    ' 支店コードが空白の時
                    e.Graphics.DrawString("", f, Brushes.Black, intSTPosYoko, intSTPosTate + intTateHaba * (intDispIndex + 1) + intOffset)
                    ' 罫線印刷
                    'e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(intYoko1 + intYoko2 , intTate3, intYoko3, intTateHaba * (intDispIndex + 1)))
                    e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(intYoko1 + intYoko2 + intYoko3, intTate3, intYoko4, intTateHaba * (intDispIndex + 1)))
                    e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(intYoko1 + intYoko2, intTate3, intYoko3, intTateHaba * (intDispIndex + 2)))
                Else
                    ' 支店コードがある時
                    If strBeforSiten = "" Then
                        ' 支店コードの印刷
                        e.Graphics.DrawString(strArray(1), f, Brushes.Black, intSTPosYoko, intSTPosTate + intTateHaba * (intDispIndex + 1) + intOffset)
                        ' 支店名の印刷
                        e.Graphics.DrawString(strArray(2), f, Brushes.Black, intSTPosYoko, intSTPosTate + intTateHaba * (intDispIndex + 2) + intOffset)
                        strBeforSiten = strArray(1)
                    Else
                        If strBeforSiten <> strArray(1) Then
                            ' 支店コードの印刷
                            e.Graphics.DrawString(strArray(1), f, Brushes.Black, intSTPosYoko, intSTPosTate + intTateHaba * (intDispIndex + 1) + intOffset)

                            If intDispIndex >= (intRowPerPage - 1) Then
                                OutPutLogFile("【支店日次集計表】最終行には支店名は印字しない")
                            Else
                                ' 支店名の印刷
                                e.Graphics.DrawString(strArray(2), f, Brushes.Black, intSTPosYoko, intSTPosTate + intTateHaba * (intDispIndex + 2) + intOffset)
                            End If

                            strBeforSiten = strArray(1)
                            strClassArray = strArray(0).Split("："c)
                            If strBeforClass <> strClassArray(0) And strArray(0) <> "" Then
                                ' 種別の印刷
                                strSubArray = strArray(0).Split("："c)
                                e.Graphics.DrawString(strSubArray(0), f, Brushes.Black, intSTPosYoko - intYoko2, intSTPosTate + intTateHaba * (intDispIndex + 1) + intOffset)
                                e.Graphics.DrawString(strSubArray(1), f, Brushes.Black, intSTPosYoko - intYoko2, intSTPosTate + intTateHaba * (intDispIndex + 2) + intOffset)
                            End If

                        End If
                    End If
                End If
                ' 重量
                intSTPosYoko = intSTPosYoko + intYoko3

                '// 定形・定形外(規格内)・定形外(規格外)
                If strArray.Length > 7 Then
                    e.Graphics.DrawString(strArray(7), mf, Brushes.Black, intSTPosYoko - 20, intSTPosTate + intTateHaba * (intDispIndex + 1) + intOffset)
                End If

                e.Graphics.DrawString(GetWeightFormat(strArray(3)), mf, Brushes.Black, intSTPosYoko, intSTPosTate + intTateHaba * (intDispIndex + 1) + intOffset)
                ' 単価
                intSTPosYoko = intSTPosYoko + intYoko4
                e.Graphics.DrawString(GetPriceFormat(strArray(4)), mf, Brushes.Black, intSTPosYoko, intSTPosTate + intTateHaba * (intDispIndex + 1) + intOffset)
                ' 通数
                intSTPosYoko = intSTPosYoko + intYoko5
                e.Graphics.DrawString(GetTusuFormat(strArray(5)), mf, Brushes.Black, intSTPosYoko, intSTPosTate + intTateHaba * (intDispIndex + 1) + intOffset)
                ' 合計金額
                intSTPosYoko = intSTPosYoko + intYoko6
                e.Graphics.DrawString(GetAmountFormat(strArray(6)), mf, Brushes.Black, intSTPosYoko, intSTPosTate + intTateHaba * (intDispIndex + 1) + intOffset)

                intNextPrintDtIndex += 1
                intDispIndex += 1

                ' 合計行の印字行が１行目の場合の改頁処理
                'If strArray(4) = "合計" And (N Mod intRowPerPage) = 0 Then
                If strArray(4) = "合計" And intDispIndex = 1 Then
                    e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(intYoko1, _
                                                    intTate3, _
                                                    intYoko2, _
                                                    intTateHaba * (intDispIndex - ((intPageIndex - 1) * intRowPerPage) + 1)))
                    ' 次の頁あり
                    e.HasMorePages = True
                    'intPageIndex += 1       ' 頁インデックス＋１
                    intClassPageIndex = 0   ' 種別単位の頁インデックスの初期化
                    Exit For
                End If

                If strArray(4) = "小計" And (intDispIndex >= (intRowPerPage - 3)) Then
                    OutPutLogFile("〓小計が" & intDispIndex.ToString("0") & "行で出現したので改行した〓")


                    strArray = PubConstClass.arPrintData(N + 1).ToString.Split(","c)
                    If strArray(4) = "合計" Then
                        e.Graphics.FillRectangle(Brushes.LightGray, New Rectangle(intYoko1 + intYoko2 + intYoko3, _
                                                                                  intTate3 + intTateHaba * (intDispIndex - ((1 - 1) * intRowPerPage) + 1), _
                                                                                  intYoko4 + intYoko5 + intYoko6 + intYoko7, _
                                                                                  intTateHaba))
                        intSTPosYoko = intYoko1
                        intSTPosYoko = intSTPosYoko + intYoko2
                        'e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(intSTPosYoko, intSTPosTate + intTateHaba * (intDispIndex + 1), intYoko3, intTateHaba))
                        intSTPosYoko = intSTPosYoko + intYoko3
                        e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(intSTPosYoko, intSTPosTate + intTateHaba * (intDispIndex + 1), intYoko4, intTateHaba))
                        intSTPosYoko = intSTPosYoko + intYoko4
                        e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(intSTPosYoko, intSTPosTate + intTateHaba * (intDispIndex + 1), intYoko5, intTateHaba))
                        intSTPosYoko = intSTPosYoko + intYoko5
                        e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(intSTPosYoko, intSTPosTate + intTateHaba * (intDispIndex + 1), intYoko6, intTateHaba))
                        intSTPosYoko = intSTPosYoko + intYoko6
                        e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(intSTPosYoko, intSTPosTate + intTateHaba * (intDispIndex + 1), intYoko7, intTateHaba))

                        intSTPosYoko = intYoko1
                        intSTPosYoko = intSTPosYoko + intYoko2
                        intSTPosYoko = intSTPosYoko + intYoko3
                        ' 単価
                        intSTPosYoko = intSTPosYoko + intYoko4
                        e.Graphics.DrawString(GetPriceFormat(strArray(4)), mf, Brushes.Black, intSTPosYoko, intSTPosTate + intTateHaba * (intDispIndex + 1) + intOffset)
                        ' 通数
                        intSTPosYoko = intSTPosYoko + intYoko5
                        e.Graphics.DrawString(GetTusuFormat(strArray(5)), mf, Brushes.Black, intSTPosYoko, intSTPosTate + intTateHaba * (intDispIndex + 1) + intOffset)
                        ' 合計金額
                        intSTPosYoko = intSTPosYoko + intYoko6
                        e.Graphics.DrawString(GetAmountFormat(strArray(6)), mf, Brushes.Black, intSTPosYoko, intSTPosTate + intTateHaba * (intDispIndex + 1) + intOffset)

                        intNextPrintDtIndex += 1
                        intDispIndex += 1
                    End If

                    ' 次の頁あり
                    e.HasMorePages = True
                    intClassPageIndex = 0   ' 種別単位の頁インデックスの初期化
                    Exit For
                End If

                intDispCnt -= 1
                If intDispCnt = 0 Then
                    Exit For
                End If

            Next N

            ' 頁全体の１カラム目の外枠線を印字
            e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(intYoko1, _
                                    intTate3, _
                                    intYoko2, _
                                    intTateHaba * (intDispIndex + 1)))
            ' 頁全体の２カラム目の外枠線を印字
            e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(intYoko1 + intYoko2, _
                                                                intTate3, _
                                                                intYoko3, _
                                                                intTateHaba * (intDispIndex + 1)))

            If intNextPrintDtIndex > PubConstClass.arPrintData.Count - 1 Then
                ' 次の頁なし
                'e.HasMorePages = False
                blnIsLastList = True
                e.HasMorePages = True
                intPageIndex += 1       ' 頁インデックス＋１
            Else
                ' 次の頁あり
                e.HasMorePages = True
                intPageIndex += 1       ' 頁インデックス＋１
                intClassPageIndex += 1
            End If

        Catch ex As Exception
            MsgBox("【PrintDocument1_PrintPage】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 重量
    ''' </summary>
    ''' <param name="strData"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetWeightFormat(ByVal strData As String) As String

        Select Case strData.Length
            Case 1, 2
                '          123456
                strData = "      " & strData & "g"
            Case 3
                '          12345
                strData = "     " & strData & "g"
            Case 4
                '          1234
                strData = "    " & strData & "g"
        End Select

        Return strData

    End Function

    ''' <summary>
    ''' 通数
    ''' </summary>
    ''' <param name="strData"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetTusuFormat(ByVal strData As String) As String

        Select Case strData.Length
            Case 1
                '          12345678
                strData = "        " & strData
            Case 2
                '          1234567
                strData = "       " & strData
            Case 3
                '          123456
                strData = "      " & strData
            Case 4
                '          12345
                strData = "     " & strData
        End Select

        Return strData

    End Function

    ''' <summary>
    ''' 単価
    ''' </summary>
    ''' <param name="strData"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetPriceFormat(ByVal strData As String) As String

        If strData = "小計" Then
            '       123456
            Return "      小計"
        ElseIf strData = "合計" Then
            '       123456
            Return "      合計"
        End If

        Select Case strData.Length
            Case 1
                '          12345678
                strData = "        " & strData
            Case 2
                '          1234567
                strData = "       " & strData
            Case 3
                '          123456
                strData = "      " & strData
            Case 4
                '          1234
                strData = "    " & CInt(strData).ToString("0,000")
        End Select

        Return strData

    End Function

    ''' <summary>
    ''' 合計金額
    ''' </summary>
    ''' <param name="strData"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetAmountFormat(ByVal strData As String) As String

        Select Case strData.Length
            Case 1
                '          123456789
                strData = "         " & strData
            Case 2
                '          12345678
                strData = "        " & strData
            Case 3
                '          1234567
                strData = "       " & strData
            Case 4
                '          12345
                strData = "     " & CInt(strData).ToString("0,000")
            Case 5
                '          1234
                strData = "    " & CInt(strData).ToString("0,000")
            Case 6
                '          123
                strData = "   " & CInt(strData).ToString("000,000")
            Case 7
                '          12
                strData = "  " & CInt(strData).ToString("0,000,000")

        End Select

        Return strData

    End Function

    ''' <summary>
    ''' 集計対象日選択処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub DateTimePicker1_ValueChanged(sender As System.Object, e As System.EventArgs) Handles DateTimePicker1.ValueChanged

        Call DispTargetData()

    End Sub

 
    Private Function DispTargetData() As Boolean

        Dim strSearchDir As String = ""
        Dim col(5) As String
        Dim itm As ListViewItem
        Dim strReadDataFileName As String
        Dim strArray() As String = Nothing
        Dim strDateArray() As String
        Dim intNumber As Integer = 1
        Dim strReadData As String

        Try
            DispTargetData = False

            ' 種別ファイル読込フラグ
            Dim blnIsReadClassMaster As Boolean
            Dim arReadData As New ArrayList
            Dim arWork As New ArrayList

            arWork.Clear()
            '// 2016.02.05 Ver.B06 hayakawa 追加↓ここから
            lstGetDataView.Items.Clear()
            '// 2016.02.05 Ver.B06 hayakawa 追加↑ここまで

            ' 集計対象日から対象フォルダを確定する
            strSearchDir = IncludeTrailingPathDelimiter(PubConstClass.imgPath) & DateTimePicker1.Value.ToString("yyyyMMdd") & "\"

            If System.IO.Directory.Exists(strSearchDir) = False Then
                '// 2016.02.05 Ver.B06 hayakawa 修正↓ここから
                'MsgBox("集計対象フォルダが見つかりません", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")
                '// 2016.02.05 Ver.B06 hayakawa 修正↑ここまで
                Exit Function
            End If

            If System.IO.Directory.GetFiles(strSearchDir, "*.LOG", System.IO.SearchOption.AllDirectories).Count < 1 Then
                '// 2016.02.05 Ver.B06 hayakawa 修正↓ここから
                'MsgBox("集計対象ファイルが見つかりません", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")
                '// 2016.02.05 Ver.B06 hayakawa 修正↑ここまで
                Exit Function
            End If

            DispTargetData = True
            For Each strFileList As String In System.IO.Directory.GetFiles(strSearchDir, "*.LOG", System.IO.SearchOption.AllDirectories)

                strReadDataFileName = strFileList
                blnIsReadClassMaster = False
                Using sr As New System.IO.StreamReader(strReadDataFileName, System.Text.Encoding.Default)

                    ' ファイルから１行読込む
                    strReadData = sr.ReadLine.ToString

                    ' カンマ単位にデータを分解
                    strArray = strReadData.Split(","c)

                    'col(0) = intNumber.ToString("000")      ' No.
                    ' 処理日のみを切り出す
                    strDateArray = strArray(2).Split(" "c)
                    col(1) = strDateArray(0)                ' 処理日
                    col(2) = strArray(8)                    ' 支店コード
                    col(3) = strArray(10)                   ' 処理数
                    col(4) = strArray(7)                    ' 種別
                    col(5) = strReadDataFileName            ' 対象ファイル名

                    Dim strChkArray() As String
                    strChkArray = col(4).Split("："c)
                    col(4) = CInt(strChkArray(0)).ToString("000") & "：" & strChkArray(1)
                    arWork.Add(col(4) & "," & CInt(col(2)).ToString("00000") & "," & col(3) & "," & col(5) & "," & col(1))

                End Using

            Next

            'OutPutLogFile("〓〓〓〓〓ソート前〓〓〓〓〓")
            'For N = 0 To arWork.Count - 1
            '    OutPutLogFile(arWork(N).ToString)
            'Next

            ' 種別と支店コードで昇順にソートする
            arWork.Sort()

            'OutPutLogFile("〓〓〓〓〓ソート後〓〓〓〓〓")
            'For N = 0 To arWork.Count - 1
            '    OutPutLogFile(arWork(N).ToString)
            'Next

            lstGetDataView.Items.Clear()
            For N = 0 To arWork.Count - 1
                '            0       1   2                                                   3          4
                '030：簡易書留,0001-00,111,C:\RECDEL\IMG\20150814\稼動ログ_20150814_215417.LOG,2015/08/14
                strArray = arWork(N).ToString.Split(","c)
                col(0) = intNumber.ToString("000")      ' No.
                col(1) = strArray(4)                    ' 処理日
                col(2) = CInt(strArray(1)).ToString("0") ' 支店コード
                col(3) = strArray(2)                    ' 処理数
                col(4) = strArray(0)                    ' 種別
                col(5) = strArray(3)                    ' 対象ファイル名

                ' 対象ファイルをリストアップする
                itm = New ListViewItem(col)
                lstGetDataView.Items.Add(itm)
                'lstGetDataView.Items(0).Selected = True
                'lstGetDataView.Items(0).Focused = True
                'lstGetDataView.Select()
                'lstGetDataView.Items(0).EnsureVisible()

                intNumber += 1
            Next

        Catch ex As Exception
            MsgBox("【DispTargetData】" & ex.Message)
            Return False
        End Try

    End Function

End Class