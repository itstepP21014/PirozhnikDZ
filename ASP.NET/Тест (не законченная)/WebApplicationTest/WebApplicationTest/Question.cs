using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationTest
{
    public class Question
    {
        public string QuestionText { get; set; }
        public List<Answer> AnswersCollection { get; set; }
        public string Type { get; set; }

        public void AddAnswer(Answer _newAnswer)
        {
            AnswersCollection.Add(_newAnswer);
        }
    }
}