using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUcitelj.Common
{
    public class FilterModel
    {
        public string Redoslijed { get; set; }//sorting
        public string TrazeniPojam { get; set; }//filetring
        public int? BrStr { get; set; }//paging 
        public int  BrEl { get; set; }//paging - broj elemenata na jednoj stranici

        public FilterModel(string redoslijed, string trazeniPojam, int? brStr, int brEl)
        {
            Redoslijed = redoslijed;
            TrazeniPojam = trazeniPojam;
            BrStr = brStr;
            BrEl = brEl;
        }
    }
}
