<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MngNumberForm
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
        Me.lblCurrentDate = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.BtnSearch = New System.Windows.Forms.Button()
        Me.TxtClassName = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TxtEnNum1 = New System.Windows.Forms.TextBox()
        Me.TxtEnNum2 = New System.Windows.Forms.TextBox()
        Me.TxtEnNum3 = New System.Windows.Forms.TextBox()
        Me.TxtEnNum4 = New System.Windows.Forms.TextBox()
        Me.TxtStNum4 = New System.Windows.Forms.TextBox()
        Me.TxtStNum3 = New System.Windows.Forms.TextBox()
        Me.TxtStNum2 = New System.Windows.Forms.TextBox()
        Me.TxtStNum1 = New System.Windows.Forms.TextBox()
        Me.CmbMasterItem = New System.Windows.Forms.ComboBox()
        Me.BtnNewEntry = New System.Windows.Forms.Button()
        Me.BtnBack = New System.Windows.Forms.Button()
        Me.BtnUpdate = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'LblOperatorName
        '
        Me.LblOperatorName.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblOperatorName.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblOperatorName.ForeColor = System.Drawing.Color.White
        Me.LblOperatorName.Location = New System.Drawing.Point(313, 0)
        Me.LblOperatorName.Name = "LblOperatorName"
        Me.LblOperatorName.Size = New System.Drawing.Size(224, 33)
        Me.LblOperatorName.TabIndex = 158
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
        Me.lblTitle.Size = New System.Drawing.Size(553, 36)
        Me.lblTitle.TabIndex = 157
        Me.lblTitle.Text = "　引受番号管理"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCurrentDate
        '
        Me.lblCurrentDate.BackColor = System.Drawing.SystemColors.Control
        Me.lblCurrentDate.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblCurrentDate.ForeColor = System.Drawing.Color.Black
        Me.lblCurrentDate.Location = New System.Drawing.Point(212, 39)
        Me.lblCurrentDate.Name = "lblCurrentDate"
        Me.lblCurrentDate.Size = New System.Drawing.Size(265, 29)
        Me.lblCurrentDate.TabIndex = 156
        Me.lblCurrentDate.Text = "lblCurrentDate"
        Me.lblCurrentDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label16.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(28, 89)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(181, 35)
        Me.Label16.TabIndex = 164
        Me.Label16.Text = "引受番号帯コード"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnSearch
        '
        Me.BtnSearch.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnSearch.Image = Global.RecordedDelivery.My.Resources.Resources.search_file
        Me.BtnSearch.Location = New System.Drawing.Point(357, 74)
        Me.BtnSearch.Name = "BtnSearch"
        Me.BtnSearch.Size = New System.Drawing.Size(120, 50)
        Me.BtnSearch.TabIndex = 166
        Me.BtnSearch.Text = "検索"
        Me.BtnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnSearch.UseVisualStyleBackColor = True
        Me.BtnSearch.Visible = False
        '
        'TxtClassName
        '
        Me.TxtClassName.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TxtClassName.Location = New System.Drawing.Point(210, 137)
        Me.TxtClassName.MaxLength = 20
        Me.TxtClassName.Name = "TxtClassName"
        Me.TxtClassName.Size = New System.Drawing.Size(267, 36)
        Me.TxtClassName.TabIndex = 163
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label20.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.White
        Me.Label20.Location = New System.Drawing.Point(28, 137)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(181, 35)
        Me.Label20.TabIndex = 162
        Me.Label20.Text = "種別（表示用）"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label5.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(27, 228)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(181, 35)
        Me.Label5.TabIndex = 180
        Me.Label5.Text = "開 始 番 号"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(27, 188)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(182, 30)
        Me.Label4.TabIndex = 175
        Me.Label4.Text = "引受番号の番号帯"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(215, 188)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 30)
        Me.Label1.TabIndex = 181
        Me.Label1.Text = "３桁"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(281, 188)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 30)
        Me.Label2.TabIndex = 182
        Me.Label2.Text = "２桁"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(356, 188)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 30)
        Me.Label3.TabIndex = 183
        Me.Label3.Text = "５桁"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(431, 188)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(98, 30)
        Me.Label6.TabIndex = 184
        Me.Label6.Text = "CD１桁"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label7.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(27, 278)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(181, 35)
        Me.Label7.TabIndex = 185
        Me.Label7.Text = "終 了 番 号"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtEnNum1
        '
        Me.TxtEnNum1.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TxtEnNum1.Location = New System.Drawing.Point(214, 276)
        Me.TxtEnNum1.MaxLength = 3
        Me.TxtEnNum1.Name = "TxtEnNum1"
        Me.TxtEnNum1.Size = New System.Drawing.Size(70, 39)
        Me.TxtEnNum1.TabIndex = 186
        Me.TxtEnNum1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtEnNum2
        '
        Me.TxtEnNum2.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TxtEnNum2.Location = New System.Drawing.Point(290, 276)
        Me.TxtEnNum2.MaxLength = 2
        Me.TxtEnNum2.Name = "TxtEnNum2"
        Me.TxtEnNum2.Size = New System.Drawing.Size(51, 39)
        Me.TxtEnNum2.TabIndex = 187
        Me.TxtEnNum2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtEnNum3
        '
        Me.TxtEnNum3.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TxtEnNum3.Location = New System.Drawing.Point(347, 276)
        Me.TxtEnNum3.MaxLength = 5
        Me.TxtEnNum3.Name = "TxtEnNum3"
        Me.TxtEnNum3.Size = New System.Drawing.Size(90, 39)
        Me.TxtEnNum3.TabIndex = 188
        Me.TxtEnNum3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtEnNum4
        '
        Me.TxtEnNum4.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TxtEnNum4.Location = New System.Drawing.Point(443, 276)
        Me.TxtEnNum4.MaxLength = 1
        Me.TxtEnNum4.Name = "TxtEnNum4"
        Me.TxtEnNum4.Size = New System.Drawing.Size(34, 39)
        Me.TxtEnNum4.TabIndex = 189
        Me.TxtEnNum4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtStNum4
        '
        Me.TxtStNum4.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TxtStNum4.Location = New System.Drawing.Point(443, 226)
        Me.TxtStNum4.MaxLength = 1
        Me.TxtStNum4.Name = "TxtStNum4"
        Me.TxtStNum4.Size = New System.Drawing.Size(34, 39)
        Me.TxtStNum4.TabIndex = 193
        Me.TxtStNum4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtStNum3
        '
        Me.TxtStNum3.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TxtStNum3.Location = New System.Drawing.Point(347, 226)
        Me.TxtStNum3.MaxLength = 5
        Me.TxtStNum3.Name = "TxtStNum3"
        Me.TxtStNum3.Size = New System.Drawing.Size(90, 39)
        Me.TxtStNum3.TabIndex = 192
        Me.TxtStNum3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtStNum2
        '
        Me.TxtStNum2.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TxtStNum2.Location = New System.Drawing.Point(290, 226)
        Me.TxtStNum2.MaxLength = 2
        Me.TxtStNum2.Name = "TxtStNum2"
        Me.TxtStNum2.Size = New System.Drawing.Size(51, 39)
        Me.TxtStNum2.TabIndex = 191
        Me.TxtStNum2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtStNum1
        '
        Me.TxtStNum1.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TxtStNum1.Location = New System.Drawing.Point(214, 226)
        Me.TxtStNum1.MaxLength = 3
        Me.TxtStNum1.Name = "TxtStNum1"
        Me.TxtStNum1.Size = New System.Drawing.Size(70, 39)
        Me.TxtStNum1.TabIndex = 190
        Me.TxtStNum1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CmbMasterItem
        '
        Me.CmbMasterItem.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CmbMasterItem.FormattingEnabled = True
        Me.CmbMasterItem.Location = New System.Drawing.Point(210, 89)
        Me.CmbMasterItem.Name = "CmbMasterItem"
        Me.CmbMasterItem.Size = New System.Drawing.Size(133, 36)
        Me.CmbMasterItem.TabIndex = 194
        '
        'BtnNewEntry
        '
        Me.BtnNewEntry.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnNewEntry.Image = Global.RecordedDelivery.My.Resources.Resources.new_small
        Me.BtnNewEntry.Location = New System.Drawing.Point(12, 376)
        Me.BtnNewEntry.Name = "BtnNewEntry"
        Me.BtnNewEntry.Size = New System.Drawing.Size(149, 50)
        Me.BtnNewEntry.TabIndex = 195
        Me.BtnNewEntry.Text = "新規登録"
        Me.BtnNewEntry.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnNewEntry.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnNewEntry.UseVisualStyleBackColor = True
        Me.BtnNewEntry.Visible = False
        '
        'BtnBack
        '
        Me.BtnBack.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnBack.Image = Global.RecordedDelivery.My.Resources.Resources.back_arrow
        Me.BtnBack.Location = New System.Drawing.Point(357, 356)
        Me.BtnBack.Name = "BtnBack"
        Me.BtnBack.Size = New System.Drawing.Size(120, 50)
        Me.BtnBack.TabIndex = 168
        Me.BtnBack.Text = "戻る"
        Me.BtnBack.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnBack.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnBack.UseVisualStyleBackColor = True
        '
        'BtnUpdate
        '
        Me.BtnUpdate.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnUpdate.Image = Global.RecordedDelivery.My.Resources.Resources.update
        Me.BtnUpdate.Location = New System.Drawing.Point(213, 356)
        Me.BtnUpdate.Name = "BtnUpdate"
        Me.BtnUpdate.Size = New System.Drawing.Size(120, 50)
        Me.BtnUpdate.TabIndex = 167
        Me.BtnUpdate.Text = "更新"
        Me.BtnUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnUpdate.UseVisualStyleBackColor = True
        '
        'MngNumberForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 24.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(549, 438)
        Me.ControlBox = False
        Me.Controls.Add(Me.BtnNewEntry)
        Me.Controls.Add(Me.CmbMasterItem)
        Me.Controls.Add(Me.TxtStNum4)
        Me.Controls.Add(Me.TxtStNum3)
        Me.Controls.Add(Me.TxtStNum2)
        Me.Controls.Add(Me.TxtStNum1)
        Me.Controls.Add(Me.TxtEnNum4)
        Me.Controls.Add(Me.TxtEnNum3)
        Me.Controls.Add(Me.TxtEnNum2)
        Me.Controls.Add(Me.TxtEnNum1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.BtnBack)
        Me.Controls.Add(Me.BtnUpdate)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.BtnSearch)
        Me.Controls.Add(Me.TxtClassName)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.LblOperatorName)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.lblCurrentDate)
        Me.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MngNumberForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "引受番号管理"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LblOperatorName As System.Windows.Forms.Label
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents lblCurrentDate As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents BtnSearch As System.Windows.Forms.Button
    Friend WithEvents TxtClassName As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents BtnUpdate As System.Windows.Forms.Button
    Friend WithEvents BtnBack As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxtEnNum1 As System.Windows.Forms.TextBox
    Friend WithEvents TxtEnNum2 As System.Windows.Forms.TextBox
    Friend WithEvents TxtEnNum3 As System.Windows.Forms.TextBox
    Friend WithEvents TxtEnNum4 As System.Windows.Forms.TextBox
    Friend WithEvents TxtStNum4 As System.Windows.Forms.TextBox
    Friend WithEvents TxtStNum3 As System.Windows.Forms.TextBox
    Friend WithEvents TxtStNum2 As System.Windows.Forms.TextBox
    Friend WithEvents TxtStNum1 As System.Windows.Forms.TextBox
    Friend WithEvents CmbMasterItem As System.Windows.Forms.ComboBox
    Friend WithEvents BtnNewEntry As System.Windows.Forms.Button
End Class
