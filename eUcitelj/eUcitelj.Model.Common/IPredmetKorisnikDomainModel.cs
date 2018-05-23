using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUcitelj.Model.Common
{
    public interface IPredmetKorisnikDomainModel
    {
        Guid PredmetKorisnikId { get; set; }
        Guid KorisnikId { get; set; }
        Guid PredmetId { get; set; }
    }
}
