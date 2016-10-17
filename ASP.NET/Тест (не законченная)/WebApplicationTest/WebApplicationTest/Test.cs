using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationTest
{
    public class Test
    {
        public List<Question> QuestionCollection { get; set; }

        public Test()
        {
            QuestionCollection = this.GenerateTest();
        }

        public List<Question> GenerateTest()
        {
            return new List<Question> {
                new Question {
                    QuestionText = "Вопрос 1", Type = "radio", AnswersCollection = new List<Answer> {
                        new Answer { AnswerText = "вариант 1", IsCorrect = false},
                        new Answer { AnswerText = "вариант 2", IsCorrect = false},
                        new Answer { AnswerText = "вариант 3", IsCorrect = false},
                        new Answer { AnswerText = "вариант 4", IsCorrect = true}
                    }
                },
                 new Question {
                    QuestionText = "Вопрос 2", Type = "checkbox", AnswersCollection = new List<Answer> {
                        new Answer { AnswerText = "вариант 1", IsCorrect = false},
                        new Answer { AnswerText = "вариант 2", IsCorrect = false},
                        new Answer { AnswerText = "вариант 3", IsCorrect = true},
                        new Answer { AnswerText = "вариант 4", IsCorrect = false}
                    }
                },
                 new Question {
                    QuestionText = "Вопрос 3", Type = "radio", AnswersCollection = new List<Answer> {
                        new Answer { AnswerText = "вариант 1", IsCorrect = true},
                        new Answer { AnswerText = "вариант 2", IsCorrect = false},
                        new Answer { AnswerText = "вариант 3", IsCorrect = false},
                        new Answer { AnswerText = "вариант 4", IsCorrect = false}
                    }
                }
            };
        }
    }
}