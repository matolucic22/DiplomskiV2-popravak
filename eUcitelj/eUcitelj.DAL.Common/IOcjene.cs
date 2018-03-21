using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUcitelj.DAL.Common
{
   public interface IOcjene
    {
        Guid OcjeneId { get; set; }
        Guid PredmetiId { get; set; }
        int Ocjena { get; set; }
        string Opis { get; set; }
        DateTime DatumOcjene { get; set; }
        DateTime DatumUpisa { get; set; }
    }
}
