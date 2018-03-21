using eUcitelj.DAL.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUcitelj.DAL.Models
{
    public class Predmeti:IPredmeti
    {
  
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public Guid PredmetiId { get; set; }
        
        public Guid KorisnikId { get; set; }

        public string Ime_predmeta { get; set; }

        public int Bodovi_kvizova { get; set; }

        public virtual ICollection<Ocjene> Ocjene { get; set; }//1 predmet moze imati vise ocijena

        public virtual ICollection<Kviz> Kviz { get; set; }//1 predmet moze imati vise kvizova

        [ForeignKey("KorisnikId")]
        public virtual Korisnik Korisnik { get; set; }
    }
}
