using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Example
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();

            List<TimeSpan> t = new List<TimeSpan>();
            t.Add(new TimeSpan(8, 45, 0));
            t.Add(new TimeSpan(9, 45, 0));
            t.Add(new TimeSpan(10, 45, 0));
            t.Add(new TimeSpan(11, 45, 0));
            t.Add(new TimeSpan(12, 45, 0));

            time_comboBox.Items.Add("1 урок: 8:00 - 8:45");
            time_comboBox.Items.Add("2 урок: 9:00 - 9:45");
            time_comboBox.Items.Add("3 урок: 10:00 - 10:45");
            time_comboBox.Items.Add("4 урок: 11:00 - 11:45");
            time_comboBox.Items.Add("5 урок: 12:00 - 12:45");

            for (int i = 0; i < t.Count; ++i)
            {
                if (DateTime.Now.TimeOfDay.CompareTo(t[i]) < 0)
                {
                    time_comboBox.SelectedIndex = i;
                    break;
                }
            }
        }

        private void time_label_Click(object sender, EventArgs e)
        {

        }

        private void time_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            switch (this.time_comboBox.SelectedIndex)
            {
                case 0:
                    this.name_subject_lable.Text = "Математика";
                    this.group_name_label.Text = "1'A'";
                    break;
                case 1:
                    this.name_subject_lable.Text = "Русский язык";
                    this.group_name_label.Text = "2'A'";
                    break;
                case 2:
                    this.name_subject_lable.Text = "Английский язык";
                    this.group_name_label.Text = "1'A'";
                    break;
                case 3:
                    this.name_subject_lable.Text = "Английский язык";
                    this.group_name_label.Text = "3'В'";
                    break;
                case 4:
                    this.name_subject_lable.Text = "Математика";
                    this.group_name_label.Text = "5'Б'";
                    break;
                default:
                    //Console.WriteLine("Default case");
                    break;
            }
        }

        private void subject_label_Click(object sender, EventArgs e)
        {

        }

        private void OK_button_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("C:/users/st/lessons.xml");
            var lesson = doc.CreateElement("lesson");
            
            lesson.InnerXml = "<teacher id=' '/><group id=' '/><subject id=' '/><date>" 
                               + this.dateTimePicker.Value.Date.ToString().Split(new char[]{' '})[0] 
                               + "</date><lessonNum>" + this.time_comboBox.SelectedIndex.ToString() 
                               + "</lessonNum><topic>" + this.topic_textBox.Text + "</topic>";
            
            doc.SelectSingleNode("/lessons").AppendChild(lesson);
            doc.Save("C:/users/st/lessons.xml");
            this.Hide();
        }

    }
}
