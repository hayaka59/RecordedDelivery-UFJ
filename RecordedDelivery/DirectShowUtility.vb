Option Explicit On
Option Strict On

'//////////////////////////////////////////////////////////
'DirectShow関係のユーティリティモジュール
'//////////////////////////////////////////////////////////

Imports System
Imports System.ComponentModel
Imports System.Runtime.InteropServices

Public Module DirectShowUtility

    '//////////////////////////////////////////////////////////
    '//////////////////////////////////////////////////////////
    '汎用関数
#Region "汎用関数"

    'インスタンスの作成
    '引数
    '　CLSIDString              作成するインスタンスのGUID文字列
    '戻り値
    '　生成されたインスタンス
    Public Function CoCreateInstance(ByVal CLSIDString As String) As Object

        Dim comobj As Object = Nothing
        Try
            'クラスID
            Dim cid As Guid
            cid = New Guid(CLSIDString)

            'タイプ取得
            Dim comtype As Type
            comtype = Type.GetTypeFromCLSID(cid)

            'インスタンス化
            comobj = Activator.CreateInstance(comtype)

        Catch ex As Exception
            Trace.WriteLine("インスタンスを作成できません。- " + CLSIDString)
            Throw

        End Try

        Return comobj
    End Function

    'インスタンスの開放
    '引数
    '　Obj                      解放するCOMオブジェクト
    Public Sub ReleaseInstance(Of ObjType)(ByRef Obj As ObjType)
        If Not Obj Is Nothing Then
            Marshal.ReleaseComObject(Obj)
            Obj = Nothing
        End If
    End Sub

    'ポインタから各型データの取得
    '・アンマネージ領域のデータをマネージ領域にコピー
    Public Function PtrToStructure(Of DataType)(ByVal Ptr As IntPtr) As DataType
        Return CType(Marshal.PtrToStructure(Ptr, GetType(DataType)), DataType)
    End Function

#End Region

    '//////////////////////////////////////////////////////////
    '//////////////////////////////////////////////////////////
    'デバッグ用関数
#Region "デバッグ用"

    'グラフの内容をコンソールに出力
    '引数
    '　Graph                    対象グラフ
    Public Sub DebugPrint(ByVal Graph As IGraphBuilder)

        '事前チェック
        If Graph Is Nothing Then Exit Sub

        'フィルタ列挙子取得
        Dim eflt As IEnumFilters = Nothing
        Graph.EnumFilters(eflt)

        'フィルタ列挙
        Dim fc As Integer
        Dim flt As IBaseFilter = Nothing
        Do While eflt.Next(1, flt, fc) = 0

            'フィルタ情報の取得
            Dim finfo As New FILTER_INFO
            Dim fltname As String = "(不明なフィルタ)"
            If flt.QueryFilterInfo(finfo) = 0 Then
                fltname = finfo.achName
                ReleaseInstance(finfo.pUnk)
            End If

            'フィルタ情報表示
            System.Console.WriteLine("[{0}]", fltname)

            'ピン列挙子取得
            Dim epin As IEnumPins = Nothing
            flt.EnumPins(epin)

            'ピン列挙
            Dim pc As Integer
            Dim pin As IPin = Nothing
            Do While epin.Next(1, pin, pc) = 0

                'ピン情報取得
                Dim pinfo As New PIN_INFO
                If pin.QueryPinInfo(pinfo) = 0 Then

                    'ピン情報出力
                    System.Console.Write("  '{0}' ", pinfo.Name)
                    Select Case pinfo.PinDir
                        Case PinDirection.Input
                            System.Console.Write(" <== ")
                        Case PinDirection.Output
                            System.Console.Write(" ==> ")
                        Case Else
                            System.Console.Write(" ??? ")
                    End Select

                    '接続先取得
                    Dim cpin As IPin = Nothing
                    pin.ConnectedTo(cpin)
                    If Not cpin Is Nothing Then
                        '接続済みのピン

                        '接続先ピンの情報取得
                        Dim cpinfo As New PIN_INFO
                        If cpin.QueryPinInfo(cpinfo) = 0 Then

                            '接続先ピン情報出力
                            System.Console.Write("'{0}'@", cpinfo.Name)

                            '接続先フィルタの情報取得
                            Dim cfinfo As New FILTER_INFO
                            If cpinfo.Filter.QueryFilterInfo(cfinfo) = 0 Then
                                ReleaseInstance(finfo.pUnk)
                                System.Console.Write("[{0}]", cfinfo.achName)
                            Else
                                System.Console.Write("(不明なフィルタ)")
                            End If

                            '接続先ピン情報中のフィルタを解放
                            If Not cpinfo.Filter Is Nothing Then Marshal.ReleaseComObject(cpinfo.Filter)

                            '接続先ピンの解放
                            Marshal.ReleaseComObject(cpin)
                        Else
                            System.Console.Write("(不明なピン)")
                        End If

                    End If

                    System.Console.WriteLine()

                    'ピン情報中のフィルタを解放
                    If Not pinfo.Filter Is Nothing Then Marshal.ReleaseComObject(pinfo.Filter)
                End If

                'ピン解放
                Marshal.ReleaseComObject(pin)
            Loop


            'フィルタ解放
            Marshal.ReleaseComObject(flt)
        Loop

        'フィルタ列挙終了
        Marshal.ReleaseComObject(eflt)

    End Sub

    'グラフをGRFファイルに保存
    '引数
    '　Grp                      保存するグラフのIGraphBuilder
    '　Filename                 GRFファイル名
    Public Sub SaveGraphFile(ByRef Grp As IGraphBuilder, ByVal Filename As String)
        Dim ps As IPersistStream = Nothing
        Dim grpstr As IStorage = Nothing
        Dim strm As System.Runtime.InteropServices.ComTypes.IStream = Nothing

        Try
            'IPresistStreamインターフェースの取得
            ps = CType(Grp, IPersistStream)

            'IStorageオブジェクト作成
            Win32API.StgCreateDocfile(Filename, STGM.STGM_CREATE Or STGM.STGM_TRANSACTED Or STGM.STGM_READWRITE Or STGM.STGM_SHARE_EXCLUSIVE, 0, grpstr)

            'ストリーム作成
            grpstr.CreateStream("ActiveMovieGraph", STGM.STGM_WRITE Or STGM.STGM_CREATE Or STGM.STGM_SHARE_EXCLUSIVE, 0, 0, strm)

            'グラフ保存
            ps.Save(strm, True)

            'ファイルに出力
            grpstr.Commit(0)

        Catch ex As Exception
            '失敗
            Throw

        Finally
            '不要となったオブジェクトの開放

            If Not ps Is Nothing Then
                Marshal.ReleaseComObject(ps)
                ps = Nothing
            End If

            If Not grpstr Is Nothing Then
                Marshal.ReleaseComObject(grpstr)
                grpstr = Nothing
            End If

            If Not strm Is Nothing Then
                Marshal.ReleaseComObject(strm)
                strm = Nothing
            End If
        End Try

    End Sub

    'GRFファイルからグラフを読み込み
    '引数
    '　Filename                 GRFファイル名
    '戻り値
    '　読み込まれたグラフのIGraphBuilder
    Public Function LoadGraphFilte(ByVal Filename As String) As IGraphBuilder

        'クラスＩＤ準備
        Dim FilterGraphManagerClassID As Guid
        FilterGraphManagerClassID = New Guid(GUIDString.CLSID_FilterGraph)

        'タイプの取得
        Dim FilterGraphManagerType As Type
        FilterGraphManagerType = Type.GetTypeFromCLSID(FilterGraphManagerClassID)

        'フィルタグラフマネージャのインスタンス作成
        Dim FilterGraphManagerObject As Object
        FilterGraphManagerObject = Activator.CreateInstance(FilterGraphManagerType)

        'IGraphBuilderインターフェースの取得
        Dim newgrp As IGraphBuilder
        newgrp = CType(FilterGraphManagerObject, IGraphBuilder)

        Dim grpstr As IStorage = Nothing
        Dim ps As IPersistStream = Nothing
        Dim strm As System.Runtime.InteropServices.ComTypes.IStream = Nothing
        Try
            '(普通の)ファイルであるかチェック
            If Win32API.StgIsStorageFile(Filename) <> 0 Then Return Nothing

            'IStorageオブジェクト作成
            Win32API.StgOpenStorage(Filename, Nothing, STGM.STGM_TRANSACTED Or STGM.STGM_READ Or STGM.STGM_SHARE_DENY_WRITE, Nothing, 0, grpstr)

            'IPresistStreamインターフェースの取得
            ps = CType(newgrp, IPersistStream)

            'ストリーム作成
            grpstr.OpenStream("ActiveMovieGraph", Nothing, STGM.STGM_READ Or STGM.STGM_SHARE_EXCLUSIVE, 0, strm)

            '読込
            ps.Load(strm)

        Catch ex As Exception
            '失敗

            If Not newgrp Is Nothing Then
                Marshal.ReleaseComObject(newgrp)
                newgrp = Nothing
            End If

            Throw

        Finally
            '不要となったオブジェクトの開放

            If Not grpstr Is Nothing Then
                Marshal.ReleaseComObject(grpstr)
                grpstr = Nothing
            End If

            If Not ps Is Nothing Then
                Marshal.ReleaseComObject(ps)
                ps = Nothing
            End If

            If Not strm Is Nothing Then
                Marshal.ReleaseComObject(strm)
                strm = Nothing
            End If

        End Try

        Return newgrp
    End Function

