#pragma once
#include "Ratee.h"
#include "Question.h"
#include "Profession.h"
#include <vector>

// тест, проходимый конкретным испытуемым
class Test
{
public:

	// объект-испытуемый
	Ratee ratee;
	// список вопросов теста
	static std::vector<Question> questions;
	// список профессий
	static std::vector<Profession> professions;
	// список характеристик
	static std::vector<Trait> traits;
	//итератор на текущий вопрос, который будет
	std::vector<Question>::iterator current_question;
	// задать очередной вопрос
	void ask();
	// если все вопросы отвечены, то показать результат теста
	void show_result();
	static void load_questions();
	static void load_professions();
	static void load_traits();
	void start_test();
	bool finished() {
		return current_question == questions.end();
	}

	Test(std::string& name_) : ratee(name_), current_question(questions.begin()) {
		load_questions();
		load_professions();
		load_traits();
	};
};
