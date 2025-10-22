<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class rePrintForm
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
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtStart = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtEnd = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtSum = New System.Windows.Forms.TextBox()
        Me.rdbOriginal = New System.Windows.Forms.RadioButton()
        Me.rdbReserve = New System.Windows.Forms.RadioButton()
        Me.rdbBoth = New System.Windows.Forms.RadioButton()
        Me.lblLastPage = New System.Windows.Forms.Label()
        Me.lblDataNum = New System.Windows.Forms.Label()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(68, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 28)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "最終頁"
        '
        'txtStart
        '
        Me.txtStart.Location = New System.Drawing.Point(143, 73)
        Me.txtStart.MaxLength = 3
        Me.txtStart.Name = "txtStart"
        Me.txtStart.Size = New System.Drawing.Size(66, 36)
        Me.txtStart.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(143, 193)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(177, 53)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "印刷"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(406, 193)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(177, 53)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "キャンセル"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(325, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(183, 28)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "最終頁内　データ数"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(68, 84)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 28)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "開始頁"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(273, 84)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 28)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "終了頁"
        '
        'txtEnd
        '
        Me.txtEnd.Location = New System.Drawing.Point(348, 73)
        Me.txtEnd.MaxLength = 3
        Me.txtEnd.Name = "txtEnd"
        Me.txtEnd.Size = New System.Drawing.Size(66, 36)
        Me.txtEnd.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(489, 81)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 28)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "総頁数"
        '
        'txtSum
        '
        Me.txtSum.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtSum.Enabled = False
        Me.txtSum.Location = New System.Drawing.Point(564, 73)
        Me.txtSum.MaxLength = 3
        Me.txtSum.Name = "txtSum"
        Me.txtSum.Size = New System.Drawing.Size(66, 36)
        Me.txtSum.TabIndex = 8
        '
        'rdbOriginal
        '
        Me.rdbOriginal.AutoSize = True
        Me.rdbOriginal.Location = New System.Drawing.Point(73, 137)
        Me.rdbOriginal.Name = "rdbOriginal"
        Me.rdbOriginal.Size = New System.Drawing.Size(144, 32)
        Me.rdbOriginal.TabIndex = 10
        Me.rdbOriginal.Text = "受領書　原符"
        Me.rdbOriginal.UseVisualStyleBackColor = True
        '
        'rdbReserve
        '
        Me.rdbReserve.AutoSize = True
        Me.rdbReserve.Location = New System.Drawing.Point(278, 137)
        Me.rdbReserve.Name = "rdbReserve"
        Me.rdbReserve.Size = New System.Drawing.Size(144, 32)
        Me.rdbReserve.TabIndex = 11
        Me.rdbReserve.Text = "受領書　控え"
        Me.rdbReserve.UseVisualStyleBackColor = True
        '
        'rdbBoth
        '
        Me.rdbBoth.AutoSize = True
        Me.rdbBoth.Checked = True
        Me.rdbBoth.Location = New System.Drawing.Point(494, 137)
        Me.rdbBoth.Name = "rdbBoth"
        Me.rdbBoth.Size = New System.Drawing.Size(106, 32)
        Me.rdbBoth.TabIndex = 12
        Me.rdbBoth.TabStop = True
        Me.rdbBoth.Text = "両ページ"
        Me.rdbBoth.UseVisualStyleBackColor = True
        '
        'lblLastPage
        '
        Me.lblLastPage.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblLastPage.Location = New System.Drawing.Point(138, 31)
        Me.lblLastPage.Name = "lblLastPage"
        Me.lblLastPage.Size = New System.Drawing.Size(69, 28)
        Me.lblLastPage.TabIndex = 13
        Me.lblLastPage.Text = "lblLastPage"
        '
        'lblDataNum
        '
        Me.lblDataNum.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblDataNum.Location = New System.Drawing.Point(514, 31)
        Me.lblDataNum.Name = "lblDataNum"
        Me.lblDataNum.Size = New System.Drawing.Size(69, 28)
        Me.lblDataNum.TabIndex = 14
        Me.lblDataNum.Text = "lblDataNum"
        '
        'PrintDocument1
        '
        '
        'rePrintForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 28.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Silver
        Me.ClientSize = New System.Drawing.Size(731, 289)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblDataNum)
        Me.Controls.Add(Me.lblLastPage)
        Me.Controls.Add(Me.rdbBoth)
        Me.Controls.Add(Me.rdbReserve)
        Me.Controls.Add(Me.rdbOriginal)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtSum)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtEnd)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtStart)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Margin = New System.Windows.Forms.Padding(6, 7, 6, 7)
        Me.Name = "rePrintForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "印刷（受領書再発行）"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtStart As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtEnd As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtSum As System.Windows.Forms.TextBox
    Friend WithEvents rdbOriginal As System.Windows.Forms.RadioButton
    Friend WithEvents rdbReserve As System.Windows.Forms.RadioButton
    Friend WithEvents rdbBoth As System.Windows.Forms.RadioButton
    Friend WithEvents lblLastPage As System.Windows.Forms.Label
    Friend WithEvents lblDataNum As System.Windows.Forms.Label
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
End Class
