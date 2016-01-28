using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    class Program
    {
        static void Main(string[] args)
        {
            //Exchange birzha = new Exchange();
            //Logger protokol = new Logger();
            //Auditor audit = new Auditor();

            //birzha.bid += birzha.Deal;
            //birzha.bid += protokol.Log;
            //birzha.bid += audit.Audit;

            //birzha.takeBid();


            Bank bank = new Bank();

            Contractor [] c = new Contractor[10];
            for (int i = 0; i < c.Length; i++)
            {
                c[i] = new Contractor();
            }

            Random r = new Random();

            while (true)
            {
                
                c[r.Next(c.Length)].MakeDeal();
                //
            }







                Console.Read();
        }
    }
}
