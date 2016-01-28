#pragma once

#include "Buddy.h"
#include "Stock.h"

class CentralBank : public Buddy {
private:
	double sellRate, buyRate;
public:
	CentralBank(Stock& stock) : Buddy(stock) { sellRate = stock.getSellRate(); buyRate = stock.getBuyRate(); };
	~CentralBank() {};

	virtual void act();
};