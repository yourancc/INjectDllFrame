// SimpleDll.cpp : ���� DLL Ӧ�ó���ĵ���������
//

#include "stdafx.h"
#include "SimpleDll.h"


// ���ǵ���������һ��ʾ��
SIMPLEDLL_API int nSimpleDll=0;
SIMPLEDLL_API  HHOOK g_Hook = NULL;
// ���ǵ���������һ��ʾ����
SIMPLEDLL_API int fnSimpleDll(void)
{
    return 42;
}
C_DLL_API int showMessage(WCHAR * text)
{
	return MessageBoxW(NULL, text, L"��ʾ", MB_OK);
}
C_DLL_API int showMessage2()
{
	return MessageBoxW(NULL, L"123", L"��ʾ", MB_OK);
}
C_DLL_API VOID SetHookOn(DWORD threadId)
{
	g_Hook = SetWindowsHookExW(WH_GETMESSAGE, GetMessageHookProcW, ::GetModuleHandle(TEXT("SimpleDll.dll")), threadId);
}
C_DLL_API VOID SetHookAllOn()
{
	g_Hook = SetWindowsHookExW(WH_GETMESSAGE, GetMessageHookProcW, ::GetModuleHandle(TEXT("SimpleDll.dll")), 0);
}
C_DLL_API VOID SetHookOff()
{
	UnhookWindowsHookEx(g_Hook);
}
VOID check(HMODULE hmodule)
{
	HWND hwnd = FindWindowW(L"GAME", L"Shaiya");
	DWORD pid;
	GetWindowThreadProcessId(hwnd, &pid);
	if (GetCurrentProcessId() == pid)
	{
		showMessage(L"��ע�뵽����");
	}
	//else 
	//{
	//	FreeLibraryAndExitThread(hmodule, 0); ;
	//	::CreateThread(NULL, 0, (LPTHREAD_START_ROUTINE)FreeLibrary, (LPVOID)hmodule, 0, NULL);
	//}
}
LRESULT CALLBACK GetMessageHookProcW(int nCode, WPARAM wParam, LPARAM lParam) 
{
	MSG* pMsg = (MSG*)lParam;
	if (WM_NULL == pMsg->message)
	::LoadLibraryW(TEXT("D://MyDLL.dll"));
	return CallNextHookEx(g_Hook, nCode, wParam, lParam);
}