//// ���� WINDOWS.H �������� �����������, �������, � ��������� 
//// ������� ������������ ��� ��������� ���������� ��� Windows. 
//#include <windows.h>
//#include <tchar.h>
//#include <map>
//using namespace std;
//
////�������� ������� ���������
//LRESULT CALLBACK WindowProc(HWND, UINT, WPARAM, LPARAM);
//
//TCHAR szClassWindow[] = TEXT("��������� ����������"); /* ��� ������ ���� */
//
//typedef LRESULT CALLBACK EventProc(HWND hWnd, UINT uMessage, WPARAM wParam, LPARAM lParam);
//
//
//map<UINT, EventProc*> eventMap;
//
//
//LRESULT CALLBACK KeyboardHanldler(HWND hWnd, UINT uMessage, WPARAM wParam, LPARAM lParam) {
//	RECT r; // ��������� ��� ��������� ����
//	GetWindowRect(hWnd, &r);
//
//	int top = r.top; // y
//	int left = r.left; // x
//	int width = r.right - r.left;
//	int height = r.bottom - r.top;
//
//	// ������ ����������
//	if (wParam == VK_LEFT) left -= 10;
//	if (wParam == VK_RIGHT) left += 10;
//	if (wParam == VK_UP) top -= 10;
//	if (wParam == VK_DOWN) top += 10;
//
//	MoveWindow(hWnd, left, top, width, height, TRUE);
//	return 0;
//}
//
//
//LRESULT CALLBACK OnExit(HWND hWnd, UINT uMessage, WPARAM wParam, LPARAM lParam){
//	PostQuitMessage(0);	// ������� ��������� WM_QUIT
//	return 0;
//}
//
//
//INT WINAPI _tWinMain(HINSTANCE hInst, HINSTANCE hPrevInst, LPTSTR lpszCmdLine, int nCmdShow)
//{
//	HWND hWnd;
//	MSG Msg;
//	WNDCLASSEX wcl;
//
//	/* 1. ����������� ������ ����  */
//
//	wcl.cbSize = sizeof (wcl);	// ������ ��������� WNDCLASSEX 
//	wcl.style = CS_HREDRAW | CS_VREDRAW | CS_DBLCLKS;	// ���� ������ �������� ��������� � ������� ������ (DBLCLK)
//	wcl.lpfnWndProc = WindowProc;	// ����� ������� ���������
//	wcl.cbClsExtra = 0;		// ������������ Windows 
//	wcl.cbWndExtra = 0; 	// ������������ Windows 
//	wcl.hInstance = hInst;	// ���������� ������� ����������
//	wcl.hIcon = LoadIcon(NULL, IDI_APPLICATION);	// �������� ����������� ������
//	wcl.hCursor = LoadCursor(NULL, IDC_ARROW);		// �������� ������������ �������
//	wcl.hbrBackground = (HBRUSH)GetStockObject(WHITE_BRUSH);	//���������� ���� ����� ������			
//	wcl.lpszMenuName = NULL;	// ���������� �� �������� ����
//	wcl.lpszClassName = szClassWindow;	// ��� ������ ����
//	wcl.hIconSm = NULL;	// ���������� ��������� ������ ��� ����� � ������� ����
//
//
//	/*  2. ����������� ������ ����  */
//
//	if (!RegisterClassEx(&wcl))
//		return 0;	// ��� ��������� ����������� - �����
//
//	/*  3. �������� ����  */
//
//	// ��������� ���� �  ���������� hWnd ������������� ���������� ����
//	hWnd = CreateWindowEx(
//		0,		// ����������� ����� ����
//		szClassWindow,	// ��� ������ ����
//		TEXT("������  Windows ����������"),	// ��������� ����
//		/* ���������, �����, ����������� ������ �������, ��������� ����,
//		������ ������������ � ���������� ����  */
//		WS_OVERLAPPEDWINDOW,	// ����� ����
//		CW_USEDEFAULT,	// �-���������� ������ �������� ���� ����
//		CW_USEDEFAULT,	// y-���������� ������ �������� ���� ����
//		CW_USEDEFAULT,	// ������ ����
//		CW_USEDEFAULT,	// ������ ����
//		NULL,			// ���������� ������������� ����
//		NULL,			// ���������� ���� ����
//		hInst,		// ������������� ����������, ���������� ����
//		NULL);		// ��������� �� ������� ������ ����������
//
//
//	/* 4. ����������� ���� */
//
//	ShowWindow(hWnd, nCmdShow);
//	UpdateWindow(hWnd);	// ����������� ����
//
//	SetTimer(hWnd, 1, 10, NULL);
//
//
//	/* 4.5 ������������ ������� */
//
//	eventMap[WM_KEYDOWN] = KeyboardHanldler;
//	eventMap[WM_DESTROY] = OnExit;
//
//	/* 5. ������ ����� ��������� ���������  */
//
//	// ��������� ���������� ��������� �� ������� ���������
//	while (GetMessage(&Msg, NULL, 0, 0))
//	{
//		TranslateMessage(&Msg);	// ���������� ���������
//		DispatchMessage(&Msg);	// ��������������� ���������
//	}
//	return Msg.wParam;
//}
//
//
//// ������� ��������� ���������� ������������ �������� � �������� � �������� 
//// ���������� ��������� �� ������� ��������� ������� ����������	
//// - ���������� ���������
//LRESULT CALLBACK WindowProc(HWND hWnd, UINT uMessage, WPARAM wParam, LPARAM lParam29)
//{
//	if (eventMap.find(uMessage) != eventMap.end())
//	return (eventMap[uMessage])  (hWnd, uMessage, wParam, lParam29);
//	else
//		return DefWindowProc(hWnd, uMessage, wParam, lParam29);
//
//}
