Option Explicit On
Option Strict On
Imports System.IO

Public Class MaintenanceForm

    'Public rcvBufferData As String      ' 受信バッファ
    '----------------------------------------------------------

    Private Delegate Sub Delegate_RcvDataToTextBox(ByVal data As String)

    ''' <summary>
    ''' フォームアクティブ処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub maintenanceForm_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated

        ' オペレータ情報の表示
        LblOperatorName.Text = GetOperatorInfomation()

    End Sub


    ''' <summary>
    ''' フォームロード処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub maintenanceForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim strArray() As String
        Dim strSubArray() As String

        Try
            lblVersion.Text = PubConstClass.DEF_VERSION

            TxtUserNo.Text = PubConstClass.userNumber
            TxtPassUsePeriod.Text = PubConstClass.passUsePeriod
            TxtKuwake.Text = PubConstClass.pblKuwakeCnt
            TxtTrigerTime.Text = PubConstClass.trigerTime
            TxtTranLog.Text = PubConstClass.tranPath
            TxtImageLog.Text = PubConstClass.imgPath
            TxtHeader1.Text = PubConstClass.pblHeder1Page
            TxtHeader2.Text = PubConstClass.pblHeder2Page
            TxtFooter1.Text = PubConstClass.pblFooter1
            TxtFooter2.Text = PubConstClass.pblFooter2
            TxtMachineName.Text = PubConstClass.pblMachineName
            TxtAddress1.Text = PubConstClass.pblSenderAddress1
            TxtAddress2.Text = PubConstClass.pblSenderAddress2
            TxtName.Text = PubConstClass.pblSenderName

            ' 030：簡易書留（スタート番号）
            strArray = PubConstClass.strCurrentNumber(0).Split(","c)
            strSubArray = strArray(1).Split("-"c)
            TxtSt1Num1.Text = strSubArray(0)
            TxtSt1Num2.Text = strSubArray(1)
            TxtSt1Num3.Text = strSubArray(2)
            TxtSt1Num4.Text = strSubArray(3)
            ' 050：特定記録（スタート番号）
            strArray = PubConstClass.strCurrentNumber(1).Split(","c)
            strSubArray = strArray(1).Split("-"c)
            TxtSt2Num1.Text = strSubArray(0)
            TxtSt2Num2.Text = strSubArray(1)
            TxtSt2Num3.Text = strSubArray(2)
            TxtSt2Num4.Text = strSubArray(3)
            ' 150：ゆうメール（スタート番号）
            strArray = PubConstClass.strCurrentNumber(2).Split(","c)
            strSubArray = strArray(1).Split("-"c)
            TxtSt3Num1.Text = strSubArray(0)
            TxtSt3Num2.Text = strSubArray(1)
            TxtSt3Num3.Text = strSubArray(2)
            TxtSt3Num4.Text = strSubArray(3)
            ' 070：書留（スタート番号）
            strArray = PubConstClass.strCurrentNumber(3).Split(","c)
            strSubArray = strArray(1).Split("-"c)
            TxtSt4Num1.Text = strSubArray(0)
            TxtSt4Num2.Text = strSubArray(1)
            TxtSt4Num3.Text = strSubArray(2)
            TxtSt4Num4.Text = strSubArray(3)

            txtVersion.Text = ""
            txtInput1.Text = ""
            txtInput2.Text = ""
            txtInput3.Text = ""
            txtInput4.Text = ""
            txtInput5.Text = ""
            txtInput6.Text = ""
            txtInput7.Text = ""
            txtInput8.Text = ""
            txtInput9.Text = ""
            txtInputA.Text = ""
            txtInputB.Text = ""
            txtInputC.Text = ""
            TxtBarCode.Text = ""

            ' シリアルポートのオープン
            SerialPort.PortName = "COM1"
            ' シリアルポートの通信速度指定
            SerialPort.BaudRate = 38400
            ' シリアルポートのパリティ指定
            SerialPort.Parity = IO.Ports.Parity.Even
            ' シリアルポートのビット数指定
            SerialPort.DataBits = 8
            ' シリアルポートのストップビット指定
            SerialPort.StopBits = IO.Ports.StopBits.One
            ' シリアルポートのオープン
            SerialPort.Open()

            ' メンテナンスモードコマンド（Zm1）送信
            Dim dat As Byte() = System.Text.Encoding.GetEncoding("SHIFT-JIS").GetBytes(PubConstClass.CMD_SEND_m & "1" & vbCr)
            SerialPort.Write(dat, 0, dat.GetLength(0))

            ' 出力表示の文言の設定
            Dim strReadDataPath As String

            strReadDataPath = My.Application.Info.DirectoryPath & "\maintenance.ini"

            Dim sr As New System.IO.StreamReader(strReadDataPath, System.Text.Encoding.Default)

            Dim intDispPosition As Integer
            intDispPosition = 1
            'ファイルの最後までループ
            Do Until sr.Peek = -1
                'strArray = sr.ReadLine.Split(","c)
                Select Case intDispPosition
                    Case 1
                        LblInput1.Text = sr.ReadLine
                    Case 2
                        LblInput2.Text = sr.ReadLine
                    Case 3
                        LblInput3.Text = sr.ReadLine
                    Case 4
                        LblInput4.Text = sr.ReadLine
                    Case 5
                        LblInput5.Text = sr.ReadLine
                    Case 6
                        LblInput6.Text = sr.ReadLine
                    Case 7
                        LblInput7.Text = sr.ReadLine
                    Case 8
                        LblInput8.Text = sr.ReadLine
                    Case 9
                        LblInput9.Text = sr.ReadLine
                    Case 10
                        LblInputA.Text = sr.ReadLine
                    Case 11
                        LblInputB.Text = sr.ReadLine
                    Case 12
                        LblInputC.Text = sr.ReadLine

                    Case Else

                End Select
                intDispPosition = intDispPosition + 1

            Loop
            sr.Close()

            RcvTextBox.Text = ""

        Catch ex As Exception
            MsgBox("【maintenanceForm_Load】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 　シリアルポートからデータを受信する
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub SerialPort_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles SerialPort.DataReceived

        SyncLock (PubConstClass.objSyncRec)

            'シリアルポートをオープンしていない場合、処理を行わない。
            If SerialPort.IsOpen = False Then
                Return
            End If

            Try
                Dim strRecData As String
                Dim strChar As String

                strRecData = SerialPort.ReadExisting
                For N = 0 To strRecData.Length - 1

                    strChar = strRecData.Substring(N, 1)
                    If strChar = vbCr Then

                        If PubConstClass.strRecData = "" Then
                            Call OutPutLogFile("■受信（<CR>のみ）")
                        Else
                            Call OutPutLogFile("■受信：" & PubConstClass.strRecData & "<CR>")
                            BeginInvoke(New Delegate_RcvDataToTextBox(AddressOf Me.RcvDataToTextBox), PubConstClass.strRecData)

                            PubConstClass.strRecData = ""

                        End If
                    Else
                        PubConstClass.strRecData &= strChar
                    End If
                Next

            Catch ex As TimeoutException
                ' 受信タイムアウトの処理（受信バッファをクリア）
                Dim strDiscardData As String = SerialPort.ReadExisting()
                ' ディスカードするデータ
                Call OutPutLogFile("■データ受信タイムアウトエラー：<CR>未受信で切り捨てたデータ：" & strDiscardData)
                BeginInvoke(New Delegate_RcvDataToTextBox(AddressOf Me.RcvDataToTextBox), "ZE999" & ControlChars.Cr)

            Catch ex As Exception
                MsgBox("【SerialPort_DataReceived】" & ex.Message)
            End Try

        End SyncLock

    End Sub

    ''' <summary>
    ''' 受信データをテキストボックスに書き込む。
    ''' </summary>
    ''' <param name="data">受信した文字列</param>
    ''' <remarks></remarks>
    Private Sub RcvDataToTextBox(ByVal data As String)

        Try
            '受信データをテキストボックスの最後に追記する。
            If IsNothing(data) = False Then

                If data.Length > 2 Then
                    Select Case data.Substring(0, 2)
                        Case "ZD"
                            TxtBarCode.Text = data.Substring(2, data.Length - 2)
                        Case Else
                    End Select
                End If

                If data.Length > 3 Then

                    Select Case data.Substring(0, 3)

                        Case "ZM0"
                            txtVersion.Text = data.Substring(4, data.Length - 4)
                            RcvTextBox.Text = "バージョン情報コマンド（" & data & "）受信"

                        Case "ZM1"
                            txtInput1.Text = data.Substring(4, data.Length - 4)
                        Case "ZM2"
                            txtInput2.Text = data.Substring(4, data.Length - 4)
                        Case "ZM3"
                            txtInput3.Text = data.Substring(4, data.Length - 4)
                        Case "ZM4"
                            txtInput4.Text = data.Substring(4, data.Length - 4)
                        Case "ZM5"
                            txtInput5.Text = data.Substring(4, data.Length - 4)
                        Case "ZM6"
                            txtInput6.Text = data.Substring(4, data.Length - 4)
                        Case "ZM7"
                            txtInput7.Text = data.Substring(4, data.Length - 4)
                        Case "ZM8"
                            txtInput8.Text = data.Substring(4, data.Length - 4)
                        Case "ZM9"
                            txtInput9.Text = data.Substring(4, data.Length - 4)
                        Case "ZMA"
                            txtInputA.Text = data.Substring(4, data.Length - 4)
                        Case "ZMB"
                            txtInputB.Text = data.Substring(4, data.Length - 4)
                        Case "ZMC"
                            txtInputC.Text = data.Substring(4, data.Length - 4)

                        Case Else
                            RcvTextBox.Text = "未定義コマンド（" & data & "）受信"

                    End Select

                Else
                    RcvTextBox.Text = "未定義コマンド（" & data & "）受信"
                End If

            End If

        Catch ex As Exception
            MsgBox("【RcvDataToTextBox】" & ex.Message)
        End Try

    End Sub


    Private Sub RadioButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton1.Click

        Call checkRadioButton()

    End Sub

    Private Sub checkRadioButton()

        If RadioButton1.Checked = True Then
            RadioButton1.BackColor = Color.FromArgb(192, 192, 255)
        Else
            RadioButton1.BackColor = Color.FromArgb(192, 255, 192)
        End If

        If RadioButton2.Checked = True Then
            RadioButton2.BackColor = Color.FromArgb(192, 192, 255)
        Else
            RadioButton2.BackColor = Color.FromArgb(192, 255, 192)
        End If

        If RadioButton3.Checked = True Then
            RadioButton3.BackColor = Color.FromArgb(192, 192, 255)
        Else
            RadioButton3.BackColor = Color.FromArgb(192, 255, 192)
        End If

        If RadioButton4.Checked = True Then
            RadioButton4.BackColor = Color.FromArgb(192, 192, 255)
        Else
            RadioButton4.BackColor = Color.FromArgb(192, 255, 192)
        End If

        If RadioButton5.Checked = True Then
            RadioButton5.BackColor = Color.FromArgb(192, 192, 255)
        Else
            RadioButton5.BackColor = Color.FromArgb(192, 255, 192)
        End If

        If RadioButton6.Checked = True Then
            RadioButton6.BackColor = Color.FromArgb(192, 192, 255)
        Else
            RadioButton6.BackColor = Color.FromArgb(192, 255, 192)
        End If

        If RadioButton7.Checked = True Then
            RadioButton7.BackColor = Color.FromArgb(192, 192, 255)
        Else
            RadioButton7.BackColor = Color.FromArgb(192, 255, 192)
        End If

        If RadioButton7.Checked = True Then
            RadioButton7.BackColor = Color.FromArgb(192, 192, 255)
        Else
            RadioButton7.BackColor = Color.FromArgb(192, 255, 192)
        End If

        If RadioButton8.Checked = True Then
            RadioButton8.BackColor = Color.FromArgb(192, 192, 255)
        Else
            RadioButton8.BackColor = Color.FromArgb(192, 255, 192)
        End If

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnSetValue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetValue.Click

        Dim strPutData As String
        strPutData = "Zm"

        If RadioButton1.Checked = True Then
            strPutData = strPutData & "1"
        Else
            strPutData = strPutData & "0"
        End If

        If RadioButton2.Checked = True Then
            strPutData = strPutData & "1"
        Else
            strPutData = strPutData & "0"
        End If

        If RadioButton3.Checked = True Then
            strPutData = strPutData & "1"
        Else
            strPutData = strPutData & "0"
        End If

        If RadioButton4.Checked = True Then
            strPutData = strPutData & "1"
        Else
            strPutData = strPutData & "0"
        End If

        If RadioButton5.Checked = True Then
            strPutData = strPutData & "1"
        Else
            strPutData = strPutData & "0"
        End If

        If RadioButton6.Checked = True Then
            strPutData = strPutData & "1"
        Else
            strPutData = strPutData & "0"
        End If

        If RadioButton7.Checked = True Then
            strPutData = strPutData & "1"
        Else
            strPutData = strPutData & "0"
        End If

        If RadioButton8.Checked = True Then
            strPutData = strPutData & "1"
        Else
            strPutData = strPutData & "0"
        End If

        ' シリアルポートにデータ送信（動作不可コマンド）
        Dim dat As Byte() = System.Text.Encoding.GetEncoding("SHIFT-JIS").GetBytes(strPutData & vbCr)

        SerialPort.Write(dat, 0, dat.GetLength(0))

        Call OutPutLogFile("★送信：" & strPutData)

    End Sub


    Private Sub RadioButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton2.Click

        Call checkRadioButton()

    End Sub

    Private Sub RadioButton3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton3.Click

        Call checkRadioButton()

    End Sub

    Private Sub RadioButton4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton4.Click

        Call checkRadioButton()

    End Sub

    Private Sub RadioButton5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton5.Click

        Call checkRadioButton()

    End Sub

    Private Sub RadioButton6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton6.Click

        Call checkRadioButton()

    End Sub

    Private Sub RadioButton7_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton7.Click

        Call checkRadioButton()

    End Sub

    Private Sub RadioButton8_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton8.Click

        Call checkRadioButton()

    End Sub


    ''' <summary>
    ''' 「戻る」ボタン処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBack.Click

        Try
            MsgBoxForm.strMessage = "メインメニューに戻りますか？"
            ' 確認メッセージの表示
            MsgBoxForm.ShowDialog()

            If MsgBoxForm.blnRetValMsgBox = True Then

                ' オペレータ情報ファイル(INI)の削除
                Dim strOperatorINIPath As String = IncludeTrailingPathDelimiter(Application.StartupPath) & PubConstClass.DEF_OPERATOR_FILE_NAME_INI
                System.IO.File.Delete(strOperatorINIPath)

                ' メンテナンスモードコマンド（Zm0）送信
                Dim dat As Byte() = System.Text.Encoding.GetEncoding("SHIFT-JIS").GetBytes(PubConstClass.CMD_SEND_m & "0" & vbCr)
                SerialPort.Write(dat, 0, dat.GetLength(0))

                ' シリアルポートのクローズ
                SerialPort.Close()

                ' メインメニュー画面の表示
                MainForm.Show()
                Me.Dispose()

            End If

        Catch ex As Exception
            MsgBox("【BtnBack_Click】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 「保存」ボタン処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click

        Dim strIniFilePath As String
        Dim strPutData As String
        Dim strCmpCD As String

        Try
            strCmpCD = (CDbl(TxtSt1Num1.Text & TxtSt1Num2.Text & TxtSt1Num3.Text) Mod 7).ToString("0"c)
            If TxtSt1Num4.Text <> strCmpCD Then
                'MsgBox("「030：簡易書留」のチェックデジットは「" & strCmpCD & "」です", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")
                MsgBox($"「{LblStartNumber1.Text}」のチェックデジットは「{strCmpCD}」です", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")
                Exit Sub
            End If

            strCmpCD = (CDbl(TxtSt2Num1.Text & TxtSt2Num2.Text & TxtSt2Num3.Text) Mod 7).ToString("0"c)
            If TxtSt2Num4.Text <> strCmpCD Then
                'MsgBox("「050：特定記録」のチェックデジットは「" & strCmpCD & "」です", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")
                MsgBox($"「{LblStartNumber2.Text}」のチェックデジットは「{strCmpCD}」です", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")
                Exit Sub
            End If

            strCmpCD = (CDbl(TxtSt3Num1.Text & TxtSt3Num2.Text & TxtSt3Num3.Text) Mod 7).ToString("0"c)
            If TxtSt3Num4.Text <> strCmpCD Then
                'MsgBox("「150：ゆうメール」のチェックデジットは「" & strCmpCD & "」です", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")
                MsgBox($"「{LblStartNumber3.Text}」のチェックデジットは「{strCmpCD}」です", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")
                Exit Sub
            End If

            strCmpCD = (CDbl(TxtSt4Num1.Text & TxtSt4Num2.Text & TxtSt4Num3.Text) Mod 7).ToString("0"c)
            If TxtSt4Num4.Text <> strCmpCD Then
                MsgBox($"「{LblStartNumber4.Text}」のチェックデジットは「{strCmpCD}」です", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")
                Exit Sub
            End If

            Dim varRetVal As MsgBoxResult = MsgBox("設定値を保存しますか？", CType(MsgBoxStyle.Question + MsgBoxStyle.OkCancel, MsgBoxStyle), "確認")
            If varRetVal = MsgBoxResult.Cancel Then
                Exit Sub
            End If

            strIniFilePath = IncludeTrailingPathDelimiter(Application.StartupPath) & PubConstClass.DEF_INI_FILENAME

            WritePrivateProfileString("System", "UserNo", TxtUserNo.Text, strIniFilePath)
            WritePrivateProfileString("System", "PasswordPeriod", TxtPassUsePeriod.Text, strIniFilePath)
            WritePrivateProfileString("System", "KuwakeCnt", TxtKuwake.Text, strIniFilePath)
            WritePrivateProfileString("System", "TrigerTime", TxtTrigerTime.Text, strIniFilePath)
            WritePrivateProfileString("System", "Header1Page", TxtHeader1.Text, strIniFilePath)
            WritePrivateProfileString("System", "Header2Page", TxtHeader2.Text, strIniFilePath)
            WritePrivateProfileString("System", "Footer1", TxtFooter1.Text, strIniFilePath)
            WritePrivateProfileString("System", "Footer2", TxtFooter2.Text, strIniFilePath)
            WritePrivateProfileString("System", "MachineName", TxtMachineName.Text, strIniFilePath)
            WritePrivateProfileString("System", "SenderAddress1", TxtAddress1.Text, strIniFilePath)
            WritePrivateProfileString("System", "SenderAddress2", TxtAddress2.Text, strIniFilePath)
            WritePrivateProfileString("System", "SenderName", TxtName.Text, strIniFilePath)

            WritePrivateProfileString("Folder", "TranSaveFolder", TxtTranLog.Text, strIniFilePath)
            WritePrivateProfileString("Folder", "ImageSaveFolder", TxtImageLog.Text, strIniFilePath)

            ' INIファイルの設定値を再取得する
            Call getSystemIniFile()

            ' 引受番号のスタート番号の格納
            strIniFilePath = IncludeTrailingPathDelimiter(Application.StartupPath) & PubConstClass.DEF_UNDER_WRITING_NUMBER

            strPutData = "スタート番号," & TxtSt1Num1.Text & "-" & TxtSt1Num2.Text & "-" & TxtSt1Num3.Text & "-" & TxtSt1Num4.Text
            WritePrivateProfileString("Class30", "CurrentNum", strPutData, strIniFilePath)
            strPutData = "スタート番号," & TxtSt2Num1.Text & "-" & TxtSt2Num2.Text & "-" & TxtSt2Num3.Text & "-" & TxtSt2Num4.Text
            WritePrivateProfileString("Class50", "CurrentNum", strPutData, strIniFilePath)
            strPutData = "スタート番号," & TxtSt3Num1.Text & "-" & TxtSt3Num2.Text & "-" & TxtSt3Num3.Text & "-" & TxtSt3Num4.Text
            WritePrivateProfileString("Class150", "CurrentNum", strPutData, strIniFilePath)

            strPutData = "スタート番号," & TxtSt4Num1.Text & "-" & TxtSt4Num2.Text & "-" & TxtSt4Num3.Text & "-" & TxtSt4Num4.Text
            WritePrivateProfileString("Class70", "CurrentNum", strPutData, strIniFilePath)

            ' 引受番号データの再取得
            Call GetUnderWritingNumber()

            ''ディレクトリの属性を取得する
            'Dim di As New System.IO.DirectoryInfo(TxtImageLog.Text)
            'Dim GodMode As New System.IO.DirectoryInfo("C:\RECDEL\GodMode.{21EC2020-3AEA-1069-A2DD-08002B30309D}")
            'If ChkHidden.Checked = True Then
            '    ' 隠し属性を追加する
            '    GodMode.Attributes = GodMode.Attributes Or System.IO.FileAttributes.Hidden
            '    ' システム属性を追加する
            '    GodMode.Attributes = GodMode.Attributes Or System.IO.FileAttributes.System
            '    ' 隠し属性を追加する
            '    di.Attributes = di.Attributes Or System.IO.FileAttributes.Hidden
            '    ' システム属性を追加する
            '    di.Attributes = di.Attributes Or System.IO.FileAttributes.System
            'Else
            '    ' 隠し属性を削除する
            '    di.Attributes = di.Attributes And Not System.IO.FileAttributes.Hidden
            '    ' システム属性を削除する
            '    di.Attributes = di.Attributes And Not System.IO.FileAttributes.System
            '    ' 隠し属性を削除する
            '    GodMode.Attributes = GodMode.Attributes And Not System.IO.FileAttributes.Hidden
            '    ' システム属性を削除する
            '    GodMode.Attributes = GodMode.Attributes And Not System.IO.FileAttributes.System
            'End If
            '' 隠し属性があるか調べる
            'If (di.Attributes And System.IO.FileAttributes.Hidden) = _
            '        System.IO.FileAttributes.Hidden Then
            '    MsgBox("隠し属性があります。")
            'Else
            '    MsgBox("隠し属性はありません。")
            'End If
            '' システム属性があるか調べる
            'If (di.Attributes And System.IO.FileAttributes.System) = _
            '        System.IO.FileAttributes.System Then
            '    MsgBox("システム属性があります。")
            'Else
            '    MsgBox("システム属性はありません。")
            'End If

        Catch ex As Exception
            MsgBox("【BtnSave_Click】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 「参照」ボタン処理（稼働ログ）
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnRefTran_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRefTran.Click

        Dim fbd As New FolderBrowserDialog

        Try
            fbd.Description = "稼働ログ格納フォルダを選択してください。"

            fbd.RootFolder = Environment.SpecialFolder.Desktop
            fbd.SelectedPath = PubConstClass.tranPath

            ' 新規フォルダ作成を表示
            fbd.ShowNewFolderButton = True

            If fbd.ShowDialog(Me) = DialogResult.OK Then
                ' 選択されたフォルダを表示する
                TxtTranLog.Text = fbd.SelectedPath
            End If

        Catch ex As Exception
            MsgBox("【BtnRefTran_Click】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 「参照」ボタン処理（画像ログ）
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnRefImage_Click(sender As System.Object, e As System.EventArgs) Handles BtnRefImage.Click

        Dim fbd As New FolderBrowserDialog

        Try
            fbd.Description = "画像ログ格納フォルダを選択してください。"

            fbd.RootFolder = Environment.SpecialFolder.Desktop
            fbd.SelectedPath = PubConstClass.imgPath

            ' 新規フォルダ作成を表示
            fbd.ShowNewFolderButton = True

            If fbd.ShowDialog(Me) = DialogResult.OK Then
                ' 選択されたフォルダを表示する
                TxtImageLog.Text = fbd.SelectedPath
            End If

        Catch ex As Exception
            MsgBox("【BtnRefImage_Click】" & ex.Message)
        End Try

    End Sub

    Private Sub LblDecrypt_Click(sender As System.Object, e As System.EventArgs) Handles LblDecrypt.Click
        '// LblDecrypt_DoubleClick 参照
    End Sub

    ''' <summary>
    ''' 「Operator.encの復号化」ラベルのダブルクリック処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub LblDecrypt_DoubleClick(sender As Object, e As System.EventArgs) Handles LblDecrypt.DoubleClick

        Try
            Dim strReadDataENCPath As String = IncludeTrailingPathDelimiter(Application.StartupPath) & PubConstClass.DEF_OPERATOR_FILE_NAME_ENC
            Dim strReadDataINIPath As String = IncludeTrailingPathDelimiter(Application.StartupPath) & PubConstClass.DEF_OPERATOR_FILE_NAME_INI
            ' 暗号化されたオペレータ情報ファイルを復号化する
            DecryptFile(strReadDataENCPath, strReadDataINIPath, PubConstClass.DEF_OPEN_KEY)

            MsgBox("オペレータ情報ファイル（Operator.enc）を復号化（Operator.ini）しました。", CType(MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, MsgBoxStyle), "【！！警告！！】")

        Catch ex As Exception
            MsgBox("【BtnSave_Click】" & ex.Message)
        End Try

    End Sub

    Private Sub TxtSt1Num1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtSt1Num1.TextChanged

    End Sub

    Private Sub TxtPassUsePeriod_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPassUsePeriod.KeyPress
        ' 数字のみ入力可能
        e.Handled = CheckKeyPress("1", e)
    End Sub

    Private Sub TxtPassUsePeriod_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtPassUsePeriod.TextChanged

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub BtnProcessListOutPut_Click(sender As Object, e As EventArgs) Handles BtnProcessListOutPut.Click

        Try
            ' ここで何らかの処理を行う（例：例外を発生させる）
            Throw New Exception("テスト例外")
        Catch ex As Exception
            Console.WriteLine("エラーが発生しました: " & ex.Message)
            DumpProcessesToFile("process_dump.txt")
        End Try

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="filePath"></param>
    Sub DumpProcessesToFile(filePath As String)
        Try
            Using writer As New StreamWriter(filePath)
                Dim processes() As Process = Process.GetProcesses()
                For Each proc As Process In processes
                    Try
                        writer.WriteLine($"PID: {proc.Id}, Name: {proc.ProcessName}, Memory: {proc.WorkingSet64 \ 1024} KB")
                    Catch
                        writer.WriteLine($"PID: {proc.Id}, Name: {proc.ProcessName}, Memory: アクセス不可")
                    End Try
                Next
            End Using

            Console.WriteLine("プロセス一覧をファイルに出力しました。")
        Catch e As Exception
            Console.WriteLine("ファイル出力中にエラーが発生しました: " & e.Message)
        End Try
    End Sub

End Class