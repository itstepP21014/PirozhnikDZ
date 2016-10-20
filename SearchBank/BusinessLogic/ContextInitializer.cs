using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
     public class ContextInitializer : DropCreateDatabaseAlways<Context>
    {
        protected override void Seed(Context context)
        {
            
            Bank bank = new Bank() { Name = "МТБанк", TimeUpdateCourses = DateTime.Now, BankIdXML = 1, Branchs = new List<Branch>()};
            context.Banks.Add(bank);
            bank = new Bank() { Name = "Приорбанк", TimeUpdateCourses = DateTime.Now, BankIdXML = 2, Branchs = new List<Branch>() };
            context.Banks.Add(bank);
            bank = new Bank() { Name = "Белинвестбанк", TimeUpdateCourses = DateTime.Now, BankIdXML = 3, Branchs = new List<Branch>() };
            context.Banks.Add(bank);
            bank = new Bank() { Name = "Белгазпромбанк", TimeUpdateCourses = DateTime.Now, BankIdXML = 4, Branchs = new List<Branch>() };
            context.Banks.Add(bank);
            bank = new Bank() { Name = "Франсабанк", TimeUpdateCourses = DateTime.Now, BankIdXML = 5, Branchs = new List<Branch>() };
            context.Banks.Add(bank);
            bank = new Bank() { Name = "Альфа-Банк", TimeUpdateCourses = DateTime.Now, BankIdXML = 6, Branchs = new List<Branch>() };
            context.Banks.Add(bank);
            bank = new Bank() { Name = "Паритетбанк", TimeUpdateCourses = DateTime.Now, BankIdXML = 8, Branchs = new List<Branch>() };
            context.Banks.Add(bank);
            Service serv = new Service() { Name = "Снятие наличных" };
            context.Services.Add(serv);
            serv = new Service() { Name = "Выдача кредитов" };
            context.Services.Add(serv);
            serv = new Service() { Name = "Получение отчетов" };
            context.Services.Add(serv);
            context.SaveChanges();
        }
    }
}
