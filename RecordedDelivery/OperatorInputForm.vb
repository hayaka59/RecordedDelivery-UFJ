Option Explicit On
Option Strict On

Public Class OperatorInputForm

    ''' <summary>
    ''' フォームアクティブ処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub OperatorInputForm_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated

        TxtOperator.Focus()

    End Sub

    ''' <summary>
    ''' ' 「×」ボタンのキャンセル
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub OperatorInputForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        ' 「×」ボタンのキャンセル
        e.Cancel = True

    End Sub

    ''' <summary>
    ''' フォームロード処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub OperatorInputForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try

            ' 現在の年月日を取得する
            lblCurrentDate.Text = GetCurrentDate()

        Catch ex As Exception
            MsgBox("【OperatorInputForm_Load】" & ex.Message)
        End Try

    End Sub


    Private Sub TxtOperator_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtOperator.KeyPress
        ' 英数字のみ入力可能
        e.Handled = CheckKeyPress("2", e)
    End Sub

    Private Sub TxtOperator_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtOperator.TextChanged
        '// TxtOperator_KeyDown 参照
    End Sub

    ''' <summary>
    ''' オペレータコード入力処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TxtOperator_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtOperator.KeyDown

        Try
            ' 「Enter」キーで入力値をチェックしフォーカスを移動する
            If e.KeyCode = Keys.Return Then

                If TxtOperator.Text = "" Then
                    MsgBox("オペレータコードが入力されていません", CType(MsgBoxStyle.Information + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")
                    Exit Sub
                End If

                TxtPassword.Focus()

            End If

        Catch ex As Exception
            MsgBox("【TxtOperator_KeyDown】" & ex.Message)
        End Try

    End Sub

    Private Sub TxtPassword_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtPassword.TextChanged
        '// TxtPassword_KeyDown 参照
    End Sub

    ''' <summary>
    ''' パスワード入力処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TxtPassword_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtPassword.KeyDown

        Try
            ' 「Enter」キーで入力値をチェックしフォーカスを移動する
            If e.KeyCode = Keys.Return Then

                If TxtOperator.Text = "" Then
                    MsgBox("オペレータコードが入力されていません", CType(MsgBoxStyle.Information + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")
                    Exit Sub
                End If

                If TxtPassword.Text = "" Then
                    MsgBox("パスワードが入力されていません", CType(MsgBoxStyle.Information + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")
                    Exit Sub
                End If

                PubConstClass.pblIsOkayFlag = ConFirmOperator()
                If PubConstClass.pblIsOkayFlag = True Then
                    Me.Dispose()
                End If

            End If

        Catch ex As Exception
            MsgBox("【TxtPassword_KeyDown】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' オペレーターの確認処理
    ''' </summary>
    ''' <returns>True：ＯＫ／False：ＮＧ</returns>
    ''' <remarks>オペレーターの存在確認とパスワード照合と有効期限の確認</remarks>
    Private Function ConFirmOperator() As Boolean

        Dim strArray() As String
        'Dim strDecryptValue As String
        Dim IsFind As Boolean = False

        Try
            ' 全オペレータ情報を取得する
            GetOperatorIniFile()

            ' 該当のオペレータコードを検索する
            For N = 0 To PubConstClass.pblOperatorArrayIndex - 1
                strArray = Split(PubConstClass.pblOperatorArray(N), ","c)
                If strArray(0) = TxtOperator.Text Then

                    ' 入力したパスワードを暗号化する
                    'strDecryptValue = EncryptString(TxtPassword.Text, PubConstClass.DEF_OPEN_KEY)
                    If TxtPassword.Text = strArray(2) Then
                        ' オペレーターコードの格納
                        PubConstClass.pblOperatorCode = TxtOperator.Text
                        OutPutLogFile("■オペレータコード：" & PubConstClass.pblOperatorCode)
                        ' オペレーター名称の格納
                        PubConstClass.pblOperatorName = strArray(1)
                        OutPutLogFile("■オペレータ名称：" & PubConstClass.pblOperatorName)
                        ' 登録日
                        PubConstClass.pblOperatorEntryDate = strArray(3)
                        OutPutLogFile("■オペレータ登録日：" & PubConstClass.pblOperatorEntryDate)
                        ' 権限
                        PubConstClass.pblOperatorAuthorityh = strArray(4)
                        OutPutLogFile("■オペレータ権限：" & PubConstClass.pblOperatorAuthorityh)

                        ' パスワードの有効期間のチェック
                        'Dim dtPassUsePeriod As DateTime = Date.Now
                        ' オペレータ登録日に有効期間を加算
                        Dim dtPassUsePeriod As DateTime = DateTime.Parse(PubConstClass.pblOperatorEntryDate).AddDays(CDbl(PubConstClass.passUsePeriod))

                        Dim intDateComp As Integer = Date.Compare(Date.Now, dtPassUsePeriod)

                        ' intDateComp = Date.Compare(date1,date2)
                        ' 結果
                        ' intDateComp = -1 : date1 < date2
                        ' intDateComp = 0 : date1 = date2
                        ' intDateComp = 1 : date1 > date2 
                        If intDateComp > 0 Then
                            Dim varRet As MsgBoxResult
                            varRet = MsgBox("パスワードの有効期限（" & dtPassUsePeriod.ToString("yyyy/MM/dd") & "）が切れています。パスワードを変更しますか？", _
                                   CType(MsgBoxStyle.Question + MsgBoxStyle.OkCancel, MsgBoxStyle), "確認")
                            If varRet = MsgBoxResult.Cancel Then
                                Return False
                            Else
                                OutPutLogFile("■パスワード有効期限切れ")
                                Me.Dispose()
                                OperatorEntryForm.ShowDialog()
                                Return False
                            End If
                        End If

                        'MsgBox(strArray(1) & vbCr & strArray(3) & vbCr & strArray(4), CType(MsgBoxStyle.Information + MsgBoxStyle.OkOnly, MsgBoxStyle), "デバッグメッセージ")
                        MainForm.LblOperatorName.Text = GetOperatorInfomation()

                        IsFind = True
                    Else
                        OutPutLogFile("■パスワードが一致しません：" & TxtPassword.Text)
                        MsgBox("パスワードが一致しません", CType(MsgBoxStyle.Information + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")
                        Return False
                    End If

                End If
            Next

            If IsFind = False Then
                MsgBox("オペレータコードが存在しません", CType(MsgBoxStyle.Information + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")
            End If

        Catch ex As Exception
            MsgBox("【ConFirmOperator】" & ex.Message)
        Finally
            ConFirmOperator = IsFind
        End Try

    End Function


    ''' <summary>
    ''' 「キャンセル」ボタン処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnCansel_Click(sender As System.Object, e As System.EventArgs) Handles BtnCansel.Click

        PubConstClass.pblIsOkayFlag = False
        Me.Dispose()

    End Sub

    Private Sub BtnPassword_Click(sender As Object, e As EventArgs) Handles BtnPassword.Click

        Try
            If TxtPassword.PasswordChar.ToString() = "*" Then
                TxtPassword.PasswordChar = ChrW(0)
                BtnPassword.Image = My.Resources.password_close
            Else
                TxtPassword.PasswordChar = "*"c
                BtnPassword.Image = My.Resources.password_open
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "【BtnPassword_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

End Class