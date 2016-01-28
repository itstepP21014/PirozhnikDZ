using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_System
{
    public class QualityMetrics
    {
        public List<string> metrics = new List<string>();

        public List<int> indexes = new List<int>();

        public QualityMetrics(List<int> _indexes, List<string> _metrics)
        {
            metrics = _metrics;
            indexes = _indexes;
        }

        public QualityMetrics()
        {

        }

    }
}
