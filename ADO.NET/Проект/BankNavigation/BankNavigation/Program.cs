using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyLibrary;

namespace BankNavigation
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());

            string CS = @"Data Source=(localdb)\v11.0;Initial Catalog=MapProject.Context.mdf;Integrated Security=True";
            Context db = new Context(CS);
            int dd = db.Adresses.Count();
        }
    }
}
