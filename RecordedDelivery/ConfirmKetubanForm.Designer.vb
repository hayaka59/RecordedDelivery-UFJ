<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConfirmKetubanForm
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
        Me.LblOperatorName = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.BtnBack = New System.Windows.Forms.Button()
        Me.BtnPrint = New System.Windows.Forms.Button()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.lblCurrentDate = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.BtnConfNumber = New System.Windows.Forms.Button()
        Me.RdoKakitome = New System.Windows.Forms.RadioButton()
        Me.RdoYuMail = New System.Windows.Forms.RadioButton()
        Me.RdoTokutei = New System.Windows.Forms.RadioButton()
        Me.lblKakiAcNumS4 = New System.Windows.Forms.Label()
        Me.lblKakiAcNumS3 = New System.Windows.Forms.Label()
        Me.lblKakiAcNumS2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblKakiAcNumS1 = New System.Windows.Forms.Label()
        Me.lblKakiAcNumE4 = New System.Windows.Forms.Label()
        Me.lblKakiAcNumE3 = New System.Windows.Forms.Label()
        Me.lblKakiAcNumE2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblKakiAcNumE1 = New System.Windows.Forms.Label()
        Me.lblYumeAcNumE4 = New System.Windows.Forms.Label()
        Me.lblYumeAcNumE3 = New System.Windows.Forms.Label()
        Me.lblYumeAcNumE2 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblYumeAcNumE1 = New System.Windows.Forms.Label()
        Me.lblYumeAcNumS4 = New System.Windows.Forms.Label()
        Me.lblYumeAcNumS3 = New System.Windows.Forms.Label()
        Me.lblYumeAcNumS2 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.lblYumeAcNumS1 = New System.Windows.Forms.Label()
        Me.lblTokuAcNumE4 = New System.Windows.Forms.Label()
        Me.lblTokuAcNumE3 = New System.Windows.Forms.Label()
        Me.lblTokuAcNumE2 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.lblTokuAcNumE1 = New System.Windows.Forms.Label()
        Me.lblTokuAcNumS4 = New System.Windows.Forms.Label()
        Me.lblTokuAcNumS3 = New System.Windows.Forms.Label()
        Me.lblTokuAcNumS2 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.lblTokuAcNumS1 = New System.Windows.Forms.Label()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.SuspendLayout()
        '
        'LblOperatorName
        '
        Me.LblOperatorName.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblOperatorName.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblOperatorName.ForeColor = System.Drawing.Color.White
        Me.LblOperatorName.Location = New System.Drawing.Point(375, 3)
        Me.LblOperatorName.Name = "LblOperatorName"
        Me.LblOperatorName.Size = New System.Drawing.Size(224, 33)
        Me.LblOperatorName.TabIndex = 155
        Me.LblOperatorName.Text = "LblOperatorName"
        Me.LblOperatorName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblTitle.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblTitle.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(604, 36)
        Me.lblTitle.TabIndex = 154
        Me.lblTitle.Text = "　欠番確認表"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtnBack
        '
        Me.BtnBack.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnBack.Image = Global.RecordedDelivery.My.Resources.Resources.back_small
        Me.BtnBack.Location = New System.Drawing.Point(390, 524)
        Me.BtnBack.Name = "BtnBack"
        Me.BtnBack.Size = New System.Drawing.Size(170, 45)
        Me.BtnBack.TabIndex = 153
        Me.BtnBack.Text = "戻る"
        Me.BtnBack.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnBack.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnBack.UseVisualStyleBackColor = True
        '
        'BtnPrint
        '
        Me.BtnPrint.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnPrint.Image = Global.RecordedDelivery.My.Resources.Resources.printer_small
        Me.BtnPrint.Location = New System.Drawing.Point(212, 524)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(170, 45)
        Me.BtnPrint.TabIndex = 152
        Me.BtnPrint.Text = "印刷"
        Me.BtnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnPrint.UseVisualStyleBackColor = True
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CalendarFont = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.DateTimePicker1.Location = New System.Drawing.Point(212, 76)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(210, 36)
        Me.DateTimePicker1.TabIndex = 151
        '
        'lblCurrentDate
        '
        Me.lblCurrentDate.BackColor = System.Drawing.SystemColors.Control
        Me.lblCurrentDate.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblCurrentDate.ForeColor = System.Drawing.Color.Black
        Me.lblCurrentDate.Location = New System.Drawing.Point(313, 42)
        Me.lblCurrentDate.Name = "lblCurrentDate"
        Me.lblCurrentDate.Size = New System.Drawing.Size(265, 29)
        Me.lblCurrentDate.TabIndex = 150
        Me.lblCurrentDate.Text = "lblCurrentDate"
        Me.lblCurrentDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label14.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(78, 76)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(134, 36)
        Me.Label14.TabIndex = 149
        Me.Label14.Text = "処　理　日"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnConfNumber
        '
        Me.BtnConfNumber.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnConfNumber.Image = Global.RecordedDelivery.My.Resources.Resources.check_ok
        Me.BtnConfNumber.Location = New System.Drawing.Point(390, 118)
        Me.BtnConfNumber.Name = "BtnConfNumber"
        Me.BtnConfNumber.Size = New System.Drawing.Size(170, 45)
        Me.BtnConfNumber.TabIndex = 157
        Me.BtnConfNumber.Text = "番号帯確認"
        Me.BtnConfNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnConfNumber.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnConfNumber.UseVisualStyleBackColor = True
        '
        'RdoKakitome
        '
        Me.RdoKakitome.Checked = True
        Me.RdoKakitome.Location = New System.Drawing.Point(56, 152)
        Me.RdoKakitome.Name = "RdoKakitome"
        Me.RdoKakitome.Size = New System.Drawing.Size(316, 28)
        Me.RdoKakitome.TabIndex = 158
        Me.RdoKakitome.TabStop = True
        Me.RdoKakitome.Text = "書留郵便引受番号の番号帯"
        Me.RdoKakitome.UseVisualStyleBackColor = True
        '
        'RdoYuMail
        '
        Me.RdoYuMail.Location = New System.Drawing.Point(56, 382)
        Me.RdoYuMail.Name = "RdoYuMail"
        Me.RdoYuMail.Size = New System.Drawing.Size(316, 28)
        Me.RdoYuMail.TabIndex = 159
        Me.RdoYuMail.Text = "ゆうメール引受番号の番号帯"
        Me.RdoYuMail.UseVisualStyleBackColor = True
        '
        'RdoTokutei
        '
        Me.RdoTokutei.Location = New System.Drawing.Point(56, 267)
        Me.RdoTokutei.Name = "RdoTokutei"
        Me.RdoTokutei.Size = New System.Drawing.Size(316, 28)
        Me.RdoTokutei.TabIndex = 160
        Me.RdoTokutei.Text = "特定記録引受番号の番号帯"
        Me.RdoTokutei.UseVisualStyleBackColor = True
        '
        'lblKakiAcNumS4
        '
        Me.lblKakiAcNumS4.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblKakiAcNumS4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblKakiAcNumS4.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblKakiAcNumS4.Location = New System.Drawing.Point(446, 184)
        Me.lblKakiAcNumS4.Name = "lblKakiAcNumS4"
        Me.lblKakiAcNumS4.Size = New System.Drawing.Size(34, 30)
        Me.lblKakiAcNumS4.TabIndex = 164
        Me.lblKakiAcNumS4.Text = "9"
        Me.lblKakiAcNumS4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblKakiAcNumS3
        '
        Me.lblKakiAcNumS3.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblKakiAcNumS3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblKakiAcNumS3.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblKakiAcNumS3.Location = New System.Drawing.Point(350, 184)
        Me.lblKakiAcNumS3.Name = "lblKakiAcNumS3"
        Me.lblKakiAcNumS3.Size = New System.Drawing.Size(90, 30)
        Me.lblKakiAcNumS3.TabIndex = 163
        Me.lblKakiAcNumS3.Text = "99999"
        Me.lblKakiAcNumS3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblKakiAcNumS2
        '
        Me.lblKakiAcNumS2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblKakiAcNumS2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblKakiAcNumS2.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblKakiAcNumS2.Location = New System.Drawing.Point(293, 184)
        Me.lblKakiAcNumS2.Name = "lblKakiAcNumS2"
        Me.lblKakiAcNumS2.Size = New System.Drawing.Size(51, 30)
        Me.lblKakiAcNumS2.TabIndex = 162
        Me.lblKakiAcNumS2.Text = "99"
        Me.lblKakiAcNumS2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label4.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(78, 184)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(134, 30)
        Me.Label4.TabIndex = 165
        Me.Label4.Text = "開 始 番 号"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblKakiAcNumS1
        '
        Me.lblKakiAcNumS1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblKakiAcNumS1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblKakiAcNumS1.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblKakiAcNumS1.Location = New System.Drawing.Point(218, 184)
        Me.lblKakiAcNumS1.Name = "lblKakiAcNumS1"
        Me.lblKakiAcNumS1.Size = New System.Drawing.Size(69, 30)
        Me.lblKakiAcNumS1.TabIndex = 161
        Me.lblKakiAcNumS1.Text = "999"
        Me.lblKakiAcNumS1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblKakiAcNumE4
        '
        Me.lblKakiAcNumE4.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblKakiAcNumE4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblKakiAcNumE4.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblKakiAcNumE4.Location = New System.Drawing.Point(446, 223)
        Me.lblKakiAcNumE4.Name = "lblKakiAcNumE4"
        Me.lblKakiAcNumE4.Size = New System.Drawing.Size(34, 30)
        Me.lblKakiAcNumE4.TabIndex = 169
        Me.lblKakiAcNumE4.Text = "9"
        Me.lblKakiAcNumE4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblKakiAcNumE3
        '
        Me.lblKakiAcNumE3.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblKakiAcNumE3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblKakiAcNumE3.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblKakiAcNumE3.Location = New System.Drawing.Point(350, 223)
        Me.lblKakiAcNumE3.Name = "lblKakiAcNumE3"
        Me.lblKakiAcNumE3.Size = New System.Drawing.Size(90, 30)
        Me.lblKakiAcNumE3.TabIndex = 168
        Me.lblKakiAcNumE3.Text = "99999"
        Me.lblKakiAcNumE3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblKakiAcNumE2
        '
        Me.lblKakiAcNumE2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblKakiAcNumE2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblKakiAcNumE2.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblKakiAcNumE2.Location = New System.Drawing.Point(293, 223)
        Me.lblKakiAcNumE2.Name = "lblKakiAcNumE2"
        Me.lblKakiAcNumE2.Size = New System.Drawing.Size(51, 30)
        Me.lblKakiAcNumE2.TabIndex = 167
        Me.lblKakiAcNumE2.Text = "99"
        Me.lblKakiAcNumE2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label5.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(78, 223)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(134, 30)
        Me.Label5.TabIndex = 170
        Me.Label5.Text = "終 了 番 号"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblKakiAcNumE1
        '
        Me.lblKakiAcNumE1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblKakiAcNumE1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblKakiAcNumE1.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblKakiAcNumE1.Location = New System.Drawing.Point(218, 223)
        Me.lblKakiAcNumE1.Name = "lblKakiAcNumE1"
        Me.lblKakiAcNumE1.Size = New System.Drawing.Size(69, 30)
        Me.lblKakiAcNumE1.TabIndex = 166
        Me.lblKakiAcNumE1.Text = "999"
        Me.lblKakiAcNumE1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblYumeAcNumE4
        '
        Me.lblYumeAcNumE4.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblYumeAcNumE4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblYumeAcNumE4.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblYumeAcNumE4.Location = New System.Drawing.Point(446, 453)
        Me.lblYumeAcNumE4.Name = "lblYumeAcNumE4"
        Me.lblYumeAcNumE4.Size = New System.Drawing.Size(34, 30)
        Me.lblYumeAcNumE4.TabIndex = 179
        Me.lblYumeAcNumE4.Text = "9"
        Me.lblYumeAcNumE4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblYumeAcNumE3
        '
        Me.lblYumeAcNumE3.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblYumeAcNumE3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblYumeAcNumE3.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblYumeAcNumE3.Location = New System.Drawing.Point(350, 453)
        Me.lblYumeAcNumE3.Name = "lblYumeAcNumE3"
        Me.lblYumeAcNumE3.Size = New System.Drawing.Size(90, 30)
        Me.lblYumeAcNumE3.TabIndex = 178
        Me.lblYumeAcNumE3.Text = "99999"
        Me.lblYumeAcNumE3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblYumeAcNumE2
        '
        Me.lblYumeAcNumE2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblYumeAcNumE2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblYumeAcNumE2.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblYumeAcNumE2.Location = New System.Drawing.Point(293, 453)
        Me.lblYumeAcNumE2.Name = "lblYumeAcNumE2"
        Me.lblYumeAcNumE2.Size = New System.Drawing.Size(51, 30)
        Me.lblYumeAcNumE2.TabIndex = 177
        Me.lblYumeAcNumE2.Text = "99"
        Me.lblYumeAcNumE2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label10.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(78, 453)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(134, 30)
        Me.Label10.TabIndex = 180
        Me.Label10.Text = "終 了 番 号"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblYumeAcNumE1
        '
        Me.lblYumeAcNumE1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblYumeAcNumE1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblYumeAcNumE1.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblYumeAcNumE1.Location = New System.Drawing.Point(218, 453)
        Me.lblYumeAcNumE1.Name = "lblYumeAcNumE1"
        Me.lblYumeAcNumE1.Size = New System.Drawing.Size(69, 30)
        Me.lblYumeAcNumE1.TabIndex = 176
        Me.lblYumeAcNumE1.Text = "999"
        Me.lblYumeAcNumE1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblYumeAcNumS4
        '
        Me.lblYumeAcNumS4.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblYumeAcNumS4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblYumeAcNumS4.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblYumeAcNumS4.Location = New System.Drawing.Point(446, 414)
        Me.lblYumeAcNumS4.Name = "lblYumeAcNumS4"
        Me.lblYumeAcNumS4.Size = New System.Drawing.Size(34, 30)
        Me.lblYumeAcNumS4.TabIndex = 174
        Me.lblYumeAcNumS4.Text = "9"
        Me.lblYumeAcNumS4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblYumeAcNumS3
        '
        Me.lblYumeAcNumS3.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblYumeAcNumS3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblYumeAcNumS3.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblYumeAcNumS3.Location = New System.Drawing.Point(350, 414)
        Me.lblYumeAcNumS3.Name = "lblYumeAcNumS3"
        Me.lblYumeAcNumS3.Size = New System.Drawing.Size(90, 30)
        Me.lblYumeAcNumS3.TabIndex = 173
        Me.lblYumeAcNumS3.Text = "99999"
        Me.lblYumeAcNumS3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblYumeAcNumS2
        '
        Me.lblYumeAcNumS2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblYumeAcNumS2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblYumeAcNumS2.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblYumeAcNumS2.Location = New System.Drawing.Point(293, 414)
        Me.lblYumeAcNumS2.Name = "lblYumeAcNumS2"
        Me.lblYumeAcNumS2.Size = New System.Drawing.Size(51, 30)
        Me.lblYumeAcNumS2.TabIndex = 172
        Me.lblYumeAcNumS2.Text = "99"
        Me.lblYumeAcNumS2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label16.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(78, 414)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(134, 30)
        Me.Label16.TabIndex = 175
        Me.Label16.Text = "開 始 番 号"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblYumeAcNumS1
        '
        Me.lblYumeAcNumS1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblYumeAcNumS1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblYumeAcNumS1.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblYumeAcNumS1.Location = New System.Drawing.Point(218, 414)
        Me.lblYumeAcNumS1.Name = "lblYumeAcNumS1"
        Me.lblYumeAcNumS1.Size = New System.Drawing.Size(69, 30)
        Me.lblYumeAcNumS1.TabIndex = 171
        Me.lblYumeAcNumS1.Text = "999"
        Me.lblYumeAcNumS1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTokuAcNumE4
        '
        Me.lblTokuAcNumE4.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblTokuAcNumE4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTokuAcNumE4.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblTokuAcNumE4.Location = New System.Drawing.Point(446, 340)
        Me.lblTokuAcNumE4.Name = "lblTokuAcNumE4"
        Me.lblTokuAcNumE4.Size = New System.Drawing.Size(34, 30)
        Me.lblTokuAcNumE4.TabIndex = 189
        Me.lblTokuAcNumE4.Text = "9"
        Me.lblTokuAcNumE4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTokuAcNumE3
        '
        Me.lblTokuAcNumE3.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblTokuAcNumE3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTokuAcNumE3.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblTokuAcNumE3.Location = New System.Drawing.Point(350, 340)
        Me.lblTokuAcNumE3.Name = "lblTokuAcNumE3"
        Me.lblTokuAcNumE3.Size = New System.Drawing.Size(90, 30)
        Me.lblTokuAcNumE3.TabIndex = 188
        Me.lblTokuAcNumE3.Text = "99999"
        Me.lblTokuAcNumE3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTokuAcNumE2
        '
        Me.lblTokuAcNumE2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblTokuAcNumE2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTokuAcNumE2.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblTokuAcNumE2.Location = New System.Drawing.Point(293, 340)
        Me.lblTokuAcNumE2.Name = "lblTokuAcNumE2"
        Me.lblTokuAcNumE2.Size = New System.Drawing.Size(51, 30)
        Me.lblTokuAcNumE2.TabIndex = 187
        Me.lblTokuAcNumE2.Text = "99"
        Me.lblTokuAcNumE2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label21.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.White
        Me.Label21.Location = New System.Drawing.Point(78, 340)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(134, 30)
        Me.Label21.TabIndex = 190
        Me.Label21.Text = "終 了 番 号"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTokuAcNumE1
        '
        Me.lblTokuAcNumE1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblTokuAcNumE1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTokuAcNumE1.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblTokuAcNumE1.Location = New System.Drawing.Point(218, 340)
        Me.lblTokuAcNumE1.Name = "lblTokuAcNumE1"
        Me.lblTokuAcNumE1.Size = New System.Drawing.Size(69, 30)
        Me.lblTokuAcNumE1.TabIndex = 186
        Me.lblTokuAcNumE1.Text = "999"
        Me.lblTokuAcNumE1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTokuAcNumS4
        '
        Me.lblTokuAcNumS4.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblTokuAcNumS4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTokuAcNumS4.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblTokuAcNumS4.Location = New System.Drawing.Point(446, 301)
        Me.lblTokuAcNumS4.Name = "lblTokuAcNumS4"
        Me.lblTokuAcNumS4.Size = New System.Drawing.Size(34, 30)
        Me.lblTokuAcNumS4.TabIndex = 184
        Me.lblTokuAcNumS4.Text = "9"
        Me.lblTokuAcNumS4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTokuAcNumS3
        '
        Me.lblTokuAcNumS3.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblTokuAcNumS3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTokuAcNumS3.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblTokuAcNumS3.Location = New System.Drawing.Point(350, 301)
        Me.lblTokuAcNumS3.Name = "lblTokuAcNumS3"
        Me.lblTokuAcNumS3.Size = New System.Drawing.Size(90, 30)
        Me.lblTokuAcNumS3.TabIndex = 183
        Me.lblTokuAcNumS3.Text = "99999"
        Me.lblTokuAcNumS3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTokuAcNumS2
        '
        Me.lblTokuAcNumS2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblTokuAcNumS2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTokuAcNumS2.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblTokuAcNumS2.Location = New System.Drawing.Point(293, 301)
        Me.lblTokuAcNumS2.Name = "lblTokuAcNumS2"
        Me.lblTokuAcNumS2.Size = New System.Drawing.Size(51, 30)
        Me.lblTokuAcNumS2.TabIndex = 182
        Me.lblTokuAcNumS2.Text = "99"
        Me.lblTokuAcNumS2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label26
        '
        Me.Label26.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label26.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.White
        Me.Label26.Location = New System.Drawing.Point(78, 301)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(134, 30)
        Me.Label26.TabIndex = 185
        Me.Label26.Text = "開 始 番 号"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTokuAcNumS1
        '
        Me.lblTokuAcNumS1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblTokuAcNumS1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTokuAcNumS1.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblTokuAcNumS1.Location = New System.Drawing.Point(218, 301)
        Me.lblTokuAcNumS1.Name = "lblTokuAcNumS1"
        Me.lblTokuAcNumS1.Size = New System.Drawing.Size(69, 30)
        Me.lblTokuAcNumS1.TabIndex = 181
        Me.lblTokuAcNumS1.Text = "999"
        Me.lblTokuAcNumS1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PrintDocument1
        '
        '
        'ConfirmKetubanForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 28.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(604, 620)
        Me.ControlBox = False
        Me.Controls.Add(Me.BtnConfNumber)
        Me.Controls.Add(Me.lblTokuAcNumE4)
        Me.Controls.Add(Me.lblTokuAcNumE3)
        Me.Controls.Add(Me.lblTokuAcNumE2)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.lblTokuAcNumE1)
        Me.Controls.Add(Me.lblTokuAcNumS4)
        Me.Controls.Add(Me.lblTokuAcNumS3)
        Me.Controls.Add(Me.lblTokuAcNumS2)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.lblTokuAcNumS1)
        Me.Controls.Add(Me.lblYumeAcNumE4)
        Me.Controls.Add(Me.lblYumeAcNumE3)
        Me.Controls.Add(Me.lblYumeAcNumE2)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.lblYumeAcNumE1)
        Me.Controls.Add(Me.lblYumeAcNumS4)
        Me.Controls.Add(Me.lblYumeAcNumS3)
        Me.Controls.Add(Me.lblYumeAcNumS2)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.lblYumeAcNumS1)
        Me.Controls.Add(Me.lblKakiAcNumE4)
        Me.Controls.Add(Me.lblKakiAcNumE3)
        Me.Controls.Add(Me.lblKakiAcNumE2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblKakiAcNumE1)
        Me.Controls.Add(Me.lblKakiAcNumS4)
        Me.Controls.Add(Me.lblKakiAcNumS3)
        Me.Controls.Add(Me.lblKakiAcNumS2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblKakiAcNumS1)
        Me.Controls.Add(Me.RdoTokutei)
        Me.Controls.Add(Me.RdoYuMail)
        Me.Controls.Add(Me.RdoKakitome)
        Me.Controls.Add(Me.LblOperatorName)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.BtnBack)
        Me.Controls.Add(Me.BtnPrint)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.lblCurrentDate)
        Me.Controls.Add(Me.Label14)
        Me.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(6, 7, 6, 7)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ConfirmKetubanForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "欠番確認表"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LblOperatorName As System.Windows.Forms.Label
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents BtnBack As System.Windows.Forms.Button
    Friend WithEvents BtnPrint As System.Windows.Forms.Button
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblCurrentDate As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents BtnConfNumber As System.Windows.Forms.Button
    Friend WithEvents RdoKakitome As System.Windows.Forms.RadioButton
    Friend WithEvents RdoYuMail As System.Windows.Forms.RadioButton
    Friend WithEvents RdoTokutei As System.Windows.Forms.RadioButton
    Friend WithEvents lblKakiAcNumS4 As System.Windows.Forms.Label
    Friend WithEvents lblKakiAcNumS3 As System.Windows.Forms.Label
    Friend WithEvents lblKakiAcNumS2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblKakiAcNumS1 As System.Windows.Forms.Label
    Friend WithEvents lblKakiAcNumE4 As System.Windows.Forms.Label
    Friend WithEvents lblKakiAcNumE3 As System.Windows.Forms.Label
    Friend WithEvents lblKakiAcNumE2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblKakiAcNumE1 As System.Windows.Forms.Label
    Friend WithEvents lblYumeAcNumE4 As System.Windows.Forms.Label
    Friend WithEvents lblYumeAcNumE3 As System.Windows.Forms.Label
    Friend WithEvents lblYumeAcNumE2 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblYumeAcNumE1 As System.Windows.Forms.Label
    Friend WithEvents lblYumeAcNumS4 As System.Windows.Forms.Label
    Friend WithEvents lblYumeAcNumS3 As System.Windows.Forms.Label
    Friend WithEvents lblYumeAcNumS2 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents lblYumeAcNumS1 As System.Windows.Forms.Label
    Friend WithEvents lblTokuAcNumE4 As System.Windows.Forms.Label
    Friend WithEvents lblTokuAcNumE3 As System.Windows.Forms.Label
    Friend WithEvents lblTokuAcNumE2 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents lblTokuAcNumE1 As System.Windows.Forms.Label
    Friend WithEvents lblTokuAcNumS4 As System.Windows.Forms.Label
    Friend WithEvents lblTokuAcNumS3 As System.Windows.Forms.Label
    Friend WithEvents lblTokuAcNumS2 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents lblTokuAcNumS1 As System.Windows.Forms.Label
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
End Class
