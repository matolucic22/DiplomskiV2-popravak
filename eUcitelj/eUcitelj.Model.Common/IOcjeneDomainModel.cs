using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUcitelj.Model.Common
{
    public interface IOcjeneDomainModel
    {
        Guid OcjenaId { get; set; }
        Guid PredmetId { get; set; }
        Guid KorisnikId { get; set; }
        int Ocj { get; set; }
        string Opis { get; set; }
        DateTime DatumOcjene { get; set; }
        DateTime DatumUpisa { get; set; }
    }
}
