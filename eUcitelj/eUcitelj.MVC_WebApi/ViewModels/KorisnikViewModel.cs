using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace eUcitelj.MVC_WebApi.ViewModels
{
    public class KorisnikViewModel
    {
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Ime korisnika je obavezno polje za unos")]
        public string Ime_korisnika { get; set; }

        [Required(ErrorMessage = "Prezime korisnika je obavezno polje za unos")]
        public string Prezime_korisnika { get; set; }

        [Required(ErrorMessage = "Korisničko ime je obavezno polje za unos")]
        public string Korisnicko_ime { get; set; }

        [Required(ErrorMessage = "Lozinka je obavezno polje za unos")]
        public string Lozinka { get; set; }
        
        public string Potvrda { get; set; }
        
        public string Uloga { get; set; }

        public virtual ICollection<PredmetKorisnikViewModel> PredmetKorisnici { get; set; }//1 korisnik moze biti upisan na vise predmeta
        public virtual ICollection<UcenikViewModel> Ucenici { get; set; }//jedan korsinik role roditelj moze pristupiti vise ucenika ili jednom uceniku
    }
}