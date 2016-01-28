#pragma once
#include <string>
#include "Trait.h"
#include <vector>
#include <iostream>

class Profession
{
public:
	//name of profession
	std::string name;
	//container of requirement traits for this profession
	std::vector<trait_numb> traits;

	//container of all possible professions
	static std::vector<Profession> professions;
	//adds set of professions to container
	static void add_professions();
	void add_trait(trait_numb trait) {
		traits.push_back(trait);
	}

	//ctor
	Profession(const std::string& name_, std::vector<trait_numb> list) : name(name_), traits(list) {};
	Profession(std::string &name_) : name(name_) {}
};