Option Explicit On
Option Strict On

Public Class ClassMasterForm

    ''' <summary>
    ''' フォームアクティブ処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ClassMasterForm_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated

        LblOperatorName.Text = GetOperatorInfomation()

    End Sub

    ''' <summary>
    ''' フォームロード処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ClassMasterForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            ' 現在の年月日を取得する
            lblCurrentDate.Text = GetCurrentDate()

            'CmbNumberBand.Items.Clear()
            'CmbNumberBand.Items.Add("030：簡易書留")
            'CmbNumberBand.Items.Add("050：特定記録")
            'CmbNumberBand.Items.Add("150：ゆうメール")
            'CmbNumberBand.SelectedIndex = 0

            ' 「種別」コンボボックスの設定
            SetComboBoxForClassFile(CmbNumberBand)
            CmbNumberBand.SelectedIndex = 0

            ' 種別ファイルの読込とコンボボックスへの登録
            Dim strReadDataFileName As String = IncludeTrailingPathDelimiter(Application.StartupPath) & PubConstClass.DEF_CLASS_FILE_NAME
            Using sr As New System.IO.StreamReader(strReadDataFileName, System.Text.Encoding.Default)
                CmbClassCode.Items.Clear()
                Do While Not sr.EndOfStream
                    CmbClassCode.Items.Add(sr.ReadLine.ToString)
                Loop
                CmbClassCode.SelectedIndex = 0
            End Using

        Catch ex As Exception
            MsgBox("【ClassMasterForm_Load】" & ex.Message)
        End Try


    End Sub

    ''' <summary>
    ''' 「戻る」ボタン処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBack.Click

        Me.Dispose()

    End Sub

    ''' <summary>
    ''' 種別コード変更処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CmbClassCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbClassCode.SelectedIndexChanged

        Dim strArray() As String

        Try
            strArray = Split(CmbClassCode.Text, "："c)
            TxtClassName.Text = strArray(1)

            ' 種別マスタからデータを表示する
            DispClassMasterData()

        Catch ex As Exception
            MsgBox("【CmbClassCode_SelectedIndexChanged】" & ex.Message)
        End Try

    End Sub


    ''' <summary>
    ''' 「登録」ボタン処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnEntry_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEntry.Click

        Dim varRetVal As MsgBoxResult

        Try
            varRetVal = MsgBox("登録してよろしいですか？", CType(MsgBoxStyle.Question + MsgBoxStyle.OkCancel, MsgBoxStyle), "確認")
            If varRetVal = MsgBoxResult.Cancel Then
                Exit Sub
            End If

            Dim strOutPutFileName As String = IncludeTrailingPathDelimiter(Application.StartupPath) & CmbClassCode.Text & ".txt"

            ' 種別マスターファイルの削除
            System.IO.File.Delete(strOutPutFileName)
            ' 種別マスター情報の書き込み

            Using sw As New System.IO.StreamWriter(strOutPutFileName, True, System.Text.Encoding.Default)
                sw.WriteLine(CmbNumberBand.SelectedIndex.ToString("0") & "," & CmbNumberBand.Text)

                sw.WriteLine("[定形：重量,料金]")
                sw.WriteLine(TxtWeight1.Text & "," & TxtPrice1.Text)
                sw.WriteLine(TxtWeight2.Text & "," & TxtPrice2.Text)
                sw.WriteLine(TxtWeight3.Text & "," & TxtPrice3.Text)
                sw.WriteLine(TxtWeight4.Text & "," & TxtPrice4.Text)
                sw.WriteLine(TxtWeight5.Text & "," & TxtPrice5.Text)
                sw.WriteLine(TxtWeight6.Text & "," & TxtPrice6.Text)
                sw.WriteLine(TxtWeight7.Text & "," & TxtPrice7.Text)
                sw.WriteLine(TxtWeight8.Text & "," & TxtPrice8.Text)
                sw.WriteLine(TxtWeight9.Text & "," & TxtPrice9.Text)

                sw.WriteLine("[定形外（規格内）：重量,料金]")
                sw.WriteLine(TxtWeightG1.Text & "," & TxtPriceG1.Text)
                sw.WriteLine(TxtWeightG2.Text & "," & TxtPriceG2.Text)
                sw.WriteLine(TxtWeightG3.Text & "," & TxtPriceG3.Text)
                sw.WriteLine(TxtWeightG4.Text & "," & TxtPriceG4.Text)
                sw.WriteLine(TxtWeightG5.Text & "," & TxtPriceG5.Text)
                sw.WriteLine(TxtWeightG6.Text & "," & TxtPriceG6.Text)
                sw.WriteLine(TxtWeightG7.Text & "," & TxtPriceG7.Text)
                sw.WriteLine(TxtWeightG8.Text & "," & TxtPriceG8.Text)

                sw.WriteLine("[定形外（規格外）：重量,料金]")
                sw.WriteLine(TxtWeightNonS1.Text & "," & TxtPriceNonS1.Text)
                sw.WriteLine(TxtWeightNonS2.Text & "," & TxtPriceNonS2.Text)
                sw.WriteLine(TxtWeightNonS3.Text & "," & TxtPriceNonS3.Text)
                sw.WriteLine(TxtWeightNonS4.Text & "," & TxtPriceNonS4.Text)
                sw.WriteLine(TxtWeightNonS5.Text & "," & TxtPriceNonS5.Text)
                sw.WriteLine(TxtWeightNonS6.Text & "," & TxtPriceNonS6.Text)
                sw.WriteLine(TxtWeightNonS7.Text & "," & TxtPriceNonS7.Text)
                sw.WriteLine(TxtWeightNonS8.Text & "," & TxtPriceNonS8.Text)

            End Using

            MsgBox("登録が完了しました", CType(MsgBoxStyle.Information + MsgBoxStyle.OkOnly, MsgBoxStyle), "確認")

        Catch ex As Exception
            MsgBox("【BtnEntry_Click】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 種別マスタのデータを表示する
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DispClassMasterData()

        Dim strReadData As String
        Dim strArray() As String

        Try
            Dim strReadDataPath As String = IncludeTrailingPathDelimiter(Application.StartupPath) & CmbClassCode.Text & ".txt"

            Using sr As New System.IO.StreamReader(strReadDataPath, System.Text.Encoding.Default)

                ' 引受番号帯選択の設定
                strReadData = sr.ReadLine.ToString
                strArray = Split(strReadData, ","c)
                CmbNumberBand.SelectedIndex = CInt(strArray(0))

                ' １行読み飛ばし（[定形：重量,料金]）
                strReadData = sr.ReadLine.ToString
                ' 定形のデータ表示
                strReadData = sr.ReadLine.ToString
                SetReadData(TxtWeight1, TxtPrice1, strReadData)
                strReadData = sr.ReadLine.ToString
                SetReadData(TxtWeight2, TxtPrice2, strReadData)
                strReadData = sr.ReadLine.ToString
                SetReadData(TxtWeight3, TxtPrice3, strReadData)
                strReadData = sr.ReadLine.ToString
                SetReadData(TxtWeight4, TxtPrice4, strReadData)
                strReadData = sr.ReadLine.ToString
                SetReadData(TxtWeight5, TxtPrice5, strReadData)
                strReadData = sr.ReadLine.ToString
                SetReadData(TxtWeight6, TxtPrice6, strReadData)
                strReadData = sr.ReadLine.ToString
                SetReadData(TxtWeight7, TxtPrice7, strReadData)
                strReadData = sr.ReadLine.ToString
                SetReadData(TxtWeight8, TxtPrice8, strReadData)
                strReadData = sr.ReadLine.ToString
                SetReadData(TxtWeight9, TxtPrice9, strReadData)

                ' １行読み飛ばし（[定形外：重量,料金]）
                strReadData = sr.ReadLine.ToString
                '　定形外のデータ表示
                strReadData = sr.ReadLine.ToString
                SetReadData(TxtWeightG1, TxtPriceG1, strReadData)
                strReadData = sr.ReadLine.ToString
                SetReadData(TxtWeightG2, TxtPriceG2, strReadData)
                strReadData = sr.ReadLine.ToString
                SetReadData(TxtWeightG3, TxtPriceG3, strReadData)
                strReadData = sr.ReadLine.ToString
                SetReadData(TxtWeightG4, TxtPriceG4, strReadData)
                strReadData = sr.ReadLine.ToString
                SetReadData(TxtWeightG5, TxtPriceG5, strReadData)
                strReadData = sr.ReadLine.ToString
                SetReadData(TxtWeightG6, TxtPriceG6, strReadData)
                strReadData = sr.ReadLine.ToString
                SetReadData(TxtWeightG7, TxtPriceG7, strReadData)
                strReadData = sr.ReadLine.ToString
                SetReadData(TxtWeightG8, TxtPriceG8, strReadData)

                ' １行読み飛ばし（[定形外（規格外）：重量,料金]）
                strReadData = sr.ReadLine.ToString
                '　定形外のデータ表示
                strReadData = sr.ReadLine.ToString
                SetReadData(TxtWeightNonS1, TxtPriceNonS1, strReadData)
                strReadData = sr.ReadLine.ToString
                SetReadData(TxtWeightNonS2, TxtPriceNonS2, strReadData)
                strReadData = sr.ReadLine.ToString
                SetReadData(TxtWeightNonS3, TxtPriceNonS3, strReadData)
                strReadData = sr.ReadLine.ToString
                SetReadData(TxtWeightNonS4, TxtPriceNonS4, strReadData)
                strReadData = sr.ReadLine.ToString
                SetReadData(TxtWeightNonS5, TxtPriceNonS5, strReadData)
                strReadData = sr.ReadLine.ToString
                SetReadData(TxtWeightNonS6, TxtPriceNonS6, strReadData)
                strReadData = sr.ReadLine.ToString
                SetReadData(TxtWeightNonS7, TxtPriceNonS7, strReadData)
                strReadData = sr.ReadLine.ToString
                SetReadData(TxtWeightNonS8, TxtPriceNonS8, strReadData)

            End Using

        Catch ex As Exception
            MsgBox("【GetClassMasterData】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="TxtWeight"></param>
    ''' <param name="TxtPrice"></param>
    ''' <param name="strReadData"></param>
    ''' <remarks></remarks>
    Private Sub SetReadData(ByVal TxtWeight As TextBox, ByVal TxtPrice As TextBox, ByVal strReadData As String)

        Dim strArray() As String

        Try
            strArray = Split(strReadData, ","c)
            If strArray.Length > 1 Then
                TxtWeight.Text = strArray(0)
                TxtPrice.Text = strArray(1)
            Else
                TxtWeight.Text = ""
                TxtPrice.Text = ""
            End If
        Catch ex As Exception
            MsgBox("【SetReadData】" & ex.Message)
        End Try

    End Sub


    ''' <summary>
    ''' 「検索」ボタン処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSearch.Click

        ' 種別マスタからデータを読込
        GetClassMasterData(CmbClassCode.Text)

    End Sub

End Class