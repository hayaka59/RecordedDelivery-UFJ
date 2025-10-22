Option Explicit On
Option Strict On

Imports System.Windows.Forms
Imports System.Runtime.InteropServices


'//////////////////////////////////////////////////////////////
'�L���v�`���f�o�C�X�I���_�C�A���O
'//////////////////////////////////////////////////////////////
Public Class Dlg_CaptureDevice

    '----------------------------------------------------------

    '����J�f�[�^
    Private mGrp As IGraphBuilder
    Private mFlt As IBaseFilter
    Private mPin As IPin
    Private mSelectedDeviceName As String

    '----------------------------------------------------------

    '�t�H�[�����[�h��
    Private Sub Dlg_CaptureDevice_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Start()
    End Sub

    '�A�N�e�B�u��
    Private Sub Dlg_CaptureDevice_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        ResizeWindow()
    End Sub

    '�t�H�[���T�C�Y�̒���
    Private Sub ResizeWindow()
        Me.ClientSize = New Size(Me.ClientSize.Width, Pnl_Button.Bottom)
    End Sub

    '----------------------------------------------------------
    '�O�����J�v���p�e�B

    '�O���t
    Public ReadOnly Property Graph() As IGraphBuilder
        Get
            Return mGrp
        End Get
    End Property

    '�t�B���^
    Public ReadOnly Property Filter() As IBaseFilter
        Get
            Return mFlt
        End Get
    End Property

    '�s��
    Public ReadOnly Property Pin() As IPin
        Get
            Return mPin
        End Get
    End Property

    '----------------------------------------------------------

    'OK�{�^��������
    Private Sub Btn_OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_OK.Click

        '����(����)
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub

    '�L�����Z���{�^��������
    Private Sub Btn_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cancel.Click

        '�I���̃L�����Z��
        ReleaseGraph()

        '����(���s)
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub

    '�f�o�C�X�I����
    Private Sub Cmb_Device_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmb_Device.SelectedIndexChanged
        SelectDevice()
    End Sub

    '�s���I����
    Private Sub Cmb_Pin_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmb_Pin.SelectedIndexChanged
        SelectPin()
    End Sub

    '�f�o�C�X�v���p�e�B�{�^��������
    Private Sub Btn_Device_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Device.Click
        If mFlt Is Nothing Then Exit Sub

        '�v���p�e�B�_�C�A���O�\��
        If OpenDiaglog(mFlt, Me.Handle, mSelectedDeviceName) Then
            MsgBox("�v���p�e�B�y�[�W�͎g�p�ł��܂���B")
        End If
    End Sub

    '�s���v���p�e�B�{�^��������
    Private Sub Btn_Pin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Pin.Click
        If mPin Is Nothing Then Exit Sub

        '�v���p�e�B�_�C�A���O�\��
        If OpenDiaglog(mPin, Me.Handle, GetPinName(mPin)) Then
            MsgBox("�v���p�e�B�y�[�W�͎g�p�ł��܂���B")
        Else
            '���݂̃t�H�[�}�b�g���ύX���ꂽ�\��������

            '�t�H�[�}�b�g���X�g�X�V
            If Pnl_Format.Visible Then
                MakeFormatList()
            End If
        End If

    End Sub

    '�t�H�[�}�b�g�{�^������
    Private Sub Btn_PinFormat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_PinFormat.Click
        Pnl_Format.Visible = Not Pnl_Format.Visible
        ResizeWindow()

        If Pnl_Format.Visible Then
            MakeFormatList()
        End If

    End Sub

    '���W���[�^�C�v�ύX��
    Private Sub Chk_MajorType_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_MajorType.CheckedChanged
        MakeFormatList()
    End Sub

    '�}�C�i�[�^�C�v�ύX��
    Private Sub Chk_SubType_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_SubType.CheckedChanged
        MakeFormatList()
    End Sub

    '�t�H�[�}�b�g�ύX�{�^��������
    Private Sub Btn_Format_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Format.Click

        Dim idx As Integer = Lst_Format.SelectedIndex
        OutPutLogFile("�ύX�{�^�������yLst_Format.SelectedIndex�z" & Lst_Format.SelectedIndex)
        If idx < 0 Then
            MsgBox("�t�H�[�}�b�g��I�����ĉ������B")
            Exit Sub
        End If

        '�t�H�[�}�b�g�ύX
        ChangeFormat(idx)

        '���X�g�č쐬
        MakeFormatList()

    End Sub

    '----------------------------------------------------------

    '�I���J�n
    Private Sub Start()

        '������
        ReleaseGraph()
        Cmb_Device.Items.Clear()
        Cmb_Pin.Items.Clear()
        Lst_Format.Items.Clear()
        'ControlEnable("1", False)
        'ControlEnable("2", False)
        'ControlEnable("3", False)
        ControlEnable("1", True)
        ControlEnable("2", True)
        ControlEnable("3", True)

        '�f�o�C�X���X�g�̍쐬
        MakeDeviceList()

        '�I���J�n
        ControlEnable("1", True)

    End Sub

    '�R���g���[���̗L���^�����؂�ւ�
    Private Sub ControlEnable(ByVal TagName As String, ByVal Flag As Boolean, Optional ByVal Owner As Control.ControlCollection = Nothing)

        If Owner Is Nothing Then Owner = Me.Controls
        For Each ctl As Control In Owner

            If CStr(ctl.Tag) = TagName Then
                ctl.Enabled = Flag
            End If

            If Not ctl.Controls Is Nothing Then
                ControlEnable(TagName, Flag, ctl.Controls)
            End If

        Next
    End Sub

    '----------------------------------------------------------

    '�f�o�C�X���X�g�̍쐬
    Private Sub MakeDeviceList()

        '���݂̃��X�g���N���A
        Cmb_Device.Items.Clear()

        Try
            '�J�����f�o�C�X�̗�
            Dim devs As Collection
            devs = EnumFilters(GUIDString.FilterCategory.CLSID_VideoInputDeviceCategory)

            '���X�g�쐬
            For Each obj As Object In devs
                Dim fi As FILTERINFORMATION = CType(obj, FILTERINFORMATION)
                Cmb_Device.Items.Add(fi.Name)
                OutPutLogFile("MakeDeviceList�yfi.Name�z" & fi.Name)
            Next
            ' 2015.04.17 hayakawa �ǉ�
            Cmb_Device.SelectedIndex = 0

        Catch ex As Exception
            MsgBox("�f�o�C�X�̗񋓒��ɖ�肪�������܂����B" + vbCrLf + "���R�F" + ex.Message)
        End Try

    End Sub

    '�s�����X�g�̍쐬
    Private Sub MakePinList()

        '���݂̃��X�g���N���A
        Cmb_Pin.Items.Clear()

        Try
            '�s���̗�
            Dim pins As Collection
            pins = EnumPins(mFlt)

            '���X�g�쐬
            For Each obj As Object In pins
                Dim pi As PININFORMATION = CType(obj, PININFORMATION)
                Cmb_Pin.Items.Add(pi.Name)
            Next

        Catch ex As Exception
            MsgBox("�s���̗񋓒��ɖ�肪�������܂����B" + vbCrLf + "���R�F" + ex.Message)
        End Try

    End Sub

    '�t�H�[�}�b�g���X�g�̍쐬
    Private Sub MakeFormatList()

        '�N���A
        Lst_Format.Items.Clear()

        Dim mt As AMMediaType = Nothing
        Try

            '��
            If mPin Is Nothing Then Exit Sub
            Dim fmts As Collection = EnumFormat(mPin)

            '���݂̃t�H�[�}�b�g�擾
            mt = GetFormat(mPin)
            Dim vinfo As New DSVIDEOINFOHEADER
            vinfo = PtrToStructure(Of DSVIDEOINFOHEADER)(mt.formatPtr)
            Dim sz As New Size(vinfo.BmiHeader.Width, vinfo.BmiHeader.Height)

            '���X�g�쐬
            Dim ss As New System.Text.StringBuilder
            For Each v As FORMATINFORMATION In fmts

                '���W���[�^�C�v�ƃ}�C�i�[�^�C�v�̕ҏW
                ss.Length = 0
                If Chk_MajorType.Checked Then ss.AppendFormat("{0} ", GetMediaTypeName(v.MajorType.ToString))
                If Chk_SubType.Checked Then ss.AppendFormat("{0} ", GetMediaTypeName(v.SubType.ToString))

                '�T�C�Y�̕ҏW
                If CompGUIDString(v.FormatType.ToString, GUIDString.FormatType.FORMAT_VideoInfo) Then
                    '�摜�`��
                    ss.AppendFormat("{0} x {1}", v.Size.Width, v.Size.Height)
                Else
                    '�f���`���łȂ�
                    ss.AppendFormat("unsupport format")
                End If

                '���X�g�ɒǉ�
                Lst_Format.Items.Add(ss.ToString)

                '���݂̃t�H�[�}�b�g���H
                If v.MajorType.Equals(mt.majorType) Then
                    If v.SubType.Equals(mt.subType) Then
                        If v.FormatType.Equals(mt.formatType) Then
                            If (v.Size.Width = sz.Width) And (v.Size.Height = sz.Height) Then
                                '���݂̃t�H�[�}�b�g�ł���

                                '�I������
                                Lst_Format.SelectedItem = Lst_Format.Items(Lst_Format.Items.Count - 1)
                            End If
                        End If
                    End If
                End If
            Next

        Catch ex As Exception
            MsgBox("�t�H�[�}�b�g�̗񋓒��ɖ�肪�������܂����B" + vbCrLf + "���R�F" + ex.Message)

        Finally
            If Not mt Is Nothing Then
                DeleteMediaType(mt)
            End If

        End Try

    End Sub

    '----------------------------------------------------------

    '�s���̉��
    Private Sub ReleasePin()

        If Not mPin Is Nothing Then
            Marshal.ReleaseComObject(mPin)
            mPin = Nothing
        End If

    End Sub

    '�t�B���^���
    Private Sub ReleaseFilter()

        '�s���̉��
        ReleasePin()

        '�t�B���^���
        If Not mFlt Is Nothing Then
            Marshal.ReleaseComObject(mFlt)
            mFlt = Nothing
        End If
        mSelectedDeviceName = ""

    End Sub

    '�O���t���
    Private Sub ReleaseGraph()

        '�s���E�t�B���^���
        ReleaseFilter()

        '�O���t���
        If Not mGrp Is Nothing Then
            Marshal.ReleaseComObject(mGrp)
            mGrp = Nothing
        End If

    End Sub

    '----------------------------------------------------------

    '�f�o�C�X�̑I��
    Private Sub SelectDevice()

        Try

            '���݂̃O���t���
            ReleaseGraph()

            '�I���f�o�C�X�̎擾
            If Cmb_Device.SelectedItem Is Nothing Then
                '�f�o�C�X���I������Ă��Ȃ�
                ControlEnable("2", False)
                ControlEnable("3", False)
                Exit Sub
            End If
            mSelectedDeviceName = CStr(Cmb_Device.SelectedItem)

            '�����̃f�o�C�X�����݂���\�������邽��
            '���Ԗڂ̃f�o�C�X�ł��邩�𒲍�
            Dim selidx As Integer = Cmb_Device.SelectedIndex
            Dim skp As Integer = 0  '�X�L�b�v���i���������铯���̃f�o�C�X���j
            For x As Integer = 0 To Cmb_Device.Items.Count - 1
                If CStr(Cmb_Device.Items(x)) = mSelectedDeviceName Then
                    If selidx <> x Then
                        skp += 1    '�I�������f�o�C�X�ȊO�œ����̃f�o�C�X�ł���
                    Else
                        Exit For    '�I�������f�o�C�X
                    End If
                End If
            Next

            '�O���t����
            mGrp = CreateNewGraph()

            System.Console.WriteLine("��mSelectedDeviceName�F" + mSelectedDeviceName)

            '�O���t�Ƀt�B���^��ǉ�
            mFlt = AddFilter(mGrp, GUIDString.FilterCategory.CLSID_VideoInputDeviceCategory, mSelectedDeviceName, skp, "")
            If mFlt Is Nothing Then
                Throw New Exception("�I�������f�o�C�X�͎g�p�ł��܂���B")
            End If

            '�s�����X�g�̍쐬
            MakePinList()
            If Cmb_Pin.Items.Count = 0 Then
                Throw New Exception("���p�\�ȏo�̓s��������܂���B")
            End If

            '�f�t�H���g�Ő擪�̃s����I��
            ControlEnable("2", True)
            Cmb_Pin.SelectedIndex = 0

        Catch ex As Exception
            MsgBox(ex.Message)

            '�N���A
            Start()
        End Try

    End Sub

    '�s���̑I��
    Private Sub SelectPin()

        '��ԃ`�F�b�N
        If (mGrp Is Nothing) OrElse (mFlt Is Nothing) Then Exit Sub

        '�s���̑I��
        mPin = FindPin(mFlt, Cmb_Pin.Text)

        System.Console.WriteLine("��Cmb_Pin.Text�F" + Cmb_Pin.Text)

        If mPin Is Nothing Then
            ControlEnable("3", False)
        Else
            '�I������
            ControlEnable("3", True)
        End If

        '�t�H�[�}�b�g���X�g�X�V
        If Pnl_Format.Visible Then
            MakeFormatList()
        End If

    End Sub

    '----------------------------------------------------------

    '�t�H�[�}�b�g�̕ύX
    Private Sub ChangeFormat(ByVal Index As Integer)

        '�`�F�b�N
        If mPin Is Nothing Then Exit Sub

        '�t�H�[�}�b�g�擾
        Dim mt As AMMediaType = Nothing
        mt = GetFormat(mPin, Index)

        '�t�H�[�}�b�g�ݒ�
        SetFormat(mPin, mt)

    End Sub

End Class
