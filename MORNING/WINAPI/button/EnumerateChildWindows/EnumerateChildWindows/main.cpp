#include <windows.h>
#include <tchar.h>

LRESULT CALLBACK WindowProc(HWND, UINT, WPARAM, LPARAM);

TCHAR szClassWindow[] = TEXT("Каркасное приложение");

HWND hwndButton2, hwndButton3, hwndButtonNoAnswer;

BOOL CALLBACK EnumWindowsProc(HWND hWnd, LPARAM lParam)
{
	HWND hWindow = (HWND)lParam; // дескриптор окна нашего приложения
	TCHAR caption[MAX_PATH] = { 0 }, classname[100] = { 0 }, text[500] = { 0 };
	SetWindowText(hWnd, TEXT("111111111111111")); // задаем название текущего окна
	GetWindowText(hWnd, caption, 100); // получаем текст заголовка текущего окна верхнего уровня
	GetClassName(hWnd, classname, 100); // получаем имя класса текущего окна верхнего уровня
	if (lstrlen(caption))
	{
		lstrcat(text, TEXT("Заголовок окна: "));
		lstrcat(text, caption);
		lstrcat(text, TEXT("\n"));
		lstrcat(text, TEXT("Класс окна: "));
		lstrcat(text, classname);
		//MessageBox(hWindow, text, TEXT("Перечисление окон верхнего уровня"), MB_OK | MB_ICONINFORMATION);
	}
	return TRUE; // продолжаем перечисление окон верхнего уровня
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
	case WM_DESTROY: // если окно разрушено
		PostQuitMessage(0); // закрываем программу
		break;
	case WM_KEYDOWN:

		if (wParam == VK_CONTROL)
			EnumWindows(EnumWindowsProc, (LPARAM)hWnd); // просим ос обработать все открытые окна нашей процедурой
		break;
	default:
		return DefWindowProc(hWnd, message, wParam, lParam); // работать по умолчанию
	}
	return 0;
}


int WINAPI _tWinMain(HINSTANCE hInst, HINSTANCE hPrevInst, LPTSTR lpszCmdLine, int nCmdShow)
{
	HWND hWnd;
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
	hWnd = CreateWindowEx(0, szClassWindow, TEXT("Перечисление окон верхнего уровня"), WS_OVERLAPPEDWINDOW,
		100, 100, 600, 600, NULL, NULL, hInst, NULL);

	TCHAR question[] = TEXT("Сколько будет 2 + 2 ?");

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
		L"Нет правильного ответа",      // Button text 
		WS_TABSTOP | WS_VISIBLE | WS_CHILD | BS_DEFPUSHBUTTON,  // Styles 
		10,         // x position 
		85,         // y position 
		200,        // Button width
		20,        // Button height
		hWnd,     // Parent window
		NULL,       // No menu.
		hInst,
		NULL);      // Pointer not needed.


	HWND label = CreateWindowEx(0, TEXT("STATIC"), L"Сколько будет 2 + 2 ?",
		WS_CHILD | WS_VISIBLE | WS_BORDER | SS_CENTER | WS_EX_CLIENTEDGE,
		10, 10, 200, 25, hWnd, 0, hInst, 0);



	// ос задает способ прорисовки окна (развернутым или свернутым)
	ShowWindow(hWnd, nCmdShow);
	// выводим на экран
	UpdateWindow(hWnd);



	MessageBox(hWnd, TEXT("Для перечисления окон верхнего уровня нажмите <CTRL>"), TEXT("Перечисление окон верхнего уровня"), MB_OK | MB_ICONINFORMATION);

	while (GetMessage(&Msg, NULL, 0, 0))
	{
		//TranslateMessage(&Msg);


		// вызывает оконную процедуру внутри себя
		DispatchMessage(&Msg);
	}
	return Msg.wParam;
}

// 1. заменить название калькулятор на бульбулятор
// 2. заменить название всем окнам
// 3. на всех кнопках калькулятора написать "здесь был я"