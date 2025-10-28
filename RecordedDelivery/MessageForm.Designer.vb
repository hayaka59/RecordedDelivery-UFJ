<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MessageForm
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.BtnOK = New System.Windows.Forms.Button()
        Me.LblMessage = New System.Windows.Forms.Label()
        Me.BtnNo = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'BtnOK
        '
        Me.BtnOK.Image = Global.RecordedDelivery.My.Resources.Resources.check_ok
        Me.BtnOK.Location = New System.Drawing.Point(155, 117)
        Me.BtnOK.Name = "BtnOK"
        Me.BtnOK.Size = New System.Drawing.Size(177, 53)
        Me.BtnOK.TabIndex = 2
        Me.BtnOK.Text = "はい"
        Me.BtnOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnOK.UseVisualStyleBackColor = True
        '
        'LblMessage
        '
        Me.LblMessage.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblMessage.Location = New System.Drawing.Point(12, 20)
        Me.LblMessage.Name = "LblMessage"
        Me.LblMessage.Size = New System.Drawing.Size(707, 81)
        Me.LblMessage.TabIndex = 3
        Me.LblMessage.Text = "LblMessage"
        Me.LblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnNo
        '
        Me.BtnNo.Image = Global.RecordedDelivery.My.Resources.Resources.cancel
        Me.BtnNo.Location = New System.Drawing.Point(395, 117)
        Me.BtnNo.Name = "BtnNo"
        Me.BtnNo.Size = New System.Drawing.Size(177, 53)
        Me.BtnNo.TabIndex = 4
        Me.BtnNo.Text = "いいえ"
        Me.BtnNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnNo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnNo.UseVisualStyleBackColor = True
        '
        'MessageForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 28.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(731, 196)
        Me.ControlBox = False
        Me.Controls.Add(Me.BtnNo)
        Me.Controls.Add(Me.LblMessage)
        Me.Controls.Add(Me.BtnOK)
        Me.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(6, 7, 6, 7)
        Me.Name = "MessageForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "確認メッセージ"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BtnOK As System.Windows.Forms.Button
    Friend WithEvents LblMessage As System.Windows.Forms.Label
    Friend WithEvents BtnNo As System.Windows.Forms.Button
End Class
