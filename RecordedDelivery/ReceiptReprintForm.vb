Option Explicit On
Option Strict On

Public Class ReceiptReprintForm

    'Private intImageDataCount As Integer

    Private objSync As Object
    Private objPrintSync As Object
    Private objPrintSyncReserve As Object

    ''' <summary>
    ''' フォームアクティブ処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ReceiptReprintForm_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated

        ' オペレータ情報の表示
        LblOperatorName.Text = GetOperatorInfomation()

    End Sub


    ''' <summary>
    ''' 受領証再発行検索画面ロード
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ReceiptReprintForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Dim intLastPage As Integer
        'Dim intDataNum As Integer

        Try
            ' 現在の年月日を取得する
            lblCurrentDate.Text = GetCurrentDate()

            ' ListViewのカラムヘッダー設定
            lstRePrintView.View = View.Details
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
            lstRePrintView.Columns.AddRange(colHeader)

            TxtBranch.Text = ""
            TxtYoteiTusu.Text = ""

            TxtBranch.ImeMode = ImeMode.Off
            TxtBranch.MaxLength = 10

            ' CSV出力対象ファイルの表示処理
            Call DispCsvOutFile()

        Catch ex As Exception
            MsgBox("【ReceiptReprintForm_Load】" & ex.Message)
        End Try

    End Sub


    ''' <summary>
    ''' 対象のログデータを隠しリストビューに表示する処理
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DispRePrintContentList()

        Try
            ' ListViewのカラムヘッダー設定
            lstGetDataView.View = View.Details
            Dim col1 As ColumnHeader = New ColumnHeader
            Dim col2 As ColumnHeader = New ColumnHeader
            Dim col3 As ColumnHeader = New ColumnHeader
            Dim col4 As ColumnHeader = New ColumnHeader
            Dim col5 As ColumnHeader = New ColumnHeader
            Dim col6 As ColumnHeader = New ColumnHeader
            Dim col7 As ColumnHeader = New ColumnHeader
            Dim col8 As ColumnHeader = New ColumnHeader
            Dim col9 As ColumnHeader = New ColumnHeader
            Dim col10 As ColumnHeader = New ColumnHeader
            Dim col11 As ColumnHeader = New ColumnHeader
            Dim col12 As ColumnHeader = New ColumnHeader
            Dim col13 As ColumnHeader = New ColumnHeader

            col1.Text = "No"
            col2.Text = "業務名称"
            col3.Text = "取得時間"
            col4.Text = "引受番号"
            col5.Text = "重量"
            col6.Text = "料金"
            col7.Text = "ファイル名称"
            col8.Text = "種別"
            col9.Text = "支店コード"
            col10.Text = "支店名"
            col11.Text = "処理予定通数"
            col12.Text = "定形／定形外"
            col13.Text = "抜取"

            col1.TextAlign = HorizontalAlignment.Center
            col2.TextAlign = HorizontalAlignment.Center
            col3.TextAlign = HorizontalAlignment.Center
            col4.TextAlign = HorizontalAlignment.Center
            col5.TextAlign = HorizontalAlignment.Center
            col6.TextAlign = HorizontalAlignment.Center
            col7.TextAlign = HorizontalAlignment.Left
            col8.TextAlign = HorizontalAlignment.Left
            col9.TextAlign = HorizontalAlignment.Left
            col10.TextAlign = HorizontalAlignment.Left
            col11.TextAlign = HorizontalAlignment.Left
            col12.TextAlign = HorizontalAlignment.Left
            col13.TextAlign = HorizontalAlignment.Center

            col1.Width = 120    ' No
            col2.Width = 250    ' 業務名称
            col3.Width = 230    ' 取得時間
            col4.Width = 200    ' 引受番号
            col5.Width = 100    ' 重量
            col6.Width = 100    ' 料金
            col7.Width = 900    ' ファイル名称
            col8.Width = 150    ' 種別
            col9.Width = 150    ' 支店コード
            col10.Width = 150   ' 支店名
            col11.Width = 150   ' 処理予定通数
            col12.Width = 150   ' 定形／定形外
            col13.Width = 100   ' 抜取

            Dim colHeader() As ColumnHeader = {col1, col2, col3, col4, col5, col6, col7, col8, col9, col10, col11, col12, col13}
            lstGetDataView.Columns.AddRange(colHeader)

            ' 検索画面（データ確認・抜き取り）データの表示処理
            Call DispContentsData()

        Catch ex As Exception
            MsgBox("【DispRePrintContentList】" & ex.Message)
        End Try
    End Sub


    ''' <summary>
    ''' 検索画面（データ確認・抜き取り）データの表示処理
    ''' 画像ファイルの復号化も行う
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DispContentsData()

        Dim col(12) As String       ' カラムデータ
        Dim itm As ListViewItem
        Dim blnIsRead As Boolean    ' 先頭行を読込済フラグ

        Try
            '    0                  1                  2              3    4    5                                                             6            7       8          9   0    1 2
            '00001,001：簡易書留郵便,2015/07/30 19:09:18,358-19-00001-1,3281,1490,C:\RECDEL\IMG\20150730\190900\image_20150730_190918_00001.jpg,30：簡易書留,0013-00,神保町支店,130,定形,
            '00002,001：簡易書留郵便,2015/07/30 19:09:20,358-19-00002-2,2994,1490,C:\RECDEL\IMG\20150730\190900\image_20150730_190920_00002.jpg,30：簡易書留,0013-00,神保町支店,130,定形,

            ' 読込ファイル名の設定
            Dim strReadDataFileName As String = PubConstClass.strJobDataFileName

            Dim strArray() As String = Nothing
            Dim strArraySub() As String = Nothing
            Dim strArrayUser() As String = Nothing
            Dim intArrayIndex As Integer = 0

            lstGetDataView.Items.Clear()
            blnIsRead = False
            Using sr As New System.IO.StreamReader(strReadDataFileName, System.Text.Encoding.Default)
                Do While Not sr.EndOfStream
                    strArray = sr.ReadLine.ToString.Split(","c)
                    For N = 0 To col.Length - 1
                        col(N) = strArray(N)
                    Next

                    If blnIsRead = False Then
                        blnIsRead = True
                        PubConstClass.pblSitenCode = col(8)
                        PubConstClass.pblSitenName = col(9)
                        PubConstClass.pblClassForSiten = col(7)
                        ' ユーザー情報の取得
                        strArrayUser = col(1).Split("："c)
                        If IsNumeric(strArrayUser(0)) = True Then
                            Call getUserInfomation(CInt(strArrayUser(0)))
                        End If
                    End If

                    If System.IO.File.Exists(strArray(6).Replace(".jpg", ".enc")) = True Then
                        ' 暗号化したファイルを復号化する
                        DecryptFile(strArray(6).Replace(".jpg", ".enc"), strArray(6), PubConstClass.DEF_OPEN_KEY)
                    Else
                        OutPutLogFile("■暗号化した画像ファイル（" & strArray(6).Replace(".jpg", ".enc") & "）ファイルが見つかりませんでした")
                    End If

                    itm = New ListViewItem(col)
                    lstGetDataView.Items.Add(itm)
                Loop
                ' 先頭行を選択
                lstGetDataView.Items(0).Selected = True
                lstGetDataView.Items(0).Focused = True
                lstGetDataView.Select()
                lstGetDataView.Items(0).EnsureVisible()

            End Using

        Catch ex As Exception
            MsgBox("【DispContentsData】" & ex.Message)
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
    ''' 「検索」ボタン処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSearch.Click

        Dim arSearch As New ArrayList
        Dim strData As String
        Dim strArray() As String

        Try
            If TxtBranch.Text = "" And TxtYoteiTusu.Text = "" Then
                'MsgBox("「支店コード」または「処理予定通数」を入力して下さい", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, MsgBoxStyle), "")
                Call DispCsvOutFile()
                Exit Sub
            End If

            arSearch.Clear()
            Call DispCsvOutFile()
            For N = 0 To lstRePrintView.Items.Count - 1

                strData = lstRePrintView.Items(N).SubItems(1).Text & "," & _
                          lstRePrintView.Items(N).SubItems(2).Text & "," & _
                          lstRePrintView.Items(N).SubItems(3).Text & "," & _
                          lstRePrintView.Items(N).SubItems(4).Text & "," & _
                          lstRePrintView.Items(N).SubItems(5).Text

                If TxtBranch.Text <> "" Then
                    ' 支店コードが検索条件になっている場合
                    If lstRePrintView.Items(N).SubItems(2).Text = TxtBranch.Text Then
                        If TxtYoteiTusu.Text <> "" Then
                            ' 処理予定通数が検索条件になっている場合
                            If lstRePrintView.Items(N).SubItems(3).Text = TxtYoteiTusu.Text Then
                                arSearch.Add(strData)
                            End If
                        Else
                            arSearch.Add(strData)
                        End If
                    End If

                ElseIf TxtYoteiTusu.Text <> "" Then
                    If lstRePrintView.Items(N).SubItems(3).Text = TxtYoteiTusu.Text Then
                        arSearch.Add(strData)
                    End If
                End If

            Next

            lstRePrintView.Items.Clear()
            If arSearch.Count = 0 Then
                ' 検索結果が無い場合
                Exit Sub
            End If

            Dim col(5) As String
            Dim itm As ListViewItem

            For N = 0 To arSearch.Count - 1
                strArray = arSearch.Item(N).ToString.Split(","c)

                col(0) = (N + 1).ToString("000")    ' No.
                col(1) = strArray(0)                ' 処理日
                col(2) = strArray(1)                ' 支店コード
                col(3) = strArray(2)                ' 処理数
                col(4) = strArray(3)                ' 種別
                col(5) = strArray(4)                ' 対象ファイル名

                itm = New ListViewItem(col)
                'itm.Checked = True
                lstRePrintView.Items.Add(itm)
                lstRePrintView.Items(lstRePrintView.Items.Count - 1).Selected = True
                lstRePrintView.Items(lstRePrintView.Items.Count - 1).Focused = True
                lstRePrintView.Select()
                lstRePrintView.Items(lstRePrintView.Items.Count - 1).EnsureVisible()

            Next


        Catch ex As Exception
            MsgBox("【BtnSearch_Click】" & ex.Message)
        End Try

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
            lstRePrintView.Items.Clear()
            If System.IO.Directory.Exists(strSearchDir) = False Then
                '// 2016.02.07 Ver.B06 hayakawa 修正↓ここから
                'MsgBox("集計対象フォルダが見つかりません", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")
                '// 2016.02.07 Ver.B06 hayakawa 修正↑ここまで
                Exit Sub
            End If
            If System.IO.Directory.GetFiles(strSearchDir, "*.LOG", System.IO.SearchOption.AllDirectories).Count < 1 Then
                '// 2016.02.07 Ver.B06 hayakawa 修正↓ここから
                'MsgBox("集計対象ファイルが見つかりません", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")
                '// 2016.02.07 Ver.B06 hayakawa 修正↑ここまで
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
                    itm.Checked = False
                    lstRePrintView.Items.Add(itm)
                    lstRePrintView.Items(0).Selected = True
                    lstRePrintView.Items(0).Focused = True
                    lstRePrintView.Select()
                    lstRePrintView.Items(0).EnsureVisible()

                    intNumber += 1

                End Using

            Next

        Catch ex As Exception
            MsgBox("【DispCsvOutFile】" & ex.Message)
        End Try

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

    Private Sub TxtBranch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBranch.KeyDown
        If e.KeyData = Keys.Enter Then
            ' 「検索」ボタンにフォーカスをセットする
            BtnSearch.Focus()
        End If
    End Sub

    Private Sub TxtBranch_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBranch.KeyPress
        ' 数字のみ入力可能
        e.Handled = CheckKeyPress("1", e)
    End Sub

    Private Sub TxtBranch_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtBranch.LostFocus
        Try
            If TxtBranch.Text <> "" Then
                TxtBranch.Text = CDbl(TxtBranch.Text).ToString("0")
            End If
        Catch ex As System.OverflowException
            MsgBox("支店コードが見つかりません")
        Catch ex As Exception
            MsgBox("【TxtBranch_LostFocus】" & ex.Message)
        End Try
    End Sub

    Private Sub TxtBranch_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtBranch.TextChanged

    End Sub

    Private Sub TxtYoteiTusu_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtYoteiTusu.KeyPress
        ' 数字のみ入力可能
        e.Handled = CheckKeyPress("1", e)
    End Sub

    Private Sub TxtYoteiTusu_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtYoteiTusu.TextChanged

    End Sub


    Private Sub TxtFromPage_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtFromPage.TextChanged
        '// TxtToPage_KeyPress 参照
    End Sub

    ''' <summary>
    ''' 頁（FROM)入力キー制限処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TxtFromPage_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFromPage.KeyPress
        ' 数字のみ入力可能
        e.Handled = CheckKeyPress("1", e)
    End Sub

    Private Sub TxtToPage_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtToPage.TextChanged
        '// TxtToPage_KeyPress 参照
    End Sub

    ''' <summary>
    ''' 頁（TO)入力キー制限処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TxtToPage_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtToPage.KeyPress
        ' 数字のみ入力可能
        e.Handled = CheckKeyPress("1", e)
    End Sub

    ''' <summary>
    ''' 「印刷」ボタン処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnPrint_Click(sender As System.Object, e As System.EventArgs) Handles BtnPrint.Click

        Dim retVal As MsgBoxResult

        Try
            If TxtFromPage.Text <> "" And TxtToPage.Text <> "" Then
                ' FROMとTOの大小チェック
                If CInt(TxtFromPage.Text) > CInt(TxtToPage.Text) Then
                    MsgBox("「ＦＲＯＭ≦ＴＯ」で入力して下さい", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")
                    Exit Sub
                End If
            End If

            If TxtFromPage.Text <> "" Then
                If CInt(TxtFromPage.Text) = 0 Then
                    MsgBox("「0」以外を入力して下さい", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")
                    Exit Sub
                End If
            End If

            If TxtToPage.Text <> "" Then
                If CInt(TxtToPage.Text) = 0 Then
                    MsgBox("「0」以外を入力して下さい", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")
                    Exit Sub
                End If
            End If

            If TxtFromPage.Text <> "" And TxtToPage.Text = "" Then
                MsgBox("「ＴＯ」を入力して下さい", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")
                Exit Sub
            End If
            If TxtFromPage.Text = "" And TxtToPage.Text <> "" Then
                MsgBox("「ＦＲＯＭ」を入力して下さい", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")
                Exit Sub
            End If

            If RdoSasidasi.Checked = True Then
                retVal = MsgBox("差出票の内容を確認しますか？", CType(MsgBoxStyle.Question + MsgBoxStyle.OkCancel, MsgBoxStyle), "確認")
            Else
                retVal = MsgBox("受領証の内容を確認しますか？", CType(MsgBoxStyle.Question + MsgBoxStyle.OkCancel, MsgBoxStyle), "確認")
            End If
            If retVal = MsgBoxResult.Cancel Then
                ' キャンセル
                Exit Sub
            End If

            ' 編集するJOBデータファイル名称の設定
            PubConstClass.strJobDataFileName = lstRePrintView.SelectedItems(0).SubItems(5).Text

            ' 対象のログデータを隠しリストビューに表示
            Call DispRePrintContentList()

            ' 再印字用のデータを印字用アレイリストに格納
            Call RePrintData()

            ' 画像ファイル（JPG）の削除処理
            Call DeleteJPGFile(PubConstClass.strJobDataFileName)

        Catch ex As Exception
            MsgBox("【BtnPrint_Click】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 再印字用のデータを印字用アレイリストに格納
    ''' ① ページ指定の最大値チェック
    ''' ②「15面／頁」「8面／頁」の判断
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RePrintData()

        Dim strPutMessage As String
        Dim retVal As MsgBoxResult

        Try
            '    0                  1                  2              3    4    5                                                             6            7       8          9   0    1 2
            '00001,001：簡易書留郵便,2015/07/30 19:09:18,358-19-00001-1,3281,1490,C:\RECDEL\IMG\20150730\190900\image_20150730_190918_00001.jpg,30：簡易書留,0013-00,神保町支店,130,定形,■
            '00002,001：簡易書留郵便,2015/07/30 19:09:20,358-19-00002-2,2994,1490,C:\RECDEL\IMG\20150730\190900\image_20150730_190920_00002.jpg,30：簡易書留,0013-00,神保町支店,130,定形,

            PubConstClass.arListForPrint = New ArrayList
            PubConstClass.arListForPrint.Clear()

            For N = 0 To lstGetDataView.Items.Count - 1
                ' 書込データの設定
                strPutMessage = lstGetDataView.Items(N).SubItems(0).Text & "," & _
                                             lstGetDataView.Items(N).SubItems(1).Text & "," & _
                                             lstGetDataView.Items(N).SubItems(2).Text & "," & _
                                             lstGetDataView.Items(N).SubItems(3).Text & "," & _
                                             lstGetDataView.Items(N).SubItems(4).Text & "," & _
                                             lstGetDataView.Items(N).SubItems(5).Text & "," & _
                                             lstGetDataView.Items(N).SubItems(6).Text & "," & _
                                             lstGetDataView.Items(N).SubItems(7).Text & "," & _
                                             lstGetDataView.Items(N).SubItems(8).Text & "," & _
                                             lstGetDataView.Items(N).SubItems(9).Text & "," & _
                                             lstGetDataView.Items(N).SubItems(10).Text & "," & _
                                             lstGetDataView.Items(N).SubItems(11).Text & ","

                If lstGetDataView.Items(N).Checked = True Or lstGetDataView.Items(N).SubItems(12).Text = "■" Then
                    strPutMessage = strPutMessage & "■"
                End If
                ' 印刷用アレイリストへの格納
                PubConstClass.arListForPrint.Add(strPutMessage)
            Next

            Dim intLastPage As Integer
            Dim intModNum As Integer
            Dim intCntForPage As Integer
            Dim intImageDataCountBack As Integer
            Dim intPrintImageIndexBack As Integer

            PubConstClass.intPrintFuncNo = 1
            PubConstClass.intReceiptKind = 0
            If Rdo15FacePerPage.Checked = True Then
                intCntForPage = 15      ' 15面／頁
                PubConstClass.pblPrintCountPerPage = "0"                
            Else
                intCntForPage = 8       ' 8面／頁
                PubConstClass.pblPrintCountPerPage = "1"
            End If

            PubConstClass.lngPrintIndex = CLng(Math.Truncate((lstGetDataView.Items.Count - 1) / intCntForPage)) + 1
            ' 頁（FROM～TO）指定の設定
            If TxtFromPage.Text <> "" And TxtToPage.Text <> "" Then
                ' 最終印字頁を算出する
                intLastPage = CInt(Math.Truncate(lstGetDataView.Items.Count / intCntForPage)) + 1
                intModNum = CInt(lstGetDataView.Items.Count Mod intCntForPage)
                If intModNum = 0 Then
                    ' 余りが「0」の場合は最終印字頁を（－１）し、余りを頁の最大数とする
                    intLastPage = intLastPage - 1
                    intModNum = intCntForPage
                End If

                If intLastPage < CInt(TxtFromPage.Text) Then
                    MsgBox("「最終頁（" & intLastPage.ToString("0") & "）＜ＦＲＯＭ」となっています")
                    Exit Sub
                End If
                If intLastPage < CInt(TxtToPage.Text) Then
                    MsgBox("「最終頁（" & intLastPage.ToString("0") & "）＜ＴＯ」となっています")
                    Exit Sub
                End If

                If CInt(TxtToPage.Text) = intLastPage Then
                    ' 最終頁＝ＴＯ
                    If TxtFromPage.Text = TxtToPage.Text Then
                        ' ＦＲＯＭ＝ＴＯ
                        intImageDataCount = intModNum
                        intImageDataCountBack = intImageDataCount
                    Else
                        ' ＦＲＯＭ <> ＴＯ
                        intImageDataCount = (CInt(TxtToPage.Text) - CInt(TxtFromPage.Text)) * intCntForPage + intModNum
                        intImageDataCountBack = intImageDataCount
                    End If
                Else
                    ' 最終頁 <> ＴＯ
                    If TxtFromPage.Text = TxtToPage.Text Then
                        ' ＦＲＯＭ＝ＴＯ
                        intImageDataCount = intCntForPage
                        intImageDataCountBack = intImageDataCount
                    Else
                        ' ＦＲＯＭ <> ＴＯ
                        intImageDataCount = (CInt(TxtToPage.Text) - CInt(TxtFromPage.Text) + 1) * intCntForPage
                        intImageDataCountBack = intImageDataCount
                    End If
                End If

                intPrintImageIndex = CInt(TxtFromPage.Text) - 1
                intPrintImageIndexBack = intPrintImageIndex
            Else
                ' 頁指定が無い場合は全頁印刷
                ' 印字する画像データの個数を取得
                intImageDataCount = lstGetDataView.Items.Count
                intImageDataCountBack = intImageDataCount
                ' 印字ページインデックスの初期化
                intPrintImageIndex = 0
                intPrintImageIndexBack = intPrintImageIndex
            End If

            ' PrintDocumentオブジェクトの作成
            Dim pd As New System.Drawing.Printing.PrintDocument
            ' PrintPageイベントハンドラの追加
            AddHandler pd.PrintPage, AddressOf MainForm.PrintDocument1_PrintPage

            If RdoSasidasi.Checked = True Or RdoBoth.Checked = True Then
                ' プレビューのヘッダーを制御
                PubConstClass.intReceiptKind = 0
            Else
                PubConstClass.intReceiptKind = 1
            End If

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

            ' 印刷選択のチェック
            If RdoSasidasi.Checked = True Or RdoBoth.Checked = True Then
                ' 差出票の印刷
                retVal = MsgBox(PubConstClass.pblHeder1Page & "を印刷しますか？", CType(MsgBoxStyle.Question + MsgBoxStyle.OkCancel, MsgBoxStyle), "確認")
                If retVal = MsgBoxResult.Cancel Then
                    ' キャンセル
                    Exit Sub
                End If

                PubConstClass.intReceiptKind = 0
                ' 印字する画像データの個数を取得
                intImageDataCount = intImageDataCountBack
                ' 印字ページインデックスの初期化
                intPrintImageIndex = intPrintImageIndexBack
                pd.DocumentName = PubConstClass.pblHeder1Page & "の印刷"
                ' 印刷処理
                pd.Print()
            End If

            ' 印刷選択のチェック
            If RdoZyuryo.Checked = True Or RdoBoth.Checked = True Then
                ' 受領証の印刷
                retVal = MsgBox(PubConstClass.pblHeder2Page & "を印刷しますか？", CType(MsgBoxStyle.Question + MsgBoxStyle.OkCancel, MsgBoxStyle), "確認")
                If retVal = MsgBoxResult.Cancel Then
                    ' キャンセル
                    Exit Sub
                End If

                PubConstClass.intReceiptKind = 1
                ' 印字する画像データの個数を取得
                intImageDataCount = intImageDataCountBack
                ' 印字ページインデックスの初期化
                intPrintImageIndex = intPrintImageIndexBack
                pd.DocumentName = PubConstClass.pblHeder2Page & "の印刷"
                ' 印刷処理
                pd.Print()
            End If

            ' PrintDocumentオブジェクトの解放
            pd.Dispose()

        Catch ex As Exception
            MsgBox("【RePrintData】" & ex.Message)
        End Try

    End Sub


    ''' <summary>
    ''' 画像ファイル（jpg）の削除処理
    ''' </summary>
    ''' <param name="strJobDataFileName">編集対象ジョブファイル名</param>
    ''' <remarks></remarks>
    Private Sub DeleteJPGFile(ByVal strJobDataFileName As String)

        Try
            Dim strSaveImageFolder As String = ""

            'Dim strArray() As String = PubConstClass.strJobDataFileName.Split("\"c)
            Dim strArray() As String = strJobDataFileName.Split("\"c)
            ' 
            Dim strSubArray() As String = strArray(strArray.Length - 1).Split("_"c)

            ' ファイル名を除くフォルダ名を再結合
            For N = 0 To strArray.Length - 2
                strSaveImageFolder = strSaveImageFolder & strArray(N) & "\"
            Next
            strSaveImageFolder = strSaveImageFolder & strSubArray(2).Replace(".LOG", "")
            ' JPG ファイルの削除
            For Each FileName As String In System.IO.Directory.GetFiles(strSaveImageFolder, "*.jpg")
                System.IO.File.Delete(FileName)
            Next

        Catch ex As Exception
            MsgBox("【DeleteJPGFile】" & ex.Message)
        End Try

    End Sub

End Class