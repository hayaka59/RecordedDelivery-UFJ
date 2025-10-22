Option Explicit On
Option Strict On

Public Class MsgBoxForm

    Public strMessage As String
    Public Shared blnRetValMsgBox As Boolean

    ''' <summary>
    ''' フォームロード処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub msgBoxForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            lblMes.Text = strMessage

            If strMessage.Length > 5 Then
                If strMessage.Substring(0, 5) = "ラベル印刷" Then
                    btnOK.Text = "行う"
                    btnCancel.Text = "行わない"
                Else
                    btnOK.Text = "ＯＫ"
                    btnCancel.Text = "キャンセル"
                End If
            End If

        Catch ex As Exception
            MsgBox("【msgBoxForm_Load】" & ex.Message)
        End Try

    End Sub


    ''' <summary>
    ''' 「ＯＫ」ボタン処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

        blnRetValMsgBox = True
        Me.Dispose()

    End Sub


    ''' <summary>
    ''' 「キャンセル」ボタンのクリック処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        blnRetValMsgBox = False
        Me.Dispose()

    End Sub

End Class