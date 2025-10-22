Option Explicit On
Option Strict On

Public Class DataCheckForm

    ''' <summary>
    ''' フォームアクティブ処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub DataCheckForm_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated

        ' オペレータ情報の表示
        LblOperatorName.Text = GetOperatorInfomation()

    End Sub


    ''' <summary>
    ''' フォームロード処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub DataCheckForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Try
            ' 現在の年月日を取得する
            lblCurrentDate.Text = GetCurrentDate()

            LblMessage.Text = ""
            TxtBranch.Text = ""
            TxtYoteiTusu.Text = ""

            TxtBranch.ImeMode = ImeMode.Off
            TxtBranch.MaxLength = 10

            ' リストビューのヘッダー表示
            Call DisplayHeader()

            ' 「画面表示ボタン無効化」
            BtnDisplay.Enabled = False

            ' CSV出力対象ファイルの表示処理
            Call DispCsvOutFile()

        Catch ex As Exception
            MsgBox("【DataCheckForm_Load】" & ex.Message)
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
    Private Sub BtnBack_Click(sender As System.Object, e As System.EventArgs) Handles BtnBack.Click

        Me.Dispose()

    End Sub

    ''' <summary>
    ''' 「検索」ボタン処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnSearch_Click(sender As System.Object, e As System.EventArgs) Handles BtnSearch.Click

        Dim arSearch As New ArrayList
        Dim strData As String
        Dim strArray() As String

        Try
            If TxtBranch.Text = "" And TxtYoteiTusu.Text = "" Then
                'MsgBox("「支店コード」または「処理予定通数」を入力して下さい", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, MsgBoxStyle), "")
                Call DispCsvOutFile()
                Exit Sub
            End If

            Call DispCsvOutFile()
            arSearch.Clear()

            For N = 0 To lstGetDataView.Items.Count - 1

                strData = lstGetDataView.Items(N).SubItems(1).Text & "," & _
                          lstGetDataView.Items(N).SubItems(2).Text & "," & _
                          lstGetDataView.Items(N).SubItems(3).Text & "," & _
                          lstGetDataView.Items(N).SubItems(4).Text & "," & _
                          lstGetDataView.Items(N).SubItems(5).Text

                If TxtBranch.Text <> "" Then
                    ' 支店コードが検索条件になっている場合
                    If lstGetDataView.Items(N).SubItems(2).Text = TxtBranch.Text Then
                        If TxtYoteiTusu.Text <> "" Then
                            ' 処理予定通数が検索条件になっている場合
                            If lstGetDataView.Items(N).SubItems(3).Text = TxtYoteiTusu.Text Then
                                arSearch.Add(strData)
                            End If
                        Else
                            arSearch.Add(strData)
                        End If
                    End If

                ElseIf TxtYoteiTusu.Text <> "" Then
                    If lstGetDataView.Items(N).SubItems(3).Text = TxtYoteiTusu.Text Then
                        arSearch.Add(strData)
                    End If
                End If

            Next

            lstGetDataView.Items.Clear()
            If arSearch.Count = 0 Then
                ' 検索結果が無い場合

                ' 「画面表示」ボタン無効化
                BtnDisplay.Enabled = False

                Exit Sub
            End If

            ' 「画面表示」ボタン有効化
            BtnDisplay.Enabled = True

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
                itm.Checked = False
                lstGetDataView.Items.Add(itm)
                lstGetDataView.Items(0).Selected = True
                lstGetDataView.Items(0).Focused = True
                lstGetDataView.Select()
                lstGetDataView.Items(0).EnsureVisible()

            Next

        Catch ex As Exception
            MsgBox("【BtnSearch_Click】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 「画面表示」ボタン処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnDisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDisplay.Click

        Dim retVal As MsgBoxResult
        retVal = MsgBox("データ確認・抜き取りの画面を表示しますか？", CType(MsgBoxStyle.Question + MsgBoxStyle.OkCancel, MsgBoxStyle), "確認")
        If retVal = MsgBoxResult.Cancel Then
            ' キャンセル
            Exit Sub
        End If

        PubConstClass.strJobDataFileName = lstGetDataView.SelectedItems(0).SubItems(5).Text

        LblMessage.Text = "表示処理中です。"
        LblMessage.Refresh()

        SearchResultForm.ShowDialog()
        LblMessage.Text = ""

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
                ' 「画面表示」ボタン無効化
                BtnDisplay.Enabled = False
                '// 2016.02.05 Ver.B06 hayakawa 修正↓ここから
                'MsgBox("集計対象フォルダが見つかりません", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")
                '// 2016.02.05 Ver.B06 hayakawa 修正↑ここまで
                Exit Sub
            End If
            If System.IO.Directory.GetFiles(strSearchDir, "*.LOG", System.IO.SearchOption.AllDirectories).Count < 1 Then
                ' 「画面表示」ボタン無効化
                BtnDisplay.Enabled = False
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

            ' 「画面表示」ボタン有効化
            BtnDisplay.Enabled = True

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
                    lstGetDataView.Items.Add(itm)
                    lstGetDataView.Items(0).Selected = True
                    lstGetDataView.Items(0).Focused = True
                    lstGetDataView.Select()
                    lstGetDataView.Items(0).EnsureVisible()

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

    Private Sub TxtBranch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBranch.TextChanged

    End Sub

    Private Sub TxtYoteiTusu_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtYoteiTusu.KeyPress
        ' 数字のみ入力可能
        e.Handled = CheckKeyPress("1", e)
    End Sub

    Private Sub TxtYoteiTusu_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtYoteiTusu.TextChanged

    End Sub

End Class