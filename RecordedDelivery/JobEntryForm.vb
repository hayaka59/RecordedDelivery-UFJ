Option Explicit On
Option Strict On

Imports System.Runtime.InteropServices

Public Class JobEntryForm

    Private strCopyItem(13) As String

    '----------------------------------------------------------
    ' 非公開データ
    Private mGrp As IGraphBuilder           'IGraphBuilderインターフェース
    Private mSmp As ISampleGrabber          'ISampleGrabberインターフェース
    Private mFlt As IBaseFilter
    Private mPin As IPin
    Private mSelectedDeviceName As String
    '----------------------------------------------------------
    Private Delegate Sub Delegate_RcvDataToTextBox(ByVal data As String)

    '----------------------------------------------------------
    'キャプチャデバイスの選択
    Private Sub SelectDeviceDialog()

        Try
            'グラフ解放
            ReleaseGraph()

            '選択
            Dim dlg As New Dlg_CaptureDevice
            If dlg.ShowDialog() <> Windows.Forms.DialogResult.OK Then
                Exit Sub
            End If

            'グラフ作成
            CreateGraph(dlg.Graph, dlg.Pin)
            If mGrp Is Nothing Then Exit Sub

            '再生
            Dim mc As IMediaControl = CType(mGrp, IMediaControl)
            mc.Run()
            mc = Nothing

        Catch ex As Exception
            MsgBox("カメラの再設定を行って下さい" & vbCr & "【SelectDeviceDialog】" & ex.Message)
        End Try

    End Sub

    '----------------------------------------------------------
    'グラフ生成
    Private Function CreateGraph(ByVal grp As IGraphBuilder, ByVal outpin As IPin) As Boolean

        'チェック
        If grp Is Nothing Then Return True
        If outpin Is Nothing Then Return True
        mGrp = grp

        Dim rc As Integer
        Try
            'サンプルグラバフィルタの生成
            Dim smpflt As IBaseFilter = CreateFilter(DirectShowDefine.GUIDString.Filter.CLSID_SampleGrabber)
            If smpflt Is Nothing Then Throw New DirectShowException(0, "サンプルグラバフィルタが使用できません。")
            mSmp = CType(smpflt, ISampleGrabber)

            'サンプルグラバフィルタの設定
            Dim mt As New DirectShowDefine.AMMediaType
            mt.majorType = New Guid(DirectShowDefine.GUIDString.MediaType.MEDIATYPE_Video)
            mt.subType = New Guid(DirectShowDefine.GUIDString.MediaType.MEDIASUBTYPE_RGB24)
            rc = mSmp.SetMediaType(mt)
            If rc <> 0 Then Throw New DirectShowException(rc, "サンプルグラバフィルタのメディアタイプを設定できません。")

            'サンプルグラバフィルタをグラフに追加
            rc = mGrp.AddFilter(smpflt, "SampleGrabber")
            If rc <> 0 Then Throw New DirectShowException(rc, "サンプルグラバフィルタをグラフに追加できません。")

            '接続
            mGrp.Render(outpin)

            'サイズ初期設定
            Dim vsz As Size = GetVideoSize(mGrp)    '動画サイズ
            Dim csz As Size = Pic_View.ClientSize   '現在の表示領域サイズ
            Dim wsz As Size = Me.Size               'ウィンドウサイズ
            Dim esz As Size = wsz - csz             '表示エリア以外のサイズ

            'Me.Size = vsz + esz                     '動画サイズ＋表示エリア以外のサイズ
            'Pic_View.Size = vsz + esz               '動画サイズ＋表示エリア以外のサイズ

            'ウィンドウ内で再生
            ViewSizeChange()

            'サンプリング開始
            rc = mSmp.SetBufferSamples(True)
            If rc <> 0 Then Throw New DirectShowException(rc, "サンプリングを開始できません。")

        Catch ex As Exception
            'エラー
            MsgBox("カメラの再設定を行って下さい" & vbCr & "【CreateGraph】" & ex.Message)
            Return True
        End Try

        '成功
        Return False

    End Function

    '----------------------------------------------------------
    'グラフ解放
    Private Sub ReleaseGraph()

        Try
            If mGrp Is Nothing Then Exit Sub

            '停止させる
            Dim mc As IMediaControl = CType(mGrp, IMediaControl)
            mc.Stop()
            mc = Nothing

            '解放
            ReleaseInstance(mGrp)

        Catch ex As Exception
            MsgBox("カメラの再設定を行って下さい" & vbCr & "【ReleaseGraph】" & ex.Message)
        End Try

    End Sub

    '----------------------------------------------------------
    ' サイズ変更時
    Private Sub ViewSizeChange()

        Try
            ' 状態確認
            If mGrp Is Nothing Then Exit Sub

            ' PictureBox内で再生
            SetVideoRenderer(mGrp, Pic_View, RendererScale.KeepAspect)

        Catch ex As Exception
            MsgBox("カメラの再設定を行って下さい" & vbCr & "【ViewSizeChange】" & ex.Message)
        End Try

    End Sub

    '----------------------------------------------------------
    ' 静止画取得
    Private Sub Snap()

        'チェック
        If mGrp Is Nothing Then Exit Sub
        If mSmp Is Nothing Then Exit Sub

        Dim rc As Integer

        Try

            ' イメージサイズ取得
            Dim bmpsz As Integer = 0
            rc = mSmp.GetCurrentBuffer(bmpsz, IntPtr.Zero)
            If rc <> 0 Then Throw New DirectShowException(rc, "画像サイズが取得できません。")

            ' イメージ取得領域確保
            Dim bmpptr As IntPtr = Marshal.AllocHGlobal(bmpsz)

            ' サンプル取得
            rc = mSmp.GetCurrentBuffer(bmpsz, bmpptr)
            If rc <> 0 Then Throw New DirectShowException(rc, "イメージが取得できません。")

            ' 描画
            Dim vsz As Size = GetVideoSize(mGrp)
            Dim frm As New Frm_Image

            Call DrawRGB24(bmpptr, vsz)

            'イメージ取得領域解放
            Marshal.FreeHGlobal(bmpptr)

        Catch ex As Exception
            MsgBox("カメラの再設定を行って下さい" & vbCr & "【JobEntryForm.Snap】" & ex.Message)
        End Try

    End Sub


    ''' <summary>
    ''' 表示(RGB24ビット)
    ''' </summary>
    ''' <param name="BmpPtr"></param>
    ''' <param name="BmpSize"></param>
    ''' <remarks></remarks>
    Public Sub DrawRGB24(ByVal BmpPtr As IntPtr, ByVal BmpSize As Size)

        Try
            '準備
            Dim bmp As New Bitmap(BmpSize.Width, BmpSize.Height, BmpSize.Width * 3, Imaging.PixelFormat.Format24bppRgb, BmpPtr)

            If ChkPositiveDirection.Checked = True Then
                ' 正方向
                bmp.RotateFlip(RotateFlipType.Rotate180FlipY)
            Else
                ' 逆方向
                bmp.RotateFlip(RotateFlipType.RotateNoneFlipY)
            End If
            'bmp.RotateFlip(RotateFlipType.RotateNoneFlipY)

            PictureBox1.Image = New Bitmap(BmpSize.Width, BmpSize.Height)

            '表示領域にコピー
            Dim g As Graphics = Graphics.FromImage(PictureBox1.Image)
            g.DrawImage(bmp, 0, 0)
            g.Dispose()

            '後始末
            bmp.Dispose()

        Catch ex As Exception
            MsgBox("カメラの再設定を行って下さい" & vbCr & "【DrawRGB24】" & ex.Message)
        End Try

    End Sub

    '----------------------------------------------------------
    '選択開始
    Private Sub Start()

        Try
            '初期化
            ReleaseGraph()
            Cmb_Device.Items.Clear()
            Cmb_Pin.Items.Clear()
            Lst_Format.Items.Clear()
            'ControlEnable("1", False)
            'ControlEnable("2", False)
            'ControlEnable("3", False)
            ControlEnable("1", True)
            ControlEnable("2", True)
            ControlEnable("3", True)

            'デバイスリストの作成
            MakeDeviceList()
            Cmb_Device.SelectedIndex = 0

            ' デバイスの設定
            Cmb_Device.SelectedIndex = PubConstClass.intDeviceIdnex
            ' フォーマットの設定
            Lst_Format.SelectedIndex = PubConstClass.intFormatIndex

            'Btn_Format.PerformClick()

            'フォーマット変更
            ChangeFormat(Lst_Format.SelectedIndex)

            'リスト再作成
            MakeFormatList()

            'グラフ作成
            CreateGraph(mGrp, mPin)
            If mGrp Is Nothing Then Exit Sub

            '再生
            Dim mc As IMediaControl = CType(mGrp, IMediaControl)
            mc.Run()
            mc = Nothing

            PictureBox1.Width = PubConstClass.imageWinWidth
            PictureBox1.Height = PubConstClass.imageWinHeight

            Panel1.Visible = False

            '選択開始
            'ControlEnable("1", True)

        Catch ex As Exception
            MsgBox("カメラの再設定を行って下さい" & vbCr & "【Start】" & ex.Message)
        End Try

    End Sub

    '----------------------------------------------------------
    'デバイスリストの作成
    Private Sub MakeDeviceList()

        '現在のリストをクリア
        Cmb_Device.Items.Clear()

        Try
            'カメラデバイスの列挙
            Dim devs As Collection
            devs = EnumFilters(GUIDString.FilterCategory.CLSID_VideoInputDeviceCategory)

            'リスト作成
            For Each obj As Object In devs
                Dim fi As FILTERINFORMATION = CType(obj, FILTERINFORMATION)
                Cmb_Device.Items.Add(fi.Name)
                OutPutLogFile("MakeDeviceList【fi.Name】" & fi.Name)
            Next

        Catch ex As Exception
            MsgBox("【MakeDeviceList】デバイスの列挙中に問題が発生しました。" + vbCrLf + "理由：" + ex.Message)
        End Try

    End Sub

    '----------------------------------------------------------
    'コントロールの有効／無効切り替え
    Private Sub ControlEnable(ByVal TagName As String, ByVal Flag As Boolean, Optional ByVal Owner As Control.ControlCollection = Nothing)

        Try
            If Owner Is Nothing Then Owner = Me.Controls
            For Each ctl As Control In Owner

                If CStr(ctl.Tag) = TagName Then
                    ctl.Enabled = Flag
                End If

                If Not ctl.Controls Is Nothing Then
                    ControlEnable(TagName, Flag, ctl.Controls)
                End If

            Next

        Catch ex As Exception
            MsgBox("カメラの再設定を行って下さい" & vbCr & "【ControlEnable】" & ex.Message)
        End Try

    End Sub


    '----------------------------------------------------------
    'デバイスの選択
    Private Sub SelectDevice()

        Try
            '現在のグラフ解放
            ReleaseGraph()

            '選択デバイスの取得
            If Cmb_Device.SelectedItem Is Nothing Then
                'デバイスが選択されていない
                ControlEnable("2", False)
                ControlEnable("3", False)
                Exit Sub
            End If
            mSelectedDeviceName = CStr(Cmb_Device.SelectedItem)

            '同名のデバイスが存在する可能性があるため
            '何番目のデバイスであるかを調査
            Dim selidx As Integer = Cmb_Device.SelectedIndex
            Dim skp As Integer = 0  'スキップ数（＝無視する同名のデバイス数）
            For x As Integer = 0 To Cmb_Device.Items.Count - 1
                If CStr(Cmb_Device.Items(x)) = mSelectedDeviceName Then
                    If selidx <> x Then
                        skp += 1    '選択したデバイス以外で同名のデバイスである
                    Else
                        Exit For    '選択したデバイス
                    End If
                End If
            Next

            'グラフ生成
            mGrp = CreateNewGraph()

            'グラフにフィルタを追加
            mFlt = AddFilter(mGrp, GUIDString.FilterCategory.CLSID_VideoInputDeviceCategory, mSelectedDeviceName, skp, "")
            If mFlt Is Nothing Then
                Throw New Exception("選択したデバイスは使用できません。")
            End If

            'ピンリストの作成
            MakePinList()
            If Cmb_Pin.Items.Count = 0 Then
                Throw New Exception("利用可能な出力ピンがありません。")
            End If

            'デフォルトで先頭のピンを選択
            ControlEnable("2", True)
            Cmb_Pin.SelectedIndex = 0

        Catch ex As Exception
            MsgBox("カメラの再設定を行って下さい" & vbCr & "【ControlEnable】" & ex.Message)
            'クリア
            Start()
        End Try

    End Sub

    '----------------------------------------------------------
    'ピンリストの作成
    Private Sub MakePinList()

        '現在のリストをクリア
        Cmb_Pin.Items.Clear()

        Try
            'ピンの列挙
            Dim pins As Collection
            pins = EnumPins(mFlt)

            'リスト作成
            For Each obj As Object In pins
                Dim pi As PININFORMATION = CType(obj, PININFORMATION)
                Cmb_Pin.Items.Add(pi.Name)
            Next

        Catch ex As Exception
            MsgBox("【MakePinList】ピンの列挙中に問題が発生しました。" + vbCrLf + "理由：" + ex.Message)
        End Try

    End Sub

    '----------------------------------------------------------
    'フォーマットリストの作成
    Private Sub MakeFormatList()

        'クリア
        Lst_Format.Items.Clear()

        Dim mt As AMMediaType = Nothing
        Try

            '列挙
            If mPin Is Nothing Then Exit Sub
            Dim fmts As Collection = EnumFormat(mPin)

            '現在のフォーマット取得
            mt = GetFormat(mPin)
            Dim vinfo As New DSVIDEOINFOHEADER
            vinfo = PtrToStructure(Of DSVIDEOINFOHEADER)(mt.formatPtr)
            Dim sz As New Size(vinfo.BmiHeader.Width, vinfo.BmiHeader.Height)

            'リスト作成
            Dim ss As New System.Text.StringBuilder
            For Each v As FORMATINFORMATION In fmts

                'メジャータイプとマイナータイプの編集
                ss.Length = 0
                If Chk_MajorType.Checked Then ss.AppendFormat("{0} ", GetMediaTypeName(v.MajorType.ToString))
                If Chk_SubType.Checked Then ss.AppendFormat("{0} ", GetMediaTypeName(v.SubType.ToString))

                'サイズの編集
                If CompGUIDString(v.FormatType.ToString, GUIDString.FormatType.FORMAT_VideoInfo) Then
                    '画像形式
                    ss.AppendFormat("{0} x {1}", v.Size.Width, v.Size.Height)
                Else
                    '映像形式でない
                    ss.AppendFormat("unsupport format")
                End If

                'リストに追加
                Lst_Format.Items.Add(ss.ToString)

                '現在のフォーマットか？
                If v.MajorType.Equals(mt.majorType) Then
                    If v.SubType.Equals(mt.subType) Then
                        If v.FormatType.Equals(mt.formatType) Then
                            If (v.Size.Width = sz.Width) And (v.Size.Height = sz.Height) Then
                                '現在のフォーマットである

                                '選択する
                                Lst_Format.SelectedItem = Lst_Format.Items(Lst_Format.Items.Count - 1)
                            End If
                        End If
                    End If
                End If
            Next

        Catch ex As Exception
            MsgBox("【MakeFormatList】フォーマットの列挙中に問題が発生しました。" + vbCrLf + "理由：" + ex.Message)

        Finally
            If Not mt Is Nothing Then
                DeleteMediaType(mt)
            End If

        End Try

    End Sub

    '----------------------------------------------------------
    'フォーマットの変更
    Private Sub ChangeFormat(ByVal Index As Integer)

        'チェック
        If mPin Is Nothing Then Exit Sub

        'フォーマット取得
        Dim mt As AMMediaType = Nothing
        mt = GetFormat(mPin, Index)

        'フォーマット設定
        SetFormat(mPin, mt)

    End Sub

    '----------------------------------------------------------
    'ピンの選択
    Private Sub SelectPin()

        '状態チェック
        If (mGrp Is Nothing) OrElse (mFlt Is Nothing) Then Exit Sub

        'ピンの選択
        mPin = FindPin(mFlt, Cmb_Pin.Text)

        If mPin Is Nothing Then
            ControlEnable("3", False)
        Else
            '選択完了
            ControlEnable("3", True)
        End If

        'フォーマットリスト更新
        If Pnl_Format.Visible Then
            MakeFormatList()
        End If

    End Sub

    ''' <summary>
    ''' フォームアクティブ処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub userDataForm_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated

        Try

        Catch ex As Exception
            MsgBox("【userDataForm_Activated】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' フォームロード処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub userDataForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try

            ' オペレータ情報の表示
            LblOperatorName.Text = GetOperatorInfomation()

            ' バージョン表示
            lblVersion.Text = PubConstClass.DEF_VERSION

            ' 種別データの表示
            CmbClassification.Items.Clear()
            For N = 0 To PubConstClass.pblClassDataIndex - 1
                CmbClassification.Items.Add(PubConstClass.pblClassData(N))
            Next
            CmbClassification.SelectedIndex = 0

            ' INIファイルから設定値を取得する
            Call getSystemIniFile()

            ' 業務データコンボボックス登録処理
            EntryJobComboBox(cmbJobList)

            ' ユーザー情報の取得
            Call getUserInfomation(CInt(PubConstClass.userNumber))

            ' ユーザーデータ表示
            Call displayUserInfomation(CInt(PubConstClass.userNumber))

            ' 操作ログの書き込み
            OutPutLogFile("業務登録メニュー起動")
            OutPutLogFile("ユーザー番号【" & PubConstClass.userNumber & "】")

            'ToolTipを作成する
            ToolTip1 = New ToolTip(Me.components)
            'フォームにcomponentsがない場合
            'ToolTip1 = new ToolTip();
            'ToolTipの設定を行う
            'ToolTipが表示されるまでの時間
            ToolTip1.InitialDelay = 1000
            'ToolTipが表示されている時に、別のToolTipを表示するまでの時間
            ToolTip1.ReshowDelay = 1000
            'ToolTipを表示する時間
            ToolTip1.AutoPopDelay = 10000
            ToolTip1.SetToolTip(TxtPosYFeeder, "封筒幅の入力範囲は、100～260 です")
            ToolTip1.SetToolTip(TxtPosYLabel, "送方向（上辺）の入力範囲は、10～145 です")
            ToolTip1.SetToolTip(TxtPosXLabel, "横方向（左辺）の入力範囲は、10～170 です。")
            ToolTip1.SetToolTip(TxtPosYCapture, "送方向（画角中央）の入力範囲は、43～255 です。")
            ToolTip1.SetToolTip(TxtPosXCapture, "横方向（画角中央）の入力範囲は、50～190 です。")

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
            ' 読込タイムアウト時間の設定
            SerialPort.ReadTimeout = 1000
            SerialPort.ParityReplace = Convert.ToByte(Char.Parse("?"))
            ' シリアルポートのオープン
            SerialPort.Open()

            '' ラベラー＆プリンター用に修正（デバックの為）↓ここから
            '' シリアルポートのオープン
            'SerialPort.PortName = "COM1"
            '' シリアルポートの通信速度指定
            'SerialPort.BaudRate = 19200
            '' シリアルポートのパリティ指定
            'SerialPort.Parity = IO.Ports.Parity.None
            '' シリアルポートのビット数指定
            'SerialPort.DataBits = 8
            '' シリアルポートのストップビット指定
            'SerialPort.StopBits = IO.Ports.StopBits.One
            '' 読込タイムアウト時間の設定
            'SerialPort.ReadTimeout = 1000
            'SerialPort.ParityReplace = Convert.ToByte(Char.Parse("?"))
            '' シリアルポートのオープン
            'SerialPort.Open()
            '' ラベラー＆プリンター用に修正（デバックの為）↑ここまで

            '///////////////////////
            '// カメラの初期化    //
            '///////////////////////
            Call Start()

        Catch ex As Exception
            MsgBox("【userDataForm_Load】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' ユーザーデータ表示処理
    ''' </summary>
    ''' <param name="intUserNo"></param>
    ''' <remarks></remarks>
    Public Sub displayUserInfomation(ByVal intUserNo As Integer)

        Dim strArray() As String

        Try
            ' ユーザー情報の取得
            getUserInfomation(intUserNo)

            ' (00)業務名称
            TxtJobName.Text = PubConstClass.strPubJobName

            ' (01)コメント
            TxtComment.Text = PubConstClass.strPubComment

            ' (02) 種別
            strArray = Split(PubConstClass.strPubKind, ","c)
            CmbClassification.SelectedIndex = CInt(strArray(0))

            ' (03) 定形・定形外
            If PubConstClass.strPubTeikei = "0" Then
                ' 定形
                RdoTeikei.Checked = True
            ElseIf PubConstClass.strPubTeikei = "1" Then
                ' 定形外(規格内)
                RdoTeikeiGai.Checked = True
            Else
                ' 定形外(規格外)
                RdoTeikeiGaiNonS.Checked = True
            End If

            ' (04) 差出人住所１
            TxtAddress1.Text = PubConstClass.strPubAddress1

            ' (05) 差出人住所２
            TxtAddress2.Text = PubConstClass.strPubAddress2

            ' (06) 差出人氏名
            TxtName.Text = PubConstClass.strPubName

            ' (07) 承認局名
            TxtPostName.Text = PubConstClass.strPubPostName

            ' (08) 摘要
            TxtTekiyou.Text = PubConstClass.strPubTekiyou

            ' (09) 要償額
            TxtYoushoPrice.Text = PubConstClass.strPubYousyougaku

            ' (10) フィーダー位置（垂直方向）
            TxtPosYFeeder.Text = PubConstClass.strPubFeederPosV

            ' (11) ラベル貼付位置（垂直方向）
            TxtPosYLabel.Text = PubConstClass.strPubLabelPosV

            ' (12) ラベル貼付位置（水平方向）
            TxtPosXLabel.Text = PubConstClass.strPubLabelPosH

            ' (13) 宛名撮像位置（垂直方向）
            TxtPosYCapture.Text = PubConstClass.strPubAddressPosV

            ' (14) 宛名撮像位置（水平方向）
            TxtPosXCapture.Text = PubConstClass.strPubAddressPosH

            ' (15) 正方向流し
            If PubConstClass.strPubPositiveDirection = "1" Then
                ChkPositiveDirection.Checked = True
                LblPositiveDirection.Visible = True
            Else
                ChkPositiveDirection.Checked = False
                LblPositiveDirection.Visible = False
            End If

        Catch ex As Exception
            MsgBox("【displayUserInfomation】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' ユーザーデータ書込処理
    ''' </summary>
    ''' <param name="intUserNo">ユーザー番号</param>
    ''' <remarks></remarks>
    Public Sub putUserInfomation(ByVal intUserNo As Integer)

        Dim strPutDataPath As String

        Try
            strPutDataPath = IncludeTrailingPathDelimiter(Application.StartupPath) & "USER\user_" & intUserNo.ToString.PadLeft(2, "0"c) & ".txt"
            ' 上書モードで書き込む
            Using sw As New System.IO.StreamWriter(strPutDataPath, False, System.Text.Encoding.Default)
                ' (00) 業務名称
                sw.WriteLine(PubConstClass.USR_JOB_NAME & "," & TxtJobName.Text)
                ' (01) コメント
                sw.WriteLine(PubConstClass.USR_COMMENT & "," & TxtComment.Text)
                ' (02) 種別
                sw.WriteLine(PubConstClass.USR_KIND & "," & CmbClassification.SelectedIndex.ToString("0") & "," & CmbClassification.Text)
                ' (03) 定形・定形外
                If RdoTeikei.Checked = True Then
                    ' 定形
                    sw.WriteLine(PubConstClass.USR_TEIKEI & ",0")
                ElseIf RdoTeikeiGai.Checked = True Then
                    ' 定形外(規格内)
                    sw.WriteLine(PubConstClass.USR_TEIKEI & ",1")
                Else
                    ' 定形外(規格外)
                    sw.WriteLine(PubConstClass.USR_TEIKEI & ",2")
                End If
                ' (04) 差出人住所１
                sw.WriteLine(PubConstClass.USR_ADRESS1 & "," & TxtAddress1.Text)
                ' (05) 差出人住所２
                sw.WriteLine(PubConstClass.USR_ADRESS2 & "," & TxtAddress2.Text)
                ' (06) 差出人氏名
                sw.WriteLine(PubConstClass.USR_NAME & "," & TxtName.Text)
                ' (07) 承認局名
                sw.WriteLine(PubConstClass.USR_POSTNAME & "," & TxtPostName.Text)
                ' (08) 摘要
                sw.WriteLine(PubConstClass.USR_TEKIYOU & "," & TxtTekiyou.Text)
                ' (09) 要償額
                sw.WriteLine(PubConstClass.USR_YOUSYOUGAKU & "," & TxtYoushoPrice.Text)
                ' (10) フィーダー位置（垂直方向）
                sw.WriteLine(PubConstClass.USR_FEEDER_POS_V & "," & TxtPosYFeeder.Text)
                ' (11) ラベル貼付位置（垂直方向）
                sw.WriteLine(PubConstClass.USR_LABEL_POS_V & "," & TxtPosYLabel.Text)
                ' (12) ラベル貼付位置（水平方向）
                sw.WriteLine(PubConstClass.USR_LABEL_POS_H & "," & TxtPosXLabel.Text)
                ' (13) 宛名撮像位置（垂直方向）
                sw.WriteLine(PubConstClass.USR_ADDRESS_POS_V & "," & TxtPosYCapture.Text)
                ' (14) 宛名撮像位置（水平方向）
                sw.WriteLine(PubConstClass.USR_ADDRESS_POS_H & "," & TxtPosXCapture.Text)

                If ChkPositiveDirection.Checked = True Then
                    ' (15) 正方向流し
                    sw.WriteLine(PubConstClass.USR_POSITIVE_DIRECTION & ",1")
                    OutPutLogFile("■USER\user_" & intUserNo.ToString.PadLeft(2, "0"c) & ".txt" & "：正方向流し設定")
                End If

            End Using

        Catch ex As Exception
            MsgBox("【putUserInfomation】" & ex.Message)
        End Try

    End Sub


    ''' <summary>
    ''' 表示データの初期化
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub deleteUserInfomation()

        Try
            ' (00)業務名称
            TxtJobName.Text = "（空き）"

            ' (01)コメント
            TxtComment.Text = "（空き）"

            ' (02) 種別
            CmbClassification.SelectedIndex = 0

            ' (03) 定形・定形外
            RdoTeikei.Checked = True

            ' (04) 差出人住所１
            TxtAddress1.Text = ""

            ' (05) 差出人住所２
            TxtAddress2.Text = ""

            ' (06) 差出人氏名
            TxtName.Text = ""

            ' (07) 承認局名
            TxtPostName.Text = ""

            ' (08) 摘要
            TxtTekiyou.Text = ""

            ' (09) 要償額
            TxtYoushoPrice.Text = ""

        Catch ex As Exception
            MsgBox("【deleteUserInfomation】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' コンボボックス選択処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmbJobList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbJobList.SelectedIndexChanged

        Try
            Dim strArray() As String = cmbJobList.Text.Split("："c)
            If strArray(1) = "（空き）" Then
                TxtJobName.Text = ""
                TxtComment.Text = ""
                TxtAddress1.Text = ""
                TxtAddress2.Text = ""
                TxtName.Text = ""
                TxtPostName.Text = ""
                TxtTekiyou.Text = ""
                TxtYoushoPrice.Text = ""
                Exit Sub
            End If

            ' ユーザーデータ表示
            Call displayUserInfomation(cmbJobList.SelectedIndex + 1)
            Debug.Print("コンボボックスクリック：" & cmbJobList.SelectedIndex.ToString)

        Catch ex As Exception
            MsgBox("【cmbJobList_SelectedIndexChanged】" & ex.Message)
        End Try

    End Sub

    ' ''' <summary>
    ' ''' 「要償額」入力文字制御
    ' ''' </summary>
    ' ''' <param name="sender"></param>
    ' ''' <param name="e"></param>
    ' ''' <remarks></remarks>
    'Private Sub TextBox7_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtYoushoPrice.KeyPress
    '    ' 「BS」の場合はキャンセルしない
    '    If e.KeyChar = Constants.vbBack Then
    '        Exit Sub
    '    End If
    '    ' 押されたキーが「0～9」以外の場合は入力をキャンセルする
    '    If e.KeyChar < "0"c Or e.KeyChar > "9"c Then
    '        e.Handled = True
    '    End If
    'End Sub

    ' ''' <summary>
    ' ''' 「停止NG回数」入力文字制御
    ' ''' </summary>
    ' ''' <param name="sender"></param>
    ' ''' <param name="e"></param>
    ' ''' <remarks></remarks>
    'Private Sub TextBox8_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    '    ' 「BS」の場合はキャンセルしない
    '    If e.KeyChar = Constants.vbBack Then
    '        Exit Sub
    '    End If
    '    ' 押されたキーが「0～9」以外の場合は入力をキャンセルする
    '    If e.KeyChar < "0"c Or e.KeyChar > "9"c Then
    '        e.Handled = True
    '    End If
    'End Sub

    'Private Sub TextBox9_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    '    ' 「BS」の場合はキャンセルしない
    '    If e.KeyChar = Constants.vbBack Then
    '        Exit Sub
    '    End If
    '    ' 押されたキーが「0～9」以外の場合は入力をキャンセルする
    '    If e.KeyChar < "0"c Or e.KeyChar > "9"c Then
    '        e.Handled = True
    '    End If
    'End Sub

    'Private Sub TextBox10_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    '    ' 「BS」の場合はキャンセルしない
    '    If e.KeyChar = Constants.vbBack Then
    '        Exit Sub
    '    End If
    '    ' 押されたキーが「0～9」以外の場合は入力をキャンセルする
    '    If e.KeyChar < "0"c Or e.KeyChar > "9"c Then
    '        e.Handled = True
    '    End If
    'End Sub

    'Private Sub TextBox11_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    '    ' 「BS」の場合はキャンセルしない
    '    If e.KeyChar = Constants.vbBack Then
    '        Exit Sub
    '    End If
    '    ' 押されたキーが「0～9」以外の場合は入力をキャンセルする
    '    If e.KeyChar < "0"c Or e.KeyChar > "9"c Then
    '        e.Handled = True
    '    End If
    'End Sub


    'Private Sub TextBox12_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    '    ' 「BS」の場合はキャンセルしない
    '    If e.KeyChar = Constants.vbBack Then
    '        Exit Sub
    '    End If
    '    ' 押されたキーが「0～9」以外の場合は入力をキャンセルする
    '    If e.KeyChar < "0"c Or e.KeyChar > "9"c Then
    '        e.Handled = True
    '    End If
    'End Sub

    'Private Sub TextBox13_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    '    ' 「BS」の場合はキャンセルしない
    '    If e.KeyChar = Constants.vbBack Then
    '        Exit Sub
    '    End If
    '    ' 押されたキーが「0～9」以外の場合は入力をキャンセルする
    '    If e.KeyChar < "0"c Or e.KeyChar > "9"c Then
    '        e.Handled = True
    '    End If
    'End Sub

    'Private Sub TextBox14_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    '    ' 「BS」の場合はキャンセルしない
    '    If e.KeyChar = Constants.vbBack Then
    '        Exit Sub
    '    End If
    '    ' 押されたキーが「0～9」以外の場合は入力をキャンセルする
    '    If e.KeyChar < "0"c Or e.KeyChar > "9"c Then
    '        e.Handled = True
    '    End If
    'End Sub

    'Private Sub TextBox15_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    '    ' 「BS」の場合はキャンセルしない
    '    If e.KeyChar = Constants.vbBack Then
    '        Exit Sub
    '    End If
    '    ' 押されたキーが「0～9」以外の場合は入力をキャンセルする
    '    If e.KeyChar < "0"c Or e.KeyChar > "9"c Then
    '        e.Handled = True
    '    End If
    'End Sub

    'Private Sub TextBox16_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    '    ' 「BS」の場合はキャンセルしない
    '    If e.KeyChar = Constants.vbBack Then
    '        Exit Sub
    '    End If
    '    ' 押されたキーが「0～9」以外の場合は入力をキャンセルする
    '    If e.KeyChar < "0"c Or e.KeyChar > "9"c Then
    '        e.Handled = True
    '    End If
    'End Sub

    'Private Sub TextBox17_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    '    ' 「BS」の場合はキャンセルしない
    '    If e.KeyChar = Constants.vbBack Then
    '        Exit Sub
    '    End If
    '    ' 押されたキーが「0～9」以外の場合は入力をキャンセルする
    '    If e.KeyChar < "0"c Or e.KeyChar > "9"c Then
    '        e.Handled = True
    '    End If
    'End Sub

    'Private Sub TextBox18_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    '    ' 「BS」の場合はキャンセルしない
    '    If e.KeyChar = Constants.vbBack Then
    '        Exit Sub
    '    End If
    '    ' 押されたキーが「0～9」以外の場合は入力をキャンセルする
    '    If e.KeyChar < "0"c Or e.KeyChar > "9"c Then
    '        e.Handled = True
    '    End If
    'End Sub

    'Private Sub TextBox19_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    '    ' 「BS」の場合はキャンセルしない
    '    If e.KeyChar = Constants.vbBack Then
    '        Exit Sub
    '    End If
    '    ' 押されたキーが「0～9」以外の場合は入力をキャンセルする
    '    If e.KeyChar < "0"c Or e.KeyChar > "9"c Then
    '        e.Handled = True
    '    End If
    'End Sub

    'Private Sub TextBox20_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    '    ' 「BS」の場合はキャンセルしない
    '    If e.KeyChar = Constants.vbBack Then
    '        Exit Sub
    '    End If
    '    ' 押されたキーが「0～9」以外の場合は入力をキャンセルする
    '    If e.KeyChar < "0"c Or e.KeyChar > "9"c Then
    '        e.Handled = True
    '    End If
    'End Sub

    'Private Sub TextBox21_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    '    ' 「BS」の場合はキャンセルしない
    '    If e.KeyChar = Constants.vbBack Then
    '        Exit Sub
    '    End If
    '    ' 押されたキーが「0～9」以外の場合は入力をキャンセルする
    '    If e.KeyChar < "0"c Or e.KeyChar > "9"c Then
    '        e.Handled = True
    '    End If
    'End Sub

    'Private Sub TextBox22_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    '    ' 「BS」の場合はキャンセルしない
    '    If e.KeyChar = Constants.vbBack Then
    '        Exit Sub
    '    End If
    '    ' 押されたキーが「0～9」以外の場合は入力をキャンセルする
    '    If e.KeyChar < "0"c Or e.KeyChar > "9"c Then
    '        e.Handled = True
    '    End If
    'End Sub

    'Private Sub TextBox23_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    '    ' 「BS」の場合はキャンセルしない
    '    If e.KeyChar = Constants.vbBack Then
    '        Exit Sub
    '    End If
    '    ' 押されたキーが「0～9」以外の場合は入力をキャンセルする
    '    If e.KeyChar < "0"c Or e.KeyChar > "9"c Then
    '        e.Handled = True
    '    End If
    'End Sub

    'Private Sub TextBox24_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    '    ' 「BS」の場合はキャンセルしない
    '    If e.KeyChar = Constants.vbBack Then
    '        Exit Sub
    '    End If
    '    ' 押されたキーが「0～9」以外の場合は入力をキャンセルする
    '    If e.KeyChar < "0"c Or e.KeyChar > "9"c Then
    '        e.Handled = True
    '    End If
    'End Sub

    'Private Sub TextBox25_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    '    ' 「BS」の場合はキャンセルしない
    '    If e.KeyChar = Constants.vbBack Then
    '        Exit Sub
    '    End If
    '    ' 押されたキーが「0～9」以外の場合は入力をキャンセルする
    '    If e.KeyChar < "0"c Or e.KeyChar > "9"c Then
    '        e.Handled = True
    '    End If
    'End Sub

    'Private Sub TextBox26_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    '    ' 「BS」の場合はキャンセルしない
    '    If e.KeyChar = Constants.vbBack Then
    '        Exit Sub
    '    End If
    '    ' 押されたキーが「0～9」以外の場合は入力をキャンセルする
    '    If e.KeyChar < "0"c Or e.KeyChar > "9"c Then
    '        e.Handled = True
    '    End If
    'End Sub

    'Private Sub TextBox27_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    '    ' 「BS」の場合はキャンセルしない
    '    If e.KeyChar = Constants.vbBack Then
    '        Exit Sub
    '    End If
    '    ' 押されたキーが「0～9」以外の場合は入力をキャンセルする
    '    If e.KeyChar < "0"c Or e.KeyChar > "9"c Then
    '        e.Handled = True
    '    End If
    'End Sub

    'Private Sub TextBox28_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    '    ' 「BS」の場合はキャンセルしない
    '    If e.KeyChar = Constants.vbBack Then
    '        Exit Sub
    '    End If
    '    ' 押されたキーが「0～9」以外の場合は入力をキャンセルする
    '    If e.KeyChar < "0"c Or e.KeyChar > "9"c Then
    '        e.Handled = True
    '    End If
    'End Sub

    'Private Sub TextBox29_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    '    ' 「BS」の場合はキャンセルしない
    '    If e.KeyChar = Constants.vbBack Then
    '        Exit Sub
    '    End If
    '    ' 押されたキーが「0～9」以外の場合は入力をキャンセルする
    '    If e.KeyChar < "0"c Or e.KeyChar > "9"c Then
    '        e.Handled = True
    '    End If
    'End Sub

    'Private Sub TextBox30_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    '    ' 「BS」の場合はキャンセルしない
    '    If e.KeyChar = Constants.vbBack Then
    '        Exit Sub
    '    End If
    '    ' 押されたキーが「0～9」以外の場合は入力をキャンセルする
    '    If e.KeyChar < "0"c Or e.KeyChar > "9"c Then
    '        e.Handled = True
    '    End If
    'End Sub


    ''' <summary>
    ''' 「戻る」ボタン処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBack.Click

        If SerialPort.IsOpen = True Then
            SerialPort.Close()
        End If

        ' グラフの解放
        ReleaseGraph()

        MasterMaintForm.Show()
        Me.Dispose()

    End Sub


    ''' <summary>
    ''' 「保存」ボタン処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Dim blnIsError As Boolean = False

        Try
            PubConstClass.userNumber = (cmbJobList.SelectedIndex + 1).ToString

            Dim varRetVal As MsgBoxResult = MsgBox("保存しますか？", CType(MsgBoxStyle.Question + MsgBoxStyle.OkCancel, MsgBoxStyle), "確認")

            If varRetVal = Constants.vbOK Then
                ' フィーダー位置、ラベル貼付位置、宛名撮像位置の範囲チェック
                For N = 1 To 5
                    blnIsError = InputRangeCheck(N)
                    If blnIsError = False Then
                        Exit Sub
                    End If
                Next

                ' 「はい」を選択
                PubConstClass.userNumber = (cmbJobList.SelectedIndex + 1).ToString
                Debug.Print("★ユーザー番号書き込み：" & PubConstClass.userNumber)

                Dim strIniFilePath As String = IncludeTrailingPathDelimiter(Application.StartupPath) & PubConstClass.DEF_INI_FILENAME

                WritePrivateProfileString("System", "UserNo", PubConstClass.userNumber, strIniFilePath)

                ' ユーザーデータ書込処理
                Call putUserInfomation(cmbJobList.SelectedIndex + 1)

                ' 業務データコンボボックス登録処理
                EntryJobComboBox(cmbJobList)

                ' ユーザーデータ表示
                Call displayUserInfomation(cmbJobList.SelectedIndex + 1)

            End If

        Catch ex As Exception
            MsgBox("【btnSave_Click】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Pic_View_Resize(sender As Object, e As System.EventArgs) Handles Pic_View.Resize

        Try
            '動画サイズ変更
            ViewSizeChange()
        Catch ex As Exception
            MsgBox("【Pic_View_Resize】" & ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' 「撮像確認」ボタン処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnSnapConfirm_Click(sender As System.Object, e As System.EventArgs) Handles BtnSnapConfirm.Click

        Call Snap()

    End Sub

    Private Sub Cmb_Device_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles Cmb_Device.SelectedIndexChanged
        SelectDevice()
    End Sub

    Private Sub Btn_PinFormat_Click(sender As System.Object, e As System.EventArgs) Handles Btn_PinFormat.Click
        MakeFormatList()
    End Sub

    Private Sub Cmb_Pin_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles Cmb_Pin.SelectedIndexChanged
        SelectPin()
    End Sub

    ''' <summary>
    ''' 「設定保存」ボタン処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Btn_Format_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Format.Click

        Try
            Dim idx As Integer = Lst_Format.SelectedIndex
            OutPutLogFile("■業務登録画面：「設定保存」ボタン押下【Lst_Format.SelectedIndex】" & idx)
            If idx < 0 Then
                MsgBox("フォーマットを選択して下さい。")
                Exit Sub
            End If

            Dim strIniFilePath As String = IncludeTrailingPathDelimiter(Application.StartupPath) & PubConstClass.DEF_INI_FILENAME
            ' デバイスインデックス（カメラ用）
            PubConstClass.intDeviceIdnex = Cmb_Device.SelectedIndex
            ' フォーマットインデックス（カメラ用）
            PubConstClass.intFormatIndex = Lst_Format.SelectedIndex
            OutPutLogFile("■業務登録画面（デバイス）：" & PubConstClass.intDeviceIdnex.ToString("0"))
            OutPutLogFile("■業務登録画面（出力フォーマット）：" & PubConstClass.intFormatIndex.ToString("0"))
            WritePrivateProfileString("Camera", "DeviceIndex", PubConstClass.intDeviceIdnex.ToString("0"), strIniFilePath)
            WritePrivateProfileString("Camera", "FormatIndex", PubConstClass.intFormatIndex.ToString("0"), strIniFilePath)

            'フォーマット変更
            ChangeFormat(idx)

            'リスト再作成
            MakeFormatList()

            'グラフ作成
            CreateGraph(mGrp, mPin)
            If mGrp Is Nothing Then Exit Sub

            '再生
            Dim mc As IMediaControl = CType(mGrp, IMediaControl)
            mc.Run()
            mc = Nothing

            PictureBox1.Width = PubConstClass.imageWinWidth
            PictureBox1.Height = PubConstClass.imageWinHeight

            Panel1.Visible = False

        Catch ex As Exception
            MsgBox("【Btn_Format_Click】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 「閉じる」ボタン処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click

        Panel1.Visible = False

    End Sub

    ''' <summary>
    ''' 「現在値要求」ボタン処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnRecieveSetData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRecieveSetData.Click
        Try
            ' シリアルポートにデータ送信（設定要求コマンド）
            Call sendCommand(PubConstClass.CMD_SEND_h)
        Catch ex As Exception
            MsgBox("【BtnRecieveSetData_Click】" & ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' 受信データによる各コマンド処理
    ''' </summary>
    ''' <param name="data">受信した文字列</param>
    ''' <remarks></remarks>
    Private Sub RcvDataToTextBox(ByVal data As String)

        Dim strArray() As String
        Dim strHexDump As String

        Try
            '受信データをテキストボックスの最後に追記する。
            If IsNothing(data) = False Then

                If data.Length > 2 Then
                    Select Case data.Substring(0, 2)
                        Case "ZH"
                            strArray = data.Split(","c)
                            TxtPosYFeeder.Text = strArray(0).Substring(2, 3)
                            TxtPosYLabel.Text = strArray(1)
                            TxtPosXLabel.Text = strArray(2)
                            TxtPosYCapture.Text = strArray(3)
                            TxtPosXCapture.Text = strArray(4)

                        Case "ZL"
                            For N = 2 To data.Length - 1
                                strHexDump = AscW(data.Substring(N, 1)).ToString("X")
                                OutPutLogFile("◆LR4820RVe2からの受信文字：" & strHexDump)
                            Next

                        Case Else
                            ' テキストボックスに表示
                            OutPutLogFile("未定義コマンド受信：" & data.ToString)
                            ' 受信データの格納
                            Call OutPutLogFile("【JobEntryForm.RcvDataToTextBox】未定義コマンド受信：" + data.Replace(ControlChars.Cr, "<CR>"))
                    End Select
                End If
            End If

        Catch ex As Exception
            MsgBox("【RcvDataToTextBox】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' データ受信が発生したときのイベント処理
    ''' </summary>
    ''' <param name="sender">イベントの送信元のオブジェクト</param>
    ''' <param name="e">イベント情報</param>
    ''' <remarks></remarks>
    Private Sub SerialPort_DataReceived(ByVal sender As System.Object, _
                                        ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) _
                                        Handles SerialPort.DataReceived

        'シリアルポートをオープンしていない場合、処理を行わない。
        If SerialPort.IsOpen = False Then
            Return
        End If

        Try
            Dim data As String
            Dim args(0) As Object

            ' <CR>まで読み込む
            data = SerialPort.ReadTo(ControlChars.Cr)

            If data.IndexOf("?") > 0 Then
                Call OutPutLogFile("【JobEntryForm】受信（パリティエラー）：" & data.ToString & "<CR>")
                BeginInvoke(New Delegate_RcvDataToTextBox(AddressOf Me.RcvDataToTextBox), "パリティエラー：" & "data.ToString" & ControlChars.Cr)
            End If

            ' 受信データの格納
            Call OutPutLogFile("【JobEntryForm】受信：" & data.ToString & "<CR>")
            BeginInvoke(New Delegate_RcvDataToTextBox(AddressOf Me.RcvDataToTextBox), data.ToString & ControlChars.Cr)

        Catch ex As TimeoutException
            ' 受信タイムアウトの処理（受信バッファをクリア）
            Dim strDiscardData As String = SerialPort.ReadExisting()
            ' ディスカードするデータ
            Call OutPutLogFile("【JobEntryForm】データ受信タイムアウトエラー：<CR>未受信で切り捨てたデータ：" & strDiscardData)
            BeginInvoke(New Delegate_RcvDataToTextBox(AddressOf Me.RcvDataToTextBox), "ZE999" & ControlChars.Cr)
        Catch ex As Exception
            MsgBox("【JobEntryForm.SerialPort_DataReceived】" & ex.Message)
        End Try


    End Sub

    ''' <summary>
    ''' シリアルポートにデータ送信
    ''' </summary>
    ''' <param name="strSendData">送信データ</param>
    ''' <remarks></remarks>
    Private Sub sendCommand(ByVal strSendData As String)

        Try
            Dim dat As Byte() = System.Text.Encoding.GetEncoding("SHIFT-JIS").GetBytes(strSendData & vbCr)
            SerialPort.Write(dat, 0, dat.GetLength(0))
            Call OutPutLogFile("【JobEntryForm】送信：" & strSendData & "<CR>")
        Catch ex As Exception
            MsgBox("【JobEntryForm.sendCommand】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 「設定送信」ボタン処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnSendSetData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSendSetData.Click

        Dim blnIsError As Boolean

        Try
            ' フィーダー位置、ラベル貼付位置、宛名撮像位置の範囲チェック
            For N = 1 To 5
                blnIsError = InputRangeCheck(N)
                If blnIsError = False Then
                    Exit Sub
                End If
            Next

            Dim strSendData As String = PubConstClass.CMD_SEND_b
            strSendData &= CInt(TxtPosYFeeder.Text).ToString("000") & ","
            strSendData &= CInt(TxtPosYLabel.Text).ToString("000") & ","
            strSendData &= CInt(TxtPosXLabel.Text).ToString("000") & ","
            strSendData &= CInt(TxtPosYCapture.Text).ToString("000") & ","
            strSendData &= CInt(TxtPosXCapture.Text).ToString("000") & ","

            ' シリアルポートにデータ送信（設定送信コマンド）
            Call sendCommand(strSendData)

        Catch ex As Exception
            MsgBox("【JobEntryForm.BtnSendSetData_Click】" & ex.Message)
        End Try

    End Sub

    Private Sub TxtPosYFeeder_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPosYFeeder.KeyPress
        ' 数字のみ入力可能
        e.Handled = CheckKeyPress("1", e)
    End Sub

    ''' <summary>
    ''' フィーダー位置（垂直方向）の範囲チェック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TxtPosYFeeder_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtPosYFeeder.LostFocus

        Try
            InputRangeCheck(1)

            'If TxtPosYFeeder.Text <> "" Then
            '    If CInt(TxtPosYFeeder.Text) < 100 Or CInt(TxtPosYFeeder.Text) > 235 Then
            '        MsgBox("フィーダー位置（垂直方向）の入力範囲は、100～235 です", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")
            '        'TxtPosYFeeder.Focus()
            '    End If
            'Else
            '    MsgBox("フィーダー位置（垂直方向）の値を入力して下さい", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")
            '    'TxtPosYFeeder.Focus()
            'End If

        Catch ex As Exception
            MsgBox("【TxtPosYFeeder_LostFocus】" & ex.Message)
        End Try

    End Sub

    Private Sub TxtPosYFeeder_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtPosYFeeder.TextChanged

    End Sub

    Private Sub TxtPosYLabel_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPosYLabel.KeyPress
        ' 数字のみ入力可能
        e.Handled = CheckKeyPress("1", e)
    End Sub

    ''' <summary>
    ''' ラベル貼付位置（垂直方向）の範囲チェック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TxtPosYLabel_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtPosYLabel.LostFocus

        Try
            InputRangeCheck(2)

            'If TxtPosYLabel.Text <> "" Then
            '    If CInt(TxtPosYLabel.Text) < 10 Or CInt(TxtPosYLabel.Text) > 160 Then
            '        MsgBox("ラベル貼付位置（垂直方向）の入力範囲は、10～160 です", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")
            '        'TxtPosYLabel.Focus()
            '    End If
            'Else
            '    MsgBox("ラベル貼付位置（垂直方向）の値を入力して下さい", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")
            '    'TxtPosYLabel.Focus()
            'End If

        Catch ex As Exception
            MsgBox("【TxtPosYLabel_LostFocus】" & ex.Message)
        End Try

    End Sub

    Private Sub TxtPosYLabel_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtPosYLabel.TextChanged

    End Sub

    Private Sub TxtPosXLabel_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPosXLabel.KeyPress
        ' 数字のみ入力可能
        e.Handled = CheckKeyPress("1", e)
    End Sub

    ''' <summary>
    ''' ラベル貼付位置（水平方向）の範囲チェック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TxtPosXLabel_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtPosXLabel.LostFocus

        Try
            InputRangeCheck(3)

            'If TxtPosXLabel.Text <> "" Then
            '    If CInt(TxtPosXLabel.Text) < 10 Or CInt(TxtPosXLabel.Text) > 135 Then
            '        MsgBox("ラベル貼付位置（水平方向）の入力範囲は、10～135 です", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")
            '        'TxtPosXLabel.Focus()
            '    End If
            'Else
            '    MsgBox("ラベル貼付位置（水平方向）の値を入力して下さい", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")
            '    'TxtPosXLabel.Focus()
            'End If

        Catch ex As Exception
            MsgBox("【TxtPosXLabel_LostFocus】" & ex.Message)
        End Try

    End Sub

    Private Sub TxtPosXLabel_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtPosXLabel.TextChanged

    End Sub

    Private Sub TxtPosYCapture_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPosYCapture.KeyPress
        ' 数字のみ入力可能
        e.Handled = CheckKeyPress("1", e)
    End Sub

    ''' <summary>
    ''' 宛名撮像位置（垂直方向）の範囲チェック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TxtPosYCapture_LostFocus(sender As Object, e As System.EventArgs) Handles TxtPosYCapture.LostFocus

        Try
            InputRangeCheck(4)

            'If TxtPosYCapture.Text <> "" Then
            '    If CInt(TxtPosYCapture.Text) < 71 Or CInt(TxtPosYCapture.Text) > 168 Then
            '        MsgBox("宛名撮像位置（垂直方向）の入力範囲は、71～168 です", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")
            '        'TxtPosYCapture.Focus()
            '    End If
            'Else
            '    MsgBox("宛名撮像位置（垂直方向）の値を入力して下さい", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")
            '    'TxtPosYCapture.Focus()
            'End If

        Catch ex As Exception
            MsgBox("【TxtPosYCapture_LostFocus】" & ex.Message)
        End Try

    End Sub

    Private Sub TxtPosYCapture_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtPosYCapture.TextChanged

    End Sub

    Private Sub TxtPosXCapture_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPosXCapture.KeyPress
        ' 数字のみ入力可能
        e.Handled = CheckKeyPress("1", e)
    End Sub

    ''' <summary>
    ''' 宛名撮像位置（水平方向）の範囲チェック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TxtPosXCapture_LostFocus(sender As Object, e As System.EventArgs) Handles TxtPosXCapture.LostFocus

        Try
            InputRangeCheck(5)

            'If TxtPosXCapture.Text <> "" Then
            '    If CInt(TxtPosXCapture.Text) < 60 Or CInt(TxtPosXCapture.Text) > 272 Then
            '        MsgBox("宛名撮像位置（水平方向）の入力範囲は、60～272 です", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")
            '        'TxtPosXCapture.Focus()
            '    End If
            'Else
            '    MsgBox("宛名撮像位置（水平方向）の値を入力して下さい", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")
            '    'TxtPosXCapture.Focus()
            'End If

        Catch ex As Exception
            MsgBox("【TxtPosXCapture_LostFocus】" & ex.Message)
        End Try

    End Sub

    Private Sub TxtPosXCapture_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtPosXCapture.TextChanged

    End Sub

    Private Sub TxtHikiuke_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtHikiuke.KeyPress
        ' 数字のみ入力可能
        e.Handled = CheckKeyPress("1", e)
    End Sub

    Private Sub TxtHikiuke_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtHikiuke.TextChanged

    End Sub

    Private Sub TxtCd_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCd.KeyPress
        ' 数字のみ入力可能
        e.Handled = CheckKeyPress("1", e)
    End Sub

    Private Sub TxtCd_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCd.TextChanged

    End Sub

    Private Sub BtnSendHikiuke_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSendHikiuke.Click

        Dim strSendData As String

        Try
            TxtCd.Text = (CInt(TxtHikiuke.Text) Mod 7).ToString("0")

            ' 2バイト
            strSendData = Chr(27) & "A"
            ' 37バイト
            strSendData &= GetBarCodeSendData(TxtHikiuke.Text)
            ' 45バイト
            strSendData &= GetCharSendData(TxtHikiuke.Text)
            ' 5バイト
            strSendData &= Chr(27) & "Q1"
            ' 2バイト
            strSendData &= Chr(27) & "Z"

            sendESCCommand(strSendData)

            TxtHikiuke.Text = (CInt(TxtHikiuke.Text) + 1).ToString("0000000000")
            TxtCd.Text = (CInt(TxtHikiuke.Text) Mod 7).ToString("0")

        Catch ex As Exception
            MsgBox("【BtnSendHikiuke_Click】" & ex.Message)
        End Try

    End Sub


    Private Sub sendESCCommand(ByVal strSendData As String)

        Dim strData As String = ""

        Try
            Dim dat As Byte() = System.Text.Encoding.GetEncoding("SHIFT-JIS").GetBytes("Zl" & strSendData & vbCr)
            SerialPort.Write(dat, 0, dat.GetLength(0))

            strData &= System.Text.Encoding.GetEncoding(932).GetString(dat)
            LstData.Items.Add(strData)
            LstData.SelectedIndex = LstData.Items.Count - 1

        Catch ex As Exception
            MsgBox("【sendESCCommand】" & ex.Message)
        End Try

    End Sub


    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click

        Dim strData As String = ""

        Try
            ' CANの送信
            Dim dat As Byte() = System.Text.Encoding.GetEncoding("SHIFT-JIS").GetBytes("Zl" & Chr(24) & vbCr)
            SerialPort.Write(dat, 0, dat.GetLength(0))

            strData &= System.Text.Encoding.GetEncoding(932).GetString(dat)
            LstData.Items.Add(strData)
            LstData.SelectedIndex = LstData.Items.Count - 1

        Catch ex As Exception
            MsgBox("【BtnCancel_Click】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 「デバイス」ボタン処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnDevice_Click(sender As System.Object, e As System.EventArgs) Handles BtnDevice.Click

        Try
            'Call SelectDeviceDialog()

            Panel1.Visible = True
            SelectDevice()
            'Cmb_Device.SelectedIndex = 0

            '///////////////////////
            '// カメラの初期化    //
            '///////////////////////
            'Call Start()

        Catch ex As Exception
            MsgBox("【BtnDevice_Click】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' フィーダー位置、ラベル貼付位置、宛名撮像位置の範囲チェック
    ''' </summary>
    ''' <param name="intCase"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function InputRangeCheck(ByVal intCase As Integer) As Boolean

        Try
            Select Case intCase
                Case 1
                    If TxtPosYFeeder.Text <> "" Then
                        If CInt(TxtPosYFeeder.Text) < 100 Or CInt(TxtPosYFeeder.Text) > 260 Then
                            MsgBox("封筒幅の入力範囲は、100～260 です", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")
                            Return False
                        End If
                    Else
                        MsgBox("封筒幅の値を入力して下さい", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")
                        Return False
                    End If

                Case 2
                    If TxtPosYLabel.Text <> "" Then
                        If CInt(TxtPosYLabel.Text) < 10 Or CInt(TxtPosYLabel.Text) > 145 Then
                            MsgBox("送方向（上辺）の入力範囲は、10～145 です", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")
                            Return False
                        End If
                    Else
                        MsgBox("送方向（上辺）の値を入力して下さい", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")
                        Return False
                    End If

                Case 3
                    If TxtPosXLabel.Text <> "" Then
                        If CInt(TxtPosXLabel.Text) < 10 Or CInt(TxtPosXLabel.Text) > 170 Then
                            MsgBox("横方向（左辺）の入力範囲は、10～170 です", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")
                            Return False
                        End If
                    Else
                        MsgBox("横方向（左辺）の値を入力して下さい", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")
                        Return False
                    End If

                Case 4
                    If TxtPosYCapture.Text <> "" Then
                        If CInt(TxtPosYCapture.Text) < 43 Or CInt(TxtPosYCapture.Text) > 255 Then
                            MsgBox("送方向（画角中央）の入力範囲は、43～255 です", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")
                            Return False
                        End If
                    Else
                        MsgBox("送方向（画角中央）の値を入力して下さい", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")
                        Return False
                    End If

                Case 5
                    If TxtPosXCapture.Text <> "" Then
                        If CInt(TxtPosXCapture.Text) < 50 Or CInt(TxtPosXCapture.Text) > 190 Then
                            MsgBox("横方向（画角中央）の入力範囲は、50～190 です", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")
                            Return False
                        End If
                    Else
                        MsgBox("横方向（画角中央）の値を入力して下さい", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")
                        Return False
                    End If

                Case Else

            End Select

        Catch ex As Exception
            MsgBox("【InpuRangeCheck】" & ex.Message)
            Return False
        End Try

        Return True

    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnCameraAdjust_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCameraAdjust.Click

        Try
            ' カメラ調整コマンド送信
            Call sendCommand(PubConstClass.CMD_SEND_e)

        Catch ex As Exception
            MsgBox("【BtnCameraAdjust_Click】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 「ラベル試貼り」ボタン処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnTestLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTestLabel.Click

        Dim strSendData As String

        Try
            ' 2バイト
            strSendData = Chr(27) & "A"

            If ChkPositiveDirection.Checked = True Then
                ' 正方向
                ' 45バイト
                strSendData &= GetTestLabelSendData("TEST LABEL")

                ' テスト印字（バーコード＋解説文字）
                'strSendData &= GetBarCodeSendData("1234567890")
                'strSendData &= GetCharSendData("1234567890")
            Else
                ' 逆方向
                strSendData &= GetTestLabel180SendData("TEST LABEL")

                ' テスト印字（バーコード＋解説文字）
                'strSendData &= GetBarCode180SendData("1234567890")
                'strSendData &= GetChar180SendData("1234567890")
            End If

            ' 5バイト
            strSendData &= Chr(27) & "Q1"
            ' 2バイト
            strSendData &= Chr(27) & "Z"

            sendESCCommand(strSendData)

            ' ラベル試貼りコマンド送信
            Call sendCommand(PubConstClass.CMD_SEND_i)

        Catch ex As Exception
            MsgBox("【BtnTestLabel_Click】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 「全項目コピー」ボタン処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnCopy_Click(sender As System.Object, e As System.EventArgs) Handles BtnCopy.Click

        Dim strMessage As String = ""

        Try
            strCopyItem(0) = TxtJobName.Text
            strMessage = strCopyItem(0) & vbCr

            strCopyItem(1) = TxtComment.Text
            strMessage &= strCopyItem(1) & vbCr

            strCopyItem(2) = CmbClassification.SelectedIndex.ToString("0")
            strMessage &= CmbClassification.Text & vbCr

            If RdoTeikei.Checked = True Then
                strCopyItem(3) = "0"
                strMessage &= "定形" & vbCr
            ElseIf RdoTeikeiGai.Checked = True Then
                strCopyItem(3) = "1"
                strMessage &= "定形外(規格内)" & vbCr
            Else
                strCopyItem(3) = "2"
                strMessage &= "定形外(規格外)" & vbCr
            End If

            strCopyItem(4) = TxtAddress1.Text
            strMessage &= strCopyItem(4) & vbCr

            strCopyItem(5) = TxtAddress2.Text
            strMessage &= strCopyItem(5) & vbCr

            strCopyItem(6) = TxtName.Text
            strMessage &= strCopyItem(6) & vbCr

            strCopyItem(7) = TxtPostName.Text
            strMessage &= strCopyItem(7) & vbCr

            strCopyItem(8) = TxtTekiyou.Text
            strMessage &= strCopyItem(8) & vbCr

            strCopyItem(9) = TxtYoushoPrice.Text
            strMessage &= strCopyItem(9) & vbCr

            strMessage &= vbCr & "上記項目をコピーしました。" & vbCr

            MsgBox(strMessage, CType(MsgBoxStyle.Information + MsgBoxStyle.OkOnly, MsgBoxStyle), "【コピー項目一覧】")

        Catch ex As Exception
            MsgBox("【BtnCopy_Click】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 「全項目ペースト」ボタン処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnPaste_Click(sender As System.Object, e As System.EventArgs) Handles BtnPaste.Click

        Try
            TxtJobName.Text = strCopyItem(0)
            TxtComment.Text = strCopyItem(1)

            CmbClassification.SelectedIndex = CInt(strCopyItem(2))

            If strCopyItem(3) = "0" Then
                ' 定形
                RdoTeikei.Checked = True
            ElseIf strCopyItem(3) = "1" Then
                ' 定形外（規格内）
                RdoTeikeiGai.Checked = True
            Else
                ' 定形外（規格外）
                RdoTeikeiGaiNonS.Checked = True
            End If

            TxtAddress1.Text = strCopyItem(4)
            TxtAddress2.Text = strCopyItem(5)
            TxtName.Text = strCopyItem(6)
            TxtPostName.Text = strCopyItem(7)
            TxtTekiyou.Text = strCopyItem(8)
            TxtYoushoPrice.Text = strCopyItem(9)

        Catch ex As Exception
            MsgBox("【BtnPaste_Click】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 「削除」ボタン処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnDelete_Click(sender As System.Object, e As System.EventArgs) Handles BtnDelete.Click

        Try
            PubConstClass.userNumber = (cmbJobList.SelectedIndex + 1).ToString

            Dim varRetVal As MsgBoxResult = MsgBox("削除しますか？", CType(MsgBoxStyle.Question + MsgBoxStyle.OkCancel, MsgBoxStyle), "確認")

            If varRetVal = Constants.vbOK Then

                ' 「はい」を選択
                PubConstClass.userNumber = (cmbJobList.SelectedIndex + 1).ToString
                Debug.Print("〓ユーザー番号削除：" & PubConstClass.userNumber)

                Dim strIniFilePath As String = IncludeTrailingPathDelimiter(Application.StartupPath) & PubConstClass.DEF_INI_FILENAME

                WritePrivateProfileString("System", "UserNo", "1", strIniFilePath)

                ' ユーザーデータ初期化処理
                Call deleteUserInfomation()

                WritePrivateProfileString("System", "UserNo", "1", strIniFilePath)

                ' ユーザーデータ書込処理
                Call putUserInfomation(cmbJobList.SelectedIndex + 1)

                ' 業務データコンボボックス登録処理
                EntryJobComboBox(cmbJobList)

                ' ユーザーデータ表示
                Call displayUserInfomation(cmbJobList.SelectedIndex + 1)

            End If

        Catch ex As Exception
            MsgBox("【BtnDelete_Click】" & ex.Message)
        End Try

    End Sub


    ''' <summary>
    ''' デバイスプロパティ表示
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Btn_Device_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Device.Click

        If mFlt Is Nothing Then Exit Sub

        'プロパティダイアログ表示
        If OpenDiaglog(mFlt, Me.Handle, mSelectedDeviceName) Then
            MsgBox("プロパティページは使用できません。")
        End If

    End Sub

    ''' <summary>
    ''' ピンプロパティ表示
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Btn_Pin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Pin.Click

        If mPin Is Nothing Then Exit Sub

        'プロパティダイアログ表示
        If OpenDiaglog(mPin, Me.Handle, GetPinName(mPin)) Then
            MsgBox("プロパティページは使用できません。")
        Else
            '現在のフォーマットが変更された可能性がある

            'フォーマットリスト更新
            If Pnl_Format.Visible Then
                MakeFormatList()
            End If
        End If

    End Sub

End Class