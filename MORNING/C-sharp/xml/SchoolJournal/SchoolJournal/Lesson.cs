using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolJournal
{
    [Serializable]
    public class Lesson
    {
        public Lesson() { }

        public Subject subject;
        public Teacher teacher;
        public string topic;
        public Group group;
        public List<Mark> scores = new List<Mark>();
        // кто был на занятии
        // дата

        public Lesson(Teacher _teacher, Group _group, Subject _subject, string _topic)
        {
            teacher = _teacher;
            group = _group;
            subject = _subject;
            topic = _topic;
        }

        public void GiveMark(Pupil pupil, int score, ZA_CHTO_OCENKA za_chto)
        {
            scores.Add(new Mark(teacher, pupil, score, za_chto));
        }

    }
}
