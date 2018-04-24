using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUcitelj.DAL.Models
{
    public class Predmet
    {
  
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required(ErrorMessage = "Greška u sustavu (ID predmeta nije stvoren)")]
        public Guid PredmetId { get; set; }

        [Required(ErrorMessage = "Greška u sustavu (ID korisnika nije poznat)")]
        public Guid KorisnikId { get; set; }

        [Required(ErrorMessage = "Ime predmeta je obavezno polje za unos")]
        //[Unique(ErrorMessage = "This already exist !!")]
        public string Ime_predmeta { get; set; }

        public virtual ICollection<Ocjena> Ocjene { get; set; }//1 predmet moze imati vise ocijena

        public virtual ICollection<Kviz> Kviz { get; set; }//1 predmet moze imati vise kvizova

        [ForeignKey("KorisnikId")]
        public virtual Korisnik Korisnik { get; set; }
    }
}
