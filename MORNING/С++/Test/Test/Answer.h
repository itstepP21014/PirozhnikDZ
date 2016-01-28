#pragma once
#include <string>
#include <map>
#include "Trait.h"

class Answer
{
public:
	//contains text of the answer
	std::string text;
	//contains container of pairs (trait_num - it's index number of trait, int - trait's score)
	std::map<trait_numb, int> points;

	//structure that contains trait_num and int fields (and have its own ctor)
	struct point {
		trait_numb num;
		int score;

		point(const trait_numb& num_, const int& score_) : num(num_), score(score_) {};
	};

	//ctors
	Answer(const std::string& text_) : text(text_) {};

	Answer(const std::string& text_, std::vector<point> list) : text(text_) {
		for (auto it = list.begin(); it != list.end(); ++it) {
			points[it->num] = it->score;
		}
	}

	//methods

	void add_point(trait_numb trait_, int score_) {
		points[trait_] = score_;
	}
};

