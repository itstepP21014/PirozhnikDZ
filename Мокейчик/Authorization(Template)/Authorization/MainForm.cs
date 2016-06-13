using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Authorization
{
    public partial class MainForm : Form
    {
        string userInfo;

        public string UserInfo
        {
            get { return userInfo; }
            set { userInfo = value; }
        }

      
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            tbUserInfo.Text = userInfo;
        }
    }
}
