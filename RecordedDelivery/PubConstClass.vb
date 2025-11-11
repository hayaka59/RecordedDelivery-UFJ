Public Class PubConstClass

#Region "送信コマンド定義"
    Public Const CMD_ACK As String = "Za"       ' 通信確認コマンド
    Public Const CMD_START As String = "Zt"     ' 作動コマンド
    Public Const CMD_STOP As String = "Zp"      ' 停止要求
    Public Const CMD_SETINFO As String = "Zs"   ' 区分け通数コマンド
    Public Const CMD_DISABLE As String = "Zf"   ' 動作不可コマンド
    Public Const CMD_ENABLE As String = "Zd"    ' 動作可能コマンド
    Public Const CMD_RESET As String = "Zr"     ' エラーリセットコマンド
    Public Const CMD_SNAP_OK As String = "Zc"   ' 画像読取完了コマンド
    Public Const CMD_LED_OFF As String = "Zl0"
    Public Const CMD_LED_OK As String = "Zl1"

    Public Const CMD_SEND_b As String = "Zb"    ' 設定情報の送信コマンド
    Public Const CMD_SEND_h As String = "Zh"    ' 設定要求コマンド
    Public Const CMD_SEND_j As String = "Zj"    ' 1通処理コマンド
    Public Const CMD_SEND_k As String = "Zk"    ' 手差処理コマンド
    Public Const CMD_SEND_r As String = "Zr"    ' リセットコマンド
    Public Const CMD_SEND_g As String = "Zg"    ' 引受番号の範囲情報送信コマンド

    Public Const CMD_SEND_e As String = "Ze"    ' カメラ調整コマンド（ストッパーとLED照明ＯＮ）
    Public Const CMD_SEND_i As String = "Zi"    ' ラベラー試張りコマンド（テスト文字を印字）
    Public Const CMD_SEND_n As String = "Zn"    ' 区分けコマンド
    Public Const CMD_SEND_m As String = "Zm"    ' メンテナンスモード（1：メンテナンスモード／0：通常モード）
    Public Const CMD_SEND_o As String = "Zo"    ' 照合エラー
    Public Const CMD_SEND_q As String = "Zq"    ' q001：定形／q002：定形外

#End Region

#Region "受信コマンド定義"

#End Region

#Region "定数定義"
    ''' <summary> バージョン情報</summary>
    Public Const DEF_VERSION = "Ver.0.11.1.1（大型機）"
    ''' <summary> 暗号化用オープンキー</summary>
    Public Const DEF_OPEN_KEY = "SSKINOSHITASS"
    Public Const USR_JOB_NAME As String = "業務名"
    Public Const USR_COMMENT As String = "コメント"
    Public Const USR_KIND As String = "種別"
    Public Const USR_TEIKEI As String = "定形"
    Public Const USR_RECEIPT As String = "受領書印刷"
    Public Const USR_ORIGINAL As String = "原符自動印刷"
    Public Const USR_RESERVE As String = "控え自動印刷"
    Public Const USR_NGSTOPCNT As String = "停止ＮＧ回数"
    Public Const USR_ADRESS1 As String = "差出人住所１"
    Public Const USR_ADRESS2 As String = "差出人住所２"
    Public Const USR_NAME As String = "差出人氏名"
    Public Const USR_POSTNAME As String = "承認局名"
    Public Const USR_TEKIYOU As String = "摘要"
    Public Const USR_YOUSYOUGAKU As String = "要償額"
    Public Const USR_FEEDER_POS_V As String = "フィーダー位置垂直"
    Public Const USR_LABEL_POS_V As String = "ラベル貼付位置垂直"
    Public Const USR_LABEL_POS_H As String = "ラベル貼付位置水平"
    Public Const USR_ADDRESS_POS_V As String = "宛名撮像位置垂直"
    Public Const USR_ADDRESS_POS_H As String = "宛名撮像位置水平"
    Public Const USR_POSITIVE_DIRECTION As String = "正方向流し"
#End Region

