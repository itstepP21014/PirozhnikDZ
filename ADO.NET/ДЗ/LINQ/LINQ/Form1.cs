using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace LINQ
{
    public partial class Form1 : Form
    {
        List<CD> cd_collection = new List<CD>();
        List<PRODUCER> producer_collection = new List<PRODUCER>();

        public Form1()
        {
            InitializeComponent();

            using (FileStream file = new FileStream("cd_catalog _1.xml", FileMode.Open))
            {
                XmlSerializer xmlFormat = new XmlSerializer(typeof(List<CD>));
                cd_collection = (List<CD>)xmlFormat.Deserialize(file);
            }

            using (FileStream file = new FileStream("cd_catalog _2.xml", FileMode.Open))
            {
                XmlSerializer xmlFormat = new XmlSerializer(typeof(List<PRODUCER>));
                producer_collection = (List<PRODUCER>)xmlFormat.Deserialize(file);
            }

            dgv1.DataSource = cd_collection;
            dgv2.DataSource = producer_collection;

        }

        // запрос №1
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            dgvQueryResult.DataSource = cd_collection.Where(art => art.YEAR > 1993).ToList();
        }

        // запрос №2
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            dgvQueryResult.DataSource = cd_collection.GroupBy(cd => cd.COUNTRY).ToList();
        }

        // запрос №3
        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            dgvQueryResult.DataSource = cd_collection.Where(cd => cd.COUNTRY == "USA")
                .OrderBy(cd => cd.YEAR).Select(alb => new { Albome = alb.TITLE }).ToList();
        }

        // запрос №4
        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            dgvQueryResult.DataSource = cd_collection.GroupBy(gr => gr.COUNTRY)
                .Select(s => new { Country = s.Key, Price = s.Sum(p => p.PRICE)}).ToList();
        }

        // запрос №5
        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            dgvQueryResult.DataSource = cd_collection.OrderBy(y => y.YEAR).GroupBy(gr => new { gr.COMPANY, gr.YEAR })
                .Select(s => new { Company = s.Key.COMPANY, Year = s.Key.YEAR, CountOfAlbums = s.Count() }).ToList();
        }

        // запрос №6
        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            dgvQueryResult.DataSource = producer_collection.OrderByDescending(f => f.FEE)
                .Take(1)
                .Join(cd_collection,
                p => p.ID,
                c => c.PRODUCER,
                (p, c) => new { producer = p.NAME, cd = c.TITLE }).ToList();

        }

        // запрос №7
        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            dgvQueryResult.DataSource = cd_collection.Join(producer_collection,
                c => c.PRODUCER,
                p => p.ID,
                (c, p) => new { Producer = p.NAME, Albom = c.TITLE, Year = c.YEAR }).Where(s => s.Year >= 1988 && s.Year <= 1990)
                .GroupBy(gr => new { Producer = gr.Producer})
                .Select(s => new {Producer = s.Key.Producer, CountOfAlbum = s.Count()}).ToList();
        }

        // запрос №8
        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            dgvQueryResult.DataSource = producer_collection.OrderByDescending(d => d.DATE)
                .Take(1).Select(s => new { Name = s.NAME }).ToList();
        }

        // запрос №9
        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            dgvQueryResult.DataSource = cd_collection.OrderBy(p => p.PRICE)
                .Take(1)
                .Join(producer_collection,
                c => c.PRODUCER,
                p => p.ID,
                (c, p) => new {Albome = c.TITLE, Artist = c.ARTIST , Producer = p.NAME}).ToList();
        }

        // запрос №10
        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            dgvQueryResult.DataSource = cd_collection.OrderBy(y => y.YEAR).ThenBy(p => p.PRICE).ThenBy(t => t.TITLE).ToList();
        }



    }
}
