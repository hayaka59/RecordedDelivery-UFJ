<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Image
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Windows フォーム デザイナで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
    'Windows フォーム デザイナを使用して変更できます。  
    'コード エディタを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.Pic_View = New System.Windows.Forms.PictureBox
        Me.PopupMenu_Image = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Menu_Save = New System.Windows.Forms.ToolStripMenuItem
        Me.Menu_FlipY = New System.Windows.Forms.ToolStripMenuItem
        Me.Diag_SaveFile = New System.Windows.Forms.SaveFileDialog
        CType(Me.Pic_View, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PopupMenu_Image.SuspendLayout()
        Me.SuspendLayout()
        '
        'Pic_View
        '
        Me.Pic_View.BackColor = System.Drawing.Color.Black
        Me.Pic_View.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pic_View.Location = New System.Drawing.Point(0, 24)
        Me.Pic_View.Name = "Pic_View"
        Me.Pic_View.Size = New System.Drawing.Size(100, 50)
        Me.Pic_View.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.Pic_View.TabIndex = 0
        Me.Pic_View.TabStop = False
        '
        'PopupMenu_Image
        '
        Me.PopupMenu_Image.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Menu_Save, Me.Menu_FlipY})
        Me.PopupMenu_Image.Name = "PopupMenu_Image"
        Me.PopupMenu_Image.Size = New System.Drawing.Size(140, 48)
        '
        'Menu_Save
        '
        Me.Menu_Save.Name = "Menu_Save"
        Me.Menu_Save.Size = New System.Drawing.Size(139, 22)
        Me.Menu_Save.Text = "保存(&S)"
        '
        'Menu_FlipY
        '
        Me.Menu_FlipY.Name = "Menu_FlipY"
        Me.Menu_FlipY.Size = New System.Drawing.Size(139, 22)
        Me.Menu_FlipY.Text = "上下反転(&Y)"
        '
        'Diag_SaveFile
        '
        Me.Diag_SaveFile.DefaultExt = "bmp"
        Me.Diag_SaveFile.Filter = "BMPファイル|*.bmp|全てのファイル|*.*"
        '
        'Frm_Image
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(170, 94)
        Me.Controls.Add(Me.Pic_View)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Image"
        CType(Me.Pic_View, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PopupMenu_Image.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Pic_View As System.Windows.Forms.PictureBox
    Friend WithEvents PopupMenu_Image As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents Menu_Save As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Menu_FlipY As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Diag_SaveFile As System.Windows.Forms.SaveFileDialog
End Class
