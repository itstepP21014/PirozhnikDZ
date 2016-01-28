#include "Stock.h"
#include "Buddy.h"
#include "Player.h"
#include "Client.h"

#include <iostream>
#include <vector>
#include <fstream>
#include <ctime>

using namespace std;
int main() {
	srand(time(nullptr));
	Stock stock;
	vector<Buddy*> buddies{ new Player(stock), new Client(stock) };
	stock.makeBuyBet(1.0, 1000000000000);
	stock.makeSellBet(1.8, 1000000000000);
	stock.makeBuyBet(1.24, 1000);
	stock.makeSellBet(1.26, 1000);
	stock.makeBuyBet(1.239, 100000);
	stock.makeSellBet(1.261, 100000);

	ofstream fs("stock.csv");
	fs.imbue(locale("")); // использовать региональные настройки по умолчанию
	fs << "time;buy rate;sell rate\n";
	for (int time = 0; time < 10000; ++time) {
		for (auto b : buddies) {
			b->act();
		}
		fs << time << ";" << stock.getBuyRate() << ";" << stock.getSellRate() << "\n";

	}

	fs.close();

	std::cout << "End\n";
	getc(stdin);
	return 0;
}