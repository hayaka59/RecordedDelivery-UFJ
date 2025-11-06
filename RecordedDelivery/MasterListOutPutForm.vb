Option Explicit On
Option Strict On

Public Class MasterListOutPutForm

    Private arPrintData As ArrayList
    Private intPrintDataCount As Integer    ' 印字するデータの数
    Private intPrintPageIndex As Integer    ' 印字頁数

    ''' <summary>
    ''' フォームアクティブ処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MasterListOutPutForm_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated

        LblOperatorName.Text = GetOperatorInfomation()

    End Sub

    ''' <summary>
    ''' フォームロード処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MasterListOutPutForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load


        Try
            ' 現在の年月日を取得する
            lblCurrentDate.Text = GetCurrentDate()

            CmbMasterItem.Items.Clear()
            CmbMasterItem.Items.Add("支店コード")
            CmbMasterItem.Items.Add("種別マスター")
            CmbMasterItem.Items.Add("オペレーター")
            CmbMasterItem.Items.Add("業務一覧")
            CmbMasterItem.SelectedIndex = 0

            BtnExport.Enabled = False
            BtnInport.Enabled = False

        Catch ex As Exception
            MsgBox("【MasterListOutPutForm_Load】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 「戻る」ボタン処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnBack_Click(sender As System.Object, e As System.EventArgs) Handles BtnBack.Click

        Me.Dispose()

    End Sub

    ''' <summary>
    ''' 「表示」ボタン処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnDisplay_Click(sender As System.Object, e As System.EventArgs) Handles BtnDisplay.Click

        Try
            Select Case CmbMasterItem.SelectedIndex
                Case 0
                    ' 支店コード
                    BtnExport.Enabled = True
                    BtnInport.Enabled = True
                    Call DisplayBranchMaster()
                Case 1
                    ' 種別マスター
                    BtnExport.Enabled = True
                    BtnInport.Enabled = True
                    Call DisplayClassMaster()
                Case 2
                    ' オペレーター
                    BtnExport.Enabled = False
                    BtnInport.Enabled = False
                    Call DisplayOperatorList()
                Case Else
                    ' 業務マスター
                    BtnExport.Enabled = False
                    BtnInport.Enabled = False
                    Call DisplayJobList()

            End Select

        Catch ex As Exception
            MsgBox("【BtnDisplay_Click】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 支店コードマスタの内容表示
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DisplayBranchMaster()

        Try
            LsvDataView.Clear()
            ' ListViewのカラムヘッダー設定
            LsvDataView.View = View.Details
            Dim col1 As ColumnHeader = New ColumnHeader
            Dim col2 As ColumnHeader = New ColumnHeader
            Dim col3 As ColumnHeader = New ColumnHeader

            col1.Text = "No"
            col2.Text = "支店コード"
            col3.Text = "支店名"

            col1.TextAlign = HorizontalAlignment.Center
            col2.TextAlign = HorizontalAlignment.Center
            col3.TextAlign = HorizontalAlignment.Left

            col1.Width = 80     ' No
            col2.Width = 100    ' 支店コード
            col3.Width = 200    ' 支店名

            Dim colHeader() As ColumnHeader = {col1, col2, col3}
            LsvDataView.Columns.AddRange(colHeader)

            Dim col(3) As String
            Dim itm As ListViewItem
            Dim intNumber As Integer = 0
            Dim strReadData As String = ""
            Dim strArray() As String = Nothing

            ' 読込ファイル名の設定
            Dim strReadDataFileName As String = IncludeTrailingPathDelimiter(Application.StartupPath) & PubConstClass.DEF_BRANCH_MASTER

            arPrintData = New ArrayList
            arPrintData.Clear()

            Using sr As New System.IO.StreamReader(strReadDataFileName, System.Text.Encoding.Default)
                Do While Not sr.EndOfStream
                    strReadData = sr.ReadLine.ToString
                    strArray = Split(strReadData, ","c)
                    intNumber += 1
                    col(0) = intNumber.ToString("0")
                    col(1) = strArray(0)
                    col(2) = strArray(1)

                    ' 印刷用アレイリストへデータ格納
                    arPrintData.Add(col(0) & "," & col(1) & "," & col(2))

                    itm = New ListViewItem(col)
                    LsvDataView.Items.Add(itm)
                Loop
            End Using
            LsvDataView.Items(0).Selected = True
            LsvDataView.Items(0).Focused = True
            LsvDataView.Select()
            LsvDataView.Items(0).EnsureVisible()

        Catch ex As Exception
            MsgBox("【DisplayBranchMaster】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 種別マスタの内容表示
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DisplayClassMaster()

        Try
            LsvDataView.Clear()
            ' ListViewのカラムヘッダー設定
            LsvDataView.View = View.Details
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

            col1.Text = "　種　別"
            col2.Text = "値１"
            col3.Text = "値２"
            col4.Text = "値３"
            col5.Text = "値４"
            col6.Text = "値５"
            col7.Text = "値６"
            col8.Text = "値７"
            col9.Text = "値８"
            col10.Text = "値９"

            col1.TextAlign = HorizontalAlignment.Center
            col2.TextAlign = HorizontalAlignment.Center
            col3.TextAlign = HorizontalAlignment.Center
            col4.TextAlign = HorizontalAlignment.Center
            col5.TextAlign = HorizontalAlignment.Center
            col6.TextAlign = HorizontalAlignment.Center
            col7.TextAlign = HorizontalAlignment.Center
            col8.TextAlign = HorizontalAlignment.Center
            col9.TextAlign = HorizontalAlignment.Center
            col10.TextAlign = HorizontalAlignment.Center

            col1.Width = 300    ' 種別
            col2.Width = 90     ' 
            col3.Width = 90     ' 
            col4.Width = 90     ' 
            col5.Width = 90     ' 
            col6.Width = 90     ' 
            col7.Width = 90     ' 
            col8.Width = 90     ' 
            col9.Width = 90     ' 
            col10.Width = 90    ' 

            Dim colHeader() As ColumnHeader = {col1, col2, col3, col4, col5, col6, col7, col8, col9, col10}
            LsvDataView.Columns.AddRange(colHeader)

            arPrintData = New ArrayList
            arPrintData.Clear()

            Call DisplayClassMasterSub("30：簡易書留.txt")
            Call DisplayClassMasterSub("40：簡易書留速達.txt")
            Call DisplayClassMasterSub("50：特定記録.txt")
            Call DisplayClassMasterSub("60：特定記録速達.txt")
            Call DisplayClassMasterSub("150：ゆうメール（簡易書留）.txt")
            Call DisplayClassMasterSub("160：ゆうメール（簡易書留）速達.txt")

            Call DisplayClassMasterSub("70：書留.txt")
            Call DisplayClassMasterSub("80：書留速達.txt")
            Call DisplayClassMasterSub("90：配達証明.txt")
            Call DisplayClassMasterSub("100：配達証明速達.txt")
            Call DisplayClassMasterSub("75：書留（本人限定）.txt")
            Call DisplayClassMasterSub("85：書留速達（本人限定）.txt")
            Call DisplayClassMasterSub("95：配達証明（本人限定）.txt")
            Call DisplayClassMasterSub("105：配達証明速達（本人限定）.txt")

            LsvDataView.Items(0).Selected = True
            LsvDataView.Items(0).Focused = True
            LsvDataView.Select()
            LsvDataView.Items(0).EnsureVisible()

        Catch ex As Exception
            MsgBox("【DisplayClassMaster】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 種別マスタ内容表示
    ''' </summary>
    ''' <param name="strReadFileName"></param>
    ''' <remarks></remarks>
    Private Sub DisplayClassMasterSub(ByVal strReadFileName As String)

        Dim colW(10) As String
        Dim colP(10) As String

        Dim itmW As ListViewItem
        Dim itmP As ListViewItem
        Dim strReadData As String = ""
        Dim strArray() As String = Nothing

        Try
            ' 読込ファイル名の設定
            Dim strReadDataFileName As String = IncludeTrailingPathDelimiter(Application.StartupPath) & strReadFileName

            Using sr As New System.IO.StreamReader(strReadDataFileName, System.Text.Encoding.Default)

                Do While Not sr.EndOfStream
                    strArray = Split(strReadFileName, "."c)
                    colW(0) = strArray(0)
                    For N = 1 To 9
                        colW(N) = "　"
                    Next
                    itmW = New ListViewItem(colW)
                    LsvDataView.Items.Add(itmW)
                    ' 印字データの格納
                    arPrintData.Add(colW(0) & "," & colW(1) & "," & colW(2) & "," & colW(3) & "," & colW(4) & "," _
                                     & colW(5) & "," & colW(6) & "," & colW(7) & "," & colW(8) & "," & colW(9))

                    ' 行の背景色を設定
                    For K = 0 To 9
                        LsvDataView.Items(LsvDataView.Items.Count - 1).SubItems(K).BackColor = Color.LightGray
                    Next

                    ' １行目読み飛ばし
                    strReadData = sr.ReadLine.ToString
                    ' ２行目読み飛ばし
                    strReadData = sr.ReadLine.ToString

                    colW(0) = "　重量(定形)"
                    colP(0) = "　料金(定形)"
                    For N = 1 To 9
                        strReadData = sr.ReadLine.ToString
                        strArray = Split(strReadData, ","c)
                        colW(N) = strArray(0)
                        colP(N) = strArray(1)
                    Next
                    itmW = New ListViewItem(colW)
                    LsvDataView.Items.Add(itmW)
                    ' 印字データの格納
                    arPrintData.Add(colW(0) & "," & colW(1) & "," & colW(2) & "," & colW(3) & "," & colW(4) & "," _
                                     & colW(5) & "," & colW(6) & "," & colW(7) & "," & colW(8) & "," & colW(9))

                    itmP = New ListViewItem(colP)
                    LsvDataView.Items.Add(itmP)
                    ' 印字データの格納
                    arPrintData.Add(colP(0) & "," & colP(1) & "," & colP(2) & "," & colP(3) & "," & colP(4) & "," _
                                     & colP(5) & "," & colP(6) & "," & colP(7) & "," & colP(8) & "," & colP(9))

                    ' １２行目読み飛ばし
                    strReadData = sr.ReadLine.ToString
                    colW(0) = "　重量(定形外／規格内)"
                    colP(0) = "　料金(定形外／規格内)"
                    colW(1) = ""
                    colP(1) = ""
                    For N = 2 To 9
                        strReadData = sr.ReadLine.ToString
                        strArray = Split(strReadData, ","c)
                        colW(N) = strArray(0)
                        colP(N) = strArray(1)
                    Next
                    itmW = New ListViewItem(colW)
                    LsvDataView.Items.Add(itmW)
                    ' 印字データの格納
                    arPrintData.Add(colW(0) & "," & colW(1) & "," & colW(2) & "," & colW(3) & "," & colW(4) & "," _
                                     & colW(5) & "," & colW(6) & "," & colW(7) & "," & colW(8) & "," & colW(9))

                    itmP = New ListViewItem(colP)
                    LsvDataView.Items.Add(itmP)
                    ' 印字データの格納
                    arPrintData.Add(colP(0) & "," & colP(1) & "," & colP(2) & "," & colP(3) & "," & colP(4) & "," _
                                     & colP(5) & "," & colP(6) & "," & colP(7) & "," & colP(8) & "," & colP(9))

                    ' ２１行目読み飛ばし
                    strReadData = sr.ReadLine.ToString
                    colW(0) = "　重量(定形外／規格外)"
                    colP(0) = "　料金(定形外／規格外)"
                    colW(1) = ""
                    colP(1) = ""
                    For N = 2 To 9
                        strReadData = sr.ReadLine.ToString
                        strArray = Split(strReadData, ","c)
                        colW(N) = strArray(0)
                        colP(N) = strArray(1)
                    Next
                    itmW = New ListViewItem(colW)
                    LsvDataView.Items.Add(itmW)
                    ' 印字データの格納
                    arPrintData.Add(colW(0) & "," & colW(1) & "," & colW(2) & "," & colW(3) & "," & colW(4) & "," _
                                     & colW(5) & "," & colW(6) & "," & colW(7) & "," & colW(8) & "," & colW(9))

                    itmP = New ListViewItem(colP)
                    LsvDataView.Items.Add(itmP)
                    ' 印字データの格納
                    arPrintData.Add(colP(0) & "," & colP(1) & "," & colP(2) & "," & colP(3) & "," & colP(4) & "," _
                                     & colP(5) & "," & colP(6) & "," & colP(7) & "," & colP(8) & "," & colP(9))

                Loop

            End Using

        Catch ex As Exception
            MsgBox("【DisplayClassMasterSub】" & ex.Message)
        End Try

    End Sub


    ''' <summary>
    ''' オペレータ一覧表示
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DisplayOperatorList()

        Try
            LsvDataView.Clear()
            ' ListViewのカラムヘッダー設定
            LsvDataView.View = View.Details
            Dim col1 As ColumnHeader = New ColumnHeader
            Dim col2 As ColumnHeader = New ColumnHeader
            Dim col3 As ColumnHeader = New ColumnHeader
            Dim col4 As ColumnHeader = New ColumnHeader
            Dim col5 As ColumnHeader = New ColumnHeader

            col1.Text = "No"
            col2.Text = "オペレータコード"
            col3.Text = "オペレータ名"
            col4.Text = "登録日"
            col5.Text = "権限"

            col1.TextAlign = HorizontalAlignment.Left
            col2.TextAlign = HorizontalAlignment.Left
            col3.TextAlign = HorizontalAlignment.Left
            col4.TextAlign = HorizontalAlignment.Center
            col5.TextAlign = HorizontalAlignment.Left

            col1.Width = 80     ' No
            col2.Width = 200    ' オペレータコード
            col3.Width = 200    ' オペレータ名
            col4.Width = 200    ' 登録日
            col5.Width = 100    ' 権限

            Dim colHeader() As ColumnHeader = {col1, col2, col3, col4, col5}
            LsvDataView.Columns.AddRange(colHeader)

            Dim col(4) As String
            Dim itm As ListViewItem
            Dim intNumber As Integer = 0
            Dim strReadData As String = ""
            Dim strArray() As String = Nothing

            Dim strReadDataENCPath As String = IncludeTrailingPathDelimiter(Application.StartupPath) & PubConstClass.DEF_OPERATOR_FILE_NAME_ENC
            Dim strReadDataINIPath As String = IncludeTrailingPathDelimiter(Application.StartupPath) & PubConstClass.DEF_OPERATOR_FILE_NAME_INI
            ' 暗号化されたオペレータ情報ファイルを復号化する
            DecryptFile(strReadDataENCPath, strReadDataINIPath, PubConstClass.DEF_OPEN_KEY)

            ' 読込ファイル名の設定
            Dim strReadDataFileName As String = IncludeTrailingPathDelimiter(Application.StartupPath) & PubConstClass.DEF_OPERATOR_FILE_NAME_INI

            arPrintData = New ArrayList
            arPrintData.Clear()

            Using sr As New System.IO.StreamReader(strReadDataFileName, System.Text.Encoding.Default)
                '          0,     1,          2,         3,     4
                'maintenance,保守員,maintenance,2015/08/17,保守員
                Do While Not sr.EndOfStream
                    strReadData = sr.ReadLine.ToString
                    strArray = Split(strReadData, ","c)
                    intNumber += 1
                    col(0) = intNumber.ToString("0")
                    col(1) = strArray(0)    ' オペレータコード
                    col(2) = strArray(1)    ' オペレータ名
                    col(3) = strArray(3)    ' 登録日
                    col(4) = strArray(4)    ' 権限

                    ' 印刷用アレイリストへデータ格納
                    arPrintData.Add(col(0) & "," & col(1) & "," & col(2) & "," & col(3) & "," & col(4))

                    itm = New ListViewItem(col)
                    LsvDataView.Items.Add(itm)
                Loop
            End Using
            LsvDataView.Items(0).Selected = True
            LsvDataView.Items(0).Focused = True
            LsvDataView.Select()
            LsvDataView.Items(0).EnsureVisible()

            ' 読込ファイルの削除
            System.IO.File.Delete(strReadDataFileName)

        Catch ex As Exception
            MsgBox("【DisplayOperatorList】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 業務リスト一覧表示
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DisplayJobList()

        Dim strArray() As String
        Dim strReadDataPath As String

        Try
            LsvDataView.Clear()
            ' ListViewのカラムヘッダー設定
            LsvDataView.View = View.Details
            Dim col1 As ColumnHeader = New ColumnHeader
            Dim col2 As ColumnHeader = New ColumnHeader

            col1.Text = "項目"
            col2.Text = "内容"

            col1.TextAlign = HorizontalAlignment.Left
            col2.TextAlign = HorizontalAlignment.Left

            col1.Width = 300    ' 
            col2.Width = 350    ' 

            Dim colHeader() As ColumnHeader = {col1, col2}
            LsvDataView.Columns.AddRange(colHeader)

            arPrintData = New ArrayList
            arPrintData.Clear()

            Dim col(2) As String
            Dim itm As ListViewItem
            Dim strFolder As String = IncludeTrailingPathDelimiter(Application.StartupPath) & "USER"
            Dim files As String() = System.IO.Directory.GetFiles( _
                                    strFolder, "user_*.txt", System.IO.SearchOption.AllDirectories)
            For N = 0 To files.GetLength(0) - 1
                strArray = files(N).Split("\"c)

                strReadDataPath = IncludeTrailingPathDelimiter(Application.StartupPath) & "USER\" & strArray(strArray.GetLength(0) - 1)

                Using sr As New System.IO.StreamReader(strReadDataPath, System.Text.Encoding.Default)

                    Do While Not sr.EndOfStream
                        strArray = sr.ReadLine.Split(","c)
                        If strArray.Length > 1 Then
                            If strArray(1) = "（空き）" Then
                                Exit Do
                            End If
                            col(0) = strArray(0)
                            If col(0) = "種別" And strArray.Length > 2 Then
                                col(1) = strArray(2)
                            Else
                                col(1) = strArray(1)
                            End If

                            Select Case col(0)
                                Case PubConstClass.USR_TEIKEI
                                    col(0) = "定形・定形外"
                                    If col(1) = "0" Then
                                        col(1) = "定形"
                                    Else
                                        col(1) = "定形外"
                                    End If
                                Case PubConstClass.USR_FEEDER_POS_V
                                    col(0) = "フィーダー位置 封筒幅"
                                Case PubConstClass.USR_LABEL_POS_V
                                    col(0) = "ラベル貼付位置 送方向（上辺）"
                                Case PubConstClass.USR_LABEL_POS_H
                                    col(0) = "ラベル貼付位置 横方向（左辺）"
                                Case PubConstClass.USR_ADDRESS_POS_V
                                    col(0) = "宛名撮像位置 送方向（画角中央）"
                                Case PubConstClass.USR_ADDRESS_POS_H
                                    col(0) = "宛名撮像位置 横方向（画角中央）"
                                Case Else
                            End Select

                            ' 2015.11.27 Ver.B04 hayakawa 修正↓ここから
                            If col(0) <> "正方向流し" Then
                                ' 印刷用アレイリストへデータ格納
                                arPrintData.Add(col(0) & "," & col(1))

                                itm = New ListViewItem(col)
                                LsvDataView.Items.Add(itm)

                                If strArray(0) = "業務名" Then
                                    ' 行の背景色を設定
                                    For K = 0 To 1
                                        LsvDataView.Items(LsvDataView.Items.Count - 1).SubItems(K).BackColor = Color.LightGray
                                    Next
                                End If
                            End If
                            ' 2015.11.27 Ver.B04 hayakawa 修正↑ここまで

                        End If
                    Loop

                End Using

            Next

            LsvDataView.Items(0).Selected = True
            LsvDataView.Items(0).Focused = True
            LsvDataView.Select()
            LsvDataView.Items(0).EnsureVisible()

        Catch ex As Exception
            MsgBox("【DisplayJobList】" & ex.Message)
        End Try

    End Sub


    ''' <summary>
    ''' 「インポート」ボタン処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnInport_Click(sender As System.Object, e As System.EventArgs) Handles BtnInport.Click

        Dim fbd As New FolderBrowserDialog

        Try
            fbd.Description = "インポートするファイルが格納されているフォルダを選択してください。"

            fbd.RootFolder = Environment.SpecialFolder.Desktop
            fbd.SelectedPath = Application.StartupPath

            ' 新規フォルダ作成を表示
            fbd.ShowNewFolderButton = True

            If fbd.ShowDialog(Me) = DialogResult.OK Then
                ' 選択されたフォルダをマスターファイルをインポートする
                Dim strFolderPath As String = fbd.SelectedPath
                Select Case CmbMasterItem.SelectedIndex
                    Case 0
                        ' 支店マスターのインポート
                        System.IO.File.Copy(IncludeTrailingPathDelimiter(strFolderPath) & "BranchMaster.ini", _
                                            IncludeTrailingPathDelimiter(Application.StartupPath) & "BranchMaster.ini")
                    Case 1
                        ' 種別マスターのインポート
                        System.IO.File.Copy(IncludeTrailingPathDelimiter(strFolderPath) & "30：簡易書留.txt", _
                                            IncludeTrailingPathDelimiter(Application.StartupPath) & "30：簡易書留.txt")
                        System.IO.File.Copy(IncludeTrailingPathDelimiter(strFolderPath) & "40：簡易書留速達.txt", _
                                            IncludeTrailingPathDelimiter(Application.StartupPath) & "40：簡易書留速達.txt")
                        System.IO.File.Copy(IncludeTrailingPathDelimiter(strFolderPath) & "50：特定記録.txt", _
                                            IncludeTrailingPathDelimiter(Application.StartupPath) & "50：特定記録.txt")
                        System.IO.File.Copy(IncludeTrailingPathDelimiter(strFolderPath) & "60：特定記録速達.txt", _
                                            IncludeTrailingPathDelimiter(Application.StartupPath) & "60：特定記録速達.txt")
                        System.IO.File.Copy(IncludeTrailingPathDelimiter(strFolderPath) & "150：ゆうメール（簡易書留）.txt", _
                                            IncludeTrailingPathDelimiter(Application.StartupPath) & "150：ゆうメール（簡易書留）txt")
                        System.IO.File.Copy(IncludeTrailingPathDelimiter(strFolderPath) & "160：ゆうメール（簡易書留）速達.txt", _
                                            IncludeTrailingPathDelimiter(Application.StartupPath) & "160：ゆうメール（簡易書留）速達.txt")
                    Case Else

                End Select

            End If

        Catch ex As Exception
            MsgBox("【BtnInport_Click】" & ex.Message)
        End Try

    End Sub


    ''' <summary>
    ''' 「エクスポート」ボタン処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnExport_Click(sender As System.Object, e As System.EventArgs) Handles BtnExport.Click

        Dim fbd As New FolderBrowserDialog

        Try
            fbd.Description = "エクスポート先のフォルダを選択してください。"

            fbd.RootFolder = Environment.SpecialFolder.Desktop
            fbd.SelectedPath = "E:\"

            ' 新規フォルダ作成を表示
            fbd.ShowNewFolderButton = True

            If fbd.ShowDialog(Me) = DialogResult.OK Then
                ' 選択されたフォルダにマスターファイルをエクスポートする
                Dim strFolderPath As String = fbd.SelectedPath
                Select Case CmbMasterItem.SelectedIndex
                    Case 0
                        ' 支店マスターのエクスポート
                        System.IO.File.Copy(IncludeTrailingPathDelimiter(Application.StartupPath) & "BranchMaster.ini", _
                                            IncludeTrailingPathDelimiter(strFolderPath) & "BranchMaster.ini")
                    Case 1
                        ' 種別マスターのエクスポート
                        System.IO.File.Copy(IncludeTrailingPathDelimiter(Application.StartupPath) & "30：簡易書留.txt", _
                                            IncludeTrailingPathDelimiter(strFolderPath) & "30：簡易書留.txt")

                        System.IO.File.Copy(IncludeTrailingPathDelimiter(Application.StartupPath) & "40：簡易書留速達.txt", _
                                            IncludeTrailingPathDelimiter(strFolderPath) & "40：簡易書留速達.txt")

                        System.IO.File.Copy(IncludeTrailingPathDelimiter(Application.StartupPath) & "50：特定記録.txt", _
                                            IncludeTrailingPathDelimiter(strFolderPath) & "50：特定記録.txt")

                        System.IO.File.Copy(IncludeTrailingPathDelimiter(Application.StartupPath) & "60：特定記録速達.txt", _
                                            IncludeTrailingPathDelimiter(strFolderPath) & "60：特定記録速達.txt")

                        System.IO.File.Copy(IncludeTrailingPathDelimiter(Application.StartupPath) & "150：ゆうメール（簡易書留）.txt", _
                                            IncludeTrailingPathDelimiter(strFolderPath) & "150：ゆうメール（簡易書留）.txt")

                        System.IO.File.Copy(IncludeTrailingPathDelimiter(Application.StartupPath) & "160：ゆうメール（簡易書留）速達.txt", _
                                            IncludeTrailingPathDelimiter(strFolderPath) & "160：ゆうメール（簡易書留）速達.txt")
                    Case Else

                End Select

            End If

        Catch ex As Exception
            MsgBox("【BtnExport_Click】" & ex.Message)
        End Try

    End Sub


    ''' <summary>
    ''' 「印刷」ボタン処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnPrint_Click(sender As System.Object, e As System.EventArgs) Handles BtnPrint.Click

        Try
            Dim retVal As MsgBoxResult
            retVal = MsgBox(CmbMasterItem.Text & "の内容を確認しますか？", CType(MsgBoxStyle.Question + MsgBoxStyle.OkCancel, MsgBoxStyle), "確認")
            If retVal = MsgBoxResult.Cancel Then
                ' キャンセル
                Exit Sub
            End If
            intPrintDataCount = arPrintData.Count
            intPrintPageIndex = 1

            'PrintDocumentオブジェクトの作成
            Dim pd As New System.Drawing.Printing.PrintDocument
            'PrintPageイベントハンドラの追加
            AddHandler pd.PrintPage, AddressOf PrintDocument1_PrintPage

            ' PrintPreviewDialogオブジェクトの作成
            Dim ppd As New PrintPreviewDialog
            ppd.Width = 1200
            ppd.Height = 1000
            ' プレビューオブジェクトの「印刷」ボタン削除
            Dim tool As ToolStrip = CType(ppd.Controls(1), ToolStrip)
            tool.Items.RemoveAt(0)

            ' プレビューするPrintDocumentを設定
            ppd.Document = pd
            ' 印刷プレビューダイアログを表示する
            ppd.ShowDialog()
            ' PrintPreviewDialogオブジェクトの解放
            ppd.Dispose()

            retVal = MsgBox(CmbMasterItem.Text & "を印刷しますか？", CType(MsgBoxStyle.Question + MsgBoxStyle.OkCancel, MsgBoxStyle), "確認")
            If retVal = MsgBoxResult.Cancel Then
                ' キャンセル
                Exit Sub
            End If
            intPrintDataCount = arPrintData.Count
            intPrintPageIndex = 1

            Select Case CmbMasterItem.SelectedIndex
                Case 0
                    pd.DocumentName = "支店コード印刷"
                Case 1
                    pd.DocumentName = "種別マスター印刷"
                Case 2
                    pd.DocumentName = "オペレーター印刷"
                Case 3
                    pd.DocumentName = "業務リスト印刷"
                Case Else
            End Select

            ' 印刷処理
            pd.Print()
            ' PrintDocumentオブジェクトの解放
            pd.Dispose()


        Catch ex As Exception
            MsgBox("【BtnPrint_Click】" & ex.Message)
        End Try

    End Sub


    ''' <summary>
    ''' 印刷処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub PrintDocument1_PrintPage(sender As Object, e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage

        Try
            Select Case CmbMasterItem.SelectedIndex
                Case 0
                    ' 支店コード
                    Call PrintBranchCodeData(sender, e)
                Case 1
                    ' 種別マスター
                    Call PrintClassMaster(sender, e)
                Case 2
                    ' オペレーター
                    Call PrintOperatorData(sender, e)
                Case 3
                    ' 業務リスト一覧
                    Call PrintJobList(sender, e)
                Case Else
            End Select

        Catch ex As Exception
            MsgBox("【MasterListOutPutForm.PrintDocument1_PrintPage】" & ex.Message)
        End Try

    End Sub


    ''' <summary>
    ''' 種別マスター印刷処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub PrintClassMaster(sender As Object, e As System.Drawing.Printing.PrintPageEventArgs)

        '// 1mm≒4.11
        Dim intYoko1 As Integer = 62                ' 横１の印刷座標（15mm）
        Dim intYoko2 As Integer = 164               ' 横２の印刷座標（40mm）
        Dim intYoko3 As Integer = 164 + 62 * 1      ' 横３の印刷座標（15mm×1）
        Dim intYoko4 As Integer = 164 + 62 * 2      ' 横４の印刷座標（15mm×2）
        Dim intYoko5 As Integer = 164 + 62 * 3      ' 横５の印刷座標（15mm×3）
        Dim intYoko6 As Integer = 164 + 62 * 4      ' 横６の印刷座標（15mm×4）
        Dim intYoko7 As Integer = 164 + 62 * 5      ' 横７の印刷座標（15mm×5）
        Dim intYoko8 As Integer = 164 + 62 * 6      ' 横８の印刷座標（15mm×6）
        Dim intYoko9 As Integer = 164 + 62 * 7      ' 横９の印刷座標（15mm×7）
        Dim intYoko10 As Integer = 164 + 62 * 8     ' 横10の印刷座標（15mm×8）
        Dim intYoko11 As Integer = 164 + 62 * 9     ' 横11の印刷座標（15mm×9）

        Dim intTate1 As Integer = 41        ' 縦１の印刷座標（10mm）
        Dim intTate2 As Integer = 61        ' 縦２の印刷座標（15mm）
        Dim intTate3 As Integer = 82        ' 縦３の印刷座標（20mm）
        Dim intTate4 As Integer = 102       ' 縦４の印刷座標（25mm）

        Dim intSTPosYoko As Integer         ' 印刷開始ポジション（横）
        Dim intSTPosTate As Integer         ' 印刷開始ポジション（縦）

        Dim intOffset As Integer            ' 文字印刷縦方向印刷オフセット
        Dim strArray() As String

        Dim N As Integer                    ' 汎用ループカウンタ
        Dim iRowPerPage As Integer          ' １頁毎の印字行数

        Try
            ' ヘッダーの印刷
            Dim dtNow As DateTime = DateTime.Now
            Dim t As New Font("メイリオ", 18, FontStyle.Regular)
            Dim h As New Font("メイリオ", 14, FontStyle.Regular)
            Dim f As New Font("メイリオ", 10, FontStyle.Regular)

            Dim uh As New Font("メイリオ", 14, FontStyle.Underline)
            Dim ms As New Font("ＭＳ ゴシック", 14, FontStyle.Regular)

            ' ヘッダー１行目
            e.Graphics.DrawString(Date.Now.ToString("yyyy年MM月dd日 HH時mm分ss秒"), f, Brushes.Black, intYoko1 + intYoko7, intTate1)
            ' ヘッダー２行目
            e.Graphics.DrawString("種別マスター一覧", h, Brushes.Black, intYoko1, intTate2)
            e.Graphics.DrawString("【" & PubConstClass.pblMachineName & "】", f, Brushes.Black, intYoko1 + intYoko7, intTate2)
            e.Graphics.DrawString("Page " & intPrintPageIndex.ToString("0"), f, Brushes.Black, intYoko1 + intYoko9, intTate2)

            intSTPosYoko = intYoko1
            intSTPosTate = intTate4
            intOffset = 5                       ' 1.2mm
            Dim intRowHeight As Integer = 25    ' 6.1mm

            '// ヘッダー行
            intSTPosYoko = intYoko1
            e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(intSTPosYoko, intSTPosTate, intYoko2, intRowHeight))
            e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(intSTPosYoko, intSTPosTate, intYoko3, intRowHeight))
            e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(intSTPosYoko, intSTPosTate, intYoko4, intRowHeight))
            e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(intSTPosYoko, intSTPosTate, intYoko5, intRowHeight))
            e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(intSTPosYoko, intSTPosTate, intYoko6, intRowHeight))
            e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(intSTPosYoko, intSTPosTate, intYoko7, intRowHeight))
            e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(intSTPosYoko, intSTPosTate, intYoko8, intRowHeight))
            e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(intSTPosYoko, intSTPosTate, intYoko9, intRowHeight))
            e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(intSTPosYoko, intSTPosTate, intYoko10, intRowHeight))
            e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(intSTPosYoko, intSTPosTate, intYoko11, intRowHeight))

            e.Graphics.DrawString("　種別", f, Brushes.Black, intSTPosYoko, intSTPosTate + intOffset)
            e.Graphics.DrawString("　値１", f, Brushes.Black, intSTPosYoko + intYoko2, intSTPosTate + intOffset)
            e.Graphics.DrawString("　値２", f, Brushes.Black, intSTPosYoko + intYoko3, intSTPosTate + intOffset)
            e.Graphics.DrawString("　値３", f, Brushes.Black, intSTPosYoko + intYoko4, intSTPosTate + intOffset)
            e.Graphics.DrawString("　値４", f, Brushes.Black, intSTPosYoko + intYoko5, intSTPosTate + intOffset)
            e.Graphics.DrawString("　値５", f, Brushes.Black, intSTPosYoko + intYoko6, intSTPosTate + intOffset)
            e.Graphics.DrawString("　値６", f, Brushes.Black, intSTPosYoko + intYoko7, intSTPosTate + intOffset)
            e.Graphics.DrawString("　値７", f, Brushes.Black, intSTPosYoko + intYoko8, intSTPosTate + intOffset)
            e.Graphics.DrawString("　値８", f, Brushes.Black, intSTPosYoko + intYoko9, intSTPosTate + intOffset)
            e.Graphics.DrawString("　値９", f, Brushes.Black, intSTPosYoko + intYoko10, intSTPosTate + intOffset)

            iRowPerPage = 28
            'For N = 1 To 40
            For N = 1 To iRowPerPage
                strArray = arPrintData(N - 1 + (intPrintPageIndex - 1) * iRowPerPage).ToString.Split(","c)
                If N Mod 7 = 1 Then
                    e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(intSTPosYoko, intSTPosTate + intRowHeight * N, intYoko11, intRowHeight))
                Else
                    e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(intSTPosYoko, intSTPosTate + intRowHeight * N, intYoko2, intRowHeight))
                    e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(intSTPosYoko, intSTPosTate + intRowHeight * N, intYoko3, intRowHeight))
                    e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(intSTPosYoko, intSTPosTate + intRowHeight * N, intYoko4, intRowHeight))
                    e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(intSTPosYoko, intSTPosTate + intRowHeight * N, intYoko5, intRowHeight))
                    e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(intSTPosYoko, intSTPosTate + intRowHeight * N, intYoko6, intRowHeight))
                    e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(intSTPosYoko, intSTPosTate + intRowHeight * N, intYoko7, intRowHeight))
                    e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(intSTPosYoko, intSTPosTate + intRowHeight * N, intYoko8, intRowHeight))
                    e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(intSTPosYoko, intSTPosTate + intRowHeight * N, intYoko9, intRowHeight))
                    e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(intSTPosYoko, intSTPosTate + intRowHeight * N, intYoko10, intRowHeight))
                    e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(intSTPosYoko, intSTPosTate + intRowHeight * N, intYoko11, intRowHeight))
                End If

                e.Graphics.DrawString(" " & strArray(0), f, Brushes.Black, intSTPosYoko, intSTPosTate + intRowHeight * N + intOffset)
                e.Graphics.DrawString(" " & strArray(1), f, Brushes.Black, intSTPosYoko + intYoko2, intSTPosTate + intRowHeight * N + intOffset)
                e.Graphics.DrawString(" " & strArray(2), f, Brushes.Black, intSTPosYoko + intYoko3, intSTPosTate + intRowHeight * N + intOffset)
                e.Graphics.DrawString(" " & strArray(3), f, Brushes.Black, intSTPosYoko + intYoko4, intSTPosTate + intRowHeight * N + intOffset)
                e.Graphics.DrawString(" " & strArray(4), f, Brushes.Black, intSTPosYoko + intYoko5, intSTPosTate + intRowHeight * N + intOffset)
                e.Graphics.DrawString(" " & strArray(5), f, Brushes.Black, intSTPosYoko + intYoko6, intSTPosTate + intRowHeight * N + intOffset)
                e.Graphics.DrawString(" " & strArray(6), f, Brushes.Black, intSTPosYoko + intYoko7, intSTPosTate + intRowHeight * N + intOffset)
                e.Graphics.DrawString(" " & strArray(7), f, Brushes.Black, intSTPosYoko + intYoko8, intSTPosTate + intRowHeight * N + intOffset)
                e.Graphics.DrawString(" " & strArray(8), f, Brushes.Black, intSTPosYoko + intYoko9, intSTPosTate + intRowHeight * N + intOffset)
                e.Graphics.DrawString(" " & strArray(9), f, Brushes.Black, intSTPosYoko + intYoko10, intSTPosTate + intRowHeight * N + intOffset)

                intPrintDataCount -= 1
                If intPrintDataCount = 0 Then
                    Exit For
                End If

            Next N

            If intPrintDataCount > 0 Then
                e.HasMorePages = True
                intPrintPageIndex = intPrintPageIndex + 1
            Else
                e.HasMorePages = False
            End If

        Catch ex As Exception
            MsgBox("【PrintClassMaster】" & ex.Message)
        End Try

    End Sub


    ''' <summary>
    ''' オペレーター印刷処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub PrintOperatorData(sender As Object, e As System.Drawing.Printing.PrintPageEventArgs)

        '// 1mm≒4.11
        Dim intYoko1 As Integer = 103   ' 横１の印刷座標（25mm）
        Dim intYoko2 As Integer = 62    ' 横２の印刷座標（15mm）
        Dim intYoko3 As Integer = 238   ' 横３の印刷座標（58mm）
        Dim intYoko4 As Integer = 390   ' 横４の印刷座標（95mm）
        Dim intYoko5 As Integer = 518   ' 横５の印刷座標（126mm）
        Dim intYoko6 As Integer = 600   ' 横６の印刷座標（146mm）

        Dim intTate1 As Integer = 41    ' 縦１の印刷座標（10mm）
        Dim intTate2 As Integer = 61    ' 縦２の印刷座標（15mm）
        Dim intTate3 As Integer = 82    ' 縦３の印刷座標（20mm）
        Dim intTate4 As Integer = 102   ' 縦４の印刷座標（25mm）

        Dim intSTPosYoko As Integer     ' 印刷開始ポジション（横）
        Dim intSTPosTate As Integer     ' 印刷開始ポジション（縦）

        Dim intOffset As Integer        ' 文字印刷縦方向印刷オフセット
        Dim strArray() As String

        Dim N As Integer                ' 汎用ループカウンタ

        Try
            ' ヘッダーの印刷
            Dim dtNow As DateTime = DateTime.Now
            Dim t As New Font("メイリオ", 18, FontStyle.Regular)
            Dim h As New Font("メイリオ", 14, FontStyle.Regular)
            Dim f As New Font("メイリオ", 10, FontStyle.Regular)

            Dim uh As New Font("メイリオ", 14, FontStyle.Underline)
            Dim ms As New Font("ＭＳ ゴシック", 14, FontStyle.Regular)

            ' ヘッダー１行目
            e.Graphics.DrawString(Date.Now.ToString("yyyy年MM月dd日 HH時mm分ss秒"), f, Brushes.Black, intYoko1 + intYoko4, intTate1)
            ' ヘッダー２行目
            e.Graphics.DrawString("オペレータ一覧", h, Brushes.Black, intYoko1, intTate2)
            e.Graphics.DrawString("【" & PubConstClass.pblMachineName & "】", f, Brushes.Black, intYoko1 + intYoko4, intTate2)
            e.Graphics.DrawString("Page " & intPrintPageIndex.ToString("0"), f, Brushes.Black, intYoko1 + intYoko5, intTate2)

            intSTPosYoko = intYoko1
            intSTPosTate = intTate4
            intOffset = 5                       ' 1.2mm
            Dim intRowHeight As Integer = 25    ' 6.1mm

            '// ヘッダー行
            intSTPosYoko = intYoko1
            e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(intSTPosYoko, intSTPosTate, intYoko2, intRowHeight))
            e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(intSTPosYoko, intSTPosTate, intYoko3, intRowHeight))
            e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(intSTPosYoko, intSTPosTate, intYoko4, intRowHeight))
            e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(intSTPosYoko, intSTPosTate, intYoko5, intRowHeight))
            e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(intSTPosYoko, intSTPosTate, intYoko6, intRowHeight))
            e.Graphics.DrawString("　 No．", f, Brushes.Black, intSTPosYoko, intSTPosTate + intOffset)
            e.Graphics.DrawString("　オペレーターコード", f, Brushes.Black, intSTPosYoko + intYoko2, intSTPosTate + intOffset)
            e.Graphics.DrawString("　オペレーター名", f, Brushes.Black, intSTPosYoko + intYoko3, intSTPosTate + intOffset)
            e.Graphics.DrawString("　登録日", f, Brushes.Black, intSTPosYoko + intYoko4, intSTPosTate + intOffset)
            e.Graphics.DrawString("　権限", f, Brushes.Black, intSTPosYoko + intYoko5, intSTPosTate + intOffset)

            For N = 1 To 40
                strArray = arPrintData(N - 1 + (intPrintPageIndex - 1) * 40).ToString.Split(","c)

                e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(intSTPosYoko, intSTPosTate + intRowHeight * N, intYoko2, intRowHeight))
                e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(intSTPosYoko, intSTPosTate + intRowHeight * N, intYoko3, intRowHeight))
                e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(intSTPosYoko, intSTPosTate + intRowHeight * N, intYoko4, intRowHeight))
                e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(intSTPosYoko, intSTPosTate + intRowHeight * N, intYoko5, intRowHeight))
                e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(intSTPosYoko, intSTPosTate + intRowHeight * N, intYoko6, intRowHeight))
                e.Graphics.DrawString("　" & strArray(0), f, Brushes.Black, intSTPosYoko, intSTPosTate + intRowHeight * N + intOffset)
                e.Graphics.DrawString("　" & strArray(1), f, Brushes.Black, intSTPosYoko + intYoko2, intSTPosTate + intRowHeight * N + intOffset)
                e.Graphics.DrawString("　" & strArray(2), f, Brushes.Black, intSTPosYoko + intYoko3, intSTPosTate + intRowHeight * N + intOffset)
                e.Graphics.DrawString("　" & strArray(3), f, Brushes.Black, intSTPosYoko + intYoko4, intSTPosTate + intRowHeight * N + intOffset)
                e.Graphics.DrawString("　" & strArray(4), f, Brushes.Black, intSTPosYoko + intYoko5, intSTPosTate + intRowHeight * N + intOffset)

                intPrintDataCount -= 1
                If intPrintDataCount = 0 Then
                    Exit For
                End If

            Next N

            If intPrintDataCount > 0 Then
                e.HasMorePages = True
                intPrintPageIndex = intPrintPageIndex + 1
            Else
                e.HasMorePages = False
            End If

        Catch ex As Exception
            MsgBox("【PrintOperatorData】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 支店コード印刷処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub PrintBranchCodeData(sender As Object, e As System.Drawing.Printing.PrintPageEventArgs)

        '// 1mm≒4.11
        Dim intYoko1 As Integer = 144   ' 横１の印刷座標（35mm）
        Dim intYoko2 As Integer = 103   ' 横２の印刷座標（25mm）
        Dim intYoko3 As Integer = 238   ' 横３の印刷座標（58mm）
        Dim intYoko4 As Integer = 349   ' 横４の印刷座標（85mm）
        Dim intYoko5 As Integer = 518   ' 横５の印刷座標（126mm）

        Dim intTate1 As Integer = 41    ' 縦１の印刷座標（10mm）
        Dim intTate2 As Integer = 61    ' 縦２の印刷座標（15mm）
        Dim intTate3 As Integer = 82    ' 縦３の印刷座標（20mm）
        Dim intTate4 As Integer = 102   ' 縦４の印刷座標（25mm）

        Dim intSTPosYoko As Integer     ' 印刷開始ポジション（横）
        Dim intSTPosTate As Integer     ' 印刷開始ポジション（縦）

        Dim intOffset As Integer        ' 文字印刷縦方向印刷オフセット
        Dim strArray() As String

        Dim N As Integer                ' 汎用ループカウンタ

        Try
            ' ヘッダーの印刷
            Dim dtNow As DateTime = DateTime.Now
            Dim t As New Font("メイリオ", 18, FontStyle.Regular)
            Dim h As New Font("メイリオ", 14, FontStyle.Regular)
            Dim f As New Font("メイリオ", 10, FontStyle.Regular)

            Dim uh As New Font("メイリオ", 14, FontStyle.Underline)
            Dim ms As New Font("ＭＳ ゴシック", 14, FontStyle.Regular)

            ' ヘッダー１行目
            e.Graphics.DrawString(Date.Now.ToString("yyyy年MM月dd日 HH時mm分ss秒"), f, Brushes.Black, intYoko1 + intYoko4, intTate1)
            ' ヘッダー２行目
            e.Graphics.DrawString("支店コード一覧", h, Brushes.Black, intYoko1, intTate2)
            e.Graphics.DrawString("【" & PubConstClass.pblMachineName & "】", f, Brushes.Black, intYoko1 + intYoko4, intTate2)
            e.Graphics.DrawString("Page " & intPrintPageIndex.ToString("0"), f, Brushes.Black, intYoko1 + intYoko5, intTate2)

            intSTPosYoko = intYoko1
            intSTPosTate = intTate4
            intOffset = 5                       ' 1.2mm
            Dim intRowHeight As Integer = 25    ' 6.1mm

            '// ヘッダー行
            intSTPosYoko = intYoko1
            e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(intSTPosYoko, intSTPosTate, intYoko2, intRowHeight))
            e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(intSTPosYoko, intSTPosTate, intYoko3, intRowHeight))
            e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(intSTPosYoko, intSTPosTate, intYoko5, intRowHeight))
            e.Graphics.DrawString("　 No．", f, Brushes.Black, intSTPosYoko, intSTPosTate + intOffset)
            e.Graphics.DrawString("　支店コード", f, Brushes.Black, intSTPosYoko + intYoko2, intSTPosTate + intOffset)
            e.Graphics.DrawString("　支店名", f, Brushes.Black, intSTPosYoko + intYoko3, intSTPosTate + intOffset)

            For N = 1 To 40
                strArray = arPrintData(N - 1 + (intPrintPageIndex - 1) * 40).ToString.Split(","c)

                e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(intSTPosYoko, intSTPosTate + intRowHeight * N, intYoko2, intRowHeight))
                e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(intSTPosYoko, intSTPosTate + intRowHeight * N, intYoko3, intRowHeight))
                e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(intSTPosYoko, intSTPosTate + intRowHeight * N, intYoko5, intRowHeight))
                e.Graphics.DrawString("　" & strArray(0), f, Brushes.Black, intSTPosYoko, intSTPosTate + intRowHeight * N + intOffset)
                e.Graphics.DrawString("　" & strArray(1), f, Brushes.Black, intSTPosYoko + intYoko2, intSTPosTate + intRowHeight * N + intOffset)
                e.Graphics.DrawString("　" & strArray(2), f, Brushes.Black, intSTPosYoko + intYoko3, intSTPosTate + intRowHeight * N + intOffset)

                intPrintDataCount -= 1
                If intPrintDataCount = 0 Then
                    Exit For
                End If

            Next N

            If intPrintDataCount > 0 Then
                e.HasMorePages = True
                intPrintPageIndex = intPrintPageIndex + 1
            Else
                e.HasMorePages = False
            End If

        Catch ex As Exception
            MsgBox("【PrintBranchCodeData】" & ex.Message)
        End Try

    End Sub


    ''' <summary>
    ''' 業務リスト印刷処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub PrintJobList(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)

        '// 1mm≒4.11
        'Dim intYoko1 As Integer = 144   ' 横１の印刷座標（35mm）
        Dim intYoko1 As Integer = 103   ' 横１の印刷座標（25mm）
        Dim intYoko2 As Integer = 103   ' 横２の印刷座標（25mm）
        'Dim intYoko3 As Integer = 238   ' 横３の印刷座標（58mm）
        Dim intYoko3 As Integer = 279   ' 横３の印刷座標（68mm）
        Dim intYoko4 As Integer = 349   ' 横４の印刷座標（85mm）
        'Dim intYoko5 As Integer = 518   ' 横５の印刷座標（126mm）
        Dim intYoko5 As Integer = 600   ' 横５の印刷座標（146mm）

        Dim intTate1 As Integer = 41    ' 縦１の印刷座標（10mm）
        Dim intTate2 As Integer = 61    ' 縦２の印刷座標（15mm）
        Dim intTate3 As Integer = 82    ' 縦３の印刷座標（20mm）
        Dim intTate4 As Integer = 102   ' 縦４の印刷座標（25mm）

        Dim intSTPosYoko As Integer     ' 印刷開始ポジション（横）
        Dim intSTPosTate As Integer     ' 印刷開始ポジション（縦）

        Dim intOffset As Integer        ' 文字印刷縦方向印刷オフセット
        Dim strArray() As String

        Dim N As Integer                ' 汎用ループカウンタ

        Try
            ' ヘッダーの印刷
            Dim dtNow As DateTime = DateTime.Now
            Dim t As New Font("メイリオ", 18, FontStyle.Regular)
            Dim h As New Font("メイリオ", 14, FontStyle.Regular)
            Dim f As New Font("メイリオ", 10, FontStyle.Regular)

            Dim uh As New Font("メイリオ", 14, FontStyle.Underline)
            Dim ms As New Font("ＭＳ ゴシック", 14, FontStyle.Regular)

            ' ヘッダー１行目
            e.Graphics.DrawString(Date.Now.ToString("yyyy年MM月dd日 HH時mm分ss秒"), f, Brushes.Black, intYoko1 + intYoko4, intTate1)
            ' ヘッダー２行目
            e.Graphics.DrawString("業務リスト一覧", h, Brushes.Black, intYoko1, intTate2)
            e.Graphics.DrawString("【" & PubConstClass.pblMachineName & "】", f, Brushes.Black, intYoko1 + intYoko4, intTate2)
            e.Graphics.DrawString("Page " & intPrintPageIndex.ToString("0"), f, Brushes.Black, intYoko1 + intYoko5, intTate2)

            intSTPosYoko = intYoko1
            intSTPosTate = intTate4
            intOffset = 5                       ' 1.2mm
            Dim intRowHeight As Integer = 25    ' 6.1mm

            '// ヘッダー行
            intSTPosYoko = intYoko1            
            'e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(intSTPosYoko, intSTPosTate, intYoko3, intRowHeight))
            'e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(intSTPosYoko, intSTPosTate, intYoko5, intRowHeight))
            'e.Graphics.DrawString("項目", f, Brushes.Black, intSTPosYoko, intSTPosTate + intOffset)
            'e.Graphics.DrawString("項目内容", f, Brushes.Black, intSTPosYoko + intYoko3, intSTPosTate + intOffset)

            For N = 1 To 30

                strArray = arPrintData(N - 1 + (intPrintPageIndex - 1) * 30).ToString.Split(","c)
                If N = 1 Or N = 16 Then
                    e.Graphics.FillRectangle(New SolidBrush(Color.LightGray), New Rectangle(intSTPosYoko, intSTPosTate + intRowHeight * N, intYoko3, intRowHeight))
                    e.Graphics.FillRectangle(New SolidBrush(Color.LightGray), New Rectangle(intSTPosYoko, intSTPosTate + intRowHeight * N, intYoko5, intRowHeight))
                End If
                e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(intSTPosYoko, intSTPosTate + intRowHeight * N, intYoko3, intRowHeight))
                e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(intSTPosYoko, intSTPosTate + intRowHeight * N, intYoko5, intRowHeight))
                e.Graphics.DrawString("　" & strArray(0), f, Brushes.Black, intSTPosYoko, intSTPosTate + intRowHeight * N + intOffset)
                e.Graphics.DrawString("　" & strArray(1), f, Brushes.Black, intSTPosYoko + intYoko3, intSTPosTate + intRowHeight * N + intOffset)

                intPrintDataCount -= 1
                If intPrintDataCount = 0 Then
                    Exit For
                End If

            Next N

            If intPrintDataCount > 0 Then
                e.HasMorePages = True
                intPrintPageIndex = intPrintPageIndex + 1
            Else
                e.HasMorePages = False
            End If

        Catch ex As Exception
            MsgBox("【PrintJobList】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CmbMasterItem_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles CmbMasterItem.SelectedIndexChanged

        If CmbMasterItem.SelectedIndex = 2 Then
            ' オペレーターは「インポート」「エクスポート」不可とする
            BtnExport.Enabled = False
            BtnInport.Enabled = False
        Else
            BtnExport.Enabled = True
            BtnInport.Enabled = True
        End If

        BtnDisplay.PerformClick()

    End Sub

End Class