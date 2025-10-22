Option Explicit On
Option Strict On

Public Class InformationForm

    Public strMessage As String
    Public Shared blnRetValMsgBox As Boolean

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub InformationForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Try
            LblMessage.Text = strMessage
            'Me.Location = New Point(CInt((1980 - Me.Width) / 2), DrivingForm.GroupBox12.Top)

            ' 動作不可コマンド送信
            Call DrivingForm.sendCommand(PubConstClass.CMD_DISABLE & vbCr)

        Catch ex As Exception
            MsgBox("【InformationForm_Load】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 「ＯＫ」ボタン
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnOK_Click(sender As System.Object, e As System.EventArgs) Handles BtnOK.Click

        '' 動作可能コマンド送信
        'Call DrivingForm.sendCommand(PubConstClass.CMD_ENABLE & vbCr)

        blnRetValMsgBox = True
        Me.Dispose()

    End Sub

End Class