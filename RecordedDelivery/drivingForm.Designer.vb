<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DrivingForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DrivingForm))
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.SerialPort = New System.IO.Ports.SerialPort(Me.components)
        Me.lstGetDataView = New System.Windows.Forms.ListView()
        Me.RcvTextBox = New System.Windows.Forms.TextBox()
        Me.Pic_View = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblImageFileName = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblSaveLogFileName = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.LblTeikei = New System.Windows.Forms.Label()
        Me.LblSitenName = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.LblSitenCd = New System.Windows.Forms.Label()
        Me.BtnJobSelect = New System.Windows.Forms.Button()
        Me.CmbJobName = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.LblClass = New System.Windows.Forms.Label()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.LblPostName = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.LblComment = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LblName = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.LblAddress2 = New System.Windows.Forms.Label()
        Me.LblAddress1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.LblWeight = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lblAcceptNum4 = New System.Windows.Forms.Label()
        Me.lblAcceptNum3 = New System.Windows.Forms.Label()
        Me.lblAcceptNum2 = New System.Windows.Forms.Label()
        Me.lblAcceptNum1 = New System.Windows.Forms.Label()
        Me.LblPrice = New System.Windows.Forms.Label()
        Me.lblTranCount = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblOKCount = New System.Windows.Forms.Label()
        Me.DateTimeTimer = New System.Windows.Forms.Timer(Me.components)
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.BtnBack = New System.Windows.Forms.Button()
        Me.btnReceive = New System.Windows.Forms.Button()
        Me.lblYear = New System.Windows.Forms.Label()
        Me.lblCurrentTime = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.LblDebugTitle = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.TimSendCom = New System.Windows.Forms.Timer(Me.components)
        Me.Btn_Device = New System.Windows.Forms.Button()
        Me.Btn_Snap = New System.Windows.Forms.Button()
        Me.SerialWeightPort = New System.IO.Ports.SerialPort(Me.components)
        Me.BtnHandTran = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.BtnZanMinus = New System.Windows.Forms.Button()
        Me.BtnZanPlus = New System.Windows.Forms.Button()
        Me.BtnYoteiMinus = New System.Windows.Forms.Button()
        Me.BtnYoteiPlus = New System.Windows.Forms.Button()
        Me.LblZanCnt = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.LblYoteiCnt = New System.Windows.Forms.Label()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.LblSepNumber = New System.Windows.Forms.Label()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.LblTodayTotal = New System.Windows.Forms.Label()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.LblClassTotal = New System.Windows.Forms.Label()
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
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.TxtPosYFeeder = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.BtnOnePage = New System.Windows.Forms.Button()
        Me.GroupBox12 = New System.Windows.Forms.GroupBox()
        Me.Rdo8Face = New System.Windows.Forms.RadioButton()
        Me.Rdo15Face = New System.Windows.Forms.RadioButton()
        Me.LblOperatorName = New System.Windows.Forms.Label()
        Me.LstDebug = New System.Windows.Forms.ListBox()
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
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Pnl_Pin = New System.Windows.Forms.Panel()
        Me.Cmb_Pin = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Btn_Pin = New System.Windows.Forms.Button()
        Me.Pnl_Filter = New System.Windows.Forms.Panel()
        Me.lbl_Device = New System.Windows.Forms.Label()
        Me.Cmb_Device = New System.Windows.Forms.ComboBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.TimPlusMinus = New System.Windows.Forms.Timer(Me.components)
        Me.TimSnapDelay = New System.Windows.Forms.Timer(Me.components)
        Me.ChkPositiveDirection = New System.Windows.Forms.CheckBox()
        Me.LblPositiveDirection = New System.Windows.Forms.Label()
        CType(Me.Pic_View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.GroupBox10.SuspendLayout()
        Me.GroupBox12.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Pnl_Button.SuspendLayout()
        Me.Pnl_Format.SuspendLayout()
        Me.Pnl_Pin.SuspendLayout()
        Me.Pnl_Filter.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblVersion
        '
        Me.lblVersion.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblVersion.Location = New System.Drawing.Point(1471, 131)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(344, 24)
        Me.lblVersion.TabIndex = 7
        Me.lblVersion.Text = "lblVersion"
        Me.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblTitle.Font = New System.Drawing.Font("メイリオ", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(0, -1)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(1916, 57)
        Me.lblTitle.TabIndex = 9
        Me.lblTitle.Text = "　書留郵便受領証発行機　運転画面"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SerialPort
        '
        '
        'lstGetDataView
        '
        Me.lstGetDataView.BackColor = System.Drawing.SystemColors.Control
        Me.lstGetDataView.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lstGetDataView.FullRowSelect = True
        Me.lstGetDataView.GridLines = True
        Me.lstGetDataView.Location = New System.Drawing.Point(112, 720)
        Me.lstGetDataView.MultiSelect = False
        Me.lstGetDataView.Name = "lstGetDataView"
        Me.lstGetDataView.Size = New System.Drawing.Size(989, 207)
        Me.lstGetDataView.TabIndex = 14
        Me.lstGetDataView.UseCompatibleStateImageBehavior = False
        '
        'RcvTextBox
        '
        Me.RcvTextBox.AcceptsReturn = True
        Me.RcvTextBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.RcvTextBox.Font = New System.Drawing.Font("メイリオ", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.RcvTextBox.Location = New System.Drawing.Point(1123, 161)
        Me.RcvTextBox.Multiline = True
        Me.RcvTextBox.Name = "RcvTextBox"
        Me.RcvTextBox.ReadOnly = True
        Me.RcvTextBox.Size = New System.Drawing.Size(336, 75)
        Me.RcvTextBox.TabIndex = 15
        Me.RcvTextBox.Text = "RcvTextBox"
        Me.RcvTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Pic_View
        '
        Me.Pic_View.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pic_View.Location = New System.Drawing.Point(80, 90)
        Me.Pic_View.Name = "Pic_View"
        Me.Pic_View.Size = New System.Drawing.Size(495, 270)
        Me.Pic_View.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Pic_View.TabIndex = 19
        Me.Pic_View.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Black
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Location = New System.Drawing.Point(607, 91)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(495, 270)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 20
        Me.PictureBox1.TabStop = False
        '
        'lblImageFileName
        '
        Me.lblImageFileName.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblImageFileName.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblImageFileName.Location = New System.Drawing.Point(80, 374)
        Me.lblImageFileName.Name = "lblImageFileName"
        Me.lblImageFileName.Size = New System.Drawing.Size(1022, 10)
        Me.lblImageFileName.TabIndex = 21
        Me.lblImageFileName.Text = "lblImageFileName"
        Me.lblImageFileName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label2.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Yellow
        Me.Label2.Location = New System.Drawing.Point(247, 394)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(126, 25)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "保存ログファイル"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSaveLogFileName
        '
        Me.lblSaveLogFileName.BackColor = System.Drawing.Color.White
        Me.lblSaveLogFileName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSaveLogFileName.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblSaveLogFileName.ForeColor = System.Drawing.Color.Black
        Me.lblSaveLogFileName.Location = New System.Drawing.Point(374, 395)
        Me.lblSaveLogFileName.Name = "lblSaveLogFileName"
        Me.lblSaveLogFileName.Size = New System.Drawing.Size(728, 23)
        Me.lblSaveLogFileName.TabIndex = 25
        Me.lblSaveLogFileName.Text = "lblSaveLogFileName"
        Me.lblSaveLogFileName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox1.Controls.Add(Me.LblTeikei)
        Me.GroupBox1.Controls.Add(Me.LblSitenName)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.LblSitenCd)
        Me.GroupBox1.Controls.Add(Me.BtnJobSelect)
        Me.GroupBox1.Controls.Add(Me.CmbJobName)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.LblClass)
        Me.GroupBox1.Controls.Add(Me.Label46)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.LblPostName)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.LblComment)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.LblName)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.LblAddress2)
        Me.GroupBox1.Controls.Add(Me.LblAddress1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(139, 415)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(872, 302)
        Me.GroupBox1.TabIndex = 26
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "業務選択"
        '
        'LblTeikei
        '
        Me.LblTeikei.BackColor = System.Drawing.SystemColors.ControlLight
        Me.LblTeikei.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblTeikei.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblTeikei.ForeColor = System.Drawing.Color.Red
        Me.LblTeikei.Location = New System.Drawing.Point(673, 32)
        Me.LblTeikei.Name = "LblTeikei"
        Me.LblTeikei.Size = New System.Drawing.Size(193, 32)
        Me.LblTeikei.TabIndex = 51
        Me.LblTeikei.Text = "LblTeikei"
        Me.LblTeikei.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblSitenName
        '
        Me.LblSitenName.BackColor = System.Drawing.SystemColors.Control
        Me.LblSitenName.Font = New System.Drawing.Font("メイリオ", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblSitenName.Location = New System.Drawing.Point(483, 34)
        Me.LblSitenName.Name = "LblSitenName"
        Me.LblSitenName.Size = New System.Drawing.Size(284, 30)
        Me.LblSitenName.TabIndex = 50
        Me.LblSitenName.Text = "LblSitenName"
        Me.LblSitenName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label19.Font = New System.Drawing.Font("メイリオ", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label19.Location = New System.Drawing.Point(372, 33)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(105, 30)
        Me.Label19.TabIndex = 49
        Me.Label19.Text = "支 店 名"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblSitenCd
        '
        Me.LblSitenCd.BackColor = System.Drawing.SystemColors.Control
        Me.LblSitenCd.Font = New System.Drawing.Font("メイリオ", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblSitenCd.Location = New System.Drawing.Point(167, 34)
        Me.LblSitenCd.Name = "LblSitenCd"
        Me.LblSitenCd.Size = New System.Drawing.Size(158, 30)
        Me.LblSitenCd.TabIndex = 48
        Me.LblSitenCd.Text = "LblSitenCd"
        Me.LblSitenCd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtnJobSelect
        '
        Me.BtnJobSelect.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnJobSelect.Location = New System.Drawing.Point(689, 64)
        Me.BtnJobSelect.Name = "BtnJobSelect"
        Me.BtnJobSelect.Size = New System.Drawing.Size(101, 35)
        Me.BtnJobSelect.TabIndex = 47
        Me.BtnJobSelect.Text = "選択"
        Me.BtnJobSelect.UseVisualStyleBackColor = True
        Me.BtnJobSelect.Visible = False
        '
        'CmbJobName
        '
        Me.CmbJobName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbJobName.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CmbJobName.FormattingEnabled = True
        Me.CmbJobName.Location = New System.Drawing.Point(167, 66)
        Me.CmbJobName.Name = "CmbJobName"
        Me.CmbJobName.Size = New System.Drawing.Size(490, 32)
        Me.CmbJobName.TabIndex = 46
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label6.Font = New System.Drawing.Font("メイリオ", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(11, 67)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(150, 30)
        Me.Label6.TabIndex = 45
        Me.Label6.Text = "業 務 名 称"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblClass
        '
        Me.LblClass.BackColor = System.Drawing.SystemColors.Control
        Me.LblClass.Font = New System.Drawing.Font("メイリオ", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblClass.Location = New System.Drawing.Point(167, 132)
        Me.LblClass.Name = "LblClass"
        Me.LblClass.Size = New System.Drawing.Size(503, 30)
        Me.LblClass.TabIndex = 44
        Me.LblClass.Text = "LblClass"
        Me.LblClass.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label46
        '
        Me.Label46.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label46.Font = New System.Drawing.Font("メイリオ", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label46.ForeColor = System.Drawing.Color.Black
        Me.Label46.Location = New System.Drawing.Point(11, 133)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(150, 30)
        Me.Label46.TabIndex = 43
        Me.Label46.Text = "種　　　別"
        Me.Label46.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label10.Font = New System.Drawing.Font("メイリオ", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(11, 34)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(150, 30)
        Me.Label10.TabIndex = 37
        Me.Label10.Text = "支店コード"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblPostName
        '
        Me.LblPostName.BackColor = System.Drawing.SystemColors.Control
        Me.LblPostName.Font = New System.Drawing.Font("メイリオ", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblPostName.ForeColor = System.Drawing.Color.Black
        Me.LblPostName.Location = New System.Drawing.Point(167, 259)
        Me.LblPostName.Name = "LblPostName"
        Me.LblPostName.Size = New System.Drawing.Size(643, 30)
        Me.LblPostName.TabIndex = 36
        Me.LblPostName.Text = "LblPostName"
        Me.LblPostName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label7.Font = New System.Drawing.Font("メイリオ", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(11, 259)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(150, 30)
        Me.Label7.TabIndex = 35
        Me.Label7.Text = "承 認 局 名"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblComment
        '
        Me.LblComment.BackColor = System.Drawing.SystemColors.Control
        Me.LblComment.Font = New System.Drawing.Font("メイリオ", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblComment.Location = New System.Drawing.Point(167, 100)
        Me.LblComment.Name = "LblComment"
        Me.LblComment.Size = New System.Drawing.Size(643, 30)
        Me.LblComment.TabIndex = 34
        Me.LblComment.Text = "LblComment"
        Me.LblComment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("メイリオ", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(11, 100)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(150, 30)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "コ メ ン ト"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblName
        '
        Me.LblName.BackColor = System.Drawing.SystemColors.Control
        Me.LblName.Font = New System.Drawing.Font("メイリオ", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblName.ForeColor = System.Drawing.Color.Black
        Me.LblName.Location = New System.Drawing.Point(167, 228)
        Me.LblName.Name = "LblName"
        Me.LblName.Size = New System.Drawing.Size(643, 30)
        Me.LblName.TabIndex = 29
        Me.LblName.Text = "LblName"
        Me.LblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label8.Font = New System.Drawing.Font("メイリオ", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(11, 226)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(150, 30)
        Me.Label8.TabIndex = 28
        Me.Label8.Text = "差出人氏名"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblAddress2
        '
        Me.LblAddress2.BackColor = System.Drawing.SystemColors.Control
        Me.LblAddress2.Font = New System.Drawing.Font("メイリオ", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblAddress2.ForeColor = System.Drawing.Color.Black
        Me.LblAddress2.Location = New System.Drawing.Point(167, 196)
        Me.LblAddress2.Name = "LblAddress2"
        Me.LblAddress2.Size = New System.Drawing.Size(643, 30)
        Me.LblAddress2.TabIndex = 25
        Me.LblAddress2.Text = "LblAddress2"
        Me.LblAddress2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblAddress1
        '
        Me.LblAddress1.BackColor = System.Drawing.SystemColors.Control
        Me.LblAddress1.Font = New System.Drawing.Font("メイリオ", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblAddress1.ForeColor = System.Drawing.Color.Black
        Me.LblAddress1.Location = New System.Drawing.Point(167, 164)
        Me.LblAddress1.Name = "LblAddress1"
        Me.LblAddress1.Size = New System.Drawing.Size(643, 30)
        Me.LblAddress1.TabIndex = 24
        Me.LblAddress1.Text = "LblAddress1"
        Me.LblAddress1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label3.Font = New System.Drawing.Font("メイリオ", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(11, 166)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(150, 30)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "差出人住所"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox2.Controls.Add(Me.Label34)
        Me.GroupBox2.Controls.Add(Me.Label33)
        Me.GroupBox2.Controls.Add(Me.Label32)
        Me.GroupBox2.Controls.Add(Me.Label31)
        Me.GroupBox2.Controls.Add(Me.LblWeight)
        Me.GroupBox2.Controls.Add(Me.GroupBox3)
        Me.GroupBox2.Controls.Add(Me.LblPrice)
        Me.GroupBox2.Controls.Add(Me.lblTranCount)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.lblOKCount)
        Me.GroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox2.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(1475, 161)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(340, 284)
        Me.GroupBox2.TabIndex = 27
        Me.GroupBox2.TabStop = False
        '
        'Label34
        '
        Me.Label34.BackColor = System.Drawing.SystemColors.Control
        Me.Label34.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label34.ForeColor = System.Drawing.Color.Black
        Me.Label34.Location = New System.Drawing.Point(287, 222)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(41, 30)
        Me.Label34.TabIndex = 38
        Me.Label34.Text = "円"
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label33
        '
        Me.Label33.BackColor = System.Drawing.SystemColors.Control
        Me.Label33.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.Black
        Me.Label33.Location = New System.Drawing.Point(287, 181)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(41, 30)
        Me.Label33.TabIndex = 37
        Me.Label33.Text = "ｇ"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label32
        '
        Me.Label32.BackColor = System.Drawing.SystemColors.Control
        Me.Label32.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label32.ForeColor = System.Drawing.Color.Black
        Me.Label32.Location = New System.Drawing.Point(287, 142)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(41, 30)
        Me.Label32.TabIndex = 36
        Me.Label32.Text = "通"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label31
        '
        Me.Label31.BackColor = System.Drawing.SystemColors.Control
        Me.Label31.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label31.ForeColor = System.Drawing.Color.Black
        Me.Label31.Location = New System.Drawing.Point(287, 102)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(41, 30)
        Me.Label31.TabIndex = 35
        Me.Label31.Text = "通"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblWeight
        '
        Me.LblWeight.BackColor = System.Drawing.SystemColors.Control
        Me.LblWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblWeight.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblWeight.Location = New System.Drawing.Point(153, 181)
        Me.LblWeight.Name = "LblWeight"
        Me.LblWeight.Size = New System.Drawing.Size(130, 30)
        Me.LblWeight.TabIndex = 34
        Me.LblWeight.Text = "LblWeight"
        Me.LblWeight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lblAcceptNum4)
        Me.GroupBox3.Controls.Add(Me.lblAcceptNum3)
        Me.GroupBox3.Controls.Add(Me.lblAcceptNum2)
        Me.GroupBox3.Controls.Add(Me.lblAcceptNum1)
        Me.GroupBox3.Location = New System.Drawing.Point(11, 27)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(307, 64)
        Me.GroupBox3.TabIndex = 33
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "最終読取データ"
        '
        'lblAcceptNum4
        '
        Me.lblAcceptNum4.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblAcceptNum4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblAcceptNum4.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblAcceptNum4.Location = New System.Drawing.Point(242, 27)
        Me.lblAcceptNum4.Name = "lblAcceptNum4"
        Me.lblAcceptNum4.Size = New System.Drawing.Size(34, 28)
        Me.lblAcceptNum4.TabIndex = 4
        Me.lblAcceptNum4.Text = "9"
        Me.lblAcceptNum4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblAcceptNum3
        '
        Me.lblAcceptNum3.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblAcceptNum3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblAcceptNum3.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblAcceptNum3.Location = New System.Drawing.Point(146, 27)
        Me.lblAcceptNum3.Name = "lblAcceptNum3"
        Me.lblAcceptNum3.Size = New System.Drawing.Size(90, 28)
        Me.lblAcceptNum3.TabIndex = 3
        Me.lblAcceptNum3.Text = "99999"
        Me.lblAcceptNum3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblAcceptNum2
        '
        Me.lblAcceptNum2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblAcceptNum2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblAcceptNum2.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblAcceptNum2.Location = New System.Drawing.Point(89, 27)
        Me.lblAcceptNum2.Name = "lblAcceptNum2"
        Me.lblAcceptNum2.Size = New System.Drawing.Size(51, 28)
        Me.lblAcceptNum2.TabIndex = 2
        Me.lblAcceptNum2.Text = "99"
        Me.lblAcceptNum2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblAcceptNum1
        '
        Me.lblAcceptNum1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblAcceptNum1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblAcceptNum1.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblAcceptNum1.Location = New System.Drawing.Point(14, 27)
        Me.lblAcceptNum1.Name = "lblAcceptNum1"
        Me.lblAcceptNum1.Size = New System.Drawing.Size(69, 28)
        Me.lblAcceptNum1.TabIndex = 1
        Me.lblAcceptNum1.Text = "999"
        Me.lblAcceptNum1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblPrice
        '
        Me.LblPrice.BackColor = System.Drawing.SystemColors.Control
        Me.LblPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblPrice.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblPrice.Location = New System.Drawing.Point(153, 222)
        Me.LblPrice.Name = "LblPrice"
        Me.LblPrice.Size = New System.Drawing.Size(130, 30)
        Me.LblPrice.TabIndex = 31
        Me.LblPrice.Text = "LblPrice"
        Me.LblPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTranCount
        '
        Me.lblTranCount.BackColor = System.Drawing.SystemColors.Control
        Me.lblTranCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTranCount.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblTranCount.Location = New System.Drawing.Point(153, 141)
        Me.lblTranCount.Name = "lblTranCount"
        Me.lblTranCount.Size = New System.Drawing.Size(130, 30)
        Me.lblTranCount.TabIndex = 29
        Me.lblTranCount.Text = "lblTranCount"
        Me.lblTranCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Blue
        Me.Label12.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(19, 222)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(134, 30)
        Me.Label12.TabIndex = 27
        Me.Label12.Text = "料金"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Blue
        Me.Label9.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(19, 181)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(134, 30)
        Me.Label9.TabIndex = 26
        Me.Label9.Text = "重量"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Blue
        Me.Label5.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(19, 141)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(134, 30)
        Me.Label5.TabIndex = 25
        Me.Label5.Text = "投入数"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Blue
        Me.Label4.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(19, 102)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(134, 30)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "正常発行"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblOKCount
        '
        Me.lblOKCount.BackColor = System.Drawing.SystemColors.Control
        Me.lblOKCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOKCount.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblOKCount.Location = New System.Drawing.Point(153, 102)
        Me.lblOKCount.Name = "lblOKCount"
        Me.lblOKCount.Size = New System.Drawing.Size(130, 30)
        Me.lblOKCount.TabIndex = 0
        Me.lblOKCount.Text = "lblOKCount"
        Me.lblOKCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DateTimeTimer
        '
        '
        'PrintDocument1
        '
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'PrintPreviewDialog1
        '
        Me.PrintPreviewDialog1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog1.Enabled = True
        Me.PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog1.Visible = False
        '
        'BtnBack
        '
        Me.BtnBack.Location = New System.Drawing.Point(1516, 934)
        Me.BtnBack.Name = "BtnBack"
        Me.BtnBack.Size = New System.Drawing.Size(300, 100)
        Me.BtnBack.TabIndex = 29
        Me.BtnBack.Text = "戻る"
        Me.BtnBack.UseVisualStyleBackColor = True
        '
        'btnReceive
        '
        Me.btnReceive.Location = New System.Drawing.Point(1187, 934)
        Me.btnReceive.Name = "btnReceive"
        Me.btnReceive.Size = New System.Drawing.Size(300, 100)
        Me.btnReceive.TabIndex = 30
        Me.btnReceive.Text = "受領証印刷"
        Me.btnReceive.UseVisualStyleBackColor = True
        '
        'lblYear
        '
        Me.lblYear.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblYear.Location = New System.Drawing.Point(1417, 88)
        Me.lblYear.Name = "lblYear"
        Me.lblYear.Size = New System.Drawing.Size(223, 35)
        Me.lblYear.TabIndex = 31
        Me.lblYear.Text = "lblYear"
        Me.lblYear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCurrentTime
        '
        Me.lblCurrentTime.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblCurrentTime.Location = New System.Drawing.Point(1646, 88)
        Me.lblCurrentTime.Name = "lblCurrentTime"
        Me.lblCurrentTime.Size = New System.Drawing.Size(166, 35)
        Me.lblCurrentTime.TabIndex = 32
        Me.lblCurrentTime.Text = "lblCurrentTime"
        Me.lblCurrentTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label14.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label14.Location = New System.Drawing.Point(80, 65)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(109, 24)
        Me.Label14.TabIndex = 34
        Me.Label14.Text = "ライブ画像"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label15.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label15.Location = New System.Drawing.Point(607, 66)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(109, 24)
        Me.Label15.TabIndex = 35
        Me.Label15.Text = "静止画像"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblDebugTitle
        '
        Me.LblDebugTitle.AutoSize = True
        Me.LblDebugTitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblDebugTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblDebugTitle.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblDebugTitle.Location = New System.Drawing.Point(1264, 786)
        Me.LblDebugTitle.Name = "LblDebugTitle"
        Me.LblDebugTitle.Size = New System.Drawing.Size(128, 22)
        Me.LblDebugTitle.TabIndex = 40
        Me.LblDebugTitle.Text = "デバッグウィンドウ"
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label17.Font = New System.Drawing.Font("メイリオ", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label17.Location = New System.Drawing.Point(79, 720)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(33, 207)
        Me.Label17.TabIndex = 42
        Me.Label17.Text = "処理デ｜タ"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Timer1
        '
        '
        'TimSendCom
        '
        '
        'Btn_Device
        '
        Me.Btn_Device.Font = New System.Drawing.Font("メイリオ", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Btn_Device.Location = New System.Drawing.Point(1107, 876)
        Me.Btn_Device.Name = "Btn_Device"
        Me.Btn_Device.Size = New System.Drawing.Size(151, 51)
        Me.Btn_Device.TabIndex = 46
        Me.Btn_Device.Text = "カメラ設定"
        Me.Btn_Device.UseVisualStyleBackColor = True
        Me.Btn_Device.Visible = False
        '
        'Btn_Snap
        '
        Me.Btn_Snap.Font = New System.Drawing.Font("メイリオ", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Btn_Snap.Location = New System.Drawing.Point(1107, 785)
        Me.Btn_Snap.Name = "Btn_Snap"
        Me.Btn_Snap.Size = New System.Drawing.Size(151, 87)
        Me.Btn_Snap.TabIndex = 47
        Me.Btn_Snap.Text = "スナップ"
        Me.Btn_Snap.UseVisualStyleBackColor = True
        Me.Btn_Snap.Visible = False
        '
        'SerialWeightPort
        '
        '
        'BtnHandTran
        '
        Me.BtnHandTran.Location = New System.Drawing.Point(861, 934)
        Me.BtnHandTran.Name = "BtnHandTran"
        Me.BtnHandTran.Size = New System.Drawing.Size(300, 100)
        Me.BtnHandTran.TabIndex = 49
        Me.BtnHandTran.Text = "手差処理"
        Me.BtnHandTran.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox5.Controls.Add(Me.GroupBox4)
        Me.GroupBox5.Controls.Add(Me.Label26)
        Me.GroupBox5.Controls.Add(Me.Label25)
        Me.GroupBox5.Controls.Add(Me.BtnZanMinus)
        Me.GroupBox5.Controls.Add(Me.BtnZanPlus)
        Me.GroupBox5.Controls.Add(Me.BtnYoteiMinus)
        Me.GroupBox5.Controls.Add(Me.BtnYoteiPlus)
        Me.GroupBox5.Controls.Add(Me.LblZanCnt)
        Me.GroupBox5.Controls.Add(Me.Label28)
        Me.GroupBox5.Controls.Add(Me.Label29)
        Me.GroupBox5.Controls.Add(Me.LblYoteiCnt)
        Me.GroupBox5.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox5.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(1475, 448)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(377, 137)
        Me.GroupBox5.TabIndex = 50
        Me.GroupBox5.TabStop = False
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox4.Controls.Add(Me.Label23)
        Me.GroupBox4.Controls.Add(Me.Label27)
        Me.GroupBox4.Controls.Add(Me.Label35)
        Me.GroupBox4.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox4.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(2, 132)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(340, 73)
        Me.GroupBox4.TabIndex = 53
        Me.GroupBox4.TabStop = False
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.SystemColors.Control
        Me.Label23.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.Black
        Me.Label23.Location = New System.Drawing.Point(292, 27)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(41, 30)
        Me.Label23.TabIndex = 25
        Me.Label23.Text = "通"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label27
        '
        Me.Label27.BackColor = System.Drawing.Color.Blue
        Me.Label27.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.White
        Me.Label27.Location = New System.Drawing.Point(19, 27)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(134, 30)
        Me.Label27.TabIndex = 24
        Me.Label27.Text = "予定処理数"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label35
        '
        Me.Label35.BackColor = System.Drawing.Color.White
        Me.Label35.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label35.Location = New System.Drawing.Point(155, 28)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(134, 28)
        Me.Label35.TabIndex = 0
        Me.Label35.Text = "Label35"
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label26
        '
        Me.Label26.BackColor = System.Drawing.SystemColors.Control
        Me.Label26.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.Black
        Me.Label26.Location = New System.Drawing.Point(288, 90)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(41, 30)
        Me.Label26.TabIndex = 35
        Me.Label26.Text = "通"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label25
        '
        Me.Label25.BackColor = System.Drawing.SystemColors.Control
        Me.Label25.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.Black
        Me.Label25.Location = New System.Drawing.Point(287, 33)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(41, 30)
        Me.Label25.TabIndex = 34
        Me.Label25.Text = "通"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnZanMinus
        '
        Me.BtnZanMinus.Location = New System.Drawing.Point(334, 103)
        Me.BtnZanMinus.Name = "BtnZanMinus"
        Me.BtnZanMinus.Size = New System.Drawing.Size(35, 27)
        Me.BtnZanMinus.TabIndex = 33
        Me.BtnZanMinus.Text = "ー"
        Me.BtnZanMinus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnZanMinus.UseVisualStyleBackColor = True
        '
        'BtnZanPlus
        '
        Me.BtnZanPlus.Location = New System.Drawing.Point(334, 76)
        Me.BtnZanPlus.Name = "BtnZanPlus"
        Me.BtnZanPlus.Size = New System.Drawing.Size(35, 27)
        Me.BtnZanPlus.TabIndex = 32
        Me.BtnZanPlus.Text = "＋"
        Me.BtnZanPlus.UseVisualStyleBackColor = True
        '
        'BtnYoteiMinus
        '
        Me.BtnYoteiMinus.Location = New System.Drawing.Point(334, 47)
        Me.BtnYoteiMinus.Name = "BtnYoteiMinus"
        Me.BtnYoteiMinus.Size = New System.Drawing.Size(35, 27)
        Me.BtnYoteiMinus.TabIndex = 31
        Me.BtnYoteiMinus.Text = "ー"
        Me.BtnYoteiMinus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnYoteiMinus.UseVisualStyleBackColor = True
        '
        'BtnYoteiPlus
        '
        Me.BtnYoteiPlus.Location = New System.Drawing.Point(334, 20)
        Me.BtnYoteiPlus.Name = "BtnYoteiPlus"
        Me.BtnYoteiPlus.Size = New System.Drawing.Size(35, 27)
        Me.BtnYoteiPlus.TabIndex = 30
        Me.BtnYoteiPlus.Text = "＋"
        Me.BtnYoteiPlus.UseVisualStyleBackColor = True
        '
        'LblZanCnt
        '
        Me.LblZanCnt.BackColor = System.Drawing.Color.White
        Me.LblZanCnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblZanCnt.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblZanCnt.Location = New System.Drawing.Point(168, 89)
        Me.LblZanCnt.Name = "LblZanCnt"
        Me.LblZanCnt.Size = New System.Drawing.Size(113, 30)
        Me.LblZanCnt.TabIndex = 29
        Me.LblZanCnt.Text = "LblZanCnt"
        Me.LblZanCnt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label28
        '
        Me.Label28.BackColor = System.Drawing.Color.Blue
        Me.Label28.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.White
        Me.Label28.Location = New System.Drawing.Point(19, 89)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(149, 30)
        Me.Label28.TabIndex = 25
        Me.Label28.Text = "残カウント"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label29
        '
        Me.Label29.BackColor = System.Drawing.Color.Blue
        Me.Label29.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.White
        Me.Label29.Location = New System.Drawing.Point(19, 33)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(149, 30)
        Me.Label29.TabIndex = 24
        Me.Label29.Text = "予定処理数"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblYoteiCnt
        '
        Me.LblYoteiCnt.BackColor = System.Drawing.Color.White
        Me.LblYoteiCnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblYoteiCnt.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblYoteiCnt.Location = New System.Drawing.Point(168, 33)
        Me.LblYoteiCnt.Name = "LblYoteiCnt"
        Me.LblYoteiCnt.Size = New System.Drawing.Size(113, 30)
        Me.LblYoteiCnt.TabIndex = 0
        Me.LblYoteiCnt.Text = "LblYoteiCnt"
        Me.LblYoteiCnt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox7
        '
        Me.GroupBox7.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox7.Controls.Add(Me.Label18)
        Me.GroupBox7.Controls.Add(Me.Label22)
        Me.GroupBox7.Controls.Add(Me.LblSepNumber)
        Me.GroupBox7.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox7.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox7.Location = New System.Drawing.Point(1475, 743)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(344, 73)
        Me.GroupBox7.TabIndex = 52
        Me.GroupBox7.TabStop = False
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.SystemColors.Control
        Me.Label18.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(292, 27)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(41, 30)
        Me.Label18.TabIndex = 25
        Me.Label18.Text = "通"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.Blue
        Me.Label22.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.White
        Me.Label22.Location = New System.Drawing.Point(19, 27)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(149, 30)
        Me.Label22.TabIndex = 24
        Me.Label22.Text = "区分通数"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblSepNumber
        '
        Me.LblSepNumber.BackColor = System.Drawing.SystemColors.Control
        Me.LblSepNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblSepNumber.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblSepNumber.Location = New System.Drawing.Point(168, 27)
        Me.LblSepNumber.Name = "LblSepNumber"
        Me.LblSepNumber.Size = New System.Drawing.Size(113, 30)
        Me.LblSepNumber.TabIndex = 0
        Me.LblSepNumber.Text = "LblSepNumber"
        Me.LblSepNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox8
        '
        Me.GroupBox8.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox8.Controls.Add(Me.Label36)
        Me.GroupBox8.Controls.Add(Me.Label37)
        Me.GroupBox8.Controls.Add(Me.LblTodayTotal)
        Me.GroupBox8.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox8.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox8.Location = New System.Drawing.Point(1475, 589)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(340, 73)
        Me.GroupBox8.TabIndex = 53
        Me.GroupBox8.TabStop = False
        '
        'Label36
        '
        Me.Label36.BackColor = System.Drawing.SystemColors.Control
        Me.Label36.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label36.ForeColor = System.Drawing.Color.Black
        Me.Label36.Location = New System.Drawing.Point(290, 27)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(41, 30)
        Me.Label36.TabIndex = 25
        Me.Label36.Text = "通"
        Me.Label36.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label37
        '
        Me.Label37.BackColor = System.Drawing.Color.Blue
        Me.Label37.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label37.ForeColor = System.Drawing.Color.White
        Me.Label37.Location = New System.Drawing.Point(19, 27)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(149, 30)
        Me.Label37.TabIndex = 24
        Me.Label37.Text = "当日累計"
        Me.Label37.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblTodayTotal
        '
        Me.LblTodayTotal.BackColor = System.Drawing.SystemColors.Control
        Me.LblTodayTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblTodayTotal.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblTodayTotal.Location = New System.Drawing.Point(168, 27)
        Me.LblTodayTotal.Name = "LblTodayTotal"
        Me.LblTodayTotal.Size = New System.Drawing.Size(113, 30)
        Me.LblTodayTotal.TabIndex = 0
        Me.LblTodayTotal.Text = "LblTodayTotal"
        Me.LblTodayTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox9
        '
        Me.GroupBox9.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox9.Controls.Add(Me.Label39)
        Me.GroupBox9.Controls.Add(Me.Label40)
        Me.GroupBox9.Controls.Add(Me.LblClassTotal)
        Me.GroupBox9.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox9.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox9.Location = New System.Drawing.Point(1475, 663)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(340, 73)
        Me.GroupBox9.TabIndex = 54
        Me.GroupBox9.TabStop = False
        '
        'Label39
        '
        Me.Label39.BackColor = System.Drawing.SystemColors.Control
        Me.Label39.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label39.ForeColor = System.Drawing.Color.Black
        Me.Label39.Location = New System.Drawing.Point(292, 27)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(41, 30)
        Me.Label39.TabIndex = 25
        Me.Label39.Text = "通"
        Me.Label39.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label40
        '
        Me.Label40.BackColor = System.Drawing.Color.Blue
        Me.Label40.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label40.ForeColor = System.Drawing.Color.White
        Me.Label40.Location = New System.Drawing.Point(19, 27)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(149, 30)
        Me.Label40.TabIndex = 24
        Me.Label40.Text = "種別累計"
        Me.Label40.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblClassTotal
        '
        Me.LblClassTotal.BackColor = System.Drawing.SystemColors.Control
        Me.LblClassTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblClassTotal.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblClassTotal.Location = New System.Drawing.Point(168, 27)
        Me.LblClassTotal.Name = "LblClassTotal"
        Me.LblClassTotal.Size = New System.Drawing.Size(113, 30)
        Me.LblClassTotal.TabIndex = 0
        Me.LblClassTotal.Text = "LblClassTotal"
        Me.LblClassTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.GroupBox10.Controls.Add(Me.Label30)
        Me.GroupBox10.Controls.Add(Me.Label21)
        Me.GroupBox10.Controls.Add(Me.TxtPosYFeeder)
        Me.GroupBox10.Controls.Add(Me.Label24)
        Me.GroupBox10.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox10.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox10.Location = New System.Drawing.Point(1156, 247)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(304, 403)
        Me.GroupBox10.TabIndex = 56
        Me.GroupBox10.TabStop = False
        '
        'BtnRecieveSetData
        '
        Me.BtnRecieveSetData.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnRecieveSetData.Location = New System.Drawing.Point(168, 337)
        Me.BtnRecieveSetData.Name = "BtnRecieveSetData"
        Me.BtnRecieveSetData.Size = New System.Drawing.Size(121, 52)
        Me.BtnRecieveSetData.TabIndex = 48
        Me.BtnRecieveSetData.Text = "設定要求"
        Me.BtnRecieveSetData.UseVisualStyleBackColor = True
        '
        'BtnSendSetData
        '
        Me.BtnSendSetData.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnSendSetData.Location = New System.Drawing.Point(24, 338)
        Me.BtnSendSetData.Name = "BtnSendSetData"
        Me.BtnSendSetData.Size = New System.Drawing.Size(121, 52)
        Me.BtnSendSetData.TabIndex = 47
        Me.BtnSendSetData.Text = "設定送信"
        Me.BtnSendSetData.UseVisualStyleBackColor = True
        '
        'TxtPosXCapture
        '
        Me.TxtPosXCapture.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TxtPosXCapture.Location = New System.Drawing.Point(228, 292)
        Me.TxtPosXCapture.Name = "TxtPosXCapture"
        Me.TxtPosXCapture.Size = New System.Drawing.Size(65, 31)
        Me.TxtPosXCapture.TabIndex = 36
        Me.TxtPosXCapture.Text = "10"
        Me.TxtPosXCapture.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label42
        '
        Me.Label42.BackColor = System.Drawing.Color.Blue
        Me.Label42.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label42.ForeColor = System.Drawing.Color.White
        Me.Label42.Location = New System.Drawing.Point(25, 293)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(203, 30)
        Me.Label42.TabIndex = 35
        Me.Label42.Text = "横方向（画角中央）"
        Me.Label42.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtPosYCapture
        '
        Me.TxtPosYCapture.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TxtPosYCapture.Location = New System.Drawing.Point(228, 255)
        Me.TxtPosYCapture.Name = "TxtPosYCapture"
        Me.TxtPosYCapture.Size = New System.Drawing.Size(65, 31)
        Me.TxtPosYCapture.TabIndex = 34
        Me.TxtPosYCapture.Text = "10"
        Me.TxtPosYCapture.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label43
        '
        Me.Label43.BackColor = System.Drawing.Color.Blue
        Me.Label43.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label43.ForeColor = System.Drawing.Color.White
        Me.Label43.Location = New System.Drawing.Point(25, 256)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(203, 30)
        Me.Label43.TabIndex = 33
        Me.Label43.Text = "送方向（画角中央）"
        Me.Label43.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label44
        '
        Me.Label44.BackColor = System.Drawing.SystemColors.Control
        Me.Label44.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
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
        Me.TxtPosXLabel.Location = New System.Drawing.Point(228, 171)
        Me.TxtPosXLabel.Name = "TxtPosXLabel"
        Me.TxtPosXLabel.Size = New System.Drawing.Size(63, 31)
        Me.TxtPosXLabel.TabIndex = 31
        Me.TxtPosXLabel.Text = "10"
        Me.TxtPosXLabel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label41
        '
        Me.Label41.BackColor = System.Drawing.Color.Blue
        Me.Label41.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label41.ForeColor = System.Drawing.Color.White
        Me.Label41.Location = New System.Drawing.Point(25, 172)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(203, 30)
        Me.Label41.TabIndex = 30
        Me.Label41.Text = "横方向（左辺）"
        Me.Label41.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtPosYLabel
        '
        Me.TxtPosYLabel.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TxtPosYLabel.Location = New System.Drawing.Point(228, 134)
        Me.TxtPosYLabel.Name = "TxtPosYLabel"
        Me.TxtPosYLabel.Size = New System.Drawing.Size(63, 31)
        Me.TxtPosYLabel.TabIndex = 29
        Me.TxtPosYLabel.Text = "10"
        Me.TxtPosYLabel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label38
        '
        Me.Label38.BackColor = System.Drawing.Color.Blue
        Me.Label38.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label38.ForeColor = System.Drawing.Color.White
        Me.Label38.Location = New System.Drawing.Point(25, 135)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(203, 30)
        Me.Label38.TabIndex = 28
        Me.Label38.Text = "送方向（上辺）"
        Me.Label38.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label30
        '
        Me.Label30.BackColor = System.Drawing.SystemColors.Control
        Me.Label30.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.Black
        Me.Label30.Location = New System.Drawing.Point(22, 103)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(252, 30)
        Me.Label30.TabIndex = 27
        Me.Label30.Text = "ラベル貼付位置"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.SystemColors.Control
        Me.Label21.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
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
        Me.TxtPosYFeeder.Location = New System.Drawing.Point(228, 56)
        Me.TxtPosYFeeder.Name = "TxtPosYFeeder"
        Me.TxtPosYFeeder.Size = New System.Drawing.Size(63, 31)
        Me.TxtPosYFeeder.TabIndex = 25
        Me.TxtPosYFeeder.Text = "10"
        Me.TxtPosYFeeder.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.Blue
        Me.Label24.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.White
        Me.Label24.Location = New System.Drawing.Point(25, 57)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(203, 30)
        Me.Label24.TabIndex = 24
        Me.Label24.Text = "封筒幅"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnOnePage
        '
        Me.BtnOnePage.Location = New System.Drawing.Point(543, 934)
        Me.BtnOnePage.Name = "BtnOnePage"
        Me.BtnOnePage.Size = New System.Drawing.Size(300, 100)
        Me.BtnOnePage.TabIndex = 57
        Me.BtnOnePage.Text = "一通処理"
        Me.BtnOnePage.UseVisualStyleBackColor = True
        '
        'GroupBox12
        '
        Me.GroupBox12.Controls.Add(Me.Rdo8Face)
        Me.GroupBox12.Controls.Add(Me.Rdo15Face)
        Me.GroupBox12.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox12.Location = New System.Drawing.Point(1156, 662)
        Me.GroupBox12.Name = "GroupBox12"
        Me.GroupBox12.Size = New System.Drawing.Size(304, 81)
        Me.GroupBox12.TabIndex = 140
        Me.GroupBox12.TabStop = False
        Me.GroupBox12.Text = "受領証面数設定"
        '
        'Rdo8Face
        '
        Me.Rdo8Face.Location = New System.Drawing.Point(168, 34)
        Me.Rdo8Face.Name = "Rdo8Face"
        Me.Rdo8Face.Size = New System.Drawing.Size(74, 28)
        Me.Rdo8Face.TabIndex = 1
        Me.Rdo8Face.Text = "8面"
        Me.Rdo8Face.UseVisualStyleBackColor = True
        '
        'Rdo15Face
        '
        Me.Rdo15Face.Checked = True
        Me.Rdo15Face.Location = New System.Drawing.Point(50, 34)
        Me.Rdo15Face.Name = "Rdo15Face"
        Me.Rdo15Face.Size = New System.Drawing.Size(79, 28)
        Me.Rdo15Face.TabIndex = 0
        Me.Rdo15Face.TabStop = True
        Me.Rdo15Face.Text = "15面"
        Me.Rdo15Face.UseVisualStyleBackColor = True
        '
        'LblOperatorName
        '
        Me.LblOperatorName.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblOperatorName.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblOperatorName.ForeColor = System.Drawing.Color.White
        Me.LblOperatorName.Location = New System.Drawing.Point(1657, 11)
        Me.LblOperatorName.Name = "LblOperatorName"
        Me.LblOperatorName.Size = New System.Drawing.Size(224, 33)
        Me.LblOperatorName.TabIndex = 141
        Me.LblOperatorName.Text = "LblOperatorName"
        Me.LblOperatorName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LstDebug
        '
        Me.LstDebug.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LstDebug.Font = New System.Drawing.Font("メイリオ", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LstDebug.FormattingEnabled = True
        Me.LstDebug.ItemHeight = 23
        Me.LstDebug.Location = New System.Drawing.Point(1264, 808)
        Me.LstDebug.Name = "LstDebug"
        Me.LstDebug.Size = New System.Drawing.Size(638, 119)
        Me.LstDebug.TabIndex = 142
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Pnl_Button)
        Me.Panel1.Controls.Add(Me.Pnl_Format)
        Me.Panel1.Controls.Add(Me.Pnl_Pin)
        Me.Panel1.Controls.Add(Me.Pnl_Filter)
        Me.Panel1.Location = New System.Drawing.Point(70, 709)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(445, 340)
        Me.Panel1.TabIndex = 163
        '
        'Pnl_Button
        '
        Me.Pnl_Button.Controls.Add(Me.Btn_Cancel)
        Me.Pnl_Button.Controls.Add(Me.Btn_PinFormat)
        Me.Pnl_Button.Controls.Add(Me.Btn_OK)
        Me.Pnl_Button.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pnl_Button.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Pnl_Button.Location = New System.Drawing.Point(0, 287)
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
        Me.Pnl_Format.Controls.Add(Me.Label11)
        Me.Pnl_Format.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pnl_Format.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Pnl_Format.Location = New System.Drawing.Point(0, 96)
        Me.Pnl_Format.Name = "Pnl_Format"
        Me.Pnl_Format.Size = New System.Drawing.Size(445, 191)
        Me.Pnl_Format.TabIndex = 22
        '
        'BtnClose
        '
        Me.BtnClose.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnClose.Location = New System.Drawing.Point(186, 155)
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
        Me.Btn_Format.Location = New System.Drawing.Point(312, 155)
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
        Me.Lst_Format.Location = New System.Drawing.Point(16, 28)
        Me.Lst_Format.Name = "Lst_Format"
        Me.Lst_Format.Size = New System.Drawing.Size(413, 124)
        Me.Lst_Format.TabIndex = 16
        Me.Lst_Format.Tag = "3"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(8, 8)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(113, 20)
        Me.Label11.TabIndex = 10
        Me.Label11.Text = "出力フォーマット"
        '
        'Pnl_Pin
        '
        Me.Pnl_Pin.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Pnl_Pin.Controls.Add(Me.Cmb_Pin)
        Me.Pnl_Pin.Controls.Add(Me.Label13)
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
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(8, 8)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(61, 20)
        Me.Label13.TabIndex = 10
        Me.Label13.Text = "出力ピン"
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
        '
        'Pnl_Filter
        '
        Me.Pnl_Filter.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Pnl_Filter.Controls.Add(Me.lbl_Device)
        Me.Pnl_Filter.Controls.Add(Me.Cmb_Device)
        Me.Pnl_Filter.Controls.Add(Me.Button2)
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
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(324, 9)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(105, 33)
        Me.Button2.TabIndex = 8
        Me.Button2.Tag = "2"
        Me.Button2.Text = "プロパティ"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'TimPlusMinus
        '
        Me.TimPlusMinus.Interval = 500
        '
        'TimSnapDelay
        '
        '
        'ChkPositiveDirection
        '
        Me.ChkPositiveDirection.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ChkPositiveDirection.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ChkPositiveDirection.Location = New System.Drawing.Point(1018, 447)
        Me.ChkPositiveDirection.Name = "ChkPositiveDirection"
        Me.ChkPositiveDirection.Size = New System.Drawing.Size(130, 31)
        Me.ChkPositiveDirection.TabIndex = 171
        Me.ChkPositiveDirection.Text = "正方向流し"
        Me.ChkPositiveDirection.UseVisualStyleBackColor = False
        '
        'LblPositiveDirection
        '
        Me.LblPositiveDirection.BackColor = System.Drawing.SystemColors.Control
        Me.LblPositiveDirection.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblPositiveDirection.ForeColor = System.Drawing.Color.Red
        Me.LblPositiveDirection.Location = New System.Drawing.Point(739, 65)
        Me.LblPositiveDirection.Name = "LblPositiveDirection"
        Me.LblPositiveDirection.Size = New System.Drawing.Size(215, 24)
        Me.LblPositiveDirection.TabIndex = 172
        Me.LblPositiveDirection.Text = "画像表示反転"
        Me.LblPositiveDirection.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DrivingForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(16.0!, 41.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1914, 1052)
        Me.Controls.Add(Me.LblPositiveDirection)
        Me.Controls.Add(Me.ChkPositiveDirection)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.LblDebugTitle)
        Me.Controls.Add(Me.LstDebug)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LblOperatorName)
        Me.Controls.Add(Me.GroupBox12)
        Me.Controls.Add(Me.BtnOnePage)
        Me.Controls.Add(Me.lblSaveLogFileName)
        Me.Controls.Add(Me.GroupBox10)
        Me.Controls.Add(Me.GroupBox9)
        Me.Controls.Add(Me.GroupBox8)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.BtnHandTran)
        Me.Controls.Add(Me.Pic_View)
        Me.Controls.Add(Me.Btn_Device)
        Me.Controls.Add(Me.Btn_Snap)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.RcvTextBox)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblImageFileName)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lblCurrentTime)
        Me.Controls.Add(Me.lblYear)
        Me.Controls.Add(Me.btnReceive)
        Me.Controls.Add(Me.BtnBack)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.lstGetDataView)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.lblVersion)
        Me.Font = New System.Drawing.Font("メイリオ", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(8, 10, 8, 10)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DrivingForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "運転画面"
        CType(Me.Pic_View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox10.ResumeLayout(False)
        Me.GroupBox10.PerformLayout()
        Me.GroupBox12.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Pnl_Button.ResumeLayout(False)
        Me.Pnl_Format.ResumeLayout(False)
        Me.Pnl_Format.PerformLayout()
        Me.Pnl_Pin.ResumeLayout(False)
        Me.Pnl_Pin.PerformLayout()
        Me.Pnl_Filter.ResumeLayout(False)
        Me.Pnl_Filter.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblVersion As System.Windows.Forms.Label
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents SerialPort As System.IO.Ports.SerialPort
    Friend WithEvents lstGetDataView As System.Windows.Forms.ListView
    Friend WithEvents RcvTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Pic_View As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lblImageFileName As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblSaveLogFileName As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents LblName As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents LblAddress2 As System.Windows.Forms.Label
    Friend WithEvents LblAddress1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lblOKCount As System.Windows.Forms.Label
    Friend WithEvents DateTimeTimer As System.Windows.Forms.Timer
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents BtnBack As System.Windows.Forms.Button
    Friend WithEvents btnReceive As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents LblPostName As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents LblComment As System.Windows.Forms.Label
    Friend WithEvents lblYear As System.Windows.Forms.Label
    Friend WithEvents lblCurrentTime As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents lblAcceptNum4 As System.Windows.Forms.Label
    Friend WithEvents lblAcceptNum3 As System.Windows.Forms.Label
    Friend WithEvents lblAcceptNum2 As System.Windows.Forms.Label
    Friend WithEvents lblAcceptNum1 As System.Windows.Forms.Label
    Friend WithEvents LblPrice As System.Windows.Forms.Label
    Friend WithEvents lblTranCount As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents LblDebugTitle As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents TimSendCom As System.Windows.Forms.Timer
    Friend WithEvents Btn_Device As System.Windows.Forms.Button
    Friend WithEvents Btn_Snap As System.Windows.Forms.Button
    Friend WithEvents SerialWeightPort As System.IO.Ports.SerialPort
    Friend WithEvents BtnHandTran As System.Windows.Forms.Button
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents LblWeight As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents BtnZanMinus As System.Windows.Forms.Button
    Friend WithEvents BtnZanPlus As System.Windows.Forms.Button
    Friend WithEvents BtnYoteiMinus As System.Windows.Forms.Button
    Friend WithEvents BtnYoteiPlus As System.Windows.Forms.Button
    Friend WithEvents LblZanCnt As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents LblYoteiCnt As System.Windows.Forms.Label
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents LblSepNumber As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents LblTodayTotal As System.Windows.Forms.Label
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents LblClassTotal As System.Windows.Forms.Label
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
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents TxtPosYFeeder As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents BtnOnePage As System.Windows.Forms.Button
    Friend WithEvents CmbJobName As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents LblClass As System.Windows.Forms.Label
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents BtnJobSelect As System.Windows.Forms.Button
    Friend WithEvents LblSitenName As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents LblSitenCd As System.Windows.Forms.Label
    Friend WithEvents GroupBox12 As System.Windows.Forms.GroupBox
    Friend WithEvents Rdo8Face As System.Windows.Forms.RadioButton
    Friend WithEvents Rdo15Face As System.Windows.Forms.RadioButton
    Friend WithEvents LblOperatorName As System.Windows.Forms.Label
    Friend WithEvents LstDebug As System.Windows.Forms.ListBox
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
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Pnl_Pin As System.Windows.Forms.Panel
    Friend WithEvents Cmb_Pin As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Btn_Pin As System.Windows.Forms.Button
    Friend WithEvents Pnl_Filter As System.Windows.Forms.Panel
    Friend WithEvents lbl_Device As System.Windows.Forms.Label
    Friend WithEvents Cmb_Device As System.Windows.Forms.ComboBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents BtnClose As System.Windows.Forms.Button
    Friend WithEvents TimPlusMinus As System.Windows.Forms.Timer
    Friend WithEvents BtnRecieveSetData As System.Windows.Forms.Button
    Friend WithEvents TimSnapDelay As System.Windows.Forms.Timer
    Friend WithEvents LblTeikei As System.Windows.Forms.Label
    Friend WithEvents ChkPositiveDirection As System.Windows.Forms.CheckBox
    Friend WithEvents LblPositiveDirection As System.Windows.Forms.Label
End Class
