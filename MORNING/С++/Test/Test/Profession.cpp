#include "profession.h"
#include "Functions.h"
#include "trait.h"
#include <fstream>
#include <exception>
#include <string>
#include <sstream>

using std::ifstream;
using std::exception;
using std::string;
using std::getline;
using std::stringstream;

std::vector<Profession> Profession::professions;

void Profession::add_professions() {
	ifstream file("professions.csv");
	if (!file.is_open())
		throw exception("File \"professions.csv\" is not found.");

	int current_index = 0, test_index;

	string buffer;
	while (!file.eof()) {
		getline(file, buffer);

		std::vector<std::string> values = parse_csv_line(buffer);
		auto it = values.begin();

		stringstream ss(*(it++));
		ss >> test_index;
		if (current_index != test_index) {
			file.close();
			throw exception("There's a mistake in \"professions.csv\".");
		}

		string profession_name = *(it++);
		std::vector<trait_numb> related_traits;
		trait_numb tr_number;

		while (it != values.end()) {
			stringstream ss_trait(*(it++));
			ss_trait >> tr_number;
			related_traits.push_back(tr_number);
		}

		Profession::professions.push_back(Profession(profession_name, related_traits));
		++current_index;
	}

	file.close();
}