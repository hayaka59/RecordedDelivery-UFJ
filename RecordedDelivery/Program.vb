Module Program

    Sub Main()
        ' 任意のフォームを起動
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        ' 最初に起動するフォーム
        Application.Run(New OperatorInputForm())
    End Sub

End Module
