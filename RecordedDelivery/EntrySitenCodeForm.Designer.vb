<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EntrySitenCodeForm
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
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TxtBranchCd = New System.Windows.Forms.TextBox()
        Me.BtnSearch = New System.Windows.Forms.Button()
        Me.LblOperatorName = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblCurrentDate = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtBranchName = New System.Windows.Forms.TextBox()
        Me.BtnBack = New System.Windows.Forms.Button()
        Me.BtnUpdate = New System.Windows.Forms.Button()
        Me.BtnDelete = New System.Windows.Forms.Button()
        Me.LsvDataView = New System.Windows.Forms.ListView()
        Me.BtnNew = New System.Windows.Forms.Button()
        Me.LblMessage = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label16.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(43, 102)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(181, 35)
        Me.Label16.TabIndex = 166
        Me.Label16.Text = "支店コード"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtBranchCd
        '
        Me.TxtBranchCd.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TxtBranchCd.Location = New System.Drawing.Point(225, 102)
        Me.TxtBranchCd.MaxLength = 10
        Me.TxtBranchCd.Name = "TxtBranchCd"
        Me.TxtBranchCd.Size = New System.Drawing.Size(149, 36)
        Me.TxtBranchCd.TabIndex = 167
        Me.TxtBranchCd.Text = "1234567890"
        Me.TxtBranchCd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'BtnSearch
        '
        Me.BtnSearch.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnSearch.Location = New System.Drawing.Point(439, 93)
        Me.BtnSearch.Name = "BtnSearch"
        Me.BtnSearch.Size = New System.Drawing.Size(120, 50)
        Me.BtnSearch.TabIndex = 168
        Me.BtnSearch.Text = "検索"
        Me.BtnSearch.UseVisualStyleBackColor = True
        Me.BtnSearch.Visible = False
        '
        'LblOperatorName
        '
        Me.LblOperatorName.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblOperatorName.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblOperatorName.ForeColor = System.Drawing.Color.White
        Me.LblOperatorName.Location = New System.Drawing.Point(383, 4)
        Me.LblOperatorName.Name = "LblOperatorName"
        Me.LblOperatorName.Size = New System.Drawing.Size(224, 33)
        Me.LblOperatorName.TabIndex = 165
        Me.LblOperatorName.Text = "LblOperatorName"
        Me.LblOperatorName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblTitle.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(-5, 1)
        Me.lblTitle.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(626, 36)
        Me.lblTitle.TabIndex = 164
        Me.lblTitle.Text = "　支店コード登録・変更"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCurrentDate
        '
        Me.lblCurrentDate.BackColor = System.Drawing.SystemColors.Control
        Me.lblCurrentDate.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblCurrentDate.ForeColor = System.Drawing.Color.Black
        Me.lblCurrentDate.Location = New System.Drawing.Point(397, 43)
        Me.lblCurrentDate.Name = "lblCurrentDate"
        Me.lblCurrentDate.Size = New System.Drawing.Size(206, 36)
        Me.lblCurrentDate.TabIndex = 163
        Me.lblCurrentDate.Text = "処理日"
        Me.lblCurrentDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(43, 68)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(181, 35)
        Me.Label1.TabIndex = 170
        Me.Label1.Text = "支店情報"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label2.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(43, 155)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(181, 35)
        Me.Label2.TabIndex = 171
        Me.Label2.Text = "支　店　名"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtBranchName
        '
        Me.TxtBranchName.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TxtBranchName.Location = New System.Drawing.Point(225, 155)
        Me.TxtBranchName.MaxLength = 20
        Me.TxtBranchName.Name = "TxtBranchName"
        Me.TxtBranchName.Size = New System.Drawing.Size(325, 36)
        Me.TxtBranchName.TabIndex = 172
        '
        'BtnBack
        '
        Me.BtnBack.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnBack.Location = New System.Drawing.Point(430, 581)
        Me.BtnBack.Name = "BtnBack"
        Me.BtnBack.Size = New System.Drawing.Size(120, 50)
        Me.BtnBack.TabIndex = 174
        Me.BtnBack.Text = "戻る"
        Me.BtnBack.UseVisualStyleBackColor = True
        '
        'BtnUpdate
        '
        Me.BtnUpdate.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnUpdate.Location = New System.Drawing.Point(169, 581)
        Me.BtnUpdate.Name = "BtnUpdate"
        Me.BtnUpdate.Size = New System.Drawing.Size(120, 50)
        Me.BtnUpdate.TabIndex = 173
        Me.BtnUpdate.Text = "更新"
        Me.BtnUpdate.UseVisualStyleBackColor = True
        '
        'BtnDelete
        '
        Me.BtnDelete.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnDelete.Location = New System.Drawing.Point(300, 581)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(120, 50)
        Me.BtnDelete.TabIndex = 175
        Me.BtnDelete.Text = "削除"
        Me.BtnDelete.UseVisualStyleBackColor = True
        '
        'LsvDataView
        '
        Me.LsvDataView.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LsvDataView.FullRowSelect = True
        Me.LsvDataView.GridLines = True
        Me.LsvDataView.Location = New System.Drawing.Point(39, 211)
        Me.LsvDataView.MultiSelect = False
        Me.LsvDataView.Name = "LsvDataView"
        Me.LsvDataView.Size = New System.Drawing.Size(511, 316)
        Me.LsvDataView.TabIndex = 178
        Me.LsvDataView.UseCompatibleStateImageBehavior = False
        '
        'BtnNew
        '
        Me.BtnNew.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnNew.Location = New System.Drawing.Point(39, 581)
        Me.BtnNew.Name = "BtnNew"
        Me.BtnNew.Size = New System.Drawing.Size(120, 50)
        Me.BtnNew.TabIndex = 179
        Me.BtnNew.Text = "新規"
        Me.BtnNew.UseVisualStyleBackColor = True
        '
        'LblMessage
        '
        Me.LblMessage.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblMessage.ForeColor = System.Drawing.Color.Red
        Me.LblMessage.Location = New System.Drawing.Point(44, 541)
        Me.LblMessage.Name = "LblMessage"
        Me.LblMessage.Size = New System.Drawing.Size(503, 31)
        Me.LblMessage.TabIndex = 180
        Me.LblMessage.Text = "LblMessage"
        Me.LblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'EntrySitenCodeForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 24.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(617, 656)
        Me.ControlBox = False
        Me.Controls.Add(Me.LblMessage)
        Me.Controls.Add(Me.BtnNew)
        Me.Controls.Add(Me.LsvDataView)
        Me.Controls.Add(Me.BtnDelete)
        Me.Controls.Add(Me.BtnBack)
        Me.Controls.Add(Me.BtnUpdate)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtBranchName)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.TxtBranchCd)
        Me.Controls.Add(Me.BtnSearch)
        Me.Controls.Add(Me.LblOperatorName)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.lblCurrentDate)
        Me.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "EntrySitenCodeForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "支店コード登録・変更"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents TxtBranchCd As System.Windows.Forms.TextBox
    Friend WithEvents BtnSearch As System.Windows.Forms.Button
    Friend WithEvents LblOperatorName As System.Windows.Forms.Label
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents lblCurrentDate As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtBranchName As System.Windows.Forms.TextBox
    Friend WithEvents BtnBack As System.Windows.Forms.Button
    Friend WithEvents BtnUpdate As System.Windows.Forms.Button
    Friend WithEvents BtnDelete As System.Windows.Forms.Button
    Friend WithEvents LsvDataView As System.Windows.Forms.ListView
    Friend WithEvents BtnNew As System.Windows.Forms.Button
    Friend WithEvents LblMessage As System.Windows.Forms.Label
End Class
