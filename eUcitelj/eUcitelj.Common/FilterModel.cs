using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUcitelj.Common
{
    public class FilterModel
    {
        public string Redoslijed { get; set; }
        public string TrazeniPojam { get; set; }
        public int? BrStr { get; set; }

        public FilterModel(string redoslijed, string trazeniPojam, int? brStr)
        {
            Redoslijed = redoslijed;
            TrazeniPojam = trazeniPojam;
            BrStr = brStr;
        }
    }
}
