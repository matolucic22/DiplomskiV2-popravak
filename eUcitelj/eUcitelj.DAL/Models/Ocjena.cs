using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUcitelj.DAL.Models
{
    public class Ocjena
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required(ErrorMessage = "Greška u sustavu (ID korisnika nije stvoren)")]
        public Guid OcjenaId { get; set; }

        [Required(ErrorMessage = "Ocjena je obavezno polje za unos")]
        public int Ocj { get; set; }

        [Required(ErrorMessage = "Opis je obavezno polje za unos")]
        public string Opis { get; set; }

        [Required(ErrorMessage = "Datum je obavezno polje za unos")]
        [Column(TypeName = "date")]
        public DateTime DatumOcjene { get; set; }

        [Required(ErrorMessage = "Datum je obavezno polje za unos")]
        [Column(TypeName = "date")]
        public DateTime DatumUpisa { get; set; }

        [Required(ErrorMessage = "Greška u sustavu (ID predmeta nije poznat)")]
        public Guid PredmetId { get; set; }
        [ForeignKey("PredmetId")]
        public Predmet Predmeti { get; set; }
    }
}
