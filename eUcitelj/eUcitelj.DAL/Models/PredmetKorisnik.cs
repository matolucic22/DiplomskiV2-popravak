using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUcitelj.DAL.Models
{
    public class PredmetKorisnik
    {
        public Guid PredmetKorisnikId { get; set; }
        
        public Guid PredmetId { get; set; }

        public Guid KorisnikId { get; set; }

        [ForeignKey("PredmetId")]
        public virtual Predmet Predmet { get; set; }

        [ForeignKey("KorisnikId")]
        public virtual Korisnik Korisnik { get; set; }
    }
}
