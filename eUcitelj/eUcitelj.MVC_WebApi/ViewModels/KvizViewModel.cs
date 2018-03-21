using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eUcitelj.MVC_WebApi.ViewModels
{
    public class KvizViewModel
    {
        public Guid KvizId { get; set; }
        public Guid PredmetiId { get; set; }
        public String Pitanje { get; set; }
        public String Odg1 { get; set; }
        public String Odg2 { get; set; }
        public String Odg3 { get; set; }
        public String Tocan_odgovor { get; set; }
      //  public int Bodovi { get; set; }
    }
}