using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_System
{
    public class Person
    {
        public Person(string _name, string _photo, List<Project> _listOfPprojects, DEPARTMENT _department, QualityMetrics _perform)
        {
            name = _name;
            photo = _photo;
            doneProjects = _listOfPprojects;
            department = _department;
            performance = _perform;
        }

        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string name;
    
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private DateTime birthday;

        public DateTime Birthday
        {
            get { return birthday; }
            set { birthday = value; }
        }
        private string adress;

        public string Adress
        {
            get { return adress; }
            set { adress = value; }
        }
        private string photo;

        public string Photo
        {
            get { return photo; }
            set { photo = value; }
        }
        private string post;

        public string Post
        {
            get { return post; }
            set { post = value; }
        }
        private int salary;

        public int Salary
        {
            get { return salary; }
            set { salary = value; }
        }
        private List<Project> doneProjects = new List<Project>();

        public List<Project> DoneProjects
        {
            get { return doneProjects; }
            set { doneProjects = value; }
        }

        private int rating;

        public int Rating
        {
            get { return rating; }
            set { rating = value; }
        }

        private DEPARTMENT department;

        public DEPARTMENT Department
        {
            get { return department; }
            set { department = value; }
        }

        public enum DEPARTMENT
        {
            Directors,
            Programmers,
            Managers,
            Disigners
        }

        QualityMetrics performance;

        public QualityMetrics Performance
        {
            get { return performance; }
            set { performance = value; }
        }

    }
}
