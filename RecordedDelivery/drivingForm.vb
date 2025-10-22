Option Explicit On
Option Strict On

Imports System.Runtime.InteropServices

Public Class DrivingForm

    Public rcvBufferData As String          ' 受信バッファ
    Public rcvDataCount As Long             ' 受信データカウンタ
    Public strYYYYMMDDvalue As String       ' 年月日（YYYYMMDD）格納変数
    Public strHHMMSSvalue As String         ' 時分秒（HHMMSS）格納変数
    Public strJobName As String             ' ジョブ名称
    Public lngOKCount As Long               ' OK処理カウンタ
    Public lngTranCount As Long             ' 処理カウンタ
    Public strSaveImageFileName As String   ' 保存画像ファイル名

    Public blnPrinting As Boolean           ' 印刷中フラグ
    Public blnPrintOKFlg As Boolean         ' 印刷OKフラグ
    Public strWeight As String
    Public strPrice As String
    Public strTranCnt(9) As String          ' 通数（定形）
    Public strAmount(9) As String           ' 合計金額（定数）
    Public strTranCntGai(8) As String       ' 通数（定形外）
    Public strAmountGai(8) As String        ' 合計金額（定数外）
    Public strTranCntNonS(8) As String      ' 通数（定形外／規格外）
    Public strAmountNonS(8) As String       ' 合計金額（定形外／規格外）

    Public strStUnderWRNum As String = "XXX-XX-XXXXX-X"
    Public strEnUnderWRNum As String = "XXX-XX-XXXXX-X"
    Public intTranALLCnt As Integer = 0
    Public intAmountALL As Integer = 0

    Private blnIsDispFlg As Boolean         ' 確認メッセージ表示フラグ
    Private objSync As Object
    Private objPrintSync As Object

    Private arNW7List As ArrayList = Nothing
    Private intNW7ListIndex As Integer = 0
    Private strSendNW7Data As String = ""           ' 次の送信バーコードデータ
    Private blnShiftF12Flg As Boolean = False       ' 「SHIFT」＋「F12」押下フラグ
    Private blnIsManualFeedFlg As Boolean = False   ' 手差し処理フラグ
    Private strCmpBarCodeData As String             ' ラベル印字したデータとバーコード読込したデータを比較する
    Private intKuwakeCnt As Integer                 ' 区分けカウンタ
    Private strYosoEndNumber As String              ' 予想終了番号
    Private blnIsNoCount As Boolean                 ' カウントアップしないフラグ（上書保存／ラベル印刷なし）

    '----------------------------------------------------------
    ' 非公開データ
    Private mGrp As IGraphBuilder           'IGraphBuilderインターフェース
    Private mSmp As ISampleGrabber          'ISampleGrabberインターフェース
    Private mFlt As IBaseFilter
    Private mPin As IPin
    Private mSelectedDeviceName As String
    '----------------------------------------------------------

    Private PrintString As String           ' 印字する文字データ

    '----------------------------------------------------------

    Private Delegate Sub Delegate_RcvDataToTextBox(data As String)
    Private Delegate Sub Delegate_RcvWeightDataToTextBox(data As String)
    Private Delegate Sub Delegate_Snap()

    '----------------------------------------------------------
    '選択開始
    Private Sub Start()

        Try
            '初期化
            ReleaseGraph()
            Cmb_Device.Items.Clear()
            Cmb_Pin.Items.Clear()
            Lst_Format.Items.Clear()
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

    Private Sub Cmb_Device_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmb_Device.SelectedIndexChanged
        SelectDevice()
    End Sub

    Private Sub Btn_PinFormat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_PinFormat.Click
        MakeFormatList()
    End Sub

    Private Sub Cmb_Pin_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmb_Pin.SelectedIndexChanged
        SelectPin()
    End Sub

    ''' <summary>
    ''' 「設定保存」ボタン処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Btn_Format_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Format.Click

        Try
            Dim idx As Integer = Lst_Format.SelectedIndex
            OutPutLogFile("■運転画面：「設定保存」ボタン押下【Lst_Format.SelectedIndex】" & idx)
            If idx < 0 Then
                MsgBox("フォーマットを選択して下さい。")
                Exit Sub
            End If

            Dim strIniFilePath As String = IncludeTrailingPathDelimiter(Application.StartupPath) & PubConstClass.DEF_INI_FILENAME
            ' デバイスインデックス（カメラ用）
            PubConstClass.intDeviceIdnex = Cmb_Device.SelectedIndex
            ' フォーマットインデックス（カメラ用）
            PubConstClass.intFormatIndex = Lst_Format.SelectedIndex
            OutPutLogFile("■運転画面（デバイス）：" & PubConstClass.intDeviceIdnex.ToString("0"))
            OutPutLogFile("■運転画面（出力フォーマット）：" & PubConstClass.intFormatIndex.ToString("0"))
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
    ''' フォームアクティブ処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub drivingForm_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated

        ' オペレータ情報の表示
        LblOperatorName.Text = GetOperatorInfomation()

    End Sub

    ''' <summary>
    ''' 「×」ボタンのキャンセル
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub drivingForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        ' 「×」ボタンのキャンセル
        e.Cancel = True

    End Sub

    ''' <summary>
    ''' 運転画面フォームでキーボード押下の判断を行う
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub DrivingForm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        ' SHIFTキーが押されているかチェック
        If e.Shift = True Then
            '「SHIFT」＋「F12」の確認
            If e.KeyCode = Keys.F12 Then
                '「F12」キーが押されているかチェック
                BtnBack.Enabled = True
                OutPutLogFile("〓運転画面で「SHIFT」＋「F12」が押されました")

                blnShiftF12Flg = True

            End If
        End If

    End Sub

    ''' <summary>
    ''' フォーム初期ロード処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub drivingForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        objSync = New Object
        objPrintSync = New Object

        blnPrinting = False
        DateTimeTimer.Interval = 1000
        DateTimeTimer.Enabled = True
        blnIsDispFlg = True

        Dim strArray() As String

        ' ListViewのカラムヘッダー設定
        lstGetDataView.View = View.Details
        Dim col1 As ColumnHeader = New ColumnHeader
        Dim col2 As ColumnHeader = New ColumnHeader
        Dim col3 As ColumnHeader = New ColumnHeader
        Dim col4 As ColumnHeader = New ColumnHeader
        Dim col5 As ColumnHeader = New ColumnHeader
        Dim col6 As ColumnHeader = New ColumnHeader
        Dim col7 As ColumnHeader = New ColumnHeader
        Dim col8 As ColumnHeader = New ColumnHeader
        Dim col9 As ColumnHeader = New ColumnHeader
        Dim col10 As ColumnHeader = New ColumnHeader
        Dim col11 As ColumnHeader = New ColumnHeader
        Dim col12 As ColumnHeader = New ColumnHeader

        col1.Text = "No"
        col2.Text = "業務名称"
        col3.Text = "取得時間"
        col4.Text = "引受番号"
        col5.Text = "重量"
        col6.Text = "料金"
        col7.Text = "ファイル名称"
        col8.Text = "種別"
        col9.Text = "支店コード"
        col10.Text = "支店名"
        col11.Text = "処理予定通数"
        col12.Text = "定形／定形外"

        col1.TextAlign = HorizontalAlignment.Center
        col2.TextAlign = HorizontalAlignment.Center
        col3.TextAlign = HorizontalAlignment.Center
        col4.TextAlign = HorizontalAlignment.Center
        col5.TextAlign = HorizontalAlignment.Center
        col6.TextAlign = HorizontalAlignment.Center
        col7.TextAlign = HorizontalAlignment.Left
        col8.TextAlign = HorizontalAlignment.Left
        col9.TextAlign = HorizontalAlignment.Left
        col10.TextAlign = HorizontalAlignment.Left
        col11.TextAlign = HorizontalAlignment.Left
        col12.TextAlign = HorizontalAlignment.Left

        col1.Width = 80     ' No
        col2.Width = 250    ' 業務名称
        col3.Width = 230    ' 取得時間
        col4.Width = 200    ' 引受番号
        col5.Width = 100    ' 重量
        col6.Width = 100    ' 料金
        col7.Width = 900    ' ファイル名称
        col8.Width = 150    ' 種別
        col9.Width = 150    ' 支店コード
        col10.Width = 150   ' 支店名
        col11.Width = 150   ' 処理予定通数
        col12.Width = 150   ' 定形／定形外

        Dim colHeader() As ColumnHeader = {col1, col2, col3, col4, col5, col6, col7, col8, col9, col10, col11, col12}
        lstGetDataView.Columns.AddRange(colHeader)

        ' 読取画像ファイル名称クリア
        lblImageFileName.Text = ""
        ' 最終引受番号クリア
        lblAcceptNum1.Text = ""
        lblAcceptNum2.Text = ""
        lblAcceptNum3.Text = ""
        lblAcceptNum4.Text = ""

        LblYoteiCnt.Text = ""
        LblZanCnt.Text = ""
        LblTodayTotal.Text = ""
        LblClassTotal.Text = ""

        LblSepNumber.Text = ""

        TxtPosYFeeder.Text = "0"
        TxtPosXLabel.Text = "0"
        TxtPosYLabel.Text = "0"
        TxtPosXCapture.Text = "0"
        TxtPosYCapture.Text = "0"

        btnReceive.Enabled = False      ' 「受領証印刷」ボタン使用不可
        BtnBack.Enabled = False         ' 「戻る」ボタン使用不可
        PubConstClass.blnIsErrorGamen = False

        ' デバッグ表示領域のクリアと非表示
        LblDebugTitle.Visible = False
        LstDebug.Visible = False

        ' エラーリセット送信フラグリセット
        PubConstClass.blnResetFlg = False
        ' 最印字処理フラグリセット
        PubConstClass.blnRePrintFlg = False
        ' メッセージ表示フラグリセット
        blnIsDispFlg = False

        ' 保存ログファイル
        With Now
            strYYYYMMDDvalue = String.Format("{0:D4}{1:D2}{2:D2}", .Year, .Month, .Day)
            strHHMMSSvalue = String.Format("{0:D2}{1:D2}{2:D2}", .Hour, .Minute, .Second)
        End With
        lblSaveLogFileName.Text = "処理ログ_" + strYYYYMMDDvalue + "_" + strHHMMSSvalue + ".dat"

        ' 受信コマンド表示領域クリア
        RcvTextBox.Text = "待機"

        ' 受信バッファのクリア
        rcvBufferData = ""
        ' 受信データカウンタ
        rcvDataCount = 0
        ' OKカウンタクリア
        lngOKCount = 0
        lblOKCount.Text = "0"

        ' 処理カウンタクリア
        lngTranCount = 0
        lblTranCount.Text = "0"

        ' ログデータ管理用配列の初期化
        Call InitLogControlArray()

        ' ページ情報初期化（0ページ）
        PubConstClass.lngPrintIndex = 0

        ' フォルダの存在チェック
        Dim hDirInfo As System.IO.DirectoryInfo
        hDirInfo = System.IO.Directory.CreateDirectory(IncludeTrailingPathDelimiter(PubConstClass.imgPath) & strYYYYMMDDvalue & "\" & strHHMMSSvalue)
        If hDirInfo.Exists = False Then
            ' フォルダの作成
            System.IO.Directory.CreateDirectory(IncludeTrailingPathDelimiter(PubConstClass.imgPath) & strYYYYMMDDvalue & "\" & strHHMMSSvalue)
        End If

        Try
            '' 前回設定値のロード
            'IcImagingControl1.LoadDeviceStateFromFile("device.xml", True)
            '' Let IC Imaging Control fill the complete form.
            ''IcImagingControl1.Dock = DockStyle.Fill
            '' Allow scaling.
            'IcImagingControl1.LiveDisplayDefault = False
            '' Scale the display to match the extents of the control window.
            'IcImagingControl1.LiveDisplayHeight = IcImagingControl1.Height
            'IcImagingControl1.LiveDisplayWidth = IcImagingControl1.Width
            ''IcImagingControl1.LiveDisplayHeight = Convert.ToInt32(Math.Round(IcImagingControl1.Height * 0.8))
            ''IcImagingControl1.LiveDisplayWidth = Convert.ToInt32(Math.Round(IcImagingControl1.Width * 0.8))

            '' ライブ開始
            'With IcImagingControl1
            '    If (.DeviceValid) Then
            '        .LiveStart()
            '        btnLiveStart.Text = "ライブ停止"
            '        'btnDevice.Enabled = False
            '        'btnProperty.Enabled = False
            '    Else
            '        MsgBox("「IcImagingControl1」が使用出来ません")
            '    End If
            'End With

            ' バージョン表示
            lblVersion.Text = PubConstClass.DEF_VERSION

            LblComment.Text = "（空き）"
            LblAddress1.Text = "（空き）"
            LblAddress2.Text = "（空き）"
            LblName.Text = "（空き）"
            LblPostName.Text = "（空き）"

            ' 業務データコンボボックス登録処理（種別と一致したデータのみ）
            EntryJobClassComboBox(CmbJobName, PubConstClass.pblClassForSiten)

            ' 業務（ユーザー）データ取得処理
            'Call getUserInfomation(CInt(PubConstClass.userNumber))
            ' 業務（ユーザー）データの先頭(1)とする。
            Call getUserInfomation(1)

            ' 支店コード（4桁＋2桁）
            LblSitenCd.Text = PubConstClass.pblSitenCode

            ' 支店名
            LblSitenName.Text = PubConstClass.pblSitenName

            ' 種別
            LblClass.Text = PubConstClass.pblClassForSiten
            ' 種別単位の重量及び料金データを読込む
            GetClassMasterData(PubConstClass.pblClassForSiten)
            ' 指定種別の現在の引受番号を取得する
            GetStartUnderWritingNumber(PubConstClass.pblClassForSiten)
            Debug_Print("運転時の引受番号：" & PubConstClass.dblStartUnderWritingNumber.ToString("000-00-00000") & "-" & (PubConstClass.dblStartUnderWritingNumber Mod 7).ToString("0"))
            Debug_Print("設定開始番号：" & PubConstClass.dblFirstUnderWritingNumber.ToString("000-00-00000") & "-" & (PubConstClass.dblFirstUnderWritingNumber Mod 7).ToString("0"))
            Debug_Print("設定終了番号：" & PubConstClass.dblEndUnderWritingNumber.ToString("000-00-00000") & "-" & (PubConstClass.dblEndUnderWritingNumber Mod 7).ToString("0"))

            ' 受領証面数設定
            If PubConstClass.pblPrintCountPerPage = "0" Then
                ' 15面
                Rdo15Face.Checked = True
            Else
                ' 8面
                Rdo8Face.Checked = True
            End If

            ' 処理予定数
            LblYoteiCnt.Text = PubConstClass.pblTranYoteiCount

            ' 残カウント
            LblZanCnt.Text = PubConstClass.pblTranYoteiCount

            ' 当日累計            
            LblTodayTotal.Text = PubConstClass.intTodayALLCount.ToString("0")

            ' 種別累計
            strArray = LblClass.Text.Split("："c)
            Select Case strArray(0)
                Case "30"
                    LblClassTotal.Text = PubConstClass.intKaniALLCount.ToString("0")
                Case "40"
                    LblClassTotal.Text = PubConstClass.intKaniALLCount.ToString("0")
                Case "50"
                    LblClassTotal.Text = PubConstClass.intTokuALLCount.ToString("0")
                Case "60"
                    LblClassTotal.Text = PubConstClass.intTokuALLCount.ToString("0")
                Case "150"
                    LblClassTotal.Text = PubConstClass.intMailALLCount.ToString("0")
                Case "160"
                    LblClassTotal.Text = PubConstClass.intMailALLCount.ToString("0")
            End Select

            ' 区分け通数
            LblSepNumber.Text = PubConstClass.pblKuwakeCnt
            ' 区分けカウンタのセット
            intKuwakeCnt = CInt(PubConstClass.pblKuwakeCnt)

            ' 重量表示クリア
            LblWeight.Text = "0"
            strWeight = LblWeight.Text

            ' 料金表示クリア
            LblPrice.Text = "0"
            strPrice = LblPrice.Text

            Dim dtNow As DateTime = DateTime.Now

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

            ' シリアルポートにデータ送信（通信確認コマンド）
            Call sendCommand(PubConstClass.CMD_ACK)

            ' シリアルポートにデータ送信（動作可能コマンド）
            Call sendCommand(PubConstClass.CMD_ENABLE)

            ' シリアルポートにデータ送信（設定情報コマンド）
            Call sendSettingInfomation()

            ' 運用記録ログ格納
            Call OutPutUseLogFile(lngOKCount.ToString & ":運転画面起動")

            ' 書込ファイル名の設定
            Dim strOutPutFileName As String = "C:\ADP\引受番号.csv"
            System.IO.File.Delete(strOutPutFileName)
            ' 書込データの設定
            Dim strPutMessage As String = ""

            arNW7List = New ArrayList
            Dim intOneRoundIndex As Integer = 0
            ' 追記モードで書き込む
            Using sw As New System.IO.StreamWriter(strOutPutFileName, True, System.Text.Encoding.Default)
                For N = 0 To CInt(PubConstClass.pblTranYoteiCount) - 1
                    'strPutMessage = "1," & (CDbl(PubConstClass.dblStartUnderWritingNumber.ToString("0000000000")) + N).ToString("0000000000")
                    If CDbl(PubConstClass.dblStartUnderWritingNumber.ToString("0000000000")) + N > PubConstClass.dblEndUnderWritingNumber Then
                        ' 予想終了引受番号が設定終了番号を超えた時の処理
                        strPutMessage = (CDbl(PubConstClass.dblFirstUnderWritingNumber.ToString("0000000000")) + intOneRoundIndex).ToString("0000000000") & ",1"
                        sw.WriteLine(strPutMessage)
                        arNW7List.Add((CDbl(PubConstClass.dblFirstUnderWritingNumber.ToString("0000000000")) + intOneRoundIndex).ToString("0000000000"))
                        intOneRoundIndex += 1
                    Else
                        strPutMessage = (CDbl(PubConstClass.dblStartUnderWritingNumber.ToString("0000000000")) + N).ToString("0000000000") & ",1"
                        sw.WriteLine(strPutMessage)
                        arNW7List.Add((CDbl(PubConstClass.dblStartUnderWritingNumber.ToString("0000000000")) + N).ToString("0000000000"))
                    End If
                Next
            End Using

            ' 引受番号の範囲設定情報を送信
            strPutMessage = PubConstClass.CMD_SEND_g
            strPutMessage &= arNW7List.Item(0).ToString & ","
            strPutMessage &= arNW7List.Item(arNW7List.Count - 1).ToString
            Call sendCommand(strPutMessage)

            intNW7ListIndex = 0
            strYosoEndNumber = arNW7List.Item(arNW7List.Count - 1).ToString
            Debug_Print("予想終了番号：" & strYosoEndNumber)

            'SendNW7BarCodeData(arNW7List.Item(intNW7ListIndex).ToString)
            'intNW7ListIndex += 1

            ' 次に送信する引受番号のバーコードデータの設定
            strSendNW7Data = arNW7List.Item(intNW7ListIndex).ToString

            ' 定形・定形外
            If PubConstClass.strPubTeikei = "0" Then
                LblTeikei.Text = "定形"
            Else
                LblTeikei.Text = "定形外"
            End If

            ' 正方向流しのチェック
            If PubConstClass.strPubPositiveDirection = "0" Then
                ' 逆方向流し
                LblPositiveDirection.Visible = False
            Else
                ' 正方向流し
                LblPositiveDirection.Visible = True
            End If

            '///////////////////////
            '// カメラの初期化    //
            '///////////////////////
            Call Start()

            blnIsDispFlg = False

        Catch ex As Exception
            MsgBox("【drivingForm_Load】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' ログデータ管理用配列の初期化
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub InitLogControlArray()

        Try
            For N = 0 To 5
                For K = 0 To 3
                    ' ログデータ管理用配列（引受番号／画像保存ファイル名／測定重量）の初期化
                    PubConstClass.strLogArrayList(N, K) = ""
                Next
            Next
            ' ログデータ管理用配列インデックスの初期化
            PubConstClass.intLogArrayListIndex = 0

        Catch ex As Exception
            MsgBox("【InitLogControlArray】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 引受番号のスタート番号を格納する
    ''' </summary>
    ''' <param name="strClass"></param>
    ''' <remarks></remarks>
    Private Sub SetStartUnderWritingNumber(ByVal strClass As String)

        Dim strCmp1Array() As String
        Dim strIniFilePath As String
        Dim strPutData As String
        Dim intCD As Integer

        Try
            ' 引受番号のスタート番号の格納
            strIniFilePath = IncludeTrailingPathDelimiter(Application.StartupPath) & PubConstClass.DEF_UNDER_WRITING_NUMBER

            If lblAcceptNum1.Text <> "" Then
                intCD = CInt(CDbl(strSendNW7Data) Mod 7)
                strPutData = "スタート番号," & CDbl(strSendNW7Data).ToString("000-00-00000") & "-" & intCD.ToString("0")
            Else
                ' 処理されずに戻る場合は何もしない
                OutPutLogFile("【運転画面】処理が０件だったので引受番号のスタート番号は格納しない")
                Exit Sub
            End If

            strCmp1Array = strClass.Split("："c)
            Select Case strCmp1Array(0)
                Case "30"
                    WritePrivateProfileString("Class30", "CurrentNum", strPutData, strIniFilePath)
                Case "40"
                    WritePrivateProfileString("Class30", "CurrentNum", strPutData, strIniFilePath)
                Case "50"
                    WritePrivateProfileString("Class50", "CurrentNum", strPutData, strIniFilePath)
                Case "60"
                    WritePrivateProfileString("Class50", "CurrentNum", strPutData, strIniFilePath)
                Case "150"
                    WritePrivateProfileString("Class150", "CurrentNum", strPutData, strIniFilePath)
                Case "160"
                    WritePrivateProfileString("Class150", "CurrentNum", strPutData, strIniFilePath)
                Case Else
                    OutPutLogFile("■種別（" & strClass & "）対象外により（" & strPutData & "）が更新できませんでした")
            End Select

        Catch ex As Exception
            MsgBox("【SetStartUnderWritingNumber】" & ex.Message)
        End Try

    End Sub


    ''' <summary>
    ''' デバッグメッセージの表示
    ''' </summary>
    ''' <param name="strMessage"></param>
    ''' <remarks></remarks>
    Private Sub Debug_Print(ByVal strMessage As String)

        Try
            LstDebug.Items.Add(Date.Now.ToString("HH:mm:ss") & " ⇒ " & strMessage)
            LstDebug.SelectedIndex = LstDebug.Items.Count - 1
            OutPutLogFile(strMessage)
        Catch ex As Exception
            MsgBox("【Debug_Print】" & ex.Message)
        End Try

    End Sub


    ''' <summary>
    ''' シリアルポートにデータ送信
    ''' </summary>
    ''' <param name="strSendData">送信データ</param>
    ''' <remarks></remarks>
    Public Sub sendCommand(ByVal strSendData As String)

        Try
            Dim dat As Byte() = System.Text.Encoding.GetEncoding("SHIFT-JIS").GetBytes(strSendData & vbCr)
            SerialPort.Write(dat, 0, dat.GetLength(0))
            Call OutPutLogFile("★送信：" & strSendData & "<CR>")
        Catch ex As Exception
            MsgBox("【sendCommand】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 設定情報（区分け）コマンド送信
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub sendSettingInfomation()

        ' シリアルポートにデータ送信（設定情報コマンド）
        Dim strSendData As String
        'strSendData = PubConstClass.CMD_SETINFO & LblSepNumber.Text & ","c & lblNGCount.Text.PadLeft(2, "0"c) & "," & PubConstClass.trigerTime.PadLeft(3, "0"c)
        strSendData = PubConstClass.CMD_SETINFO & LblSepNumber.Text
        Call sendCommand(strSendData)

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
                Call OutPutLogFile("■受信（パリティエラー）：" & data.ToString & "<CR>")
                BeginInvoke(New Delegate_RcvDataToTextBox(AddressOf Me.RcvDataToTextBox), "パリティエラー：" & "data.ToString" & ControlChars.Cr)
            End If

            ' 受信データの格納
            Call OutPutLogFile("■受信：" & data.ToString & "<CR>")
            BeginInvoke(New Delegate_RcvDataToTextBox(AddressOf Me.RcvDataToTextBox), data.ToString & ControlChars.Cr)

        Catch ex As TimeoutException
            ' 受信タイムアウトの処理（受信バッファをクリア）
            Dim strDiscardData As String = SerialPort.ReadExisting()
            ' ディスカードするデータ
            Call OutPutLogFile("■データ受信タイムアウトエラー：<CR>未受信で切り捨てたデータ：" & strDiscardData)
            BeginInvoke(New Delegate_RcvDataToTextBox(AddressOf Me.RcvDataToTextBox), "ZE999" & ControlChars.Cr)
        Catch ex As Exception
            MsgBox("【SerialPort_DataReceived】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 運転画面（drivingForm）を、Enabled=False にして呼び出す MsgBox(String) 関数
    ''' </summary>
    ''' <param name="strMessage">表示文字列</param>
    ''' <remarks></remarks>
    Private Sub MsgBoxModal(ByVal strMessage As String)

        Me.Enabled = False
        MsgBox(strMessage)

    End Sub

    ''' <summary>
    ''' 現在の分秒ミリを返す
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetMinSecMilli() As String
        Return Date.Now.Minute & ":" & Date.Now.Second & "." & Date.Now.Millisecond
    End Function

    ''' <summary>
    ''' 「Ａ」コマンド
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub myAProc()

        Try
            ' シリアルポートにデータ送信（通信確認コマンド）
            Call sendCommand(PubConstClass.CMD_ACK)

        Catch ex As Exception
            MsgBox("【myAProc】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 「Ｂ」コマンド（ラベル印字コマンド発行処理）
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub myBProc()

        Dim strMessage As String

        Try
            'If CInt(LblZanCnt.Text) <= 0 Then
            '    ' 停止コマンドを送付
            '    Call sendCommand(PubConstClass.CMD_STOP)
            '    strMessage = "予定通数のラベル印字を発行しました"
            '    MsgBox(strMessage, CType(MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, MsgBoxStyle), "【確認】")
            '    OutPutLogFile(strMessage)
            '    Exit Sub
            'End If
            ' 現在の引受番号をラベラ＆プリンタに送信
            SendNW7BarCodeData(strSendNW7Data)
            ' 印字直前の引受番号を確保する
            strCmpBarCodeData = strSendNW7Data

            If strYosoEndNumber = strSendNW7Data Then
                ' 停止コマンドを送付
                Call sendCommand(PubConstClass.CMD_STOP)

                ' 次の「＋」「－」ボタン処理の為に＋１する
                strSendNW7Data = (CDbl(strSendNW7Data) + 1).ToString("0000000000")

                strMessage = "予定数の処理が終了しました"
                'MsgBox(strMessage, CType(MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, MsgBoxStyle), "【確認】")
                If InformationForm.Visible = True Then
                    InformationForm.Dispose()
                End If
                InformationForm.strMessage = strMessage
                InformationForm.ShowDialog()

                ' 1.5秒後に動作可（Zd）コマンドを送信する。
                TimSendCom.Interval = 1500
                TimSendCom.Enabled = True

                If CInt(LblZanCnt.Text) <> 0 Then
                    strYosoEndNumber = (CDbl(strYosoEndNumber) + CInt(LblZanCnt.Text)).ToString("0000000000")
                    Debug_Print("【＋】ボタン：strYosoEndNumber：" & strYosoEndNumber)
                    OutPutLogFile("【＋】ボタン：strYosoEndNumber：" & strYosoEndNumber)
                End If

                Exit Sub
            End If

            ' 現在の引受番号が最終番号かチェック
            If strSendNW7Data = PubConstClass.dblEndUnderWritingNumber.ToString("0000000000") Then
                ' 最終番号なので開始番号へ戻す
                strSendNW7Data = PubConstClass.dblFirstUnderWritingNumber.ToString("0000000000")
            Else
                ' 最終番号では無いので＋１する
                strSendNW7Data = (CDbl(strSendNW7Data) + 1).ToString("0000000000")
            End If

            'If intNW7ListIndex <= CInt(PubConstClass.pblTranYoteiCount) - 1 Then
            '    SendNW7BarCodeData(arNW7List(intNW7ListIndex).ToString)
            '    intNW7ListIndex += 1
            'Else
            '    strMessage = "予定通数のラベル印字を発行しました"
            '    MsgBox(strMessage, CType(MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, MsgBoxStyle), "【デバッグエラー】")
            '    OutPutLogFile(strMessage)
            'End If

        Catch ex As Exception
            MsgBox("【myBProc】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 「Ｑ」コマンド
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub myQProc()
        Call OutPutLogFile("【正常処理数】" & lngOKCount.ToString & "件" & GetMinSecMilli() & "（ZQ受信：ストッパを下げる）")
    End Sub

    ''' <summary>
    ''' 「Ｇ」コマンド
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub myGProc()
        Call OutPutLogFile("【正常処理数】" & lngOKCount.ToString & "件" & GetMinSecMilli() & "（ZG受信：ピック開始）")
    End Sub

    ''' <summary>
    ''' 「Ｃ」コマンド
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub myCProc()

        Dim blnIsFind As Boolean = False

        Try
            Call OutPutLogFile("【正常処理数】" & lngOKCount.ToString & "件" & GetMinSecMilli() & "（ZC受信）")

            ' 保存ファイル名の作成
            With Now
                strSaveImageFileName = IncludeTrailingPathDelimiter(PubConstClass.imgPath) & _
                                       strYYYYMMDDvalue & "\" & strHHMMSSvalue & "\" & _
                                       "image_" & _
                                       String.Format("{0:D4}{1:D2}{2:D2}", .Year, .Month, .Day) & _
                                       "_" & _
                                       String.Format("{0:D2}{1:D2}{2:D2}", .Hour, .Minute, .Second) & _
                                       "_" & _
                                       String.Format("{0:00000}", rcvDataCount + 1) & _
                                       ".jpg"
            End With

            For N = 0 To PubConstClass.intLogArrayListIndex
                If PubConstClass.strLogArrayList(N, 1) = "" Then
                    ' 画像保存ファイル名の格納
                    PubConstClass.strLogArrayList(N, 1) = strSaveImageFileName
                    blnIsFind = True
                    Exit For
                End If
            Next
            If blnIsFind = False Then
                ' 停止コマンド送信
                Call sendCommand(PubConstClass.CMD_STOP)
                'MsgBox("【myCProc】画像ファイル名の保存が出来ませんでした", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, MsgBoxStyle), "【システムエラー】")
                Debug_Print("【myCProc】画像ファイル名の保存が出来ませんでした")
                OutPutLogFile("【myCProc】画像ファイル名の保存が出来ませんでした")
                ' 画像ファイルの保存が出来なかった時の画像をSnapする為、Exit Sub しない。
            End If

            TimSnapDelay.Interval = 300
            TimSnapDelay.Enabled = True

        Catch ex As Exception
            MsgBox("【myCProc】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 「Ｄ」コマンド
    ''' </summary>
    ''' <param name="data"></param>
    ''' <remarks></remarks>
    Private Sub myDProc(ByVal data As String)

        Dim strHikiukeNum As String
        Dim strMessage As String
        Dim strCD As String

        Try

            'SendNW7BarCodeData(arNW7List(intNW7ListIndex).ToString)
            'intNW7ListIndex += 1

            'If intNW7ListIndex <= CInt(PubConstClass.pblTranYoteiCount) - 1 Then
            '    SendNW7BarCodeData(arNW7List(intNW7ListIndex).ToString)
            '    intNW7ListIndex += 1
            'End If


            ' 引受番号の取得（ZD12345678901<CR>）
            strHikiukeNum = data.Substring(2, 11)

            ' 読取エラーチェック
            If strHikiukeNum = "-----------" Then

                ' 照合エラーコマンド送信
                Call sendCommand(PubConstClass.CMD_SEND_o & vbCr)

                ' 1秒後に停止コマンドを送信する
                Timer1.Interval = 1000
                Timer1.Enabled = True

                ' チェックデジットを求める
                strCD = (CDbl(strCmpBarCodeData) Mod 7).ToString("0")
                strMessage = "バーコードが読み取れません"
                'MsgBox(strMessage, CType(MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, MsgBoxStyle), "【読取エラー】")
                OutPutLogFile(strMessage.Replace(vbCr, ""))
                'If blnIsNoCount = False Then
                '    ' ラベル印字を行った場合は「－１」する
                '    strSendNW7Data = (CDbl(strSendNW7Data) - 1).ToString("0000000000")
                '    Debug_Print("【－１】" & strSendNW7Data)
                'End If

                If InformationForm.Visible = True Then
                    InformationForm.Dispose()
                End If
                InformationForm.strMessage = strMessage
                InformationForm.ShowDialog()

                ' 1.5秒後に動作可（Zd）コマンドを送信する。
                TimSendCom.Interval = 1500
                TimSendCom.Enabled = True

                Exit Sub
            End If

            ' 誤読エラーチェック
            If IsNumeric(strHikiukeNum) = False Then

                ' 照合エラーコマンド送信
                Call sendCommand(PubConstClass.CMD_SEND_o & vbCr)

                ' 1秒後に停止コマンドを送信する
                Timer1.Interval = 1000
                Timer1.Enabled = True

                ' チェックデジットを求める
                strCD = (CDbl(strCmpBarCodeData) Mod 7).ToString("0")
                strMessage = "読取データ「" & strCmpBarCodeData & strCD & "」に誤りがあります"
                'MsgBox(strMessage, CType(MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, MsgBoxStyle), "【誤読エラー】")
                OutPutLogFile(strMessage.Replace(vbCr, ""))

                'If blnIsNoCount = False Then
                '    ' ラベル印字を行った場合は「－１」する
                '    strSendNW7Data = (CDbl(strSendNW7Data) - 1).ToString("0000000000")
                '    Debug_Print("【－１】" & strSendNW7Data)
                'End If
                If InformationForm.Visible = True Then
                    InformationForm.Dispose()
                End If
                InformationForm.strMessage = strMessage
                InformationForm.ShowDialog()

                ' 1.5秒後に動作可（Zd）コマンドを送信する。
                TimSendCom.Interval = 1500
                TimSendCom.Enabled = True

                Exit Sub
            End If

            'If blnIsManualFeedFlg = False Then
            ' 手差し処理ではない場合に照合エラーチェック
            If blnIsNoCount = False Then
                ' ラベル印字ありの場合に照合エラーチェック
                If strHikiukeNum.Substring(0, 10) <> strCmpBarCodeData Then

                    ' 照合エラーコマンド送信
                    Call sendCommand(PubConstClass.CMD_SEND_o & vbCr)

                    ' 1秒後に停止コマンドを送信する
                    Timer1.Interval = 1000
                    Timer1.Enabled = True

                    ' チェックデジットを求める
                    strCD = (CDbl(strCmpBarCodeData) Mod 7).ToString("0")
                    strMessage = "印字した引受番号「" & strCmpBarCodeData & strCD & "」と" & vbCr & _
                                 "読取した引受番号「" & strHikiukeNum & "」が異なります"
                    ' 運用記録ログ格納
                    Call OutPutUseLogFile(lngOKCount.ToString & ":<<<<< " & strMessage)

                    'MsgBox(strMessage, CType(MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, MsgBoxStyle), "【照合エラー】")
                    OutPutLogFile(strMessage.Replace(vbCr, ""))
                    'If blnIsNoCount = False Then
                    '    ' ラベル印字を行った場合は「－１」する
                    '    strSendNW7Data = (CDbl(strSendNW7Data) - 1).ToString("0000000000")
                    '    Debug_Print("【－１】" & strSendNW7Data)
                    'End If
                    If InformationForm.Visible = True Then
                        InformationForm.Dispose()
                    End If
                    InformationForm.strMessage = strMessage
                    InformationForm.ShowDialog()

                    ' 1.5秒後に動作可（Zd）コマンドを送信する。
                    TimSendCom.Interval = 1500
                    TimSendCom.Enabled = True

                    Exit Sub
                End If
            End If

            Debug_Print("【開始　　番号】" & PubConstClass.dblStartUnderWritingNumber)
            Debug_Print("【予定終了番号】" & strYosoEndNumber)
            Debug_Print("【読取　　番号】" & strHikiukeNum.Substring(0, 10))

            ' 予定した引受番号の範囲内にあるかのチェック
            If PubConstClass.dblStartUnderWritingNumber > CDbl(strYosoEndNumber) Then
                '////////////////////////////////////////////
                '// （運転時の引受番号）＞（予想終了番号） //
                '////////////////////////////////////////////
                If (PubConstClass.dblStartUnderWritingNumber <= CDbl(strHikiukeNum.Substring(0, 10)) And _
                    CDbl(strHikiukeNum.Substring(0, 10)) <= CDbl(PubConstClass.dblEndUnderWritingNumber)) Or _
                    (PubConstClass.dblFirstUnderWritingNumber <= CDbl(strHikiukeNum.Substring(0, 10)) And _
                    CDbl(strHikiukeNum.Substring(0, 10)) <= CDbl(strYosoEndNumber)) Then
                    ''// 正常処理
                Else
                    ' 照合エラーコマンド送信
                    Call sendCommand(PubConstClass.CMD_SEND_o & vbCr)

                    ' 1秒後に停止コマンドを送信する
                    Timer1.Interval = 1000
                    Timer1.Enabled = True

                    ' チェックデジットを求める
                    strCD = (CDbl(strCmpBarCodeData) Mod 7).ToString("0")
                    strMessage = "読取した引受番号「" & strHikiukeNum & "」が範囲外です"
                    OutPutLogFile(strMessage.Replace(vbCr, ""))
                    If InformationForm.Visible = True Then
                        InformationForm.Dispose()
                    End If
                    InformationForm.strMessage = strMessage
                    InformationForm.ShowDialog()
                    Exit Sub
                End If
            Else
                '////////////////////////////////////////////
                '// （運転時の引受番号）＜（予想終了番号） //
                '////////////////////////////////////////////
                If PubConstClass.dblStartUnderWritingNumber <= CDbl(strHikiukeNum.Substring(0, 10)) And _
                    CDbl(strHikiukeNum.Substring(0, 10)) <= CDbl(strYosoEndNumber) Then
                    ''// 正常処理
                Else
                    ' 照合エラーコマンド送信
                    Call sendCommand(PubConstClass.CMD_SEND_o & vbCr)

                    ' 1秒後に停止コマンドを送信する
                    Timer1.Interval = 1000
                    Timer1.Enabled = True

                    ' チェックデジットを求める
                    strCD = (CDbl(strCmpBarCodeData) Mod 7).ToString("0")
                    strMessage = "読取した引受番号「" & strHikiukeNum & "」が範囲外です"
                    OutPutLogFile(strMessage.Replace(vbCr, ""))
                    If InformationForm.Visible = True Then
                        InformationForm.Dispose()
                    End If
                    InformationForm.strMessage = strMessage
                    InformationForm.ShowDialog()
                    Exit Sub
                End If
            End If

            ' 引受番号の格納
            PubConstClass.strLogArrayList(PubConstClass.intLogArrayListIndex, 0) = strHikiukeNum
            PubConstClass.intLogArrayListIndex += 1
            If PubConstClass.intLogArrayListIndex > 5 Then
                MsgBox("【PubConstClass.intLogArrayListIndex】が「" & PubConstClass.intLogArrayListIndex.ToString & "」となりました。", _
                       CType(MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, MsgBoxStyle), "【デバッグエラー】")
                OutPutLogFile("【PubConstClass.intLogArrayListIndex】が「" & PubConstClass.intLogArrayListIndex.ToString & "」となりました。")
            End If

            ' リストボックスに表示
            'Call RcvDataToListBox(data)
        Catch ex As Exception
            MsgBox("【myDProc】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 「Ｈ」コマンド
    ''' </summary>
    ''' <param name="data"></param>
    ''' <remarks></remarks>
    Private Sub myHProc(ByVal data As String)

        Dim strArray() As String

        Try
            strArray = data.Split(","c)
            TxtPosYFeeder.Text = strArray(0).Substring(2, 3)
            TxtPosYLabel.Text = strArray(1)
            TxtPosXLabel.Text = strArray(2)
            TxtPosYCapture.Text = strArray(3)
            TxtPosXCapture.Text = strArray(4)

        Catch ex As Exception
            MsgBox("【myHProc】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 「Ｔ」コマンド
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub myTProc()

        Try
            ' ステータスを「作動中」表示
            DispStatus("2")

            If blnIsManualFeedFlg = True Then
                '// 手差し処理なら下記のチェックは行わない
            Else
                If CDbl(LblZanCnt.Text) <= 0 Then
                    ' 残カウントが「0」以下の場合は動作しない
                    Call sendCommand(PubConstClass.CMD_STOP & vbCr)
                    Exit Sub
                End If
            End If

            ' シリアルポートにデータ送信（設定情報コマンド）
            Call sendSettingInfomation()

            ' <CAN>コマンド送信（ラベル＆プリンタの印字データクリア）
            Call SendCANCommand()

            ' フォルダの存在チェック
            Dim hDirInfo As System.IO.DirectoryInfo
            hDirInfo = System.IO.Directory.CreateDirectory(IncludeTrailingPathDelimiter(PubConstClass.imgPath) & strYYYYMMDDvalue & "\" & strHHMMSSvalue)
            If hDirInfo.Exists = False Then
                ' フォルダの作成
                System.IO.Directory.CreateDirectory(IncludeTrailingPathDelimiter(PubConstClass.imgPath) & strYYYYMMDDvalue & "\" & strHHMMSSvalue)
            End If

            BtnOnePage.Enabled = False
            BtnHandTran.Enabled = False
            BtnYoteiPlus.Enabled = False
            BtnYoteiMinus.Enabled = False
            BtnZanPlus.Enabled = False
            BtnZanMinus.Enabled = False
            BtnSendSetData.Enabled = False
            BtnRecieveSetData.Enabled = False
            Btn_Device.Enabled = False
            CmbJobName.Enabled = False
            ChkPositiveDirection.Enabled = False

            ' 運用記録ログ格納
            Call OutPutUseLogFile(lngOKCount.ToString & ":稼動開始")

        Catch ex As Exception
            MsgBox("【myTProc】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 「Ｐ」コマンド
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub myPProc()
        Try
            ' ステータスを「待機」表示
            DispStatus("1")

            BtnOnePage.Enabled = True
            BtnHandTran.Enabled = True
            BtnYoteiPlus.Enabled = True
            BtnYoteiMinus.Enabled = True
            BtnZanPlus.Enabled = True
            BtnZanMinus.Enabled = True
            BtnSendSetData.Enabled = True
            BtnRecieveSetData.Enabled = True
            Btn_Device.Enabled = True
            CmbJobName.Enabled = True
            ChkPositiveDirection.Enabled = True

            ' 運用記録ログ格納
            Call OutPutUseLogFile(lngOKCount.ToString & ":一時停止")

            ' <CAN>コマンド送信（ラベル＆プリンタの印字データクリア）
            Call SendCANCommand()

            ' ログデータ管理用配列の初期化
            Call InitLogControlArray()

        Catch ex As Exception
            MsgBox("【myPProc】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 「Ｅ」コマンド
    ''' </summary>
    ''' <param name="data"></param>
    ''' <remarks></remarks>
    Private Sub myEProc(ByVal data As String)

        Try
            ' エラー番号を取得する
            PubConstClass.strErrorNo = data.Substring(2, 3)
            ' ステータスを「エラー」表示
            DispStatus("3")

            ' 呼び出し元のフォームをディスエーブルする
            Me.Enabled = False

            'ErrorForm.Show()

            If PubConstClass.blnIsErrorGamen = False Then
                PubConstClass.blnIsErrorGamen = True
                ErrorForm.ShowDialog()
                PubConstClass.blnIsErrorGamen = False
            End If

            Dim strWork() As String
            For intLoopCnt = 0 To PubConstClass.intErrCnt - 1
                strWork = PubConstClass.strErrArray(intLoopCnt).Split(","c)
                If PubConstClass.strErrorNo = strWork(0) Then
                    ' 運用記録ログ格納
                    Call OutPutUseLogFile(lngOKCount.ToString & ":<<<<< " & strWork(1))
                    Exit For
                End If
            Next

            TimSendCom.Interval = 1500
            TimSendCom.Enabled = True
            ' 動作可能コマンドを１秒後に TimSendCom で送信する

        Catch ex As Exception
            MsgBox("【myEProc】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 「Ｎ」コマンド
    ''' </summary>
    ''' <param name="data"></param>
    ''' <remarks></remarks>
    Private Sub myNProc(ByVal data As String)

        Try
            ' ステータス領域の表示
            DispStatus(data.Substring(2, 1))
        Catch ex As Exception
            MsgBox("【myNProc】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 「Ｗ」コマンド
    ''' </summary>
    ''' <param name="data"></param>
    ''' <remarks></remarks>
    Private Sub myWProc(ByVal data As String)

        Dim blnIsFind As Boolean = False
        Dim strHikiukeNum As String
        Dim strArray() As String

        Try
            ' 引受番号の取得（ZW12345678901,12345<CR>）
            strHikiukeNum = data.Substring(2, 11)
            strArray = data.Split(","c)
            For N = 0 To PubConstClass.intLogArrayListIndex
                If PubConstClass.strLogArrayList(N, 0) = strHikiukeNum Then
                    PubConstClass.strLogArrayList(N, 2) = strArray(1)
                    blnIsFind = True
                    Exit For
                End If
            Next
            If blnIsFind = False Then
                ' 停止コマンド送信
                Call sendCommand(PubConstClass.CMD_STOP)
                'MsgBox("【myWProc】重量の保存が出来ませんでした", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, MsgBoxStyle), "【システムエラー】")
                Debug_Print("【myWProc】重量の保存が出来ませんでした")
                OutPutLogFile("【myWProc】重量の保存が出来ませんでした")
                Exit Sub
            End If

            '// 2017.07.04 Ver.B08c hayakawa 追加＆修正↓ここから
            Dim sWeight As String
            If PubConstClass.strLogArrayList(0, 2).Substring(4, 1) = "0" Then
                ' 切り上げしない
                sWeight = (CInt(PubConstClass.strLogArrayList(0, 2).Substring(0, 4))).ToString
            Else
                ' 切り上げ処理（＋１）
                sWeight = (CInt(PubConstClass.strLogArrayList(0, 2).Substring(0, 4)) + 1).ToString
            End If
            If GetPriceFromWeight(sWeight) = "範囲外" Then

                '// 2017.06.30 Ver.B08c hayakawa 追加↓ここから
                If PubConstClass.strPubTeikei = "0" Then
                    ' 定形で範囲外の処理
                    PubConstClass.strPubTeikei = "1"
                    If GetPriceFromWeight(sWeight) = "範囲外" Then
                        PubConstClass.strPubTeikei = "0"
                        Debug_Print("【定形→定形外（規格内）】重量範囲外で表示のみ：" & PubConstClass.strLogArrayList(0, 2))
                        Call DisplayToListBox(PubConstClass.strLogArrayList(0, 0), PubConstClass.strLogArrayList(0, 1), PubConstClass.strLogArrayList(0, 2))
                    Else
                        Debug_Print("【定形→定形外（規格内）】PubConstClass.strLogArrayList(0, 0) = " & PubConstClass.strLogArrayList(0, 0))
                        Debug_Print("【定形→定形外（規格内）】PubConstClass.strLogArrayList(0, 1) = " & PubConstClass.strLogArrayList(0, 1))
                        Debug_Print("【定形→定形外（規格内）】PubConstClass.strLogArrayList(0, 2) = " & PubConstClass.strLogArrayList(0, 2).Replace(vbCr, ""))
                        Debug_Print("【定形→定形外（規格内）】sWeight = " & sWeight)
                        Call RcvDataToListBox(PubConstClass.strLogArrayList(0, 0), PubConstClass.strLogArrayList(0, 1), PubConstClass.strLogArrayList(0, 2))
                    End If
                    PubConstClass.strPubTeikei = "0"

                ElseIf PubConstClass.strPubTeikei = "1" Then
                    ' 定形外で範囲外の処理
                    PubConstClass.strPubTeikei = "2"
                    If GetPriceFromWeight(sWeight) = "範囲外" Then
                        PubConstClass.strPubTeikei = "1"
                        Debug_Print("【定形外（規格内）→定形外（規格外）】重量範囲外で表示のみ：" & PubConstClass.strLogArrayList(0, 2))
                        Call DisplayToListBox(PubConstClass.strLogArrayList(0, 0), PubConstClass.strLogArrayList(0, 1), PubConstClass.strLogArrayList(0, 2))
                    Else
                        Debug_Print("【定形外（規格内）→定形外（規格外）】PubConstClass.strLogArrayList(0, 0) = " & PubConstClass.strLogArrayList(0, 0))
                        Debug_Print("【定形外（規格内）→定形外（規格外）】PubConstClass.strLogArrayList(0, 1) = " & PubConstClass.strLogArrayList(0, 1))
                        Debug_Print("【定形外（規格内）→定形外（規格外）】PubConstClass.strLogArrayList(0, 2) = " & PubConstClass.strLogArrayList(0, 2).Replace(vbCr, ""))
                        Debug_Print("【定形→定形外（規格内）】sWeight = " & sWeight)
                        Call RcvDataToListBox(PubConstClass.strLogArrayList(0, 0), PubConstClass.strLogArrayList(0, 1), PubConstClass.strLogArrayList(0, 2))
                    End If
                    PubConstClass.strPubTeikei = "1"
                Else
                    Debug_Print("重量範囲外で表示のみ：" & PubConstClass.strLogArrayList(0, 2))
                    Call DisplayToListBox(PubConstClass.strLogArrayList(0, 0), PubConstClass.strLogArrayList(0, 1), PubConstClass.strLogArrayList(0, 2))
                End If
                '// 2017.07.04 Ver.B08c hayakawa 追加＆修正↑ここまで

                'If PubConstClass.strPubTeikei = "1" Then
                '    PubConstClass.strPubTeikei = "2"
                '    If GetPriceFromWeight(PubConstClass.strLogArrayList(0, 2).Substring(0, 4)) = "範囲外" Then
                '        Debug_Print("【定形外（規格内）→定形外（規格外）】重量範囲外で表示のみ：" & PubConstClass.strLogArrayList(0, 2))
                '        Call DisplayToListBox(PubConstClass.strLogArrayList(0, 0), PubConstClass.strLogArrayList(0, 1), PubConstClass.strLogArrayList(0, 2))
                '    Else
                '        Debug_Print("【定形外（規格内）→定形外（規格外）】PubConstClass.strLogArrayList(0, 0)" & PubConstClass.strLogArrayList(0, 0))
                '        Debug_Print("【定形外（規格内）→定形外（規格外）】PubConstClass.strLogArrayList(0, 1)" & PubConstClass.strLogArrayList(0, 1))
                '        Debug_Print("【定形外（規格内）→定形外（規格外）】PubConstClass.strLogArrayList(0, 2)" & PubConstClass.strLogArrayList(0, 2))
                '        Call RcvDataToListBox(PubConstClass.strLogArrayList(0, 0), PubConstClass.strLogArrayList(0, 1), PubConstClass.strLogArrayList(0, 2))
                '    End If
                '    PubConstClass.strPubTeikei = "1"
                'Else
                '    Debug_Print("重量範囲外で表示のみ：" & PubConstClass.strLogArrayList(0, 2))
                '    Call DisplayToListBox(PubConstClass.strLogArrayList(0, 0), PubConstClass.strLogArrayList(0, 1), PubConstClass.strLogArrayList(0, 2))
                'End If

            Else
                ' 範囲外ではない場合の処理
                Call RcvDataToListBox(PubConstClass.strLogArrayList(0, 0), PubConstClass.strLogArrayList(0, 1), PubConstClass.strLogArrayList(0, 2))
            End If

        Catch ex As Exception
            'MsgBox("【myWProc】" & ex.Message)
            OutPutLogFile("【myWProc】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 「Ｌ」コマンド
    ''' </summary>
    ''' <param name="data"></param>
    ''' <remarks></remarks>
    Private Sub myLProc(ByVal data As String)

        Try
            ' ACK データ受信の有無を確認
            If data.Substring(data.Length - 2, 1) = Chr(6) Then
                '「Ｄ」コマンドで送信する様に変更
                'If intNW7ListIndex <= CInt(PubConstClass.pblTranYoteiCount) - 1 Then
                '    SendNW7BarCodeData(arNW7List(intNW7ListIndex).ToString)
                '    intNW7ListIndex += 1
                'End If
                OutPutLogFile("<ACK>受信")
            End If

        Catch ex As Exception
            MsgBox("【myLProc】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 「Ｒ」コマンド
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub myRProc()

        Try
            ' シリアルポートにデータ送信（リセットコマンド）
            Call sendCommand(PubConstClass.CMD_SEND_r)
            If ErrorForm.Visible = True Then
                Me.Enabled = True
                ErrorForm.Dispose()
            End If
        Catch ex As Exception
            MsgBox("【myRProc】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' ステータス領域の表示
    ''' </summary>
    ''' <param name="strId"></param>
    ''' <remarks></remarks>
    Private Sub DispStatus(ByVal strId As String)

        Try
            Select Case strId
                Case "0"
                    RcvTextBox.Text = "設定中"
                    RcvTextBox.BackColor = Color.Yellow
                    RcvTextBox.ForeColor = Color.Blue
                Case "1"
                    RcvTextBox.Text = "待機中"
                    RcvTextBox.BackColor = Color.LightGray
                    RcvTextBox.ForeColor = Color.Black
                Case "2"
                    RcvTextBox.Text = "運転中"
                    RcvTextBox.BackColor = Color.Green
                    RcvTextBox.ForeColor = Color.Yellow
                Case "3"
                    RcvTextBox.Text = "エラー"
                    RcvTextBox.BackColor = Color.Red
                    RcvTextBox.ForeColor = Color.White
                Case Else

            End Select
        Catch ex As Exception
            MsgBox("【DispStatus】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 受信データによる各コマンド処理
    ''' </summary>
    ''' <param name="data">受信した文字列</param>
    ''' <remarks></remarks>
    Private Sub RcvDataToTextBox(ByVal data As String)

        Try
            '受信データをテキストボックスの最後に追記する。
            If IsNothing(data) = False Then
                'Debug_Print(data.Replace(ControlChars.Cr, "<CR>"))
                If data.Length > 2 Then
                    Select Case data.Substring(0, 2)
                        Case "ZA"
                            myAProc()
                        Case "ZB"
                            myBProc()
                        Case "ZL"
                            myLProc(data)
                        Case "ZQ"
                            myQProc()   '// デバッグコマンド
                        Case "ZG"
                            myGProc()   '// デバッグコマンド
                        Case "ZC"
                            myCProc()       ' カメラトリガー要求コマンド
                        Case "ZD"
                            myDProc(data)   ' 読取データ送信コマンド
                        Case "ZH"
                            myHProc(data)
                        Case "ZT"
                            myTProc()       ' 作動要求コマンド
                        Case "ZP"
                            myPProc()       ' 停止要求コマンド
                        Case "ZE"
                            myEProc(data)   ' 装置エラーコマンド
                        Case "ZN"
                            myNProc(data)   ' 装置状態表示コマンド
                        Case "ZW"
                            myWProc(data)   ' 測定重量送信コマンド
                        Case "ZR"
                            myRProc()
                        Case Else
                            ' テキストボックスに表示
                            'Debug_Print("未定義コマンド受信：" & data.ToString)
                            ' 受信データの格納
                            Call OutPutLogFile("【DrivingForm】未定義コマンド受信：" + data.Replace(ControlChars.Cr, "<CR>"))
                    End Select
                End If
            End If

        Catch ex As Exception
            MsgBox("【RcvDataToTextBox】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="data"></param>
    ''' <remarks></remarks>
    Private Sub RcvWeightDataToTextBox(ByVal data As String)

        Dim strRecData As String
        Dim strArray() As String

        Try
            '受信データをテキストボックスの最後に追記する。
            If IsNothing(data) = False Then

                strRecData = data.Replace(vbLf, "").Replace(ControlChars.Cr, "<CR>")
                Debug.Print("■strRecData：" & strRecData)

                If strRecData.Length > 1 Then

                    Select Case strRecData.Substring(0, 1)

                        Case "+"
                            strArray = Split(strRecData, " "c)
                            LblWeight.Text = CDbl(strArray(0).Replace("+", "")).ToString

                            Btn_Snap.PerformClick()

                        Case Else
                            ' テキストボックスに表示
                            Debug_Print("【重量計から】未定義コマンド受信：" & data.Replace(vbLf, "<LF>").Replace(vbCr, "<CR>").ToString)

                            ' 受信データの格納
                            Call OutPutLogFile("■【重量計から】未定義コマンド受信：" & data.Replace(vbLf, "<LF>").Replace(vbCr, "<CR>").ToString)

                    End Select

                End If
            End If

        Catch ex As Exception

            MsgBox("【RcvWeightDataToTextBox】" & ex.Message)

        End Try

    End Sub

    ''' <summary>
    ''' リストボックスに表示のみを行う
    ''' </summary>
    ''' <param name="strHikiuke">引受番号</param>
    ''' <param name="strFileName">保存画像ファイル名（フルパス）</param>
    ''' <param name="strWeight">測定重量</param>
    ''' <remarks></remarks>
    Private Sub DisplayToListBox(ByVal strHikiuke As String, ByVal strFileName As String, ByVal strWeight As String)

        Dim col(11) As String
        Dim itm As ListViewItem
        Dim strOutPutData As String
        Dim blnIsFindFlg As Boolean = False ' 同一引受番号の合致フラグ

        Try

            ' ListViewの行追加 
            ' 処理番号
            'col(0) = String.Format("{0:00000}", rcvDataCount)
            col(0) = (lstGetDataView.Items.Count + 1).ToString("00000")
            strOutPutData = col(0) + ","

            ' 業務名称
            col(1) = CmbJobName.Text
            strOutPutData = strOutPutData + col(1) + ","

            ' 処理日付
            col(2) = Date.Now.ToString
            strOutPutData = strOutPutData + col(2) + ","

            lblOKCount.Text = lngOKCount.ToString
            lblTranCount.Text = lngTranCount.ToString

            ' 引受番号
            lblAcceptNum1.Text = strHikiuke.Substring(0, 3)
            lblAcceptNum2.Text = strHikiuke.Substring(3, 2)
            lblAcceptNum3.Text = strHikiuke.Substring(5, 5)
            lblAcceptNum4.Text = strHikiuke.Substring(10, 1)
            col(3) = lblAcceptNum1.Text & "-" & lblAcceptNum2.Text & "-" & lblAcceptNum3.Text & "-" & lblAcceptNum4.Text
            strOutPutData = strOutPutData + col(3) + ","

            ' 重量データ（整数部のみ切出す）
            col(4) = strWeight.Substring(0, 4)
            LblWeight.Text = col(4)
            strOutPutData = strOutPutData + col(4) & ","

            ' 料金データ
            col(5) = GetPriceFromWeight(col(4))
            LblPrice.Text = col(5)
            strOutPutData = strOutPutData + col(5) & ","

            ' 画像ファイル名称
            col(6) = strFileName
            strOutPutData = strOutPutData + col(6) + ","

            ' 種別　　　　　：pblClassForSiten
            col(7) = PubConstClass.pblClassForSiten
            strOutPutData = strOutPutData + col(7) + ","

            ' 支店コード　　：pblSitenCode
            col(8) = PubConstClass.pblSitenCode
            strOutPutData = strOutPutData + col(8) + ","

            ' 支店名　　　　：pblSitenName
            col(9) = PubConstClass.pblSitenName
            strOutPutData = strOutPutData + col(9) + ","

            ' 処理予定通数　：pblTranYoteiCount
            col(10) = PubConstClass.pblTranYoteiCount
            strOutPutData = strOutPutData + col(10) + ","

            ' 定形・定形外
            If PubConstClass.strPubTeikei = "0" Then
                col(11) = "定形"
            Else
                col(11) = "定形外"
            End If
            strOutPutData = strOutPutData + col(11) + ","

            itm = New ListViewItem(col)
            lstGetDataView.Items.Add(itm)
            lstGetDataView.Items(lstGetDataView.Items.Count - 1).Selected = True
            lstGetDataView.Items(lstGetDataView.Items.Count - 1).Focused = True
            lstGetDataView.Select()
            lstGetDataView.Items(lstGetDataView.Items.Count - 1).EnsureVisible()

            ' 検査ログ書込処理
            'Call OutPutKensaLogFile(strYYYYMMDDvalue, strHHMMSSvalue, strOutPutData)

            Call ShiftLogArrayList()

        Catch ex As Exception
            MsgBox("【DisplayToListBox】" & ex.Message)
            Call OutPutLogFile("【DisplayToListBox】" & ex.Message)
        End Try


    End Sub


    ''' <summary>
    ''' データの表示とログデータの保存処理
    ''' </summary>
    ''' <param name="strHikiuke">引受番号</param>
    ''' <param name="strFileName">保存画像ファイル名（フルパス）</param>
    ''' <param name="strWeight">測定重量</param>
    ''' <remarks></remarks>
    Private Sub RcvDataToListBox(ByVal strHikiuke As String, ByVal strFileName As String, ByVal strWeight As String)

        Dim col(11) As String
        Dim itm As ListViewItem
        Dim strOutPutData As String
        Dim blnIsFindFlg As Boolean = False ' 同一引受番号の合致フラグ
        Dim strArray() As String
        Dim strMessage As String

        Try
            If blnIsNoCount = False Then
                '// 手差しでラベル印字を行う処理 //
                '// 通常処理 //////////////////////
                ' 受信データ回数のインクリメント
                rcvDataCount = rcvDataCount + 1
                ' OK処理カウンタ
                lngOKCount += 1
                ' 処理カウンタ
                lngTranCount += 1
                LblZanCnt.Text = (CInt(LblZanCnt.Text) - 1).ToString
                ' 残カウントが「1」以下かチェック
                If CInt(LblZanCnt.Text) <= 1 Then
                    ' 停止コマンドを送付
                    Call sendCommand(PubConstClass.CMD_STOP)
                End If
                ' 当日累計インクリメント
                PubConstClass.intTodayALLCount = PubConstClass.intTodayALLCount + 1
                LblTodayTotal.Text = PubConstClass.intTodayALLCount.ToString("0")

                ' 種別累計
                strArray = LblClass.Text.Split("："c)
                Select Case strArray(0)
                    Case "30"
                        PubConstClass.intKaniALLCount = PubConstClass.intKaniALLCount + 1
                        LblClassTotal.Text = PubConstClass.intKaniALLCount.ToString("0")
                    Case "40"
                        PubConstClass.intKaniALLCount = PubConstClass.intKaniALLCount + 1
                        LblClassTotal.Text = PubConstClass.intKaniALLCount.ToString("0")
                    Case "50"
                        PubConstClass.intTokuALLCount = PubConstClass.intTokuALLCount + 1
                        LblClassTotal.Text = PubConstClass.intTokuALLCount.ToString("0")
                    Case "60"
                        PubConstClass.intTokuALLCount = PubConstClass.intTokuALLCount + 1
                        LblClassTotal.Text = PubConstClass.intTokuALLCount.ToString("0")
                    Case "150"
                        PubConstClass.intMailALLCount = PubConstClass.intMailALLCount + 1
                        LblClassTotal.Text = PubConstClass.intMailALLCount.ToString("0")
                    Case "160"
                        PubConstClass.intMailALLCount = PubConstClass.intMailALLCount + 1
                        LblClassTotal.Text = PubConstClass.intMailALLCount.ToString("0")
                End Select

            End If

            ' ListViewの行追加 
            ' 処理番号
            'col(0) = String.Format("{0:00000}", rcvDataCount)
            col(0) = (lstGetDataView.Items.Count + 1).ToString("00000")
            strOutPutData = col(0) + ","

            ' 業務名称
            col(1) = CmbJobName.Text
            strOutPutData = strOutPutData + col(1) + ","

            ' 処理日付
            col(2) = Date.Now.ToString
            strOutPutData = strOutPutData + col(2) + ","

            lblOKCount.Text = lngOKCount.ToString
            lblTranCount.Text = lngTranCount.ToString

            ' 引受番号
            lblAcceptNum1.Text = strHikiuke.Substring(0, 3)
            lblAcceptNum2.Text = strHikiuke.Substring(3, 2)
            lblAcceptNum3.Text = strHikiuke.Substring(5, 5)
            lblAcceptNum4.Text = strHikiuke.Substring(10, 1)
            col(3) = lblAcceptNum1.Text & "-" & lblAcceptNum2.Text & "-" & lblAcceptNum3.Text & "-" & lblAcceptNum4.Text
            strOutPutData = strOutPutData + col(3) + ","

            ' 重量データ（整数部のみ切出す）
            'col(4) = strWeight.Substring(0, 4)
            If strWeight.Substring(4, 1) = "0" Then
                ' 切り上げしない
                col(4) = (CInt(strWeight.Substring(0, 4))).ToString
            Else
                ' 切り上げ処理（＋１）
                col(4) = (CInt(strWeight.Substring(0, 4)) + 1).ToString
            End If
            LblWeight.Text = col(4)
            strOutPutData = strOutPutData + col(4) & ","

            ' 料金データ
            col(5) = GetPriceFromWeight(col(4))
            LblPrice.Text = col(5)
            strOutPutData = strOutPutData + col(5) & ","

            ' 画像ファイル名称
            col(6) = strFileName
            strOutPutData = strOutPutData + col(6) + ","

            ' 種別　　　　　：pblClassForSiten
            col(7) = PubConstClass.pblClassForSiten
            strOutPutData = strOutPutData + col(7) + ","

            ' 支店コード　　：pblSitenCode
            col(8) = PubConstClass.pblSitenCode
            strOutPutData = strOutPutData + col(8) + ","

            ' 支店名　　　　：pblSitenName
            col(9) = PubConstClass.pblSitenName
            strOutPutData = strOutPutData + col(9) + ","

            ' 処理予定通数　：pblTranYoteiCount
            col(10) = PubConstClass.pblTranYoteiCount
            strOutPutData = strOutPutData + col(10) + ","

            ' 定形・定形外
            If PubConstClass.strPubTeikei = "0" Then
                col(11) = "定形"
            ElseIf PubConstClass.strPubTeikei = "1" Then
                col(11) = "定形外(規格内)"
            Else
                col(11) = "定形外(規格外)"
            End If
            strOutPutData = strOutPutData + col(11) + ","

            ' OK分の表示
            If blnIsManualFeedFlg = True And blnIsNoCount = True Then
                ' 手差処理でラベル印字を行わない場合は同一引受番号の下記の情報を書き換える
                If lstGetDataView.Items.Count > 0 Then
                    For N = 0 To lstGetDataView.Items.Count - 1
                        ' 引受番号が合致するデータをチェック
                        If lstGetDataView.Items(N).SubItems(3).Text = col(3) Then
                            ' 業務名の書き換え
                            lstGetDataView.Items(N).SubItems(1).Text = col(1)
                            ' 取得時間の書き換え
                            lstGetDataView.Items(N).SubItems(2).Text = col(2)
                            ' 重量の書き換え
                            lstGetDataView.Items(N).SubItems(4).Text = col(4)
                            ' 料金の書き換え
                            lstGetDataView.Items(N).SubItems(5).Text = col(5)
                            ' 画像保存ファイル名の書き換え
                            lstGetDataView.Items(N).SubItems(6).Text = col(6)
                            ' 定形・定形外の書き換え
                            lstGetDataView.Items(N).SubItems(11).Text = col(11)
                            ' 対象行の背景を薄いピンクに設定
                            lstGetDataView.Items(N).BackColor = Color.LightPink
                            blnIsFindFlg = True

                            ' 全ての表示データを書き換える
                            Call OutPutALLKensaLogFile(strYYYYMMDDvalue, strHHMMSSvalue)

                            Exit For
                        End If
                    Next
                End If
                ' 手差しフラグをＯＦＦ
                blnIsManualFeedFlg = False
                blnIsNoCount = False

                If blnIsFindFlg = False Then
                    ' 受信データ回数のインクリメント
                    rcvDataCount = rcvDataCount + 1
                    ' OK処理カウンタ
                    lngOKCount += 1
                    ' 処理カウンタ
                    lngTranCount += 1
                    LblZanCnt.Text = (CInt(LblZanCnt.Text) - 1).ToString
                    ' 残カウントが「1」以下かチェック
                    If CInt(LblZanCnt.Text) <= 1 Then
                        ' 停止コマンドを送付
                        Call sendCommand(PubConstClass.CMD_STOP)
                    End If
                    ' 当日累計インクリメント
                    PubConstClass.intTodayALLCount = PubConstClass.intTodayALLCount + 1
                    LblTodayTotal.Text = PubConstClass.intTodayALLCount.ToString("0")

                    ' 種別累計
                    strArray = LblClass.Text.Split("："c)
                    Select Case strArray(0)
                        Case "30"
                            PubConstClass.intKaniALLCount = PubConstClass.intKaniALLCount + 1
                            LblClassTotal.Text = PubConstClass.intKaniALLCount.ToString("0")
                        Case "40"
                            PubConstClass.intKaniALLCount = PubConstClass.intKaniALLCount + 1
                            LblClassTotal.Text = PubConstClass.intKaniALLCount.ToString("0")
                        Case "50"
                            PubConstClass.intTokuALLCount = PubConstClass.intTokuALLCount + 1
                            LblClassTotal.Text = PubConstClass.intTokuALLCount.ToString("0")
                        Case "60"
                            PubConstClass.intTokuALLCount = PubConstClass.intTokuALLCount + 1
                            LblClassTotal.Text = PubConstClass.intTokuALLCount.ToString("0")
                        Case "150"
                            PubConstClass.intMailALLCount = PubConstClass.intMailALLCount + 1
                            LblClassTotal.Text = PubConstClass.intMailALLCount.ToString("0")
                        Case "160"
                            PubConstClass.intMailALLCount = PubConstClass.intMailALLCount + 1
                            LblClassTotal.Text = PubConstClass.intMailALLCount.ToString("0")
                    End Select

                End If

            Else
                blnIsFindFlg = False
            End If

            If blnIsFindFlg = False Then

                intKuwakeCnt -= 1
                If intKuwakeCnt = 0 Then
                    ' 区分けカウンタのセット
                    intKuwakeCnt = CInt(PubConstClass.pblKuwakeCnt)
                    ' 区分けコマンドの送信
                    Call sendCommand(PubConstClass.CMD_SEND_n)
                End If

                itm = New ListViewItem(col)
                lstGetDataView.Items.Add(itm)
                lstGetDataView.Items(lstGetDataView.Items.Count - 1).Selected = True
                lstGetDataView.Items(lstGetDataView.Items.Count - 1).Focused = True
                lstGetDataView.Select()
                lstGetDataView.Items(lstGetDataView.Items.Count - 1).EnsureVisible()
                ' 検査ログ書込処理
                Call OutPutKensaLogFile(strYYYYMMDDvalue, strHHMMSSvalue, strOutPutData)

                blnIsNoCount = False

            End If

            ' 内部カウンタの値を最後に確実に「正常発行」「投入数」に表示する
            lblOKCount.Text = lngOKCount.ToString
            lblTranCount.Text = lngTranCount.ToString

            Call ShiftLogArrayList()

        Catch ex As Exception
            strMessage = "【RcvDataToListBox】" & ex.Message
            Call OutPutLogFile(strMessage)
            MsgBox(strMessage)
        End Try

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="strYYYYMMDDvalue"></param>
    ''' <param name="strHHMMSSvalue"></param>
    ''' <remarks></remarks>
    Private Sub OutPutALLKensaLogFile(ByVal strYYYYMMDDvalue As String, ByVal strHHMMSSvalue As String)

        Dim strOutPutFolder As String
        Dim strOutPutFileName As String
        Dim strPutData As String
        Dim strMessage As String

        Try
            'Dim dtNow As DateTime = DateTime.Now

            ' 格納フォルダ名の設定
            strOutPutFolder = IncludeTrailingPathDelimiter(PubConstClass.imgPath) & strYYYYMMDDvalue & "\"
            ' 格納ファイル名の設定
            strOutPutFileName = "稼動ログ_" & strYYYYMMDDvalue & "_" & strHHMMSSvalue & ".LOG"
            '////////////////////////////////////////////////
            '// 上書きモードで全ての表示データを書き変える //
            '////////////////////////////////////////////////
            '    0,     1,                 2,             3,   4,   5,                                                            6,           7,8,   9,10,  11,12
            '00000,019：O,2015/09/22 9:17:46,358-39-00406-2,1234,1030,C:\RECDEL\IMG\20150922\091734\image_20150922_091746_00001.jpg,50：特定記録,1,本店,10,定形,
            Using sw As New System.IO.StreamWriter(strOutPutFolder & strOutPutFileName, False, System.Text.Encoding.Default)
                For N = 0 To lstGetDataView.Items.Count - 1
                    strPutData = ""
                    For K = 0 To 11
                        strPutData = strPutData & lstGetDataView.Items(N).SubItems(K).Text & ","
                    Next
                    sw.WriteLine(strPutData)
                Next
            End Using

        Catch ex As Exception
            strMessage = "【OutPutALLKensaLogFile】" & ex.Message
            Call OutPutLogFile(strMessage)
            MsgBox(strMessage)
        End Try

    End Sub

    ''' <summary>
    ''' ログデータ管理用配列（引受番号／画像保存ファイル名／測定重量）のシフト処理。
    ''' ログデータ管理用配列インデックスのデクリメント。
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ShiftLogArrayList()

        Try
            For N = 0 To PubConstClass.intLogArrayListIndex - 1
                PubConstClass.strLogArrayList(N, 0) = PubConstClass.strLogArrayList(N + 1, 0)
                PubConstClass.strLogArrayList(N, 1) = PubConstClass.strLogArrayList(N + 1, 1)
                PubConstClass.strLogArrayList(N, 2) = PubConstClass.strLogArrayList(N + 1, 2)
            Next
            PubConstClass.strLogArrayList(PubConstClass.intLogArrayListIndex, 0) = ""
            PubConstClass.strLogArrayList(PubConstClass.intLogArrayListIndex, 1) = ""
            PubConstClass.strLogArrayList(PubConstClass.intLogArrayListIndex, 2) = ""

            PubConstClass.intLogArrayListIndex -= 1
            If PubConstClass.intLogArrayListIndex < 1 Then
                PubConstClass.intLogArrayListIndex = 0
                'MsgBox("【ShiftLogArrayList】PubConstClass.intLogArrayListIndex = 0 にしました。", _
                '       CType(MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, MsgBoxStyle), "【デバッグエラー】")
            End If
        Catch ex As Exception
            MsgBox("【ShiftLogArrayList】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 受信データ処理
    ''' </summary>
    ''' <param name="data">受信した文字列</param>
    ''' <remarks></remarks>
    Private Sub wkwk_RcvDataToListBox(ByVal data As String)

        Dim strArrayData() As String
        Dim col(11) As String
        Dim itm As ListViewItem
        Dim strOutPutData As String

        Dim cRandom As New System.Random()  ' 乱数発生クラスの生成
        Dim strClassArray() As String
        Dim iRandWeight As Integer

        Try
            '// デバッグの為追加↓ここから
            strClassArray = PubConstClass.pblClassForSiten.Split("："c)
            Select Case strClassArray(0)
                Case "30"
                    'iRandWeight = cRandom.Next(25, 4000)    ' 25g から 4000g の乱数生成
                    iRandWeight = cRandom.Next(25, 500)    ' 25g から 500g の乱数生成
                Case "40"
                    iRandWeight = cRandom.Next(25, 4000)    ' 25g から 4000g の乱数生成
                Case "50"
                    iRandWeight = cRandom.Next(25, 4000)    ' 25g から 4000g の乱数生成
                Case "60"
                    iRandWeight = cRandom.Next(25, 4000)    ' 25g から 4000g の乱数生成
                Case "150"
                    iRandWeight = cRandom.Next(25, 500)     ' 25g から 500g の乱数生成
                Case "160"
                    iRandWeight = cRandom.Next(25, 500)     ' 25g から 500g の乱数生成
                Case Else
                    iRandWeight = cRandom.Next(25, 1000)    ' 25g から 1000g の乱数生成
            End Select
            '// デバッグの為追加↑ここまで

            ' 受信データ回数のインクリメント
            rcvDataCount = rcvDataCount + 1

            '' 保存ファイル名の作成
            'With Now
            '    strSaveImageFileName = IncludeTrailingPathDelimiter(PubConstClass.imgPath) & _
            '                           strYYYYMMDDvalue & "\" & strHHMMSSvalue & "\" & _
            '                           "image_" & _
            '                           String.Format("{0:D4}{1:D2}{2:D2}", .Year, .Month, .Day) & _
            '                           "_" & _
            '                           String.Format("{0:D2}{1:D2}{2:D2}", .Hour, .Minute, .Second) & _
            '                           "_" & _
            '                           String.Format("{0:00000}", rcvDataCount) & _
            '                           ".jpg"
            'End With

            ' 受信データをリストボックスの最後に追加する。
            strArrayData = data.Split(","c)

            If strArrayData.Length > 1 Then
                ' ListViewの行追加 
                ' 処理番号
                col(0) = String.Format("{0:00000}", rcvDataCount)
                strOutPutData = col(0) + ","

                ' 業務名称
                col(1) = CmbJobName.Text
                strOutPutData = strOutPutData + col(1) + ","

                ' 処理日付
                col(2) = Date.Now.ToString
                strOutPutData = strOutPutData + col(2) + ","

                ' 合否
                If strArrayData(0).Substring(2, 1) = "0" Then
                    'col(2) = "OK"
                    ' OK処理カウンタ
                    lngOKCount += 1
                    ' 処理カウンタ
                    lngTranCount += 1
                    blnPrintOKFlg = True
                Else
                    'col(2) = "NG"
                    ' 処理カウンタ
                    lngTranCount += 1
                    blnPrintOKFlg = False
                End If
                lblOKCount.Text = lngOKCount.ToString
                lblTranCount.Text = lngTranCount.ToString
                LblZanCnt.Text = (CInt(LblZanCnt.Text) - 1).ToString
                'strOutPutData = strOutPutData + col(2) + ","

                '// TODO:当日累計 
                LblTodayTotal.Text = lblTranCount.Text

                '// TODO：種別累計
                LblClassTotal.Text = lblTranCount.Text

                '// TODO：種別
                'LblClass.Text = ""

                ' 引受番号
                lblAcceptNum1.Text = strArrayData(1).Substring(0, 3)
                lblAcceptNum2.Text = strArrayData(1).Substring(3, 2)
                lblAcceptNum3.Text = strArrayData(1).Substring(5, 5)
                lblAcceptNum4.Text = strArrayData(1).Substring(10, 1)
                col(3) = lblAcceptNum1.Text & "-" & lblAcceptNum2.Text & "-" & lblAcceptNum3.Text & "-" & lblAcceptNum4.Text

                strOutPutData = strOutPutData + col(3) + ","


                '// TODO：重量データ
                col(4) = iRandWeight.ToString("0")
                LblWeight.Text = col(4)
                strOutPutData = strOutPutData + col(4) & ","


                '// TODO：料金データ
                col(5) = GetPriceFromWeight(col(4))
                LblPrice.Text = col(5)
                strOutPutData = strOutPutData + col(5) & ","


                ' 画像ファイル名称
                col(6) = strSaveImageFileName
                strOutPutData = strOutPutData + col(6) + ","

                ' 種別　　　　　：pblClassForSiten
                col(7) = PubConstClass.pblClassForSiten
                strOutPutData = strOutPutData + col(7) + ","

                ' 支店コード　　：pblSitenCode
                col(8) = PubConstClass.pblSitenCode
                strOutPutData = strOutPutData + col(8) + ","

                ' 支店名　　　　：pblSitenName
                col(9) = PubConstClass.pblSitenName
                strOutPutData = strOutPutData + col(9) + ","

                ' 処理予定通数　：pblTranYoteiCount
                col(10) = PubConstClass.pblTranYoteiCount
                strOutPutData = strOutPutData + col(10) + ","

                ' 定形・定形外
                If PubConstClass.strPubTeikei = "0" Then
                    col(11) = "定形"
                Else
                    col(11) = "定形外"
                End If
                strOutPutData = strOutPutData + col(11) + ","

                ' OK分の表示
                itm = New ListViewItem(col)
                lstGetDataView.Items.Add(itm)
                lstGetDataView.Items(lstGetDataView.Items.Count - 1).Selected = True
                lstGetDataView.Items(lstGetDataView.Items.Count - 1).Focused = True
                lstGetDataView.Select()
                lstGetDataView.Items(lstGetDataView.Items.Count - 1).EnsureVisible()

                ' 検査ログ書込処理
                Call OutPutKensaLogFile(strYYYYMMDDvalue, strHHMMSSvalue, strOutPutData)

            Else
                ' エラー出力

            End If

        Catch ex As Exception
            MsgBox("【RcvDataToListBox】" & ex.Message)
            Call OutPutLogFile("【RcvDataToListBox】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 重量から料金を取得する
    ''' </summary>
    ''' <param name="strWeight"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetPriceFromWeight(ByVal strWeight As String) As String

        Dim strRetVal As String = "範囲外"
        Dim intWeight As Integer = CInt(strWeight)

        Try
            For N = 0 To 8
                If PubConstClass.strWeightArray(N) = "" Then
                    PubConstClass.strWeightArray(N) = "0"
                End If
            Next

            If PubConstClass.strPubTeikei = "0" Then
                ' 定形
                If intWeight <= CInt(PubConstClass.strWeightArray(0)) Then
                    strRetVal = PubConstClass.strPriceArray(0).ToString

                ElseIf intWeight <= CInt(PubConstClass.strWeightArray(1)) Then
                    strRetVal = PubConstClass.strPriceArray(1).ToString

                ElseIf intWeight <= CInt(PubConstClass.strWeightArray(2)) Then
                    strRetVal = PubConstClass.strPriceArray(2).ToString

                ElseIf intWeight <= CInt(PubConstClass.strWeightArray(3)) Then
                    strRetVal = PubConstClass.strPriceArray(3).ToString

                ElseIf intWeight <= CInt(PubConstClass.strWeightArray(4)) Then
                    strRetVal = PubConstClass.strPriceArray(4).ToString

                ElseIf intWeight <= CInt(PubConstClass.strWeightArray(5)) Then
                    strRetVal = PubConstClass.strPriceArray(5).ToString

                ElseIf intWeight <= CInt(PubConstClass.strWeightArray(6)) Then
                    strRetVal = PubConstClass.strPriceArray(6).ToString

                ElseIf intWeight <= CInt(PubConstClass.strWeightArray(7)) Then
                    strRetVal = PubConstClass.strPriceArray(7).ToString

                ElseIf intWeight <= CInt(PubConstClass.strWeightArray(8)) Then
                    strRetVal = PubConstClass.strPriceArray(8).ToString
                Else
                    strRetVal = "範囲外"
                End If

            ElseIf PubConstClass.strPubTeikei = "1" Then
                ' 定形外(規格内)
                If intWeight <= CInt(PubConstClass.strWeightGaiArray(0)) Then
                    strRetVal = PubConstClass.strPriceGaiArray(0).ToString

                ElseIf intWeight <= CInt(PubConstClass.strWeightGaiArray(1)) Then
                    strRetVal = PubConstClass.strPriceGaiArray(1).ToString

                ElseIf intWeight <= CInt(PubConstClass.strWeightGaiArray(2)) Then
                    strRetVal = PubConstClass.strPriceGaiArray(2).ToString

                ElseIf intWeight <= CInt(PubConstClass.strWeightGaiArray(3)) Then
                    strRetVal = PubConstClass.strPriceGaiArray(3).ToString

                ElseIf intWeight <= CInt(PubConstClass.strWeightGaiArray(4)) Then
                    strRetVal = PubConstClass.strPriceGaiArray(4).ToString

                ElseIf intWeight <= CInt(PubConstClass.strWeightGaiArray(5)) Then
                    strRetVal = PubConstClass.strPriceGaiArray(5).ToString

                ElseIf intWeight <= CInt(PubConstClass.strWeightGaiArray(6)) Then
                    strRetVal = PubConstClass.strPriceGaiArray(6).ToString

                ElseIf intWeight <= CInt(PubConstClass.strWeightGaiArray(7)) Then
                    strRetVal = PubConstClass.strPriceGaiArray(7).ToString
                Else
                    strRetVal = "範囲外"
                End If
            Else
                ' 定形外(規格外)
                If intWeight <= CInt(PubConstClass.strWeightNonSArray(0)) Then
                    strRetVal = PubConstClass.strPriceNonSArray(0).ToString

                ElseIf intWeight <= CInt(PubConstClass.strWeightNonSArray(1)) Then
                    strRetVal = PubConstClass.strPriceNonSArray(1).ToString

                ElseIf intWeight <= CInt(PubConstClass.strWeightNonSArray(2)) Then
                    strRetVal = PubConstClass.strPriceNonSArray(2).ToString

                ElseIf intWeight <= CInt(PubConstClass.strWeightNonSArray(3)) Then
                    strRetVal = PubConstClass.strPriceNonSArray(3).ToString

                ElseIf intWeight <= CInt(PubConstClass.strWeightNonSArray(4)) Then
                    strRetVal = PubConstClass.strPriceNonSArray(4).ToString

                ElseIf intWeight <= CInt(PubConstClass.strWeightNonSArray(5)) Then
                    strRetVal = PubConstClass.strPriceNonSArray(5).ToString

                ElseIf intWeight <= CInt(PubConstClass.strWeightNonSArray(6)) Then
                    strRetVal = PubConstClass.strPriceNonSArray(6).ToString

                ElseIf intWeight <= CInt(PubConstClass.strWeightNonSArray(7)) Then
                    strRetVal = PubConstClass.strPriceNonSArray(7).ToString
                Else
                    strRetVal = "範囲外"
                End If
            End If

            Return strRetVal

        Catch ex As Exception
            MsgBox("【GetPriceFromWeight】" & ex.Message)
        End Try

        Return strRetVal

    End Function


    Public Sub New()

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。

    End Sub


    '----------------------------------------------------------
    '//////////////////////////////////////////////////////////////
    '動画表示フォーム

    '表示エリアのサイズ変更時
    Private Sub Pic_View_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Pic_View.Resize

        Try
            '動画サイズ変更
            ViewSizeChange()
        Catch ex As Exception
            MsgBox("【DrivingForm.Pic_View_Resize】" & ex.Message)
        End Try

    End Sub

    '----------------------------------------------------------
    'キャプチャデバイスダイアログの表示
    Private Sub SelectDeviceDialog()

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
            'Pic_View.Size = vsz + esz                     '動画サイズ＋表示エリア以外のサイズ


            'ウィンドウ内で再生
            ViewSizeChange()

            'サンプリング開始
            rc = mSmp.SetBufferSamples(True)
            If rc <> 0 Then Throw New DirectShowException(rc, "サンプリングを開始できません。")

        Catch ex As Exception
            'エラー
            MsgBox("【CreateGraph】" & ex.Message)

            Return True
        End Try

        '成功
        Return False

    End Function

    '----------------------------------------------------------
    'グラフ解放
    Private Sub ReleaseGraph()

        If mGrp Is Nothing Then Exit Sub

        '停止させる
        Dim mc As IMediaControl = CType(mGrp, IMediaControl)
        mc.Stop()
        mc = Nothing

        '解放
        ReleaseInstance(mGrp)

    End Sub

    '----------------------------------------------------------
    ' サイズ変更時
    Private Sub ViewSizeChange()

        ' 状態確認
        If mGrp Is Nothing Then Exit Sub

        ' PictureBox内で再生
        SetVideoRenderer(mGrp, Pic_View, RendererScale.KeepAspect)

    End Sub


    '----------------------------------------------------------
    ' 静止画取得及び画像の暗号化
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
            'frm.DrawRGB24(bmpptr, vsz)

            Call DrawRGB24(bmpptr, vsz)

            'イメージ取得領域解放
            Marshal.FreeHGlobal(bmpptr)

            ' 指定したファイル名（フルパス）に画像保存する
            PictureBox1.Image.Save(strSaveImageFileName, System.Drawing.Imaging.ImageFormat.Jpeg)

            ' 保存した画像ファイルを暗号化する
            EncryptFile(strSaveImageFileName, strSaveImageFileName.Replace(".jpg", ".enc"), PubConstClass.DEF_OPEN_KEY)

            ' 暗号化した元のファイルを削除する
            '「戻る」ボタンで削除する様に変更
            'System.IO.File.Delete(strSaveImageFileName)

        Catch ex As Exception
            MsgBox("【Snap】" & ex.Message)
        End Try

    End Sub


    ''' <summary>
    ''' 表示(RGB24ビット)
    ''' </summary>
    ''' <param name="BmpPtr"></param>
    ''' <param name="BmpSize"></param>
    ''' <remarks></remarks>
    Public Sub DrawRGB24(ByVal BmpPtr As IntPtr, ByVal BmpSize As Size)

        '準備
        'Dim bmp As New Bitmap(BmpSize.Width, BmpSize.Height, BmpSize.Width * 3, Imaging.PixelFormat.Format24bppRgb, BmpPtr)
        Dim bmp As New Bitmap(BmpSize.Width, BmpSize.Height, BmpSize.Width * 3, Imaging.PixelFormat.Format24bppRgb, BmpPtr)

        If ChkPositiveDirection.Checked = True Then
            ' 正方向流れ
            bmp.RotateFlip(RotateFlipType.Rotate180FlipY)
        Else
            ' 逆方向
            bmp.RotateFlip(RotateFlipType.RotateNoneFlipY)
        End If

        PictureBox1.Image = New Bitmap(BmpSize.Width, BmpSize.Height)

        '表示領域にコピー
        Dim g As Graphics = Graphics.FromImage(PictureBox1.Image)
        g.DrawImage(bmp, 0, 0)
        g.Dispose()

        '後始末
        bmp.Dispose()

        ' ''表示
        ''Pic_View.Location = New Point(0, 0)
        ''Me.ClientSize = Pic_View.Size
        ''Me.Show()

    End Sub


    Private Sub DateTimeTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimeTimer.Tick

        Dim dtNow As DateTime = DateTime.Now

        ' 指定した書式で日付を文字列に変換する
        lblYear.Text = dtNow.ToString("yyyy/MM/dd")
        lblCurrentTime.Text = dtNow.ToString("HH:mm:ss")

        If PubConstClass.blnResetFlg = True Then
            ' シリアルポートにデータ送信（リセットコマンド）
            Call sendCommand(PubConstClass.CMD_RESET)
            PubConstClass.blnResetFlg = False
        End If

        ' 残カウントが「0」がどうかチェックする
        If IsNumeric(LblZanCnt.Text) = True Then
            If CInt(LblZanCnt.Text) = 0 Then
                btnReceive.Enabled = True       ' 「受領証印刷」ボタンを有効化する                
            Else
                btnReceive.Enabled = False      ' 「受領証印刷」ボタンを無効化する
            End If
        End If

        If blnIsDispFlg = False Then
            blnIsDispFlg = True

            ' 動作不可コマンド送信
            Call sendCommand(PubConstClass.CMD_DISABLE & vbCr)

            MessageForm.strMessage = "フィーダーガイド、コンベアガイド位置を確認してください" & vbCr & "設定位置を自動で動かしますか？"
            MessageForm.ShowDialog()
            '// 2015.12.16 Ver.B04 hayakawa 追加↓ここから
            lstGetDataView.Focus()
            '// 2015.12.16 Ver.B04 hayakawa 追加↑ここまで
            If MessageForm.blnRetValMsgBox = True Then

                Dim blnIsError As Boolean = True
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

                If LblTeikei.Text = "定形" Then
                    ' 定形
                    Call sendCommand(PubConstClass.CMD_SEND_q & "001" & vbCr)
                Else
                    ' 定形外
                    Call sendCommand(PubConstClass.CMD_SEND_q & "002" & vbCr)
                End If

            End If

            ' 動作可能コマンド送信
            Call sendCommand(PubConstClass.CMD_ENABLE & vbCr)

        End If

    End Sub

    ''' <summary>
    ''' 別スレッドで原符の印刷処理を実行
    ''' </summary>
    ''' <param name="state"></param>
    ''' <remarks></remarks>
    Private Sub ThreadMethodPrintOrigin(ByVal state As Object)

        SyncLock (objPrintSync)

            Try
                PubConstClass.intReceiptKind = 0

                If PubConstClass.pblPrintCountPerPage = "0" Then
                    ' 15画像／1頁
                    PubConstClass.lngPrintIndex = CLng(Math.Truncate(lngOKCount / 15))
                    intImageDataCount = 15
                Else
                    ' 8画像／1頁
                    PubConstClass.lngPrintIndex = CLng(Math.Truncate(lngOKCount / 8))
                    intImageDataCount = 8
                End If

                PrintDocument1.DocumentName = PubConstClass.pblHeder1Page & "の印刷"
                PrintDocument1.Print()
                Console.Write(" {0} ", state)
                'Call OutPutLogFile("■ThreadMethodPrint：" & state.ToString)
            Catch ex As Exception
                MsgBox("【ThreadMethodPrintOrigin】" & ex.Message)
            End Try

        End SyncLock

    End Sub

    ''' <summary>
    ''' 別スレッドで控えの印刷処理を実行
    ''' </summary>
    ''' <param name="state"></param>
    ''' <remarks></remarks>
    Private Sub ThreadMethodPrintReserve(ByVal state As Object)

        SyncLock (objPrintSync)

            Try
                PubConstClass.intReceiptKind = 1
                If PubConstClass.pblPrintCountPerPage = "0" Then
                    ' 15画像／1頁
                    PubConstClass.lngPrintIndex = CLng(Math.Truncate(lngOKCount / 15))
                    intImageDataCount = 15
                Else
                    ' 8画像／1頁
                    PubConstClass.lngPrintIndex = CLng(Math.Truncate(lngOKCount / 8))
                    intImageDataCount = 8
                End If

                PrintDocument1.DocumentName = PubConstClass.pblHeder2Page & "の印刷"
                PrintDocument1.Print()
                Console.Write(" {0} ", state)
                'Call OutPutLogFile("■ThreadMethodPrint：" & state.ToString)
            Catch ex As Exception
                MsgBox("【ThreadMethodPrintReserve】" & ex.Message)
            End Try

        End SyncLock

    End Sub


    '// 2016.01.13 Ver.B05 hayakawa 変更↓ここから
    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage

        Try

            Select Case PubConstClass.intPrintFuncNo
                Case 1
                    ' 受領証印刷
                    If PubConstClass.pblPrintCountPerPage = "0" Then
                        ' 「15面／頁」印刷処理
                        Print15FacePerPage(sender, e)
                        Exit Sub
                    Else
                        ' 「8面／頁」印刷処理
                        Print8FacePerPage(sender, e)
                        Exit Sub
                    End If
                Case Else

            End Select

        Catch ex As Exception
            MsgBox("【DrivingForm.PrintDocument1_PrintPage】" & ex.Message)
        End Try

    End Sub
    '// 2016.01.13 Ver.B05 hayakawa 変更↑ここまで

    ''' <summary>
    ''' 料金取得処理
    ''' </summary>
    ''' <param name="index"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetPriceVal(ByVal index As Integer) As String

        SyncLock (objSync)
            Dim sync As Object = Me.Invoke(New Func(Of Integer, String)(AddressOf GetPriceValSub), index)
            GetPriceVal = sync.ToString()
        End SyncLock

    End Function

    ''' <summary>
    ''' 料金取得処理
    ''' </summary>
    ''' <param name="index">取得する行の指定</param>
    ''' <returns>取得した料金</returns>
    ''' <remarks>運転画面に表示された料金を取得し返す</remarks>
    Function GetPriceValSub(ByVal index As Object) As String

        Try
            Dim strWeightVal = Me.lstGetDataView.Items(CInt(index)).SubItems(5).Text
            GetPriceValSub = strWeightVal.ToString

        Catch ex As Exception
            GetPriceValSub = "XXXX"
            MsgBox("【GetWeightValSub】" & ex.Message)
        End Try

    End Function

    ''' <summary>
    ''' 重量取得処理
    ''' </summary>
    ''' <param name="index"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetWeightVal(ByVal index As Integer) As String
        SyncLock (objSync)
            Dim sync As Object = Me.Invoke(New Func(Of Integer, String)(AddressOf GetWeightValSub), index)
            GetWeightVal = sync.ToString()
        End SyncLock
    End Function

    ''' <summary>
    ''' 重量取得処理
    ''' </summary>
    ''' <param name="index">取得する行の指定</param>
    ''' <returns>取得した重量</returns>
    ''' <remarks>運転画面に表示された重量を取得し返す</remarks>
    Function GetWeightValSub(ByVal index As Object) As String

        Try
            Dim strWeightVal = Me.lstGetDataView.Items(CInt(index)).SubItems(4).Text
            GetWeightValSub = strWeightVal.ToString

        Catch ex As Exception
            GetWeightValSub = "XXXX"
            MsgBox("【GetWeightValSub】" & ex.Message)
        End Try

    End Function

    ''' <summary>
    ''' 引受番号取得処理
    ''' </summary>
    ''' <param name="index">取得する行の指定</param>
    ''' <returns>取得した引受番号</returns>
    ''' <remarks>運転画面に表示された引受番号を取得し返す</remarks>
    Function GetAcceptNumberSub(ByVal index As Object) As String

        Try
            Dim strAcceptNumber = Me.lstGetDataView.Items(CInt(index)).SubItems(3).Text
            GetAcceptNumberSub = strAcceptNumber.ToString

        Catch ex As Exception
            GetAcceptNumberSub = "XXX-XX-XXXXX-X"
            MsgBox("【GetAcceptNumberSub】" & ex.Message)
        End Try

    End Function

    ''' <summary>
    ''' 引受番号取得処理
    ''' </summary>
    ''' <param name="index"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetAcceptNumber(ByVal index As Integer) As String
        SyncLock (objSync)
            Dim sync As Object = Me.Invoke(New Func(Of Integer, String)(AddressOf GetAcceptNumberSub), index)
            GetAcceptNumber = sync.ToString()
        End SyncLock
    End Function

    ''' <summary>
    ''' 撮像画像ファイル名称取得処理
    ''' </summary>
    ''' <param name="index">取得する行の指定</param>
    ''' <returns>取得した撮像画像ファイル名称</returns>
    ''' <remarks>運転画面に表示された撮像画像ファイル名称を取得し返す</remarks>
    Function GetPrintFileNameSub(ByVal index As Object) As String

        Try
            Dim strPrintFileNam = Me.lstGetDataView.Items(CInt(index)).SubItems(6).Text
            GetPrintFileNameSub = strPrintFileNam.ToString

        Catch ex As Exception
            GetPrintFileNameSub = ""
            MsgBox("【GetPrintFileNameSub】" & ex.Message)
        End Try

    End Function


    ''' <summary>
    ''' 撮像画像ファイル名称取得処理
    ''' </summary>
    ''' <param name="index"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetPrintFileName(ByVal index As Integer) As String
        SyncLock (objSync)
            Dim sync As Object = Me.Invoke(New Func(Of Integer, String)(AddressOf GetPrintFileNameSub), index)
            GetPrintFileName = sync.ToString()
        End SyncLock
    End Function

    Private Sub lstGetDataView_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstGetDataView.SelectedIndexChanged
        '// lstGetDataView_Click 参照
    End Sub

    ''' <summary>
    ''' 受信ログ表示領域クリック処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub lstGetDataView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstGetDataView.Click

        Try
            If System.IO.File.Exists(lstGetDataView.SelectedItems(0).SubItems(6).Text.Replace(".jpg", ".enc")) = True Then
                ' 暗号化したファイルを復号化する
                DecryptFile(lstGetDataView.SelectedItems(0).SubItems(6).Text.Replace(".jpg", ".enc"), _
                            lstGetDataView.SelectedItems(0).SubItems(6).Text, _
                            PubConstClass.DEF_OPEN_KEY)
                PictureBox1.ImageLocation = lstGetDataView.SelectedItems(0).SubItems(6).Text
            Else
                PictureBox1.ImageLocation = IncludeTrailingPathDelimiter(Application.StartupPath) & "noimage.jpg"
            End If

            ' 復号化した画像ファイルを削除する
            'System.IO.File.Delete(lstGetDataView.SelectedItems(0).SubItems(6).Text)

        Catch ex As Exception
            MsgBox("【lstGetDataView_Click】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 「受領」ボタン処理（最後の15毎に満たない場合の印刷処理）
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnReceive_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReceive.Click

        Dim margin1 As Integer = 0
        Dim margin2 As Integer = 0
        Dim intPrintCnt As Integer

        Dim retVal As MsgBoxResult
        retVal = MsgBox("差出票・受領証の内容を確認しますか？", CType(MsgBoxStyle.Question + MsgBoxStyle.OkCancel, MsgBoxStyle), "確認")
        If retVal = MsgBoxResult.Cancel Then
            ' キャンセル
            Exit Sub
        End If

        If Rdo15Face.Checked = True Then
            ' 15面／頁
            PubConstClass.pblPrintCountPerPage = "0"
        ElseIf Rdo8Face.Checked = True Then
            ' 8面／頁
            PubConstClass.pblPrintCountPerPage = "1"
        Else
            ' ありえないけど念の為に。
            Exit Sub
        End If

        If lstGetDataView.Items.Count > 0 Then
            PubConstClass.arListForPrint = New ArrayList
            PubConstClass.arListForPrint.Clear()
            intPrintCnt = 0
            For N = 0 To lstGetDataView.Items.Count - 1
                If lstGetDataView.Items(N).SubItems(5).Text <> "範囲外" Then
                    intPrintCnt += 1
                    PubConstClass.arListForPrint.Add(lstGetDataView.Items(N).SubItems(0).Text & "," & _
                                                     lstGetDataView.Items(N).SubItems(1).Text & "," & _
                                                     lstGetDataView.Items(N).SubItems(2).Text & "," & _
                                                     lstGetDataView.Items(N).SubItems(3).Text & "," & _
                                                     lstGetDataView.Items(N).SubItems(4).Text & "," & _
                                                     lstGetDataView.Items(N).SubItems(5).Text & "," & _
                                                     lstGetDataView.Items(N).SubItems(6).Text & "," & _
                                                     lstGetDataView.Items(N).SubItems(7).Text & "," & _
                                                     lstGetDataView.Items(N).SubItems(8).Text & "," & _
                                                     lstGetDataView.Items(N).SubItems(9).Text & "," & _
                                                     lstGetDataView.Items(N).SubItems(10).Text & "," & _
                                                     lstGetDataView.Items(N).SubItems(11).Text & ","
                                                     )
                End If
            Next

            PubConstClass.intPrintFuncNo = 1    ' 印刷機能番号のセット
            PubConstClass.intReceiptKind = 0
            PubConstClass.lngPrintIndex = CLng(Math.Truncate(lngOKCount / 15)) + 1
            ' 印字する画像データの個数を取得
            'intImageDataCount = lstGetDataView.Items.Count
            intImageDataCount = intPrintCnt
            ' 印字ページインデックスの初期化
            intPrintImageIndex = 0

            'PrintDocumentオブジェクトの作成
            Dim pd As New System.Drawing.Printing.PrintDocument
            'PrintPageイベントハンドラの追加
            'AddHandler pd.PrintPage, AddressOf MainForm.PrintDocument1_PrintPage
            AddHandler pd.PrintPage, AddressOf PrintDocument1_PrintPage

            ' PrintPreviewDialogオブジェクトの作成
            Dim ppd As New PrintPreviewDialog
            ppd.Width = 1200
            ppd.Height = 1000

            '// 2016.01.18 Ver.B05 hayakawa 追加↓ここから
            ppd.Top = 0
            ppd.Left = 0
            'ppd.ControlBox = False
            ppd.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            '// 2016.01.18 Ver.B05 hayakawa 追加↑ここまで

            ' プレビューオブジェクトの「印刷」ボタン削除
            Dim tool As ToolStrip = CType(ppd.Controls(1), ToolStrip)
            tool.Items.RemoveAt(0)
            ' プレビューするPrintDocumentを設定
            ppd.Document = pd
            ' 印刷プレビューダイアログを表示する
            ppd.ShowDialog()
            ' PrintPreviewDialogオブジェクトの解放
            ppd.Dispose()

            retVal = MsgBox(PubConstClass.pblHeder1Page & "を印刷しますか？", CType(MsgBoxStyle.Question + MsgBoxStyle.OkCancel, MsgBoxStyle), "確認")
            If retVal = MsgBoxResult.Cancel Then
                ' キャンセル
                Exit Sub
            End If

            PubConstClass.intReceiptKind = 0
            ' 印字する画像データの個数を取得
            'intImageDataCount = lstGetDataView.Items.Count
            intImageDataCount = intPrintCnt
            ' 印字ページインデックスの初期化
            intPrintImageIndex = 0
            pd.DocumentName = PubConstClass.pblHeder1Page & "の印刷"
            ' 印刷処理
            pd.Print()

            retVal = MsgBox(PubConstClass.pblHeder2Page & "を印刷しますか？", CType(MsgBoxStyle.Question + MsgBoxStyle.OkCancel, MsgBoxStyle), "確認")
            If retVal = MsgBoxResult.Cancel Then
                ' キャンセル
                Exit Sub
            End If

            PubConstClass.intReceiptKind = 1
            ' 印字する画像データの個数を取得
            'intImageDataCount = lstGetDataView.Items.Count
            intImageDataCount = intPrintCnt
            ' 印字ページインデックスの初期化
            intPrintImageIndex = 0
            pd.DocumentName = PubConstClass.pblHeder2Page & "の印刷"
            ' 印刷処理
            pd.Print()

            ' PrintDocumentオブジェクトの解放
            pd.Dispose()

        End If

        ' 「戻る」ボタンの有効化
        BtnBack.Enabled = True

    End Sub


    ''' <summary>
    ''' デバイス選択画面の表示
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub OpenVideoCaptureDevice()

        'With IcImagingControl1

        '    If (.DeviceValid) Then
        '        .LiveStop()
        '    End If
        '    .ShowDeviceSettingsDialog()
        '    If (.DeviceValid) Then
        '        .SaveDeviceStateToFile("device.xml")
        '    End If

        '    ' Update button states
        '    btnLiveStart.Enabled = .DeviceValid
        '    btnProperty.Enabled = .DeviceValid

        'End With

    End Sub

    ''' <summary>
    ''' プロパティ画面の表示
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ShowDeviceProperties()

        'With IcImagingControl1
        '    If (.DeviceValid) Then
        '        .ShowPropertyDialog()
        '        .SaveDeviceStateToFile("device.xml")
        '    End If
        'End With

    End Sub

    ''' <summary>
    ''' ライブ開始処理
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub StartLiveVideo()

        'With IcImagingControl1
        '    If (.DeviceValid) Then
        '        .LiveStart()
        '        btnLiveStart.Text = "ライブ停止"
        '    Else
        '        btnLiveStart.Text = "ライブ開始"
        '    End If
        'End With

    End Sub

    ''' <summary>
    ''' ライブ停止処理
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub StopLiveVideo()

        'With IcImagingControl1
        '    If (.DeviceValid) Then
        '        .LiveStop()
        '        btnLiveStart.Text = "ライブ開始"
        '    Else
        '        btnLiveStart.Text = "ライブ停止"
        '    End If
        'End With

    End Sub

    ''' <summary>
    ''' デバッグ表示領域の（表示／非表示）の制御処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub lblVersion_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblVersion.DoubleClick

        If LblDebugTitle.Visible = True Then
            LblDebugTitle.Visible = False
            LstDebug.Visible = False
            Btn_Snap.Visible = False
            Btn_Device.Visible = False
        Else
            LblDebugTitle.Visible = True
            LstDebug.Visible = True
            Btn_Snap.Visible = True
            Btn_Device.Visible = True
        End If

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        Try
            Timer1.Enabled = False
            ' 停止コマンド送信
            Call sendCommand(PubConstClass.CMD_STOP)

        Catch ex As Exception
            MsgBox("【Timer1_Tick】" & ex.Message)
        End Try


        'PubConstClass.intReceiptKind = 1
        'PubConstClass.lngPrintIndex = CLng(Math.Truncate(lngOKCount / 15))
        '' １頁１５画像の設定
        'intImageDataCount = 15
        'PrintDocument1.DocumentName = "受領書（控え）の印刷"


        '' WaitCallbackデリゲートを作成
        'Dim waitCallback As New System.Threading.WaitCallback(AddressOf ThreadMethodPrintReserve)
        '' スレッドプールに登録
        'System.Threading.ThreadPool.QueueUserWorkItem(waitCallback, "B")

        ''PrintDocument1.Print()

        'Timer1.Enabled = False

    End Sub



    ''' <summary>
    ''' 「カメラ設定」ボタン処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Btn_Device_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Device.Click

        'SelectDeviceDialog()
        Panel1.Visible = True
        SelectDevice()

        '///////////////////////
        '// カメラの初期化    //
        '///////////////////////
        'Call Start()


    End Sub


    ''' <summary>
    ''' 「スナップ」ボタン処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Btn_Snap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Snap.Click

        Dim data As String = ""

        Try
            ' 保存ファイル名の作成
            With Now
                strSaveImageFileName = IncludeTrailingPathDelimiter(PubConstClass.imgPath) & _
                                       strYYYYMMDDvalue & "\" & strHHMMSSvalue & "\" & _
                                       "image_" & _
                                       String.Format("{0:D4}{1:D2}{2:D2}", .Year, .Month, .Day) & _
                                       "_" & _
                                       String.Format("{0:D2}{1:D2}{2:D2}", .Hour, .Minute, .Second) & _
                                       "_" & _
                                       String.Format("{0:00000}", rcvDataCount) & _
                                       ".jpg"
            End With

            data = "ZD0," & PubConstClass.dblStartUnderWritingNumber.ToString("0000000000") & (PubConstClass.dblStartUnderWritingNumber Mod 7).ToString("0")
            'data = "ZD0,32548000012"
            wkwk_RcvDataToListBox(data)
            ' 引受番号のインクリメント
            PubConstClass.dblStartUnderWritingNumber += 1

            ' 撮像及び画像保存
            Snap()

        Catch ex As Exception
            MsgBox("【Btn_Snap_Click】" & ex.Message)
        End Try

    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub SerialWeightPort_DataReceived(sender As Object, e As System.IO.Ports.SerialDataReceivedEventArgs) Handles SerialWeightPort.DataReceived

        'シリアルポートをオープンしていない場合、処理を行わない。
        If SerialWeightPort.IsOpen = False Then
            Return
        End If

        Try
            Dim data As String
            Dim args(0) As Object

            ' <CR>まで読み込む
            data = SerialWeightPort.ReadTo(ControlChars.Cr)

            If data.IndexOf("?") > 0 Then
                Call OutPutLogFile("■受信（パリティエラー）：" & data.ToString & "<CR>")
                BeginInvoke(New Delegate_RcvDataToTextBox(AddressOf Me.RcvWeightDataToTextBox), "パリティエラー：" & "data.ToString" & ControlChars.Cr)
            End If

            ' 受信データの格納
            Call OutPutLogFile("■受信：" & data.ToString & "<CR>")
            BeginInvoke(New Delegate_RcvWeightDataToTextBox(AddressOf Me.RcvWeightDataToTextBox), data.ToString & ControlChars.Cr)

        Catch ex As TimeoutException
            ' 受信タイムアウトの処理（受信バッファをクリア）
            Dim strDiscardData As String = SerialPort.ReadExisting()
            ' ディスカードするデータ
            Call OutPutLogFile("■データ受信タイムアウトエラー：<CR>未受信で切り捨てたデータ：" & strDiscardData)
            BeginInvoke(New Delegate_RcvDataToTextBox(AddressOf Me.RcvWeightDataToTextBox), "ZE999" & ControlChars.Cr)
        Catch ex As Exception
            MsgBox("【SerialWeightPort_DataReceived】" & ex.Message)
        End Try

    End Sub


    ''' <summary>
    ''' 「戻る」ボタン処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnBack_Click(sender As System.Object, e As System.EventArgs) Handles BtnBack.Click

        Dim strArray() As String
        Dim strIniFilePath As String

        Try
            strArray = LblClass.Text.Split("："c)
            'If strArray(0) = "30" Or strArray(0) = "40" Then
            If strArray(0) = "30" Then
                '// 2017.06.26 Ver.B08a hayakawa 修正↓ここから
                'MsgBoxForm.strMessage = "「処理データ」と「手入力リスト」" & vbCr & "を印字しますか？"
                MsgBoxForm.strMessage = "「処理データ」を印字しますか？"
                '// 2017.06.26 Ver.B08a hayakawa 修正↑ここまで
            Else
                MsgBoxForm.strMessage = "「処理データ」を印字しますか？"
            End If

            ' 確認メッセージの表示
            MsgBoxForm.ShowDialog()
            If MsgBoxForm.blnRetValMsgBox = False Then
                ' 「いいえ」の場合の処理
                If blnShiftF12Flg = False Then
                    ' 運転画面に戻る（「SHIFT」＋「F12」が押下されていない）
                    Exit Sub
                End If
                '「SHIFT」＋「F12」が押下されていたら処理Ａから実行する
            Else
                ' 処理データ表（配送内容集計リスト）印刷処理
                If lstGetDataView.Items.Count > 0 Then
                    With MainForm
                        PubConstClass.intPrintFuncNo = 4    ' 印刷機能番号のセット
                        .PrintDocument1.DocumentName = "処理データ（" & PubConstClass.pblClassForSiten & "）の印刷"
                        .PrintDocument1.Print()
                        'If strArray(0) = "30" Or strArray(0) = "40" Then
                        '// 2017.06.26 Ver.B08a hayakawa コメントアウト↓ここから
                        'If strArray(0) = "30" Then
                        '    ' 手入力リスト（簡易書留）印刷処理
                        '    PubConstClass.intPrintFuncNo = 5    ' 印刷機能番号のセット
                        '    .PrintDocument1.DocumentName = "手入力リスト（" & PubConstClass.pblClassForSiten & "）の印刷"
                        '    .PrintDocument1.Print()
                        'End If
                        '// 2017.06.26 Ver.B08a hayakawa コメントアウト↑ここまで
                    End With
                End If
            End If

            ' （処理Ａ）指定種別の現在の引受番号を書き込む
            SetStartUnderWritingNumber(PubConstClass.pblClassForSiten)

            ' 引受番号の再取得を行う
            Call GetUnderWritingNumber()

            ' 各カウンタをINIファイルに書き込む
            strIniFilePath = IncludeTrailingPathDelimiter(Application.StartupPath) & PubConstClass.DEF_INI_FILENAME
            WritePrivateProfileString("Counter", "WorkDay", Date.Now.ToString("yyyyMMdd"), strIniFilePath)
            WritePrivateProfileString("Counter", "TodayAllCount", PubConstClass.intTodayALLCount.ToString("0"), strIniFilePath)
            WritePrivateProfileString("Counter", "KaniALLCount", PubConstClass.intKaniALLCount.ToString("0"), strIniFilePath)
            WritePrivateProfileString("Counter", "TokuALLCount", PubConstClass.intTokuALLCount.ToString("0"), strIniFilePath)
            WritePrivateProfileString("Counter", "MailALLCount", PubConstClass.intMailALLCount.ToString("0"), strIniFilePath)

            Dim strSaveImageFolder As String = IncludeTrailingPathDelimiter(PubConstClass.imgPath) & _
                                                strYYYYMMDDvalue & "\" & strHHMMSSvalue & "\"
            ' JPG ファイルの削除
            If System.IO.Directory.Exists(strSaveImageFolder) = True Then

                For Each FileName As String In System.IO.Directory.GetFiles(strSaveImageFolder, "*.jpg")
                    System.IO.File.Delete(FileName)
                Next

            End If

            ' グラフの解放
            ReleaseGraph()

            ' <CAN>コマンド送信（ラベル＆プリンタの印字データクリア）
            Call SendCANCommand()

            ' シリアルポートにデータ送信（動作不可コマンド）
            Call sendCommand(PubConstClass.CMD_DISABLE)

            ' シリアルポートのクローズ
            SerialPort.Close()

            Me.Dispose()

            ' メインメニュー表示
            MainForm.Show()
            ' 支店選択画面の表示
            'SelectClassForm.Show()
            SelectClassForm.ShowDialog()

            'Me.Dispose()

        Catch ex As Exception
            MsgBox("【BtnBack_Click】" & ex.Message)
        End Try

    End Sub


    ''' <summary>
    ''' 「一通処理」ボタン処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnOnePage_Click(sender As System.Object, e As System.EventArgs) Handles BtnOnePage.Click

        Try
            MsgBoxForm.strMessage = "一通処理を行いますか？"
            MsgBoxForm.ShowDialog()
            If MsgBoxForm.blnRetValMsgBox = False Then
                Exit Sub
            Else
                ' １通処理コマンド送信
                Call sendCommand(PubConstClass.CMD_SEND_j)

                ' 「設定」ボタン使用不可
                'BtnBack.Enabled = False
                ' 「受領」ボタン使用不可
                'btnReceive.Enabled = False

                ' フォルダの存在チェック
                Dim hDirInfo As System.IO.DirectoryInfo
                hDirInfo = System.IO.Directory.CreateDirectory(IncludeTrailingPathDelimiter(PubConstClass.imgPath) & strYYYYMMDDvalue & "\" & strHHMMSSvalue)
                If hDirInfo.Exists = False Then
                    ' フォルダの作成
                    System.IO.Directory.CreateDirectory(IncludeTrailingPathDelimiter(PubConstClass.imgPath) & strYYYYMMDDvalue & "\" & strHHMMSSvalue)
                End If
            End If

        Catch ex As Exception
            MsgBox("【BtnOnePage_Click】" & ex.Message)
        End Try

    End Sub

    Private Sub Label14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label14.Click
        '// Label14_DoubleClick 参照
    End Sub

    ''' <summary>
    ''' 隠しコマンド（「スナップ」「デバイス」ボタン「デバッグウィンドウ」ラベルの表示・非表示）
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Label14_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label14.DoubleClick

        If Btn_Snap.Visible = False Then
            Btn_Snap.Visible = True
            Btn_Device.Visible = True
        Else
            Btn_Snap.Visible = False
            Btn_Device.Visible = False
        End If

    End Sub


    ''' <summary>
    ''' 「＋」ボタン（予定処理数）
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnYoteiPlus_Click(sender As System.Object, e As System.EventArgs) Handles BtnYoteiPlus.Click

        Dim IntCalcValue As Integer = 0

        Try
            If IsNumeric(LblYoteiCnt.Text) = True Then
                IntCalcValue = CInt(LblYoteiCnt.Text)
            Else
                IntCalcValue = 0
            End If

            IntCalcValue += 1

            LblYoteiCnt.Text = IntCalcValue.ToString("0")

        Catch ex As Exception
            MsgBox("【BtnYoteiPlus_Click】" & ex.Message)
        End Try

    End Sub


    ''' <summary>
    ''' 「－」ボタン（予定処理数）
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnYoteiMinus_Click(sender As System.Object, e As System.EventArgs) Handles BtnYoteiMinus.Click

        Dim IntCalcValue As Integer = 0

        Try
            If IsNumeric(LblYoteiCnt.Text) = True Then
                IntCalcValue = CInt(LblYoteiCnt.Text)
            Else
                IntCalcValue = 0
            End If

            IntCalcValue -= 1
            If IntCalcValue < 0 Then
                IntCalcValue = 0
            End If

            LblYoteiCnt.Text = IntCalcValue.ToString("0")

        Catch ex As Exception
            MsgBox("【BtnYoteiMinus_Click】" & ex.Message)
        End Try

    End Sub


    ''' <summary>
    ''' 業務名コンボボックス選択処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CmbJobName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbJobName.SelectedIndexChanged

        Dim strArray() As String

        Try
            ' ユーザー情報の取得
            strArray = CmbJobName.Text.Split("："c)
            getUserInfomation(CInt(strArray(0)))

            ' (01)コメント
            LblComment.Text = PubConstClass.strPubComment

            ' (02) 種別
            strArray = PubConstClass.strPubKind.Split(","c)
            LblClass.Text = strArray(1)

            ' (03) 差出人住所１
            LblAddress1.Text = PubConstClass.strPubAddress1

            ' (04) 差出人住所２
            LblAddress2.Text = PubConstClass.strPubAddress2

            ' (05) 差出人氏名
            LblName.Text = PubConstClass.strPubName

            ' (06) 承認局名
            LblPostName.Text = PubConstClass.strPubPostName

            ' (07) フィーダー位置（垂直方向）
            TxtPosYFeeder.Text = PubConstClass.strPubFeederPosV

            ' (08) ラベル貼付位置（垂直方向）
            TxtPosYLabel.Text = PubConstClass.strPubLabelPosV

            ' (09) ラベル貼付位置（水平方向）
            TxtPosXLabel.Text = PubConstClass.strPubLabelPosH

            ' (10) 宛名撮像位置（垂直方向）
            TxtPosYCapture.Text = PubConstClass.strPubAddressPosV

            ' (11) 宛名撮像位置（水平方向）
            TxtPosXCapture.Text = PubConstClass.strPubAddressPosH

            ' 定形・定形外
            If PubConstClass.strPubTeikei = "0" Then
                LblTeikei.Text = "定形"
                If SerialPort.IsOpen = True Then
                    Call sendCommand(PubConstClass.CMD_SEND_q & "001" & vbCr)
                    Call sendCommand(PubConstClass.CMD_ENABLE & vbCr)
                End If
            ElseIf PubConstClass.strPubTeikei = "1" Then
                LblTeikei.Text = "定形外(規格内)"
                If SerialPort.IsOpen = True Then
                    Call sendCommand(PubConstClass.CMD_SEND_q & "002" & vbCr)
                    Call sendCommand(PubConstClass.CMD_ENABLE & vbCr)
                End If
            Else
                LblTeikei.Text = "定形外(規格外)"
                If SerialPort.IsOpen = True Then
                    '// TODO:2017.05.22 qコマンドの値は「002」で良いか？
                    Call sendCommand(PubConstClass.CMD_SEND_q & "002" & vbCr)
                    Call sendCommand(PubConstClass.CMD_ENABLE & vbCr)
                End If
            End If
            OutPutLogFile("〓「定形／定形外(規格内)／定形外(規格外)」変更：" & LblTeikei.Text)

            ' 正方向流し
            If PubConstClass.strPubPositiveDirection = "1" Then
                ' 正方向
                ChkPositiveDirection.Checked = True
                LblPositiveDirection.Visible = True
                OutPutLogFile("■" & CmbJobName.Text & "：正方向流し設定")
            Else
                ' 逆方向
                ChkPositiveDirection.Checked = False
                LblPositiveDirection.Visible = False
            End If

            If blnIsDispFlg = True Then
                MessageForm.strMessage = "フィーダーガイド、コンベアガイド位置を確認してください" & vbCr & "設定位置を自動で動かしますか？"
                MessageForm.ShowDialog()
                If MessageForm.blnRetValMsgBox = True Then

                    Dim blnIsError As Boolean = True
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

                End If

                Call sendCommand(PubConstClass.CMD_ENABLE & vbCr)

            End If

            ' 下記のフォーカスセット操作をしないとハンディバーコードがリード出来ない
            If lstGetDataView.Items.Count > 0 Then
                ' 表示データがある場合はフォーカスを最後のデータにセット
                lstGetDataView.Items(lstGetDataView.Items.Count - 1).Selected = True
                lstGetDataView.Items(lstGetDataView.Items.Count - 1).Focused = True
                lstGetDataView.Select()
                lstGetDataView.Items(lstGetDataView.Items.Count - 1).EnsureVisible()
            Else
                ' 表示データが無い場合はリストビューにフォーカスをセット
                lstGetDataView.Focus()
            End If

        Catch ex As Exception
            MsgBox("【CmbJobName_SelectedIndexChanged】" & ex.Message)
        End Try

    End Sub


    ''' <summary>
    ''' 「＋」ボタン（残カウント）
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnZanPlus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnZanPlus.Click

        Dim IntCalcValue As Integer = 0

        Try
            If IsNumeric(LblZanCnt.Text) = True Then
                IntCalcValue = CInt(LblZanCnt.Text)
            Else
                IntCalcValue = 0
            End If

            IntCalcValue += 1

            strYosoEndNumber = (CDbl(strYosoEndNumber) + 1).ToString("0000000000")
            Debug_Print("【＋】ボタン：strYosoEndNumber：" & strYosoEndNumber)
            OutPutLogFile("【＋】ボタン：strYosoEndNumber：" & strYosoEndNumber)

            LblZanCnt.Text = IntCalcValue.ToString("0")

        Catch ex As Exception
            MsgBox("【BtnZanPlus_Click】" & ex.Message)
        End Try

    End Sub


    ''' <summary>
    ''' 「－」ボタン（残カウント）
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnZanMinus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnZanMinus.Click

        Dim IntCalcValue As Integer = 0

        Try
            If IsNumeric(LblZanCnt.Text) = True Then
                IntCalcValue = CInt(LblZanCnt.Text)
            Else
                IntCalcValue = 0
            End If

            IntCalcValue -= 1
            If IntCalcValue < 0 Then
                IntCalcValue = 0
            Else
                strYosoEndNumber = (CDbl(strYosoEndNumber) - 1).ToString("0000000000")
                Debug_Print("【－】ボタン：strYosoEndNumber：" & strYosoEndNumber)
                OutPutLogFile("【－】ボタン：strYosoEndNumber：" & strYosoEndNumber)
            End If

            LblZanCnt.Text = IntCalcValue.ToString("0")

        Catch ex As Exception
            MsgBox("【BtnZanMinus_Click】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 重量から通数をカウントアップする
    ''' </summary>
    ''' <param name="strWeight">重量</param>
    ''' <param name="strTeikei">0：定形／1：定形外(規格内)／2：定形外(規格外)</param>
    ''' <remarks></remarks>
    Private Sub GetTranCntFromWeight(ByVal strWeight As String, ByVal strTeikei As String)

        Dim strRetVal As String = "範囲外"
        Dim intWeight As Integer = CInt(strWeight)

        Try

            If strTeikei = "0" Then
                ' 定形
                If intWeight <= CInt(PubConstClass.strWeightArray(0)) Then
                    strTranCnt(0) = (CInt(strTranCnt(0)) + 1).ToString("0")
                    strAmount(0) = (CInt(strTranCnt(0)) * CInt(PubConstClass.strPriceArray(0))).ToString("0")

                ElseIf intWeight <= CInt(PubConstClass.strWeightArray(1)) Then
                    strTranCnt(1) = (CInt(strTranCnt(1)) + 1).ToString("0")
                    strAmount(1) = (CInt(strTranCnt(1)) * CInt(PubConstClass.strPriceArray(1))).ToString("0")

                ElseIf intWeight <= CInt(PubConstClass.strWeightArray(2)) Then
                    strTranCnt(2) = (CInt(strTranCnt(2)) + 1).ToString("0")
                    strAmount(2) = (CInt(strTranCnt(2)) * CInt(PubConstClass.strPriceArray(2))).ToString("0")

                ElseIf intWeight <= CInt(PubConstClass.strWeightArray(3)) Then
                    strTranCnt(3) = (CInt(strTranCnt(3)) + 1).ToString("0")
                    strAmount(3) = (CInt(strTranCnt(3)) * CInt(PubConstClass.strPriceArray(3))).ToString("0")

                ElseIf intWeight <= CInt(PubConstClass.strWeightArray(4)) Then
                    strTranCnt(4) = (CInt(strTranCnt(4)) + 1).ToString("0")
                    strAmount(4) = (CInt(strTranCnt(4)) * CInt(PubConstClass.strPriceArray(4))).ToString("0")

                ElseIf intWeight <= CInt(PubConstClass.strWeightArray(5)) Then
                    strTranCnt(5) = (CInt(strTranCnt(5)) + 1).ToString("0")
                    strAmount(5) = (CInt(strTranCnt(5)) * CInt(PubConstClass.strPriceArray(5))).ToString("0")

                ElseIf intWeight <= CInt(PubConstClass.strWeightArray(6)) Then
                    strTranCnt(6) = (CInt(strTranCnt(6)) + 1).ToString("0")
                    strAmount(6) = (CInt(strTranCnt(6)) * CInt(PubConstClass.strPriceArray(6))).ToString("0")

                ElseIf intWeight <= CInt(PubConstClass.strWeightArray(7)) Then
                    strTranCnt(7) = (CInt(strTranCnt(7)) + 1).ToString("0")
                    strAmount(7) = (CInt(strTranCnt(7)) * CInt(PubConstClass.strPriceArray(7))).ToString("0")

                ElseIf intWeight <= CInt(PubConstClass.strWeightArray(8)) Then
                    strTranCnt(8) = (CInt(strTranCnt(8)) + 1).ToString("0")
                    strAmount(8) = (CInt(strTranCnt(8)) * CInt(PubConstClass.strPriceArray(8))).ToString("0")
                Else
                    strRetVal = "範囲外"
                End If

            ElseIf strTeikei = "1" Then
                '// 定形外（規格内）
                If intWeight <= CInt(PubConstClass.strWeightGaiArray(0)) Then
                    strTranCntGai(0) = (CInt(strTranCntGai(0)) + 1).ToString("0")
                    strAmountGai(0) = (CInt(strTranCntGai(0)) * CInt(PubConstClass.strPriceGaiArray(0))).ToString("0")

                ElseIf intWeight <= CInt(PubConstClass.strWeightGaiArray(1)) Then
                    strTranCntGai(1) = (CInt(strTranCntGai(1)) + 1).ToString("0")
                    strAmountGai(1) = (CInt(strTranCntGai(1)) * CInt(PubConstClass.strPriceGaiArray(1))).ToString("0")

                ElseIf intWeight <= CInt(PubConstClass.strWeightGaiArray(2)) Then
                    strTranCntGai(2) = (CInt(strTranCntGai(2)) + 1).ToString("0")
                    strAmountGai(2) = (CInt(strTranCntGai(2)) * CInt(PubConstClass.strPriceGaiArray(2))).ToString("0")

                ElseIf intWeight <= CInt(PubConstClass.strWeightGaiArray(3)) Then
                    strTranCntGai(3) = (CInt(strTranCntGai(3)) + 1).ToString("0")
                    strAmountGai(3) = (CInt(strTranCntGai(3)) * CInt(PubConstClass.strPriceGaiArray(3))).ToString("0")

                ElseIf intWeight <= CInt(PubConstClass.strWeightGaiArray(4)) Then
                    strTranCntGai(4) = (CInt(strTranCntGai(4)) + 1).ToString("0")
                    strAmountGai(4) = (CInt(strTranCntGai(4)) * CInt(PubConstClass.strPriceGaiArray(4))).ToString("0")

                ElseIf intWeight <= CInt(PubConstClass.strWeightGaiArray(5)) Then
                    strTranCntGai(5) = (CInt(strTranCntGai(5)) + 1).ToString("0")
                    strAmountGai(5) = (CInt(strTranCntGai(5)) * CInt(PubConstClass.strPriceGaiArray(5))).ToString("0")

                ElseIf intWeight <= CInt(PubConstClass.strWeightGaiArray(6)) Then
                    strTranCntGai(6) = (CInt(strTranCntGai(6)) + 1).ToString("0")
                    strAmountGai(6) = (CInt(strTranCntGai(6)) * CInt(PubConstClass.strPriceGaiArray(6))).ToString("0")

                ElseIf intWeight <= CInt(PubConstClass.strWeightGaiArray(7)) Then
                    strTranCntGai(7) = (CInt(strTranCntGai(7)) + 1).ToString("0")
                    strAmountGai(7) = (CInt(strTranCntGai(7)) * CInt(PubConstClass.strPriceGaiArray(7))).ToString("0")
                Else
                    strRetVal = "範囲外"
                End If

            Else
                '// 定形外（規格外）
                ' 定形外（重量の判断は定形外の配列（strWeightGaiArray）で行うがカウントは定形の配列（strTranCnt）に合算する
                ' 最初の重量のみ定形外の配列（strTranCntGai，strAmountGai）で合算する
                If intWeight <= CInt(PubConstClass.strWeightNonSArray(0)) Then
                    strTranCntNonS(0) = (CInt(strTranCntNonS(0)) + 1).ToString("0")
                    strAmountNonS(0) = (CInt(strTranCntNonS(0)) * CInt(PubConstClass.strPriceNonSArray(0))).ToString("0")

                ElseIf intWeight <= CInt(PubConstClass.strWeightNonSArray(1)) Then
                    strTranCntNonS(1) = (CInt(strTranCntNonS(1)) + 1).ToString("0")
                    strAmountNonS(1) = (CInt(strTranCntNonS(1)) * CInt(PubConstClass.strPriceNonSArray(1))).ToString("0")

                ElseIf intWeight <= CInt(PubConstClass.strWeightNonSArray(2)) Then
                    strTranCntNonS(2) = (CInt(strTranCntNonS(2)) + 1).ToString("0")
                    strAmountNonS(2) = (CInt(strTranCntNonS(2)) * CInt(PubConstClass.strPriceNonSArray(2))).ToString("0")

                ElseIf intWeight <= CInt(PubConstClass.strWeightNonSArray(3)) Then
                    strTranCntNonS(3) = (CInt(strTranCntNonS(3)) + 1).ToString("0")
                    strAmountNonS(3) = (CInt(strTranCntNonS(3)) * CInt(PubConstClass.strPriceNonSArray(3))).ToString("0")

                ElseIf intWeight <= CInt(PubConstClass.strWeightNonSArray(4)) Then
                    strTranCntNonS(4) = (CInt(strTranCntNonS(4)) + 1).ToString("0")
                    strAmountNonS(4) = (CInt(strTranCntNonS(4)) * CInt(PubConstClass.strPriceNonSArray(4))).ToString("0")

                ElseIf intWeight <= CInt(PubConstClass.strWeightNonSArray(5)) Then
                    strTranCntNonS(5) = (CInt(strTranCntNonS(5)) + 1).ToString("0")
                    strAmountNonS(5) = (CInt(strTranCntNonS(5)) * CInt(PubConstClass.strPriceNonSArray(5))).ToString("0")

                ElseIf intWeight <= CInt(PubConstClass.strWeightNonSArray(6)) Then
                    strTranCntNonS(6) = (CInt(strTranCntNonS(6)) + 1).ToString("0")
                    strAmountNonS(6) = (CInt(strTranCntNonS(6)) * CInt(PubConstClass.strPriceNonSArray(6))).ToString("0")

                ElseIf intWeight <= CInt(PubConstClass.strWeightNonSArray(7)) Then
                    strTranCntNonS(7) = (CInt(strTranCntNonS(7)) + 1).ToString("0")
                    strAmountNonS(7) = (CInt(strTranCntNonS(7)) * CInt(PubConstClass.strPriceNonSArray(7))).ToString("0")
                Else
                    strRetVal = "範囲外"
                End If
            End If

        Catch ex As Exception
            MsgBox("【GetTranCntFromWeight】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 「通数」と「合計金額」と「通数の合計」と「合計金額の合計」を求める
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GetTranCntAndAmount()

        Dim strChkData As String
        Dim strTeikei As String         ' 「0：定形／1:定形外」変数

        Try
            ' (0) = "No"
            ' (1) = "業務名称"
            ' (2) = "取得時間"
            ' (3) = "引受番号"
            ' (4) = "重量"
            ' (5) = "料金"
            ' (6) = "ファイル名称"
            ' (7) = "種別"
            ' (8) = "支店コード"
            ' (9) = "支店名"
            '(10) = "処理予定通数"
            '(11) = "定形／定形外"

            intTranALLCnt = 0
            intAmountALL = 0
            For N = 0 To strTranCnt.Length - 1
                strTranCnt(N) = "0"     ' 通数格納配列クリア（定形）
                strAmount(N) = "0"      ' 合計金額格納配列クリア（定形）
            Next
            For N = 0 To strTranCntGai.Length - 1
                strTranCntGai(N) = "0"  ' 通数格納配列クリア（定形外／規格内）
                strAmountGai(N) = "0"   ' 合計金額格納配列クリア（定形外／規格内）
            Next
            For N = 0 To strTranCntNonS.Length - 1
                strTranCntNonS(N) = "0" ' 通数格納配列クリア（定形外／規格外）
                strAmountNonS(N) = "0"  ' 合計金額格納配列クリア（定形外／規格外）
            Next

            Dim arStartEndHikiuke As ArrayList
            arStartEndHikiuke = New ArrayList
            arStartEndHikiuke.Clear()
            For N = 0 To lstGetDataView.Items.Count - 1

                ' 開始と終了の引受番号を求める為のアレイリストに追加
                arStartEndHikiuke.Add(lstGetDataView.Items(N).SubItems(3).Text)

                If N = 0 Then
                    ' 開始 引受番号の取得
                    strStUnderWRNum = lstGetDataView.Items(N).SubItems(3).Text
                End If
                If N = lstGetDataView.Items.Count - 1 Then
                    ' 終了 引受番号の取得
                    strEnUnderWRNum = lstGetDataView.Items(N).SubItems(3).Text
                End If
                ' 重量を取得する
                strChkData = lstGetDataView.Items(N).SubItems(4).Text
                ' 「定形／定形外」を取得する
                If lstGetDataView.Items(N).SubItems(11).Text = "定形" Then
                    strTeikei = "0"     ' 定形
                ElseIf lstGetDataView.Items(N).SubItems(11).Text = "定形外(規格内)" Then
                    strTeikei = "1"     ' 定形外／規格内
                Else
                    strTeikei = "2"     ' 定形外／規格外
                End If
                ' 重量から通数をカウントアップし合計金額を求める
                GetTranCntFromWeight(strChkData, strTeikei)
            Next

            ' 引受番号が「FROM＞TO」なら引受番号帯が一周したと判断する
            If CDbl(arStartEndHikiuke(0).ToString.Replace("-", "")) > _
                CDbl(arStartEndHikiuke(arStartEndHikiuke.Count - 1).ToString.Replace("-", "")) Then
                ' 引受番号が一周した（昇順にソートしない）
                strStUnderWRNum = arStartEndHikiuke(0).ToString
                strEnUnderWRNum = arStartEndHikiuke(arStartEndHikiuke.Count - 1).ToString
            Else
                ' 引受番号を昇順にソートする
                arStartEndHikiuke.Sort()
                strStUnderWRNum = arStartEndHikiuke(0).ToString
                strEnUnderWRNum = arStartEndHikiuke(arStartEndHikiuke.Count - 1).ToString
            End If

            For N = 0 To strTranCnt.Length - 1
                ' 通数の合計を求める
                intTranALLCnt += CInt(strTranCnt(N))
                ' 合計金額の合計を求める
                intAmountALL += CInt(strAmount(N))
            Next
            For N = 0 To strTranCntGai.Length - 1
                ' 通数の合計を求める
                intTranALLCnt += CInt(strTranCntGai(N))
                ' 合計金額の合計を求める
                intAmountALL += CInt(strAmountGai(N))
            Next
            For N = 0 To strTranCntNonS.Length - 1
                ' 通数の合計を求める
                intTranALLCnt += CInt(strTranCntNonS(N))
                ' 合計金額の合計を求める
                intAmountALL += CInt(strAmountNonS(N))
            Next

            For N = 0 To strTranCnt.Length - 1
                Debug_Print(PubConstClass.strWeightArray(N) & "," & strTranCnt(N) & "," & strAmount(N))
            Next
            For N = 0 To strTranCntGai.Length - 1
                Debug_Print(PubConstClass.strWeightGaiArray(N) & "," & strTranCntGai(N) & "," & strAmountGai(N))
            Next
            For N = 0 To strTranCntNonS.Length - 1
                Debug_Print(PubConstClass.strWeightNonSArray(N) & "," & strTranCntNonS(N) & "," & strAmountNonS(N))
            Next


        Catch ex As Exception
            MsgBox("【GetTranCntAndAmount】" & ex.Message)
        End Try

    End Sub


    ''' <summary>
    ''' 「手入力リスト（簡易書留）」印刷処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Sub PrintHandInputList(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)

        '// 1mm≒4.11
        Dim intYoko1 As Integer = 144   ' 横１の印刷座標（35mm）
        Dim intYoko2 As Integer = 103   ' 横２の印刷座標（25mm）
        Dim intYoko3 As Integer = 238   ' 横３の印刷座標（58mm）
        Dim intYoko4 As Integer = 349   ' 横４の印刷座標（85mm）
        Dim intYoko5 As Integer = 518   ' 横５の印刷座標（126mm）

        Dim intTate1 As Integer = 123   ' 縦１の印刷座標（30mm）
        Dim intTate2 As Integer = 164   ' 縦２の印刷座標（40mm）
        Dim intTate3 As Integer = 206   ' 縦３の印刷座標（50mm）
        Dim intTate4 As Integer = 247   ' 縦４の印刷座標（60mm）

        Dim intSTPosYoko As Integer     ' 印刷開始ポジション（横）
        Dim intSTPosTate As Integer     ' 印刷開始ポジション（縦）

        Dim intOffset As Integer        ' 文字印刷縦方向印刷オフセット
        Dim strArray() As String

        Dim N As Integer                ' 汎用ループカウンタ

        Try

            Call GetTranCntAndAmount()

            ' ヘッダーの印刷
            Dim dtNow As DateTime = DateTime.Now
            Dim t As New Font("メイリオ", 18, FontStyle.Regular)
            Dim h As New Font("メイリオ", 14, FontStyle.Regular)
            Dim uh As New Font("メイリオ", 14, FontStyle.Underline)
            Dim f As New Font("メイリオ", 10, FontStyle.Regular)

            Dim ms As New Font("ＭＳ ゴシック", 14, FontStyle.Regular)

            ' ヘッダー１行目
            e.Graphics.DrawString(Date.Now.ToString("yyyy年MM月dd日"), f, Brushes.Black, intYoko1 + intYoko5, intTate1)
            ' ヘッダー２行目
            strArray = PubConstClass.pblClassForSiten.Split("："c)
            e.Graphics.DrawString("手入力リスト（" & strArray(1) & "）", t, Brushes.Black, intYoko1, intTate2)
            e.Graphics.DrawString(Date.Now.ToString("HH時mm分ss秒"), f, Brushes.Black, intYoko1 + intYoko5, intTate2)
            ' ヘッダー３行目
            e.Graphics.DrawString("店番　" & PubConstClass.pblSitenCode & "　店名　" & PubConstClass.pblSitenName, uh, Brushes.Black, intYoko1, intTate3)

            e.Graphics.DrawString("【" & PubConstClass.pblMachineName & "】", f, Brushes.Black, intYoko1 + intYoko5, intTate3)
            ' ヘッダー４行目
            e.Graphics.DrawString("引受番号　" & strStUnderWRNum & " ～ " & strEnUnderWRNum, f, Brushes.Black, intYoko1, intTate4)

            ' 罫線の印刷
            'e.Graphics.DrawLine(New Pen(Color.Black), intSTPosYoko, intMargin * 5, intLineWidth, intMargin * 5)
            PrintDocument1.DocumentName = "手入力リスト印刷"

            intSTPosYoko = intYoko1
            intSTPosTate = intTate4 + +41
            ' １行目の印刷
            e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(intSTPosYoko, intSTPosTate + 41 * (1 - 1), intYoko2, 41))
            e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(intSTPosYoko, intSTPosTate + 41 * (1 - 1), intYoko3, 41))
            e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(intSTPosYoko, intSTPosTate + 41 * (1 - 1), intYoko4, 41))
            e.Graphics.DrawRectangle(New Pen(Color.Black, 2), New Rectangle(intSTPosYoko, intSTPosTate + 41 * (1 - 1), intYoko5, 41))
            ' ２行目の印刷
            e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(intSTPosYoko, intSTPosTate + 41 * (2 - 1), intYoko2, 41))
            e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(intSTPosYoko, intSTPosTate + 41 * (2 - 1), intYoko3, 41))
            e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(intSTPosYoko, intSTPosTate + 41 * (2 - 1), intYoko4, 41))
            e.Graphics.DrawRectangle(New Pen(Color.Black, 2), New Rectangle(intSTPosYoko, intSTPosTate + 41 * (2 - 1), intYoko5, 41))


            ' 太枠線を印刷
            ' 11行目の外枠線
            e.Graphics.DrawRectangle(New Pen(Color.Black, 2), New Rectangle(intSTPosYoko, intSTPosTate, intYoko5, 41 * 2))
            ' 12行目の外枠線
            e.Graphics.DrawRectangle(New Pen(Color.Black, 2), New Rectangle(intSTPosYoko, intSTPosTate, intYoko5, 41 * 3))
            ' 12行目2列目の外枠線
            e.Graphics.DrawRectangle(New Pen(Color.Black, 2), New Rectangle(intSTPosYoko, intSTPosTate, intYoko3, 41 * 3))
            ' 12行目3列目の外枠線（普通の線）
            e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(intSTPosYoko, intSTPosTate, intYoko4, 41 * 3))

            '// 7＝1.7mm（1mm≒4.11）
            intOffset = 7

            N = 1       '// ヘッダー行
            intSTPosYoko = intYoko1
            e.Graphics.DrawString("　 重量", h, Brushes.Black, intSTPosYoko, intSTPosTate + 41 * (N - 1) + intOffset)
            intSTPosYoko = intYoko1 + intYoko2
            e.Graphics.DrawString("　　料金", h, Brushes.Black, intSTPosYoko, intSTPosTate + 41 * (N - 1) + intOffset)
            intSTPosYoko = intYoko1 + intYoko3
            e.Graphics.DrawString("　 通数", h, Brushes.Black, intSTPosYoko, intSTPosTate + 41 * (N - 1) + intOffset)
            intSTPosYoko = intYoko1 + intYoko4
            e.Graphics.DrawString("    合計金額", h, Brushes.Black, intSTPosYoko, intSTPosTate + 41 * (N - 1) + intOffset)


            N = 1
            intSTPosYoko = intYoko1
            e.Graphics.DrawString(GetWeightFormat(PubConstClass.strWeightGaiArray(0)), ms, Brushes.Black, intSTPosYoko, intSTPosTate + 41 * (N) + intOffset)
            intSTPosYoko = intYoko1 + intYoko2
            e.Graphics.DrawString(GetPriceFormat(PubConstClass.strPriceGaiArray(0)), ms, Brushes.Black, intSTPosYoko, intSTPosTate + 41 * (N) + intOffset)

            intSTPosYoko = intYoko1 + intYoko3  ' 通数
            e.Graphics.DrawString(GetTranCntFormat(strTranCntGai(0)), ms, Brushes.Black, intSTPosYoko, intSTPosTate + 41 * (N) + intOffset)
            intSTPosYoko = intYoko1 + intYoko4  ' 合計金額
            e.Graphics.DrawString(GetAmountFormat(strAmountGai(0)), ms, Brushes.Black, intSTPosYoko, intSTPosTate + 41 * (N) + intOffset)

            N = 3       '// フッター行
            intSTPosYoko = intYoko1
            e.Graphics.DrawString("　　　　総合計", h, Brushes.Black, intSTPosYoko, intSTPosTate + 41 * (N - 1) + intOffset)

            N = 2
            intSTPosYoko = intYoko1 + intYoko3  ' 通数
            e.Graphics.DrawString(GetTranCntFormat(strTranCntGai(0)), ms, Brushes.Black, intSTPosYoko, intSTPosTate + 41 * (N) + intOffset)
            intSTPosYoko = intYoko1 + intYoko4  ' 合計金額
            e.Graphics.DrawString(GetAmountFormat(strAmountGai(0)), ms, Brushes.Black, intSTPosYoko, intSTPosTate + 41 * (N) + intOffset)

            ' １頁のみの印刷
            e.HasMorePages = False

        Catch ex As Exception
            MsgBox("【PrintHandInputList】" & ex.Message)
        End Try

    End Sub


    ''' <summary>
    ''' 「処理データ（簡易書留）」印刷処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Sub PrintTranData(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)

        '// 1mm≒4.11
        Dim intYoko1 As Integer = 144   ' 横１の印刷座標（35mm）
        Dim intYoko2 As Integer = 103   ' 横２の印刷座標（25mm）
        Dim intYoko3 As Integer = 238   ' 横３の印刷座標（58mm）
        Dim intYoko4 As Integer = 349   ' 横４の印刷座標（85mm）
        Dim intYoko5 As Integer = 518   ' 横５の印刷座標（126mm）

        Dim intTate1 As Integer = 123   ' 縦１の印刷座標（30mm）
        Dim intTate2 As Integer = 164   ' 縦２の印刷座標（40mm）
        Dim intTate3 As Integer = 206   ' 縦３の印刷座標（50mm）
        Dim intTate4 As Integer = 247   ' 縦４の印刷座標（60mm）

        Dim intSTPosYoko As Integer     ' 印刷開始ポジション（横）
        Dim intSTPosTate As Integer     ' 印刷開始ポジション（縦）

        Dim intOffset As Integer        ' 文字印刷縦方向印刷オフセット
        Dim strArray() As String

        Dim N As Integer                ' 汎用ループカウンタ

        Try
            Call GetTranCntAndAmount()

            '// 2017.09.29 Ver.B08e hayakawa 追加↓ここから
            Dim iBlankCounter As Integer = 0
            For N = 0 To PubConstClass.strWeightArray.Length - 2
                If PubConstClass.strWeightArray(N) = "0" Then
                    iBlankCounter += 1
                End If
            Next
            '// 2017.09.29 Ver.B08e hayakawa 追加↑ここまで

            ' ヘッダーの印刷
            Dim dtNow As DateTime = DateTime.Now
            Dim t As New Font("メイリオ", 18, FontStyle.Regular)
            Dim h As New Font("メイリオ", 14, FontStyle.Regular)
            Dim f As New Font("メイリオ", 10, FontStyle.Regular)

            Dim uh As New Font("メイリオ", 14, FontStyle.Underline)
            Dim ms As New Font("ＭＳ ゴシック", 14, FontStyle.Regular)

            ' ヘッダー１行目
            e.Graphics.DrawString(Date.Now.ToString("yyyy年MM月dd日"), f, Brushes.Black, intYoko1 + intYoko5, intTate1)
            ' ヘッダー２行目
            strArray = PubConstClass.pblClassForSiten.Split("："c)
            e.Graphics.DrawString("処理データ（" & strArray(1) & "）", t, Brushes.Black, intYoko1, intTate2)
            e.Graphics.DrawString(Date.Now.ToString("HH時mm分ss秒"), f, Brushes.Black, intYoko1 + intYoko5, intTate2)
            ' ヘッダー３行目
            e.Graphics.DrawString("店番　" & PubConstClass.pblSitenCode & "　店名　" & PubConstClass.pblSitenName, uh, Brushes.Black, intYoko1, intTate3)

            e.Graphics.DrawString("【" & PubConstClass.pblMachineName & "】", f, Brushes.Black, intYoko1 + intYoko5, intTate3)
            ' ヘッダー４行目
            e.Graphics.DrawString("引受番号　" & strStUnderWRNum & " ～ " & strEnUnderWRNum, f, Brushes.Black, intYoko1, intTate4)

            ' 罫線の印刷
            'e.Graphics.DrawLine(New Pen(Color.Black), intSTPosYoko, intMargin * 5, intLineWidth, intMargin * 5)
            PrintDocument1.DocumentName = "処理データ印刷"

            Dim iRowHeight As Integer = 28
            'iRowHeight = 41
            intSTPosYoko = intYoko1
            intSTPosTate = intTate4 + iRowHeight

            For N = 1 To 27 - iBlankCounter     '// Ver.B08e
                If N = 1 Then
                    '// １行目タイトル
                    e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(intSTPosYoko, intSTPosTate + iRowHeight * (N - 1), intYoko2, iRowHeight))
                    e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(intSTPosYoko, intSTPosTate + iRowHeight * (N - 1), intYoko3, iRowHeight))
                    e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(intSTPosYoko, intSTPosTate + iRowHeight * (N - 1), intYoko4, iRowHeight))
                    e.Graphics.DrawRectangle(New Pen(Color.Black, 2), New Rectangle(intSTPosYoko, intSTPosTate + iRowHeight * (N - 1), intYoko5, iRowHeight))
                ElseIf N = 2 Or N = 12 - iBlankCounter Or N = 19 - iBlankCounter Then   '// Ver.B08e
                    '// 定形・定形外（規格内）・定形外（規格外）
                    e.Graphics.DrawRectangle(New Pen(Color.Black, 2), New Rectangle(intSTPosYoko, intSTPosTate + iRowHeight * (N - 1), intYoko5, iRowHeight))
                Else
                    e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(intSTPosYoko, intSTPosTate + iRowHeight * (N - 1), intYoko2, iRowHeight))
                    e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(intSTPosYoko, intSTPosTate + iRowHeight * (N - 1), intYoko3, iRowHeight))
                    e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(intSTPosYoko, intSTPosTate + iRowHeight * (N - 1), intYoko4, iRowHeight))
                    e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(intSTPosYoko, intSTPosTate + iRowHeight * (N - 1), intYoko5, iRowHeight))
                End If
            Next N

            ' 太枠線を印刷
            N = 27 - iBlankCounter '// Ver.B08e
            ' 27行目の外枠線
            e.Graphics.DrawRectangle(New Pen(Color.Black, 2), New Rectangle(intSTPosYoko, intSTPosTate, intYoko5, iRowHeight * N))

            N = 28 - iBlankCounter  '// Ver.B08e
            ' 28行目の外枠線（太線）
            e.Graphics.DrawRectangle(New Pen(Color.Black, 2), New Rectangle(intSTPosYoko, intSTPosTate + iRowHeight * (N - 1), intYoko5, iRowHeight))
            ' 28行目2列目の外枠線（普通の線）
            e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(intSTPosYoko, intSTPosTate + iRowHeight * (N - 1), intYoko3, iRowHeight))
            ' 28行目3列目の外枠線（普通の線）
            e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(intSTPosYoko, intSTPosTate + iRowHeight * (N - 1), intYoko4, iRowHeight))

            '// 7＝1.7mm（1mm≒4.11）
            intOffset = 7

            N = 1       '// ヘッダー行
            intSTPosYoko = intYoko1
            e.Graphics.DrawString("　 重量", h, Brushes.Black, intSTPosYoko, intSTPosTate + iRowHeight * (N - 1) + intOffset - 4)
            intSTPosYoko = intYoko1 + intYoko2
            e.Graphics.DrawString("　　料金", h, Brushes.Black, intSTPosYoko, intSTPosTate + iRowHeight * (N - 1) + intOffset - 4)
            intSTPosYoko = intYoko1 + intYoko3
            e.Graphics.DrawString("　 通数", h, Brushes.Black, intSTPosYoko, intSTPosTate + iRowHeight * (N - 1) + intOffset - 4)
            intSTPosYoko = intYoko1 + intYoko4
            e.Graphics.DrawString("    合計金額", h, Brushes.Black, intSTPosYoko, intSTPosTate + iRowHeight * (N - 1) + intOffset - 4)

            '//////////////////
            '// 実データ印字 //
            '//////////////////
            N = 2       '// 定形
            intSTPosYoko = intYoko1
            e.Graphics.DrawString("　定形", h, Brushes.Black, intSTPosYoko, intSTPosTate + iRowHeight * (N - 1) + intOffset - 4)
            For N = 3 To 11 - iBlankCounter     '// Ver.B08e
                intSTPosYoko = intYoko1             ' 重量
                e.Graphics.DrawString(GetWeightFormat(PubConstClass.strWeightArray(N - 3)), ms, Brushes.Black, intSTPosYoko, intSTPosTate + iRowHeight * (N - 1) + intOffset)
                intSTPosYoko = intYoko1 + intYoko2  ' 料金
                e.Graphics.DrawString(GetPriceFormat(PubConstClass.strPriceArray(N - 3)), ms, Brushes.Black, intSTPosYoko, intSTPosTate + iRowHeight * (N - 1) + intOffset)
                intSTPosYoko = intYoko1 + intYoko3  ' 通数
                e.Graphics.DrawString(GetTranCntFormat(strTranCnt(N - 3)), ms, Brushes.Black, intSTPosYoko, intSTPosTate + iRowHeight * (N - 1) + intOffset)
                intSTPosYoko = intYoko1 + intYoko4  ' 合計金額
                e.Graphics.DrawString(GetAmountFormat(strAmount(N - 3)), ms, Brushes.Black, intSTPosYoko, intSTPosTate + iRowHeight * (N - 1) + intOffset)
            Next

            N = 12 - iBlankCounter       '// 定形外（規格内）   '// Ver.B08e
            intSTPosYoko = intYoko1
            e.Graphics.DrawString("　定形外（規格内）", h, Brushes.Black, intSTPosYoko, intSTPosTate + iRowHeight * (N - 1) + intOffset - 4)
            For N = 13 - iBlankCounter To 18 - iBlankCounter    '// Ver.B08e
                intSTPosYoko = intYoko1             ' 重量      '// Ver.B08e↓
                e.Graphics.DrawString(GetWeightFormat(PubConstClass.strWeightGaiArray(N - 13 + iBlankCounter)), ms, Brushes.Black, intSTPosYoko, intSTPosTate + iRowHeight * (N - 1) + intOffset)
                intSTPosYoko = intYoko1 + intYoko2  ' 料金      '// Ver.B08e↓
                e.Graphics.DrawString(GetPriceFormat(PubConstClass.strPriceGaiArray(N - 13 + iBlankCounter)), ms, Brushes.Black, intSTPosYoko, intSTPosTate + iRowHeight * (N - 1) + intOffset)
                intSTPosYoko = intYoko1 + intYoko3  ' 通数      '// Ver.B08e↓
                e.Graphics.DrawString(GetTranCntFormat(strTranCntGai(N - 13 + iBlankCounter)), ms, Brushes.Black, intSTPosYoko, intSTPosTate + iRowHeight * (N - 1) + intOffset)
                intSTPosYoko = intYoko1 + intYoko4  ' 合計金額  '// Ver.B08e↓
                e.Graphics.DrawString(GetAmountFormat(strAmountGai(N - 13 + iBlankCounter)), ms, Brushes.Black, intSTPosYoko, intSTPosTate + iRowHeight * (N - 1) + intOffset)
            Next

            N = 19 - iBlankCounter       '// 定形外（規格外）   '// Ver.B08e
            intSTPosYoko = intYoko1
            e.Graphics.DrawString("　定形外（規格外）", h, Brushes.Black, intSTPosYoko, intSTPosTate + iRowHeight * (N - 1) + intOffset - 4)
            For N = 20 - iBlankCounter To 27 - iBlankCounter    '// Ver.B08e
                intSTPosYoko = intYoko1             ' 重量      '// Ver.B08e↓
                e.Graphics.DrawString(GetWeightFormat(PubConstClass.strWeightNonSArray(N - 20 + iBlankCounter)), ms, Brushes.Black, intSTPosYoko, intSTPosTate + iRowHeight * (N - 1) + intOffset)
                intSTPosYoko = intYoko1 + intYoko2  ' 料金      '// Ver.B08e↓
                e.Graphics.DrawString(GetPriceFormat(PubConstClass.strPriceNonSArray(N - 20 + iBlankCounter)), ms, Brushes.Black, intSTPosYoko, intSTPosTate + iRowHeight * (N - 1) + intOffset)
                intSTPosYoko = intYoko1 + intYoko3  ' 通数      '// Ver.B08e↓
                e.Graphics.DrawString(GetTranCntFormat(strTranCntNonS(N - 20 + iBlankCounter)), ms, Brushes.Black, intSTPosYoko, intSTPosTate + iRowHeight * (N - 1) + intOffset)
                intSTPosYoko = intYoko1 + intYoko4  ' 合計金額  '// Ver.B08e↓
                e.Graphics.DrawString(GetAmountFormat(strAmountNonS(N - 20 + iBlankCounter)), ms, Brushes.Black, intSTPosYoko, intSTPosTate + iRowHeight * (N - 1) + intOffset)
            Next

            '//////////////////////
            '// フッター行の印刷 //
            '//////////////////////
            N = 28 - iBlankCounter      '// Ver.B08e
            intSTPosYoko = intYoko1
            e.Graphics.DrawString("　　　　総合計", h, Brushes.Black, intSTPosYoko, intSTPosTate + iRowHeight * (N - 1) + intOffset - 4)

            N = 27 - iBlankCounter      '// Ver.B08e
            intSTPosYoko = intYoko1 + intYoko3  ' 通数
            e.Graphics.DrawString(GetTranCntFormat(intTranALLCnt.ToString("0")), ms, Brushes.Black, intSTPosYoko, intSTPosTate + iRowHeight * (N) + intOffset)
            intSTPosYoko = intYoko1 + intYoko4  ' 合計金額
            e.Graphics.DrawString(GetAmountFormat(intAmountALL.ToString("0")), ms, Brushes.Black, intSTPosYoko, intSTPosTate + iRowHeight * (N) + intOffset)

            ' １頁のみの印刷
            e.HasMorePages = False

        Catch ex As Exception
            MsgBox("【PrintTranData】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 重量を書式変換して取得
    ''' </summary>
    ''' <param name="strData"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetWeightFormat(ByVal strData As String) As String

        Select Case strData.Length
            Case 1, 2
                '          123456
                strData = "      " & strData & "g"
            Case 3
                '          12345
                strData = "     " & strData & "g"
            Case 4
                '          1234
                strData = "    " & strData & "g"
        End Select

        Return strData

    End Function

    ''' <summary>
    ''' 料金を書式変換して取得
    ''' </summary>
    ''' <param name="strData"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetPriceFormat(ByVal strData As String) As String

        Select Case strData.Length
            Case 1, 2
                '          12 123456
                strData = "  \      " & strData
            Case 3
                '          12 12345
                strData = "  \     " & strData
            Case 4
                '          12 123
                strData = "  \   " & CInt(strData).ToString("0,000")
        End Select

        Return strData

    End Function

    ''' <summary>
    ''' 通数を書式変換して取得
    ''' </summary>
    ''' <param name="strData"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetTranCntFormat(ByVal strData As String) As String

        Select Case strData.Length
            Case 1
                '          1234567
                strData = "       " & strData
            Case 2
                '          123456
                strData = "      " & strData
            Case 3
                '          12345
                strData = "     " & strData
            Case 4
                '          1234
                strData = "    " & strData
        End Select

        Return strData

    End Function

    ''' <summary>
    ''' 合計金額を書式変換して取得
    ''' </summary>
    ''' <param name="strData"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetAmountFormat(ByVal strData As String) As String

        Select Case strData.Length
            Case 1
                '          12 1234567890
                strData = "  \          " & strData
            Case 2
                '          12 123456789
                strData = "  \         " & strData
            Case 3
                '          12 12345678
                strData = "  \        " & strData
            Case 4
                '          12 123456
                strData = "  \      " & CInt(strData).ToString("0,000")
            Case 5
                '          12 12345
                strData = "  \     " & CInt(strData).ToString("0,000")
            Case 6
                '          12 1234
                strData = "  \    " & CInt(strData).ToString("000,000")
            Case 7
                '          12 12
                strData = "  \  " & CInt(strData).ToString("0,000,000")

        End Select

        Return strData

    End Function

    ''' <summary>
    ''' 「手差処理」ボタン処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnHandTran_Click(sender As System.Object, e As System.EventArgs) Handles BtnHandTran.Click

        Try
            MsgBoxForm.strMessage = "手差処理を行いますか？"
            MsgBoxForm.ShowDialog()
            If MsgBoxForm.blnRetValMsgBox = False Then
                Exit Sub
            End If

            Dim strMessage As String = PubConstClass.CMD_SEND_k

            MsgBoxForm.strMessage = "ラベル印刷及び貼付けを行いますか？"
            MsgBoxForm.ShowDialog()
            If MsgBoxForm.blnRetValMsgBox = True Then
                ' ラベル貼り付けを行う手差し処理
                strMessage &= "1"
            Else
                ' ラベル貼り付けを行わない手差し処理
                strMessage &= "0"
                ' カウントアップしないフラグＯＮ
                blnIsNoCount = True
            End If

            Call sendCommand(strMessage)
            ' 手差しフラグＯＮ
            blnIsManualFeedFlg = True

        Catch ex As Exception
            MsgBox("【BtnHandTran_Click】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 「閉じる」ボタン
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click

        Panel1.Visible = False

    End Sub

    Private blnIsYoteiButton As Boolean
    Private blnIsYoteiPlus As Boolean
    Private blnIsZanPlus As Boolean
    'Private Const IntervalValuePlusMinus As Integer = 200
    Private Const IntervalValuePlusMinus As Integer = 100


    Private Sub BtnYoteiPlus_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles BtnYoteiPlus.MouseDown
        blnIsYoteiButton = True
        blnIsYoteiPlus = True
        TimPlusMinus.Interval = IntervalValuePlusMinus
        TimPlusMinus.Enabled = True
    End Sub

    Private Sub BtnYoteiPlus_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles BtnYoteiPlus.MouseUp
        TimPlusMinus.Enabled = False
    End Sub

    Private Sub BtnYoteiMinus_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles BtnYoteiMinus.MouseDown
        blnIsYoteiButton = True
        blnIsYoteiPlus = False
        TimPlusMinus.Interval = IntervalValuePlusMinus
        TimPlusMinus.Enabled = True
    End Sub

    Private Sub BtnYoteiMinus_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles BtnYoteiMinus.MouseUp
        TimPlusMinus.Enabled = False
    End Sub

    Private Sub BtnZanPlus_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles BtnZanPlus.MouseDown
        blnIsYoteiButton = False
        blnIsZanPlus = True
        TimPlusMinus.Interval = IntervalValuePlusMinus
        TimPlusMinus.Enabled = True
    End Sub

    Private Sub BtnZanPlus_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles BtnZanPlus.MouseUp
        TimPlusMinus.Enabled = False
    End Sub

    Private Sub BtnZanMinus_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles BtnZanMinus.MouseDown
        blnIsYoteiButton = False
        blnIsZanPlus = False
        TimPlusMinus.Interval = IntervalValuePlusMinus
        TimPlusMinus.Enabled = True
    End Sub

    Private Sub BtnZanMinus_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles BtnZanMinus.MouseUp
        TimPlusMinus.Enabled = False
    End Sub

    ''' <summary>
    ''' 「＋」「－」ボタン長押し制御処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TimPlusMinus_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TimPlusMinus.Tick

        If blnIsYoteiButton = True Then
            ' 予定処理数の「＋」「－」ボタン
            If blnIsYoteiPlus = True Then
                LblYoteiCnt.Text = (CInt(LblYoteiCnt.Text) + 1).ToString("0")
                strYosoEndNumber = (CDbl(strYosoEndNumber) + 1).ToString("0000000000")
                Debug_Print("【＋】strYosoEndNumber：" & strYosoEndNumber)
                'OutPutLogFile("【＋】strYosoEndNumber：" & strYosoEndNumber)
            Else
                If CInt(LblYoteiCnt.Text) - 1 < 0 Then
                    LblYoteiCnt.Text = "0"
                Else
                    LblYoteiCnt.Text = (CInt(LblYoteiCnt.Text) - 1).ToString("0")
                    strYosoEndNumber = (CDbl(strYosoEndNumber) - 1).ToString("0000000000")
                    Debug_Print("【－】strYosoEndNumber：" & strYosoEndNumber)
                    'OutPutLogFile("【－】strYosoEndNumber：" & strYosoEndNumber)
                End If
            End If
        Else
            ' 残カウントの「＋」「－」ボタン
            If blnIsZanPlus = True Then
                LblZanCnt.Text = (CInt(LblZanCnt.Text) + 1).ToString("0")
                strYosoEndNumber = (CDbl(strYosoEndNumber) + 1).ToString("0000000000")
                Debug_Print("【＋】strYosoEndNumber：" & strYosoEndNumber)
                'OutPutLogFile("【＋】strYosoEndNumber：" & strYosoEndNumber)
            Else
                If CInt(LblZanCnt.Text) - 1 < 0 Then
                    LblZanCnt.Text = "0"
                Else
                    LblZanCnt.Text = (CInt(LblZanCnt.Text) - 1).ToString("0")
                    strYosoEndNumber = (CDbl(strYosoEndNumber) - 1).ToString("0000000000")
                    Debug_Print("【－】strYosoEndNumber：" & strYosoEndNumber)
                    'OutPutLogFile("【－】strYosoEndNumber：" & strYosoEndNumber)
                End If
            End If
        End If

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

            MsgBoxForm.strMessage = "設定内容を送信しますか？"
            MsgBoxForm.ShowDialog()
            If MsgBoxForm.blnRetValMsgBox = False Then
                Exit Sub
            End If

            Dim strSendData As String = PubConstClass.CMD_SEND_b
            strSendData &= CInt(TxtPosYFeeder.Text).ToString("000") & ","
            strSendData &= CInt(TxtPosYLabel.Text).ToString("000") & ","
            strSendData &= CInt(TxtPosXLabel.Text).ToString("000") & ","
            strSendData &= CInt(TxtPosYCapture.Text).ToString("000") & ","
            strSendData &= CInt(TxtPosXCapture.Text).ToString("000") & ","

            ' シリアルポートにデータ送信（設定送信コマンド）
            Call sendCommand(strSendData)

        Catch ex As Exception
            MsgBox("【BtnSendSetData_Click】" & ex.Message)
        End Try

    End Sub

    Private Sub TxtPosYFeeder_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPosYFeeder.KeyPress
        ' 数字のみ入力可能
        e.Handled = CheckKeyPress("1", e)
    End Sub

    Private Sub TxtPosYFeeder_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtPosYFeeder.TextChanged

    End Sub

    Private Sub TxtPosYLabel_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPosYLabel.KeyPress
        ' 数字のみ入力可能
        e.Handled = CheckKeyPress("1", e)
    End Sub

    Private Sub TxtPosYLabel_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtPosYLabel.TextChanged

    End Sub

    Private Sub TxtPosXLabel_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPosXLabel.KeyPress
        ' 数字のみ入力可能
        e.Handled = CheckKeyPress("1", e)
    End Sub

    Private Sub TxtPosXLabel_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtPosXLabel.TextChanged

    End Sub

    Private Sub TxtPosYCapture_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPosYCapture.KeyPress
        ' 数字のみ入力可能
        e.Handled = CheckKeyPress("1", e)
    End Sub

    Private Sub TxtPosYCapture_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtPosYCapture.TextChanged

    End Sub

    Private Sub TxtPosXCapture_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPosXCapture.KeyPress
        ' 数字のみ入力可能
        e.Handled = CheckKeyPress("1", e)
    End Sub

    Private Sub TxtPosXCapture_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtPosXCapture.TextChanged

    End Sub

    Private Sub lblVersion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblVersion.Click

    End Sub

    ''' <summary>
    ''' ラベラーへの印字文字列送信
    ''' </summary>
    ''' <param name="strHikiuke">引受番号（10桁）</param>
    ''' <remarks></remarks>
    Private Sub SendNW7BarCodeData(ByVal strHikiuke As String)

        Dim strSendData As String

        Try
            ' 2バイト
            strSendData = Chr(27) & "A"

            If ChkPositiveDirection.Checked = True Then
                ' 正方向流れ
                ' 37バイト
                strSendData &= GetBarCodeSendData(strHikiuke)
                ' 45バイト
                strSendData &= GetCharSendData(strHikiuke)
            Else
                ' 逆方向流れ
                ' 37バイト
                strSendData &= GetBarCode180SendData(strHikiuke)
                ' 45バイト
                strSendData &= GetChar180SendData(strHikiuke)
            End If

            ' 5バイト
            strSendData &= Chr(27) & "Q1"
            ' 2バイト
            strSendData &= Chr(27) & "Z"

            sendESCCommand(strSendData)

        Catch ex As Exception
            MsgBox("【SendNW7BarCodeData】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="strSendData"></param>
    ''' <remarks></remarks>
    Private Sub sendESCCommand(ByVal strSendData As String)

        Dim strData As String = ""

        Try
            Dim dat As Byte() = System.Text.Encoding.GetEncoding("SHIFT-JIS").GetBytes("Zl" & strSendData & vbCr)
            SerialPort.Write(dat, 0, dat.GetLength(0))
            OutPutLogFile("〓送信バーコードデータ：Zl" & strSendData & "<CR>")

        Catch ex As Exception
            MsgBox("【sendESCCommand】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SendCANCommand()

        Dim strData As String = ""

        Try
            ' CANの送信
            Dim dat As Byte() = System.Text.Encoding.GetEncoding("SHIFT-JIS").GetBytes("Zl" & Chr(24) & vbCr)
            SerialPort.Write(dat, 0, dat.GetLength(0))
            OutPutLogFile("〓送信バーコードデータ：Zl<CAN><CR>")

        Catch ex As Exception
            MsgBox("【BtnCancel_Click】" & ex.Message)
        End Try

    End Sub

    Private Sub Label15_Click(sender As System.Object, e As System.EventArgs) Handles Label15.Click

    End Sub

    Private Sub Label15_DoubleClick(sender As Object, e As System.EventArgs) Handles Label15.DoubleClick

        MsgBox("【幅：" & PubConstClass.imageWinWidth & "／縦：" & PubConstClass.imageWinHeight & "】")
        PictureBox1.Width = PubConstClass.imageWinWidth
        PictureBox1.Height = PubConstClass.imageWinHeight

    End Sub

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
    ''' ディレイ後、撮像処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TimSnapDelay_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TimSnapDelay.Tick

        Try
            TimSnapDelay.Enabled = False

            ' 静止画取得及び画像の暗号化
            Call Snap()

            ' カメラトリガー要求コマンド
            ' 静止画像取得
            'IcImagingControl1.MemorySnapImage()

            '' 静止画像の保存（JPEG形式）１００％クオリティ
            'IcImagingControl1.ImageActiveBuffer.SaveAsJpeg(strSaveImageFileName, 100)
            ' 静止画像の保存（JPEG形式）５０％クオリティ
            'IcImagingControl1.ImageActiveBuffer.SaveAsJpeg(strSaveImageFileName, 50)
            ' 静止画像の表示
            'Call DrawRGB24(IcImagingControl1.ImageActiveBuffer.GetImageDataPtr(), IcImagingControl1.ImageActiveBuffer.Size)
            Call OutPutLogFile("【正常処理数】" & lngOKCount.ToString & "件" & GetMinSecMilli() & "（静止画像保存）")

            ' シリアルポートにデータ送信（画像読取りコマンド）
            Call sendCommand(PubConstClass.CMD_SNAP_OK)

        Catch ex As Exception
            MsgBox("【TimSnapDelay_Tick】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TimSendCom_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TimSendCom.Tick

        Try
            TimSendCom.Enabled = False

            ' 動作可能コマンド送信
            Call sendCommand(PubConstClass.CMD_ENABLE & vbCr)

            If LblTeikei.Text = "定形" Then
                ' 定形
                Call sendCommand(PubConstClass.CMD_SEND_q & "001" & vbCr)
            Else
                ' 定形外
                Call sendCommand(PubConstClass.CMD_SEND_q & "002" & vbCr)
            End If

        Catch ex As Exception
            MsgBox("【TimSendCom_Tick】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ChkPositiveDirection_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkPositiveDirection.CheckedChanged
        '// ChkPositiveDirection_Click() 参照
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ChkPositiveDirection_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkPositiveDirection.Click

        Dim varRetVal As MsgBoxResult

        Try
            ' 動作不可コマンド送信
            Call sendCommand(PubConstClass.CMD_DISABLE & vbCr)

            If ChkPositiveDirection.Checked = False Then
                varRetVal = MsgBox("「正方向流し」のチェックを外しますか？", _
                                   CType(MsgBoxStyle.OkCancel + MsgBoxStyle.Question, MsgBoxStyle), "確認")

                If varRetVal = MsgBoxResult.Ok Then
                    ChkPositiveDirection.Checked = False
                    LblPositiveDirection.Visible = False
                Else
                    ChkPositiveDirection.Checked = True
                    LblPositiveDirection.Visible = True
                End If

            Else
                varRetVal = MsgBox("「正方向流し」のチェックを入れますか？", _
                                   CType(MsgBoxStyle.OkCancel + MsgBoxStyle.Question, MsgBoxStyle), "確認")

                If varRetVal = MsgBoxResult.Ok Then
                    ChkPositiveDirection.Checked = True
                    LblPositiveDirection.Visible = True
                Else
                    ChkPositiveDirection.Checked = False
                    LblPositiveDirection.Visible = False
                End If

            End If

            ' 動作可能コマンド送信
            Call sendCommand(PubConstClass.CMD_ENABLE & vbCr)

        Catch ex As Exception
            MsgBox("【ChkPositiveDirection_Click】" & ex.Message)
        End Try

    End Sub

End Class


