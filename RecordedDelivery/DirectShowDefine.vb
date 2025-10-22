Option Explicit On
Option Strict On

'//////////////////////////////////////////////////////////
'DirectShow関係の定義モジュール
'//////////////////////////////////////////////////////////

Imports System
Imports System.Runtime.InteropServices


'//////////////////////////////////////////////////////////
'DirectShowの定義
'//////////////////////////////////////////////////////////
Public Module DirectShowDefine

    '//////////////////////////////////////////////////////////
    '定数定義
    '//////////////////////////////////////////////////////////
#Region "定数定義"

#Region "列挙型"

    'PIN_DIRECTION
    <ComVisible(False)> _
    Public Enum PinDirection
        Input = 0                       'PINDIR_INPUT
        Output = 1                      'PINDIR_OUTPUT
        Unknown = -1                    '不明
    End Enum

    'AM_SEEKING_SEEKING_CAPABILITIES
    <Flags(), ComVisible(False)> _
    Public Enum SeekingCapabilities
        CanSeekAbsolute = &H1
        CanSeekForwards = &H2
        CanSeekBackwards = &H4
        CanGetCurrentPos = &H8
        CanGetStopPos = &H10
        CanGetDuration = &H20
        CanPlayBackwards = &H40
        CanDoSegments = &H80
        [Source] = &H100
    End Enum

    'AM_SEEKING_SEEKING_FLAGS
    <Flags(), ComVisible(False)> _
    Public Enum SeekingFlags
        NoPositioning = &H0
        AbsolutePositioning = &H1
        RelativePositioning = &H2
        IncrementalPositioning = &H3
        PositioningBitsMask = &H3
        SeekToKeyFrame = &H4
        ReturnTime = &H8
        Segment = &H10
        NoFlush = &H20
    End Enum

#End Region

#Region "コード"

    'イベントコード
    <ComVisible(False)> _
    Public Enum DirectShowEventCode
        EC_COMPLETE = &H1
        EC_USERABORT = &H2
        EC_ERRORABORT = &H3
        EC_TIME = &H4
        EC_REPAINT = &H5
        EC_STREAM_ERROR_STOPPED = &H6
        EC_STREAM_ERROR_STILLPLAYING = &H7
        EC_ERROR_STILLPLAYING = &H8
        EC_PALETTE_CHANGED = &H9
        EC_VIDEO_SIZE_CHANGED = &HA
        EC_QUALITY_CHANGE = &HB
        EC_SHUTTING_DOWN = &HC
        EC_CLOCK_CHANGED = &HD
        EC_PAUSED = &HE
        EC_OPENING_FILE = &H10
        EC_BUFFERING_DATA = &H11
        EC_FULLSCREEN_LOST = &H12
        EC_ACTIVATE = &H13
        EC_NEED_RESTART = &H14
        EC_WINDOW_DESTROYED = &H15
        EC_DISPLAY_CHANGED = &H16
        EC_STARVATION = &H17
        EC_OLE_EVENT = &H18
        EC_NOTIFY_WINDOW = &H19

        'DVD関係
        EC_DVD_DOMAIN_CHANGE = &H101
        EC_DVD_TITLE_CHANGE = &H102
        EC_DVD_CHAPTER_START = &H103
        EC_DVD_AUDIO_STREAM_CHANGE = &H104
        EC_DVD_SUBPICTURE_STREAM_CHANGE = &H105
        EC_DVD_ANGLE_CHANGE = &H106
        EC_DVD_BUTTON_CHANGE = &H107
        EC_DVD_VALID_UOPS_CHANGE = &H108
        EC_DVD_STILL_ON = &H109
        EC_DVD_STILL_OFF = &H10A
        EC_DVD_CURRENT_TIME = &H10B
        EC_DVD_ERROR = &H10C
        EC_DVD_WARNING = &H10D
        EC_DVD_CHAPTER_AUTOSTOP = &H10E
        EC_DVD_NO_FP_PGC = &H10F
        EC_DVD_PLAYBACK_RATE_CHANGE = &H110
        EC_DVD_PARENTAL_LEVEL_CHANGE = &H111
        EC_DVD_PLAYBACK_STOPPED = &H112
        EC_DVD_ANGLES_AVAILABLE = &H113
        EC_DVD_PLAYPERIOD_AUTOSTOP = &H114
        EC_DVD_BUTTON_AUTO_ACTIVATED = &H115
        EC_DVD_CMD_START = &H116
        EC_DVD_CMD_END = &H117
        EC_DVD_DISC_EJECTED = &H118
        EC_DVD_DISC_INSERTED = &H119
        EC_DVD_CURRENT_HMSF_TIME = &H11A
        EC_DVD_KARAOKE_MODE = &H11B
    End Enum

    'エラーコード
    <ComVisible(False)> _
    Public Enum DirectShowHRESULT
        VFW_E_INVALIDMEDIATYPE = &H80040200         '指定されたメディア タイプは無効である。
        VFW_E_INVALIDSUBTYPE = &H80040201           '指定されたメディア サブタイプは無効である。
        VFW_E_NEED_OWNER = &H80040202               'このオブジェクトは集成オブジェクトとしてのみ作成できる。
        VFW_E_ENUM_OUT_OF_SYNC = &H80040203         '列挙オブジェクトの状態が変化して、列挙子の状態との矛盾が発生した。
        VFW_E_ALREADY_CONNECTED = &H80040204        '処理に含まれるピンが既に少なくとも 1 つ接続されている。
        VFW_E_FILTER_ACTIVE = &H80040205            'フィルタがアクティブなので、この処理を実行できない。
        VFW_E_NO_TYPES = &H80040206                 '指定されたいずれかのピンがメディア タイプをサポートしていない。
        VFW_E_NO_ACCEPTABLE_TYPES = &H80040207      'これらのピンに共通のメディア タイプがない。
        VFW_E_INVALID_DIRECTION = &H80040208        '同じ方向のピンを 2 つ接続することはできない。
        VFW_E_NOT_CONNECTED = &H80040209            'ピンが接続されていないため、処理を実行できない。
        VFW_E_NO_ALLOCATOR = &H8004020A             'サンプル バッファ アロケータが利用不可能。
        VFW_E_RUNTIME_ERROR = &H8004020B            '実行時エラーが発生した。
        VFW_E_BUFFER_NOTSET = &H8004020C            'バッファ空間が設定されていない。
        VFW_E_BUFFER_OVERFLOW = &H8004020D          'バッファの大きさが足りない。
        VFW_E_BADALIGN = &H8004020E                 '無効なアラインメントが指定された。
        VFW_E_ALREADY_COMMITTED = &H8004020F        'アロケータはコミットされなかった。「IMemAllocator::Commit」を参照すること。
        VFW_E_BUFFERS_OUTSTANDING = &H80040210      '1 つまたは複数のバッファがアクティブである。
        VFW_E_NOT_COMMITTED = &H80040211            'アロケータがアクティブでないときはサンプルを割り当てることができない。
        VFW_E_SIZENOTSET = &H80040212               'サイズが設定されていないので、メモリを割り当てることができない。
        VFW_E_NO_CLOCK = &H80040213                 'クロックが定義されていないので、同期を行えない。
        VFW_E_NO_SINK = &H80040214                  '品質シンクが定義されていないので、品質メッセージを送信できない。
        VFW_E_NO_INTERFACE = &H80040215             '必要なインターフェイスが実装されていない。
        VFW_E_NOT_FOUND = &H80040216                'オブジェクトまたは名前が見つからなかった。
        VFW_E_CANNOT_CONNECT = &H80040217           '接続を確立する中間フィルタの組み合わせが見つからなかった。
        VFW_E_CANNOT_RENDER = &H80040218            'ストリームをレンダリングするフィルタの組み合わせが見つからなかった。
        VFW_E_CHANGING_FORMAT = &H80040219          'フォーマットを動的に変更できない。
        VFW_E_NO_COLOR_KEY_SET = &H8004021A         'カラー キーが設定されていない。
        VFW_E_NOT_OVERLAY_CONNECTION = &H8004021B   '現在のピン接続は IOverlay 転送を使っていない。
        VFW_E_NOT_SAMPLE_CONNECTION = &H8004021C    '現在のピン接続は IMemInputPin 転送を使っていない。
        VFW_E_PALETTE_SET = &H8004021D              'カラー キーを設定すると、既に設定されているパレットと矛盾する可能性がある。
        VFW_E_COLOR_KEY_SET = &H8004021E            'パレットを設定すると、既に設定されているカラー キーと矛盾する可能性がある。
        VFW_E_NO_COLOR_KEY_FOUND = &H8004021F       '一致するカラー キーがない。
        VFW_E_NO_PALETTE_AVAILABLE = &H80040220     'パレットが利用不可能。
        VFW_E_NO_DISPLAY_PALETTE = &H80040221       'ディスプレイはパレットを使わない。
        VFW_E_TOO_MANY_COLORS = &H80040222          '現在のディスプレイ設定に対して色が多すぎる。
        VFW_E_STATE_CHANGED = &H80040223            'サンプルの処理を待っている間に状態が変化した。
        VFW_E_NOT_STOPPED = &H80040224              'フィルタが停止していないので、処理を実行できない。
        VFW_E_NOT_PAUSED = &H80040225               'フィルタが停止していないため、処理を実行できなかった。
        VFW_E_NOT_RUNNING = &H80040226              'フィルタが実行されていないので、処理を実行できない。
        VFW_E_WRONG_STATE = &H80040227              'フィルタが不正な状態にあるため、処理を実行できなかった。
        VFW_E_START_TIME_AFTER_END = &H80040228     'サンプルの開始タイムがサンプルの終了タイムの後になっている。
        VFW_E_INVALID_RECT = &H80040229             '提供された矩形が無効である。
        VFW_E_TYPE_NOT_ACCEPTED = &H8004022A        'このピンは、提供されたメディア タイプを使えない。
        VFW_E_SAMPLE_REJECTED = &H8004022B          'このサンプルはレンダリングできない。
        VFW_E_SAMPLE_REJECTED_EOS = &H8004022C      'ストリームの終わりに到達しているので、このサンプルをレンダリングできない。
        VFW_E_DUPLICATE_NAME = &H8004022D           '同じ名前のフィルタを追加しようとしたが失敗した。
        VFW_S_DUPLICATE_NAME = &H4022D              '同じ名前のフィルタを追加しようとしたところ、名前を変更して処理が成功した。
        VFW_E_TIMEOUT = &H8004022E                  'タイムアウト期間が過ぎた。
        VFW_E_INVALID_FILE_FORMAT = &H8004022F      'ファイル フォーマットが無効である。
        VFW_E_ENUM_OUT_OF_RANGE = &H80040230        'リストが使い果たされた。
        VFW_E_CIRCULAR_GRAPH = &H80040231           'フィルタ グラフが循環している。
        VFW_E_NOT_ALLOWED_TO_SAVE = &H80040232      'この状態での更新は許されない。
        VFW_E_TIME_ALREADY_PASSED = &H80040233      '過去のタイムのコマンドをキューに入れようとした。
        VFW_E_ALREADY_CANCELLED = &H80040234        'キューに入れられたコマンドは既にキャンセルされていた。
        VFW_E_CORRUPT_GRAPH_FILE = &H80040235       'ファイルが壊れているのでレンダリングできない。
        VFW_E_ADVISE_ALREADY_SET = &H80040236       'IOverlay アドバイズ リンクが既に存在している。
        VFW_S_STATE_INTERMEDIATE = &H40237          '状態の移行が完了していない。
        VFW_E_NO_MODEX_AVAILABLE = &H80040238       'フルスクリーン モードは利用できない。
        VFW_E_NO_ADVISE_SET = &H80040239            'このアドバイズは正常に設定されていないのでキャンセルできない。
        VFW_E_NO_FULLSCREEN = &H8004023A            'フルスクリーン モードは利用できない。
        VFW_E_IN_FULLSCREEN_MODE = &H8004023B       'フルスクリーン モードでは IVideoWindow メソッドを呼び出せない。
        VFW_E_UNKNOWN_FILE_TYPE = &H80040240        'このファイルのメディア タイプが認識されない。
        VFW_E_CANNOT_LOAD_SOURCE_FILTER = &H80040241    'このファイルのソース フィルタをロードできない。
        VFW_S_PARTIAL_RENDER = &H40242              'このムービーにサポートされないフォーマットのストリームが含まれている。
        VFW_E_FILE_TOO_SHORT = &H80040243           'ファイルが不完全である。
        VFW_E_INVALID_FILE_VERSION = &H80040244     'ファイルのバージョン番号が無効である。
        VFW_S_SOME_DATA_IGNORED = &H40245           'ファイルにいくつかの使用されていないプロパティ設定が含まれている。
        VFW_S_CONNECTIONS_DEFERRED = &H40246        '一部の接続が失敗して遅延した。
        VFW_E_INVALID_CLSID = &H80040247            'このファイルは壊れている。無効なクラス識別子が含まれている。
        VFW_E_INVALID_MEDIA_TYPE = &H80040248       'このファイルは壊れている。無効なメディア タイプが含まれている。
        VFW_E_SAMPLE_TIME_NOT_SET = &H80040249      'このサンプルにはタイム スタンプが設定されていない。
        VFW_S_RESOURCE_NOT_NEEDED = &H40250         '指定されたリソースはもはや必要ない。
        VFW_E_MEDIA_TIME_NOT_SET = &H80040251       'このサンプルにはメディア タイムが設定されていない。
        VFW_E_NO_TIME_FORMAT_SET = &H80040252       'メディア タイム フォーマットが選択されていない。
        VFW_E_MONO_AUDIO_HW = &H80040253            'オーディオ デバイスがモノラル専用なので、バランスを変更できない。
        VFW_S_MEDIA_TYPE_IGNORED = &H40254          '永続グラフのメディア タイプに接続できない。
        VFW_E_NO_DECOMPRESSOR = &H80040255          'ビデオ ストリームを再生できない。適切なデコンプレッサが見つからなかった。
        VFW_E_NO_AUDIO_HARDWARE = &H80040256        'オーディオ ストリームを再生できない。オーディオ ハードウェアが利用できない、またはハードウェアがサポートされていない。
        VFW_S_VIDEO_NOT_RENDERED = &H40257          'ビデオ ストリームを再生できない。適切なレンダラが見つからなかった。
        VFW_S_AUDIO_NOT_RENDERED = &H40258          'オーディオ ストリームを再生できない。適切なレンダラが見つからなかった。
        VFW_E_RPZA = &H80040259                     'ビデオ ストリームを再生できない。フォーマット 'RPZA' はサポートされていない。
        VFW_S_RPZA = &H4025A                        'ビデオ ストリームを再生できない。フォーマット 'RPZA' はサポートされていない。
        VFW_E_PROCESSOR_NOT_SUITABLE = &H8004025B   'DirectShow はこのプロセッサ上で MPEG ムービーを再生できない。
        VFW_E_UNSUPPORTED_AUDIO = &H8004025C        'オーディオ ストリームを再生できない。このオーディオ フォーマットはサポートされていない。
        VFW_E_UNSUPPORTED_VIDEO = &H8004025D        'ビデオ ストリームを再生できない。このビデオ フォーマットはサポートされていない。
        VFW_E_MPEG_NOT_CONSTRAINED = &H8004025E     'このビデオ ストリームは規格に準拠していないので DirectShow で再生できない。
        VFW_E_NOT_IN_GRAPH = &H8004025F             'フィルタ グラフに存在しないオブジェクトに要求された関数を実行できない。
        VFW_S_ESTIMATED = &H40260                   '返された値は予測値である。値の正確さを保証できない。
        VFW_E_NO_TIME_FORMAT = &H80040261           'オブジェクトのタイム フォーマットにアクセスできない。
        VFW_E_READ_ONLY = &H80040262                'ストリームが読み出し専用で、フィルタによってデータが変更されているので、接続を確立できない。
        VFW_S_RESERVED = &H40263                    'この成功コードは、DirectShow の内部処理用に予約されている。
        VFW_E_BUFFER_UNDERFLOW = &H80040264         'バッファが十分に満たされていない。
        VFW_E_UNSUPPORTED_STREAM = &H80040265       'ファイルを再生できない。フォーマットがサポートされていない。
        VFW_E_NO_TRANSPORT = &H80040266             '同じ転送をサポートしていないのでピンどうしを接続できない。
        VFW_S_STREAM_OFF = &H40267                  'ストリームがオフになった。
        VFW_S_CANT_CUE = &H40268                    'フィルタはアクティブだが、データを出力することができない。「IMediaFilter::GetState」を参照すること。
        VFW_E_BAD_VIDEOCD = &H80040269              'デバイスがビデオ CD を正常に読み出せない、またはビデオ CD のデータが壊れている。
        VFW_S_NO_STOP_TIME = &H80040270             'サンプルに終了タイムではなく開始タイムが設定されていた。この場合、返される終了タイムは開始タイムに 1 を加えた値に設定される。
        VFW_E_OUT_OF_VIDEO_MEMORY = &H80040271      'このディスプレイ解像度と色数に対してビデオ メモリが不十分である。解像度を低くするとよい。
        VFW_E_VP_NEGOTIATION_FAILED = &H80040272    'ビデオ ポート接続ネゴシエーション プロセスが失敗した。
        VFW_E_DDRAW_CAPS_NOT_SUITABLE = &H80040273  'Microsoft DirectDraw がインストールされていない、またはビデオ カードの能力が適切でない。ディスプレイが 16 色モードでないことを確認すること。
        VFW_E_NO_VP_HARDWARE = &H80040274           'ビデオ ポート ハードウェアが利用できない、またはハードウェアが応答しない。
        VFW_E_NO_CAPTURE_HARDWARE = &H80040275      'キャプチャ ハードウェアが利用できない、またはハードウェアが応答しない。
        VFW_E_DVD_OPERATION_INHIBITED = &H80040276  'この時点でこのユーザー操作は DVD コンテンツによって禁止されている。
        VFW_E_DVD_INVALIDDOMAIN = &H80040277        '現在のドメインでこの処理は許可されていない。
        VFW_E_DVD_NO_BUTTON = &H80040278            '要求されたボタンが利用できない。
        VFW_E_DVD_GRAPHNOTREADY = &H80040279        'DVD-Video 再生グラフが作成されていない。
        VFW_E_DVD_RENDERFAIL = &H8004027A           'DVD-Video 再生グラフの作成が失敗した。
        VFW_E_DVD_DECNOTENOUGH = &H8004027B         'デコーダが不十分だったために、DVD-Video 再生グラフが作成できなかった。
        VFW_E_DVD_NOT_IN_KARAOKE_MODE = &H8004028B  'DVD ナビゲータはカラオケ モードではない。
        VFW_E_FRAME_STEP_UNSUPPORTED = &H8004028E   'コマ送りはサポートされていない。
        VFW_E_PIN_ALREADY_BLOCKED_ON_THIS_THREAD = &H80040293   'ピンは既に呼び出し元のスレッドでブロックされている。
        VFW_E_PIN_ALREADY_BLOCKED = &H80040294      'ピンは既に他のスレッドでブロックされている。
        VFW_E_CERTIFICATION_FAILURE = &H80040295    'このフィルタの使用は、ソフトウェア キーによって制限されている。アプリケーションは、フィルタのロックを解除しなければならない。
        VFW_E_BAD_KEY = &H800403F2                  'レジストリ エントリが壊れている。

        S_OK = 0                                    'Success
        S_FALSE = 1                                 'Fail (not error)
        E_NOTIMPL = &H80004001                      'Not implemented
        E_OUTOFMEMORY = &H8007000E                  'Ran out of memory
        E_INVALIDARG = &H80070057                   'One or more arguments are invalid
        E_NOINTERFACE = &H80004002                  'No such interface supported
        E_POINTER = &H80004003                      'Invalid pointer
        E_HANDLE = &H80070006                       'Invalid handle
        E_ABORT = &H80004004                        'Operation aborted
        E_FAIL = &H80004005                         'Unspecified error
        E_ACCESSDENIED = &H80070005                 'General access denied error

    End Enum

