#include <windows.h>
#include <tchar.h>
#include <list>
#include <string>
#include <fstream>
#include <locale>
#include <codecvt>
#include <sstream>

LRESULT CALLBACK WindowProc(HWND, UINT, WPARAM, LPARAM);

TCHAR szClassWindow[] = TEXT("Каркасное приложение");

using namespace std;

HWND hWnd; // дискриптор главного окна
list <wstring> items = { L"Картофель", L"Морковь", L"Яблоки", L"Помидоры", L"Лимон", L"Виноград", L"Сливы", L"Огурцы", L"Гранат", L"Вишня", L"Клубника", L"Малина" };
HWND list_box, basket;
list <wstring> purchase;

LRESULT CALLBACK xxx(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam)
{

	switch (message)
	{
	case WM_COMMAND:
		if (HWND(lParam) == list_box && HIWORD(wParam) == LBN_SELCHANGE)
		{
			int i = SendMessage(list_box, LB_GETCURSEL, 0, 0);
			wchar_t buf[15];
			SendMessage(list_box, LB_GETTEXT, i, LPARAM(buf));

			SendMessage(basket, LB_ADDSTRING, 0, LPARAM(buf));
			
		}
		if (HWND(lParam) == basket && HIWORD(wParam) == LBN_SELCHANGE)
		{
			int i = SendMessage(basket, LB_GETCURSEL, 0, 0);
			SendMessage(basket, LB_DELETESTRING, i, 0);
		}




		break;
	case WM_DESTROY: // если окно разрушено
		PostQuitMessage(0); // закрываем программу
		break;
	default:
		return DefWindowProc(hWnd, message, wParam, lParam); // работать по умолчанию
	}
	return 0;
}

int WINAPI _tWinMain(HINSTANCE hInst, HINSTANCE hPrevInst, LPTSTR lpszCmdLine, int nCmdShow)
{
	
	MSG Msg;

	// задаем характеристики классу окна
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
	// регистрируем полученный класс окна
	if (!RegisterClassEx(&wcl))
		return 0;
	// создаем окно зарегистрированного класса
	hWnd = CreateWindowEx(0, szClassWindow, TEXT("Корзина товаров"), WS_OVERLAPPEDWINDOW,
		100, 100, 800, 600, NULL, NULL, hInst, NULL);

	list_box = CreateWindow(TEXT("listbox"), TEXT(""), LBS_STANDARD | WS_CHILD | WS_VISIBLE, 10, 10, 150, 200, hWnd, NULL, hInst, NULL);

	basket = CreateWindow(TEXT("listbox"), TEXT(""), LBS_STANDARD | WS_CHILD | WS_VISIBLE, 210, 10, 150, 200, hWnd, NULL, hInst, NULL);

	for (auto it : items)
		SendMessage(list_box, LB_INSERTSTRING, 0, (LPARAM)it.c_str());


	// ос задает способ прорисовки окна (развернутым или свернутым)
	ShowWindow(hWnd, nCmdShow);
	// выводим на экран
	UpdateWindow(hWnd);

	while (GetMessage(&Msg, NULL, 0, 0))
	{
		// вызывает оконную процедуру внутри себя
		DispatchMessage(&Msg);
	}
	return Msg.wParam;
}
