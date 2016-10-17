using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationTest
{
    public class Answer
    {
        public int Id { get; set; }
        public string AnswerText { get; set; }
        public bool IsCorrect { get; set; }
    }
}