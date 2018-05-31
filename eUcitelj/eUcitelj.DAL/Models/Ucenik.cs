using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUcitelj.DAL.Models
{
    public class Ucenik
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid UcenikId { get; set; }

        public Guid KorisnikId { get; set; }//ID roditelja

        public Guid IdKorisnikaU { get; set; }//ID ucenika

        [ForeignKey("KorisnikId")]
        public virtual Korisnik Korisnik { get; set; }
    }
}
