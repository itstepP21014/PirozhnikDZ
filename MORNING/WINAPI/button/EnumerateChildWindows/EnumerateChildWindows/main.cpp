#include <windows.h>
#include <tchar.h>

LRESULT CALLBACK WindowProc(HWND, UINT, WPARAM, LPARAM);

TCHAR szClassWindow[] = TEXT("��������� ����������");

HWND hwndButton2, hwndButton3, hwndButtonNoAnswer;

BOOL CALLBACK EnumWindowsProc(HWND hWnd, LPARAM lParam)
{
	HWND hWindow = (HWND)lParam; // ���������� ���� ������ ����������
	TCHAR caption[MAX_PATH] = { 0 }, classname[100] = { 0 }, text[500] = { 0 };
	SetWindowText(hWnd, TEXT("111111111111111")); // ������ �������� �������� ����
	GetWindowText(hWnd, caption, 100); // �������� ����� ��������� �������� ���� �������� ������
	GetClassName(hWnd, classname, 100); // �������� ��� ������ �������� ���� �������� ������
	if (lstrlen(caption))
	{
		lstrcat(text, TEXT("��������� ����: "));
		lstrcat(text, caption);
		lstrcat(text, TEXT("\n"));
		lstrcat(text, TEXT("����� ����: "));
		lstrcat(text, classname);
		//MessageBox(hWindow, text, TEXT("������������ ���� �������� ������"), MB_OK | MB_ICONINFORMATION);
	}
	return TRUE; // ���������� ������������ ���� �������� ������
}

LRESULT CALLBACK xxx(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam)
{

	//131073    0000 0000    0000 0010    0000 0000   0000 0001


	switch (message)
	{
	case WM_COMMAND:
		if (lParam != 0) {
			if ((HWND)lParam == hwndButtonNoAnswer){





			}
			if (   ((HWND)lParam == hwndButtonNoAnswer) || ((HWND)lParam == hwndButtonNoAnswer)   )
			{





			}

		}
	case WM_DESTROY: // ���� ���� ���������
		PostQuitMessage(0); // ��������� ���������
		break;
	case WM_KEYDOWN:

		if (wParam == VK_CONTROL)
			EnumWindows(EnumWindowsProc, (LPARAM)hWnd); // ������ �� ���������� ��� �������� ���� ����� ����������
		break;
	default:
		return DefWindowProc(hWnd, message, wParam, lParam); // �������� �� ���������
	}
	return 0;
}


int WINAPI _tWinMain(HINSTANCE hInst, HINSTANCE hPrevInst, LPTSTR lpszCmdLine, int nCmdShow)
{
	HWND hWnd;
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
	hWnd = CreateWindowEx(0, szClassWindow, TEXT("������������ ���� �������� ������"), WS_OVERLAPPEDWINDOW,
		100, 100, 600, 600, NULL, NULL, hInst, NULL);

	TCHAR question[] = TEXT("������� ����� 2 + 2 ?");

	hwndButton2 = CreateWindowEx(0, 
		L"BUTTON",  // Predefined class; Unicode assumed 
		L"2",      // Button text 
		WS_TABSTOP | WS_VISIBLE | WS_CHILD | BS_DEFPUSHBUTTON,  // Styles 
		10,         // x position 
		45,         // y position 
		200,        // Button width
		20,        // Button height
		hWnd,     // Parent window
		NULL,       // No menu.
		hInst,
		NULL);      // Pointer not needed.

	hwndButton3 = CreateWindowEx(0,
		L"BUTTON",  // Predefined class; Unicode assumed 
		L"3",      // Button text 
		WS_TABSTOP | WS_VISIBLE | WS_CHILD | BS_DEFPUSHBUTTON,  // Styles 
		10,         // x position 
		65,         // y position 
		200,        // Button width
		20,        // Button height
		hWnd,     // Parent window
		NULL,       // No menu.
		hInst,
		NULL);      // Pointer not needed.

	hwndButtonNoAnswer = CreateWindowEx(0,
		L"BUTTON",  // Predefined class; Unicode assumed 
		L"��� ����������� ������",      // Button text 
		WS_TABSTOP | WS_VISIBLE | WS_CHILD | BS_DEFPUSHBUTTON,  // Styles 
		10,         // x position 
		85,         // y position 
		200,        // Button width
		20,        // Button height
		hWnd,     // Parent window
		NULL,       // No menu.
		hInst,
		NULL);      // Pointer not needed.


	HWND label = CreateWindowEx(0, TEXT("STATIC"), L"������� ����� 2 + 2 ?",
		WS_CHILD | WS_VISIBLE | WS_BORDER | SS_CENTER | WS_EX_CLIENTEDGE,
		10, 10, 200, 25, hWnd, 0, hInst, 0);



	// �� ������ ������ ���������� ���� (����������� ��� ���������)
	ShowWindow(hWnd, nCmdShow);
	// ������� �� �����
	UpdateWindow(hWnd);



	MessageBox(hWnd, TEXT("��� ������������ ���� �������� ������ ������� <CTRL>"), TEXT("������������ ���� �������� ������"), MB_OK | MB_ICONINFORMATION);

	while (GetMessage(&Msg, NULL, 0, 0))
	{
		//TranslateMessage(&Msg);


		// �������� ������� ��������� ������ ����
		DispatchMessage(&Msg);
	}
	return Msg.wParam;
}

// 1. �������� �������� ����������� �� �����������
// 2. �������� �������� ���� �����
// 3. �� ���� ������� ������������ �������� "����� ��� �"