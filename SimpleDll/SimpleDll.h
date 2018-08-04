// 下列 ifdef 块是创建使从 DLL 导出更简单的
// 宏的标准方法。此 DLL 中的所有文件都是用命令行上定义的 SIMPLEDLL_EXPORTS
// 符号编译的。在使用此 DLL 的
// 任何其他项目上不应定义此符号。这样，源文件中包含此文件的任何其他项目都会将
// SIMPLEDLL_API 函数视为是从 DLL 导入的，而此 DLL 则将用此宏定义的
// 符号视为是被导出的。
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
