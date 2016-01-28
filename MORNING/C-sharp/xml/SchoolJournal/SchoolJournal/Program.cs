using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace SchoolJournal
{
    class Program
    {
        static void Main(string[] args)
        {
            // список учителей
            List<Teacher> list_of_teachers = new List<Teacher>();
            list_of_teachers.Add(new Teacher("MARIA IVANOVNA"));
            list_of_teachers.Add(new Teacher("PETR MIHALYCH"));

            //Dictionary<string, Teacher> list_of_teachers = new Dictionary<string, Teacher>();
            //list_of_teachers.Add("Марья Ивановна", new Teacher("Марья Ивановна"));
            //list_of_teachers.Add("Петр Михалыч", new Teacher("Петр Михалыч"));

            // группа учеников
            Group group_1A = new Group("1A");
            Pupil pupil_1 = new Pupil("VASIA IVANOV");
            Pupil pupil_2 = new Pupil("PETIA PETROV");
            Pupil pupil_3 = new Pupil("ALISA BAKINA");
            Pupil pupil_4 = new Pupil("ANIA KOSHKINA");
            Pupil pupil_5 = new Pupil("MISHA TRUS");
            group_1A.pupil_group.Add(pupil_1);
            group_1A.pupil_group.Add(pupil_2);
            group_1A.pupil_group.Add(pupil_3);
            group_1A.pupil_group.Add(pupil_4);
            group_1A.pupil_group.Add(pupil_5);

            // список предметов
            List<Subject> list_of_subjects = new List<Subject>();
            list_of_subjects.Add(new Subject("MATH"));
            list_of_subjects.Add(new Subject("RUSSIAN"));
            list_of_subjects.Add(new Subject("ART"));

            // список занятий
            List<Lesson> list_of_lessins = new List<Lesson>();

            // учитель отмечает присутствующих

            // учитель начинает занятие и объявляет тему
            list_of_lessins.Add(new Lesson(list_of_teachers[0], group_1A, list_of_subjects[2], "TOPIC_1 OF LESSON_1"));
 
            // учитель ставит оценки
            list_of_lessins[0].GiveMark(pupil_3, 10, ZA_CHTO_OCENKA.class_work);
            list_of_lessins[0].GiveMark(pupil_2, 7, ZA_CHTO_OCENKA.class_work);
            list_of_lessins[0].GiveMark(pupil_5, 5, ZA_CHTO_OCENKA.class_work);


            XmlSerializer formatter = new XmlSerializer(typeof(Lesson));
            using (FileStream file = new FileStream("C:/users/st/school_journal_serialization.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(file, list_of_lessins[0]);
                file.Close();
            }


            //XmlSerializer deserializer = new XmlSerializer(typeof(Lesson));
            //using (FileStream file = new FileStream("file.xml", FileMode.OpenOrCreate))
            //{
            //    deserializer.Deserialize(file);
            //    file.Close();
            //}

            Console.ReadLine();

        }
    }
}
