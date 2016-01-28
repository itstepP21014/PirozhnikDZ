using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SchoolJournal
{
    [Serializable]

    public enum ZA_CHTO_OCENKA { home_work, class_work, test }

    public class Mark
    {
        public Mark() { }

        public ZA_CHTO_OCENKA for_what;
        public int score;
        private Pupil pupil;
        [XmlAttribute] public int pupil_Id;

        [XmlIgnore] public Pupil Pupil
        {
            get
            {
                return pupil;
            }
            set
            {
                pupil = value;
                pupil_Id = value.id;
            }
        }
        
        private Teacher teacher;
        [XmlAttribute] public int teacher_Id;

        [XmlIgnore] public Teacher Teacher
        {
            get
            {
                return teacher;
            }
            set
            {
                teacher = value;
                teacher_Id = value.id;
            }
        }

        public Mark(Teacher _teacher, Pupil _pupil, int _score, ZA_CHTO_OCENKA za_chto)
        {
            teacher = _teacher;
            pupil = _pupil;
            for_what = za_chto;
            pupil_Id = _pupil.id;
            teacher_Id = _teacher.id;
            score = _score;
        }

    }
}
