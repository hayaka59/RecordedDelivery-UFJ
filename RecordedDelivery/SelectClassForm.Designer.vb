<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectClassForm
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
        Me.CmbClassification = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.TxtBranchCd = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LblCurrentDate = New System.Windows.Forms.Label()
        Me.TxtTranCnt = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LblOperatorName = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.LblBranchName = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Rdo8Face = New System.Windows.Forms.RadioButton()
        Me.Rdo15Face = New System.Windows.Forms.RadioButton()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.CmbClassFilter = New System.Windows.Forms.ComboBox()
        Me.BtnBack = New System.Windows.Forms.Button()
        Me.BtnNext = New System.Windows.Forms.Button()
        Me.BtnSearch = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CmbClassification
        '
        Me.CmbClassification.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbClassification.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CmbClassification.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CmbClassification.FormattingEnabled = True
        Me.CmbClassification.Location = New System.Drawing.Point(222, 277)
        Me.CmbClassification.Name = "CmbClassification"
        Me.CmbClassification.Size = New System.Drawing.Size(314, 39)
        Me.CmbClassification.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(345, 330)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 31)
        Me.Label5.TabIndex = 98
        Me.Label5.Text = "通"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label4.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.Location = New System.Drawing.Point(44, 325)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(178, 38)
        Me.Label4.TabIndex = 97
        Me.Label4.Text = "処理予定数"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(44, 235)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(177, 31)
        Me.Label3.TabIndex = 96
        Me.Label3.Text = "支　店　名："
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.DateTimePicker1.Location = New System.Drawing.Point(222, 89)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(198, 39)
        Me.DateTimePicker1.TabIndex = 10
        '
        'TxtBranchCd
        '
        Me.TxtBranchCd.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TxtBranchCd.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TxtBranchCd.Location = New System.Drawing.Point(223, 187)
        Me.TxtBranchCd.MaxLength = 4
        Me.TxtBranchCd.Name = "TxtBranchCd"
        Me.TxtBranchCd.Size = New System.Drawing.Size(198, 39)
        Me.TxtBranchCd.TabIndex = 1
        Me.TxtBranchCd.Text = "1234567890"
        Me.TxtBranchCd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label2.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(44, 186)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(178, 38)
        Me.Label2.TabIndex = 92
        Me.Label2.Text = "支店コード"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblCurrentDate
        '
        Me.LblCurrentDate.BackColor = System.Drawing.SystemColors.Control
        Me.LblCurrentDate.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblCurrentDate.ForeColor = System.Drawing.Color.Black
        Me.LblCurrentDate.Location = New System.Drawing.Point(337, 48)
        Me.LblCurrentDate.Name = "LblCurrentDate"
        Me.LblCurrentDate.Size = New System.Drawing.Size(199, 27)
        Me.LblCurrentDate.TabIndex = 91
        Me.LblCurrentDate.Text = "LblDate"
        Me.LblCurrentDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TxtTranCnt
        '
        Me.TxtTranCnt.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TxtTranCnt.Location = New System.Drawing.Point(223, 324)
        Me.TxtTranCnt.MaxLength = 6
        Me.TxtTranCnt.Name = "TxtTranCnt"
        Me.TxtTranCnt.Size = New System.Drawing.Size(114, 39)
        Me.TxtTranCnt.TabIndex = 4
        Me.TxtTranCnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(44, 90)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(178, 38)
        Me.Label1.TabIndex = 89
        Me.Label1.Text = "処理日"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblOperatorName
        '
        Me.LblOperatorName.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblOperatorName.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblOperatorName.ForeColor = System.Drawing.Color.White
        Me.LblOperatorName.Location = New System.Drawing.Point(352, 2)
        Me.LblOperatorName.Name = "LblOperatorName"
        Me.LblOperatorName.Size = New System.Drawing.Size(224, 33)
        Me.LblOperatorName.TabIndex = 88
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
        Me.lblTitle.Size = New System.Drawing.Size(580, 36)
        Me.lblTitle.TabIndex = 87
        Me.lblTitle.Text = "　支店選択"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label6.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.Location = New System.Drawing.Point(44, 278)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(178, 38)
        Me.Label6.TabIndex = 101
        Me.Label6.Text = "種別②"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblBranchName
        '
        Me.LblBranchName.BackColor = System.Drawing.SystemColors.Control
        Me.LblBranchName.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblBranchName.Location = New System.Drawing.Point(221, 235)
        Me.LblBranchName.Name = "LblBranchName"
        Me.LblBranchName.Size = New System.Drawing.Size(275, 31)
        Me.LblBranchName.TabIndex = 102
        Me.LblBranchName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Rdo8Face)
        Me.GroupBox1.Controls.Add(Me.Rdo15Face)
        Me.GroupBox1.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(49, 383)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(306, 64)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "受領証面数設定"
        '
        'Rdo8Face
        '
        Me.Rdo8Face.Location = New System.Drawing.Point(168, 24)
        Me.Rdo8Face.Name = "Rdo8Face"
        Me.Rdo8Face.Size = New System.Drawing.Size(75, 28)
        Me.Rdo8Face.TabIndex = 7
        Me.Rdo8Face.Text = "8面"
        Me.Rdo8Face.UseVisualStyleBackColor = True
        '
        'Rdo15Face
        '
        Me.Rdo15Face.Checked = True
        Me.Rdo15Face.Location = New System.Drawing.Point(57, 24)
        Me.Rdo15Face.Name = "Rdo15Face"
        Me.Rdo15Face.Size = New System.Drawing.Size(82, 28)
        Me.Rdo15Face.TabIndex = 6
        Me.Rdo15Face.TabStop = True
        Me.Rdo15Face.Text = "15面"
        Me.Rdo15Face.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label7.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.Location = New System.Drawing.Point(44, 138)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(178, 38)
        Me.Label7.TabIndex = 104
        Me.Label7.Text = "種別①"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CmbClassFilter
        '
        Me.CmbClassFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbClassFilter.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CmbClassFilter.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CmbClassFilter.FormattingEnabled = True
        Me.CmbClassFilter.Location = New System.Drawing.Point(221, 137)
        Me.CmbClassFilter.Name = "CmbClassFilter"
        Me.CmbClassFilter.Size = New System.Drawing.Size(315, 39)
        Me.CmbClassFilter.TabIndex = 103
        '
        'BtnBack
        '
        Me.BtnBack.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnBack.Image = Global.RecordedDelivery.My.Resources.Resources.back_small
        Me.BtnBack.Location = New System.Drawing.Point(386, 469)
        Me.BtnBack.Name = "BtnBack"
        Me.BtnBack.Size = New System.Drawing.Size(150, 45)
        Me.BtnBack.TabIndex = 9
        Me.BtnBack.Text = "戻る"
        Me.BtnBack.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnBack.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnBack.UseVisualStyleBackColor = True
        '
        'BtnNext
        '
        Me.BtnNext.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnNext.Image = Global.RecordedDelivery.My.Resources.Resources.check_ok
        Me.BtnNext.Location = New System.Drawing.Point(49, 469)
        Me.BtnNext.Name = "BtnNext"
        Me.BtnNext.Size = New System.Drawing.Size(150, 45)
        Me.BtnNext.TabIndex = 8
        Me.BtnNext.Text = "次へ"
        Me.BtnNext.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnNext.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnNext.UseVisualStyleBackColor = True
        '
        'BtnSearch
        '
        Me.BtnSearch.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnSearch.Image = Global.RecordedDelivery.My.Resources.Resources.search_file
        Me.BtnSearch.Location = New System.Drawing.Point(435, 186)
        Me.BtnSearch.Name = "BtnSearch"
        Me.BtnSearch.Size = New System.Drawing.Size(101, 45)
        Me.BtnSearch.TabIndex = 2
        Me.BtnSearch.Text = "検索"
        Me.BtnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnSearch.UseVisualStyleBackColor = True
        '
        'SelectClassForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 24.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(580, 557)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.CmbClassFilter)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.BtnBack)
        Me.Controls.Add(Me.BtnNext)
        Me.Controls.Add(Me.LblBranchName)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.CmbClassification)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.BtnSearch)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.TxtBranchCd)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LblCurrentDate)
        Me.Controls.Add(Me.TxtTranCnt)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LblOperatorName)
        Me.Controls.Add(Me.lblTitle)
        Me.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SelectClassForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "支店選択"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CmbClassification As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents BtnSearch As System.Windows.Forms.Button
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents TxtBranchCd As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LblCurrentDate As System.Windows.Forms.Label
    Friend WithEvents TxtTranCnt As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LblOperatorName As System.Windows.Forms.Label
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents LblBranchName As System.Windows.Forms.Label
    Friend WithEvents BtnBack As System.Windows.Forms.Button
    Friend WithEvents BtnNext As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Rdo8Face As System.Windows.Forms.RadioButton
    Friend WithEvents Rdo15Face As System.Windows.Forms.RadioButton
    Friend WithEvents Label7 As Label
    Friend WithEvents CmbClassFilter As ComboBox
End Class
