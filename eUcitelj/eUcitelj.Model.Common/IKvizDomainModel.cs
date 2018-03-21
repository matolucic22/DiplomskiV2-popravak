using eUcitelj.DAL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUcitelj.Model.Common
{
    public interface IKvizDomainModel
    {
        Guid KvizId { get; set; }
        Guid PredmetiId { get; set; }
        String Pitanje { get; set; }
        String Odg1 { get; set; }
        String Odg2 { get; set; }
        String Odg3 { get; set; }
        String Tocan_odgovor { get; set; }
        int Bodovi { get; set; }
    }
}
