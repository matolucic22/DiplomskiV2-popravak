using eUcitelj.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUcitelj.Model
{
    public class PredmetKorisnikDomainModel : IPredmetKorisnikDomainModel
    {
        public Guid PredmetKorisnikId { get; set; }
        public Guid KorisnikId { get; set; }
        public Guid PredmetId { get; set; }
    }
}
