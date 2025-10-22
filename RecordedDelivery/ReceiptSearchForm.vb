Option Explicit On
Option Strict On

Public Class ReceiptSearchForm


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub RecieptSearchForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim col(5) As String
        Dim itm As ListViewItem

        Try
            ' ListViewのカラムヘッダー設定
            lstSearchDataView.View = View.Details
            Dim col1 As ColumnHeader = New ColumnHeader
            Dim col2 As ColumnHeader = New ColumnHeader
            Dim col3 As ColumnHeader = New ColumnHeader
            Dim col4 As ColumnHeader = New ColumnHeader
            Dim col5 As ColumnHeader = New ColumnHeader

            col1.Text = "　 No"
            col2.Text = "処理日"
            col3.Text = "支店コード"
            col4.Text = "処理通数"
            col5.Text = "種別"

            col1.Width = 80
            col2.Width = 150
            col3.Width = 100
            col4.Width = 100
            col5.Width = 200

            Dim colHeader() As ColumnHeader = {col1, col2, col3, col4, col5}
            lstSearchDataView.Columns.AddRange(colHeader)

            For N = 1 To 10
                col(0) = " " & N.ToString("0")
                col(1) = Date.Now.ToString("yyyy年MM月dd日")
                col(2) = "1234-56"
                col(3) = "999"
                col(4) = "ゆうメール"
                itm = New ListViewItem(col)
                lstSearchDataView.Items.Add(itm)

            Next

            lstSearchDataView.Items(lstSearchDataView.Items.Count - 1).Selected = True
            lstSearchDataView.Items(lstSearchDataView.Items.Count - 1).Focused = True
            lstSearchDataView.Select()
            lstSearchDataView.Items(lstSearchDataView.Items.Count - 1).EnsureVisible()


        Catch ex As Exception
            MsgBox("【RecieptSearchForm_Load】" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBack.Click

        Me.Hide()

    End Sub

End Class