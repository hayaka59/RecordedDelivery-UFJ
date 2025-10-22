<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Dlg_CaptureDevice
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Windows フォーム デザイナで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
    'Windows フォーム デザイナを使用して変更できます。  
    'コード エディタを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Btn_Cancel = New System.Windows.Forms.Button()
        Me.Btn_OK = New System.Windows.Forms.Button()
        Me.Btn_PinFormat = New System.Windows.Forms.Button()
        Me.Btn_Pin = New System.Windows.Forms.Button()
        Me.Btn_Device = New System.Windows.Forms.Button()
        Me.Cmb_Pin = New System.Windows.Forms.ComboBox()
        Me.Cmb_Device = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbl_Device = New System.Windows.Forms.Label()
        Me.Lst_Format = New System.Windows.Forms.ListBox()
        Me.Pnl_Filter = New System.Windows.Forms.Panel()
        Me.Pnl_Pin = New System.Windows.Forms.Panel()
        Me.Pnl_Format = New System.Windows.Forms.Panel()
        Me.Btn_Format = New System.Windows.Forms.Button()
        Me.Chk_SubType = New System.Windows.Forms.CheckBox()
        Me.Chk_MajorType = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Pnl_Button = New System.Windows.Forms.Panel()
        Me.Pnl_Filter.SuspendLayout()
        Me.Pnl_Pin.SuspendLayout()
        Me.Pnl_Format.SuspendLayout()
        Me.Pnl_Button.SuspendLayout()
        Me.SuspendLayout()
        '
        'Btn_Cancel
        '
        Me.Btn_Cancel.Location = New System.Drawing.Point(200, 8)
        Me.Btn_Cancel.Name = "Btn_Cancel"
        Me.Btn_Cancel.Size = New System.Drawing.Size(88, 23)
        Me.Btn_Cancel.TabIndex = 15
        Me.Btn_Cancel.Tag = ""
        Me.Btn_Cancel.Text = "キャンセル"
        Me.Btn_Cancel.UseVisualStyleBackColor = True
        '
        'Btn_OK
        '
        Me.Btn_OK.Location = New System.Drawing.Point(104, 8)
        Me.Btn_OK.Name = "Btn_OK"
        Me.Btn_OK.Size = New System.Drawing.Size(88, 23)
        Me.Btn_OK.TabIndex = 14
        Me.Btn_OK.Tag = "3"
        Me.Btn_OK.Text = "OK"
        Me.Btn_OK.UseVisualStyleBackColor = True
        '
        'Btn_PinFormat
        '
        Me.Btn_PinFormat.Location = New System.Drawing.Point(8, 8)
        Me.Btn_PinFormat.Name = "Btn_PinFormat"
        Me.Btn_PinFormat.Size = New System.Drawing.Size(88, 24)
        Me.Btn_PinFormat.TabIndex = 13
        Me.Btn_PinFormat.Tag = "3"
        Me.Btn_PinFormat.Text = "フォーマット"
        Me.Btn_PinFormat.UseVisualStyleBackColor = True
        '
        'Btn_Pin
        '
        Me.Btn_Pin.Location = New System.Drawing.Point(224, 24)
        Me.Btn_Pin.Name = "Btn_Pin"
        Me.Btn_Pin.Size = New System.Drawing.Size(64, 20)
        Me.Btn_Pin.TabIndex = 12
        Me.Btn_Pin.Tag = "3"
        Me.Btn_Pin.Text = "プロパティ"
        Me.Btn_Pin.UseVisualStyleBackColor = True
        '
        'Btn_Device
        '
        Me.Btn_Device.Location = New System.Drawing.Point(224, 24)
        Me.Btn_Device.Name = "Btn_Device"
        Me.Btn_Device.Size = New System.Drawing.Size(64, 20)
        Me.Btn_Device.TabIndex = 8
        Me.Btn_Device.Tag = "2"
        Me.Btn_Device.Text = "プロパティ"
        Me.Btn_Device.UseVisualStyleBackColor = True
        '
        'Cmb_Pin
        '
        Me.Cmb_Pin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_Pin.FormattingEnabled = True
        Me.Cmb_Pin.Location = New System.Drawing.Point(16, 24)
        Me.Cmb_Pin.Name = "Cmb_Pin"
        Me.Cmb_Pin.Size = New System.Drawing.Size(208, 20)
        Me.Cmb_Pin.TabIndex = 11
        Me.Cmb_Pin.Tag = "2"
        '
        'Cmb_Device
        '
        Me.Cmb_Device.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_Device.FormattingEnabled = True
        Me.Cmb_Device.Location = New System.Drawing.Point(16, 24)
        Me.Cmb_Device.Name = "Cmb_Device"
        Me.Cmb_Device.Size = New System.Drawing.Size(208, 20)
        Me.Cmb_Device.TabIndex = 7
        Me.Cmb_Device.Tag = "1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 12)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "出力ピン"
        '
        'lbl_Device
        '
        Me.lbl_Device.AutoSize = True
        Me.lbl_Device.Location = New System.Drawing.Point(8, 8)
        Me.lbl_Device.Name = "lbl_Device"
        Me.lbl_Device.Size = New System.Drawing.Size(43, 12)
        Me.lbl_Device.TabIndex = 9
        Me.lbl_Device.Text = "デバイス"
        '
        'Lst_Format
        '
        Me.Lst_Format.FormattingEnabled = True
        Me.Lst_Format.ItemHeight = 12
        Me.Lst_Format.Location = New System.Drawing.Point(16, 24)
        Me.Lst_Format.Name = "Lst_Format"
        Me.Lst_Format.Size = New System.Drawing.Size(272, 112)
        Me.Lst_Format.TabIndex = 16
        Me.Lst_Format.Tag = "3"
        '
        'Pnl_Filter
        '
        Me.Pnl_Filter.Controls.Add(Me.lbl_Device)
        Me.Pnl_Filter.Controls.Add(Me.Cmb_Device)
        Me.Pnl_Filter.Controls.Add(Me.Btn_Device)
        Me.Pnl_Filter.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pnl_Filter.Location = New System.Drawing.Point(0, 0)
        Me.Pnl_Filter.Name = "Pnl_Filter"
        Me.Pnl_Filter.Size = New System.Drawing.Size(297, 48)
        Me.Pnl_Filter.TabIndex = 17
        '
        'Pnl_Pin
        '
        Me.Pnl_Pin.Controls.Add(Me.Cmb_Pin)
        Me.Pnl_Pin.Controls.Add(Me.Label1)
        Me.Pnl_Pin.Controls.Add(Me.Btn_Pin)
        Me.Pnl_Pin.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pnl_Pin.Location = New System.Drawing.Point(0, 48)
        Me.Pnl_Pin.Name = "Pnl_Pin"
        Me.Pnl_Pin.Size = New System.Drawing.Size(297, 48)
        Me.Pnl_Pin.TabIndex = 18
        '
        'Pnl_Format
        '
        Me.Pnl_Format.Controls.Add(Me.Btn_Format)
        Me.Pnl_Format.Controls.Add(Me.Chk_SubType)
        Me.Pnl_Format.Controls.Add(Me.Chk_MajorType)
        Me.Pnl_Format.Controls.Add(Me.Lst_Format)
        Me.Pnl_Format.Controls.Add(Me.Label2)
        Me.Pnl_Format.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pnl_Format.Location = New System.Drawing.Point(0, 96)
        Me.Pnl_Format.Name = "Pnl_Format"
        Me.Pnl_Format.Size = New System.Drawing.Size(297, 160)
        Me.Pnl_Format.TabIndex = 18
        Me.Pnl_Format.Visible = False
        '
        'Btn_Format
        '
        Me.Btn_Format.Location = New System.Drawing.Point(200, 136)
        Me.Btn_Format.Name = "Btn_Format"
        Me.Btn_Format.Size = New System.Drawing.Size(88, 23)
        Me.Btn_Format.TabIndex = 18
        Me.Btn_Format.Tag = "3"
        Me.Btn_Format.Text = "変更"
        Me.Btn_Format.UseVisualStyleBackColor = True
        '
        'Chk_SubType
        '
        Me.Chk_SubType.AutoSize = True
        Me.Chk_SubType.Checked = True
        Me.Chk_SubType.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Chk_SubType.Location = New System.Drawing.Point(120, 136)
        Me.Chk_SubType.Name = "Chk_SubType"
        Me.Chk_SubType.Size = New System.Drawing.Size(72, 16)
        Me.Chk_SubType.TabIndex = 17
        Me.Chk_SubType.Text = "Sub Type"
        Me.Chk_SubType.UseVisualStyleBackColor = True
        '
        'Chk_MajorType
        '
        Me.Chk_MajorType.AutoSize = True
        Me.Chk_MajorType.Checked = True
        Me.Chk_MajorType.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Chk_MajorType.Location = New System.Drawing.Point(16, 136)
        Me.Chk_MajorType.Name = "Chk_MajorType"
        Me.Chk_MajorType.Size = New System.Drawing.Size(81, 16)
        Me.Chk_MajorType.TabIndex = 17
        Me.Chk_MajorType.Text = "Major Type"
        Me.Chk_MajorType.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 12)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "出力フォーマット"
        '
        'Pnl_Button
        '
        Me.Pnl_Button.Controls.Add(Me.Btn_Cancel)
        Me.Pnl_Button.Controls.Add(Me.Btn_PinFormat)
        Me.Pnl_Button.Controls.Add(Me.Btn_OK)
        Me.Pnl_Button.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pnl_Button.Location = New System.Drawing.Point(0, 256)
        Me.Pnl_Button.Name = "Pnl_Button"
        Me.Pnl_Button.Size = New System.Drawing.Size(297, 40)
        Me.Pnl_Button.TabIndex = 19
        '
        'Dlg_CaptureDevice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(297, 307)
        Me.Controls.Add(Me.Pnl_Button)
        Me.Controls.Add(Me.Pnl_Format)
        Me.Controls.Add(Me.Pnl_Pin)
        Me.Controls.Add(Me.Pnl_Filter)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Dlg_CaptureDevice"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "DlgCaptureDevice"
        Me.Pnl_Filter.ResumeLayout(False)
        Me.Pnl_Filter.PerformLayout()
        Me.Pnl_Pin.ResumeLayout(False)
        Me.Pnl_Pin.PerformLayout()
        Me.Pnl_Format.ResumeLayout(False)
        Me.Pnl_Format.PerformLayout()
        Me.Pnl_Button.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Btn_Cancel As System.Windows.Forms.Button
    Friend WithEvents Btn_OK As System.Windows.Forms.Button
    Friend WithEvents Btn_PinFormat As System.Windows.Forms.Button
    Friend WithEvents Btn_Pin As System.Windows.Forms.Button
    Friend WithEvents Btn_Device As System.Windows.Forms.Button
    Friend WithEvents Cmb_Pin As System.Windows.Forms.ComboBox
    Friend WithEvents Cmb_Device As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbl_Device As System.Windows.Forms.Label
    Friend WithEvents Lst_Format As System.Windows.Forms.ListBox
    Friend WithEvents Pnl_Filter As System.Windows.Forms.Panel
    Friend WithEvents Pnl_Pin As System.Windows.Forms.Panel
    Friend WithEvents Pnl_Format As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Pnl_Button As System.Windows.Forms.Panel
    Friend WithEvents Chk_SubType As System.Windows.Forms.CheckBox
    Friend WithEvents Chk_MajorType As System.Windows.Forms.CheckBox
    Friend WithEvents Btn_Format As System.Windows.Forms.Button

End Class
