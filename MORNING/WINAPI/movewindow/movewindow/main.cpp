//// Файл WINDOWS.H содержит определения, макросы, и структуры 
//// которые используются при написании приложений под Windows. 
//#include <windows.h>
//#include <tchar.h>
//#include <map>
//using namespace std;
//
////прототип оконной процедуры
//LRESULT CALLBACK WindowProc(HWND, UINT, WPARAM, LPARAM);
//
//TCHAR szClassWindow[] = TEXT("Каркасное приложение"); /* Имя класса окна */
//
//typedef LRESULT CALLBACK EventProc(HWND hWnd, UINT uMessage, WPARAM wParam, LPARAM lParam);
//
//
//map<UINT, EventProc*> eventMap;
//
//
//LRESULT CALLBACK KeyboardHanldler(HWND hWnd, UINT uMessage, WPARAM wParam, LPARAM lParam) {
//	RECT r; // структору для координат окна
//	GetWindowRect(hWnd, &r);
//
//	int top = r.top; // y
//	int left = r.left; // x
//	int width = r.right - r.left;
//	int height = r.bottom - r.top;
//
//	// меняем координыты
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
//	PostQuitMessage(0);	// посылка сообщения WM_QUIT
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
//	/* 1. Определение класса окна  */
//
//	wcl.cbSize = sizeof (wcl);	// размер структуры WNDCLASSEX 
//	wcl.style = CS_HREDRAW | CS_VREDRAW | CS_DBLCLKS;	// окно сможет получать сообщения о двойном щелчке (DBLCLK)
//	wcl.lpfnWndProc = WindowProc;	// адрес оконной процедуры
//	wcl.cbClsExtra = 0;		// используется Windows 
//	wcl.cbWndExtra = 0; 	// используется Windows 
//	wcl.hInstance = hInst;	// дескриптор данного приложения
//	wcl.hIcon = LoadIcon(NULL, IDI_APPLICATION);	// загрузка стандартной иконки
//	wcl.hCursor = LoadCursor(NULL, IDC_ARROW);		// загрузка стандартного курсора
//	wcl.hbrBackground = (HBRUSH)GetStockObject(WHITE_BRUSH);	//заполнение окна белым цветом			
//	wcl.lpszMenuName = NULL;	// приложение не содержит меню
//	wcl.lpszClassName = szClassWindow;	// имя класса окна
//	wcl.hIconSm = NULL;	// отсутствие маленькой иконки для связи с классом окна
//
//
//	/*  2. Регистрация класса окна  */
//
//	if (!RegisterClassEx(&wcl))
//		return 0;	// при неудачной регистрации - выход
//
//	/*  3. Создание окна  */
//
//	// создается окно и  переменной hWnd присваивается дескриптор окна
//	hWnd = CreateWindowEx(
//		0,		// расширенный стиль окна
//		szClassWindow,	// имя класса окна
//		TEXT("Каркас  Windows приложения"),	// заголовок окна
//		/* Заголовок, рамка, позволяющая менять размеры, системное меню,
//		кнопки развёртывания и свёртывания окна  */
//		WS_OVERLAPPEDWINDOW,	// стиль окна
//		CW_USEDEFAULT,	// х-координата левого верхнего угла окна
//		CW_USEDEFAULT,	// y-координата левого верхнего угла окна
//		CW_USEDEFAULT,	// ширина окна
//		CW_USEDEFAULT,	// высота окна
//		NULL,			// дескриптор родительского окна
//		NULL,			// дескриптор меню окна
//		hInst,		// идентификатор приложения, создавшего окно
//		NULL);		// указатель на область данных приложения
//
//
//	/* 4. Отображение окна */
//
//	ShowWindow(hWnd, nCmdShow);
//	UpdateWindow(hWnd);	// перерисовка окна
//
//	SetTimer(hWnd, 1, 10, NULL);
//
//
//	/* 4.5 Регистрируем события */
//
//	eventMap[WM_KEYDOWN] = KeyboardHanldler;
//	eventMap[WM_DESTROY] = OnExit;
//
//	/* 5. Запуск цикла обработки сообщений  */
//
//	// получение очередного сообщения из очереди сообщений
//	while (GetMessage(&Msg, NULL, 0, 0))
//	{
//		TranslateMessage(&Msg);	// трансляция сообщения
//		DispatchMessage(&Msg);	// диспетчеризация сообщений
//	}
//	return Msg.wParam;
//}
//
//
//// Оконная процедура вызывается операционной системой и получает в качестве 
//// параметров сообщения из очереди сообщений данного приложения	
//// - обработчик сообщений
//LRESULT CALLBACK WindowProc(HWND hWnd, UINT uMessage, WPARAM wParam, LPARAM lParam29)
//{
//	if (eventMap.find(uMessage) != eventMap.end())
//	return (eventMap[uMessage])  (hWnd, uMessage, wParam, lParam29);
//	else
//		return DefWindowProc(hWnd, uMessage, wParam, lParam29);
//
//}
