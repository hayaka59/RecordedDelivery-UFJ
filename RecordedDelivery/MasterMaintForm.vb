Option Explicit On
Option Strict On

Public Class MasterMaintForm

    ''' <summary>
    ''' フォームアクティブ処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MasterMaintForm_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated

        ' オペレータ情報の表示
        LblOperatorName.Text = GetOperatorInfomation()

    End Sub

    ''' <summary>
    ''' 「×」ボタンのキャンセル
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MasterMaintForm_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        ' 「×」ボタンのキャンセル
        e.Cancel = True

    End Sub

    ''' <summary>
    ''' フォームロード処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MasterMaintForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load


    End Sub

    ''' <summary>
    ''' 「オペレータ 登録・変更」ボタン処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnOperatorEntry_Click(sender As System.Object, e As System.EventArgs) Handles BtnOperatorEntry.Click

        OutPutLogFile("〓「オペレータ 登録・変更画面」呼び出し〓")
        OperatorEntryForm.ShowDialog()

    End Sub

    ''' <summary>
    ''' 「戻る」ボタン処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnBack_Click(sender As System.Object, e As System.EventArgs) Handles BtnBack.Click

        Try
            MsgBoxForm.strMessage = "メインメニューに戻りますか？"
            ' 確認メッセージの表示
            MsgBoxForm.ShowDialog()

            If MsgBoxForm.blnRetValMsgBox = True Then
                OutPutLogFile("〓「メインメニューに戻る」呼び出し〓")
                MainForm.Show()
                Me.Hide()
            End If

        Catch ex As Exception
            MsgBox("【BtnBack_Click】" & ex.Message)
        End Try


    End Sub

    ''' <summary>
    ''' 「業務登録」ボタン処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnJobEntry_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnJobEntry.Click

        OutPutLogFile("〓「業務登録画面」呼び出し〓")
        JobEntryForm.Show()
        Me.Hide()

    End Sub

    ''' <summary>
    ''' 「支店コード登録・変更」ボタン処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnEntrySiten_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEntrySiten.Click

        OutPutLogFile("〓「支店コード登録・変更画面」呼び出し〓")
        EntrySitenCodeForm.ShowDialog()

    End Sub

    ''' <summary>
    ''' 「引受番号管理」ボタン処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnMngNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMngNumber.Click

        OutPutLogFile("〓「引受番号管理画面」呼び出し〓")
        MngNumberForm.ShowDialog()

    End Sub

    ''' <summary>
    ''' 「種別マスタ登録・変更」ボタン処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnClassMasterEntry_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClassMasterEntry.Click

        OutPutLogFile("〓「種別マスタ登録・変更画面」呼び出し〓")
        ClassMasterForm.ShowDialog()

    End Sub

    ''' <summary>
    ''' 「マスタ一覧出力」ボタン処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnMasterList_Click(sender As System.Object, e As System.EventArgs) Handles BtnMasterList.Click

        OutPutLogFile("〓「マスタ一覧出力画面」呼び出し〓")
        MasterListOutPutForm.ShowDialog()

    End Sub

End Class