#End Region

#Region "GUID文字列"
    Public Class GUIDString

        'メディアタイプ
        Public Class MediaType
            'メジャータイプ
            Public Shared ReadOnly MEDIATYPE_Video As String = "{73646976-0000-0010-8000-00AA00389B71}"
            Public Shared ReadOnly MEDIATYPE_Audio As String = "{73647561-0000-0010-8000-00AA00389B71}"
            Public Shared ReadOnly MEDIATYPE_Text As String = "{73747874-0000-0010-8000-00AA00389B71}"
            Public Shared ReadOnly MEDIATYPE_Midi As String = "{7364696D-0000-0010-8000-00AA00389B71}"
            Public Shared ReadOnly MEDIATYPE_Stream As String = "{E436EB83-524F-11CE-9F53-0020AF0BA770}"
            Public Shared ReadOnly MEDIATYPE_Interleaved As String = "{73766169-0000-0010-8000-00AA00389B71}"
            Public Shared ReadOnly MEDIATYPE_File As String = "{656C6966-0000-0010-8000-00AA00389B71}"
            Public Shared ReadOnly MEDIATYPE_ScriptCommand As String = "{73636D64-0000-0010-8000-00AA00389B71}"
            Public Shared ReadOnly MEDIATYPE_AUXLine21Data As String = "{670AEA80-3A82-11D0-B79B-00AA003767A7}"
            Public Shared ReadOnly MEDIATYPE_VBI As String = "{F72A76E1-EB0A-11D0-ACE4-0000C0CC16BA}"
            Public Shared ReadOnly MEDIATYPE_Timecode As String = "{0482DEE3-7817-11CF-8A03-00AA006ECB65}"
            Public Shared ReadOnly MEDIATYPE_LMRT As String = "{74726C6D-0000-0010-8000-00AA00389B71}"
            Public Shared ReadOnly MEDIATYPE_URL_STREAM As String = "{74726C6D-0000-0010-8000-00AA00389B71}"

            'サブタイプ
            Public Shared ReadOnly MEDIASUBTYPE_None As String = "{E436EB8E-524F-11CE-9F53-0020AF0BA770}"
            Public Shared ReadOnly MEDIASUBTYPE_CLPL As String = "{4C504C43-0000-0010-8000-00AA00389B71}"
            Public Shared ReadOnly MEDIASUBTYPE_YUYV As String = "{56595559-0000-0010-8000-00AA00389B71}"
            Public Shared ReadOnly MEDIASUBTYPE_IYUV As String = "{56555949-0000-0010-8000-00AA00389B71}"
            Public Shared ReadOnly MEDIASUBTYPE_YVU9 As String = "{39555659-0000-0010-8000-00AA00389B71}"
            Public Shared ReadOnly MEDIASUBTYPE_Y411 As String = "{31313459-0000-0010-8000-00AA00389B71}"
            Public Shared ReadOnly MEDIASUBTYPE_Y41P As String = "{50313459-0000-0010-8000-00AA00389B71}"
            Public Shared ReadOnly MEDIASUBTYPE_YUY2 As String = "{32595559-0000-0010-8000-00AA00389B71}"
            Public Shared ReadOnly MEDIASUBTYPE_YVYU As String = "{55595659-0000-0010-8000-00AA00389B71}"
            Public Shared ReadOnly MEDIASUBTYPE_UYVY As String = "{59565955-0000-0010-8000-00AA00389B71}"
            Public Shared ReadOnly MEDIASUBTYPE_Y211 As String = "{31313259-0000-0010-8000-00AA00389B71}"
            Public Shared ReadOnly MEDIASUBTYPE_CLJR As String = "{524A4C43-0000-0010-8000-00AA00389B71}"
            Public Shared ReadOnly MEDIASUBTYPE_IF09 As String = "{39304649-0000-0010-8000-00AA00389B71}"
            Public Shared ReadOnly MEDIASUBTYPE_CPLA As String = "{414C5043-0000-0010-8000-00AA00389B71}"
            Public Shared ReadOnly MEDIASUBTYPE_MJPG As String = "{47504A4D-0000-0010-8000-00AA00389B71}"
            Public Shared ReadOnly MEDIASUBTYPE_TVMJ As String = "{4A4D5654-0000-0010-8000-00AA00389B71}"
            Public Shared ReadOnly MEDIASUBTYPE_WAKE As String = "{454B4157-0000-0010-8000-00AA00389B71}"
            Public Shared ReadOnly MEDIASUBTYPE_CFCC As String = "{43434643-0000-0010-8000-00AA00389B71}"
            Public Shared ReadOnly MEDIASUBTYPE_IJPG As String = "{47504A49-0000-0010-8000-00AA00389B71}"
            Public Shared ReadOnly MEDIASUBTYPE_Plum As String = "{6D756C50-0000-0010-8000-00AA00389B71}"
            Public Shared ReadOnly MEDIASUBTYPE_DVSD As String = "{44535644-0000-0010-8000-00AA00389B71}"
            Public Shared ReadOnly MEDIASUBTYPE_MDVF As String = "{4656444D-0000-0010-8000-00AA00389B71}"
            Public Shared ReadOnly MEDIASUBTYPE_RGB1 As String = "{E436EB78-524F-11CE-9F53-0020AF0BA770}"
            Public Shared ReadOnly MEDIASUBTYPE_RGB4 As String = "{E436EB79-524F-11CE-9F53-0020AF0BA770}"
            Public Shared ReadOnly MEDIASUBTYPE_RGB8 As String = "{E436EB7A-524F-11CE-9F53-0020AF0BA770}"
            Public Shared ReadOnly MEDIASUBTYPE_RGB565 As String = "{E436EB7B-524F-11CE-9F53-0020AF0BA770}"
            Public Shared ReadOnly MEDIASUBTYPE_RGB555 As String = "{E436EB7C-524F-11CE-9F53-0020AF0BA770}"
            Public Shared ReadOnly MEDIASUBTYPE_RGB24 As String = "{E436EB7D-524F-11CE-9F53-0020AF0BA770}"
            Public Shared ReadOnly MEDIASUBTYPE_RGB32 As String = "{E436EB7E-524F-11CE-9F53-0020AF0BA770}"
            Public Shared ReadOnly MEDIASUBTYPE_ARGB1555 As String = "{297C55AF-E209-4CB3-B757-C76D6B9C88A8}"
            Public Shared ReadOnly MEDIASUBTYPE_ARGB4444 As String = "{6E6415E6-5C24-425F-93CD-80102B3D1CCA}"
            Public Shared ReadOnly MEDIASUBTYPE_ARGB32 As String = "{773C9AC0-3274-11D0-B724-00AA006C1A01}"
            Public Shared ReadOnly MEDIASUBTYPE_A2R10G10B10 As String = "{2F8BB76D-B644-4550-ACF3-D30CAA65D5C5}"
            Public Shared ReadOnly MEDIASUBTYPE_A2B10G10R10 As String = "{576F7893-BDF6-48C4-875F-AE7B81834567}"
            Public Shared ReadOnly MEDIASUBTYPE_AYUV As String = "{56555941-0000-0010-8000-00AA00389B71}"
            Public Shared ReadOnly MEDIASUBTYPE_AI44 As String = "{34344941-0000-0010-8000-00AA00389B71}"
            Public Shared ReadOnly MEDIASUBTYPE_IA44 As String = "{34344149-0000-0010-8000-00AA00389B71}"
            Public Shared ReadOnly MEDIASUBTYPE_YV12 As String = "{32315659-0000-0010-8000-00AA00389B71}"
            Public Shared ReadOnly MEDIASUBTYPE_NV12 As String = "{3231564E-0000-0010-8000-00AA00389B71}"
            Public Shared ReadOnly MEDIASUBTYPE_IMC1 As String = "{31434D49-0000-0010-8000-00AA00389B71}"
            Public Shared ReadOnly MEDIASUBTYPE_IMC2 As String = "{32434d49-0000-0010-8000-00AA00389B71}"
            Public Shared ReadOnly MEDIASUBTYPE_IMC3 As String = "{33434d49-0000-0010-8000-00AA00389B71}"
            Public Shared ReadOnly MEDIASUBTYPE_IMC4 As String = "{34434d49-0000-0010-8000-00AA00389B71}"
            Public Shared ReadOnly MEDIASUBTYPE_S340 As String = "{30343353-0000-0010-8000-00AA00389B71}"
            Public Shared ReadOnly MEDIASUBTYPE_S342 As String = "{32343353-0000-0010-8000-00AA00389B71}"
            Public Shared ReadOnly MEDIASUBTYPE_I420 As String = "{30323449-0000-0010-8000-00AA00389B71}"
            Public Shared ReadOnly MEDIASUBTYPE_Overlay As String = "{E436EB7F-524F-11CE-9F53-0020AF0BA770}"
            Public Shared ReadOnly MEDIASUBTYPE_MPEGPacket As String = "{E436EB80-524F-11CE-9F53-0020AF0BA770}"
            Public Shared ReadOnly MEDIASUBTYPE_MPEG1Payload As String = "{E436EB81-524F-11CE-9F53-0020AF0BA770}"
            Public Shared ReadOnly MEDIASUBTYPE_MPEG1AudioPayload As String = "{00000050-0000-0010-8000-00AA00389B71}"
            Public Shared ReadOnly MEDIASUBTYPE_MPEG1SystemStream As String = "{E436EB82-524F-11CE-9F53-0020AF0BA770}"
            Public Shared ReadOnly MEDIASUBTYPE_MPEG1VideoCD As String = "{E436EB85-524F-11CE-9F53-0020AF0BA770}"
            Public Shared ReadOnly MEDIASUBTYPE_MPEG1Video As String = "{E436EB86-524F-11CE-9F53-0020AF0BA770}"
            Public Shared ReadOnly MEDIASUBTYPE_MPEG1Audio As String = "{E436EB87-524F-11CE-9F53-0020AF0BA770}"
            Public Shared ReadOnly MEDIASUBTYPE_Avi As String = "{E436EB88-524F-11CE-9F53-0020AF0BA770}"
            Public Shared ReadOnly MEDIASUBTYPE_Asf As String = "{3DB80F90-9412-11D1-ADED-0000F8754B99}"
            Public Shared ReadOnly MEDIASUBTYPE_QTMovie As String = "{E436EB89-524F-11CE-9F53-0020AF0BA770}"
            Public Shared ReadOnly MEDIASUBTYPE_Rpza As String = "{617A7072-0000-0010-8000-00AA00389B71}"
            Public Shared ReadOnly MEDIASUBTYPE_Smc As String = "{20636D73-0000-0010-8000-00AA00389B71}"
            Public Shared ReadOnly MEDIASUBTYPE_Rle As String = "{20656C72-0000-0010-8000-00AA00389B71}"
            Public Shared ReadOnly MEDIASUBTYPE_Jpeg As String = "{6765706A-0000-0010-8000-00AA00389B71}"
            Public Shared ReadOnly MEDIASUBTYPE_PCMAudio_Obsolete As String = "{E436EB8A-524F-11CE-9F53-0020AF0BA770}"
            Public Shared ReadOnly MEDIASUBTYPE_PCM As String = "{00000001-0000-0010-8000-00AA00389B71}"
            Public Shared ReadOnly MEDIASUBTYPE_WAVE As String = "{E436EB8B-524F-11CE-9F53-0020AF0BA770}"
            Public Shared ReadOnly MEDIASUBTYPE_AU As String = "{E436EB8C-524F-11CE-9F53-0020AF0BA770}"
            Public Shared ReadOnly MEDIASUBTYPE_AIFF As String = "{E436EB8D-524F-11CE-9F53-0020AF0BA770}"
            Public Shared ReadOnly MEDIASUBTYPE_dvsd2 As String = "{64737664-0000-0010-8000-00AA00389B71}"
            Public Shared ReadOnly MEDIASUBTYPE_dvhd As String = "{64687664-0000-0010-8000-00AA00389B71}"
            Public Shared ReadOnly MEDIASUBTYPE_dvsl As String = "{6C737664-0000-0010-8000-00AA00389B71}"
            Public Shared ReadOnly MEDIASUBTYPE_dv25 As String = "{35327664-0000-0010-8000-00AA00389B71}"
            Public Shared ReadOnly MEDIASUBTYPE_dv50 As String = "{30357664-0000-0010-8000-00AA00389B71}"
            Public Shared ReadOnly MEDIASUBTYPE_dvh1 As String = "{31687664-0000-0010-8000-00AA00389B71}"
            Public Shared ReadOnly MEDIASUBTYPE_Line21_BytePair As String = "{6E8D4A22-310C-11D0-B79A-00AA003767A7}"
            Public Shared ReadOnly MEDIASUBTYPE_Line21_GOPPacket As String = "{6E8D4A23-310C-11D0-B79A-00AA003767A7}"
            Public Shared ReadOnly MEDIASUBTYPE_Line21_VBIRawData As String = "{6E8D4A24-310C-11D0-B79A-00AA003767A7}"
            Public Shared ReadOnly MEDIASUBTYPE_TELETEXT As String = "{F72A76E3-EB0A-11D0-ACE4-0000C0CC16BA}"

        End Class

        'フォーマットタイプ
        Public Class FormatType
            Public Shared ReadOnly FORMAT_None As String = "{0F6417D6-C318-11D0-A43F-00A0C9223196}"
            Public Shared ReadOnly FORMAT_VideoInfo As String = "{05589F80-C356-11CE-BF01-00AA0055595A}"
            Public Shared ReadOnly FORMAT_VideoInfo2 As String = "{F72A76A0-EB0A-11d0-ACE4-0000C0CC16BA}"
            Public Shared ReadOnly FORMAT_WaveFormatEx As String = "{05589F81-C356-11CE-BF01-00AA0055595A}"
        End Class

        'フィルタカテゴリ
        Public Class FilterCategory
            Public Shared ReadOnly CLSID_AudioInputDeviceCategory As String = "{33D9A762-90C8-11d0-BD43-00A0C911CE86}"
            Public Shared ReadOnly CLSID_AudioCompressorCategory As String = "{33D9A761-90C8-11d0-BD43-00A0C911CE86}"
            Public Shared ReadOnly CLSID_AudioRendererCategory As String = "{E0F158E1-CB04-11d0-BD4E-00A0C911CE86}"
            Public Shared ReadOnly CLSID_DeviceControlCategory As String = "{CC7BFB46-F175-11d1-A392-00E0291F3959}"
            Public Shared ReadOnly CLSID_LegacyAmFilterCategory As String = "{083863F1-70DE-11d0-BD40-00A0C911CE86}"
            Public Shared ReadOnly CLSID_TransmitCategory As String = "{CC7BFB41-F175-11d1-A392-00E0291F3959}"
            Public Shared ReadOnly CLSID_MidiRendererCategory As String = "{4EFE2452-168A-11d1-BC76-00C04FB9453B}"
            Public Shared ReadOnly CLSID_VideoInputDeviceCategory As String = "{860BB310-5D01-11d0-BD3B-00A0C911CE86}"
            Public Shared ReadOnly CLSID_VideoCompressorCategory As String = "{33D9A760-90C8-11d0-BD43-00A0C911CE86}"
            Public Shared ReadOnly CLSID_AM_KSCATEGORY_CAPTURE As String = "{65E8773D-8F56-11D0-A3B9-00A0C9223196}"
            Public Shared ReadOnly CLSID_AM_KSCATEGORY_CROSSBAR As String = "{A799A801-A46D-11d0-A18C-00A02401DCD4}"
            Public Shared ReadOnly CLSID_AM_KSCATEGORY_RENDER As String = "{65e8773e-8f56-11d0-a3b9-00a0c9223196}"
            Public Shared ReadOnly CLSID_AM_KSCATEGORY_SPLITTER As String = "{0A4252A0-7E70-11D0-A5D6-28DB04C10000}"
            Public Shared ReadOnly CLSID_AM_KSCATEGORY_TVAUDIO As String = "{A799A802-A46D-11d0-A18C-00A02401DCD4}"
            Public Shared ReadOnly CLSID_AM_KSCATEGORY_TVTUNER As String = "{A799A800-A46D-11d0-A18C-00A02401DCD4}"
            Public Shared ReadOnly CLSID_AM_KSCATEGORY_VBICODEC As String = "{07DAD660-22F1-11d1-A9F4-00C04FBBDE8F}"
            Public Shared ReadOnly CLSID_ActiveMovieCategories As String = "{DA4E3DA0-D07D-11D0-BD50-00A0C911CE86}"
            Public Shared ReadOnly CLSID_KSCATEGORY_COMMUNICATIONSTRANSFORM As String = "{CF1DDA2C-9743-11D0-A3EE-00A0C9223196}"
            Public Shared ReadOnly CLSID_KSCATEGORY_DATATRANSFORM As String = "{2EB07EA0-7E70-11D0-A5D6-28DB04C10000}"
            Public Shared ReadOnly CLSID_KSCATEGORY_INTERFACETRANSFORM As String = "{CF1DDA2D-9743-11D0-A3EE-00A0C9223196}"
            Public Shared ReadOnly CLSID_KSCATEGORY_MIXER As String = "{AD809C00-7B88-11D0-A5D6-28DB04C10000}"
            Public Shared ReadOnly CLSID_KSCATEGORY_BDA_NETWORK_PROVIDER As String = "{71985F4B-1CA1-11D3-9CC8-00C04F7971E0}"
            Public Shared ReadOnly CLSID_KSCATEGORY_BDA_RECEIVER_COMPONENT As String = "{FD0A5AF4-B41D-11d2-9C95-00C04F7971E0}"
            Public Shared ReadOnly CLSID_KSCATEGORY_BDA_TRANSPORT_INFORMATION As String = "{A2E3074F-6C3D-11D3-B653-00C04F79498E}"
        End Class

        'フィルタクラスＩＤ
        Public Class Filter
            Public Shared ReadOnly CLSID_DivXDecoderFilter As String = "{78766964-0000-0010-8000-00AA00389B71}"               'DivX Decoder Filter
            Public Shared ReadOnly CLSID_RTPSourceFilter As String = "{00D20920-7E20-11D0-B291-00C04FC31D18}"                 'RTP Source Filter
            Public Shared ReadOnly CLSID_RTPRenderFilter As String = "{00D20921-7E20-11D0-B291-00C04FC31D18}"                 'RTP Render Filter
            Public Shared ReadOnly CLSID_FullScreenRenderer As String = "{07167665-5011-11CF-BF33-00AA0055595A}"              'Full Screen Renderer
            Public Shared ReadOnly CLSID_MinimalNull As String = "{08AF6540-4F21-11CF-AACB-0020AF0B99A3}"                     'Minimal Null
            Public Shared ReadOnly CLSID_DVMuxer As String = "{129D7E40-C10D-11D0-AFB9-00AA00B67A42}"                         'DV Muxer
            Public Shared ReadOnly CLSID_ColorSpaceConverter As String = "{1643E180-90F5-11CE-97D5-00AA0055595A}"             'Color Space Converter
            Public Shared ReadOnly CLSID_WMASFReader As String = "{187463A0-5BB7-11D3-ACBE-0080C75E246E}"                     'WM ASF Reader
            Public Shared ReadOnly CLSID_AudioSource As String = "{18F39114-6AA8-11D2-8B55-00C04F797443}"                     'Audio Source
            Public Shared ReadOnly CLSID_IntelRTPSPHforG711G7231 As String = "{1AE60860-8297-11D0-9643-00AA00A89C1D}"         'Intel RTP SPH for G.711/G.723.1
            Public Shared ReadOnly CLSID_AVISplitter As String = "{1B544C20-FD0B-11CE-8C63-00AA0044B51E}"                     'AVI Splitter
            Public Shared ReadOnly CLSID_VGA16ColorDitherer As String = "{1DA08500-9EDC-11CF-BC10-00AA00AC74F6}"              'VGA 16 Color Ditherer
            Public Shared ReadOnly CLSID_IndeoRvideo511CompressionFilter As String = "{1F73E9B1-8C3A-11D0-A3BE-00A0C9244436}" 'IndeoR video 5.11 Compression Filter
            Public Shared ReadOnly CLSID_WindowsMediaAudioDecoder As String = "{22E24591-49D0-11D2-BB50-006008320064}"        'Windows Media Audio Decoder
            Public Shared ReadOnly CLSID_PCMSilenceSuppressor As String = "{26721E10-390C-11D0-8A22-00A0C90C9156}"            'PCM Silence Suppressor
            Public Shared ReadOnly CLSID_AC3ParserFilter As String = "{280A3020-86CF-11D1-ABE6-00A0C905F375}"                 'AC3 Parser Filter
            Public Shared ReadOnly CLSID_XingRVideoCDNavigator As String = "{2D300C60-73EE-11D2-AFD4-006008AFEA28}"           'XingR VideoCD Navigator
            Public Shared ReadOnly CLSID_SampleGrabberExample As String = "{2FA4F053-6D60-4CB0-9503-8E89234F3F73}"            'SampleGrabber Example
            Public Shared ReadOnly CLSID_MJPEGDecompressor As String = "{301056D0-6DFF-11D2-9EEB-006008039E37}"               'MJPEG Decompressor
            Public Shared ReadOnly CLSID_IndeoRvideo511DecompressionFilter As String = "{30355649-0000-0010-8000-00AA00389B71}" 'IndeoR video 5.11 Decompression Filter
            Public Shared ReadOnly CLSID_H261DecodeFilter As String = "{31363248-0000-0010-8000-00AA00389B71}"                'H261 Decode Filter
            Public Shared ReadOnly CLSID_MicrosoftScreenVideoDecompressor As String = "{3301A7C4-0A8D-11D4-914D-00C04F610D24}" 'Microsoft Screen Video Decompressor
            Public Shared ReadOnly CLSID_WDMCaptureDevice As String = "{33156162-81D6-11D3-8006-00C04FA30A73}"                'WDM Capture Device
            Public Shared ReadOnly CLSID_H263DecodeFilter As String = "{33363248-0000-0010-8000-00AA00389B71}"                'H263 Decode Filter
            Public Shared ReadOnly CLSID_MPEGIStreamSplitter As String = "{336475D0-942A-11CE-A870-00AA002FEAB5}"             'MPEG-I Stream Splitter
            Public Shared ReadOnly CLSID_SAMIParser As String = "{33FACFE0-A9BE-11D0-A520-00A0D10129C0}"                      'SAMI (CC) Parser
            Public Shared ReadOnly CLSID_Oscilloscope As String = "{35919F40-E904-11CE-8A03-00AA006ECB65}"                    'Oscilloscope
            Public Shared ReadOnly CLSID_Dump As String = "{36A5F770-FE4C-11CE-A8ED-00AA002FEAB5}"                            'Dump
            Public Shared ReadOnly CLSID_MPEGLayer3Decoder As String = "{38BE3000-DBF4-11D0-860E-00A024CFEF6D}"               'MPEG Layer-3 Decoder
            Public Shared ReadOnly CLSID_IntelRTPDemuxFilter As String = "{399D5C90-74AB-11D0-9CCF-00A0C9081C19}"             'Intel RTP Demux Filter
            Public Shared ReadOnly CLSID_MPEG2Splitter As String = "{3AE86B20-7BE8-11D1-ABE6-00A0C905F375}"                   'MPEG-2 Splitter
            Public Shared ReadOnly CLSID_CyberLinkAudioEffect As String = "{3D5455E5-D8E8-4B4C-84AF-4703C5542042}"            'CyberLink Audio Effect
            Public Shared ReadOnly CLSID_IntelRTPSPHforGenericAudio As String = "{3DDDA000-88E4-11D0-9643-00AA00A89C1D}"      'Intel RTP SPH for Generic Audio
            Public Shared ReadOnly CLSID_ACELPnetSiproLabAudioDecoder As String = "{4009F700-AEBA-11D1-8344-00C04FB92EB7}"        'ACELP.net Sipro Lab Audio Decoder
            Public Shared ReadOnly CLSID_InternalScriptCommandRenderer As String = "{48025243-2D39-11CE-875D-00608CB78066}" 'Internal Script Command Renderer
            Public Shared ReadOnly CLSID_MPEGAudioDecoder As String = "{4A2286E0-7BEF-11CE-9BD9-0000E202599C}" 'MPEG Audio Decoder
            Public Shared ReadOnly CLSID_FileSource_NetshowURL As String = "{4B428940-263C-11D1-A520-000000000000}" 'File Source (Netshow URL)
            Public Shared ReadOnly CLSID_SampleVideoRenderer As String = "{4D4B1600-33AC-11CF-BF30-00AA0055595A}" 'Sample Video Renderer
            Public Shared ReadOnly CLSID_DVSplitter As String = "{4EB31670-9FC6-11CF-AF6E-00AA00B67A42}" 'DV Splitter
            Public Shared ReadOnly CLSID_WindowsMediaVideoDecoder_A As String = "{4FACBBA1-FFD8-4CD7-8228-61E2F65CB1AE}" 'Windows Media Video Decoder
            Public Shared ReadOnly CLSID_WindowsMediaVideoDecoder_B As String = "{521FB373-7654-49F2-BDB1-0C6E6660714F}" 'Windows Media Video Decoder
            Public Shared ReadOnly CLSID_ClipperFilter As String = "{501B7653-CA15-432C-AAD3-41ED64201217}" 'ClipperFilter
            Public Shared ReadOnly CLSID_VideoMixingRenderer9 As String = "{51B4ABF3-748F-4E3B-A276-C828330E926A}" 'Video Mixing Renderer 9
            Public Shared ReadOnly CLSID_DiskRecordQueue As String = "{5BB4BE4A-09B3-4689-BB4B-6F33E1E82797}" 'Disk Record Queue
            Public Shared ReadOnly CLSID_ColorConverter As String = "{637E3E39-462F-477E-9DAF-F07B9B1C00D2}" 'Color Converter
            Public Shared ReadOnly CLSID_WindowsMediaMultiplexer As String = "{63F8AA94-E2B9-11D0-ADF6-00C04FB66DAD}" 'Windows Media Multiplexer
            Public Shared ReadOnly CLSID_ASXfileParser As String = "{640999A0-A946-11D0-A520-000000000000}" 'ASX file Parser
            Public Shared ReadOnly CLSID_ASXv2fileParser As String = "{640999A1-A946-11D0-A520-000000000000}" 'ASX v.2 file Parser
            Public Shared ReadOnly CLSID_NSCfileParser As String = "{640999A2-A946-11D0-A520-000000000000}" 'NSC file Parser
            Public Shared ReadOnly CLSID_ACMWrapper As String = "{6A08CF80-0E18-11CF-A24D-0020AFD79767}" 'ACM Wrapper
            Public Shared ReadOnly CLSID_WindowsMediasourcefilter As String = "{6B6D0800-9ADA-11D0-A520-00A0D10129C0}" 'Windows Media source filter
            Public Shared ReadOnly CLSID_Line21Decoder As String = "{6E8D4A20-310C-11D0-B79A-00AA003767A7}" 'Line 21 Decoder
            Public Shared ReadOnly CLSID_WSTDecoder As String = "{70BC06E0-5666-11D3-A184-00105AEF9F33}" 'WST Decoder
            Public Shared ReadOnly CLSID_VideoRenderer As String = "{70E102B0-5556-11CE-97C0-00AA0055595A}" 'Video Renderer
            Public Shared ReadOnly CLSID_AudioSynthesizer As String = "{79A98DE0-BC00-11CE-AC2E-444553540000}" 'Audio Synthesizer
            Public Shared ReadOnly CLSID_WMASFWriter As String = "{7C23220E-55BB-11D3-8B16-00C04FB6BD3D}" 'WM ASF Writer
            Public Shared ReadOnly CLSID_MemoFilter As String = "{7C4C601E-F338-46E6-9EA0-F047A5A2EFF1}" 'MemoFilter
            Public Shared ReadOnly CLSID_VBISurfaceAllocator As String = "{814B9800-1C88-11D1-BAD9-00609744111A}" 'VBI Surface Allocator
            Public Shared ReadOnly CLSID_MicrosoftMPEG4VideoDecompressor As String = "{82CCD3E0-F71A-11D0-9FE5-00609778EA66}" 'Microsoft MPEG-4 Video Decompressor
            Public Shared ReadOnly CLSID_Filewriter As String = "{8596E5F0-0DA5-11D0-BD21-00A0C911CE86}" 'File writer
            Public Shared ReadOnly CLSID_WinampDSPtoDirectShow As String = "{87491715-CC71-4160-BDB1-24FF4FD250D8}" 'Winamp DSP to DirectShow
            Public Shared ReadOnly CLSID_ImageEffects As String = "{8B498501-1218-11CF-ADC4-00A0D100041B}" 'Image Effects
            Public Shared ReadOnly CLSID_hunuaaCropping As String = "{8ED21D59-66E8-4B62-819A-3FB86F05A7C1}" 'hunuaa Cropping
            Public Shared ReadOnly CLSID_DVDNavigator As String = "{9B8C4620-2C1A-11D0-8493-00A02438AD48}" 'DVD Navigator
            Public Shared ReadOnly CLSID_CyberLinkAudioDecoder As String = "{9BC1B780-85E3-11D2-98D0-0080C84E9C39}" 'CyberLink Audio Decoder
            Public Shared ReadOnly CLSID_CyberLinkVideoSPDecoder As String = "{9BC1B781-85E3-11D2-98D0-0080C84E9C39}" 'CyberLink Video/SP Decoder
            Public Shared ReadOnly CLSID_OverlayMixer2 As String = "{A0025E90-E45B-11D1-ABE9-00A0C905F375}" 'Overlay Mixer2
            Public Shared ReadOnly CLSID_CutlistFileSource As String = "{A5EA8D20-253D-11D1-B3F1-00AA003761C5}" 'Cutlist File Source
            Public Shared ReadOnly CLSID_AVIDraw As String = "{A888DF60-1E90-11CF-AC98-00AA004C0FA9}" 'AVI Draw
            Public Shared ReadOnly CLSID_RAMfileParser As String = "{A98C8400-4181-11D1-A520-00A0D10129C0}" 'RAM file Parser
            Public Shared ReadOnly CLSID_G711Codec As String = "{AF7D8180-A8F9-11CF-9A46-00AA00B7DAD1}" 'G.711 Codec
            Public Shared ReadOnly CLSID_MPEG2Demultiplexer As String = "{AFB6C280-2C41-11D3-8A60-0000F81E0E4A}" 'MPEG-2 Demultiplexer
            Public Shared ReadOnly CLSID_DVVideoDecoder As String = "{B1B77C00-C3E4-11CF-AF79-00AA00B67A42}" 'DV Video Decoder
            Public Shared ReadOnly CLSID_IndeoRaudiosoftware As String = "{B4CA2970-DD2B-11D0-9DFA-00AA00AF3494}" 'IndeoR audio software
            Public Shared ReadOnly CLSID_WindowsMediaUpdateFilter As String = "{B6353564-96C4-11D2-8DDB-006097C9A2B2}" 'Windows Media Update Filter
            Public Shared ReadOnly CLSID_ScreenCapturefilter As String = "{B9330878-C1DB-11D3-B36B-00C04F6108FF}" 'Screen Capture filter
            Public Shared ReadOnly CLSID_ASFDIBHandler As String = "{B9D1F320-C401-11D0-A520-000000000000}" 'ASF DIB Handler
            Public Shared ReadOnly CLSID_ASFACMHandler As String = "{B9D1F321-C401-11D0-A520-000000000000}" 'ASF ACM Handler
            Public Shared ReadOnly CLSID_ASFICMHandler As String = "{B9D1F322-C401-11D0-A520-000000000000}" 'ASF ICM Handler
            Public Shared ReadOnly CLSID_ASFURLHandler As String = "{B9D1F323-C401-11D0-A520-000000000000}" 'ASF URL Handler
            Public Shared ReadOnly CLSID_ASFJPEGHandler As String = "{B9D1F324-C401-11D0-A520-000000000000}" 'ASF JPEG Handler
            Public Shared ReadOnly CLSID_ASFDJPEGHandler As String = "{B9D1F325-C401-11D0-A520-000000000000}" 'ASF DJPEG Handler
            Public Shared ReadOnly CLSID_ASFembeddedstuffHandler As String = "{B9D1F32E-C401-11D0-A520-000000000000}" 'ASF embedded stuff Handler
            Public Shared ReadOnly CLSID_SampleGrabber As String = "{C1F400A0-3F08-11D3-9F0B-006008039E37}" 'SampleGrabber
            Public Shared ReadOnly CLSID_NullRenderer As String = "{C1F400A4-3F08-11D3-9F0B-006008039E37}" 'Null Renderer
            Public Shared ReadOnly CLSID_CyberLinkDxVAFilter2 As String = "{C494A68B-A398-4E2B-A63A-02578A84DFF4}" 'CyberLink DxVA Filter 2
            Public Shared ReadOnly CLSID_MPEG2SectionsandTables As String = "{C666E115-BB62-4027-A113-82D643FE2D99}" 'MPEG-2 Sections and Tables
            Public Shared ReadOnly CLSID_IVFsourcefilter As String = "{C69E8F40-D5C8-11D0-A520-145405C10000}" 'IVF source filter
            Public Shared ReadOnly CLSID_H263EncodeFilter As String = "{C9076CE2-FB56-11CF-906C-00AA00A59F69}" 'H263 Encode Filter
            Public Shared ReadOnly CLSID_SmartTee As String = "{CC58E280-8AA1-11D1-B3F1-00AA003761C5}" 'Smart Tee
            Public Shared ReadOnly CLSID_OverlayMixer As String = "{CD8743A1-3736-11D0-9E69-00C04FD7C15B}" 'Overlay Mixer
            Public Shared ReadOnly CLSID_MicrosoftPCMAudioMixer As String = "{CDCDD6A0-C016-11D0-82A4-00AA00B5CA1B}" 'Microsoft PCM Audio Mixer
            Public Shared ReadOnly CLSID_RealPlayerAudioFilter As String = "{CEF4D40F-ACA5-40BA-8F3B-161A594A1A39}" 'RealPlayer Audio Filter
            Public Shared ReadOnly CLSID_AVIDecompressor As String = "{CF49D4E0-1115-11CE-B03A-0020AF0BA770}" 'AVI Decompressor
            Public Shared ReadOnly CLSID_AVIWAVFileSource As String = "{D3588AB0-0781-11CE-B03A-0020AF0BA770}" 'AVI/WAV File Source
            Public Shared ReadOnly CLSID_IntelRTPRPHforG711G7231 As String = "{D42FEAC0-82A1-11D0-9643-00AA00A89C1D}" 'Intel RTP RPH for G.711/G.723.1
            Public Shared ReadOnly CLSID_QuickTimeMovieParser As String = "{D51BD5A0-7548-11CF-A520-0080C77EF58A}" 'QuickTime Movie Parser
            Public Shared ReadOnly CLSID_WaveParser As String = "{D51BD5A1-7548-11CF-A520-0080C77EF58A}" 'Wave Parser
            Public Shared ReadOnly CLSID_MIDIParser As String = "{D51BD5A2-7548-11CF-A520-0080C77EF58A}" 'MIDI Parser
            Public Shared ReadOnly CLSID_MultifileParser As String = "{D51BD5A3-7548-11CF-A520-0080C77EF58A}" 'Multi-file Parser
            Public Shared ReadOnly CLSID_LyricParser As String = "{D51BD5A4-7548-11CF-A520-0080C77EF58A}" 'Lyric Parser
            Public Shared ReadOnly CLSID_Filestreamrenderer As String = "{D51BD5A5-7548-11CF-A520-0080C77EF58A}" 'File stream renderer
            Public Shared ReadOnly CLSID_XMLPlaylist As String = "{D51BD5AE-7548-11CF-A520-0080C77EF58A}" 'XML Playlist
            Public Shared ReadOnly CLSID_AVDummyFilter As String = "{D74E6C66-DC8A-4BCD-808F-066FC71A1618}" 'A/V Dummy Filter
            Public Shared ReadOnly CLSID_VideoSource As String = "{DC0DADF0-8E0D-11D2-8B62-00C04F797443}" 'Video Source
            Public Shared ReadOnly CLSID_AVIMux As String = "{E2510970-F137-11CE-8B67-00AA00A3F1A6}" 'AVI Mux
            Public Shared ReadOnly CLSID_TextDisplay As String = "{E30629D3-27E5-11CE-875D-00608CB78066}" 'Text Display
            Public Shared ReadOnly CLSID_Line21Decoder2 As String = "{E4206432-01A1-4BEE-B3E1-3702C8EDC574}" 'Line 21 Decoder 2
            Public Shared ReadOnly CLSID_FileSource_Async As String = "{E436EBB5-524F-11CE-9F53-0020AF0BA770}" 'File Source (Async.)
            Public Shared ReadOnly CLSID_FileSource_URL As String = "{E436EBB6-524F-11CE-9F53-0020AF0BA770}" 'File Source (URL)
            Public Shared ReadOnly CLSID_IntelRTPSPHforH263H261_A As String = "{EC941960-7DF6-11D0-9643-00AA00A89C1D}" 'Intel RTP SPH for H.263/H.261
            Public Shared ReadOnly CLSID_IntelRTPRPHforH263H261_B As String = "{EC941961-7DF6-11D0-9643-00AA00A89C1D}" 'Intel RTP RPH for H.263/H.261
            Public Shared ReadOnly CLSID_IntelRTPRPHforGenericAudio As String = "{ECB29E60-88ED-11D0-9643-00AA00A89C1D}" 'Intel RTP RPH for Generic Audio
            Public Shared ReadOnly CLSID_H261EncodeFilter As String = "{EFD08EC1-EA11-11CF-9FEC-00AA00A59F69}" 'H261 Encode Filter
            Public Shared ReadOnly CLSID_InfinitePinTeeFilter As String = "{F8388A40-D5BB-11D0-BE5A-0080C706568E}" 'Infinite Pin Tee Filter
            Public Shared ReadOnly CLSID_BDAMPEG2TransportInformationFilter As String = "{FC772AB0-0C7F-11D3-8FF2-00A0C9224CF4}" 'BDA MPEG2 Transport Information Filter
            Public Shared ReadOnly CLSID_BouncingBall As String = "{FD501041-8EBE-11CE-8183-00AA00577DA1}" 'Bouncing Ball
            Public Shared ReadOnly CLSID_VideoContrast As String = "{FD501043-8EBE-11CE-8183-00AA00577DA1}" 'Video Contrast
            Public Shared ReadOnly CLSID_QTDecompressor As String = "{FDFE9681-74A3-11D0-AFA7-00AA00B67A42}" 'QT Decompressor
            Public Shared ReadOnly CLSID_MPEGVideoDecoder As String = "{FEB50740-7BEF-11CE-9BD9-0000E202599C}" 'MPEG Video Decoder
            Public Shared ReadOnly CLSID_IndeoRvideo44DecompressionFilter As String = "{31345649-0000-0010-8000-00AA00389B71}" 'IndeoR video 4.4 Decompression Filter
            Public Shared ReadOnly CLSID_VoxwareMetaVoiceAudioDecoder As String = "{46E32B01-A465-11D1-B550-006097242D8D}" 'Voxware MetaVoice Audio Decoder
            Public Shared ReadOnly CLSID_VoxwareMetaSoundAudioDecoder As String = "{73F7A062-8829-11D1-B550-006097242D8D}" 'Voxware MetaSound Audio Decoder
            Public Shared ReadOnly CLSID_IndeoRvideo44CompressionFilter As String = "{A2551F60-705F-11CF-A424-00AA003735BE}" 'IndeoR video 4.4 Compression Filter
        End Class

        'インターフェースＩＤ
        Public Class [Interface]
            Public Shared ReadOnly IID_IPropertyBag As String = "{55272A00-42CB-11CE-8135-00AA004BB851}"
            Public Shared ReadOnly IID_IBaseFilter As String = "{56a86895-0ad4-11ce-b03a-0020af0ba770}"
            Public Shared ReadOnly IID_IAMStreamConfig As String = "{C6E13340-30AC-11d0-A18C-00A0C9118956}"
        End Class

        'ピンプロパティセット
        Public Class PinCategory
            Public Shared ReadOnly PIN_CATEGORY_CAPTURE As String = "{fb6c4281-0353-11d1-905f-0000c0cc16ba}"
            Public Shared ReadOnly PIN_CATEGORY_PREVIEW As String = "{fb6c4282-0353-11d1-905f-0000c0cc16ba}"
        End Class

        'クラスＩＤ
        Public Shared ReadOnly CLSID_FilterGraph As String = "{E436EBB3-524F-11CE-9F53-0020AF0BA770}"
        Public Shared ReadOnly CLSID_SystemDeviceEnum As String = "{62BE5D10-60EB-11d0-BD3B-00A0C911CE86}"
        Public Shared ReadOnly CLSID_CaptureGraphBuilder2 As String = "{BF87B6E1-8C27-11d0-B3F0-00AA003761C5}"

    End Class
