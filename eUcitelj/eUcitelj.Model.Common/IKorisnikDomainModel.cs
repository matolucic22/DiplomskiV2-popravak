using eUcitelj.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUcitelj.Model.Common
{
   public interface IKorisnikDomainModel
    {
        Guid KorisnikId { get; set; }
        String Ime_korisnika { get; set; }
        String Prezime_korisnika { get; set; }
        String Korisnicko_ime { get; set; }
        String Password { get; set; }
        String Role { get; set; }
        String Potvrda { get; set; }
        ICollection<IPredmetiDomainModel> Predmeti { get; set; }
        ICollection<IUceniciDomainModel> Ucenici { get; set; }
    }
}
