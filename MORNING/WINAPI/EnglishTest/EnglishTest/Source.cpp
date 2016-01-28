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
TCHAR szClassWindow[] = TEXT("Каркасное приложение");
HWND hWnd; // дискриптор главного окна

class TwoWords {
public:
	wstring ru_word;
	wstring en_word;
	TwoWords(const wstring& source) {
		int i = source.find(' ');

		ru_word = source.substr(0, i);
		en_word = source.substr(i + 1);
		en_word.erase(en_word.find_last_not_of(L" \n\r\t") + 1);

	}
};

list<TwoWords> dictionary;
HWND back_button, help_button, ready_button, label;
vector<HWND> en_word_buttons, letter_buttons;
void CreateContent();
void NextWord();
int word_length;
int current_pos;
int full;
int unknown_words = 0;
int learned_words = 0;

LRESULT CALLBACK xxx(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam) {

	switch (message){
	case WM_COMMAND:

		TCHAR buf[2], buf2[2];

		// если нажали на букву
		if ((int)wParam >= 200){
			GetWindowText(HWND(lParam), buf, 2);
			if (buf[0] != NULL){
				SetWindowText(en_word_buttons[current_pos++], buf);
				SetWindowText(HWND(lParam), NULL);
				full++;
			}
		}

		if ((HWND)lParam == back_button){
			if (current_pos != 0){
				current_pos--;
				GetWindowText(en_word_buttons[current_pos], buf, 2);
				SetWindowText(en_word_buttons[current_pos], NULL);
				int empty;
				for (int i = 0; i < word_length; ++i){
					GetWindowText(letter_buttons[i], buf2, 2);
					if (buf2[0] == NULL){
						empty = i;
					}
				}
				SetWindowText(letter_buttons[empty], buf);
				full--;
			}
		}

		if ((HWND)lParam == ready_button){
			if (full == word_length){

				wstring temp = L"";
				TCHAR buf[10];
				for (size_t i = 0; i < en_word_buttons.size(); ++i){
					GetWindowText(en_word_buttons[i], buf, 2);
					temp += buf;
				}
				if (temp != dictionary.front().en_word ){
					MessageBox(hWnd, L"Word is not correct!\nTry again", L"result", MB_OK);
				}
				else{
					learned_words++;
					NextWord();
				}
			}
			else{
				MessageBox(hWnd, L"You are not finished!", L"result", MB_OK);
			}
		}

		if ((HWND)lParam == help_button){
			wstringstream ss;
			ss << L"Right answer:\n" << dictionary.front().en_word.c_str();
			MessageBox(hWnd, ss.str().c_str(), L"result", MB_OK);
			NextWord();
			unknown_words++;
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

	wifstream file("../dictionary.txt");
	file.imbue(std::locale(file.getloc(), new std::codecvt_utf16<wchar_t, 0x10ffff, std::consume_header>));

	if (!file.is_open()) {
		MessageBox(0, L"File couldn't be read!", L"Error masage", MB_OK);
		return 1;
	}

	wstring buf;
	vector <wstring> rand_dic;
	while(getline(file, buf)) {
		dictionary.push_back(buf);
		rand_dic.push_back(buf);
	}

	unsigned seed = chrono::system_clock::now().time_since_epoch().count();
	shuffle(rand_dic.begin(), rand_dic.end() - 1, default_random_engine(seed));
	
	// здесь надо записать перемешаные строки в файл

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
	hWnd = CreateWindowEx(0, szClassWindow, TEXT("Repead words"), WS_OVERLAPPEDWINDOW,
		100, 100, 400, 300, NULL, NULL, hInst, NULL);

	back_button = CreateWindowEx(0, L"BUTTON", L"delete", WS_TABSTOP | WS_VISIBLE | WS_CHILD | BS_DEFPUSHBUTTON,
		10, 120, 60, 20, hWnd, NULL, 0, NULL);

	ready_button = CreateWindowEx(0, L"BUTTON", L"ready!", WS_TABSTOP | WS_VISIBLE | WS_CHILD | BS_DEFPUSHBUTTON,
		75, 120, 60, 20, hWnd, NULL, 0, NULL); 

	help_button = CreateWindowEx(0, L"BUTTON", L"I don't know", WS_TABSTOP | WS_VISIBLE | WS_CHILD | BS_DEFPUSHBUTTON,
		140, 120, 100, 20, hWnd, NULL, 0, NULL);

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


void CreateContent() {

	label = CreateWindowEx(0, TEXT("STATIC"), dictionary.front().ru_word.c_str(),
		WS_CHILD | WS_VISIBLE | WS_BORDER | SS_CENTER | WS_EX_CLIENTEDGE, 10, 10, 230, 20, hWnd, 0, 0, 0);
	word_length = dictionary.front().en_word.length();
	for (int i = 0; i < word_length; ++i){
		HWND word_button = CreateWindowEx(0, L"STATIC", L"", WS_CHILD | WS_VISIBLE | WS_BORDER | SS_CENTER | WS_EX_CLIENTEDGE,
			(10 + i * 20), 85, 20, 20, hWnd, (HMENU)100 + i, 0, NULL);
		en_word_buttons.push_back(word_button);
	}

	unsigned seed = chrono::system_clock::now().time_since_epoch().count();
	wstring rand_en_word = dictionary.front().en_word;
	shuffle(rand_en_word.begin(), rand_en_word.end() - 1, default_random_engine(seed));

	wchar_t letter[2];
	letter[1] = 0;
	for (int i = 0; i < word_length; ++i){
		letter[0] = rand_en_word[i];
		HWND letter_button = CreateWindowEx(0, L"BUTTON", (LPCTSTR)letter, WS_TABSTOP | WS_VISIBLE | WS_CHILD | BS_DEFPUSHBUTTON,
			(10 + i * 25), 50, 20, 20,  hWnd, (HMENU)200 + i, 0, NULL);      
		letter_buttons.push_back(letter_button);
	}

}

void NextWord() {

	for (auto it : en_word_buttons)
		DestroyWindow(it);
	en_word_buttons.clear();
	for (auto it : letter_buttons)
		DestroyWindow(it);
	letter_buttons.clear();
	DestroyWindow(label);
	if (dictionary.size() > 1){
		dictionary.pop_front();
		CreateContent();
		current_pos = 0;
		full = 0;
	}
	else{
		DestroyWindow(ready_button);
		DestroyWindow(back_button);
		DestroyWindow(help_button);
		wstringstream ss;
		ss << L"Test is finished.\nlearned words: " << learned_words << L"\nunknown words: " << unknown_words;
		MessageBox(hWnd, ss.str().c_str(), L"result", MB_OK);
		PostMessage(hWnd, WM_DESTROY, 0, 0);
	}

}
