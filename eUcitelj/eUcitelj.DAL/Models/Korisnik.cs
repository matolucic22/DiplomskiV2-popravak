using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eUcitelj.DAL.Models
{
    public class Korisnik
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required(ErrorMessage = "Greška u sustavu (ID korisnika nije stvoren)")]
        public Guid KorisnikId { get; set; }

        [Required(ErrorMessage = "Ime korisnika je obavezno polje za unos")]
        public string Ime_korisnika { get; set; }

        [Required(ErrorMessage = "Prezime korisnika je obavezno polje za unos")]
        public string Prezime_korisnika { get; set; }

        [Required(ErrorMessage = "Korisničko ime je obavezno polje za unos")]
        public string Korisnicko_ime { get; set; }

        [Required(ErrorMessage = "Lozinka je obavezno polje za unos")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Potvrda je obavezno polje za unos")]
        public string Potvrda { get; set; }

        [Required(ErrorMessage = "Greška u sustavu (Role)")]
        public string Role { get; set; }

        public virtual ICollection<Predmeti> Predmeti { get; set; }//1 korisnik moze biti upisan na vise predmeta
        public virtual ICollection<Ucenici> Ucenici { get; set; }//1 korisnik logiran kao roditelj moze imati vise ucenika
    }
}
