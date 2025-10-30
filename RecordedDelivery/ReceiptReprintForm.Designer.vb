<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReceiptReprintForm
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
        Me.TxtYoteiTusu = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lblCurrentDate = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.LblOperatorName = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TxtBranch = New System.Windows.Forms.TextBox()
        Me.lstRePrintView = New System.Windows.Forms.ListView()
        Me.GroupBox12 = New System.Windows.Forms.GroupBox()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.Rdo15FacePerPage = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtFromPage = New System.Windows.Forms.TextBox()
        Me.TxtToPage = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RdoBoth = New System.Windows.Forms.RadioButton()
        Me.RdoZyuryo = New System.Windows.Forms.RadioButton()
        Me.RdoSasidasi = New System.Windows.Forms.RadioButton()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.lstGetDataView = New System.Windows.Forms.ListView()
        Me.BtnSearch = New System.Windows.Forms.Button()
        Me.BtnPrint = New System.Windows.Forms.Button()
        Me.BtnBack = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.CmbClassFilter = New System.Windows.Forms.ComboBox()
        Me.GroupBox12.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TxtYoteiTusu
        '
        Me.TxtYoteiTusu.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TxtYoteiTusu.Location = New System.Drawing.Point(224, 182)
        Me.TxtYoteiTusu.MaxLength = 6
        Me.TxtYoteiTusu.Name = "TxtYoteiTusu"
        Me.TxtYoteiTusu.Size = New System.Drawing.Size(183, 36)
        Me.TxtYoteiTusu.TabIndex = 3
        Me.TxtYoteiTusu.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label20.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.White
        Me.Label20.Location = New System.Drawing.Point(27, 182)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(197, 35)
        Me.Label20.TabIndex = 106
        Me.Label20.Text = "処理通数"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label14.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(27, 53)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(197, 33)
        Me.Label14.TabIndex = 103
        Me.Label14.Text = "処理日"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCurrentDate
        '
        Me.lblCurrentDate.BackColor = System.Drawing.SystemColors.Control
        Me.lblCurrentDate.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblCurrentDate.ForeColor = System.Drawing.Color.Black
        Me.lblCurrentDate.Location = New System.Drawing.Point(616, 39)
        Me.lblCurrentDate.Name = "lblCurrentDate"
        Me.lblCurrentDate.Size = New System.Drawing.Size(265, 36)
        Me.lblCurrentDate.TabIndex = 119
        Me.lblCurrentDate.Text = "処理日"
        Me.lblCurrentDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CalendarFont = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.DateTimePicker1.Location = New System.Drawing.Point(224, 54)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(210, 31)
        Me.DateTimePicker1.TabIndex = 15
        '
        'LblOperatorName
        '
        Me.LblOperatorName.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblOperatorName.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblOperatorName.ForeColor = System.Drawing.Color.White
        Me.LblOperatorName.Location = New System.Drawing.Point(657, 1)
        Me.LblOperatorName.Name = "LblOperatorName"
        Me.LblOperatorName.Size = New System.Drawing.Size(224, 33)
        Me.LblOperatorName.TabIndex = 124
        Me.LblOperatorName.Text = "LblOperatorName"
        Me.LblOperatorName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblTitle.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(-2, -1)
        Me.lblTitle.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(883, 36)
        Me.lblTitle.TabIndex = 123
        Me.lblTitle.Text = "　受領証再発行"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label16.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(27, 93)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(197, 35)
        Me.Label16.TabIndex = 126
        Me.Label16.Text = "支店コード"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtBranch
        '
        Me.TxtBranch.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TxtBranch.Location = New System.Drawing.Point(224, 93)
        Me.TxtBranch.MaxLength = 10
        Me.TxtBranch.Name = "TxtBranch"
        Me.TxtBranch.Size = New System.Drawing.Size(183, 36)
        Me.TxtBranch.TabIndex = 1
        Me.TxtBranch.Text = "1234567890"
        Me.TxtBranch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lstRePrintView
        '
        Me.lstRePrintView.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lstRePrintView.FullRowSelect = True
        Me.lstRePrintView.GridLines = True
        Me.lstRePrintView.HideSelection = False
        Me.lstRePrintView.Location = New System.Drawing.Point(27, 228)
        Me.lstRePrintView.MultiSelect = False
        Me.lstRePrintView.Name = "lstRePrintView"
        Me.lstRePrintView.Size = New System.Drawing.Size(618, 762)
        Me.lstRePrintView.TabIndex = 5
        Me.lstRePrintView.UseCompatibleStateImageBehavior = False
        '
        'GroupBox12
        '
        Me.GroupBox12.Controls.Add(Me.RadioButton1)
        Me.GroupBox12.Controls.Add(Me.Rdo15FacePerPage)
        Me.GroupBox12.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox12.Location = New System.Drawing.Point(674, 351)
        Me.GroupBox12.Name = "GroupBox12"
        Me.GroupBox12.Size = New System.Drawing.Size(167, 100)
        Me.GroupBox12.TabIndex = 141
        Me.GroupBox12.TabStop = False
        Me.GroupBox12.Text = "受領証面数設定"
        '
        'RadioButton1
        '
        Me.RadioButton1.Location = New System.Drawing.Point(23, 56)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(74, 28)
        Me.RadioButton1.TabIndex = 10
        Me.RadioButton1.Text = "8面"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'Rdo15FacePerPage
        '
        Me.Rdo15FacePerPage.Checked = True
        Me.Rdo15FacePerPage.Location = New System.Drawing.Point(23, 27)
        Me.Rdo15FacePerPage.Name = "Rdo15FacePerPage"
        Me.Rdo15FacePerPage.Size = New System.Drawing.Size(79, 28)
        Me.Rdo15FacePerPage.TabIndex = 9
        Me.Rdo15FacePerPage.TabStop = True
        Me.Rdo15FacePerPage.Text = "15面"
        Me.Rdo15FacePerPage.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(671, 463)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 35)
        Me.Label1.TabIndex = 144
        Me.Label1.Text = "FROM"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TxtFromPage
        '
        Me.TxtFromPage.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TxtFromPage.Location = New System.Drawing.Point(741, 461)
        Me.TxtFromPage.MaxLength = 3
        Me.TxtFromPage.Name = "TxtFromPage"
        Me.TxtFromPage.Size = New System.Drawing.Size(78, 36)
        Me.TxtFromPage.TabIndex = 11
        '
        'TxtToPage
        '
        Me.TxtToPage.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TxtToPage.Location = New System.Drawing.Point(741, 504)
        Me.TxtToPage.MaxLength = 3
        Me.TxtToPage.Name = "TxtToPage"
        Me.TxtToPage.Size = New System.Drawing.Size(78, 36)
        Me.TxtToPage.TabIndex = 12
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(671, 503)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 35)
        Me.Label2.TabIndex = 142
        Me.Label2.Text = "TO"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(818, 462)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 35)
        Me.Label3.TabIndex = 147
        Me.Label3.Text = "頁"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(820, 505)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 35)
        Me.Label4.TabIndex = 146
        Me.Label4.Text = "頁"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RdoBoth)
        Me.GroupBox1.Controls.Add(Me.RdoZyuryo)
        Me.GroupBox1.Controls.Add(Me.RdoSasidasi)
        Me.GroupBox1.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(676, 229)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(163, 113)
        Me.GroupBox1.TabIndex = 148
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "印刷選択"
        '
        'RdoBoth
        '
        Me.RdoBoth.Checked = True
        Me.RdoBoth.Location = New System.Drawing.Point(27, 77)
        Me.RdoBoth.Name = "RdoBoth"
        Me.RdoBoth.Size = New System.Drawing.Size(74, 28)
        Me.RdoBoth.TabIndex = 8
        Me.RdoBoth.TabStop = True
        Me.RdoBoth.Text = "両方"
        Me.RdoBoth.UseVisualStyleBackColor = True
        '
        'RdoZyuryo
        '
        Me.RdoZyuryo.Location = New System.Drawing.Point(27, 51)
        Me.RdoZyuryo.Name = "RdoZyuryo"
        Me.RdoZyuryo.Size = New System.Drawing.Size(106, 28)
        Me.RdoZyuryo.TabIndex = 7
        Me.RdoZyuryo.Text = "受領証"
        Me.RdoZyuryo.UseVisualStyleBackColor = True
        '
        'RdoSasidasi
        '
        Me.RdoSasidasi.Location = New System.Drawing.Point(27, 24)
        Me.RdoSasidasi.Name = "RdoSasidasi"
        Me.RdoSasidasi.Size = New System.Drawing.Size(106, 28)
        Me.RdoSasidasi.TabIndex = 6
        Me.RdoSasidasi.Text = "差出票"
        Me.RdoSasidasi.UseVisualStyleBackColor = True
        '
        'lstGetDataView
        '
        Me.lstGetDataView.CheckBoxes = True
        Me.lstGetDataView.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lstGetDataView.FullRowSelect = True
        Me.lstGetDataView.GridLines = True
        Me.lstGetDataView.HideSelection = False
        Me.lstGetDataView.Location = New System.Drawing.Point(2, 956)
        Me.lstGetDataView.MultiSelect = False
        Me.lstGetDataView.Name = "lstGetDataView"
        Me.lstGetDataView.Size = New System.Drawing.Size(879, 92)
        Me.lstGetDataView.TabIndex = 149
        Me.lstGetDataView.UseCompatibleStateImageBehavior = False
        Me.lstGetDataView.Visible = False
        '
        'BtnSearch
        '
        Me.BtnSearch.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnSearch.Image = Global.RecordedDelivery.My.Resources.Resources.search_file
        Me.BtnSearch.Location = New System.Drawing.Point(455, 137)
        Me.BtnSearch.Name = "BtnSearch"
        Me.BtnSearch.Size = New System.Drawing.Size(190, 68)
        Me.BtnSearch.TabIndex = 2
        Me.BtnSearch.Text = "検索"
        Me.BtnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnSearch.UseVisualStyleBackColor = True
        '
        'BtnPrint
        '
        Me.BtnPrint.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnPrint.Image = Global.RecordedDelivery.My.Resources.Resources.printer_small
        Me.BtnPrint.Location = New System.Drawing.Point(668, 566)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(190, 68)
        Me.BtnPrint.TabIndex = 13
        Me.BtnPrint.Text = "印刷"
        Me.BtnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnPrint.UseVisualStyleBackColor = True
        '
        'BtnBack
        '
        Me.BtnBack.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnBack.Image = Global.RecordedDelivery.My.Resources.Resources.back_arrow
        Me.BtnBack.Location = New System.Drawing.Point(668, 922)
        Me.BtnBack.Name = "BtnBack"
        Me.BtnBack.Size = New System.Drawing.Size(190, 68)
        Me.BtnBack.TabIndex = 14
        Me.BtnBack.Text = "戻る"
        Me.BtnBack.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnBack.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnBack.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label7.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(27, 137)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(197, 38)
        Me.Label7.TabIndex = 151
        Me.Label7.Text = "種別"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CmbClassFilter
        '
        Me.CmbClassFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbClassFilter.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CmbClassFilter.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CmbClassFilter.FormattingEnabled = True
        Me.CmbClassFilter.Location = New System.Drawing.Point(224, 137)
        Me.CmbClassFilter.Name = "CmbClassFilter"
        Me.CmbClassFilter.Size = New System.Drawing.Size(183, 36)
        Me.CmbClassFilter.TabIndex = 150
        '
        'ReceiptReprintForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 24.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(880, 1007)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.CmbClassFilter)
        Me.Controls.Add(Me.BtnBack)
        Me.Controls.Add(Me.lstRePrintView)
        Me.Controls.Add(Me.lstGetDataView)
        Me.Controls.Add(Me.TxtFromPage)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtToPage)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GroupBox12)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.TxtBranch)
        Me.Controls.Add(Me.BtnSearch)
        Me.Controls.Add(Me.BtnPrint)
        Me.Controls.Add(Me.LblOperatorName)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.lblCurrentDate)
        Me.Controls.Add(Me.TxtYoteiTusu)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label14)
        Me.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ReceiptReprintForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "受領証再発行検索"
        Me.GroupBox12.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtYoteiTusu As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents BtnBack As System.Windows.Forms.Button
    Friend WithEvents lblCurrentDate As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents LblOperatorName As System.Windows.Forms.Label
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents BtnPrint As System.Windows.Forms.Button
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents TxtBranch As System.Windows.Forms.TextBox
    Friend WithEvents BtnSearch As System.Windows.Forms.Button
    Friend WithEvents lstRePrintView As System.Windows.Forms.ListView
    Friend WithEvents GroupBox12 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents Rdo15FacePerPage As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtFromPage As System.Windows.Forms.TextBox
    Friend WithEvents TxtToPage As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RdoBoth As System.Windows.Forms.RadioButton
    Friend WithEvents RdoZyuryo As System.Windows.Forms.RadioButton
    Friend WithEvents RdoSasidasi As System.Windows.Forms.RadioButton
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents lstGetDataView As System.Windows.Forms.ListView
    Friend WithEvents Label7 As Label
    Friend WithEvents CmbClassFilter As ComboBox
End Class
