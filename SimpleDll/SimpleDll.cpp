// SimpleDll.cpp : ���� DLL Ӧ�ó���ĵ���������
//

#include "stdafx.h"
#include "SimpleDll.h"


// ���ǵ���������һ��ʾ��
SIMPLEDLL_API int nSimpleDll=0;

// ���ǵ���������һ��ʾ����
SIMPLEDLL_API int fnSimpleDll(void)
{
    return 42;
}

// �����ѵ�����Ĺ��캯����
// �й��ඨ�����Ϣ������� SimpleDll.h
CSimpleDll::CSimpleDll()
{
    return;
}
