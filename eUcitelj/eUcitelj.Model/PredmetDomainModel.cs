using eUcitelj.DAL.Models;
using eUcitelj.Model;
using eUcitelj.Model.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUcitelj.Model
{
    public class PredmetDomainModel:IPredmetDomainModel
    {
        public string Ime_predmeta { get; set; }
        
        public Guid Id { get; set; }

        public virtual ICollection<IOcjeneDomainModel> Ocjene { get; set; }//1 predmet moze imati vise ocjena

        public virtual ICollection<IKvizDomainModel> Kviz { get; set; }//1 predmet moze imati vise kvizova

        public virtual ICollection<IPredmetKorisnikDomainModel> PredmetKorisnici { get; set; }
    }
}

    

