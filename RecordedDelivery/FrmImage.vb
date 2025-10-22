Option Explicit On
Option Strict On

Imports System.Runtime.InteropServices

'//////////////////////////////////////////////////////////////
'スナップ画像表示フォーム
Public Class Frm_Image

    '----------------------------------------------------------
    'フォームロード時
    Private Sub Frm_Image_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    '----------------------------------------------------------

    'マウスダウン時
    Private Sub Pic_View_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Pic_View.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            'ポップアップメニュー表示
            Me.ContextMenuStrip = PopupMenu_Image
        End If
    End Sub

    'ポップアップメニュー：保存
    Private Sub Menu_Save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Menu_Save.Click

        'ファイル名決定
        Diag_SaveFile.FileName = Me.Text + ".bmp"
        If Diag_SaveFile.ShowDialog <> Windows.Forms.DialogResult.OK Then Exit Sub

        '保存
        Try
            Pic_View.Image.Save(Diag_SaveFile.FileName, System.Drawing.Imaging.ImageFormat.Bmp)
        Catch ex As Exception
            MsgBox("保存に失敗しました。" + vbCrLf + "理由：" + ex.Message)
        End Try

    End Sub

    'ポップアップメニュー：上下反転
    Private Sub Menu_FlipY_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Menu_FlipY.Click
        '上下反転
        Pic_View.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
        Pic_View.Refresh()
    End Sub

    '----------------------------------------------------------

    '表示(RGB24ビット)
    Public Sub DrawRGB24(ByVal BmpPtr As IntPtr, ByVal BmpSize As Size)

        '準備
        Dim bmp As New Bitmap(BmpSize.Width, BmpSize.Height, BmpSize.Width * 3, Imaging.PixelFormat.Format24bppRgb, BmpPtr)
        bmp.RotateFlip(RotateFlipType.RotateNoneFlipY)
        Pic_View.Image = New Bitmap(BmpSize.Width, BmpSize.Height)

        '表示領域にコピー
        Dim g As Graphics = Graphics.FromImage(Pic_View.Image)
        g.DrawImage(bmp, 0, 0)
        g.Dispose()

        '後始末
        bmp.Dispose()

        '表示
        Pic_View.Location = New Point(0, 0)
        Me.ClientSize = Pic_View.Size
        Me.Show()

    End Sub

End Class