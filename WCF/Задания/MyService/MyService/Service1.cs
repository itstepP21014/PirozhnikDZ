using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace MyService
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            this.MyFun("Service started");
        }

        protected override void OnStop()
        {
            this.MyFun("Service stopped");
        }

        private void MyFun(string msg)
        {
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter("my_service.txt", true);
                msg += "\t\t";
                msg += DateTime.Now.ToLongTimeString();
                sw.WriteLine(msg);
            }
            catch(Exception ex)
            {
                sw = new StreamWriter("my_service.txt", true);
                msg += "\t\t";
                sw.WriteLine(ex.Message);
            }
            finally
            {
                sw.Close();
            }
        }
    }
}
