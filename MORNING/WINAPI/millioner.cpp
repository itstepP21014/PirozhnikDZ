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

void CreateContent();

HWND hWnd; // дискриптор главного окна
HWND label;
list<HWND> buttons;
int correct;
int money = 0;
list <wstring> lines;

LRESULT CALLBACK xxx(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam)
{

	switch (message)
	{
	case WM_COMMAND:
		if (lParam != 0) {
			if (wParam == correct){
				money += 500;
				for (auto it : buttons)
					DestroyWindow(it);
				buttons.clear();
				DestroyWindow(label);
				if (lines.size() > 0){
					CreateContent();
				}
				else{
					wstringstream ss;
					ss << L"Congratulations, you win " << money << L"$";
					MessageBox(hWnd, ss.str().c_str(), L"result", MB_OK);
					PostMessage(hWnd, WM_DESTROY, 0, 0);
				}
			}
			else{
				MessageBox(hWnd, L"You lost!", L"result", MB_OK);
				PostMessage(hWnd, WM_DESTROY, 0, 0);
			}
		}break;
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

	wifstream file("../1.txt");
	file.imbue(std::locale(file.getloc(), new std::codecvt_utf16<wchar_t, 0x10ffff, std::consume_header>));

	if (!file.is_open()) {
		MessageBox(0, L"File couldn't be read!", L"error", MB_OK);
		return 1;
	}

	wstring buf;
	while (getline(file, buf)) {
		lines.push_back(buf);
	}

	file.close();

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
	hWnd = CreateWindowEx(0, szClassWindow, TEXT("Кто хочет стать миллионером?"), WS_OVERLAPPEDWINDOW,
		100, 100, 800, 600, NULL, NULL, hInst, NULL);

	CreateContent();

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

void CreateContent(){

	int answer_count;

	wstringstream ss(lines.front());
	ss >> answer_count >> correct;
	lines.pop_front();

	label = CreateWindowEx(0, TEXT("STATIC"), lines.front().c_str(),
		WS_CHILD | WS_VISIBLE | WS_BORDER | SS_CENTER | WS_EX_CLIENTEDGE,
		10, 10, 750, 25, hWnd, 0, 0, 0);
	lines.pop_front();

	for (int i = 0; i < answer_count; ++i){
		HWND button = CreateWindowEx(0,
			L"BUTTON",
			lines.front().c_str(),
			WS_TABSTOP | WS_VISIBLE | WS_CHILD | BS_DEFPUSHBUTTON,
			300,         // x position 
			(45 + i * 30),         // y position 
			200,        // Button width
			20,        // Button height
			hWnd,     // Parent window
			(HMENU)i,       // menu.
			0,
			NULL);      // Pointer not needed.
		buttons.push_back(button);
		lines.pop_front();
	}
}