#End Region

#Region "その他"

    '音声のフォーマット形式
    Public Const WAVE_FORMAT_PCM As Integer = 1

#End Region

#End Region

    '//////////////////////////////////////////////////////////
    '構造体定義
    '//////////////////////////////////////////////////////////
#Region "構造体定義"

    'AM_MEDIA_TYPE
    <StructLayout(LayoutKind.Sequential), ComVisible(False)> _
    Public Class AMMediaType
        Public majorType As Guid
        Public subType As Guid
        <MarshalAs(UnmanagedType.Bool)> Public fixedSizeSamples As Boolean
        <MarshalAs(UnmanagedType.Bool)> Public temporalCompression As Boolean
        Public sampleSize As Integer
        Public formatType As Guid
        Public unkPtr As IntPtr
        Public formatSize As Integer
        Public formatPtr As IntPtr
    End Class

    'FILTER_INFO
    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Unicode), ComVisible(False)> _
    Public Class FILTER_INFO
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=128)> Public achName As String
        <MarshalAs(UnmanagedType.IUnknown)> Public pUnk As Object
    End Class

    'PIN_INFO
    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Unicode), ComVisible(False)> _
    Public Class PIN_INFO
        Public Filter As IBaseFilter
        Public PinDir As PinDirection
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=128)> Public Name As String
    End Class

    'RECT
    <StructLayout(LayoutKind.Sequential), ComVisible(False)> _
    Public Structure DSRECT
        Public Left As Integer
        Public Top As Integer
        Public Right As Integer
        Public Bottom As Integer
    End Structure

    'BITMAPINFOHEADER
    <StructLayout(LayoutKind.Sequential, Pack:=2), ComVisible(False)> _
    Public Structure DSBITMAPINFOHEADER
        Public Size As Integer
        Public Width As Integer
        Public Height As Integer
        Public Planes As Short
        Public BitCount As Short
        Public Compression As Integer
        Public ImageSize As Integer
        Public XPelsPerMeter As Integer
        Public YPelsPerMeter As Integer
        Public ClrUsed As Integer
        Public ClrImportant As Integer
    End Structure

    'VIDEOINFOHEADER
    <StructLayout(LayoutKind.Sequential), ComVisible(False)> _
    Public Class DSVIDEOINFOHEADER
        Public SrcRect As DSRECT
        Public TagRect As DSRECT
        Public BitRate As Integer
        Public BitErrorRate As Integer
        Public AvgTimePerFrame As Long
        Public BmiHeader As DSBITMAPINFOHEADER
    End Class

    'WAVEFORMATEX
    <StructLayout(LayoutKind.Sequential), ComVisible(False)> _
    Public Class DSWAVEFORMATEX
        Public FormatTag As UInt16
        Public Channels As UInt16
        Public SamplesPerSec As UInt32
        Public AvgBytesPerSec As UInt32
        Public BlockAlign As Int16
        Public BitsPerSample As Int16
        Public Size As Int16
    End Class

    'ピクセル操作用構造体
    <StructLayout(LayoutKind.Explicit, Size:=4)> _
    Public Structure DSPIXEL
        <FieldOffset(0)> Public dw As UInt32
        <FieldOffset(0)> Public b As Byte
        <FieldOffset(1)> Public g As Byte
        <FieldOffset(2)> Public r As Byte
        <FieldOffset(3)> Public a As Byte
    End Structure

