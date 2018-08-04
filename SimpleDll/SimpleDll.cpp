// SimpleDll.cpp : ���� DLL Ӧ�ó���ĵ���������
//

#include "stdafx.h"
#include "SimpleDll.h"

SIMPLEDLL_API  HHOOK g_Hook = NULL;

C_DLL_API int showMessage(WCHAR * text)
{
	return MessageBoxW(NULL, text, L"��ʾ", MB_OK);
}
C_DLL_API int showMessage2()
{
	return MessageBoxW(NULL, L"123", L"��ʾ", MB_OK);
}

///*********************************************************
///��������������Ϊ��ģ��ľ��
///����ֵ����
///��;�����ڼ�⵱ǰģ��ע��Ľ����Ƿ�ΪĿ�����
///*********************************************************
VOID check(HMODULE hmodule)
{
	
	HWND hwnd = FindWindowW(L"Ŀ���������",L"Ŀ�����");
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

///*********************************************************
///����������
///����ֵ��
///��;��ȫ�ֻص��Ĺ��̺���
///*********************************************************
LRESULT CALLBACK GetMessageHookProcW(int nCode, WPARAM wParam, LPARAM lParam)
{
	MSG* pMsg = (MSG*)lParam;
	if (WM_NULL == pMsg->message)
		::LoadLibraryW(TEXT("D://MyDLL.dll"));
	return CallNextHookEx(g_Hook, nCode, wParam, lParam);
}
///*********************************************************
///����������Ҫע����߳�
///����ֵ��
///��;��HookĿ���߳�ע��Dll
///*********************************************************
C_DLL_API VOID SetHookOn(DWORD threadId)
{
	g_Hook = SetWindowsHookExW(WH_GETMESSAGE, GetMessageHookProcW, ::GetModuleHandle(TEXT("SimpleDll.dll")), threadId);
}
///*********************************************************
///����������
///����ֵ��
///��;��ȫ��Hookע��Dll
///*********************************************************
C_DLL_API VOID SetHookAllOn()
{
	g_Hook = SetWindowsHookExW(WH_GETMESSAGE, GetMessageHookProcW, ::GetModuleHandle(TEXT("SimpleDll.dll")), 0);
}

///*********************************************************
///����������
///����ֵ��
///��;�����Hook
///*********************************************************
C_DLL_API VOID SetHookOff()
{
	UnhookWindowsHookEx(g_Hook);
}