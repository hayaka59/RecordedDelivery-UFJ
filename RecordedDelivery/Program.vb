Module Program

    Sub Main()
        ' 任意のフォームを起動
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        Application.Run(New OperatorInputForm()) ' ← 起動したいフォームに変更
    End Sub

End Module
