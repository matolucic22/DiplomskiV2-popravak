using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUcitelj.DAL.Common
{
    public interface IUcenici
    {
        Guid UceniciId { get; set; }
        Guid KorisnikId { get; set; }
        Guid IdKorisnikaU { get; set; }
        String Ime_korisnika { get; set; }
        String Prezime_korisnika { get; set; }
    }
}
