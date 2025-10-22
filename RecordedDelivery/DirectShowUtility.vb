Option Explicit On
Option Strict On

'//////////////////////////////////////////////////////////
'DirectShow�֌W�̃��[�e�B���e�B���W���[��
'//////////////////////////////////////////////////////////

Imports System
Imports System.ComponentModel
Imports System.Runtime.InteropServices

Public Module DirectShowUtility

    '//////////////////////////////////////////////////////////
    '//////////////////////////////////////////////////////////
    '�ėp�֐�
#Region "�ėp�֐�"

    '�C���X�^���X�̍쐬
    '����
    '�@CLSIDString              �쐬����C���X�^���X��GUID������
    '�߂�l
    '�@�������ꂽ�C���X�^���X
    Public Function CoCreateInstance(ByVal CLSIDString As String) As Object

        Dim comobj As Object = Nothing
        Try
            '�N���XID
            Dim cid As Guid
            cid = New Guid(CLSIDString)

            '�^�C�v�擾
            Dim comtype As Type
            comtype = Type.GetTypeFromCLSID(cid)

            '�C���X�^���X��
            comobj = Activator.CreateInstance(comtype)

        Catch ex As Exception
            Trace.WriteLine("�C���X�^���X���쐬�ł��܂���B- " + CLSIDString)
            Throw

        End Try

        Return comobj
    End Function

    '�C���X�^���X�̊J��
    '����
    '�@Obj                      �������COM�I�u�W�F�N�g
    Public Sub ReleaseInstance(Of ObjType)(ByRef Obj As ObjType)
        If Not Obj Is Nothing Then
            Marshal.ReleaseComObject(Obj)
            Obj = Nothing
        End If
    End Sub

    '�|�C���^����e�^�f�[�^�̎擾
    '�E�A���}�l�[�W�̈�̃f�[�^���}�l�[�W�̈�ɃR�s�[
    Public Function PtrToStructure(Of DataType)(ByVal Ptr As IntPtr) As DataType
        Return CType(Marshal.PtrToStructure(Ptr, GetType(DataType)), DataType)
    End Function

#End Region

    '//////////////////////////////////////////////////////////
    '//////////////////////////////////////////////////////////
    '�f�o�b�O�p�֐�
#Region "�f�o�b�O�p"

    '�O���t�̓��e���R���\�[���ɏo��
    '����
    '�@Graph                    �ΏۃO���t
    Public Sub DebugPrint(ByVal Graph As IGraphBuilder)

        '���O�`�F�b�N
        If Graph Is Nothing Then Exit Sub

        '�t�B���^�񋓎q�擾
        Dim eflt As IEnumFilters = Nothing
        Graph.EnumFilters(eflt)

        '�t�B���^��
        Dim fc As Integer
        Dim flt As IBaseFilter = Nothing
        Do While eflt.Next(1, flt, fc) = 0

            '�t�B���^���̎擾
            Dim finfo As New FILTER_INFO
            Dim fltname As String = "(�s���ȃt�B���^)"
            If flt.QueryFilterInfo(finfo) = 0 Then
                fltname = finfo.achName
                ReleaseInstance(finfo.pUnk)
            End If

            '�t�B���^���\��
            System.Console.WriteLine("[{0}]", fltname)

            '�s���񋓎q�擾
            Dim epin As IEnumPins = Nothing
            flt.EnumPins(epin)

            '�s����
            Dim pc As Integer
            Dim pin As IPin = Nothing
            Do While epin.Next(1, pin, pc) = 0

                '�s�����擾
                Dim pinfo As New PIN_INFO
                If pin.QueryPinInfo(pinfo) = 0 Then

                    '�s�����o��
                    System.Console.Write("  '{0}' ", pinfo.Name)
                    Select Case pinfo.PinDir
                        Case PinDirection.Input
                            System.Console.Write(" <== ")
                        Case PinDirection.Output
                            System.Console.Write(" ==> ")
                        Case Else
                            System.Console.Write(" ??? ")
                    End Select

                    '�ڑ���擾
                    Dim cpin As IPin = Nothing
                    pin.ConnectedTo(cpin)
                    If Not cpin Is Nothing Then
                        '�ڑ��ς݂̃s��

                        '�ڑ���s���̏��擾
                        Dim cpinfo As New PIN_INFO
                        If cpin.QueryPinInfo(cpinfo) = 0 Then

                            '�ڑ���s�����o��
                            System.Console.Write("'{0}'@", cpinfo.Name)

                            '�ڑ���t�B���^�̏��擾
                            Dim cfinfo As New FILTER_INFO
                            If cpinfo.Filter.QueryFilterInfo(cfinfo) = 0 Then
                                ReleaseInstance(finfo.pUnk)
                                System.Console.Write("[{0}]", cfinfo.achName)
                            Else
                                System.Console.Write("(�s���ȃt�B���^)")
                            End If

                            '�ڑ���s����񒆂̃t�B���^�����
                            If Not cpinfo.Filter Is Nothing Then Marshal.ReleaseComObject(cpinfo.Filter)

                            '�ڑ���s���̉��
                            Marshal.ReleaseComObject(cpin)
                        Else
                            System.Console.Write("(�s���ȃs��)")
                        End If

                    End If

                    System.Console.WriteLine()

                    '�s����񒆂̃t�B���^�����
                    If Not pinfo.Filter Is Nothing Then Marshal.ReleaseComObject(pinfo.Filter)
                End If

                '�s�����
                Marshal.ReleaseComObject(pin)
            Loop


            '�t�B���^���
            Marshal.ReleaseComObject(flt)
        Loop

        '�t�B���^�񋓏I��
        Marshal.ReleaseComObject(eflt)

    End Sub

    '�O���t��GRF�t�@�C���ɕۑ�
    '����
    '�@Grp                      �ۑ�����O���t��IGraphBuilder
    '�@Filename                 GRF�t�@�C����
    Public Sub SaveGraphFile(ByRef Grp As IGraphBuilder, ByVal Filename As String)
        Dim ps As IPersistStream = Nothing
        Dim grpstr As IStorage = Nothing
        Dim strm As System.Runtime.InteropServices.ComTypes.IStream = Nothing

        Try
            'IPresistStream�C���^�[�t�F�[�X�̎擾
            ps = CType(Grp, IPersistStream)

            'IStorage�I�u�W�F�N�g�쐬
            Win32API.StgCreateDocfile(Filename, STGM.STGM_CREATE Or STGM.STGM_TRANSACTED Or STGM.STGM_READWRITE Or STGM.STGM_SHARE_EXCLUSIVE, 0, grpstr)

            '�X�g���[���쐬
            grpstr.CreateStream("ActiveMovieGraph", STGM.STGM_WRITE Or STGM.STGM_CREATE Or STGM.STGM_SHARE_EXCLUSIVE, 0, 0, strm)

            '�O���t�ۑ�
            ps.Save(strm, True)

            '�t�@�C���ɏo��
            grpstr.Commit(0)

        Catch ex As Exception
            '���s
            Throw

        Finally
            '�s�v�ƂȂ����I�u�W�F�N�g�̊J��

            If Not ps Is Nothing Then
                Marshal.ReleaseComObject(ps)
                ps = Nothing
            End If

            If Not grpstr Is Nothing Then
                Marshal.ReleaseComObject(grpstr)
                grpstr = Nothing
            End If

            If Not strm Is Nothing Then
                Marshal.ReleaseComObject(strm)
                strm = Nothing
            End If
        End Try

    End Sub

    'GRF�t�@�C������O���t��ǂݍ���
    '����
    '�@Filename                 GRF�t�@�C����
    '�߂�l
    '�@�ǂݍ��܂ꂽ�O���t��IGraphBuilder
    Public Function LoadGraphFilte(ByVal Filename As String) As IGraphBuilder

        '�N���X�h�c����
        Dim FilterGraphManagerClassID As Guid
        FilterGraphManagerClassID = New Guid(GUIDString.CLSID_FilterGraph)

        '�^�C�v�̎擾
        Dim FilterGraphManagerType As Type
        FilterGraphManagerType = Type.GetTypeFromCLSID(FilterGraphManagerClassID)

        '�t�B���^�O���t�}�l�[�W���̃C���X�^���X�쐬
        Dim FilterGraphManagerObject As Object
        FilterGraphManagerObject = Activator.CreateInstance(FilterGraphManagerType)

        'IGraphBuilder�C���^�[�t�F�[�X�̎擾
        Dim newgrp As IGraphBuilder
        newgrp = CType(FilterGraphManagerObject, IGraphBuilder)

        Dim grpstr As IStorage = Nothing
        Dim ps As IPersistStream = Nothing
        Dim strm As System.Runtime.InteropServices.ComTypes.IStream = Nothing
        Try
            '(���ʂ�)�t�@�C���ł��邩�`�F�b�N
            If Win32API.StgIsStorageFile(Filename) <> 0 Then Return Nothing

            'IStorage�I�u�W�F�N�g�쐬
            Win32API.StgOpenStorage(Filename, Nothing, STGM.STGM_TRANSACTED Or STGM.STGM_READ Or STGM.STGM_SHARE_DENY_WRITE, Nothing, 0, grpstr)

            'IPresistStream�C���^�[�t�F�[�X�̎擾
            ps = CType(newgrp, IPersistStream)

            '�X�g���[���쐬
            grpstr.OpenStream("ActiveMovieGraph", Nothing, STGM.STGM_READ Or STGM.STGM_SHARE_EXCLUSIVE, 0, strm)

            '�Ǎ�
            ps.Load(strm)

        Catch ex As Exception
            '���s

            If Not newgrp Is Nothing Then
                Marshal.ReleaseComObject(newgrp)
                newgrp = Nothing
            End If

            Throw

        Finally
            '�s�v�ƂȂ����I�u�W�F�N�g�̊J��

            If Not grpstr Is Nothing Then
                Marshal.ReleaseComObject(grpstr)
                grpstr = Nothing
            End If

            If Not ps Is Nothing Then
                Marshal.ReleaseComObject(ps)
                ps = Nothing
            End If

            If Not strm Is Nothing Then
                Marshal.ReleaseComObject(strm)
                strm = Nothing
            End If

        End Try

        Return newgrp
    End Function

