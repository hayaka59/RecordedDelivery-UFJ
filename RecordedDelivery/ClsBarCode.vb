Option Explicit On
'Option Strict On

Public Class ClsBarCode

    '----------------------------------------------------
    ' バーコードタイプキャラクタ配列宣言
    '----------------------------------------------------
    '[ NW7 ]
    Private t_NW7_Char As String        ' キャラクタ
    Private t_NW7_Pattern() As String   ' バーパターン

    '----------------------------------------------------
    ' プロパティ変数宣言
    '----------------------------------------------------
    Private _target As PictureBox   ' 出力対象オブジェクト（PictureBox 固定）
    Private _top As Long            ' 出力開始上端位置
    Private _left As Long           ' 出力開始左端位置
    Private _block As Long          ' バーコード 1ブロックラインサイズ
    Private _height As Long         ' バーコード 高さ

    Private _code As String         ' コードキャラクタ
    Private _check As Boolean       ' モジュラスチェックあり/なし
    Private _startChr As String     ' スタートキャラクタ
    Private _stopChr As String      ' ストップキャラクタ

    '*************************************************************************************************************
    '                                 プライベートプロシージャ（チェックデジット）
    '*************************************************************************************************************
    '----------------------------------------------------
    ' モジュラス16   任意桁用 (NW7用)
    '----------------------------------------------------
    Private Function pfncModulus16(ByVal strCode As String) As Long

        Dim i As Long
        Dim lngModulus As Long

        pfncModulus16 = -1
        lngModulus = 0

        For i = 1 To Len(strCode)
            lngModulus = lngModulus + (InStr(t_NW7_Char, UCase(Mid(strCode, CInt(i), 1))) - 1)
        Next i

        i = lngModulus Mod 16

        pfncModulus16 = 16 - i

        If pfncModulus16 = 16 Then
            pfncModulus16 = 0
        End If


    End Function

    '----------------------------------------------------
    ' NW7 変換
    '----------------------------------------------------
    Private Function pfncConvNW7(ByVal strCode As String) As String

        Dim i As Long
        Dim j As Long
        Dim lngLength As Long

        pfncConvNW7 = ""

        lngLength = Len(strCode)

        For i = 1 To lngLength
            ' 変換
            j = InStr(t_NW7_Char, UCase(Mid(strCode, CInt(i), 1)))
            If j > 0 Then
                pfncConvNW7 = pfncConvNW7 + t_NW7_Pattern(CInt(j) - 1)
            End If
        Next i

    End Function


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Target() As Object
        Get
            Return _target
        End Get
        Set(ByVal value As Object)
            _target = value
        End Set
    End Property

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Top() As Long
        Get
            Return _top
        End Get
        Set(ByVal value As Long)
            _top = value
        End Set
    End Property

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Left() As Long
        Get
            Return _block
        End Get
        Set(ByVal value As Long)
            _block = value
        End Set
    End Property

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Height() As Long
        Get
            Return _height
        End Get
        Set(ByVal value As Long)
            _height = value
        End Set
    End Property

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Block() As Long
        Get
            Return _block
        End Get
        Set(ByVal value As Long)
            _block = value
        End Set
    End Property

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Code() As String
        Get
            Return _code
        End Get
        Set(ByVal value As String)
            _code = value
        End Set
    End Property


    ''' <summary>
    ''' チェックデジット
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Check() As Boolean
        Get
            Return _check
        End Get
        Set(ByVal value As Boolean)
            _check = value
        End Set
    End Property

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property StartChr() As String
        Get
            Return _startChr
        End Get
        Set(ByVal value As String)
            _startChr = value
        End Set
    End Property

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property StopChr() As String
        Get
            Return _stopChr
        End Get
        Set(ByVal value As String)
            _stopChr = value
        End Set
    End Property


    ''' <summary>
    ''' バーコード作成クラスのコンストラクタ
    ''' </summary>
    ''' <remarks></remarks>
    Sub New()

        _check = False
        _startChr = "c"
        _stopChr = "c"

        '----------------------------------------
        ' バーコードタイプキャラクタ配列初期設定
        '----------------------------------------
        '****************************************
        '                  NW7
        '****************************************
        t_NW7_Char = "0123456789-$:/.+ABCD"
        t_NW7_Pattern = New String() {"10101000111000", _
                                      "10101110001000", _
                                      "10100010111000", _
                                      "11100010101000", _
                                      "10111010001000", _
                                      "11101010001000", _
                                      "10001010111000", _
                                      "10001011101000", _
                                      "10001110101000", _
                                      "11101000101000", _
                                      "10100011101000", _
                                      "10111000101000", _
                                      "11101011101110", _
                                      "11101110101110", _
                                      "11101110111010", _
                                      "10111011101110", _
                                      "10111000100010", _
                                      "10001000101110", _
                                      "10100010001110", _
                                      "10100011100010"}

    End Sub

    ''' <summary>
    ''' バーコード（NW7）作成
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub PrintBar()

        Dim i As Long               ' ループカウンタ
        Dim strCode As String       ' スタート・ストップ・チェックを含むコード
        Dim strCodeNon As String    ' チェックを含むコード（スタート・ストップコードは含まない）
        Dim strPatern As String     ' strCodeのNW7パターンデータ
        Dim lngRatioX As Long       ' 横(X)比率
        Dim lngRatioY As Long       ' 縦(Y)比率
        Dim lngBlock As Long        ' 1ブロックサイズ
        Dim lngX1 As Long           ' バー開始X座標
        Dim lngY1 As Long           '         Y座標
        'Dim lngX2 As Long           ' バー終了X座標
        Dim lngY2 As Long           '         Y座標
        'Dim strChr As String        ' 1キャラクタ文字列
        Dim lngChrBarWidth As Long  ' 1キャラクタバーコード幅
        'Dim lngChrWidth As Long     ' コード文字列1キャラクタ幅

        ' スタート・ストップキャラクタ
        strCode = _startChr & _code & _stopChr
        strCodeNon = _code

        ' モジュラスチェック
        If _check Then
            strCode = _startChr & _code & Mid(t_NW7_Char, CInt(pfncModulus16(strCode) + 1), 1) & _stopChr
            strCodeNon = _code & Mid(t_NW7_Char, CInt(pfncModulus16(strCode) + 1), 1)
        End If

        ' NW7 パターンに変換
        strPatern = pfncConvNW7(strCode)

        '' 縦横比率取得
        'If TypeOf _target Is PowerPacks.Printing.Compatibility.VB6.Printer Then
        '    ' プリンター
        '    lngRatioX = _target.TwipsPerPixelX
        '    lngRatioY = _target.TwipsPerPixelY
        '    lngBlock = _block * lngRatioX
        'ElseIf TypeOf _target Is PictureBox Then
        '    ' ピクチャーボックス
        '    lngRatioX = Screen.TwipsPerPixelX
        '    lngRatioY = Screen.TwipsPerPixelY
        '    lngBlock = _block
        'Else
        '    Exit Sub
        'End If

        ' ピクチャーボックス
        lngRatioX = 1
        lngRatioY = 1
        lngBlock = _block

        ' バーコード出力位置セット
        lngX1 = _left * lngRatioX
        lngY1 = _top * lngRatioY
        lngY2 = lngY1 + (_height * lngRatioY)
        ' 1キャラクタバーコード幅
        lngChrBarWidth = (lngBlock * lngRatioY) * 14
        ' バー1ブロックサイズセット
        _target.Width = 200

        '描画先とするImageオブジェクトを作成する
        Dim canvas As New Bitmap(_target.Width, _target.Height)
        'ImageオブジェクトのGraphicsオブジェクトを作成する
        Dim g As Graphics = Graphics.FromImage(canvas)

        ' バーコード描画
        For i = 1 To Len(strPatern)

            ' バー出力
            If Mid(strPatern, CInt(i), 1) = "1" Then
                '_target. (lngX1, lngY1)-(lngX1 + (lngBlock - 1), lngY2), 0, BF
                g.DrawLine(Pens.Black, lngX1, lngY1, lngX1 + (lngBlock - 1), lngY2)
                'g.DrawRectangle(Pens.Black, lngX1, lngY1, (lngBlock - 1), lngY2)
            End If
            ' 文字列出力
            '----------------------------------------------------------------------
            ' 1キャラクタは14バイトのパターンで表される為、14で割った時に余りが0の
            ' 場合にキャラクタ文字列を表示します。
            ' 尚、フォントサイズはデフォルト値を使用する為、適切な処理を行ってくだ
            ' さい。(手抜き^^;)
            ' 画面イメージと印刷イメージは解像度の関係上同じにはなりません。
            '----------------------------------------------------------------------

            'If i Mod 14 = 0 Then
            '    strChr = Mid(strCode, CInt(i) \ 14, 1)                            ' 出力1キャラクタ
            '    lngChrWidth = mf.Size                    ' 1キャラクタ幅
            '    'lngX1 - lngChrBarWidth                  ' 出力開始X座標
            '    '_target.CurrentY = lngY2 + lngRatioY                       ' 出力開始Y座標
            '    '_target.CurrentX = _target.CurrentX + _
            '    '                    ((lngChrBarWidth - lngChrWidth) \ 2)    ' 中央にセット
            '    '_target.DrawToBitmap()

            '    g.DrawString(strChr, mf, Brushes.Black, 20 * i, _height \ 2)


            'End If
            lngX1 = lngX1 + (lngBlock * lngRatioX)                          ' バー出力位置加算
        Next i
        'Dim mf As New Font("ＭＳ ゴシック", 10, FontStyle.Regular)
        Dim mf As New Font("ＭＳ ゴシック", 12, FontStyle.Regular)
        'g.DrawString(strCode, mf, Brushes.Black, 40, _height)
        g.DrawString(CDbl(strCodeNon).ToString("000-00-00000-0"), mf, Brushes.Black, 40, _height)

        'リソースを解放する
        g.Dispose()
        'PictureBox1に表示する
        _target.Image = canvas

    End Sub


End Class
