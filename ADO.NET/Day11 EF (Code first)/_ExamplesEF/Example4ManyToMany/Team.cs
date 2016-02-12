﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Example4ManyToMany
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Player> Players { get; set; }
    }
}
