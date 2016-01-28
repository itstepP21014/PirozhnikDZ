using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    class Bank
    {
        private int spentOnAudit = 0;
        private int corruptedMoneyRevealed= 0;



        Auditor auditor = new Auditor();

        // black list

        public Bank()
        {
            
        }

        public void PerformDeal(Deal d)
        {
            auditor.Check(d);
            // тратит 1% от суммы, чтобы узнать честная сделка или нет

        }

    }
}

// задача банка определить максимальное число нечестных сделок у контрактора