#End Region

    '//////////////////////////////////////////////////////////
    '//////////////////////////////////////////////////////////
    '��O�֌W
#Region "��O�֌W"

    'DirectShow�֘A�̃G���[���b�Z�[�W�擾
    '����
    '�@ResultCode               ���^�[���R�[�h
    '�߂�l
    '�@���^�[���R�[�h�ɑΉ��������b�Z�[�W
    Public Function GetDirectShowMessage(ByVal ResultCode As Integer) As String
        Return GetDirectShowMessage(CType(ResultCode, DirectShowHRESULT))
    End Function
    Public Function GetDirectShowMessage(ByVal ResultCode As DirectShowHRESULT) As String
        Dim mes As String

        Select Case ResultCode
            Case DirectShowHRESULT.VFW_E_INVALIDMEDIATYPE : mes = "�w�肳�ꂽ���f�B�A �^�C�v�͖����ł���B"        '= &H80040200
            Case DirectShowHRESULT.VFW_E_INVALIDSUBTYPE : mes = "�w�肳�ꂽ���f�B�A �T�u�^�C�v�͖����ł���B"      '= &H80040201
            Case DirectShowHRESULT.VFW_E_NEED_OWNER : mes = "���̃I�u�W�F�N�g�͏W���I�u�W�F�N�g�Ƃ��Ă̂ݍ쐬�ł���B"        '= &H80040202
            Case DirectShowHRESULT.VFW_E_ENUM_OUT_OF_SYNC : mes = "�񋓃I�u�W�F�N�g�̏�Ԃ��ω����āA�񋓎q�̏�ԂƂ̖��������������B"       '= &H80040203
            Case DirectShowHRESULT.VFW_E_ALREADY_CONNECTED : mes = "�����Ɋ܂܂��s�������ɏ��Ȃ��Ƃ� 1 �ڑ�����Ă���B"       '= &H80040204
            Case DirectShowHRESULT.VFW_E_FILTER_ACTIVE : mes = "�t�B���^���A�N�e�B�u�Ȃ̂ŁA���̏��������s�ł��Ȃ��B"      '= &H80040205
            Case DirectShowHRESULT.VFW_E_NO_TYPES : mes = "�w�肳�ꂽ�����ꂩ�̃s�������f�B�A �^�C�v���T�|�[�g���Ă��Ȃ��B"        '= &H80040206
            Case DirectShowHRESULT.VFW_E_NO_ACCEPTABLE_TYPES : mes = "�����̃s���ɋ��ʂ̃��f�B�A �^�C�v���Ȃ��B"      '= &H80040207
            Case DirectShowHRESULT.VFW_E_INVALID_DIRECTION : mes = "���������̃s���� 2 �ڑ����邱�Ƃ͂ł��Ȃ��B"        '= &H80040208
            Case DirectShowHRESULT.VFW_E_NOT_CONNECTED : mes = "�s�����ڑ�����Ă��Ȃ����߁A���������s�ł��Ȃ��B"        '= &H80040209
            Case DirectShowHRESULT.VFW_E_NO_ALLOCATOR : mes = "�T���v�� �o�b�t�@ �A���P�[�^�����p�s�\�B"      '= &H8004020A
            Case DirectShowHRESULT.VFW_E_RUNTIME_ERROR : mes = "���s���G���[�����������B"        '= &H8004020B
            Case DirectShowHRESULT.VFW_E_BUFFER_NOTSET : mes = "�o�b�t�@��Ԃ��ݒ肳��Ă��Ȃ��B"        '= &H8004020C
            Case DirectShowHRESULT.VFW_E_BUFFER_OVERFLOW : mes = "�o�b�t�@�̑傫��������Ȃ��B"      '= &H8004020D
            Case DirectShowHRESULT.VFW_E_BADALIGN : mes = "�����ȃA���C�������g���w�肳�ꂽ�B"       '= &H8004020E
            Case DirectShowHRESULT.VFW_E_ALREADY_COMMITTED : mes = "�A���P�[�^�̓R�~�b�g����Ȃ������B�uIMemAllocator::Commit�v���Q�Ƃ��邱�ƁB"        '= &H8004020F
            Case DirectShowHRESULT.VFW_E_BUFFERS_OUTSTANDING : mes = "1 �܂��͕����̃o�b�t�@���A�N�e�B�u�ł���B"     '= &H80040210
            Case DirectShowHRESULT.VFW_E_NOT_COMMITTED : mes = "�A���P�[�^���A�N�e�B�u�łȂ��Ƃ��̓T���v�������蓖�Ă邱�Ƃ��ł��Ȃ��B"     '= &H80040211
            Case DirectShowHRESULT.VFW_E_SIZENOTSET : mes = "�T�C�Y���ݒ肳��Ă��Ȃ��̂ŁA�����������蓖�Ă邱�Ƃ��ł��Ȃ��B"        '= &H80040212
            Case DirectShowHRESULT.VFW_E_NO_CLOCK : mes = "�N���b�N����`����Ă��Ȃ��̂ŁA�������s���Ȃ��B"        '= &H80040213
            Case DirectShowHRESULT.VFW_E_NO_SINK : mes = "�i���V���N����`����Ă��Ȃ��̂ŁA�i�����b�Z�[�W�𑗐M�ł��Ȃ��B"        '= &H80040214
            Case DirectShowHRESULT.VFW_E_NO_INTERFACE : mes = "�K�v�ȃC���^�[�t�F�C�X����������Ă��Ȃ��B"       '= &H80040215
            Case DirectShowHRESULT.VFW_E_NOT_FOUND : mes = "�I�u�W�F�N�g�܂��͖��O��������Ȃ������B"       '= &H80040216
            Case DirectShowHRESULT.VFW_E_CANNOT_CONNECT : mes = "�ڑ����m�����钆�ԃt�B���^�̑g�ݍ��킹��������Ȃ������B"       '= &H80040217
            Case DirectShowHRESULT.VFW_E_CANNOT_RENDER : mes = "�X�g���[���������_�����O����t�B���^�̑g�ݍ��킹��������Ȃ������B"      '= &H80040218
            Case DirectShowHRESULT.VFW_E_CHANGING_FORMAT : mes = "�t�H�[�}�b�g�𓮓I�ɕύX�ł��Ȃ��B"       '= &H80040219
            Case DirectShowHRESULT.VFW_E_NO_COLOR_KEY_SET : mes = "�J���[ �L�[���ݒ肳��Ă��Ȃ��B"        '= &H8004021A
            Case DirectShowHRESULT.VFW_E_NOT_OVERLAY_CONNECTION : mes = "���݂̃s���ڑ��� IOverlay �]�����g���Ă��Ȃ��B"        '= &H8004021B
            Case DirectShowHRESULT.VFW_E_NOT_SAMPLE_CONNECTION : mes = "���݂̃s���ڑ��� IMemInputPin �]�����g���Ă��Ȃ��B"        '= &H8004021C
            Case DirectShowHRESULT.VFW_E_PALETTE_SET : mes = "�J���[ �L�[��ݒ肷��ƁA���ɐݒ肳��Ă���p���b�g�Ɩ�������\��������B"      '= &H8004021D
            Case DirectShowHRESULT.VFW_E_COLOR_KEY_SET : mes = "�p���b�g��ݒ肷��ƁA���ɐݒ肳��Ă���J���[ �L�[�Ɩ�������\��������B"      '= &H8004021E
            Case DirectShowHRESULT.VFW_E_NO_COLOR_KEY_FOUND : mes = "��v����J���[ �L�[���Ȃ��B"      '= &H8004021F
            Case DirectShowHRESULT.VFW_E_NO_PALETTE_AVAILABLE : mes = "�p���b�g�����p�s�\�B"     '= &H80040220
            Case DirectShowHRESULT.VFW_E_NO_DISPLAY_PALETTE : mes = "�f�B�X�v���C�̓p���b�g���g��Ȃ��B"       '= &H80040221
            Case DirectShowHRESULT.VFW_E_TOO_MANY_COLORS : mes = "���݂̃f�B�X�v���C�ݒ�ɑ΂��ĐF����������B"      '= &H80040222
            Case DirectShowHRESULT.VFW_E_STATE_CHANGED : mes = "�T���v���̏�����҂��Ă���Ԃɏ�Ԃ��ω������B"     '= &H80040223
            Case DirectShowHRESULT.VFW_E_NOT_STOPPED : mes = "�t�B���^����~���Ă��Ȃ��̂ŁA���������s�ł��Ȃ��B"       '= &H80040224
            Case DirectShowHRESULT.VFW_E_NOT_PAUSED : mes = "�t�B���^����~���Ă��Ȃ����߁A���������s�ł��Ȃ������B"     '= &H80040225
            Case DirectShowHRESULT.VFW_E_NOT_RUNNING : mes = "�t�B���^�����s����Ă��Ȃ��̂ŁA���������s�ł��Ȃ��B"      '= &H80040226
            Case DirectShowHRESULT.VFW_E_WRONG_STATE : mes = "�t�B���^���s���ȏ�Ԃɂ��邽�߁A���������s�ł��Ȃ������B"        '= &H80040227
            Case DirectShowHRESULT.VFW_E_START_TIME_AFTER_END : mes = "�T���v���̊J�n�^�C�����T���v���̏I���^�C���̌�ɂȂ��Ă���B"      '= &H80040228
            Case DirectShowHRESULT.VFW_E_INVALID_RECT : mes = "�񋟂��ꂽ��`�������ł���B"      '= &H80040229
            Case DirectShowHRESULT.VFW_E_TYPE_NOT_ACCEPTED : mes = "���̃s���́A�񋟂��ꂽ���f�B�A �^�C�v���g���Ȃ��B"       '= &H8004022A
            Case DirectShowHRESULT.VFW_E_SAMPLE_REJECTED : mes = "���̃T���v���̓����_�����O�ł��Ȃ��B"      '= &H8004022B
            Case DirectShowHRESULT.VFW_E_SAMPLE_REJECTED_EOS : mes = "�X�g���[���̏I���ɓ��B���Ă���̂ŁA���̃T���v���������_�����O�ł��Ȃ��B"       '= &H8004022C
            Case DirectShowHRESULT.VFW_E_DUPLICATE_NAME : mes = "�������O�̃t�B���^��ǉ����悤�Ƃ��������s�����B"        '= &H8004022D
            Case DirectShowHRESULT.VFW_S_DUPLICATE_NAME : mes = "�������O�̃t�B���^��ǉ����悤�Ƃ����Ƃ���A���O��ύX���ď��������������B"       '= &H4022D   
            Case DirectShowHRESULT.VFW_E_TIMEOUT : mes = "�^�C���A�E�g���Ԃ��߂����B"       '= &H8004022E
            Case DirectShowHRESULT.VFW_E_INVALID_FILE_FORMAT : mes = "�t�@�C�� �t�H�[�}�b�g�������ł���B"      '= &H8004022F
            Case DirectShowHRESULT.VFW_E_ENUM_OUT_OF_RANGE : mes = "���X�g���g���ʂ����ꂽ�B"        '= &H80040230
            Case DirectShowHRESULT.VFW_E_CIRCULAR_GRAPH : mes = "�t�B���^ �O���t���z���Ă���B"        '= &H80040231
            Case DirectShowHRESULT.VFW_E_NOT_ALLOWED_TO_SAVE : mes = "���̏�Ԃł̍X�V�͋�����Ȃ��B"     '= &H80040232
            Case DirectShowHRESULT.VFW_E_TIME_ALREADY_PASSED : mes = "�ߋ��̃^�C���̃R�}���h���L���[�ɓ���悤�Ƃ����B"        '= &H80040233
            Case DirectShowHRESULT.VFW_E_ALREADY_CANCELLED : mes = "�L���[�ɓ����ꂽ�R�}���h�͊��ɃL�����Z������Ă����B"     '= &H80040234
            Case DirectShowHRESULT.VFW_E_CORRUPT_GRAPH_FILE : mes = "�t�@�C�������Ă���̂Ń����_�����O�ł��Ȃ��B"     '= &H80040235
            Case DirectShowHRESULT.VFW_E_ADVISE_ALREADY_SET : mes = "IOverlay �A�h�o�C�Y �����N�����ɑ��݂��Ă���B"        '= &H80040236
            Case DirectShowHRESULT.VFW_S_STATE_INTERMEDIATE : mes = "��Ԃ̈ڍs���������Ă��Ȃ��B"      '= &H40237   
            Case DirectShowHRESULT.VFW_E_NO_MODEX_AVAILABLE : mes = "�t���X�N���[�� ���[�h�͗��p�ł��Ȃ��B"     '= &H80040238
            Case DirectShowHRESULT.VFW_E_NO_ADVISE_SET : mes = "���̃A�h�o�C�Y�͐���ɐݒ肳��Ă��Ȃ��̂ŃL�����Z���ł��Ȃ��B"     '= &H80040239
            Case DirectShowHRESULT.VFW_E_NO_FULLSCREEN : mes = "�t���X�N���[�� ���[�h�͗��p�ł��Ȃ��B"     '= &H8004023A
            Case DirectShowHRESULT.VFW_E_IN_FULLSCREEN_MODE : mes = "�t���X�N���[�� ���[�h�ł� IVideoWindow ���\�b�h���Ăяo���Ȃ��B"     '= &H8004023B
            Case DirectShowHRESULT.VFW_E_UNKNOWN_FILE_TYPE : mes = "���̃t�@�C���̃��f�B�A �^�C�v���F������Ȃ��B"     '= &H80040240
            Case DirectShowHRESULT.VFW_E_CANNOT_LOAD_SOURCE_FILTER : mes = "���̃t�@�C���̃\�[�X �t�B���^�����[�h�ł��Ȃ��B"        '= &H80040241
            Case DirectShowHRESULT.VFW_S_PARTIAL_RENDER : mes = "���̃��[�r�[�ɃT�|�[�g����Ȃ��t�H�[�}�b�g�̃X�g���[�����܂܂�Ă���B"     '= &H40242   
            Case DirectShowHRESULT.VFW_E_FILE_TOO_SHORT : mes = "�t�@�C�����s���S�ł���B"        '= &H80040243
            Case DirectShowHRESULT.VFW_E_INVALID_FILE_VERSION : mes = "�t�@�C���̃o�[�W�����ԍ��������ł���B"     '= &H80040244
            Case DirectShowHRESULT.VFW_S_SOME_DATA_IGNORED : mes = "�t�@�C���ɂ������̎g�p����Ă��Ȃ��v���p�e�B�ݒ肪�܂܂�Ă���B"       '= &H40245   
            Case DirectShowHRESULT.VFW_S_CONNECTIONS_DEFERRED : mes = "�ꕔ�̐ڑ������s���Ēx�������B"     '= &H40246   
            Case DirectShowHRESULT.VFW_E_INVALID_CLSID : mes = "���̃t�@�C���͉��Ă���B�����ȃN���X���ʎq���܂܂�Ă���B"      '= &H80040247
            Case DirectShowHRESULT.VFW_E_INVALID_MEDIA_TYPE : mes = "���̃t�@�C���͉��Ă���B�����ȃ��f�B�A �^�C�v���܂܂�Ă���B"        '= &H80040248
            Case DirectShowHRESULT.VFW_E_SAMPLE_TIME_NOT_SET : mes = "���̃T���v���ɂ̓^�C�� �X�^���v���ݒ肳��Ă��Ȃ��B"      '= &H80040249
            Case DirectShowHRESULT.VFW_S_RESOURCE_NOT_NEEDED : mes = "�w�肳�ꂽ���\�[�X�͂��͂�K�v�Ȃ��B"      '= &H40250   
            Case DirectShowHRESULT.VFW_E_MEDIA_TIME_NOT_SET : mes = "���̃T���v���ɂ̓��f�B�A �^�C�����ݒ肳��Ă��Ȃ��B"      '= &H80040251
            Case DirectShowHRESULT.VFW_E_NO_TIME_FORMAT_SET : mes = "���f�B�A �^�C�� �t�H�[�}�b�g���I������Ă��Ȃ��B"       '= &H80040252
            Case DirectShowHRESULT.VFW_E_MONO_AUDIO_HW : mes = "�I�[�f�B�I �f�o�C�X�����m������p�Ȃ̂ŁA�o�����X��ύX�ł��Ȃ��B"       '= &H80040253
            Case DirectShowHRESULT.VFW_S_MEDIA_TYPE_IGNORED : mes = "�i���O���t�̃��f�B�A �^�C�v�ɐڑ��ł��Ȃ��B"      '= &H40254   
            Case DirectShowHRESULT.VFW_E_NO_DECOMPRESSOR : mes = "�r�f�I �X�g���[�����Đ��ł��Ȃ��B�K�؂ȃf�R���v���b�T��������Ȃ������B"       '= &H80040255
            Case DirectShowHRESULT.VFW_E_NO_AUDIO_HARDWARE : mes = "�I�[�f�B�I �X�g���[�����Đ��ł��Ȃ��B�I�[�f�B�I �n�[�h�E�F�A�����p�ł��Ȃ��A�܂��̓n�[�h�E�F�A���T�|�[�g����Ă��Ȃ��B"        '= &H80040256
            Case DirectShowHRESULT.VFW_S_VIDEO_NOT_RENDERED : mes = "�r�f�I �X�g���[�����Đ��ł��Ȃ��B�K�؂ȃ����_����������Ȃ������B"      '= &H40257   
            Case DirectShowHRESULT.VFW_S_AUDIO_NOT_RENDERED : mes = "�I�[�f�B�I �X�g���[�����Đ��ł��Ȃ��B�K�؂ȃ����_����������Ȃ������B"        '= &H40258   
            Case DirectShowHRESULT.VFW_E_RPZA : mes = "�r�f�I �X�g���[�����Đ��ł��Ȃ��B�t�H�[�}�b�g 'RPZA' �̓T�|�[�g����Ă��Ȃ��B"     '= &H80040259
            Case DirectShowHRESULT.VFW_S_RPZA : mes = "�r�f�I �X�g���[�����Đ��ł��Ȃ��B�t�H�[�}�b�g 'RPZA' �̓T�|�[�g����Ă��Ȃ��B"     '= &H4025A   
            Case DirectShowHRESULT.VFW_E_PROCESSOR_NOT_SUITABLE : mes = "DirectShow �͂��̃v���Z�b�T��� MPEG ���[�r�[���Đ��ł��Ȃ��B"     '= &H8004025B
            Case DirectShowHRESULT.VFW_E_UNSUPPORTED_AUDIO : mes = "�I�[�f�B�I �X�g���[�����Đ��ł��Ȃ��B���̃I�[�f�B�I �t�H�[�}�b�g�̓T�|�[�g����Ă��Ȃ��B"       '= &H8004025C
            Case DirectShowHRESULT.VFW_E_UNSUPPORTED_VIDEO : mes = "�r�f�I �X�g���[�����Đ��ł��Ȃ��B���̃r�f�I �t�H�[�}�b�g�̓T�|�[�g����Ă��Ȃ��B"       '= &H8004025D
            Case DirectShowHRESULT.VFW_E_MPEG_NOT_CONSTRAINED : mes = "���̃r�f�I �X�g���[���͋K�i�ɏ������Ă��Ȃ��̂� DirectShow �ōĐ��ł��Ȃ��B"        '= &H8004025E
            Case DirectShowHRESULT.VFW_E_NOT_IN_GRAPH : mes = "�t�B���^ �O���t�ɑ��݂��Ȃ��I�u�W�F�N�g�ɗv�����ꂽ�֐������s�ł��Ȃ��B"        '= &H8004025F
            Case DirectShowHRESULT.VFW_S_ESTIMATED : mes = "�Ԃ��ꂽ�l�͗\���l�ł���B�l�̐��m����ۏ؂ł��Ȃ��B"      '= &H40260   
            Case DirectShowHRESULT.VFW_E_NO_TIME_FORMAT : mes = "�I�u�W�F�N�g�̃^�C�� �t�H�[�}�b�g�ɃA�N�Z�X�ł��Ȃ��B"     '= &H80040261
            Case DirectShowHRESULT.VFW_E_READ_ONLY : mes = "�X�g���[�����ǂݏo����p�ŁA�t�B���^�ɂ���ăf�[�^���ύX����Ă���̂ŁA�ڑ����m���ł��Ȃ��B"      '= &H80040262
            Case DirectShowHRESULT.VFW_S_RESERVED : mes = "���̐����R�[�h�́ADirectShow �̓��������p�ɗ\�񂳂�Ă���B"     '= &H40263   
            Case DirectShowHRESULT.VFW_E_BUFFER_UNDERFLOW : mes = "�o�b�t�@���\���ɖ�������Ă��Ȃ��B"       '= &H80040264
            Case DirectShowHRESULT.VFW_E_UNSUPPORTED_STREAM : mes = "�t�@�C�����Đ��ł��Ȃ��B�t�H�[�}�b�g���T�|�[�g����Ă��Ȃ��B"      '= &H80040265
            Case DirectShowHRESULT.VFW_E_NO_TRANSPORT : mes = "�����]�����T�|�[�g���Ă��Ȃ��̂Ńs���ǂ�����ڑ��ł��Ȃ��B"       '= &H80040266
            Case DirectShowHRESULT.VFW_S_STREAM_OFF : mes = "�X�g���[�����I�t�ɂȂ����B"       '= &H40267   
            Case DirectShowHRESULT.VFW_S_CANT_CUE : mes = "�t�B���^�̓A�N�e�B�u�����A�f�[�^���o�͂��邱�Ƃ��ł��Ȃ��B�uIMediaFilter::GetState�v���Q�Ƃ��邱�ƁB"       '= &H40268   
            Case DirectShowHRESULT.VFW_E_BAD_VIDEOCD : mes = "�f�o�C�X���r�f�I CD �𐳏�ɓǂݏo���Ȃ��A�܂��̓r�f�I CD �̃f�[�^�����Ă���B"        '= &H80040269
            Case DirectShowHRESULT.VFW_S_NO_STOP_TIME : mes = "�T���v���ɏI���^�C���ł͂Ȃ��J�n�^�C�����ݒ肳��Ă����B���̏ꍇ�A�Ԃ����I���^�C���͊J�n�^�C���� 1 ���������l�ɐݒ肳���B"        '= &H80040270
            Case DirectShowHRESULT.VFW_E_OUT_OF_VIDEO_MEMORY : mes = "���̃f�B�X�v���C�𑜓x�ƐF���ɑ΂��ăr�f�I ���������s�\���ł���B�𑜓x��Ⴍ����Ƃ悢�B"       '= &H80040271
            Case DirectShowHRESULT.VFW_E_VP_NEGOTIATION_FAILED : mes = "�r�f�I �|�[�g�ڑ��l�S�V�G�[�V���� �v���Z�X�����s�����B"        '= &H80040272
            Case DirectShowHRESULT.VFW_E_DDRAW_CAPS_NOT_SUITABLE : mes = "Microsoft DirectDraw ���C���X�g�[������Ă��Ȃ��A�܂��̓r�f�I �J�[�h�̔\�͂��K�؂łȂ��B�f�B�X�v���C�� 16 �F���[�h�łȂ����Ƃ��m�F���邱�ƁB"     '= &H80040273
            Case DirectShowHRESULT.VFW_E_NO_VP_HARDWARE : mes = "�r�f�I �|�[�g �n�[�h�E�F�A�����p�ł��Ȃ��A�܂��̓n�[�h�E�F�A���������Ȃ��B"      '= &H80040274
            Case DirectShowHRESULT.VFW_E_NO_CAPTURE_HARDWARE : mes = "�L���v�`�� �n�[�h�E�F�A�����p�ł��Ȃ��A�܂��̓n�[�h�E�F�A���������Ȃ��B"        '= &H80040275
            Case DirectShowHRESULT.VFW_E_DVD_OPERATION_INHIBITED : mes = "���̎��_�ł��̃��[�U�[����� DVD �R���e���c�ɂ���ċ֎~����Ă���B"        '= &H80040276
            Case DirectShowHRESULT.VFW_E_DVD_INVALIDDOMAIN : mes = "���݂̃h���C���ł��̏����͋�����Ă��Ȃ��B"      '= &H80040277
            Case DirectShowHRESULT.VFW_E_DVD_NO_BUTTON : mes = "�v�����ꂽ�{�^�������p�ł��Ȃ��B"        '= &H80040278
            Case DirectShowHRESULT.VFW_E_DVD_GRAPHNOTREADY : mes = "DVD-Video �Đ��O���t���쐬����Ă��Ȃ��B"       '= &H80040279
            Case DirectShowHRESULT.VFW_E_DVD_RENDERFAIL : mes = "DVD-Video �Đ��O���t�̍쐬�����s�����B"        '= &H8004027A
            Case DirectShowHRESULT.VFW_E_DVD_DECNOTENOUGH : mes = "�f�R�[�_���s�\�����������߂ɁADVD-Video �Đ��O���t���쐬�ł��Ȃ������B"        '= &H8004027B
            Case DirectShowHRESULT.VFW_E_DVD_NOT_IN_KARAOKE_MODE : mes = "DVD �i�r�Q�[�^�̓J���I�P ���[�h�ł͂Ȃ��B"     '= &H8004028B
            Case DirectShowHRESULT.VFW_E_FRAME_STEP_UNSUPPORTED : mes = "�R�}����̓T�|�[�g����Ă��Ȃ��B"        '= &H8004028E
            Case DirectShowHRESULT.VFW_E_PIN_ALREADY_BLOCKED_ON_THIS_THREAD : mes = "�s���͊��ɌĂяo�����̃X���b�h�Ńu���b�N����Ă���B"      '= &H80040293
            Case DirectShowHRESULT.VFW_E_PIN_ALREADY_BLOCKED : mes = "�s���͊��ɑ��̃X���b�h�Ńu���b�N����Ă���B"      '= &H80040294
            Case DirectShowHRESULT.VFW_E_CERTIFICATION_FAILURE : mes = "���̃t�B���^�̎g�p�́A�\�t�g�E�F�A �L�[�ɂ���Đ�������Ă���B�A�v���P�[�V�����́A�t�B���^�̃��b�N���������Ȃ���΂Ȃ�Ȃ��B"     '= &H80040295
            Case DirectShowHRESULT.VFW_E_BAD_KEY : mes = "���W�X�g�� �G���g�������Ă���B"       '= &H800403F2
            Case DirectShowHRESULT.E_NOTIMPL : mes = "��������Ă��܂���B"
            Case DirectShowHRESULT.E_OUTOFMEMORY : mes = "������������܂���B"
            Case DirectShowHRESULT.E_INVALIDARG : mes = "�������s���ł��B"
            Case DirectShowHRESULT.E_NOINTERFACE : mes = "�C���^�[�t�F�[�X������܂���B"
            Case DirectShowHRESULT.E_POINTER : mes = "NULL�|�C���^�������Ɏw�肳��܂����B"
            Case DirectShowHRESULT.E_HANDLE : mes = "�s���ȃn���h���ł��B"
            Case DirectShowHRESULT.E_ABORT : mes = "���삪���~����܂����B"
            Case DirectShowHRESULT.E_FAIL : mes = "���s���܂����B"
            Case DirectShowHRESULT.E_ACCESSDENIED : mes = "�A�N�Z�X�͋��ۂ���܂����B"
            Case DirectShowHRESULT.S_OK : mes = "����"
            Case Else
                mes = "�s���ȃG���[�ł��B(" + Hex$(ResultCode) + ")"
        End Select

        Return mes
    End Function

    '//////////////////////////////////////////////////////////
    'DirectShow��O�N���X
    Public Class DirectShowException
        Inherits COMException

        '------------------------------------------------------
        '����J�f�[�^
        Private mMsg As String

        '------------------------------------------------------
        '------------------------------------------------------

        '�R���X�g���N�^
        Public Sub New(ByVal ex As COMException)
            MyBase.HResult = ex.ErrorCode
            mMsg = ""
        End Sub
        Public Sub New(ByVal HResult As Integer, Optional ByVal Msg As String = "")
            MyBase.HResult = HResult
            mMsg = Msg
        End Sub
        Public Sub New(ByVal Msg As String)
            MyBase.HResult = 0
            mMsg = Msg
        End Sub

        '�G���[���b�Z�[�W
        Public Overrides ReadOnly Property Message() As String
            Get
                If mMsg = "" Then
                    '�g�����b�Z�[�W�Ȃ��̏ꍇ�A
                    '������DirectShow�̃G���[���b�Z�[�W��Ԃ�
                    Return GetDirectShowMessage(MyBase.ErrorCode)
                End If

                '�����̏ꍇ�͊g�����b�Z�[�W�݂̂�Ԃ��B
                If MyBase.ErrorCode >= 0 Then
                    Return mMsg
                End If

                '�g�����b�Z�[�W��DirectShow�̃G���[���b�Z�[�W�������ĕԂ�
                Return mMsg + vbCrLf + "���R�F" + GetDirectShowMessage(MyBase.ErrorCode)
            End Get
        End Property

    End Class


