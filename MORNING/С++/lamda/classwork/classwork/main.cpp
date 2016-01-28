#include <vector>
#include <functional>
#include <iostream>
#include <algorithm>
#include <numeric>

// вернет тру если число делится на 3
bool devided_3(int n) {
	return  (n % 3 == 0);
	/*
	if (n % 3 == 0)
		return true;
	else
		return false;
		*/
}

std::vector<int> primes = { 2, 3, 5, 7 }; // массив для отобранных простых чисел

// функция которая возвращвет тру если число простое
bool is_prime(int c) {
	// count_if возвращает количество чисел на которое делится наше число
	int dividers = std::count_if(primes.begin(), primes.end(), [c](int n){return (c % n == 0) && (c > n); });

	if (dividers == 0) {
		return true; // наше число простое
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

	// строка из чисел,разделенных ;
	// список чисел, отличающихся от предыдущих более чем на 1
}