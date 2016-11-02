﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TextParser
{
    public class Sentance : Composite
    {
        public override void parse(string str)
        {
            var words = Regex.Matches(str, @"^(\s+|\d+|\w+|[^\d\s\w])+$");

            foreach (var word in words)
            {
                Word w = new Word();
                this.Components.Add(w);
                w.parse(word.ToString());
            }
        }

        public override void show()
        {
            foreach (var w in this.Components)
            {
                w.show();
            }

        }
    }
}