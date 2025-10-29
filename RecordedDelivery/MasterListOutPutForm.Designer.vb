<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MasterListOutPutForm
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
        Me.CmbMasterItem = New System.Windows.Forms.ComboBox()
        Me.LsvDataView = New System.Windows.Forms.ListView()
        Me.BtnInport = New System.Windows.Forms.Button()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.BtnExport = New System.Windows.Forms.Button()
        Me.BtnDisplay = New System.Windows.Forms.Button()
        Me.BtnBack = New System.Windows.Forms.Button()
        Me.BtnPrint = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'LblOperatorName
        '
        Me.LblOperatorName.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblOperatorName.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblOperatorName.ForeColor = System.Drawing.Color.White
        Me.LblOperatorName.Location = New System.Drawing.Point(979, 0)
        Me.LblOperatorName.Name = "LblOperatorName"
        Me.LblOperatorName.Size = New System.Drawing.Size(224, 33)
        Me.LblOperatorName.TabIndex = 171
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
        Me.lblTitle.Size = New System.Drawing.Size(1220, 36)
        Me.lblTitle.TabIndex = 170
        Me.lblTitle.Text = "マスター一覧出力"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCurrentDate
        '
        Me.lblCurrentDate.BackColor = System.Drawing.SystemColors.Control
        Me.lblCurrentDate.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblCurrentDate.ForeColor = System.Drawing.Color.Black
        Me.lblCurrentDate.Location = New System.Drawing.Point(938, 47)
        Me.lblCurrentDate.Name = "lblCurrentDate"
        Me.lblCurrentDate.Size = New System.Drawing.Size(265, 29)
        Me.lblCurrentDate.TabIndex = 169
        Me.lblCurrentDate.Text = "lblCurrentDate"
        Me.lblCurrentDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CmbMasterItem
        '
        Me.CmbMasterItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbMasterItem.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CmbMasterItem.FormattingEnabled = True
        Me.CmbMasterItem.Location = New System.Drawing.Point(12, 61)
        Me.CmbMasterItem.Name = "CmbMasterItem"
        Me.CmbMasterItem.Size = New System.Drawing.Size(454, 36)
        Me.CmbMasterItem.TabIndex = 174
        '
        'LsvDataView
        '
        Me.LsvDataView.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LsvDataView.FullRowSelect = True
        Me.LsvDataView.GridLines = True
        Me.LsvDataView.HideSelection = False
        Me.LsvDataView.Location = New System.Drawing.Point(12, 114)
        Me.LsvDataView.MultiSelect = False
        Me.LsvDataView.Name = "LsvDataView"
        Me.LsvDataView.Size = New System.Drawing.Size(1191, 483)
        Me.LsvDataView.TabIndex = 177
        Me.LsvDataView.UseCompatibleStateImageBehavior = False
        '
        'BtnInport
        '
        Me.BtnInport.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnInport.Image = Global.RecordedDelivery.My.Resources.Resources.upload
        Me.BtnInport.Location = New System.Drawing.Point(469, 613)
        Me.BtnInport.Name = "BtnInport"
        Me.BtnInport.Size = New System.Drawing.Size(160, 50)
        Me.BtnInport.TabIndex = 178
        Me.BtnInport.Text = "インポート"
        Me.BtnInport.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnInport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnInport.UseVisualStyleBackColor = True
        '
        'PrintDocument1
        '
        '
        'BtnExport
        '
        Me.BtnExport.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnExport.Image = Global.RecordedDelivery.My.Resources.Resources.download
        Me.BtnExport.Location = New System.Drawing.Point(645, 613)
        Me.BtnExport.Name = "BtnExport"
        Me.BtnExport.Size = New System.Drawing.Size(160, 50)
        Me.BtnExport.TabIndex = 179
        Me.BtnExport.Text = "エクスポート"
        Me.BtnExport.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnExport.UseVisualStyleBackColor = True
        '
        'BtnDisplay
        '
        Me.BtnDisplay.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnDisplay.Image = Global.RecordedDelivery.My.Resources.Resources.display_small
        Me.BtnDisplay.Location = New System.Drawing.Point(488, 47)
        Me.BtnDisplay.Name = "BtnDisplay"
        Me.BtnDisplay.Size = New System.Drawing.Size(160, 50)
        Me.BtnDisplay.TabIndex = 176
        Me.BtnDisplay.Text = "表示"
        Me.BtnDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnDisplay.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnDisplay.UseVisualStyleBackColor = True
        '
        'BtnBack
        '
        Me.BtnBack.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnBack.Image = Global.RecordedDelivery.My.Resources.Resources.back_small
        Me.BtnBack.Location = New System.Drawing.Point(1043, 613)
        Me.BtnBack.Name = "BtnBack"
        Me.BtnBack.Size = New System.Drawing.Size(160, 50)
        Me.BtnBack.TabIndex = 173
        Me.BtnBack.Text = "戻る"
        Me.BtnBack.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnBack.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnBack.UseVisualStyleBackColor = True
        '
        'BtnPrint
        '
        Me.BtnPrint.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnPrint.Image = Global.RecordedDelivery.My.Resources.Resources.printer_small
        Me.BtnPrint.Location = New System.Drawing.Point(867, 613)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(160, 50)
        Me.BtnPrint.TabIndex = 172
        Me.BtnPrint.Text = "印刷"
        Me.BtnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnPrint.UseVisualStyleBackColor = True
        '
        'MasterListOutPutForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 24.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1215, 675)
        Me.ControlBox = False
        Me.Controls.Add(Me.BtnExport)
        Me.Controls.Add(Me.BtnInport)
        Me.Controls.Add(Me.LsvDataView)
        Me.Controls.Add(Me.BtnDisplay)
        Me.Controls.Add(Me.CmbMasterItem)
        Me.Controls.Add(Me.BtnBack)
        Me.Controls.Add(Me.BtnPrint)
        Me.Controls.Add(Me.LblOperatorName)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.lblCurrentDate)
        Me.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MasterListOutPutForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "マスター一覧出力"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BtnBack As System.Windows.Forms.Button
    Friend WithEvents BtnPrint As System.Windows.Forms.Button
    Friend WithEvents LblOperatorName As System.Windows.Forms.Label
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents lblCurrentDate As System.Windows.Forms.Label
    Friend WithEvents CmbMasterItem As System.Windows.Forms.ComboBox
    Friend WithEvents BtnDisplay As System.Windows.Forms.Button
    Friend WithEvents LsvDataView As System.Windows.Forms.ListView
    Friend WithEvents BtnInport As System.Windows.Forms.Button
    Friend WithEvents BtnExport As System.Windows.Forms.Button
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
End Class
