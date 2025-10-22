Public Class ErrorForm

    ''' <summary>
    ''' エラーフォームのロード処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub errorForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim intLoopCnt As Integer
        Dim strWork() As String

        Try

            lblErrorTitle.Text = "未定義タイトル"
            lblErrorMsg.Text = "未定義エラー"

            ' 動作不可コマンド送信
            Call DrivingForm.sendCommand(PubConstClass.CMD_DISABLE & vbCr)

            For intLoopCnt = 0 To PubConstClass.intErrCnt - 1
                strWork = PubConstClass.strErrArray(intLoopCnt).Split(","c)
                If PubConstClass.strErrorNo = strWork(0) Then
                    lblErrorTitle.Text = strWork(1)
                    lblErrorMsg.Text = strWork(2)
                    Exit For
                End If
            Next

        Catch ex As Exception
            MsgBox("【errorForm_Load】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 「ＯＫ」ボタン処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

        '' 動作可能コマンド送信
        'Call DrivingForm.sendCommand(PubConstClass.CMD_ENABLE & vbCr)

        ' 呼び出し元のフォームをイネーブルにする
        DrivingForm.Enabled = True

        PubConstClass.blnResetFlg = True
        Me.Dispose()

    End Sub
End Class