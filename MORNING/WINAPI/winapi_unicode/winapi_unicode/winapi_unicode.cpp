// ConsoleApplication.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"


int _tmain(int argc, _TCHAR* argv[])
{
	std::wcout.imbue(std::locale(".866")); // ������������ �� 1251 ��������� � ������ ��������� ( .866 - ��������� �������)

	wchar_t *hello = L"������ ";
	//wprintf(L"%s �������", hello);
	wchar_t buf[50];
	wcscpy(buf, hello);
	wcscat(buf, L"�������\n");
	std::wcout << buf;

	std::wregex r(L"[����������]");
	std::wstring s(buf);
	std::wsmatch m;
	int count = 0;
	while (std::regex_search(s, m, r)){
		++count;
		s = m.suffix().str();
	}
	std::wcout << count << L" ������.";

	std::wcout << L" ������";


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
