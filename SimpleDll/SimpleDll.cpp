// SimpleDll.cpp : 定义 DLL 应用程序的导出函数。
//

#include "stdafx.h"
#include "SimpleDll.h"

SIMPLEDLL_API  HHOOK g_Hook = NULL;

C_DLL_API int showMessage(WCHAR * text)
{
	return MessageBoxW(NULL, text, L"提示", MB_OK);
}
C_DLL_API int showMessage2()
{
	return MessageBoxW(NULL, L"123", L"提示", MB_OK);
}

///*********************************************************
///函数参数：参数为本模块的句柄
///返回值：无
///用途：用于检测当前模块注入的进程是否为目标进程
///*********************************************************
VOID check(HMODULE hmodule)
{
	
	HWND hwnd = FindWindowW(L"目标进程类名",L"目标进程");
	DWORD pid;
	GetWindowThreadProcessId(hwnd, &pid);
	if (GetCurrentProcessId() == pid)
	{
		showMessage(L"已注入到进程");
	}
	//else 
	//{
	//	FreeLibraryAndExitThread(hmodule, 0); ;
	//	::CreateThread(NULL, 0, (LPTHREAD_START_ROUTINE)FreeLibrary, (LPVOID)hmodule, 0, NULL);
	//}
}

///*********************************************************
///函数参数：
///返回值：
///用途：全局回调的过程函数
///*********************************************************
LRESULT CALLBACK GetMessageHookProcW(int nCode, WPARAM wParam, LPARAM lParam)
{
	MSG* pMsg = (MSG*)lParam;
	if (WM_NULL == pMsg->message)
		::LoadLibraryW(TEXT("D://MyDLL.dll"));
	return CallNextHookEx(g_Hook, nCode, wParam, lParam);
}
///*********************************************************
///函数参数：要注入的线程
///返回值：
///用途：Hook目标线程注入Dll
///*********************************************************
C_DLL_API VOID SetHookOn(DWORD threadId)
{
	g_Hook = SetWindowsHookExW(WH_GETMESSAGE, GetMessageHookProcW, ::GetModuleHandle(TEXT("SimpleDll.dll")), threadId);
}
///*********************************************************
///函数参数：
///返回值：
///用途：全局Hook注入Dll
///*********************************************************
C_DLL_API VOID SetHookAllOn()
{
	g_Hook = SetWindowsHookExW(WH_GETMESSAGE, GetMessageHookProcW, ::GetModuleHandle(TEXT("SimpleDll.dll")), 0);
}

///*********************************************************
///函数参数：
///返回值：
///用途：解除Hook
///*********************************************************
C_DLL_API VOID SetHookOff()
{
	UnhookWindowsHookEx(g_Hook);
}