#End Region

    '//////////////////////////////////////////////////////////
    '//////////////////////////////////////////////////////////
    '例外関係
#Region "例外関係"

    'DirectShow関連のエラーメッセージ取得
    '引数
    '　ResultCode               リターンコード
    '戻り値
    '　リターンコードに対応したメッセージ
    Public Function GetDirectShowMessage(ByVal ResultCode As Integer) As String
        Return GetDirectShowMessage(CType(ResultCode, DirectShowHRESULT))
    End Function
    Public Function GetDirectShowMessage(ByVal ResultCode As DirectShowHRESULT) As String
        Dim mes As String

        Select Case ResultCode
            Case DirectShowHRESULT.VFW_E_INVALIDMEDIATYPE : mes = "指定されたメディア タイプは無効である。"        '= &H80040200
            Case DirectShowHRESULT.VFW_E_INVALIDSUBTYPE : mes = "指定されたメディア サブタイプは無効である。"      '= &H80040201
            Case DirectShowHRESULT.VFW_E_NEED_OWNER : mes = "このオブジェクトは集成オブジェクトとしてのみ作成できる。"        '= &H80040202
            Case DirectShowHRESULT.VFW_E_ENUM_OUT_OF_SYNC : mes = "列挙オブジェクトの状態が変化して、列挙子の状態との矛盾が発生した。"       '= &H80040203
            Case DirectShowHRESULT.VFW_E_ALREADY_CONNECTED : mes = "処理に含まれるピンが既に少なくとも 1 つ接続されている。"       '= &H80040204
            Case DirectShowHRESULT.VFW_E_FILTER_ACTIVE : mes = "フィルタがアクティブなので、この処理を実行できない。"      '= &H80040205
            Case DirectShowHRESULT.VFW_E_NO_TYPES : mes = "指定されたいずれかのピンがメディア タイプをサポートしていない。"        '= &H80040206
            Case DirectShowHRESULT.VFW_E_NO_ACCEPTABLE_TYPES : mes = "これらのピンに共通のメディア タイプがない。"      '= &H80040207
            Case DirectShowHRESULT.VFW_E_INVALID_DIRECTION : mes = "同じ方向のピンを 2 つ接続することはできない。"        '= &H80040208
            Case DirectShowHRESULT.VFW_E_NOT_CONNECTED : mes = "ピンが接続されていないため、処理を実行できない。"        '= &H80040209
            Case DirectShowHRESULT.VFW_E_NO_ALLOCATOR : mes = "サンプル バッファ アロケータが利用不可能。"      '= &H8004020A
            Case DirectShowHRESULT.VFW_E_RUNTIME_ERROR : mes = "実行時エラーが発生した。"        '= &H8004020B
            Case DirectShowHRESULT.VFW_E_BUFFER_NOTSET : mes = "バッファ空間が設定されていない。"        '= &H8004020C
            Case DirectShowHRESULT.VFW_E_BUFFER_OVERFLOW : mes = "バッファの大きさが足りない。"      '= &H8004020D
            Case DirectShowHRESULT.VFW_E_BADALIGN : mes = "無効なアラインメントが指定された。"       '= &H8004020E
            Case DirectShowHRESULT.VFW_E_ALREADY_COMMITTED : mes = "アロケータはコミットされなかった。「IMemAllocator::Commit」を参照すること。"        '= &H8004020F
            Case DirectShowHRESULT.VFW_E_BUFFERS_OUTSTANDING : mes = "1 つまたは複数のバッファがアクティブである。"     '= &H80040210
            Case DirectShowHRESULT.VFW_E_NOT_COMMITTED : mes = "アロケータがアクティブでないときはサンプルを割り当てることができない。"     '= &H80040211
            Case DirectShowHRESULT.VFW_E_SIZENOTSET : mes = "サイズが設定されていないので、メモリを割り当てることができない。"        '= &H80040212
            Case DirectShowHRESULT.VFW_E_NO_CLOCK : mes = "クロックが定義されていないので、同期を行えない。"        '= &H80040213
            Case DirectShowHRESULT.VFW_E_NO_SINK : mes = "品質シンクが定義されていないので、品質メッセージを送信できない。"        '= &H80040214
            Case DirectShowHRESULT.VFW_E_NO_INTERFACE : mes = "必要なインターフェイスが実装されていない。"       '= &H80040215
            Case DirectShowHRESULT.VFW_E_NOT_FOUND : mes = "オブジェクトまたは名前が見つからなかった。"       '= &H80040216
            Case DirectShowHRESULT.VFW_E_CANNOT_CONNECT : mes = "接続を確立する中間フィルタの組み合わせが見つからなかった。"       '= &H80040217
            Case DirectShowHRESULT.VFW_E_CANNOT_RENDER : mes = "ストリームをレンダリングするフィルタの組み合わせが見つからなかった。"      '= &H80040218
            Case DirectShowHRESULT.VFW_E_CHANGING_FORMAT : mes = "フォーマットを動的に変更できない。"       '= &H80040219
            Case DirectShowHRESULT.VFW_E_NO_COLOR_KEY_SET : mes = "カラー キーが設定されていない。"        '= &H8004021A
            Case DirectShowHRESULT.VFW_E_NOT_OVERLAY_CONNECTION : mes = "現在のピン接続は IOverlay 転送を使っていない。"        '= &H8004021B
            Case DirectShowHRESULT.VFW_E_NOT_SAMPLE_CONNECTION : mes = "現在のピン接続は IMemInputPin 転送を使っていない。"        '= &H8004021C
            Case DirectShowHRESULT.VFW_E_PALETTE_SET : mes = "カラー キーを設定すると、既に設定されているパレットと矛盾する可能性がある。"      '= &H8004021D
            Case DirectShowHRESULT.VFW_E_COLOR_KEY_SET : mes = "パレットを設定すると、既に設定されているカラー キーと矛盾する可能性がある。"      '= &H8004021E
            Case DirectShowHRESULT.VFW_E_NO_COLOR_KEY_FOUND : mes = "一致するカラー キーがない。"      '= &H8004021F
            Case DirectShowHRESULT.VFW_E_NO_PALETTE_AVAILABLE : mes = "パレットが利用不可能。"     '= &H80040220
            Case DirectShowHRESULT.VFW_E_NO_DISPLAY_PALETTE : mes = "ディスプレイはパレットを使わない。"       '= &H80040221
            Case DirectShowHRESULT.VFW_E_TOO_MANY_COLORS : mes = "現在のディスプレイ設定に対して色が多すぎる。"      '= &H80040222
            Case DirectShowHRESULT.VFW_E_STATE_CHANGED : mes = "サンプルの処理を待っている間に状態が変化した。"     '= &H80040223
            Case DirectShowHRESULT.VFW_E_NOT_STOPPED : mes = "フィルタが停止していないので、処理を実行できない。"       '= &H80040224
            Case DirectShowHRESULT.VFW_E_NOT_PAUSED : mes = "フィルタが停止していないため、処理を実行できなかった。"     '= &H80040225
            Case DirectShowHRESULT.VFW_E_NOT_RUNNING : mes = "フィルタが実行されていないので、処理を実行できない。"      '= &H80040226
            Case DirectShowHRESULT.VFW_E_WRONG_STATE : mes = "フィルタが不正な状態にあるため、処理を実行できなかった。"        '= &H80040227
            Case DirectShowHRESULT.VFW_E_START_TIME_AFTER_END : mes = "サンプルの開始タイムがサンプルの終了タイムの後になっている。"      '= &H80040228
            Case DirectShowHRESULT.VFW_E_INVALID_RECT : mes = "提供された矩形が無効である。"      '= &H80040229
            Case DirectShowHRESULT.VFW_E_TYPE_NOT_ACCEPTED : mes = "このピンは、提供されたメディア タイプを使えない。"       '= &H8004022A
            Case DirectShowHRESULT.VFW_E_SAMPLE_REJECTED : mes = "このサンプルはレンダリングできない。"      '= &H8004022B
            Case DirectShowHRESULT.VFW_E_SAMPLE_REJECTED_EOS : mes = "ストリームの終わりに到達しているので、このサンプルをレンダリングできない。"       '= &H8004022C
            Case DirectShowHRESULT.VFW_E_DUPLICATE_NAME : mes = "同じ名前のフィルタを追加しようとしたが失敗した。"        '= &H8004022D
            Case DirectShowHRESULT.VFW_S_DUPLICATE_NAME : mes = "同じ名前のフィルタを追加しようとしたところ、名前を変更して処理が成功した。"       '= &H4022D   
            Case DirectShowHRESULT.VFW_E_TIMEOUT : mes = "タイムアウト期間が過ぎた。"       '= &H8004022E
            Case DirectShowHRESULT.VFW_E_INVALID_FILE_FORMAT : mes = "ファイル フォーマットが無効である。"      '= &H8004022F
            Case DirectShowHRESULT.VFW_E_ENUM_OUT_OF_RANGE : mes = "リストが使い果たされた。"        '= &H80040230
            Case DirectShowHRESULT.VFW_E_CIRCULAR_GRAPH : mes = "フィルタ グラフが循環している。"        '= &H80040231
            Case DirectShowHRESULT.VFW_E_NOT_ALLOWED_TO_SAVE : mes = "この状態での更新は許されない。"     '= &H80040232
            Case DirectShowHRESULT.VFW_E_TIME_ALREADY_PASSED : mes = "過去のタイムのコマンドをキューに入れようとした。"        '= &H80040233
            Case DirectShowHRESULT.VFW_E_ALREADY_CANCELLED : mes = "キューに入れられたコマンドは既にキャンセルされていた。"     '= &H80040234
            Case DirectShowHRESULT.VFW_E_CORRUPT_GRAPH_FILE : mes = "ファイルが壊れているのでレンダリングできない。"     '= &H80040235
            Case DirectShowHRESULT.VFW_E_ADVISE_ALREADY_SET : mes = "IOverlay アドバイズ リンクが既に存在している。"        '= &H80040236
            Case DirectShowHRESULT.VFW_S_STATE_INTERMEDIATE : mes = "状態の移行が完了していない。"      '= &H40237   
            Case DirectShowHRESULT.VFW_E_NO_MODEX_AVAILABLE : mes = "フルスクリーン モードは利用できない。"     '= &H80040238
            Case DirectShowHRESULT.VFW_E_NO_ADVISE_SET : mes = "このアドバイズは正常に設定されていないのでキャンセルできない。"     '= &H80040239
            Case DirectShowHRESULT.VFW_E_NO_FULLSCREEN : mes = "フルスクリーン モードは利用できない。"     '= &H8004023A
            Case DirectShowHRESULT.VFW_E_IN_FULLSCREEN_MODE : mes = "フルスクリーン モードでは IVideoWindow メソッドを呼び出せない。"     '= &H8004023B
            Case DirectShowHRESULT.VFW_E_UNKNOWN_FILE_TYPE : mes = "このファイルのメディア タイプが認識されない。"     '= &H80040240
            Case DirectShowHRESULT.VFW_E_CANNOT_LOAD_SOURCE_FILTER : mes = "このファイルのソース フィルタをロードできない。"        '= &H80040241
            Case DirectShowHRESULT.VFW_S_PARTIAL_RENDER : mes = "このムービーにサポートされないフォーマットのストリームが含まれている。"     '= &H40242   
            Case DirectShowHRESULT.VFW_E_FILE_TOO_SHORT : mes = "ファイルが不完全である。"        '= &H80040243
            Case DirectShowHRESULT.VFW_E_INVALID_FILE_VERSION : mes = "ファイルのバージョン番号が無効である。"     '= &H80040244
            Case DirectShowHRESULT.VFW_S_SOME_DATA_IGNORED : mes = "ファイルにいくつかの使用されていないプロパティ設定が含まれている。"       '= &H40245   
            Case DirectShowHRESULT.VFW_S_CONNECTIONS_DEFERRED : mes = "一部の接続が失敗して遅延した。"     '= &H40246   
            Case DirectShowHRESULT.VFW_E_INVALID_CLSID : mes = "このファイルは壊れている。無効なクラス識別子が含まれている。"      '= &H80040247
            Case DirectShowHRESULT.VFW_E_INVALID_MEDIA_TYPE : mes = "このファイルは壊れている。無効なメディア タイプが含まれている。"        '= &H80040248
            Case DirectShowHRESULT.VFW_E_SAMPLE_TIME_NOT_SET : mes = "このサンプルにはタイム スタンプが設定されていない。"      '= &H80040249
            Case DirectShowHRESULT.VFW_S_RESOURCE_NOT_NEEDED : mes = "指定されたリソースはもはや必要ない。"      '= &H40250   
            Case DirectShowHRESULT.VFW_E_MEDIA_TIME_NOT_SET : mes = "このサンプルにはメディア タイムが設定されていない。"      '= &H80040251
            Case DirectShowHRESULT.VFW_E_NO_TIME_FORMAT_SET : mes = "メディア タイム フォーマットが選択されていない。"       '= &H80040252
            Case DirectShowHRESULT.VFW_E_MONO_AUDIO_HW : mes = "オーディオ デバイスがモノラル専用なので、バランスを変更できない。"       '= &H80040253
            Case DirectShowHRESULT.VFW_S_MEDIA_TYPE_IGNORED : mes = "永続グラフのメディア タイプに接続できない。"      '= &H40254   
            Case DirectShowHRESULT.VFW_E_NO_DECOMPRESSOR : mes = "ビデオ ストリームを再生できない。適切なデコンプレッサが見つからなかった。"       '= &H80040255
            Case DirectShowHRESULT.VFW_E_NO_AUDIO_HARDWARE : mes = "オーディオ ストリームを再生できない。オーディオ ハードウェアが利用できない、またはハードウェアがサポートされていない。"        '= &H80040256
            Case DirectShowHRESULT.VFW_S_VIDEO_NOT_RENDERED : mes = "ビデオ ストリームを再生できない。適切なレンダラが見つからなかった。"      '= &H40257   
            Case DirectShowHRESULT.VFW_S_AUDIO_NOT_RENDERED : mes = "オーディオ ストリームを再生できない。適切なレンダラが見つからなかった。"        '= &H40258   
            Case DirectShowHRESULT.VFW_E_RPZA : mes = "ビデオ ストリームを再生できない。フォーマット 'RPZA' はサポートされていない。"     '= &H80040259
            Case DirectShowHRESULT.VFW_S_RPZA : mes = "ビデオ ストリームを再生できない。フォーマット 'RPZA' はサポートされていない。"     '= &H4025A   
            Case DirectShowHRESULT.VFW_E_PROCESSOR_NOT_SUITABLE : mes = "DirectShow はこのプロセッサ上で MPEG ムービーを再生できない。"     '= &H8004025B
            Case DirectShowHRESULT.VFW_E_UNSUPPORTED_AUDIO : mes = "オーディオ ストリームを再生できない。このオーディオ フォーマットはサポートされていない。"       '= &H8004025C
            Case DirectShowHRESULT.VFW_E_UNSUPPORTED_VIDEO : mes = "ビデオ ストリームを再生できない。このビデオ フォーマットはサポートされていない。"       '= &H8004025D
            Case DirectShowHRESULT.VFW_E_MPEG_NOT_CONSTRAINED : mes = "このビデオ ストリームは規格に準拠していないので DirectShow で再生できない。"        '= &H8004025E
            Case DirectShowHRESULT.VFW_E_NOT_IN_GRAPH : mes = "フィルタ グラフに存在しないオブジェクトに要求された関数を実行できない。"        '= &H8004025F
            Case DirectShowHRESULT.VFW_S_ESTIMATED : mes = "返された値は予測値である。値の正確さを保証できない。"      '= &H40260   
            Case DirectShowHRESULT.VFW_E_NO_TIME_FORMAT : mes = "オブジェクトのタイム フォーマットにアクセスできない。"     '= &H80040261
            Case DirectShowHRESULT.VFW_E_READ_ONLY : mes = "ストリームが読み出し専用で、フィルタによってデータが変更されているので、接続を確立できない。"      '= &H80040262
            Case DirectShowHRESULT.VFW_S_RESERVED : mes = "この成功コードは、DirectShow の内部処理用に予約されている。"     '= &H40263   
            Case DirectShowHRESULT.VFW_E_BUFFER_UNDERFLOW : mes = "バッファが十分に満たされていない。"       '= &H80040264
            Case DirectShowHRESULT.VFW_E_UNSUPPORTED_STREAM : mes = "ファイルを再生できない。フォーマットがサポートされていない。"      '= &H80040265
            Case DirectShowHRESULT.VFW_E_NO_TRANSPORT : mes = "同じ転送をサポートしていないのでピンどうしを接続できない。"       '= &H80040266
            Case DirectShowHRESULT.VFW_S_STREAM_OFF : mes = "ストリームがオフになった。"       '= &H40267   
            Case DirectShowHRESULT.VFW_S_CANT_CUE : mes = "フィルタはアクティブだが、データを出力することができない。「IMediaFilter::GetState」を参照すること。"       '= &H40268   
            Case DirectShowHRESULT.VFW_E_BAD_VIDEOCD : mes = "デバイスがビデオ CD を正常に読み出せない、またはビデオ CD のデータが壊れている。"        '= &H80040269
            Case DirectShowHRESULT.VFW_S_NO_STOP_TIME : mes = "サンプルに終了タイムではなく開始タイムが設定されていた。この場合、返される終了タイムは開始タイムに 1 を加えた値に設定される。"        '= &H80040270
            Case DirectShowHRESULT.VFW_E_OUT_OF_VIDEO_MEMORY : mes = "このディスプレイ解像度と色数に対してビデオ メモリが不十分である。解像度を低くするとよい。"       '= &H80040271
            Case DirectShowHRESULT.VFW_E_VP_NEGOTIATION_FAILED : mes = "ビデオ ポート接続ネゴシエーション プロセスが失敗した。"        '= &H80040272
            Case DirectShowHRESULT.VFW_E_DDRAW_CAPS_NOT_SUITABLE : mes = "Microsoft DirectDraw がインストールされていない、またはビデオ カードの能力が適切でない。ディスプレイが 16 色モードでないことを確認すること。"     '= &H80040273
            Case DirectShowHRESULT.VFW_E_NO_VP_HARDWARE : mes = "ビデオ ポート ハードウェアが利用できない、またはハードウェアが応答しない。"      '= &H80040274
            Case DirectShowHRESULT.VFW_E_NO_CAPTURE_HARDWARE : mes = "キャプチャ ハードウェアが利用できない、またはハードウェアが応答しない。"        '= &H80040275
            Case DirectShowHRESULT.VFW_E_DVD_OPERATION_INHIBITED : mes = "この時点でこのユーザー操作は DVD コンテンツによって禁止されている。"        '= &H80040276
            Case DirectShowHRESULT.VFW_E_DVD_INVALIDDOMAIN : mes = "現在のドメインでこの処理は許可されていない。"      '= &H80040277
            Case DirectShowHRESULT.VFW_E_DVD_NO_BUTTON : mes = "要求されたボタンが利用できない。"        '= &H80040278
            Case DirectShowHRESULT.VFW_E_DVD_GRAPHNOTREADY : mes = "DVD-Video 再生グラフが作成されていない。"       '= &H80040279
            Case DirectShowHRESULT.VFW_E_DVD_RENDERFAIL : mes = "DVD-Video 再生グラフの作成が失敗した。"        '= &H8004027A
            Case DirectShowHRESULT.VFW_E_DVD_DECNOTENOUGH : mes = "デコーダが不十分だったために、DVD-Video 再生グラフが作成できなかった。"        '= &H8004027B
            Case DirectShowHRESULT.VFW_E_DVD_NOT_IN_KARAOKE_MODE : mes = "DVD ナビゲータはカラオケ モードではない。"     '= &H8004028B
            Case DirectShowHRESULT.VFW_E_FRAME_STEP_UNSUPPORTED : mes = "コマ送りはサポートされていない。"        '= &H8004028E
            Case DirectShowHRESULT.VFW_E_PIN_ALREADY_BLOCKED_ON_THIS_THREAD : mes = "ピンは既に呼び出し元のスレッドでブロックされている。"      '= &H80040293
            Case DirectShowHRESULT.VFW_E_PIN_ALREADY_BLOCKED : mes = "ピンは既に他のスレッドでブロックされている。"      '= &H80040294
            Case DirectShowHRESULT.VFW_E_CERTIFICATION_FAILURE : mes = "このフィルタの使用は、ソフトウェア キーによって制限されている。アプリケーションは、フィルタのロックを解除しなければならない。"     '= &H80040295
            Case DirectShowHRESULT.VFW_E_BAD_KEY : mes = "レジストリ エントリが壊れている。"       '= &H800403F2
            Case DirectShowHRESULT.E_NOTIMPL : mes = "実装されていません。"
            Case DirectShowHRESULT.E_OUTOFMEMORY : mes = "メモリが足りません。"
            Case DirectShowHRESULT.E_INVALIDARG : mes = "引数が不正です。"
            Case DirectShowHRESULT.E_NOINTERFACE : mes = "インターフェースがありません。"
            Case DirectShowHRESULT.E_POINTER : mes = "NULLポインタが引数に指定されました。"
            Case DirectShowHRESULT.E_HANDLE : mes = "不正なハンドルです。"
            Case DirectShowHRESULT.E_ABORT : mes = "操作が中止されました。"
            Case DirectShowHRESULT.E_FAIL : mes = "失敗しました。"
            Case DirectShowHRESULT.E_ACCESSDENIED : mes = "アクセスは拒否されました。"
            Case DirectShowHRESULT.S_OK : mes = "成功"
            Case Else
                mes = "不明なエラーです。(" + Hex$(ResultCode) + ")"
        End Select

        Return mes
    End Function

    '//////////////////////////////////////////////////////////
    'DirectShow例外クラス
    Public Class DirectShowException
        Inherits COMException

        '------------------------------------------------------
        '非公開データ
        Private mMsg As String

        '------------------------------------------------------
        '------------------------------------------------------

        'コンストラクタ
        Public Sub New(ByVal ex As COMException)
            MyBase.HResult = ex.ErrorCode
            mMsg = ""
        End Sub
        Public Sub New(ByVal HResult As Integer, Optional ByVal Msg As String = "")
            MyBase.HResult = HResult
            mMsg = Msg
        End Sub
        Public Sub New(ByVal Msg As String)
            MyBase.HResult = 0
            mMsg = Msg
        End Sub

        'エラーメッセージ
        Public Overrides ReadOnly Property Message() As String
            Get
                If mMsg = "" Then
                    '拡張メッセージなしの場合、
                    '純粋なDirectShowのエラーメッセージを返す
                    Return GetDirectShowMessage(MyBase.ErrorCode)
                End If

                '成功の場合は拡張メッセージのみを返す。
                If MyBase.ErrorCode >= 0 Then
                    Return mMsg
                End If

                '拡張メッセージにDirectShowのエラーメッセージを加えて返す
                Return mMsg + vbCrLf + "理由：" + GetDirectShowMessage(MyBase.ErrorCode)
            End Get
        End Property

    End Class


