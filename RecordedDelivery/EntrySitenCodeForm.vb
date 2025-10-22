Option Explicit On
Option Strict On

Public Class EntrySitenCodeForm

    ''' <summary>
    ''' フォームアクティブ処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub EntrySitenCodeForm_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated

        ' オペレータ情報の表示
        LblOperatorName.Text = GetOperatorInfomation()

    End Sub


    ''' <summary>
    ''' フォームロード処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub EntrySitenCodeForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try

            ' 現在の年月日を取得する
            lblCurrentDate.Text = GetCurrentDate()
            ' メッセージ情報クリア
            LblMessage.Text = ""
            TxtBranchCd.Text = ""

            LsvDataView.Clear()
            ' ListViewのカラムヘッダー設定
            LsvDataView.View = View.Details
            Dim col1 As ColumnHeader = New ColumnHeader
            Dim col2 As ColumnHeader = New ColumnHeader
            Dim col3 As ColumnHeader = New ColumnHeader

            col1.Text = "　No"
            col2.Text = "支店コード"
            col3.Text = "支店名"

            col1.TextAlign = HorizontalAlignment.Center
            col2.TextAlign = HorizontalAlignment.Center
            col3.TextAlign = HorizontalAlignment.Left

            col1.Width = 80     ' No
            col2.Width = 150    ' 支店コード
            col3.Width = 250    ' 支店名

            Dim colHeader() As ColumnHeader = {col1, col2, col3}
            LsvDataView.Columns.AddRange(colHeader)

            TxtBranchCd.ImeMode = ImeMode.Off
            TxtBranchCd.MaxLength = 10

            ' 支店データの表示
            Call DispSitenData()

        Catch ex As Exception
            MsgBox("【EntrySitenCodeForm_Load】" & ex.Message)
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

        'Dim strArray() As String
        'Dim intLoopCnt As Integer
        'Dim blnIsFind As Boolean

        'Try
        '    blnIsFind = False
        '    For intLoopCnt = 0 To PubConstClass.pblBranchIndex - 1
        '        strArray = PubConstClass.pblBranchArray(intLoopCnt).Split(","c)

        '        If CInt(strArray(0)) = CInt(TxtBranchCd.Text) Then
        '            blnIsFind = True
        '            LblMessage.Text = ""
        '            TxtBranchName.Text = strArray(1)
        '            Exit For
        '        End If
        '    Next
        '    If blnIsFind = False Then
        '        TxtBranchName.Text = ""
        '        LblMessage.Text = "支店コードが見つかりません"
        '    End If

        'Catch ex As Exception
        '    MsgBox("【BtnSearch_Click】" & ex.Message)
        'End Try

    End Sub


    ''' <summary>
    ''' 「新規」ボタン処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click

        Dim col(3) As String
        Dim itm As ListViewItem
        Dim varRetVal As MsgBoxResult

        Try
            If TxtBranchCd.Text = "" Then
                MsgBox("支店コードを入力して下さい", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")
                Exit Sub
            End If
            If TxtBranchName.Text = "" Then
                MsgBox("支店名を入力して下さい", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")
                Exit Sub
            End If

            ' 支店コードの重複チェック
            For N = 0 To LsvDataView.Items.Count - 1
                If CDbl(TxtBranchCd.Text) = CDbl(LsvDataView.Items(N).SubItems(1).Text) Then
                    MsgBox("支店コード（" & TxtBranchCd.Text & "）が重複しています", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")
                    Exit Sub
                End If
            Next

            Dim strMessage As String = "【" & TxtBranchCd.Text & "：" & TxtBranchName.Text & "】を新規登録しますか？"
            varRetVal = MsgBox(strMessage, CType(MsgBoxStyle.Question + MsgBoxStyle.OkCancel, MsgBoxStyle), "確認")
            If varRetVal = MsgBoxResult.Cancel Then
                ' 「キャンセル」ボタン
                Exit Sub
            End If

            col(0) = (LsvDataView.Items.Count + 1).ToString("000")
            col(1) = CInt(TxtBranchCd.Text).ToString("0")
            col(2) = TxtBranchName.Text
            itm = New ListViewItem(col)
            LsvDataView.Items.Add(itm)
            LsvDataView.Items(LsvDataView.Items.Count - 1).Selected = True
            LsvDataView.Items(LsvDataView.Items.Count - 1).Focused = True
            LsvDataView.Select()
            LsvDataView.Items(LsvDataView.Items.Count - 1).EnsureVisible()

            ' 支店データの登録
            Call SaveSitenData()

            ' 支店データの表示
            Call DispSitenData()

            ' 支店マスター読込処理
            Call GetBranchMasterFile()

        Catch ex As Exception
            MsgBox("【BtnNew_Click】" & ex.Message)
        End Try

    End Sub


    ''' <summary>
    ''' 「更新」ボタン処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUpdate.Click

        Dim varRetVal As MsgBoxResult

        Try
            If TxtBranchCd.Text = "" Then
                MsgBox("支店コードを入力して下さい", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")
                Exit Sub
            End If
            If TxtBranchName.Text = "" Then
                MsgBox("支店名を入力して下さい", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")
                Exit Sub
            End If
            If LsvDataView.SelectedItems.Count = 0 Then
                MsgBox("更新するデータを選択してください", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")
                Exit Sub
            End If
            If LsvDataView.Items(LsvDataView.SelectedItems(0).Index).SubItems(1).Text() & _
                LsvDataView.Items(LsvDataView.SelectedItems(0).Index).SubItems(2).Text() = _
                TxtBranchCd.Text & TxtBranchName.Text Then
                MsgBox("変更前の値と変更後の値が同じです", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")
                Exit Sub
            End If

            Dim strMessage As String = "【"
            strMessage &= LsvDataView.Items(LsvDataView.SelectedItems(0).Index).SubItems(1).Text() & "："
            strMessage &= LsvDataView.Items(LsvDataView.SelectedItems(0).Index).SubItems(2).Text()
            strMessage &= "】を"
            strMessage &= "【" & TxtBranchCd.Text & "：" & TxtBranchName.Text & "】に更新しますか？"
            varRetVal = MsgBox(strMessage, CType(MsgBoxStyle.Question + MsgBoxStyle.OkCancel, MsgBoxStyle), "確認")
            If varRetVal = MsgBoxResult.Cancel Then
                ' 「キャンセル」ボタン
                Exit Sub
            End If

            ' 支店コードの更新
            LsvDataView.Items(LsvDataView.SelectedItems(0).Index).SubItems(1).Text() = TxtBranchCd.Text
            ' 支店名の更新
            LsvDataView.Items(LsvDataView.SelectedItems(0).Index).SubItems(2).Text() = TxtBranchName.Text

            ' 支店データの登録
            Call SaveSitenData()

            ' 支店マスター読込処理
            Call GetBranchMasterFile()

        Catch ex As Exception
            MsgBox("【BtnUpdate_Click】" & ex.Message)
        End Try

    End Sub


    ''' <summary>
    ''' 「削除」ボタン
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click

        Dim varRetVal As MsgBoxResult

        Try
            If TxtBranchCd.Text = "" Then
                MsgBox("支店コードを入力して下さい", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")
                Exit Sub
            End If
            If TxtBranchName.Text = "" Then
                MsgBox("支店名を入力して下さい", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")
                Exit Sub
            End If
            If LsvDataView.SelectedItems.Count = 0 Then
                MsgBox("削除するデータを選択してください", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")
                Exit Sub
            End If
            Dim strMessage As String = "【"
            strMessage &= LsvDataView.Items(LsvDataView.SelectedItems(0).Index).SubItems(1).Text() & "："
            strMessage &= LsvDataView.Items(LsvDataView.SelectedItems(0).Index).SubItems(2).Text()
            strMessage &= "】を削除しますか？"
            varRetVal = MsgBox(strMessage, CType(MsgBoxStyle.Question + MsgBoxStyle.OkCancel, MsgBoxStyle), "確認")
            If varRetVal = MsgBoxResult.Cancel Then
                ' 「キャンセル」ボタン
                Exit Sub
            End If

            LsvDataView.Items.RemoveAt(LsvDataView.SelectedItems(0).Index)

            ' 支店データの登録
            Call SaveSitenData()

            ' 支店データの表示
            Call DispSitenData()

            ' 支店マスター読込処理
            Call GetBranchMasterFile()

        Catch ex As Exception
            MsgBox("【BtnDelete_Click】" & ex.Message)
        End Try

    End Sub


    ''' <summary>
    ''' 支店データの登録
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SaveSitenData()

        Try
            ' 支店コードでソート
            Dim arSortArray As New ArrayList
            arSortArray.Clear()

            For N = 0 To LsvDataView.Items.Count - 1
                arSortArray.Add(CDbl(LsvDataView.Items(N).SubItems(1).Text).ToString("0000000000") & "," & LsvDataView.Items(N).SubItems(2).Text)
            Next

            arSortArray.Sort()

            ' 書込ファイル名の設定
            Dim strReadDataFileName As String = IncludeTrailingPathDelimiter(Application.StartupPath) & PubConstClass.DEF_BRANCH_MASTER

            System.IO.File.Delete(strReadDataFileName)
            Dim strArray() As String
            ' 追記モードで書き込む
            Using sw As New System.IO.StreamWriter(strReadDataFileName, True, System.Text.Encoding.Default)
                For N = 0 To LsvDataView.Items.Count - 1
                    ' 書込データの設定
                    strArray = arSortArray(N).ToString.Split(","c)
                    sw.WriteLine(CDbl(strArray(0)).ToString("0") & "," & strArray(1))
                Next
            End Using

        Catch ex As Exception
            MsgBox("【SaveSitenData】" & ex.Message)
        End Try

    End Sub


    ''' <summary>
    ''' 支店データの表示
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DispSitenData()

        Dim col(3) As String
        Dim itm As ListViewItem
        Dim intNumber As Integer = 0
        Dim strReadData As String = ""
        Dim strArray() As String = Nothing

        Try
            ' 読込ファイル名の設定
            Dim strReadDataFileName As String = IncludeTrailingPathDelimiter(Application.StartupPath) & PubConstClass.DEF_BRANCH_MASTER
            LsvDataView.Items.Clear()
            Using sr As New System.IO.StreamReader(strReadDataFileName, System.Text.Encoding.Default)
                Do While Not sr.EndOfStream
                    strReadData = sr.ReadLine.ToString
                    strArray = Split(strReadData, ","c)
                    intNumber += 1
                    col(0) = intNumber.ToString("0")
                    col(1) = strArray(0)
                    col(2) = strArray(1)
                    itm = New ListViewItem(col)
                    LsvDataView.Items.Add(itm)
                Loop
                LsvDataView.Items(0).Selected = True
                LsvDataView.Items(0).Focused = True
                LsvDataView.Select()
                LsvDataView.Items(0).EnsureVisible()

            End Using

        Catch ex As Exception
            MsgBox("【DispSitenData】" & ex.Message)
        End Try

    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub LsvDataView_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LsvDataView.SelectedIndexChanged
        ' LsvDataView_Click 参照
    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub LsvDataView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LsvDataView.Click

        Try
            ' 支店コードの取得と設定
            TxtBranchCd.Text = LsvDataView.Items(LsvDataView.SelectedItems(0).Index).SubItems(1).Text()
            ' 支店名の取得と設定
            TxtBranchName.Text = LsvDataView.Items(LsvDataView.SelectedItems(0).Index).SubItems(2).Text()

        Catch ex As Exception
            MsgBox("【LsvDataView_Click】" & ex.Message)
        End Try

    End Sub

    Private Sub TxtBranchCd_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBranchCd.KeyDown
        If e.KeyData = Keys.Enter Then
            ' 「検索」ボタンにフォーカスをセットする
            BtnSearch.Focus()
        End If
    End Sub

    Private Sub TxtBranchCd_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBranchCd.TextChanged
        '// TxtBranchCd_LostFocus 参照
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TxtBranchCd_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtBranchCd.LostFocus

        Try
            If IsNumeric(TxtBranchCd.Text) = True Then
                TxtBranchCd.Text = CDbl(TxtBranchCd.Text).ToString("0")
            End If

        Catch ex As Exception
            MsgBox("【TxtBranchCd_LostFocus】" & ex.Message)
        End Try

    End Sub

End Class