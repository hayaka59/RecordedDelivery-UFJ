<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MasterMaintForm
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
        Me.BtnEntrySiten = New System.Windows.Forms.Button()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.LblOperatorName = New System.Windows.Forms.Label()
        Me.BtnBack = New System.Windows.Forms.Button()
        Me.BtnMasterList = New System.Windows.Forms.Button()
        Me.BtnOperatorEntry = New System.Windows.Forms.Button()
        Me.BtnMngNumber = New System.Windows.Forms.Button()
        Me.BtnJobEntry = New System.Windows.Forms.Button()
        Me.BtnClassMasterEntry = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'BtnEntrySiten
        '
        Me.BtnEntrySiten.Font = New System.Drawing.Font("メイリオ", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnEntrySiten.Image = Global.RecordedDelivery.My.Resources.Resources.bank_big
        Me.BtnEntrySiten.Location = New System.Drawing.Point(205, 151)
        Me.BtnEntrySiten.Name = "BtnEntrySiten"
        Me.BtnEntrySiten.Size = New System.Drawing.Size(700, 180)
        Me.BtnEntrySiten.TabIndex = 13
        Me.BtnEntrySiten.Text = "支店コード登録・変更"
        Me.BtnEntrySiten.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnEntrySiten.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnEntrySiten.UseVisualStyleBackColor = True
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblTitle.Font = New System.Drawing.Font("メイリオ", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(-2, 1)
        Me.lblTitle.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(1916, 85)
        Me.lblTitle.TabIndex = 14
        Me.lblTitle.Text = "マスターメンテナンス"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblOperatorName
        '
        Me.LblOperatorName.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblOperatorName.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblOperatorName.ForeColor = System.Drawing.Color.White
        Me.LblOperatorName.Location = New System.Drawing.Point(1536, 30)
        Me.LblOperatorName.Name = "LblOperatorName"
        Me.LblOperatorName.Size = New System.Drawing.Size(345, 33)
        Me.LblOperatorName.TabIndex = 24
        Me.LblOperatorName.Text = "LblOperatorName"
        Me.LblOperatorName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnBack
        '
        Me.BtnBack.Font = New System.Drawing.Font("メイリオ", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnBack.Image = Global.RecordedDelivery.My.Resources.Resources.back_big
        Me.BtnBack.Location = New System.Drawing.Point(980, 789)
        Me.BtnBack.Name = "BtnBack"
        Me.BtnBack.Size = New System.Drawing.Size(700, 180)
        Me.BtnBack.TabIndex = 20
        Me.BtnBack.Text = "戻　る"
        Me.BtnBack.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnBack.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnBack.UseVisualStyleBackColor = True
        '
        'BtnMasterList
        '
        Me.BtnMasterList.Font = New System.Drawing.Font("メイリオ", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnMasterList.Image = Global.RecordedDelivery.My.Resources.Resources.printer
        Me.BtnMasterList.Location = New System.Drawing.Point(980, 575)
        Me.BtnMasterList.Name = "BtnMasterList"
        Me.BtnMasterList.Size = New System.Drawing.Size(700, 180)
        Me.BtnMasterList.TabIndex = 19
        Me.BtnMasterList.Text = "マスター一覧出力"
        Me.BtnMasterList.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnMasterList.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnMasterList.UseVisualStyleBackColor = True
        '
        'BtnOperatorEntry
        '
        Me.BtnOperatorEntry.Font = New System.Drawing.Font("メイリオ", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnOperatorEntry.Image = Global.RecordedDelivery.My.Resources.Resources.sv_op
        Me.BtnOperatorEntry.Location = New System.Drawing.Point(980, 363)
        Me.BtnOperatorEntry.Name = "BtnOperatorEntry"
        Me.BtnOperatorEntry.Size = New System.Drawing.Size(700, 180)
        Me.BtnOperatorEntry.TabIndex = 18
        Me.BtnOperatorEntry.Text = "オペレーター登録・変更"
        Me.BtnOperatorEntry.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnOperatorEntry.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnOperatorEntry.UseVisualStyleBackColor = True
        '
        'BtnMngNumber
        '
        Me.BtnMngNumber.Font = New System.Drawing.Font("メイリオ", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnMngNumber.Image = Global.RecordedDelivery.My.Resources.Resources.setting
        Me.BtnMngNumber.Location = New System.Drawing.Point(205, 575)
        Me.BtnMngNumber.Name = "BtnMngNumber"
        Me.BtnMngNumber.Size = New System.Drawing.Size(700, 180)
        Me.BtnMngNumber.TabIndex = 17
        Me.BtnMngNumber.Text = "引受番号管理"
        Me.BtnMngNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnMngNumber.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnMngNumber.UseVisualStyleBackColor = True
        '
        'BtnJobEntry
        '
        Me.BtnJobEntry.Font = New System.Drawing.Font("メイリオ", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnJobEntry.Image = Global.RecordedDelivery.My.Resources.Resources.job_big
        Me.BtnJobEntry.Location = New System.Drawing.Point(205, 363)
        Me.BtnJobEntry.Name = "BtnJobEntry"
        Me.BtnJobEntry.Size = New System.Drawing.Size(700, 180)
        Me.BtnJobEntry.TabIndex = 16
        Me.BtnJobEntry.Text = "業務登録"
        Me.BtnJobEntry.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnJobEntry.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnJobEntry.UseVisualStyleBackColor = True
        '
        'BtnClassMasterEntry
        '
        Me.BtnClassMasterEntry.Font = New System.Drawing.Font("メイリオ", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnClassMasterEntry.Image = Global.RecordedDelivery.My.Resources.Resources.database
        Me.BtnClassMasterEntry.Location = New System.Drawing.Point(980, 151)
        Me.BtnClassMasterEntry.Name = "BtnClassMasterEntry"
        Me.BtnClassMasterEntry.Size = New System.Drawing.Size(700, 180)
        Me.BtnClassMasterEntry.TabIndex = 15
        Me.BtnClassMasterEntry.Text = "種別マスター登録・変更"
        Me.BtnClassMasterEntry.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnClassMasterEntry.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnClassMasterEntry.UseVisualStyleBackColor = True
        '
        'MasterMaintForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 28.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1914, 1052)
        Me.Controls.Add(Me.LblOperatorName)
        Me.Controls.Add(Me.BtnBack)
        Me.Controls.Add(Me.BtnMasterList)
        Me.Controls.Add(Me.BtnOperatorEntry)
        Me.Controls.Add(Me.BtnMngNumber)
        Me.Controls.Add(Me.BtnJobEntry)
        Me.Controls.Add(Me.BtnClassMasterEntry)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.BtnEntrySiten)
        Me.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(6, 7, 6, 7)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MasterMaintForm"
        Me.Text = "マスターメンテナンス"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BtnEntrySiten As System.Windows.Forms.Button
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents BtnClassMasterEntry As System.Windows.Forms.Button
    Friend WithEvents BtnJobEntry As System.Windows.Forms.Button
    Friend WithEvents BtnMngNumber As System.Windows.Forms.Button
    Friend WithEvents BtnOperatorEntry As System.Windows.Forms.Button
    Friend WithEvents BtnMasterList As System.Windows.Forms.Button
    Friend WithEvents BtnBack As System.Windows.Forms.Button
    Friend WithEvents LblOperatorName As System.Windows.Forms.Label
End Class