#End Region


    '//////////////////////////////////////////////////////////
    '//////////////////////////////////////////////////////////
    'グラフ操作用関数
#Region "グラフ操作用関数"

    'グラフの生成
    '戻り値
    '　Nothing               失敗
    '　Nothing以外           IGraphBuilderインターフェース(成功)
    Public Function CreateNewGraph() As IGraphBuilder

        'インスタンス生成
        Dim obj As Object = CoCreateInstance(DirectShowDefine.GUIDString.CLSID_FilterGraph)
        If obj Is Nothing Then Return Nothing

        '成功
        Return CType(obj, IGraphBuilder)
    End Function

    'フィルタのインスタンス作成
    '引数
    '　CLSIDString           フィルタのGUIDを表す文字列
    '戻り値
    '　Nothing               失敗
    '　Nothing以外           IBaseFilterインターフェース(成功)
    Public Function CreateFilter(ByVal CLSIDString As String) As IBaseFilter

        'クラスＩＤ準備
        Dim FilterClassID As Guid
        FilterClassID = New Guid(CLSIDString)

        'タイプの取得
        Dim FilterType As Type
        FilterType = Type.GetTypeFromCLSID(FilterClassID)

        'フィルタのインスタンス作成
        Dim FilterObject As Object
        FilterObject = Activator.CreateInstance(FilterType)

        'IBaseFilterインターフェース取得
        Dim flt As IBaseFilter = TryCast(FilterObject, IBaseFilter)

        Return flt
    End Function

    'フィルタをグラフに追加
    '引数
    '　Grp                      グラフ
    '　CLSIDString              フィルタのGUIDを表す文字列
    '　FilterCaption            フィルタ名称
    '戻り値
    '　Nothing                  失敗
    '　Nothing以外              IBaseFilterインターフェース(成功)
    Public Function AddFilter(ByVal Grp As IGraphBuilder, ByVal CLSIDString As String, ByVal FilterCaption As String) As IBaseFilter

        'フィルタインスタンス生成
        Dim flt As IBaseFilter
        flt = CreateFilter(CLSIDString)

        'グラフに追加
        Dim rc As Integer
        rc = Grp.AddFilter(flt, FilterCaption)
        If rc <> 0 Then Throw New DirectShowException(rc, "グラフにフィルタを追加できません。")

        '成功
        Return flt
    End Function

    'フィルタをグラフに追加(名前指定)
    '引数
    '　Grp                      グラフ
    '　Category                 フィルタのカテゴリ
    '　FilterName               フィルタの名称
    '　SkipCount                フィルタ列挙時のスキップ数
    '　FilterCaption            フィルタ名称
    '戻り値
    '　Nothing                  失敗
    '　Nothing以外              IBaseFilterインターフェース(成功)
    Public Function AddFilter(ByVal Grp As IGraphBuilder, ByVal Category As String, ByVal FilterName As String, ByVal SkipCount As Integer, ByVal FilterCaption As String) As IBaseFilter

        'フィルタを列挙し、対象フィルタを見つけたらグラフに追加する
        Dim afp As New ADDFILTERPARAM
        afp.Grp = Grp
        afp.FilterName = FilterName
        afp.SkipCount = SkipCount
        afp.FilterCaption = FilterCaption
        afp.Filter = Nothing
        EnumFiltersAlgorithm(Category, New DelegateEnumFilters(AddressOf AddFilterFunc), afp)

        Return afp.Filter
    End Function
    Private Function AddFilterFunc(ByRef Mon As ComTypes.IMoniker, ByVal PropertyBag As IPropertyBag, ByVal Param As Object) As Boolean

        'パラメタ取得
        Dim afp As ADDFILTERPARAM = CType(Param, ADDFILTERPARAM)

        '名称取得
        Dim fnameobj As Object = Nothing
        PropertyBag.Read("FriendlyName", fnameobj, 0)
        Dim fname As String = CStr(fnameobj)
        fnameobj = Nothing

        '判定
        If fname = afp.FilterName Then
            If afp.SkipCount > 0 Then
                'スキップ
                afp.SkipCount -= 1
            Else
                '対象フィルタ発見

                'フィルタオブジェクト取得
                Dim fltobj As Object = Nothing
                Mon.BindToObject(Nothing, Nothing, New Guid(GUIDString.Interface.IID_IBaseFilter), fltobj)
                If fltobj Is Nothing Then Throw New DirectShowException("グラフにフィルタを追加できません。- " + afp.FilterName)
                Dim flt As IBaseFilter = CType(fltobj, IBaseFilter)

                'グラフに追加
                Dim rc As Integer
                rc = afp.Grp.AddFilter(flt, afp.FilterCaption)
                If rc <> 0 Then Throw New DirectShowException(rc, "グラフにフィルタを追加できません。- " + afp.FilterName)

                '成功
                afp.Filter = flt

                '列挙終了
                Return True
            End If
        End If

        '列挙継続
        Return False
    End Function
    Private Class ADDFILTERPARAM
        Public Grp As IGraphBuilder
        Public FilterName As String
        Public SkipCount As Integer
        Public FilterCaption As String
        Public Filter As IBaseFilter
    End Class


