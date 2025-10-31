Option Explicit On
Option Strict On

Public Class MngNumberForm

    ''' <summary>
    ''' フォームアクティブ処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MngNumberForm_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated

        LblOperatorName.Text = GetOperatorInfomation()

    End Sub


    ''' <summary>
    ''' フォームロード処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MngNumberForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Dim strArray() As String
            Dim intArrayIndex As Integer = 0

            ' 現在の年月日を取得する
            lblCurrentDate.Text = GetCurrentDate()

            ' 引受番号データの取得
            Call GetUnderWritingNumber()

            ' 引受番号帯コードコンボボックスの登録
            CmbMasterItem.Items.Clear()
            For N = 0 To PubConstClass.strNumberInfo.Length - 1
                strArray = Split(PubConstClass.strNumberInfo(N), ","c)
                If strArray(0) <> "" Then
                    CmbMasterItem.Items.Add(strArray(0))
                End If
            Next
            CmbMasterItem.SelectedIndex = 0

        Catch ex As Exception
            MsgBox("【MngNumberForm_Load】" & ex.Message)
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
    ''' コンボボックス選択処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CmbMasterItem_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles CmbMasterItem.SelectedIndexChanged

        Try
            Dim strNumArray() As String = Nothing

            Dim strArray() As String = Split(PubConstClass.strNumberInfo(CmbMasterItem.SelectedIndex), ","c)
            TxtClassName.Text = strArray(1)

            strArray = Split(PubConstClass.strStartNumber(CmbMasterItem.SelectedIndex), ","c)
            strNumArray = Split(strArray(1), "-"c)
            TxtStNum1.Text = strNumArray(0)
            TxtStNum2.Text = strNumArray(1)
            TxtStNum3.Text = strNumArray(2)
            TxtStNum4.Text = strNumArray(3)

            strArray = Split(PubConstClass.strEndNumber(CmbMasterItem.SelectedIndex), ","c)
            strNumArray = Split(strArray(1), "-"c)
            TxtEnNum1.Text = strNumArray(0)
            TxtEnNum2.Text = strNumArray(1)
            TxtEnNum3.Text = strNumArray(2)
            TxtEnNum4.Text = strNumArray(3)

        Catch ex As Exception
            MsgBox("【CmbMasterItem_SelectedIndexChanged】" & ex.Message)
        End Try

    End Sub


    ''' <summary>
    ''' 「更新」ボタン処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUpdate.Click

        Dim intArrayIndex As Integer
        Dim strMessage As String
        Dim strCmpCD As String

        Try
            If TxtStNum1.Text.Trim = "" Or TxtStNum2.Text.Trim = "" Or _
                TxtStNum3.Text.Trim = "" Or TxtStNum4.Text.Trim = "" Then
                MsgBox("開始番号を入力して下さい", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")
                TxtStNum1.Focus()
                Exit Sub
            End If

            If TxtEnNum1.Text.Trim = "" Or TxtEnNum2.Text.Trim = "" Or _
                TxtEnNum3.Text.Trim = "" Or TxtEnNum4.Text.Trim = "" Then
                MsgBox("終了番号を入力して下さい", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")
                TxtEnNum1.Focus()
                Exit Sub
            End If

            strCmpCD = (CDbl(TxtStNum1.Text & TxtStNum2.Text & TxtStNum3.Text) Mod 7).ToString("0"c)
            'If CDbl(TxtStNum1.Text & TxtStNum2.Text & TxtStNum3.Text) Mod 7 <> CDbl(TxtStNum4.Text) Then
            If strCmpCD <> TxtStNum4.Text Then
                'MsgBox("開始番号のＣＤに誤りがあります", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")
                MsgBox($"開始番号のＣＤは「{strCmpCD}」です", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")
                TxtStNum4.Focus()
                Exit Sub
            End If

            strCmpCD = (CDbl(TxtEnNum1.Text & TxtEnNum2.Text & TxtEnNum3.Text) Mod 7).ToString("0"c)
            'If CDbl(TxtEnNum1.Text & TxtEnNum2.Text & TxtEnNum3.Text) Mod 7 <> CDbl(TxtEnNum4.Text) Then
            If strCmpCD <> TxtEnNum4.Text Then
                'MsgBox("終了番号のＣＤに誤りがあります", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")
                MsgBox($"終了番号のＣＤは「{strCmpCD}」です", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")
                TxtEnNum4.Focus()
                Exit Sub
            End If

            If CDbl(TxtEnNum1.Text & TxtEnNum2.Text & TxtEnNum3.Text) < CDbl(TxtStNum1.Text & TxtStNum2.Text & TxtStNum3.Text) Then
                MsgBox("「開始番号」＜「終了番号」で入力して下さい", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")
                TxtStNum4.Focus()
                Exit Sub
            End If

            ' 重複チェック
            Dim strCmpStartNum(3) As Double
            Dim strCmpEndNum(3) As Double
            Dim strArray() As String
            ' 比較用配列にコピー
            For N = 0 To 2
                strArray = Split(PubConstClass.strStartNumber(N), ","c)
                strCmpStartNum(N) = CDbl(strArray(1).Replace("-", "").Substring(0, 10))
                strArray = Split(PubConstClass.strEndNumber(N), ","c)
                strCmpEndNum(N) = CDbl(strArray(1).Replace("-", "").Substring(0, 10))
            Next
            strCmpStartNum(CmbMasterItem.SelectedIndex) = CDbl(TxtStNum1.Text & TxtStNum2.Text & TxtStNum3.Text)
            strCmpEndNum(CmbMasterItem.SelectedIndex) = CDbl(TxtEnNum1.Text & TxtEnNum2.Text & TxtStNum3.Text)

            If strCmpStartNum(1) < strCmpStartNum(0) And strCmpStartNum(0) < strCmpEndNum(1) Then
                'strMessage = "開始番号「" & strCmpStartNum(0) & "」が「" & strCmpStartNum(1) & "～" & strCmpEndNum(1) & "」と重複しています"
                strMessage = strCmpStartNum(0).ToString("000-00-00000") & "が" & vbCr & _
                             strCmpStartNum(1).ToString("000-00-00000") & "～" & strCmpEndNum(1).ToString("000-00-00000") & vbCr & _
                             "と重複しています"
                MsgBox(strMessage, CType(MsgBoxStyle.YesNoCancel + MsgBoxStyle.OkOnly, MsgBoxStyle), "警告")
                Exit Sub
            End If

            If strCmpStartNum(1) < strCmpEndNum(0) And strCmpStartNum(0) < strCmpEndNum(1) Then

            End If



            Dim varRetResult As MsgBoxResult

            varRetResult = MsgBox("更新しますか？", CType(MsgBoxStyle.Question + MsgBoxStyle.OkCancel, MsgBoxStyle), "確認")
            If varRetResult = MsgBoxResult.Cancel Then
                ' キャンセル処理
                Exit Sub
            End If

            intArrayIndex = CmbMasterItem.SelectedIndex

            ' 引受番号帯コードと種別（表示用）
            PubConstClass.strNumberInfo(intArrayIndex) = CmbMasterItem.Text & "," & TxtClassName.Text
            ' 開始番号
            PubConstClass.strStartNumber(intArrayIndex) = "開始番号" & "," & TxtStNum1.Text & "-" & TxtStNum2.Text & "-" & TxtStNum3.Text & "-" & TxtStNum4.Text
            ' 終了番号
            PubConstClass.strEndNumber(intArrayIndex) = "終了番号" & "," & TxtEnNum1.Text & "-" & TxtEnNum2.Text & "-" & TxtEnNum3.Text & "-" & TxtEnNum4.Text
            ' 番号帯の中でのスタート番号
            PubConstClass.strCurrentNumber(intArrayIndex) = "スタート番号" & "," & TxtStNum1.Text & "-" & TxtStNum2.Text & "-" & TxtStNum3.Text & "-" & TxtStNum4.Text

            ' 書込ファイル名の設定
            Dim strOutPutFileName As String = IncludeTrailingPathDelimiter(Application.StartupPath) & PubConstClass.DEF_UNDER_WRITING_NUMBER

            ' 書込みファイルの削除
            'System.IO.File.Delete(strOutPutFileName)

            ' 引受番号帯コードと種別（表示用）
            WritePrivateProfileString("Class30", "ClassName", PubConstClass.strNumberInfo(0), strOutPutFileName)
            ' 開始番号
            WritePrivateProfileString("Class30", "StartNum", PubConstClass.strStartNumber(0), strOutPutFileName)
            ' 終了番号
            WritePrivateProfileString("Class30", "EndNum", PubConstClass.strEndNumber(0), strOutPutFileName)
            ' 番号帯の中でのスタート番号
            WritePrivateProfileString("Class30", "CurrentNum", PubConstClass.strCurrentNumber(0), strOutPutFileName)

            ' 引受番号帯コードと種別（表示用）
            WritePrivateProfileString("Class50", "ClassName", PubConstClass.strNumberInfo(1), strOutPutFileName)
            ' 開始番号
            WritePrivateProfileString("Class50", "StartNum", PubConstClass.strStartNumber(1), strOutPutFileName)
            ' 終了番号
            WritePrivateProfileString("Class50", "EndNum", PubConstClass.strEndNumber(1), strOutPutFileName)
            ' 番号帯の中でのスタート番号
            WritePrivateProfileString("Class50", "CurrentNum", PubConstClass.strCurrentNumber(1), strOutPutFileName)

            ' 引受番号帯コードと種別（表示用）
            WritePrivateProfileString("Class150", "ClassName", PubConstClass.strNumberInfo(2), strOutPutFileName)
            ' 開始番号
            WritePrivateProfileString("Class150", "StartNum", PubConstClass.strStartNumber(2), strOutPutFileName)
            ' 終了番号
            WritePrivateProfileString("Class150", "EndNum", PubConstClass.strEndNumber(2), strOutPutFileName)
            ' 番号帯の中でのスタート番号
            WritePrivateProfileString("Class150", "CurrentNum", PubConstClass.strCurrentNumber(2), strOutPutFileName)

            ' 引受番号帯コードと種別（表示用）
            WritePrivateProfileString("Class70", "ClassName", PubConstClass.strNumberInfo(3), strOutPutFileName)
            ' 開始番号
            WritePrivateProfileString("Class70", "StartNum", PubConstClass.strStartNumber(3), strOutPutFileName)
            ' 終了番号
            WritePrivateProfileString("Class70", "EndNum", PubConstClass.strEndNumber(3), strOutPutFileName)
            ' 番号帯の中でのスタート番号
            WritePrivateProfileString("Class70", "CurrentNum", PubConstClass.strCurrentNumber(3), strOutPutFileName)

            ' 引受番号データの再取得
            Call GetUnderWritingNumber()

        Catch ex As Exception
            MsgBox("【BtnUpdate_Click】" & ex.Message)
        End Try

    End Sub

    Private Sub BtnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSearch.Click

    End Sub


    Private Sub TxtStNum1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtStNum1.KeyPress
        ' 「BS」の場合はキャンセルしない
        If e.KeyChar = Constants.vbBack Then
            Exit Sub
        End If
        ' 押されたキーが「0～9」以外の場合は入力をキャンセルする
        If e.KeyChar < "0"c Or e.KeyChar > "9"c Then
            e.Handled = True
        End If
    End Sub

    Private Sub TxtStNum2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtStNum2.KeyPress
        ' 「BS」の場合はキャンセルしない
        If e.KeyChar = Constants.vbBack Then
            Exit Sub
        End If
        ' 押されたキーが「0～9」以外の場合は入力をキャンセルする
        If e.KeyChar < "0"c Or e.KeyChar > "9"c Then
            e.Handled = True
        End If
    End Sub

    Private Sub TxtStNum3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtStNum3.KeyPress
        ' 「BS」の場合はキャンセルしない
        If e.KeyChar = Constants.vbBack Then
            Exit Sub
        End If
        ' 押されたキーが「0～9」以外の場合は入力をキャンセルする
        If e.KeyChar < "0"c Or e.KeyChar > "9"c Then
            e.Handled = True
        End If
    End Sub

    Private Sub TxtStNum4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtStNum4.KeyPress
        ' 「BS」の場合はキャンセルしない
        If e.KeyChar = Constants.vbBack Then
            Exit Sub
        End If
        ' 押されたキーが「0～9」以外の場合は入力をキャンセルする
        If e.KeyChar < "0"c Or e.KeyChar > "9"c Then
            e.Handled = True
        End If
    End Sub

    Private Sub TxtEnNum1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtEnNum1.KeyPress
        ' 「BS」の場合はキャンセルしない
        If e.KeyChar = Constants.vbBack Then
            Exit Sub
        End If
        ' 押されたキーが「0～9」以外の場合は入力をキャンセルする
        If e.KeyChar < "0"c Or e.KeyChar > "9"c Then
            e.Handled = True
        End If
    End Sub

    Private Sub TxtEnNum2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtEnNum2.KeyPress
        ' 「BS」の場合はキャンセルしない
        If e.KeyChar = Constants.vbBack Then
            Exit Sub
        End If
        ' 押されたキーが「0～9」以外の場合は入力をキャンセルする
        If e.KeyChar < "0"c Or e.KeyChar > "9"c Then
            e.Handled = True
        End If
    End Sub

    Private Sub TxtEnNum3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtEnNum3.KeyPress
        ' 「BS」の場合はキャンセルしない
        If e.KeyChar = Constants.vbBack Then
            Exit Sub
        End If
        ' 押されたキーが「0～9」以外の場合は入力をキャンセルする
        If e.KeyChar < "0"c Or e.KeyChar > "9"c Then
            e.Handled = True
        End If
    End Sub

    Private Sub TxtEnNum4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtEnNum4.KeyPress
        ' 「BS」の場合はキャンセルしない
        If e.KeyChar = Constants.vbBack Then
            Exit Sub
        End If
        ' 押されたキーが「0～9」以外の場合は入力をキャンセルする
        If e.KeyChar < "0"c Or e.KeyChar > "9"c Then
            e.Handled = True
        End If
    End Sub

    Private Sub TxtStNum1_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtStNum1.TextChanged

    End Sub
End Class