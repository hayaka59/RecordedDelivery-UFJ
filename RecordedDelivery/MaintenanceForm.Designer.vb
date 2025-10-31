<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MaintenanceForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MaintenanceForm))
        Me.SerialPort = New System.IO.Ports.SerialPort(Me.components)
        Me.RcvTextBox = New System.Windows.Forms.TextBox()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox13 = New System.Windows.Forms.GroupBox()
        Me.TxtBarCode = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnSetValue = New System.Windows.Forms.Button()
        Me.RadioButton8 = New System.Windows.Forms.RadioButton()
        Me.RadioButton7 = New System.Windows.Forms.RadioButton()
        Me.RadioButton6 = New System.Windows.Forms.RadioButton()
        Me.RadioButton5 = New System.Windows.Forms.RadioButton()
        Me.RadioButton4 = New System.Windows.Forms.RadioButton()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtVersion = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.LblInputC = New System.Windows.Forms.Label()
        Me.txtInputC = New System.Windows.Forms.TextBox()
        Me.LblInputB = New System.Windows.Forms.Label()
        Me.txtInputB = New System.Windows.Forms.TextBox()
        Me.LblInputA = New System.Windows.Forms.Label()
        Me.txtInputA = New System.Windows.Forms.TextBox()
        Me.LblInput9 = New System.Windows.Forms.Label()
        Me.txtInput9 = New System.Windows.Forms.TextBox()
        Me.LblInput8 = New System.Windows.Forms.Label()
        Me.txtInput8 = New System.Windows.Forms.TextBox()
        Me.LblInput7 = New System.Windows.Forms.Label()
        Me.txtInput7 = New System.Windows.Forms.TextBox()
        Me.LblInput6 = New System.Windows.Forms.Label()
        Me.txtInput6 = New System.Windows.Forms.TextBox()
        Me.LblInput5 = New System.Windows.Forms.Label()
        Me.txtInput5 = New System.Windows.Forms.TextBox()
        Me.LblInput4 = New System.Windows.Forms.Label()
        Me.txtInput4 = New System.Windows.Forms.TextBox()
        Me.LblInput3 = New System.Windows.Forms.Label()
        Me.txtInput3 = New System.Windows.Forms.TextBox()
        Me.LblInput2 = New System.Windows.Forms.Label()
        Me.txtInput2 = New System.Windows.Forms.TextBox()
        Me.LblInput1 = New System.Windows.Forms.Label()
        Me.txtInput1 = New System.Windows.Forms.TextBox()
        Me.BtnBack = New System.Windows.Forms.Button()
        Me.LblOperatorName = New System.Windows.Forms.Label()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtKuwake = New System.Windows.Forms.TextBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TxtFooter2 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtFooter1 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtHeader2 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtHeader1 = New System.Windows.Forms.TextBox()
        Me.TxtSt1Num4 = New System.Windows.Forms.TextBox()
        Me.TxtSt1Num3 = New System.Windows.Forms.TextBox()
        Me.TxtSt1Num2 = New System.Windows.Forms.TextBox()
        Me.TxtSt1Num1 = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.LblStartNumber1 = New System.Windows.Forms.Label()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.LblStartNumber3 = New System.Windows.Forms.Label()
        Me.TxtSt3Num4 = New System.Windows.Forms.TextBox()
        Me.TxtSt3Num3 = New System.Windows.Forms.TextBox()
        Me.TxtSt3Num2 = New System.Windows.Forms.TextBox()
        Me.TxtSt3Num1 = New System.Windows.Forms.TextBox()
        Me.LblStartNumber2 = New System.Windows.Forms.Label()
        Me.TxtSt2Num4 = New System.Windows.Forms.TextBox()
        Me.TxtSt2Num3 = New System.Windows.Forms.TextBox()
        Me.TxtSt2Num2 = New System.Windows.Forms.TextBox()
        Me.TxtSt2Num1 = New System.Windows.Forms.TextBox()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtUserNo = New System.Windows.Forms.TextBox()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TxtTrigerTime = New System.Windows.Forms.TextBox()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.BtnRefImage = New System.Windows.Forms.Button()
        Me.BtnRefTran = New System.Windows.Forms.Button()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.TxtImageLog = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TxtTranLog = New System.Windows.Forms.TextBox()
        Me.GroupBox10 = New System.Windows.Forms.GroupBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.TxtPassUsePeriod = New System.Windows.Forms.TextBox()
        Me.ChkHidden = New System.Windows.Forms.CheckBox()
        Me.LblDecrypt = New System.Windows.Forms.Label()
        Me.GroupBox11 = New System.Windows.Forms.GroupBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.TxtMachineName = New System.Windows.Forms.TextBox()
        Me.TxtName = New System.Windows.Forms.TextBox()
        Me.TxtAddress2 = New System.Windows.Forms.TextBox()
        Me.TxtAddress1 = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.GroupBox12 = New System.Windows.Forms.GroupBox()
        Me.BtnProcessListOutPut = New System.Windows.Forms.Button()
        Me.LblStartNumber4 = New System.Windows.Forms.Label()
        Me.TxtSt4Num4 = New System.Windows.Forms.TextBox()
        Me.TxtSt4Num3 = New System.Windows.Forms.TextBox()
        Me.TxtSt4Num2 = New System.Windows.Forms.TextBox()
        Me.TxtSt4Num1 = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.GroupBox13.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.GroupBox10.SuspendLayout()
        Me.GroupBox11.SuspendLayout()
        Me.GroupBox12.SuspendLayout()
        Me.SuspendLayout()
        '
        'SerialPort
        '
        '
        'RcvTextBox
        '
        Me.RcvTextBox.Font = New System.Drawing.Font("メイリオ", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.RcvTextBox.Location = New System.Drawing.Point(100, 983)
        Me.RcvTextBox.Name = "RcvTextBox"
        Me.RcvTextBox.Size = New System.Drawing.Size(564, 48)
        Me.RcvTextBox.TabIndex = 4
        Me.RcvTextBox.Text = "RcvTextBox"
        Me.RcvTextBox.Visible = False
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblTitle.Font = New System.Drawing.Font("メイリオ", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(2, 0)
        Me.lblTitle.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(1916, 85)
        Me.lblTitle.TabIndex = 5
        Me.lblTitle.Text = "　書留郵便受領証発行機　メンテナンス画面"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.GroupBox13)
        Me.Panel1.Controls.Add(Me.GroupBox3)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Location = New System.Drawing.Point(100, 114)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(564, 863)
        Me.Panel1.TabIndex = 8
        '
        'GroupBox13
        '
        Me.GroupBox13.Controls.Add(Me.TxtBarCode)
        Me.GroupBox13.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox13.Location = New System.Drawing.Point(66, 748)
        Me.GroupBox13.Name = "GroupBox13"
        Me.GroupBox13.Size = New System.Drawing.Size(418, 80)
        Me.GroupBox13.TabIndex = 95
        Me.GroupBox13.TabStop = False
        Me.GroupBox13.Text = "バーコード読取値"
        '
        'TxtBarCode
        '
        Me.TxtBarCode.Font = New System.Drawing.Font("MS UI Gothic", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TxtBarCode.Location = New System.Drawing.Point(70, 32)
        Me.TxtBarCode.MaxLength = 11
        Me.TxtBarCode.Name = "TxtBarCode"
        Me.TxtBarCode.Size = New System.Drawing.Size(260, 34)
        Me.TxtBarCode.TabIndex = 94
        Me.TxtBarCode.Text = "12345678901"
        Me.TxtBarCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnSetValue)
        Me.GroupBox3.Controls.Add(Me.RadioButton8)
        Me.GroupBox3.Controls.Add(Me.RadioButton7)
        Me.GroupBox3.Controls.Add(Me.RadioButton6)
        Me.GroupBox3.Controls.Add(Me.RadioButton5)
        Me.GroupBox3.Controls.Add(Me.RadioButton4)
        Me.GroupBox3.Controls.Add(Me.RadioButton3)
        Me.GroupBox3.Controls.Add(Me.RadioButton2)
        Me.GroupBox3.Controls.Add(Me.RadioButton1)
        Me.GroupBox3.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(65, 834)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(419, 131)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "出力選択"
        Me.GroupBox3.Visible = False
        '
        'btnSetValue
        '
        Me.btnSetValue.Font = New System.Drawing.Font("メイリオ", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnSetValue.Location = New System.Drawing.Point(106, 411)
        Me.btnSetValue.Name = "btnSetValue"
        Me.btnSetValue.Size = New System.Drawing.Size(208, 53)
        Me.btnSetValue.TabIndex = 9
        Me.btnSetValue.Text = "設定"
        Me.btnSetValue.UseVisualStyleBackColor = True
        '
        'RadioButton8
        '
        Me.RadioButton8.Font = New System.Drawing.Font("メイリオ", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.RadioButton8.Location = New System.Drawing.Point(23, 360)
        Me.RadioButton8.Name = "RadioButton8"
        Me.RadioButton8.Size = New System.Drawing.Size(371, 45)
        Me.RadioButton8.TabIndex = 8
        Me.RadioButton8.Text = "RadioButton8"
        Me.RadioButton8.UseVisualStyleBackColor = True
        '
        'RadioButton7
        '
        Me.RadioButton7.Font = New System.Drawing.Font("メイリオ", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.RadioButton7.Location = New System.Drawing.Point(23, 313)
        Me.RadioButton7.Name = "RadioButton7"
        Me.RadioButton7.Size = New System.Drawing.Size(371, 45)
        Me.RadioButton7.TabIndex = 7
        Me.RadioButton7.Text = "RadioButton7"
        Me.RadioButton7.UseVisualStyleBackColor = True
        '
        'RadioButton6
        '
        Me.RadioButton6.Font = New System.Drawing.Font("メイリオ", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.RadioButton6.Location = New System.Drawing.Point(23, 266)
        Me.RadioButton6.Name = "RadioButton6"
        Me.RadioButton6.Size = New System.Drawing.Size(371, 45)
        Me.RadioButton6.TabIndex = 6
        Me.RadioButton6.Text = "RadioButton6"
        Me.RadioButton6.UseVisualStyleBackColor = True
        '
        'RadioButton5
        '
        Me.RadioButton5.Font = New System.Drawing.Font("メイリオ", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.RadioButton5.Location = New System.Drawing.Point(23, 220)
        Me.RadioButton5.Name = "RadioButton5"
        Me.RadioButton5.Size = New System.Drawing.Size(371, 45)
        Me.RadioButton5.TabIndex = 5
        Me.RadioButton5.Text = "RadioButton5"
        Me.RadioButton5.UseVisualStyleBackColor = True
        '
        'RadioButton4
        '
        Me.RadioButton4.Font = New System.Drawing.Font("メイリオ", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.RadioButton4.Location = New System.Drawing.Point(23, 174)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.Size = New System.Drawing.Size(371, 45)
        Me.RadioButton4.TabIndex = 4
        Me.RadioButton4.Text = "RadioButton4"
        Me.RadioButton4.UseVisualStyleBackColor = True
        '
        'RadioButton3
        '
        Me.RadioButton3.Font = New System.Drawing.Font("メイリオ", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.RadioButton3.Location = New System.Drawing.Point(23, 128)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(371, 45)
        Me.RadioButton3.TabIndex = 3
        Me.RadioButton3.Text = "RadioButton3"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.Font = New System.Drawing.Font("メイリオ", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.RadioButton2.Location = New System.Drawing.Point(23, 82)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(371, 45)
        Me.RadioButton2.TabIndex = 2
        Me.RadioButton2.Text = "RadioButton2"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Font = New System.Drawing.Font("メイリオ", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.RadioButton1.Location = New System.Drawing.Point(23, 35)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(371, 45)
        Me.RadioButton1.TabIndex = 1
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "RadioButton1"
        Me.RadioButton1.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.txtVersion)
        Me.GroupBox2.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(13, 14)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(532, 128)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "バージョン表示"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(11, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(510, 38)
        Me.Label1.TabIndex = 70
        Me.Label1.Text = "バージョン情報"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtVersion
        '
        Me.txtVersion.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtVersion.Location = New System.Drawing.Point(11, 70)
        Me.txtVersion.MaxLength = 999
        Me.txtVersion.Name = "txtVersion"
        Me.txtVersion.Size = New System.Drawing.Size(510, 36)
        Me.txtVersion.TabIndex = 69
        Me.txtVersion.Text = "123456789*123456789*"
        Me.txtVersion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LblInputC)
        Me.GroupBox1.Controls.Add(Me.txtInputC)
        Me.GroupBox1.Controls.Add(Me.LblInputB)
        Me.GroupBox1.Controls.Add(Me.txtInputB)
        Me.GroupBox1.Controls.Add(Me.LblInputA)
        Me.GroupBox1.Controls.Add(Me.txtInputA)
        Me.GroupBox1.Controls.Add(Me.LblInput9)
        Me.GroupBox1.Controls.Add(Me.txtInput9)
        Me.GroupBox1.Controls.Add(Me.LblInput8)
        Me.GroupBox1.Controls.Add(Me.txtInput8)
        Me.GroupBox1.Controls.Add(Me.LblInput7)
        Me.GroupBox1.Controls.Add(Me.txtInput7)
        Me.GroupBox1.Controls.Add(Me.LblInput6)
        Me.GroupBox1.Controls.Add(Me.txtInput6)
        Me.GroupBox1.Controls.Add(Me.LblInput5)
        Me.GroupBox1.Controls.Add(Me.txtInput5)
        Me.GroupBox1.Controls.Add(Me.LblInput4)
        Me.GroupBox1.Controls.Add(Me.txtInput4)
        Me.GroupBox1.Controls.Add(Me.LblInput3)
        Me.GroupBox1.Controls.Add(Me.txtInput3)
        Me.GroupBox1.Controls.Add(Me.LblInput2)
        Me.GroupBox1.Controls.Add(Me.txtInput2)
        Me.GroupBox1.Controls.Add(Me.LblInput1)
        Me.GroupBox1.Controls.Add(Me.txtInput1)
        Me.GroupBox1.Font = New System.Drawing.Font("MS UI Gothic", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(65, 148)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(419, 587)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "入力表示"
        '
        'LblInputC
        '
        Me.LblInputC.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblInputC.Font = New System.Drawing.Font("MS UI Gothic", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblInputC.ForeColor = System.Drawing.Color.Black
        Me.LblInputC.Location = New System.Drawing.Point(18, 521)
        Me.LblInputC.Name = "LblInputC"
        Me.LblInputC.Size = New System.Drawing.Size(204, 34)
        Me.LblInputC.TabIndex = 92
        Me.LblInputC.Text = "LblInputC"
        Me.LblInputC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtInputC
        '
        Me.txtInputC.Font = New System.Drawing.Font("MS UI Gothic", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtInputC.Location = New System.Drawing.Point(222, 520)
        Me.txtInputC.MaxLength = 8
        Me.txtInputC.Name = "txtInputC"
        Me.txtInputC.Size = New System.Drawing.Size(168, 34)
        Me.txtInputC.TabIndex = 91
        Me.txtInputC.Text = "12345678"
        Me.txtInputC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LblInputB
        '
        Me.LblInputB.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblInputB.Font = New System.Drawing.Font("MS UI Gothic", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblInputB.ForeColor = System.Drawing.Color.Black
        Me.LblInputB.Location = New System.Drawing.Point(18, 475)
        Me.LblInputB.Name = "LblInputB"
        Me.LblInputB.Size = New System.Drawing.Size(204, 34)
        Me.LblInputB.TabIndex = 90
        Me.LblInputB.Text = "LblInputB"
        Me.LblInputB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtInputB
        '
        Me.txtInputB.Font = New System.Drawing.Font("MS UI Gothic", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtInputB.Location = New System.Drawing.Point(222, 474)
        Me.txtInputB.MaxLength = 8
        Me.txtInputB.Name = "txtInputB"
        Me.txtInputB.Size = New System.Drawing.Size(168, 34)
        Me.txtInputB.TabIndex = 89
        Me.txtInputB.Text = "12345678"
        Me.txtInputB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LblInputA
        '
        Me.LblInputA.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblInputA.Font = New System.Drawing.Font("MS UI Gothic", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblInputA.ForeColor = System.Drawing.Color.Black
        Me.LblInputA.Location = New System.Drawing.Point(18, 430)
        Me.LblInputA.Name = "LblInputA"
        Me.LblInputA.Size = New System.Drawing.Size(204, 34)
        Me.LblInputA.TabIndex = 88
        Me.LblInputA.Text = "LblInputA"
        Me.LblInputA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtInputA
        '
        Me.txtInputA.Font = New System.Drawing.Font("MS UI Gothic", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtInputA.Location = New System.Drawing.Point(222, 429)
        Me.txtInputA.MaxLength = 8
        Me.txtInputA.Name = "txtInputA"
        Me.txtInputA.Size = New System.Drawing.Size(168, 34)
        Me.txtInputA.TabIndex = 87
        Me.txtInputA.Text = "12345678"
        Me.txtInputA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LblInput9
        '
        Me.LblInput9.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblInput9.Font = New System.Drawing.Font("MS UI Gothic", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblInput9.ForeColor = System.Drawing.Color.Black
        Me.LblInput9.Location = New System.Drawing.Point(18, 385)
        Me.LblInput9.Name = "LblInput9"
        Me.LblInput9.Size = New System.Drawing.Size(204, 34)
        Me.LblInput9.TabIndex = 86
        Me.LblInput9.Text = "LblInput9"
        Me.LblInput9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtInput9
        '
        Me.txtInput9.Font = New System.Drawing.Font("MS UI Gothic", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtInput9.Location = New System.Drawing.Point(222, 384)
        Me.txtInput9.MaxLength = 8
        Me.txtInput9.Name = "txtInput9"
        Me.txtInput9.Size = New System.Drawing.Size(168, 34)
        Me.txtInput9.TabIndex = 85
        Me.txtInput9.Text = "12345678"
        Me.txtInput9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LblInput8
        '
        Me.LblInput8.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblInput8.Font = New System.Drawing.Font("MS UI Gothic", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblInput8.ForeColor = System.Drawing.Color.Black
        Me.LblInput8.Location = New System.Drawing.Point(18, 341)
        Me.LblInput8.Name = "LblInput8"
        Me.LblInput8.Size = New System.Drawing.Size(204, 34)
        Me.LblInput8.TabIndex = 84
        Me.LblInput8.Text = "LblInput8"
        Me.LblInput8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtInput8
        '
        Me.txtInput8.Font = New System.Drawing.Font("MS UI Gothic", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtInput8.Location = New System.Drawing.Point(222, 340)
        Me.txtInput8.MaxLength = 8
        Me.txtInput8.Name = "txtInput8"
        Me.txtInput8.Size = New System.Drawing.Size(168, 34)
        Me.txtInput8.TabIndex = 83
        Me.txtInput8.Text = "12345678"
        Me.txtInput8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LblInput7
        '
        Me.LblInput7.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblInput7.Font = New System.Drawing.Font("MS UI Gothic", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblInput7.ForeColor = System.Drawing.Color.Black
        Me.LblInput7.Location = New System.Drawing.Point(18, 297)
        Me.LblInput7.Name = "LblInput7"
        Me.LblInput7.Size = New System.Drawing.Size(204, 34)
        Me.LblInput7.TabIndex = 82
        Me.LblInput7.Text = "LblInput7"
        Me.LblInput7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtInput7
        '
        Me.txtInput7.Font = New System.Drawing.Font("MS UI Gothic", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtInput7.Location = New System.Drawing.Point(222, 296)
        Me.txtInput7.MaxLength = 8
        Me.txtInput7.Name = "txtInput7"
        Me.txtInput7.Size = New System.Drawing.Size(168, 34)
        Me.txtInput7.TabIndex = 81
        Me.txtInput7.Text = "12345678"
        Me.txtInput7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LblInput6
        '
        Me.LblInput6.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblInput6.Font = New System.Drawing.Font("MS UI Gothic", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblInput6.ForeColor = System.Drawing.Color.Black
        Me.LblInput6.Location = New System.Drawing.Point(18, 253)
        Me.LblInput6.Name = "LblInput6"
        Me.LblInput6.Size = New System.Drawing.Size(204, 34)
        Me.LblInput6.TabIndex = 80
        Me.LblInput6.Text = "LblInput6"
        Me.LblInput6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtInput6
        '
        Me.txtInput6.Font = New System.Drawing.Font("MS UI Gothic", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtInput6.Location = New System.Drawing.Point(222, 252)
        Me.txtInput6.MaxLength = 8
        Me.txtInput6.Name = "txtInput6"
        Me.txtInput6.Size = New System.Drawing.Size(168, 34)
        Me.txtInput6.TabIndex = 79
        Me.txtInput6.Text = "12345678"
        Me.txtInput6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LblInput5
        '
        Me.LblInput5.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblInput5.Font = New System.Drawing.Font("MS UI Gothic", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblInput5.ForeColor = System.Drawing.Color.Black
        Me.LblInput5.Location = New System.Drawing.Point(18, 208)
        Me.LblInput5.Name = "LblInput5"
        Me.LblInput5.Size = New System.Drawing.Size(204, 34)
        Me.LblInput5.TabIndex = 78
        Me.LblInput5.Text = "LblInput5"
        Me.LblInput5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtInput5
        '
        Me.txtInput5.Font = New System.Drawing.Font("MS UI Gothic", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtInput5.Location = New System.Drawing.Point(222, 207)
        Me.txtInput5.MaxLength = 8
        Me.txtInput5.Name = "txtInput5"
        Me.txtInput5.Size = New System.Drawing.Size(168, 34)
        Me.txtInput5.TabIndex = 77
        Me.txtInput5.Text = "12345678"
        Me.txtInput5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LblInput4
        '
        Me.LblInput4.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblInput4.Font = New System.Drawing.Font("MS UI Gothic", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblInput4.ForeColor = System.Drawing.Color.Black
        Me.LblInput4.Location = New System.Drawing.Point(18, 163)
        Me.LblInput4.Name = "LblInput4"
        Me.LblInput4.Size = New System.Drawing.Size(204, 34)
        Me.LblInput4.TabIndex = 76
        Me.LblInput4.Text = "LblInput4"
        Me.LblInput4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtInput4
        '
        Me.txtInput4.Font = New System.Drawing.Font("MS UI Gothic", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtInput4.Location = New System.Drawing.Point(222, 162)
        Me.txtInput4.MaxLength = 8
        Me.txtInput4.Name = "txtInput4"
        Me.txtInput4.Size = New System.Drawing.Size(168, 34)
        Me.txtInput4.TabIndex = 75
        Me.txtInput4.Text = "12345678"
        Me.txtInput4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LblInput3
        '
        Me.LblInput3.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblInput3.Font = New System.Drawing.Font("MS UI Gothic", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblInput3.ForeColor = System.Drawing.Color.Black
        Me.LblInput3.Location = New System.Drawing.Point(18, 118)
        Me.LblInput3.Name = "LblInput3"
        Me.LblInput3.Size = New System.Drawing.Size(204, 34)
        Me.LblInput3.TabIndex = 74
        Me.LblInput3.Text = "LblInput3"
        Me.LblInput3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtInput3
        '
        Me.txtInput3.Font = New System.Drawing.Font("MS UI Gothic", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtInput3.Location = New System.Drawing.Point(222, 117)
        Me.txtInput3.MaxLength = 8
        Me.txtInput3.Name = "txtInput3"
        Me.txtInput3.Size = New System.Drawing.Size(168, 34)
        Me.txtInput3.TabIndex = 73
        Me.txtInput3.Text = "12345678"
        Me.txtInput3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LblInput2
        '
        Me.LblInput2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblInput2.Font = New System.Drawing.Font("MS UI Gothic", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblInput2.ForeColor = System.Drawing.Color.Black
        Me.LblInput2.Location = New System.Drawing.Point(18, 74)
        Me.LblInput2.Name = "LblInput2"
        Me.LblInput2.Size = New System.Drawing.Size(204, 34)
        Me.LblInput2.TabIndex = 72
        Me.LblInput2.Text = "LblInput2"
        Me.LblInput2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtInput2
        '
        Me.txtInput2.Font = New System.Drawing.Font("MS UI Gothic", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtInput2.Location = New System.Drawing.Point(222, 73)
        Me.txtInput2.MaxLength = 8
        Me.txtInput2.Name = "txtInput2"
        Me.txtInput2.Size = New System.Drawing.Size(168, 34)
        Me.txtInput2.TabIndex = 71
        Me.txtInput2.Text = "12345678"
        Me.txtInput2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LblInput1
        '
        Me.LblInput1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblInput1.Font = New System.Drawing.Font("MS UI Gothic", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblInput1.ForeColor = System.Drawing.Color.Black
        Me.LblInput1.Location = New System.Drawing.Point(18, 31)
        Me.LblInput1.Name = "LblInput1"
        Me.LblInput1.Size = New System.Drawing.Size(204, 34)
        Me.LblInput1.TabIndex = 70
        Me.LblInput1.Text = "LblInput1"
        Me.LblInput1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtInput1
        '
        Me.txtInput1.Font = New System.Drawing.Font("MS UI Gothic", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtInput1.Location = New System.Drawing.Point(222, 30)
        Me.txtInput1.MaxLength = 8
        Me.txtInput1.Name = "txtInput1"
        Me.txtInput1.Size = New System.Drawing.Size(168, 34)
        Me.txtInput1.TabIndex = 69
        Me.txtInput1.Text = "12345678"
        Me.txtInput1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'BtnBack
        '
        Me.BtnBack.Font = New System.Drawing.Font("メイリオ", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnBack.Image = Global.RecordedDelivery.My.Resources.Resources.back_small
        Me.BtnBack.Location = New System.Drawing.Point(1217, 935)
        Me.BtnBack.Name = "BtnBack"
        Me.BtnBack.Size = New System.Drawing.Size(337, 70)
        Me.BtnBack.TabIndex = 4
        Me.BtnBack.Text = "戻る"
        Me.BtnBack.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnBack.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnBack.UseVisualStyleBackColor = True
        '
        'LblOperatorName
        '
        Me.LblOperatorName.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblOperatorName.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblOperatorName.ForeColor = System.Drawing.Color.White
        Me.LblOperatorName.Location = New System.Drawing.Point(1662, 30)
        Me.LblOperatorName.Name = "LblOperatorName"
        Me.LblOperatorName.Size = New System.Drawing.Size(224, 33)
        Me.LblOperatorName.TabIndex = 31
        Me.LblOperatorName.Text = "LblOperatorName"
        Me.LblOperatorName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblVersion
        '
        Me.lblVersion.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblVersion.Location = New System.Drawing.Point(1569, 967)
        Me.lblVersion.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(332, 32)
        Me.lblVersion.TabIndex = 32
        Me.lblVersion.Text = "lblVersion"
        Me.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Label3)
        Me.GroupBox5.Controls.Add(Me.TxtKuwake)
        Me.GroupBox5.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(939, 203)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(168, 91)
        Me.GroupBox5.TabIndex = 33
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "区分通数"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label3.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(15, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 48)
        Me.Label3.TabIndex = 70
        Me.Label3.Text = "設定値"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtKuwake
        '
        Me.TxtKuwake.Font = New System.Drawing.Font("メイリオ", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TxtKuwake.Location = New System.Drawing.Point(93, 32)
        Me.TxtKuwake.MaxLength = 2
        Me.TxtKuwake.Name = "TxtKuwake"
        Me.TxtKuwake.Size = New System.Drawing.Size(63, 48)
        Me.TxtKuwake.TabIndex = 69
        Me.TxtKuwake.Text = "99"
        Me.TxtKuwake.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.Label7)
        Me.GroupBox6.Controls.Add(Me.TxtFooter2)
        Me.GroupBox6.Controls.Add(Me.Label6)
        Me.GroupBox6.Controls.Add(Me.TxtFooter1)
        Me.GroupBox6.Controls.Add(Me.Label5)
        Me.GroupBox6.Controls.Add(Me.TxtHeader2)
        Me.GroupBox6.Controls.Add(Me.Label4)
        Me.GroupBox6.Controls.Add(Me.TxtHeader1)
        Me.GroupBox6.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox6.Location = New System.Drawing.Point(689, 545)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(1032, 210)
        Me.GroupBox6.TabIndex = 34
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "受領証印刷設定"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label7.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(33, 143)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(141, 49)
        Me.Label7.TabIndex = 76
        Me.Label7.Text = "フッター２"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtFooter2
        '
        Me.TxtFooter2.Font = New System.Drawing.Font("メイリオ", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TxtFooter2.Location = New System.Drawing.Point(176, 143)
        Me.TxtFooter2.MaxLength = 30
        Me.TxtFooter2.Name = "TxtFooter2"
        Me.TxtFooter2.Size = New System.Drawing.Size(836, 48)
        Me.TxtFooter2.TabIndex = 75
        Me.TxtFooter2.Text = "必要となりますので、大切に保存してください。"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label6.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(33, 87)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(141, 49)
        Me.Label6.TabIndex = 74
        Me.Label6.Text = "フッター１"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtFooter1
        '
        Me.TxtFooter1.Font = New System.Drawing.Font("メイリオ", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TxtFooter1.Location = New System.Drawing.Point(176, 87)
        Me.TxtFooter1.MaxLength = 30
        Me.TxtFooter1.Name = "TxtFooter1"
        Me.TxtFooter1.Size = New System.Drawing.Size(836, 48)
        Me.TxtFooter1.TabIndex = 73
        Me.TxtFooter1.Text = "この受領証は、損害賠償の請求をするときその他の場合に"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label5.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(488, 33)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(141, 47)
        Me.Label5.TabIndex = 72
        Me.Label5.Text = "ヘッダー２頁"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtHeader2
        '
        Me.TxtHeader2.Font = New System.Drawing.Font("メイリオ", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TxtHeader2.Location = New System.Drawing.Point(631, 32)
        Me.TxtHeader2.MaxLength = 10
        Me.TxtHeader2.Name = "TxtHeader2"
        Me.TxtHeader2.Size = New System.Drawing.Size(257, 48)
        Me.TxtHeader2.TabIndex = 71
        Me.TxtHeader2.Text = "受領証"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label4.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(33, 33)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(141, 47)
        Me.Label4.TabIndex = 70
        Me.Label4.Text = "ヘッダー１頁"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtHeader1
        '
        Me.TxtHeader1.Font = New System.Drawing.Font("メイリオ", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TxtHeader1.Location = New System.Drawing.Point(176, 32)
        Me.TxtHeader1.MaxLength = 10
        Me.TxtHeader1.Name = "TxtHeader1"
        Me.TxtHeader1.Size = New System.Drawing.Size(257, 48)
        Me.TxtHeader1.TabIndex = 69
        Me.TxtHeader1.Text = "差出票"
        '
        'TxtSt1Num4
        '
        Me.TxtSt1Num4.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TxtSt1Num4.Location = New System.Drawing.Point(493, 50)
        Me.TxtSt1Num4.MaxLength = 1
        Me.TxtSt1Num4.Name = "TxtSt1Num4"
        Me.TxtSt1Num4.Size = New System.Drawing.Size(34, 39)
        Me.TxtSt1Num4.TabIndex = 202
        Me.TxtSt1Num4.Text = "0"
        Me.TxtSt1Num4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtSt1Num3
        '
        Me.TxtSt1Num3.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TxtSt1Num3.Location = New System.Drawing.Point(397, 50)
        Me.TxtSt1Num3.MaxLength = 5
        Me.TxtSt1Num3.Name = "TxtSt1Num3"
        Me.TxtSt1Num3.Size = New System.Drawing.Size(90, 39)
        Me.TxtSt1Num3.TabIndex = 201
        Me.TxtSt1Num3.Text = "10000"
        Me.TxtSt1Num3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtSt1Num2
        '
        Me.TxtSt1Num2.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TxtSt1Num2.Location = New System.Drawing.Point(340, 50)
        Me.TxtSt1Num2.MaxLength = 2
        Me.TxtSt1Num2.Name = "TxtSt1Num2"
        Me.TxtSt1Num2.Size = New System.Drawing.Size(51, 39)
        Me.TxtSt1Num2.TabIndex = 200
        Me.TxtSt1Num2.Text = "12"
        Me.TxtSt1Num2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtSt1Num1
        '
        Me.TxtSt1Num1.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TxtSt1Num1.Location = New System.Drawing.Point(264, 50)
        Me.TxtSt1Num1.MaxLength = 3
        Me.TxtSt1Num1.Name = "TxtSt1Num1"
        Me.TxtSt1Num1.Size = New System.Drawing.Size(70, 39)
        Me.TxtSt1Num1.TabIndex = 199
        Me.TxtSt1Num1.Text = "030"
        Me.TxtSt1Num1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.Control
        Me.Label8.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(481, 21)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(98, 30)
        Me.Label8.TabIndex = 198
        Me.Label8.Text = "CD１桁"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.Control
        Me.Label9.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(406, 21)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(64, 30)
        Me.Label9.TabIndex = 197
        Me.Label9.Text = "５桁"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.Control
        Me.Label10.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(331, 21)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(62, 30)
        Me.Label10.TabIndex = 196
        Me.Label10.Text = "２桁"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.SystemColors.Control
        Me.Label11.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(265, 21)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(57, 30)
        Me.Label11.TabIndex = 195
        Me.Label11.Text = "３桁"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblStartNumber1
        '
        Me.LblStartNumber1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblStartNumber1.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblStartNumber1.ForeColor = System.Drawing.Color.Black
        Me.LblStartNumber1.Location = New System.Drawing.Point(32, 52)
        Me.LblStartNumber1.Name = "LblStartNumber1"
        Me.LblStartNumber1.Size = New System.Drawing.Size(226, 35)
        Me.LblStartNumber1.TabIndex = 194
        Me.LblStartNumber1.Text = "030：簡易書留"
        Me.LblStartNumber1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.LblStartNumber4)
        Me.GroupBox7.Controls.Add(Me.TxtSt4Num4)
        Me.GroupBox7.Controls.Add(Me.TxtSt4Num3)
        Me.GroupBox7.Controls.Add(Me.TxtSt4Num2)
        Me.GroupBox7.Controls.Add(Me.TxtSt4Num1)
        Me.GroupBox7.Controls.Add(Me.LblStartNumber3)
        Me.GroupBox7.Controls.Add(Me.TxtSt3Num4)
        Me.GroupBox7.Controls.Add(Me.TxtSt3Num3)
        Me.GroupBox7.Controls.Add(Me.TxtSt3Num2)
        Me.GroupBox7.Controls.Add(Me.TxtSt3Num1)
        Me.GroupBox7.Controls.Add(Me.LblStartNumber2)
        Me.GroupBox7.Controls.Add(Me.TxtSt2Num4)
        Me.GroupBox7.Controls.Add(Me.TxtSt2Num3)
        Me.GroupBox7.Controls.Add(Me.TxtSt2Num2)
        Me.GroupBox7.Controls.Add(Me.TxtSt2Num1)
        Me.GroupBox7.Controls.Add(Me.LblStartNumber1)
        Me.GroupBox7.Controls.Add(Me.TxtSt1Num4)
        Me.GroupBox7.Controls.Add(Me.Label11)
        Me.GroupBox7.Controls.Add(Me.TxtSt1Num3)
        Me.GroupBox7.Controls.Add(Me.Label10)
        Me.GroupBox7.Controls.Add(Me.TxtSt1Num2)
        Me.GroupBox7.Controls.Add(Me.Label9)
        Me.GroupBox7.Controls.Add(Me.TxtSt1Num1)
        Me.GroupBox7.Controls.Add(Me.Label8)
        Me.GroupBox7.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox7.Location = New System.Drawing.Point(689, 305)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(620, 232)
        Me.GroupBox7.TabIndex = 71
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "引受番号のスタート番号"
        '
        'LblStartNumber3
        '
        Me.LblStartNumber3.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblStartNumber3.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblStartNumber3.ForeColor = System.Drawing.Color.Black
        Me.LblStartNumber3.Location = New System.Drawing.Point(31, 138)
        Me.LblStartNumber3.Name = "LblStartNumber3"
        Me.LblStartNumber3.Size = New System.Drawing.Size(226, 35)
        Me.LblStartNumber3.TabIndex = 208
        Me.LblStartNumber3.Text = "150：ゆうメール"
        Me.LblStartNumber3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtSt3Num4
        '
        Me.TxtSt3Num4.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TxtSt3Num4.Location = New System.Drawing.Point(492, 136)
        Me.TxtSt3Num4.MaxLength = 1
        Me.TxtSt3Num4.Name = "TxtSt3Num4"
        Me.TxtSt3Num4.Size = New System.Drawing.Size(34, 39)
        Me.TxtSt3Num4.TabIndex = 212
        Me.TxtSt3Num4.Text = "4"
        Me.TxtSt3Num4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtSt3Num3
        '
        Me.TxtSt3Num3.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TxtSt3Num3.Location = New System.Drawing.Point(396, 136)
        Me.TxtSt3Num3.MaxLength = 5
        Me.TxtSt3Num3.Name = "TxtSt3Num3"
        Me.TxtSt3Num3.Size = New System.Drawing.Size(90, 39)
        Me.TxtSt3Num3.TabIndex = 211
        Me.TxtSt3Num3.Text = "10000"
        Me.TxtSt3Num3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtSt3Num2
        '
        Me.TxtSt3Num2.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TxtSt3Num2.Location = New System.Drawing.Point(339, 136)
        Me.TxtSt3Num2.MaxLength = 2
        Me.TxtSt3Num2.Name = "TxtSt3Num2"
        Me.TxtSt3Num2.Size = New System.Drawing.Size(51, 39)
        Me.TxtSt3Num2.TabIndex = 210
        Me.TxtSt3Num2.Text = "78"
        Me.TxtSt3Num2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtSt3Num1
        '
        Me.TxtSt3Num1.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TxtSt3Num1.Location = New System.Drawing.Point(263, 136)
        Me.TxtSt3Num1.MaxLength = 3
        Me.TxtSt3Num1.Name = "TxtSt3Num1"
        Me.TxtSt3Num1.Size = New System.Drawing.Size(70, 39)
        Me.TxtSt3Num1.TabIndex = 209
        Me.TxtSt3Num1.Text = "150"
        Me.TxtSt3Num1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LblStartNumber2
        '
        Me.LblStartNumber2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblStartNumber2.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblStartNumber2.ForeColor = System.Drawing.Color.Black
        Me.LblStartNumber2.Location = New System.Drawing.Point(32, 95)
        Me.LblStartNumber2.Name = "LblStartNumber2"
        Me.LblStartNumber2.Size = New System.Drawing.Size(226, 35)
        Me.LblStartNumber2.TabIndex = 203
        Me.LblStartNumber2.Text = "050：特定記録"
        Me.LblStartNumber2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtSt2Num4
        '
        Me.TxtSt2Num4.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TxtSt2Num4.Location = New System.Drawing.Point(493, 93)
        Me.TxtSt2Num4.MaxLength = 1
        Me.TxtSt2Num4.Name = "TxtSt2Num4"
        Me.TxtSt2Num4.Size = New System.Drawing.Size(34, 39)
        Me.TxtSt2Num4.TabIndex = 207
        Me.TxtSt2Num4.Text = "2"
        Me.TxtSt2Num4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtSt2Num3
        '
        Me.TxtSt2Num3.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TxtSt2Num3.Location = New System.Drawing.Point(397, 93)
        Me.TxtSt2Num3.MaxLength = 5
        Me.TxtSt2Num3.Name = "TxtSt2Num3"
        Me.TxtSt2Num3.Size = New System.Drawing.Size(90, 39)
        Me.TxtSt2Num3.TabIndex = 206
        Me.TxtSt2Num3.Text = "10000"
        Me.TxtSt2Num3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtSt2Num2
        '
        Me.TxtSt2Num2.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TxtSt2Num2.Location = New System.Drawing.Point(340, 93)
        Me.TxtSt2Num2.MaxLength = 2
        Me.TxtSt2Num2.Name = "TxtSt2Num2"
        Me.TxtSt2Num2.Size = New System.Drawing.Size(51, 39)
        Me.TxtSt2Num2.TabIndex = 205
        Me.TxtSt2Num2.Text = "34"
        Me.TxtSt2Num2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtSt2Num1
        '
        Me.TxtSt2Num1.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TxtSt2Num1.Location = New System.Drawing.Point(264, 93)
        Me.TxtSt2Num1.MaxLength = 3
        Me.TxtSt2Num1.Name = "TxtSt2Num1"
        Me.TxtSt2Num1.Size = New System.Drawing.Size(70, 39)
        Me.TxtSt2Num1.TabIndex = 204
        Me.TxtSt2Num1.Text = "050"
        Me.TxtSt2Num1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'BtnSave
        '
        Me.BtnSave.Font = New System.Drawing.Font("メイリオ", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnSave.Image = Global.RecordedDelivery.My.Resources.Resources.save_icon
        Me.BtnSave.Location = New System.Drawing.Point(822, 935)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(337, 70)
        Me.BtnSave.TabIndex = 72
        Me.BtnSave.Text = "保存"
        Me.BtnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Controls.Add(Me.TxtUserNo)
        Me.GroupBox4.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(689, 108)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(180, 91)
        Me.GroupBox4.TabIndex = 73
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "ユーザー番号"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label2.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(15, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 48)
        Me.Label2.TabIndex = 70
        Me.Label2.Text = "設定値"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtUserNo
        '
        Me.TxtUserNo.Font = New System.Drawing.Font("メイリオ", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TxtUserNo.Location = New System.Drawing.Point(93, 34)
        Me.TxtUserNo.MaxLength = 3
        Me.TxtUserNo.Name = "TxtUserNo"
        Me.TxtUserNo.Size = New System.Drawing.Size(74, 48)
        Me.TxtUserNo.TabIndex = 69
        Me.TxtUserNo.Text = "123"
        Me.TxtUserNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.Label15)
        Me.GroupBox8.Controls.Add(Me.TxtTrigerTime)
        Me.GroupBox8.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox8.Location = New System.Drawing.Point(1616, 332)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(251, 91)
        Me.GroupBox8.TabIndex = 74
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "トリガータイム(msec)"
        Me.GroupBox8.Visible = False
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label15.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(15, 33)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(78, 48)
        Me.Label15.TabIndex = 70
        Me.Label15.Text = "設定値"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtTrigerTime
        '
        Me.TxtTrigerTime.Font = New System.Drawing.Font("メイリオ", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TxtTrigerTime.Location = New System.Drawing.Point(114, 33)
        Me.TxtTrigerTime.MaxLength = 8
        Me.TxtTrigerTime.Name = "TxtTrigerTime"
        Me.TxtTrigerTime.Size = New System.Drawing.Size(98, 48)
        Me.TxtTrigerTime.TabIndex = 69
        Me.TxtTrigerTime.Text = "500"
        Me.TxtTrigerTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.BtnRefImage)
        Me.GroupBox9.Controls.Add(Me.BtnRefTran)
        Me.GroupBox9.Controls.Add(Me.Label17)
        Me.GroupBox9.Controls.Add(Me.TxtImageLog)
        Me.GroupBox9.Controls.Add(Me.Label16)
        Me.GroupBox9.Controls.Add(Me.TxtTranLog)
        Me.GroupBox9.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox9.Location = New System.Drawing.Point(689, 765)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(1178, 160)
        Me.GroupBox9.TabIndex = 75
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "ログ保存フォルダ"
        '
        'BtnRefImage
        '
        Me.BtnRefImage.Font = New System.Drawing.Font("メイリオ", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnRefImage.Image = CType(resources.GetObject("BtnRefImage.Image"), System.Drawing.Image)
        Me.BtnRefImage.Location = New System.Drawing.Point(1030, 85)
        Me.BtnRefImage.Name = "BtnRefImage"
        Me.BtnRefImage.Size = New System.Drawing.Size(125, 48)
        Me.BtnRefImage.TabIndex = 77
        Me.BtnRefImage.Text = "参照"
        Me.BtnRefImage.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnRefImage.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnRefImage.UseVisualStyleBackColor = True
        '
        'BtnRefTran
        '
        Me.BtnRefTran.Font = New System.Drawing.Font("メイリオ", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnRefTran.Image = CType(resources.GetObject("BtnRefTran.Image"), System.Drawing.Image)
        Me.BtnRefTran.Location = New System.Drawing.Point(1030, 30)
        Me.BtnRefTran.Name = "BtnRefTran"
        Me.BtnRefTran.Size = New System.Drawing.Size(125, 48)
        Me.BtnRefTran.TabIndex = 76
        Me.BtnRefTran.Text = "参照"
        Me.BtnRefTran.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnRefTran.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnRefTran.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label17.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(33, 89)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(141, 47)
        Me.Label17.TabIndex = 72
        Me.Label17.Text = "画像ログ"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtImageLog
        '
        Me.TxtImageLog.Font = New System.Drawing.Font("メイリオ", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TxtImageLog.Location = New System.Drawing.Point(176, 88)
        Me.TxtImageLog.MaxLength = 0
        Me.TxtImageLog.Name = "TxtImageLog"
        Me.TxtImageLog.Size = New System.Drawing.Size(836, 48)
        Me.TxtImageLog.TabIndex = 71
        Me.TxtImageLog.Text = "TxtImageLog"
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label16.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(33, 34)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(141, 47)
        Me.Label16.TabIndex = 70
        Me.Label16.Text = "稼働ログ"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtTranLog
        '
        Me.TxtTranLog.Font = New System.Drawing.Font("メイリオ", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TxtTranLog.Location = New System.Drawing.Point(176, 33)
        Me.TxtTranLog.MaxLength = 0
        Me.TxtTranLog.Name = "TxtTranLog"
        Me.TxtTranLog.Size = New System.Drawing.Size(836, 48)
        Me.TxtTranLog.TabIndex = 69
        Me.TxtTranLog.Text = "TxtTranLog"
        '
        'GroupBox10
        '
        Me.GroupBox10.Controls.Add(Me.Label18)
        Me.GroupBox10.Controls.Add(Me.TxtPassUsePeriod)
        Me.GroupBox10.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox10.Location = New System.Drawing.Point(878, 109)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(230, 91)
        Me.GroupBox10.TabIndex = 76
        Me.GroupBox10.TabStop = False
        Me.GroupBox10.Text = "ﾊﾟｽﾜｰﾄﾞ有効期間（日）"
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label18.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(14, 33)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(78, 48)
        Me.Label18.TabIndex = 70
        Me.Label18.Text = "設定値"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtPassUsePeriod
        '
        Me.TxtPassUsePeriod.Font = New System.Drawing.Font("メイリオ", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TxtPassUsePeriod.Location = New System.Drawing.Point(92, 33)
        Me.TxtPassUsePeriod.MaxLength = 3
        Me.TxtPassUsePeriod.Name = "TxtPassUsePeriod"
        Me.TxtPassUsePeriod.Size = New System.Drawing.Size(94, 48)
        Me.TxtPassUsePeriod.TabIndex = 69
        Me.TxtPassUsePeriod.Text = "999"
        Me.TxtPassUsePeriod.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ChkHidden
        '
        Me.ChkHidden.AutoSize = True
        Me.ChkHidden.Location = New System.Drawing.Point(888, 1010)
        Me.ChkHidden.Name = "ChkHidden"
        Me.ChkHidden.Size = New System.Drawing.Size(202, 32)
        Me.ChkHidden.TabIndex = 77
        Me.ChkHidden.Text = "隠しフォルダとする"
        Me.ChkHidden.UseVisualStyleBackColor = True
        Me.ChkHidden.Visible = False
        '
        'LblDecrypt
        '
        Me.LblDecrypt.Font = New System.Drawing.Font("メイリオ", 9.75!, CType((System.Drawing.FontStyle.Italic Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblDecrypt.ForeColor = System.Drawing.Color.Red
        Me.LblDecrypt.Location = New System.Drawing.Point(1657, 1006)
        Me.LblDecrypt.Name = "LblDecrypt"
        Me.LblDecrypt.Size = New System.Drawing.Size(161, 25)
        Me.LblDecrypt.TabIndex = 78
        Me.LblDecrypt.Text = "Operator.encの復号化"
        Me.LblDecrypt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox11
        '
        Me.GroupBox11.Controls.Add(Me.Label20)
        Me.GroupBox11.Controls.Add(Me.TxtMachineName)
        Me.GroupBox11.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox11.Location = New System.Drawing.Point(689, 203)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.Size = New System.Drawing.Size(243, 91)
        Me.GroupBox11.TabIndex = 79
        Me.GroupBox11.TabStop = False
        Me.GroupBox11.Text = "号機名"
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label20.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Black
        Me.Label20.Location = New System.Drawing.Point(14, 32)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(78, 48)
        Me.Label20.TabIndex = 70
        Me.Label20.Text = "設定値"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtMachineName
        '
        Me.TxtMachineName.Font = New System.Drawing.Font("メイリオ", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TxtMachineName.Location = New System.Drawing.Point(92, 32)
        Me.TxtMachineName.MaxLength = 5
        Me.TxtMachineName.Name = "TxtMachineName"
        Me.TxtMachineName.Size = New System.Drawing.Size(140, 48)
        Me.TxtMachineName.TabIndex = 69
        Me.TxtMachineName.Text = "１２３４５"
        Me.TxtMachineName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtName
        '
        Me.TxtName.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TxtName.Location = New System.Drawing.Point(109, 118)
        Me.TxtName.MaxLength = 999
        Me.TxtName.Name = "TxtName"
        Me.TxtName.Size = New System.Drawing.Size(657, 36)
        Me.TxtName.TabIndex = 84
        Me.TxtName.Text = "TxtName"
        '
        'TxtAddress2
        '
        Me.TxtAddress2.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TxtAddress2.Location = New System.Drawing.Point(109, 75)
        Me.TxtAddress2.MaxLength = 999
        Me.TxtAddress2.Name = "TxtAddress2"
        Me.TxtAddress2.Size = New System.Drawing.Size(657, 36)
        Me.TxtAddress2.TabIndex = 83
        Me.TxtAddress2.Text = "TxtAddress2"
        '
        'TxtAddress1
        '
        Me.TxtAddress1.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TxtAddress1.Location = New System.Drawing.Point(109, 34)
        Me.TxtAddress1.MaxLength = 999
        Me.TxtAddress1.Name = "TxtAddress1"
        Me.TxtAddress1.Size = New System.Drawing.Size(657, 36)
        Me.TxtAddress1.TabIndex = 82
        Me.TxtAddress1.Text = "TxtAddress1"
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label21.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Black
        Me.Label21.Location = New System.Drawing.Point(15, 34)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(93, 36)
        Me.Label21.TabIndex = 80
        Me.Label21.Text = "住所"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label22.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.Black
        Me.Label22.Location = New System.Drawing.Point(15, 118)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(93, 36)
        Me.Label22.TabIndex = 81
        Me.Label22.Text = "氏名"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox12
        '
        Me.GroupBox12.Controls.Add(Me.Label21)
        Me.GroupBox12.Controls.Add(Me.TxtName)
        Me.GroupBox12.Controls.Add(Me.Label22)
        Me.GroupBox12.Controls.Add(Me.TxtAddress2)
        Me.GroupBox12.Controls.Add(Me.TxtAddress1)
        Me.GroupBox12.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox12.Location = New System.Drawing.Point(1119, 109)
        Me.GroupBox12.Name = "GroupBox12"
        Me.GroupBox12.Size = New System.Drawing.Size(778, 172)
        Me.GroupBox12.TabIndex = 85
        Me.GroupBox12.TabStop = False
        Me.GroupBox12.Text = "差出人住所と氏名"
        '
        'BtnProcessListOutPut
        '
        Me.BtnProcessListOutPut.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnProcessListOutPut.Location = New System.Drawing.Point(1632, 453)
        Me.BtnProcessListOutPut.Name = "BtnProcessListOutPut"
        Me.BtnProcessListOutPut.Size = New System.Drawing.Size(196, 48)
        Me.BtnProcessListOutPut.TabIndex = 86
        Me.BtnProcessListOutPut.Text = "プロセス一覧出力"
        Me.BtnProcessListOutPut.UseVisualStyleBackColor = True
        '
        'LblStartNumber4
        '
        Me.LblStartNumber4.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblStartNumber4.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblStartNumber4.ForeColor = System.Drawing.Color.Black
        Me.LblStartNumber4.Location = New System.Drawing.Point(31, 182)
        Me.LblStartNumber4.Name = "LblStartNumber4"
        Me.LblStartNumber4.Size = New System.Drawing.Size(226, 35)
        Me.LblStartNumber4.TabIndex = 213
        Me.LblStartNumber4.Text = "070：書留"
        Me.LblStartNumber4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtSt4Num4
        '
        Me.TxtSt4Num4.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TxtSt4Num4.Location = New System.Drawing.Point(492, 180)
        Me.TxtSt4Num4.MaxLength = 1
        Me.TxtSt4Num4.Name = "TxtSt4Num4"
        Me.TxtSt4Num4.Size = New System.Drawing.Size(34, 39)
        Me.TxtSt4Num4.TabIndex = 217
        Me.TxtSt4Num4.Text = "1"
        Me.TxtSt4Num4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtSt4Num3
        '
        Me.TxtSt4Num3.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TxtSt4Num3.Location = New System.Drawing.Point(396, 180)
        Me.TxtSt4Num3.MaxLength = 5
        Me.TxtSt4Num3.Name = "TxtSt4Num3"
        Me.TxtSt4Num3.Size = New System.Drawing.Size(90, 39)
        Me.TxtSt4Num3.TabIndex = 216
        Me.TxtSt4Num3.Text = "10000"
        Me.TxtSt4Num3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtSt4Num2
        '
        Me.TxtSt4Num2.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TxtSt4Num2.Location = New System.Drawing.Point(339, 180)
        Me.TxtSt4Num2.MaxLength = 2
        Me.TxtSt4Num2.Name = "TxtSt4Num2"
        Me.TxtSt4Num2.Size = New System.Drawing.Size(51, 39)
        Me.TxtSt4Num2.TabIndex = 215
        Me.TxtSt4Num2.Text = "56"
        Me.TxtSt4Num2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtSt4Num1
        '
        Me.TxtSt4Num1.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TxtSt4Num1.Location = New System.Drawing.Point(263, 180)
        Me.TxtSt4Num1.MaxLength = 3
        Me.TxtSt4Num1.Name = "TxtSt4Num1"
        Me.TxtSt4Num1.Size = New System.Drawing.Size(70, 39)
        Me.TxtSt4Num1.TabIndex = 214
        Me.TxtSt4Num1.Text = "070"
        Me.TxtSt4Num1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'MaintenanceForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 28.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1916, 1053)
        Me.ControlBox = False
        Me.Controls.Add(Me.BtnProcessListOutPut)
        Me.Controls.Add(Me.GroupBox12)
        Me.Controls.Add(Me.GroupBox11)
        Me.Controls.Add(Me.LblDecrypt)
        Me.Controls.Add(Me.ChkHidden)
        Me.Controls.Add(Me.GroupBox10)
        Me.Controls.Add(Me.GroupBox9)
        Me.Controls.Add(Me.GroupBox8)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.lblVersion)
        Me.Controls.Add(Me.LblOperatorName)
        Me.Controls.Add(Me.BtnBack)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.RcvTextBox)
        Me.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Margin = New System.Windows.Forms.Padding(6, 7, 6, 7)
        Me.Name = "MaintenanceForm"
        Me.Text = "メンテナンス画面"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox13.ResumeLayout(False)
        Me.GroupBox13.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
        Me.GroupBox10.ResumeLayout(False)
        Me.GroupBox10.PerformLayout()
        Me.GroupBox11.ResumeLayout(False)
        Me.GroupBox11.PerformLayout()
        Me.GroupBox12.ResumeLayout(False)
        Me.GroupBox12.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SerialPort As System.IO.Ports.SerialPort
    Friend WithEvents RcvTextBox As System.Windows.Forms.TextBox
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnBack As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnSetValue As System.Windows.Forms.Button
    Friend WithEvents RadioButton8 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton7 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton6 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton5 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton4 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtVersion As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents LblInput1 As System.Windows.Forms.Label
    Friend WithEvents txtInput1 As System.Windows.Forms.TextBox
    Friend WithEvents LblOperatorName As System.Windows.Forms.Label
    Friend WithEvents lblVersion As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtKuwake As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtFooter2 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtFooter1 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtHeader2 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtHeader1 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxtSt1Num4 As System.Windows.Forms.TextBox
    Friend WithEvents TxtSt1Num3 As System.Windows.Forms.TextBox
    Friend WithEvents TxtSt1Num2 As System.Windows.Forms.TextBox
    Friend WithEvents TxtSt1Num1 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents LblStartNumber1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents LblStartNumber3 As System.Windows.Forms.Label
    Friend WithEvents TxtSt3Num4 As System.Windows.Forms.TextBox
    Friend WithEvents TxtSt3Num3 As System.Windows.Forms.TextBox
    Friend WithEvents TxtSt3Num2 As System.Windows.Forms.TextBox
    Friend WithEvents TxtSt3Num1 As System.Windows.Forms.TextBox
    Friend WithEvents LblStartNumber2 As System.Windows.Forms.Label
    Friend WithEvents TxtSt2Num4 As System.Windows.Forms.TextBox
    Friend WithEvents TxtSt2Num3 As System.Windows.Forms.TextBox
    Friend WithEvents TxtSt2Num2 As System.Windows.Forms.TextBox
    Friend WithEvents TxtSt2Num1 As System.Windows.Forms.TextBox
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtUserNo As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TxtTrigerTime As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents TxtImageLog As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents TxtTranLog As System.Windows.Forms.TextBox
    Friend WithEvents BtnRefImage As System.Windows.Forms.Button
    Friend WithEvents BtnRefTran As System.Windows.Forms.Button
    Friend WithEvents GroupBox10 As System.Windows.Forms.GroupBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents TxtPassUsePeriod As System.Windows.Forms.TextBox
    Friend WithEvents ChkHidden As System.Windows.Forms.CheckBox
    Friend WithEvents LblDecrypt As System.Windows.Forms.Label
    Friend WithEvents GroupBox11 As System.Windows.Forms.GroupBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents TxtMachineName As System.Windows.Forms.TextBox
    Friend WithEvents TxtName As System.Windows.Forms.TextBox
    Friend WithEvents TxtAddress2 As System.Windows.Forms.TextBox
    Friend WithEvents TxtAddress1 As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents GroupBox12 As System.Windows.Forms.GroupBox
    Friend WithEvents LblInput8 As System.Windows.Forms.Label
    Friend WithEvents txtInput8 As System.Windows.Forms.TextBox
    Friend WithEvents LblInput7 As System.Windows.Forms.Label
    Friend WithEvents txtInput7 As System.Windows.Forms.TextBox
    Friend WithEvents LblInput6 As System.Windows.Forms.Label
    Friend WithEvents txtInput6 As System.Windows.Forms.TextBox
    Friend WithEvents LblInput5 As System.Windows.Forms.Label
    Friend WithEvents txtInput5 As System.Windows.Forms.TextBox
    Friend WithEvents LblInput4 As System.Windows.Forms.Label
    Friend WithEvents txtInput4 As System.Windows.Forms.TextBox
    Friend WithEvents LblInput3 As System.Windows.Forms.Label
    Friend WithEvents txtInput3 As System.Windows.Forms.TextBox
    Friend WithEvents LblInput2 As System.Windows.Forms.Label
    Friend WithEvents txtInput2 As System.Windows.Forms.TextBox
    Friend WithEvents LblInputB As System.Windows.Forms.Label
    Friend WithEvents txtInputB As System.Windows.Forms.TextBox
    Friend WithEvents LblInputA As System.Windows.Forms.Label
    Friend WithEvents txtInputA As System.Windows.Forms.TextBox
    Friend WithEvents LblInput9 As System.Windows.Forms.Label
    Friend WithEvents txtInput9 As System.Windows.Forms.TextBox
    Friend WithEvents LblInputC As System.Windows.Forms.Label
    Friend WithEvents txtInputC As System.Windows.Forms.TextBox
    Friend WithEvents TxtBarCode As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox13 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnProcessListOutPut As Button
    Friend WithEvents LblStartNumber4 As Label
    Friend WithEvents TxtSt4Num4 As TextBox
    Friend WithEvents TxtSt4Num3 As TextBox
    Friend WithEvents TxtSt4Num2 As TextBox
    Friend WithEvents TxtSt4Num1 As TextBox
End Class