#End Region

    '//////////////////////////////////////////////////////////
    'インターフェース定義
    '//////////////////////////////////////////////////////////
#Region "インターフェース定義"

#Region "グラフ関係"

    <ComVisible(True), ComImport(), Guid("56a868a9-0ad4-11ce-b03a-0020af0ba770"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)> _
    Public Interface IGraphBuilder
#Region "IFilterGraph Methods"
        <PreserveSig()> Function AddFilter(<[In]()> ByVal pFilter As IBaseFilter, <[In](), MarshalAs(UnmanagedType.LPWStr)> ByVal pName As String) As Integer
        <PreserveSig()> Function RemoveFilter(<[In]()> ByVal pFilter As IBaseFilter) As Integer
        <PreserveSig()> Function EnumFilters(<Out()> ByRef ppEnum As IEnumFilters) As Integer
        <PreserveSig()> Function FindFilterByName(<[In](), MarshalAs(UnmanagedType.LPWStr)> ByVal pName As String, <Out()> ByRef ppFilter As IBaseFilter) As Integer
        <PreserveSig()> Function ConnectDirect(<[In]()> ByVal ppinOut As IPin, <[In]()> ByVal ppinIn As IPin, <[In](), MarshalAs(UnmanagedType.LPStruct)> ByVal pmt As AMMediaType) As Integer
        <PreserveSig()> Function Reconnect(<[In]()> ByVal ppin As IPin) As Integer
        <PreserveSig()> Function Disconnect(<[In]()> ByVal ppin As IPin) As Integer
        <PreserveSig()> Function SetDefaultSyncSource() As Integer
