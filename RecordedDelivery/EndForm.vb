Option Explicit On
Option Strict On

Public Class EndForm

    Private Sub endForm_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated

        btnCancel.Select()

    End Sub

    ''' <summary>
    ''' 「×」ボタンのキャンセル
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub endForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        ' 「×」ボタンのキャンセル
        e.Cancel = True

    End Sub

    ''' <summary>
    ''' フォームロード処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub endForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        lblMessage.Text = "終了してもよろしいですか？"

    End Sub

    ''' <summary>
    ''' 「終了実行」ボタン処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnEnd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnd.Click

        'Dim strIniFilePath As String

        Try
            '' 各カウンタをINIファイルに書き込む
            'strIniFilePath = IncludeTrailingPathDelimiter(Application.StartupPath) & PubConstClass.DEF_INI_FILENAME
            'WritePrivateProfileString("Counter", "WorkDay", Date.Now.ToString("yyyyMMdd"), strIniFilePath)
            'WritePrivateProfileString("Counter", "TodayAllCount", PubConstClass.intTodayALLCount.ToString("0"), strIniFilePath)
            'WritePrivateProfileString("Counter", "KaniALLCount", PubConstClass.intKaniALLCount.ToString("0"), strIniFilePath)
            'WritePrivateProfileString("Counter", "TokuALLCount", PubConstClass.intTokuALLCount.ToString("0"), strIniFilePath)
            'WritePrivateProfileString("Counter", "MailALLCount", PubConstClass.intMailALLCount.ToString("0"), strIniFilePath)

            Call OutPutLogFile("簡易書留処理アプリを終了します")
            MainForm.blnEndFlag = True
            Me.Dispose()

        Catch ex As Exception
            MsgBox("【btnEnd_Click】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 「キャンセル」ボタン処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Call OutPutLogFile("アプリ終了処理をキャンセルしました")
        MainForm.blnEndFlag = False
        Me.Dispose()

    End Sub

End Class