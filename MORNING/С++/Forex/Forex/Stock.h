#pragma once

#include <map>

class Stock
{
private:
	std::map<double, double> sellBets, buyBets;

public:
	double getSellRate() const {

		if (sellBets.size() == 0)
			return 2.0;
		return sellBets.begin()->first;
	};
	double getBuyRate() const {
		if (buyBets.size() == 0)
			return 1.1;
		return buyBets.rbegin()->first;
	};

	void makeSellBet(const double rate, double amount);
	void makeBuyBet(const double rate, double amount);
	void buy(double amount);
	void sell(double amount);
	Stock();
	~Stock();
};
