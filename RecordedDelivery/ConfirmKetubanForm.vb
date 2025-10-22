Option Explicit On
Option Strict On

Public Class ConfirmKetubanForm

    Private intPageIndex As Integer         ' 頁インデックス
    Private intNextPrintDtIndex As Integer  ' 次のプリントデータのインデックス 

    Private ar30NukiTori As New ArrayList   ' 抜取データ格納アレイリスト（簡易書留）
    Private ar50NukiTori As New ArrayList   ' 抜取データ格納アレイリスト（特定記録）
    Private ar150NukiTori As New ArrayList  ' 抜取データ格納アレイリスト（ゆうメール）

    Private ar30Class As New ArrayList
    Private ar50Class As New ArrayList
    Private ar150Class As New ArrayList
    Private arMissing As ArrayList = New ArrayList

    Private ar30ClassFirstHalf As New ArrayList
    Private ar50ClassFirstHalf As New ArrayList
    Private ar150ClassFirstHalf As New ArrayList
    Private ar30ClassSecondHalf As New ArrayList
    Private ar50ClassSecondHalf As New ArrayList
    Private ar150ClassSecondHalf As New ArrayList
    Private blnIs30FirstAndSecond As Boolean
    Private blnIs50FirstAndSecond As Boolean
    Private blnIs150FirstAndSecond As Boolean
    Private lng30FirstAndSecondCnt As Long
    Private lng50FirstAndSecondCnt As Long
    Private lng150FirstAndSecondCnt As Long

    Private strClassName As String          ' タイトルの種別を格納する
    Private strSArray(10) As String         ' 開始引受番号を格納する
    Private strEArray(10) As String         ' 終了引受番号を格納する
    Private strNumCount(4) As String        ' 引受番号の通数

    ''' <summary>
    ''' フォームアクティブ処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ConfirmKetubanForm_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated

        LblOperatorName.Text = GetOperatorInfomation()

    End Sub

    ''' <summary>
    ''' フォームロード処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ConfirmKetubanForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try

            ' 現在の年月日を取得する
            lblCurrentDate.Text = GetCurrentDate()

            ' 画面の初期化
            Call InitDisplayData()

        Catch ex As Exception
            MsgBox("【ConfirmKetubanForm_Load】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    '''  画面の初期化
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub InitDisplayData()

        Try
            lblKakiAcNumS1.Text = ""
            lblKakiAcNumS2.Text = ""
            lblKakiAcNumS3.Text = ""
            lblKakiAcNumS4.Text = ""

            lblKakiAcNumE1.Text = ""
            lblKakiAcNumE2.Text = ""
            lblKakiAcNumE3.Text = ""
            lblKakiAcNumE4.Text = ""

            lblYumeAcNumS1.Text = ""
            lblYumeAcNumS2.Text = ""
            lblYumeAcNumS3.Text = ""
            lblYumeAcNumS4.Text = ""

            lblYumeAcNumE1.Text = ""
            lblYumeAcNumE2.Text = ""
            lblYumeAcNumE3.Text = ""
            lblYumeAcNumE4.Text = ""

            lblTokuAcNumS1.Text = ""
            lblTokuAcNumS2.Text = ""
            lblTokuAcNumS3.Text = ""
            lblTokuAcNumS4.Text = ""

            lblTokuAcNumE1.Text = ""
            lblTokuAcNumE2.Text = ""
            lblTokuAcNumE3.Text = ""
            lblTokuAcNumE4.Text = ""

        Catch ex As Exception
            MsgBox("【InitDisplayData】" & ex.Message)
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
    ''' 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function Set30MissingAndNukitori() As Boolean

        Dim RetValMsgResult As MsgBoxResult
        Set30MissingAndNukitori = True

        Try
            If lblKakiAcNumS1.Text = "" Or lblKakiAcNumS2.Text = "" Or _
                lblKakiAcNumS3.Text = "" Or lblKakiAcNumS4.Text = "" Then
                MsgBox("簡易郵便引受番号の開始番号を確認して下さい", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")
                Return False
            End If
            If lblKakiAcNumE1.Text = "" Or lblKakiAcNumE2.Text = "" Or _
                lblKakiAcNumE3.Text = "" Or lblKakiAcNumE4.Text = "" Then
                MsgBox("簡易郵便引受番号の終了番号を確認して下さい", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")
                Return False
            End If
            ' タイトルの種別設定
            strClassName = "簡易書留郵便物"
            ' 開始番号の設定
            strSArray(0) = lblKakiAcNumS1.Text.Substring(0, 1)
            strSArray(1) = lblKakiAcNumS1.Text.Substring(1, 1)
            strSArray(2) = lblKakiAcNumS1.Text.Substring(2, 1)
            strSArray(3) = lblKakiAcNumS2.Text.Substring(0, 1)
            strSArray(4) = lblKakiAcNumS2.Text.Substring(1, 1)
            strSArray(5) = lblKakiAcNumS3.Text.Substring(0, 1)
            strSArray(6) = lblKakiAcNumS3.Text.Substring(1, 1)
            strSArray(7) = lblKakiAcNumS3.Text.Substring(2, 1)
            strSArray(8) = lblKakiAcNumS3.Text.Substring(3, 1)
            strSArray(9) = lblKakiAcNumS3.Text.Substring(4, 1)
            strSArray(10) = lblKakiAcNumS4.Text
            ' 終了番号の設定
            strEArray(0) = lblKakiAcNumE1.Text.Substring(0, 1)
            strEArray(1) = lblKakiAcNumE1.Text.Substring(1, 1)
            strEArray(2) = lblKakiAcNumE1.Text.Substring(2, 1)
            strEArray(3) = lblKakiAcNumE2.Text.Substring(0, 1)
            strEArray(4) = lblKakiAcNumE2.Text.Substring(1, 1)
            strEArray(5) = lblKakiAcNumE3.Text.Substring(0, 1)
            strEArray(6) = lblKakiAcNumE3.Text.Substring(1, 1)
            strEArray(7) = lblKakiAcNumE3.Text.Substring(2, 1)
            strEArray(8) = lblKakiAcNumE3.Text.Substring(3, 1)
            strEArray(9) = lblKakiAcNumE3.Text.Substring(4, 1)
            strEArray(10) = lblKakiAcNumE4.Text

            arMissing.Clear()
            If blnIs30FirstAndSecond = True Then
                ' 欠番確認表を２部に分けて印字する
                GetMissingNumber(ar30ClassSecondHalf, arMissing)
                GetMissingNumber(ar30ClassFirstHalf, arMissing)
            Else
                GetMissingNumber(ar30Class, arMissing)
            End If

            If arMissing.Count - 1 > 1000 Then
                RetValMsgResult = MsgBox("簡易書留郵便物の欠番の引受番号が、" & arMissing.Count - 1 & "件 あります。印字しますか？", _
                                         CType(MsgBoxStyle.Exclamation + MsgBoxStyle.OkCancel, MsgBoxStyle), "【確認】")
                If RetValMsgResult = MsgBoxResult.Cancel Then
                    Return False
                End If
            End If

            If arMissing.Count = 0 And ar30NukiTori.Count = 0 Then
                MsgBox("簡易書留郵便物の欠番の引受番号はありません", CType(MsgBoxStyle.Information + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")
            Else
                For N = 0 To arMissing.Count - 1
                    OutPutLogFile("■欠番（簡易書留）の引受番号：" & arMissing(N).ToString)
                Next
                For N = 0 To ar30NukiTori.Count - 1
                    arMissing.Add(ar30NukiTori(N).ToString & ",■")
                    OutPutLogFile("■抜取（簡易書留）の引受番号：" & ar30NukiTori(N).ToString)
                Next
            End If

        Catch ex As Exception
            MsgBox("【Set30MissingAndNukitori】" & ex.Message)
        End Try

    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function Set50MissingAndNukitori() As Boolean

        Dim RetValMsgResult As MsgBoxResult
        Set50MissingAndNukitori = True

        Try
            If lblTokuAcNumS1.Text = "" Or lblTokuAcNumS2.Text = "" Or _
                lblTokuAcNumS3.Text = "" Or lblTokuAcNumS4.Text = "" Then
                MsgBox("特定記録引受番号の開始番号を確認して下さい", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")
                Return False
            End If
            If lblTokuAcNumE1.Text = "" Or lblTokuAcNumE2.Text = "" Or _
                lblTokuAcNumE3.Text = "" Or lblTokuAcNumE4.Text = "" Then
                MsgBox("特定記録引受番号の終了番号を確認して下さい", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")
                Return False
            End If
            ' タイトルの種別設定
            strClassName = "特定記録郵便物"
            ' 開始番号の設定
            strSArray(0) = lblTokuAcNumS1.Text.Substring(0, 1)
            strSArray(1) = lblTokuAcNumS1.Text.Substring(1, 1)
            strSArray(2) = lblTokuAcNumS1.Text.Substring(2, 1)
            strSArray(3) = lblTokuAcNumS2.Text.Substring(0, 1)
            strSArray(4) = lblTokuAcNumS2.Text.Substring(1, 1)
            strSArray(5) = lblTokuAcNumS3.Text.Substring(0, 1)
            strSArray(6) = lblTokuAcNumS3.Text.Substring(1, 1)
            strSArray(7) = lblTokuAcNumS3.Text.Substring(2, 1)
            strSArray(8) = lblTokuAcNumS3.Text.Substring(3, 1)
            strSArray(9) = lblTokuAcNumS3.Text.Substring(4, 1)
            strSArray(10) = lblTokuAcNumS4.Text
            ' 終了番号の設定
            strEArray(0) = lblTokuAcNumE1.Text.Substring(0, 1)
            strEArray(1) = lblTokuAcNumE1.Text.Substring(1, 1)
            strEArray(2) = lblTokuAcNumE1.Text.Substring(2, 1)
            strEArray(3) = lblTokuAcNumE2.Text.Substring(0, 1)
            strEArray(4) = lblTokuAcNumE2.Text.Substring(1, 1)
            strEArray(5) = lblTokuAcNumE3.Text.Substring(0, 1)
            strEArray(6) = lblTokuAcNumE3.Text.Substring(1, 1)
            strEArray(7) = lblTokuAcNumE3.Text.Substring(2, 1)
            strEArray(8) = lblTokuAcNumE3.Text.Substring(3, 1)
            strEArray(9) = lblTokuAcNumE3.Text.Substring(4, 1)
            strEArray(10) = lblTokuAcNumE4.Text

            arMissing.Clear()
            If blnIs50FirstAndSecond = True Then
                ' 欠番確認表を２部に分けて印字する
                GetMissingNumber(ar50ClassSecondHalf, arMissing)
                GetMissingNumber(ar50ClassFirstHalf, arMissing)
            Else
                GetMissingNumber(ar50Class, arMissing)
            End If

            If arMissing.Count - 1 > 1000 Then
                RetValMsgResult = MsgBox("特定記録郵便物の欠番の引受番号が、" & arMissing.Count - 1 & "件 あります。印字しますか？", _
                                         CType(MsgBoxStyle.Exclamation + MsgBoxStyle.OkCancel, MsgBoxStyle), "【確認】")
                If RetValMsgResult = MsgBoxResult.Cancel Then
                    Return False
                End If
            End If

            If arMissing.Count = 0 And ar50NukiTori.Count = 0 Then
                MsgBox("特定記録郵便物の欠番の引受番号はありません", CType(MsgBoxStyle.Information + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")
            Else
                For N = 0 To arMissing.Count - 1
                    OutPutLogFile("■欠番（特定記録）の引受番号：" & arMissing(N).ToString)
                Next
                For N = 0 To ar50NukiTori.Count - 1
                    arMissing.Add(ar50NukiTori(N).ToString & ",■")
                    OutPutLogFile("■抜取（特定記録）の引受番号：" & ar50NukiTori(N).ToString)
                Next
            End If

        Catch ex As Exception
            MsgBox("【Set50MissingAndNukitori】" & ex.Message)
        End Try

    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function Set150MissingAndNukitori() As Boolean

        Dim RetValMsgResult As MsgBoxResult
        Set150MissingAndNukitori = True

        Try
            If lblYumeAcNumS1.Text = "" Or lblYumeAcNumS2.Text = "" Or _
                lblYumeAcNumS3.Text = "" Or lblYumeAcNumS4.Text = "" Then
                MsgBox("ゆうメール引受番号の開始番号を確認して下さい", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")
                Return False
            End If
            If lblYumeAcNumE1.Text = "" Or lblYumeAcNumE2.Text = "" Or _
                lblYumeAcNumE3.Text = "" Or lblYumeAcNumE4.Text = "" Then
                MsgBox("ゆうメール引受番号の終了番号を確認して下さい", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")
                Return False
            End If
            ' タイトルの種別設定
            strClassName = "ゆうメール"
            ' 開始番号の設定
            strSArray(0) = lblYumeAcNumS1.Text.Substring(0, 1)
            strSArray(1) = lblYumeAcNumS1.Text.Substring(1, 1)
            strSArray(2) = lblYumeAcNumS1.Text.Substring(2, 1)
            strSArray(3) = lblYumeAcNumS2.Text.Substring(0, 1)
            strSArray(4) = lblYumeAcNumS2.Text.Substring(1, 1)
            strSArray(5) = lblYumeAcNumS3.Text.Substring(0, 1)
            strSArray(6) = lblYumeAcNumS3.Text.Substring(1, 1)
            strSArray(7) = lblYumeAcNumS3.Text.Substring(2, 1)
            strSArray(8) = lblYumeAcNumS3.Text.Substring(3, 1)
            strSArray(9) = lblYumeAcNumS3.Text.Substring(4, 1)
            strSArray(10) = lblYumeAcNumS4.Text
            ' 終了番号の設定
            strEArray(0) = lblYumeAcNumE1.Text.Substring(0, 1)
            strEArray(1) = lblYumeAcNumE1.Text.Substring(1, 1)
            strEArray(2) = lblYumeAcNumE1.Text.Substring(2, 1)
            strEArray(3) = lblYumeAcNumE2.Text.Substring(0, 1)
            strEArray(4) = lblYumeAcNumE2.Text.Substring(1, 1)
            strEArray(5) = lblYumeAcNumE3.Text.Substring(0, 1)
            strEArray(6) = lblYumeAcNumE3.Text.Substring(1, 1)
            strEArray(7) = lblYumeAcNumE3.Text.Substring(2, 1)
            strEArray(8) = lblYumeAcNumE3.Text.Substring(3, 1)
            strEArray(9) = lblYumeAcNumE3.Text.Substring(4, 1)
            strEArray(10) = lblYumeAcNumE4.Text

            arMissing.Clear()
            ' 連続した引受番号の欠番を求める
            If blnIs150FirstAndSecond = True Then
                GetMissingNumber(ar150ClassSecondHalf, arMissing)
                GetMissingNumber(ar150ClassFirstHalf, arMissing)
            Else
                GetMissingNumber(ar150Class, arMissing)
            End If

            If arMissing.Count - 1 > 1000 Then
                RetValMsgResult = MsgBox("ゆうメールの欠番の引受番号が、" & arMissing.Count - 1 & "件 あります。印字しますか？", _
                                         CType(MsgBoxStyle.Exclamation + MsgBoxStyle.OkCancel, MsgBoxStyle), "【確認】")
                If RetValMsgResult = MsgBoxResult.Cancel Then
                    Return False
                End If
            End If

            If arMissing.Count = 0 And ar150NukiTori.Count = 0 Then
                MsgBox("ゆうメールの欠番の引受番号はありません", CType(MsgBoxStyle.Information + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")                
            Else
                For N = 0 To arMissing.Count - 1
                    OutPutLogFile("■欠番（ゆうメール）の引受番号：" & arMissing(N).ToString)
                Next
                For N = 0 To ar150NukiTori.Count - 1                    
                    arMissing.Add(ar150NukiTori(N).ToString & ",■")
                    OutPutLogFile("■抜取（ゆうメール）の引受番号：" & ar150NukiTori(N).ToString)
                Next
            End If

        Catch ex As Exception
            MsgBox("【Set150MissingAndNukitori】" & ex.Message)
        End Try

    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Get30MissingAndNukitoriForOneRound()

        Try
            GetStartUnderWritingNumber("30：簡易書留")
            arMissing.Clear()
            ' 第一部の欠番を求める
            GetMissingNumberForRound("1", ar30ClassSecondHalf, arMissing)

            ' 開始番号の設定
            Dim strWorkStart As String = ar30ClassSecondHalf(0).ToString.Replace("-", "")
            For N = 0 To 10
                strSArray(N) = strWorkStart.Substring(N, 1)
            Next

            ' 終了番号の設定
            Dim strArray() As String = PubConstClass.strEndNumber(0).Split(","c)
            Dim strWorkEnd As String = strArray(1).Replace("-", "")
            For N = 0 To 10
                strEArray(N) = strWorkEnd.Substring(N, 1)
            Next

            ' 引受番号の通数の設定
            Dim lngTusu As Long
            lngTusu = CLng(strWorkEnd.Substring(0, 10)) - CLng(strWorkStart.Substring(0, 10)) + 1
            For N = 0 To 3
                strNumCount(N) = lngTusu.ToString("0000").Substring(N, 1)
            Next

        Catch ex As Exception
            MsgBox("【Get30MissingAndNukitoriForOneRound】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Get50MissingAndNukitoriForOneRound()

        Try
            GetStartUnderWritingNumber("50：特定記録")
            arMissing.Clear()
            ' 第一部の欠番を求める
            GetMissingNumberForRound("1", ar50ClassSecondHalf, arMissing)

            ' 開始番号の設定
            Dim strWorkStart As String = ar50ClassSecondHalf(0).ToString.Replace("-", "")
            For N = 0 To 10
                strSArray(N) = strWorkStart.Substring(N, 1)
            Next

            ' 終了番号の設定
            Dim strArray() As String = PubConstClass.strEndNumber(1).Split(","c)
            Dim strWorkEnd As String = strArray(1).Replace("-", "")
            For N = 0 To 10
                strEArray(N) = strWorkEnd.Substring(N, 1)
            Next

            ' 引受番号の通数の設定
            Dim lngTusu As Long
            lngTusu = CLng(strWorkEnd.Substring(0, 10)) - CLng(strWorkStart.Substring(0, 10)) + 1
            For N = 0 To 3
                strNumCount(N) = lngTusu.ToString("0000").Substring(N, 1)
            Next

        Catch ex As Exception
            MsgBox("【Get50MissingAndNukitoriForOneRound】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Get150MissingAndNukitoriForOneRound()

        Try
            GetStartUnderWritingNumber("150：ゆうメール")
            arMissing.Clear()
            ' 第一部の欠番を求める
            GetMissingNumberForRound("1", ar150ClassSecondHalf, arMissing)

            ' 開始番号の設定
            Dim strWorkStart As String = ar150ClassSecondHalf(0).ToString.Replace("-", "")
            For N = 0 To 10
                strSArray(N) = strWorkStart.Substring(N, 1)
            Next

            ' 終了番号の設定
            Dim strArray() As String = PubConstClass.strEndNumber(2).Split(","c)
            Dim strWorkEnd As String = strArray(1).Replace("-", "")
            For N = 0 To 10
                strEArray(N) = strWorkEnd.Substring(N, 1)
            Next

            ' 引受番号の通数の設定
            Dim lngTusu As Long
            lngTusu = CLng(strWorkEnd.Substring(0, 10)) - CLng(strWorkStart.Substring(0, 10)) + 1
            For N = 0 To 3
                strNumCount(N) = lngTusu.ToString("0000").Substring(N, 1)
            Next

        Catch ex As Exception
            MsgBox("【Get150MissingAndNukitoriForOneRound】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Get30MissingAndNukitoriForTwoRound()

        Try
            arMissing.Clear()
            ' 第二部の欠番を求める
            GetMissingNumberForRound("0", ar30ClassFirstHalf, arMissing)

            ' 開始番号の設定
            Dim strArray() As String = PubConstClass.strStartNumber(0).Split(","c)
            Dim strWorkStart As String = strArray(1).Replace("-", "")
            For N = 0 To 10
                strSArray(N) = strWorkStart.Substring(N, 1)
            Next

            ' 終了番号の設定
            Dim strWorkEnd As String = ar30ClassFirstHalf(ar30ClassFirstHalf.Count - 1).ToString.Replace("-", "")
            For N = 0 To 10
                strEArray(N) = strWorkEnd.Substring(N, 1)
            Next

            ' 引受番号の通数
            Dim lngTusu As Long
            lngTusu = CLng(strWorkEnd.Substring(0, 10)) - CLng(strWorkStart.Substring(0, 10)) + 1
            For N = 0 To 3
                strNumCount(N) = lngTusu.ToString("0000").Substring(N, 1)
            Next

        Catch ex As Exception
            MsgBox("【Get30MissingAndNukitoriForTwoRound】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Get50MissingAndNukitoriForTwoRound()

        Try
            arMissing.Clear()
            ' 第二部の欠番を求める
            GetMissingNumberForRound("0", ar50ClassFirstHalf, arMissing)

            ' 開始番号の設定
            Dim strArray() As String = PubConstClass.strStartNumber(1).Split(","c)
            Dim strWorkStart As String = strArray(1).Replace("-", "")
            For N = 0 To 10
                strSArray(N) = strWorkStart.Substring(N, 1)
            Next

            ' 終了番号の設定
            Dim strWorkEnd As String = ar50ClassFirstHalf(ar50ClassFirstHalf.Count - 1).ToString.Replace("-", "")
            For N = 0 To 10
                strEArray(N) = strWorkEnd.Substring(N, 1)
            Next

            ' 引受番号の通数
            Dim lngTusu As Long
            lngTusu = CLng(strWorkEnd.Substring(0, 10)) - CLng(strWorkStart.Substring(0, 10)) + 1
            For N = 0 To 3
                strNumCount(N) = lngTusu.ToString("0000").Substring(N, 1)
            Next

        Catch ex As Exception
            MsgBox("【Get50MissingAndNukitoriForTwoRound】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Get150MissingAndNukitoriForTwoRound()

        Try
            arMissing.Clear()
            ' 第二部の欠番を求める
            GetMissingNumberForRound("0", ar150ClassFirstHalf, arMissing)

            ' 開始番号の設定
            Dim strArray() As String = PubConstClass.strStartNumber(2).Split(","c)
            Dim strWorkStart As String = strArray(1).Replace("-", "")
            For N = 0 To 10
                strSArray(N) = strWorkStart.Substring(N, 1)
            Next

            ' 終了番号の設定
            Dim strWorkEnd As String = ar150ClassFirstHalf(ar150ClassFirstHalf.Count - 1).ToString.Replace("-", "")
            For N = 0 To 10
                strEArray(N) = strWorkEnd.Substring(N, 1)
            Next

            ' 引受番号の通数
            Dim lngTusu As Long
            lngTusu = CLng(strWorkEnd.Substring(0, 10)) - CLng(strWorkStart.Substring(0, 10)) + 1
            For N = 0 To 3
                strNumCount(N) = lngTusu.ToString("0000").Substring(N, 1)
            Next

        Catch ex As Exception
            MsgBox("【Get150MissingAndNukitoriForTwoRound】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 「印刷」ボタン処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click

        Try
            If RdoKakitome.Checked = True Then
                ' 書留郵便引受番号の番号帯のラジオボタンチェック処理
                If Set30MissingAndNukitori() = False Then
                    Exit Sub
                End If
            ElseIf RdoTokutei.Checked = True Then
                ' 特定記録引受番号の番号帯のラジオボタンチェック処理
                If Set50MissingAndNukitori() = False Then
                    Exit Sub
                End If
            ElseIf RdoYuMail.Checked = True Then
                ' ゆうメール引受番号の番号帯のラジオボタンチェック処理
                If Set150MissingAndNukitori() = False Then
                    Exit Sub
                End If
            Else
                Exit Sub
            End If

            ' 通数の計算
            Dim strStartNum As String = "0"     ' 開始引受番号
            Dim strEndNum As String = "0"       ' 終了引受番号
            For N = 0 To 9
                strStartNum = strStartNum & strSArray(N)
                strEndNum = strEndNum & strEArray(N)
            Next

            Dim lngTusu As Long
            lngTusu = CLng(strEndNum) - CLng(strStartNum) + 1

            If blnIs30FirstAndSecond = True Then
                If RdoKakitome.Checked = True Then
                    lngTusu = lng30FirstAndSecondCnt
                End If
            End If
            If blnIs50FirstAndSecond = True Then
                If RdoTokutei.Checked = True Then
                    lngTusu = lng50FirstAndSecondCnt
                End If
            End If
            If blnIs150FirstAndSecond = True Then
                If RdoYuMail.Checked = True Then
                    lngTusu = lng150FirstAndSecondCnt
                End If
            End If

            For N = 0 To 3
                strNumCount(N) = lngTusu.ToString("0000").Substring(N, 1)
            Next

            Dim varRetval As MsgBoxResult
            varRetval = MsgBox("欠番確認表の内容を確認しますか？", CType(MsgBoxStyle.Question + MsgBoxStyle.OkCancel, MsgBoxStyle), "確認")
            If varRetval = MsgBoxResult.Cancel Then
                Exit Sub
            End If

            ' 第一部の印刷
            For N = 0 To arMissing.Count - 1
                OutPutLogFile("【arMissing(N)】" & arMissing(N).ToString)
            Next

            If blnIs30FirstAndSecond = True And RdoKakitome.Checked = True Then
                MsgBox("簡易書留の開始引受番号からの欠番確認表を印刷します", CType(MsgBoxStyle.Information + MsgBoxStyle.OkCancel, MsgBoxStyle), "確認")
                ' 簡易書留の引受番号
                Get30MissingAndNukitoriForOneRound()
            End If
            If blnIs50FirstAndSecond = True And RdoTokutei.Checked = True Then
                MsgBox("特定記録の開始引受番号からの欠番確認表を印刷します", CType(MsgBoxStyle.Information + MsgBoxStyle.OkCancel, MsgBoxStyle), "確認")
                ' 特定記録の引受番号
                Get50MissingAndNukitoriForOneRound()
            End If
            If blnIs150FirstAndSecond = True And RdoYuMail.Checked = True Then
                MsgBox("ゆうメールの開始引受番号からの欠番確認表を印刷します", CType(MsgBoxStyle.Information + MsgBoxStyle.OkCancel, MsgBoxStyle), "確認")
                ' ゆうメールの引受番号
                Get150MissingAndNukitoriForOneRound()
            End If

            'PrintDocumentオブジェクトの作成
            Dim pd As New System.Drawing.Printing.PrintDocument
            'PrintPageイベントハンドラの追加
            AddHandler pd.PrintPage, AddressOf PrintDocument1_PrintPage

            ' 欠番データの個数を取得
            intImageDataCount = arMissing.Count
            ' 印字ページインデックスの初期化
            intPrintImageIndex = 0

            ' PrintPreviewDialogオブジェクトの作成
            Dim ppd As New PrintPreviewDialog
            ppd.Width = 1200
            ppd.Height = 1000
            ' プレビューオブジェクトの「印刷」ボタン削除
            Dim tool As ToolStrip = CType(ppd.Controls(1), ToolStrip)
            tool.Items.RemoveAt(0)
            ' プレビューするPrintDocumentを設定
            ppd.Document = pd
            ' 印刷プレビューダイアログを表示する
            ppd.ShowDialog()
            '// 2016.01.25 Ver.B06 hayakawa 修正↓ここから
            ' PrintPreviewDialogオブジェクトの解放
            ppd.Dispose()
            '// 2016.01.25 Ver.B06 hayakawa 修正↑ここまで

            Dim retVal As MsgBoxResult = MsgBox("欠番確認表を印刷しますか？", CType(MsgBoxStyle.Question + MsgBoxStyle.OkCancel, MsgBoxStyle), "確認")
            If retVal = MsgBoxResult.Cancel Then
                ' キャンセル
                Exit Sub
            End If

            ' 欠番データの個数を取得
            intImageDataCount = arMissing.Count
            ' 印字ページインデックスの初期化
            intPrintImageIndex = 0
            pd.DocumentName = "欠番確認表の印刷"
            ' 印刷処理
            pd.Print()
            '// 2016.01.25 Ver.B06 hayakawa 修正↓ここから
            ' PrintDocumentオブジェクトの解放
            pd.Dispose()
            '// 2016.01.25 Ver.B06 hayakawa 修正↑ここまで

            ' 第二部の印刷
            If blnIs30FirstAndSecond = True And RdoKakitome.Checked = True Then
                ' 簡易書留
                Get30MissingAndNukitoriForTwoRound()
            End If

            If blnIs50FirstAndSecond = True And RdoTokutei.Checked = True Then
                ' 特定記録
                Get50MissingAndNukitoriForTwoRound()
            End If

            If blnIs150FirstAndSecond = True And RdoYuMail.Checked = True Then
                ' ゆうメール
                Get150MissingAndNukitoriForTwoRound()
            End If

            If (blnIs30FirstAndSecond = True And RdoKakitome.Checked = True) Or _
               (blnIs50FirstAndSecond = True And RdoTokutei.Checked = True) Or _
               (blnIs150FirstAndSecond = True And RdoYuMail.Checked = True) Then

                '// 2016.01.25 Ver.B06 hayakawa 修正↓ここから
                'PrintDocumentオブジェクトの作成
                Dim pd2 As New System.Drawing.Printing.PrintDocument
                'PrintPageイベントハンドラの追加
                AddHandler pd2.PrintPage, AddressOf PrintDocument1_PrintPage
                ' 欠番データの個数を取得
                intImageDataCount = arMissing.Count
                ' 印字ページインデックスの初期化
                intPrintImageIndex = 0
                ' PrintPreviewDialogオブジェクトの作成
                Dim ppd2 As New PrintPreviewDialog
                ppd2.Width = 1200
                ppd2.Height = 1000
                ' プレビューオブジェクトの「印刷」ボタン削除
                'tool = CType(ppd.Controls(1), ToolStrip)
                'tool.Items.RemoveAt(0)
                ' プレビューするPrintDocumentを設定
                ppd2.Document = pd2
                ' 印刷プレビューダイアログを表示する
                ppd2.ShowDialog()
                ' PrintPreviewDialogオブジェクトの解放
                ppd2.Dispose()
                retVal = MsgBox("第二部目の欠番確認表を印刷しますか？", CType(MsgBoxStyle.Question + MsgBoxStyle.OkCancel, MsgBoxStyle), "確認")
                If retVal = MsgBoxResult.Cancel Then
                    ' キャンセル
                    Exit Sub
                End If
                ' 欠番データの個数を取得
                intImageDataCount = arMissing.Count
                ' 印字ページインデックスの初期化
                intPrintImageIndex = 0
                pd2.DocumentName = "欠番確認表（第2部）の印刷"
                ' 印刷処理
                pd2.Print()
                ' PrintDocumentオブジェクトの解放
                pd2.Dispose()
                '// 2016.01.25 Ver.B06 hayakawa 修正↑ここまで
            End If

            '// 2016.01.25 Ver.B06 hayakawa コメントアウト↓ここから
            ' PrintPreviewDialogオブジェクトの解放
            'ppd.Dispose()
            ' PrintDocumentオブジェクトの解放
            'pd.Dispose()
            '// 2016.01.25 Ver.B06 hayakawa コメントアウト↑ここまで

        Catch ex As Exception
            MsgBox("【BtnPrint_Click】" & ex.Message)
        End Try

    End Sub


    ''' <summary>
    ''' 欠番確認表の印刷処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub PrintDocument1_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage

        '// 1mm≒4.11
        Dim intYoko1 As Integer = 62    ' 横１の印刷座標（15mm）（原点からの距離）

        'Dim intTate1 As Integer = 41    ' 縦１の印刷座標（10mm）
        'Dim intTate2 As Integer = 82    ' 縦２の印刷座標（20mm）
        Dim intTate3 As Integer = 123   ' 縦３の印刷座標（30mm）

        Dim intTate5 As Integer = 358   ' 表組のスタート位置（縦：87mm） 

        Dim intSTPosYoko As Integer     ' 印刷開始ポジション（横）
        Dim intSTPosTate As Integer     ' 印刷開始ポジション（縦）
        Dim intTateHaba As Integer      ' 行の縦幅
        Dim intOffset As Integer        ' 文字印刷縦方向印刷オフセット

        Dim N As Integer                ' 汎用ループカウンタ

        Try
            ' ヘッダーの印刷
            Dim dtNow As DateTime = DateTime.Now
            Dim t As New Font("メイリオ", 18, FontStyle.Regular)
            Dim h As New Font("メイリオ", 14, FontStyle.Regular)
            Dim f As New Font("メイリオ", 10, FontStyle.Regular)

            Dim uh As New Font("メイリオ", 14, FontStyle.Underline)
            Dim mf As New Font("ＭＳ ゴシック", 10, FontStyle.Regular)
            Dim ms As New Font("ＭＳ ゴシック", 14, FontStyle.Regular)

            ' ヘッダー１行目（印字開始位置：横130mm×縦10mm）
            e.Graphics.DrawString(Date.Now.ToString("yyyy年MM月dd日 HH時mm分ss秒"), f, Brushes.Black, 534, 41)
            ' ヘッダー１行目（印字開始位置：横20mm×縦10mm）
            e.Graphics.DrawString(DateTimePicker1.Value.ToString("yyyy年MM月dd日"), t, Brushes.Black, 82, 41)

            ' ヘッダー２行目（印字開始位置：横20mm×縦18mm）
            e.Graphics.DrawString(strClassName & "等欠番確認表", t, Brushes.Black, 82, 73)
            ' ヘッダー３行目（印字開始位置：横150mm×縦20mm）
            e.Graphics.DrawString("【" & PubConstClass.pblMachineName & "】", f, Brushes.Black, 616, 82)
            ' ヘッダー３行目（印字開始位置：横170mm×縦20mm）
            e.Graphics.DrawString("Page " & (intPrintImageIndex + 1).ToString, f, Brushes.Black, 699, 82)

            PrintDocument1.DocumentName = "欠番確認表印刷"

            intSTPosYoko = intYoko1
            intSTPosTate = intTate3

            intTateHaba = 65        ' 16mm
            intOffset = 7           ' 1.7mm

            '// 差出人の氏名住所の枠線
            ' 横155mm×縦18mm
            e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(intSTPosYoko, intSTPosTate, 721, 74))
            e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(215, 141, 123, 41))
            e.Graphics.DrawString("Ｆ－３５", h, Brushes.Black, 234, 148)

            e.Graphics.DrawString("差出人の住所氏名", f, Brushes.Black, intSTPosYoko + 5, intSTPosTate + 5)
            e.Graphics.DrawString(PubConstClass.pblSenderAddress1 & PubConstClass.pblSenderAddress2, f, Brushes.Black, intSTPosYoko + 308 + 5, intSTPosTate + 5)
            e.Graphics.DrawString(PubConstClass.pblSenderName, f, Brushes.Black, intSTPosYoko + 308 + 5, intSTPosTate + 25 + 5)

            ' 印字位置（横19mm×縦53mm）
            e.Graphics.DrawString("最初の引受番号", f, Brushes.Black, 78, 218 - 5)
            e.Graphics.DrawString("－", f, Brushes.Black, 321, 218 - 5)
            e.Graphics.DrawString("－", f, Brushes.Black, 415, 218 - 5)
            e.Graphics.DrawString("－", f, Brushes.Black, 608, 218 - 5)
            e.Graphics.DrawString("①", f, Brushes.Black, 666, 218 - 5)

            ' 印字位置（横19mm×縦65mm）
            e.Graphics.DrawString("最後の引受番号", f, Brushes.Black, 78, 267 - 5)
            e.Graphics.DrawString("－", f, Brushes.Black, 321, 267 - 5)
            e.Graphics.DrawString("－", f, Brushes.Black, 415, 267 - 5)
            e.Graphics.DrawString("－", f, Brushes.Black, 608, 267 - 5)
            e.Graphics.DrawString("②", f, Brushes.Black, 666, 267 - 5)
            ' 印字位置（横19mm×縦76mm）
            e.Graphics.DrawString("引受番号の通数（②－①）＋１＝③", f, Brushes.Black, 78, 312 - 5)
            e.Graphics.DrawString("通", f, Brushes.Black, 608, 312 - 5)

            '// 最初の引受番号の枠印刷
            ' 枠の印字（横52mm×縦50mm）
            e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(214, 206, 33, 33))
            e.Graphics.DrawString(strSArray(0), ms, Brushes.Black, 214 + intOffset, 206 + intOffset)
            e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(214 + 33, 206, 33, 33))
            e.Graphics.DrawString(strSArray(1), ms, Brushes.Black, 214 + 33 + intOffset, 206 + intOffset)
            e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(214 + 33 * 2, 206, 33, 33))
            e.Graphics.DrawString(strSArray(2), ms, Brushes.Black, 214 + 33 * 2 + intOffset, 206 + intOffset)
            ' 枠の印字（横83mm×縦50mm）
            e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(341, 206, 33, 33))
            e.Graphics.DrawString(strSArray(3), ms, Brushes.Black, 341 + intOffset, 206 + intOffset)
            e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(341 + 33, 206, 33, 33))
            e.Graphics.DrawString(strSArray(4), ms, Brushes.Black, 341 + 33 + intOffset, 206 + intOffset)
            ' 枠の印字（横106mm×縦50mm）
            e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(436, 206, 33, 33))
            e.Graphics.DrawString(strSArray(5), ms, Brushes.Black, 436 + intOffset, 206 + intOffset)
            e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(436 + 33, 206, 33, 33))
            e.Graphics.DrawString(strSArray(6), ms, Brushes.Black, 436 + 33 + intOffset, 206 + intOffset)
            e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(436 + 33 * 2, 206, 33, 33))
            e.Graphics.DrawString(strSArray(7), ms, Brushes.Black, 436 + 33 * 2 + intOffset, 206 + intOffset)
            e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(436 + 33 * 3, 206, 33, 33))
            e.Graphics.DrawString(strSArray(8), ms, Brushes.Black, 436 + 33 * 3 + intOffset, 206 + intOffset)
            e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(436 + 33 * 4, 206, 33, 33))
            e.Graphics.DrawString(strSArray(9), ms, Brushes.Black, 436 + 33 * 4 + intOffset, 206 + intOffset)
            ' 枠の印字（横153mm×縦50mm）
            e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(629, 206, 33, 33))
            e.Graphics.DrawString(strSArray(10), ms, Brushes.Black, 629 + intOffset, 206 + intOffset)

            '// 最後の引受番号の枠印刷
            ' 枠の印字（横52mm×縦62mm）
            e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(214, 255, 33, 33))
            e.Graphics.DrawString(strEArray(0), ms, Brushes.Black, 214 + intOffset, 255 + intOffset)
            e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(214 + 33, 255, 33, 33))
            e.Graphics.DrawString(strEArray(1), ms, Brushes.Black, 214 + 33 + intOffset, 255 + intOffset)
            e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(214 + 33 * 2, 255, 33, 33))
            e.Graphics.DrawString(strEArray(2), ms, Brushes.Black, 214 + 33 * 2 + intOffset, 255 + intOffset)
            ' 枠の印字（横83mm×縦62mm）
            e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(341, 255, 33, 33))
            e.Graphics.DrawString(strEArray(3), ms, Brushes.Black, 341 + intOffset, 255 + intOffset)
            e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(341 + 33, 255, 33, 33))
            e.Graphics.DrawString(strEArray(4), ms, Brushes.Black, 341 + 33 + intOffset, 255 + intOffset)
            ' 枠の印字（横106mm×縦62mm）
            e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(436, 255, 33, 33))
            e.Graphics.DrawString(strEArray(5), ms, Brushes.Black, 436 + intOffset, 255 + intOffset)
            e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(436 + 33, 255, 33, 33))
            e.Graphics.DrawString(strEArray(6), ms, Brushes.Black, 436 + 33 + intOffset, 255 + intOffset)
            e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(436 + 33 * 2, 255, 33, 33))
            e.Graphics.DrawString(strEArray(7), ms, Brushes.Black, 436 + 33 * 2 + intOffset, 255 + intOffset)
            e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(436 + 33 * 3, 255, 33, 33))
            e.Graphics.DrawString(strEArray(8), ms, Brushes.Black, 436 + 33 * 3 + intOffset, 255 + intOffset)
            e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(436 + 33 * 4, 255, 33, 33))
            e.Graphics.DrawString(strEArray(9), ms, Brushes.Black, 436 + 33 * 4 + intOffset, 255 + intOffset)
            ' 枠の印字（横153mm×縦62mm）
            e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(629, 255, 33, 33))
            e.Graphics.DrawString(strEArray(10), ms, Brushes.Black, 629 + intOffset, 255 + intOffset)

            '// 引受番号の通数
            ' 枠の印字（（横106mm＋8mm）×縦73mm）
            e.Graphics.DrawRectangle(New Pen(Color.Black, 2), New Rectangle(436 + 33, 300, 33, 33))
            e.Graphics.DrawString(strNumCount(0), ms, Brushes.Black, 436 + 33 + intOffset, 300 + intOffset)
            e.Graphics.DrawRectangle(New Pen(Color.Black, 2), New Rectangle(436 + 33 * 2, 300, 33, 33))
            e.Graphics.DrawString(strNumCount(1), ms, Brushes.Black, 436 + 33 * 2 + intOffset, 300 + intOffset)
            e.Graphics.DrawRectangle(New Pen(Color.Black, 2), New Rectangle(436 + 33 * 3, 300, 33, 33))
            e.Graphics.DrawString(strNumCount(2), ms, Brushes.Black, 436 + 33 * 3 + intOffset, 300 + intOffset)
            e.Graphics.DrawRectangle(New Pen(Color.Black, 2), New Rectangle(436 + 33 * 4, 300, 33, 33))
            e.Graphics.DrawString(strNumCount(3), ms, Brushes.Black, 436 + 33 * 4 + intOffset, 300 + intOffset)

            Dim intWidth1 As Integer = 33   ' 8mm
            Dim intWidth2 As Integer = 214  ' 52mm
            Dim intVarWidth As Integer
            '// バーコード印字領域の表組み印刷
            For N = 1 To 10
                intVarWidth = 0
                For K = 1 To 3
                    intVarWidth = intVarWidth + intWidth1
                    e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(intYoko1 - 20, intTate5, intVarWidth, intTateHaba * N))
                    intVarWidth = intVarWidth + intWidth2
                    e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(intYoko1 - 20, intTate5, intVarWidth, intTateHaba * N))
                Next
            Next

            Dim img(30) As Image
            Dim pict As PictureBox = New PictureBox

            pict.Width = 200    ' 48mm
            pict.Height = 53    ' 13mm

            Dim cbar = New ClsBarCode

            cbar.Top = 0
            cbar.Left = 0
            cbar.Block = 1
            cbar.Height = 30    ' 8mm
            cbar.Check = False
            cbar.StartChr = "c"
            cbar.StopChr = "c"

            ' 描画領域の作成
            pict.Image = New Bitmap(pict.ClientSize.Width, pict.ClientSize.Height)
            cbar.Target = pict

            If arMissing.Count > 0 Then

                Dim intMissingCnt As Integer = 0
                Dim blnIsExitFor As Boolean = False
                Dim strNukiArray() As String

                For K = 0 To 2
                    For N = 0 To 9
                        'strNukiArray = arMissing(N).ToString.Split(","c)
                        strNukiArray = arMissing(intMissingCnt + 30 * intPrintImageIndex).ToString.Split(","c)
                        If strNukiArray.Length > 1 Then
                            ' 抜取データの印字
                            '// 2016.02.02 Ver.B06 hayakawa 修正↓ここから                            
                            'e.Graphics.DrawString((K * 10 + N + 1).ToString("00"), ms, Brushes.Black, _
                            '                      intYoko1 - 20 + (intWidth1 + intWidth2) * K + intOffset - 5, _
                            '                      intTate5 + intTateHaba * N + intOffset * 2)
                            e.Graphics.DrawString((K * 10 + N + 1 + 30 * intPrintImageIndex).ToString("00"), ms, Brushes.Black, _
                                                  intYoko1 - 20 + (intWidth1 + intWidth2) * K + intOffset - 5, _
                                                  intTate5 + intTateHaba * N + intOffset * 2)
                            '// 2016.02.02 Ver.B06 hayakawa 修正↑ここまで
                            e.Graphics.DrawString("■", ms, Brushes.Black, _
                                                  intYoko1 - 20 + (intWidth1 + intWidth2) * K + intOffset - 5, _
                                                  intTate5 + intTateHaba * N + intOffset * 2 + 22)
                            cbar.Code = strNukiArray(0).ToString.Replace("-", "")
                        Else
                            ' 欠番データの印字
                            '// 2016.02.02 Ver.B06 hayakawa 修正↓ここから
                            'e.Graphics.DrawString((K * 10 + N + 1).ToString("00"), ms, Brushes.Black, _
                            '                      intYoko1 - 20 + (intWidth1 + intWidth2) * K + intOffset - 5, _
                            '                      intTate5 + intTateHaba * N + intOffset * 2)
                            e.Graphics.DrawString((K * 10 + N + 1 + 30 * intPrintImageIndex).ToString("00"), ms, Brushes.Black, _
                                                  intYoko1 - 20 + (intWidth1 + intWidth2) * K + intOffset - 5, _
                                                  intTate5 + intTateHaba * N + intOffset * 2)
                            '// 2016.02.02 Ver.B06 hayakawa 修正↑ここまで
                            cbar.Code = arMissing(intMissingCnt + 30 * intPrintImageIndex).ToString.Replace("-", "")
                        End If

                        cbar.PrintBar()
                        img((K * 10 + N + 1)) = pict.Image
                        e.Graphics.DrawImage(img((K * 10 + N + 1)), New Rectangle(intYoko1 + 20 + (intWidth1 + intWidth2) * K + 5, _
                                                                                  intTate5 + intTateHaba * N + 10, _
                                                                                  pict.Width, _
                                                                                  pict.Height))
                        intMissingCnt += 1
                        intImageDataCount = intImageDataCount - 1
                        If intImageDataCount < 1 Then
                            blnIsExitFor = True
                            Exit For
                        End If
                    Next
                    If blnIsExitFor = True Then
                        Exit For
                    End If
                Next

            End If

            Dim intTateFooter As Integer = 1036       ' 252mm

            e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(intYoko1, intTateFooter, 136, 66))
            e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(370, intTateFooter, 206, 66))
            e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(621, intTateFooter, 74, 66))

            e.Graphics.DrawString("欠番数", mf, Brushes.Black, intYoko1 + intOffset, intTateFooter + 5)
            e.Graphics.DrawString("差出現物通数", mf, Brushes.Black, 370 + intOffset, intTateFooter + 5)
            e.Graphics.DrawString("担当者印", mf, Brushes.Black, 621 + intOffset, intTateFooter + 5)

            e.Graphics.DrawString("通", mf, Brushes.Black, 177, intTateFooter + 41)
            e.Graphics.DrawString("④", mf, Brushes.Black, 177 + 41, intTateFooter + 41)
            e.Graphics.DrawString("通", mf, Brushes.Black, 555, intTateFooter + 41)

            e.Graphics.DrawString(GetKetuban(arMissing.Count.ToString("0")), ms, Brushes.Black, intYoko1, intTateFooter + 33)
            Dim strTusuCount As String = strNumCount(0) & strNumCount(1) & strNumCount(2) & strNumCount(3)
            Dim intTranCount As Integer
            intTranCount = CInt(strTusuCount) - arMissing.Count
            e.Graphics.DrawString(GetTranCount(intTranCount.ToString("0")), ms, Brushes.Black, 370, intTateFooter + 33)
            e.Graphics.DrawString("③－④＝⑤", mf, Brushes.Black, 242 + 41, intTateFooter + 26)

            ' 次の頁なし
            e.HasMorePages = False

            If intImageDataCount > 0 Then
                e.HasMorePages = True
                intPrintImageIndex = intPrintImageIndex + 1
            Else
                ' 次の頁なし
                e.HasMorePages = False
            End If

        Catch ex As Exception
            MsgBox("【PrintDocument1_PrintPage】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="strData"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetTranCount(ByVal strData As String) As String

        Dim strRetVal As String

        GetTranCount = strData

        Try
            Select Case strData.Length
                Case 1
                    '            1234567890123456
                    strRetVal = "                " & strData
                Case 2
                    '            123456789012345
                    strRetVal = "               " & strData
                Case 3
                    '            12345678901234
                    strRetVal = "              " & strData
                Case 4
                    '            123456789012
                    strRetVal = "            " & CInt(strData).ToString("0,000")
                Case 5
                    '            12345678901
                    strRetVal = "           " & CInt(strData).ToString("00,000")
                Case 6
                    '            1234567890
                    strRetVal = "          " & CInt(strData).ToString("000,000")
                Case Else
                    strRetVal = strData
            End Select

            Return strRetVal

        Catch ex As Exception
            MsgBox("【GetTranCount】" & ex.Message)
        End Try

    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="strData"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetKetuban(ByVal strData As String) As String

        Dim strRetVal As String

        GetKetuban = strData

        Try
            Select Case strData.Length

                Case 1
                    '            123456789
                    strRetVal = "         " & strData
                Case 2
                    '            12345678
                    strRetVal = "        " & strData
                Case 3
                    '            1234567
                    strRetVal = "       " & strData
                Case 4
                    '            12345
                    strRetVal = "     " & CInt(strData).ToString("0,000")
                Case 5
                    '            1234
                    strRetVal = "    " & CInt(strData).ToString("00,000")
                Case Else
                    strRetVal = strData
            End Select

            Return strRetVal

        Catch ex As Exception
            MsgBox("【GetKetuban】" & ex.Message)
        End Try

    End Function

    ''' <summary>
    ''' 「番号帯確認」ボタン処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnConfNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnConfNumber.Click

        Dim strArray() As String
        Dim strClassArray() As String
        Dim strReadDataFileName As String
        Dim strReadData As String

        Try

            ' 画面の初期化
            Call InitDisplayData()

            ' 集計対象日から対象フォルダを確定する
            Dim strSearchDir As String = IncludeTrailingPathDelimiter(PubConstClass.imgPath) & DateTimePicker1.Value.ToString("yyyyMMdd") & "\"

            If System.IO.Directory.Exists(strSearchDir) = False Then
                MsgBox("集計対象フォルダが見つかりません", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")
                Exit Sub
            End If
            If System.IO.Directory.GetFiles(strSearchDir, "*.LOG", System.IO.SearchOption.AllDirectories).Count < 1 Then
                MsgBox("集計対象ファイルが見つかりません", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")
                Exit Sub
            End If

            '    0,                                  1,                  2,             3,  4,  5,                                                            6,           7,      8,       9  10,  11,
            '00001,001：簡易書留郵便（定型ラベル右上）,2015/07/28 19:44:18,358-19-00001-1,894,910,C:\RECDEL\IMG\20150728\194347\image_20150728_194418_00001.jpg,30：簡易書留,0234-00,蟹江支店,234,定形,
            ar30Class.Clear()
            ar50Class.Clear()
            ar150Class.Clear()
            ar30NukiTori.Clear()
            ar50NukiTori.Clear()
            ar150NukiTori.Clear()

            For Each strFileList As String In System.IO.Directory.GetFiles(strSearchDir, "*.LOG", System.IO.SearchOption.AllDirectories)

                strReadDataFileName = strFileList
                Using sr As New System.IO.StreamReader(strReadDataFileName, System.Text.Encoding.Default)

                    Do While Not sr.EndOfStream
                        ' ファイルから１行読込む
                        strReadData = sr.ReadLine.ToString

                        ' カンマ単位にデータを分解
                        strArray = strReadData.Split(","c)
                        strClassArray = strArray(7).Split("："c)

                        ' 030,簡易書留（速達）
                        If strClassArray(0) = "30" Or strClassArray(0) = "40" Then
                            ' 引受番号の格納
                            ar30Class.Add(strArray(3))
                            If strArray(12) = "■" Then
                                ar30NukiTori.Add(strArray(3))
                            End If
                        End If
                        ' 050,特定記録（速達）
                        If strClassArray(0) = "50" Or strClassArray(0) = "60" Then
                            ' 引受番号の格納
                            ar50Class.Add(strArray(3))
                            If strArray(12) = "■" Then
                                ar50NukiTori.Add(strArray(3))
                            End If
                        End If
                        ' 150,ゆうメール（速達）
                        If strClassArray(0) = "150" Or strClassArray(0) = "160" Then
                            ' 引受番号の格納
                            ar150Class.Add(strArray(3))
                            If strArray(12) = "■" Then
                                ar150NukiTori.Add(strArray(3))
                            End If
                        End If
                    Loop

                End Using

            Next

            If ar30Class.Count > 0 Then

                If CDbl(ar30Class.Item(0).ToString.Replace("-", "")) > CDbl(ar30Class.Item(ar30Class.Count - 1).ToString.Replace("-", "")) Then
                    ' 「開始引受番号＞終了引受番号」の場合は昇順にソートしない

                    blnIs30FirstAndSecond = True
                    lng30FirstAndSecondCnt = ar30Class.Count
                    Dim strStartArray() As String = PubConstClass.strStartNumber(0).Split(","c)
                    Dim strEndArray() As String = PubConstClass.strEndNumber(0).Split(","c)
                    ar30ClassFirstHalf.Clear()
                    ar30ClassSecondHalf.Clear()
                    For N = 0 To ar30Class.Count - 1
                        If CDbl(ar30Class(N).ToString.Replace("-", "")) >= CDbl(ar30Class(0).ToString.Replace("-", "")) Then
                            ar30ClassSecondHalf.Add(ar30Class(N).ToString)
                        Else
                            ar30ClassFirstHalf.Add(ar30Class(N).ToString)
                        End If
                    Next

                Else
                    ar30Class.Sort()
                    blnIs30FirstAndSecond = False
                End If

                strArray = ar30Class(0).ToString.Split("-"c)
                lblKakiAcNumS1.Text = strArray(0)
                lblKakiAcNumS2.Text = strArray(1)
                lblKakiAcNumS3.Text = strArray(2)
                lblKakiAcNumS4.Text = strArray(3)
                strArray = ar30Class(ar30Class.Count - 1).ToString.Split("-"c)
                lblKakiAcNumE1.Text = strArray(0)
                lblKakiAcNumE2.Text = strArray(1)
                lblKakiAcNumE3.Text = strArray(2)
                lblKakiAcNumE4.Text = strArray(3)

            End If

            If ar50Class.Count > 0 Then

                If CDbl(ar50Class.Item(0).ToString.Replace("-", "")) > CDbl(ar50Class.Item(ar50Class.Count - 1).ToString.Replace("-", "")) Then
                    ' 「開始引受番号＞終了引受番号」の場合は昇順にソートしない

                    blnIs50FirstAndSecond = True
                    lng50FirstAndSecondCnt = ar50Class.Count
                    Dim strStartArray() As String = PubConstClass.strStartNumber(0).Split(","c)
                    Dim strEndArray() As String = PubConstClass.strEndNumber(0).Split(","c)
                    ar50ClassFirstHalf.Clear()
                    ar50ClassSecondHalf.Clear()
                    For N = 0 To ar50Class.Count - 1
                        If CDbl(ar50Class(N).ToString.Replace("-", "")) >= CDbl(ar50Class(0).ToString.Replace("-", "")) Then
                            ar50ClassSecondHalf.Add(ar50Class(N).ToString)
                        Else
                            ar50ClassFirstHalf.Add(ar50Class(N).ToString)
                        End If
                    Next

                Else
                    ar50Class.Sort()
                    blnIs50FirstAndSecond = False
                End If

                strArray = ar50Class(0).ToString.Split("-"c)
                lblTokuAcNumS1.Text = strArray(0)
                lblTokuAcNumS2.Text = strArray(1)
                lblTokuAcNumS3.Text = strArray(2)
                lblTokuAcNumS4.Text = strArray(3)
                strArray = ar50Class(ar50Class.Count - 1).ToString.Split("-"c)
                lblTokuAcNumE1.Text = strArray(0)
                lblTokuAcNumE2.Text = strArray(1)
                lblTokuAcNumE3.Text = strArray(2)
                lblTokuAcNumE4.Text = strArray(3)

            End If

            If ar150Class.Count > 0 Then

                If CDbl(ar150Class.Item(0).ToString.Replace("-", "")) > CDbl(ar150Class.Item(ar150Class.Count - 1).ToString.Replace("-", "")) Then
                    ' 「開始引受番号＞終了引受番号」の場合は昇順にソートしない

                    blnIs150FirstAndSecond = True
                    lng150FirstAndSecondCnt = ar150Class.Count
                    Dim strStartArray() As String = PubConstClass.strStartNumber(0).Split(","c)
                    Dim strEndArray() As String = PubConstClass.strEndNumber(0).Split(","c)
                    ar150ClassFirstHalf.Clear()
                    ar150ClassSecondHalf.Clear()
                    For N = 0 To ar150Class.Count - 1
                        If CDbl(ar150Class(N).ToString.Replace("-", "")) >= CDbl(ar150Class(0).ToString.Replace("-", "")) Then
                            ar150ClassSecondHalf.Add(ar150Class(N).ToString)
                        Else
                            ar150ClassFirstHalf.Add(ar150Class(N).ToString)
                        End If
                    Next

                Else
                    ar150Class.Sort()
                    blnIs150FirstAndSecond = False
                End If

                strArray = ar150Class(0).ToString.Split("-"c)
                lblYumeAcNumS1.Text = strArray(0)
                lblYumeAcNumS2.Text = strArray(1)
                lblYumeAcNumS3.Text = strArray(2)
                lblYumeAcNumS4.Text = strArray(3)
                strArray = ar150Class(ar150Class.Count - 1).ToString.Split("-"c)
                lblYumeAcNumE1.Text = strArray(0)
                lblYumeAcNumE2.Text = strArray(1)
                lblYumeAcNumE3.Text = strArray(2)
                lblYumeAcNumE4.Text = strArray(3)
            End If

        Catch ex As Exception
            MsgBox("【BtnConfNumber_Click】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 連続した引受番号の欠番を求める
    ''' </summary>
    ''' <param name="arData">使用した引受番号</param>
    ''' <param name="arMissingNumber">欠番の引受番号</param>
    ''' <remarks>連番性の無い引受番号を欠番として返す</remarks>
    Private Sub GetMissingNumber(ByRef arData As ArrayList, ByVal arMissingNumber As ArrayList)

        Dim strStart As String
        Dim strEnd As String
        Dim lngCnt As Long
        Dim strData As String
        Dim strMod As String

        Try
            strStart = arData(0).ToString.Replace("-", "").Substring(0, 10)
            strEnd = arData(arData.Count - 1).ToString.Replace("-", "").Substring(0, 10)
            lngCnt = CLng(strEnd) - CLng(strStart)
            For N = 0 To lngCnt
                strData = (CLng(strStart) + N).ToString("000-00-00000")
                strMod = ((CLng(strStart) + N) Mod 7).ToString
                arMissingNumber.Add(strData & "-" & strMod)
            Next

            For N = 0 To arData.Count - 1
                arMissingNumber.Remove(arData(N))
            Next

        Catch ex As Exception
            MsgBox("【GetMissingNumber】" & ex.Message)
        End Try

    End Sub


    ''' <summary>
    ''' 最終番号から開始番号変化した処理を行った時の欠番を求める
    ''' </summary>
    ''' <param name="strFirstSecond">0：前半部／1：後半部</param>
    ''' <param name="arData">使用した引受番号</param>
    ''' <param name="arMissingNumber">欠番と抜取の引受番号を欠番として返す</param>
    ''' <remarks></remarks>
    Private Sub GetMissingNumberForRound(ByVal strFirstSecond As String, ByRef arData As ArrayList, ByVal arMissingNumber As ArrayList)

        Dim strStart As String
        Dim strEnd As String
        Dim lngCnt As Long
        Dim strData As String
        Dim strMod As String

        '運転時の引受番号：PubConstClass.dblStartUnderWritingNumber
        '　　設定開始番号：PubConstClass.dblFirstUnderWritingNumber
        '　　設定終了番号：PubConstClass.dblEndUnderWritingNumber

        Try
            If strFirstSecond = "0" Then
                ' 前半部分を求める
                strStart = PubConstClass.dblFirstUnderWritingNumber.ToString("0000000000")
                strEnd = arData(arData.Count - 1).ToString.Replace("-", "").Substring(0, 10)
                lngCnt = CLng(strEnd) - CLng(strStart)
                For N = 0 To lngCnt
                    strData = (CLng(strStart) + N).ToString("000-00-00000")
                    strMod = ((CLng(strStart) + N) Mod 7).ToString
                    arMissingNumber.Add(strData & "-" & strMod)
                Next
                ' 欠番の引受番号を求める
                For N = 0 To arData.Count - 1
                    arMissingNumber.Remove(arData(N))
                Next

                ' 抜取データの抽出
                If RdoKakitome.Checked = True Then
                    For N = 0 To ar30NukiTori.Count - 1
                        If CLng(ar30NukiTori(N).ToString.ToString.Replace("-", "").Substring(0, 10)) >= CLng(strStart) And _
                           CLng(ar30NukiTori(N).ToString.ToString.Replace("-", "").Substring(0, 10)) <= CLng(strEnd) Then
                            arMissing.Add(ar30NukiTori(N).ToString & ",■")
                            OutPutLogFile("【前半部分】抜取（簡易書留）の引受番号：" & ar30NukiTori(N).ToString)
                        End If
                    Next

                ElseIf RdoTokutei.Checked = True Then
                    For N = 0 To ar50NukiTori.Count - 1
                        If CLng(ar50NukiTori(N).ToString.ToString.Replace("-", "").Substring(0, 10)) >= CLng(strStart) And _
                           CLng(ar50NukiTori(N).ToString.ToString.Replace("-", "").Substring(0, 10)) <= CLng(strEnd) Then
                            arMissing.Add(ar50NukiTori(N).ToString & ",■")
                            OutPutLogFile("【前半部分】抜取（特定記録）の引受番号：" & ar50NukiTori(N).ToString)
                        End If
                    Next

                ElseIf RdoYuMail.Checked = True Then
                    For N = 0 To ar150NukiTori.Count - 1
                        If CLng(ar150NukiTori(N).ToString.ToString.Replace("-", "").Substring(0, 10)) >= CLng(strStart) And _
                           CLng(ar150NukiTori(N).ToString.ToString.Replace("-", "").Substring(0, 10)) <= CLng(strEnd) Then
                            arMissing.Add(ar150NukiTori(N).ToString & ",■")
                            OutPutLogFile("【前半部分】抜取（ゆうメール）の引受番号：" & ar150NukiTori(N).ToString)
                        End If
                    Next

                End If


            Else
                ' 後半部分を求める
                strStart = arData(0).ToString.Replace("-", "").Substring(0, 10)
                strEnd = PubConstClass.dblEndUnderWritingNumber.ToString("0000000000")
                lngCnt = CLng(strEnd) - CLng(strStart)
                For N = 0 To lngCnt
                    strData = (CLng(strStart) + N).ToString("000-00-00000")
                    strMod = ((CLng(strStart) + N) Mod 7).ToString
                    arMissingNumber.Add(strData & "-" & strMod)
                Next
                ' 欠番の引受番号を求める
                For N = 0 To arData.Count - 1
                    arMissingNumber.Remove(arData(N))
                Next

                ' 抜取データの抽出
                If RdoKakitome.Checked = True Then
                    For N = 0 To ar30NukiTori.Count - 1
                        If CLng(ar30NukiTori(N).ToString.Replace("-", "").Substring(0, 10)) >= CLng(strStart) And _
                           CLng(ar30NukiTori(N).ToString.Replace("-", "").Substring(0, 10)) <= CLng(strEnd) Then
                            arMissing.Add(ar30NukiTori(N).ToString & ",■")
                            OutPutLogFile("【後半部分】抜取（簡易書留）の引受番号：" & ar30NukiTori(N).ToString)
                        End If
                    Next

                ElseIf RdoTokutei.Checked = True Then
                    For N = 0 To ar50NukiTori.Count - 1
                        If CLng(ar50NukiTori(N).ToString.Replace("-", "").Substring(0, 10)) >= CLng(strStart) And _
                           CLng(ar50NukiTori(N).ToString.Replace("-", "").Substring(0, 10)) <= CLng(strEnd) Then
                            arMissing.Add(ar50NukiTori(N).ToString & ",■")
                            OutPutLogFile("【後半部分】抜取（特定記録）の引受番号：" & ar50NukiTori(N).ToString)
                        End If
                    Next

                ElseIf RdoYuMail.Checked = True Then
                    For N = 0 To ar150NukiTori.Count - 1
                        If CLng(ar150NukiTori(N).ToString.Replace("-", "").Substring(0, 10)) >= CLng(strStart) And _
                           CLng(ar150NukiTori(N).ToString.Replace("-", "").Substring(0, 10)) <= CLng(strEnd) Then
                            arMissing.Add(ar150NukiTori(N).ToString & ",■")
                            OutPutLogFile("【後半部分】抜取（ゆうメール）の引受番号：" & ar150NukiTori(N).ToString)
                        End If
                    Next

                End If

            End If

        Catch ex As Exception
            MsgBox("【GetMissingNumberForRound】" & ex.Message)
        End Try

    End Sub

End Class