#End Region

#Region "情報取得"

    'フィルタの列挙
    '引数
    '　Category                 カテゴリ
    '戻り値
    '　FILTERINFORMATIONのコレクション
    Public Function EnumFilters(ByVal Category As String) As Collection
        Return EnumFilters(New Guid(Category))
    End Function
    Public Function EnumFilters(ByVal Category As Guid) As Collection

        '列挙
        Dim ret As New Collection
        EnumFiltersAlgorithm(Category, New DelegateEnumFilters(AddressOf EnumFiltersFunc), ret)

        Return ret
    End Function
    Private Function EnumFiltersFunc(ByRef Mon As ComTypes.IMoniker, ByVal PropertyBag As IPropertyBag, ByVal Param As Object) As Boolean

        Dim fi As New FILTERINFORMATION

        '名前取得
        Dim fnameobj As Object = Nothing
        PropertyBag.Read("FriendlyName", fnameobj, 0)
        fi.Name = CStr(fnameobj)
        fnameobj = Nothing

        'CLSID取得
        Dim cidobj As Object = Nothing
        PropertyBag.Read("CLSID", cidobj, 0)
        fi.CLSID = CStr(cidobj)
        cidobj = Nothing

        'コレクションに追加
        CType(Param, Collection).Add(fi)

        Return False
    End Function
    Public Structure FILTERINFORMATION
        Public Name As String
        Public CLSID As String

        '文字列化
        Public Overrides Function ToString() As String
            Return Name
        End Function
    End Structure 'フィルタ情報

    'ピンの列挙
    '引数
    '　Filter                   フィルタ
    '戻り値
    '　PININFORMATIONのコレクション
    Public Function EnumPins(ByVal Filter As IBaseFilter) As Collection

        '列挙
        Dim ret As New Collection
        EnumPinsAlgorithm(Filter, New DelegateEnumPins(AddressOf EnumPinsFunc), ret)

        Return ret
    End Function
    Private Function EnumPinsFunc(ByRef Pin As IPin, ByVal Param As Object) As Boolean

        'ピン情報取得
        Dim pf As New PIN_INFO
        Pin.QueryPinInfo(pf)
        Dim pi As New PININFORMATION
        pi.Name = pf.Name
        pi.Direction = pf.PinDir
        If Not pf.Filter Is Nothing Then
            Marshal.ReleaseComObject(pf.Filter)
        End If

        'コレクションに追加
        CType(Param, Collection).Add(pi)

        '列挙継続
        Return False
    End Function
    Public Class PININFORMATION
        Public Name As String
        Public Direction As PinDirection

        '文字列化
        Public Overrides Function ToString() As String
            Return Name
        End Function
    End Class 'ピン情報

    'フィルタのピン検索
    '引数
    '　Filter                   フィルタ
    '　PinName                  ピン名称
    '戻り値
    '　Nothing                  指定されたピンはない(失敗)
    '　Nothing以外              IPinインターフェース(成功)
    Public Function FindPin(ByVal Filter As IBaseFilter, ByVal PinName As String) As IPin

        '検索
        Dim fpp As New FINDPINPARAM
        fpp.Name = PinName
        fpp.Pin = Nothing
        EnumPinsAlgorithm(Filter, New DelegateEnumPins(AddressOf FindPinFunc), fpp)

        Return fpp.Pin

    End Function
    Private Function FindPinFunc(ByRef Pin As IPin, ByVal Param As Object) As Boolean

        'パラメタ取得
        Dim fpp As FINDPINPARAM = CType(Param, FINDPINPARAM)

        'ピン情報取得
        Dim pf As New PIN_INFO
        Pin.QueryPinInfo(pf)
        If Not pf.Filter Is Nothing Then
            Marshal.ReleaseComObject(pf.Filter)
        End If

        '判定
        If pf.Name = fpp.Name Then
            '発見
            fpp.Pin = Pin

            'PinオブジェクトがReleaseされないようにする
            Pin = Nothing

            '列挙終了
            Return True
        End If

        '列挙継続
        Return False

    End Function
    Private Class FINDPINPARAM
        Public Name As String
        Public Direction As PinDirection
        Public Pin As IPin
    End Class

    'ピンの名称取得
    '引数
    '　Pin                      ピン
    '戻り値
    '　ピン名称
    Public Function GetPinName(ByVal Pin As IPin) As String

        Dim rc As Integer

        'ピン情報取得
        Dim PINFO As New PIN_INFO
        rc = Pin.QueryPinInfo(PINFO)
        If rc <> 0 Then Throw New DirectShowException(rc, "ピン名称を取得できません。")

        '後片付け
        If Not PINFO.Filter Is Nothing Then
            Marshal.ReleaseComObject(PINFO.Filter)
        End If

        Return PINFO.Name
    End Function

    '動画の画像サイズ取得
    '引数
    '　Grp                      グラフ
    '戻り値
    '  画像サイズ
    Public Function GetVideoSize(ByVal Grp As IGraphBuilder) As Size
        Dim ret As Size
        Dim rc As Integer

        '画像サイズを取得
        Dim bv As IBasicVideo2
        bv = TryCast(Grp, IBasicVideo2)
        If bv Is Nothing Then Throw New DirectShowException("ビデオストリームがありません。")
        rc = bv.GetVideoSize(ret.Width, ret.Height)
        If rc <> 0 Then Throw New DirectShowException(rc, "ビデオサイズが取得できません。")

        '成功
        Return ret
    End Function

