Option Explicit On
Option Strict On

Public Class MainForm
    '--------------------------------------------------------------------------
    Private Delegate Sub Delegate_RcvDataToTextBox(ByVal data As String)

    ''' <summary>
    ''' メインフォームロード処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            PubConstClass.objSyncHist = New Object
            PubConstClass.objSyncSeri = New Object

            ' 操作ログの書き込み
            OutPutLogFile("〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓")
            OutPutLogFile("【" + Me.Text + "】プログラム起動")

            '二重起動のチェック
            If Diagnostics.Process.GetProcessesByName( _
                Diagnostics.Process.GetCurrentProcess.ProcessName).Length > 1 Then
                'すでに起動していると判断する
                OutPutLogFile("二重起動はできません。")
                MsgBox("二重起動はできません。", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")
                Me.Dispose()
            End If

            CmbM1C.Items.Clear()
            For N = 1 To 9
                CmbM1C.Items.Add(N.ToString("0"c))
            Next
            CmbM1C.Items.Add("A")
            CmbM1C.Items.Add("B")
            CmbM1C.Items.Add("C")
            CmbM1C.SelectedIndex = 0

            ' シリアルポートのオープン
            'SerialPort.PortName = "COM1"
            SerialPort.PortName = "COM2"
            ' シリアルポートの通信速度指定
            SerialPort.BaudRate = 38400
            'SerialPort.BaudRate = 19200
            ' シリアルポートのパリティ指定
            SerialPort.Parity = IO.Ports.Parity.Even
            ' シリアルポートのビット数指定
            SerialPort.DataBits = 8
            ' シリアルポートのストップビット指定
            SerialPort.StopBits = IO.Ports.StopBits.One

            SerialPort.Open()

            Dim strSendData As String
            strSendData = PubConstClass.CMD_SEND_C
            Dim dat As Byte() = System.Text.Encoding.GetEncoding("SHIFT-JIS").GetBytes(strSendData & vbCr)
            SerialPort.Write(dat, 0, dat.GetLength(0))
            ' 通信ログの保存
            LoggingSerialSendDAta(strSendData)

            CmbStatusList.Items.Clear()
            CmbStatusList.Items.Add("0:単独モード")
            CmbStatusList.Items.Add("1:待機中")
            CmbStatusList.Items.Add("2:運転中")
            CmbStatusList.Items.Add("3:エラー")
            CmbStatusList.SelectedIndex = 0

            ' 読込ファイル名の設定
            CmbErrorList.Items.Clear()
            Dim strReadDataFileName As String = IncludeTrailingPathDelimiter(Application.StartupPath) & PubConstClass.DEF_ERROR_FILENAME
            Using sr As New System.IO.StreamReader(strReadDataFileName, System.Text.Encoding.Default)
                Do While Not sr.EndOfStream
                    CmbErrorList.Items.Add(sr.ReadLine.ToString)
                Loop
                CmbErrorList.SelectedIndex = 0
            End Using

        Catch ex As Exception
            MsgBox("【MainForm_Load】" & ex.Message)
        End Try

    End Sub


    ''' <summary>
    ''' 受信コマンド解析
    ''' </summary>
    ''' <param name="data"></param>
    ''' <remarks></remarks>
    Private Sub RcvDataToTextBox(ByVal data As String)

        Dim strSendData As String

        Try
            '受信データをテキストボックスの最後に追記する。
            If IsNothing(data) = False Then

                If data.Length > 1 Then

                    Select Case data.Substring(0, 2)

                        Case PubConstClass.CMD_RECIEVE_a
                            LstRecvData.Items.Add("【" & Date.Now.ToString & "】「Za」受信")

                        Case PubConstClass.CMD_RECIEVE_b
                            LstRecvData.Items.Add("【" & Date.Now.ToString & "】「Zb」受信：" & data.Replace(vbCr, "<CR>"))

                        Case PubConstClass.CMD_RECIEVE_c
                            LstRecvData.Items.Add("【" & Date.Now.ToString & "】「Zc」受信")

                        Case PubConstClass.CMD_RECIEVE_d
                            LstRecvData.Items.Add("【" & Date.Now.ToString & "】「Zd」受信：" & data.Replace(vbCr, "<CR>"))

                        Case PubConstClass.CMD_RECIEVE_e
                            LstRecvData.Items.Add("【" & Date.Now.ToString & "】「Ze」受信")

                        Case PubConstClass.CMD_RECIEVE_f
                            LstRecvData.Items.Add("【" & Date.Now.ToString & "】「Zf」受信：" & data.Replace(vbCr, "<CR>"))

                        Case PubConstClass.CMD_RECIEVE_g
                            LstRecvData.Items.Add("【" & Date.Now.ToString & "】「Zg」受信")

                        Case PubConstClass.CMD_RECIEVE_h
                            LstRecvData.Items.Add("【" & Date.Now.ToString & "】「Zh」受信")

                        Case PubConstClass.CMD_RECIEVE_i
                            LstRecvData.Items.Add("【" & Date.Now.ToString & "】「Zi」受信" & data.Replace(vbCr, "<CR>"))

                        Case PubConstClass.CMD_RECIEVE_p
                            LstRecvData.Items.Add("【" & Date.Now.ToString & "】「Zi」受信")

                        Case PubConstClass.CMD_RECIEVE_o
                            LstRecvData.Items.Add("【" & Date.Now.ToString & "】「Zi」受信")

                        Case PubConstClass.CMD_RECIEVE_l
                            LstRecvData.Items.Add("【" & Date.Now.ToString & "】" & data.Replace(vbCr, ""))
                            LstRecvData.SelectedIndex = LstRecvData.Items.Count - 1

                            If data.Length > 19 Then
                                'TxtHikiukeNum.Text = data.Substring(data.Length - 16, 11)
                                TxtHikiukeNum.Text = data.Substring(data.Length - 19, 14).Replace("-", "")
                                TxtHikiukeNum.Refresh()

                                strSendData = PubConstClass.CMD_SEND_L & Chr(6)
                                Dim dat As Byte() = System.Text.Encoding.GetEncoding("SHIFT-JIS").GetBytes(strSendData & vbCr)
                                SerialPort.Write(dat, 0, dat.GetLength(0))
                                LstSendData.Items.Add("【" & Date.Now.ToString & "】" & strSendData)
                                LstSendData.SelectedIndex = LstSendData.Items.Count - 1
                                ' 通信ログの保存
                                LoggingSerialSendDAta(strSendData)
                            End If

                        Case Else
                            LstRecvData.Items.Add("【" & Date.Now.ToString & "】未定義コマンド受信：" & data.Replace(vbCr, "<CR>"))

                    End Select
                    LstRecvData.SelectedIndex = LstRecvData.Items.Count - 1

                End If

            End If

        Catch ex As Exception
            MsgBox("【MainForm：RcvDataToTextBox】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 通信ログの保存処理（送信データ用）
    ''' </summary>
    ''' <param name="strWriteData"></param>
    ''' <remarks></remarks>
    Private Sub LoggingSerialSendDAta(ByVal strWriteData As String)

        Call OutPutLogFile("■送信：" & strWriteData & "<CR>")

    End Sub

    ''' <summary>
    ''' 通信ログの保存処理（受信データ用）
    ''' </summary>
    ''' <param name="strWriteData"></param>
    ''' <remarks></remarks>
    Private Sub LoggingSerialRecvDAta(ByVal strWriteData As String)

        Call OutPutLogFile("■受信：" & strWriteData & "<CR>")

    End Sub


    ''' <summary>
    ''' 「終了」ボタン
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnEnd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEnd.Click

        Dim retValResult As MsgBoxResult

        Try
            retValResult = MsgBox("終了しますか？", CType(MsgBoxStyle.Question + MsgBoxStyle.OkCancel, MsgBoxStyle), "確認")
            If retValResult = MsgBoxResult.Ok Then
                End
            End If
        Catch ex As Exception
            MsgBox("【BtnEnd_Click】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 「A」コマンド送信処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnCmdA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCmdA.Click

        Try
            Dim strSendData As String
            strSendData = PubConstClass.CMD_SEND_A
            Dim dat As Byte() = System.Text.Encoding.GetEncoding("SHIFT-JIS").GetBytes(strSendData & vbCr)
            SerialPort.Write(dat, 0, dat.GetLength(0))
            LstSendData.Items.Add("【" & Date.Now.ToString & "】" & strSendData)
            LstSendData.SelectedIndex = LstSendData.Items.Count - 1
            ' 通信ログの保存
            LoggingSerialSendDAta(strSendData)


        Catch ex As Exception
            MsgBox("【BtnCmdA_Click】" & ex.Message)
        End Try

    End Sub




    ''' <summary>
    ''' シリアルポートデータ受信処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub SerialPort_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles SerialPort.DataReceived

        'シリアルポートをオープンしていない場合、処理を行わない。
        If SerialPort.IsOpen = False Then
            Return
        End If

        Dim data As String
        Dim args(0) As Object
        data = ""

        Try

            '' <CR>まで読み込む
            'data = SerialPort.ReadTo(ControlChars.Cr)

            'If data.IndexOf("?") > 0 Then
            '    Call OutPutSerialLogFile("■受信（パリティエラー）：" & data.ToString & "<CR>")
            '    BeginInvoke(New Delegate_RcvDataToTextBox(AddressOf Me.RcvDataToTextBox), "パリティエラー：" & "data.ToString" & ControlChars.Cr)
            'End If

            'BeginInvoke(New Delegate_RcvDataToTextBox(AddressOf Me.RcvDataToTextBox), data.ToString & ControlChars.Cr)


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
            Call OutPutSerialLogFile("■データ受信タイムアウトエラー：<CR>未受信で切り捨てたデータ：" & strDiscardData)
            BeginInvoke(New Delegate_RcvDataToTextBox(AddressOf Me.RcvDataToTextBox), "ZE999" & ControlChars.Cr)
        Catch ex As Exception
            MsgBox("【SerialPort_DataReceived】" & ex.Message)
        End Try

    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TimRunning_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TimRunning.Tick

        Try
            Dim strSendData As String
            strSendData = PubConstClass.CMD_SEND_D & ","
            strSendData &= "1" & ","
            If Date.Now.ToString("ss") = "44" Then
                ' NG とする
                strSendData &= "1" & ","
            Else
                ' OK　とする
                strSendData &= "0" & ","
            End If

            strSendData &= Date.Now.ToString("yyMMddHHmmss") & "34567890123456789012345678901234567" & ","
            strSendData &= Date.Now.ToString("yyMMddHHmmss") & "34567890123456789012345678901234567"

            Dim dat As Byte() = System.Text.Encoding.GetEncoding("SHIFT-JIS").GetBytes(strSendData & vbCr)
            SerialPort.Write(dat, 0, dat.GetLength(0))
            ' 通信ログの保存
            LoggingSerialSendDAta(strSendData)
            LstSendData.Items.Add(strSendData)
            LstSendData.SelectedIndex = LstSendData.Items.Count - 1

            strSendData = PubConstClass.CMD_SEND_D & ","
            strSendData &= "2" & ","
            If Date.Now.ToString("ss") = "11" Then
                ' NG とする
                strSendData &= "1" & ","
            Else
                ' OK　とする
                strSendData &= "0" & ","
            End If

            strSendData &= Date.Now.ToString("yyMMddHHmmss") & "34567890123456789012345678901234567" & ","
            strSendData &= Date.Now.ToString("yyMMddHHmmss") & "34567890123456789012345678901234567"

            dat = System.Text.Encoding.GetEncoding("SHIFT-JIS").GetBytes(strSendData & vbCr)
            SerialPort.Write(dat, 0, dat.GetLength(0))
            ' 通信ログの保存
            LoggingSerialSendDAta(strSendData)
            LstSendData.SelectedIndex = LstSendData.Items.Count - 1

        Catch ex As Exception
            MsgBox("【TimRunning_Tick】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 「T」コマンド送信処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnCmdT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCmdT.Click

        Try
            Dim strSendData As String
            strSendData = PubConstClass.CMD_SEND_T
            Dim dat As Byte() = System.Text.Encoding.GetEncoding("SHIFT-JIS").GetBytes(strSendData & vbCr)
            SerialPort.Write(dat, 0, dat.GetLength(0))
            LstSendData.Items.Add("【" & Date.Now.ToString & "】" & strSendData)
            LstSendData.SelectedIndex = LstSendData.Items.Count - 1
            ' 通信ログの保存
            LoggingSerialSendDAta(strSendData)

        Catch ex As Exception
            MsgBox("【BtnCmdT_Click】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 「P」コマンド送信処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnCmdP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCmdP.Click

        Try
            Dim strSendData As String
            strSendData = PubConstClass.CMD_SEND_P
            Dim dat As Byte() = System.Text.Encoding.GetEncoding("SHIFT-JIS").GetBytes(strSendData & vbCr)
            SerialPort.Write(dat, 0, dat.GetLength(0))
            LstSendData.Items.Add("【" & Date.Now.ToString & "】" & strSendData)
            LstSendData.SelectedIndex = LstSendData.Items.Count - 1
            ' 通信ログの保存
            LoggingSerialSendDAta(strSendData)

        Catch ex As Exception
            MsgBox("【BtnCmdP_Click】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 「D」コマンド送信処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnCmdD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCmdD.Click

        Try
            Dim strSendData As String
            strSendData = PubConstClass.CMD_SEND_D & TxtHikiukeNum.Text
            Dim dat As Byte() = System.Text.Encoding.GetEncoding("SHIFT-JIS").GetBytes(strSendData & vbCr)
            SerialPort.Write(dat, 0, dat.GetLength(0))
            LstSendData.Items.Add("【" & Date.Now.ToString & "】" & strSendData)
            LstSendData.SelectedIndex = LstSendData.Items.Count - 1
            ' 通信ログの保存
            LoggingSerialSendDAta(strSendData)

        Catch ex As Exception
            MsgBox("【BtnCmdD_Click】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 「E」コマンド送信処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnCmdE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCmdE.Click

        Try
            Dim strSendData As String
            Dim strArray() As String
            strArray = CmbErrorList.Text.Split(","c)
            strSendData = PubConstClass.CMD_SEND_E & strArray(0)
            Dim dat As Byte() = System.Text.Encoding.GetEncoding("SHIFT-JIS").GetBytes(strSendData & vbCr)
            SerialPort.Write(dat, 0, dat.GetLength(0))
            LstSendData.Items.Add("【" & Date.Now.ToString & "】" & strSendData)
            LstSendData.SelectedIndex = LstSendData.Items.Count - 1
            ' 通信ログの保存
            LoggingSerialSendDAta(strSendData)

        Catch ex As Exception
            MsgBox("【BtnCmdE_Click】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 「N」コマンド送信処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnCmdN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCmdN.Click

        Try
            Dim strSendData As String
            Dim strArray() As String
            strArray = CmbStatusList.Text.Split(":"c)
            strSendData = PubConstClass.CMD_SEND_N & strArray(0)
            Dim dat As Byte() = System.Text.Encoding.GetEncoding("SHIFT-JIS").GetBytes(strSendData & vbCr)
            SerialPort.Write(dat, 0, dat.GetLength(0))
            LstSendData.Items.Add("【" & Date.Now.ToString & "】" & strSendData)
            LstSendData.SelectedIndex = LstSendData.Items.Count - 1
            ' 通信ログの保存
            LoggingSerialSendDAta(strSendData)

        Catch ex As Exception
            MsgBox("【BtnCmdN_Click】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 「S」コマンド送信処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnCmdS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCmdS.Click

        Try
            Dim strSendData As String
            strSendData = PubConstClass.CMD_SEND_S
            Dim dat As Byte() = System.Text.Encoding.GetEncoding("SHIFT-JIS").GetBytes(strSendData & vbCr)
            SerialPort.Write(dat, 0, dat.GetLength(0))
            LstSendData.Items.Add("【" & Date.Now.ToString & "】" & strSendData)
            LstSendData.SelectedIndex = LstSendData.Items.Count - 1
            ' 通信ログの保存
            LoggingSerialSendDAta(strSendData)

        Catch ex As Exception
            MsgBox("【BtnCmdN_Click】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 「R」コマンド送信処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnCmdR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCmdR.Click

        Try
            Dim strSendData As String
            strSendData = PubConstClass.CMD_SEND_R
            Dim dat As Byte() = System.Text.Encoding.GetEncoding("SHIFT-JIS").GetBytes(strSendData & vbCr)
            SerialPort.Write(dat, 0, dat.GetLength(0))
            LstSendData.Items.Add("【" & Date.Now.ToString & "】" & strSendData)
            LstSendData.SelectedIndex = LstSendData.Items.Count - 1
            ' 通信ログの保存
            LoggingSerialSendDAta(strSendData)

        Catch ex As Exception
            MsgBox("【BtnCmdR_Click】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 「C」コマンド送信処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnCmdC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCmdC.Click

        Dim strWeight As String

        Try
            Dim strSendData As String
            strSendData = PubConstClass.CMD_SEND_C
            Dim dat As Byte() = System.Text.Encoding.GetEncoding("SHIFT-JIS").GetBytes(strSendData & vbCr)
            SerialPort.Write(dat, 0, dat.GetLength(0))
            LstSendData.Items.Add("【" & Date.Now.ToString & "】" & strSendData)
            LstSendData.SelectedIndex = LstSendData.Items.Count - 1
            ' 通信ログの保存
            LoggingSerialSendDAta(strSendData)

            strWeight = "00" & Date.Now.ToString("ss") & "0"
            TxtWeight.Text = strWeight

        Catch ex As Exception
            MsgBox("【BtnCmdC_Click】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 「W」コマンド送信処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnCmdW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCmdW.Click

        Try
            Dim strSendData As String
            strSendData = PubConstClass.CMD_SEND_W & TxtHikiukeNum.Text & "," & TxtWeight.Text
            Dim dat As Byte() = System.Text.Encoding.GetEncoding("SHIFT-JIS").GetBytes(strSendData & vbCr)
            SerialPort.Write(dat, 0, dat.GetLength(0))
            LstSendData.Items.Add("【" & Date.Now.ToString & "】" & strSendData)
            LstSendData.SelectedIndex = LstSendData.Items.Count - 1
            ' 通信ログの保存
            LoggingSerialSendDAta(strSendData)

        Catch ex As Exception
            MsgBox("【BtnCmdW_Click】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 「M」コマンド送信処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnCmdM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCmdM.Click

        Try
            Dim strSendData As String
            strSendData = PubConstClass.CMD_SEND_M & "0,Ver.A0123"
            Dim dat As Byte() = System.Text.Encoding.GetEncoding("SHIFT-JIS").GetBytes(strSendData & vbCr)
            SerialPort.Write(dat, 0, dat.GetLength(0))
            LstSendData.Items.Add("【" & Date.Now.ToString & "】" & strSendData)
            LstSendData.SelectedIndex = LstSendData.Items.Count - 1
            ' 通信ログの保存
            LoggingSerialSendDAta(strSendData)

        Catch ex As Exception
            MsgBox("【BtnCmdM_Click】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 「L」コマンド送信処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnCmdL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCmdL.Click

        Try
            Dim strSendData As String
            strSendData = PubConstClass.CMD_SEND_L & TxtLR4820Rve2.Text
            Dim dat As Byte() = System.Text.Encoding.GetEncoding("SHIFT-JIS").GetBytes(strSendData & vbCr)
            SerialPort.Write(dat, 0, dat.GetLength(0))
            LstSendData.Items.Add("【" & Date.Now.ToString & "】" & strSendData)
            LstSendData.SelectedIndex = LstSendData.Items.Count - 1
            ' 通信ログの保存
            LoggingSerialSendDAta(strSendData)

        Catch ex As Exception
            MsgBox("【BtnCmdL_Click】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 「Ｂ」コマンド送信処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnCmdB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCmdB.Click

        Try
            Dim strSendData As String
            strSendData = PubConstClass.CMD_SEND_B
            Dim dat As Byte() = System.Text.Encoding.GetEncoding("SHIFT-JIS").GetBytes(strSendData & vbCr)
            SerialPort.Write(dat, 0, dat.GetLength(0))
            LstSendData.Items.Add("【" & Date.Now.ToString & "】" & strSendData)
            LstSendData.SelectedIndex = LstSendData.Items.Count - 1
            ' 通信ログの保存
            LoggingSerialSendDAta(strSendData)

        Catch ex As Exception
            MsgBox("【BtnCmdB_Click】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 「連続処理」ボタン処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnRenzoku_Click(sender As System.Object, e As System.EventArgs) Handles BtnRenzoku.Click

        Try
            If BtnRenzoku.Text = "連続処理" Then
                BtnRenzoku.Text = "停止"
                blnIsStop = False
                TimRenzoku.Interval = 800
                TimRenzoku.Enabled = True
                intPhase = 1
            Else
                BtnRenzoku.Text = "連続処理"
                blnIsStop = True
            End If

        Catch ex As Exception
            MsgBox("【BtnRenzoku_Click】" & ex.Message)
        End Try

    End Sub

    Private blnIsStop As Boolean
    Private intPhase As Integer

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TimRenzoku_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TimRenzoku.Tick

        Try
            Select Case intPhase
                Case 1
                    BtnCmdB.PerformClick()
                    intPhase += 1
                Case 2
                    BtnCmdD.PerformClick()
                    intPhase += 1
                Case 3
                    BtnCmdC.PerformClick()
                    intPhase += 1
                Case 4
                    BtnCmdW.PerformClick()
                    intPhase = 1
                    If blnIsStop = True Then
                        TimRenzoku.Enabled = False
                    End If

            End Select

        Catch ex As Exception
            MsgBox("【TimRenzoku_Tick】" & ex.Message)
        End Try

    End Sub


    Private Sub BtnCmdM1C_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCmdM1C.Click

        Try
            Dim strSendData As String
            strSendData = PubConstClass.CMD_SEND_M & CmbM1C.Text & "," & TxtM1C.Text
            Dim dat As Byte() = System.Text.Encoding.GetEncoding("SHIFT-JIS").GetBytes(strSendData & vbCr)
            SerialPort.Write(dat, 0, dat.GetLength(0))
            LstSendData.Items.Add("【" & Date.Now.ToString & "】" & strSendData)
            LstSendData.SelectedIndex = LstSendData.Items.Count - 1
            ' 通信ログの保存
            LoggingSerialSendDAta(strSendData)

        Catch ex As Exception
            MsgBox("【BtnCmdB_Click】" & ex.Message)
        End Try

    End Sub

    Private Sub BtnTakWeight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTakWeight.Click

        Try
            Dim strSendData As String
            strSendData = "+" & TxtTakWeight.Text
            Dim dat As Byte() = System.Text.Encoding.GetEncoding("SHIFT-JIS").GetBytes(strSendData & vbCrLf)
            SerialPort.Write(dat, 0, dat.GetLength(0))
            LstSendData.Items.Add("【" & Date.Now.ToString & "】" & strSendData)
            LstSendData.SelectedIndex = LstSendData.Items.Count - 1
            ' 通信ログの保存
            LoggingSerialSendDAta(strSendData)

        Catch ex As Exception
            MsgBox("【BtnTakWeight_Click】" & ex.Message)
        End Try

    End Sub

    Private Sub BtnWeightMode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnWeightMode.Click

        Try
            If SerialPort.IsOpen = True Then
                SerialPort.Close()
            End If
            ' シリアルポートのオープン
            SerialPort.PortName = "COM2"
            ' シリアルポートの通信速度指定            
            SerialPort.BaudRate = 19200
            ' シリアルポートのパリティ指定
            SerialPort.Parity = IO.Ports.Parity.Even
            ' シリアルポートのビット数指定
            SerialPort.DataBits = 8
            ' シリアルポートのストップビット指定
            SerialPort.StopBits = IO.Ports.StopBits.One

            SerialPort.Open()

        Catch ex As Exception
            MsgBox("【BtnTakWeight_Click】" & ex.Message)
        End Try

    End Sub

    Private Sub BtnADPmode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnADPmode.Click

        Try
            If SerialPort.IsOpen = True Then
                SerialPort.Close()
            End If
            ' シリアルポートのオープン
            SerialPort.PortName = "COM2"
            ' シリアルポートの通信速度指定            
            SerialPort.BaudRate = 38400
            ' シリアルポートのパリティ指定
            SerialPort.Parity = IO.Ports.Parity.Even
            ' シリアルポートのビット数指定
            SerialPort.DataBits = 8
            ' シリアルポートのストップビット指定
            SerialPort.StopBits = IO.Ports.StopBits.One

            SerialPort.Open()

        Catch ex As Exception
            MsgBox("【BtnADPmode_Click】" & ex.Message)
        End Try

    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnWeightRenzoku_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnWeightRenzoku.Click

        Try
            If BtnWeightRenzoku.Text = "重量連続送信" Then
                BtnWeightRenzoku.Text = "連続送信停止"
                TimWeight.Interval = 3000
                TimWeight.Enabled = True
            Else
                BtnWeightRenzoku.Text = "重量連続送信"
                TimWeight.Enabled = False
            End If

        Catch ex As Exception
            MsgBox("【BtnWeightRenzoku_Click】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TimWeight_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TimWeight.Tick

        BtnTakWeight.PerformClick()

    End Sub

End Class
