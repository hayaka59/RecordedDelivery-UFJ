Option Explicit On
Option Strict On

Public Class CsvOutPutForm

    Private intTranALLCnt As Integer = 0        ' 通数（定形）の合計
    Private intAmountALL As Integer = 0         ' 合計金額（定形）の合計
    Private intTranALLCntGai As Integer = 0     ' 通数（定形外／規格内）の合計
    Private intAmountALLGai As Integer = 0      ' 合計金額（定形外／規格内）の合計
    Private intTranALLCntNonS As Integer = 0    ' 通数（定形外／規格外）の合計
    Private intAmountALLNonS As Integer = 0     ' 合計金額（定形外／規格外）の合計

    Private strTranCnt(9) As String         ' 通数（定形）
    Private strAmount(9) As String          ' 合計金額（定形）
    Private strTranCntGai(8) As String      ' 通数（定形外／規格内）
    Private strAmountGai(8) As String       ' 合計金額（定形外／規格内）
    Private strTranCntNonS(8) As String     ' 通数（定形外／規格外）
    Private strAmountNonS(8) As String      ' 合計金額（定形外／規格外）
    Private blnIsHeaderWrite As Boolean     ' ヘッダー書込みフラグ

    ''' <summary>
    ''' フォームアクティブ処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CsvOutPutForm_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated

        LblOperatorName.Text = GetOperatorInfomation()

    End Sub

    ''' <summary>
    ''' フォームロード処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CsvOutPutForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try

            ' 現在の年月日を取得する
            lblCurrentDate.Text = GetCurrentDate()

            ' リストビューのヘッダー表示
            Call DisplayHeader()

            ' CSV出力対象ファイルの表示処理
            Call DispCsvOutFile()

        Catch ex As Exception
            MsgBox("【CsvOutPutForm_Load】" & ex.Message)
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
            col3.TextAlign = HorizontalAlignment.Center
            col4.TextAlign = HorizontalAlignment.Center
            col5.TextAlign = HorizontalAlignment.Left
            col6.TextAlign = HorizontalAlignment.Left

            col1.Width = 80     ' No
            col2.Width = 120    ' 処理日
            col3.Width = 100    ' 支店コード
            col4.Width = 100    ' 処理通数
            col5.Width = 200    ' 種別
            'col6.Width = 300    ' 対象ファイル名
            col6.Width = 2      ' 対象ファイル名

            Dim colHeader() As ColumnHeader = {col1, col2, col3, col4, col5, col6}
            lstGetDataView.Columns.AddRange(colHeader)

        Catch ex As Exception
            MsgBox("【DisplayHeader】" & ex.Message)
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
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub DateTimePicker1_ValueChanged(sender As System.Object, e As System.EventArgs) Handles DateTimePicker1.ValueChanged

        ' CSV出力対象ファイルの表示処理
        Call DispCsvOutFile()

    End Sub

    ''' <summary>
    ''' CSV出力対象ファイルの表示処理
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DispCsvOutFile()

        Dim col(5) As String
        Dim itm As ListViewItem
        Dim strReadDataFileName As String
        Dim strArray() As String = Nothing
        Dim strDateArray() As String
        Dim intNumber As Integer = 1

        ' 集計対象日から対象フォルダを確定する
        Dim strSearchDir As String = IncludeTrailingPathDelimiter(PubConstClass.imgPath) & DateTimePicker1.Value.ToString("yyyyMMdd") & "\"

        Try
            lstGetDataView.Items.Clear()
            If System.IO.Directory.Exists(strSearchDir) = False Then
                '// 2016.02.05 Ver.B06 hayakawa 修正↓ここから                
                'MsgBox("集計対象フォルダが見つかりません", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")
                '// 2016.02.05 Ver.B06 hayakawa 修正↑ここまで
                Exit Sub
            End If
            If System.IO.Directory.GetFiles(strSearchDir, "*.LOG", System.IO.SearchOption.AllDirectories).Count < 1 Then
                '// 2016.02.05 Ver.B06 hayakawa 修正↓ここから                
                'MsgBox("集計対象ファイルが見つかりません", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")
                '// 2016.02.05 Ver.B06 hayakawa 修正↑ここまで
                Exit Sub
            End If

            ' 種別ファイル読込フラグ
            Dim blnIsReadClassMaster As Boolean
            Dim arReadData As New ArrayList
            Dim strReadData As String

            Dim arWork As New ArrayList

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
                    arWork.Add(col(4) & "," & col(2) & "," & col(3) & "," & col(5))

                End Using

            Next

            OutPutLogFile("【CSV出力】〓〓〓〓〓ソート前〓〓〓〓〓")
            For N = 0 To arWork.Count - 1
                OutPutLogFile("【CSV出力】" & arWork(N).ToString)
            Next

            ' 種別と支店コードで昇順にソートする
            arWork.Sort()

            OutPutLogFile("【CSV出力】〓〓〓〓〓ソート後〓〓〓〓〓")
            For N = 0 To arWork.Count - 1
                OutPutLogFile("【CSV出力】" & arWork(N).ToString)
            Next

            For Each strFileList In arWork
                '            0       1   2                                                   3
                '030：簡易書留,0145-00,145,C:\RECDEL\IMG\20150729\稼動ログ_20150729_102140.LOG
                '150：ゆうメール（簡易書留）,0079-00,79,C:\RECDEL\IMG\20150729\稼動ログ_20150729_150418.LOG
                strArray = strFileList.ToString.Split(","c)

                strReadDataFileName = strArray(3)
                blnIsReadClassMaster = False
                Using sr As New System.IO.StreamReader(strReadDataFileName, System.Text.Encoding.Default)
                    '    0,                                  1,                  2,             3,  4,  5,                                                            6,           7,      8,       9  10,  11,
                    '00001,001：簡易書留郵便（定型ラベル右上）,2015/07/28 19:44:18,358-19-00001-1,894,910,C:\RECDEL\IMG\20150728\194347\image_20150728_194418_00001.jpg,30：簡易書留,0234-00,蟹江支店,234,定形,
                    arReadData.Clear()
                    ' ファイルから１行読込む
                    strReadData = sr.ReadLine.ToString
                    ' アレイリストに追加
                    arReadData.Add(strReadData)
                    ' カンマ単位にデータを分解
                    strArray = strReadData.Split(","c)
                    ' 種別単位の重量及び料金データを読込む
                    Call GetClassMasterData(strArray(7))

                    col(0) = intNumber.ToString("000")      ' No.
                    ' 処理日のみを切り出す
                    strDateArray = strArray(2).Split(" "c)
                    col(1) = strDateArray(0)                ' 処理日
                    col(2) = strArray(8)                    ' 支店コード
                    col(3) = strArray(10)                   ' 処理数
                    col(4) = strArray(7)                    ' 種別
                    col(5) = strReadDataFileName            ' 対象ファイル名

                    ' 対象ファイルをリストアップする
                    itm = New ListViewItem(col)
                    'itm.Checked = True
                    lstGetDataView.Items.Add(itm)
                    'lstGetDataView.Items(lstGetDataView.Items.Count - 1).Selected = True
                    'lstGetDataView.Items(lstGetDataView.Items.Count - 1).Focused = True
                    'lstGetDataView.Select()
                    'lstGetDataView.Items(lstGetDataView.Items.Count - 1).EnsureVisible()

                    intNumber += 1

                End Using

            Next

        Catch ex As Exception
            MsgBox("【DispCsvOutFile】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 「CSV出力」ボタン処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnCsvOutPut_Click(sender As System.Object, e As System.EventArgs) Handles BtnCsvOutPut.Click

        Dim arReadData As New ArrayList
        Dim fbd As New FolderBrowserDialog
        Dim strSaveFolder As String

        Try
            Dim retVal As MsgBoxResult
            retVal = MsgBox("ＣＳＶ出力を行いますか？", CType(MsgBoxStyle.Question + MsgBoxStyle.OkCancel, MsgBoxStyle), "確認")
            If retVal = MsgBoxResult.Cancel Then
                ' キャンセル
                Exit Sub
            End If


            fbd.Description = "ＣＳＶ出力するフォルダを選択してください。"

            fbd.RootFolder = Environment.SpecialFolder.Desktop
            fbd.SelectedPath = "D:\"

            ' 新規フォルダ作成を表示
            fbd.ShowNewFolderButton = True

            If fbd.ShowDialog(Me) = DialogResult.OK Then
                ' 選択されたフォルダを表示する
                strSaveFolder = fbd.SelectedPath
                'MsgBox(strSaveFolder)
            Else
                Exit Sub
            End If

            ' 書込ファイル名の設定
            Dim strOutPutFileName As String = ""

            ' ADP用ファイル名の作成
            strOutPutFileName = IncludeTrailingPathDelimiter(strSaveFolder) &
                                    "DAY_" & DateTimePicker1.Value.ToString("yyyyMMdd") & ".csv"

            ' 追記する前に該当ファイルを削除する
            System.IO.File.Delete(strOutPutFileName)
            blnIsHeaderWrite = False
            ' ＡＤＰ集計システム用
            CsvDataOutPut(True, strOutPutFileName)

            'If ChkAdp.Checked = True Then
            '    ' ADP用ファイル名の作成
            '    '// 2017.09.29 Ver.B08e hayakawa 変更↓ここから
            '    strOutPutFileName = IncludeTrailingPathDelimiter(strSaveFolder) &
            '                        "DAY_" & DateTimePicker1.Value.ToString("yyyyMMdd") & ".csv"
            '    '// 2017.09.29 Ver.B08e hayakawa 変更↑ここまで

            '    ' 追記する前に該当ファイルを削除する
            '    System.IO.File.Delete(strOutPutFileName)
            '    blnIsHeaderWrite = False
            '    ' ＡＤＰ集計システム用
            '    CsvDataOutPut(True, strOutPutFileName)
            'End If

            'If ChkMitsubishi.Checked = True Then
            '    ' 三菱電機集計用ファイル名の作成
            '    '// 2017.09.29 Ver.B08e hayakawa 変更↓ここから
            '    strOutPutFileName = IncludeTrailingPathDelimiter(strSaveFolder) &
            '        "TOPPAN_" & DateTimePicker1.Value.ToString("yyyyMMdd") & ".csv"
            '    '// 2017.09.29 Ver.B08e hayakawa 変更↑ここまで

            '    ' 追記する前に該当ファイルを削除する
            '    System.IO.File.Delete(strOutPutFileName)
            '    blnIsHeaderWrite = False
            '    ' 三菱電機集計システム用
            '    CsvDataOutPut(False, strOutPutFileName)
            'End If

            MsgBox("ＣＳＶ出力処理が完了しました", CType(MsgBoxStyle.Question + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")

        Catch ex As Exception
            MsgBox("【BtnCsvOutPut_Click】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 集計用CSV出力処理
    ''' </summary>
    ''' <param name="blnIsAdp">TRUE：ADP用データ（定形外50g）の出力</param>
    ''' <param name="strOutPutFileName">CSV出力ファイル名</param>
    ''' <remarks></remarks>
    Private Sub CsvDataOutPut(ByVal blnIsAdp As Boolean, ByVal strOutPutFileName As String)

        Dim strReadDataFileName As String
        Dim strReadData As String
        Dim strArray() As String
        Dim arReadData As New ArrayList

        Try
            arReadData.Clear()
            For N = 0 To lstGetDataView.Items.Count - 1
                '  0      1          2      3    4            5
                'No.,処理日,支店コード,処理数,種別,対象ファイル
                '150：ゆうメール（簡易書留）,0079-00,79,C:\RECDEL\IMG\20150729\稼動ログ_20150729_150418.LOG
                strReadDataFileName = lstGetDataView.Items(N).SubItems(5).Text
                Using sr As New System.IO.StreamReader(strReadDataFileName, System.Text.Encoding.Default)
                    '    0,                1,                  2,             3,  4,  5,                                                            6,           7,      8,       9  10,  11,12
                    '00001,001：簡易書留郵便,2015/07/28 19:44:18,358-19-00001-1,894,910,C:\RECDEL\IMG\20150728\194347\image_20150728_194418_00001.jpg,30：簡易書留,0234-00,蟹江支店,234,定形,■
                    'arReadData.Clear()

                    ' ファイルから１行読込む
                    strReadData = sr.ReadLine.ToString

                    Dim strChkArray() As String = strReadData.Split(","c)
                    Dim strChkArrayTarget() As String = strChkArray(7).Split("："c)
                    ' 簡易書留のみ対象とする
                    If blnIsAdp = False Then
                        'If strChkArrayTarget(0) = "30" Or strChkArrayTarget(0) = "40" Then
                        If strChkArrayTarget(0) = "30" Then
                            ' アレイリストに追加
                            arReadData.Add(strReadData)
                            ' カンマ単位にデータを分解
                            strArray = strReadData.Split(","c)
                            ' 種別単位の重量及び料金データを読込む
                            Call GetClassMasterData(strArray(7))
                            ' 対象ファイルの内容を格納する
                            Do While Not sr.EndOfStream
                                strReadData = sr.ReadLine.ToString
                                arReadData.Add(strReadData)
                            Loop
                            ' 対象
                            'GetTranCntAndAmount(arReadData, blnIsAdp, strOutPutFileName)
                        End If
                    Else
                        ' アレイリストに追加
                        arReadData.Add(strReadData)
                        ' カンマ単位にデータを分解
                        strArray = strReadData.Split(","c)
                        ' 種別単位の重量及び料金データを読込む
                        Call GetClassMasterData(strArray(7))
                        ' 対象ファイルの内容を格納する
                        Do While Not sr.EndOfStream
                            strReadData = sr.ReadLine.ToString
                            arReadData.Add(strReadData)
                        Loop
                        ' 対象
                        'GetTranCntAndAmount(arReadData, blnIsAdp, strOutPutFileName)
                    End If

                End Using

            Next

            For N = 0 To arReadData.Count - 1
                OutPutLogFile("【arReadData】" & arReadData(N).ToString)
            Next

            '// 2016.01.15 Ver.B05 hayakawa 追加↓ここから
            '    0,                    1,                  2,             3, 4,  5,                                                            6,           7,8,   9, 0,   1,
            '00001,001：簡易書留（定形）,2016/01/06 14:58:28,464-65-17329-6,13,392,C:\RECDEL\IMG\20160106\145812\image_20160106_145828_00001.jpg,30：簡易書留,1,本店,26,定形,
            Dim arForSort As New ArrayList          '  「種別ｺｰﾄﾞ＋支店ｺｰﾄﾞ」でソートする為のアレイリスト
            Dim strArrayForSort() As String         ' 項目分解用配列
            Dim strArrayForSyubetu() As String      ' 種別ｺｰﾄﾞ取得用配列
            arForSort.Clear()
            ' 読込アレイリスト（arReadData）からソート用アレイリスト（arForSort）に読込データの先頭に「種別ｺｰﾄﾞ＋支店ｺｰﾄﾞ＋〓」を付加して追加する
            For N = 0 To arReadData.Count - 1
                strArrayForSort = arReadData(N).ToString.Split(","c)        ' 項目別に分解する 
                strArrayForSyubetu = strArrayForSort(7).Split("："c)        ' 種別ｺｰﾄﾞを取得する   
                arForSort.Add(CInt(strArrayForSyubetu(0)).ToString("000") & CInt(strArrayForSort(8)).ToString("00000") & "〓" & arReadData(N).ToString)
            Next
            ' 「種別ｺｰﾄﾞ＋支店ｺｰﾄﾞ」でソートする
            arForSort.Sort()
            'For N = 0 To arForSort.Count - 1
            '    OutPutLogFile("【arForSort】" & arForSort(N).ToString)
            'Next
            arReadData.Clear()
            For N = 0 To arForSort.Count - 1
                strArrayForSort = arForSort(N).ToString.Split("〓"c)
                arReadData.Add(strArrayForSort(1))
            Next
            For N = 0 To arReadData.Count - 1
                OutPutLogFile("「種別ｺｰﾄﾞ＋支店ｺｰﾄﾞ」でソート【arReadData】" & arReadData(N).ToString)
            Next
            '// 2016.01.15 Ver.B05 hayakawa 追加↑ここまで

            If blnIsAdp = False Then
                Call CsvOutPutForSitenAndWeight(arReadData, blnIsAdp, strOutPutFileName)
                'GetTranCntAndAmount(arReadData, blnIsAdp, strOutPutFileName)
            Else
                Call CsvOutPutForSitenAndWeight(arReadData, blnIsAdp, strOutPutFileName)
                'GetTranCntAndAmount(arReadData, blnIsAdp, strOutPutFileName)
            End If

        Catch ex As Exception
            MsgBox("【CsvDataOutPut】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 「支店」「重量」でサマリする処理
    ''' </summary>
    ''' <param name="arReadData"></param>
    ''' <param name="blnIsAdp"></param>
    ''' <param name="strOutPutFileName"></param>
    ''' <remarks></remarks>
    Private Sub CsvOutPutForSitenAndWeight(ByVal arReadData As ArrayList, ByVal blnIsAdp As Boolean, ByVal strOutPutFileName As String)

        Dim N As Integer
        Dim strArray() As String
        'Dim strBeforeData As String = ""
        Dim strBeforeSyubetu As String = ""
        Dim strBeforeSiten As String = ""
        Dim arSiten As ArrayList = New ArrayList
        arSiten.Clear()

        Try
            '    1      2                   3              4    5   6                                                             7            8 9    0  1    2 3   
            '00010,001：A,2015/09/27 18:09:21,358-19-00303-2,0020,392,C:\RECDEL\IMG\20150927\180832\image_20150927_180920_00010.jpg,30：簡易書留,1,本店,10,定形,
            For N = 0 To arReadData.Count - 1
                strArray = arReadData(N).ToString.Split(","c)
                If (strArray(7) = strBeforeSyubetu Or strBeforeSyubetu = "") And (strArray(8) = strBeforeSiten Or strBeforeSiten = "") Then
                    strBeforeSyubetu = strArray(7)
                    strBeforeSiten = strArray(8)
                    arSiten.Add(arReadData(N).ToString)
                    OutPutLogFile("【arSiten.Add】" & arReadData(N).ToString)
                Else
                    GetTranCntAndAmount(arSiten, blnIsAdp, strOutPutFileName)
                    OutPutLogFile("【GetTranCntAndAmount呼出】" & arReadData(N).ToString)
                    strBeforeSyubetu = strArray(7)
                    strBeforeSiten = strArray(8)
                    arSiten.Clear()
                    arSiten.Add(arReadData(N).ToString)
                    OutPutLogFile("【arSiten.Add】" & arReadData(N).ToString)
                End If
            Next
            ' 最後のデータが存在する場合のCSV出力処理
            If arSiten.Count > 0 Then
                GetTranCntAndAmount(arSiten, blnIsAdp, strOutPutFileName)
                'OutPutLogFile("【GetTranCntAndAmount呼出】" & arReadData(N - 1).ToString)
            End If

        Catch ex As Exception
            MsgBox("【CsvOutPutForSitenAndWeight】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 「通数」と「合計金額」と「通数の合計」と「合計金額の合計」を求める
    ''' </summary>
    ''' <param name="arReadData">集計用データ格納アレイリスト</param>
    ''' <param name="blnIsAdp">TRUE：ADP用データ（定形外50g）の出力</param>
    ''' <param name="strOutPutFileName">CSV出力ファイル名</param>
    ''' <remarks></remarks>
    Private Sub GetTranCntAndAmount(ByVal arReadData As ArrayList, ByVal blnIsAdp As Boolean, ByVal strOutPutFileName As String)

        Dim strChkData As String
        Dim strTeikei As String         ' 「0：定形／1:定形外」変数
        Dim strArray() As String
        Dim strDateArray() As String
        Dim strPutData As String        ' 出力用データ格納変数

        Try

            intTranALLCnt = 0
            intAmountALL = 0
            For N = 0 To strTranCnt.Length - 1
                strTranCnt(N) = "0"     ' 通数格納配列クリア（定形）
                strAmount(N) = "0"      ' 合計金額格納配列クリア（定形）
            Next
            For N = 0 To strTranCntGai.Length - 1
                strTranCntGai(N) = "0"  ' 通数格納配列クリア（定形外／規格内）
                strAmountGai(N) = "0"   ' 合計金額格納配列クリア（定形外／規格内）
            Next
            For N = 0 To strTranCntNonS.Length - 1
                strTranCntNonS(N) = "0"  ' 通数格納配列クリア（定形外／規格外）
                strAmountNonS(N) = "0"   ' 合計金額格納配列クリア（定形外／規格外）
            Next

            strArray = arReadData(0).ToString.Split(","c)
            strDateArray = strArray(2).Split(" "c)

            Dim strSyubetu As String = strArray(7)
            Dim strSitenCode As String = strArray(8)
            Dim strSitenName As String = strArray(9)
            Dim strTranDate As String = strDateArray(0).Replace("/", "")

            '// 2016.01.15 Ver.B05 hayakawa 追加↓ここから
            Call GetClassMasterData(strSyubetu)
            '// 2016.01.15 Ver.B05 hayakawa 追加↑ここまで

            '    0,                1,                  2,             3,  4,  5,                                                            6,           7,      8,       9  10,  11,12
            '00001,001：簡易書留郵便,2015/07/28 19:44:18,358-19-00001-1,894,910,C:\RECDEL\IMG\20150728\194347\image_20150728_194418_00001.jpg,30：簡易書留,0234-00,蟹江支店,234,定形,■
            For Each ar In arReadData
                strArray = ar.ToString.Split(","c)
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

            For N = 0 To strTranCnt.Length - 1
                ' 通数の合計を求める
                intTranALLCnt += CInt(strTranCnt(N))
                ' 合計金額の合計を求める
                intAmountALL += CInt(strAmount(N))
            Next
            For N = 0 To strTranCntGai.Length - 1
                ' 通数の合計を求める
                intTranALLCntGai += CInt(strTranCntGai(N))
                ' 合計金額の合計を求める
                intAmountALLGai += CInt(strAmountGai(N))
            Next
            For N = 0 To strTranCntNonS.Length - 1
                ' 通数の合計を求める
                intTranALLCntNonS += CInt(strTranCntNonS(N))
                ' 合計金額の合計を求める
                intAmountALLNonS += CInt(strAmountNonS(N))
            Next

            ' 追記モードで書き込む
            Using sw As New System.IO.StreamWriter(strOutPutFileName, True, System.Text.Encoding.Default)

                If blnIsHeaderWrite = False Then
                    blnIsHeaderWrite = True
                    ' ヘッダーの書き込み
                    '// 2017.05.24 Ver.B08 hayakawa 修正↓ここから
                    If blnIsAdp = True Then
                        'strPutData = "作業日,店舗番号,店舗名,種別コード,種別名,重量範囲,重量コード,金額,通数,合計金額"
                        strPutData = "作業日,店舗番号,店舗名,種別コード,種別名,料金区分,重量範囲,重量コード,規格区分,金額,通数,本人限定"
                    Else
                        strPutData = "作業日,店舗番号,店舗名,種別コード,種別名,料金区分,重量範囲,重量コード,規格区分,金額,通数,本人限定"
                    End If
                    '// 2017.05.24 Ver.B08 hayakawa 修正↑ここまで
                    sw.WriteLine(strPutData)
                End If

                For N = 0 To strTranCnt.Length - 1
                    If strTranCnt(N) = "0" Or strTranCnt(N) = "" Then
                        '// 出力しない
                    Else
                        strArray = strSyubetu.Split("："c)
                        If blnIsAdp = True Then
                            ' ADP集計用フォーマット
                            'strPutData = strTranDate & "," & _
                            '              strSitenCode & "," & _
                            '              strSitenName & "," & _
                            '              strArray(0) & "," & _
                            '              strArray(1) & "," & _
                            '              PubConstClass.strWeightArray(N) & "," & _
                            '              PubConstClass.strWeightArray(N) & "," & _
                            '              PubConstClass.strPriceArray(N) & "," & _
                            '              strTranCnt(N) & "," & _
                            '              strAmount(N)
                            strPutData = strTranDate & "," &
                                          strSitenCode & "," &
                                          strSitenName & "," &
                                          strArray(0) & "," &
                                          strArray(1) & "," &
                                          "1," &
                                          PubConstClass.strWeightArray(N) & "," &
                                          PubConstClass.strWeightArray(N) & "," &
                                          "0," &
                                          PubConstClass.strPriceArray(N) & "," &
                                          strTranCnt(N)
                        Else
                            ' 三菱電機集計用フォーマット
                            strPutData = strTranDate & "," &
                                          strSitenCode & "," &
                                          strSitenName & "," &
                                          strArray(0) & "," &
                                          strArray(1) & "," &
                                          "1," &
                                          PubConstClass.strWeightArray(N) & "," &
                                          PubConstClass.strWeightArray(N) & "," &
                                          "0," &
                                          PubConstClass.strPriceArray(N) & "," &
                                          strTranCnt(N)
                        End If

                        ' 本人限定のチェックと置換を行う
                        strPutData = CheckPersonLimited(strPutData)
                        sw.WriteLine(strPutData)
                        ' 操作履歴ログに格納
                        OutPutLogFile("【CSV出力】" & strPutData)

                    End If
                Next

                For N = 0 To strTranCntGai.Length - 1
                    If strTranCntGai(N) = "0" Or strTranCntGai(N) = "" Then
                        '// 出力しない
                    Else
                        strArray = strSyubetu.Split("："c)
                        If blnIsAdp = True Then
                            ' ADP集計用フォーマット
                            'strPutData = strTranDate & "," & _
                            '              strSitenCode & "," & _
                            '              strSitenName & "," & _
                            '              strArray(0) & "," & _
                            '              strArray(1) & "," & _
                            '              PubConstClass.strWeightGaiArray(N) & "," & _
                            '              PubConstClass.strWeightGaiArray(N) & "," & _
                            '              PubConstClass.strPriceGaiArray(N) & "," & _
                            '              strTranCntGai(N) & "," & _
                            '              strAmountGai(N)
                            strPutData = strTranDate & "," &
                                          strSitenCode & "," &
                                          strSitenName & "," &
                                          strArray(0) & "," &
                                          strArray(1) & "," &
                                          "1," &
                                          PubConstClass.strWeightGaiArray(N) & "," &
                                          PubConstClass.strWeightGaiArray(N) & "," &
                                          "1," &
                                          PubConstClass.strPriceGaiArray(N) & "," &
                                          strTranCntGai(N)

                        Else
                            ' 三菱電機集計用フォーマット
                            strPutData = strTranDate & "," &
                                          strSitenCode & "," &
                                          strSitenName & "," &
                                          strArray(0) & "," &
                                          strArray(1) & "," &
                                          "1," &
                                          PubConstClass.strWeightGaiArray(N) & "," &
                                          PubConstClass.strWeightGaiArray(N) & "," &
                                          "1," &
                                          PubConstClass.strPriceGaiArray(N) & "," &
                                          strTranCntGai(N)
                        End If


                        ' 本人限定のチェックと置換を行う
                        strPutData = CheckPersonLimited(strPutData)

                        sw.WriteLine(strPutData)
                        ' 操作履歴ログに格納
                        OutPutLogFile("【CSV出力】" & strPutData)
                    End If
                Next

                For N = 0 To strTranCntNonS.Length - 1
                    If strTranCntNonS(N) = "0" Or strTranCntNonS(N) = "" Then
                        '// 出力しない
                    Else
                        strArray = strSyubetu.Split("："c)
                        If blnIsAdp = True Then
                            ' ADP集計用フォーマット
                            'strPutData = strTranDate & "," & _
                            '              strSitenCode & "," & _
                            '              strSitenName & "," & _
                            '              strArray(0) & "," & _
                            '              strArray(1) & "," & _
                            '              PubConstClass.strWeightNonSArray(N) & "," & _
                            '              PubConstClass.strWeightNonSArray(N) & "," & _
                            '              PubConstClass.strPriceNonSArray(N) & "," & _
                            '              strTranCntNonS(N) & "," & _
                            '              strAmountNonS(N)
                            strPutData = strTranDate & "," &
                                          strSitenCode & "," &
                                          strSitenName & "," &
                                          strArray(0) & "," &
                                          strArray(1) & "," &
                                          "2," &
                                          PubConstClass.strWeightNonSArray(N) & "," &
                                          PubConstClass.strWeightNonSArray(N) & "," &
                                          "2," &
                                          PubConstClass.strPriceNonSArray(N) & "," &
                                          strTranCntNonS(N)

                        Else
                            ' 三菱電機集計用フォーマット
                            strPutData = strTranDate & "," &
                                          strSitenCode & "," &
                                          strSitenName & "," &
                                          strArray(0) & "," &
                                          strArray(1) & "," &
                                          "2," &
                                          PubConstClass.strWeightNonSArray(N) & "," &
                                          PubConstClass.strWeightNonSArray(N) & "," &
                                          "2," &
                                          PubConstClass.strPriceNonSArray(N) & "," &
                                          strTranCntNonS(N)
                        End If

                        ' 本人限定のチェックと置換を行う
                        strPutData = CheckPersonLimited(strPutData)

                        sw.WriteLine(strPutData)
                        ' 操作履歴ログに格納
                        OutPutLogFile("【CSV出力】" & strPutData)
                    End If
                Next

            End Using

        Catch ex As Exception
            MsgBox("【CsvOutPutForm.GetTranCntAndAmount】" & ex.Message)
        End Try

    End Sub


    ''' <summary>
    ''' 本人限定のチェックと置換を行う
    ''' </summary>
    ''' <param name="sData"></param>
    ''' <returns></returns>
    Private Function CheckPersonLimited(sData As String) As String

        Try
            ' デバッグの為に取り敢えず何もせずに返す
            'Return sData

            ' 本人限定文字列
            Dim aryPersonal As String() = New String() {",75,書留（本人限定）,", ",85,書留速達（本人限定）,",
                                                        ",95,配達証明（本人限定）,", ",105,配達証明速達（本人限定）,"}

            Dim aryNonPersonal As String() = New String() {",70,書留,", ",80,書留速達,",
                                                           ",90,配達証明,", ",100,配達証明速達,"}
            '  本人限定フラグ
            Dim bPersonalFlag As Boolean = False

            For iPersonal = 0 To aryPersonal.Length - 1
                If sData.Contains(aryPersonal(iPersonal)) Then
                    ' 本人限定あり
                    sData = sData.Replace(aryPersonal(iPersonal), aryNonPersonal(iPersonal))
                    bPersonalFlag = True
                    Exit For
                End If
            Next iPersonal

            If bPersonalFlag = True Then
                ' 本人限定
                sData += ",1"
            Else
                sData += ",0"
            End If

            Return sData

        Catch ex As Exception
            MsgBox("【CheckPersonLimited】" & ex.Message)
            Return sData
        End Try

    End Function

    ' ''' <summary>
    ' ''' 重量から通数をカウントアップする
    ' ''' </summary>
    ' ''' <param name="strWeight">重量</param>
    ' ''' <param name="strTeikei">0：定形／1：定形外</param>
    ' ''' <remarks></remarks>
    Private Sub GetTranCntFromWeight(ByVal strWeight As String, ByVal strTeikei As String)


        Dim strRetVal As String = "範囲外"
        Dim intWeight As Integer = CInt(strWeight)

        Try

            If strTeikei = "0" Then
                ' 定形
                If intWeight <= CInt(PubConstClass.strWeightArray(0)) Then
                    strTranCnt(0) = (CInt(strTranCnt(0)) + 1).ToString("0")
                    strAmount(0) = (CInt(strTranCnt(0)) * CInt(PubConstClass.strPriceArray(0))).ToString("0")

                ElseIf intWeight <= CInt(PubConstClass.strWeightArray(1)) Then
                    strTranCnt(1) = (CInt(strTranCnt(1)) + 1).ToString("0")
                    strAmount(1) = (CInt(strTranCnt(1)) * CInt(PubConstClass.strPriceArray(1))).ToString("0")

                ElseIf intWeight <= CInt(PubConstClass.strWeightArray(2)) Then
                    strTranCnt(2) = (CInt(strTranCnt(2)) + 1).ToString("0")
                    strAmount(2) = (CInt(strTranCnt(2)) * CInt(PubConstClass.strPriceArray(2))).ToString("0")

                ElseIf intWeight <= CInt(PubConstClass.strWeightArray(3)) Then
                    strTranCnt(3) = (CInt(strTranCnt(3)) + 1).ToString("0")
                    strAmount(3) = (CInt(strTranCnt(3)) * CInt(PubConstClass.strPriceArray(3))).ToString("0")

                ElseIf intWeight <= CInt(PubConstClass.strWeightArray(4)) Then
                    strTranCnt(4) = (CInt(strTranCnt(4)) + 1).ToString("0")
                    strAmount(4) = (CInt(strTranCnt(4)) * CInt(PubConstClass.strPriceArray(4))).ToString("0")

                ElseIf intWeight <= CInt(PubConstClass.strWeightArray(5)) Then
                    strTranCnt(5) = (CInt(strTranCnt(5)) + 1).ToString("0")
                    strAmount(5) = (CInt(strTranCnt(5)) * CInt(PubConstClass.strPriceArray(5))).ToString("0")

                ElseIf intWeight <= CInt(PubConstClass.strWeightArray(6)) Then
                    strTranCnt(6) = (CInt(strTranCnt(6)) + 1).ToString("0")
                    strAmount(6) = (CInt(strTranCnt(6)) * CInt(PubConstClass.strPriceArray(6))).ToString("0")

                ElseIf intWeight <= CInt(PubConstClass.strWeightArray(7)) Then
                    strTranCnt(7) = (CInt(strTranCnt(7)) + 1).ToString("0")
                    strAmount(7) = (CInt(strTranCnt(7)) * CInt(PubConstClass.strPriceArray(7))).ToString("0")

                ElseIf intWeight <= CInt(PubConstClass.strWeightArray(8)) Then
                    strTranCnt(8) = (CInt(strTranCnt(8)) + 1).ToString("0")
                    strAmount(8) = (CInt(strTranCnt(8)) * CInt(PubConstClass.strPriceArray(8))).ToString("0")
                Else
                    strRetVal = "範囲外"
                End If

            ElseIf strTeikei = "1" Then
                ' 定形外(規格内)
                If intWeight <= CInt(PubConstClass.strWeightGaiArray(0)) Then
                    strTranCntGai(0) = (CInt(strTranCntGai(0)) + 1).ToString("0")
                    strAmountGai(0) = (CInt(strTranCntGai(0)) * CInt(PubConstClass.strPriceGaiArray(0))).ToString("0")

                ElseIf intWeight <= CInt(PubConstClass.strWeightGaiArray(1)) Then
                    strTranCntGai(1) = (CInt(strTranCntGai(1)) + 1).ToString("0")
                    strAmountGai(1) = (CInt(strTranCntGai(1)) * CInt(PubConstClass.strPriceGaiArray(1))).ToString("0")

                ElseIf intWeight <= CInt(PubConstClass.strWeightGaiArray(2)) Then
                    strTranCntGai(2) = (CInt(strTranCntGai(2)) + 1).ToString("0")
                    strAmountGai(2) = (CInt(strTranCntGai(2)) * CInt(PubConstClass.strPriceGaiArray(2))).ToString("0")

                ElseIf intWeight <= CInt(PubConstClass.strWeightGaiArray(3)) Then
                    strTranCntGai(3) = (CInt(strTranCntGai(3)) + 1).ToString("0")
                    strAmountGai(3) = (CInt(strTranCntGai(3)) * CInt(PubConstClass.strPriceGaiArray(3))).ToString("0")

                ElseIf intWeight <= CInt(PubConstClass.strWeightGaiArray(4)) Then
                    strTranCntGai(4) = (CInt(strTranCntGai(4)) + 1).ToString("0")
                    strAmountGai(4) = (CInt(strTranCntGai(4)) * CInt(PubConstClass.strPriceGaiArray(4))).ToString("0")

                ElseIf intWeight <= CInt(PubConstClass.strWeightGaiArray(5)) Then
                    strTranCntGai(5) = (CInt(strTranCntGai(5)) + 1).ToString("0")
                    strAmountGai(5) = (CInt(strTranCntGai(5)) * CInt(PubConstClass.strPriceGaiArray(5))).ToString("0")

                ElseIf intWeight <= CInt(PubConstClass.strWeightGaiArray(6)) Then
                    strTranCntGai(6) = (CInt(strTranCntGai(6)) + 1).ToString("0")
                    strAmountGai(6) = (CInt(strTranCntGai(6)) * CInt(PubConstClass.strPriceGaiArray(6))).ToString("0")

                ElseIf intWeight <= CInt(PubConstClass.strWeightGaiArray(7)) Then
                    strTranCntGai(7) = (CInt(strTranCntGai(7)) + 1).ToString("0")
                    strAmountGai(7) = (CInt(strTranCntGai(7)) * CInt(PubConstClass.strPriceGaiArray(7))).ToString("0")
                Else
                    strRetVal = "範囲外"
                End If
            Else
                ' 定形外(規格内)
                If intWeight <= CInt(PubConstClass.strWeightNonSArray(0)) Then
                    strTranCntNonS(0) = (CInt(strTranCntNonS(0)) + 1).ToString("0")
                    strAmountNonS(0) = (CInt(strTranCntNonS(0)) * CInt(PubConstClass.strPriceNonSArray(0))).ToString("0")

                ElseIf intWeight <= CInt(PubConstClass.strWeightNonSArray(1)) Then
                    strTranCntNonS(1) = (CInt(strTranCntNonS(1)) + 1).ToString("0")
                    strAmountNonS(1) = (CInt(strTranCntNonS(1)) * CInt(PubConstClass.strPriceNonSArray(1))).ToString("0")

                ElseIf intWeight <= CInt(PubConstClass.strWeightNonSArray(2)) Then
                    strTranCntNonS(2) = (CInt(strTranCntNonS(2)) + 1).ToString("0")
                    strAmountNonS(2) = (CInt(strTranCntNonS(2)) * CInt(PubConstClass.strPriceNonSArray(2))).ToString("0")

                ElseIf intWeight <= CInt(PubConstClass.strWeightNonSArray(3)) Then
                    strTranCntNonS(3) = (CInt(strTranCntNonS(3)) + 1).ToString("0")
                    strAmountNonS(3) = (CInt(strTranCntNonS(3)) * CInt(PubConstClass.strPriceNonSArray(3))).ToString("0")

                ElseIf intWeight <= CInt(PubConstClass.strWeightNonSArray(4)) Then
                    strTranCntNonS(4) = (CInt(strTranCntNonS(4)) + 1).ToString("0")
                    strAmountNonS(4) = (CInt(strTranCntNonS(4)) * CInt(PubConstClass.strPriceNonSArray(4))).ToString("0")

                ElseIf intWeight <= CInt(PubConstClass.strWeightNonSArray(5)) Then
                    strTranCntNonS(5) = (CInt(strTranCntNonS(5)) + 1).ToString("0")
                    strAmountNonS(5) = (CInt(strTranCntNonS(5)) * CInt(PubConstClass.strPriceNonSArray(5))).ToString("0")

                ElseIf intWeight <= CInt(PubConstClass.strWeightNonSArray(6)) Then
                    strTranCntNonS(6) = (CInt(strTranCntNonS(6)) + 1).ToString("0")
                    strAmountNonS(6) = (CInt(strTranCntNonS(6)) * CInt(PubConstClass.strPriceNonSArray(6))).ToString("0")

                ElseIf intWeight <= CInt(PubConstClass.strWeightNonSArray(7)) Then
                    strTranCntNonS(7) = (CInt(strTranCntNonS(7)) + 1).ToString("0")
                    strAmountNonS(7) = (CInt(strTranCntNonS(7)) * CInt(PubConstClass.strPriceNonSArray(7))).ToString("0")
                Else
                    strRetVal = "範囲外"
                End If

            End If

        Catch ex As Exception
            MsgBox("【GetTranCntFromWeight】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 「参照」ボタン処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnRef_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRef.Click

        Try
            'OpenFileDialogクラスのインスタンスを作成
            Dim ofd As New OpenFileDialog()

            'はじめのファイル名を指定する
            'はじめに「ファイル名」で表示される文字列を指定する
            ofd.FileName = "default.csv"
            'はじめに表示されるフォルダを指定する
            '指定しない（空の文字列）の時は、現在のディレクトリが表示される
            ofd.InitialDirectory = "E:\"
            '[ファイルの種類]に表示される選択肢を指定する
            '指定しないとすべてのファイルが表示される
            ofd.Filter = "すべてのファイル(*.*)|*.*"
            '[ファイルの種類]ではじめに
            '「すべてのファイル」が選択されているようにする
            ofd.FilterIndex = 2
            'タイトルを設定する
            ofd.Title = "開くファイルを選択してください"
            'ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
            ofd.RestoreDirectory = True
            '存在しないファイルの名前が指定されたとき警告を表示する
            'デフォルトでTrueなので指定する必要はない
            ofd.CheckFileExists = True
            '存在しないパスが指定されたとき警告を表示する
            'デフォルトでTrueなので指定する必要はない
            ofd.CheckPathExists = True

            'ダイアログを表示する
            If ofd.ShowDialog() = DialogResult.OK Then
                'OKボタンがクリックされたとき
                '選択されたファイル名を表示する
                Console.WriteLine(ofd.FileName)
            End If
        Catch ex As Exception
            MsgBox("【BtnRef_Click】" & ex.Message)
        End Try

    End Sub

End Class