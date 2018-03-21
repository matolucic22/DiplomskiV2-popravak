using eUcitelj.DAL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUcitelj.DAL.Common
{
    public interface IPredmeti
    {
        Guid PredmetiId { get; set; }
        Guid KorisnikId { get; set; }
        String Ime_predmeta { get; set; }
        int Bodovi_kvizova { get; set; }
    }
}
