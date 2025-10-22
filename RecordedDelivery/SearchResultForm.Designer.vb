<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SearchResultForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SearchResultForm))
        Me.LblOperatorName = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblSaveLogFileName = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.LblTranDate = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.LblJobName = New System.Windows.Forms.Label()
        Me.LblSitenName = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.LblSitenCd = New System.Windows.Forms.Label()
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
        Me.lstGetDataView = New System.Windows.Forms.ListView()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.GroupBox12 = New System.Windows.Forms.GroupBox()
        Me.Rdo8FacePerPage = New System.Windows.Forms.RadioButton()
        Me.Rdo15FacePerPage = New System.Windows.Forms.RadioButton()
        Me.BtnBack = New System.Windows.Forms.Button()
        Me.BtnEnd = New System.Windows.Forms.Button()
        Me.DateTimeTimer = New System.Windows.Forms.Timer(Me.components)
        Me.lblCurrentTime = New System.Windows.Forms.Label()
        Me.lblYear = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblAcceptNum4 = New System.Windows.Forms.Label()
        Me.lblAcceptNum3 = New System.Windows.Forms.Label()
        Me.lblAcceptNum2 = New System.Windows.Forms.Label()
        Me.lblAcceptNum1 = New System.Windows.Forms.Label()
        Me.LblCreateDate = New System.Windows.Forms.Label()
        Me.BtnRePrint = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox12.SuspendLayout()
        Me.SuspendLayout()
        '
        'LblOperatorName
        '
        Me.LblOperatorName.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblOperatorName.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblOperatorName.ForeColor = System.Drawing.Color.White
        Me.LblOperatorName.Location = New System.Drawing.Point(1656, 13)
        Me.LblOperatorName.Name = "LblOperatorName"
        Me.LblOperatorName.Size = New System.Drawing.Size(224, 33)
        Me.LblOperatorName.TabIndex = 144
        Me.LblOperatorName.Text = "LblOperatorName"
        Me.LblOperatorName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Black
        Me.PictureBox1.ErrorImage = CType(resources.GetObject("PictureBox1.ErrorImage"), System.Drawing.Image)
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.InitialImage = CType(resources.GetObject("PictureBox1.InitialImage"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(101, 425)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(495, 270)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 143
        Me.PictureBox1.TabStop = False
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblTitle.Font = New System.Drawing.Font("メイリオ", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(-1, 1)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(1916, 57)
        Me.lblTitle.TabIndex = 142
        Me.lblTitle.Text = "　検索画面（データ確認・抜取り）"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSaveLogFileName
        '
        Me.lblSaveLogFileName.BackColor = System.Drawing.Color.White
        Me.lblSaveLogFileName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSaveLogFileName.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblSaveLogFileName.ForeColor = System.Drawing.Color.Black
        Me.lblSaveLogFileName.Location = New System.Drawing.Point(1089, 149)
        Me.lblSaveLogFileName.Name = "lblSaveLogFileName"
        Me.lblSaveLogFileName.Size = New System.Drawing.Size(675, 30)
        Me.lblSaveLogFileName.TabIndex = 147
        Me.lblSaveLogFileName.Text = "lblSaveLogFileName"
        Me.lblSaveLogFileName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label17.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label17.Location = New System.Drawing.Point(749, 228)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(33, 645)
        Me.Label17.TabIndex = 149
        Me.Label17.Text = "検索範囲デ｜タ"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label2.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Yellow
        Me.Label2.Location = New System.Drawing.Point(939, 149)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(150, 30)
        Me.Label2.TabIndex = 146
        Me.Label2.Text = "保存ログファイル"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox1.Controls.Add(Me.LblTranDate)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.LblJobName)
        Me.GroupBox1.Controls.Add(Me.LblSitenName)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.LblSitenCd)
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
        Me.GroupBox1.Location = New System.Drawing.Point(86, 84)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(836, 297)
        Me.GroupBox1.TabIndex = 148
        Me.GroupBox1.TabStop = False
        '
        'LblTranDate
        '
        Me.LblTranDate.BackColor = System.Drawing.SystemColors.Control
        Me.LblTranDate.Font = New System.Drawing.Font("メイリオ", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblTranDate.Location = New System.Drawing.Point(163, 32)
        Me.LblTranDate.Name = "LblTranDate"
        Me.LblTranDate.Size = New System.Drawing.Size(201, 30)
        Me.LblTranDate.TabIndex = 54
        Me.LblTranDate.Text = "LblTranDate"
        Me.LblTranDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label11.Font = New System.Drawing.Font("メイリオ", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(11, 32)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(150, 30)
        Me.Label11.TabIndex = 53
        Me.Label11.Text = "処　理　日"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblJobName
        '
        Me.LblJobName.BackColor = System.Drawing.SystemColors.Control
        Me.LblJobName.Font = New System.Drawing.Font("メイリオ", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblJobName.Location = New System.Drawing.Point(163, 65)
        Me.LblJobName.Name = "LblJobName"
        Me.LblJobName.Size = New System.Drawing.Size(246, 30)
        Me.LblJobName.TabIndex = 51
        Me.LblJobName.Text = "LblJobName"
        Me.LblJobName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblSitenName
        '
        Me.LblSitenName.BackColor = System.Drawing.SystemColors.Control
        Me.LblSitenName.Font = New System.Drawing.Font("メイリオ", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblSitenName.Location = New System.Drawing.Point(532, 64)
        Me.LblSitenName.Name = "LblSitenName"
        Me.LblSitenName.Size = New System.Drawing.Size(280, 30)
        Me.LblSitenName.TabIndex = 50
        Me.LblSitenName.Text = "LblSitenName"
        Me.LblSitenName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label19.Font = New System.Drawing.Font("メイリオ", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label19.Location = New System.Drawing.Point(415, 64)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(115, 30)
        Me.Label19.TabIndex = 49
        Me.Label19.Text = "支 店 名"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblSitenCd
        '
        Me.LblSitenCd.BackColor = System.Drawing.SystemColors.Control
        Me.LblSitenCd.Font = New System.Drawing.Font("メイリオ", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblSitenCd.Location = New System.Drawing.Point(532, 31)
        Me.LblSitenCd.Name = "LblSitenCd"
        Me.LblSitenCd.Size = New System.Drawing.Size(96, 30)
        Me.LblSitenCd.TabIndex = 48
        Me.LblSitenCd.Text = "LblSitenCd"
        Me.LblSitenCd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label6.Font = New System.Drawing.Font("メイリオ", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(11, 65)
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
        Me.LblClass.Location = New System.Drawing.Point(163, 130)
        Me.LblClass.Name = "LblClass"
        Me.LblClass.Size = New System.Drawing.Size(650, 30)
        Me.LblClass.TabIndex = 44
        Me.LblClass.Text = "LblClass"
        Me.LblClass.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label46
        '
        Me.Label46.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label46.Font = New System.Drawing.Font("メイリオ", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label46.ForeColor = System.Drawing.Color.Black
        Me.Label46.Location = New System.Drawing.Point(11, 130)
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
        Me.Label10.Location = New System.Drawing.Point(415, 31)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(115, 30)
        Me.Label10.TabIndex = 37
        Me.Label10.Text = "支店コード"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblPostName
        '
        Me.LblPostName.BackColor = System.Drawing.SystemColors.Control
        Me.LblPostName.Font = New System.Drawing.Font("メイリオ", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblPostName.ForeColor = System.Drawing.Color.Black
        Me.LblPostName.Location = New System.Drawing.Point(163, 258)
        Me.LblPostName.Name = "LblPostName"
        Me.LblPostName.Size = New System.Drawing.Size(494, 30)
        Me.LblPostName.TabIndex = 36
        Me.LblPostName.Text = "LblPostName"
        Me.LblPostName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label7.Font = New System.Drawing.Font("メイリオ", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(11, 258)
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
        Me.LblComment.Location = New System.Drawing.Point(163, 98)
        Me.LblComment.Name = "LblComment"
        Me.LblComment.Size = New System.Drawing.Size(650, 30)
        Me.LblComment.TabIndex = 34
        Me.LblComment.Text = "LblComment"
        Me.LblComment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("メイリオ", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(11, 98)
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
        Me.LblName.Location = New System.Drawing.Point(163, 226)
        Me.LblName.Name = "LblName"
        Me.LblName.Size = New System.Drawing.Size(494, 30)
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
        Me.LblAddress2.Location = New System.Drawing.Point(163, 194)
        Me.LblAddress2.Name = "LblAddress2"
        Me.LblAddress2.Size = New System.Drawing.Size(650, 30)
        Me.LblAddress2.TabIndex = 25
        Me.LblAddress2.Text = "LblAddress2"
        Me.LblAddress2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblAddress1
        '
        Me.LblAddress1.BackColor = System.Drawing.SystemColors.Control
        Me.LblAddress1.Font = New System.Drawing.Font("メイリオ", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblAddress1.ForeColor = System.Drawing.Color.Black
        Me.LblAddress1.Location = New System.Drawing.Point(163, 162)
        Me.LblAddress1.Name = "LblAddress1"
        Me.LblAddress1.Size = New System.Drawing.Size(650, 30)
        Me.LblAddress1.TabIndex = 24
        Me.LblAddress1.Text = "LblAddress1"
        Me.LblAddress1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label3.Font = New System.Drawing.Font("メイリオ", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(11, 162)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(150, 30)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "差出人住所"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lstGetDataView
        '
        Me.lstGetDataView.CheckBoxes = True
        Me.lstGetDataView.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lstGetDataView.FullRowSelect = True
        Me.lstGetDataView.GridLines = True
        Me.lstGetDataView.Location = New System.Drawing.Point(782, 228)
        Me.lstGetDataView.MultiSelect = False
        Me.lstGetDataView.Name = "lstGetDataView"
        Me.lstGetDataView.Size = New System.Drawing.Size(1029, 645)
        Me.lstGetDataView.TabIndex = 145
        Me.lstGetDataView.UseCompatibleStateImageBehavior = False
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label15.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label15.Location = New System.Drawing.Point(100, 401)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(151, 24)
        Me.Label15.TabIndex = 150
        Me.Label15.Text = "選択データ画像"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox12
        '
        Me.GroupBox12.Controls.Add(Me.Rdo8FacePerPage)
        Me.GroupBox12.Controls.Add(Me.Rdo15FacePerPage)
        Me.GroupBox12.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox12.Location = New System.Drawing.Point(86, 808)
        Me.GroupBox12.Name = "GroupBox12"
        Me.GroupBox12.Size = New System.Drawing.Size(304, 87)
        Me.GroupBox12.TabIndex = 151
        Me.GroupBox12.TabStop = False
        Me.GroupBox12.Text = "受領証面数設定"
        '
        'Rdo8FacePerPage
        '
        Me.Rdo8FacePerPage.Location = New System.Drawing.Point(172, 35)
        Me.Rdo8FacePerPage.Name = "Rdo8FacePerPage"
        Me.Rdo8FacePerPage.Size = New System.Drawing.Size(74, 28)
        Me.Rdo8FacePerPage.TabIndex = 1
        Me.Rdo8FacePerPage.Text = "8面"
        Me.Rdo8FacePerPage.UseVisualStyleBackColor = True
        '
        'Rdo15FacePerPage
        '
        Me.Rdo15FacePerPage.Checked = True
        Me.Rdo15FacePerPage.Location = New System.Drawing.Point(50, 35)
        Me.Rdo15FacePerPage.Name = "Rdo15FacePerPage"
        Me.Rdo15FacePerPage.Size = New System.Drawing.Size(79, 28)
        Me.Rdo15FacePerPage.TabIndex = 0
        Me.Rdo15FacePerPage.TabStop = True
        Me.Rdo15FacePerPage.Text = "15面"
        Me.Rdo15FacePerPage.UseVisualStyleBackColor = True
        '
        'BtnBack
        '
        Me.BtnBack.Location = New System.Drawing.Point(1194, 935)
        Me.BtnBack.Name = "BtnBack"
        Me.BtnBack.Size = New System.Drawing.Size(300, 100)
        Me.BtnBack.TabIndex = 152
        Me.BtnBack.Text = "戻る"
        Me.BtnBack.UseVisualStyleBackColor = True
        '
        'BtnEnd
        '
        Me.BtnEnd.Location = New System.Drawing.Point(1511, 935)
        Me.BtnEnd.Name = "BtnEnd"
        Me.BtnEnd.Size = New System.Drawing.Size(300, 100)
        Me.BtnEnd.TabIndex = 153
        Me.BtnEnd.Text = "終了"
        Me.BtnEnd.UseVisualStyleBackColor = True
        '
        'DateTimeTimer
        '
        '
        'lblCurrentTime
        '
        Me.lblCurrentTime.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblCurrentTime.Location = New System.Drawing.Point(1687, 82)
        Me.lblCurrentTime.Name = "lblCurrentTime"
        Me.lblCurrentTime.Size = New System.Drawing.Size(166, 35)
        Me.lblCurrentTime.TabIndex = 155
        Me.lblCurrentTime.Text = "lblCurrentTime"
        Me.lblCurrentTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblYear
        '
        Me.lblYear.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblYear.Location = New System.Drawing.Point(1458, 82)
        Me.lblYear.Name = "lblYear"
        Me.lblYear.Size = New System.Drawing.Size(223, 35)
        Me.lblYear.TabIndex = 154
        Me.lblYear.Text = "lblYear"
        Me.lblYear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Blue
        Me.Label4.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(110, 713)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(134, 30)
        Me.Label4.TabIndex = 157
        Me.Label4.Text = "引受番号"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Blue
        Me.Label5.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(110, 756)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(134, 30)
        Me.Label5.TabIndex = 158
        Me.Label5.Text = "取得時間"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblAcceptNum4
        '
        Me.lblAcceptNum4.BackColor = System.Drawing.Color.White
        Me.lblAcceptNum4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblAcceptNum4.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblAcceptNum4.Location = New System.Drawing.Point(473, 713)
        Me.lblAcceptNum4.Name = "lblAcceptNum4"
        Me.lblAcceptNum4.Size = New System.Drawing.Size(34, 30)
        Me.lblAcceptNum4.TabIndex = 162
        Me.lblAcceptNum4.Text = "9"
        Me.lblAcceptNum4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblAcceptNum3
        '
        Me.lblAcceptNum3.BackColor = System.Drawing.Color.White
        Me.lblAcceptNum3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblAcceptNum3.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblAcceptNum3.Location = New System.Drawing.Point(377, 713)
        Me.lblAcceptNum3.Name = "lblAcceptNum3"
        Me.lblAcceptNum3.Size = New System.Drawing.Size(90, 30)
        Me.lblAcceptNum3.TabIndex = 161
        Me.lblAcceptNum3.Text = "99999"
        Me.lblAcceptNum3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblAcceptNum2
        '
        Me.lblAcceptNum2.BackColor = System.Drawing.Color.White
        Me.lblAcceptNum2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblAcceptNum2.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblAcceptNum2.Location = New System.Drawing.Point(320, 713)
        Me.lblAcceptNum2.Name = "lblAcceptNum2"
        Me.lblAcceptNum2.Size = New System.Drawing.Size(51, 30)
        Me.lblAcceptNum2.TabIndex = 160
        Me.lblAcceptNum2.Text = "99"
        Me.lblAcceptNum2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblAcceptNum1
        '
        Me.lblAcceptNum1.BackColor = System.Drawing.Color.White
        Me.lblAcceptNum1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblAcceptNum1.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblAcceptNum1.Location = New System.Drawing.Point(245, 713)
        Me.lblAcceptNum1.Name = "lblAcceptNum1"
        Me.lblAcceptNum1.Size = New System.Drawing.Size(69, 30)
        Me.lblAcceptNum1.TabIndex = 159
        Me.lblAcceptNum1.Text = "999"
        Me.lblAcceptNum1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblCreateDate
        '
        Me.LblCreateDate.BackColor = System.Drawing.Color.White
        Me.LblCreateDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblCreateDate.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblCreateDate.ForeColor = System.Drawing.Color.Black
        Me.LblCreateDate.Location = New System.Drawing.Point(245, 756)
        Me.LblCreateDate.Name = "LblCreateDate"
        Me.LblCreateDate.Size = New System.Drawing.Size(261, 30)
        Me.LblCreateDate.TabIndex = 163
        Me.LblCreateDate.Text = "LblCreateDate"
        Me.LblCreateDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnRePrint
        '
        Me.BtnRePrint.Location = New System.Drawing.Point(414, 821)
        Me.BtnRePrint.Name = "BtnRePrint"
        Me.BtnRePrint.Size = New System.Drawing.Size(300, 100)
        Me.BtnRePrint.TabIndex = 164
        Me.BtnRePrint.Text = "受領証再作成"
        Me.BtnRePrint.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.Control
        Me.Label9.Font = New System.Drawing.Font("メイリオ", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Red
        Me.Label9.Location = New System.Drawing.Point(784, 875)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(499, 30)
        Me.Label9.TabIndex = 165
        Me.Label9.Text = "↑抜取する引受番号のチェックボックスにチェックを入れてください"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SearchResultForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(16.0!, 41.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1914, 1052)
        Me.ControlBox = False
        Me.Controls.Add(Me.lstGetDataView)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.BtnRePrint)
        Me.Controls.Add(Me.LblCreateDate)
        Me.Controls.Add(Me.lblAcceptNum4)
        Me.Controls.Add(Me.lblAcceptNum3)
        Me.Controls.Add(Me.lblAcceptNum2)
        Me.Controls.Add(Me.lblAcceptNum1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblCurrentTime)
        Me.Controls.Add(Me.lblYear)
        Me.Controls.Add(Me.BtnEnd)
        Me.Controls.Add(Me.BtnBack)
        Me.Controls.Add(Me.GroupBox12)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.lblSaveLogFileName)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.LblOperatorName)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lblTitle)
        Me.Font = New System.Drawing.Font("メイリオ", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(8, 10, 8, 10)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SearchResultForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "検索画面（データ確認・抜取り）"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox12.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LblOperatorName As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents lblSaveLogFileName As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents LblSitenName As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents LblSitenCd As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents LblClass As System.Windows.Forms.Label
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents LblPostName As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents LblComment As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LblName As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents LblAddress2 As System.Windows.Forms.Label
    Friend WithEvents LblAddress1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lstGetDataView As System.Windows.Forms.ListView
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents GroupBox12 As System.Windows.Forms.GroupBox
    Friend WithEvents Rdo8FacePerPage As System.Windows.Forms.RadioButton
    Friend WithEvents Rdo15FacePerPage As System.Windows.Forms.RadioButton
    Friend WithEvents BtnBack As System.Windows.Forms.Button
    Friend WithEvents BtnEnd As System.Windows.Forms.Button
    Friend WithEvents DateTimeTimer As System.Windows.Forms.Timer
    Friend WithEvents lblCurrentTime As System.Windows.Forms.Label
    Friend WithEvents lblYear As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblAcceptNum4 As System.Windows.Forms.Label
    Friend WithEvents lblAcceptNum3 As System.Windows.Forms.Label
    Friend WithEvents lblAcceptNum2 As System.Windows.Forms.Label
    Friend WithEvents lblAcceptNum1 As System.Windows.Forms.Label
    Friend WithEvents LblCreateDate As System.Windows.Forms.Label
    Friend WithEvents LblJobName As System.Windows.Forms.Label
    Friend WithEvents LblTranDate As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents BtnRePrint As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
End Class
