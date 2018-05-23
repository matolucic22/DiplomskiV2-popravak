using eUcitelj.DAL.Models;
using eUcitelj.Model.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUcitelj.Model
{
    public class OcjenaDomanModel:IOcjeneDomainModel
    {
        public Guid OcjenaId { get; set; }       
        public Guid PredmetId { get; set; }
        public Guid KorisnikId { get; set; }
        public int Ocj { get; set; }
        public string Opis { get; set; }
        [Column(TypeName = "date")]
        public DateTime DatumOcjene { get; set; }
        [Column(TypeName = "date")]
        public DateTime DatumUpisa { get; set; }
    }
}