#Region "内部ファイル名称定義"
    ''' <summary> 種別名格納ファイル</summary>
    Public Const DEF_CLASS_FILE_NAME = "ClassFile.ini"
    ''' <summary> オペレータ情報ファイル</summary>
    Public Const DEF_OPERATOR_FILE_NAME_ENC = "Operator.enc"
    Public Const DEF_OPERATOR_FILE_NAME_INI = "Operator.ini"
    ''' <summary> DEFファイル名称</summary>
    Public Const DEF_FILENAME = "RecordedDelivery.def"
    Public Const DEF_INI_FILENAME = "RecordedDelivery.ini"
    ''' <summary> 引受番号格納ファイル</summary>
    Public Const DEF_UNDER_WRITING_NUMBER = "UnderWritingNumber.ini"
    ''' <summary> 支店マスタファイル</summary>
    Public Const DEF_BRANCH_MASTER = "BranchMaster.ini"
#End Region

#Region "メンテナンス画面定数定義"
    Public Const DEF_USERNO As String = "ユーザー番号"
    Public Const DEF_PASS_USE_PERIOD As String = "パスワード有効期間"
    Public Const DEF_KUWAKE_CNT As String = "区分通数"
    Public Const DEF_TRIGER As String = "トリガータイム"
    Public Const DEF_TRNFOLDERPATH As String = "稼働ログ保存フォルダ"
    Public Const DEF_IMGFOLDERPATH As String = "画像ログ保存フォルダ"
    Public Const DEF_HEADER_1PAGE As String = "ヘッダー１頁"
    Public Const DEF_HEADER_2PAGE As String = "ヘッダー２頁"
    Public Const DEF_FOOTER_1ROW As String = "フッター１"
    Public Const DEF_FOOTER_2ROW As String = "フッター２"
#End Region

    '// 2015.12.14 Ver.B04 hayakawa 追加↓ここから
#Region "メイン画面グローバル変数"
    Public Shared pblUsed30FromUnderWrittingNumber As Double    ' 使用済み引受番号（簡易書留）のFROM
    Public Shared pblUsed30ToUnderWrittingNumber As Double      ' 使用済み引受番号（簡易書留）のTO
    Public Shared pblUsed50FromUnderWrittingNumber As Double    ' 使用済み引受番号（特定記録）のFROM
    Public Shared pblUsed50ToUnderWrittingNumber As Double      ' 使用済み引受番号（特定記録）のTO
    Public Shared pblUsed150FromUnderWrittingNumber As Double   ' 使用済み引受番号（ゆうメール）のFROM
    Public Shared pblUsed150ToUnderWrittingNumber As Double     ' 使用済み引受番号（ゆうメール）のTO
    Public Shared pblUsed70FromUnderWrittingNumber As Double    '【今回追加分】使用済み引受番号（書留）のFROM
    Public Shared pblUsed70ToUnderWrittingNumber As Double      '【今回追加分】使用済み引受番号（書留）のTO

    ' 引受番号が一周した時の格納変数
    Public Shared pblUsed30FromUnderWrittingNumber2 As Double   ' 
    Public Shared pblUsed30ToUnderWrittingNumber2 As Double     ' 
    Public Shared pblUsed50FromUnderWrittingNumber2 As Double   ' 
    Public Shared pblUsed50ToUnderWrittingNumber2 As Double     ' 
    Public Shared pblUsed150FromUnderWrittingNumber2 As Double  ' 
    Public Shared pblUsed150ToUnderWrittingNumber2 As Double    ' 
    Public Shared pblUsed70FromUnderWrittingNumber2 As Double   '【今回追加分】
    Public Shared pblUsed70ToUnderWrittingNumber2 As Double     '【今回追加分】

    Public Shared blnIsOneRound30Flg As Boolean
    Public Shared blnIsOneRound50Flg As Boolean
    Public Shared blnIsOneRound150Flg As Boolean
    Public Shared blnIsOneRound70Flg As Boolean                 '【今回追加分】
#End Region
    '// 2015.12.14 Ver.B04 hayakawa 追加↑ここまで

    Public Shared sClassGroupList As New List(Of String)()

#Region "ログイン画面グローバル変数"
    ''' <summary> ログインオペレータコード</summary>
    Public Shared pblOperatorCode As String
    ''' <summary> ログインオペレータ名称</summary>
    Public Shared pblOperatorName As String
    ''' <summary> オペレータ登録日</summary>
    Public Shared pblOperatorEntryDate As String
    ''' <summary> オペレータ権限</summary>
    Public Shared pblOperatorAuthorityh As String
#End Region

#Region "支店選択画面グローバル変数"
    Public Shared pblTranDate As String             ' 処理日
    Public Shared pblSitenCode As String            ' 支店コード
    Public Shared pblSitenName As String            ' 支店名
    Public Shared pblClassForSiten As String        ' 種別
    Public Shared pblTranYoteiCount As String       ' 処理予定数
    Public Shared pblPrintCountPerPage As String    ' 受領証面数設定（0：15面／1：8面）
#End Region

#Region "業務登録画面グローバル変数"
    Public Shared strPubJobName As String           ' 業務名称
    Public Shared strPubComment As String           ' コメント
    Public Shared strPubKind As String              ' 種別
    Public Shared strPubTeikei As String            ' 0：定形／1：定形外
    Public Shared strPubAddress1 As String          ' 差出人住所１
    Public Shared strPubAddress2 As String          ' 差出人住所２
    Public Shared strPubName As String              ' 差出人
    Public Shared strPubPostName As String          ' 承認局名
    Public Shared strPubTekiyou As String           ' 摘要
    Public Shared strPubYousyougaku As String       ' 要償額
    Public Shared strPubFeederPosV As String        ' フィーダー位置（垂直方向）
    Public Shared strPubLabelPosV As String         ' ラベル位置（垂直方向）
    Public Shared strPubLabelPosH As String         ' ラベル位置（水平方向）
    Public Shared strPubAddressPosV As String       ' 宛名撮像位置（垂直方向）
    Public Shared strPubAddressPosH As String       ' 宛名撮像位置（水平方向）

    Public Shared strPubPositiveDirection As String ' 正方向流し

    Public Shared strPubReceipt As String           ' 受領書印刷
    Public Shared strPubOriginal As String          ' 原符自動印刷
    Public Shared strPubReserve As String           ' 控え自動印刷
    Public Shared blnIsErrorGamen As Boolean        ' エラー画面表示フラグ

#End Region

#Region "メンテナンス画面グローバル変数"
    Public Shared userNumber As String              ' ユーザー番号
    Public Shared passUsePeriod As String           ' パスワード有効期間
    Public Shared pblKuwakeCnt As String            ' 区分通数
    Public Shared trigerTime As String              ' トリガータイム
    Public Shared tranPath As String                ' 稼働ファイル保存フォルダ
    Public Shared imgPath As String                 ' 画像ファイル保存フォルダ
    Public Shared pblHeder1Page As String           ' ヘッダー１頁（差出票）
    Public Shared pblHeder2Page As String           ' ヘッダー２頁（受領証）
    Public Shared pblFooter1 As String              ' フッター１
    Public Shared pblFooter2 As String              ' フッター２
    Public Shared pblMachineName As String          ' 号機名
    Public Shared pblSenderAddress1 As String       ' 差出人住所１
    Public Shared pblSenderAddress2 As String       ' 差出人住所２
    Public Shared pblSenderName As String           ' 差出人氏名

    Public Shared objSyncRec As Object
    Public Shared strRecData As String

    ' 「番号帯の中でのスタート番号」は引受番号管理グローバル変数を使用する
#End Region

#Region "引受番号管理グローバル変数"
    Public Shared strNumberInfo(4) As String        ' 引受番号帯コードと種別（表示用）
    Public Shared strStartNumber(4) As String       ' 開始番号
    Public Shared strEndNumber(4) As String         ' 終了番号
    Public Shared strCurrentNumber(4) As String     ' 番号帯の中でのスタート番号
#End Region

#Region "種別マスターグローバル変数"
    Public Shared strWeightArray(9) As String       ' 種別単位の重量格納配列（定形）
    Public Shared strPriceArray(9) As String        ' 種別単位の料金格納配列（定形）
    Public Shared strWeightGaiArray(8) As String    ' 種別単位の重量格納配列（定形外／規格内）
    Public Shared strPriceGaiArray(8) As String     ' 種別単位の料金格納配列（定形外／規格内）
    Public Shared strWeightNonSArray(8) As String   ' 種別単位の重量格納配列（定形外／規格外）
    Public Shared strPriceNonSArray(8) As String    ' 種別単位の料金格納配列（定形外／規格外）

#End Region

#Region "運転画面グローバル変数"
    Public Shared dblStartUnderWritingNumber As Double  ' 運転時の引受番号
    Public Shared dblFirstUnderWritingNumber As Double  ' 開始引受番号
    Public Shared dblEndUnderWritingNumber As Double    ' 終了引受番号

    Public Shared arListForPrint As ArrayList           ' 印刷用アレイリスト
    Public Shared intDeviceIdnex As Integer             ' デバイスインデックス（カメラ用）
    Public Shared intFormatIndex As Integer             ' フォーマットインデックス（カメラ用）
    Public Shared strLogArrayList(5, 3) As String       ' ログデータ管理用配列（引受番号／画像保存ファイル名／測定重量）
    Public Shared intLogArrayListIndex As Integer       ' ログデータ管理用配列インデックス
    Public Shared objSyncHist As Object                 ' 操作履歴用の SyncLock ステートメント
    Public Shared imageWinWidth As Integer              ' 静止画像表示用イメージウィンドウの横サイズ
    Public Shared imageWinHeight As Integer             ' 静止画像表示用イメージウィンドウの縦サイズ

    Public Shared strWorkDay As String = 0              ' 作業日
    Public Shared intTodayALLCount As Integer = 0       ' 当日累計
    Public Shared intKaniALLCount As Integer = 0        ' 簡易書留累計
    Public Shared intTokuALLCount As Integer = 0        ' 特定郵便累計
    Public Shared intMailALLCount As Integer = 0        ' ゆうメール累計

#End Region

#Region "データ確認・抜取りグローバル変数"
    Public Shared strJobDataFileName As String          ' 編集するJOBデータファイル名称
#End Region

#Region "作業日報印刷用グローバル変数"
    Public Shared strMinUdrWrtKan As String             ' 引受番号（簡易書留）の最小値
    Public Shared strMaxUdrWrtKan As String             ' 引受番号（簡易書留）の最大値
    Public Shared intTranCountKan As Integer            ' 処理数（簡易書留）ログの件数
    Public Shared intUdrWrtDupIndexKan As Integer       ' 重複した引受番号（簡易書留）の数
    Public Shared intUdrWrtNukiIndexKan As Integer      ' 抜取した引受番号（簡易書留）の数
    Public Shared strDupUdrWrtNumKan(1000) As String    ' 重複引受番号（簡易書留）
    Public Shared strNukUdrWrtNumKan(1000) As String    ' 抜取引受番号（簡易書留）

    Public Shared arHikiukeKanList As ArrayList         ' 簡易書留用の処理した引受番号を格納するアレイリスト
    Public Shared arHikiukeTokList As ArrayList         ' 特定記録用の処理した引受番号を格納するアレイリスト
    Public Shared arHikiukeYouList As ArrayList         ' ゆうメール用の処理した引受番号を格納するアレイリスト

    Public Shared strMinUdrWrtTok As String             ' 引受番号（特定記録）の最小値
    Public Shared strMaxUdrWrtTok As String             ' 引受番号（特定記録）の最大値
    Public Shared intTranCountTok As Integer            ' 処理数（特定記録）ログの件数
    Public Shared intUdrWrtDupIndexTok As Integer       ' 重複した引受番号（特定記録）の数
    Public Shared intUdrWrtNukiIndexTok As Integer      ' 抜取した引受番号（特定記録）の数
    Public Shared strDupUdrWrtNumTok(1000) As String    ' 重複引受番号（特定記録）
    Public Shared strNukUdrWrtNumTok(1000) As String    ' 抜取引受番号（特定記録）

    Public Shared strMinUdrWrtYou As String             ' 引受番号（ゆうメール）の最小値
    Public Shared strMaxUdrWrtYou As String             ' 引受番号（ゆうメール）の最大値
    Public Shared intTranCountYou As Integer            ' 処理数（ゆうメール）ログの件数
    Public Shared intUdrWrtDupIndexYou As Integer       ' 重複した引受番号（ゆうメール）の数
    Public Shared intUdrWrtNukiIndexYou As Integer      ' 抜取した引受番号（ゆうメール）の数
    Public Shared strDupUdrWrtNumYou(1000) As String    ' 重複引受番号（ゆうメール）
    Public Shared strNukUdrWrtNumYou(1000) As String    ' 抜取引受番号（ゆうメール）

    Public Shared lngLoopCntKan As Long                 ' 作業日報（簡易書留）（重複件数用）ループカウンタ
    Public Shared lngLoopCntKanNuk As Long              ' 作業日報（簡易書留）（抜取件数用）ループカウンタ
    Public Shared lngLoopCntTok As Long                 ' 作業日報（特定記録）（重複件数用）ループカウンタ
    Public Shared lngLoopCntTokNuk As Long              ' 作業日報（特定記録）（抜取件数用）ループカウンタ
    Public Shared lngLoopCntYou As Long                 ' 作業日報（ゆうメール）（重複件数用）ループカウンタ
    Public Shared lngLoopCntYouNuk As Long              ' 作業日報（ゆうメール）（抜取件数用）ループカウンタ

    Public Shared blnIsDispKan As Boolean
    Public Shared blnIsDispKanNuk As Boolean

    Public Shared blnIsDispTok As Boolean
    Public Shared blnIsDispTokNuk As Boolean

    Public Shared blnIsDispYou As Boolean
    Public Shared blnIsDispYouNuk As Boolean

    ' 今回は多分使用しない↓ここから
    Public Shared strMinReceiptNum As String            ' 引受番号の最小値
    Public Shared strMaxReceiptNum As String            ' 引受番号の最大値
    Public Shared intReceiptDupIndex As Integer         ' 重複した引受番号の数
    Public Shared intReceiptDispDupIndex As Integer     ' 重複した引受番号の数（印刷用）
    Public Shared strDupReceiptNum(1000) As String      ' 重複引受番号
    ' 今回は多分使用しない↑ここまで
#End Region

#Region "制御コード"
    ''' <summary> ENQ(ステータス要求コマンド)</summary>
    Public Const ENQ As Byte = &H5
    ''' <summary> ACK</summary>
    Public Const ACK As Byte = &H6
    ''' <summary> NAK</summary>
    Public Const NAK As Byte = &H15
    ''' <summary> CAN(キャンセルコマンド)</summary>
    Public Const CAN As Byte = &H18
    ''' <summary> STX</summary>
    Public Const STX As Byte = &H2
    ''' <summary> ETX</summary>
    Public Const ETX As Byte = &H3
    ''' <summary> ESC</summary>
    Public Const ESC As Byte = &H1B
