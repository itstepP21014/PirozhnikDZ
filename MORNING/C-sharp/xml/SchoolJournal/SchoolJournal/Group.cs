using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolJournal
{
    [Serializable]
    public class Group
    {
        public Group() { }

        public string name;
        public List<Pupil> pupil_group = new List<Pupil>();

        public Group(string _name)
        {
            name = _name;
        }

    }
}
