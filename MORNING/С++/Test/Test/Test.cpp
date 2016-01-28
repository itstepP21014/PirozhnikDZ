#include "Test.h"
#include <string>
#include <fstream>
#include <sstream>
#include "Question.h"
#include "Functions.h"
#include <iostream>

std::vector<Question> Test::questions;

void Test::load_questions() {
	// check
	if (questions.size()) {
		return;
	}
	std::string buf, number;
	std::ifstream file;
	file.open("Questions.csv");
	if (!file.is_open()) {
		throw std::exception("File questions.csv: Error opening file\n");
	}
	int counter = 0, question_num;
	while (!file.eof()) {
		// читаем очередную строчку из файла в переменную buf
		std::getline(file, buf);
		std::vector<std::string> data = parse_csv_line(buf);
		if (!data.size())
			break;
		number = data[0];
		std::stringstream ss(number);
		// считываем число в переменную number (как scanf)
		ss >> question_num;
		if (counter != question_num) {
			throw std::exception("File questions.csv: Error file content\n");
		}
		Question q(data[1]);
		questions.push_back(q);
		++counter;
	}
	file.close();
}

void Test::load_professions()
{
	// check
	if (professions.size())
		return;

	std::string buffer, number;
	std::ifstream file;
	file.open("Professions.csv");

	if (!file.is_open())
		throw std::exception("Error: file(Professions.csv) is not opened!\n");

	int counter = 0, question_num;

	while (!file.eof())
	{
		std::getline(file, buffer);
		std::vector<std::string> data = parse_csv_line(buffer);
		if (!data.size())
			break;

		number = data[0];
		std::stringstream ss(number);
		ss >> question_num;

		if (counter == question_num)
		{
			Profession prof(data[1]);
			for (auto it = data.begin() + 2; it != data.end(); it++)
			{
				int trait;
				number = *it;
				std::stringstream ss(number);
				ss >> trait;
				prof.add_trait(trait);
			}
			professions.push_back(prof);
			counter++;
		}
		else
		{
			file.close();
			throw std::exception("Error: file(Question.csv) content!\n");
		}
	}
	file.close();
}


void Test::load_traits()
{
	// check
	if (traits.size())
		return;

	std::string buffer, number;
	std::ifstream file;
	file.open("../Data/Traits.csv");
	if (!file.is_open())
		throw std::exception("Error: file(Question.csv) is not opened!\n");
	int counter = 0, question_num;

	while (!file.eof())
	{
		std::getline(file, buffer);
		std::vector<std::string> data = parse_csv_line(buffer);
		if (!data.size())
			break;

		number = data[0];
		std::stringstream ss(number);
		ss >> question_num;

		if (counter == question_num)
		{
			Trait trait(data[1]);
			traits.push_back(trait);
			counter++;
		}
		else
		{
			file.close();
			throw std::exception("Error: file(Question.csv) content!\n");
		}
	}
	file.close();
}



void Test::start_test()
{
	for (auto it = questions.begin(); it != questions.end(); it++) {
		ask();
	}

}


void Test::ask()
{
	// ASK QUESTION

	std::cout << questions[current_question].question << std::endl;
	// output annswer options for this question
	int answer_num = 1;
	for (auto it = questions[current_question].answers.begin(); it != questions[current_question].answers.end(); it++, answer_num++)
		std::cout << answer_num << it->answer << std::endl;
	// processing answer
	int ratee_response;
	do
	{
		std::cin >> ratee_response;
		if (ratee_response < 1 && ratee_response > answer_num - 1)
			std::cout << "You enter invalid number! Try again!" << std::endl;
	} while (ratee_response < 1 && ratee_response > answer_num - 1);


	// PROCESSING RESULT

	auto points = ((questions[current_question]).answers)[ratee_response - 1].points;
	for (auto it = points.begin(); it != points.end(); it++)
		ratee.result[it->first] += it->second;
	current_question++;
}


void Test::show_result()
{
	int prof_number = 0;
	for (auto it = professions.begin(); it != professions.end(); it++, prof_number++)
	{
		// ????????????????????????????????????????
		ratee.final_result[prof_number] = 0;
		for (auto trait = it->traits.begin(); trait != it->traits.end(); trait++)
			ratee.final_result[prof_number] += ratee.result[*trait];
	}


	int max_prof_point = 0;
	for (auto it = ratee.final_result.begin(); it != ratee.final_result.end(); it++)
		max_prof_point > it->second ? max_prof_point : it->second;


	size_t profession_number;
	for (auto it = ratee.final_result.begin(); it != ratee.final_result.end(); it++)
	{
		if (it->second == max_prof_point)
		{
			profession_number = it->first;
			std::cout << professions[profession_number].name << std::endl;
		}
	}

}