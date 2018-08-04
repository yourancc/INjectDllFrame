// ���� ifdef ���Ǵ���ʹ�� DLL �������򵥵�
// ��ı�׼�������� DLL �е������ļ��������������϶���� SIMPLEDLL_EXPORTS
// ���ű���ġ���ʹ�ô� DLL ��
// �κ�������Ŀ�ϲ�Ӧ����˷��š�������Դ�ļ��а������ļ����κ�������Ŀ���Ὣ
// SIMPLEDLL_API ������Ϊ�Ǵ� DLL ����ģ����� DLL ���ô˺궨���
// ������Ϊ�Ǳ������ġ�
#ifdef SIMPLEDLL_EXPORTS
#define SIMPLEDLL_API extern "C"  __declspec(dllexport)
#define C_DLL_API extern "C" __declspec(dllexport)
#else
#define SIMPLEDLL_API extern "C"  __declspec(dllimport)
#define C_DLL_API extern "C" __declspec(dllexport)
#endif

SIMPLEDLL_API  HHOOK g_Hook;
C_DLL_API HMODULE hModul;
LRESULT CALLBACK GetMessageHookProcW(int nCode, WPARAM wParam, LPARAM lParam);
C_DLL_API INT showMessage(WCHAR * text);
C_DLL_API int showMessage2();
C_DLL_API VOID SetHookOn(DWORD threadId);
C_DLL_API VOID SetHookAllOn();
C_DLL_API VOID SetHookOff();

VOID check(HMODULE hmodule);
SIMPLEDLL_API int nSimpleDll;

SIMPLEDLL_API int fnSimpleDll(void);
