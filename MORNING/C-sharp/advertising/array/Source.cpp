#include <vector>

std::vector<int>* f() {
	return new std::vector<int>(6);
}

int main() {
	auto x = f();
	x[4] = 34;
	x[7] = 7;
}