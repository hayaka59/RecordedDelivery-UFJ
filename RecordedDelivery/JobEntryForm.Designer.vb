<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class JobEntryForm
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbJobList = New System.Windows.Forms.ComboBox()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.TxtComment = New System.Windows.Forms.TextBox()
        Me.TxtAddress1 = New System.Windows.Forms.TextBox()
        Me.TxtAddress2 = New System.Windows.Forms.TextBox()
        Me.TxtName = New System.Windows.Forms.TextBox()
        Me.TxtPostName = New System.Windows.Forms.TextBox()
        Me.TxtTekiyou = New System.Windows.Forms.TextBox()
        Me.TxtYoushoPrice = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CmbClassification = New System.Windows.Forms.ComboBox()
        Me.LblOperatorName = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.GroupBox10 = New System.Windows.Forms.GroupBox()
        Me.BtnRecieveSetData = New System.Windows.Forms.Button()
        Me.BtnSendSetData = New System.Windows.Forms.Button()
        Me.TxtPosXCapture = New System.Windows.Forms.TextBox()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.TxtPosYCapture = New System.Windows.Forms.TextBox()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.TxtPosXLabel = New System.Windows.Forms.TextBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.TxtPosYLabel = New System.Windows.Forms.TextBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.TxtPosYFeeder = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RdoTeikeiGaiNonS = New System.Windows.Forms.RadioButton()
        Me.RdoTeikeiGai = New System.Windows.Forms.RadioButton()
        Me.RdoTeikei = New System.Windows.Forms.RadioButton()
        Me.TxtJobName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Pnl_Button = New System.Windows.Forms.Panel()
        Me.Btn_Cancel = New System.Windows.Forms.Button()
        Me.Btn_PinFormat = New System.Windows.Forms.Button()
        Me.Btn_OK = New System.Windows.Forms.Button()
        Me.Pnl_Format = New System.Windows.Forms.Panel()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.Btn_Format = New System.Windows.Forms.Button()
        Me.Chk_SubType = New System.Windows.Forms.CheckBox()
        Me.Chk_MajorType = New System.Windows.Forms.CheckBox()
        Me.Lst_Format = New System.Windows.Forms.ListBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Pnl_Pin = New System.Windows.Forms.Panel()
        Me.Cmb_Pin = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Btn_Pin = New System.Windows.Forms.Button()
        Me.Pnl_Filter = New System.Windows.Forms.Panel()
        Me.lbl_Device = New System.Windows.Forms.Label()
        Me.Cmb_Device = New System.Windows.Forms.ComboBox()
        Me.Btn_Device = New System.Windows.Forms.Button()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.SerialPort = New System.IO.Ports.SerialPort(Me.components)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.LstData = New System.Windows.Forms.ListBox()
        Me.BtnSendHikiuke = New System.Windows.Forms.Button()
        Me.TxtCd = New System.Windows.Forms.TextBox()
        Me.TxtHikiuke = New System.Windows.Forms.TextBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.BtnPaste = New System.Windows.Forms.Button()
        Me.ChkPositiveDirection = New System.Windows.Forms.CheckBox()
        Me.LblPositiveDirection = New System.Windows.Forms.Label()
        Me.BtnDelete = New System.Windows.Forms.Button()
        Me.BtnCopy = New System.Windows.Forms.Button()
        Me.BtnTestLabel = New System.Windows.Forms.Button()
        Me.BtnCameraAdjust = New System.Windows.Forms.Button()
        Me.BtnDevice = New System.Windows.Forms.Button()
        Me.Pic_View = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.BtnBack = New System.Windows.Forms.Button()
        Me.BtnSnapConfirm = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.GroupBox10.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Pnl_Button.SuspendLayout()
        Me.Pnl_Format.SuspendLayout()
        Me.Pnl_Pin.SuspendLayout()
        Me.Pnl_Filter.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.Pic_View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label2.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(248, 343)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(200, 36)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "差出人住所"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbJobList
        '
        Me.cmbJobList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbJobList.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmbJobList.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbJobList.FormattingEnabled = True
        Me.cmbJobList.Location = New System.Drawing.Point(449, 140)
        Me.cmbJobList.Name = "cmbJobList"
        Me.cmbJobList.Size = New System.Drawing.Size(804, 36)
        Me.cmbJobList.TabIndex = 22
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblTitle.Font = New System.Drawing.Font("メイリオ", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(-3, -2)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(1907, 57)
        Me.lblTitle.TabIndex = 21
        Me.lblTitle.Text = "　業務登録メニュー"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label11.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(248, 434)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(200, 36)
        Me.Label11.TabIndex = 33
        Me.Label11.Text = "差出人氏名"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label12.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(248, 480)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(200, 36)
        Me.Label12.TabIndex = 34
        Me.Label12.Text = "承 認 局 名"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label13.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(248, 527)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(200, 36)
        Me.Label13.TabIndex = 35
        Me.Label13.Text = "摘　　　要"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label15.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(248, 573)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(200, 36)
        Me.Label15.TabIndex = 37
        Me.Label15.Text = "要　償　額"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label18.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(248, 229)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(200, 36)
        Me.Label18.TabIndex = 40
        Me.Label18.Text = "コ メ ン ト"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtComment
        '
        Me.TxtComment.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TxtComment.Location = New System.Drawing.Point(449, 229)
        Me.TxtComment.MaxLength = 999
        Me.TxtComment.Name = "TxtComment"
        Me.TxtComment.Size = New System.Drawing.Size(804, 36)
        Me.TxtComment.TabIndex = 42
        Me.TxtComment.Text = "TxtComment"
        '
        'TxtAddress1
        '
        Me.TxtAddress1.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TxtAddress1.Location = New System.Drawing.Point(449, 343)
        Me.TxtAddress1.MaxLength = 999
        Me.TxtAddress1.Name = "TxtAddress1"
        Me.TxtAddress1.Size = New System.Drawing.Size(804, 36)
        Me.TxtAddress1.TabIndex = 43
        Me.TxtAddress1.Text = "TxtAddress1"
        '
        'TxtAddress2
        '
        Me.TxtAddress2.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TxtAddress2.Location = New System.Drawing.Point(449, 389)
        Me.TxtAddress2.MaxLength = 999
        Me.TxtAddress2.Name = "TxtAddress2"
        Me.TxtAddress2.Size = New System.Drawing.Size(804, 36)
        Me.TxtAddress2.TabIndex = 44
        Me.TxtAddress2.Text = "TxtAddress2"
        '
        'TxtName
        '
        Me.TxtName.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TxtName.Location = New System.Drawing.Point(449, 434)
        Me.TxtName.MaxLength = 999
        Me.TxtName.Name = "TxtName"
        Me.TxtName.Size = New System.Drawing.Size(804, 36)
        Me.TxtName.TabIndex = 45
        Me.TxtName.Text = "TxtName"
        '
        'TxtPostName
        '
        Me.TxtPostName.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TxtPostName.Location = New System.Drawing.Point(449, 480)
        Me.TxtPostName.MaxLength = 999
        Me.TxtPostName.Name = "TxtPostName"
        Me.TxtPostName.Size = New System.Drawing.Size(804, 36)
        Me.TxtPostName.TabIndex = 46
        Me.TxtPostName.Text = "TxtPostName"
        '
        'TxtTekiyou
        '
        Me.TxtTekiyou.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TxtTekiyou.Location = New System.Drawing.Point(449, 527)
        Me.TxtTekiyou.MaxLength = 999
        Me.TxtTekiyou.Name = "TxtTekiyou"
        Me.TxtTekiyou.Size = New System.Drawing.Size(804, 36)
        Me.TxtTekiyou.TabIndex = 49
        Me.TxtTekiyou.Text = "TxtTekiyou"
        '
        'TxtYoushoPrice
        '
        Me.TxtYoushoPrice.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TxtYoushoPrice.Location = New System.Drawing.Point(449, 572)
        Me.TxtYoushoPrice.MaxLength = 4
        Me.TxtYoushoPrice.Name = "TxtYoushoPrice"
        Me.TxtYoushoPrice.Size = New System.Drawing.Size(804, 36)
        Me.TxtYoushoPrice.TabIndex = 50
        Me.TxtYoushoPrice.Text = "TxtYoushoPrice"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label3.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(248, 140)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(200, 36)
        Me.Label3.TabIndex = 80
        Me.Label3.Text = "業 務 選 択"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label6.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(248, 287)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(200, 36)
        Me.Label6.TabIndex = 83
        Me.Label6.Text = "種　　　別"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CmbClassification
        '
        Me.CmbClassification.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbClassification.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CmbClassification.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CmbClassification.FormattingEnabled = True
        Me.CmbClassification.Location = New System.Drawing.Point(449, 287)
        Me.CmbClassification.Name = "CmbClassification"
        Me.CmbClassification.Size = New System.Drawing.Size(351, 36)
        Me.CmbClassification.TabIndex = 84
        '
        'LblOperatorName
        '
        Me.LblOperatorName.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblOperatorName.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblOperatorName.ForeColor = System.Drawing.Color.White
        Me.LblOperatorName.Location = New System.Drawing.Point(1636, 11)
        Me.LblOperatorName.Name = "LblOperatorName"
        Me.LblOperatorName.Size = New System.Drawing.Size(224, 33)
        Me.LblOperatorName.TabIndex = 145
        Me.LblOperatorName.Text = "LblOperatorName"
        Me.LblOperatorName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label7.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.Location = New System.Drawing.Point(771, 632)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(109, 24)
        Me.Label7.TabIndex = 156
        Me.Label7.Text = "静止画像"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label14.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label14.Location = New System.Drawing.Point(244, 632)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(109, 24)
        Me.Label14.TabIndex = 155
        Me.Label14.Text = "ライブ画像"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox10
        '
        Me.GroupBox10.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox10.Controls.Add(Me.BtnRecieveSetData)
        Me.GroupBox10.Controls.Add(Me.BtnSendSetData)
        Me.GroupBox10.Controls.Add(Me.TxtPosXCapture)
        Me.GroupBox10.Controls.Add(Me.Label42)
        Me.GroupBox10.Controls.Add(Me.TxtPosYCapture)
        Me.GroupBox10.Controls.Add(Me.Label43)
        Me.GroupBox10.Controls.Add(Me.Label44)
        Me.GroupBox10.Controls.Add(Me.TxtPosXLabel)
        Me.GroupBox10.Controls.Add(Me.Label41)
        Me.GroupBox10.Controls.Add(Me.TxtPosYLabel)
        Me.GroupBox10.Controls.Add(Me.Label38)
        Me.GroupBox10.Controls.Add(Me.Label8)
        Me.GroupBox10.Controls.Add(Me.Label21)
        Me.GroupBox10.Controls.Add(Me.TxtPosYFeeder)
        Me.GroupBox10.Controls.Add(Me.Label9)
        Me.GroupBox10.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox10.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox10.Location = New System.Drawing.Point(1295, 216)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(304, 430)
        Me.GroupBox10.TabIndex = 157
        Me.GroupBox10.TabStop = False
        '
        'BtnRecieveSetData
        '
        Me.BtnRecieveSetData.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnRecieveSetData.Location = New System.Drawing.Point(161, 340)
        Me.BtnRecieveSetData.Name = "BtnRecieveSetData"
        Me.BtnRecieveSetData.Size = New System.Drawing.Size(121, 52)
        Me.BtnRecieveSetData.TabIndex = 48
        Me.BtnRecieveSetData.Text = "現在値要求"
        Me.BtnRecieveSetData.UseVisualStyleBackColor = True
        '
        'BtnSendSetData
        '
        Me.BtnSendSetData.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnSendSetData.Location = New System.Drawing.Point(19, 340)
        Me.BtnSendSetData.Name = "BtnSendSetData"
        Me.BtnSendSetData.Size = New System.Drawing.Size(121, 52)
        Me.BtnSendSetData.TabIndex = 47
        Me.BtnSendSetData.Text = "設定送信"
        Me.BtnSendSetData.UseVisualStyleBackColor = True
        '
        'TxtPosXCapture
        '
        Me.TxtPosXCapture.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TxtPosXCapture.Location = New System.Drawing.Point(214, 292)
        Me.TxtPosXCapture.MaxLength = 3
        Me.TxtPosXCapture.Name = "TxtPosXCapture"
        Me.TxtPosXCapture.Size = New System.Drawing.Size(68, 31)
        Me.TxtPosXCapture.TabIndex = 36
        Me.TxtPosXCapture.Text = "10"
        Me.TxtPosXCapture.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label42
        '
        Me.Label42.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label42.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label42.ForeColor = System.Drawing.Color.Black
        Me.Label42.Location = New System.Drawing.Point(20, 293)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(203, 30)
        Me.Label42.TabIndex = 35
        Me.Label42.Text = "横方向（画角中央）"
        Me.Label42.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtPosYCapture
        '
        Me.TxtPosYCapture.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TxtPosYCapture.Location = New System.Drawing.Point(214, 255)
        Me.TxtPosYCapture.MaxLength = 3
        Me.TxtPosYCapture.Name = "TxtPosYCapture"
        Me.TxtPosYCapture.Size = New System.Drawing.Size(68, 31)
        Me.TxtPosYCapture.TabIndex = 34
        Me.TxtPosYCapture.Text = "10"
        Me.TxtPosYCapture.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label43
        '
        Me.Label43.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label43.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label43.ForeColor = System.Drawing.Color.Black
        Me.Label43.Location = New System.Drawing.Point(20, 256)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(203, 30)
        Me.Label43.TabIndex = 33
        Me.Label43.Text = "送方向（画角中央）"
        Me.Label43.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label44
        '
        Me.Label44.BackColor = System.Drawing.SystemColors.Control
        Me.Label44.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label44.ForeColor = System.Drawing.Color.Black
        Me.Label44.Location = New System.Drawing.Point(24, 224)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(252, 30)
        Me.Label44.TabIndex = 32
        Me.Label44.Text = "宛名撮像位置"
        Me.Label44.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtPosXLabel
        '
        Me.TxtPosXLabel.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TxtPosXLabel.Location = New System.Drawing.Point(212, 171)
        Me.TxtPosXLabel.MaxLength = 3
        Me.TxtPosXLabel.Name = "TxtPosXLabel"
        Me.TxtPosXLabel.Size = New System.Drawing.Size(68, 31)
        Me.TxtPosXLabel.TabIndex = 31
        Me.TxtPosXLabel.Text = "10"
        Me.TxtPosXLabel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label41
        '
        Me.Label41.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label41.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label41.ForeColor = System.Drawing.Color.Black
        Me.Label41.Location = New System.Drawing.Point(18, 172)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(203, 30)
        Me.Label41.TabIndex = 30
        Me.Label41.Text = "横方向（左辺）"
        Me.Label41.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtPosYLabel
        '
        Me.TxtPosYLabel.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TxtPosYLabel.Location = New System.Drawing.Point(212, 134)
        Me.TxtPosYLabel.MaxLength = 3
        Me.TxtPosYLabel.Name = "TxtPosYLabel"
        Me.TxtPosYLabel.Size = New System.Drawing.Size(68, 31)
        Me.TxtPosYLabel.TabIndex = 29
        Me.TxtPosYLabel.Text = "10"
        Me.TxtPosYLabel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label38
        '
        Me.Label38.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label38.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label38.ForeColor = System.Drawing.Color.Black
        Me.Label38.Location = New System.Drawing.Point(18, 135)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(203, 30)
        Me.Label38.TabIndex = 28
        Me.Label38.Text = "送方向（上辺）"
        Me.Label38.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.Control
        Me.Label8.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(22, 103)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(252, 30)
        Me.Label8.TabIndex = 27
        Me.Label8.Text = "ラベル貼付位置"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.SystemColors.Control
        Me.Label21.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Black
        Me.Label21.Location = New System.Drawing.Point(22, 24)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(252, 30)
        Me.Label21.TabIndex = 26
        Me.Label21.Text = "フィーダー位置"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtPosYFeeder
        '
        Me.TxtPosYFeeder.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TxtPosYFeeder.Location = New System.Drawing.Point(212, 57)
        Me.TxtPosYFeeder.MaxLength = 3
        Me.TxtPosYFeeder.Name = "TxtPosYFeeder"
        Me.TxtPosYFeeder.Size = New System.Drawing.Size(68, 31)
        Me.TxtPosYFeeder.TabIndex = 25
        Me.TxtPosYFeeder.Text = "10"
        Me.TxtPosYFeeder.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label9.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(18, 57)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(203, 30)
        Me.Label9.TabIndex = 24
        Me.Label9.Text = "封筒幅"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox1.Controls.Add(Me.RdoTeikeiGaiNonS)
        Me.GroupBox1.Controls.Add(Me.RdoTeikeiGai)
        Me.GroupBox1.Controls.Add(Me.RdoTeikei)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox1.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(813, 271)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(440, 64)
        Me.GroupBox1.TabIndex = 158
        Me.GroupBox1.TabStop = False
        '
        'RdoTeikeiGaiNonS
        '
        Me.RdoTeikeiGaiNonS.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.RdoTeikeiGaiNonS.Location = New System.Drawing.Point(259, 24)
        Me.RdoTeikeiGaiNonS.Name = "RdoTeikeiGaiNonS"
        Me.RdoTeikeiGaiNonS.Size = New System.Drawing.Size(164, 28)
        Me.RdoTeikeiGaiNonS.TabIndex = 4
        Me.RdoTeikeiGaiNonS.Text = "定形外(規格外)"
        Me.RdoTeikeiGaiNonS.UseVisualStyleBackColor = True
        '
        'RdoTeikeiGai
        '
        Me.RdoTeikeiGai.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.RdoTeikeiGai.Location = New System.Drawing.Point(90, 23)
        Me.RdoTeikeiGai.Name = "RdoTeikeiGai"
        Me.RdoTeikeiGai.Size = New System.Drawing.Size(162, 28)
        Me.RdoTeikeiGai.TabIndex = 2
        Me.RdoTeikeiGai.Text = "定形外(規格内)"
        Me.RdoTeikeiGai.UseVisualStyleBackColor = True
        '
        'RdoTeikei
        '
        Me.RdoTeikei.Checked = True
        Me.RdoTeikei.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.RdoTeikei.Location = New System.Drawing.Point(13, 23)
        Me.RdoTeikei.Name = "RdoTeikei"
        Me.RdoTeikei.Size = New System.Drawing.Size(79, 28)
        Me.RdoTeikei.TabIndex = 1
        Me.RdoTeikei.TabStop = True
        Me.RdoTeikei.Text = "定形"
        Me.RdoTeikei.UseVisualStyleBackColor = True
        '
        'TxtJobName
        '
        Me.TxtJobName.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TxtJobName.Location = New System.Drawing.Point(449, 185)
        Me.TxtJobName.MaxLength = 999
        Me.TxtJobName.Name = "TxtJobName"
        Me.TxtJobName.Size = New System.Drawing.Size(804, 36)
        Me.TxtJobName.TabIndex = 160
        Me.TxtJobName.Text = "TxtJobName"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(248, 185)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(200, 36)
        Me.Label1.TabIndex = 159
        Me.Label1.Text = "業　務　名"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Pnl_Button)
        Me.Panel1.Controls.Add(Me.Pnl_Format)
        Me.Panel1.Controls.Add(Me.Pnl_Pin)
        Me.Panel1.Controls.Add(Me.Pnl_Filter)
        Me.Panel1.Location = New System.Drawing.Point(1440, 643)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(445, 340)
        Me.Panel1.TabIndex = 162
        '
        'Pnl_Button
        '
        Me.Pnl_Button.Controls.Add(Me.Btn_Cancel)
        Me.Pnl_Button.Controls.Add(Me.Btn_PinFormat)
        Me.Pnl_Button.Controls.Add(Me.Btn_OK)
        Me.Pnl_Button.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pnl_Button.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Pnl_Button.Location = New System.Drawing.Point(0, 297)
        Me.Pnl_Button.Name = "Pnl_Button"
        Me.Pnl_Button.Size = New System.Drawing.Size(445, 35)
        Me.Pnl_Button.TabIndex = 23
        '
        'Btn_Cancel
        '
        Me.Btn_Cancel.Location = New System.Drawing.Point(312, 3)
        Me.Btn_Cancel.Name = "Btn_Cancel"
        Me.Btn_Cancel.Size = New System.Drawing.Size(117, 23)
        Me.Btn_Cancel.TabIndex = 15
        Me.Btn_Cancel.Tag = ""
        Me.Btn_Cancel.Text = "キャンセル"
        Me.Btn_Cancel.UseVisualStyleBackColor = True
        Me.Btn_Cancel.Visible = False
        '
        'Btn_PinFormat
        '
        Me.Btn_PinFormat.Location = New System.Drawing.Point(8, 3)
        Me.Btn_PinFormat.Name = "Btn_PinFormat"
        Me.Btn_PinFormat.Size = New System.Drawing.Size(117, 23)
        Me.Btn_PinFormat.TabIndex = 13
        Me.Btn_PinFormat.Tag = "3"
        Me.Btn_PinFormat.Text = "フォーマット"
        Me.Btn_PinFormat.UseVisualStyleBackColor = True
        Me.Btn_PinFormat.Visible = False
        '
        'Btn_OK
        '
        Me.Btn_OK.Location = New System.Drawing.Point(161, 3)
        Me.Btn_OK.Name = "Btn_OK"
        Me.Btn_OK.Size = New System.Drawing.Size(117, 23)
        Me.Btn_OK.TabIndex = 14
        Me.Btn_OK.Tag = "3"
        Me.Btn_OK.Text = "OK"
        Me.Btn_OK.UseVisualStyleBackColor = True
        Me.Btn_OK.Visible = False
        '
        'Pnl_Format
        '
        Me.Pnl_Format.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Pnl_Format.Controls.Add(Me.BtnClose)
        Me.Pnl_Format.Controls.Add(Me.Btn_Format)
        Me.Pnl_Format.Controls.Add(Me.Chk_SubType)
        Me.Pnl_Format.Controls.Add(Me.Chk_MajorType)
        Me.Pnl_Format.Controls.Add(Me.Lst_Format)
        Me.Pnl_Format.Controls.Add(Me.Label4)
        Me.Pnl_Format.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pnl_Format.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Pnl_Format.Location = New System.Drawing.Point(0, 96)
        Me.Pnl_Format.Name = "Pnl_Format"
        Me.Pnl_Format.Size = New System.Drawing.Size(445, 201)
        Me.Pnl_Format.TabIndex = 22
        '
        'BtnClose
        '
        Me.BtnClose.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnClose.Location = New System.Drawing.Point(188, 159)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(117, 32)
        Me.BtnClose.TabIndex = 19
        Me.BtnClose.Tag = "3"
        Me.BtnClose.Text = "閉じる"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'Btn_Format
        '
        Me.Btn_Format.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Btn_Format.Location = New System.Drawing.Point(312, 159)
        Me.Btn_Format.Name = "Btn_Format"
        Me.Btn_Format.Size = New System.Drawing.Size(117, 32)
        Me.Btn_Format.TabIndex = 18
        Me.Btn_Format.Tag = "3"
        Me.Btn_Format.Text = "設定保存"
        Me.Btn_Format.UseVisualStyleBackColor = True
        '
        'Chk_SubType
        '
        Me.Chk_SubType.AutoSize = True
        Me.Chk_SubType.Location = New System.Drawing.Point(120, 156)
        Me.Chk_SubType.Name = "Chk_SubType"
        Me.Chk_SubType.Size = New System.Drawing.Size(86, 24)
        Me.Chk_SubType.TabIndex = 17
        Me.Chk_SubType.Text = "Sub Type"
        Me.Chk_SubType.UseVisualStyleBackColor = True
        Me.Chk_SubType.Visible = False
        '
        'Chk_MajorType
        '
        Me.Chk_MajorType.AutoSize = True
        Me.Chk_MajorType.Checked = True
        Me.Chk_MajorType.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Chk_MajorType.Location = New System.Drawing.Point(16, 156)
        Me.Chk_MajorType.Name = "Chk_MajorType"
        Me.Chk_MajorType.Size = New System.Drawing.Size(98, 24)
        Me.Chk_MajorType.TabIndex = 17
        Me.Chk_MajorType.Text = "Major Type"
        Me.Chk_MajorType.UseVisualStyleBackColor = True
        Me.Chk_MajorType.Visible = False
        '
        'Lst_Format
        '
        Me.Lst_Format.FormattingEnabled = True
        Me.Lst_Format.ItemHeight = 20
        Me.Lst_Format.Location = New System.Drawing.Point(16, 32)
        Me.Lst_Format.Name = "Lst_Format"
        Me.Lst_Format.Size = New System.Drawing.Size(413, 124)
        Me.Lst_Format.TabIndex = 16
        Me.Lst_Format.Tag = "3"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(113, 20)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "出力フォーマット"
        '
        'Pnl_Pin
        '
        Me.Pnl_Pin.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Pnl_Pin.Controls.Add(Me.Cmb_Pin)
        Me.Pnl_Pin.Controls.Add(Me.Label5)
        Me.Pnl_Pin.Controls.Add(Me.Btn_Pin)
        Me.Pnl_Pin.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pnl_Pin.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Pnl_Pin.Location = New System.Drawing.Point(0, 48)
        Me.Pnl_Pin.Name = "Pnl_Pin"
        Me.Pnl_Pin.Size = New System.Drawing.Size(445, 48)
        Me.Pnl_Pin.TabIndex = 21
        '
        'Cmb_Pin
        '
        Me.Cmb_Pin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_Pin.FormattingEnabled = True
        Me.Cmb_Pin.Location = New System.Drawing.Point(75, 12)
        Me.Cmb_Pin.Name = "Cmb_Pin"
        Me.Cmb_Pin.Size = New System.Drawing.Size(243, 28)
        Me.Cmb_Pin.TabIndex = 11
        Me.Cmb_Pin.Tag = "2"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 8)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 20)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "出力ピン"
        '
        'Btn_Pin
        '
        Me.Btn_Pin.Location = New System.Drawing.Point(324, 8)
        Me.Btn_Pin.Name = "Btn_Pin"
        Me.Btn_Pin.Size = New System.Drawing.Size(105, 34)
        Me.Btn_Pin.TabIndex = 12
        Me.Btn_Pin.Tag = "3"
        Me.Btn_Pin.Text = "プロパティ"
        Me.Btn_Pin.UseVisualStyleBackColor = True
        Me.Btn_Pin.Visible = False
        '
        'Pnl_Filter
        '
        Me.Pnl_Filter.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Pnl_Filter.Controls.Add(Me.lbl_Device)
        Me.Pnl_Filter.Controls.Add(Me.Cmb_Device)
        Me.Pnl_Filter.Controls.Add(Me.Btn_Device)
        Me.Pnl_Filter.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pnl_Filter.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Pnl_Filter.Location = New System.Drawing.Point(0, 0)
        Me.Pnl_Filter.Name = "Pnl_Filter"
        Me.Pnl_Filter.Size = New System.Drawing.Size(445, 48)
        Me.Pnl_Filter.TabIndex = 20
        '
        'lbl_Device
        '
        Me.lbl_Device.AutoSize = True
        Me.lbl_Device.Location = New System.Drawing.Point(8, 8)
        Me.lbl_Device.Name = "lbl_Device"
        Me.lbl_Device.Size = New System.Drawing.Size(61, 20)
        Me.lbl_Device.TabIndex = 9
        Me.lbl_Device.Text = "デバイス"
        '
        'Cmb_Device
        '
        Me.Cmb_Device.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_Device.FormattingEnabled = True
        Me.Cmb_Device.Location = New System.Drawing.Point(75, 9)
        Me.Cmb_Device.Name = "Cmb_Device"
        Me.Cmb_Device.Size = New System.Drawing.Size(243, 28)
        Me.Cmb_Device.TabIndex = 7
        Me.Cmb_Device.Tag = "1"
        '
        'Btn_Device
        '
        Me.Btn_Device.Location = New System.Drawing.Point(324, 6)
        Me.Btn_Device.Name = "Btn_Device"
        Me.Btn_Device.Size = New System.Drawing.Size(105, 33)
        Me.Btn_Device.TabIndex = 8
        Me.Btn_Device.Tag = "2"
        Me.Btn_Device.Text = "プロパティ"
        Me.Btn_Device.UseVisualStyleBackColor = True
        Me.Btn_Device.Visible = False
        '
        'lblVersion
        '
        Me.lblVersion.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblVersion.Location = New System.Drawing.Point(1532, 998)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(353, 24)
        Me.lblVersion.TabIndex = 163
        Me.lblVersion.Text = "lblVersion"
        Me.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'SerialPort
        '
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.BtnCancel)
        Me.GroupBox2.Controls.Add(Me.LstData)
        Me.GroupBox2.Controls.Add(Me.BtnSendHikiuke)
        Me.GroupBox2.Controls.Add(Me.TxtCd)
        Me.GroupBox2.Controls.Add(Me.TxtHikiuke)
        Me.GroupBox2.Location = New System.Drawing.Point(1625, 70)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(260, 80)
        Me.GroupBox2.TabIndex = 164
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "LR4820RVe2テスト"
        Me.GroupBox2.Visible = False
        '
        'BtnCancel
        '
        Me.BtnCancel.Location = New System.Drawing.Point(23, 368)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(193, 41)
        Me.BtnCancel.TabIndex = 4
        Me.BtnCancel.Text = "データキャンセル"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'LstData
        '
        Me.LstData.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LstData.FormattingEnabled = True
        Me.LstData.ItemHeight = 20
        Me.LstData.Location = New System.Drawing.Point(6, 157)
        Me.LstData.Name = "LstData"
        Me.LstData.Size = New System.Drawing.Size(248, 204)
        Me.LstData.TabIndex = 3
        '
        'BtnSendHikiuke
        '
        Me.BtnSendHikiuke.Location = New System.Drawing.Point(23, 101)
        Me.BtnSendHikiuke.Name = "BtnSendHikiuke"
        Me.BtnSendHikiuke.Size = New System.Drawing.Size(193, 41)
        Me.BtnSendHikiuke.TabIndex = 2
        Me.BtnSendHikiuke.Text = "送　信"
        Me.BtnSendHikiuke.UseVisualStyleBackColor = True
        '
        'TxtCd
        '
        Me.TxtCd.Location = New System.Drawing.Point(176, 55)
        Me.TxtCd.MaxLength = 1
        Me.TxtCd.Name = "TxtCd"
        Me.TxtCd.Size = New System.Drawing.Size(40, 36)
        Me.TxtCd.TabIndex = 1
        Me.TxtCd.Text = "9"
        Me.TxtCd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtHikiuke
        '
        Me.TxtHikiuke.Location = New System.Drawing.Point(23, 56)
        Me.TxtHikiuke.MaxLength = 10
        Me.TxtHikiuke.Name = "TxtHikiuke"
        Me.TxtHikiuke.Size = New System.Drawing.Size(147, 36)
        Me.TxtHikiuke.TabIndex = 0
        Me.TxtHikiuke.Text = "1234567890"
        Me.TxtHikiuke.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'BtnPaste
        '
        Me.BtnPaste.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnPaste.Image = Global.RecordedDelivery.My.Resources.Resources.paste
        Me.BtnPaste.Location = New System.Drawing.Point(454, 70)
        Me.BtnPaste.Name = "BtnPaste"
        Me.BtnPaste.Size = New System.Drawing.Size(200, 53)
        Me.BtnPaste.TabIndex = 168
        Me.BtnPaste.Text = "全項目ペースト"
        Me.BtnPaste.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnPaste.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnPaste.UseVisualStyleBackColor = True
        '
        'ChkPositiveDirection
        '
        Me.ChkPositiveDirection.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ChkPositiveDirection.Location = New System.Drawing.Point(1640, 434)
        Me.ChkPositiveDirection.Name = "ChkPositiveDirection"
        Me.ChkPositiveDirection.Size = New System.Drawing.Size(236, 31)
        Me.ChkPositiveDirection.TabIndex = 170
        Me.ChkPositiveDirection.Text = "正方向流し"
        Me.ChkPositiveDirection.UseVisualStyleBackColor = False
        '
        'LblPositiveDirection
        '
        Me.LblPositiveDirection.BackColor = System.Drawing.SystemColors.Control
        Me.LblPositiveDirection.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblPositiveDirection.ForeColor = System.Drawing.Color.Red
        Me.LblPositiveDirection.Location = New System.Drawing.Point(914, 630)
        Me.LblPositiveDirection.Name = "LblPositiveDirection"
        Me.LblPositiveDirection.Size = New System.Drawing.Size(215, 24)
        Me.LblPositiveDirection.TabIndex = 173
        Me.LblPositiveDirection.Text = "画像表示反転"
        Me.LblPositiveDirection.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnDelete
        '
        Me.BtnDelete.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnDelete.Image = Global.RecordedDelivery.My.Resources.Resources.trash_icon
        Me.BtnDelete.Location = New System.Drawing.Point(1619, 140)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(250, 68)
        Me.BtnDelete.TabIndex = 169
        Me.BtnDelete.Text = "削除"
        Me.BtnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnDelete.UseVisualStyleBackColor = True
        '
        'BtnCopy
        '
        Me.BtnCopy.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnCopy.Image = Global.RecordedDelivery.My.Resources.Resources.copy_icon
        Me.BtnCopy.Location = New System.Drawing.Point(248, 70)
        Me.BtnCopy.Name = "BtnCopy"
        Me.BtnCopy.Size = New System.Drawing.Size(200, 53)
        Me.BtnCopy.TabIndex = 167
        Me.BtnCopy.Text = "全項目コピー"
        Me.BtnCopy.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnCopy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnCopy.UseVisualStyleBackColor = True
        '
        'BtnTestLabel
        '
        Me.BtnTestLabel.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnTestLabel.Image = Global.RecordedDelivery.My.Resources.Resources.attach
        Me.BtnTestLabel.Location = New System.Drawing.Point(1640, 555)
        Me.BtnTestLabel.Name = "BtnTestLabel"
        Me.BtnTestLabel.Size = New System.Drawing.Size(236, 53)
        Me.BtnTestLabel.TabIndex = 166
        Me.BtnTestLabel.Text = "ラベル試貼り"
        Me.BtnTestLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnTestLabel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnTestLabel.UseVisualStyleBackColor = True
        '
        'BtnCameraAdjust
        '
        Me.BtnCameraAdjust.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnCameraAdjust.Image = Global.RecordedDelivery.My.Resources.Resources.setting_small
        Me.BtnCameraAdjust.Location = New System.Drawing.Point(1640, 489)
        Me.BtnCameraAdjust.Name = "BtnCameraAdjust"
        Me.BtnCameraAdjust.Size = New System.Drawing.Size(236, 53)
        Me.BtnCameraAdjust.TabIndex = 165
        Me.BtnCameraAdjust.Text = "カメラ調整"
        Me.BtnCameraAdjust.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnCameraAdjust.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnCameraAdjust.UseVisualStyleBackColor = True
        '
        'BtnDevice
        '
        Me.BtnDevice.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnDevice.Image = Global.RecordedDelivery.My.Resources.Resources.setting_small
        Me.BtnDevice.Location = New System.Drawing.Point(1319, 739)
        Me.BtnDevice.Name = "BtnDevice"
        Me.BtnDevice.Size = New System.Drawing.Size(250, 45)
        Me.BtnDevice.TabIndex = 161
        Me.BtnDevice.Text = "カメラ設定"
        Me.BtnDevice.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnDevice.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnDevice.UseVisualStyleBackColor = True
        '
        'Pic_View
        '
        Me.Pic_View.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pic_View.Location = New System.Drawing.Point(244, 657)
        Me.Pic_View.Name = "Pic_View"
        Me.Pic_View.Size = New System.Drawing.Size(495, 270)
        Me.Pic_View.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Pic_View.TabIndex = 153
        Me.Pic_View.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Black
        Me.PictureBox1.Location = New System.Drawing.Point(770, 657)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(495, 270)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 154
        Me.PictureBox1.TabStop = False
        '
        'BtnBack
        '
        Me.BtnBack.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnBack.Image = Global.RecordedDelivery.My.Resources.Resources.back_small
        Me.BtnBack.Location = New System.Drawing.Point(1319, 828)
        Me.BtnBack.Name = "BtnBack"
        Me.BtnBack.Size = New System.Drawing.Size(250, 68)
        Me.BtnBack.TabIndex = 88
        Me.BtnBack.Text = "戻る"
        Me.BtnBack.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnBack.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnBack.UseVisualStyleBackColor = True
        '
        'BtnSnapConfirm
        '
        Me.BtnSnapConfirm.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnSnapConfirm.Image = Global.RecordedDelivery.My.Resources.Resources.camera_small
        Me.BtnSnapConfirm.Location = New System.Drawing.Point(1319, 659)
        Me.BtnSnapConfirm.Name = "BtnSnapConfirm"
        Me.BtnSnapConfirm.Size = New System.Drawing.Size(250, 68)
        Me.BtnSnapConfirm.TabIndex = 7
        Me.BtnSnapConfirm.Text = "撮像確認"
        Me.BtnSnapConfirm.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnSnapConfirm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnSnapConfirm.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnSave.Image = Global.RecordedDelivery.My.Resources.Resources.save_icon
        Me.btnSave.Location = New System.Drawing.Point(1319, 140)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(250, 68)
        Me.btnSave.TabIndex = 6
        Me.btnSave.Text = "保存"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'JobEntryForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 28.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1904, 1042)
        Me.ControlBox = False
        Me.Controls.Add(Me.LblPositiveDirection)
        Me.Controls.Add(Me.ChkPositiveDirection)
        Me.Controls.Add(Me.BtnDelete)
        Me.Controls.Add(Me.BtnPaste)
        Me.Controls.Add(Me.BtnCopy)
        Me.Controls.Add(Me.BtnTestLabel)
        Me.Controls.Add(Me.BtnCameraAdjust)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lblVersion)
        Me.Controls.Add(Me.BtnDevice)
        Me.Controls.Add(Me.TxtJobName)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtComment)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox10)
        Me.Controls.Add(Me.Pic_View)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.LblOperatorName)
        Me.Controls.Add(Me.BtnBack)
        Me.Controls.Add(Me.CmbClassification)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtYoushoPrice)
        Me.Controls.Add(Me.TxtTekiyou)
        Me.Controls.Add(Me.TxtPostName)
        Me.Controls.Add(Me.TxtName)
        Me.Controls.Add(Me.TxtAddress2)
        Me.Controls.Add(Me.TxtAddress1)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.cmbJobList)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.BtnSnapConfirm)
        Me.Controls.Add(Me.btnSave)
        Me.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Margin = New System.Windows.Forms.Padding(6, 7, 6, 7)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "JobEntryForm"
        Me.Text = "業務登録"
        Me.GroupBox10.ResumeLayout(False)
        Me.GroupBox10.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Pnl_Button.ResumeLayout(False)
        Me.Pnl_Format.ResumeLayout(False)
        Me.Pnl_Format.PerformLayout()
        Me.Pnl_Pin.ResumeLayout(False)
        Me.Pnl_Pin.PerformLayout()
        Me.Pnl_Filter.ResumeLayout(False)
        Me.Pnl_Filter.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.Pic_View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents BtnSnapConfirm As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbJobList As System.Windows.Forms.ComboBox
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents TxtComment As System.Windows.Forms.TextBox
    Friend WithEvents TxtAddress1 As System.Windows.Forms.TextBox
    Friend WithEvents TxtAddress2 As System.Windows.Forms.TextBox
    Friend WithEvents TxtName As System.Windows.Forms.TextBox
    Friend WithEvents TxtPostName As System.Windows.Forms.TextBox
    Friend WithEvents TxtTekiyou As System.Windows.Forms.TextBox
    Friend WithEvents TxtYoushoPrice As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CmbClassification As System.Windows.Forms.ComboBox
    Friend WithEvents BtnBack As System.Windows.Forms.Button
    Friend WithEvents LblOperatorName As System.Windows.Forms.Label
    Friend WithEvents Pic_View As System.Windows.Forms.PictureBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents GroupBox10 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnSendSetData As System.Windows.Forms.Button
    Friend WithEvents TxtPosXCapture As System.Windows.Forms.TextBox
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents TxtPosYCapture As System.Windows.Forms.TextBox
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents TxtPosXLabel As System.Windows.Forms.TextBox
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents TxtPosYLabel As System.Windows.Forms.TextBox
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents TxtPosYFeeder As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RdoTeikeiGai As System.Windows.Forms.RadioButton
    Friend WithEvents RdoTeikei As System.Windows.Forms.RadioButton
    Friend WithEvents TxtJobName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnDevice As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Pnl_Button As System.Windows.Forms.Panel
    Friend WithEvents Btn_Cancel As System.Windows.Forms.Button
    Friend WithEvents Btn_PinFormat As System.Windows.Forms.Button
    Friend WithEvents Btn_OK As System.Windows.Forms.Button
    Friend WithEvents Pnl_Format As System.Windows.Forms.Panel
    Friend WithEvents Btn_Format As System.Windows.Forms.Button
    Friend WithEvents Chk_SubType As System.Windows.Forms.CheckBox
    Friend WithEvents Chk_MajorType As System.Windows.Forms.CheckBox
    Friend WithEvents Lst_Format As System.Windows.Forms.ListBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Pnl_Pin As System.Windows.Forms.Panel
    Friend WithEvents Cmb_Pin As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Btn_Pin As System.Windows.Forms.Button
    Friend WithEvents Pnl_Filter As System.Windows.Forms.Panel
    Friend WithEvents lbl_Device As System.Windows.Forms.Label
    Friend WithEvents Cmb_Device As System.Windows.Forms.ComboBox
    Friend WithEvents Btn_Device As System.Windows.Forms.Button
    Friend WithEvents lblVersion As System.Windows.Forms.Label
    Friend WithEvents BtnClose As System.Windows.Forms.Button
    Friend WithEvents BtnRecieveSetData As System.Windows.Forms.Button
    Friend WithEvents SerialPort As System.IO.Ports.SerialPort
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtCd As System.Windows.Forms.TextBox
    Friend WithEvents TxtHikiuke As System.Windows.Forms.TextBox
    Friend WithEvents LstData As System.Windows.Forms.ListBox
    Friend WithEvents BtnSendHikiuke As System.Windows.Forms.Button
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents BtnCameraAdjust As System.Windows.Forms.Button
    Friend WithEvents BtnTestLabel As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents BtnCopy As System.Windows.Forms.Button
    Friend WithEvents BtnPaste As System.Windows.Forms.Button
    Friend WithEvents BtnDelete As System.Windows.Forms.Button
    Friend WithEvents ChkPositiveDirection As System.Windows.Forms.CheckBox
    Friend WithEvents LblPositiveDirection As System.Windows.Forms.Label
    Friend WithEvents RdoTeikeiGaiNonS As System.Windows.Forms.RadioButton
End Class
