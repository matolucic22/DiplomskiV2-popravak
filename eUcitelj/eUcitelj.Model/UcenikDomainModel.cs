using eUcitelj.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUcitelj.Model
{
    public class UcenikDomainModel:IUceniciDomainModel
    {
       public Guid UcenikId { get; set; }
       public Guid KorisnikId { get; set; }
       public Guid IdKorisnikaU { get; set; }
    }
}
