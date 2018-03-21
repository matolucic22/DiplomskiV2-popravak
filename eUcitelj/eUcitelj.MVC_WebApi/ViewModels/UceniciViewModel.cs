using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eUcitelj.MVC_WebApi.ViewModels
{
    public class UceniciViewModel
    {
        public Guid UceniciId { get; set; }
        public Guid KorisnikId { get; set; }
        public Guid IdKorisnikaU { get; set; }
        public String Ime_korisnika { get; set; }
        public String Prezime_korisnika { get; set; }
    }
}