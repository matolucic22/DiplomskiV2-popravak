using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace eUcitelj.MVC_WebApi.ViewModels
{
    public class OcjenaViewModel
    {
        public Guid OcjenaId { get; set; }

        
        public Guid PredmetId { get; set; }

       
        public Guid KorisnikId { get; set; }

        [Required(ErrorMessage = "Ocjena je obavezno polje za unos")]
        public int Ocj { get; set; }

        [Required(ErrorMessage = "Opis je obavezno polje za unos")]
        public string Opis { get; set; }

        [Required(ErrorMessage = "Datum je obavezno polje za unos")]
        [Column(TypeName = "date")]
        public DateTime DatumOcjene { get; set; }

        [Column(TypeName = "date")]
        public DateTime DatumUpisa { get; set; }
    }
}