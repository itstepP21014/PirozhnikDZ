#include "Stock.h"


Stock::Stock()
{
}


Stock::~Stock()
{
}

void Stock::makeSellBet(const double rate, double amount) {
	// ���� ���� ������ �� ������� � ������� ����� 
	// ������ ������� ����� �� �������
	while (rate <= getBuyRate()) {
		// bet - �������� �� ����� �������� ������ �������
		auto bet = buyBets.rbegin();
		//���� � ������������� ������ ������ ����� ��� � �����
		if (amount < bet->second) {
			// �������� ������������ ������������ ������
			bet->second -= amount;
			// � �� ������ �����
			return;
		}
		// ���� � ������������ ������ ����� �� �������
		// ������� �����������
		amount -= bet->second;
		buyBets.erase(bet->first);
		if (amount == 0) {
			// ���� ��������� ������ ������
			return;
		}
	}
	// ���� ��������, ��� ���������
	if (sellBets.find(rate) == sellBets.end())  {
		sellBets[rate] = amount;
	}
	else {
		sellBets[rate] += amount;
	}

}

void Stock::sell(double amount) {
	while (amount > 0) {
		auto bet = buyBets.rbegin();
		if (bet == buyBets.rend()) {
			return;
		}
		if (amount < bet->second){
			bet->second -= amount;
			return;
		}
		amount -= bet->second;
		buyBets.erase(bet->first);
	}
}


void Stock::makeBuyBet(double rate, double amount) {
	while (rate >= getSellRate()) {
		auto bet = sellBets.begin();
		if (amount < bet->second) {
			bet->second -= amount;
			return;
		}
		amount -= bet->second;
		sellBets.erase(bet);
		if (!amount)
			return;
	}
	if (buyBets.find(rate) == buyBets.end())
		buyBets[rate] = amount;
	else
		buyBets[rate] += amount;
}




void Stock::buy(double amount) {
	while (amount > 0) {
		auto bet = sellBets.begin();
		if (bet == sellBets.end()) {
			return;
		}
		if (amount < bet->second){
			bet->second -= amount;
			return;
		}
		amount -= bet->second;
		sellBets.erase(bet->first);
	}
}