#End Region


    '//////////////////////////////////////////////////////////
    '//////////////////////////////////////////////////////////
    '�O���t����p�֐�
#Region "�O���t����p�֐�"

    '�O���t�̐���
    '�߂�l
    '�@Nothing               ���s
    '�@Nothing�ȊO           IGraphBuilder�C���^�[�t�F�[�X(����)
    Public Function CreateNewGraph() As IGraphBuilder

        '�C���X�^���X����
        Dim obj As Object = CoCreateInstance(DirectShowDefine.GUIDString.CLSID_FilterGraph)
        If obj Is Nothing Then Return Nothing

        '����
        Return CType(obj, IGraphBuilder)
    End Function

    '�t�B���^�̃C���X�^���X�쐬
    '����
    '�@CLSIDString           �t�B���^��GUID��\��������
    '�߂�l
    '�@Nothing               ���s
    '�@Nothing�ȊO           IBaseFilter�C���^�[�t�F�[�X(����)
    Public Function CreateFilter(ByVal CLSIDString As String) As IBaseFilter

        '�N���X�h�c����
        Dim FilterClassID As Guid
        FilterClassID = New Guid(CLSIDString)

        '�^�C�v�̎擾
        Dim FilterType As Type
        FilterType = Type.GetTypeFromCLSID(FilterClassID)

        '�t�B���^�̃C���X�^���X�쐬
        Dim FilterObject As Object
        FilterObject = Activator.CreateInstance(FilterType)

        'IBaseFilter�C���^�[�t�F�[�X�擾
        Dim flt As IBaseFilter = TryCast(FilterObject, IBaseFilter)

        Return flt
    End Function

    '�t�B���^���O���t�ɒǉ�
    '����
    '�@Grp                      �O���t
    '�@CLSIDString              �t�B���^��GUID��\��������
    '�@FilterCaption            �t�B���^����
    '�߂�l
    '�@Nothing                  ���s
    '�@Nothing�ȊO              IBaseFilter�C���^�[�t�F�[�X(����)
    Public Function AddFilter(ByVal Grp As IGraphBuilder, ByVal CLSIDString As String, ByVal FilterCaption As String) As IBaseFilter

        '�t�B���^�C���X�^���X����
        Dim flt As IBaseFilter
        flt = CreateFilter(CLSIDString)

        '�O���t�ɒǉ�
        Dim rc As Integer
        rc = Grp.AddFilter(flt, FilterCaption)
        If rc <> 0 Then Throw New DirectShowException(rc, "�O���t�Ƀt�B���^��ǉ��ł��܂���B")

        '����
        Return flt
    End Function

    '�t�B���^���O���t�ɒǉ�(���O�w��)
    '����
    '�@Grp                      �O���t
    '�@Category                 �t�B���^�̃J�e�S��
    '�@FilterName               �t�B���^�̖���
    '�@SkipCount                �t�B���^�񋓎��̃X�L�b�v��
    '�@FilterCaption            �t�B���^����
    '�߂�l
    '�@Nothing                  ���s
    '�@Nothing�ȊO              IBaseFilter�C���^�[�t�F�[�X(����)
    Public Function AddFilter(ByVal Grp As IGraphBuilder, ByVal Category As String, ByVal FilterName As String, ByVal SkipCount As Integer, ByVal FilterCaption As String) As IBaseFilter

        '�t�B���^��񋓂��A�Ώۃt�B���^����������O���t�ɒǉ�����
        Dim afp As New ADDFILTERPARAM
        afp.Grp = Grp
        afp.FilterName = FilterName
        afp.SkipCount = SkipCount
        afp.FilterCaption = FilterCaption
        afp.Filter = Nothing
        EnumFiltersAlgorithm(Category, New DelegateEnumFilters(AddressOf AddFilterFunc), afp)

        Return afp.Filter
    End Function
    Private Function AddFilterFunc(ByRef Mon As ComTypes.IMoniker, ByVal PropertyBag As IPropertyBag, ByVal Param As Object) As Boolean

        '�p�����^�擾
        Dim afp As ADDFILTERPARAM = CType(Param, ADDFILTERPARAM)

        '���̎擾
        Dim fnameobj As Object = Nothing
        PropertyBag.Read("FriendlyName", fnameobj, 0)
        Dim fname As String = CStr(fnameobj)
        fnameobj = Nothing

        '����
        If fname = afp.FilterName Then
            If afp.SkipCount > 0 Then
                '�X�L�b�v
                afp.SkipCount -= 1
            Else
                '�Ώۃt�B���^����

                '�t�B���^�I�u�W�F�N�g�擾
                Dim fltobj As Object = Nothing
                Mon.BindToObject(Nothing, Nothing, New Guid(GUIDString.Interface.IID_IBaseFilter), fltobj)
                If fltobj Is Nothing Then Throw New DirectShowException("�O���t�Ƀt�B���^��ǉ��ł��܂���B- " + afp.FilterName)
                Dim flt As IBaseFilter = CType(fltobj, IBaseFilter)

                '�O���t�ɒǉ�
                Dim rc As Integer
                rc = afp.Grp.AddFilter(flt, afp.FilterCaption)
                If rc <> 0 Then Throw New DirectShowException(rc, "�O���t�Ƀt�B���^��ǉ��ł��܂���B- " + afp.FilterName)

                '����
                afp.Filter = flt

                '�񋓏I��
                Return True
            End If
        End If

        '�񋓌p��
        Return False
    End Function
    Private Class ADDFILTERPARAM
        Public Grp As IGraphBuilder
        Public FilterName As String
        Public SkipCount As Integer
        Public FilterCaption As String
        Public Filter As IBaseFilter
    End Class


