using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainObjects
{
    public class Comment
    {
        [Key]
        public int CommentID { get; set; }
        public string Message { get; set; }
        public DateTime CreateData { get; set; }
        public int UserID { get; set; }


        public int NewsID { get; set; }
        public virtual News News { get; set; }
    }
}
