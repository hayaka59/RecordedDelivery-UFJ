<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ErrorForm
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
        Me.lblErrorTitle = New System.Windows.Forms.Label()
        Me.lblErrorMsg = New System.Windows.Forms.Label()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblErrorTitle
        '
        Me.lblErrorTitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblErrorTitle.Font = New System.Drawing.Font("メイリオ", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblErrorTitle.ForeColor = System.Drawing.Color.White
        Me.lblErrorTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblErrorTitle.Name = "lblErrorTitle"
        Me.lblErrorTitle.Size = New System.Drawing.Size(854, 63)
        Me.lblErrorTitle.TabIndex = 0
        Me.lblErrorTitle.Text = "lblErrorTitle"
        Me.lblErrorTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblErrorMsg
        '
        Me.lblErrorMsg.Font = New System.Drawing.Font("メイリオ", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblErrorMsg.Location = New System.Drawing.Point(11, 83)
        Me.lblErrorMsg.Name = "lblErrorMsg"
        Me.lblErrorMsg.Size = New System.Drawing.Size(828, 97)
        Me.lblErrorMsg.TabIndex = 1
        Me.lblErrorMsg.Text = "lblErrorMsg"
        Me.lblErrorMsg.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnOK
        '
        Me.btnOK.Font = New System.Drawing.Font("メイリオ", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnOK.Image = Global.RecordedDelivery.My.Resources.Resources.check_ok
        Me.btnOK.Location = New System.Drawing.Point(280, 195)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(308, 65)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "ＯＫ"
        Me.btnOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'ErrorForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(15.0!, 36.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(854, 296)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.lblErrorMsg)
        Me.Controls.Add(Me.lblErrorTitle)
        Me.Font = New System.Drawing.Font("メイリオ", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(8, 9, 8, 9)
        Me.Name = "ErrorForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "エラー表示"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblErrorTitle As System.Windows.Forms.Label
    Friend WithEvents lblErrorMsg As System.Windows.Forms.Label
    Friend WithEvents btnOK As System.Windows.Forms.Button
End Class