#End Region

#Region "フォーマット形式関係"

    'フォーマット形式の列挙
    '引数
    '　Pin                      ピン
    '戻り値
    '　FORMATINFORMATIONコレクション
    '注意
    '・映像形式の列挙を想定している。
    Public Function EnumFormat(ByVal Pin As IPin) As Collection
        '列挙
        Dim ret As New Collection
        EnumFormatAlgorithm(Pin, New DelegateEnumFormat(AddressOf EnumFormatFunc), ret)

        Return ret
    End Function
    Private Function EnumFormatFunc(ByRef MediaType As AMMediaType, ByVal Param As Object) As Boolean

        '基本情報の取得
        Dim fmt As New FORMATINFORMATION
        fmt.MajorType = MediaType.majorType
        fmt.SubType = MediaType.subType
        fmt.FormatType = MediaType.formatType

        '映像形式の場合、サイズを取得する
        If CompGUIDString(MediaType.formatType.ToString, GUIDString.FormatType.FORMAT_VideoInfo) Then
            '映像形式である
            Dim vinfo As New DSVIDEOINFOHEADER
            vinfo = PtrToStructure(Of DSVIDEOINFOHEADER)(MediaType.formatPtr)
            fmt.Size.Width = vinfo.BmiHeader.Width
            fmt.Size.Height = vinfo.BmiHeader.Height
        End If

        'コレクションに追加
        CType(Param, Collection).Add(fmt)

        Return False
    End Function
    Public Class FORMATINFORMATION
        Public MajorType As Guid
        Public SubType As Guid
        Public FormatType As Guid
        Public Size As Size
    End Class

    'フォーマット形式の個数取得
    '引数
    '　Pin                      ピン
    '戻り値
    '　0以上                    フォーマット形式数
    '　0未満                    失敗
    Public Function GetFormatCount(ByVal Pin As IPin) As Integer

        'IAMStreamConfigインターフェースの取得
        If Pin Is Nothing Then Return -1
        Dim asc As IAMStreamConfig = TryCast(Pin, IAMStreamConfig)
        If asc Is Nothing Then Throw New DirectShowException(0, "このデバイスはフォーマット形式を列挙できません。")

        'フォーマット個数取得
        Dim fcnt As Integer = 0
        Dim ssz As Integer = 0
        Dim rc As Integer
        rc = asc.GetNumberOfCapabilities(fcnt, ssz)
        If rc <> 0 Then Throw New DirectShowException(rc, "フォーマットの列挙に失敗しました。")

        Return fcnt
    End Function

    'フォーマット形式取得
    '引数
    '　Pin                      ピン
    '　Index                    インデックス
    '戻り値
    '　Nothing以外              メディアタイプ
    '　Nothing                  失敗
    '注意
    '・取得に成功した場合、取得したデータをDeleteMediaTypeで解放すること。
    Public Function GetFormat(ByVal Pin As IPin, ByVal Index As Integer) As AMMediaType

        'IAMStreamConfigインターフェースの取得
        If Pin Is Nothing Then Return Nothing
        Dim asc As IAMStreamConfig = TryCast(Pin, IAMStreamConfig)
        If asc Is Nothing Then Throw New DirectShowException(0, "このデバイスはフォーマット形式を列挙できません。")

        'フォーマット個数取得
        Dim fcnt As Integer = 0
        Dim ssz As Integer = 0
        Dim rc As Integer
        rc = asc.GetNumberOfCapabilities(fcnt, ssz)
        If rc <> 0 Then Throw New DirectShowException(rc, "フォーマットの列挙に失敗しました。")

        'データ用領域確保
        Dim dataptr As IntPtr = Marshal.AllocHGlobal(ssz)

        'メディアタイプ取得
        Dim mt As AMMediaType = Nothing
        asc.GetStreamCaps(Index, mt, dataptr)

        'データ用領域解放
        Marshal.FreeHGlobal(dataptr)
        dataptr = IntPtr.Zero

        Return mt
    End Function

    '現在のフォーマット形式番号取得
    '引数
    '　Pin                      ピン
    '戻り値
    '　Nothing以外              メディアタイプ
    '　Nothing                  失敗
    '注意
    '・取得に成功した場合、取得したデータをDeleteMediaTypeで解放すること。
    Public Function GetFormat(ByVal Pin As IPin) As AMMediaType

        'IAMStreamConfigインターフェースの取得
        If Pin Is Nothing Then Return Nothing
        Dim asc As IAMStreamConfig = TryCast(Pin, IAMStreamConfig)
        If asc Is Nothing Then Throw New DirectShowException(0, "このデバイスはフォーマット形式を列挙できません。")

        'メディアタイプ取得
        Dim mt As AMMediaType = Nothing
        Dim rc As Integer
        rc = asc.GetFormat(mt)
        If rc <> 0 Then Throw New DirectShowException(rc, "現在のフォーマット形式が取得できません。")

        Return mt
    End Function

    'フォーマット形式の選択
    '引数
    '　Pin                      ピン
    '　Format                   新しいフォーマット
    Public Sub SetFormat(ByVal Pin As IPin, ByVal Format As AMMediaType)

        'IAMStreamConfigインターフェースの取得
        If Pin Is Nothing Then Exit Sub
        Dim asc As IAMStreamConfig = TryCast(Pin, IAMStreamConfig)
        If asc Is Nothing Then Throw New DirectShowException(0, "このデバイスはフォーマット形式を設定できません。")

        'メディアタイプ設定
        Dim rc As Integer
        rc = asc.SetFormat(Format)
        If rc <> 0 Then Throw New DirectShowException(rc, "フォーマット形式を設定できません。")

    End Sub


