using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUcitelj.DAL.Models
{
    public class Ucenici
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required(ErrorMessage = "Greška u sustavu (ID korisnika nije stvoren)")]
        public Guid UceniciId { get; set; }

        [Required(ErrorMessage = "Greška u sustavu (ID korisnika nije poznat)")]
        public Guid KorisnikId { get; set; }

        [Required(ErrorMessage = "Greška u sustavu (ID korisnika nije poznat)")]
        public Guid IdKorisnikaU { get; set; }

        [Required(ErrorMessage = "Ime korisnika je obavezno polje za unos")]
        public String Ime_korisnika { get; set; }

        [Required(ErrorMessage = "Prezime korisnika je obavezno polje za unos")]
        public String Prezime_korisnika { get; set; }

        [ForeignKey("KorisnikId")]
        public virtual Korisnik Korisnik { get; set; }
    }
}
