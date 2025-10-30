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
        Me.SerialPort = New System.IO.Ports.SerialPort(Me.components)
        Me.BtnEnd = New System.Windows.Forms.Button()
        Me.BtnCmdA = New System.Windows.Forms.Button()
        Me.LstRecvData = New System.Windows.Forms.ListBox()
        Me.LstSendData = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TimRunning = New System.Windows.Forms.Timer(Me.components)
        Me.BtnCmdT = New System.Windows.Forms.Button()
        Me.BtnCmdP = New System.Windows.Forms.Button()
        Me.BtnCmdD = New System.Windows.Forms.Button()
        Me.TxtHikiukeNum = New System.Windows.Forms.TextBox()
        Me.BtnCmdE = New System.Windows.Forms.Button()
        Me.CmbErrorList = New System.Windows.Forms.ComboBox()
        Me.BtnCmdN = New System.Windows.Forms.Button()
        Me.CmbStatusList = New System.Windows.Forms.ComboBox()
        Me.BtnCmdS = New System.Windows.Forms.Button()
        Me.BtnCmdR = New System.Windows.Forms.Button()
        Me.BtnCmdC = New System.Windows.Forms.Button()
        Me.BtnCmdW = New System.Windows.Forms.Button()
        Me.TxtWeight = New System.Windows.Forms.TextBox()
        Me.BtnCmdM = New System.Windows.Forms.Button()
        Me.BtnCmdL = New System.Windows.Forms.Button()
        Me.TxtLR4820Rve2 = New System.Windows.Forms.TextBox()
        Me.BtnCmdB = New System.Windows.Forms.Button()
        Me.BtnRenzoku = New System.Windows.Forms.Button()
        Me.TimRenzoku = New System.Windows.Forms.Timer(Me.components)
        Me.TxtM1C = New System.Windows.Forms.TextBox()
        Me.BtnCmdM1C = New System.Windows.Forms.Button()
        Me.CmbM1C = New System.Windows.Forms.ComboBox()
        Me.TxtTakWeight = New System.Windows.Forms.TextBox()
        Me.BtnTakWeight = New System.Windows.Forms.Button()
        Me.BtnWeightMode = New System.Windows.Forms.Button()
        Me.BtnADPmode = New System.Windows.Forms.Button()
        Me.TimWeight = New System.Windows.Forms.Timer(Me.components)
        Me.BtnWeightRenzoku = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'SerialPort
        '
        Me.SerialPort.ReadTimeout = 3000
        Me.SerialPort.WriteTimeout = 3000
        '
        'BtnEnd
        '
        Me.BtnEnd.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.BtnEnd.Font = New System.Drawing.Font("メイリオ", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnEnd.Location = New System.Drawing.Point(218, 394)
        Me.BtnEnd.Name = "BtnEnd"
        Me.BtnEnd.Size = New System.Drawing.Size(181, 69)
        Me.BtnEnd.TabIndex = 0
        Me.BtnEnd.Text = "終了"
        Me.BtnEnd.UseVisualStyleBackColor = True
        '
        'BtnCmdA
        '
        Me.BtnCmdA.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.BtnCmdA.Font = New System.Drawing.Font("メイリオ", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnCmdA.Location = New System.Drawing.Point(19, 12)
        Me.BtnCmdA.Name = "BtnCmdA"
        Me.BtnCmdA.Size = New System.Drawing.Size(181, 40)
        Me.BtnCmdA.TabIndex = 1
        Me.BtnCmdA.Text = "「A」コマンド"
        Me.BtnCmdA.UseVisualStyleBackColor = True
        '
        'LstRecvData
        '
        Me.LstRecvData.Font = New System.Drawing.Font("メイリオ", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LstRecvData.FormattingEnabled = True
        Me.LstRecvData.ItemHeight = 21
        Me.LstRecvData.Location = New System.Drawing.Point(405, 39)
        Me.LstRecvData.Name = "LstRecvData"
        Me.LstRecvData.Size = New System.Drawing.Size(853, 340)
        Me.LstRecvData.TabIndex = 4
        '
        'LstSendData
        '
        Me.LstSendData.Font = New System.Drawing.Font("メイリオ", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LstSendData.FormattingEnabled = True
        Me.LstSendData.ItemHeight = 21
        Me.LstSendData.Location = New System.Drawing.Point(405, 412)
        Me.LstSendData.Name = "LstSendData"
        Me.LstSendData.Size = New System.Drawing.Size(853, 340)
        Me.LstSendData.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(405, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(853, 27)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "受信データ"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(405, 385)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(853, 27)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "送信データ"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TimRunning
        '
        '
        'BtnCmdT
        '
        Me.BtnCmdT.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.BtnCmdT.Font = New System.Drawing.Font("メイリオ", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnCmdT.Location = New System.Drawing.Point(19, 59)
        Me.BtnCmdT.Name = "BtnCmdT"
        Me.BtnCmdT.Size = New System.Drawing.Size(181, 40)
        Me.BtnCmdT.TabIndex = 16
        Me.BtnCmdT.Text = "「T」コマンド"
        Me.BtnCmdT.UseVisualStyleBackColor = True
        '
        'BtnCmdP
        '
        Me.BtnCmdP.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.BtnCmdP.Font = New System.Drawing.Font("メイリオ", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnCmdP.Location = New System.Drawing.Point(19, 104)
        Me.BtnCmdP.Name = "BtnCmdP"
        Me.BtnCmdP.Size = New System.Drawing.Size(181, 40)
        Me.BtnCmdP.TabIndex = 17
        Me.BtnCmdP.Text = "「P」コマンド"
        Me.BtnCmdP.UseVisualStyleBackColor = True
        '
        'BtnCmdD
        '
        Me.BtnCmdD.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.BtnCmdD.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.BtnCmdD.Font = New System.Drawing.Font("メイリオ", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnCmdD.Location = New System.Drawing.Point(216, 59)
        Me.BtnCmdD.Name = "BtnCmdD"
        Me.BtnCmdD.Size = New System.Drawing.Size(181, 38)
        Me.BtnCmdD.TabIndex = 18
        Me.BtnCmdD.Text = "「D」コマンド"
        Me.BtnCmdD.UseVisualStyleBackColor = False
        '
        'TxtHikiukeNum
        '
        Me.TxtHikiukeNum.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TxtHikiukeNum.Location = New System.Drawing.Point(217, 96)
        Me.TxtHikiukeNum.MaxLength = 11
        Me.TxtHikiukeNum.Name = "TxtHikiukeNum"
        Me.TxtHikiukeNum.Size = New System.Drawing.Size(179, 31)
        Me.TxtHikiukeNum.TabIndex = 19
        Me.TxtHikiukeNum.Text = "12345678901"
        Me.TxtHikiukeNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'BtnCmdE
        '
        Me.BtnCmdE.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.BtnCmdE.Font = New System.Drawing.Font("メイリオ", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnCmdE.Location = New System.Drawing.Point(18, 728)
        Me.BtnCmdE.Name = "BtnCmdE"
        Me.BtnCmdE.Size = New System.Drawing.Size(181, 38)
        Me.BtnCmdE.TabIndex = 20
        Me.BtnCmdE.Text = "「E」コマンド"
        Me.BtnCmdE.UseVisualStyleBackColor = True
        '
        'CmbErrorList
        '
        Me.CmbErrorList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbErrorList.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CmbErrorList.ForeColor = System.Drawing.Color.Red
        Me.CmbErrorList.FormattingEnabled = True
        Me.CmbErrorList.Location = New System.Drawing.Point(19, 765)
        Me.CmbErrorList.Name = "CmbErrorList"
        Me.CmbErrorList.Size = New System.Drawing.Size(566, 32)
        Me.CmbErrorList.TabIndex = 21
        '
        'BtnCmdN
        '
        Me.BtnCmdN.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.BtnCmdN.Font = New System.Drawing.Font("メイリオ", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnCmdN.Location = New System.Drawing.Point(20, 150)
        Me.BtnCmdN.Name = "BtnCmdN"
        Me.BtnCmdN.Size = New System.Drawing.Size(181, 38)
        Me.BtnCmdN.TabIndex = 22
        Me.BtnCmdN.Text = "「N」コマンド"
        Me.BtnCmdN.UseVisualStyleBackColor = True
        '
        'CmbStatusList
        '
        Me.CmbStatusList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbStatusList.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CmbStatusList.ForeColor = System.Drawing.Color.Red
        Me.CmbStatusList.FormattingEnabled = True
        Me.CmbStatusList.Location = New System.Drawing.Point(21, 187)
        Me.CmbStatusList.Name = "CmbStatusList"
        Me.CmbStatusList.Size = New System.Drawing.Size(178, 32)
        Me.CmbStatusList.TabIndex = 23
        '
        'BtnCmdS
        '
        Me.BtnCmdS.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.BtnCmdS.Font = New System.Drawing.Font("メイリオ", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnCmdS.Location = New System.Drawing.Point(21, 300)
        Me.BtnCmdS.Name = "BtnCmdS"
        Me.BtnCmdS.Size = New System.Drawing.Size(181, 38)
        Me.BtnCmdS.TabIndex = 24
        Me.BtnCmdS.Text = "「S」コマンド"
        Me.BtnCmdS.UseVisualStyleBackColor = True
        '
        'BtnCmdR
        '
        Me.BtnCmdR.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.BtnCmdR.Font = New System.Drawing.Font("メイリオ", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnCmdR.Location = New System.Drawing.Point(21, 341)
        Me.BtnCmdR.Name = "BtnCmdR"
        Me.BtnCmdR.Size = New System.Drawing.Size(181, 38)
        Me.BtnCmdR.TabIndex = 25
        Me.BtnCmdR.Text = "「R」コマンド"
        Me.BtnCmdR.UseVisualStyleBackColor = True
        '
        'BtnCmdC
        '
        Me.BtnCmdC.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.BtnCmdC.Font = New System.Drawing.Font("メイリオ", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnCmdC.Location = New System.Drawing.Point(217, 133)
        Me.BtnCmdC.Name = "BtnCmdC"
        Me.BtnCmdC.Size = New System.Drawing.Size(181, 38)
        Me.BtnCmdC.TabIndex = 26
        Me.BtnCmdC.Text = "「C」コマンド"
        Me.BtnCmdC.UseVisualStyleBackColor = True
        '
        'BtnCmdW
        '
        Me.BtnCmdW.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.BtnCmdW.Font = New System.Drawing.Font("メイリオ", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnCmdW.Location = New System.Drawing.Point(217, 177)
        Me.BtnCmdW.Name = "BtnCmdW"
        Me.BtnCmdW.Size = New System.Drawing.Size(181, 38)
        Me.BtnCmdW.TabIndex = 27
        Me.BtnCmdW.Text = "「W」コマンド"
        Me.BtnCmdW.UseVisualStyleBackColor = True
        '
        'TxtWeight
        '
        Me.TxtWeight.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TxtWeight.Location = New System.Drawing.Point(218, 214)
        Me.TxtWeight.MaxLength = 5
        Me.TxtWeight.Name = "TxtWeight"
        Me.TxtWeight.Size = New System.Drawing.Size(179, 31)
        Me.TxtWeight.TabIndex = 28
        Me.TxtWeight.Text = "12345"
        Me.TxtWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'BtnCmdM
        '
        Me.BtnCmdM.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.BtnCmdM.Font = New System.Drawing.Font("メイリオ", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnCmdM.Location = New System.Drawing.Point(20, 394)
        Me.BtnCmdM.Name = "BtnCmdM"
        Me.BtnCmdM.Size = New System.Drawing.Size(181, 38)
        Me.BtnCmdM.TabIndex = 29
        Me.BtnCmdM.Text = "「M0」コマンド"
        Me.BtnCmdM.UseVisualStyleBackColor = True
        '
        'BtnCmdL
        '
        Me.BtnCmdL.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.BtnCmdL.Font = New System.Drawing.Font("メイリオ", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnCmdL.Location = New System.Drawing.Point(21, 438)
        Me.BtnCmdL.Name = "BtnCmdL"
        Me.BtnCmdL.Size = New System.Drawing.Size(181, 38)
        Me.BtnCmdL.TabIndex = 30
        Me.BtnCmdL.Text = "「L」コマンド"
        Me.BtnCmdL.UseVisualStyleBackColor = True
        '
        'TxtLR4820Rve2
        '
        Me.TxtLR4820Rve2.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TxtLR4820Rve2.Location = New System.Drawing.Point(21, 475)
        Me.TxtLR4820Rve2.MaxLength = 5
        Me.TxtLR4820Rve2.Name = "TxtLR4820Rve2"
        Me.TxtLR4820Rve2.Size = New System.Drawing.Size(179, 31)
        Me.TxtLR4820Rve2.TabIndex = 31
        Me.TxtLR4820Rve2.Text = "12345"
        Me.TxtLR4820Rve2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'BtnCmdB
        '
        Me.BtnCmdB.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.BtnCmdB.Font = New System.Drawing.Font("メイリオ", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnCmdB.Location = New System.Drawing.Point(216, 13)
        Me.BtnCmdB.Name = "BtnCmdB"
        Me.BtnCmdB.Size = New System.Drawing.Size(181, 40)
        Me.BtnCmdB.TabIndex = 32
        Me.BtnCmdB.Text = "「B」コマンド"
        Me.BtnCmdB.UseVisualStyleBackColor = True
        '
        'BtnRenzoku
        '
        Me.BtnRenzoku.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.BtnRenzoku.Font = New System.Drawing.Font("メイリオ", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnRenzoku.Location = New System.Drawing.Point(218, 300)
        Me.BtnRenzoku.Name = "BtnRenzoku"
        Me.BtnRenzoku.Size = New System.Drawing.Size(181, 79)
        Me.BtnRenzoku.TabIndex = 33
        Me.BtnRenzoku.Text = "連続処理"
        Me.BtnRenzoku.UseVisualStyleBackColor = True
        '
        'TimRenzoku
        '
        '
        'TxtM1C
        '
        Me.TxtM1C.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TxtM1C.Location = New System.Drawing.Point(21, 560)
        Me.TxtM1C.MaxLength = 8
        Me.TxtM1C.Name = "TxtM1C"
        Me.TxtM1C.Size = New System.Drawing.Size(179, 31)
        Me.TxtM1C.TabIndex = 35
        Me.TxtM1C.Text = "12345678"
        Me.TxtM1C.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'BtnCmdM1C
        '
        Me.BtnCmdM1C.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.BtnCmdM1C.Font = New System.Drawing.Font("メイリオ", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnCmdM1C.Location = New System.Drawing.Point(21, 523)
        Me.BtnCmdM1C.Name = "BtnCmdM1C"
        Me.BtnCmdM1C.Size = New System.Drawing.Size(181, 38)
        Me.BtnCmdM1C.TabIndex = 34
        Me.BtnCmdM1C.Text = "「M1」コマンド"
        Me.BtnCmdM1C.UseVisualStyleBackColor = True
        '
        'CmbM1C
        '
        Me.CmbM1C.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbM1C.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CmbM1C.FormattingEnabled = True
        Me.CmbM1C.Location = New System.Drawing.Point(202, 523)
        Me.CmbM1C.Name = "CmbM1C"
        Me.CmbM1C.Size = New System.Drawing.Size(60, 39)
        Me.CmbM1C.TabIndex = 36
        '
        'TxtTakWeight
        '
        Me.TxtTakWeight.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TxtTakWeight.Location = New System.Drawing.Point(19, 659)
        Me.TxtTakWeight.MaxLength = 20
        Me.TxtTakWeight.Name = "TxtTakWeight"
        Me.TxtTakWeight.Size = New System.Drawing.Size(179, 31)
        Me.TxtTakWeight.TabIndex = 38
        Me.TxtTakWeight.Text = "000023.4 G S"
        Me.TxtTakWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'BtnTakWeight
        '
        Me.BtnTakWeight.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.BtnTakWeight.Font = New System.Drawing.Font("メイリオ", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnTakWeight.Location = New System.Drawing.Point(19, 622)
        Me.BtnTakWeight.Name = "BtnTakWeight"
        Me.BtnTakWeight.Size = New System.Drawing.Size(181, 38)
        Me.BtnTakWeight.TabIndex = 37
        Me.BtnTakWeight.Text = "「+」卓上ｺﾏﾝﾄﾞ"
        Me.BtnTakWeight.UseVisualStyleBackColor = True
        '
        'BtnWeightMode
        '
        Me.BtnWeightMode.Location = New System.Drawing.Point(206, 622)
        Me.BtnWeightMode.Name = "BtnWeightMode"
        Me.BtnWeightMode.Size = New System.Drawing.Size(152, 38)
        Me.BtnWeightMode.TabIndex = 39
        Me.BtnWeightMode.Text = "重量計通信変更"
        Me.BtnWeightMode.UseVisualStyleBackColor = True
        '
        'BtnADPmode
        '
        Me.BtnADPmode.Location = New System.Drawing.Point(206, 666)
        Me.BtnADPmode.Name = "BtnADPmode"
        Me.BtnADPmode.Size = New System.Drawing.Size(152, 38)
        Me.BtnADPmode.TabIndex = 40
        Me.BtnADPmode.Text = "大型機通信変更"
        Me.BtnADPmode.UseVisualStyleBackColor = True
        '
        'BtnWeightRenzoku
        '
        Me.BtnWeightRenzoku.Location = New System.Drawing.Point(206, 578)
        Me.BtnWeightRenzoku.Name = "BtnWeightRenzoku"
        Me.BtnWeightRenzoku.Size = New System.Drawing.Size(152, 38)
        Me.BtnWeightRenzoku.TabIndex = 41
        Me.BtnWeightRenzoku.Text = "重量連続送信"
        Me.BtnWeightRenzoku.UseVisualStyleBackColor = True
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 24.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDark
        Me.ClientSize = New System.Drawing.Size(1270, 817)
        Me.Controls.Add(Me.BtnWeightRenzoku)
        Me.Controls.Add(Me.BtnADPmode)
        Me.Controls.Add(Me.BtnWeightMode)
        Me.Controls.Add(Me.TxtTakWeight)
        Me.Controls.Add(Me.BtnTakWeight)
        Me.Controls.Add(Me.CmbM1C)
        Me.Controls.Add(Me.TxtM1C)
        Me.Controls.Add(Me.BtnCmdM1C)
        Me.Controls.Add(Me.BtnRenzoku)
        Me.Controls.Add(Me.BtnCmdB)
        Me.Controls.Add(Me.TxtLR4820Rve2)
        Me.Controls.Add(Me.BtnCmdL)
        Me.Controls.Add(Me.BtnCmdM)
        Me.Controls.Add(Me.TxtWeight)
        Me.Controls.Add(Me.BtnCmdW)
        Me.Controls.Add(Me.BtnCmdC)
        Me.Controls.Add(Me.BtnCmdR)
        Me.Controls.Add(Me.BtnCmdS)
        Me.Controls.Add(Me.CmbStatusList)
        Me.Controls.Add(Me.BtnCmdN)
        Me.Controls.Add(Me.CmbErrorList)
        Me.Controls.Add(Me.BtnCmdE)
        Me.Controls.Add(Me.TxtHikiukeNum)
        Me.Controls.Add(Me.BtnCmdD)
        Me.Controls.Add(Me.BtnCmdP)
        Me.Controls.Add(Me.BtnCmdT)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LstSendData)
        Me.Controls.Add(Me.LstRecvData)
        Me.Controls.Add(Me.BtnCmdA)
        Me.Controls.Add(Me.BtnEnd)
        Me.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ADPシミュレータ"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SerialPort As System.IO.Ports.SerialPort
    Friend WithEvents BtnEnd As System.Windows.Forms.Button
    Friend WithEvents BtnCmdA As System.Windows.Forms.Button
    Friend WithEvents LstRecvData As System.Windows.Forms.ListBox
    Friend WithEvents LstSendData As System.Windows.Forms.ListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TimRunning As System.Windows.Forms.Timer
    Friend WithEvents BtnCmdT As System.Windows.Forms.Button
    Friend WithEvents BtnCmdP As System.Windows.Forms.Button
    Friend WithEvents BtnCmdD As System.Windows.Forms.Button
    Friend WithEvents TxtHikiukeNum As System.Windows.Forms.TextBox
    Friend WithEvents BtnCmdE As System.Windows.Forms.Button
    Friend WithEvents CmbErrorList As System.Windows.Forms.ComboBox
    Friend WithEvents BtnCmdN As System.Windows.Forms.Button
    Friend WithEvents CmbStatusList As System.Windows.Forms.ComboBox
    Friend WithEvents BtnCmdS As System.Windows.Forms.Button
    Friend WithEvents BtnCmdR As System.Windows.Forms.Button
    Friend WithEvents BtnCmdC As System.Windows.Forms.Button
    Friend WithEvents BtnCmdW As System.Windows.Forms.Button
    Friend WithEvents TxtWeight As System.Windows.Forms.TextBox
    Friend WithEvents BtnCmdM As System.Windows.Forms.Button
    Friend WithEvents BtnCmdL As System.Windows.Forms.Button
    Friend WithEvents TxtLR4820Rve2 As System.Windows.Forms.TextBox
    Friend WithEvents BtnCmdB As System.Windows.Forms.Button
    Friend WithEvents BtnRenzoku As System.Windows.Forms.Button
    Friend WithEvents TimRenzoku As System.Windows.Forms.Timer
    Friend WithEvents TxtM1C As System.Windows.Forms.TextBox
    Friend WithEvents BtnCmdM1C As System.Windows.Forms.Button
    Friend WithEvents CmbM1C As System.Windows.Forms.ComboBox
    Friend WithEvents TxtTakWeight As System.Windows.Forms.TextBox
    Friend WithEvents BtnTakWeight As System.Windows.Forms.Button
    Friend WithEvents BtnWeightMode As System.Windows.Forms.Button
    Friend WithEvents BtnADPmode As System.Windows.Forms.Button
    Friend WithEvents TimWeight As System.Windows.Forms.Timer
    Friend WithEvents BtnWeightRenzoku As System.Windows.Forms.Button

End Class
