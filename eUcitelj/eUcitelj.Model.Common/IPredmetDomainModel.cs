using eUcitelj.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUcitelj.Model.Common
{
   public interface IPredmetDomainModel
    {
        Guid Id { get; set; }
        String Ime_predmeta { get; set; }        

        ICollection<IOcjeneDomainModel> Ocjene { get; set; }//1 predmet moze imati vise ocijena

        ICollection<IKvizDomainModel> Kviz { get; set; }//1 predmet moze imati vise ocijena

        ICollection<IPredmetKorisnikDomainModel> PredmetKorisnici { get; set; }
    }
}
