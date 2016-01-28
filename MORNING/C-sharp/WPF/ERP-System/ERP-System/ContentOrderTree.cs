using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_System
{
    class ContentOrderTree : INotifyPropertyChanged
    {
        string text;
        public string Text
        {
            get { return text; }
            set { text = value; OnPropertyChanged("Text"); }
        }

        string logo;
        public string Logo
        {
            get { return logo; }
            set { logo = value; OnPropertyChanged("Logo"); }
        }

        List<ContentOrderTree> children;
        public List<ContentOrderTree> Children
        {
            get { return children; }
            set
            {
                children = value;
                OnPropertyChanged("Children");
            }
        }

        public ContentOrderTree()
        {
            children = new List<ContentOrderTree>();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler ph = this.PropertyChanged;

            if (ph != null)
                ph(this, new PropertyChangedEventArgs(name));
        }
    }
}