#End Region

    '//////////////////////////////////////////////////////////
    '//////////////////////////////////////////////////////////
    'その他
#Region "列挙アルゴリズム"

    '//////////////////////////////////////////////////////////
    'フィルタ列挙アルゴリズム
    '引数
    '　Category                 カテゴリ
    '　DelegateFunc             DelegateEnumFiltersデリゲート
    '　Param                    デリゲート関数に渡されるパラメタ
    '注意
    '・指定カテゴリ内のフィルタを列挙し、デリゲートを呼び出す。
    Public Sub EnumFiltersAlgorithm(ByVal Category As String, ByVal DelegateFunc As DelegateEnumFilters, ByVal Param As Object)
        EnumFiltersAlgorithm(New Guid(Category), DelegateFunc, Param)
    End Sub
    Public Sub EnumFiltersAlgorithm(ByVal Category As Guid, ByVal DelegateFunc As DelegateEnumFilters, ByVal Param As Object)

        'システムデバイス列挙子のタイプ準備
        Dim devenumtype As Type
        devenumtype = Type.GetTypeFromCLSID(New Guid(GUIDString.CLSID_SystemDeviceEnum))

        'システムデバイス列挙子のインスタンス作成
        Dim devenumobj As Object
        devenumobj = Activator.CreateInstance(devenumtype)

        'ICreateDevEnumインターフェース取得
        Dim devenum As ICreateDevEnum
        devenum = CType(devenumobj, ICreateDevEnum)
        devenumobj = Nothing

        'EnumMonikerの作成
        Dim emon As ComTypes.IEnumMoniker = Nothing
        devenum.CreateClassEnumerator(Category, emon, 0)

        '列挙
        Dim mon(0) As ComTypes.IMoniker
        Dim fc As IntPtr
        Dim rc As Boolean = False
        Do While (emon.Next(1, mon, fc) = 0) And (rc = False)

            'プロパティバッグへのバインド
            Dim propbagobj As Object = Nothing
            mon(0).BindToStorage(Nothing, Nothing, New Guid(GUIDString.Interface.IID_IPropertyBag), propbagobj)
            Dim propbag As IPropertyBag
            propbag = CType(propbagobj, IPropertyBag)
            propbagobj = Nothing

            'デリゲート呼び出し
            rc = DelegateFunc(mon(0), propbag, Param)

            'プロパティバッグの解放
            Marshal.ReleaseComObject(propbag)
            propbag = Nothing

            '列挙したモニカの解放
            If Not mon(0) Is Nothing Then
                Marshal.ReleaseComObject(mon(0))
                mon(0) = Nothing
            End If
        Loop

        '列挙終了
        Marshal.ReleaseComObject(emon)
        emon = Nothing
        Marshal.ReleaseComObject(devenum)
        devenum = Nothing

    End Sub

    'フィルタ列挙アルゴリズム用デリゲート
    '引数
    '　Moniker                  列挙されたフィルタのモニカ
    '　PropertyBag              列挙されたフィルタのプロパティバッグ
    '　Param                    汎用パラメタ
    '戻り値
    '　True                     列挙を中止する
    '　False                    列挙を継続する
    Public Delegate Function DelegateEnumFilters(ByRef Mon As ComTypes.IMoniker, ByVal PropertyBag As IPropertyBag, ByVal Param As Object) As Boolean


    '//////////////////////////////////////////////////////////
    'ピン列挙アルゴリズム
    '引数
    '　Filter                    フィルタ
    '　DelegateFunc              DelegateEnumPinsデリゲート
    '　Param                     汎用パラメタ
    Public Sub EnumPinsAlgorithm(ByVal Filter As IBaseFilter, ByVal DelegateFunc As DelegateEnumPins, ByVal Param As Object)

        Dim rc As Integer

        'ピン列挙子取得
        Dim epin As IEnumPins = Nothing
        rc = Filter.EnumPins(epin)
        If rc <> 0 Then Throw New DirectShowException(rc)

        '列挙
        Dim fc As Integer
        Dim pin As IPin = Nothing
        Do While epin.Next(1, pin, fc) = 0

            'デリゲート呼び出し
            DelegateFunc(pin, Param)

            '列挙したピンの解放
            If Not pin Is Nothing Then
                Marshal.ReleaseComObject(pin)
                pin = Nothing
            End If
        Loop

        '列挙終了
        Marshal.ReleaseComObject(epin)

    End Sub

    'ピン列挙アルゴリズム用デリゲート
    '引数
    '　Pin                      列挙されたピン
    '　Param                    汎用パラメタ
    '戻り値
    '　True                     列挙を中止する
    '　False                    列挙を継続する
    Public Delegate Function DelegateEnumPins(ByRef Pin As IPin, ByVal Param As Object) As Boolean

    '//////////////////////////////////////////////////////////
    'フォーマットタイプ列挙アルゴリズム
    '引数
    '　Pin                      ピン
    '　DelegateFunc              DelegateEnumFormatデリゲート
    '　Param                     汎用パラメタ
    Public Sub EnumFormatAlgorithm(ByVal Pin As IPin, ByVal DelegateFunc As DelegateEnumFormat, ByVal Param As Object)

        'IAMStreamConfigインターフェースの取得
        If Pin Is Nothing Then Exit Sub
        Dim asc As IAMStreamConfig = TryCast(Pin, IAMStreamConfig)
        If asc Is Nothing Then Throw New DirectShowException("このデバイスはフォーマット形式を列挙できません。")

        'フォーマット個数取得
        Dim fcnt As Integer = 0
        Dim ssz As Integer = 0
        Dim rc As Integer
        rc = asc.GetNumberOfCapabilities(fcnt, ssz)
        If rc <> 0 Then Throw New DirectShowException(rc, "フォーマットの列挙に失敗しました。")

        'データ用領域確保
        Dim dataptr As IntPtr = Marshal.AllocHGlobal(ssz)

        '列挙
        Dim mt As AMMediaType = Nothing
        Dim ss As New System.Text.StringBuilder
        Dim flg As Boolean
        For x As Integer = 0 To fcnt - 1

            'x番目のフォーマット情報取得
            asc.GetStreamCaps(x, mt, dataptr)

            'デリゲート呼び出し
            flg = DelegateFunc(mt, Param)

            '解放
            If Not mt Is Nothing Then
                DeleteMediaType(mt)
            End If

            If flg Then Exit For
        Next

        'データ用領域解放
        Marshal.FreeHGlobal(dataptr)
        dataptr = IntPtr.Zero

    End Sub


    'ピン列挙アルゴリズム用デリゲート
    '引数
    '　MediaType                メディアタイプ
    '　Param                    汎用パラメタ
    '戻り値
    '　True                     列挙を中止する
    '　False                    列挙を継続する
    Public Delegate Function DelegateEnumFormat(ByRef MediaType As AMMediaType, ByVal Param As Object) As Boolean



