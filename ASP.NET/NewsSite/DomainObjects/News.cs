using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainObjects
{
    public class News
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NewsID { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }
        public DateTime CreateData { get; set; }
        public bool Hot { get; set; }
        public TypeEnum Type { get; set; }

        public virtual List<Comment> Comments { get; set; }
    }
}