#End Region

#Region "���擾"

    '�t�B���^�̗�
    '����
    '�@Category                 �J�e�S��
    '�߂�l
    '�@FILTERINFORMATION�̃R���N�V����
    Public Function EnumFilters(ByVal Category As String) As Collection
        Return EnumFilters(New Guid(Category))
    End Function
    Public Function EnumFilters(ByVal Category As Guid) As Collection

        '��
        Dim ret As New Collection
        EnumFiltersAlgorithm(Category, New DelegateEnumFilters(AddressOf EnumFiltersFunc), ret)

        Return ret
    End Function
    Private Function EnumFiltersFunc(ByRef Mon As ComTypes.IMoniker, ByVal PropertyBag As IPropertyBag, ByVal Param As Object) As Boolean

        Dim fi As New FILTERINFORMATION

        '���O�擾
        Dim fnameobj As Object = Nothing
        PropertyBag.Read("FriendlyName", fnameobj, 0)
        fi.Name = CStr(fnameobj)
        fnameobj = Nothing

        'CLSID�擾
        Dim cidobj As Object = Nothing
        PropertyBag.Read("CLSID", cidobj, 0)
        fi.CLSID = CStr(cidobj)
        cidobj = Nothing

        '�R���N�V�����ɒǉ�
        CType(Param, Collection).Add(fi)

        Return False
    End Function
    Public Structure FILTERINFORMATION
        Public Name As String
        Public CLSID As String

        '������
        Public Overrides Function ToString() As String
            Return Name
        End Function
    End Structure '�t�B���^���

    '�s���̗�
    '����
    '�@Filter                   �t�B���^
    '�߂�l
    '�@PININFORMATION�̃R���N�V����
    Public Function EnumPins(ByVal Filter As IBaseFilter) As Collection

        '��
        Dim ret As New Collection
        EnumPinsAlgorithm(Filter, New DelegateEnumPins(AddressOf EnumPinsFunc), ret)

        Return ret
    End Function
    Private Function EnumPinsFunc(ByRef Pin As IPin, ByVal Param As Object) As Boolean

        '�s�����擾
        Dim pf As New PIN_INFO
        Pin.QueryPinInfo(pf)
        Dim pi As New PININFORMATION
        pi.Name = pf.Name
        pi.Direction = pf.PinDir
        If Not pf.Filter Is Nothing Then
            Marshal.ReleaseComObject(pf.Filter)
        End If

        '�R���N�V�����ɒǉ�
        CType(Param, Collection).Add(pi)

        '�񋓌p��
        Return False
    End Function
    Public Class PININFORMATION
        Public Name As String
        Public Direction As PinDirection

        '������
        Public Overrides Function ToString() As String
            Return Name
        End Function
    End Class '�s�����

    '�t�B���^�̃s������
    '����
    '�@Filter                   �t�B���^
    '�@PinName                  �s������
    '�߂�l
    '�@Nothing                  �w�肳�ꂽ�s���͂Ȃ�(���s)
    '�@Nothing�ȊO              IPin�C���^�[�t�F�[�X(����)
    Public Function FindPin(ByVal Filter As IBaseFilter, ByVal PinName As String) As IPin

        '����
        Dim fpp As New FINDPINPARAM
        fpp.Name = PinName
        fpp.Pin = Nothing
        EnumPinsAlgorithm(Filter, New DelegateEnumPins(AddressOf FindPinFunc), fpp)

        Return fpp.Pin

    End Function
    Private Function FindPinFunc(ByRef Pin As IPin, ByVal Param As Object) As Boolean

        '�p�����^�擾
        Dim fpp As FINDPINPARAM = CType(Param, FINDPINPARAM)

        '�s�����擾
        Dim pf As New PIN_INFO
        Pin.QueryPinInfo(pf)
        If Not pf.Filter Is Nothing Then
            Marshal.ReleaseComObject(pf.Filter)
        End If

        '����
        If pf.Name = fpp.Name Then
            '����
            fpp.Pin = Pin

            'Pin�I�u�W�F�N�g��Release����Ȃ��悤�ɂ���
            Pin = Nothing

            '�񋓏I��
            Return True
        End If

        '�񋓌p��
        Return False

    End Function
    Private Class FINDPINPARAM
        Public Name As String
        Public Direction As PinDirection
        Public Pin As IPin
    End Class

    '�s���̖��̎擾
    '����
    '�@Pin                      �s��
    '�߂�l
    '�@�s������
    Public Function GetPinName(ByVal Pin As IPin) As String

        Dim rc As Integer

        '�s�����擾
        Dim PINFO As New PIN_INFO
        rc = Pin.QueryPinInfo(PINFO)
        If rc <> 0 Then Throw New DirectShowException(rc, "�s�����̂��擾�ł��܂���B")

        '��Еt��
        If Not PINFO.Filter Is Nothing Then
            Marshal.ReleaseComObject(PINFO.Filter)
        End If

        Return PINFO.Name
    End Function

    '����̉摜�T�C�Y�擾
    '����
    '�@Grp                      �O���t
    '�߂�l
    '  �摜�T�C�Y
    Public Function GetVideoSize(ByVal Grp As IGraphBuilder) As Size
        Dim ret As Size
        Dim rc As Integer

        '�摜�T�C�Y���擾
        Dim bv As IBasicVideo2
        bv = TryCast(Grp, IBasicVideo2)
        If bv Is Nothing Then Throw New DirectShowException("�r�f�I�X�g���[��������܂���B")
        rc = bv.GetVideoSize(ret.Width, ret.Height)
        If rc <> 0 Then Throw New DirectShowException(rc, "�r�f�I�T�C�Y���擾�ł��܂���B")

        '����
        Return ret
    End Function

