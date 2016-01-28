#include <windows.h>
#include <tchar.h>
#include <list>
#include <string>
#include <fstream>
#include <locale>
#include <codecvt>
#include <sstream>
#include <algorithm>
#include <chrono> 
#include <random>
#include <vector>

using namespace std;

LRESULT CALLBACK WindowProc(HWND, UINT, WPARAM, LPARAM);
TCHAR szClassWindow[] = TEXT("��������� ����������");
HWND hWnd; // ���������� �������� ����

HINSTANCE hInst;
HWND button;

LRESULT CALLBACK xxx(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam) {

	switch (message){
	case WM_COMMAND:
		if ((HWND)lParam)
		{
			HANDLE hBitmap;
			//hBitmap = LoadImage((HINSTANCE)lParam, L"../krestiki.bmp", IMAGE_BITMAP, 100, 100, LR_DEFAULTCOLOR);
			hBitmap = LoadImage(NULL, L"../krestiki.bmp", IMAGE_BITMAP, 0, 0, LR_LOADFROMFILE);
			if (hBitmap == NULL){
				MessageBox(NULL, _T("Picture couldn't be downloaded"), _T("Error"), NULL);
			}
			SendMessage((HWND)lParam, BM_SETIMAGE, IMAGE_BITMAP, (LPARAM)hBitmap);
			EnableWindow((HWND)lParam, false);
		}

		break;
	case WM_DESTROY: // ���� ���� ���������
		PostQuitMessage(0); // ��������� ���������
		break;
	default:
		return DefWindowProc(hWnd, message, wParam, lParam); // �������� �� ���������
	}
	return 0;
}

int WINAPI _tWinMain(HINSTANCE hInst, HINSTANCE hPrevInst, LPTSTR lpszCmdLine, int nCmdShow)
{
	MSG Msg;

	// ������ �������������� ������ ����
	WNDCLASSEX wcl;
	wcl.cbSize = sizeof(wcl);
	wcl.style = CS_HREDRAW | CS_VREDRAW;
	wcl.lpfnWndProc = xxx;
	wcl.cbClsExtra = 0;
	wcl.cbWndExtra = 0;
	wcl.hInstance = hInst;
	wcl.hIcon = LoadIcon(NULL, IDI_APPLICATION);
	wcl.hCursor = LoadCursor(NULL, IDC_ARROW);
	wcl.hbrBackground = (HBRUSH)GetStockObject(WHITE_BRUSH);
	wcl.lpszMenuName = NULL;
	wcl.lpszClassName = szClassWindow;
	wcl.hIconSm = NULL;
	// ������������ ���������� ����� ����
	if (!RegisterClassEx(&wcl))
		return 0;
	// ������� ���� ������������������� ������
	hWnd = CreateWindowEx(0, szClassWindow, TEXT("Repead words"), WS_OVERLAPPEDWINDOW,
		100, 100, 315, 337, NULL, NULL, hInst, NULL);

	int x = 0, y = 0;
	for(int c = 0; c < 3; ++c, y = c * 100){
		for (int i = 0; i < 3; ++i){
			x = i * 100;
			button = CreateWindowEx(0, L"BUTTON", L"gjdfhjg", WS_TABSTOP | WS_VISIBLE | WS_CHILD | BS_DEFPUSHBUTTON,
				x, y, 100, 100, hWnd, (HMENU)i, 0, NULL);
		}
	}

	// �� ������ ������ ���������� ���� (����������� ��� ���������)
	ShowWindow(hWnd, nCmdShow);
	// ������� �� �����
	UpdateWindow(hWnd);

	while (GetMessage(&Msg, NULL, 0, 0))
	{
		// �������� ������� ��������� ������ ����
		DispatchMessage(&Msg);
	}
	return Msg.wParam;
}