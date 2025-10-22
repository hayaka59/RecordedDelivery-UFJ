Option Explicit On
Option Strict On

Imports System.Windows.Forms
Imports System.Runtime.InteropServices


'//////////////////////////////////////////////////////////////
'キャプチャデバイス選択ダイアログ
'//////////////////////////////////////////////////////////////
Public Class Dlg_CaptureDevice

    '----------------------------------------------------------

    '非公開データ
    Private mGrp As IGraphBuilder
    Private mFlt As IBaseFilter
    Private mPin As IPin
    Private mSelectedDeviceName As String

    '----------------------------------------------------------

    'フォームロード時
    Private Sub Dlg_CaptureDevice_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Start()
    End Sub

    'アクティブ時
    Private Sub Dlg_CaptureDevice_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        ResizeWindow()
    End Sub

    'フォームサイズの調整
    Private Sub ResizeWindow()
        Me.ClientSize = New Size(Me.ClientSize.Width, Pnl_Button.Bottom)
    End Sub

    '----------------------------------------------------------
    '外部公開プロパティ

    'グラフ
    Public ReadOnly Property Graph() As IGraphBuilder
        Get
            Return mGrp
        End Get
    End Property

    'フィルタ
    Public ReadOnly Property Filter() As IBaseFilter
        Get
            Return mFlt
        End Get
    End Property

    'ピン
    Public ReadOnly Property Pin() As IPin
        Get
            Return mPin
        End Get
    End Property

    '----------------------------------------------------------

    'OKボタン押下時
    Private Sub Btn_OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_OK.Click

        '閉じる(成功)
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub

    'キャンセルボタン押下時
    Private Sub Btn_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cancel.Click

        '選択のキャンセル
        ReleaseGraph()

        '閉じる(失敗)
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub

    'デバイス選択時
    Private Sub Cmb_Device_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmb_Device.SelectedIndexChanged
        SelectDevice()
    End Sub

    'ピン選択時
    Private Sub Cmb_Pin_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmb_Pin.SelectedIndexChanged
        SelectPin()
    End Sub

    'デバイスプロパティボタン押下時
    Private Sub Btn_Device_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Device.Click
        If mFlt Is Nothing Then Exit Sub

        'プロパティダイアログ表示
        If OpenDiaglog(mFlt, Me.Handle, mSelectedDeviceName) Then
            MsgBox("プロパティページは使用できません。")
        End If
    End Sub

    'ピンプロパティボタン押下時
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

    'フォーマットボタン押下
    Private Sub Btn_PinFormat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_PinFormat.Click
        Pnl_Format.Visible = Not Pnl_Format.Visible
        ResizeWindow()

        If Pnl_Format.Visible Then
            MakeFormatList()
        End If

    End Sub

    'メジャータイプ変更時
    Private Sub Chk_MajorType_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_MajorType.CheckedChanged
        MakeFormatList()
    End Sub

    'マイナータイプ変更時
    Private Sub Chk_SubType_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_SubType.CheckedChanged
        MakeFormatList()
    End Sub

    'フォーマット変更ボタン押下時
    Private Sub Btn_Format_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Format.Click

        Dim idx As Integer = Lst_Format.SelectedIndex
        OutPutLogFile("変更ボタン押下【Lst_Format.SelectedIndex】" & Lst_Format.SelectedIndex)
        If idx < 0 Then
            MsgBox("フォーマットを選択して下さい。")
            Exit Sub
        End If

        'フォーマット変更
        ChangeFormat(idx)

        'リスト再作成
        MakeFormatList()

    End Sub

    '----------------------------------------------------------

    '選択開始
    Private Sub Start()

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

        '選択開始
        ControlEnable("1", True)

    End Sub

    'コントロールの有効／無効切り替え
    Private Sub ControlEnable(ByVal TagName As String, ByVal Flag As Boolean, Optional ByVal Owner As Control.ControlCollection = Nothing)

        If Owner Is Nothing Then Owner = Me.Controls
        For Each ctl As Control In Owner

            If CStr(ctl.Tag) = TagName Then
                ctl.Enabled = Flag
            End If

            If Not ctl.Controls Is Nothing Then
                ControlEnable(TagName, Flag, ctl.Controls)
            End If

        Next
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
            ' 2015.04.17 hayakawa 追加
            Cmb_Device.SelectedIndex = 0

        Catch ex As Exception
            MsgBox("デバイスの列挙中に問題が発生しました。" + vbCrLf + "理由：" + ex.Message)
        End Try

    End Sub

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
            MsgBox("ピンの列挙中に問題が発生しました。" + vbCrLf + "理由：" + ex.Message)
        End Try

    End Sub

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
            MsgBox("フォーマットの列挙中に問題が発生しました。" + vbCrLf + "理由：" + ex.Message)

        Finally
            If Not mt Is Nothing Then
                DeleteMediaType(mt)
            End If

        End Try

    End Sub

    '----------------------------------------------------------

    'ピンの解放
    Private Sub ReleasePin()

        If Not mPin Is Nothing Then
            Marshal.ReleaseComObject(mPin)
            mPin = Nothing
        End If

    End Sub

    'フィルタ解放
    Private Sub ReleaseFilter()

        'ピンの解放
        ReleasePin()

        'フィルタ解放
        If Not mFlt Is Nothing Then
            Marshal.ReleaseComObject(mFlt)
            mFlt = Nothing
        End If
        mSelectedDeviceName = ""

    End Sub

    'グラフ解放
    Private Sub ReleaseGraph()

        'ピン・フィルタ解放
        ReleaseFilter()

        'グラフ解放
        If Not mGrp Is Nothing Then
            Marshal.ReleaseComObject(mGrp)
            mGrp = Nothing
        End If

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

            System.Console.WriteLine("■mSelectedDeviceName：" + mSelectedDeviceName)

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
            MsgBox(ex.Message)

            'クリア
            Start()
        End Try

    End Sub

    'ピンの選択
    Private Sub SelectPin()

        '状態チェック
        If (mGrp Is Nothing) OrElse (mFlt Is Nothing) Then Exit Sub

        'ピンの選択
        mPin = FindPin(mFlt, Cmb_Pin.Text)

        System.Console.WriteLine("■Cmb_Pin.Text：" + Cmb_Pin.Text)

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

End Class
