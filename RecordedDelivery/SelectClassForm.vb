Option Explicit On
Option Strict On

Public Class SelectClassForm

    Private Sub SelectClassForm_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated

        ' 支店コード入力のフォーカスをセット
        TxtBranchCd.Focus()

        ' オペレータ情報の表示
        LblOperatorName.Text = GetOperatorInfomation()

    End Sub


    ''' <summary>
    ''' 「×」ボタンのキャンセル
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub SelectClassForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        ' 「×」ボタンのキャンセル
        e.Cancel = True

    End Sub

    ''' <summary>
    ''' フォームロード処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub SelectClassForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            OutPutLogFile($"【{Me.Text}】（{PubConstClass.pblOperatorCode}：{PubConstClass.pblOperatorName}）")

            ' 現在の年月日を取得する
            LblCurrentDate.Text = GetCurrentDate()

            ' 支店コードの設定
            TxtBranchCd.Text = ""

            TxtBranchCd.ImeMode = ImeMode.Off
            TxtBranchCd.MaxLength = 10

            ' 種別ファイルフィルターの設定
            Dim sAray() As String
            CmbClassFilter.Items.Clear()
            For Each sData In PubConstClass.sClassGroupList
                sAray = sData.Split(","c)
                CmbClassFilter.Items.Add(sAray(0))
            Next
            CmbClassFilter.SelectedIndex = 0

        Catch ex As Exception
            MsgBox("【SelectClassForm_Load】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 「戻る」ボタン処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBack.Click

        'PubConstClass.pblIsOkayFlag = False
        Me.Dispose()

    End Sub


    ''' <summary>
    ''' 「次へ」ボタン処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNext.Click

        '// 2015.12.16 Ver.B04 hayakawa 追加↓ここから
        Dim strMessage As String
        '// 2015.12.16 Ver.B04 hayakawa 追加↑ここまで

        Try
            '// 2015.12.16 Ver.B04 hayakawa 追加↓ここから
            ' 指定種別の現在の引受番号を取得する
            GetStartUnderWritingNumber(CmbClassification.Text)

            strMessage = "開始引受番号が重複しています。" & vbCr & "管理者に引受番号の修正を依頼して下さい。" & vbCr & vbCr
            strMessage &= "開始引受番号："
            strMessage &= PubConstClass.dblStartUnderWritingNumber.ToString("000-00-00000") & "-" & (PubConstClass.dblStartUnderWritingNumber Mod 7).ToString("0") & vbCr & vbCr
            Dim strArrayClass() As String = CmbClassification.Text.Split("："c)
            Select Case strArrayClass(0)

                Case "30", "40"
                    ' 簡易書留、簡易書留（速達）
                    If PubConstClass.pblUsed30FromUnderWrittingNumber <= PubConstClass.dblStartUnderWritingNumber And _
                        PubConstClass.dblStartUnderWritingNumber <= PubConstClass.pblUsed30ToUnderWrittingNumber Then
                        strMessage &= PubConstClass.pblUsed30FromUnderWrittingNumber.ToString("000-00-00000") & "-" & _
                                         (PubConstClass.pblUsed30FromUnderWrittingNumber Mod 7).ToString("0") & " ～ " & _
                                         PubConstClass.pblUsed30ToUnderWrittingNumber.ToString("000-00-00000") & "-" & _
                                         (PubConstClass.pblUsed30ToUnderWrittingNumber Mod 7).ToString("0") & vbCr & _
                                            "の引受番号が過去10日分の間に使用されています。"
                        MsgBox(strMessage, CType(MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, MsgBoxStyle), "システムエラー")
                        Exit Sub
                    End If

                    If PubConstClass.blnIsOneRound30Flg = True Then
                        If PubConstClass.pblUsed30FromUnderWrittingNumber2 <= PubConstClass.dblStartUnderWritingNumber And _
                            PubConstClass.dblStartUnderWritingNumber <= PubConstClass.pblUsed30ToUnderWrittingNumber2 Then
                            strMessage &= PubConstClass.pblUsed30FromUnderWrittingNumber2.ToString("000-00-00000") & "-" & _
                                             (PubConstClass.pblUsed30FromUnderWrittingNumber2 Mod 7).ToString("0") & " ～ " & _
                                             PubConstClass.pblUsed30ToUnderWrittingNumber2.ToString("000-00-00000") & "-" & _
                                             (PubConstClass.pblUsed30ToUnderWrittingNumber2 Mod 7).ToString("0") & vbCr & _
                                                "の引受番号が過去10日分の間に使用されています。"
                            MsgBox(strMessage, CType(MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, MsgBoxStyle), "システムエラー")
                            Exit Sub
                        End If
                    End If

                Case "50", "60"
                    ' 特定記録、特定記録（速達）
                    If PubConstClass.pblUsed50FromUnderWrittingNumber <= PubConstClass.dblStartUnderWritingNumber And _
                        PubConstClass.dblStartUnderWritingNumber <= PubConstClass.pblUsed50ToUnderWrittingNumber Then
                        strMessage &= PubConstClass.pblUsed50FromUnderWrittingNumber.ToString("000-00-00000") & "-" & _
                                         (PubConstClass.pblUsed50FromUnderWrittingNumber Mod 7).ToString("0") & " ～ " & _
                                         PubConstClass.pblUsed50ToUnderWrittingNumber.ToString("000-00-00000") & "-" & _
                                         (PubConstClass.pblUsed50ToUnderWrittingNumber Mod 7).ToString("0") & vbCr & _
                                            "の引受番号が過去10日分の間に使用されています。"
                        MsgBox(strMessage, CType(MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, MsgBoxStyle), "システムエラー")
                        Exit Sub
                    End If

                    If PubConstClass.blnIsOneRound50Flg = True Then
                        If PubConstClass.pblUsed50FromUnderWrittingNumber2 <= PubConstClass.dblStartUnderWritingNumber And _
                            PubConstClass.dblStartUnderWritingNumber <= PubConstClass.pblUsed50ToUnderWrittingNumber2 Then
                            strMessage &= PubConstClass.pblUsed50FromUnderWrittingNumber2.ToString("000-00-00000") & "-" & _
                                             (PubConstClass.pblUsed50FromUnderWrittingNumber2 Mod 7).ToString("0") & " ～ " & _
                                             PubConstClass.pblUsed50ToUnderWrittingNumber2.ToString("000-00-00000") & "-" & _
                                             (PubConstClass.pblUsed50ToUnderWrittingNumber2 Mod 7).ToString("0") & vbCr & _
                                                "の引受番号が過去10日分の間に使用されています。"
                            MsgBox(strMessage, CType(MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, MsgBoxStyle), "システムエラー")
                            Exit Sub
                        End If
                    End If

                Case "150", "160"
                    ' ゆうメール、ゆうメール（速達）
                    If PubConstClass.pblUsed150FromUnderWrittingNumber <= PubConstClass.dblStartUnderWritingNumber And _
                        PubConstClass.dblStartUnderWritingNumber <= PubConstClass.pblUsed150ToUnderWrittingNumber Then
                        strMessage &= PubConstClass.pblUsed150FromUnderWrittingNumber.ToString("000-00-00000") & "-" & _
                                         (PubConstClass.pblUsed150FromUnderWrittingNumber Mod 7).ToString("0") & " ～ " & _
                                         PubConstClass.pblUsed150ToUnderWrittingNumber.ToString("000-00-00000") & "-" & _
                                         (PubConstClass.pblUsed150ToUnderWrittingNumber Mod 7).ToString("0") & vbCr & _
                                            "の引受番号が過去10日分の間に使用されています。"
                        MsgBox(strMessage, CType(MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, MsgBoxStyle), "システムエラー")
                        Exit Sub
                    End If

                    If PubConstClass.blnIsOneRound150Flg = True Then
                        If PubConstClass.pblUsed150FromUnderWrittingNumber2 <= PubConstClass.dblStartUnderWritingNumber And _
                            PubConstClass.dblStartUnderWritingNumber <= PubConstClass.pblUsed150ToUnderWrittingNumber2 Then
                            strMessage &= PubConstClass.pblUsed150FromUnderWrittingNumber2.ToString("000-00-00000") & "-" & _
                                             (PubConstClass.pblUsed150FromUnderWrittingNumber2 Mod 7).ToString("0") & " ～ " & _
                                             PubConstClass.pblUsed150ToUnderWrittingNumber2.ToString("000-00-00000") & "-" & _
                                             (PubConstClass.pblUsed150ToUnderWrittingNumber2 Mod 7).ToString("0") & vbCr & _
                                                "の引受番号が過去10日分の間に使用されています。"
                            MsgBox(strMessage, CType(MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, MsgBoxStyle), "システムエラー")
                            Exit Sub
                        End If
                    End If

                Case Else
            End Select
            '// 2015.12.16 Ver.B04 hayakawa 追加↑ここまで

            If TxtBranchCd.Text = "" Then
                MsgBox("支店コードを入力して下さい", CType(MsgBoxStyle.Information + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")
                TxtBranchCd.Focus()
                Exit Sub
            End If

            If TxtTranCnt.Text = "" Then
                MsgBox("処理予定通数を入力して下さい", CType(MsgBoxStyle.Information + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")
                TxtTranCnt.Focus()
                Exit Sub
            End If

            If TxtTranCnt.Text = "0" Then
                MsgBox("処理予定通数は「1」以上を入力して下さい", CType(MsgBoxStyle.Information + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")
                TxtTranCnt.Focus()
                Exit Sub
            End If
            If LblBranchName.Text = "" Then
                MsgBox("支店コードを確定して下さい", CType(MsgBoxStyle.Information + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")
                TxtBranchCd.Focus()
                Exit Sub
            End If
            ' 処理日
            PubConstClass.pblTranDate = DateTimePicker1.Value.ToString("yyyy/MM/dd hh:mm:ss")
            ' 支店コード
            PubConstClass.pblSitenCode = TxtBranchCd.Text
            ' 支店名
            PubConstClass.pblSitenName = LblBranchName.Text
            ' 種別
            'PubConstClass.pblClassForSiten = CmbClassification.SelectedIndex.ToString("0")
            PubConstClass.pblClassForSiten = CmbClassification.Text
            ' 処理予定数
            PubConstClass.pblTranYoteiCount = TxtTranCnt.Text
            If Rdo15Face.Checked = True Then
                ' 受領証面数設定（15面）
                PubConstClass.pblPrintCountPerPage = "0"
            Else
                ' 受領証面数設定（8面）
                PubConstClass.pblPrintCountPerPage = "1"
            End If

            DrivingForm.Show()

            Me.Hide()
            MainForm.Hide()

            OutPutLogFile("〓「運転画面」呼び出し〓")

        Catch ex As Exception
            MsgBox("【BtnNext_Click】" & ex.Message)
        End Try

    End Sub


    Private Sub BtnNext_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles BtnNext.KeyDown

        If e.KeyData = Keys.Enter Then
            ' 支店コードフォーカスをセットする
            TxtBranchCd.Focus()
        End If

    End Sub


    ''' <summary>
    ''' 「検索」ボタン処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSearch.Click

        Dim strArray() As String
        Dim intLoopCnt As Integer
        Dim blnIsFind As Boolean

        Try
            blnIsFind = False
            For intLoopCnt = 0 To PubConstClass.pblBranchIndex - 1
                strArray = PubConstClass.pblBranchArray(intLoopCnt).Split(","c)
                If IsNumeric(TxtBranchCd.Text) = True Then

                    If strArray(0) = CDbl(TxtBranchCd.Text).ToString("0") Then
                        blnIsFind = True
                        LblBranchName.Text = strArray(1)
                        Exit For
                    End If

                End If
            Next
            If blnIsFind = False Then
                LblBranchName.Text = ""
                MsgBox("支店コードが見つかりません", CType(MsgBoxStyle.Information + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")
                ' 支店コードにフォーカスをセットする
                TxtBranchCd.Focus()
            Else
                ' 処理予定数にフォーカスをセットする
                TxtTranCnt.Focus()
            End If

        Catch ex As Exception
            MsgBox("【BtnSearch_Click】" & ex.Message)
        End Try

    End Sub

    Private Sub TxtBranchCd_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBranchCd.KeyPress
        ' 数字のみ入力可能
        e.Handled = CheckKeyPress("1", e)
    End Sub

    Private Sub TxtBranchCd_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtBranchCd.TextChanged
        ' TxtBranchCd_KeyDown に処理実装
    End Sub

    Private Sub TxtBranchCd_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBranchCd.KeyDown

        LblBranchName.Text = ""

        If e.KeyData = Keys.Enter Then
            ' 「検索」ボタンにフォーカスをセットする
            BtnSearch.Focus()
        End If

    End Sub

    Private Sub TxtTranCnt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtTranCnt.TextChanged
        '// TxtTranCnt_KeyPress → TxtTranCnt_KeyDown
    End Sub

    Private Sub TxtTranCnt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtTranCnt.KeyPress
        ' 数字のみ入力可能
        e.Handled = CheckKeyPress("1", e)
    End Sub

    Private Sub TxtTranCnt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtTranCnt.KeyDown

        If e.KeyData = Keys.Enter Then
            ' 「次へ」ボタンにフォーカスをセットする
            BtnNext.Focus()
        End If

    End Sub

    Private Sub TxtBranchCd_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtBranchCd.LostFocus

        Try
            If TxtBranchCd.Text <> "" Then
                TxtBranchCd.Text = CDbl(TxtBranchCd.Text).ToString("0")
            End If

        Catch ex As System.OverflowException
            MsgBox("支店コードが見つかりません")
        Catch ex As Exception
            MsgBox("【TxtBranchCd_LostFocus】" & ex.Message)
        End Try

    End Sub

    Private Sub CmbClassFilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbClassFilter.SelectedIndexChanged

        Dim sAray As String()

        Try
            sAray = PubConstClass.sClassGroupList(CmbClassFilter.SelectedIndex).Split(","c)
            CmbClassification.Items.Clear()
            For N = 1 To sAray.Length - 1
                CmbClassification.Items.Add(sAray(N))
            Next
            CmbClassification.SelectedIndex = 0

        Catch ex As Exception
            MsgBox("【CmbClassFilter_SelectedIndexChanged】" & ex.Message)
        End Try
    End Sub

End Class