using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eUcitelj.MVC_WebApi.ViewModels
{
    public class UcenikViewModel
    {
        public Guid UcenikId { get; set; }
        
        public Guid KorisnikId { get; set; }
        
        public Guid IdKorisnikaU { get; set; }

        [Required(ErrorMessage = "Ime korisnika je obavezno polje za unos")]
        public String Ime_korisnika { get; set; }

        [Required(ErrorMessage = "Prezime korisnika je obavezno polje za unos")]
        public String Prezime_korisnika { get; set; }
    }
}