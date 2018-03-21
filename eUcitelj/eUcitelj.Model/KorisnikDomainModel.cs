using eUcitelj.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUcitelj.Model
{
   public class KorisnikDomainModel:IKorisnikDomainModel
    {
        public Guid KorisnikId { get; set; }

        public string Ime_korisnika { get; set; }

        public string Prezime_korisnika { get; set; }

        public string Korisnicko_ime { get; set; }

        public string Password { get; set; }

        public string Potvrda { get; set; }

        public string Role { get; set; }

        public virtual ICollection<IPredmetiDomainModel> Predmeti { get; set; }//1 korisnit moze biti upisan na vise predmeta
        public virtual ICollection<IUceniciDomainModel> Ucenici { get; set; }//1 korisnit moze biti upisan na vise predmeta
    }
}