#End Region

#Region "�t�H�[�}�b�g�`���֌W"

    '�t�H�[�}�b�g�`���̗�
    '����
    '�@Pin                      �s��
    '�߂�l
    '�@FORMATINFORMATION�R���N�V����
    '����
    '�E�f���`���̗񋓂�z�肵�Ă���B
    Public Function EnumFormat(ByVal Pin As IPin) As Collection
        '��
        Dim ret As New Collection
        EnumFormatAlgorithm(Pin, New DelegateEnumFormat(AddressOf EnumFormatFunc), ret)

        Return ret
    End Function
    Private Function EnumFormatFunc(ByRef MediaType As AMMediaType, ByVal Param As Object) As Boolean

        '��{���̎擾
        Dim fmt As New FORMATINFORMATION
        fmt.MajorType = MediaType.majorType
        fmt.SubType = MediaType.subType
        fmt.FormatType = MediaType.formatType

        '�f���`���̏ꍇ�A�T�C�Y���擾����
        If CompGUIDString(MediaType.formatType.ToString, GUIDString.FormatType.FORMAT_VideoInfo) Then
            '�f���`���ł���
            Dim vinfo As New DSVIDEOINFOHEADER
            vinfo = PtrToStructure(Of DSVIDEOINFOHEADER)(MediaType.formatPtr)
            fmt.Size.Width = vinfo.BmiHeader.Width
            fmt.Size.Height = vinfo.BmiHeader.Height
        End If

        '�R���N�V�����ɒǉ�
        CType(Param, Collection).Add(fmt)

        Return False
    End Function
    Public Class FORMATINFORMATION
        Public MajorType As Guid
        Public SubType As Guid
        Public FormatType As Guid
        Public Size As Size
    End Class

    '�t�H�[�}�b�g�`���̌��擾
    '����
    '�@Pin                      �s��
    '�߂�l
    '�@0�ȏ�                    �t�H�[�}�b�g�`����
    '�@0����                    ���s
    Public Function GetFormatCount(ByVal Pin As IPin) As Integer

        'IAMStreamConfig�C���^�[�t�F�[�X�̎擾
        If Pin Is Nothing Then Return -1
        Dim asc As IAMStreamConfig = TryCast(Pin, IAMStreamConfig)
        If asc Is Nothing Then Throw New DirectShowException(0, "���̃f�o�C�X�̓t�H�[�}�b�g�`����񋓂ł��܂���B")

        '�t�H�[�}�b�g���擾
        Dim fcnt As Integer = 0
        Dim ssz As Integer = 0
        Dim rc As Integer
        rc = asc.GetNumberOfCapabilities(fcnt, ssz)
        If rc <> 0 Then Throw New DirectShowException(rc, "�t�H�[�}�b�g�̗񋓂Ɏ��s���܂����B")

        Return fcnt
    End Function

    '�t�H�[�}�b�g�`���擾
    '����
    '�@Pin                      �s��
    '�@Index                    �C���f�b�N�X
    '�߂�l
    '�@Nothing�ȊO              ���f�B�A�^�C�v
    '�@Nothing                  ���s
    '����
    '�E�擾�ɐ��������ꍇ�A�擾�����f�[�^��DeleteMediaType�ŉ�����邱�ƁB
    Public Function GetFormat(ByVal Pin As IPin, ByVal Index As Integer) As AMMediaType

        'IAMStreamConfig�C���^�[�t�F�[�X�̎擾
        If Pin Is Nothing Then Return Nothing
        Dim asc As IAMStreamConfig = TryCast(Pin, IAMStreamConfig)
        If asc Is Nothing Then Throw New DirectShowException(0, "���̃f�o�C�X�̓t�H�[�}�b�g�`����񋓂ł��܂���B")

        '�t�H�[�}�b�g���擾
        Dim fcnt As Integer = 0
        Dim ssz As Integer = 0
        Dim rc As Integer
        rc = asc.GetNumberOfCapabilities(fcnt, ssz)
        If rc <> 0 Then Throw New DirectShowException(rc, "�t�H�[�}�b�g�̗񋓂Ɏ��s���܂����B")

        '�f�[�^�p�̈�m��
        Dim dataptr As IntPtr = Marshal.AllocHGlobal(ssz)

        '���f�B�A�^�C�v�擾
        Dim mt As AMMediaType = Nothing
        asc.GetStreamCaps(Index, mt, dataptr)

        '�f�[�^�p�̈���
        Marshal.FreeHGlobal(dataptr)
        dataptr = IntPtr.Zero

        Return mt
    End Function

    '���݂̃t�H�[�}�b�g�`���ԍ��擾
    '����
    '�@Pin                      �s��
    '�߂�l
    '�@Nothing�ȊO              ���f�B�A�^�C�v
    '�@Nothing                  ���s
    '����
    '�E�擾�ɐ��������ꍇ�A�擾�����f�[�^��DeleteMediaType�ŉ�����邱�ƁB
    Public Function GetFormat(ByVal Pin As IPin) As AMMediaType

        'IAMStreamConfig�C���^�[�t�F�[�X�̎擾
        If Pin Is Nothing Then Return Nothing
        Dim asc As IAMStreamConfig = TryCast(Pin, IAMStreamConfig)
        If asc Is Nothing Then Throw New DirectShowException(0, "���̃f�o�C�X�̓t�H�[�}�b�g�`����񋓂ł��܂���B")

        '���f�B�A�^�C�v�擾
        Dim mt As AMMediaType = Nothing
        Dim rc As Integer
        rc = asc.GetFormat(mt)
        If rc <> 0 Then Throw New DirectShowException(rc, "���݂̃t�H�[�}�b�g�`�����擾�ł��܂���B")

        Return mt
    End Function

    '�t�H�[�}�b�g�`���̑I��
    '����
    '�@Pin                      �s��
    '�@Format                   �V�����t�H�[�}�b�g
    Public Sub SetFormat(ByVal Pin As IPin, ByVal Format As AMMediaType)

        'IAMStreamConfig�C���^�[�t�F�[�X�̎擾
        If Pin Is Nothing Then Exit Sub
        Dim asc As IAMStreamConfig = TryCast(Pin, IAMStreamConfig)
        If asc Is Nothing Then Throw New DirectShowException(0, "���̃f�o�C�X�̓t�H�[�}�b�g�`����ݒ�ł��܂���B")

        '���f�B�A�^�C�v�ݒ�
        Dim rc As Integer
        rc = asc.SetFormat(Format)
        If rc <> 0 Then Throw New DirectShowException(rc, "�t�H�[�}�b�g�`����ݒ�ł��܂���B")

    End Sub


