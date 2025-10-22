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
        Me.BtnClassMasterEntry = New System.Windows.Forms.Button()
        Me.BtnJobEntry = New System.Windows.Forms.Button()
        Me.BtnMngNumber = New System.Windows.Forms.Button()
        Me.BtnOperatorEntry = New System.Windows.Forms.Button()
        Me.BtnMasterList = New System.Windows.Forms.Button()
        Me.BtnBack = New System.Windows.Forms.Button()
        Me.LblOperatorName = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'BtnEntrySiten
        '
        Me.BtnEntrySiten.Font = New System.Drawing.Font("メイリオ", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnEntrySiten.Location = New System.Drawing.Point(205, 151)
        Me.BtnEntrySiten.Name = "BtnEntrySiten"
        Me.BtnEntrySiten.Size = New System.Drawing.Size(700, 180)
        Me.BtnEntrySiten.TabIndex = 13
        Me.BtnEntrySiten.Text = "支店コード登録・変更"
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
        'BtnClassMasterEntry
        '
        Me.BtnClassMasterEntry.Font = New System.Drawing.Font("メイリオ", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnClassMasterEntry.Location = New System.Drawing.Point(980, 151)
        Me.BtnClassMasterEntry.Name = "BtnClassMasterEntry"
        Me.BtnClassMasterEntry.Size = New System.Drawing.Size(700, 180)
        Me.BtnClassMasterEntry.TabIndex = 15
        Me.BtnClassMasterEntry.Text = "種別マスター登録・変更"
        Me.BtnClassMasterEntry.UseVisualStyleBackColor = True
        '
        'BtnJobEntry
        '
        Me.BtnJobEntry.Font = New System.Drawing.Font("メイリオ", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnJobEntry.Location = New System.Drawing.Point(205, 363)
        Me.BtnJobEntry.Name = "BtnJobEntry"
        Me.BtnJobEntry.Size = New System.Drawing.Size(700, 180)
        Me.BtnJobEntry.TabIndex = 16
        Me.BtnJobEntry.Text = "業　務　登　録"
        Me.BtnJobEntry.UseVisualStyleBackColor = True
        '
        'BtnMngNumber
        '
        Me.BtnMngNumber.Font = New System.Drawing.Font("メイリオ", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnMngNumber.Location = New System.Drawing.Point(205, 575)
        Me.BtnMngNumber.Name = "BtnMngNumber"
        Me.BtnMngNumber.Size = New System.Drawing.Size(700, 180)
        Me.BtnMngNumber.TabIndex = 17
        Me.BtnMngNumber.Text = "引　受　番　号　管　理"
        Me.BtnMngNumber.UseVisualStyleBackColor = True
        '
        'BtnOperatorEntry
        '
        Me.BtnOperatorEntry.Font = New System.Drawing.Font("メイリオ", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnOperatorEntry.Location = New System.Drawing.Point(980, 363)
        Me.BtnOperatorEntry.Name = "BtnOperatorEntry"
        Me.BtnOperatorEntry.Size = New System.Drawing.Size(700, 180)
        Me.BtnOperatorEntry.TabIndex = 18
        Me.BtnOperatorEntry.Text = "オペレーター　登録・変更"
        Me.BtnOperatorEntry.UseVisualStyleBackColor = True
        '
        'BtnMasterList
        '
        Me.BtnMasterList.Font = New System.Drawing.Font("メイリオ", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnMasterList.Location = New System.Drawing.Point(980, 575)
        Me.BtnMasterList.Name = "BtnMasterList"
        Me.BtnMasterList.Size = New System.Drawing.Size(700, 180)
        Me.BtnMasterList.TabIndex = 19
        Me.BtnMasterList.Text = "マ　ス　タ　ー　一　覧　出　力"
        Me.BtnMasterList.UseVisualStyleBackColor = True
        '
        'BtnBack
        '
        Me.BtnBack.Font = New System.Drawing.Font("メイリオ", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnBack.Location = New System.Drawing.Point(980, 789)
        Me.BtnBack.Name = "BtnBack"
        Me.BtnBack.Size = New System.Drawing.Size(700, 180)
        Me.BtnBack.TabIndex = 20
        Me.BtnBack.Text = "戻　　　　る"
        Me.BtnBack.UseVisualStyleBackColor = True
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
