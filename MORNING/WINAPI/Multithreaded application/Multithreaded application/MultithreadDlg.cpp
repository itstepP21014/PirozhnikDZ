#include "MultithreadDlg.h"
#include <string>
#include <ctime>
using namespace std;

HWND hList;
int cnt = 0;
CRITICAL_SECTION cr;

CRITICAL_SECTION our_section;
int counter_global = 0;
wstring buf_main, buf_main_2;
int first_time = 0, sec_time = 0;

CMultithreadDlg* CMultithreadDlg::ptr = NULL;

CMultithreadDlg::CMultithreadDlg(void)
{
	ptr = this;
}

CMultithreadDlg::~CMultithreadDlg(void)
{

}

void CMultithreadDlg::Cls_OnClose(HWND hwnd)
{
	EndDialog(hwnd, 0);
}

//DWORD WINAPI Thread1(LPVOID lp)
//{
//	for (int counter = 0; counter < 100000; ++counter)
//	{
//		EnterCriticalSection(&our_section);
//		++counter_global;
//		LeaveCriticalSection(&our_section);
//	}
//	return 0;
//}
//
//DWORD WINAPI Thread2(LPVOID lp)
//{
//	for (int counter = 0; counter < 100000; ++counter)
//	{
//		EnterCriticalSection(&our_section);
//		--counter_global;
//		LeaveCriticalSection(&our_section);
//	}
//	return 0;
//}
//
//DWORD WINAPI Thread_main(LPVOID lp)
//{
//	int count = (int)lp;
//	if (count == 0)
//	{
//		for (int i = 0; i < 15; i++)
//		{
//			SendMessage(hList, LB_ADDSTRING, 0, LPARAM(TEXT("Работает первый поток")));
//			Sleep(10);
//		}
//		SendMessage(hList, LB_ADDSTRING, 0, LPARAM(TEXT("Первый поток завершает работу")));
//	}
//	else if (count == 1)
//	{
//		for (int i = 0; i < 20; i++)
//		{
//			SendMessage(hList, LB_ADDSTRING, 0, LPARAM(TEXT("Работает второй поток")));
//			Sleep(10);
//		}
//		SendMessage(hList, LB_ADDSTRING, 0, LPARAM(TEXT("Второй поток завершает работу")));
//	}
//	else if (count == 2)
//	{
//		for (int i = 0; i < 10; i++)
//		{
//			SendMessage(hList, LB_ADDSTRING, 0, LPARAM(TEXT("Работает третий поток")));
//			Sleep(10);
//		}
//		SendMessage(hList, LB_ADDSTRING, 0, LPARAM(TEXT("Третий поток завершает работу")));
//	}
//	return 0;
//}

DWORD WINAPI Thread3(LPVOID lp)
{

	for (int c = 3; c < 1000000; c += 4)
	{
		bool f = true;
		for (int d = 3; d*d <= c; d += 2)
		{
			if (c % d == 0)
			{
				f = false;
				break;
			}
		}
		if (f)
		{
			f = true;
		}
	}

	return 0;
}

DWORD WINAPI Thread4(LPVOID lp)
{
	for (int c = 5; c < 1000000; c += 4)
	{
		bool f = true;
		for (int d = 3; d*d <= c; d += 2)
		{
			if (c % d == 0)
			{
				f = false;
				break;
			}
		}
		if (f)
		{
			f = true;
		}
	}

	return 0;
}

DWORD WINAPI Thread5(LPVOID lp)
{
	for (int c = 3; c < 1000000; c += 2)
	{
		bool f = true;
		for (int d = 3; d*d <= c; d += 2)
		{
			if (c % d == 0)
			{
				f = false;
				break;
			}
			if (f)
			{
				f = true;
			}
		}
	}

	return 0;
}


BOOL CMultithreadDlg::Cls_OnInitDialog(HWND hwnd, HWND hwndFocus, LPARAM lParam)
{
	hList = GetDlgItem(hwnd, IDC_LIST1);
	InitializeCriticalSection(&our_section);

	sec_time = clock(); // начальное время
	HANDLE th1 = CreateThread(NULL, 0, Thread3, (LPVOID)0, 0, NULL);
	HANDLE th2 = CreateThread(NULL, 0, Thread4, (LPVOID)1, 0, NULL);

	WaitForSingleObject(th1, INFINITE);
	WaitForSingleObject(th2, INFINITE);

	unsigned int end_time_2 = clock(); // конечное время
	sec_time = end_time_2 - sec_time; // искомое время

	SendMessage(hList, LB_ADDSTRING, 0, (LPARAM)(to_wstring(sec_time).c_str()));

	sec_time = clock(); // начальное время
	HANDLE th3 = CreateThread(NULL, 0, Thread5, (LPVOID)0, 0, NULL);

	WaitForSingleObject(th3, INFINITE);

	end_time_2 = clock(); // конечное время
	sec_time = end_time_2 - sec_time; // искомое время

	SendMessage(hList, LB_ADDSTRING, 0, (LPARAM)(to_wstring(sec_time).c_str()));
	return TRUE;
}

BOOL CALLBACK CMultithreadDlg::DlgProc(HWND hwnd, UINT message, WPARAM wParam, LPARAM lParam)
{
	switch(message)
	{
		HANDLE_MSG(hwnd, WM_CLOSE, ptr->Cls_OnClose);
		HANDLE_MSG(hwnd, WM_INITDIALOG, ptr->Cls_OnInitDialog);
	}
	return FALSE;
}
