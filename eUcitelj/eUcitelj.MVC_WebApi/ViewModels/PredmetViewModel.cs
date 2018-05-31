using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eUcitelj.MVC_WebApi.ViewModels
{
    public class PredmetViewModel
    {
        [Required(ErrorMessage = "Ime predmeta je obavezno polje za unos")]
        public string Ime_predmeta { get; set; }

        public Guid Id { get; set; }

        public virtual ICollection<OcjenaViewModel> Ocjene { get; set; }//1 predmet moze imati vise ocjena

        public virtual ICollection<KvizViewModel> Kviz { get; set; }//1 predmet moze imati vise kvizova

        public virtual ICollection<PredmetKorisnikViewModel> PredmetKorisnici { get; set; }

        
    }
}