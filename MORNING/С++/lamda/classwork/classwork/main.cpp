#include <vector>
#include <functional>
#include <iostream>
#include <algorithm>
#include <numeric>

// ������ ��� ���� ����� ������� �� 3
bool devided_3(int n) {
	return  (n % 3 == 0);
	/*
	if (n % 3 == 0)
		return true;
	else
		return false;
		*/
}

std::vector<int> primes = { 2, 3, 5, 7 }; // ������ ��� ���������� ������� �����

// ������� ������� ���������� ��� ���� ����� �������
bool is_prime(int c) {
	// count_if ���������� ���������� ����� �� ������� ������� ���� �����
	int dividers = std::count_if(primes.begin(), primes.end(), [c](int n){return (c % n == 0) && (c > n); });

	if (dividers == 0) {
		return true; // ���� ����� �������
	}
	return false;
}


int myfunction(int x, int y) { 
	if (is_prime(y))
		return x + y;
	else
		return x;
}

int main()
{
	std::vector<int> arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 15, 16, 17 };
	int x = 3;
	int kolichestvo_chisel_del_na_x = 0;

	//kolichestvo_chisel_del_na_x = std::count_if(arr.begin(), arr.end(), devided_3 );

	kolichestvo_chisel_del_na_x = std::count_if(arr.begin(), arr.end(),
	[] (int n) {
		return  (n % 3 == 0);
	}

		);

	std::cout << kolichestvo_chisel_del_na_x << std::endl;



	int summ = std::accumulate(arr.begin(), arr.end(), 0, myfunction );

	std::cout << summ << std::endl;

	getc(stdin);
	return 0;

	// ������ �� �����,����������� ;
	// ������ �����, ������������ �� ���������� ����� ��� �� 1
}