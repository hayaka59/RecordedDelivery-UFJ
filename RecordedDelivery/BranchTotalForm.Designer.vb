<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BranchTotalForm
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
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.lblCurrentDate = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.BtnBack = New System.Windows.Forms.Button()
        Me.BtnPrint = New System.Windows.Forms.Button()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.LblOperatorName = New System.Windows.Forms.Label()
        Me.lstGetDataView = New System.Windows.Forms.ListView()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.SuspendLayout
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CalendarFont = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.DateTimePicker1.Location = New System.Drawing.Point(256, 76)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(210, 36)
        Me.DateTimePicker1.TabIndex = 130
        '
        'lblCurrentDate
        '
        Me.lblCurrentDate.BackColor = System.Drawing.SystemColors.Control
        Me.lblCurrentDate.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblCurrentDate.ForeColor = System.Drawing.Color.Black
        Me.lblCurrentDate.Location = New System.Drawing.Point(313, 42)
        Me.lblCurrentDate.Name = "lblCurrentDate"
        Me.lblCurrentDate.Size = New System.Drawing.Size(265, 29)
        Me.lblCurrentDate.TabIndex = 129
        Me.lblCurrentDate.Text = "処理日"
        Me.lblCurrentDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.FromArgb(CType(CType(128,Byte),Integer), CType(CType(128,Byte),Integer), CType(CType(255,Byte),Integer))
        Me.Label14.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(57, 76)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(197, 36)
        Me.Label14.TabIndex = 122
        Me.Label14.Text = "集 計 対 象 日"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnBack
        '
        Me.BtnBack.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.BtnBack.Location = New System.Drawing.Point(384, 139)
        Me.BtnBack.Name = "BtnBack"
        Me.BtnBack.Size = New System.Drawing.Size(150, 40)
        Me.BtnBack.TabIndex = 136
        Me.BtnBack.Text = "戻る"
        Me.BtnBack.UseVisualStyleBackColor = true
        '
        'BtnPrint
        '
        Me.BtnPrint.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.BtnPrint.Location = New System.Drawing.Point(221, 139)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(150, 40)
        Me.BtnPrint.TabIndex = 135
        Me.BtnPrint.Text = "印刷"
        Me.BtnPrint.UseVisualStyleBackColor = true
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(128,Byte),Integer), CType(CType(128,Byte),Integer), CType(CType(255,Byte),Integer))
        Me.lblTitle.Font = New System.Drawing.Font("メイリオ", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblTitle.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(604, 36)
        Me.lblTitle.TabIndex = 140
        Me.lblTitle.Text = "　配達内容集計支店コード検索"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblOperatorName
        '
        Me.LblOperatorName.BackColor = System.Drawing.Color.FromArgb(CType(CType(128,Byte),Integer), CType(CType(128,Byte),Integer), CType(CType(255,Byte),Integer))
        Me.LblOperatorName.Font = New System.Drawing.Font("メイリオ", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.LblOperatorName.ForeColor = System.Drawing.Color.White
        Me.LblOperatorName.Location = New System.Drawing.Point(375, 3)
        Me.LblOperatorName.Name = "LblOperatorName"
        Me.LblOperatorName.Size = New System.Drawing.Size(224, 33)
        Me.LblOperatorName.TabIndex = 141
        Me.LblOperatorName.Text = "LblOperatorName"
        Me.LblOperatorName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lstGetDataView
        '
        Me.lstGetDataView.Font = New System.Drawing.Font("メイリオ", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lstGetDataView.FullRowSelect = true
        Me.lstGetDataView.GridLines = true
        Me.lstGetDataView.Location = New System.Drawing.Point(6, 198)
        Me.lstGetDataView.MultiSelect = False
        Me.lstGetDataView.Name = "lstGetDataView"
        Me.lstGetDataView.Size = New System.Drawing.Size(594, 264)
        Me.lstGetDataView.TabIndex = 164
        Me.lstGetDataView.UseCompatibleStateImageBehavior = false
        '
        'PrintDocument1
        '
        '
        'BranchTotalForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12!, 28!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(604, 467)
        Me.ControlBox = false
        Me.Controls.Add(Me.lstGetDataView)
        Me.Controls.Add(Me.LblOperatorName)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.BtnBack)
        Me.Controls.Add(Me.BtnPrint)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.lblCurrentDate)
        Me.Controls.Add(Me.Label14)
        Me.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(6, 7, 6, 7)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "BranchTotalForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "配達内容集計支店コード検索"
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblCurrentDate As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents BtnBack As System.Windows.Forms.Button
    Friend WithEvents BtnPrint As System.Windows.Forms.Button
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents LblOperatorName As System.Windows.Forms.Label
    Friend WithEvents lstGetDataView As System.Windows.Forms.ListView
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
End Class
