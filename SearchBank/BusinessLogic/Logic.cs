using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BusinessLogic
{
    public class Logic
    {
        Context db;
        public Logic()
        {
            //db = new Context();
        }

        public List<Branch> ReturnBranchs()
        {
            using (db = new Context())
            {
                return db.Branchs.ToList();
            }
        }

        public List<Bank> ReturnBanks()
        {
            using (db = new Context())
            {
                return db.Banks.ToList();
            }
        }

        public void LoadDate()
        {
            using (db = new Context())
            {
                NumberFormatInfo formatSepar = new NumberFormatInfo();
                formatSepar.NumberDecimalSeparator = ".";

                XDocument doc = XDocument.Load("http://www.obmennik.by/xml/kurs.xml");
                //XDocument doc = XDocument.Load("banks.xml");
                foreach (XElement el in doc.Root.Elements())
                {
                    Bank bank = null;
                    foreach (XElement element in el.Elements())
                    {
                        if (element.Name == "idbank")
                        {
                            foreach (var item in db.Banks.ToList())
                            {
                                if (item.BankIdXML == Convert.ToInt32(element.Value))
                                {
                                    bank = item;
                                    break;
                                }
                            }
                            continue;
                        }
                        if (bank == null)
                            continue;
                        if (element.Name == "usd")
                        {
                            foreach (var item in element.Elements())
                            {
                                if (item.Name == "sell")
                                    bank.SellDollar = Convert.ToDecimal(item.Value);
                                else if (item.Name == "buy")
                                    bank.BuyDollar = Convert.ToDecimal(item.Value);
                            }
                            continue;
                        }
                        if (element.Name == "eur")
                        {
                            foreach (var item in element.Elements())
                            {
                                if (item.Name == "sell")
                                    bank.SellEuro = Convert.ToDecimal(item.Value);
                                else if (item.Name == "buy")
                                    bank.BuyEuro = Convert.ToDecimal(item.Value);
                            }
                            continue;
                        }
                        if (element.Name == "rur")
                        {
                            foreach (var item in element.Elements())
                            {
                                if (item.Name == "sell")
                                    bank.SellRussianRub = Convert.ToDecimal(item.Value, formatSepar);
                                else if (item.Name == "buy")
                                    bank.BuyRussianRub = Convert.ToDecimal(item.Value, formatSepar);
                            }
                            continue;
                        }
                    }
                }
                db.SaveChanges();
                db.Dispose();
            }
        }

        public void AddObject(Branch brch, int index, List<int> SelectedServices)
        {
            using (db = new Context())
            {
                brch.Bank = db.Banks.ToList()[index];
                brch.Services = new List<Service>();
                brch.Reviews = new List<Review>();
                foreach (var item in db.Services.ToList())
                {
                    for (int i = 0; i < SelectedServices.Count; ++i)
                    {
                        if (item.Id == SelectedServices[i])
                        {
                            brch.Services.Add(item);
                            SelectedServices.RemoveAt(i);
                            break;
                        }
                    }
                }
                db.Branchs.Add(brch);
                db.SaveChanges();
                db.Dispose();
            }
        }

        public struct InfoBranch
        {
            public string info;
            public double coordX;
            public double coordY;
        }

        public List<InfoBranch> ReturnInfoBranchs()
        {
            List<InfoBranch> info_branchs = new List<InfoBranch>();
            using (db = new Context())
            {
                foreach (var item in db.Branchs.ToList())
                {
                    InfoBranch ibrch = new InfoBranch();
                    ibrch.info =(String.Format(" Название: {0}\n Телефон: {1}\n Банк: {2}\n Адрес: {3}\n Дата открытия: {4}\n Время работы\n {5}-{6}", item.Name, item.Phone, item.Bank, item.Address, item.DateOpenObject.ToString("dd:MM:yyyy"), item.TimeJobOpen.ToString("HH:mm"), item.TimeJobClose.ToString("HH:mm")));
                    ibrch.info += "\n" + String.Format(" {0}     {1} {2}", "Банк", "Продажа", "Покупка");
                    ibrch.info += "\n" + String.Format(" {0} {1} {2}", "Доллар", item.Bank.SellDollar, item.Bank.BuyDollar);
                    ibrch.info += "\n" + String.Format(" {0}     {1} {2}", "Евро", item.Bank.SellEuro, item.Bank.BuyEuro);
                    ibrch.info += "\n" + String.Format(" {0}    {1}   {2}", "Рубль", item.Bank.SellRussianRub, item.Bank.BuyRussianRub);
                    ibrch.info += "\n" + " Услуги:";
                    foreach(var serv in item.Services.ToList())
                    {
                        ibrch.info += "\n";
                        ibrch.info += " " + serv.Name;
                    }
                    ibrch.info += "\n" + " Отзывы:";
                    if (item.Reviews.ToList().Count == 0)
                        ibrch.info += "\n" + " Нет отзывов";
                    else
                        foreach (var rev in item.Reviews.ToList())
                        {
                            ibrch.info += "\n";
                            ibrch.info += " " + rev.Commentator;
                            ibrch.info += "\n";
                            ibrch.info += " " + rev.Comment;
                        }
                    ibrch.coordX = item.CoordX;
                    ibrch.coordY = item.CoordY;
                    info_branchs.Add(ibrch);
                }
            }
            return info_branchs;
        }

        public void AddReview(Review rev, int index_branch)
        {
            using(db = new Context())
            {
                db.Branchs.ToList()[index_branch].Reviews.Add(rev);
                db.SaveChanges();
            }
        }

    }
    
}
