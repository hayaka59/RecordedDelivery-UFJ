Option Explicit On
Option Strict On

Imports System.Runtime.InteropServices

'//////////////////////////////////////////////////////////////
'�X�i�b�v�摜�\���t�H�[��
Public Class Frm_Image

    '----------------------------------------------------------
    '�t�H�[�����[�h��
    Private Sub Frm_Image_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    '----------------------------------------------------------

    '�}�E�X�_�E����
    Private Sub Pic_View_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Pic_View.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            '�|�b�v�A�b�v���j���[�\��
            Me.ContextMenuStrip = PopupMenu_Image
        End If
    End Sub

    '�|�b�v�A�b�v���j���[�F�ۑ�
    Private Sub Menu_Save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Menu_Save.Click

        '�t�@�C��������
        Diag_SaveFile.FileName = Me.Text + ".bmp"
        If Diag_SaveFile.ShowDialog <> Windows.Forms.DialogResult.OK Then Exit Sub

        '�ۑ�
        Try
            Pic_View.Image.Save(Diag_SaveFile.FileName, System.Drawing.Imaging.ImageFormat.Bmp)
        Catch ex As Exception
            MsgBox("�ۑ��Ɏ��s���܂����B" + vbCrLf + "���R�F" + ex.Message)
        End Try

    End Sub

    '�|�b�v�A�b�v���j���[�F�㉺���]
    Private Sub Menu_FlipY_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Menu_FlipY.Click
        '�㉺���]
        Pic_View.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
        Pic_View.Refresh()
    End Sub

    '----------------------------------------------------------

    '�\��(RGB24�r�b�g)
    Public Sub DrawRGB24(ByVal BmpPtr As IntPtr, ByVal BmpSize As Size)

        '����
        Dim bmp As New Bitmap(BmpSize.Width, BmpSize.Height, BmpSize.Width * 3, Imaging.PixelFormat.Format24bppRgb, BmpPtr)
        bmp.RotateFlip(RotateFlipType.RotateNoneFlipY)
        Pic_View.Image = New Bitmap(BmpSize.Width, BmpSize.Height)

        '�\���̈�ɃR�s�[
        Dim g As Graphics = Graphics.FromImage(Pic_View.Image)
        g.DrawImage(bmp, 0, 0)
        g.Dispose()

        '��n��
        bmp.Dispose()

        '�\��
        Pic_View.Location = New Point(0, 0)
        Me.ClientSize = Pic_View.Size
        Me.Show()

    End Sub

End Class