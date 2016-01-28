using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolJournal
{
    [Serializable]
    public class Subject
    {
        public Subject() { }

        public string title;
        public List<string> topics = new List<string>();

        public Subject(string _title)
        {
            title = _title;
        }

    }
}
