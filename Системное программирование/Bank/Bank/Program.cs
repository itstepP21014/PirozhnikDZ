using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bank
{
    class Program
    {
        static BankAccount acc = new BankAccount(2000);
        static Object o = (Object)acc;
        static int withdraw;

        static Random rnd = new Random();

        static int[] m = new int[100];


        static void Main(string[] args)
        {

        }


        static void T()
        {
            int i = rnd.Next(0, 100);
            
        }

        static void TT()
        {
            int i = rnd.Next(0, 100);
            lock(m)
            {

            }
        }





        static void Main22222(string[] args)
        {
            Thread a = new Thread(B);
            Thread b = new Thread(B);
            a.Start();
            b.Start();
            a.Join();
            b.Join();

            Console.WriteLine("На счету осталось: {0}", acc.ShowAccount());
        }

        static void B()
        {
            lock (rnd)
            {
                Console.WriteLine("Текущий баланс: {0}", ((BankAccount)o).ShowAccount());
                withdraw = rnd.Next(0, ((BankAccount)o).Account);
                Console.WriteLine("Снимаем: {0}", withdraw);
                ((BankAccount)o).Withdraw(withdraw);
            }
        }

        static void A()
        {
            System.Threading.Monitor.Enter(o);
            try
            {
                Console.WriteLine("Текущий баланс: {0}", ((BankAccount)o).ShowAccount());
                bool accept = true;
                while(accept)
                {
                    Console.WriteLine("Сколько снимаем?");
                    Int32.TryParse(Console.ReadLine(), out withdraw);
                    if (((BankAccount)o).Account - withdraw < 0)
                    {
                        Console.WriteLine("Недостаточно средств");

                    }
                    else
                    {
                        accept = false;
                    }
                }
                ((BankAccount)o).Withdraw(withdraw);
      
            }
            catch (Exception ex)
            {
                Console.WriteLine("ex");
            }
            finally
            {
                System.Threading.Monitor.Exit(o);
            }
        }

    }
}
