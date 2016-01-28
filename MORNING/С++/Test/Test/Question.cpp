#include "Question.h"
#include <vector>
#include "Functions.h"
#include <string>
#include <fstream>
#include <sstream>
#include <map>


void Question::LoadAnswers()
{
	std::string buffer, number;
	std::ifstream file;

	file.open("../Data/Answers.csv");
	if (!file.is_open())
		throw std::exception("Error: file(Question.csv) is not opened!\n");


	while (!file.eof())
	{
		std::getline(file, buffer);
		std::vector<std::string> data = parse_csv_line(buffer);
		if (!data.size())
			break;


		Answer answer(data[1]);
		for (auto it = data.begin() + 2; it != data.end(); it++)
		{
			// read trait number
			int trait_, score_;
			number = *it;
			std::stringstream ss1(number);
			ss1 >> trait_;

			//read score
			it++;

			number = *it;
			std::stringstream ss2(number);
			ss2 >> score_;
			answer.add_point(trait_, score_);
		}
		answers.push_back(answer);


	}
	file.close();
}