using eUcitelj.DAL.Models;
using eUcitelj.Model.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUcitelj.Model
{
   public class KorisnikDomainModel:IKorisnikDomainModel
    {
        
        public Guid Id { get; set; }
        
        public string Ime_korisnika { get; set; }
        
        public string Prezime_korisnika { get; set; }
        
        public string Korisnicko_ime { get; set; }
        
        public string Lozinka { get; set; }
        
        public string Potvrda { get; set; }
        
        public string Uloga { get; set; }

        public virtual ICollection<IPredmetKorisnikDomainModel> PredmetKorisnici { get; set; }
        public virtual ICollection<IUceniciDomainModel> Ucenici { get; set; }//1 korisnik moze imati vise ucenika(ako je Role=roditelj)
    }
}
