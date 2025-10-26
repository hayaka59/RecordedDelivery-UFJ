<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListMenuForm
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
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.BtnConfirmKetuban = New System.Windows.Forms.Button()
        Me.LblOperatorName = New System.Windows.Forms.Label()
        Me.BtnBack = New System.Windows.Forms.Button()
        Me.BtnCsvInPut = New System.Windows.Forms.Button()
        Me.BtnCsvOutPut = New System.Windows.Forms.Button()
        Me.BtnJobRecordList = New System.Windows.Forms.Button()
        Me.BtnBranchTotal = New System.Windows.Forms.Button()
        Me.BtnJobDayReport = New System.Windows.Forms.Button()
        Me.ReceiptReprint = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblTitle.Font = New System.Drawing.Font("メイリオ", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(-2, 3)
        Me.lblTitle.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(1916, 85)
        Me.lblTitle.TabIndex = 3
        Me.lblTitle.Text = "リスト・レポート印刷メニュー"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnConfirmKetuban
        '
        Me.BtnConfirmKetuban.Font = New System.Drawing.Font("メイリオ", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnConfirmKetuban.Image = Global.RecordedDelivery.My.Resources.Resources.keybord
        Me.BtnConfirmKetuban.Location = New System.Drawing.Point(980, 555)
        Me.BtnConfirmKetuban.Name = "BtnConfirmKetuban"
        Me.BtnConfirmKetuban.Size = New System.Drawing.Size(700, 180)
        Me.BtnConfirmKetuban.TabIndex = 21
        Me.BtnConfirmKetuban.Text = "欠番確認表"
        Me.BtnConfirmKetuban.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnConfirmKetuban.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnConfirmKetuban.UseVisualStyleBackColor = True
        '
        'LblOperatorName
        '
        Me.LblOperatorName.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblOperatorName.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblOperatorName.ForeColor = System.Drawing.Color.White
        Me.LblOperatorName.Location = New System.Drawing.Point(1557, 32)
        Me.LblOperatorName.Name = "LblOperatorName"
        Me.LblOperatorName.Size = New System.Drawing.Size(345, 33)
        Me.LblOperatorName.TabIndex = 23
        Me.LblOperatorName.Text = "LblOperatorName"
        Me.LblOperatorName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnBack
        '
        Me.BtnBack.Font = New System.Drawing.Font("メイリオ", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnBack.Image = Global.RecordedDelivery.My.Resources.Resources.back_big
        Me.BtnBack.Location = New System.Drawing.Point(980, 758)
        Me.BtnBack.Name = "BtnBack"
        Me.BtnBack.Size = New System.Drawing.Size(700, 180)
        Me.BtnBack.TabIndex = 22
        Me.BtnBack.Text = "戻　る"
        Me.BtnBack.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnBack.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnBack.UseVisualStyleBackColor = True
        '
        'BtnCsvInPut
        '
        Me.BtnCsvInPut.Font = New System.Drawing.Font("メイリオ", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnCsvInPut.Image = Global.RecordedDelivery.My.Resources.Resources.document
        Me.BtnCsvInPut.Location = New System.Drawing.Point(205, 758)
        Me.BtnCsvInPut.Name = "BtnCsvInPut"
        Me.BtnCsvInPut.Size = New System.Drawing.Size(700, 180)
        Me.BtnCsvInPut.TabIndex = 20
        Me.BtnCsvInPut.Text = "集計CSV取込"
        Me.BtnCsvInPut.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnCsvInPut.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnCsvInPut.UseVisualStyleBackColor = True
        Me.BtnCsvInPut.Visible = False
        '
        'BtnCsvOutPut
        '
        Me.BtnCsvOutPut.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.BtnCsvOutPut.Font = New System.Drawing.Font("メイリオ", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnCsvOutPut.Image = Global.RecordedDelivery.My.Resources.Resources.document
        Me.BtnCsvOutPut.Location = New System.Drawing.Point(205, 555)
        Me.BtnCsvOutPut.Name = "BtnCsvOutPut"
        Me.BtnCsvOutPut.Size = New System.Drawing.Size(700, 180)
        Me.BtnCsvOutPut.TabIndex = 16
        Me.BtnCsvOutPut.Text = "集計ＣＳＶ出力"
        Me.BtnCsvOutPut.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnCsvOutPut.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnCsvOutPut.UseVisualStyleBackColor = False
        '
        'BtnJobRecordList
        '
        Me.BtnJobRecordList.Font = New System.Drawing.Font("メイリオ", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnJobRecordList.Image = Global.RecordedDelivery.My.Resources.Resources.printer
        Me.BtnJobRecordList.Location = New System.Drawing.Point(980, 353)
        Me.BtnJobRecordList.Name = "BtnJobRecordList"
        Me.BtnJobRecordList.Size = New System.Drawing.Size(700, 180)
        Me.BtnJobRecordList.TabIndex = 15
        Me.BtnJobRecordList.Text = "運用記録リスト"
        Me.BtnJobRecordList.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnJobRecordList.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnJobRecordList.UseVisualStyleBackColor = True
        '
        'BtnBranchTotal
        '
        Me.BtnBranchTotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.BtnBranchTotal.Font = New System.Drawing.Font("メイリオ", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnBranchTotal.Image = Global.RecordedDelivery.My.Resources.Resources.printer
        Me.BtnBranchTotal.Location = New System.Drawing.Point(205, 353)
        Me.BtnBranchTotal.Name = "BtnBranchTotal"
        Me.BtnBranchTotal.Size = New System.Drawing.Size(700, 180)
        Me.BtnBranchTotal.TabIndex = 14
        Me.BtnBranchTotal.Text = "支店集計表"
        Me.BtnBranchTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnBranchTotal.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnBranchTotal.UseVisualStyleBackColor = False
        '
        'BtnJobDayReport
        '
        Me.BtnJobDayReport.Font = New System.Drawing.Font("メイリオ", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnJobDayReport.Image = Global.RecordedDelivery.My.Resources.Resources.printer
        Me.BtnJobDayReport.Location = New System.Drawing.Point(980, 151)
        Me.BtnJobDayReport.Name = "BtnJobDayReport"
        Me.BtnJobDayReport.Size = New System.Drawing.Size(700, 180)
        Me.BtnJobDayReport.TabIndex = 13
        Me.BtnJobDayReport.Text = "作業日報"
        Me.BtnJobDayReport.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnJobDayReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnJobDayReport.UseVisualStyleBackColor = True
        '
        'ReceiptReprint
        '
        Me.ReceiptReprint.Font = New System.Drawing.Font("メイリオ", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ReceiptReprint.Image = Global.RecordedDelivery.My.Resources.Resources.printer
        Me.ReceiptReprint.Location = New System.Drawing.Point(205, 151)
        Me.ReceiptReprint.Name = "ReceiptReprint"
        Me.ReceiptReprint.Size = New System.Drawing.Size(700, 180)
        Me.ReceiptReprint.TabIndex = 12
        Me.ReceiptReprint.Text = "受領証再発行"
        Me.ReceiptReprint.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ReceiptReprint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ReceiptReprint.UseVisualStyleBackColor = True
        '
        'ListMenuForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 28.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1914, 1052)
        Me.Controls.Add(Me.LblOperatorName)
        Me.Controls.Add(Me.BtnBack)
        Me.Controls.Add(Me.BtnConfirmKetuban)
        Me.Controls.Add(Me.BtnCsvInPut)
        Me.Controls.Add(Me.BtnCsvOutPut)
        Me.Controls.Add(Me.BtnJobRecordList)
        Me.Controls.Add(Me.BtnBranchTotal)
        Me.Controls.Add(Me.BtnJobDayReport)
        Me.Controls.Add(Me.ReceiptReprint)
        Me.Controls.Add(Me.lblTitle)
        Me.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(6, 7, 6, 7)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ListMenuForm"
        Me.Text = "リスト・レポート印刷メニュー"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents ReceiptReprint As System.Windows.Forms.Button
    Friend WithEvents BtnJobDayReport As System.Windows.Forms.Button
    Friend WithEvents BtnBranchTotal As System.Windows.Forms.Button
    Friend WithEvents BtnJobRecordList As System.Windows.Forms.Button
    Friend WithEvents BtnCsvOutPut As System.Windows.Forms.Button
    Friend WithEvents BtnConfirmKetuban As System.Windows.Forms.Button
    Friend WithEvents BtnCsvInPut As System.Windows.Forms.Button
    Friend WithEvents BtnBack As System.Windows.Forms.Button
    Friend WithEvents LblOperatorName As System.Windows.Forms.Label
End Class
