using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUcitelj.Model.Common
{
    public interface IKorisnikDomainModel
    {
        
        Guid Id { get; set; }
       
        String Ime_korisnika { get; set; }
       
        String Prezime_korisnika { get; set; }
        
        String Korisnicko_ime { get; set; }
       
        String Lozinka { get; set; }
        
        String Uloga { get; set; }
        
        String Potvrda { get; set; }
        ICollection<IPredmetKorisnikDomainModel> PredmetKorisnici { get; set; }
        ICollection<IUceniciDomainModel> Ucenici { get; set; }
    }
}