#End Region

        <PreserveSig()> Function Connect(<[In]()> ByVal ppinOut As IPin, <[In]()> ByVal ppinIn As IPin) As Integer
        <PreserveSig()> Function Render(<[In]()> ByVal ppinOut As IPin) As Integer
        <PreserveSig()> Function RenderFile(<[In](), MarshalAs(UnmanagedType.LPWStr)> ByVal lpcwstrFile As String, <[In](), MarshalAs(UnmanagedType.LPWStr)> ByVal lpcwstrPlayList As String) As Integer
        <PreserveSig()> Function AddSourceFilter(<[In](), MarshalAs(UnmanagedType.LPWStr)> ByVal lpcwstrFileName As String, <[In](), MarshalAs(UnmanagedType.LPWStr)> ByVal lpcwstrFilterName As String, <Out()> ByRef ppFilter As IBaseFilter) As Integer
        <PreserveSig()> Function SetLogFile(ByVal hFile As IntPtr) As Integer
        <PreserveSig()> Function Abort() As Integer
        <PreserveSig()> Function ShouldOperationContinue() As Integer
    End Interface

    <ComVisible(True), ComImport(), Guid("56a8689f-0ad4-11ce-b03a-0020af0ba770"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)> _
    Public Interface IFilterGraph
        <PreserveSig()> Function AddFilter(<[In]()> ByVal pFilter As IBaseFilter, <[In](), MarshalAs(UnmanagedType.LPWStr)> ByVal pName As String) As Integer
        <PreserveSig()> Function RemoveFilter(<[In]()> ByVal pFilter As IBaseFilter) As Integer
        <PreserveSig()> Function EnumFilters(<Out()> ByRef ppEnum As IEnumFilters) As Integer
        <PreserveSig()> Function FindFilterByName(<[In](), MarshalAs(UnmanagedType.LPWStr)> ByVal pName As String, <Out()> ByRef ppFilter As IBaseFilter) As Integer
        <PreserveSig()> Function ConnectDirect(<[In]()> ByVal ppinOut As IPin, <[In]()> ByVal ppinIn As IPin, <[In](), MarshalAs(UnmanagedType.LPStruct)> ByVal pmt As AMMediaType) As Integer
        <PreserveSig()> Function Reconnect(<[In]()> ByVal ppin As IPin) As Integer
        <PreserveSig()> Function Disconnect(<[In]()> ByVal ppin As IPin) As Integer
        <PreserveSig()> Function SetDefaultSyncSource() As Integer
    End Interface

    <ComVisible(True), ComImport(), Guid("56a868b1-0ad4-11ce-b03a-0020af0ba770"), InterfaceType(ComInterfaceType.InterfaceIsDual)> _
    Public Interface IMediaControl
        <PreserveSig()> Function Run() As Integer
        <PreserveSig()> Function Pause() As Integer
        <PreserveSig()> Function [Stop]() As Integer
        <PreserveSig()> Function GetState(ByVal msTimeout As Integer, ByRef pfs As Integer) As Integer
        <PreserveSig()> Function RenderFile(ByVal strFilename As String) As Integer
        <PreserveSig()> Function AddSourceFilter(<[In]()> ByVal strFilename As String, <Out(), MarshalAs(UnmanagedType.IDispatch)> ByRef ppUnk As Object) As Integer
        <PreserveSig()> Function get_FilterCollection(<Out(), MarshalAs(UnmanagedType.IDispatch)> ByRef ppUnk As Object) As Integer
        <PreserveSig()> Function get_RegFilterCollection(<Out(), MarshalAs(UnmanagedType.IDispatch)> ByRef ppUnk As Object) As Integer
        <PreserveSig()> Function StopWhenReady() As Integer
    End Interface

    <ComVisible(True), ComImport(), Guid("56a868b2-0ad4-11ce-b03a-0020af0ba770"), InterfaceType(ComInterfaceType.InterfaceIsDual)> _
    Public Interface IMediaPosition
        <PreserveSig()> Function get_Duration(ByRef pLength As Double) As Integer
        <PreserveSig()> Function put_CurrentPosition(ByVal llTime As Double) As Integer
        <PreserveSig()> Function get_CurrentPosition(ByRef pllTime As Double) As Integer
        <PreserveSig()> Function get_StopTime(ByRef pllTime As Double) As Integer
        <PreserveSig()> Function put_StopTime(ByVal llTime As Double) As Integer
        <PreserveSig()> Function get_PrerollTime(ByRef pllTime As Double) As Integer
        <PreserveSig()> Function put_PrerollTime(ByVal llTime As Double) As Integer
        <PreserveSig()> Function put_Rate(ByVal dRate As Double) As Integer
        <PreserveSig()> Function get_Rate(ByRef pdRate As Double) As Integer
        <PreserveSig()> Function CanSeekForward(ByRef pCanSeekForward As Integer) As Integer
        <PreserveSig()> Function CanSeekBackward(ByRef pCanSeekBackward As Integer) As Integer
    End Interface

    <ComVisible(True), ComImport(), Guid("56a868b4-0ad4-11ce-b03a-0020af0ba770"), InterfaceType(ComInterfaceType.InterfaceIsDual)> _
    Public Interface IVideoWindow
        <PreserveSig()> Function put_Caption(ByVal caption As String) As Integer
        <PreserveSig()> Function get_Caption(<Out()> ByRef caption As String) As Integer
        <PreserveSig()> Function put_WindowStyle(ByVal windowStyle As Integer) As Integer
        <PreserveSig()> Function get_WindowStyle(ByRef windowStyle As Integer) As Integer
        <PreserveSig()> Function put_WindowStyleEx(ByVal windowStyleEx As Integer) As Integer
        <PreserveSig()> Function get_WindowStyleEx(ByRef windowStyleEx As Integer) As Integer
        <PreserveSig()> Function put_AutoShow(ByVal autoShow As Integer) As Integer
        <PreserveSig()> Function get_AutoShow(ByRef autoShow As Integer) As Integer
        <PreserveSig()> Function put_WindowState(ByVal windowState As Integer) As Integer
        <PreserveSig()> Function get_WindowState(ByRef windowState As Integer) As Integer
        <PreserveSig()> Function put_BackgroundPalette(ByVal backgroundPalette As Integer) As Integer
        <PreserveSig()> Function get_BackgroundPalette(ByRef backgroundPalette As Integer) As Integer
        <PreserveSig()> Function put_Visible(ByVal visible As Integer) As Integer
        <PreserveSig()> Function get_Visible(ByRef visible As Integer) As Integer
        <PreserveSig()> Function put_Left(ByVal left As Integer) As Integer
        <PreserveSig()> Function get_Left(ByRef left As Integer) As Integer
        <PreserveSig()> Function put_Width(ByVal width As Integer) As Integer
        <PreserveSig()> Function get_Width(ByRef width As Integer) As Integer
        <PreserveSig()> Function put_Top(ByVal top As Integer) As Integer
        <PreserveSig()> Function get_Top(ByRef top As Integer) As Integer
        <PreserveSig()> Function put_Height(ByVal height As Integer) As Integer
        <PreserveSig()> Function get_Height(ByRef height As Integer) As Integer
        <PreserveSig()> Function put_Owner(ByVal owner As IntPtr) As Integer
        <PreserveSig()> Function get_Owner(ByRef owner As IntPtr) As Integer
        <PreserveSig()> Function put_MessageDrain(ByVal drain As IntPtr) As Integer
        <PreserveSig()> Function get_MessageDrain(ByRef drain As IntPtr) As Integer
        <PreserveSig()> Function get_BorderColor(ByRef color As Integer) As Integer
        <PreserveSig()> Function put_BorderColor(ByVal color As Integer) As Integer
        <PreserveSig()> Function get_FullScreenMode(ByRef fullScreenMode As Integer) As Integer
        <PreserveSig()> Function put_FullScreenMode(ByVal fullScreenMode As Integer) As Integer
        <PreserveSig()> Function SetWindowForeground(ByVal focus As Integer) As Integer
        <PreserveSig()> Function NotifyOwnerMessage(ByVal hwnd As IntPtr, ByVal msg As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As Integer
        <PreserveSig()> Function SetWindowPosition(ByVal left As Integer, ByVal top As Integer, ByVal width As Integer, ByVal height As Integer) As Integer
        <PreserveSig()> Function GetWindowPosition(ByRef left As Integer, ByRef top As Integer, ByRef width As Integer, ByRef height As Integer) As Integer
        <PreserveSig()> Function GetMinIdealImageSize(ByRef width As Integer, ByRef height As Integer) As Integer
        <PreserveSig()> Function GetMaxIdealImageSize(ByRef width As Integer, ByRef height As Integer) As Integer
        <PreserveSig()> Function GetRestorePosition(ByRef left As Integer, ByRef top As Integer, ByRef width As Integer, ByRef height As Integer) As Integer
        <PreserveSig()> Function HideCursor(ByVal HideCursorValue As Integer) As Integer
        <PreserveSig()> Function IsCursorHidden(ByRef hideCursor As Integer) As Integer
    End Interface

    <ComVisible(True), ComImport(), Guid("329bb360-f6ea-11d1-9038-00a0c9697298"), InterfaceType(ComInterfaceType.InterfaceIsDual)> _
    Public Interface IBasicVideo2
        <PreserveSig()> Function AvgTimePerFrame(ByRef pAvgTimePerFrame As Double) As Integer
        <PreserveSig()> Function BitRate(ByRef pBitRate As Integer) As Integer
        <PreserveSig()> Function BitErrorRate(ByRef pBitRate As Integer) As Integer
        <PreserveSig()> Function VideoWidth(ByRef pVideoWidth As Integer) As Integer
        <PreserveSig()> Function VideoHeight(ByRef pVideoHeight As Integer) As Integer
        <PreserveSig()> Function put_SourceLeft(ByVal SourceLeft As Integer) As Integer
        <PreserveSig()> Function get_SourceLeft(ByRef pSourceLeft As Integer) As Integer
        <PreserveSig()> Function put_SourceWidth(ByVal SourceWidth As Integer) As Integer
        <PreserveSig()> Function get_SourceWidth(ByRef pSourceWidth As Integer) As Integer
        <PreserveSig()> Function put_SourceTop(ByVal SourceTop As Integer) As Integer
        <PreserveSig()> Function get_SourceTop(ByRef pSourceTop As Integer) As Integer
        <PreserveSig()> Function put_SourceHeight(ByVal SourceHeight As Integer) As Integer
        <PreserveSig()> Function get_SourceHeight(ByRef pSourceHeight As Integer) As Integer
        <PreserveSig()> Function put_DestinationLeft(ByVal DestinationLeft As Integer) As Integer
        <PreserveSig()> Function get_DestinationLeft(ByRef pDestinationLeft As Integer) As Integer
        <PreserveSig()> Function put_DestinationWidth(ByVal DestinationWidth As Integer) As Integer
        <PreserveSig()> Function get_DestinationWidth(ByRef pDestinationWidth As Integer) As Integer
        <PreserveSig()> Function put_DestinationTop(ByVal DestinationTop As Integer) As Integer
        <PreserveSig()> Function get_DestinationTop(ByRef pDestinationTop As Integer) As Integer
        <PreserveSig()> Function put_DestinationHeight(ByVal DestinationHeight As Integer) As Integer
        <PreserveSig()> Function get_DestinationHeight(ByRef pDestinationHeight As Integer) As Integer
        <PreserveSig()> Function SetSourcePosition(ByVal left As Integer, ByVal top As Integer, ByVal width As Integer, ByVal height As Integer) As Integer
        <PreserveSig()> Function GetSourcePosition(ByRef left As Integer, ByRef top As Integer, ByRef width As Integer, ByRef height As Integer) As Integer
        <PreserveSig()> Function SetDefaultSourcePosition() As Integer
        <PreserveSig()> Function SetDestinationPosition(ByVal left As Integer, ByVal top As Integer, ByVal width As Integer, ByVal height As Integer) As Integer
        <PreserveSig()> Function GetDestinationPosition(ByRef left As Integer, ByRef top As Integer, ByRef width As Integer, ByRef height As Integer) As Integer
        <PreserveSig()> Function SetDefaultDestinationPosition() As Integer
        <PreserveSig()> Function GetVideoSize(ByRef pWidth As Integer, ByRef pHeight As Integer) As Integer
        <PreserveSig()> Function GetVideoPaletteEntries(ByVal StartIndex As Integer, ByVal Entries As Integer, ByRef pRetrieved As Integer, ByVal pPalette As IntPtr) As Integer
        <PreserveSig()> Function GetCurrentImage(ByRef pBufferSize As Integer, ByVal pDIBImage As IntPtr) As Integer
        <PreserveSig()> Function IsUsingDefaultSource() As Integer
        <PreserveSig()> Function IsUsingDefaultDestination() As Integer
        <PreserveSig()> Function GetPreferredAspectRatio(ByRef plAspectX As Integer, ByRef plAspectY As Integer) As Integer
    End Interface

    <ComVisible(True), ComImport(), Guid("56a868b3-0ad4-11ce-b03a-0020af0ba770"), InterfaceType(ComInterfaceType.InterfaceIsDual)> _
    Public Interface IBasicAudio
        <PreserveSig()> Function put_Volume(ByVal lVolume As Integer) As Integer
        <PreserveSig()> Function get_Volume(ByRef plVolume As Integer) As Integer
        <PreserveSig()> Function put_Balance(ByVal lBalance As Integer) As Integer
        <PreserveSig()> Function get_Balance(ByRef plBalance As Integer) As Integer
    End Interface

    <ComVisible(True), ComImport(), Guid("56a868b6-0ad4-11ce-b03a-0020af0ba770"), InterfaceType(ComInterfaceType.InterfaceIsDual)> _
    Public Interface IMediaEvent
        <PreserveSig()> Function GetEventHandle(ByRef hEvent As IntPtr) As Integer
        <PreserveSig()> Function GetEvent(ByRef lEventCode As DirectShowEventCode, ByRef lParam1 As Integer, ByRef lParam2 As Integer, ByVal msTimeout As Integer) As Integer
        <PreserveSig()> Function WaitForCompletion(ByVal msTimeout As Integer, ByRef pEvCode As Integer) As Integer
        <PreserveSig()> Function CancelDefaultHandling(ByVal lEvCode As Integer) As Integer
        <PreserveSig()> Function RestoreDefaultHandling(ByVal lEvCode As Integer) As Integer
        <PreserveSig()> Function FreeEventParams(ByVal lEvCode As DirectShowEventCode, ByVal lParam1 As Integer, ByVal lParam2 As Integer) As Integer
    End Interface

    <ComVisible(True), ComImport(), Guid("56a868c0-0ad4-11ce-b03a-0020af0ba770"), InterfaceType(ComInterfaceType.InterfaceIsDual)> _
    Public Interface IMediaEventEx
#Region "IMediaEvent"
        <PreserveSig()> Function GetEventHandle(ByRef hEvent As IntPtr) As Integer
        <PreserveSig()> Function GetEvent(ByRef lEventCode As DirectShowEventCode, ByRef lParam1 As Integer, ByRef lParam2 As Integer, ByVal msTimeout As Integer) As Integer
        <PreserveSig()> Function WaitForCompletion(ByVal msTimeout As Integer, <Out()> ByRef pEvCode As Integer) As Integer
        <PreserveSig()> Function CancelDefaultHandling(ByVal lEvCode As Integer) As Integer
        <PreserveSig()> Function RestoreDefaultHandling(ByVal lEvCode As Integer) As Integer
        <PreserveSig()> Function FreeEventParams(ByVal lEvCode As DirectShowEventCode, ByVal lParam1 As Integer, ByVal lParam2 As Integer) As Integer
#End Region
        <PreserveSig()> Function SetNotifyWindow(ByVal hwnd As IntPtr, ByVal lMsg As Integer, ByVal lInstanceData As IntPtr) As Integer
        <PreserveSig()> Function SetNotifyFlags(ByVal lNoNotifyFlags As Integer) As Integer
        <PreserveSig()> Function GetNotifyFlags(ByRef lplNoNotifyFlags As Integer) As Integer
    End Interface

    <ComVisible(True), ComImport(), Guid("36b73880-c2c8-11cf-8b46-00805f6cef60"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)> _
    Public Interface IMediaSeeking
        <PreserveSig()> Function GetCapabilities(ByRef pCapabilities As SeekingCapabilities) As Integer
        <PreserveSig()> Function CheckCapabilities(<[In](), Out()> ByRef pCapabilities As SeekingCapabilities) As Integer
        <PreserveSig()> Function IsFormatSupported(<[In]()> ByRef pFormat As Guid) As Integer
        <PreserveSig()> Function QueryPreferredFormat(<Out()> ByRef pFormat As Guid) As Integer
        <PreserveSig()> Function GetTimeFormat(<Out()> ByRef pFormat As Guid) As Integer
        <PreserveSig()> Function IsUsingTimeFormat(<[In]()> ByRef pFormat As Guid) As Integer
        <PreserveSig()> Function SetTimeFormat(<[In]()> ByRef pFormat As Guid) As Integer
        <PreserveSig()> Function GetDuration(ByRef pDuration As Long) As Integer
        <PreserveSig()> Function GetStopPosition(ByRef pStop As Long) As Integer
        <PreserveSig()> Function GetCurrentPosition(ByRef pCurrent As Long) As Integer
        <PreserveSig()> Function ConvertTimeFormat(ByRef pTarget As Long, <[In]()> ByRef pTargetFormat As Guid, ByVal [Source] As Long, <[In]()> ByRef pSourceFormat As Guid) As Integer
        <PreserveSig()> Function SetPositions(<[In](), Out(), MarshalAs(UnmanagedType.LPStruct)> ByVal pCurrent As Int64, ByVal dwCurrentFlags As SeekingFlags, <[In](), Out(), MarshalAs(UnmanagedType.LPStruct)> ByVal pStop As Int64, ByVal dwStopFlags As SeekingFlags) As Integer
        <PreserveSig()> Function GetPositions(ByRef pCurrent As Long, ByRef pStop As Long) As Integer
        <PreserveSig()> Function GetAvailable(ByRef pEarliest As Long, ByRef pLatest As Long) As Integer
        <PreserveSig()> Function SetRate(ByVal dRate As Double) As Integer
        <PreserveSig()> Function GetRate(ByRef pdRate As Double) As Integer
        <PreserveSig()> Function GetPreroll(ByRef pllPreroll As Long) As Integer
    End Interface

    <ComVisible(True), ComImport(), Guid("93E5A4E0-2D50-11d2-ABFA-00A0C9C6E38D"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)> _
    Public Interface ICaptureGraphBuilder2
        <PreserveSig()> Function SetFiltergraph(<[In]()> ByVal pfg As IGraphBuilder) As Integer
        <PreserveSig()> Function GetFiltergraph(<Out()> ByRef ppfg As IGraphBuilder) As Integer
        <PreserveSig()> Function SetOutputFileName(<[In]()> ByRef pType As Guid, <[In](), MarshalAs(UnmanagedType.LPWStr)> ByVal lpstrFile As String, <Out()> ByRef ppbf As IBaseFilter, <Out()> ByRef ppSink As IFileSinkFilter) As Integer
        <PreserveSig()> Function FindInterface(<[In]()> ByRef pCategory As Guid, <[In]()> ByRef pType As Guid, <[In]()> ByVal pbf As IBaseFilter, <[In]()> ByRef riid As Guid, <Out(), MarshalAs(UnmanagedType.IUnknown)> ByRef ppint As Object) As Integer
        <PreserveSig()> Function RenderStream(<[In]()> ByRef pCategory As Guid, <[In]()> ByRef pType As Guid, <[In](), MarshalAs(UnmanagedType.IUnknown)> ByVal pSource As Object, <[In]()> ByVal pfCompressor As IBaseFilter, <[In]()> ByVal pfRenderer As IBaseFilter) As Integer
        <PreserveSig()> Function ControlStream(<[In]()> ByRef pCategory As Guid, <[In]()> ByRef pType As Guid, <[In]()> ByVal pFilter As IBaseFilter, <[In]()> ByVal pstart As IntPtr, <[In]()> ByVal pstop As IntPtr, <[In]()> ByVal wStartCookie As Short, <[In]()> ByVal wStopCookie As Short) As Integer
        <PreserveSig()> Function AllocCapFile(<[In](), MarshalAs(UnmanagedType.LPWStr)> ByVal lpstrFile As String, <[In]()> ByVal dwlSize As Long) As Integer
        <PreserveSig()> Function CopyCaptureFile(<[In](), MarshalAs(UnmanagedType.LPWStr)> ByVal lpwstrOld As String, <[In](), MarshalAs(UnmanagedType.LPWStr)> ByVal lpwstrNew As String, <[In]()> ByVal fAllowEscAbort As Integer, <[In]()> ByVal pFilter As IAMCopyCaptureFileProgress) As Integer
        <PreserveSig()> Function FindPin(<[In]()> ByVal pSource As Object, <[In]()> ByVal pindir As Integer, <[In]()> ByRef pCategory As Guid, <[In]()> ByRef pType As Guid, <[In](), MarshalAs(UnmanagedType.Bool)> ByVal fUnconnected As Boolean, <[In]()> ByVal num As Integer, <Out()> ByRef ppPin As IPin) As Integer
    End Interface

    <ComVisible(True), ComImport(), Guid("a2104830-7c70-11cf-8bce-00aa00a3f1a6"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)> _
    Public Interface IFileSinkFilter
        <PreserveSig()> Function SetFileName(<[In](), MarshalAs(UnmanagedType.LPWStr)> ByVal pszFileName As String, <[In](), MarshalAs(UnmanagedType.LPStruct)> ByVal pmt As AMMediaType) As Integer
        <PreserveSig()> Function GetCurFile(<Out(), MarshalAs(UnmanagedType.LPWStr)> ByRef pszFileName As String, <Out(), MarshalAs(UnmanagedType.LPStruct)> ByVal pmt As AMMediaType) As Integer
    End Interface

    <ComVisible(True), ComImport(), Guid("670d1d20-a068-11d0-b3f0-00aa003761c5"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)> _
    Public Interface IAMCopyCaptureFileProgress
        <PreserveSig()> Function Progress(ByVal iProgress As Integer) As Integer
    End Interface

#End Region

#Region "フィルタ関係"

    <ComVisible(True), ComImport(), Guid("56a86895-0ad4-11ce-b03a-0020af0ba770"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)> _
    Public Interface IBaseFilter
        'Inherits IPersist
        'Inherits IMediaControl
#Region "IPersist"
        <PreserveSig()> Function GetClassID(<Out()> ByRef pClassID As Guid) As Integer
#End Region
#Region "IMediaFilter"
        <PreserveSig()> Function [Stop]() As Integer
        <PreserveSig()> Function Pause() As Integer
        <PreserveSig()> Function Run(ByVal tStart As Long) As Integer
        <PreserveSig()> Function GetState(ByVal dwMilliSecsTimeout As Integer, <Out()> ByRef filtState As Integer) As Integer
        <PreserveSig()> Function SetSyncSource(<[In]()> ByVal pClock As IReferenceClock) As Integer
        <PreserveSig()> Function GetSyncSource(<Out()> ByRef pClock As IReferenceClock) As Integer
#End Region
        <PreserveSig()> Function EnumPins(<Out()> ByRef ppEnum As IEnumPins) As Integer
        <PreserveSig()> Function FindPin(<[In](), MarshalAs(UnmanagedType.LPWStr)> ByVal Id As String, <Out()> ByRef ppPin As IPin) As Integer
        <PreserveSig()> Function QueryFilterInfo(<Out()> ByVal pInfo As FILTER_INFO) As Integer
        <PreserveSig()> Function JoinFilterGraph(<[In]()> ByVal pGraph As IFilterGraph, <[In](), MarshalAs(UnmanagedType.LPWStr)> ByVal pName As String) As Integer
        <PreserveSig()> Function QueryVendorInfo(<Out(), MarshalAs(UnmanagedType.LPWStr)> ByRef pVendorInfo As String) As Integer
    End Interface

    <ComVisible(True), ComImport(), Guid("0000010c-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)> _
    Public Interface IPersist
        <PreserveSig()> Function GetClassID(<Out()> ByRef pClassID As Guid) As Integer
    End Interface

    <ComVisible(True), ComImport(), Guid("56a86899-0ad4-11ce-b03a-0020af0ba770"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)> _
    Public Interface IMediaFilter
        'Inherits IPersist
#Region "IPersist Methods"
        <PreserveSig()> Function GetClassID(<Out()> ByRef pClassID As Guid) As Integer
#End Region
        <PreserveSig()> Function [Stop]() As Integer
        <PreserveSig()> Function Pause() As Integer
        <PreserveSig()> Function Run(ByVal tStart As Long) As Integer
        <PreserveSig()> Function GetState(ByVal dwMilliSecsTimeout As Integer, ByRef filtState As Integer) As Integer
        <PreserveSig()> Function SetSyncSource(<[In]()> ByVal pClock As IReferenceClock) As Integer
        <PreserveSig()> Function GetSyncSource(<Out()> ByRef pClock As IReferenceClock) As Integer
    End Interface

    <ComVisible(True), ComImport(), Guid("56a86893-0ad4-11ce-b03a-0020af0ba770"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)> _
    Public Interface IEnumFilters
        <PreserveSig()> Function [Next](<[In]()> ByVal cFilters As Integer, <Out()> ByRef ppFilter As IBaseFilter, <Out()> ByRef pcFetched As Integer) As Integer
        <PreserveSig()> Function Skip(<[In]()> ByVal cFilters As Integer) As Integer
        Sub Reset()
        Sub Clone(<Out()> ByRef ppEnum As IEnumFilters)
    End Interface

    <ComVisible(True), ComImport(), Guid("C6E13340-30AC-11d0-A18C-00A0C9118956"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)> _
    Public Interface IAMStreamConfig
        <PreserveSig()> Function SetFormat(<[In](), MarshalAs(UnmanagedType.LPStruct)> ByVal pmt As AMMediaType) As Integer
        <PreserveSig()> Function GetFormat(<Out(), MarshalAs(UnmanagedType.LPStruct)> ByRef pmt As AMMediaType) As Integer
        <PreserveSig()> Function GetNumberOfCapabilities(ByRef piCount As Integer, ByRef piSize As Integer) As Integer
        <PreserveSig()> Function GetStreamCaps(ByVal iIndex As Integer, <Out(), MarshalAs(UnmanagedType.LPStruct)> ByRef ppmt As AMMediaType, ByVal pSCC As IntPtr) As Integer
    End Interface

    <ComVisible(True), ComImport(), Guid("56a8689a-0ad4-11ce-b03a-0020af0ba770"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)> _
    Public Interface IMediaSample
        <PreserveSig()> Function GetPointer(ByRef ppBuffer As IntPtr) As Integer
        <PreserveSig()> Function GetSize() As Integer
        <PreserveSig()> Function GetTime(ByRef pTimeStart As Long, ByRef pTimeEnd As Long) As Integer
        <PreserveSig()> Function SetTime(<[In](), MarshalAs(UnmanagedType.LPStruct)> ByVal pTimeStart As UInt64, <[In](), MarshalAs(UnmanagedType.LPStruct)> ByVal pTimeEnd As UInt64) As Integer
        <PreserveSig()> Function IsSyncPoint() As Integer
        <PreserveSig()> Function SetSyncPoint(<[In](), MarshalAs(UnmanagedType.Bool)> ByVal bIsSyncPoint As Boolean) As Integer
        <PreserveSig()> Function IsPreroll() As Integer
        <PreserveSig()> Function SetPreroll(<[In](), MarshalAs(UnmanagedType.Bool)> ByVal bIsPreroll As Boolean) As Integer
        <PreserveSig()> Function GetActualDataLength() As Integer
        <PreserveSig()> Function SetActualDataLength(ByVal len As Integer) As Integer
        <PreserveSig()> Function GetMediaType(<Out(), MarshalAs(UnmanagedType.LPStruct)> ByRef ppMediaType As AMMediaType) As Integer
        <PreserveSig()> Function SetMediaType(<[In](), MarshalAs(UnmanagedType.LPStruct)> ByVal pMediaType As AMMediaType) As Integer
        <PreserveSig()> Function IsDiscontinuity() As Integer
        <PreserveSig()> Function SetDiscontinuity(<[In](), MarshalAs(UnmanagedType.Bool)> ByVal bDiscontinuity As Boolean) As Integer
        <PreserveSig()> Function GetMediaTime(ByRef pTimeStart As Long, ByRef pTimeEnd As Long) As Integer
        <PreserveSig()> Function SetMediaTime(<[In](), MarshalAs(UnmanagedType.LPStruct)> ByVal pTimeStart As UInt64, <[In](), MarshalAs(UnmanagedType.LPStruct)> ByVal pTimeEnd As UInt64) As Integer
    End Interface


#End Region

#Region "ピン関係"

    <ComVisible(True), ComImport(), Guid("56a86891-0ad4-11ce-b03a-0020af0ba770"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)> _
    Public Interface IPin
        <PreserveSig()> Function Connect(<[In]()> ByVal pReceivePin As IPin, <[In](), MarshalAs(UnmanagedType.LPStruct)> ByVal pmt As AMMediaType) As Integer
        <PreserveSig()> Function ReceiveConnection(<[In]()> ByVal pReceivePin As IPin, <[In](), MarshalAs(UnmanagedType.LPStruct)> ByVal pmt As AMMediaType) As Integer
        <PreserveSig()> Function Disconnect() As Integer
        <PreserveSig()> Function ConnectedTo(<Out()> ByRef ppPin As IPin) As Integer
        <PreserveSig()> Function ConnectionMediaType(<Out(), MarshalAs(UnmanagedType.LPStruct)> ByVal pmt As AMMediaType) As Integer
        <PreserveSig()> Function QueryPinInfo(<Out()> ByVal pInfo As PIN_INFO) As Integer
        <PreserveSig()> Function QueryDirection(ByRef pPinDir As PinDirection) As Integer
        <PreserveSig()> Function QueryId(<Out(), MarshalAs(UnmanagedType.LPWStr)> ByRef Id As String) As Integer
        <PreserveSig()> Function QueryAccept(<[In](), MarshalAs(UnmanagedType.LPStruct)> ByVal pmt As AMMediaType) As Integer
        <PreserveSig()> Function EnumMediaTypes(ByVal ppEnum As IntPtr) As Integer
        <PreserveSig()> Function QueryInternalConnections(ByVal apPin As IntPtr, <[In](), Out()> ByRef nPin As Integer) As Integer
        <PreserveSig()> Function EndOfStream() As Integer
        <PreserveSig()> Function BeginFlush() As Integer
        <PreserveSig()> Function EndFlush() As Integer
        <PreserveSig()> Function NewSegment(ByVal tStart As Long, ByVal tStop As Long, ByVal dRate As Double) As Integer
    End Interface

    <ComVisible(True), ComImport(), Guid("56a86892-0ad4-11ce-b03a-0020af0ba770"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)> _
    Public Interface IEnumPins
        '        <PreserveSig()> Function [Next](<[In]()> ByVal cPins As Integer, <Out(), MarshalAs(UnmanagedType.LPArray, SizeParamIndex:=2)> ByRef ppPins() As IPin, <Out()> ByRef pcFetched As Integer) As Integer
        <PreserveSig()> Function [Next](<[In]()> ByVal cPins As Integer, <Out()> ByRef ppPins As IPin, <Out()> ByRef pcFetched As Integer) As Integer
        <PreserveSig()> Function Skip(<[In]()> ByVal cPins As Integer) As Integer
        Sub Reset()
        Sub Clone(<Out()> ByRef ppEnum As IEnumPins)
    End Interface

#End Region

#Region "その他"

#Region "IReferenceClock"
    <ComVisible(True), ComImport(), Guid("56a86897-0ad4-11ce-b03a-0020af0ba770"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)> _
    Public Interface IReferenceClock
        <PreserveSig()> Function GetTime(ByRef pTime As Long) As Integer
        <PreserveSig()> Function AdviseTime(ByVal baseTime As Long, ByVal streamTime As Long, ByVal hEvent As IntPtr, ByRef pdwAdviseCookie As Integer) As Integer
        <PreserveSig()> Function AdvisePeriodic(ByVal startTime As Long, ByVal periodTime As Long, ByVal hSemaphore As IntPtr, ByRef pdwAdviseCookie As Integer) As Integer
        <PreserveSig()> Function Unadvise(ByVal dwAdviseCookie As Integer) As Integer
    End Interface
#End Region

#End Region

#End Region

#Region "SampleGrabber関係"

    <ComVisible(True), ComImport(), Guid("6B652FFF-11FE-4fce-92AD-0266B5D7C78F"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)> _
    Public Interface ISampleGrabber
        <PreserveSig()> Function SetOneShot(<[In](), MarshalAs(UnmanagedType.Bool)> ByVal OneShot As Boolean) As Integer
        <PreserveSig()> Function SetMediaType(<[In](), MarshalAs(UnmanagedType.LPStruct)> ByVal pmt As AMMediaType) As Integer
        <PreserveSig()> Function GetConnectedMediaType(<Out(), MarshalAs(UnmanagedType.LPStruct)> ByVal pmt As AMMediaType) As Integer
        <PreserveSig()> Function SetBufferSamples(<[In](), MarshalAs(UnmanagedType.Bool)> ByVal BufferThem As Boolean) As Integer
        <PreserveSig()> Function GetCurrentBuffer(ByRef pBufferSize As Integer, ByVal pBuffer As IntPtr) As Integer
        <PreserveSig()> Function GetCurrentSample(ByVal ppSample As IntPtr) As Integer
        <PreserveSig()> Function SetCallback(ByVal pCallback As ISampleGrabberCB, ByVal WhichMethodToCallback As Integer) As Integer
    End Interface

    <ComVisible(True), ComImport(), Guid("0579154A-2B53-4994-B0D0-E773148EFF85"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)> _
    Public Interface ISampleGrabberCB
        <PreserveSig()> Function SampleCB(ByVal SampleTime As Double, ByVal pSample As IMediaSample) As Integer
        <PreserveSig()> Function BufferCB(ByVal SampleTime As Double, ByVal pBuffer As IntPtr, ByVal BufferLen As Integer) As Integer
    End Interface

#End Region



End Module



'//////////////////////////////////////////////////////////
'DirectShow以外の定義
'//////////////////////////////////////////////////////////
Public Module DirectShowDefineEx

#Region "定数定義"

    <Flags()> _
    Public Enum STREAM_SEEK
        STREAM_SEEK_SET = 0
        STREAM_SEEK_CUR = 1
        STREAM_SEEK_END = 2
    End Enum
    <Flags()> _
    Public Enum STGTY
        STGTY_STORAGE = 1
        STGTY_STREAM = 2
        STGTY_LOCKBYTES = 3
        STGTY_PROPERTY = 4
    End Enum
    <Flags()> _
    Public Enum STGMOVE
        STGMOVE_MOVE = 0
        STGMOVE_COPY = 1
    End Enum
    <Flags()> _
    Public Enum STGM
        STGM_READ = &H0
        STGM_WRITE = &H1
        STGM_READWRITE = &H2
        STGM_SHARE_DENY_NONE = &H40
        STGM_SHARE_DENY_READ = &H30
        STGM_SHARE_DENY_WRITE = &H20
        STGM_SHARE_EXCLUSIVE = &H10
        STGM_PRIORITY = &H40000
        STGM_CREATE = &H1000
        STGM_CONVERT = &H20000
        STGM_FAILIFTHERE = &H0
        STGM_DIRECT = &H0
        STGM_TRANSACTED = &H10000
        STGM_NOSCRATCH = &H100000
        STGM_NOSNAPSHOT = &H200000
        STGM_SIMPLE = &H8000000
        STGM_DIRECT_SWMR = &H400000
        STGM_DELETEONRELEASE = &H4000000
    End Enum
    <Flags()> _
    Public Enum STGFMT
        STGFMT_STORAGE = 0
        STGFMT_FILE = 3
        STGFMT_ANY = 4
        STGFMT_DOCFILE = 5
    End Enum
    <Flags()> _
    Public Enum STGC
        STGC_DEFAULT = 0
        STGC_OVERWRITE = 1
        STGC_ONLYIFCURRENT = 2
        STGC_DANGEROUSLYCOMMITMERELYTODISKCACHE = 4
        STGC_CONSOLIDATE = 8
    End Enum
    <Flags()> _
    Public Enum STATFLAG
        STATFLAG_DEFAULT = 0
        STATFLAG_NONAME = 1
    End Enum
    <Flags()> _
    Public Enum LOCKTYPE
        LOCK_WRITE = 1
        LOCK_EXCLUSIVE = 2
        LOCK_ONLYONCE = 4
    End Enum
    <Flags()> _
    Public Enum PROPSETFLAG
        PROPSETFLAG_DEFAULT = 0
        PROPSETFLAG_NONSIMPLE = 1
        PROPSETFLAG_ANSI = 2
        PROPSETFLAG_UNBUFFERED = 4
        PROPSETFLAG_CASE_SENSITIVE = 8
    End Enum

#End Region

#Region "構造体定義"

    <StructLayout(LayoutKind.Sequential), ComVisible(False)> _
    Public Structure CAUUID
        Public cElems As Integer
        Public pElems As IntPtr
    End Structure

#End Region

#Region "インターフェース定義"

    <ComImport(), Guid("0000000d-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)> _
    Public Interface IEnumSTATSTG
        <PreserveSig()> Function [Next](<[In]()> ByVal celt As System.UInt32, <Out(), MarshalAs(UnmanagedType.LPArray, SizeParamIndex:=0)> ByVal rgelt() As ComTypes.STATSTG, <Out()> ByRef pceltFetched As System.UInt32) As Integer
        <PreserveSig()> Function Skip(<[In]()> ByVal celt As System.UInt32) As Integer
        <PreserveSig()> Function Reset() As Integer
        <PreserveSig()> Function Clone(<Out()> ByRef ppenum As IEnumSTATSTG) As Integer
    End Interface

    <ComImport(), Guid("0000000b-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)> _
    Public Interface IStorage
        <PreserveSig()> Function CreateStream(<[In](), MarshalAs(UnmanagedType.LPWStr)> ByVal wcsName As String, <[In](), MarshalAs(UnmanagedType.U4)> ByVal grfMode As STGM, <[In](), MarshalAs(UnmanagedType.U4)> ByVal reserved1 As System.UInt32, <[In](), MarshalAs(UnmanagedType.U4)> ByVal reserved2 As System.UInt32, <Out(), MarshalAs(UnmanagedType.Interface)> ByRef ppstg As ComTypes.IStream) As Integer
        <PreserveSig()> Function OpenStream(<[In](), MarshalAs(UnmanagedType.LPWStr)> ByVal wcsName As String, <[In]()> ByVal reserved1 As IntPtr, <[In](), MarshalAs(UnmanagedType.U4)> ByVal grfMode As STGM, <[In]()> ByVal reserved2 As System.UInt32, <Out(), MarshalAs(UnmanagedType.Interface)> ByRef ppstg As ComTypes.IStream) As Integer
        <PreserveSig()> Function CreateStorage(<MarshalAs(UnmanagedType.LPWStr)> ByVal pwcsName As String, <[In](), MarshalAs(UnmanagedType.U4)> ByVal grfMode As STGM, <[In](), MarshalAs(UnmanagedType.U4)> ByVal reserved1 As System.UInt32, <[In](), MarshalAs(UnmanagedType.U4)> ByVal reserved2 As System.UInt32, <Out(), MarshalAs(UnmanagedType.Interface)> ByRef ppstg As IStorage) As Integer
        <PreserveSig()> Function OpenStorage(<[In](), MarshalAs(UnmanagedType.LPWStr)> ByVal wcsName As String, <[In]()> ByVal stgPriority As IntPtr, <[In](), MarshalAs(UnmanagedType.U4)> ByVal grfMode As STGM, <[In]()> ByVal snbExclude As IntPtr, <[In]()> ByVal reserved As System.UInt32, <Out(), MarshalAs(UnmanagedType.Interface)> ByRef ppstg As IStorage) As Integer
        <PreserveSig()> Function CopyTo(<[In](), MarshalAs(UnmanagedType.U4)> ByVal ciidExclude As Integer, <[In](), MarshalAs(UnmanagedType.LPArray, SizeParamIndex:=0)> ByVal rgiidExclude() As Guid, <[In]()> ByVal snbExclude As IntPtr, <[In](), MarshalAs(UnmanagedType.Interface)> ByVal pstgDest As IStorage) As Integer
        <PreserveSig()> Function MoveElementTo(<[In](), MarshalAs(UnmanagedType.LPWStr)> ByVal wcsName As String, <[In](), MarshalAs(UnmanagedType.Interface)> ByVal stgDest As IStorage, <[In](), MarshalAs(UnmanagedType.LPWStr)> ByVal wcsNewName As String, <[In](), MarshalAs(UnmanagedType.U4)> ByVal grfFlags As STGMOVE) As Integer
        <PreserveSig()> Function Commit(<[In](), MarshalAs(UnmanagedType.U4)> ByVal grfCommitFlags As STGC) As Integer
        <PreserveSig()> Function Revert() As Integer
        <PreserveSig()> Function EnumElements(<[In]()> ByVal reserved1 As System.UInt32, <[In]()> ByVal reserved2 As IntPtr, <[In]()> ByVal reserved3 As System.UInt32, <Out(), MarshalAs(UnmanagedType.Interface)> ByRef ppenum As IEnumSTATSTG) As Integer
        <PreserveSig()> Function DestroyElement(<[In](), MarshalAs(UnmanagedType.LPWStr)> ByVal wcsName As String) As Integer
        <PreserveSig()> Function RenameElement(<[In](), MarshalAs(UnmanagedType.LPWStr)> ByVal wcsOldName As String, <[In](), MarshalAs(UnmanagedType.LPWStr)> ByVal wcsNewName As String) As Integer
        <PreserveSig()> Function SetElementTimes(<[In](), MarshalAs(UnmanagedType.LPWStr)> ByVal wcsName As String, <[In]()> ByRef ctime As ComTypes.FILETIME, <[In]()> ByRef atime As ComTypes.FILETIME, <[In]()> ByRef mtime As ComTypes.FILETIME) As Integer
        <PreserveSig()> Function SetClass(<[In]()> ByRef clsid As Guid) As Integer
        <PreserveSig()> Function SetStateBits(<[In](), MarshalAs(UnmanagedType.U4)> ByVal grfStateBits As System.UInt32, <[In](), MarshalAs(UnmanagedType.U4)> ByVal grfMask As System.UInt32) As Integer
        <PreserveSig()> Function Stat(<[In]()> ByRef statstg As ComTypes.STATSTG, <[In](), MarshalAs(UnmanagedType.U4)> ByVal grfStatFlag As STATFLAG) As Integer
    End Interface

    <InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("0000010c-0000-0000-C000-000000000046")> _
    Public Interface IPersist
        Sub GetClassID(ByRef pClassID As Guid)
    End Interface

    <InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("00000109-0000-0000-C000-000000000046")> _
    Public Interface IPersistStream
        Inherits IPersist
        Shadows Sub GetClassID(ByRef pClassID As Guid)

        <PreserveSig()> Function IsDirty() As Integer
        <PreserveSig()> Sub Load(<[In]()> ByVal pStm As ComTypes.IStream)
        <PreserveSig()> Sub Save(<[In]()> ByVal pStm As ComTypes.IStream, <[In](), MarshalAs(UnmanagedType.Bool)> ByVal fClearDirty As Boolean)
        <PreserveSig()> Sub GetSizeMax(ByRef pcbSize As Long)
    End Interface

    <ComVisible(True), ComImport(), Guid("B196B28B-BAB4-101A-B69C-00AA00341D07"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)> _
    Public Interface ISpecifyPropertyPages
        <PreserveSig()> Function GetPages(ByRef pPages As CAUUID) As Integer
    End Interface

    <ComVisible(True), ComImport(), Guid("29840822-5B84-11D0-BD3B-00A0C911CE86"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)> _
    Public Interface ICreateDevEnum
        <PreserveSig()> Function CreateClassEnumerator(<[In]()> ByRef pType As Guid, <Out()> ByRef ppEnumMoniker As ComTypes.IEnumMoniker, <[In]()> ByVal dwFlags As Integer) As Integer
    End Interface

    <ComVisible(True), ComImport(), Guid("55272A00-42CB-11CE-8135-00AA004BB851"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)> _
    Public Interface IPropertyBag
        <PreserveSig()> Function Read(<MarshalAs(UnmanagedType.LPWStr)> ByVal PropName As String, ByRef Var As Object, ByVal ErrorLog As Integer) As Integer
        <PreserveSig()> Function Write(ByVal PropName As String, ByRef Var As Object) As Integer
    End Interface

#End Region

#Region "API"

    Public Class Win32API

        <DllImport("ole32.dll")> _
        Friend Shared Function StgCreateDocfile(<MarshalAs(UnmanagedType.LPWStr)> ByVal wcsName As String, <[In](), MarshalAs(UnmanagedType.U4)> ByVal grfMode As STGM, ByVal reserved As System.UInt32, <MarshalAs(UnmanagedType.Interface)> ByRef stgOpen As IStorage) As Integer
        End Function

        <DllImport("Ole32.dll"), PreserveSig()> _
        Public Shared Function StgOpenStorage(<MarshalAs(UnmanagedType.LPWStr)> ByVal pwcsName As String, ByVal pstgPriority As IStorage, ByVal grfMode As STGM, ByVal snbExclude As IntPtr, ByVal reserved As Integer, <MarshalAs(UnmanagedType.Interface)> ByRef storage As IStorage) As Integer
        End Function

        <DllImport("Ole32.dll"), PreserveSig()> _
        Public Shared Function StgIsStorageFile(<MarshalAs(UnmanagedType.LPWStr)> ByVal pwcsName As String) As Integer
        End Function

        <DllImport("olepro32.dll", CharSet:=CharSet.Unicode, ExactSpelling:=True)> _
        Public Shared Function OleCreatePropertyFrame(ByVal hwndOwner As IntPtr, ByVal x As Integer, ByVal y As Integer, ByVal lpszCaption As String, ByVal cObjects As Integer, <[In](), MarshalAs(UnmanagedType.Interface)> ByRef ppUnk As Object, ByVal cPages As Integer, ByVal pPageClsID As IntPtr, ByVal lcid As Integer, ByVal dwReserved As Integer, ByVal pvReserved As IntPtr) As Integer
        End Function

        <DllImport("KERNEL32")> _
        Public Shared Function WaitForSingleObject(ByVal handle As IntPtr, ByVal timeOut As Integer) As Integer
        End Function

    End Class

#End Region

End Module
