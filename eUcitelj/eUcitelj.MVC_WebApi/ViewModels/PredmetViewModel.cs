using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eUcitelj.MVC_WebApi.ViewModels
{
    public class PredmetViewModel
    {
        public string Ime_predmeta { get; set; }

        public Guid KorisnikId { get; set; }

        public Guid PredmetId { get; set; }

        public virtual ICollection<OcjenaViewModel> Ocjene { get; set; }//1 predmet moze imati vise ocjena

        public virtual ICollection<KvizViewModel> Kviz { get; set; }//1 predmet moze imati vise kvizova
    }
}