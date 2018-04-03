using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace eUcitelj.MVC_WebApi.ViewModels
{
    public class OcjenaViewModel
    {
        public Guid OcjenaId { get; set; }
        public Guid PredmetId { get; set; }
        public int Ocj { get; set; }
        public string Opis { get; set; }
        [Column(TypeName = "date")]
        public DateTime DatumOcjene { get; set; }
        [Column(TypeName = "date")]
        public DateTime DatumUpisa { get; set; }
    }
}