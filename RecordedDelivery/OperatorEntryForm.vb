Option Explicit On
Option Strict On

Public Class OperatorEntryForm

    ' この変数は不要かもしれないので要検討
    Private intOperatorIndex As Integer

    ''' <summary>
    ''' フォームアクティブ処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub OperatorEntryForm_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated

        Try
            ' オペレータ情報の表示
            LblOperatorName.Text = GetOperatorInfomation()

            'If PubConstClass.pblOperatorAuthorityh = "管理者" Or PubConstClass.pblOperatorAuthorityh = "保守員" Then
            '    ' 管理者
            '    'RdoAdmin.Checked = True     ' 権限は「管理者」で
            '    Panel1.Enabled = True       ' 変更可能とする
            '    ' オペレータコードは空白で変更可能とする
            '    TxtOpCode.Enabled = True
            '    ' オペレータの「削除」も可能とする
            '    BtnDelete.Enabled = True
            'Else
            '    ' 「一般」ユーザーの処理
            '    'RdoUser.Checked = True      ' 権限は「一般」で
            '    Panel1.Enabled = False      ' 変更出来ない
            '    ' オペレータコードの表示
            '    TxtOpCode.Text = PubConstClass.pblOperatorCode
            '    ' オペレータコードは変更出来ない
            '    TxtOpCode.Enabled = False
            '    ' オペレータ名の表示（変更可能とする）
            '    TxtOpName.Text = PubConstClass.pblOperatorName
            '    ' 「削除」ボタンは使用不可とする
            '    BtnDelete.Enabled = False
            'End If

        Catch ex As Exception
            MsgBox("【OperatorEntryForm_Activated】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' フォームロード処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub OperatorEntryForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            LblDate.Text = Date.Now.ToString("yyyy年MM月dd日")            

            'EnabaleObject(False)
            EnabaleObject(True)

            ' オペレータ情報の取得
            GetOperatorIniFile()

            If PubConstClass.pblOperatorAuthorityh = "管理者" Or PubConstClass.pblOperatorAuthorityh = "保守員" Then
                ' 管理者
                RdoAdmin.Checked = True     ' 権限は「管理者」
                Panel1.Enabled = True       ' 権限の変更は可能とする
                ' オペレータコードは空白で変更可能とする
                TxtOpCode.Enabled = True
                ' オペレータの「削除」も可能とする
                BtnDelete.Enabled = True

            Else
                lblTitle.Text = "パスワードの変更"
                ' 「一般」ユーザーの処理
                RdoUser.Checked = True      ' 権限は「一般」
                Panel1.Enabled = False      ' 権限の変更は出来ない
                ' オペレータコードの表示
                TxtOpCode.Text = PubConstClass.pblOperatorCode
                ' オペレータ名称の表示
                TxtOpName.Text = PubConstClass.pblOperatorName
                ' オペレータコードは変更出来ない
                TxtOpCode.Enabled = False
                ' オペレータ名称は変更出来ない
                TxtOpName.Enabled = False
                ' オペレータ名の表示（変更可能とする）
                TxtOpName.Text = PubConstClass.pblOperatorName
                ' 「削除」ボタンは使用不可とする
                BtnDelete.Enabled = False

            End If

        Catch ex As Exception
            MsgBox("【BtnLblPublish_Click】" & ex.Message)
        End Try

    End Sub


    ''' <summary>
    ''' オブジェクトの操作可・不可の制御
    ''' </summary>
    ''' <param name="IsEnable">True：使用可／False：使用不可</param>
    ''' <remarks>各テキスト及びボタンの使用可・不可をコントロールする</remarks>
    Private Sub EnabaleObject(ByVal IsEnable As Boolean)

        Try
            'TxtOpCode.Enabled = IsEnable
            TxtOpName.Enabled = IsEnable
            TxtPassword.Enabled = IsEnable
            TxtConfirmPassword.Enabled = IsEnable

            BtnEntry.Enabled = IsEnable
            BtnDelete.Enabled = IsEnable

        Catch ex As Exception
            MsgBox("【EnabaleObject】" & ex.Message)
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

    Private Sub TxtOpCode_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtOpCode.KeyPress
        ' 英数字のみ入力可能
        e.Handled = CheckKeyPress("2", e)
    End Sub

    Private Sub TxtOpCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtOpCode.TextChanged
        '// TxtOpCode_KeyDown 参照
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TxtOpCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtOpCode.KeyDown

        Dim strArray() As String
        Dim blnIsFind As Boolean

        Try
            If e.KeyCode = Keys.Return Then

                If TxtOpCode.Text = "" Then
                    MsgBox("オペレータコードを入力して下さい", CType(MsgBoxStyle.Information + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")
                    Exit Sub
                End If

                blnIsFind = False
                For N = 0 To PubConstClass.pblOperatorArrayIndex - 1
                    strArray = Split(PubConstClass.pblOperatorArray(N), ","c)
                    If TxtOpCode.Text = strArray(0) Then
                        TxtOpName.Text = strArray(1)

                        If strArray(4) = "一般" Then
                            RdoUser.Checked = True
                            'Panel1.Enabled = False
                        ElseIf strArray(4) = "管理者" Then
                            RdoAdmin.Checked = True
                            'Panel1.Enabled = True
                        End If
                        intOperatorIndex = N
                        TxtOpName.Enabled = True
                        TxtPassword.Enabled = True
                        TxtConfirmPassword.Enabled = True
                        BtnEntry.Enabled = True

                        TxtOpName.Focus()
                        blnIsFind = True
                        Exit Sub

                    End If
                Next

                If blnIsFind = False Then
                    TxtPassword.Text = ""
                    TxtConfirmPassword.Text = ""
                    TxtOpName.Text = "新規"
                    TxtOpName.Focus()
                End If
            End If

        Catch ex As Exception
            MsgBox("【TxtOpCode_KeyDown】" & ex.Message)
        End Try

    End Sub


    ''' <summary>
    ''' 「登録」ボタン処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnEntry_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEntry.Click

        Dim strArray() As String = Nothing
        Dim strChangeData As String = ""
        Dim blnIsFind As Boolean = False
        Dim retVal As MsgBoxResult
        Dim strOutPutENCFileName As String
        Dim strOutPutINIFileName As String

        strOutPutENCFileName = IncludeTrailingPathDelimiter(Application.StartupPath) & PubConstClass.DEF_OPERATOR_FILE_NAME_ENC
        strOutPutINIFileName = IncludeTrailingPathDelimiter(Application.StartupPath) & PubConstClass.DEF_OPERATOR_FILE_NAME_INI

        Try
            If TxtOpCode.Text = "" Then
                MsgBox("オペレータコードを入力して下さい", CType(MsgBoxStyle.Information + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")
                Exit Sub
            End If
            If TxtOpName.Text = "" Then
                MsgBox("オペレータ名を入力して下さい", CType(MsgBoxStyle.Information + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")
                Exit Sub
            End If
            If TxtPassword.Text = "" Then
                MsgBox("パスワードを入力して下さい", CType(MsgBoxStyle.Information + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")
                Exit Sub
            End If
            If TxtConfirmPassword.Text = "" Then
                MsgBox("パスワード（確認）を入力して下さい", CType(MsgBoxStyle.Information + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")
                Exit Sub
            End If
            If TxtPassword.Text <> TxtConfirmPassword.Text Then
                MsgBox("「パスワード」と「パスワード（確認）」が異なります", CType(MsgBoxStyle.Information + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")
                Exit Sub
            End If

            ' 該当のオペレータコードを検索する
            For N = 0 To PubConstClass.pblOperatorArrayIndex - 1
                '          0,     1,          2,         3,     4
                'maintenance,保守員,maintenance,2015/08/17,保守員
                strArray = Split(PubConstClass.pblOperatorArray(N), ","c)
                If strArray(0) = TxtOpCode.Text Then

                    retVal = MsgBox("オペレータコード（" & TxtOpCode.Text & "）の内容を変更しますか？", CType(MsgBoxStyle.Question + MsgBoxStyle.OkCancel, MsgBoxStyle), "確認")
                    If retVal = MsgBoxResult.Cancel Then
                        ' キャンセル
                        Exit Sub
                    End If

                    ' オペレータコード
                    strChangeData = strArray(0) & ","
                    ' オペレータ名称
                    strChangeData &= TxtOpName.Text & ","
                    ' パスワード
                    'strChangeData &= EncryptString(TxtPassword.Text, PubConstClass.DEF_OPEN_KEY) & ","
                    strChangeData &= TxtPassword.Text & ","
                    ' 登録日
                    strChangeData &= Date.Now.ToString("yyyy/MM/dd") & ","
                    OutPutLogFile("■オペレータコード変更：" & TxtOpCode.Text)
                    OutPutLogFile("■オペレータ名称変更：" & TxtOpName.Text)
                    If strArray(4) = "保守員" Then
                        strChangeData &= "保守員"
                        OutPutLogFile("■オペレータ権限変更：保守員")
                    Else
                        ' 権限
                        If RdoUser.Checked = True Then
                            strChangeData &= "一般"
                            OutPutLogFile("■オペレータ権限変更：一般")
                        ElseIf RdoAdmin.Checked = True Then
                            strChangeData &= "管理者"
                            OutPutLogFile("■オペレータ権限変更：管理者")
                        Else
                            strChangeData &= "不明"
                            OutPutLogFile("■オペレータ権限変更：不明")
                        End If
                    End If

                    PubConstClass.pblOperatorArray(N) = strChangeData
                    blnIsFind = True

                End If
            Next

            ' 現行のオペレータ情報格納配列にない場合は新規登録とする
            If blnIsFind = False Then

                retVal = MsgBox("オペレータコード（" & TxtOpCode.Text & "）を新規登録しますか？", CType(MsgBoxStyle.Question + MsgBoxStyle.OkCancel, MsgBoxStyle), "確認")
                If retVal = MsgBoxResult.Cancel Then
                    ' キャンセル
                    Exit Sub
                End If

                ' オペレータコード
                strChangeData = TxtOpCode.Text & ","
                ' オペレータ名称
                strChangeData &= TxtOpName.Text & ","
                ' パスワード
                'strChangeData &= EncryptString(TxtPassword.Text, PubConstClass.DEF_OPEN_KEY) & ","
                strChangeData &= TxtPassword.Text & ","
                ' 登録日
                strChangeData &= Date.Now.ToString("yyyy/MM/dd") & ","
                OutPutLogFile("■オペレータコード新規登録：" & TxtOpCode.Text)
                OutPutLogFile("■オペレータ名称新規登録：" & TxtOpName.Text)
                ' 権限
                If RdoUser.Checked = True Then
                    strChangeData &= "一般"
                    OutPutLogFile("■オペレータ権限新規登録：一般")
                ElseIf RdoAdmin.Checked = True Then
                    strChangeData &= "管理者"
                    OutPutLogFile("■オペレータ権限新規登録：管理者")
                Else
                    strChangeData &= "不明"
                    OutPutLogFile("■オペレータ権限新規登録：不明")
                End If
                PubConstClass.pblOperatorArray(PubConstClass.pblOperatorArrayIndex) = strChangeData
                PubConstClass.pblOperatorArrayIndex += 1

            End If

            ' オペレータ情報ファイル(INI)の削除
            System.IO.File.Delete(strOutPutINIFileName)
            ' 全オペレータ情報のINIファイルへの書き込み
            For N = 0 To PubConstClass.pblOperatorArrayIndex - 1
                ' 追記モードで書き込む
                Using sw As New System.IO.StreamWriter(strOutPutINIFileName, True, System.Text.Encoding.Default)
                    sw.WriteLine(PubConstClass.pblOperatorArray(N))
                End Using
            Next
            ' オペレータ情報ファイルを暗号化する
            EncryptFile(strOutPutINIFileName, strOutPutENCFileName, PubConstClass.DEF_OPEN_KEY)
            ' オペレータ情報ファイル(INI)の削除
            System.IO.File.Delete(strOutPutINIFileName)

            ' 全オペレータ情報を再取得する
            GetOperatorIniFile()

            MsgBox("登録が完了しました。", CType(MsgBoxStyle.Information + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")

        Catch ex As Exception
            ' オペレータ情報ファイル(INI)の削除
            System.IO.File.Delete(strOutPutINIFileName)
            MsgBox("【BtnEntry_Click】" & ex.Message)
        End Try

    End Sub

    Private Sub TxtOpName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtOpName.KeyDown
        If e.KeyCode = Keys.Return Then
            ' 「Enter」キーで「パスワード」へフォーカスを移動する
            TxtPassword.Focus()
        End If
    End Sub

    Private Sub TxtPassword_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtPassword.KeyDown
        If e.KeyCode = Keys.Return Then
            ' 「Enter」キーで「パスワード確認」へフォーカスを移動する
            TxtConfirmPassword.Focus()
        End If
    End Sub

    Private Sub TxtConfirmPassword_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtConfirmPassword.KeyDown
        If e.KeyCode = Keys.Return Then
            ' 「Enter」キーフォーカスを移動する
            BtnEntry.Focus()
        End If
    End Sub


    ''' <summary>
    ''' 「削除」ボタン処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnDelete_Click(sender As System.Object, e As System.EventArgs) Handles BtnDelete.Click

        Dim strArray() As String
        Dim retVal As MsgBoxResult

        Try

            For N = 0 To PubConstClass.pblOperatorArrayIndex - 1
                '          0,     1,          2,         3,     4
                'maintenance,保守員,maintenance,2015/08/17,保守員
                strArray = Split(PubConstClass.pblOperatorArray(N), ","c)
                If TxtOpCode.Text = strArray(0) Then
                    If strArray(4) = "保守員" Then
                        MsgBox("権限が保守員のオペレータコードは削除できません", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")
                        Exit Sub
                    End If
                    retVal = MsgBox("オペレータコード（" & TxtOpCode.Text & "）を削除しますか？", CType(MsgBoxStyle.Question + MsgBoxStyle.OkCancel, MsgBoxStyle), "確認")
                    If retVal = MsgBoxResult.Cancel Then
                        ' キャンセル
                        Exit Sub
                    End If
                    PubConstClass.pblOperatorArray(N) = ""
                    Exit For
                End If
            Next

            ' オペレーターファイルの復号化
            Dim strOutPutENCFileName As String = IncludeTrailingPathDelimiter(Application.StartupPath) & PubConstClass.DEF_OPERATOR_FILE_NAME_ENC
            Dim strOutPutINIFileName As String = IncludeTrailingPathDelimiter(Application.StartupPath) & PubConstClass.DEF_OPERATOR_FILE_NAME_INI
            ' オペレータ情報ファイル(INI)の削除
            System.IO.File.Delete(strOutPutINIFileName)
            ' 全オペレータ情報のINIファイルへの書き込み
            For N = 0 To PubConstClass.pblOperatorArrayIndex - 1
                ' 追記モードで書き込む
                Using sw As New System.IO.StreamWriter(strOutPutINIFileName, True, System.Text.Encoding.Default)
                    If PubConstClass.pblOperatorArray(N) <> "" Then
                        sw.WriteLine(PubConstClass.pblOperatorArray(N))
                    End If
                End Using
            Next
            ' オペレータ情報ファイルを暗号化する
            EncryptFile(strOutPutINIFileName, strOutPutENCFileName, PubConstClass.DEF_OPEN_KEY)
            ' オペレータ情報ファイル(INI)の削除
            System.IO.File.Delete(strOutPutINIFileName)

            ' 全オペレータ情報を再取得する
            GetOperatorIniFile()

            TxtOpCode.Text = ""
            TxtOpName.Text = ""
            TxtPassword.Text = ""
            TxtConfirmPassword.Text = ""

            MsgBox("削除が完了しました。", CType(MsgBoxStyle.Information + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")

        Catch ex As Exception
            MsgBox("【BtnDelete_Click】" & ex.Message)
        End Try

    End Sub

End Class