#End Region

    '//////////////////////////////////////////////////////////
    '//////////////////////////////////////////////////////////
    '���̑�
#Region "�񋓃A���S���Y��"

    '//////////////////////////////////////////////////////////
    '�t�B���^�񋓃A���S���Y��
    '����
    '�@Category                 �J�e�S��
    '�@DelegateFunc             DelegateEnumFilters�f���Q�[�g
    '�@Param                    �f���Q�[�g�֐��ɓn�����p�����^
    '����
    '�E�w��J�e�S�����̃t�B���^��񋓂��A�f���Q�[�g���Ăяo���B
    Public Sub EnumFiltersAlgorithm(ByVal Category As String, ByVal DelegateFunc As DelegateEnumFilters, ByVal Param As Object)
        EnumFiltersAlgorithm(New Guid(Category), DelegateFunc, Param)
    End Sub
    Public Sub EnumFiltersAlgorithm(ByVal Category As Guid, ByVal DelegateFunc As DelegateEnumFilters, ByVal Param As Object)

        '�V�X�e���f�o�C�X�񋓎q�̃^�C�v����
        Dim devenumtype As Type
        devenumtype = Type.GetTypeFromCLSID(New Guid(GUIDString.CLSID_SystemDeviceEnum))

        '�V�X�e���f�o�C�X�񋓎q�̃C���X�^���X�쐬
        Dim devenumobj As Object
        devenumobj = Activator.CreateInstance(devenumtype)

        'ICreateDevEnum�C���^�[�t�F�[�X�擾
        Dim devenum As ICreateDevEnum
        devenum = CType(devenumobj, ICreateDevEnum)
        devenumobj = Nothing

        'EnumMoniker�̍쐬
        Dim emon As ComTypes.IEnumMoniker = Nothing
        devenum.CreateClassEnumerator(Category, emon, 0)

        '��
        Dim mon(0) As ComTypes.IMoniker
        Dim fc As IntPtr
        Dim rc As Boolean = False
        Do While (emon.Next(1, mon, fc) = 0) And (rc = False)

            '�v���p�e�B�o�b�O�ւ̃o�C���h
            Dim propbagobj As Object = Nothing
            mon(0).BindToStorage(Nothing, Nothing, New Guid(GUIDString.Interface.IID_IPropertyBag), propbagobj)
            Dim propbag As IPropertyBag
            propbag = CType(propbagobj, IPropertyBag)
            propbagobj = Nothing

            '�f���Q�[�g�Ăяo��
            rc = DelegateFunc(mon(0), propbag, Param)

            '�v���p�e�B�o�b�O�̉��
            Marshal.ReleaseComObject(propbag)
            propbag = Nothing

            '�񋓂������j�J�̉��
            If Not mon(0) Is Nothing Then
                Marshal.ReleaseComObject(mon(0))
                mon(0) = Nothing
            End If
        Loop

        '�񋓏I��
        Marshal.ReleaseComObject(emon)
        emon = Nothing
        Marshal.ReleaseComObject(devenum)
        devenum = Nothing

    End Sub

    '�t�B���^�񋓃A���S���Y���p�f���Q�[�g
    '����
    '�@Moniker                  �񋓂��ꂽ�t�B���^�̃��j�J
    '�@PropertyBag              �񋓂��ꂽ�t�B���^�̃v���p�e�B�o�b�O
    '�@Param                    �ėp�p�����^
    '�߂�l
    '�@True                     �񋓂𒆎~����
    '�@False                    �񋓂��p������
    Public Delegate Function DelegateEnumFilters(ByRef Mon As ComTypes.IMoniker, ByVal PropertyBag As IPropertyBag, ByVal Param As Object) As Boolean


    '//////////////////////////////////////////////////////////
    '�s���񋓃A���S���Y��
    '����
    '�@Filter                    �t�B���^
    '�@DelegateFunc              DelegateEnumPins�f���Q�[�g
    '�@Param                     �ėp�p�����^
    Public Sub EnumPinsAlgorithm(ByVal Filter As IBaseFilter, ByVal DelegateFunc As DelegateEnumPins, ByVal Param As Object)

        Dim rc As Integer

        '�s���񋓎q�擾
        Dim epin As IEnumPins = Nothing
        rc = Filter.EnumPins(epin)
        If rc <> 0 Then Throw New DirectShowException(rc)

        '��
        Dim fc As Integer
        Dim pin As IPin = Nothing
        Do While epin.Next(1, pin, fc) = 0

            '�f���Q�[�g�Ăяo��
            DelegateFunc(pin, Param)

            '�񋓂����s���̉��
            If Not pin Is Nothing Then
                Marshal.ReleaseComObject(pin)
                pin = Nothing
            End If
        Loop

        '�񋓏I��
        Marshal.ReleaseComObject(epin)

    End Sub

    '�s���񋓃A���S���Y���p�f���Q�[�g
    '����
    '�@Pin                      �񋓂��ꂽ�s��
    '�@Param                    �ėp�p�����^
    '�߂�l
    '�@True                     �񋓂𒆎~����
    '�@False                    �񋓂��p������
    Public Delegate Function DelegateEnumPins(ByRef Pin As IPin, ByVal Param As Object) As Boolean

    '//////////////////////////////////////////////////////////
    '�t�H�[�}�b�g�^�C�v�񋓃A���S���Y��
    '����
    '�@Pin                      �s��
    '�@DelegateFunc              DelegateEnumFormat�f���Q�[�g
    '�@Param                     �ėp�p�����^
    Public Sub EnumFormatAlgorithm(ByVal Pin As IPin, ByVal DelegateFunc As DelegateEnumFormat, ByVal Param As Object)

        'IAMStreamConfig�C���^�[�t�F�[�X�̎擾
        If Pin Is Nothing Then Exit Sub
        Dim asc As IAMStreamConfig = TryCast(Pin, IAMStreamConfig)
        If asc Is Nothing Then Throw New DirectShowException("���̃f�o�C�X�̓t�H�[�}�b�g�`����񋓂ł��܂���B")

        '�t�H�[�}�b�g���擾
        Dim fcnt As Integer = 0
        Dim ssz As Integer = 0
        Dim rc As Integer
        rc = asc.GetNumberOfCapabilities(fcnt, ssz)
        If rc <> 0 Then Throw New DirectShowException(rc, "�t�H�[�}�b�g�̗񋓂Ɏ��s���܂����B")

        '�f�[�^�p�̈�m��
        Dim dataptr As IntPtr = Marshal.AllocHGlobal(ssz)

        '��
        Dim mt As AMMediaType = Nothing
        Dim ss As New System.Text.StringBuilder
        Dim flg As Boolean
        For x As Integer = 0 To fcnt - 1

            'x�Ԗڂ̃t�H�[�}�b�g���擾
            asc.GetStreamCaps(x, mt, dataptr)

            '�f���Q�[�g�Ăяo��
            flg = DelegateFunc(mt, Param)

            '���
            If Not mt Is Nothing Then
                DeleteMediaType(mt)
            End If

            If flg Then Exit For
        Next

        '�f�[�^�p�̈���
        Marshal.FreeHGlobal(dataptr)
        dataptr = IntPtr.Zero

    End Sub


    '�s���񋓃A���S���Y���p�f���Q�[�g
    '����
    '�@MediaType                ���f�B�A�^�C�v
    '�@Param                    �ėp�p�����^
    '�߂�l
    '�@True                     �񋓂𒆎~����
    '�@False                    �񋓂��p������
    Public Delegate Function DelegateEnumFormat(ByRef MediaType As AMMediaType, ByVal Param As Object) As Boolean



