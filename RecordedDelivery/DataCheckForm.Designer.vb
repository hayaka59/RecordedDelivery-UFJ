<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DataCheckForm
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
        Me.lstGetDataView = New System.Windows.Forms.ListView()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TxtBranch = New System.Windows.Forms.TextBox()
        Me.BtnSearch = New System.Windows.Forms.Button()
        Me.LblOperatorName = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.lblCurrentDate = New System.Windows.Forms.Label()
        Me.BtnBack = New System.Windows.Forms.Button()
        Me.BtnDisplay = New System.Windows.Forms.Button()
        Me.TxtYoteiTusu = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.LblMessage = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lstGetDataView
        '
        Me.lstGetDataView.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lstGetDataView.FullRowSelect = True
        Me.lstGetDataView.GridLines = True
        Me.lstGetDataView.Location = New System.Drawing.Point(29, 217)
        Me.lstGetDataView.MultiSelect = False
        Me.lstGetDataView.Name = "lstGetDataView"
        Me.lstGetDataView.Size = New System.Drawing.Size(557, 207)
        Me.lstGetDataView.TabIndex = 163
        Me.lstGetDataView.UseCompatibleStateImageBehavior = False
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label16.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(29, 119)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(181, 35)
        Me.Label16.TabIndex = 159
        Me.Label16.Text = "支店コード"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtBranch
        '
        Me.TxtBranch.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TxtBranch.Location = New System.Drawing.Point(211, 118)
        Me.TxtBranch.MaxLength = 4
        Me.TxtBranch.Name = "TxtBranch"
        Me.TxtBranch.Size = New System.Drawing.Size(153, 36)
        Me.TxtBranch.TabIndex = 1
        Me.TxtBranch.Text = "1234567890"
        Me.TxtBranch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'BtnSearch
        '
        Me.BtnSearch.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnSearch.Location = New System.Drawing.Point(416, 118)
        Me.BtnSearch.Name = "BtnSearch"
        Me.BtnSearch.Size = New System.Drawing.Size(120, 50)
        Me.BtnSearch.TabIndex = 2
        Me.BtnSearch.Text = "検索"
        Me.BtnSearch.UseVisualStyleBackColor = True
        '
        'LblOperatorName
        '
        Me.LblOperatorName.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblOperatorName.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblOperatorName.ForeColor = System.Drawing.Color.White
        Me.LblOperatorName.Location = New System.Drawing.Point(387, 3)
        Me.LblOperatorName.Name = "LblOperatorName"
        Me.LblOperatorName.Size = New System.Drawing.Size(224, 33)
        Me.LblOperatorName.TabIndex = 157
        Me.LblOperatorName.Text = "LblOperatorName"
        Me.LblOperatorName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblTitle.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(-1, 0)
        Me.lblTitle.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(626, 36)
        Me.lblTitle.TabIndex = 156
        Me.lblTitle.Text = "　データ確認・抜取り"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CalendarFont = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.DateTimePicker1.Location = New System.Drawing.Point(211, 75)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(184, 31)
        Me.DateTimePicker1.TabIndex = 6
        '
        'lblCurrentDate
        '
        Me.lblCurrentDate.BackColor = System.Drawing.SystemColors.Control
        Me.lblCurrentDate.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblCurrentDate.ForeColor = System.Drawing.Color.Black
        Me.lblCurrentDate.Location = New System.Drawing.Point(401, 42)
        Me.lblCurrentDate.Name = "lblCurrentDate"
        Me.lblCurrentDate.Size = New System.Drawing.Size(206, 36)
        Me.lblCurrentDate.TabIndex = 154
        Me.lblCurrentDate.Text = "処理日"
        Me.lblCurrentDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BtnBack
        '
        Me.BtnBack.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnBack.Location = New System.Drawing.Point(416, 467)
        Me.BtnBack.Name = "BtnBack"
        Me.BtnBack.Size = New System.Drawing.Size(120, 50)
        Me.BtnBack.TabIndex = 5
        Me.BtnBack.Text = "戻る"
        Me.BtnBack.UseVisualStyleBackColor = True
        '
        'BtnDisplay
        '
        Me.BtnDisplay.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnDisplay.Location = New System.Drawing.Point(256, 467)
        Me.BtnDisplay.Name = "BtnDisplay"
        Me.BtnDisplay.Size = New System.Drawing.Size(120, 50)
        Me.BtnDisplay.TabIndex = 4
        Me.BtnDisplay.Text = "画面表示"
        Me.BtnDisplay.UseVisualStyleBackColor = True
        '
        'TxtYoteiTusu
        '
        Me.TxtYoteiTusu.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TxtYoteiTusu.Location = New System.Drawing.Point(211, 167)
        Me.TxtYoteiTusu.MaxLength = 6
        Me.TxtYoteiTusu.Name = "TxtYoteiTusu"
        Me.TxtYoteiTusu.Size = New System.Drawing.Size(124, 36)
        Me.TxtYoteiTusu.TabIndex = 3
        Me.TxtYoteiTusu.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label20.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.White
        Me.Label20.Location = New System.Drawing.Point(29, 167)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(181, 35)
        Me.Label20.TabIndex = 150
        Me.Label20.Text = "処理予定通数"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label14.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(29, 74)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(181, 33)
        Me.Label14.TabIndex = 149
        Me.Label14.Text = "処理日"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblMessage
        '
        Me.LblMessage.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblMessage.ForeColor = System.Drawing.Color.Red
        Me.LblMessage.Location = New System.Drawing.Point(30, 427)
        Me.LblMessage.Name = "LblMessage"
        Me.LblMessage.Size = New System.Drawing.Size(556, 33)
        Me.LblMessage.TabIndex = 164
        Me.LblMessage.Text = "LblMessage"
        Me.LblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DataCheckForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 24.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(623, 545)
        Me.ControlBox = False
        Me.Controls.Add(Me.LblMessage)
        Me.Controls.Add(Me.lstGetDataView)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.TxtBranch)
        Me.Controls.Add(Me.BtnSearch)
        Me.Controls.Add(Me.LblOperatorName)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.lblCurrentDate)
        Me.Controls.Add(Me.BtnBack)
        Me.Controls.Add(Me.BtnDisplay)
        Me.Controls.Add(Me.TxtYoteiTusu)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label14)
        Me.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DataCheckForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "データ確認・抜取り"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lstGetDataView As System.Windows.Forms.ListView
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents TxtBranch As System.Windows.Forms.TextBox
    Friend WithEvents BtnSearch As System.Windows.Forms.Button
    Friend WithEvents LblOperatorName As System.Windows.Forms.Label
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblCurrentDate As System.Windows.Forms.Label
    Friend WithEvents BtnBack As System.Windows.Forms.Button
    Friend WithEvents BtnDisplay As System.Windows.Forms.Button
    Friend WithEvents TxtYoteiTusu As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents LblMessage As System.Windows.Forms.Label
End Class
