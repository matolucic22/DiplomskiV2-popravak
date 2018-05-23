using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eUcitelj.MVC_WebApi.ViewModels
{
    public class KvizViewModel
    {
        
        public Guid KvizId { get; set; }

        
        public Guid PredmetId { get; set; }

        [Required(ErrorMessage = "Pitanje je obavezno polje za unos")]
        public String Pitanje { get; set; }

        [Required(ErrorMessage = "Odgovor je obavezno polje za unos")]
        public String Odg1 { get; set; }

        [Required(ErrorMessage = "Odgovor je obavezno polje za unos")]
        public String Odg2 { get; set; }

        [Required(ErrorMessage = "Odgovor je obavezno polje za unos")]
        public String Odg3 { get; set; }

        [Required(ErrorMessage = "Tocan odgovor je obavezno polje za unos")]
        public String Tocan_odgovor { get; set; }
    }
}