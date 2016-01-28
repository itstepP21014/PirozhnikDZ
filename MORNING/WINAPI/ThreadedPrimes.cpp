#include <iostream>
#include <string>
#include <vector>
#include <chrono>
#include <Windows.h>

using namespace std;

CRITICAL_SECTION cs;
const int N = 2;
const int maxCandidate = 100;
vector<int> primes[N];

DWORD WINAPI Thread(LPVOID lp)
{
	int rank = (int)lp;

	for (int c = 3+rank*2; c < maxCandidate; c += N*2)
	{
		bool f = true;
		for (int d = 3; d * d <= c; d += 2)
		{
			if (c % d == 0)
			{
				f = false;
				break;
			}
		}
		if (f)
		{
			primes[rank].push_back(c);
		}

	}
	return 0;
}


int main()
{
	using namespace std::chrono;
	system_clock::time_point before = system_clock::now();

	InitializeCriticalSection(&cs);
	HANDLE threads[N];
	for (int i = 0; i < N; i++) {
		threads[i] = CreateThread(NULL, 0, Thread, (LPVOID)i, 0, NULL);
	}
	WaitForMultipleObjects(N, threads, TRUE, INFINITE);
	
	vector<int>::iterator its[N];
	for (int i = 0; i < N; i++) {
		its[i] = primes[i].begin();
	}

	while (true) {
		// get minimal from primes
		int min = -1;
		int minV = maxCandidate;
		for (int i = 0; i < N; i++) {
			if (its[i] != primes[i].end() )
			if ( (*(its[i])) < minV ) {
				minV = *(its[i]);
				min = i;
			}
		}
		if (min == -1) {
			break;
		}
		cout << *its[min] << '\n';
		its[min]++;
	}



	DeleteCriticalSection(&cs);
	return 0;
}
