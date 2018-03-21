using eUcitelj.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUcitelj.Model
{
    public class UceniciDomainModel:IUceniciDomainModel
    {
       public Guid UceniciId { get; set; }
       public Guid KorisnikId { get; set; }
       public Guid IdKorisnikaU { get; set; }
       public String Ime_korisnika { get; set; }
       public String Prezime_korisnika { get; set; }
    }
}
