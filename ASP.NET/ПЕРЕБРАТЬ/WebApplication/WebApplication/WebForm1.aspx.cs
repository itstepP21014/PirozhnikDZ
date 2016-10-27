using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            func();
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            func();
        }

        public void func()
        {
            string html = string.Empty;
            string url = @"http://www.nbrb.by/API/ExRates/Rates?onDate=2016-7-6&Periodicity=0";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }

            List<RateShort> data = JsonConvert.DeserializeObject<List<RateShort>>(html);
            Repeater1.DataSource = data;
            Repeater1.DataBind();
        }
    }
}