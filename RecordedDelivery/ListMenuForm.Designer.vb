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
        Me.ReceiptReprint = New System.Windows.Forms.Button()
        Me.BtnJobDayReport = New System.Windows.Forms.Button()
        Me.BtnBranchTotal = New System.Windows.Forms.Button()
        Me.BtnJobRecordList = New System.Windows.Forms.Button()
        Me.BtnCsvOutPut = New System.Windows.Forms.Button()
        Me.BtnConfirmKetuban = New System.Windows.Forms.Button()
        Me.BtnCsvInPut = New System.Windows.Forms.Button()
        Me.BtnBack = New System.Windows.Forms.Button()
        Me.LblOperatorName = New System.Windows.Forms.Label()
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
        'ReceiptReprint
        '
        Me.ReceiptReprint.Font = New System.Drawing.Font("メイリオ", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ReceiptReprint.Location = New System.Drawing.Point(205, 151)
        Me.ReceiptReprint.Name = "ReceiptReprint"
        Me.ReceiptReprint.Size = New System.Drawing.Size(700, 180)
        Me.ReceiptReprint.TabIndex = 12
        Me.ReceiptReprint.Text = "受　領　証　再　発　行"
        Me.ReceiptReprint.UseVisualStyleBackColor = True
        '
        'BtnJobDayReport
        '
        Me.BtnJobDayReport.Font = New System.Drawing.Font("メイリオ", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnJobDayReport.Location = New System.Drawing.Point(980, 151)
        Me.BtnJobDayReport.Name = "BtnJobDayReport"
        Me.BtnJobDayReport.Size = New System.Drawing.Size(700, 180)
        Me.BtnJobDayReport.TabIndex = 13
        Me.BtnJobDayReport.Text = "作　業　日　報"
        Me.BtnJobDayReport.UseVisualStyleBackColor = True
        '
        'BtnBranchTotal
        '
        Me.BtnBranchTotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.BtnBranchTotal.Font = New System.Drawing.Font("メイリオ", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnBranchTotal.Location = New System.Drawing.Point(205, 353)
        Me.BtnBranchTotal.Name = "BtnBranchTotal"
        Me.BtnBranchTotal.Size = New System.Drawing.Size(700, 180)
        Me.BtnBranchTotal.TabIndex = 14
        Me.BtnBranchTotal.Text = "支　店　集　計　表"
        Me.BtnBranchTotal.UseVisualStyleBackColor = False
        '
        'BtnJobRecordList
        '
        Me.BtnJobRecordList.Font = New System.Drawing.Font("メイリオ", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnJobRecordList.Location = New System.Drawing.Point(980, 353)
        Me.BtnJobRecordList.Name = "BtnJobRecordList"
        Me.BtnJobRecordList.Size = New System.Drawing.Size(700, 180)
        Me.BtnJobRecordList.TabIndex = 15
        Me.BtnJobRecordList.Text = "運　用　記　録　リ　ス　ト"
        Me.BtnJobRecordList.UseVisualStyleBackColor = True
        '
        'BtnCsvOutPut
        '
        Me.BtnCsvOutPut.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.BtnCsvOutPut.Font = New System.Drawing.Font("メイリオ", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnCsvOutPut.Location = New System.Drawing.Point(205, 555)
        Me.BtnCsvOutPut.Name = "BtnCsvOutPut"
        Me.BtnCsvOutPut.Size = New System.Drawing.Size(700, 180)
        Me.BtnCsvOutPut.TabIndex = 16
        Me.BtnCsvOutPut.Text = "集　計　Ｃ　Ｓ　Ｖ　出　力"
        Me.BtnCsvOutPut.UseVisualStyleBackColor = False
        '
        'BtnConfirmKetuban
        '
        Me.BtnConfirmKetuban.Font = New System.Drawing.Font("メイリオ", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnConfirmKetuban.Location = New System.Drawing.Point(980, 555)
        Me.BtnConfirmKetuban.Name = "BtnConfirmKetuban"
        Me.BtnConfirmKetuban.Size = New System.Drawing.Size(700, 180)
        Me.BtnConfirmKetuban.TabIndex = 21
        Me.BtnConfirmKetuban.Text = "欠　番　確　認　表"
        Me.BtnConfirmKetuban.UseVisualStyleBackColor = True
        '
        'BtnCsvInPut
        '
        Me.BtnCsvInPut.Font = New System.Drawing.Font("メイリオ", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnCsvInPut.Location = New System.Drawing.Point(205, 758)
        Me.BtnCsvInPut.Name = "BtnCsvInPut"
        Me.BtnCsvInPut.Size = New System.Drawing.Size(700, 180)
        Me.BtnCsvInPut.TabIndex = 20
        Me.BtnCsvInPut.Text = "集　計　C　S　V　取　込"
        Me.BtnCsvInPut.UseVisualStyleBackColor = True
        Me.BtnCsvInPut.Visible = False
        '
        'BtnBack
        '
        Me.BtnBack.Font = New System.Drawing.Font("メイリオ", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnBack.Location = New System.Drawing.Point(980, 758)
        Me.BtnBack.Name = "BtnBack"
        Me.BtnBack.Size = New System.Drawing.Size(700, 180)
        Me.BtnBack.TabIndex = 22
        Me.BtnBack.Text = "戻　　　　る"
        Me.BtnBack.UseVisualStyleBackColor = True
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
