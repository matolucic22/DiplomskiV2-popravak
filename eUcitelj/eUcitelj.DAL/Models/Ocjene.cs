using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUcitelj.DAL.Models
{
    public class Ocjene
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required(ErrorMessage = "Greška u sustavu (ID korisnika nije stvoren)")]
        public Guid OcjeneId { get; set; }

        [Required(ErrorMessage = "Ocjena je obavezno polje za unos")]
        public int Ocjena { get; set; }

        [Required(ErrorMessage = "Opis je obavezno polje za unos")]
        public string Opis { get; set; }

        [Required(ErrorMessage = "Datum je obavezno polje za unos")]
        [Column(TypeName = "date")]
        public DateTime DatumOcjene { get; set; }

        [Required(ErrorMessage = "Datum je obavezno polje za unos")]
        [Column(TypeName = "date")]
        public DateTime DatumUpisa { get; set; }

        [Required(ErrorMessage = "Greška u sustavu (ID predmeta nije poznat)")]
        public Guid PredmetiId { get; set; }
        [ForeignKey("PredmetiId")]
        public Predmeti Predmeti { get; set; }
    }
}
