Option Explicit On
Option Strict On

Public Class logManageForm

    ' 「戻る(F12)」ボタンの処理
    Private Sub btnBack_Click(sender As System.Object, e As System.EventArgs) Handles btnBack.Click

        With MsgBoxForm
            .strMessage = "メインメニュー画面に戻りますか？"
            .ShowDialog()
            If MsgBoxForm.blnRetValMsgBox = True Then

                ' メインメニュー画面の表示
                MainForm.Show()
                .Dispose()
                Me.Dispose()

            Else
                .Dispose()
            End If
        End With

    End Sub

    Private Sub logManageForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        ' ListViewのカラムヘッダー設定
        lstGetDataView.View = View.Details
        Dim col1 As ColumnHeader = New ColumnHeader
        Dim col2 As ColumnHeader = New ColumnHeader
        Dim col3 As ColumnHeader = New ColumnHeader
        Dim col4 As ColumnHeader = New ColumnHeader
        Dim col5 As ColumnHeader = New ColumnHeader

        col1.Text = "No"
        col2.Text = "取得時間"
        col3.Text = "判定"
        col4.Text = "引受番号"
        col5.Text = "ファイル名称"

        col1.Width = 80
        col2.Width = 250
        col3.Width = 70
        col4.Width = 200
        col5.Width = 700

        Dim colHeader() As ColumnHeader = {col1, col2, col3, col4, col5}
        lstGetDataView.Columns.AddRange(colHeader)

    End Sub

End Class