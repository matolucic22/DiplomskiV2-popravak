using eUcitelj.DAL.Common;
using eUcitelj.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUcitelj.Model
{
    public class OcjeneDomainModel:IOcjeneDomainModel
    {
        public Guid OcjeneId { get; set; }
        public Guid PredmetiId { get; set; }
        public int Ocjena { get; set; }
        public virtual IPredmeti Predmeti { get; set; }
    }
}