#End Region

#Region "プロパティページ表示"
    '//////////////////////////////////////////////////////////
    'フィルタ又はピンのプロパティページ表示
    '引数
    '　FilterObject         フィルタ、又は、ピン（ISpecifyPropertyPagesを持つもの）
    '　WindowHandle         親ウィンドウのハンドル
    '　Caption              プロパティウィンドウのタイトル
    '戻り値
    '　False                プロパティページは開かれた
    '　True                 プロパティページは開かれなかった
    Public Function OpenDiaglog(ByVal FilterObject As Object, ByVal WindowHandle As IntPtr, Optional ByVal Caption As String = "プロパティ") As Boolean

        'ISpecifyPropertyPagesインターフェース取得
        Dim sp As ISpecifyPropertyPages
        sp = TryCast(FilterObject, ISpecifyPropertyPages)
        If sp Is Nothing Then
            'プロパティページはない
            Return True
        End If

        'プロパティページ情報取得
        Dim ca As CAUUID
        sp.GetPages(ca)

        'プロパティページ表示
        Win32API.OleCreatePropertyFrame( _
            WindowHandle, 0, 0, _
            Caption, 1, _
            FilterObject, ca.cElems, ca.pElems, 0, 0, Nothing)

        '後始末
        If ca.pElems <> IntPtr.Zero Then
            Marshal.FreeCoTaskMem(ca.pElems)
        End If

        Return False
    End Function

#End Region

