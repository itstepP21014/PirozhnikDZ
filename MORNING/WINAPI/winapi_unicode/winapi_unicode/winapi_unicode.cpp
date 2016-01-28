// ConsoleApplication.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"


int _tmain(int argc, _TCHAR* argv[])
{
	std::wcout.imbue(std::locale(".866")); // перекодируем из 1251 кодировки в нужную кодировку ( .866 - кодировка консоли)

	wchar_t *hello = L"Привет ";
	//wprintf(L"%s коллеги", hello);
	wchar_t buf[50];
	wcscpy(buf, hello);
	wcscat(buf, L"коллеги\n");
	std::wcout << buf;

	std::wregex r(L"[аюяиуеоэёы]");
	std::wstring s(buf);
	std::wsmatch m;
	int count = 0;
	while (std::regex_search(s, m, r)){
		++count;
		s = m.suffix().str();
	}
	std::wcout << count << L" слогов.";

	std::wcout << L" Привет";


	std::wifstream file("names.txt");
	file.imbue(std::locale(file.getloc(), new std::codecvt_utf16<wchar_t, 0x10ffff, std::consume_header>));
	std::wstring buffer;
	while (!(file.eof())){
		std::getline(file, buffer);
	}
	std::wcout << buffer;



	getc(stdin);
	return 0;
}
