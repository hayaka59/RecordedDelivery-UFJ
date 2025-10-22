<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.timIconTimer = New System.Windows.Forms.Timer(Me.components)
        Me.SerialPort = New System.IO.Ports.SerialPort(Me.components)
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.BtnDataCheck = New System.Windows.Forms.Button()
        Me.LblOperatorName = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.BtnMaintenance = New System.Windows.Forms.Button()
        Me.BtnMasterMent = New System.Windows.Forms.Button()
        Me.BtnListReport = New System.Windows.Forms.Button()
        Me.BtnReceipPublish = New System.Windows.Forms.Button()
        Me.btnEnd = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblTitle.Font = New System.Drawing.Font("メイリオ", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(-1, 0)
        Me.lblTitle.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(1916, 85)
        Me.lblTitle.TabIndex = 2
        Me.lblTitle.Text = "　書留郵便受領証発行　メインメニュー"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblVersion
        '
        Me.lblVersion.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblVersion.Location = New System.Drawing.Point(1525, 984)
        Me.lblVersion.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(359, 32)
        Me.lblVersion.TabIndex = 6
        Me.lblVersion.Text = "lblVersion"
        Me.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'timIconTimer
        '
        '
        'PrintDocument1
        '
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'BtnDataCheck
        '
        Me.BtnDataCheck.Font = New System.Drawing.Font("メイリオ", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnDataCheck.Image = Global.RecordedDelivery.My.Resources.Resources.check
        Me.BtnDataCheck.Location = New System.Drawing.Point(205, 355)
        Me.BtnDataCheck.Name = "BtnDataCheck"
        Me.BtnDataCheck.Size = New System.Drawing.Size(700, 180)
        Me.BtnDataCheck.TabIndex = 12
        Me.BtnDataCheck.Text = "データ確認・抜取り"
        Me.BtnDataCheck.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnDataCheck.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnDataCheck.UseVisualStyleBackColor = True
        '
        'LblOperatorName
        '
        Me.LblOperatorName.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblOperatorName.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblOperatorName.ForeColor = System.Drawing.Color.White
        Me.LblOperatorName.Location = New System.Drawing.Point(1652, 29)
        Me.LblOperatorName.Name = "LblOperatorName"
        Me.LblOperatorName.Size = New System.Drawing.Size(224, 33)
        Me.LblOperatorName.TabIndex = 30
        Me.LblOperatorName.Text = "LblOperatorName"
        Me.LblOperatorName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button1.Location = New System.Drawing.Point(219, 575)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(226, 71)
        Me.Button1.TabIndex = 32
        Me.Button1.Text = "バーコード（NW7）生成"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(219, 652)
        Me.TextBox1.MaxLength = 14
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(226, 36)
        Me.TextBox1.TabIndex = 33
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TextBox1.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.PictureBox1.Location = New System.Drawing.Point(454, 575)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(400, 70)
        Me.PictureBox1.TabIndex = 31
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'BtnMaintenance
        '
        Me.BtnMaintenance.Font = New System.Drawing.Font("メイリオ", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnMaintenance.Image = Global.RecordedDelivery.My.Resources.Resources.maintenance_icon
        Me.BtnMaintenance.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnMaintenance.Location = New System.Drawing.Point(205, 711)
        Me.BtnMaintenance.Name = "BtnMaintenance"
        Me.BtnMaintenance.Size = New System.Drawing.Size(700, 180)
        Me.BtnMaintenance.TabIndex = 15
        Me.BtnMaintenance.Text = "保守メニュー"
        Me.BtnMaintenance.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnMaintenance.UseCompatibleTextRendering = True
        Me.BtnMaintenance.UseVisualStyleBackColor = True
        '
        'BtnMasterMent
        '
        Me.BtnMasterMent.Font = New System.Drawing.Font("メイリオ", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnMasterMent.Image = Global.RecordedDelivery.My.Resources.Resources.database
        Me.BtnMasterMent.Location = New System.Drawing.Point(980, 355)
        Me.BtnMasterMent.Name = "BtnMasterMent"
        Me.BtnMasterMent.Size = New System.Drawing.Size(700, 180)
        Me.BtnMasterMent.TabIndex = 14
        Me.BtnMasterMent.Text = "マスターメンテナンス"
        Me.BtnMasterMent.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnMasterMent.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnMasterMent.UseVisualStyleBackColor = True
        '
        'BtnListReport
        '
        Me.BtnListReport.Font = New System.Drawing.Font("メイリオ", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnListReport.Image = Global.RecordedDelivery.My.Resources.Resources.printer
        Me.BtnListReport.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnListReport.Location = New System.Drawing.Point(980, 151)
        Me.BtnListReport.Name = "BtnListReport"
        Me.BtnListReport.Size = New System.Drawing.Size(700, 180)
        Me.BtnListReport.TabIndex = 13
        Me.BtnListReport.Text = "リスト・レポート印刷"
        Me.BtnListReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnListReport.UseVisualStyleBackColor = True
        '
        'BtnReceipPublish
        '
        Me.BtnReceipPublish.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BtnReceipPublish.Font = New System.Drawing.Font("メイリオ", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnReceipPublish.Image = Global.RecordedDelivery.My.Resources.Resources.camera
        Me.BtnReceipPublish.Location = New System.Drawing.Point(205, 151)
        Me.BtnReceipPublish.Name = "BtnReceipPublish"
        Me.BtnReceipPublish.Size = New System.Drawing.Size(700, 180)
        Me.BtnReceipPublish.TabIndex = 11
        Me.BtnReceipPublish.Text = "受領証発行処理"
        Me.BtnReceipPublish.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnReceipPublish.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnReceipPublish.UseVisualStyleBackColor = False
        '
        'btnEnd
        '
        Me.btnEnd.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnEnd.Font = New System.Drawing.Font("メイリオ", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnEnd.Image = Global.RecordedDelivery.My.Resources.Resources._exit
        Me.btnEnd.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEnd.Location = New System.Drawing.Point(980, 711)
        Me.btnEnd.Margin = New System.Windows.Forms.Padding(6, 7, 6, 7)
        Me.btnEnd.Name = "btnEnd"
        Me.btnEnd.Size = New System.Drawing.Size(700, 180)
        Me.btnEnd.TabIndex = 0
        Me.btnEnd.Text = "終　了"
        Me.btnEnd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEnd.UseVisualStyleBackColor = False
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 28.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1914, 1052)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.LblOperatorName)
        Me.Controls.Add(Me.BtnMaintenance)
        Me.Controls.Add(Me.BtnMasterMent)
        Me.Controls.Add(Me.BtnListReport)
        Me.Controls.Add(Me.BtnDataCheck)
        Me.Controls.Add(Me.BtnReceipPublish)
        Me.Controls.Add(Me.lblVersion)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.btnEnd)
        Me.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(6, 7, 6, 7)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "メインメニュー"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnEnd As System.Windows.Forms.Button
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents lblVersion As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents timIconTimer As System.Windows.Forms.Timer
    Friend WithEvents SerialPort As System.IO.Ports.SerialPort
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents BtnReceipPublish As System.Windows.Forms.Button
    Friend WithEvents BtnDataCheck As System.Windows.Forms.Button
    Friend WithEvents BtnListReport As System.Windows.Forms.Button
    Friend WithEvents BtnMasterMent As System.Windows.Forms.Button
    Friend WithEvents BtnMaintenance As System.Windows.Forms.Button
    Friend WithEvents LblOperatorName As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox

End Class
