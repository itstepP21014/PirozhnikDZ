using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_System
{
    public class QualityMetrics
    {
        public QualityMetrics(int m_1, int m_2, int m_3, int m_4, int m_5)
        {
            metrica_1 = m_1;
            metrica_2 = m_2;
            metrica_3 = m_3;
            metrica_4 = m_4;
            metrica_5 = m_5;
        }

        private int metrica_1;

        public int Metrica_1
        {
            get { return metrica_1; }
            set { metrica_1 = value; }
        }
        private int metrica_2;

        public int Metrica_2
        {
            get { return metrica_2; }
            set { metrica_2 = value; }
        }
        private int metrica_3;

        public int Metrica_3
        {
            get { return metrica_3; }
            set { metrica_3 = value; }
        }
        private int metrica_4;

        public int Metrica_4
        {
            get { return metrica_4; }
            set { metrica_4 = value; }
        }
        private int metrica_5;

        public int Metrica_5
        {
            get { return metrica_5; }
            set { metrica_5 = value; }
        }
    }
}
