using eUcitelj.DAL.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUcitelj.DAL.Models
{
    public class Ocjene:IOcjene
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid OcjeneId { get; set; }
        public int Ocjena { get; set; }
        public string Opis { get; set; }
        [Column(TypeName = "date")]
        public DateTime DatumOcjene { get; set; }
        [Column(TypeName = "date")]
        public DateTime DatumUpisa { get; set; }
        public Guid PredmetiId { get; set; }
        [ForeignKey("PredmetiId")]
        public Predmeti Predmeti { get; set; }
    }
}
