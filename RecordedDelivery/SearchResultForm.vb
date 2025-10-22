Option Explicit On
Option Strict On

Public Class SearchResultForm

    ''' <summary>
    ''' フォームアクティブ処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub SearchRusultForm_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated

        Try
            ' オペレータ情報の表示
            LblOperatorName.Text = GetOperatorInfomation()

        Catch ex As Exception
            MsgBox("【SearchRusultForm_Activated】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' フォームロード処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub SearchResultForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            DateTimeTimer.Interval = 1000
            DateTimeTimer.Enabled = True

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

            ' 保存ログファイル
            Dim strArray() As String = PubConstClass.strJobDataFileName.Split("\"c)
            lblSaveLogFileName.Text = strArray(strArray.Length - 1)

            lblAcceptNum1.Text = ""
            lblAcceptNum2.Text = ""
            lblAcceptNum3.Text = ""
            lblAcceptNum4.Text = ""
            LblCreateDate.Text = ""

        Catch ex As Exception
            MsgBox("【SearchResultForm_Load】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub DateTimeTimer_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DateTimeTimer.Tick

        ' 指定した書式で日付を文字列に変換する
        lblYear.Text = Date.Now.ToString("yyyy/MM/dd")
        lblCurrentTime.Text = Date.Now.ToString("HH:mm:ss")

    End Sub

    ''' <summary>
    ''' 「終了」ボタン処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnEnd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEnd.Click

        DeleteJPGFile()
        Me.Dispose()
        DataCheckForm.Dispose()

    End Sub


    ''' <summary>
    ''' 検索画面（データ確認・抜き取り）データの表示処理
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
            Dim intArrayIndex As Integer = 0

            lstGetDataView.Items.Clear()
            blnIsRead = False
            Using sr As New System.IO.StreamReader(strReadDataFileName, System.Text.Encoding.Default)
                Do While Not sr.EndOfStream
                    strArray = sr.ReadLine.ToString.Split(","c)
                    For N = 0 To col.Length - 1
                        col(N) = strArray(N)
                    Next
                    If System.IO.File.Exists(strArray(6).Replace(".jpg", ".enc")) = True Then
                        ' 暗号化したファイルを復号化する
                        DecryptFile(strArray(6).Replace(".jpg", ".enc"), strArray(6), PubConstClass.DEF_OPEN_KEY)
                    Else
                        OutPutLogFile("■暗号化した画像ファイル（" & strArray(6).Replace(".jpg", ".enc") & "）ファイルが見つかりませんでした")
                    End If

                    If blnIsRead = False Then
                        blnIsRead = True
                        ' 支店コード
                        PubConstClass.pblSitenCode = strArray(8)                        
                        LblSitenCd.Text = strArray(8)

                        ' 支店名
                        PubConstClass.pblSitenName = strArray(9)
                        LblSitenName.Text = strArray(9)
                        PubConstClass.pblClassForSiten = strArray(7)
                        ' 処理日
                        strArraySub = strArray(2).Split(" "c)
                        LblTranDate.Text = strArraySub(0)
                        ' 業務名称
                        LblJobName.Text = strArray(1)
                        ' 種別
                        LblClass.Text = strArray(7)

                        ' ユーザー情報の取得
                        '// 2016.1.12 Ver.B05 hayakawa 変更↓ここから
                        Dim strUserNo() As String = strArray(1).Split("："c)
                        'Call getUserInfomation(CInt(PubConstClass.userNumber))
                        Call getUserInfomation(CInt(strUserNo(0)))
                        '// 2016.1.12 Ver.B05 hayakawa 変更↑ここまで

                        ' コメント
                        LblComment.Text = PubConstClass.strPubComment
                        ' 差出人氏名
                        LblName.Text = PubConstClass.strPubName
                        ' 差出人住所１
                        LblAddress1.Text = PubConstClass.strPubAddress1
                        ' 差出人住所２
                        LblAddress2.Text = PubConstClass.strPubAddress2
                        ' 承認局名
                        LblPostName.Text = PubConstClass.strPubPostName

                    End If

                    itm = New ListViewItem(col)
                    lstGetDataView.Items.Add(itm)
                    If strArray(12) = "■" Then
                        lstGetDataView.Items(lstGetDataView.Items.Count - 1).Checked = True
                        lstGetDataView.Items(lstGetDataView.Items.Count - 1).BackColor = Color.LightPink
                    End If
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
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub lstGetDataView_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lstGetDataView.SelectedIndexChanged
        '// lstGetDataView_Click 参照
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub lstGetDataView_Click(sender As Object, e As System.EventArgs) Handles lstGetDataView.Click

        Dim strArray() As String

        Try
            ' 取得時間
            LblCreateDate.Text = lstGetDataView.SelectedItems(0).SubItems(2).Text

            ' 引受番号
            strArray = lstGetDataView.SelectedItems(0).SubItems(3).Text.Split("-"c)
            lblAcceptNum1.Text = strArray(0)
            lblAcceptNum2.Text = strArray(1)
            lblAcceptNum3.Text = strArray(2)
            lblAcceptNum4.Text = strArray(3)

            'If System.IO.File.Exists(lstGetDataView.SelectedItems(0).SubItems(6).Text.Replace(".jpg", ".enc")) = True Then
            '    ' 暗号化したファイルを復号化する
            '    DecryptFile(lstGetDataView.SelectedItems(0).SubItems(6).Text.Replace(".jpg", ".enc"), _
            '                lstGetDataView.SelectedItems(0).SubItems(6).Text, _
            '                PubConstClass.DEF_OPEN_KEY)
            '    ' 画像
            '    PictureBox1.ImageLocation = lstGetDataView.SelectedItems(0).SubItems(6).Text
            'Else
            '    ' 画像
            '    PictureBox1.ImageLocation = IncludeTrailingPathDelimiter(Application.StartupPath) & "noimage.jpg"
            'End If

            ' 画像
            PictureBox1.ImageLocation = lstGetDataView.SelectedItems(0).SubItems(6).Text

        Catch ex As Exception
            MsgBox("【lstGetDataView_Click】" & ex.Message)
        End Try

    End Sub


    ''' <summary>
    ''' 「戻る」ボタン処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnBack_Click(sender As System.Object, e As System.EventArgs) Handles BtnBack.Click

        DeleteJPGFile()
        Me.Dispose()
        'DataCheckForm.Show()

    End Sub

    ''' <summary>
    ''' 画像ファイル（jpg）の削除処理
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DeleteJPGFile()

        Try
            Dim strSaveImageFolder As String = ""

            Dim strArray() As String = PubConstClass.strJobDataFileName.Split("\"c)
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


    ''' <summary>
    ''' 「受領証再作成」ボタン処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnRePrint_Click(sender As System.Object, e As System.EventArgs) Handles BtnRePrint.Click

        Dim strPutMessage As String

        Try
            Dim margin1 As Integer = 0
            Dim margin2 As Integer = 0

            Dim retVal As MsgBoxResult
            retVal = MsgBox("受領証の内容を確認しますか？", CType(MsgBoxStyle.Question + MsgBoxStyle.OkCancel, MsgBoxStyle), "確認")
            If retVal = MsgBoxResult.Cancel Then
                ' キャンセル
                Exit Sub
            End If

            ' 書込ファイル名の設定
            Dim strOutPutFileName As String = PubConstClass.strJobDataFileName
            ' 書込ファイルの削除
            System.IO.File.Delete(strOutPutFileName)
            ' 追記モードで書き込む
            Using sw As New System.IO.StreamWriter(strOutPutFileName, True, System.Text.Encoding.Default)

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
                    'If lstGetDataView.Items(N).Checked = True Or lstGetDataView.Items(N).SubItems(12).Text = "■" Then
                    If lstGetDataView.Items(N).Checked = True Then
                        strPutMessage = strPutMessage & "■"
                    End If
                    ' 稼働ログファイルへの書き込み
                    sw.WriteLine(strPutMessage)
                    ' 印刷用アレイリストへの格納
                    PubConstClass.arListForPrint.Add(strPutMessage)
                Next
            End Using

            PubConstClass.intPrintFuncNo = 1
            PubConstClass.intReceiptKind = 0
            If Rdo15FacePerPage.Checked = True Then
                PubConstClass.pblPrintCountPerPage = "0"
                PubConstClass.lngPrintIndex = CLng(Math.Truncate((lstGetDataView.Items.Count - 1) / 15)) + 1
            Else
                PubConstClass.pblPrintCountPerPage = "1"
                PubConstClass.lngPrintIndex = CLng(Math.Truncate((lstGetDataView.Items.Count - 1) / 8)) + 1
            End If

            ' 印字する画像データの個数を取得
            intImageDataCount = lstGetDataView.Items.Count
            ' 印字ページインデックスの初期化
            intPrintImageIndex = 0

            ' PrintDocumentオブジェクトの作成
            Dim pd As New System.Drawing.Printing.PrintDocument
            ' PrintPageイベントハンドラの追加
            '// 2016.01.13 Ver.B05 hayakawa 修正↓ここから
            'AddHandler pd.PrintPage, AddressOf MainForm.PrintDocument1_PrintPage
            AddHandler pd.PrintPage, AddressOf PrintDocument1_PrintPage
            '// 2016.01.13 Ver.B05 hayakawa 修正↑ここまで

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

            ' 検索画面（データ確認・抜き取り）データの表示処理
            Call DispContentsData()

            retVal = MsgBox(PubConstClass.pblHeder1Page & "を印刷しますか？", CType(MsgBoxStyle.Question + MsgBoxStyle.OkCancel, MsgBoxStyle), "確認")
            If retVal = MsgBoxResult.Cancel Then
                ' キャンセル
                Exit Sub
            End If

            PubConstClass.intReceiptKind = 0
            ' 印字する画像データの個数を取得
            intImageDataCount = lstGetDataView.Items.Count
            ' 印字ページインデックスの初期化
            intPrintImageIndex = 0
            pd.DocumentName = PubConstClass.pblHeder1Page & "の印刷"
            ' 印刷処理
            pd.Print()

            retVal = MsgBox(PubConstClass.pblHeder2Page & "を印刷しますか？", CType(MsgBoxStyle.Question + MsgBoxStyle.OkCancel, MsgBoxStyle), "確認")
            If retVal = MsgBoxResult.Cancel Then
                ' キャンセル
                Exit Sub
            End If

            PubConstClass.intReceiptKind = 1
            ' 印字する画像データの個数を取得
            intImageDataCount = lstGetDataView.Items.Count
            ' 印字ページインデックスの初期化
            intPrintImageIndex = 0
            pd.DocumentName = PubConstClass.pblHeder2Page & "の印刷"
            ' 印刷処理
            pd.Print()

            ' PrintDocumentオブジェクトの解放
            pd.Dispose()

        Catch ex As Exception
            MsgBox("【BtnRePrint_Click】" & ex.Message)
        End Try

    End Sub


    '// 2016.01.13 Ver.B05 hayakawa 追加↓ここから
    Private Sub PrintDocument1_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage

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
                Case Else

            End Select

        Catch ex As Exception
            MsgBox("【SearchResultForm.PrintDocument1_PrintPage】" & ex.Message)
        End Try

    End Sub
    '// 2016.01.13 Ver.B05 hayakawa 追加↑ここまで

End Class