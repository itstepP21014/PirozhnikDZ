// regex_search example
#include <iostream>
#include <string>
#include <regex>

int main()
{
	// задание 1
	std::string s("7 this 2,5 12,45 -7.01 6. 7,4subject has78,02 a submarine as a 1111.1111.1111.1111 subsequence 2,025.");
	std::smatch m;
	std::regex e("(\\s|^)(\\d+([,.]\\d+)?)(\\s|\\.?$)");

	std::cout << "Target sequence: " << s << std::endl;
	std::cout << "Regular expression: /\\d+[,.]\\d+/" << std::endl;
	std::cout << "The following matches and submatches were found:" << std::endl;

	while (std::regex_search(s, m, e)) {
		//for (auto x : m) std::cout << x << " ";
		std::cout << m[2] << std::endl;
		s = m.suffix().str(); // обрезает то, что нашел, и далее ищет уже в остатке
	}

	// задание 2

	//std::string s("7 this 2,5 12,45 7.01 7,4subject888.888.888.888 has78,02 a submarine 2.3.4. 45.6.45.5 as a 111.111.111.111 5 subsequence 2,025.");
	//std::smatch m;
	//std::regex e("\\b(\\d{1,3}\\.){3}\\d{1,3}\\b");
	////std::regex e("\\b(?:\\d{1,3}\\.){3}\\d{1,3}\\b"); // чтобы вывести на экран только полное совпадение (без скобок)

	//std::cout << "Target sequence: " << s << std::endl;
	//std::cout << "The following matches and submatches were found:" << std::endl;

	//while (std::regex_search(s, m, e)) {
	//	//for (auto x : m) std::cout << x << " ";
	//	std::cout << m[0] << std::endl; // чтобы вывести на экран только полное совпадение (без скобок)
	//	s = m.suffix().str(); // обрезает то, что нашел, и далее ищет уже в остатке
	//}

	//задание 3

	//std::string s("7 this 2,5  7.01 7,4subject  has78,02 a v456_jgv@jgbujhi.com 1 5 hg e-mail@x.co.uk subsequence edfe.ergv@d.g.h.j.org 2,025.");
	//std::smatch m;
	//std::regex e("\\b[\\w-_\\.]+@[\\w-_\\.]+\\.(?:com|ru|by|org|uk)\\b");

	//std::cout << "Target sequence: " << s << std::endl;
	//std::cout << "Regular expression: /\\b[\\w-_\\.]+@[\\w-_\\.]+\\.(?:com|ru|by|org|uk)\\b/" << std::endl;
	//std::cout << "The following matches and submatches were found:" << std::endl;

	//while (std::regex_search(s, m, e)) {
	//	for (auto x : m) std::cout << x << " ";
	//	std::cout << std::endl;
	//	s = m.suffix().str(); // обрезает то, что нашел, и далее ищет уже в остатке
	//}


	getc(stdin);

	return 0;
}
