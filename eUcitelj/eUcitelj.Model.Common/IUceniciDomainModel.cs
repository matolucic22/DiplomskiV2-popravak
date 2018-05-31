using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUcitelj.Model.Common
{
    public interface IUceniciDomainModel
    {
        Guid UcenikId { get; set; }
        Guid KorisnikId { get; set; }
        Guid IdKorisnikaU { get; set; }
    }
}
