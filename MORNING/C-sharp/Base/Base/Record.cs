using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FileRecords
{
    class Record
    {
        string firstName;
        string lastName;
        string pasport;

        public Record(string record)
        {
            string[] tmp;
            tmp = record.Split(new Char[] { ';' });
            firstName = tmp[0];
            lastName = tmp[1];
            pasport = tmp[2];

        }

    }
}