#End Region

#Region "印刷用グローバル変数"
    Public Shared intTranALLCnt As Integer              ' 通数の合計
    Public Shared intAmountALL As Integer               ' 合計金額の合計
    Public Shared strTranCnt(9) As String               ' 通数（定形）
    Public Shared strAmount(9) As String                ' 合計金額（定形）
    Public Shared strTranCntGai(8) As String            ' 通数（定形外／規格内）
    Public Shared strAmountGai(8) As String             ' 合計金額（定形外／規格内）
    Public Shared strTranCntNonS(8) As String           ' 通数（定形外／規格外）
    Public Shared strAmountNonS(8) As String            ' 合計金額（定形外／規格外）
    Public Shared arPrePrintData As New ArrayList       ' 印字データ作成用アレイリスト
    Public Shared arPrintData As New ArrayList          ' 印字データ用アレイリスト
#End Region

    Public Shared pblOperatorArray(2000) As String  ' オペレータ情報格納配列
    Public Shared pblOperatorArrayIndex As Integer  ' オペレータ情報格納インデックス

    Public Shared pblIsOkayFlag As Boolean          ' ＯＫフラグ

    Public Shared pblBranchArray(1000) As String    ' 支店データ格納配列
    Public Shared pblBranchIndex As Integer         ' 支店データ格納インデックス

    Public Shared pblClassData(50) As String        ' 種別データ格納配列
    Public Shared pblClassDataIndex As Integer      ' 種別データインデックス

    ' 印字用
    Public Shared strUseLogArray(10000) As String   ' 運用記録リスト用配列（60行／1頁）≒166頁
    Public Shared lngLoopCnt As Long
    Public Shared lngPrintIndex As Long             ' 印刷インデックス（ページ情報）

    Public Shared lngPrintIndexKan As Long
    Public Shared lngPrintIndexTok As Long
    Public Shared lngPrintIndexYou As Long
    Public Shared lngPrintIndexKanNuk As Long
    Public Shared lngPrintIndexTokNuk As Long
    Public Shared lngPrintIndexYouNuk As Long

    Public Shared intPrintFuncNo As Integer         ' 印刷機能番号

    Public Shared lngRePrintIndex As Long           ' 再印刷インデックス（ページ情報）
    Public Shared lngPrintIndexReserve As Long      ' 控え用
    Public Shared lngImageDataCount As Long         ' 再印刷イメージ画像数
    Public Shared blnRePrintFlg As Boolean          ' 受領書再発行フラグ
    Public Shared strReceiptNum(10000) As String    ' 処理した引受番号（）格納配列
    Public Shared lngReceiptIndex As Long           ' 処理した受領書（）の数

    Public Shared intPrintStatus As Integer         ' プリントステータス（0：なし／1：原符のみ／2：控えのみ／3：原符と控え／4：処理データ）
    Public Shared intReceiptKind As Integer         ' 受領書の種類（0：差出票／1：受領証）

    ' 日付設定画面用
    Public Shared strSetDateValue As String         ' 日付データ格納（【形式】YYYY/MM/DD hh:mm:ss）

    ' エラーメッセージ画面
    Public Shared strErrorNo As String              ' エラー番号（3桁）
    Public Shared strErrArray(255) As String        ' エラーメッセージ格納配列
    Public Shared intErrCnt As Integer              ' エラーの数
    Public Shared blnResetFlg As Boolean            ' エラーリセット送信フラグ

End Class
