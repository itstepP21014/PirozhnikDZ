#include "Centralbank.h"
#include <cmath>

void CentralBank::act() {
	if (fabs((stock.getSellRate() - sellRate) / stock.getSellRate()) > 0.05) {
		if (stock.getSellRate() > sellRate)
			sellRate = stock.getSellRate() + 0.01;
		else  
			sellRate = stock.getSellRate() - 0.01;
		stock.makeSellBet(sellRate, pow(10, 6));
	}

	if (fabs((stock.getBuyRate() - buyRate) / stock.getBuyRate()) > 0.05) {
		if (stock.getBuyRate() > buyRate)
			buyRate = stock.getBuyRate() + 0.01;
		else
			buyRate = stock.getBuyRate() - 0.01;
		stock.makeBuyBet(buyRate, pow(10, 6));
	}
}