#End Region

#Region "�v���p�e�B�y�[�W�\��"
    '//////////////////////////////////////////////////////////
    '�t�B���^���̓s���̃v���p�e�B�y�[�W�\��
    '����
    '�@FilterObject         �t�B���^�A���́A�s���iISpecifyPropertyPages�������́j
    '�@WindowHandle         �e�E�B���h�E�̃n���h��
    '�@Caption              �v���p�e�B�E�B���h�E�̃^�C�g��
    '�߂�l
    '�@False                �v���p�e�B�y�[�W�͊J���ꂽ
    '�@True                 �v���p�e�B�y�[�W�͊J����Ȃ�����
    Public Function OpenDiaglog(ByVal FilterObject As Object, ByVal WindowHandle As IntPtr, Optional ByVal Caption As String = "�v���p�e�B") As Boolean

        'ISpecifyPropertyPages�C���^�[�t�F�[�X�擾
        Dim sp As ISpecifyPropertyPages
        sp = TryCast(FilterObject, ISpecifyPropertyPages)
        If sp Is Nothing Then
            '�v���p�e�B�y�[�W�͂Ȃ�
            Return True
        End If

        '�v���p�e�B�y�[�W���擾
        Dim ca As CAUUID
        sp.GetPages(ca)

        '�v���p�e�B�y�[�W�\��
        Win32API.OleCreatePropertyFrame( _
            WindowHandle, 0, 0, _
            Caption, 1, _
            FilterObject, ca.cElems, ca.pElems, 0, 0, Nothing)

        '��n��
        If ca.pElems <> IntPtr.Zero Then
            Marshal.FreeCoTaskMem(ca.pElems)
        End If

        Return False
    End Function

#End Region

