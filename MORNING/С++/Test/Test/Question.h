#pragma once
#include <string>
#include <vector>
#include "Answer.h"
class Question
{
public:

	std::string text;
	std::vector<Answer> answers;

	void LoadAnswers();
	Question(std::string &text_) : text(text_) {
		LoadAnswers();
	}
};

