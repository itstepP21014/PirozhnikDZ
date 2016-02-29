using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class BankAccount
    {
        public int Account { get; set; }

        public BankAccount(int n)
        {
            Account = n;
        }

        public int Refill(int n)
        {
            Account += n;
            return Account;
        }

        public int Withdraw(int n)
        {
            Account -= n;
            return Account;
        }

        public int ShowAccount()
        {
            return Account;
        }
    }
}
