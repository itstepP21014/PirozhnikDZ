using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.ServiceModel;
using WCF_DuplexLibrary;


namespace WCF_DuplexService
{
    public partial class Service1 : ServiceBase
    {
        static ServiceHost sh = new ServiceHost(typeof(DuplexSvc));

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            if(sh != null)
            {
                sh.Open();
            }
        }

        protected override void OnStop()
        {
            sh.Close();
        }
    }
}
