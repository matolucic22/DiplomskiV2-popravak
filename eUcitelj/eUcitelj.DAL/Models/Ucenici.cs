using eUcitelj.DAL.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUcitelj.DAL.Models
{
    public class Ucenici:IUcenici
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid UceniciId { get; set; }
        public Guid KorisnikId { get; set; }
        public Guid IdKorisnikaU { get; set; }
        public String Ime_korisnika { get; set; }
        public String Prezime_korisnika { get; set; }

        [ForeignKey("KorisnikId")]
        public virtual Korisnik Korisnik { get; set; }
    }
}