#Region "���f�B�A�^�C�v�֌W"

    '���f�B�A�^�C�v�̉��
    Public Sub DeleteMediaType(ByVal Ptr As IntPtr)

        Dim mt As AMMediaType = Nothing
        mt = PtrToStructure(Of AMMediaType)(Ptr)

        DeleteMediaType(mt)

        Marshal.FreeCoTaskMem(Ptr)

    End Sub
    Public Sub DeleteMediaType(ByRef Data As AMMediaType)

        If Data.formatSize <> 0 Then
            Marshal.FreeCoTaskMem(Data.formatPtr)
        End If
        If Data.unkPtr <> IntPtr.Zero Then
            Marshal.FreeCoTaskMem(Data.unkPtr)
        End If

        Data = Nothing

    End Sub

    'GUID�����񓯎m�̔�r
    Public Function CompGUIDString(ByVal GUID1 As String, ByVal GUID2 As String) As Boolean
        Return NormalizeGUIDString(GUID1) = NormalizeGUIDString(GUID2)
    End Function

    'GUID������� {xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx} �ɂ���
    Public Function NormalizeGUIDString(ByVal GuidStr As String) As String
        If Not GuidStr.StartsWith("{") Then GuidStr = "{" + GuidStr
        If Not GuidStr.EndsWith("}") Then GuidStr = GuidStr + "}"
        Return UCase(GuidStr)
    End Function

    '���f�B�A�^�C�vGUID�����񂩂�킩��Ղ����̂��擾
    Public Function GetMediaTypeName(ByVal GUIDStr As String) As String

        Dim ss As String = NormalizeGUIDString(GUIDStr)
        Dim name As String = ""
        Select Case ss
            '���W���[�^�C�v
            Case GUIDString.MediaType.MEDIATYPE_Video : name = "[Video]"
            Case GUIDString.MediaType.MEDIATYPE_Audio : name = "[Audio]"
            Case GUIDString.MediaType.MEDIATYPE_Text : name = "[Text]"
            Case GUIDString.MediaType.MEDIATYPE_Midi : name = "[Midi]"
            Case GUIDString.MediaType.MEDIATYPE_Stream : name = "[Stream]"
            Case GUIDString.MediaType.MEDIATYPE_Interleaved : name = "[Interleaved]"
            Case GUIDString.MediaType.MEDIATYPE_File : name = "[File]"
            Case GUIDString.MediaType.MEDIATYPE_ScriptCommand : name = "[ScriptCommand]"
            Case GUIDString.MediaType.MEDIATYPE_AUXLine21Data : name = "[AUXLine21Data]"
            Case GUIDString.MediaType.MEDIATYPE_VBI : name = "[VBI]"
            Case GUIDString.MediaType.MEDIATYPE_Timecode : name = "[Timecode]"
            Case GUIDString.MediaType.MEDIATYPE_LMRT : name = "[LMRT]"
            Case GUIDString.MediaType.MEDIATYPE_URL_STREAM : name = "[URL_STREAM]"

                '�T�u�^�C�v
            Case GUIDString.MediaType.MEDIASUBTYPE_None : name = "[None]"
            Case GUIDString.MediaType.MEDIASUBTYPE_CLPL : name = "[CLPL]"
            Case GUIDString.MediaType.MEDIASUBTYPE_YUYV : name = "[YUYV]"
            Case GUIDString.MediaType.MEDIASUBTYPE_IYUV : name = "[IYUV]"
            Case GUIDString.MediaType.MEDIASUBTYPE_YVU9 : name = "[YVU9]"
            Case GUIDString.MediaType.MEDIASUBTYPE_Y411 : name = "[Y411]"
            Case GUIDString.MediaType.MEDIASUBTYPE_Y41P : name = "[Y41P]"
            Case GUIDString.MediaType.MEDIASUBTYPE_YUY2 : name = "[YUY2]"
            Case GUIDString.MediaType.MEDIASUBTYPE_YVYU : name = "[YVYU]"
            Case GUIDString.MediaType.MEDIASUBTYPE_UYVY : name = "[UYVY]"
            Case GUIDString.MediaType.MEDIASUBTYPE_Y211 : name = "[Y211]"
            Case GUIDString.MediaType.MEDIASUBTYPE_CLJR : name = "[CLJR]"
            Case GUIDString.MediaType.MEDIASUBTYPE_IF09 : name = "[IF09]"
            Case GUIDString.MediaType.MEDIASUBTYPE_CPLA : name = "[CPLA]"
            Case GUIDString.MediaType.MEDIASUBTYPE_MJPG : name = "[MJPG]"
            Case GUIDString.MediaType.MEDIASUBTYPE_TVMJ : name = "[TVMJ]"
            Case GUIDString.MediaType.MEDIASUBTYPE_WAKE : name = "[WAKE]"
            Case GUIDString.MediaType.MEDIASUBTYPE_CFCC : name = "[CFCC]"
            Case GUIDString.MediaType.MEDIASUBTYPE_IJPG : name = "[IJPG]"
            Case GUIDString.MediaType.MEDIASUBTYPE_Plum : name = "[Plum]"
            Case GUIDString.MediaType.MEDIASUBTYPE_DVSD : name = "[DVSD]"
            Case GUIDString.MediaType.MEDIASUBTYPE_MDVF : name = "[MDVF]"
            Case GUIDString.MediaType.MEDIASUBTYPE_RGB1 : name = "[RGB1]"
            Case GUIDString.MediaType.MEDIASUBTYPE_RGB4 : name = "[RGB4]"
            Case GUIDString.MediaType.MEDIASUBTYPE_RGB8 : name = "[RGB8]"
            Case GUIDString.MediaType.MEDIASUBTYPE_RGB565 : name = "[RGB565]"
            Case GUIDString.MediaType.MEDIASUBTYPE_RGB555 : name = "[RGB555]"
            Case GUIDString.MediaType.MEDIASUBTYPE_RGB24 : name = "[RGB24]"
            Case GUIDString.MediaType.MEDIASUBTYPE_RGB32 : name = "[RGB32]"
            Case GUIDString.MediaType.MEDIASUBTYPE_ARGB1555 : name = "[ARGB1555]"
            Case GUIDString.MediaType.MEDIASUBTYPE_ARGB4444 : name = "[ARGB4444]"
            Case GUIDString.MediaType.MEDIASUBTYPE_ARGB32 : name = "[ARGB32]"
            Case GUIDString.MediaType.MEDIASUBTYPE_A2R10G10B10 : name = "[A2R10G10B10]"
            Case GUIDString.MediaType.MEDIASUBTYPE_A2B10G10R10 : name = "[A2B10G10R10]"
            Case GUIDString.MediaType.MEDIASUBTYPE_AYUV : name = "[AYUV]"
            Case GUIDString.MediaType.MEDIASUBTYPE_AI44 : name = "[AI44]"
            Case GUIDString.MediaType.MEDIASUBTYPE_IA44 : name = "[IA44]"
            Case GUIDString.MediaType.MEDIASUBTYPE_YV12 : name = "[YV12]"
            Case GUIDString.MediaType.MEDIASUBTYPE_NV12 : name = "[NV12]"
            Case GUIDString.MediaType.MEDIASUBTYPE_IMC1 : name = "[IMC1]"
            Case GUIDString.MediaType.MEDIASUBTYPE_IMC2 : name = "[IMC2]"
            Case GUIDString.MediaType.MEDIASUBTYPE_IMC3 : name = "[IMC3]"
            Case GUIDString.MediaType.MEDIASUBTYPE_IMC4 : name = "[IMC4]"
            Case GUIDString.MediaType.MEDIASUBTYPE_S340 : name = "[S340]"
            Case GUIDString.MediaType.MEDIASUBTYPE_S342 : name = "[S342]"
            Case GUIDString.MediaType.MEDIASUBTYPE_I420 : name = "[I420]"
            Case GUIDString.MediaType.MEDIASUBTYPE_Overlay : name = "[Overlay]"
            Case GUIDString.MediaType.MEDIASUBTYPE_MPEGPacket : name = "[MPEGPacket]"
            Case GUIDString.MediaType.MEDIASUBTYPE_MPEG1Payload : name = "[MPEG1Payload]"
            Case GUIDString.MediaType.MEDIASUBTYPE_MPEG1AudioPayload : name = "[MPEG1AudioPayload]"
            Case GUIDString.MediaType.MEDIASUBTYPE_MPEG1SystemStream : name = "[MPEG1SystemStream]"
            Case GUIDString.MediaType.MEDIASUBTYPE_MPEG1VideoCD : name = "[MPEG1VideoCD]"
            Case GUIDString.MediaType.MEDIASUBTYPE_MPEG1Video : name = "[MPEG1Video]"
            Case GUIDString.MediaType.MEDIASUBTYPE_MPEG1Audio : name = "[MPEG1Audio]"
            Case GUIDString.MediaType.MEDIASUBTYPE_Avi : name = "[Avi]"
            Case GUIDString.MediaType.MEDIASUBTYPE_Asf : name = "[Asf]"
            Case GUIDString.MediaType.MEDIASUBTYPE_QTMovie : name = "[QTMovie]"
            Case GUIDString.MediaType.MEDIASUBTYPE_Rpza : name = "[Rpza]"
            Case GUIDString.MediaType.MEDIASUBTYPE_Smc : name = "[Smc]"
            Case GUIDString.MediaType.MEDIASUBTYPE_Rle : name = "[Rle]"
            Case GUIDString.MediaType.MEDIASUBTYPE_Jpeg : name = "[Jpeg]"
            Case GUIDString.MediaType.MEDIASUBTYPE_PCMAudio_Obsolete : name = "[PCMAudio_Obsolete]"
            Case GUIDString.MediaType.MEDIASUBTYPE_PCM : name = "[PCM]"
            Case GUIDString.MediaType.MEDIASUBTYPE_WAVE : name = "[WAVE]"
            Case GUIDString.MediaType.MEDIASUBTYPE_AU : name = "[AU]"
            Case GUIDString.MediaType.MEDIASUBTYPE_AIFF : name = "[AIFF]"
            Case GUIDString.MediaType.MEDIASUBTYPE_dvsd2 : name = "[dvsd2]"
            Case GUIDString.MediaType.MEDIASUBTYPE_dvhd : name = "[dvhd]"
            Case GUIDString.MediaType.MEDIASUBTYPE_dvsl : name = "[dvsl]"
            Case GUIDString.MediaType.MEDIASUBTYPE_dv25 : name = "[dv25]"
            Case GUIDString.MediaType.MEDIASUBTYPE_dv50 : name = "[dv50]"
            Case GUIDString.MediaType.MEDIASUBTYPE_dvh1 : name = "[dvh1]"
            Case GUIDString.MediaType.MEDIASUBTYPE_Line21_BytePair : name = "[Line21_BytePair]"
            Case GUIDString.MediaType.MEDIASUBTYPE_Line21_GOPPacket : name = "[Line21_GOPPacket]"
            Case GUIDString.MediaType.MEDIASUBTYPE_Line21_VBIRawData : name = "[Line21_VBIRawData]"
            Case GUIDString.MediaType.MEDIASUBTYPE_TELETEXT : name = "[TELETEXT]"
        End Select

        Return name
    End Function

#End Region

#Region "�r�f�I�����_���֌W"

    '//////////////////////////////////////////////////////////
    '�w�肳�ꂽ�E�B���h�E���œ�����Đ�������
    Public Enum RendererScale    '�g��k������
        None = 0                    '�g��k���Ȃ�
        KeepAspect = 1              '�c�����ۂ��Ċg��k��
        Full = 2                    '�̈�S�̂Ɋg��k��
    End Enum
    Public Sub SetVideoRenderer(ByVal Grp As IGraphBuilder, ByVal Owner As Control, ByVal Zoom As RendererScale)
        Dim sz As Size = Owner.ClientSize
        SetVideoRenderer(Grp, Owner.Handle, sz, Zoom)
    End Sub
    Public Sub SetVideoRenderer(ByVal Grp As IGraphBuilder, ByVal Owner As IntPtr, ByVal OwnerSize As Size, ByVal Zoom As RendererScale)

        Dim rc As Integer

        '�����`�F�b�N
        If Grp Is Nothing Then Throw New DirectShowException("�O���t���쐬����Ă��܂���B")
        If (OwnerSize.Width = 0) Or (OwnerSize.Height = 0) Then Throw New DirectShowException("�Đ��̈�̃T�C�Y���s���ł��B")

        'IVideoWindow�C���^�[�t�F�[�X�擾
        Dim vw As IVideoWindow
        vw = TryCast(Grp, IVideoWindow)
        If vw Is Nothing Then Throw New DirectShowException("�r�f�I�����_��������܂���B")

        '�摜�T�C�Y���擾
        Dim vsz As Size = GetVideoSize(Grp)
        If (vsz.Width = 0) Or (vsz.Height = 0) Then Throw New DirectShowException("�r�f�I�T�C�Y���s���ł��B")

        '�Đ��ʒu�ƃT�C�Y����
        Dim pos As Point, sz As Size
        Select Case Zoom
            Case RendererScale.None '�g��k���Ȃ�
                sz = vsz

            Case RendererScale.KeepAspect   '�c�����ۂ��Ċg��k��
                sz.Width = OwnerSize.Width
                sz.Height = CInt(vsz.Height * sz.Width / vsz.Width)
                If sz.Height > OwnerSize.Height Then
                    sz.Height = OwnerSize.Height
                    sz.Width = CInt(vsz.Width * sz.Height / vsz.Height)
                End If

            Case RendererScale.Full '�S�̂Ɋg��k���Ȃ�
                sz = OwnerSize

            Case Else
                Exit Sub
        End Select
        pos.X = (OwnerSize.Width - sz.Width) \ 2
        pos.Y = (OwnerSize.Height - sz.Height) \ 2

        ' 2015.09.12 hayakawa �ǉ�����������
        PubConstClass.imageWinWidth = sz.Width
        PubConstClass.imageWinHeight = sz.Height
        ' 2015.09.12 hayakawa �ǉ��������܂�

        '�I�[�i�[�ݒ�
        rc = vw.put_Owner(Owner)
        If rc <> 0 Then Throw New DirectShowException(rc)

        '�E�B���h�E�X�^�C���ύX
        rc = vw.put_WindowStyle(&H40000000)
        If rc <> 0 Then Throw New DirectShowException(rc)

        '�ʒu�ύX
        rc = vw.SetWindowPosition(pos.X, pos.Y, sz.Width, sz.Height)
        If rc <> 0 Then Throw New DirectShowException(rc)

        '����
    End Sub

#End Region

End Module
