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
    public partial class Form5 : Form
    {
        public string kind = null;

        public Form5()
        {
            InitializeComponent();
            choise_kind_comboBox.Items.Add("по предмету");
            choise_kind_comboBox.Items.Add("по пеподавателю");
            choise_kind_comboBox.Items.Add("по учебной группе");
            choise_kind_comboBox.SelectedIndex = 0;
            kind_comboBox.SelectedIndex = 0;
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("C:/users/st/lessons.xml");

            // если вид по предмету
            //foreach (XmlElement LessonNode in doc.SelectNodes("/lessons/lesson[" + kind + "/@id='" + kind_comboBox.SelectedItem.ToString() + "']"))
            foreach (XmlElement LessonNode in doc.SelectNodes("/lessons/lesson[" + "subject" + "/@id='" + "math" + "']"))
            {
                dataGridView1.Rows.Add(LessonNode["date"].InnerText,
                                        LessonNode["lessonNum"].InnerText,
                                        LessonNode["group"].Attributes["id"].Value.ToString(),
                                        LessonNode["teacher"].Attributes["id"].Value.ToString(),
                                        //LessonNode["topic"].InnerText);
                                        kind);
            }

            // если вид по преподавателю
            // teacher

            // если вид по уч.группе
            // group

        }

        private void choise_kind_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (choise_kind_comboBox.SelectedIndex)
            {
                case 0:
                    this.kind_comboBox.Items.Clear();
                    kind = "subject";
                    this.kind_label.Text = "Предмет:";
                    this.kind_comboBox.Items.Add("Физкультура");
                    this.kind_comboBox.Items.Add("Труд");
                    this.kind_comboBox.Items.Add("Идеология");
                    kind_comboBox.SelectedIndex = 0;
                    break;
                case 1:
                    this.kind_comboBox.Items.Clear();
                    kind = "teacher";
                    this.kind_label.Text = "Преподаватель:";
                    this.kind_comboBox.Items.Add("Марья Ивановна");
                    this.kind_comboBox.Items.Add("Петр Михалыч");
                    this.kind_comboBox.Items.Add("Елена Васильевна");
                    kind_comboBox.SelectedIndex = 0;
                    break;
                case 2:
                    this.kind_comboBox.Items.Clear();
                    kind = "group";
                    this.kind_label.Text = "Уч. группа:";
                    this.kind_comboBox.Items.Add("1'A'");
                    this.kind_comboBox.Items.Add("3'B'");
                    this.kind_comboBox.Items.Add("2'Б'");
                    kind_comboBox.SelectedIndex = 0;
                    break;
                default:
                    //Console.WriteLine("Default case");
                    break;
            }

        }

    }
}
