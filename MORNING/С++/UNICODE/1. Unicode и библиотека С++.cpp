#include <iostream>
using namespace std;

void main()
{
	// ANSI-���������
	char szBuf1[15] = "Hello,";
	strcat(szBuf1, " world!");
	cout << sizeof(szBuf1) << " bytes\n"; // 15 ����

	// UNICODE-���������
	wchar_t szBuf2[15] = L"Hello,";
	wcscat(szBuf2, L" world!");
	cout << sizeof(szBuf2) << " bytes\n"; // 30 ����
}

