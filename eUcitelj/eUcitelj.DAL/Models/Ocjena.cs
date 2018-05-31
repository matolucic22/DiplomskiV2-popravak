using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUcitelj.DAL.Models
{
    public class Ocjena
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid OcjenaId { get; set; }

        public int Ocj { get; set; }

        public string Opis { get; set; }

        [Column(TypeName = "date")]
        public DateTime DatumOcjene { get; set; }

        [Column(TypeName = "date")]
        public DateTime DatumUpisa { get; set; }

        public Guid PredmetId { get; set; }

        public Guid KorisnikId { get; set; }

        [ForeignKey("PredmetId")]
        public Predmet Predmet { get; set; }
    }
}
