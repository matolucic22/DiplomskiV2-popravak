using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUcitelj.DAL.Models
{
    public class Kviz
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required(ErrorMessage = "Greška u sustavu (ID kviza nije stvoren)")]
        public Guid KvizId { get; set; }

        [Required(ErrorMessage = "Bodovi je obavezno polje za unos")]
        public int Bodovi { get; set; }

        [Required(ErrorMessage = "Odgovor je obavezno polje za unos")]
        public string Odg1 { get; set; }

        [Required(ErrorMessage = "Odgovor je obavezno polje za unos")]
        public string Odg2 { get; set; }

        [Required(ErrorMessage = "Odgovor je obavezno polje za unos")]
        public string Odg3 { get; set; }

        [Required(ErrorMessage = "Pianje je obavezno polje za unos")]
        public string Pitanje { get; set; }

        [Required(ErrorMessage = "Greška u sustavu (ID predmeta nije poznat)")]
        public Guid PredmetiId { get; set; }

        [Required(ErrorMessage = "Točan odgovor je obavezno polje za unos")]
        public string Tocan_odgovor { get; set; }

    }
}