#Region "メディアタイプ関係"

    'メディアタイプの解放
    Public Sub DeleteMediaType(ByVal Ptr As IntPtr)

        Dim mt As AMMediaType = Nothing
        mt = PtrToStructure(Of AMMediaType)(Ptr)

        DeleteMediaType(mt)

        Marshal.FreeCoTaskMem(Ptr)

    End Sub
    Public Sub DeleteMediaType(ByRef Data As AMMediaType)

        If Data.formatSize <> 0 Then
            Marshal.FreeCoTaskMem(Data.formatPtr)
        End If
        If Data.unkPtr <> IntPtr.Zero Then
            Marshal.FreeCoTaskMem(Data.unkPtr)
        End If

        Data = Nothing

    End Sub

    'GUID文字列同士の比較
    Public Function CompGUIDString(ByVal GUID1 As String, ByVal GUID2 As String) As Boolean
        Return NormalizeGUIDString(GUID1) = NormalizeGUIDString(GUID2)
    End Function

    'GUID文字列を {xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx} にする
    Public Function NormalizeGUIDString(ByVal GuidStr As String) As String
        If Not GuidStr.StartsWith("{") Then GuidStr = "{" + GuidStr
        If Not GuidStr.EndsWith("}") Then GuidStr = GuidStr + "}"
        Return UCase(GuidStr)
    End Function

    'メディアタイプGUID文字列からわかり易い名称を取得
    Public Function GetMediaTypeName(ByVal GUIDStr As String) As String

        Dim ss As String = NormalizeGUIDString(GUIDStr)
        Dim name As String = ""
        Select Case ss
            'メジャータイプ
            Case GUIDString.MediaType.MEDIATYPE_Video : name = "[Video]"
            Case GUIDString.MediaType.MEDIATYPE_Audio : name = "[Audio]"
            Case GUIDString.MediaType.MEDIATYPE_Text : name = "[Text]"
            Case GUIDString.MediaType.MEDIATYPE_Midi : name = "[Midi]"
            Case GUIDString.MediaType.MEDIATYPE_Stream : name = "[Stream]"
            Case GUIDString.MediaType.MEDIATYPE_Interleaved : name = "[Interleaved]"
            Case GUIDString.MediaType.MEDIATYPE_File : name = "[File]"
            Case GUIDString.MediaType.MEDIATYPE_ScriptCommand : name = "[ScriptCommand]"
            Case GUIDString.MediaType.MEDIATYPE_AUXLine21Data : name = "[AUXLine21Data]"
            Case GUIDString.MediaType.MEDIATYPE_VBI : name = "[VBI]"
            Case GUIDString.MediaType.MEDIATYPE_Timecode : name = "[Timecode]"
            Case GUIDString.MediaType.MEDIATYPE_LMRT : name = "[LMRT]"
            Case GUIDString.MediaType.MEDIATYPE_URL_STREAM : name = "[URL_STREAM]"

                'サブタイプ
            Case GUIDString.MediaType.MEDIASUBTYPE_None : name = "[None]"
            Case GUIDString.MediaType.MEDIASUBTYPE_CLPL : name = "[CLPL]"
            Case GUIDString.MediaType.MEDIASUBTYPE_YUYV : name = "[YUYV]"
            Case GUIDString.MediaType.MEDIASUBTYPE_IYUV : name = "[IYUV]"
            Case GUIDString.MediaType.MEDIASUBTYPE_YVU9 : name = "[YVU9]"
            Case GUIDString.MediaType.MEDIASUBTYPE_Y411 : name = "[Y411]"
            Case GUIDString.MediaType.MEDIASUBTYPE_Y41P : name = "[Y41P]"
            Case GUIDString.MediaType.MEDIASUBTYPE_YUY2 : name = "[YUY2]"
            Case GUIDString.MediaType.MEDIASUBTYPE_YVYU : name = "[YVYU]"
            Case GUIDString.MediaType.MEDIASUBTYPE_UYVY : name = "[UYVY]"
            Case GUIDString.MediaType.MEDIASUBTYPE_Y211 : name = "[Y211]"
            Case GUIDString.MediaType.MEDIASUBTYPE_CLJR : name = "[CLJR]"
            Case GUIDString.MediaType.MEDIASUBTYPE_IF09 : name = "[IF09]"
            Case GUIDString.MediaType.MEDIASUBTYPE_CPLA : name = "[CPLA]"
            Case GUIDString.MediaType.MEDIASUBTYPE_MJPG : name = "[MJPG]"
            Case GUIDString.MediaType.MEDIASUBTYPE_TVMJ : name = "[TVMJ]"
            Case GUIDString.MediaType.MEDIASUBTYPE_WAKE : name = "[WAKE]"
            Case GUIDString.MediaType.MEDIASUBTYPE_CFCC : name = "[CFCC]"
            Case GUIDString.MediaType.MEDIASUBTYPE_IJPG : name = "[IJPG]"
            Case GUIDString.MediaType.MEDIASUBTYPE_Plum : name = "[Plum]"
            Case GUIDString.MediaType.MEDIASUBTYPE_DVSD : name = "[DVSD]"
            Case GUIDString.MediaType.MEDIASUBTYPE_MDVF : name = "[MDVF]"
            Case GUIDString.MediaType.MEDIASUBTYPE_RGB1 : name = "[RGB1]"
            Case GUIDString.MediaType.MEDIASUBTYPE_RGB4 : name = "[RGB4]"
            Case GUIDString.MediaType.MEDIASUBTYPE_RGB8 : name = "[RGB8]"
            Case GUIDString.MediaType.MEDIASUBTYPE_RGB565 : name = "[RGB565]"
            Case GUIDString.MediaType.MEDIASUBTYPE_RGB555 : name = "[RGB555]"
            Case GUIDString.MediaType.MEDIASUBTYPE_RGB24 : name = "[RGB24]"
            Case GUIDString.MediaType.MEDIASUBTYPE_RGB32 : name = "[RGB32]"
            Case GUIDString.MediaType.MEDIASUBTYPE_ARGB1555 : name = "[ARGB1555]"
            Case GUIDString.MediaType.MEDIASUBTYPE_ARGB4444 : name = "[ARGB4444]"
            Case GUIDString.MediaType.MEDIASUBTYPE_ARGB32 : name = "[ARGB32]"
            Case GUIDString.MediaType.MEDIASUBTYPE_A2R10G10B10 : name = "[A2R10G10B10]"
            Case GUIDString.MediaType.MEDIASUBTYPE_A2B10G10R10 : name = "[A2B10G10R10]"
            Case GUIDString.MediaType.MEDIASUBTYPE_AYUV : name = "[AYUV]"
            Case GUIDString.MediaType.MEDIASUBTYPE_AI44 : name = "[AI44]"
            Case GUIDString.MediaType.MEDIASUBTYPE_IA44 : name = "[IA44]"
            Case GUIDString.MediaType.MEDIASUBTYPE_YV12 : name = "[YV12]"
            Case GUIDString.MediaType.MEDIASUBTYPE_NV12 : name = "[NV12]"
            Case GUIDString.MediaType.MEDIASUBTYPE_IMC1 : name = "[IMC1]"
            Case GUIDString.MediaType.MEDIASUBTYPE_IMC2 : name = "[IMC2]"
            Case GUIDString.MediaType.MEDIASUBTYPE_IMC3 : name = "[IMC3]"
            Case GUIDString.MediaType.MEDIASUBTYPE_IMC4 : name = "[IMC4]"
            Case GUIDString.MediaType.MEDIASUBTYPE_S340 : name = "[S340]"
            Case GUIDString.MediaType.MEDIASUBTYPE_S342 : name = "[S342]"
            Case GUIDString.MediaType.MEDIASUBTYPE_I420 : name = "[I420]"
            Case GUIDString.MediaType.MEDIASUBTYPE_Overlay : name = "[Overlay]"
            Case GUIDString.MediaType.MEDIASUBTYPE_MPEGPacket : name = "[MPEGPacket]"
            Case GUIDString.MediaType.MEDIASUBTYPE_MPEG1Payload : name = "[MPEG1Payload]"
            Case GUIDString.MediaType.MEDIASUBTYPE_MPEG1AudioPayload : name = "[MPEG1AudioPayload]"
            Case GUIDString.MediaType.MEDIASUBTYPE_MPEG1SystemStream : name = "[MPEG1SystemStream]"
            Case GUIDString.MediaType.MEDIASUBTYPE_MPEG1VideoCD : name = "[MPEG1VideoCD]"
            Case GUIDString.MediaType.MEDIASUBTYPE_MPEG1Video : name = "[MPEG1Video]"
            Case GUIDString.MediaType.MEDIASUBTYPE_MPEG1Audio : name = "[MPEG1Audio]"
            Case GUIDString.MediaType.MEDIASUBTYPE_Avi : name = "[Avi]"
            Case GUIDString.MediaType.MEDIASUBTYPE_Asf : name = "[Asf]"
            Case GUIDString.MediaType.MEDIASUBTYPE_QTMovie : name = "[QTMovie]"
            Case GUIDString.MediaType.MEDIASUBTYPE_Rpza : name = "[Rpza]"
            Case GUIDString.MediaType.MEDIASUBTYPE_Smc : name = "[Smc]"
            Case GUIDString.MediaType.MEDIASUBTYPE_Rle : name = "[Rle]"
            Case GUIDString.MediaType.MEDIASUBTYPE_Jpeg : name = "[Jpeg]"
            Case GUIDString.MediaType.MEDIASUBTYPE_PCMAudio_Obsolete : name = "[PCMAudio_Obsolete]"
            Case GUIDString.MediaType.MEDIASUBTYPE_PCM : name = "[PCM]"
            Case GUIDString.MediaType.MEDIASUBTYPE_WAVE : name = "[WAVE]"
            Case GUIDString.MediaType.MEDIASUBTYPE_AU : name = "[AU]"
            Case GUIDString.MediaType.MEDIASUBTYPE_AIFF : name = "[AIFF]"
            Case GUIDString.MediaType.MEDIASUBTYPE_dvsd2 : name = "[dvsd2]"
            Case GUIDString.MediaType.MEDIASUBTYPE_dvhd : name = "[dvhd]"
            Case GUIDString.MediaType.MEDIASUBTYPE_dvsl : name = "[dvsl]"
            Case GUIDString.MediaType.MEDIASUBTYPE_dv25 : name = "[dv25]"
            Case GUIDString.MediaType.MEDIASUBTYPE_dv50 : name = "[dv50]"
            Case GUIDString.MediaType.MEDIASUBTYPE_dvh1 : name = "[dvh1]"
            Case GUIDString.MediaType.MEDIASUBTYPE_Line21_BytePair : name = "[Line21_BytePair]"
            Case GUIDString.MediaType.MEDIASUBTYPE_Line21_GOPPacket : name = "[Line21_GOPPacket]"
            Case GUIDString.MediaType.MEDIASUBTYPE_Line21_VBIRawData : name = "[Line21_VBIRawData]"
            Case GUIDString.MediaType.MEDIASUBTYPE_TELETEXT : name = "[TELETEXT]"
        End Select

        Return name
    End Function

#End Region

#Region "ビデオレンダラ関係"

    '//////////////////////////////////////////////////////////
    '指定されたウィンドウ内で動画を再生させる
    Public Enum RendererScale    '拡大縮小方式
        None = 0                    '拡大縮小なし
        KeepAspect = 1              '縦横比を保って拡大縮小
        Full = 2                    '領域全体に拡大縮小
    End Enum
    Public Sub SetVideoRenderer(ByVal Grp As IGraphBuilder, ByVal Owner As Control, ByVal Zoom As RendererScale)
        Dim sz As Size = Owner.ClientSize
        SetVideoRenderer(Grp, Owner.Handle, sz, Zoom)
    End Sub
    Public Sub SetVideoRenderer(ByVal Grp As IGraphBuilder, ByVal Owner As IntPtr, ByVal OwnerSize As Size, ByVal Zoom As RendererScale)

        Dim rc As Integer

        '引数チェック
        If Grp Is Nothing Then Throw New DirectShowException("グラフが作成されていません。")
        If (OwnerSize.Width = 0) Or (OwnerSize.Height = 0) Then Throw New DirectShowException("再生領域のサイズが不正です。")

        'IVideoWindowインターフェース取得
        Dim vw As IVideoWindow
        vw = TryCast(Grp, IVideoWindow)
        If vw Is Nothing Then Throw New DirectShowException("ビデオレンダラがありません。")

        '画像サイズを取得
        Dim vsz As Size = GetVideoSize(Grp)
        If (vsz.Width = 0) Or (vsz.Height = 0) Then Throw New DirectShowException("ビデオサイズが不正です。")

        '再生位置とサイズ決定
        Dim pos As Point, sz As Size
        Select Case Zoom
            Case RendererScale.None '拡大縮小なし
                sz = vsz

            Case RendererScale.KeepAspect   '縦横比を保って拡大縮小
                sz.Width = OwnerSize.Width
                sz.Height = CInt(vsz.Height * sz.Width / vsz.Width)
                If sz.Height > OwnerSize.Height Then
                    sz.Height = OwnerSize.Height
                    sz.Width = CInt(vsz.Width * sz.Height / vsz.Height)
                End If

            Case RendererScale.Full '全体に拡大縮小なし
                sz = OwnerSize

            Case Else
                Exit Sub
        End Select
        pos.X = (OwnerSize.Width - sz.Width) \ 2
        pos.Y = (OwnerSize.Height - sz.Height) \ 2

        ' 2015.09.12 hayakawa 追加↓ここから
        PubConstClass.imageWinWidth = sz.Width
        PubConstClass.imageWinHeight = sz.Height
        ' 2015.09.12 hayakawa 追加↑ここまで

        'オーナー設定
        rc = vw.put_Owner(Owner)
        If rc <> 0 Then Throw New DirectShowException(rc)

        'ウィンドウスタイル変更
        rc = vw.put_WindowStyle(&H40000000)
        If rc <> 0 Then Throw New DirectShowException(rc)

        '位置変更
        rc = vw.SetWindowPosition(pos.X, pos.Y, sz.Width, sz.Height)
        If rc <> 0 Then Throw New DirectShowException(rc)

        '成功
    End Sub

#End Region

End Module
