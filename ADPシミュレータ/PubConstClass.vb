Public Class PubConstClass

    ' 送信コマンド
    Public Const CMD_SEND_A As String = "ZA"
    Public Const CMD_SEND_B As String = "ZB"
    Public Const CMD_SEND_T As String = "ZT"
    Public Const CMD_SEND_P As String = "ZP"
    Public Const CMD_SEND_D As String = "ZD"
    Public Const CMD_SEND_E As String = "ZE"
    Public Const CMD_SEND_N As String = "ZN"
    Public Const CMD_SEND_S As String = "ZS"
    Public Const CMD_SEND_R As String = "ZR"
    Public Const CMD_SEND_C As String = "ZC"
    Public Const CMD_SEND_M As String = "ZM"
    Public Const CMD_SEND_L As String = "ZL"
    Public Const CMD_SEND_W As String = "ZW"

    ' 受信コマンド
    Public Const CMD_RECIEVE_a As String = "Za"
    Public Const CMD_RECIEVE_b As String = "Zb"
    Public Const CMD_RECIEVE_c As String = "Zc"
    Public Const CMD_RECIEVE_d As String = "Zd"
    Public Const CMD_RECIEVE_e As String = "Ze"     ' マーク読み取り開始要求コマンド受信
    Public Const CMD_RECIEVE_f As String = "Zf"
    Public Const CMD_RECIEVE_g As String = "Zg"
    Public Const CMD_RECIEVE_h As String = "Zh"     ' 動作可能コマンド受信
    Public Const CMD_RECIEVE_i As String = "Zi"     ' マークセンサーからのカメラ距離受信

    Public Const CMD_RECIEVE_l As String = "Zl"
    Public Const CMD_RECIEVE_m As String = "Zm"

    Public Const CMD_RECIEVE_o As String = "Zo"     ' 照合エラー
    Public Const CMD_RECIEVE_p As String = "Zp"     ' 停止要求
    Public Const CMD_RECIEVE_r As String = "Zr"

    Public Const CMD_RECIEVE_s As String = "Zs"
    Public Const CMD_RECIEVE_t As String = "Zt"

    Public Const DEF_VERSION = "Ver.2025.11.06"
    Public Const DEF_FILENAME = "ADPsim.def"
    Public Const DEF_ERROR_FILENAME = "ErrorMessageList.txt"

    Public Shared pblDriveLogFileName As String
    Public Shared objSyncHist As Object
    Public Shared objSyncSeri As Object

    Public Shared strRecData As String                      ' 受信データ

End Class
